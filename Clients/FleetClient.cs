using Newtonsoft.Json.Linq;
using SpaceTradersDotNetSDK.Http;
using SpaceTradersDotNetSDK.Models;
using SpaceTradersDotNetSDK.Models.Enums;
using SpaceTradersDotNetSDK.ResponseModels.Fleet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Data;
using System.Runtime.Intrinsics.X86;

namespace SpaceTradersDotNetSDK.Clients
{
    public class FleetClient : APIClient
    {
        public FleetClient(IAPIConnector apiConnector, Uri baseAdress) : base(apiConnector, baseAdress)
        { }

        /// <summary>
        /// Retrieve all of your ships.
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<List<Ship>> ListMyShips(int limit = 20, int page = 1)
        {
            if (limit < 1 || limit > 20)
                throw new ApplicationException($"Can't set limit lower then 0 or higher then 20");
            if (page < 1)
                throw new ApplicationException($"Can't set page lower then 0");

            return await API.Get<List<Ship>>(new Uri("my/ships", UriKind.Relative), new Dictionary<string, string>
            {
                { "limit", limit.ToString() },
                { "page", page.ToString() }
            });
        }

        /// <summary>
        /// Retrieve the details of your ship.
        /// </summary>
        /// <param name="shipSymbol"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<Ship> GetShip(string shipSymbol)
        {
            if (string.IsNullOrEmpty(shipSymbol))
                throw new ArgumentNullException(nameof(shipSymbol));

            return await API.Get<Ship>(new Uri($"my/ships/{shipSymbol}", UriKind.Relative));
        }
        
        /// <summary>
        /// Retrieve the cargo of your ship.
        /// </summary>
        /// <param name="shipSymbol"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<ShipCargo> GetShipCargo(string shipSymbol)
        {
            if (string.IsNullOrEmpty(shipSymbol))
                throw new ArgumentNullException(nameof(shipSymbol));

            return await API.Get<ShipCargo>(new Uri($"my/ships/{shipSymbol}/cargo", UriKind.Relative));
        }

        /// <summary>
        /// Purchase a ship
        /// </summary>
        /// <param name="shipType"></param>
        /// <param name="waypointSymbol"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<PurchaseShipResponse> PurchaseShip(string shipType, string waypointSymbol)
        {
            if (string.IsNullOrEmpty(waypointSymbol))
                throw new ArgumentNullException(nameof(waypointSymbol));

            return await API.Post<PurchaseShipResponse>(new Uri("my/ships", UriKind.Relative), null, new
            {
                shipType = shipType,
                waypointSymbol = waypointSymbol
            });
        }

        /// <summary>
        /// Attempt to move your ship into orbit at it's current location. The request will only succeed if your ship is capable of moving into orbit at the time of the request.
        /// 
        /// The endpoint is idempotent - successive calls will succeed even if the ship is already in orbit.
        /// </summary>
        /// <param name="shipSymbol"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<OrbitResponse> OrbitShip(string shipSymbol)
        {
            if (string.IsNullOrEmpty(shipSymbol))
                throw new ArgumentNullException(nameof(shipSymbol));

            return await API.Post<OrbitResponse>(new Uri($"my/ships/{shipSymbol}/orbit", UriKind.Relative));
        }

        /// <summary>
        /// Attempt to refine the raw materials on your ship. The request will only succeed if your ship is capable of refining at the time of the request.
        /// </summary>
        /// <param name="shipSymbol"></param>
        /// <param name="produce"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<ShipRefineResponse> Refine(string shipSymbol, Produce produce)
        {
            if (string.IsNullOrEmpty(shipSymbol))
                throw new ArgumentNullException(nameof(shipSymbol));

            return await API.Post<ShipRefineResponse>(new Uri($"my/ships/{shipSymbol}/refine", UriKind.Relative), null, new
            {
                produce = Enum.GetName(produce)
            });
        }

        /// <summary>
        /// Command a ship to chart the current waypoint.
        /// <br /><br />
        /// Waypoints in the universe are uncharted by default. These locations will not show up in the API until they have been charted by a ship.
        /// <br /><br />
        /// Charting a location will record your agent as the one who created the chart.
        /// </summary>
        /// <param name="shipSymbol"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<CreateChartResponse> CreateChart(string shipSymbol)
        {
            if (string.IsNullOrEmpty(shipSymbol))
                throw new ArgumentNullException(nameof(shipSymbol));

            return await API.Post<CreateChartResponse>(new Uri($"my/ships/{shipSymbol}/chart", UriKind.Relative));
        }

        /// <summary>
        /// Retrieve the details of your ship's reactor cooldown. Some actions such as activating your jump drive, scanning, or extracting resources taxes your reactor and results in a cooldown.
        /// <br /> <br />
        /// Your ship cannot perform additional actions until your cooldown has expired.The duration of your cooldown is relative to the power consumption of the related modules or mounts for the action taken.
        /// <br /><br />
        /// Response returns a 204 status code(no-content) when the ship has no cooldown.
        /// </summary>
        /// <param name="shipSymbol"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<Cooldown> GetShipCooldown(string shipSymbol)
        {
            if (string.IsNullOrEmpty(shipSymbol))
                throw new ArgumentNullException(nameof(shipSymbol));

            return await API.Get<Cooldown>(new Uri($"my/ships/{shipSymbol}/cooldown", UriKind.Relative));
        }

        /// <summary>
        /// Attempt to dock your ship at it's current location. Docking will only succeed if the waypoint is a dockable location, and your ship is capable of docking at the time of the request.
        /// <br /> <br />
        ///The endpoint is idempotent - successive calls will succeed even if the ship is already docked.
        /// </summary>
        /// <param name="shipSymbol"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<DockShipResponse> DockShip(string shipSymbol)
        {
            if (string.IsNullOrEmpty(shipSymbol))
                throw new ArgumentNullException(nameof(shipSymbol));

            return await API.Post<DockShipResponse>(new Uri($"my/ships/{shipSymbol}/dock", UriKind.Relative));
        }

        /// <summary>
        /// If you want to target specific yields for an extraction, you can survey a waypoint, such as an asteroid field, and send the survey in the body of the extract request. Each survey may have multiple deposits, and if a symbol shows up more than once, that indicates a higher chance of extracting that resource.
        /// <br /> <br />
        /// Your ship will enter a cooldown between consecutive survey requests.Surveys will eventually expire after a period of time. Multiple ships can use the same survey for extraction.
        /// </summary>
        /// <param name="shipSymbol"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<CreateSurveyResponse> CreateSurvey(string shipSymbol)
        {
            if (string.IsNullOrEmpty(shipSymbol))
                throw new ArgumentNullException(nameof(shipSymbol));

            return await API.Post<CreateSurveyResponse>(new Uri($"my/ships/{shipSymbol}/survey", UriKind.Relative));
        }

        /// <summary>
        /// Extract resources from the waypoint into your ship. Send an optional survey as the payload to target specific yields.
        /// </summary>
        /// <param name="shipSymbol"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<ExtractResourcesResponse> ExtractResources(string shipSymbol)
        {
            if (string.IsNullOrEmpty(shipSymbol))
                throw new ArgumentNullException(nameof(shipSymbol));

            return await API.Post<ExtractResourcesResponse>(new Uri($"my/ships/{shipSymbol}/extract", UriKind.Relative));
        }

        /// <summary>
        /// Jettison cargo from your ship's cargo hold.
        /// </summary>
        /// <param name="shipSymbol"></param>
        /// <param name="cargoItemSymbol"></param>
        /// <param name="units"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public async Task<JettisonCargoResponse> JettisonCargo(string shipSymbol, string cargoItemSymbol, int units)
        {
            if (string.IsNullOrEmpty(shipSymbol))
                throw new ArgumentNullException(nameof(shipSymbol));
            if (string.IsNullOrEmpty(cargoItemSymbol))
                throw new ArgumentNullException(nameof(cargoItemSymbol));
            if(units <= 0)
                throw new ArgumentOutOfRangeException(nameof(units));

            return await API.Post<JettisonCargoResponse>(new Uri($"my/ships/{shipSymbol}/jettison", UriKind.Relative), null, new
            {
                symbol = cargoItemSymbol,
                units = units
            });
        }

        /// <summary>
        /// Jump your ship instantly to a target system. Unlike other forms of navigation, jumping requires a unit of antimatter.
        /// </summary>
        /// <param name="shipSymbol"></param>
        /// <returns></returns>
        public async Task<ShipWarpOrJumpResponse> ShipJump(string shipSymbol, string targetSystemSymbol)
        {
            if (string.IsNullOrEmpty(shipSymbol))
                throw new ArgumentNullException(nameof(shipSymbol));
            if (string.IsNullOrEmpty(targetSystemSymbol))
                throw new ArgumentNullException(nameof(targetSystemSymbol));

            return await API.Post<ShipWarpOrJumpResponse>(new Uri($"my/ships/{shipSymbol}/jump", UriKind.Relative), null, new
            {
                systemSymbol = targetSystemSymbol
            });
        }

        /// <summary>
        /// Navigate to a target destination. The destination must be located within the same system as the ship. Navigating will consume the necessary fuel and supplies from the ship's manifest, and will pay out crew wages from the agent's account.
        /// <br /> <br />
        /// The returned response will detail the route information including the expected time of arrival.Most ship actions are unavailable until the ship has arrived at it's destination.
        /// <br /> <br />
        /// To travel between systems, see the ship's warp or jump actions.
        /// </summary>
        /// <param name="shipSymbol"></param>
        /// <param name="targetWaypointSymbol"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<ShipNavigateResponse> ShipNavigate(string shipSymbol, string targetWaypointSymbol)
        {
            if (string.IsNullOrEmpty(shipSymbol))
                throw new ArgumentNullException(nameof(shipSymbol));
            if (string.IsNullOrEmpty(targetWaypointSymbol))
                throw new ArgumentNullException(nameof(targetWaypointSymbol));

            return await API.Post<ShipNavigateResponse>(new Uri($"my/ships/{shipSymbol}/navigate", UriKind.Relative), null, new
            {
                waypointSymbol = targetWaypointSymbol
            });
        }

        /// <summary>
        /// Update the nav data of a ship, such as the flight mode.
        /// </summary>
        /// <param name="shipSymbol"></param>
        /// <param name="flightMode"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<ShipNav> PatchShipNav(string shipSymbol, ShipNavFlightMode flightMode)
        {
            if (string.IsNullOrEmpty(shipSymbol))
                throw new ArgumentNullException(nameof(shipSymbol));

            return await API.Patch<ShipNav>(new Uri($"my/ships/{shipSymbol}/nav", UriKind.Relative), null, new
            {
                flightMode = Enum.GetName(flightMode)
            });
        }

        /// <summary>
        /// Get the current nav status of a ship.
        /// </summary>
        /// <param name="shipSymbol"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<ShipNav> GetShipNav(string shipSymbol)
        {
            if (string.IsNullOrEmpty(shipSymbol))
                throw new ArgumentNullException(nameof(shipSymbol));

            return await API.Get<ShipNav>(new Uri($"my/ships/{shipSymbol}/nav", UriKind.Relative));
        }

        /// <summary>
        /// Warp your ship to a target destination in another system. Warping will consume the necessary fuel and supplies from the ship's manifest, and will pay out crew wages from the agent's account.
        ///  <br /> <br />
        /// The returned response will detail the route information including the expected time of arrival.Most ship actions are unavailable until the ship has arrived at it's destination.
        /// </summary>
        /// <param name="shipSymbol"></param>
        /// <param name="targetWaypointSymbol"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<ShipWarpOrJumpResponse> WarpShip(string shipSymbol, string targetWaypointSymbol)
        {
            if (string.IsNullOrEmpty(shipSymbol))
                throw new ArgumentNullException(nameof(shipSymbol));
            if (string.IsNullOrEmpty(targetWaypointSymbol))
                throw new ArgumentNullException(nameof(targetWaypointSymbol));

            return await API.Post<ShipWarpOrJumpResponse>(new Uri($"my/ships/{shipSymbol}/warp", UriKind.Relative), null , new
            {
                waypointSymbol = targetWaypointSymbol
            });
        }

        /// <summary>
        /// Sell cargo.
        /// </summary>
        /// <param name="shipSymbol"></param>
        /// <param name="cargoItemSymbol"></param>
        /// <param name="units"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public async Task<SellCargoResponse> SellCargo(string shipSymbol, string cargoItemSymbol, int units)
        {
            if (string.IsNullOrEmpty(shipSymbol))
                throw new ArgumentNullException(nameof(shipSymbol));
            if (string.IsNullOrEmpty(cargoItemSymbol))
                throw new ArgumentNullException(nameof(cargoItemSymbol));
            if (units <= 0)
                throw new ArgumentOutOfRangeException(nameof(units));

            return await API.Post<SellCargoResponse>(new Uri($"my/ships/{shipSymbol}/sell", UriKind.Relative), null, new
            {
                symbol = cargoItemSymbol,
                units = units
            });
        }

        /// <summary>
        /// Activate your ship's sensor arrays to scan for system information.
        /// </summary>
        /// <param name="shipSymbol"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<ScanResponse> ScanSystems(string shipSymbol)
        {
            if (string.IsNullOrEmpty(shipSymbol))
                throw new ArgumentNullException(nameof(shipSymbol));

            return await API.Post<ScanResponse>(new Uri($"my/ships/{shipSymbol}/scan/systems", UriKind.Relative));
        }

        /// <summary>
        /// Activate your ship's sensor arrays to scan for waypoint information.
        /// </summary>
        /// <param name="shipSymbol"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<ScanResponse> ScanWaypoints(string shipSymbol)
        {
            if (string.IsNullOrEmpty(shipSymbol))
                throw new ArgumentNullException(nameof(shipSymbol));

            return await API.Post<ScanResponse>(new Uri($"my/ships/{shipSymbol}/scan/waypoints", UriKind.Relative));
        }

        /// <summary>
        /// Activate your ship's sensor arrays to scan for ship information.
        /// </summary>
        /// <param name="shipSymbol"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<ScanResponse> ScanShips(string shipSymbol)
        {
            if (string.IsNullOrEmpty(shipSymbol))
                throw new ArgumentNullException(nameof(shipSymbol));

            return await API.Post<ScanResponse>(new Uri($"my/ships/{shipSymbol}/scan/ships", UriKind.Relative));
        }

        /// <summary>
        /// Refuel your ship from the local market.
        /// </summary>
        /// <param name="shipSymbol"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<RefuelShipResponse> RefuelShip(string shipSymbol)
        {
            if (string.IsNullOrEmpty(shipSymbol))
                throw new ArgumentNullException(nameof(shipSymbol));

            return await API.Post<RefuelShipResponse>(new Uri($"my/ships/{shipSymbol}/refuel", UriKind.Relative));
        }

        /// <summary>
        /// Purchase cargo.
        /// </summary>
        /// <param name="shipSymbol"></param>
        /// <param name="cargoItemSymbol"></param>
        /// <param name="units"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public async Task<PurchaseCargoResponse> PurchaseCargo(string shipSymbol, string cargoItemSymbol, int units)
        {
            if (string.IsNullOrEmpty(shipSymbol))
                throw new ArgumentNullException(nameof(shipSymbol));
            if (string.IsNullOrEmpty(cargoItemSymbol))
                throw new ArgumentNullException(nameof(cargoItemSymbol));
            if (units <= 0)
                throw new ArgumentOutOfRangeException(nameof(units));

            return await API.Post<PurchaseCargoResponse>(new Uri($"my/ships/{shipSymbol}/purchase", UriKind.Relative), null, new
            {
                symbol = cargoItemSymbol,
                units = units
            });
        }

        /// <summary>
        /// Transfer cargo between ships.
        /// </summary>
        /// <param name="shipSymbol"></param>
        /// <param name="targetShipSymbol"></param>
        /// <param name="cargoItemSymbol"></param>
        /// <param name="units"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public async Task<ShipCargo> TransferCargo(string shipSymbol, string targetShipSymbol, string cargoItemSymbol, int units)
        {
            if (string.IsNullOrEmpty(shipSymbol))
                throw new ArgumentNullException(nameof(shipSymbol));
            if (string.IsNullOrEmpty(cargoItemSymbol))
                throw new ArgumentNullException(nameof(cargoItemSymbol));
            if (string.IsNullOrEmpty(targetShipSymbol))
                throw new ArgumentNullException(nameof(targetShipSymbol));
            if (units <= 0)
                throw new ArgumentOutOfRangeException(nameof(units));

            return await API.Post<ShipCargo>(new Uri($"my/ships/{shipSymbol}/transfer", UriKind.Relative), null, new
            {
                symbol = cargoItemSymbol,
                units = units,
                shipSymbol = targetShipSymbol
            });
        }
    }
}

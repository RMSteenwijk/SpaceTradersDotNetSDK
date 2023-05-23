using SpaceTradersDotNetSDK.Models;
using SpaceTradersDotNetSDK.Models.Enums;
using SpaceTradersDotNetSDK.ResponseModels.Fleet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradersDotNetSDK.Clients.Interfaces
{
    public interface IFleetClient
    {
        Task<List<Ship>> ListMyShips(int limit = 20, int page = 1);
        Task<Ship> GetShip(string shipSymbol);
        Task<ShipCargo> GetShipCargo(string shipSymbol);
        Task<PurchaseShipResponse> PurchaseShip(string shipType, string waypointSymbol);
        Task<OrbitResponse> OrbitShip(string shipSymbol);
        Task<ShipRefineResponse> Refine(string shipSymbol, Produce produce);
        Task<CreateChartResponse> CreateChart(string shipSymbol);
        Task<Cooldown> GetShipCooldown(string shipSymbol);
        Task<DockShipResponse> DockShip(string shipSymbol);
        Task<CreateSurveyResponse> CreateSurvey(string shipSymbol);
        Task<ExtractResourcesResponse> ExtractResources(string shipSymbol, Survey survey = null);
        Task<JettisonCargoResponse> JettisonCargo(string shipSymbol, string cargoItemSymbol, int units);
        Task<ShipWarpOrJumpResponse> ShipJump(string shipSymbol, string targetSystemSymbol);
        Task<ShipNavigateResponse> ShipNavigate(string shipSymbol, string targetWaypointSymbol);
        Task<ShipNav> PatchShipNav(string shipSymbol, ShipNavFlightMode flightMode);
        Task<ShipNav> GetShipNav(string shipSymbol);
        Task<ShipWarpOrJumpResponse> WarpShip(string shipSymbol, string targetWaypointSymbol);
        Task<SellCargoResponse> SellCargo(string shipSymbol, string cargoItemSymbol, int units);
        Task<ScanResponse> ScanSystems(string shipSymbol);
        Task<ScanResponse> ScanWaypoints(string shipSymbol);
        Task<ScanResponse> ScanShips(string shipSymbol);
        Task<RefuelShipResponse> RefuelShip(string shipSymbol);
        Task<PurchaseCargoResponse> PurchaseCargo(string shipSymbol, string cargoItemSymbol, int units);
        Task<ShipCargo> TransferCargo(string shipSymbol, string targetShipSymbol, string cargoItemSymbol, int units);

    }
}

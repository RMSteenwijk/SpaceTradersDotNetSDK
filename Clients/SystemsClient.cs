using SpaceTradersDotNetSDK.Clients.Interfaces;
using SpaceTradersDotNetSDK.Http;
using SpaceTradersDotNetSDK.Models;

namespace SpaceTradersDotNetSDK.Clients
{
    public class SystemsClient : APIClient, ISystemsClient
    {
        public SystemsClient(IAPIConnector apiConnector, Uri baseAdress) : base(apiConnector, baseAdress)
        { }

        /// <summary>
        /// Return a list of all systems.
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<List<Models.System>> GetAllSystems(int limit = 20, int page = 1)
        {
            if (limit < 1 || limit > 20)
                throw new ApplicationException($"Can't set limit lower then 0 or higher then 20");
            if (page < 1)
                throw new ApplicationException($"Can't set page lower then 0");

            return await API.Get<List<Models.System>>(new Uri("systems", UriKind.Relative), new Dictionary<string, string>
            {
                { "limit", limit.ToString() },
                { "page", page.ToString() }
            });
        }

        /// <summary>
        /// Get the details of a system.
        /// </summary>
        /// <param name="contractId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<Models.System> GetSystem(string systemSymbol)
        {
            if (string.IsNullOrEmpty(systemSymbol))
                throw new ArgumentNullException(nameof(systemSymbol));

            return await API.Get<Models.System>(new Uri($"systems/{systemSymbol}", UriKind.Relative));
        }

        /// <summary>
        /// Fetch all of the waypoints for a given system. System must be charted or a ship must be present to return waypoint details.
        /// </summary>
        /// <param name="systemSymbol"></param>
        /// <param name="limit"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ApplicationException"></exception>
        public async Task<List<Waypoint>> ListWaypoints(string systemSymbol, int limit = 20, int page = 1)
        {
            if (string.IsNullOrEmpty(systemSymbol))
                throw new ArgumentNullException(nameof(systemSymbol));
            if (limit < 1 || limit > 20)
                throw new ApplicationException($"Can't set limit lower then 0 or higher then 20");
            if (page < 1)
                throw new ApplicationException($"Can't set page lower then 0");

            return await API.Get<List<Waypoint>>(new Uri($"systems/{systemSymbol}/waypoints", UriKind.Relative), new Dictionary<string, string>
            {
                { "limit", limit.ToString() },
                { "page", page.ToString() }
            });
        }

        /// <summary>
        /// View the details of a waypoint.
        /// </summary>
        /// <param name="systemSymbol"></param>
        /// <param name="waypointSymbol"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<Waypoint> GetWaypoint(string systemSymbol, string waypointSymbol)
        {
            if (string.IsNullOrEmpty(systemSymbol))
                throw new ArgumentNullException(nameof(systemSymbol));
            if (string.IsNullOrEmpty(waypointSymbol))
                throw new ArgumentNullException(nameof(waypointSymbol));

            return await API.Get<Waypoint>(new Uri($"systems/{systemSymbol}/waypoints/{waypointSymbol}", UriKind.Relative));
        }

        /// <summary>
        /// Retrieve imports, exports and exchange data from a marketplace. Imports can be sold, exports can be purchased, and exchange goods can be purchased or sold. Send a ship to the waypoint to access trade good prices and recent transactions.
        /// </summary>
        /// <param name="systemSymbol"></param>
        /// <param name="waypointSymbol"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<Market> GetMarket(string systemSymbol, string waypointSymbol)
        {
            if (string.IsNullOrEmpty(systemSymbol))
                throw new ArgumentNullException(nameof(systemSymbol));
            if (string.IsNullOrEmpty(waypointSymbol))
                throw new ArgumentNullException(nameof(waypointSymbol));

            return await API.Get<Market>(new Uri($"systems/{systemSymbol}/waypoints/{waypointSymbol}/market", UriKind.Relative));
        }

        /// <summary>
        /// Get the shipyard for a waypoint. Send a ship to the waypoint to access ships that are currently available for purchase and recent transactions.
        /// </summary>
        /// <param name="systemSymbol"></param>
        /// <param name="waypointSymbol"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<Shipyard> GetShipyard(string systemSymbol, string waypointSymbol)
        {
            if (string.IsNullOrEmpty(systemSymbol))
                throw new ArgumentNullException(nameof(systemSymbol));
            if (string.IsNullOrEmpty(waypointSymbol))
                throw new ArgumentNullException(nameof(waypointSymbol));

            return await API.Get<Shipyard>(new Uri($"systems/{systemSymbol}/waypoints/{waypointSymbol}/shipyard", UriKind.Relative));
        }

        /// <summary>
        /// Get jump gate details for a waypoint.
        /// </summary>
        /// <param name="systemSymbol"></param>
        /// <param name="waypointSymbol"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<JumpGate> GetJumpGate(string systemSymbol, string waypointSymbol)
        {
            if (string.IsNullOrEmpty(systemSymbol))
                throw new ArgumentNullException(nameof(systemSymbol));
            if (string.IsNullOrEmpty(waypointSymbol))
                throw new ArgumentNullException(nameof(waypointSymbol));

            return await API.Get<JumpGate>(new Uri($"systems/{systemSymbol}/waypoints/{waypointSymbol}/jump-gate", UriKind.Relative));
        }
    }
}

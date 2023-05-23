using SpaceTradersDotNetSDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradersDotNetSDK.Clients.Interfaces
{
    public interface ISystemsClient
    {
        Task<List<Models.System>> GetAllSystems(int limit = 20, int page = 1);
        Task<Models.System> GetSystem(string systemSymbol);
        Task<List<Waypoint>> ListWaypoints(string systemSymbol, int limit = 20, int page = 1);
        Task<Waypoint> GetWaypoint(string systemSymbol, string waypointSymbol);
        Task<Market> GetMarket(string systemSymbol, string waypointSymbol);
        Task<Shipyard> GetShipyard(string systemSymbol, string waypointSymbol);
        Task<JumpGate> GetJumpGate(string systemSymbol, string waypointSymbol);

    }
}

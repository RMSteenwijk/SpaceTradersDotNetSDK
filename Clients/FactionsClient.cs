using SpaceTradersDotNetSDK.Http;
using SpaceTradersDotNetSDK.Models;
using SpaceTradersDotNetSDK.Models.Enums;

namespace SpaceTradersDotNetSDK.Clients
{
    public class FactionsClient : APIClient
    {
        public FactionsClient(IAPIConnector apiConnector, Uri baseAdress) : base(apiConnector, baseAdress)
        { }

        public async Task<List<Faction>> ListFactionsAsync(int limit = 20, int page = 1)
        {
            if (limit < 1 || limit > 20)
                throw new ApplicationException($"Can't set limit lower then 0 or higher then 20");
            if(page < 1)
                throw new ApplicationException($"Can't set page lower then 0");

            return await API.Get<List<Faction>>(new Uri("factions", UriKind.Relative), new Dictionary<string, string>
            {
                { "limit", limit.ToString() },
                { "page", page.ToString() }
            });
        }

        public async Task<Faction> GetFactionAsync(string factionSymbol)
        {
            return await API.Get<Faction>(new Uri($"factions/{factionSymbol}", UriKind.Relative));
        }
    }
}

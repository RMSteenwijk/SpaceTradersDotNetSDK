using SpaceTradersDotNetSDK.Clients.Interfaces;
using SpaceTradersDotNetSDK.Http;
using SpaceTradersDotNetSDK.Models;

namespace SpaceTradersDotNetSDK.Clients
{
    public class AgentsClient : APIClient, IAgentsClient
    {
        public AgentsClient(IAPIConnector apiConnector, Uri baseAdress) : base(apiConnector, baseAdress)
        { }

        public async Task<Agent> GetMyAgentAsync()
        {
            return await API.Get<Agent>(new Uri("my/agent", UriKind.Relative));
        }
    }
}

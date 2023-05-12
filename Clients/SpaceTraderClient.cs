using SpaceTradersDotNetSDK.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradersDotNetSDK.Clients
{
    public class SpaceTraderClient
    {
        private IAPIConnector _connector;
        private SpaceTraderClientConfig _config;
        private bool _useWaitForCooldownHandler;
        public RegisterClient Register { get; set; }
        public AgentsClient Agents { get; set; }
        public FactionsClient Factions { get; set; }
        public FleetClient Fleet { get; set; }
        public ContractsClient Contracts { get; set; }
        public SystemsClient Systems { get; set; }

        public SpaceTraderClient(IHttpClientFactory httpClientFactory, string access_token = "", bool useWaitForCooldownHandler = false)
            : this(httpClientFactory.CreateClient(), access_token, useWaitForCooldownHandler) { }

        /// <summary>
        /// Create Client
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="access_token"></param>
        public SpaceTraderClient(HttpClient httpClient, string access_token = "", bool useWaitForCooldownHandler = false)
        {
            _useWaitForCooldownHandler = useWaitForCooldownHandler;
            _config = SpaceTraderClientConfig.CreateDefault(new NetHttpClient(httpClient));
            if (!string.IsNullOrEmpty(access_token))
                _config = _config.WithToken(access_token);
            _connector = _config.BuildAPIConnector(useWaitForCooldownHandler);

            Register = new RegisterClient(_connector, _config.BaseAddress);

            SetClientsBasedOnConnector();
        }

        /// <summary>
        /// Recreate API layer to include access_token authenticator
        /// </summary>
        /// <param name="token"></param>
        public void UpdateToken(string token)
        {
            _config = _config.WithToken(token);
            _connector = _config.BuildAPIConnector(_useWaitForCooldownHandler);

            SetClientsBasedOnConnector();
        }

        public void SetClientsBasedOnConnector()
        {
            Agents = new AgentsClient(_connector, _config.BaseAddress);
            Factions = new FactionsClient(_connector, _config.BaseAddress);
            Fleet = new FleetClient(_connector, _config.BaseAddress);
            Contracts =  new ContractsClient(_connector, _config.BaseAddress);
            Systems = new SystemsClient(_connector, _config.BaseAddress);
        }
    }
}

﻿using SpaceTradersDotNetSDK.Clients.Interfaces;
using SpaceTradersDotNetSDK.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradersDotNetSDK.Clients
{
    public class SpaceTraderClient : ISpaceTraderClient
    {
        private IAPIConnector _connector;
        private SpaceTraderClientConfig _config;
        public IRegisterClient Register { get; set; }
        public IAgentsClient Agents { get; set; }
        public IFactionsClient Factions { get; set; }
        public IFleetClient Fleet { get; set; }
        public IContractsClient Contracts { get; set; }
        public ISystemsClient Systems { get; set; }

        public SpaceTraderClient(IHttpClientFactory httpClientFactory, string access_token = "")
            : this(httpClientFactory.CreateClient(), access_token) { }

        /// <summary>
        /// Create Client
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="access_token"></param>
        public SpaceTraderClient(HttpClient httpClient, string access_token = "")
        {
            _config = SpaceTraderClientConfig.CreateDefault(new NetHttpClient(httpClient));
            if (!string.IsNullOrEmpty(access_token))
                _config = _config.WithToken(access_token);
            _connector = _config.BuildAPIConnector();

            Register = new RegisterClient(_connector, _config.BaseAddress);

            _setClientsBasedOnConnector();
        }

        /// <summary>
        /// Recreate API layer to include access_token authenticator
        /// </summary>
        /// <param name="token"></param>
        public void UpdateToken(string token)
        {
            _config = _config.WithToken(token);
            _connector = _config.BuildAPIConnector();

            _setClientsBasedOnConnector();
        }

        private void _setClientsBasedOnConnector()
        {
            Agents = new AgentsClient(_connector, _config.BaseAddress);
            Factions = new FactionsClient(_connector, _config.BaseAddress);
            Fleet = new FleetClient(_connector, _config.BaseAddress);
            Contracts =  new ContractsClient(_connector, _config.BaseAddress);
            Systems = new SystemsClient(_connector, _config.BaseAddress);
        }
    }
}

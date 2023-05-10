using SpaceTradersDotNetSDK.Http;
using SpaceTradersDotNetSDK.Models;
using SpaceTradersDotNetSDK.ResponseModels.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradersDotNetSDK.Clients
{
    public class ContractsClient : APIClient
    {
        public ContractsClient(IAPIConnector apiConnector, Uri baseAdress) : base(apiConnector, baseAdress)
        { }

        /// <summary>
        /// List all of your contracts.
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<List<Contract>> GetMyContracts(int limit, int page)
        {
            if (limit < 0 || limit > 20)
                throw new ApplicationException($"Can't set limit lower then 0 or higher then 20");
            if (page < 0)
                throw new ApplicationException($"Can't set page lower then 0");

            return await API.Get<List<Contract>>(new Uri("my/contracts", UriKind.Relative), new Dictionary<string, string>
            {
                { "limit", limit.ToString() },
                { "page", page.ToString() }
            });
        }

        /// <summary>
        /// Get the details of a contract by ID.
        /// </summary>
        /// <param name="contractId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<Contract> GetContract(string contractId)
        {
            if (string.IsNullOrEmpty(contractId))
                throw new ArgumentNullException(nameof(contractId));

            return await API.Get<Contract>(new Uri($"my/contracts/{contractId}", UriKind.Relative));
        }

        /// <summary>
        /// Accept a contract.
        /// </summary>
        /// <param name="contractId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<AcceptContractResponse> AcceptContract(string contractId)
        {
            if (string.IsNullOrEmpty(contractId))
                throw new ArgumentNullException(nameof(contractId));

            return await API.Post<AcceptContractResponse>(new Uri($"my/contracts/{contractId}/accept", UriKind.Relative));
        }

        /// <summary>
        /// Deliver cargo on a given contract.
        /// </summary>
        /// <param name="contractId"></param>
        /// <param name="shipSymbol"></param>
        /// <param name="cargoItemSymbol"></param>
        /// <param name="units"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public async Task<DeliverContractResponse> DeliverContract(string contractId, string shipSymbol, string cargoItemSymbol, int units)
        {
            if (string.IsNullOrEmpty(contractId))
                throw new ArgumentNullException(nameof(contractId));
            if (string.IsNullOrEmpty(shipSymbol))
                throw new ArgumentNullException(nameof(shipSymbol));
            if (string.IsNullOrEmpty(cargoItemSymbol))
                throw new ArgumentNullException(nameof(cargoItemSymbol));
            if (units <= 0)
                throw new ArgumentOutOfRangeException(nameof(units));

            return await API.Post<DeliverContractResponse>(new Uri($"my/contracts/{contractId}/deliver", UriKind.Relative), null, new 
            {
                shipSymbol = shipSymbol,
                tradeSymbol = cargoItemSymbol, 
                units = units
            });
        }

        /// <summary>
        /// Fulfill a contract
        /// </summary>
        /// <param name="contractId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<DeliverContractResponse> FulfillContract(string contractId)
        {
            if (string.IsNullOrEmpty(contractId))
                throw new ArgumentNullException(nameof(contractId));

            return await API.Post<DeliverContractResponse>(new Uri($"my/contracts/{contractId}/fulfill", UriKind.Relative));
        }


    }
}

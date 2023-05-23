using SpaceTradersDotNetSDK.Models;
using SpaceTradersDotNetSDK.ResponseModels.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradersDotNetSDK.Clients.Interfaces
{
    public interface IContractsClient
    {
        Task<List<Contract>> GetMyContracts(int limit = 20, int page = 1);
        Task<Contract> GetContract(string contractId);
        Task<AcceptContractResponse> AcceptContract(string contractId);
        Task<DeliverContractResponse> DeliverContract(string contractId, string shipSymbol, string cargoItemSymbol, int units);
        Task<DeliverContractResponse> FulfillContract(string contractId);
    }
}

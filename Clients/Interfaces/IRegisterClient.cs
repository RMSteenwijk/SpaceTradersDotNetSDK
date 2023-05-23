using SpaceTradersDotNetSDK.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradersDotNetSDK.Clients.Interfaces
{
    public interface IRegisterClient
    {
        Task<RegisterResponse> Register(string factionSymbol, string callSign, string email = "");
    }
}

using SpaceTradersDotNetSDK.Clients.Interfaces;
using SpaceTradersDotNetSDK.Http;
using SpaceTradersDotNetSDK.Models.Enums;
using SpaceTradersDotNetSDK.ResponseModels;

namespace SpaceTradersDotNetSDK.Clients
{
    public class RegisterClient : APIClient, IRegisterClient
    {
        public RegisterClient(IAPIConnector connector, Uri baseAdress) : base(connector, baseAdress) { }

        public Task<RegisterResponse> Register(string factionSymbol, string callSign, string email = "")
        {
            if (callSign.Length < 3)
                throw new ArgumentException($"Length of {nameof(callSign)} is short");
            if (callSign.Length > 14)
                throw new ArgumentException($"Length of {nameof(callSign)} is long");

            return API.Post<RegisterResponse>(new Uri("register", UriKind.Relative), null, 
            new 
            { 
                symbol = callSign, 
                faction = factionSymbol,
                email = email   
            });
        }
    }

}

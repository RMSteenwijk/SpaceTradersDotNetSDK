using SpaceTradersDotNetSDK.Clients;
using SpaceTradersDotNetSDK.Http.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradersDotNetSDK.Http
{
    public class AuthorizationCodeAuthenticator : IAuthenticator
    {
        private bool _hasExistingToken;
        private string _accessToken;

        public AuthorizationCodeAuthenticator(string accessToken) 
        { 
            _hasExistingToken = !string.IsNullOrEmpty(accessToken);
            _accessToken = accessToken;
        }

        public void Apply(IRequest request, IAPIConnector apiConnector)
        {
            Ensure.ArgumentNotNull(request, nameof(request));

            if(!_hasExistingToken && request.RequiresAccessToken)
            {
                throw new ArgumentNullException("Can't send request without token");
            }

            request.Headers["Authorization"] = $"Bearer {_accessToken}";
        }
    }
}

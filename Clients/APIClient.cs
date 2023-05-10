using SpaceTradersDotNetSDK.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradersDotNetSDK.Clients
{
    public abstract class APIClient
    {
        protected APIClient(IAPIConnector apiConnector, Uri baseAdress)
        {
            Ensure.ArgumentNotNull(apiConnector, nameof(apiConnector));
            Ensure.ArgumentNotNull(baseAdress, nameof(baseAdress));

            API = apiConnector;
            BaseAdress = baseAdress;
        }

        protected IAPIConnector API { get; set; }

        protected Uri BaseAdress { get; set;  }
    }
}

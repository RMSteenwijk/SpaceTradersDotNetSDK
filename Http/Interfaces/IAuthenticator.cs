using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradersDotNetSDK.Http.Interfaces
{
    public interface IAuthenticator
    {
        void Apply(IRequest request, IAPIConnector apiConnector);
    }
}

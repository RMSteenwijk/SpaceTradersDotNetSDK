using SpaceTradersDotNetSDK.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradersDotNetSDK
{
    public delegate Exception ExceptionFactory(string methodName, IResponse response);

    public class Default
    {
        public static readonly ExceptionFactory DefaultExceptionFactory = (methodName, response) =>
        {
            var status = (int)response.StatusCode; 
            if (status == 0)
            {
                return new ApplicationException(string.Format("Error calling {0}", methodName));
            }
            return new APIException(response);
        };
    }
}

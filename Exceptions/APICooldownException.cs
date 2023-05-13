using Newtonsoft.Json;
using SpaceTradersDotNetSDK.Http;
using SpaceTradersDotNetSDK.ResponseModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradersDotNetSDK
{
    public class APICooldownException : APIException
    {
        public TimeSpan RetryAfter { get; }

        public APICooldownException(IResponse response) : base(response)
        {
            Ensure.ArgumentNotNull(response, nameof(response));

            var errorResponse = JsonConvert.DeserializeObject<CooldownErrorResponse>(response?.Body as string ?? "");
            if(errorResponse != null)
            {
                RetryAfter = TimeSpan.FromSeconds(2);
            }
        }

        public APICooldownException() { }

        public APICooldownException(string message) : base(message) { }

        public APICooldownException(string message, Exception innerException) : base(message, innerException) { }

        protected APICooldownException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}

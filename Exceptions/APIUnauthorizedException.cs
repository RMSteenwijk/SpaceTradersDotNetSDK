using SpaceTradersDotNetSDK.Http;
using System.Runtime.Serialization;

namespace SpaceTradersDotNetSDK
{
    [Serializable]
  public class APIUnauthorizedException : APIException
  {
    public APIUnauthorizedException(IResponse response) : base(response) { }

    public APIUnauthorizedException() { }

    public APIUnauthorizedException(string message) : base(message) { }

    public APIUnauthorizedException(string message, Exception innerException) : base(message, innerException) { }

    protected APIUnauthorizedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
  }
}

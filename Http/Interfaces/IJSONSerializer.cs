using System.Threading.Tasks;

namespace SpaceTradersDotNetSDK.Http
{
  public interface IJSONSerializer
  {
    void SerializeRequest(IRequest request);
    IAPIResponse<T> DeserializeResponse<T>(IResponse response);
  }
}

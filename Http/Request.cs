using System;
using System.Collections.Generic;
using System.Net.Http;

namespace SpaceTradersDotNetSDK.Http
{
  public class Request : IRequest
  {
    public Request(Uri baseAddress, Uri endpoint, HttpMethod method, bool requiresAccessToken)
    {
      Headers = new Dictionary<string, string>();
      Parameters = new Dictionary<string, string>();
      BaseAddress = baseAddress;
      Endpoint = endpoint;
      Method = method;
      RequiresAccessToken = requiresAccessToken;
    }

    public Request(Uri baseAddress, Uri endpoint, HttpMethod method, IDictionary<string, string> headers, bool requiresAccessToken)
    {
      Headers = headers;
      Parameters = new Dictionary<string, string>();
      BaseAddress = baseAddress;
      Endpoint = endpoint;
      Method = method;
      RequiresAccessToken = requiresAccessToken;
    }

    public Request(
      Uri baseAddress,
      Uri endpoint,
      HttpMethod method,
      IDictionary<string, string> headers,
      IDictionary<string, string> parameters,
      bool requiresAccessToken)
    {
      Headers = headers;
      Parameters = parameters;
      BaseAddress = baseAddress;
      Endpoint = endpoint;
      Method = method;
      RequiresAccessToken = requiresAccessToken;
    }

    public bool RequiresAccessToken { get; }

    public Uri BaseAddress { get; set; }

    public Uri Endpoint { get; set; }

    public IDictionary<string, string> Headers { get; }

    public IDictionary<string, string> Parameters { get; }

    public HttpMethod Method { get; set; }

    public object? Body { get; set; }
  }
}

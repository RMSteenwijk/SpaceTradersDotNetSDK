using SpaceTradersDotNetSDK.Http.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SpaceTradersDotNetSDK.Http
{
  public class APIConnector : IAPIConnector
  {
    private readonly Uri _baseAddress;
    private readonly IAuthenticator? _authenticator;
    private readonly IJSONSerializer _jsonSerializer;
    private readonly IHTTPClient _httpClient;
    private readonly IRetryHandler? _retryHandler;
    private readonly IHTTPLogger? _httpLogger;
    private static bool _useWaitForCooldown;

    public event EventHandler<IResponse>? ResponseReceived;

    public APIConnector(Uri baseAddress, IAuthenticator authenticator) :
      this(baseAddress, authenticator, new NewtonsoftJSONSerializer(), new NetHttpClient(), null, null, true)
    { }
    public APIConnector(
      Uri baseAddress,
      IAuthenticator? authenticator,
      IJSONSerializer jsonSerializer,
      IHTTPClient httpClient,
      IRetryHandler? retryHandler,
      IHTTPLogger? httpLogger,
      bool useWaitForCooldown)
    {
      _baseAddress = baseAddress;
      _authenticator = authenticator;
      _jsonSerializer = jsonSerializer;
      _httpClient = httpClient;
      _retryHandler = retryHandler;
      _httpLogger = httpLogger;
      _useWaitForCooldown = useWaitForCooldown; 
    }

    public Task<T> Delete<T>(Uri uri, CancellationToken cancel)
    {
      Ensure.ArgumentNotNull(uri, nameof(uri));

      return SendAPIRequest<T>(uri, HttpMethod.Delete, cancel: cancel);
    }

    public Task<T> Delete<T>(Uri uri, IDictionary<string, string>? parameters, CancellationToken cancel)
    {
      Ensure.ArgumentNotNull(uri, nameof(uri));

      return SendAPIRequest<T>(uri, HttpMethod.Delete, parameters, cancel: cancel);
    }

    public Task<T> Delete<T>(Uri uri, IDictionary<string, string>? parameters, object? body, CancellationToken cancel)
    {
      Ensure.ArgumentNotNull(uri, nameof(uri));

      return SendAPIRequest<T>(uri, HttpMethod.Delete, parameters, body, cancel: cancel);
    }

    public async Task<HttpStatusCode> Delete(Uri uri, IDictionary<string, string>? parameters, object? body, CancellationToken cancel)
    {
      Ensure.ArgumentNotNull(uri, nameof(uri));

      var response = await SendAPIRequestDetailed(uri, HttpMethod.Delete, parameters, body, cancel: cancel).ConfigureAwait(false);
      return response.StatusCode;
    }

    public Task<T> Get<T>(Uri uri, CancellationToken cancel)
    {
      Ensure.ArgumentNotNull(uri, nameof(uri));

      return SendAPIRequest<T>(uri, HttpMethod.Get, cancel: cancel);
    }

    public Task<T> Get<T>(Uri uri, IDictionary<string, string>? parameters, CancellationToken cancel)
    {
      Ensure.ArgumentNotNull(uri, nameof(uri));

      return SendAPIRequest<T>(uri, HttpMethod.Get, parameters, cancel: cancel);
    }

    public async Task<HttpStatusCode> Get(Uri uri, IDictionary<string, string>? parameters, object? body, CancellationToken cancel)
    {
      Ensure.ArgumentNotNull(uri, nameof(uri));

      var response = await SendAPIRequestDetailed(uri, HttpMethod.Get, parameters, body, cancel: cancel).ConfigureAwait(false);
      return response.StatusCode;
    }

    public Task<T> Post<T>(Uri uri, CancellationToken cancel)
    {
      Ensure.ArgumentNotNull(uri, nameof(uri));

      return SendAPIRequest<T>(uri, HttpMethod.Post, cancel: cancel);
    }

    public Task<T> Post<T>(Uri uri, IDictionary<string, string>? parameters, CancellationToken cancel)
    {
      Ensure.ArgumentNotNull(uri, nameof(uri));

      return SendAPIRequest<T>(uri, HttpMethod.Post, parameters, cancel: cancel);
    }

    public Task<T> Post<T>(Uri uri, IDictionary<string, string>? parameters, object? body, CancellationToken cancel)
    {
      Ensure.ArgumentNotNull(uri, nameof(uri));

      return SendAPIRequest<T>(uri, HttpMethod.Post, parameters, body, cancel: cancel);
    }

    public Task<T> Post<T>(Uri uri, IDictionary<string, string>? parameters, object? body, Dictionary<string, string>? headers, CancellationToken cancel)
    {
      Ensure.ArgumentNotNull(uri, nameof(uri));

      return SendAPIRequest<T>(uri, HttpMethod.Post, parameters, body, headers, cancel: cancel);
    }

    public async Task<HttpStatusCode> Post(Uri uri, IDictionary<string, string>? parameters, object? body, CancellationToken cancel)
    {
      Ensure.ArgumentNotNull(uri, nameof(uri));

      var response = await SendAPIRequestDetailed(uri, HttpMethod.Post, parameters, body, cancel: cancel).ConfigureAwait(false);
      return response.StatusCode;
    }

    public Task<T> Patch<T>(Uri uri, CancellationToken cancel)
    {
      Ensure.ArgumentNotNull(uri, nameof(uri));

      return SendAPIRequest<T>(uri, HttpMethod.Patch, cancel: cancel);
    }

    public Task<T> Patch<T>(Uri uri, IDictionary<string, string>? parameters, CancellationToken cancel)
    {
      Ensure.ArgumentNotNull(uri, nameof(uri));

      return SendAPIRequest<T>(uri, HttpMethod.Patch, parameters, cancel: cancel);
    }

    public Task<T> Patch<T>(Uri uri, IDictionary<string, string>? parameters, object? body, CancellationToken cancel)
    {
      Ensure.ArgumentNotNull(uri, nameof(uri));

      return SendAPIRequest<T>(uri, HttpMethod.Patch, parameters, body, cancel: cancel);
    }

    public Task<T> Patch<T>(Uri uri, IDictionary<string, string>? parameters, object? body, Dictionary<string, string>? headers, CancellationToken cancel)
    {
      Ensure.ArgumentNotNull(uri, nameof(uri));

      return SendAPIRequest<T>(uri, HttpMethod.Patch, parameters, body, headers, cancel: cancel);
    }

    public async Task<HttpStatusCode> Patch(Uri uri, IDictionary<string, string>? parameters, object? body, CancellationToken cancel)
    {
      Ensure.ArgumentNotNull(uri, nameof(uri));

      var response = await SendAPIRequestDetailed(uri, HttpMethod.Patch, parameters, body, cancel: cancel).ConfigureAwait(false);
      return response.StatusCode;
    }

    public Task<T> Put<T>(Uri uri, CancellationToken cancel)
    {
      Ensure.ArgumentNotNull(uri, nameof(uri));

      return SendAPIRequest<T>(uri, HttpMethod.Put, cancel: cancel);
    }

    public Task<T> Put<T>(Uri uri, IDictionary<string, string>? parameters, CancellationToken cancel)
    {
      Ensure.ArgumentNotNull(uri, nameof(uri));

      return SendAPIRequest<T>(uri, HttpMethod.Put, parameters, cancel: cancel);
    }

    public Task<T> Put<T>(Uri uri, IDictionary<string, string>? parameters, object? body, CancellationToken cancel)
    {
      Ensure.ArgumentNotNull(uri, nameof(uri));

      return SendAPIRequest<T>(uri, HttpMethod.Put, parameters, body, cancel: cancel);
    }

    public async Task<HttpStatusCode> Put(Uri uri, IDictionary<string, string>? parameters, object? body, CancellationToken cancel)
    {
      Ensure.ArgumentNotNull(uri, nameof(uri));

      var response = await SendAPIRequestDetailed(uri, HttpMethod.Put, parameters, body, cancel: cancel).ConfigureAwait(false);
      return response.StatusCode;
    }

    public async Task<HttpStatusCode> PutRaw(Uri uri, IDictionary<string, string>? parameters, object? body, CancellationToken cancel)
    {
      Ensure.ArgumentNotNull(uri, nameof(uri));

      var response = await SendRawRequest(uri, HttpMethod.Put, parameters, body, cancel: cancel).ConfigureAwait(false);
      return response.StatusCode;
    }

    public void SetRequestTimeout(TimeSpan timeout)
    {
      _httpClient.SetRequestTimeout(timeout);
    }

    private IRequest CreateRequest(
        Uri uri,
        HttpMethod method,
        IDictionary<string, string>? parameters,
        object? body,
        IDictionary<string, string>? headers
      )
    {
      Ensure.ArgumentNotNull(uri, nameof(uri));
      Ensure.ArgumentNotNull(method, nameof(method));

      var requiresAccessToken = true;
      if (uri == new Uri("register", UriKind.Relative))
                requiresAccessToken = false;

      return new Request(
        _baseAddress,
        uri,
        method,
        headers ?? new Dictionary<string, string>(),
        parameters ?? new Dictionary<string, string>(),
        requiresAccessToken)
      {
        Body = body
      };
    }

    private async Task<IAPIResponse<T>> DoSerializedRequest<T>(IRequest request, CancellationToken cancel)
    {
      _jsonSerializer.SerializeRequest(request);
      var response = await DoRequest(request, cancel).ConfigureAwait(false);
      return _jsonSerializer.DeserializeResponse<T>(response);
    }

    private async Task<IResponse> DoRequest(IRequest request, CancellationToken cancel)
    {
      if(request.RequiresAccessToken)
        await ApplyAuthenticator(request).ConfigureAwait(false);
      _httpLogger?.OnRequest(request);
      IResponse response = await _httpClient.DoRequest(request, cancel).ConfigureAwait(false);
      _httpLogger?.OnResponse(response);
      ResponseReceived?.Invoke(this, response);
      if (_retryHandler != null)
      {
        response = await _retryHandler.HandleRetry(request, response, async (newRequest, ct) =>
        {
            if (request.RequiresAccessToken)
                await ApplyAuthenticator(request).ConfigureAwait(false);
          var newResponse = await _httpClient.DoRequest(request, ct).ConfigureAwait(false);
          _httpLogger?.OnResponse(newResponse);
          ResponseReceived?.Invoke(this, response);
          return newResponse;
        }, cancel).ConfigureAwait(false);
      }
      ProcessErrors(response);
      return response;
    }

    private async Task ApplyAuthenticator(IRequest request)
    {
      if (_authenticator != null)
      {
        _authenticator!.Apply(request, this);
      }
    }

    public Task<IResponse> SendRawRequest(
        Uri uri,
        HttpMethod method,
        IDictionary<string, string>? parameters = null,
        object? body = null,
        IDictionary<string, string>? headers = null,
        CancellationToken cancel = default
      )
    {
      var request = CreateRequest(uri, method, parameters, body, headers);
      return DoRequest(request, cancel);
    }

    public async Task<T> SendAPIRequest<T>(
        Uri uri,
        HttpMethod method,
        IDictionary<string, string>? parameters = null,
        object? body = null,
        IDictionary<string, string>? headers = null,
        CancellationToken cancel = default
      )
    {
      var request = CreateRequest(uri, method, parameters, body, headers);
      IAPIResponse<T> apiResponse = await DoSerializedRequest<T>(request, cancel).ConfigureAwait(false);
      return apiResponse.Body!;
    }

    public async Task<IResponse> SendAPIRequestDetailed(
        Uri uri,
        HttpMethod method,
        IDictionary<string, string>? parameters = null,
        object? body = null,
        IDictionary<string, string>? headers = null,
        CancellationToken cancel = default
      )
    {
      var request = CreateRequest(uri, method, parameters, body, headers);
      var response = await DoSerializedRequest<object>(request, cancel).ConfigureAwait(false);
      return response.Response;
    }

    private static void ProcessErrors(IResponse response)
    {
      Ensure.ArgumentNotNull(response, nameof(response));

      if ((int)response.StatusCode >= 200 && (int)response.StatusCode < 400)
      {
        return;
      }

      throw response.StatusCode switch
      {
        HttpStatusCode.Unauthorized => new APIUnauthorizedException(response),
        HttpStatusCode.Conflict => _handleServerError(response),
        // TODO: Remove hack once .netstandard 2.0 is not supported
        (HttpStatusCode)429 => new APITooManyRequestsException(response),
        _ => new APIException(response),
      };
    }

    private static Exception _handleServerError(IResponse response)
    {
        if (_useWaitForCooldown)
            return new APICooldownException(response);
        else
            return new APIException(response);
    }
  }
}
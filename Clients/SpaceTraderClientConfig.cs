using SpaceTradersDotNetSDK.Http.Interfaces;
using SpaceTradersDotNetSDK.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradersDotNetSDK.Clients
{
    public class SpaceTraderClientConfig
    {
        public Uri BaseAddress = new Uri("https://api.spacetraders.io/v2/");
        public IAuthenticator? Authenticator { get; private set; }
        public IJSONSerializer JSONSerializer { get; private set; }
        public IHTTPClient HTTPClient { get; private set; }
        public IHTTPLogger? HTTPLogger { get; private set; }
        public IRetryHandler? RetryHandler { get; private set; }
        public IAPIConnector? APIConnector { get; private set; }

        /// <summary>
        ///   This config spefies the internal parts of the SpotifyClient.
        /// </summary>
        /// <param name="baseAddress"></param>
        /// <param name="authenticator"></param>
        /// <param name="jsonSerializer"></param>
        /// <param name="httpClient"></param>
        /// <param name="retryHandler"></param>
        /// <param name="httpLogger"></param>
        /// <param name="apiConnector"></param>
        public SpaceTraderClientConfig(
          Uri baseAddress,
          IAuthenticator? authenticator,
          IJSONSerializer jsonSerializer,
          IHTTPClient httpClient,
          IRetryHandler? retryHandler,
          IHTTPLogger? httpLogger,
          IAPIConnector? apiConnector = null
        )
        {
            BaseAddress = baseAddress;
            Authenticator = authenticator;
            JSONSerializer = jsonSerializer;
            HTTPClient = httpClient;
            RetryHandler = retryHandler;
            HTTPLogger = httpLogger;
            APIConnector = apiConnector;
        }

        public SpaceTraderClientConfig WithToken(string token)
        {
            Ensure.ArgumentNotNull(token, nameof(token));

            return new SpaceTraderClientConfig(
              BaseAddress,
              new AuthorizationCodeAuthenticator(token),
              JSONSerializer,
              HTTPClient,
              RetryHandler,
              HTTPLogger
            );
        }


        public SpaceTraderClientConfig WithAuthenticator(IAuthenticator authenticator)
        {
            Ensure.ArgumentNotNull(authenticator, nameof(authenticator));

            return new SpaceTraderClientConfig(
              BaseAddress,
              authenticator,
              JSONSerializer,
              HTTPClient,
              RetryHandler,
              HTTPLogger
            );
        }

        public SpaceTraderClientConfig WithHTTPLogger(IHTTPLogger httpLogger)
        {
            return new SpaceTraderClientConfig(
              BaseAddress,
              Authenticator,
              JSONSerializer,
              HTTPClient,
              RetryHandler,
              httpLogger
            );
        }

        public SpaceTraderClientConfig WithHTTPClient(IHTTPClient httpClient)
        {
            Ensure.ArgumentNotNull(httpClient, nameof(httpClient));

            return new SpaceTraderClientConfig(
              BaseAddress,
              Authenticator,
              JSONSerializer,
              httpClient,
              RetryHandler,
              HTTPLogger
            );
        }

        public SpaceTraderClientConfig WithJSONSerializer(IJSONSerializer jsonSerializer)
        {
            Ensure.ArgumentNotNull(jsonSerializer, nameof(jsonSerializer));

            return new SpaceTraderClientConfig(
              BaseAddress,
              Authenticator,
              jsonSerializer,
              HTTPClient,
              RetryHandler,
              HTTPLogger
            );
        }


        public SpaceTraderClientConfig WithAPIConnector(IAPIConnector apiConnector)
        {
            Ensure.ArgumentNotNull(apiConnector, nameof(apiConnector));

            return new SpaceTraderClientConfig(
              BaseAddress,
              Authenticator,
              JSONSerializer,
              HTTPClient,
              RetryHandler,
              HTTPLogger,
              apiConnector
            );
        }

        public IAPIConnector BuildAPIConnector(bool useWaitForCooldownHandler)
        {
            return APIConnector ?? new APIConnector(
              BaseAddress,
              Authenticator,
              JSONSerializer,
              HTTPClient,
              RetryHandler,
              HTTPLogger,
              useWaitForCooldownHandler
            );
        }

        public static SpaceTraderClientConfig CreateDefault(IHTTPClient client, string token)
        {
            return CreateDefault(client).WithAuthenticator(new AuthorizationCodeAuthenticator(token));
        }

        public static SpaceTraderClientConfig CreateDefault(IHTTPClient client)
        {
            return new SpaceTraderClientConfig(
              new Uri("https://api.spacetraders.io/v2/"),
              null,
              new NewtonsoftJSONSerializer(),
              client,
              null,
              null
            );
        }
    }
}

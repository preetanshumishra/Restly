using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Restly.Core.Exceptions;
using Restly.Core.Services.Abstractions;

namespace Restly.Core.Services.Implementations
{
    public class RestApiClient : IRestApiClient
    {
        private static readonly TimeSpan HttpTimeOut = TimeSpan.FromSeconds(Constants.ApiConstants.ApiTimeOut);

        private readonly Dictionary<string, string> _headers = new Dictionary<string, string>();
        private readonly JsonSerializerSettings _serializerSettings;

        public RestApiClient()
        {
            _serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore
            };
            _serializerSettings.Converters.Add(new StringEnumConverter());
        }

        #region Public Methods

        public async Task<TResponse> GetAsync<TResponse>(
            string apiPath,
            CancellationToken cancellationToken = default)
            where TResponse : new()
        {
            try
            {
                return await CallWithResponseAsync<TResponse>(apiPath, HttpMethod.Get, null, cancellationToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TResponse> GetAsync<TRequest, TResponse>(
            string apiPath,
            TRequest requestModel,
            CancellationToken cancellationToken = default)
            where TResponse : new()
        {
            try
            {
                var content = JsonConvert.SerializeObject(requestModel);
                return await CallWithResponseAsync<TResponse>(apiPath, HttpMethod.Get, content, cancellationToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> PostAsync<TRequest>(
            string apiPath,
            TRequest requestModel,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var content = JsonConvert.SerializeObject(requestModel);
                return await CallWithNoResponseAsync(apiPath, HttpMethod.Post, content, cancellationToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(
            string apiPath,
            TRequest requestModel,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var content = JsonConvert.SerializeObject(requestModel);
                return await CallWithResponseAsync<TResponse>(apiPath, HttpMethod.Post, content, cancellationToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> PutAsync<TRequest>(
            string apiPath,
            TRequest requestModel,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var content = JsonConvert.SerializeObject(requestModel);
                return await CallWithNoResponseAsync(apiPath, HttpMethod.Put, content, cancellationToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TResponse> PutAsync<TRequest, TResponse>(
            string apiPath,
            TRequest requestModel,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var content = JsonConvert.SerializeObject(requestModel);
                return await CallWithResponseAsync<TResponse>(apiPath, HttpMethod.Put, content, cancellationToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAsync<TRequest>(
            string apiPath,
            TRequest requestModel,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var content = JsonConvert.SerializeObject(requestModel);
                await CallWithNoResponseAsync(apiPath, HttpMethod.Delete, content, cancellationToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Private Methods

        //private void AddHttpHeader(string key, string value)
        //{
        //    if (_headers.ContainsKey(key))
        //    {
        //        _headers.Remove(key);
        //    }
        //    _headers.Add(key, value);
        //}

        //private void AddHttpHeader(IDictionary<string, string> headers)
        //{
        //    foreach (var key in headers.Keys)
        //    {
        //        AddHttpHeader(key, headers[key]);
        //    }
        //}

        private HttpClient CreateHttpClient(string url)
        {
            var httpHandler = new HttpClientHandler();
            var httpClient = new HttpClient(httpHandler);
            httpClient.BaseAddress = new Uri(url);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.Timeout = HttpTimeOut;
            return httpClient;
        }

        private HttpRequestMessage GetHttpRequest(
            string url,
            HttpMethod method,
            string content = null)
        {
            var message = new HttpRequestMessage(method, url);
            foreach (var header in _headers)
            {
                message.Headers.Add(header.Key, header.Value);
            }

            message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (!string.IsNullOrEmpty(content))
            {
                message.Content = new StringContent(content, Encoding.UTF8, "application/json");
            }

            return message;
        }

        private async Task<bool> CallWithNoResponseAsync(
            string apiPath,
            HttpMethod httpMethod,
            string content = null,
            CancellationToken cancellationToken = default)
        {
            using var client = CreateHttpClient(apiPath);
            using var requestMessage = GetHttpRequest(apiPath, httpMethod, content);
            var response = await client.SendAsync(requestMessage, cancellationToken).ConfigureAwait(false);
            await HandleResponseAsync(response);
            var serializedResponse = await response.Content.ReadAsStringAsync();
            return response.IsSuccessStatusCode;
        }

        private async Task<TResponse> CallWithResponseAsync<TResponse>(
            string apiPath,
            HttpMethod httpMethod,
            string content = null,
            CancellationToken cancellationToken = default)
        {
            using var client = CreateHttpClient(apiPath);
            using var requestMessage = GetHttpRequest(apiPath, httpMethod, content);
            var response = await client.SendAsync(requestMessage, cancellationToken).ConfigureAwait(false);
            await HandleResponseAsync(response);
            var serializedResponse = await response.Content.ReadAsStringAsync();
            var result = await Task.Run(
                () => JsonConvert.DeserializeObject<TResponse>(serializedResponse, _serializerSettings));
            return result;
        }

        private void HandleResponseAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return;
            }

            if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new CustomHttpRequestException(HttpStatusCode.Unauthorized, "Server unresponsive");
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new CustomHttpRequestException(HttpStatusCode.Unauthorized, "User is not authorized");
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new CustomHttpRequestException(response.StatusCode, "Resource not found");
            }

            throw new CustomHttpRequestException(response.StatusCode, "Api error");
        }

        #endregion
    }
}
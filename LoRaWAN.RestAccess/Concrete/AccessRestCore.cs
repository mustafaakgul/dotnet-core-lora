using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using LoRaWAN.RestAccess.Abstract;
using LoRaWAN.RestAccess.Models;
using RestSharp;
using System;
using System.Globalization;

namespace LoRaWAN.RestAccess.Concrete
{
    public class AccessRestCore : IAccessRestCore
    {
        private readonly RestAccessSettings _settings;
        private readonly CultureInfo _language;

        public AccessRestCore(IOptionsSnapshot<RestAccessSettings> settings)
        {
            _settings = settings.Value;
            _language = CultureInfo.CurrentCulture;
        }

        public IRestResponse Execute(Connection connection, Method method)
        {
            var version = !string.IsNullOrWhiteSpace(_settings.DefaultVersion) ? $"/{_settings.DefaultVersion}" : string.Empty;
            var areaName = !string.IsNullOrWhiteSpace(connection.Area) ? $"/{connection.Area}" : string.Empty;
            var controllerName = !string.IsNullOrWhiteSpace(connection.Controller) ? $"/{connection.Controller}" : string.Empty;
            var actionName = !string.IsNullOrWhiteSpace(connection.Action) ? $"/{connection.Action}" : string.Empty;
            var query = !string.IsNullOrWhiteSpace(connection.Query) ? $"/{connection.Query}" : string.Empty;
            var queryString = !string.IsNullOrWhiteSpace(connection.QueryString) ? $"?{connection.QueryString}" : string.Empty;

            var client = new RestClient() { 
                BaseUrl = new Uri($"{_settings.BaseUrl}{version}{areaName}{controllerName}{actionName}{query}{queryString}"),
                //Proxy = new WebProxy { UseDefaultCredentials = true },
            };
            var request = new RestRequest() { Method = method };
            request.Parameters.Clear();

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Accept-Language", _language.Name);
            if (!string.IsNullOrWhiteSpace(_settings.GeneratedToken.Token) & !string.IsNullOrWhiteSpace(_settings.GeneratedToken.Name))
                request.AddHeader(_settings.GeneratedToken.Name, _settings.GeneratedToken.Token);

            //ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol | SecurityProtocolType.Tls12;

            return client.Execute(request);
        }

        public IRestResponse Execute<TRequest>(Connection<TRequest> connection, Method method)
        {
            var version = !string.IsNullOrWhiteSpace(_settings.DefaultVersion) ? $"/{_settings.DefaultVersion}" : string.Empty;
            var areaName = !string.IsNullOrWhiteSpace(connection.Area) ? $"/{connection.Area}" : string.Empty;
            var controllerName = !string.IsNullOrWhiteSpace(connection.Controller) ? $"/{connection.Controller}" : string.Empty;
            var actionName = !string.IsNullOrWhiteSpace(connection.Action) ? $"/{connection.Action}" : string.Empty;
            var query = !string.IsNullOrWhiteSpace(connection.Query) ? $"/{connection.Query}" : string.Empty;
            var queryString = !string.IsNullOrWhiteSpace(connection.QueryString) ? $"?{connection.QueryString}" : string.Empty;

            var client = new RestClient()
            {
                BaseUrl = new Uri($"{_settings.BaseUrl}{version}{areaName}{controllerName}{actionName}{query}{queryString}"),
                //Proxy = new WebProxy { UseDefaultCredentials = true },
            };
            var request = new RestRequest() { Method = method };
            request.Parameters.Clear();

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Accept-Language", _language.Name);
            if (!string.IsNullOrWhiteSpace(_settings.GeneratedToken.Token) & !string.IsNullOrWhiteSpace(_settings.GeneratedToken.Name))
                request.AddHeader(_settings.GeneratedToken.Name, _settings.GeneratedToken.Token);
            request.AddParameter("application/json", JsonConvert.SerializeObject(connection.Model), ParameterType.RequestBody);

            return client.Execute(request);
        }

        public IRestResponse<TResponse> Execute<TResponse>(Connection connection, Method method) where TResponse : new()
        {
            var version = !string.IsNullOrWhiteSpace(_settings.DefaultVersion) ? $"/{_settings.DefaultVersion}" : string.Empty;
            var areaName = !string.IsNullOrWhiteSpace(connection.Area) ? $"/{connection.Area}" : string.Empty;
            var controllerName = !string.IsNullOrWhiteSpace(connection.Controller) ? $"/{connection.Controller}" : string.Empty;
            var actionName = !string.IsNullOrWhiteSpace(connection.Action) ? $"/{connection.Action}" : string.Empty;
            var query = !string.IsNullOrWhiteSpace(connection.Query) ? $"/{connection.Query}" : string.Empty;
            var queryString = !string.IsNullOrWhiteSpace(connection.QueryString) ? $"?{connection.QueryString}" : string.Empty;

            var client = new RestClient()
            {
                BaseUrl = new Uri($"{_settings.BaseUrl}{version}{areaName}{controllerName}{actionName}{query}{queryString}"),
                //Proxy = new WebProxy { UseDefaultCredentials = true },
            };
            var request = new RestRequest() { Method = method };
            request.Parameters.Clear();

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Accept-Language", _language.Name);
            if (!string.IsNullOrWhiteSpace(_settings.GeneratedToken.Token) & !string.IsNullOrWhiteSpace(_settings.GeneratedToken.Name))
                request.AddHeader(_settings.GeneratedToken.Name, _settings.GeneratedToken.Token);

            return client.Execute<TResponse>(request);
        }

        public IRestResponse<TResponse> Execute<TResponse, TRequest>(Connection<TRequest> connection, Method method)
        {
            var version = !string.IsNullOrWhiteSpace(_settings.DefaultVersion) ? $"/{_settings.DefaultVersion}" : string.Empty;
            var areaName = !string.IsNullOrWhiteSpace(connection.Area) ? $"/{connection.Area}" : string.Empty;
            var controllerName = !string.IsNullOrWhiteSpace(connection.Controller) ? $"/{connection.Controller}" : string.Empty;
            var actionName = !string.IsNullOrWhiteSpace(connection.Action) ? $"/{connection.Action}" : string.Empty;
            var query = !string.IsNullOrWhiteSpace(connection.Query) ? $"/{connection.Query}" : string.Empty;
            var queryString = !string.IsNullOrWhiteSpace(connection.QueryString) ? $"?{connection.QueryString}" : string.Empty;

            var client = new RestClient()
            {
                BaseUrl = new Uri($"{_settings.BaseUrl}{version}{areaName}{controllerName}{actionName}{query}{queryString}"),
                //Proxy = new WebProxy { UseDefaultCredentials = true },
            };
            var request = new RestRequest() { Method = method };
            request.Parameters.Clear();

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Accept-Language", _language.Name);
            if (!string.IsNullOrWhiteSpace(_settings.GeneratedToken.Token) & !string.IsNullOrWhiteSpace(_settings.GeneratedToken.Name))
                request.AddHeader(_settings.GeneratedToken.Name, _settings.GeneratedToken.Token);
            request.AddParameter("application/json", JsonConvert.SerializeObject(connection.Model), ParameterType.RequestBody);

            return client.Execute<TResponse>(request);
        }

    }
}

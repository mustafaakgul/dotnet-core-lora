using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using LoRaWAN.ResponseStates.Models;
using LoRaWAN.RestAccess.Abstract;
using LoRaWAN.RestAccess.Models;
using RestSharp;

namespace LoRaWAN.RestAccess.Concrete
{
    public class AccessRestService : IAccessRest
    {
        private readonly IAccessRestCore _restAccessCore;

        public AccessRestService(IAccessRestCore restAccessCore)
        {
            _restAccessCore = restAccessCore;
        }

        public ResponseState<TResponse> GetJSON<TResponse>(Connection connection)
        {
            var response = _restAccessCore.Execute(connection, Method.GET);
            return JsonConvert.DeserializeObject<ResponseState<TResponse>>(response.Content);
        }

        public ResponseState<TResponse> GetJSON<TResponse, TRequest>(Connection<TRequest> connection)
        {
            var response = _restAccessCore.Execute<TResponse, TRequest>(connection, Method.GET);
            return JsonConvert.DeserializeObject<ResponseState<TResponse>>(response.Content);
        }

        public ResponseState<TResponse> PostJSON<TResponse>(Connection connection)
        {
            var response = _restAccessCore.Execute(connection, Method.POST);
            return JsonConvert.DeserializeObject<ResponseState<TResponse>>(response.Content);
        }

        public ResponseState PostJSON(Connection connection)
        {
            var response = _restAccessCore.Execute(connection, Method.POST);
            return JsonConvert.DeserializeObject<ResponseState>(response.Content);
        }

        public ResponseState PostJSON<TRequest>(Connection<TRequest> connection)
        {
            var response = _restAccessCore.Execute(connection, Method.POST);
            return JsonConvert.DeserializeObject<ResponseState>(response.Content);
        }

        public ResponseState<TResponse> PostJSON<TResponse, TRequest>(Connection<TRequest> connection)
        {
            var response = _restAccessCore.Execute<TResponse, TRequest>(connection, Method.POST);
            return JsonConvert.DeserializeObject<ResponseState<TResponse>>(response.Content);
        }

        public ResponseState<TResponse> PutJSON<TResponse>(Connection connection)
        {
            var response = _restAccessCore.Execute(connection, Method.PUT);
            return JsonConvert.DeserializeObject<ResponseState<TResponse>>(response.Content);
        }

        public ResponseState<TResponse> PutJSON<TResponse, TRequest>(Connection<TRequest> connection)
        {
            var response = _restAccessCore.Execute<TResponse, TRequest>(connection, Method.PUT);
            return JsonConvert.DeserializeObject<ResponseState<TResponse>>(response.Content);
        }

        public ResponseState<TResponse> DeleteJSON<TResponse>(Connection connection)
        {
            var response = _restAccessCore.Execute(connection, Method.DELETE);
            return JsonConvert.DeserializeObject<ResponseState<TResponse>>(response.Content);
        }

        public ResponseState DeleteJSON(Connection connection)
        {
            var response = _restAccessCore.Execute(connection, Method.DELETE);
            return JsonConvert.DeserializeObject<ResponseState>(response.Content);
        }

        public ResponseState DeleteJSON<TRequest>(Connection<TRequest> connection)
        {
            var response = _restAccessCore.Execute(connection, Method.DELETE);
            return JsonConvert.DeserializeObject<ResponseState>(response.Content);
        }

        public ResponseState<TResponse> DeleteJSON<TResponse, TRequest>(Connection<TRequest> connection)
        {
            var response = _restAccessCore.Execute<TResponse, TRequest>(connection, Method.DELETE);
            return JsonConvert.DeserializeObject<ResponseState<TResponse>>(response.Content);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using LoRaWAN.ResponseStates.Enums;
using LoRaWAN.ResponseStates.Models;
using LoRaWAN.RestAccess.Abstract;
using LoRaWAN.RestAccess.Models;
using RestSharp;

namespace LoRaWAN.RestAccess.Concrete
{
    public class AccessRest : IAccessRest
    {
        private readonly IAccessRestCore _restAccessCore;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITempDataDictionaryFactory _tempDataDictionaryFactory;

        public AccessRest(IAccessRestCore restAccessCore, IHttpContextAccessor httpContextAccessor, ITempDataDictionaryFactory tempDataDictionaryFactory)
        {
            _restAccessCore = restAccessCore;
            _httpContextAccessor = httpContextAccessor;
            _tempDataDictionaryFactory = tempDataDictionaryFactory;
        }

        public ResponseState<TResponse> GetJSON<TResponse>(Connection connection)
        {
            var response = _restAccessCore.Execute(connection, Method.GET);
            var responseClass = JsonConvert.DeserializeObject<ResponseState<TResponse>>(response.Content);
            
            if (!responseClass.Status.Success) ErrorTempData(responseClass);

            return responseClass;
        }

        public ResponseState<TResponse> GetJSON<TResponse, TRequest>(Connection<TRequest> connection)
        {
            var response = _restAccessCore.Execute<TResponse, TRequest>(connection, Method.GET);
            var responseClass = JsonConvert.DeserializeObject<ResponseState<TResponse>>(response.Content);
            
            if (!responseClass.Status.Success)
                ErrorTempData(responseClass);

            return responseClass;
        }

        public ResponseState PostJSON(Connection connection)
        {
            var response = _restAccessCore.Execute(connection, Method.POST);
            return JsonConvert.DeserializeObject<ResponseState>(response.Content);
        }

        public ResponseState PostJSON<TRequest>(Connection<TRequest> connection)
        {
            var response = _restAccessCore.Execute(connection, Method.POST);
            var responseClass = JsonConvert.DeserializeObject<ResponseState>(response.Content);

            if (!responseClass.Status.Success)
                ErrorTempData(responseClass);

            return responseClass;
        }

        public ResponseState<TResponse> PostJSON<TResponse>(Connection connection)
        {
            var response = _restAccessCore.Execute(connection, Method.POST);
            var responseClass = JsonConvert.DeserializeObject<ResponseState<TResponse>>(response.Content);

            if (!responseClass.Status.Success)
                ErrorTempData(responseClass);

            return responseClass;
        }

        public ResponseState<TResponse> PostJSON<TResponse, TRequest>(Connection<TRequest> connection)
        {
            var response = _restAccessCore.Execute<TResponse, TRequest>(connection, Method.POST);
            var responseClass = JsonConvert.DeserializeObject<ResponseState<TResponse>>(response.Content);

            if (!responseClass.Status.Success)
                ErrorTempData(responseClass);

            return responseClass;
        }

        public ResponseState<TResponse> PutJSON<TResponse>(Connection connection)
        {
            var response = _restAccessCore.Execute(connection, Method.PUT);
            var responseClass = JsonConvert.DeserializeObject<ResponseState<TResponse>>(response.Content);

            if (!responseClass.Status.Success)
                ErrorTempData(responseClass);

            return responseClass;
        }

        public ResponseState<TResponse> PutJSON<TResponse, TRequest>(Connection<TRequest> connection)
        {
            var response = _restAccessCore.Execute<TResponse, TRequest>(connection, Method.PUT);
            var responseClass = JsonConvert.DeserializeObject<ResponseState<TResponse>>(response.Content);

            if (!responseClass.Status.Success)
                ErrorTempData(responseClass);

            return responseClass;
        }

        public ResponseState<TResponse> DeleteJSON<TResponse>(Connection connection)
        {
            var response = _restAccessCore.Execute(connection, Method.DELETE);
            var responseClass = JsonConvert.DeserializeObject<ResponseState<TResponse>>(response.Content);

            if (!responseClass.Status.Success)
                ErrorTempData(responseClass);

            return responseClass;
        }

        public ResponseState DeleteJSON(Connection connection)
        {
            var response = _restAccessCore.Execute(connection, Method.DELETE);
            return JsonConvert.DeserializeObject<ResponseState>(response.Content);
        }

        public ResponseState DeleteJSON<TRequest>(Connection<TRequest> connection)
        {
            var response = _restAccessCore.Execute(connection, Method.DELETE);
            var responseClass = JsonConvert.DeserializeObject<ResponseState>(response.Content);

            if (!responseClass.Status.Success)
                ErrorTempData(responseClass);

            return responseClass;
        }

        public ResponseState<TResponse> DeleteJSON<TResponse, TRequest>(Connection<TRequest> connection)
        {
            var response = _restAccessCore.Execute<TResponse, TRequest>(connection, Method.DELETE);
            var responseClass = JsonConvert.DeserializeObject<ResponseState<TResponse>>(response.Content);

            if (!responseClass.Status.Success)
                ErrorTempData(responseClass);

            return responseClass;
        }

        private void ErrorTempData(ResponseState responseState)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var tempData = _tempDataDictionaryFactory.GetTempData(httpContext);

            tempData["ErrorHandeled"] = JsonConvert.SerializeObject(responseState.Status);
        }
        private void ErrorTempData<TResponse>(ResponseState<TResponse> responseState)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var tempData = _tempDataDictionaryFactory.GetTempData(httpContext);

            tempData["ErrorHandeled"] = JsonConvert.SerializeObject(responseState.Status);
        }
    }
}

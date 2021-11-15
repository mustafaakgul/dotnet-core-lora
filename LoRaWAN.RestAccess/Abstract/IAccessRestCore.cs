using LoRaWAN.RestAccess.Models;
using RestSharp;

namespace LoRaWAN.RestAccess.Abstract
{
    public interface IAccessRestCore
    {
        IRestResponse Execute(Connection connection, Method method);
        IRestResponse Execute<TRequest>(Connection<TRequest> connection, Method method);
        IRestResponse<TResponse> Execute<TResponse>(Connection connection, Method method) where TResponse : new();
        IRestResponse<TResponse> Execute<TResponse, TRequest>(Connection<TRequest> connection, Method method);
    }
}

using LoRaWAN.ResponseStates.Models;
using LoRaWAN.RestAccess.Models;

namespace LoRaWAN.RestAccess.Abstract
{
    public interface IAccessRest
    {
        ResponseState<T> GetJSON<T>(Connection connection);
        ResponseState<TResponse> GetJSON<TResponse, TRequest>(Connection<TRequest> connection);
        ResponseState<T> PostJSON<T>(Connection connection);
        ResponseState PostJSON(Connection connection);
        ResponseState PostJSON<TRequest>(Connection<TRequest> connection);
        ResponseState<TResponse> PostJSON<TResponse, TRequest>(Connection<TRequest> connection);
        ResponseState<T> PutJSON<T>(Connection connection);
        ResponseState<TResponse> PutJSON<TResponse, TRequest>(Connection<TRequest> connection);
        ResponseState<T> DeleteJSON<T>(Connection connection);
        ResponseState DeleteJSON(Connection connection);
        ResponseState DeleteJSON<TRequest>(Connection<TRequest> connection);
        ResponseState<TResponse> DeleteJSON<TResponse, TRequest>(Connection<TRequest> connection);
    }
}

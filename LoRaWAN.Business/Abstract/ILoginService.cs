using LoRaWAN.Entity.DTOs.WebUI.User;
using LoRaWAN.ResponseStates.Models;

namespace LoRaWAN.Business.Abstract
{
    public interface ILoginService
    {
        public ResponseState<UserDto> UserLogin(LoginDto loginDto);
    }
}
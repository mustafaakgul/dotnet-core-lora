using System;
using LoRaWAN.Entity.Concrete;
using LoRaWAN.Entity.DTOs.WebUI.User;
using LoRaWAN.ResponseStates.Models;

namespace LoRaWAN.Business.Abstract
{
    public interface IUserService
    {
        public ResponseState Create(RegisterDto registerDto);
        public User Detail(LoginDto loginDto);
    }
}

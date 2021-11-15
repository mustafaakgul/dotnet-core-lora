using System;
using LoRaWAN.Business.Abstract;
using LoRaWAN.Data.Dals.Abstract;

namespace LoRaWAN.Business.Concrete
{
    public class EndNodeService : IEndNodeService
    {
        private readonly IUserRepository _userRepository;

        public EndNodeService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
    }
}

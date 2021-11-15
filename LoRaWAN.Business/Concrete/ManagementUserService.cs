using System;
using LoRaWAN.Business.Abstract;
using LoRaWAN.Data.Dals.Abstract;

namespace LoRaWAN.Business.Concrete
{
    public class ManagementUserService : IManagementUserService
    {
        private readonly IManagementUserRepository _managementUserRepository;

        public ManagementUserService(IManagementUserRepository managementUserRepository)
        {
            _managementUserRepository = managementUserRepository;
        }
    }
}

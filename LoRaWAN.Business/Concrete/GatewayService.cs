using System;
using LoRaWAN.Business.Abstract;
using LoRaWAN.Data.Dals.Abstract;

namespace LoRaWAN.Business.Concrete
{
    public class GatewayService : IGatewayService
    {
        private readonly IGatewayRepository _gatewayRepository;

        public GatewayService(IGatewayRepository gatewayRepository)
        {
            _gatewayRepository = gatewayRepository;
        }
    }
}

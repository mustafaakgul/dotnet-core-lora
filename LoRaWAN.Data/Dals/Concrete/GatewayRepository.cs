using System;
using LoRaWAN.Data.Context;
using LoRaWAN.Data.Dals.Abstract;
using LoRaWAN.Data.Extensions;
using LoRaWAN.Data.Repositories;
using LoRaWAN.Entity.Concrete;
using LoRaWAN.Entity.Enums;

namespace LoRaWAN.Data.Dals.Concrete
{
    public class GatewayRepository : EfRepository<Gateway>, IGatewayRepository
    {
        private readonly LoRaWANDBContext _context;

        public GatewayRepository(LoRaWANDBContext context) : base(context)
        {
            _context = context;
        }
    }
}

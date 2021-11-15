using LoRaWAN.Entity.Concrete;
using LoRaWAN.Entity.Enums;
using LoRaWAN.Entity.DTOs.Common;
using LoRaWAN.ResponseStates.Enums;
using LoRaWAN.ResponseStates.Exceptions;
using System;
using LoRaWAN.Utilities.Extensions;

namespace LoRaWAN.Data.Extensions
{
    public static class EntityControlExtension
    {
        public static User Control(this User user)
        {
            if (user == null)
            {
                //Log kayıtların geleceği yer
                throw new StateException { StateCode = StateCode.NotFoundUser };
            }
            else if (user.IsDelete)
            {
                //Log kayıtların geleceği yer
                throw new StateException { StateCode = StateCode.DeletedUser };
            }
            if (!user.IsActive)
            {
                //Log kayıtların geleceği yer
                throw new StateException { StateCode = StateCode.InActiveUser };
            }
            else
            {
                return user;
            }
        }
    }
}

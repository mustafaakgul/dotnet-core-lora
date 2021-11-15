using LoRaWAN.ResponseStates.Enums;
using System;
using System.Collections.Generic;

namespace LoRaWAN.ResponseStates.Exceptions
{
    public class StateException : Exception
    {
        public StateCode StateCode { get; set; }
        public string Messages { get; set; }

        public StateException()
        { }
        public StateException(StateCode stateCode)
        {
            StateCode = stateCode;
        }
        public StateException(string message) : base(message)
        {
            StateCode = StateCode.Error;
        }
        public StateException(StateCode stateCode, string message) : base(message)
        {
            StateCode = stateCode;
            Messages = message;
        }
    }
}

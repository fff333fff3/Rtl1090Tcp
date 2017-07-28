using System;

namespace Rtl1090Tcp
{
    internal class TransmissionMessage : TelemetryMessage
    {
        public TransmissionMessage(string[] parts) : base(BsTypeCode.TransmissionMessage, parts)
        {
        }
    }
}
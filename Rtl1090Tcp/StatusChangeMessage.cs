using System;

namespace Rtl1090Tcp
{
    internal class StatusChangeMessage : TelemetryMessage
    {
        public StatusChangeMessage(string[] parts) : base(BsTypeCode.StatusChange, parts)
        {
            throw new NotImplementedException();
        }
    }
}
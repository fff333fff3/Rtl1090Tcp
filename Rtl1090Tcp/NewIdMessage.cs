using System;

namespace Rtl1090Tcp
{
    internal class NewIdMessage : TelemetryMessage
    {
        public NewIdMessage(string[] parts) : base(BsTypeCode.NewId, parts)
        {
            throw new NotImplementedException();
        }
    }
}
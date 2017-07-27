using System;

namespace Rtl1090Tcp
{
    internal class ClickMessage : TelemetryMessage
    {
        public ClickMessage(string[] parts) : base(BsTypeCode.Click, parts)
        {
            throw new NotImplementedException();
        }
    }
}
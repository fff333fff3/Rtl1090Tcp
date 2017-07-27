using System;

namespace Rtl1090Tcp
{
    internal class SelectionChangeMessage : TelemetryMessage
    {
        public SelectionChangeMessage(string[] parts) : base(BsTypeCode.SelectionChange, parts)
        {
            throw new NotImplementedException();
        }
    }
}
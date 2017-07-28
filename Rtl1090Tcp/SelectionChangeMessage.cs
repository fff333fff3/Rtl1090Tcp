using System;
using System.Collections.Generic;

namespace Rtl1090Tcp
{
    internal class SelectionChangeMessage : TelemetryMessage
    {
        public int Callsign;

        public SelectionChangeMessage(IReadOnlyList<string> parts) : base(BsTypeCode.SelectionChange, parts)
        {
            int.TryParse(parts[10], out Callsign);
        }
    }
}
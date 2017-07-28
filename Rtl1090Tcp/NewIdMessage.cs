using System;
using System.Collections.Generic;

namespace Rtl1090Tcp
{
    internal class NewIdMessage : TelemetryMessage
    {
        public int Callsign;

        public NewIdMessage(IReadOnlyList<string> parts) : base(BsTypeCode.NewId, parts)
        {
            int.TryParse(parts[10], out Callsign);
        }
    }
}
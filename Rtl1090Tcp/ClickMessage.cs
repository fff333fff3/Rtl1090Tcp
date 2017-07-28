using System;
using System.IO;

namespace Rtl1090Tcp
{
    internal class ClickMessage : TelemetryMessage
    {
        public ClickMessage(string[] parts) : base(BsTypeCode.Click, parts)
        {
            if (parts[3] != "-1" || parts[5] != "-1")
                throw new InvalidDataException();
        }
    }
}
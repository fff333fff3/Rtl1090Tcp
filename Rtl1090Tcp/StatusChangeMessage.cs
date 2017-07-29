using System;
using System.IO;

namespace Rtl1090Tcp
{
    internal partial class StatusChangeMessage : TelemetryMessage
    {
        public BsStatus Status;

        public StatusChangeMessage(string[] parts) : base(BsTypeCode.StatusChange, parts)
        {
            switch (Util.Get(parts, 10))
            {
                case "PL":
                    Status = BsStatus.PositionLost;
                    break;
                case "SL":
                    Status = BsStatus.SignalLost;
                    break;
                case "RM":
                    Status = BsStatus.Remove;
                    break;
                case "AD":
                    Status = BsStatus.Delete;
                    break;
                case "OK":
                    Status = BsStatus.Ok;
                    break;
                default:
                    throw new InvalidDataException(string.Format(Lang.UnknownStatus, Util.Get(parts, 0)));
            }
        }
    }
}
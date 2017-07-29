namespace Rtl1090Tcp
{
    internal partial class StatusChangeMessage : TelemetryMessage
    {
        internal enum BsStatus
        {
            PositionLost,
            SignalLost,
            Remove,
            Delete,
            Ok
        }
    }
}
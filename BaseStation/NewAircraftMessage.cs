namespace BaseStationDotNet
{
    public class NewAircraftMessage : TelemetryMessage
    {
        public NewAircraftMessage(string[] parts) : base(BsTypeCode.NewAircraft, parts)
        {
        }
    }
}
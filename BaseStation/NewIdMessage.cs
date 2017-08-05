namespace BaseStationDotNet
{
    public class NewIdMessage : TelemetryMessage
    {
        public string Callsign;

        public NewIdMessage(string[] parts) : base(BsTypeCode.NewId, parts)
        {
            Callsign = Util.Get(parts, 10);
        }
    }
}
namespace BaseStationDotNet
{
    public class SelectionChangeMessage : TelemetryMessage
    {
        public int Callsign;

        public SelectionChangeMessage(string[] parts) : base(BsTypeCode.SelectionChange, parts)
        {
            int.TryParse(Util.Get(parts, 10), out Callsign);
        }
    }
}
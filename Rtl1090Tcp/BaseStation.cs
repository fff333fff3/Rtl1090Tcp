﻿using System.Linq;

namespace Rtl1090Tcp
{
    internal class BaseStation
    {
        public static TelemetryMessage Parse(string data)
        {
            var parts = data.Split(',').Select(s => s.Trim().ToUpper()).ToArray();

            if (parts.Length < 10)
                return null;

            switch (parts[0])
            {
                case "SEL":
                    return new SelectionChangeMessage(parts);
                case "ID":
                    return new NewIdMessage(parts);
                case "AIR":
                    return new NewAircraftMessage(parts);
                case "STA":
                    return new StatusChangeMessage(parts);
                case "CLK":
                    return new ClickMessage(parts);
                case "MSG":
                    return new TransmissionMessage(BsTypeCode.NewAircraft, parts);
                default:
                    return null;
            }
        }
    }
}
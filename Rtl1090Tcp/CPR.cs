using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rtl1090Tcp
{
    /*
     * Compact Position Reporting
     */
    class CPR
    {
        public const int NumLatitudeZones = 15;

        public static double Nl(double lat)
        {
            if (Math.Abs(Math.Floor(lat) - 90) < 0.001)
                return 1;
            var a = 1 - Math.Cos(Math.PI / (2 * NumLatitudeZones));
            var b = Math.Pow(Math.Cos(Math.PI / 180.0 * Math.Abs(lat)), 2);
            var nl = 2 * Math.PI / Math.Acos(1 - a / b);
            return Math.Floor(nl);
        }
    }
}

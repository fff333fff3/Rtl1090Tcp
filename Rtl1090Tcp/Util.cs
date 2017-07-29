namespace Rtl1090Tcp
{
    internal class Util
    {
        public static string Get(string[] parts, int i)
        {
            return parts.Length <= i ? "" : parts[i];
        }
    }
}
using System.Linq;
using System.Globalization;

namespace DemoZXing.Helpers
{
    public static class BarcodeValidation
    {
        public static bool IsValidEan(string eanBarcode, int length)
        {
            if (eanBarcode.Length != length)
                return false;

            var allDigits = eanBarcode.Select(c => int.Parse(c.ToString(CultureInfo.InvariantCulture))).ToArray();
            var s = length % 2 == 0 ? 3 : 1;
            var s2 = s == 3 ? 1 : 3;

            return allDigits.Last() == (10 - (allDigits.Take(length - 1).Select((c, ci) => c * (ci % 2 == 0 ? s : s2)).Sum() % 10)) % 10;
        }
    }
}

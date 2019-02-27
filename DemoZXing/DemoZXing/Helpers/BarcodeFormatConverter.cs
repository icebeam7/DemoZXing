using System;

using ZXing;

namespace DemoZXing.Helpers
{
    public static class BarcodeFormatConverter
    {
        public static string ConvertEnumToString(Enum eEnum) => Enum.GetName(eEnum.GetType(), eEnum);
        public static BarcodeFormat ConvertStringToEnum(string value) => (BarcodeFormat)Enum.Parse(typeof(BarcodeFormat), value);
    }
}

namespace MonitoR.Common.Common
{
    public enum SizeUnitType
    {
        KB,
        MB,
        GB,
        TB
    }

    public static class SizeUnitTypeHelper
    {
        public static string SizeUnitTypeToString(this SizeUnitType suType)
        {
            return suType.ToString();
        }

        public static SizeUnitType ToSizeUnitType(this string suTypeStr)
        {
            if (nameof(SizeUnitType.KB) == suTypeStr)
            {
                return SizeUnitType.KB;
            }
            else if (nameof(SizeUnitType.GB) == suTypeStr)
            {
                return SizeUnitType.GB;
            }
            if (nameof(SizeUnitType.TB) == suTypeStr)
            {
                return SizeUnitType.TB;
            }
            else
            {
                return SizeUnitType.MB;
            }
        }

        public static double ToSizeUnitValue(this SizeUnitType suType, long sizeInBytes)
        {
            switch (suType)
            {
                case SizeUnitType.KB:
                    return sizeInBytes/ 1024.0;
                case SizeUnitType.GB:
                    return sizeInBytes / (1024.0 * 1024 * 1024);
                case SizeUnitType.TB:
                    return sizeInBytes / (1024.0 * 1024 * 1024 * 1024);
                case SizeUnitType.MB:
                default:
                    return sizeInBytes / (1024.0 * 1024);
            }
        }
    }
}

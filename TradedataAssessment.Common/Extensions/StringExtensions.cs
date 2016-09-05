namespace TradedataAssessment.Common.Extensions
{
    public static class StringExtensions
    {
        public static bool HasContent(this string value)
        {
            return !string.IsNullOrEmpty(value);
        }

        public static string With(this string format, params object[] args)
        {
            return string.Format(format, args);
        }
    }
}
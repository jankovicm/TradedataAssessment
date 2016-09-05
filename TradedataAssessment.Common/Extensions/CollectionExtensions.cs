using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace TradedataAssessment.Common.Extensions
{
    public static class CollectionExtensions
    {
        public static Dictionary<string, string> ToDictionary(this NameValueCollection col)
        {
            return col.AllKeys.ToDictionary(k => k, k => col[k]);
        }

        public static string JoinWithComma(this IEnumerable<int> value)
        {
            return string.Join(",", value);
        }

        public static string JoinWithComma(this IEnumerable<int?> value)
        {
            return string.Join(",", value);
        }
    }
}
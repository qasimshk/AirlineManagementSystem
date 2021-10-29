using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace airline.management.sharedkernal.Common
{
    public static class GlobalMethods
    {
        public static string GetValueByKey(IEnumerable<string> args, string key)
        {
            return args.Single(x => x.Contains(key)).Split('=').Last();
        }

        public static readonly CultureInfo UnitedKingdom = CultureInfo.GetCultureInfo("en-GB");
    }
}

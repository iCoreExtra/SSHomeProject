using SSHomeCommon.Constants;
using System;
using System.Configuration;

namespace SSHomeCommon.Helpers
{
    public static class ConfigHelper
    {
        public static double GetCacheExpirationTimeInHours()
        {
            double value;
            double.TryParse(ConfigurationManager.AppSettings[CommonConstant.CacheExpirationTimeInHours], out value);
            return value;
        }

        public static int GetPageSize(int page = 0)
        {
            return 10;
        }
        public static string GetApplicationErrorLogSource()
        {
            return ConfigurationManager.AppSettings[CommonConstant.ErrorLogSource];
        }
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace SSHomeCommon.Helpers
{
   public static class CacheHelper
    {
        public static void Add<T>(string key, T value)
        {
            Add<T>(key, value, ConfigHelper.GetCacheExpirationTimeInHours());
        }

        public static void Add<T>(string key, T value, double cacheExpiryInHours)
        {
            HttpContext.Current.Cache.Insert(key, value, null, DateTime.Now.AddHours(cacheExpiryInHours), Cache.NoSlidingExpiration);
        }

        public static void RemoveItem(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                HttpContext.Current.Cache.Remove(key);
            }
        }

        public static bool Exists(string key)
        {
            return !string.IsNullOrEmpty(key) && HttpContext.Current.Cache[key] != null ? true : false;
        }

        public static bool TryGet<T>(string key, out T value)
        {
            try
            {
                if (Exists(key))
                {
                    value = (T)HttpContext.Current.Cache[key];
                    return true;
                }
                else
                {
                    value = default(T);
                    return false;
                }
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
                value = default(T);
                return false;
            }
        }

    }
}

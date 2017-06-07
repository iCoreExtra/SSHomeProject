using SSHomeCommon.Constants;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeCommon.Helpers
{
    public static class ConfigHelper
    {
        public static string GetApplicationErrorLogSource()
        {
            return ConfigurationManager.AppSettings[CommonConstant.ErrorLogSource];
        }
    }
}

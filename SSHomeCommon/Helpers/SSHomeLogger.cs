using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using SSHomeCommon.Helpers;

namespace SSHomeCommon.Helpers
{
    public static class SSHomeLogger
    {
        public static void LogException(Exception exception)
        {            
            if (!EventLog.SourceExists(ConfigHelper.GetApplicationErrorLogSource()))
            {
                EventLog.CreateEventSource(ConfigHelper.GetApplicationErrorLogSource(), "Application");
            }
            EventLog.WriteEntry(ConfigHelper.GetApplicationErrorLogSource(), CreateErrorMessage(exception.ToString()), EventLogEntryType.Error, 1);            
        }

        public static void LogException(string exception)
        {
            if (!EventLog.SourceExists(ConfigHelper.GetApplicationErrorLogSource()))
            {
                EventLog.CreateEventSource(ConfigHelper.GetApplicationErrorLogSource(), "Application");
            }
            EventLog.WriteEntry(ConfigHelper.GetApplicationErrorLogSource(), CreateErrorMessage(exception), EventLogEntryType.Error, 1);
        }


        private static string CreateErrorMessage(string exception)
        {
            return string.Format("TimeStamp: {0} \nMessage: {1} \n{2}", DateTime.Now, GetExecutingMethodName(), exception);
        }

        /// <summary>
        /// Returns name of the executing method.
        /// </summary>
        /// <returns></returns>
        private static string GetExecutingMethodName()
        {
            string result = "Unknown";
            StackTrace trace = new StackTrace(false);

            for (int index = 0; index < trace.FrameCount; ++index)
            {
                StackFrame frame = trace.GetFrame(index);
                MethodBase method = frame.GetMethod();
                if (method.DeclaringType != typeof(SSHomeLogger))
                {
                    result = string.Concat(method.DeclaringType.FullName, ".", method.Name);
                    break;
                }
            }
            return result;
        }
    }
}

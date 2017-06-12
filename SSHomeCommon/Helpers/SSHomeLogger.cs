using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeCommon.Helpers
{
    public static class SSHomeLogger
    {
        public static void LogException(Exception exception)
        {
            EventLog logEntry = new EventLog();
            logEntry.Source = "SSHome.Web";
            logEntry.WriteEntry(string.Concat(GetExecutingMethodName(), "\n", exception), EventLogEntryType.Error);            
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

using System.Diagnostics;
using System.Reflection;

namespace NetCoreShortCodes.LogMethodTimming
{
    // Use this class to write custom loggers
    public static class MethodTimeLogger
    {
        //Do some custom logging here
        public static void Log(MethodBase methodBase, TimeSpan elapsed, string message)
        {
            var logMessage = $"{methodBase.DeclaringType!.Name}.{methodBase.Name} {(int)elapsed.TotalMilliseconds}ms.";

            if (!string.IsNullOrEmpty(message))
            {
                logMessage += $" {message}";
            }

            Trace.WriteLine(logMessage);
        }
    }
}
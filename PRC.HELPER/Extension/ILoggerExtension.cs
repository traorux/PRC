using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.HELPER.Extension
{
    public static class ILoggerExtension
    {
        public static void Dumper(this ILogger logger, Exception exception, string Message, LogLevel logLevel = LogLevel.Information)
        {
        //    switch (logLevel)
        //    {
        //        case LogLevel.Trace:

        //            break;
        //        case LogLevel.Debug:

        //            break;

        //        default:
        //            break;
        //    }

        //    if (logger.IsEnabled(LogLevel.Debug))
        //    {
        //        logger.LogDebug(exception, Message);
        //    }
        //    else if (logger.IsEnabled(LogLevel.Trace))
        //    {
        //        logger.LogTrace(exception, Message);
        //    }
        //    else if (logger.IsEnabled(LogLevel.Information))
        //    {
        //        logger.LogTrace(exception, Message);
        //    }
        //    else if (logger.IsEnabled(LogLevel.Information))
        //    {
        //        logger.LogTrace(exception, Message);
        //    }
        //    else if (logger.IsEnabled(LogLevel.None))
        //    {
        //        logger.LogTrace(exception, Message);
        //    }
        //    else if (logger.IsEnabled(LogLevel.Warning))
        //    {
        //        logger.LogTrace(exception, Message);
        //    }
        //    else if (logger.IsEnabled(LogLevel.Error))
        //    {
        //        logger.LogTrace(exception, Message);
        //    }
        //    else if (logger.IsEnabled(LogLevel.Critical))
        //    {
        //        logger.LogTrace(exception, Message);
        //    }
           
        }
    }
}

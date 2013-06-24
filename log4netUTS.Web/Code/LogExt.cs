using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace log4netUTS.Web
{
    public class LogExt
    {
        const string APP_ERROR = "APP_ERROR";

        static LogExt()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static log4net.ILog Log
        {
            get
            {
                return log;
            }
        }

        public static void SetError(Exception e, string category)
        {
            SetError(e, category, true);
        }

        public static void SetError(Exception e, string category, bool output)
        {
            Log.ErrorFormat("{0}\t{1}\t{2}", category, e.Message, e.StackTrace);

            if (e.InnerException != null)
            {
                Log.ErrorFormat("inner {0}\t{1}\t{2}", category, e.InnerException.Message, e.InnerException.StackTrace);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Log4netUTS.Model;
using log4netUTS.DAL;

using Smark.Data;

namespace Log4netUTS.BLL
{
    public class LogManager
    {
        public bool AddLog(List<LogEvent> logList)
        {
            using (IConnectinContext context = DBContext.Context1)
            {
                context.BeginTransaction();

                foreach (var logEvent in logList)
                {
                    Log log = new Log();
                    logEvent.MemberCopyTo(log);
                    log.ErrorTime = Convert.ToDateTime(logEvent.ErrorTime);
                    log.CreatedTime = DateTime.Now;
                    log.Save();

                    AddLogInnerException(logEvent.Errors, log.ID);
                }
                context.Commit();

                return true;
            }
        }

        public void AddLogInnerException(List<EventMessage> list,string logID)
        {
            if (list != null && list.Count > 0)
            {
                list.ForEach(e =>
                {
                    LogInnerException exception = new LogInnerException();
                    e.MemberCopyTo(exception);
                    exception.LogID = logID;
                    exception.Save();
                });
            }
        }

        public IList<LogBM> GetLogList(int pageIndex, int pageSize,out int count)
        {
            count = new Expression().Count<Log>();
            return new Expression().List<Log, LogBM>(new Region(pageIndex, pageSize), Log.createdTime.Desc);
        }
    }
}

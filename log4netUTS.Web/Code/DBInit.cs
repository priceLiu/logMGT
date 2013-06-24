using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace log4netUTS.Web
{
    public class DBInit:Smark.Data.IDBContextInithandler
    {
        public void Init()
        {
            Smark.Data.DBContext.SetConnectionDriver<log4netUTS.DAL.SqliteDriver>(Smark.Data.ConnectionType.Context1);
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[ConstMember.Config.ConnectionString].ConnectionString;
            string appPath = HttpContext.Current.Request.PhysicalApplicationPath;
        
            Smark.Data.DBContext.SetConnectionString(Smark.Data.ConnectionType.Context1, string.Format(connectionString, appPath));
            Smark.Data.DBContext.LoadEntityByAssembly(typeof(log4netUTS.DAL.SqliteDriver).Assembly);
        }
    }
}

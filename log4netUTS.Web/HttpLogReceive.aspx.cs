using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Log4netUTS.BLL;
using Log4netUTS.Model;

using Newtonsoft.Json;

namespace log4netUTS.Web
{
    public partial class HttpLogReceive : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

            string UserName =Request["UserName"] ?? string.Empty;
            string UserPwd = Request["UserPwd"] ?? string.Empty;
            string LogData =Request["LogData"] ?? string.Empty;

            try
            {
                UserManager um = new UserManager();
                if (um.CheckUser(UserName, UserPwd))
                {
                    if (!string.IsNullOrEmpty(LogData))
                    {
                        List<LogEvent> logList = JsonConvert.DeserializeObject<List<LogEvent>>(LogData);

                        if (logList != null)
                        {
                            LogManager lm = new LogManager();
                            bool result = lm.AddLog(logList);
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                LogExt.SetError(ex, "");
            }

        }
    }
}
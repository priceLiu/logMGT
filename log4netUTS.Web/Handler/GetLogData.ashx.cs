using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Log4netUTS.Model;
using Log4netUTS.BLL;
using Newtonsoft.Json;

namespace log4netUTS.Web.Handler
{
    /// <summary>
    /// GetLogData 的摘要说明
    /// </summary>
    public class GetLogData : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string strPageSize = context.Request["pageSize"] ?? string.Empty;
            string strPageIndex = context.Request["pageIndex"] ?? string.Empty;

            ActionResult data = new ActionResult() { Result = true, Message = "" };
            int intPageSize=0, intPageIndex=0;

            if (string.IsNullOrEmpty(strPageSize) || !int.TryParse(strPageSize, out intPageSize))
            {
                data.Result = false;
                data.Message = "页面尺寸格式不正确定!";
            }

            if (string.IsNullOrEmpty(strPageIndex) || !int.TryParse(strPageIndex, out intPageIndex))
            {
                data.Result = false;
                data.Message = "页面索引格式不正确定!";
            }

            if (data.Result != false)
            {
                data.Result=true;
                LogManager log = new LogManager();
                int count = 0;
                try
                {
                    data.Data = log.GetLogList(intPageIndex, intPageSize, out count);
                    data.Count = count;
                }
                catch (Exception ex)
                {
                    data.Result = false;
                    data.Message = "错误:" + ex.Message+ "  " + ex.StackTrace;
                    if (ex.InnerException != null)
                    {
                        data.Message += "\\r\\n详情:" + ex.InnerException.Message + " " + ex.InnerException.StackTrace;
                    }
                }
                
            }
            string strData = JsonConvert.SerializeObject(data);
            context.Response.Write(strData);
        }



        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
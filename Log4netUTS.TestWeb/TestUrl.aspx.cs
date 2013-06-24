using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Log4netUTS.Model;
using System.Text;
using System.Net;
using System.IO;

namespace Log4netUTS.TestWeb
{
    public partial class TestUrl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
            
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                List<LogEvent> items = new List<LogEvent>();
                items.Add(new LogEvent() { AppName = "测试发送", Message = "测试错误", ErrorType = "测试", ErrorTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), EventType = "Warning", ServerTag = Request.UserHostAddress });
                string param = string.Format("UserName={0}&UserPwd={1}&LogData={2}", "Admin", "8D70D8AB2768F232EBE874175065EAD3", Newtonsoft.Json.JsonConvert.SerializeObject(items));
                byte[] data = Encoding.UTF8.GetBytes(param);
                HttpWebRequest req =
                (HttpWebRequest)HttpWebRequest.Create(txtUrl.Text);
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = data.Length;
                using (Stream reqStream = req.GetRequestStream())
                {
                    reqStream.Write(data, 0, data.Length);
                }
                using (WebResponse wr = req.GetResponse())
                {

                }
                lbInfo.Text = "发送成功";
            }
            catch (Exception ex)
            {
                lbInfo.Text = ex.Message;
                if (ex.InnerException != null)
                {
                    lbInfo.Text += "\r\n" + ex.InnerException.StackTrace;
                }
            }
           


        }
    }
}
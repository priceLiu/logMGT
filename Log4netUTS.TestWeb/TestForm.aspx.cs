using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Log4netUTS.TestWeb
{
    public partial class TestForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                throw new Exception("测试错误");
            }
            catch (Exception ex)
            {
                LogExt.SetError(ex, "Page_Load");
            }
           
        }
    }
}
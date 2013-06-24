using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Log4netUTS.Model
{
    public class ActionResult
    {
        public bool Result { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public int Count { get; set; }
    }
}

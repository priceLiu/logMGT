using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Log4netUTS.Model
{
    public class LogBM
    {

        public string ID { get; set; }

        public string AppName { get; set; }

        public string ServerTag { get; set; }

        public string EventType { get; set; }

        public string Message { get; set; }

        public DateTime ErrorTime { get; set; }

        public string ErrorType { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}

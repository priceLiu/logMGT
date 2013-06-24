using System;
using System.Collections.Generic;
//********************************************************
// 	Copyright © henryfan 2013		 
//	Email:		henryfan@msn.com	
//	HomePage:	http://www.ikende.com		
//	CreateTime:	2013/4/19 21:23:40
//********************************************************	 
using System.Linq;
using System.Text;

namespace Log4netUTS.Model
{
    public class LogEvent
    {
        public LogEvent()
        {
            Errors = new List<EventMessage>();
        }
        public string EventType
        {
            get;
            set;
        }
        public string ServerTag
        {
            get;
            set;
        }
        public string Message
        {
            get;
            set;
        }
        public string AppName
        {
            get;
            set;
        }
        public string ErrorTime
        {
            get;
            set;
        }

        public string ErrorType { get; set; }

        public List<EventMessage> Errors
        {
            get;
            set;
        }

    }
}

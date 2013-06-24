using System;
using System.Collections.Generic;
//********************************************************
// 	Copyright © henryfan 2013		 
//	Email:		henryfan@msn.com	
//	HomePage:	http://www.ikende.com		
//	CreateTime:	2013/4/19 21:22:44
//********************************************************	 
using System.Linq;
using System.Text;
using log4net.Util;
using System.IO;
using System.Net;

using Log4netUTS.Model;

namespace log4netUTS
{
    /// <summary>
    /// <code>
    /// <appender name="HttpAppender" type="log4netUTS.HttpAppender,log4netUTS">
    ///  <param name="Host" value="http://localhost:30532/WEBFORM1.ASPX"/>
    ///  <param name="ServerTag" value="192.168.0.1"/>
    ///  <param name="AppName" value="test"/>
    ///  <param name="Timer" value="60000"/>
    ///  <param name="MaxRecords" value="1000"/>
    /// </appender>
    /// </code>
    /// </summary>
    public class HttpAppender : log4net.Appender.AppenderSkeleton
    {
        public HttpAppender()
        {
            Timer = 5000;
            MaxRecords = 300;
        }

        private System.Threading.Timer mTimer;

        private void CreateTime()
        {
            lock (this)
            {
                if (mTimer == null)
                    mTimer = new System.Threading.Timer(Upload, null, Timer, Timer);
            }
        }

        private readonly static Type declaringType = typeof(HttpAppender);

        private Queue<LogEvent> mEvents = new Queue<LogEvent>(1000);

        private void Add(LogEvent item)
        {
            CreateTime();
            lock (mEvents)
            {
                mEvents.Enqueue(item);
                if (mEvents.Count > MaxRecords)
                    Upload(null);
            }
        }

        private void Upload(object state)
        {
            List<LogEvent> items = new List<LogEvent>();
            lock (mEvents)
            {
                while (mEvents.Count > 0)
                {
                    items.Add(mEvents.Dequeue());
                }
            }
            if (items.Count > 0)
            {
                OnUpload(items);
            }
        }

        private void OnUpload(object state)
        {
            try
            {
                List<LogEvent> items = (List<LogEvent>)state;
                string param =string.Format("UserName={0}&UserPwd={1}&LogData={2}",UserName,UserPWD, Newtonsoft.Json.JsonConvert.SerializeObject(items));
                byte[] data = Encoding.UTF8.GetBytes(param);
                HttpWebRequest req =
                (HttpWebRequest)HttpWebRequest.Create(Host);
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
            }
            catch (Exception e_)
            {
                LogLog.Error(declaringType, e_.Message);
            }
        }

        public string Host
        {
            get;
            set;
        }

        public string ServerTag
        {
            get;
            set;
        }

        public string AppName
        {
            get;
            set;
        }

        public int MaxRecords
        {
            get;
            set;
        }

        public int Timer
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }
        public string UserPWD
        {
            get;
            set;
        }

        protected override void Append(log4net.Core.LoggingEvent loggingEvent)
        {
            try
            {
                LogEvent le = new LogEvent();
                le.ErrorTime =loggingEvent.TimeStamp.ToString("yyyy-MM-dd HH:mm:ss");
                le.EventType = loggingEvent.Level.ToString();
                le.Message = loggingEvent.RenderedMessage;
                le.AppName = AppName;
                le.ServerTag = ServerTag;
                le.ErrorType = loggingEvent.ExceptionObject != null ? loggingEvent.ExceptionObject.GetType().ToString() : "未知错误类型";
                AddError(le, loggingEvent.ExceptionObject);
                Add(le);


            }
            catch (Exception e_)
            {
                LogLog.Error(declaringType, e_.Message);
            }
        }

        private void AddError(LogEvent e, Exception err)
        {
            if (err != null)
            {
                e.Errors.Add(new EventMessage { Message = err.Message, StackTrace = err.StackTrace });
                err = err.InnerException;
                while (err != null)
                {
                    e.Errors.Add(new EventMessage { Message = err.Message, StackTrace = err.StackTrace });
                    err = err.InnerException;
                }
            }

        }
    }
}

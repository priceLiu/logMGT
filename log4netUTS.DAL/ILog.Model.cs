﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.296
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using Smark.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace log4netUTS.DAL {
    
    
    [Serializable()]
    [Table("log")]
    public partial class Log : Smark.Data.Mappings.DataObject, ILog {
        
        private string mID;
        
        public static Smark.Data.FieldInfo iD = new Smark.Data.FieldInfo("log", "ID");
        
        private string mAppName;
        
        public static Smark.Data.FieldInfo appName = new Smark.Data.FieldInfo("log", "AppName");
        
        private string mServerTag;
        
        public static Smark.Data.FieldInfo serverTag = new Smark.Data.FieldInfo("log", "ServerTag");
        
        private string mEventType;
        
        public static Smark.Data.FieldInfo eventType = new Smark.Data.FieldInfo("log", "EventType");
        
        private string mMessage;
        
        public static Smark.Data.FieldInfo message = new Smark.Data.FieldInfo("log", "Message");
        
        private DateTime mErrorTime;
        
        public static Smark.Data.FieldInfo errorTime = new Smark.Data.FieldInfo("log", "ErrorTime");
        
        private string mErrorType;
        
        public static Smark.Data.FieldInfo errorType = new Smark.Data.FieldInfo("log", "ErrorType");
        
        private DateTime mCreatedTime;
        
        public static Smark.Data.FieldInfo createdTime = new Smark.Data.FieldInfo("log", "CreatedTime");
        
        [ID()]
        [GUID_ID()]
        public virtual string ID {
            get {
                return this.mID;
            }
            set {
                this.mID = value;
                this.EntityState.FieldChange("ID");
            }
        }
        
        [Column("AppName")]
        public virtual string AppName {
            get {
                return this.mAppName;
            }
            set {
                this.mAppName = value;
                this.EntityState.FieldChange("AppName");
            }
        }
        
        [Column("ServerTag")]
        public virtual string ServerTag {
            get {
                return this.mServerTag;
            }
            set {
                this.mServerTag = value;
                this.EntityState.FieldChange("ServerTag");
            }
        }
        
        [Column("EventType")]
        public virtual string EventType {
            get {
                return this.mEventType;
            }
            set {
                this.mEventType = value;
                this.EntityState.FieldChange("EventType");
            }
        }
        
        [Column("Message")]
        public virtual string Message {
            get {
                return this.mMessage;
            }
            set {
                this.mMessage = value;
                this.EntityState.FieldChange("Message");
            }
        }
        
        [Column("ErrorTime")]
        [DatetimeToLong]
        public virtual DateTime ErrorTime {
            get {
                return this.mErrorTime;
            }
            set {
                this.mErrorTime = value;
                this.EntityState.FieldChange("ErrorTime");
            }
        }
        
        [Column("ErrorType")]
        public virtual string ErrorType {
            get {
                return this.mErrorType;
            }
            set {
                this.mErrorType = value;
                this.EntityState.FieldChange("ErrorType");
            }
        }
        
        [Column("CreatedTime")]
        [DatetimeToLong()]
        public virtual DateTime CreatedTime {
            get {
                return this.mCreatedTime;
            }
            set {
                this.mCreatedTime = value;
                this.EntityState.FieldChange("CreatedTime");
            }
        }
    }
}
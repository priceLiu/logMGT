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
    [Table("LogInnerException")]
    public partial class LogInnerException : Smark.Data.Mappings.DataObject, ILogInnerException {
        
        private string mID;
        
        public static Smark.Data.FieldInfo iD = new Smark.Data.FieldInfo("LogInnerException", "ID");
        
        private string mLogID;
        
        public static Smark.Data.FieldInfo logID = new Smark.Data.FieldInfo("LogInnerException", "LogID");
        
        private string mStackTrace;
        
        public static Smark.Data.FieldInfo stackTrace = new Smark.Data.FieldInfo("LogInnerException", "StackTrace");
        
        private string mMessage;
        
        public static Smark.Data.FieldInfo message = new Smark.Data.FieldInfo("LogInnerException", "Message");
        
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
        
        [Column("LogID")]
        public virtual string LogID {
            get {
                return this.mLogID;
            }
            set {
                this.mLogID = value;
                this.EntityState.FieldChange("LogID");
            }
        }
        
        [Column("StackTrace")]
        public virtual string StackTrace {
            get {
                return this.mStackTrace;
            }
            set {
                this.mStackTrace = value;
                this.EntityState.FieldChange("StackTrace");
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
    }
}

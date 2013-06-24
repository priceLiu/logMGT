using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Smark.Data.Mappings;

namespace log4netUTS.DAL
{
    [Table("log")]
    interface ILog
    {
        [ID]
        [GUID_ID]
        string ID { get; set; }

        [Column("AppName")]
        string AppName { get; set; }

        [Column("ServerTag")]
        string ServerTag { get; set; }

        [Column("EventType")]
        string EventType { get; set; }

        [Column("Message")]
        string Message { get; set; }

        [Column("ErrorTime")]
        DateTime ErrorTime { get; set; }

        [Column("ErrorType")]
        string ErrorType { get; set; }

        [Column("CreatedTime")]
        [DatetimeToLong]
        DateTime CreatedTime { get; set; }
    }
}

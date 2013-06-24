using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Smark.Data.Mappings;

namespace log4netUTS.DAL
{
    [Table("LogInnerException")]
    interface ILogInnerException
    {
        [ID]
        [GUID_ID]
        string ID { get; set; }

        [Column("LogID")]
        string LogID { get; set; }

        [Column("StackTrace")]
        string StackTrace { get; set; }

        [Column("Message")]
        string Message { get; set; }
    }
}

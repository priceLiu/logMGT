using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Smark.Data.Mappings;

namespace log4netUTS.DAL
{
    [Table("Users")]
    interface IUsers
    {
        [ID]
        [GUID_ID]
        string ID { get; set; }

        [Column("UserName")]
        string UserName { get; set; }

        [Column("Password")]
        string Password { get; set; }

        [Column("IsLocked")]
        [BoolToInt]
        bool IsLocked { get; set; }

        [Column("IsDeleted")]
        [BoolToInt]
        bool IsDeleted { get; set; }

        [Column("CreateTime")]
        [DatetimeToLong]
        DateTime CreateTime { get; set; }
    }
}

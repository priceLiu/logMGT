using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smark.Data.Mappings;
using Smark.Data;

namespace log4netUTS.DAL
{
    /// <summary>
    /// 枚举转short
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class EnumToShort : PropertyCastAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        public override object ToColumn(object value, Type ptype, object source)
        {
            return (short)value.GetHashCode();
        }
        /// <summary>
        /// 
        /// </summary>
        public override object ToProperty(object value, Type ptype, object source)
        {
            int result = Convert.ToInt16(value);
            Array values = Enum.GetValues(ptype);
            for (int i = 0; i < values.Length; i++)
            {
                if (Convert.ToInt16(values.GetValue(i)) == result)
                {
                    return values.GetValue(i);
                }
            }
            return values.GetValue(0);

        }
    }

    /// <summary>
    /// 时间转long
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class DatetimeToLong : PropertyCastAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        public override object ToColumn(object value, Type ptype, object source)
        {
            if (value != null)
            {
                DateTime result = Convert.ToDateTime(value);
                return result.Ticks;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        public override object ToProperty(object value, Type ptype, object source)
        {
            if (value != null)
            {
                long longTime = Convert.ToInt64(value);
                return new DateTime(longTime);
            }
            return DateTime.MinValue;
        }
    }


    /// <summary>
    /// 自动加密字符串
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class MD5 : PropertyCastAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        public override object ToColumn(object value, Type ptype, object source)
        {

            if (value != null)
                return Smark.Core.Functions.MD5Crypto(value.ToString());
            else
                return "";
        }
        /// <summary>
        /// 
        /// </summary>
        public override object ToProperty(object value, Type ptype, object source)
        {
            return value;
        }
    }

    /// <summary>
    /// 自动获取序列
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class GUID_ID : Smark.Data.Mappings.ValueAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        public GUID_ID() : base(false) { }
        /// <summary>
        /// 
        /// </summary>
        public override void Executed(Smark.Data.IConnectinContext cc, object data, Smark.Data.Mappings.PropertyMapper pm, string table)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public override void Executing(Smark.Data.IConnectinContext cc, object data, Smark.Data.Mappings.PropertyMapper pm, string table)
        {
            pm.Handler.Set(data, Guid.NewGuid().ToString("N"));
        }
    }
    /// <summary>
    /// 自动转为小写字母
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ToLower : Smark.Data.Mappings.PropertyCastAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        public override object ToColumn(object value, Type ptype, object source)
        {
            if (value != null)
                return value.ToString().ToLower();
            return value;
        }
        /// <summary>
        /// 
        /// </summary>
        public override object ToProperty(object value, Type ptype, object source)
        {
            if (value != null)
                return value.ToString().ToLower();
            return value;
        }
    }
    /// <summary>
    /// bool值转int
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class BoolToInt : Smark.Data.Mappings.PropertyCastAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="ptype"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public override object ToColumn(object value, Type ptype, object source)
        {
            if ((bool)value)

                return 1;

            else
                return 0;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="ptype"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public override object ToProperty(object value, Type ptype, object source)
        {
            if (value == null || value == DBNull.Value)
                return false;
            if (Convert.ToInt32(value) > 0)
                return true;
            return false;
        }
    }

    /// <summary>
    /// 将半角的单引号、双引号转换成全角的
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class FilterQuote : Smark.Data.Mappings.PropertyCastAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="ptype"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public override object ToColumn(object value, Type ptype, object source)
        {
            if (value.ToString().IndexOf("'") != -1)
            {
                value = value.ToString().Replace("'", "’");
            }
            if (value.ToString().IndexOf("\"") != -1)
            {
                value = value.ToString().Replace("\"", "”");
            }
            return value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="ptype"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public override object ToProperty(object value, Type ptype, object source)
        {
            return value;
        }
    }

    /// <summary>
    /// 将横杆 空格删除
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class FilterSpaceAndCrossBar : Smark.Data.Mappings.PropertyCastAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="ptype"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public override object ToColumn(object value, Type ptype, object source)
        {
            if (value.ToString().IndexOf(" ") != -1)
            {
                value = value.ToString().Replace(" ", "");
            }
            if (value.ToString().IndexOf("-") != -1)
            {
                value = value.ToString().Replace("-", "");
            }
            return value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="ptype"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public override object ToProperty(object value, Type ptype, object source)
        {
            return value;
        }
    }
}

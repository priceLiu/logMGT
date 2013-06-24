/*********************************************************************
 * Copyright © CN100.COM 2013
 * File: SqliteDriver.cs
 * Time: 05/02/2013 9:51:17 AM
 * Author: Squeen
 * URL:  http://www.cn100.com
 * Description:Sqlite Driver
 * History:
 * 
 * 
 *********************************************************************/

using System;
using System.Data.SQLite;

namespace log4netUTS.DAL
{
    public class SqliteDriver : Smark.Data.DriverTemplate<
    SQLiteConnection, SQLiteCommand, SQLiteDataAdapter, SQLiteParameter, Smark.Data.SqlitBuilder>
    {
        public override System.Data.IDataParameter CreateProcParameter(string name, object value, System.Data.ParameterDirection direction)
        {
            System.Data.IDataParameter dp = base.CreateProcParameter(name, value, direction);
            return dp;
        }
    }
}

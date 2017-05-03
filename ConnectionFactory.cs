using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;



namespace MyTextIndexMaker
{
    /// <summary>
    /// Connection工厂用于实例化对应的IDbConnection对象，传递给Dapper。
    /// </summary>
    public class DBFactory
    {
        private static readonly string mainConnString = ConfigurationManager.AppSettings["MainDbConnectionString"];
        private static readonly string logConnString = ConfigurationManager.AppSettings["LogDbConnectionString"];
        /// <summary>
        /// 创建生涯主站数据库连接
        /// </summary>
        /// <returns></returns>
        public static IDbConnection CreateMainSiteConnection()
        {
            IDbConnection conn = new SqlConnection(mainConnString);
            conn.Open();
            return conn;
        }

        /// <summary>
        /// 创建生涯主站日志数据库连接
        /// </summary>
        /// <returns></returns>
        public static IDbConnection CreateLogConnection()
        {
            IDbConnection conn = new SqlConnection(logConnString);
            conn.Open();
            return conn;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using XTF.Utilities;

namespace _51XuanXiao.TextIndexMaker.Common
{
    /// <summary>
    /// 数据库相关配置
    /// </summary>
    /// <remarks>
    ///  Author:         周少阳(Michael Zhou)
    ///  Description:    数据库相关配置
    ///                  
    ///  History:        2015/4/3 13:52:08 创建
    ///                  
    /// </remarks>
    internal class SqlConfig
    {

        static SqlConfig()
        {
            LoadDbConnectionString();
        }

        /// <summary>
        /// 新版主库
        /// </summary>
        internal static string StapleDbConnectionString
        {
            get;
            set;
        }
        /// <summary>
        /// 各种日志库
        /// </summary>
        internal static string LogDbConnectionString
        {
            get;
            set;
        }

        /// <summary>
        /// 加载连接字符串配置
        /// </summary>
        private static void LoadDbConnectionString()
        {
            string stapleConnStr = ConfigurationManager.AppSettings["StapleDbConnectionString"];
            StapleDbConnectionString = stapleConnStr;

            string logConnStr = ConfigurationManager.AppSettings["LogDbConnectionString"];
            LogDbConnectionString = logConnStr;

        }

    }
}

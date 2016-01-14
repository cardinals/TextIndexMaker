using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using XTF.Utilities;

namespace _51XuanXiao.TextIndexMaker.Common
{
    /// <summary>
    /// 常用的变量等
    /// </summary>
    /// <remarks>
    ///  Author:         周少阳(Michael Zhou)
    ///  Description:    常用的变量等
    ///                  
    ///  History:        2015/4/5 21:32:01 创建
    ///                  
    /// </remarks>
    public class Vars
    {

        /// <summary>
        /// 当前使用的LUCENT版本
        /// </summary>
        public static Lucene.Net.Util.Version LuceneVersion = Lucene.Net.Util.Version.LUCENE_29;

        private static string _luceneTextIndexFileDirectory;
        /// <summary>
        /// LUCENE索引保存的根目录路径
        /// </summary>
        public static string LUCENE_TEXT_INDEX_FILE_DIRECTORY
        {
            get
            {
                if (string.IsNullOrEmpty(_luceneTextIndexFileDirectory))
                {
                    string confPath = ConfigurationManager.AppSettings["LUCENE_TEXT_INDEX_FILE_DIRECTORY"];
                    if (Path.IsPathRooted(confPath))
                    {
                        _luceneTextIndexFileDirectory = confPath;
                    }
                    else
                    {
                        _luceneTextIndexFileDirectory = PathHelper.PathCombile(AppDomain.CurrentDomain.BaseDirectory, confPath);
                    }
                }
                return _luceneTextIndexFileDirectory;
            }
        }

        private static string _textIndexFileDirectory;
        /// <summary>
        /// 索引保存的根目录路径
        /// </summary>
        public static string TEXT_INDEX_FILE_DIRECTORY
        {
            get
            {
                if (string.IsNullOrEmpty(_textIndexFileDirectory))
                {
                    string confPath = ConfigurationManager.AppSettings["TEXT_INDEX_FILE_DIRECTORY"];
                    if (Path.IsPathRooted(confPath))
                    {
                        _textIndexFileDirectory = confPath;
                    }
                    else
                    {
                        _textIndexFileDirectory = PathHelper.PathCombile(AppDomain.CurrentDomain.BaseDirectory, confPath);
                    }
                }
                return _textIndexFileDirectory;
            }
        }
    }
}

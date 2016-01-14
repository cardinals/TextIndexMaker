using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;


namespace _51XuanXiao.TextIndexMaker.Common
{
    /// <summary>
    /// 项目级逻辑通用函数
    /// </summary>
    /// <remarks>
    ///  Author:         周少阳(Michael Zhou)
    ///  Description:    项目级逻辑通用函数
    ///                  
    ///  History:        2015/5/3 15:05:13 创建
    ///                  
    /// </remarks>
    public class Utilities
    {

        /// <summary>
        /// 转汉字为拼音
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ConvertToPinYin(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }
            string PYstr = "";
            foreach (char item in str.ToCharArray())
            {
                if (Microsoft.International.Converters.PinYinConverter.ChineseChar.IsValidChar(item))
                {
                    Microsoft.International.Converters.PinYinConverter.ChineseChar cc = new Microsoft.International.Converters.PinYinConverter.ChineseChar(item);

                    //PYstr += string.Join("", cc.Pinyins.ToArray());
                    PYstr += cc.Pinyins[0].Substring(0, cc.Pinyins[0].Length - 1);
                    //PYstr += cc.Pinyins[0].Substring(0, cc.Pinyins[0].Length - 1).Substring(0, 1).ToLower();
                }
                else
                {
                    PYstr += item.ToString();
                }
            }
            return PYstr;
        }


        /// <summary>
        /// 获取索引存放的分目录
        /// </summary>
        /// <param name="type"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static string GetLuceneTextIndexDirectoryPath(LuceneTextIndexType type, string parameter)
        {
            string d = string.Concat(type.ToString(), "\\");
            if (!string.IsNullOrEmpty(parameter))
            {
                d = string.Concat(d, parameter, "\\");
            }
            string p = Path.Combine(Vars.LUCENE_TEXT_INDEX_FILE_DIRECTORY, d);
            return p;
        }
        /// <summary>
        /// 获取海外大学提供的学位
        /// </summary>
        /// <param name="degree"></param>
        /// <returns></returns>
        public static string GetOverseaDegreeOffered(int degree)
        {
            string result;

            switch (degree)
            {
                case 1:
                    result = "大学本科";
                    break;
                case 2:
                    result = "硕士研究生";
                    break;
                case 3:
                    result = "大学预科";
                    break;
                case 4:
                    result = "职业技术";
                    break;
                case 5:
                    result = "博士";
                    break;
                case 6:
                    result = "MBA";
                    break;
                default:
                    result = "";
                    break;
            }

            return result;
        }


    }
}

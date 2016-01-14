using System;
using System.Collections.Generic;
using System.Text;

namespace _51XuanXiao.Common
{
    /// <summary>
    /// 临时用来存储一些院校全局数据
    /// </summary>
    /// <remarks>
    ///  Author:         周少阳(Michael Zhou)
    ///  Description:    临时用来存储一些院校全局数据,硬编码数据，之后可能会考虑存在数据库中
    ///                  
    ///  History:        2015/4/3 10:04:06 创建
    ///                  
    /// </remarks>
    public class SchoolStore
    {
        /// <summary>
        /// 
        /// </summary>
        private static object _storeLocker = new object();


        private static Dictionary<byte, string> _chinaUniversitySchoolTypes;
        /// <summary>
        /// 中国大学学校类别集合
        /// </summary>
        public static Dictionary<byte, string> ChinaUniversitySchoolTypes
        {
            get
            {
                if (_chinaUniversitySchoolTypes == null)
                {
                    lock (_storeLocker)
                    {
                        if (_chinaUniversitySchoolTypes == null)
                        {
                            _chinaUniversitySchoolTypes = new Dictionary<byte, string>();
                            _chinaUniversitySchoolTypes.Add(1, "综合类");
                            _chinaUniversitySchoolTypes.Add(2, "理工类");
                            _chinaUniversitySchoolTypes.Add(3, "财经类");
                            _chinaUniversitySchoolTypes.Add(4, "师范类");
                            _chinaUniversitySchoolTypes.Add(5, "军事类");
                            _chinaUniversitySchoolTypes.Add(6, "民族类");          
                            _chinaUniversitySchoolTypes.Add(7, "语言类");
                            _chinaUniversitySchoolTypes.Add(8, "政法类");
                            _chinaUniversitySchoolTypes.Add(9, "医药类");
                            _chinaUniversitySchoolTypes.Add(10, "艺术类");
                            _chinaUniversitySchoolTypes.Add(11, "农林类");                   
                            _chinaUniversitySchoolTypes.Add(12, "体育类");               
                        }
                    }
                }
                return _chinaUniversitySchoolTypes;
            }
        }




        private static Dictionary<byte, string> _chinaUniversityEducationLevels;
        /// <summary>
        /// 中国学校学历层次集合
        /// </summary>
        public static Dictionary<byte, string> ChinaUniversityEducationLevels
        {
            get
            {
                if (_chinaUniversityEducationLevels == null)
                {
                    lock (_storeLocker)
                    {
                        if (_chinaUniversityEducationLevels == null)
                        {
                            _chinaUniversityEducationLevels = new Dictionary<byte, string>();
                            _chinaUniversityEducationLevels.Add(1, "普通本科");
                            _chinaUniversityEducationLevels.Add(2, "独立学院");
                            _chinaUniversityEducationLevels.Add(3, "高职高专");
                            _chinaUniversityEducationLevels.Add(4, "成人教育");
                            _chinaUniversityEducationLevels.Add(5, "远程教育");
                            _chinaUniversityEducationLevels.Add(6, "中外合作办学");
                            _chinaUniversityEducationLevels.Add(7, "HND项目");
                        }
                    }
                }
                return _chinaUniversityEducationLevels;
            }
        }

        private static Dictionary<byte, string> _chinaUniversityBatches;
        public static Dictionary<byte, string> ChinaUniversityBatches
        {
            get
            {
                if (_chinaUniversityBatches == null)
                {
                    lock (_storeLocker)
                    {
                        if (_chinaUniversityBatches == null)
                        {
                            _chinaUniversityBatches = new Dictionary<byte, string>();
                            _chinaUniversityBatches.Add(1, "本科一批");
                            _chinaUniversityBatches.Add(2, "本科二批");
                            _chinaUniversityBatches.Add(3, "本科三批");
                            _chinaUniversityBatches.Add(4, "提前批");
                            _chinaUniversityBatches.Add(5, "专科");
                            _chinaUniversityBatches.Add(6, "高职高专");
                            _chinaUniversityBatches.Add(23, "本科二三批");
                        }
                    }
                }
                return _chinaUniversityBatches;
            }
        }

        private static Dictionary<int, string> _abroadSchoolLevels;
        /// <summary>
        /// 海外留学层次集合
        /// </summary>
        public static Dictionary<int, string> AbroadSchoolLevels
        {
            get
            {
                if (_abroadSchoolLevels == null)
                {
                    lock (_storeLocker)
                    {
                        if (_abroadSchoolLevels == null)
                        {
                            _abroadSchoolLevels = new Dictionary<int, string>();
                            _abroadSchoolLevels.Add(1, "本科");
                            _abroadSchoolLevels.Add(2, "研究生");
                            _abroadSchoolLevels.Add(99, "高中");
                        }
                    }
                }
                return _abroadSchoolLevels;
            }
        }


    }
}

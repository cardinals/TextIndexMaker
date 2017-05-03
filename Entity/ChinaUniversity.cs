using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MyTextIndexMaker.Entity
{
    /// <summary>
    /// 中国大学院校
    /// </summary>
    /// <remarks>
    ///  Author:         
    ///  Description:    中国大学院校
    ///                  
    ///  History:        2015/7/9 9:17:39 生成
    /// </remarks>

    public class ChinaUniversity
    {
        public const string SAMPLE_COLUMNS = "[UniversityId],[Name],[ProvinceId],[CityId],[Address],[SchoolType],[EducationLevel],[CodeNumber]";

        public const string LIST_COLUMNS = "[UniversityId],[Name],[Pinyin],[ProvinceId],[CityId],[CodeNumber],[Address],[Phone],[EMail],[WebSite],[Longitude],[Latitude],[SchoolType],[EducationLevel],[IsEdu],[Is985],[Is211],[BelongTo],[CUAARank],[WSLRank]";


        #region Constructors

       

        #endregion

        #region Columns

       
        /// <summary>
        /// 院校唯一ID
        /// </summary>

        public int UniversityId
        {
            get;
            set;
        }

      
        /// <summary>
        /// 院校名称
        /// </summary>

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Name
        {
            get;
            set;
        }

       
        /// <summary>
        /// 学校代码
        /// </summary>
         [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string CodeNumber
        {
            get;
            set;
        }

     
        /// <summary>
        /// 院校拼音
        /// </summary>

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Pinyin
        {
            get;
            set;
        }

       
        /// <summary>
        /// 院校省份
        /// </summary>

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int ProvinceId
        {
            get;
            set;
        }

       
        /// <summary>
        /// 院校城市
        /// </summary>

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int CityId
        {
            get;
            set;
        }

       
        /// <summary>
        /// 院校详细地址
        /// </summary>
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Address
        {
            get;
            set;
        }

      
        /// <summary>
        /// 联系电话
        /// </summary>

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Phone
        {
            get;
            set;
        }

    
        /// <summary>
        /// 电子邮箱
        /// </summary>

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string EMail
        {
            get;
            set;
        }

      
        /// <summary>
        /// 学校网址
        /// </summary>

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string WebSite
        {
            get;
            set;
        }

       
        /// <summary>
        /// 地理位置，经度
        /// </summary>

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public decimal Longitude
        {
            get;
            set;
        }

      
        /// <summary>
        /// 地理位置，纬度
        /// </summary>

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public decimal Latitude
        {
            get;
            set;
        }

        
        /// <summary>
        /// 学校类别(1:综合类,2:理工类,3:财经类,4:师范类,5:军事类,6:民族类,7:语言类,8:政法类,9:医药类,10:艺术类,11:农林类,12:体育类)
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public byte SchoolType
        {
            get;
            set;
        }

      
        /// <summary>
        /// 学历层次(1:普通本科,2:独立学院,3:高职高专,4:成人教育,5:远程教育)
        /// </summary>

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public byte EducationLevel
        {
            get;
            set;
        }

      
        /// <summary>
        /// 是否教育部直属
        /// </summary>

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool IsEdu
        {
            get;
            set;
        }

      
        /// <summary>
        /// 是否985工程
        /// </summary>

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool Is985
        {
            get;
            set;
        }

      
        /// <summary>
        /// 是否211工程
        /// </summary>

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool Is211
        {
            get;
            set;
        }

        
        /// <summary>
        /// 隶属单位
        /// </summary>
       [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string BelongTo
        {
            get;
            set;
        }

       
        /// <summary>
        /// 院校介绍
        /// </summary>
  
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Introduction
        {
            get;
            set;
        }

       
        /// <summary>
        /// 最新的中国校友会网排名
        /// </summary>
      
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int CUAARank
        {
            get;
            set;
        }

       
        /// <summary>
        /// 最新的武书连排名
        /// </summary>
       
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int WSLRank
        {
            get;
            set;
        }

        /// <summary>
        /// 其它属性
        /// </summary>
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Attribute
        {
            get;
            set;
        }

        /// <summary>
        /// 附件
        /// </summary>
       
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Enclosure
        {
            get;
            set;
        }
        /// <summary>
        /// 校徽
        /// </summary>
       
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string SchoolBadge
        {
            get;
            set;
        }
        #endregion

        #region IEntitySet

      

        #endregion

        #region IPrimaryKey

        public int GetKey()
        {
            return this.UniversityId;
        }

        #endregion

        

        
    }
}

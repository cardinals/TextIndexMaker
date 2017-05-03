using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace MyTextIndexMaker.Entity
{
    /// <summary>
    /// 专业
    /// </summary>

    public class Specialty 
    {
        public const string LIST_COLUMNS = "[SpecialtyId],[CategoryId],[SecondCategoryId],[Name],[Code],[Holland],[Intelligence],[SortOrder],[IsHot],[Introduction],[TrainingObjectives],[MajorCategory]";
        public const string SAMPLE_COLUMNS = "[SpecialtyId],[CategoryId],[SecondCategoryId],[Name],[Code],[SortOrder],[IsHot]";

        

        #region Columns
        /// <summary>
        /// 视频播放次数
        /// </summary>
        
        public int VideoPalyTimes
        {
            get;
            set;
        }
        /// <summary>
        /// 唯一id
        /// </summary>
       
        public int SpecialtyId
        {
            set;
            get;
        }


        /// <summary>
        /// 所属一级分类
        /// </summary>
         
        public int CategoryId
        {
            set;
            get;
        }


        /// <summary>
        /// 所属二级分类
        /// </summary>
   
        public int SecondCategoryId
        {
            set;
            get;
        }


        /// <summary>
        /// 名称
        /// </summary>
       
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Name
        {
            set;
            get;
        }

        /// <summary>
        /// 介绍
        /// </summary>
       
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Introduction
        {
            set;
            get;
        }


        /// <summary>
        /// 培养目标
        /// </summary>
  
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string TrainingObjectives
        {
            set;
            get;
        }


        /// <summary>
        /// 主要课程
        /// </summary>
 
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string MainCourses
        {
            set;
            get;
        }


        /// <summary>
        /// 就业情况
        /// </summary>
 
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string EmploymentStatus
        {
            set;
            get;
        }


        /// <summary>
        /// 专业代码
        /// </summary>
 
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Code
        {
            set;
            get;
        }


        /// <summary>
        /// 职业倾向Holland码
        /// </summary>
 
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Holland
        {
            set;
            get;
        }


        /// <summary>
        /// 职业多元智能码(例：^LM$^IR$^IE$)
        /// </summary>
 
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Intelligence
        {
            set;
            get;
        }


        /// <summary>
        /// 排序值，值越小越靠前
        /// </summary>
 
        public int SortOrder
        {
            set;
            get;
        }


        /// <summary>
        /// 是否热门专业
        /// </summary>
 
        public bool IsHot
        {
            set;
            get;
        }


        /// <summary>
        /// 文理标识(1:理科,2:文科,12:文理兼收)
        /// </summary>
 
        public int AdmissionBranch
        {
            set;
            get;
        }

        /// <summary>
        /// 修学年限
        /// </summary>
 
        public string StudyLife
        {
            set;
            get;
        }

        /// <summary>
        /// 授予学位
        /// </summary>
 
        public string Degree
        {
            set;
            get;
        }

        /// <summary>
        /// 具备能力
        /// </summary>
        public string Ability
        {
            set;
            get;
        }

        /// <summary>
        /// 实际观看人数
        /// </summary>
 
        public int RealLookCount
        {
            set;
            get;
        }

        /// <summary>
        /// 自定义观看人数
        /// </summary>
 
        public int CustomLookCount
        {
            set;
            get;
        }
        /// <summary>
        /// 专业类别：1表示本科；2表示专科
        /// </summary>
 
        public int MajorCategory
        {
            get;
            set;
        }
        #endregion

        

        

        

        

    }
}


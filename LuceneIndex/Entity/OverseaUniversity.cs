using System;
using System.Collections.Generic;
using System.Text;
using XTF.Common;
using XTF.Model;
using _51XuanXiao.TextIndexMaker.Common;
using XTF.Utilities;
using Newtonsoft.Json;

namespace _51XuanXiao.Entity
{
    /// <summary>
    /// 海外大学院校
    /// </summary>
    /// <remarks>
    ///  Author:         
    ///  Description:    海外大学院校
    ///                  
    ///  History:        2015/7/20 15:42:33 生成
    /// </remarks>
    [Serializable]
    [XDataTableAttribute(TableName = "OverseaUniversity")]
    public class OverseaUniversity : EntityBase<OverseaUniversity>
    {
        #region Constructors

        public OverseaUniversity()
        {
        }

        public OverseaUniversity(DataReaderWrap xReader)
        {
            this.SetProperty(xReader);
        }
    
        public OverseaUniversity(DataReaderWrap xReader, string fields)
        {
            this.SetProperty(xReader, fields);
        }

        #endregion

        #region Columns
		
		private int _universityId;
		/// <summary>
        /// 院校唯一ID
        /// </summary>
        [XDataColumnAttribute(Column = "UniversityId")]
        [XJSONColumnAttribute(Key = "UniversityId")]
		public int UniversityId
        {
            get
            {
                return _universityId;
            }
            set
            {
                _universityId = value;
            }
        }
		
		private string _name;
		/// <summary>
        /// 官方名称
        /// </summary>
        [XDataColumnAttribute(Column = "Name")]
        [XJSONColumnAttribute(Key = "Name")]
		public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
		
		private string _cnName;
		/// <summary>
        /// 中文名称
        /// </summary>
        [XDataColumnAttribute(Column = "CnName")]
        [XJSONColumnAttribute(Key = "CnName")]
		public string CnName
        {
            get
            {
                return _cnName;
            }
            set
            {
                _cnName = value;
            }
        }
		
		private string _pinyin;
		/// <summary>
        /// 拼音
        /// </summary>
        [XDataColumnAttribute(Column = "Pinyin")]
        [XJSONColumnAttribute(Key = "Pinyin")]
		public string Pinyin
        {
            get
            {
                return _pinyin;
            }
            set
            {
                _pinyin = value;
            }
        }
		
		private int _countryId;
		/// <summary>
        /// 国家ID
        /// </summary>
        [XDataColumnAttribute(Column = "CountryId")]
        [XJSONColumnAttribute(Key = "CountryId")]
		public int CountryId
        {
            get
            {
                return _countryId;
            }
            set
            {
                _countryId = value;
            }
        }
		
		private int _stateId;
		/// <summary>
        /// 州ID
        /// </summary>
        [XDataColumnAttribute(Column = "StateId")]
        [XJSONColumnAttribute(Key = "StateId")]
		public int StateId
        {
            get
            {
                return _stateId;
            }
            set
            {
                _stateId = value;
            }
        }
		
		private int _cityId;
		/// <summary>
        /// 城市ID
        /// </summary>
        [XDataColumnAttribute(Column = "CityId")]
        [XJSONColumnAttribute(Key = "CityId")]
		public int CityId
        {
            get
            {
                return _cityId;
            }
            set
            {
                _cityId = value;
            }
        }
		
		private string _address;
		/// <summary>
        /// 详细地址
        /// </summary>
        [XDataColumnAttribute(Column = "Address")]
        [XJSONColumnAttribute(Key = "Address")]
		public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        }
		
		private string _trafficRoutes;
		/// <summary>
        /// 
        /// </summary>
        [XDataColumnAttribute(Column = "TrafficRoutes")]
        [XJSONColumnAttribute(Key = "TrafficRoutes")]
		public string TrafficRoutes
        {
            get
            {
                return _trafficRoutes;
            }
            set
            {
                _trafficRoutes = value;
            }
        }
		
		private string _phone;
		/// <summary>
        /// 联系电话
        /// </summary>
        [XDataColumnAttribute(Column = "Phone")]
        [XJSONColumnAttribute(Key = "Phone")]
		public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
            }
        }
		
		private string _eMail;
		/// <summary>
        /// 电子邮箱
        /// </summary>
        [XDataColumnAttribute(Column = "EMail")]
        [XJSONColumnAttribute(Key = "EMail")]
		public string EMail
        {
            get
            {
                return _eMail;
            }
            set
            {
                _eMail = value;
            }
        }
		
		private string _webSite;
		/// <summary>
        /// 学校网址
        /// </summary>
        [XDataColumnAttribute(Column = "WebSite")]
        [XJSONColumnAttribute(Key = "WebSite")]
		public string WebSite
        {
            get
            {
                return _webSite;
            }
            set
            {
                _webSite = value;
            }
        }
		
		private string _admissionUrl;
		/// <summary>
        /// 招生网址
        /// </summary>
        [XDataColumnAttribute(Column = "AdmissionUrl")]
        [XJSONColumnAttribute(Key = "AdmissionUrl")]
		public string AdmissionUrl
        {
            get
            {
                return _admissionUrl;
            }
            set
            {
                _admissionUrl = value;
            }
        }
		
		private string _applyOnlineUrl;
		/// <summary>
        /// 在线申请网址
        /// </summary>
        [XDataColumnAttribute(Column = "ApplyOnlineUrl")]
        [XJSONColumnAttribute(Key = "ApplyOnlineUrl")]
		public string ApplyOnlineUrl
        {
            get
            {
                return _applyOnlineUrl;
            }
            set
            {
                _applyOnlineUrl = value;
            }
        }

        private string _financialAidUrl;
		/// <summary>
        /// 奖学金信息网址
        /// </summary>
        [XDataColumnAttribute(Column = "FinancialAidUrl")]
        [XJSONColumnAttribute(Key = "FinancialAidUrl")]
        public string FinancialAidUrl
        {
            get
            {
                return _financialAidUrl;
            }
            set
            {
                _financialAidUrl = value;
            }
        }
		
		private decimal _longitude;
		/// <summary>
        /// 地理位置，经度
        /// </summary>
        [XDataColumnAttribute(Column = "Longitude")]
        [XJSONColumnAttribute(Key = "Longitude")]
		public decimal Longitude
        {
            get
            {
                return _longitude;
            }
            set
            {
                _longitude = value;
            }
        }
		
		private decimal _latitude;
		/// <summary>
        /// 地理位置，纬度
        /// </summary>
        [XDataColumnAttribute(Column = "Latitude")]
        [XJSONColumnAttribute(Key = "Latitude")]
		public decimal Latitude
        {
            get
            {
                return _latitude;
            }
            set
            {
                _latitude = value;
            }
        }
		
		private bool _isPublic;
		/// <summary>
        /// 是否公立学校
        /// </summary>
        [XDataColumnAttribute(Column = "IsPublic")]
        [XJSONColumnAttribute(Key = "IsPublic")]
		public bool IsPublic
        {
            get
            {
                return _isPublic;
            }
            set
            {
                _isPublic = value;
            }
        }
		
		private bool _isEduCertified;
		/// <summary>
        /// 是否教育部认证
        /// </summary>
        [XDataColumnAttribute(Column = "IsEduCertified")]
        [XJSONColumnAttribute(Key = "IsEduCertified")]
		public bool IsEduCertified
        {
            get
            {
                return _isEduCertified;
            }
            set
            {
                _isEduCertified = value;
            }
        }
		
		private string _introduction;
		/// <summary>
        /// 院校介绍
        /// </summary>
        [XDataColumnAttribute(Column = "Introduction")]
        [XJSONColumnAttribute(Key = "Introduction")]
		public string Introduction
        {
            get
            {
                return _introduction;
            }
            set
            {
                _introduction = value;
            }
        }

        private bool _isUndergraduate;
        /// <summary>
        /// 是否本科学位
        /// </summary>
        [XDataColumnAttribute(Column = "IsUndergraduate")]
        [XJSONColumnAttribute(Key = "IsUndergraduate")]
        public bool IsUndergraduate
        {
            get
            {
                return _isUndergraduate;
            }
            set
            {
                _isUndergraduate = value;
            }
        }

        private bool _isMaster;
        /// <summary>
        /// 是否硕士学位
        /// </summary>
        [XDataColumnAttribute(Column = "IsMaster")]
        [XJSONColumnAttribute(Key = "IsMaster")]
        public bool IsMaster
        {
            get
            {
                return _isMaster;
            }
            set
            {
                _isMaster = value;
            }
        }

        private bool _isDoctor;
        /// <summary>
        /// 是否博士学位
        /// </summary>
        [XDataColumnAttribute(Column = "IsDoctor")]
        [XJSONColumnAttribute(Key = "IsDoctor")]
        public bool IsDoctor
        {
            get
            {
                return _isDoctor;
            }
            set
            {
                _isDoctor = value;
            }
        }
		
        private string _degreeOffered;
        /// <summary>
        /// 提供学位,英文逗号隔开(1:大学本科,2:硕士研究生,3:大学预科,4:职业技术,5:博士,6:MBA)
        /// </summary>
        [XDataColumnAttribute(Column = "DegreeOffered")]
        [XJSONColumnAttribute(Key = "DegreeOffered")]
        public string DegreeOffered
        {
            get
            {
                return _degreeOffered;
            }
            set
            {
                _degreeOffered = value;
            }
        }
		
		private int _undergraduateNumber;
		/// <summary>
        /// 本科生学生人数,-1:无数据
        /// </summary>
        [XDataColumnAttribute(Column = "UndergraduateNumber")]
        [XJSONColumnAttribute(Key = "UndergraduateNumber")]
		public int UndergraduateNumber
        {
            get
            {
                return _undergraduateNumber;
            }
            set
            {
                _undergraduateNumber = value;
            }
        }
		
		private int _postgraduateNumber;
		/// <summary>
        /// 研究生人数,-1:无数据
        /// </summary>
        [XDataColumnAttribute(Column = "PostgraduateNumber")]
        [XJSONColumnAttribute(Key = "PostgraduateNumber")]
		public int PostgraduateNumber
        {
            get
            {
                return _postgraduateNumber;
            }
            set
            {
                _postgraduateNumber = value;
            }
        }
		
		private decimal _undergraduateAdmissionRate;
		/// <summary>
        /// 本科录取率,-1:无数据
        /// </summary>
        [XDataColumnAttribute(Column = "UndergraduateAdmissionRate")]
        [XJSONColumnAttribute(Key = "UndergraduateAdmissionRate")]
		public decimal UndergraduateAdmissionRate
        {
            get
            {
                return _undergraduateAdmissionRate;
            }
            set
            {
                _undergraduateAdmissionRate = value;
            }
        }
		
		private decimal _undergraduateSchoolFee;
		/// <summary>
        /// 本科学费,-1:无数据
        /// </summary>
        [XDataColumnAttribute(Column = "UndergraduateSchoolFee")]
        [XJSONColumnAttribute(Key = "UndergraduateSchoolFee")]
		public decimal UndergraduateSchoolFee
        {
            get
            {
                return _undergraduateSchoolFee;
            }
            set
            {
                _undergraduateSchoolFee = value;
            }
        }
		
		private decimal _postgraduateSchoolFee;
		/// <summary>
        /// 研究生学费,-1:无数据
        /// </summary>
        [XDataColumnAttribute(Column = "PostgraduateSchoolFee")]
        [XJSONColumnAttribute(Key = "PostgraduateSchoolFee")]
		public decimal PostgraduateSchoolFee
        {
            get
            {
                return _postgraduateSchoolFee;
            }
            set
            {
                _postgraduateSchoolFee = value;
            }
        }
		
		private decimal _undergraduateApplyFee;
		/// <summary>
        /// 本科生申请费,-1:无数据
        /// </summary>
        [XDataColumnAttribute(Column = "UndergraduateApplyFee")]
        [XJSONColumnAttribute(Key = "UndergraduateApplyFee")]
		public decimal UndergraduateApplyFee
        {
            get
            {
                return _undergraduateApplyFee;
            }
            set
            {
                _undergraduateApplyFee = value;
            }
        }
		
		private decimal _postgraduateApplyFee;
		/// <summary>
        /// 研究生申请费,-1:无数据
        /// </summary>
        [XDataColumnAttribute(Column = "PostgraduateApplyFee")]
        [XJSONColumnAttribute(Key = "PostgraduateApplyFee")]
		public decimal PostgraduateApplyFee
        {
            get
            {
                return _postgraduateApplyFee;
            }
            set
            {
                _postgraduateApplyFee = value;
            }
        }
		
		private decimal _undergraduateTOEFL;
		/// <summary>
        /// 本科托福分数,-1:无数据
        /// </summary>
        [XDataColumnAttribute(Column = "UndergraduateTOEFL")]
        [XJSONColumnAttribute(Key = "UndergraduateTOEFL")]
		public decimal UndergraduateTOEFL
        {
            get
            {
                return _undergraduateTOEFL;
            }
            set
            {
                _undergraduateTOEFL = value;
            }
        }
		
		private decimal _postgraduateTOEFL;
		/// <summary>
        /// 研究生托福分数,-1:无数据
        /// </summary>
        [XDataColumnAttribute(Column = "PostgraduateTOEFL")]
        [XJSONColumnAttribute(Key = "PostgraduateTOEFL")]
		public decimal PostgraduateTOEFL
        {
            get
            {
                return _postgraduateTOEFL;
            }
            set
            {
                _postgraduateTOEFL = value;
            }
        }
		
		private decimal _undergraduateIELTS;
		/// <summary>
        /// 本科雅思分数,-1:无数据
        /// </summary>
        [XDataColumnAttribute(Column = "UndergraduateIELTS")]
        [XJSONColumnAttribute(Key = "UndergraduateIELTS")]
		public decimal UndergraduateIELTS
        {
            get
            {
                return _undergraduateIELTS;
            }
            set
            {
                _undergraduateIELTS = value;
            }
        }
		
		private decimal _postgraduateIELTS;
		/// <summary>
        /// 研究生雅思分数,-1:无数据
        /// </summary>
        [XDataColumnAttribute(Column = "PostgraduateIELTS")]
        [XJSONColumnAttribute(Key = "PostgraduateIELTS")]
		public decimal PostgraduateIELTS
        {
            get
            {
                return _postgraduateIELTS;
            }
            set
            {
                _postgraduateIELTS = value;
            }
        }
		
		private decimal _undergraduateGPA;
		/// <summary>
        /// 本科GPA,-1:无数据
        /// </summary>
        [XDataColumnAttribute(Column = "UndergraduateGPA")]
        [XJSONColumnAttribute(Key = "UndergraduateGPA")]
		public decimal UndergraduateGPA
        {
            get
            {
                return _undergraduateGPA;
            }
            set
            {
                _undergraduateGPA = value;
            }
        }
		
		private decimal _postgraduateGPA;
		/// <summary>
        /// 研究生GPA,-1:无数据
        /// </summary>
        [XDataColumnAttribute(Column = "PostgraduateGPA")]
        [XJSONColumnAttribute(Key = "PostgraduateGPA")]
		public decimal PostgraduateGPA
        {
            get
            {
                return _postgraduateGPA;
            }
            set
            {
                _postgraduateGPA = value;
            }
        }
		
		private DateTime _undergraduateApplyDeadline;
		/// <summary>
        /// （本科常规）申请截止日期
        /// </summary>
        [XDataColumnAttribute(Column = "UndergraduateApplyDeadline")]
        [XJSONColumnAttribute(Key = "UndergraduateApplyDeadline")]
		public DateTime UndergraduateApplyDeadline
        {
            get
            {
                return _undergraduateApplyDeadline;
            }
            set
            {
                _undergraduateApplyDeadline = value;
            }
        }
		
		private DateTime _postgraduateApplyDeadline;
		/// <summary>
        /// （研究生）申请截止日期
        /// </summary>
        [XDataColumnAttribute(Column = "PostgraduateApplyDeadline")]
        [XJSONColumnAttribute(Key = "PostgraduateApplyDeadline")]
		public DateTime PostgraduateApplyDeadline
        {
            get
            {
                return _postgraduateApplyDeadline;
            }
            set
            {
                _postgraduateApplyDeadline = value;
            }
        }
		
		private DateTime _eAUndergraduateApplyDeadline;
		/// <summary>
        /// （本科EA）申请截止日期
        /// </summary>
        [XDataColumnAttribute(Column = "EAUndergraduateApplyDeadline")]
        [XJSONColumnAttribute(Key = "EAUndergraduateApplyDeadline")]
		public DateTime EAUndergraduateApplyDeadline
        {
            get
            {
                return _eAUndergraduateApplyDeadline;
            }
            set
            {
                _eAUndergraduateApplyDeadline = value;
            }
        }
		
		private DateTime _eDUndergraduateApplyDeadline;
		/// <summary>
        /// （本科ED）申请截止日期
        /// </summary>
        [XDataColumnAttribute(Column = "EDUndergraduateApplyDeadline")]
        [XJSONColumnAttribute(Key = "EDUndergraduateApplyDeadline")]
		public DateTime EDUndergraduateApplyDeadline
        {
            get
            {
                return _eDUndergraduateApplyDeadline;
            }
            set
            {
                _eDUndergraduateApplyDeadline = value;
            }
        }
		
		private int _thamesRank;
		/// <summary>
        /// 泰晤士全球大学排名
        /// </summary>
        [XDataColumnAttribute(Column = "ThamesRank")]
        [XJSONColumnAttribute(Key = "ThamesRank")]
		public int ThamesRank
        {
            get
            {
                return _thamesRank;
            }
            set
            {
                _thamesRank = value;
            }
        }
		
		private int _sHRank;
		/// <summary>
        /// 上海交大全球大学排名
        /// </summary>
        [XDataColumnAttribute(Column = "SHRank")]
        [XJSONColumnAttribute(Key = "SHRank")]
		public int SHRank
        {
            get
            {
                return _sHRank;
            }
            set
            {
                _sHRank = value;
            }
        }
		
		private int _thamesEngRank;
		/// <summary>
        /// 泰晤士英国大学排名
        /// </summary>
        [XDataColumnAttribute(Column = "ThamesEngRank")]
        [XJSONColumnAttribute(Key = "ThamesEngRank")]
		public int ThamesEngRank
        {
            get
            {
                return _thamesEngRank;
            }
            set
            {
                _thamesEngRank = value;
            }
        }
		
		private int _ausRank;
		/// <summary>
        /// 澳洲大学科学研究排名
        /// </summary>
        [XDataColumnAttribute(Column = "AusRank")]
        [XJSONColumnAttribute(Key = "AusRank")]
		public int AusRank
        {
            get
            {
                return _ausRank;
            }
            set
            {
                _ausRank = value;
            }
        }



        private string _relCMSKeywords = string.Empty;
        /// <summary>
        /// 用来关联CMS文章的关键词
        /// </summary>
        [XDataColumnAttribute(Column = "RelCMSKeywords")]
        [XJSONColumnAttribute(Key = "RelCMSKeywords")]
        public string RelCMSKeywords
        {
            get
            {
                return _relCMSKeywords;
            }
            set
            {
                _relCMSKeywords = value;
            }
        }

        private string _cSSALink;
        /// <summary>
        /// 
        /// </summary>
        [XDataColumnAttribute(Column = "CSSALink")]
        [XJSONColumnAttribute(Key = "CSSALink")]
        public string CSSALink
        {
            get
            {
                return _cSSALink;
            }
            set
            {
                _cSSALink = value;
            }
        }

        private string _cSSAEMail;
        /// <summary>
        /// 
        /// </summary>
        [XDataColumnAttribute(Column = "CSSAEMail")]
        [XJSONColumnAttribute(Key = "CSSAEMail")]
        public string CSSAEMail
        {
            get
            {
                return _cSSAEMail;
            }
            set
            {
                _cSSAEMail = value;
            }
        }
		
        #endregion

        #region IEntitySet

        public override void SetProperty(DataReaderWrap xReader)
        {
            this.UniversityId = xReader.Get<int>("UniversityId");
            this.Name = xReader.Get<string>("Name");
            this.CnName = xReader.Get<string>("CnName");
            this.Pinyin = xReader.Get<string>("Pinyin");
            this.CountryId = xReader.Get<int>("CountryId");
            this.StateId = xReader.Get<int>("StateId");
            this.CityId = xReader.Get<int>("CityId");
            this.Address = xReader.Get<string>("Address");
            this.TrafficRoutes = xReader.Get<string>("TrafficRoutes");
            this.Phone = xReader.Get<string>("Phone");
            this.EMail = xReader.Get<string>("EMail");
            this.WebSite = xReader.Get<string>("WebSite");
            this.AdmissionUrl = xReader.Get<string>("AdmissionUrl");
            this.ApplyOnlineUrl = xReader.Get<string>("ApplyOnlineUrl");
            this.FinancialAidUrl = xReader.Get<string>("FinancialAidUrl");
            this.Longitude = xReader.Get<decimal>("Longitude");
            this.Latitude = xReader.Get<decimal>("Latitude");
            this.IsPublic = xReader.Get<bool>("IsPublic");
            this.IsEduCertified = xReader.Get<bool>("IsEduCertified");
            this.Introduction = xReader.Get<string>("Introduction");
            this.IsUndergraduate = xReader.Get<bool>("IsUndergraduate");
            this.IsMaster = xReader.Get<bool>("IsMaster");
            this.IsDoctor = xReader.Get<bool>("IsDoctor");
            this.DegreeOffered = xReader.Get<string>("DegreeOffered");

            this.UndergraduateNumber = xReader.Get<int>("UndergraduateNumber");
            this.PostgraduateNumber = xReader.Get<int>("PostgraduateNumber");
            this.UndergraduateAdmissionRate = xReader.Get<decimal>("UndergraduateAdmissionRate");
            this.UndergraduateSchoolFee = xReader.Get<decimal>("UndergraduateSchoolFee");
            this.PostgraduateSchoolFee = xReader.Get<decimal>("PostgraduateSchoolFee");
            this.UndergraduateApplyFee = xReader.Get<decimal>("UndergraduateApplyFee");
            this.PostgraduateApplyFee = xReader.Get<decimal>("PostgraduateApplyFee");
            this.UndergraduateTOEFL = xReader.Get<decimal>("UndergraduateTOEFL");
            this.PostgraduateTOEFL = xReader.Get<decimal>("PostgraduateTOEFL");
            this.UndergraduateIELTS = xReader.Get<decimal>("UndergraduateIELTS");
            this.PostgraduateIELTS = xReader.Get<decimal>("PostgraduateIELTS");
            this.UndergraduateGPA = xReader.Get<decimal>("UndergraduateGPA");
            this.PostgraduateGPA = xReader.Get<decimal>("PostgraduateGPA");
            this.UndergraduateApplyDeadline = xReader.Get<DateTime>("UndergraduateApplyDeadline");
            this.PostgraduateApplyDeadline = xReader.Get<DateTime>("PostgraduateApplyDeadline");
            this.EAUndergraduateApplyDeadline = xReader.Get<DateTime>("EAUndergraduateApplyDeadline");
            this.EDUndergraduateApplyDeadline = xReader.Get<DateTime>("EDUndergraduateApplyDeadline");
            this.ThamesRank = xReader.Get<int>("ThamesRank");
            this.SHRank = xReader.Get<int>("SHRank");
            this.ThamesEngRank = xReader.Get<int>("ThamesEngRank");
            this.AusRank = xReader.Get<int>("AusRank");

            this.RelCMSKeywords = xReader.Get<string>("RelCMSKeywords");
            this.CSSALink = xReader.Get<string>("CSSALink");
            this.CSSAEMail = xReader.Get<string>("CSSAEMail");
        }

        #endregion

        
    }
}

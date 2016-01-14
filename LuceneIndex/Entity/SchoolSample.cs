using System;
using System.Collections.Generic;
using System.Text;
using _51XuanXiao.TextIndexMaker.Common;
using _51XuanXiao.Entity;
using Newtonsoft.Json;
using XTF.Model;
using XTF.Utilities;

namespace _51XuanXiao.Model
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    ///  Author:         周少阳(Michael Zhou)
    ///  Description:    
    ///                  
    ///  History:        2015/7/31 18:08:20 创建
    ///                  
    /// </remarks>
    [Serializable]
    public class SchoolSample : ILuceneData
    {
        public SchoolSample()
        {
        }

        public SchoolSample(Lucene.Net.Documents.Document doc)
        {
            this.SetProperty(doc);
        }


        [XJSONColumnAttribute(Key = "SchoolId")]
        public int SchoolId
        {
            get;
            set;
        }

        [XJSONColumnAttribute(Key = "Type")]
        public SchoolType Type
        {
            get;
            set;
        }

        [XJSONColumnAttribute(Key = "Name")]
        public string Name
        {
            get;
            set;
        }

        [XJSONColumnAttribute(Key = "CnName")]
        public string CnName
        {
            get;
            set;
        }

        [XJSONColumnAttribute(Key = "Pinyin")]
        public string Pinyin
        {
            get;
            set;
        }

        [XJSONColumnAttribute(Key = "RegionId")]
        public int RegionId
        {
            get;
            set;
        }

        [XJSONColumnAttribute(Key = "StateId")]
        public int StateId
        {
            get;
            set;
        }

        [XJSONColumnAttribute(Key = "CityId")]
        public int CityId
        {
            get;
            set;
        }

        #region ILuceneData

        public void SetProperty(Lucene.Net.Documents.Document doc)
        {
            if (doc != null)
            {
                this.SchoolId = XConvert.ToInt32(doc.Get("SchoolId"), -1);
                this.Type = (SchoolType)XConvert.ToByte(doc.Get("Type"));
                this.Name = doc.Get("Name");
                this.CnName = doc.Get("CnName");
                this.Pinyin = doc.Get("Pinyin");
                this.RegionId = XConvert.ToInt32(doc.Get("RegionId"), -1);
                this.StateId = XConvert.ToInt32(doc.Get("StateId"), -1);
                this.CityId = XConvert.ToInt32(doc.Get("CityId"), -1);
            }
        }

        #endregion

        

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Lucene.Net;
namespace MyTextIndexMaker.Entity
{
    public class SchoolSample
    {
        #region 属性
        public int UniversityId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string CnName
        {
            get;
            set;
        }

        public string Pinyin
        {
            get;
            set;
        }

        #endregion
        public SchoolSample()
        {
        }

        public SchoolSample(Lucene.Net.Documents.Document doc)
        {
            SetProperty(doc);
        }


        public SchoolSample(ChinaUniversity school)
        {
            this.UniversityId = school.UniversityId;
            this.Name = school.Pinyin;
            this.CnName = school.Name;
            this.Pinyin = school.Pinyin;
        }

        #region ILuceneData

        public void SetProperty(Lucene.Net.Documents.Document doc)
        {
            if (doc != null)
            {
                this.UniversityId = Convert.ToInt32(doc.Get("UniversityId"));
                this.Name = doc.Get("CnName");
                this.CnName = doc.Get("CnName");
                this.Pinyin = doc.Get("Pinyin");
            }
        }

        #endregion



    }
}

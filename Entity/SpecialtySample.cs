using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Lucene.Net;
namespace MyTextIndexMaker.Entity
{
    public class SpecialtySample
    {
        #region 属性
        public int SpecialtyId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }


        #endregion
        public SpecialtySample()
        {
        }

        public SpecialtySample(Lucene.Net.Documents.Document doc)
        {
            SetProperty(doc);
        }


        public SpecialtySample(Specialty item)
        {
            this.SpecialtyId = item.SpecialtyId;
            this.Name = item.Name;
        }

        #region ILuceneData

        public void SetProperty(Lucene.Net.Documents.Document doc)
        {
            if (doc != null)
            {
                this.SpecialtyId = Convert.ToInt32(doc.Get("SpecialtyId"));
                this.Name = doc.Get("Name");
            }
        }

        #endregion



    }
}

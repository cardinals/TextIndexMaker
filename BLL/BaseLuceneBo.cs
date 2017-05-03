using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using MyLuceneTextIndexMaker;
using MyLuceneTextIndexMaker.Entity;
using MyLuceneTextIndexMaker.IBLL;
using MyTextIndexMaker.DAL;
using MyTextIndexMaker.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace MyTextIndexMaker.BLL
{
    public abstract class BaseLuceneBo
    {
        public BaseLuceneBo()
        {
            string panguConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PanGu\\PanGu.xml");
            PanGu.Segment.Init(panguConfigPath);
        }

       

    }
}
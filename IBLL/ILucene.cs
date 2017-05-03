using Lucene.Net.Documents;
using Lucene.Net.Search;
using MyLuceneTextIndexMaker.Entity;
using MyTextIndexMaker.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLuceneTextIndexMaker.IBLL
{
    public interface ILucene
    {
        /// <summary>
        /// 回调方法
        /// </summary>
        void Callback(Document indexDoc);
        /// <summary>
        /// 生成索引
        /// </summary>
        /// <param name="itemCallback"></param>
        void MakeLuceneIndex(Action<Document> callback);

    }
}

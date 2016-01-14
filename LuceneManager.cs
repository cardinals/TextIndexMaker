using System;
using System.Collections.Generic;
using System.Text;
using MyTextIndexMaker.Common;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;
using XTF.Model;

namespace MyTextIndexMaker.BLL
{
    public class LuceneManagers
    {
        public delegate void SearchLuceneDataLoopItemHandler(Document doc);



        private static List<string> _invaildWords;
        /// <summary>
        /// 
        /// </summary>
        public static List<string> InvalidWords
        {
            get
            {
                if (_invaildWords == null)
                {
                    _invaildWords = new List<string>();
                    _invaildWords.Add("of");
                    _invaildWords.Add("for");
                    _invaildWords.Add("or");
                    _invaildWords.Add("and");
                    _invaildWords.Add("in");
                    _invaildWords.Add("on");
                    _invaildWords.Add("at");
                }
                return _invaildWords;
            }
        }


        /// <summary>
        /// 非法词检验
        /// </summary>
        /// <param name="keywords"></param>
        /// <returns></returns>
        public static bool CheckIsSearchInvalidWords(string keywords)
        {
            keywords = keywords.ToLower();
            if (InvalidWords.Contains(keywords))
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// 搜索LUCENE数据
        /// </summary>
        /// <param name="indexType"></param>
        /// <param name="query"></param>
        /// <param name="sort"></param>
        /// <param name="pagerInfo"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static List<Document> SearchLuceneData(LuceneTextIndexType indexType, Query query, Sort sort, PagerInfo pagerInfo, SearchLuceneDataLoopItemHandler callback)
        {
            List<Document> list = new List<Document>();

            string textIndexDir = Utilities.GetLuceneTextIndexDirectoryPath(indexType, null);
            FSDirectory directory = FSDirectory.Open(new System.IO.DirectoryInfo(textIndexDir), new NoLockFactory());
            IndexReader indexReader = IndexReader.Open(directory, true);
            IndexSearcher indexSearcher = new IndexSearcher(indexReader);

            ScoreDoc[] docs;
            int totalCount;
            int startOffset;
            int endOffset;

            if (sort != null)
            {
                TopFieldDocs resultFieldDocs = indexSearcher.Search(query, null, indexSearcher.MaxDoc(), sort);
                totalCount = resultFieldDocs.totalHits;
                pagerInfo.RecordCount = totalCount;
                startOffset = (pagerInfo.PageIndex - 1) * pagerInfo.PageSize;
                endOffset = pagerInfo.PageIndex * pagerInfo.PageSize;
                if (endOffset >= totalCount)
                {
                    endOffset = totalCount;
                }
                docs = resultFieldDocs.scoreDocs;
            }
            else
            {
                TopDocs resultFieldDocs = indexSearcher.Search(query, null, indexSearcher.MaxDoc());
                totalCount = resultFieldDocs.totalHits;
                pagerInfo.RecordCount = totalCount;
                startOffset = (pagerInfo.PageIndex - 1) * pagerInfo.PageSize;
                endOffset = pagerInfo.PageIndex * pagerInfo.PageSize;
                if (endOffset >= totalCount)
                {
                    endOffset = totalCount;
                }
                docs = resultFieldDocs.scoreDocs;
            }

            if (totalCount > 0)
            {
                for (int i = startOffset; i < endOffset; i++)
                {
                    ScoreDoc hit = docs[i];
                    Document doc = indexSearcher.Doc(hit.doc);

                    list.Add(doc);

                    if (callback != null)
                    {
                        callback(doc);
                    }
                }
            }

            indexSearcher.Close();
            directory.Close();

            return list;
        }



    }
}

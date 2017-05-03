using Lucene.Net.Analysis.PanGu;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;
using MyLuceneTextIndexMaker.Entity;
using MyTextIndexMaker.DAL;
using MyTextIndexMaker.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyLuceneTextIndexMaker.IBLL;
namespace MyTextIndexMaker.BLL
{
    public class UniversityLuceneBo : BaseLuceneBo,ILucene
    {
        /// <summary>
        ///  回调方法
        /// </summary>
        /// <param name="indexDoc"></param>
        public  void Callback(Document indexDoc){

            Console.WriteLine("生成了{0}", indexDoc.Get("CnName"));
        
        }
        /// <summary>
        /// 生成所有索引
        /// </summary>
        /// <param name="itemCallback"></param>
        public void MakeLuceneIndex(Action<Document> callback)
        {
            #region 中国大学

                ChinaUniversityDao chinaUniverisityDao = new ChinaUniversityDao();
                List<ChinaUniversity> universityList = chinaUniverisityDao.GetChinaUniversityList();

                PanGuAnalyzer analyzer = new PanGuAnalyzer(true);

                string textIndexDir = LuceneManager.GetLuceneTextIndexDirectoryPath(LuceneTextIndexType.ChinaUniversity, null);

                List<Document> documentList = new List<Document>();
                foreach (ChinaUniversity university in universityList)
                {
                    Document indexDoc = new Document();

                    #region 根据需要添加要被索引的数据列

                    indexDoc.Add(new NumericField("UniversityId", Field.Store.YES, true).SetIntValue(university.UniversityId));
                    indexDoc.Add(new Field("CnName", university.Name.ToLower(), Field.Store.YES, Field.Index.ANALYZED));
                    indexDoc.Add(new Field("Pinyin", university.Pinyin.ToLower(), Field.Store.YES, Field.Index.ANALYZED));
                    #endregion 根据需要添加要被索引的数据列

                    documentList.Add(indexDoc);
                }
                LuceneManager.MakeIndex(documentList, textIndexDir, callback);

            #endregion 中国大学

         
        }

        public List<SchoolSample> SearchList(string keywords, PagerInfo pagerInfo)
        {
            List<SchoolSample> list = new List<SchoolSample>();

            try
            {
                BooleanQuery query = new BooleanQuery();
                if (!string.IsNullOrEmpty(keywords))
                {
                    string[] keywordsParts =keywords.Split(' ', ',');

                    foreach (string keywordsPart in keywordsParts)
                    {
                        string lowerCaseKeywordsPart = keywordsPart.ToLower();

                        BooleanQuery groupQuery = new BooleanQuery();

                        groupQuery.Add(new WildcardQuery(new Term("CnName", "*" + lowerCaseKeywordsPart + "*")), BooleanClause.Occur.SHOULD);
                        groupQuery.Add(new WildcardQuery(new Term("Pinyin", "*" + lowerCaseKeywordsPart + "*")), BooleanClause.Occur.SHOULD);

                        query.Add(groupQuery, BooleanClause.Occur.MUST);
                    }
                }



                Sort sort = null;
                string textIndexDir = LuceneManager.GetLuceneTextIndexDirectoryPath(LuceneTextIndexType.ChinaUniversity, null);

                LuceneManager.SearchLuceneData(textIndexDir, query, sort, pagerInfo, delegate(Document doc)
                {
                    SchoolSample school = new SchoolSample(doc);

                    list.Add(school);
                });
            }
            catch (Exception ex)
            {
                pagerInfo.RecordCount = 0;
            }

            return list;
        }

       
    }
}

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
    public class SpecialtyLuceneBo : BaseLuceneBo, ILucene
    {
        /// <summary>
        ///  回调方法
        /// </summary>
        /// <param name="indexDoc"></param>
        public  void Callback(Document indexDoc){

            Console.WriteLine("生成了{0}", indexDoc.Get("Name"));
        
        }
        /// <summary>
        /// 生成所有索引
        /// </summary>
        /// <param name="itemCallback"></param>
        public void MakeLuceneIndex(Action<Document> callback)
        {
            #region 大学专业

                SpecialtyDao dao = new SpecialtyDao();
                List<Specialty> list = dao.GetSpecialtyList();

                PanGuAnalyzer analyzer = new PanGuAnalyzer(true);

                string textIndexDir = LuceneManager.GetLuceneTextIndexDirectoryPath(LuceneTextIndexType.Specialty, null);

                List<Document> documentList = new List<Document>();
                foreach (Specialty item in list)
                {
                    Document indexDoc = new Document();

                    #region 根据需要添加要被索引的数据列

                    indexDoc.Add(new NumericField("SpecialtyId", Field.Store.YES, true).SetIntValue(item.SpecialtyId));
                    indexDoc.Add(new Field("Name", item.Name.ToLower(), Field.Store.YES, Field.Index.ANALYZED));
                    #endregion 根据需要添加要被索引的数据列

                    documentList.Add(indexDoc);
                }
                LuceneManager.MakeIndex(documentList, textIndexDir, callback);

            #endregion 
         
        }

        public List<SpecialtySample> SearchList(string keywords, PagerInfo pagerInfo)
        {
            List<SpecialtySample> list = new List<SpecialtySample>();

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

                        groupQuery.Add(new WildcardQuery(new Term("Name", "*" + lowerCaseKeywordsPart + "*")), BooleanClause.Occur.SHOULD);

                        query.Add(groupQuery, BooleanClause.Occur.MUST);
                    }
                }



                Sort sort = null;
                string textIndexDir = LuceneManager.GetLuceneTextIndexDirectoryPath(LuceneTextIndexType.Specialty, null);

                LuceneManager.SearchLuceneData(textIndexDir, query, sort, pagerInfo, delegate(Document doc)
                {
                    SpecialtySample item = new SpecialtySample(doc);

                    list.Add(item);
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

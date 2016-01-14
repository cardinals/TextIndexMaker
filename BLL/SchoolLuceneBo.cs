using System;
using System.Collections.Generic;
using System.Text;
using MyTextIndexMaker.Common;
using MyTextIndexMaker.DAL;
using MyTextIndexMaker.Entity;
using MyTextIndexMaker.Model;
using Lucene.Net.Analysis.PanGu;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;
using XTF.Model;
using XTF.Utilities;
using System.IO;
using System.Configuration;

namespace MyTextIndexMaker.BLL
{
    public class SchoolLuceneBo
    {
        /// <summary>
        /// 按关键词搜索学校
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="pagerInfo"></param>
        /// <returns></returns>
        public List<SchoolSample> SearchSchoolList(string keywords, PagerInfo pagerInfo)
        {
            List<SchoolSample> list = new List<SchoolSample>();

            try
            {
                BooleanQuery query = new BooleanQuery();
                if (!string.IsNullOrEmpty(keywords))
                {
                    string[] keywordsParts = StringHelper.Split<string>(keywords, StringSplitOptions.RemoveEmptyEntries, " ", ",");

                    foreach (string keywordsPart in keywordsParts)
                    {
                        string lowerCaseKeywordsPart = keywordsPart.ToLower();

                        BooleanQuery groupQuery = new BooleanQuery();
                        groupQuery.Add(new WildcardQuery(new Term("Name", "*" + keywordsPart + "*")), Lucene.Net.Search.BooleanClause.Occur.SHOULD);
                        groupQuery.Add(new WildcardQuery(new Term("CnName", "*" + keywordsPart + "*")), Lucene.Net.Search.BooleanClause.Occur.SHOULD);
                        groupQuery.Add(new WildcardQuery(new Term("Pinyin", "*" + keywordsPart + "*")), Lucene.Net.Search.BooleanClause.Occur.SHOULD);

                        groupQuery.Add(new WildcardQuery(new Term("LC_Name", "*" + lowerCaseKeywordsPart + "*")), Lucene.Net.Search.BooleanClause.Occur.SHOULD);
                        groupQuery.Add(new WildcardQuery(new Term("LC_CnName", "*" + lowerCaseKeywordsPart + "*")), Lucene.Net.Search.BooleanClause.Occur.SHOULD);
                        groupQuery.Add(new WildcardQuery(new Term("LC_Pinyin", "*" + lowerCaseKeywordsPart + "*")), Lucene.Net.Search.BooleanClause.Occur.SHOULD);

                        query.Add(groupQuery, BooleanClause.Occur.MUST);
                    }

                    Sort sort = null;

                    LuceneManager.SearchLuceneData(LuceneTextIndexType.AllSchool, query, sort, pagerInfo, delegate(Document doc)
                    {
                        SchoolSample school = new SchoolSample(doc);

                        list.Add(school);
                    });

                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                pagerInfo.RecordCount = 0;
            }

            return list;
        }

        /// <summary>
        /// 生成所有院校索引
        /// </summary>
        /// <param name="itemCallback"></param>
        public void MakeAllSchoolIndex(Action<Document> callback)
        {

            #region 所有海外大学

            string directoryPath =  ConfigurationManager.AppSettings["UNIVERTITY_INDEX_FILE_DIRECTORY"].ToString();
            OverseaUniversityDao overseaUniversityDao = new OverseaUniversityDao();
            List<OverseaUniversity> universityList = overseaUniversityDao.Backstage_GetAllUniversityList();
            List<Document> documentList = new List<Document>();
            foreach (OverseaUniversity university in universityList)
            {
                Document indexDoc = new Document();

                #region 根据需要添加要被索引的数据列
                indexDoc.Add(new Field("Key", string.Concat("OverseaUniversity_", university.UniversityId), Field.Store.YES, Field.Index.ANALYZED));
                indexDoc.Add(new NumericField("SchoolId", Field.Store.YES, true).SetIntValue(university.UniversityId));
                indexDoc.Add(new Field("Name", university.Name, Field.Store.YES, Field.Index.ANALYZED));
                indexDoc.Add(new Field("LC_Name", university.Name.ToLower(), Field.Store.NO, Field.Index.ANALYZED));
                indexDoc.Add(new Field("CnName", university.CnName, Field.Store.YES, Field.Index.ANALYZED));
                indexDoc.Add(new Field("LC_CnName", university.CnName.ToLower(), Field.Store.NO, Field.Index.ANALYZED));
                indexDoc.Add(new Field("Pinyin", university.Pinyin, Field.Store.YES, Field.Index.ANALYZED));
                indexDoc.Add(new Field("LC_Pinyin", university.Pinyin.ToLower(), Field.Store.NO, Field.Index.ANALYZED));
                #endregion

                documentList.Add(indexDoc);
                LuceneManager.MakeIndex(documentList, directoryPath, callback);

            #endregion

            }


        }
    }
}

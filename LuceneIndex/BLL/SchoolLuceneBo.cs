using System;
using System.Collections.Generic;
using System.Text;
using _51XuanXiao.TextIndexMaker.Common;
using _51XuanXiao.DAL;
using _51XuanXiao.Entity;
using _51XuanXiao.Model;
using Lucene.Net.Analysis.PanGu;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;
using XTF.Model;
using XTF.Utilities;

namespace _51XuanXiao.BLL
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    ///  Author:         周少阳(Michael Zhou)
    ///  Description:    
    ///                  
    ///  History:        2015/7/31 18:02:31 创建
    ///                  
    /// </remarks>
    public class SchoolLuceneBo : BoBase<SchoolLuceneBo>
    {

        /// <summary>
        /// 生成每项院校索引时的回调函数
        /// </summary>
        /// <param name="indexDoc"></param>
        public delegate void MakeSchoolItemIndexCallback(Document indexDoc);


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
        /// 重新生成所有院校索引
        /// </summary>
        public void MakeAllSchoolIndex()
        {
            MakeAllSchoolIndex(null);
        }
        /// <summary>
        /// 重新生成所有院校索引
        /// </summary>
        /// <param name="itemCallback"></param>
        public void MakeAllSchoolIndex(MakeSchoolItemIndexCallback itemCallback)
        {

            #region 海外大学
            try
            {
                OverseaUniversityDao overseaUniversityDao = new OverseaUniversityDao();
                List<OverseaUniversity> universityList = overseaUniversityDao.Backstage_GetAllUniversityList();

                PanGuAnalyzer analyzer = new PanGuAnalyzer(true);

                string textIndexDir = Utilities.GetLuceneTextIndexDirectoryPath(LuceneTextIndexType.AllSchool, null);
                if (!System.IO.Directory.Exists(textIndexDir))
                {
                    System.IO.Directory.CreateDirectory(textIndexDir);
                }

                Lucene.Net.Store.Directory indexDirectory = Lucene.Net.Store.FSDirectory.Open(new System.IO.DirectoryInfo(textIndexDir), new NativeFSLockFactory());
                if (IndexReader.IndexExists(indexDirectory))
                {
                    if (IndexWriter.IsLocked(indexDirectory))
                    {
                        IndexWriter.Unlock(indexDirectory);
                    }
                }
                IndexWriter indexWriter = new IndexWriter(indexDirectory, analyzer, false, Lucene.Net.Index.IndexWriter.MaxFieldLength.LIMITED);

                foreach (OverseaUniversity university in universityList)
                {
                    try
                    {
                        Document indexDoc = new Document();

                        #region 数据列
                        indexDoc.Add(new Field("Key", string.Concat("OverseaUniversity_", university.UniversityId), Field.Store.YES, Field.Index.ANALYZED));
                        indexDoc.Add(new NumericField("SchoolId", Field.Store.YES, true).SetIntValue(university.UniversityId));
                        indexDoc.Add(new NumericField("Type", Field.Store.YES, true).SetIntValue((int)SchoolType.OverseaUniversity));
                        indexDoc.Add(new Field("Name", university.Name, Field.Store.YES, Field.Index.ANALYZED));
                        indexDoc.Add(new Field("LC_Name", university.Name.ToLower(), Field.Store.NO, Field.Index.ANALYZED));
                        indexDoc.Add(new Field("CnName", university.CnName, Field.Store.YES, Field.Index.ANALYZED));
                        indexDoc.Add(new Field("LC_CnName", university.CnName.ToLower(), Field.Store.NO, Field.Index.ANALYZED));
                        indexDoc.Add(new Field("Pinyin", university.Pinyin, Field.Store.YES, Field.Index.ANALYZED));
                        indexDoc.Add(new Field("LC_Pinyin", university.Pinyin.ToLower(), Field.Store.NO, Field.Index.ANALYZED));
                        indexDoc.Add(new NumericField("RegionId", Field.Store.YES, true).SetIntValue(university.CountryId));
                        indexDoc.Add(new NumericField("StateId", Field.Store.YES, true).SetIntValue(university.StateId));
                        indexDoc.Add(new NumericField("CityId", Field.Store.YES, true).SetIntValue(university.CityId));
                        #endregion

                        indexWriter.AddDocument(indexDoc, analyzer);

                        if (itemCallback != null)
                        {
                            itemCallback(indexDoc);
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog(ex);
                    }
                }

                indexWriter.Optimize();
                indexWriter.Close();

                analyzer.Close();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
            #endregion

            

        }

    }
}

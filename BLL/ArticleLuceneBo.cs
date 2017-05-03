using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using MyLuceneTextIndexMaker;
using MyLuceneTextIndexMaker.IBLL;
using MyTextIndexMaker.DAL;
using MyTextIndexMaker.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace MyTextIndexMaker.BLL
{
    public class ArticleLuceneBo : BaseLuceneBo, ILucene
    {
        private ArticleDao dao = new ArticleDao();
        private string directoryPath = ConfigurationManager.AppSettings["UNIVERTITY_INDEX_FILE_DIRECTORY"].ToString();
        /// <summary>
        ///  回调方法
        /// </summary>
        /// <param name="indexDoc"></param>
        public void Callback(Document indexDoc)
        {

            Console.WriteLine("生成了{0}", indexDoc.Get("CnName"));

        }
        /// <summary>
        /// 生成文章索引
        /// </summary>
        /// <param name="itemCallback"></param>
        public void MakeLuceneIndex(Action<Document> callback)
        {
            List<Article> list = dao.GetArticleList();
            List<Document> documentList = new List<Document>();
            foreach (Article item in list)
            {
                Document indexDoc = new Document();

                #region 根据需要添加要被索引的数据列

                indexDoc.Add(new Field("Id", string.Concat("", item.Id), Field.Store.YES, Field.Index.ANALYZED));
                indexDoc.Add(new Field("Title", item.Title, Field.Store.YES, Field.Index.ANALYZED));
                indexDoc.Add(new Field("Content", item.Content, Field.Store.YES, Field.Index.ANALYZED));

                #endregion 根据需要添加要被索引的数据列

                documentList.Add(indexDoc);
                LuceneManager.MakeIndex(documentList, directoryPath, callback);
            }
        }

        /// <summary>
        /// 按关键词搜索文章
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="pagerInfo"></param>
        /// <returns></returns>
        public List<LuceneArticle> SearchArticleList(string keywords, PagerInfo pagerInfo)
        {

            List<LuceneArticle> list = new List<LuceneArticle>();
            BooleanQuery query = new BooleanQuery();
            if (!string.IsNullOrEmpty(keywords))
            {
                string[] keywordsParts = keywords.Split(',');//逗号分隔

                foreach (string keywordsPart in keywordsParts)
                {
                    string lowerCaseKeywordsPart = keywordsPart.ToLower();

                    BooleanQuery groupQuery = new BooleanQuery();
                    groupQuery.Add(new WildcardQuery(new Term("Id", "*" + keywordsPart + "*")),BooleanClause.Occur.SHOULD);
                    groupQuery.Add(new WildcardQuery(new Term("Title", "*" + keywordsPart + "*")), BooleanClause.Occur.SHOULD);
                    groupQuery.Add(new WildcardQuery(new Term("Content", "*" + keywordsPart + "*")), BooleanClause.Occur.SHOULD);
                    query.Add(groupQuery,BooleanClause.Occur.MUST);
                }
                Sort sort = null;
                try
                {

                    List<Document> documentList = LuceneManager.SearchLuceneData(directoryPath, query, sort, pagerInfo,null);
                    if (documentList != null && documentList.Count > 0)
                    {

                        documentList.ForEach(item => { list.Add(new LuceneArticle(item)); });
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Info(this, ex.ToString());

                    pagerInfo.RecordCount = 0;
                }
            }


            return list;
        }
    }
}
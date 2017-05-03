using Lucene.Net.Analysis;
using Lucene.Net.Analysis.PanGu;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;
using MyLuceneTextIndexMaker;
using MyLuceneTextIndexMaker.Entity;
using MyTextIndexMaker.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace MyTextIndexMaker.BLL
{
    public class LuceneManager
    {

        private static string _luceneTextIndexFileDirectory;

        private static string _textIndexFileDirectory;

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
        /// 获取索引存放的分目录
        /// </summary>
        /// <param name="type"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static string GetLuceneTextIndexDirectoryPath(LuceneTextIndexType type, string parameter)
        {
            string d = string.Concat(type.ToString(), "\\");
            if (!string.IsNullOrEmpty(parameter))
            {
                d = string.Concat(d, parameter, "\\");
            }
            string p = Path.Combine(LuceneManager.LUCENE_TEXT_INDEX_FILE_DIRECTORY, d);
            return p;
        }
        /// <summary>
        /// LUCENE索引保存的根目录路径
        /// </summary>
        public static string LUCENE_TEXT_INDEX_FILE_DIRECTORY
        {
            get
            {
                if (string.IsNullOrEmpty(_luceneTextIndexFileDirectory))
                {
                    string confPath = ConfigurationManager.AppSettings["LUCENE_TEXT_INDEX_FILE_DIRECTORY"];
                    if (Path.IsPathRooted(confPath))
                    {
                        _luceneTextIndexFileDirectory = confPath;
                    }
                    else
                    {
                        _luceneTextIndexFileDirectory =String.Concat(AppDomain.CurrentDomain.BaseDirectory, confPath);
                    }
                }
                return _luceneTextIndexFileDirectory;
            }
        }


        /// <summary>
        /// 生成LUCENE索引数据
        /// </summary>
        /// <param name="indexDocList">索引数据文档列表</param>
        /// <param name="directoryPath">索引文件路径</param>
        /// <param name="callback">回调方法</param>
        public static void MakeIndex(List<Document> indexDocList, string directoryPath, Action<Document> callback)
        {
            try
            {
                PanGuAnalyzer analyzer = new PanGuAnalyzer(true);
                string textIndexDir = directoryPath;
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
                IndexWriter indexWriter = new IndexWriter(indexDirectory, analyzer, true, Lucene.Net.Index.IndexWriter.MaxFieldLength.LIMITED);
                if (indexDocList != null && indexDocList.Count > 0)
                {
                    foreach (var item in indexDocList)
                    {
                        indexWriter.AddDocument(item, analyzer);

                        if (callback != null)
                        {
                            callback(item);
                        }
                    }
                }

                indexWriter.Optimize();
                indexWriter.Close();

                analyzer.Close();
            }
            catch (Exception ex)
            {
                LogHelper.Info(typeof(LuceneManager), ex.ToString());

            }
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
        public static List<Document> SearchLuceneData(string directoryPath, Query query, Sort sort, PagerInfo pagerInfo, Action<Document> callback)
        {
            List<Document> list = new List<Document>();

            FSDirectory directory = FSDirectory.Open(new System.IO.DirectoryInfo(directoryPath), new NoLockFactory());
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
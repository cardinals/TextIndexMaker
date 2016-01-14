using Lucene.Net.Documents;
using MyTextIndexMaker.BLL;
using MyTextIndexMaker.Entity;
using System;
using System.Collections.Generic;
using System.IO;
namespace MyLuceneTextIndexMaker
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
               
                Console.WriteLine("请选择要进行的操作");
                Console.WriteLine("输入Y，生成所有文章索引");
                Console.WriteLine("输入F，生成所有文章索引");
                Console.WriteLine("> X:关闭程序");
                string input = Console.ReadLine();
                ArticleLuceneBo luceneBo = new ArticleLuceneBo();
                if (string.Compare(input, "y", true) == 0)
                {
                    Console.WriteLine("开始执行：生成所有文章索引......");

                    string panguConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PanGu\\PanGu.xml");
                    PanGu.Segment.Init(panguConfigPath);

                    luceneBo.MakeArticleLuceneIndex(delegate(Document indexDoc)
                    {
                        Console.WriteLine("生成了文章《{0}》的索引", indexDoc.Get("Title"));
                    });
                    Console.WriteLine("索引全部生成");
                }
                else if (string.Compare(input, "F", true) == 0)
                {
                    Console.WriteLine("输入要查找的关键字，关键字用逗号分开");
                    string keyword = Console.ReadLine();

                    PagerInfo pagerInfo = new PagerInfo() { PageIndex = 1, PageSize = 10 };
                    List<LuceneArticle> list = luceneBo.SearchArticleList(keyword, pagerInfo);
                    Console.WriteLine("索引结果如下：");
                    if (list != null)
                    {
                        list.ForEach(item =>
                        {

                            Console.WriteLine(item.Content);
                        });
                    }
                }
                if (string.Compare(input, "X", true) == 0)
                {
                    Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("程序出错：{0}", ex.Message);
            }
            Console.ReadLine();

        }

    }
}
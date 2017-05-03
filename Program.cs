using Lucene.Net.Documents;
using MyLuceneTextIndexMaker.IBLL;
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
                ILucene lucene =  new UniversityLuceneBo();
                Console.WriteLine("开始生成大学索引：");
                lucene.MakeLuceneIndex(lucene.Callback);
                Console.WriteLine("索引全部生成");
                
                //string keyword = Console.ReadLine();
                //var luceneBo = lucene as UniversityLuceneBo;
                //PagerInfo pagerInfo = new PagerInfo() { PageIndex = 1, PageSize = 10 };
                //List<SchoolSample> list = luceneBo.SearchList(keyword, pagerInfo);
                //Console.WriteLine("索引结果如下：");
                //if (list != null)
                //{
                //    list.ForEach(item =>
                //    {

                //        Console.WriteLine(item.Name);
                //    });
                //}
                Console.ReadLine();

                lucene = new SpecialtyLuceneBo();

                Console.WriteLine("开始生成专业索引：");
                lucene.MakeLuceneIndex(lucene.Callback);
                Console.WriteLine("索引全部生成");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("程序出错：{0}", ex.Message);
            }
            Console.ReadLine();

        }

    }
}
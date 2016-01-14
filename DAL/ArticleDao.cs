using MyTextIndexMaker.Entity;
using System;
using System.Collections.Generic;

namespace MyTextIndexMaker.DAL
{
    public class ArticleDao
    {
        /// <summary>
        /// 模拟从数据库获取所有文章列表
        /// </summary>
        /// <returns></returns>
        public List<Article> GetArticleList()
        {
            List<Article> list = new List<Article>();
            for (int i = 0; i < 20; i++)
            {
                var item = new Article() { Id = i, Title = "ASP.NET技术架构分析系列-" + i, Content = "这里是ASP.NET技术架构分析系列-" + i + "的内容", CreateTime = DateTime.Now.AddMinutes(i) };
                list.Add(item);
            }
            return list;
        }
    }
}
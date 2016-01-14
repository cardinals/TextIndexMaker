using Lucene.Net.Documents;
using System;

namespace MyTextIndexMaker.Entity
{
    public class LuceneArticle
    {
        public LuceneArticle(Document document)
        {
            if (document != null)
            {
                this.Id = Convert.ToInt32(document.Get("Id"));
                this.Title = document.Get("Title");
                this.Content = document.Get("Content");
            }
        }

        public string Content { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
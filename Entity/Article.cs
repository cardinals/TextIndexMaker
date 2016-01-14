using System;

namespace MyTextIndexMaker.Entity
{
    public class Article
    {
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
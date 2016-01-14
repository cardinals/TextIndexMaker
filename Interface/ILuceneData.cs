namespace MyTextIndexMaker.Entity
{
    /// <summary>
    /// LUCENE数据实体接口
    /// </summary>
    /// <remarks>
    ///  Author:         周少阳(Michael Zhou)
    ///  Description:
    ///
    ///  History:        2015/5/6 11:20:02 创建
    ///
    /// </remarks>
    public interface ILuceneData
    {
        /// <summary>
        /// 实体字段赋值
        /// </summary>
        /// <param name="doc"></param>
        void SetProperty(Lucene.Net.Documents.Document doc);
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using _51XuanXiao.BLL;
using _51XuanXiao.TextIndexMaker.Common;
using _51XuanXiao.Entity;
using Lucene.Net.Analysis.PanGu;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Store;
using XTF.DataAccess;
using XTF.Utilities;

namespace _51XuanXiao.TextIndexMaker.Logic
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    ///  Author:         周少阳(Michael Zhou)
    ///  Description:    
    ///                  
    ///  History:        2015/7/31 15:07:14 创建
    ///                  
    /// </remarks>
    public class SchoolIndexMaker
    {
       

        

        

        #region 所有学校

        /// <summary>
        /// 重新生成所有院校索引
        /// </summary>
        public static void MakeAllSchoolIndex()
        {
            SchoolLuceneBo luceneBo = SchoolLuceneBo.New;

            luceneBo.MakeAllSchoolIndex(delegate(Document indexDoc)
            {
                Console.WriteLine("生成了院校索引：《{0}》", indexDoc.Get("CnName"));
            });
        }

        #endregion
    }
}

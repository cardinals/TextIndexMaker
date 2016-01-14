using System;
using System.Collections.Generic;
using System.Text;

namespace _51XuanXiao.TextIndexMaker.Common
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    ///  Author:         周少阳(Michael Zhou)
    ///  Description:    
    ///                  
    ///  History:        2015/7/31 14:54:08 创建
    ///                  
    /// </remarks>
    public class AppVars
    {

        private static Dictionary<int, string> _appActions;
        /// <summary>
        /// 程序功能
        /// </summary>
        public static Dictionary<int, string> AppActions
        {
            get
            {
                if (_appActions == null)
                {
                    _appActions = new Dictionary<int, string>();
                    _appActions.Add(100, "重新生成所有中国大学索引");
                    _appActions.Add(101, "更新指定ID的中国大学索引");
                    _appActions.Add(102, "删除指定ID的中国大学索引");

                    _appActions.Add(200, "重新生成所有美国大学索引");
                    _appActions.Add(201, "更新指定ID的美国大学索引");
                    _appActions.Add(202, "删除指定ID的美国大学索引");

                    _appActions.Add(300, "重新生成所有海外大学索引");
                    _appActions.Add(301, "更新指定ID的海外大学索引");
                    _appActions.Add(302, "删除指定ID的海外大学索引");

                    _appActions.Add(400, "重新生成所有美国高中索引");
                    _appActions.Add(401, "更新指定ID的美国高中索引");
                    _appActions.Add(402, "删除指定ID的美国高中索引");

                    _appActions.Add(500, "重新生成所有院校索引(全站院校库搜索)");
                    _appActions.Add(501, "删除指定类型指定ID的院校索引");

                    _appActions.Add(600, "重新生成所有CMS文章索引");
                    _appActions.Add(601, "更新指定ID的CMS文章索引");
                    _appActions.Add(602, "刪除指定ID的CMS文章索引");
                }
                return _appActions;
            }
        }

    }
}

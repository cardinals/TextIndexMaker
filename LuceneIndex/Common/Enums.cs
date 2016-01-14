using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// 枚举
/// </summary>
/// <remarks>
///  Author:         周少阳(Michael Zhou)
///  Description:    常用枚举
///                  
///  History:        2015/4/18 21:01:38 创建
///                  
/// </remarks>
namespace _51XuanXiao.TextIndexMaker.Common
{
    /// <summary>
    /// 数据状态（注意：数值一旦确定使用后，不能再更改）
    /// </summary>
    public enum DataOperateFlag : byte
    {
        /// <summary>
        /// 逻辑删除
        /// </summary>
        LogicDeleted = 0,
        /// <summary>
        /// 正常
        /// </summary>
        OK = 1
    }

    /// <summary>
    /// 学校数据类别（注意：数值一旦确定使用后，不能再更改）
    /// </summary>
    public enum SchoolType : byte
    {
        ChinaUniversity = 1,

        AmericaUniversity = 2,

        OverseaUniversity = 3,

        AmericaSeniorSchool = 4
    }

    /// <summary>
    /// 性别（注意：数值一旦确定使用后，不能再更改）
    /// </summary>
    public enum GenderType : byte
    {
        /// <summary>
        /// 男性
        /// </summary>
        Male = 1,
        /// <summary>
        /// 女性
        /// </summary>
        Female = 2,
        /// <summary>
        /// 未知/未设置
        /// </summary>
        Unknown = 0
    }

    /// <summary>
    /// 支付平台（注意：数值一旦确定使用后，不能再更改）
    /// </summary>
    public enum PaymentPlatform : byte
    {
        /// <summary>
        /// 支付宝
        /// </summary>
        Alipay = 1
    }

    /// <summary>
    /// 付费产品类型（注意：数值一旦确定使用后，不能再更改）
    /// </summary>
    public enum PaymentProduct : byte
    {
        Unknown = 0,
        /// <summary>
        /// 留学选校方案定制
        /// </summary>
        AbroadEvaluation = 1
    }

    /// <summary>
    /// 验证码类型（注意：数值一旦确定使用后，不能再更改）
    /// </summary>
    public enum ValidateCodeType : byte
    {
        /// <summary>
        /// 登陆验证码
        /// </summary>
        Login = 1,
        /// <summary>
        /// 注册验证码
        /// </summary>
        Register = 2,
        /// <summary>
        /// 找回密码
        /// </summary>
        FindPassword = 3,
        /// <summary>
        /// 注册领券
        /// </summary>
        SetCouponUserPassword = 10
    }

    /// <summary>
    /// LUCENE索引类型（注意：数值一旦确定使用后，不能再更改）
    /// </summary>
    public enum LuceneTextIndexType : int
    {
        /// <summary>
        /// 中国大学
        /// </summary>
        ChinaUniversity = 100,

        /// <summary>
        /// 美国大学
        /// </summary>
        AmericaUniversity = 200,

        /// <summary>
        /// 美国高中
        /// </summary>
        AmericaSeniorSchool = 300,

        /// <summary>
        /// 海外大学
        /// </summary>
        OverseaUniversity = 400,

        /// <summary>
        /// 所有院校
        /// </summary>
        AllSchool = 1000,


        /// <summary>
        /// 所有CMS文章
        /// </summary>
        AllArticle = 2000
    }

    
}

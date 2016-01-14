using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using _51XuanXiao.Entity;
using _51XuanXiao.Model;
using XTF.DataAccess;
using XTF.Model;
using XTF.Utilities;
using _51XuanXiao.TextIndexMaker.Common;


namespace _51XuanXiao.DAL
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    ///  Author:         
    ///  Description:    
    ///                  
    ///  History:        周少阳(Michael Zhou) 2015/7/15 10:52:13 创建
    ///                  
    /// </remarks>
    public class OverseaUniversityDao 
    {

        private string LIST_UNIVERSITY_TABLE_FIELDS = "[UniversityId],[Name],[CnName],[CountryId],[StateId],[CityId],[IsPublic],[IsEduCertified],[UndergraduateNumber],[PostgraduateNumber],[DegreeOffered],[UndergraduateSchoolFee],[PostgraduateSchoolFee],[UndergraduateAdmissionRate],[UndergraduateTOEFL],[PostgraduateTOEFL],[UndergraduateIELTS],[PostgraduateIELTS],[ThamesRank],[SHRank],[ThamesEngRank],[AusRank]";
        private string LIST_UNIVERSITY_PROPERTY_NAMES = "UniversityId,Name,CnName,CountryId,StateId,CityId,IsPublic,IsEduCertified,UndergraduateNumber,PostgraduateNumber,DegreeOffered,UndergraduateSchoolFee,PostgraduateSchoolFee,UndergraduateAdmissionRate,UndergraduateTOEFL,PostgraduateTOEFL,UndergraduateIELTS,PostgraduateIELTS,ThamesRank,SHRank,ThamesEngRank,AusRank";




        /// <summary>
        /// 获取所有海外大学列表
        /// </summary>
        /// <returns></returns>
        public List<OverseaUniversity> Backstage_GetAllUniversityList()
        {
            List<OverseaUniversity> universityList;
            string sql = "SELECT * FROM [OverseaUniversity]";
            using (SqlQuery query = new SqlQuery(SqlConfig.StapleDbConnectionString))
            {
                universityList = query.QueryForEntityList<OverseaUniversity>(sql);
            }

            return universityList;
        }

    }
}

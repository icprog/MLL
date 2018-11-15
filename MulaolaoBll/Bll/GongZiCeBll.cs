using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class GongZiCeBll
    {
        Dao.GongZiCeDao dao = new Dao.GongZiCeDao( );
        /// <summary>
        /// 是否存在一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists ( MulaolaoLibrary.GongZiCeLibrary model )
        {
            return dao.Exists( model );
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.GongZiCeLibrary model )
        {
            return dao.Update( model );
        }


        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add ( MulaolaoLibrary.GongZiCeLibrary model )
        {
            return dao.Add( model );
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateIdx ( MulaolaoLibrary.GongZiCeLibrary model )
        {
            return dao.UpdateIdx( model );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx )
        {
            return dao.Delete( idx );
        }

        /// <summary>
        /// 得到数据集
        /// </summary>
        /// <param name="year"></param>
        /// <param name="mouth"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableGenerate ( string year ,int mouth ,string name,string nameS ,string nameT)
        {
            return dao.GetDataTableGenerate( year ,mouth ,name ,nameS ,nameT );
        }

        /// <summary>
        /// 获取本结算年和月的所有车间主任、组长、统计员列表
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public DataTable GetDataTableGroupBy ( int year ,int month )
        {
            return dao . GetDataTableGroupBy ( year ,month );
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="year"></param>
        /// <param name="mouth"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableIdx ( string year ,int mouth ,string name,string names )
        {
            return dao.GetDataTableIdx( year ,mouth ,name ,names );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableAll ( string strWhere )
        {
            return dao.GetDataTableAll( strWhere );
        }

        /// <summary>
        /// 是否执行
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public bool ExistsReviews ( string oddNum ,string tableName )
        {
            return dao.ExistsReviews( oddNum ,tableName );
        }

        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DeleteOddNum ( string oddNum ,string idStr)
        {
            return dao.DeleteOddNum( oddNum ,idStr );
        }

        /// <summary>
        /// 删除送审记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public bool DeleteReview ( string oddNum ,string tableName )
        {
            return dao.DeleteReview( oddNum ,tableName );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableWeiHu ( string oddNum )
        {
            return dao.GetDataTableWeiHu( oddNum );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateWeiHu ( MulaolaoLibrary.GongZiCeLibrary model )
        {
            return dao.UpdateWeiHu( model );
        }

        /// <summary>
        /// 获取车间主任
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableWorkShop ( )
        {
            return dao.GetDataTableWorkShop( );
        }

        /// <summary>
        /// 获取组长
        /// </summary>
        /// <param name="workShopName"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableLeader ( )
        {
            return dao.GetDataTableLeader( );
        }

        /// <summary>
        /// 获取员工
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableLeader ( string userName )
        {
            return dao . GetDataTableLeader ( userName );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableSta ( )
        {
            return dao.GetDataTableSta( );
        }

        /// <summary>
        /// 获取生产人
        /// </summary>
        /// <param name="workShopName"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableProduction ( string workShopName )
        {
            return dao.GetDataTableProduction( workShopName );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.GongZiCeLibrary GetModel ( int idx )
        {
            return dao.GetModel( idx );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.GongZiCeLibrary GetDataRow ( System.Data.DataRow row )
        {
            return dao.GetDataRow( row );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableOnly ( )
        {
            return dao.GetDataTableOnly( );
        }

        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount ( string strWhere )
        {
            return dao.GetCount( strWhere );
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableByPage ( string strWhere ,int startIndex ,int endIndex )
        {
            return dao.GetDataTableByPage( strWhere ,startIndex ,endIndex );
        }

        /// <summary>
        /// 获取打印表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePrint ( string oddNum )
        {
            return dao.GetDataTablePrint( oddNum );
        }

        /// <summary>
        /// 获取打印表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePrints ( string oddNum )
        {
            return dao.GetDataTablePrints( oddNum );
        }

        /// <summary>
        /// 是否存在idx
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int ExistsUpIn ( MulaolaoLibrary.GongZiCeLibrary model )
        {
            return dao.ExistsUpIn( model );
        }

        /// <summary>
        /// 增加记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="year"></param>
        /// <param name="mouth"></param>
        /// <returns></returns>
        public bool ExistsTranUpdate ( MulaolaoLibrary.GongZiCeLibrary model ,string year ,int mouth )
        {
            return dao.ExistsTranUpdate( model ,year ,mouth );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="year"></param>
        /// <param name="mouth"></param>
        /// <returns></returns>
        public bool ExistsTranInsert ( MulaolaoLibrary.GongZiCeLibrary model ,string year ,int mouth )
        {
            return dao.ExistsTranInsert( model ,year ,mouth );
        }

        /// <summary>
        /// 回写317数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool UpdateWriteTo ( string strWhere )
        {
            return dao.UpdateWriteTo( strWhere );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableMdi ( string strWhere )
        {
            return dao.GetDataTableMdi( strWhere );
        }
    }
}

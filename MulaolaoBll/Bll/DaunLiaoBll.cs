using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class DaunLiaoBll
    {
        Dao.DuanLiaoDao dao = new Dao.DuanLiaoDao( );

        /// <summary>
        /// 查询流水号
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableNum ( )
        {
            return dao.GetDataTableNum( );
        }

        /// <summary>
        /// 是否执行
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool GetDataTableReviews ( string tableName ,string oddNum )
        {
            return dao.GetDataTableReviews( tableName ,oddNum );
        }

        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteAll ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.DeleteAll( oddNum , tableNum , tableName , logins , dtOne , stateOf , stateOfOdd );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Insert ( MulaolaoLibrary.DuanLiaoLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.Insert( model ,tableNum ,tableName ,logins ,dtOne  ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.DuanLiaoLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.Update( model ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd ,string oddNum )
        {
            return dao.Delete( idx ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd ,oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTable ( string strWhere )
        {
            return dao.GetDataTable( strWhere );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MulaolaoLibrary.DuanLiaoLibrary GetModel ( int id )
        {
            return dao.GetModel( id );
        }
        public MulaolaoLibrary.DuanLiaoLibrary GetModel ( string oddNum )
        {
            return dao.GetModel( oddNum );
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
        public int GetCountAll ( string strWhere )
        {
            return dao.GetCountAll( strWhere );
        }

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableByChange ( string strWhere ,int startIndex ,int endIndex )
        {
            return dao.GetDataTableByChange( strWhere ,startIndex ,endIndex );
        }
        public System.Data.DataTable GetDataTableByChangeAll ( string strWhere ,int startIndex ,int endIndex )
        {
            return dao.GetDataTableByChangeAll( strWhere ,startIndex ,endIndex );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableMain ( string oddNum )
        {
            return dao.GetDataTableMain( oddNum );
        }

        public System.Data.DataTable GetDataTableNoMain ( string oddNum,string num )
        {
            return dao.GetDataTableNoMain( oddNum ,num );
        }

        /// <summary>
        /// 编辑记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateMain ( MulaolaoLibrary.DuanLiaoLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.UpdateMain( model ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 复制一条记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Copy ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.Copy( oddNum ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }
        public bool CopyUpdate ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.CopyUpdate( oddNum ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 删出复制记录
        /// </summary>
        /// <returns></returns>
        public bool deleteCopy ( )
        {
            return dao.deleteCopy( );
        }

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsEdit ( MulaolaoLibrary.DuanLiaoLibrary model )
        {
            return dao.ExistsEdit( model );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePrint ( string oddNum )
        {
            return dao.GetDataTablePrint( oddNum );
        }
        public System.Data.DataTable GetDataTablePrints ( string oddNum )
        {
            return dao.GetDataTablePrints( oddNum );
        }

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsOf ( MulaolaoLibrary.DuanLiaoLibrary model )
        {
            return dao.ExistsOf( model );
        }

        /// <summary>
        /// 获取承揽人
        /// </summary>
        /// <returns></returns>
        public DataTable GetTableOfCl ( )
        {
            return dao.GetTableOfCl( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfReceviable ( string oddNum )
        {
            return dao.GetDataTableOfReceviable( oddNum );
        }

        /// <summary>
        /// 写数据到241
        /// </summary>
        /// <param name="modelAm"></param>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateOfReceivable ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum )
        {
            return dao.UpdateOfReceivable( modelAm ,oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable getTable ( string num )
        {
            return dao . getTable ( num );
        }

    }
}

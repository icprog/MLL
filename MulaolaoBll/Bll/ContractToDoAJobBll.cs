using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class ContractToDoAJobBll
    {
        Dao.ContractToDoAJobDao _dao = new Dao.ContractToDoAJobDao( );

        /// <summary>
        /// 获取生产车间
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableWork ( )
        {
            return _dao.GetDataTableWork( );
        }


        /// <summary>
        /// 获取业务员
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableSalesman ( )
        {
            return _dao.GetDataTableSalesman( );
        }

        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DeleteAll ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return _dao.DeleteAll(  oddNum , tableNum , tableName , logins , dtOne , stateOf , stateOfOdd );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.ContractToDoAJobLibrary _model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return _dao.Update( _model ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 复制数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Copy ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return _dao.Copy( oddNum ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 编辑复制数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateOfCopy ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return _dao.UpdateOfCopy( oddNum ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 删除复制数据
        /// </summary>
        /// <returns></returns>
        public bool DeleteOfCopy ( )
        {
            return _dao.DeleteOfCopy( );
        }

        /// <summary>
        /// 获取数据源
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfOnly ( )
        {
            return _dao.GetDataTableOfOnly( );
        }

        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount ( string strWhere )
        {
            return _dao.GetCount( strWhere );
        }

        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCounts ( string strWhere )
        {
            return _dao.GetCounts( strWhere );
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTableByChange ( string strWhere ,int startIndex ,int endIndex )
        {
            return _dao.GetDataTableByChange( strWhere ,startIndex ,endIndex );
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTableByChanges ( string strWhere ,int startIndex ,int endIndex )
        {
            return _dao.GetDataTableByChanges( strWhere ,startIndex ,endIndex );
        }


        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool Exists ( string num )
        {
            return _dao.Exists( num );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Add ( MulaolaoLibrary.ContractToDoAJobLibrary _model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string oddNum  ,string stateOf ,string stateOfOdd )
        {
            return _dao.Add( _model ,tableNum ,tableName ,logins ,dtOne ,oddNum  ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool DeleteOfOne ( int idx ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string oddNum ,string stateOf ,string stateOfOdd )
        {
            return _dao.DeleteOfOne( idx ,tableNum ,tableName ,logins ,dtOne ,oddNum ,stateOf ,stateOfOdd );
        }
        
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string strWhere )
        {
            return _dao.GetDataTable( strWhere );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ContractToDoAJobLibrary GetModel ( int idx )
        {
            return _dao.GetModel( idx );
        }
        public MulaolaoLibrary.ContractToDoAJobLibrary GetModel ( string oddNum )
        {
            return _dao.GetModel( oddNum );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool UpdateOfOne ( MulaolaoLibrary.ContractToDoAJobLibrary _model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string oddNum ,string stateOf ,string stateOfOdd )
        {
            return _dao.UpdateOfOne( _model ,tableNum ,tableName ,logins ,dtOne ,oddNum ,stateOf ,stateOfOdd );
        }


        /// <summary>
        /// 获取乙方数据
        /// </summary>
        /// <param name="B"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfB ( string B )
        {
            return _dao.GetDataTableOfB( B );
        }


        /// <summary>
        /// 获取乙方数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfB ( )
        {
            return _dao.GetDataTableOfB( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="No"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfNum ( )
        {
            return _dao.GetDataTableOfNum( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfNum ( string num ,string oddNum )
        {
            return _dao.GetDataTableOfNum( num ,oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfAll ( string oddNum )
        {
            return _dao.GetDataTableOfAll( oddNum );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrint ( string oddNum )
        {
            return _dao.GetDataTablePrint( oddNum );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrints ( string oddNum )
        {
            return _dao.GetDataTablePrints( oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfRecevable (string oddNum )
        {
            return _dao.GetDataTableOfRecevable( oddNum );
        }

        /// <summary>
        /// 写数据到241中
        /// </summary>
        /// <param name="modelAm"></param>
        /// <returns></returns>
        public bool UpdateOfRecevable ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum)
        {
            return _dao.UpdateOfRecevable( modelAm ,oddNum );
        }
    }
}

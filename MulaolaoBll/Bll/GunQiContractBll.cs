using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class GunQiContractBll
    {
        Dao.GunQiContractDao dao = new Dao.GunQiContractDao( );
        Dao.GunQiChenBenDao _dao = new Dao.GunQiChenBenDao( );

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableQuery ( string strWhere )
        {
            return dao.GetDataTableQuery( strWhere );
        }

        /// <summary>
        /// 是否存在一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists ( MulaolaoLibrary.GunQiContractLibrary model )
        {
            return dao.Exists( model );
        }

        /// <summary>
        /// 获取序号
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfSerialNum ( string oddNum )
        {
            return dao.GetDataTableOfSerialNum( oddNum );
        }

        /// <summary>
        /// 增肌一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Insert ( MulaolaoLibrary.GunQiContractLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.Insert( model ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 编辑一条
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.GunQiContractLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.Update( model ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( string serialNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd ,string oddNum )
        {
            return dao.Delete( serialNum ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd ,oddNum );
        }

        public MulaolaoLibrary.GunQiContractLibrary GetModel ( string serialNum,string oddNum )
        {
            return dao.GetModel( serialNum ,oddNum );
        }
        public MulaolaoLibrary.GunQiContractLibrary GetModel ( string oddNum )
        {
            return dao.GetModel( oddNum );
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DeleteAll ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.DeleteAll( oddNum ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 更改记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateAll ( MulaolaoLibrary.GunQiContractLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.UpdateAll( model ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableMain ( string oddNum )
        {
            return dao.GetDataTableMain( oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTableWeiHu ( string oddNum ,string num )
        {
            return dao.GetDataTableWeiHu( oddNum ,num );
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


        /// <summary>
        /// 更改复制记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateCopy ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.UpdateCopy( oddNum ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 删除复制记录
        /// </summary>
        /// <returns></returns>
        public bool DeleteCopy ( )
        {
            return dao.DeleteCopy( );
        }

        /// <summary>
        /// 获取零件名称
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable DataTablePart ( string oddNum )
        {
            return dao.DataTablePart( oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( )
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
        public int GetCounts ( string strWhere )
        {
            return dao.GetCounts( strWhere );
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTableByPage ( string strWhere ,int startIndex ,int endIndex )
        { 
            return dao.GetDataTableByPage( strWhere ,startIndex ,endIndex );
        }
        public DataTable GetDataTableByPages ( string strWhere ,int startIndex ,int endIndex )
        {
            return dao.GetDataTableByPages( strWhere ,startIndex ,endIndex );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrint ( string oddNum )
        {
            return dao.GetDataTablePrint( oddNum );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableExport ( string oddNum )
        {
            return dao.GetDataTableExport( oddNum );
        }

        /// <summary>
        /// 写入R_346
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool WriteTo ( string oddNum )
        {
            return dao.WriteTo( oddNum );
        }

        /// <summary>
        /// 获取零件名称
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfPart ( string num )
        {
            return dao.GetDataTableOfPart( num );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string num )
        {
            return dao.GetDataTable( num );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="colorNum"></param>
        /// <param name="brand"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfPqac ( string colorNum ,string brand )
        {
            return dao.GetDataTableOfPqac( colorNum ,brand );
        }

        /// <summary>
        /// 获取供应商信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableP ( )
        {
            return dao.GetDataTableP( );
        }

        /// <summary>
        /// 获取联系人
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableBusi ( )
        {
            return dao.GetDataTableBusi( );
        }

        /// <summary>
        /// 批量编辑产品数量
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool batchUpdate ( string oddNum ,long num ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.batchUpdate( oddNum ,num ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePri ( string oddNum )
        {
            return dao.GetDataTablePri( oddNum );
        }


        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableExp ( string oddNum )
        {
            return dao.GetDataTableExp( oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOther ( string oddNum )
        {
            return dao.GetDataTableOther( oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOtherTwo ( string oddNum )
        {
            return dao.GetDataTableOtherTwo( oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableTre ( string oddNum )
        {
            return dao.GetDataTableTre( oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="colorNum"></param>
        /// <param name="colorName"></param>
        /// <param name="brand"></param>
        /// <returns></returns>
        public DataTable GetDataTableStock ( string colorNum ,string colorName ,string brand )
        {
            return dao.GetDataTableStock( colorNum ,colorName ,brand );
        }

        /// <summary>
        /// 是否出库
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool ExistsOfLibrary ( string oddNum )
        {
            return dao.ExistsOfLibrary( oddNum );
        }


        /// <summary>
        /// 获取乙方
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfYf ( )
        {
            return dao.GetDataTableOfYf( );
        }

        /// <summary>
        /// 获取供应商
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfGy ( string num )
        {
            return dao.GetDataTableOfGy( num );
        }

        /// <summary>
        /// 获取数据列表   漆款
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfReceviable ( string oddNum )
        {
            return dao.GetDataTableOfReceviable( oddNum );
        }

        /// <summary>
        /// 获取数据列表  工资
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfRecevable ( string oddNum )
        {
            return dao.GetDataTableOfRecevable( oddNum );
        }

        /// <summary>
        /// 写数据到241
        /// </summary>
        /// <param name="modelAm"></param>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateOfReceviable ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum )
        {
            return dao.UpdateOfReceviable( modelAm ,oddNum );
        }

        /// <summary>
        /// 获取色号等
        /// </summary>
        /// <param name="AC18"></param>
        /// <returns></returns>
        public DataTable GetDataTableAC ( string AC18 )
        {
            return _dao . GetDataTableAC ( AC18 );
        }

        /// <summary>
        /// 获取剩余出库内容
        /// </summary>
        /// <returns></returns>
        public DataTable getAutoLibrary ( )
        {
            return dao . getAutoLibrary ( );
        }

        /// <summary>
        /// 删除入库记录
        /// </summary>
        /// <param name="ad17"></param>
        /// <returns></returns>
        public bool DeleteLibrary ( string ad17 )
        {
            return dao . DeleteLibrary ( ad17 );
        }

    }
}

using StudentMgr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class JiaomiducontractBll
    {
        Dao.JiaomiducontractDao dao = new Dao.JiaomiducontractDao( );
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTable ( string field )
        {
            return dao.GetDataTable( field );
        }


        /// <summary>
        /// 获取数据列表  采购员
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTable ( )
        {
            return dao.GetDataTable( );
        }

        /// <summary>
        /// 获取数据列表  供应商
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableJoin ( )
        {
            return dao.GetDataTableJoin( );
        }


        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strWher"></param>
        /// <returns></returns>
        public int GetJiaomiduCount ( string strWher )
        {
            return dao.GetJiaomiduCount( strWher );
        }


        /// <summary>
        /// 获取总记录数  财务结账
        /// </summary>
        /// <param name="strWher"></param>
        /// <returns></returns>
        public int GetJiaomiduCountOne ( string strWher )
        {
            return dao.GetJiaomiduCountOne( strWher );
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableByPage ( string strWhere ,string orderby ,int startIndex ,int endIndex )
        {
            return dao.GetDataTableByPage( strWhere ,orderby ,startIndex ,endIndex );
        }


        /// <summary>
        /// 分页获取数据列表   财务结账  已执行单据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableByPage ( string strWhere ,int startIndex ,int endIndex )
        {
            return dao.GetDataTableByPage( strWhere ,startIndex ,endIndex );
        }

        /// <summary>
        /// 获取打印列表  表一
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePrintOne ( string oddNum )
        {
            return dao.GetDataTablePrintOne( oddNum );
        }

        /// <summary>
        /// 获取打印列表  表二
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePrintTwo ( string oddNum )
        {
            return dao.GetDataTablePrintTwo( oddNum );
        }

        /// <summary>
        /// 是否存在一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsOne ( MulaolaoLibrary.JiaoMiDuContractLibrary model )
        {
            return dao.ExistsOne( model );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <returns></returns>
        public bool Add ( MulaolaoLibrary.JiaoMiDuContractLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne  ,string stateOf ,string stateOfOdd )
        {
            return dao.Add( model ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.JiaoMiDuContractLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.Update( model ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string oddNum ,string stateOf ,string stateOfOdd )
        {
            return dao.Delete( idx ,tableNum ,tableName ,logins ,dtOne ,oddNum ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 获取是否在入库表中存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableAcPlan ( MulaolaoLibrary.JiaoMiDuContractLibrary model )
        {
            return dao.GetDataTableAcPlan( model );
        }

        /// <summary>
        /// 获取出库表中出库数量
        /// </summary>
        /// <param name="acPlanAc18"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableAdPlan ( string acPlanAc18 )
        {
            return dao.GetDataTableAdPlan( acPlanAc18 );
        }


        /// <summary>
        /// 获取物料名称
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableNum ( string num )
        {
            return dao.GetDataTableNum( num );
        }

        /// <summary>
        /// 得到货号
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableName ( )
        {
            return dao.GetDataTableName( );
        }

        /// <summary>
        /// 获取联系人
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableProce ( )
        {
            return dao.GetDataTableProce( );
        }

        /// <summary>
        /// 获取生产车间
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableWork ( )
        {
            return dao.GetDataTableWork( );
        }

        /// <summary>
        /// 获取对比数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableContrast ( MulaolaoLibrary.JiaoMiDuContractLibrary model )
        {
            return dao.GetDataTableContrast( model );
        }

        /// <summary>
        /// //同货号、物料名称、规格是否已经开过计划订单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableYesOrNoPlan ( MulaolaoLibrary.JiaoMiDuContractLibrary model )
        {
            return dao.GetDataTableYesOrNoPlan( model );
        }

        /// <summary>
        /// 获取是否出货完毕
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableYesNoAdPlan ( string oddNum )
        {
            return dao.GetDataTableYesNoAdPlan( oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePlan ( MulaolaoLibrary.JiaoMiDuContractLibrary model )
        {
            return dao.GetDataTablePlan( model );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableDwo ( MulaolaoLibrary.JiaoMiDuContractLibrary model )
        {
            return dao.GetDataTableDwo( model );
        }

        /// <summary>
        /// 获取表
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
        /// <param name="tableNum"></param>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool ExistsReviews ( string tableNum ,string oddNum )
        {
            return dao.ExistsReviews( tableNum ,oddNum );
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool DeleteOne ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.DeleteOne( oddNum ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 删除送审记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="tableNum"></param>
        /// <returns></returns>
        public bool DeleteReview ( string oddNum ,string tableNum )
        {
            return dao.DeleteReview( oddNum ,tableNum );
        }

        /// <summary>
        /// 更改入库标记
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool EditAcs ( string oddNum )
        {
            return dao.EditAcs( oddNum );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateMain ( MulaolaoLibrary.JiaoMiDuContractLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.UpdateMain( model ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableMainTain ( string oddNum )
        {
            return dao.GetDataTableMainTain( oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableNoMain ( string oddNum )
        {
            return dao.GetDataTableNoMain( oddNum );
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
        /// 更新一条记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateCopy ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.UpdateCopy( oddNum ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <returns></returns>
        public bool DeleteCopy ( )
        {
            return dao.DeleteCopy( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.JiaoMiDuContractLibrary GetModel ( int idx )
        {
            return dao.GetModel( idx );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public MulaolaoLibrary.JiaoMiDuContractLibrary GetModel ( string oddNum )
        {
            return dao.GetModel( oddNum );
        }

        /// <summary>
        /// 获取供应商
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableSecond ( string number )
        {
            return dao.GetDataTableSecond( number );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableOther ( )
        {
            return dao.GetDataTableOther( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableTable ( string no )
        {
            return dao.GetDataTableTable( no );
        }


        /// <summary>
        /// 是否已经入库
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableStrAo ( string oddNum )
        {
            return dao.GetDataTableStr( oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableStr ( string oddNum )
        {
            return dao.GetDataTableStr( oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableAc ( string oddNum )
        {
            return dao.GetDataTableAc( oddNum );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="oddNum"></param>
        /// <param name="specification"></param>
        /// <returns></returns>
        public bool UpdateStr ( MulaolaoLibrary.JiaoMiDuContractLibrary model ,string oddNum ,string specification ,long AO004 ,decimal AO005 )
        {
            return dao.UpdateStr( model ,oddNum ,specification ,AO004 ,AO005 );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="oddNum"></param>
        /// <param name="specification"></param>
        /// <param name="AO004"></param>
        /// <param name="AO005"></param>
        /// <returns></returns>
        public bool UpdateInsertAcTran ( MulaolaoLibrary.JiaoMiDuContractLibrary model ,string oddNum ,string specification ,long AO004 ,decimal AO005 )
        {
            return dao.UpdateInsertAcTran( model ,oddNum ,specification ,AO004 ,AO005 );
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="jm109"></param>
        /// <param name="jm110"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool UpdateLastTime ( long jm109 ,decimal jm110 ,int idx )
        {
            return dao.UpdateLastTime( jm109 ,jm110 ,idx );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateBatch ( MulaolaoLibrary.JiaoMiDuContractLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.UpdateBatch( model ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }


        /// <summary>
        /// 入库标志更改
        /// </summary>
        /// <returns></returns>
        public bool signOfStorage ( )
        {
            return dao.signOfStorage( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfPrice ( string numOf,string nameOf,decimal lon,decimal wicth,decimal high )
        {
            return dao.GetDataTableOfPrice( numOf ,nameOf ,lon ,wicth ,high );
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
        /// <returns></returns>
        public bool UpdateOfReceviable ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum )
        {
            return dao.UpdateOfReceviable( modelAm ,oddNum );
        }

        /// <summary>
        /// 是否存在库存
        /// </summary>
        /// <param name="num"></param>
        /// <param name="name"></param>
        /// <param name="spe"></param>
        /// <returns></returns>
        public decimal getSurNum ( string num ,string name ,string spe )
        {
            return dao . getSurNum ( num ,name ,spe );
        }

    }
}

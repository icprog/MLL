using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Dao
{
    
    public class ChanPinZhiBaoDao
    {
        Bll.ChanPinZhiBaoBll bll = new Bll.ChanPinZhiBaoBll( );


        /// <summary>
        /// 获取打印数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintOne ( string oddNum )
        {
            return bll.GetDataTablePrintOne( oddNum );
        }

        /// <summary>
        /// 获取打印数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintTwo ( string oddNum )
        {
            return bll.GetDataTablePrintTwo( oddNum );
        }

        /// <summary>
        /// 获取联系人
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableCon ( )
        {
            return bll.GetDataTableCon( );
        }

        /// <summary>
        /// 获取生产车间
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableWork ( )
        {
            return bll.GetDataTableWork( );
        }

        /// <summary>
        /// 获取流水信息
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableNum ( )
        {
            return bll.GetDataTableNum( );
        }

        /// <summary>
        /// 获取509信息
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePqp ( )
        {
            return bll.GetDataTablePqp( );
        }

        /// <summary>
        /// 获取数据列表  单个字段
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( string field )
        {
            return bll.GetDataTableOnly( field );
        }
        public System.Data.DataTable GetDataTableOnly ( )
        {
            return bll.GetDataTableOnly( );
        }


        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetChanPinZhiBaoCount (string strWhere )
        {
            return bll.GetChanPinZhiBaoCount( strWhere );
        }


        /// <summary>
        /// 获取总记录数  财务结账
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetChanPinZhiBaoCountOne ( string strWhere )
        {
            return bll.GetChanPinZhiBaoCountOne( strWhere );
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
            return bll.GetDataTableByPage( strWhere ,orderby ,startIndex ,endIndex );
        }


        /// <summary>
        /// 分页获取数据列表  财务结账   已执行单据  且没有完全结账
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableByPage ( string strWhere ,int startIndex ,int endIndex )
        {
            return bll.GetDataTableByPage( strWhere ,startIndex ,endIndex );
        }


        /// <summary>
        /// 是否存在一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists ( MulaolaoLibrary.ChanPinZhiBiaoLibrary model )
        {
            return bll.Exists( model );
        }


        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add ( MulaolaoLibrary.ChanPinZhiBiaoLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return bll.Add( model ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.ChanPinZhiBiaoLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return bll.Update( model ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 批量编辑数量
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateBatch ( MulaolaoLibrary.ChanPinZhiBiaoLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return bll.UpdateBatch( model ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string oddNum ,string stateOf ,string stateOfOdd )
        {
            return bll.Delete( idx ,tableNum ,tableName ,logins ,dtOne ,oddNum ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DeleteOddNum ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return bll.DeleteOddNum( oddNum ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTable ( string strWhere )
        {
            return bll.GetDataTable( strWhere );
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ChanPinZhiBiaoLibrary GetModel ( int idx )
        {
            return bll.GetModel( idx );
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ChanPinZhiBiaoLibrary GetDataRow ( DataRow row )
        {
            return bll.GetDataRow( row );
        }


        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ChanPinZhiBiaoLibrary GetMo ( string oddNum )
        {
            return bll.GetMo( oddNum );
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ChanPinZhiBiaoLibrary GetDataR ( DataRow row )
        {
            return bll.GetDataR( row );
        }

        /// <summary>
        /// 是否已经送审
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="formText"></param>
        /// <returns></returns>
        public bool ExistsReview ( string oddNum ,string formText )
        {
            return bll.ExistsReview( oddNum ,formText );
        }

        /// <summary>
        /// 删除送审记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="tableNum"></param>
        /// <returns></returns>
        public bool DeleteReview ( string oddNum ,string tableNum )
        {
            return bll.DeleteReview( oddNum ,tableNum );
        }

        /// <summary>
        /// 更新维护意见
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateWeiHu ( MulaolaoLibrary.ChanPinZhiBiaoLibrary model )
        {
            return bll.UpdateWeiHu( model );
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableAll ( string oddNum )
        {
            return bll.GetDataTableAll( oddNum );
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableCopy ( string oddNum )
        {
            return bll.GetDataTableCopy( oddNum );
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateOther ( MulaolaoLibrary.ChanPinZhiBiaoLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return bll.UpdateOther( model ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 是否复制成功
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateCopy ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return bll.UpdateCopy( oddNum ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }


        /// <summary>
        /// 删除复制失败数据
        /// </summary>
        public bool DeleteCopy ( )
        {
            return bll.DeleteCopy( );
        }


        /// <summary>
        /// 是否更改复制单号成功
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateCopyUp ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return bll.UpdateCopyUp( oddNum ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 获取供应商
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfSupplier ( )
        {
            return bll.GetDataTableOfSupplier( );
        }

        /// <summary>
        /// 获取供应商
        /// </summary>
        /// <param name="supplierNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfSu ( string supplierNum )
        {
            return bll.GetDataTableOfSu( supplierNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable receivableOf ( string oddNum )
        {
            return bll.receivableOf( oddNum );
        }

        /// <summary>
        /// 写应收款到241
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateOfOutSource ( MulaolaoLibrary.ProductCostSummaryLibrary model ,string oper )
        {
            return bll . UpdateOfOutSource ( model ,oper );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable receivableOfOther ( string oddNum )
        {
            return bll.receivableOfOther( oddNum );
        }


        /// <summary>
        /// 写应收款到241
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateOfOther ( MulaolaoLibrary.ProductCostSummaryLibrary model ,string oper  )
        {
            return bll.UpdateOfOther( model ,oper );
        }
    }
}

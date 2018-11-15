using StudentMgr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
   public class SiReYiYincontractBll
    {
        Dao.SiReYiYincontractDao dao = new Dao.SiReYiYincontractDao( );

        /// <summary>
        /// 获取数据列表  单个字段
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTable ( string field )
        {
            return dao.GetDataTable( field );
        }
        public DataTable GetDataTable ( )
        {
            return dao.GetDataTable( );
        }

        /// <summary>
        ///获取总记录数 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetSiReYiYinCount ( string strWhere )
        {
            return dao.GetSiReYiYinCount( strWhere );
        }


        /// <summary>
        ///获取总记录数 财务结账
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetSiReYiYinCountOne ( string strWhere )
        {
            return dao.GetSiReYiYinCountOne( strWhere );
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
        /// 分页获取数据列表    执行单据  且没结账
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
        /// 获取联系人
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableCont ( )
        {
            return dao.GetDataTableCont( );
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
        /// 是否存在记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsAdd ( MulaolaoLibrary.SiReYiYinContractLibrary model )
        {
            return dao.ExistsAdd( model );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add ( MulaolaoLibrary.SiReYiYinContractLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.Add( model ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.SiReYiYinContractLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.Update( model , tableNum , tableName , logins , dtOne , stateOf , stateOfOdd );
        }

        /// <summary>
        /// 批量编辑数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateBatch ( MulaolaoLibrary.SiReYiYinContractLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.UpdateBatch( model ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd ,string oddNum )
        {
            return dao.Delete( idx , tableNum , tableName , logins , dtOne , stateOf , stateOfOdd , oddNum );
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
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableTable ( string strWhere )
        {
            return dao.GetDataTableTable( strWhere );
        }

        /// <summary>
        /// 获取数据列表  打印表1
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePrintOne ( string oddNum )
        {
            return dao.GetDataTablePrintOne( oddNum );
        }

        /// <summary>
        /// 获取数据列表  打印表2
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePrintTwo ( string oddNum )
        {
            return dao.GetDataTablePrintTwo( oddNum );
        }

        /// <summary>
        /// 获取数据列表  查询流水信息
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableNum ( )
        {
            return dao.GetDataTableNum( );
        }

        /// <summary>
        /// 是否执行
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="formText"></param>
        /// <returns></returns>
        public bool ExistsReview ( string oddNum ,string formText )
        {
            return dao.ExistsReview( oddNum ,formText );
        }

        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DeleteOddNum ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.DeleteOddNum(  oddNum , tableNum , tableName , logins , dtOne , stateOf , stateOfOdd );
        }

        /// <summary>
        /// 获取数据列表   是否存在
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableAll ( string oddNum )
        {
            return dao.GetDataTableAll( oddNum );
        }

        /// <summary>
        /// 更改一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdataWeiHu ( MulaolaoLibrary.SiReYiYinContractLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.UpdataWeiHu( model , tableNum , tableName , logins , dtOne , stateOf , stateOfOdd );
        }

        /// <summary>
        /// 获取数据列表  是否存在
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableAnOther ( string oddNum )
        {
            return dao.GetDataTableAnOther( oddNum );
        }

        /// <summary>
        /// 复制数据是否成功
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateAdd ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.UpdateAdd( oddNum , tableNum , tableName , logins , dtOne , stateOf , stateOfOdd );
        }

        /// <summary>
        /// 更改复制数据单号
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateAdds ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.UpdateAdds( oddNum , tableNum , tableName , logins , dtOne , stateOf , stateOfOdd );
        }

        /// <summary>
        /// 删除复制数据
        /// </summary>
        /// <returns></returns>
        public bool DeleteAdd ( )
        {
            return dao.DeleteAdd( );
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public MulaolaoLibrary.SiReYiYinContractLibrary GetModel ( string oddNum )
        {
            return dao.GetModel( oddNum );
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.SiReYiYinContractLibrary GetDataRow ( DataRow row )
        {
            return dao.GetDataRow( row );
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.SiReYiYinContractLibrary GetMode ( int idx )
        {
            return dao.GetMode( idx );
        }


        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.SiReYiYinContractLibrary GetDataR ( DataRow row )
        {
            return dao.GetDataR( row );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="numOfGoods"></param>
        /// <param name="nameOfPart"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfPrice ( string numOfGoods ,string nameOfPart )
        {
            return dao.GetDataTableOfPrice( numOfGoods ,nameOfPart );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataOfSuppiler ( )
        {
            return dao.GetDataOfSuppiler( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="supplierNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfSupplier ( string supplierNum )
        {
            return dao.GetDataTableOfSupplier( supplierNum );
        }

        /// <summary>
        /// 获取数据列表
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
        /// <returns></returns>
        public bool UpdateOfRecevable ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum )
        {
            return dao.UpdateOfRecevable( modelAm ,oddNum );
        }
    }
}

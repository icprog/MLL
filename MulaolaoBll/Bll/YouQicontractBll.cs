using StudentMgr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class YouQicontractBll
    {
        Dao.YouQicontractDao dao = new Dao.YouQicontractDao( );

        /// <summary>
        /// 获取数据列表  单个字段
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTable ( )
        {
            return dao.GetDataTable( );
        }
        public DataTable GetDataTableOther ( )
        {
            return dao.GetDataTableOther( );
        }


        /// <summary>
        /// 获取数据列表   供应商 
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableOnly ( )
        {
            return dao.GetDataTableOnly( );
        }
        public System.Data.DataTable GetDataTableOnlyOther ( )
        {
            return dao.GetDataTableOnlyOther( );
        }


        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetDataTableCount ( string strWhere )
        {
            return dao.GetYouQiCount( strWhere );
        }
        public int GetYouQiCountOther ( string strWhere )
        {
            return dao.GetYouQiCountOther( strWhere );
        }


        /// <summary>
        /// 获取总记录数  财务结账
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetDataTableCountOne ( string strWhere )
        {
            return dao.GetYouQiCountOne( strWhere );
        }
        public int GetYouQiCountOneOther ( string strWhere )
        {
            return dao.GetYouQiCountOneOther( strWhere );
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableByChange ( string strWhere ,string orderby ,int startIndex ,int endIndex )
        {
            return dao.GetDataTableByPage( strWhere ,orderby ,startIndex ,endIndex );
        }
        public System.Data.DataTable GetDataTableByChangeOther ( string strWhere ,string orderby ,int startIndex ,int endIndex )
        {
            return dao.GetDataTableByPageOther( strWhere ,orderby ,startIndex ,endIndex );
        }

        /// <summary>
        /// 分页获取数据列表  财务结账  已执行单据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableByChange ( string strWhere ,int startIndex ,int endIndex )
        {
            return dao.GetDataTableByPage( strWhere ,startIndex ,endIndex );
        }
        public System.Data.DataTable GetDataTableByChangeOther ( string strWhere ,int startIndex ,int endIndex )
        {
            return dao.GetDataTableByPageOther( strWhere ,startIndex ,endIndex );
        }

        /// <summary>
        /// 获取联系人
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableProson ( )
        {
            return dao.GetDataTableProson( );
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
        /// 获取打印数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePrintOne ( string oddNum )
        {
            return dao.GetDataTablePrintOne( oddNum );
        }

        /// <summary>
        /// 获取打印数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePrintTwo ( string oddNum )
        {
            return dao.GetDataTablePrintTwo( oddNum );
        }

        /// <summary>
        /// 获取打印数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePrintThr ( string oddNum )
        {
            return dao.GetDataTablePrintThr( oddNum );
        }

        /// <summary>
        /// 获取464数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableYesOrNoPlan ( MulaolaoLibrary.YouQiLibrary model )
        {
            return dao.GetDataTableYesOrNoPlan( model );
        }

        /// <summary>
        /// 获取464数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableYesNoAdPlan ( string oddNum )
        {
            return dao.GetDataTableYesNoAdPlan( oddNum );
        }

        /// <summary>
        /// 获取对比数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableContrast ( MulaolaoLibrary.YouQiLibrary model )
        {
            return dao.GetDataTableContrast( model );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add ( MulaolaoLibrary.YouQiLibrary model ,string tableNum ,string tableName ,string logins ,string stateOf ,string stateOfOdd ,DateTime dtOne )
        {
            return dao.Add( model ,tableNum ,tableName ,logins ,stateOf ,stateOfOdd ,dtOne );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.YouQiLibrary model ,string tableNum ,string tableName ,string logins ,string stateOf ,string stateOfOdd ,DateTime dtOne )
        {
            return dao.Update( model ,tableNum ,tableName ,logins ,stateOf ,stateOfOdd ,dtOne );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePlan ( MulaolaoLibrary.YouQiLibrary model )
        {
            return dao.GetDataTablePlan( model );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableDwo ( MulaolaoLibrary.YouQiLibrary model )
        {
            return dao.GetDataTableDwo( model );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx ,string tableNum ,string tableName ,string logins ,string stateOf ,string stateOfOdd ,DateTime dtOne ,string oddNum ,string gP ,string sP ,string numOf525 ,string oddNumOf525 ,string nameOf ,string workOf ,string colorName)
        {
            return dao.Delete( idx ,tableNum ,tableName ,logins ,stateOf ,stateOfOdd ,dtOne ,oddNum ,gP ,sP ,numOf525 ,oddNumOf525 ,nameOf ,workOf ,colorName );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableAll ( string oddNum )
        {
            return dao.GetDataTableAll( oddNum );
        }

        /// <summary>
        /// 批量编辑
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateBatch ( string oddNum ,long numBer ,string tableNum ,string tableName ,string logins ,string stateOf ,string stateOfOdd ,DateTime dtOne )
        {
            return dao.UpdateBatch( oddNum ,numBer ,tableNum ,tableName ,logins ,stateOf ,stateOfOdd ,dtOne );
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.YouQiLibrary GetModel ( int idx )
        {
            return dao.GetModel( idx );
        }

        /// <summary>
        /// 是否执行
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public bool ExistsReview ( string oddNum ,string tableName )
        {
            return dao.ExistsReview( oddNum ,tableName );
        }

        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DeleteOddNum ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.DeleteOddNum( oddNum ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
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
        public bool EditOfSign ( string odd )
        {
            return dao.EditOfSign( odd );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateMain ( MulaolaoLibrary.YouQiLibrary model )
        {
            return dao.UpdateMain( model );
        }
        public bool UpdatePlan ( MulaolaoLibrary.YouQiLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.UpdatePlan( model ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
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

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableCopy ( string oddNum )
        {
            return dao.GetDataTableCopy( oddNum );
        }

        /// <summary>
        /// 复制一单数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Copy ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.Copy( oddNum ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateCo ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.UpdateCo( oddNum ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
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
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.YouQiLibrary GetMo ( string oddNum )
        {
            return dao.GetMo( oddNum );
        }

        /// <summary>
        /// 获取供应商
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableSupp ( string oddNum )
        {
            return dao.GetDataTableSupp( oddNum );
        }

        /// <summary>
        /// 编辑上次入库记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateStr ( MulaolaoLibrary.YouQiLibrary model )
        {
            return dao.UpdateStr( model );
        }

        /// <summary>
        /// 获取供应商信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableSupplier ( )
        {
            return dao.GetDataTableSupplier( );
        }

        /// <summary>
        /// 获取519数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqabcdekz ( string tableName )
        {
            return dao.GetDataTablePqabcdekz( tableName );
        }


        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="procedure"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public bool ExistsBuild ( string procedure ,string color ,string oddNum,string colorName,string brand)
        {
            return dao.ExistsBuild( procedure ,color ,oddNum ,colorName ,brand );
        }


        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Insert ( MulaolaoLibrary.YouQiLibrary _model ,string tableNum ,string tableName ,string logins ,DateTime dtOne   ,string stateOf ,string stateOfOdd )
        {
            return dao.Insert( _model ,tableNum ,tableName ,logins ,dtOne  ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool UpdateOther ( MulaolaoLibrary.YouQiLibrary _model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.UpdateOther( _model ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool DeleteOther ( int idx ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string oddNum ,string stateOf ,string stateOfOdd )
        {
            return dao.DeleteOther( idx ,tableNum ,tableName ,logins ,dtOne ,oddNum ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTablePlanOther ( string strWhere )
        {
            return dao.GetDataTablePlanOther( strWhere );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintOther ( string oddNum )
        {
            return dao.GetDataTablePrintOther( oddNum );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintsOther ( string oddNum )
        {
            return dao.GetDataTablePrintsOther( oddNum );
        }

        /// <summary>
        /// 获取色号名称
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableColorName ( )
        {
            return dao.GetDataTableColorName( );
        }

        /// <summary>
        /// 编辑入库指标
        /// </summary>
        public bool GetDataTableOfStorage ( )
        {
            return dao.GetDataTableOfStorage( );
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
        /// 写入数据到241
        /// </summary>
        /// <param name="modelAm"></param>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateOfReceivable ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum )
        {
            return dao.UpdateOfReceivable( modelAm ,oddNum );
        }

        /// <summary>
        /// 获取525剩余库存
        /// </summary>
        /// <param name="nameOf"></param>
        /// <param name="workOf"></param>
        /// <param name="colorName"></param>
        /// <returns></returns>
        public DataTable GetDataTableSerialNum ( string nameOf ,string workOf ,string colorName )
        {
            return dao.GetDataTableSerialNum( nameOf ,workOf ,colorName );
        }

        /// <summary>
        /// 编辑入库标记
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public int editSigns ( string oddNum )
        {
            return dao . editSigns ( oddNum );
        }

    }
}

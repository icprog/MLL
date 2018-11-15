using StudentMgr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class MucaiContractBll
    {
        Dao.MucaiContractDao dao = new Dao.MucaiContractDao( );


        /// <summary>
        /// 获取数据列表   单个字段
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableOnly ( string field )
        {
            return dao.GetDataTableOnely( field );
        }


        /// <summary>
        /// 获取数据列表  单个字段
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableSupplied ( )
        {
            return dao.GetDataTableSupplied( );
        }


        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetMucaiCount ( string strWhere )
        {
            return dao.GetMucaiCount( strWhere );
        }


        /// <summary>
        /// 获取总记录数 财务结账
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetMucaiCountOne ( string strWhere )
        {
            return dao.GetMucaiCountOne( strWhere );
        }

        /// <summary>
        /// 分页获取数据集
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
        /// 更改入库标记
        /// </summary>
        /// <returns></returns>
        public bool EditStroageMark ( )
        {
            return dao.EditStroageMark( );
        }


        /// <summary>
        /// 分页获取数据集  财务结账
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
        /// 获取生产人姓名
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePerson ( )
        {
            return dao.GetDataTablePerson( );
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
        /// 获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableYesNoAcPlan ( MulaolaoLibrary.MuCaiContractLibrary model )
        {
            return dao.GetDataTableYesNoAcPlan( model );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableYseNoAdPlan ( string oddNum )
        {
            return dao.GetDataTableYseNoAdPlan( oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableContrast ( MulaolaoLibrary.MuCaiContractLibrary model )
        {
            return dao.GetDataTableContrast( model );
        }

        /// <summary>
        /// 是否存在一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsTable ( MulaolaoLibrary.MuCaiContractLibrary model )
        {
            return dao.ExistsTable( model );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add ( MulaolaoLibrary.MuCaiContractLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne   ,string stateOf ,string stateOfOdd )
        {
            return dao.Add( model ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.MuCaiContractLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.Update( model ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePlan ( MulaolaoLibrary.MuCaiContractLibrary model )
        {
            return dao.GetDataTablePlan( model );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableDwo ( MulaolaoLibrary.MuCaiContractLibrary model )
        {
            return dao.GetDataTableDwo( model );
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
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTabelTable ( string strWhere )
        {
            return dao.GetDataTabelTable( strWhere );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePrintOne ( string oddNum,int startIndex,int endIndex )
        {
            return dao.GetDataTablePrintOne( oddNum , startIndex , endIndex );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePrintTwo ( string oddNum ,int startIndex ,int endIndex )
        {
            return dao.GetDataTablePrintTwo( oddNum , startIndex , endIndex );
        }

        /// <summary>
        /// 是否已经执行
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="formText"></param>
        /// <returns></returns>
        public bool ExistsReeviews ( string oddNum ,string formText )
        {
            return dao.ExistsReeviews( oddNum ,formText );
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
        /// <param name="formText"></param>
        /// <returns></returns>
        public bool DeleteReview ( string oddNum ,string formText )
        {
            return dao.DeleteReview( oddNum ,formText );
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
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateWeiHu ( MulaolaoLibrary.MuCaiContractLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.UpdateWeiHu( model ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 批量编辑数量
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateBatch ( MulaolaoLibrary.MuCaiContractLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.UpdateBatch( model ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 复制一条记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool AddCopy ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.AddCopy(  oddNum , tableNum , tableName , logins , dtOne , stateOf , stateOfOdd );
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
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DeleteCopy ( string oddNum )
        {
            return dao.DeleteCopy( oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.MuCaiContractLibrary GetModel ( int idx )
        {
            return dao.GetModel( idx );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.MuCaiContractLibrary GetMo ( string oddNum )
        {
            return dao.GetMo( oddNum );
        }

        /// <summary>
        /// 获取乙方
        /// </summary>
        /// <param name="numBer"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableSecond ( string numBer )
        {
            return dao.GetDataTableSecond( numBer );
        }

        /// <summary>
        /// 编辑上次入库记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateStr ( MulaolaoLibrary.MuCaiContractLibrary model )
        {
            return dao.UpdateStr( model );
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
        /// 获取原价切削
        /// </summary>
        /// <param name="numOfGoods">货号</param>
        /// <param name="cName">材料</param>
        /// <param name="lName">零件</param>
        /// <param name="len">半成品长</param>
        /// <param name="width">半成品宽</param>
        /// <param name="height">半成品高</param>
        /// <param name="oddNum">单号</param>
        /// <returns></returns>
        public decimal getPreviousCost ( string numOfGoods ,string cName ,string lName ,string len ,string width ,string height ,string oddNum )
        {
            return dao . getPreviousCost ( numOfGoods ,cName ,lName ,len ,width ,height ,oddNum );
        }


        /// <summary>
        /// 获取规格
        /// </summary>
        /// <param name="num">流水号</param>
        /// <param name="cz">材料</param>
        /// <param name="lj">零件</param>
        /// <returns></returns>
        public DataTable getSpe ( string num ,string cz ,string lj )
        {
            return dao . getSpe ( num ,cz ,lj );
        }

    }
}

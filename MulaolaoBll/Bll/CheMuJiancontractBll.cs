using StudentMgr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class CheMuJiancontractBll
    {

        Dao.CheMuJiancontractDao dao = new Dao.CheMuJiancontractDao( );

        /// <summary>
        /// 获取数据列表 单个字段
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public System.Data. DataTable GetDataTableOnly ( string field )
        {
            return dao.GetDataTableOnly( field );
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
        /// <returns></returns>
        public int GetCheMuJianCount ( string strWhere )
        {
            return dao.GetCheMuJianCount( strWhere );
        }

        /// <summary>
        /// 获取总记录数  财务结账
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCheMuJianCountOne ( string strWhere )
        {
            return dao.GetCheMuJianCountOne( strWhere );
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
        /// 分页获取数据列表  财务结账
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
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePrintOne ( string oddNum ,int startIndex,int endIndex)
        {
            return dao . GetDataTablePrintOne ( oddNum ,startIndex ,endIndex );
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
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePrintThr ( string oddNum )
        {
            return dao.GetDataTablePrintThr( oddNum );
        }

        /// <summary>
        /// 编辑上次更新记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateStr ( MulaolaoLibrary.CheMuJianContractLibrary model )
        {
            return dao.UpdateStr( model );
        }

        /// <summary>
        /// 批量编辑数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateBatch ( MulaolaoLibrary.CheMuJianContractLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.UpdateBatch( model ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }


        /// <summary>
        /// 编辑入库标记
        /// </summary>
        /// <returns></returns>
        public bool EditStorage ( )
        {
            return dao.EditStorage( );
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="tableNum"></param>
        /// <param name="tableName"></param>
        /// <param name="logins"></param>
        /// <param name="dtOne"></param>
        /// <param name="stateOf"></param>
        /// <param name="stateOfOdd"></param>
        /// <returns></returns>
        public bool DeleteAll ( MulaolaoLibrary.CheMuJianContractLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.DeleteAll( model ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 更改记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="tableNum"></param>
        /// <param name="tableName"></param>
        /// <param name="logins"></param>
        /// <param name="dtOne"></param>
        /// <param name="stateOf"></param>
        /// <param name="stateOfOdd"></param>
        /// <returns></returns>
        public bool UpdateOfAll ( MulaolaoLibrary.CheMuJianContractLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.UpdateOfAll( model ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="tableNum"></param>
        /// <param name="tableName"></param>
        /// <param name="logins"></param>
        /// <param name="dtOne"></param>
        /// <param name="stateOf"></param>
        /// <param name="stateOfOdd"></param>
        /// <returns></returns>
        public bool Copy ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.Copy( oddNum ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 更改复制单号
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="tableNum"></param>
        /// <param name="tableName"></param>
        /// <param name="logins"></param>
        /// <param name="dtOne"></param>
        /// <param name="stateOf"></param>
        /// <param name="stateOfOdd"></param>
        /// <returns></returns>
        public bool CopyOdd ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.CopyOdd( oddNum ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfReceivable ( string oddNum )
        {
            return dao.GetDataTableOfReceivable( oddNum );
        }

        /// <summary>
        /// 写数据到241
        /// </summary>
        /// <param name="modelAm"></param>
        /// <returns></returns>
        public bool UpdateOfReceivable ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum )
        {
            return dao.UpdateOfReceivable( modelAm ,oddNum );
        }

        /// <summary>
        /// 根据流水和物品名称获取规格和每套用量
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getPartInfo ( string strWhere )
        {
            return dao . getPartInfo ( strWhere );
        }

        /// <summary>
        /// 获取原价
        /// </summary>
        /// <param name="liuNum"></param>
        /// <param name="huoNum"></param>
        /// <param name="buJian"></param>
        /// <param name="len"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public decimal getOriPri ( string liuNum ,string huoNum ,string buJian ,string len ,string width ,string height )
        {
            return dao . getOriPri ( liuNum ,huoNum ,buJian ,len ,width ,height );
        }

        /// <summary>
        /// 获取每套成本原价
        /// </summary>
        /// <param name="liuNum"></param>
        /// <param name="huoNum"></param>
        /// <param name="buJian"></param>
        /// <param name="len"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public decimal getOriPrice ( string liuNum ,string huoNum ,string buJian ,string len ,string width ,string height )
        {
            return dao . getOriPrice ( liuNum ,huoNum ,buJian ,len ,width ,height );
        }

    }
}

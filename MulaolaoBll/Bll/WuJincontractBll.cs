using StudentMgr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class WuJincontractBll
    {
        Dao.WuJincontractDao dao = new Dao.WuJincontractDao( );


        /// <summary>
        /// 获取数据列表  单个字段
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableOnly ( string field )
        {
            return dao.GetDataTableOnly( field );
        }



        /// <summary>
        /// 获取数据列表  供应商
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
        public int GetWuJinCount ( string strWhere )
        {
            return dao.GetWuJinCount( strWhere );
        }


        /// <summary>
        /// 获取总记录数  财务结账
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetWuJinCountOne ( string strWhere )
        {
            return dao.GetWuJinCountOne( strWhere );
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
        /// 分页获取数据列表   财务结账
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
        /// 编辑上次入库记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateStr ( MulaolaoLibrary.WuJinContractLibrary model )
        {
            return dao.UpdateStr( model );
        }

        /// <summary>
        /// 批量编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateBatch ( MulaolaoLibrary.WuJinContractLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string oddNumn ,string stateOf ,string stateOfOdd )
        {
            return dao.UpdateBatch( model ,tableNum ,tableName ,logins ,dtOne ,oddNumn ,stateOf ,stateOfOdd );
        }


        /// <summary>
        /// 获取联系人
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
        /// 编辑入库标记
        /// </summary>
        /// <returns></returns>
        public bool EditStorage ( )
        {
            return dao.EditStorage( );
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
        /// 删除一单记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="tableNum"></param>
        /// <param name="tableName"></param>
        /// <param name="logins"></param>
        /// <param name="dtOne"></param>
        /// <param name="stateOf"></param>
        /// <param name="stateOfOdd"></param>
        /// <returns></returns>
        public bool DeleteAll ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.DeleteAll( oddNum ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
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
        /// 复制保存
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="tableNum"></param>
        /// <param name="tableName"></param>
        /// <param name="logins"></param>
        /// <param name="dtOne"></param>
        /// <param name="stateOf"></param>
        /// <param name="stateOfOdd"></param>
        /// <returns></returns>
        public bool CopyAll ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.CopyAll( oddNum ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable UpdateOfReceviable ( string oddNum )
        {
            return dao.UpdateOfReceviable( oddNum );
        }

        /// <summary>
        /// 写数据到241
        /// </summary>
        /// <param name="modelAm"></param>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateOfRece ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum )
        {
            return dao.UpdateOfRece( modelAm ,oddNum );
        }
    }
}

using StudentMgr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class SailesBll
    {
        Dao.SailesDao dao = new Dao.SailesDao( );
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public System.Data.DataTable GetList ( string filed )
        {
            return dao.GetList( filed );
        }


        /// <summary>
        /// 获取数据列表 HT01
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public System.Data.DataTable GetListPql ( )
        {
            return dao.GetListPql( );
        }


        /// <summary>
        /// 获取数据列表  审核人员信息
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetListJoin ( )
        {
            return dao.GetListJoin( );
        }

        /// <summary>
        /// 获取数据列表  客户信息
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetListJoinCustomer ( )
        {
            return dao.GetListJoinCustomer( );
        }


        /// <summary>
        /// 获取数据列表  生产车间
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetListProductionWork ( )
        {
            return dao.GetListProductionWork( );
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
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<MulaolaoLibrary.SailesLibrary> GetModelList ( string strWhere )
        {
            System.Data.DataTable dt = dao.GetList( strWhere );
            return DataTableToList( dt );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<MulaolaoLibrary.SailesLibrary> DataTableToList ( System.Data.DataTable dt )
        {
            List<MulaolaoLibrary.SailesLibrary> modeList = new List<MulaolaoLibrary.SailesLibrary>( );
            int rowCount = dt.Rows.Count;
            if ( rowCount > 0 )
            {
                MulaolaoLibrary.SailesLibrary model;
                for ( int i = 0 ; i < rowCount ; i++ )
                {
                    model = dao.DataRowToModel( dt.Rows[i] );
                    if ( model != null )
                    {
                        modeList.Add( model );
                    }
                }
            }

            return modeList;
        }


        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetSailesCount ( string strWhere )
        {
            return dao.GetSailesCount( strWhere );
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
        /// 是否执行
        /// </summary>
        /// <param name="num"></param>
        /// <param name="formText"></param>
        /// <returns></returns>
        public bool ExistsReviews ( string num  )
        {
            return dao.ExistsReviews( num  );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool Delete ( string tableNum ,string tableName ,string logins ,DateTime dtOne ,string oddNum ,string strS ,string stateOf,string stateOfOdd )
        {
            return dao.Delete( tableNum ,tableName ,logins ,dtOne ,oddNum ,strS ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 删除送审记录
        /// </summary>
        /// <param name="num"></param>
        /// <param name="formText"></param>
        /// <returns></returns>
        public bool DeleteReview ( string num ,string formText )
        {
            return dao.DeleteReview( num ,formText );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add ( MulaolaoLibrary.SailesLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.Add( model ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.SailesLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.Update( model ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTabletable ( string strWhere )
        {
            return dao.GetDataTabletable( strWhere );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public MulaolaoLibrary.SailesLibrary GetModel ( string num )
        {
            return dao.GetModel( num );
        }

        /// <summary>
        /// 获取数据实体
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableOther ( string num )
        {
            return dao.GetDataTableOther( num );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePrint ( string num )
        {
            return dao.GetDataTablePrint( num );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableExport ( string num )
        {
            return dao.GetDataTableExport( num );
        }

        /// <summary>
        /// 获取客户名称
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableCustomer ( )
        {
            return dao.GetDataTableCustomer( );
        }

        /// <summary>
        /// 获取业务部名称
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableBusiness ( )
        {
            return dao.GetDataTableBusiness( );
        }

        /// <summary>
        /// 获取制单人员
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableSingle ( )
        {
            return dao.GetDataTableSingle( );
        }

        /// <summary>
        /// 获取生产部门
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableWork ( )
        {
            return dao.GetDataTableWork( );
        }

        /// <summary>
        /// 获取销售部
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableSail ( )
        {
            return dao.GetDataTableSail( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableAll ( )
        {
            return dao.GetDataTableAll( );
        }

        /// <summary>
        /// 写入数据到250
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool WriteToDaily ( string num )
        {
            return dao.WriteToDaily( num );      
        }
    }
}

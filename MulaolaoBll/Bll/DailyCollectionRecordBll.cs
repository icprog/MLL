using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class DailyCollectionRecordBll
    {
        Dao.DailyCollectionRecordDao dao = new Dao.DailyCollectionRecordDao( );

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Exists ( int idx )
        {
            return dao.Exists( idx );
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool GetExists ( MulaolaoLibrary.DailyCollectionRecordLibrary model )
        {
            return dao.GetExists( model );
        }


        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add ( MulaolaoLibrary.DailyCollectionRecordLibrary model )
        {
            return dao.Add( model );
        }
        public bool Adds ( MulaolaoLibrary.DailyCollectionRecordLibrary model )
        {
            return dao.Adds( model );
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.DailyCollectionRecordLibrary model )
        {
            return dao.Updata( model );
        }
        public bool Updatas ( MulaolaoLibrary.DailyCollectionRecordLibrary model )
        {
            return dao.Updatas( model );
        }


        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete ( MulaolaoLibrary.DailyCollectionRecordLibrary model )
        {
            return dao.Delete( model );
        }


        /// <summary>
        /// 批量删除记录
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public bool DeleteList ( string idList )
        {
            return dao.DeleteList( idList );
        }


        /// <summary>
        /// 得到一个数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTable ( string strWhere )
        {
            return dao.GetDataTable( strWhere );
        }
        public DataTable GetDataTableTwo ( string strWhere )
        {
            return dao.GetDataTableTwo( strWhere );
        }


        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.DailyCollectionRecordLibrary GetModel ( int idx )
        {
            return dao.GetModel( idx );
        }


        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.DailyCollectionRecordLibrary DataRowModel ( DataRow row )
        {
            return dao.DataRowModel( row );
        }


        /// <summary>
        /// 是否执行
        /// </summary>
        /// <param name="model"></param>
        /// <param name="formText"></param>
        /// <returns></returns>
        public bool GetReview ( MulaolaoLibrary.DailyCollectionRecordLibrary model ,string formText )
        {
            return dao.GetReview( model ,formText );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="PQF01"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePqf ( string PQF01 )
        {
            return dao.GetDataTablePqf( PQF01 );
        }


        /// <summary>
        /// 获取数据列表  单个字段
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableAll ( )
        {
            return dao.GetDataTableAll( );
        }


        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetDailyCollectionRecordCount ( string strWhere )
        {
            return dao.GetDailyCollectionRecordCount( strWhere );
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
            return dao.GetDataTableByChange( strWhere ,orderby ,startIndex ,endIndex );
        }

        /// <summary>
        /// 获取所有已经执行的流水号
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( )
        {
            return dao.GetDataTable( );
        }

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable ExistsDataTable ( string num )
        {
            return dao.ExistsDataTable( num );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class ChengBenYuHeSuanAllBll
    {

        Dao.ChengBenYuHeSuanALLDao dao = new Dao.ChengBenYuHeSuanALLDao( );


        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Exists ( string oddNum )
        {
            return dao.Exists( oddNum );
        }



        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public int idxExists ( MulaolaoLibrary.ChengBenYuHeSuanAllLibrary model )
        {
            return dao.idxExists( model );
        }


        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool idxExistsPqy ( MulaolaoLibrary.ChengBenYuHeSuanAllLibrary model )
        {
            return dao.idxExistsPqy( model );
        }
        public bool ExistsOf ( MulaolaoLibrary.ChengBenYuHeSuanAllLibrary model )
        {
            return dao.ExistsOf( model );
        }


        /// <summary>
        /// R_339是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsPqi ( MulaolaoLibrary.ChengBenYuHeSuanAllLibrary model )
        {
            return dao.ExistsPqi( model );
        }


        /// <summary>
        /// 新增一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add ( MulaolaoLibrary.ChengBenYuHeSuanAllLibrary model )
        {
            return dao.Add( model );
        }



        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateContract ( MulaolaoLibrary.ChengBenYuHeSuanAllLibrary model )
        {
            return dao.UpdateContract( model );
        }



        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.ChengBenYuHeSuanAllLibrary model )
        {
            return dao.Update( model );
        }




        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete ( MulaolaoLibrary.ChengBenYuHeSuanAllLibrary model )
        {
            return dao.Delete( model );
        }



        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="idxList"></param>
        /// <returns></returns>
        public bool DeleteList ( string idxList )
        {
            return dao.DeleteList( idxList );
        }



        /// <summary>
        /// 获取一个实例对象
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ChengBenYuHeSuanAllLibrary GetModel ( MulaolaoLibrary.ChengBenYuHeSuanAllLibrary model )
        {
            return dao.GetModel( model );
        }




        /// <summary>
        /// 获取一个实例对象
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ChengBenYuHeSuanAllLibrary DataRowModel ( DataRow row )
        {
            return dao.DataRowModel( row );
        }



        /// <summary>
        /// 获取一个实例对象
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
        /// <returns></returns>
        public System.Data.DataTable GetDataTableRpqaf ( )
        {
            return dao.GetDataTableRpqaf( );
        }


        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableRpqafQuery ( string strWhere )
        {
            return dao.GetDataTableRpqafQuery( strWhere );
        }


        /// <summary>
        /// R_195
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePqq ( string oddNum )
        {
            return dao.GetDataTablePqq( oddNum );
        }



        /// <summary>
        /// R_196
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePqah ( string oddNum )
        {
            return dao.GetDataTablePqah( oddNum );
        }



        /// <summary>
        /// R_338
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePqo ( string oddNum )
        {
            return dao.GetDataTablePqo( oddNum );
        }


        /// <summary>
        /// R_339
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePqi ( string oddNum )
        {
            return dao.GetDataTablePqi( oddNum );
        }

        /// <summary>
        /// R_344 成本
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqmz ( string oddNum )
        {
            return dao.GetDataTablePqmz( oddNum );
        }

        /// <summary>
        /// R_344 厂内
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqmzes ( string oddNum )
        {
            return dao.GetDataTablePqmzes( oddNum );
        }

        /// <summary>
        /// R_344 工资
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqmzs ( string oddNum )
        {
            return dao.GetDataTablePqmzs( oddNum );
        }

        /// <summary>
        /// R_341
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePqv ( string oddNum )
        {
            return dao.GetDataTablePqv( oddNum );
        }



        /// <summary>
        /// R_342
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePqaf ( string oddNum )
        {
            return dao.GetDataTablePqaf( oddNum );
        }



        /// <summary>
        /// R_343
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePqu ( string oddNum )
        {
            return dao.GetDataTablePqu( oddNum );
        }


        /// <summary>
        /// 345
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqlz ( string oddNum )
        {
            return dao.GetDataTablePqlz( oddNum );
        }


        /// <summary>
        /// R_347
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePqs ( string oddNum )
        {
            return dao.GetDataTablePqs( oddNum );
        }

        /// <summary>
        /// 348
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqoz ( string oddNum )
        {
            return dao.GetDataTablePqoz( oddNum );
        }

        /// <summary>
        /// R_349
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePqt ( string oddNum )
        {
            return dao.GetDataTablePqt( oddNum );
        }

        /// <summary>
        /// R_495
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePqy ( string oddNum )
        {
            return dao.GetDataTablePqy( oddNum );
        }

        /// <summary>
        /// 505
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePqiz ( string oddNum )
        {
            return dao.GetDataTablePqiz( oddNum );
        }

        /// <summary>
        /// R_317
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqw ( string num )
        {
            return dao.GetDataTablePqw( num );
        }
        public bool ExistsOfPqw ( string gx )
        {
            return dao.ExistsOfPqw( gx );
        }
        public bool UpdateOfPqw ( MulaolaoLibrary.ChengBenYuHeSuanAllLibrary model )
        {
            return dao.UpdateOfPqw( model );
        }
        public bool AddOfPqw ( MulaolaoLibrary.ChengBenYuHeSuanAllLibrary model )
        {
            return dao.AddOfPqw( model );
        }

        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetChengCount ( string strWhere )
        {
            return dao.GetChengCount( strWhere );
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
        /// 分页获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableByPage ( string strWhere ,int startIndex ,int endIndex )
        {
            return dao.GetDataTableByPage( strWhere ,startIndex ,endIndex );
        }

        /// <summary>
        /// get table for print
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable getPrintOne ( string num )
        {
            return dao . getPrintOne ( num );
        }

        /// <summary>
        /// get table for print
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable getPrintTwo ( string num )
        {
            return dao . getPrintTwo ( num );
        }


    }
}
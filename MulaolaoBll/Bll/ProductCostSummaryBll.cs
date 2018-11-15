using StudentMgr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class ProductCostSummaryBll
    {
        Dao.ProductCostSummaryDao dao = new Dao.ProductCostSummaryDao( );

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Exists ( int idx )
        {
            return dao.Exists( idx );
        }



        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsModel ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            return dao.ExistsModel( model );
        }

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsModel ( string num )
        {
            return dao.ExistsModel( num );
        }

        /// <summary>
        /// 是否存在idx
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTableExists ( string num )
        {
            return dao.GetDataTableExists( num );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            return dao.Add( model );
        }

        /// <summary>
        /// 写数据到
        /// </summary>
        /// <returns></returns>
        public bool UpdateOfRpqbb ( )
        {
            return dao.UpdateOfRpqbb( );
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            return dao.Update( model );
        }
        public bool UpdateAgent ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            return dao.UpdateAgent( model );
        }
        public bool ProductBeforeAndAfterRoadWages ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            return dao.ProductBeforeAndAfterRoadWages( model );
        }
        public bool ContractProcess ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            return dao.ContractProcess( model );
        }
        public bool FinishedProductOutsourcing ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            return dao.FinishedProductOutsourcing( model );
        }
        public bool PackageMaterial ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            return dao.PackageMaterial( model );
        }
        public bool Paint ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            return dao.Paint( model );
        }
        public bool Lron ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            return dao.Lron( model );
        }
        public bool GunPaint ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            return dao.GunPaint( model );
        }
        public bool VehicleWoodPieces ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            return dao.VehicleWoodPieces( model );
        }
        public bool Plywood ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            return dao.Plywood( model );
        }
        public bool Wood ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            return dao.Wood( model );
        }



        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            return dao.Delete( model );
        }


        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="idlist"></param>
        /// <returns></returns>
        public bool DeleteList ( string idlist )
        {
            return dao.DeleteList( idlist );
        }



        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ProductCostSummaryLibrary GetModel ( int idx )
        {
            return dao.GetModel( idx );
        }



        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ProductCostSummaryLibrary DataRowModel ( DataRow row )
        {
            return dao.DataRowModel( row );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetList ( string strWhere )
        {
            return dao.GetList( strWhere );
        }


        /// <summary>
        /// 
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
        public int ProductCostSummaryCount ( string strWhere )
        {
            return dao.ProductCostSummaryCount( strWhere );
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
        /// 获取计算结果
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableCalCu (string strWhere )
        {
            return dao.GetDataTableCalCu( strWhere );
        }



        /// <summary>
        /// 获取隐藏后的计算结果
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableCalCuHide (string strWhere )
        {
            return dao.GetDataTableCalCuHide( strWhere );
        }


        /// <summary>
        /// 隐藏
        /// </summary>
        /// <returns></returns>
        public bool GetHide ( )
        {
            return dao.GetHide( );
        }



        /// <summary>
        /// 取消隐藏
        /// </summary>
        /// <returns></returns>
        public bool GetHideCanCel ( )
        {
            return dao.GetHideCanCel( );
        }

        /// <summary>
        /// 获取347数据
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePqsTwo ( string num )
        {
            return dao.GetDataTablePqsTwo( num );
        }

        /// <summary>
        /// 获取R_250数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableOne ( string strWhere )
        {
            return dao.GetDataTableOne( strWhere );
        }



        /// <summary>
        /// 获取R_196数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableTwo ( string num )
        {
            return dao.GetDataTableTwo( num );
        }
        public bool UpdatePqah ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            return dao.UpdatePqah( model );
        }


        /// <summary>
        /// 获取195数据
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePqq ( string num )
        {
            return dao.GetDataTablePqq( num );
        }
        public bool UpdatePqq ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            return dao.UpdatePqq( model );
        }

        /// <summary>
        /// 获取199数据
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqba ( string num )
        {
            return dao.GetDataTablePqba( num );
        }

        /// <summary>
        /// 获取317成本
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqw ( string num )
        {
            return dao.GetDataTablePqw( num );
        }

        /// <summary>
        /// 获取338数据
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePqo ( string num )
        {
            return dao.GetDataTablePqo( num );
        }
        public bool UpdatePqo ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            return dao.UpdatePqo( model );
        }

        /// <summary>
        /// 339
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePqi ( string num )
        {
            return dao.GetDataTablePqi( num );
        }
        public bool UpdatePqi ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            return dao.UpdatePqi( model );
        }

        /// <summary>
        /// 285
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqk ( string num )
        {
            return dao . GetDataTablePqk ( num );
        }
        public bool UpdatePqk ( MulaolaoLibrary . ProductCostSummaryLibrary model )
        {
            return dao . UpdatePqk ( model );
        }

        /// <summary>
        /// 341
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePqv ( string num )
        {
            return dao.GetDataTablePqv( num );
        }
        public bool UpdatePqv ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            return dao.UpdatePqv( model );
        }

        /// <summary>
        /// 342
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePqaf ( string num )
        {
            return dao.GetDataTablePqaf( num );
        }
        public bool UpdatePqaf ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            return dao.UpdatePqaf( model );
        }

        /// <summary>
        /// 343
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePqu ( string num )
        {
            return dao.GetDataTablePqu( num );
        }
        public bool UpdatePqu ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            return dao.UpdatePqu( model );
        }

        /// <summary>
        /// 347
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqs ( string num )
        {
            return dao.GetDataTablePqs( num );
        }
        public bool UpdatePqs ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            return dao.UpdatePqs( model );
        }

        /// <summary>
        /// 349
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePqt ( string num )
        {
            return dao.GetDataTablePqt( num );
        }
        public bool UpdatePqt ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            return dao.UpdatePqt( model );
        }

        /// <summary>
        /// 344 结款
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqlz ( string num )
        {
            return dao.GetDataTablePqlz( num );
        }
        public bool UpdatePqlz ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            return dao.UpdatePqlz( model );
        }


        /// <summary>
        /// 344 漆款厂内
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqlzs ( string num )
        {
            return dao.GetDataTablePqlzs( num );
        }

        /// <summary>
        /// 344漆款  厂内   （与346厂内漆款做对比  显示差额）
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqmzs ( string num )
        {
            return dao . GetDataTablePqmzs ( num );
        }

        /// <summary>
        /// 344 工资
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqmz ( string num )
        {
            return dao.GetDataTablePqmz( num );
        }
        public bool UpdatePqmz ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            return dao.UpdatePqmz( model );
        }

        /// <summary>
        /// 243  运费
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqbe ( string num )
        {
            return dao.GetDataTablePqbe( num );
        }

        /// <summary>
        /// 获取001已经执行数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePqf ( string num )
        {
            return dao . GetDataTablePqf ( num );
        }

        /// <summary>
        /// 获取车间主任
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableTpa ( )
        {
            return dao.GetDataTableTpa( );
        }

        /// <summary>
        /// 编辑标记
        /// </summary>
        /// <param name="dicIdx"></param>
        /// <returns></returns>
        public bool UpdateOfSign ( Dictionary<string ,string> dicIdx )
        {
            return dao.UpdateOfSign( dicIdx );
        }

        /// <summary>
        /// 更改241标记
        /// </summary>
        /// <returns></returns>
        public bool UpdateGetDataTable ( )
        {
            return dao.UpdateGetDataTable( );
        }

        /// <summary>
        /// 批量编辑税率
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="deOne"></param>
        /// <param name="deTwo"></param>
        /// <returns></returns>
        public bool BatchEdit(string strWhere, decimal deOne, decimal deTwo)
        {
            return dao.BatchEdit(strWhere, deOne, deTwo);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class CheckOutBll
    {
        private readonly Dao.CheckOutDao dal = new Dao.CheckOutDao( );

        #region BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Exists ( int idx )
        {
            return dal.Exists( idx );
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsModel ( MulaolaoLibrary.CheckOutLibrary model )
        {
            return dal.ExistsModel( model );
        }

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsAll ( MulaolaoLibrary . CheckOutLibrary model )
        {
            return dal . ExistsAll ( model );
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add ( MulaolaoLibrary.CheckOutLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfState )
        {
            return dal.Add( model , tableNum , tableName , logins , dtOne , stateOf , stateOfState );
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddAl ( MulaolaoLibrary.CheckOutLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfState )
        {
            return dal.AddAl( model ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfState );
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.CheckOutLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfState )
        {
            return dal.Update( model ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfState );
        }


        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete ( MulaolaoLibrary.CheckOutLibrary model ,string tableNum ,string tableName,string logins ,DateTime dtOne ,string stateOf ,string stateOfState )
        {
            return dal.Delete( model ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfState );
        }


        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteAl ( MulaolaoLibrary.CheckOutLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfState )
        {
            return dal.DeleteAl( model ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfState );
        }

        /// <summary>
        /// 批量删除记录
        /// </summary>
        /// <param name="idlist"></param>
        /// <returns></returns>
        public bool DeleteList ( string idlist ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfState,string oddNum )
        {
            return dal.DeleteList( idlist ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfState ,oddNum );
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.CheckOutLibrary GetMode ( int idx )
        {
            return dal.GetMode( idx );
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.CheckOutLibrary DataRowMedel ( DataRow row )
        {
            return dal.DataRowModel( row );
        }


        /// <summary>
        /// 得到一个实体对象   单个字段
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableOnly ( )
        {
            return dal.GetDataTableOnly(  );
        }



        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetList ( string strWhere )
        {
            return dal.GetList( strWhere );
        }


        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCheckOutCount ( string strWhere )
        {
            return dal.GetCheckOutCount( strWhere );
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public System.Data.DataTable GetListByPage ( string strWhere ,string orderby ,int startIndex ,int endIndex )
        {
            return dal.GetListByPage( strWhere ,orderby ,startIndex ,endIndex );
        }

        /// <summary>
        /// 获取R_915数据
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePqq (string strWhere )
        {
            return dal.GetDataTablePqq( strWhere );
        }
        public System.Data.DataTable GetDataTablePqqCount ( string oddNum )
        {
            return dal.GetDataTablePqqCount( oddNum );
        }

        /// <summary>
        /// 获取R_485数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqozCount ( string oddNum )
        {
            return dal.GetDataTablePqozCount( oddNum );
        }

        /// <summary>
        /// 获取R_199数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqbaCount ( string oddNum )
        {
            return dal.GetDataTablePqbaCount( oddNum );
        }
        public DataTable GetDataTablePqba ( string strWhere )
        {
            return dal.GetDataTablePqba( strWhere );
        }

        /// <summary>
        /// 获取R_196数据
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePqah (string strWhere)
        {
            return dal.GetDataTablePqah( strWhere );
        }
        public System.Data.DataTable GetDataTablePqahCount ( string oddNum )
        {
            return dal.GetDataTablePqahCount( oddNum );
        }


        /// <summary>
        /// 获取R_338数据
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePqo ( string strWhere )
        {
            return dal.GetDataTablePqo( strWhere );
        }
        public System.Data.DataTable GetDataTablePqoCount ( string oddNum )
        {
            return dal.GetDataTablePqoCount( oddNum );
        }

        /// <summary>
        /// 获取R_339数据
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePqi ( string strWhere )
        {
            return dal.GetDataTablePqi( strWhere );
        }
        public System.Data.DataTable GetDataTablePqiCount ( string oddNum )
        {
            return dal.GetDataTablePqiCount( oddNum );
        }


        /// <summary>
        /// 获取R_341数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePqv ( string strWhere )
        {
            return dal.GetDataTablePqv( strWhere );
        }
        public System.Data.DataTable GetDataTablePqvCount ( string oddNum )
        {
            return dal.GetDataTablePqvCount( oddNum );
        }



        /// <summary>
        /// 获取R_342数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePqaf ( string strWhere )
        {
            return dal.GetDataTablePqaf( strWhere );
        }
        public System.Data.DataTable GetDataTablePqafCount ( string oddNum )
        {
            return dal.GetDataTablePqafCount( oddNum );
        }


        /// <summary>
        /// 获取R_343数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePqu ( string strWhere )
        {
            return dal.GetDataTablePqu( strWhere );
        }
        public System.Data.DataTable GetDataTablePquCount ( string oddNum )
        {
            return dal.GetDataTablePquCount( oddNum );
        }


        /// <summary>
        /// 获取R_347数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePqs ( string strWhere )
        {
            return dal.GetDataTablePqs( strWhere );
        }
        public System.Data.DataTable GetDataTablePqsCount ( string oddNum )
        {
            return dal.GetDataTablePqsCount( oddNum );
        }


        /// <summary>
        /// 获取R_349数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePqt ( string strWhere )
        {
            return dal.GetDataTablePqt( strWhere );
        }
        public System.Data.DataTable GetDataTablePqtCount ( string oddNum )
        {
            return dal.GetDataTablePqtCount( oddNum );
        }

        /// <summary>
        /// 获取R_495数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePqy ( string strWhere )
        {
            return dal.GetDataTablePqy( strWhere );
        }
        public System.Data.DataTable GetDataTablePqyCount ( string oddNum )
        {
            return dal.GetDataTablePqyCount( oddNum );
        }

        /// <summary>
        /// 获取505
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePqiz ( string strWhere )
        {
            return dal.GetDataTablePqiz( strWhere );
        }
        public System.Data.DataTable GetDataTablePqizCount ( string oddNum )
        {
            return dal.GetDataTablePqizCount( oddNum );
        }

        /// <summary>
        /// R_345
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqlz ( string strWhere )
        {
            return dal.GetDataTablePqlz( strWhere );
        }
        public DataTable GetDataTablePqlzCount ( string oddNum )
        {
            return dal.GetDataTablePqlzCount( oddNum );
        }

        /// <summary>
        /// R_344
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqmz ( string strWhere )
        {
            return dal.GetDataTablePqmz( strWhere );
        }
        public DataTable GetDataTablePqmzCount ( string oddNum )
        {
            return dal.GetDataTablePqmzCount( oddNum );
        }

        /// <summary>
        /// R_337
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqisCount ( string oddNum )
        {
            return dal.GetDataTablePqisCount( oddNum );
        }
        public DataTable GetDataTablePqis ( string strWhere )
        {
            return dal.GetDataTablePqis( strWhere );
        }

        /// <summary>
        /// 获取本单号本次付款金额的总金额
        /// </summary>
        /// <param name="conTractNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePqak ( string conTractNum )
        {
            return dal.GetDataTablePqak( conTractNum );
        }

        /// <summary>
        /// 批量编辑状态
        /// </summary>
        /// <param name="str"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool UpdateOfState ( string str ,DateTime dt ,string tableNum,string tableName ,string logins ,string stateOf ,string stateOfState ,string oddNum )
        {
            return dal.UpdateOfState( str ,dt ,tableNum ,tableName ,logins ,stateOf ,stateOfState ,oddNum );
        }

        /// <summary>
        /// 删除AL中有  AK中没有的数据
        /// </summary>
        /// <returns></returns>
        public bool DeleteOfCheck ( )
        {
            return dal.DeleteOfCheck( );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrint ( string strWhere )
        {
            return dal.GetDataTablePrint( strWhere );
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfAll ( )
        {
            return dal.GetDataTableOfAll( );
        }

        /// <summary>
        /// 获取供应商
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfG ( )
        {
            return dal . GetDataTableOfG ( );
        }

        /// <summary>
        /// 批量编辑供应商
        /// </summary>
        /// <param name="strNameOne"></param>
        /// <param name="strNameTwo"></param>
        /// <returns></returns>
        public bool UpdateOfG ( string strNameOne , string strNameTwo )
        {
            return dal . UpdateOfG ( strNameOne , strNameTwo );
        }
        #endregion
    }
}

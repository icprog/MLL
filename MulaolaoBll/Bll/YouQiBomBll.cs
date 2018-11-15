using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class YouQiBomBll
    {
        Dao.YouQiBomDao dao = new Dao.YouQiBomDao( );

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( )
        {
            return dao.GetDataTableOnly( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( )
        {
            return dao.GetDataTable( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="loginsNumber"></param>
        /// <param name="formText"></param>
        /// <returns></returns>
        public DataTable GetDataTablePower ( string loginsNumber ,string formText )
        {
            return dao.GetDataTablePower( loginsNumber ,formText );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePqa ( )
        {
            return dao.GetDataTablePqa( );
        }
        public DataTable GetDataTablePqas ( )
        {
            return dao.GetDataTablePqas( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePqc ( )
        {
            return dao.GetDataTablePqc( );
        }
        public DataTable GetDataTablePqcs ( )
        {
            return dao.GetDataTablePqcs( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePqd ( )
        {
            return dao.GetDataTablePqd( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePqe ( )
        {
            return dao.GetDataTablePqe( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePqb ( )
        {
            return dao.GetDataTablePqb( );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.YouQiBomLibrary GetModel ( int idx )
        {
            return dao.GetModel( idx );
        }

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists ( MulaolaoLibrary.YouQiBomLibrary model )
        {
            return dao.Exists( model );
        }

        

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert ( MulaolaoLibrary.YouQiBomLibrary model )
        {
            return dao.Insert( model );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.YouQiBomLibrary model )
        {
            return dao.Update( model );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx )
        {
            return dao.Delete( idx );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableGun ( )
        {
            return dao.GetDataTableGun( );
        }

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="colorNum"></param>
        /// <param name="type"></param>
        /// <param name="material"></param>
        /// <returns></returns>
        public bool Exists ( string colorNum ,string type ,string material )
        {
            return dao.Exists( colorNum ,type ,material );
        }

        /// <summary>
        /// 批量新建数据
        /// </summary>
        /// <param name="colorNum"></param>
        /// <param name="type"></param>
        /// <param name="material"></param>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool batchAdd ( string colorNum ,string type ,string material ,MulaolaoLibrary.YouQiBomLibrary _model )
        {
            return dao.batchAdd( colorNum ,type ,material ,_model );
        }

        /// <summary>
        /// 批量编辑数据
        /// </summary>
        /// <param name="colorNum"></param>
        /// <param name="type"></param>
        /// <param name="material"></param>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool batchEdit ( string colorNum ,string type ,string material ,MulaolaoLibrary.YouQiBomLibrary _model )
        {
            return dao.batchEdit( colorNum ,type ,material ,_model );
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="colorNum"></param>
        /// <param name="type"></param>
        /// <param name="material"></param>
        /// <returns></returns>
        public bool batchDelete ( string colorNum ,string type ,string material )
        {
            return dao.batchDelete( colorNum ,type ,material );
        }

        /// <summary>
        /// 根据油漆品牌批量删除滚漆
        /// </summary>
        /// <param name="paintP"></param>
        /// <returns></returns>
        public bool barchDelete ( string paintP )
        {
            return dao . barchDelete ( paintP );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePqase ( )
        {
            return dao.GetDataTablePqase( );
        }
        public DataTable GetDataTablePqases ( )
        {
            return dao.GetDataTablePqases( );
        }

        /// <summary>
        /// 获取供应商列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfSupplie ( )
        {
            return dao.GetDataTableOfSupplie( );
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool ExistsOfSupplie ( MulaolaoLibrary.YouQiBomHupLibrary _model )
        {
            return dao.ExistsOfSupplie( _model );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public int AddOfSupplie ( MulaolaoLibrary.YouQiBomHupLibrary _model )
        {
            return dao.AddOfSupplie( _model );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.YouQiBomHupLibrary GetModelSupplie ( int idx )
        {
            return dao.GetModelSupplie( idx );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool UpdateOfSupplie ( MulaolaoLibrary.YouQiBomHupLibrary _model )
        {
            return dao.UpdateOfSupplie( _model );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool DeleteOfSupplie ( int idx )
        {
            return dao.DeleteOfSupplie( idx );
        }


        /// <summary>
        /// 胶板是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsPQJB ( MulaolaoLibrary . PqjbEntity model )
        {
            return dao . ExistsPQJB ( model );
        }

        public bool ExistsPQJBEdit ( MulaolaoLibrary . PqjbEntity model )
        {
            return dao . ExistsPQJBEdit ( model );
        }

        /// <summary>
        /// 新增胶板
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddPQJB ( MulaolaoLibrary . PqjbEntity model )
        {
            return dao . AddPQJB ( model );
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EditPQJB ( MulaolaoLibrary . PqjbEntity model )
        {
            return dao . EditPQJB ( model );
        }

        /// <summary>
        /// 删除胶板数据
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool DeletePQJB ( int idx )
        {
            return dao . DeletePQJB ( idx );
        }

        /// <summary>
        /// 获取胶板数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable getTable ( )
        {
            return dao . getTable ( );
        }


        /// <summary>
        /// 是否存在密度板
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsPQMD ( MulaolaoLibrary . PqmdEntity model )
        {
            return dao . ExistsPQMD ( model );
        }

        public bool ExistsPQMDE ( MulaolaoLibrary . PqmdEntity model )
        {
            return dao . ExistsPQMDE ( model );
        }

        /// <summary>
        /// 新增密度板
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddPQMD ( MulaolaoLibrary . PqmdEntity model )
        {
            return dao . AddPQMD ( model );
        }

        /// <summary>
        /// 编辑密度板
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EditPQMD ( MulaolaoLibrary . PqmdEntity model )
        {
            return dao . EditPQMD ( model );
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool DeletePQMD ( int idx )
        {
            return dao . DeletePQMD ( idx );
        }

        /// <summary>
        /// 获取密度板数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable getTableMd ( )
        {
            return dao . getTableMd ( );
        }

        /// <summary>
        /// 获取供应商
        /// </summary>
        /// <returns></returns>
        public DataTable getGYS ( )
        {
            return dao . getGYS ( );
        }

    }
}

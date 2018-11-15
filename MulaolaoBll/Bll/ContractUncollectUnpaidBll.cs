using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class ContractUncollectUnpaidBll
    {
        Dao.ContractUncollectUnpaidDao _dao = new Dao.ContractUncollectUnpaidDao( );
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string strWhere )
        {
            return _dao.GetDataTable( strWhere );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable (int year )
        {
            return _dao.GetDataTable( year );
        }

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public bool Exists ( int year )
        {
            return _dao.Exists( year );
        }
        public bool ExistsIdx ( int idx )
        {
            return _dao.ExistsIdx( idx );
        }
        public bool Exists ( int year ,int month )
        {
            return _dao.Exists( year ,month );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.ContractUncollectUnpaid _model )
        {
            return _dao.Update( _model );
        }
        public bool UpdateOther ( MulaolaoLibrary.ContractUncollectUnpaid _model )
        {
            return _dao.UpdateOther( _model );
        }

        /// <summary>
        /// 录入一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Insert ( MulaolaoLibrary.ContractUncollectUnpaid _model )
        {
            return _dao.Insert( _model );
        }

        /// <summary>
        /// Generate
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Add ( MulaolaoLibrary.ContractUncollectUnpaid _model )
        {
            return _dao.Add( _model );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx )
        {
            return _dao.Delete( idx );
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool DeleteBatch ( int year )
        {
            return _dao.DeleteBatch( year );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ContractUncollectUnpaid GetModel ( int idx )
        {
            return _dao.GetModel( idx );
        }
    }
}

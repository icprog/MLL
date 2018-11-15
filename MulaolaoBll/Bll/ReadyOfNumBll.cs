using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MulaolaoBll.Bll
{
    public class ReadyOfNumBll
    {
        Dao.ReadyOfNumDao _dao = new Dao.ReadyOfNumDao( );

        /// <summary>
        /// 获取最大流水号
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfNum ( )
        {
            return _dao.GetDataTableOfNum( );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool Delete ( string num )
        {
            return _dao.Delete( num );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( )
        {
            return _dao.GetDataTable( );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOf ( )
        {
            return _dao.GetDataTableOf( );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Save ( MulaolaoLibrary.ReadyOfNumLibrary _model )
        {
            return _dao.Save( _model );
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ReadyOfNumLibrary GetModel ( string num )
        {
            return _dao.GetModel( num );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsOf ( MulaolaoLibrary.ReadyOfNumLibrary model )
        {
            return _dao.ExistsOf( model );
        }
    }
}

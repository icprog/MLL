using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class WagesContrastTableBll
    {
        Dao.WagesContrastTableDao _dao = new Dao.WagesContrastTableDao( );

        /// <summary>
        /// Generate
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Insert ( MulaolaoLibrary.WagesContrastTableLibrary _model )
        {
            return _dao.Insert( _model );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( MulaolaoLibrary.WagesContrastTableLibrary _model )
        {
            return _dao.GetDataTable( _model );
        }


        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Delete ( MulaolaoLibrary.WagesContrastTableLibrary _model )
        {
            return _dao.Delete( _model );
        }
    }
}

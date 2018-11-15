using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{

    public class SystemDrityBll
    {
        Dao.SystemDrityDao _dao = new Dao.SystemDrityDao( );

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
        public DataTable GetDataTableOnly ( )
        {
            return _dao.GetDataTableOnly( );
        }


        /// <summary>
        /// 获取单号
        /// </summary>
        /// <param name="tableNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOf ( string tableNum )
        {
            return _dao.GetDataTableOf( tableNum );
        }
    }
}

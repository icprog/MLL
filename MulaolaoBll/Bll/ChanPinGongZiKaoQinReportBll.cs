using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class ChanPinGongZiKaoQinReportBll
    {
        Dao.ChanPinGongZiKaoQinReportDao dao = new Dao.ChanPinGongZiKaoQinReportDao( );
        /// <summary>
        /// 获取生产车间组长
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableGroupLeader ( )
        {
            return dao.GetDataTableGroupLeader( );
        }

        /// <summary>
        /// 获取生产车间员工姓名
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePerson ( string name )
        {
            return dao.GetDataTablePerson( name );
        }

        /// <summary>
        /// 获取317产品
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableProduct ( string num)
        {
            return dao.GetDataTableProduct( num );
        }

        /// <summary>
        /// 获取报表内容
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableReport ( string strWhere )
        {
            return dao.GetDataTableReport( strWhere );
        }
    }
}

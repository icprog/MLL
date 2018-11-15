using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MulaolaoBll.Bll
{
    public class ChanPinGonZiKaoQinHuiZongBll
    {
        Dao.ChanPinGonZiKaoQinHuiZongDao dao = new Dao.ChanPinGonZiKaoQinHuiZongDao( );
        /// <summary>
        /// 获取317产品信息
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableProduct ( )
        {
            return dao.GetDataTableProduct( );
        }

        /// <summary>
        /// 获取317车间主任
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableHeadOfWorkShop ( )
        {
            return dao.GetDataTableHeadOfWorkShop( );
        }

        /// <summary>
        /// 获取317统计员
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableStatistician ( string num )
        {
            return dao.GetDataTableStatistician( num );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableAll ( string strWhere  )
        {
            return dao.GetDataTableAll( strWhere  );
        }

        /// <summary>
        /// 获取打印表
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePrint ( string strWhere  )
        {
            return dao.GetDataTablePrint( strWhere  );
        }
    }
}

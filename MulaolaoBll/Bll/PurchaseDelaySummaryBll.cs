using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace MulaolaoBll . Bll
{
    public class PurchaseDelaySummaryBll
    {
        Dao.PurchaseDelaySummaryDao dal=null;
        public PurchaseDelaySummaryBll ( )
        {
            dal = new Dao . PurchaseDelaySummaryDao ( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable getTableView ( string strWhere )
        {
            return dal . getTableView ( strWhere );
        }

        /// <summary>
        /// 获取产品名称
        /// </summary>
        /// <returns></returns>
        public DataTable getTablePro ( )
        {
            return dal . getTablePro ( );
        }

    }
}

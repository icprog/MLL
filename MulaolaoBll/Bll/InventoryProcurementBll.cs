using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;

namespace MulaolaoBll . Bll
{
    public class InventoryProcurementBll
    {
        private readonly Dao.InventoryProcurementDao dal=null;
        public InventoryProcurementBll ( )
        {
            dal = new Dao . InventoryProcurementDao ( );
        }

        /// <summary>
        /// 入库的
        /// </summary>
        /// <returns></returns>
        public bool UpdateJZ ( )
        {
            return dal . UpdateJZ ( );
        }


        /// <summary>
        /// 出库的
        /// </summary>
        /// <returns></returns>
        public bool UpdateADJZ ( )
        {
            return dal . UpdateADJZ ( );
        }
    }
}

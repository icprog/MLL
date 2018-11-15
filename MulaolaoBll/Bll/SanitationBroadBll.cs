using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace MulaolaoBll . Bll
{
    public class SanitationBroadBll
    {
        readonly private Dao.SanitationBroadDao dal=null;
        public SanitationBroadBll ( )
        {
            dal = new Dao . SanitationBroadDao ( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public DataTable getTableView ( string dateTime )
        {
            return dal . getTableView ( dateTime );
        }


        /// <summary>
        /// 获取本年所有记录
        /// </summary>
        /// <returns></returns>
        public DataTable getTableGrouper ( )
        {
            return dal . getTableGrouper ( );
        }


        }
}

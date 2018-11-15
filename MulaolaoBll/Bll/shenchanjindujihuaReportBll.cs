using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace MulaolaoBll . Bll
{
    public class shenchanjindujihuaReportBll
    {
        Dao.shenchanjindujihuaReportDao _dal=null;

        public shenchanjindujihuaReportBll ( )
        {
            _dal = new Dao . shenchanjindujihuaReportDao ( );
        }

        /// <summary>
        /// get table to view 
        /// </summary>
        /// <returns></returns>
        public DataTable getTableToView (    )
        {
            return _dal . getTableToView (  );
        }

        /// <summary>
        /// 计算046结果
        /// </summary>
        /// <returns></returns>
        public string Calcu ( )
        {
            return _dal . Calcu ( );
        }

        /// <summary>
        /// get table of only column
        /// </summary>
        /// <returns></returns>
        public DataTable getTableOfPro ( )
        {
            return _dal . getTableOfPro ( );
        }

        }
}

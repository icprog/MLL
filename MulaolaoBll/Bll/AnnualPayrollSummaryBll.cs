using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace MulaolaoBll . Bll
{
    public class AnnualPayrollSummaryBll
    {
        readonly private Dao.AnnualPayrollSummaryDao _dal=null;
        public AnnualPayrollSummaryBll ( )
        {
            _dal = new Dao . AnnualPayrollSummaryDao ( );
        }

        /// <summary>
        /// read data from database
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public bool Read ( int year )
        {
            return _dal . Read ( year );
        }


        /// <summary>
        /// get data from database to view 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable getTableView ( int year )
        {
            return _dal . getTableView ( year );
        }

        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public bool Delete ( int year )
        {
            return _dal . Delete ( year );
        }


        /// <summary>
        /// edit data to database
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Save ( DataTable table )
        {
            return _dal . Save ( table );
        }

    }
}

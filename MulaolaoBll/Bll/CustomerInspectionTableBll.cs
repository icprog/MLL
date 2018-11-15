using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace MulaolaoBll . Bll
{
    public class CustomerInspectionTableBll
    {
        Dao.CustomerInspectionTableDao _dal=null;
        public CustomerInspectionTableBll ( )
        {
            _dal = new Dao . CustomerInspectionTableDao ( );
        }

        /// <summary>
        /// read data from r_293 to view
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public bool Read ( int year )
        {
            return _dal . Read ( year );
        }

        /// <summary>
        /// get table from r_pqdm to view
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable getTableView ( int year )
        {
            return _dal . getTableView ( year );
        }

        /// <summary>
        /// delete data for year 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public bool Delete ( int year )
        {
            return _dal . Delete ( year );
        }


    }
}

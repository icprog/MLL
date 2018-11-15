using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace MulaolaoBll . Bll
{
    public class PerformanceAppraisalBll
    {
        readonly private Dao.PerformanceAppraisalDao _dal=null;
        public PerformanceAppraisalBll ( )
        {
            _dal = new Dao . PerformanceAppraisalDao ( );
        }

        /// <summary>
        /// delete data from database 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public bool Delete ( int year )
        {
            return _dal . Delete ( year );
        }


        /// <summary>
        /// generate the data add to database
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public bool Generate ( int year )
        {
            return _dal . Generate ( year );
        }

        /// <summary>
        /// get the data from database to view 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable getTableView ( int year )
        {
            return _dal . getTableView ( year );
        }

        /// <summary>
        /// edit data to database
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Edit ( DataTable table )
        {
            return _dal . Edit ( table );
        }

    }
}

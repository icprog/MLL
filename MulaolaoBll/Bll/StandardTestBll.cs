using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace MulaolaoBll . Bll
{
    public class StandardTestBll
    {
        Dao.StandardTestDao _dal=null;
        public StandardTestBll ( )
        {
            _dal = new Dao . StandardTestDao ( );
        }

        /// <summary>
        /// get data from r_pqcl to view 
        /// </summary>
        /// <returns></returns>
        public DataTable getViewOne ( )
        {
            return _dal . getViewOne ( );
        }

        /// <summary>
        /// get data from r_pqcm to view 
        /// </summary>
        /// <returns></returns>
        public DataTable getViewTwo ( )
        {
            return _dal . getViewTwo ( );
        }

        /// <summary>
        /// save data to database for r_pqcl r_pqcm
        /// </summary>
        /// <param name="tableOne"></param>
        /// <param name="tableTwo"></param>
        /// <param name="strList"></param>
        /// <param name="strL"></param>
        /// <returns></returns>
        public bool Save ( DataTable tableOne ,DataTable tableTwo ,List<string> strList ,List<string> strL )
        {
            return _dal . Save ( tableOne ,tableTwo ,strList ,strL );
        }

    }
}

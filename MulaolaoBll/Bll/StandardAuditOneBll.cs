using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace MulaolaoBll . Bll
{
    public class StandardAuditOneBll
    {
        Dao. StandardAuditOneDao _dal=null;
        public StandardAuditOneBll ( )
        {
            _dal = new Dao . StandardAuditOneDao ( );
        }

        /// <summary>
        /// get data from r_pqcc to view
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getView ( string strWhere )
        {
            return _dal . getView ( strWhere );
        }

        /// <summary>
        /// get datasource from r_pqcb
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public MulaolaoLibrary . StandardAuditOneCBEntity getModel ( string oddNum )
        {
            return _dal . getModel ( oddNum );
        }

        /// <summary>
        /// get product info from r_pqf
        /// </summary>
        /// <returns></returns>
        public DataTable getProInfo ( )
        {
            return _dal . getProInfo ( );
        }

        /// <summary>
        /// get product parts from r_pqp
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable getPart ( string num )
        {
            return _dal . getPart ( num );
        }

        /// <summary>
        /// get max oddNum from r_pqcb
        /// </summary>
        /// <returns></returns>
        public string getOddNum ( )
        {
            return _dal . getOddNum ( );
        }

        /// <summary>
        /// delete data from r_pqcb and r_pqcc, and write operation to r_pqbf
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="logins"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum ,string logins )
        {
            return _dal . Delete ( oddNum ,logins );
        }

        /// <summary>
        /// save data to r_pqcb and r_pqcc
        /// </summary>
        /// <param name="table"></param>
        /// <param name="_cb"></param>
        /// <returns></returns>
        public bool Save ( DataTable table ,MulaolaoLibrary . StandardAuditOneCBEntity _cb ,string logins )
        {
            return _dal . Save ( table ,_cb ,logins );
        }


        /// <summary>
        /// edit data from r_pqcb and r_pqcc to database
        /// </summary>
        /// <param name="table"></param>
        /// <param name="_cb"></param>
        /// <param name="logins"></param>
        /// <param name="strList"></param>
        /// <returns></returns>
        public bool Edit ( DataTable table ,MulaolaoLibrary . StandardAuditOneCBEntity _cb ,string logins ,List<string> strList )
        {
            return _dal . Edit ( table ,_cb ,logins ,strList );
        }

        /// <summary>
        /// get one column datasource from r_pqcb
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public DataTable getColumnOnly ( )
        {
            return _dal . getColumnOnly ( );
        }

        /// <summary>
        /// get count from r_pqcb
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int getCount ( string strWhere )
        {
            return _dal . getCount ( strWhere );
        }

        /// <summary>
        /// get data for page from r_pqcb
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable getDataTableByChange ( string strWhere ,int startIndex ,int endIndex )
        {
            return _dal . getDataTableByChange ( strWhere ,startIndex ,endIndex );
        }

        /// <summary>
        /// get user data from r_pqcb
        /// </summary>
        /// <returns></returns>
        public DataTable getUser ( )
        {
            return _dal . getUser ( );
        }


        /// <summary>
        /// get table for print
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable getPrintOne ( string oddNum )
        {
            return _dal . getPrintOne ( oddNum );
        }

        /// <summary>
        /// get table for print
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable getPrintTwo ( string oddNum )
        {
            return _dal . getPrintTwo ( oddNum );
        }

    }
}

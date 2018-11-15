using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace MulaolaoBll . Bll
{
    public class StandardAuditFivBll
    {
        Dao.StandardAuditFivDao _dal=null;
        public StandardAuditFivBll ( )
        {
            _dal = new Dao . StandardAuditFivDao ( );
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
        /// get user data from r_pqcf
        /// </summary>
        /// <returns></returns>
        public DataTable getUser ( )
        {
            return _dal . getUser ( );
        }

        /// <summary>
        /// get one column datasource from r_pqcf
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public DataTable getColumnOnly ( )
        {
            return _dal . getColumnOnly ( );
        }


        /// <summary>
        /// get count from r_pqcf
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int getCount ( string strWhere )
        {
            return _dal . getCount ( strWhere );
        }

        /// <summary>
        /// get data for page from r_pqcf
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
        /// get datasource from r_pqcf
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public MulaolaoLibrary . StandardAuditFivCJEntity getModel ( string oddNum )
        {
            return _dal . getModel ( oddNum );
        }

        /// <summary>
        /// get data from r_pqcg to view
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getView ( string strWhere )
        {
            return _dal . getView ( strWhere );
        }


        /// <summary>
        /// get max oddNum from r_pqcf
        /// </summary>
        /// <returns></returns>
        public string getOddNum ( )
        {
            return _dal . getOddNum ( );
        }

        /// <summary>
        /// delete data from r_pqcf and r_pqcg, and write operation to r_pqbf
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
        public bool Save ( DataTable table ,MulaolaoLibrary . StandardAuditFivCJEntity _cd ,string logins )
        {
            return _dal . Save ( table ,_cd ,logins );
        }

        /// <summary>
        /// edit data from r_pqcb and r_pqcc to database
        /// </summary>
        /// <param name="table"></param>
        /// <param name="_cb"></param>
        /// <param name="logins"></param>
        /// <param name="strList"></param>
        /// <returns></returns>
        public bool Edit ( DataTable table ,MulaolaoLibrary . StandardAuditFivCJEntity _cd ,string logins ,List<string> strList )
        {
            return _dal . Edit ( table ,_cd ,logins ,strList );
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
        /// get a list of printed data
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable getTablePrintOne ( string oddNum )
        {
            return _dal . getTablePrintOne ( oddNum );
        }

        /// <summary>
        /// get a list of printed data
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable getTablePrintTwo ( string oddNum )
        {
            return _dal . getTablePrintTwo ( oddNum );
        }

    }
}

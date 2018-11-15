using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace MulaolaoBll . Bll
{
    public class TestReportForAQBll
    {
        Dao.TestReportForAQDao _dal=null;

        public TestReportForAQBll ( )
        {
            _dal = new Dao . TestReportForAQDao ( );
        }

        /// <summary>
        /// get pro info from r_pqf
        /// </summary>
        /// <returns></returns>
        public DataTable getProInfo ( )
        {
            return _dal . getProInfo ( );
        }

        /// <summary>
        /// get data from r_pqdb to view
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTableView ( string strWhere )
        {
            return _dal . getTableView ( strWhere );
        }

        /// <summary>
        /// get datasource from r_pqda to view
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public MulaolaoLibrary . TestReportForAQDAEntity getModel ( string oddNum )
        {
            return _dal . getModel ( oddNum );
        }


        /// <summary>
        /// get data from r_pqda for columns
        /// </summary>
        /// <returns></returns>
        public DataTable getColumnOnly ( )
        {
            return _dal . getColumnOnly ( );
        }


        /// <summary>
        /// get count from r_pqda 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int getCount ( string strWhere )
        {
            return _dal . getCount ( strWhere );
        }

        /// <summary>
        /// get data from r_pqda to view for by page 
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
        /// get max oddNum from r_pqch
        /// </summary>
        /// <returns></returns>
        public string getOddNum ( )
        {
            return _dal . getOddNum ( );
        }

        /// <summary>
        /// delete data from r_pqcu and r_pqcv and write operation to r_pqbf
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="logins"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum ,string logins )
        {
            return _dal . Delete ( oddNum ,logins );
        }

        /// <summary>
        /// save data to r_pqda r_pqdb 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="_da"></param>
        /// <param name="bodyList"></param>
        /// <param name="logins"></param>
        /// <returns></returns>
        public bool Save ( DataTable table ,MulaolaoLibrary . TestReportForAQDAEntity _da ,List<string> bodyList ,string logins )
        {
            return _dal . Save ( table ,_da ,bodyList ,logins );
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

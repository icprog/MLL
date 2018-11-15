using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace MulaolaoBll . Bll
{
    public class TestResultRecordOneBll
    {
        Dao.TestResultRecordOneDao _dal=null;
        public TestResultRecordOneBll ( )
        {
            _dal = new Dao . TestResultRecordOneDao ( );
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
        /// get proNun from r_pqcw
        /// </summary>
        /// <returns></returns>
        public DataTable getProNum ( )
        {
            return _dal . getProNum ( );
        }

        /// <summary>
        /// get data from r_pqcv
        /// </summary>
        /// <returns></returns>
        public DataTable getColumnOnly ( )
        {
            return _dal . getColumnOnly ( );
        }


        /// <summary>
        /// get count from r_pqcv
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int getCount ( string strWhere )
        {
            return _dal . getCount ( strWhere );
        }

        /// <summary>
        /// get data from r_pqcv
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
        /// get data from r_pqcu to view
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTableView ( string strWhere )
        {
            return _dal . getTableView ( strWhere );
        }

        /// <summary>
        /// get data from r_pqcv 
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public MulaolaoLibrary . TestResultRecordOneCVEntity getModel ( string oddNum )
        {
            return _dal . getModel ( oddNum );
        }

        /// <summary>
        /// get data from r_pqcw to view
        /// </summary>
        /// <returns></returns>
        public DataTable getTableViewOne ( )
        {
            return _dal . getTableViewOne ( );
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
        /// save data to r_pqcv r_pqcu r_pqcw
        /// </summary>
        /// <param name="tableOnt"></param>
        /// <param name="tableTwo"></param>
        /// <param name="_cv"></param>
        /// <param name="bodyList"></param>
        /// <param name="coeList"></param>
        /// <param name="logins"></param>
        /// <returns></returns>
        public bool Save ( DataTable tableOnt ,DataTable tableTwo ,MulaolaoLibrary . TestResultRecordOneCVEntity _cv ,List<string> bodyList ,List<string> coeList ,string logins )
        {
            return _dal . Save ( tableOnt ,tableTwo ,_cv ,bodyList ,coeList ,logins );
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

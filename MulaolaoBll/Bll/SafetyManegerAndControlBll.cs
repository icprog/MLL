using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using System . Data;

namespace MulaolaoBll . Bll
{
    public class SafetyManegerAndControlBll
    {
        Dao.SafetyManegerAndControlDao _dal=null;

        public SafetyManegerAndControlBll ( )
        {
            _dal = new Dao . SafetyManegerAndControlDao ( );
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
        /// get product parts from r_pqp
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable getPart ( string num )
        {
            return _dal . getPart ( num );
        }

        /// <summary>
        /// get data from r_pqce to view
        /// </summary>
        /// <returns></returns>
        public DataTable getTableOfCoefficient ( )
        {
            return _dal . getTableOfCoefficient ( );
        }


        /// <summary>
        /// get item num from r_pqde
        /// </summary>
        /// <returns></returns>
        public DataTable itemNum ( )
        {
            return _dal . itemNum ( );
        }

        /// <summary>
        /// get data from r_pqdd to view
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTableView ( string strWhere )
        {
            return _dal . getTableView ( strWhere );
        }


        /// <summary>
        /// get datasource from r_pqdc 
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public MulaolaoLibrary . SafetyManegerAndControlDCEntity getModel ( string oddNum )
        {
            return _dal . getModel ( oddNum );
        }

        /// <summary>
        /// get data from r_pqdc 
        /// </summary>
        /// <returns></returns>
        public DataTable getColumnOnly ( )
        {
            return _dal . getColumnOnly ( );
        }

        /// <summary>
        /// get count from r_pqdc
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int getCount ( string strWhere )
        {
            return _dal . getCount ( strWhere );
        }

        /// <summary>
        /// get data from r_pqdc by page
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
        /// get max oddNum from r_pqdc
        /// </summary>
        /// <returns></returns>
        public string getOddNum ( )
        {
            return _dal . getOddNum ( );
        }


        /// <summary>
        /// delete data from r_pqdc and r_pqdd and write operation to r_pqbf
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="logins"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum ,string logins )
        {
            return _dal . Delete ( oddNum ,logins );
        }

        /// <summary>
        /// save data to r_pqdc,r_pqdd,r_pqde
        /// </summary>
        /// <param name="tableOne"></param>
        /// <param name="tableTwo"></param>
        /// <param name="_dc"></param>
        /// <param name="bodyList"></param>
        /// <param name="coeList"></param>
        /// <param name="logins"></param>
        /// <returns></returns>
        public bool Save ( DataTable tableOne ,DataTable tableTwo ,MulaolaoLibrary . SafetyManegerAndControlDCEntity _dc ,List<string> bodyList ,List<string> coeList ,string logins )
        {
            return _dal . Save ( tableOne ,tableTwo ,_dc ,bodyList ,coeList ,logins );
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

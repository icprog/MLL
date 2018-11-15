using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace MulaolaoBll . Bll
{
    public class CustomerrecordBll
    {
        Dao.CustomerrecordDao _dal=null;
        public CustomerrecordBll ( )
        {
            _dal = new Dao . CustomerrecordDao ( );
        }

        /// <summary>
        /// get customer info from tpadfa
        /// </summary>
        /// <returns></returns>
        public DataTable getCustomNameInfo ( )
        {
            return _dal . getCustomNameInfo ( );
        }

        /// <summary>
        /// get salesman info from tpadba
        /// </summary>
        /// <returns></returns>
        public DataTable getSalesmanInfo ( )
        {
            return _dal . getSalesmanInfo ( );
        }

        /// <summary>
        /// get base info from r_pqn
        /// </summary>
        /// <returns></returns>
        public DataTable getAllInfo ( )
        {
            return _dal . getAllInfo ( );
        }

        /// <summary>
        /// get only columns from r_pqn
        /// </summary>
        /// <returns></returns>
        public DataTable getColumnOnly ( )
        {
            return _dal . getColumnOnly ( );
        }

        /// <summary>
        /// get count from r_pqn
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int getCount ( string strWhere )
        {
            return _dal . getCount ( strWhere );
        }

        /// <summary>
        /// get data from r_pqn by change page
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
        /// get data from r_pqna to view
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTableView ( string strWhere )
        {
            return _dal . getTableView ( strWhere );
        }

        /// <summary>
        /// get datasource from r_pqn
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public MulaolaoLibrary . CustomerrecordEntity getModel ( string oddNum )
        {
            return _dal . getModel ( oddNum );
        }

        /// <summary>
        /// delete data from r_pqn,r_pqna,r_reviews
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="logins"></param>
        /// <param name="stateOdd"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum ,string logins )
        {
            return _dal . Delete ( oddNum ,logins );
        }



        /// <summary>
        /// get data from r_pqn for print
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable getPrintOne ( string oddNum )
        {
            return _dal . getPrintOne ( oddNum );
        }

        /// <summary>
        /// get data from r_pqna for print
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable getPrintTwo ( string oddNum )
        {
            return _dal . getPrintTwo ( oddNum );
        }

        /// <summary>
        /// save data to r_pqn,r_pqna
        /// </summary>
        /// <param name="model"></param>
        /// <param name="table"></param>
        /// <param name="strList"></param>
        /// <param name="logins"></param>
        /// <returns></returns>
        public bool Save ( MulaolaoLibrary . CustomerrecordEntity model ,DataTable table ,string logins )
        {
            return _dal . Save ( model ,table ,logins );
        }

        /// <summary>
        /// edit data to r_pqn,r_pqna
        /// </summary>
        /// <param name="model"></param>
        /// <param name="table"></param>
        /// <param name="logins"></param>
        /// <param name="strList"></param>
        /// <returns></returns>
        public bool Edit ( MulaolaoLibrary . CustomerrecordEntity model ,DataTable table ,string logins ,List<string> strList )
        {
            return _dal . Edit ( model ,table ,logins ,strList );
        }

        /// <summary>
        /// get max oddNum from r_pqn
        /// </summary>
        /// <returns></returns>
        public string getOddNum ( )
        {
            return _dal . getOddNum ( );
        }

        }
}

using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace MulaolaoBll . Bll
{
    public class QualityFinalInspsctionBll
    {
        Dao.QualityFinalInspsctionDao _dal=null;
        public QualityFinalInspsctionBll ( )
        {
            _dal = new Dao . QualityFinalInspsctionDao ( );
        }

        /// <summary>
        /// get table from r_pqf
        /// </summary>
        /// <returns></returns>
        public DataTable getSupplier ( )
        {
            return _dal . getSupplier ( );
        }

        /// <summary>
        /// get columns value from r_pqdi
        /// </summary>
        /// <returns></returns>
        public DataTable getColumnOnly ( )
        {
            return _dal . getColumnOnly ( );
        }


        /// <summary>
        /// get count from r_pqdi 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int getCount ( string strWhere )
        {
            return _dal . getCount ( strWhere );
        }


        /// <summary>
        /// get data by page for change
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
        /// get datasource from r_pqdi
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public MulaolaoLibrary . QualityFinalInspsctionDIEntity getModel ( string oddNum )
        {
            return _dal . getModel ( oddNum );
        }

        /// <summary>
        /// get table from r_pqdj
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable getTableView ( string oddNum )
        {
            return _dal . getTableView ( oddNum );
        }

        /// <summary>
        /// get max oddNum from r_pqdJ
        /// </summary>
        /// <returns></returns>
        public string getOddNum ( )
        {
            return _dal . getOddNum ( );
        }

        /// <summary>
        /// delete data from table
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum ,string logins )
        {
            return _dal . Delete ( oddNum ,logins );
        }

        /// <summary>
        /// save data to database
        /// </summary>
        /// <param name="table"></param>
        /// <param name="_di"></param>
        /// <param name="bodyList"></param>
        /// <param name="logins"></param>
        /// <returns></returns>
        public bool Save ( DataTable table ,MulaolaoLibrary . QualityFinalInspsctionDIEntity _di ,List<string> bodyList ,string logins )
        {
            return _dal . Save ( table ,_di ,bodyList ,logins );
        }

        /// <summary>
        /// get sampling from baseISO 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable getSam ( int num )
        {
            return _dal . getSam ( num );
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

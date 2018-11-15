using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace MulaolaoBll . Bll
{
    public class ProductSpecificationBll
    {
        Dao . ProductSpecificationDao _dal = null;

        public ProductSpecificationBll ( )
        {
            _dal = new Dao . ProductSpecificationDao ( );
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
        /// get basic data
        /// </summary>
        /// <returns></returns>
        public DataTable getTableOfCoefficient ( )
        {
            return _dal . getTableOfCoefficient ( );
        }


        /// <summary>
        /// get data from r_pqfc 
        /// </summary>
        /// <returns></returns>
        public DataTable getColumnOnly ( )
        {
            return _dal . getColumnOnly ( );
        }


        /// <summary>
        /// get the quantity according to the conditions
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int getCount ( string strWhere )
        {
            return _dal . getCount ( strWhere );
        }

        /// <summary>
        /// paging to get data
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
        /// get datasource
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public MulaolaoLibrary . ProductSpecificationDFEntity getModel ( string oddNum )
        {
            return _dal . getModel ( oddNum );
        }

        /// <summary>
        /// get datatable to view
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable getTableView ( string oddNum )
        {
            return _dal . getTableView ( oddNum );
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
        /// delete data from table
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum,string logins  )
        {
            return _dal . Delete ( oddNum ,logins );
        }


        /// <summary>
        /// save data to database
        /// </summary>
        /// <param name="table"></param>
        /// <param name="tableOne"></param>
        /// <param name="_df"></param>
        /// <param name="logins"></param>
        /// <param name="bodyList"></param>
        /// <param name="coeList"></param>
        /// <returns></returns>
        public bool Save ( DataTable table ,DataTable tableOne ,MulaolaoLibrary . ProductSpecificationDFEntity _df ,string logins ,List<string> bodyList ,List<string> coeList )
        {
            return _dal . Save ( table ,tableOne ,_df ,logins ,bodyList ,coeList );
        }

        /// <summary>
        /// get part from r_pqp
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable getTablePart ( string num )
        {
            return _dal . getTablePart ( num );
        }

        /// <summary>
        /// get data from r_pqdh
        /// </summary>
        /// <returns></returns>
        public DataTable getTableCheck ( )
        {
            return _dal . getTableCheck ( );
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

using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace MulaolaoBll . Bll
{
    public class FeedTestBll
    {
        Dao.FeedTestDao _dal=null;
        public FeedTestBll ( )
        {
            _dal = new Dao . FeedTestDao ( );
        }

        /// <summary>
        /// get supplier from tpadga
        /// </summary>
        /// <returns></returns>
        public DataTable getSupplier ( )
        {
            return _dal . getSupplier ( );
        }


        /// <summary>
        /// get product info from r_pqf
        /// </summary>
        /// <returns></returns>
        public DataTable getProductInfo ( )
        {
            return _dal . getProductInfo ( );
        }


        /// <summary>
        /// get part from contract for num
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable getPart ( string num,string oddNum )
        {
            return _dal . getPart ( num ,oddNum );
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
        /// get column from r_pqcn
        /// </summary>
        /// <returns></returns>
        public DataTable getColumnOnly ( )
        {
            return _dal . getColumnOnly ( );
        }


        /// <summary>
        /// get count from r_pqcn
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int getCount ( string strWhere )
        {
            return _dal . getCount ( strWhere );
        }

        /// <summary>
        /// get data from r_pqbn by change
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
        /// get data from r_pqco for oddnum to view
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable getView ( string strWhere )
        {
            return _dal . getView ( strWhere );
        }

        /// <summary>
        /// get datasource from r_pqcn
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public MulaolaoLibrary . FeedTestCNEntity getModel ( string oddNum )
        {
            return _dal . getModel ( oddNum );
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
        /// delete data from r_pqcN and r_pqc0 AND r_pqcp, and write operation to r_pqbf
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="logins"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum ,string logins )
        {
            return _dal . Delete ( oddNum ,logins );
        }

        /// <summary>
        /// save data to r_pqcn r_pqco r_pqcp
        /// </summary>
        /// <param name="table"></param>
        /// <param name="_cn"></param>
        /// <param name="ModelCp"></param>
        /// <returns></returns>
        public bool Save ( DataTable table ,MulaolaoLibrary . FeedTestCNEntity _cn ,List<MulaolaoLibrary . FeedTestCPEntity> ModelCp )
        {
            return _dal . Save ( table ,_cn ,ModelCp );
        }

        /// <summary>
        /// edit data to r_pqcn r_pqco r_pqcp
        /// </summary>
        /// <param name="table"></param>
        /// <param name="_cn"></param>
        /// <param name="ModelCp"></param>
        /// <param name="strList"></param>
        /// <returns></returns>
        public bool Edit ( DataTable table ,MulaolaoLibrary . FeedTestCNEntity _cn ,List<MulaolaoLibrary . FeedTestCPEntity> ModelCp ,List<string> strList )
        {
            return _dal . Edit ( table ,_cn ,ModelCp ,strList );
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

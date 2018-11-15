using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace MulaolaoBll . Bll
{
    public class TestResultRecordBll
    {
        Dao.TestResultRecordDao _dal=null;

        public TestResultRecordBll ( )
        {
            _dal = new Dao . TestResultRecordDao ( );
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
        /// get base info from r_pqcr
        /// </summary>
        /// <returns></returns>
        public DataTable getColumnOnly ( )
        {
            return _dal . getColumnOnly ( );
        }

        /// <summary>
        /// get count for condition
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int getCount ( string strWhere )
        {
            return _dal . getCount ( strWhere );
        }

        /// <summary>
        /// get data from r_pqcn by change page
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
        /// get data from r_pqcs to view
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTableView ( string strWhere )
        {
            return _dal . getTableView ( strWhere );
        }

        /// <summary>
        /// get data from r_pqct to view
        /// </summary>
        /// <returns></returns>
        public DataTable getTableViewOne ( )
        {
            return _dal . getTableViewOne ( );
        }


        /// <summary>
        /// get datasource from r_pqcr 
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public MulaolaoLibrary . TestResultRecordCREntity getModel ( string oddNum )
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
        /// delete data from r_pqcr and r_pqcs and write operation to r_pqbf
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="logins"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum ,string logins )
        {
            return _dal . Delete ( oddNum ,logins );
        }

        /// <summary>
        /// save data to databse 
        /// </summary>
        /// <param name="table">单身</param>
        /// <param name="_cr">单头</param>
        /// <param name="tableOne">系数</param>
        /// <param name="coeList">系数删除</param>
        /// <param name="bodyList">单身删除</param>
        /// <param name="logins">登录人</param>
        /// <returns></returns>
        public bool Save ( DataTable table ,MulaolaoLibrary . TestResultRecordCREntity _cr ,DataTable tableOne ,List<string> coeList ,List<string> bodyList ,string logins )
        {
            return _dal . Save ( table ,_cr ,tableOne ,coeList ,bodyList ,logins );
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
        /// get data from r_pqct
        /// </summary>
        /// <returns></returns>
        public DataTable getTableOfNum ( )
        {
            return _dal . getTableOfNum ( );
        }

        /// <summary>
        /// get table from r_pqcr to print info 
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable getPrintOne ( string oddNum )
        {
            return _dal . getPrintOne ( oddNum );
        }

        /// <summary>
        /// get table from r_pqcs to print info
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable getPrintTwo ( string oddNum )
        {
            return _dal . getPrintTwo ( oddNum );
        }

    }
}

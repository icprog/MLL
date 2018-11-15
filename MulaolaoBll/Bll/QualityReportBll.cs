using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace MulaolaoBll . Bll
{
    public class QualityReportBll
    {
        Dao.QualityReportDao _dal=null;
        public QualityReportBll ( )
        {
            _dal = new Dao . QualityReportDao ( );
        }

        /// <summary>
        /// get pro info from r_pqf
        /// </summary>
        /// <returns></returns>
        public DataTable getTableOfPro ( )
        {
            return _dal . getTableOfPro ( );
        }


        /// <summary>
        /// get datatable from r_pqdk
        /// </summary>
        /// <returns></returns>
        public DataTable getColumnOnly ( )
        {
            return _dal . getColumnOnly ( );
        }

        /// <summary>
        /// get count from r_pqdk
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int getCount ( string strWhere )
        {
            return _dal . getCount ( strWhere );
        }

        /// <summary>
        /// get table by one by page
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
        /// get data list from r_pqdk
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public MulaolaoLibrary . QualityReportDKEntity getModel ( string oddNum )
        {
            return _dal . getModel ( oddNum );
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
        /// delete data from r_pqdk
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="logins"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum ,string logins )
        {
            return _dal . Delete ( oddNum ,logins );
        }

        /// <summary>
        /// add data to r_pqdk
        /// </summary>
        /// <param name="model"></param>
        /// <param name="logins"></param>
        /// <returns></returns>
        public bool Save ( MulaolaoLibrary . QualityReportDKEntity model ,string logins,string state )
        {
            return _dal . Save ( model ,logins ,state);
        }


        /// <summary>
        /// get business table from tpadba
        /// </summary>
        /// <returns></returns>
        public DataTable getTableOfPersonBD ( )
        {
            return _dal . getTableOfPersonBD ( );
        }

        /// <summary>
        /// get production department from tpadba
        /// </summary>
        /// <returns></returns>
        public DataTable getTabbleOfPersonPD ( )
        {
            return _dal . getTabbleOfPersonPD ( );
        }

        /// <summary>
        /// get user from this table
        /// </summary>
        /// <returns></returns>
        public DataTable getTableOfPersonBDUser ( )
        {
            return _dal . getTableOfPersonBDUser ( );
        }

        /// <summary>
        /// get production workshop from tpadba
        /// </summary>
        /// <returns></returns>
        public DataTable getTableOfPersonPW ( )
        {
            return _dal . getTableOfPersonPW ( );
        }

        /// <summary>
        /// get table for print
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable printOne ( string oddNum )
        {
            return _dal . printOne ( oddNum );
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool Exists ( string oddNum ,string num )
        {
            return _dal . Exists ( oddNum ,num );
        }

        /// <summary>
        /// 复制数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="logins"></param>
        /// <returns></returns>
        public string copy ( string oddNum ,string logins )
        {
            return _dal . copy ( oddNum ,logins );
        }

    }
}

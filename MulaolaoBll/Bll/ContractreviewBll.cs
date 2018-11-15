using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace MulaolaoBll . Bll
{
    public class ContractreviewBll
    {
        Dao. ContractreviewDao _dal=null;
        public ContractreviewBll ( )
        {
            _dal = new Dao . ContractreviewDao ( );
        }

        public DataTable GetDataTableOfWork ( )
        {
            return _dal . GetDataTableOfWork ( );
        }

        public bool delete ( string logins )
        {
            return _dal . delete ( logins );
        }

        public DataTable printOne ( string oddNum )
        {
            return _dal . printOne ( oddNum );
        }

        public DataTable printTwo ( string oddNum )
        {

            return _dal . printTwo ( oddNum );
        }

        public DataTable getTable ( string oddNum )
        {
            return _dal . getTable ( oddNum );
        }

        public bool Save ( MulaolaoLibrary . ContractreviewEntity model )
        {
            return _dal . Save ( model );
        }

        public bool Edit ( MulaolaoLibrary . ContractreviewEntity model )
        {
            return _dal . Edit ( model );
        }

        public bool delete ( string oddNum ,string logins )
        {
            return _dal . delete ( oddNum ,logins );
        }

        public bool saveTo ( DataTable table ,string logins )
        {
            return _dal . saveTo ( table ,logins );
        }

        public bool Delete ( string oddNum ,string tableName ,string logins )
        {
            return _dal . Delete ( oddNum ,tableName ,logins );
        }

        public bool Update ( MulaolaoLibrary . ContractreviewEntity _mode ,string logins )
        {
            return _dal . Update ( _mode ,logins );
        }

        public bool Delete ( MulaolaoLibrary . ContractreviewEntity _mode ,string logins )
        {
            return _dal . Delete ( _mode ,logins );
        }

        public bool ExistsNum ( string num )
        {
            return _dal . ExistsNum ( num );
        }

        public bool Insert ( MulaolaoLibrary . ContractreviewEntity _mode ,string logins )
        {
            return _dal . Insert ( _mode ,logins );
        }

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
        /// 获取列数据
        /// </summary>
        /// <returns></returns>
        public DataTable getTableOnly ( )
        {
            return _dal . getTableOnly ( );
        }


        /// <summary>
        /// 获取列数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount ( string strWhere )
        {
            return _dal . GetCount ( strWhere );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTableByChange ( string strWhere ,int startIndex ,int endIndex )
        {
            return _dal . GetDataTableByChange ( strWhere ,startIndex ,endIndex );
        }


    }
}

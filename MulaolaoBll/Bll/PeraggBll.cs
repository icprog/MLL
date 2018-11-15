using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace MulaolaoBll . Bll
{
    public class PeraggBll
    {
        readonly private Dao.PeraggDao _dal=null;
        public PeraggBll ( )
        {
            _dal = new Dao . PeraggDao ( );
        }

        /// <summary>
        /// 生成数据
        /// </summary>
        /// <param name="table"></param>
        /// <param name="userName"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public bool GeneralTable ( string userName ,int year )
        {
            return _dal . GeneralTable ( userName ,year );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="table"></param>
        /// <param name="userName"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public bool Save ( DataTable table )
        {
            return _dal . Save ( table );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable tableView ( string strWhere )
        {
            return _dal . tableView ( strWhere );
        }

        /// <summary>
        /// 获取人员信息
        /// </summary>
        /// <returns></returns>
        public DataTable getUser ( )
        {
            return _dal . getUser ( );
        }

        /// <summary>
        /// 获取字段列表
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        public DataTable getTableOnly ( string columns )
        {
            return _dal . getTableOnly ( columns );
        }


        /// <summary>
        /// 获取记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int getCount ( string strWhere )
        {
            return _dal . getCount ( strWhere );
        }


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable getTableByChange ( string strWhere ,int startIndex ,int endIndex )
        {
            return _dal . getTableByChange ( strWhere ,startIndex ,endIndex );
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum )
        {
            return _dal . Delete ( oddNum );
        }

    }
}

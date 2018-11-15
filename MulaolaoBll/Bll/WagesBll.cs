using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace MulaolaoBll . Bll
{
    public class WagesBll
    {
        Dao.WagesDao _dal=null;

        public WagesBll ( )
        {
            _dal = new Dao . WagesDao ( );
        }

        /// <summary>
        /// 获取产品名称
        /// </summary>
        /// <returns></returns>
        public DataTable getPro ( )
        {
            return _dal . getPro ( );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Edit ( DataTable table )
        {
            return _dal . Edit ( table );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTabelView ( string strWhere )
        {
            return _dal . getTabelView ( strWhere );
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool Save ( string strWhere )
        {
            return _dal . Save ( strWhere );
        }

    }
}

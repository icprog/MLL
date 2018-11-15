using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace MulaolaoBll . Bll
{
    public class MaterialBLL
    {
        Dao.MaterialDao _dal=null;
        public MaterialBLL ( )
        {
            _dal = new Dao . MaterialDao ( );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        public bool Save ( string strWhere ,string num)
        {
            return _dal . Save ( strWhere ,num );
        }

        /// <summary>
        /// 获取数据库数据
        /// </summary>
        /// <returns></returns>
        public DataTable getTableView ( string strWhere )
        {
            return _dal . getTableView ( strWhere );
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
        /// 获取产品名称
        /// </summary>
        /// <returns></returns>
        public DataTable getPro ( )
        {
            return _dal . getPro ( );
        }

    }
}

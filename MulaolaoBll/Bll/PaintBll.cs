using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace MulaolaoBll . Bll
{
    public class PaintBll
    {
        Dao.PaintDao _dal=null;
        public PaintBll ( )
        {
            _dal = new Dao . PaintDao ( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
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
        /// 生成
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool Save ( string strWhere )
        {
            return _dal . Save ( strWhere );
        }

    }
}

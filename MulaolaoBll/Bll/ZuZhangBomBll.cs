using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class ZuZhangBomBll
    {
        Dao.ZuZhangBomDao _dao = new Dao.ZuZhangBomDao( );

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( )
        {
            return _dao.GetDataTable( );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Save ( DataTable table )
        {
            return _dao.Save( table );
        }
    }
}

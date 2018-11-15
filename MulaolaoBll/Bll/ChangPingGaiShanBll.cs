using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class ChangPingGaiShanBll
    {
        Dao.ChangPingGaiShanDao _dao = new Dao.ChangPingGaiShanDao( );

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfPqf ( )
        {
            return _dao.GetDataTableOfPqf( );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableSerialNum ( )
        {
            return _dao.GetDataTableSerialNum( );
        }
    }
}

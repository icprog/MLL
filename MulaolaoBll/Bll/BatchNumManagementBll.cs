using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class BatchNumManagementBll
    {
        Dao.BatchNumManagementDao _dao = new Dao.BatchNumManagementDao( );

        /// <summary>
        /// 获取464供方批号
        /// </summary>
        /// <param name="procedure"></param>
        /// <param name="colorNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableStock ( string procedure ,string colorNum )
        {
            return _dao.GetDataTableStock( procedure ,colorNum );
        }
    }
}

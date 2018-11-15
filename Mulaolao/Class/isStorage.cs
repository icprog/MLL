using StudentMgr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Mulaolao.Class
{
    public class isStorage
    {
        /// <summary>
        /// 获取入库记录
        /// </summary>
        /// <param name="tableNum"></param>
        /// <returns></returns>
        public DataTable GetDataTable (string tableNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
    }
}

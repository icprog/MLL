using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StudentMgr;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Mulaolao.Class
{
    public static class Powers
    {
        public static void Power( Form fm, ToolStrip ts ,string cmds, params SqlParameter[] parameters )
        {
            DataTable da = SqlHelper.ExecuteDataTable( cmds, parameters );
        }
    }
}

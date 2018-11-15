using StudentMgr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mulaolao.Contract.yesOrNoPlan
{
    public static class ProductionWorkshop
    {
        /// <summary>
        /// 生产车间
        /// </summary>
        /// <param name="boxOne"></param>
        public static void workShop (ComboBox boxOne )
        {
            DataTable dt = SqlHelper.ExecuteDataTable( "SELECT DBA001,DBA002 FROM TPADBA WHERE DBA001 IN (SELECT DBB001 FROM R_DBB) ORDER BY DBA002" );
            boxOne.DataSource = dt;
            boxOne.DisplayMember = "DBA002";
        }
        /// <summary>
        /// 采购人
        /// </summary>
        /// <param name="boxOne"></param>
        public static void purchaser ( ComboBox boxOne )
        {
            DataTable st = SqlHelper.ExecuteDataTable( "SELECT DBA001,DBA002 FROM TPADBA ORDER BY DBA002" );
            boxOne.DataSource = st;
            boxOne.DisplayMember = "DBA002";
            boxOne.ValueMember = "DBA001";
        }
    }
}

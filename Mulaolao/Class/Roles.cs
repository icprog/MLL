using StudentMgr;
using System . Data;
using System . Data . SqlClient;
using System . Windows . Forms;

namespace Mulaolao . Class
{
    public static class Roles
    {
        /// <summary>
        /// 签字确认
        /// </summary>
        /// <param name="fm">窗体</param>
        /// <param name="num">登陆人编号</param>
        /// <param name="gb">需要屏蔽的内容</param>
        /// <param name="cn">需要敞开的内容</param>
        /// <param name="title">需要签字人的职位</param>
        public static void role(Form fm,string num,GroupBox[] gb,Control[] cn,string title)
        {
            DataTable count = SqlHelper.ExecuteDataTable( "SELECT DBA012  FROM TPADBA WHERE DBA001=@DBA001", new SqlParameter( "@DBA001", num ) );
            if (count != null && count.Rows.Count > 0 && title == count.Rows[0]["DBA012"].ToString( ))
            {
                Ergodic.FormGroupboxEnableFalse( fm, gb );
                Ergodic.FormControlEnableTrue( fm, cn );
            }
        }


    }
}

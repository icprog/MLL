using StudentMgr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll
{
   public class generateOddNum
    {
        public static DateTime getTime ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT GETDATE() t" );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "t" ] . ToString ( ) ) )
                    return DateTime . Now;
                else
                    return Convert . ToDateTime ( dt . Rows [ 0 ] [ "t" ] . ToString ( ) );
            }
            else
                return DateTime . Now;
        }

        /// <summary>
        /// 生成采购合同单号
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="filed">单号字段</param>
        /// <param name="tableNumber">表号</param>
        /// <returns></returns>
        public static string purchaseContract ( string sql ,string filed ,string tableNumber )
        {
            DataTable da = SqlHelper.ExecuteDataTable( "" + sql + "" );
            if ( da.Rows.Count < 1 )
                filed = "" + tableNumber + "" +  getTime ( ) . ToString( "yyyyMMdd" ) + "001";
            else if ( da.Rows[0]["" + filed + ""].ToString( ).Length > 0 && da.Rows[0]["" + filed + ""].ToString( ).Substring( da.Rows[0]["" + filed + ""].ToString( ).Length - 11 ,8 ) == getTime ( ) . ToString( "yyyyMMdd" ) )
                filed = "" + tableNumber + "" + ( Convert.ToInt64( da.Rows[0]["" + filed + ""].ToString( ).Substring( da.Rows[0]["" + filed + ""].ToString( ).Length - 11 ,11 ) ) + 1 ).ToString( );
            else
                filed = "" + tableNumber + "" + getTime ( ) . ToString( "yyyyMMdd" ) + "001";

            try
            {
                if ( tableNumber == "R_346-" )
                {
                    SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQAJ (AJ029) VALUES (@AJ029)" ,new System.Data.SqlClient.SqlParameter( "@AJ029" ,filed ) );
                }
                if ( tableNumber == "R_241-" )
                {
                    SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQAJ (AJ024) VALUES (@AJ024)" ,new System.Data.SqlClient.SqlParameter( "@AJ024" ,filed ) );
                }
            }
            catch { }
            return filed;
        }
    }
}

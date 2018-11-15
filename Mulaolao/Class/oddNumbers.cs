using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using StudentMgr;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Mulaolao.Class
{
   public  class oddNumbers
    {
       static DateTime getTime ( ) 
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
            }else
                return DateTime . Now;
        }

        /// <summary>
        /// 生成采购合同单号
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="filed">单号字段</param>
        /// <param name="tableNumber">表号</param>
        /// <returns></returns>
        public static string purchaseContract ( string sql ,string filed ,string tableNumber)
        {
            DataTable da = SqlHelper.ExecuteDataTable("" + sql + "");
            if ( da . Rows . Count < 1 )
                filed = "" + tableNumber + "" + getTime ( ) . ToString ( "yyyyMMdd" ) + "001";
            //string sst = da.Rows[0]["" + filed + ""].ToString( );
            //int str = da.Rows[0]["" + filed + ""].ToString( ).Length;
            //string sr = da.Rows[0]["" + filed + ""].ToString( ).Substring( da.Rows[0]["" + filed + ""].ToString( ).Length - 11 ,8 );
            else if ( da . Rows [ 0 ] [ "" + filed + "" ] . ToString ( ) . Length > 0 && da . Rows [ 0 ] [ "" + filed + "" ] . ToString ( ) . Substring ( da . Rows [ 0 ] [ "" + filed + "" ] . ToString ( ) . Length - 11 ,8 ) == getTime ( ) . ToString ( "yyyyMMdd" ) )
                filed = "" + tableNumber + "" + ( Convert . ToInt64 ( da . Rows [ 0 ] [ "" + filed + "" ] . ToString ( ) . Substring ( da . Rows [ 0 ] [ "" + filed + "" ] . ToString ( ) . Length - 11 ,11 ) ) + 1 ) . ToString ( );
            else
                filed = "" + tableNumber + "" + getTime ( ) . ToString ( "yyyyMMdd" ) + "001";

            try
            {
                if ( tableNumber == "R_021-" )
                {
                    SqlHelper . ExecuteNonQuery ( "INSERT INTO R_PQAJ (AJ030) VALUES (@AJ030)" ,new SqlParameter ( "@AJ030" ,filed ) );
                }
                if ( tableNumber == "R_339-" )
                {
                    SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQAJ (AJ001) VALUES (@AJ001)" ,new SqlParameter( "@AJ001" ,filed ) );
                }
                else if ( tableNumber == "R_338-" )
                {
                    SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQAJ (AJ002) VALUES (@AJ002)" ,new SqlParameter( "@AJ002" ,filed ) );
                }
                else if ( tableNumber == "R_341-" )
                {
                    SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQAJ (AJ004) VALUES (@AJ004)" ,new SqlParameter( "@AJ004" ,filed ) );
                }
                else if ( tableNumber == "R_342-" )
                {
                    SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQAJ (AJ005) VALUES (@AJ005)" ,new SqlParameter( "@AJ005" ,filed ) );
                }               
                else if ( tableNumber == "R_343-" )
                {
                    SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQAJ (AJ006) VALUES (@AJ006)" ,new SqlParameter( "@AJ006" ,filed ) );
                }
                else if ( tableNumber == "R_347-" )
                {
                    SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQAJ (AJ007) VALUES (@AJ007)" ,new SqlParameter( "@AJ007" ,filed ) );
                }
                else if ( tableNumber == "R_349-" )
                {
                    SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQAJ (AJ008) VALUES (@AJ008)" ,new SqlParameter( "@AJ008" ,filed ) );
                }
                else if ( tableNumber == "R_195-" )
                {
                    SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQAJ (AJ009) VALUES (@AJ009)" ,new SqlParameter( "@AJ009" ,filed ) );
                }
                else if ( tableNumber == "R_196-" )
                {
                    SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQAJ (AJ010) VALUES (@AJ010)" ,new SqlParameter( "@AJ010" ,filed ) );
                }
                else if ( tableNumber == "R_526-" )
                {
                    SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQAJ (AJ011) VALUES (@AJ011)" ,new SqlParameter( "@AJ011" ,filed ) );
                }
                else if ( tableNumber == "R_046-" )
                {
                    SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQAJ (AJ012) VALUES (@AJ012)" ,new SqlParameter( "@AJ012" ,filed ) );
                }
                else if ( tableNumber == "R_317-" )
                {
                    SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQAJ (AJ013) VALUES (@AJ013)" ,new SqlParameter( "@AJ013" ,filed ) );
                }
                else if ( tableNumber == "R_436-" )
                {
                    SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQAJ (AJ014) VALUES (@AJ014)" ,new SqlParameter( "@AJ014" ,filed ) );
                }
                else if ( tableNumber == "R_501-" )
                {
                    SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQAJ (AJ015) VALUES (@AJ015)" ,new SqlParameter( "@AJ015" ,filed ) );
                }
                else if ( tableNumber == "R_505-" )
                {
                    SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQAJ (AJ016) VALUES (@AJ016)" ,new SqlParameter( "@AJ016" ,filed ) );
                }
                else if ( tableNumber == "R_047-" )
                {
                    SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQAJ (AJ017) VALUES (@AJ017)" ,new SqlParameter( "@AJ017" ,filed ) );
                }
                else if ( tableNumber == "R_231-" )
                {
                    SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQAJ (AJ018) VALUES (@AJ018)" ,new SqlParameter( "@AJ018" ,filed ) );
                }
                else if ( tableNumber == "R_344-" )
                {
                    SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQAJ (AJ019) VALUES (@AJ019)" ,new SqlParameter( "@AJ019" ,filed ) );
                }
                else if ( tableNumber == "R_337-" )
                {
                    SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQAJ (AJ020) VALUES (@AJ020)" ,new SqlParameter( "@AJ020" ,filed ) );
                }
                else if ( tableNumber == "R_266-" )
                {
                    SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQAJ (AJ021) VALUES (@AJ021)" ,new SqlParameter( "@AJ021" ,filed ) );
                }           
                else if ( tableNumber == "R_199-" )
                {
                    SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQAJ (AJ022) VALUES (@AJ022)" ,new SqlParameter( "@AJ022" ,filed ) );
                }
                else if ( tableNumber == "R_502-" )
                {
                    SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQAJ (AJ023) VALUES (@AJ023)" ,new SqlParameter( "@AJ023" ,filed ) );
                }
                else if ( tableNumber == "R_241-" )
                {
                    SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQAJ (AJ024) VALUES (@AJ024)" ,new SqlParameter( "@AJ024" ,filed ) );
                }
                else if ( tableNumber == "R_364-" )
                {
                    SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQAJ (AJ025) VALUES (@AJ025)" ,new SqlParameter( "@AJ025" ,filed ) );
                }
                else if ( tableNumber == "R_365-" )
                {
                    SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQAJ (AJ026) VALUES (@AJ026)" ,new SqlParameter( "@AJ026" ,filed ) );
                }
                else if ( tableNumber == "R_243-" )
                {
                    SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQAJ (AJ027) VALUES (@AJ027)" ,new SqlParameter( "@AJ027" ,filed ) );
                }
                else if ( tableNumber == "R_480-" )
                {
                    SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQAJ (AJ028) VALUES (@AJ028)" ,new SqlParameter( "@AJ028" ,filed ) );
                }
                else if ( tableNumber == "R_503-" )
                {
                    SqlHelper . ExecuteNonQuery ( "INSERT INTO R_PQAJ (AJ029) VALUES (@AJ029)" ,new SqlParameter ( "@AJ029" ,filed ) );
                }
            }
            catch { }
            return filed;
        }

        /// <summary>
        /// 生成采购合同合同批号
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="closeColleagues">开合同人</param>
        /// <param name="tb">开合同人</param>
        /// <param name="tbx">合同批号</param>
        /// <param name="conBat"></param>
        /// <returns></returns>
        public static string[] contractBatch ( string TableName ,string closeColleagues ,TextBox tb ,TextBox tbx ,string conBat )
        {
            string[] str = new string[2];
            
            //开合同人是否有编号
            DataTable der = SqlHelper.ExecuteDataTable( "SELECT DBA001 FROM TPADBA WHERE DBA002=@DBA002" ,new SqlParameter( "@DBA002" ,closeColleagues ) );
            if ( der.Rows.Count < 1 )
            {
                MessageBox.Show( "开合同人:" + closeColleagues + "没有编号,信息不完整" );
                tb.Text = "";
                str[0] = tb.Text;
            }
            else
            {
                //若有  判断是否有开过合同
                DataTable dw = SqlHelper.ExecuteDataTable( "SELECT MAX(" + conBat + ") "+conBat+" FROM " + TableName + " WHERE " + conBat + " LIKE '%" + der.Rows[0]["DBA001"].ToString( ) + "%'" );
                if ( dw.Rows.Count < 1 || dw.Rows[0]["" + conBat + ""].ToString( ) == "" )
                {
                    //若无  则新建此开合同人的合同批号
                    tbx.Text = der.Rows[0]["DBA001"].ToString( ) + "0001";
                    conBat = tbx.Text;
                }
                else if ( dw.Rows[0]["" + conBat + ""].ToString( ).Length > 0 )
                {
                    //若有  则在原有的基础上累加                   
                    tbx.Text = dw.Rows[0]["" + conBat + ""].ToString( ).Substring( 0 ,dw.Rows[0]["" + conBat + ""].ToString( ).Length - 5 ) + ( Convert.ToInt64( dw.Rows[0]["" + conBat + ""].ToString( ).Substring( dw.Rows[0]["" + conBat + ""].ToString( ).Length - 5 ,5 ) ) + 1 ).ToString( );
                    conBat = tbx.Text;
                }
            }
            str[1] = tbx.Text;
            return str;
        }
    }
}

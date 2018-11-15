using System . Data;
using System . Text;
using StudentMgr;
using System . Windows . Forms;

namespace Mulaolao . Class
{
    public class SpecialPowers
    {
        public string sp = "";
        /// <summary>
        /// 打印、导出必须要成本员不为空   若是计划订单   审核人必须是廖总
        /// </summary>
        /// <param name="variableOne">成本员字段</param>
        /// <param name="variableTwo">审核人字段</param>
        /// <param name="tableName">表名</param>
        /// <param name="variableThr">单号</param>
        /// <param name="tableNum">表号</param>
        /// <param name="ord">计划(实际)</param>
        /// <param name="box">流水号</param>
        public void panDuan ( string variableOne ,string variableTwo ,string tableName ,string variableThr ,string variableFor ,string ord ,string box ,string tableNum )
        {
            DataTable da = SqlHelper.ExecuteDataTable( "SELECT " + variableOne + "," + variableTwo + " FROM " + tableName + " WHERE " + variableThr + "=@" + variableThr + "" ,new System.Data.SqlClient.SqlParameter( "@" + variableThr + "" ,variableFor ) );
            if ( da.Rows.Count < 1 )
                MessageBox.Show( "没有数据,不能打印(导出、执行)" );
            else
            {
                if ( string.IsNullOrEmpty( da.Rows[0]["" + variableOne + ""].ToString( ) ) )
                    MessageBox.Show( "成本员不可为空" );
                else
                {
                    if ( tableNum == "R_341" || tableNum == "R_342" )
                    {
                        if ( da.Rows[0]["" + variableTwo + ""].ToString( ) != "廖灵飞" )
                            MessageBox.Show( "此订单必须要廖总审核" );
                        else
                            sp = "1";
                    }
                    else
                    {
                        if ( ord == "计划" || string.IsNullOrEmpty( box ) )
                        {
                            if ( da.Rows[0]["" + variableTwo + ""].ToString( ) != "廖灵飞" )
                                MessageBox.Show( "此订单为计划订单,必须要廖总审核" );
                            else
                                sp = "1";
                        }
                        else
                            sp = "1";
                    }
                }
            }
        }


        /// <summary>
        /// 是否已经出入库   若是则可以打印  导出  若否则不能打印  导出
        /// </summary>
        /// <param name="oddNum">单号</param>
        /// <param name="materialName">物料名称</param>
        /// <param name="num">货号</param>
        /// <param name="specifications">规格</param>
        /// <returns></returns>
        public bool inOut ( string oddNum ,string materialName ,string num ,string specifications )
        { 
            bool result = false;
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "SELECT DISTINCT AC16,AC02,AC04,AC05 FROM R_PQAC WHERE AC16 LIKE '%{0}%' AND AC04='{1}' AND AC02='{2}' AND AC05='{3}' UNION SELECT DISTINCT AD17,AD03,AD06,AD07 FROM R_PQAD WHERE AD17='{0}' AND AD06='{1}' AND AD03='{2}' AND AD07='{3}'" ,oddNum ,materialName ,num ,specifications );
            //strSql.AppendFormat( "SELECT * FROM R_PQAD WHERE AD17='{0}' AND AD06='{1}' AND AD07='{2}' AND AD03='{3}'" ,oddNum ,materialName ,specifications ,num );
            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ); /*SqlHelper.ExecuteDataTable( "SELECT DISTINCT AC16,AC02,AC04,AC05 FROM R_PQAC UNION SELECT DISTINCT AD17,AD03,AD06,AD07 FROM R_PQAD" );*/
            if ( da != null && da.Rows.Count > 0 )
            {
                result = true;
            }
            else
                result = false;

            return result;
        }

        /// <summary>
        /// 341
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="materialName"></param>
        /// <param name="specifications"></param>
        /// <returns></returns>
        public bool inOut ( string oddNum ,string materialName ,string specifications )
        {
            bool result = false;
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "SELECT DISTINCT AC16,AC02,AC04,AC05 FROM R_PQAC WHERE AC16 LIKE '%{0}%' AND AC04='{1}' AND AC05='{2}' UNION SELECT DISTINCT AD17,AD03,AD06,AD07 FROM R_PQAD WHERE AD17='{0}' AND AD06='{1}' AND AD07='{2}'" ,oddNum ,materialName  ,specifications );
            //strSql.AppendFormat( "SELECT * FROM R_PQAD WHERE AD17='{0}' AND AD06='{1}' AND AD07='{2}' AND AD03='{3}'" ,oddNum ,materialName ,specifications ,num );
            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ); /*SqlHelper.ExecuteDataTable( "SELECT DISTINCT AC16,AC02,AC04,AC05 FROM R_PQAC UNION SELECT DISTINCT AD17,AD03,AD06,AD07 FROM R_PQAD" );*/
            if ( da != null && da.Rows.Count > 0 )
            {
                result = true;
            }
            else
                result = false;

            return result;
        }

        /// <summary>
        /// 是否已经存在送审记录
        /// </summary>
        /// <param name="tableNum"></param>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool reviewYesNo (string tableNum ,string oddNum)
        {
            bool result = false;
            DataTable de = SqlHelper.ExecuteDataTable( "SELECT * FROM R_REVIEWS WHERE RES01=@RES01 AND RES06=@RES06" ,new System.Data.SqlClient.SqlParameter( "@RES01" ,tableNum ) ,new System.Data.SqlClient.SqlParameter( "@RES06" ,oddNum ) );
            if ( de.Rows.Count > 0 )
                result = true;
            else
                result = false;

            return result;
        }

        /// <summary>
        /// 是否已经执行
        /// </summary>
        /// <returns></returns>
        public bool reviewImple (string tableNum,string oddNum )
        {
            bool result = false;
            DataTable dl = SqlHelper.ExecuteDataTable( "SELECT RES05 FROM R_REVIEWS WHERE RES04=(SELECT MAX(RES04) FROM R_REVIEWS WHERE RES01=@RES01 AND RES06=@RES06 )" ,new System.Data.SqlClient.SqlParameter( "@RES01" ,tableNum ) ,new System.Data.SqlClient.SqlParameter( "@RES06" ,oddNum ) );
            if ( dl.Rows.Count > 0 )
            {
                if ( dl.Rows[0]["RES05"].ToString( ) == "执行" )
                    result = true;
                else
                    result = false;
            }
            else
                result = false;

            return result;
        }
    }
}

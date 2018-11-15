using Mulaolao.Contract.DefineFileds;
using StudentMgr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Mulaolao.Contract.yesOrNoPlan
{
    public class yesOrNoPlanActual
    {
        /// <summary>
        /// R_464是否有剩余库存数量
        /// </summary>
        /// <param name="AC04">名称</param>
        /// <param name="AC05">规格</param>
        /// <param name="AC02">货号</param>
        /// <returns>True:无记录</returns>
        public bool PlanActual (string AC04,string AC05,string AC02 )
        {
            bool result = false;
            StringBuilder strSql = new StringBuilder( );
            //strSql.Append( "SELECT SUM(AD05) AD05 FROM (SELECT AC18,AC03+ISNULL(AC26,0)-SUM(ISNULL(AD05,0)+ISNULL(AD20,0)) AD05 FROM R_PQAC A LEFT JOIN R_PQAD B ON AC18=AD01 AND AC04=AD06 AND AC05=AD07 AND AC02=AD03 WHERE AC02=@AC02 AND AC04=@AC04 AND AC05=@AC05 GROUP BY AC03,AC18,ISNULL(AC26,0)) A " );
            strSql . Append ( "SELECT SUM(AD05) AD05 FROM (SELECT AC18,AC10+ISNULL(AC27,0)-ISNULL(SUM(AD12+ISNULL(AD21,0)),0) AD05 FROM R_PQAC A LEFT JOIN R_PQAD B ON AC18=AD01 AND AC04=AD06 AND AC05=AD07 AND AC02=AD03 WHERE AC02=@AC02 AND AC04=@AC04 AND AC05=@AC05 GROUP BY AC10,AC18,ISNULL(AC27,0)) A " );
            SqlParameter [ ] parameter =
            {
                new SqlParameter("@AC04",SqlDbType.NVarChar,255),
                new SqlParameter("@AC05",SqlDbType.NVarChar,255),
                new SqlParameter("@AC02",SqlDbType.NVarChar,255)
            };
            parameter [ 0 ] . Value = AC04;
            parameter [ 1 ] . Value = AC05;
            parameter [ 2 ] . Value = AC02;

            DataTable da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
            if ( da.Rows.Count < 1 )
                result = true;
            else
            {
                if ( !string.IsNullOrEmpty( da.Rows[0]["AD05"].ToString( ) ) )
                {
                    if ( Convert.ToDecimal( da.Rows[0]["AD05"].ToString( ) ) != 0 )
                        result = false;
                    else
                        result = true;
                }
                else
                    result = true;
            }
            return result;
        }

        /// <summary>
        ///  R_338是否存在
        /// </summary>
        /// <param name="JM90">流水</param>
        /// <param name="JM09">物料名称</param>
        /// <param name="JM94">长</param>
        /// <param name="JM95">宽</param>
        /// <param name="JM96">高</param>
        /// <returns>True:无记录</returns>
        public bool PlanInDataBase (string JM90,string JM09,decimal JM94,decimal JM95 ,decimal JM96 )
        {
            bool result = false;

            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQO" );
            strSql.Append( " WHERE JM90=@JM90 AND JM09=@JM09 AND JM94=@JM94 AND JM95=@JM95 AND JM96=@JM96" );
            SqlParameter[] spa = {
                new SqlParameter("@JM90",SqlDbType.NVarChar,500),
                new SqlParameter("@JM09",SqlDbType.NVarChar,20),
                new SqlParameter("@JM94",SqlDbType.Decimal,6),
                new SqlParameter("@JM95",SqlDbType.Decimal,6),
                new SqlParameter("@JM96",SqlDbType.Decimal,6)
            };
            spa[0].Value = JM90;
            spa[1].Value = JM09;
            spa[2].Value = JM94;
            spa[3].Value = JM95;
            spa[4].Value = JM96;

            DataTable de = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,spa );
            if ( de.Rows.Count < 1 )
                result = true;
            else
                result = false;
            return result;
        }

        /// <summary>
        /// R_342是否存在
        /// </summary>
        /// <param name="AF002">流水</param>
        /// <param name="AF015">物料名称</param>
        /// <param name="AF020">长</param>
        /// <param name="AF021">宽</param>
        /// <param name="AF022">高</param>
        /// <returns>True:无记录</returns>
        public bool PlanInDataBaseCar (string AF002,string AF015,Decimal AF020,Decimal AF021,Decimal AF022 )
        {
            bool result = false;
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQAF" );
            strSql.Append( " WHERE AF002=@AF002 AND AF015=@AF015 AND AF020=@AF020 AND AF021=@AF021 AND AF022=@AF022" );
            SqlParameter[] parameter = {
                new SqlParameter("@AF002",SqlDbType.NVarChar,500),
                new SqlParameter("AF015",SqlDbType.NVarChar,20),
                new SqlParameter("@AF020",SqlDbType.Decimal,5),
                new SqlParameter("@AF021",SqlDbType.Decimal,5),
                new SqlParameter("@AF022",SqlDbType.Decimal,5)
            };
            parameter[0].Value = AF002;
            parameter[1].Value = AF015;
            parameter[2].Value = AF020;
            parameter[3].Value = AF021;
            parameter[4].Value = AF022;

            DataTable de = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( de.Rows.Count < 1 )
                result = true;
            else
                result = false;

            return result;
        }

        /// <summary>
        /// R_341是否存在
        /// </summary>
        /// <param name="PQV01">流水</param>
        /// <param name="PQV10">物料名称</param>
        /// <param name="PQV66">长</param>
        /// <param name="PQV67">宽</param>
        /// <param name="PQV81">高</param>
        /// <returns>True:无记录</returns>
        public bool PlanInDataBaseTree (string PQV01,string PQV10,Decimal PQV66,Decimal PQV67,Decimal PQV81)
        {
            bool result = false;
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQV" );
            strSql.Append( " WHERE PQV01=@PQV01 AND PQV10=@PQV10 AND PQV66=@PQV66 AND PQV67=@PQV67 AND PQV81=@PQV81" );
            SqlParameter[] parameter = {
                new SqlParameter("@PQV01",SqlDbType.NVarChar,100),
                new SqlParameter ("@PQV10",SqlDbType.NVarChar,20),
                new SqlParameter("@PQV66",SqlDbType.Decimal,6),
                new SqlParameter("@PQV67",SqlDbType.Decimal,6),
                new SqlParameter("@PQV81",SqlDbType.Decimal,6)
            };
            parameter[0].Value = PQV01;
            parameter[1].Value = PQV10;
            parameter[2].Value = PQV66;
            parameter[3].Value = PQV67;
            parameter[4].Value = PQV81;

            DataTable de = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( de.Rows.Count < 1 )
                result = true;
            else
                result = false;

            return result;
        }

        /// <summary>
        /// R_347是否存在
        /// </summary>
        /// <param name="PJ01"></param>
        /// <param name="PJ09"></param>
        /// <param name="PJ89"></param>
        /// <returns>True:无记录</returns>
        public bool PlanInDataBaseSu (string PJ01,string PJ09,string PJ89 )
        {
            bool result = false;
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQS" );
            strSql.Append( " WHERE PJ01=@PJ01 AND PJ09=@PJ09 AND PJ89=@PJ89" );
            SqlParameter[] parameter = {
                new SqlParameter("@PJ01",SqlDbType.NVarChar,100),
                new SqlParameter("@PJ09",SqlDbType.NVarChar,20),
                new SqlParameter("@PJ89",SqlDbType.NVarChar,50)
            };
            parameter[0].Value = PJ01;
            parameter[1].Value = PJ09;
            parameter[2].Value = PJ89;

            DataTable de = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( de.Rows.Count < 1 )
                result = true;
            else
                result = false;
            return result;
        }

        /// <summary>
        /// R_349是否存在
        /// </summary>
        /// <param name="WX01">流水</param>
        /// <param name="WX10">物料名称</param>
        /// <param name="WX11">规格</param>
        /// <returns>True:无记录</returns>
        public bool PlanInDataBaseCarton (string WX01,string WX10,string WX11 )
        {
            bool result = false;
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQT" );
            strSql.Append( " WHERE WX10=@WX10 AND WX11=@WX11" );
            SqlParameter[] parameter =
            {
                new SqlParameter("@WX10",SqlDbType.NVarChar,20),
                new SqlParameter("@WX11",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = WX10;
            parameter[1].Value = WX11;

            DataTable de = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( de.Rows.Count < 1 )
                result = true;
            else
            {
                for ( int i = 0 ; i < de.Rows.Count ; i++ )
                {
                    if ( de.Rows[i]["WX01"].ToString( ).Contains( WX01 ) )
                    {
                        result = false;
                        break;
                    }
                    else if ( i == de.Rows.Count - 1 )
                        result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// R_343是否存在
        /// </summary>
        /// <param name="PQU01">流水</param>
        /// <param name="PQU10">物料名称</param>
        /// <param name="PQU12">规格</param>
        /// <returns>True:无记录</returns>
        public bool PlanInDataBaseHardware ( string PQU01,string PQU10,string PQU12)
        {
            bool result = false;
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQU" );
            strSql.Append( " WHERE PQU01=@PQU01 AND PQU10=@PQU10 AND PQU12=@PQU12" );
            SqlParameter[] parameter = {
                new SqlParameter("@PQU01",SqlDbType.NVarChar,20),
                new SqlParameter("@PQU10",SqlDbType.NVarChar,20),
                new SqlParameter("@PQU12",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = PQU01;
            parameter[1].Value = PQU10;
            parameter[2].Value = PQU12;

            DataTable de = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( de.Rows.Count < 1 )
                result = true;
            else
                result = false;

            return result;
        }

        /// <summary>
        /// R_339是否存在
        /// </summary>
        /// <param name="YQ106">流水</param>
        /// <param name="YQ10">物料名称</param>
        /// <param name="YQ11">工序</param>
        /// <param name="YQ12">色号</param>
        /// <returns>True:无记录</returns>
        public bool PlanInDataBasePaint (string YQ03,string YQ10,string YQ11,string YQ12 )
        {
            bool result = false;
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQI" );
            strSql.Append( " WHERE YQ10=@YQ10 AND YQ11=@YQ11 AND YQ12=@YQ12" );
            SqlParameter[] parameter = {
                new SqlParameter("@YQ10",SqlDbType.NVarChar,20),
                new SqlParameter("@YQ11",SqlDbType.NVarChar,20),
                new SqlParameter("YQ12",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = YQ10;
            parameter[1].Value = YQ11;
            parameter[2].Value = YQ12;

            DataTable de = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( de.Rows.Count < 1 )
                result = true;
            else
            {
                for ( int i = 0 ; i < de.Rows.Count ; i++ )
                {
                    if ( de.Rows[i]["YQ03"].ToString( ).Contains( YQ03 ) )
                    {
                        result = false;
                        return result;
                    }
                    else
                        result = true;
                }
            }
            return result;
        }
    }
}

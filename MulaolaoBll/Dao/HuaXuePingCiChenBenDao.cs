using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using System . Data;
using StudentMgr;
using System . Data . SqlClient;
using System . Collections;

namespace MulaolaoBll.Dao
{
    public class HuaXuePingCiChenBenDao
    {
        /// <summary>
        /// 是否被339领用
        /// </summary>
        /// <param name="num"></param>
        /// <param name="nameOf"></param>
        /// <param name="workOf"></param>
        /// <param name="colorName"></param>
        /// <returns>false:被领用</returns>
        public bool yesOrNo (string num,string nameOf,string workOf,string colorName )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AI013 FROM R_PQAI WHERE AI002=@AI002 AND AI011=@AI011 AND AI003=@AI003 AND AI004=@AI004" );
            SqlParameter[] parameter = {
                new SqlParameter("@AI002",SqlDbType.NVarChar,20),
                new SqlParameter("@AI011",SqlDbType.NVarChar,20),
                new SqlParameter("@AI003",SqlDbType.NVarChar,20),
                new SqlParameter("@AI004",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = num;
            parameter[1].Value = nameOf;
            parameter[2].Value = workOf;
            parameter[3].Value = colorName;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da != null && da.Rows.Count > 0 )
            {
                if ( string.IsNullOrEmpty( da.Rows[0]["AI013"].ToString( ) ) )
                    return true;
                else
                {
                    if ( da.Rows[0]["AI013"].ToString( ).Trim( ) == "T" )
                        return false;
                    else
                        return true;
                }
            }
            else
                return true;
        }
        
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT CONVERT(DECIMAL(18,0),SUM(ISNULL(PQK10,0)*ISNULL(PQK25,0)+ISNULL(PQK31,0)*ISNULL(PQK25,0))) PQK,PQK02 FROM R_PQK" );
            strSql . Append ( " WHERE PQK01=@PQK01" );
            strSql . Append ( " GROUP BY PQK02" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PQK01",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = oddNum;

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) , parameter );
        }

        /// <summary>
        /// 写数据到241
        /// </summary>
        /// <param name="modelAm"></param>
        /// <returns></returns>
        public bool UpdateOfRecevable ( MulaolaoLibrary . ProductCostSummaryLibrary modelAm , string oddNum )
        {
            ArrayList SQLString = new ArrayList ( );
            ByOneBy ( modelAm , oddNum , SQLString );
            //WriteReceivableToGeneralLedger.ByOneByChanPintZhiBao( modelAm ,oddNum ,SQLString );

            if ( modelAm . AM173 > 0 )
            {
                StringBuilder strSqlAM173 = new StringBuilder ( );
                strSqlAM173 . AppendFormat ( "UPDATE R_PQAM SET AM173='{0}' WHERE AM002='{1}'" , modelAm . AM173 , modelAm . AM002 );
                SQLString . Add ( strSqlAM173 . ToString ( ) );
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void ByOneBy ( MulaolaoLibrary . ProductCostSummaryLibrary modelAm , string oddNum , ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT AMB173 FROM R_PQAMB WHERE AMB001='{0}'" , oddNum );

            DataTable de = SqlHelper . ExecuteDataTable ( "SELECT AM173 FROM R_PQAM WHERE AM002='" + modelAm . AM002 + "'" );
            DataTable da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( da != null && da . Rows . Count > 0 )
            {
                if ( modelAm . AM173 > 0 )
                {
                    strSql = new StringBuilder ( );
                    strSql . AppendFormat ( "UPDATE R_PQAMB SET AMB173='{0}' WHERE AMB001='{1}'" , modelAm . AM173 , oddNum );
                    SQLString . Add ( strSql . ToString ( ) );
                }
               
                if ( de != null && de . Rows . Count > 0 )
                {
                    modelAm . AM173 = modelAm . AM173 - ( string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AMB173" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AMB173" ] . ToString ( ) ) );

                    modelAm . AM173 = modelAm . AM173 + ( string . IsNullOrEmpty ( de . Rows [ 0 ] [ "AM173" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ 0 ] [ "AM173" ] . ToString ( ) ) );                    
                }
            }
            else
            {
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "INSERT INTO R_PQAMB (AMB001,AMB173) VALUES ('{0}','{1}')" , oddNum , modelAm . AM173  );
                SQLString . Add ( strSql . ToString ( ) );
                if ( de != null && de . Rows . Count > 0 )
                {
                    modelAm . AM173 = modelAm . AM173 + ( string . IsNullOrEmpty ( de . Rows [ 0 ] [ "AM173" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ 0 ] [ "AM173" ] . ToString ( ) ) );                   
                }

            }
        }

        /// <summary>
        /// 是否完工
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool UpdateOver ( string num )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE R_PQK SET PQK41='完工' WHERE PQK02='{0}'" ,num );

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            return rows > 0 ? true : false;
        }

        /// <summary>
        /// 获取流水号
        /// </summary>
        /// <returns></returns>
        public DataTable getNum ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT PQK02 FROM R_PQK ORDER BY PQK02 DESC" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTableView ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "WITH CET AS (SELECT PQK01,PQK02,PQK13,PQK23,PQK14,PQK12,PQK03,PQK04,PQK05,PQK06,(SELECT RES05 FROM R_REVIEWS WHERE RES04=(SELECT MAX(RES04) FROM R_REVIEWS WHERE RES06=PQK01)) RES05,CASE WHEN (PQK09<0 OR PQK09 IS NULL) OR (PQK37<0 OR PQK37 IS NULL) OR PQK09<PQK18 OR PQK37<PQK32 THEN '未入库' WHEN PQK09=PQK18 OR PQK37=PQK32 THEN '已入库' END PQK09,PQK41,ISNULL(CONVERT(FLOAT,PQK10*PQK25+PQK31*PQK25),0) US,ISNULL(CONVERT(FLOAT,CONVERT(DECIMAL(11,1),(PQK23*PQK20*PQK21*PQK22/(PQK08*PQK19))*PQK27*PQK26/100+PQK08*PQK19*PQK20*PQK23*PQK21*PQK22*0.0001*PQK27*PQK28/100)),0) UJ FROM R_PQK WHERE {0} ) SELECT PQK01,PQK02,PQK13,PQK23,PQK14,PQK12,PQK03,PQK04,PQK05,PQK06,RES05,PQK09,PQK41,SUM(US) US,SUM(UJ) UJ FROM CET GROUP BY PQK01,PQK02,PQK13,PQK23,PQK14,PQK12,PQK03,PQK04,PQK05,PQK06,RES05,PQK09,PQK41" ,strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}

using StudentMgr;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Dao
{
    public class YouQicontractDao
    {
        /// <summary>
        /// 获取数据列表  单个字段
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT YQ99,YQ03,YQ106,YQ105,YQ107,YQ10,YQ11,YQ12,YQ119" );
            strSql.Append( " FROM R_PQI" );
            strSql.Append( " WHERE YQ99 LIKE 'R_339%'" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableOther ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT YQ99,YQ11,YQ12,YQ119" );
            strSql.Append( " FROM R_PQI" );
            strSql.Append( " WHERE YQ99 LIKE 'R_337%'" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表  供应商
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT YQ02,(SELECT DGA003 FROM TPADGA WHERE YQ02=DGA001) DGA002 FROM R_PQI" );
            strSql.Append( " WHERE YQ99 LIKE 'R_339%'" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableOnlyOther ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT YQ02,(SELECT DGA003 FROM TPADGA WHERE YQ02=DGA001) DGA002 FROM R_PQI" );
            strSql.Append( " WHERE YQ99 LIKE 'R_337%'" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetYouQiCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQI" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " WHERE " + strWhere );
            }
            strSql.Append( " AND YQ99 LIKE 'R_339%'" );

            object obj = SqlHelper.GetSingle( strSql.ToString( ) );
            if ( obj == null )
                return 0;
            else
                return Convert.ToInt32( obj );
        }
        public int GetYouQiCountOther ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQI" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " WHERE " + strWhere );
            }
            strSql.Append( " AND YQ99 LIKE 'R_337%'" );

            object obj = SqlHelper.GetSingle( strSql.ToString( ) );
            if ( obj == null )
                return 0;
            else
                return Convert.ToInt32( obj );
        }


        /// <summary>
        /// 获取总记录数  财务结账
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetYouQiCountOne ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQI TT,R_REVIEWS B WHERE TT.YQ99=B.RES06 AND RES05='执行' AND NOT EXISTS (SELECT 1 FROM R_PQAL C,R_PQAK D WHERE TT.idx=C.AL003 AND TT.YQ99=C.AL002 AND C.AL001=D.idx) AND YQ99 LIKE 'R_339%'" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " AND " + strWhere );
            }

            object obj = SqlHelper.GetSingle( strSql.ToString( ) );
            if ( obj == null )
                return 0;
            else
                return Convert.ToInt32( obj );
        }
        public int GetYouQiCountOneOther ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQI TT,R_REVIEWS B WHERE TT.YQ99=B.RES06 AND RES05='执行' AND NOT EXISTS (SELECT 1 FROM R_PQAL C,R_PQAK D WHERE TT.idx=C.AL003 AND TT.YQ99=C.AL002 AND C.AL001=D.idx) AND YQ99 LIKE 'R_337%'" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " AND " + strWhere );
            }

            object obj = SqlHelper.GetSingle( strSql.ToString( ) );
            if ( obj == null )
                return 0;
            else
                return Convert.ToInt32( obj );
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTableByPage ( string strWhere ,string orderby ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "WITH CET AS (SELECT YQ99,YQ03,YQ105,YQ106,YQ107,YQ02,(SELECT DGA003 FROM TPADGA WHERE YQ02=DGA001) DGA002,YQ10,YQ11,YQ12,YQ108,YQ13,YQ14,YQ16,YQ101,YQ109,YQ19,YQ114,YQ115,YQ112,YQ113,YQ116,YQ123,CASE WHEN YQ128='T' THEN '已入' ELSE '未入' END YQ128,(SELECT RES05 FROM R_REVIEWS WHERE RES04=(SELECT MAX(RES04) FROM R_REVIEWS WHERE RES06=YQ99)) RES05,CASE WHEN YQ16=0 THEN 0 WHEN YQ16!=0 THEN CONVERT( DECIMAL(18,0), YQ108 * YQ113 * YQ112 * YQ114 * YQ115 * YQ116 * 0.0001 ) END U01,CASE WHEN YQ114 = 0 OR YQ115 = 0 OR YQ14=0 THEN 0 WHEN YQ114 != 0 AND YQ115 != 0 AND YQ14!=0 THEN CONVERT( DECIMAL(18,0), YQ108 * YQ112 * YQ116 * YQ113 / YQ114 / YQ115 ) END U02,CASE WHEN YQ15 = 0 THEN 0 WHEN YQ15 != 0 THEN CONVERT( DECIMAL( 11, 1 ), YQ108*YQ112*YQ116*YQ113*YQ13*0.01*YQ14/YQ114/YQ115/YQ15 ) END U03,CASE WHEN YQ15 = 0 THEN 0 WHEN YQ15 != 0 THEN CONVERT( DECIMAL( 11, 1 ), YQ16 * YQ13 * 0.01 * YQ108 * YQ113 * YQ112 * YQ114 * YQ115 * YQ116 * 0.0001 / YQ15 ) END U04,ISNULL(YQ134,0) YQ134,ISNULL(YQ135,0) YQ135,YQ15,YQ04,YQ140 FROM (" );
            strSql.Append( " SELECT ROW_NUMBER() OVER(" );
            if ( !string.IsNullOrEmpty( orderby ) )
            {
                strSql.Append( "ORDER BY T." + orderby );
            }
            else
            {
                strSql.Append( "ORDER BY T.idx DESC" );
            }
            strSql.Append( " ) AS Row,T.* FROM R_PQI T" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " WHERE " + strWhere );
            }
            strSql.Append( " AND YQ99 LIKE 'R_339%'" );
            strSql.Append( " ) TT" );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}) " ,startIndex ,endIndex );
            strSql . Append ( "SELECT *,ISNULL(CASE WHEN U03=0 THEN 0 ELSE CONVERT(DECIMAL(18,4),U02/U03/2*0.85) END,0) U11,ISNULL(CASE WHEN U04=0 THEN 0 ELSE CONVERT(DECIMAL(18,4),U01/U04/2) END,0) U12 FROM CET" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableByPageOther ( string strWhere ,string orderby ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT YQ99,YQ02,(SELECT DGA003 FROM TPADGA WHERE YQ02=DGA001) DGA002,YQ04,YQ10,YQ11,YQ12,YQ15,YQ109,YQ119,CASE WHEN YQ128='T' THEN '已入' ELSE '未入' END YQ128,(SELECT RES05 FROM R_REVIEWS WHERE RES04=(SELECT MAX(RES04) FROM R_REVIEWS WHERE RES06=YQ99)) RES05,YQ04,YQ140 FROM (" );
            strSql.Append( " SELECT ROW_NUMBER() OVER(" );
            if ( !string.IsNullOrEmpty( orderby ) )
            {
                strSql.Append( "ORDER BY T." + orderby );
            }
            else
            {
                strSql.Append( "ORDER BY T.idx DESC" );
            }
            strSql.Append( " ) AS Row,T.* FROM R_PQI T" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " WHERE " + strWhere );
            }
            strSql.Append( " AND YQ99 LIKE 'R_337%'" );
            strSql.Append( " ) TT" );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTableByPage ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT TT.idx,YQ99,YQ03,YQ105,YQ106,YQ107,YQ02,(SELECT DGA003 FROM TPADGA WHERE YQ02=DGA001) DGA002,YQ10,YQ11,YQ12,YQ108,YQ13,YQ14,YQ16,YQ101,YQ109,YQ19,YQ114,YQ115,YQ112,YQ113,YQ116,YQ123,YQ13*YQ16*YQ108*YQ112*YQ113*YQ114*YQ115*YQ116*0.000001 U9,CASE WHEN YQ114=0 OR YQ115=0 THEN 0 WHEN YQ114!=0 AND YQ115!=0 THEN YQ108*YQ112*YQ113*YQ116*YQ13*YQ14*0.01/YQ114/YQ115 END U10, RES05  FROM( " );
            strSql.Append( " SELECT ROW_NUMBER() OVER(" );
            strSql.Append( "ORDER BY T.YQ99 DESC" );
            strSql.Append( " ) AS Row,T.* FROM R_PQI T" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " WHERE " + strWhere );
            }
            strSql.Append( " AND YQ99 LIKE 'R_339%'" );
            strSql.Append( " ) TT,R_REVIEWS B WHERE TT.YQ99=B.RES06 AND RES05='执行' AND NOT EXISTS (SELECT 1 FROM R_PQAL C,R_PQAK D WHERE TT.idx=C.AL003 AND TT.YQ99=C.AL002 AND C.AL001=D.idx AND (AK009-AK010-AK011-AK015)<=100)" );// AND AK009=AK011
            strSql .AppendFormat( " AND TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableByPageOther ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT TT.idx,YQ99,YQ02,(SELECT DGA003 FROM TPADGA WHERE YQ02=DGA001) DGA002,YQ10,YQ11,YQ12,YQ108,YQ13,YQ14,YQ15,YQ16,YQ101,YQ109,YQ19,YQ114,YQ115,YQ112,YQ113,YQ116,YQ123,YQ04,RES05  FROM( " );
            strSql.Append( " SELECT ROW_NUMBER() OVER(" );
            strSql.Append( "ORDER BY T.YQ99 DESC" );
            strSql.Append( " ) AS Row,T.* FROM R_PQI T" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " WHERE " + strWhere );
            }
            strSql.Append( " AND YQ99 LIKE 'R_337%'" );
            strSql.Append( " ) TT,R_REVIEWS B WHERE TT.YQ99=B.RES06 AND RES05='执行' AND NOT EXISTS (SELECT 1 FROM R_PQAL C,R_PQAK D WHERE TT.idx=C.AL003 AND TT.YQ99=C.AL002 AND C.AL001=D.idx)" );
            strSql.AppendFormat( " AND TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取联系人
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableProson ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DBA002,DBA001,DBA028 FROM TPADBA WHERE DBA028!='' AND (DBA043='F' OR DBA043='' OR DBA043 IS NULL) ORDER BY DBA001" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取生产车间
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableWork ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DBA001,DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002 IN (SELECT DBA002 FROM TPADBA WHERE DBA005=(SELECT DAA001 FROM TPADAA WHERE DAA002='生产部')) AND (DBA043='F' OR DBA043='' OR DBA043 IS NULL))" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取打印数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintOne ( string oddNum)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT YQ10,YQ11,YQ12,YQ117,YQ06,CONVERT( DECIMAL( 11, 0 ), YQ114 * YQ115 ) U0,CASE WHEN YQ16=0 THEN 0 WHEN YQ16!=0 THEN CONVERT( DECIMAL( 11, 0 ), YQ108 * YQ113 * YQ112 * YQ114 * YQ115 * YQ116 * 0.0001 ) END U1,CASE WHEN YQ114 = 0 OR YQ115 = 0 OR YQ14=0 THEN 0 WHEN YQ114 != 0 AND YQ115 != 0 AND YQ14!=0 THEN CONVERT( DECIMAL( 11, 0 ), YQ108 * YQ112 * YQ116 * YQ113 / YQ114 / YQ115 ) END U2,CONVERT(FLOAT,YQ13) YQ13,CONVERT(FLOAT,YQ14) YQ14,CONVERT(FLOAT,YQ15) YQ15, CONVERT(FLOAT,YQ16) YQ16,CASE WHEN YQ15 = 0 THEN 0 WHEN YQ15 != 0 THEN CONVERT( DECIMAL( 11, 1 ), YQ108*YQ112*YQ116*YQ113*YQ13*0.01*YQ14/YQ114/YQ115/YQ15 ) END U3,CASE WHEN YQ15 = 0 THEN 0 WHEN YQ15 != 0 THEN CONVERT( DECIMAL( 11, 1 ), YQ16 * YQ13 * 0.01 * YQ108 * YQ113 * YQ112 * YQ114 * YQ115 * YQ116 * 0.0001 / YQ15 ) END U4,CASE WHEN YQ15 = 0 THEN 0 WHEN YQ15 != 0 THEN CONVERT( DECIMAL( 11, 3 ), YQ14 / YQ15 * YQ13 ) END U5,CONVERT(FLOAT,CASE WHEN YQ15 = 0 THEN 0 WHEN YQ15 != 0 THEN CONVERT( DECIMAL( 11, 3 ),YQ16 / YQ15) END) U6,CONVERT(FLOAT,CONVERT( DECIMAL( 11, 2 ), YQ16 *YQ13*0.01 * YQ112 * YQ114 * YQ115* YQ113* YQ116 * 0.0001 )) U7,CONVERT(FLOAT,CASE WHEN YQ114 = 0 OR YQ115 = 0 THEN 0 WHEN YQ114 != 0 AND YQ115 != 0 THEN CONVERT( DECIMAL( 11, 2 ), YQ112 * YQ116 * YQ113 * YQ13 * 0.01 * YQ14 / YQ114 / YQ115 ) END) U8,YQ16 *YQ13*0.01* YQ108 * YQ112 * YQ114 * YQ115* YQ113* YQ116 * 0.0001 U9,CASE WHEN YQ114 = 0 OR YQ115 = 0 THEN 0 WHEN YQ114 != 0 AND YQ115 != 0 THEN  YQ13 * YQ14 * YQ108 * YQ112 * YQ116 * YQ113*0.01 / YQ114 / YQ115  END U10,CONVERT( VARCHAR( 20 ), YQ17, 102 ) YQ17,CONVERT( VARCHAR( 20 ), YQ18, 102 ) YQ18,YQ101 FROM R_PQI" );
            strSql.Append( " WHERE YQ99 =@YQ99" );
            SqlParameter[] parameter = {
                new SqlParameter("@YQ99",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取打印数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintTwo ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT (SELECT DBA002 FROM TPADBA WHERE YQ01=DBA001) DBA002,(SELECT DBA028 FROM TPADBA WHERE YQ01=DBA001) DBA028,(SELECT DGA003 FROM TPADGA WHERE YQ02=DGA001) DGA003,(SELECT DGA017 FROM TPADGA WHERE YQ02=DGA001) DGA017,(SELECT DGA008 FROM TPADGA WHERE YQ02=DGA001) DGA008,(SELECT DGA012 FROM TPADGA WHERE YQ02=DGA001) DGA012,(SELECT DGA009 FROM TPADGA WHERE YQ02=DGA001) DGA009,(SELECT DGA011 FROM TPADGA WHERE YQ02=DGA001) DGA011,YQ04,CONVERT(VARCHAR(20),YQ05,102) YQ05,YQ07, CONVERT( VARCHAR( 20 ), YQ08, 102 ) YQ08, YQ09, YQ105, YQ106, YQ107, YQ03, YQ108,YQ20, YQ21, YQ22, YQ23, YQ24, YQ25, YQ26, YQ27, CONVERT( VARCHAR( 20 ), YQ28, 102 ) YQ28,CASE WHEN YQ32 = 'F' AND YQ33 = 'F' AND YQ34 = 'F' AND YQ35 = 'F' THEN 'F' WHEN YQ32 = 'T' OR YQ33 = 'T' OR YQ34 = 'T' OR YQ35 = 'T' THEN 'T' END U0,YQ32, YQ33, YQ34, YQ35, YQ40, YQ31, YQ41, YQ42, YQ43, YQ45, YQ44, YQ102, YQ29, CONVERT( VARCHAR( 20 ), YQ30, 102 ) YQ30, YQ36, YQ37, YQ38, YQ39, YQ46, CONVERT( VARCHAR( 20 ), YQ47, 102 ) YQ47,YQ52, YQ53, YQ54, YQ55, YQ56, YQ57, YQ58, YQ60, YQ61, YQ62, YQ59, YQ64, YQ65, YQ66, YQ68, YQ69, YQ70, YQ67, YQ76, YQ72, YQ73, YQ74, YQ75, YQ71, YQ63, YQ51, YQ50, YQ48,CONVERT( VARCHAR( 20 ), YQ49, 102 ) YQ49, YQ77, YQ80, YQ81, YQ78, CONVERT( VARCHAR( 20 ), YQ79, 102 ) YQ79, YQ82, YQ83, YQ84, YQ85, YQ86, YQ87, YQ88, YQ89, YQ90, YQ91, YQ92, CONVERT( VARCHAR( 20 ), YQ93, 102 ) YQ93, YQ94, CONVERT( VARCHAR( 20 ), YQ95, 102 ) YQ95,YQ96,CONVERT( VARCHAR( 20 ), YQ97, 102 ) YQ97,CONVERT( VARCHAR( 20 ), YQ98, 102 ) YQ98,YQ124,YQ99,CASE WHEN YQ120='' OR YQ120 IS NULL THEN 'F' ELSE 'T' END YQ,ISNULL(YQ123,'F') YQ123 FROM R_PQI" );
            strSql.Append( " WHERE YQ99 = @YQ99" );
            SqlParameter[] parameter = {
                new SqlParameter("@YQ99",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取打印数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintThr ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT SUM(U11) U11 FROM (SELECT CASE WHEN YQ15=0 OR YQ16=0 OR YQ13=0 OR YQ108=0 OR YQ113=0 OR YQ112=0 OR YQ114=0 OR YQ115=0 OR YQ116=0 THEN 0 WHEN YQ15!=0 THEN CONVERT(DECIMAL(18,3),SUM(YQ108 * YQ113 * YQ112 * YQ114 * YQ115 * YQ116 * 0.0001)/SUM(YQ16 * YQ13 * 0.01 * YQ108 * YQ113 * YQ112 * YQ114 * YQ115 * YQ116 * 0.0001 / YQ15)) END U11 FROM R_PQI" );
            strSql.Append( " WHERE YQ99 = @YQ99 GROUP BY YQ15,YQ16,YQ13,YQ108,YQ113,YQ112,YQ114,YQ115,YQ116) A" );
            SqlParameter[] parameter = {
                 new SqlParameter("@YQ99",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        
        /// <summary>
        /// 获取464数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetDataTableYesOrNoPlan (MulaolaoLibrary.YouQiLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AC03+ISNULL(AC26,0) AC03,AC18 FROM R_PQAC WHERE AC18=(SELECT MAX(AC18) FROM R_PQAC WHERE AC04=@AC04 AND AC05=@AC05)" );
            SqlParameter[] parameter = {
                new SqlParameter("@AC04",SqlDbType.NVarChar),
                new SqlParameter("@AC05",SqlDbType.NVarChar)
            };
            parameter[0].Value = model.YQ11;
            parameter[1].Value = model.YQ12;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取464数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableYesNoAdPlan ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT SUM(AD05) AD05 FROM R_PQAD" );
            strSql.Append( " WHERE AD01=@AD01" );
            SqlParameter[] parameter = {
                new SqlParameter("@AD01",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取对比数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetDataTableContrast (MulaolaoLibrary.YouQiLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQI WHERE YQ107=@YQ107 AND YQ10=@YQ10 AND YQ11=@YQ11 AND YQ12=@YQ12 AND YQ03='' AND YQ99=(SELECT MAX(YQ99) FROM R_PQI WHERE YQ107=@YQ107 AND YQ10=@YQ10 AND YQ11=@YQ11 AND YQ12=@YQ12 AND YQ03='')" );
            SqlParameter[] parameter = {
                new SqlParameter("@YQ107",SqlDbType.NVarChar),
                new SqlParameter("@YQ10",SqlDbType.NVarChar),
                new SqlParameter("@YQ11",SqlDbType.NVarChar),
                new SqlParameter("@YQ12",SqlDbType.NVarChar)
            };
            parameter[0].Value = model.YQ107;
            parameter[1].Value = model.YQ10;
            parameter[2].Value = model.YQ11;
            parameter[3].Value = model.YQ12;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add ( MulaolaoLibrary.YouQiLibrary model ,string tableNum ,string tableName ,string logins ,string stateOf ,string stateOfOdd ,DateTime dtOne)
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQI (" );
            strSql.Append( "YQ06,YQ10,YQ11,YQ12,YQ13,YQ14,YQ15,YQ16,YQ19,YQ99,YQ101,YQ108,YQ109,YQ112,YQ113,YQ114,YQ115,YQ116,YQ117,YQ119,YQ120,YQ121,YQ02,YQ129,YQ130,YQ131,YQ132,YQ133,YQ134,YQ135)" );
            strSql.Append( " VALUES (" );
            strSql . AppendFormat ( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}')" ,model . YQ06 ,model . YQ10 ,model . YQ11 ,model . YQ12 ,model . YQ13 ,model . YQ14 ,model . YQ15 ,model . YQ16 ,model . YQ19 ,model . YQ99 ,model . YQ101 ,model . YQ108 ,model . YQ109 ,model . YQ112 ,model . YQ113 ,model . YQ114 ,model . YQ115 ,model . YQ116 ,model . YQ117 ,model . YQ119 ,model . YQ120 ,model . YQ121 ,model . YQ02 ,model . YQ129 ,model . YQ130 ,model . YQ131 ,model . YQ132 ,model . YQ133 ,model . YQ134 ,model . YQ135 );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.YQ99 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );
            if ( !string.IsNullOrEmpty( model.YQ121 ) )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAI SET AI013='T' WHERE AI001='{0}' AND AI002='{1}' AND AI005='{2}' AND AI006='{3}' AND AI011='{4}' AND AI003='{5}' AND AI004='{6}'" ,model.YQ133 ,model.YQ132 ,model.YQ120 ,model.YQ121 ,model.YQ10 ,model.YQ11 ,model.YQ12 );
                SQLString.Add( strSql.ToString( ) );
                SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.YQ99 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );
            }
            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary . YouQiLibrary model ,string tableNum ,string tableName ,string logins ,string stateOf ,string stateOfOdd ,DateTime dtOne )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQI SET " );
            strSql . AppendFormat ( "YQ02='{0}'," ,model . YQ02 );
            strSql . AppendFormat ( "YQ06='{0}'," ,model . YQ06 );
            strSql . AppendFormat ( "YQ10='{0}'," ,model . YQ10 );
            strSql . AppendFormat ( "YQ11='{0}'," ,model . YQ11 );
            strSql . AppendFormat ( "YQ12='{0}'," ,model . YQ12 );
            strSql . AppendFormat ( "YQ13='{0}'," ,model . YQ13 );
            strSql . AppendFormat ( "YQ14='{0}'," ,model . YQ14 );
            strSql . AppendFormat ( "YQ15='{0}'," ,model . YQ15 );
            strSql . AppendFormat ( "YQ16='{0}'," ,model . YQ16 );
            strSql . AppendFormat ( "YQ19='{0}'," ,model . YQ19 );
            strSql . AppendFormat ( "YQ101='{0}'," ,model . YQ101 );
            strSql . AppendFormat ( "YQ108='{0}'," ,model . YQ108 );
            strSql . AppendFormat ( "YQ109='{0}'," ,model . YQ109 );
            strSql . AppendFormat ( "YQ112='{0}'," ,model . YQ112 );
            strSql . AppendFormat ( "YQ113='{0}'," ,model . YQ113 );
            strSql . AppendFormat ( "YQ114='{0}'," ,model . YQ114 );
            strSql . AppendFormat ( "YQ115='{0}'," ,model . YQ115 );
            strSql . AppendFormat ( "YQ116='{0}'," ,model . YQ116 );
            strSql . AppendFormat ( "YQ117='{0}'," ,model . YQ117 );
            strSql . AppendFormat ( "YQ119='{0}'," ,model . YQ119 );
            strSql . AppendFormat ( "YQ120='{0}'," ,model . YQ120 );
            strSql . AppendFormat ( "YQ121='{0}'," ,model . YQ121 );
            strSql . AppendFormat ( "YQ129='{0}'," ,model . YQ129 );
            strSql . AppendFormat ( "YQ130='{0}'," ,model . YQ130 );
            strSql . AppendFormat ( "YQ131='{0}'," ,model . YQ131 );
            strSql . AppendFormat ( "YQ134='{0}'," ,model . YQ134 );
            strSql . AppendFormat ( "YQ135='{0}'" ,model . YQ135 );
            strSql . AppendFormat ( " WHERE YQ99='{1}' AND idx='{0}'" ,model . IDX ,model . YQ99 );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( tableNum ,tableName ,logins ,dtOne ,model . YQ99 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetDataTablePlan ( MulaolaoLibrary.YouQiLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AC03+ISNULL(AC26,0)-(SELECT SUM(AD05+ISNULL(AD20,0)) AD05 FROM R_PQAD  WHERE AC18=AD01) AD05  FROM R_PQAC WHERE AC18=(SELECT MAX(AC18) FROM R_PQAC WHERE AC04=@AC04 AND AC05=@AC05) GROUP BY AC03,ISNULL(AC26,0),AC18" );
            SqlParameter[] parameter = {
                new SqlParameter("@AC04",SqlDbType.NVarChar),
                new SqlParameter("@AC05",SqlDbType.NVarChar)
            };

            parameter[0].Value = model.YQ11;
            parameter[1].Value = model.YQ12;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetDataTableDwo ( MulaolaoLibrary.YouQiLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQI WHERE YQ101=@YQ101 AND YQ10=@YQ10 AND YQ11=@YQ11 AND YQ12=@YQ12 AND YQ107=@YQ107" );
            SqlParameter[] parameter = {
                new SqlParameter("@YQ101",SqlDbType.NVarChar),
                new SqlParameter("@YQ10",SqlDbType.NVarChar),
                new SqlParameter("@YQ11",SqlDbType.NVarChar),
                new SqlParameter("@YQ12",SqlDbType.NVarChar),
                new SqlParameter("@YQ107",SqlDbType.NVarChar)
            };
            parameter[0].Value = model.YQ101;
            parameter[1].Value = model.YQ10;
            parameter[2].Value = model.YQ11;
            parameter[3].Value = model.YQ12;
            parameter[4].Value = model.YQ107;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx ,string tableNum ,string tableName ,string logins ,string stateOf ,string stateOfOdd ,DateTime dtOne ,string oddNum ,string gP ,string sP ,string numOf525 ,string oddNumOf525 ,string nameOf ,string workOf ,string colorName )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQI" );
            strSql . AppendFormat ( " WHERE YQ99='{1}' AND idx='{0}'" , idx , oddNum );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );
            if ( !string.IsNullOrEmpty( gP ) )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAI SET AI013='F' WHERE AI001='{0}' AND AI002='{1}' AND AI011='{2}' AND AI003='{3}' AND AI004='{4}' AND AI005='{5}' AND AI006='{6}'" ,oddNumOf525 ,numOf525 ,nameOf ,workOf ,colorName ,gP ,sP );
                SQLString.Add( strSql.ToString( ) );
                SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableAll ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql . Append ( "WITH CET AS (" );
            strSql.Append( "SELECT idx,YQ06,YQ10,YQ11,YQ12,YQ13,YQ14,YQ15,YQ16,YQ19,YQ108,YQ109,YQ101,YQ117,YQ114,YQ115,YQ112,YQ116,YQ113,YQ119,YQ120,YQ121,YQ129,YQ130,YQ131,U1,U2,YQ134,YQ135  " );
            strSql . Append ( ",CASE WHEN YQ16=0 THEN 0 WHEN YQ16!=0 THEN CONVERT( DECIMAL(18,0), YQ108 * YQ113 * YQ112 * YQ114 * YQ115 * YQ116 * 0.0001 ) END U01,CASE WHEN YQ114 = 0 OR YQ115 = 0 OR YQ14=0 THEN 0 WHEN YQ114 != 0 AND YQ115 != 0 AND YQ14!=0 THEN CONVERT( DECIMAL(18,0), YQ108 * YQ112 * YQ116 * YQ113 / YQ114 / YQ115 ) END U02,CASE WHEN YQ15 = 0 THEN 0 WHEN YQ15 != 0 THEN CONVERT( DECIMAL( 11, 1 ), YQ108*YQ112*YQ116*YQ113*YQ13*0.01*YQ14/YQ114/YQ115/YQ15 ) END U03,CASE WHEN YQ15 = 0 THEN 0 WHEN YQ15 != 0 THEN CONVERT( DECIMAL( 11, 1 ), YQ16 * YQ13 * 0.01 * YQ108 * YQ113 * YQ112 * YQ114 * YQ115 * YQ116 * 0.0001 / YQ15 ) END U04 " );
            strSql . Append ( "FROM R_PQI" );
            strSql.Append( " WHERE YQ99 =@YQ99 " );
            strSql . Append ( ") SELECT *,CASE WHEN U03=0 THEN 0 ELSE CONVERT(DECIMAL(18,4),U02/U03/2*0.85) END U11,CASE WHEN U04=0 THEN 0 ELSE CONVERT(DECIMAL(18,4),U01/U04/2) END U12 FROM CET " );
            strSql . Append ( "ORDER BY idx DESC" );
            SqlParameter[] parameter = {
                new SqlParameter("@YQ99",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 批量编辑
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateBatch ( string oddNum ,long numBer ,string tableNum ,string tableName ,string logins ,string stateOf ,string stateOfOdd ,DateTime dtOne )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQI SET YQ108=@YQ108" );
            strSql.Append( " WHERE YQ99=@YQ99" );
            SqlParameter[] parameter = {
                new SqlParameter("@YQ99",SqlDbType.NVarChar),
                new SqlParameter("@YQ108",SqlDbType.BigInt)
            };

            parameter[0].Value = oddNum;
            parameter[1].Value = numBer;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
            {
                StringBuilder strSq = new StringBuilder( );
                strSq.Append( "UPDATE R_PQI SET YQ109=(SELECT CASE WHEN YQ14=0 THEN CASE WHEN YQ15=0 THEN 0 ELSE CONVERT(DECIMAL(10,1),YQ108*YQ112*YQ114*YQ115*YQ116*YQ113*0.0001*YQ13*0.01*YQ16/YQ15) END WHEN YQ16=0 THEN CASE WHEN YQ15=0 OR YQ114=0 OR YQ115=0 THEN 0 ELSE CONVERT(DECIMAL(10,1),YQ108*YQ112*YQ116*YQ113*YQ13*0.01*YQ14/YQ15/YQ114/YQ115) END END YQ)" );
                strSq.AppendFormat( " WHERE YQ99='{0}'" ,oddNum );

                SQLString.Add( strSq.ToString( ) );
                SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSq.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

                return SqlHelper.ExecuteSqlTran( SQLString );
            }
            else
                return false;
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.YouQiLibrary GetModel ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,YQ02,YQ06,YQ10,YQ11,YQ12,YQ13,YQ14,YQ15,YQ16,YQ19,YQ100,YQ108,YQ109,YQ101,YQ117,YQ114,YQ115,YQ112,YQ116,YQ113,YQ119,YQ120,YQ121,YQ129,YQ130,YQ131,YQ99,YQ132,YQ133,YQ134,YQ135 FROM R_PQI" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };

            parameter[0].Value = idx;

            DataTable dt = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( dt.Rows.Count > 0 )
                return GetDataRow( dt.Rows[0] );
            else
                return null;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.YouQiLibrary GetDataRow ( DataRow row )
        {
            MulaolaoLibrary.YouQiLibrary model = new MulaolaoLibrary.YouQiLibrary( );

            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    model.IDX = int.Parse( row["idx"].ToString( ) );
                if ( row["YQ02"] != null && row["YQ02"].ToString( ) != "" )
                    model.YQ02 = row["YQ02"].ToString( );
                if ( row["YQ06"] != null && row["YQ06"].ToString( ) != "" )
                    model.YQ06 = row["YQ06"].ToString( );
                if ( row["YQ10"] != null && row["YQ10"].ToString( ) != "" )
                    model.YQ10 = row["YQ10"].ToString( );
                if ( row["YQ11"] != null && row["YQ11"].ToString( ) != "" )
                    model.YQ11 = row["YQ11"].ToString( );
                if ( row["YQ12"] != null && row["YQ12"].ToString( ) != "" )
                    model.YQ12 = row["YQ12"].ToString( );
                if ( row["YQ13"] != null && row["YQ13"].ToString( ) != "" )
                    model.YQ13 = decimal.Parse( row["YQ13"].ToString( ) );
                if ( row["YQ14"] != null && row["YQ14"].ToString( ) != "" )
                    model.YQ14 = decimal.Parse( row["YQ14"].ToString( ) );
                if ( row["YQ15"] != null && row["YQ15"].ToString( ) != "" )
                    model.YQ15 = decimal.Parse( row["YQ15"].ToString( ) );
                if ( row["YQ16"] != null && row["YQ16"].ToString( ) != "" )
                    model.YQ16 = decimal.Parse( row["YQ16"].ToString( ) );
                if ( row["YQ19"] != null && row["YQ19"].ToString( ) != "" )
                    model.YQ19 = decimal.Parse( row["YQ19"].ToString( ) );
                if ( row [ "YQ100" ] != null && row [ "YQ100" ] . ToString ( ) != "" )
                    model . YQ100 = row [ "YQ100" ] . ToString ( );
                if ( row["YQ99"] != null && row["YQ99"].ToString( ) != "" )
                    model.YQ99 = row["YQ99"].ToString( );
                if ( row["YQ108"] != null && row["YQ108"].ToString( ) != "" )
                    model.YQ108 = int.Parse( row["YQ108"].ToString( ) );
                if ( row["YQ109"] != null && row["YQ109"].ToString( ) != "" )
                    model.YQ109 = decimal.Parse( row["YQ109"].ToString( ) );
                if ( row["YQ101"] != null && row["YQ101"].ToString( ) != "" )
                    model.YQ101 = row["YQ101"].ToString( );
                if ( row["YQ112"] != null && row["YQ112"].ToString( ) != "" )
                    model.YQ112 = int.Parse( row["YQ112"].ToString( ) );
                if ( row["YQ113"] != null && row["YQ113"].ToString( ) != "" )
                    model.YQ113 = int.Parse( row["YQ113"].ToString( ) );
                if ( row["YQ114"] != null && row["YQ114"].ToString( ) != "" )
                    model.YQ114 = int.Parse( row["YQ114"].ToString( ) );
                if ( row["YQ115"] != null && row["YQ115"].ToString( ) != "" )
                    model.YQ115 = decimal.Parse( row["YQ115"].ToString( ) );
                if ( row["YQ116"] != null && row["YQ116"].ToString( ) != "" )
                    model.YQ116 = int.Parse( row["YQ116"].ToString( ) );
                if ( row["YQ117"] != null && row["YQ117"].ToString( ) != "" )
                    model.YQ117 = row["YQ117"].ToString( );
                if ( row["YQ119"] != null && row["YQ119"].ToString( ) != "" )
                    model.YQ119 = row["YQ119"].ToString( );
                if ( row["YQ120"] != null && row["YQ120"].ToString( ) != "" )
                    model.YQ120 = row["YQ120"].ToString( );
                if ( row["YQ121"] != null && row["YQ121"].ToString( ) != "" )
                    model.YQ121 = row["YQ121"].ToString( );
                if ( row["YQ129"] != null && row["YQ129"].ToString( ) != "" )
                    model.YQ129 = row["YQ129"].ToString( );
                if ( row["YQ130"] != null && row["YQ130"].ToString( ) != "" )
                    model.YQ130 = row["YQ130"].ToString( );
                if ( row["YQ131"] != null && row["YQ131"].ToString( ) != "" )
                    model.YQ131 = row["YQ131"].ToString( );
                if ( row["YQ132"] != null && row["YQ132"].ToString( ) != "" )
                    model.YQ132 = row["YQ132"].ToString( );
                if ( row["YQ133"] != null && row["YQ133"].ToString( ) != "" )
                    model.YQ133 = row["YQ133"].ToString( );
                if ( row [ "YQ134" ] != null && row [ "YQ134" ] . ToString ( ) != "" )
                    model . YQ134 = Convert . ToDecimal ( row [ "YQ134" ] . ToString ( ) );
                if ( row [ "YQ135" ] != null && row [ "YQ135" ] . ToString ( ) != "" )
                    model . YQ135 = Convert . ToDecimal ( row [ "YQ135" ] . ToString ( ) );
            }

            return model;
        }

        /// <summary>
        /// 是否执行
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public bool ExistsReview ( string oddNum ,string tableName )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_REVIEWS" );
            strSql.Append( " WHERE RES05='执行' AND RES01=@RES01 AND RES06=@RES06" );
            SqlParameter[] parameter = {
                new SqlParameter("@RES01",SqlDbType.NVarChar),
                new SqlParameter("@RES06",SqlDbType.NVarChar)
            };
            parameter[0].Value = tableName;
            parameter[1].Value = oddNum;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DeleteOddNum ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            UpdateOf525( strSql ,SQLString ,oddNum );
            strSql.Append( "DELETE FROM R_PQI" );
            strSql.AppendFormat( " WHERE YQ99='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            StringBuilder strSq = new StringBuilder( );
            strSq.Append( "DELETE FROM R_REVIEWS" );
            strSq.AppendFormat( " WHERE RES01='{0}' AND RES06='{1}'" ,tableNum ,oddNum );
            SQLString.Add( strSq.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        void UpdateOf525 ( StringBuilder strSql ,ArrayList SQLString ,string oddNum )
        {
            strSql = new StringBuilder( );
            strSql.AppendFormat( "SELECT YQ120,YQ121,YQ132,YQ133,YQ10,YQ11,YQ12 FROM R_PQI WHERE YQ99='" + oddNum + "' AND (YQ133!='' OR YQ133 IS NOT NULL)" );
            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            if ( da != null && da.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < da.Rows.Count ; i++ )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAI SET AI013='F' WHERE AI001='{0}' AND AI002='{1}' AND AI011='{2}' AND AI003='{3}' AND AI004='{4}' AND AI005='{5}' AND AI006='{6}'" ,da.Rows[i]["YQ133"].ToString() ,da.Rows[i]["YQ132"].ToString( ) ,da.Rows[i]["YQ10"].ToString( ) ,da.Rows[i]["YQ11"].ToString( ) ,da.Rows[i]["YQ12"].ToString( ) ,da.Rows[i]["YQ120"].ToString( ) ,da.Rows[i]["YQ121"].ToString( ) );
                    SQLString.Add( strSql.ToString( ) );
                }
            }
        }

        /// <summary>
        /// 删除送审记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public bool DeleteReview ( string oddNum ,string tableName )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_REVIEWS" );
            strSql.Append( " WHERE RES01=@RES01 AND RES06=@RES06" );
            SqlParameter[] parameter = {
                new SqlParameter("@RES01",SqlDbType.NVarChar),
                new SqlParameter("@RES06",SqlDbType.NVarChar)
            };

            parameter[0].Value = tableName;
            parameter[1].Value = oddNum;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }
        public bool EditOfSign (string odd )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAC SET AC17='F' WHERE AC16 LIKE '" + odd + "'" );

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateMain ( MulaolaoLibrary.YouQiLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQI SET " );
            strSql.Append( "YQ01=@YQ01," );
            strSql.Append( "YQ02=@YQ02," );
            strSql.Append( "YQ03=@YQ03," );
            strSql.Append( "YQ04=@YQ04," );
            strSql.Append( "YQ05=@YQ05," );
            strSql.Append( "YQ07=@YQ07," );
            strSql.Append( "YQ08=@YQ08," );
            strSql.Append( "YQ09=@YQ09," );
            strSql.Append( "YQ17=@YQ17," );
            strSql.Append( "YQ18=@YQ18," );
            strSql.Append( "YQ20=@YQ20," );
            strSql.Append( "YQ21=@YQ21," );
            strSql.Append( "YQ22=@YQ22," );
            strSql.Append( "YQ23=@YQ23," );
            strSql.Append( "YQ24=@YQ24," );
            strSql.Append( "YQ25=@YQ25," );
            strSql.Append( "YQ26=@YQ26," );
            strSql.Append( "YQ27=@YQ27," );
            strSql.Append( "YQ28=@YQ28," );
            strSql.Append( "YQ29=@YQ29," );
            strSql.Append( "YQ30=@YQ30," );
            strSql.Append( "YQ31=@YQ31," );
            strSql.Append( "YQ32=@YQ32," );
            strSql.Append( "YQ33=@YQ33," );
            strSql.Append( "YQ34=@YQ34," );
            strSql.Append( "YQ35=@YQ35," );
            strSql.Append( "YQ36=@YQ36," );
            strSql.Append( "YQ37=@YQ37," );
            strSql.Append( "YQ38=@YQ38," );
            strSql.Append( "YQ39=@YQ39," );
            strSql.Append( "YQ40=@YQ40," );
            strSql.Append( "YQ41=@YQ41," );
            strSql.Append( "YQ42=@YQ42," );
            strSql.Append( "YQ43=@YQ43," );
            strSql.Append( "YQ44=@YQ44," );
            strSql.Append( "YQ45=@YQ45," );
            strSql.Append( "YQ46=@YQ46," );
            strSql.Append( "YQ47=@YQ47," );
            strSql.Append( "YQ48=@YQ48," );
            strSql.Append( "YQ49=@YQ49," );
            strSql.Append( "YQ50=@YQ50," );
            strSql.Append( "YQ51=@YQ51," );
            strSql.Append( "YQ52=@YQ52," );
            strSql.Append( "YQ53=@YQ53," );
            strSql.Append( "YQ54=@YQ54," );
            strSql.Append( "YQ55=@YQ55," );
            strSql.Append( "YQ56=@YQ56," );
            strSql.Append( "YQ57=@YQ57," );
            strSql.Append( "YQ58=@YQ58," );
            strSql.Append( "YQ59=@YQ59," );
            strSql.Append( "YQ60=@YQ60," );
            strSql.Append( "YQ61=@YQ61," );
            strSql.Append( "YQ62=@YQ62," );
            strSql.Append( "YQ63=@YQ63," );
            strSql.Append( "YQ64=@YQ64," );
            strSql.Append( "YQ65=@YQ65," );
            strSql.Append( "YQ66=@YQ66," );
            strSql.Append( "YQ67=@YQ67," );
            strSql.Append( "YQ68=@YQ68," );
            strSql.Append( "YQ69=@YQ69," );
            strSql.Append( "YQ70=@YQ70," );
            strSql.Append( "YQ71=@YQ71," );
            strSql.Append( "YQ72=@YQ72," );
            strSql.Append( "YQ73=@YQ73," );
            strSql.Append( "YQ74=@YQ74," );
            strSql.Append( "YQ75=@YQ75," );
            strSql.Append( "YQ76=@YQ76," );
            strSql.Append( "YQ77=@YQ77," );
            strSql.Append( "YQ78=@YQ78," );
            strSql.Append( "YQ79=@YQ79," );
            strSql.Append( "YQ80=@YQ80," );
            strSql.Append( "YQ81=@YQ81," );
            strSql.Append( "YQ82=@YQ82," );
            strSql.Append( "YQ83=@YQ83," );
            strSql.Append( "YQ84=@YQ84," );
            strSql.Append( "YQ85=@YQ85," );
            strSql.Append( "YQ86=@YQ86," );
            strSql.Append( "YQ87=@YQ87," );
            strSql.Append( "YQ88=@YQ88," );
            strSql.Append( "YQ89=@YQ89," );
            strSql.Append( "YQ90=@YQ90," );
            strSql.Append( "YQ91=@YQ91," );
            strSql.Append( "YQ92=@YQ92," );
            strSql.Append( "YQ93=@YQ93," );
            strSql.Append( "YQ94=@YQ94," );
            strSql.Append( "YQ95=@YQ95," );
            strSql.Append( "YQ96=@YQ96," );
            strSql.Append( "YQ97=@YQ97," );
            strSql.Append( "YQ98=@YQ98," );
            strSql.Append( "YQ102=@YQ102," );
            strSql.Append( "YQ103=@YQ103," );
            strSql.Append( "YQ104=@YQ104," );
            strSql.Append( "YQ105=@YQ105," );
            strSql.Append( "YQ106=@YQ106," );
            strSql.Append( "YQ107=@YQ107," );
            strSql.Append( "YQ111=@YQ111," );
            strSql.Append( "YQ123=@YQ123," );
            strSql.Append( "YQ124=@YQ124" );
            strSql.Append( " WHERE YQ99=@YQ99" );
            SqlParameter[] parameter = {
                new SqlParameter("@YQ01",SqlDbType.NVarChar),
                new SqlParameter("@YQ02",SqlDbType.NVarChar),
                new SqlParameter("@YQ03",SqlDbType.NVarChar),
                new SqlParameter("@YQ04",SqlDbType.NVarChar),
                new SqlParameter("@YQ05",SqlDbType.Date),
                //new SqlParameter("@YQ06",SqlDbType.NVarChar),
                new SqlParameter("@YQ07",SqlDbType.NVarChar),
                new SqlParameter("@YQ08",SqlDbType.Date),
                new SqlParameter("@YQ09",SqlDbType.NVarChar),
                new SqlParameter("@YQ17",SqlDbType.Date),
                new SqlParameter("@YQ18",SqlDbType.Date),
                new SqlParameter("@YQ20",SqlDbType.NVarChar),
                new SqlParameter("@YQ21",SqlDbType.NVarChar),
                new SqlParameter("@YQ22",SqlDbType.NVarChar),
                new SqlParameter("@YQ23",SqlDbType.NVarChar),
                new SqlParameter("@YQ24",SqlDbType.NVarChar),
                new SqlParameter("@YQ25",SqlDbType.NVarChar),
                new SqlParameter("@YQ26",SqlDbType.NVarChar),
                new SqlParameter("@YQ27",SqlDbType.NVarChar),
                new SqlParameter("@YQ28",SqlDbType.Date),
                new SqlParameter("@YQ29",SqlDbType.NVarChar),
                new SqlParameter("@YQ30",SqlDbType.Date),
                new SqlParameter("@YQ31",SqlDbType.NVarChar),
                new SqlParameter("@YQ32",SqlDbType.NVarChar),
                new SqlParameter("@YQ33",SqlDbType.NVarChar),
                new SqlParameter("@YQ34",SqlDbType.NVarChar),
                new SqlParameter("@YQ35",SqlDbType.NVarChar),
                new SqlParameter("@YQ36",SqlDbType.NVarChar),
                new SqlParameter("@YQ37",SqlDbType.NVarChar),
                new SqlParameter("@YQ38",SqlDbType.NVarChar),
                new SqlParameter("@YQ39",SqlDbType.NVarChar),
                new SqlParameter("@YQ40",SqlDbType.NVarChar),
                new SqlParameter("@YQ41",SqlDbType.NVarChar),
                new SqlParameter("@YQ42",SqlDbType.NVarChar),
                new SqlParameter("@YQ43",SqlDbType.NVarChar),
                new SqlParameter("@YQ44",SqlDbType.NVarChar),
                new SqlParameter("@YQ45",SqlDbType.NVarChar),
                new SqlParameter("@YQ46",SqlDbType.NVarChar),
                new SqlParameter("@YQ47",SqlDbType.Date),
                new SqlParameter("@YQ48",SqlDbType.NVarChar),
                new SqlParameter("@YQ49",SqlDbType.Date),
                new SqlParameter("@YQ50",SqlDbType.NVarChar),
                new SqlParameter("@YQ51",SqlDbType.NVarChar),
                new SqlParameter("@YQ52",SqlDbType.NVarChar),
                new SqlParameter("@YQ53",SqlDbType.NVarChar),
                new SqlParameter("@YQ54",SqlDbType.NVarChar),
                new SqlParameter("@YQ55",SqlDbType.NVarChar),
                new SqlParameter("@YQ56",SqlDbType.NVarChar),
                new SqlParameter("@YQ57",SqlDbType.NVarChar),
                new SqlParameter("@YQ58",SqlDbType.NVarChar),
                new SqlParameter("@YQ59",SqlDbType.NVarChar),
                new SqlParameter("@YQ60",SqlDbType.NVarChar),
                new SqlParameter("@YQ61",SqlDbType.NVarChar),
                new SqlParameter("@YQ62",SqlDbType.NVarChar),
                new SqlParameter("@YQ63",SqlDbType.NVarChar),
                new SqlParameter("@YQ64",SqlDbType.NVarChar),
                new SqlParameter("@YQ65",SqlDbType.NVarChar),
                new SqlParameter("@YQ66",SqlDbType.NVarChar),
                new SqlParameter("@YQ67",SqlDbType.NVarChar),
                new SqlParameter("@YQ68",SqlDbType.NVarChar),
                new SqlParameter("@YQ69",SqlDbType.NVarChar),
                new SqlParameter("@YQ70",SqlDbType.NVarChar),
                new SqlParameter("@YQ71",SqlDbType.NVarChar),
                new SqlParameter("@YQ72",SqlDbType.NVarChar),
                new SqlParameter("@YQ73",SqlDbType.NVarChar),
                new SqlParameter("@YQ74",SqlDbType.NVarChar),
                new SqlParameter("@YQ75",SqlDbType.NVarChar),
                new SqlParameter("@YQ76",SqlDbType.NVarChar),
                new SqlParameter("@YQ77",SqlDbType.BigInt),
                new SqlParameter("@YQ78",SqlDbType.NVarChar),
                new SqlParameter("@YQ79",SqlDbType.Date),
                new SqlParameter("@YQ80",SqlDbType.NVarChar),
                new SqlParameter("@YQ81",SqlDbType.NVarChar),
                new SqlParameter("@YQ82",SqlDbType.BigInt),
                new SqlParameter("@YQ83",SqlDbType.BigInt),
                new SqlParameter("@YQ84",SqlDbType.BigInt),
                new SqlParameter("@YQ85",SqlDbType.BigInt),
                new SqlParameter("@YQ86",SqlDbType.BigInt),
                new SqlParameter("@YQ87",SqlDbType.BigInt),
                new SqlParameter("@YQ88",SqlDbType.BigInt),
                new SqlParameter("@YQ89",SqlDbType.BigInt),
                new SqlParameter("@YQ90",SqlDbType.BigInt),
                new SqlParameter("@YQ91",SqlDbType.NVarChar),
                new SqlParameter("@YQ92",SqlDbType.NVarChar),
                new SqlParameter("@YQ93",SqlDbType.Date),
                new SqlParameter("@YQ94",SqlDbType.NVarChar),
                new SqlParameter("@YQ95",SqlDbType.Date),
                new SqlParameter("@YQ96",SqlDbType.NVarChar),
                new SqlParameter("@YQ97",SqlDbType.Date),
                new SqlParameter("@YQ98",SqlDbType.Date),
                new SqlParameter("@YQ102",SqlDbType.NVarChar),
                new SqlParameter("@YQ103",SqlDbType.NVarChar),
                new SqlParameter("@YQ104",SqlDbType.NVarChar),
                new SqlParameter("@YQ105",SqlDbType.NVarChar),
                new SqlParameter("@YQ106",SqlDbType.NVarChar),
                new SqlParameter("@YQ107",SqlDbType.NVarChar),
                new SqlParameter("@YQ111",SqlDbType.NVarChar),
                new SqlParameter("@YQ123",SqlDbType.NChar),
                new SqlParameter("@YQ124",SqlDbType.NVarChar),
                new SqlParameter("@YQ99",SqlDbType.NVarChar)
            };
            parameter[0].Value = model.YQ01;
            parameter[1].Value = model.YQ02;
            parameter[2].Value = model.YQ03;
            parameter[3].Value = model.YQ04;
            parameter[4].Value = model.YQ05;
            //parameter[5].Value = model.YQ06;
            parameter[5].Value = model.YQ07;
            parameter[6].Value = model.YQ08;
            parameter[7].Value = model.YQ09;
            parameter[8].Value = model.YQ17;
            parameter[9].Value = model.YQ18;
            parameter[10].Value = model.YQ20;
            parameter[11].Value = model.YQ21;
            parameter[12].Value = model.YQ22;
            parameter[13].Value = model.YQ23;
            parameter[14].Value = model.YQ24;
            parameter[15].Value = model.YQ25;
            parameter[16].Value = model.YQ26;
            parameter[17].Value = model.YQ27;
            parameter[18].Value = model.YQ28;
            parameter[19].Value = model.YQ29;
            parameter[20].Value = model.YQ30;
            parameter[21].Value = model.YQ31;
            parameter[22].Value = model.YQ32;
            parameter[23].Value = model.YQ33;
            parameter[24].Value = model.YQ34;
            parameter[25].Value = model.YQ35;
            parameter[26].Value = model.YQ36;
            parameter[27].Value = model.YQ37;
            parameter[28].Value = model.YQ38;
            parameter[29].Value = model.YQ39;
            parameter[30].Value = model.YQ40;
            parameter[31].Value = model.YQ41;
            parameter[32].Value = model.YQ42;
            parameter[33].Value = model.YQ43;
            parameter[34].Value = model.YQ44;
            parameter[35].Value = model.YQ45;
            parameter[36].Value = model.YQ46;
            parameter[37].Value = model.YQ47;
            parameter[38].Value = model.YQ48;
            parameter[39].Value = model.YQ49;
            parameter[40].Value = model.YQ50;
            parameter[41].Value = model.YQ51;
            parameter[42].Value = model.YQ52;
            parameter[43].Value = model.YQ53;
            parameter[44].Value = model.YQ54;
            parameter[45].Value = model.YQ55;
            parameter[46].Value = model.YQ56;
            parameter[47].Value = model.YQ57;
            parameter[48].Value = model.YQ58;
            parameter[49].Value = model.YQ59;
            parameter[50].Value = model.YQ60;
            parameter[51].Value = model.YQ61;
            parameter[52].Value = model.YQ62;
            parameter[53].Value = model.YQ63;
            parameter[54].Value = model.YQ64;
            parameter[55].Value = model.YQ65;
            parameter[56].Value = model.YQ66;
            parameter[57].Value = model.YQ67;
            parameter[58].Value = model.YQ68;
            parameter[59].Value = model.YQ69;
            parameter[60].Value = model.YQ70;
            parameter[61].Value = model.YQ71;
            parameter[62].Value = model.YQ72;
            parameter[63].Value = model.YQ73;
            parameter[64].Value = model.YQ74;
            parameter[65].Value = model.YQ75;
            parameter[66].Value = model.YQ76;
            parameter[67].Value = model.YQ77;
            parameter[68].Value = model.YQ78;
            parameter[69].Value = model.YQ79;
            parameter[70].Value = model.YQ80;
            parameter[71].Value = model.YQ81;
            parameter[72].Value = model.YQ82;
            parameter[73].Value = model.YQ83;
            parameter[74].Value = model.YQ84;
            parameter[75].Value = model.YQ85;
            parameter[76].Value = model.YQ86;
            parameter[77].Value = model.YQ87;
            parameter[78].Value = model.YQ88;
            parameter[79].Value = model.YQ89;
            parameter[80].Value = model.YQ90;
            parameter[81].Value = model.YQ91;
            parameter[82].Value = model.YQ92;
            parameter[83].Value = model.YQ93;
            parameter[84].Value = model.YQ94;
            parameter[85].Value = model.YQ95;
            parameter[86].Value = model.YQ96;
            parameter[87].Value = model.YQ97;
            parameter[88].Value = model.YQ98;
            parameter[89].Value = model.YQ102;
            parameter[90].Value = model.YQ103;
            parameter[91].Value = model.YQ104;
            parameter[92].Value = model.YQ105;
            parameter[93].Value = model.YQ106;
            parameter[94].Value = model.YQ107;
            parameter[95].Value = model.YQ111;
            parameter[96].Value = model.YQ123;
            parameter[97].Value = model.YQ124;
            parameter[98].Value = model.YQ99;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }
        public bool UpdatePlan ( MulaolaoLibrary.YouQiLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQI SET " );
            strSql.AppendFormat( "YQ01='{0}'," ,model.YQ01 );
            strSql.AppendFormat( "YQ02='{0}'," ,model.YQ02 );
            strSql.AppendFormat( "YQ04='{0}'," ,model.YQ04 );
            strSql.AppendFormat( "YQ05='{0}'," ,model.YQ05 );
            strSql.AppendFormat( "YQ07='{0}'," ,model.YQ07 );
            strSql.AppendFormat( "YQ08='{0}'," ,model.YQ08 );
            strSql.AppendFormat( "YQ09='{0}'," ,model.YQ09 );
            strSql.AppendFormat( "YQ17='{0}'," ,model.YQ17 );
            strSql.AppendFormat( "YQ18='{0}'," ,model.YQ18 );
            strSql.AppendFormat( "YQ22='{0}'," ,model.YQ22 );
            strSql.AppendFormat( "YQ23='{0}'," ,model.YQ23 );
            strSql.AppendFormat( "YQ24='{0}'," ,model.YQ24 );
            strSql.AppendFormat( "YQ25='{0}'," ,model.YQ25 );
            strSql.AppendFormat( "YQ26='{0}'," ,model.YQ26 );
            strSql.AppendFormat( "YQ27='{0}'," ,model.YQ27 );
            strSql.AppendFormat( "YQ28='{0}'," ,model.YQ28 );
            strSql.AppendFormat( "YQ29='{0}'," ,model.YQ29 );
            strSql.AppendFormat( "YQ30='{0}'," ,model.YQ30 );
            strSql.AppendFormat( "YQ31='{0}'," ,model.YQ31 );
            strSql.AppendFormat( "YQ32='{0}'," ,model.YQ32 );
            strSql.AppendFormat( "YQ33='{0}'," ,model.YQ33 );
            strSql.AppendFormat( "YQ34='{0}'," ,model.YQ34 );
            strSql.AppendFormat( "YQ35='{0}'," ,model.YQ35 );
            strSql.AppendFormat( "YQ36='{0}'," ,model.YQ36 );
            strSql.AppendFormat( "YQ37='{0}'," ,model.YQ37 );
            strSql.AppendFormat( "YQ38='{0}'," ,model.YQ38 );
            strSql.AppendFormat( "YQ39='{0}'," ,model.YQ39 );
            strSql.AppendFormat( "YQ40='{0}'," ,model.YQ40 );
            strSql.AppendFormat( "YQ41='{0}'," ,model.YQ41 );
            strSql.AppendFormat( "YQ42='{0}'," ,model.YQ42 );
            strSql.AppendFormat( "YQ43='{0}'," ,model.YQ43 );
            strSql.AppendFormat( "YQ44='{0}'," ,model.YQ44 );
            strSql.AppendFormat( "YQ45='{0}'," ,model.YQ45 );
            strSql.AppendFormat( "YQ46='{0}'," ,model.YQ46 );
            strSql.AppendFormat( "YQ47='{0}'," ,model.YQ47 );
            strSql.AppendFormat( "YQ48='{0}'," ,model.YQ48 );
            strSql.AppendFormat( "YQ49='{0}'," ,model.YQ49 );
            strSql.AppendFormat( "YQ50='{0}'," ,model.YQ50 );
            strSql.AppendFormat( "YQ51='{0}'," ,model.YQ51 );
            strSql.AppendFormat( "YQ52='{0}'," ,model.YQ52 );
            strSql.AppendFormat( "YQ53='{0}'," ,model.YQ53 );
            strSql.AppendFormat( "YQ54='{0}'," ,model.YQ54 );
            strSql.AppendFormat( "YQ55='{0}'," ,model.YQ55 );
            strSql.AppendFormat( "YQ56='{0}'," ,model.YQ56 );
            strSql.AppendFormat( "YQ57='{0}'," ,model.YQ57 );
            strSql.AppendFormat( "YQ58='{0}'," ,model.YQ58 );
            strSql.AppendFormat( "YQ59='{0}'," ,model.YQ59 );
            strSql.AppendFormat( "YQ60='{0}'," ,model.YQ60 );
            strSql.AppendFormat( "YQ61='{0}'," ,model.YQ61 );
            strSql.AppendFormat( "YQ62='{0}'," ,model.YQ62 );
            strSql.AppendFormat( "YQ63='{0}'," ,model.YQ63 );
            strSql.AppendFormat( "YQ64='{0}'," ,model.YQ64 );
            strSql.AppendFormat( "YQ65='{0}'," ,model.YQ65 );
            strSql.AppendFormat( "YQ66='{0}'," ,model.YQ66 );
            strSql.AppendFormat( "YQ67='{0}'," ,model.YQ67 );
            strSql.AppendFormat( "YQ68='{0}'," ,model.YQ68 );
            strSql.AppendFormat( "YQ69='{0}'," ,model.YQ69 );
            strSql.AppendFormat( "YQ70='{0}'," ,model.YQ70 );
            strSql.AppendFormat( "YQ71='{0}'," ,model.YQ71 );
            strSql.AppendFormat( "YQ72='{0}'," ,model.YQ72 );
            strSql.AppendFormat( "YQ73='{0}'," ,model.YQ73 );
            strSql.AppendFormat( "YQ74='{0}'," ,model.YQ74 );
            strSql.AppendFormat( "YQ75='{0}'," ,model.YQ75 );
            strSql.AppendFormat( "YQ76='{0}'," ,model.YQ76 );
            strSql.AppendFormat( "YQ77='{0}'," ,model.YQ77 );
            strSql.AppendFormat( "YQ78='{0}'," ,model.YQ78 );
            strSql.AppendFormat( "YQ79='{0}'," ,model.YQ79 );
            strSql.AppendFormat( "YQ80='{0}'," ,model.YQ80 );
            strSql.AppendFormat( "YQ81='{0}'," ,model.YQ81 );
            strSql.AppendFormat( "YQ82='{0}'," ,model.YQ82 );
            strSql.AppendFormat( "YQ83='{0}'," ,model.YQ83 );
            strSql.AppendFormat( "YQ84='{0}'," ,model.YQ84 );
            strSql.AppendFormat( "YQ85='{0}'," ,model.YQ85 );
            strSql.AppendFormat( "YQ86='{0}'," ,model.YQ86 );
            strSql.AppendFormat( "YQ87='{0}'," ,model.YQ87 );
            strSql.AppendFormat( "YQ88='{0}'," ,model.YQ88 );
            strSql.AppendFormat( "YQ89='{0}'," ,model.YQ89 );
            strSql.AppendFormat( "YQ90='{0}'," ,model.YQ90 );
            strSql.AppendFormat( "YQ91='{0}'," ,model.YQ91 );
            strSql.AppendFormat( "YQ92='{0}'," ,model.YQ92 );
            strSql.AppendFormat( "YQ93='{0}'," ,model.YQ93 );
            strSql.AppendFormat( "YQ94='{0}'," ,model.YQ94 );
            strSql.AppendFormat( "YQ95='{0}'," ,model.YQ95 );
            strSql.AppendFormat( "YQ96='{0}'," ,model.YQ96 );
            strSql.AppendFormat( "YQ97='{0}'," ,model.YQ97 );
            strSql.AppendFormat( "YQ98='{0}'," ,model.YQ98 );
            strSql.AppendFormat( "YQ102='{0}'," ,model.YQ102 );
            strSql.AppendFormat( "YQ103='{0}'," ,model.YQ103 );
            strSql.AppendFormat( "YQ104='{0}'," ,model.YQ104 );
            strSql.AppendFormat( "YQ110='{0}'," ,model.YQ110 );
            strSql.AppendFormat( "YQ111='{0}'" ,model.YQ111 );
            strSql.AppendFormat( " WHERE YQ99='{0}'" ,model.YQ99 );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.YQ99 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );
            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableMain ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQI" );
            strSql.Append( " WHERE YQ99=@YQ99" );
            SqlParameter[] parameter = {
                new SqlParameter("@YQ99",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableCopy ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQI" );
            strSql.Append( " WHERE YQ99!=@YQ99" );
            SqlParameter[] parameter = {
                new SqlParameter("@YQ99",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 复制一单数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Copy (string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQI (" );
            strSql.Append( "YQ100,YQ105,YQ106,YQ107,YQ108,YQ01,YQ02,YQ03,YQ06,YQ10,YQ11,YQ12,YQ119,YQ112,YQ113,YQ114,YQ115,YQ116,YQ117,YQ13,YQ14,YQ15,YQ16,YQ19,YQ109,YQ101,YQ20,YQ21,YQ22,YQ23,YQ24,YQ25,YQ26,YQ27,YQ31,YQ32,YQ33,YQ34,YQ35,YQ36,YQ37,YQ38,YQ39,YQ40,YQ41,YQ42,YQ43,YQ44,YQ45,YQ55,YQ102,YQ46,YQ50,YQ51,YQ52,YQ53,YQ54,YQ56,YQ57,YQ58,YQ59,YQ60,YQ61,YQ62,YQ63,YQ64,YQ65,YQ66,YQ67,YQ68,YQ69,YQ70,YQ71,YQ72,YQ73,YQ74,YQ75,YQ76,YQ77,YQ78,YQ80,YQ81,YQ82,YQ83,YQ84,YQ85,YQ86,YQ87,YQ88,YQ89,YQ90,YQ111,YQ118,YQ129,YQ130,YQ131,YQ134,YQ135)" );
            strSql.Append( "SELECT  YQ100,YQ105,YQ106,YQ107,YQ108,YQ01,YQ02,YQ03,YQ06,YQ10,YQ11,YQ12,YQ119,YQ112,YQ113,YQ114,YQ115,YQ116,YQ117,YQ13,YQ14,YQ15,YQ16,YQ19,YQ109,YQ101,YQ20,YQ21,YQ22,YQ23,YQ24,YQ25,YQ26,YQ27,YQ31,YQ32,YQ33,YQ34,YQ35,YQ36,YQ37,YQ38,YQ39,YQ40,YQ41,YQ42,YQ43,YQ44,YQ45,YQ55,YQ102,YQ46,YQ50,YQ51,YQ52,YQ53,YQ54,YQ56,YQ57,YQ58,YQ59,YQ60,YQ61,YQ62,YQ63,YQ64,YQ65,YQ66,YQ67,YQ68,YQ69,YQ70,YQ71,YQ72,YQ73,YQ74,YQ75,YQ76,YQ77,YQ78,YQ80,YQ81,YQ82,YQ83,YQ84,YQ85,YQ86,YQ87,YQ88,YQ89,YQ90,YQ111,YQ118,YQ129,YQ130,YQ131,YQ134,YQ135 FROM R_PQI " );
            strSql.AppendFormat( " WHERE YQ99='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateCo ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "UPDATE R_PQI SET YQ99='{0}',YQ111='复制',YQ17=DATEADD(DAY,5,GETDATE()) WHERE YQ99 IS NULL" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 删除复制记录
        /// </summary>
        /// <returns></returns>
        public bool DeleteCopy ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQI WHERE YQ99 IS NULL" );

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.YouQiLibrary GetMo ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQI" );
            strSql.Append( " WHERE YQ99=@YQ99" );
            SqlParameter[] parameter = {
                new SqlParameter("@YQ99",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            DataTable dt = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( dt.Rows.Count >= 1 )
                return GetDataR( dt.Rows[0] );
            else
                return null;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.YouQiLibrary GetDataR ( DataRow row )
        {
            MulaolaoLibrary.YouQiLibrary model = new MulaolaoLibrary.YouQiLibrary( );

            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    model.IDX = int.Parse( row["idx"].ToString( ) );
                else
                    model.IDX = 0;
                if ( row["YQ01"] != null && row["YQ01"].ToString( ) != "" )
                    model.YQ01 = row["YQ01"].ToString( );
                else
                    model.YQ01 = string.Empty;
                if ( row["YQ02"] != null && row["YQ02"].ToString( ) != "" )
                    model.YQ02 = row["YQ02"].ToString( );
                else
                    model.YQ02 = string.Empty;
                if ( row["YQ03"] != null && row["YQ03"].ToString( ) != "" )
                    model.YQ03 = row["YQ03"].ToString( );
                else
                    model.YQ03 = string.Empty;
                if ( row["YQ04"] != null && row["YQ04"].ToString( ) != "" )
                    model.YQ04 = row["YQ04"].ToString( );
                else
                    model.YQ04 = string.Empty;
                if ( row["YQ05"] != null && row["YQ05"].ToString( ) != "" )
                    model.YQ05 = DateTime.Parse( row["YQ05"].ToString( ) );
                else
                    model.YQ05 = MulaolaoBll . Drity . GetDt ( );
                if ( row["YQ06"] != null && row["YQ06"].ToString( ) != "" )
                    model.YQ06 = row["YQ06"].ToString( );
                else
                    model.YQ06 = string.Empty;
                if ( row["YQ07"] != null && row["YQ07"].ToString( ) != "" )
                    model.YQ07 = row["YQ07"].ToString( );
                else
                    model.YQ07 = string.Empty;
                if ( row["YQ08"] != null && row["YQ08"].ToString( ) != "" )
                    model.YQ08 = DateTime.Parse( row["YQ08"].ToString( ) );
                else
                    model.YQ08 = MulaolaoBll . Drity . GetDt ( );
                if ( row["YQ09"] != null && row["YQ09"].ToString( ) != "" )
                    model.YQ09 = row["YQ09"].ToString( );
                else
                    model.YQ09 = string.Empty;
                if ( row["YQ17"] != null && row["YQ17"].ToString( ) != "" )
                    model.YQ17 = DateTime.Parse( row["YQ17"].ToString( ) );
                else
                    model.YQ17 = MulaolaoBll . Drity . GetDt ( );
                if ( row["YQ18"] != null && row["YQ18"].ToString( ) != "" )
                    model.YQ18 = DateTime.Parse( row["YQ18"].ToString( ) );
                else
                    model.YQ18 = MulaolaoBll . Drity . GetDt ( );
                if ( row["YQ20"] != null && row["YQ20"].ToString( ) != "" )
                    model.YQ20 = row["YQ20"].ToString( );
                else
                    model.YQ20 = string.Empty;
                if ( row["YQ21"] != null && row["YQ21"].ToString( ) != "" )
                    model.YQ21 = row["YQ21"].ToString( );
                else
                    model.YQ21 = string.Empty;
                if ( row["YQ22"] != null && row["YQ22"].ToString( ) != "" )
                    model.YQ22 = row["YQ22"].ToString( );
                else
                    model.YQ22 = string.Empty;
                if ( row["YQ23"] != null && row["YQ23"].ToString( ) != "" )
                    model.YQ23 = row["YQ23"].ToString( );
                else
                    model.YQ23 = string.Empty;
                if ( row["YQ24"] != null && row["YQ24"].ToString( ) != "" )
                    model.YQ24 = row["YQ24"].ToString( );
                else
                    model.YQ24 = string.Empty;
                if ( row["YQ25"] != null && row["YQ25"].ToString( ) != "" )
                    model.YQ25 = row["YQ25"].ToString( );
                else
                    model.YQ25 = string.Empty;
                if ( row["YQ26"] != null && row["YQ26"].ToString( ) != "" )
                    model.YQ26 = row["YQ26"].ToString( );
                else
                    model.YQ26 = string.Empty;
                if ( row["YQ27"] != null && row["YQ27"].ToString( ) != "" )
                    model.YQ27 = row["YQ27"].ToString( );
                else
                    model.YQ27 = string.Empty;
                if ( row["YQ28"] != null && row["YQ28"].ToString( ) != "" )
                    model.YQ28 = DateTime.Parse( row["YQ28"].ToString( ) );
                else
                    model.YQ28 = MulaolaoBll . Drity . GetDt ( );
                if ( row["YQ29"] != null && row["YQ29"].ToString( ) != "" )
                    model.YQ29 = row["YQ29"].ToString( );
                else
                    model.YQ29 = string.Empty;
                if ( row["YQ30"] != null && row["YQ30"].ToString( ) != "" )
                    model.YQ30 = DateTime.Parse( row["YQ30"].ToString( ) );
                else
                    model.YQ30 = MulaolaoBll . Drity . GetDt ( );
                if ( row["YQ31"] != null && row["YQ31"].ToString( ) != "" )
                    model.YQ31 = row["YQ31"].ToString( );
                else
                    model.YQ31 = string.Empty;
                if ( row["YQ32"] != null && row["YQ32"].ToString( ) != "" )
                    model.YQ32 = row["YQ32"].ToString( );
                else
                    model.YQ32 = string.Empty;
                if ( row["YQ33"] != null && row["YQ33"].ToString( ) != "" )
                    model.YQ33 = row["YQ33"].ToString( );
                else
                    model.YQ33 = string.Empty;
                if ( row["YQ34"] != null && row["YQ34"].ToString( ) != "" )
                    model.YQ34 = row["YQ34"].ToString( );
                else
                    model.YQ34 = string.Empty;
                if ( row["YQ35"] != null && row["YQ35"].ToString( ) != "" )
                    model.YQ35 = row["YQ35"].ToString( );
                else
                    model.YQ35 = string.Empty;
                if ( row["YQ36"] != null && row["YQ36"].ToString( ) != "" )
                    model.YQ36 = row["YQ36"].ToString( );
                else
                    model.YQ36 = string.Empty;
                if ( row["YQ37"] != null && row["YQ37"].ToString( ) != "" )
                    model.YQ37 = row["YQ37"].ToString( );
                else
                    model.YQ37 = string.Empty;
                if ( row["YQ38"] != null && row["YQ38"].ToString( ) != "" )
                    model.YQ38 = row["YQ38"].ToString( );
                else
                    model.YQ38 = string.Empty;
                if ( row["YQ39"] != null && row["YQ39"].ToString( ) != "" )
                    model.YQ39 = row["YQ39"].ToString( );
                else
                    model.YQ39 = string.Empty;
                if ( row["YQ40"] != null && row["YQ40"].ToString( ) != "" )
                    model.YQ40 = row["YQ40"].ToString( );
                else
                    model.YQ40 = string.Empty;
                if ( row["YQ41"] != null && row["YQ41"].ToString( ) != "" )
                    model.YQ41 = row["YQ41"].ToString( );
                else
                    model.YQ41 = string.Empty;
                if ( row["YQ42"] != null && row["YQ42"].ToString( ) != "" )
                    model.YQ42 = row["YQ42"].ToString( );
                else
                    model.YQ42 = string.Empty;
                if ( row["YQ43"] != null && row["YQ43"].ToString( ) != "" )
                    model.YQ43 = row["YQ43"].ToString( );
                else
                    model.YQ43 = string.Empty;
                if ( row["YQ44"] != null && row["YQ44"].ToString( ) != "" )
                    model.YQ44 = row["YQ44"].ToString( );
                else
                    model.YQ44 = string.Empty;
                if ( row["YQ45"] != null && row["YQ45"].ToString( ) != "" )
                    model.YQ45 = row["YQ45"].ToString( );
                else
                    model.YQ45 = string.Empty;
                if ( row["YQ46"] != null && row["YQ46"].ToString( ) != "" )
                    model.YQ46 = row["YQ46"].ToString( );
                else
                    model.YQ46 = string.Empty;
                if ( row["YQ47"] != null && row["YQ47"].ToString( ) != "" )
                    model.YQ47 = DateTime.Parse( row["YQ47"].ToString( ) );
                else
                    model.YQ47 = MulaolaoBll . Drity . GetDt ( );
                if ( row["YQ48"] != null && row["YQ48"].ToString( ) != "" )
                    model.YQ48 = row["YQ48"].ToString( );
                else
                    model.YQ48 = string.Empty;
                if ( row["YQ49"] != null && row["YQ49"].ToString( ) != "" )
                    model.YQ49 = DateTime.Parse( row["YQ49"].ToString( ) );
                else
                    model.YQ49 = MulaolaoBll . Drity . GetDt ( );
                if ( row["YQ50"] != null && row["YQ50"].ToString( ) != "" )
                    model.YQ50 = row["YQ50"].ToString( );
                else
                    model.YQ50 = string.Empty;
                if ( row["YQ51"] != null && row["YQ51"].ToString( ) != "" )
                    model.YQ51 = row["YQ51"].ToString( );
                else
                    model.YQ51 = string.Empty;
                if ( row["YQ52"] != null && row["YQ52"].ToString( ) != "" )
                    model.YQ52 = row["YQ52"].ToString( );
                else
                    model.YQ52 = string.Empty;
                if ( row["YQ53"] != null && row["YQ53"].ToString( ) != "" )
                    model.YQ53 = row["YQ53"].ToString( );
                else
                    model.YQ53 = string.Empty;
                if ( row["YQ54"] != null && row["YQ54"].ToString( ) != "" )
                    model.YQ54 = row["YQ54"].ToString( );
                else
                    model.YQ54 = string.Empty;
                if ( row["YQ55"] != null && row["YQ55"].ToString( ) != "" )
                    model.YQ55 = row["YQ55"].ToString( );
                else
                    model.YQ55 = string.Empty;
                if ( row["YQ56"] != null && row["YQ56"].ToString( ) != "" )
                    model.YQ56 = row["YQ56"].ToString( );
                else
                    model.YQ56 = string.Empty;
                if ( row["YQ57"] != null && row["YQ57"].ToString( ) != "" )
                    model.YQ57 = row["YQ57"].ToString( );
                else
                    model.YQ57 = string.Empty;
                if ( row["YQ58"] != null && row["YQ58"].ToString( ) != "" )
                    model.YQ58 = row["YQ58"].ToString( );
                else
                    model.YQ58 = string.Empty;
                if ( row["YQ59"] != null && row["YQ59"].ToString( ) != "" )
                    model.YQ59 = row["YQ59"].ToString( );
                else
                    model.YQ59 = string.Empty;
                if ( row["YQ60"] != null && row["YQ60"].ToString( ) != "" )
                    model.YQ60 = row["YQ60"].ToString( );
                else
                    model.YQ60 = string.Empty;
                if ( row["YQ61"] != null && row["YQ61"].ToString( ) != "" )
                    model.YQ61 = row["YQ61"].ToString( );
                else
                    model.YQ61 = string.Empty;
                if ( row["YQ62"] != null && row["YQ62"].ToString( ) != "" )
                    model.YQ62 = row["YQ62"].ToString( );
                else
                    model.YQ62 = string.Empty;
                if ( row["YQ63"] != null && row["YQ63"].ToString( ) != "" )
                    model.YQ63 = row["YQ63"].ToString( );
                else
                    model.YQ63 = string.Empty;
                if ( row["YQ64"] != null && row["YQ64"].ToString( ) != "" )
                    model.YQ64 = row["YQ64"].ToString( );
                else
                    model.YQ64 = string.Empty;
                if ( row["YQ65"] != null && row["YQ65"].ToString( ) != "" )
                    model.YQ65 = row["YQ65"].ToString( );
                else
                    model.YQ65 = string.Empty;
                if ( row["YQ66"] != null && row["YQ66"].ToString( ) != "" )
                    model.YQ66 = row["YQ66"].ToString( );
                else
                    model.YQ66 = string.Empty;
                if ( row["YQ67"] != null && row["YQ67"].ToString( ) != "" )
                    model.YQ67 = row["YQ67"].ToString( );
                else
                    model.YQ67 = string.Empty;
                if ( row["YQ68"] != null && row["YQ68"].ToString( ) != "" )
                    model.YQ68 = row["YQ68"].ToString( );
                else
                    model.YQ68 = string.Empty;
                if ( row["YQ69"] != null && row["YQ69"].ToString( ) != "" )
                    model.YQ69 = row["YQ69"].ToString( );
                else
                    model.YQ69 = string.Empty;
                if ( row["YQ70"] != null && row["YQ70"].ToString( ) != "" )
                    model.YQ70 = row["YQ70"].ToString( );
                else
                    model.YQ70 = string.Empty;
                if ( row["YQ71"] != null && row["YQ71"].ToString( ) != "" )
                    model.YQ71 = row["YQ71"].ToString( );
                else
                    model.YQ71 = string.Empty;
                if ( row["YQ72"] != null && row["YQ72"].ToString( ) != "" )
                    model.YQ72 = row["YQ72"].ToString( );
                else
                    model.YQ72 = string.Empty;
                if ( row["YQ73"] != null && row["YQ73"].ToString( ) != "" )
                    model.YQ73 = row["YQ73"].ToString( );
                else
                    model.YQ73 = string.Empty;
                if ( row["YQ74"] != null && row["YQ74"].ToString( ) != "" )
                    model.YQ74 = row["YQ74"].ToString( );
                else
                    model.YQ74 = string.Empty;
                if ( row["YQ75"] != null && row["YQ75"].ToString( ) != "" )
                    model.YQ75 = row["YQ75"].ToString( );
                else
                    model.YQ75 = string.Empty;
                if ( row["YQ76"] != null && row["YQ76"].ToString( ) != "" )
                    model.YQ76 = row["YQ76"].ToString( );
                else
                    model.YQ76 = string.Empty;
                if ( row["YQ77"] != null && row["YQ77"].ToString( ) != "" )
                    model.YQ77 = long.Parse( row["YQ77"].ToString( ) );
                else
                    model.YQ77 = 0;
                if ( row["YQ78"] != null && row["YQ78"].ToString( ) != "" )
                    model.YQ78 = row["YQ78"].ToString( );
                else
                    model.YQ78 = string.Empty;
                if ( row["YQ79"] != null && row["YQ79"].ToString( ) != "" )
                    model.YQ79 = DateTime.Parse( row["YQ79"].ToString( ) );
                else
                    model.YQ79 = MulaolaoBll . Drity . GetDt ( );
                if ( row["YQ80"] != null && row["YQ80"].ToString( ) != "" )
                    model.YQ80 = row["YQ80"].ToString( );
                else
                    model.YQ80 = string.Empty;
                if ( row["YQ81"] != null && row["YQ81"].ToString( ) != "" )
                    model.YQ81 = row["YQ81"].ToString( );
                else
                    model.YQ81 = string.Empty;
                if ( row["YQ82"] != null && row["YQ82"].ToString( ) != "" )
                    model.YQ82 = long.Parse( row["YQ82"].ToString( ) );
                else
                    model.YQ82 = 0;
                if ( row["YQ83"] != null && row["YQ83"].ToString( ) != "" )
                    model.YQ83 = long.Parse( row["YQ83"].ToString( ) );
                else
                    model.YQ83 = 0;
                if ( row["YQ84"] != null && row["YQ84"].ToString( ) != "" )
                    model.YQ84 = long.Parse( row["YQ84"].ToString( ) );
                else
                    model.YQ84 = 0;
                if ( row["YQ85"] != null && row["YQ85"].ToString( ) != "" )
                    model.YQ85 = long.Parse( row["YQ85"].ToString( ) );
                else
                    model.YQ85 = 0;
                if ( row["YQ86"] != null && row["YQ86"].ToString( ) != "" )
                    model.YQ86 = long.Parse( row["YQ86"].ToString( ) );
                else
                    model.YQ86 = 0;
                if ( row["YQ87"] != null && row["YQ87"].ToString( ) != "" )
                    model.YQ87 = long.Parse( row["YQ87"].ToString( ) );
                else
                    model.YQ87 = 0;
                if ( row["YQ88"] != null && row["YQ88"].ToString( ) != "" )
                    model.YQ88 = long.Parse( row["YQ88"].ToString( ) );
                else
                    model.YQ88 = 0;
                if ( row["YQ89"] != null && row["YQ89"].ToString( ) != "" )
                    model.YQ89 = long.Parse( row["YQ89"].ToString( ) );
                else
                    model.YQ89 = 0;
                if ( row["YQ90"] != null && row["YQ90"].ToString( ) != "" )
                    model.YQ90 = long.Parse( row["YQ90"].ToString( ) );
                else
                    model.YQ90 = 0;
                if ( row["YQ91"] != null && row["YQ91"].ToString( ) != "" )
                    model.YQ91 = row["YQ91"].ToString( );
                else
                    model.YQ91 = string.Empty;
                if ( row["YQ92"] != null && row["YQ92"].ToString( ) != "" )
                    model.YQ92 = row["YQ92"].ToString( );
                else
                    model.YQ92 = string.Empty;
                if ( row["YQ93"] != null && row["YQ93"].ToString( ) != "" )
                    model.YQ93 = DateTime.Parse( row["YQ93"].ToString( ) );
                else
                    model.YQ93 = MulaolaoBll . Drity . GetDt ( );
                if ( row["YQ94"] != null && row["YQ94"].ToString( ) != "" )
                    model.YQ94 = row["YQ94"].ToString( );
                else
                    model.YQ94 = string.Empty;
                if ( row["YQ95"] != null && row["YQ95"].ToString( ) != "" )
                    model.YQ95 = DateTime.Parse( row["YQ95"].ToString( ) );
                else
                    model.YQ95 = MulaolaoBll . Drity . GetDt ( );
                if ( row["YQ96"] != null && row["YQ96"].ToString( ) != "" )
                    model.YQ96 = row["YQ96"].ToString( );
                else
                    model.YQ96 = string.Empty;
                if ( row["YQ97"] != null && row["YQ97"].ToString( ) != "" )
                    model.YQ97 = DateTime.Parse( row["YQ97"].ToString( ) );
                else
                    model.YQ97 = MulaolaoBll . Drity . GetDt ( );
                if ( row["YQ98"] != null && row["YQ98"].ToString( ) != "" )
                    model.YQ98 = DateTime.Parse( row["YQ98"].ToString( ) );
                else
                    model.YQ98 = MulaolaoBll . Drity . GetDt ( );
                if ( row["YQ99"] != null && row["YQ99"].ToString( ) != "" )
                    model.YQ99 = row["YQ99"].ToString( );
                else
                    model.YQ99 = string.Empty;
                if ( row["YQ102"] != null && row["YQ102"].ToString( ) != "" )
                    model.YQ102 = row["YQ102"].ToString( );
                else
                    model.YQ102 = string.Empty;
                if ( row["YQ103"] != null && row["YQ103"].ToString( ) != "" )
                    model.YQ103 = row["YQ103"].ToString( );
                else
                    model.YQ103 = string.Empty;
                if ( row["YQ104"] != null && row["YQ104"].ToString( ) != "" )
                    model.YQ104 = row["YQ104"].ToString( );
                else
                    model.YQ104 = string.Empty;
                if ( row["YQ105"] != null && row["YQ105"].ToString( ) != "" )
                    model.YQ105 = row["YQ105"].ToString( );
                else
                    model.YQ105 = string.Empty;
                if ( row["YQ106"] != null && row["YQ106"].ToString( ) != "" )
                    model.YQ106 = row["YQ106"].ToString( );
                else
                    model.YQ106 = string.Empty;
                if ( row["YQ107"] != null && row["YQ107"].ToString( ) != "" )
                    model.YQ107 = row["YQ107"].ToString( );
                else
                    model.YQ107 = string.Empty;
                if ( row["YQ108"] != null && row["YQ108"].ToString( ) != "" )
                    model.YQ108 = long.Parse( row["YQ108"].ToString( ) );
                else
                    model.YQ108 = 0;
                if ( row["YQ110"] != null && row["YQ110"].ToString( ) != "" )
                    model.YQ110 = DateTime.Parse( row["YQ110"].ToString( ) );
                if ( row["YQ111"] != null && row["YQ111"].ToString( ) != "" )
                    model.YQ111 = row["YQ111"].ToString( );
                else
                    model.YQ111 = string.Empty;
                if ( row["YQ123"] != null && row["YQ123"].ToString( ) != "" )
                    model.YQ123 = row["YQ123"].ToString( );
                else
                    model.YQ123 = string.Empty;
                if ( row["YQ124"] != null && row["YQ124"].ToString( ) != "" )
                    model.YQ124 = row["YQ124"].ToString( );
                else
                    model.YQ124 = string.Empty;
                if ( row["YQ127"] != null && row["YQ127"].ToString( ) != "" )
                    model.YQ127 = row["YQ127"].ToString( );
                else
                    model.YQ127 = string.Empty;
            }

            return model;
        }

        /// <summary>
        /// 获取供应商
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableSupp (string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DGA003,DGA008,DGA011,DGA017,DGA009,DGA012 FROM TPADGA" );
            strSql.Append( " WHERE DGA001=@DGA001" );
            SqlParameter[] parameter = {
                new SqlParameter("@DGA001",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 编辑上次入库记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateStr ( MulaolaoLibrary.YouQiLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQI SET " );
            strSql.Append( "YQ125=@YQ125," );
            strSql.Append( "YQ126=@YQ126" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@YQ125",SqlDbType.BigInt),
                new SqlParameter("@YQ126",SqlDbType.Int),
                new SqlParameter("idx",SqlDbType.Int)
            };
            parameter[0].Value = model.YQ125;
            parameter[1].Value = model.YQ126;
            parameter[2].Value = model.IDX;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取供应商信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableSupplier ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DGA001,DGA003,DGA008,DGA011,DGA017,DGA009,DGA012 FROM TPADGA" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取519数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqabcdekz ( string tableName )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM " + tableName + "" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="procedure"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public bool ExistsBuild ( string procedure ,string color ,string oddNum,string colorName,string brand)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQI" );
            strSql.Append( " WHERE YQ11=@YQ11 AND YQ12=@YQ12 AND YQ06=@YQ06 AND YQ119=@YQ119 AND YQ99=@YQ99" );
            strSql.Append( " AND YQ99 LIKE 'R_337%'" );
            SqlParameter[] parameter = {
                new SqlParameter("@YQ11",SqlDbType.NVarChar,20),
                new SqlParameter("@YQ12",SqlDbType.NVarChar,20),
                new SqlParameter("@YQ06",SqlDbType.NVarChar,20),
                new SqlParameter("@YQ119",SqlDbType.NVarChar,20),
                new SqlParameter("@YQ99",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = procedure;
            parameter[1].Value = color;
            parameter[2].Value = colorName;
            parameter[3].Value = brand;
            parameter[4].Value = oddNum;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Insert ( MulaolaoLibrary.YouQiLibrary _model,string tableNum ,string tableName ,string logins ,DateTime dtOne   ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQI (" );
            strSql.Append( "YQ99,YQ02,YQ06,YQ09,YQ11,YQ12,YQ15,YQ109,YQ119,YQ10,YQ117,YQ100)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')" ,_model.YQ99 ,_model.YQ02 ,_model.YQ06 ,_model.YQ09 ,_model.YQ11 ,_model.YQ12 ,_model.YQ15 ,_model.YQ109 ,_model.YQ119 ,_model.YQ10 ,_model.YQ117 ,_model . YQ100 );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,_model.YQ99 ,strSql.ToString().Replace("'","''") ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool UpdateOther ( MulaolaoLibrary.YouQiLibrary _model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQI SET " );
            strSql.AppendFormat( "YQ02='{0}'," ,_model.YQ02 );
            strSql.AppendFormat( "YQ06='{0}'," ,_model.YQ06 );
            strSql.AppendFormat( "YQ09='{0}'," ,_model.YQ09 );
            strSql.AppendFormat( "YQ11='{0}'," ,_model.YQ11 );
            strSql.AppendFormat( "YQ12='{0}'," ,_model.YQ12 );
            strSql.AppendFormat( "YQ15='{0}'," ,_model.YQ15 );
            strSql.AppendFormat( "YQ109='{0}'," ,_model.YQ109 );
            strSql.AppendFormat( "YQ119='{0}'," ,_model.YQ119 );
            strSql.AppendFormat( "YQ10='{0}'," ,_model.YQ10 );
            strSql.AppendFormat( "YQ117='{0}'," ,_model.YQ117 );
            strSql . AppendFormat ( "YQ100='{0}' " ,_model . YQ100 );
            strSql . AppendFormat ( " WHERE YQ99='{1}' AND idx='{0}'" , _model . IDX , _model . YQ99 );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,_model.YQ99 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );
            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool DeleteOther ( int idx ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string oddNum,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQI" );
            strSql . AppendFormat ( " WHERE YQ99='{1}' AND idx='{0}'" , idx , oddNum );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );
            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTablePlanOther ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,YQ06,YQ11,YQ12,YQ15,YQ109,YQ119,YQ126,YQ10,YQ117,YQ100 FROM R_PQI" );
            strSql.Append( " WHERE " + strWhere );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintOther ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT YQ10,YQ11,YQ12,YQ06,YQ15,YQ119,YQ109,YQ109*YQ15 U0 FROM R_PQI" );
            strSql.Append( " WHERE YQ99=@YQ99" );
            SqlParameter[] parameter = {
                new SqlParameter("@YQ99",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintsOther ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT DBA002,DBA028,DGA003,DGA017,DGA008,DGA012,DGA009,DGA011,YQ04,CONVERT(VARCHAR(20),YQ05,102) YQ05,YQ07, CONVERT( VARCHAR( 20 ), YQ08, 102 ) YQ08, YQ09, YQ105, YQ106, YQ107, YQ03, YQ108,YQ20, YQ21, YQ22, YQ23, YQ24, YQ25, YQ26, YQ27, CONVERT( VARCHAR( 20 ), YQ28, 102 ) YQ28,CASE WHEN YQ32 = 'F' AND YQ33 = 'F' AND YQ34 = 'F' AND YQ35 = 'F' THEN 'F' WHEN YQ32 = 'T' OR YQ33 = 'T' OR YQ34 = 'T' OR YQ35 = 'T' THEN 'T' END U0,YQ32, YQ33, YQ34, YQ35, YQ40, YQ31, YQ41, YQ42, YQ43, YQ45, YQ44, YQ102, YQ29, CONVERT( VARCHAR( 20 ), YQ30, 102 ) YQ30, YQ36, YQ37, YQ38, YQ39, YQ46, CONVERT( VARCHAR( 20 ), YQ47, 102 ) YQ47,YQ52, YQ53, YQ54, YQ55, YQ56, YQ57, YQ58, YQ60, YQ61, YQ62, YQ59, YQ64, YQ65, YQ66, YQ68, YQ69, YQ70, YQ67, YQ76, YQ72, YQ73, YQ74, YQ75, YQ71, YQ63, YQ51, YQ50, YQ48,CONVERT( VARCHAR( 20 ), YQ49, 102 ) YQ49, YQ77, YQ80, YQ81, YQ78, CONVERT( VARCHAR( 20 ), YQ79, 102 ) YQ79, YQ82, YQ83, YQ84, YQ85, YQ86, YQ87, YQ88, YQ89, YQ90, YQ91, YQ92, CONVERT( VARCHAR( 20 ), YQ93, 102 ) YQ93, YQ94, CONVERT( VARCHAR( 20 ), YQ95, 102 ) YQ95, YQ96, CONVERT( VARCHAR( 20 ), YQ97, 102 ) YQ97, CONVERT( VARCHAR( 20 ), YQ98, 102 ) YQ98,YQ124,YQ99 FROM R_PQI A, TPADBA B, TPADGA C WHERE A.YQ01 = B.DBA001 AND A.YQ02 = C.DGA001" );
            strSql.Append( " AND YQ99=@YQ99" );
            SqlParameter[] parameter = {
                new SqlParameter("@YQ99",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取色号名称
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableColorName ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT YQ12 FROM R_PQI WHERE YQ99 LIKE 'R_337%' AND YQ12 IS NOT NULL AND YQ12!=''" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 编辑入库指标
        /// </summary>
        public bool GetDataTableOfStorage ( )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AC18,AC16 FROM R_PQAC WHERE AC16 LIKE 'R_337%' AND (AC17='' OR AC17 IS NULL OR AC17='F')" );

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            if ( da != null && da.Rows.Count > 0 )
            {
                string oddNum = "", odd = "";
                for ( int i = 0 ; i < da.Rows.Count ; i++ )
                {
                    string ac = da.Rows[i]["AC16"].ToString( );
                    if ( ac.Contains( "," ) )
                    {
                        string[] ad = ac.Split( ',' );
                        foreach ( string str in ad )
                        {
                            if ( oddNum == "" )
                                oddNum = "'" + str + "'";
                            else
                                oddNum = oddNum + "," + "'" + str + "'";
                        }
                    }
                    else
                    {
                        if ( oddNum == "" )
                            oddNum = "'" + ac + "'";
                        else
                            oddNum = oddNum + "," + "'" + ac + "'";
                    }

                    if ( odd == "" )
                        odd = "'" + da.Rows[i]["AC18"].ToString( ) + "'";
                    else
                        odd = odd + "," + "'" + da.Rows[i]["AC18"].ToString( ) + "'";
                }
                if ( oddNum != "" )
                    SQLString.Add( editSign( oddNum ) );
                if ( odd != "" )
                    SQLString.Add( editSignOfAc( odd ) );
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public string editSign ( string oddNum)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQI SET YQ128='T' WHERE YQ99 IN (" + oddNum + ")" );

            return strSql.ToString( );
        }

        public int editSigns ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE R_PQI SET YQ128='T' WHERE YQ99='{0}'" ,oddNum );

            return SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="odd"></param>
        /// <returns></returns>
        public string editSignOfAc ( string odd )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAC SET AC17='T' WHERE AC18 IN (" + odd + ")" );

            return strSql.ToString( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfReceviable ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT YQ03,YQ12,YQ101,YQ123,SUM(YQ) YQ FROM (" );
            strSql.Append( "SELECT YQ03,CASE WHEN YQ12 LIKE '%硝基漆%' THEN '硝基漆' WHEN YQ12 LIKE '%香蕉水%' THEN '香蕉水' ELSE CASE WHEN YQ33='T' OR YQ35='T' THEN '水性漆一类' ELSE '水性漆二类' END END YQ12,YQ101,CASE WHEN YQ123='T' THEN 'T' ELSE 'F' END YQ123,SUM(CASE WHEN YQ114=0 OR YQ115=0 THEN 0 WHEN YQ114!=0 AND YQ115!=0 THEN CONVERT(DECIMAL(18,0),YQ108*YQ112*YQ113*YQ116*YQ13*YQ14*0.01/YQ114/YQ115 + YQ13*YQ16*YQ108*YQ112*YQ113*YQ114*YQ115*YQ116*0.000001) END) YQ FROM R_PQI A INNER JOIN R_REVIEWS D ON A.YQ99=D.RES06 AND RES05='执行'" );
            strSql.AppendFormat( " WHERE YQ99='{0}' AND (YQ03!='' AND YQ03 IS NOT NULL) GROUP BY YQ03,YQ12,YQ101,YQ123,YQ33,YQ35) A GROUP BY YQ03,YQ12,YQ101,YQ123" ,oddNum );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 写入数据到241
        /// </summary>
        /// <param name="modelAm"></param>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateOfReceivable ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum )
        {
            ArrayList SQLString = new ArrayList( );
            ByOneBy( modelAm ,oddNum ,SQLString );
            //WriteReceivableToGeneralLedger.ByOneByYouQi( modelAm ,oddNum ,SQLString );
            StringBuilder strSql = new StringBuilder( );
            if ( modelAm.AM175 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM175='{0}' WHERE AM002='{1}'" ,modelAm.AM175 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( modelAm.AM177 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM177='{0}' WHERE AM002='{1}'" ,modelAm.AM177 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( modelAm.AM178 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM178='{0}' WHERE AM002='{1}'" ,modelAm.AM178 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( modelAm.AM182 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM182='{0}' WHERE AM002='{1}'" ,modelAm.AM182 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( modelAm.AM184 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM184='{0}' WHERE AM002='{1}'" ,modelAm.AM184 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( modelAm.AM185 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM185='{0}' WHERE AM002='{1}'" ,modelAm.AM185 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( modelAm.AM188 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM188='{0}' WHERE AM002='{1}'" ,modelAm.AM188 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( modelAm.AM190 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM190='{0}' WHERE AM002='{1}'" ,modelAm.AM190 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( modelAm.AM191 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM191='{0}' WHERE AM002='{1}'" ,modelAm.AM191 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( modelAm.AM194 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM194='{0}' WHERE AM002='{1}'" ,modelAm.AM194 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( modelAm.AM196 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM196='{0}' WHERE AM002='{1}'" ,modelAm.AM196 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( modelAm.AM197 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM197='{0}' WHERE AM002='{1}'" ,modelAm.AM197 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( modelAm.AM200 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM200='{0}' WHERE AM002='{1}'" ,modelAm.AM200 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( modelAm.AM203 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM203='{0}' WHERE AM002='{1}'" ,modelAm.AM203 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( modelAm.AM205 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM205='{0}' WHERE AM002='{1}'" ,modelAm.AM205 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( modelAm.AM207 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM207='{0}' WHERE AM002='{1}'" ,modelAm.AM207 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }


            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        void ByOneBy ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "SELECT AMB175,AMB177,AMB178,AMB182,AMB184,AMB185,AMB188,AMB190,AMB191,AMB194,AMB196,AMB197,AMB200,AMB203,AMB205,AMB207 FROM R_PQAMB WHERE AMB001='{0}'" ,oddNum );

            DataTable de = SqlHelper.ExecuteDataTable( "SELECT AM175,AM177,AM178,AM182,AM184,AM185,AM188,AM190,AM191,AM194,AM196,AM197,AM200,AM203,AM205,AM207 FROM R_PQAM WHERE AM002='" + modelAm.AM002 + "'" );
            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            if ( da != null && da.Rows.Count > 0 )
            {
                if ( modelAm.AM175 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB175='{0}' WHERE AMB001='{1}'" ,modelAm.AM175 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM177 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB177='{0}' WHERE AMB001='{1}'" ,modelAm.AM177 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM178 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB178='{0}' WHERE AMB001='{1}'" ,modelAm.AM178 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM182 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB182='{0}' WHERE AMB001='{1}'" ,modelAm.AM182 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM184 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB184='{0}' WHERE AMB001='{1}'" ,modelAm.AM184 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM185 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB185='{0}' WHERE AMB001='{1}'" ,modelAm.AM185 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM188 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB188='{0}' WHERE AMB001='{1}'" ,modelAm.AM188 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM190 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB190='{0}' WHERE AMB001='{1}'" ,modelAm.AM190 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM191 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB191='{0}' WHERE AMB001='{1}'" ,modelAm.AM191 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM194 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB194='{0}' WHERE AMB001='{1}'" ,modelAm.AM194 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM196 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB196='{0}' WHERE AMB001='{1}'" ,modelAm.AM196 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM197 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB197='{0}' WHERE AMB001='{1}'" ,modelAm.AM197 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM200 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB200='{0}' WHERE AMB001='{1}'" ,modelAm.AM200 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM203 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB203='{0}' WHERE AMB001='{1}'" ,modelAm.AM203 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM205 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB205='{0}' WHERE AMB001='{1}'" ,modelAm.AM205 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM207 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB207='{0}' WHERE AMB001='{1}'" ,modelAm.AM207 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }

                
               
                if ( de != null && de.Rows.Count > 0 )
                {
                    modelAm.AM175 = modelAm.AM175 - ( string.IsNullOrEmpty( da.Rows[0]["AMB175"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB175"].ToString( ) ) );
                    modelAm.AM177 = modelAm.AM177 - ( string.IsNullOrEmpty( da.Rows[0]["AMB177"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB177"].ToString( ) ) );
                    modelAm.AM178 = modelAm.AM178 - ( string.IsNullOrEmpty( da.Rows[0]["AMB178"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB178"].ToString( ) ) );
                    modelAm.AM182 = modelAm.AM182 - ( string.IsNullOrEmpty( da.Rows[0]["AMB182"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB182"].ToString( ) ) );
                    modelAm.AM184 = modelAm.AM184 - ( string.IsNullOrEmpty( da.Rows[0]["AMB184"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB184"].ToString( ) ) );
                    modelAm.AM185 = modelAm.AM185 - ( string.IsNullOrEmpty( da.Rows[0]["AMB185"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB185"].ToString( ) ) );
                    modelAm.AM188 = modelAm.AM188 - ( string.IsNullOrEmpty( da.Rows[0]["AMB188"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB188"].ToString( ) ) );
                    modelAm.AM190 = modelAm.AM190 - ( string.IsNullOrEmpty( da.Rows[0]["AMB190"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB190"].ToString( ) ) );
                    modelAm.AM191 = modelAm.AM191 - ( string.IsNullOrEmpty( da.Rows[0]["AMB191"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB191"].ToString( ) ) );
                    modelAm.AM194 = modelAm.AM194 - ( string.IsNullOrEmpty( da.Rows[0]["AMB194"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB194"].ToString( ) ) );
                    modelAm.AM196 = modelAm.AM196 - ( string.IsNullOrEmpty( da.Rows[0]["AMB196"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB196"].ToString( ) ) );
                    modelAm.AM197 = modelAm.AM197 - ( string.IsNullOrEmpty( da.Rows[0]["AMB197"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB197"].ToString( ) ) );
                    modelAm.AM200 = modelAm.AM200 - ( string.IsNullOrEmpty( da.Rows[0]["AMB200"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB200"].ToString( ) ) );
                    modelAm.AM203 = modelAm.AM203 - ( string.IsNullOrEmpty( da.Rows[0]["AMB203"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB203"].ToString( ) ) );
                    modelAm.AM205 = modelAm.AM205 - ( string.IsNullOrEmpty( da.Rows[0]["AMB205"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB205"].ToString( ) ) );
                    modelAm.AM207 = modelAm.AM207 - ( string.IsNullOrEmpty( da.Rows[0]["AMB207"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB207"].ToString( ) ) );

                    modelAm.AM175 = modelAm.AM175 + ( string.IsNullOrEmpty( de.Rows[0]["AM175"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM175"].ToString( ) ) );
                    modelAm.AM177 = modelAm.AM177 + ( string.IsNullOrEmpty( de.Rows[0]["AM177"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM177"].ToString( ) ) );
                    modelAm.AM178 = modelAm.AM178 + ( string.IsNullOrEmpty( de.Rows[0]["AM178"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM178"].ToString( ) ) );
                    modelAm.AM182 = modelAm.AM182 + ( string.IsNullOrEmpty( de.Rows[0]["AM182"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM182"].ToString( ) ) );
                    modelAm.AM184 = modelAm.AM184 + ( string.IsNullOrEmpty( de.Rows[0]["AM184"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM184"].ToString( ) ) );
                    modelAm.AM185 = modelAm.AM185 + ( string.IsNullOrEmpty( de.Rows[0]["AM185"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM185"].ToString( ) ) );
                    modelAm.AM188 = modelAm.AM188 + ( string.IsNullOrEmpty( de.Rows[0]["AM188"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM188"].ToString( ) ) );
                    modelAm.AM190 = modelAm.AM190 + ( string.IsNullOrEmpty( de.Rows[0]["AM190"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM190"].ToString( ) ) );
                    modelAm.AM191 = modelAm.AM191 + ( string.IsNullOrEmpty( de.Rows[0]["AM191"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM191"].ToString( ) ) );
                    modelAm.AM194 = modelAm.AM194 + ( string.IsNullOrEmpty( de.Rows[0]["AM194"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM194"].ToString( ) ) );
                    modelAm.AM196 = modelAm.AM196 + ( string.IsNullOrEmpty( de.Rows[0]["AM196"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM196"].ToString( ) ) );
                    modelAm.AM197 = modelAm.AM197 + ( string.IsNullOrEmpty( de.Rows[0]["AM197"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM197"].ToString( ) ) );
                    modelAm.AM200 = modelAm.AM200 + ( string.IsNullOrEmpty( de.Rows[0]["AM200"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM200"].ToString( ) ) );
                    modelAm.AM203 = modelAm.AM203 + ( string.IsNullOrEmpty( de.Rows[0]["AM203"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM203"].ToString( ) ) );
                    modelAm.AM205 = modelAm.AM205 + ( string.IsNullOrEmpty( de.Rows[0]["AM205"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM205"].ToString( ) ) );
                    modelAm.AM207 = modelAm.AM207 + ( string.IsNullOrEmpty( de.Rows[0]["AM207"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM207"].ToString( ) ) );
                }
                
            }
            else
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "INSERT INTO R_PQAMB (AMB001,AMB175,AMB177,AMB178,AMB182,AMB184,AMB185,AMB188,AMB190,AMB191,AMB194,AMB196,AMB197,AMB200,AMB203,AMB205,AMB207) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}')" ,oddNum ,modelAm.AM175 ,modelAm.AM177 ,modelAm.AM178 ,modelAm.AM182 ,modelAm.AM184 ,modelAm.AM185 ,modelAm.AM188 ,modelAm.AM190 ,modelAm.AM191 ,modelAm.AM194 ,modelAm.AM196 ,modelAm.AM197 ,modelAm.AM200 ,modelAm.AM203 ,modelAm.AM205 ,modelAm.AM207 );
                SQLString.Add( strSql.ToString( ) );
                if ( de != null && de.Rows.Count > 0 )
                {
                    modelAm.AM175 = modelAm.AM175 + ( string.IsNullOrEmpty( de.Rows[0]["AM175"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM175"].ToString( ) ) );
                    modelAm.AM177 = modelAm.AM177 + ( string.IsNullOrEmpty( de.Rows[0]["AM177"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM177"].ToString( ) ) );
                    modelAm.AM178 = modelAm.AM178 + ( string.IsNullOrEmpty( de.Rows[0]["AM178"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM178"].ToString( ) ) );
                    modelAm.AM182 = modelAm.AM182 + ( string.IsNullOrEmpty( de.Rows[0]["AM182"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM182"].ToString( ) ) );
                    modelAm.AM184 = modelAm.AM184 + ( string.IsNullOrEmpty( de.Rows[0]["AM184"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM184"].ToString( ) ) );
                    modelAm.AM185 = modelAm.AM185 + ( string.IsNullOrEmpty( de.Rows[0]["AM185"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM185"].ToString( ) ) );
                    modelAm.AM188 = modelAm.AM188 + ( string.IsNullOrEmpty( de.Rows[0]["AM188"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM188"].ToString( ) ) );
                    modelAm.AM190 = modelAm.AM190 + ( string.IsNullOrEmpty( de.Rows[0]["AM190"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM190"].ToString( ) ) );
                    modelAm.AM191 = modelAm.AM191 + ( string.IsNullOrEmpty( de.Rows[0]["AM191"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM191"].ToString( ) ) );
                    modelAm.AM194 = modelAm.AM194 + ( string.IsNullOrEmpty( de.Rows[0]["AM194"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM194"].ToString( ) ) );
                    modelAm.AM196 = modelAm.AM196 + ( string.IsNullOrEmpty( de.Rows[0]["AM196"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM196"].ToString( ) ) );
                    modelAm.AM197 = modelAm.AM197 + ( string.IsNullOrEmpty( de.Rows[0]["AM197"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM197"].ToString( ) ) );
                    modelAm.AM200 = modelAm.AM200 + ( string.IsNullOrEmpty( de.Rows[0]["AM200"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM200"].ToString( ) ) );
                    modelAm.AM203 = modelAm.AM203 + ( string.IsNullOrEmpty( de.Rows[0]["AM203"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM203"].ToString( ) ) );
                    modelAm.AM205 = modelAm.AM205 + ( string.IsNullOrEmpty( de.Rows[0]["AM205"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM205"].ToString( ) ) );
                    modelAm.AM207 = modelAm.AM207 + ( string.IsNullOrEmpty( de.Rows[0]["AM207"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM207"].ToString( ) ) );
                }
                
            }
        }

        /// <summary>
        /// 获取525剩余库存
        /// </summary>
        /// <param name="nameOf"></param>
        /// <param name="workOf"></param>
        /// <param name="colorName"></param>
        /// <returns></returns>
        public DataTable GetDataTableSerialNum (string nameOf,string workOf,string colorName )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AI001,AI002,AI005,AI006,AI007-AI008-ISNULL(AG011,0)+ISNULL(AG012,0) AI,AI011,AI003,AI004 FROM R_PQAI A LEFT JOIN R_PQAG B ON A.AI002=B.AG002 AND A.AI011=B.AG009 AND A.AI003=B.AG005 AND A.AI004=B.AG006 WHERE AI007!=AI008 AND (AI013!='T' OR AI013='' OR AI013 IS NULL)" );
            strSql.Append( " AND AI011=@AI011 AND AI003=@AI003 AND AI004=@AI004" );
            SqlParameter[] parameter = {
                new SqlParameter("@AI011",SqlDbType.NVarChar,20),
                new SqlParameter("@AI003",SqlDbType.NVarChar,20),
                new SqlParameter("@AI004",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = nameOf;
            parameter[1].Value = workOf;
            parameter[2].Value = colorName;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
    }
}

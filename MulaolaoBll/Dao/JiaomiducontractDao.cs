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
    public class JiaomiducontractDao
    {
        /// <summary>
        /// 获取数据列表 
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string field )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT " );
            strSql.Append( field );
            strSql.Append( " FROM R_PQO" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT JM02,(SELECT DBA002 FROM TPADBA WHERE JM02=DBA001) DBA002 FROM R_PQO" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableJoin ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT JM03,(SELECT DGA003 FROM TPADGA WHERE JM03=DGA001) DGA002 FROM R_PQO" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetJiaomiduCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQO" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " WHERE " + strWhere );
            }

            object obj = SqlHelper.GetSingle( strSql.ToString( ) );
            if ( obj == null )
                return 0;
            else
                return Convert.ToInt32( obj );
        }


        /// <summary>
        /// 获取总记录数 财务结账
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetJiaomiduCountOne ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQO TT,R_REVIEWS B WHERE TT.JM01=B.RES06 AND RES05='执行' AND NOT EXISTS (SELECT 1 FROM R_PQAL C,R_PQAK D WHERE TT.idx=C.AL003 AND TT.JM01=C.AL002 AND C.AL001=D.idx)" );
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
            //JM02,(SELECT DBA002 FROM TPADBA WHERE DBA001=JM02) DBA002,
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,JM01,JM90,JM100,JM101,JM102,JM103,JM03,(SELECT DGA003 FROM TPADGA WHERE JM03=DGA001) DGA002,JM04,JM14,JM15,JM104,CASE WHEN JM90!='' THEN '' ELSE CASE WHEN JM111='T' THEN '已入' ELSE '未入' END END JM111,(SELECT RES05 FROM R_REVIEWS WHERE RES04 = ( SELECT MAX(RES04) RES04 FROM R_REVIEWS WHERE RES06 = JM01)) RES05,JM94,JM95,JM96,JM09,JM10,JM11,JM113,CASE WHEN JM10=0 THEN JM118*JM11 ELSE CONVERT(decimal(11,0),JM103/JM10+isnull(JM118,0))*JM11 END U0,ISNULL(JM107,'F') JM107,JM04,CONVERT(DECIMAL(11,2),CASE WHEN JM10=0 THEN JM118*JM11/JM103 ELSE CONVERT(decimal(11,0),JM103/JM10+isnull(JM118,0))*JM11/JM103 END) U1,CONVERT(DECIMAL(11,2),CASE WHEN JM10=0 THEN ISNULL(JM118,0)*JM11/JM103 ELSE CONVERT(decimal(11,0),JM103/JM10+isnull(JM118,0))*JM11/JM103 END) U2,JM12,CASE WHEN JM94=0 OR JM95=0 OR JM96=0 THEN 0 ELSE JM11/JM94/JM95/JM96/0.000001 END U3,JM117,JM112,JM92 FROM (" );
            strSql.Append( "SELECT ROW_NUMBER() OVER(" );
            if ( !string.IsNullOrEmpty( orderby.Trim( ) ) )
            {
                strSql.Append( "ORDER BY T." + orderby );
            }
            else
            {
                strSql.Append( "ORDER BY T.idx DESC" );
            }
            strSql.Append( ") AS Row,T.* FROM R_PQO T" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " WHERE " + strWhere );
            }
            strSql.Append( ") TT" );
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
            //JM02,(SELECT DBA002 FROM TPADBA WHERE DBA001=JM02) DBA002,
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT TT.idx,JM01,JM90,JM100,JM101,JM102,JM103,CASE WHEN JM90!='' THEN '' ELSE CASE WHEN JM111='T' THEN '已入' ELSE '未入' END END JM111,JM03,(SELECT DGA003 FROM TPADGA WHERE JM03=DGA001) DGA002,JM14,JM15,JM104,JM94,JM95,JM96,JM09,JM10,JM11,RES05,JM113,CASE WHEN JM10=0 THEN isnull(JM118,0)*JM11 ELSE CONVERT(decimal(11,0),JM103/JM10+isnull(JM118,0))*JM11 END U0,ISNULL(JM107,'F') JM107,JM04,CONVERT(DECIMAL(11,2),CASE WHEN JM10=0 THEN JM118*JM11/JM103 ELSE CONVERT(decimal(11,0),JM103/JM10+isnull(JM118,0))*JM11/JM103 END) U1,CONVERT(DECIMAL(11,2),CASE WHEN JM10=0 THEN ISNULL(JM118,0)*JM11/JM103 ELSE CONVERT(decimal(11,0),JM103/JM10+isnull(JM118,0))*JM11/JM103 END) U2,JM12,CASE WHEN JM94=0 OR JM95=0 OR JM96=0 THEN 0 ELSE JM11/JM94/JM95/JM96/0.000001 END U3,JM117,JM112,JM92 FROM  ( " );
            strSql.Append( "SELECT ROW_NUMBER() OVER(" );
            strSql.Append( "ORDER BY T.JM01 DESC" );
            strSql.Append( ") AS Row,T.* FROM R_PQO T" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " WHERE " + strWhere );
            }
            strSql.Append( ") TT,R_REVIEWS B WHERE TT.JM01=B.RES06 AND RES05='执行' AND NOT EXISTS (SELECT 1 FROM R_PQAL C,R_PQAK D WHERE TT.idx=C.AL003 AND TT.JM01=C.AL002 AND C.AL001=D.idx AND (AK009-AK010-AK011-AK015)<=100)" );// AND AK009=AK011
            strSql .AppendFormat( " AND TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取打印列表  表一
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintOne ( string oddNum)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT JM09,JM92,JM93,JM94,JM95,JM96,CONVERT( DECIMAL( 11, 5 ), JM94 * JM95 * JM96 * 0.000001 ) U0,CASE WHEN JM10 = 0 THEN 0 WHEN JM10 != 0 THEN CONVERT( BIGINT, round(JM103/JM10,0) )+ISNULL(JM118,0) END U1,JM10,CONVERT(DECIMAL(6,2),JM11) JM11, JM13,CONVERT(BIGINT,round(JM12,0)) JM12,CASE WHEN JM94 = 0 OR JM95 = 0 OR JM96 = 0 THEN 0 WHEN JM94 != 0 AND JM95 != 0 AND JM96 != 0 THEN CONVERT( BIGINT, round(JM11 / JM94 / JM95 / JM96 / 0.000001,0) ) END U2,CASE WHEN JM10 = 0 THEN 0 WHEN JM10 != 0 THEN CONVERT( DECIMAL( 11, 5 ), JM94 * JM95 * JM96 * 0.000001 * JM103 / JM10 ) END U3,CASE WHEN JM10=0 THEN JM118*JM11 ELSE CONVERT(decimal(11,0),JM103/JM10+isnull(JM118,0))*JM11 END U4,CASE WHEN JM10=0 THEN JM118*JM11 ELSE CONVERT(decimal(11,0),JM103/JM10+isnull(JM118,0))*JM11 END U5,CONVERT(DECIMAL(11,2),CASE WHEN JM10=0 THEN JM118*JM11/JM103 ELSE CONVERT(decimal(11,0),JM103/JM10+isnull(JM118,0))*JM11/JM103 END) U6,CONVERT(DECIMAL(11,2),CASE WHEN JM10=0 THEN ISNULL(JM118,0)*JM11/JM103 ELSE CONVERT(decimal(11,0),JM103/JM10+isnull(JM118,0))*JM11/JM103 END) U7,JM14, CONVERT( VARCHAR( 20 ), JM16, 102 ) JM16, CONVERT( VARCHAR( 20 ), JM17, 102 ) JM17,JM103,JM120+ISNULL(JM119,0) JM120 FROM R_PQO" );
            strSql.Append( " WHERE JM01 =@JM01" );
            SqlParameter[] parameter = {
                new SqlParameter("@JM01",SqlDbType.NVarChar)
            };
            
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取打印列表  表二
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintTwo ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DBA002 U0,DBA028,DGA003 U1,DGA008 U2,DGA011,DGA017,DGA009 U3,DGA012,JM04,CONVERT(VARCHAR(20),JM05,102) JM05,JM06,CONVERT(VARCHAR(20),JM07,102) JM07,JM08,JM100,JM101,JM102,JM90,JM19,JM20,JM21,JM22,JM23,JM24,JM25,JM26,JM27,CONVERT(VARCHAR(20),JM28,102) JM28,CONVERT(VARCHAR(30),JM30,102) JM30,JM29,JM33,JM31,CONVERT(VARCHAR(20),JM32,102) JM32,JM39,JM40,JM41,JM42,JM43,JM44,JM45,JM46,JM47,JM48,JM49,JM34,JM35,JM36,JM37,JM38,JM50,CONVERT(NVARCHAR(20),JM51,102) JM51,JM56,JM57,JM58,JM59,JM60,JM61,JM62,JM63,JM64,JM65,JM66,JM67,JM71,JM72,JM68,JM69,JM70,JM52,CONVERT(VARCHAR(20),JM53,102) JM53,JM73,JM74,JM75,JM76,JM77,JM78,JM79,JM80,JM81,JM82,JM83,CONVERT(VARCHAR(20),JM84,102) JM84,JM85,CONVERT(VARCHAR(20),JM86,102) JM86,JM87,CONVERT(VARCHAR(20),JM88,102) JM88,CONVERT(VARCHAR(20),JM89,102) JM89,JM54,JM55,JM108,JM01,CASE WHEN JM90='' THEN 'F' WHEN JM90!='' THEN CASE WHEN JM14='库存' THEN 'T' ELSE '1' END END JM,ISNULL(JM107,'F') JM107 FROM R_PQO A ,TPADBA B,TPADGA C" );
            strSql.Append( " WHERE A.JM02=B.DBA001 AND A.JM03=C.DGA001 AND JM01=@JM01" );
            SqlParameter[] parameter = {
                new SqlParameter("@JM01",SqlDbType.NVarChar)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 是否存在一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsOne ( MulaolaoLibrary.JiaoMiDuContractLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQO" );
            strSql.Append( " WHERE JM01=@JM01 AND JM09=@JM09 AND JM94=@JM94 AND JM95=@JM95 AND JM96=@JM96" );
            SqlParameter[] parameter = {
                new SqlParameter("@JM01",SqlDbType.NVarChar),
                new SqlParameter("@JM09",SqlDbType.NVarChar),
                new SqlParameter("@JM94",SqlDbType.NVarChar),
                new SqlParameter("@JM95",SqlDbType.NVarChar),
                new SqlParameter("@JM96",SqlDbType.NVarChar)
            };
            parameter[0].Value = model.JM01;
            parameter[1].Value = model.JM09;
            parameter[2].Value = model.JM94;
            parameter[3].Value = model.JM95;
            parameter[4].Value = model.JM96;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <returns></returns>
        public bool Add ( MulaolaoLibrary . JiaoMiDuContractLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQO (" );
            strSql . Append ( "JM01,JM09,JM10,JM11,JM12,JM13,JM14,JM15,JM16,JM17,JM91,JM92,JM93,JM94,JM95,JM96,JM103,JM104,JM112,JM03,JM118,JM119,JM120,JM121)" );
            strSql . Append ( " VALUES (" );
            strSql . AppendFormat ( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}')" ,model . JM01 ,model . JM09 ,model . JM10 ,model . JM11 ,model . JM12 ,model . JM13 ,model . JM14 ,model . JM15 ,model . JM16 ,model . JM17 ,model . JM91 ,model . JM92 ,model . JM93 ,model . JM94 ,model . JM95 ,model . JM96 ,model . JM103 ,model . JM104 ,model . JM112 ,model . JM03 ,model . JM118 ,model . JM119 ,model . JM120 ,model . JM121 );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( tableNum ,tableName ,logins ,dtOne ,model . JM01 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.JiaoMiDuContractLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQO SET " );
            strSql.AppendFormat( "JM09='{0}'," ,model.JM09 );
            strSql.AppendFormat( "JM10='{0}'," ,model.JM10 );
            strSql.AppendFormat( "JM11='{0}'," ,model.JM11 );
            strSql.AppendFormat( "JM12='{0}'," ,model.JM12 );
            strSql.AppendFormat( "JM13='{0}'," ,model.JM13 );
            strSql.AppendFormat( "JM14='{0}'," ,model.JM14 );
            strSql.AppendFormat( "JM15='{0}'," ,model.JM15 );
            strSql.AppendFormat( "JM16='{0}'," ,model.JM16 );
            strSql.AppendFormat( "JM17='{0}'," ,model.JM17 );
            strSql.AppendFormat( "JM91='{0}'," ,model.JM91 );
            strSql.AppendFormat( "JM92='{0}'," ,model.JM92 );
            strSql.AppendFormat( "JM93='{0}'," ,model.JM93 );
            strSql.AppendFormat( "JM94='{0}'," ,model.JM94 );
            strSql.AppendFormat( "JM95='{0}'," ,model.JM95 );
            strSql.AppendFormat( "JM96='{0}'," ,model.JM96 );
            strSql.AppendFormat( "JM103='{0}'," ,model.JM103 );
            strSql.AppendFormat( "JM104='{0}'," ,model.JM104 );
            strSql.AppendFormat( "JM112='{0}'," ,model.JM112 );
            strSql . AppendFormat ( "JM118='{0}'," ,model . JM118 );
            strSql . AppendFormat ( "JM119='{0}'," ,model . JM119 );
            strSql . AppendFormat ( "JM120='{0}'," ,model . JM120 );
            strSql . AppendFormat ( "JM121='{0}'" ,model . JM121 );
            strSql . AppendFormat ( " WHERE JM01='{1}' AND idx='{0}'" , model . IDX , model . JM01 );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.JM01 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx ,string tableNum ,string tableName ,string logins ,DateTime dtOne,string oddNum ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQO" );
            strSql . AppendFormat ( " WHERE JM01='{1}' AND idx={0}" , idx , oddNum );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );
            
            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取是否在入库表中存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetDataTableAcPlan ( MulaolaoLibrary.JiaoMiDuContractLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AC03+ISNULL(AC26,0) AC03,AC18 FROM R_PQAC" );
            strSql.Append( " WHERE AC18=(SELECT MAX(AC18) FROM R_PQAC WHERE AC02=@AC02 AND AC04=@AC04 AND AC05=@AC05)" );
            SqlParameter[] parameter = {
                new SqlParameter("@AC02",SqlDbType.NVarChar),
                new SqlParameter("@AC04",SqlDbType.NVarChar),
                new SqlParameter("@AC05",SqlDbType.NVarChar)
            };

            parameter[0].Value = model.JM102;
            parameter[1].Value = model.JM09;
            parameter[2].Value = model.JM94 + "*" + model.JM95 + "*" + model.JM96;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取出库表中出库数量
        /// </summary>
        /// <param name="acPlanAc18"></param>
        /// <returns></returns>
        public DataTable GetDataTableAdPlan ( string acPlanAc18 )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT SUM(AD05) AD05 FROM R_PQAD" );
            strSql.Append( " WHERE AD01=@AD01" );
            SqlParameter[] parameter = {
                new SqlParameter("@AD01",SqlDbType.NVarChar)
            };

            parameter[0].Value = acPlanAc18;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        //public DataTable GetDataTablePrice(MulaolaoLibrary.)
        /// <summary>
        /// 获取物料名称    509材料一栏  分类为胶合板或者密度板
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTableNum ( string num )
        {
            // AND GS02 LIKE '%胶合板%' OR  GS02 LIKE '%密度板%'
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT GS02 JM09 FROM R_PQP" );
            strSql.Append( " WHERE GS48=@GS48 AND GS02 IS NOT NULL AND GS02!=''" );
            SqlParameter[] parameter = {
                new SqlParameter("@GS48",SqlDbType.NVarChar)
            };

            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 得到货号
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableName ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT JM09 FROM R_PQO" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取联系人
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableProce ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DBA002,DBA001,DBA028 FROM TPADBA WHERE DBA028!=''  AND (DBA043='F' OR DBA043='' OR DBA043 IS NULL) ORDER BY DBA001" );
            
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
        /// 获取对比数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetDataTableContrast ( MulaolaoLibrary.JiaoMiDuContractLibrary model)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT JM10,JM11,JM12 FROM R_PQO WHERE JM102=@JM102 AND JM09=@JM09 AND JM94=@JM94 AND JM95=@JM95 AND JM96=@JM96 AND JM90='' AND JM01=(SELECT MAX(JM01) FROM R_PQO WHERE JM102=@JM102 AND JM09=@JM09 AND JM94=@JM94 AND JM95=@JM95 AND JM96=@JM96 AND JM90='')" );
            SqlParameter[] parameter = {
                new SqlParameter("@JM102",SqlDbType.NVarChar),
                new SqlParameter("@JM09",SqlDbType.NVarChar),
                new SqlParameter("@JM94",SqlDbType.Decimal),
                new SqlParameter("@JM95",SqlDbType.Decimal),
                new SqlParameter("@JM96",SqlDbType.Decimal)
            };

            parameter[0].Value = model.JM102;
            parameter[1].Value = model.JM09;
            parameter[2].Value = model.JM94;
            parameter[3].Value = model.JM95;
            parameter[4].Value = model.JM96;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// //同货号、物料名称、规格是否已经开过计划订单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetDataTableYesOrNoPlan (MulaolaoLibrary.JiaoMiDuContractLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AC03+ISNULL(AC26,0) AC03,AC18 FROM R_PQAC WHERE AC18=(SELECT MAX(AC18) FROM R_PQAC WHERE AC02=@AC02 AND AC04=@AC04 AND AC05=@AC05)" );
            SqlParameter[] parameter = {
                new SqlParameter("@AC02",SqlDbType.NVarChar),
                new SqlParameter("@AC04",SqlDbType.NVarChar),
                new SqlParameter("@AC05",SqlDbType.NVarChar)
            };
            parameter[0].Value = model.JM102;
            parameter[1].Value = model.JM09;
            parameter[2].Value = model.JM94 + "*" + model.JM95 + "*" + model.JM96;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取是否出货完毕
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableYesNoAdPlan ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql . AppendFormat ( "WITH CET AS(SELECT INB002,INB003,SUM(CONVERT(FLOAT,INB014+CONVERT(VARCHAR,INB013))) INB013,SUM(CONVERT(FLOAT,INB016+CONVERT(VARCHAR,INB015))) INB015 FROM R_INA A INNER JOIN R_INB B ON A.INA001=B.INB001 WHERE INA003='出库' AND INB003='{0}' group by INB002,INB003) " ,oddNum );
            strSql.Append( "SELECT SUM(AD05)+ISNULL(INB013,0) AD05 FROM R_PQAD A LEFT JOIN CET B ON A.AD01=B.INB002 AND A.AD17=B.INB003 WHERE AD01=@AD01" );
            SqlParameter[] parameter = {
                new SqlParameter("@AD01",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetDataTablePlan ( MulaolaoLibrary.JiaoMiDuContractLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AC03+ISNULL(AC26,0)-(SELECT SUM(AD05+ISNULL(AD20,0)) AD05 FROM R_PQAD  WHERE AC18=AD01) AD05  FROM R_PQAC WHERE AC18=(SELECT MAX(AC18) FROM R_PQAC WHERE AC02=@AC02 AND AC04=@AC04 AND AC05=@AC05) GROUP BY AC03,ISNULL(AC26,0),AC18" );
            SqlParameter[] parameter = {
                new SqlParameter("@AC02",SqlDbType.NVarChar),
                new SqlParameter("@AC04",SqlDbType.NVarChar),
                new SqlParameter("@AC05",SqlDbType.NVarChar)
            };
            parameter[0].Value = model.JM102;
            parameter[1].Value = model.JM09;
            parameter[2].Value = model.JM94 + "*" + model.JM95 + "*" + model.JM96;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetDataTableDwo ( MulaolaoLibrary.JiaoMiDuContractLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQO WHERE  JM14=@JM14 AND JM09=@JM09 AND JM94=@JM94 AND JM95=@JM95 AND JM96=@JM96 AND JM90=@JM90" );
            SqlParameter[] parameter = {
                new SqlParameter("@JM14",SqlDbType.NVarChar),
                new SqlParameter("@JM09",SqlDbType.NVarChar),
                new SqlParameter("@JM94",SqlDbType.Decimal),
                new SqlParameter("@JM95",SqlDbType.Decimal),
                new SqlParameter("@JM96",SqlDbType.Decimal),
                new SqlParameter("@JM90",SqlDbType.NVarChar)
            };
            parameter[0].Value = model.JM14;
            parameter[1].Value = model.JM09;
            parameter[2].Value = model.JM94;
            parameter[3].Value = model.JM95;
            parameter[4].Value = model.JM96;
            parameter[5].Value = model.JM90;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableAll ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,JM09,JM92,JM93,JM94,JM95,JM96,JM10,JM11,JM12,JM13,JM14,JM15,JM104,JM16,JM17,JM91,JM103,JM109,JM110,JM112,ISNULL(JM118,0) JM118,JM119,JM120,JM121 FROM R_PQO A" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( " AND JM09!= '' AND JM09 IS NOT NULL ORDER BY idx DESC" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 是否执行
        /// </summary>
        /// <param name="tableNum"></param>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool ExistsReviews (string tableNum,string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_REVIEWS WHERE RES05='执行' AND RES06=@RES06 AND RES01=@RES01 " );
            SqlParameter[] parameter = {
                new SqlParameter("@RES06",SqlDbType.NVarChar),
                new SqlParameter("@RES01",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;
            parameter[1].Value = tableNum;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool DeleteOne ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "DELETE FROM R_PQO WHERE JM01='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            StringBuilder strSq = new StringBuilder( );
            strSq.AppendFormat( "DELETE FROM R_REVIEWS WHERE RES01='{0}' AND RES06='{1}'" ,tableNum ,oddNum );
            SQLString.Add( strSq.ToString( ) );
            StringBuilder strS = new StringBuilder( );
            strS.Append( "UPDATE R_PQAC SET AC17='F'" );
            strS.Append( " WHERE AC16 LIKE '" + oddNum + "%'" );
            SQLString.Add( strS.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );
            if ( stateOfOdd == "维护删除" )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "DELETE FROM R_PQAMB WHERE AMB001='{0}'" ,oddNum );
                SQLString.Add( strSql.ToString( ) );
            }
            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 删除送审记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="tableNum"></param>
        /// <returns></returns>
        public bool DeleteReview ( string oddNum ,string tableNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_REVIEWS " );
            strSql.Append( " WHERE RES01=@RES01 AND RES06=@RES06" );
            SqlParameter[] parameter = {
                new SqlParameter("@RES01",SqlDbType.NVarChar),
                new SqlParameter("@RES06",SqlDbType.NVarChar)
            };

            parameter[0].Value = tableNum;
            parameter[1].Value = oddNum;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 更改入库标记
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool EditAcs (string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAC SET AC17='F'" );
            strSql.Append( " WHERE AC16 LIKE '" + oddNum + "%'" );

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
        public bool UpdateMain ( MulaolaoLibrary.JiaoMiDuContractLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQO SET " );
            strSql.AppendFormat( "JM02='{0}',",model.JM02 );
            strSql.AppendFormat( "JM03='{0}'," ,model.JM03 );
            strSql.AppendFormat( "JM04='{0}'," ,model.JM04 );
            strSql.AppendFormat( "JM05='{0}'," ,model.JM05 );
            strSql.AppendFormat( "JM06='{0}'," ,model.JM06 );
            strSql.AppendFormat( "JM07='{0}'," ,model.JM07 );
            strSql.AppendFormat( "JM08='{0}'," ,model.JM08 );
            strSql.AppendFormat( "JM19='{0}'," ,model.JM19 );
            strSql.AppendFormat( "JM20='{0}'," ,model.JM20 );
            strSql.AppendFormat( "JM21='{0}'," ,model.JM21 );
            strSql.AppendFormat( "JM22='{0}'," ,model.JM22 );
            strSql.AppendFormat( "JM23='{0}'," ,model.JM23 );
            strSql.AppendFormat( "JM24='{0}'," ,model.JM24 );
            strSql.AppendFormat( "JM25='{0}'," ,model.JM25 );
            strSql.AppendFormat( "JM26='{0}'," ,model.JM26 );
            strSql.AppendFormat( "JM27='{0}'," ,model.JM27 );
            strSql.AppendFormat( "JM28='{0}'," ,model.JM28 );
            strSql.AppendFormat( "JM29='{0}'," ,model.JM29 );
            strSql.AppendFormat( "JM30='{0}'," ,model.JM30 );
            strSql.AppendFormat( "JM31='{0}'," ,model.JM31 );
            strSql.AppendFormat( "JM32='{0}'," ,model.JM32 );
            strSql.AppendFormat( "JM33='{0}'," ,model.JM33 );
            strSql.AppendFormat( "JM34='{0}'," ,model.JM34 );
            strSql.AppendFormat( "JM35='{0}'," ,model.JM35 );
            strSql.AppendFormat( "JM36='{0}'," ,model.JM36 );
            strSql.AppendFormat( "JM37='{0}'," ,model.JM37 );
            strSql.AppendFormat( "JM38='{0}'," ,model.JM38 );
            strSql.AppendFormat( "JM39='{0}'," ,model.JM39 );
            strSql.AppendFormat( "JM40='{0}'," ,model.JM40 );
            strSql.AppendFormat( "JM41='{0}'," ,model.JM41 );
            strSql.AppendFormat( "JM42='{0}'," ,model.JM42 );
            strSql.AppendFormat( "JM43='{0}'," ,model.JM43 );
            strSql.AppendFormat( "JM44='{0}'," ,model.JM44 );
            strSql.AppendFormat( "JM45='{0}'," ,model.JM45 );
            strSql.AppendFormat( "JM46='{0}'," ,model.JM46 );
            strSql.AppendFormat( "JM47='{0}'," ,model.JM47 );
            strSql.AppendFormat( "JM48='{0}'," ,model.JM48 );
            strSql.AppendFormat( "JM49='{0}'," ,model.JM49 );
            strSql.AppendFormat( "JM50='{0}'," ,model.JM50 );
            strSql.AppendFormat( "JM51='{0}'," ,model.JM51 );
            strSql.AppendFormat( "JM52='{0}'," ,model.JM52 );
            strSql.AppendFormat( "JM53='{0}'," ,model.JM53 );
            strSql.AppendFormat( "JM54='{0}'," ,model.JM54 );
            strSql.AppendFormat( "JM55='{0}'," ,model.JM55 );
            strSql.AppendFormat( "JM56='{0}'," ,model.JM56 );
            strSql.AppendFormat( "JM57='{0}'," ,model.JM57 );
            strSql.AppendFormat( "JM58='{0}'," ,model.JM58 );
            strSql.AppendFormat( "JM59='{0}'," ,model.JM59 );
            strSql.AppendFormat( "JM60='{0}'," ,model.JM60 );
            strSql.AppendFormat( "JM61='{0}'," ,model.JM61 );
            strSql.AppendFormat( "JM62='{0}'," ,model.JM62 );
            strSql.AppendFormat( "JM63='{0}'," ,model.JM63 );
            strSql.AppendFormat( "JM64='{0}'," ,model.JM64 );
            strSql.AppendFormat( "JM65='{0}'," ,model.JM65 );
            strSql.AppendFormat( "JM66='{0}'," ,model.JM66 );
            strSql.AppendFormat( "JM67='{0}'," ,model.JM67 );
            strSql.AppendFormat( "JM68='{0}'," ,model.JM68 );
            strSql.AppendFormat( "JM69='{0}'," ,model.JM69 );
            strSql.AppendFormat( "JM70='{0}'," ,model.JM70 );
            strSql.AppendFormat( "JM71='{0}'," ,model.JM71 );
            strSql.AppendFormat( "JM72='{0}'," ,model.JM72 );
            strSql.AppendFormat( "JM73='{0}'," ,model.JM73 );
            strSql.AppendFormat( "JM74='{0}'," ,model.JM74 );
            strSql.AppendFormat( "JM75='{0}'," ,model.JM75 );
            strSql.AppendFormat( "JM76='{0}'," ,model.JM76 );
            strSql.AppendFormat( "JM77='{0}'," ,model.JM77 );
            strSql.AppendFormat( "JM78='{0}'," ,model.JM78 );
            strSql.AppendFormat( "JM79='{0}'," ,model.JM79 );
            strSql.AppendFormat( "JM80='{0}'," ,model.JM80 );
            strSql.AppendFormat( "JM81='{0}'," ,model.JM81 );
            strSql.AppendFormat( "JM82='{0}'," ,model.JM82 );
            strSql.AppendFormat( "JM83='{0}'," ,model.JM83 );
            strSql.AppendFormat( "JM84='{0}'," ,model.JM84 );
            strSql.AppendFormat( "JM85='{0}'," ,model.JM85 );
            strSql.AppendFormat( "JM86='{0}'," ,model.JM86 );
            strSql.AppendFormat( "JM87='{0}'," ,model.JM87 );
            strSql.AppendFormat( "JM88='{0}'," ,model.JM88 );
            strSql.AppendFormat( "JM89='{0}'," ,model.JM89 );
            strSql.AppendFormat( "JM90='{0}'," ,model.JM90 );
            strSql.AppendFormat( "JM98='{0}'," ,model.JM98 );
            strSql.AppendFormat( "JM99='{0}'," ,model.JM99 );
            strSql.AppendFormat( "JM100='{0}'," ,model.JM100 );
            strSql.AppendFormat( "JM101='{0}'," ,model.JM101 );
            strSql.AppendFormat( "JM102='{0}'," ,model.JM102 );
            strSql.AppendFormat( "JM106='{0}'," ,model.JM106 );
            strSql.AppendFormat( "JM107='{0}'," ,model.JM107 );
            strSql.AppendFormat( "JM108='{0}'," ,model.JM108 );
            strSql.AppendFormat( "JM113='{0}'" ,model.JM113 );
            strSql.AppendFormat( " WHERE JM01='{0}'" ,model.JM01 );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.JM01 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableMainTain ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT JM99 FROM R_PQO" );
            strSql.Append( " WHERE JM01=@JM01" );
            SqlParameter[] parameter = {
                new SqlParameter("@JM01",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableNoMain ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQO" );
            strSql.Append( " WHERE JM01!=@JM01" );
            SqlParameter[] parameter = {
                new SqlParameter("@JM01",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 复制一条记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Copy ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQO (" );
            strSql.Append( "JM90,JM100,JM101,JM102,JM103,JM02,JM03,JM09,JM10,JM11,JM12,JM13,JM14,JM15,JM104,JM18,JM91,JM92,JM93,JM94,JM95,JM96,JM19,JM20,JM21,JM22,JM23,JM24,JM25,JM26,JM27,JM29,JM31,JM33,JM34,JM35,JM36,JM37,JM38,JM39,JM40,JM41,JM42,JM43,JM44,JM45,JM46,JM47,JM48,JM49,JM50,JM52,JM54,JM55,JM56,JM57,JM58,JM59,JM60,JM61,JM62,JM63,JM64,JM65,JM66,JM67,JM68,JM71,JM72,JM73,JM74,JM75,JM76,JM77,JM78,JM79,JM80,JM81,JM119,JM120,JM121)" );
            strSql.Append( "SELECT JM90,JM100,JM101,JM102,JM103,JM02,JM03,JM09,JM10,JM11,JM12,JM13,JM14,JM15,JM104,JM18,JM91,JM92,JM93,JM94,JM95,JM96,JM19,JM20,JM21,JM22,JM23,JM24,JM25,JM26,JM27,JM29,JM31,JM33,JM34,JM35,JM36,JM37,JM38,JM39,JM40,JM41,JM42,JM43,JM44,JM45,JM46,JM47,JM48,JM49,JM50,JM52,JM54,JM55,JM56,JM57,JM58,JM59,JM60,JM61,JM62,JM63,JM64,JM65,JM66,JM67,JM68,JM71,JM72,JM73,JM74,JM75,JM76,JM77,JM78,JM79,JM80,JM81,JM119,JM120,JM121 FROM R_PQO" );
            strSql.AppendFormat( " WHERE JM01='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateCopy ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "UPDATE R_PQO SET JM01='{0}',JM106='复制',JM16=DATEADD(DAY,5,GETDATE()) WHERE JM01 IS NULL" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <returns></returns>
        public bool DeleteCopy ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQO WHERE JM01 IS NULL" );

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
        public MulaolaoLibrary.JiaoMiDuContractLibrary GetModel ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,JM01,JM03,JM09,JM92,JM93,JM94,JM95,JM96,JM10,JM11,JM12,JM13,JM14,JM15,JM16,JM17,JM91,JM103,JM104,JM112,JM118,JM119,JM120,JM121 FROM R_PQO" );
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
        public MulaolaoLibrary.JiaoMiDuContractLibrary GetDataRow ( DataRow row )
        {
            MulaolaoLibrary.JiaoMiDuContractLibrary model = new MulaolaoLibrary.JiaoMiDuContractLibrary( );
            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    model.IDX = int.Parse( row["idx"].ToString( ) );
                else
                    model.IDX = 0;
                if ( row["JM01"] != null && row["JM01"].ToString( ) != "" )
                    model.JM01 = row["JM01"].ToString( );
                else
                    model.JM01 = "";
                if ( row["JM03"] != null && row["JM03"].ToString( ) != "" )
                    model.JM03 = row["JM03"].ToString( );
                else
                    model.JM03 = "";
                if ( row["JM09"] != null && row["JM09"].ToString( ) != "" )
                    model.JM09 = row["JM09"].ToString( );
                else
                    model.JM09 = "";
                if ( row["JM10"] != null && row["JM10"].ToString( ) != "" )
                    model.JM10 = decimal.Parse( row["JM10"].ToString( ) );
                else
                    model.JM10 = 0;
                if ( row["JM11"] != null && row["JM11"].ToString( ) != "" )
                    model.JM11 = decimal.Parse( row["JM11"].ToString( ) );
                else
                    model.JM11 = 0;
                if ( row["JM12"] != null && row["JM12"].ToString( ) != "" )
                    model.JM12 = decimal.Parse( row["JM12"].ToString( ) );
                else
                    model.JM12 = 0;
                if ( row["JM13"] != null && row["JM13"].ToString( ) != "" )
                    model.JM13 = decimal.Parse( row["JM13"].ToString( ) );
                else
                    model.JM13 = 0;
                if ( row["JM14"] != null && row["JM14"].ToString( ) != "" )
                    model.JM14 = row["JM14"].ToString( );
                else
                    model.JM14 = "";
                if ( row["JM15"] != null && row["JM15"].ToString( ) != "" )
                    model.JM15 = decimal.Parse( row["JM15"].ToString( ) );
                else
                    model.JM15 = 0;
                if ( row["JM16"] != null && row["JM16"].ToString( ) != "" )
                    model.JM16 = DateTime.Parse( row["JM16"].ToString( ) );
                else
                    model.JM16 = MulaolaoBll . Drity . GetDt ( );
                if ( row["JM17"] != null && row["JM17"].ToString( ) != "" )
                    model.JM17 = DateTime.Parse( row["JM17"].ToString( ) );
                else
                    model.JM17 = MulaolaoBll . Drity . GetDt ( );
                if ( row["JM91"] != null && row["JM91"].ToString( ) != "" )
                    model.JM91 = decimal.Parse( row["JM91"].ToString( ) );
                else
                    model.JM91 = 0;
                if ( row["JM92"] != null && row["JM92"].ToString( ) != "" )
                    model.JM92 = row["JM92"].ToString( );
                else
                    model.JM92 = "";
                if ( row["JM93"] != null && row["JM93"].ToString( ) != "" )
                    model.JM93 = row["JM93"].ToString( );
                else
                    model.JM93 = "";
                if ( row["JM94"] != null && row["JM94"].ToString( ) != "" )
                    model.JM94 = decimal.Parse( row["JM94"].ToString( ) );
                else
                    model.JM94 = 0;
                if ( row["JM95"] != null && row["JM95"].ToString( ) != "" )
                    model.JM95 = decimal.Parse( row["JM95"].ToString( ) );
                else
                    model.JM95 = 0;
                if ( row["JM96"] != null && row["JM96"].ToString( ) != "" )
                    model.JM96 = decimal.Parse( row["JM96"].ToString( ) );
                else
                    model.JM96 = 0;
                if ( row["JM103"] != null && row["JM103"].ToString( ) != "" )
                    model.JM103 = long.Parse( row["JM103"].ToString( ) );
                else
                    model.JM103 = 0;
                if ( row["JM104"] != null && row["JM104"].ToString( ) != "" )
                    model.JM104 = decimal.Parse( row["JM104"].ToString( ) );
                else
                    model.JM104 = 0;
                if ( row["JM112"] != null && row["JM112"].ToString( ) != "" )
                    model.JM112 = decimal.Parse( row["JM112"].ToString( ) );
                else
                    model.JM112 = 0;
                if ( row [ "JM118" ] != null && row [ "JM118" ] . ToString ( ) != "" )
                    model . JM118 = int . Parse ( row [ "JM118" ] . ToString ( ) );
                else
                    model . JM118 = 0;
                if ( row [ "JM119" ] != null && row [ "JM119" ] . ToString ( ) != "" )
                    model . JM119 = decimal . Parse ( row [ "JM119" ] . ToString ( ) );
                else
                    model . JM119 = 0;
                if ( row [ "JM120" ] != null && row [ "JM120" ] . ToString ( ) != "" )
                    model . JM120 = decimal . Parse ( row [ "JM120" ] . ToString ( ) );
                else
                    model . JM120 = 0;
                if ( row [ "JM121" ] != null && row [ "JM121" ] . ToString ( ) != "" )
                    model . JM121 = decimal . Parse ( row [ "JM121" ] . ToString ( ) );
                else
                    model . JM121 = 0;
            }
            return model;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public MulaolaoLibrary.JiaoMiDuContractLibrary GetModel ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQO" );
            strSql.Append( " WHERE JM01=@JM01");
            SqlParameter[] parameter = {
                new SqlParameter("@JM01",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            DataTable dt = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( dt.Rows.Count >= 1 )
                return GetDataRo( dt.Rows[0] );
            else
                return null;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.JiaoMiDuContractLibrary GetDataRo ( DataRow row )
        {
            MulaolaoLibrary.JiaoMiDuContractLibrary model = new MulaolaoLibrary.JiaoMiDuContractLibrary( );

            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    model.IDX = int.Parse( row["idx"].ToString( ) );
                if ( row["JM01"] != null && row["JM01"].ToString( ) != "" )
                    model.JM01 = row["JM01"].ToString( );
                else
                    model.JM01 = string.Empty;
                if ( row["JM02"] != null && row["JM02"].ToString( ) != "" )
                    model.JM02 = row["JM02"].ToString( );
                else
                    model.JM02 = string.Empty;
                if ( row["JM03"] != null && row["JM03"].ToString( ) != "" )
                    model.JM03 = row["JM03"].ToString( );
                else
                    model.JM03 = string.Empty;
                if ( row["JM04"] != null && row["JM04"].ToString( ) != "" )
                    model.JM04 = row["JM04"].ToString( );
                else
                    model.JM04 = string.Empty;
                if ( row["JM05"] != null && row["JM05"].ToString( ) != "" )
                    model.JM05 = DateTime.Parse( row["JM05"].ToString( ) );
                else
                    model.JM05 = MulaolaoBll . Drity . GetDt ( );
                if ( row["JM06"] != null && row["JM06"].ToString( ) != "" )
                    model.JM06 = row["JM06"].ToString( );
                else
                    model.JM06 = string.Empty;
                if ( row["JM07"] != null && row["JM07"].ToString( ) != "" )
                    model.JM07 = DateTime.Parse( row["JM07"].ToString( ) );
                else
                    model.JM07 = MulaolaoBll . Drity . GetDt ( );
                if ( row["JM08"] != null && row["JM08"].ToString( ) != "" )
                    model.JM08 = row["JM08"].ToString( );
                else
                    model.JM08 = string.Empty;
                if ( row["JM19"] != null && row["JM19"].ToString( ) != "" )
                    model.JM19 = row["JM19"].ToString( );
                else
                    model.JM19 = string.Empty;
                if ( row["JM20"] != null && row["JM20"].ToString( ) != "" )
                    model.JM20 = row["JM20"].ToString( );
                else
                    model.JM20 = string.Empty;
                if ( row["JM21"] != null && row["JM21"].ToString( ) != "" )
                    model.JM21 = row["JM21"].ToString( );
                else
                    model.JM21 = string.Empty;
                if ( row["JM22"] != null && row["JM22"].ToString( ) != "" )
                    model.JM22 = row["JM22"].ToString( );
                else
                    model.JM22 = string.Empty;
                if ( row["JM23"] != null && row["JM23"].ToString( ) != "" )
                    model.JM23 = row["JM23"].ToString( );
                else
                    model.JM23 = string.Empty;
                if ( row["JM24"] != null && row["JM24"].ToString( ) != "" )
                    model.JM24 = row["JM24"].ToString( );
                else
                    model.JM24 = string.Empty;
                if ( row["JM25"] != null && row["JM25"].ToString( ) != "" )
                    model.JM25 = row["JM25"].ToString( );
                else
                    model.JM25 = string.Empty;
                if ( row["JM26"] != null && row["JM26"].ToString( ) != "" )
                    model.JM26 = row["JM26"].ToString( );
                else
                    model.JM26 = string.Empty;
                if ( row["JM27"] != null && row["JM27"].ToString( ) != "" )
                    model.JM27 = row["JM27"].ToString( );
                else
                    model.JM27 = string.Empty;
                if ( row["JM28"] != null && row["JM28"].ToString( ) != "" )
                    model.JM28 = DateTime.Parse( row["JM28"].ToString( ) );
                else
                    model.JM28 = MulaolaoBll . Drity . GetDt ( );
                if ( row["JM29"] != null && row["JM29"].ToString( ) != "" )
                    model.JM29 = row["JM29"].ToString( );
                else
                    model.JM29 = string.Empty;
                if ( row["JM30"] != null && row["JM30"].ToString( ) != "" )
                    model.JM30 = DateTime.Parse( row["JM30"].ToString( ) );
                else
                    model.JM30 = MulaolaoBll . Drity . GetDt ( );
                if ( row["JM31"] != null && row["JM31"].ToString( ) != "" )
                    model.JM31 = row["JM31"].ToString( );
                else
                    model.JM31 = string.Empty;
                if ( row["JM32"] != null && row["JM32"].ToString( ) != "" )
                    model.JM32 = DateTime.Parse( row["JM32"].ToString( ) );
                else
                    model.JM32 = MulaolaoBll . Drity . GetDt ( );
                if ( row["JM33"] != null && row["JM33"].ToString( ) != "" )
                    model.JM33 = row["JM33"].ToString( );
                else
                    model.JM33 = string.Empty;
                if ( row["JM34"] != null && row["JM34"].ToString( ) != "" )
                    model.JM34 = row["JM34"].ToString( );
                else
                    model.JM34 = string.Empty;
                if ( row["JM35"] != null && row["JM35"].ToString( ) != "" )
                    model.JM35 = row["JM35"].ToString( );
                else
                    model.JM35 = string.Empty;
                if ( row["JM36"] != null && row["JM36"].ToString( ) != "" )
                    model.JM36 = row["JM36"].ToString( );
                else
                    model.JM36 = string.Empty;
                if ( row["JM37"] != null && row["JM37"].ToString( ) != "" )
                    model.JM37 = row["JM37"].ToString( );
                else
                    model.JM37 = string.Empty;
                if ( row["JM38"] != null && row["JM38"].ToString( ) != "" )
                    model.JM38 = row["JM38"].ToString( );
                else
                    model.JM38 = string.Empty;
                if ( row["JM39"] != null && row["JM39"].ToString( ) != "" )
                    model.JM39 = row["JM39"].ToString( );
                else
                    model.JM39 = string.Empty;
                if ( row["JM40"] != null && row["JM40"].ToString( ) != "" )
                    model.JM40 = row["JM40"].ToString( );
                else
                    model.JM40 = string.Empty;
                if ( row["JM41"] != null && row["JM41"].ToString( ) != "" )
                    model.JM41 = row["JM41"].ToString( );
                else
                    model.JM41 = string.Empty;
                if ( row["JM42"] != null && row["JM42"].ToString( ) != "" )
                    model.JM42 = row["JM42"].ToString( );
                else
                    model.JM42 = string.Empty;
                if ( row["JM43"] != null && row["JM43"].ToString( ) != "" )
                    model.JM43 = row["JM43"].ToString( );
                else
                    model.JM43 = string.Empty;
                if ( row["JM44"] != null && row["JM44"].ToString( ) != "" )
                    model.JM44 = row["JM44"].ToString( );
                else
                    model.JM44 = string.Empty;
                if ( row["JM45"] != null && row["JM45"].ToString( ) != "" )
                    model.JM45 = row["JM45"].ToString( );
                else
                    model.JM45 = string.Empty;
                if ( row["JM46"] != null && row["JM46"].ToString( ) != "" )
                    model.JM46 = row["JM46"].ToString( );
                else
                    model.JM46 = string.Empty;
                if ( row["JM47"] != null && row["JM47"].ToString( ) != "" )
                    model.JM47 = row["JM47"].ToString( );
                else
                    model.JM47 = string.Empty;
                if ( row["JM48"] != null && row["JM48"].ToString( ) != "" )
                    model.JM48 = row["JM48"].ToString( );
                else
                    model.JM48 = string.Empty;
                if ( row["JM49"] != null && row["JM49"].ToString( ) != "" )
                    model.JM49 = row["JM49"].ToString( );
                else
                    model.JM49 = string.Empty;
                if ( row["JM50"] != null && row["JM50"].ToString( ) != "" )
                    model.JM50 = row["JM50"].ToString( );
                else
                    model.JM50 = string.Empty;
                if ( row["JM51"] != null && row["JM51"].ToString( ) != "" )
                    model.JM51 = DateTime.Parse( row["JM51"].ToString( ) );
                else
                    model.JM51 = MulaolaoBll . Drity . GetDt ( );
                if ( row["JM52"] != null && row["JM52"].ToString( ) != "" )
                    model.JM52 = row["JM52"].ToString( );
                else
                    model.JM52 = string.Empty;
                if ( row["JM53"] != null && row["JM53"].ToString( ) != "" )
                    model.JM53 = DateTime.Parse( row["JM53"].ToString( ) );
                else
                    model.JM53 = MulaolaoBll . Drity . GetDt ( );
                if ( row["JM54"] != null && row["JM54"].ToString( ) != "" )
                    model.JM54 = row["JM54"].ToString( );
                else
                    model.JM54 = string.Empty;
                if ( row["JM55"] != null && row["JM55"].ToString( ) != "" )
                    model.JM55 = row["JM55"].ToString( );
                else
                    model.JM55 = string.Empty;
                if ( row["JM56"] != null && row["JM56"].ToString( ) != "" )
                    model.JM56 = row["JM56"].ToString( );
                else
                    model.JM56 = string.Empty;
                if ( row["JM57"] != null && row["JM57"].ToString( ) != "" )
                    model.JM57 = row["JM57"].ToString( );
                else
                    model.JM57 = string.Empty;
                if ( row["JM58"] != null && row["JM58"].ToString( ) != "" )
                    model.JM58 = row["JM58"].ToString( );
                else
                    model.JM58 = string.Empty;
                if ( row["JM59"] != null && row["JM59"].ToString( ) != "" )
                    model.JM59 = row["JM59"].ToString( );
                else
                    model.JM59 = string.Empty;
                if ( row["JM60"] != null && row["JM60"].ToString( ) != "" )
                    model.JM60 = row["JM60"].ToString( );
                else
                    model.JM60 = string.Empty;
                if ( row["JM61"] != null && row["JM61"].ToString( ) != "" )
                    model.JM61 = row["JM61"].ToString( );
                else
                    model.JM61 = string.Empty;
                if ( row["JM62"] != null && row["JM62"].ToString( ) != "" )
                    model.JM62 = row["JM62"].ToString( );
                else
                    model.JM62 = string.Empty;
                if ( row["JM63"] != null && row["JM63"].ToString( ) != "" )
                    model.JM63 = row["JM63"].ToString( );
                else
                    model.JM63 = string.Empty;
                if ( row["JM64"] != null && row["JM64"].ToString( ) != "" )
                    model.JM64 = row["JM64"].ToString( );
                else
                    model.JM64 = string.Empty;
                if ( row["JM65"] != null && row["JM65"].ToString( ) != "" )
                    model.JM65 = row["JM65"].ToString( );
                else
                    model.JM65 = string.Empty;
                if ( row["JM66"] != null && row["JM66"].ToString( ) != "" )
                    model.JM66 = row["JM66"].ToString( );
                else
                    model.JM66 = string.Empty;
                if ( row["JM67"] != null && row["JM67"].ToString( ) != "" )
                    model.JM67 = int.Parse( row["JM67"].ToString( ) );
                else
                    model.JM67 = 0;
                if ( row["JM68"] != null && row["JM68"].ToString( ) != "" )
                    model.JM68 = row["JM68"].ToString( );
                else
                    model.JM68 = string.Empty;
                if ( row["JM69"] != null && row["JM69"].ToString( ) != "" )
                    model.JM69 = row["JM69"].ToString( );
                else
                    model.JM69 = string.Empty;
                if ( row["JM70"] != null && row["JM70"].ToString( ) != "" )
                    model.JM70 = row["JM70"].ToString( );
                else
                    model.JM70 = string.Empty;
                if ( row["JM71"] != null && row["JM71"].ToString( ) != "" )
                    model.JM71 = row["JM71"].ToString( );
                else
                    model.JM71 = string.Empty;
                if ( row["JM72"] != null && row["JM72"].ToString( ) != "" )
                    model.JM72 = row["JM72"].ToString( );
                else
                    model.JM72 = string.Empty;
                if ( row["JM73"] != null && row["JM73"].ToString( ) != "" )
                    model.JM73 = long.Parse( row["JM73"].ToString( ) );
                else
                    model.JM73 = 0;
                if ( row["JM74"] != null && row["JM74"].ToString( ) != "" )
                    model.JM74 = long.Parse( row["JM74"].ToString( ) );
                else
                    model.JM74 = 0;
                if ( row["JM75"] != null && row["JM75"].ToString( ) != "" )
                    model.JM75 = long.Parse( row["JM75"].ToString( ) );
                else
                    model.JM75 = 0;
                if ( row["JM76"] != null && row["JM76"].ToString( ) != "" )
                    model.JM76 = long.Parse( row["JM76"].ToString( ) );
                else
                    model.JM76 = 0;
                if ( row["JM77"] != null && row["JM77"].ToString( ) != "" )
                    model.JM77 = long.Parse( row["JM77"].ToString( ) );
                else
                    model.JM77 = 0;
                if ( row["JM78"] != null && row["JM78"].ToString( ) != "" )
                    model.JM78 = long.Parse( row["JM78"].ToString( ) );
                else
                    model.JM78 = 0;
                if ( row["JM79"] != null && row["JM79"].ToString( ) != "" )
                    model.JM79 = long.Parse( row["JM79"].ToString( ) );
                else
                    model.JM79 = 0;
                if ( row["JM80"] != null && row["JM80"].ToString( ) != "" )
                    model.JM80 = long.Parse( row["JM80"].ToString( ) );
                else
                    model.JM80 = 0;
                if ( row["JM81"] != null && row["JM81"].ToString( ) != "" )
                    model.JM81 = long.Parse( row["JM81"].ToString( ) );
                else
                    model.JM81 = 0;
                if ( row["JM82"] != null && row["JM82"].ToString( ) != "" )
                    model.JM82 = row["JM82"].ToString( );
                else
                    model.JM82 = string.Empty;
                if ( row["JM83"] != null && row["JM83"].ToString( ) != "" )
                    model.JM83 = row["JM83"].ToString( );
                else
                    model.JM83 = string.Empty;
                if ( row["JM84"] != null && row["JM84"].ToString( ) != "" )
                    model.JM84 = DateTime.Parse( row["JM84"].ToString( ) );
                else
                    model.JM84 = MulaolaoBll . Drity . GetDt ( );
                if ( row["JM85"] != null && row["JM85"].ToString( ) != "" )
                    model.JM85 = row["JM85"].ToString( );
                else
                    model.JM85 = string.Empty;
                if ( row["JM86"] != null && row["JM86"].ToString( ) != "" )
                    model.JM86 = DateTime.Parse( row["JM86"].ToString( ) );
                else
                    model.JM86 = MulaolaoBll . Drity . GetDt ( );
                if ( row["JM87"] != null && row["JM87"].ToString( ) != "" )
                    model.JM87 = row["JM87"].ToString( );
                else
                    model.JM87 = string.Empty;
                if ( row["JM88"] != null && row["JM88"].ToString( ) != "" )
                    model.JM88 = DateTime.Parse( row["JM88"].ToString( ) );
                else
                    model.JM88 = MulaolaoBll . Drity . GetDt ( );
                if ( row["JM89"] != null && row["JM89"].ToString( ) != "" )
                    model.JM89 = DateTime.Parse( row["JM89"].ToString( ) );
                else
                    model.JM89 = MulaolaoBll . Drity . GetDt ( );
                if ( row["JM90"] != null && row["JM90"].ToString( ) != "" )
                    model.JM90 = row["JM90"].ToString( );
                else
                    model.JM90 = string.Empty;
                if ( row["JM98"] != null && row["JM98"].ToString( ) != "" )
                    model.JM98 = row["JM98"].ToString( );
                else
                    model.JM98 = string.Empty;
                if ( row["JM99"] != null && row["JM99"].ToString( ) != "" )
                    model.JM99 = row["JM99"].ToString( );
                else
                    model.JM99 = string.Empty;
                if ( row["JM100"] != null && row["JM100"].ToString( ) != "" )
                    model.JM100 = row["JM100"].ToString( );
                else
                    model.JM100 = string.Empty;
                if ( row["JM101"] != null && row["JM101"].ToString( ) != "" )
                    model.JM101 = row["JM101"].ToString( );
                else
                    model.JM101 = string.Empty;
                if ( row["JM102"] != null && row["JM102"].ToString( ) != "" )
                    model.JM102 = row["JM102"].ToString( );
                else
                    model.JM102 = string.Empty;
                if ( row["JM103"] != null && row["JM103"].ToString( ) != "" )
                    model.JM103 = int.Parse( row["JM103"].ToString( ) );
                if ( row["JM106"] != null && row["JM106"].ToString( ) != "" )
                    model.JM106 = row["JM106"].ToString( );
                else
                    model.JM106 = string.Empty;
                if ( row["JM107"] != null && row["JM107"].ToString( ) != "" )
                    model.JM107 = row["JM107"].ToString( );
                else
                    model.JM107 = string.Empty;
                if ( row["JM108"] != null && row["JM108"].ToString( ) != "" )
                    model.JM108 = row["JM108"].ToString( );
                else
                    model.JM108 = string.Empty;
                if ( row["JM113"] != null && row["JM113"].ToString( ) != "" )
                    model.JM113 = row["JM113"].ToString( );
                else
                    model.JM113 = string.Empty;
            }

            return model;
        }

        /// <summary>
        /// 获取供应商
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public DataTable GetDataTableSecond ( string number)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DGA003,DGA008,DGA011,DGA017,DGA009,DGA012 FROM TPADGA" );
            strSql.Append( " WHERE DGA001=@DGA001" );
            SqlParameter[] parameter = {
                new SqlParameter("@DGA001",SqlDbType.NVarChar)
            };

            parameter[0].Value = number;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOther ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT JM27,JM29,JM31,JM50,JM52,JM68,JM69,JM70,JM92,JM93 FROM R_PQO" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public DataTable GetDataTableTable ( string no )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT '' JM09,JM92,JM93,JM10,JM11,JM12,JM13,JM14,JM15,JM91,JM94,JM95,JM96 FROM R_PQO" );
            strSql.Append( " WHERE JM102=@JM102" );
            SqlParameter[] parameter = {
                new SqlParameter("@JM102",SqlDbType.NVarChar)
            };

            parameter[0].Value = no;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 是否已经入库
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableStrAo ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQAO" );
            strSql.Append( " WHERE AO002=@AO002" );
            SqlParameter[] parameter = {
                new SqlParameter("@AO002",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableStr ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT JM100,JM102,JM09,JM103,JM94,JM95,JM96,JM13,JM12,JM104,JM04,JM07,(SELECT DBA002 FROM TPADBA WHERE DBA001=JM02) JM02,idx FROM R_PQO" );
            strSql.Append( " WHERE JM01=@JM01" );
            SqlParameter[] parameter = {
                new SqlParameter("@JM01",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableAc ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AC02,AC04,AC05,AC03+ISNULL(AC26,0) AC03,AC10+ISNULL(AC27,0) AC10 FROM R_PQAC" );
            strSql.Append( " WHERE AC18=@AC18" );
            SqlParameter[] parameter = {
                new SqlParameter("@AC18",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="oddNum"></param>
        /// <param name="specification"></param>
        /// <returns></returns>
        public bool UpdateStr ( MulaolaoLibrary.JiaoMiDuContractLibrary model,string oddNum ,string specification,long AO004,decimal AO005)
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "UPDATE R_PQAC SET AC03='{0}',AC10='{1}' WHERE AC18='{2}' AND AC02='{3}' AND AC04='{4}' AND AC05='{5}'" ,model.JM103 ,model.JM104 ,oddNum ,model.JM102 ,model.JM09 ,specification );
            SQLString.Add( strSql.ToString( ) );
            StringBuilder strS = new StringBuilder( );
            strS.AppendFormat( "UPDATE R_PQAO SET AO004='{0}',AO005='{1}' WHERE AO002='{2}' AND AO003='{3}'" ,AO004 ,AO005 ,model.JM01 ,model.IDX );
            SQLString.Add( strS.ToString( ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="oddNum"></param>
        /// <param name="specification"></param>
        /// <param name="AO004"></param>
        /// <param name="AO005"></param>
        /// <returns></returns>
        public bool UpdateInsertAcTran ( MulaolaoLibrary.JiaoMiDuContractLibrary model ,string oddNum ,string specification ,long AO004 ,decimal AO005 )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "UPDATE R_PQAC SET AC03='{0}',AC10='{1}' WHERE AC18='{2}' AND AC02='{3}' AND AC04='{4}' AND AC05='{5}'" ,model.JM103 ,model.JM104 ,oddNum ,model.JM102 ,model.JM09 ,specification );
            SQLString.Add( strSql.ToString( ) );
            StringBuilder strS = new StringBuilder( );
            strS.AppendFormat( "INSERT INTO R_PQAO (AO001,AO002,AO003,AO004,AO005) VALUES ('{0}','{1}','{2}','{3}','{4}')" ,oddNum ,model.JM01 ,model.IDX ,AO004 ,AO005 );
            SQLString.Add( strS.ToString( ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }


        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="jm109"></param>
        /// <param name="jm110"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool UpdateLastTime ( long jm109 ,decimal jm110 ,int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "UPDATE R_PQO SET JM109='{0}',JM110='{1}' WHERE idx='{2}'" ,jm109 ,jm110 ,idx );

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
        public bool UpdateBatch ( MulaolaoLibrary.JiaoMiDuContractLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQO SET " );
            strSql.AppendFormat( "JM15='{0}',",model.JM15 );
            strSql.AppendFormat( "JM103='{0}'," ,model.JM103 );
            strSql.AppendFormat( "JM104='{0}'" ,model.JM104 );
            strSql.AppendFormat( " WHERE idx='{0}'" ,model.IDX );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.JM01 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 入库标志更改
        /// </summary>
        /// <returns></returns>
        public bool signOfStorage ( )
        {
            ArrayList SQLString = new ArrayList( );
            string strWhere = "", strNum = "";
            DataTable da = GetDataTableOfStorage( );
            if (da!=null && da.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < da.Rows.Count ; i++ )
                {
                    string sx = da.Rows[i]["AC16"].ToString( );
                    if ( sx.Contains( "," ) )
                    {
                        foreach ( string st in sx.Split( ',') )
                        {
                            if ( strWhere == "" )
                                strWhere = "'" + sx + "'";
                            else
                                strWhere = strWhere + "," + "'" + sx + "'";
                        }
                    }
                    else
                    {
                        if ( strWhere == "" )
                            strWhere = "'" + sx + "'";
                        else
                            strWhere = strWhere + "," + "'" + sx + "'";
                    }
                    if ( strNum == "" )
                        strNum = "'" + da.Rows[i]["AC18"].ToString( ) + "'";
                    else
                        strNum = strNum + "," + "'" + da.Rows[i]["AC18"].ToString( ) + "'";
                }
                if ( strWhere != "" )
                    SQLString.Add( EditPqo( strWhere ) );
                if ( strNum != "" )
                    SQLString.Add( EditAc( strNum ) );
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取所有入库记录
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfStorage ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT AC16,AC18 FROM R_PQAC WHERE (AC17!='T' OR AC17 IS NULL OR AC17='') AND AC16 LIKE 'R_338%'" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 更改入库标志
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public string EditAc (string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAC SET AC17='T'" );
            strSql.Append( " WHERE AC18 IN (" + strWhere + ")" );

            return strSql.ToString( );
        }

        /// <summary>
        /// 更改合同标志
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public string EditPqo ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQO SET JM111='T'" );
            strSql.Append( " WHERE JM01 IN (" + strWhere + ")" );

            return strSql.ToString( );
        }
        
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfPrice ( string numOf ,string nameOf ,decimal lon ,decimal wicth ,decimal high )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT TOP 1 CONVERT(DECIMAL(18,2),CASE WHEN JM96=0 OR JM95=0 OR JM94=0 THEN 0 ELSE JM11/JM94/JM95/JM96/0.000001 END) JM,JM11 FROM R_PQO" );
            strSql.Append( " WHERE JM102=@JM102 AND JM09=@JM09 AND JM94=@JM94 AND JM95=@JM95 AND JM96=@JM96" );
            strSql.Append( " ORDER BY idx DESC" );
            SqlParameter[] parameter = {
                new SqlParameter("@JM102",SqlDbType.NVarChar),
                new SqlParameter("@JM09",SqlDbType.NVarChar),
                new SqlParameter("@JM94",SqlDbType.Decimal),
                new SqlParameter("@JM95",SqlDbType.Decimal),
                new SqlParameter("@JM96",SqlDbType.Decimal)
            };
            parameter[0].Value = numOf;
            parameter[1].Value = nameOf;
            parameter[2].Value = lon;
            parameter[3].Value = wicth;
            parameter[4].Value = high;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfReceviable ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT JM90,CASE WHEN JM09 LIKE '%密度板%' THEN '密度板' WHEN JM09 LIKE '%胶合板%' OR JM09 LIKE '%曲板%' THEN '胶合板' ELSE '胶合板' END JM09,JM93,JM14,CASE WHEN JM107='F' OR JM107 IS NULL THEN 'F' WHEN JM107='T' THEN 'T' END JM107,SUM(CASE WHEN JM10 = 0 THEN 0 WHEN JM10 != 0 THEN CONVERT( DECIMAL(18,2),JM103/JM10* JM11 ) END) JM FROM R_PQO A INNER JOIN R_REVIEWS D ON A.JM01=D.RES06 AND RES05='执行' WHERE JM90!=''" );
            strSql.AppendFormat( " AND JM01='{0}'" ,oddNum );
            strSql.Append( " AND (JM90!='' AND JM90 IS NOT NULL) GROUP BY JM90,JM09,JM93,JM14,JM107" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 写数据到241
        /// </summary>
        /// <param name="modelAm"></param>
        /// <returns></returns>
        public bool UpdateOfReceviable ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum )
        {
            ArrayList SQLString = new ArrayList( );
            ByOneBy( modelAm ,oddNum ,SQLString );
            //WriteReceivableToGeneralLedger.ByOneByJiao( modelAm ,oddNum ,SQLString );
            if ( modelAm.AM296 > 0 )
            {
                StringBuilder strSqlAM296 = new StringBuilder( );
                strSqlAM296.AppendFormat( "UPDATE R_PQAM SET AM296={0} WHERE AM002='{1}'" ,modelAm.AM296 ,modelAm.AM002 );
                SQLString.Add( strSqlAM296.ToString( ) );
            }
            if ( modelAm.AM298 > 0 )
            {
                StringBuilder strSqlAM298 = new StringBuilder( );
                strSqlAM298.AppendFormat( "UPDATE R_PQAM SET AM298={0} WHERE AM002='{1}'" ,modelAm.AM298 ,modelAm.AM002 );
                SQLString.Add( strSqlAM298.ToString( ) );
            }
            if ( modelAm.AM300 > 0 )
            {
                StringBuilder strSqlAM300 = new StringBuilder( );
                strSqlAM300.AppendFormat( "UPDATE R_PQAM SET AM300={0} WHERE AM002='{1}'" ,modelAm.AM300 ,modelAm.AM002 );
                SQLString.Add( strSqlAM300.ToString( ) );
            }
            if ( modelAm.AM301 > 0 )
            {
                StringBuilder strSqlAM301 = new StringBuilder( );
                strSqlAM301.AppendFormat( "UPDATE R_PQAM SET AM301={0} WHERE AM002='{1}'" ,modelAm.AM301 ,modelAm.AM002 );
                SQLString.Add( strSqlAM301.ToString( ) );
            }
            if ( modelAm.AM304 > 0 )
            {
                StringBuilder strSqlAM304 = new StringBuilder( );
                strSqlAM304.AppendFormat( "UPDATE R_PQAM SET AM304={0} WHERE AM002='{1}'" ,modelAm.AM304 ,modelAm.AM002 );
                SQLString.Add( strSqlAM304.ToString( ) );
            }
            if ( modelAm.AM306 > 0 )
            {
                StringBuilder strSqlAM306 = new StringBuilder( );
                strSqlAM306.AppendFormat( "UPDATE R_PQAM SET AM306={0} WHERE AM002='{1}'" ,modelAm.AM306 ,modelAm.AM002 );
                SQLString.Add( strSqlAM306.ToString( ) );
            }
            if ( modelAm.AM307 > 0 )
            {
                StringBuilder strSqlAM307 = new StringBuilder( );
                strSqlAM307.AppendFormat( "UPDATE R_PQAM SET AM307={0} WHERE AM002='{1}'" ,modelAm.AM307 ,modelAm.AM002 );
                SQLString.Add( strSqlAM307.ToString( ) );
            }
            if ( modelAm.AM311 > 0 )
            {
                StringBuilder strSqlAM311 = new StringBuilder( );
                strSqlAM311.AppendFormat( "UPDATE R_PQAM SET AM311={0} WHERE AM002='{1}'" ,modelAm.AM311 ,modelAm.AM002 );
                SQLString.Add( strSqlAM311.ToString( ) );
            }
            if ( modelAm.AM313 > 0 )
            {
                StringBuilder strSqlAM313 = new StringBuilder( );
                strSqlAM313.AppendFormat( "UPDATE R_PQAM SET AM313={0} WHERE AM002='{1}'" ,modelAm.AM313 ,modelAm.AM002 );
                SQLString.Add( strSqlAM313.ToString( ) );
            }
            if ( modelAm.AM315 > 0 )
            {
                StringBuilder strSqlAM315 = new StringBuilder( );
                strSqlAM315.AppendFormat( "UPDATE R_PQAM SET AM315={0} WHERE AM002='{1}'" ,modelAm.AM315 ,modelAm.AM002 );
                SQLString.Add( strSqlAM315.ToString( ) );
            }
            if ( modelAm.AM318 > 0 )
            {
                StringBuilder strSqlAM318 = new StringBuilder( );
                strSqlAM318.AppendFormat( "UPDATE R_PQAM SET AM318={0} WHERE AM002='{1}'" ,modelAm.AM318 ,modelAm.AM002 );
                SQLString.Add( strSqlAM318.ToString( ) );
            }
            if ( modelAm.AM320 > 0 )
            {
                StringBuilder strSqlAM320 = new StringBuilder( );
                strSqlAM320.AppendFormat( "UPDATE R_PQAM SET AM320={0} WHERE AM002='{1}'" ,modelAm.AM320 ,modelAm.AM002 );
                SQLString.Add( strSqlAM320.ToString( ) );
            }
            if ( modelAm.AM321 > 0 )
            {
                StringBuilder strSqlAM321 = new StringBuilder( );
                strSqlAM321.AppendFormat( "UPDATE R_PQAM SET AM321={0} WHERE AM002='{1}'" ,modelAm.AM321 ,modelAm.AM002 );
                SQLString.Add( strSqlAM321.ToString( ) );
            }
            if ( modelAm.AM324 > 0 )
            {
                StringBuilder strSqlAM324 = new StringBuilder( );
                strSqlAM324.AppendFormat( "UPDATE R_PQAM SET AM324={0} WHERE AM002='{1}'" ,modelAm.AM324 ,modelAm.AM002 );
                SQLString.Add( strSqlAM324.ToString( ) );
            }
            if ( modelAm.AM326 > 0 )
            {
                StringBuilder strSqlAM326 = new StringBuilder( );
                strSqlAM326.AppendFormat( "UPDATE R_PQAM SET AM326={0} WHERE AM002='{1}'" ,modelAm.AM326 ,modelAm.AM002 );
                SQLString.Add( strSqlAM326.ToString( ) );
            }
            if ( modelAm.AM328 > 0 )
            {
                StringBuilder strSqlAM328 = new StringBuilder( );
                strSqlAM328.AppendFormat( "UPDATE R_PQAM SET AM328={0} WHERE AM002='{1}'" ,modelAm.AM328 ,modelAm.AM002 );
                SQLString.Add( strSqlAM328.ToString( ) );
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        void ByOneBy ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "SELECT AMB296,AMB298,AMB300,AMB301,AMB304,AMB306,AMB307,AMB311,AMB313,AMB315,AMB318,AMB320,AMB321,AMB324,AMB326,AMB328 FROM R_PQAMB WHERE AMB001='{0}'" ,oddNum );

            DataTable de = SqlHelper.ExecuteDataTable( "SELECT AM296,AM298,AM300,AM301,AM304,AM306,AM307,AM311,AM313,AM315,AM318,AM320,AM321,AM324,AM326,AM328 FROM R_PQAM WHERE AM002='" + modelAm.AM002 + "'" );
            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            if ( da != null && da.Rows.Count > 0 )
            {
                if ( modelAm.AM296 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB296='{0}' WHERE AMB001='{1}'" ,modelAm.AM296 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM298 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB298='{0}' WHERE AMB001='{1}'" ,modelAm.AM298 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM300 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB300='{0}' WHERE AMB001='{1}'" ,modelAm.AM300 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM301 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB301='{0}' WHERE AMB001='{1}'" ,modelAm.AM301 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM304 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB304='{0}' WHERE AMB001='{1}'" ,modelAm.AM304 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM306 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB306='{0}' WHERE AMB001='{1}'" ,modelAm.AM306 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM307 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB307='{0}' WHERE AMB001='{1}'" ,modelAm.AM307 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM311 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB311='{0}' WHERE AMB001='{1}'" ,modelAm.AM311 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM313 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB313='{0}' WHERE AMB001='{1}'" ,modelAm.AM313 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM315 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB315='{0}' WHERE AMB001='{1}'" ,modelAm.AM315 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM318 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB318='{0}' WHERE AMB001='{1}'" ,modelAm.AM318 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM320 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB320='{0}' WHERE AMB001='{1}'" ,modelAm.AM320 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM321 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB321='{0}' WHERE AMB001='{1}'" ,modelAm.AM321 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM324 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB324='{0}' WHERE AMB001='{1}'" ,modelAm.AM324 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM326 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB326='{0}' WHERE AMB001='{1}'" ,modelAm.AM326 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM328 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB328='{0}' WHERE AMB001='{1}'" ,modelAm.AM328 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
               
                if ( de != null && de.Rows.Count > 0 )
                {
                    modelAm.AM296 = modelAm.AM296 - ( string.IsNullOrEmpty( da.Rows[0]["AMB296"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB296"].ToString( ) ) );
                    modelAm.AM298 = modelAm.AM298 - ( string.IsNullOrEmpty( da.Rows[0]["AMB298"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB298"].ToString( ) ) );
                    modelAm.AM300 = modelAm.AM300 - ( string.IsNullOrEmpty( da.Rows[0]["AMB300"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB300"].ToString( ) ) );
                    modelAm.AM301 = modelAm.AM301 - ( string.IsNullOrEmpty( da.Rows[0]["AMB301"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB301"].ToString( ) ) );
                    modelAm.AM304 = modelAm.AM304 - ( string.IsNullOrEmpty( da.Rows[0]["AMB304"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB304"].ToString( ) ) );
                    modelAm.AM306 = modelAm.AM306 - ( string.IsNullOrEmpty( da.Rows[0]["AMB306"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB306"].ToString( ) ) );
                    modelAm.AM307 = modelAm.AM307 - ( string.IsNullOrEmpty( da.Rows[0]["AMB307"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB307"].ToString( ) ) );
                    modelAm.AM311 = modelAm.AM311 - ( string.IsNullOrEmpty( da.Rows[0]["AMB311"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB311"].ToString( ) ) );
                    modelAm.AM313 = modelAm.AM313 - ( string.IsNullOrEmpty( da.Rows[0]["AMB313"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB313"].ToString( ) ) );
                    modelAm.AM315 = modelAm.AM315 - ( string.IsNullOrEmpty( da.Rows[0]["AMB315"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB315"].ToString( ) ) );
                    modelAm.AM318 = modelAm.AM318 - ( string.IsNullOrEmpty( da.Rows[0]["AMB318"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB318"].ToString( ) ) );
                    modelAm.AM320 = modelAm.AM320 - ( string.IsNullOrEmpty( da.Rows[0]["AMB320"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB320"].ToString( ) ) );
                    modelAm.AM321 = modelAm.AM321 - ( string.IsNullOrEmpty( da.Rows[0]["AMB321"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB321"].ToString( ) ) );
                    modelAm.AM324 = modelAm.AM324 - ( string.IsNullOrEmpty( da.Rows[0]["AMB324"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB324"].ToString( ) ) );
                    modelAm.AM326 = modelAm.AM326 - ( string.IsNullOrEmpty( da.Rows[0]["AMB326"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB326"].ToString( ) ) );
                    modelAm.AM328 = modelAm.AM328 - ( string.IsNullOrEmpty( da.Rows[0]["AMB328"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB328"].ToString( ) ) );

                    modelAm.AM296 = modelAm.AM296 + ( string.IsNullOrEmpty( de.Rows[0]["AM296"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM296"].ToString( ) ) );
                    modelAm.AM298 = modelAm.AM298 + ( string.IsNullOrEmpty( de.Rows[0]["AM298"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM298"].ToString( ) ) );
                    modelAm.AM300 = modelAm.AM300 + ( string.IsNullOrEmpty( de.Rows[0]["AM300"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM300"].ToString( ) ) );
                    modelAm.AM301 = modelAm.AM301 + ( string.IsNullOrEmpty( de.Rows[0]["AM301"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM301"].ToString( ) ) );
                    modelAm.AM304 = modelAm.AM304 + ( string.IsNullOrEmpty( de.Rows[0]["AM304"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM304"].ToString( ) ) );
                    modelAm.AM306 = modelAm.AM306 + ( string.IsNullOrEmpty( de.Rows[0]["AM306"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM306"].ToString( ) ) );
                    modelAm.AM307 = modelAm.AM307 + ( string.IsNullOrEmpty( de.Rows[0]["AM307"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM307"].ToString( ) ) );
                    modelAm.AM311 = modelAm.AM311 + ( string.IsNullOrEmpty( de.Rows[0]["AM311"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM311"].ToString( ) ) );
                    modelAm.AM313 = modelAm.AM313 + ( string.IsNullOrEmpty( de.Rows[0]["AM313"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM313"].ToString( ) ) );
                    modelAm.AM315 = modelAm.AM315 + ( string.IsNullOrEmpty( de.Rows[0]["AM315"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM315"].ToString( ) ) );
                    modelAm.AM318 = modelAm.AM318 + ( string.IsNullOrEmpty( de.Rows[0]["AM318"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM318"].ToString( ) ) );
                    modelAm.AM320 = modelAm.AM320 + ( string.IsNullOrEmpty( de.Rows[0]["AM320"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM320"].ToString( ) ) );
                    modelAm.AM321 = modelAm.AM321 + ( string.IsNullOrEmpty( de.Rows[0]["AM321"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM321"].ToString( ) ) );
                    modelAm.AM324 = modelAm.AM324 + ( string.IsNullOrEmpty( de.Rows[0]["AM324"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM324"].ToString( ) ) );
                    modelAm.AM326 = modelAm.AM326 + ( string.IsNullOrEmpty( de.Rows[0]["AM326"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM326"].ToString( ) ) );
                    modelAm.AM328 = modelAm.AM328 + ( string.IsNullOrEmpty( de.Rows[0]["AM328"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM328"].ToString( ) ) );
                }
                
            }
            else
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "INSERT INTO R_PQAMB (AMB001,AMB296,AMB298,AMB300,AMB301,AMB304,AMB306,AMB307,AMB311,AMB313,AMB315,AMB318,AMB320,AMB321,AMB324,AMB326,AMB328) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}')" ,oddNum ,modelAm.AM296 ,modelAm.AM298 ,modelAm.AM300 ,modelAm.AM301 ,modelAm.AM304 ,modelAm.AM306 ,modelAm.AM307 ,modelAm.AM311 ,modelAm.AM313 ,modelAm.AM315 ,modelAm.AM318 ,modelAm.AM320 ,modelAm.AM321 ,modelAm.AM324 ,modelAm.AM326 ,modelAm.AM328 );
                SQLString.Add( strSql.ToString( ) );
                if ( de != null && de.Rows.Count > 0 )
                {
                    modelAm.AM296 = modelAm.AM296 + ( string.IsNullOrEmpty( de.Rows[0]["AM296"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM296"].ToString( ) ) );
                    modelAm.AM298 = modelAm.AM298 + ( string.IsNullOrEmpty( de.Rows[0]["AM298"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM298"].ToString( ) ) );
                    modelAm.AM300 = modelAm.AM300 + ( string.IsNullOrEmpty( de.Rows[0]["AM300"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM300"].ToString( ) ) );
                    modelAm.AM301 = modelAm.AM301 + ( string.IsNullOrEmpty( de.Rows[0]["AM301"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM301"].ToString( ) ) );
                    modelAm.AM304 = modelAm.AM304 + ( string.IsNullOrEmpty( de.Rows[0]["AM304"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM304"].ToString( ) ) );
                    modelAm.AM306 = modelAm.AM306 + ( string.IsNullOrEmpty( de.Rows[0]["AM306"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM306"].ToString( ) ) );
                    modelAm.AM307 = modelAm.AM307 + ( string.IsNullOrEmpty( de.Rows[0]["AM307"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM307"].ToString( ) ) );
                    modelAm.AM311 = modelAm.AM311 + ( string.IsNullOrEmpty( de.Rows[0]["AM311"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM311"].ToString( ) ) );
                    modelAm.AM313 = modelAm.AM313 + ( string.IsNullOrEmpty( de.Rows[0]["AM313"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM313"].ToString( ) ) );
                    modelAm.AM315 = modelAm.AM315 + ( string.IsNullOrEmpty( de.Rows[0]["AM315"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM315"].ToString( ) ) );
                    modelAm.AM318 = modelAm.AM318 + ( string.IsNullOrEmpty( de.Rows[0]["AM318"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM318"].ToString( ) ) );
                    modelAm.AM320 = modelAm.AM320 + ( string.IsNullOrEmpty( de.Rows[0]["AM320"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM320"].ToString( ) ) );
                    modelAm.AM321 = modelAm.AM321 + ( string.IsNullOrEmpty( de.Rows[0]["AM321"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM321"].ToString( ) ) );
                    modelAm.AM324 = modelAm.AM324 + ( string.IsNullOrEmpty( de.Rows[0]["AM324"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM324"].ToString( ) ) );
                    modelAm.AM326 = modelAm.AM326 + ( string.IsNullOrEmpty( de.Rows[0]["AM326"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM326"].ToString( ) ) );
                    modelAm.AM328 = modelAm.AM328 + ( string.IsNullOrEmpty( de.Rows[0]["AM328"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM328"].ToString( ) ) );
                }
               
            }
        }

        /// <summary>
        /// 是否存在库存
        /// </summary>
        /// <param name="num"></param>
        /// <param name="name"></param>
        /// <param name="spe"></param>
        /// <returns></returns>
        public decimal getSurNum ( string num ,string name ,string spe )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT SUM(AC) AC FROM (SELECT AC10+ISNULL(AC27,0)-SUM(ISNULL(AD12,0)+ISNULL(AD21,0)) AC FROM R_PQAC A LEFT JOIN R_PQAD B ON A.AC18=B.AD01 AND A.AC04=B.AD06 AND A.AC05=B.AD07 WHERE AC02='{0}' AND AC04='{1}' AND AC05='{2}' GROUP BY AC10,AC16,ISNULL(AC27,0)) A" ,num ,name ,spe );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
                return string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "AC" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ 0 ] [ "AC" ] . ToString ( ) );
            else
                return 0;
        }

    }
}

using StudentMgr;
using System;
using System . Collections;
using System . Collections . Generic;
using System . Data;
using System . Data . SqlClient;
using System . Linq;
using System . Text;
using System . Threading . Tasks;

namespace MulaolaoBll.Dao
{
    public class SiReYiYincontractDao
    {
        /// <summary>
        /// 获取数据列表   单个字段
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string field )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT " );
            strSql.Append( field );
            strSql.Append( " FROM R_PQAH" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTable (  )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT CASE WHEN AH114 IS NULL OR AH114='' THEN AH03 ELSE DGA003 END AH03 FROM R_PQAH A LEFT JOIN TPADGA B ON A.AH114=B.DGA001" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetSiReYiYinCount ( string strWhere )
        {
            //Task task = new Task ( editAH118 );
            //task . Start ( );

            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQAH" );
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
        
        void editAH118 ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "WITH CET AS (SELECT AH01,AH97,SUM(AH16*AH101*AH13*AH14)-ISNULL(AK011,0) U2 FROM R_PQAH A LEFT JOIN (SELECT AK002,AK003,SUM(ISNULL(AK011,0)) AK011 FROM R_PQAK GROUP BY AK002,AK003) B ON A.AH01=B.AK002 AND A.AH97=B.AK003 GROUP BY AH01,AH97,ISNULL(AK011,0))  UPDATE R_PQAH SET AH118=CASE WHEN U2<=10 AND U2>=-10 THEN '已结' ELSE '未结' END FROM CET B WHERE R_PQAH.AH97=B.AH97 AND R_PQAH.AH01=B.AH01 " );

            SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetSiReYiYinCountOne ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQAH TT,R_REVIEWS B WHERE TT.AH97=B.RES06 AND RES05='执行' AND NOT EXISTS( SELECT 1 FROM R_PQAL C ,R_PQAK D WHERE TT.idx = C.AL003 AND TT.AH97 = C.AL002 AND C.AL001 = D.idx )" );
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
            strSql.Append( "SELECT AH97,AH01,AH98,AH99,AH100,CASE WHEN AH114 IS NULL OR AH114='' THEN AH03 ELSE (SELECT DGA003 FROM TPADGA WHERE DGA001=AH114) END AH03,AH10,AH11,AH12,AH18,AH101,AH13,AH16,AH15,AH14,AH111,(SELECT RES05 FROM R_REVIEWS WHERE RES04=(SELECT MAX(RES04) FROM R_REVIEWS WHERE AH97=RES06)) RES05,AH05,CASE WHEN AH101=0 THEN 0 ELSE CONVERT(FLOAT,(AH16*AH101*AH13*AH14-AH17)/AH101) END AH,AH118 FROM (" );
            strSql.Append( " SELECT ROW_NUMBER() OVER(" );
            if ( !string.IsNullOrEmpty( orderby ) )
            {
                strSql.Append( "ORDER BY T." + orderby );
            }
            else
            {
                strSql.Append( "ORDER BY T.idx DESC" );
            }
            strSql.Append( ") AS Row,T.* FROM R_PQAH T" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " WHERE " + strWhere );
            }
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
            strSql.Append( "SELECT TT.idx,AH97,AH01,AH98,AH99,AH100,CASE WHEN AH114 IS NULL OR AH114='' THEN AH03 ELSE (SELECT DGA003 FROM TPADGA WHERE DGA001=AH114) END AH03,AH10,AH11,AH12,AH18,AH101,AH13,AH15,AH16,AH14,AH111,RES05,AH05,CASE WHEN AH101=0 THEN 0 ELSE CONVERT(FLOAT,(AH16*AH101*AH13*AH14-AH17)/AH101) END AH,AH118 FROM (" );
            strSql.Append( " SELECT ROW_NUMBER() OVER(" );
            strSql.Append( "ORDER BY T.AH97" );
            strSql.Append( ") AS Row,T.* FROM R_PQAH T" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " WHERE " + strWhere );
            }
            strSql.Append( " ) TT,R_REVIEWS B WHERE TT.AH97=B.RES06 AND RES05='执行' AND NOT EXISTS( SELECT 1 FROM R_PQAL C ,R_PQAK D WHERE TT.idx = C.AL003 AND TT.AH97 = C.AL002 AND C.AL001 = D.idx AND (AK009-AK010-AK011-AK015)<=100)" );//  AND AK009=AK011
            strSql .AppendFormat( " AND TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取联系人
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableCont ( )
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
        /// 是否存在记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsAdd ( MulaolaoLibrary.SiReYiYinContractLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQAH" );
            strSql.Append( " WHERE AH01=@AH01 AND AH10=@AH10 AND AH11=@AH11 AND AH12=@AH12 AND AH18=@AH18" );
            SqlParameter[] parameter = {
                new SqlParameter("@AH01",SqlDbType.NVarChar),
                new SqlParameter("@AH10",SqlDbType.NVarChar),
                new SqlParameter("@AH11",SqlDbType.NVarChar),
                new SqlParameter("@AH12",SqlDbType.NVarChar),
                new SqlParameter("@AH18",SqlDbType.NVarChar)
            };

            parameter[0].Value = model.AH01;
            parameter[1].Value = model.AH10;
            parameter[2].Value = model.AH11;
            parameter[3].Value = model.AH12;
            parameter[4].Value = model.AH18;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );

        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add ( MulaolaoLibrary.SiReYiYinContractLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAH (" );
            strSql.Append( "AH01,AH97,AH10,AH11,AH12,AH13,AH14,AH15,AH16,AH17,AH18,AH19,AH21,AH22,AH23,AH101,AH114)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}')" , model.AH01 ,model.AH97 ,model.AH10 ,model.AH11 ,model.AH12 ,model.AH13 ,model.AH14 ,model.AH15 ,model.AH16 ,model.AH17 ,model.AH18 ,model.AH19 ,model.AH21 ,model.AH22 ,model.AH23 ,model.AH101 , model . AH114 );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.AH97 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary . SiReYiYinContractLibrary model , string tableNum , string tableName , string logins , DateTime dtOne , string stateOf , string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQAH SET " );
            strSql . AppendFormat ( "AH10='{0}'," , model . AH10 );
            strSql . AppendFormat ( "AH11='{0}'," , model . AH11 );
            strSql . AppendFormat ( "AH12='{0}'," , model . AH12 );
            strSql . AppendFormat ( "AH13='{0}'," , model . AH13 );
            strSql . AppendFormat ( "AH14='{0}'," , model . AH14 );
            strSql . AppendFormat ( "AH15='{0}'," , model . AH15 );
            strSql . AppendFormat ( "AH16='{0}'," , model . AH16 );
            strSql . AppendFormat ( "AH17='{0}'," , model . AH17 );
            strSql . AppendFormat ( "AH18='{0}'," , model . AH18 );
            strSql . AppendFormat ( "AH19='{0}'," , model . AH19 );
            strSql . AppendFormat ( "AH21='{0}'," , model . AH21 );
            strSql . AppendFormat ( "AH22='{0}'," , model . AH22 );
            strSql . AppendFormat ( "AH23='{0}'," , model . AH23 );
            strSql . AppendFormat ( "AH101='{0}'," , model . AH101 );
            strSql . AppendFormat ( "AH114='{0}'," ,model . AH114 );
            strSql . AppendFormat ( "AH01='{0}' " ,model . AH01 );
            strSql . AppendFormat ( " WHERE AH97='{1}' AND idx='{0}'" , model . idx , model . AH97 );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( tableNum , tableName , logins , dtOne , model . AH97 , strSql . ToString ( ) . Replace ( "'" , "''" ) , stateOf , stateOfOdd ) );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 批量编辑数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateBatch ( MulaolaoLibrary.SiReYiYinContractLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAH SET " );
            strSql.AppendFormat( "AH101='{0}'",model.AH101 );
            strSql.AppendFormat( " WHERE AH97='{0}'" ,model.AH97 );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.AH97 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd ,string oddNum)
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQAH" );
            strSql . AppendFormat ( " WHERE AH97='{1}' AND idx={0}" , idx , oddNum );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableTable (string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,AH10,AH11,AH12,AH13,AH14,AH15,AH16,AH17,AH18,AH19,AH20,AH21,AH22,AH23,AH101 FROM R_PQAH" );
            strSql.Append( " WHERE " + strWhere );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 获取数据列表  打印表1
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintOne ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AH10,AH11,AH12,AH13,AH14,AH15,AH16,AH17,AH18,AH19,AH21,CONVERT(VARCHAR(20),AH22,111) AH22,CONVERT(VARCHAR(20),AH23,111) AH23,AH101,CONVERT(DECIMAL(10,2),AH16*AH13*AH14-AH17) U0,CONVERT(DECIMAL(10,2),AH101*AH13*AH14) U1,AH16*AH101*AH13*AH14-AH17 U2 FROM R_PQAH" );
            strSql.Append( " WHERE AH97=@AH97" );
            SqlParameter[] parameter = {
                new SqlParameter("@AH97",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;


            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表  打印表2
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintTwo ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT (SELECT DBA002 FROM TPADBA WHERE AH02=DBA001) DBA002,(SELECT DBA028 FROM TPADBA WHERE AH02=DBA001) DBA028,CASE WHEN AH114 IS NULL OR AH114='' THEN AH03 ELSE (SELECT DGA003 FROM TPADGA WHERE DGA001=AH114) END AH03,CASE WHEN AH114 IS NULL OR AH114='' THEN AH106 ELSE (SELECT DGA017 FROM TPADGA WHERE DGA001=AH114) END AH106,CASE WHEN AH114 IS NULL OR AH114='' THEN AH107 ELSE (SELECT DGA008 FROM TPADGA WHERE DGA001=AH114) END AH107,CASE WHEN AH114 IS NULL OR AH114='' THEN AH108 ELSE (SELECT DGA009 FROM TPADGA WHERE DGA001=AH114) END AH108,CASE WHEN AH114 IS NULL OR AH114='' THEN AH109 ELSE (SELECT DGA011 FROM TPADGA WHERE DGA001=AH114) END AH109,CONVERT(VARCHAR(20),AH04,111) AH04,AH05,CONVERT(VARCHAR(20),AH06,111) AH06,AH07,CONVERT(VARCHAR(20),AH08,111) AH08,AH09,AH01,AH98,AH99,AH100,AH24,AH25,AH26,AH27,AH28,AH29,AH30,CONVERT(VARCHAR(20),AH31,111) AH31,AH32,AH33,AH34,AH35,AH36,AH37,AH38,AH39,AH40,AH41,AH42,AH43,AH44,AH45,CONVERT(VARCHAR(20),AH46,111) AH46,AH47,CONVERT(VARCHAR(20),AH48,111) AH48,AH49,AH50,AH51,AH52,AH53,AH54,AH55,AH56,AH57,AH58,AH59,AH60,AH61,AH62,AH63,AH64,AH65,AH66,AH67,AH68,AH69,AH70,CONVERT(VARCHAR(20),AH71,111) AH71,AH72,AH73,AH74,CONVERT(VARCHAR(20),AH75,111) AH75,AH76,AH77,AH78,AH79,AH80,AH81,AH82,AH83,AH84,AH85,AH86,AH87,AH88,CONVERT(VARCHAR(20),AH89,111) AH89,AH90,CONVERT(VARCHAR(20),AH91,111) AH91,AH92,CONVERT(VARCHAR(20),AH93,111) AH93,CONVERT(VARCHAR(20),AH94,111) AH94,CASE WHEN AH32='F' AND AH33='F' AND AH34='F' AND AH35='F' THEN 'F' WHEN AH32='T' OR AH33='T' OR AH34='T' OR AH35='T' THEN 'T' END U0,AH112,AH97,ISNULL(AH111,'F') AH111 FROM R_PQAH" );
            strSql.Append( "  WHERE AH97=@AH97" );
            SqlParameter[] parameter = {
                new SqlParameter("@AH97",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }


        /// <summary>
        /// 获取数据列表  查询流水信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableNum ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT PQF01,PQF02,PQF03,PQF04,PQF06,PQF07,PQF08 FROM R_PQF A ,R_REVIEWS B WHERE A.PQF01=B.RES06 AND RES01='R_001' AND RES05='执行' ORDER BY PQF01 DESC" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 是否执行
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="formText"></param>
        /// <returns></returns>
        public bool ExistsReview ( string oddNum ,string formText )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_REVIEWS A,R_MLLCXMC B" );
            strSql.Append( " WHERE A.RES01=B.CX01 AND RES05='执行' AND RES06=@RES06 AND CX02=@CX02" );
            SqlParameter[] parameter = {
                new SqlParameter("@RES06",SqlDbType.NVarChar),
                new SqlParameter("@CX02",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;
            parameter[1].Value = formText;

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
            strSql.AppendFormat( "DELETE FROM R_PQAH WHERE AH97='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            StringBuilder strSq = new StringBuilder( );
            strSq.Append( "DELETE FROM R_REVIEWS" );
            strSq.AppendFormat( " WHERE RES01='{0}' AND RES06='{1}'" ,tableNum ,oddNum );
            SQLString.Add( strSq.ToString( ) );
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
            strSql.Append( "DELETE FROM R_REVIEWS" );
            strSql.Append( " WHERE RES01=@RES01 AND RES06=@RES06" );
            SqlParameter[] parameter = {
                new SqlParameter("@RES01",SqlDbType.NVarChar),
                new SqlParameter("@RES06",SqlDbType.NVarChar)
            };

            parameter[0].Value = tableNum;
            parameter[1].Value = oddNum;

            int rows = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取数据列表   是否存在
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableAll ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQAH" );
            strSql.Append( " WHERE AH97=@AH97" );
            SqlParameter[] parameter = {
                new SqlParameter("@AH97",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }


        /// <summary>
        /// 更改一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdataWeiHu ( MulaolaoLibrary.SiReYiYinContractLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAH SET " );
            strSql.AppendFormat( "AH01='{0}'," ,model.AH01);
            strSql.AppendFormat( "AH02='{0}'," ,model.AH02 );
            strSql.AppendFormat( "AH03='{0}'," ,model.AH03 );
            strSql.AppendFormat( "AH04='{0}'," ,model.AH04 );
            strSql.AppendFormat( "AH05='{0}'," ,model.AH05 );
            strSql.AppendFormat( "AH06='{0}'," ,model.AH06 );
            strSql.AppendFormat( "AH07='{0}'," ,model.AH07 );
            strSql.AppendFormat( "AH08='{0}'," ,model.AH08 );
            strSql.AppendFormat( "AH09='{0}'," ,model.AH09 );
            strSql.AppendFormat( "AH24='{0}'," ,model.AH24 );
            strSql.AppendFormat( "AH25='{0}'," ,model.AH25 );
            strSql.AppendFormat( "AH26='{0}'," ,model.AH26 );
            strSql.AppendFormat( "AH27='{0}'," ,model.AH27 );
            strSql.AppendFormat( "AH28='{0}'," ,model.AH28 );
            strSql.AppendFormat( "AH29='{0}'," ,model.AH29 );
            strSql.AppendFormat( "AH30='{0}'," ,model.AH30 );
            strSql.AppendFormat( "AH31='{0}'," ,model.AH31 );
            strSql.AppendFormat( "AH32='{0}'," ,model.AH32 );
            strSql.AppendFormat( "AH33='{0}'," ,model.AH33 );
            strSql.AppendFormat( "AH34='{0}'," ,model.AH34 );
            strSql.AppendFormat( "AH35='{0}'," ,model.AH35 );
            strSql.AppendFormat( "AH36='{0}'," ,model.AH36 );
            strSql.AppendFormat( "AH37='{0}'," ,model.AH37 );
            strSql.AppendFormat( "AH38='{0}'," ,model.AH38 );
            strSql.AppendFormat( "AH39='{0}'," ,model.AH39 );
            strSql.AppendFormat( "AH40='{0}'," ,model.AH40 );
            strSql.AppendFormat( "AH41='{0}'," ,model.AH41 );
            strSql.AppendFormat( "AH42='{0}'," ,model.AH42 );
            strSql.AppendFormat( "AH43='{0}'," ,model.AH43 );
            strSql.AppendFormat( "AH44='{0}'," ,model.AH44 );
            strSql.AppendFormat( "AH45='{0}'," ,model.AH45 );
            strSql.AppendFormat( "AH46='{0}'," ,model.AH46 );
            strSql.AppendFormat( "AH47='{0}'," ,model.AH47 );
            strSql.AppendFormat( "AH48='{0}'," ,model.AH48 );
            strSql.AppendFormat( "AH49='{0}'," ,model.AH49 );
            strSql.AppendFormat( "AH50='{0}'," ,model.AH50 );
            strSql.AppendFormat( "AH51='{0}'," ,model.AH51 );
            strSql.AppendFormat( "AH52='{0}'," ,model.AH52 );
            strSql.AppendFormat( "AH53='{0}'," ,model.AH53 );
            strSql.AppendFormat( "AH54='{0}'," ,model.AH54 );
            strSql.AppendFormat( "AH55='{0}'," ,model.AH55 );
            strSql.AppendFormat( "AH56='{0}'," ,model.AH56 );
            strSql.AppendFormat( "AH57='{0}'," ,model.AH57 );
            strSql.AppendFormat( "AH58='{0}'," ,model.AH58 );
            strSql.AppendFormat( "AH59='{0}'," ,model.AH59 );
            strSql.AppendFormat( "AH60='{0}'," ,model.AH60 );
            strSql.AppendFormat( "AH61='{0}'," ,model.AH61 );
            strSql.AppendFormat( "AH62='{0}'," ,model.AH62 );
            strSql.AppendFormat( "AH63='{0}'," ,model.AH63 );
            strSql.AppendFormat( "AH64='{0}'," ,model.AH64 );
            strSql.AppendFormat( "AH65='{0}'," ,model.AH65 );
            strSql.AppendFormat( "AH66='{0}'," ,model.AH66 );
            strSql.AppendFormat( "AH67='{0}'," ,model.AH67 );
            strSql.AppendFormat( "AH68='{0}'," ,model.AH68 );
            strSql.AppendFormat( "AH69='{0}'," ,model.AH69 );
            strSql.AppendFormat( "AH70='{0}'," ,model.AH70 );
            strSql.AppendFormat( "AH71='{0}'," ,model.AH71 );
            strSql.AppendFormat( "AH72='{0}'," ,model.AH72 );
            strSql.AppendFormat( "AH73='{0}'," ,model.AH73 );
            strSql.AppendFormat( "AH74='{0}'," ,model.AH74 );
            strSql.AppendFormat( "AH75='{0}'," ,model.AH75 );
            strSql.AppendFormat( "AH76='{0}'," ,model.AH76 );
            strSql.AppendFormat( "AH77='{0}'," ,model.AH77 );
            strSql.AppendFormat( "AH78='{0}'," ,model.AH78 );
            strSql.AppendFormat( "AH79='{0}'," ,model.AH79 );
            strSql.AppendFormat( "AH80='{0}'," ,model.AH80 );
            strSql.AppendFormat( "AH81='{0}'," ,model.AH81 );
            strSql.AppendFormat( "AH82='{0}'," ,model.AH82 );
            strSql.AppendFormat( "AH83='{0}'," ,model.AH83 );
            strSql.AppendFormat( "AH84='{0}'," ,model.AH84 );
            strSql.AppendFormat( "AH85='{0}'," ,model.AH85 );
            strSql.AppendFormat( "AH86='{0}'," ,model.AH86 );
            strSql.AppendFormat( "AH87='{0}'," ,model.AH87 );
            strSql.AppendFormat( "AH88='{0}'," ,model.AH88 );
            strSql.AppendFormat( "AH89='{0}'," ,model.AH89 );
            strSql.AppendFormat( "AH90='{0}'," ,model.AH90 );
            strSql.AppendFormat( "AH91='{0}'," ,model.AH91 );
            strSql.AppendFormat( "AH92='{0}'," ,model.AH92 );
            strSql.AppendFormat( "AH93='{0}'," ,model.AH93 );
            strSql.AppendFormat( "AH94='{0}'," ,model.AH94 );
            strSql.AppendFormat( "AH95='{0}'," ,model.AH95 );
            strSql.AppendFormat( "AH96='{0}'," ,model.AH96 );
            strSql.AppendFormat( "AH98='{0}'," ,model.AH98 );
            strSql.AppendFormat( "AH99='{0}'," ,model.AH99 );
            strSql.AppendFormat( "AH100='{0}'," ,model.AH100 );
            strSql.AppendFormat( "AH106='{0}'," ,model.AH106 );
            strSql.AppendFormat( "AH107='{0}'," ,model.AH107 );
            strSql.AppendFormat( "AH108='{0}'," ,model.AH108 );
            strSql.AppendFormat( "AH109='{0}'," ,model.AH109 );
            strSql.AppendFormat( "AH110='{0}'," ,model.AH110 );
            strSql.AppendFormat( "AH111='{0}'," ,model.AH111 );
            strSql.AppendFormat( "AH112='{0}'," ,model.AH112 );
            strSql.AppendFormat( "AH114='{0}'" ,model.AH114 );
            strSql.AppendFormat( " WHERE AH97='{0}'" ,model.AH97 );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.AH97 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );
            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取数据列表  是否存在
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableAnOther ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQAH" );
            strSql.Append( " WHERE AH97!=@AH97" );
            SqlParameter[] parameter = {
                new SqlParameter("@AH97",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }


        /// <summary>
        /// 复制数据是否成功
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateAdd ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAH (" );
            strSql.Append( "AH01,AH98,AH99,AH100,AH02,AH03,AH106,AH107,AH108,AH109,AH10,AH11,AH12,AH13,AH14,AH15,AH16,AH17,AH18,AH19,AH21,AH22,AH24,AH25,AH26,AH27,AH28,AH29,AH30,AH32,AH33,AH34,AH35,AH36,AH37,AH38,AH39,AH40,AH41,AH42,AH43,AH44,AH49,AH50,AH51,AH52,AH53,AH54,AH55,AH56,AH57,AH58,AH59,AH60,AH61,AH62,AH63,AH64,AH65,AH66,AH67,AH68,AH69,AH70,AH72,AH73,AH74,AH76,AH77,AH78,AH79,AH80,AH81,AH82,AH83,AH84,AH85,AH95,AH101)" );
            strSql.Append( "SELECT AH01,AH98,AH99,AH100,AH02,AH03,AH106,AH107,AH108,AH109,AH10,AH11,AH12,AH13,AH14,AH15,AH16,AH17,AH18,AH19,AH21,AH22,AH24,AH25,AH26,AH27,AH28,AH29,AH30,AH32,AH33,AH34,AH35,AH36,AH37,AH38,AH39,AH40,AH41,AH42,AH43,AH44,AH49,AH50,AH51,AH52,AH53,AH54,AH55,AH56,AH57,AH58,AH59,AH60,AH61,AH62,AH63,AH64,AH65,AH66,AH67,AH68,AH69,AH70,AH72,AH73,AH74,AH76,AH77,AH78,AH79,AH80,AH81,AH82,AH83,AH84,AH85,AH95,AH101 FROM R_PQAH" );
            strSql.AppendFormat( " WHERE AH97='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 更改复制数据单号
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateAdds ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAH SET" );
            strSql.AppendFormat( " AH97='{0}'," ,oddNum );
            strSql.Append( "AH110='复制'" );
            strSql.Append( " WHERE AH97 IS NULL" );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 删除复制数据
        /// </summary>
        /// <returns></returns>
        public bool DeleteAdd ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQAH WHERE AH97 IS NULL" );

            int rows = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public MulaolaoLibrary.SiReYiYinContractLibrary GetModel ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQAH" );
            strSql.Append( " WHERE AH97=@AH97" );
            SqlParameter[] parameter = {
                new SqlParameter("@AH97",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            DataTable dt = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( dt.Rows.Count >= 1 )
                return GetDataRow( dt.Rows[0] );
            else
                return null;
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.SiReYiYinContractLibrary GetDataRow ( DataRow row )
        {
            MulaolaoLibrary.SiReYiYinContractLibrary model = new MulaolaoLibrary.SiReYiYinContractLibrary( );

            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    model.idx = int.Parse( row["idx"].ToString( ) );
                else
                    model.idx = 0;
                if ( row["AH01"] != null && row["AH01"].ToString( ) != "" )
                    model.AH01 = row["AH01"].ToString( );
                else
                    model.AH01 = "";
                if ( row["AH02"] != null && row["AH02"].ToString( ) != "" )
                    model.AH02 = row["AH02"].ToString( );
                else
                    model.AH02 = "";
                if ( row["AH03"] != null && row["AH03"].ToString( ) != "" )
                    model.AH03 = row["AH03"].ToString( );
                else
                    model.AH03 = "";
                if ( row["AH04"] != null && row["AH04"].ToString( ) != "" )
                    model.AH04 = DateTime.Parse( row["AH04"].ToString( ) );
                else
                    model.AH04 = MulaolaoBll . Drity . GetDt ( );
                if ( row["AH05"] != null && row["AH05"].ToString( ) != "" )
                    model.AH05 = row["AH05"].ToString( );
                else
                    model.AH05 = "";
                if ( row["AH06"] != null && row["AH06"].ToString( ) != "" )
                    model.AH06 = DateTime.Parse( row["AH06"].ToString( ) );
                else
                    model.AH06 = MulaolaoBll . Drity . GetDt ( );
                if ( row["AH07"] != null && row["AH07"].ToString( ) != "" )
                    model.AH07 = row["AH07"].ToString( );
                else
                    model.AH07 = "";
                if ( row["AH08"] != null && row["AH08"].ToString( ) != "" )
                    model.AH08 = DateTime.Parse( row["AH08"].ToString( ) );
                else
                    model.AH08 = MulaolaoBll . Drity . GetDt ( );
                if ( row["AH09"] != null && row["AH09"].ToString( ) != "" )
                    model.AH09 = row["AH09"].ToString( );
                else
                    model.AH09 = "";
                if ( row["AH24"] != null && row["AH24"].ToString( ) != "" )
                    model.AH24 = row["AH24"].ToString( );
                else
                    model.AH24 = "";
                if ( row["AH25"] != null && row["AH25"].ToString( ) != "" )
                    model.AH25 = row["AH25"].ToString( );
                else
                    model.AH25 = "";
                if ( row["AH26"] != null && row["AH26"].ToString( ) != "" )
                    model.AH26 = row["AH26"].ToString( );
                else
                    model.AH26 = "";
                if ( row["AH27"] != null && row["AH27"].ToString( ) != "" )
                    model.AH27 = row["AH27"].ToString( );
                else
                    model.AH27 = "";
                if ( row["AH28"] != null && row["AH28"].ToString( ) != "" )
                    model.AH28 = row["AH28"].ToString( );
                else
                    model.AH28 = "";
                if ( row["AH29"] != null && row["AH29"].ToString( ) != "" )
                    model.AH29 = row["AH29"].ToString( );
                else
                    model.AH29 = "";
                if ( row["AH30"] != null && row["AH30"].ToString( ) != "" )
                    model.AH30 = row["AH30"].ToString( );
                else
                    model.AH30 = "";
                if ( row["AH31"] != null && row["AH31"].ToString( ) != "" )
                    model.AH31 = DateTime.Parse( row["AH31"].ToString( ) );
                else
                    model.AH31 = MulaolaoBll . Drity . GetDt ( );
                if ( row["AH32"] != null && row["AH32"].ToString( ) != "" )
                    model.AH32 = row["AH32"].ToString( );
                else
                    model.AH32 = "";
                if ( row["AH33"] != null && row["AH33"].ToString( ) != "" )
                    model.AH33 = row["AH33"].ToString( );
                else
                    model.AH33 = "";
                if ( row["AH34"] != null && row["AH34"].ToString( ) != "" )
                    model.AH34 = row["AH34"].ToString( );
                else
                    model.AH34 = "";
                if ( row["AH35"] != null && row["AH35"].ToString( ) != "" )
                    model.AH35 = row["AH35"].ToString( );
                else
                    model.AH35 = "";
                if ( row["AH36"] != null && row["AH36"].ToString( ) != "" )
                    model.AH36 = row["AH36"].ToString( );
                else
                    model.AH36 = "";
                if ( row["AH37"] != null && row["AH37"].ToString( ) != "" )
                    model.AH37 = row["AH37"].ToString( );
                else
                    model.AH37 = "";
                if ( row["AH38"] != null && row["AH38"].ToString( ) != "" )
                    model.AH38 = row["AH38"].ToString( );
                else
                    model.AH38 = "";
                if ( row["AH39"] != null && row["AH39"].ToString( ) != "" )
                    model.AH39 = row["AH39"].ToString( );
                else
                    model.AH39 = "";
                if ( row["AH40"] != null && row["AH40"].ToString( ) != "" )
                    model.AH40 = row["AH40"].ToString( );
                else
                    model.AH40 = "";
                if ( row["AH41"] != null && row["AH41"].ToString( ) != "" )
                    model.AH41 = row["AH41"].ToString( );
                else
                    model.AH41 = "";
                if ( row["AH42"] != null && row["AH42"].ToString( ) != "" )
                    model.AH42 = row["AH42"].ToString( );
                else
                    model.AH42 = "";
                if ( row["AH43"] != null && row["AH43"].ToString( ) != "" )
                    model.AH43 = row["AH43"].ToString( );
                else
                    model.AH43 = "";
                if ( row["AH44"] != null && row["AH44"].ToString( ) != "" )
                    model.AH44 = row["AH44"].ToString( );
                else
                    model.AH44 = "";
                if ( row["AH45"] != null && row["AH45"].ToString( ) != "" )
                    model.AH45 = row["AH45"].ToString( );
                else
                    model.AH45 = "";
                if ( row["AH46"] != null && row["AH46"].ToString( ) != "" )
                    model.AH46 = DateTime.Parse( row["AH46"].ToString( ) );
                else
                    model.AH46 = MulaolaoBll . Drity . GetDt ( );
                if ( row["AH47"] != null && row["AH47"].ToString( ) != "" )
                    model.AH47 = row["AH47"].ToString( );
                else
                    model.AH47 = "";
                if ( row["AH48"] != null && row["AH48"].ToString( ) != "" )
                    model.AH48 = DateTime.Parse( row["AH48"].ToString( ) );
                else
                    model.AH48 = MulaolaoBll . Drity . GetDt ( );
                if ( row["AH49"] != null && row["AH49"].ToString( ) != "" )
                    model.AH49 = row["AH49"].ToString( );
                else
                    model.AH49 = "";
                if ( row["AH50"] != null && row["AH50"].ToString( ) != "" )
                    model.AH50 = row["AH50"].ToString( );
                else
                    model.AH50 = "";
                if ( row["AH51"] != null && row["AH51"].ToString( ) != "" )
                    model.AH51 = row["AH51"].ToString( );
                else
                    model.AH51 = "";
                if ( row["AH52"] != null && row["AH52"].ToString( ) != "" )
                    model.AH52 = row["AH52"].ToString( );
                else
                    model.AH52 = "";
                if ( row["AH53"] != null && row["AH53"].ToString( ) != "" )
                    model.AH53 = row["AH53"].ToString( );
                else
                    model.AH53 = "";
                if ( row["AH54"] != null && row["AH54"].ToString( ) != "" )
                    model.AH54 = row["AH54"].ToString( );
                else
                    model.AH54 = "";
                if ( row["AH55"] != null && row["AH55"].ToString( ) != "" )
                    model.AH55 = row["AH55"].ToString( );
                else
                    model.AH55 = "";
                if ( row["AH56"] != null && row["AH56"].ToString( ) != "" )
                    model.AH56 = row["AH56"].ToString( );
                else
                    model.AH56 = "";
                if ( row["AH57"] != null && row["AH57"].ToString( ) != "" )
                    model.AH57 = row["AH57"].ToString( );
                else
                    model.AH57 = "";
                if ( row["AH58"] != null && row["AH58"].ToString( ) != "" )
                    model.AH58 = row["AH58"].ToString( );
                else
                    model.AH58 = "";
                if ( row["AH59"] != null && row["AH59"].ToString( ) != "" )
                    model.AH59 = row["AH59"].ToString( );
                else
                    model.AH59 = "";
                if ( row["AH60"] != null && row["AH60"].ToString( ) != "" )
                    model.AH60 = row["AH60"].ToString( );
                else
                    model.AH60 = "";
                if ( row["AH61"] != null && row["AH61"].ToString( ) != "" )
                    model.AH61 = row["AH61"].ToString( );
                else
                    model.AH61 = "";
                if ( row["AH62"] != null && row["AH62"].ToString( ) != "" )
                    model.AH62 = row["AH62"].ToString( );
                else
                    model.AH62 = "";
                if ( row["AH63"] != null && row["AH63"].ToString( ) != "" )
                    model.AH63 = row["AH63"].ToString( );
                else
                    model.AH63 = "";
                if ( row["AH64"] != null && row["AH64"].ToString( ) != "" )
                    model.AH64 = row["AH64"].ToString( );
                else
                    model.AH64 = "";
                if ( row["AH65"] != null && row["AH65"].ToString( ) != "" )
                    model.AH65 = row["AH65"].ToString( );
                else
                    model.AH65 = "";
                if ( row["AH66"] != null && row["AH66"].ToString( ) != "" )
                    model.AH66 = row["AH66"].ToString( );
                else
                    model.AH66 = "";
                if ( row["AH67"] != null && row["AH67"].ToString( ) != "" )
                    model.AH67 = row["AH67"].ToString( );
                else
                    model.AH67 = "";
                if ( row["AH68"] != null && row["AH68"].ToString( ) != "" )
                    model.AH68 = row["AH68"].ToString( );
                else
                    model.AH68 = "";
                if ( row["AH69"] != null && row["AH69"].ToString( ) != "" )
                    model.AH69 = row["AH69"].ToString( );
                else
                    model.AH69 = "";
                if ( row["AH70"] != null && row["AH70"].ToString( ) != "" )
                    model.AH70 = row["AH70"].ToString( );
                else
                    model.AH70 = "";
                if ( row["AH71"] != null && row["AH71"].ToString( ) != "" )
                    model.AH71 = DateTime.Parse( row["AH71"].ToString( ) );
                else
                    model.AH71 = MulaolaoBll . Drity . GetDt ( );
                if ( row["AH72"] != null && row["AH72"].ToString( ) != "" )
                    model.AH72 = long.Parse( row["AH72"].ToString( ) );
                else
                    model.AH72 = 0;
                if ( row["AH73"] != null && row["AH73"].ToString( ) != "" )
                    model.AH73 = row["AH73"].ToString( );
                else
                    model.AH73 = "";
                if ( row["AH74"] != null && row["AH74"].ToString( ) != "" )
                    model.AH74 = row["AH74"].ToString( );
                else
                    model.AH74 = "";
                if ( row["AH75"] != null && row["AH75"].ToString( ) != "" )
                    model.AH75 = DateTime.Parse( row["AH75"].ToString( ) );
                else
                    model.AH75 = MulaolaoBll . Drity . GetDt ( );
                if ( row["AH76"] != null && row["AH76"].ToString( ) != "" )
                    model.AH76 = row["AH76"].ToString( );
                else
                    model.AH76 = "";
                if ( row["AH77"] != null && row["AH77"].ToString( ) != "" )
                    model.AH77 = long.Parse( row["AH77"].ToString( ) );
                else
                    model.AH77 = 0;
                if ( row["AH78"] != null && row["AH78"].ToString( ) != "" )
                    model.AH78 = long.Parse( row["AH78"].ToString( ) );
                else
                    model.AH78 = 0;
                if ( row["AH79"] != null && row["AH79"].ToString( ) != "" )
                    model.AH79 = long.Parse( row["AH79"].ToString( ) );
                else
                    model.AH79 = 0;
                if ( row["AH80"] != null && row["AH80"].ToString( ) != "" )
                    model.AH80 = long.Parse( row["AH80"].ToString( ) );
                else
                    model.AH80 = 0;
                if ( row["AH81"] != null && row["AH81"].ToString( ) != "" )
                    model.AH81 = long.Parse( row["AH81"].ToString( ) );
                else
                    model.AH81 = 0;
                if ( row["AH82"] != null && row["AH82"].ToString( ) != "" )
                    model.AH82 = long.Parse( row["AH82"].ToString( ) );
                else
                    model.AH82 = 0;
                if ( row["AH83"] != null && row["AH83"].ToString( ) != "" )
                    model.AH83 = long.Parse( row["AH83"].ToString( ) );
                else
                    model.AH83 = 0;
                if ( row["AH84"] != null && row["AH84"].ToString( ) != "" )
                    model.AH84 = long.Parse( row["AH84"].ToString( ) );
                else
                    model.AH84 = 0;
                if ( row["AH85"] != null && row["AH85"].ToString( ) != "" )
                    model.AH85 = long.Parse( row["AH85"].ToString( ) );
                else
                    model.AH85 = 0;
                if ( row["AH86"] != null && row["AH86"].ToString( ) != "" )
                    model.AH86 = row["AH86"].ToString( );
                else
                    model.AH86 = "";
                if ( row["AH87"] != null && row["AH87"].ToString( ) != "" )
                    model.AH87 = row["AH87"].ToString( );
                else
                    model.AH87 = "";
                if ( row["AH88"] != null && row["AH88"].ToString( ) != "" )
                    model.AH88 = row["AH88"].ToString( );
                else
                    model.AH88 = "";
                if ( row["AH89"] != null && row["AH89"].ToString( ) != "" )
                    model.AH89 = DateTime.Parse( row["AH89"].ToString( ) );
                else
                    model.AH89 = MulaolaoBll . Drity . GetDt ( );
                if ( row["AH90"] != null && row["AH90"].ToString( ) != "" )
                    model.AH90 = row["AH90"].ToString( );
                else
                    model.AH90 = "";
                if ( row["AH91"] != null && row["AH91"].ToString( ) != "" )
                    model.AH91 = DateTime.Parse( row["AH91"].ToString( ) );
                else
                    model.AH91 = MulaolaoBll . Drity . GetDt ( );
                if ( row["AH92"] != null && row["AH92"].ToString( ) != "" )
                    model.AH92 = row["AH92"].ToString( );
                else
                    model.AH92 = "";
                if ( row["AH93"] != null && row["AH93"].ToString( ) != "" )
                    model.AH93 = DateTime.Parse( row["AH93"].ToString( ) );
                else
                    model.AH93 = MulaolaoBll . Drity . GetDt ( );
                if ( row["AH94"] != null && row["AH94"].ToString( ) != "" )
                    model.AH94 = DateTime.Parse( row["AH94"].ToString( ) );
                else
                    model.AH94 = MulaolaoBll . Drity . GetDt ( );
                if ( row["AH95"] != null && row["AH95"].ToString( ) != "" )
                    model.AH95 = row["AH95"].ToString( );
                else
                    model.AH95 = "";
                if ( row["AH96"] != null && row["AH96"].ToString( ) != "" )
                    model.AH96 = row["AH96"].ToString( );
                else
                    model.AH96 = "";
                if ( row["AH97"] != null && row["AH97"].ToString( ) != "" )
                    model.AH97 = row["AH97"].ToString( );
                else
                    model.AH97 = "";
                if ( row["AH98"] != null && row["AH98"].ToString( ) != "" )
                    model.AH98 = row["AH98"].ToString( );
                else
                    model.AH98 = "";
                if ( row["AH99"] != null && row["AH99"].ToString( ) != "" )
                    model.AH99 = row["AH99"].ToString( );
                else
                    model.AH99 = "";
                if ( row["AH100"] != null && row["AH100"].ToString( ) != "" )
                    model.AH100 = row["AH100"].ToString( );
                else
                    model.AH100 = "";
                if ( row["AH101"] != null && row["AH101"].ToString( ) != "" )
                    model.AH101 = long.Parse( row["AH101"].ToString( ) );
                else
                    model.AH101 = 0;
                if ( row["AH106"] != null && row["AH106"].ToString( ) != "" )
                    model.AH106 = row["AH106"].ToString( );
                else
                    model.AH106 = "";
                if ( row["AH107"] != null && row["AH107"].ToString( ) != "" )
                    model.AH107 = row["AH107"].ToString( );
                else
                    model.AH107 = "";
                if ( row["AH108"] != null && row["AH108"].ToString( ) != "" )
                    model.AH108 = row["AH108"].ToString( );
                else
                    model.AH108 = "";
                if ( row["AH109"] != null && row["AH109"].ToString( ) != "" )
                    model.AH109 = row["AH109"].ToString( );
                else
                    model.AH109 = "";
                if ( row["AH110"] != null && row["AH110"].ToString( ) != "" )
                    model.AH110 = row["AH110"].ToString( );
                else
                    model.AH110 = "";
                if ( row["AH111"] != null && row["AH111"].ToString( ) != "" )
                    model.AH111 = row["AH111"].ToString( );
                else
                    model.AH111 = "";
                if ( row["AH112"] != null && row["AH112"].ToString( ) != "" )
                    model.AH112 = row["AH112"].ToString( );
                else
                    model.AH112 = "";
                //if ( row["AH113"] != null && row["AH113"].ToString( ) != "" )
                //    model.AH113 = row["AH113"].ToString( );
                //else
                //    model.AH113 = "";
                if ( row["AH114"] != null && row["AH114"].ToString( ) != "" )
                    model.AH114 = row["AH114"].ToString( );
            }

            return model;
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.SiReYiYinContractLibrary GetMode ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,AH10,AH11,AH12,AH13,AH14,AH15,AH16,AH17,AH18,AH19,AH21,AH22,AH23,AH101,AH97,AH114 FROM R_PQAH" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };

            parameter[0].Value = idx;

            DataTable dt = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( dt.Rows.Count > 0 )
                return GetDataR( dt.Rows[0] );
            else
                return null;
        }


        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.SiReYiYinContractLibrary GetDataR ( DataRow row )
        {
            MulaolaoLibrary.SiReYiYinContractLibrary model = new MulaolaoLibrary.SiReYiYinContractLibrary( );

            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    model.idx = int.Parse( row["idx"].ToString( ) );
                else
                    model.idx = 0;
                if ( row["AH10"] != null && row["AH10"].ToString( ) != "" )
                    model.AH10 = row["AH10"].ToString( );
                else
                    model.AH10 = "";
                if ( row["AH11"] != null && row["AH11"].ToString( ) != "" )
                    model.AH11 = row["AH11"].ToString( );
                else
                    model.AH11 = "";
                if ( row["AH12"] != null && row["AH12"].ToString( ) != "" )
                    model.AH12 = row["AH12"].ToString( );
                else
                    model.AH12 = "";
                if ( row["AH13"] != null && row["AH13"].ToString( ) != "" )
                    model.AH13 = decimal.Parse( row["AH13"].ToString( ) );
                else
                    model.AH13 = 0;
                if ( row["AH14"] != null && row["AH14"].ToString( ) != "" )
                    model.AH14 = int.Parse( row["AH14"].ToString( ) );
                else
                    model.AH14 = 0;
                if ( row["AH15"] != null && row["AH15"].ToString( ) != "" )
                    model.AH15 = decimal.Parse( row["AH15"].ToString( ) );
                else
                    model.AH15 = 0;
                if ( row["AH16"] != null && row["AH16"].ToString( ) != "" )
                    model.AH16 = decimal.Parse( row["AH16"].ToString( ) );
                else
                    model.AH16 = 0;
                if ( row["AH17"] != null && row["AH17"].ToString( ) != "" )
                    model.AH17 = int.Parse( row["AH17"].ToString( ) );
                else
                    model.AH17 = 0;
                if ( row["AH18"] != null && row["AH18"].ToString( ) != "" )
                    model.AH18 = row["AH18"].ToString( );
                else
                    model.AH18 = "";
                if ( row["AH19"] != null && row["AH19"].ToString( ) != "" )
                    model.AH19 = row["AH19"].ToString( );
                else
                    model.AH19 = "";
                if ( row["AH21"] != null && row["AH21"].ToString( ) != "" )
                    model.AH21 = row["AH21"].ToString( );
                else
                    model.AH21 = "";
                if ( row["AH22"] != null && row["AH22"].ToString( ) != "" )
                    model.AH22 = DateTime.Parse( row["AH22"].ToString( ) );
                else
                    model.AH22 = MulaolaoBll . Drity . GetDt ( );
                if ( row["AH23"] != null && row["AH23"].ToString( ) != "" )
                    model.AH23 = DateTime.Parse( row["AH23"].ToString( ) );
                else
                    model.AH23 = MulaolaoBll . Drity . GetDt ( );
                if ( row["AH101"] != null && row["AH101"].ToString( ) != "" )
                    model.AH101 = int.Parse( row["AH101"].ToString( ) );
                else
                    model.AH101 = 0;
                if ( row["AH97"] != null && row["AH97"].ToString( ) != "" )
                    model.AH97 = row["AH97"].ToString( );
                else
                    model.AH97 = "";
                if ( row [ "AH114" ] != null && row [ "AH114" ] . ToString ( ) != "" )
                    model . AH114 = row [ "AH114" ] . ToString ( );
                else
                    model . AH114 = "";
            }

            return model;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="numOfGoods"></param>
        /// <param name="nameOfPart"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfPrice ( string numOfGoods ,string nameOfPart )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT TOP 1 AH16 FROM R_PQAH WHERE AH100=@AH100 AND AH10=@AH10 ORDER BY idx DESC" );
            SqlParameter[] parameter = {
                new SqlParameter("@AH100",SqlDbType.NVarChar),
                new SqlParameter("@AH10",SqlDbType.NVarChar)
            };
            parameter[0].Value = numOfGoods;
            parameter[1].Value = nameOfPart;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataOfSuppiler ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DGA001,DGA003,DGA008,DGA011,DGA017,DGA009,DGA012 FROM TPADGA WHERE DGA052='F'" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="supplierNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfSupplier ( string supplierNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DGA003,DGA008,DGA011,DGA017,DGA009,DGA012 FROM TPADGA" );
            strSql.AppendFormat( " WHERE DGA001='{0}'" ,supplierNum );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfRecevable ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AH01,CASE WHEN AH18 LIKE '%雕刻%' THEN '雕刻' WHEN AH18 LIKE '%绕锯%' THEN '绕锯' WHEN AH18 LIKE '%夹料%' THEN '夹料' WHEN AH18 LIKE '%砂皮%' THEN '擦砂皮' WHEN AH18 LIKE '%丝印%' THEN '丝印' WHEN AH18 LIKE '%走台印%' THEN '走台印' WHEN AH18 LIKE '%移印%' THEN '移印' WHEN AH18 LIKE '%热转印%' THEN '热转印' WHEN AH18 LIKE '%烫印%' THEN '烫印' WHEN AH18 LIKE '%喷漆%' THEN '喷漆' WHEN AH18 LIKE '%冲压%' THEN '冲压' WHEN AH18 LIKE '%/%' THEN '委外' ELSE '手工剪切、其它' END AH18,CONVERT(DECIMAL(18,2),SUM(AH16*AH101*AH13*AH14-AH17)) AH,ISNULL(AH113,'F') AH113,AH111 FROM R_PQAH A  INNER JOIN R_REVIEWS D ON A.AH97=D.RES06 AND RES05='执行'" );
            strSql.AppendFormat( " WHERE AH97='{0}'" ,oddNum );
            strSql.Append( "  AND (AH01!='' AND AH01 IS NOT NULL)" );
            strSql.Append( " GROUP BY AH18,AH01,AH113,AH111" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 写数据到241
        /// </summary>
        /// <param name="modelAm"></param>
        /// <returns></returns>
        public bool UpdateOfRecevable ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum )
        {
            ArrayList SQLString = new ArrayList( );
            ByOneBy( modelAm ,oddNum ,SQLString );
            //WriteReceivableToGeneralLedger.ByOneByChanPintZhiBao( modelAm ,oddNum ,SQLString );

            if ( modelAm.AM108 > 0 )
            {
                StringBuilder strSqlAM108 = new StringBuilder( );
                strSqlAM108.AppendFormat( "UPDATE R_PQAM SET AM108='{0}' WHERE AM002='{1}'" ,modelAm.AM108 ,modelAm.AM002 );
                SQLString.Add( strSqlAM108.ToString( ) );
            }
            if ( modelAm.AM110 > 0 )
            {
                StringBuilder strSqlAM110 = new StringBuilder( );
                strSqlAM110.AppendFormat( "UPDATE R_PQAM SET AM110='{0}' WHERE AM002='{1}'" ,modelAm.AM110 ,modelAm.AM002 );
                SQLString.Add( strSqlAM110.ToString( ) );
            }
            if ( modelAm.AM111 > 0 )
            {
                StringBuilder strSqlAM111 = new StringBuilder( );
                strSqlAM111.AppendFormat( "UPDATE R_PQAM SET AM111='{0}' WHERE AM002='{1}'" ,modelAm.AM111 ,modelAm.AM002 );
                SQLString.Add( strSqlAM111.ToString( ) );
            }
            if ( modelAm.AM115 > 0 )
            {
                StringBuilder strSqlAM115 = new StringBuilder( );
                strSqlAM115.AppendFormat( "UPDATE R_PQAM SET AM115='{0}' WHERE AM002='{1}'" ,modelAm.AM115 ,modelAm.AM002 );
                SQLString.Add( strSqlAM115.ToString( ) );
            }
            if ( modelAm.AM070 > 0 )
            {
                StringBuilder strSqlAM070 = new StringBuilder( );
                strSqlAM070.AppendFormat( "UPDATE R_PQAM SET AM070='{0}' WHERE AM002='{1}'" ,modelAm.AM070 ,modelAm.AM002 );
                SQLString.Add( strSqlAM070.ToString( ) );
            }
            if ( modelAm.AM072 > 0 )
            {
                StringBuilder strSqlAM072 = new StringBuilder( );
                strSqlAM072.AppendFormat( "UPDATE R_PQAM SET AM072='{0}' WHERE AM002='{1}'" ,modelAm.AM072 ,modelAm.AM002 );
                SQLString.Add( strSqlAM072.ToString( ) );
            }
            if ( modelAm.AM074 > 0 )
            {
                StringBuilder strSqlAM074 = new StringBuilder( );
                strSqlAM074.AppendFormat( "UPDATE R_PQAM SET AM074='{0}' WHERE AM002='{1}'" ,modelAm.AM074 ,modelAm.AM002 );
                SQLString.Add( strSqlAM074.ToString( ) );
            }
            if ( modelAm.AM076 > 0 )
            {
                StringBuilder strSqlAM076 = new StringBuilder( );
                strSqlAM076.AppendFormat( "UPDATE R_PQAM SET AM076='{0}' WHERE AM002='{1}'" ,modelAm.AM076 ,modelAm.AM002 );
                SQLString.Add( strSqlAM076.ToString( ) );
            }
            if ( modelAm.AM078 > 0 )
            {
                StringBuilder strSqlAM078 = new StringBuilder( );
                strSqlAM078.AppendFormat( "UPDATE R_PQAM SET AM078='{0}' WHERE AM002='{1}'" ,modelAm.AM078 ,modelAm.AM002 );
                SQLString.Add( strSqlAM078.ToString( ) );
            }
            if ( modelAm.AM080 > 0 )
            {
                StringBuilder strSqlAM080 = new StringBuilder( );
                strSqlAM080.AppendFormat( "UPDATE R_PQAM SET AM080='{0}' WHERE AM002='{1}'" ,modelAm.AM080 ,modelAm.AM002 );
                SQLString.Add( strSqlAM080.ToString( ) );
            }
            if ( modelAm.AM082 > 0 )
            {
                StringBuilder strSqlAM082 = new StringBuilder( );
                strSqlAM082.AppendFormat( "UPDATE R_PQAM SET AM082='{0}' WHERE AM002='{1}'" ,modelAm.AM082 ,modelAm.AM002 );
                SQLString.Add( strSqlAM082.ToString( ) );
            }
            if ( modelAm.AM084 > 0 )
            {
                StringBuilder strSqlAM084 = new StringBuilder( );
                strSqlAM084.AppendFormat( "UPDATE R_PQAM SET AM084='{0}' WHERE AM002='{1}'" ,modelAm.AM084 ,modelAm.AM002 );
                SQLString.Add( strSqlAM084.ToString( ) );
            }
            if ( modelAm.AM086 > 0 )
            {
                StringBuilder strSqlAM086 = new StringBuilder( );
                strSqlAM086.AppendFormat( "UPDATE R_PQAM SET AM086='{0}' WHERE AM002='{1}'" ,modelAm.AM086 ,modelAm.AM002 );
                SQLString.Add( strSqlAM086.ToString( ) );
            }
            if ( modelAm.AM088 > 0 )
            {
                StringBuilder strSqlAM088 = new StringBuilder( );
                strSqlAM088.AppendFormat( "UPDATE R_PQAM SET AM088='{0}' WHERE AM002='{1}'" ,modelAm.AM088 ,modelAm.AM002 );
                SQLString.Add( strSqlAM088.ToString( ) );
            }
            if ( modelAm.AM090 > 0 )
            {
                StringBuilder strSqlAM090 = new StringBuilder( );
                strSqlAM090.AppendFormat( "UPDATE R_PQAM SET AM090='{0}' WHERE AM002='{1}'" ,modelAm.AM090 ,modelAm.AM002 );
                SQLString.Add( strSqlAM090.ToString( ) );
            }
            if ( modelAm.AM092 > 0 )
            {
                StringBuilder strSqlAM092 = new StringBuilder( );
                strSqlAM092.AppendFormat( "UPDATE R_PQAM SET AM092='{0}' WHERE AM002='{1}'" ,modelAm.AM092 ,modelAm.AM002 );
                SQLString.Add( strSqlAM092.ToString( ) );
            }
            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        
        void ByOneBy ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "SELECT AMB108,AMB110,AMB111,AMB115,AMB070,AMB072,AMB074,AMB076,AMB078,AMB080,AMB082,AMB084,AMB086,AMB088,AMB090,AMB092 FROM R_PQAMB WHERE AMB001='{0}'" ,oddNum );

            DataTable de = SqlHelper.ExecuteDataTable( "SELECT AM108,AM110,AM111,AM115,AM070,AM072,AM074,AM076,AM078,AM080,AM082,AM084,AM086,AM088,AM090,AM092 FROM R_PQAM WHERE AM002='" + modelAm.AM002 + "'" );
            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            if ( da != null && da.Rows.Count > 0 )
            {
                if ( modelAm.AM108 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB108='{0}' WHERE AMB001='{1}'" ,modelAm.AM108 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM110 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB110='{0}' WHERE AMB001='{1}'" ,modelAm.AM110 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM111 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB111='{0}' WHERE AMB001='{1}'" ,modelAm.AM111 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM115 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB115='{0}' WHERE AMB001='{1}'" ,modelAm.AM115 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM070 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB070='{0}' WHERE AMB001='{1}'" ,modelAm.AM070 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM072 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB072='{0}' WHERE AMB001='{1}'" ,modelAm.AM072 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM074 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB074='{0}' WHERE AMB001='{1}'" ,modelAm.AM074 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM076 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB076='{0}' WHERE AMB001='{1}'" ,modelAm.AM076 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM078 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB078='{0}' WHERE AMB001='{1}'" ,modelAm.AM078 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM080 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB080='{0}' WHERE AMB001='{1}'" ,modelAm.AM080 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM082 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB082='{0}' WHERE AMB001='{1}'" ,modelAm.AM082 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM084 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB084='{0}' WHERE AMB001='{1}'" ,modelAm.AM084 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM086 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB086='{0}' WHERE AMB001='{1}'" ,modelAm.AM086 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM088 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB088='{0}' WHERE AMB001='{1}'" ,modelAm.AM088 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM090 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB090='{0}' WHERE AMB001='{1}'" ,modelAm.AM090 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM092 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB092='{0}' WHERE AMB001='{1}'" ,modelAm.AM092 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                
                if ( de != null && de.Rows.Count > 0 )
                {
                    modelAm.AM108 = modelAm.AM108 - ( string.IsNullOrEmpty( da.Rows[0]["AMB108"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB108"].ToString( ) ) );
                    modelAm.AM110 = modelAm.AM110 - ( string.IsNullOrEmpty( da.Rows[0]["AMB110"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB110"].ToString( ) ) );
                    modelAm.AM111 = modelAm.AM111 - ( string.IsNullOrEmpty( da.Rows[0]["AMB111"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB111"].ToString( ) ) );
                    modelAm.AM115 = modelAm.AM115 - ( string.IsNullOrEmpty( da.Rows[0]["AMB115"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB115"].ToString( ) ) );
                    modelAm.AM070 = modelAm.AM070 - ( string.IsNullOrEmpty( da.Rows[0]["AMB070"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB070"].ToString( ) ) );
                    modelAm.AM072 = modelAm.AM072 - ( string.IsNullOrEmpty( da.Rows[0]["AMB072"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB072"].ToString( ) ) );
                    modelAm.AM074 = modelAm.AM074 - ( string.IsNullOrEmpty( da.Rows[0]["AMB074"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB074"].ToString( ) ) );
                    modelAm.AM076 = modelAm.AM076 - ( string.IsNullOrEmpty( da.Rows[0]["AMB076"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB076"].ToString( ) ) );
                    modelAm.AM078 = modelAm.AM078 - ( string.IsNullOrEmpty( da.Rows[0]["AMB078"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB078"].ToString( ) ) );
                    modelAm.AM080 = modelAm.AM080 - ( string.IsNullOrEmpty( da.Rows[0]["AMB080"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB080"].ToString( ) ) );
                    modelAm.AM082 = modelAm.AM082 - ( string.IsNullOrEmpty( da.Rows[0]["AMB082"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB082"].ToString( ) ) );
                    modelAm.AM084 = modelAm.AM084 - ( string.IsNullOrEmpty( da.Rows[0]["AMB084"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB084"].ToString( ) ) );
                    modelAm.AM086 = modelAm.AM086 - ( string.IsNullOrEmpty( da.Rows[0]["AMB086"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB086"].ToString( ) ) );
                    modelAm.AM088 = modelAm.AM088 - ( string.IsNullOrEmpty( da.Rows[0]["AMB088"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB088"].ToString( ) ) );
                    modelAm.AM090 = modelAm.AM090 - ( string.IsNullOrEmpty( da.Rows[0]["AMB090"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB090"].ToString( ) ) );
                    modelAm.AM092 = modelAm.AM092 - ( string.IsNullOrEmpty( da.Rows[0]["AMB092"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB092"].ToString( ) ) );

                    modelAm.AM108 = modelAm.AM108 + ( string.IsNullOrEmpty( de.Rows[0]["AM108"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM108"].ToString( ) ) );
                    modelAm.AM110 = modelAm.AM110 + ( string.IsNullOrEmpty( de.Rows[0]["AM110"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM110"].ToString( ) ) );
                    modelAm.AM111 = modelAm.AM111 + ( string.IsNullOrEmpty( de.Rows[0]["AM111"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM111"].ToString( ) ) );
                    modelAm.AM115 = modelAm.AM115 + ( string.IsNullOrEmpty( de.Rows[0]["AM115"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM115"].ToString( ) ) );
                    modelAm.AM070 = modelAm.AM070 + ( string.IsNullOrEmpty( de.Rows[0]["AM070"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM070"].ToString( ) ) );
                    modelAm.AM072 = modelAm.AM072 + ( string.IsNullOrEmpty( de.Rows[0]["AM072"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM072"].ToString( ) ) );
                    modelAm.AM074 = modelAm.AM074 + ( string.IsNullOrEmpty( de.Rows[0]["AM074"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM074"].ToString( ) ) );
                    modelAm.AM076 = modelAm.AM076 + ( string.IsNullOrEmpty( de.Rows[0]["AM076"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM076"].ToString( ) ) );
                    modelAm.AM078 = modelAm.AM078 + ( string.IsNullOrEmpty( de.Rows[0]["AM078"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM078"].ToString( ) ) );
                    modelAm.AM080 = modelAm.AM080 + ( string.IsNullOrEmpty( de.Rows[0]["AM080"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM080"].ToString( ) ) );
                    modelAm.AM082 = modelAm.AM082 + ( string.IsNullOrEmpty( de.Rows[0]["AM082"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM082"].ToString( ) ) );
                    modelAm.AM084 = modelAm.AM084 + ( string.IsNullOrEmpty( de.Rows[0]["AM084"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM084"].ToString( ) ) );
                    modelAm.AM086 = modelAm.AM086 + ( string.IsNullOrEmpty( de.Rows[0]["AM086"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM086"].ToString( ) ) );
                    modelAm.AM088 = modelAm.AM088 + ( string.IsNullOrEmpty( de.Rows[0]["AM088"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM088"].ToString( ) ) );
                    modelAm.AM090 = modelAm.AM090 + ( string.IsNullOrEmpty( de.Rows[0]["AM090"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM090"].ToString( ) ) );
                    modelAm.AM092 = modelAm.AM092 + ( string.IsNullOrEmpty( de.Rows[0]["AM092"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM092"].ToString( ) ) );
                }
                
                
            }
            else
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "INSERT INTO R_PQAMB (AMB001,AMB108,AMB110,AMB111,AMB115,AMB070,AMB072,AMB074,AMB076,AMB078,AMB080,AMB082,AMB084,AMB086,AMB088,AMB090,AMB092) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}')" ,oddNum ,modelAm.AM108 ,modelAm.AM110 ,modelAm.AM111 ,modelAm.AM115 ,modelAm.AM070 ,modelAm.AM072 ,modelAm.AM074 ,modelAm.AM076 ,modelAm.AM078 ,modelAm.AM080 ,modelAm.AM082 ,modelAm.AM084 ,modelAm.AM086 ,modelAm.AM088 ,modelAm.AM090 ,modelAm.AM092 );
                SQLString.Add( strSql.ToString( ) );
                if ( de != null && de.Rows.Count > 0 )
                {
                    modelAm.AM108 = modelAm.AM108 + ( string.IsNullOrEmpty( de.Rows[0]["AM108"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM108"].ToString( ) ) );
                    modelAm.AM110 = modelAm.AM110 + ( string.IsNullOrEmpty( de.Rows[0]["AM110"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM110"].ToString( ) ) );
                    modelAm.AM111 = modelAm.AM111 + ( string.IsNullOrEmpty( de.Rows[0]["AM111"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM111"].ToString( ) ) );
                    modelAm.AM115 = modelAm.AM115 + ( string.IsNullOrEmpty( de.Rows[0]["AM115"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM115"].ToString( ) ) );
                    modelAm.AM070 = modelAm.AM070 + ( string.IsNullOrEmpty( de.Rows[0]["AM070"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM070"].ToString( ) ) );
                    modelAm.AM072 = modelAm.AM072 + ( string.IsNullOrEmpty( de.Rows[0]["AM072"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM072"].ToString( ) ) );
                    modelAm.AM074 = modelAm.AM074 + ( string.IsNullOrEmpty( de.Rows[0]["AM074"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM074"].ToString( ) ) );
                    modelAm.AM076 = modelAm.AM076 + ( string.IsNullOrEmpty( de.Rows[0]["AM076"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM076"].ToString( ) ) );
                    modelAm.AM078 = modelAm.AM078 + ( string.IsNullOrEmpty( de.Rows[0]["AM078"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM078"].ToString( ) ) );
                    modelAm.AM080 = modelAm.AM080 + ( string.IsNullOrEmpty( de.Rows[0]["AM080"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM080"].ToString( ) ) );
                    modelAm.AM082 = modelAm.AM082 + ( string.IsNullOrEmpty( de.Rows[0]["AM082"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM082"].ToString( ) ) );
                    modelAm.AM084 = modelAm.AM084 + ( string.IsNullOrEmpty( de.Rows[0]["AM084"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM084"].ToString( ) ) );
                    modelAm.AM086 = modelAm.AM086 + ( string.IsNullOrEmpty( de.Rows[0]["AM086"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM086"].ToString( ) ) );
                    modelAm.AM088 = modelAm.AM088 + ( string.IsNullOrEmpty( de.Rows[0]["AM088"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM088"].ToString( ) ) );
                    modelAm.AM090 = modelAm.AM090 + ( string.IsNullOrEmpty( de.Rows[0]["AM090"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM090"].ToString( ) ) );
                    modelAm.AM092 = modelAm.AM092 + ( string.IsNullOrEmpty( de.Rows[0]["AM092"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM092"].ToString( ) ) );
                }
                
            }
        }

        /// <summary>
        /// 获取工序
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable getTableWorkProce ( string num )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT GS35 FROM R_PQP WHERE GS74='R_196' AND GS01='{0}'" ,num );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}

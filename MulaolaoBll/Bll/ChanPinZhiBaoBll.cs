using StudentMgr;
using System;
using System . Collections;
using System . Collections . Generic;
using System . Data;
using System . Data . SqlClient;
using System . Linq;
using System . Text;
using System . Threading . Tasks;

namespace MulaolaoBll.Bll
{
    public class ChanPinZhiBaoBll
    {
        /// <summary>
        /// 获取打印数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePrintOne ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT CP52,CP51,CP53,CP01,CP06,CP07,CP09,CP54,CP13,CONVERT( BIGINT, ROUND(CP13 * CP54,0) ) U1, CP08,CP10, CP11,CASE WHEN CP10!=0 THEN CONVERT( DECIMAL( 11, 2 ), CP13 * CP10 ) WHEN CP10=0 THEN CONVERT( DECIMAL( 11, 2 ), CP13 * CP11 ) END U2, CP12,CASE WHEN CP10!=0 THEN CP13 * CP54 * CP10 - CP12 WHEN CP10=0 THEN CP13 * CP54 * CP11 - CP12 END U3, CONVERT( VARCHAR( 20 ), CP14, 102 ) U4 FROM R_PQQ" );
            strSql.Append( " WHERE CP03 =@CP03" );
            SqlParameter[] parameter = {
                new SqlParameter("@CP03",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取打印数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePrintTwo ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT CP59,CASE WHEN CP59 IS NULL OR CP59='' THEN CP44 ELSE (SELECT DGA003 FROM TPADGA WHERE DGA001=CP59) END CP44,CASE WHEN CP59 IS NULL OR CP59='' THEN CP45 ELSE (SELECT DGA017 FROM TPADGA WHERE DGA001=CP59) END CP45,CASE WHEN CP59 IS NULL OR CP59='' THEN CP46 ELSE (SELECT DGA008 FROM TPADGA WHERE DGA001=CP59) END CP46,CASE WHEN CP59 IS NULL OR CP59='' THEN CP47 ELSE (SELECT DGA009 FROM TPADGA WHERE DGA001=CP59) END CP47,CASE WHEN CP59 IS NULL OR CP59='' THEN CP48 ELSE (SELECT DGA011 FROM TPADGA WHERE DGA001=CP59) END CP48,CP05,CP04,CP15,CP16,CP17,CP18,CP20,CP21,CP22,CP23,CP24,CP25,CP26,CP27,CP28,CP29,CP30,CP31,CP32,CONVERT(VARCHAR(20),CP33,102) CP33,CP34,CONVERT(VARCHAR(20),CP35,102) CP35,CP36,CONVERT(VARCHAR(20),CP37,102) CP37,CP38,CONVERT(VARCHAR(20),CP39,102) CP39,CP40,CONVERT(VARCHAR(20),CP41,102) CP41,CP42,CONVERT(VARCHAR(20),CP43,102) CP43,(SELECT DBA028 FROM TPADBA WHERE CP02=DBA001) DBA028,(SELECT DBA002 FROM TPADBA WHERE CP02=DBA001) DBA002,CP57,CP03,ISNULL(CP56,'F') CP56 FROM R_PQQ" );
            strSql.Append( " WHERE CP03 = @CP03" );
            SqlParameter[] parameter = {
                new SqlParameter("@CP03",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取联系人
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableCon ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DBA002,DBA001,DBA028 FROM TPADBA WHERE DBA028!=''  AND (DBA043='F' OR DBA043='' OR DBA043 IS NULL) ORDER BY DBA001" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取生产车间
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableWork ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DBA001,DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002 IN (SELECT DBA002 FROM TPADBA WHERE DBA005=(SELECT DAA001 FROM TPADAA WHERE DAA002='生产部')) AND (DBA043='F' OR DBA043='' OR DBA043 IS NULL))" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取流水信息
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableNum ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT PQF01,PQF02,PQF03,PQF04,PQF06,RES05 FROM R_PQF A,R_REVIEWS B WHERE A.PQF01=B.RES06 AND RES05='执行' ORDER BY PQF01 DESC" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取509信息
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePqp ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT GS07,GS08,GS09,GS10 FROM R_PQP A,R_REVIEWS B,R_MLLCXMC C WHERE A.GS01=B.RES06 AND B.RES01=C.CX01 AND RES05='执行' AND CX02='产品每套成本改善控制表(R_509)' AND GS07 IS NOT NULL OR GS07!='' UNION SELECT DISTINCT CP06,CP07,CP08,CP13 FROM R_PQQ WHERE CP06!=''" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表  单个字段
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableOnly ( string field )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT " );
            strSql.Append( field );
            strSql.Append( " FROM R_PQQ" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public System.Data.DataTable GetDataTableOnly (  )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT CP59,CASE WHEN CP59 IS NULL THEN CP44 WHEN CP59='' THEN CP44 ELSE DGA003 END CP44 FROM R_PQQ A LEFT JOIN TPADGA B ON A.CP59=B.DGA001 WHERE CP59 IS NOT NULL AND CP59!=''" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetChanPinZhiBaoCount ( string strWhere )
        {
            //Task task = new Task ( editCP63 );
            //task . Start ( );

            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQQ" );
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
        /// 是否结账
        /// </summary>
        void editCP63 ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "WITH CET AS (SELECT CP01,CP03,SUM(CASE WHEN CP10=0 THEN CP11*CP13*CP54-CP12 WHEN CP11=0 THEN CP10*CP13*CP54-CP12 ELSE CP10*CP13*CP54-CP12 END)-ISNULL(AK011,0) U2 FROM R_PQQ A LEFT JOIN (SELECT AK002,AK003,SUM(ISNULL(AK011,0)) AK011 FROM R_PQAK GROUP BY AK002,AK003) B ON A.CP01=B.AK002 AND A.CP03=B.AK003 GROUP BY  CP01,CP03,ISNULL(AK011,0)) " );
            strSql . Append ( "UPDATE R_PQQ SET CP63=CASE WHEN U2<=10 AND U2>=-10 THEN '已结' ELSE '未结' END FROM CET B WHERE R_PQQ.CP01=B.CP01 AND R_PQQ.CP03=B.CP03" );

            SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取总记录数  财务结账
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetChanPinZhiBaoCountOne ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQQ TT,R_REVIEWS B WHERE TT.CP03=B.RES06 AND RES05='执行' AND NOT EXISTS (SELECT 1 FROM R_PQAL C,R_PQAK D WHERE TT.idx=C.AL003 AND TT.CP03=C.AL002 AND C.AL001=D.idx)" );
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
        public System.Data.DataTable GetDataTableByPage ( string strWhere ,string orderby ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,CP03,CP01,CP51,CP52,CP53,CASE WHEN CP59 IS NULL OR CP59='' THEN CP44 ELSE (SELECT DGA003 FROM TPADGA WHERE DGA001=CP59) END CP44,CP06,CP07,CP09,CP54,CASE WHEN CP10=0 THEN CP11*CP13*CP54-CP12 WHEN CP11=0 THEN CP10*CP13*CP54-CP12 ELSE CP10*CP13*CP54-CP12 END U2,CP56,(SELECT RES05 FROM R_REVIEWS WHERE RES04=(SELECT MAX(RES04) FROM R_REVIEWS WHERE RES06=CP03)) RES05,CP32,CONVERT(FLOAT,CASE WHEN CP10!=0 THEN CP13*CP10 ELSE CP13*CP11 END ) CP,CP63 FROM (" );
            strSql.Append( " SELECT ROW_NUMBER() OVER( " );
            if ( !string.IsNullOrEmpty( orderby ) )
            {
                strSql.Append( "ORDER BY T." + orderby );
            }
            else
            {
                strSql.Append( "ORDER BY T.idx DESC" );
            }
            strSql.Append( " ) AS Row,T.* FROM R_PQQ T" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " WHERE " + strWhere );
            }
            strSql.Append( " ) TT" );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

         
        /// <summary>
        /// 分页获取数据列表  财务结账   已执行单据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableByPage ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT TT.idx,CP03,CP01,CP51,CP52,CP53,CASE WHEN CP59 IS NULL OR CP59='' THEN CP44 ELSE (SELECT DGA003 FROM TPADGA WHERE DGA001=CP59) END CP44,CP06,CP07,CP09,CP54,CASE WHEN CP10=0 THEN CP11*CP13*CP54-CP12 WHEN CP11=0 THEN CP10*CP13*CP54-CP12 ELSE CP10*CP13*CP54-CP12 END U2,CP56,RES05,CP32,CONVERT(FLOAT,CASE WHEN CP10!=0 THEN CP13*CP10 ELSE CP13*CP11 END ) CP,CP63 FROM ( " );
            strSql.Append( " SELECT ROW_NUMBER() OVER( " );
            strSql.Append( "ORDER BY T.CP03 DESC" );
            strSql.Append( " ) AS Row,T.* FROM R_PQQ T" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " WHERE " + strWhere );
            }
            strSql.Append( " ) TT,R_REVIEWS B WHERE TT.CP03=B.RES06 AND RES05='执行' AND NOT EXISTS (SELECT 1 FROM R_PQAL C,R_PQAK D WHERE TT.idx=C.AL003 AND TT.CP03=C.AL002 AND C.AL001=D.idx AND (AK009-AK010-AK011-AK015)<=100)" );// AND AK009-AK010-AK011!=0  ||  AK009=AK011
            strSql .AppendFormat( " AND TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 是否存在一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists ( MulaolaoLibrary.ChanPinZhiBiaoLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQQ" );
            strSql.Append( " WHERE CP01=@CP01 AND CP06=@CP06 AND CP09=@CP09" );// AND CP07=@CP07
            SqlParameter [ ] parameter = {
                new SqlParameter("@CP01",SqlDbType.NVarChar),
                new SqlParameter("@CP06",SqlDbType.NVarChar),
                //new SqlParameter("@CP07",SqlDbType.NVarChar),
                new SqlParameter("@CP09",SqlDbType.NVarChar)
            };

            parameter[0].Value = model.CP01;
            parameter[1].Value = model.CP06;
            //parameter[2].Value = model.CP07;
            parameter[2].Value = model.CP09;
            
            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add ( MulaolaoLibrary.ChanPinZhiBiaoLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQQ (" );
            strSql.Append( "CP03,CP06,CP07,CP08,CP54,CP09,CP10,CP11,CP12,CP13,CP14,CP59,CP01)" );
            strSql.Append( " VALUES (" );
            strSql . AppendFormat ( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')" ,model . CP03 ,model . CP06 ,model . CP07 ,model . CP08 ,model . CP54 ,model . CP09 ,model . CP10 ,model . CP11 ,model . CP12 ,model . CP13 ,model . CP14 ,model . CP59 ,model . CP01 );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.CP03 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );
            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary . ChanPinZhiBiaoLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQQ SET " );
            strSql . AppendFormat ( "CP06='{0}'," ,model . CP06 );
            strSql . AppendFormat ( "CP07='{0}'," ,model . CP07 );
            strSql . AppendFormat ( "CP08='{0}'," ,model . CP08 );
            strSql . AppendFormat ( "CP09='{0}'," ,model . CP09 );
            strSql . AppendFormat ( "CP10='{0}'," ,model . CP10 );
            strSql . AppendFormat ( "CP11='{0}'," ,model . CP11 );
            strSql . AppendFormat ( "CP12='{0}'," ,model . CP12 );
            strSql . AppendFormat ( "CP13='{0}'," ,model . CP13 );
            strSql . AppendFormat ( "CP14='{0}'," ,model . CP14 );
            strSql . AppendFormat ( "CP54='{0}'," ,model . CP54 );
            strSql . AppendFormat ( "CP59='{0}'," ,model . CP59 );
            strSql . AppendFormat ( "CP01='{0}' " ,model . CP01 );
            strSql . AppendFormat ( " WHERE CP03='{1}' AND idx='{0}'" ,model . IDX ,model . CP03 );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( tableNum ,tableName ,logins ,dtOne ,model . CP03 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 批量编辑数量
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateBatch ( MulaolaoLibrary.ChanPinZhiBiaoLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQQ SET " );
            strSql.AppendFormat( "CP54='{0}'" ,model.CP54 );
            strSql.AppendFormat( " WHERE CP03='{0}'" ,model.CP03 );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.CP03 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string oddNum ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQQ" );
            strSql . AppendFormat ( " WHERE CP03='{1}' AND idx={0}" , idx , oddNum );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
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
            strSql.Append( "DELETE FROM R_PQQ" );
            strSql.AppendFormat( " WHERE CP03='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
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
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTable ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,CP06,CP07,CP08,CP54,CP09,CP10,CP11,CP12,CP13,CP14,U3,U4 FROM R_PQQ" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( " ORDER BY idx DESC" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ChanPinZhiBiaoLibrary GetModel (int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQQ" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };

            parameter[0].Value = idx;

            System.Data.DataTable dt = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( dt.Rows.Count > 0 )
                return GetDataRow( dt.Rows[0] );
            else
                return null;
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ChanPinZhiBiaoLibrary GetDataRow ( DataRow row)
        {
            MulaolaoLibrary.ChanPinZhiBiaoLibrary model = new MulaolaoLibrary.ChanPinZhiBiaoLibrary( );
            if ( row !=null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    model.IDX = int.Parse( row["idx"].ToString( ) );
                else
                    model.IDX = 0;
                if ( row["CP03"] != null && row["CP03"].ToString( ) != "" )
                    model.CP03 = row["CP03"].ToString( );
                else
                    model.CP03 = string.Empty;
                if ( row["CP06"] != null && row["CP06"].ToString( ) != "" )
                    model.CP06 = row["CP06"].ToString( );
                else
                    model.CP06 = string.Empty;
                if ( row["CP07"] != null && row["CP07"].ToString( ) != "" )
                    model.CP07 = row["CP07"].ToString( );
                else
                    model.CP07 = string.Empty;
                if ( row["CP08"] != null && row["CP08"].ToString( ) != "" )
                    model.CP08 = row["CP08"].ToString( );
                else
                    model.CP08 = string.Empty;
                if ( row["CP09"] != null && row["CP09"].ToString( ) != "" )
                    model.CP09 = row["CP09"].ToString( );
                else
                    model.CP09 = string.Empty;
                if ( row["CP10"] != null && row["CP10"].ToString( ) != "" )
                    model.CP10 = decimal.Parse( row["CP10"].ToString( ) );
                else
                    model.CP10 = 0;
                if ( row["CP11"] != null && row["CP11"].ToString( ) != "" )
                    model.CP11 = decimal.Parse( row["CP11"].ToString( ) );
                else
                    model.CP11 = 0;
                if ( row["CP12"] != null && row["CP12"].ToString( ) != "" )
                    model.CP12 = long.Parse( row["CP12"].ToString( ) );
                else
                    model.CP12 = 0;
                if ( row["CP13"] != null && row["CP13"].ToString( ) != "" )
                    model.CP13 = decimal.Parse( row["CP13"].ToString( ) );
                else
                    model.CP13 = 0;
                if ( row["CP14"] != null && row["CP14"].ToString( ) != "" )
                    model.CP14 = DateTime.Parse( row["CP14"].ToString( ) );
                else
                    model.CP14 = MulaolaoBll . Drity . GetDt ( );
                if ( row["CP54"] != null && row["CP54"].ToString( ) != "" )
                    model.CP54 = long.Parse( row["CP54"].ToString( ) );
                else
                    model.CP54 = 0;
                if ( row [ "CP59" ] != null && row [ "CP59" ] . ToString ( ) != "" )
                    model . CP59 = row [ "CP59" ] . ToString ( );
                else
                    model . CP59 = "";
            }
            return model;
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ChanPinZhiBiaoLibrary GetMo ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQQ" );
            strSql.Append( " WHERE CP03=@CP03" );
            SqlParameter[] parameter = {
                new SqlParameter("@CP03",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            System.Data.DataTable dt = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( dt.Rows.Count >= 1 )
                return GetDataR( dt.Rows[0] );
            else
                return null;
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ChanPinZhiBiaoLibrary GetDataR ( DataRow row )
        {
            MulaolaoLibrary.ChanPinZhiBiaoLibrary model = new MulaolaoLibrary.ChanPinZhiBiaoLibrary( );

            if ( row != null )
            {
                if ( row["CP01"] != null && row["CP01"].ToString( ) != "" )
                    model.CP01 = row["CP01"].ToString( );
                else
                    model.CP01 = string.Empty;
                if ( row["CP02"] != null && row["CP02"].ToString( ) != "" )
                    model.CP02 = row["CP02"].ToString( );
                else
                    model.CP02 = string.Empty;
                if ( row["CP03"] != null && row["CP03"].ToString( ) != "" )
                    model.CP03 = row["CP03"].ToString( );
                else
                    model.CP03 = string.Empty;
                if ( row["CP04"] != null && row["CP04"].ToString( ) != "" )
                    model.CP04 = row["CP04"].ToString( );
                else
                    model.CP04 = string.Empty;
                if ( row["CP05"] != null && row["CP05"].ToString( ) != "" )
                    model.CP05 = row["CP05"].ToString( );
                else
                    model.CP05 = string.Empty;
                if ( row["CP15"] != null && row["CP15"].ToString( ) != "" )
                    model.CP15 = row["CP15"].ToString( );
                else
                    model.CP15 = string.Empty;
                if ( row["CP16"] != null && row["CP16"].ToString( ) != "" )
                    model.CP16 = row["CP16"].ToString( );
                else
                    model.CP16 = string.Empty;
                if ( row["CP17"] != null && row["CP17"].ToString( ) != "" )
                    model.CP17 = row["CP17"].ToString( );
                else
                    model.CP17 = string.Empty;
                if ( row["CP18"] != null && row["CP18"].ToString( ) != "" )
                    model.CP18 = row["CP18"].ToString( );
                else
                    model.CP18 = string.Empty;
                if ( row["CP19"] != null && row["CP19"].ToString( ) != "" )
                    model.CP19 = int.Parse( row["CP19"].ToString( ) );
                else
                    model.CP19 = 0;
                if ( row["CP20"] != null && row["CP20"].ToString( ) != "" )
                    model.CP20 = row["CP20"].ToString( );
                else
                    model.CP20 = string.Empty;
                if ( row["CP21"] != null && row["CP21"].ToString( ) != "" )
                    model.CP21 = row["CP21"].ToString( );
                else
                    model.CP21 = string.Empty;
                if ( row["CP22"] != null && row["CP22"].ToString( ) != "" )
                    model.CP22 = row["CP22"].ToString( );
                else
                    model.CP22 = string.Empty;
                if ( row["CP23"] != null && row["CP23"].ToString( ) != "" )
                    model.CP23 = row["CP23"].ToString( );
                else
                    model.CP23 = string.Empty;
                if ( row["CP24"] != null && row["CP24"].ToString( ) != "" )
                    model.CP24 = row["CP24"].ToString( );
                else
                    model.CP24 = string.Empty;
                if ( row["CP25"] != null && row["CP25"].ToString( ) != "" )
                    model.CP25 = row["CP25"].ToString( );
                else
                    model.CP25 = string.Empty;
                if ( row["CP26"] != null && row["CP26"].ToString( ) != "" )
                    model.CP26 = row["CP26"].ToString( );
                else
                    model.CP26 = string.Empty;
                if ( row["CP27"] != null && row["CP27"].ToString( ) != "" )
                    model.CP27 = row["CP27"].ToString( );
                else
                    model.CP27 = string.Empty;
                if ( row["CP28"] != null && row["CP28"].ToString( ) != "" )
                    model.CP28 = row["CP28"].ToString( );
                else
                    model.CP28 = string.Empty;
                if ( row["CP29"] != null && row["CP29"].ToString( ) != "" )
                    model.CP29 = row["CP29"].ToString( );
                else
                    model.CP29 = string.Empty;
                if ( row["CP30"] != null && row["CP30"].ToString( ) != "" )
                    model.CP30 = row["CP30"].ToString( );
                else
                    model.CP30 = string.Empty;
                if ( row["CP31"] != null && row["CP31"].ToString( ) != "" )
                    model.CP31 = row["CP31"].ToString( );
                else
                    model.CP31 = string.Empty;
                if ( row["CP32"] != null && row["CP32"].ToString( ) != "" )
                    model.CP32 = row["CP32"].ToString( );
                else
                    model.CP32 = string.Empty;
                if ( row["CP33"] != null && row["CP33"].ToString( ) != "" )
                    model.CP33 = DateTime.Parse( row["CP33"].ToString( ) );
                else
                    model.CP33 = MulaolaoBll . Drity . GetDt ( );
                if ( row["CP34"] != null && row["CP34"].ToString( ) != "" )
                    model.CP34 = row["CP34"].ToString( );
                else
                    model.CP34 = string.Empty;
                if ( row["CP35"] != null && row["CP35"].ToString( ) != "" )
                    model.CP35 = DateTime.Parse( row["CP35"].ToString( ) );
                else
                    model.CP35 = MulaolaoBll . Drity . GetDt ( );
                if ( row["CP36"] != null && row["CP36"].ToString( ) != "" )
                    model.CP36 = row["CP36"].ToString( );
                else
                    model.CP36 = string.Empty;
                if ( row["CP37"] != null && row["CP37"].ToString( ) != "" )
                    model.CP37 = DateTime.Parse( row["CP37"].ToString( ) );
                else
                    model.CP37 = MulaolaoBll . Drity . GetDt ( );
                if ( row["CP38"] != null && row["CP38"].ToString( ) != "" )
                    model.CP38 = row["CP38"].ToString( );
                else
                    model.CP38 = string.Empty;
                if ( row["CP39"] != null && row["CP39"].ToString( ) != "" )
                    model.CP39 = DateTime.Parse( row["CP39"].ToString( ) );
                else
                    model.CP39 = MulaolaoBll . Drity . GetDt ( );
                if ( row["CP40"] != null && row["CP40"].ToString( ) != "" )
                    model.CP40 = row["CP40"].ToString( );
                else
                    model.CP40 = string.Empty;
                if ( row["CP41"] != null && row["CP41"].ToString( ) != "" )
                    model.CP41 = DateTime.Parse( row["CP41"].ToString( ) );
                else
                    model.CP41 = MulaolaoBll . Drity . GetDt ( );
                if ( row["CP42"] != null && row["CP42"].ToString( ) != "" )
                    model.CP42 = row["CP42"].ToString( );
                else
                    model.CP40 = string.Empty;
                if ( row["CP43"] != null && row["CP43"].ToString( ) != "" )
                    model.CP43 = DateTime.Parse( row["CP43"].ToString( ) );
                else
                    model.CP43 = MulaolaoBll . Drity . GetDt ( );
                if ( row["CP44"] != null && row["CP44"].ToString( ) != "" )
                    model.CP44 = row["CP44"].ToString( );
                else
                    model.CP44 = string.Empty;
                if ( row["CP45"] != null && row["CP45"].ToString( ) != "" )
                    model.CP45 = row["CP45"].ToString( );
                else
                    model.CP45 = string.Empty;
                if ( row["CP46"] != null && row["CP46"].ToString( ) != "" )
                    model.CP46 = row["CP46"].ToString( );
                else
                    model.CP46 = string.Empty;
                if ( row["CP47"] != null && row["CP47"].ToString( ) != "" )
                    model.CP47 = row["CP47"].ToString( );
                else
                    model.CP47 = string.Empty;
                if ( row["CP48"] != null && row["CP48"].ToString( ) != "" )
                    model.CP48 = row["CP48"].ToString( );
                else
                    model.CP48 = string.Empty;
                if ( row["CP49"] != null && row["CP49"].ToString( ) != "" )
                    model.CP49 = row["CP49"].ToString( );
                else
                    model.CP49 = string.Empty;
                if ( row["CP50"] != null && row["CP50"].ToString( ) != "" )
                    model.CP50 = row["CP50"].ToString( );
                else
                    model.CP50 = string.Empty;
                if ( row["CP51"] != null && row["CP51"].ToString( ) != "" )
                    model.CP51 = row["CP51"].ToString( );
                else
                    model.CP51 = string.Empty;
                if ( row["CP52"] != null && row["CP52"].ToString( ) != "" )
                    model.CP52 = row["CP52"].ToString( );
                else
                    model.CP52 = string.Empty;
                if ( row["CP53"] != null && row["CP53"].ToString( ) != "" )
                    model.CP53 = row["CP53"].ToString( );
                else
                    model.CP53 = string.Empty;
                if ( row["CP54"] != null && row["CP54"].ToString( ) != "" )
                    model.CP54 = long.Parse( row["CP54"].ToString( ) );
                else
                    model.CP54 = 0;
                if ( row["CP55"] != null && row["CP55"].ToString( ) != "" )
                    model.CP55 = row["CP55"].ToString( );
                else
                    model.CP55 = string.Empty;
                if ( row["CP56"] != null && row["CP56"].ToString( ) != "" )
                    model.CP56 = row["CP56"].ToString( );
                else
                    model.CP56 = string.Empty;
                if ( row["CP57"] != null && row["CP57"].ToString( ) != "" )
                    model.CP57 = row["CP57"].ToString( );
                else
                    model.CP57 = string.Empty;
                if ( row["CP58"] != null && row["CP58"].ToString( ) != "" )
                    model.CP58 = row["CP58"].ToString( );
                else
                    model.CP58 = string.Empty;
                if ( row["CP59"] != null && row["CP59"].ToString( ) != "" )
                    model.CP59 = row["CP59"].ToString( );
            }

            return model;
        }


        /// <summary>
        /// 是否已经送审
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="formText"></param>
        /// <returns></returns>
        public bool ExistsReview ( string oddNum,string formText)
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
            parameter[0].Value = oddNum;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 更新维护意见
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateWeiHu ( MulaolaoLibrary.ChanPinZhiBiaoLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQQ SET " );
            strSql.Append( "CP49=@CP49," );
            strSql.Append( "CP50=@CP50" );
            strSql.Append( " WHERE CP03=@CP03" );
            SqlParameter[] parameter = {
                new SqlParameter("@CP49",SqlDbType.NVarChar),
                new SqlParameter("@CP50",SqlDbType.NVarChar),
                new SqlParameter("@CP03",SqlDbType.NVarChar)
            };
            parameter[0].Value = model.CP49;
            parameter[1].Value = model.CP50;
            parameter[2].Value = model.CP03;

            int rows = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableAll ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT CP50 FROM R_PQQ" );
            strSql.Append( " WHERE CP03=@CP03" );
            SqlParameter[] parameter = {
                new SqlParameter("@CP03",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }


        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableCopy ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQQ" );
            strSql.Append( " WHERE CP03!=@CP03" );
            SqlParameter[] parameter = {
                new SqlParameter("@CP03",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateOther ( MulaolaoLibrary.ChanPinZhiBiaoLibrary model,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "UPDATE R_PQQ SET " );
            strSql.AppendFormat( "CP01='{0}'," ,model.CP01);
            strSql.AppendFormat( "CP02='{0}'," ,model.CP02 );
            strSql.AppendFormat( "CP04='{0}'," ,model.CP04 );
            strSql.AppendFormat( "CP05='{0}'," ,model.CP05 );
            strSql.AppendFormat( "CP15='{0}'," ,model.CP15 );
            strSql.AppendFormat( "CP16='{0}'," ,model.CP16 );
            strSql.AppendFormat( "CP17='{0}'," ,model.CP17 );
            strSql.AppendFormat( "CP18='{0}'," ,model.CP18 );
            strSql.AppendFormat( "CP19='{0}'," ,model.CP19 );
            strSql.AppendFormat( "CP20='{0}'," ,model.CP20 );
            strSql.AppendFormat( "CP21='{0}'," ,model.CP21 );
            strSql.AppendFormat( "CP22='{0}'," ,model.CP22 );
            strSql.AppendFormat( "CP23='{0}'," ,model.CP23 );
            strSql.AppendFormat( "CP24='{0}'," ,model.CP24 );
            strSql.AppendFormat( "CP25='{0}'," ,model.CP25 );
            strSql.AppendFormat( "CP26='{0}'," ,model.CP26 );
            strSql.AppendFormat( "CP27='{0}'," ,model.CP27 );
            strSql.AppendFormat( "CP28='{0}'," ,model.CP28 );
            strSql.AppendFormat( "CP29='{0}'," ,model.CP29 );
            strSql.AppendFormat( "CP30='{0}'," ,model.CP30 );
            strSql.AppendFormat( "CP31='{0}'," ,model.CP31 );
            strSql.AppendFormat( "CP32='{0}'," ,model.CP32 );
            strSql.AppendFormat( "CP33='{0}'," ,model.CP33 );
            strSql.AppendFormat( "CP34='{0}'," ,model.CP34 );
            strSql.AppendFormat( "CP35='{0}'," ,model.CP35 );
            strSql.AppendFormat( "CP36='{0}'," ,model.CP36 );
            strSql.AppendFormat( "CP37='{0}'," ,model.CP37 );
            strSql.AppendFormat( "CP38='{0}'," ,model.CP38 );
            strSql.AppendFormat( "CP39='{0}'," ,model.CP39 );
            strSql.AppendFormat( "CP40='{0}'," ,model.CP40 );
            strSql.AppendFormat( "CP41='{0}'," ,model.CP41 );
            strSql.AppendFormat( "CP42='{0}'," ,model.CP42 );
            strSql.AppendFormat( "CP43='{0}'," ,model.CP43 );
            strSql.AppendFormat( "CP44='{0}'," ,model.CP44 );
            strSql.AppendFormat( "CP45='{0}'," ,model.CP45 );
            strSql.AppendFormat( "CP46='{0}'," ,model.CP46 );
            strSql.AppendFormat( "CP47='{0}'," ,model.CP47 );
            strSql.AppendFormat( "CP48='{0}'," ,model.CP48 );
            strSql.AppendFormat( "CP49='{0}'," ,model.CP49 );
            strSql.AppendFormat( "CP50='{0}'," ,model.CP50 );
            strSql.AppendFormat( "CP51='{0}'," ,model.CP51 );
            strSql.AppendFormat( "CP52='{0}'," ,model.CP52 );
            strSql.AppendFormat( "CP53='{0}'," ,model.CP53 );
            strSql.AppendFormat( "CP55='{0}'," ,model.CP55 );
            strSql.AppendFormat( "CP56='{0}'," ,model.CP56 );
            strSql.AppendFormat( "CP57='{0}'," ,model.CP57 );
            strSql.AppendFormat( "CP58='{0}'," ,model.CP58 );
            strSql.AppendFormat( "CP59='{0}'" ,model.CP59 );
            strSql.AppendFormat( " WHERE CP03='{0}'" ,model.CP03 );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.CP03 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 是否复制成功
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateCopy ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            MulaolaoLibrary.ChanPinZhiBiaoLibrary model = new MulaolaoLibrary.ChanPinZhiBiaoLibrary( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQQ ( " );
            strSql.Append( "CP01,CP51,CP52,CP53,CP54,CP02,CP05,CP06,CP07,CP08,CP09,CP10,CP11,CP12,CP13,CP14,CP15,CP16,CP17,CP18,CP19,CP20,CP21,CP22,CP23,CP24,CP25,CP26,CP27,CP28,CP29,CP30,CP31)" );
            strSql.Append( "SELECT CP01,CP51,CP52,CP53,CP54,CP02,CP05,CP06,CP07,CP08,CP09,CP10,CP11,CP12,CP13,CP14,CP15,CP16,CP17,CP18,CP19,CP20,CP21,CP22,CP23,CP24,CP25,CP26,CP27,CP28,CP29,CP30,CP31 FROM R_PQQ " );
            strSql.AppendFormat( " WHERE CP03='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 删除复制失败数据
        /// </summary>
        public bool DeleteCopy ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQQ WHERE CP03 IS NULL" );

            return true;
        }

        /// <summary>
        /// 是否更改复制单号成功
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateCopyUp ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQQ SET " );
            strSql.AppendFormat( "CP03='{0}'," ,oddNum );
            strSql.Append( "CP55='复制'" );
            strSql.Append( " WHERE CP03 IS NULL" );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取供应商
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfSupplier ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DGA001,DGA003,DGA008,DGA011,DGA017,DGA009,DGA012 FROM TPADGA WHERE DGA052='F'" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取供应商
        /// </summary>
        /// <param name="supplierNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfSu ( string supplierNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DGA003,DGA008,DGA011,DGA017,DGA009,DGA012 FROM TPADGA " );
            strSql.AppendFormat( " WHERE DGA001='{0}'" ,supplierNum );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable receivableOf (string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT CASE CP56 WHEN 'T' THEN 'T' ELSE 'F' END CP56,CASE CP58 WHEN 'T' THEN 'T' ELSE 'F' END CP58,CP01,SUM(CASE WHEN CP10=0 THEN CONVERT(DECIMAL(18,1),CP13*CP54*CP11-CP12) WHEN CP11=0 THEN CONVERT(DECIMAL(18,1),CP13*CP54*CP10-CP12)END) CP FROM R_PQQ A INNER JOIN R_REVIEWS D ON A.CP03=D.RES06 AND RES05='执行'" );
            strSql.AppendFormat( " WHERE CP03='{0}'" ,oddNum );
            strSql.Append( "  AND (CP01!='' AND CP01 IS NOT NULL) AND CP09='委外' GROUP BY CP56,CP58,CP01" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 写应收款到241
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateOfOutSource ( MulaolaoLibrary.ProductCostSummaryLibrary model,string oper )
        {
            ArrayList SQLString = new ArrayList( );
            //MulaolaoBll.WriteReceivableToGeneralLedger.ByOneByChanPintZhiBao( model ,oddNum ,SQLString );
            ByOneBy( model ,SQLString,oper );
            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        
        void ByOneBy ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString,string oper )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql . Append ( "SELECT count(1) FROM R_PQAM WHERE AM002='" + model . AM002 + "'" );
            if ( SqlHelper . Exists ( strSql . ToString ( ) ) )
            {
                StringBuilder strSqlam108 = new StringBuilder ( );
                strSqlam108 . Append ( "UPDATE R_PQAM SET " );
                strSqlam108 . AppendFormat ( "AM108=ISNULL(AM108,0){1}{0}," ,model . AM108 ,oper );
                strSqlam108 . AppendFormat ( "AM108=ISNULL(AM110,0){1}{0}," ,model . AM110 ,oper );
                strSqlam108 . AppendFormat ( "AM108=ISNULL(AM111,0){1}{0}," ,model . AM111 ,oper );
                strSqlam108 . AppendFormat ( "AM108=ISNULL(AM115,0){1}{0} " ,model . AM115 ,oper );
                strSqlam108 . AppendFormat ( " WHERE AM002='{0}'" ,model . AM002 );
            }
            else if ( "+" . Equals ( oper ) )
            {
                strSql = new StringBuilder ( );
                strSql . Append ( "SELECT MAX(AM001) AM001 FROM " );
                DataTable table = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
                if ( table != null && table . Rows . Count > 0 )
                    model . AM001 = table . Rows [ 0 ] [ "AM001" ] . ToString ( );
                else
                    model . AM001 = "R_241-" + DateTime . Now . ToString ( "yyyyMMdd" ) + "001";
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "INSERT INTO R_PQAMB (AM001,AM002,AM108,AM110,AM111,AM115) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')" ,model . AM001 ,model . AM002 ,model . AM108 ,model . AM110 ,model . AM111 ,model . AM115 );
                SQLString . Add ( strSql . ToString ( ) );
            }
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable receivableOfOther ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT CASE WHEN CP09 LIKE '%雕刻%' THEN '雕刻' WHEN CP09 LIKE '%绕锯%' THEN '绕锯' WHEN CP09 LIKE '%夹料%' THEN '夹料' WHEN CP09 LIKE '%砂皮%' THEN '擦砂皮' WHEN CP09 LIKE '%丝印%' THEN '丝印' WHEN CP09 LIKE '%走台印%' THEN '走台印' WHEN CP09 LIKE '%移印%' THEN '移印' WHEN CP09 LIKE '%热转印%' THEN '热转印' WHEN CP09 LIKE '%烫印%' THEN '烫印' WHEN CP09 LIKE '%喷漆%' THEN '喷漆' WHEN CP09 LIKE '%冲压%' THEN '冲压' WHEN CP09 LIKE '%/%' THEN '委外' ELSE '手工剪切、其它' END CP09,CASE CP56 WHEN 'T' THEN 'T' ELSE 'F' END CP56,CASE CP58 WHEN 'T' THEN 'T' ELSE 'F' END CP58,CP01,SUM(CASE WHEN CP10=0 THEN CONVERT(DECIMAL(18,1),CP13*CP54*CP11-CP12) WHEN CP11=0 THEN CONVERT(DECIMAL(18,1),CP13*CP54*CP10-CP12)END) CP FROM R_PQQ A INNER JOIN R_REVIEWS D ON A.CP03=D.RES06 AND RES05='执行'" );
            strSql.AppendFormat( " WHERE CP03='{0}'" ,oddNum );
            strSql.Append( "  AND (CP01!='' AND CP01 IS NOT NULL) GROUP BY CP56,CP58,CP01,CP09" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 写应收款到241
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateOfOther ( MulaolaoLibrary.ProductCostSummaryLibrary model,string oper )
        {
            ArrayList SQLString = new ArrayList( );
            ByOneBys( model ,SQLString ,oper );
            //WriteReceivableToGeneralLedger.ByOneByChanPintZhiBao( model ,oddNum ,SQLString );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        
        void ByOneBys ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString,string oper )
        {
            //modelAm.AM070 = modelAm.AM072 = modelAm.AM074 = modelAm.AM076 = modelAm.AM078 = modelAm.AM080 = modelAm.AM082 = modelAm.AM084 = modelAm.AM086 = modelAm.AM088 = modelAm.AM090 = modelAm.AM092 = 0;
            StringBuilder strSql = new StringBuilder( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM R_PQAM WHERE AM002='{0}'" ,model . AM002 );
            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            if ( da != null && da . Rows . Count > 0 )
            {
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "UPDATE R_PQAM SET " );
                strSql . AppendFormat ( "AM070=ISNULL(AM070,0){1}{0}," ,model . AM070 ,oper );
                strSql . AppendFormat ( "AM072=ISNULL(AM072,0){1}{0}," ,model . AM072 ,oper );
                strSql . AppendFormat ( "AM074=ISNULL(AM074,0){1}{0}," ,model . AM074 ,oper );
                strSql . AppendFormat ( "AM076=ISNULL(AM076,0){1}{0}," ,model . AM076 ,oper );
                strSql . AppendFormat ( "AM078=ISNULL(AM078,0){1}{0}," ,model . AM078 ,oper );
                strSql . AppendFormat ( "AM080=ISNULL(AM080,0){1}{0}," ,model . AM080 ,oper );
                strSql . AppendFormat ( "AM082=ISNULL(AM082,0){1}{0}," ,model . AM082 ,oper );
                strSql . AppendFormat ( "AM084=ISNULL(AM084,0){1}{0}," ,model . AM084 ,oper );
                strSql . AppendFormat ( "AM086=ISNULL(AM086,0){1}{0}," ,model . AM086 ,oper );
                strSql . AppendFormat ( "AM088=ISNULL(AM088,0){1}{0}," ,model . AM088 ,oper );
                strSql . AppendFormat ( "AM090=ISNULL(AM090,0){1}{0}," ,model . AM090 ,oper );
                strSql . AppendFormat ( "AM092=ISNULL(AM092,0){1}{0} " ,model . AM092 ,oper );
                strSql . AppendFormat ( "WHERE AM002='{0}'" ,model . AM002 );
                SQLString . Add ( strSql . ToString ( ) );
            }
            else if("+".Equals(oper))
            {
                strSql = new StringBuilder ( );
                strSql . Append ( "SELECT MAX(AM001) AM001 FROM R_PQAM" );
                DataTable table = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
                if ( table != null && table . Rows . Count > 0 )
                    model . AM001 = table . Rows [ 0 ] [ "AM001" ] . ToString ( );
                else
                    model . AM001 = "R_241-" + DateTime . Now . ToString ( "yyyyMMdd" ) + "001";
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "INSERT INTO R_PQAMB (AM001,AM002,AM070,AM072,AM074,AM076,AM078,AM080,AM082,AM084,AM086,AM088,AM090,AM092) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}')" ,model . AM001 ,model . AM002 ,model . AM070 ,model . AM072 ,model . AM074 ,model . AM076 ,model . AM078 ,model . AM080 ,model . AM082 ,model . AM084 ,model . AM086 ,model . AM088 ,model . AM090 ,model . AM092 );
                SQLString . Add ( strSql . ToString ( ) );
            }
        }
    }
}

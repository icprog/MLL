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
    public class SailesDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="filed"></param>
        /// <returns></returns>
        public DataTable GetList ( string filed )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT " );
            strSql.Append( filed );
            strSql.Append( " FROM R_PQF" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表  HT01
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public DataTable GetListPql ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT HT01 PQF01 FROM R_PQL A,R_REVIEWS B WHERE A.HT64=B.RES06 AND RES05='执行'" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表  审核人员信息
        /// </summary>
        /// <param name="filed"></param>
        /// <returns></returns>
        public DataTable GetListJoin ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT PQF55,(SELECT DBA002 FROM TPADBA WHERE PQF55=DBA001) DBA002 FROM R_PQF" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表  客户信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetListJoinCustomer ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT PQF11,(SELECT DFA003 FROM TPADFA WHERE PQF11=DFA001) DFA003 FROM R_PQF" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表  生产车间
        /// </summary>
        /// <returns></returns>
        public DataTable GetListProductionWork ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT PQF17,PQF66 FROM R_PQF" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT PQF01,PQF02,PQF03,PQF04,(SELECT DBA002 FROM TPADBA WHERE PQF12=DBA001) DBA002,(SELECT DFA003 FROM TPADFA WHERE PQF11=DFA001) DFA003,(SELECT RES05 FROM R_REVIEWS WHERE RES04=(SELECT MAX(RES04) FROM R_REVIEWS WHERE RES06=PQF01)) RES05,PQF32  FROM R_PQF" );
            if ( !string.IsNullOrEmpty( strWhere.Trim( ) ) )
            {
                strSql.Append( " WHERE " + strWhere );
                strSql.Append( " ORDER BY idx DESC" );
            }
            else
                strSql.Append( " ORDER BY idx DESC" );
            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.SailesLibrary DataRowToModel ( DataRow row )
        {
            MulaolaoLibrary.SailesLibrary model = new MulaolaoLibrary.SailesLibrary( );
            if ( row != null )
            {
                if ( row["PQF01"] != null && row["PQF01"].ToString( ) != "" )
                {
                    model.PQF01 = row["PQF01"].ToString( );
                }
            }

            return model;
        }

        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetSailesCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQF" );
            if ( !string.IsNullOrEmpty( strWhere.Trim( ) ) )
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
            strSql.Append( "SELECT idx,PQF01,PQF02,PQF03,PQF04,(SELECT DBA002 FROM TPADBA WHERE PQF55=DBA001) DBA002,(SELECT DFA003 FROM TPADFA WHERE PQF11=DFA001) DFA003,PQF66,(SELECT RES05 FROM R_REVIEWS WHERE RES04=(SELECT MAX(RES04) FROM R_REVIEWS WHERE RES06=PQF01)) RES05,PQF32 FROM ( " );
            strSql.Append( " SELECT ROW_NUMBER() OVER (" );
            if ( !string.IsNullOrEmpty( orderby.Trim( ) ) )
            {
                strSql.Append( "ORDER BY T." + orderby );
            }
            else
            {
                strSql.Append( "ORDER BY T.idx DESC" );
            }
            strSql.Append( ") AS Row, T.* FROM R_PQF T" );
            if ( !string.IsNullOrEmpty( strWhere.Trim( ) ) )
            {
                strSql.Append( " WHERE " + strWhere );
            }
            strSql.Append( " ) TT" );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );
            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 是否执行
        /// </summary>
        /// <param name="num"></param>
        /// <param name="formText"></param>
        /// <returns></returns>
        public bool ExistsReviews ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_REVIEWS" );
            strSql.Append( " WHERE RES01=@RES01 AND RES06=@RES06 AND RES05='执行'" );
            SqlParameter[] parameter = {
                new SqlParameter("@RES01",SqlDbType.NVarChar),
                new SqlParameter("@RES06",SqlDbType.NVarChar)
            };
            parameter[0].Value = "R_001";
            parameter[1].Value = num;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool Delete ( string tableNum ,string tableName ,string logins ,DateTime dtOne ,string oddNum ,string strS ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQF" );
            strSql.AppendFormat( " WHERE PQF01='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            StringBuilder strSq = new StringBuilder( );
            strSq.Append( "DELETE FROM R_REVIEWS" );
            strSq.AppendFormat( " WHERE RES01='{0}' AND RES06='{1}'" ,tableNum ,oddNum );
            SQLString.Add( strSq.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 删除送审记录
        /// </summary>
        /// <param name="num"></param>
        /// <param name="formText"></param>
        /// <returns></returns>
        public bool DeleteReview ( string num ,string formText )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_REVIEWS" );
            strSql.Append( " WHERE RES01=@RES01 AND RES06=@RES06" );
            SqlParameter[] parameter = {
                new SqlParameter("@RES01",SqlDbType.NVarChar),
                new SqlParameter("@RES06",SqlDbType.NVarChar)
            };

            parameter[0].Value = num;
            parameter[1].Value = formText;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add ( MulaolaoLibrary . SailesLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSq = new StringBuilder ( );
            strSq . Append ( "INSERT INTO R_PQF (" );
            strSq . Append ( "PQF01,PQF02,PQF03,PQF04,PQF05,PQF06,PQF07,PQF08,PQF09,PQF10,PQF11,PQF12,PQF13,PQF17,PQF20,PQF21,PQF23,PQF24,PQF29,PQF31,PQF32,PQF34,PQF38,PQF41,PQF44,PQF45,PQF47,PQF49,PQF51,PQF55,PQF56,PQF57,PQF58,PQF59,PQF60,PQF61,PQF62,PQF63,PQF64,PQF65,PQF66,PQF67)" );
            strSq . Append ( " VALUES (" );
            strSq . Append ( "@PQF01 ,@PQF02 ,@PQF03 ,@PQF04 ,@PQF05 ,@PQF06 ,@PQF07 ,@PQF08 ,@PQF09 ,@PQF10 ,@PQF11 ,@PQF12 ,@PQF13 ,@PQF17 ,@PQF20 ,@PQF21 ,@PQF23 ,@PQF24 ,@PQF29 ,@PQF31 ,@PQF32 ,@PQF34 ,@PQF38 ,@PQF41 ,@PQF44 ,@PQF45 ,@PQF47 ,@PQF49 ,@PQF51 ,@PQF55 ,@PQF56 ,@PQF57 ,@PQF58 ,@PQF59 ,@PQF60 ,@PQF61 ,@PQF62 ,@PQF63 ,@PQF64 ,@PQF65 ,@PQF66 ,@PQF67 )" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PQF01",SqlDbType.NVarChar),
                new SqlParameter("@PQF02",SqlDbType.NVarChar),
                new SqlParameter("@PQF03",SqlDbType.NVarChar),
                new SqlParameter("@PQF04",SqlDbType.NVarChar),
                new SqlParameter("@PQF05",SqlDbType.NVarChar),
                new SqlParameter("@PQF06",SqlDbType.BigInt),
                new SqlParameter("@PQF07",SqlDbType.NVarChar),
                new SqlParameter("@PQF08",SqlDbType.NVarChar),
                new SqlParameter("@PQF09",SqlDbType.Decimal),
                new SqlParameter("@PQF10",SqlDbType.Decimal),
                new SqlParameter("@PQF11",SqlDbType.NVarChar),
                new SqlParameter("@PQF12",SqlDbType.NVarChar),
                new SqlParameter("@PQF13",SqlDbType.Date),
                new SqlParameter("@PQF17",SqlDbType.NVarChar),
                new SqlParameter("@PQF20",SqlDbType.NVarChar),
                new SqlParameter("@PQF21",SqlDbType.NVarChar),
                new SqlParameter("@PQF23",SqlDbType.NVarChar),
                new SqlParameter("@PQF24",SqlDbType.NVarChar),
                new SqlParameter("@PQF29",SqlDbType.VarBinary),
                new SqlParameter("@PQF31",SqlDbType.Date),
                new SqlParameter("@PQF32",SqlDbType.Date),
                new SqlParameter("@PQF34",SqlDbType.Date),
                new SqlParameter("@PQF38",SqlDbType.Decimal),
                new SqlParameter("@PQF41",SqlDbType.NVarChar),
                new SqlParameter("@PQF44",SqlDbType.NVarChar),
                new SqlParameter("@PQF45",SqlDbType.Decimal),
                new SqlParameter("@PQF47",SqlDbType.NVarChar),
                new SqlParameter("@PQF49",SqlDbType.Decimal),
                new SqlParameter("@PQF51",SqlDbType.NVarChar),
                new SqlParameter("@PQF55",SqlDbType.NVarChar),
                new SqlParameter("@PQF56",SqlDbType.Date),
                new SqlParameter("@PQF57",SqlDbType.NVarChar),
                new SqlParameter("@PQF58",SqlDbType.Date),
                new SqlParameter("@PQF59",SqlDbType.NVarChar),
                new SqlParameter("@PQF60",SqlDbType.NVarChar),
                new SqlParameter("@PQF61",SqlDbType.NVarChar),
                new SqlParameter("@PQF62",SqlDbType.VarBinary),
                new SqlParameter("@PQF63",SqlDbType.Date),
                new SqlParameter("@PQF64",SqlDbType.NVarChar),
                new SqlParameter("@PQF65",SqlDbType.NVarChar),
                new SqlParameter("@PQF66",SqlDbType.NVarChar),
                new SqlParameter("@PQF67",SqlDbType.NVarChar)
            };

            parameter [ 0 ] . Value = model . PQF01;
            parameter [ 1 ] . Value = model . PQF02;
            parameter [ 2 ] . Value = model . PQF03;
            parameter [ 3 ] . Value = model . PQF04;
            parameter [ 4 ] . Value = model . PQF05;
            parameter [ 5 ] . Value = model . PQF06;
            parameter [ 6 ] . Value = model . PQF07;
            parameter [ 7 ] . Value = model . PQF08;
            parameter [ 8 ] . Value = model . PQF09;
            parameter [ 9 ] . Value = model . PQF10;
            parameter [ 10 ] . Value = model . PQF11;
            parameter [ 11 ] . Value = model . PQF12;
            parameter [ 12 ] . Value = model . PQF13;
            parameter [ 13 ] . Value = model . PQF17;
            parameter [ 14 ] . Value = model . PQF20;
            parameter [ 15 ] . Value = model . PQF21;
            parameter [ 16 ] . Value = model . PQF23;
            parameter [ 17 ] . Value = model . PQF24;
            parameter [ 18 ] . Value = model . PQF29;
            parameter [ 19 ] . Value = model . PQF31;
            parameter [ 20 ] . Value = model . PQF32;
            parameter [ 21 ] . Value = model . PQF34;
            parameter [ 22 ] . Value = model . PQF38;
            parameter [ 23 ] . Value = model . PQF41;
            parameter [ 24 ] . Value = model . PQF44;
            parameter [ 25 ] . Value = model . PQF45;
            parameter [ 26 ] . Value = model . PQF47;
            parameter [ 27 ] . Value = model . PQF49;
            parameter [ 28 ] . Value = model . PQF51;
            parameter [ 29 ] . Value = model . PQF55;
            parameter [ 30 ] . Value = model . PQF56;
            parameter [ 31 ] . Value = model . PQF57;
            parameter [ 32 ] . Value = model . PQF58;
            parameter [ 33 ] . Value = model . PQF59;
            parameter [ 34 ] . Value = model . PQF60;
            parameter [ 35 ] . Value = model . PQF61;
            parameter [ 36 ] . Value = model . PQF62;
            parameter [ 37 ] . Value = model . PQF63;
            parameter [ 38 ] . Value = model . PQF64;
            parameter [ 39 ] . Value = model . PQF65;
            parameter [ 40 ] . Value = model . PQF66;
            parameter [ 41 ] . Value = model . PQF67;

            int row = SqlHelper . ExecuteNonQuery ( strSq . ToString ( ) ,parameter );
            if ( row > 0 )
            {
                try
                {
                    StringBuilder strSql = new StringBuilder ( );
                    strSql . Append ( "INSERT INTO R_PQF (" );
                    strSql . Append ( "PQF01,PQF02,PQF03,PQF04,PQF05,PQF06,PQF07,PQF08,PQF09,PQF10,PQF11,PQF12,PQF13,PQF17,PQF20,PQF21,PQF23,PQF24,PQF29,PQF31,PQF32,PQF34,PQF38,PQF41,PQF44,PQF45,PQF47,PQF49,PQF51,PQF55,PQF56,PQF57,PQF58,PQF59,PQF60,PQF61,PQF62,PQF63,PQF64,PQF65,PQF66,PQF67)" );
                    strSql . Append ( " VALUES (" );
                    strSql . AppendFormat ( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}','{38}','{39}','{40}','{41}')" ,model . PQF01 ,model . PQF02 ,model . PQF03 ,model . PQF04 ,model . PQF05 ,model . PQF06 ,model . PQF07 ,model . PQF08 ,model . PQF09 ,model . PQF10 ,model . PQF11 ,model . PQF12 ,model . PQF13 ,model . PQF17 ,model . PQF20 ,model . PQF21 ,model . PQF23 ,model . PQF24 ,model . PQF29 ,model . PQF31 ,model . PQF32 ,model . PQF34 ,model . PQF38 ,model . PQF41 ,model . PQF44 ,model . PQF45 ,model . PQF47 ,model . PQF49 ,model . PQF51 ,model . PQF55 ,model . PQF56 ,model . PQF57 ,model . PQF58 ,model . PQF59 ,model . PQF60 ,model . PQF61 ,model . PQF62 ,model . PQF63 ,model . PQF64 ,model . PQF65 ,model . PQF66 ,model . PQF67 );
                    //SQLString.Add( strSql.ToString( ) );
                    SQLString . Add ( Drity . DrityOfComparation ( tableNum ,tableName ,logins ,dtOne ,model . PQF01 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

                    return SqlHelper . ExecuteSqlTran ( SQLString );
                }
                catch { }
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary . SailesLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQF SET " );
            strSql . Append ( "PQF02=@PQF02," );
            strSql . Append ( "PQF03=@PQF03," );
            strSql . Append ( "PQF04=@PQF04," );
            strSql . Append ( "PQF05=@PQF05," );
            strSql . Append ( "PQF06=@PQF06," );
            strSql . Append ( "PQF07=@PQF07," );
            strSql . Append ( "PQF08=@PQF08," );
            strSql . Append ( "PQF09=@PQF09," );
            strSql . Append ( "PQF10=@PQF10," );
            strSql . Append ( "PQF11=@PQF11," );
            strSql . Append ( "PQF12=@PQF12," );
            strSql . Append ( "PQF13=@PQF13," );
            
            strSql . Append ( "PQF20=@PQF20," );
            strSql . Append ( "PQF21=@PQF21," );
            strSql . Append ( "PQF23=@PQF23," );
            strSql . Append ( "PQF24=@PQF24," );
            strSql . Append ( "PQF29=@PQF29," );
            strSql . Append ( "PQF31=@PQF31," );
            strSql . Append ( "PQF32=@PQF32," );
            strSql . Append ( "PQF34=@PQF34," );
            strSql . Append ( "PQF38=@PQF38," );
            strSql . Append ( "PQF41=@PQF41," );
            strSql . Append ( "PQF44=@PQF44," );
            strSql . Append ( "PQF45=@PQF45," );
            strSql . Append ( "PQF47=@PQF47," );
            strSql . Append ( "PQF49=@PQF49," );
            strSql . Append ( "PQF51=@PQF51," );
            strSql . Append ( "PQF55=@PQF55," );
            strSql . Append ( "PQF56=@PQF56," );
            strSql . Append ( "PQF57=@PQF57," );
            strSql . Append ( "PQF58=@PQF58," );
            strSql . Append ( "PQF59=@PQF59," );
            strSql . Append ( "PQF60=@PQF60," );
            strSql . Append ( "PQF61=@PQF61," );
            strSql . Append ( "PQF62=@PQF62," );
            strSql . Append ( "PQF63=@PQF63," );
            strSql . Append ( "PQF64=@PQF64," );
            strSql . Append ( "PQF65=@PQF65," );
            if ( !string . IsNullOrEmpty ( model . PQF17 ) )
            {
                strSql . AppendFormat ( "PQF17='{0}'," ,model . PQF17 );
                strSql . AppendFormat ( "PQF66='{0}'," ,model . PQF66 );
            }
            strSql . Append ( "PQF67=@PQF67 " );
            strSql . Append ( " WHERE PQF01=@PQF01" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PQF01",SqlDbType.NVarChar),
                new SqlParameter("@PQF02",SqlDbType.NVarChar),
                new SqlParameter("@PQF03",SqlDbType.NVarChar),
                new SqlParameter("@PQF04",SqlDbType.NVarChar),
                new SqlParameter("@PQF05",SqlDbType.NVarChar),
                new SqlParameter("@PQF06",SqlDbType.BigInt),
                new SqlParameter("@PQF07",SqlDbType.NVarChar),
                new SqlParameter("@PQF08",SqlDbType.NVarChar),
                new SqlParameter("@PQF09",SqlDbType.Decimal),
                new SqlParameter("@PQF10",SqlDbType.Decimal),
                new SqlParameter("@PQF11",SqlDbType.NVarChar),
                new SqlParameter("@PQF12",SqlDbType.NVarChar),
                new SqlParameter("@PQF13",SqlDbType.Date),
                new SqlParameter("@PQF20",SqlDbType.NVarChar),
                new SqlParameter("@PQF21",SqlDbType.NVarChar),
                new SqlParameter("@PQF23",SqlDbType.NVarChar),
                new SqlParameter("@PQF24",SqlDbType.NVarChar),
                new SqlParameter("@PQF29",SqlDbType.VarBinary),
                new SqlParameter("@PQF31",SqlDbType.Date),
                new SqlParameter("@PQF32",SqlDbType.Date),
                new SqlParameter("@PQF34",SqlDbType.Date),
                new SqlParameter("@PQF38",SqlDbType.Decimal),
                new SqlParameter("@PQF41",SqlDbType.NVarChar),
                new SqlParameter("@PQF44",SqlDbType.NVarChar),
                new SqlParameter("@PQF45",SqlDbType.Decimal),
                new SqlParameter("@PQF47",SqlDbType.NVarChar),
                new SqlParameter("@PQF49",SqlDbType.Decimal),
                new SqlParameter("@PQF51",SqlDbType.NVarChar),
                new SqlParameter("@PQF55",SqlDbType.NVarChar),
                new SqlParameter("@PQF56",SqlDbType.Date),
                new SqlParameter("@PQF57",SqlDbType.NVarChar),
                new SqlParameter("@PQF58",SqlDbType.Date),
                new SqlParameter("@PQF59",SqlDbType.NVarChar),
                new SqlParameter("@PQF60",SqlDbType.NVarChar),
                new SqlParameter("@PQF61",SqlDbType.NVarChar),
                new SqlParameter("@PQF62",SqlDbType.VarBinary),
                new SqlParameter("@PQF63",SqlDbType.Date),
                new SqlParameter("@PQF64",SqlDbType.NVarChar),
                new SqlParameter("@PQF65",SqlDbType.NVarChar),
                new SqlParameter("@PQF67",SqlDbType.NVarChar)
            };

            parameter [ 0 ] . Value = model . PQF01;
            parameter [ 1 ] . Value = model . PQF02;
            parameter [ 2 ] . Value = model . PQF03;
            parameter [ 3 ] . Value = model . PQF04;
            parameter [ 4 ] . Value = model . PQF05;
            parameter [ 5 ] . Value = model . PQF06;
            parameter [ 6 ] . Value = model . PQF07;
            parameter [ 7 ] . Value = model . PQF08;
            parameter [ 8 ] . Value = model . PQF09;
            parameter [ 9 ] . Value = model . PQF10;
            parameter [ 10 ] . Value = model . PQF11;
            parameter [ 11 ] . Value = model . PQF12;
            parameter [ 12 ] . Value = model . PQF13;
            parameter [ 13 ] . Value = model . PQF20;
            parameter [ 14 ] . Value = model . PQF21;
            parameter [ 15 ] . Value = model . PQF23;
            parameter [ 16 ] . Value = model . PQF24;
            parameter [ 17 ] . Value = model . PQF29;
            parameter [ 18 ] . Value = model . PQF31;
            parameter [ 19 ] . Value = model . PQF32;
            parameter [ 20 ] . Value = model . PQF34;
            parameter [ 21 ] . Value = model . PQF38;
            parameter [ 22 ] . Value = model . PQF41;
            parameter [ 23 ] . Value = model . PQF44;
            parameter [ 24 ] . Value = model . PQF45;
            parameter [ 25 ] . Value = model . PQF47;
            parameter [ 26 ] . Value = model . PQF49;
            parameter [ 27 ] . Value = model . PQF51;
            parameter [ 28 ] . Value = model . PQF55;
            parameter [ 29 ] . Value = model . PQF56;
            parameter [ 30 ] . Value = model . PQF57;
            parameter [ 31 ] . Value = model . PQF58;
            parameter [ 32 ] . Value = model . PQF59;
            parameter [ 33 ] . Value = model . PQF60;
            parameter [ 34 ] . Value = model . PQF61;
            parameter [ 35 ] . Value = model . PQF62;
            parameter [ 36 ] . Value = model . PQF63;
            parameter [ 37 ] . Value = model . PQF64;
            parameter [ 38 ] . Value = model . PQF65;
            parameter [ 39 ] . Value = model . PQF67;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTabletable ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            //strSql.Append( "SELECT PQF01,PQF56,PQF58,PQF60,PQF61,PQF51,(SELECT DBA002 FROM TPADBA WHERE DBA001=PQF55) AS DBA02,( SELECT DBA002 FROM TPADBA WHERE DBA001 = PQF57 ) AS DBA2, (SELECT DAA002 FROM TPADAA WHERE DAA001 = PQF59 ) AS DAA02,PQF01, PQF02, PQF03, PQF04, PQF05, PQF06, PQF07, PQF08, PQF09, PQF10, DFA003,(SELECT DBA002 FROM TPADBA WHERE DBA001 = PQF12) AS DBA002,PQF13, PQF20, PQF21, PQF17,(SELECT DAA002 FROM TPADAA WHERE DAA001 = PQF17) DAA002, PQF23, PQF24, PQF63, PQF31, PQF32, PQF34, PQF41, PQF47, PQF38, PQF44, PQF45, PQF49,PQF64,PQF65 FROM R_PQF B, TPADFA C WHERE B.PQF11 = C.DFA001 " );
            strSql . Append ( "SELECT PQF01,PQF56,PQF58,PQF60,PQF61,PQF51,(SELECT DBA002 FROM TPADBA WHERE DBA001=PQF55) AS DBA02,( SELECT DBA002 FROM TPADBA WHERE DBA001 = PQF57 ) AS DBA2, (SELECT DAA002 FROM TPADAA WHERE DAA001 = PQF59 ) AS DAA02,PQF01, PQF02, PQF03, PQF04, PQF05, PQF06, PQF07, PQF08, PQF09, PQF10, DFA003,PQF12,PQF67,PQF13, PQF20, PQF21, PQF17,PQF17,PQF66, PQF23, PQF24, PQF63, PQF31, PQF32, PQF34, PQF41, PQF47, PQF38, PQF44, PQF45, PQF49,PQF64,PQF65 FROM R_PQF B, TPADFA C WHERE B.PQF11 = C.DFA001 " );
            strSql .Append( " AND " + strWhere );
            strSql.Append( " ORDER BY B.PQF01 DESC" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public MulaolaoLibrary.SailesLibrary GetModel ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQF" );
            strSql.Append( " WHERE PQF01=@PQF01" );
            SqlParameter[] parameter = {
                new SqlParameter("@PQF01",SqlDbType.NVarChar)
            };

            parameter[0].Value = num;

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
        public MulaolaoLibrary.SailesLibrary GetDataRow ( DataRow row )
        {
            MulaolaoLibrary.SailesLibrary model = new MulaolaoLibrary.SailesLibrary( );
            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    model.IDX = int.Parse( row["idx"].ToString( ) );
                if ( row["PQF01"] != null && row["PQF01"].ToString( ) != "" )
                    model.PQF01 = row["PQF01"].ToString( );
                if ( row["PQF02"] != null && row["PQF02"].ToString( ) != "" )
                    model.PQF02 = row["PQF02"].ToString( );
                if ( row["PQF03"] != null && row["PQF03"].ToString( ) != "" )
                    model.PQF03 = row["PQF03"].ToString( );
                if ( row["PQF04"] != null && row["PQF04"].ToString( ) != "" )
                    model.PQF04 = row["PQF04"].ToString( );
                if ( row["PQF05"] != null && row["PQF05"].ToString( ) != "" )
                    model.PQF05 = row["PQF05"].ToString( );
                if ( row["PQF06"] != null && row["PQF06"].ToString( ) != "" )
                    model.PQF06 = long.Parse( row["PQF06"].ToString( ) );
                if ( row["PQF07"] != null && row["PQF07"].ToString( ) != "" )
                    model.PQF07 = row["PQF07"].ToString( );
                if ( row["PQF08"] != null && row["PQF08"].ToString( ) != "" )
                    model.PQF08 = row["PQF08"].ToString( );
                if ( row["PQF09"] != null && row["PQF09"].ToString( ) != "" )
                    model.PQF09 = decimal.Parse( row["PQF09"].ToString( ) );
                if ( row["PQF10"] != null && row["PQF10"].ToString( ) != "" )
                    model.PQF10 = decimal.Parse( row["PQF10"].ToString( ) );
                if ( row["PQF11"] != null && row["PQF11"].ToString( ) != "" )
                    model.PQF11 = row["PQF11"].ToString( );
                if ( row["PQF12"] != null && row["PQF12"].ToString( ) != "" )
                    model.PQF12 = row["PQF12"].ToString( );
                if ( row["PQF13"] != null && row["PQF13"].ToString( ) != "" )
                    model.PQF13 = DateTime.Parse( row["PQF13"].ToString( ) );
                if ( row["PQF17"] != null && row["PQF17"].ToString( ) != "" )
                    model.PQF17 = row["PQF17"].ToString( );
                if ( row["PQF20"] != null && row["PQF20"].ToString( ) != "" )
                    model.PQF20 = row["PQF20"].ToString( );
                if ( row["PQF20"] != null && row["PQF20"].ToString( ) != "" )
                    model.PQF20 = row["PQF20"].ToString( );
                if ( row["PQF21"] != null && row["PQF21"].ToString( ) != "" )
                    model.PQF21 = row["PQF21"].ToString( );
                if ( row["PQF23"] != null && row["PQF23"].ToString( ) != "" )
                    model.PQF23 = row["PQF23"].ToString( );
                if ( row["PQF24"] != null && row["PQF24"].ToString( ) != "" )
                    model.PQF24 = row["PQF24"].ToString( );
                if ( row["PQF29"] != null && row["PQF29"].ToString( ) != "" )
                    model.PQF29 = ( byte[] ) row["PQF29"];
                if ( row["PQF31"] != null && row["PQF31"].ToString( ) != "" )
                    model.PQF31 = DateTime.Parse( row["PQF31"].ToString( ) );
                if ( row["PQF32"] != null && row["PQF32"].ToString( ) != "" )
                    model.PQF32 = DateTime.Parse( row["PQF32"].ToString( ) );
                if ( row["PQF34"] != null && row["PQF34"].ToString( ) != "" )
                    model.PQF34 = DateTime.Parse( row["PQF34"].ToString( ) );
                if ( row["PQF38"] != null && row["PQF38"].ToString( ) != "" )
                    model.PQF38 = decimal.Parse( row["PQF38"].ToString( ) );
                if ( row["PQF41"] != null && row["PQF41"].ToString( ) != "" )
                    model.PQF41 = row["PQF41"].ToString( );
                if ( row["PQF44"] != null && row["PQF44"].ToString( ) != "" )
                    model.PQF44 = row["PQF44"].ToString( );
                if ( row["PQF45"] != null && row["PQF45"].ToString( ) != "" )
                    model.PQF45 = decimal.Parse( row["PQF45"].ToString( ) );
                if ( row["PQF47"] != null && row["PQF47"].ToString( ) != "" )
                    model.PQF47 = row["PQF47"].ToString( );
                if ( row["PQF49"] != null && row["PQF49"].ToString( ) != "" )
                    model.PQF49 = decimal.Parse( row["PQF49"].ToString( ) );
                if ( row["PQF51"] != null && row["PQF51"].ToString( ) != "" )
                    model.PQF51 = row["PQF51"].ToString( );
                if ( row["PQF55"] != null && row["PQF55"].ToString( ) != "" )
                    model.PQF55 = row["PQF55"].ToString( );
                if ( row["PQF56"] != null && row["PQF56"].ToString( ) != "" )
                    model.PQF56 = DateTime.Parse( row["PQF56"].ToString( ) );
                if ( row["PQF57"] != null && row["PQF57"].ToString( ) != "" )
                    model.PQF57 = row["PQF57"].ToString( );
                if ( row["PQF58"] != null && row["PQF58"].ToString( ) != "" )
                    model.PQF58 = DateTime.Parse( row["PQF58"].ToString( ) );
                if ( row["PQF59"] != null && row["PQF59"].ToString( ) != "" )
                    model.PQF59 = row["PQF59"].ToString( );
                if ( row["PQF60"] != null && row["PQF60"].ToString( ) != "" )
                    model.PQF60 = row["PQF60"].ToString( );
                if ( row["PQF61"] != null && row["PQF61"].ToString( ) != "" )
                    model.PQF61 = row["PQF61"].ToString( );
                if ( row["PQF62"] != null && row["PQF62"].ToString( ) != "" )
                    model.PQF62 = ( byte[] ) row["PQF62"];
                if ( row["PQF63"] != null && row["PQF63"].ToString( ) != "" )
                    model.PQF63 = DateTime.Parse( row["PQF63"].ToString( ) );
                if ( row["PQF64"] != null && row["PQF64"].ToString( ) != "" )
                    model.PQF64 = row["PQF64"].ToString( );
                if ( row["PQF65"] != null && row["PQF65"].ToString( ) != "" )
                    model.PQF65 = row["PQF65"].ToString( );
            }
            return model;
        }

        /// <summary>
        /// 获取数据实体
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTableOther ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            //strSql.Append( "SELECT PQF29,PQF62,(SELECT DBA002 FROM TPADBA WHERE DBA001=PQF55) AS DBA02,(SELECT DBA002 FROM TPADBA WHERE DBA001 = PQF57 ) AS DBA2, (SELECT DAA002 FROM TPADAA WHERE DAA001 = PQF59 ) AS DAA02, DFA003,(SELECT DBA002 FROM TPADBA WHERE DBA001 = PQF12) AS DBA002,(SELECT DAA002 FROM TPADAA WHERE DAA001 = PQF17) DAA002,(SELECT RES05 FROM R_REVIEWS WHERE RES04=(SELECT MAX(RES04) FROM R_REVIEWS WHERE RES06=PQF01 AND RES01='R_001')) RES05 FROM R_PQF B, TPADFA C WHERE B.PQF11 = C.DFA001" );
            strSql . Append ( "SELECT PQF29,PQF62,(SELECT DBA002 FROM TPADBA WHERE DBA001=PQF55) AS DBA02,(SELECT DBA002 FROM TPADBA WHERE DBA001 = PQF57 ) AS DBA2, (SELECT DAA002 FROM TPADAA WHERE DAA001 = PQF59 ) AS DAA02, DFA003,PQF12,PQF67,PQF17,PQF66,(SELECT RES05 FROM R_REVIEWS WHERE RES04=(SELECT MAX(RES04) FROM R_REVIEWS WHERE RES06=PQF01 AND RES01='R_001')) RES05 FROM R_PQF B, TPADFA C WHERE B.PQF11 = C.DFA001" );
            strSql .Append( " AND PQF01=@PQF01" );
            SqlParameter[] parameter = {
                new SqlParameter("@PQF01",SqlDbType.NVarChar)
            };

            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrint ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            //strSql.Append( "SELECT PQF01,PQF02,PQF03,PQF04,PQF05,PQF06,PQF07,PQF08,PQF09,PQF10,CONVERT(varchar(100), PQF13, 102) PQF13,PQF20,PQF21,PQF23, PQF24, CONVERT( varchar( 100 ), PQF63, 102 ) PQF63, CONVERT( varchar( 100 ), PQF31, 102 ) PQF31,CONVERT( varchar( 100 ), PQF32, 102 ) PQF32, CONVERT( varchar( 100 ), PQF34, 102 ) PQF34, CONVERT( varchar( 100 ), PQF56, 102 ) PQF56,CONVERT( varchar( 100 ), PQF58, 102 ) PQF58, PQF60, PQF61, PQF41, PQF47, PQF38, PQF44,PQF45, PQF49, PQF51, DFA003, (SELECT DBA002 FROM TPADBA WHERE DBA001 = PQF12 ) AS DBA002,(SELECT DBA002 FROM TPADBA WHERE DBA001 = PQF55 ) AS DBA02,(SELECT DBA002 FROM TPADBA WHERE DBA001 = PQF57 ) AS DBA2,(SELECT DAA002 FROM TPADAA WHERE DAA001 = PQF17) DAA002,(SELECT DAA002 FROM TPADAA WHERE DAA001 = PQF59 ) AS DAA02 FROM R_PQF B, TPADFA C" );
            strSql . Append ( "SELECT PQF01,PQF02,PQF03,PQF04,PQF05,PQF06,PQF07,PQF08,PQF09,PQF10,CONVERT(varchar(100), PQF13, 102) PQF13,PQF20,PQF21,PQF23, PQF24, CONVERT( varchar( 100 ), PQF63, 102 ) PQF63, CONVERT( varchar( 100 ), PQF31, 102 ) PQF31,CONVERT( varchar( 100 ), PQF32, 102 ) PQF32, CONVERT( varchar( 100 ), PQF34, 102 ) PQF34, CONVERT( varchar( 100 ), PQF56, 102 ) PQF56,CONVERT( varchar( 100 ), PQF58, 102 ) PQF58, PQF60, PQF61, PQF41, PQF47, PQF38, PQF44,PQF45, PQF49, PQF51, DFA003,PQF12,PQF67,(SELECT DBA002 FROM TPADBA WHERE DBA001 = PQF55 ) AS DBA02,(SELECT DBA002 FROM TPADBA WHERE DBA001 = PQF57 ) AS DBA2,PQF17,PQF66,(SELECT DAA002 FROM TPADAA WHERE DAA001 = PQF59 ) AS DAA02 FROM R_PQF B, TPADFA C" );
            strSql .Append( "  WHERE B.PQF11 = C.DFA001 AND PQF01=@PQF01" );
            SqlParameter[] parameter = {
                new SqlParameter("@PQF01",SqlDbType.NVarChar)
            };

            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTableExport ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT PQF01,PQF03,PQF04,PQF05,PQF06,PQF09,CONVERT(varchar(100), PQF31, 102) PQF31,PQF06*PQF09 PQF999 FROM R_PQF" );
            strSql.Append( " WHERE PQF02=@PQF02" );
            SqlParameter[] parameter = {
                new SqlParameter("@PQF02",SqlDbType.NVarChar)
            };

            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取客户名称
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableCustomer ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DFA001,DFA003 FROM TPADFA ORDER BY DFA003" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取业务部名称
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableBusiness ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DBA001,DBA002 FROM TPADBA WHERE DBA005=(SELECT DAA001 FROM TPADAA WHERE DAA002='业务部')  AND (DBA043='F' OR DBA043='' OR DBA043 IS NULL)" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取制单人员
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableSingle ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DBA001,DBA002 FROM TPADBA WHERE DBA001 IN (SELECT DISTINCT DBB001 FROM R_DBB) AND (DBA043='F' OR DBA043='' OR DBA043 IS NULL) ORDER BY DBA002" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取生产部门
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableWork ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DAA001,DAA002 FROM TPADAA WHERE DAA002 IN (SELECT DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002 IN (SELECT DBA002 FROM TPADBA WHERE DBA005=(SELECT DAA001 FROM TPADAA WHERE DAA002='生产部'))  AND (DBA043='F' OR DBA043='' OR DBA043 IS NULL) )) UNION SELECT DAA001,DAA002 FROM TPADAA WHERE DAA001 LIKE '13%'" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取销售部
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableSail ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DAA001,DAA002 FROM TPADAA" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableAll ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT PQF02,PQF03,PQF04,PQF05,PQF07,PQF08,PQF21,PQF47,PQF44,PQF20,PQF60 FROM R_PQF" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 写入数据到250
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool WriteToDaily ( string num )
        {
            int row = 0;
            DataTable da = GetDataTableOf( num );
            if ( da != null && da.Rows.Count > 0 )
            {
                //AE26=0:开票数量  AE37=0:发货数量  AE38=0:客检数量  AE22:实际收款日期
                //WHERE AE02=@AE02 AND AE26=0 AND AE37=0 AND AE38=0 AND AE22 IS NULL  2018-5-30  王军要求变更，去掉前面的条件
                StringBuilder strSql = new StringBuilder( );
                strSql.Append( "SELECT COUNT(1) FROM R_PQAE WHERE AE02=@AE02 " );
                SqlParameter[] parameter = {
                new SqlParameter("@AE02",SqlDbType.NVarChar,20)
                };
                parameter[0].Value = num;

                if ( SqlHelper.Exists( strSql.ToString( ) ,parameter ) == false )
                    row = AddOf( da ,row );
                else
                    row = UpdateOf( da ,row );
            }

            if ( row > 0 )
                return true;
            else
                return false;
        }

        DataTable GetDataTableOf ( string num )
        {
            StringBuilder strSq = new StringBuilder( );
            strSq.Append( "SELECT DISTINCT PQF01,PQF02,PQF03,PQF04,PQF06,PQF10,DFA003,DAA002,DBA002,PQF10,PQF45,PQF09,PQF23,PQF13,CONVERT(VARCHAR(100), (SELECT RES04 FROM R_REVIEWS B WHERE A.PQF01=B.RES06 AND RES05='执行'),23) RES4,CONVERT(VARCHAR(20),B.RES04,23) RES04,PQF31,PQF34,CONVERT(DECIMAL(18,2),CASE WHEN PQF09=0 THEN PQF10*PQF45*PQF06 ELSE PQF09*PQF06 END) AE19,PQF46 AE20 FROM R_PQF A LEFT JOIN TPADFA ON PQF11  = DFA001 LEFT JOIN TPADAA ON DAA001 = PQF17 LEFT JOIN TPADBA ON DBA001 = PQF12 INNER JOIN R_REVIEWS ON PQF01=RES06 AND RES05='执行' LEFT JOIN (SELECT RES04,HT01,HT02 FROM R_PQL A LEFT JOIN R_REVIEWS B ON A.HT64=B.RES06 AND RES05='执行') B ON A.PQF01=B.HT01 AND A.PQF02=B.HT02" );
            strSq.Append( " WHERE PQF01=@PQF01" );
            SqlParameter[] paramete = {
                    new SqlParameter("@PQF01",SqlDbType.NVarChar,20)
                };
            paramete[0].Value = num;
            DataTable da = SqlHelper.ExecuteDataTable( strSq.ToString( ) ,paramete );

            return da;
        }

        int AddOf (DataTable da,int row )
        {
            MulaolaoLibrary.DailyCollectionRecordLibrary model = new MulaolaoLibrary.DailyCollectionRecordLibrary( );
            model.AE02 = da.Rows[0]["PQF01"].ToString( );
            model.AE03 = da.Rows[0]["PQF04"].ToString( );
            model.AE04 = da.Rows[0]["PQF02"].ToString( );
            model.AE05 = da.Rows[0]["PQF03"].ToString( );
            model.AE06 = string.IsNullOrEmpty( da.Rows[0]["PQF06"].ToString( ) ) == true ? 0 : Convert.ToInt64( da.Rows[0]["PQF06"].ToString( ) );
            model.AE07 = da.Rows[0]["DFA003"].ToString( );
            model.AE08 = da.Rows[0]["DAA002"].ToString( );
            model.AE09 = da.Rows[0]["DBA002"].ToString( );
            model.AE10 = string.IsNullOrEmpty( da.Rows[0]["PQF10"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["PQF10"].ToString( ) );
            model.AE11 = string.IsNullOrEmpty( da.Rows[0]["PQF45"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["PQF45"].ToString( ) );
            model.AE12 = string.IsNullOrEmpty( da.Rows[0]["PQF09"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["PQF09"].ToString( ) );
            model.AE13 = da.Rows[0]["PQF23"].ToString( );
            model.AE14 = string.IsNullOrEmpty( da.Rows[0]["PQF13"].ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( da.Rows[0]["PQF13"].ToString( ) );
            model.AE15 = string.IsNullOrEmpty( da.Rows[0]["RES4"].ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( da.Rows[0]["RES4"].ToString( ) );
            model.AE16 = string.IsNullOrEmpty( da.Rows[0]["RES04"].ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( da.Rows[0]["RES04"].ToString( ) );
            model.AE17 = string.IsNullOrEmpty( da.Rows[0]["PQF31"].ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( da.Rows[0]["PQF31"].ToString( ) );
            model.AE18 = string.IsNullOrEmpty( da.Rows[0]["PQF34"].ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( da.Rows[0]["PQF34"].ToString( ) );
            model.AE19 = string.IsNullOrEmpty( da.Rows[0]["AE19"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AE19"].ToString( ) );
            model.AE20 = 0;
            model.AE01 = generateOddNum.purchaseContract( "SELECT MAX(AE01) AE01 FROM R_PQAE" ,"AE01" ,"R_250-" );
            StringBuilder strS = new StringBuilder( );
            strS.Append( "INSERT INTO R_PQAE (AE01,AE02,AE03,AE04,AE05,AE06,AE07,AE08,AE09,AE10,AE11,AE12,AE13,AE14,AE15,AE16,AE17,AE18,AE19,AE20) VALUES (@AE01,@AE02,@AE03,@AE04,@AE05,@AE06,@AE07,@AE08,@AE09,@AE10,@AE11,@AE12,@AE13,@AE14,@AE15,@AE16,@AE17,@AE18,@AE19,@AE20)" );
            SqlParameter[] para = {
                        new SqlParameter("@AE01",SqlDbType.NVarChar),
                        new SqlParameter("@AE02",SqlDbType.NVarChar),
                        new SqlParameter("@AE03",SqlDbType.NVarChar),
                        new SqlParameter("@AE04",SqlDbType.NVarChar),
                        new SqlParameter("@AE05",SqlDbType.NVarChar),
                        new SqlParameter("@AE06",SqlDbType.BigInt),
                        new SqlParameter("@AE07",SqlDbType.NVarChar),
                        new SqlParameter("@AE08",SqlDbType.NVarChar),
                        new SqlParameter("@AE09",SqlDbType.NVarChar),
                        new SqlParameter("@AE10",SqlDbType.Decimal),
                        new SqlParameter("@AE11",SqlDbType.Decimal),
                        new SqlParameter("@AE12",SqlDbType.Decimal),
                        new SqlParameter("@AE13",SqlDbType.NChar),
                        new SqlParameter("@AE14",SqlDbType.Date),
                        new SqlParameter("@AE15",SqlDbType.Date),
                        new SqlParameter("@AE16",SqlDbType.Date),
                        new SqlParameter("@AE17",SqlDbType.Date),
                        new SqlParameter("@AE18",SqlDbType.Date),
                        new SqlParameter("@AE19",SqlDbType.Decimal),
                        new SqlParameter("@AE20",SqlDbType.Decimal)
                    };
            para[0].Value = model.AE01;
            para[1].Value = model.AE02;
            para[2].Value = model.AE03;
            para[3].Value = model.AE04;
            para[4].Value = model.AE05;
            para[5].Value = model.AE06;
            para[6].Value = model.AE07;
            para[7].Value = model.AE08;
            para[8].Value = model.AE09;
            para[9].Value = model.AE10;
            para[10].Value = model.AE11;
            para[11].Value = model.AE12;
            para[12].Value = model.AE13;
            para[13].Value = model.AE14;
            para[14].Value = model.AE15;
            para[15].Value = model.AE16;
            para[16].Value = model.AE17;
            para[17].Value = model.AE18;
            para[18].Value = model.AE19;
            para[19].Value = model.AE20;

            row = SqlHelper.ExecuteNonQuery( strS.ToString( ) ,para );
            return row;
        }

        int UpdateOf ( DataTable da ,int row )
        {
            MulaolaoLibrary.DailyCollectionRecordLibrary model = new MulaolaoLibrary.DailyCollectionRecordLibrary( );
            model.AE02 = da.Rows[0]["PQF01"].ToString( );
            model.AE03 = da.Rows[0]["PQF04"].ToString( );
            model.AE04 = da.Rows[0]["PQF02"].ToString( );
            model.AE05 = da.Rows[0]["PQF03"].ToString( );
            model.AE06 = string.IsNullOrEmpty( da.Rows[0]["PQF06"].ToString( ) ) == true ? 0 : Convert.ToInt64( da.Rows[0]["PQF06"].ToString( ) );
            model.AE07 = da.Rows[0]["DFA003"].ToString( );
            model.AE08 = da.Rows[0]["DAA002"].ToString( );
            model.AE09 = da.Rows[0]["DBA002"].ToString( );
            model.AE10 = string.IsNullOrEmpty( da.Rows[0]["PQF10"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["PQF10"].ToString( ) );
            model.AE11 = string.IsNullOrEmpty( da.Rows[0]["PQF45"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["PQF45"].ToString( ) );
            model.AE12 = string.IsNullOrEmpty( da.Rows[0]["PQF09"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["PQF09"].ToString( ) );
            model.AE13 = da.Rows[0]["PQF23"].ToString( );
            model.AE14 = string.IsNullOrEmpty( da.Rows[0]["PQF13"].ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( da.Rows[0]["PQF13"].ToString( ) );
            model.AE15 = string.IsNullOrEmpty( da.Rows[0]["RES4"].ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( da.Rows[0]["RES4"].ToString( ) );
            model.AE16 = string.IsNullOrEmpty( da.Rows[0]["RES04"].ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( da.Rows[0]["RES04"].ToString( ) );
            model.AE17 = string.IsNullOrEmpty( da.Rows[0]["PQF31"].ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( da.Rows[0]["PQF31"].ToString( ) );
            model.AE18 = string.IsNullOrEmpty( da.Rows[0]["PQF34"].ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( da.Rows[0]["PQF34"].ToString( ) );
            model.AE19 = string.IsNullOrEmpty( da.Rows[0]["AE19"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AE19"].ToString( ) );
            model.AE20 = 0;
            //model.AE01 = generateOddNum.purchaseContract( "SELECT MAX(AE01) AE01 FROM R_PQAE" ,"AE01" ,"R_250-" );
            StringBuilder strS = new StringBuilder( );
            strS.Append( "UPDATE R_PQAE SET " );
            strS.Append( "AE03=@AE03," );
            strS.Append( "AE04=@AE04," );
            strS.Append( "AE05=@AE05," );
            strS.Append( "AE06=@AE06," );
            strS.Append( "AE07=@AE07," );
            strS.Append( "AE08=@AE08," );
            strS.Append( "AE09=@AE09," );
            strS.Append( "AE10=@AE10," );
            strS.Append( "AE11=@AE11," );
            strS.Append( "AE12=@AE12," );
            strS.Append( "AE13=@AE13," );
            strS.Append( "AE14=@AE14," );
            strS.Append( "AE15=@AE15," );
            strS.Append( "AE16=@AE16," );
            strS.Append( "AE17=@AE17," );
            strS.Append( "AE18=@AE18," );
            strS.Append( "AE19=@AE19," );
            strS.Append( "AE20=@AE20" );
            strS.Append( " WHERE AE02=@AE02" );
            SqlParameter[] para = {
                        new SqlParameter("@AE03",SqlDbType.NVarChar),
                        new SqlParameter("@AE04",SqlDbType.NVarChar),
                        new SqlParameter("@AE05",SqlDbType.NVarChar),
                        new SqlParameter("@AE06",SqlDbType.BigInt),
                        new SqlParameter("@AE07",SqlDbType.NVarChar),
                        new SqlParameter("@AE08",SqlDbType.NVarChar),
                        new SqlParameter("@AE09",SqlDbType.NVarChar),
                        new SqlParameter("@AE10",SqlDbType.Decimal),
                        new SqlParameter("@AE11",SqlDbType.Decimal),
                        new SqlParameter("@AE12",SqlDbType.Decimal),
                        new SqlParameter("@AE13",SqlDbType.NChar),
                        new SqlParameter("@AE14",SqlDbType.Date),
                        new SqlParameter("@AE15",SqlDbType.Date),
                        new SqlParameter("@AE16",SqlDbType.Date),
                        new SqlParameter("@AE17",SqlDbType.Date),
                        new SqlParameter("@AE18",SqlDbType.Date),
                        new SqlParameter("@AE19",SqlDbType.Decimal),
                        new SqlParameter("@AE20",SqlDbType.Decimal),
                        new SqlParameter("@AE02",SqlDbType.NVarChar)
                    };
            para[0].Value = model.AE03;
            para[1].Value = model.AE04;
            para[2].Value = model.AE05;
            para[3].Value = model.AE06;
            para[4].Value = model.AE07;
            para[5].Value = model.AE08;
            para[6].Value = model.AE09;
            para[7].Value = model.AE10;
            para[8].Value = model.AE11;
            para[9].Value = model.AE12;
            para[10].Value = model.AE13;
            para[11].Value = model.AE14;
            para[12].Value = model.AE15;
            para[13].Value = model.AE16;
            para[14].Value = model.AE17;
            para[15].Value = model.AE18;
            para[16].Value = model.AE19;
            para[17].Value = model.AE20;
            para[18].Value = model.AE02;

            row = SqlHelper.ExecuteNonQuery( strS.ToString( ) ,para );
            return row;
        }

    }
}

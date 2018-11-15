using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;
using StudentMgr;
using System . Data . SqlClient;
using System . Collections;

namespace MulaolaoBll . Dao
{
    public class InvenAdSheetDao
    {
        /// <summary>
        /// 获取单号
        /// </summary>
        /// <returns></returns>
        public string getCode ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(INA001) INA001 FROM R_INA" );

            DataTable table = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );

            DateTime dt = Drity . GetDt ( );

            if ( table == null || table . Rows . Count < 1 )
                return dt . ToString ( "yyyyMMdd" ) + "001";
            else
            {
                string code = table . Rows [ 0 ] [ "INA001" ] . ToString ( );
                if ( string . IsNullOrEmpty ( code ) )
                    return dt . ToString ( "yyyyMMdd" ) + "001";
                else if ( code . Substring ( 0 ,8 ) . Equals ( dt . ToString ( "yyyyMMdd" ) ) )
                    return ( Convert . ToInt64 ( code ) + 1 ) . ToString ( );
                else
                    return dt . ToString ( "yyyyMMdd" ) + "001";
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Delete ( string code )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM R_INA WHERE INA001='{0}'" ,code );

            int rows= SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            return rows > 0 ? true : false;
        }

        /// <summary>
        /// 查询入库记录
        /// </summary>
        /// <param name="codeForRK"></param>
        /// <returns></returns>
        public DataTable getTableRK (   )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT AC01,AC02,AC03+ISNULL(AC26,0) AC03,AC04,AC05,AC06,CONVERT(FLOAT,CONVERT(DECIMAL(18,2),AC07)) AC07,CONVERT(FLOAT,AC09) AC09,CONVERT(FLOAT,AC10+ISNULL(AC27,0)) AC10,AC11,AC12,AC13,AC14,AC15,AC18,AC16,AC19,AC20,AC21,AC22,CONVERT(FLOAT,CONVERT(DECIMAL(18,4),AC10+ISNULL(AC27,0)-SUM(ISNULL(AD12,0)+ISNULL(AD21,0)))) AD,AC24,AC25 FROM R_PQAC A LEFT JOIN R_PQAD B ON A.AC18=B.AD01 GROUP BY AC01,AC02,AC03,AC04,AC05,AC06,AC07,AC09,AC10,AC11,AC12,AC13,AC14,AC15,AC18,AC16,AC19,AC20,AC21,AC22,AC24,AC25,ISNULL(AC26,0),ISNULL(AC27,0)" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 查询出库记录
        /// </summary>
        /// <param name="codeForCK"></param>
        /// <returns></returns>
        public DataTable getTableCK ( string code )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT A.idx,AD01,AD04,AD02,AD03,AD05+ISNULL(AD20,0) AD05,AD06,AD07,AD08,CONVERT(FLOAT,AD09) AD09,CONVERT(FLOAT,AD11) AD11,CONVERT(FLOAT,AD12+ISNULL(AD21,0)) AD12,AD13,AD14,AD17,CONVERT(FLOAT,AC10+ISNULL(AC27,0)) AC10,CONVERT(FLOAT,AC03+ISNULL(AC26,0)) AC03,CONVERT(FLOAT,AC09) AC09,AC10+ISNULL(AC27,0)-ISNULL((SELECT SUM(AD12+ISNULL(AD21,0)) FROM R_PQAD WHERE idx<=A.idx AND AD01='{0}'),0) U1,CASE WHEN AC10+ISNULL(AC27,0)=0 THEN 0 ELSE (AC03+ISNULL(AC26,0))/(AC10+ISNULL(AC27,0))*(AC10+ISNULL(AC27,0)-ISNULL((SELECT SUM(AD12+ISNULL(AD21,0)) FROM R_PQAD WHERE idx<=A.idx AND AD01='{0}'),0)) END U2,AD18,AD19 FROM R_PQAD A,R_PQAC B WHERE A.AD01=B.AC18 AND AD01='{0}' ORDER BY A.AD16,AD17" ,code );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="table"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add ( DataTable table ,MulaolaoLibrary . InvenAdSheetINAEntity model )
        {
            Dictionary<object ,object> SQLString = new Dictionary<object ,object> ( );
            model . INA001 = getCode ( );
            addHeader ( model ,SQLString );

            MulaolaoLibrary . InvenAdSheetINBEntity body = new MulaolaoLibrary . InvenAdSheetINBEntity ( );
            body . INB001 = model . INA001;
            foreach ( DataRow row in table . Rows )
            {
                body . INB002 = row [ "INB002" ] . ToString ( );
                body . INB003 = row [ "INB003" ] . ToString ( );
                body . INB004 = row [ "INB004" ] . ToString ( );
                body . INB005 = row [ "INB005" ] . ToString ( );
                body . INB006 = row [ "INB006" ] . ToString ( );
                body . INB007 = string . IsNullOrEmpty ( row [ "INB007" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "INB007" ] );
                body . INB008 = row [ "INB008" ] . ToString ( );
                body . INB009 = row [ "INB009" ] . ToString ( );
                body . INB010 = string . IsNullOrEmpty ( row [ "INB010" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "INB010" ] );
                body . INB011 = string . IsNullOrEmpty ( row [ "INB011" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "INB011" ] );
                body . INB012 = string . IsNullOrEmpty ( row [ "INB012" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "INB012" ] );
                body . INB013 = string . IsNullOrEmpty ( row [ "INB013" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "INB013" ] );
                body . INB014 = row [ "INB014" ] . ToString ( );
                body . INB015 = string . IsNullOrEmpty ( row [ "INB015" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "INB015" ] );
                body . INB016 = row [ "INB016" ] . ToString ( );
                addBody ( body ,SQLString );
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="table"></param>
        /// <param name="model"></param>
        /// <param name="strList"></param>
        /// <returns></returns>
        public bool Edit ( DataTable table ,MulaolaoLibrary . InvenAdSheetINAEntity model,List<string> strList )
        {
            Dictionary<object ,object> SQLString = new Dictionary<object ,object> ( );
            editHeader ( model ,SQLString );

            MulaolaoLibrary . InvenAdSheetINBEntity body = new MulaolaoLibrary . InvenAdSheetINBEntity ( );
            body . INB001 = model . INA001;
            foreach ( DataRow row in table . Rows )
            {
                body . id = string . IsNullOrEmpty ( row [ "id" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "id" ] );
                body . INB002 = row [ "INB002" ] . ToString ( );
                body . INB003 = row [ "INB003" ] . ToString ( );
                body . INB004 = row [ "INB004" ] . ToString ( );
                body . INB005 = row [ "INB005" ] . ToString ( );
                body . INB006 = row [ "INB006" ] . ToString ( );
                body . INB007 = string . IsNullOrEmpty ( row [ "INB007" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "INB007" ] );
                body . INB008 = row [ "INB008" ] . ToString ( );
                body . INB009 = row [ "INB009" ] . ToString ( );
                body . INB010 = string . IsNullOrEmpty ( row [ "INB010" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "INB010" ] );
                body . INB011 = string . IsNullOrEmpty ( row [ "INB011" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "INB011" ] );
                body . INB012 = string . IsNullOrEmpty ( row [ "INB012" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "INB012" ] );
                body . INB013 = string . IsNullOrEmpty ( row [ "INB013" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "INB013" ] );
                body . INB014 = row [ "INB014" ] . ToString ( );
                body . INB015 = string . IsNullOrEmpty ( row [ "INB015" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "INB015" ] );
                body . INB016 = row [ "INB016" ] . ToString ( );
                if ( body . id <= 1 )
                    addBody ( body ,SQLString );
                else
                    editBody ( body ,SQLString );
            }

            foreach ( string s in strList )
            {
                deleteBody ( s ,SQLString );
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void addHeader ( MulaolaoLibrary . InvenAdSheetINAEntity model ,Dictionary<object ,object> SQLString )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_INA(" );
            strSql . Append ( "INA001,INA003,INA004,INA005)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@INA001,@INA003,@INA004,@INA005)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@INA001", SqlDbType.NVarChar,20),
                    new SqlParameter("@INA003", SqlDbType.NVarChar,20),
                    new SqlParameter("@INA004", SqlDbType.Date,3),
                    new SqlParameter("@INA005", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = model . INA001;
            parameters [ 1 ] . Value = model . INA003;
            parameters [ 2 ] . Value = model . INA004;
            parameters [ 3 ] . Value = model . INA005;
            SQLString . Add ( strSql ,parameters );
        }
        void editHeader ( MulaolaoLibrary . InvenAdSheetINAEntity model ,Dictionary<object ,object> SQLString )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_INA SET " );
            strSql . Append ( "INA003=@INA003 " );
            strSql . Append ( " WHERE INA001=@INA001" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@INA001", SqlDbType.NVarChar,20),
                    new SqlParameter("@INA003", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = model . INA001;
            parameters [ 1 ] . Value = model . INA003;
            SQLString . Add ( strSql ,parameters );
        }

        void addBody ( MulaolaoLibrary . InvenAdSheetINBEntity model ,Dictionary<object ,object> SQLString )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_INB(" );
            strSql . Append ( "INB001,INB002,INB003,INB004,INB005,INB006,INB007,INB008,INB009,INB010,INB011,INB012,INB013,INB014,INB015,INB016)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@INB001,@INB002,@INB003,@INB004,@INB005,@INB006,@INB007,@INB008,@INB009,@INB010,@INB011,@INB012,@INB013,@INB014,@INB015,@INB016)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@INB001", SqlDbType.NVarChar,20),
                    new SqlParameter("@INB002", SqlDbType.NVarChar,20),
                    new SqlParameter("@INB003", SqlDbType.NVarChar,100),
                    new SqlParameter("@INB004", SqlDbType.NVarChar,20),
                    new SqlParameter("@INB005", SqlDbType.NVarChar,50),
                    new SqlParameter("@INB006", SqlDbType.NVarChar,50),
                    new SqlParameter("@INB007", SqlDbType.Decimal,9),
                    new SqlParameter("@INB008", SqlDbType.NVarChar,50),
                    new SqlParameter("@INB009", SqlDbType.NVarChar,50),
                    new SqlParameter("@INB010", SqlDbType.Decimal,9),
                    new SqlParameter("@INB011", SqlDbType.Decimal,9),
                    new SqlParameter("@INB012", SqlDbType.Decimal,9),
                    new SqlParameter("@INB013", SqlDbType.Decimal,9),
                    new SqlParameter("@INB014", SqlDbType.NVarChar,5),
                    new SqlParameter("@INB015", SqlDbType.NChar,10),
                    new SqlParameter("@INB016", SqlDbType.NVarChar,5)
            };
            parameters [ 0 ] . Value = model . INB001;
            parameters [ 1 ] . Value = model . INB002;
            parameters [ 2 ] . Value = model . INB003;
            parameters [ 3 ] . Value = model . INB004;
            parameters [ 4 ] . Value = model . INB005;
            parameters [ 5 ] . Value = model . INB006;
            parameters [ 6 ] . Value = model . INB007;
            parameters [ 7 ] . Value = model . INB008;
            parameters [ 8 ] . Value = model . INB009;
            parameters [ 9 ] . Value = model . INB010;
            parameters [ 10 ] . Value = model . INB011;
            parameters [ 11 ] . Value = model . INB012;
            parameters [ 12 ] . Value = model . INB013;
            parameters [ 13 ] . Value = model . INB014;
            parameters [ 14 ] . Value = model . INB015;
            parameters [ 15 ] . Value = model . INB016;
            SQLString . Add ( strSql ,parameters );
        }
        void editBody ( MulaolaoLibrary . InvenAdSheetINBEntity model ,Dictionary<object ,object> SQLString )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "update R_INB set " );
            strSql . Append ( "INB001=@INB001," );
            strSql . Append ( "INB002=@INB002," );
            strSql . Append ( "INB003=@INB003," );
            strSql . Append ( "INB004=@INB004," );
            strSql . Append ( "INB005=@INB005," );
            strSql . Append ( "INB006=@INB006," );
            strSql . Append ( "INB007=@INB007," );
            strSql . Append ( "INB008=@INB008," );
            strSql . Append ( "INB009=@INB009," );
            strSql . Append ( "INB010=@INB010," );
            strSql . Append ( "INB011=@INB011," );
            strSql . Append ( "INB012=@INB012," );
            strSql . Append ( "INB013=@INB013," );
            strSql . Append ( "INB014=@INB014," );
            strSql . Append ( "INB015=@INB015," );
            strSql . Append ( "INB016=@INB016" );
            strSql . Append ( " where id=@id" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@INB001", SqlDbType.NVarChar,20),
                    new SqlParameter("@INB002", SqlDbType.NVarChar,20),
                    new SqlParameter("@INB003", SqlDbType.NVarChar,100),
                    new SqlParameter("@INB004", SqlDbType.NVarChar,20),
                    new SqlParameter("@INB005", SqlDbType.NVarChar,50),
                    new SqlParameter("@INB006", SqlDbType.NVarChar,50),
                    new SqlParameter("@INB007", SqlDbType.Decimal,9),
                    new SqlParameter("@INB008", SqlDbType.NVarChar,50),
                    new SqlParameter("@INB009", SqlDbType.NVarChar,50),
                    new SqlParameter("@INB010", SqlDbType.Decimal,9),
                    new SqlParameter("@INB011", SqlDbType.Decimal,9),
                    new SqlParameter("@INB012", SqlDbType.Decimal,9),
                    new SqlParameter("@INB013", SqlDbType.Decimal,9),
                    new SqlParameter("@INB014", SqlDbType.NVarChar,5),
                    new SqlParameter("@INB015", SqlDbType.NChar,10),
                    new SqlParameter("@INB016", SqlDbType.NVarChar,5),
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters [ 0 ] . Value = model . INB001;
            parameters [ 1 ] . Value = model . INB002;
            parameters [ 2 ] . Value = model . INB003;
            parameters [ 3 ] . Value = model . INB004;
            parameters [ 4 ] . Value = model . INB005;
            parameters [ 5 ] . Value = model . INB006;
            parameters [ 6 ] . Value = model . INB007;
            parameters [ 7 ] . Value = model . INB008;
            parameters [ 8 ] . Value = model . INB009;
            parameters [ 9 ] . Value = model . INB010;
            parameters [ 10 ] . Value = model . INB011;
            parameters [ 11 ] . Value = model . INB012;
            parameters [ 12 ] . Value = model . INB013;
            parameters [ 13 ] . Value = model . INB014;
            parameters [ 14 ] . Value = model . INB015;
            parameters [ 15 ] . Value = model . INB016;
            parameters [ 16 ] . Value = model . id;
            SQLString . Add ( strSql ,parameters );
        }

        void deleteBody ( string s ,Dictionary<object ,object> SQLString )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM R_INB WHERE id={0}" ,s );
            SQLString . Add ( strSql ,null );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable getTableView ( string code )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "select id,INB001,INB002,INB003,INB004,INB005,INB006,INB007,INB008,INB009,INB010,INB011,INB012,INB013,INB014,INB015,INB016 from R_INB where  INB001='{0}'" ,code );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取查询数据
        /// </summary>
        /// <returns></returns>
        public DataTable getTableQuery ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT INA001,INA003,INA004,INA005,(SELECT RES05 FROM R_REVIEWS WHERE RES04=(SELECT MAX(RES04) FROM R_REVIEWS WHERE RES06=INA001)) RES05 FROM R_INA ORDER BY INA001 DESC" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 回写数据到464中
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool writeTo ( string code )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT A.INB002,A.INB003,INA003,SUM(CONVERT(FLOAT,INB014+CONVERT(NVARCHAR,INB013))) INB013,SUM(CONVERT(FLOAT,INB016+CONVERT(NVARCHAR,INB015))) INB015 FROM R_INB A INNER JOIN (SELECT INB002,INB003,INA003 FROM R_INA A INNER JOIN R_INB B ON A.INA001=B.INB001 WHERE INA001='{0}') B ON A.INB002=B.INB002 AND A.INB003=B.INB003 GROUP BY A.INB002,A.INB003,INA003" ,code );

            DataTable table = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( table == null || table . Rows . Count < 1 )
                return true;
            else
            {
                MulaolaoLibrary . InvenAdSheetINBEntity model = new MulaolaoLibrary . InvenAdSheetINBEntity ( );
                foreach ( DataRow row in table . Rows )
                {
                    model . INB001 = row [ "INA003" ] . ToString ( );
                    model . INB002 = row [ "INB002" ] . ToString ( );
                    model . INB003 = row [ "INB003" ] . ToString ( );
                    model . INB007 = string . IsNullOrEmpty ( row [ "INB015" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "INB015" ] );
                    model . INB012 = string . IsNullOrEmpty ( row [ "INB013" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "INB013" ] );
                    if ( model . INB001 . Equals ( "入库" ) )
                        editRK ( SQLString ,model );
                    else
                        editCK ( SQLString ,model );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void editRK ( Hashtable SQLString ,MulaolaoLibrary . InvenAdSheetINBEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQAC SET " );
            strSql . Append ( "AC26=@AC26," );
            strSql . Append ( "AC27=@AC27 " );
            strSql . Append ( "WHERE AC18=@AC18 AND AC16=@AC16 " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@AC16",SqlDbType.NVarChar),
                new SqlParameter("@AC18",SqlDbType.NVarChar),
                new SqlParameter("@AC26",SqlDbType.Decimal),
                new SqlParameter("@AC27",SqlDbType.Decimal)
            };
            parameter [ 0 ] . Value = model . INB003;
            parameter [ 1 ] . Value = model . INB002;
            parameter [ 2 ] . Value = model . INB007;
            parameter [ 3 ] . Value = model . INB012;

            SQLString . Add ( strSql ,parameter );
        }
        void editCK ( Hashtable SQLString ,MulaolaoLibrary . InvenAdSheetINBEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQAD SET " );
            strSql . Append ( "AD20=@AD20," );
            strSql . Append ( "AD21=@AD21 " );
            strSql . Append ( "WHERE AD01=@AD01 AND AD17=@AD17 " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@AD01",SqlDbType.NVarChar),
                new SqlParameter("@AD17",SqlDbType.NVarChar),
                new SqlParameter("@AD20",SqlDbType.Decimal),
                new SqlParameter("@AD21",SqlDbType.Decimal)
            };
            parameter [ 0 ] . Value = model . INB002;
            parameter [ 1 ] . Value = model . INB003;
            parameter [ 2 ] . Value = model . INB007;
            parameter [ 3 ] . Value = model . INB012;

            SQLString . Add ( strSql ,parameter );
        }
    }
}

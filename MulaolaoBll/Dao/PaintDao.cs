using System . Text;
using StudentMgr;
using System . Data;
using System . Collections;
using System;
using System . Data . SqlClient;

namespace MulaolaoBll . Dao
{
    public class PaintDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTableView ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT idx,ED001,ED002,ED003,ED004,ED005,ED006,ED007,ED008,ED009,ED010,ED011,ED024,ED025,ED029,ED030 FROM R_PQED WHERE {0}" ,strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Edit ( DataTable table )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            MulaolaoLibrary . PaintEntity _model = new MulaolaoLibrary . PaintEntity ( );

            if ( table != null && table . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < table . Rows . Count ; i++ )
                {
                    _model . ED002 = table . Rows [ i ] [ "ED002" ] . ToString ( );
                    _model . ED024 = string . IsNullOrEmpty ( table . Rows [ i ] [ "ED024" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "ED024" ] . ToString ( ) );
                    _model . ED025 = string . IsNullOrEmpty ( table . Rows [ i ] [ "ED025" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "ED025" ] . ToString ( ) );
                    _model . ED029 = table . Rows [ i ] [ "ED029" ] . ToString ( );
                    _model . ED030 = table . Rows [ i ] [ "ED030" ] . ToString ( );

                    editAll ( SQLString ,strSql ,_model );
                }
            }
            else
                return false;

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void editAll ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . PaintEntity _model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQED SET " );
            strSql . Append ( "ED024=@ED024," );
            strSql . Append ( "ED025=@ED025," );
            strSql . Append ( "ED029=@ED029," );
            strSql . Append ( "ED030=@ED030 " );
            strSql . Append ( "WHERE ED002=@ED002 " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@ED002",SqlDbType.NVarChar,50),
                new SqlParameter("@ED024",SqlDbType.Decimal,18),
                new SqlParameter("@ED025",SqlDbType.Decimal,18),
                new SqlParameter("@ED029",SqlDbType.NVarChar,50),
                new SqlParameter("@ED030",SqlDbType.NVarChar,255)
            };
            parameter [ 0 ] . Value = _model . ED002;
            parameter [ 1 ] . Value = _model . ED024;
            parameter [ 2 ] . Value = _model . ED025;
            parameter [ 3 ] . Value = _model . ED029;
            parameter [ 4 ] . Value = _model . ED030;

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 生成
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool Save ( string strWhere )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            MulaolaoLibrary . PaintEntity _model = new MulaolaoLibrary . PaintEntity ( );

            DataTable table = getGun ( strWhere );
            if ( table != null && table . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < table . Rows . Count ; i++ )
                {
                    _model . ED001 = table . Rows [ i ] [ "AM003" ] . ToString ( );
                    _model . ED002 = table . Rows [ i ] [ "AM002" ] . ToString ( );
                    _model . ED003 = table . Rows [ i ] [ "AM005" ] . ToString ( );
                    _model . ED004 = string . IsNullOrEmpty ( table . Rows [ i ] [ "AM006" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "AM006" ] . ToString ( ) );
                    if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "PQF31" ] . ToString ( ) ) )
                        _model . ED005 = null;
                    else
                        _model . ED005 = Convert . ToDateTime ( table . Rows [ i ] [ "PQF31" ] . ToString ( ) );
                    _model . ED009 = 0;
                    _model . ED010 = string . IsNullOrEmpty ( table . Rows [ i ] [ "SWOODNOW" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "SWOODNOW" ] . ToString ( ) );
                    _model . ED011 = string . IsNullOrEmpty ( table . Rows [ i ] [ "YWOODNOW" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "YWOODNOW" ] . ToString ( ) );
                    if ( Exists ( _model ) )
                        editGun ( SQLString ,strSql ,_model );
                    else
                        addGun ( SQLString ,strSql ,_model );
                }
            }

            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                SQLString . Clear ( );
                table = getPen ( strWhere );
                if ( table != null && table . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < table . Rows . Count ; i++ )
                    {
                        _model . ED001 = table . Rows [ i ] [ "AM003" ] . ToString ( );
                        _model . ED002 = table . Rows [ i ] [ "AM002" ] . ToString ( );
                        _model . ED003 = table . Rows [ i ] [ "AM005" ] . ToString ( );
                        _model . ED004 = string . IsNullOrEmpty ( table . Rows [ i ] [ "AM006" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "AM006" ] . ToString ( ) );
                        if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "PQF31" ] . ToString ( ) ) )
                            _model . ED005 = null;
                        else
                            _model . ED005 = Convert . ToDateTime ( table . Rows [ i ] [ "PQF31" ] . ToString ( ) );
                        _model . ED006 = 0;
                        _model . ED007 = string . IsNullOrEmpty ( table . Rows [ i ] [ "SWOODNOW" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "SWOODNOW" ] . ToString ( ) );
                        _model . ED008 = string . IsNullOrEmpty ( table . Rows [ i ] [ "YWOODNOW" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "YWOODNOW" ] . ToString ( ) );
                        if ( Exists ( _model ) )
                            editPen ( SQLString ,strSql ,_model );
                        else
                            addPen ( SQLString ,strSql ,_model );
                    }
                }
            }
            else
                return false;

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        bool Exists ( MulaolaoLibrary . PaintEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM R_PQED WHERE ED002='{0}'" ,_model . ED002 );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        void addGun ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . PaintEntity _model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQED (" );
            strSql . Append ( "ED001,ED002,ED003,ED004,ED005,ED009,ED010,ED011) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@ED001,@ED002,@ED003,@ED004,@ED005,@ED009,@ED010,@ED011) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@ED001",SqlDbType.NVarChar,50),
                new SqlParameter("@ED002",SqlDbType.NVarChar,50),
                new SqlParameter("@ED003",SqlDbType.NVarChar,50),
                new SqlParameter("@ED004",SqlDbType.Int,4),
                new SqlParameter("@ED005",SqlDbType.Date,3),
                new SqlParameter("@ED009",SqlDbType.Decimal,18),
                new SqlParameter("@ED010",SqlDbType.Decimal,18),
                new SqlParameter("@ED011",SqlDbType.Decimal,18)
            };
            parameter [ 0 ] . Value = _model . ED001;
            parameter [ 1 ] . Value = _model . ED002;
            parameter [ 2 ] . Value = _model . ED003;
            parameter [ 3 ] . Value = _model . ED004;
            parameter [ 4 ] . Value = _model . ED005;
            parameter [ 5 ] . Value = _model . ED009;
            parameter [ 6 ] . Value = _model . ED010;
            parameter [ 7 ] . Value = _model . ED011;

            SQLString . Add ( strSql ,parameter );
        }
        void editGun ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . PaintEntity _model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQED SET " );
            strSql . Append ( "ED009=@ED009," );
            strSql . Append ( "ED010=@ED010," );
            strSql . Append ( "ED011=@ED011 " );
            strSql . Append ( "WHERE ED002=@ED002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@ED002",SqlDbType.NVarChar,50),
                new SqlParameter("@ED009",SqlDbType.Decimal,18),
                new SqlParameter("@ED010",SqlDbType.Decimal,18),
                new SqlParameter("@ED011",SqlDbType.Decimal,18)
            };
            parameter [ 0 ] . Value = _model . ED002;
            parameter [ 1 ] . Value = _model . ED009;
            parameter [ 2 ] . Value = _model . ED010;
            parameter [ 3 ] . Value = _model . ED011;

            SQLString . Add ( strSql ,parameter );
        }

        void addPen ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . PaintEntity _model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQED (" );
            strSql . Append ( "ED001,ED002,ED003,ED004,ED005,ED006,ED007,ED008) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@ED001,@ED002,@ED003,@ED004,@ED005,@ED006,@ED007,@ED008) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@ED001",SqlDbType.NVarChar,50),
                new SqlParameter("@ED002",SqlDbType.NVarChar,50),
                new SqlParameter("@ED003",SqlDbType.NVarChar,50),
                new SqlParameter("@ED004",SqlDbType.Int,4),
                new SqlParameter("@ED005",SqlDbType.Date,3),
                new SqlParameter("@ED006",SqlDbType.Decimal,18),
                new SqlParameter("@ED007",SqlDbType.Decimal,18),
                new SqlParameter("@ED008",SqlDbType.Decimal,18)
            };
            parameter [ 0 ] . Value = _model . ED001;
            parameter [ 1 ] . Value = _model . ED002;
            parameter [ 2 ] . Value = _model . ED003;
            parameter [ 3 ] . Value = _model . ED004;
            parameter [ 4 ] . Value = _model . ED005;
            parameter [ 5 ] . Value = _model . ED006;
            parameter [ 6 ] . Value = _model . ED007;
            parameter [ 7 ] . Value = _model . ED008;

            SQLString . Add ( strSql ,parameter );
        }
        void editPen ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . PaintEntity _model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQED SET " );
            strSql . Append ( "ED006=@ED006," );
            strSql . Append ( "ED007=@ED007," );
            strSql . Append ( "ED008=@ED008 " );
            strSql . Append ( "WHERE ED002=@ED002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@ED002",SqlDbType.NVarChar,50),
                new SqlParameter("@ED006",SqlDbType.Decimal,18),
                new SqlParameter("@ED007",SqlDbType.Decimal,18),
                new SqlParameter("@ED008",SqlDbType.Decimal,18)
            };
            parameter [ 0 ] . Value = _model . ED002;
            parameter [ 1 ] . Value = _model . ED006;
            parameter [ 2 ] . Value = _model . ED007;
            parameter [ 3 ] . Value = _model . ED008;

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 滚漆
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        DataTable getGun ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT A.AM002,A.AM003,A.AM006,PQF31,A.AM005,CONVERT(DECIMAL(11,2),CASE WHEN AM006=0 THEN 0 ELSE (AM249+AM242+AM245)/AM006 END) YWOODNOW,ISNULL((SELECT CONVERT(DECIMAL(11,2),CASE WHEN AM006=0 THEN 0 ELSE (AM249+AM242+AM245)/AM006 END) SWOODNOW FROM R_PQAM WHERE AM002 IN (SELECT MAX(AM002) AM002 FROM R_PQAM B WHERE B.AM002<A.AM002 AND B.AM005=A.AM005 GROUP BY B.AM005)),0) SWOODNOW FROM R_PQAM A INNER JOIN R_PQF B ON A.AM002=B.PQF01 WHERE {0}" ,strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 喷漆
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        DataTable getPen ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT A.AM002,A.AM003,A.AM006,PQF31,A.AM005,CONVERT(DECIMAL(11,2),CASE WHEN AM006=0 THEN 0 ELSE (AM175+AM178+AM182+AM185)/AM006 END) YWOODNOW,ISNULL((SELECT CONVERT(DECIMAL(11,2),CASE WHEN AM006=0 THEN 0 ELSE (AM175+AM178+AM182+AM185)/AM006 END) SWOODNOW FROM R_PQAM WHERE AM002 IN (SELECT MAX(AM002) AM002 FROM R_PQAM B WHERE B.AM002<A.AM002 AND B.AM005=A.AM005 GROUP BY B.AM005)),0) SWOODNOW FROM R_PQAM A INNER JOIN R_PQF B ON A.AM002=B.PQF01 WHERE {0}" ,strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}

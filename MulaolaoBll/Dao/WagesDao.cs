using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using StudentMgr;
using System . Collections;
using System . Data;
using System . Data . SqlClient;

namespace MulaolaoBll . Dao
{
    public class WagesDao
    {
        /*
        public bool Save ( )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            MulaolaoLibrary . WagesEntity _model = new MulaolaoLibrary . WagesEntity ( );

            #region 白坯

            #endregion

            #region 后段

            #endregion

            #region 检验

            #endregion

            #region 包装

            #endregion

            #region 承揽

            #endregion

        }

        DataTable getBP ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "" );
        }

        */


        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Edit ( DataTable table )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            MulaolaoLibrary . WagesEntity _model = new MulaolaoLibrary . WagesEntity ( );

            if ( table != null && table . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < table . Rows . Count ; i++ )
                {
                    _model . EC002 = table . Rows [ i ] [ "EC002" ] . ToString ( );
                    _model . EC024 = string . IsNullOrEmpty ( table . Rows [ i ] [ "EC024" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "EC024" ] . ToString ( ) );
                    _model . EC025 = string . IsNullOrEmpty ( table . Rows [ i ] [ "EC025" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "EC025" ] . ToString ( ) );
                    _model . EC026 = string . IsNullOrEmpty ( table . Rows [ i ] [ "EC026" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "EC026" ] . ToString ( ) );
                    _model . EC027 = string . IsNullOrEmpty ( table . Rows [ i ] [ "EC027" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "EC027" ] . ToString ( ) );
                    _model . EC028 = string . IsNullOrEmpty ( table . Rows [ i ] [ "EC028" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "EC028" ] . ToString ( ) );
                    _model . EC029 = table . Rows [ i ] [ "EC029" ] . ToString ( );
                    _model . EC030 = table . Rows [ i ] [ "EC030" ] . ToString ( );

                    editAll ( SQLString ,strSql ,_model );
                }
            }
            else
                return false;

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void editAll ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . WagesEntity _model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQEC SET " );
            strSql . Append ( "EC024=@EC024," );
            strSql . Append ( "EC025=@EC025," );
            strSql . Append ( "EC026=@EC026," );
            strSql . Append ( "EC027=@EC027," );
            strSql . Append ( "EC028=@EC028," );
            strSql . Append ( "EC029=@EC029," );
            strSql . Append ( "EC030=@EC030 " );
            strSql . Append ( "WHERE EC002=@EC002" );
            SqlParameter [ ] parametre = {
                new SqlParameter("@EC002",SqlDbType.NVarChar,50),
                new SqlParameter("@EC024",SqlDbType.Decimal,18),
                new SqlParameter("@EC025",SqlDbType.Decimal,18),
                new SqlParameter("@EC026",SqlDbType.Decimal,18),
                new SqlParameter("@EC027",SqlDbType.Decimal,18),
                new SqlParameter("@EC028",SqlDbType.Decimal,18),
                new SqlParameter("@EC029",SqlDbType.NVarChar,50),
                new SqlParameter("@EC030",SqlDbType.NVarChar,255)
            };
            parametre [ 0 ] . Value = _model . EC002;
            parametre [ 1 ] . Value = _model . EC024;
            parametre [ 2 ] . Value = _model . EC025;
            parametre [ 3 ] . Value = _model . EC026;
            parametre [ 4 ] . Value = _model . EC027;
            parametre [ 5 ] . Value = _model . EC028;
            parametre [ 6 ] . Value = _model . EC029;
            parametre [ 7 ] . Value = _model . EC030;

            SQLString . Add ( strSql ,parametre );
        }

        /// <summary>
        /// 获取产品名称
        /// </summary>
        /// <returns></returns>
        public DataTable getPro ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT AM002,AM003,AM005 FROM R_PQAM " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTabelView ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT idx,EC001,EC002,EC003,EC004,EC005,CONVERT(FLOAT,EC006) EC006,CONVERT(FLOAT,EC007) EC007,CONVERT(FLOAT,EC008) EC008,CONVERT(FLOAT,EC009) EC009,CONVERT(FLOAT,EC010) EC010,CONVERT(FLOAT,EC011) EC011,CONVERT(FLOAT,EC012) EC012,CONVERT(FLOAT,EC013) EC013,CONVERT(FLOAT,EC014) EC014,CONVERT(FLOAT,EC015) EC015,CONVERT(FLOAT,EC016) EC016,CONVERT(FLOAT,EC017) EC017,CONVERT(FLOAT,EC018) EC018,CONVERT(FLOAT,EC019) EC019,CONVERT(FLOAT,EC020) EC020,CONVERT(FLOAT,EC024) EC024,CONVERT(FLOAT,EC025) EC025,CONVERT(FLOAT,EC026) EC026,CONVERT(FLOAT,EC027) EC027,CONVERT(FLOAT,EC028) EC028,EC029,EC030 FROM R_PQEC WHERE {0}" ,strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool Save ( string strWhere )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            MulaolaoLibrary . WagesEntity _model = new MulaolaoLibrary . WagesEntity ( );
            DataTable table = getW ( strWhere );
            if ( table != null && table . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < table . Rows . Count ; i++ )
                {
                    _model . EC001 = table . Rows [ i ] [ "AM003" ] . ToString ( );
                    _model . EC002 = table . Rows [ i ] [ "AM002" ] . ToString ( );
                    _model . EC003 = table . Rows [ i ] [ "AM005" ] . ToString ( );
                    _model . EC004 = string . IsNullOrEmpty ( table . Rows [ i ] [ "AM006" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "AM006" ] . ToString ( ) );
                    if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "PQF31" ] . ToString ( ) ) )
                        _model . EC005 = null;
                    else
                        _model . EC005 = Convert . ToDateTime ( table . Rows [ i ] [ "PQF31" ] . ToString ( ) );
                    _model . EC018 = 0;
                    _model . EC019 = string . IsNullOrEmpty ( table . Rows [ i ] [ "SWOODNOW" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "SWOODNOW" ] . ToString ( ) );
                    _model . EC020 = string . IsNullOrEmpty ( table . Rows [ i ] [ "YWOODNOW" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "YWOODNOW" ] . ToString ( ) );
                    if ( Exists ( _model ) )
                        editW ( SQLString ,strSql ,_model );
                    else
                        addW ( SQLString ,strSql ,_model );
                }
            }

            if ( strWhere . Equals ( "A.AM002" ) )
                strWhere = strWhere . Replace ( "A.AM002" ,"GZ01" );

            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                SQLString . Clear ( );
                table = getQ ( strWhere );
                if ( table != null && table . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < table . Rows . Count ; i++ )
                    {
                        _model . EC001 = table . Rows [ i ] [ "GZ22" ] . ToString ( );
                        _model . EC002 = table . Rows [ i ] [ "GZ01" ] . ToString ( );
                        _model . EC003 = table . Rows [ i ] [ "GZ23" ] . ToString ( );
                        _model . EC004 = string . IsNullOrEmpty ( table . Rows [ i ] [ "GZ34" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "GZ34" ] . ToString ( ) );
                        if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "PQF31" ] . ToString ( ) ) )
                            _model . EC005 = null;
                        else
                            _model . EC005 = Convert . ToDateTime ( table . Rows [ i ] [ "PQF31" ] . ToString ( ) );
                        _model . EC006 = 0;
                        _model . EC007 = string . IsNullOrEmpty ( table . Rows [ i ] [ "GZ1" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "GZ1" ] . ToString ( ) );
                        _model . EC008 = string . IsNullOrEmpty ( table . Rows [ i ] [ "GZ" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "GZ" ] . ToString ( ) );
                        if ( Exists ( _model ) )
                            editQ ( SQLString ,strSql ,_model );
                        else
                            addQ ( SQLString ,strSql ,_model );
                    }
                }
            }
            else
                return false;

            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                SQLString . Clear ( );
                table = getH ( strWhere );
                if ( table != null && table . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < table . Rows . Count ; i++ )
                    {
                        _model . EC001 = table . Rows [ i ] [ "GZ22" ] . ToString ( );
                        _model . EC002 = table . Rows [ i ] [ "GZ01" ] . ToString ( );
                        _model . EC003 = table . Rows [ i ] [ "GZ23" ] . ToString ( );
                        _model . EC004 = string . IsNullOrEmpty ( table . Rows [ i ] [ "GZ34" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "GZ34" ] . ToString ( ) );
                        if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "PQF31" ] . ToString ( ) ) )
                            _model . EC005 = null;
                        else
                            _model . EC005 = Convert . ToDateTime ( table . Rows [ i ] [ "PQF31" ] . ToString ( ) );
                        _model . EC009 = 0;
                        _model . EC010 = string . IsNullOrEmpty ( table . Rows [ i ] [ "GZ1" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "GZ1" ] . ToString ( ) );
                        _model . EC011 = string . IsNullOrEmpty ( table . Rows [ i ] [ "GZ" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "GZ" ] . ToString ( ) );
                        if ( Exists ( _model ) )
                            editH ( SQLString ,strSql ,_model );
                        else
                            addH ( SQLString ,strSql ,_model );
                    }
                }
            }
            else
                return false;

            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                SQLString . Clear ( );
                table = getCheck ( strWhere );
                if ( table != null && table . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < table . Rows . Count ; i++ )
                    {
                        _model . EC001 = table . Rows [ i ] [ "GZ22" ] . ToString ( );
                        _model . EC002 = table . Rows [ i ] [ "GZ01" ] . ToString ( );
                        _model . EC003 = table . Rows [ i ] [ "GZ23" ] . ToString ( );
                        _model . EC004 = string . IsNullOrEmpty ( table . Rows [ i ] [ "GZ34" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "GZ34" ] . ToString ( ) );
                        if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "PQF31" ] . ToString ( ) ) )
                            _model . EC005 = null;
                        else
                            _model . EC005 = Convert . ToDateTime ( table . Rows [ i ] [ "PQF31" ] . ToString ( ) );
                        _model . EC012 = 0;
                        _model . EC013 = string . IsNullOrEmpty ( table . Rows [ i ] [ "GZ1" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "GZ1" ] . ToString ( ) );
                        _model . EC014 = string . IsNullOrEmpty ( table . Rows [ i ] [ "GZ" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "GZ" ] . ToString ( ) );
                        if ( Exists ( _model ) )
                            editCheck ( SQLString ,strSql ,_model );
                        else
                            addCheck ( SQLString ,strSql ,_model );
                    }
                }
            }
            else
                return false;

            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                SQLString . Clear ( );
                table = getCheck ( strWhere );
                if ( table != null && table . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < table . Rows . Count ; i++ )
                    {
                        _model . EC001 = table . Rows [ i ] [ "GZ22" ] . ToString ( );
                        _model . EC002 = table . Rows [ i ] [ "GZ01" ] . ToString ( );
                        _model . EC003 = table . Rows [ i ] [ "GZ23" ] . ToString ( );
                        _model . EC004 = string . IsNullOrEmpty ( table . Rows [ i ] [ "GZ34" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "GZ34" ] . ToString ( ) );
                        if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "PQF31" ] . ToString ( ) ) )
                            _model . EC005 = null;
                        else
                            _model . EC005 = Convert . ToDateTime ( table . Rows [ i ] [ "PQF31" ] . ToString ( ) );
                        _model . EC015 = 0;
                        _model . EC016 = string . IsNullOrEmpty ( table . Rows [ i ] [ "GZ1" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "GZ1" ] . ToString ( ) );
                        _model . EC017 = string . IsNullOrEmpty ( table . Rows [ i ] [ "GZ" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "GZ" ] . ToString ( ) );
                        if ( Exists ( _model ) )
                            editPack ( SQLString ,strSql ,_model );
                        else
                            addPack ( SQLString ,strSql ,_model );
                    }
                }
            }
            else
                return false;

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }
        
        void addW ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . WagesEntity _model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQEC (" );
            strSql . Append ( "EC001,EC002,EC003,EC004,EC005,EC018,EC019,EC020) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@EC001,@EC002,@EC003,@EC004,@EC005,@EC018,@EC019,@EC020) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@EC001",SqlDbType.NVarChar,50),
                new SqlParameter("@EC002",SqlDbType.NVarChar,50),
                new SqlParameter("@EC003",SqlDbType.NVarChar,50),
                new SqlParameter("@EC004",SqlDbType.Int,4),
                new SqlParameter("@EC005",SqlDbType.Date,3),
                new SqlParameter("@EC018",SqlDbType.Decimal,18),
                new SqlParameter("@EC019",SqlDbType.Decimal,18),
                new SqlParameter("@EC020",SqlDbType.Decimal,18)
            };
            parameter [ 0 ] . Value = _model . EC001;
            parameter [ 1 ] . Value = _model . EC002;
            parameter [ 2 ] . Value = _model . EC003;
            parameter [ 3 ] . Value = _model . EC004;
            parameter [ 4 ] . Value = _model . EC005;
            parameter [ 5 ] . Value = _model . EC018;
            parameter [ 6 ] . Value = _model . EC019;
            parameter [ 7 ] . Value = _model . EC020;

            SQLString . Add ( strSql ,parameter );
        }
        void editW ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . WagesEntity _model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQEC SET " );
            strSql . Append ( "EC018=@EC018," );
            strSql . Append ( "EC019=@EC019," );
            strSql . Append ( "EC020=@EC020 " );
            strSql . Append ( "WHERE EC002=@EC002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@EC002",SqlDbType.NVarChar,50),
                new SqlParameter("@EC018",SqlDbType.Decimal,18),
                new SqlParameter("@EC019",SqlDbType.Decimal,18),
                new SqlParameter("@EC020",SqlDbType.Decimal,18)
            };
            parameter [ 0 ] . Value = _model . EC002;
            parameter [ 1 ] . Value = _model . EC018;
            parameter [ 2 ] . Value = _model . EC019;
            parameter [ 3 ] . Value = _model . EC020;

            SQLString . Add ( strSql ,parameter );
        }

        void addQ ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . WagesEntity _model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQEC (" );
            strSql . Append ( "EC001,EC002,EC003,EC004,EC005,EC006,EC007,EC008) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@EC001,@EC002,@EC003,@EC004,@EC005,@EC006,@EC007,@EC008) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@EC001",SqlDbType.NVarChar,50),
                new SqlParameter("@EC002",SqlDbType.NVarChar,50),
                new SqlParameter("@EC003",SqlDbType.NVarChar,50),
                new SqlParameter("@EC004",SqlDbType.Int,4),
                new SqlParameter("@EC005",SqlDbType.Date,3),
                new SqlParameter("@EC006",SqlDbType.Decimal,18),
                new SqlParameter("@EC007",SqlDbType.Decimal,18),
                new SqlParameter("@EC008",SqlDbType.Decimal,18)
            };
            parameter [ 0 ] . Value = _model . EC001;
            parameter [ 1 ] . Value = _model . EC002;
            parameter [ 2 ] . Value = _model . EC003;
            parameter [ 3 ] . Value = _model . EC004;
            parameter [ 4 ] . Value = _model . EC005;
            parameter [ 5 ] . Value = _model . EC006;
            parameter [ 6 ] . Value = _model . EC007;
            parameter [ 7 ] . Value = _model . EC008;

            SQLString . Add ( strSql ,parameter );
        }
        void editQ ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . WagesEntity _model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQEC SET " );
            strSql . Append ( "EC006=@EC006," );
            strSql . Append ( "EC007=@EC007," );
            strSql . Append ( "EC008=@EC008 " );
            strSql . Append ( "WHERE EC002=@EC002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@EC002",SqlDbType.NVarChar,50),
                new SqlParameter("@EC006",SqlDbType.Decimal,18),
                new SqlParameter("@EC007",SqlDbType.Decimal,18),
                new SqlParameter("@EC008",SqlDbType.Decimal,18)
            };
            parameter [ 0 ] . Value = _model . EC002;
            parameter [ 1 ] . Value = _model . EC006;
            parameter [ 2 ] . Value = _model . EC007;
            parameter [ 3 ] . Value = _model . EC008;

            SQLString . Add ( strSql ,parameter );
        }

        void addH ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . WagesEntity _model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQEC (" );
            strSql . Append ( "EC001,EC002,EC003,EC004,EC005,EC009,EC010,EC011) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@EC001,@EC002,@EC003,@EC004,@EC005,@EC009,@EC010,@EC011) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@EC001",SqlDbType.NVarChar,50),
                new SqlParameter("@EC002",SqlDbType.NVarChar,50),
                new SqlParameter("@EC003",SqlDbType.NVarChar,50),
                new SqlParameter("@EC004",SqlDbType.Int,4),
                new SqlParameter("@EC005",SqlDbType.Date,3),
                new SqlParameter("@EC009",SqlDbType.Decimal,18),
                new SqlParameter("@EC010",SqlDbType.Decimal,18),
                new SqlParameter("@EC011",SqlDbType.Decimal,18)
            };
            parameter [ 0 ] . Value = _model . EC001;
            parameter [ 1 ] . Value = _model . EC002;
            parameter [ 2 ] . Value = _model . EC003;
            parameter [ 3 ] . Value = _model . EC004;
            parameter [ 4 ] . Value = _model . EC005;
            parameter [ 5 ] . Value = _model . EC009;
            parameter [ 6 ] . Value = _model . EC010;
            parameter [ 7 ] . Value = _model . EC011;

            SQLString . Add ( strSql ,parameter );
        }
        void editH ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . WagesEntity _model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQEC SET " );
            strSql . Append ( "EC009=@EC009," );
            strSql . Append ( "EC010=@EC010," );
            strSql . Append ( "EC011=@EC011 " );
            strSql . Append ( "WHERE EC002=@EC002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@EC002",SqlDbType.NVarChar,50),
                new SqlParameter("@EC009",SqlDbType.Decimal,18),
                new SqlParameter("@EC010",SqlDbType.Decimal,18),
                new SqlParameter("@EC011",SqlDbType.Decimal,18)
            };
            parameter [ 0 ] . Value = _model . EC002;
            parameter [ 1 ] . Value = _model . EC009;
            parameter [ 2 ] . Value = _model . EC010;
            parameter [ 3 ] . Value = _model . EC011;

            SQLString . Add ( strSql ,parameter );
        }

        void addCheck ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . WagesEntity _model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQEC (" );
            strSql . Append ( "EC001,EC002,EC003,EC004,EC005,EC012,EC013,EC014) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@EC001,@EC002,@EC003,@EC004,@EC005,@EC012,@EC013,@EC014) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@EC001",SqlDbType.NVarChar,50),
                new SqlParameter("@EC002",SqlDbType.NVarChar,50),
                new SqlParameter("@EC003",SqlDbType.NVarChar,50),
                new SqlParameter("@EC004",SqlDbType.Int,4),
                new SqlParameter("@EC005",SqlDbType.Date,3),
                new SqlParameter("@EC012",SqlDbType.Decimal,18),
                new SqlParameter("@EC013",SqlDbType.Decimal,18),
                new SqlParameter("@EC014",SqlDbType.Decimal,18)
            };
            parameter [ 0 ] . Value = _model . EC001;
            parameter [ 1 ] . Value = _model . EC002;
            parameter [ 2 ] . Value = _model . EC003;
            parameter [ 3 ] . Value = _model . EC004;
            parameter [ 4 ] . Value = _model . EC005;
            parameter [ 5 ] . Value = _model . EC012;
            parameter [ 6 ] . Value = _model . EC013;
            parameter [ 7 ] . Value = _model . EC014;

            SQLString . Add ( strSql ,parameter );
        }
        void editCheck ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . WagesEntity _model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQEC SET " );
            strSql . Append ( "EC012=@EC012," );
            strSql . Append ( "EC013=@EC013," );
            strSql . Append ( "EC014=@EC014 " );
            strSql . Append ( "WHERE EC002=@EC002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@EC002",SqlDbType.NVarChar,50),
                new SqlParameter("@EC012",SqlDbType.Decimal,18),
                new SqlParameter("@EC013",SqlDbType.Decimal,18),
                new SqlParameter("@EC014",SqlDbType.Decimal,18)
            };
            parameter [ 0 ] . Value = _model . EC002;
            parameter [ 1 ] . Value = _model . EC012;
            parameter [ 2 ] . Value = _model . EC013;
            parameter [ 3 ] . Value = _model . EC014;

            SQLString . Add ( strSql ,parameter );
        }

        void addPack ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . WagesEntity _model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQEC (" );
            strSql . Append ( "EC001,EC002,EC003,EC004,EC005,EC015,EC016,EC017) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@EC001,@EC002,@EC003,@EC004,@EC005,@EC015,@EC016,@EC017) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@EC001",SqlDbType.NVarChar,50),
                new SqlParameter("@EC002",SqlDbType.NVarChar,50),
                new SqlParameter("@EC003",SqlDbType.NVarChar,50),
                new SqlParameter("@EC004",SqlDbType.Int,4),
                new SqlParameter("@EC005",SqlDbType.Date,3),
                new SqlParameter("@EC015",SqlDbType.Decimal,18),
                new SqlParameter("@EC016",SqlDbType.Decimal,18),
                new SqlParameter("@EC017",SqlDbType.Decimal,18)
            };
            parameter [ 0 ] . Value = _model . EC001;
            parameter [ 1 ] . Value = _model . EC002;
            parameter [ 2 ] . Value = _model . EC003;
            parameter [ 3 ] . Value = _model . EC004;
            parameter [ 4 ] . Value = _model . EC005;
            parameter [ 5 ] . Value = _model . EC015;
            parameter [ 6 ] . Value = _model . EC016;
            parameter [ 7 ] . Value = _model . EC017;

            SQLString . Add ( strSql ,parameter );
        }
        void editPack ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . WagesEntity _model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQEC SET " );
            strSql . Append ( "EC015=@EC015," );
            strSql . Append ( "EC016=@EC016," );
            strSql . Append ( "EC017=@EC017 " );
            strSql . Append ( "WHERE EC002=@EC002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@EC002",SqlDbType.NVarChar,50),
                new SqlParameter("@EC015",SqlDbType.Decimal,18),
                new SqlParameter("@EC016",SqlDbType.Decimal,18),
                new SqlParameter("@EC017",SqlDbType.Decimal,18)
            };
            parameter [ 0 ] . Value = _model . EC002;
            parameter [ 1 ] . Value = _model . EC015;
            parameter [ 2 ] . Value = _model . EC016;
            parameter [ 3 ] . Value = _model . EC017;

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        bool Exists ( MulaolaoLibrary . WagesEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM R_PQEC WHERE EC002='{0}'" ,_model . EC002 );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取委外工资
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        DataTable getW ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT A.AM002,A.AM003,A.AM006,PQF31,A.AM005,CONVERT(DECIMAL(11,2),CASE WHEN AM006=0 THEN 0 ELSE (AM070+AM072+AM074+AM076+AM078+AM080+AM082+AM084+AM086+AM088+AM090+AM092)/AM006 END) YWOODNOW,ISNULL((SELECT CONVERT(DECIMAL(11,2),CASE WHEN AM006=0 THEN 0 ELSE (AM070+AM072+AM074+AM076+AM078+AM080+AM082+AM084+AM086+AM088+AM090+AM092)/AM006 END) SWOODNOW FROM R_PQAM WHERE AM002 IN (SELECT MAX(AM002) AM002 FROM R_PQAM B WHERE B.AM002<A.AM002 AND B.AM005=A.AM005 GROUP BY B.AM005)),0) SWOODNOW FROM R_PQAM A INNER JOIN R_PQF B ON A.AM002=B.PQF01 WHERE {0} " ,strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 前道
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        DataTable getQ ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "WITH CET AS (SELECT GZ01,GZ23,GZ22,PQF31,SUM(GZ06*GZ25*GZ41+GZ36*(GZ12+GZ13+GZ14))/GZ34 GZ,GZ34 FROM R_PQW A INNER JOIN R_PQF E ON GZ01=PQF01 LEFT JOIN R_PQAA B ON A.GZ04=B.GX02 LEFT JOIN TPADBA C ON C.DBA001=A.GZ32 WHERE GX04!='检验' AND GX04!='包装' AND DBA960='男' AND {0} GROUP BY GZ01,GZ23,GZ34,GZ22,PQF31 " ,strWhere );
            strSql . Append ( "),CFT AS(" );
            strSql . Append ( "SELECT GZ01,GZ23,GZ22,PQF31,GZ34,SUM(GZ) GZ,(SELECT SUM(GZ) FROM CET WHERE GZ01 IN (SELECT MAX(GZ01) FROM CET B WHERE B.GZ01<A.GZ01 AND B.GZ23=A.GZ23 GROUP BY B.GZ23)) GZ1 FROM CET A GROUP BY GZ01,GZ23,GZ22,GZ34,PQF31) " );
            strSql . Append ( "SELECT GZ01,GZ23,GZ22,GZ34,PQF31,GZ,ISNULL(GZ1,0) GZ1 FROM CFT ORDER BY GZ01 " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 后道
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        DataTable getH ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "WITH CET AS (SELECT GZ01,GZ23,GZ22,PQF31,SUM(GZ06*GZ25*GZ41+GZ36*(GZ12+GZ13+GZ14))/GZ34 GZ,GZ34 FROM R_PQW A INNER JOIN R_PQF E ON GZ01=PQF01 LEFT JOIN R_PQAA B ON A.GZ04=B.GX02 LEFT JOIN TPADBA C ON C.DBA001=A.GZ32 WHERE GX04!='检验' AND GX04!='包装' AND DBA960 IN ('女','其他') AND {0} GROUP BY GZ01,GZ23,GZ34,GZ22,PQF31 " ,strWhere );
            strSql . Append ( "),CFT AS(" );
            strSql . Append ( "SELECT GZ01,GZ23,GZ22,PQF31,GZ34,SUM(GZ) GZ,(SELECT SUM(GZ) FROM CET WHERE GZ01 IN (SELECT MAX(GZ01) FROM CET B WHERE B.GZ01<A.GZ01 AND B.GZ23=A.GZ23 GROUP BY B.GZ23)) GZ1 FROM CET A GROUP BY GZ01,GZ23,GZ22,GZ34,PQF31) " );
            strSql . Append ( "SELECT GZ01,GZ23,GZ22,GZ34,PQF31,GZ,ISNULL(GZ1,0) GZ1 FROM CFT ORDER BY GZ01 " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 检验
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        DataTable getCheck ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "WITH CET AS (SELECT GZ01,GZ23,GZ22,PQF31,SUM(GZ06*GZ25*GZ41+GZ36*(GZ12+GZ13+GZ14))/GZ34 GZ,GZ34 FROM R_PQW A INNER JOIN R_PQF E ON GZ01=PQF01 LEFT JOIN R_PQAA B ON A.GZ04=B.GX02 WHERE GX04='检验' AND {0} GROUP BY GZ01,GZ23,GZ34,GZ22,PQF31 " ,strWhere );
            strSql . Append ( "),CFT AS(" );
            strSql . Append ( "SELECT GZ01,GZ23,GZ22,PQF31,GZ34,SUM(GZ) GZ,(SELECT SUM(GZ) FROM CET WHERE GZ01 IN (SELECT MAX(GZ01) FROM CET B WHERE B.GZ01<A.GZ01 AND B.GZ23=A.GZ23 GROUP BY B.GZ23)) GZ1 FROM CET A GROUP BY GZ01,GZ23,GZ22,GZ34,PQF31) " );
            strSql . Append ( "SELECT GZ01,GZ23,GZ22,GZ34,PQF31,GZ,ISNULL(GZ1,0) GZ1 FROM CFT ORDER BY GZ01 " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 包装
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        DataTable getPack ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "WITH CET AS (SELECT GZ01,GZ23,GZ22,PQF31,SUM(GZ06*GZ25*GZ41+GZ36*(GZ12+GZ13+GZ14))/GZ34 GZ,GZ34 FROM R_PQW A INNER JOIN R_PQF E ON GZ01=PQF01 LEFT JOIN R_PQAA B ON A.GZ04=B.GX02 WHERE GX04='包装' AND {0} GROUP BY GZ01,GZ23,GZ34,GZ22,PQF31 " ,strWhere );
            strSql . Append ( "),CFT AS(" );
            strSql . Append ( "SELECT GZ01,GZ23,GZ22,PQF31,GZ34,SUM(GZ) GZ,(SELECT SUM(GZ) FROM CET WHERE GZ01 IN (SELECT MAX(GZ01) FROM CET B WHERE B.GZ01<A.GZ01 AND B.GZ23=A.GZ23 GROUP BY B.GZ23)) GZ1 FROM CET A GROUP BY GZ01,GZ23,GZ22,GZ34,PQF31) " );
            strSql . Append ( "SELECT GZ01,GZ23,GZ22,GZ34,PQF31,GZ,ISNULL(GZ1,0) GZ1 FROM CFT ORDER BY GZ01 " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}

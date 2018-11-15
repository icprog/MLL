using System . Text;
using StudentMgr;
using System . Data;
using System . Collections;
using System;
using System . Data . SqlClient;

namespace MulaolaoBll . Dao
{
    public class MaterialDao
    {
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        public bool Save ( string strWhere ,string num )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            MulaolaoLibrary . MaterialEntity _model = new MulaolaoLibrary . MaterialEntity ( );

            #region 木材
            DataTable table = getWood ( strWhere ,num );
            if ( table != null && table . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < table . Rows . Count ; i++ )
                {
                    _model . EB001 = table . Rows [ i ] [ "AM003" ] . ToString ( );
                    _model . EB002 = table . Rows [ i ] [ "AM002" ] . ToString ( );
                    _model . EB003 = table . Rows [ i ] [ "AM005" ] . ToString ( );
                    _model . EB004 = string . IsNullOrEmpty ( table . Rows [ i ] [ "AM006" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "AM006" ] . ToString ( ) );
                    if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "PQF31" ] . ToString ( ) ) )
                        _model . EB005 = null;
                    else
                        _model . EB005 = Convert . ToDateTime ( table . Rows [ i ] [ "PQF31" ] . ToString ( ) );
                    _model . EB006 = string . IsNullOrEmpty ( table . Rows [ i ] [ "GS04" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "GS04" ] . ToString ( ) );
                    _model . EB007 = string . IsNullOrEmpty ( table . Rows [ i ] [ "SWOODNOW" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "SWOODNOW" ] . ToString ( ) );
                    _model . EB008 = string . IsNullOrEmpty ( table . Rows [ i ] [ "YWOODNOW" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "YWOODNOW" ] . ToString ( ) );

                    if ( Exists ( _model ) )
                        editWood ( _model ,strSql ,SQLString );
                    else
                        addWood ( _model ,strSql ,SQLString );
                }
            }
            #endregion

            #region 胶板料
            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                SQLString . Clear ( );
                table = getJM ( strWhere ,num );
                if ( table != null && table . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < table . Rows . Count ; i++ )
                    {
                        _model . EB001 = table . Rows [ i ] [ "AM003" ] . ToString ( );
                        _model . EB002 = table . Rows [ i ] [ "AM002" ] . ToString ( );
                        _model . EB003 = table . Rows [ i ] [ "AM005" ] . ToString ( );
                        _model . EB004 = string . IsNullOrEmpty ( table . Rows [ i ] [ "AM006" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "AM006" ] . ToString ( ) );
                        if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "PQF31" ] . ToString ( ) ) )
                            _model . EB005 = null;
                        else
                            _model . EB005 = Convert . ToDateTime ( table . Rows [ i ] [ "PQF31" ] . ToString ( ) );
                        _model . EB009 = string . IsNullOrEmpty ( table . Rows [ i ] [ "GS04" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "GS04" ] . ToString ( ) );
                        _model . EB010 = string . IsNullOrEmpty ( table . Rows [ i ] [ "SWOODNOW" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "SWOODNOW" ] . ToString ( ) );
                        _model . EB011 = string . IsNullOrEmpty ( table . Rows [ i ] [ "YWOODNOW" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "YWOODNOW" ] . ToString ( ) );

                        if ( Exists ( _model ) )
                            editJM ( _model ,strSql ,SQLString );
                        else
                            addJM ( _model ,strSql ,SQLString );
                    }
                }
            }
            else
                return false;
            #endregion

            #region 塑铁布
            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                SQLString . Clear ( );
                table = getPlastic ( strWhere ,num );
                if ( table != null && table . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < table . Rows . Count ; i++ )
                    {
                        _model . EB001 = table . Rows [ i ] [ "AM003" ] . ToString ( );
                        _model . EB002 = table . Rows [ i ] [ "AM002" ] . ToString ( );
                        _model . EB003 = table . Rows [ i ] [ "AM005" ] . ToString ( );
                        _model . EB004 = string . IsNullOrEmpty ( table . Rows [ i ] [ "AM006" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "AM006" ] . ToString ( ) );
                        if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "PQF31" ] . ToString ( ) ) )
                            _model . EB005 = null;
                        else
                            _model . EB005 = Convert . ToDateTime ( table . Rows [ i ] [ "PQF31" ] . ToString ( ) );
                        _model . EB012 = string . IsNullOrEmpty ( table . Rows [ i ] [ "GS04" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "GS04" ] . ToString ( ) );
                        _model . EB013 = string . IsNullOrEmpty ( table . Rows [ i ] [ "SWOODNOW" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "SWOODNOW" ] . ToString ( ) );
                        _model . EB014 = string . IsNullOrEmpty ( table . Rows [ i ] [ "YWOODNOW" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "YWOODNOW" ] . ToString ( ) );

                        if ( Exists ( _model ) )
                            editPlastic ( _model ,strSql ,SQLString );
                        else
                            addPlastic ( _model ,strSql ,SQLString );
                    }
                }
            }
            else
                return false;
            #endregion

            #region 车木件
            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                SQLString . Clear ( );
                table = getCarWood ( strWhere ,num );
                if ( table != null && table . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < table . Rows . Count ; i++ )
                    {
                        _model . EB001 = table . Rows [ i ] [ "AM003" ] . ToString ( );
                        _model . EB002 = table . Rows [ i ] [ "AM002" ] . ToString ( );
                        _model . EB003 = table . Rows [ i ] [ "AM005" ] . ToString ( );
                        _model . EB004 = string . IsNullOrEmpty ( table . Rows [ i ] [ "AM006" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "AM006" ] . ToString ( ) );
                        if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "PQF31" ] . ToString ( ) ) )
                            _model . EB005 = null;
                        else
                            _model . EB005 = Convert . ToDateTime ( table . Rows [ i ] [ "PQF31" ] . ToString ( ) );
                        _model . EB015 = string . IsNullOrEmpty ( table . Rows [ i ] [ "GS04" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "GS04" ] . ToString ( ) );
                        _model . EB016 = string . IsNullOrEmpty ( table . Rows [ i ] [ "SWOODNOW" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "SWOODNOW" ] . ToString ( ) );
                        _model . EB017 = string . IsNullOrEmpty ( table . Rows [ i ] [ "YWOODNOW" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "YWOODNOW" ] . ToString ( ) );

                        if ( Exists ( _model ) )
                            editCarWood ( _model ,strSql ,SQLString );
                        else
                            addCarWood ( _model ,strSql ,SQLString );
                    }
                }
            }
            else
                return false;
            #endregion

            #region 委外
            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                SQLString . Clear ( );
                table = getOutSource ( strWhere );
                if ( table != null && table . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < table . Rows . Count ; i++ )
                    {
                        _model . EB001 = table . Rows [ i ] [ "AM003" ] . ToString ( );
                        _model . EB002 = table . Rows [ i ] [ "AM002" ] . ToString ( );
                        _model . EB003 = table . Rows [ i ] [ "AM005" ] . ToString ( );
                        _model . EB004 = string . IsNullOrEmpty ( table . Rows [ i ] [ "AM006" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "AM006" ] . ToString ( ) );
                        if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "PQF31" ] . ToString ( ) ) )
                            _model . EB005 = null;
                        else
                            _model . EB005 = Convert . ToDateTime ( table . Rows [ i ] [ "PQF31" ] . ToString ( ) );
                        _model . EB018 = 0;
                        _model . EB019 = string . IsNullOrEmpty ( table . Rows [ i ] [ "SWOODNOW" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "SWOODNOW" ] . ToString ( ) );
                        _model . EB020 = string . IsNullOrEmpty ( table . Rows [ i ] [ "YWOODNOW" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "YWOODNOW" ] . ToString ( ) );

                        if ( Exists ( _model ) )
                            editOutSource ( _model ,strSql ,SQLString );
                        else
                            addOutSource ( _model ,strSql ,SQLString );
                    }
                }
            }
            else
                return false;
            #endregion

            #region 纸箱
            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                SQLString . Clear ( );
                table = getCarton ( strWhere ,num );
                if ( table != null && table . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < table . Rows . Count ; i++ )
                    {
                        _model . EB001 = table . Rows [ i ] [ "AM003" ] . ToString ( );
                        _model . EB002 = table . Rows [ i ] [ "AM002" ] . ToString ( );
                        _model . EB003 = table . Rows [ i ] [ "AM005" ] . ToString ( );
                        _model . EB004 = string . IsNullOrEmpty ( table . Rows [ i ] [ "AM006" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "AM006" ] . ToString ( ) );
                        if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "PQF31" ] . ToString ( ) ) )
                            _model . EB005 = null;
                        else
                            _model . EB005 = Convert . ToDateTime ( table . Rows [ i ] [ "PQF31" ] . ToString ( ) );
                        _model . EB021 = string . IsNullOrEmpty ( table . Rows [ i ] [ "GS04" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "GS04" ] . ToString ( ) );
                        _model . EB022 = string . IsNullOrEmpty ( table . Rows [ i ] [ "SWOODNOW" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "SWOODNOW" ] . ToString ( ) );
                        _model . EB023 = string . IsNullOrEmpty ( table . Rows [ i ] [ "YWOODNOW" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "YWOODNOW" ] . ToString ( ) );

                        if ( Exists ( _model ) )
                            editCarton ( _model ,strSql ,SQLString );
                        else
                            addCarton ( _model ,strSql ,SQLString );
                    }
                }
            }
            else
                return false;
            #endregion

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }
        
        void addWood ( MulaolaoLibrary . MaterialEntity _model ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQEB (" );
            strSql . Append ( "EB001,EB002,EB003,EB004,EB005,EB006,EB007,EB008) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@EB001,@EB002,@EB003,@EB004,@EB005,@EB006,@EB007,@EB008) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@EB001",SqlDbType.NVarChar,50),
                new SqlParameter("@EB002",SqlDbType.NVarChar,50),
                new SqlParameter("@EB003",SqlDbType.NVarChar,50),
                new SqlParameter("@EB004",SqlDbType.Int,4),
                new SqlParameter("@EB005",SqlDbType.Date,3),
                new SqlParameter("@EB006",SqlDbType.Decimal,18),
                new SqlParameter("@EB007",SqlDbType.Decimal,18),
                new SqlParameter("@EB008",SqlDbType.Decimal,18)
            };
            parameter [ 0 ] . Value = _model . EB001;
            parameter [ 1 ] . Value = _model . EB002;
            parameter [ 2 ] . Value = _model . EB003;
            parameter [ 3 ] . Value = _model . EB004;
            parameter [ 4 ] . Value = _model . EB005;
            parameter [ 5 ] . Value = _model . EB006;
            parameter [ 6 ] . Value = _model . EB007;
            parameter [ 7 ] . Value = _model . EB008;

            SQLString . Add ( strSql ,parameter );
        }
        void editWood ( MulaolaoLibrary . MaterialEntity _model ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQEB SET " );
            strSql . Append ( "EB006=@EB006," );
            strSql . Append ( "EB007=@EB007," );
            strSql . Append ( "EB008=@EB008 " );
            strSql . Append ( "WHERE EB002=@EB002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@EB002",SqlDbType.NVarChar,50),
                new SqlParameter("@EB006",SqlDbType.Decimal,18),
                new SqlParameter("@EB007",SqlDbType.Decimal,18),
                new SqlParameter("@EB008",SqlDbType.Decimal,18)
            };
            parameter [ 0 ] . Value = _model . EB002;
            parameter [ 1 ] . Value = _model . EB006;
            parameter [ 2 ] . Value = _model . EB007;
            parameter [ 3 ] . Value = _model . EB008;

            SQLString . Add ( strSql ,parameter );
        }

        void addJM ( MulaolaoLibrary . MaterialEntity _model ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQEB (" );
            strSql . Append ( "EB001,EB002,EB003,EB004,EB005,EB009,EB010,EB011) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@EB001,@EB002,@EB003,@EB004,@EB005,@EB009,@EB010,@EB011) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@EB001",SqlDbType.NVarChar,50),
                new SqlParameter("@EB002",SqlDbType.NVarChar,50),
                new SqlParameter("@EB003",SqlDbType.NVarChar,50),
                new SqlParameter("@EB004",SqlDbType.Int,4),
                new SqlParameter("@EB005",SqlDbType.Date,3),
                new SqlParameter("@EB009",SqlDbType.Decimal,18),
                new SqlParameter("@EB010",SqlDbType.Decimal,18),
                new SqlParameter("@EB011",SqlDbType.Decimal,18)
            };
            parameter [ 0 ] . Value = _model . EB001;
            parameter [ 1 ] . Value = _model . EB002;
            parameter [ 2 ] . Value = _model . EB003;
            parameter [ 3 ] . Value = _model . EB004;
            parameter [ 4 ] . Value = _model . EB005;
            parameter [ 5 ] . Value = _model . EB009;
            parameter [ 6 ] . Value = _model . EB010;
            parameter [ 7 ] . Value = _model . EB011;

            SQLString . Add ( strSql ,parameter );
        }
        void editJM ( MulaolaoLibrary . MaterialEntity _model ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQEB SET " );
            strSql . Append ( "EB009=@EB009," );
            strSql . Append ( "EB010=@EB010," );
            strSql . Append ( "EB011=@EB011 " );
            strSql . Append ( "WHERE EB002=@EB002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@EB002",SqlDbType.NVarChar,50),
                new SqlParameter("@EB009",SqlDbType.Decimal,18),
                new SqlParameter("@EB010",SqlDbType.Decimal,18),
                new SqlParameter("@EB011",SqlDbType.Decimal,18)
            };
            parameter [ 0 ] . Value = _model . EB002;
            parameter [ 1 ] . Value = _model . EB009;
            parameter [ 2 ] . Value = _model . EB010;
            parameter [ 3 ] . Value = _model . EB011;

            SQLString . Add ( strSql ,parameter );
        }

        void addPlastic ( MulaolaoLibrary . MaterialEntity _model ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQEB (" );
            strSql . Append ( "EB001,EB002,EB003,EB004,EB005,EB012,EB013,EB014) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@EB001,@EB002,@EB003,@EB004,@EB005,@EB012,@EB013,@EB014) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@EB001",SqlDbType.NVarChar,50),
                new SqlParameter("@EB002",SqlDbType.NVarChar,50),
                new SqlParameter("@EB003",SqlDbType.NVarChar,50),
                new SqlParameter("@EB004",SqlDbType.Int,4),
                new SqlParameter("@EB005",SqlDbType.Date,3),
                new SqlParameter("@EB012",SqlDbType.Decimal,18),
                new SqlParameter("@EB013",SqlDbType.Decimal,18),
                new SqlParameter("@EB014",SqlDbType.Decimal,18)
            };
            parameter [ 0 ] . Value = _model . EB001;
            parameter [ 1 ] . Value = _model . EB002;
            parameter [ 2 ] . Value = _model . EB003;
            parameter [ 3 ] . Value = _model . EB004;
            parameter [ 4 ] . Value = _model . EB005;
            parameter [ 5 ] . Value = _model . EB012;
            parameter [ 6 ] . Value = _model . EB013;
            parameter [ 7 ] . Value = _model . EB014;

            SQLString . Add ( strSql ,parameter );
        }
        void editPlastic ( MulaolaoLibrary . MaterialEntity _model ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQEB SET " );
            strSql . Append ( "EB012=@EB012," );
            strSql . Append ( "EB013=@EB013," );
            strSql . Append ( "EB014=@EB014 " );
            strSql . Append ( "WHERE EB002=@EB002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@EB002",SqlDbType.NVarChar,50),
                new SqlParameter("@EB012",SqlDbType.Decimal,18),
                new SqlParameter("@EB013",SqlDbType.Decimal,18),
                new SqlParameter("@EB014",SqlDbType.Decimal,18)
            };
            parameter [ 0 ] . Value = _model . EB002;
            parameter [ 1 ] . Value = _model . EB012;
            parameter [ 2 ] . Value = _model . EB013;
            parameter [ 3 ] . Value = _model . EB014;

            SQLString . Add ( strSql ,parameter );
        }

        void addCarWood ( MulaolaoLibrary . MaterialEntity _model ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQEB (" );
            strSql . Append ( "EB001,EB002,EB003,EB004,EB005,EB015,EB016,EB017) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@EB001,@EB002,@EB003,@EB004,@EB005,@EB015,@EB016,@EB017) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@EB001",SqlDbType.NVarChar,50),
                new SqlParameter("@EB002",SqlDbType.NVarChar,50),
                new SqlParameter("@EB003",SqlDbType.NVarChar,50),
                new SqlParameter("@EB004",SqlDbType.Int,4),
                new SqlParameter("@EB005",SqlDbType.Date,3),
                new SqlParameter("@EB015",SqlDbType.Decimal,18),
                new SqlParameter("@EB016",SqlDbType.Decimal,18),
                new SqlParameter("@EB017",SqlDbType.Decimal,18)
            };
            parameter [ 0 ] . Value = _model . EB001;
            parameter [ 1 ] . Value = _model . EB002;
            parameter [ 2 ] . Value = _model . EB003;
            parameter [ 3 ] . Value = _model . EB004;
            parameter [ 4 ] . Value = _model . EB005;
            parameter [ 5 ] . Value = _model . EB015;
            parameter [ 6 ] . Value = _model . EB016;
            parameter [ 7 ] . Value = _model . EB017;

            SQLString . Add ( strSql ,parameter );
        }
        void editCarWood ( MulaolaoLibrary . MaterialEntity _model ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQEB SET " );
            strSql . Append ( "EB015=@EB015," );
            strSql . Append ( "EB016=@EB016," );
            strSql . Append ( "EB017=@EB017 " );
            strSql . Append ( "WHERE EB002=@EB002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@EB002",SqlDbType.NVarChar,50),
                new SqlParameter("@EB015",SqlDbType.Decimal,18),
                new SqlParameter("@EB016",SqlDbType.Decimal,18),
                new SqlParameter("@EB017",SqlDbType.Decimal,18)
            };
            parameter [ 0 ] . Value = _model . EB002;
            parameter [ 1 ] . Value = _model . EB015;
            parameter [ 2 ] . Value = _model . EB016;
            parameter [ 3 ] . Value = _model . EB017;

            SQLString . Add ( strSql ,parameter );
        }

        void addOutSource ( MulaolaoLibrary . MaterialEntity _model ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQEB (" );
            strSql . Append ( "EB001,EB002,EB003,EB004,EB005,EB018,EB019,EB020) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@EB001,@EB002,@EB003,@EB004,@EB005,@EB018,@EB019,@EB020) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@EB001",SqlDbType.NVarChar,50),
                new SqlParameter("@EB002",SqlDbType.NVarChar,50),
                new SqlParameter("@EB003",SqlDbType.NVarChar,50),
                new SqlParameter("@EB004",SqlDbType.Int,4),
                new SqlParameter("@EB005",SqlDbType.Date,3),
                new SqlParameter("@EB018",SqlDbType.Decimal,18),
                new SqlParameter("@EB019",SqlDbType.Decimal,18),
                new SqlParameter("@EB020",SqlDbType.Decimal,18)
            };
            parameter [ 0 ] . Value = _model . EB001;
            parameter [ 1 ] . Value = _model . EB002;
            parameter [ 2 ] . Value = _model . EB003;
            parameter [ 3 ] . Value = _model . EB004;
            parameter [ 4 ] . Value = _model . EB005;
            parameter [ 5 ] . Value = _model . EB018;
            parameter [ 6 ] . Value = _model . EB019;
            parameter [ 7 ] . Value = _model . EB020;

            SQLString . Add ( strSql ,parameter );
        }
        void editOutSource ( MulaolaoLibrary . MaterialEntity _model ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQEB SET " );
            strSql . Append ( "EB018=@EB018," );
            strSql . Append ( "EB019=@EB019," );
            strSql . Append ( "EB020=@EB020 " );
            strSql . Append ( "WHERE EB002=@EB002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@EB002",SqlDbType.NVarChar,50),
                new SqlParameter("@EB018",SqlDbType.Decimal,18),
                new SqlParameter("@EB019",SqlDbType.Decimal,18),
                new SqlParameter("@EB020",SqlDbType.Decimal,18)
            };
            parameter [ 0 ] . Value = _model . EB002;
            parameter [ 1 ] . Value = _model . EB018;
            parameter [ 2 ] . Value = _model . EB019;
            parameter [ 3 ] . Value = _model . EB020;

            SQLString . Add ( strSql ,parameter );
        }

        void addCarton ( MulaolaoLibrary . MaterialEntity _model ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQEB (" );
            strSql . Append ( "EB001,EB002,EB003,EB004,EB005,EB021,EB022,EB023) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@EB001,@EB002,@EB003,@EB004,@EB005,@EB021,@EB022,@EB023) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@EB001",SqlDbType.NVarChar,50),
                new SqlParameter("@EB002",SqlDbType.NVarChar,50),
                new SqlParameter("@EB003",SqlDbType.NVarChar,50),
                new SqlParameter("@EB004",SqlDbType.Int,4),
                new SqlParameter("@EB005",SqlDbType.Date,3),
                new SqlParameter("@EB021",SqlDbType.Decimal,18),
                new SqlParameter("@EB022",SqlDbType.Decimal,18),
                new SqlParameter("@EB023",SqlDbType.Decimal,18)
            };
            parameter [ 0 ] . Value = _model . EB001;
            parameter [ 1 ] . Value = _model . EB002;
            parameter [ 2 ] . Value = _model . EB003;
            parameter [ 3 ] . Value = _model . EB004;
            parameter [ 4 ] . Value = _model . EB005;
            parameter [ 5 ] . Value = _model . EB021;
            parameter [ 6 ] . Value = _model . EB022;
            parameter [ 7 ] . Value = _model . EB023;

            SQLString . Add ( strSql ,parameter );
        }
        void editCarton ( MulaolaoLibrary . MaterialEntity _model ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQEB SET " );
            strSql . Append ( "EB021=@EB021," );
            strSql . Append ( "EB022=@EB022," );
            strSql . Append ( "EB023=@EB023 " );
            strSql . Append ( "WHERE EB002=@EB002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@EB002",SqlDbType.NVarChar,50),
                new SqlParameter("@EB021",SqlDbType.Decimal,18),
                new SqlParameter("@EB022",SqlDbType.Decimal,18),
                new SqlParameter("@EB023",SqlDbType.Decimal,18)
            };
            parameter [ 0 ] . Value = _model . EB002;
            parameter [ 1 ] . Value = _model . EB021;
            parameter [ 2 ] . Value = _model . EB022;
            parameter [ 3 ] . Value = _model . EB023;

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 是否存在此流水号
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        bool Exists ( MulaolaoLibrary . MaterialEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM R_PQEB WHERE EB002='{0}'" ,_model . EB002 );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 木材料
        /// </summary>
        /// <returns></returns>
        DataTable getWood ( string strWhere,string num )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT A.AM002,A.AM003,A.AM006,PQF31,A.AM005,CONVERT(DECIMAL(11,2),CASE WHEN AM006=0 THEN 0 ELSE (AM336+AM343+AM361+AM346+AM349+AM367+AM352+AM370+AM355+AM153+AM339+AM364)/AM006 END) YWOODNOW,ISNULL((SELECT CONVERT(DECIMAL(11,2),CASE WHEN AM006=0 THEN 0 ELSE (AM336+AM343+AM361+AM346+AM349+AM367+AM352+AM370+AM355+AM153+AM339+AM364)/AM006 END) SWOODNOW FROM R_PQAM WHERE AM002 IN (SELECT MAX(AM002) AM002 FROM R_PQAM B WHERE B.AM002<A.AM002 AND B.AM005=A.AM005 GROUP BY B.AM005)),0) SWOODNOW,ISNULL(GS04,0) GS04 FROM R_PQAM A INNER JOIN R_PQF B ON A.AM002=B.PQF01 " );
            if ( !string . IsNullOrEmpty ( num ) )
                strSql . AppendFormat ( "LEFT JOIN (SELECT PQV01,SUM(ISNULL(GS04,0)) GS04 FROM (SELECT A.idx,PQV01,CONVERT(DECIMAL(6,2),GS11*GS10) GS04 FROM R_PQV A LEFT JOIN R_PQP C ON A.PQV01=C.GS01 AND C.GS02=A.PQV86 AND C.GS07=A.PQV10) A WHERE PQV01='{0}' GROUP BY PQV01) C ON A.AM002=C.PQV01 WHERE {1}" ,num ,strWhere );
            else
                strSql . AppendFormat ( "LEFT JOIN (SELECT PQV01,SUM(ISNULL(GS04,0)) GS04 FROM (SELECT A.idx,PQV01,CONVERT(DECIMAL(6,2),GS11*GS10) GS04 FROM R_PQV A LEFT JOIN R_PQP C ON A.PQV01=C.GS01 AND C.GS02=A.PQV86 AND C.GS07=A.PQV10) A GROUP BY PQV01) C ON A.AM002=C.PQV01 WHERE {0}" ,strWhere );


            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 胶板料
        /// </summary>
        /// <returns></returns>
        DataTable getJM ( string strWhere ,string num )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT A.AM002,A.AM003,A.AM006,PQF31,A.AM005,CONVERT(DECIMAL(11,2),CASE WHEN AM006=0 THEN 0 ELSE (AM298+AM301+AM307+AM311)/AM006 END) YWOODNOW,ISNULL((SELECT CONVERT(DECIMAL(11,2),CASE WHEN AM006=0 THEN 0 ELSE (AM298+AM301+AM307+AM311)/AM006 END) SWOODNOW FROM R_PQAM WHERE AM002 IN (SELECT MAX(AM002) AM002 FROM R_PQAM B WHERE B.AM002<A.AM002 AND B.AM005=A.AM005 GROUP BY B.AM005)),0) SWOODNOW,ISNULL(GS04,0) GS04 FROM R_PQAM A INNER JOIN R_PQF B ON A.AM002=B.PQF01 LEFT JOIN " );
            if ( !string . IsNullOrEmpty ( num ) )
                strSql . AppendFormat ( "(SELECT JM90,SUM(ISNULL(GS04,0)) GS04 FROM (SELECT JM90,ISNULL((SELECT TOP 1  CONVERT(DECIMAL(6,2),GS10*GS11) GS04 FROM R_PQP B WHERE A.JM09=B.GS02 AND A.JM90=B.GS01),0) GS04 FROM R_PQO A WHERE JM90='{1}' GROUP BY JM90,JM09,JM94,JM95,JM96) A GROUP BY JM90 ) C ON A.AM002=C.JM90 WHERE {0}" ,strWhere ,num );
            else
                strSql . AppendFormat ( "(SELECT JM90,SUM(ISNULL(GS04,0)) GS04 FROM (SELECT JM90,ISNULL((SELECT TOP 1  CONVERT(DECIMAL(6,2),GS10*GS11) GS04 FROM R_PQP B WHERE A.JM09=B.GS02 AND A.JM90=B.GS01),0) GS04 FROM R_PQO A GROUP BY JM90,JM09,JM94,JM95,JM96) A GROUP BY JM90 ) C ON A.AM002=C.JM90 WHERE {0}" ,strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 车木件
        /// </summary>
        /// <returns></returns>
        DataTable getCarWood ( string strWhere ,string num )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT A.AM002,A.AM003,A.AM006,PQF31,A.AM005,CONVERT(DECIMAL(11,2),CASE WHEN AM006=0 THEN 0 ELSE (AM270+AM273)/AM006 END) YWOODNOW,ISNULL((SELECT CONVERT(DECIMAL(11,2),CASE WHEN AM006=0 THEN 0 ELSE (AM270+AM273)/AM006 END) SWOODNOW FROM R_PQAM WHERE AM002 IN (SELECT MAX(AM002) AM002 FROM R_PQAM B WHERE B.AM002<A.AM002 AND B.AM005=A.AM005 GROUP BY B.AM005)),0) SWOODNOW,ISNULL(GS04,0) GS04 FROM R_PQAM A INNER JOIN R_PQF B ON A.AM002=B.PQF01 " );
            if ( !string . IsNullOrEmpty ( num ) )
                strSql . AppendFormat ( "LEFT JOIN (SELECT AF002,SUM(GS04) GS04 FROM (SELECT A.idx,AF002,CONVERT(DECIMAL(6,2),(SELECT TOP 1 GS10*GS11 FROM R_PQP A WHERE AF002=GS01 AND AF015=GS07)) GS04 FROM R_PQAF A  WHERE AF002='{0}') A GROUP BY AF002) C ON A.AM002=C.AF002 WHERE {1}" ,num ,strWhere );
            else
                strSql . AppendFormat ( "LEFT JOIN (SELECT AF002,SUM(GS04) GS04 FROM (SELECT A.idx,AF002,CONVERT(DECIMAL(6,2),(SELECT TOP 1 GS10*GS11 FROM R_PQP A WHERE AF002=GS01 AND AF015=GS07)) GS04 FROM R_PQAF A) A GROUP BY AF002) C ON A.AM002=C.AF002 WHERE {0}" ,strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 塑.铁.布
        /// </summary>
        /// <returns></returns>
        DataTable getPlastic ( string strWhere,string num )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT A.AM002,A.AM003,A.AM006,PQF31,A.AM005,CONVERT(DECIMAL(11,2),CASE WHEN AM006=0 THEN 0 ELSE (AM209+AM212+AM215+AM218)/AM006 END) YWOODNOW,ISNULL((SELECT CONVERT(DECIMAL(11,2),CASE WHEN AM006=0 THEN 0 ELSE (AM209+AM212+AM215+AM218)/AM006 END) SWOODNOW FROM R_PQAM WHERE AM002 IN (SELECT MAX(AM002) AM002 FROM R_PQAM B WHERE B.AM002<A.AM002 AND B.AM005=A.AM005 GROUP BY B.AM005)),0) SWOODNOW,ISNULL(C.GS04,0)+ISNULL(D.GS04,0) GS04 FROM R_PQAM A INNER JOIN R_PQF B ON A.AM002=B.PQF01 " );
            if ( !string . IsNullOrEmpty ( num ) )
                strSql . AppendFormat ( "LEFT JOIN (SELECT PQU01,SUM(GS04) GS04 FROM (SELECT A.idx,PQU01,ISNULL((SELECT SUM(CONVERT(DECIMAL(6,2),GS10*GS11)) GS FROM R_PQP B WHERE A.PQU01=B.GS01 AND A.PQU10=B.GS07),0) GS04 FROM R_PQU A WHERE PQU01='{0}' ) A GROUP BY PQU01) C ON A.AM002=C.PQU01 LEFT JOIN (SELECT PJ01,SUM(GS04) GS04 FROM (SELECT A.idx,PJ01,ISNULL((SELECT CONVERT(DECIMAL(6,2),B.GS04)  FROM (SELECT DISTINCT GS10*GS11 GS04,GS01,GS07 FROM R_PQP UNION SELECT DISTINCT GS60*GS59 GS04,GS01,GS56 FROM R_PQP) B WHERE A.PJ01=B.GS01 AND A.PJ09=B.GS07),0) GS04  FROM R_PQS A WHERE PJ01='{0}') A GROUP BY PJ01) D ON A.AM002=D.PJ01 WHERE {1}" ,num ,strWhere );
            else
                strSql . AppendFormat ( "LEFT JOIN (SELECT PQU01,SUM(GS04) GS04 FROM (SELECT A.idx,PQU01,ISNULL((SELECT SUM(CONVERT(DECIMAL(6,2),GS10*GS11)) GS FROM R_PQP B WHERE A.PQU01=B.GS01 AND A.PQU10=B.GS07),0) GS04 FROM R_PQU A ) A GROUP BY PQU01) C ON A.AM002=C.PQU01 LEFT JOIN (SELECT PJ01,SUM(GS04) GS04 FROM (SELECT A.idx,PJ01,ISNULL((SELECT SUM(CONVERT(DECIMAL(6,2),B.GS04))  FROM (SELECT DISTINCT GS10*GS11 GS04,GS01,GS07 FROM R_PQP UNION SELECT DISTINCT GS60*GS59 GS04,GS01,GS56 FROM R_PQP) B WHERE A.PJ01=B.GS01 AND A.PJ09=B.GS07),0) GS04  FROM R_PQS A ) A GROUP BY PJ01) D ON A.AM002=D.PJ01 WHERE {0}" ,strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 委外加工
        /// </summary>
        /// <returns></returns>
        DataTable getOutSource ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT A.AM002,A.AM003,A.AM006,PQF31,A.AM005,CONVERT(DECIMAL(11,2),CASE WHEN AM006=0 THEN 0 ELSE (AM108+AM111)/AM006 END) YWOODNOW,ISNULL((SELECT CONVERT(DECIMAL(11,2),CASE WHEN AM006=0 THEN 0 ELSE (AM108+AM111)/AM006 END) SWOODNOW FROM R_PQAM WHERE AM002 IN (SELECT MAX(AM002) AM002 FROM R_PQAM B WHERE B.AM002<A.AM002 AND B.AM005=A.AM005 GROUP BY B.AM005)),0) SWOODNOW FROM R_PQAM A INNER JOIN R_PQF B ON A.AM002=B.PQF01 WHERE {0}",strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 纸箱
        /// </summary>
        /// <returns></returns>
        DataTable getCarton ( string strWhere ,string num )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT A.AM002,A.AM003,A.AM006,PQF31,A.AM005,CONVERT(DECIMAL(11,2),CASE WHEN AM006=0 THEN 0 ELSE (AM136+AM139+AM142+AM145+AM148+AM138)/AM006 END) YWOODNOW,ISNULL((SELECT CONVERT(DECIMAL(11,2),CASE WHEN AM006=0 THEN 0 ELSE (AM136+AM139+AM142+AM145+AM148+AM138)/AM006 END) SWOODNOW FROM R_PQAM WHERE AM002 IN (SELECT MAX(AM002) AM002 FROM R_PQAM B WHERE B.AM002<A.AM002 AND B.AM005=A.AM005 GROUP BY B.AM005)),0) SWOODNOW,ISNULL(GS04,0) GS04 FROM R_PQAM A INNER JOIN R_PQF B ON A.AM002=B.PQF01 " );
            if ( !string . IsNullOrEmpty ( num ) )
                strSql . AppendFormat ( "LEFT JOIN (SELECT WX01,SUM(ISNULL(GS04,0)) GS04 FROM (SELECT A.idx,WX01,ISNULL((SELECT TOP 1 CONVERT(DECIMAL(6,2),GS59*GS60) FROM R_PQP B WHERE A.WX01=B.GS01 AND A.WX10=B.GS56),0) GS04 FROM R_PQT A WHERE WX01='{0}') A GROUP BY WX01) C ON A.AM002=C.WX01 WHERE {1}" ,num ,strWhere );
            else
                strSql . AppendFormat ( "LEFT JOIN (SELECT WX01,SUM(ISNULL(GS04,0)) GS04 FROM (SELECT A.idx,WX01,ISNULL((SELECT TOP 1 CONVERT(DECIMAL(6,2),GS59*GS60) FROM R_PQP B WHERE A.WX01=B.GS01 AND A.WX10=B.GS56),0) GS04 FROM R_PQT A) A GROUP BY WX01) C ON A.AM002=C.WX01 WHERE {0}" ,strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据库数据
        /// </summary>
        /// <returns></returns>
        public DataTable getTableView ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,EB001,EB002,EB003,EB004,EB005,CONVERT(FLOAT,EB006) EB006,CONVERT(FLOAT,EB007) EB007,CONVERT(FLOAT,EB008) EB008,CONVERT(FLOAT,EB009) EB009,CONVERT(FLOAT,EB010) EB010,CONVERT(FLOAT,EB011) EB011,CONVERT(FLOAT,EB012) EB012,CONVERT(FLOAT,EB013) EB013,CONVERT(FLOAT,EB014) EB014,CONVERT(FLOAT,EB015) EB015,CONVERT(FLOAT,EB016) EB016,CONVERT(FLOAT,EB017) EB017,CONVERT(FLOAT,EB018) EB018,CONVERT(FLOAT,EB019) EB019,CONVERT(FLOAT,EB020) EB020,CONVERT(FLOAT,EB021) EB021,CONVERT(FLOAT,EB022) EB022,CONVERT(FLOAT,EB023) EB023,CONVERT(FLOAT,EB024) EB024,CONVERT(FLOAT,EB025) EB025,CONVERT(FLOAT,EB026) EB026,CONVERT(FLOAT,EB027) EB027,CONVERT(FLOAT,EB028) EB028,EB029,EB030,CONVERT(FLOAT,EB031) EB031 FROM R_PQEB " );
            strSql . Append ( " WHERE " + strWhere );

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

            MulaolaoLibrary . MaterialEntity _model = new MulaolaoLibrary . MaterialEntity ( );
            if ( table != null && table . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < table . Rows . Count ; i++ )
                {
                    _model . EB002 = table . Rows [ i ] [ "EB002" ] . ToString ( );
                    _model . EB024 = string . IsNullOrEmpty ( table . Rows [ i ] [ "EB024" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "EB024" ] . ToString ( ) );
                    _model . EB025 = string . IsNullOrEmpty ( table . Rows [ i ] [ "EB025" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "EB025" ] . ToString ( ) );
                    _model . EB026 = string . IsNullOrEmpty ( table . Rows [ i ] [ "EB026" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "EB026" ] . ToString ( ) );
                    _model . EB027 = string . IsNullOrEmpty ( table . Rows [ i ] [ "EB027" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "EB027" ] . ToString ( ) );
                    _model . EB028 = string . IsNullOrEmpty ( table . Rows [ i ] [ "EB028" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "EB028" ] . ToString ( ) );
                    _model . EB031 = string . IsNullOrEmpty ( table . Rows [ i ] [ "EB031" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "EB031" ] . ToString ( ) );
                    _model . EB029 = table . Rows [ i ] [ "EB029" ] . ToString ( );
                    _model . EB030 = table . Rows [ i ] [ "EB030" ] . ToString ( );
                    editAll ( SQLString ,strSql ,_model );
                }
            }
            else
                return false;

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void editAll ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . MaterialEntity _model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQEB SET " );
            strSql . Append ( "EB024=@EB024," );
            strSql . Append ( "EB025=@EB025," );
            strSql . Append ( "EB026=@EB026," );
            strSql . Append ( "EB027=@EB027," );
            strSql . Append ( "EB028=@EB028," );
            strSql . Append ( "EB029=@EB029," );
            strSql . Append ( "EB030=@EB030," );
            strSql . Append ( "EB031=@EB031 " );
            strSql . Append ( "WHERE EB002=@EB002 " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@EB002",SqlDbType.NVarChar,50),
                new SqlParameter("@EB024",SqlDbType.Decimal,18),
                new SqlParameter("@EB025",SqlDbType.Decimal,18),
                new SqlParameter("@EB026",SqlDbType.Decimal,18),
                new SqlParameter("@EB027",SqlDbType.Decimal,18),
                new SqlParameter("@EB028",SqlDbType.Decimal,18),
                new SqlParameter("@EB029",SqlDbType.NVarChar,50),
                new SqlParameter("@EB030",SqlDbType.NVarChar,50),
                new SqlParameter("@EB031",SqlDbType.Decimal,18),
            };
            parameter [ 0 ] . Value = _model . EB002;
            parameter [ 1 ] . Value = _model . EB024;
            parameter [ 2 ] . Value = _model . EB025;
            parameter [ 3 ] . Value = _model . EB026;
            parameter [ 4 ] . Value = _model . EB027;
            parameter [ 5 ] . Value = _model . EB028;
            parameter [ 6 ] . Value = _model . EB029;
            parameter [ 7 ] . Value = _model . EB030;
            parameter [ 8 ] . Value = _model . EB031;

            SQLString . Add ( strSql ,parameter );
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

    }
}

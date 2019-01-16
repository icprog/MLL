using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using StudentMgr;
using System.Data.SqlClient;
using System.Collections;

namespace MulaolaoBll.Dao
{
    public class ContractUncollectUnpaidDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string strWhere)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT QZ009,QZ001,QZ002,QZ003,QZ004,QZ005,QZ006,QZ007,QZ008,RZ002,CASE WHEN QZ009=YEAR(GETDATE()) THEN QZ021 ELSE 0 END QZ021,CASE WHEN QZ009=YEAR(GETDATE())-1 THEN QZ021 ELSE 0 END QZ020,CASE WHEN QZ009=YEAR(GETDATE())-2 THEN QZ021 ELSE 0 END QZ019,CASE WHEN QZ009=YEAR(GETDATE())-3 THEN QZ021 ELSE 0 END QZ018  FROM (SELECT QZ009,QZ001,SUM(QZ002) QZ002,SUM(QZ003) QZ003,SUM(QZ004) QZ004,SUM(QZ005) QZ005,SUM(QZ006) QZ006,SUM(QZ007) QZ007,SUM(QZ008) QZ008,RZ002,ISNULL(SUM(ISNULL(U24,0)+ISNULL(U29,0)+ISNULL(U34,0)+ISNULL(U39,0)+ISNULL(U44,0)+ISNULL(U49,0)+ISNULL(U54,0)+ISNULL(U59,0)+ISNULL(U64,0)+ISNULL(U69,0)+ISNULL(U74,0)),0)-ISNULL(SUM(ISNULL(U26,0)+ISNULL(U31,0)+ISNULL(U36,0)+ISNULL(U41,0)+ISNULL(U46,0)+ISNULL(U51,0)+ISNULL(U56,0)+ISNULL(U61,0)+ISNULL(U66,0)+ISNULL(U71,0)+ISNULL(U76,0)),0) QZ021 FROM (SELECT AE02,YEAR(AE17) QZ009,RZ002,MONTH(AE17) QZ001,AE06 QZ002,AE19 QZ003,SUM(AE37) QZ004,CASE WHEN AE12=0 THEN SUM(CONVERT(DECIMAL(18,2),AE10*AE37)) ELSE SUM(CONVERT(DECIMAL(18,2),AE12*AE37)) END QZ005,SUM(AE26) QZ006,CASE WHEN AE12=0 THEN SUM(CONVERT(DECIMAL(18,2),AE10*AE26)) ELSE SUM(CONVERT(DECIMAL(18,2),AE12*AE26)) END QZ007,SUM(CONVERT(DECIMAL(18,2),AE28+AE30+AE29*AE11)) QZ008 FROM R_PQAE A LEFT JOIN R_PQRZ B ON YEAR(AE17)=B.RZ001" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( " GROUP BY AE02,AE17,AE19,AE12,AE06,RZ002 )A " );
            strSql.Append( " LEFT JOIN (SELECT AM002,AM330+AM333+AM336+AM339+AM343+AM346+AM349+AM352+AM355+AM358+AM361+AM364+AM367+AM370+AM373+AM376+AM379+AM385+AM388+AM391 U24,AM331+AM334+AM337+AM340+AM344+AM347+AM350+AM353+AM356+AM359+AM362+AM365+AM368+AM371+AM374+AM377+AM380+AM386+AM389+AM392 U26,AM298 +  AM301 + AM304 + AM307 + AM311 + AM315 + AM318 + AM321 U29,AM299 + AM302 + AM305 + AM308 + AM312 + AM316 + AM319 + AM322 U31,AM270 + AM273 + AM277 + AM280 U34,AM271 + AM274 + AM278 + AM281 U36,AM239 + AM242 + AM245 + AM249 + AM252 + AM255 + AM258 + AM261 + AM264 + AM267+AM249 U39,AM240 + AM243 + AM246 + AM250 + AM253 + AM256 + AM259 + AM262 + AM265 + AM268+AM250 U41,AM209 + AM212 + AM215 U44,AM210 + AM213 + AM216 U46,AM175 + AM178 + AM182 + AM185 + AM188 + AM191 + AM194 + AM197 U49,AM176 + AM179 + AM183 + AM186+AM189+AM192+AM195+AM198 U51,AM136+AM139 + AM142 + AM145 + AM148+AM218 U54,AM137 + AM140 + AM143 + AM146 + AM149 + AM219 U56,AM108 + AM111 U59,AM109 + AM112 U61,AM070 + AM072 + AM074 + AM076 + AM078 + AM080 + AM082 + AM084 + AM086 + AM088 + AM090 + AM092 U64,AM071 + AM073 + AM075 + AM077 + AM079 + AM081 + AM083 + AM085 + AM087 + AM089 + AM091 + AM093 U66,AM044 + AM046 + AM048 + AM050 + AM052 + AM054 U69,AM045 + AM047 + AM049 + AM051 + AM053 + AM055 U71,AM020 + AM022 + AM024 + AM026 + AM028 U74,AM021 + AM023 + AM025 + AM027 + AM029 U76  FROM R_PQAM) B ON A.AE02=B.AM002" );
            strSql.Append( " GROUP BY QZ009,QZ001,RZ002) A" );
            
            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ); 
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable (int year )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQRZ" );
            strSql.Append( " WHERE RZ001=@RZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@RZ001",SqlDbType.Int)
            };
            parameter[0].Value = year;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public bool Exists ( int year )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQRZ" );
            strSql.Append( " WHERE RZ001=@RZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@RZ001",SqlDbType.Int)
            };
            parameter[0].Value = year;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }
        public bool ExistsIdx ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQRZ" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = idx;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.ContractUncollectUnpaid _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQRZ SET " );
            strSql.Append( "RZ002=@RZ002," );
            strSql.Append( "RZ006=@RZ006" );
            strSql.Append( " WHERE RZ001=@RZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@RZ002",SqlDbType.Decimal,6),
                new SqlParameter("@RZ006",SqlDbType.Decimal,6),
                new SqlParameter("@RZ001",SqlDbType.Int)
            };
            parameter[0].Value = _model.RZ002;
            parameter[1].Value = _model.RZ006;
            parameter[2].Value = _model.RZ001;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }
        public bool UpdateOther ( MulaolaoLibrary.ContractUncollectUnpaid _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQRZ SET " );
            strSql.Append( "RZ005=@RZ005," );
            strSql.Append( "RZ008=@RZ008," );
            strSql.Append( "RZ016=@RZ016," );
            strSql.Append( "RZ017=@RZ017" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@RZ005",SqlDbType.Int),
                new SqlParameter("@RZ008",SqlDbType.Int),
                new SqlParameter("@RZ016",SqlDbType.Int),
                new SqlParameter("@RZ017",SqlDbType.Int),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = _model.RZ005;
            parameter[1].Value = _model.RZ008;
            parameter[2].Value = _model.RZ016;
            parameter[3].Value = _model.RZ017;
            parameter[4].Value = _model.IDX;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 录入一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Insert ( MulaolaoLibrary.ContractUncollectUnpaid _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQRZ (" );
            strSql.Append( "RZ001,RZ002)" );
            strSql.Append( " VALUES (" );
            strSql.Append( "@RZ001,@RZ002);" );
            SqlParameter[] parameter = {
                new SqlParameter("@RZ001",SqlDbType.Int),
                new SqlParameter("@RZ002",SqlDbType.Decimal,6)
            };
            parameter[0].Value = _model.RZ001;
            parameter[1].Value = _model.RZ002;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// Generate
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Add ( MulaolaoLibrary.ContractUncollectUnpaid _model)
        {
            ArrayList SQLString = new ArrayList( );
            bool result = false;
            DataTable da = GetDataTableOne( _model.RZ001 );
            if ( da != null && da.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < da.Rows.Count ; i++ )
                {
                    _model.RZ003 = string.IsNullOrEmpty( da.Rows[i]["AE14"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[i]["AE14"].ToString( ) );
                    _model.RZ009 = string.IsNullOrEmpty( da.Rows[i]["AE06"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[i]["AE06"].ToString( ) );
                    _model.RZ010 = string.IsNullOrEmpty( da.Rows[i]["AE19"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[i]["AE19"].ToString( ) );
                    _model.RZ011 = string.IsNullOrEmpty( da.Rows[i]["AE37"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[i]["AE37"].ToString( ) );
                    _model.RZ012 = string.IsNullOrEmpty( da.Rows[i]["AE3"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[i]["AE3"].ToString( ) );
                    _model.RZ013 = string.IsNullOrEmpty( da.Rows[i]["AE26"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[i]["AE26"].ToString( ) );
                    _model.RZ014 = string.IsNullOrEmpty( da.Rows[i]["AE2"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[i]["AE2"].ToString( ) );
                    _model.RZ015 = string.IsNullOrEmpty( da.Rows[i]["AE28"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[i]["AE28"].ToString( ) );
                    _model . RZ020 = _model . RZ010 - ( string . IsNullOrEmpty ( da . Rows [ i ] [ "AE8" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "AE8" ] . ToString ( ) ) );
                    _model . RZ021 = ( string . IsNullOrEmpty ( da . Rows [ i ] [ "U12" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "U12" ] . ToString ( ) ) );
                    _model . RZ022 = ( string . IsNullOrEmpty ( da . Rows [ i ] [ "U13" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "U13" ] . ToString ( ) ) );
                    _model . RZ023 = string . IsNullOrEmpty ( da . Rows [ i ] [ "AE610" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "AE610" ] . ToString ( ) );
                    _model . RZ024 = string . IsNullOrEmpty ( da . Rows [ i ] [ "AE611" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "AE611" ] . ToString ( ) );
                    if ( Exists( _model.RZ001 ,_model.RZ003 ) )
                        SQLString.Add( UpdateOne( _model ) );
                    else
                        SQLString.Add( AddOne( _model ) );
                }
            }

            if ( SQLString != null && SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                da = GetDataTableOneOther ( _model . RZ001 );
                if ( da != null && da . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < da . Rows . Count ; i++ )
                    {
                        _model . RZ003 = string . IsNullOrEmpty ( da . Rows [ i ] [ "AE14" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "AE14" ] . ToString ( ) );
                        _model . RZ010 = string . IsNullOrEmpty ( da . Rows [ i ] [ "AE19" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "AE19" ] . ToString ( ) );
                        _model . RZ015 = string . IsNullOrEmpty ( da . Rows [ i ] [ "AE28" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "AE28" ] . ToString ( ) );
                        _model . RZ020 = _model . RZ010 - ( string . IsNullOrEmpty ( da . Rows [ i ] [ "AE8" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "AE8" ] . ToString ( ) ) );
                        _model . RZ021 = ( string . IsNullOrEmpty ( da . Rows [ i ] [ "U12" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "U12" ] . ToString ( ) ) );
                        _model . RZ022 = ( string . IsNullOrEmpty ( da . Rows [ i ] [ "U13" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "U13" ] . ToString ( ) ) );
                        if ( Exists ( _model . RZ001 ,_model . RZ003 ) )
                            SQLString . Add ( UpdateOneOther ( _model ) );
                    }
                }

            }
            else
                return false;

            if (SQLString!=null && SqlHelper.ExecuteSqlTran( SQLString ) )
            {
                result = true;
                SQLString = new ArrayList( );
                DataTable de = GetDataTableTwo( _model.RZ001 );
                if ( de != null && de.Rows.Count > 0 )
                {
                    for ( int i = 0 ; i < de.Rows.Count ; i++ )
                    {
                        _model.RZ003 = string.IsNullOrEmpty( de.Rows[i]["monthP"].ToString( ) ) == true ? 0 : Convert.ToInt32( de.Rows[i]["monthP"].ToString( ) );
                        int x= string.IsNullOrEmpty( de.Rows[i]["yearP"].ToString( ) ) == true ? 0 : Convert.ToInt32( de.Rows[i]["yearP"].ToString( ) );
                        if ( x == _model . RZ001 - 2 )
                        {
                            _model . RZ016 = string . IsNullOrEmpty ( de . Rows [ i ] [ "QZ021" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( de . Rows [ i ] [ "QZ021" ] . ToString ( ) );
                            //if ( x == _model.RZ001 - 1 )
                            //    _model.RZ017 = string.IsNullOrEmpty( de.Rows[i]["QZ021"].ToString( ) ) == true ? 0 : Convert.ToInt32( de.Rows[i]["QZ021"].ToString( ) );
                            //else
                            //    _model.RZ017 = 0;
                            _model . RZ018 = 0;
                            //_model.RZ019 = string.IsNullOrEmpty( de.Rows[i]["QZ021"].ToString( ) ) == true ? 0 : Convert.ToInt32( de.Rows[i]["QZ021"].ToString( ) );
                            if ( Exists ( _model . RZ001 ,_model . RZ003 ) )
                                SQLString . Add ( UpdateTwo ( _model ,"RZ016" ) );
                            else
                                SQLString . Add ( AddTwo ( _model ,"RZ016" ) );
                        }
                    }

                    if ( SQLString != null && SqlHelper . ExecuteSqlTran ( SQLString ) )
                    {
                        SQLString = new ArrayList ( );
                        for ( int i = 0 ; i < de . Rows . Count ; i++ )
                        {
                            _model . RZ003 = string . IsNullOrEmpty ( de . Rows [ i ] [ "monthP" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( de . Rows [ i ] [ "monthP" ] . ToString ( ) );
                            int x = string . IsNullOrEmpty ( de . Rows [ i ] [ "yearP" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( de . Rows [ i ] [ "yearP" ] . ToString ( ) );
                            //if ( x == _model . RZ001 - 2 )
                            //    _model . RZ016 = string . IsNullOrEmpty ( de . Rows [ i ] [ "QZ021" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( de . Rows [ i ] [ "QZ021" ] . ToString ( ) );
                            //else
                            //    _model . RZ016 = 0;
                            if ( x == _model . RZ001 - 1 )
                            {
                                _model . RZ017 = string . IsNullOrEmpty ( de . Rows [ i ] [ "QZ021" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( de . Rows [ i ] [ "QZ021" ] . ToString ( ) );
                                _model . RZ018 = 0;
                                //_model . RZ019 = string . IsNullOrEmpty ( de . Rows [ i ] [ "QZ021" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( de . Rows [ i ] [ "QZ021" ] . ToString ( ) );
                                if ( Exists ( _model . RZ001 ,_model . RZ003 ) )
                                    SQLString . Add ( UpdateTwo ( _model ,"RZ017" ) );
                                else
                                    SQLString . Add ( AddTwo ( _model ,"RZ017" ) );
                            }
                        }
                    }
                    else
                        return false;

                    if ( SQLString != null && SqlHelper . ExecuteSqlTran ( SQLString ) )
                    {
                        SQLString = new ArrayList ( );
                        for ( int i = 0 ; i < de . Rows . Count ; i++ )
                        {
                            _model . RZ003 = string . IsNullOrEmpty ( de . Rows [ i ] [ "monthP" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( de . Rows [ i ] [ "monthP" ] . ToString ( ) );
                            //int x = string . IsNullOrEmpty ( de . Rows [ i ] [ "yearP" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( de . Rows [ i ] [ "yearP" ] . ToString ( ) );
                            //if ( x == _model . RZ001 - 2 )
                            //    _model . RZ016 = string . IsNullOrEmpty ( de . Rows [ i ] [ "QZ021" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( de . Rows [ i ] [ "QZ021" ] . ToString ( ) );
                            //else
                            //    _model . RZ016 = 0;
                            //if ( x == _model . RZ001 - 1 )
                            //    _model . RZ017 = string . IsNullOrEmpty ( de . Rows [ i ] [ "QZ021" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( de . Rows [ i ] [ "QZ021" ] . ToString ( ) );
                            //else
                            //    _model . RZ017 = 0;
                            _model . RZ018 = 0;
                            _model . RZ019 = string . IsNullOrEmpty ( de . Rows [ i ] [ "QZ021" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( de . Rows [ i ] [ "QZ021" ] . ToString ( ) );
                            if ( Exists ( _model . RZ001 ,_model . RZ003 ) )
                                SQLString . Add ( UpdateTwo ( _model ,"RZ019" ) );
                            else
                                SQLString . Add ( AddTwo ( _model ,"RZ019" ) );
                        }
                    }
                    else
                        return false;
                }
            }
            else
                result = false;

            if (SQLString!=null && SqlHelper.ExecuteSqlTran( SQLString ) )
            {
                result = true;
                SQLString = new ArrayList( );
                DataTable dl = GetDataTableTre( _model.RZ001 );
                if ( dl != null && dl.Rows.Count > 0 )
                {
                    for ( int i = 0 ; i < dl.Rows.Count ; i++ )
                    {
                        _model.RZ003 = string.IsNullOrEmpty( dl.Rows[i]["GZ24"].ToString( ) ) == true ? 0 : Convert.ToInt32( dl.Rows[i]["GZ24"].ToString( ) );
                        _model.RZ007 = string.IsNullOrEmpty( dl.Rows[i]["GZ"].ToString( ) ) == true ? 0 : Convert.ToInt32( dl.Rows[i]["GZ"].ToString( ) );
                        if ( Exists( _model.RZ001 ,_model.RZ003 ) )
                            SQLString.Add( UpdateTre( _model ) );
                        else
                            SQLString.Add( AddTre( _model ) );
                    }
                }
            }
            else
                result = false;

            if ( SQLString != null && SqlHelper.ExecuteSqlTran( SQLString ) )
            {
                result = true;
                SQLString = new ArrayList( );
                DataTable dk = GetDataTableFor( _model.RZ001 );
                if ( dk != null && dk.Rows.Count > 0 )
                {
                    _model.RZ003 = 3;
                    _model.RZ004 = string.IsNullOrEmpty( dk.Rows[0]["AC"].ToString( ) ) == true ? 0 : Convert.ToInt32( dk.Rows[0]["AC"].ToString( ) );
                    if ( Exists( _model.RZ001 ,_model.RZ003 ) )
                        SQLString.Add( UpdateFor( _model ) );
                    else
                        SQLString.Add( AddFor( _model ) );
                }
            }
            result = SqlHelper.ExecuteSqlTran( SQLString );

            return result;
        }

        /// <summary>
        /// 获取收款等
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable GetDataTableOne (int year )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT A.AE1,A.AE14,AE06,AE19,AE610,AE611,B.AE37,AE3,AE26,AE2,AE28+AE30+AE29+AE27+AE42 AE8,AE28+AE30+AE2911 AE28,CONVERT(DECIMAL(18,0),ISNULL(B.AE37,0)*ISNULL(AE12,0)-AE28-AE30-AE2911+AE41) U12,AE002-AE28-AE30-AE29+AE40 U13 FROM (" );
            strSql.Append( "SELECT SUM(AE06) AE06,CONVERT(DECIMAL(18,0),SUM(AE19)) AE19,MONTH(AE14) AE14,YEAR(AE14) AE1,CONVERT(DECIMAL(18,0),SUM(AE06*AE10)) AE610,CONVERT(DECIMAL(18,0),SUM(AE06*AE10-ISNULL(AE29,0))) AE611 FROM R_PQAE " );
            strSql.Append( "  WHERE idx IN (SELECT MIN(idx) FROM R_PQAE GROUP BY AE02) AND YEAR(AE14)=@AE14" );
            strSql.Append( " GROUP BY MONTH(AE14),YEAR(AE14)) A" );
            strSql.Append( " LEFT JOIN" );
            strSql.Append( " (SELECT SUM(AE37) AE37,CONVERT(DECIMAL(18,0),SUM(ISNULL(AE37,0)*ISNULL(AE12,0))) AE3,MONTH(AE14) AE14,YEAR(AE14) AE1 FROM R_PQAE" );
            strSql.Append( " WHERE YEAR(AE14)=@AE14" );
            strSql.Append( " GROUP BY MONTH(AE14),YEAR(AE14)) B" );
            strSql.Append( " ON A.AE14=B.AE14 AND A.AE1=B.AE1" );
            strSql.Append( " LEFT JOIN (" );
            strSql.Append( " SELECT SUM(AE26) AE26,CONVERT(DECIMAL(18,0),SUM(CASE WHEN AE39!=0 THEN AE26*AE10*AE39 ELSE AE12*AE26 END)) AE2,MONTH(AE14) AE14,YEAR(AE14) AE1 FROM R_PQAE" ); 
            strSql.Append( " WHERE YEAR(AE14)=@AE14" );
            strSql.Append( " GROUP BY MONTH(AE14),YEAR(AE14)) C" );
            strSql.Append( " ON A.AE14=C.AE14 AND A.AE1=C.AE1" );
            strSql.Append( " LEFT JOIN (" );
            strSql.Append( " SELECT CONVERT(DECIMAL(18,0),SUM(ISNULL(AE29*AE11,0))) AE2911,CONVERT(DECIMAL(18,0),SUM(CASE WHEN AE39!=0 THEN AE26*AE10*AE39 ELSE AE12*AE26 END)) AE002,CONVERT(DECIMAL(18,0),SUM(ISNULL(AE37,0)*ISNULL(AE12,0))) AE37,AE12,CONVERT(DECIMAL(18,0),SUM(ISNULL(AE41,0))) AE41,CONVERT(DECIMAL(18,0),SUM(ISNULL(AE40,0))) AE40,CONVERT(DECIMAL(18,0),SUM(ISNULL(AE28,0))) AE28,CONVERT(DECIMAL(18,0),SUM(ISNULL(AE30,0))) AE30,CONVERT(DECIMAL(18,0),SUM(ISNULL(AE29,0))) AE29,CONVERT(DECIMAL(18,0),SUM(ISNULL(AE27,0))) AE27,CONVERT(DECIMAL(18,0),SUM(ISNULL(AE42,0))) AE42,MONTH(AE14) AE14,YEAR(AE14) AE1 FROM R_PQAE" );
            strSql.Append( " WHERE YEAR(AE14)=@AE14" );
            strSql.Append( " GROUP BY MONTH(AE14),YEAR(AE14),AE12) D" );
            strSql.Append( " ON A.AE14=D.AE14 AND A.AE1=D.AE1" );
            SqlParameter[] parameter = {
                new SqlParameter("@AE14",SqlDbType.Int)
            };
            parameter[0].Value = year;
            
            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public bool Exists ( int year ,int month )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQRZ" );
            strSql.Append( " WHERE RZ001=@RZ001 AND RZ003=@RZ003" );
            SqlParameter[] parameter = {
                new SqlParameter("@RZ001",SqlDbType.Int),
                new SqlParameter("@RZ003",SqlDbType.Int)
            };
            parameter[0].Value = year;
            parameter[1].Value = month;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }
        public string UpdateOne ( MulaolaoLibrary . ContractUncollectUnpaid _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQRZ SET " );
            strSql . AppendFormat ( "RZ009={0}," ,_model . RZ009 );
            strSql . AppendFormat ( "RZ010={0}," ,_model . RZ010 );
            strSql . AppendFormat ( "RZ011={0}," ,_model . RZ011 );
            strSql . AppendFormat ( "RZ012={0}," ,_model . RZ012 );
            strSql . AppendFormat ( "RZ013={0}," ,_model . RZ013 );
            strSql . AppendFormat ( "RZ014={0}," ,_model . RZ014 );
            strSql . AppendFormat ( "RZ015={0}," ,_model . RZ015 );
            strSql . AppendFormat ( "RZ020={0}," ,_model . RZ020 );
            strSql . AppendFormat ( "RZ021={0}," ,_model . RZ021 );
            strSql . AppendFormat ( "RZ022={0}," ,_model . RZ022 );
            strSql . AppendFormat ( "RZ023={0}," ,_model . RZ023 );
            strSql . AppendFormat ( "RZ024={0}" ,_model . RZ024 );
            strSql . AppendFormat ( " WHERE RZ001={0} AND RZ003={1}" ,_model . RZ001 ,_model . RZ003 );

            return strSql . ToString ( );
        }
        public string AddOne ( MulaolaoLibrary . ContractUncollectUnpaid _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQRZ (" );
            strSql . Append ( "RZ001,RZ003,RZ009,RZ010,RZ011,RZ012,RZ013,RZ014,RZ015,RZ020,RZ021,RZ022,RZ023,RZ024)" );
            strSql . Append ( " VALUES (" );
            strSql . AppendFormat ( "{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13})" ,_model . RZ001 ,_model . RZ003 ,_model . RZ009 ,_model . RZ010 ,_model . RZ011 ,_model . RZ012 ,_model . RZ013 ,_model . RZ014 ,_model . RZ015 ,_model . RZ020 ,_model . RZ021 ,_model . RZ022 ,_model . RZ023 ,_model . RZ024 );

            return strSql . ToString ( );
        }


        public DataTable GetDataTableOneOther ( int year )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT AE1,AE14,AE19,SUM(AE8) AE8,SUM(AE28) AE28,SUM(U12) U12,SUM(U13) U13 FROM (" );
            strSql . Append ( "SELECT A.AE1,A.AE14,AE06,AE19,B.AE37,AE3,AE26,AE2,AE28+AE30+AE29+AE27+AE42 AE8,AE28+AE30+AE2911 AE28,CONVERT(DECIMAL(18,0),AE003-AE28-AE30-AE2911+AE41) U12,AE002-AE28-AE30-AE29+AE40 U13 FROM (" );
            strSql . Append ( "SELECT SUM(AE06) AE06,CONVERT(DECIMAL(18,0),SUM(AE19)) AE19,MONTH(AE14) AE14,YEAR(AE14) AE1 FROM R_PQAE " );
            strSql . Append ( "  WHERE idx IN (SELECT MIN(idx) FROM R_PQAE GROUP BY AE02) AND YEAR(AE14)=@AE14" );
            strSql . Append ( " GROUP BY MONTH(AE14),YEAR(AE14)) A" );
            strSql . Append ( " LEFT JOIN" );
            strSql . Append ( " (SELECT SUM(AE37) AE37,CONVERT(DECIMAL(18,0),SUM(ISNULL(AE37,0)*ISNULL(AE12,0))) AE3,MONTH(AE14) AE14,YEAR(AE14) AE1 FROM R_PQAE" );
            strSql . Append ( " WHERE YEAR(AE14)=@AE14" );
            strSql . Append ( " GROUP BY MONTH(AE14),YEAR(AE14)) B" );
            strSql . Append ( " ON A.AE14=B.AE14 AND A.AE1=B.AE1" );
            strSql . Append ( " LEFT JOIN (" );
            strSql . Append ( " SELECT SUM(AE26) AE26,CONVERT(DECIMAL(18,0),SUM(CASE WHEN AE39!=0 THEN AE26*AE10*AE39 ELSE AE12*AE26 END)) AE2,MONTH(AE14) AE14,YEAR(AE14) AE1 FROM R_PQAE" );
            strSql . Append ( " WHERE YEAR(AE14)=@AE14" );
            strSql . Append ( " GROUP BY MONTH(AE14),YEAR(AE14)) C" );
            strSql . Append ( " ON A.AE14=C.AE14 AND A.AE1=C.AE1" );
            strSql . Append ( " LEFT JOIN (" );
            strSql . Append ( " SELECT CONVERT(DECIMAL(18,0),SUM(ISNULL(AE29*AE11,0))) AE2911,CONVERT(DECIMAL(18,0),SUM(CASE WHEN AE39!=0 THEN AE26*AE10*AE39 ELSE AE12*AE26 END)) AE002,CONVERT(DECIMAL(18,0),SUM(ISNULL(AE37,0)*ISNULL(AE12,0))) AE37,AE12,CONVERT(DECIMAL(18,0),SUM(ISNULL(AE41,0))) AE41,CONVERT(DECIMAL(18,0),SUM(ISNULL(AE40,0))) AE40,CONVERT(DECIMAL(18,0),SUM(ISNULL(AE28,0))) AE28,CONVERT(DECIMAL(18,0),SUM(ISNULL(AE30,0))) AE30,CONVERT(DECIMAL(18,0),SUM(ISNULL(AE29,0))) AE29,CONVERT(DECIMAL(18,0),SUM(ISNULL(AE27,0))) AE27,CONVERT(DECIMAL(18,0),SUM(ISNULL(AE42,0))) AE42,MONTH(AE14) AE14,YEAR(AE14) AE1,CONVERT(DECIMAL(18,0),SUM(ISNULL(AE37,0)*ISNULL(AE12,0))) AE003 FROM R_PQAE" );
            strSql . Append ( " WHERE YEAR(AE14)=@AE14" );
            strSql . Append ( " GROUP BY MONTH(AE14),YEAR(AE14),AE12) D" );
            strSql . Append ( " ON A.AE14=D.AE14 AND A.AE1=D.AE1" );
            strSql . Append ( ") A GROUP BY AE1,AE14,AE19" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@AE14",SqlDbType.Int)
            };
            parameter [ 0 ] . Value = year;

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
        }
        /// <summary>
        /// 
        /// 获取收款等
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public string UpdateOneOther ( MulaolaoLibrary . ContractUncollectUnpaid _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQRZ SET " );
            strSql . AppendFormat ( "RZ015={0}," ,_model . RZ015 );
            strSql . AppendFormat ( "RZ020={0}," ,_model . RZ020 );
            strSql . AppendFormat ( "RZ021={0}," ,_model . RZ021 );
            strSql . AppendFormat ( "RZ022={0}" ,_model . RZ022 );
            strSql . AppendFormat ( " WHERE RZ001={0} AND RZ003={1}" ,_model . RZ001 ,_model . RZ003 );

            return strSql . ToString ( );
        }

        /// <summary>
        /// 获取未收款  本年以及本年的前3年
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable GetDataTableTwo ( int year )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "WITH CET AS (SELECT YEAR(PQF13) yearP,MONTH(PQF13) monthP,AM336+AM343+AM361+AM346+AM349+AM367+AM352+AM370+AM355+AM153+AM339+AM364+AM157+AM330+AM333+AM358+AM373+AM376+AM379+AM385+AM388+AM391+AM298+AM301+AM307+AM311+AM304+AM318+AM315+AM321+AM270+AM273+AM277+AM280+AM249+AM242+AM245+AM239+AM209+AM212+AM215+AM225+AM229+AM233+AM175+AM178+AM182+AM185+AM188+AM191+AM194+AM197+AM136+AM139+AM142+AM145+AM148+AM237+AM108+AM111+AM084 U104,AM070+AM072+AM074+AM076+AM078+AM080+AM082+AM086+AM088+AM090+AM092+AM044+AM046+AM048+AM050+AM052+AM054+AM056+AM058+AM060+AM062 U105,AM020+AM022+AM024+AM026+AM028 U106,AM338+AM351+AM381+AM357+AM363+AM294+AM369+AM292+AM332+AM155+AM345+AM390+AM300+AM306+AM320+AM324+AM272+AM279+AM211+AM217+AM221+AM255+AM241+AM247+AM252+AM177+AM184+AM190+AM196 U107,AM158+AM261+AM263+AM265+AM267+AM287+AM288+AM290+AM375+AM382+AM313+AM328+AM326+AM296+AM283+AM285+AM227+AM231+AM235+AM255+AM241+AM200+AM203+AM205+AM207 U108,AM337+AM344+AM362+AM347+AM350+AM368+AM353+AM371+AM365+AM154+AM340+AM365+AM157+AM330+AM333+AM358+AM373+AM376+AM379+AM385+AM388+AM391+AM299+AM302+AM308+AM312+AM304+AM318+AM315+AM321+AM271+AM274+AM277+AM280+AM250+AM243+AM246+AM240+AM210+AM213+AM216+AM226+AM230+AM234+AM176+AM179+AM183+AM186+AM189+AM192+AM195+AM198+AM137+AM140+AM143+AM146+AM149+AM238+AM109+AM112+AM085 U109,AM071+AM073+AM075+AM077+AM079+AM081+AM083+AM087+AM089+AM091+AM093+AM045+AM047+AM049+AM051+AM053+AM055+AM057+AM059+AM061+AM063 U110,AM021+AM023+AM025+AM027+AM029 U111,AM341+AM354+AM387+AM360+AM366+AM295+AM372+AM293+AM335+AM156+AM348+AM393+AM303+AM309+AM323+AM325+AM275+AM282+AM214+AM220+AM222+AM256 U112,AM158+AM261+AM263+AM265+AM267+AM287+AM288+AM290+AM375+AM382+AM313+AM328+AM326+AM296+AM283+AM285+AM227+AM231+AM235+AM255 U113,AM338+AM351+AM381+AM357+AM363+AM294+AM369+AM292+AM332+AM155+AM345+AM390+AM336+AM343+AM361+AM346+AM349+AM367+AM352+AM370+AM355+AM153+AM339+AM364 U24,AM341+AM354+AM387+AM360+AM366+AM295+AM372+AM293+AM335+AM156+AM348+AM393+AM365+AM340+AM154+AM337+AM344+AM362+AM347+AM350+AM368+AM353+AM371+AM356 U26,AM298+AM301+AM307+AM311+AM300+AM306+AM320+AM324 U29,AM299+AM302+AM308+AM312+AM303+AM309+AM323+AM325 U31,AM270+AM273+AM272+AM279 U34,AM271+AM274+AM275+AM282 U36,AM249+AM242+AM245+AM241+AM247+AM252 U39,AM244+AM251+AM253+AM250+AM243+AM246 U41,AM209+AM212+AM215+AM211+AM217+AM221 U44,AM210+AM213+AM216+AM214+AM220+AM222 U46,AM175+AM178+AM182+AM185+AM177+AM184+AM190+AM196 U49,AM176+AM179+AM183+AM186+AM180+AM187+AM193+AM199 U51,AM136+AM139+AM142+AM145+AM148+AM255+AM218+AM138 U54,AM137+AM140+AM143+AM146+AM149+AM256+AM219+AM141 U56,AM020+AM022+AM024+AM026+AM028 U74,AM021+AM023+AM025+AM027+AM029 U76,AM108+AM111 U59,AM109+AM112 U61,AM070+AM072+AM074+AM076+AM078+AM080+AM082+AM084+AM086+AM088+AM090+AM092 U64,AM071+AM073+AM075+AM077+AM079+AM081+AM083+AM085+AM087+AM089+AM091+AM093 U66,AM044+AM046+AM048+AM050+AM052+AM054+AM056+AM058+AM060+AM062 U69,AM045+AM047+AM049+AM051+AM053+AM055+AM057+AM059+AM061+AM063 U71,AM006,AM016,AM017,AM018 FROM R_PQAM A INNER JOIN R_PQF  B ON A.AM002=B.PQF01 " );
            strSql.AppendFormat( " WHERE YEAR(PQF13) BETWEEN {0} AND {1}" ,year - 2 ,year );
            strSql.Append( " ) SELECT CONVERT(DECIMAL(18,0),SUM(U24+U29+U34+U39+U44+U49+U54+U59+U64+U69+U74)-SUM(U26+U31+U36+U41+U46+U51+U56+U61+U66+U71+U76))  QZ021,yearP,monthP FROM CET GROUP BY yearP ,monthP " );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public string UpdateTwo ( MulaolaoLibrary.ContractUncollectUnpaid _model ,string column )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQRZ SET " );
            if ( column . Equals ( "RZ016" ) )
            {
                strSql . AppendFormat ( "RZ016={0}," ,_model . RZ016 );
            }
            else if ( column . Equals ( "RZ017" ) )
            {
                strSql . AppendFormat ( "RZ017={0}," ,_model . RZ017 );
            }
            else if ( column . Equals ( "RZ019" ) )
            {
                strSql . AppendFormat ( "RZ019={0}," ,_model . RZ019 );
            }
            strSql .AppendFormat( "RZ018={0} " ,_model.RZ018 );
            strSql.AppendFormat( " WHERE RZ001={0} AND RZ003={1}" ,_model.RZ001 ,_model.RZ003 );

            return strSql.ToString( );
        }
        public string AddTwo ( MulaolaoLibrary.ContractUncollectUnpaid _model ,string column )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQRZ (" );
            if ( column . Equals ( "RZ016" ) )
            {
                strSql . Append ( "RZ001,RZ003,RZ016,RZ018)" );
                strSql . Append ( " VALUES (" );
                strSql . AppendFormat ( "{0},{1},{2},{3})" ,_model . RZ001 ,_model . RZ003 ,_model . RZ016 ,_model . RZ018 );
            }
            else if ( column . Equals ( "RZ017" ) )
            {
                strSql . Append ( "RZ001,RZ003,RZ017,RZ018)" );
                strSql . Append ( " VALUES (" );
                strSql . AppendFormat ( "{0},{1},{2},{3})" ,_model . RZ001 ,_model . RZ003 ,_model . RZ017 ,_model . RZ018 );
            }
            else if ( column . Equals ( "RZ019" ) )
            {
                strSql . Append ( "RZ001,RZ003,RZ018,RZ019)" );
                strSql . Append ( " VALUES (" );
                strSql . AppendFormat ( "{0},{1},{2},{3})" ,_model . RZ001 ,_model . RZ003 ,_model . RZ018 ,_model . RZ019 );
            }

            return strSql.ToString( );
        }

        /// <summary>
        /// 获取未结算工资
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable GetDataTableTre ( int year )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT GZ35,GZ24,CONVERT(DECIMAL(18,0),SUM(GZ)) GZ FROM (SELECT GZ35,GZ24,SUM(CASE WHEN GZ01>='16080100' THEN CONVERT(DECIMAL(18,6),GZ06*GZ25*GZ41)+CONVERT(DECIMAL(18,6),GZ36*(GZ12+GZ13+GZ14)) ELSE CONVERT(DECIMAL(18,6),GZ06*GZ25)+CONVERT(DECIMAL(18,6),GZ36*(GZ12+GZ13+GZ14)) END) GZ FROM R_PQW " );
            strSql.AppendFormat( " WHERE (GZ39!='执行' OR GZ39='' OR GZ39 IS NULL) AND GZ35={0}" ,year );
            strSql.Append( " GROUP BY GZ35,GZ24,GZ01) A GROUP BY GZ35,GZ24" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public string UpdateTre ( MulaolaoLibrary.ContractUncollectUnpaid _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQRZ SET " );
            strSql.AppendFormat( "RZ007={0}" ,_model.RZ007 );
            strSql.AppendFormat( " WHERE RZ001={0} AND RZ003={1}" ,_model.RZ001 ,_model.RZ003 );

            return strSql.ToString( );
        }
        public string AddTre ( MulaolaoLibrary.ContractUncollectUnpaid _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQRZ (" );
            strSql.Append( "RZ001,RZ003,RZ007)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "{0},{1},{2})" ,_model.RZ001 ,_model.RZ003 ,_model.RZ007 );

            return strSql.ToString( );
        }

        /// <summary>
        /// 获取库存
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable GetDataTableFor ( int year )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT BO010+BO014+BO004+BO006+BO012+BO002+BO008+BO016 AC FROM R_PQBO " );
            //strSql.Append( " SELECT SUM(AC) AC FROM CET" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public string UpdateFor ( MulaolaoLibrary.ContractUncollectUnpaid _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQRZ SET " );
            strSql.AppendFormat( "RZ004={0}" ,_model.RZ004 );
            strSql.AppendFormat( " WHERE RZ001={0} AND RZ003={1}" ,_model.RZ001 ,_model.RZ003 );

            return strSql.ToString( );
        }
        public string AddFor ( MulaolaoLibrary.ContractUncollectUnpaid _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQRZ (" );
            strSql.Append( "RZ001,RZ003,RZ004)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "{0},{1},{2})" ,_model.RZ001 ,_model.RZ003 ,_model.RZ004 );

            return strSql.ToString( );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQRZ" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = idx;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool DeleteBatch ( int year )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQRZ" );
            strSql.Append( " WHERE RZ001=@RZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@RZ001",SqlDbType.Int)
            };
            parameter[0].Value = year;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
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
        public MulaolaoLibrary.ContractUncollectUnpaid GetModel (int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQRZ" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = idx;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da.Rows.Count > 0 )
                return GetDataRow( da.Rows[0] );
            else
                return null;
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ContractUncollectUnpaid GetDataRow ( DataRow row )
        {
            MulaolaoLibrary.ContractUncollectUnpaid _model = new MulaolaoLibrary.ContractUncollectUnpaid( );
            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    _model.IDX = int.Parse( row["idx"].ToString( ) );
                if ( row["RZ001"] != null && row["RZ001"].ToString( ) != "" )
                    _model.RZ001 = int.Parse( row["RZ001"].ToString( ) );
                if ( row["RZ002"] != null && row["RZ002"].ToString( ) != "" )
                    _model.RZ002 = decimal.Parse( row["RZ002"].ToString( ) );
                if ( row["RZ003"] != null && row["RZ003"].ToString( ) != "" )
                    _model.RZ003 = int.Parse( row["RZ003"].ToString( ) );
                if ( row["RZ005"] != null && row["RZ005"].ToString( ) != "" )
                    _model.RZ005 = int.Parse( row["RZ005"].ToString( ) );
                if ( row["RZ006"] != null && row["RZ006"].ToString( ) != "" )
                    _model.RZ006 = decimal.Parse( row["RZ006"].ToString( ) );
                if ( row["RZ008"] != null && row["RZ008"].ToString( ) != "" )
                    _model.RZ008 = int.Parse( row["RZ008"].ToString( ) );
                if ( row["RZ016"] != null && row["RZ016"].ToString( ) != "" )
                    _model.RZ016 = int.Parse( row["RZ016"].ToString( ) );
                if ( row["RZ017"] != null && row["RZ017"].ToString( ) != "" )
                    _model.RZ017 = int.Parse( row["RZ017"].ToString( ) );
            }
            return _model;
        }
    }
}

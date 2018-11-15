using System;
using System . Data;
using System . Text;
using StudentMgr;
using System . Collections;
using System . Data . SqlClient;

namespace MulaolaoBll . Dao
{
    public class MaterialPurchaseCompariaseDao
    {
        private decimal sumOne=0M;
        private decimal sumTwo=0M;

        /// <summary>
        /// 生成数据
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Generate (MulaolaoLibrary.MaterialPurchaseCompariaseLibrary _model,string year )
        {
            ArrayList SQLString = new ArrayList( );
            DataTable da = new DataTable( );

            da = GetDataTableOfCost ( year.Substring(2,2) );
            if ( da != null && da.Rows.Count > 0 )
            {
                _model.AU001 = "R_241";
                _model.AU002 = string.IsNullOrEmpty( da.Rows[0]["U14"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[0]["U14"].ToString( ) );
                _model.AU003 = string.IsNullOrEmpty( da.Rows[0]["U16"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[0]["U16"].ToString( ) );
                _model.AU004 = string.IsNullOrEmpty( da.Rows[0]["U17"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[0]["U17"].ToString( ) );
                if ( Exists( _model.AU001 ) )
                    SQLString.Add( UpdateOf( _model ) );
                else
                    SQLString.Add( AddOf( _model ) );
            }
            else
                return false;

            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                SQLString . Clear ( );
                _model . AU001 = "R_526";
                _model . AU002 = _model . AU003 = 0;
                da = GetDataTableOfCount ( year . Substring ( 2 ,2 ) );
                if ( da != null && da . Rows . Count > 0 )
                {
                    _model . AU003 = string . IsNullOrEmpty ( da . Rows [ 0 ] [ "R" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ 0 ] [ "R" ] . ToString ( ) );
                }

                da = GetDataTableOfY ( year.Substring(2,2) );
                if ( da != null && da . Rows . Count > 0 )
                {
                    _model . AU002 = string . IsNullOrEmpty ( da . Rows [ 0 ] [ "R" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ 0 ] [ "R" ] . ToString ( ) );
                }
                _model . AU004 = _model . AU002 - _model . AU003;
                if ( Exists ( _model . AU001 ) )
                    SQLString . Add ( UpdateOf ( _model ) );
                else
                    SQLString . Add ( AddOf ( _model ) );
            }

            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                SQLString . Clear ( );
                GetDataTableOfPayMent ( year . Substring ( 2 ,2 ) );
                _model . AU001 = "R_231";
                _model . AU002 = Convert . ToInt32 ( sumOne );
                _model . AU003 = Convert . ToInt32 ( sumTwo );
                _model . AU004 = _model . AU002 - _model . AU003;
                if ( Exists ( _model . AU001 ) )
                    SQLString . Add ( UpdateOf ( _model ) );
                else
                    SQLString . Add ( AddOf ( _model ) );
            }

            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                SQLString . Clear ( );
                GetDataTableOfPayMent323 ( year . Substring ( 2 ,2 ) );
                _model . AU001 = "R_323";
                _model . AU002 = Convert . ToInt32 ( sumOne );
                _model . AU003 = Convert . ToInt32 ( sumTwo );
                _model . AU004 = _model . AU002 - _model . AU003;
                if ( Exists ( _model . AU001 ) )
                    SQLString . Add ( UpdateOf ( _model ) );
                else
                    SQLString . Add ( AddOf ( _model ) );
            }

            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                SQLString . Clear ( );
                GetDataTableOfPayMent243 ( year . Substring ( 2 ,2 ) );
                _model . AU001 = "R_243";
                _model . AU002 = Convert . ToInt32 ( sumOne );
                _model . AU003 = Convert . ToInt32 ( sumTwo );
                _model . AU004 = _model . AU002 - _model . AU003;
                if ( Exists ( _model . AU001 ) )
                    SQLString . Add ( UpdateOf ( _model ) );
                else
                    SQLString . Add ( AddOf ( _model ) );
            }



            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool Exists ( string str )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQAU" );
            strSql.Append( " WHERE AU001=@AU001" );
            SqlParameter[] parameter = {
                new SqlParameter("@AU001",SqlDbType.NVarChar)
            };
            parameter[0].Value = str;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }
        public string AddOf ( MulaolaoLibrary.MaterialPurchaseCompariaseLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAU (" );
            strSql.Append( "AU001,AU002,AU003,AU004)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}')" ,_model.AU001 ,_model.AU002 ,_model.AU003 ,_model.AU004 );

            return strSql.ToString( );
        }
        public string UpdateOf ( MulaolaoLibrary.MaterialPurchaseCompariaseLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAU SET " );
            strSql.AppendFormat( "AU002='{0}'," ,_model.AU002 );
            strSql.AppendFormat( "AU003='{0}'," ,_model.AU003 );
            strSql.AppendFormat( "AU004='{0}'" ,_model.AU004 );
            strSql.AppendFormat( " WHERE AU001='{0}'" ,_model.AU001 );

            return strSql.ToString( );
        }

        /// <summary>
        /// 241数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfCost ( string year )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "WITH CET AS (" );
            strSql . AppendFormat ( "SELECT idx,AM336+AM343+AM361+AM346+AM349+AM367+AM352+AM370+AM355+AM153+AM339+AM364+AM157+AM330+AM333+AM358+AM373+AM376+AM379+AM385+AM388+AM391+AM298+AM301+AM307+AM311+AM304+AM318+AM315+AM321+AM270+AM273+AM277+AM280+AM249+AM242+AM245+AM239+AM209+AM212+AM215+AM225+AM229+AM233+AM175+AM178+AM182+AM185+AM188+AM191+AM194+AM197+AM136+AM139+AM142+AM145+AM148+AM237+AM108+AM111+AM084 U104,AM070+AM072+AM074+AM076+AM078+AM080+AM082+AM086+AM088+AM090+AM092+AM044+AM046+AM048+AM050+AM052+AM054+AM056+AM058+AM060+AM062 U105,AM020+AM022+AM024+AM026+AM028 U106,AM338+AM351+AM381+AM357+AM363+AM294+AM369+AM292+AM332+AM155+AM345+AM390+AM300+AM306+AM320+AM324+AM272+AM279+AM211+AM217+AM221+AM255+AM241+AM247+AM252+AM177+AM184+AM190+AM196 U107,AM158+AM261+AM263+AM265+AM267+AM287+AM288+AM290+AM375+AM382+AM313+AM328+AM326+AM296+AM283+AM285+AM227+AM231+AM235+AM255+AM241+AM200+AM203+AM205+AM207 U108,AM337+AM344+AM362+AM347+AM350+AM368+AM353+AM371+AM365+AM154+AM340+AM365+AM157+AM330+AM333+AM358+AM373+AM376+AM379+AM385+AM388+AM391+AM299+AM302+AM308+AM312+AM304+AM318+AM315+AM321+AM271+AM274+AM277+AM280+AM250+AM243+AM246+AM240+AM210+AM213+AM216+AM226+AM230+AM234+AM176+AM179+AM183+AM186+AM189+AM192+AM195+AM198+AM137+AM140+AM143+AM146+AM149+AM238+AM109+AM112+AM085 U109,AM071+AM073+AM075+AM077+AM079+AM081+AM083+AM087+AM089+AM091+AM093+AM045+AM047+AM049+AM051+AM053+AM055+AM057+AM059+AM061+AM063 U110,AM021+AM023+AM025+AM027+AM029 U111,AM341+AM354+AM387+AM360+AM366+AM295+AM372+AM293+AM335+AM156+AM348+AM393+AM303+AM309+AM323+AM325+AM275+AM282+AM214+AM220+AM222+AM256 U112,AM158+AM261+AM263+AM265+AM267+AM287+AM288+AM290+AM375+AM382+AM313+AM328+AM326+AM296+AM283+AM285+AM227+AM231+AM235+AM255 U113,AM338+AM351+AM381+AM357+AM363+AM294+AM369+AM292+AM332+AM155+AM345+AM390+AM336+AM343+AM361+AM346+AM349+AM367+AM352+AM370+AM355+AM153+AM339+AM364 U24,AM341+AM354+AM387+AM360+AM366+AM295+AM372+AM293+AM335+AM156+AM348+AM393+AM365+AM340+AM154+AM337+AM344+AM362+AM347+AM350+AM368+AM353+AM371+AM356 U26,AM298+AM301+AM307+AM311+AM300+AM306+AM320+AM324 U29,AM299+AM302+AM308+AM312+AM303+AM309+AM323+AM325 U31,AM270+AM273+AM272+AM279 U34,AM271+AM274+AM275+AM282 U36,AM249+AM242+AM245+AM241+AM247+AM252 U39,AM244+AM251+AM253+AM250+AM243+AM246 U41,AM209+AM212+AM215+AM211+AM217+AM221 U44,AM210+AM213+AM216+AM214+AM220+AM222 U46,AM175+AM178+AM182+AM185+AM177+AM184+AM190+AM196 U49,AM176+AM179+AM183+AM186+AM180+AM187+AM193+AM199 U51,AM136+AM139+AM142+AM145+AM148+AM255+AM218+AM138 U54,AM137+AM140+AM143+AM146+AM149+AM256+AM219+AM141 U56,AM020+AM022+AM024+AM026+AM028 U74,AM021+AM023+AM025+AM027+AM029 U76,AM108+AM111 U59,AM109+AM112 U61,AM070+AM072+AM074+AM076+AM078+AM080+AM082+AM084+AM086+AM088+AM090+AM092 U64,AM071+AM073+AM075+AM077+AM079+AM081+AM083+AM085+AM087+AM089+AM091+AM093 U66,AM044+AM046+AM048+AM050+AM052+AM054+AM056+AM058+AM060+AM062 U69,AM045+AM047+AM049+AM051+AM053+AM055+AM057+AM059+AM061+AM063 U71,AM006,AM016,AM017,AM018 FROM R_PQAM WHERE AM002 LIKE '{0}%' )" ,year );
            strSql . Append ( "SELECT CONVERT(DECIMAL(18,0),SUM(U24+U29+U34+U39+U44+U49+U54+U59+U64+U69+U74)) U14,CONVERT(DECIMAL(18,0),SUM(U26+U31+U36+U41+U46+U51+U56+U61+U66+U71+U76)) U16,CONVERT(DECIMAL(18,0),SUM(U24+U29+U34+U39+U44+U49+U54+U59+U64+U69+U74)-SUM(U26+U31+U36+U41+U46+U51+U56+U61+U66+U71+U76)) U17 FROM CET" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 231数据
        /// </summary>
        /// <returns></returns>
        void GetDataTableOfPayMent ( string year )
        {
            sumOne = 0M;
            sumTwo = 0M;
            StringBuilder strSql = new StringBuilder ( );
            //strSql.Append( "WITH CET AS(" );
            //strSql.Append( "SELECT SUM(CASE WHEN YZ008='材料款' THEN YZ015-YZ014-YZ026+YZ011+YZ012 ELSE 0 END) U1 FROM R_PQYZ" );
            //strSql.Append( ")" );
            //strSql.Append( ",CFT AS (" );
            //strSql.Append( "SELECT SUM(CASE WHEN AP008='材料款' THEN AP015-AP014-AP026+AP011+AP012 ELSE 0 END) U2 FROM R_PQAP" );
            //strSql.Append( ")" );
            //strSql.Append( "SELECT CONVERT(DECIMAL(18,0),U1+U2) U FROM CET,CFT" );

            string idx = string . Empty;
            //获取526数据
            DataTable dt = null;
            //strSql . Append ( "SELECT YZ022 FROM R_PQYZ WHERE YZ022!='' AND YZ022 IS NOT NULL UNION SELECT AP022 FROM R_PQAP WHERE AP022!='' AND AP022 IS NOT NULL " );
            //DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            //if ( dt != null && dt . Rows . Count > 0 )
            //{
            //for ( int i = 0 ; i < dt . Rows . Count ; i++ )
            //{
            //    if ( string . IsNullOrEmpty ( idx ) )
            //        idx = dt . Rows [ i ] [ "YZ022" ] . ToString ( );
            //    else
            //        idx = idx + "," + dt . Rows [ i ] [ "YZ022" ] . ToString ( );
            //}
            //if ( !string . IsNullOrEmpty ( idx ) )
            //    {

            //应付款  526
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT CONVERT(DECIMAL(18,0),SUM(AK009)) AK009 FROM R_PQAK WHERE idx IN (SELECT MAX(idx) FROM R_PQAK WHERE AK002 LIKE '{0}%' AND AK017 IN ('执行','审核') GROUP BY AK003)" ,year );
            dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                sumOne += string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "AK009" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ 0 ] [ "AK009" ] . ToString ( ) );
            }
            //已付款
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT CONVERT(DECIMAL(18,0),SUM(AK011)) AK011 FROM R_PQAK WHERE AK002 LIKE '{0}%' AND AK017 IN ('执行','审核')" ,year );
            dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                sumTwo += string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "AK011" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ 0 ] [ "AK011" ] . ToString ( ) );
            }

            //}
            //}

            //strSql = new StringBuilder ( );
            //strSql . Append ( "SELECT YZ027 FROM R_PQYZ WHERE YZ027!='' AND YZ027 IS NOT NULL UNION SELECT AP027 FROM R_PQAP WHERE AP027!='' AND AP027 IS NOT NULL" );
            //dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            //if ( dt != null && dt . Rows . Count > 0 )
            //{
            //    idx = string . Empty;
            //    for ( int i = 0 ; i < dt . Rows . Count ; i++ )
            //    {
            //        if ( string . IsNullOrEmpty ( idx ) )
            //            idx = dt . Rows [ i ] [ "YZ027" ] . ToString ( );
            //        else
            //            idx = idx + "," + dt . Rows [ i ] [ "YZ027" ] . ToString ( );
            //    }

            //    if ( !string . IsNullOrEmpty ( idx ) )
            //    {
            //已付款323
            strSql = new StringBuilder ( );
            //strSql . AppendFormat ( "SELECT CONVERT(DECIMAL(18,0),SUM(EZ)) EZ FROM (SELECT EZ007+EZ008 EZ FROM R_PQEZ A INNER JOIN R_PQFZ B ON A.idx=B.FZ001 INNER JOIN R_PQW C ON B.FZ002=C.idx WHERE EZ015 IN ('执行','审核') AND GZ01 LIKE '{0}%' GROUP BY A.idx,EZ007,EZ008) A" ,year );
            strSql . AppendFormat ( "SELECT  CONVERT(DECIMAL(18,0),SUM(GZ06 *GZ25*1.0*GZ41+GZ36*(GZ12+GZ13+GZ14))) EZ  FROM R_PQEZ A INNER JOIN R_PQFZ B ON A.idx=B.FZ001 INNER JOIN R_PQW C ON B.FZ002=C.idx WHERE EZ015 IN ('执行','审核') AND GZ01 LIKE '{0}%'" ,year );
            dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                sumTwo += string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "EZ" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ 0 ] [ "EZ" ] . ToString ( ) );
            }
            //应付款317
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT CONVERT(DECIMAL(18,0),SUM(GZ06 *GZ25*1.0*GZ41+GZ36*(GZ12+GZ13+GZ14))) EZ FROM R_PQW WHERE GZ39 IN ('执行','审核') AND GZ01 LIKE '{0}%'" ,year  );
            dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                sumOne += string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "EZ" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ 0 ] [ "EZ" ] . ToString ( ) );
            }
            //    }
            //}

            //strSql = new StringBuilder ( );
            //strSql . Append ( "SELECT YZ030 FROM R_PQYZ WHERE YZ030!='' AND YZ030 IS NOT NULL UNION SELECT AP030 FROM R_PQAP WHERE AP030!='' AND AP030 IS NOT NULL " );
            //dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            //if ( dt != null && dt . Rows . Count > 0 )
            //{
            //    idx = string . Empty;
            //    for ( int i = 0 ; i < dt . Rows . Count ; i++ )
            //    {
            //        if ( string . IsNullOrEmpty ( idx ) )
            //            idx = dt . Rows [ i ] [ "YZ030" ] . ToString ( );
            //        else
            //            idx = idx + "," + dt . Rows [ i ] [ "YZ030" ] . ToString ( );
            //    }

            //    if ( !string . IsNullOrEmpty ( idx ) )
            //    {
            //应付款和已付款  243
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT CONVERT(DECIMAL(18,0),SUM(BE007+BE008+BE009+BE010+BE011+BE012)) BE FROM R_PQBE WHERE BE013 IN ('执行','审核') AND BE002 LIKE '{0}%'" ,year );
            dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                sumOne += string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "BE" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ 0 ] [ "BE" ] . ToString ( ) );
                sumTwo += string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "BE" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ 0 ] [ "BE" ] . ToString ( ) );
            }
            //    }

            //}

            sumOne = Math . Round ( sumOne ,0 );
            sumTwo = Math . Round ( sumTwo ,0 );
        }

        /// <summary>
        /// 323和317数据
        /// </summary>
        /// <param name="year"></param>
        void GetDataTableOfPayMent323 ( string year )
        {
            sumOne = 0M;
            sumTwo = 0M;
            StringBuilder strSql = new StringBuilder ( );
            DataTable dt;
            //已付款323
            strSql = new StringBuilder ( );
            //strSql . AppendFormat ( "SELECT CONVERT(DECIMAL(18,0),SUM(EZ)) EZ FROM (SELECT EZ007+EZ008 EZ FROM R_PQEZ A INNER JOIN R_PQFZ B ON A.idx=B.FZ001 INNER JOIN R_PQW C ON B.FZ002=C.idx WHERE EZ015 IN ('执行','审核') AND GZ01 LIKE '{0}%' GROUP BY A.idx,EZ007,EZ008) A" ,year );
            strSql . AppendFormat ( "SELECT  CONVERT(DECIMAL(18,0),SUM(GZ06 *GZ25*1.0*GZ41+GZ36*(GZ12+GZ13+GZ14))) EZ  FROM R_PQEZ A INNER JOIN R_PQFZ B ON A.idx=B.FZ001 INNER JOIN R_PQW C ON B.FZ002=C.idx WHERE EZ015 IN ('执行','审核') AND GZ01 LIKE '{0}%'" ,year );
            dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                sumTwo += string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "EZ" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ 0 ] [ "EZ" ] . ToString ( ) );
            }
            //应付款317
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT CONVERT(DECIMAL(18,0),SUM(GZ06 *GZ25*1.0*GZ41+GZ36*(GZ12+GZ13+GZ14))) EZ FROM R_PQW WHERE GZ39 IN ('执行','审核') AND GZ01 LIKE '{0}%'" ,year );
            dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                sumOne += string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "EZ" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ 0 ] [ "EZ" ] . ToString ( ) );
            }
        }

        /// <summary>
        /// 243数据
        /// </summary>
        /// <param name="year"></param>
        void GetDataTableOfPayMent243 ( string year )
        {
            sumOne = sumTwo = 0;
            //应付款和已付款  243
            StringBuilder strSql = new StringBuilder ( );
            DataTable dt;
            strSql . AppendFormat ( "SELECT CONVERT(DECIMAL(18,0),SUM(BE007+BE008+BE009+BE010+BE011+BE012)) BE FROM R_PQBE WHERE BE013 IN ('执行','审核') AND BE002 LIKE '{0}%'" ,year );
            dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                sumOne += string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "BE" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ 0 ] [ "BE" ] . ToString ( ) );
                sumTwo += string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "BE" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ 0 ] [ "BE" ] . ToString ( ) );
            }
        }

        /// <summary>
        /// 526数据  已付款
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfCount ( string year )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql . AppendFormat ( "SELECT CONVERT(DECIMAL(18,0),SUM(AK011)) R FROM R_PQAK WHERE AK002 LIKE '{0}%' AND AK017 IN ('执行','审核')" ,year );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 526数据  应付款
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfY (string year )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT CONVERT(DECIMAL(18,0),SUM(AK009)) R FROM R_PQAK WHERE idx IN (SELECT MIN(idx) FROM R_PQAK WHERE AK002 LIKE '{0}%' AND AK017 IN ('执行','审核') GROUP BY AK003)" ,year );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQAU" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
    }
}

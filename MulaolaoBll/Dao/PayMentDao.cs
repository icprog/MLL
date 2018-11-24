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
    public class PayMentDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableCombo ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT YZ004,YZ005,YZ020,YZ021 FROM R_PQYZ" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableComboOne ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT AP004,AP005,AP020,AP021 FROM R_PQAP" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableComboTwo ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT AQ002,AQ011 FROM R_PQAQ" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableComboTre ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT AO004,AO005,AO006,AO007,AO008,AO019 FROM R_PQAO" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableComboFor ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT AR004,AR005,AR006,AR007,AR008,AR019 FROM R_PQAR" );

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
            strSql.Append( "SELECT idx,AK001,AK002,AK004,AK005,AK006,AK007,AK008,AK009,AK010,AK011,AK012,AK013,AK014,AK015 FROM R_PQAK" );
            strSql.Append( " WHERE (AK017 NOT IN ('执行','审核') OR AK017 IS NULL OR AK017='')" );
            strSql.Append( " AND " + strWhere );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取323数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfPqez ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQEZ A LEFT JOIN R_REVIEWS B ON A.EZ001=B.RES06 AND RES05='执行'" );
            strSql.Append( " WHERE " + strWhere );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT AK001 FROM R_PQAK WHERE AK017!='执行' OR AK017='' OR AK017 IS NULL" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 323数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnlyOfPqez ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT EZ011,EZ004 FROM R_PQEZ WHERE EZ015!='执行' OR EZ015 IS NULL" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取扣款明细
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableSupplier ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT WZ002,WZ003,WZ004,WZ005,WZ006,WZ007,WZ008,WZ009,WZ010,WZ011,WZ012,WZ013,WZ014,WZ015,WY001,WY002,B.idx FROM R_PQWZ A INNER JOIN R_PQWY B ON A.idx=B.WY001 WHERE WY004='' OR WY004 IS NULL ORDER BY A.WZ004" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取工资
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfPay ( DateTime dt ,string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql . Append ( "WITH CET AS (" );
            strSql.Append( "SELECT idx,XZ002,XZ003,XZ004,XZ005,XZ006,XZ007,XZ008,XZ009,XZ010,XZ011,XZ012,XZ013,XZ014,XZ021,XZ022,XZ023,XZ024,XZ030,XZ031,CONVERT(DECIMAL(18,5),XZ005/day(dateadd(d,-day(@XZ013),dateadd(m,1,@XZ013)))) U4,XZ029 FROM R_PQXZ" );
            strSql.Append( " WHERE YEAR(XZ013)=@YEAR AND MONTH(XZ013)=@MONTH" );
            strSql.Append( " AND (XZ025!='执行' OR XZ025 IS NULL OR XZ025='')" );
            strSql.Append( " AND " + strWhere );
            strSql . Append ( " ) SELECT *,XZ023+XZ021+U4*(XZ006+XZ007)+XZ029-(XZ010+XZ008+XZ011+XZ009+XZ024+XZ030+XZ031) U3 FROM CET " );
            SqlParameter[] parameter = {
                new SqlParameter("@XZ013",SqlDbType.Date),
                new SqlParameter("@YEAR",SqlDbType.Int),
                new SqlParameter("@MONTH",SqlDbType.Int)
            };
            parameter[0].Value = dt;
            parameter[1].Value = dt.Year;
            parameter[2].Value = dt.Month;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取工资
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfPays ( DateTime dt ,string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,XZ002,XZ003,XZ004,XZ005,XZ006,XZ007,XZ008,XZ009,XZ010,XZ011,XZ012,XZ013,XZ014,XZ021,XZ022,XZ023,XZ024,XZ030,XZ031,CONVERT(DECIMAL(18,2),XZ005/day(dateadd(d,-day(@XZ013),dateadd(m,1,@XZ013)))) U4 FROM R_PQXZ" );
            strSql.Append( " WHERE XZ013=@XZ013" );
            strSql.Append( " AND (XZ025!='执行' OR XZ025 IS NULL OR XZ025='')" );
            strSql.Append( " AND " + strWhere );
            SqlParameter[] parameter = {
                new SqlParameter("@XZ013",SqlDbType.Date)
            };
            parameter[0].Value = dt;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfAll ( string strWhere )
        {
            //,YZ027,YZ026,YZ021,YZ022,YZ023,YZ024,YZ025,YZ014,YZ015,YZ016,YZ017,YZ018,YZ019,YZ020,YZ009,YZ010,YZ011,YZ012,YZ013
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQYZ" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( " ORDER BY YZ003,YZ009 DESC,idx DESC" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableOfAllOne ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQAP" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( " ORDER BY AP003,AP009 DESC,idx DESC" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableOfAllTwo ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQAQ" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( " ORDER BY idx" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableOfAllTre ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQAO" );
            strSql.Append( " WHERE " + strWhere );
            //strSql . Append ( " AND (WZ016='' OR WZ016 IS NULL)" );
            strSql.Append( " ORDER BY AO003,AO009 DESC,idx DESC" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableOfAllFor ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQAR" );
            strSql.Append( " WHERE " + strWhere );
            //strSql . Append ( " AND (WZ016='' OR WZ016 IS NULL)" );
            strSql .Append( " ORDER BY AR003,AR009 DESC,idx DESC" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableOfAllFiv ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT 0.00 AS F0,0.00 AS F1,0.00 AS F2,0.00 AS F4,0.00 AS F5,0.00 AS F6,0.00 AS F7,0.00 AS F8,0.00 AS F9,0.00 AS F10,0.00 AS F11,0.00 AS F12,0.00 AS F13 FROM R_PQYZ" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableOfAllSix ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT 0.00 AS H0,0.00 AS H1,0.00 AS H2,0.00 AS H4,0.00 AS H5,0.00 AS H6,0.00 AS H7,0.00 AS H8,0.00 AS H9,0.00 AS H10,0.00 AS H11,0.00 AS H12,0.00 AS H13 FROM R_PQAP" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 编辑状态
        /// </summary>
        /// <param name="signOne"></param>
        /// <param name="signTwo"></param>
        /// <param name="signTre"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool UpdateStateSe ( string signOne ,string signTwo ,string signTre ,string signFor ,string signFiv ,string signSix ,DateTime dt,string signSev )
        {
            ArrayList SQLString = new ArrayList( );
            if ( !string.IsNullOrEmpty( signOne ) )
            {
                StringBuilder strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAK SET AK016='{0}',AK017='执行' WHERE idx IN (" + signOne + ")" ,dt );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( !string.IsNullOrEmpty( signTwo ) )
            {
                StringBuilder strSq = new StringBuilder( );
                //strSq.AppendFormat( "UPDATE R_PQWZ SET WZ016='执行',WZ017='{0}' WHERE idx IN (" + signTwo + ")" ,dt );
                strSq . AppendFormat ( "UPDATE R_PQWY SET WY004='执行',WY003='{0}' WHERE idx IN (" + signTwo + ")" ,dt );
                SQLString .Add( strSq.ToString( ) );
            }
            if ( !string.IsNullOrEmpty( signTre ) )
            {
                StringBuilder strS = new StringBuilder( );
                strS.AppendFormat( "UPDATE R_PQXZ SET XZ022='{0}',XZ025='执行' WHERE idx IN (" + signTre + ")" ,dt );
                SQLString.Add( strS.ToString( ) );
            }
            if ( !string.IsNullOrEmpty( signFor ) )
            {
                StringBuilder str = new StringBuilder( );
                str.AppendFormat( "UPDATE R_PQXZ SET XZ022='{0}',XZ025='执行' WHERE idx IN (" + signFor + ")" ,dt );
                SQLString.Add( str.ToString( ) );
            }
            if ( !string.IsNullOrEmpty( signFiv ) )
            {
                StringBuilder str = new StringBuilder( );
                str.AppendFormat( "UPDATE R_PQEZ SET EZ016='{0}',EZ015='执行' WHERE idx IN (" + signFiv + ")" ,dt );
                SQLString.Add( str.ToString( ) );
            }
            if ( !string.IsNullOrEmpty( signSix ) )
            {
                StringBuilder str = new StringBuilder( );
                str.AppendFormat( "UPDATE R_PQBE SET BE014='{0}',BE013='执行' WHERE idx IN (" + signSix + ")" ,dt );
                SQLString.Add( str.ToString( ) );
            }
            if ( !string . IsNullOrEmpty ( signSev ) )
            {
                StringBuilder str = new StringBuilder ( );
                str . AppendFormat ( "UPDATE R_PQCQ SET CQ113='{0}',CQ112='执行' WHERE idx IN (" + signSev + ")" , dt );
                SQLString . Add ( str . ToString ( ) );
            }

            if ( SQLString.Count > 0 )
                return SqlHelper.ExecuteSqlTran( SQLString );
            else
                return true;
        }
        public bool UpdateState ( string signOne ,string signTwo ,string signTre ,string signFor ,string signFiv ,string signSix,string signSev )
        {
            ArrayList SQLString = new ArrayList( );
            if ( !string.IsNullOrEmpty( signOne ) )
            {
                StringBuilder strSql = new StringBuilder( );
                strSql.Append( "UPDATE R_PQAK SET AK016=NULL,AK017='' WHERE idx IN (" + signOne + ")" );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( !string.IsNullOrEmpty( signTwo ) )
            {
                StringBuilder strSq = new StringBuilder( );
                //strSq.Append( "UPDATE R_PQWZ SET WZ016='',WZ017=NULL WHERE idx IN (" + signTwo + ")" );
                strSq . Append ( "UPDATE R_PQWY SET WY003=NULL,WY004=NULL WHERE idx IN (" + signTwo + ")" );
                SQLString .Add( strSq.ToString( ) );
            }
            if ( !string.IsNullOrEmpty( signTre ) )
            {
                StringBuilder strS = new StringBuilder( );
                strS.Append( "UPDATE R_PQXZ SET XZ022=NULL,XZ025='' WHERE idx IN (" + signTre + ")" );
                SQLString.Add( strS.ToString( ) );
            }
            if ( !string.IsNullOrEmpty( signFor ) )
            {
                StringBuilder str = new StringBuilder( );
                str.Append( "UPDATE R_PQXZ SET XZ022=NULL,XZ025='' WHERE idx IN (" + signFor + ")" );
                SQLString.Add( str.ToString( ) );
            }
            if ( !string.IsNullOrEmpty( signFiv ) )
            {
                StringBuilder str = new StringBuilder( );
                str.Append( "UPDATE R_PQEZ SET EZ016=NULL,EZ015='' WHERE idx IN (" + signFiv + ")" );
                SQLString.Add( str.ToString( ) );
            }
            if ( !string.IsNullOrEmpty( signSix ) )
            {
                StringBuilder str = new StringBuilder( );
                str.Append( "UPDATE R_PQBE SET BE014=NULL,BE013='' WHERE idx IN (" + signSix + ")" );
                SQLString.Add( str.ToString( ) );
            }
            if ( !string . IsNullOrEmpty ( signSev ) )
            {
                StringBuilder str = new StringBuilder ( );
                str . Append ( "UPDATE R_PQCQ SET CQ113=NULL,CQ112='' WHERE idx IN (" + signSev + ")" );
                SQLString . Add ( str . ToString ( ) );
            }
            if ( SQLString.Count > 0 )
                return SqlHelper.ExecuteSqlTran( SQLString );
            else
                return true;
        }
        public bool UpdateState ( string signOne ,string signTwo ,string signTre ,string signFor ,string signFiv ,string state ,string signSix,string signEgi )
        {
            ArrayList SQLString = new ArrayList( );
            if ( !string.IsNullOrEmpty( signOne ) )
            {
                StringBuilder strSql = new StringBuilder( );
                strSql.Append( "UPDATE R_PQAK SET AK016=NULL,AK017='审核' WHERE idx IN (" + signOne + ")" );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( !string.IsNullOrEmpty( signTwo ) )
            {
                StringBuilder strSq = new StringBuilder( );
                //strSq.Append( "UPDATE R_PQWZ SET WZ016='审核',WZ017=NULL WHERE idx IN (" + signTwo + ")" );
                strSq . Append ( "UPDATE R_PQWY SET WY004='审核',WY003=NULL WHERE idx IN (" + signTwo + ")" );
                SQLString .Add( strSq.ToString( ) );
            }
            if ( !string.IsNullOrEmpty( signTre ) )
            {
                StringBuilder strS = new StringBuilder( );
                strS.Append( "UPDATE R_PQXZ SET XZ022=NULL,XZ025='审核' WHERE idx IN (" + signTre + ")" );
                SQLString.Add( strS.ToString( ) );
            }
            if ( !string.IsNullOrEmpty( signFor ) )
            {
                StringBuilder str = new StringBuilder( );
                str.Append( "UPDATE R_PQXZ SET XZ022=NULL,XZ025='审核' WHERE idx IN (" + signFor + ")" );
                SQLString.Add( str.ToString( ) );
            }
            if ( !string.IsNullOrEmpty( signFiv ) )
            {
                StringBuilder str = new StringBuilder( );
                str.Append( "UPDATE R_PQEZ SET EZ016=NULL,EZ015='审核' WHERE idx IN (" + signFiv + ")" );
                SQLString.Add( str.ToString( ) );
            }
            if ( !string.IsNullOrEmpty( signSix ) )
            {
                StringBuilder str = new StringBuilder( );
                str.AppendFormat( "UPDATE R_PQBE SET BE014=NULL,BE013='审核' WHERE idx IN (" + signSix + ")" );
                SQLString.Add( str.ToString( ) );
            }
            if ( !string . IsNullOrEmpty ( signEgi ) )
            {
                StringBuilder str = new StringBuilder ( );
                str . AppendFormat ( "UPDATE R_PQCQ SET CQ113=NULL,CQ112='审核' WHERE idx IN (" + signEgi + ")" );
                SQLString . Add ( str . ToString ( ) );
            }
            if ( SQLString.Count > 0 )
                return SqlHelper.ExecuteSqlTran( SQLString );
            else
                return true;
        }
        public bool UpdateState ( string signOne ,string signTwo ,string signTre ,string signFor ,string signFiv ,string state ,DateTime dt ,string signSix )
        {
            ArrayList SQLString = new ArrayList( );
            if ( !string.IsNullOrEmpty( signOne ) )
            {
                StringBuilder strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAK SET AK016='{0}',AK017='{1}' WHERE idx IN (" + signOne + ")" ,dt ,state );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( !string.IsNullOrEmpty( signTwo ) )
            {
                StringBuilder strSq = new StringBuilder( );
                strSq.AppendFormat( "UPDATE R_PQWZ SET WZ016='{1}',WZ017='{0}' WHERE idx IN (" + signTwo + ")" ,dt ,state );
                SQLString.Add( strSq.ToString( ) );
            }
            if ( !string.IsNullOrEmpty( signTre ) )
            {
                StringBuilder strS = new StringBuilder( );
                strS.AppendFormat( "UPDATE R_PQXZ SET XZ022='{0}',XZ025='{1}' WHERE idx IN (" + signTre + ")" ,dt ,state );
                SQLString.Add( strS.ToString( ) );
            }
            if ( !string.IsNullOrEmpty( signFor ) )
            {
                StringBuilder str = new StringBuilder( );
                str.AppendFormat( "UPDATE R_PQXZ SET XZ022='{0}',XZ025='{1}' WHERE idx IN (" + signFor + ")" ,dt ,state );
                SQLString.Add( str.ToString( ) );
            }
            if ( !string.IsNullOrEmpty( signFiv ) )
            {
                StringBuilder str = new StringBuilder( );
                str.AppendFormat( "UPDATE R_PQEZ SET EZ016='{0}',EZ015='{1}' WHERE idx IN (" + signFiv + ")" ,dt ,state );
                SQLString.Add( str.ToString( ) );
            }
            if ( !string.IsNullOrEmpty( signSix ) )
            {
                StringBuilder str = new StringBuilder( );
                str.AppendFormat( "UPDATE R_PQBE SET BE014='{0}',BE013='{1}' WHERE idx IN (" + signSix + ")" ,dt ,state );
                SQLString.Add( str.ToString( ) );
            }

            if ( SQLString.Count > 0 )
                return SqlHelper.ExecuteSqlTran( SQLString );
            else
                return true;
        }
        public bool UpdateState ( string signOne ,DateTime dt,string state )
        {
            StringBuilder strSq = new StringBuilder ( );
            strSq . AppendFormat ( "UPDATE R_PQWZ SET WZ016='{0}',WZ017='{1}' WHERE idx IN (" + signOne + ")" ,state ,dt );

            int row = SqlHelper . ExecuteNonQuery ( strSq . ToString ( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        public bool UpdateStateOf ( string oddNum , List<string> strList , string imPlement )
        {
            StringBuilder strS = new StringBuilder ( );
            strS . Append ( "UPDATE R_PQYZ SET YZ003='' WHERE YZ003 IS NULL;" );
            if ( SqlHelper . ExecuteNonQuery ( strS . ToString ( ) ) < 0 )
                return false;
            ArrayList SQLString = new ArrayList ( );
            bool result = false;
            string yz031 = "";
            foreach ( string str in strList )
            {
                if ( yz031 == "" )
                    yz031 = "'" + str + "'";
                else
                    yz031 = yz031 + "," + "'" + str + "'";
            }
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT YZ022,YZ023,YZ024,YZ025,YZ027,YZ009,YZ030,YZ032 FROM R_PQYZ WHERE YZ001=@YZ001 AND YZ031 IN (" + yz031 + ")" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@YZ001",SqlDbType.NVarChar)//,
                //new SqlParameter("@YZ003",SqlDbType.NVarChar),
                //new SqlParameter("@YZ009",SqlDbType.Date)
            };
            parameter [ 0 ] . Value = oddNum;
            //parameter[1].Value = exaMine;
            //parameter[1].Value = dtOne;
            DataTable da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) , parameter );
            if ( da != null && da . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    if ( string . IsNullOrEmpty ( da . Rows [ i ] [ "YZ009" ] . ToString ( ) ) )
                        UpdateStates ( da . Rows [ i ] [ "YZ022" ] . ToString ( ) , da . Rows [ i ] [ "YZ023" ] . ToString ( ) , da . Rows [ i ] [ "YZ024" ] . ToString ( ) , da . Rows [ i ] [ "YZ025" ] . ToString ( ) , da . Rows [ i ] [ "YZ027" ] . ToString ( ) , da . Rows [ i ] [ "YZ030" ] . ToString ( ) , da . Rows [ i ] [ "YZ032" ] . ToString ( ) , imPlement , DateTime . Now , SQLString );
                    else
                        UpdateStates ( da . Rows [ i ] [ "YZ022" ] . ToString ( ) , da . Rows [ i ] [ "YZ023" ] . ToString ( ) , da . Rows [ i ] [ "YZ024" ] . ToString ( ) , da . Rows [ i ] [ "YZ025" ] . ToString ( ) , da . Rows [ i ] [ "YZ027" ] . ToString ( ) , da . Rows [ i ] [ "YZ030" ] . ToString ( ) , da . Rows [ i ] [ "YZ032" ] . ToString ( ) , imPlement , Convert . ToDateTime ( da . Rows [ i ] [ "YZ009" ] . ToString ( ) ) , SQLString );
                }
                //StringBuilder strSq = new StringBuilder( );
                //strSq.AppendFormat( "UPDATE R_PQYZ SET YZ003='{0}' WHERE YZ001='{1}' AND YZ003='{2}'" ,imPlement ,oddNum ,exaMine );
                //SQLString.Add( strSq.ToString( ) );
            }
            else
                result = false;

            result = SqlHelper . ExecuteSqlTran ( SQLString );

            return result;
        }
        public bool UpdateStateOfs ( string oddNum , List<string> strList , string imPlement )
        {
            StringBuilder strS = new StringBuilder ( );
            strS . Append ( "UPDATE R_PQAP SET AP003='' WHERE AP003 IS NULL;" );
            if ( SqlHelper . ExecuteNonQuery ( strS . ToString ( ) ) < 0 )
                return false;
            ArrayList SQLString = new ArrayList ( );
            bool result = false;
            string yz031 = "";
            foreach ( string str in strList )
            {
                if ( yz031 == "" )
                    yz031 = "'" + str + "'";
                else
                    yz031 = yz031 + "," + "'" + str + "'";
            }
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT AP022,AP023,AP024,AP025,AP027,AP009,AP030,AP032 FROM R_PQAP WHERE AP001=@AP001 AND AP031 IN (" + yz031 + ")" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@AP001",SqlDbType.NVarChar)//,
                //new SqlParameter("@AP003",SqlDbType.NVarChar),
                //new SqlParameter("@AP009",SqlDbType.Date)
            };
            parameter [ 0 ] . Value = oddNum;
            //parameter[1].Value = exaMine;
            //parameter[1].Value = dtOne;
            DataTable da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) , parameter );
            if ( da != null && da . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    if ( string . IsNullOrEmpty ( da . Rows [ i ] [ "AP009" ] . ToString ( ) ) )
                        UpdateStates ( da . Rows [ i ] [ "AP022" ] . ToString ( ) , da . Rows [ i ] [ "AP023" ] . ToString ( ) , da . Rows [ i ] [ "AP024" ] . ToString ( ) , da . Rows [ i ] [ "AP025" ] . ToString ( ) , da . Rows [ i ] [ "AP027" ] . ToString ( ) , da . Rows [ i ] [ "AP030" ] . ToString ( ) , da . Rows [ i ] [ "AP032" ] . ToString ( ) , imPlement , DateTime . Now , SQLString );
                    else
                        UpdateStates ( da . Rows [ i ] [ "AP022" ] . ToString ( ) , da . Rows [ i ] [ "AP023" ] . ToString ( ) , da . Rows [ i ] [ "AP024" ] . ToString ( ) , da . Rows [ i ] [ "AP025" ] . ToString ( ) , da . Rows [ i ] [ "AP027" ] . ToString ( ) , da . Rows [ i ] [ "AP030" ] . ToString ( ) , da . Rows [ i ] [ "AP032" ] . ToString ( ) , imPlement , Convert . ToDateTime ( da . Rows [ i ] [ "AP009" ] . ToString ( ) ) , SQLString );
                }
                //StringBuilder strSq = new StringBuilder( );
                //strSq.AppendFormat( "UPDATE R_PQYZ SET YZ003='{0}' WHERE YZ001='{1}' AND YZ003='{2}'" ,imPlement ,oddNum ,exaMine );
                //SQLString.Add( strSq.ToString( ) );
            }
            else
                result = false;

            result = SqlHelper . ExecuteSqlTran ( SQLString );

            return result;
        }
        void UpdateStates ( string signOne , string signTwo , string signTre , string signFor , string signFiv , string signSix , string signSev , string state , DateTime dt , ArrayList SQLString )
        {

            if ( !string . IsNullOrEmpty ( signOne ) )
            {
                StringBuilder strSql = new StringBuilder ( );
                strSql . AppendFormat ( "UPDATE R_PQAK SET AK016='{0}',AK017='{1}' WHERE idx IN (" + signOne + ")" , dt , state );
                SQLString . Add ( strSql . ToString ( ) );
            }
            if ( !string . IsNullOrEmpty ( signTwo ) )
            {
                StringBuilder strSq = new StringBuilder ( );
                //strSq . AppendFormat ( "UPDATE R_PQWZ SET WZ016='{1}',WZ017='{0}' WHERE idx IN (" + signTwo + ")" , dt , state );
                strSq . AppendFormat ( "UPDATE R_PQWY SET WY003='{0}',WY004='{1}' WHERE idx IN (" + signTwo + ")" ,dt ,state );
                SQLString . Add ( strSq . ToString ( ) );
            }
            if ( !string . IsNullOrEmpty ( signTre ) )
            {
                StringBuilder strS = new StringBuilder ( );
                strS . AppendFormat ( "UPDATE R_PQXZ SET XZ022='{0}',XZ025='{1}' WHERE idx IN (" + signTre + ")" , dt , state );
                SQLString . Add ( strS . ToString ( ) );
            }
            if ( !string . IsNullOrEmpty ( signFor ) )
            {
                StringBuilder str = new StringBuilder ( );
                str . AppendFormat ( "UPDATE R_PQXZ SET XZ022='{0}',XZ025='{1}' WHERE idx IN (" + signFor + ")" , dt , state );
                SQLString . Add ( str . ToString ( ) );
            }
            if ( !string . IsNullOrEmpty ( signFiv ) )
            {
                StringBuilder str = new StringBuilder ( );
                str . AppendFormat ( "UPDATE R_PQEZ SET EZ016='{0}',EZ015='{1}' WHERE idx IN (" + signFiv + ")" , dt , state );
                SQLString . Add ( str . ToString ( ) );
            }
            if ( !string . IsNullOrEmpty ( signSix ) )
            {
                StringBuilder str = new StringBuilder ( );
                str . AppendFormat ( "UPDATE R_PQBE SET BE014='{0}',BE013='{1}' WHERE idx IN (" + signSix + ")" , dt , state );
                SQLString . Add ( str . ToString ( ) );
            }
            if ( !string . IsNullOrEmpty ( signSev ) )
            {
                StringBuilder str = new StringBuilder ( );
                str . AppendFormat ( "UPDATE R_PQCQ SET CQ113='{0}',CQ112='{1}' WHERE idx IN (" + signSev + ")" , dt , state );
                SQLString . Add ( str . ToString ( ) );
            }
        }
        public bool UpdateStateOfVirwTre ( string oddNum ,List<string> strList ,string imPlement )
        {
            StringBuilder strS = new StringBuilder ( );
            strS . Append ( "UPDATE R_PQAO SET AO003='' WHERE AO003 IS NULL;" );
            if ( SqlHelper . ExecuteNonQuery ( strS . ToString ( ) ) < 0 )
                return false;
            ArrayList SQLString = new ArrayList ( );
            bool result = false;
            string yz031 = "";
            foreach ( string str in strList )
            {
                if ( yz031 == "" )
                    yz031 = "'" + str + "'";
                else
                    yz031 = yz031 + "," + "'" + str + "'";
            }
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT AO022 FROM R_PQAO WHERE AO001=@AO001 AND AO021 IN (" + yz031 + ")" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@AO001",SqlDbType.NVarChar)//,
                //new SqlParameter("@AP003",SqlDbType.NVarChar),
                //new SqlParameter("@AP009",SqlDbType.Date)
            };
            parameter [ 0 ] . Value = oddNum;
            //parameter[1].Value = exaMine;
            //parameter[1].Value = dtOne;
            DataTable da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
            if ( da != null && da . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    if ( string . IsNullOrEmpty ( da . Rows [ i ] [ "AO009" ] . ToString ( ) ) )
                        UpdateStates ( "" ,da . Rows [ i ] [ "AO022" ] . ToString ( ) ,"" ,"" ,"" ,"" ,"" ,imPlement ,DateTime . Now ,SQLString );
                    else
                        UpdateStates ( "" ,da . Rows [ i ] [ "AO022" ] . ToString ( ) ,"" ,"" ,"" ,"" ,"" ,imPlement ,Convert . ToDateTime ( da . Rows [ i ] [ "AP009" ] . ToString ( ) ) ,SQLString );
                }
                //StringBuilder strSq = new StringBuilder( );
                //strSq.AppendFormat( "UPDATE R_PQYZ SET YZ003='{0}' WHERE YZ001='{1}' AND YZ003='{2}'" ,imPlement ,oddNum ,exaMine );
                //SQLString.Add( strSq.ToString( ) );
            }
            else
                result = false;

            result = SqlHelper . ExecuteSqlTran ( SQLString );

            return result;
        }
        public bool UpdateStateOfVirwFor ( string oddNum ,List<string> strList ,string imPlement )
        {
            StringBuilder strS = new StringBuilder ( );
            strS . Append ( "UPDATE R_PQAR SET AR003='' WHERE AR003 IS NULL;" );
            if ( SqlHelper . ExecuteNonQuery ( strS . ToString ( ) ) < 0 )
                return false;
            ArrayList SQLString = new ArrayList ( );
            bool result = false;
            string yz031 = "";
            foreach ( string str in strList )
            {
                if ( yz031 == "" )
                    yz031 = "'" + str + "'";
                else
                    yz031 = yz031 + "," + "'" + str + "'";
            }
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT AR022 FROM R_PQAR WHERE AR001=@AR001 AND AR021 IN (" + yz031 + ")" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@AR001",SqlDbType.NVarChar)//,
                //new SqlParameter("@AP003",SqlDbType.NVarChar),
                //new SqlParameter("@AP009",SqlDbType.Date)
            };
            parameter [ 0 ] . Value = oddNum;
            //parameter[1].Value = exaMine;
            //parameter[1].Value = dtOne;
            DataTable da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
            if ( da != null && da . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    if ( string . IsNullOrEmpty ( da . Rows [ i ] [ "AR009" ] . ToString ( ) ) )
                        UpdateStates ( "" ,da . Rows [ i ] [ "AR022" ] . ToString ( ) ,"" ,"" ,"" ,"" ,"" ,imPlement ,DateTime . Now ,SQLString );
                    else
                        UpdateStates ( "" ,da . Rows [ i ] [ "AR022" ] . ToString ( ) ,"" ,"" ,"" ,"" ,"" ,imPlement ,Convert . ToDateTime ( da . Rows [ i ] [ "AR009" ] . ToString ( ) ) ,SQLString );
                }
                //StringBuilder strSq = new StringBuilder( );
                //strSq.AppendFormat( "UPDATE R_PQYZ SET YZ003='{0}' WHERE YZ001='{1}' AND YZ003='{2}'" ,imPlement ,oddNum ,exaMine );
                //SQLString.Add( strSq.ToString( ) );
            }
            else
                result = false;

            result = SqlHelper . ExecuteSqlTran ( SQLString );

            return result;
        }
        public int UpdaetOfDt ( string oddNum ,string sate ,DateTime dtTwo )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQYZ SET YZ009=@YZ009 WHERE YZ001=@YZ001 AND YZ003=@YZ003" );
            SqlParameter[] parameter = {
                new SqlParameter("@YZ009",SqlDbType.Date),
                new SqlParameter("@YZ001",SqlDbType.NVarChar),
                new SqlParameter("@YZ003",SqlDbType.NVarChar)
            };
            parameter[0].Value = dtTwo;
            parameter[1].Value = oddNum;
            parameter[2].Value = sate;

            return SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
        }
        public int UpdaetOfDtAp ( string oddNum ,string sate ,DateTime dtTwo )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAP SET AP009=@AP009 WHERE AP001=@AP001 AND AP003=@AP003" );
            SqlParameter[] parameter = {
                new SqlParameter("@AP009",SqlDbType.Date),
                new SqlParameter("@AP001",SqlDbType.NVarChar),
                new SqlParameter("@AP003",SqlDbType.NVarChar)
            };
            parameter[0].Value = dtTwo;
            parameter[1].Value = oddNum;
            parameter[2].Value = sate;

            return SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
        }
        public int UpdaetOfDtViewTre ( string oddNum ,string sate ,DateTime dtTwo )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQAO SET AO009=@AO009 WHERE AO001=@AO001 AND AO003=@AO003" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@AO009",SqlDbType.Date),
                new SqlParameter("@AO001",SqlDbType.NVarChar),
                new SqlParameter("@AO003",SqlDbType.NVarChar)
            };
            parameter [ 0 ] . Value = dtTwo;
            parameter [ 1 ] . Value = oddNum;
            parameter [ 2 ] . Value = sate;

            return SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
        }
        public int UpdaetOfDtViewFor ( string oddNum ,string sate ,DateTime dtTwo )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQAR SET AR009=@AR009 WHERE AR001=@AR001 AND AR003=@AR003" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@AR009",SqlDbType.Date),
                new SqlParameter("@AR001",SqlDbType.NVarChar),
                new SqlParameter("@AR003",SqlDbType.NVarChar)
            };
            parameter [ 0 ] . Value = dtTwo;
            parameter [ 1 ] . Value = oddNum;
            parameter [ 2 ] . Value = sate;

            return SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool AddNew ( DataTable table )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT YZ001,YZ002,YZ003,YZ004,YZ005,YZ006,YZ007,YZ008,YZ009,YZ010,YZ011,YZ012,YZ013,YZ014,YZ015,YZ016,YZ017,YZ018,YZ019,YZ020,YZ021,YZ022,YZ023,YZ024,YZ025,YZ026,YZ027,YZ028,YZ029,YZ030 FROM R_PQYZ WHERE 1=2" );

            return SqlHelper.UpdateTable( table ,strSql.ToString( ) );
        }
        public bool AddNewOne ( DataTable table )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQAP WHERE 1=2" );

            return SqlHelper.UpdateTable( table ,strSql.ToString( ) );
        }
        public bool AddNewTwo ( DataTable table )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQAQ WHERE 1=2" );

            return SqlHelper.UpdateTable( table ,strSql.ToString( ) );
        }
        public bool AddNewTre ( DataTable table )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQAO WHERE 1=2" );

            return SqlHelper.UpdateTable( table ,strSql.ToString( ) );
        }
        public bool AddNewFor ( DataTable table )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQAR WHERE 1=2" );

            return SqlHelper.UpdateTable( table ,strSql.ToString( ) );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool AddOne ( DataTable table )
        {
            using ( SqlConnection conn = new SqlConnection ( SqlHelper . connstr ) )
            {
                conn . Open ( );
                SqlCommand cmd = new SqlCommand ( );
                cmd . Connection = conn;
                SqlTransaction tran = conn . BeginTransaction ( );
                cmd . Transaction = tran;
                try
                {
                    StringBuilder strSql = new StringBuilder ( );
                    MulaolaoLibrary . PayMentLibrary _model = new MulaolaoLibrary . PayMentLibrary ( );
                    if ( table != null && table . Rows . Count > 0 )
                    {
                        _model . YZ001 = table . Rows [ 0 ] [ "YZ001" ] . ToString ( );
                        DataTable choise = SqlHelper . ExecuteDataTable ( "SELECT * FROM R_PQYZ WHERE YZ001='" + _model . YZ001 + "'" );
                        for ( int i = 0 ; i < table . Rows . Count ; i++ )
                        {
                            _model = new MulaolaoLibrary . PayMentLibrary ( );
                            _model . YZ001 = table . Rows [ 0 ] [ "YZ001" ] . ToString ( );
                            _model . YZ031 = table . Rows [ i ] [ "YZ031" ] . ToString ( );
                            _model . YZ002 = table . Rows [ i ] [ "YZ002" ] . ToString ( );
                            _model . YZ003 = table . Rows [ i ] [ "YZ003" ] . ToString ( );
                            _model . YZ004 = table . Rows [ i ] [ "YZ004" ] . ToString ( );
                            _model . YZ005 = table . Rows [ i ] [ "YZ005" ] . ToString ( );
                            _model . YZ006 = table . Rows [ i ] [ "YZ006" ] . ToString ( );
                            _model . YZ007 = table . Rows [ i ] [ "YZ007" ] . ToString ( );
                            _model . YZ008 = table . Rows [ i ] [ "YZ008" ] . ToString ( );
                            if ( !string . IsNullOrEmpty ( table . Rows [ i ] [ "YZ009" ] . ToString ( ) ) )
                                _model . YZ009 = Convert . ToDateTime ( table . Rows [ i ] [ "YZ009" ] . ToString ( ) );
                            _model . YZ010 = string . IsNullOrEmpty ( table . Rows [ i ] [ "YZ010" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "YZ010" ] . ToString ( ) );
                            _model . YZ011 = string . IsNullOrEmpty ( table . Rows [ i ] [ "YZ011" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "YZ011" ] . ToString ( ) );
                            _model . YZ012 = string . IsNullOrEmpty ( table . Rows [ i ] [ "YZ012" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "YZ012" ] . ToString ( ) );
                            _model . YZ013 = string . IsNullOrEmpty ( table . Rows [ i ] [ "YZ013" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "YZ013" ] . ToString ( ) );
                            _model . YZ014 = string . IsNullOrEmpty ( table . Rows [ i ] [ "YZ014" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "YZ014" ] . ToString ( ) );
                            _model . YZ015 = string . IsNullOrEmpty ( table . Rows [ i ] [ "YZ015" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "YZ015" ] . ToString ( ) );
                            _model . YZ016 = string . IsNullOrEmpty ( table . Rows [ i ] [ "YZ016" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "YZ016" ] . ToString ( ) );
                            _model . YZ017 = string . IsNullOrEmpty ( table . Rows [ i ] [ "YZ017" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "YZ017" ] . ToString ( ) );
                            _model . YZ018 = string . IsNullOrEmpty ( table . Rows [ i ] [ "YZ018" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "YZ018" ] . ToString ( ) );
                            _model . YZ019 = string . IsNullOrEmpty ( table . Rows [ i ] [ "YZ019" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "YZ019" ] . ToString ( ) );
                            _model . YZ020 = table . Rows [ i ] [ "YZ020" ] . ToString ( );
                            _model . YZ021 = table . Rows [ i ] [ "YZ021" ] . ToString ( );
                            _model . YZ022 = table . Rows [ i ] [ "YZ022" ] . ToString ( );
                            _model . YZ023 = table . Rows [ i ] [ "YZ023" ] . ToString ( );
                            _model . YZ024 = table . Rows [ i ] [ "YZ024" ] . ToString ( );
                            _model . YZ025 = table . Rows [ i ] [ "YZ025" ] . ToString ( );
                            _model . YZ026 = string . IsNullOrEmpty ( table . Rows [ i ] [ "YZ026" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "YZ026" ] . ToString ( ) );
                            _model . YZ027 = table . Rows [ i ] [ "YZ027" ] . ToString ( );
                            _model . YZ028 = table . Rows [ i ] [ "YZ028" ] . ToString ( );
                            _model . YZ030 = table . Rows [ i ] [ "YZ030" ] . ToString ( );
                            _model . YZ032 = table . Rows [ i ] [ "YZ032" ] . ToString ( );

                            if ( choise . Select ( "YZ031='" + _model . YZ031 + "'" ) . Length > 0 )
                                UpdateOne ( cmd ,_model ,strSql ,tran ,conn );
                            else
                                AddOne ( cmd ,_model ,strSql ,tran ,conn );

                            if ( !string . IsNullOrEmpty ( _model . YZ022 ) )
                                UpdatePqak ( cmd ,_model ,strSql ,tran ,conn );
                            if ( !string . IsNullOrEmpty ( _model . YZ023 ) )
                                UpdatePqwz ( cmd ,_model ,strSql ,tran ,conn );
                            if ( !string . IsNullOrEmpty ( _model . YZ024 ) || !string . IsNullOrEmpty ( _model . YZ025 ) )
                                UpdatePqxz ( cmd ,_model ,strSql ,tran ,conn );
                            if ( !string . IsNullOrEmpty ( _model . YZ027 ) )
                                UpdatePqez ( cmd ,_model ,strSql ,tran ,conn );
                            if ( !string . IsNullOrEmpty ( _model . YZ030 ) )
                                UpdatePqbe ( cmd ,_model ,strSql ,tran ,conn );
                            if ( !string . IsNullOrEmpty ( _model . YZ032 ) )
                                UpdatePqcq ( cmd ,_model ,strSql ,tran ,conn );
                        }

                        for ( int k = 0 ; k < choise . Rows . Count ; k++ )
                        {
                            _model . YZ022 = choise . Rows [ k ] [ "YZ022" ] . ToString ( );
                            _model . YZ023 = choise . Rows [ k ] [ "YZ023" ] . ToString ( );
                            _model . YZ024 = choise . Rows [ k ] [ "YZ024" ] . ToString ( );
                            _model . YZ025 = choise . Rows [ k ] [ "YZ025" ] . ToString ( );
                            _model . YZ027 = choise . Rows [ k ] [ "YZ027" ] . ToString ( );
                            _model . YZ030 = choise . Rows [ k ] [ "YZ030" ] . ToString ( );
                            _model . YZ031 = choise . Rows [ k ] [ "YZ031" ] . ToString ( );
                            if ( table . Select ( "YZ031='" + _model . YZ031 + "'" ) . Length < 1 )
                                DeleteOne ( cmd ,_model ,strSql ,tran ,conn );
                        }

                    }
                    tran . Commit ( );
                    return true;
                }
                catch (Exception ex)
                {
                    AutoUpdate . LogHelper . WriteLog ( ex . Message );
                    tran . Rollback ( );
                    
                    return false;
                }
                finally
                {
                    cmd . Dispose ( );
                    conn . Close ( );
                }
            }
        }

        void UpdateOne ( SqlCommand cmd ,MulaolaoLibrary . PayMentLibrary _model ,StringBuilder strSql ,SqlTransaction tran ,SqlConnection conn )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQYZ SET " );
            strSql . Append ( " YZ002=@YZ002," );
            strSql . Append ( " YZ003=@YZ003," );
            strSql . Append ( " YZ004=@YZ004," );
            strSql . Append ( " YZ005=@YZ005," );
            strSql . Append ( " YZ006=@YZ006," );
            strSql . Append ( " YZ007=@YZ007," );
            strSql . Append ( " YZ008=@YZ008," );
            strSql . Append ( " YZ010=@YZ010," );
            strSql . Append ( " YZ011=@YZ011," );
            strSql . Append ( " YZ012=@YZ012," );
            strSql . Append ( " YZ013=@YZ013," );
            strSql . Append ( " YZ014=@YZ014," );
            strSql . Append ( " YZ015=@YZ015," );
            strSql . Append ( " YZ016=@YZ016," );
            strSql . Append ( " YZ017=@YZ017," );
            strSql . Append ( " YZ018=@YZ018," );
            strSql . Append ( " YZ019=@YZ019," );
            strSql . Append ( " YZ020=@YZ020," );
            strSql . Append ( " YZ021=@YZ021," );
            strSql . Append ( " YZ022=@YZ022," );
            strSql . Append ( " YZ023=@YZ023," );
            strSql . Append ( " YZ024=@YZ024," );
            strSql . Append ( " YZ025=@YZ025," );
            strSql . Append ( " YZ026=@YZ026," );
            strSql . Append ( " YZ027=@YZ027," );
            strSql . Append ( " YZ028=@YZ028," );
            strSql . Append ( " YZ030=@YZ030," );
            strSql . Append ( " YZ032=@YZ032 " );
            strSql . Append ( " WHERE YZ001=@YZ001 AND YZ031=@YZ031" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@YZ001",SqlDbType.NVarChar,20),
                new SqlParameter("@YZ002",SqlDbType.NVarChar,20),
                new SqlParameter("@YZ003",SqlDbType.NVarChar,20),
                new SqlParameter("@YZ004",SqlDbType.NVarChar,20),
                new SqlParameter("@YZ005",SqlDbType.NVarChar,20),
                new SqlParameter("@YZ006",SqlDbType.NVarChar,100),
                new SqlParameter("@YZ007",SqlDbType.NVarChar,50),
                new SqlParameter("@YZ008",SqlDbType.NVarChar,20),
                new SqlParameter("@YZ010",SqlDbType.Decimal,11),
                new SqlParameter("@YZ011",SqlDbType.Decimal,11),
                new SqlParameter("@YZ012",SqlDbType.Decimal,11),
                new SqlParameter("@YZ013",SqlDbType.Decimal,11),
                new SqlParameter("@YZ014",SqlDbType.Decimal,11),
                new SqlParameter("@YZ015",SqlDbType.Decimal,11),
                new SqlParameter("@YZ016",SqlDbType.Decimal,11),
                new SqlParameter("@YZ017",SqlDbType.Decimal,11),
                new SqlParameter("@YZ018",SqlDbType.Decimal,11),
                new SqlParameter("@YZ019",SqlDbType.Decimal,11),
                new SqlParameter("@YZ020",SqlDbType.NVarChar,50),
                new SqlParameter("@YZ021",SqlDbType.NVarChar,100),
                new SqlParameter("@YZ022",SqlDbType.NVarChar,2000),
                new SqlParameter("@YZ023",SqlDbType.NVarChar,2000),
                new SqlParameter("@YZ024",SqlDbType.NVarChar,2000),
                new SqlParameter("@YZ025",SqlDbType.NVarChar,2000),
                new SqlParameter("@YZ026",SqlDbType.Decimal,11),
                new SqlParameter("@YZ027",SqlDbType.NVarChar,2000),
                new SqlParameter("@YZ028",SqlDbType.NVarChar,20),
                new SqlParameter("@YZ030",SqlDbType.NVarChar,2000),
                new SqlParameter("@YZ031",SqlDbType.NVarChar,20),
                new SqlParameter("@YZ032",SqlDbType.NVarChar,2000)
            };
            parameter [ 0 ] . Value = _model . YZ001;
            parameter [ 1 ] . Value = _model . YZ002;
            parameter [ 2 ] . Value = _model . YZ003;
            parameter [ 3 ] . Value = _model . YZ004;
            parameter [ 4 ] . Value = _model . YZ005;
            parameter [ 5 ] . Value = _model . YZ006;
            parameter [ 6 ] . Value = _model . YZ007;
            parameter [ 7 ] . Value = _model . YZ008;
            parameter [ 8 ] . Value = _model . YZ010;
            parameter [ 9 ] . Value = _model . YZ011;
            parameter [ 10 ] . Value = _model . YZ012;
            parameter [ 11 ] . Value = _model . YZ013;
            parameter [ 12 ] . Value = _model . YZ014;
            parameter [ 13 ] . Value = _model . YZ015;
            parameter [ 14 ] . Value = _model . YZ016;
            parameter [ 15 ] . Value = _model . YZ017;
            parameter [ 16 ] . Value = _model . YZ018;
            parameter [ 17 ] . Value = _model . YZ019;
            parameter [ 18 ] . Value = _model . YZ020;
            parameter [ 19 ] . Value = _model . YZ021;
            parameter [ 20 ] . Value = _model . YZ022;
            parameter [ 21 ] . Value = _model . YZ023;
            parameter [ 22 ] . Value = _model . YZ024;
            parameter [ 23 ] . Value = _model . YZ025;
            parameter [ 24 ] . Value = _model . YZ026;
            parameter [ 25 ] . Value = _model . YZ027;
            parameter [ 26 ] . Value = _model . YZ028;
            parameter [ 27 ] . Value = _model . YZ030;
            parameter [ 28 ] . Value = _model . YZ031;
            parameter [ 29 ] . Value = _model . YZ032;

            cmd . Parameters . Clear ( );
            SqlHelper . PrepareCommand ( cmd ,conn ,tran ,strSql . ToString ( ) ,parameter );
            cmd . CommandText = strSql . ToString ( );
            cmd . ExecuteNonQuery ( );

            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQYZ SET " );
            if ( _model . YZ009 == null )
                strSql . Append ( " YZ009=NULL" );
            else
                strSql . AppendFormat ( " YZ009='{0}'" ,_model . YZ009 );
            strSql . Append ( " WHERE YZ001=@YZ001 AND YZ031=@YZ031" );
            SqlParameter [ ] paramete = {
                new SqlParameter("@YZ001",SqlDbType.NVarChar,20),
                new SqlParameter("@YZ031",SqlDbType.NVarChar,20)
            };
            paramete [ 0 ] . Value = _model . YZ001;
            paramete [ 1 ] . Value = _model . YZ031;

            cmd . Parameters . Clear ( );
            SqlHelper . PrepareCommand ( cmd ,conn ,tran ,strSql . ToString ( ) ,paramete );
            cmd . CommandText = strSql . ToString ( );
            cmd . ExecuteNonQuery ( );
        }
        void AddOne ( SqlCommand cmd ,MulaolaoLibrary . PayMentLibrary _model ,StringBuilder strSql ,SqlTransaction tran ,SqlConnection conn )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQYZ (" );
            strSql . Append ( "YZ001,YZ002,YZ003,YZ004,YZ005,YZ006,YZ007,YZ008,YZ010,YZ011,YZ012,YZ013,YZ014,YZ015,YZ016,YZ017,YZ018,YZ019,YZ020,YZ021,YZ022,YZ023,YZ024,YZ025,YZ026,YZ027,YZ028,YZ030,YZ031,YZ032)" );
            strSql . Append ( " VALUES (" );
            strSql . Append ( "@YZ001,@YZ002,@YZ003,@YZ004,@YZ005,@YZ006,@YZ007,@YZ008,@YZ010,@YZ011,@YZ012,@YZ013,@YZ014,@YZ015,@YZ016,@YZ017,@YZ018,@YZ019,@YZ020,@YZ021,@YZ022,@YZ023,@YZ024,@YZ025,@YZ026,@YZ027,@YZ028,@YZ030,@YZ031,@YZ032)" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@YZ001",SqlDbType.NVarChar,20),
                new SqlParameter("@YZ002",SqlDbType.NVarChar,20),
                new SqlParameter("@YZ003",SqlDbType.NVarChar,20),
                new SqlParameter("@YZ004",SqlDbType.NVarChar,20),
                new SqlParameter("@YZ005",SqlDbType.NVarChar,20),
                new SqlParameter("@YZ006",SqlDbType.NVarChar,100),
                new SqlParameter("@YZ007",SqlDbType.NVarChar,50),
                new SqlParameter("@YZ008",SqlDbType.NVarChar,20),
                new SqlParameter("@YZ010",SqlDbType.Decimal,11),
                new SqlParameter("@YZ011",SqlDbType.Decimal,11),
                new SqlParameter("@YZ012",SqlDbType.Decimal,11),
                new SqlParameter("@YZ013",SqlDbType.Decimal,11),
                new SqlParameter("@YZ014",SqlDbType.Decimal,11),
                new SqlParameter("@YZ015",SqlDbType.Decimal,11),
                new SqlParameter("@YZ016",SqlDbType.Decimal,11),
                new SqlParameter("@YZ017",SqlDbType.Decimal,11),
                new SqlParameter("@YZ018",SqlDbType.Decimal,11),
                new SqlParameter("@YZ019",SqlDbType.Decimal,11),
                new SqlParameter("@YZ020",SqlDbType.NVarChar,50),
                new SqlParameter("@YZ021",SqlDbType.NVarChar,100),
                new SqlParameter("@YZ022",SqlDbType.NVarChar,2000),
                new SqlParameter("@YZ023",SqlDbType.NVarChar,2000),
                new SqlParameter("@YZ024",SqlDbType.NVarChar,2000),
                new SqlParameter("@YZ025",SqlDbType.NVarChar,2000),
                new SqlParameter("@YZ026",SqlDbType.Decimal,11),
                new SqlParameter("@YZ027",SqlDbType.NVarChar,2000),
                new SqlParameter("@YZ028",SqlDbType.NVarChar,20),
                new SqlParameter("@YZ030",SqlDbType.NVarChar,2000),
                new SqlParameter("@YZ031",SqlDbType.NVarChar,20),
                new SqlParameter("@YZ032",SqlDbType.NVarChar,2000)
            };
            parameter [ 0 ] . Value = _model . YZ001;
            parameter [ 1 ] . Value = _model . YZ002;
            parameter [ 2 ] . Value = _model . YZ003;
            parameter [ 3 ] . Value = _model . YZ004;
            parameter [ 4 ] . Value = _model . YZ005;
            parameter [ 5 ] . Value = _model . YZ006;
            parameter [ 6 ] . Value = _model . YZ007;
            parameter [ 7 ] . Value = _model . YZ008;
            parameter [ 8 ] . Value = _model . YZ010;
            parameter [ 9 ] . Value = _model . YZ011;
            parameter [ 10 ] . Value = _model . YZ012;
            parameter [ 11 ] . Value = _model . YZ013;
            parameter [ 12 ] . Value = _model . YZ014;
            parameter [ 13 ] . Value = _model . YZ015;
            parameter [ 14 ] . Value = _model . YZ016;
            parameter [ 15 ] . Value = _model . YZ017;
            parameter [ 16 ] . Value = _model . YZ018;
            parameter [ 17 ] . Value = _model . YZ019;
            parameter [ 18 ] . Value = _model . YZ020;
            parameter [ 19 ] . Value = _model . YZ021;
            parameter [ 20 ] . Value = _model . YZ022;
            parameter [ 21 ] . Value = _model . YZ023;
            parameter [ 22 ] . Value = _model . YZ024;
            parameter [ 23 ] . Value = _model . YZ025;
            parameter [ 24 ] . Value = _model . YZ026;
            parameter [ 25 ] . Value = _model . YZ027;
            parameter [ 26 ] . Value = _model . YZ028;
            parameter [ 27 ] . Value = _model . YZ030;
            parameter [ 28 ] . Value = _model . YZ031;
            parameter [ 29 ] . Value = _model . YZ032;

            cmd . Parameters . Clear ( );
            SqlHelper . PrepareCommand ( cmd ,conn ,tran ,strSql . ToString ( ) ,parameter );
            cmd . CommandText = strSql . ToString ( );
            cmd . ExecuteNonQuery ( );

            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQYZ SET " );
            if ( _model . YZ009 == null || _model . YZ009 <= DateTime . MinValue || _model . YZ009 >= DateTime . MaxValue )
                strSql . Append ( " YZ009=NULL" );
            else
                strSql . AppendFormat ( " YZ009='{0}'" ,_model . YZ009 );
            strSql . Append ( " WHERE YZ001=@YZ001 AND YZ031=@YZ031" );
            SqlParameter [ ] paramete = {
                new SqlParameter("@YZ001",SqlDbType.NVarChar,20),
                new SqlParameter("@YZ031",SqlDbType.NVarChar,20)
            };
            paramete [ 0 ] . Value = _model . YZ001;
            paramete [ 1 ] . Value = _model . YZ031;

            cmd . Parameters . Clear ( );
            SqlHelper . PrepareCommand ( cmd ,conn ,tran ,strSql . ToString ( ) ,paramete );
            cmd . CommandText = strSql . ToString ( );
            cmd . ExecuteNonQuery ( );
        }
        void DeleteOne ( SqlCommand cmd ,MulaolaoLibrary.PayMentLibrary _model ,StringBuilder strSql ,SqlTransaction tran ,SqlConnection conn )
        {
            strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQYZ " );
            strSql.Append( "WHERE YZ001=@YZ001 AND YZ031=@YZ031" );
            SqlParameter[] parameter = {
                new SqlParameter("@YZ001",SqlDbType.NVarChar,20),
                new SqlParameter("@YZ031",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = _model.YZ001;
            parameter[1].Value = _model.YZ031;

            cmd.Parameters.Clear( );
            SqlHelper.PrepareCommand( cmd ,conn ,tran ,strSql.ToString( ) ,parameter );
            cmd.CommandText = strSql.ToString( );
            cmd.ExecuteNonQuery( );

            if ( !string.IsNullOrEmpty( _model.YZ022 ) )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAK SET AK016=NULL,AK017='' WHERE idx IN (" + _model.YZ022 + ")" );
                cmd.CommandText = strSql.ToString( );
                cmd.ExecuteNonQuery( );
            }
            if ( !string.IsNullOrEmpty( _model.YZ023 ) )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQWY SET WY003=NULL,WY004='' WHERE idx IN (" + _model.YZ023 + ")" );
                cmd.CommandText = strSql.ToString( );
                cmd.ExecuteNonQuery( );
            }
            if ( !string.IsNullOrEmpty( _model.YZ024 ) )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQXZ SET XZ022=NULL,XZ025='' WHERE idx IN (" + _model.YZ024 + ")" );
                cmd.CommandText = strSql.ToString( );
                cmd.ExecuteNonQuery( );
            }
            if ( !string.IsNullOrEmpty( _model.YZ025 ) )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQXZ SET XZ022=NULL,XZ025='' WHERE idx IN (" + _model.YZ025 + ")" );
                cmd.CommandText = strSql.ToString( );
                cmd.ExecuteNonQuery( );
            }
            if ( !string.IsNullOrEmpty( _model.YZ027 ) )
            {
                strSql = new StringBuilder( );
                strSql.Append( "UPDATE R_PQEZ SET " );
                strSql.Append( "EZ016=NULL," );
                strSql.Append( "EZ015=''" );
                strSql.Append( " WHERE idx IN (" + _model.YZ027 + ")" );
                cmd.CommandText = strSql.ToString( );
                cmd.ExecuteNonQuery( );
            }
            if ( !string.IsNullOrEmpty( _model.YZ030 ) )
            {
                strSql = new StringBuilder( );
                strSql.Append( "UPDATE R_PQBE SET " );
                strSql.Append( "BE014=NULL," );
                strSql.Append( "BE013=''" );
                strSql.Append( " WHERE idx IN (" + _model.YZ030 + ")" );
                cmd.CommandText = strSql.ToString( );
                cmd.ExecuteNonQuery( );
            }
        }
        void UpdatePqak ( SqlCommand cmd ,MulaolaoLibrary.PayMentLibrary _model ,StringBuilder strSql ,SqlTransaction tran ,SqlConnection conn )
        {
            strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAK SET " );
            strSql.Append( "AK016=@AK016," );
            strSql.Append( "AK017=@AK017" );
            strSql.Append( "  WHERE idx IN (" + _model.YZ022 + ")" );
            SqlParameter[] parameter ={
                new SqlParameter("@AK016",SqlDbType.Date),
                new SqlParameter("@AK017",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = _model.YZ009;
            parameter[1].Value = _model.YZ003;

            cmd.Parameters.Clear( );
            SqlHelper.PrepareCommand( cmd ,conn ,tran ,strSql.ToString( ) ,parameter );
            cmd.CommandText = strSql.ToString( );
            cmd.ExecuteNonQuery( );
        }
        void UpdatePqwz ( SqlCommand cmd ,MulaolaoLibrary.PayMentLibrary _model ,StringBuilder strSql ,SqlTransaction tran ,SqlConnection conn )
        {
            strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQWY SET WY003=@WY003,WY004=@WY004 WHERE idx IN (" + _model.YZ023 + ")" );
            SqlParameter[] parameter = {
                new SqlParameter("@WY004",SqlDbType.NVarChar,20),
                new SqlParameter("@WY003",SqlDbType.Date),
            };
            parameter[0].Value = _model.YZ003;
            parameter[1].Value = _model.YZ009;

            cmd.Parameters.Clear( );
            SqlHelper.PrepareCommand( cmd ,conn ,tran ,strSql.ToString( ) ,parameter );
            cmd.CommandText = strSql.ToString( );
            cmd.ExecuteNonQuery( );
        }
        void UpdatePqxz ( SqlCommand cmd ,MulaolaoLibrary.PayMentLibrary _model ,StringBuilder strSql ,SqlTransaction tran ,SqlConnection conn )
        {
            strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQXZ SET " );
            strSql.Append( "XZ022=@XZ022," );
            strSql.Append( "XZ025=@XZ025" );
            if ( !string.IsNullOrEmpty( _model.YZ024 ) )
                strSql.Append( " WHERE idx IN (" + _model.YZ024 + ")" );
            if ( !string.IsNullOrEmpty( _model.YZ025 ) )
                strSql.Append( " WHERE idx IN (" + _model.YZ025 + ")" );
            SqlParameter[] parameter = {
                new SqlParameter("@XZ022",SqlDbType.Date),
                new SqlParameter("@XZ025",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = _model.YZ009;
            parameter[1].Value = _model.YZ003;

            cmd.Parameters.Clear( );
            SqlHelper.PrepareCommand( cmd ,conn ,tran ,strSql.ToString( ) ,parameter );
            cmd.CommandText = strSql.ToString( );
            cmd.ExecuteNonQuery( );
        }
        void UpdatePqez ( SqlCommand cmd ,MulaolaoLibrary.PayMentLibrary _model ,StringBuilder strSql ,SqlTransaction tran ,SqlConnection conn )
        {
            strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQEZ SET " );
            strSql.Append( "EZ016=@EZ016," );
            strSql.Append( "EZ015=@EZ015" );
            strSql.Append( " WHERE idx IN (" + _model.YZ027 + ")" );
            SqlParameter[] parameter = {
                new SqlParameter("@EZ016",SqlDbType.Date),
                new SqlParameter("@EZ015",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = _model.YZ009;
            parameter[1].Value = _model.YZ003;

            cmd.Parameters.Clear( );
            SqlHelper.PrepareCommand( cmd ,conn ,tran ,strSql.ToString( ) ,parameter );
            cmd.CommandText = strSql.ToString( );
            cmd.ExecuteNonQuery( );
        }
        void UpdatePqbe ( SqlCommand cmd ,MulaolaoLibrary.PayMentLibrary _model ,StringBuilder strSql ,SqlTransaction tran ,SqlConnection conn )
        {
            strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQBE SET " );
            strSql.Append( "BE014=@BE014," );
            strSql.Append( "BE013=@BE013" );
            strSql.Append( " WHERE idx IN (" + _model.YZ030 + ")" );
            SqlParameter[] parameter = {
                new SqlParameter("@BE014",SqlDbType.Date),
                new SqlParameter("@BE013",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = _model.YZ009;
            parameter[1].Value = _model.YZ003;

            cmd.Parameters.Clear( );
            SqlHelper.PrepareCommand( cmd ,conn ,tran ,strSql.ToString( ) ,parameter );
            cmd.CommandText = strSql.ToString( );
            cmd.ExecuteNonQuery( );
        }
        void UpdatePqcq ( SqlCommand cmd ,MulaolaoLibrary . PayMentLibrary _model ,StringBuilder strSql ,SqlTransaction tran ,SqlConnection conn )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQCQ SET " );
            strSql . Append ( "CQ112=@CQ112," );
            strSql . Append ( "CQ113=@CQ113" );
            strSql . Append ( " WHERE idx IN (" + _model . YZ032 + ")" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@CQ112",SqlDbType.NVarChar,20),
                new SqlParameter("@CQ113",SqlDbType.Date,3)
            };
            parameter [ 0 ] . Value = _model . YZ003;
            parameter [ 1 ] . Value = _model . YZ009;

            cmd . Parameters . Clear ( );
            SqlHelper . PrepareCommand ( cmd ,conn ,tran ,strSql . ToString ( ) ,parameter );
            cmd . CommandText = strSql . ToString ( );
            cmd . ExecuteNonQuery ( );
        }

        public bool AddTwo ( DataTable table )
        {
            using ( SqlConnection conn = new SqlConnection ( SqlHelper . connstr ) )
            {
                conn . Open ( );
                SqlCommand cmd = new SqlCommand ( );
                cmd . Connection = conn;
                SqlTransaction tran = conn . BeginTransaction ( );
                cmd . Transaction = tran;
                try
                {
                    MulaolaoLibrary . PayMentOneLibrary _modelOne = new MulaolaoLibrary . PayMentOneLibrary ( );
                    StringBuilder strSql = new StringBuilder ( );
                    if ( table != null && table . Rows . Count > 0 )
                    {
                        _modelOne . AP001 = table . Rows [ 0 ] [ "AP001" ] . ToString ( );
                        DataTable choise = SqlHelper . ExecuteDataTable ( "SELECT * FROM R_PQAP WHERE AP001='" + _modelOne . AP001 + "'" );
                        for ( int i = 0 ; i < table . Rows . Count ; i++ )
                        {
                            _modelOne = new MulaolaoLibrary . PayMentOneLibrary ( );
                            _modelOne . AP001 = table . Rows [ 0 ] [ "AP001" ] . ToString ( );
                            _modelOne . AP031 = table . Rows [ i ] [ "AP031" ] . ToString ( );
                            _modelOne . AP002 = table . Rows [ i ] [ "AP002" ] . ToString ( );
                            _modelOne . AP003 = table . Rows [ i ] [ "AP003" ] . ToString ( );
                            _modelOne . AP004 = table . Rows [ i ] [ "AP004" ] . ToString ( );
                            _modelOne . AP005 = table . Rows [ i ] [ "AP005" ] . ToString ( );
                            _modelOne . AP006 = table . Rows [ i ] [ "AP006" ] . ToString ( );
                            _modelOne . AP007 = table . Rows [ i ] [ "AP007" ] . ToString ( );
                            _modelOne . AP008 = table . Rows [ i ] [ "AP008" ] . ToString ( );
                            if ( !string . IsNullOrEmpty ( table . Rows [ i ] [ "AP009" ] . ToString ( ) ) )
                                _modelOne . AP009 = Convert . ToDateTime ( table . Rows [ i ] [ "AP009" ] . ToString ( ) );
                            _modelOne . AP010 = string . IsNullOrEmpty ( table . Rows [ i ] [ "AP010" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "AP010" ] . ToString ( ) );
                            _modelOne . AP011 = string . IsNullOrEmpty ( table . Rows [ i ] [ "AP011" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "AP011" ] . ToString ( ) );
                            _modelOne . AP012 = string . IsNullOrEmpty ( table . Rows [ i ] [ "AP012" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "AP012" ] . ToString ( ) );
                            _modelOne . AP013 = string . IsNullOrEmpty ( table . Rows [ i ] [ "AP013" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "AP013" ] . ToString ( ) );
                            _modelOne . AP014 = string . IsNullOrEmpty ( table . Rows [ i ] [ "AP014" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "AP014" ] . ToString ( ) );
                            _modelOne . AP015 = string . IsNullOrEmpty ( table . Rows [ i ] [ "AP015" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "AP015" ] . ToString ( ) );
                            _modelOne . AP016 = string . IsNullOrEmpty ( table . Rows [ i ] [ "AP016" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "AP016" ] . ToString ( ) );
                            _modelOne . AP017 = string . IsNullOrEmpty ( table . Rows [ i ] [ "AP017" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "AP017" ] . ToString ( ) );
                            _modelOne . AP018 = string . IsNullOrEmpty ( table . Rows [ i ] [ "AP018" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "AP018" ] . ToString ( ) );
                            _modelOne . AP019 = string . IsNullOrEmpty ( table . Rows [ i ] [ "AP019" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "AP019" ] . ToString ( ) );
                            _modelOne . AP020 = table . Rows [ i ] [ "AP020" ] . ToString ( );
                            _modelOne . AP021 = table . Rows [ i ] [ "AP021" ] . ToString ( );
                            _modelOne . AP022 = table . Rows [ i ] [ "AP022" ] . ToString ( );
                            _modelOne . AP023 = table . Rows [ i ] [ "AP023" ] . ToString ( );
                            _modelOne . AP024 = table . Rows [ i ] [ "AP024" ] . ToString ( );
                            _modelOne . AP025 = table . Rows [ i ] [ "AP025" ] . ToString ( );
                            _modelOne . AP026 = string . IsNullOrEmpty ( table . Rows [ i ] [ "AP026" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "AP026" ] . ToString ( ) );
                            _modelOne . AP027 = table . Rows [ i ] [ "AP027" ] . ToString ( );
                            _modelOne . AP028 = table . Rows [ i ] [ "AP028" ] . ToString ( );
                            _modelOne . AP030 = table . Rows [ i ] [ "AP030" ] . ToString ( );
                            _modelOne . AP032 = table . Rows [ i ] [ "AP032" ] . ToString ( );

                            if ( choise . Select ( "AP031='" + _modelOne . AP031 + "'" ) . Length > 0 )
                                UpdateTwo ( cmd ,_modelOne ,strSql ,tran ,conn );
                            else
                                AddTwo ( cmd ,_modelOne ,strSql ,tran ,conn );

                            if ( !string . IsNullOrEmpty ( _modelOne . AP022 ) )
                                UpdatePqakOne ( cmd ,_modelOne ,strSql ,tran ,conn );
                            if ( !string . IsNullOrEmpty ( _modelOne . AP023 ) )
                                UpdatePqwzOne ( cmd ,_modelOne ,strSql ,tran ,conn );
                            if ( !string . IsNullOrEmpty ( _modelOne . AP024 ) || !string . IsNullOrEmpty ( _modelOne . AP025 ) )
                                UpdatePqxzOne ( cmd ,_modelOne ,strSql ,tran ,conn );
                            if ( !string . IsNullOrEmpty ( _modelOne . AP027 ) )
                                UpdatePqezOne ( cmd ,_modelOne ,strSql ,tran ,conn );
                            if ( !string . IsNullOrEmpty ( _modelOne . AP030 ) )
                                UpdatePqbeOne ( cmd ,_modelOne ,strSql ,tran ,conn );
                            if ( !string . IsNullOrEmpty ( _modelOne . AP032 ) )
                                UpdatePqcqOne ( cmd ,_modelOne ,strSql ,tran ,conn );
                        }

                        for ( int k = 0 ; k < choise . Rows . Count ; k++ )
                        {
                            _modelOne . AP022 = choise . Rows [ k ] [ "AP022" ] . ToString ( );
                            _modelOne . AP023 = choise . Rows [ k ] [ "AP023" ] . ToString ( );
                            _modelOne . AP024 = choise . Rows [ k ] [ "AP024" ] . ToString ( );
                            _modelOne . AP025 = choise . Rows [ k ] [ "AP025" ] . ToString ( );
                            _modelOne . AP027 = choise . Rows [ k ] [ "AP027" ] . ToString ( );
                            _modelOne . AP030 = choise . Rows [ k ] [ "AP030" ] . ToString ( );
                            _modelOne . AP031 = choise . Rows [ k ] [ "AP031" ] . ToString ( );
                            if ( table . Select ( "AP031='" + _modelOne . AP031 + "'" ) . Length < 1 )
                                DeleteTwo ( cmd ,_modelOne ,strSql ,tran ,conn );
                        }
                    }

                    tran . Commit ( );
                    return true;
                }
                catch (Exception ex)
                {
                    AutoUpdate . LogHelper . WriteLog ( ex . Message );
                    tran . Rollback ( );
                    return false;
                }
                finally
                {
                    cmd . Dispose ( );
                    conn . Close ( );
                }
            }
        }

        void UpdateTwo ( SqlCommand cmd ,MulaolaoLibrary.PayMentOneLibrary _modelOne ,StringBuilder strSql ,SqlTransaction tran ,SqlConnection conn )
        {
            strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAP SET " );
            strSql.Append( " AP002=@AP002," );
            strSql.Append( " AP003=@AP003," );
            strSql.Append( " AP004=@AP004," );
            strSql.Append( " AP005=@AP005," );
            strSql.Append( " AP006=@AP006," );
            strSql.Append( " AP007=@AP007," );
            strSql.Append( " AP008=@AP008," );
            //strSql.Append( " AP009=@AP009," );
            strSql.Append( " AP010=@AP010," );
            strSql.Append( " AP011=@AP011," );
            strSql.Append( " AP012=@AP012," );
            strSql.Append( " AP013=@AP013," );
            strSql.Append( " AP014=@AP014," );
            strSql.Append( " AP015=@AP015," );
            strSql.Append( " AP016=@AP016," );
            strSql.Append( " AP017=@AP017," );
            strSql.Append( " AP018=@AP018," );
            strSql.Append( " AP019=@AP019," );
            strSql.Append( " AP020=@AP020," );
            strSql.Append( " AP021=@AP021," );
            strSql.Append( " AP022=@AP022," );
            strSql.Append( " AP023=@AP023," );
            strSql.Append( " AP024=@AP024," );
            strSql.Append( " AP025=@AP025," );
            strSql.Append( " AP026=@AP026," );
            strSql.Append( " AP027=@AP027," );
            strSql.Append( " AP028=@AP028," );
            strSql.Append( " AP030=@AP030," );
            strSql . Append ( "AP032=@AP032 " );
            strSql .Append( " WHERE AP001=@AP001 AND AP031=@AP031" );
            SqlParameter[] parameter = {
                new SqlParameter("@AP001",SqlDbType.NVarChar,20),
                new SqlParameter("@AP002",SqlDbType.NVarChar,20),
                new SqlParameter("@AP003",SqlDbType.NVarChar,20),
                new SqlParameter("@AP004",SqlDbType.NVarChar,20),
                new SqlParameter("@AP005",SqlDbType.NVarChar,20),
                new SqlParameter("@AP006",SqlDbType.NVarChar,100),
                new SqlParameter("@AP007",SqlDbType.NVarChar,50),
                new SqlParameter("@AP008",SqlDbType.NVarChar,20),
                //new SqlParameter("@AP009",SqlDbType.Date),
                new SqlParameter("@AP010",SqlDbType.Decimal,11),
                new SqlParameter("@AP011",SqlDbType.Decimal,11),
                new SqlParameter("@AP012",SqlDbType.Decimal,11),
                new SqlParameter("@AP013",SqlDbType.Decimal,11),
                new SqlParameter("@AP014",SqlDbType.Decimal,11),
                new SqlParameter("@AP015",SqlDbType.Decimal,11),
                new SqlParameter("@AP016",SqlDbType.Decimal,11),
                new SqlParameter("@AP017",SqlDbType.Decimal,11),
                new SqlParameter("@AP018",SqlDbType.Decimal,11),
                new SqlParameter("@AP019",SqlDbType.Decimal,11),
                new SqlParameter("@AP020",SqlDbType.NVarChar,50),
                new SqlParameter("@AP021",SqlDbType.NVarChar,100),
                new SqlParameter("@AP022",SqlDbType.NVarChar,2000),
                new SqlParameter("@AP023",SqlDbType.NVarChar,2000),
                new SqlParameter("@AP024",SqlDbType.NVarChar,2000),
                new SqlParameter("@AP025",SqlDbType.NVarChar,2000),
                new SqlParameter("@AP026",SqlDbType.Decimal,11),
                new SqlParameter("@AP027",SqlDbType.NVarChar,2000),
                new SqlParameter("@AP028",SqlDbType.NVarChar,20),
                new SqlParameter("@AP030",SqlDbType.NVarChar,2000),
                new SqlParameter("@AP031",SqlDbType.NVarChar,20),
                new SqlParameter("@AP032",SqlDbType.NVarChar,2000)
            };
            parameter[0].Value = _modelOne.AP001;
            parameter[1].Value = _modelOne.AP002;
            parameter[2].Value = _modelOne.AP003;
            parameter[3].Value = _modelOne.AP004;
            parameter[4].Value = _modelOne.AP005;
            parameter[5].Value = _modelOne.AP006;
            parameter[6].Value = _modelOne.AP007;
            parameter[7].Value = _modelOne.AP008;
            //parameter[8].Value = _modelOne.AP009;
            parameter[8].Value = _modelOne.AP010;
            parameter[9].Value = _modelOne.AP011;
            parameter[10].Value = _modelOne.AP012;
            parameter[11].Value = _modelOne.AP013;
            parameter[12].Value = _modelOne.AP014;
            parameter[13].Value = _modelOne.AP015;
            parameter[14].Value = _modelOne.AP016;
            parameter[15].Value = _modelOne.AP017;
            parameter[16].Value = _modelOne.AP018;
            parameter[17].Value = _modelOne.AP019;
            parameter[18].Value = _modelOne.AP020;
            parameter[19].Value = _modelOne.AP021;
            parameter[20].Value = _modelOne.AP022;
            parameter[21].Value = _modelOne.AP023;
            parameter[22].Value = _modelOne.AP024;
            parameter[23].Value = _modelOne.AP025;
            parameter[24].Value = _modelOne.AP026;
            parameter[25].Value = _modelOne.AP027;
            parameter[26].Value = _modelOne.AP028;
            parameter[27].Value = _modelOne.AP030;
            parameter[28].Value = _modelOne.AP031;
            parameter [ 29 ] . Value = _modelOne . AP032;

            cmd .Parameters.Clear( );
            SqlHelper.PrepareCommand( cmd ,conn ,tran ,strSql.ToString( ) ,parameter );
            cmd.CommandText = strSql.ToString( );
            cmd.ExecuteNonQuery( );

            strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAP SET " );
            if ( _modelOne.AP009 == null )
                strSql.Append( " AP009=NULL" );
            else
                strSql.AppendFormat( " AP009='{0}'" ,_modelOne.AP009 );
            strSql.Append( " WHERE AP001=@AP001 AND AP031=@AP031" );
            SqlParameter[] paramete = {
                new SqlParameter("@AP001",SqlDbType.NVarChar,20),
                new SqlParameter("@AP031",SqlDbType.NVarChar,20)
            };
            paramete[0].Value = _modelOne.AP001;
            paramete[1].Value = _modelOne.AP031;

            cmd.Parameters.Clear( );
            SqlHelper.PrepareCommand( cmd ,conn ,tran ,strSql.ToString( ) ,paramete );
            cmd.CommandText = strSql.ToString( );
            cmd.ExecuteNonQuery( );
        }
        void AddTwo ( SqlCommand cmd ,MulaolaoLibrary.PayMentOneLibrary _modelOne ,StringBuilder strSql ,SqlTransaction tran ,SqlConnection conn )
        {
            strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAP (" );
            strSql.Append( "AP001,AP002,AP003,AP004,AP005,AP006,AP007,AP008,AP010,AP011,AP012,AP013,AP014,AP015,AP016,AP017,AP018,AP019,AP020,AP021,AP022,AP023,AP024,AP025,AP026,AP027,AP028,AP030,AP031,AP032)" );
            strSql.Append( " VALUES (" );
            strSql.Append( "@AP001,@AP002,@AP003,@AP004,@AP005,@AP006,@AP007,@AP008,@AP010,@AP011,@AP012,@AP013,@AP014,@AP015,@AP016,@AP017,@AP018,@AP019,@AP020,@AP021,@AP022,@AP023,@AP024,@AP025,@AP026,@AP027,@AP028,@AP030,@AP031,@AP032)" );
            SqlParameter[] parameter = {
                new SqlParameter("@AP001",SqlDbType.NVarChar,20),
                new SqlParameter("@AP002",SqlDbType.NVarChar,20),
                new SqlParameter("@AP003",SqlDbType.NVarChar,20),
                new SqlParameter("@AP004",SqlDbType.NVarChar,20),
                new SqlParameter("@AP005",SqlDbType.NVarChar,20),
                new SqlParameter("@AP006",SqlDbType.NVarChar,100),
                new SqlParameter("@AP007",SqlDbType.NVarChar,50),
                new SqlParameter("@AP008",SqlDbType.NVarChar,20),
                new SqlParameter("@AP010",SqlDbType.Decimal,11),
                new SqlParameter("@AP011",SqlDbType.Decimal,11),
                new SqlParameter("@AP012",SqlDbType.Decimal,11),
                new SqlParameter("@AP013",SqlDbType.Decimal,11),
                new SqlParameter("@AP014",SqlDbType.Decimal,11),
                new SqlParameter("@AP015",SqlDbType.Decimal,11),
                new SqlParameter("@AP016",SqlDbType.Decimal,11),
                new SqlParameter("@AP017",SqlDbType.Decimal,11),
                new SqlParameter("@AP018",SqlDbType.Decimal,11),
                new SqlParameter("@AP019",SqlDbType.Decimal,11),
                new SqlParameter("@AP020",SqlDbType.NVarChar,50),
                new SqlParameter("@AP021",SqlDbType.NVarChar,100),
                new SqlParameter("@AP022",SqlDbType.NVarChar,2000),
                new SqlParameter("@AP023",SqlDbType.NVarChar,2000),
                new SqlParameter("@AP024",SqlDbType.NVarChar,2000),
                new SqlParameter("@AP025",SqlDbType.NVarChar,2000),
                new SqlParameter("@AP026",SqlDbType.Decimal,11),
                new SqlParameter("@AP027",SqlDbType.NVarChar,2000),
                new SqlParameter("@AP028",SqlDbType.NVarChar,20),
                new SqlParameter("@AP030",SqlDbType.NVarChar,2000),
                new SqlParameter("@AP031",SqlDbType.NVarChar,20),
                new SqlParameter("@AP032",SqlDbType.NVarChar,2000)
            };
            parameter[0].Value = _modelOne.AP001;
            parameter[1].Value = _modelOne.AP002;
            parameter[2].Value = _modelOne.AP003;
            parameter[3].Value = _modelOne.AP004;
            parameter[4].Value = _modelOne.AP005;
            parameter[5].Value = _modelOne.AP006;
            parameter[6].Value = _modelOne.AP007;
            parameter[7].Value = _modelOne.AP008;
            parameter[8].Value = _modelOne.AP010;
            parameter[9].Value = _modelOne.AP011;
            parameter[10].Value = _modelOne.AP012;
            parameter[11].Value = _modelOne.AP013;
            parameter[12].Value = _modelOne.AP014;
            parameter[13].Value = _modelOne.AP015;
            parameter[14].Value = _modelOne.AP016;
            parameter[15].Value = _modelOne.AP017;
            parameter[16].Value = _modelOne.AP018;
            parameter[17].Value = _modelOne.AP019;
            parameter[18].Value = _modelOne.AP020;
            parameter[19].Value = _modelOne.AP021;
            parameter[20].Value = _modelOne.AP022;
            parameter[21].Value = _modelOne.AP023;
            parameter[22].Value = _modelOne.AP024;
            parameter[23].Value = _modelOne.AP025;
            parameter[24].Value = _modelOne.AP026;
            parameter[25].Value = _modelOne.AP027;
            parameter[26].Value = _modelOne.AP028;
            parameter[27].Value = _modelOne.AP030;
            parameter[28].Value = _modelOne.AP031;
            parameter [ 29 ] . Value = _modelOne . AP032;

            cmd .Parameters.Clear( );
            SqlHelper.PrepareCommand( cmd ,conn ,tran ,strSql.ToString( ) ,parameter );
            cmd.CommandText = strSql.ToString( );
            cmd.ExecuteNonQuery( );

            strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAP SET " );
            if ( _modelOne.AP009 == null || _modelOne.AP009 <= DateTime.MinValue || _modelOne.AP009 >= DateTime.MaxValue )
                strSql.Append( " AP009=NULL" );
            else
                strSql.AppendFormat( " AP009='{0}'" ,_modelOne.AP009 );
            strSql.Append( " WHERE AP001=@AP001 AND AP031=@AP031" );
            SqlParameter[] paramete = {
                new SqlParameter("@AP001",SqlDbType.NVarChar,20),
                new SqlParameter("@AP031",SqlDbType.NVarChar,20)
            };
            paramete[0].Value = _modelOne.AP001;
            paramete[1].Value = _modelOne.AP031;

            cmd.Parameters.Clear( );
            SqlHelper.PrepareCommand( cmd ,conn ,tran ,strSql.ToString( ) ,paramete );
            cmd.CommandText = strSql.ToString( );
            cmd.ExecuteNonQuery( );
        }
        void DeleteTwo ( SqlCommand cmd ,MulaolaoLibrary.PayMentOneLibrary _modelOne ,StringBuilder strSql ,SqlTransaction tran ,SqlConnection conn )
        {
            strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQAP " );
            strSql.Append( "WHERE AP001=@AP001 AND AP031=@AP031" );
            SqlParameter[] parameter = {
                new SqlParameter("@AP001",SqlDbType.NVarChar,20),
                new SqlParameter("@AP031",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = _modelOne.AP001;
            parameter[1].Value = _modelOne.AP031;

            cmd.Parameters.Clear( );
            SqlHelper.PrepareCommand( cmd ,conn ,tran ,strSql.ToString( ) ,parameter );
            cmd.CommandText = strSql.ToString( );
            cmd.ExecuteNonQuery( );

            if ( !string.IsNullOrEmpty( _modelOne.AP022 ) )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAK SET AK016=NULL,AK017='' WHERE idx IN (" + _modelOne.AP022 + ")" );
                cmd.CommandText = strSql.ToString( );
                cmd.ExecuteNonQuery( );
            }
            if ( !string.IsNullOrEmpty( _modelOne.AP023 ) )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQWY SET WY004='',WY003=NULL WHERE idx IN (" + _modelOne.AP023 + ")" );
                cmd.CommandText = strSql.ToString( );
                cmd.ExecuteNonQuery( );
            }
            if ( !string.IsNullOrEmpty( _modelOne.AP024 ) )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQXZ SET XZ022=NULL,XZ025='' WHERE idx IN (" + _modelOne.AP024 + ")" );
                cmd.CommandText = strSql.ToString( );
                cmd.ExecuteNonQuery( );
            }
            if ( !string.IsNullOrEmpty( _modelOne.AP025 ) )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQXZ SET XZ022=NULL,XZ025='' WHERE idx IN (" + _modelOne.AP025 + ")" );
                cmd.CommandText = strSql.ToString( );
                cmd.ExecuteNonQuery( );
            }
            if ( !string.IsNullOrEmpty( _modelOne.AP027 ) )
            {
                strSql = new StringBuilder( );
                strSql.Append( "UPDATE R_PQEZ SET " );
                strSql.Append( "EZ016=NULL," );
                strSql.Append( "EZ015=''" );
                strSql.Append( " WHERE idx IN (" + _modelOne.AP027 + ")" );
                cmd.CommandText = strSql.ToString( );
                cmd.ExecuteNonQuery( );
            }
            if ( !string.IsNullOrEmpty( _modelOne.AP030 ) )
            {
                strSql = new StringBuilder( );
                strSql.Append( "UPDATE R_PQBE SET " );
                strSql.Append( "BE014=NULL," );
                strSql.Append( "BE013=''" );
                strSql.Append( " WHERE idx IN (" + _modelOne.AP030 + ")" );
                cmd.CommandText = strSql.ToString( );
                cmd.ExecuteNonQuery( );
            }
        }
        void UpdatePqakOne ( SqlCommand cmd ,MulaolaoLibrary.PayMentOneLibrary _modelOne ,StringBuilder strSql ,SqlTransaction tran ,SqlConnection conn )
        {
            strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAK SET " );
            strSql.Append( "AK016=@AK016," );
            strSql.Append( "AK017=@AK017" );
            strSql.Append( "  WHERE idx IN (" + _modelOne.AP022 + ")" );
            SqlParameter[] parameter ={
                new SqlParameter("@AK016",SqlDbType.Date),
                new SqlParameter("@AK017",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = _modelOne.AP009;
            parameter[1].Value = _modelOne.AP003;

            cmd.Parameters.Clear( );
            SqlHelper.PrepareCommand( cmd ,conn ,tran ,strSql.ToString( ) ,parameter );
            cmd.CommandText = strSql.ToString( );
            cmd.ExecuteNonQuery( );
        }
        void UpdatePqwzOne ( SqlCommand cmd ,MulaolaoLibrary.PayMentOneLibrary _modelOne ,StringBuilder strSql ,SqlTransaction tran ,SqlConnection conn )
        {
            strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQWY SET WY003=@WY003,WY004=@WY004 WHERE idx IN (" + _modelOne.AP023 + ")" );
            SqlParameter[] parameter = {
                new SqlParameter("@WY004",SqlDbType.NVarChar,20),
                new SqlParameter("@WY003",SqlDbType.Date),
            };
            parameter[0].Value = _modelOne.AP003;
            parameter[1].Value = _modelOne.AP009;

            cmd.Parameters.Clear( );
            SqlHelper.PrepareCommand( cmd ,conn ,tran ,strSql.ToString( ) ,parameter );
            cmd.CommandText = strSql.ToString( );
            cmd.ExecuteNonQuery( );
        }
        void UpdatePqxzOne ( SqlCommand cmd ,MulaolaoLibrary.PayMentOneLibrary _modelOne ,StringBuilder strSql ,SqlTransaction tran ,SqlConnection conn )
        {
            strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQXZ SET " );
            strSql.Append( "XZ022=@XZ022," );
            strSql.Append( "XZ025=@XZ025" );
            if ( !string.IsNullOrEmpty( _modelOne.AP024 ) )
                strSql.Append( " WHERE idx IN (" + _modelOne.AP024 + ")" );
            if ( !string.IsNullOrEmpty( _modelOne.AP025 ) )
                strSql.Append( " WHERE idx IN (" + _modelOne.AP025 + ")" );
            SqlParameter[] parameter = {
                new SqlParameter("@XZ022",SqlDbType.Date),
                new SqlParameter("@XZ025",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = _modelOne.AP009;
            parameter[1].Value = _modelOne.AP003;

            cmd.Parameters.Clear( );
            SqlHelper.PrepareCommand( cmd ,conn ,tran ,strSql.ToString( ) ,parameter );
            cmd.CommandText = strSql.ToString( );
            cmd.ExecuteNonQuery( );
        }
        void UpdatePqezOne ( SqlCommand cmd ,MulaolaoLibrary.PayMentOneLibrary _modelOne ,StringBuilder strSql ,SqlTransaction tran ,SqlConnection conn )
        {
            strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQEZ SET " );
            strSql.Append( "EZ016=@EZ016," );
            strSql.Append( "EZ015=@EZ015" );
            strSql.Append( " WHERE idx IN (" + _modelOne.AP027 + ")" );
            SqlParameter[] parameter = {
                new SqlParameter("@EZ016",SqlDbType.Date),
                new SqlParameter("@EZ015",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = _modelOne.AP009;
            parameter[1].Value = _modelOne.AP003;

            cmd.Parameters.Clear( );
            SqlHelper.PrepareCommand( cmd ,conn ,tran ,strSql.ToString( ) ,parameter );
            cmd.CommandText = strSql.ToString( );
            cmd.ExecuteNonQuery( );
        }
        void UpdatePqbeOne ( SqlCommand cmd ,MulaolaoLibrary.PayMentOneLibrary _modelOne ,StringBuilder strSql ,SqlTransaction tran ,SqlConnection conn )
        {
            strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQBE SET " );
            strSql.Append( "BE014=@BE014," );
            strSql.Append( "BE013=@BE013" );
            strSql.Append( " WHERE idx IN (" + _modelOne.AP030 + ")" );
            SqlParameter[] parameter = {
                new SqlParameter("@BE014",SqlDbType.Date),
                new SqlParameter("@BE013",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = _modelOne.AP009;
            parameter[1].Value = _modelOne.AP003;

            cmd.Parameters.Clear( );
            SqlHelper.PrepareCommand( cmd ,conn ,tran ,strSql.ToString( ) ,parameter );
            cmd.CommandText = strSql.ToString( );
            cmd.ExecuteNonQuery( );
        }
        void UpdatePqcqOne ( SqlCommand cmd ,MulaolaoLibrary . PayMentOneLibrary _modelOne ,StringBuilder strSql ,SqlTransaction tran ,SqlConnection conn )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQCQ SET " );
            strSql . Append ( "CQ112=@CQ112," );
            strSql . Append ( "CQ113=@CQ113" );
            strSql . Append ( " WHERE idx IN (" + _modelOne . AP032 + ")" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@CQ112",SqlDbType.NVarChar,20),
                new SqlParameter("@CQ113",SqlDbType.Date,3)
            };
            parameter [ 0 ] . Value = _modelOne . AP003;
            parameter [ 1 ] . Value = _modelOne . AP009;

            cmd . Parameters . Clear ( );
            SqlHelper . PrepareCommand ( cmd ,conn ,tran ,strSql . ToString ( ) ,parameter );
            cmd . CommandText = strSql . ToString ( );
            cmd . ExecuteNonQuery ( );
        }

        public bool AddTre ( DataTable table )
        {
            using ( SqlConnection conn = new SqlConnection( SqlHelper.connstr ) )
            {
                conn.Open( );
                SqlCommand cmd = new SqlCommand( );
                cmd.Connection = conn;
                SqlTransaction tran = conn.BeginTransaction( );
                cmd.Transaction = tran;
                try
                {
                    MulaolaoLibrary.QayMentTwoLibrary _modelTwo = new MulaolaoLibrary.QayMentTwoLibrary( );
                    StringBuilder strSql = new StringBuilder( );
                    if ( table != null && table.Rows.Count > 0 )
                    {
                        _modelTwo.AQ001 = table.Rows[0]["AQ001"].ToString( );
                        DataTable choise = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQAQ WHERE AQ001='" + _modelTwo.AQ001 + "'" );
                        for ( int i = 0 ; i < table.Rows.Count ; i++ )
                        {
                            _modelTwo = new MulaolaoLibrary.QayMentTwoLibrary( );
                            _modelTwo.AQ001 = table.Rows[0]["AQ001"].ToString( );
                            _modelTwo.AQ018 = table.Rows[i]["AQ018"].ToString( );
                            _modelTwo.AQ002 = table.Rows[i]["AQ002"].ToString( );
                            if ( !string.IsNullOrEmpty( table.Rows[i]["AQ003"].ToString( ) ) )
                                _modelTwo.AQ003 = Convert.ToDateTime( table.Rows[i]["AQ003"].ToString( ) );
                            if ( !string.IsNullOrEmpty( table.Rows[i]["AQ004"].ToString( ) ) )
                                _modelTwo.AQ004 =  Convert.ToDateTime( table.Rows[i]["AQ004"].ToString( ) );
                            _modelTwo.AQ005 = string.IsNullOrEmpty( table.Rows[i]["AQ005"].ToString( ) ) == true ? 0 : Convert.ToInt32( table.Rows[i]["AQ005"].ToString( ) );
                            _modelTwo.AQ006 = string.IsNullOrEmpty( table.Rows[i]["AQ006"].ToString( ) ) == true ? 0 : Convert.ToDecimal( table.Rows[i]["AQ006"].ToString( ) );
                            _modelTwo.AQ007 = string.IsNullOrEmpty( table.Rows[i]["AQ007"].ToString( ) ) == true ? 0 : Convert.ToInt32( table.Rows[i]["AQ007"].ToString( ) );
                            if ( !string.IsNullOrEmpty( table.Rows[i]["AQ008"].ToString( ) ) )
                                _modelTwo.AQ008 = Convert.ToDateTime( table.Rows[i]["AQ008"].ToString( ) );
                            _modelTwo.AQ009 = string.IsNullOrEmpty( table.Rows[i]["AQ009"].ToString( ) ) == true ? 0 : Convert.ToInt32( table.Rows[i]["AQ009"].ToString( ) );
                            _modelTwo.AQ010 = string.IsNullOrEmpty( table.Rows[i]["AQ010"].ToString( ) ) == true ? 0 : Convert.ToDecimal( table.Rows[i]["AQ010"].ToString( ) );
                            _modelTwo.AQ011 = table.Rows[i]["AQ011"].ToString( );
                            if ( !string.IsNullOrEmpty( table.Rows[i]["AQ012"].ToString( ) ) )
                                _modelTwo.AQ012 = Convert.ToDateTime( table.Rows[i]["AQ012"].ToString( ) );
                            _modelTwo.AQ013 = string.IsNullOrEmpty( table.Rows[i]["AQ013"].ToString( ) ) == true ? 0 : Convert.ToDecimal( table.Rows[i]["AQ013"].ToString( ) );
                            _modelTwo.AQ014 = string.IsNullOrEmpty( table.Rows[i]["AQ014"].ToString( ) ) == true ? 0 : Convert.ToDecimal( table.Rows[i]["AQ014"].ToString( ) );
                            _modelTwo.AQ015 = string.IsNullOrEmpty( table.Rows[i]["AQ015"].ToString( ) ) == true ? 0 : Convert.ToDecimal( table.Rows[i]["AQ015"].ToString( ) );
                            _modelTwo.AQ016 = string.IsNullOrEmpty( table.Rows[i]["AQ016"].ToString( ) ) == true ? 0 : Convert.ToDecimal( table.Rows[i]["AQ016"].ToString( ) );
                            _modelTwo.AQ017 = table.Rows[i]["AQ017"].ToString( );

                            if ( choise.Select( "AQ018='" + _modelTwo.AQ018 + "'" ).Length > 0 )
                                UpdateTre( cmd ,_modelTwo ,strSql ,tran ,conn );
                            else
                                AddTre( cmd ,_modelTwo ,strSql ,tran ,conn );
                        }

                        for ( int k = 0 ; k < choise.Rows.Count ; k++ )
                        {
                            _modelTwo.AQ018 = choise.Rows[k]["AQ018"].ToString( );
                            if ( table.Select( "AQ018='" + _modelTwo.AQ018 + "'" ).Length < 1 )
                                DeleteTre( cmd ,_modelTwo ,strSql ,tran ,conn );
                        }

                    }

                    tran.Commit( );
                    return true;
                }
                catch (Exception ex)
                {
                    AutoUpdate . LogHelper . WriteLog ( ex . Message );
                    tran .Rollback( );
                    return false;
                }
                finally
                {
                    cmd.Dispose( );
                    conn.Close( );
                }
            }
        }

        void UpdateTre ( SqlCommand cmd ,MulaolaoLibrary.QayMentTwoLibrary _modelTwo ,StringBuilder strSql ,SqlTransaction tran ,SqlConnection conn )
        {
            strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAQ SET " );
            strSql.Append( " AQ002=@AQ002," );         
            strSql.Append( " AQ005=@AQ005," );
            strSql.Append( " AQ006=@AQ006," );
            strSql.Append( " AQ007=@AQ007," );
            strSql.Append( " AQ009=@AQ009," );
            strSql.Append( " AQ010=@AQ010," );
            strSql.Append( " AQ011=@AQ011," );
            strSql.Append( " AQ013=@AQ013," );
            strSql.Append( " AQ014=@AQ014," );
            strSql.Append( " AQ015=@AQ015," );
            strSql.Append( " AQ016=@AQ016," );
            strSql.Append( " AQ017=@AQ017" );
            strSql.Append( " WHERE AQ001=@AQ001 AND AQ018=@AQ018" );
            SqlParameter[] parameter = {
                new SqlParameter("@AQ001",SqlDbType.NVarChar,20),
                new SqlParameter("@AQ002",SqlDbType.NVarChar,50),
                new SqlParameter("@AQ005",SqlDbType.Int),
                new SqlParameter("@AQ006",SqlDbType.Decimal,6),
                new SqlParameter("@AQ007",SqlDbType.Int),
                new SqlParameter("@AQ009",SqlDbType.Int),
                new SqlParameter("@AQ010",SqlDbType.Decimal,6),
                new SqlParameter("@AQ011",SqlDbType.NVarChar,20),
                new SqlParameter("@AQ013",SqlDbType.Decimal,11),
                new SqlParameter("@AQ014",SqlDbType.Decimal,11),
                new SqlParameter("@AQ015",SqlDbType.Decimal,11),
                new SqlParameter("@AQ016",SqlDbType.Decimal,11),
                new SqlParameter("@AQ017",SqlDbType.NVarChar,20),
                new SqlParameter("@AQ018",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = _modelTwo.AQ001;
            parameter[1].Value = _modelTwo.AQ002;
            parameter[2].Value = _modelTwo.AQ005;
            parameter[3].Value = _modelTwo.AQ006;
            parameter[4].Value = _modelTwo.AQ007;
            parameter[5].Value = _modelTwo.AQ009;
            parameter[6].Value = _modelTwo.AQ010;
            parameter[7].Value = _modelTwo.AQ011;
            parameter[8].Value = _modelTwo.AQ013;
            parameter[9].Value = _modelTwo.AQ014;
            parameter[10].Value = _modelTwo.AQ015;
            parameter[11].Value = _modelTwo.AQ016;
            parameter[12].Value = _modelTwo.AQ017;
            parameter[13].Value = _modelTwo.AQ018;

            cmd.Parameters.Clear( );
            SqlHelper.PrepareCommand( cmd ,conn ,tran ,strSql.ToString( ) ,parameter );
            cmd.CommandText = strSql.ToString( );
            cmd.ExecuteNonQuery( );

            strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAQ SET " );
            if ( _modelTwo.AQ003 == null )
                strSql.Append( " AQ003=NULL," );
            else
                strSql.AppendFormat( " AQ003='{0}'," ,_modelTwo.AQ003 );
            if ( _modelTwo.AQ004 == null )
                strSql.Append( " AQ004=NULL," );
            else
                strSql.AppendFormat( " AQ004='{0}'," ,_modelTwo.AQ004 );
            if ( _modelTwo.AQ008 == null )
                strSql.Append( " AQ008=NULL," );
            else
                strSql.AppendFormat( " AQ008='{0}'," ,_modelTwo.AQ008 );
            if ( _modelTwo.AQ012 == null )
                strSql.Append( " AQ012=NULL" );
            else
                strSql.AppendFormat( " AQ012='{0}'" ,_modelTwo.AQ012 );
            strSql.Append( " WHERE AQ001=@AQ001 AND AQ018=@AQ018" );
            SqlParameter[] paramete = {
                new SqlParameter("@AQ001",SqlDbType.NVarChar,20),
                new SqlParameter("@AQ018",SqlDbType.NVarChar,20)
            };
            paramete[0].Value = _modelTwo.AQ001;
            paramete[1].Value = _modelTwo.AQ018;

            cmd.Parameters.Clear( );
            SqlHelper.PrepareCommand( cmd ,conn ,tran ,strSql.ToString( ) ,paramete );
            cmd.CommandText = strSql.ToString( );
            cmd.ExecuteNonQuery( );
        }
        void AddTre ( SqlCommand cmd ,MulaolaoLibrary.QayMentTwoLibrary _modelTwo ,StringBuilder strSql ,SqlTransaction tran ,SqlConnection conn )
        {
            strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAQ (" );
            strSql.Append( "AQ001,AQ002,AQ005,AQ006,AQ007,AQ009,AQ010,AQ011,AQ013,AQ014,AQ015,AQ016,AQ017,AQ018)" );
            strSql.Append( " VALUES (" );
            strSql.Append( "@AQ001,@AQ002,@AQ005,@AQ006,@AQ007,@AQ009,@AQ010,@AQ011,@AQ013,@AQ014,@AQ015,@AQ016,@AQ017,@AQ018)" );
            SqlParameter[] parameter = {
                new SqlParameter("@AQ001",SqlDbType.NVarChar,20),
                new SqlParameter("@AQ002",SqlDbType.NVarChar,50),
                new SqlParameter("@AQ005",SqlDbType.Int),
                new SqlParameter("@AQ006",SqlDbType.Decimal,6),
                new SqlParameter("@AQ007",SqlDbType.Int),
                new SqlParameter("@AQ009",SqlDbType.Int),
                new SqlParameter("@AQ010",SqlDbType.Decimal,6),
                new SqlParameter("@AQ011",SqlDbType.NVarChar,20),
                new SqlParameter("@AQ013",SqlDbType.Decimal,11),
                new SqlParameter("@AQ014",SqlDbType.Decimal,11),
                new SqlParameter("@AQ015",SqlDbType.Decimal,11),
                new SqlParameter("@AQ016",SqlDbType.Decimal,11),
                new SqlParameter("@AQ017",SqlDbType.NVarChar,20),
                new SqlParameter("@AQ018",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = _modelTwo.AQ001;
            parameter[1].Value = _modelTwo.AQ002;
            parameter[2].Value = _modelTwo.AQ005;
            parameter[3].Value = _modelTwo.AQ006;
            parameter[4].Value = _modelTwo.AQ007;
            parameter[5].Value = _modelTwo.AQ009;
            parameter[6].Value = _modelTwo.AQ010;
            parameter[7].Value = _modelTwo.AQ011;
            parameter[8].Value = _modelTwo.AQ013;
            parameter[9].Value = _modelTwo.AQ014;
            parameter[10].Value = _modelTwo.AQ015;
            parameter[11].Value = _modelTwo.AQ016;
            parameter[12].Value = _modelTwo.AQ017;
            parameter[13].Value = _modelTwo.AQ018;

            cmd.Parameters.Clear( );
            SqlHelper.PrepareCommand( cmd ,conn ,tran ,strSql.ToString( ) ,parameter );
            cmd.CommandText = strSql.ToString( );
            cmd.ExecuteNonQuery( );

            strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAQ SET " );
            if ( _modelTwo.AQ003 == null || _modelTwo.AQ003 <= DateTime.MinValue || _modelTwo.AQ003 >= DateTime.MaxValue )
                strSql.Append( " AQ003=NULL," );
            else
                strSql.AppendFormat( " AQ003='{0}'," ,_modelTwo.AQ003 );
            if ( _modelTwo.AQ004 == null || _modelTwo.AQ004 <= DateTime.MinValue || _modelTwo.AQ004 >= DateTime.MaxValue )
                strSql.Append( " AQ004=NULL," );
            else
                strSql.AppendFormat( " AQ004='{0}'," ,_modelTwo.AQ004 );
            if ( _modelTwo.AQ008 == null || _modelTwo.AQ008 <= DateTime.MinValue || _modelTwo.AQ008 >= DateTime.MaxValue )
                strSql.Append( " AQ008=NULL," );
            else
                strSql.AppendFormat( " AQ008='{0}'," ,_modelTwo.AQ008 );
            if ( _modelTwo.AQ012 == null || _modelTwo.AQ012 <= DateTime.MinValue || _modelTwo.AQ012 >= DateTime.MaxValue )
                strSql.Append( " AQ012=NULL" );
            else
                strSql.AppendFormat( " AQ012='{0}'" ,_modelTwo.AQ012 );
            strSql.Append( " WHERE AQ001=@AQ001 AND AQ018=@AQ018" );
            SqlParameter[] paramete = {
                new SqlParameter("@AQ001",SqlDbType.NVarChar,20),
                new SqlParameter("@AQ018",SqlDbType.NVarChar,20)
            };
            paramete[0].Value = _modelTwo.AQ001;
            paramete[1].Value = _modelTwo.AQ018;

            cmd.Parameters.Clear( );
            SqlHelper.PrepareCommand( cmd ,conn ,tran ,strSql.ToString( ) ,paramete );
            cmd.CommandText = strSql.ToString( );
            cmd.ExecuteNonQuery( );
        }
        void DeleteTre ( SqlCommand cmd ,MulaolaoLibrary.QayMentTwoLibrary _modelTwo ,StringBuilder strSql ,SqlTransaction tran ,SqlConnection conn )
        {
            strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQAQ " );
            strSql.Append( "WHERE AQ001=@AQ001 AND AQ018=@AQ018" );
            SqlParameter[] parameter = {
                new SqlParameter("@AQ001",SqlDbType.NVarChar,20),
                new SqlParameter("@AQ018",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = _modelTwo.AQ001;
            parameter[1].Value = _modelTwo.AQ018;

            cmd.Parameters.Clear( );
            SqlHelper.PrepareCommand( cmd ,conn ,tran ,strSql.ToString( ) ,parameter );
            cmd.CommandText = strSql.ToString( );
            cmd.ExecuteNonQuery( );
        }

        public bool AddFor ( DataTable table )
        {
            using ( SqlConnection conn = new SqlConnection ( SqlHelper . connstr ) )
            {
                conn . Open ( );
                SqlCommand cmd = new SqlCommand ( );
                cmd . Connection = conn;
                SqlTransaction tran = conn . BeginTransaction ( );
                cmd . Transaction = tran;
                try
                {
                    MulaolaoLibrary . PayMentTreLibrary _modelTre = new MulaolaoLibrary . PayMentTreLibrary ( );
                    StringBuilder strSql = new StringBuilder ( );
                    if ( table != null && table . Rows . Count > 0 )
                    {
                        _modelTre . AO001 = table . Rows [ 0 ] [ "AO001" ] . ToString ( );
                        DataTable choise = SqlHelper . ExecuteDataTable ( "SELECT * FROM R_PQAO WHERE AO001='" + _modelTre . AO001 + "'" );
                        for ( int i = 0 ; i < table . Rows . Count ; i++ )
                        {
                            _modelTre = new MulaolaoLibrary . PayMentTreLibrary ( );
                            _modelTre . AO001 = table . Rows [ 0 ] [ "AO001" ] . ToString ( );
                            _modelTre . AO021 = table . Rows [ i ] [ "AO021" ] . ToString ( );
                            _modelTre . AO002 = table . Rows [ i ] [ "AO002" ] . ToString ( );
                            _modelTre . AO003 = table . Rows [ i ] [ "AO003" ] . ToString ( );
                            _modelTre . AO004 = table . Rows [ i ] [ "AO004" ] . ToString ( );
                            _modelTre . AO005 = table . Rows [ i ] [ "AO005" ] . ToString ( );
                            _modelTre . AO006 = table . Rows [ i ] [ "AO006" ] . ToString ( );
                            _modelTre . AO007 = table . Rows [ i ] [ "AO007" ] . ToString ( );
                            _modelTre . AO008 = table . Rows [ i ] [ "AO008" ] . ToString ( );
                            if ( !string . IsNullOrEmpty ( table . Rows [ i ] [ "AO009" ] . ToString ( ) ) )
                                _modelTre . AO009 = Convert . ToDateTime ( table . Rows [ i ] [ "AO009" ] . ToString ( ) );
                            if ( !string . IsNullOrEmpty ( table . Rows [ i ] [ "AO010" ] . ToString ( ) ) )
                                _modelTre . AO010 = Convert . ToDateTime ( table . Rows [ i ] [ "AO010" ] . ToString ( ) );
                            _modelTre . AO011 = string . IsNullOrEmpty ( table . Rows [ i ] [ "AO011" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "AO011" ] . ToString ( ) );
                            _modelTre . AO012 = string . IsNullOrEmpty ( table . Rows [ i ] [ "AO012" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "AO012" ] . ToString ( ) );
                            _modelTre . AO013 = string . IsNullOrEmpty ( table . Rows [ i ] [ "AO013" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "AO013" ] . ToString ( ) );
                            _modelTre . AO014 = string . IsNullOrEmpty ( table . Rows [ i ] [ "AO014" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "AO014" ] . ToString ( ) );
                            _modelTre . AO015 = string . IsNullOrEmpty ( table . Rows [ i ] [ "AO015" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "AO015" ] . ToString ( ) );
                            _modelTre . AO018 = string . IsNullOrEmpty ( table . Rows [ i ] [ "AO018" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "AO018" ] . ToString ( ) );
                            _modelTre . AO019 = table . Rows [ i ] [ "AO019" ] . ToString ( );
                            _modelTre . AO020 = string . IsNullOrEmpty ( table . Rows [ i ] [ "AO020" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "AO020" ] . ToString ( ) );
                            _modelTre . AO022 = table . Rows [ i ] [ "AO022" ] . ToString ( );

                            if ( choise . Select ( "AO021='" + _modelTre . AO021 + "'" ) . Length > 0 )
                                UpdateFor ( cmd ,_modelTre ,strSql ,tran ,conn );
                            else
                                AddFor ( cmd ,_modelTre ,strSql ,tran ,conn );

                            if ( !string . IsNullOrEmpty ( _modelTre . AO022 ) )
                                UpdatePQWZ ( cmd ,_modelTre ,strSql ,tran ,conn );
                        }

                        for ( int k = 0 ; k < choise . Rows . Count ; k++ )
                        {
                            _modelTre . AO021 = choise . Rows [ k ] [ "AO021" ] . ToString ( );
                            _modelTre . AO022 = choise . Rows [ k ] [ "AO022" ] . ToString ( );
                            if ( table . Select ( "AO021='" + _modelTre . AO021 + "'" ) . Length < 1 )
                                DeleteFor ( cmd ,_modelTre ,strSql ,tran ,conn );
                        }

                    }

                    tran . Commit ( );
                    return true;
                }
                catch (Exception ex)
                {
                    AutoUpdate . LogHelper . WriteLog ( ex . Message );
                    tran . Rollback ( );
                    return false;
                }
                finally
                {
                    cmd . Dispose ( );
                    conn . Close ( );
                }
            }
        }

        void UpdateFor ( SqlCommand cmd ,MulaolaoLibrary.PayMentTreLibrary _modelTre ,StringBuilder strSql ,SqlTransaction tran ,SqlConnection conn )
        {
            strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAO SET " );
            strSql.Append( " AO002=@AO002," );
            strSql.Append( " AO003=@AO003," );
            strSql.Append( " AO004=@AO004," );
            strSql.Append( " AO005=@AO005," );
            strSql.Append( " AO006=@AO006," );
            strSql.Append( " AO007=@AO007," );
            strSql.Append( " AO008=@AO008," );
            strSql.Append( " AO011=@AO011," );
            strSql.Append( " AO012=@AO012," );
            strSql.Append( " AO013=@AO013," );
            strSql.Append( " AO014=@AO014," );
            strSql.Append( " AO015=@AO015," );
            strSql.Append( " AO018=@AO018," );
            strSql.Append( " AO019=@AO019," );
            strSql.Append( " AO020=@AO020," );
            strSql . Append ( "AO022=@AO022 " );
            strSql .Append( " WHERE AO001=@AO001 AND AO021=@AO021" );
            SqlParameter[] parameter = {
                new SqlParameter("@AO001",SqlDbType.NVarChar,20),
                new SqlParameter("@AO002",SqlDbType.NVarChar,20),
                new SqlParameter("@AO003",SqlDbType.NVarChar,20),
                new SqlParameter("@AO004",SqlDbType.NVarChar,20),
                new SqlParameter("@AO005",SqlDbType.NVarChar,20),
                new SqlParameter("@AO006",SqlDbType.NVarChar,20),
                new SqlParameter("@AO007",SqlDbType.NVarChar,20),
                new SqlParameter("@AO008",SqlDbType.NVarChar,250),
                new SqlParameter("@AO011",SqlDbType.Decimal,11),
                new SqlParameter("@AO012",SqlDbType.Decimal,11),
                new SqlParameter("@AO013",SqlDbType.Decimal,11),
                new SqlParameter("@AO014",SqlDbType.Decimal,11),
                new SqlParameter("@AO015",SqlDbType.Decimal,6),
                new SqlParameter("@AO018",SqlDbType.Decimal,11),
                new SqlParameter("@AO019",SqlDbType.NVarChar,20),
                new SqlParameter("@AO020",SqlDbType.Decimal,11),
                new SqlParameter("@AO021",SqlDbType.NVarChar,20),
                new SqlParameter("@AO022",SqlDbType.NVarChar,255)
            };
            parameter[0].Value = _modelTre.AO001;
            parameter[1].Value = _modelTre.AO002;
            parameter[2].Value = _modelTre.AO003;
            parameter[3].Value = _modelTre.AO004;
            parameter[4].Value = _modelTre.AO005;
            parameter[5].Value = _modelTre.AO006;
            parameter[6].Value = _modelTre.AO007;
            parameter[7].Value = _modelTre.AO008;
            parameter[8].Value = _modelTre.AO011;
            parameter[9].Value = _modelTre.AO012;
            parameter[10].Value = _modelTre.AO013;
            parameter[11].Value = _modelTre.AO014;
            parameter[12].Value = _modelTre.AO015;
            parameter[13].Value = _modelTre.AO018;
            parameter[14].Value = _modelTre.AO019;
            parameter[15].Value = _modelTre.AO020;
            parameter[16].Value = _modelTre.AO021;
            parameter [ 17 ] . Value = _modelTre . AO022;

            cmd .Parameters.Clear( );
            SqlHelper.PrepareCommand( cmd ,conn ,tran ,strSql.ToString( ) ,parameter );
            cmd.CommandText = strSql.ToString( );
            cmd.ExecuteNonQuery( );

            strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAO SET " );
            if ( _modelTre.AO009 == null )
                strSql.Append( " AO009=NULL," );
            else
                strSql.AppendFormat( " AO009='{0}'," ,_modelTre.AO009 );
            if ( _modelTre.AO010 == null )
                strSql.Append( " AO010=NULL" );
            else
                strSql.AppendFormat( " AO010='{0}'" ,_modelTre.AO010 );
            strSql.Append( " WHERE AO001=@AO001 AND AO021=@AO021" );
            SqlParameter[] paramete = {
                new SqlParameter("@AO001",SqlDbType.NVarChar,20),
                new SqlParameter("@AO021",SqlDbType.NVarChar,20)
            };
            paramete[0].Value = _modelTre.AO001;
            paramete[1].Value = _modelTre.AO021;

            cmd.Parameters.Clear( );
            SqlHelper.PrepareCommand( cmd ,conn ,tran ,strSql.ToString( ) ,paramete );
            cmd.CommandText = strSql.ToString( );
            cmd.ExecuteNonQuery( );
        }
        void AddFor ( SqlCommand cmd ,MulaolaoLibrary.PayMentTreLibrary _modelTre ,StringBuilder strSql ,SqlTransaction tran ,SqlConnection conn )
        {
            strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAO (" );
            strSql.Append( "AO001,AO002,AO003,AO004,AO005,AO006,AO007,AO008,AO011,AO012,AO013,AO014,AO015,AO018,AO019,AO020,AO021,AO022)" );
            strSql.Append( " VALUES (" );
            strSql.Append( "@AO001,@AO002,@AO003,@AO004,@AO005,@AO006,@AO007,@AO008,@AO011,@AO012,@AO013,@AO014,@AO015,@AO018,@AO019,@AO020,@AO021,@AO022)" );
            SqlParameter[] parameter = {
                new SqlParameter("@AO001",SqlDbType.NVarChar,20),
                new SqlParameter("@AO002",SqlDbType.NVarChar,20),
                new SqlParameter("@AO003",SqlDbType.NVarChar,20),
                new SqlParameter("@AO004",SqlDbType.NVarChar,20),
                new SqlParameter("@AO005",SqlDbType.NVarChar,20),
                new SqlParameter("@AO006",SqlDbType.NVarChar,20),
                new SqlParameter("@AO007",SqlDbType.NVarChar,20),
                new SqlParameter("@AO008",SqlDbType.NVarChar,250),
                new SqlParameter("@AO011",SqlDbType.Decimal,11),
                new SqlParameter("@AO012",SqlDbType.Decimal,11),
                new SqlParameter("@AO013",SqlDbType.Decimal,11),
                new SqlParameter("@AO014",SqlDbType.Decimal,11),
                new SqlParameter("@AO015",SqlDbType.Decimal,6),
                new SqlParameter("@AO018",SqlDbType.Decimal,11),
                new SqlParameter("@AO019",SqlDbType.NVarChar,20),
                new SqlParameter("@AO020",SqlDbType.Decimal,11),
                new SqlParameter("@AO021",SqlDbType.NVarChar,20),
                new SqlParameter("@AO022",SqlDbType.NVarChar,255)
            };
            parameter[0].Value = _modelTre.AO001;
            parameter[1].Value = _modelTre.AO002;
            parameter[2].Value = _modelTre.AO003;
            parameter[3].Value = _modelTre.AO004;
            parameter[4].Value = _modelTre.AO005;
            parameter[5].Value = _modelTre.AO006;
            parameter[6].Value = _modelTre.AO007;
            parameter[7].Value = _modelTre.AO008;
            parameter[8].Value = _modelTre.AO011;
            parameter[9].Value = _modelTre.AO012;
            parameter[10].Value = _modelTre.AO013;
            parameter[11].Value = _modelTre.AO014;
            parameter[12].Value = _modelTre.AO015;
            parameter[13].Value = _modelTre.AO018;
            parameter[14].Value = _modelTre.AO019;
            parameter[15].Value = _modelTre.AO020;
            parameter[16].Value = _modelTre.AO021;
            parameter [ 17 ] . Value = _modelTre . AO022;

            cmd .Parameters.Clear( );
            SqlHelper.PrepareCommand( cmd ,conn ,tran ,strSql.ToString( ) ,parameter );
            cmd.CommandText = strSql.ToString( );
            cmd.ExecuteNonQuery( );

            strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAO SET " );
            if ( _modelTre.AO009 == null || _modelTre.AO009 <= DateTime.MinValue || _modelTre.AO009 >= DateTime.MaxValue )
                strSql.Append( " AO009=NULL," );
            else
                strSql.AppendFormat( " AO009='{0}'," ,_modelTre.AO009 );
            if ( _modelTre.AO010 == null || _modelTre.AO010 <= DateTime.MinValue || _modelTre.AO010 >= DateTime.MaxValue )
                strSql.Append( " AO010=NULL" );
            else
                strSql.AppendFormat( " AO010='{0}'" ,_modelTre.AO010 );
            strSql.Append( " WHERE AO001=@AO001 AND AO021=@AO021" );
            SqlParameter[] paramete = {
                new SqlParameter("@AO001",SqlDbType.NVarChar,20),
                new SqlParameter("@AO021",SqlDbType.NVarChar,20)
            };
            paramete[0].Value = _modelTre.AO001;
            paramete[1].Value = _modelTre.AO021;

            cmd.Parameters.Clear( );
            SqlHelper.PrepareCommand( cmd ,conn ,tran ,strSql.ToString( ) ,paramete );
            cmd.CommandText = strSql.ToString( );
            cmd.ExecuteNonQuery( );
        }
        void DeleteFor ( SqlCommand cmd ,MulaolaoLibrary.PayMentTreLibrary _modelTre ,StringBuilder strSql ,SqlTransaction tran ,SqlConnection conn )
        {
            strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQAO " );
            strSql.Append( "WHERE AO001=@AO001 AND AO021=@AO021" );
            SqlParameter[] parameter = {
                new SqlParameter("@AO001",SqlDbType.NVarChar,20),
                new SqlParameter("@AO021",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = _modelTre.AO001;
            parameter[1].Value = _modelTre.AO021;

            cmd.Parameters.Clear( );
            SqlHelper.PrepareCommand( cmd ,conn ,tran ,strSql.ToString( ) ,parameter );
            cmd.CommandText = strSql.ToString( );
            cmd.ExecuteNonQuery( );

            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE R_PQWZ SET WZ016='',WZ017=NULL WHERE idx IN ({0})" ,_modelTre . AO022 );
            cmd . Parameters . Clear ( );
            SqlHelper . PrepareCommand ( cmd ,conn ,tran ,strSql . ToString ( ) ,parameter );
            cmd . CommandText = strSql . ToString ( );
            cmd . ExecuteNonQuery ( );
        }
        void UpdatePQWZ ( SqlCommand cmd ,MulaolaoLibrary . PayMentTreLibrary _modelTre ,StringBuilder strSql ,SqlTransaction tran ,SqlConnection conn )
        {
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE R_PQWZ SET WZ016=@WZ016,WZ017=@WZ017 WHERE idx IN ({0})" ,_modelTre . AO022 );
            SqlParameter [ ] parameter = {
                new SqlParameter("@WZ016",SqlDbType.NVarChar,20),
                new SqlParameter("@WZ017",SqlDbType.Date),
            };
            parameter [ 0 ] . Value = _modelTre . AO003;
            parameter [ 1 ] . Value = _modelTre . AO009;

            cmd . Parameters . Clear ( );
            SqlHelper . PrepareCommand ( cmd ,conn ,tran ,strSql . ToString ( ) ,parameter );
            cmd . CommandText = strSql . ToString ( );
            cmd . ExecuteNonQuery ( );
        }

        public bool AddFiv ( DataTable table )
        {
            using ( SqlConnection conn = new SqlConnection ( SqlHelper . connstr ) )
            {
                conn . Open ( );
                SqlCommand cmd = new SqlCommand ( );
                cmd . Connection = conn;
                SqlTransaction tran = conn . BeginTransaction ( );
                cmd . Transaction = tran;
                try
                {
                    MulaolaoLibrary . PayMentForLibrary _modelFor = new MulaolaoLibrary . PayMentForLibrary ( );
                    StringBuilder strSql = new StringBuilder ( );
                    if ( table != null && table . Rows . Count > 0 )
                    {
                        _modelFor . AR001 = table . Rows [ 0 ] [ "AR001" ] . ToString ( );
                        DataTable choise = SqlHelper . ExecuteDataTable ( "SELECT * FROM R_PQAR WHERE AR001='" + _modelFor . AR001 + "'" );
                        for ( int i = 0 ; i < table . Rows . Count ; i++ )
                        {
                            _modelFor = new MulaolaoLibrary . PayMentForLibrary ( );
                            _modelFor . AR001 = table . Rows [ 0 ] [ "AR001" ] . ToString ( );
                            _modelFor . AR021 = table . Rows [ i ] [ "AR021" ] . ToString ( );
                            _modelFor . AR002 = table . Rows [ i ] [ "AR002" ] . ToString ( );
                            _modelFor . AR003 = table . Rows [ i ] [ "AR003" ] . ToString ( );
                            _modelFor . AR004 = table . Rows [ i ] [ "AR004" ] . ToString ( );
                            _modelFor . AR005 = table . Rows [ i ] [ "AR005" ] . ToString ( );
                            _modelFor . AR006 = table . Rows [ i ] [ "AR006" ] . ToString ( );
                            _modelFor . AR007 = table . Rows [ i ] [ "AR007" ] . ToString ( );
                            _modelFor . AR008 = table . Rows [ i ] [ "AR008" ] . ToString ( );
                            if ( !string . IsNullOrEmpty ( table . Rows [ i ] [ "AR009" ] . ToString ( ) ) )
                                _modelFor . AR009 = Convert . ToDateTime ( table . Rows [ i ] [ "AR009" ] . ToString ( ) );
                            if ( !string . IsNullOrEmpty ( table . Rows [ i ] [ "AR010" ] . ToString ( ) ) )
                                _modelFor . AR010 = Convert . ToDateTime ( table . Rows [ i ] [ "AR010" ] . ToString ( ) );
                            _modelFor . AR011 = string . IsNullOrEmpty ( table . Rows [ i ] [ "AR011" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "AR011" ] . ToString ( ) );
                            _modelFor . AR012 = string . IsNullOrEmpty ( table . Rows [ i ] [ "AR012" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "AR012" ] . ToString ( ) );
                            _modelFor . AR013 = string . IsNullOrEmpty ( table . Rows [ i ] [ "AR013" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "AR013" ] . ToString ( ) );
                            _modelFor . AR014 = string . IsNullOrEmpty ( table . Rows [ i ] [ "AR014" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "AR014" ] . ToString ( ) );
                            _modelFor . AR015 = string . IsNullOrEmpty ( table . Rows [ i ] [ "AR015" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "AR015" ] . ToString ( ) );
                            _modelFor . AR018 = string . IsNullOrEmpty ( table . Rows [ i ] [ "AR018" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "AR018" ] . ToString ( ) );
                            _modelFor . AR019 = table . Rows [ i ] [ "AR019" ] . ToString ( );
                            _modelFor . AR020 = string . IsNullOrEmpty ( table . Rows [ i ] [ "AR020" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "AR020" ] . ToString ( ) );
                            _modelFor . AR022 = table . Rows [ i ] [ "AR022" ] . ToString ( );

                            if ( choise . Select ( "AR021='" + _modelFor . AR021 + "'" ) . Length > 0 )
                                UpdateFiv ( cmd ,_modelFor ,strSql ,tran ,conn );
                            else
                                AddFiv ( cmd ,_modelFor ,strSql ,tran ,conn );

                            if ( !string . IsNullOrEmpty ( _modelFor . AR022 ) )
                                UpdatePQWZ ( cmd ,_modelFor ,strSql ,tran ,conn );

                        }

                        for ( int k = 0 ; k < choise . Rows . Count ; k++ )
                        {
                            _modelFor . AR021 = choise . Rows [ k ] [ "AR021" ] . ToString ( );
                            _modelFor . AR022 = choise . Rows [ k ] [ "AR022" ] . ToString ( );
                            if ( table . Select ( "AR021='" + _modelFor . AR021 + "'" ) . Length < 1 )
                                DeleteFiv ( cmd ,_modelFor ,strSql ,tran ,conn );
                        }

                    }

                    tran . Commit ( );
                    return true;
                }
                catch (Exception ex)
                {
                    AutoUpdate . LogHelper . WriteLog ( ex . Message );
                    tran . Rollback ( );
                    return false;
                }
                finally
                {
                    cmd . Dispose ( );
                    conn . Close ( );
                }
            }
        }

        void UpdateFiv ( SqlCommand cmd ,MulaolaoLibrary.PayMentForLibrary _modelFor ,StringBuilder strSql ,SqlTransaction tran ,SqlConnection conn )
        {
            strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAR SET " );
            strSql.Append( " AR002=@AR002," );
            strSql.Append( " AR003=@AR003," );
            strSql.Append( " AR004=@AR004," );
            strSql.Append( " AR005=@AR005," );
            strSql.Append( " AR006=@AR006," );
            strSql.Append( " AR007=@AR007," );
            strSql.Append( " AR008=@AR008," );
            //strSql.Append( " AR009=@AR009," );
            //strSql.Append( " AR010=@AR010," );
            strSql.Append( " AR011=@AR011," );
            strSql.Append( " AR012=@AR012," );
            strSql.Append( " AR013=@AR013," );
            strSql.Append( " AR014=@AR014," );
            strSql.Append( " AR015=@AR015," );
            strSql.Append( " AR018=@AR018," );
            strSql.Append( " AR019=@AR019," );
            strSql.Append( " AR020=@AR020," );
            strSql . Append ( "AR022=@AR022 " );
            strSql .Append( " WHERE AR001=@AR001 AND AR021=@AR021" );
            SqlParameter[] parameter = {
                new SqlParameter("@AR001",SqlDbType.NVarChar,20),
                new SqlParameter("@AR002",SqlDbType.NVarChar,20),
                new SqlParameter("@AR003",SqlDbType.NVarChar,20),
                new SqlParameter("@AR004",SqlDbType.NVarChar,20),
                new SqlParameter("@AR005",SqlDbType.NVarChar,20),
                new SqlParameter("@AR006",SqlDbType.NVarChar,20),
                new SqlParameter("@AR007",SqlDbType.NVarChar,20),
                new SqlParameter("@AR008",SqlDbType.NVarChar,250),
                //new SqlParameter("@AR009",SqlDbType.Date),
                //new SqlParameter("@AR010",SqlDbType.Date),
                new SqlParameter("@AR011",SqlDbType.Decimal,11),
                new SqlParameter("@AR012",SqlDbType.Decimal,11),
                new SqlParameter("@AR013",SqlDbType.Decimal,11),
                new SqlParameter("@AR014",SqlDbType.Decimal,11),
                new SqlParameter("@AR015",SqlDbType.Decimal,6),
                new SqlParameter("@AR018",SqlDbType.Decimal,11),
                new SqlParameter("@AR019",SqlDbType.NVarChar,20),
                new SqlParameter("@AR020",SqlDbType.Decimal,11),
                new SqlParameter("@AR021",SqlDbType.NVarChar,20),
                new SqlParameter("@AR022",SqlDbType.NVarChar,255)
            };
            parameter[0].Value = _modelFor.AR001;
            parameter[1].Value = _modelFor.AR002;
            parameter[2].Value = _modelFor.AR003;
            parameter[3].Value = _modelFor.AR004;
            parameter[4].Value = _modelFor.AR005;
            parameter[5].Value = _modelFor.AR006;
            parameter[6].Value = _modelFor.AR007;
            parameter[7].Value = _modelFor.AR008;
            //parameter[8].Value = _modelFor.AR009;
            //parameter[9].Value = _modelFor.AR010;
            parameter[8].Value = _modelFor.AR011;
            parameter[9].Value = _modelFor.AR012;
            parameter[10].Value = _modelFor.AR013;
            parameter[11].Value = _modelFor.AR014;
            parameter[12].Value = _modelFor.AR015;
            parameter[13].Value = _modelFor.AR018;
            parameter[14].Value = _modelFor.AR019;
            parameter[15].Value = _modelFor.AR020;
            parameter[16].Value = _modelFor.AR021;
            parameter [ 17 ] . Value = _modelFor . AR022;

            cmd .Parameters.Clear( );
            SqlHelper.PrepareCommand( cmd ,conn ,tran ,strSql.ToString( ) ,parameter );
            cmd.CommandText = strSql.ToString( );
            cmd.ExecuteNonQuery( );

            strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAR SET " );
            if ( _modelFor.AR009 == null )
                strSql.Append( " AR009=NULL," );
            else
                strSql.AppendFormat( " AR009='{0}'," ,_modelFor.AR009 );
            if ( _modelFor.AR010 == null )
                strSql.Append( " AR010=NULL" );
            else
                strSql.AppendFormat( " AR010='{0}'" ,_modelFor.AR010 );
            strSql.Append( " WHERE AR001=@AR001 AND AR021=@AR021" );
            SqlParameter[] paramete = {
                 new SqlParameter("@AR001",SqlDbType.NVarChar,20),
                 new SqlParameter("@AR021",SqlDbType.NVarChar,20)
            };
            paramete[0].Value = _modelFor.AR001;
            paramete[1].Value = _modelFor.AR021;

            cmd.Parameters.Clear( );
            SqlHelper.PrepareCommand( cmd ,conn ,tran ,strSql.ToString( ) ,paramete );
            cmd.CommandText = strSql.ToString( );
            cmd.ExecuteNonQuery( );

        }
        void AddFiv ( SqlCommand cmd ,MulaolaoLibrary.PayMentForLibrary _modelFor ,StringBuilder strSql ,SqlTransaction tran ,SqlConnection conn )
        {
            strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAR (" );
            strSql.Append( "AR001,AR002,AR003,AR004,AR005,AR006,AR007,AR008,AR011,AR012,AR013,AR014,AR015,AR018,AR019,AR020,AR021,AR022)" );
            strSql.Append( " VALUES (" );
            strSql.Append( "@AR001,@AR002,@AR003,@AR004,@AR005,@AR006,@AR007,@AR008,@AR011,@AR012,@AR013,@AR014,@AR015,@AR018,@AR019,@AR020,@AR021,@AR022)" );
            SqlParameter[] parameter = {
                new SqlParameter("@AR001",SqlDbType.NVarChar,20),
                new SqlParameter("@AR002",SqlDbType.NVarChar,20),
                new SqlParameter("@AR003",SqlDbType.NVarChar,20),
                new SqlParameter("@AR004",SqlDbType.NVarChar,20),
                new SqlParameter("@AR005",SqlDbType.NVarChar,20),
                new SqlParameter("@AR006",SqlDbType.NVarChar,20),
                new SqlParameter("@AR007",SqlDbType.NVarChar,20),
                new SqlParameter("@AR008",SqlDbType.NVarChar,250),
                new SqlParameter("@AR011",SqlDbType.Decimal,11),
                new SqlParameter("@AR012",SqlDbType.Decimal,11),
                new SqlParameter("@AR013",SqlDbType.Decimal,11),
                new SqlParameter("@AR014",SqlDbType.Decimal,11),
                new SqlParameter("@AR015",SqlDbType.Decimal,6),
                new SqlParameter("@AR018",SqlDbType.Decimal,11),
                new SqlParameter("@AR019",SqlDbType.NVarChar,20),
                new SqlParameter("@AR020",SqlDbType.Decimal,11),
                new SqlParameter("@AR021",SqlDbType.NVarChar,20),
                new SqlParameter("@AR022",SqlDbType.NVarChar,255)
            };
            parameter[0].Value = _modelFor.AR001;
            parameter[1].Value = _modelFor.AR002;
            parameter[2].Value = _modelFor.AR003;
            parameter[3].Value = _modelFor.AR004;
            parameter[4].Value = _modelFor.AR005;
            parameter[5].Value = _modelFor.AR006;
            parameter[6].Value = _modelFor.AR007;
            parameter[7].Value = _modelFor.AR008;
            parameter[8].Value = _modelFor.AR011;
            parameter[9].Value = _modelFor.AR012;
            parameter[10].Value = _modelFor.AR013;
            parameter[11].Value = _modelFor.AR014;
            parameter[12].Value = _modelFor.AR015;
            parameter[13].Value = _modelFor.AR018;
            parameter[14].Value = _modelFor.AR019;
            parameter[15].Value = _modelFor.AR020;
            parameter[16].Value = _modelFor.AR021;
            parameter [ 17 ] . Value = _modelFor . AR022;

            cmd .Parameters.Clear( );
            SqlHelper.PrepareCommand( cmd ,conn ,tran ,strSql.ToString( ) ,parameter );
            cmd.CommandText = strSql.ToString( );
            cmd.ExecuteNonQuery( );


            strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAR SET " );
            if ( _modelFor.AR009 == null || _modelFor.AR009 <= DateTime.MinValue || _modelFor.AR009 >= DateTime.MaxValue )
                strSql.Append( " AR009=NULL," );
            else
                strSql.AppendFormat( " AR009='{0}'," ,_modelFor.AR009 );
            if ( _modelFor.AR010 == null || _modelFor.AR010 <= DateTime.MinValue || _modelFor.AR010 >= DateTime.MaxValue )
                strSql.Append( " AR010=NULL" );
            else
                strSql.AppendFormat( " AR010='{0}'" ,_modelFor.AR010 );
            strSql.Append( " WHERE AR001=@AR001 AND AR021=@AR021" );
            SqlParameter[] paramete = {
                 new SqlParameter("@AR001",SqlDbType.NVarChar,20),
                 new SqlParameter("@AR021",SqlDbType.NVarChar,20)
            };
            paramete[0].Value = _modelFor.AR001;
            paramete[1].Value = _modelFor.AR021;

            cmd.Parameters.Clear( );
            SqlHelper.PrepareCommand( cmd ,conn ,tran ,strSql.ToString( ) ,paramete );
            cmd.CommandText = strSql.ToString( );
            cmd.ExecuteNonQuery( );
        }
        void DeleteFiv ( SqlCommand cmd ,MulaolaoLibrary.PayMentForLibrary _modelFor ,StringBuilder strSql ,SqlTransaction tran ,SqlConnection conn )
        {
            strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQAR " );
            strSql.Append( "WHERE AR001=@AR001 AND AR021=@AR021" );
            SqlParameter[] parameter = {
                new SqlParameter("@AR001",SqlDbType.NVarChar,20),
                new SqlParameter("@AR021",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = _modelFor.AR001;
            parameter[1].Value = _modelFor.AR021;

            cmd.Parameters.Clear( );
            SqlHelper.PrepareCommand( cmd ,conn ,tran ,strSql.ToString( ) ,parameter );
            cmd.CommandText = strSql.ToString( );
            cmd.ExecuteNonQuery( );

            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE R_PQWZ SET WZ016='',WZ017=NULL WHERE idx IN ({0})" ,_modelFor . AR022 );
            cmd . Parameters . Clear ( );
            SqlHelper . PrepareCommand ( cmd ,conn ,tran ,strSql . ToString ( ) ,parameter );
            cmd . CommandText = strSql . ToString ( );
            cmd . ExecuteNonQuery ( );
        }
        void UpdatePQWZ ( SqlCommand cmd ,MulaolaoLibrary . PayMentForLibrary _modelFor ,StringBuilder strSql ,SqlTransaction tran ,SqlConnection conn )
        {
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE R_PQWZ SET WZ016=@WZ016,WZ017=@WZ017 WHERE idx IN ({0})" ,_modelFor . AR022 );
            SqlParameter [ ] parameter = {
                new SqlParameter("@WZ016",SqlDbType.NVarChar,20),
                new SqlParameter("@WZ017",SqlDbType.Date),
            };
            parameter [ 0 ] . Value = _modelFor . AR003;
            parameter [ 1 ] . Value = _modelFor . AR009;

            cmd . Parameters . Clear ( );
            SqlHelper . PrepareCommand ( cmd ,conn ,tran ,strSql . ToString ( ) ,parameter );
            cmd . CommandText = strSql . ToString ( );
            cmd . ExecuteNonQuery ( );
        }


        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "SELECT YZ022,YZ023,YZ024,YZ025,YZ027,YZ030 FROM R_PQYZ WHERE YZ001='{0}' AND YZ003='执行'" ,oddNum );

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            if ( da != null && da.Rows.Count > 0 )
            {
                string one = "", two = "", tre = "", fore = "",fiv="",six = "";
                for ( int i = 0 ; i < da.Rows.Count ; i++ )
                {
                    if ( !string.IsNullOrEmpty( da.Rows[i]["YZ022"].ToString( ) ) )
                    {
                        if ( one == "" )
                            one = da.Rows[i]["YZ022"].ToString( );
                        else
                            one = one + "," + da.Rows[i]["YZ022"].ToString( );
                    }
                    if ( !string.IsNullOrEmpty( da.Rows[i]["YZ023"].ToString( ) ) )
                    {
                        if ( two == "" )
                            two = da.Rows[i]["YZ023"].ToString( );
                        else
                            two = two + "," + da.Rows[i]["YZ023"].ToString( );
                    }
                    if ( !string.IsNullOrEmpty( da.Rows[i]["YZ024"].ToString( ) ) )
                    {
                        if ( tre == "" )
                            tre = da.Rows[i]["YZ024"].ToString( );
                        else
                            tre = tre + "," + da.Rows[i]["YZ024"].ToString( );
                    }
                    if ( !string.IsNullOrEmpty( da.Rows[i]["YZ025"].ToString( ) ) )
                    {
                        if ( fore == "" )
                            fore = da.Rows[i]["YZ025"].ToString( );
                        else
                            fore = fore + "," + da.Rows[i]["YZ025"].ToString( );
                    }
                    if ( !string.IsNullOrEmpty( da.Rows[i]["YZ027"].ToString( ) ) )
                    {
                        if ( fiv == "" )
                            fiv = da.Rows[i]["YZ027"].ToString( );
                        else
                            fiv = fiv + "," + da.Rows[i]["YZ027"].ToString( );
                    }
                    if ( !string.IsNullOrEmpty( da.Rows[i]["YZ030"].ToString( ) ) )
                    {
                        if ( six == "" )
                            six = da.Rows[i]["YZ030"].ToString( );
                        else
                            six = six + "," + da.Rows[i]["YZ030"].ToString( );
                    }
                }
                if ( one != "" )
                {
                    StringBuilder strOne = new StringBuilder( );
                    strOne.AppendFormat( "UPDATE R_PQAK SET AK016=NULL,AK017='' WHERE idx IN (" + one + ")" );
                    SQLString.Add( strOne.ToString( ) );
                }
                if ( two != "" )
                {
                    StringBuilder sqlTwo = new StringBuilder( );
                    sqlTwo.AppendFormat( "UPDATE R_PQWZ SET WZ016='',WZ017=NULL WHERE idx IN (" + two + ")" );
                    SQLString.Add( sqlTwo.ToString( ) );
                }
                if ( tre != "" )
                {
                    StringBuilder sqlTre = new StringBuilder( );
                    sqlTre.AppendFormat( "UPDATE R_PQXZ SET XZ022=NULL,XZ025='' WHERE idx IN (" + tre + ")" );
                    SQLString.Add( sqlTre.ToString( ) );
                }
                if ( fore != "" )
                {
                    StringBuilder sqlFore = new StringBuilder( );
                    sqlFore.AppendFormat( "UPDATE R_PQXZ SET XZ022=NULL,XZ025='' WHERE idx IN (" + fore + ")" );
                    SQLString.Add( sqlFore.ToString( ) );
                }
                if ( fiv != "" )
                {
                    StringBuilder sqlFore = new StringBuilder( );
                    sqlFore.Append( "UPDATE R_PQEZ SET " );
                    sqlFore.Append( "EZ016=NULL," );
                    sqlFore.Append( "EZ015=''" );
                    sqlFore.Append( " WHERE idx IN (" + fiv + ")" );
                    SQLString.Add( sqlFore.ToString( ) );
                }
                if ( six != "" )
                {
                    StringBuilder sqlFore = new StringBuilder( );
                    sqlFore.Append( "UPDATE R_PQBE SET " );
                    sqlFore.Append( "BE014=NULL," );
                    sqlFore.Append( "BE013=''" );
                    sqlFore.Append( " WHERE idx IN (" + six + ")" );
                    SQLString.Add( sqlFore.ToString( ) );
                }
            }
            StringBuilder strS = new StringBuilder( );
            strS.AppendFormat( "DELETE FROM R_PQYZ WHERE YZ001='{0}'" ,oddNum );
            SQLString.Add( strS.ToString( ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        public bool Deletes ( string idxList )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT YZ022,YZ023,YZ024,YZ025,YZ027,YZ030 FROM R_PQYZ WHERE idx IN (" + idxList + ") AND YZ003='执行'" );

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            if ( da != null && da.Rows.Count > 0 )
            {
                string one = "", two = "", tre = "", fore = "", fiv = "", six = "";
                for ( int i = 0 ; i < da.Rows.Count ; i++ )
                {
                    if ( !string.IsNullOrEmpty( da.Rows[i]["YZ022"].ToString( ) ) )
                    {
                        if ( one == "" )
                            one = da.Rows[i]["YZ022"].ToString( );
                        else
                            one = one + "," + da.Rows[i]["YZ022"].ToString( );
                    }
                    if ( !string.IsNullOrEmpty( da.Rows[i]["YZ023"].ToString( ) ) )
                    {
                        if ( two == "" )
                            two = da.Rows[i]["YZ023"].ToString( );
                        else
                            two = two + "," + da.Rows[i]["YZ023"].ToString( );
                    }
                    if ( !string.IsNullOrEmpty( da.Rows[i]["YZ024"].ToString( ) ) )
                    {
                        if ( tre == "" )
                            tre = da.Rows[i]["YZ024"].ToString( );
                        else
                            tre = tre + "," + da.Rows[i]["YZ024"].ToString( );
                    }
                    if ( !string.IsNullOrEmpty( da.Rows[i]["YZ025"].ToString( ) ) )
                    {
                        if ( fore == "" )
                            fore = da.Rows[i]["YZ025"].ToString( );
                        else
                            fore = fore + "," + da.Rows[i]["YZ025"].ToString( );
                    }
                    if ( !string.IsNullOrEmpty( da.Rows[i]["YZ027"].ToString( ) ) )
                    {
                        if ( fiv == "" )
                            fiv = da.Rows[i]["YZ027"].ToString( );
                        else
                            fiv = fiv + "," + da.Rows[i]["YZ027"].ToString( );
                    }
                    if ( !string.IsNullOrEmpty( da.Rows[i]["YZ030"].ToString( ) ) )
                    {
                        if ( six == "" )
                            six = da.Rows[i]["YZ030"].ToString( );
                        else
                            six = six + "," + da.Rows[i]["YZ030"].ToString( );
                    }
                }
                if ( one != "" )
                {
                    StringBuilder strOne = new StringBuilder( );
                    strOne.AppendFormat( "UPDATE R_PQAK SET AK016=NULL,AK017='' WHERE idx IN (" + one + ")" );
                    SQLString.Add( strOne.ToString( ) );
                }
                if ( two != "" )
                {
                    StringBuilder sqlTwo = new StringBuilder( );
                    sqlTwo.AppendFormat( "UPDATE R_PQWZ SET WZ016='',WZ017=NULL WHERE idx IN (" + two + ")" );
                    SQLString.Add( sqlTwo.ToString( ) );
                }
                if ( tre != "" )
                {
                    StringBuilder sqlTre = new StringBuilder( );
                    sqlTre.AppendFormat( "UPDATE R_PQXZ SET XZ022=NULL,XZ025='' WHERE idx IN (" + tre + ")" );
                    SQLString.Add( sqlTre.ToString( ) );
                }
                if ( fore != "" )
                {
                    StringBuilder sqlFore = new StringBuilder( );
                    sqlFore.AppendFormat( "UPDATE R_PQXZ SET XZ022=NULL,XZ025='' WHERE idx IN (" + fore + ")" );
                    SQLString.Add( sqlFore.ToString( ) );
                }
                if ( fiv != "" )
                {
                    StringBuilder sqlFore = new StringBuilder( );
                    sqlFore.Append( "UPDATE R_PQEZ SET " );
                    sqlFore.Append( "EZ016=NULL," );
                    sqlFore.Append( "EZ015=''" );
                    sqlFore.Append( " WHERE idx IN (" + fiv + ")" );
                    SQLString.Add( sqlFore.ToString( ) );
                }
                if ( six != "" )
                {
                    StringBuilder sqlFore = new StringBuilder( );
                    sqlFore.Append( "UPDATE R_PQBE SET " );
                    sqlFore.Append( "BE014=NULL," );
                    sqlFore.Append( "BE013=''" );
                    sqlFore.Append( " WHERE idx IN (" + six + ")" );
                    SQLString.Add( sqlFore.ToString( ) );
                }
            }
            StringBuilder strS = new StringBuilder( );
            strS.Append( "DELETE FROM R_PQYZ WHERE idx IN (" + idxList + ")" );
            SQLString.Add( strS.ToString( ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        public bool DeleteOne ( string oddNum )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "SELECT AP022,AP023,AP024,AP025,AP027,AP030 FROM R_PQAP WHERE AP001='{0}' AND AP003='执行'" ,oddNum );

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            if ( da != null && da.Rows.Count > 0 )
            {
                string one = "", two = "", tre = "", fore = "", fiv = "", six = "";
                for ( int i = 0 ; i < da.Rows.Count ; i++ )
                {
                    if ( !string.IsNullOrEmpty( da.Rows[i]["AP022"].ToString( ) ) )
                    {
                        if ( one == "" )
                            one = da.Rows[i]["AP022"].ToString( );
                        else
                            one = one + "," + da.Rows[i]["AP022"].ToString( );
                    }
                    if ( !string.IsNullOrEmpty( da.Rows[i]["AP023"].ToString( ) ) )
                    {
                        if ( two == "" )
                            two = da.Rows[i]["AP023"].ToString( );
                        else
                            two = two + "," + da.Rows[i]["AP023"].ToString( );
                    }
                    if ( !string.IsNullOrEmpty( da.Rows[i]["AP024"].ToString( ) ) )
                    {
                        if ( tre == "" )
                            tre = da.Rows[i]["AP024"].ToString( );
                        else
                            tre = tre + "," + da.Rows[i]["AP024"].ToString( );
                    }
                    if ( !string.IsNullOrEmpty( da.Rows[i]["AP025"].ToString( ) ) )
                    {
                        if ( fore == "" )
                            fore = da.Rows[i]["AP025"].ToString( );
                        else
                            fore = fore + "," + da.Rows[i]["AP025"].ToString( );
                    }
                    if ( !string.IsNullOrEmpty( da.Rows[i]["AP027"].ToString( ) ) )
                    {
                        if ( fiv == "" )
                            fiv = da.Rows[i]["AP027"].ToString( );
                        else
                            fiv = fiv + "," + da.Rows[i]["AP027"].ToString( );
                    }
                    if ( !string.IsNullOrEmpty( da.Rows[i]["AP030"].ToString( ) ) )
                    {
                        if ( six == "" )
                            six = da.Rows[i]["AP030"].ToString( );
                        else
                            six = six + "," + da.Rows[i]["AP030"].ToString( );
                    }
                }
                if ( one != "" )
                {
                    StringBuilder strOne = new StringBuilder( );
                    strOne.AppendFormat( "UPDATE R_PQAK SET AK016=NULL,AK017='' WHERE idx IN (" + one + ")" );
                    SQLString.Add( strOne.ToString( ) );
                }
                if ( two != "" )
                {
                    StringBuilder sqlTwo = new StringBuilder( );
                    sqlTwo.AppendFormat( "UPDATE R_PQWZ SET WZ016='',WZ017=NULL WHERE idx IN (" + two + ")" );
                    SQLString.Add( sqlTwo.ToString( ) );
                }
                if ( tre != "" )
                {
                    StringBuilder sqlTre = new StringBuilder( );
                    sqlTre.AppendFormat( "UPDATE R_PQXZ SET XZ022=NULL,XZ025='' WHERE idx IN (" + tre + ")" );
                    SQLString.Add( sqlTre.ToString( ) );
                }
                if ( fore != "" )
                {
                    StringBuilder sqlFore = new StringBuilder( );
                    sqlFore.AppendFormat( "UPDATE R_PQXZ SET XZ022=NULL,XZ025='' WHERE idx IN (" + fore + ")" );
                    SQLString.Add( sqlFore.ToString( ) );
                }
                if ( fiv != "" )
                {
                    StringBuilder sqlFore = new StringBuilder( );
                    sqlFore.Append( "UPDATE R_PQEZ SET " );
                    sqlFore.Append( "EZ016=NULL," );
                    sqlFore.Append( "EZ015=''" );
                    sqlFore.Append( " WHERE idx IN (" + fiv + ")" );
                    SQLString.Add( sqlFore.ToString( ) );
                }
                if ( six != "" )
                {
                    StringBuilder sqlFore = new StringBuilder( );
                    sqlFore.Append( "UPDATE R_PQBE SET " );
                    sqlFore.Append( "BE014=NULL," );
                    sqlFore.Append( "BE013=''" );
                    sqlFore.Append( " WHERE idx IN (" + six + ")" );
                    SQLString.Add( sqlFore.ToString( ) );
                }
            }
            StringBuilder strS = new StringBuilder( );
            strS.AppendFormat( "DELETE FROM R_PQAP WHERE AP001='{0}'" ,oddNum );
            SQLString.Add( strS.ToString( ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        public bool DeleteOnes ( string idxList )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AP022,AP023,AP024,AP025 FROM R_PQAP WHERE idx IN (" + idxList + ") AND AP003='执行'" );

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            if ( da != null && da.Rows.Count > 0 )
            {
                string one = "", two = "", tre = "", fore = "", fiv = "", six = "";
                for ( int i = 0 ; i < da.Rows.Count ; i++ )
                {
                    if ( !string.IsNullOrEmpty( da.Rows[i]["AP022"].ToString( ) ) )
                    {
                        if ( one == "" )
                            one = da.Rows[i]["AP022"].ToString( );
                        else
                            one = one + "," + da.Rows[i]["AP022"].ToString( );
                    }
                    if ( !string.IsNullOrEmpty( da.Rows[i]["AP023"].ToString( ) ) )
                    {
                        if ( two == "" )
                            two = da.Rows[i]["AP023"].ToString( );
                        else
                            two = two + "," + da.Rows[i]["AP023"].ToString( );
                    }
                    if ( !string.IsNullOrEmpty( da.Rows[i]["AP024"].ToString( ) ) )
                    {
                        if ( tre == "" )
                            tre = da.Rows[i]["AP024"].ToString( );
                        else
                            tre = tre + "," + da.Rows[i]["AP024"].ToString( );
                    }
                    if ( !string.IsNullOrEmpty( da.Rows[i]["AP025"].ToString( ) ) )
                    {
                        if ( fore == "" )
                            fore = da.Rows[i]["AP025"].ToString( );
                        else
                            fore = fore + "," + da.Rows[i]["AP025"].ToString( );
                    }
                    if ( !string.IsNullOrEmpty( da.Rows[i]["AP027"].ToString( ) ) )
                    {
                        if ( fiv == "" )
                            fiv = da.Rows[i]["AP027"].ToString( );
                        else
                            fiv = fiv + "," + da.Rows[i]["AP027"].ToString( );
                    }
                    if ( !string.IsNullOrEmpty( da.Rows[i]["AP030"].ToString( ) ) )
                    {
                        if ( six == "" )
                            six = da.Rows[i]["AP030"].ToString( );
                        else
                            six = six + "," + da.Rows[i]["AP030"].ToString( );
                    }
                }
                if ( one != "" )
                {
                    StringBuilder strOne = new StringBuilder( );
                    strOne.AppendFormat( "UPDATE R_PQAK SET AK016=NULL,AK017='' WHERE idx IN (" + one + ")" );
                    SQLString.Add( strOne.ToString( ) );
                }
                if ( two != "" )
                {
                    StringBuilder sqlTwo = new StringBuilder( );
                    sqlTwo.AppendFormat( "UPDATE R_PQWZ SET WZ016='',WZ017=NULL WHERE idx IN (" + two + ")" );
                    SQLString.Add( sqlTwo.ToString( ) );
                }
                if ( tre != "" )
                {
                    StringBuilder sqlTre = new StringBuilder( );
                    sqlTre.AppendFormat( "UPDATE R_PQXZ SET XZ022=NULL,XZ025='' WHERE idx IN (" + tre + ")" );
                    SQLString.Add( sqlTre.ToString( ) );
                }
                if ( fore != "" )
                {
                    StringBuilder sqlFore = new StringBuilder( );
                    sqlFore.AppendFormat( "UPDATE R_PQXZ SET XZ022=NULL,XZ025='' WHERE idx IN (" + fore + ")" );
                    SQLString.Add( sqlFore.ToString( ) );
                }
                if ( fiv != "" )
                {
                    StringBuilder sqlFore = new StringBuilder( );
                    sqlFore.Append( "UPDATE R_PQEZ SET " );
                    sqlFore.Append( "EZ016=NULL," );
                    sqlFore.Append( "EZ015=''" );
                    sqlFore.Append( " WHERE idx IN (" + fiv + ")" );
                    SQLString.Add( sqlFore.ToString( ) );
                }
                if ( six != "" )
                {
                    StringBuilder sqlFore = new StringBuilder( );
                    sqlFore.Append( "UPDATE R_PQBE SET " );
                    sqlFore.Append( "BE014=NULL," );
                    sqlFore.Append( "BE013=''" );
                    sqlFore.Append( " WHERE idx IN (" + six + ")" );
                    SQLString.Add( sqlFore.ToString( ) );
                }
            }
            StringBuilder strS = new StringBuilder( );
            strS.Append( "DELETE FROM R_PQAP WHERE idx IN (" + idxList + ")" );
            SQLString.Add( strS.ToString( ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        public bool DeleteTwo ( string oddNum )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strS = new StringBuilder( );
            strS.AppendFormat( "DELETE FROM R_PQAQ WHERE AQ001='{0}'" ,oddNum );
            SQLString.Add( strS.ToString( ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        public bool DeleteTwos ( string idxList )
        {
            ArrayList SQLString = new ArrayList( );

            StringBuilder strS = new StringBuilder( );
            strS.Append( "DELETE FROM R_PQAQ WHERE idx IN (" + idxList + ")" );
            SQLString.Add( strS.ToString( ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        public bool DeleteTre ( string oddNum )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strS = new StringBuilder( );
            strS.AppendFormat( "DELETE FROM R_PQAO WHERE AO001='{0}'" ,oddNum );
            SQLString.Add( strS.ToString( ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        public bool DeleteTres ( string idxList )
        {
            ArrayList SQLString = new ArrayList( );

            StringBuilder strS = new StringBuilder( );
            strS.Append( "DELETE FROM R_PQAO WHERE idx IN (" + idxList + ")" );
            SQLString.Add( strS.ToString( ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        public bool DeleteFor ( string oddNum )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strS = new StringBuilder( );
            strS.AppendFormat( "DELETE FROM R_PQAR WHERE AR001='{0}'" ,oddNum );
            SQLString.Add( strS.ToString( ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        public bool DeleteFors ( string idxList )
        {
            ArrayList SQLString = new ArrayList( );

            StringBuilder strS = new StringBuilder( );
            strS.Append( "DELETE FROM R_PQAR WHERE idx IN (" + idxList + ")" );
            SQLString.Add( strS.ToString( ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfOddNum ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT YZ001 FROM R_PQYZ" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableOfOddNumOne ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT AP001 FROM R_PQAP" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM (SELECT DISTINCT YZ001,YZ009 FROM R_PQYZ" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") A" );

            object obj = SqlHelper.GetSingle( strSql.ToString( ) );
            if ( obj == null )
                return 0;
            else
                return Convert.ToInt32( obj );
        }
        public int GetCountOne ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM (SELECT DISTINCT AP001,AP009 FROM R_PQAP" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") A" );

            object obj = SqlHelper.GetSingle( strSql.ToString( ) );
            if ( obj == null )
                return 0;
            else
                return Convert.ToInt32( obj );
        }
        public int GetCountTwo ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM (SELECT DISTINCT AQ001,AQ002,AQ003 FROM R_PQAQ" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") A" );

            object obj = SqlHelper.GetSingle( strSql.ToString( ) );
            if ( obj == null )
                return 0;
            else
                return Convert.ToInt32( obj );
        }
        public int GetCountTre ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM (SELECT DISTINCT AO001,AO009 FROM R_PQAO" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") A" );

            object obj = SqlHelper.GetSingle( strSql.ToString( ) );
            if ( obj == null )
                return 0;
            else
                return Convert.ToInt32( obj );
        }
        public int GetCountFor ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM (SELECT DISTINCT AR001,AR009 FROM R_PQAR" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") A" );

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
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTableByChange ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT YZ001,YZ009 FROM (" );
            strSql.Append( "SELECT ROW_NUMBER() OVER (" );
            strSql.Append( "ORDER BY T.YZ009 DESC" );
            strSql.Append( ") AS Row,T.* FROM R_PQYZ T" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") TT" );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableByChangeOne ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT AP001,AP009 FROM (" );
            strSql.Append( "SELECT ROW_NUMBER() OVER (" );
            strSql.Append( "ORDER BY T.AP009 DESC" );
            strSql.Append( ") AS Row,T.* FROM R_PQAP T" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") TT" );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableByChangeTwo ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT AQ001,AQ002,AQ003 FROM (" );
            strSql.Append( "SELECT ROW_NUMBER() OVER (" );
            strSql.Append( "ORDER BY T.AQ001 DESC" );
            strSql.Append( ") AS Row,T.* FROM R_PQAQ T" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") TT" );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableByChangeTre ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT AO001,AO009 FROM (" );
            strSql.Append( "SELECT ROW_NUMBER() OVER (" );
            strSql.Append( "ORDER BY T.AO001 DESC" );
            strSql.Append( ") AS Row,T.* FROM R_PQAO T" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") TT" );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableByChangeFor ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT AR001,AR009 FROM (" );
            strSql.Append( "SELECT ROW_NUMBER() OVER (" );
            strSql.Append( "ORDER BY T.AR001 DESC" );
            strSql.Append( ") AS Row,T.* FROM R_PQAR T" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") TT" );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnlyOne ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT AQ001,AQ002 FROM R_PQAQ" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableOnlyTwo ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT AO001 FROM R_PQAO" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableOnlyTre ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT AR001 FROM R_PQAR" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取本月之前所有记录和
        /// </summary>
        /// <param name="dtOne">当前日期</param>
        /// <param name="dtTwo">开始日期</param>
        /// <returns></returns>
        public DataTable GetDataTableSumOne ( DateTime dtOne ,DateTime dtTwo )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT ISNULL(SUM(YZ011),0) YZ011,ISNULL(SUM(YZ012),0) YZ012,ISNULL(SUM(YZ013),0) YZ013,ISNULL(SUM(YZ014),0) YZ014,ISNULL(SUM(YZ015),0) YZ015,ISNULL(SUM(U0),0) U0,ISNULL(SUM(U1),0) U1,ISNULL(SUM(U2),0) U2,ISNULL(SUM(U3),0) U3,ISNULL(SUM(U4),0) U4,ISNULL(SUM(U5),0) U5,ISNULL(SUM(U6),0) U6,ISNULL(SUM(U7),0) U7,ISNULL(SUM(U8),0) U8,ISNULL(SUM(U9),0) U9,ISNULL(SUM(U10),0) U10,ISNULL(SUM(U28),0) U28,ISNULL(SUM(YZ017),0) YZ017,ISNULL(SUM(U31),0) U31,ISNULL(SUM(U11),0) U11 FROM (" );
            strSql.Append( "SELECT ISNULL(SUM(YZ011),0) YZ011,ISNULL(SUM(YZ012),0) YZ012,ISNULL(SUM(YZ013),0) YZ013,ISNULL(SUM(YZ014),0) YZ014,ISNULL(SUM(YZ015),0) YZ015,CASE WHEN YZ008='材料款' THEN SUM(YZ015-YZ014-YZ026+YZ011+YZ012) ELSE 0 END U0,CASE WHEN YZ008='代理.报关出口' THEN SUM(YZ015-YZ014-YZ026+YZ011+YZ012) ELSE 0 END U1,CASE WHEN YZ008='运输费' THEN SUM(YZ015-YZ014-YZ026+YZ011+YZ012) ELSE 0 END U2,CASE WHEN YZ008='工人工资' THEN SUM(YZ015-YZ014-YZ026+YZ011+YZ012) ELSE 0 END U3,CASE WHEN YZ008='生产管理工资' THEN SUM(YZ017-YZ014-YZ026+YZ011+YZ012) ELSE 0 END U28,ISNULL(SUM(YZ017),0) YZ017,CASE WHEN YZ008='行政工资' THEN SUM(YZ017-YZ014-YZ026+YZ011+YZ012) ELSE 0 END U31,CASE WHEN YZ008='刀具修理款' THEN SUM(YZ017-YZ014-YZ026+YZ011+YZ012) ELSE 0 END U4,CASE WHEN YZ008='砂布款' THEN SUM(YZ017-YZ014-YZ026+YZ011+YZ012) ELSE 0 END U5,CASE WHEN YZ008='餐费' THEN SUM(YZ017-YZ014-YZ026+YZ011+YZ012) ELSE 0 END U6,CASE WHEN YZ008='差旅.招待费' THEN SUM(YZ017-YZ014-YZ026+YZ011+YZ012) ELSE 0 END U7,CASE WHEN YZ008='检测费' THEN SUM(YZ017-YZ014-YZ026+YZ011+YZ012) ELSE 0 END U8,CASE WHEN YZ008='样品费' THEN SUM(YZ017-YZ014-YZ026+YZ011+YZ012) ELSE 0 END U9,CASE WHEN YZ008='其他费' THEN SUM(YZ017-YZ014-YZ026+YZ011+YZ012) ELSE 0 END U10,CASE WHEN YZ008='外购库存' THEN SUM(YZ017-YZ014-YZ026+YZ011+YZ012) ELSE 0 END U11 FROM R_PQYZ" );
            strSql.Append( " WHERE YZ009>=@YZ1 AND YZ009<=@YZ2" );
            strSql.Append( " GROUP BY YZ008) A" );
            SqlParameter[] parameter = {
                new SqlParameter("@YZ1",SqlDbType.Date),
                new SqlParameter("@YZ2",SqlDbType.Date)
            };
            parameter[0].Value = dtOne;
            parameter[1].Value = dtTwo;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public DataTable GetDataTableSumTwo ( DateTime dtOne ,DateTime dtTwo )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT ISNULL(SUM(AP011),0) AP011,ISNULL(SUM(AP012),0) AP012,ISNULL(SUM(AP013),0) AP013,ISNULL(SUM(AP014),0) AP014,ISNULL(SUM(AP015),0) AP015,ISNULL(SUM(U12),0) U12,ISNULL(SUM(U13),0) U13,ISNULL(SUM(U14),0) U14,ISNULL(SUM(U15),0) U15,ISNULL(SUM(U16),0) U16,ISNULL(SUM(U17),0) U17,ISNULL(SUM(U18),0) U18,ISNULL(SUM(U19),0) U19,ISNULL(SUM(U20),0) U20,ISNULL(SUM(U21),0) U21,ISNULL(SUM(U22),0) U22,ISNULL(SUM(U32),0) U32,ISNULL(SUM(AP017),0) AP017,ISNULL(SUM(U33),0) U33,ISNULL(SUM(U25),0) U25 FROM (" );
            strSql.Append( "SELECT ISNULL(SUM(AP011),0) AP011,ISNULL(SUM(AP012),0) AP012,ISNULL(SUM(AP013),0) AP013,ISNULL(SUM(AP014),0) AP014,ISNULL(SUM(AP015),0) AP015,CASE WHEN AP008='材料款' THEN SUM(AP015-AP014-AP026+AP011+AP012) ELSE 0 END U12,CASE WHEN AP008='代理.报关出口' THEN SUM(AP015-AP014-AP026+AP011+AP012) ELSE 0 END U13,CASE WHEN AP008='运输费' THEN SUM(AP015-AP014-AP026+AP011+AP012) ELSE 0 END U14,CASE WHEN AP008='工人工资' THEN SUM(AP015-AP014-AP026+AP011+AP012) ELSE 0 END U15,CASE WHEN AP008='生产管理工资' THEN SUM(AP017-AP014-AP026+AP011+AP012) ELSE 0 END U32,ISNULL(SUM(AP017),0) AP017,CASE WHEN AP008='行政工资' THEN SUM(AP017-AP014-AP026+AP011+AP012) ELSE 0 END U33,CASE WHEN AP008='刀具修理款' THEN SUM(AP017-AP014-AP026+AP011+AP012) ELSE 0 END U16,CASE WHEN AP008='砂布款' THEN SUM(AP017-AP014-AP026+AP011+AP012) ELSE 0 END U17,CASE WHEN AP008='餐费' THEN SUM(AP017-AP014-AP026+AP011+AP012) ELSE 0 END U18,CASE WHEN AP008='差旅.招待费' THEN SUM(AP017-AP014-AP026+AP011+AP012) ELSE 0 END U19,CASE WHEN AP008='检测费' THEN SUM(AP017-AP014-AP026+AP011+AP012) ELSE 0 END U20,CASE WHEN AP008='样品费' THEN SUM(AP017-AP014-AP026+AP011+AP012) ELSE 0 END U21,CASE WHEN AP008='其他费' THEN SUM(AP017-AP014-AP026+AP011+AP012) ELSE 0 END U22,CASE WHEN AP008='外购库存' THEN SUM(AP017-AP014-AP026+AP011+AP012) ELSE 0 END U25 FROM R_PQAP " );
            strSql.Append( " WHERE AP009>=@YZ1 AND AP009<=@YZ2" );
            strSql.Append( " GROUP BY AP008) A" );
            SqlParameter[] parameter = {
                new SqlParameter("@YZ1",SqlDbType.Date),
                new SqlParameter("@YZ2",SqlDbType.Date)
            };
            parameter[0].Value = dtOne;
            parameter[1].Value = dtTwo;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public DataTable GetDataTableSumTre ( DateTime dtOne ,DateTime dtTwo )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT ISNULL(SUM(AO011),0) AO011,ISNULL(SUM(AO012),0) AO012,ISNULL(SUM(AO013),0) AO013,ISNULL(SUM(AO014),0) AO014,CONVERT(DECIMAL(18,2),ISNULL(SUM(AO014*AO015),0)) U27,CONVERT(DECIMAL(18,2),ISNULL(SUM(AO014-AO014*AO015),0)) U26,ISNULL(SUM(AO018),0) AO018 FROM R_PQAO" );
            strSql.Append( " WHERE AO009>=@AO1 AND AO009<=@AO2" );
            SqlParameter[] parameter = {
                new SqlParameter("@AO1",SqlDbType.Date),
                new SqlParameter("@AO2",SqlDbType.Date)
            };
            parameter[0].Value = dtOne;
            parameter[1].Value = dtTwo;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public DataTable GetDataTableSumFor ( DateTime dtOne ,DateTime dtTwo )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT ISNULL(SUM(AR011),0) AR011,ISNULL(SUM(AR012),0) AR012,ISNULL(SUM(AR013),0) AR013,ISNULL(SUM(AR014),0) AR014,CONVERT(DECIMAL(18,2),ISNULL(SUM(AR014*AR015),0)) U29,CONVERT(DECIMAL(18,2),ISNULL(SUM(AR014-AR014*AR015),0)) U30,ISNULL(SUM(AR018),0) AR018 FROM R_PQAR" );
            strSql.Append( " WHERE AR009>=@AO1 AND AR009<=@AO2" );
            SqlParameter[] parameter = {
                new SqlParameter("@AO1",SqlDbType.Date),
                new SqlParameter("@AO2",SqlDbType.Date)
            };
            parameter[0].Value = dtOne;
            parameter[1].Value = dtTwo;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 更改送审记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateOfReview ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_REVIEWS SET " );
            strSql.Append( "RES05='执行'" );
            strSql.Append( " WHERE RES01='R_231' AND RES06=@RES06" );
            SqlParameter[] parameter = {
                new SqlParameter("@RES06",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 批量编辑日期
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool UpdateOfBatchTime ( MulaolaoLibrary.PayMentLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQYZ SET YZ009=@YZ009 WHERE YZ001=@YZ001 AND YZ003=@YZ003" );
            SqlParameter[] parameter = {
                new SqlParameter("@YZ001",SqlDbType.NVarChar),
                new SqlParameter("@YZ003",SqlDbType.NVarChar),
                new SqlParameter("@YZ009",SqlDbType.Date)
            };
            parameter[0].Value = _model.YZ001;
            parameter[1].Value = _model.YZ003;
            parameter[2].Value = _model.YZ009;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }
        public bool UpdateOfBatchTime ( MulaolaoLibrary.PayMentOneLibrary _modelOne )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAP SET AP009=@AP009 WHERE AP001=@AP001 AND AP003=@AP003" );
            SqlParameter[] parameter = {
                new SqlParameter("@AP001",SqlDbType.NVarChar),
                new SqlParameter("@AP003",SqlDbType.NVarChar),
                new SqlParameter("@AP009",SqlDbType.Date)
            };
            parameter[0].Value = _modelOne.AP001;
            parameter[1].Value = _modelOne.AP003;
            parameter[2].Value = _modelOne.AP009;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 写入数据到241
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Read526To241 ( DataTable table )
        {
            bool result = false;
            ArrayList SQLString = new ArrayList( );
            DataTable dk;
            string strWhere = "";
            MulaolaoLibrary.ProductCostSummaryLibrary model = new MulaolaoLibrary.ProductCostSummaryLibrary( );
            MulaolaoLibrary.ProductCostSummaryOfSumLibrary _model = new MulaolaoLibrary.ProductCostSummaryOfSumLibrary( );
            MulaolaoLibrary.PayMentLibrary modelOne = new MulaolaoLibrary.PayMentLibrary( );
            string idxList = "", numList = "", idxListOf = "", idxListOfOther = "", idxListOfGong = "";
            if ( table != null && table.Rows.Count > 0 )
            {
                strWhere = "1=1";
                modelOne.YZ001 = table.Rows[0]["YZ001"].ToString( );
                strWhere = strWhere + " AND YZ001='" + modelOne.YZ001 + "'";
                dk = GetDataTableOfAll( strWhere );
                if ( dk != null && dk.Rows.Count > 0 )
                {
                    for ( int k = 0 ; k < table.Rows.Count ; k++ )
                    {
                        modelOne.IDX = string.IsNullOrEmpty( table.Rows[k]["idx"].ToString( ) ) == true ? 0 : Convert.ToInt32( table.Rows[k]["idx"].ToString( ) );
                        modelOne.YZ003 = table.Rows[k]["YZ003"].ToString( );
                        if ( modelOne.IDX > 0 && table.Select( "idx='" + modelOne.IDX + "'" ).Length > 0 )
                            modelOne.YZ009 = Convert.ToDateTime( table.Select( "idx='" + modelOne.IDX + "'" )[0]["YZ009"].ToString( ) );
                        if ( modelOne.YZ003.Contains( "审核" ) && dk.Select( "idx='" + modelOne.IDX + "' AND YZ003='" + modelOne.YZ003 + "'" ).Length < 1 )
                        {
                            _model.BB001 = modelOne.YZ003;
                            _model.BB002 = modelOne.YZ009;

                            if ( idxList == "" )
                                idxList = table.Rows[k]["YZ022"].ToString( );
                            else
                            {
                                if ( !string.IsNullOrEmpty( table.Rows[k]["YZ022"].ToString( ) ) )
                                    idxList = idxList + "," + table.Rows[k]["YZ022"].ToString( );
                            }
                            if ( idxListOf == "" )
                                idxListOf = table.Rows[k]["YZ027"].ToString( );
                            else
                            {
                                if ( !string.IsNullOrEmpty( table.Rows[k]["YZ027"].ToString( ) ) )
                                    idxListOf = idxListOf + "," + table.Rows[k]["YZ027"].ToString( );
                            }
                            if ( idxListOfOther == "" )
                                idxListOfOther = table.Rows[k]["YZ030"].ToString( );
                            else
                            {
                                if ( !string.IsNullOrEmpty( table.Rows[k]["YZ030"].ToString( ) ) )
                                    idxListOfOther = idxListOfOther + "," + table.Rows[k]["YZ030"].ToString( );
                            }
                            if ( idxListOfGong == "" )
                                idxListOfGong = table.Rows[k]["YZ023"].ToString( );
                            else
                            {
                                if ( !string.IsNullOrEmpty( table.Rows[k]["YZ023"].ToString( ) ) )
                                    idxListOfGong = idxListOfGong + "," + table.Rows[k]["YZ023"].ToString( );
                            }

                        }
                        else if ( k == table.Rows.Count - 1 && _model.BB001 != "审核" )
                        {
                            if ( table.Select( "YZ003='" + "执行" + "'" ).Length > 0 )
                            {
                                _model.BB001 = "执行";
                                _model.BB002 = Convert.ToDateTime( table.Select( "YZ003='" + "执行" + "'" )[0]["YZ009"].ToString( ) );
                            }
                        }
                    }
                }

                if ( string.IsNullOrEmpty( idxList ) && string.IsNullOrEmpty( idxListOf ) && string.IsNullOrEmpty( idxListOfOther ) )
                {
                    if ( _model.BB001 == "执行" )
                    {
                        Pqbb( dk ,_model ,SQLString );
                        return SqlHelper.ExecuteSqlTran( SQLString );
                    }
                    return true;
                }

                if ( !string.IsNullOrEmpty( idxList ) )
                {
                    DataTable dl = GetDataTablePqak( idxList );
                    if ( dl != null && dl.Rows.Count > 0 )
                    {
                        do
                        {
                            idxList = idxList.Replace( ",," ,"," );
                        } while ( idxList.Contains( ",," ) );
                        idxList = idxList.TrimEnd( ',' );

                        for ( int k = 0 ; k < dl.Rows.Count ; k++ )
                        {
                            if ( numList == "" )
                                numList = "'" + dl.Rows[k]["AK002"].ToString( ) + "'";
                            else
                                numList = numList + "," + "'" + dl.Rows[k]["AK002"].ToString( ) + "'";
                        }

                        #region 195
                        result = Pqq( idxList ,numList ,model ,dk ,SQLString );
                        if ( result == false )
                            return false;
                        #endregion

                        #region 196
                        SQLString.Clear( );
                        result = Pqah( idxList ,numList ,model ,dk ,SQLString );
                        if ( result == false )
                            return false;
                        #endregion

                        #region 338
                        SQLString.Clear( );
                        result = Pqo( idxList ,numList ,model ,dk ,SQLString );
                        if ( result == false )
                            return false;
                        #endregion

                        #region 339
                        SQLString.Clear( );
                        result = Pqi( idxList ,numList ,model ,dk ,SQLString );
                        if ( result == false )
                            return false;
                        #endregion

                        #region 341
                        SQLString.Clear( );
                        result = Pqv( idxList ,numList ,model ,dk ,SQLString );
                        if ( result == false )
                            return false;
                        #endregion

                        #region 342
                        SQLString.Clear( );
                        result = Pqaf( idxList ,numList ,model ,dk ,SQLString );
                        if ( result == false )
                            return false;
                        #endregion

                        #region 343
                        SQLString.Clear( );
                        result = Pqu( idxList ,numList ,model ,dk ,SQLString );
                        if ( result == false )
                            return false;
                        #endregion

                        #region 344 漆
                        SQLString.Clear( );
                        result = Pqlz( idxList ,numList ,model ,dk ,SQLString );
                        if ( result == false )
                            return false;
                        #endregion

                        #region 344 工资
                        SQLString.Clear( );
                        result = Pqmz( idxList ,numList ,model ,dk ,SQLString );
                        if ( result == false )
                            return false;
                        #endregion

                        #region 347
                        SQLString.Clear( );
                        result = Pqs( idxList ,numList ,model ,dk ,SQLString );
                        if ( result == false )
                            return false;
                        #endregion

                        #region 348
                        SQLString.Clear( );
                        result = Pqts( idxList ,numList ,model ,dk ,SQLString );
                        if ( result == false )
                            return false;
                        #endregion

                        #region 349
                        SQLString.Clear( );
                        result = Pqt( idxList ,numList ,model ,dk ,SQLString );
                        if ( result == false )
                            return false;
                        #endregion

                        //#region 495
                        ////读到241喷漆工资
                        //SQLString.Clear( );
                        //result = Pqy( idxList ,numList ,model ,dk ,SQLString );
                        //if ( result == false )
                        //    return false;
                        //#endregion
                    }
                }
                #region 317
                SQLString.Clear( );
                if ( !string.IsNullOrEmpty( idxListOf ) )
                {
                    do
                    {
                        idxListOf = idxListOf.Replace( ",," ,"," );
                    } while ( idxListOf.Contains( ",," ) );
                    idxListOf = idxListOf.TrimEnd( ',' );

                    result = Pqw( idxListOf ,numList ,model ,dk ,SQLString );
                    if ( result == false )
                        return false;
                }
                #endregion

                #region 243
                SQLString.Clear( );
                if ( !string.IsNullOrEmpty( idxListOfOther ) )
                {
                    do
                    {
                        idxListOfOther = idxListOfOther.Replace( ",," ,"," );
                    } while ( idxListOfOther.Contains( ",," ) );
                    idxListOfOther = idxListOfOther.TrimEnd( ',' );

                    result = Pqbe( idxListOfOther ,model ,dk ,SQLString );
                    if ( result == false )
                        return false;
                }
                #endregion

                #region 244
                //SQLString.Clear( );
                //if ( !string.IsNullOrEmpty( idxListOfGong ) )
                //{
                //    do
                //    {
                //        idxListOfGong = idxListOfGong.Replace( ",," ,"," );
                //    } while ( idxListOfGong.Contains( ",," ) );
                //    idxListOfGong = idxListOfGong.TrimEnd( ',' );

                //    result = Pqbe( idxListOfOther ,model ,dk ,SQLString );
                //    if ( result == false )
                //        return false;
                //}
                #endregion

                #region 写总计数据
                SQLString.Clear( );
                //循环有问题
                SQLString.Clear( );
                Pqbb( dk ,_model ,SQLString );
                #endregion
            }
            else
                return true;

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        public bool Read526To241AP ( DataTable table )
        {
            bool result = false;
            ArrayList SQLString = new ArrayList( );
            DataTable dk;
            string strWhere = "";
            MulaolaoLibrary.PayMentOneLibrary _modelOne = new MulaolaoLibrary.PayMentOneLibrary( );
            MulaolaoLibrary.ProductCostSummaryLibrary model = new MulaolaoLibrary.ProductCostSummaryLibrary( );
            MulaolaoLibrary.ProductCostSummaryOfSumLibrary _model = new MulaolaoLibrary.ProductCostSummaryOfSumLibrary( );
            string idxList = "", numList = "", idxListOf = "", idxListOfOther = "";
            if ( table != null && table.Rows.Count > 0 )
            {
                strWhere = "1=1";
                _modelOne.AP001 = table.Rows[0]["AP001"].ToString( );
                strWhere = strWhere + " AND AP001='" + _modelOne.AP001 + "'";
                dk = GetDataTableOfAllOne( strWhere );
                if ( dk != null && dk.Rows.Count > 0 )
                {
                    for ( int k = 0 ; k < table.Rows.Count ; k++ )
                    {
                        _modelOne.IDX = string.IsNullOrEmpty( table.Rows[k]["idx"].ToString( ) ) == true ? 0 : Convert.ToInt32( table.Rows[k]["idx"].ToString( ) );
                        _modelOne.AP003 = table.Rows[k]["AP003"].ToString( );
                        if ( _modelOne.IDX > 0 && table.Select( "idx='" + _modelOne.IDX + "'" ).Length > 0 )
                            _modelOne.AP009 = Convert.ToDateTime( table.Select( "idx='" + _modelOne.IDX + "'" )[0]["AP009"].ToString( ) );
                        if ( _modelOne.AP003.Contains( "审核" ) && dk.Select( "idx='" + _modelOne.IDX + "' AND AP003='" + _modelOne.AP003 + "'" ).Length < 1 )
                        {
                            _model.BB001 = _modelOne.AP003;
                            _model.BB002 = _modelOne.AP009;

                            if ( idxList == "" )
                                idxList = table.Rows[k]["AP022"].ToString( );
                            else
                            {
                                if ( !string.IsNullOrEmpty( table.Rows[k]["AP022"].ToString( ) ) )
                                    idxList = idxList + "," + table.Rows[k]["AP022"].ToString( );
                            }
                            if ( idxListOf == "" )
                                idxListOf = table.Rows[k]["AP027"].ToString( );
                            else
                            {
                                if ( !string.IsNullOrEmpty( table.Rows[k]["AP027"].ToString( ) ) )
                                    idxListOf = idxListOf + "," + table.Rows[k]["AP027"].ToString( );
                            }
                            if ( idxListOfOther == "" )
                                idxListOfOther = table.Rows[k]["AP030"].ToString( );
                            else
                            {
                                if ( !string.IsNullOrEmpty( table.Rows[k]["AP030"].ToString( ) ) )
                                    idxListOfOther = idxListOfOther + "," + table.Rows[k]["AP030"].ToString( );
                            }
                        }
                        else if ( k == table.Rows.Count - 1 && _model.BB001 != "审核" )
                        {
                            if ( table.Select( "AP003='" + "执行" + "'" ).Length > 0 )
                            {
                                _model.BB001 = "执行";
                                _model.BB002 = Convert.ToDateTime( table.Select( "AP003='" + "执行" + "'" )[0]["AP009"].ToString( ) );
                            }
                        }
                    }
                }

                if ( string.IsNullOrEmpty( idxList ) && string.IsNullOrEmpty( idxListOf ) && string.IsNullOrEmpty( idxListOfOther ) )
                {
                    if ( _model.BB001 == "执行" )
                    {
                        Pqbb( dk ,_model ,SQLString );
                        return SqlHelper.ExecuteSqlTran( SQLString );
                    }
                    return true;
                }

                if ( !string.IsNullOrEmpty( idxList ) )
                {
                    do
                    {
                        idxList = idxList.Replace( ",," ,"," );
                    } while ( idxList.Contains( ",," ) );
                    idxList = idxList.TrimEnd( ',' );
                    DataTable dl = GetDataTablePqak( idxList );
                    if ( dl != null && dl.Rows.Count > 0 )
                    {
                        for ( int k = 0 ; k < dl.Rows.Count ; k++ )
                        {
                            if ( numList == "" )
                                numList = "'" + dl.Rows[k]["AK002"].ToString( ) + "'";
                            else
                                numList = numList + "," + "'" + dl.Rows[k]["AK002"].ToString( ) + "'";
                        }

                        #region 195
                        result = Pqq( idxList ,numList ,model ,dk ,SQLString );
                        if ( result == false )
                            return false;
                        #endregion

                        #region 196
                        SQLString.Clear( );
                        result = Pqah( idxList ,numList ,model ,dk ,SQLString );
                        if ( result == false )
                            return false;
                        #endregion

                        #region 338
                        SQLString.Clear( );
                        result = Pqo( idxList ,numList ,model ,dk ,SQLString );
                        if ( result == false )
                            return false;
                        #endregion

                        #region 339
                        SQLString.Clear( );
                        result = Pqi( idxList ,numList ,model ,dk ,SQLString );
                        if ( result == false )
                            return false;
                        #endregion

                        #region 341
                        SQLString.Clear( );
                        result = Pqv( idxList ,numList ,model ,dk ,SQLString );
                        if ( result == false )
                            return false;
                        #endregion

                        #region 342
                        SQLString.Clear( );
                        result = Pqaf( idxList ,numList ,model ,dk ,SQLString );
                        if ( result == false )
                            return false;
                        #endregion

                        #region 343
                        SQLString.Clear( );
                        result = Pqu( idxList ,numList ,model ,dk ,SQLString );
                        if ( result == false )
                            return false;
                        #endregion

                        #region 344 漆
                        SQLString.Clear( );
                        result = Pqlz( idxList ,numList ,model ,dk ,SQLString );
                        if ( result == false )
                            return false;
                        #endregion

                        #region 344 工资
                        SQLString.Clear( );
                        result = Pqmz( idxList ,numList ,model ,dk ,SQLString );
                        if ( result == false )
                            return false;
                        #endregion

                        #region 347
                        SQLString.Clear( );
                        result = Pqs( idxList ,numList ,model ,dk ,SQLString );
                        if ( result == false )
                            return false;
                        #endregion

                        #region 348
                        SQLString.Clear( );
                        result = Pqts( idxList ,numList ,model ,dk ,SQLString );
                        if ( result == false )
                            return false;
                        #endregion

                        #region 349
                        SQLString.Clear( );
                        result = Pqt( idxList ,numList ,model ,dk ,SQLString );
                        if ( result == false )
                            return false;
                        #endregion

                        //#region 495
                        ////读到241喷漆工资
                        //SQLString.Clear( );
                        //result = Pqy( idxList ,numList ,model ,dk ,SQLString );
                        //if ( result == false )
                        //    return false;
                        //#endregion
                    }
                }
                #region 317
                SQLString.Clear( );
                if ( !string.IsNullOrEmpty( idxListOf ) )
                {
                    do
                    {
                        idxListOf = idxListOf.Replace( ",," ,"," );
                    } while ( idxListOf.Contains( ",," ) );
                    idxListOf = idxListOf.TrimEnd( ',' );

                    result = Pqw( idxListOf ,numList ,model ,dk ,SQLString );
                    if ( result == false )
                        return false;
                }
                #endregion

                #region 243
                SQLString.Clear( );
                if ( !string.IsNullOrEmpty( idxListOfOther ) )
                {
                    do
                    {
                        idxListOfOther = idxListOfOther.Replace( ",," ,"," );
                    } while ( idxListOfOther.Contains( ",," ) );
                    idxListOfOther = idxListOfOther.TrimEnd( ',' );

                    result = Pqbe( idxListOfOther ,model ,dk ,SQLString );
                    if ( result == false )
                        return false;
                }
                #endregion

                #region 写总计数据
                SQLString.Clear( );
                //循环有问题
                SQLString.Clear( );
                Pqbb( dk ,_model ,SQLString );
                #endregion
            }
            else
                return true;

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取流水号等信息
        /// </summary>
        /// <param name="idxList"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqak ( string idxList )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT AK002 FROM R_PQAK WHERE idx IN (" + idxList + ")" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool ExistsOfCount ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQAM " );
            strSql.Append( " WHERE AM002=@AM002" );
            SqlParameter[] parameter = {
                new SqlParameter("@AM002",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取195数据
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqq ( string numList ,string idxList )
        {
            StringBuilder strSql = new StringBuilder( );
            //strSql.Append( "SELECT CP01,CP56,CP58,SUM(CP) CP,SUM(ISNULL(CASE WHEN AK>=CP THEN CP WHEN AK=0 THEN 0 END,0)) AK FROM (SELECT A.idx,CASE WHEN CP09 LIKE '%雕刻%' THEN '雕刻' WHEN CP09 LIKE '%绕锯%' THEN '绕锯' WHEN CP09 LIKE '%夹料%' THEN '夹料' WHEN CP09 LIKE '%砂皮%' THEN '擦砂皮' WHEN CP09 LIKE '%丝印%' THEN '丝印' WHEN CP09 LIKE '%走台印%' THEN '走台印' WHEN CP09 LIKE '%移印%' THEN '移印' WHEN CP09 LIKE '%热转印%' THEN '热转印' WHEN CP09 LIKE '%烫印%' THEN '烫印' WHEN CP09 LIKE '%喷漆%' THEN '喷漆' WHEN CP09 LIKE '%冲压%' THEN '冲压' WHEN CP09 LIKE '%/%' THEN '委外' ELSE '手工剪切、其它' END CP09,CASE CP56 WHEN 'T' THEN 'T' ELSE 'F' END CP56,CASE CP58 WHEN 'T' THEN 'T' ELSE 'F' END CP58,CP01,CONVERT(DECIMAL(18,2),SUM(CASE WHEN CP10=0 THEN CP13*CP54*CP11-CP12 ELSE CP13*CP54*CP10-CP12 END)) CP,ISNULL(AK011,0) AK FROM R_PQQ A LEFT JOIN R_PQAL B ON A.CP03=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx AND C.idx IN (" + idxList + ") INNER JOIN R_REVIEWS D ON A.CP03=D.RES06 AND RES05='执行' " );
            //strSql.Append( "WHERE CP01 IN (" + numList + ") AND (CP01!='' AND CP01 IS NOT NULL)" );//   AND LEN(CP01)=8
            //strSql.Append( " GROUP BY A.idx,CP56,CP58,CP01,CP09,AK011) A WHERE AK!=0 AND CP09='委外' GROUP BY CP09,CP56,CP58,CP01" );
            //strSql.Append( " UNION" );
            //strSql.Append( " SELECT BA001,BA056,BA058,SUM(BA) BA,SUM(CASE WHEN AK>=BA THEN BA WHEN AK=0 THEN 0 END) AK FROM (" );
            //strSql.Append( "SELECT BA001,BA056,BA058,CONVERT(DECIMAL(18,2),SUM(BA011*BA054)) BA,ISNULL(AK011,0) AK FROM R_PQBA A LEFT JOIN R_PQAL B ON A.BA003=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx AND C.idx IN (" + idxList + ") INNER JOIN R_REVIEWS D ON A.BA003=D.RES06 AND RES05='执行'" );
            //strSql.Append( " WHERE BA001 IN (" + numList + ") AND (BA001!='' AND BA001 IS NOT NULL)" );//   AND LEN(CP01)=8
            //strSql.Append( " GROUP BY BA056,BA058,AK011,BA001) A WHERE AK!=0 GROUP BY BA056,BA058,BA001 ORDER BY CP01" );

            /*  2017-8-4
            strSql . Append ( "SELECT CP01,CP56,CP58,CONVERT(DECIMAL(18,2),SUM(CP)) CP,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(CP)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(CP)) END AK,AK017 FROM (SELECT A.idx,CASE WHEN CP09 LIKE '%雕刻%' THEN '雕刻' WHEN CP09 LIKE '%绕锯%' THEN '绕锯' WHEN CP09 LIKE '%夹料%' THEN '夹料' WHEN CP09 LIKE '%砂皮%' THEN '擦砂皮' WHEN CP09 LIKE '%丝印%' THEN '丝印' WHEN CP09 LIKE '%走台印%' THEN '走台印' WHEN CP09 LIKE '%移印%' THEN '移印' WHEN CP09 LIKE '%热转印%' THEN '热转印' WHEN CP09 LIKE '%烫印%' THEN '烫印' WHEN CP09 LIKE '%喷漆%' THEN '喷漆' WHEN CP09 LIKE '%冲压%' THEN '冲压' WHEN CP09 LIKE '%/%' THEN '委外' ELSE '手工剪切、其它' END CP09,CASE CP56 WHEN 'T' THEN 'T' ELSE 'F' END CP56,CASE CP58 WHEN 'T' THEN 'T' ELSE 'F' END CP58,CP01,CASE WHEN CP10=0 THEN CP13*CP54*CP11-CP12 ELSE CP13*CP54*CP10-CP12 END CP,CP03 FROM R_PQQ A LEFT JOIN R_PQAL B ON A.CP03=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx   INNER JOIN R_REVIEWS D ON A.CP03=D.RES06 AND RES05='执行' " );
            strSql . Append ( "WHERE CP01 IN (" + numList + ") AND C.idx IN (" + idxList + ") AND (CP01!='' AND CP01 IS NOT NULL) " );
            strSql . Append ( ") A LEFT JOIN R_PQAK B ON A.CP03=B.AK003 WHERE CP09='委外' GROUP BY CP09,CP56,CP58,CP01,ISNULL(AK011,0),AK017 " );
            strSql . Append ( "UNION ALL " );
            strSql . Append ( "SELECT BA001,BA056,BA058,CONVERT(DECIMAL(18,2),SUM(BA)) BA,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(BA)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(BA)) END AK,AK017 FROM (SELECT BA001,BA056,BA058,BA011*BA054 BA,BA003 FROM R_PQBA A LEFT JOIN R_PQAL B ON A.BA003=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx INNER JOIN R_REVIEWS D ON A.BA003=D.RES06 AND RES05='执行' " );
            strSql . Append ( "WHERE BA001 IN (" + numList + ") AND C.idx IN (" + idxList + ") AND (BA001!='' AND BA001 IS NOT NULL) " );
            strSql . Append ( ") A LEFT JOIN R_PQAK B ON A.BA003=B.AK003  GROUP BY BA056,BA058,BA001,ISNULL(AK011,0),AK017 ORDER BY CP01" );
            */

            strSql . Append ( "SELECT CP01,CP56,CP58,CONVERT(DECIMAL(18,2),SUM(CP)) CP,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(CP)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(CP)) END AK,AK017 FROM (SELECT A.idx,CASE WHEN CP09 LIKE '%雕刻%' THEN '雕刻' WHEN CP09 LIKE '%绕锯%' THEN '绕锯' WHEN CP09 LIKE '%夹料%' THEN '夹料' WHEN CP09 LIKE '%砂皮%' THEN '擦砂皮' WHEN CP09 LIKE '%丝印%' THEN '丝印' WHEN CP09 LIKE '%走台印%' THEN '走台印' WHEN CP09 LIKE '%移印%' THEN '移印' WHEN CP09 LIKE '%热转印%' THEN '热转印' WHEN CP09 LIKE '%烫印%' THEN '烫印' WHEN CP09 LIKE '%喷漆%' THEN '喷漆' WHEN CP09 LIKE '%冲压%' THEN '冲压' WHEN CP09 LIKE '%/%' THEN '委外' ELSE '手工剪切、其它' END CP09,CASE CP56 WHEN 'T' THEN 'T' ELSE 'F' END CP56,CASE CP58 WHEN 'T' THEN 'T' ELSE 'F' END CP58,CP01,CASE WHEN CP10=0 THEN CP13*CP54*CP11-CP12 ELSE CP13*CP54*CP10-CP12 END CP,CP03,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQQ A LEFT JOIN R_PQAL B ON A.CP03=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx INNER JOIN R_REVIEWS D ON A.CP03=D.RES06 " );
            strSql . Append ( "WHERE CP01 IN (" + numList + ") AND C.idx IN (" + idxList + ")  AND RES05='执行' AND (CP01!='' AND CP01 IS NOT NULL) GROUP BY A.idx,CP09,CP56,CP58,CP01,CP10,CP13,CP54,CP11,CP12,CP03,AK017 " );
            strSql . Append ( ") A WHERE CP09='委外' GROUP BY CP09,CP56,CP58,CP01,ISNULL(AK011,0),AK017 " );
            strSql . Append ( "UNION ALL " );
            strSql . Append ( "SELECT BA001,BA056,BA058,CONVERT(DECIMAL(18,2),SUM(BA)) BA,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(BA)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(BA)) END AK,AK017 FROM (SELECT BA001,BA056,BA058,BA011*BA054 BA,BA003,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQBA A LEFT JOIN R_PQAL B ON A.BA003=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx INNER JOIN R_REVIEWS D ON A.BA003=D.RES06 " );
            strSql . Append ( "WHERE BA001 IN (" + numList + ") AND C.idx IN (" + idxList + ") AND RES05='执行' AND (BA001!='' AND BA001 IS NOT NULL) GROUP BY BA001,BA056,BA058,BA011,BA054,BA003,AK017" );
            strSql . Append ( ") A GROUP BY BA056,BA058,BA001,ISNULL(AK011,0),AK017 ORDER BY CP01" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public void UpdatePqq ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            strSql.AppendFormat( "AM108='{0}'," ,model.AM108 );
            strSql.AppendFormat( "AM109='{0}'," ,model.AM109 );
            strSql.AppendFormat( "AM110='{0}'," ,model.AM110 );
            strSql.AppendFormat( "AM111='{0}'," ,model.AM111 );
            strSql.AppendFormat( "AM112='{0}'," ,model.AM112 );
            strSql.AppendFormat( "AM113='{0}'," ,model.AM113 );
            strSql.AppendFormat( "AM115='{0}'," ,model.AM115 );
            strSql.AppendFormat( "AM116='{0}'" ,model.AM116 );
            strSql.AppendFormat( " WHERE AM002='{0}'" ,model.AM002 );
            SQLString.Add( strSql.ToString( ) );
        }
        public string AddPqq ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            //oddNumbers.purchaseContract( "SELECT MAX(AM001) AM001 FROM R_PQAM" ,"AM001" ,"R_241-" );
            model.AM001 = generateOddNum.purchaseContract( "SELECT MAX(AJ024) AJ024 FROM R_PQAJ" ,"AJ024" ,"R_241-" );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAM (" );
            strSql.Append( "AM002,AM108,AM109,AM110,AM111,AM112,AM113,AM001,AM115,AM116)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')" ,model.AM002 ,model.AM108 ,model.AM109 ,model.AM110 ,model.AM111 ,model.AM112 ,model.AM113 ,model.AM001 ,model.AM115 ,model.AM116 );

            return strSql.ToString( );
        }
        public bool Pqq ( string idxList ,string numList ,MulaolaoLibrary.ProductCostSummaryLibrary model ,DataTable dk ,ArrayList SQLString )
        {
            dk = GetDataTablePqq( numList ,idxList );
            if ( dk != null && dk.Rows.Count > 0 )
            {
                for ( int m = 0 ; m < dk.Rows.Count ; m++ )
                {
                    model.AM002 = dk.Rows[m]["CP01"].ToString( );
                    model.AM109 = model.AM108 = model.AM111 = model.AM112 = model.AM110 = model.AM113 = model.AM115 = model.AM116 = 0M;

                    //model.AM108 = string.IsNullOrEmpty( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and CP58= 'F' AND CP56='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and CP58= 'F'  AND CP56='F'" ) );
                    model.AM109 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and CP58= 'F'  AND CP56='F' AND (AK017='执行' OR AK017='审核')" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and CP58= 'F'  AND CP56='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM111 = string.IsNullOrEmpty( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and CP58= 'T' AND CP56='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and CP58= 'T' AND CP56='F'" ) );
                    model.AM112 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and CP58= 'T' AND CP56='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and CP58= 'T' AND CP56='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM110 = string.IsNullOrEmpty( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and CP58= 'F' AND CP56='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and CP58= 'F' AND CP56='T'" ) );
                    model.AM113 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and CP58= 'F' AND CP56='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and CP58= 'F' AND CP56='T' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM115 = string.IsNullOrEmpty( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and CP58= 'T' AND CP56='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and CP58= 'T' AND CP56='T'" ) );
                    model.AM116 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and CP58= 'T' AND CP56='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and CP58= 'T' AND CP56='T' AND (AK017='执行' OR AK017='审核')" ) );
          
                    if ( m == 0 )
                    {
                        ofOneY( model ,SQLString );
                        if ( ExistsOfCount( model.AM002 ) )
                        {
                            ofOne( model );
                            UpdatePqq( model ,SQLString );
                        }
                        else
                            SQLString.Add( AddPqq( model ) );
                    }
                    if ( m >= 1 )
                    {
                        if ( model.AM002 != dk.Rows[m - 1]["CP01"].ToString( ) )
                        {
                            ofOneY( model ,SQLString );
                            if ( ExistsOfCount( model.AM002 ) )
                            {
                                ofOne( model );
                                UpdatePqq( model ,SQLString );
                            }
                            else
                                SQLString.Add( AddPqq( model ) );
                        }
                    }
                }
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        public DataTable GetDataTableOfOne ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AM109,AM112,AM113,AM116 FROM R_PQAM" );
            strSql.Append( " WHERE AM002=@AM002" );
            SqlParameter[] parameter = {
                new SqlParameter("@AM002",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        void ofOne ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            DataTable ofOne = GetDataTableOfOne( model.AM002 );
            if ( ofOne != null && ofOne.Rows.Count > 0 )
            {
                model.AM109 += string.IsNullOrEmpty( ofOne.Rows[0]["AM109"].ToString( ) ) == true ? 0 : Convert.ToDecimal( ofOne.Rows[0]["AM109"].ToString( ) );
                model.AM112 += string.IsNullOrEmpty( ofOne.Rows[0]["AM112"].ToString( ) ) == true ? 0 : Convert.ToDecimal( ofOne.Rows[0]["AM112"].ToString( ) );
                model.AM113 += string.IsNullOrEmpty( ofOne.Rows[0]["AM113"].ToString( ) ) == true ? 0 : Convert.ToDecimal( ofOne.Rows[0]["AM113"].ToString( ) );
                model.AM116 += string.IsNullOrEmpty( ofOne.Rows[0]["AM116"].ToString( ) ) == true ? 0 : Convert.ToDecimal( ofOne.Rows[0]["AM116"].ToString( ) );
            }
        }
        internal DataTable GetDataTableOfOneY ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT A.CP03,CASE CP56 WHEN 'T' THEN 'T' ELSE 'F' END CP56,CASE CP58 WHEN 'T' THEN 'T' ELSE 'F' END CP58,CP01,CONVERT(DECIMAL(18,2),SUM(CASE WHEN CP10=0 THEN CP13*CP54*CP11-CP12 WHEN CP11=0 THEN CP13*CP54*CP10-CP12 END)) CP FROM R_PQQ A LEFT JOIN R_REVIEWS D ON A.CP03=D.RES06 AND RES05='执行'" );
            strSql.Append( " WHERE CP01=@CP01" );
            strSql.Append( " GROUP BY A.CP03,CP56,CP58,CP01" );
            strSql.Append( " UNION" );
            strSql.Append( " SELECT BA003,BA056,BA058,BA001,CONVERT(DECIMAL(18,0),SUM(BA011*BA054)) BA FROM R_PQBA A LEFT JOIN R_REVIEWS D ON A.BA003=D.RES06 AND RES05='执行'" );
            strSql.Append( " WHERE BA001=@CP01" );
            strSql.Append( " GROUP BY BA056,BA058,BA001,BA003" );
            SqlParameter[] parameter = {
                new SqlParameter("@CP01",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        void ofOneY ( MulaolaoLibrary.ProductCostSummaryLibrary model,ArrayList SQLString )
        {
            DataTable one = GetDataTableOfOneY( model.AM002 );
            if ( one != null && one.Rows.Count > 0 )
            {
                string oddNum = "";
                for ( int i = 0 ; i < one.Rows.Count ; i++ )
                {
                    oddNum = one.Rows[i]["CP03"].ToString( );
                    model.AM108 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP58= 'F' AND CP56='F' AND CP03='"+oddNum+"'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP58= 'F'  AND CP56='F' AND CP03='" + oddNum + "'" ) );
                    model.AM111 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP58= 'T' AND CP56='F' AND CP03='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP58= 'T' AND CP56='F' AND CP03='" + oddNum + "'" ) );
                    model.AM110 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP58= 'F' AND CP56='T' AND CP03='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP58= 'F' AND CP56='T' AND CP03='" + oddNum + "'" ) );
                    model.AM115 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP58= 'T' AND CP56='T' AND CP03='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP58= 'T' AND CP56='T' AND CP03='" + oddNum + "'" ) );
                    WriteReceivableToGeneralLedger.ByOneByChanPintZhiBao( model ,oddNum ,SQLString );                 
                }

                model.AM108 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP58= 'F' AND CP56='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP58= 'F'  AND CP56='F'" ) );
                model.AM111 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP58= 'T' AND CP56='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP58= 'T' AND CP56='F'" ) );
                model.AM110 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP58= 'F' AND CP56='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP58= 'F' AND CP56='T'" ) );
                model.AM115 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP58= 'T' AND CP56='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP58= 'T' AND CP56='T'" ) );
            }
        }
        
        /// <summary>
        /// 获取R_196数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableTwo ( string numListr ,string idxList )
        {
            StringBuilder strSql = new StringBuilder( );
            /*
            strSql.Append( "SELECT CP01,CP09 AH18,CASE WHEN CP58='' THEN 'F' ELSE CP58 END CP58,CASE WHEN CP56='' THEN 'F' ELSE CP56 END CP56,SUM(ISNULL(CP,0)) AH,SUM(CASE WHEN AK>=CP THEN CP WHEN AK<CP THEN AK ELSE 0 END) AK FROM (" );
            strSql.Append( "SELECT A.idx,CP01,CASE WHEN CP09 LIKE '%雕刻%' THEN '雕刻' WHEN CP09 LIKE '%绕锯%' THEN '绕锯' WHEN CP09 LIKE '%夹料%' THEN '夹料' WHEN CP09 LIKE '%砂皮%' THEN '擦砂皮' WHEN CP09 LIKE '%丝印%' THEN '丝印' WHEN CP09 LIKE '%走台印%' THEN '走台印' WHEN CP09 LIKE '%移印%' THEN '移印' WHEN CP09 LIKE '%热转印%' THEN '热转印' WHEN CP09 LIKE '%烫印%' THEN '烫印' WHEN CP09 LIKE '%喷漆%' THEN '喷漆' WHEN CP09 LIKE '%冲压%' THEN '冲压' WHEN CP09 LIKE '%/%' THEN '委外' ELSE '手工剪切、其它' END CP09,CONVERT(DECIMAL(18,2),SUM(CASE WHEN CP10=0 THEN CP13*CP54*CP11-CP12 ELSE CP13*CP54*CP10-CP12 END)) CP,ISNULL(AK011,0) AK,ISNULL(CP58,'F') CP58,ISNULL(CP56,'F') CP56 FROM R_PQQ A LEFT JOIN R_PQAL B ON A.CP03=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx AND C.idx IN (" + idxList + ") INNER JOIN R_REVIEWS D ON A.CP03=D.RES06 AND RES05='执行'" );
            strSql.Append( " WHERE CP01 IN (" + numListr + ") AND (CP01!='' AND CP01 IS NOT NULL)" );//   AND LEN(CP01)=8
            strSql.Append( " GROUP BY CP09,AK011,A.idx,CP01,CP58,CP56 " );
            strSql.Append( " UNION" );
            strSql.Append( " SELECT A.idx,AH01,CASE WHEN AH18 LIKE '%雕刻%' THEN '雕刻' WHEN AH18 LIKE '%绕锯%' THEN '绕锯' WHEN AH18 LIKE '%夹料%' THEN '夹料' WHEN AH18 LIKE '%砂皮%' THEN '擦砂皮' WHEN AH18 LIKE '%丝印%' THEN '丝印' WHEN AH18 LIKE '%走台印%' THEN '走台印' WHEN AH18 LIKE '%移印%' THEN '移印' WHEN AH18 LIKE '%热转印%' THEN '热转印' WHEN AH18 LIKE '%烫印%' THEN '烫印' WHEN AH18 LIKE '%喷漆%' THEN '喷漆' WHEN AH18 LIKE '%冲压%' THEN '冲压' WHEN AH18 LIKE '%/%' THEN '委外' ELSE '手工剪切、其它' END AH18,CONVERT(DECIMAL(18,2),SUM(AH16*AH101*AH13*AH14-AH17)) AH,ISNULL(AK011,0) AK,ISNULL(AH113,'F') AH113,AH111 FROM R_PQAH A LEFT JOIN R_PQAL B ON A.AH97=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx  AND C.idx IN (" + idxList + ") INNER JOIN R_REVIEWS D ON A.AH97=D.RES06 AND RES05='执行'" );
            strSql.Append( " WHERE AH01 IN (" + numListr + ") AND (AH01!='' AND AH01 IS NOT NULL)" );//   AND LEN(AH01)=8
            strSql.Append( " GROUP BY AH18,AK011,A.idx,AH01,AH113,AH111 " );
            strSql.Append( " UNION " );
            strSql.Append( " SELECT A.idx,IZ002,'夹料' AH,CASE WHEN IZ021=0 THEN 0 ELSE CONVERT(DECIMAL(18,2),(IZ005*IZ022/IZ021)*(IZ013*(IZ014+IZ015)*2*IZ016)) END U0,ISNULL(AK011,0) AK,'','' FROM R_PQIZ A LEFT JOIN R_PQAL B ON A.IZ001=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON C.idx=B.AL001 AND C.idx IN (" + idxList + ") LEFT JOIN R_REVIEWS D ON A.IZ001=D.RES06 AND RES05='执行'" );
            strSql.Append( " WHERE IZ002 IN (" + numListr + ") AND (IZ002!='' AND IZ002 IS NOT NULL)" );
            strSql.Append( " UNION" );
            strSql.Append( " SELECT A.idx,PY01,'喷漆' X,CONVERT(DECIMAL(18,2),(CASE WHEN PY14 = 0 OR PY18 = 0 OR PY21 = 0 THEN 0 WHEN PY14 != 0 AND PY18 != 0 AND PY21 != 0 THEN (PY10*PY11*PY15*PY12*PY20/PY21/PY14/PY18+PY13*PY19*PY16*PY10*PY11/PY14/PY18/PY21/2)*(1+PY17/100) END )+PY23*PY14*PY18*PY11*PY10*PY12*PY15*0.0001) U14,ISNULL(AK011,0) AK,'' X3,'' X4 FROM R_PQY A LEFT JOIN R_PQAL B ON A.PY33=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx" );
            strSql.Append( " AND C.idx IN (" + idxList + ")" );
            strSql.Append( " LEFT JOIN R_REVIEWS D ON A.PY33=D.RES06 AND RES01='R_495' AND RES05='执行'" );
            strSql.Append( " WHERE PY01 IN (" + numListr + ") AND" );
            strSql.Append( " (PY01!='' AND PY01 IS NOT NULL)" );
            strSql.Append( " ) A WHERE AK!=0 GROUP BY CP09,CP01,CP58,CP56 ORDER BY CP01" );
            */

            /*  2017-8-4
            strSql . Append ( "SELECT CP01,CP09 AH18,CASE WHEN CP58='' THEN 'F' ELSE CP58 END CP58,CASE WHEN CP56='' THEN 'F' ELSE CP56 END CP56,SUM(ISNULL(CP,0)) AH,CASE WHEN ISNULL(AK011,0)<SUM(ISNULL(CP,0)) THEN ISNULL(AK011,0) ELSE SUM(ISNULL(CP,0)) END AK,A.AK017 FROM (" );
            strSql . Append ( "SELECT A.idx,CP01,CASE WHEN CP09 LIKE '%雕刻%' THEN '雕刻' WHEN CP09 LIKE '%绕锯%' THEN '绕锯' WHEN CP09 LIKE '%夹料%' THEN '夹料' WHEN CP09 LIKE '%砂皮%' THEN '擦砂皮' WHEN CP09 LIKE '%丝印%' THEN '丝印' WHEN CP09 LIKE '%走台印%' THEN '走台印' WHEN CP09 LIKE '%移印%' THEN '移印' WHEN CP09 LIKE '%热转印%' THEN '热转印' WHEN CP09 LIKE '%烫印%' THEN '烫印' WHEN CP09 LIKE '%喷漆%' THEN '喷漆' WHEN CP09 LIKE '%冲压%' THEN '冲压' WHEN CP09 LIKE '%/%' THEN '委外' ELSE '手工剪切、其它' END CP09,CONVERT(DECIMAL(18,2),CASE WHEN CP10=0 THEN CP13*CP54*CP11-CP12 ELSE CP13*CP54*CP10-CP12 END) CP,ISNULL(CP58,'F') CP58,ISNULL(CP56,'F') CP56,CP03,AK017 FROM R_PQQ A LEFT JOIN R_PQAL B ON A.CP03=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx INNER JOIN R_REVIEWS D ON A.CP03=D.RES06 AND RES05='执行' " );
            strSql . Append ( "WHERE CP01 IN (" + numListr + ")  AND C.idx IN (" + idxList + ") AND (CP01!='' AND CP01 IS NOT NULL) " );
            strSql . Append ( "UNION ALL " );
            strSql . Append ( "SELECT A.idx,AH01,CASE WHEN AH18 LIKE '%雕刻%' THEN '雕刻' WHEN AH18 LIKE '%绕锯%' THEN '绕锯' WHEN AH18 LIKE '%夹料%' THEN '夹料' WHEN AH18 LIKE '%砂皮%' THEN '擦砂皮' WHEN AH18 LIKE '%丝印%' THEN '丝印' WHEN AH18 LIKE '%走台印%' THEN '走台印' WHEN AH18 LIKE '%移印%' THEN '移印' WHEN AH18 LIKE '%热转印%' THEN '热转印' WHEN AH18 LIKE '%烫印%' THEN '烫印' WHEN AH18 LIKE '%喷漆%' THEN '喷漆' WHEN AH18 LIKE '%冲压%' THEN '冲压' WHEN AH18 LIKE '%/%' THEN '委外' ELSE '手工剪切、其它' END AH18,CONVERT(DECIMAL(18,2),AH16*AH101*AH13*AH14-AH17) AH,ISNULL(AH113,'F') AH113,AH111,AH97,AK017 FROM R_PQAH A LEFT JOIN R_PQAL B ON A.AH97=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx INNER JOIN R_REVIEWS D ON A.AH97=D.RES06 AND RES05='执行' " );
            strSql . Append ( "WHERE AH01 IN (" + numListr + ")  AND C.idx IN (" + idxList + ") AND (AH01!='' AND AH01 IS NOT NULL)" );
            strSql . Append ( "UNION ALL " );
            strSql . Append ( "SELECT A.idx,IZ002,'夹料' AH,CASE WHEN IZ021=0 THEN 0 ELSE CONVERT(DECIMAL(18,2),(IZ005*IZ022/IZ021)*(IZ013*(IZ014+IZ015)*2*IZ016)) END U0,'','',IZ001,AK017 FROM R_PQIZ A LEFT JOIN R_PQAL B ON A.IZ001=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON C.idx=B.AL001  LEFT JOIN R_REVIEWS D ON A.IZ001=D.RES06 AND RES05='执行' " );
            strSql . Append ( "WHERE IZ002 IN (" + numListr + ") AND C.idx IN (" + idxList + ") AND (IZ002!='' AND IZ002 IS NOT NULL) " );
            strSql . Append ( "UNION ALL " );
            strSql . Append ( "SELECT A.idx,PY01,'喷漆' X,CONVERT(DECIMAL(18,2),(CASE WHEN PY14 = 0 OR PY18 = 0 OR PY21 = 0 THEN 0 WHEN PY14 != 0 AND PY18 != 0 AND PY21 != 0 THEN (PY10*PY11*PY15*PY12*PY20/PY21/PY14/PY18+PY13*PY19*PY16*PY10*PY11/PY14/PY18/PY21/2)*(1+PY17/100) END )+PY23*PY14*PY18*PY11*PY10*PY12*PY15*0.0001) U14,'' X3,'' X4,PY33,AK017 FROM R_PQY A LEFT JOIN R_PQAL B ON A.PY33=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx LEFT JOIN R_REVIEWS D ON A.PY33=D.RES06 AND RES01='R_495' AND RES05='执行' " );
            strSql . Append ( "WHERE PY01 IN (" + numListr + ") AND C.idx IN (" + idxList + ") AND (PY01!='' AND PY01 IS NOT NULL) " );
            strSql . Append ( ") A LEFT JOIN R_PQAK B ON A.CP03=B.AK003 GROUP BY CP09,CP01,CP58,CP56,ISNULL(AK011,0),A.AK017 ORDER BY CP01" );
            */

            strSql . Append ( "SELECT CP01,CP09 AH18,CASE WHEN CP58='' THEN 'F' ELSE CP58 END CP58,CASE WHEN CP56='' THEN 'F' ELSE CP56 END CP56,SUM(ISNULL(CP,0)) AH,CASE WHEN ISNULL(AK011,0)<SUM(ISNULL(CP,0)) THEN ISNULL(AK011,0) ELSE SUM(ISNULL(CP,0)) END AK,A.AK017 FROM (" );
            strSql . Append ( "SELECT A.idx,CP01,CASE WHEN CP09 LIKE '%雕刻%' THEN '雕刻' WHEN CP09 LIKE '%绕锯%' THEN '绕锯' WHEN CP09 LIKE '%夹料%' THEN '夹料' WHEN CP09 LIKE '%砂皮%' THEN '擦砂皮' WHEN CP09 LIKE '%丝印%' THEN '丝印' WHEN CP09 LIKE '%走台印%' THEN '走台印' WHEN CP09 LIKE '%移印%' THEN '移印' WHEN CP09 LIKE '%热转印%' THEN '热转印' WHEN CP09 LIKE '%烫印%' THEN '烫印' WHEN CP09 LIKE '%喷漆%' THEN '喷漆' WHEN CP09 LIKE '%冲压%' THEN '冲压' WHEN CP09 LIKE '%/%' THEN '委外' ELSE '手工剪切、其它' END CP09,CONVERT(DECIMAL(18,2),CASE WHEN CP10=0 THEN CP13*CP54*CP11-CP12 ELSE CP13*CP54*CP10-CP12 END) CP,ISNULL(CP58,'F') CP58,ISNULL(CP56,'F') CP56,CP03,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQQ A LEFT JOIN R_PQAL B ON A.CP03=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx INNER JOIN R_REVIEWS D ON A.CP03=D.RES06 " );
            strSql . Append ( "WHERE CP01 IN (" + numListr + ")  AND RES05='执行' AND C.idx IN (" + idxList + ") AND (CP01!='' AND CP01 IS NOT NULL) GROUP BY A.idx,CP03,CP01,CP09,CP10,CP13,CP54,CP11,CP12,CP56,CP58,AK017 " );
            strSql . Append ( "UNION ALL " );
            strSql . Append ( "SELECT A.idx,AH01,CASE WHEN AH18 LIKE '%雕刻%' THEN '雕刻' WHEN AH18 LIKE '%绕锯%' THEN '绕锯' WHEN AH18 LIKE '%夹料%' THEN '夹料' WHEN AH18 LIKE '%砂皮%' THEN '擦砂皮' WHEN AH18 LIKE '%丝印%' THEN '丝印' WHEN AH18 LIKE '%走台印%' THEN '走台印' WHEN AH18 LIKE '%移印%' THEN '移印' WHEN AH18 LIKE '%热转印%' THEN '热转印' WHEN AH18 LIKE '%烫印%' THEN '烫印' WHEN AH18 LIKE '%喷漆%' THEN '喷漆' WHEN AH18 LIKE '%冲压%' THEN '冲压' WHEN AH18 LIKE '%/%' THEN '委外' ELSE '手工剪切、其它' END AH18,CONVERT(DECIMAL(18,2),AH16*AH101*AH13*AH14-AH17) AH,ISNULL(AH113,'F') AH113,AH111,AH97,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQAH A LEFT JOIN R_PQAL B ON A.AH97=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx INNER JOIN R_REVIEWS D ON A.AH97=D.RES06 " );
            strSql . Append ( "WHERE AH01 IN (" + numListr + ")  AND RES05='执行' AND C.idx IN (" + idxList + ") AND (AH01!='' AND AH01 IS NOT NULL) GROUP BY A.idx,AH01,AH18,AH16,AH101,AH13,AH14,AH17,AH111,AH113,AH97,AK017 " );
            strSql . Append ( "UNION ALL " );
            strSql . Append ( "SELECT A.idx,IZ002,'夹料' AH,CASE WHEN IZ021=0 THEN 0 ELSE CONVERT(DECIMAL(18,2),(IZ005*IZ022/IZ021)*(IZ013*(IZ014+IZ015)*2*IZ016)) END U0,'','',IZ001,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQIZ A LEFT JOIN R_PQAL B ON A.IZ001=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON C.idx=B.AL001  LEFT JOIN R_REVIEWS D ON A.IZ001=D.RES06 " );
            strSql . Append ( "WHERE IZ002 IN (" + numListr + ") AND RES05='执行' AND C.idx IN (" + idxList + ") AND (IZ002!='' AND IZ002 IS NOT NULL) GROUP BY A.idx,IZ002,IZ021,IZ005,IZ022,IZ021,IZ013,IZ014,IZ015,IZ016,IZ001,AK017 " );
            strSql . Append ( "UNION ALL " );
            strSql . Append ( "SELECT A.idx,PY01,'喷漆' X,CONVERT(DECIMAL(18,2),(CASE WHEN PY14 = 0 OR PY18 = 0 OR PY21 = 0 THEN 0 WHEN PY14 != 0 AND PY18 != 0 AND PY21 != 0 THEN (PY10*PY11*PY15*PY12*PY20/PY21/PY14/PY18+PY13*PY19*PY16*PY10*PY11/PY14/PY18/PY21/2)*(1+PY17/100) END )+PY23*PY14*PY18*PY11*PY10*PY12*PY15*0.0001) U14,'' X3,'' X4,PY33,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQY A LEFT JOIN R_PQAL B ON A.PY33=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx LEFT JOIN R_REVIEWS D ON A.PY33=D.RES06 " );
            strSql . Append ( "WHERE PY01 IN (" + numListr + ")  AND RES01='R_495' AND RES05='执行' AND C.idx IN (" + idxList + ") AND (PY01!='' AND PY01 IS NOT NULL) GROUP BY A.idx,PY01,PY14,PY18,PY21,PY10,PY11,PY12,PY15,PY13,PY16,PY19,PY20,PY17,PY33,PY23,AK017 " );
            strSql . Append ( ") A GROUP BY CP09,CP01,CP58,CP56,ISNULL(AK011,0),A.AK017,CP03 ORDER BY CP01" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public void UpdatePqah ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            strSql.AppendFormat( "AM070='{0}'," ,model.AM070 );
            strSql.AppendFormat( "AM071='{0}'," ,model.AM071 );
            strSql.AppendFormat( "AM072='{0}'," ,model.AM072 );
            strSql.AppendFormat( "AM073='{0}'," ,model.AM073 );
            strSql.AppendFormat( "AM074='{0}'," ,model.AM074 );
            strSql.AppendFormat( "AM075='{0}'," ,model.AM075 );
            strSql.AppendFormat( "AM076='{0}'," ,model.AM076 );
            strSql.AppendFormat( "AM077='{0}'," ,model.AM077 );
            strSql.AppendFormat( "AM078='{0}'," ,model.AM078 );
            strSql.AppendFormat( "AM079='{0}'," ,model.AM079 );
            strSql.AppendFormat( "AM080='{0}'," ,model.AM080 );
            strSql.AppendFormat( "AM081='{0}'," ,model.AM081 );
            strSql.AppendFormat( "AM082='{0}'," ,model.AM082 );
            strSql.AppendFormat( "AM083='{0}'," ,model.AM083 );
            strSql.AppendFormat( "AM084='{0}'," ,model.AM084 );
            strSql.AppendFormat( "AM085='{0}'," ,model.AM085 );
            strSql.AppendFormat( "AM086='{0}'," ,model.AM086 );
            strSql.AppendFormat( "AM087='{0}'," ,model.AM087 );
            strSql.AppendFormat( "AM088='{0}'," ,model.AM088 );
            strSql.AppendFormat( "AM089='{0}'," ,model.AM089 );
            strSql.AppendFormat( "AM090='{0}'," ,model.AM090 );
            strSql.AppendFormat( "AM091='{0}'," ,model.AM091 );
            strSql.AppendFormat( "AM092='{0}'," ,model.AM092 );
            strSql.AppendFormat( "AM093='{0}'" ,model.AM093 );
            //strSql.AppendFormat( "AM108='{0}'," ,model.AM108 );
            //strSql.AppendFormat( "AM109='{0}'," ,model.AM109 );
            //strSql.AppendFormat( "AM110='{0}'," ,model.AM110 );
            //strSql.AppendFormat( "AM111='{0}'," ,model.AM111 );
            //strSql.AppendFormat( "AM112='{0}'," ,model.AM112 );
            //strSql.AppendFormat( "AM113='{0}'," ,model.AM113 );
            //strSql.AppendFormat( "AM115='{0}'," ,model.AM115 );
            //strSql.AppendFormat( "AM116='{0}'" ,model.AM116 );
            strSql.AppendFormat( " WHERE AM002='{0}'" ,model.AM002 );
            SQLString.Add( strSql.ToString( ) );
        }
        public string AddPqah ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            model.AM001 = generateOddNum.purchaseContract( "SELECT MAX(AJ024) AJ024 FROM R_PQAJ" ,"AJ024" ,"R_241-" );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAM (" );
            strSql.Append( "AM002,AM070,AM071,AM072,AM073,AM074,AM075,AM076,AM077,AM078,AM079,AM080,AM081,AM082,AM083,AM084,AM085,AM086,AM087,AM088,AM089,AM090,AM091,AM092,AM093,AM001)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}')" ,model.AM002 ,model.AM070 ,model.AM071 ,model.AM072 ,model.AM073 ,model.AM074 ,model.AM075 ,model.AM076 ,model.AM077 ,model.AM078 ,model.AM079 ,model.AM080 ,model.AM081 ,model.AM082 ,model.AM083 ,model.AM084 ,model.AM085 ,model.AM086 ,model.AM087 ,model.AM088 ,model.AM089 ,model.AM090 ,model.AM091 ,model.AM092 ,model.AM093 ,model.AM001 );

            return strSql.ToString( );
        }
        public bool Pqah ( string idxList ,string numList ,MulaolaoLibrary.ProductCostSummaryLibrary model ,DataTable dk ,ArrayList SQLString )
        {
            dk = GetDataTableTwo( numList ,idxList );
            if ( dk != null && dk.Rows.Count > 0 )
            {
                for ( int m = 0 ; m < dk.Rows.Count ; m++ )
                {
                    model.AM002 = dk.Rows[m]["CP01"].ToString( );

                    model.AM070 = model.AM071 = model.AM072 = model.AM073 = model.AM074 = model.AM075 = model.AM076 = model.AM077 = model.AM078 = model.AM079 = model.AM080 = model.AM081 = model.AM082 = model.AM083 = model.AM084 = model.AM085 = model.AM086 = model.AM087 = model.AM088 = model.AM089 = model.AM090 = model.AM091 = model.AM092 = model.AM093 = model.AM108 = model.AM109 = model.AM111 = model.AM112 = model.AM110 = model.AM113 = model.AM115 = model.AM116 = 0;
                    
                    //model.AM070 = string.IsNullOrEmpty( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and AH18= '雕刻'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and AH18= '雕刻'" ) );
                    model.AM071 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and AH18= '雕刻' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and AH18= '雕刻' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM072 = string.IsNullOrEmpty( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and AH18= '绕锯'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and AH18= '绕锯'" ) );
                    model.AM073 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and AH18= '绕锯' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and AH18= '绕锯' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM074 = string.IsNullOrEmpty( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and AH18= '夹料'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and AH18= '夹料'" ) );
                    model.AM075 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and AH18= '夹料' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and AH18= '夹料' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM076 = string.IsNullOrEmpty( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and AH18= '擦砂皮'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and AH18= '擦砂皮'" ) );
                    model.AM077 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and AH18= '擦砂皮' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and AH18= '擦砂皮' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM078 = string.IsNullOrEmpty( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and AH18= '丝印'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and AH18= '丝印'" ) );
                    model.AM079 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and AH18= '丝印' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and AH18= '丝印' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM080 = string.IsNullOrEmpty( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and AH18= '走台印'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and AH18= '走台印'" ) );
                    model.AM081 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and AH18= '走台印' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and AH18= '走台印' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM082 = string.IsNullOrEmpty( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and AH18= '移印'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and AH18= '移印'" ) );
                    model.AM083 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and AH18= '移印' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and AH18= '移印' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM084 = string.IsNullOrEmpty( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and AH18= '热转印'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and AH18= '热转印'" ) );
                    model.AM085 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and AH18= '热转印' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and AH18= '热转印' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM086 = string.IsNullOrEmpty( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and AH18= '烫印'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and AH18= '烫印'" ) );
                    model.AM087 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and AH18= '烫印' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and AH18= '烫印' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM088 = string.IsNullOrEmpty( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and AH18= '喷漆'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and AH18= '喷漆'" ) );
                    model.AM089 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and AH18= '喷漆' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and AH18= '喷漆' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM090 = string.IsNullOrEmpty( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and AH18= '冲压'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and AH18= '冲压'" ) );
                    model.AM091 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and AH18= '冲压' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and AH18= '冲压' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM092 = string.IsNullOrEmpty( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and AH18= '手工剪切、其它'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and AH18= '手工剪切、其它'" ) );
                    model.AM093 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and AH18= '手工剪切、其它' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and AH18= '手工剪切、其它' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM111 = string.IsNullOrEmpty( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and AH18= '委外' AND CP58='T' AND CP56='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and AH18= '委外' AND CP58='T'  AND CP56='F'" ) );
                    //model.AM112 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and AH18= '委外' AND CP58='T'  AND CP56='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and AH18= '委外' AND CP58='T'  AND CP56='F'" ) );
                    //model.AM108 = string.IsNullOrEmpty( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and AH18= '委外'  AND CP58='F'  AND CP56='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and AH18= '委外'  AND CP58='F'  AND CP56='F'" ) );
                    //model.AM109 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and AH18= '委外' AND CP58='F'  AND CP56='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and AH18= '委外' AND CP58='F'  AND CP56='F'" ) );
                    //model.AM110 = string.IsNullOrEmpty( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and AH18= '委外' AND CP58='F'  AND CP56='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and AH18= '委外' AND CP58='F'  AND CP56='T'" ) );
                    //model.AM113 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and AH18= '委外' AND CP58='F'  AND CP56='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and AH18= '委外' AND CP58='F'  AND CP56='T'" ) );
                    //model.AM115 = string.IsNullOrEmpty( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and AH18= '委外' AND CP58='T'  AND CP56='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AH)" ,"CP01='" + model.AM002 + "' and AH18= '委外' AND CP58='T'  AND CP56='T'" ) );
                    //model.AM116 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and AH18= '委外' AND CP58='T'  AND CP56='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"CP01='" + model.AM002 + "' and AH18= '委外' AND CP58='T'  AND CP56='T'" ) );

                   
                    if ( m == 0 )
                    {
                        ofTwoY( model ,SQLString );
                        if ( ExistsOfCount( model.AM002 ) )
                        {
                            ofTwo( model );
                            UpdatePqah( model ,SQLString );
                        }
                        else
                            SQLString.Add( AddPqah( model ) );
                    }
                    if ( m >= 1 )
                    {
                        if ( model.AM002 != dk.Rows[m - 1]["CP01"].ToString( ) )
                        {
                            ofTwoY( model ,SQLString );
                            if ( ExistsOfCount( model.AM002 ) )
                            {
                                ofTwo( model );
                                UpdatePqah( model ,SQLString );
                            }
                            else
                                SQLString.Add( AddPqah( model ) );
                        }
                    }
                }
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        public DataTable GetDataTableOfTwo ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AM071,AM073,AM075,AM077,AM079,AM081,AM083,AM085,AM087,AM089,AM091,AM093,AM109,AM112,AM113,AM116 FROM R_PQAM" );
            strSql.Append( " WHERE AM002=@AM002" );
            SqlParameter[] parameter = {
                new SqlParameter("@AM002",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        void ofTwo ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            DataTable ofTwo = GetDataTableOfTwo( model.AM002 );
            if ( ofTwo != null && ofTwo.Rows.Count > 0 )
            {
                model.AM071 += string.IsNullOrEmpty( ofTwo.Rows[0]["AM071"].ToString( ) ) == true ? 0 : Convert.ToDecimal( ofTwo.Rows[0]["AM071"].ToString( ) );
                model.AM073 += string.IsNullOrEmpty( ofTwo.Rows[0]["AM073"].ToString( ) ) == true ? 0 : Convert.ToDecimal( ofTwo.Rows[0]["AM073"].ToString( ) );
                model.AM075 += string.IsNullOrEmpty( ofTwo.Rows[0]["AM075"].ToString( ) ) == true ? 0 : Convert.ToDecimal( ofTwo.Rows[0]["AM075"].ToString( ) );
                model.AM077 += string.IsNullOrEmpty( ofTwo.Rows[0]["AM077"].ToString( ) ) == true ? 0 : Convert.ToDecimal( ofTwo.Rows[0]["AM077"].ToString( ) );
                model.AM079 += string.IsNullOrEmpty( ofTwo.Rows[0]["AM079"].ToString( ) ) == true ? 0 : Convert.ToDecimal( ofTwo.Rows[0]["AM079"].ToString( ) );
                model.AM081 += string.IsNullOrEmpty( ofTwo.Rows[0]["AM081"].ToString( ) ) == true ? 0 : Convert.ToDecimal( ofTwo.Rows[0]["AM081"].ToString( ) );
                model.AM083 += string.IsNullOrEmpty( ofTwo.Rows[0]["AM083"].ToString( ) ) == true ? 0 : Convert.ToDecimal( ofTwo.Rows[0]["AM083"].ToString( ) );
                model.AM085 += string.IsNullOrEmpty( ofTwo.Rows[0]["AM085"].ToString( ) ) == true ? 0 : Convert.ToDecimal( ofTwo.Rows[0]["AM085"].ToString( ) );
                model.AM087 += string.IsNullOrEmpty( ofTwo.Rows[0]["AM087"].ToString( ) ) == true ? 0 : Convert.ToDecimal( ofTwo.Rows[0]["AM087"].ToString( ) );
                model.AM089 += string.IsNullOrEmpty( ofTwo.Rows[0]["AM089"].ToString( ) ) == true ? 0 : Convert.ToDecimal( ofTwo.Rows[0]["AM089"].ToString( ) );
                model.AM091 += string.IsNullOrEmpty( ofTwo.Rows[0]["AM091"].ToString( ) ) == true ? 0 : Convert.ToDecimal( ofTwo.Rows[0]["AM091"].ToString( ) );
                model.AM093 += string.IsNullOrEmpty( ofTwo.Rows[0]["AM093"].ToString( ) ) == true ? 0 : Convert.ToDecimal( ofTwo.Rows[0]["AM093"].ToString( ) );
                model.AM109 += string.IsNullOrEmpty( ofTwo.Rows[0]["AM109"].ToString( ) ) == true ? 0 : Convert.ToDecimal( ofTwo.Rows[0]["AM109"].ToString( ) );
                model.AM112 += string.IsNullOrEmpty( ofTwo.Rows[0]["AM112"].ToString( ) ) == true ? 0 : Convert.ToDecimal( ofTwo.Rows[0]["AM112"].ToString( ) );
                model.AM113 += string.IsNullOrEmpty( ofTwo.Rows[0]["AM113"].ToString( ) ) == true ? 0 : Convert.ToDecimal( ofTwo.Rows[0]["AM113"].ToString( ) );
                model.AM116 += string.IsNullOrEmpty( ofTwo.Rows[0]["AM116"].ToString( ) ) == true ? 0 : Convert.ToDecimal( ofTwo.Rows[0]["AM116"].ToString( ) );
            }
        }
        internal DataTable GetDataTableOfTwoY ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT A.CP03,CP01,CONVERT(DECIMAL(18,2),SUM(CASE WHEN CP10=0 THEN CP13*CP54*CP11-CP12 ELSE CP13*CP54*CP10-CP12 END)) CP,ISNULL(CP58,'F') CP58,ISNULL(CP56,'F') CP56,CASE WHEN CP09 LIKE '%雕刻%' THEN '雕刻' WHEN CP09 LIKE '%绕锯%' THEN '绕锯' WHEN CP09 LIKE '%夹料%' THEN '夹料' WHEN CP09 LIKE '%砂皮%' THEN '擦砂皮' WHEN CP09 LIKE '%丝印%' THEN '丝印' WHEN CP09 LIKE '%走台印%' THEN '走台印' WHEN CP09 LIKE '%移印%' THEN '移印' WHEN CP09 LIKE '%热转印%' THEN '热转印' WHEN CP09 LIKE '%烫印%' THEN '烫印' WHEN CP09 LIKE '%喷漆%' THEN '喷漆' WHEN CP09 LIKE '%冲压%' THEN '冲压' WHEN CP09 LIKE '%/%' THEN '委外' ELSE '手工剪切、其它' END CP09 FROM R_PQQ A LEFT JOIN R_REVIEWS D ON A.CP03=D.RES06 AND RES05='执行'" );
            strSql.Append( " WHERE CP01=@CP01" );
            strSql.Append( " GROUP BY A.CP03,CP01,CP58,CP56,CP09" );
            strSql.Append( " UNION" );
            strSql.Append( " SELECT A.AH97,AH01,CONVERT(DECIMAL(18,2),SUM(AH16*AH101*AH13*AH14-AH17)) AH, ISNULL(AH113,'F') AH113,AH111,CASE WHEN AH18 LIKE '%雕刻%' THEN '雕刻' WHEN AH18 LIKE '%绕锯%' THEN '绕锯' WHEN AH18 LIKE '%夹料%' THEN '夹料' WHEN AH18 LIKE '%砂皮%' THEN '擦砂皮' WHEN AH18 LIKE '%丝印%' THEN '丝印' WHEN AH18 LIKE '%走台印%' THEN '走台印' WHEN AH18 LIKE '%移印%' THEN '移印' WHEN AH18 LIKE '%热转印%' THEN '热转印' WHEN AH18 LIKE '%烫印%' THEN '烫印' WHEN AH18 LIKE '%喷漆%' THEN '喷漆' WHEN AH18 LIKE '%冲压%' THEN '冲压' WHEN AH18 LIKE '%/%' THEN '委外' ELSE '手工剪切、其它' END AH18 FROM R_PQAH A LEFT JOIN R_REVIEWS D ON A.AH97=D.RES06 AND RES05='执行'" );
            strSql.Append( " WHERE AH01=@CP01" );
            strSql.Append( "  GROUP BY AH18,A.AH97,AH01,AH113,AH111,AH18" );
            strSql.Append( " UNION" );
            strSql.Append( " SELECT A.IZ001,IZ002,CONVERT(DECIMAL(18,2),SUM(CASE WHEN IZ021=0 THEN 0 ELSE (IZ005*IZ022/IZ021)*(IZ013*(IZ014+IZ015)*2*IZ016) END)) U0,'' X,'' Y,'夹料' AH FROM R_PQIZ A LEFT JOIN R_REVIEWS D ON A.IZ001=D.RES06 AND RES05='执行'" );
            strSql.Append( " WHERE IZ002=@CP01" );
            strSql.Append( " GROUP BY IZ001,IZ002" );
            strSql.Append( " UNION" );
            strSql.Append( " SELECT A.PY33,PY01,CONVERT(DECIMAL(18,2),SUM((CASE WHEN PY14 = 0 OR PY18 = 0 OR PY21 = 0 THEN 0 WHEN PY14 != 0 AND PY18 != 0 AND PY21 != 0 THEN (PY10*PY11*PY15*PY12*PY20/PY21/PY14/PY18+PY13*PY19*PY16*PY10*PY11/PY14/PY18/PY21/2)*(1+PY17/100) END )+PY23*PY14*PY18*PY11*PY10*PY12*PY15*0.0001)) U14,'' X3,'' X4,'喷漆' X  FROM R_PQY A LEFT JOIN R_REVIEWS D ON A.PY33=D.RES06 AND RES01='R_495' AND RES05='执行'" );
            strSql.Append( " WHERE PY01=@CP01" );
            strSql.Append( " GROUP BY PY33,PY01" );
            SqlParameter[] parameter = {
                new SqlParameter("@CP01",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        void ofTwoY ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            DataTable one = GetDataTableOfTwoY( model.AM002 );
            if ( one != null && one.Rows.Count > 0 )
            {
                string oddNum = "";
                for ( int i = 0 ; i < one.Rows.Count ; i++ )
                {
                    oddNum = one.Rows[i]["CP03"].ToString( );
                    model.AM070 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '雕刻' AND CP03='"+oddNum+"'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '雕刻' AND CP03='" + oddNum + "'" ) );
                    model.AM072 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '绕锯' AND CP03='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '绕锯' AND CP03='" + oddNum + "'" ) );
                    model.AM074 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '夹料' AND CP03='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '夹料' AND CP03='" + oddNum + "'" ) );
                    model.AM076 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '擦砂皮' AND CP03='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '擦砂皮' AND CP03='" + oddNum + "'" ) );
                    model.AM078 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '丝印' AND CP03='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '丝印' AND CP03='" + oddNum + "'" ) );
                    model.AM080 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '走台印' AND CP03='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '走台印' AND CP03='" + oddNum + "'" ) );
                    model.AM082 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '移印' AND CP03='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '移印' AND CP03='" + oddNum + "'" ) );
                    model.AM084 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '热转印' AND CP03='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '热转印' AND CP03='" + oddNum + "'" ) );
                    model.AM086 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '烫印' AND CP03='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '烫印' AND CP03='" + oddNum + "'" ) );
                    model.AM088 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '喷漆' AND CP03='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '喷漆' AND CP03='" + oddNum + "'" ) );
                    model.AM090 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '冲压' AND CP03='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '冲压' AND CP03='" + oddNum + "'" ) );
                    model.AM092 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '手工剪切、其它' AND CP03='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '手工剪切、其它' AND CP03='" + oddNum + "'" ) );
                    //model.AM111 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '委外' AND CP58='T' AND CP56='F' AND CP03='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '委外' AND CP58='T'  AND CP56='F' AND CP03='" + oddNum + "'" ) );
                    //model.AM108 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '委外'  AND CP58='F'  AND CP56='F' AND CP03='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '委外'  AND CP58='F'  AND CP56='F' AND CP03='" + oddNum + "'" ) );
                    //model.AM110 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '委外' AND CP58='F'  AND CP56='T' AND CP03='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '委外' AND CP58='F'  AND CP56='T' AND CP03='" + oddNum + "'" ) );
                    //model.AM115 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '委外' AND CP58='T'  AND CP56='T' AND CP03='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '委外' AND CP58='T'  AND CP56='T' AND CP03='" + oddNum + "'" ) );
                    WriteReceivableToGeneralLedger.ByOneByGongXu( model ,oddNum ,SQLString );
                }

                model.AM070 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '雕刻'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '雕刻'" ) );
                model.AM072 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '绕锯'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '绕锯'" ) );
                model.AM074 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '夹料'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '夹料'" ) );
                model.AM076 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '擦砂皮'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '擦砂皮'" ) );
                model.AM078 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '丝印'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '丝印'" ) );
                model.AM080 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '走台印'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '走台印'" ) );
                model.AM082 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '移印'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '移印'" ) );
                model.AM084 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '热转印'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '热转印'" ) );
                model.AM086 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '烫印'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '烫印'" ) );
                model.AM088 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '喷漆'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '喷漆'" ) );
                model.AM090 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '冲压'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '冲压'" ) );
                model.AM092 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '手工剪切、其它'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '手工剪切、其它'" ) );
                model.AM111 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '委外' AND CP58='T' AND CP56='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '委外' AND CP58='T'  AND CP56='F'" ) );
                model.AM108 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '委外'  AND CP58='F'  AND CP56='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '委外'  AND CP58='F'  AND CP56='F'" ) );
                model.AM110 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '委外' AND CP58='F'  AND CP56='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '委外' AND CP58='F'  AND CP56='T'" ) );
                model.AM115 = string.IsNullOrEmpty( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '委外' AND CP58='T'  AND CP56='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(CP)" ,"CP01='" + model.AM002 + "' and CP09= '委外' AND CP58='T'  AND CP56='T'" ) );
            }
        }
        
        /// <summary>
        /// 获取199数据
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqba ( string numListr ,string idxList )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT BA001,BA056,BA058,SUM(BA) BA,SUM(CASE WHEN AK>=BA THEN BA WHEN AK=0 THEN 0 END) AK FROM (" );
            strSql.Append( "SELECT BA001,BA056,BA058,CONVERT(DECIMAL(18,0),SUM(BA011*BA054)) BA,ISNULL(AK011,0) AK FROM R_PQBA A LEFT JOIN R_PQAL B ON A.BA003=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx AND C.idx IN (" + idxList + ") INNER JOIN R_REVIEWS D ON A.BA003=D.RES06 AND RES05='执行'" );
            strSql.Append( " WHERE BA001 IN (" + numListr + ")" );
            strSql.Append( " GROUP BY BA056,BA058,AK011,BA001) A GROUP BY BA056,BA058,BA001 ORDER BY BA001" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取338数据
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqo ( string numList ,string idxList )
        {
            StringBuilder strSql = new StringBuilder( );
            //strSql.Append( "SELECT JM90,JM09,JM93,JM14,JM107,CONVERT( DECIMAL(18,2),SUM(JM)) JM,CONVERT(DECIMAL(18,2),SUM(CASE WHEN AK>=JM THEN JM WHEN AK<JM THEN AK ELSE 0 END)) AK FROM (SELECT A.idx,JM90,CASE WHEN JM09 LIKE '%密度板%' THEN '密度板' WHEN JM09 LIKE '%胶合板%' OR JM09 LIKE '%曲板%' THEN '胶合板' ELSE '胶合板' END JM09,JM93,JM14,CASE WHEN JM107='F' OR JM107 IS NULL THEN 'F' WHEN JM107='T' THEN 'T' END JM107,CASE WHEN JM10 = 0 THEN 0 WHEN JM10 != 0 THEN JM103/JM10* JM11 END JM,ISNULL(AK011,0) AK FROM R_PQO A LEFT JOIN R_PQAL B ON A.JM01=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx AND C.idx IN (" + idxList + ") INNER JOIN R_REVIEWS D ON A.JM01=D.RES06 AND RES05='执行' WHERE JM90!=''" );
            //strSql.Append( " AND JM90 IN (" + numList + ") AND (JM90!='' AND JM90 IS NOT NULL)" );//   AND LEN(JM90)=8
            //strSql.Append( " ) A WHERE AK!=0 GROUP BY JM90,JM09,JM93,JM14,JM107 ORDER BY JM90" );

            /* 2017-8-4
            strSql . Append ( "SELECT JM90,JM09,JM93,JM14,JM107,CONVERT( DECIMAL(18,2),SUM(JM)) JM,CASE WHEN ISNULL(AK011,0)<CONVERT( DECIMAL(18,2),SUM(JM)) THEN ISNULL(AK011,0) ELSE CONVERT( DECIMAL(18,2),SUM(JM)) END AK,A.AK017 FROM (SELECT A.idx,JM90,CASE WHEN JM09 LIKE '%密度板%' THEN '密度板' WHEN JM09 LIKE '%胶合板%' OR JM09 LIKE '%曲板%' THEN '胶合板' ELSE '胶合板' END JM09,JM93,JM14,CASE WHEN JM107='F' OR JM107 IS NULL THEN 'F' WHEN JM107='T' THEN 'T' END JM107,CASE WHEN JM10 = 0 THEN 0 WHEN JM10 != 0 THEN JM103/JM10* JM11 END JM,JM01,AK017 FROM R_PQO A LEFT JOIN R_PQAL B ON A.JM01=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx INNER JOIN R_REVIEWS D ON A.JM01=D.RES06 AND RES05='执行' " );
            strSql . Append ( "WHERE JM90!=''  AND C.idx IN (" + idxList + ") AND JM90 IN (" + numList + ") AND (JM90!='' AND JM90 IS NOT NULL) " );
            strSql . Append ( ") A LEFT JOIN R_PQAK B ON A.JM01=B.AK003 GROUP BY JM90,JM09,JM93,JM14,JM107,ISNULL(AK011,0),A.AK017 ORDER BY JM90" );
            */

            
            strSql . Append ( "SELECT JM90,JM09,JM93,JM14,JM107,CONVERT( DECIMAL(18,2),SUM(JM)) JM,CASE WHEN ISNULL(AK011,0)<CONVERT( DECIMAL(18,2),SUM(JM)) THEN ISNULL(AK011,0) ELSE CONVERT( DECIMAL(18,2),SUM(JM)) END AK,A.AK017 FROM (SELECT A.idx,JM90,CASE WHEN JM09 LIKE '%密度板%' THEN '密度板' WHEN JM09 LIKE '%胶合板%' OR JM09 LIKE '%曲板%' THEN '胶合板' ELSE '胶合板' END JM09,JM93,JM14,CASE WHEN JM107='F' OR JM107 IS NULL THEN 'F' WHEN JM107='T' THEN 'T' END JM107,CASE WHEN JM10 = 0 THEN 0 WHEN JM10 != 0 THEN convert(decimal(11,0),JM103/JM10+isnull(JM118,0))*JM11 END JM,JM01,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQO A LEFT JOIN R_PQAL B ON A.JM01=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx INNER JOIN R_REVIEWS D ON A.JM01=D.RES06 " );
            strSql . Append ( "WHERE JM90!=''  AND C.idx IN (" + idxList + ") AND RES05='执行' AND JM90 IN (" + numList + ") AND (JM90!='' AND JM90 IS NOT NULL) GROUP BY A.idx,JM90,JM09,JM14,JM93,JM107,JM10,JM11,JM01,JM103,AK017,ISNULL(JM118,0) " );
            strSql . Append ( ") A GROUP BY JM90,JM09,JM93,JM14,JM107,ISNULL(AK011,0),A.AK017 ORDER BY JM90" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public void Plywood ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "UPDATE R_PQAM SET " );
            strSql.AppendFormat( "AM296='{0}'," ,model.AM296 );
            strSql.AppendFormat( "AM297='{0}'," ,model.AM297 );
            strSql.AppendFormat( "AM298='{0}'," ,model.AM298 );
            strSql.AppendFormat( "AM299='{0}'," ,model.AM299 );
            strSql.AppendFormat( "AM300='{0}'," ,model.AM300 );
            strSql.AppendFormat( "AM301='{0}'," ,model.AM301 );
            strSql.AppendFormat( "AM302='{0}'," ,model.AM302 );
            strSql.AppendFormat( "AM303='{0}'," ,model.AM303 );
            strSql.AppendFormat( "AM304='{0}'," ,model.AM304 );
            strSql.AppendFormat( "AM305='{0}'," ,model.AM305 );
            strSql.AppendFormat( "AM306='{0}'," ,model.AM306 );
            strSql.AppendFormat( "AM307='{0}'," ,model.AM307 );
            strSql.AppendFormat( "AM308='{0}'," ,model.AM308 );
            strSql.AppendFormat( "AM309='{0}'," ,model.AM309 );
            strSql.AppendFormat( "AM311='{0}'," ,model.AM311 );
            strSql.AppendFormat( "AM312='{0}'," ,model.AM312 );
            strSql.AppendFormat( "AM313='{0}'," ,model.AM313 );
            strSql.AppendFormat( "AM315='{0}'," ,model.AM315 );
            strSql.AppendFormat( "AM316='{0}'," ,model.AM316 );
            strSql.AppendFormat( "AM317='{0}'," ,model.AM317 );
            strSql.AppendFormat( "AM318='{0}'," ,model.AM318 );
            strSql.AppendFormat( "AM319='{0}'," ,model.AM319 );
            strSql.AppendFormat( "AM320='{0}'," ,model.AM320 );
            strSql.AppendFormat( "AM321='{0}'," ,model.AM321 );
            strSql.AppendFormat( "AM322='{0}'," ,model.AM322 );
            strSql.AppendFormat( "AM323='{0}'," ,model.AM323 );
            strSql.AppendFormat( "AM324='{0}'," ,model.AM324 );
            strSql.AppendFormat( "AM325='{0}'," ,model.AM325 );
            strSql.AppendFormat( "AM326='{0}'," ,model.AM326 );
            strSql.AppendFormat( "AM327='{0}'," ,model.AM327 );
            strSql.AppendFormat( "AM328='{0}'," ,model.AM328 );
            strSql.AppendFormat( "AM329='{0}'" ,model.AM329 );
            strSql.AppendFormat( " WHERE AM002='{0}'" ,model.AM002 );
            SQLString.Add( strSql.ToString( ) );
        }
        public string PlyWoodAdd ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            model.AM001 = generateOddNum.purchaseContract( "SELECT MAX(AJ024) AJ024 FROM R_PQAJ" ,"AJ024" ,"R_241-" );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAM (" );
            strSql.Append( "AM002,AM298,AM299,AM300,AM301,AM302,AM303,AM304,AM305,AM306,AM307,AM308,AM309,AM311,AM312,AM313,AM315,AM316,AM317,AM318,AM319,AM320,AM321,AM322,AM323,AM001,AM296,AM297,AM324,AM325,AM326,AM327,AM328,AM329)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}')" ,model.AM002 ,model.AM298 ,model.AM299 ,model.AM300 ,model.AM301 ,model.AM302 ,model.AM303 ,model.AM304 ,model.AM305 ,model.AM306 ,model.AM307 ,model.AM308 ,model.AM309 ,model.AM311 ,model.AM312 ,model.AM313 ,model.AM315 ,model.AM316 ,model.AM317 ,model.AM318 ,model.AM319 ,model.AM320 ,model.AM321 ,model.AM322 ,model.AM323 ,model.AM001 ,model.AM296 ,model.AM297 ,model.AM324 ,model.AM325 ,model.AM326 ,model.AM327 ,model.AM328 ,model.AM329 );

            return strSql.ToString( );
        }
        public bool Pqo ( string idxList ,string numList ,MulaolaoLibrary.ProductCostSummaryLibrary model ,DataTable dk ,ArrayList SQLString )
        {
            dk = GetDataTablePqo( numList ,idxList );
            if ( dk != null && dk.Rows.Count > 0 )
            {
                for ( int m = 0 ; m < dk.Rows.Count ; m++ )
                {
                    model.AM002 = dk.Rows[m]["JM90"].ToString( );

                    model.AM296 = model.AM297 = model.AM298 = model.AM299 = model.AM300 = model.AM301 = model.AM302 = model.AM303 = model.AM304 = model.AM305 = model.AM306 = model.AM307 = model.AM308 = model.AM309 = model.AM311 = model.AM312 = model.AM313 = model.AM315 = model.AM316 = model.AM317 = model.AM318 = model.AM319 = model.AM320 = model.AM321 = model.AM322 = model.AM323 = model.AM324 = model.AM325 = model.AM326 = model.AM327 = model.AM328 = model.AM329 = 0;

                    //model.AM298 = string.IsNullOrEmpty( dk.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='外购' AND JM107='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='外购' AND JM107='F'" ) );
                    model.AM299 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='外购' AND JM107='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='外购' AND JM107='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM300 = string.IsNullOrEmpty( dk.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='外购' AND JM107='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='外购' AND JM107='T'" ) );
                    model.AM303 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='外购' AND JM107='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='外购' AND JM107='T' AND (AK017='执行' OR AK017='审核')" ) );

                    //model.AM307 = string.IsNullOrEmpty( dk.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='外购' AND JM107='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='外购' AND JM107='F'" ) );
                    model.AM308 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='外购' AND JM107='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='外购' AND JM107='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM320 = string.IsNullOrEmpty( dk.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='外购' AND JM107='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='外购' AND JM107='T'" ) );
                    model.AM323 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='外购' AND JM107='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='外购' AND JM107='T' AND (AK017='执行' OR AK017='审核')" ) );

                    //model.AM301 = string.IsNullOrEmpty( dk.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='外购' AND JM107='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='外购' AND JM107='F'" ) );
                    model.AM302 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='外购' AND JM107='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='外购' AND JM107='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM306 = string.IsNullOrEmpty( dk.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='外购' AND JM107='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='外购' AND JM107='T'" ) );
                    model.AM309 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='外购' AND JM107='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='外购' AND JM107='T' AND (AK017='执行' OR AK017='审核')" ) );

                    //model.AM311 = string.IsNullOrEmpty( dk.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='外购' AND JM107='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='外购' AND JM107='F'" ) );
                    model.AM312 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='外购' AND JM107='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='外购' AND JM107='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM324 = string.IsNullOrEmpty( dk.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='外购' AND JM107='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='外购' AND JM107='T'" ) );
                    model.AM325 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='外购' AND JM107='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='外购' AND JM107='T' AND (AK017='执行' OR AK017='审核')" ) );

                    //model.AM304 = string.IsNullOrEmpty( dk.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='库存' AND JM107='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='库存' AND JM107='F'" ) );
                    model.AM305 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='库存' AND JM107='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='库存' AND JM107='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM313 = string.IsNullOrEmpty( dk.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='库存' AND JM107='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='库存' AND JM107='T'" ) );
                    model.AM317 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='库存' AND JM107='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='库存' AND JM107='T' AND (AK017='执行' OR AK017='审核')" ) );

                    //model.AM315 = string.IsNullOrEmpty( dk.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='库存' AND JM107='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='库存' AND JM107='F'" ) );
                    model.AM316 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='库存' AND JM107='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='库存' AND JM107='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM326 = string.IsNullOrEmpty( dk.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='库存' AND JM107='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='库存' AND JM107='T'" ) );
                    model.AM327 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='库存' AND JM107='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='库存' AND JM107='T' AND (AK017='执行' OR AK017='审核')" ) );

                    //model.AM318 = string.IsNullOrEmpty( dk.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='库存' AND JM107='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='库存' AND JM107='F'" ) );
                    model.AM319 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='库存' AND JM107='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='库存' AND JM107='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM328 = string.IsNullOrEmpty( dk.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='库存' AND JM107='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='库存' AND JM107='T'" ) );
                    model.AM329 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='库存' AND JM107='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='库存' AND JM107='T' AND (AK017='执行' OR AK017='审核')" ) );

                    //model.AM321 = string.IsNullOrEmpty( dk.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='库存' AND JM107='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='库存' AND JM107='F'" ) );
                    model.AM322 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='库存' AND JM107='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='库存' AND JM107='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM296 = string.IsNullOrEmpty( dk.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='库存' AND JM107='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='库存' AND JM107='T'" ) );
                    model.AM297 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='库存' AND JM107='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='库存' AND JM107='T' AND (AK017='执行' OR AK017='审核')" ) );

                    
                    if ( m == 0 )
                    {
                        ofTreY( model ,SQLString );
                        if ( ExistsOfCount( model.AM002 ) )
                        {
                            ofTre( model );
                            Plywood( model ,SQLString );
                        }
                        else
                            SQLString.Add( PlyWoodAdd( model ) );
                    }
                    if ( m >= 1 )
                    {
                        if ( model.AM002 != dk.Rows[m - 1]["JM90"].ToString( ) )
                        {
                            ofTreY( model ,SQLString );
                            if ( ExistsOfCount( model.AM002 ) )
                            {
                                ofTre( model );
                                Plywood( model ,SQLString );
                            }
                            else
                                SQLString.Add( PlyWoodAdd( model ) );
                        }
                    }

                }
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        public DataTable GetDataTableOfTre ( string num )
        {
            MulaolaoLibrary.ProductCostSummaryLibrary model = new MulaolaoLibrary.ProductCostSummaryLibrary( );
             
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AM297,AM299,AM302,AM303,AM305,AM308,AM309,AM312,AM316,AM317,AM319,AM322,AM323,AM325,AM327,AM329 FROM R_PQAM" );
            strSql.Append( " WHERE AM002=@AM002" );
            SqlParameter[] parameter = {
                new SqlParameter("@AM002",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        void ofTre ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            DataTable da = GetDataTableOfTre( model.AM002 );
            if ( da != null && da.Rows.Count > 0 )
            {
                model.AM297 += string.IsNullOrEmpty( da.Rows[0]["AM297"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM297"].ToString( ) );
                model.AM299 += string.IsNullOrEmpty( da.Rows[0]["AM299"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM299"].ToString( ) );
                model.AM302 += string.IsNullOrEmpty( da.Rows[0]["AM302"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM302"].ToString( ) );
                model.AM303 += string.IsNullOrEmpty( da.Rows[0]["AM303"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM303"].ToString( ) );
                model.AM305 += string.IsNullOrEmpty( da.Rows[0]["AM305"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM305"].ToString( ) );
                model.AM308 += string.IsNullOrEmpty( da.Rows[0]["AM308"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM308"].ToString( ) );
                model.AM309 += string.IsNullOrEmpty( da.Rows[0]["AM309"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM309"].ToString( ) );
                model.AM312 += string.IsNullOrEmpty( da.Rows[0]["AM312"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM312"].ToString( ) );
                model.AM316 += string.IsNullOrEmpty( da.Rows[0]["AM316"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM316"].ToString( ) );
                model.AM317 += string.IsNullOrEmpty( da.Rows[0]["AM317"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM317"].ToString( ) );
                model.AM319 += string.IsNullOrEmpty( da.Rows[0]["AM319"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM319"].ToString( ) );
                model.AM322 += string.IsNullOrEmpty( da.Rows[0]["AM322"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM322"].ToString( ) );
                model.AM323 += string.IsNullOrEmpty( da.Rows[0]["AM323"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM323"].ToString( ) );
                model.AM325 += string.IsNullOrEmpty( da.Rows[0]["AM325"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM325"].ToString( ) );
                model.AM327 += string.IsNullOrEmpty( da.Rows[0]["AM327"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM327"].ToString( ) );
                model.AM329 += string.IsNullOrEmpty( da.Rows[0]["AM329"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM329"].ToString( ) );
            }
        }
        DataTable GetDataTableOfTreY ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT A.JM01,JM90,CASE WHEN JM09 LIKE '%密度板%' THEN '密度板' WHEN JM09 LIKE '%胶合板%' OR JM09 LIKE '%曲板%' THEN '胶合板' ELSE '胶合板' END JM09,JM93,JM14,CASE WHEN JM107='F' OR JM107 IS NULL THEN 'F' WHEN JM107='T' THEN 'T' END JM107,CONVERT( DECIMAL( 11 ,2 ) ,SUM(CASE WHEN JM10 = 0 THEN 0 WHEN JM10 != 0 THEN JM103 / JM10 * JM11  END )) JM FROM R_PQO A LEFT JOIN R_REVIEWS D ON A.JM01=D.RES06 AND RES05='执行' " );
            strSql.Append( " WHERE JM90=@JM90" );
            strSql.Append( " GROUP BY JM01,JM90,JM09,JM93,JM14,JM107" );
            SqlParameter[] parameter = {
                new SqlParameter("@JM90",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        void ofTreY ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            DataTable one = GetDataTableOfTreY( model.AM002 );
            if ( one != null && one.Rows.Count > 0 )
            {
                string oddNum = "";
                for ( int i = 0 ; i < one.Rows.Count ; i++ )
                {
                    oddNum = one.Rows[i]["JM01"].ToString( );
                    model.AM298 = string.IsNullOrEmpty( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='外购' AND JM107='F' AND JM01='"+oddNum+"'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='外购' AND JM107='F' AND JM01='" + oddNum + "'" ) );
                    model.AM300 = string.IsNullOrEmpty( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='外购' AND JM107='T' AND JM01='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='外购' AND JM107='T' AND JM01='" + oddNum + "'" ) );

                    model.AM307 = string.IsNullOrEmpty( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='外购' AND JM107='F' AND JM01='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='外购' AND JM107='F' AND JM01='" + oddNum + "'" ) );
                    model.AM320 = string.IsNullOrEmpty( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='外购' AND JM107='T' AND JM01='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='外购' AND JM107='T' AND JM01='" + oddNum + "'" ) );

                    model.AM301 = string.IsNullOrEmpty( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='外购' AND JM107='F' AND JM01='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='外购' AND JM107='F' AND JM01='" + oddNum + "'" ) );
                    model.AM306 = string.IsNullOrEmpty( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='外购' AND JM107='T' AND JM01='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='外购' AND JM107='T' AND JM01='" + oddNum + "'" ) );

                    model.AM311 = string.IsNullOrEmpty( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='外购' AND JM107='F' AND JM01='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='外购' AND JM107='F' AND JM01='" + oddNum + "'" ) );
                    model.AM324 = string.IsNullOrEmpty( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='外购' AND JM107='T' AND JM01='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='外购' AND JM107='T' AND JM01='" + oddNum + "'" ) );

                    model.AM304 = string.IsNullOrEmpty( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='库存' AND JM107='F' AND JM01='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='库存' AND JM107='F' AND JM01='" + oddNum + "'" ) );
                    model.AM313 = string.IsNullOrEmpty( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='库存' AND JM107='T' AND JM01='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='库存' AND JM107='T' AND JM01='" + oddNum + "'" ) );

                    model.AM315 = string.IsNullOrEmpty( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='库存' AND JM107='F' AND JM01='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='库存' AND JM107='F' AND JM01='" + oddNum + "'" ) );
                    model.AM326 = string.IsNullOrEmpty( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='库存' AND JM107='T' AND JM01='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='库存' AND JM107='T' AND JM01='" + oddNum + "'" ) );

                    model.AM318 = string.IsNullOrEmpty( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='库存' AND JM107='F' AND JM01='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='库存' AND JM107='F' AND JM01='" + oddNum + "'" ) );
                    model.AM328 = string.IsNullOrEmpty( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='库存' AND JM107='T' AND JM01='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='库存' AND JM107='T' AND JM01='" + oddNum + "'" ) );

                    model.AM321 = string.IsNullOrEmpty( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='库存' AND JM107='F' AND JM01='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='库存' AND JM107='F' AND JM01='" + oddNum + "'" ) );
                    model.AM296 = string.IsNullOrEmpty( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='库存' AND JM107='T' AND JM01='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='库存' AND JM107='T' AND JM01='" + oddNum + "'" ) );
                    WriteReceivableToGeneralLedger.ByOneByJiao( model ,oddNum ,SQLString );
                }
                model.AM298 = string.IsNullOrEmpty( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='外购' AND JM107='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='外购' AND JM107='F'" ) );
                model.AM300 = string.IsNullOrEmpty( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='外购' AND JM107='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='外购' AND JM107='T'" ) );

                model.AM307 = string.IsNullOrEmpty( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='外购' AND JM107='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='外购' AND JM107='F'" ) );
                model.AM320 = string.IsNullOrEmpty( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='外购' AND JM107='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='外购' AND JM107='T'" ) );

                model.AM301 = string.IsNullOrEmpty( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='外购' AND JM107='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='外购' AND JM107='F'" ) );
                model.AM306 = string.IsNullOrEmpty( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='外购' AND JM107='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='外购' AND JM107='T'" ) );

                model.AM311 = string.IsNullOrEmpty( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='外购' AND JM107='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='外购' AND JM107='F'" ) );
                model.AM324 = string.IsNullOrEmpty( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='外购' AND JM107='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='外购' AND JM107='T'" ) );

                model.AM304 = string.IsNullOrEmpty( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='库存' AND JM107='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='库存' AND JM107='F'" ) );
                model.AM313 = string.IsNullOrEmpty( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='库存' AND JM107='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='库存' AND JM107='T'" ) );

                model.AM315 = string.IsNullOrEmpty( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='库存' AND JM107='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='库存' AND JM107='F'" ) );
                model.AM326 = string.IsNullOrEmpty( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='库存' AND JM107='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='库存' AND JM107='T'" ) );

                model.AM318 = string.IsNullOrEmpty( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='库存' AND JM107='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='库存' AND JM107='F'" ) );
                model.AM328 = string.IsNullOrEmpty( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='库存' AND JM107='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='库存' AND JM107='T'" ) );

                model.AM321 = string.IsNullOrEmpty( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='库存' AND JM107='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='库存' AND JM107='F'" ) );
                model.AM296 = string.IsNullOrEmpty( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='库存' AND JM107='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(JM)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='库存' AND JM107='T'" ) );
            }
        }

        /// <summary>
        /// 339
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqi ( string numListr ,string idxList )
        {
            StringBuilder strSql = new StringBuilder( );
            //strSql.Append( "SELECT YQ03,YQ12,YQ101,YQ123,CONVERT(DECIMAL(18,2),SUM(YQ)) YQ,CONVERT(DECIMAL(18,2),SUM(CASE WHEN AK>=YQ THEN YQ WHEN AK<YQ THEN AK ELSE 0 END )) AK FROM (SELECT A.idx,YQ03,CASE WHEN YQ12 LIKE '%硝基漆%' THEN '硝基漆' WHEN YQ12 LIKE '%香蕉水%' THEN '香蕉水' ELSE CASE WHEN YQ33='T' OR YQ35='T' THEN '水性漆一类' ELSE '水性漆二类' END END YQ12,YQ101,CASE WHEN YQ123='T' THEN 'T' ELSE 'F' END YQ123,SUM(CASE WHEN YQ114=0 OR YQ115=0 THEN 0 WHEN YQ114!=0 AND YQ115!=0 THEN YQ108*YQ112*YQ113*YQ116*YQ13*YQ14*0.01/YQ114/YQ115 + YQ13*YQ16*YQ108*YQ112*YQ113*YQ114*YQ115*YQ116*0.000001 END) YQ,ISNULL(AK011,0) AK FROM R_PQI A LEFT JOIN R_PQAL B ON A.YQ99=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx  AND C.idx IN (" + idxList + ") INNER JOIN R_REVIEWS D ON A.YQ99=D.RES06 AND RES05='执行'" );
            //strSql.Append( " WHERE YQ03 IN (" + numListr + ") AND (YQ03!='' AND YQ03 IS NOT NULL)" );//  AND LEN(YQ03)=8
            //strSql.Append( " GROUP BY YQ03,YQ12,YQ101,YQ123,YQ33,YQ35,A.idx,AK011 ) A WHERE AK!=0 GROUP BY YQ03,YQ12,YQ12,YQ101,YQ123 ORDER BY YQ03" );

            /*
            strSql . Append ( "SELECT YQ03,YQ12,YQ101,YQ123,CONVERT(DECIMAL(18,2),SUM(YQ)) YQ,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(YQ)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(YQ)) END AK,A.AK017 FROM (SELECT A.idx,YQ03,CASE WHEN YQ12 LIKE '%硝基漆%' THEN '硝基漆' WHEN YQ12 LIKE '%香蕉水%' THEN '香蕉水' ELSE CASE WHEN YQ33='T' OR YQ35='T' THEN '水性漆一类' ELSE '水性漆二类' END END YQ12,YQ101,CASE WHEN YQ123='T' THEN 'T' ELSE 'F' END YQ123,CASE WHEN YQ114=0 OR YQ115=0 THEN 0 WHEN YQ114!=0 AND YQ115!=0 THEN YQ108*YQ112*YQ113*YQ116*YQ13*YQ14*0.01/YQ114/YQ115 + YQ13*YQ16*YQ108*YQ112*YQ113*YQ114*YQ115*YQ116*0.000001 END YQ,YQ99,AK017 FROM R_PQI A LEFT JOIN R_PQAL B ON A.YQ99=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx INNER JOIN R_REVIEWS D ON A.YQ99=D.RES06 AND RES05='执行' " );
            strSql . Append ( "WHERE YQ03 IN (" + numListr + ")  AND C.idx IN (" + idxList + ") AND (YQ03!='' AND YQ03 IS NOT NULL) " );
            strSql . Append ( ") A LEFT JOIN R_PQAK B ON A.YQ99=B.AK003 GROUP BY YQ03,YQ12,YQ12,YQ101,YQ123,ISNULL(AK011,0),A.AK017 ORDER BY YQ03" );
            */


            strSql . Append ( "SELECT YQ03,YQ12,YQ101,YQ123,CONVERT(DECIMAL(18,2),SUM(YQ)) YQ,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(YQ)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(YQ)) END AK,A.AK017 FROM (SELECT A.idx,YQ03,CASE WHEN YQ12 LIKE '%硝基漆%' THEN '硝基漆' WHEN YQ12 LIKE '%香蕉水%' THEN '香蕉水' ELSE CASE WHEN YQ33='T' OR YQ35='T' THEN '水性漆一类' ELSE '水性漆二类' END END YQ12,YQ101,CASE WHEN YQ123='T' THEN 'T' ELSE 'F' END YQ123,CASE WHEN YQ114=0 OR YQ115=0 THEN 0 WHEN YQ114!=0 AND YQ115!=0 THEN YQ108*YQ112*YQ113*YQ116*YQ13*YQ14*0.01/YQ114/YQ115 + YQ13*YQ16*YQ108*YQ112*YQ113*YQ114*YQ115*YQ116*0.000001 END YQ,YQ99,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQI A LEFT JOIN R_PQAL B ON A.YQ99=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx INNER JOIN R_REVIEWS D ON A.YQ99=D.RES06 " );
            strSql . Append ( "WHERE YQ03 IN (" + numListr + ")  AND RES05='执行' AND C.idx IN (" + idxList + ") AND (YQ03!='' AND YQ03 IS NOT NULL) GROUP BY A.idx,YQ03,YQ12,YQ33,YQ35,YQ101,YQ123,YQ114,YQ115,YQ108,YQ112,YQ113,YQ116,YQ13,YQ14,YQ16,YQ99,AK017 " );
            strSql . Append ( ") A GROUP BY YQ03,YQ12,YQ12,YQ101,YQ123,ISNULL(AK011,0),A.AK017 ORDER BY YQ03" );


            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public void Paint ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            strSql.AppendFormat( "AM175='{0}'," ,model.AM175 );
            strSql.AppendFormat( "AM176='{0}'," ,model.AM176 );
            strSql.AppendFormat( "AM177='{0}'," ,model.AM177 );
            strSql.AppendFormat( "AM178='{0}'," ,model.AM178 );
            strSql.AppendFormat( "AM179='{0}'," ,model.AM179 );
            strSql.AppendFormat( "AM180='{0}'," ,model.AM180 );
            strSql.AppendFormat( "AM182='{0}'," ,model.AM182 );
            strSql.AppendFormat( "AM183='{0}'," ,model.AM183 );
            strSql.AppendFormat( "AM184='{0}'," ,model.AM184 );
            strSql.AppendFormat( "AM185='{0}'," ,model.AM185 );
            strSql.AppendFormat( "AM186='{0}'," ,model.AM186 );
            strSql.AppendFormat( "AM187='{0}'," ,model.AM187 );
            strSql.AppendFormat( "AM188='{0}'," ,model.AM188 );
            strSql.AppendFormat( "AM189='{0}'," ,model.AM189 );
            strSql.AppendFormat( "AM190='{0}'," ,model.AM190 );
            strSql.AppendFormat( "AM191='{0}'," ,model.AM191 );
            strSql.AppendFormat( "AM192='{0}'," ,model.AM192 );
            strSql.AppendFormat( "AM193='{0}'," ,model.AM193 );
            strSql.AppendFormat( "AM194='{0}'," ,model.AM194 );
            strSql.AppendFormat( "AM195='{0}'," ,model.AM195 );
            strSql.AppendFormat( "AM196='{0}'," ,model.AM196 );
            strSql.AppendFormat( "AM197='{0}'," ,model.AM197 );
            strSql.AppendFormat( "AM198='{0}'," ,model.AM198 );
            strSql.AppendFormat( "AM199='{0}'," ,model.AM199 );
            strSql.AppendFormat( "AM200='{0}'," ,model.AM200 );
            strSql.AppendFormat( "AM201='{0}'," ,model.AM201 );
            strSql.AppendFormat( "AM203='{0}'," ,model.AM203 );
            strSql.AppendFormat( "AM204='{0}'," ,model.AM204 );
            strSql.AppendFormat( "AM205='{0}'," ,model.AM205 );
            strSql.AppendFormat( "AM206='{0}'," ,model.AM206 );
            strSql.AppendFormat( "AM207='{0}'," ,model.AM207 );
            strSql.AppendFormat( "AM208='{0}'" ,model.AM208 );
            strSql.AppendFormat( " WHERE AM002='{0}'" ,model.AM002 );
            SQLString.Add( strSql.ToString( ) );
        }
        public string PaintAdd ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            model.AM001 = generateOddNum.purchaseContract( "SELECT MAX(AJ024) AJ024 FROM R_PQAJ" ,"AJ024" ,"R_241-" );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO  R_PQAM (" );
            strSql.Append( "AM002,AM175,AM176,AM177,AM178,AM179,AM180,AM182,AM183,AM184,AM185,AM186,AM187,AM188,AM189,AM190,AM191,AM192,AM193,AM194,AM195,AM196,AM197,AM198,AM199,AM001,AM200,AM201,AM203,AM204,AM205,AM206,AM207,AM208)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}')" ,model.AM002 ,model.AM175 ,model.AM176 ,model.AM177 ,model.AM178 ,model.AM179 ,model.AM180 ,model.AM182 ,model.AM183 ,model.AM184 ,model.AM185 ,model.AM186 ,model.AM187 ,model.AM188 ,model.AM189 ,model.AM190 ,model.AM191 ,model.AM192 ,model.AM193 ,model.AM194 ,model.AM195 ,model.AM196 ,model.AM197 ,model.AM198 ,model.AM199 ,model.AM001 ,model.AM200 ,model.AM201 ,model.AM203 ,model.AM204 ,model.AM205 ,model.AM206 ,model.AM207 ,model.AM208 );

            return strSql.ToString( );
        }
        public bool Pqi ( string idxList ,string numList ,MulaolaoLibrary.ProductCostSummaryLibrary model ,DataTable dk ,ArrayList SQLString )
        {
            dk = GetDataTablePqi( numList ,idxList );
            if ( dk != null && dk.Rows.Count > 0 )
            {
                for ( int m = 0 ; m < dk.Rows.Count ; m++ )
                {
                    model.AM002 = dk.Rows[m]["YQ03"].ToString( );

                    model.AM175 = model.AM176 = model.AM178 = model.AM179 = model.AM182 = model.AM183 = model.AM185 = model.AM186 = model.AM188 = model.AM189 = model.AM191 = model.AM192 = model.AM194 = model.AM195 = model.AM197 = model.AM198 = model.AM177 = model.AM180 = model.AM184 = model.AM187 = model.AM190 = model.AM193 = model.AM196 = model.AM199 =model.AM200=model.AM201=model.AM203=model.AM204=model.AM205=model.AM206=model.AM207=model.AM208= 0;

                    //model.AM175 = string.IsNullOrEmpty( dk.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆一类' and YQ101='外购'AND YQ123='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆一类' and YQ101='外购' AND YQ123='F'" ) );
                    model.AM176 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆一类' and YQ101='外购' AND YQ123='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆一类' and YQ101='外购' AND YQ123='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM177 = string.IsNullOrEmpty( dk.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆一类' and YQ101='外购' AND YQ123='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆一类' and YQ101='外购' AND YQ123='T'" ) );
                    model.AM180 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆一类' and YQ101='外购' AND YQ123='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆一类' and YQ101='外购' AND YQ123='T' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM188 = string.IsNullOrEmpty( dk.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆一类' and YQ101='库存' AND YQ123='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆一类' and YQ101='库存' AND YQ123='F'" ) );
                    model.AM189 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆一类' and YQ101='库存' AND YQ123='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆一类' and YQ101='库存' AND YQ123='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM200 = string.IsNullOrEmpty( dk.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆一类' and YQ101='库存' AND YQ123='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆一类' and YQ101='库存' AND YQ123='T'" ) );
                    model.AM201 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆一类' and YQ101='库存' AND YQ123='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆一类' and YQ101='库存' AND YQ123='T' AND (AK017='执行' OR AK017='审核')" ) );


                    //model.AM178 = string.IsNullOrEmpty( dk.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆二类' and YQ101='外购'  AND YQ123='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆二类' and YQ101='外购'  AND YQ123='F'" ) );
                    model.AM179 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆二类' and YQ101='外购' AND YQ123='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆二类' and YQ101='外购' AND YQ123='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM184 = string.IsNullOrEmpty( dk.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆二类' and YQ101='外购' AND YQ123='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆二类' and YQ101='外购' AND YQ123='T'" ) );
                    model.AM187 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆二类' and YQ101='外购' AND YQ123='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆二类' and YQ101='外购' AND YQ123='T' AND (AK017='执行' OR AK017='审核')" ) );

                    //model.AM191 = string.IsNullOrEmpty( dk.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆二类' and YQ101='库存' AND YQ123='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆二类' and YQ101='库存' AND YQ123='F'" ) );
                    model.AM192 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆二类' and YQ101='库存' AND YQ123='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆二类' and YQ101='库存' AND YQ123='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM203 = string.IsNullOrEmpty( dk.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆二类' and YQ101='库存' AND YQ123='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆二类' and YQ101='库存' AND YQ123='T'" ) );
                    model.AM204 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆二类' and YQ101='库存' AND YQ123='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆二类' and YQ101='库存' AND YQ123='T' AND (AK017='执行' OR AK017='审核')" ) );

                    //model.AM182 = string.IsNullOrEmpty( dk.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '硝基漆' and YQ101='外购' AND YQ123='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '硝基漆' and YQ101='外购' AND YQ123='F'" ) );
                    model.AM183 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"YQ03='" + model.AM002 + "' and YQ12= '硝基漆' and YQ101='外购' AND YQ123='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"YQ03='" + model.AM002 + "' and YQ12= '硝基漆' and YQ101='外购' AND YQ123='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM190 = string.IsNullOrEmpty( dk.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '硝基漆' and YQ101='外购' AND YQ123='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '硝基漆' and YQ101='外购' AND YQ123='T'" ) );
                    model.AM193 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"YQ03='" + model.AM002 + "' and YQ12= '硝基漆' and YQ101='外购' AND YQ123='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"YQ03='" + model.AM002 + "' and YQ12= '硝基漆' and YQ101='外购' AND YQ123='T' AND (AK017='执行' OR AK017='审核')" ) );

                    //model.AM194 = string.IsNullOrEmpty( dk.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '硝基漆' and YQ101='库存' AND YQ123='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '硝基漆' and YQ101='库存' AND YQ123='F'" ) );
                    model.AM195 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"YQ03='" + model.AM002 + "' and YQ12= '硝基漆' and YQ101='库存' AND YQ123='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"YQ03='" + model.AM002 + "' and YQ12= '硝基漆' and YQ101='库存' AND YQ123='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM205 = string.IsNullOrEmpty( dk.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '硝基漆' and YQ101='库存' AND YQ123='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '硝基漆' and YQ101='库存' AND YQ123='T'" ) );
                    model.AM206 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"YQ03='" + model.AM002 + "' and YQ12= '硝基漆' and YQ101='库存' AND YQ123='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"YQ03='" + model.AM002 + "' and YQ12= '硝基漆' and YQ101='库存' AND YQ123='T' AND (AK017='执行' OR AK017='审核')" ) );


                    //model.AM185 = string.IsNullOrEmpty( dk.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '香蕉水' and YQ101='外购' AND YQ123='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '香蕉水' and YQ101='外购' AND YQ123='F'" ) );
                    model.AM186 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"YQ03='" + model.AM002 + "' and YQ12= '香蕉水' and YQ101='外购' AND YQ123='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"YQ03='" + model.AM002 + "' and YQ12= '香蕉水' and YQ101='外购' AND YQ123='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM196 = string.IsNullOrEmpty( dk.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '香蕉水' and YQ101='外购' AND YQ123='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '香蕉水' and YQ101='外购' AND YQ123='T'" ) );
                    model.AM199 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"YQ03='" + model.AM002 + "' and YQ12= '香蕉水' and YQ101='外购' AND YQ123='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"YQ03='" + model.AM002 + "' and YQ12= '香蕉水' and YQ101='外购' AND YQ123='T' AND (AK017='执行' OR AK017='审核')" ) );

                    //model.AM197 = string.IsNullOrEmpty( dk.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '香蕉水' and YQ101='库存' AND YQ123='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '香蕉水' and YQ101='库存' AND YQ123='F'" ) );
                    model.AM198 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"YQ03='" + model.AM002 + "' and YQ12= '香蕉水' and YQ101='库存' AND YQ123='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"YQ03='" + model.AM002 + "' and YQ12= '香蕉水' and YQ101='库存' AND YQ123='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM207 = string.IsNullOrEmpty( dk.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '香蕉水' and YQ101='库存' AND YQ123='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '香蕉水' and YQ101='库存' AND YQ123='T'" ) );
                    model.AM208 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"YQ03='" + model.AM002 + "' and YQ12= '香蕉水' and YQ101='库存' AND YQ123='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"YQ03='" + model.AM002 + "' and YQ12= '香蕉水' and YQ101='库存' AND YQ123='T' AND (AK017='执行' OR AK017='审核')" ) );

                    
                    if ( m == 0 )
                    {
                        ofForY( model ,SQLString );
                        if ( ExistsOfCount( model.AM002 ) )
                        {
                            ofFor( model );
                            Paint( model ,SQLString );
                        }
                        else
                            SQLString.Add( PaintAdd( model ) );
                    }
                    if ( m >= 1 )
                    {
                        if ( model.AM002 != dk.Rows[m - 1]["YQ03"].ToString( ) )
                        {
                            ofForY( model ,SQLString );
                            if ( ExistsOfCount( model.AM002 ) )
                            {
                                ofFor( model );
                                Paint( model ,SQLString );
                            }
                            else
                                SQLString.Add( PaintAdd( model ) );
                        }
                    }
                }
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        DataTable GetDataTableOfFor ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AM176,AM179,AM180,AM183,AM186,AM187,AM189,AM192,AM193,AM195,AM198,AM199,AM201,AM204,AM206,AM208 FROM R_PQAM" );
            strSql.Append( " WHERE AM002=@AM002" );
            SqlParameter[] parameter = {
                new SqlParameter("@AM002",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        void ofFor ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            DataTable da = GetDataTableOfFor( model.AM002 );
            if ( da != null && da.Rows.Count > 0 )
            {
                model.AM176 += string.IsNullOrEmpty( da.Rows[0]["AM176"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM176"].ToString( ) );
                model.AM179 += string.IsNullOrEmpty( da.Rows[0]["AM179"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM179"].ToString( ) );
                model.AM180 += string.IsNullOrEmpty( da.Rows[0]["AM180"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM180"].ToString( ) );
                model.AM183 += string.IsNullOrEmpty( da.Rows[0]["AM183"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM183"].ToString( ) );
                model.AM186 += string.IsNullOrEmpty( da.Rows[0]["AM186"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM186"].ToString( ) );
                model.AM187 += string.IsNullOrEmpty( da.Rows[0]["AM187"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM187"].ToString( ) );
                model.AM189 += string.IsNullOrEmpty( da.Rows[0]["AM189"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM189"].ToString( ) );
                model.AM192 += string.IsNullOrEmpty( da.Rows[0]["AM192"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM192"].ToString( ) );
                model.AM193 += string.IsNullOrEmpty( da.Rows[0]["AM193"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM193"].ToString( ) );
                model.AM195 += string.IsNullOrEmpty( da.Rows[0]["AM195"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM195"].ToString( ) );
                model.AM198 += string.IsNullOrEmpty( da.Rows[0]["AM198"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM198"].ToString( ) );
                model.AM199 += string.IsNullOrEmpty( da.Rows[0]["AM199"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM199"].ToString( ) );
                model.AM201 += string.IsNullOrEmpty( da.Rows[0]["AM201"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM201"].ToString( ) );
                model.AM204 += string.IsNullOrEmpty( da.Rows[0]["AM204"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM204"].ToString( ) );
                model.AM206 += string.IsNullOrEmpty( da.Rows[0]["AM206"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM206"].ToString( ) );
                model.AM208 += string.IsNullOrEmpty( da.Rows[0]["AM208"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM208"].ToString( ) );
            }
        }
        DataTable GetDatatableOfForY ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT A.YQ99,YQ03,CASE WHEN YQ12 LIKE '%硝基漆%' THEN '硝基漆' WHEN YQ12 LIKE '%香蕉水%' THEN '香蕉水' ELSE CASE WHEN YQ33='T' OR YQ35='T' THEN '水性漆一类' ELSE '水性漆二类' END END YQ12,YQ101,CASE WHEN YQ123='T' THEN 'T' ELSE 'F' END YQ123,CONVERT(DECIMAL(18,2),SUM(CASE WHEN YQ114=0 OR YQ115=0 THEN 0 WHEN YQ114!=0 AND YQ115!=0 THEN YQ108*YQ112*YQ113*YQ116*YQ13*YQ14*0.01/YQ114/YQ115 + YQ13*YQ16*YQ108*YQ112*YQ113*YQ114*YQ115*YQ116*0.000001 END)) YQ FROM R_PQI A LEFT JOIN R_REVIEWS D ON A.YQ99=D.RES06 AND RES05='执行'" );
            strSql.Append( " WHERE YQ03=@YQ03" );
            strSql.Append( " GROUP BY YQ03,YQ12,YQ101,YQ123,YQ33,YQ35,A.YQ99" );
            SqlParameter[] parameter = {
                new SqlParameter("@YQ03",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        void ofForY ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            DataTable one = GetDatatableOfForY( model.AM002 );
            if ( one != null && one.Rows.Count > 0 )
            {
                string oddNum = "";
                for ( int i = 0 ; i < one.Rows.Count ; i++ )
                {
                    oddNum = one.Rows[i]["YQ99"].ToString( );
                    model.AM175 = string.IsNullOrEmpty( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆一类' and YQ101='外购'AND YQ123='F' AND YQ99='"+oddNum+"'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆一类' and YQ101='外购' AND YQ123='F' AND YQ99='" + oddNum + "'" ) );
                    model.AM177 = string.IsNullOrEmpty( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆一类' and YQ101='外购' AND YQ123='T' AND YQ99='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆一类' and YQ101='外购' AND YQ123='T' AND YQ99='" + oddNum + "'" ) );
                    model.AM188 = string.IsNullOrEmpty( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆一类' and YQ101='库存' AND YQ123='F' AND YQ99='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆一类' and YQ101='库存' AND YQ123='F' AND YQ99='" + oddNum + "'" ) );
                    model.AM200 = string.IsNullOrEmpty( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆一类' and YQ101='库存' AND YQ123='T' AND YQ99='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆一类' and YQ101='库存' AND YQ123='T' AND YQ99='" + oddNum + "'" ) );


                    model.AM178 = string.IsNullOrEmpty( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆二类' and YQ101='外购'  AND YQ123='F' AND YQ99='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆二类' and YQ101='外购'  AND YQ123='F' AND YQ99='" + oddNum + "'" ) );
                    model.AM184 = string.IsNullOrEmpty( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆二类' and YQ101='外购' AND YQ123='T' AND YQ99='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆二类' and YQ101='外购' AND YQ123='T' AND YQ99='" + oddNum + "'" ) );

                    model.AM191 = string.IsNullOrEmpty( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆二类' and YQ101='库存' AND YQ123='F' AND YQ99='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆二类' and YQ101='库存' AND YQ123='F' AND YQ99='" + oddNum + "'" ) );
                    model.AM203 = string.IsNullOrEmpty( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆二类' and YQ101='库存' AND YQ123='T' AND YQ99='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆二类' and YQ101='库存' AND YQ123='T' AND YQ99='" + oddNum + "'" ) );

                    model.AM182 = string.IsNullOrEmpty( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '硝基漆' and YQ101='外购' AND YQ123='F' AND YQ99='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '硝基漆' and YQ101='外购' AND YQ123='F' AND YQ99='" + oddNum + "'" ) );
                    model.AM190 = string.IsNullOrEmpty( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '硝基漆' and YQ101='外购' AND YQ123='T' AND YQ99='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '硝基漆' and YQ101='外购' AND YQ123='T' AND YQ99='" + oddNum + "'" ) );

                    model.AM194 = string.IsNullOrEmpty( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '硝基漆' and YQ101='库存' AND YQ123='F' AND YQ99='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '硝基漆' and YQ101='库存' AND YQ123='F' AND YQ99='" + oddNum + "'" ) );
                    model.AM205 = string.IsNullOrEmpty( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '硝基漆' and YQ101='库存' AND YQ123='T' AND YQ99='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '硝基漆' and YQ101='库存' AND YQ123='T' AND YQ99='" + oddNum + "'" ) );


                    model.AM185 = string.IsNullOrEmpty( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '香蕉水' and YQ101='外购' AND YQ123='F' AND YQ99='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '香蕉水' and YQ101='外购' AND YQ123='F' AND YQ99='" + oddNum + "'" ) );
                    model.AM196 = string.IsNullOrEmpty( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '香蕉水' and YQ101='外购' AND YQ123='T' AND YQ99='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '香蕉水' and YQ101='外购' AND YQ123='T' AND YQ99='" + oddNum + "'" ) );

                    model.AM197 = string.IsNullOrEmpty( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '香蕉水' and YQ101='库存' AND YQ123='F' AND YQ99='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '香蕉水' and YQ101='库存' AND YQ123='F' AND YQ99='" + oddNum + "'" ) );
                    model.AM207 = string.IsNullOrEmpty( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '香蕉水' and YQ101='库存' AND YQ123='T' AND YQ99='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '香蕉水' and YQ101='库存' AND YQ123='T' AND YQ99='" + oddNum + "'" ) );
                    WriteReceivableToGeneralLedger.ByOneByYouQi( model ,oddNum ,SQLString );
                }
                model.AM175 = string.IsNullOrEmpty( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆一类' and YQ101='外购'AND YQ123='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆一类' and YQ101='外购' AND YQ123='F'" ) );
                model.AM177 = string.IsNullOrEmpty( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆一类' and YQ101='外购' AND YQ123='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆一类' and YQ101='外购' AND YQ123='T'" ) );
                model.AM188 = string.IsNullOrEmpty( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆一类' and YQ101='库存' AND YQ123='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆一类' and YQ101='库存' AND YQ123='F'" ) );
                model.AM200 = string.IsNullOrEmpty( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆一类' and YQ101='库存' AND YQ123='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆一类' and YQ101='库存' AND YQ123='T'" ) );


                model.AM178 = string.IsNullOrEmpty( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆二类' and YQ101='外购'  AND YQ123='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆二类' and YQ101='外购'  AND YQ123='F'" ) );
                model.AM184 = string.IsNullOrEmpty( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆二类' and YQ101='外购' AND YQ123='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆二类' and YQ101='外购' AND YQ123='T'" ) );

                model.AM191 = string.IsNullOrEmpty( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆二类' and YQ101='库存' AND YQ123='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆二类' and YQ101='库存' AND YQ123='F'" ) );
                model.AM203 = string.IsNullOrEmpty( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆二类' and YQ101='库存' AND YQ123='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '水性漆二类' and YQ101='库存' AND YQ123='T'" ) );

                model.AM182 = string.IsNullOrEmpty( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '硝基漆' and YQ101='外购' AND YQ123='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '硝基漆' and YQ101='外购' AND YQ123='F'" ) );
                model.AM190 = string.IsNullOrEmpty( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '硝基漆' and YQ101='外购' AND YQ123='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '硝基漆' and YQ101='外购' AND YQ123='T'" ) );

                model.AM194 = string.IsNullOrEmpty( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '硝基漆' and YQ101='库存' AND YQ123='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '硝基漆' and YQ101='库存' AND YQ123='F'" ) );
                model.AM205 = string.IsNullOrEmpty( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '硝基漆' and YQ101='库存' AND YQ123='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '硝基漆' and YQ101='库存' AND YQ123='T'" ) );


                model.AM185 = string.IsNullOrEmpty( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '香蕉水' and YQ101='外购' AND YQ123='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '香蕉水' and YQ101='外购' AND YQ123='F'" ) );
                model.AM196 = string.IsNullOrEmpty( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '香蕉水' and YQ101='外购' AND YQ123='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '香蕉水' and YQ101='外购' AND YQ123='T'" ) );

                model.AM197 = string.IsNullOrEmpty( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '香蕉水' and YQ101='库存' AND YQ123='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '香蕉水' and YQ101='库存' AND YQ123='F'" ) );
                model.AM207 = string.IsNullOrEmpty( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '香蕉水' and YQ101='库存' AND YQ123='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(YQ)" ,"YQ03='" + model.AM002 + "' and YQ12= '香蕉水' and YQ101='库存' AND YQ123='T'" ) );
            }
        }

        /// <summary>
        /// 341
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqv ( string numList ,string idxList )
        {
            //,CASE WHEN PQV16>'95' OR PQV16='清水' THEN '清水' WHEN PQV16<'95' OR PQV16='混水' THEN '混水' END PQV16,

            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PQV01,PQV92,PQV86,PQV65,PQV88,CONVERT(DECIMAL(18,2),SUM(PQV)) PQV,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(PQV)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(PQV)) END AK,A.AK017 FROM(SELECT A.idx,PQV01,CASE WHEN PQV92='F' OR PQV92 IS NULL THEN 'F' WHEN PQV92='T' THEN 'T' END PQV92,CASE WHEN PQV86 LIKE '%荷%' THEN '荷木' WHEN PQV86 LIKE '%松%' THEN '新西兰松' WHEN PQV86 LIKE '%榉%' THEN '榉木' WHEN PQV86 LIKE '%椴%' THEN '椴木' WHEN PQV86 LIKE '%桦%' THEN '桦木' WHEN PQV86 LIKE '%杨%' THEN '杨木' ELSE '杂木' END PQV86,PQV65,CASE WHEN PQV88='T' THEN 'T' ELSE 'F' END PQV88,PQV11*PQV66*PQV81*PQV67*PQV13 PQV,PQV76,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQV A LEFT JOIN R_PQAL B ON A.PQV76=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx INNER JOIN R_REVIEWS D ON A.PQV76=D.RES06 " );
            strSql . Append ( " WHERE PQV01!='' " );
            strSql . Append ( " AND PQV01 IN (" + numList + ")  AND RES05='执行'  AND C.idx IN (" + idxList + ")  AND (PQV01!='' AND PQV01 IS NOT NULL) GROUP BY A.idx,PQV01,PQV92,PQV86,PQV65,PQV88,PQV11,PQV66,PQV81,PQV67,PQV13,PQV76,AK017 " );//  AND LEN(PQV01)=8
            strSql . Append ( " ) A GROUP BY PQV01,PQV92,PQV86,PQV65,PQV88,ISNULL(AK011,0),A.AK017 ORDER BY PQV01" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public void Wood ( MulaolaoLibrary . ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQAM SET " );
            strSql . AppendFormat ( "AM153='{0}'," ,model . AM153 );
            strSql . AppendFormat ( "AM154='{0}'," ,model . AM154 );
            strSql . AppendFormat ( "AM155='{0}'," ,model . AM155 );
            strSql . AppendFormat ( "AM156='{0}'," ,model . AM156 );
            strSql . AppendFormat ( "AM157='{0}'," ,model . AM157 );
            strSql . AppendFormat ( "AM158='{0}'," ,model . AM158 );
            strSql . AppendFormat ( "AM261='{0}'," ,model . AM261 );
            strSql . AppendFormat ( "AM262='{0}'," ,model . AM262 );
            strSql . AppendFormat ( "AM263='{0}'," ,model . AM263 );
            strSql . AppendFormat ( "AM264='{0}'," ,model . AM264 );
            strSql . AppendFormat ( "AM265='{0}'," ,model . AM265 );
            strSql . AppendFormat ( "AM266='{0}'," ,model . AM266 );
            strSql . AppendFormat ( "AM267='{0}'," ,model . AM267 );
            strSql . AppendFormat ( "AM268='{0}'," ,model . AM268 );
            strSql . AppendFormat ( "AM269='{0}'," ,model . AM269 );
            strSql . AppendFormat ( "AM287='{0}'," ,model . AM287 );
            strSql . AppendFormat ( "AM288='{0}'," ,model . AM288 );
            strSql . AppendFormat ( "AM289='{0}'," ,model . AM289 );
            strSql . AppendFormat ( "AM290='{0}'," ,model . AM290 );
            strSql . AppendFormat ( "AM291='{0}'," ,model . AM291 );
            strSql . AppendFormat ( "AM292='{0}'," ,model . AM292 );
            strSql . AppendFormat ( "AM293='{0}'," ,model . AM293 );
            strSql . AppendFormat ( "AM294='{0}'," ,model . AM294 );
            strSql . AppendFormat ( "AM295='{0}'," ,model . AM295 );
            strSql . AppendFormat ( "AM330='{0}'," ,model . AM330 );
            strSql . AppendFormat ( "AM331='{0}'," ,model . AM331 );
            strSql . AppendFormat ( "AM332='{0}'," ,model . AM332 );
            strSql . AppendFormat ( "AM333='{0}'," ,model . AM333 );
            strSql . AppendFormat ( "AM334='{0}'," ,model . AM334 );
            strSql . AppendFormat ( "AM335='{0}'," ,model . AM335 );
            strSql . AppendFormat ( "AM336='{0}'," ,model . AM336 );
            strSql . AppendFormat ( "AM337='{0}'," ,model . AM337 );
            strSql . AppendFormat ( "AM338='{0}'," ,model . AM338 );
            strSql . AppendFormat ( "AM339='{0}'," ,model . AM339 );
            strSql . AppendFormat ( "AM340='{0}'," ,model . AM340 );
            strSql . AppendFormat ( "AM341='{0}'," ,model . AM341 );
            strSql . AppendFormat ( "AM343='{0}'," ,model . AM343 );
            strSql . AppendFormat ( "AM344='{0}'," ,model . AM344 );
            strSql . AppendFormat ( "AM345='{0}'," ,model . AM345 );
            strSql . AppendFormat ( "AM346='{0}'," ,model . AM346 );
            strSql . AppendFormat ( "AM347='{0}'," ,model . AM347 );
            strSql . AppendFormat ( "AM348='{0}'," ,model . AM348 );
            strSql . AppendFormat ( "AM349='{0}'," ,model . AM349 );
            strSql . AppendFormat ( "AM350='{0}'," ,model . AM350 );
            strSql . AppendFormat ( "AM351='{0}'," ,model . AM351 );
            strSql . AppendFormat ( "AM352='{0}'," ,model . AM352 );
            strSql . AppendFormat ( "AM353='{0}'," ,model . AM353 );
            strSql . AppendFormat ( "AM354='{0}'," ,model . AM354 );
            strSql . AppendFormat ( "AM355='{0}'," ,model . AM355 );
            strSql . AppendFormat ( "AM356='{0}'," ,model . AM356 );
            strSql . AppendFormat ( "AM357='{0}'," ,model . AM357 );
            strSql . AppendFormat ( "AM358='{0}'," ,model . AM358 );
            strSql . AppendFormat ( "AM359='{0}'," ,model . AM359 );
            strSql . AppendFormat ( "AM360='{0}'," ,model . AM360 );
            strSql . AppendFormat ( "AM361='{0}'," ,model . AM361 );
            strSql . AppendFormat ( "AM362='{0}'," ,model . AM362 );
            strSql . AppendFormat ( "AM363='{0}'," ,model . AM363 );
            strSql . AppendFormat ( "AM364='{0}'," ,model . AM364 );
            strSql . AppendFormat ( "AM365='{0}'," ,model . AM365 );
            strSql . AppendFormat ( "AM366='{0}'," ,model . AM366 );
            strSql . AppendFormat ( "AM367='{0}'," ,model . AM367 );
            strSql . AppendFormat ( "AM368='{0}'," ,model . AM368 );
            strSql . AppendFormat ( "AM369='{0}'," ,model . AM369 );
            strSql . AppendFormat ( "AM370='{0}'," ,model . AM370 );
            strSql . AppendFormat ( "AM371='{0}'," ,model . AM371 );
            strSql . AppendFormat ( "AM372='{0}'," ,model . AM372 );
            strSql . AppendFormat ( "AM373='{0}'," ,model . AM373 );
            strSql . AppendFormat ( "AM374='{0}'," ,model . AM374 );
            strSql . AppendFormat ( "AM375='{0}'," ,model . AM375 );
            strSql . AppendFormat ( "AM376='{0}'," ,model . AM376 );
            strSql . AppendFormat ( "AM377='{0}'," ,model . AM377 );
            strSql . AppendFormat ( "AM378='{0}'," ,model . AM378 );
            strSql . AppendFormat ( "AM379='{0}'," ,model . AM379 );
            strSql . AppendFormat ( "AM380='{0}'," ,model . AM380 );
            strSql . AppendFormat ( "AM381='{0}'," ,model . AM381 );
            strSql . AppendFormat ( "AM385='{0}'," ,model . AM385 );
            strSql . AppendFormat ( "AM386='{0}'," ,model . AM386 );
            strSql . AppendFormat ( "AM387='{0}'," ,model . AM387 );
            strSql . AppendFormat ( "AM388='{0}'," ,model . AM388 );
            strSql . AppendFormat ( "AM389='{0}'," ,model . AM389 );
            strSql . AppendFormat ( "AM390='{0}'," ,model . AM390 );
            strSql . AppendFormat ( "AM391='{0}'," ,model . AM391 );
            strSql . AppendFormat ( "AM392='{0}'," ,model . AM392 );
            strSql . AppendFormat ( "AM393='{0}'" ,model . AM393 );
            strSql . AppendFormat ( " WHERE AM002='{0}'" ,model . AM002 );
            SQLString . Add ( strSql . ToString ( ) );
        }
        public string WoodAdd ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {           
            model.AM001 = generateOddNum.purchaseContract( "SELECT MAX(AJ024) AJ024 FROM R_PQAJ" ,"AJ024" ,"R_241-" );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAM (" );
            strSql.Append( "AM001,AM002,AM261,AM262,AM263,AM264,AM265,AM266,AM267,AM268,AM269,AM287,AM288,AM289,AM290,AM291,AM292,AM293,AM294,AM295,AM330,AM331,AM332,AM333,AM334,AM335,AM336,AM337,AM338,AM339,AM340,AM341,AM343,AM344,AM345,AM346,AM347,AM348,AM349,AM350,AM351,AM352,AM353,AM354,AM355,AM356,AM357,AM358,AM359,AM360,AM361,AM362,AM363,AM364,AM365,AM366,AM367,AM368,AM369,AM370,AM371,AM372,AM373,AM374,AM375,AM376,AM377,AM378,AM379,AM380,AM381,AM382,AM383,AM385,AM386,AM387,AM388,AM389,AM390,AM391,AM392,AM393,AM153,AM154,AM155,AM156,AM157,AM158)" );
            strSql.Append( " VALUES (" );
            strSql . AppendFormat ( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}','{38}','{39}','{40}','{41}','{42}','{43}','{44}','{45}','{46}','{47}','{48}','{49}','{50}','{51}','{52}','{53}','{54}','{55}','{56}','{57}','{58}','{59}','{60}','{61}','{62}','{63}','{64}','{65}','{66}','{67}','{68}','{69}','{70}','{71}','{72}','{73}','{74}','{75}','{76}','{77}','{78}','{79}','{80}','{81}','{82}','{83}','{84}','{85}','{86}','{87}')" ,model . AM001 ,model . AM002 ,model . AM261 ,model . AM262 ,model . AM263 ,model . AM264 ,model . AM265 ,model . AM266 ,model . AM267 ,model . AM268 ,model . AM269 ,model . AM287 ,model . AM288 ,model . AM289 ,model . AM290 ,model . AM291 ,model . AM292 ,model . AM293 ,model . AM294 ,model . AM295 ,model . AM330 ,model . AM331 ,model . AM332 ,model . AM333 ,model . AM334 ,model . AM335 ,model . AM336 ,model . AM337 ,model . AM338 ,model . AM339 ,model . AM340 ,model . AM341 ,model . AM343 ,model . AM344 ,model . AM345 ,model . AM346 ,model . AM347 ,model . AM348 ,model . AM349 ,model . AM350 ,model . AM351 ,model . AM352 ,model . AM353 ,model . AM354 ,model . AM355 ,model . AM356 ,model . AM357 ,model . AM358 ,model . AM359 ,model . AM360 ,model . AM361 ,model . AM362 ,model . AM363 ,model . AM364 ,model . AM365 ,model . AM366 ,model . AM367 ,model . AM368 ,model . AM369 ,model . AM370 ,model . AM371 ,model . AM372 ,model . AM373 ,model . AM374 ,model . AM375 ,model . AM376 ,model . AM377 ,model . AM378 ,model . AM379 ,model . AM380 ,model . AM381 ,model . AM382 ,model . AM383 ,model . AM385 ,model . AM386 ,model . AM387 ,model . AM388 ,model . AM389 ,model . AM390 ,model . AM391 ,model . AM392 ,model . AM393 ,model . AM153 ,model . AM154 ,model . AM155 ,model . AM156 ,model . AM157 ,model . AM158 );

            return strSql.ToString( );
        }
        public bool Pqv ( string idxList ,string numList ,MulaolaoLibrary.ProductCostSummaryLibrary model ,DataTable dk ,ArrayList SQLString )
        {
            dk = GetDataTablePqv( numList ,idxList );
            if ( dk != null && dk.Rows.Count > 0 )
            {
                for ( int m = 0 ; m < dk.Rows.Count ; m++ )
                {
                    model.AM002 = dk.Rows[m]["PQV01"].ToString( );

                    model . AM261 = model . AM262 = model . AM263 = model . AM264 = model . AM265 = model . AM266 = model . AM267 = model . AM268 = model . AM269 = model . AM287 = model . AM288 = model . AM289 = model . AM290 = model . AM291 = model . AM292 = model . AM293 = model . AM294 = model . AM295 = model . AM330 = model . AM331 = model . AM332 = model . AM333 = model . AM334 = model . AM335 = model . AM336 = model . AM337 = model . AM338 = model . AM339 = model . AM340 = model . AM341 = model . AM343 = model . AM344 = model . AM345 = model . AM346 = model . AM347 = model . AM348 = model . AM349 = model . AM350 = model . AM351 = model . AM352 = model . AM353 = model . AM354 = model . AM355 = model . AM356 = model . AM357 = model . AM358 = model . AM359 = model . AM360 = model . AM361 = model . AM362 = model . AM363 = model . AM364 = model . AM365 = model . AM366 = model . AM367 = model . AM368 = model . AM369 = model . AM370 = model . AM371 = model . AM372 = model . AM373 = model . AM374 = model . AM375 = model . AM376 = model . AM377 = model . AM378 = model . AM379 = model . AM380 = model . AM381 = model . AM382 = model . AM383 = model . AM385 = model . AM386 = model . AM387 = model . AM388 = model . AM389 = model . AM390 = model . AM391 = model . AM392 = model . AM393 = model . AM157 = model . AM158 = model . AM153 = model . AM154 = model . AM155 = model . AM156 = 0;

                    //model.AM339 = string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='新西兰松' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='新西兰松' AND PQV88='F'" ) );
                    model.AM340 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='新西兰松' AND PQV88='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='新西兰松' AND PQV88='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM345 = string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='新西兰松' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='新西兰松' AND PQV88='T'" ) );
                    model.AM348 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='新西兰松' AND PQV88='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='新西兰松' AND PQV88='T' AND (AK017='执行' OR AK017='审核')" ) );

                    //model.AM364 = string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='榉木' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='榉木' AND PQV88='F'" ) );
                    model.AM365 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='榉木' AND PQV88='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='榉木' AND PQV88='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM390 = string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='榉木' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='榉木' AND PQV88='T'" ) );
                    model.AM393 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='榉木' AND PQV88='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='榉木' AND PQV88='T' AND (AK017='执行' OR AK017='审核')" ) );

                    //model.AM336 = string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='外购' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='外购' AND PQV88='F'" ) );
                    model.AM337 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='外购' AND PQV88='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='外购' AND PQV88='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM338 = string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='外购' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='外购' AND PQV88='T'" ) );
                    model.AM341 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='外购' AND PQV88='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='外购' AND PQV88='T' AND (AK017='执行' OR AK017='审核')" ) );

                    //model.AM358 = string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='库存' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='库存' AND PQV88='F'" ) );
                    model.AM359 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='库存' AND PQV88='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='库存' AND PQV88='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM375 = string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='库存' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='库存' AND PQV88='T'" ) );
                    model.AM378 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='库存' AND PQV88='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='库存' AND PQV88='T' AND (AK017='执行' OR AK017='审核')" ) );

                    //model.AM343 = string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV16='清水' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV16='清水' AND PQV88='F'" ) );
                    model.AM344 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV88='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购'  AND PQV88='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM351 = string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV16='清水' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV16='清水' AND PQV88='T'" ) );
                    model.AM354 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购'  AND PQV88='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购'  AND PQV88='T' AND (AK017='执行' OR AK017='审核')" ) );

                    //model.AM361 = string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV16='混水' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV16='混水' AND PQV88='F'" ) );
                    //model.AM362 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV16='混水' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV16='混水' AND PQV88='F'" ) );
                    //model.AM381 = string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV16='混水' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV16='混水' AND PQV88='T'" ) );
                    //model.AM387 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV16='混水' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV16='混水' AND PQV88='T'" ) );

                    //model.AM373 = string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV16='清水' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV16='清水' AND PQV88='F'" ) );
                    model.AM374 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存'  AND PQV88='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存'  AND PQV88='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM287 = string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV16='清水' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV16='清水' AND PQV88='T'" ) );
                    model.AM269 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV88='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV88='T' AND (AK017='执行' OR AK017='审核')" ) );

                    //model.AM376 = string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV16='混水' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV16='混水' AND PQV88='F'" ) );
                    //model.AM377 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV16='混水' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV16='混水' AND PQV88='F'" ) );
                    //model.AM267 = string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV16='混水' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV16='混水' AND PQV88='T'" ) );
                    //model.AM268 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV16='混水' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV16='混水' AND PQV88='T'" ) );

                    //model.AM346 = string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='外购' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='外购' AND PQV88='F'" ) );
                    model.AM347 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='外购' AND PQV88='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='外购' AND PQV88='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM357 = string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='外购' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='外购' AND PQV88='T'" ) );
                    model.AM360 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='外购' AND PQV88='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='外购' AND PQV88='T' AND (AK017='执行' OR AK017='审核')" ) );

                    //model.AM379= string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='库存' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='库存' AND PQV88='F'" ) );
                    model.AM380 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='库存' AND PQV88='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='库存' AND PQV88='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM265 = string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='库存' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='库存' AND PQV88='T'" ) );
                    model.AM266 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='库存' AND PQV88='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='库存' AND PQV88='T' AND (AK017='执行' OR AK017='审核')" ) );

                    //model.AM349 = string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND PQV16='清水' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND PQV16='清水' AND PQV88='F'" ) );
                    model.AM350 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购'  AND PQV88='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND PQV88='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM363 = string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND PQV16='清水' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND PQV16='清水' AND PQV88='T'" ) );
                    model.AM366 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购'  AND PQV88='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购'  AND PQV88='T' AND (AK017='执行' OR AK017='审核')" ) );

                    //model.AM367 = string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND PQV16='混水' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND PQV16='混水' AND PQV88='F'" ) );
                    //model.AM368 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND PQV16='混水' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND PQV16='混水' AND PQV88='F'" ) );
                    //model.AM294 = string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND PQV16='混水' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND PQV16='混水' AND PQV88='T'" ) );
                    //model.AM295 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND PQV16='混水' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND PQV16='混水' AND PQV88='T'" ) );

                     //model.AM385 = string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV16='清水' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV16='清水' AND PQV88='F'" ) );
                    model.AM386 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存'  AND PQV88='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存'  AND PQV88='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM382 = string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV16='清水' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV16='清水' AND PQV88='T'" ) );
                    model.AM383 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存'  AND PQV88='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV88='T' AND (AK017='执行' OR AK017='审核')" ) );

                    //model.AM388 = string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV16='混水' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV16='混水' AND PQV88='F'" ) );
                    //model.AM389 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV16='混水' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV16='混水' AND PQV88='F'" ) );
                    //model.AM263 = string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV16='混水' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV16='混水' AND PQV88='T'" ) );
                    //model.AM264 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV16='混水' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV16='混水' AND PQV88='T'" ) );

                    //model.AM352 = string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND PQV16='清水' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND PQV16='清水' AND PQV88='F'" ) );
                    model.AM353 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购'  AND PQV88='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购'  AND PQV88='F' AND (AK017='执行' OR AK017='审核')" ) );
                   // model.AM369 = string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND PQV16='清水' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND PQV16='清水' AND PQV88='T'" ) );
                    model.AM372 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购'  AND PQV88='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购'  AND PQV88='T' AND (AK017='执行' OR AK017='审核')" ) );

                    //model.AM370 = string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND PQV16='混水' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND PQV16='混水' AND PQV88='F'" ) );
                    //model.AM371 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND PQV16='混水' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND PQV16='混水' AND PQV88='F'" ) );
                    //model.AM292 = string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND PQV16='混水' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND PQV16='混水' AND PQV88='T'" ) );
                    //model.AM293 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND PQV16='混水' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND PQV16='混水' AND PQV88='T'" ) );

                    //model.AM391 = string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV16='清水' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV16='清水' AND PQV88='F'" ) );
                    model.AM392 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存'  AND PQV88='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存'  AND PQV88='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM261 = string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV16='清水' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV16='清水' AND PQV88='T'" ) );
                    model.AM262 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存'  AND PQV88='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存'  AND PQV88='T' AND (AK017='执行' OR AK017='审核')" ) );

                    //model.AM333 = string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV16='混水' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV16='混水' AND PQV88='F'" ) );
                    //model.AM334 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV16='混水' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV16='混水' AND PQV88='F'" ) );
                    //model.AM288 = string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV16='混水' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV16='混水' AND PQV88='T'" ) );
                    //model.AM289 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV16='混水' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV16='混水' AND PQV88='T'" ) );

                    //model.AM355 = string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='杂木' AND PQV65='外购' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='杂木' AND PQV65='外购' AND PQV88='F'" ) );
                    model.AM356 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='杂木' AND PQV65='外购' AND PQV88='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='杂木' AND PQV65='外购' AND PQV88='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM332 = string.IsNullOrEmpty( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='杂木' AND PQV65='外购' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='杂木' AND PQV65='外购' AND PQV88='T'" ) );
                    model.AM335 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='杂木' AND PQV65='外购' AND PQV88='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='杂木' AND PQV65='外购' AND PQV88='T' AND (AK017='执行' OR AK017='审核')" ) );

                    model . AM154 = string . IsNullOrEmpty ( dk . Compute ( "sum(AK)" ,"PQV01='" + model . AM002 + "' and PQV92= 'F' and PQV86='杨木' AND PQV65='外购' AND PQV88='F' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dk . Compute ( "sum(AK)" ,"PQV01='" + model . AM002 + "' and PQV92= 'F' and PQV86='杨木' AND PQV65='外购' AND PQV88='F' AND (AK017='执行' OR AK017='审核')" ) );
                    model . AM156 = string . IsNullOrEmpty ( dk . Compute ( "sum(AK)" ,"PQV01='" + model . AM002 + "' and PQV92= 'F' and PQV86='杨木' AND PQV65='外购' AND PQV88='T' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dk . Compute ( "sum(AK)" ,"PQV01='" + model . AM002 + "' and PQV92= 'F' and PQV86='杨木' AND PQV65='外购' AND PQV88='T' AND (AK017='执行' OR AK017='审核')" ) );


                    if ( m == 0 )
                    {
                        ofFivY( model ,SQLString );
                        if ( ExistsOfCount( model.AM002 ) )
                        {
                            ofFiv( model );
                            Wood( model ,SQLString );
                        }
                        else
                            SQLString.Add( WoodAdd( model ) );
                    }
                    if ( m >= 1 )
                    {
                        if ( model.AM002 != dk.Rows[m - 1]["PQV01"].ToString( ) )
                        {
                            ofFivY( model ,SQLString );
                            if ( ExistsOfCount( model.AM002 ) )
                            {
                                ofFiv( model );
                                Wood( model ,SQLString );
                            }
                            else
                                SQLString.Add( WoodAdd( model ) );
                        }
                    }
                }
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        DataTable GetDataTableOfFiv ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AM154,AM156,AM262,AM264,AM266,AM268,AM269,AM289,AM291,AM293,AM295,AM331,AM333,AM334,AM335,AM337,AM340,AM341,AM344,AM347,AM348,AM350,AM353,AM354,AM356,AM359,AM360,AM362,AM365,AM366,AM368,AM371,AM372,AM374,AM377,AM378,AM380,AM383,AM386,AM387,AM389,AM392,AM393 FROM R_PQAM" );
            strSql.Append( " WHERE AM002=@AM002" );
            SqlParameter[] parameter = {
                new SqlParameter("@AM002",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        void ofFiv ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            //AM262,AM264,AM266,AM268,AM269,AM289,AM291,AM293,AM295,AM331,AM334,AM335,AM337,AM340,AM341,AM344,AM347,AM348,AM350,AM353,AM354,AM356,AM359,AM360,AM362,AM365,AM366,AM368,AM371,AM372,AM374,AM377,AM378,AM380,AM383,AM386,AM387,AM389,AM392,AM393
            DataTable da = GetDataTableOfFiv( model.AM002 );
            if ( da != null && da . Rows . Count > 0 )
            {
                model . AM154 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM154" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM154" ] . ToString ( ) );
                model . AM156 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM156" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM156" ] . ToString ( ) );
                model . AM262 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM262" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM262" ] . ToString ( ) );
                model . AM264 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM264" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM264" ] . ToString ( ) );
                model . AM266 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM266" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM266" ] . ToString ( ) );
                model . AM268 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM268" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM268" ] . ToString ( ) );
                model . AM269 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM269" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM269" ] . ToString ( ) );
                model . AM289 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM289" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM289" ] . ToString ( ) );
                model . AM291 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM291" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM291" ] . ToString ( ) );
                model . AM293 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM293" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM293" ] . ToString ( ) );
                model . AM295 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM295" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM295" ] . ToString ( ) );
                model . AM331 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM331" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM331" ] . ToString ( ) );
                model . AM334 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM334" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM334" ] . ToString ( ) );
                model . AM335 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM335" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM335" ] . ToString ( ) );
                model . AM337 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM337" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM337" ] . ToString ( ) );
                model . AM340 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM340" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM340" ] . ToString ( ) );
                model . AM341 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM341" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM341" ] . ToString ( ) );
                model . AM344 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM344" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM344" ] . ToString ( ) );
                model . AM347 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM347" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM347" ] . ToString ( ) );
                model . AM348 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM348" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM348" ] . ToString ( ) );
                model . AM350 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM350" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM350" ] . ToString ( ) );
                model . AM353 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM353" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM353" ] . ToString ( ) );
                model . AM354 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM354" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM354" ] . ToString ( ) );
                model . AM356 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM356" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM356" ] . ToString ( ) );
                model . AM359 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM359" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM359" ] . ToString ( ) );
                model . AM360 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM360" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM360" ] . ToString ( ) );
                model . AM362 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM362" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM362" ] . ToString ( ) );
                model . AM365 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM365" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM365" ] . ToString ( ) );
                model . AM366 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM366" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM366" ] . ToString ( ) );
                model . AM368 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM368" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM368" ] . ToString ( ) );
                model . AM371 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM371" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM371" ] . ToString ( ) );
                model . AM372 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM372" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM372" ] . ToString ( ) );
                model . AM374 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM374" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM374" ] . ToString ( ) );
                model . AM377 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM377" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM377" ] . ToString ( ) );
                model . AM378 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM378" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM378" ] . ToString ( ) );
                model . AM380 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM380" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM380" ] . ToString ( ) );
                model . AM383 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM383" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM383" ] . ToString ( ) );
                model . AM386 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM386" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM386" ] . ToString ( ) );
                model . AM387 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM387" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM387" ] . ToString ( ) );
                model . AM389 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM389" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM389" ] . ToString ( ) );
                model . AM392 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM392" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM392" ] . ToString ( ) );
                model . AM393 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM393" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM393" ] . ToString ( ) );
            }
        }
        DataTable GetDataTableOfFivY ( string num )
        {
            //CASE WHEN PQV16>'95' OR PQV16='清水' THEN '清水' WHEN PQV16<'95' OR PQV16='混水' THEN '混水' END PQV16,
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT A.PQV76,PQV01,CASE WHEN PQV92='F' OR PQV92 IS NULL THEN 'F' WHEN PQV92='T' THEN 'T' END PQV92,CASE WHEN PQV86 LIKE '%荷%' THEN '荷木' WHEN PQV86 LIKE '%松%' THEN '新西兰松' WHEN PQV86 LIKE '%榉%' THEN '榉木' WHEN PQV86 LIKE '%椴%' THEN '椴木' WHEN PQV86 LIKE '%桦%' THEN '桦木' WHEN PQV86 LIKE '%杨%' THEN '杨木' ELSE '杂木' END PQV86,PQV65,CASE WHEN PQV88='T' THEN 'T' ELSE 'F' END PQV88,CONVERT(DECIMAL(18,2),SUM(PQV11*PQV66*PQV81*PQV67*PQV13)) PQV FROM R_PQV A LEFT JOIN R_REVIEWS D ON A.PQV76=D.RES06 AND RES05='执行'" );
            strSql.Append( " WHERE PQV01=@PQV01" );
            strSql.Append( " GROUP BY PQV01,PQV86,PQV65,PQV88,PQV92,A.PQV76" );
            SqlParameter[] parameter = {
                new SqlParameter("@PQV01",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        void ofFivY ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            DataTable one = GetDataTableOfFivY( model.AM002 );
            if ( one != null && one.Rows.Count > 0 )
            {
                string oddNum = "";
                for ( int i = 0 ; i < one.Rows.Count ; i++ )
                {
                    oddNum = one.Rows[i]["PQV76"].ToString( );
                    model.AM339 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='新西兰松' AND PQV88='F' AND PQV76='"+oddNum+"'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='新西兰松' AND PQV88='F' AND PQV76='" + oddNum + "'" ) );
                    model.AM345 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='新西兰松' AND PQV88='T' AND PQV76='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='新西兰松' AND PQV88='T' AND PQV76='" + oddNum + "'" ) );

                    model.AM364 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='榉木' AND PQV88='F' AND PQV76='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='榉木' AND PQV88='F' AND PQV76='" + oddNum + "'" ) );
                    model.AM390 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='榉木' AND PQV88='T' AND PQV76='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='榉木' AND PQV88='T' AND PQV76='" + oddNum + "'" ) );

                    model.AM336 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='外购' AND PQV88='F' AND PQV76='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='外购' AND PQV88='F' AND PQV76='" + oddNum + "'" ) );
                    model.AM338 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='外购' AND PQV88='T' AND PQV76='"+oddNum+"'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='外购' AND PQV88='T' AND PQV76='" + oddNum + "'" ) );

                    model.AM358 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='库存' AND PQV88='F' AND PQV76='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='库存' AND PQV88='F' AND PQV76='" + oddNum + "'" ) );
                    model.AM375 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='库存' AND PQV88='T' AND PQV76='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='库存' AND PQV88='T' AND PQV76='" + oddNum + "'" ) );

                    model.AM343 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV88='F' AND PQV76='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购'  AND PQV88='F' AND PQV76='" + oddNum + "'" ) );
                    model.AM351 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV88='T' AND PQV76='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV88='T' AND PQV76='" + oddNum + "'" ) );

                    //model.AM361 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV16='混水' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV16='混水' AND PQV88='F'" ) );
                    //model.AM381 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV16='混水' AND PQV88='T' AND PQV76='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV16='混水' AND PQV88='T' AND PQV76='" + oddNum + "'" ) );

                    model.AM373 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV88='F' AND PQV76='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV88='F' AND PQV76='" + oddNum + "'" ) );
                    model.AM287 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV88='T' AND PQV76='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV88='T' AND PQV76='" + oddNum + "'" ) );

                    //model.AM376 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV16='混水' AND PQV88='F' AND PQV76='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV16='混水' AND PQV88='F' AND PQV76='" + oddNum + "'" ) );
                    //model.AM267 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV16='混水' AND PQV88='T' AND PQV76='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV16='混水' AND PQV88='T' AND PQV76='" + oddNum + "'" ) );

                    model.AM346 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='外购' AND PQV88='F' AND PQV76='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='外购' AND PQV88='F' AND PQV76='" + oddNum + "'" ) );
                    model.AM357 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='外购' AND PQV88='T' AND PQV76='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='外购' AND PQV88='T' AND PQV76='" + oddNum + "'" ) );

                    model.AM379 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='库存' AND PQV88='F' AND PQV76='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='库存' AND PQV88='F' AND PQV76='" + oddNum + "'" ) );
                    model.AM265 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='库存' AND PQV88='T' AND PQV76='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='库存' AND PQV88='T' AND PQV76='" + oddNum + "'" ) );

                    model.AM349 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND PQV88='F' AND PQV76='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND PQV88='F' AND PQV76='" + oddNum + "'" ) );
                    model.AM363 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购'  AND PQV88='T' AND PQV76='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND PQV88='T' AND PQV76='" + oddNum + "'" ) );

                    //model.AM367 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND PQV16='混水' AND PQV88='F' AND PQV76='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND PQV16='混水' AND PQV88='F' AND PQV76='" + oddNum + "'" ) );
                    //model.AM294 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND PQV16='混水' AND PQV88='T' AND PQV76='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND PQV16='混水' AND PQV88='T' AND PQV76='" + oddNum + "'" ) );

                    model.AM385 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV88='F' AND PQV76='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV88='F' AND PQV76='" + oddNum + "'" ) );
                    model.AM382 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV88='T' AND PQV76='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV88='T' AND PQV76='" + oddNum + "'" ) );

                    //model.AM388 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV16='混水' AND PQV88='F' AND PQV76='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV16='混水' AND PQV88='F' AND PQV76='" + oddNum + "'" ) );
                    //model.AM263 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV16='混水' AND PQV88='T' AND PQV76='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV16='混水' AND PQV88='T' AND PQV76='" + oddNum + "'" ) );

                    model.AM352 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND PQV88='F' AND PQV76='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND PQV88='F' AND PQV76='" + oddNum + "'" ) );
                    model.AM369 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购'  AND PQV88='T' AND PQV76='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND PQV88='T' AND PQV76='" + oddNum + "'" ) );

                    //model.AM370 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND PQV16='混水' AND PQV88='F' AND PQV76='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND PQV16='混水' AND PQV88='F' AND PQV76='" + oddNum + "'" ) );
                    //model.AM292 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND PQV16='混水' AND PQV88='T' AND PQV76='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND PQV16='混水' AND PQV88='T' AND PQV76='" + oddNum + "'" ) );

                    model.AM391 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV88='F' AND PQV76='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV88='F' AND PQV76='" + oddNum + "'" ) );
                    model.AM261 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV88='T' AND PQV76='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV88='T' AND PQV76='" + oddNum + "'" ) );

                    //model.AM333 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV16='混水' AND PQV88='F' AND PQV76='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV16='混水' AND PQV88='F' AND PQV76='" + oddNum + "'" ) );
                    //model.AM288 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV16='混水' AND PQV88='T' AND PQV76='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV16='混水' AND PQV88='T' AND PQV76='" + oddNum + "'" ) );

                    model.AM355 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='杂木' AND PQV65='外购' AND PQV88='F' AND PQV76='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='杂木' AND PQV65='外购' AND PQV88='F' AND PQV76='" + oddNum + "'" ) );
                    model.AM332 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='杂木' AND PQV65='外购' AND PQV88='T' AND PQV76='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='杂木' AND PQV65='外购' AND PQV88='T' AND PQV76='" + oddNum + "'" ) );

                    model . AM153 = string . IsNullOrEmpty ( one . Compute ( "sum(PQV)" ,"PQV01='" + model . AM002 + "' and PQV92= 'F' and PQV86='杨木' AND PQV65='外购' AND PQV88='F' AND PQV76='" + oddNum + "'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( one . Compute ( "sum(PQV)" ,"PQV01='" + model . AM002 + "' and PQV92= 'F' and PQV86='杨木' AND PQV65='外购' AND PQV88='F' AND PQV76='" + oddNum + "'" ) );
                    model . AM155 = string . IsNullOrEmpty ( one . Compute ( "sum(PQV)" ,"PQV01='" + model . AM002 + "' and PQV92= 'F' and PQV86='杨木' AND PQV65='外购' AND PQV88='T' AND PQV76='" + oddNum + "'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( one . Compute ( "sum(PQV)" ,"PQV01='" + model . AM002 + "' and PQV92= 'F' and PQV86='杨木' AND PQV65='外购' AND PQV88='T' AND PQV76='" + oddNum + "'" ) );
                    model . AM157 = string . IsNullOrEmpty ( one . Compute ( "sum(PQV)" ,"PQV01='" + model . AM002 + "' and PQV92= 'F' and PQV86='杨木' AND PQV65='库存' AND PQV88='F' AND PQV76='" + oddNum + "'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( one . Compute ( "sum(PQV)" ,"PQV01='" + model . AM002 + "' and PQV92= 'F' and PQV86='杨木' AND PQV65='库存' AND PQV88='F' AND PQV76='" + oddNum + "'" ) );
                    model . AM158 = string . IsNullOrEmpty ( one . Compute ( "sum(PQV)" ,"PQV01='" + model . AM002 + "' and PQV92= 'F' and PQV86='杨木' AND PQV65='库存' AND PQV88='T' AND PQV76='" + oddNum + "'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( one . Compute ( "sum(PQV)" ,"PQV01='" + model . AM002 + "' and PQV92= 'F' and PQV86='杨木' AND PQV65='库存' AND PQV88='T' AND PQV76='" + oddNum + "'" ) );

                    WriteReceivableToGeneralLedger .ByOneByMuCai( model ,oddNum ,SQLString );
                }
                model.AM339 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='新西兰松' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='新西兰松' AND PQV88='F'" ) );
                model.AM345 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='新西兰松' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='新西兰松' AND PQV88='T'" ) );

                model.AM364 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='榉木' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='榉木' AND PQV88='F'" ) );
                model.AM390 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='榉木' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='榉木' AND PQV88='T'" ) );

                model.AM336 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='外购' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='外购' AND PQV88='F'" ) );
                model.AM338 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='外购' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='外购' AND PQV88='T'" ) );

                model.AM358 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='库存' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='库存' AND PQV88='F'" ) );
                model.AM375 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='库存' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='库存' AND PQV88='T'" ) );

                model.AM343 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV88='F' " ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV88='F'" ) );
                model.AM351 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV88='T' " ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV88='T'" ) );

                //model.AM361 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV16='混水' AND PQV88='F' " ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV16='混水' AND PQV88='F'" ) );
                //model.AM381 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV16='混水' AND PQV88='T' " ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV16='混水' AND PQV88='T'" ) );

                model.AM373 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV88='F' " ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV88='F'" ) );
                model.AM287 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV88='T' " ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV88='T'" ) );

                //model.AM376 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV16='混水' AND PQV88='F' " ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV16='混水' AND PQV88='F'" ) );
                //model.AM267 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV16='混水' AND PQV88='T' " ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV16='混水' AND PQV88='T'" ) );

                model.AM346 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='外购' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='外购' AND PQV88='F'" ) );
                model.AM357 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='外购' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='外购' AND PQV88='T'" ) );

                model.AM379 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='库存' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='库存' AND PQV88='F'" ) );
                model.AM265 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='库存' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='库存' AND PQV88='T'" ) );

                model.AM349 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND PQV88='F' " ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND PQV88='F'" ) );
                model.AM363 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购'  AND PQV88='T' " ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购'  AND PQV88='T'" ) );

                //model.AM367 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND PQV16='混水' AND PQV88='F' " ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND PQV16='混水' AND PQV88='F'" ) );
                //model.AM294 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND PQV16='混水' AND PQV88='T' " ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND PQV16='混水' AND PQV88='T'" ) );

                model.AM385 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV88='F' " ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV88='F'" ) );
                model.AM382 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存'  AND PQV88='T' " ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存'  AND PQV88='T'" ) );

                //model.AM388 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV16='混水' AND PQV88='F' " ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV16='混水' AND PQV88='F'" ) );
                //model.AM263 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV16='混水' AND PQV88='T' " ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV16='混水' AND PQV88='T'" ) );

                model.AM352 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购'  AND PQV88='F' " ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购'  AND PQV88='F'" ) );
                model.AM369 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND PQV88='T' " ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购'  AND PQV88='T'" ) );

                //model.AM370 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND PQV16='混水' AND PQV88='F' " ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND PQV16='混水' AND PQV88='F'" ) );
                //model.AM292 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND PQV16='混水' AND PQV88='T' " ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND PQV16='混水' AND PQV88='T'" ) );

                model.AM391 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV88='F' " ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV88='F'" ) );
                model.AM261 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存'  AND PQV88='T' " ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存'  AND PQV88='T'" ) );

                //model.AM333 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV16='混水' AND PQV88='F' " ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV16='混水' AND PQV88='F'" ) );
                //model.AM288 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV16='混水' AND PQV88='T' " ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV16='混水' AND PQV88='T'" ) );

                model.AM355 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='杂木' AND PQV65='外购' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='杂木' AND PQV65='外购' AND PQV88='F'" ) );
                model.AM332 = string.IsNullOrEmpty( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='杂木' AND PQV65='外购' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQV)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='杂木' AND PQV65='外购' AND PQV88='T'" ) );

                model . AM153 = string . IsNullOrEmpty ( one . Compute ( "sum(PQV)" ,"PQV01='" + model . AM002 + "' and PQV92= 'F' and PQV86='杨木' AND PQV65='外购' AND PQV88='F'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( one . Compute ( "sum(PQV)" ,"PQV01='" + model . AM002 + "' and PQV92= 'F' and PQV86='杨木' AND PQV65='外购' AND PQV88='F' " ) );
                model . AM155 = string . IsNullOrEmpty ( one . Compute ( "sum(PQV)" ,"PQV01='" + model . AM002 + "' and PQV92= 'F' and PQV86='杨木' AND PQV65='外购' AND PQV88='T'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( one . Compute ( "sum(PQV)" ,"PQV01='" + model . AM002 + "' and PQV92= 'F' and PQV86='杨木' AND PQV65='外购' AND PQV88='T' " ) );
                model . AM157 = string . IsNullOrEmpty ( one . Compute ( "sum(PQV)" ,"PQV01='" + model . AM002 + "' and PQV92= 'F' and PQV86='杨木' AND PQV65='库存' AND PQV88='F'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( one . Compute ( "sum(PQV)" ,"PQV01='" + model . AM002 + "' and PQV92= 'F' and PQV86='杨木' AND PQV65='库存' AND PQV88='F' " ) );
                model . AM158 = string . IsNullOrEmpty ( one . Compute ( "sum(PQV)" ,"PQV01='" + model . AM002 + "' and PQV92= 'F' and PQV86='杨木' AND PQV65='库存' AND PQV88='T'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( one . Compute ( "sum(PQV)" ,"PQV01='" + model . AM002 + "' and PQV92= 'F' and PQV86='杨木' AND PQV65='库存' AND PQV88='T' " ) );

            }
        }
        
        /// <summary>
        /// 342
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqaf ( string numList ,string idxList )
        {
            StringBuilder strSql = new StringBuilder( );
            //CASE WHEN  AF026='清水' THEN '清水' WHEN  AF026='混水' THEN '混水' END AF026,
            //strSql.Append( "SELECT AF002,AF016,AF078,CONVERT(DECIMAL(18,2),SUM(AF)) AF,CONVERT(DECIMAL(18,2),SUM(CASE WHEN AK>=AF THEN AF WHEN AK<AF THEN AK ELSE 0 END)) AK FROM (SELECT A.idx,AF002,AF016,CASE WHEN AF078='T' THEN 'T' WHEN AF078='F' OR AF078 IS NULL THEN 'F' END AF078,SUM(AF023*AF006*AF019) AF,ISNULL(AK011,0) AK FROM R_PQAF A LEFT JOIN R_PQAL B ON A.AF001=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx  AND C.idx IN (" + idxList + ") INNER JOIN R_REVIEWS D ON A.AF001=D.RES06 AND RES05='执行' WHERE AF002!=''" );
            //strSql.Append( " AND AF002 IN (" + numList + ") AND (AF002!='' AND AF002 IS NOT NULL)" );//AND LEN( AF002 ) = 8
            //strSql.Append( " GROUP BY AF002,AF016,AF078,AK011,A.idx) A WHERE AK!=0 GROUP BY AF002,AF016,AF078 ORDER BY AF002" );


            /*
            strSql . Append ( "SELECT AF002,AF016,AF078,CONVERT(DECIMAL(18,2),SUM(AF)) AF,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(AF)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(AF)) END AK,A.AK017 FROM (SELECT A.idx,AF002,AF016,CASE WHEN AF078='T' THEN 'T' WHEN AF078='F' OR AF078 IS NULL THEN 'F' END AF078,AF023*AF006*AF019 AF,AF001,AK017 FROM R_PQAF A LEFT JOIN R_PQAL B ON A.AF001=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx INNER JOIN R_REVIEWS D ON A.AF001=D.RES06 AND RES05='执行' " );
            strSql . Append ( "WHERE AF002!='' AND AF002 IN (" + numList + ")  AND C.idx IN (" + idxList + ") " );
            strSql . Append ( "AND (AF002!='' AND AF002 IS NOT NULL)) A LEFT JOIN R_PQAK B ON A.AF001=B.AK003 GROUP BY AF002,AF016,AF078,ISNULL(AK011,0),A.AK017 ORDER BY AF002" );
            */


            strSql . Append ( "SELECT AF002,AF016,AF078,CONVERT(DECIMAL(18,2),SUM(AF)) AF,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(AF)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(AF)) END AK,A.AK017 FROM (SELECT A.idx,AF002,AF016,CASE WHEN AF078='T' THEN 'T' WHEN AF078='F' OR AF078 IS NULL THEN 'F' END AF078,AF023*AF006*AF019 AF,AF001,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQAF A LEFT JOIN R_PQAL B ON A.AF001=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx INNER JOIN R_REVIEWS D ON A.AF001=D.RES06 " );
            strSql . Append ( "WHERE AF002!=''  AND RES05='执行' AND AF002 IN (" + numList + ")  AND C.idx IN (" + idxList + ") " );
            strSql . Append ( "AND (AF002!='' AND AF002 IS NOT NULL) GROUP BY A.idx,AF001,AF002,AF016,AF023,AF006,AF019,AF078,AK017) A GROUP BY AF002,AF016,AF078,ISNULL(AK011,0),A.AK017 ORDER BY AF002" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public void VehicleWoodPieces ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            strSql.AppendFormat( "AM270='{0}'," ,model.AM270 );
            strSql.AppendFormat( "AM271='{0}'," ,model.AM271 );
            strSql.AppendFormat( "AM272='{0}'," ,model.AM272 );
            strSql.AppendFormat( "AM273='{0}'," ,model.AM273 );
            strSql.AppendFormat( "AM274='{0}'," ,model.AM274 );
            strSql.AppendFormat( "AM275='{0}'," ,model.AM275 );
            strSql.AppendFormat( "AM277='{0}'," ,model.AM277 );
            strSql.AppendFormat( "AM278='{0}'," ,model.AM278 );
            strSql.AppendFormat( "AM279='{0}'," ,model.AM279 );
            strSql.AppendFormat( "AM280='{0}'," ,model.AM280 );
            strSql.AppendFormat( "AM281='{0}'," ,model.AM281 );
            strSql.AppendFormat( "AM282='{0}'," ,model.AM282 );
            strSql.AppendFormat( "AM283='{0}'," ,model.AM283 );
            strSql.AppendFormat( "AM284='{0}'," ,model.AM284 );
            strSql.AppendFormat( "AM285='{0}'," ,model.AM285 );
            strSql.AppendFormat( "AM286='{0}'" ,model.AM286 );
            strSql.AppendFormat( " WHERE AM002='{0}'" ,model.AM002 );
            SQLString.Add( strSql.ToString( ) );
        }
        public string VehicleWoodPiecesAdd ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            model.AM001 = generateOddNum.purchaseContract( "SELECT MAX(AJ024) AJ024 FROM R_PQAJ" ,"AJ024" ,"R_241-" );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAM (" );
            strSql.Append( "AM002,AM270,AM271,AM272,AM273,AM274,AM275,AM277,AM278,AM279,AM280,AM281,AM282,AM283,AM284,AM285,AM286,AM001)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}')" ,model.AM002 ,model.AM270 ,model.AM271 ,model.AM272 ,model.AM273 ,model.AM274 ,model.AM275 ,model.AM277 ,model.AM278 ,model.AM279 ,model.AM280 ,model.AM281 ,model.AM282 ,model.AM283 ,model.AM284 ,model.AM285 ,model.AM286 ,model.AM001 );

            return strSql.ToString( );
        }
        public bool Pqaf ( string idxList ,string numList ,MulaolaoLibrary.ProductCostSummaryLibrary model ,DataTable dk ,ArrayList SQLString )
        {
            dk = GetDataTablePqaf( numList ,idxList );
            if ( dk != null && dk.Rows.Count > 0 )
            {
                for ( int m = 0 ; m < dk.Rows.Count ; m++ )
                {
                    model.AM002 = dk.Rows[m]["AF002"].ToString( );
                    model.AM270 = model.AM271 = model.AM273 = model.AM274 = model.AM277 = model.AM278 = model.AM280 = model.AM281 = model.AM272 = model.AM275 = model.AM279 = model.AM282 = model.AM283 = model.AM284 = model.AM285 = model.AM286 = 0;
                    
                    //model.AM270 = string.IsNullOrEmpty( dk.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "' and AF016= '外购' and AF026='清水' AND AF078='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AF)" ,"AF002='" + model.AM002 + "' and AF016= '外购' and AF026='清水' AND AF078='F'" ) );
                    model.AM271 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"AF002='" + model.AM002 + "' and AF016= '外购' AND AF078='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"AF002='" + model.AM002 + "' and AF016= '外购' AND AF078='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM272 = string.IsNullOrEmpty( dk.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "' and AF016= '外购' and AF026='清水' AND AF078='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AF)" ,"AF002='" + model.AM002 + "' and AF016= '外购' and AF026='清水' AND AF078='T'" ) );
                    model.AM275 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"AF002='" + model.AM002 + "' and AF016= '外购' AND AF078='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"AF002='" + model.AM002 + "' and AF016= '外购' AND AF078='T' AND (AK017='执行' OR AK017='审核')" ) );

                    //model.AM273 = string.IsNullOrEmpty( dk.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "' and AF016= '外购' and AF026='混水' AND AF078='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "' and AF016= '外购' and AF026='混水' AND AF078='F'" ) );
                    //model.AM274 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"AF002='" + model.AM002 + "' and AF016= '外购' and AF026='混水' AND AF078='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"AF002='" + model.AM002 + "' and AF016= '外购' and AF026='混水' AND AF078='F'" ) );
                    //model.AM279 = string.IsNullOrEmpty( dk.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "' and AF016= '外购' and AF026='混水' AND AF078='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "' and AF016= '外购' and AF026='混水' AND AF078='T'" ) );
                    //model.AM282 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"AF002='" + model.AM002 + "' and AF016= '外购' and AF026='混水' AND AF078='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"AF002='" + model.AM002 + "' and AF016= '外购' and AF026='混水' AND AF078='T'" ) );

                    //model.AM277 = string.IsNullOrEmpty( dk.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "' and AF016= '库存' and AF026='清水' AND AF078='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "' and AF016= '库存' and AF026='清水' AND AF078='F'" ) );
                    model.AM278 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"AF002='" + model.AM002 + "' and AF016= '库存' AND AF078='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"AF002='" + model.AM002 + "' and AF016= '库存' AND AF078='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM283 = string.IsNullOrEmpty( dk.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "' and AF016= '库存' and AF026='清水' AND AF078='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "' and AF016= '库存' and AF026='清水' AND AF078='T'" ) );
                    model.AM284 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"AF002='" + model.AM002 + "' and AF016= '库存' AND AF078='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"AF002='" + model.AM002 + "' and AF016= '库存' AND AF078='T' AND (AK017='执行' OR AK017='审核')" ) );

                    //model.AM280 = string.IsNullOrEmpty( dk.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "' and AF016= '库存' and AF026='混水' AND AF078='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AF)" ,"AF002='" + model.AM002 + "' and AF016= '库存' and AF026='混水'  AND AF078='F'" ) );
                    //model.AM281 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"AF002='" + model.AM002 + "' and AF016= '库存' and AF026='混水'  AND AF078='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"AF002='" + model.AM002 + "' and AF016= '库存' and AF026='混水'  AND AF078='F'" ) );
                    //model.AM285 = string.IsNullOrEmpty( dk.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "' and AF016= '库存' and AF026='混水' AND AF078='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "' and AF016= '库存' and AF026='混水'  AND AF078='T'" ) );
                    //model.AM286 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"AF002='" + model.AM002 + "' and AF016= '库存' and AF026='混水'  AND AF078='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"AF002='" + model.AM002 + "' and AF016= '库存' and AF026='混水'  AND AF078='T'" ) );

                    
                    if ( m == 0 )
                    {
                        ofSixY( model ,SQLString );
                        if ( ExistsOfCount( model.AM002 ) )
                        {
                            ofSix( model );
                            VehicleWoodPieces( model ,SQLString );
                        }
                        else
                            SQLString.Add( VehicleWoodPiecesAdd( model ) );
                    }
                    if ( m >= 1 )
                    {
                        if ( model.AM002 != dk.Rows[m - 1]["AF002"].ToString( ) )
                        {
                            ofSixY( model ,SQLString );
                            if ( ExistsOfCount( model.AM002 ) )
                            {
                                ofSix( model );
                                VehicleWoodPieces( model ,SQLString );
                            }
                            else
                                SQLString.Add( VehicleWoodPiecesAdd( model ) );
                        }
                    }
                }
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        DataTable GetDataTableOfSix ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AM271,AM274,AM278,AM281,AM275,AM282,AM284,AM286 FROM R_PQAM" );
            strSql.Append( " WHERE AM002=@AM002" );
            SqlParameter[] parameter = {
                new SqlParameter("@AM002",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        void ofSix ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            DataTable da = GetDataTableOfSix( model.AM002 );
            if ( da != null && da.Rows.Count > 0 )
            {
                model.AM271 += string.IsNullOrEmpty( da.Rows[0]["AM271"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM271"].ToString( ) );
                model.AM274 += string.IsNullOrEmpty( da.Rows[0]["AM274"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM274"].ToString( ) );
                model.AM275 += string.IsNullOrEmpty( da.Rows[0]["AM275"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM275"].ToString( ) );
                model.AM278 += string.IsNullOrEmpty( da.Rows[0]["AM278"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM278"].ToString( ) );
                model.AM281 += string.IsNullOrEmpty( da.Rows[0]["AM281"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM281"].ToString( ) );
                model.AM282 += string.IsNullOrEmpty( da.Rows[0]["AM282"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM282"].ToString( ) );
                model.AM284 += string.IsNullOrEmpty( da.Rows[0]["AM284"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM284"].ToString( ) );
                model.AM286 += string.IsNullOrEmpty( da.Rows[0]["AM286"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM286"].ToString( ) );
            }
        }
        DataTable GetDataTableOfSixY ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT A.AF001,AF002,AF016,CASE WHEN AF078='T' THEN 'T' WHEN AF078='F' OR AF078 IS NULL THEN 'F' END AF078,CASE WHEN  AF026='清水' THEN '清水' WHEN  AF026='混水' THEN '混水' END AF026,CONVERT(DECIMAL(18,2),SUM(AF023*AF006*AF019)) AF FROM R_PQAF A LEFT JOIN R_REVIEWS D ON A.AF001=D.RES06 AND RES05='执行' " );
            strSql.Append( " WHERE AF002=@AF002" );
            strSql.Append( " GROUP BY AF002,AF016,AF026,AF078,A.AF001" );
            SqlParameter[] parameter = {
                new SqlParameter("@AF002",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        void ofSixY ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            DataTable one = GetDataTableOfSixY( model.AM002 );
            if ( one != null && one.Rows.Count > 0 )
            {
                string oddNum = "";
                for ( int i = 0 ; i < one.Rows.Count ; i++ )
                {
                    oddNum = one.Rows[i]["AF001"].ToString( );
                    model.AM270 = string.IsNullOrEmpty( one.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "' AND AF001='"+oddNum+"' and AF016= '外购' AND AF078='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(AF)" ,"AF002='" + model.AM002 + "' AND AF001='" + oddNum + "'  and AF016= '外购' AND AF078='F'" ) );
                    model.AM272 = string.IsNullOrEmpty( one.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "' AND AF001='" + oddNum + "'  and AF016= '外购' AND AF078='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(AF)" ,"AF002='" + model.AM002 + "' AND AF001='" + oddNum + "'  and AF016= '外购' AND AF078='T'" ) );

                    //model.AM273 = string.IsNullOrEmpty( one.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "'  AND AF001='" + oddNum + "' and AF016= '外购' and AF026='混水' AND AF078='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "' AND AF001='" + oddNum + "'  and AF016= '外购' and AF026='混水' AND AF078='F'" ) );
                    //model.AM279 = string.IsNullOrEmpty( one.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "' AND AF001='" + oddNum + "'  and AF016= '外购' and AF026='混水' AND AF078='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "' AND AF001='" + oddNum + "'  and AF016= '外购' and AF026='混水' AND AF078='T'" ) );

                    model.AM277 = string.IsNullOrEmpty( one.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "' AND AF001='" + oddNum + "'  and AF016= '库存' AND AF078='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "' AND AF001='" + oddNum + "'  and AF016= '库存' AND AF078='F'" ) );
                    model.AM283 = string.IsNullOrEmpty( one.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "' AND AF001='" + oddNum + "'  and AF016= '库存' AND AF078='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "' AND AF001='" + oddNum + "'  and AF016= '库存' AND AF078='T'" ) );

                    //model.AM280 = string.IsNullOrEmpty( one.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "'  AND AF001='" + oddNum + "' and AF016= '库存' and AF026='混水' AND AF078='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(AF)" ,"AF002='" + model.AM002 + "' AND AF001='" + oddNum + "'  and AF016= '库存' and AF026='混水'  AND AF078='F'" ) );
                    //model.AM285 = string.IsNullOrEmpty( one.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "' AND AF001='" + oddNum + "'  and AF016= '库存' and AF026='混水' AND AF078='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "' AND AF001='" + oddNum + "'  and AF016= '库存' and AF026='混水'  AND AF078='T'" ) );
                    WriteReceivableToGeneralLedger.ByOneByChe( model ,oddNum ,SQLString );
                }

                model.AM270 = string.IsNullOrEmpty( one.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "' and AF016= '外购'  AND AF078='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(AF)" ,"AF002='" + model.AM002 + "' and AF016= '外购'  AND AF078='F'" ) );
                model.AM272 = string.IsNullOrEmpty( one.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "' and AF016= '外购'  AND AF078='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(AF)" ,"AF002='" + model.AM002 + "' and AF016= '外购' AND AF078='T'" ) );

                //model.AM273 = string.IsNullOrEmpty( one.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "' and AF016= '外购' and AF026='混水' AND AF078='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "' and AF016= '外购' and AF026='混水' AND AF078='F'" ) );
                //model.AM279 = string.IsNullOrEmpty( one.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "' and AF016= '外购' and AF026='混水' AND AF078='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "' and AF016= '外购' and AF026='混水' AND AF078='T'" ) );

                model.AM277 = string.IsNullOrEmpty( one.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "' and AF016= '库存'  AND AF078='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "' and AF016= '库存' AND AF078='F'" ) );
                model.AM283 = string.IsNullOrEmpty( one.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "' and AF016= '库存' AND AF078='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "' and AF016= '库存' AND AF078='T'" ) );

                //model.AM280 = string.IsNullOrEmpty( one.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "' and AF016= '库存' and AF026='混水' AND AF078='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(AF)" ,"AF002='" + model.AM002 + "' and AF016= '库存' and AF026='混水'  AND AF078='F'" ) );
                //model.AM285 = string.IsNullOrEmpty( one.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "' and AF016= '库存' and AF026='混水' AND AF078='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(AF)" ,"AF002='" + model.AM002 + "' and AF016= '库存' and AF026='混水'  AND AF078='T'" ) );
            }
        }

        /// <summary>
        /// 343
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqu ( string numList ,string idxList )
        {
            StringBuilder strSql = new StringBuilder( );
            //strSql.Append( "SELECT PQU01,PQU107,PQU19,CONVERT(DECIMAL(18,2),SUM(PQ)) PQ,CONVERT(DECIMAL(18,2),SUM(CASE WHEN AK>=PQ THEN PQ WHEN AK<PQ THEN AK ELSE 0 END)) AK FROM(SELECT A.idx,PQU19,PQU01,CASE WHEN PQU107='T' THEN 'T' ELSE 'F' END PQU107,SUM(PQU16*(PQU101*PQU13+PQU14)) PQ,ISNULL(AK011,0) AK FROM R_PQU A LEFT JOIN R_PQAL B ON A.PQU97=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx AND C.idx IN (" + idxList + ") INNER JOIN R_REVIEWS D ON A.PQU97=D.RES06 AND RES05='执行'" );
            //strSql.Append( " WHERE PQU01 IN (" + numList + ") AND (PQU01!='' AND PQU01 IS NOT NULL)" );//  AND LEN(PQU01)=8
            //strSql.Append( " GROUP BY PQU107,AK011,A.idx,PQU01,PQU19) A WHERE AK!=0 GROUP BY PQU107,PQU01,PQU19 ORDER BY PQU01" );

            /*
            strSql . Append ( "SELECT PQU01,PQU107,PQU19,CONVERT(DECIMAL(18,2),SUM(PQ)) PQ,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(PQ)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(PQ)) END AK,A.AK017 FROM(SELECT A.idx,PQU19,PQU01,CASE WHEN PQU107='T' THEN 'T' ELSE 'F' END PQU107,PQU16*(PQU101*PQU13+PQU14) PQ,PQU97,AK017 FROM R_PQU A LEFT JOIN R_PQAL B ON A.PQU97=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx INNER JOIN R_REVIEWS D ON A.PQU97=D.RES06 AND RES05='执行' " );
            strSql . Append ( "WHERE PQU01 IN (" + numList + ")  AND C.idx IN (" + idxList + ") AND (PQU01!='' AND PQU01 IS NOT NULL) " );
            strSql . Append ( ") A LEFT JOIN R_PQAK B ON A.PQU97=B.AK003 GROUP BY PQU107,PQU01,PQU19,ISNULL(AK011,0),A.AK017 ORDER BY PQU01" );
            */


            strSql . Append ( "SELECT PQU01,PQU107,PQU19,CONVERT(DECIMAL(18,2),SUM(PQ)) PQ,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(PQ)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(PQ)) END AK,A.AK017 FROM(SELECT A.idx,PQU19,PQU01,CASE WHEN PQU107='T' THEN 'T' ELSE 'F' END PQU107,PQU16*(PQU101*PQU13+PQU14) PQ,PQU97,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQU A LEFT JOIN R_PQAL B ON A.PQU97=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx INNER JOIN R_REVIEWS D ON A.PQU97=D.RES06 " );
            strSql . Append ( "WHERE PQU01 IN (" + numList + ")  AND RES05='执行' AND C.idx IN (" + idxList + ") AND (PQU01!='' AND PQU01 IS NOT NULL) GROUP BY A.idx,PQU19,PQU01,PQU16,PQU101,PQU13,PQU14,PQU107,PQU97,AK017 " );
            strSql . Append ( ") A GROUP BY PQU107,PQU01,PQU19,ISNULL(AK011,0),A.AK017 ORDER BY PQU01" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public void Lron ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            strSql.AppendFormat( "AM209='{0}'," ,model.AM209 );
            strSql.AppendFormat( "AM210='{0}'," ,model.AM210 );
            strSql.AppendFormat( "AM211='{0}'," ,model.AM211 );
            strSql.AppendFormat( "AM214='{0}'," ,model.AM214 );
            strSql . AppendFormat ( "AM225='{0}'," , model . AM225 );
            strSql . AppendFormat ( "AM226='{0}'," , model . AM226 );
            strSql . AppendFormat ( "AM227='{0}'," , model . AM227 );
            strSql . AppendFormat ( "AM228='{0}'" , model . AM228 );
            strSql .AppendFormat( " WHERE AM002='{0}'" ,model.AM002 );
            SQLString.Add( strSql.ToString( ) );
        }
        public string LronAdd ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            model.AM001 = generateOddNum.purchaseContract( "SELECT MAX(AJ024) AJ024 FROM R_PQAJ" ,"AJ024" ,"R_241-" );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAM (" );
            strSql.Append( "AM002,AM209,AM210,AM211,AM214,AM001,AM226,AM228,AM225,AM227)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')" , model.AM002 ,model.AM209 ,model.AM210 ,model.AM211 ,model.AM214 ,model.AM001 , model . AM226 , model . AM228 , model . AM225 , model . AM227 );

            return strSql.ToString( );
        }
        public bool Pqu ( string idxList ,string numList ,MulaolaoLibrary.ProductCostSummaryLibrary model ,DataTable dk ,ArrayList SQLString )
        {
            dk = GetDataTablePqu( numList ,idxList );
            if ( dk != null && dk.Rows.Count > 0 )
            {
                for ( int m = 0 ; m < dk.Rows.Count ; m++ )
                {
                    model.AM002 = dk.Rows[m]["PQU01"].ToString( );
                    model . AM209 = model . AM210 = model . AM211 = model . AM214 = model . AM225 = model . AM226 = model . AM227 = model . AM228 = 0;
                  
                    //model.AM209 = string.IsNullOrEmpty( dk.Compute( "SUM(PQ)" ,"PQU01='" + model.AM002 + "' AND PQU107='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(PQ)" ,"PQU01='" + model.AM002 + "' AND PQU107='F'" ) );
                    model.AM210 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQU01='" + model.AM002 + "' AND PQU107='F' AND PQU19='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQU01='" + model.AM002 + "' AND PQU107='F' AND PQU19='外购' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM211 = string.IsNullOrEmpty( dk.Compute( "SUM(PQ)" ,"PQU01='" + model.AM002 + "' AND PQU107='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(PQ)" ,"PQU01='" + model.AM002 + "' AND PQU107='T'" ) );
                    model.AM214 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQU01='" + model.AM002 + "' AND PQU107='T' AND PQU19='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQU01='" + model.AM002 + "' AND PQU107='T' AND PQU19='外购' AND (AK017='执行' OR AK017='审核')" ) );
                    model . AM226 = string . IsNullOrEmpty ( dk . Compute ( "sum(AK)" , "PQU01='" + model . AM002 + "' AND PQU107='T' AND PQU19='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dk . Compute ( "sum(AK)" , "PQU01='" + model . AM002 + "' AND PQU107='T' AND PQU19='库存' AND (AK017='执行' OR AK017='审核')" ) );
                    model . AM228 = string . IsNullOrEmpty ( dk . Compute ( "sum(AK)" , "PQU01='" + model . AM002 + "' AND PQU107='T' AND PQU19='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dk . Compute ( "sum(AK)" , "PQU01='" + model . AM002 + "' AND PQU107='T' AND PQU19='库存' AND (AK017='执行' OR AK017='审核')" ) );

                    if ( m == 0 )
                    {
                        ofSevY( model ,SQLString );
                        if ( ExistsOfCount( model.AM002 ) )
                        {
                            ofSev( model );
                            Lron( model ,SQLString );
                        }
                        else
                            SQLString.Add( LronAdd( model ) );
                    }
                    if ( m >= 1 )
                    {
                        if ( model.AM002 != dk.Rows[m - 1]["PQU01"].ToString( ) )
                        {
                            ofSevY( model ,SQLString );
                            if ( ExistsOfCount( model.AM002 ) )
                            {
                                ofSev( model );
                                Lron( model ,SQLString );
                            }
                            else
                                SQLString.Add( LronAdd( model ) );
                        }
                    }
                }
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        DataTable GetDataTableOfSev ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AM210,AM214,AM226,AM228 FROM R_PQAM" );
            strSql.Append( " WHERE AM002=@AM002" );
            SqlParameter[] parameter = {
                new SqlParameter("@AM002",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        void ofSev ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            DataTable da = GetDataTableOfSev( model.AM002 );
            if ( da != null && da.Rows.Count > 0 )
            {
                model.AM210 += string.IsNullOrEmpty( da.Rows[0]["AM210"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM210"].ToString( ) );
                model.AM214 += string.IsNullOrEmpty( da.Rows[0]["AM214"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM214"].ToString( ) );
                model . AM226 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM226" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM226" ] . ToString ( ) );
                model . AM228 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM228" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM228" ] . ToString ( ) );
            }
        }
        DataTable GetDataTableOfSevY ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT A.PQU97,PQU19,PQU01,CASE WHEN PQU107='T' THEN 'T' ELSE 'F' END PQU107,CONVERT(DECIMAL(18,2),SUM(PQU16*(PQU101*PQU13+PQU14))) PQ FROM R_PQU A LEFT JOIN R_REVIEWS D ON A.PQU97=D.RES06 AND RES05='执行'" );
            strSql.Append( " WHERE PQU01=@PQU01" );
            strSql.Append( " GROUP BY PQU107,A.PQU97,PQU01,PQU19" );
            SqlParameter[] parameter = {
                new SqlParameter("@PQU01",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        void ofSevY ( MulaolaoLibrary . ProductCostSummaryLibrary model , ArrayList SQLString )
        {
            DataTable one = GetDataTableOfSevY ( model . AM002 );
            if ( one != null && one . Rows . Count > 0 )
            {
                string oddNum = "";
                for ( int i = 0 ; i < one . Rows . Count ; i++ )
                {
                    oddNum = one . Rows [ i ] [ "PQU97" ] . ToString ( );
                    model . AM209 = string . IsNullOrEmpty ( one . Compute ( "SUM(PQ)" , "PQU01='" + model . AM002 + "' AND PQU97='" + oddNum + "' AND PQU107='F' AND PQU19='外购'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( one . Compute ( "SUM(PQ)" , "PQU01='" + model . AM002 + "' AND PQU97='" + oddNum + "'  AND PQU107='F' AND PQU19='外购'" ) );
                    model . AM211 = string . IsNullOrEmpty ( one . Compute ( "SUM(PQ)" , "PQU01='" + model . AM002 + "' AND PQU97='" + oddNum + "'  AND PQU107='T' AND PQU19='外购'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( one . Compute ( "SUM(PQ)" , "PQU01='" + model . AM002 + "' AND PQU97='" + oddNum + "'  AND PQU107='T' AND PQU19='外购'" ) );
                    model . AM225 = string . IsNullOrEmpty ( one . Compute ( "SUM(PQ)" , "PQU01='" + model . AM002 + "' AND PQU97='" + oddNum + "'  AND PQU107='T' AND PQU19='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( one . Compute ( "SUM(PQ)" , "PQU01='" + model . AM002 + "' AND PQU97='" + oddNum + "'  AND PQU107='T' AND PQU19='库存'" ) );
                    model . AM227 = string . IsNullOrEmpty ( one . Compute ( "SUM(PQ)" , "PQU01='" + model . AM002 + "' AND PQU97='" + oddNum + "'  AND PQU107='T' AND PQU19='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( one . Compute ( "SUM(PQ)" , "PQU01='" + model . AM002 + "' AND PQU97='" + oddNum + "'  AND PQU107='T' AND PQU19='库存'" ) );
                    WriteReceivableToGeneralLedger . ByOneByWu ( model , oddNum , SQLString );
                }

                model . AM209 = string . IsNullOrEmpty ( one . Compute ( "SUM(PQ)" , "PQU01='" + model . AM002 + "' AND PQU107='F' AND PQU19='外购'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( one . Compute ( "SUM(PQ)" , "PQU01='" + model . AM002 + "' AND PQU107='F' AND PQU19='外购'" ) );
                model . AM211 = string . IsNullOrEmpty ( one . Compute ( "SUM(PQ)" , "PQU01='" + model . AM002 + "' AND PQU107='T' AND PQU19='外购'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( one . Compute ( "SUM(PQ)" , "PQU01='" + model . AM002 + "' AND PQU107='T' AND PQU19='外购'" ) );
                model . AM225 = string . IsNullOrEmpty ( one . Compute ( "SUM(PQ)" , "PQU01='" + model . AM002 + "' AND PQU107='F' AND PQU19='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( one . Compute ( "SUM(PQ)" , "PQU01='" + model . AM002 + "' AND PQU107='F' AND PQU19='库存'" ) );
                model . AM227 = string . IsNullOrEmpty ( one . Compute ( "SUM(PQ)" , "PQU01='" + model . AM002 + "' AND PQU107='T' AND PQU19='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( one . Compute ( "SUM(PQ)" , "PQU01='" + model . AM002 + "' AND PQU107='T' AND PQU19='库存'" ) );
            }
        }

        /// <summary>
        /// 344 厂外漆款
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqlz ( string numList ,string idxList )
        {
            StringBuilder strSql = new StringBuilder( );
            //strSql.Append( "SELECT MZ002,MZ123,CONVERT(DECIMAL(18,2),SUM(MZ2)) MZ2,CONVERT(DECIMAL(18,2),SUM(CASE WHEN AK<MZ2 THEN AK ELSE MZ2 END)) AK FROM (SELECT MZ123,MZ002,SUM(MZ022*MZ006*MZ028*MZ024+ISNULL(MZ120,0)) MZ2,ISNULL(AK011,0) AK FROM R_PQMZ A LEFT JOIN  R_PQAL B ON A.MZ001=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx AND C.idx IN (" + idxList + ") LEFT JOIN R_REVIEWS ON MZ001=RES06 AND RES05='执行'" );
            //strSql.Append( " WHERE MZ002 IN (" + numList + ") AND (MZ002!='' AND MZ002 IS NOT NULL) AND MZ107='厂外'" );//  AND LEN(MZ002)=8
            //strSql.Append( " GROUP BY AK011,MZ002,MZ123) A WHERE AK!=0 GROUP BY MZ002,MZ123 ORDER BY MZ002" );

            /*
            strSql . Append ( "SELECT MZ002,MZ123,CONVERT(DECIMAL(18,2),SUM(MZ2)) MZ2,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(MZ2)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(MZ2)) END AK,A.AK017 FROM (SELECT MZ123,MZ002,MZ022*MZ006*MZ028*MZ024+ISNULL(MZ120,0) MZ2,MZ001,AK017 FROM R_PQMZ A LEFT JOIN  R_PQAL B ON A.MZ001=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx  LEFT JOIN R_REVIEWS ON MZ001=RES06 AND RES05='执行' " );
            strSql . Append ( "WHERE MZ002 IN (" + numList + ") AND C.idx IN (" + idxList + ") AND (MZ002!='' AND MZ002 IS NOT NULL) AND MZ107='厂外' " );
            strSql . Append ( ") A LEFT JOIN R_PQAK B ON A.MZ001=B.AK003 GROUP BY MZ002,MZ123,ISNULL(AK011,0),A.AK017 ORDER BY MZ002" );
            */

            strSql . Append ( "SELECT MZ002,MZ123,CONVERT(DECIMAL(18,2),SUM(MZ2)) MZ2,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(MZ2)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(MZ2)) END AK,A.AK017 FROM (SELECT A.idx,MZ123,MZ002,MZ022*MZ006*MZ028*MZ024+ISNULL(MZ120,0) MZ2,MZ001,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQMZ A LEFT JOIN  R_PQAL B ON A.MZ001=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx  LEFT JOIN R_REVIEWS ON MZ001=RES06  " );
            strSql . Append ( " WHERE MZ002 IN (" + numList + ")  AND RES05='执行' AND C.idx IN (" + idxList + ") AND (MZ002!='' AND MZ002 IS NOT NULL) AND MZ107='厂外' GROUP BY MZ123,MZ002,MZ022,MZ006,MZ028,MZ024,MZ120,MZ001,AK017,A.idx " );
            strSql . Append ( ") A GROUP BY MZ002,MZ123,ISNULL(AK011,0),A.AK017 ORDER BY MZ002" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public void GunPaint ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            //strSql.AppendFormat( "AM239='{0}'," ,model.AM239 );
            //strSql.AppendFormat( "AM240='{0}'," ,model.AM240 );
            //strSql.AppendFormat( "AM241='{0}'," ,model.AM241 );
            strSql.AppendFormat( "AM242='{0}'," ,model.AM242 );
            strSql.AppendFormat( "AM243='{0}'," ,model.AM243 );
            //strSql.AppendFormat( "AM244='{0}'," ,model.AM244 );
            strSql.AppendFormat( "AM245='{0}'," ,model.AM245 );
            strSql.AppendFormat( "AM246='{0}'," ,model.AM246 );
            strSql.AppendFormat( "AM247='{0}'," ,model.AM247 );
            strSql.AppendFormat( "AM251='{0}'," ,model.AM251 );
            strSql.AppendFormat( "AM252='{0}'," ,model.AM252 );
            strSql.AppendFormat( "AM253='{0}'" ,model.AM253 );
            strSql.AppendFormat( " WHERE AM002='{0}'" ,model.AM002 );
            SQLString.Add( strSql.ToString( ) );
        }
        public string GunPaintAdd ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            model.AM001 = generateOddNum.purchaseContract( "SELECT MAX(AJ024) AJ024 FROM R_PQAJ" ,"AJ024" ,"R_241-" );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAM (" );
            strSql.Append( "AM002,AM242,AM243,AM245,AM246,AM247,AM001,AM051,AM052,AM053)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')" ,model.AM002 ,model.AM242 ,model.AM243 ,model.AM245 ,model.AM246 ,model.AM247 ,model.AM001 ,model.AM251 ,model.AM252 ,model.AM253 );

            return strSql.ToString( );
        }
        public bool Pqlz ( string idxList ,string numList ,MulaolaoLibrary.ProductCostSummaryLibrary model ,DataTable dk ,ArrayList SQLString )
        {
            dk = GetDataTablePqlz( numList ,idxList );
            if ( dk != null && dk.Rows.Count > 0 )
            {
                for ( int m = 0 ; m < dk.Rows.Count ; m++ )
                {
                    model.AM002 = dk.Rows[m]["MZ002"].ToString( );

                     model.AM242 = model.AM243 = model.AM247 = model.AM251 = model.AM245 = model.AM246 = model.AM252 = model.AM253 = 0M;

                    //model.AM242 = string.IsNullOrEmpty( dk.Compute( "SUM(MZ2)" ,"MZ002='" + model.AM002 + "'  AND MZ123='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(MZ2)" ,"MZ002='" + model.AM002 + "'  AND MZ123='F'" ) );
                    model.AM243 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"MZ002='" + model.AM002 + "'  AND MZ123='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"MZ002='" + model.AM002 + "'  AND MZ123='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM247 = string.IsNullOrEmpty( dk.Compute( "SUM(MZ2)" ,"MZ002='" + model.AM002 + "'  AND MZ123='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(MZ2)" ,"MZ002='" + model.AM002 + "'  AND MZ123='T'" ) );
                    model.AM251 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"MZ002='" + model.AM002 + "'  AND MZ123='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"MZ002='" + model.AM002 + "' AND MZ123='T' AND (AK017='执行' OR AK017='审核')" ) );

                   
                    if ( m == 0 )
                    {
                        ofEgiY( model ,SQLString );
                        if ( ExistsOfCount( model.AM002 ) )
                        {
                            ofEgi( model );
                            GunPaint( model ,SQLString );
                        }
                        else
                            SQLString.Add( GunPaintAdd( model ) );
                    }

                    if ( m >= 1 )
                    {
                        if ( model.AM002 != dk.Rows[m - 1]["MZ002"].ToString( ) )
                        {
                            ofEgiY( model ,SQLString );
                            if ( ExistsOfCount( model.AM002 ) )
                            {
                                ofEgi( model );
                                GunPaint( model ,SQLString );
                            }
                            else
                                SQLString.Add( GunPaintAdd( model ) );
                        }
                    }
                }
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        DataTable GetDataTableOfEgi ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AM243,AM246,AM251,AM253 FROM R_PQAM" );
            strSql.Append( " WHERE AM002=@AM002" );
            SqlParameter[] parameter = {
                new SqlParameter("@AM002",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        void ofEgi ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            DataTable da = GetDataTableOfEgi( model.AM002 );
            if ( da != null && da.Rows.Count > 0 )
            {
                model.AM243 += string.IsNullOrEmpty( da.Rows[0]["AM243"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM243"].ToString( ) );
                model.AM246 += string.IsNullOrEmpty( da.Rows[0]["AM246"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM246"].ToString( ) );
                model.AM251 += string.IsNullOrEmpty( da.Rows[0]["AM251"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM251"].ToString( ) );
                model.AM253 += string.IsNullOrEmpty( da.Rows[0]["AM253"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM253"].ToString( ) );
            }
        }
        DataTable GetDataTableofEgiY ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT MZ001,MZ123,MZ002,CONVERT(DECIMAL(18,2),SUM(MZ022*MZ006*MZ028*MZ024+ISNULL(MZ120,0))) MZ2 FROM R_PQMZ A LEFT JOIN R_REVIEWS ON MZ001=RES06 AND RES05='执行'" );
            strSql.Append( " WHERE MZ002=@MZ002 AND MZ107='厂外'" );
            strSql.Append( " GROUP BY MZ002,MZ123,MZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@MZ002",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        void ofEgiY ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            DataTable one = GetDataTableofEgiY( model.AM002 );
            if ( one != null && one.Rows.Count > 0 )
            {
                string oddNum = "";
                for ( int i = 0 ; i < one.Rows.Count ; i++ )
                {
                    oddNum = one.Rows[i]["MZ001"].ToString( );
                    model.AM242 = string.IsNullOrEmpty( one.Compute( "SUM(MZ2)" ,"MZ002='" + model.AM002 + "' AND MZ001='"+oddNum+"'  AND MZ123='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(MZ2)" ,"MZ002='" + model.AM002 + "' AND MZ001='" + oddNum + "'   AND MZ123='F'" ) );
                    model.AM247 = string.IsNullOrEmpty( one.Compute( "SUM(MZ2)" ,"MZ002='" + model.AM002 + "' AND MZ001='" + oddNum + "'   AND MZ123='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(MZ2)" ,"MZ002='" + model.AM002 + "' AND MZ001='" + oddNum + "'   AND MZ123='T'" ) );
                    WriteReceivableToGeneralLedger.ByOneByQi( model ,oddNum ,SQLString );
                }
                model.AM242 = string.IsNullOrEmpty( one.Compute( "SUM(MZ2)" ,"MZ002='" + model.AM002 + "'  AND MZ123='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(MZ2)" ,"MZ002='" + model.AM002 + "'  AND MZ123='F'" ) );
                model.AM247 = string.IsNullOrEmpty( one.Compute( "SUM(MZ2)" ,"MZ002='" + model.AM002 + "'  AND MZ123='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(MZ2)" ,"MZ002='" + model.AM002 + "'  AND MZ123='T'" ) );
            }
        }

        /// <summary>
        /// 344  工资
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqmz ( string numList ,string idxList )
        {
            StringBuilder strSql = new StringBuilder( );
            //strSql.Append( "SELECT MZ002,CONVERT(DECIMAL(18,2),SUM(MZ0)) MZ0,CONVERT(DECIMAL(18,2),SUM(CASE WHEN AK>=MZ0 THEN MZ0 WHEN AK<MZ0 THEN AK ELSE 0 END)) AK FROM (SELECT MZ002,CASE WHEN MZ107='厂内' THEN SUM(MZ022*MZ006*MZ027+ISNULL(MZ118,0)) ELSE 0 END MZ0,ISNULL(AK011,0) AK FROM R_PQMZ A LEFT JOIN R_PQAL B ON A.MZ001=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx AND C.idx IN (" + idxList + ") LEFT JOIN R_REVIEWS ON MZ001=RES06 AND RES05='执行'" );
            //strSql.Append( " WHERE MZ002 IN (" + numList + ") AND (MZ002!='' AND MZ002 IS NOT NULL)" );//  AND LEN(MZ002)=8
            //strSql.Append( " GROUP BY MZ002,AK011,MZ107) A WHERE AK!=0 GROUP BY MZ002 ORDER BY MZ002" );

            /*
            strSql . Append ( "SELECT MZ002,CONVERT(DECIMAL(18,2),SUM(MZ0)) MZ0,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(MZ0)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(MZ0)) END AK,A.AK017 FROM (SELECT MZ002,CASE WHEN MZ107='厂内' THEN MZ022*MZ006*MZ027+ISNULL(MZ118,0) ELSE 0 END MZ0,MZ001,AK017 FROM R_PQMZ A LEFT JOIN R_PQAL B ON A.MZ001=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx LEFT JOIN R_REVIEWS ON MZ001=RES06 AND RES05='执行' " );
            strSql . Append ( "WHERE MZ002 IN (" + numList + ")  AND C.idx IN (" + idxList + ") AND (MZ002!='' AND MZ002 IS NOT NULL) " );
            strSql . Append ( ") A LEFT JOIN R_PQAK B ON A.MZ001=B.AK003 GROUP BY MZ002,ISNULL(AK011,0),A.AK017 ORDER BY MZ002" );
            */
            
            strSql . Append ( "SELECT MZ002,CONVERT(DECIMAL(18,2),SUM(MZ0)) MZ0,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(MZ0)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(MZ0)) END AK,A.AK017 FROM (SELECT A.idx,MZ002,CASE WHEN MZ107='厂内' THEN MZ022*MZ006*MZ027+ISNULL(MZ118,0) ELSE 0 END MZ0,MZ001,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQMZ A LEFT JOIN R_PQAL B ON A.MZ001=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx LEFT JOIN R_REVIEWS ON MZ001=RES06 " );
            strSql . Append ( " WHERE MZ002 IN (" + numList + ")  AND RES05='执行' AND C.idx IN (" + idxList + ") AND (MZ002!='' AND MZ002 IS NOT NULL)  GROUP BY MZ002,MZ107,MZ022,MZ006,MZ027,MZ118,MZ001,AK017,A.idx " );
            strSql . Append ( ") A GROUP BY MZ002,ISNULL(AK011,0),A.AK017 ORDER BY MZ002" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public void GunPaintOther ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            strSql.AppendFormat( "AM249='{0}'," ,model.AM249 );
            strSql.AppendFormat( "AM250='{0}'" ,model.AM250 );
            strSql.AppendFormat( " WHERE AM002='{0}'" ,model.AM002 );
            SQLString.Add( strSql.ToString( ) );
        }
        public string GunPaintOtherAdd ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            model.AM001 = generateOddNum.purchaseContract( "SELECT MAX(AJ024) AJ024 FROM R_PQAJ" ,"AJ024" ,"R_241-" );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAM (" );
            strSql.Append( "AM002,AM249,AM250,AM001)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}')" ,model.AM002 ,model.AM249 ,model.AM250 ,model.AM001 );

            return strSql.ToString( );
        }
        public bool Pqmz ( string idxList ,string numList ,MulaolaoLibrary.ProductCostSummaryLibrary model ,DataTable dk ,ArrayList SQLString )
        {
            dk = GetDataTablePqmz( numList ,idxList );
            if ( dk != null && dk.Rows.Count > 0 )
            {
                for ( int m = 0 ; m < dk.Rows.Count ; m++ )
                {
                    model.AM002 = dk.Rows[m]["MZ002"].ToString( );

                    model.AM249 = model.AM250 = 0M;
                    //model.AM249 = string.IsNullOrEmpty( dk.Compute( "SUM(MZ0)" ,"MZ002='" + model.AM002 + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(MZ0)" ,"MZ002='" + model.AM002 + "'" ) );
                    model.AM250 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"MZ002='" + model.AM002 + "' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"MZ002='" + model.AM002 + "' AND (AK017='执行' OR AK017='审核')" ) );

                    
                    if ( m == 0 )
                    {
                        ofNinY( model ,SQLString );
                        if ( ExistsOfCount( model.AM002 ) )
                        {
                            ofNin( model );
                            GunPaintOther( model ,SQLString );
                        }
                        else
                            SQLString.Add( GunPaintOtherAdd( model ) );
                    }
                    if ( m >= 1 )
                    {
                        if ( model.AM002 != dk.Rows[m - 1]["MZ002"].ToString( ) )
                        {
                            ofNinY( model ,SQLString );
                            if ( ExistsOfCount( model.AM002 ) )
                            {
                                ofNin( model );
                                GunPaintOther( model ,SQLString );
                            }
                            else
                                SQLString.Add( GunPaintOtherAdd( model ) );
                        }
                    }
                }
            }
            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        DataTable GetDataTableOfNin ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AM250 FROM R_PQAM" );
            strSql.Append( " WHERE AM002=@AM002" );
            SqlParameter[] parameter = {
                new SqlParameter("@AM002",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        void ofNin ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            DataTable da = GetDataTableOfNin( model.AM002 );
            if ( da != null && da.Rows.Count > 0 )
            {
                model.AM250 += string.IsNullOrEmpty( da.Rows[0]["AM250"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM250"].ToString( ) );
            }
        }
        DataTable GetDataTableofNinY ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT MZ001,MZ002,CONVERT(DECIMAL(18,2),CASE WHEN MZ107='厂内' THEN SUM(MZ022*MZ006*MZ027+ISNULL(MZ118,0)) ELSE 0 END) MZ0 FROM R_PQMZ A LEFT JOIN R_REVIEWS ON MZ001=RES06 AND RES05='执行'" );
            strSql.Append( " WHERE MZ002=@MZ002" );
            strSql.Append( " GROUP BY MZ002,MZ107,MZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@MZ002",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        void ofNinY ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            DataTable one = GetDataTableofNinY( model.AM002 );
            if ( one != null && one.Rows.Count > 0 )
            {
                string oddNum = "";
                for ( int i = 0 ; i < one.Rows.Count ; i++ )
                {
                    oddNum = one.Rows[i]["MZ001"].ToString( );
                    model.AM249 = string.IsNullOrEmpty( one.Compute( "SUM(MZ0)" ,"MZ002='" + model.AM002 + "' AND MZ001='"+oddNum+"'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(MZ0)" ,"MZ002='" + model.AM002 + "' AND MZ001='" + oddNum + "'" ) );
                    WriteReceivableToGeneralLedger.ByOneByQi( model ,oddNum ,SQLString );
                }
                model.AM249 = string.IsNullOrEmpty( one.Compute( "SUM(MZ0)" ,"MZ002='" + model.AM002 + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(MZ0)" ,"MZ002='" + model.AM002 + "'" ) );
            }
        }

        /// <summary>
        /// 获取347数据
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqsTwo ( string numList ,string idxList )
        {            StringBuilder strSql = new StringBuilder( );
            //strSql.Append( "SELECT PJ01,PJ15,PJ100,PJ105,CONVERT(DECIMAL(18,2),SUM(PQ)) PQ,CONVERT(DECIMAL(18,2),SUM(CASE WHEN AK>=PQ THEN PQ WHEN AK<PQ THEN AK ELSE 0 END)) AK FROM (SELECT A.idx,PJ15,PJ01,CASE WHEN PJ100='T' THEN 'T' ELSE 'F' END PJ100,PJ09,ISNULL(AK011,0) AK,SUM(PJ12*(PJ11*PJ96+PJ10)) PQ,PJ105 FROM R_PQS A LEFT JOIN R_PQAL B ON A.PJ92=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx AND C.idx IN (" + idxList + ") LEFT JOIN R_REVIEWS D ON A.PJ92=D.RES06 AND RES01='R_347' AND RES05='执行'" );
            //strSql.Append( " WHERE PJ01 IN (" + numList + ") AND (PJ01!='' AND PJ01 IS NOT NULL)" );// AND LEN(PJ01)=8
            //strSql.Append( " GROUP BY PJ100,AK011,PJ09,A.idx,PJ105,PJ01,PJ15) A WHERE AK!=0 GROUP BY PJ100,PJ105,PJ01,PJ15 ORDER BY PJ01" );

            /*
            strSql . Append ( "SELECT PJ01,PJ15,PJ100,PJ105,CONVERT(DECIMAL(18,2),SUM(PQ)) PQ,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(PQ)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(PQ)) END AK,A.AK017 FROM (SELECT A.idx,PJ15,PJ01,CASE WHEN PJ100='T' THEN 'T' ELSE 'F' END PJ100,PJ09,PJ12*(PJ11*PJ96+PJ10) PQ,PJ105,PJ92,AK017 FROM R_PQS A LEFT JOIN R_PQAL B ON A.PJ92=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx LEFT JOIN R_REVIEWS D ON A.PJ92=D.RES06 AND RES01='R_347' AND RES05='执行' " );
            strSql . Append ( "WHERE PJ01 IN (" + numList + ")  AND C.idx IN (" + idxList + ") AND (PJ01!='' AND PJ01 IS NOT NULL) " );
            strSql . Append ( ") A LEFT JOIN R_PQAK B ON A.PJ92=B.AK003 GROUP BY PJ100,PJ105,PJ01,PJ15,ISNULL(AK011,0),A.AK017 ORDER BY PJ01" );
            */

            strSql . Append ( "SELECT PJ01,PJ15,PJ100,PJ105,CONVERT(DECIMAL(18,2),SUM(PQ)) PQ,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(PQ)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(PQ)) END AK,A.AK017 FROM (SELECT A.idx,PJ15,PJ01,CASE WHEN PJ100='T' THEN 'T' ELSE 'F' END PJ100,PJ09,PJ12*(PJ11*PJ96+PJ10) PQ,PJ105,PJ92,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQS A LEFT JOIN R_PQAL B ON A.PJ92=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx LEFT JOIN R_REVIEWS D ON A.PJ92=D.RES06 " );
            strSql . Append ( " WHERE PJ01 IN (" + numList + ")  AND RES01='R_347' AND RES05='执行' AND C.idx IN (" + idxList + ") AND (PJ01!='' AND PJ01 IS NOT NULL)  GROUP BY A.idx,PJ15,PJ01,PJ100,PJ09,PJ12,PJ11,PJ96,PJ10,PJ105,PJ92,AK017 " );
            strSql . Append ( ") A GROUP BY PJ100,PJ105,PJ01,PJ15,A.AK017,ISNULL(AK011,0) ORDER BY PJ01" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public void LronOther ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            strSql.AppendFormat( "AM212='{0}'," ,model.AM212 );
            strSql.AppendFormat( "AM213='{0}'," ,model.AM213 );
            strSql.AppendFormat( "AM215='{0}'," ,model.AM215 );
            strSql.AppendFormat( "AM216='{0}'," ,model.AM216 );
            strSql.AppendFormat( "AM217='{0}'," ,model.AM217 );
            strSql.AppendFormat( "AM218='{0}'," ,model.AM218 );
            strSql.AppendFormat( "AM219='{0}'," ,model.AM219 );
            strSql.AppendFormat( "AM220='{0}'," ,model.AM220 );
            strSql.AppendFormat( "AM221='{0}'," ,model.AM221 );
            strSql.AppendFormat( "AM222='{0}'," ,model.AM222 );
            strSql.AppendFormat( "AM223='{0}'," ,model.AM223 );
            strSql.AppendFormat( "AM224='{0}'," ,model.AM224 );
            strSql . AppendFormat ( "AM229='{0}'," , model . AM229 );
            strSql . AppendFormat ( "AM230='{0}'," , model . AM230 );
            strSql . AppendFormat ( "AM231='{0}'," , model . AM231 );
            strSql . AppendFormat ( "AM232='{0}'," , model . AM232 );
            strSql . AppendFormat ( "AM233='{0}'," , model . AM233 );
            strSql . AppendFormat ( "AM234='{0}'," , model . AM234 );
            strSql . AppendFormat ( "AM235='{0}'," , model . AM235 );
            strSql . AppendFormat ( "AM236='{0}'," , model . AM236 );
            strSql . AppendFormat ( "AM237='{0}'," , model . AM237 );
            strSql . AppendFormat ( "AM238='{0}'," , model . AM238 );
            strSql . AppendFormat ( "AM255='{0}'," , model . AM255 );
            strSql . AppendFormat ( "AM256='{0}'" , model . AM256 );
            strSql .AppendFormat( " WHERE AM002='{0}'" ,model.AM002 );
            SQLString.Add( strSql.ToString( ) );
        }
        public string LronOtherAdd ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            model.AM001 = generateOddNum.purchaseContract( "SELECT MAX(AJ024) AJ024 FROM R_PQAJ" ,"AJ024" ,"R_241-" );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAM (" );
            strSql.Append( "AM002,AM212,AM213,AM215,AM216,AM217,AM218,AM219,AM220,AM001,AM221,AM222,AM223,AM224,AM229,AM230,AM231,AM232,AM233,AM234,AM235,AM236,AM237,AM238,AM255,AM256)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}')" , model.AM002 ,model.AM212 ,model.AM213 ,model.AM215 ,model.AM216 ,model.AM217 ,model.AM218 ,model.AM219 ,model.AM220 ,model.AM001 ,model.AM221 ,model.AM222 ,model.AM223 ,model.AM224 , model . AM229 , model . AM230 , model . AM231 , model . AM232 , model . AM233 , model . AM234 , model . AM235 , model . AM236 , model . AM237 , model . AM238 , model . AM255 , model . AM256 );

            return strSql.ToString( );
        }
        public bool Pqs ( string idxList ,string numList ,MulaolaoLibrary.ProductCostSummaryLibrary model ,DataTable dk ,ArrayList SQLString )
        {
            dk = GetDataTablePqsTwo( numList ,idxList );
            if ( dk != null && dk.Rows.Count > 0 )
            {
                for ( int m = 0 ; m < dk.Rows.Count ; m++ )
                {
                    model.AM002 = dk.Rows[m]["PJ01"].ToString( );

                    model.AM212 = model.AM213 = model.AM217 = model.AM220 = model.AM215 = model.AM216 = model.AM221 = model.AM222 = model.AM218 = model.AM219 = model.AM223 = model.AM224 = model . AM229 = model . AM230 = model . AM231 = model . AM232 = model . AM233 = model . AM234 = model . AM235 = model . AM236 = model . AM237 = model . AM238 = model . AM255 = model . AM256 = 0;

                    //model.AM218 = string.IsNullOrEmpty( dk.Compute( "SUM(PQ)" ,"PJ01='" + model.AM002 + "' and PJ105='包装辅料' AND PJ100='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(PQ)" ,"PJ01='" + model.AM002 + "' and PJ105='包装辅料' AND PJ100='F'" ) );
                    model.AM219 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"PJ01='" + model.AM002 + "' and PJ105='包装辅料' AND PJ100='F' AND PJ15='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PJ01='" + model.AM002 + "' and PJ105='包装辅料' AND PJ100='F' AND PJ15='外购' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM223 = string.IsNullOrEmpty( dk.Compute( "SUM(PQ)" ,"PJ01='" + model.AM002 + "' and PJ105='包装辅料' AND PJ100='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(PQ)" ,"PJ01='" + model.AM002 + "' and PJ105='包装辅料' AND PJ100='T'" ) );
                    model.AM224 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"PJ01='" + model.AM002 + "' and PJ105='包装辅料' AND PJ100='T' AND PJ15='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PJ01='" + model.AM002 + "' and PJ105='包装辅料' AND PJ100='T' AND PJ15='外购' AND (AK017='执行' OR AK017='审核')" ) );
                    model . AM238 = string . IsNullOrEmpty ( dk . Compute ( "SUM(AK)" , "PJ01='" + model . AM002 + "' and PJ105='包装辅料' AND PJ100='F' AND PJ15='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dk . Compute ( "sum(AK)" , "PJ01='" + model . AM002 + "' and PJ105='包装辅料' AND PJ100='F' AND PJ15='库存' AND (AK017='执行' OR AK017='审核')" ) );
                    model . AM256 = string . IsNullOrEmpty ( dk . Compute ( "SUM(AK)" , "PJ01='" + model . AM002 + "' and PJ105='包装辅料' AND PJ100='T' AND PJ15='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dk . Compute ( "sum(AK)" , "PJ01='" + model . AM002 + "' and PJ105='包装辅料' AND PJ100='T' AND PJ15='库存' AND (AK017='执行' OR AK017='审核')" ) );

                    //model.AM215 = string.IsNullOrEmpty( dk.Compute( "SUM(PQ)" ,"PJ01='" + model.AM002 + "' and PJ105='其它材料' AND PJ100='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(PQ)" ,"PJ01='" + model.AM002 + "' and PJ105='其它材料' AND PJ100='F'" ) );
                    model .AM216 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"PJ01='" + model.AM002 + "' and PJ105='其它材料' AND PJ100='F' AND PJ15='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PJ01='" + model.AM002 + "' and PJ105='其它材料' AND PJ100='F' AND PJ15='外购' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM221 = string.IsNullOrEmpty( dk.Compute( "SUM(PQ)" ,"PJ01='" + model.AM002 + "' and PJ105='其它材料' AND PJ100='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(PQ)" ,"PJ01='" + model.AM002 + "' and PJ105='其它材料' AND PJ100='T'" ) );
                    model.AM222 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"PJ01='" + model.AM002 + "' and PJ105='其它材料' AND PJ100='T' AND PJ15='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PJ01='" + model.AM002 + "' and PJ105='其它材料' AND PJ100='T' AND PJ15='外购' AND (AK017='执行' OR AK017='审核')" ) );
                    model . AM234 = string . IsNullOrEmpty ( dk . Compute ( "SUM(AK)" , "PJ01='" + model . AM002 + "' and PJ105='其它材料' AND PJ100='F' AND PJ15='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dk . Compute ( "sum(AK)" , "PJ01='" + model . AM002 + "' and PJ105='其它材料' AND PJ100='F' AND PJ15='库存' AND (AK017='执行' OR AK017='审核')" ) );
                    model . AM236 = string . IsNullOrEmpty ( dk . Compute ( "SUM(AK)" , "PJ01='" + model . AM002 + "' and PJ105='其它材料' AND PJ100='T' AND PJ15='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dk . Compute ( "sum(AK)" , "PJ01='" + model . AM002 + "' and PJ105='其它材料' AND PJ100='T' AND PJ15='库存' AND (AK017='执行' OR AK017='审核')" ) );

                    //model.AM212 = string.IsNullOrEmpty( dk.Compute( "SUM(PQ)" ,"PJ01='" + model.AM002 + "' and PJ105='塑料件' AND PJ100='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(PQ)" ,"PJ01='" + model.AM002 + "' and PJ105='塑料件' AND PJ100='F'" ) );
                    model .AM213 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"PJ01='" + model.AM002 + "' and PJ105='塑料件' AND PJ100='F' AND PJ15='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PJ01='" + model.AM002 + "' and PJ105='塑料件' AND PJ100='F' AND PJ15='外购' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM217 = string.IsNullOrEmpty( dk.Compute( "SUM(PQ)" ,"PJ01='" + model.AM002 + "' and PJ105='塑料件' AND PJ100='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(PQ)" ,"PJ01='" + model.AM002 + "' and PJ105='塑料件' AND PJ100='T'" ) );
                    model.AM220 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"PJ01='" + model.AM002 + "' and PJ105='塑料件' AND PJ100='T' AND PJ15='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"PJ01='" + model.AM002 + "' and PJ105='塑料件' AND PJ100='T' AND PJ15='外购' AND (AK017='执行' OR AK017='审核')" ) );
                    model . AM230 = string . IsNullOrEmpty ( dk . Compute ( "SUM(AK)" , "PJ01='" + model . AM002 + "' and PJ105='塑料件' AND PJ100='F' AND PJ15='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dk . Compute ( "SUM(AK)" , "PJ01='" + model . AM002 + "' and PJ105='塑料件' AND PJ100='F' AND PJ15='库存' AND (AK017='执行' OR AK017='审核')" ) );
                    model . AM232 = string . IsNullOrEmpty ( dk . Compute ( "SUM(AK)" , "PJ01='" + model . AM002 + "' and PJ105='塑料件' AND PJ100='T' AND PJ15='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dk . Compute ( "SUM(AK)" , "PJ01='" + model . AM002 + "' and PJ105='塑料件' AND PJ100='T' AND PJ15='库存' AND (AK017='执行' OR AK017='审核')" ) );

                    if ( m == 0 )
                    {
                        ofTenY( model ,SQLString );
                        if ( ExistsOfCount( model.AM002 ) )
                        {
                            ofTen( model );
                            LronOther( model ,SQLString );
                        }
                        else
                            SQLString.Add( LronOtherAdd( model ) );
                    }
                    if ( m >= 1 )
                    {
                        if ( model.AM002 != dk.Rows[m - 1]["PJ01"].ToString( ) )
                        {
                            ofTenY( model ,SQLString );
                            if ( ExistsOfCount( model.AM002 ) )
                            {
                                ofTen( model );
                                LronOther( model ,SQLString );
                            }
                            else
                                SQLString.Add( LronOtherAdd( model ) );
                        }
                    }
                }
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        DataTable GetDataTableOfTen ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AM213,AM216,AM219,AM220,AM222,AM224,AM230,AM232,AM234,AM236,AM238,AM256 FROM R_PQAM" );
            strSql.Append( " WHERE AM002=@AM002" );
            SqlParameter[] parameter = {
                new SqlParameter("@AM002",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        void ofTen ( MulaolaoLibrary . ProductCostSummaryLibrary model )
        {
            DataTable da = GetDataTableOfTen ( model . AM002 );
            if ( da != null && da . Rows . Count > 0 )
            {
                model . AM213 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM213" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM213" ] . ToString ( ) );
                model . AM216 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM216" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM216" ] . ToString ( ) );
                model . AM219 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM219" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM219" ] . ToString ( ) );
                model . AM220 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM220" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM220" ] . ToString ( ) );
                model . AM222 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM222" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM222" ] . ToString ( ) );
                model . AM224 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM224" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM224" ] . ToString ( ) );
                model . AM230 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM230" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM230" ] . ToString ( ) );
                model . AM232 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM232" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM232" ] . ToString ( ) );
                model . AM234 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM234" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM234" ] . ToString ( ) );
                model . AM236 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM236" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM236" ] . ToString ( ) );
                model . AM238 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM238" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM238" ] . ToString ( ) );
                model . AM256 += string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM256" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM256" ] . ToString ( ) );
            }
        }
        DataTable GetDataTableOfTenY ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT A.PJ92,PJ15,PJ01,CASE WHEN PJ100='T' THEN 'T' ELSE 'F' END PJ100,CONVERT(DECIMAL(18,2),SUM(PJ12*(PJ11*PJ96+PJ10))) PQ,PJ105 FROM R_PQS A LEFT JOIN R_REVIEWS D ON A.PJ92=D.RES06 AND RES01='R_347' AND RES05='执行'" );
            strSql.Append( " WHERE PJ01=@PJ01" );
            strSql.Append( " GROUP BY PJ100,A.PJ92,PJ105,PJ01,PJ15" );
            SqlParameter[] parameter = {
                new SqlParameter("@PJ01",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        void ofTenY ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            DataTable one = GetDataTableOfTenY( model.AM002 );
            if ( one != null && one.Rows.Count > 0 )
            {
                string oddNum = "";
                for ( int i = 0 ; i < one.Rows.Count ; i++ )
                {
                    oddNum = one.Rows[i]["PJ92"].ToString( );
                    model.AM218 = string.IsNullOrEmpty( one.Compute( "SUM(PQ)" ,"PJ01='" + model.AM002 + "' and PJ105='包装辅料' AND PJ100='F' AND PJ92='"+oddNum+ "' AND PJ15='外购'" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(PQ)" ,"PJ01='" + model.AM002 + "' and PJ105='包装辅料' AND PJ100='F' AND PJ92='" + oddNum + "' AND PJ15='外购'" ) );
                    model.AM223 = string.IsNullOrEmpty( one.Compute( "SUM(PQ)" ,"PJ01='" + model.AM002 + "' and PJ105='包装辅料' AND PJ100='T' AND PJ92='" + oddNum + "' AND PJ15='外购'" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(PQ)" ,"PJ01='" + model.AM002 + "' and PJ105='包装辅料' AND PJ100='T' AND PJ92='" + oddNum + "' AND PJ15='外购'" ) );
                    model . AM237 = string . IsNullOrEmpty ( one . Compute ( "SUM(PQ)" , "PJ01='" + model . AM002 + "' and PJ105='包装辅料' AND PJ100='F' AND PJ92='" + oddNum + "' AND PJ15='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( one . Compute ( "SUM(PQ)" , "PJ01='" + model . AM002 + "' and PJ105='包装辅料' AND PJ100='F' AND PJ92='" + oddNum + "' AND PJ15='库存'" ) );
                    model . AM255 = string . IsNullOrEmpty ( one . Compute ( "SUM(PQ)" , "PJ01='" + model . AM002 + "' and PJ105='包装辅料' AND PJ100='T' AND PJ92='" + oddNum + "' AND PJ15='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( one . Compute ( "SUM(PQ)" , "PJ01='" + model . AM002 + "' and PJ105='包装辅料' AND PJ100='T' AND PJ92='" + oddNum + "' AND PJ15='库存'" ) );

                    model .AM215 = string.IsNullOrEmpty( one.Compute( "SUM(PQ)" ,"PJ01='" + model.AM002 + "' and PJ105='其它材料' AND PJ100='F' AND PJ92='" + oddNum + "' AND PJ15='外购'" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(PQ)" ,"PJ01='" + model.AM002 + "' and PJ105='其它材料' AND PJ100='F' AND PJ92='" + oddNum + "' AND PJ15='外购'" ) );
                    model.AM221 = string.IsNullOrEmpty( one.Compute( "SUM(PQ)" ,"PJ01='" + model.AM002 + "' and PJ105='其它材料' AND PJ100='T' AND PJ92='" + oddNum + "' AND PJ15='外购'" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(PQ)" ,"PJ01='" + model.AM002 + "' and PJ105='其它材料' AND PJ100='T' AND PJ92='" + oddNum + "' AND PJ15='外购'" ) );
                    model . AM233 = string . IsNullOrEmpty ( one . Compute ( "SUM(PQ)" , "PJ01='" + model . AM002 + "' and PJ105='其它材料' AND PJ100='F' AND PJ92='" + oddNum + "' AND PJ15='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( one . Compute ( "SUM(PQ)" , "PJ01='" + model . AM002 + "' and PJ105='其它材料' AND PJ100='F' AND PJ92='" + oddNum + "' AND PJ15='库存'" ) );
                    model . AM235 = string . IsNullOrEmpty ( one . Compute ( "SUM(PQ)" , "PJ01='" + model . AM002 + "' and PJ105='其它材料' AND PJ100='T' AND PJ92='" + oddNum + "' AND PJ15='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( one . Compute ( "SUM(PQ)" , "PJ01='" + model . AM002 + "' and PJ105='其它材料' AND PJ100='T' AND PJ92='" + oddNum + "' AND PJ15='库存'" ) );

                    model .AM212 = string.IsNullOrEmpty( one.Compute( "SUM(PQ)" ,"PJ01='" + model.AM002 + "' and PJ105='塑料件' AND PJ100='F' AND PJ92='" + oddNum + "' AND PJ15='外购'" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(PQ)" ,"PJ01='" + model.AM002 + "' and PJ105='塑料件' AND PJ100='F' AND PJ92='" + oddNum + "' AND PJ15='外购'" ) );
                    model.AM217 = string.IsNullOrEmpty( one.Compute( "SUM(PQ)" ,"PJ01='" + model.AM002 + "' and PJ105='塑料件' AND PJ100='T' AND PJ92='" + oddNum + "' AND PJ15='外购'" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQ)" ,"PJ01='" + model.AM002 + "' and PJ105='塑料件' AND PJ100='T' AND PJ92='" + oddNum + "' AND PJ15='外购'" ) );
                    model . AM229 = string . IsNullOrEmpty ( one . Compute ( "SUM(PQ)" , "PJ01='" + model . AM002 + "' and PJ105='塑料件' AND PJ100='F' AND PJ92='" + oddNum + "' AND PJ15='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( one . Compute ( "SUM(PQ)" , "PJ01='" + model . AM002 + "' and PJ105='塑料件' AND PJ100='F' AND PJ92='" + oddNum + "' AND PJ15='库存'" ) );
                    model . AM231 = string . IsNullOrEmpty ( one . Compute ( "SUM(PQ)" , "PJ01='" + model . AM002 + "' and PJ105='塑料件' AND PJ100='T' AND PJ92='" + oddNum + "' AND PJ15='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( one . Compute ( "sum(PQ)" , "PJ01='" + model . AM002 + "' and PJ105='塑料件' AND PJ100='T' AND PJ92='" + oddNum + "' AND PJ15='库存'" ) );
                    WriteReceivableToGeneralLedger .ByOneBySu( model ,oddNum ,SQLString );
                }

                model.AM218 = string.IsNullOrEmpty( one.Compute( "SUM(PQ)" ,"PJ01='" + model.AM002 + "' and PJ105='包装辅料' AND PJ100='F' AND PJ15='外购'" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(PQ)" ,"PJ01='" + model.AM002 + "' and PJ105='包装辅料' AND PJ100='F' AND PJ15='外购'" ) );
                model.AM223 = string.IsNullOrEmpty( one.Compute( "SUM(PQ)" ,"PJ01='" + model.AM002 + "' and PJ105='包装辅料' AND PJ100='T' AND PJ15='外购'" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(PQ)" ,"PJ01='" + model.AM002 + "' and PJ105='包装辅料' AND PJ100='T' AND PJ15='外购'" ) );
                model . AM237 = string . IsNullOrEmpty ( one . Compute ( "SUM(PQ)" , "PJ01='" + model . AM002 + "' and PJ105='包装辅料' AND PJ100='F' AND PJ15='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( one . Compute ( "SUM(PQ)" , "PJ01='" + model . AM002 + "' and PJ105='包装辅料' AND PJ100='F' AND PJ15='库存'" ) );
                model . AM255 = string . IsNullOrEmpty ( one . Compute ( "SUM(PQ)" , "PJ01='" + model . AM002 + "' and PJ105='包装辅料' AND PJ100='T' AND PJ15='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( one . Compute ( "SUM(PQ)" , "PJ01='" + model . AM002 + "' and PJ105='包装辅料' AND PJ100='T' AND PJ15='库存'" ) );

                model .AM215 = string.IsNullOrEmpty( one.Compute( "SUM(PQ)" ,"PJ01='" + model.AM002 + "' and PJ105='其它材料' AND PJ100='F' AND PJ15='外购'" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(PQ)" ,"PJ01='" + model.AM002 + "' and PJ105='其它材料' AND PJ100='F' AND PJ15='外购'" ) );
                model.AM221 = string.IsNullOrEmpty( one.Compute( "SUM(PQ)" ,"PJ01='" + model.AM002 + "' and PJ105='其它材料' AND PJ100='T' AND PJ15='外购'" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(PQ)" ,"PJ01='" + model.AM002 + "' and PJ105='其它材料' AND PJ100='T' AND PJ15='外购'" ) );
                model . AM233 = string . IsNullOrEmpty ( one . Compute ( "SUM(PQ)" , "PJ01='" + model . AM002 + "' and PJ105='其它材料' AND PJ100='F' AND PJ15='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( one . Compute ( "SUM(PQ)" , "PJ01='" + model . AM002 + "' and PJ105='其它材料' AND PJ100='F' AND PJ15='库存'" ) );
                model . AM235 = string . IsNullOrEmpty ( one . Compute ( "SUM(PQ)" , "PJ01='" + model . AM002 + "' and PJ105='其它材料' AND PJ100='T' AND PJ15='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( one . Compute ( "SUM(PQ)" , "PJ01='" + model . AM002 + "' and PJ105='其它材料' AND PJ100='T' AND PJ15='库存'" ) );

                model .AM212 = string.IsNullOrEmpty( one.Compute( "SUM(PQ)" ,"PJ01='" + model.AM002 + "' and PJ105='塑料件' AND PJ100='F' AND PJ15='外购'" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(PQ)" ,"PJ01='" + model.AM002 + "' and PJ105='塑料件' AND PJ100='F' AND PJ15='外购'" ) );
                model.AM217 = string.IsNullOrEmpty( one.Compute( "SUM(PQ)" ,"PJ01='" + model.AM002 + "' and PJ105='塑料件' AND PJ100='T' AND PJ15='外购'" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "sum(PQ)" ,"PJ01='" + model.AM002 + "' and PJ105='塑料件' AND PJ100='T' AND PJ15='外购'" ) );
                model . AM229 = string . IsNullOrEmpty ( one . Compute ( "SUM(PQ)" , "PJ01='" + model . AM002 + "' and PJ105='塑料件' AND PJ100='F' AND PJ15='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( one . Compute ( "SUM(PQ)" , "PJ01='" + model . AM002 + "' and PJ105='塑料件' AND PJ100='F' AND PJ15='库存'" ) );
                model . AM231 = string . IsNullOrEmpty ( one . Compute ( "SUM(PQ)" , "PJ01='" + model . AM002 + "' and PJ105='塑料件' AND PJ100='T' AND PJ15='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( one . Compute ( "sum(PQ)" , "PJ01='" + model . AM002 + "' and PJ105='塑料件' AND PJ100='T' AND PJ15='库存'" ) );
            }
        }

        /// <summary>
        /// 348
        /// </summary>
        /// <param name="numList"></param>
        /// <param name="idxList"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqoz ( string numList ,string idxList )
        {
            StringBuilder strSql = new StringBuilder( );
            //strSql.Append( "WITH CET AS (SELECT SUM(OZ) OZ,OZ011,COUN FROM (SELECT OZ005*OZ006 OZ,OZ011,COUNT(1) COUN FROM R_PQOZ GROUP BY OZ011,OZ005,OZ006) A GROUP BY OZ011,COUN)" );
            //strSql.Append( "SELECT OZ001,WX90,CONVERT(DECIMAL(18,2),SUM(OZ)) OZ,CONVERT(DECIMAL(18,2),CASE WHEN AK<SUM(OZ) THEN AK ELSE SUM(OZ) END) AK FROM (SELECT OZ001,CASE WHEN OZ=0 THEN 0 ELSE SUM(OZ009)/OZ*OZ005*OZ006/COUN END OZ,WX90,ISNULL(SUM(AK011),0) AK FROM R_PQOZ TT LEFT JOIN TPADGA B ON TT.OZ014=B.DGA001 LEFT JOIN CET C ON TT.OZ011=C.OZ011 INNER JOIN R_REVIEWS D ON TT.OZ011=D.RES06 AND RES05='执行' LEFT JOIN R_PQT E ON TT.OZ015=E.WX82 LEFT JOIN R_PQAK F ON TT.OZ011=F.AK003 AND TT.OZ001=F.AK002 AND F.AK017 IN ('执行','审核')" );
            //strSql.Append( " WHERE TT.OZ001 IN (" + numList + ") AND F.idx IN (" + idxList + ")" );
            //strSql.Append( " GROUP BY OZ001,TT.OZ011,OZ,OZ005,OZ006,WX90,COUN) A GROUP BY WX90,AK,OZ001" );


            //strSql . Append ( "WITH CET AS (SELECT SUM(OZ) OZ,OZ011,COUN FROM (SELECT OZ005*OZ006 OZ,OZ011,COUNT(1) COUN FROM R_PQOZ GROUP BY OZ011,OZ005,OZ006) A GROUP BY OZ011,COUN)" );
            //strSql . Append ( "SELECT OZ001,WX90,CONVERT(DECIMAL(18,2),SUM(OZ)) OZ,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(OZ)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(OZ)) END AK,A.AK017 FROM (SELECT OZ001,CASE WHEN OZ=0 THEN 0 ELSE SUM(OZ009)/OZ*OZ005*OZ006/COUN END OZ,WX90,C.OZ011,AK017 FROM R_PQOZ TT LEFT JOIN TPADGA B ON TT.OZ014=B.DGA001 LEFT JOIN CET C ON TT.OZ011=C.OZ011 INNER JOIN R_REVIEWS D ON TT.OZ011=D.RES06 AND RES05='执行' LEFT JOIN R_PQT E ON TT.OZ015=E.WX82 LEFT JOIN R_PQAK F ON TT.OZ011=F.AK003 AND TT.OZ001=F.AK002 " );
            //strSql . Append ( "WHERE TT.OZ001 IN (" + numList + ") AND F.idx IN (" + idxList + ") " );
            //strSql . Append ( "GROUP BY OZ001,TT.OZ011,OZ,OZ005,OZ006,WX90,COUN,C.OZ011,AK017) A LEFT JOIN R_PQAK B ON A.OZ011=B.AK003 AND A.OZ001=B.AK002 GROUP BY WX90,ISNULL(AK011,0),OZ001,A.AK017" );

            strSql . Append ( "WITH CET AS (SELECT SUM(OZ) OZ,OZ011,COUN FROM (SELECT OZ005*OZ006 OZ,OZ011,COUNT(1) COUN FROM R_PQOZ GROUP BY OZ011,OZ005,OZ006) A GROUP BY OZ011,COUN) " );
            strSql . Append ( " SELECT OZ001,WX90,CONVERT(DECIMAL(18,2),SUM(OZ)) OZ,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(OZ)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(OZ)) END AK,A.AK017 FROM (SELECT OZ001,CASE WHEN OZ=0 THEN 0 ELSE SUM(OZ009)/OZ*OZ005*OZ006/COUN END OZ,WX90,C.OZ011,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQOZ TT LEFT JOIN TPADGA B ON TT.OZ014=B.DGA001 LEFT JOIN CET C ON TT.OZ011=C.OZ011 INNER JOIN R_REVIEWS D ON TT.OZ011=D.RES06  LEFT JOIN R_PQT E ON TT.OZ015=E.WX82 LEFT JOIN R_PQAK F ON TT.OZ011=F.AK003 AND TT.OZ001=F.AK002 " );
            strSql . Append ( " WHERE TT.OZ001 IN (" + numList + ") AND RES05='执行' AND F.idx IN (" + idxList + ") " );
            strSql . Append ( " GROUP BY OZ001,TT.OZ011,OZ,OZ005,OZ006,WX90,COUN,C.OZ011,AK017) A GROUP BY WX90,ISNULL(AK011,0),OZ001,A.AK017 ORDER BY OZ001" );


            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public void PackageMaterials ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            strSql.AppendFormat( "AM139='{0}'," ,model.AM139 );
            strSql.AppendFormat( "AM140='{0}'," ,model.AM140 );
            strSql.AppendFormat( "AM144='{0}'," ,model.AM144 );
            strSql.AppendFormat( "AM147='{0}'" ,model.AM147 );
            strSql.AppendFormat( " WHERE AM002='{0}'" ,model.AM002 );
            SQLString.Add( strSql.ToString( ) );
        }
        public string PackageMaterialsAdd ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            model.AM001 = generateOddNum.purchaseContract( "SELECT MAX(AJ024) AJ024 FROM R_PQAJ" ,"AJ024" ,"R_241-" );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAM (" );
            strSql.Append( "AM002,AM139,AM140,AM144,AM147,AM001)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}','{4}','{5}')" ,model.AM002 ,model.AM139 ,model.AM140 ,model.AM144 ,model.AM147 ,model.AM001 );

            return strSql.ToString( );
        }
        public bool Pqts ( string idxList ,string numList ,MulaolaoLibrary.ProductCostSummaryLibrary model ,DataTable dk ,ArrayList SQLString )
        {
            dk = GetDataTablePqoz( numList ,idxList );
            if ( dk != null && dk.Rows.Count > 0 )
            {
                for ( int m = 0 ; m < dk.Rows.Count ; m++ )
                {
                    model.AM002 = dk.Rows[m]["OZ001"].ToString( );


                    model.AM139 = model.AM140 = model.AM144 = model.AM147 = 0;

                    //model.AM136 = string.IsNullOrEmpty( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='包装辅料' AND WX90='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='包装辅料' AND WX90='F'" ) );
                    //model.AM137 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' and WX20='包装辅料' AND WX90='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' and WX20='包装辅料' AND WX90='F'" ) );
                    //model.AM138 = string.IsNullOrEmpty( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='包装辅料' AND WX90='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='包装辅料' AND WX90='T'" ) );
                    //model.AM141 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' and WX20='包装辅料' AND WX90='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' and WX20='包装辅料' AND WX90='T'" ) );
                    //model.AM145 = string.IsNullOrEmpty( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='内盒' AND WX90='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='内盒'  AND WX90='F'" ) );
                   // model.AM146 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' and WX20='内盒' AND WX90='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' and WX20='内盒' AND WX90='F'" ) );
                    //model.AM133 = string.IsNullOrEmpty( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='内盒' AND WX90='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='内盒'  AND WX90='T'" ) );
                    //model.AM134 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' and WX20='内盒' AND WX90='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' and WX20='内盒' AND WX90='T'" ) );
                    //model.AM139 = string.IsNullOrEmpty( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='外箱' AND WX90='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='外箱' AND WX90='F'" ) );
                    model.AM140 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"OZ001='" + model.AM002 + "' AND WX90='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"OZ001='" + model.AM002 + "' AND WX90='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM144 = string.IsNullOrEmpty( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='外箱' AND WX90='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='外箱' AND WX90='T'" ) );
                    model.AM147 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"OZ001='" + model.AM002 + "' AND WX90='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"OZ001='" + model.AM002 + "' AND WX90='T' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM142 = string.IsNullOrEmpty( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='中包' AND WX90='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='中包' AND WX90='F'" ) );
                    //model.AM143 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' and WX20='中包' AND WX90='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' and WX20='中包' AND WX90='F'" ) );
                    //model.AM150 = string.IsNullOrEmpty( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='中包' AND WX90='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='中包' AND WX90='T'" ) );
                    //model.AM135 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' and WX20='中包' AND WX90='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' and WX20='中包' AND WX90='T'" ) );
                    //model.AM148 = string.IsNullOrEmpty( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='彩盒' AND WX90='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='彩盒' AND WX90='F'" ) );
                    //model.AM149 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' and WX20='彩盒' AND WX90='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' and WX20='彩盒' AND WX90='F'" ) );
                    //model.AM130 = string.IsNullOrEmpty( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='彩盒' AND WX90='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='彩盒' AND WX90='T'" ) );
                    //model.AM131 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' and WX20='彩盒' AND WX90='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' and WX20='彩盒' AND WX90='T'" ) );


                    if ( m == 0 )
                    {
                        ofEleY( model ,SQLString );
                        if ( ExistsOfCount( model.AM002 ) )
                        {
                            ofEles( model );
                            PackageMaterials( model ,SQLString );
                        }
                        else
                            SQLString.Add( PackageMaterialsAdd( model ) );
                    }

                    if ( m >= 1 )
                    {
                        if ( model.AM002 != dk.Rows[m - 1]["OZ001"].ToString( ) )
                        {
                            ofEleY( model ,SQLString );
                            if ( ExistsOfCount( model.AM002 ) )
                            {
                                ofEles( model );
                                PackageMaterials( model ,SQLString );
                            }
                            else
                                SQLString.Add( PackageMaterialsAdd( model ) );
                        }
                    }
                }
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        DataTable GetDataTableOfEles ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AM140,AM147 FROM R_PQAM" );
            strSql.Append( " WHERE AM002=@AM002" );
            SqlParameter[] parameter = {
                new SqlParameter("@AM002",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        void ofEles ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            DataTable da = GetDataTableOfEles( model.AM002 );
            if ( da != null && da.Rows.Count > 0 )
            {
                model.AM140 += string.IsNullOrEmpty( da.Rows[0]["AM140"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM140"].ToString( ) );
                model.AM147 += string.IsNullOrEmpty( da.Rows[0]["AM147"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM147"].ToString( ) );
            }
        }
        DataTable GetDataTableOfEleYs ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "WITH CET AS (SELECT SUM(OZ) OZ,OZ011,COUN FROM (SELECT OZ005*OZ006 OZ,OZ011,COUNT(1) COUN FROM R_PQOZ GROUP BY OZ011,OZ005,OZ006) A GROUP BY OZ011,COUN)" );
            strSql.Append( "SELECT A.OZ011,OZ001,WX90,CONVERT(DECIMAL(18,2),SUM(OZ)) OZ FROM (SELECT TT.OZ011,OZ001,CASE WHEN OZ=0 THEN 0 ELSE SUM(OZ009)/OZ*OZ005*OZ006/COUN END OZ,WX90FROM R_PQOZ TT LEFT JOIN TPADGA B ON TT.OZ014=B.DGA001 LEFT JOIN CET C ON TT.OZ011=C.OZ011 INNER JOIN R_REVIEWS D ON TT.OZ011=D.RES06 AND RES05='执行' LEFT JOIN R_PQT E ON TT.OZ015=E.WX82 " );
            strSql.Append( " WHERE TT.OZ001=@OZ001" );
            strSql.Append( " GROUP BY TT.OZ011,OZ001,OZ,OZ005,OZ006,WX90,COUN) A GROUP BY WX90,A.OZ011,OZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@OZ001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        void ofEleYs ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            DataTable one = GetDataTableOfEleYs( model.AM002 );
            if ( one != null && one.Rows.Count > 0 )
            {
                string oddNum = "";
                for ( int i = 0 ; i < one.Rows.Count ; i++ )
                {
                    oddNum = one.Rows[i]["OZ011"].ToString( );
                    model.AM139 = string.IsNullOrEmpty( one.Compute( "SUM(OZ)" ,"OZ001='" + model.AM002 + "' AND WX90='F' AND OZ011='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(OZ)" ,"OZ001='" + model.AM002 + "' AND WX90='F' AND OZ011='" + oddNum + "'" ) );
                    model.AM144 = string.IsNullOrEmpty( one.Compute( "SUM(OZ)" ,"OZ001='" + model.AM002 + "' AND WX90='T' AND OZ011='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(OZ)" ,"OZ001='" + model.AM002 + "' AND WX90='T' AND OZ011='" + oddNum + "'" ) );
                    WriteReceivableToGeneralLedger.ByOneByLiaos( model ,oddNum ,SQLString );
                }

                model.AM139 = string.IsNullOrEmpty( one.Compute( "SUM(OZ)" ,"OZ001='" + model.AM002 + "' AND WX90='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(OZ)" ,"OZ001='" + model.AM002 + "' AND WX90='F'" ) );
                model.AM144 = string.IsNullOrEmpty( one.Compute( "SUM(OZ)" ,"OZ001='" + model.AM002 + "' AND WX90='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(OZ)" ,"OZ001='" + model.AM002 + "' AND WX90='T'" ) );
            }
        }

        /// <summary>
        /// 349
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqt ( string numList ,string idxList )
        {
            StringBuilder strSql = new StringBuilder( );
            //strSql.Append( "SELECT WX01,WX20,WX90,CONVERT(DECIMAL(18,2),SUM(PQ)) PQ,CONVERT(DECIMAL(18,2),SUM(CASE WHEN AK>=PQ THEN PQ WHEN AK<PQ THEN AK ELSE 0 END)) AK FROM (SELECT WX01,A.idx,CASE WHEN WX90='T' THEN 'T' ELSE 'F' END WX90,WX20,SUM(CASE WHEN WX10='双瓦外箱' THEN ((WX27 + WX28 + WX29) * (WX30 + WX31 + WX32) + (WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15 WHEN WX10='小箱式' THEN ((WX27 + WX28 + WX29) * (WX30 + WX31 + WX32) + (WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15 WHEN WX10='牙膏式' THEN ((WX27 + 2*WX28 + WX29) * (2*WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10='插口式' THEN ((WX27 + 2*WX28 + WX29) * (2*WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10='天盖' THEN ((WX27 + 2*WX28 + WX29) * (WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10='地盖' THEN  ((WX27 + 2*WX28 + WX29) * (WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10='折叠式' THEN ((2*WX27 + 2*WX28 + WX29) * (1.5*WX30 + WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10 NOT IN ('双瓦外箱','小箱式','牙膏式','插口式','天盖','地盖','折叠式') THEN (WX23 + WX24) * (WX25 + WX26) * 0.0001 * WX13* WX15 END) PQ,ISNULL(AK011,0) AK FROM R_PQT A LEFT JOIN R_PQAL B ON A.WX82=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx AND C.idx IN (" + idxList + ") INNER JOIN R_REVIEWS D ON A.WX82=D.RES06 AND RES05='执行'" );
            //strSql.Append( " WHERE WX01 IN (" + numList + ") AND (WX01!='' AND WX01 IS NOT NULL) AND LEN(WX01)<=8" );// AND LEN(WX01)=8
            //strSql.Append( " GROUP BY WX20,WX90,A.idx,AK011,WX01) A WHERE AK!=0 GROUP BY WX20,WX90,WX01 ORDER BY WX01" );

            /*
            strSql . Append ( "SELECT WX01,WX20,WX90,CONVERT(DECIMAL(18,2),SUM(PQ)) PQ,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(PQ)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(PQ)) END AK,A.AK017 FROM (SELECT WX01,A.idx,CASE WHEN WX90='T' THEN 'T' ELSE 'F' END WX90,WX20,CASE WHEN WX10='双瓦外箱' THEN ((WX27 + WX28 + WX29) * (WX30 + WX31 + WX32) + (WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15 WHEN WX10='小箱式' THEN ((WX27 + WX28 + WX29) * (WX30 + WX31 + WX32) + (WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15 WHEN WX10='牙膏式' THEN ((WX27 + 2*WX28 + WX29) * (2*WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10='插口式' THEN ((WX27 + 2*WX28 + WX29) * (2*WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10='天盖' THEN ((WX27 + 2*WX28 + WX29) * (WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10='地盖' THEN  ((WX27 + 2*WX28 + WX29) * (WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10='折叠式' THEN ((2*WX27 + 2*WX28 + WX29) * (1.5*WX30 + WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10 NOT IN ('双瓦外箱','小箱式','牙膏式','插口式','天盖','地盖','折叠式') THEN (WX23 + WX24) * (WX25 + WX26) * 0.0001 * WX13* WX15 END PQ,WX82,AK017 FROM R_PQT A LEFT JOIN R_PQAL B ON A.WX82=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx INNER JOIN R_REVIEWS D ON A.WX82=D.RES06 AND RES05='执行' " );
            strSql . Append ( "WHERE C.idx IN (" + idxList + ") AND WX01 IN (" + numList + ") AND (WX01!='' AND WX01 IS NOT NULL) AND LEN(WX01)<=8) A LEFT JOIN R_PQAK B ON A.WX82=B.AK003 GROUP BY WX20,WX90,WX01,ISNULL(AK011,0),A.AK017 ORDER BY WX01" );
            */


            //strSql . Append ( "SELECT WX01,WX20,WX90,CONVERT(DECIMAL(18,2),SUM(PQ)) PQ,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(PQ)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(PQ)) END AK,A.AK017 FROM (SELECT WX01,A.idx,CASE WHEN WX90='T' THEN 'T' ELSE 'F' END WX90,WX20,CASE WHEN WX10='双瓦外箱' THEN ((WX27 + WX28 + WX29) * (WX30 + WX31 + WX32) + (WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15 WHEN WX10='小箱式' THEN ((WX27 + WX28 + WX29) * (WX30 + WX31 + WX32) + (WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15 WHEN WX10='牙膏式' THEN ((WX27 + 2*WX28 + WX29) * (2*WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10='插口式' THEN ((WX27 + 2*WX28 + WX29) * (2*WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10='天盖' THEN ((WX27 + 2*WX28 + WX29) * (WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10='地盖' THEN  ((WX27 + 2*WX28 + WX29) * (WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10='折叠式' THEN ((2*WX27 + 2*WX28 + WX29) * (1.5*WX30 + WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10 NOT IN ('双瓦外箱','小箱式','牙膏式','插口式','天盖','地盖','折叠式') THEN (WX23 + WX24) * (WX25 + WX26) * 0.0001 * WX13* WX15 END PQ,WX82,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQT A LEFT JOIN R_PQAL B ON A.WX82=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx INNER JOIN R_REVIEWS D ON A.WX82=D.RES06 " );
            //strSql . Append ( " WHERE C.idx IN (" + idxList + ") AND WX01 IN (" + numList + ") AND RES05='执行' AND (WX01!='' AND WX01 IS NOT NULL) AND LEN(WX01)<=8 GROUP BY WX01,A.idx,WX90,WX20,WX10,WX27,WX28,WX29,WX30,WX31,WX32,WX23,WX24,WX25,WX26,WX13,WX15,WX23,WX82,AK017 ) A GROUP BY WX20,WX90,WX01,ISNULL(AK011,0),A.AK017 ORDER BY WX01" );

            //更改  sum(ISNULL(AK011,0))
            strSql . Append ( "SELECT WX01,WX20,WX90,CONVERT(DECIMAL(18,2),SUM(PQ)) PQ,CASE WHEN sum(ISNULL(AK011,0))<CONVERT(DECIMAL(18,2),SUM(PQ)) THEN sum(ISNULL(AK011,0)) ELSE CONVERT(DECIMAL(18,2),SUM(PQ)) END AK,A.AK017 FROM (SELECT WX01,A.idx,CASE WHEN WX90='T' THEN 'T' ELSE 'F' END WX90,WX20,CASE WHEN WX10='双瓦外箱' THEN ((WX27 + WX28 + WX29) * (WX30 + WX31 + WX32) + (WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15 WHEN WX10='小箱式' THEN ((WX27 + WX28 + WX29) * (WX30 + WX31 + WX32) + (WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15 WHEN WX10='牙膏式' THEN ((WX27 + 2*WX28 + WX29) * (2*WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10='插口式' THEN ((WX27 + 2*WX28 + WX29) * (2*WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10='天盖' THEN ((WX27 + 2*WX28 + WX29) * (WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10='地盖' THEN  ((WX27 + 2*WX28 + WX29) * (WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10='折叠式' THEN ((2*WX27 + 2*WX28 + WX29) * (1.5*WX30 + WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10 NOT IN ('双瓦外箱','小箱式','牙膏式','插口式','天盖','地盖','折叠式') THEN (WX23 + WX24) * (WX25 + WX26) * 0.0001 * WX13* WX15 END PQ,WX82,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQT A LEFT JOIN R_PQAL B ON A.WX82=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx INNER JOIN R_REVIEWS D ON A.WX82=D.RES06 " );
            strSql . Append ( " WHERE C.idx IN (" + idxList + ") AND WX01 IN (" + numList + ") AND RES05='执行' AND (WX01!='' AND WX01 IS NOT NULL) AND LEN(WX01)<=8 GROUP BY WX01,A.idx,WX90,WX20,WX10,WX27,WX28,WX29,WX30,WX31,WX32,WX23,WX24,WX25,WX26,WX13,WX15,WX23,WX82,AK017 ) A GROUP BY WX20,WX90,WX01,A.AK017 ORDER BY WX01" );



            return SqlHelper .ExecuteDataTable( strSql.ToString( ) );
        }
        public void PackageMaterial ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            strSql.AppendFormat( "AM130='{0}'," ,model.AM130 );
            strSql.AppendFormat( "AM131='{0}'," ,model.AM131 );
            strSql.AppendFormat( "AM133='{0}'," ,model.AM133 );
            strSql.AppendFormat( "AM134='{0}'," ,model.AM134 );
            strSql.AppendFormat( "AM135='{0}'," ,model.AM135 );
            strSql.AppendFormat( "AM136='{0}'," ,model.AM136 );
            strSql.AppendFormat( "AM137='{0}'," ,model.AM137 );
            strSql.AppendFormat( "AM138='{0}'," ,model.AM138 );
            strSql.AppendFormat( "AM139='{0}'," ,model.AM139 );
            strSql.AppendFormat( "AM140='{0}'," ,model.AM140 );
            strSql.AppendFormat( "AM141='{0}'," ,model.AM141 );
            strSql.AppendFormat( "AM142='{0}'," ,model.AM142 );
            strSql.AppendFormat( "AM143='{0}'," ,model.AM143 );
            strSql.AppendFormat( "AM144='{0}'," ,model.AM144 );
            strSql.AppendFormat( "AM145='{0}'," ,model.AM145 );
            strSql.AppendFormat( "AM146='{0}'," ,model.AM146 );
            strSql.AppendFormat( "AM147='{0}'," ,model.AM147 );
            strSql.AppendFormat( "AM148='{0}'," ,model.AM148 );
            strSql.AppendFormat( "AM149='{0}'," ,model.AM149 );
            strSql.AppendFormat( "AM150='{0}'" ,model.AM150 );
            strSql.AppendFormat( " WHERE AM002='{0}'" ,model.AM002 );
            SQLString.Add( strSql.ToString( ) );
        }
        public string PackageMaterialAdd ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            model.AM001 = generateOddNum.purchaseContract( "SELECT MAX(AJ024) AJ024 FROM R_PQAJ" ,"AJ024" ,"R_241-" );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAM (" );
            strSql.Append( "AM002,AM136,AM137,AM138,AM139,AM140,AM141,AM142,AM143,AM144,AM145,AM146,AM147,AM148,AM149,AM150,AM001,AM130,AM131,AM133,AM134,AM135)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}')" ,model.AM002 ,model.AM136 ,model.AM137 ,model.AM138 ,model.AM139 ,model.AM140 ,model.AM141 ,model.AM142 ,model.AM143 ,model.AM144 ,model.AM145 ,model.AM146 ,model.AM147 ,model.AM148 ,model.AM149 ,model.AM150 ,model.AM001 ,model.AM130 ,model.AM131 ,model.AM133 ,model.AM134 ,model.AM135 );

            return strSql.ToString( );
        }
        public bool Pqt ( string idxList ,string numList ,MulaolaoLibrary.ProductCostSummaryLibrary model ,DataTable dk ,ArrayList SQLString )
        {
            dk = GetDataTablePqt( numList ,idxList );
            if ( dk != null && dk.Rows.Count > 0 )
            {
                for ( int m = 0 ; m < dk.Rows.Count ; m++ )
                {
                    model.AM002 = dk.Rows[m]["WX01"].ToString( );


                    model.AM130 = model.AM131 = model.AM133 = model.AM134 = model.AM135 = model.AM136 = model.AM137 = model.AM138 = model.AM139 = model.AM140 = model.AM141 = model.AM142 = model.AM143 = model.AM144 = model.AM145 = model.AM146 = model.AM147 = model.AM148 = model.AM149 = model.AM150 = 0;

                    //model.AM136 = string.IsNullOrEmpty( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='包装辅料' AND WX90='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='包装辅料' AND WX90='F'" ) );
                    model.AM137 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' and WX20='包装辅料' AND WX90='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' and WX20='包装辅料' AND WX90='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM138 = string.IsNullOrEmpty( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='包装辅料' AND WX90='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='包装辅料' AND WX90='T'" ) );
                    model.AM141 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' and WX20='包装辅料' AND WX90='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' and WX20='包装辅料' AND WX90='T' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM145 = string.IsNullOrEmpty( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='内盒' AND WX90='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='内盒'  AND WX90='F'" ) );
                    model.AM146 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' and WX20='内盒' AND WX90='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' and WX20='内盒' AND WX90='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM133 = string.IsNullOrEmpty( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='内盒' AND WX90='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='内盒'  AND WX90='T'" ) );
                    model.AM134 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' and WX20='内盒' AND WX90='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' and WX20='内盒' AND WX90='T' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM139 = string.IsNullOrEmpty( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='外箱' AND WX90='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='外箱' AND WX90='F'" ) );
                    model.AM140 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' and WX20='外箱' AND WX90='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' and WX20='外箱' AND WX90='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM144 = string.IsNullOrEmpty( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='外箱' AND WX90='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='外箱' AND WX90='T'" ) );
                    model.AM147 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' and WX20='外箱' AND WX90='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"WX01='" + model.AM002 + "' and WX20='外箱' AND WX90='T' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM142 = string.IsNullOrEmpty( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='中包' AND WX90='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='中包' AND WX90='F'" ) );
                    model.AM143 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' and WX20='中包' AND WX90='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' and WX20='中包' AND WX90='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM150 = string.IsNullOrEmpty( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='中包' AND WX90='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='中包' AND WX90='T'" ) );
                    model.AM135 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' and WX20='中包' AND WX90='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' and WX20='中包' AND WX90='T' AND (AK017='执行' OR AK017='审核')" ) );
                   //model.AM148 = string.IsNullOrEmpty( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='彩盒' AND WX90='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='彩盒' AND WX90='F'" ) );
                    model.AM149 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' and WX20='彩盒' AND WX90='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' and WX20='彩盒' AND WX90='F' AND (AK017='执行' OR AK017='审核')" ) );
                    //model.AM130 = string.IsNullOrEmpty( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='彩盒' AND WX90='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='彩盒' AND WX90='T'" ) );
                    model.AM131 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' and WX20='彩盒' AND WX90='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' and WX20='彩盒' AND WX90='T' AND (AK017='执行' OR AK017='审核')" ) );

                    
                    if ( m == 0 )
                    {
                        ofEleY( model ,SQLString );
                        if ( ExistsOfCount( model.AM002 ) )
                        {
                            ofEle( model );
                            PackageMaterial( model ,SQLString );
                        }
                        else
                            SQLString.Add( PackageMaterialAdd( model ) );
                    }

                    if ( m >= 1 )
                    {
                        if ( model.AM002 != dk.Rows[m - 1]["WX01"].ToString( ) )
                        {
                            ofEleY( model ,SQLString );
                            if ( ExistsOfCount( model.AM002 ) )
                            {
                                ofEle( model );
                                PackageMaterial( model ,SQLString );
                            }
                            else
                                SQLString.Add( PackageMaterialAdd( model ) );
                        }
                    }
                }
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        DataTable GetDataTableOfEle ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AM131,AM134,AM135,AM137,AM143,AM146,AM149,AM140,AM141,AM147 FROM R_PQAM" );
            strSql.Append( " WHERE AM002=@AM002" );
            SqlParameter[] parameter = {
                new SqlParameter("@AM002",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        void ofEle ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            DataTable da = GetDataTableOfEle( model.AM002 );
            if ( da != null && da.Rows.Count > 0 )
            {
                model.AM131 += string.IsNullOrEmpty( da.Rows[0]["AM131"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM131"].ToString( ) );
                model.AM134 += string.IsNullOrEmpty( da.Rows[0]["AM134"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM134"].ToString( ) );
                model.AM135 += string.IsNullOrEmpty( da.Rows[0]["AM135"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM135"].ToString( ) );
                model.AM137 += string.IsNullOrEmpty( da.Rows[0]["AM137"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM137"].ToString( ) );
                model.AM140 += string.IsNullOrEmpty( da.Rows[0]["AM140"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM140"].ToString( ) );
                model.AM141 += string.IsNullOrEmpty( da.Rows[0]["AM141"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM141"].ToString( ) );
                model.AM143 += string.IsNullOrEmpty( da.Rows[0]["AM143"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM143"].ToString( ) );
                model.AM146 += string.IsNullOrEmpty( da.Rows[0]["AM146"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM146"].ToString( ) );
                model.AM147 += string.IsNullOrEmpty( da.Rows[0]["AM147"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM147"].ToString( ) );
                model.AM149 += string.IsNullOrEmpty( da.Rows[0]["AM149"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM149"].ToString( ) );
            }
        }
        DataTable GetDataTableOfEleY ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT WX01,A.WX82,CASE WHEN WX90='T' THEN 'T' ELSE 'F' END WX90,WX20,CONVERT( DECIMAL( 11, 2 ), SUM(CASE WHEN WX10='双瓦外箱' THEN ((WX27 + WX28 + WX29) * (WX30 + WX31 + WX32) + (WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15 WHEN WX10='小箱式' THEN ((WX27 + WX28 + WX29)* (WX30 + WX31 + WX32) + (WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15 WHEN WX10='牙膏式' THEN  ((WX27 + 2*WX28 + WX29) * (2*WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10='插口式' THEN ((WX27 + 2*WX28 + WX29)* (2*WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10='天盖' THEN  ((WX27 + 2*WX28 + WX29)* (WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10='地盖' THEN  ((WX27 + 2*WX28 + WX29)* (WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10='折叠式' THEN ((2*WX27 + 2*WX28 + WX29)* (1.5*WX30 + WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10 NOT IN ('双瓦外箱','小箱式','牙膏式','插口式','天盖','地盖','折叠式') THEN (WX23 + WX24) * (WX25 + WX26) * 0.0001 * WX13* WX15 END)) PQ FROM R_PQT A LEFT JOIN R_REVIEWS D ON A.WX82=D.RES06 AND RES05='执行'" );
            strSql.Append( " WHERE WX01=@WX01 AND LEN(WX01)<=8" );
            strSql.Append( " GROUP BY WX20,WX90,A.WX82,WX01" );
            SqlParameter[] parameter = {
                new SqlParameter("@WX01",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        void ofEleY ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            DataTable one = GetDataTableOfEleY( model.AM002 );
            if ( one != null && one.Rows.Count > 0 )
            {
                string oddNum = "";
                for ( int i = 0 ; i < one.Rows.Count ; i++ )
                {
                    oddNum = one.Rows[i]["WX82"].ToString( );
                    model.AM136 = string.IsNullOrEmpty( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='包装辅料' AND WX90='F' AND WX82='"+oddNum+"'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='包装辅料' AND WX90='F' AND WX82='" + oddNum + "'" ) );
                    model.AM138 = string.IsNullOrEmpty( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='包装辅料' AND WX90='T' AND WX82='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='包装辅料' AND WX90='T' AND WX82='" + oddNum + "'" ) );
                    model.AM145 = string.IsNullOrEmpty( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='内盒' AND WX90='F' AND WX82='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='内盒'  AND WX90='F' AND WX82='" + oddNum + "'" ) );
                    model.AM133 = string.IsNullOrEmpty( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='内盒' AND WX90='T' AND WX82='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='内盒'  AND WX90='T' AND WX82='" + oddNum + "'" ) );
                    model.AM139 = string.IsNullOrEmpty( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='外箱' AND WX90='F' AND WX82='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='外箱' AND WX90='F' AND WX82='" + oddNum + "'" ) );
                    model.AM144 = string.IsNullOrEmpty( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='外箱' AND WX90='T' AND WX82='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='外箱' AND WX90='T' AND WX82='" + oddNum + "'" ) );
                    model.AM142 = string.IsNullOrEmpty( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='中包' AND WX90='F' AND WX82='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='中包' AND WX90='F' AND WX82='" + oddNum + "'" ) );
                    model.AM150 = string.IsNullOrEmpty( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='中包' AND WX90='T' AND WX82='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='中包' AND WX90='T' AND WX82='" + oddNum + "'" ) );
                    model.AM148 = string.IsNullOrEmpty( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='彩盒' AND WX90='F' AND WX82='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='彩盒' AND WX90='F' AND WX82='" + oddNum + "'" ) );
                    model.AM130 = string.IsNullOrEmpty( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='彩盒' AND WX90='T' AND WX82='" + oddNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='彩盒' AND WX90='T' AND WX82='" + oddNum + "'" ) );
                    WriteReceivableToGeneralLedger.ByOneByLiao( model ,oddNum ,SQLString );
                }

                model.AM136 = string.IsNullOrEmpty( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='包装辅料' AND WX90='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='包装辅料' AND WX90='F'" ) );
                model.AM138 = string.IsNullOrEmpty( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='包装辅料' AND WX90='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='包装辅料' AND WX90='T'" ) );
                model.AM145 = string.IsNullOrEmpty( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='内盒' AND WX90='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='内盒'  AND WX90='F'" ) );
                model.AM133 = string.IsNullOrEmpty( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='内盒' AND WX90='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='内盒'  AND WX90='T'" ) );
                model.AM139 = string.IsNullOrEmpty( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='外箱' AND WX90='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='外箱' AND WX90='F'" ) );
                model.AM144 = string.IsNullOrEmpty( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='外箱' AND WX90='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='外箱' AND WX90='T'" ) );
                model.AM142 = string.IsNullOrEmpty( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='中包' AND WX90='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='中包' AND WX90='F'" ) );
                model.AM150 = string.IsNullOrEmpty( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='中包' AND WX90='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='中包' AND WX90='T'" ) );
                model.AM148 = string.IsNullOrEmpty( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='彩盒' AND WX90='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='彩盒' AND WX90='F'" ) );
                model.AM130 = string.IsNullOrEmpty( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='彩盒' AND WX90='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(PQ)" ,"WX01='" + model.AM002 + "' and WX20='彩盒' AND WX90='T'" ) );
            }
        }

        /// <summary>
        /// 495
        /// </summary>
        /// <param name="numList"></param>
        /// <param name="idxList"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqy ( string numList ,string idxList )
        {
            StringBuilder strSql = new StringBuilder( );
            //strSql.Append( "SELECT PY01,CONVERT(DECIMAL(18,2),SUM(U13+U14)) U1,CONVERT(DECIMAL(18,2),SUM(CASE WHEN U13+U14>=AK THEN AK WHEN U13+U14<AK THEN U13+U14 ELSE 0 END)) AK FROM (" );
            //strSql.Append( " SELECT PY01,CASE WHEN PY14 = 0 OR PY18 = 0 OR PY21 = 0 THEN 0 WHEN PY14 != 0 AND PY18 != 0 AND PY21 != 0 THEN (PY10*PY11*PY15*PY12*PY20/PY21/PY14/PY18+PY13*PY19*PY16*PY10*PY11/PY14/PY18/PY21/2)*(1+PY17/100) END U13,PY23*PY14*PY18*PY11*PY10*PY12*PY15*0.0001 U14,ISNULL(AK011,0) AK FROM R_PQY A LEFT JOIN R_PQAL B ON A.PY33=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx" );
            //strSql.Append( " AND C.idx IN (" + idxList + ") " );
            //strSql.Append( " LEFT JOIN R_REVIEWS D ON A.PY33=D.RES06 AND RES01='R_495' AND RES05='执行'" );
            //strSql.Append( " WHERE PY01 IN (" + numList + ") AND" );
            //strSql.Append( " (PY01!='' AND PY01 IS NOT NULL)" );
            //strSql.Append( " ) A WHERE AK!=0 GROUP BY PY01" );

            /*
            strSql . Append ( "SELECT PY01,CONVERT(DECIMAL(18,2),SUM(U13+U14)) U1,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(U13+U14)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(U13+U14)) END AK,A.AK017 FROM (SELECT PY01,CASE WHEN PY14 = 0 OR PY18 = 0 OR PY21 = 0 THEN 0 WHEN PY14 != 0 AND PY18 != 0 AND PY21 != 0 THEN (PY10*PY11*PY15*PY12*PY20/PY21/PY14/PY18+PY13*PY19*PY16*PY10*PY11/PY14/PY18/PY21/2)*(1+PY17/100) END U13,PY23*PY14*PY18*PY11*PY10*PY12*PY15*0.0001 U14,PY33,AK017 FROM R_PQY A LEFT JOIN R_PQAL B ON A.PY33=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx LEFT JOIN R_REVIEWS D ON A.PY33=D.RES06 AND RES01='R_495' AND RES05='执行' " );
            strSql . Append ( "WHERE PY01 IN (" + numList + ")  AND C.idx IN (" + idxList + ") AND (PY01!='' AND PY01 IS NOT NULL) " );
            strSql . Append ( ") A LEFT JOIN R_PQAK B ON A.PY33=B.AK003 GROUP BY PY01,ISNULL(AK011,0),A.AK017" );
            */



            strSql . Append ( "SELECT PY01,CONVERT(DECIMAL(18,2),SUM(U13+U14)) U1,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(U13+U14)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(U13+U14)) END AK,A.AK017 FROM (SELECT PY01,CASE WHEN PY14 = 0 OR PY18 = 0 OR PY21 = 0 THEN 0 WHEN PY14 != 0 AND PY18 != 0 AND PY21 != 0 THEN (PY10*PY11*PY15*PY12*PY20/PY21/PY14/PY18+PY13*PY19*PY16*PY10*PY11/PY14/PY18/PY21/2)*(1+PY17/100) END U13,PY23*PY14*PY18*PY11*PY10*PY12*PY15*0.0001 U14,PY33,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQY A LEFT JOIN R_PQAL B ON A.PY33=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx LEFT JOIN R_REVIEWS D ON A.PY33=D.RES06 " );
            strSql . Append ( "WHERE PY01 IN (" + numList + ")  AND RES01='R_495' AND RES05='执行' AND C.idx IN (" + idxList + ") AND (PY01!='' AND PY01 IS NOT NULL) GROUP BY PY01,PY14,PY18,PY21,PY10,PY11,PY15,PY12,PY20,PY13,PY16,PY19,PY17,AK017,PY23,PY33 " );
            strSql . Append ( ") A GROUP BY PY01,ISNULL(AK011,0),A.AK017  order by PY01" );



            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public void PqyMaterial ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            strSql.AppendFormat( "AM088='{0}'," ,model.AM088 );
            strSql.AppendFormat( "AM089='{0}'" ,model.AM089 );
            strSql.AppendFormat( " WHERE AM002='{0}'" ,model.AM002 );
            SQLString.Add( strSql.ToString( ) );
        }
        public string PqyMaterialAdd ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            model.AM001 = generateOddNum.purchaseContract( "SELECT MAX(AJ024) AJ024 FROM R_PQAJ" ,"AJ024" ,"R_241-" );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAM (" );
            strSql.Append( "AM002,AM088,AM089)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}')" ,model.AM002 ,model.AM088 ,model.AM089 );

            return strSql.ToString( );
        }
        public bool Pqy ( string idxList ,string numList ,MulaolaoLibrary.ProductCostSummaryLibrary model ,DataTable dk ,ArrayList SQLString )
        {
            dk = GetDataTablePqy( numList ,idxList );
            if ( dk != null && dk.Rows.Count > 0 )
            {
                for ( int m = 0 ; m < dk.Rows.Count ; m++ )
                {
                    model.AM002 = dk.Rows[m]["PY01"].ToString( );

                    model.AM088 = model.AM089 = 0;

                    model . AM089 = string . IsNullOrEmpty ( dk . Compute ( "SUM(AK)" ,"WX01='" + model . AM002 + "' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dk . Compute ( "SUM(AK)" ,"WX01='" + model . AM002 + "' AND (AK017='执行' OR AK017='审核')" ) );

                    if ( m == 0 )
                    {
                        ofPqyY( model ,SQLString );
                        if ( ExistsOfCount( model.AM002 ) )
                        {
                            ofPqy( model );
                            PqyMaterial( model ,SQLString );
                        }
                        else
                            SQLString.Add( PqyMaterialAdd( model ) );
                    }

                    if ( m >= 1 )
                    {
                        if ( model.AM002 != dk.Rows[m - 1]["PY01"].ToString( ) )
                        {
                            ofPqyY( model ,SQLString );
                            if ( ExistsOfCount( model.AM002 ) )
                            {
                                ofPqy( model );
                                PqyMaterial( model ,SQLString );
                            }
                            else
                                SQLString.Add( PqyMaterialAdd( model ) );
                        }
                    }
                }
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        DataTable GetDataTableOfPqy ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AM089 FROM R_PQAM" );
            strSql.Append( " WHERE AM002=@AM002" );
            SqlParameter[] parameter = {
                new SqlParameter("@AM002",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        void ofPqy ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            DataTable da = GetDataTableOfPqy( model.AM002 );
            if ( da != null && da.Rows.Count > 0 )
            {
                model.AM089 += string.IsNullOrEmpty( da.Rows[0]["AM089"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM089"].ToString( ) );
            }
        }
        DataTable GetDataTableOfPqyY ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT PY33,PY01,CONVERT(DECIMAL(18,2),SUM(U13+U14)) U1 FROM (SELECT PY33,PY01,CASE WHEN PY14 = 0 OR PY18 = 0 OR PY21 = 0 THEN 0 WHEN PY14 != 0 AND PY18 != 0 AND PY21 != 0 THEN (PY10*PY11*PY15*PY12*PY20/PY21/PY14/PY18+PY13*PY19*PY16*PY10*PY11/PY14/PY18/PY21/2)*(1+PY17/100) END U13,PY23*PY14*PY18*PY11*PY10*PY12*PY15*0.0001 U14 FROM R_PQY A LEFT JOIN R_REVIEWS D ON A.PY33=D.RES06 AND RES01='R_495' AND RES05='执行'" );
            strSql.Append( " WHERE PY01=@PY01" );
            strSql.Append( " ) A GROUP BY PY33,PY01" );
            SqlParameter[] parameter = {
                new SqlParameter("@PY01",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        void ofPqyY ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            DataTable one = GetDataTableOfPqyY( model.AM002 );
            if ( one != null && one.Rows.Count > 0 )
            {
                string oddNum = "";
                for ( int i = 0 ; i < one.Rows.Count ; i++ )
                {
                    oddNum = one.Rows[i]["PY33"].ToString( );
                    WriteReceivableToGeneralLedger.ByOneByQiGong( model ,oddNum ,SQLString );
                }
                model.AM088 = string.IsNullOrEmpty( one.Compute( "SUM(U1)" ,"PY01='" + model.AM002 + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( one.Compute( "SUM(U1)" ,"PY01='" + model.AM002 + "'" ) );
            }
        }

        /// <summary>
        /// 获取317成本
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqw ( string numList ,string idxList )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql . Append ( "WITH CET AS(SELECT GZ01,GX04,CASE WHEN GZ39 IN('执行','审核') THEN GZ39 ELSE '非执行' END GZ39,CONVERT(DECIMAL(18,0),SUM(GZ06*GZ25*GZ41+GZ36*(GZ12+GZ13+GZ14))) GZ FROM R_PQW A LEFT JOIN R_PQAA B ON A.GZ04=B.GX02 " );
            strSql . Append ( " WHERE (GZ01!='' AND GZ01 IS NOT NULL) " );
            strSql . Append ( " GROUP BY GX04,GZ39,GZ01) " );
            strSql . Append ( ",CFT AS (" );
            strSql . Append ( "SELECT GZ01,GX04,CASE WHEN GZ39 IN ('执行','审核') THEN GZ39 ELSE '非执行' END GZ39,CONVERT(DECIMAL(18,0),SUM(GZ06*GZ25*GZ41+GZ36*(GZ12+GZ13+GZ14))) GZ FROM R_PQW A LEFT JOIN R_PQAA B ON A.GZ04=B.GX02 RIGHT JOIN (SELECT FZ002 FROM R_PQEZ A LEFT JOIN R_PQFZ B ON A.idx=B.FZ001 WHERE A.idx IN (" + idxList + ") AND FZ002 IS NOT NULL) C ON A.idx=C.FZ002 " );
            //strSql.Append( " WHERE (GZ01!='' AND GZ01 IS NOT NULL)" );//  AND LEN(GZ01)=8
            //strSql.Append( " AND A.idx IN (SELECT FZ002 FROM R_PQEZ A LEFT JOIN R_PQFZ B ON A.idx=B.FZ001 AND A.idx IN (" + idxList + ")" );
            strSql . Append ( " GROUP BY GX04,GZ39,GZ01) " );
            strSql . Append ( " SELECT A.GZ01,A.GX04,ISNULL(GZ,0) GZ,ISNULL(GZ1,0) GZ1 FROM (SELECT GZ01,GX04,SUM(GZ) GZ FROM CET GROUP BY GX04,GZ01) A LEFT JOIN (SELECT GZ01,GX04,GZ39,SUM(GZ) GZ1 FROM CFT WHERE GZ39 IN('执行','审核') GROUP BY GX04,GZ39,GZ01 ) B ON A.GX04=B.GX04 AND A.GZ01=B.GZ01 order by A.GZ01 " );
            //strSql . Append ( "WHERE GZ1!=0 ORDER BY A.GZ01,B.GX04" );
            
            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public void ProductBeforeAndAfterRoadWages ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            strSql.AppendFormat( "AM044='{0}'," ,model.AM044 );
            strSql.AppendFormat( "AM045='{0}'," ,model.AM045 );
            strSql.AppendFormat( "AM046='{0}'," ,model.AM046 );
            strSql.AppendFormat( "AM047='{0}'," ,model.AM047 );
            strSql.AppendFormat( "AM048='{0}'," ,model.AM048 );
            strSql.AppendFormat( "AM049='{0}'," ,model.AM049 );
            strSql.AppendFormat( "AM050='{0}'," ,model.AM050 );
            strSql.AppendFormat( "AM051='{0}'," ,model.AM051 );
            strSql.AppendFormat( "AM052='{0}'," ,model.AM052 );
            strSql.AppendFormat( "AM053='{0}'," ,model.AM053 );
            strSql.AppendFormat( "AM054='{0}'," ,model.AM054 );
            strSql.AppendFormat( "AM055='{0}'," ,model.AM055 );
            strSql.AppendFormat( "AM056='{0}'," ,model.AM056 );
            strSql.AppendFormat( "AM057='{0}'," ,model.AM057 );
            strSql.AppendFormat( "AM058='{0}'," ,model.AM058 );
            strSql.AppendFormat( "AM059='{0}'," ,model.AM059 );
            strSql.AppendFormat( "AM060='{0}'," ,model.AM060 );
            strSql.AppendFormat( "AM061='{0}'," ,model.AM061 );
            strSql.AppendFormat( "AM062='{0}'," ,model.AM062 );
            strSql.AppendFormat( "AM063='{0}'" ,model.AM063 );
            strSql.AppendFormat( " WHERE AM002='{0}'" ,model.AM002 );
            SQLString.Add( strSql.ToString( ) );
        }
        public string ProductBeforeAndAfterRoadWagesAdd ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            model.AM001 = generateOddNum.purchaseContract( "SELECT MAX(AJ024) AJ024 FROM R_PQAJ" ,"AJ024" ,"R_241-" );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAM (" );
            strSql.Append( "AM002,AM044,AM045,AM046,AM047,AM048,AM049,AM050,AM051,AM052,AM053,AM054,AM055,AM056,AM057,AM058,AM059,AM060,AM061,AM001,AM062,AM063)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}')" ,model.AM002 ,model.AM044 ,model.AM045 ,model.AM046 ,model.AM047 ,model.AM048 ,model.AM049 ,model.AM050 ,model.AM051 ,model.AM052 ,model.AM053 ,model.AM054 ,model.AM055 ,model.AM056 ,model.AM057 ,model.AM058 ,model.AM059 ,model.AM060 ,model.AM061 ,model.AM001 ,model.AM062 ,model.AM063 );

            return strSql.ToString( );
        }
        public bool Pqw ( string idxListOf ,string numList ,MulaolaoLibrary.ProductCostSummaryLibrary model ,DataTable dk ,ArrayList SQLString )
        {
            dk = GetDataTablePqw( numList ,idxListOf );
            if ( dk != null && dk . Rows . Count > 0 )
            {
                for ( int m = 0 ; m < dk . Rows . Count ; m++ )
                {

                    model . AM002 = dk . Rows [ m ] [ "GZ01" ] . ToString ( );


                    model . AM044 = model . AM045 = model . AM046 = model . AM047 = model . AM048 = model . AM049 = model . AM050 = model . AM051 = model . AM052 = model . AM053 = model . AM054 = model . AM055 = model . AM056 = model . AM057 = model . AM058 = model . AM059 = model . AM060 = model . AM061 = model . AM062 = model . AM063 = 0M;

                    model . AM044 = string . IsNullOrEmpty ( dk . Compute ( "sum(GZ)" ,"GZ01='" + model . AM002 + "' AND GX04='白坯'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dk . Compute ( "sum(GZ)" ,"GZ01='" + model . AM002 + "' AND GX04='白坯'" ) );
                    model . AM045 = string . IsNullOrEmpty ( dk . Compute ( "sum(GZ1)" ,"GZ01='" + model . AM002 + "' AND GX04='白坯'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dk . Compute ( "sum(GZ1)" ,"GZ01='" + model . AM002 + "' AND GX04='白坯'" ) );
                    model . AM046 = string . IsNullOrEmpty ( dk . Compute ( "sum(GZ)" ,"GZ01='" + model . AM002 + "' AND GX04='砂光'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dk . Compute ( "sum(GZ)" ,"GZ01='" + model . AM002 + "' AND GX04='砂光'" ) );
                    model . AM047 = string . IsNullOrEmpty ( dk . Compute ( "sum(GZ1)" ,"GZ01='" + model . AM002 + "' AND GX04='砂光'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dk . Compute ( "sum(GZ1)" ,"GZ01='" + model . AM002 + "' AND GX04='砂光'" ) );
                    model . AM048 = string . IsNullOrEmpty ( dk . Compute ( "sum(GZ)" ,"GZ01='" + model . AM002 + "' AND GX04='粘接'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dk . Compute ( "sum(GZ)" ,"GZ01='" + model . AM002 + "' AND GX04='粘接'" ) );
                    model . AM049 = string . IsNullOrEmpty ( dk . Compute ( "sum(GZ1)" ,"GZ01='" + model . AM002 + "' AND GX04='粘接'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dk . Compute ( "sum(GZ1)" ,"GZ01='" + model . AM002 + "' AND GX04='粘接'" ) );
                    model . AM050 = string . IsNullOrEmpty ( dk . Compute ( "sum(GZ)" ,"GZ01='" + model . AM002 + "' AND GX04='组装'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dk . Compute ( "sum(GZ)" ,"GZ01='" + model . AM002 + "' AND GX04='组装'" ) );
                    model . AM051 = string . IsNullOrEmpty ( dk . Compute ( "sum(GZ1)" ,"GZ01='" + model . AM002 + "' AND GX04='组装'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dk . Compute ( "sum(GZ1)" ,"GZ01='" + model . AM002 + "' AND GX04='组装'" ) );
                    model . AM052 = string . IsNullOrEmpty ( dk . Compute ( "sum(GZ)" ,"GZ01='" + model . AM002 + "' AND GX04='检验'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dk . Compute ( "sum(GZ)" ,"GZ01='" + model . AM002 + "' AND GX04='检验'" ) );
                    model . AM053 = string . IsNullOrEmpty ( dk . Compute ( "sum(GZ1)" ,"GZ01='" + model . AM002 + "' AND GX04='检验'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dk . Compute ( "sum(GZ1)" ,"GZ01='" + model . AM002 + "' AND GX04='检验'" ) );
                    model . AM054 = string . IsNullOrEmpty ( dk . Compute ( "sum(GZ)" ,"GZ01='" + model . AM002 + "' AND GX04='包装'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dk . Compute ( "sum(GZ)" ,"GZ01='" + model . AM002 + "' AND GX04='包装'" ) );
                    model . AM055 = string . IsNullOrEmpty ( dk . Compute ( "sum(GZ1)" ,"GZ01='" + model . AM002 + "' AND GX04='包装'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dk . Compute ( "sum(GZ1)" ,"GZ01='" + model . AM002 + "' AND GX04='包装'" ) );
                    model . AM056 = string . IsNullOrEmpty ( dk . Compute ( "sum(GZ)" ,"GZ01='" + model . AM002 + "' AND GX04='修理'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dk . Compute ( "sum(GZ)" ,"GZ01='" + model . AM002 + "' AND GX04='修理'" ) );
                    model . AM057 = string . IsNullOrEmpty ( dk . Compute ( "sum(GZ1)" ,"GZ01='" + model . AM002 + "' AND GX04='修理'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dk . Compute ( "sum(GZ1)" ,"GZ01='" + model . AM002 + "' AND GX04='修理'" ) );
                    model . AM058 = string . IsNullOrEmpty ( dk . Compute ( "sum(GZ)" ,"GZ01='" + model . AM002 + "' AND GX04='后道辅助'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dk . Compute ( "sum(GZ)" ,"GZ01='" + model . AM002 + "' AND GX04='后道辅助'" ) );
                    model . AM059 = string . IsNullOrEmpty ( dk . Compute ( "sum(GZ1)" ,"GZ01='" + model . AM002 + "' AND GX04='后道辅助'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dk . Compute ( "sum(GZ1)" ,"GZ01='" + model . AM002 + "' AND GX04='后道辅助'" ) );
                    model . AM060 = string . IsNullOrEmpty ( dk . Compute ( "sum(GZ)" ,"GZ01='" + model . AM002 + "' AND GX04='返工'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dk . Compute ( "sum(GZ)" ,"GZ01='" + model . AM002 + "' AND GX04='返工'" ) );
                    model . AM061 = string . IsNullOrEmpty ( dk . Compute ( "sum(GZ1)" ,"GZ01='" + model . AM002 + "' AND GX04='返工'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dk . Compute ( "sum(GZ1)" ,"GZ01='" + model . AM002 + "' AND GX04='返工'" ) );
                    model . AM062 = string . IsNullOrEmpty ( dk . Compute ( "sum(GZ1)" ,"GZ01='" + model . AM002 + "' AND GX04 NOT IN ('白坯','砂光','粘接','组装','检验','包装','修理','后道辅助','返工')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dk . Compute ( "sum(GZ1)" ,"GZ01='" + model . AM002 + "' AND GX04  NOT IN ('白坯','砂光','粘接','组装','检验','包装','修理','后道辅助','返工')" ) );
                    model . AM063 = string . IsNullOrEmpty ( dk . Compute ( "sum(GZ1)" ,"GZ01='" + model . AM002 + "' AND GX04  NOT IN ('白坯','砂光','粘接','组装','检验','包装','修理','后道辅助','返工')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dk . Compute ( "sum(GZ1)" ,"GZ01='" + model . AM002 + "' AND GX04  NOT IN ('白坯','砂光','粘接','组装','检验','包装','修理','后道辅助','返工')" ) );

                    if ( m == 0 )
                    {
                        if ( ExistsOfCount ( model . AM002 ) )
                        {
                            ofTwe ( model );
                            ProductBeforeAndAfterRoadWages ( model ,SQLString );
                        }
                        else
                            SQLString . Add ( ProductBeforeAndAfterRoadWagesAdd ( model ) );
                    }
                    if ( m >= 1 )
                    {
                        if ( model . AM002 != dk . Rows [ m - 1 ] [ "GZ01" ] . ToString ( ) )
                        {
                            if ( ExistsOfCount ( model . AM002 ) )
                            {
                                ofTwe ( model );
                                ProductBeforeAndAfterRoadWages ( model ,SQLString );
                            }
                            else
                                SQLString . Add ( ProductBeforeAndAfterRoadWagesAdd ( model ) );
                        }
                    }
                }
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        DataTable GetDataTableOfTwe ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AM045,AM047,AM049,AM051,AM053,AM055,AM057,AM059,AM061,AM063 FROM R_PQAM" );
            strSql.Append( " WHERE AM002=@AM002" );
            SqlParameter[] parameter = {
                new SqlParameter("@AM002",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        void ofTwe ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            DataTable da = GetDataTableOfTwe( model.AM002 );
            if ( da != null && da.Rows.Count > 0 )
            {
                model.AM045 += string.IsNullOrEmpty( da.Rows[0]["AM045"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM045"].ToString( ) );
                model.AM047 += string.IsNullOrEmpty( da.Rows[0]["AM047"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM047"].ToString( ) );
                model.AM049 += string.IsNullOrEmpty( da.Rows[0]["AM049"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM049"].ToString( ) );
                model.AM051 += string.IsNullOrEmpty( da.Rows[0]["AM051"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM051"].ToString( ) );
                model.AM053 += string.IsNullOrEmpty( da.Rows[0]["AM053"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM053"].ToString( ) );
                model.AM055 += string.IsNullOrEmpty( da.Rows[0]["AM055"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM055"].ToString( ) );
                model.AM057 += string.IsNullOrEmpty( da.Rows[0]["AM057"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM057"].ToString( ) );
                model.AM059 += string.IsNullOrEmpty( da.Rows[0]["AM059"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM059"].ToString( ) );
                model.AM061 += string.IsNullOrEmpty( da.Rows[0]["AM061"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM061"].ToString( ) );
                model.AM063 += string.IsNullOrEmpty( da.Rows[0]["AM063"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM063"].ToString( ) );
            }
        }

        /// <summary>
        /// 获取243成本
        /// </summary>
        /// <param name="idxListOfOther"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqbe ( string idxListOfOther )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT BE002,SUM(BE007) BE007,SUM(BE008) BE008,SUM(BE009) BE009,SUM(BE010) BE010,SUM(BE011+BE012) BE011 FROM R_PQBE" );
            strSql.Append( " WHERE idx IN (" + idxListOfOther + ")" );
            strSql.Append( " GROUP BY BE002" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public void OtherCastUp ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            strSql.AppendFormat( "AM020='{0}'," ,model.AM020 );
            strSql.AppendFormat( "AM021='{0}'," ,model.AM021 );
            strSql.AppendFormat( "AM022='{0}'," ,model.AM022 );
            strSql.AppendFormat( "AM023='{0}'," ,model.AM023 );
            strSql.AppendFormat( "AM024='{0}'," ,model.AM024 );
            strSql.AppendFormat( "AM025='{0}'," ,model.AM025 );
            strSql.AppendFormat( "AM026='{0}'," ,model.AM026 );
            strSql.AppendFormat( "AM027='{0}'," ,model.AM027 );
            strSql.AppendFormat( "AM028='{0}'," ,model.AM028 );
            strSql.AppendFormat( "AM029='{0}'" ,model.AM029 );
            strSql.AppendFormat( " WHERE AM002='{0}'" ,model.AM002 );
            SQLString.Add( strSql.ToString( ) );
        }
        public string OtherCast ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            model.AM001 = generateOddNum.purchaseContract( "SELECT MAX(AJ024) AJ024 FROM R_PQAJ" ,"AJ024" ,"R_241-" );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAM (" );
            strSql.Append( "AM002,AM020,AM021,AM022,AM023,AM024,AM025,AM026,AM027,AM028,AM029,AM001)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')" ,model.AM002 ,model.AM020 ,model.AM021 ,model.AM022 ,model.AM023 ,model.AM024 ,model.AM025 ,model.AM026 ,model.AM027 ,model.AM028 ,model.AM029 ,model.AM001 );

            return strSql.ToString( );
        }
        public bool Pqbe ( string idxListOfOther ,MulaolaoLibrary.ProductCostSummaryLibrary model ,DataTable dk ,ArrayList SQLString )
        {
            dk = GetDataTablePqbe( idxListOfOther );
            if ( dk != null && dk.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < dk.Rows.Count ; i++ )
                {
                    model.AM002 = dk.Rows[i]["BE002"].ToString( );
                    model.AM020 = model.AM021 = model.AM022 = model.AM023 = model.AM024 = model.AM025 = model.AM026 = model.AM027 = model.AM028 = model.AM029 = 0;
                    model.AM020 = string.IsNullOrEmpty( dk.Compute( "sum(BE007)" ,"BE002='" + model.AM002 + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(BE007)" ,"BE002='" + model.AM002 + "'" ) );
                    model.AM021 = string.IsNullOrEmpty( dk.Compute( "sum(BE007)" ,"BE002='" + model.AM002 + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(BE007)" ,"BE002='" + model.AM002 + "'" ) );
                    model.AM022 = string.IsNullOrEmpty( dk.Compute( "sum(BE008)" ,"BE002='" + model.AM002 + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(BE008)" ,"BE002='" + model.AM002 + "'" ) );
                    model.AM023 = string.IsNullOrEmpty( dk.Compute( "sum(BE008)" ,"BE002='" + model.AM002 + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(BE008)" ,"BE002='" + model.AM002 + "'" ) );
                    model.AM024 = string.IsNullOrEmpty( dk.Compute( "sum(BE009)" ,"BE002='" + model.AM002 + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(BE009)" ,"BE002='" + model.AM002 + "'" ) );
                    model.AM025 = string.IsNullOrEmpty( dk.Compute( "sum(BE009)" ,"BE002='" + model.AM002 + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(BE009)" ,"BE002='" + model.AM002 + "'" ) );
                    model.AM026 = string.IsNullOrEmpty( dk.Compute( "sum(BE010)" ,"BE002='" + model.AM002 + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(BE010)" ,"BE002='" + model.AM002 + "'" ) );
                    model.AM027 = string.IsNullOrEmpty( dk.Compute( "sum(BE010)" ,"BE002='" + model.AM002 + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(BE010)" ,"BE002='" + model.AM002 + "'" ) );
                    model.AM028 = string.IsNullOrEmpty( dk.Compute( "sum(BE011)" ,"BE002='" + model.AM002 + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(BE011)" ,"BE002='" + model.AM002 + "'" ) );
                    model.AM029 = string.IsNullOrEmpty( dk.Compute( "sum(BE011)" ,"BE002='" + model.AM002 + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(BE011)" ,"BE002='" + model.AM002 + "'" ) );

                    if ( i == 0 )
                    {
                        if ( ExistsOfCount( model.AM002 ) )
                        {
                            ofPqbe( model );
                            OtherCastUp( model ,SQLString );
                        }
                        else
                            SQLString.Add( OtherCast( model ) );
                    }
                    if ( i >= 1 )
                    {
                        if ( model.AM002 != dk.Rows[i - 1]["BE002"].ToString( ) )
                        {
                            if ( ExistsOfCount( model.AM002 ) )
                            {
                                ofPqbe( model );
                                OtherCastUp( model ,SQLString );
                            }
                            else
                                SQLString.Add( OtherCast( model ) );
                        }
                    }
                }
            }
            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        DataTable GetDataTableOfPqbe ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AM021,AM023,AM025,AM027,AM029 FROM R_PQAM" );
            strSql.Append( " WHERE AM002=@AM002" );
            SqlParameter[] parameter = {
                new SqlParameter("@AM002",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        void ofPqbe ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            DataTable da = GetDataTableOfPqbe( model.AM002 );
            if ( da != null && da.Rows.Count > 0 )
            {
                model.AM021 += string.IsNullOrEmpty( da.Rows[0]["AM021"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM021"].ToString( ) );
                model.AM023 += string.IsNullOrEmpty( da.Rows[0]["AM023"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM023"].ToString( ) );
                model.AM025 += string.IsNullOrEmpty( da.Rows[0]["AM025"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM025"].ToString( ) );
                model.AM027 += string.IsNullOrEmpty( da.Rows[0]["AM027"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM027"].ToString( ) );
                model.AM029 += string.IsNullOrEmpty( da.Rows[0]["AM029"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM029"].ToString( ) );
            }
        }

        //public DataTable GetDataTablePqwz ( string idxListOfGong)
        //{
        //    StringBuilder strSql = new StringBuilder( );
        //    strSql.Append( "" );
        //}

        /// <summary>
        /// 获取241全部已付款
        /// </summary>
        /// <returns></returns>
        public DataTable ExistsOfSum ( string state )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx FROM R_PQBB WHERE idx=(SELECT MAX(idx) FROM R_PQBB WHERE BB004='MLL' AND BB001=@BB001)" );
            SqlParameter[] parameter = {
                new SqlParameter("@BB001",SqlDbType.NVarChar)
            };
            parameter[0].Value = state;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public DataTable GetDataTableOfSum ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT CONVERT(DECIMAL(18,1),SUM(ISNULL(AM262,0)+ISNULL(AM264,0)+ISNULL(AM266,0)+ISNULL(AM268,0)+ISNULL(AM269,0)+ISNULL(AM289,0)+ISNULL(AM291,0)+ISNULL(AM293,0)+ISNULL(AM295,0)+ISNULL(AM331,0)+ISNULL(AM334,0)+ISNULL(AM335,0)+ISNULL(AM337,0)+ISNULL(AM340,0)+ISNULL(AM341,0)+ISNULL(AM344,0)+ISNULL(AM347,0)+ISNULL(AM348,0)+ISNULL(AM350,0)+ISNULL(AM353,0)+ISNULL(AM354,0)+ISNULL(AM356,0)+ISNULL(AM359,0)+ISNULL(AM360,0)+ISNULL(AM362,0)+ISNULL(AM365,0)+ISNULL(AM366,0)+ISNULL(AM368,0)+ISNULL(AM371,0)+ISNULL(AM372,0)+ISNULL(AM374,0)+ISNULL(AM377,0)+ISNULL(AM378,0)+ISNULL(AM380,0)+ISNULL(AM383,0)+ISNULL(AM386,0)+ISNULL(AM387,0)+ISNULL(AM389,0)+ISNULL(AM392,0)+ISNULL(AM393,0)+ISNULL(AM299,0)+ISNULL(AM302,0)+ISNULL(AM305,0)+ISNULL(AM308,0)+ISNULL(AM312,0)+ISNULL(AM316,0)+ISNULL(AM319,0)+ISNULL(AM322,0)+ISNULL(AM303,0)+ISNULL(AM309,0)+ISNULL(AM317,0)+ISNULL(AM323,0)+ISNULL(AM325,0)+ISNULL(AM327,0)+ISNULL(AM329,0)+ISNULL(AM297,0)+ISNULL(AM271,0)+ISNULL(AM274,0)+ISNULL(AM275,0)+ISNULL(AM278,0)+ISNULL(AM281,0)+ISNULL(AM282,0)+ISNULL(AM284,0)+ISNULL(AM286,0)+ISNULL(AM243,0)+ISNULL(AM246,0)+ISNULL(AM250,0)+ISNULL(AM251,0)+ISNULL(AM253,0)+ISNULL(AM210,0)+ISNULL(AM213,0)+ISNULL(AM214,0)+ISNULL(AM216,0)+ISNULL(AM219,0)+ISNULL(AM220,0)+ISNULL(AM222,0)+ISNULL(AM224,0)+ISNULL(AM176,0)+ISNULL(AM179,0)+ISNULL(AM180,0)+ISNULL(AM183,0)+ISNULL(AM186,0)+ISNULL(AM187,0)+ISNULL(AM189,0)+ISNULL(AM192,0)+ISNULL(AM193,0)+ISNULL(AM195,0)+ISNULL(AM198,0)+ISNULL(AM199,0)+ISNULL(AM201,0)+ISNULL(AM204,0)+ISNULL(AM206,0)+ISNULL(AM208,0)+ISNULL(AM137,0)+ISNULL(AM140,0)+ISNULL(AM143,0)+ISNULL(AM146,0)+ISNULL(AM149,0)+ISNULL(AM141,0)+ISNULL(AM147,0)+ISNULL(AM135,0)+ISNULL(AM134,0)+ISNULL(AM131,0)+ISNULL(AM109,0)+ISNULL(AM112,0)+ISNULL(AM071,0)+ISNULL(AM073,0)+ISNULL(AM075,0)+ISNULL(AM077,0)+ISNULL(AM079,0)+ISNULL(AM081,0)+ISNULL(AM083,0)+ISNULL(AM085,0)+ISNULL(AM087,0)+ISNULL(AM089,0)+ISNULL(AM091,0)+ISNULL(AM093,0)+ISNULL(AM045,0)+ISNULL(AM047,0)+ISNULL(AM049,0)+ISNULL(AM051,0)+ISNULL(AM053,0)+ISNULL(AM055,0)+ISNULL(AM057,0)+ISNULL(AM059,0)+ISNULL(AM061,0)+ISNULL(AM063,0)+ISNULL(AM021,0)+ISNULL(AM023,0)+ISNULL(AM025,0)+ISNULL(AM027,0)+ISNULL(AM029,0)+ISNULL(AM113,0)+ISNULL(AM116,0)+ISNULL(AM226,0)+ISNULL(AM228,0)+ISNULL(AM230,0)+ISNULL(AM232,0)+ISNULL(AM234,0)+ISNULL(AM236,0)+ISNULL(AM238,0)+ISNULL(AM256,0)+ISNULL(AM154,0)+ISNULL(AM156,0)+ISNULL(AM157,0)+ISNULL(AM158,0))) U16 FROM R_PQAM" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public string OfSumAdd ( MulaolaoLibrary.ProductCostSummaryOfSumLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQBB (" );
            strSql.Append( "BB001,BB002,BB003,BB004)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}')" ,_model.BB001 ,_model.BB002 ,_model.BB003 ,_model.BB004 );

            return strSql.ToString( );
        }
        public string OfSum ( MulaolaoLibrary.ProductCostSummaryOfSumLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQBB SET " );
            strSql.AppendFormat( "BB002='{0}'," ,_model.BB002 );
            strSql.AppendFormat( "BB003='{0}'" ,_model.BB003 );
            strSql.AppendFormat( " WHERE BB001='{0}'" ,_model.BB001 );

            return strSql.ToString( );
        }
        public ArrayList Pqbb ( DataTable dk ,MulaolaoLibrary.ProductCostSummaryOfSumLibrary _model ,ArrayList SQLString )
        {
            dk = GetDataTableOfSum( );
            if ( dk != null && dk.Rows.Count > 0 )
            {
                _model.BB003 = string.IsNullOrEmpty( dk.Rows[0]["U16"].ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Rows[0]["U16"].ToString( ) );
                _model.BB004 = "MLL";
                //DataTable dn = ExistsOfSum( _model.BB001 );
                //if ( dn != null && dn.Rows.Count > 0 )
                //{
                //_model.IDX = string.IsNullOrEmpty( dn.Rows[0]["idx"].ToString( ) ) == true ? 0 : Convert.ToInt32( dn.Rows[0]["idx"].ToString( ) );
                SQLString.Add( OfSum( _model ) );
                //}
                //else
                //    SQLString.Add( OfSumAdd( _model ) );
            }

            return SQLString;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfF12 ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT MAX(BB003)-MIN(BB003) BB FROM R_PQBB" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 去除勾选掉的内容
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Delete256WriteTo241 ( DataTable table )
        {
            bool result = false;
            ArrayList SQLString = new ArrayList( );
            DataTable dk;
            MulaolaoLibrary.ProductCostSummaryLibrary model = new MulaolaoLibrary.ProductCostSummaryLibrary( );
            MulaolaoLibrary.ProductCostSummaryOfSumLibrary _model = new MulaolaoLibrary.ProductCostSummaryOfSumLibrary( );
            MulaolaoLibrary.PayMentLibrary modelOne = new MulaolaoLibrary.PayMentLibrary( );
            string idxList = "", numList = "", idxListOf = "", idxListOfOther = "";
            if ( table != null && table.Rows.Count > 0 )
            {
                modelOne.YZ001 = table.Rows[0]["YZ001"].ToString( );
                dk = GetDataTableOfAllState( modelOne.YZ001 );
                if ( dk != null && dk.Rows.Count > 0 )
                {
                    for ( int k = 0 ; k < dk.Rows.Count ; k++ )
                    {
                        modelOne.IDX = string.IsNullOrEmpty( dk.Rows[k]["idx"].ToString( ) ) == true ? 0 : Convert.ToInt32( dk.Rows[k]["idx"].ToString( ) );
                        if ( table.Select( "idx='" + modelOne.IDX + "'" ).Length < 0 )
                        {
                            if ( idxList == "" )
                                idxList = dk.Rows[k]["YZ022"].ToString( );
                            else
                                idxList = idxList + "," + dk.Rows[k]["YZ022"].ToString( );
                            if ( idxListOf == "" )
                                idxListOf = dk.Rows[k]["YZ027"].ToString( );
                            else
                                idxListOf = idxListOf + "," + dk.Rows[k]["YZ027"].ToString( );
                            if ( idxListOfOther == "" )
                                idxListOfOther = dk.Rows[k]["YZ030"].ToString( );
                            else
                                idxListOfOther = idxListOfOther + "," + dk.Rows[k]["YZ030"].ToString( );
                        }
                        if ( table.Select( "idx='" + modelOne.IDX + "'" ).Length>0 && !table.Select( "idx='" + modelOne.IDX + "'" )[0]["YZ003"].ToString( ).Contains( "审核" ) && !table.Select( "idx='" + modelOne.IDX + "'" )[0]["YZ003"].ToString( ).Contains( "执行" ) )
                        {
                            if ( idxList == "" )
                                idxList = dk.Rows[k]["YZ022"].ToString( );
                            else
                                idxList = idxList + "," + dk.Rows[k]["YZ022"].ToString( );
                            if ( idxListOf == "" )
                                idxListOf = dk.Rows[k]["YZ027"].ToString( );
                            else
                                idxListOf = idxListOf + "," + dk.Rows[k]["YZ027"].ToString( );
                            if ( idxListOfOther == "" )
                                idxListOfOther = dk.Rows[k]["YZ030"].ToString( );
                            else
                                idxListOfOther = idxListOfOther + "," + dk.Rows[k]["YZ030"].ToString( );
                        }
                    }


                    if ( !string.IsNullOrEmpty( idxList )  )
                    {
                        do
                        {
                            idxList = idxList.Replace( ",," ,"," );
                        } while ( idxList.Contains( ",," ) );
                        idxList = idxList.TrimEnd( ',' );
                        DataTable dl = GetDataTablePqak( idxList );
                        if ( dl != null && dl.Rows.Count > 0 )
                        {
                            for ( int k = 0 ; k < dl.Rows.Count ; k++ )
                            {
                                if ( numList == "" )
                                    numList = "'" + dl.Rows[k]["AK002"].ToString( ) + "'";
                                else
                                    numList = numList + "," + "'" + dl.Rows[k]["AK002"].ToString( ) + "'";
                            }

                            #region 195
                            result = PqqDelete( idxList ,numList ,model ,dk ,SQLString );
                            if ( result == false )
                                return false;
                            #endregion

                            #region 196
                            SQLString.Clear( );
                            result = PqahDelete( idxList ,numList ,model ,dk ,SQLString );
                            if ( result == false )
                                return false;
                            #endregion

                            #region 338
                            SQLString.Clear( );
                            result = PqoDelete( idxList ,numList ,model ,dk ,SQLString );
                            if ( result == false )
                                return false;
                            #endregion

                            #region 339
                            SQLString.Clear( );
                            result = PqiDetele( idxList ,numList ,model ,dk ,SQLString );
                            if ( result == false )
                                return false;
                            #endregion

                            #region 341
                            SQLString.Clear( );
                            result = PqvDelete( idxList ,numList ,model ,dk ,SQLString );
                            if ( result == false )
                                return false;
                            #endregion

                            #region 342
                            SQLString.Clear( );
                            result = PqafDelete( idxList ,numList ,model ,dk ,SQLString );
                            if ( result == false )
                                return false;
                            #endregion

                            #region 343
                            SQLString.Clear( );
                            result = PquDelete( idxList ,numList ,model ,dk ,SQLString );
                            if ( result == false )
                                return false;
                            #endregion

                            #region 344
                            SQLString.Clear( );
                            result = PqlzDelete( idxList ,numList ,model ,dk ,SQLString );
                            if ( result == false )
                                return false;
                            #endregion

                            #region 344 工资
                            SQLString.Clear( );
                            result = PqmzDelete( idxList ,numList ,model ,dk ,SQLString );
                            if ( result == false )
                                return false;
                            #endregion

                            #region 347
                            SQLString.Clear( );
                            result = PqsDelete( idxList ,numList ,model ,dk ,SQLString );
                            if ( result == false )
                                return false;
                            #endregion

                            #region 348
                            SQLString.Clear( );
                            result = PqtDeletes( idxList ,numList ,model ,dk ,SQLString );
                            if ( result == false )
                                return false;
                            #endregion

                            #region 349
                            SQLString.Clear( );
                            result = PqtDelete( idxList ,numList ,model ,dk ,SQLString );
                            if ( result == false )
                                return false;
                            #endregion

                            //#region 495
                            ////读到241喷漆工资
                            //SQLString.Clear( );
                            //result = PqyDelete( idxList ,numList ,model ,dk ,SQLString );
                            //if ( result == false )
                            //    return false;
                            //#endregion
                        }
                    }
                    if ( !string.IsNullOrEmpty( idxListOf ) )
                    {
                        do
                        {
                            idxListOf = idxListOf.Replace( ",," ,"," );
                        } while ( idxListOf.Contains( ",," ) );
                        idxListOf = idxListOf.TrimEnd( ',' );

                        #region 317
                        SQLString.Clear( );
                        result = PqwDelete( idxListOf ,numList ,model ,dk ,SQLString );
                        if ( result == false )
                            return false;
                        #endregion
                    }

                    if ( !string.IsNullOrEmpty( idxListOfOther ) )
                    {
                        do
                        {
                            idxListOfOther = idxListOfOther.Replace( ",," ,"," );
                        } while ( idxListOfOther.Contains( ",," ) );
                        idxListOfOther = idxListOfOther.TrimEnd( ',' );
                        
                        #region 243
                        SQLString.Clear( );
                        result = PqbeDelete( idxListOfOther ,model ,dk ,SQLString );
                        if ( result == false )
                            return false;
                        #endregion
                    }

                    if ( !string.IsNullOrEmpty( idxList ) || !string.IsNullOrEmpty( idxListOf ) || !string.IsNullOrEmpty( idxListOfOther ) )
                    {
                        if ( dk.Select( "YZ003='审核'" ).Length > 0 )
                        {
                            _model.BB001 = "审核";
                            _model.BB002 = string.IsNullOrEmpty( dk.Select( "YZ003='审核'" )[0]["YZ009"].ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( dk.Select( "YZ003='审核'" )[0]["YZ009"].ToString( ) );
                        }
                        else if ( dk.Select( "YZ003='执行'" ).Length > 0 )
                        {
                            _model.BB001 = "执行";
                            _model.BB002 = string.IsNullOrEmpty( dk.Select( "YZ003='执行'" )[0]["YZ009"].ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( dk.Select( "YZ003='执行'" )[0]["YZ009"].ToString( ) );
                        }
                        else
                            return false;

                        #region 241总金额
                        SQLString.Clear( );
                        //循环有问题
                        SQLString.Clear( );
                        Pqbb( dk ,_model ,SQLString );
                        #endregion
                    }
                }
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        public bool Delete256WriteTo241AP ( DataTable table )
        {
            bool result = false;
            ArrayList SQLString = new ArrayList( );
            DataTable dk;
            MulaolaoLibrary.ProductCostSummaryLibrary model = new MulaolaoLibrary.ProductCostSummaryLibrary( );
            MulaolaoLibrary.ProductCostSummaryOfSumLibrary _model = new MulaolaoLibrary.ProductCostSummaryOfSumLibrary( );
            MulaolaoLibrary.PayMentOneLibrary _modelOne = new MulaolaoLibrary.PayMentOneLibrary( );
            string idxList = "", numList = "", idxListOf = "", idxListOfOther = "";
            if ( table != null && table.Rows.Count > 0 )
            {
                _modelOne.AP001 = table.Rows[0]["AP001"].ToString( );
                dk = GetDataTableOfAllStates( _modelOne.AP001 );
                if ( dk != null && dk.Rows.Count > 0 )
                {
                    for ( int k = 0 ; k < dk.Rows.Count ; k++ )
                    {
                        _modelOne.IDX = string.IsNullOrEmpty( dk.Rows[k]["idx"].ToString( ) ) == true ? 0 : Convert.ToInt32( dk.Rows[k]["idx"].ToString( ) );
                        if ( table.Select( "idx='" + _modelOne.IDX + "'" ).Length < 0 )
                        {
                            if ( idxList == "" )
                                idxList = dk.Rows[k]["AP022"].ToString( );
                            else
                                idxList = idxList + "," + dk.Rows[k]["AP022"].ToString( );
                            if ( idxListOf == "" )
                                idxListOf = dk.Rows[k]["AP027"].ToString( );
                            else
                                idxListOf = idxListOf + "," + dk.Rows[k]["AP027"].ToString( );
                            if ( idxListOfOther == "" )
                                idxListOfOther = dk.Rows[k]["AP030"].ToString( );
                            else
                                idxListOfOther = idxListOfOther + "," + dk.Rows[k]["AP030"].ToString( );
                        }
                        if ( table.Select( "idx='" + _modelOne.IDX + "'" ).Length>0 && !table.Select( "idx='" + _modelOne.IDX + "'" )[0]["AP003"].ToString( ).Contains( "审核" ) && !table.Select( "idx='" + _modelOne.IDX + "'" )[0]["AP003"].ToString( ).Contains( "执行" ) )
                        {
                            if ( idxList == "" )
                                idxList = dk.Rows[k]["AP022"].ToString( );
                            else
                                idxList = idxList + "," + dk.Rows[k]["AP022"].ToString( );
                            if ( idxListOf == "" )
                                idxListOf = dk.Rows[k]["AP027"].ToString( );
                            else
                                idxListOf = idxListOf + "," + dk.Rows[k]["AP027"].ToString( );
                            if ( idxListOfOther == "" )
                                idxListOfOther = dk.Rows[k]["AP030"].ToString( );
                            else
                                idxListOfOther = idxListOfOther + "," + dk.Rows[k]["AP030"].ToString( );
                        }
                    }


                    if ( !string.IsNullOrEmpty( idxList ) )
                    {
                        do
                        {
                            idxList = idxList.Replace( ",," ,"," );
                        } while ( idxList.Contains( ",," ) );
                        idxList = idxList.TrimEnd( ',' );

                        DataTable dl = GetDataTablePqak( idxList );
                        if ( dl != null && dl.Rows.Count > 0 )
                        {
                            for ( int k = 0 ; k < dl.Rows.Count ; k++ )
                            {
                                if ( numList == "" )
                                    numList = "'" + dl.Rows[k]["AK002"].ToString( ) + "'";
                                else
                                    numList = numList + "," + "'" + dl.Rows[k]["AK002"].ToString( ) + "'";
                            }

                            #region 195
                            result = PqqDelete( idxList ,numList ,model ,dk ,SQLString );
                            if ( result == false )
                                return false;
                            #endregion

                            #region 196
                            SQLString.Clear( );
                            result = PqahDelete( idxList ,numList ,model ,dk ,SQLString );
                            if ( result == false )
                                return false;
                            #endregion

                            #region 338
                            SQLString.Clear( );
                            result = PqoDelete( idxList ,numList ,model ,dk ,SQLString );
                            if ( result == false )
                                return false;
                            #endregion

                            #region 339
                            SQLString.Clear( );
                            result = PqiDetele( idxList ,numList ,model ,dk ,SQLString );
                            if ( result == false )
                                return false;
                            #endregion

                            #region 341
                            SQLString.Clear( );
                            result = PqvDelete( idxList ,numList ,model ,dk ,SQLString );
                            if ( result == false )
                                return false;
                            #endregion

                            #region 342
                            SQLString.Clear( );
                            result = PqafDelete( idxList ,numList ,model ,dk ,SQLString );
                            if ( result == false )
                                return false;
                            #endregion

                            #region 343
                            SQLString.Clear( );
                            result = PquDelete( idxList ,numList ,model ,dk ,SQLString );
                            if ( result == false )
                                return false;
                            #endregion

                            #region 344
                            SQLString.Clear( );
                            result = PqlzDelete( idxList ,numList ,model ,dk ,SQLString );
                            if ( result == false )
                                return false;
                            #endregion

                            #region 344 工资
                            SQLString.Clear( );
                            result = PqmzDelete( idxList ,numList ,model ,dk ,SQLString );
                            if ( result == false )
                                return false;
                            #endregion

                            #region 347
                            SQLString.Clear( );
                            result = PqsDelete( idxList ,numList ,model ,dk ,SQLString );
                            if ( result == false )
                                return false;
                            #endregion

                            #region 348
                            SQLString.Clear( );
                            result = PqtDeletes( idxList ,numList ,model ,dk ,SQLString );
                            if ( result == false )
                                return false;
                            #endregion

                            #region 349
                            SQLString.Clear( );
                            result = PqtDelete( idxList ,numList ,model ,dk ,SQLString );
                            if ( result == false )
                                return false;
                            #endregion                          

                            //#region 495
                            ////读到241喷漆工资
                            //SQLString.Clear( );
                            //result = PqyDelete( idxList ,numList ,model ,dk ,SQLString );
                            //if ( result == false )
                            //    return false;
                            //#endregion
                        }
                    }
                    if ( !string.IsNullOrEmpty( idxListOf ) )
                    {
                        do
                        {
                            idxListOf = idxListOf.Replace( ",," ,"," );
                        } while ( idxListOf.Contains( ",," ) );
                        idxListOf = idxListOf.TrimEnd( ',' );
                        #region 317
                        SQLString.Clear( );
                        result = PqwDelete( idxListOf ,numList ,model ,dk ,SQLString );
                        if ( result == false )
                            return false;
                        #endregion
                    }

                    if ( !string.IsNullOrEmpty( idxListOfOther ) )
                    {
                        do
                        {
                            idxListOfOther = idxListOfOther.Replace( ",," ,"," );
                        } while ( idxListOfOther.Contains( ",," ) );
                        idxListOfOther = idxListOfOther.TrimEnd( ',' );

                        #region 243
                        SQLString.Clear( );
                        result = PqbeDelete( idxListOfOther ,model ,dk ,SQLString );
                        if ( result == false )
                            return false;
                        #endregion
                    }

                    if ( !string.IsNullOrEmpty( idxList ) || !string.IsNullOrEmpty( idxListOf ) || !string.IsNullOrEmpty( idxListOfOther ) )
                    {
                        if ( dk.Select( "AP003='审核'" ).Length > 0 )
                        {
                            _model.BB001 = "审核";
                            _model.BB002 = string.IsNullOrEmpty( dk.Select( "AP003='审核'" )[0]["AP009"].ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( dk.Select( "AP003='审核'" )[0]["AP009"].ToString( ) );
                        }
                        else if ( dk.Select( "AP003='执行'" ).Length > 0 )
                        {
                            _model.BB001 = "执行";
                            _model.BB002 = string.IsNullOrEmpty( dk.Select( "AP003='执行'" )[0]["AP009"].ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( dk.Select( "AP003='执行'" )[0]["AP009"].ToString( ) );
                        }
                        else
                            return false;

                        #region 241总金额
                        SQLString.Clear( );
                        //循环有问题
                        SQLString.Clear( );
                        Pqbb( dk ,_model ,SQLString );
                        #endregion
                    }
                }
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取已执行和审核的记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfAllState ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQYZ" );
            strSql.Append( " WHERE YZ001=@YZ001" );
            strSql.Append( " AND YZ003 IN ('执行','审核')" );
            SqlParameter[] parameter = {
                new SqlParameter("@YZ001",SqlDbType.NVarChar)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public DataTable GetDataTableOfAllStates ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQAP" );
            strSql.Append( " WHERE AP001=@AP001" );
            strSql.Append( " AND AP003 IN ('执行','审核')" );
            SqlParameter[] parameter = {
                new SqlParameter("@AP001",SqlDbType.NVarChar)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 195
        /// </summary>
        /// <param name="idxList"></param>
        /// <param name="numList"></param>
        /// <param name="model"></param>
        /// <param name="dk"></param>
        /// <param name="SQLString"></param>
        /// <returns></returns>
        public bool PqqDelete ( string idxList ,string numList ,MulaolaoLibrary.ProductCostSummaryLibrary model ,DataTable dk ,ArrayList SQLString )
        {
            dk = GetDataTablePqq( numList ,idxList );
            if ( dk != null && dk.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < dk.Rows.Count ; i++ )
                {
                    model.AM109 = model.AM112 = 0M;
                    model.AM002 = dk.Rows[i]["CP01"].ToString( );//AND (AK017='执行' OR AK017='审核')
                    model .AM109 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"CP01='" + model.AM002 + "' AND CP58='F' " ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"CP01='" + model.AM002 + "' AND CP58='F' " ) );
                    model.AM112 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"CP01='" + model.AM002 + "' AND CP58='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"CP01='" + model.AM002 + "' AND CP58='T' " ) );
                    if ( i == 0 && ExistsOfCount( model.AM002 ) )
                    {
                        ofOneDelete( model );
                        UpdatePqqDelete( model ,SQLString );
                    }
                    else if ( i > 0 && model.AM002 != dk.Rows[i-1]["CP01"].ToString( ) )
                    {
                        ofOneDelete( model );
                        UpdatePqqDelete( model ,SQLString );
                    }
                }
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        void ofOneDelete ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            DataTable ofOne = GetDataTableOfOne( model.AM002 );
            if ( ofOne != null && ofOne.Rows.Count > 0 )
            {
                model.AM109 = string.IsNullOrEmpty( ofOne.Rows[0]["AM109"].ToString( ) ) == true ? 0 : Convert.ToDecimal( ofOne.Rows[0]["AM109"].ToString( ) ) - model.AM109;
                model.AM112 = string.IsNullOrEmpty( ofOne.Rows[0]["AM112"].ToString( ) ) == true ? 0 : Convert.ToDecimal( ofOne.Rows[0]["AM112"].ToString( ) ) - model.AM112;
            }
        }
        public void UpdatePqqDelete ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            strSql.AppendFormat( "AM109='{0}'," ,model.AM109 );
            strSql.AppendFormat( "AM112='{0}'" ,model.AM112 );
            strSql.AppendFormat( " WHERE AM002='{0}'" ,model.AM002 );
            SQLString.Add( strSql.ToString( ) );
        }

        /// <summary>
        /// 196
        /// </summary>
        /// <param name="idxList"></param>
        /// <param name="numList"></param>
        /// <param name="model"></param>
        /// <param name="dk"></param>
        /// <param name="SQLString"></param>
        /// <returns></returns>
        public bool PqahDelete ( string idxList ,string numList ,MulaolaoLibrary.ProductCostSummaryLibrary model ,DataTable dk ,ArrayList SQLString )
        {
            dk = GetDataTableTwo( numList ,idxList );
            if ( dk != null && dk.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < dk.Rows.Count ; i++ )
                {
                    //model.AM109 = model.AM112 =
                    model . AM071 = model.AM073 = model.AM075 = model.AM077 = model.AM079 = model.AM081 = model.AM083 = model.AM085 = model.AM087 = model.AM089 = model.AM091 = model.AM093 =  0;
                    model.AM002 = dk.Rows[i]["CP01"].ToString( );//AND (AK017='执行' OR AK017='审核')
                    model .AM071 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"CP01='" + model.AM002 + "' AND AH18='雕刻' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"CP01='" + model.AM002 + "' AND AH18='雕刻' " ) );
                    model.AM073 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"CP01='" + model.AM002 + "' AND AH18='绕锯' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"CP01='" + model.AM002 + "' AND AH18='绕锯' " ) );
                    model.AM075 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"CP01='" + model.AM002 + "' AND AH18='夹料' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"CP01='" + model.AM002 + "' AND AH18='夹料' " ) );
                    model.AM077 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"CP01='" + model.AM002 + "' AND AH18='擦砂皮' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"CP01='" + model.AM002 + "' AND AH18='擦砂皮' " ) );
                    model.AM079 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"CP01='" + model.AM002 + "' AND AH18='丝印' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"CP01='" + model.AM002 + "' AND AH18='丝印' " ) );
                    model.AM081 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"CP01='" + model.AM002 + "' AND AH18='走台印' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"CP01='" + model.AM002 + "' AND AH18='走台印' " ) );
                    model.AM083 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"CP01='" + model.AM002 + "' AND AH18='移印' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"CP01='" + model.AM002 + "' AND AH18='移印' " ) );
                    model.AM085 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"CP01='" + model.AM002 + "' AND AH18='热转印' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"CP01='" + model.AM002 + "' AND AH18='热转印' " ) );
                    model.AM087 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"CP01='" + model.AM002 + "' AND AH18='烫印' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"CP01='" + model.AM002 + "' AND AH18='烫印' " ) );
                    model.AM089 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"CP01='" + model.AM002 + "' AND AH18='喷漆' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"CP01='" + model.AM002 + "' AND AH18='喷漆' " ) );
                    model.AM091 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"CP01='" + model.AM002 + "' AND AH18='冲压' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"CP01='" + model.AM002 + "' AND AH18='冲压' " ) );
                    model.AM093 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"CP01='" + model.AM002 + "' AND AH18='手工剪切、其它' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"CP01='" + model.AM002 + "' AND AH18='手工剪切、其它' " ) );
                    //model.AM109 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"CP01='" + model.AM002 + "' AND AH18='委外' AND CP58='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"CP01='" + model.AM002 + "' AND AH18='委外' AND CP58='F'" ) );
                    //model.AM112 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"CP01='" + model.AM002 + "' AND AH18='委外' AND CP58='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"CP01='" + model.AM002 + "' AND AH18='委外' AND CP58='T'" ) );

                    if ( i == 0 && ExistsOfCount( model.AM002 ) )
                    {
                        ofTwoDelete( model );
                        UpdatePqahDelete( model ,SQLString );
                    }
                    else if ( i > 0 && model.AM002 != dk.Rows[i - 1]["CP01"].ToString( ) )
                    {
                        ofTwoDelete( model );
                        UpdatePqahDelete( model ,SQLString );
                    }
                }
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        void ofTwoDelete ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            DataTable ofTwo = GetDataTableOfTwo( model.AM002 );
            if ( ofTwo != null && ofTwo.Rows.Count > 0 )
            {
                model.AM071 = string.IsNullOrEmpty( ofTwo.Rows[0]["AM071"].ToString( ) ) == true ? 0 : Convert.ToDecimal( ofTwo.Rows[0]["AM071"].ToString( ) ) - model.AM071;
                model.AM073 = string.IsNullOrEmpty( ofTwo.Rows[0]["AM073"].ToString( ) ) == true ? 0 : Convert.ToDecimal( ofTwo.Rows[0]["AM073"].ToString( ) ) - model.AM073;
                model.AM075 = string.IsNullOrEmpty( ofTwo.Rows[0]["AM075"].ToString( ) ) == true ? 0 : Convert.ToDecimal( ofTwo.Rows[0]["AM075"].ToString( ) ) - model.AM075;
                model.AM077 = string.IsNullOrEmpty( ofTwo.Rows[0]["AM077"].ToString( ) ) == true ? 0 : Convert.ToDecimal( ofTwo.Rows[0]["AM077"].ToString( ) ) - model.AM077;
                model.AM079 = string.IsNullOrEmpty( ofTwo.Rows[0]["AM079"].ToString( ) ) == true ? 0 : Convert.ToDecimal( ofTwo.Rows[0]["AM079"].ToString( ) ) - model.AM079;
                model.AM081 = string.IsNullOrEmpty( ofTwo.Rows[0]["AM081"].ToString( ) ) == true ? 0 : Convert.ToDecimal( ofTwo.Rows[0]["AM081"].ToString( ) ) - model.AM081;
                model.AM083 = string.IsNullOrEmpty( ofTwo.Rows[0]["AM083"].ToString( ) ) == true ? 0 : Convert.ToDecimal( ofTwo.Rows[0]["AM083"].ToString( ) ) - model.AM083;
                model.AM085 = string.IsNullOrEmpty( ofTwo.Rows[0]["AM085"].ToString( ) ) == true ? 0 : Convert.ToDecimal( ofTwo.Rows[0]["AM085"].ToString( ) ) - model.AM085;
                model.AM087 = string.IsNullOrEmpty( ofTwo.Rows[0]["AM087"].ToString( ) ) == true ? 0 : Convert.ToDecimal( ofTwo.Rows[0]["AM087"].ToString( ) ) - model.AM087;
                model.AM089 = string.IsNullOrEmpty( ofTwo.Rows[0]["AM089"].ToString( ) ) == true ? 0 : Convert.ToDecimal( ofTwo.Rows[0]["AM089"].ToString( ) ) - model.AM089;
                model.AM091 = string.IsNullOrEmpty( ofTwo.Rows[0]["AM091"].ToString( ) ) == true ? 0 : Convert.ToDecimal( ofTwo.Rows[0]["AM091"].ToString( ) ) - model.AM091;
                model.AM093 = string.IsNullOrEmpty( ofTwo.Rows[0]["AM093"].ToString( ) ) == true ? 0 : Convert.ToDecimal( ofTwo.Rows[0]["AM093"].ToString( ) ) - model.AM093;
                //model.AM109 = string.IsNullOrEmpty( ofTwo.Rows[0]["AM109"].ToString( ) ) == true ? 0 : Convert.ToDecimal( ofTwo.Rows[0]["AM109"].ToString( ) ) - model.AM109;
                //model.AM112 = string.IsNullOrEmpty( ofTwo.Rows[0]["AM112"].ToString( ) ) == true ? 0 : Convert.ToDecimal( ofTwo.Rows[0]["AM112"].ToString( ) ) - model.AM112;
            }
        }
        public void UpdatePqahDelete ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            strSql.AppendFormat( "AM071='{0}'," ,model.AM071 );
            strSql.AppendFormat( "AM073='{0}'," ,model.AM073 );
            strSql.AppendFormat( "AM075='{0}'," ,model.AM075 );
            strSql.AppendFormat( "AM077='{0}'," ,model.AM077 );
            strSql.AppendFormat( "AM079='{0}'," ,model.AM079 );
            strSql.AppendFormat( "AM081='{0}'," ,model.AM081 );
            strSql.AppendFormat( "AM083='{0}'," ,model.AM083 );
            strSql.AppendFormat( "AM085='{0}'," ,model.AM085 );
            strSql.AppendFormat( "AM087='{0}'," ,model.AM087 );
            strSql.AppendFormat( "AM089='{0}'," ,model.AM089 );
            strSql.AppendFormat( "AM091='{0}'," ,model.AM091 );
            strSql.AppendFormat( "AM093='{0}'" ,model.AM093 );
            //strSql.AppendFormat( "AM109='{0}'," ,model.AM109 );
            //strSql.AppendFormat( "AM112='{0}'" ,model.AM112 );
            strSql.AppendFormat( " WHERE AM002='{0}'" ,model.AM002 );
            SQLString.Add( strSql.ToString( ) );
        }

        /// <summary>
        /// 338
        /// </summary>
        /// <param name="idxList"></param>
        /// <param name="numList"></param>
        /// <param name="model"></param>
        /// <param name="dk"></param>
        /// <param name="SQLString"></param>
        /// <returns></returns>
        public bool PqoDelete ( string idxList ,string numList ,MulaolaoLibrary.ProductCostSummaryLibrary model ,DataTable dk ,ArrayList SQLString )
        {
            dk = GetDataTablePqo( numList ,idxList );
            if ( dk != null && dk.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < dk.Rows.Count ; i++ )
                {
                    model.AM297 = model.AM299 = model.AM302 = model.AM303 = model.AM305 = model.AM308 = model.AM309 = model.AM312 = model.AM316 = model.AM317 = model.AM319 = model.AM322 = model.AM323 = model.AM325 = model.AM327 = model.AM329 = 0;

                    model.AM002 = dk.Rows[i]["JM90"].ToString( );

                    model.AM299 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='外购' AND JM107='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='外购' AND JM107='F' " ) );
                    model.AM303 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='外购' AND JM107='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='外购' AND JM107='T' " ) );

                    model.AM308 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='外购' AND JM107='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='外购' AND JM107='F' " ) );
                    model.AM323 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='外购' AND JM107='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='外购' AND JM107='T' " ) );

                    model.AM302 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='外购' AND JM107='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='外购' AND JM107='F' " ) );
                    model.AM309 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='外购' AND JM107='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='外购' AND JM107='T' " ) );

                    model.AM312 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='外购' AND JM107='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='外购' AND JM107='F' " ) );
                    model.AM325 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='外购' AND JM107='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='外购' AND JM107='T' " ) );

                    model.AM305 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='库存' AND JM107='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='库存' AND JM107='F' " ) );
                    model.AM317 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='库存' AND JM107='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='库存' AND JM107='T' " ) );

                    model.AM316 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='库存' AND JM107='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='库存' AND JM107='F' " ) );
                    model.AM327 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='库存' AND JM107='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='库存' AND JM107='T' " ) );

                    model.AM319 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='库存' AND JM107='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='库存' AND JM107='F' " ) );
                    model.AM329 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='库存' AND JM107='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='库存' AND JM107='T' " ) );

                    model.AM322 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='库存' AND JM107='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='库存' AND JM107='F' " ) );
                    model.AM297 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='库存' AND JM107='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"JM90='" + model.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='库存' AND JM107='T' " ) );

                    if ( i == 0 && ExistsOfCount( model.AM002 ) )
                    {
                        ofTreDelete( model );
                        PlywoodDelete( model ,SQLString );
                    }
                    else if ( i > 0 && model.AM002 != dk.Rows[i - 1]["JM90"].ToString( ) )
                    {
                        ofTreDelete( model );
                        PlywoodDelete( model ,SQLString );
                    }
                }
            }
            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        void ofTreDelete ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            DataTable da = GetDataTableOfTre( model.AM002 );
            if ( da != null && da.Rows.Count > 0 )
            {
                model.AM297 = string.IsNullOrEmpty( da.Rows[0]["AM297"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM297"].ToString( ) ) - model.AM297;
                model.AM299 = string.IsNullOrEmpty( da.Rows[0]["AM299"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM299"].ToString( ) ) - model.AM299;
                model.AM302 = string.IsNullOrEmpty( da.Rows[0]["AM302"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM302"].ToString( ) ) - model.AM302;
                model.AM303 = string.IsNullOrEmpty( da.Rows[0]["AM303"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM303"].ToString( ) ) - model.AM303;
                model.AM305 = string.IsNullOrEmpty( da.Rows[0]["AM305"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM305"].ToString( ) ) - model.AM305;
                model.AM308 = string.IsNullOrEmpty( da.Rows[0]["AM308"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM308"].ToString( ) ) - model.AM308;
                model.AM309 = string.IsNullOrEmpty( da.Rows[0]["AM309"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM309"].ToString( ) ) - model.AM309;
                model.AM312 = string.IsNullOrEmpty( da.Rows[0]["AM312"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM312"].ToString( ) ) - model.AM312;
                model.AM316 = string.IsNullOrEmpty( da.Rows[0]["AM316"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM316"].ToString( ) ) - model.AM316;
                model.AM317 = string.IsNullOrEmpty( da.Rows[0]["AM317"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM317"].ToString( ) ) - model.AM317;
                model.AM319 = string.IsNullOrEmpty( da.Rows[0]["AM319"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM319"].ToString( ) ) - model.AM319;
                model.AM322 = string.IsNullOrEmpty( da.Rows[0]["AM322"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM322"].ToString( ) ) - model.AM322;
                model.AM323 = string.IsNullOrEmpty( da.Rows[0]["AM323"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM323"].ToString( ) ) - model.AM323;
                model.AM325 = string.IsNullOrEmpty( da.Rows[0]["AM325"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM325"].ToString( ) ) - model.AM325;
                model.AM327 = string.IsNullOrEmpty( da.Rows[0]["AM327"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM327"].ToString( ) ) - model.AM327;
                model.AM329 = string.IsNullOrEmpty( da.Rows[0]["AM329"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM329"].ToString( ) ) - model.AM329;
            }
        }
        public void PlywoodDelete ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "UPDATE R_PQAM SET " );
            strSql.AppendFormat( "AM297='{0}'," ,model.AM297 );
            strSql.AppendFormat( "AM299='{0}'," ,model.AM299 );
            strSql.AppendFormat( "AM302='{0}'," ,model.AM302 );
            strSql.AppendFormat( "AM303='{0}'," ,model.AM303 );
            strSql.AppendFormat( "AM305='{0}'," ,model.AM305 );
            strSql.AppendFormat( "AM308='{0}'," ,model.AM308 );
            strSql.AppendFormat( "AM309='{0}'," ,model.AM309 );
            strSql.AppendFormat( "AM312='{0}'," ,model.AM312 );
            strSql.AppendFormat( "AM316='{0}'," ,model.AM316 );
            strSql.AppendFormat( "AM317='{0}'," ,model.AM317 );
            strSql.AppendFormat( "AM319='{0}'," ,model.AM319 );
            strSql.AppendFormat( "AM322='{0}'," ,model.AM322 );
            strSql.AppendFormat( "AM323='{0}'," ,model.AM323 );
            strSql.AppendFormat( "AM325='{0}'," ,model.AM325 );
            strSql.AppendFormat( "AM327='{0}'," ,model.AM327 );
            strSql.AppendFormat( "AM329='{0}'" ,model.AM329 );
            strSql.AppendFormat( " WHERE AM002='{0}'" ,model.AM002 );
            SQLString.Add( strSql.ToString( ) );
        }

        /// <summary>
        /// 339
        /// </summary>
        /// <param name="idxList"></param>
        /// <param name="numList"></param>
        /// <param name="model"></param>
        /// <param name="dk"></param>
        /// <param name="SQLString"></param>
        /// <returns></returns>
        public bool PqiDetele ( string idxList ,string numList ,MulaolaoLibrary.ProductCostSummaryLibrary model ,DataTable dk ,ArrayList SQLString )
        {
            dk = GetDataTablePqi( numList ,idxList );
            if ( dk != null && dk.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < dk.Rows.Count ; i++ )
                {
                    model.AM002 = dk.Rows[i]["YQ03"].ToString( );
                    model.AM176 = model.AM179 = model.AM180 = model.AM187 = model.AM183 = model.AM186 = model.AM189 = model.AM190 = model.AM192 = model.AM195 = model.AM198 = model.AM193 =model.AM199=model.AM201=model.AM204=model.AM206=model.AM208= 0;
                    model.AM176 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"YQ03='" + model.AM002 + "' AND YQ101='外购' AND YQ12='水性漆一类' AND YQ123='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"YQ03='" + model.AM002 + "' AND YQ101='外购' AND YQ12='水性漆一类' AND YQ123='F' " ) );
                    model.AM180 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"YQ03='" + model.AM002 + "' AND YQ101='外购' AND YQ12='水性漆一类' AND YQ123='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"YQ03='" + model.AM002 + "' AND YQ101='外购' AND YQ12='水性漆一类' AND YQ123='T' " ) );
                    model.AM189 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"YQ03='" + model.AM002 + "' AND YQ101='库存' AND YQ12='水性漆一类' AND YQ123='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"YQ03='" + model.AM002 + "' AND YQ101='库存' AND YQ12='水性漆一类' AND YQ123='F' " ) );
                    model.AM201 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"YQ03='" + model.AM002 + "' AND YQ101='库存' AND YQ12='水性漆一类' AND YQ123='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"YQ03='" + model.AM002 + "' AND YQ101='库存' AND YQ12='水性漆一类' AND YQ123='T' " ) );
                    model.AM179 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"YQ03='" + model.AM002 + "' AND YQ101='外购' AND YQ12='水性漆二类' AND YQ123='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"YQ03='" + model.AM002 + "' AND YQ101='外购' AND YQ12='水性漆二类' AND YQ123='F' " ) );
                    model.AM187 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"YQ03='" + model.AM002 + "' AND YQ101='外购' AND YQ12='水性漆二类' AND YQ123='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"YQ03='" + model.AM002 + "' AND YQ101='外购' AND YQ12='水性漆二类' AND YQ123='T' " ) );
                    model.AM192 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"YQ03='" + model.AM002 + "' AND YQ101='库存' AND YQ12='水性漆二类' AND YQ123='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"YQ03='" + model.AM002 + "' AND YQ101='库存' AND YQ12='水性漆二类' AND YQ123='F' " ) );
                    model.AM204 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"YQ03='" + model.AM002 + "' AND YQ101='库存' AND YQ12='水性漆二类' AND YQ123='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"YQ03='" + model.AM002 + "' AND YQ101='库存' AND YQ12='水性漆二类' AND YQ123='T' " ) );
                    model.AM183 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"YQ03='" + model.AM002 + "' AND YQ101='外购' AND YQ12='硝基漆' AND YQ123='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"YQ03='" + model.AM002 + "' AND YQ101='外购' AND YQ12='硝基漆' AND YQ123='F' " ) );
                    model.AM190 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"YQ03='" + model.AM002 + "' AND YQ101='外购' AND YQ12='硝基漆' AND YQ123='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"YQ03='" + model.AM002 + "' AND YQ101='外购' AND YQ12='硝基漆' AND YQ123='T' " ) );
                    model.AM195 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"YQ03='" + model.AM002 + "' AND YQ101='库存' AND YQ12='硝基漆' AND YQ123='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"YQ03='" + model.AM002 + "' AND YQ101='库存' AND YQ12='硝基漆' AND YQ123='F' " ) );
                    model.AM206 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"YQ03='" + model.AM002 + "' AND YQ101='库存' AND YQ12='硝基漆' AND YQ123='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"YQ03='" + model.AM002 + "' AND YQ101='库存' AND YQ12='硝基漆' AND YQ123='T' " ) );
                    model.AM186 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"YQ03='" + model.AM002 + "' AND YQ101='外购' AND YQ12='香蕉水' AND YQ123='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"YQ03='" + model.AM002 + "' AND YQ101='外购' AND YQ12='香蕉水' AND YQ123='F' " ) );
                    model.AM199 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"YQ03='" + model.AM002 + "' AND YQ101='外购' AND YQ12='香蕉水' AND YQ123='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"YQ03='" + model.AM002 + "' AND YQ101='外购' AND YQ12='香蕉水' AND YQ123='T' " ) );
                    model.AM198 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"YQ03='" + model.AM002 + "' AND YQ101='库存' AND YQ12='香蕉水' AND YQ123='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"YQ03='" + model.AM002 + "' AND YQ101='库存' AND YQ12='香蕉水' AND YQ123='F' " ) );
                    model.AM208 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"YQ03='" + model.AM002 + "' AND YQ101='库存' AND YQ12='香蕉水' AND YQ123='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"YQ03='" + model.AM002 + "' AND YQ101='库存' AND YQ12='香蕉水' AND YQ123='T' " ) );
                    if ( i == 0 && ExistsOfCount( model.AM002 ) )
                    {
                        ofForDelete( model );
                        PaintDelete( model ,SQLString );
                    }
                    else if ( i > 0 && model.AM002 != dk.Rows[i - 1]["YQ03"].ToString( ) )
                    {
                        ofForDelete( model );
                        PaintDelete( model ,SQLString );
                    }
                }
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        void ofForDelete ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            DataTable da = GetDataTableOfFor( model.AM002 );
            if ( da != null && da.Rows.Count > 0 )
            {
                model.AM176 = string.IsNullOrEmpty( da.Rows[0]["AM176"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM176"].ToString( ) ) - model.AM176;
                model.AM179 = string.IsNullOrEmpty( da.Rows[0]["AM179"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM179"].ToString( ) ) - model.AM179;
                model.AM180 = string.IsNullOrEmpty( da.Rows[0]["AM180"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM180"].ToString( ) ) - model.AM180;
                model.AM183 = string.IsNullOrEmpty( da.Rows[0]["AM183"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM183"].ToString( ) ) - model.AM183;
                model.AM186 = string.IsNullOrEmpty( da.Rows[0]["AM186"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM186"].ToString( ) ) - model.AM186;
                model.AM187 = string.IsNullOrEmpty( da.Rows[0]["AM187"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM187"].ToString( ) ) - model.AM187;
                model.AM189 = string.IsNullOrEmpty( da.Rows[0]["AM189"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM189"].ToString( ) ) - model.AM189;
                model.AM192 = string.IsNullOrEmpty( da.Rows[0]["AM192"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM192"].ToString( ) ) - model.AM192;
                model.AM193 = string.IsNullOrEmpty( da.Rows[0]["AM193"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM193"].ToString( ) ) - model.AM193;
                model.AM195 = string.IsNullOrEmpty( da.Rows[0]["AM195"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM195"].ToString( ) ) - model.AM195;
                model.AM198 = string.IsNullOrEmpty( da.Rows[0]["AM198"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM198"].ToString( ) ) - model.AM198;
                model.AM199 = string.IsNullOrEmpty( da.Rows[0]["AM199"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM199"].ToString( ) ) - model.AM199;
                model.AM201 = string.IsNullOrEmpty( da.Rows[0]["AM201"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM201"].ToString( ) ) - model.AM201;
                model.AM204 = string.IsNullOrEmpty( da.Rows[0]["AM204"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM204"].ToString( ) ) - model.AM204;
                model.AM206 = string.IsNullOrEmpty( da.Rows[0]["AM206"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM206"].ToString( ) ) - model.AM206;
                model.AM208 = string.IsNullOrEmpty( da.Rows[0]["AM208"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM208"].ToString( ) ) - model.AM208;
            }
        }
        public void PaintDelete ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            strSql.AppendFormat( "AM176='{0}'," ,model.AM176 );
            strSql.AppendFormat( "AM179='{0}'," ,model.AM179 );
            strSql.AppendFormat( "AM180='{0}'," ,model.AM180 );
            strSql.AppendFormat( "AM183='{0}'," ,model.AM183 );
            strSql.AppendFormat( "AM186='{0}'," ,model.AM186 );
            strSql.AppendFormat( "AM187='{0}'," ,model.AM187 );
            strSql.AppendFormat( "AM189='{0}'," ,model.AM189 );
            strSql.AppendFormat( "AM190='{0}'," ,model.AM190 );
            strSql.AppendFormat( "AM192='{0}'," ,model.AM192 );
            strSql.AppendFormat( "AM195='{0}'," ,model.AM195 );
            strSql.AppendFormat( "AM198='{0}'," ,model.AM198 );
            strSql.AppendFormat( "AM199='{0}'," ,model.AM199 );
            strSql.AppendFormat( "AM201='{0}'," ,model.AM201 );
            strSql.AppendFormat( "AM204='{0}'," ,model.AM204 );
            strSql.AppendFormat( "AM206='{0}'," ,model.AM206 );
            strSql.AppendFormat( "AM208='{0}'" ,model.AM208 );
            strSql.AppendFormat( " WHERE AM002='{0}'" ,model.AM002 );
            SQLString.Add( strSql.ToString( ) );
        }

        /// <summary>
        /// 341
        /// </summary>
        /// <param name="idxList"></param>
        /// <param name="numList"></param>
        /// <param name="model"></param>
        /// <param name="dk"></param>
        /// <param name="SQLString"></param>
        /// <returns></returns>
        public bool PqvDelete ( string idxList ,string numList ,MulaolaoLibrary.ProductCostSummaryLibrary model ,DataTable dk ,ArrayList SQLString )
        {
            dk = GetDataTablePqv( numList ,idxList );
            if ( dk != null && dk.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < dk.Rows.Count ; i++ )
                {
                    model.AM002 = dk.Rows[i]["PQV01"].ToString( );
                    model . AM262 = model . AM264 = model . AM266 = model . AM268 = model . AM269 = model . AM289 = model . AM291 = model . AM293 = model . AM295 = model . AM331 = model . AM334 = model . AM335 = model . AM337 = model . AM340 = model . AM341 = model . AM344 = model . AM347 = model . AM348 = model . AM350 = model . AM353 = model . AM354 = model . AM356 = model . AM359 = model . AM360 = model . AM362 = model . AM365 = model . AM366 = model . AM368 = model . AM371 = model . AM372 = model . AM374 = model . AM377 = model . AM378 = model . AM380 = model . AM383 = model . AM386 = model . AM387 = model . AM389 = model . AM392 = model . AM393 = model . AM154 = model . AM156 = 0;

                    model . AM154 = string . IsNullOrEmpty ( dk . Compute ( "sum(AK)" ,"PQV01='" + model . AM002 + "' and PQV92= 'F' and PQV86='杨木' AND PQV65='外购' AND PQV88='F'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dk . Compute ( "sum(AK)" ,"PQV01='" + model . AM002 + "' and PQV92= 'F' and PQV86='杨木' AND PQV65='外购' AND PQV88='F'" ) );
                    model . AM156 = string . IsNullOrEmpty ( dk . Compute ( "sum(AK)" ,"PQV01='" + model . AM002 + "' and PQV92= 'F' and PQV86='杨木' AND PQV65='外购' AND PQV88='T'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dk . Compute ( "sum(AK)" ,"PQV01='" + model . AM002 + "' and PQV92= 'F' and PQV86='杨木' AND PQV65='外购' AND PQV88='T'" ) );

                    model .AM340 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='新西兰松' AND PQV88='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='新西兰松' AND PQV88='F' " ) );
                    model.AM348 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='新西兰松' AND PQV88='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='新西兰松' AND PQV88='T' " ) );

                    model.AM365 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='榉木' AND PQV88='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='榉木' AND PQV88='F' " ) );
                    model.AM393 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='榉木' AND PQV88='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'T' and PQV86='榉木' AND PQV88='T' " ) );

                    model.AM337 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='外购' AND PQV88='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='外购' AND PQV88='F' " ) );
                    model.AM341 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='外购' AND PQV88='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='外购' AND PQV88='T' " ) );

                    model.AM359 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='库存' AND PQV88='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='库存' AND PQV88='F' " ) );
                    model.AM378 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='库存' AND PQV88='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='库存' AND PQV88='T' " ) );

                    model.AM344 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV88='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV88='F' " ) );
                    model.AM354 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购'  AND PQV88='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV88='T' " ) );

                    //model.AM362 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV88='F'" ) );
                    //model.AM387 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV88='T'" ) );

                    model.AM374 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存'  AND PQV88='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV88='F' " ) );
                    model.AM269 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV88='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV88='T' " ) );

                    //model.AM377 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV88='F'" ) );
                    //model.AM268 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV88='T'" ) );

                    model.AM347 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='外购' AND PQV88='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='外购' AND PQV88='F' " ) );
                    model.AM360 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='外购' AND PQV88='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='外购' AND PQV88='T' " ) );

                    model.AM380 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='库存' AND PQV88='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='库存' AND PQV88='F' " ) );
                    model.AM266 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='库存' AND PQV88='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='库存' AND PQV88='T' " ) );

                    model.AM350 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND PQV88='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND PQV88='F' " ) );
                    model.AM366 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND  PQV88='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND  PQV88='T' " ) );

                    //model.AM368 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND  PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND PQV88='F'" ) );
                    //model.AM295 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND  PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND PQV88='T'" ) );

                    model.AM386 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND  PQV88='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV88='F' " ) );
                    model.AM383 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND  PQV88='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV88='T' " ) );

                    //model.AM389 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND  PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV88='F'" ) );
                    //model.AM264 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND  PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV88='T'" ) );

                    model.AM353 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND  PQV88='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND  PQV88='F' " ) );
                    model.AM372 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND  PQV88='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND PQV88='T' " ) );

                    //model.AM371 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND  PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND PQV88='F'" ) );
                    //model.AM293 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND  PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND PQV88='T'" ) );

                    model.AM392 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV88='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV88='F' " ) );
                    model.AM262 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND  PQV88='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV88='T' " ) );

                    //model.AM334 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND  PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV88='F'" ) );
                    //model.AM289 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND  PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV88='T'" ) );
                    
                    model.AM356 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='杂木' AND PQV65='外购' AND PQV88='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='杂木' AND PQV65='外购' AND PQV88='F' " ) );
                    model.AM335 = string.IsNullOrEmpty( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='杂木' AND PQV65='外购' AND PQV88='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(AK)" ,"PQV01='" + model.AM002 + "' and PQV92= 'F' and PQV86='杂木' AND PQV65='外购' AND PQV88='T' " ) );
                    if ( i == 0 && ExistsOfCount( model.AM002 ) )
                    {
                        ofFivDelete( model );
                        WoodDelete( model ,SQLString );
                    }
                    else if ( i > 0 && model.AM002 != dk.Rows[i - 1]["PQV01"].ToString( ) )
                    {
                        ofFivDelete( model );
                        WoodDelete( model ,SQLString );
                    }
                }
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        void ofFivDelete ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            DataTable da = GetDataTableOfFiv( model.AM002 );
            if ( da != null && da.Rows.Count > 0 )
            {
                model . AM154 = string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM154" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM154" ] . ToString ( ) ) - model . AM154;
                model . AM156 = string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AM156" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AM156" ] . ToString ( ) ) - model . AM156;
                model .AM262 = string.IsNullOrEmpty( da.Rows[0]["AM262"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM262"].ToString( ) ) - model.AM262;
                model.AM264 = string.IsNullOrEmpty( da.Rows[0]["AM264"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM264"].ToString( ) ) - model.AM264;
                model.AM266 = string.IsNullOrEmpty( da.Rows[0]["AM266"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM266"].ToString( ) ) - model.AM266;
                model.AM268 = string.IsNullOrEmpty( da.Rows[0]["AM268"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM268"].ToString( ) ) - model.AM268;
                model.AM269 = string.IsNullOrEmpty( da.Rows[0]["AM269"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM269"].ToString( ) ) - model.AM269;
                model.AM289 = string.IsNullOrEmpty( da.Rows[0]["AM289"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM289"].ToString( ) ) - model.AM289;
                model.AM291 = string.IsNullOrEmpty( da.Rows[0]["AM291"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM291"].ToString( ) ) - model.AM291;
                model.AM293 = string.IsNullOrEmpty( da.Rows[0]["AM293"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM293"].ToString( ) ) - model.AM293;
                model.AM295 = string.IsNullOrEmpty( da.Rows[0]["AM295"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM295"].ToString( ) ) - model.AM295;
                model.AM331 = string.IsNullOrEmpty( da.Rows[0]["AM331"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM331"].ToString( ) ) - model.AM331;
                model.AM334 = string.IsNullOrEmpty( da.Rows[0]["AM334"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM334"].ToString( ) ) - model.AM334;
                model.AM335 = string.IsNullOrEmpty( da.Rows[0]["AM335"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM335"].ToString( ) ) - model.AM335;
                model.AM337 = string.IsNullOrEmpty( da.Rows[0]["AM337"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM337"].ToString( ) ) - model.AM337;
                model.AM340 = string.IsNullOrEmpty( da.Rows[0]["AM340"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM340"].ToString( ) ) - model.AM340;
                model.AM341 = string.IsNullOrEmpty( da.Rows[0]["AM341"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM341"].ToString( ) ) - model.AM341;
                model.AM344 = string.IsNullOrEmpty( da.Rows[0]["AM344"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM344"].ToString( ) ) - model.AM344;
                model.AM347 = string.IsNullOrEmpty( da.Rows[0]["AM347"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM347"].ToString( ) ) - model.AM347;
                model.AM348 = string.IsNullOrEmpty( da.Rows[0]["AM348"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM348"].ToString( ) ) - model.AM348;
                model.AM350 = string.IsNullOrEmpty( da.Rows[0]["AM350"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM350"].ToString( ) ) - model.AM350;
                model.AM353 = string.IsNullOrEmpty( da.Rows[0]["AM353"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM353"].ToString( ) ) - model.AM353;
                model.AM354 = string.IsNullOrEmpty( da.Rows[0]["AM354"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM354"].ToString( ) ) - model.AM354;
                model.AM356 = string.IsNullOrEmpty( da.Rows[0]["AM356"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM356"].ToString( ) ) - model.AM356;
                model.AM359 = string.IsNullOrEmpty( da.Rows[0]["AM359"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM359"].ToString( ) ) - model.AM359;
                model.AM360 = string.IsNullOrEmpty( da.Rows[0]["AM360"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM360"].ToString( ) ) - model.AM360;
                model.AM362 = string.IsNullOrEmpty( da.Rows[0]["AM362"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM362"].ToString( ) ) - model.AM362;
                model.AM365 = string.IsNullOrEmpty( da.Rows[0]["AM365"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM365"].ToString( ) ) - model.AM365;
                model.AM366 = string.IsNullOrEmpty( da.Rows[0]["AM366"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM366"].ToString( ) ) - model.AM366;
                model.AM368 = string.IsNullOrEmpty( da.Rows[0]["AM368"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM368"].ToString( ) ) - model.AM368;
                model.AM371 = string.IsNullOrEmpty( da.Rows[0]["AM371"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM371"].ToString( ) ) - model.AM371;
                model.AM372 = string.IsNullOrEmpty( da.Rows[0]["AM372"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM372"].ToString( ) ) - model.AM372;
                model.AM374 = string.IsNullOrEmpty( da.Rows[0]["AM374"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM374"].ToString( ) ) - model.AM374;
                model.AM377 = string.IsNullOrEmpty( da.Rows[0]["AM377"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM377"].ToString( ) ) - model.AM377;
                model.AM378 = string.IsNullOrEmpty( da.Rows[0]["AM378"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM378"].ToString( ) ) - model.AM378;
                model.AM380 = string.IsNullOrEmpty( da.Rows[0]["AM380"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM380"].ToString( ) ) - model.AM380;
                model.AM383 = string.IsNullOrEmpty( da.Rows[0]["AM383"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM383"].ToString( ) ) - model.AM383;
                model.AM386 = string.IsNullOrEmpty( da.Rows[0]["AM386"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM386"].ToString( ) ) - model.AM386;
                model.AM387 = string.IsNullOrEmpty( da.Rows[0]["AM387"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM387"].ToString( ) ) - model.AM387;
                model.AM389 = string.IsNullOrEmpty( da.Rows[0]["AM389"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM389"].ToString( ) ) - model.AM389;
                model.AM392 = string.IsNullOrEmpty( da.Rows[0]["AM392"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM392"].ToString( ) ) - model.AM392;
                model.AM393 = string.IsNullOrEmpty( da.Rows[0]["AM393"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM393"].ToString( ) ) - model.AM393;
            }
        }
        public void WoodDelete ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            strSql . AppendFormat ( "AM154='{0}'," ,model . AM154 );
            strSql . AppendFormat ( "AM156='{0}'," ,model . AM156 );
            strSql .AppendFormat( "AM262='{0}'," ,model.AM262 );
            strSql.AppendFormat( "AM264='{0}'," ,model.AM264 );
            strSql.AppendFormat( "AM266='{0}'," ,model.AM266 );
            strSql.AppendFormat( "AM268='{0}'," ,model.AM268 );
            strSql.AppendFormat( "AM269='{0}'," ,model.AM269 );
            strSql.AppendFormat( "AM289='{0}'," ,model.AM289 );
            strSql.AppendFormat( "AM291='{0}'," ,model.AM291 );
            strSql.AppendFormat( "AM293='{0}'," ,model.AM293 );
            strSql.AppendFormat( "AM295='{0}'," ,model.AM295 );
            strSql.AppendFormat( "AM331='{0}'," ,model.AM331 );
            strSql.AppendFormat( "AM334='{0}'," ,model.AM334 );
            strSql.AppendFormat( "AM335='{0}'," ,model.AM335 );
            strSql.AppendFormat( "AM337='{0}'," ,model.AM337 );
            strSql.AppendFormat( "AM340='{0}'," ,model.AM340 );
            strSql.AppendFormat( "AM341='{0}'," ,model.AM341 );
            strSql.AppendFormat( "AM344='{0}'," ,model.AM344 );
            strSql.AppendFormat( "AM347='{0}'," ,model.AM347 );
            strSql.AppendFormat( "AM348='{0}'," ,model.AM348 );
            strSql.AppendFormat( "AM350='{0}'," ,model.AM350 );
            strSql.AppendFormat( "AM353='{0}'," ,model.AM353 );
            strSql.AppendFormat( "AM354='{0}'," ,model.AM354 );
            strSql.AppendFormat( "AM356='{0}'," ,model.AM356 );
            strSql.AppendFormat( "AM359='{0}'," ,model.AM359 );
            strSql.AppendFormat( "AM360='{0}'," ,model.AM360 );
            strSql.AppendFormat( "AM362='{0}'," ,model.AM362 );
            strSql.AppendFormat( "AM365='{0}'," ,model.AM365 );
            strSql.AppendFormat( "AM366='{0}'," ,model.AM366 );
            strSql.AppendFormat( "AM368='{0}'," ,model.AM368 );
            strSql.AppendFormat( "AM371='{0}'," ,model.AM371 );
            strSql.AppendFormat( "AM372='{0}'," ,model.AM372 );
            strSql.AppendFormat( "AM374='{0}'," ,model.AM374 );
            strSql.AppendFormat( "AM377='{0}'," ,model.AM377 );
            strSql.AppendFormat( "AM378='{0}'," ,model.AM378 );
            strSql.AppendFormat( "AM380='{0}'," ,model.AM380 );
            strSql.AppendFormat( "AM383='{0}'," ,model.AM383 );
            strSql.AppendFormat( "AM386='{0}'," ,model.AM386 );
            strSql.AppendFormat( "AM387='{0}'," ,model.AM387 );
            strSql.AppendFormat( "AM389='{0}'," ,model.AM389 );
            strSql.AppendFormat( "AM392='{0}'," ,model.AM392 );
            strSql.AppendFormat( "AM393='{0}'" ,model.AM393 );
            strSql.AppendFormat( " WHERE AM002='{0}'" ,model.AM002 );
            SQLString.Add( strSql.ToString( ) );
        }

        /// <summary>
        /// 342
        /// </summary>
        /// <param name="idxList"></param>
        /// <param name="numList"></param>
        /// <param name="model"></param>
        /// <param name="dk"></param>
        /// <param name="SQLString"></param>
        /// <returns></returns>
        public bool PqafDelete ( string idxList ,string numList ,MulaolaoLibrary.ProductCostSummaryLibrary model ,DataTable dk ,ArrayList SQLString )
        {
            dk = GetDataTablePqaf( numList ,idxList );
            if ( dk != null && dk.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < dk.Rows.Count ; i++ )
                {
                    model.AM002 = dk.Rows[i]["AF002"].ToString( );
                    model.AM271 = model.AM274 = model.AM278 = model.AM281 = model.AM275 = model.AM282 = model.AM284 =model.AM286= 0;
                    model.AM271 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"AF002='" + model.AM002 + "' AND AF016='外购' AND AF078='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"AF002='" + model.AM002 + "' AND AF016='外购' AND AF078='F' " ) );
                    model.AM275 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"AF002='" + model.AM002 + "' AND AF016='外购'  AND AF078='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"AF002='" + model.AM002 + "' AND AF016='外购' AND AF078='T' " ) );
                    //model.AM274 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"AF002='" + model.AM002 + "' AND AF016='外购' AND AF078='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"AF002='" + model.AM002 + "' AND AF016='外购' AND AF078='F'" ) );
                    //model.AM282 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"AF002='" + model.AM002 + "' AND AF016='外购'  AND AF078='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"AF002='" + model.AM002 + "' AND AF016='外购'  AND AF078='T'" ) );
                    model.AM278 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"AF002='" + model.AM002 + "' AND AF016='库存' AND AF078='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"AF002='" + model.AM002 + "' AND AF016='库存'  AND AF078='F' " ) );
                    model.AM284 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"AF002='" + model.AM002 + "' AND AF016='库存'  AND AF078='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"AF002='" + model.AM002 + "' AND AF016='库存' AND AF078='T' " ) );
                    //model.AM281 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"AF002='" + model.AM002 + "' AND AF016='库存' AND AF078='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"AF002='" + model.AM002 + "' AND AF016='库存' AND AF078='F'" ) );
                    //model.AM286 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"AF002='" + model.AM002 + "' AND AF016='库存' AND AF078='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"AF002='" + model.AM002 + "' AND AF016='库存' AND AF078='T'" ) );

                    if ( i == 0 && ExistsOfCount( model.AM002 ) )
                    {
                        ofSixDelete( model );
                        VehicleWoodPiecesDelete( model ,SQLString );
                    }
                    else if ( i > 0 && model.AM002 != dk.Rows[i - 1]["AF002"].ToString( ) )
                    {
                        ofSixDelete( model );
                        VehicleWoodPiecesDelete( model ,SQLString );
                    }
                }      
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        void ofSixDelete ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            DataTable da = GetDataTableOfSix( model.AM002 );
            if ( da != null && da.Rows.Count > 0 )
            {
                model.AM271 = string.IsNullOrEmpty( da.Rows[0]["AM271"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM271"].ToString( ) ) - model.AM271;
                //model.AM274 = string.IsNullOrEmpty( da.Rows[0]["AM274"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM274"].ToString( ) ) - model.AM274;
                model.AM275 = string.IsNullOrEmpty( da.Rows[0]["AM275"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM275"].ToString( ) ) - model.AM275;
                model.AM278 = string.IsNullOrEmpty( da.Rows[0]["AM278"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM278"].ToString( ) ) - model.AM278;
                //model.AM281 = string.IsNullOrEmpty( da.Rows[0]["AM281"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM281"].ToString( ) ) - model.AM281;
                //model.AM282 = string.IsNullOrEmpty( da.Rows[0]["AM282"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM282"].ToString( ) ) - model.AM282;
                model.AM284 = string.IsNullOrEmpty( da.Rows[0]["AM284"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM284"].ToString( ) ) - model.AM284;
                //model.AM286 = string.IsNullOrEmpty( da.Rows[0]["AM286"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM286"].ToString( ) ) - model.AM286;
            }
        }
        public void VehicleWoodPiecesDelete ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            strSql.AppendFormat( "AM271='{0}'," ,model.AM271 );
            //strSql.AppendFormat( "AM274='{0}'," ,model.AM274 );
            strSql.AppendFormat( "AM275='{0}'," ,model.AM275 );
            strSql.AppendFormat( "AM278='{0}'," ,model.AM278 );
            //strSql.AppendFormat( "AM281='{0}'," ,model.AM281 );
            //strSql.AppendFormat( "AM282='{0}'," ,model.AM282 );
            strSql.AppendFormat( "AM284='{0}' " ,model.AM284 );
            //strSql.AppendFormat( "AM286='{0}'" ,model.AM286 );
            strSql.AppendFormat( " WHERE AM002='{0}'" ,model.AM002 );
            SQLString.Add( strSql.ToString( ) );
        }

        /// <summary>
        /// 343
        /// </summary>
        /// <param name="idxList"></param>
        /// <param name="numList"></param>
        /// <param name="model"></param>
        /// <param name="dk"></param>
        /// <param name="SQLString"></param>
        /// <returns></returns>
        public bool PquDelete ( string idxList ,string numList ,MulaolaoLibrary.ProductCostSummaryLibrary model ,DataTable dk ,ArrayList SQLString )
        {
            dk = GetDataTablePqu( numList ,idxList );
            if ( dk != null && dk.Rows.Count > 0 )
            {
                for ( int m = 0 ; m < dk.Rows.Count ; m++ )
                {
                    model.AM002 = dk.Rows[m]["PQU01"].ToString( );
                    model.AM210 =model.AM214= 0;
                    model.AM210 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"PQU01='" + model.AM002 + "' AND PQU107='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"PQU01='" + model.AM002 + "' AND PQU107='F' " ) );
                    model.AM214 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"PQU01='" + model.AM002 + "' AND PQU107='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"PQU01='" + model.AM002 + "' AND PQU107='T' " ) );
                    if ( m == 0 && ExistsOfCount( model.AM002 ) )
                    {
                        ofSevDelete( model );
                        LronDelete( model ,SQLString );
                    }
                    else if ( m > 0 && model.AM002 != dk.Rows[m - 1]["PQU01"].ToString( ) )
                    {
                        ofSevDelete( model );
                        LronDelete( model ,SQLString );
                    }
                }
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        void ofSevDelete ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            DataTable da = GetDataTableOfSev( model.AM002 );
            if ( da != null && da.Rows.Count > 0 )
            {
                model.AM210 = string.IsNullOrEmpty( da.Rows[0]["AM210"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM210"].ToString( ) ) - model.AM210;
                model.AM214 = string.IsNullOrEmpty( da.Rows[0]["AM214"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM214"].ToString( ) ) - model.AM214;
            }
        }
        public void LronDelete ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            strSql.AppendFormat( "AM210='{0}'," ,model.AM210 );
            strSql.AppendFormat( "AM214='{0}'" ,model.AM214 );
            strSql.AppendFormat( " WHERE AM002='{0}'" ,model.AM002 );
            SQLString.Add( strSql.ToString( ) );
        }

        /// <summary>
        /// 344漆款
        /// </summary>
        /// <param name="model"></param>
        /// <param name="SQLString"></param>        
        public bool PqlzDelete ( string idxList ,string numList ,MulaolaoLibrary.ProductCostSummaryLibrary model ,DataTable dk ,ArrayList SQLString )
        {
            dk = GetDataTablePqlz( numList ,idxList );
            if ( dk != null && dk.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < dk.Rows.Count ; i++ )
                {
                    model.AM002 = dk.Rows[i]["MZ002"].ToString( );
                     model.AM243 = model.AM246  = model.AM051 = model.AM053 = 0M;
                   
                
                    model.AM243 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"MZ002='" + model.AM002 + "' AND MZ123='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"MZ002='" + model.AM002 + "' AND MZ123='F' " ) );
                    model.AM251 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"MZ002='" + model.AM002 + "' AND MZ123='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"MZ002='" + model.AM002 + "' AND MZ123='T' " ) );
                    if ( i == 0 && ExistsOfCount( model.AM002 ) )
                    {
                        ofEgiDelete( model );
                        GunPaintDelete( model ,SQLString );
                    }
                    else if ( i > 0 && model.AM002 != dk.Rows[i - 1]["MZ002"].ToString( ) )
                    {
                        ofEgiDelete( model );
                        GunPaintDelete( model ,SQLString );
                    }
                }                        
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        void ofEgiDelete ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            DataTable da = GetDataTableOfEgi( model.AM002 );
            if ( da != null && da.Rows.Count > 0 )
            {
                model.AM243 = string.IsNullOrEmpty( da.Rows[0]["AM243"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM243"].ToString( ) ) - model.AM243;
                model.AM246 = string.IsNullOrEmpty( da.Rows[0]["AM246"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM246"].ToString( ) ) - model.AM246;
                model.AM251 = string.IsNullOrEmpty( da.Rows[0]["AM251"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM251"].ToString( ) ) - model.AM251;
                model.AM253 = string.IsNullOrEmpty( da.Rows[0]["AM253"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM253"].ToString( ) ) - model.AM253;
            }
        }
        public void GunPaintDelete ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            strSql.AppendFormat( "AM243='{0}'," ,model.AM243 );
            strSql.AppendFormat( "AM246='{0}'," ,model.AM246 );
            strSql.AppendFormat( "AM251='{0}'," ,model.AM251 );
            strSql.AppendFormat( "AM253='{0}'" ,model.AM253 );
            strSql.AppendFormat( " WHERE AM002='{0}'" ,model.AM002 );
            SQLString.Add( strSql.ToString( ) );
        }

        /// <summary>
        /// 344  工资
        /// </summary>
        /// <param name="model"></param>
        /// <param name="SQLString"></param>     
        public bool PqmzDelete ( string idxList ,string numList ,MulaolaoLibrary.ProductCostSummaryLibrary model ,DataTable dk ,ArrayList SQLString )
        {
            dk = GetDataTablePqmz( numList ,idxList );
            if ( dk != null && dk.Rows.Count > 0 )
            {
                for ( int m = 0 ; m < dk.Rows.Count ; m++ )
                {
                    model.AM002 = dk.Rows[m]["MZ002"].ToString( );
                    model.AM250 = 0M;//AND (AK017='执行' AND AK017='审核')
                    model .AM250 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"MZ002='" + model.AM002 + "' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"MZ002='" + model.AM002 + "' " ) );
                    if ( m == 0 && ExistsOfCount( model.AM002 ) )
                    {
                        ofNinDelete( model );
                        GunPaintOtherDelete( model ,SQLString );
                    }
                    else if ( m > 0 && model.AM002 != dk.Rows[m - 1]["MZ002"].ToString( ) )
                    {
                        ofNinDelete( model );
                        GunPaintOtherDelete( model ,SQLString );
                    }
                }
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        void ofNinDelete ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            DataTable da = GetDataTableOfNin( model.AM002 );
            if ( da != null && da.Rows.Count > 0 )
            {
                model.AM250 = string.IsNullOrEmpty( da.Rows[0]["AM250"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM250"].ToString( ) ) - model.AM250;
            }
        }
        public void GunPaintOtherDelete ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            strSql.AppendFormat( "AM250='{0}'" ,model.AM250 );
            strSql.AppendFormat( " WHERE AM002='{0}'" ,model.AM002 );
            SQLString.Add( strSql.ToString( ) );
        }

        /// <summary>
        /// 347
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>      
        public bool PqsDelete ( string idxList ,string numList ,MulaolaoLibrary.ProductCostSummaryLibrary model ,DataTable dk ,ArrayList SQLString )
        {
            dk = GetDataTablePqsTwo( numList ,idxList );
            if ( dk != null && dk.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < dk.Rows.Count ; i++ )
                {
                    model.AM002 = dk.Rows[i]["PJ01"].ToString( );
                    model.AM213 = model.AM216 = model.AM219 =model.AM220=model.AM222=model.AM224= 0M;
                    model.AM219 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"PJ01='" + model.AM002 + "' AND PJ105='包装辅料' AND PJ100='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"PJ01='" + model.AM002 + "' AND PJ105='包装辅料' AND PJ100='F' " ) );
                    model.AM224 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"PJ01='" + model.AM002 + "' AND PJ105='包装辅料' AND PJ100='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"PJ01='" + model.AM002 + "' AND PJ105='包装辅料' AND PJ100='T' " ) );
                    model.AM216 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"PJ01='" + model.AM002 + "' AND PJ105='其它材料' AND PJ100='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"PJ01='" + model.AM002 + "' AND PJ105='其它材料' AND PJ100='F' " ) );
                    model.AM222= string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"PJ01='" + model.AM002 + "' AND PJ105='其它材料' AND PJ100='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"PJ01='" + model.AM002 + "' AND PJ105='其它材料' AND PJ100='T' " ) );
                    model.AM213 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"PJ01='" + model.AM002 + "' AND PJ105='塑料件' AND PJ100='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"PJ01='" + model.AM002 + "' AND PJ105='塑料件' AND PJ100='F' " ) );
                    model.AM220 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"PJ01='" + model.AM002 + "' AND PJ105='塑料件' AND PJ100='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"PJ01='" + model.AM002 + "' AND PJ105='塑料件' AND PJ100='T' " ) );

                    if ( i == 0 && ExistsOfCount( model.AM002 ) )
                    {
                        ofTenDelete( model );
                        LronOtherDelete( model ,SQLString );
                    }
                    else if ( i > 0 && model.AM002 != dk.Rows[i - 1]["PJ01"].ToString( ) )
                    {
                        ofTenDelete( model );
                        LronOtherDelete( model ,SQLString );
                    }
                }      
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        void ofTenDelete ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            DataTable da = GetDataTableOfTen( model.AM002 );
            if ( da != null && da.Rows.Count > 0 )
            {
                model.AM213 = string.IsNullOrEmpty( da.Rows[0]["AM213"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM213"].ToString( ) ) - model.AM213;
                model.AM216 = string.IsNullOrEmpty( da.Rows[0]["AM216"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM216"].ToString( ) ) - model.AM216;
                model.AM219 = string.IsNullOrEmpty( da.Rows[0]["AM219"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM219"].ToString( ) ) - model.AM219;
                model.AM220 = string.IsNullOrEmpty( da.Rows[0]["AM220"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM220"].ToString( ) ) - model.AM220;
                model.AM222 = string.IsNullOrEmpty( da.Rows[0]["AM222"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM222"].ToString( ) ) - model.AM222;
                model.AM224 = string.IsNullOrEmpty( da.Rows[0]["AM224"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM224"].ToString( ) ) - model.AM224;
            }
        }
        public void LronOtherDelete ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            strSql.AppendFormat( "AM213='{0}'," ,model.AM213 );
            strSql.AppendFormat( "AM216='{0}'," ,model.AM216 );
            strSql.AppendFormat( "AM219='{0}'," ,model.AM219 );
            strSql.AppendFormat( "AM220='{0}'," ,model.AM220 );
            strSql.AppendFormat( "AM222='{0}'," ,model.AM222 );
            strSql.AppendFormat( "AM224='{0}'" ,model.AM224 );
            strSql.AppendFormat( " WHERE AM002='{0}'" ,model.AM002 );
            SQLString.Add( strSql.ToString( ) );
        }

        /// <summary>
        /// 348
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>    
        public DataTable GetDataTablePqozs ( string numList ,string idxList )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "WITH CET AS (SELECT SUM(OZ) OZ,OZ011,COUN FROM (SELECT OZ005*OZ006 OZ,OZ011,COUNT(1) COUN FROM R_PQOZ GROUP BY OZ011,OZ005,OZ006) A GROUP BY OZ011,COUN)" );
            strSql.Append( "SELECT OZ001,WX90,SUM(OZ) OZ,CASE WHEN AK<SUM(OZ) THEN AK ELSE SUM(OZ) END AK,AK017 FROM (SELECT OZ001,CASE WHEN OZ=0 THEN 0 ELSE CONVERT(DECIMAL(18,0),SUM(OZ009)/OZ*OZ005*OZ006/COUN) END OZ,WX90,ISNULL(SUM(AK011),0) AK,AK017 FROM R_PQOZ TT LEFT JOIN TPADGA B ON TT.OZ014=B.DGA001 LEFT JOIN CET C ON TT.OZ011=C.OZ011 INNER JOIN R_REVIEWS D ON TT.OZ011=D.RES06 AND RES05='执行' LEFT JOIN R_PQT E ON TT.OZ015=E.WX82 LEFT JOIN R_PQAK F ON TT.OZ011=F.AK003 AND TT.OZ001=F.AK002" );
            strSql.Append( " WHERE TT.OZ001 IN (" + numList + ") AND F.idx IN (" + idxList + ")" );
            strSql.Append( " GROUP BY OZ001,TT.OZ011,OZ,OZ005,OZ006,WX90,COUN,AK017) A GROUP BY WX90,AK,OZ001,AK017" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public bool PqtDeletes ( string idxList ,string numList ,MulaolaoLibrary.ProductCostSummaryLibrary model ,DataTable dk ,ArrayList SQLString )
        {
            dk = GetDataTablePqozs( numList ,idxList );
            if ( dk != null && dk.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < dk.Rows.Count ; i++ )
                {
                    model.AM002 = dk.Rows[i]["OZ001"].ToString( );
                    model.AM140 = model.AM147 = 0M;
                    model.AM140 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"OZ001='" + model.AM002 + "' AND WX90='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"OZ001='" + model.AM002 + "' AND WX90='F'" ) );
                    model.AM147 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"OZ001='" + model.AM002 + "' AND WX90='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"OZ001='" + model.AM002 + "' AND WX90='T'" ) );

                    if ( i == 0 && ExistsOfCount( model.AM002 ) )
                    {
                        ofEleDeletes( model );
                        PackageMaterialDeletes( model ,SQLString );
                    }
                    else if ( i > 0 && model.AM002 != dk.Rows[i - 1]["OZ001"].ToString( ) )
                    {
                        ofEleDeletes( model );
                        PackageMaterialDeletes( model ,SQLString );
                    }
                }
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        void ofEleDeletes ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            DataTable da = GetDataTableOfEles( model.AM002 );
            if ( da != null && da.Rows.Count > 0 )
            {
                model.AM140 = string.IsNullOrEmpty( da.Rows[0]["AM140"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM140"].ToString( ) ) - model.AM140;
                model.AM147 = string.IsNullOrEmpty( da.Rows[0]["AM147"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM147"].ToString( ) ) - model.AM147;
            }
        }
        public void PackageMaterialDeletes ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            strSql.AppendFormat( "AM140='{0}'," ,model.AM140 );
            strSql.AppendFormat( "AM147='{0}'" ,model.AM147 );
            strSql.AppendFormat( " WHERE AM002='{0}'" ,model.AM002 );
            SQLString.Add( strSql.ToString( ) );
        }

        /// <summary>
        /// 349
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>       
        public bool PqtDelete ( string idxList ,string numList ,MulaolaoLibrary.ProductCostSummaryLibrary model ,DataTable dk ,ArrayList SQLString )
        {
            dk = GetDataTablePqt( numList ,idxList );
            if ( dk != null && dk.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < dk.Rows.Count ; i++ )
                {
                    model.AM002 = dk.Rows[i]["WX01"].ToString( );
                    model.AM137 = model.AM140 = model.AM143 = model.AM146 = model.AM149 = model.AM141 =model.AM134=model.AM147=model.AM135=model.AM131= 0M;
                    model.AM137 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' AND WX20='包装辅料' AND WX90='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' AND WX20='包装辅料' AND WX90='F' " ) );
                    model.AM141 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' AND WX20='包装辅料' AND WX90='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' AND WX20='包装辅料' AND WX90='T' " ) );
                    model.AM146 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' AND WX20='内盒' AND WX90='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' AND WX20='内盒' AND WX90='F' " ) );
                    model.AM134 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' AND WX20='内盒' AND WX90='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' AND WX20='内盒' AND WX90='T' " ) );
                    model.AM140 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' AND WX20='外箱' AND WX90='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' AND WX20='外箱' AND WX90='F' " ) );
                    model.AM147 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' AND WX20='外箱' AND WX90='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' AND WX20='外箱' AND WX90='T' " ) );
                    model.AM143 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' AND WX20='中包' AND WX90='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' AND WX20='中包' AND WX90='F' " ) );
                    model.AM135 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' AND WX20='中包' AND WX90='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' AND WX20='中包' AND WX90='T' " ) );
                    model.AM149 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' AND WX20='彩盒' AND WX90='F' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' AND WX20='彩盒' AND WX90='F' " ) );
                    model.AM131 = string.IsNullOrEmpty( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' AND WX20='彩盒' AND WX90='T' " ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(AK)" ,"WX01='" + model.AM002 + "' AND WX20='彩盒' AND WX90='T' " ) );

                    if ( i == 0 && ExistsOfCount( model.AM002 ) )
                    {
                        ofEleDelete( model );
                        PackageMaterialDelete( model ,SQLString );
                    }
                    else if ( i > 0 && model.AM002 != dk.Rows[i - 1]["WX01"].ToString( ) )
                    {
                        ofEleDelete( model );
                        PackageMaterialDelete( model ,SQLString );
                    }
                }
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        void ofEleDelete ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            DataTable da = GetDataTableOfEle( model.AM002 );
            if ( da != null && da.Rows.Count > 0 )
            {
                model.AM131 = string.IsNullOrEmpty( da.Rows[0]["AM131"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM131"].ToString( ) ) - model.AM131;
                model.AM134 = string.IsNullOrEmpty( da.Rows[0]["AM134"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM134"].ToString( ) ) - model.AM134;
                model.AM135 = string.IsNullOrEmpty( da.Rows[0]["AM135"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM135"].ToString( ) ) - model.AM135;
                model.AM137 = string.IsNullOrEmpty( da.Rows[0]["AM137"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM137"].ToString( ) ) - model.AM137;
                model.AM140 = string.IsNullOrEmpty( da.Rows[0]["AM140"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM140"].ToString( ) ) - model.AM140;
                model.AM141 = string.IsNullOrEmpty( da.Rows[0]["AM141"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM141"].ToString( ) ) - model.AM141;
                model.AM143 = string.IsNullOrEmpty( da.Rows[0]["AM143"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM143"].ToString( ) ) - model.AM143;
                model.AM146 = string.IsNullOrEmpty( da.Rows[0]["AM146"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM146"].ToString( ) ) - model.AM146;
                model.AM147 = string.IsNullOrEmpty( da.Rows[0]["AM147"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM147"].ToString( ) ) - model.AM147;
                model.AM149 = string.IsNullOrEmpty( da.Rows[0]["AM149"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM149"].ToString( ) ) - model.AM149;
            }
        }
        public void PackageMaterialDelete ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            strSql.AppendFormat( "AM131='{0}'," ,model.AM131 );
            strSql.AppendFormat( "AM134='{0}'," ,model.AM134 );
            strSql.AppendFormat( "AM135='{0}'," ,model.AM135 );
            strSql.AppendFormat( "AM137='{0}'," ,model.AM137 );
            strSql.AppendFormat( "AM140='{0}'," ,model.AM140 );
            strSql.AppendFormat( "AM141='{0}'," ,model.AM141 );
            strSql.AppendFormat( "AM143='{0}'," ,model.AM143 );
            strSql.AppendFormat( "AM146='{0}'," ,model.AM146 );
            strSql.AppendFormat( "AM147='{0}'," ,model.AM147 );
            strSql.AppendFormat( "AM149='{0}'" ,model.AM149 );
            strSql.AppendFormat( " WHERE AM002='{0}'" ,model.AM002 );
            SQLString.Add( strSql.ToString( ) );
        }

        /// <summary>
        /// 495  不用
        /// </summary>
        /// <param name="numList"></param>
        /// <param name="idxList"></param>
        /// <returns></returns>
        public void PqyMaterialDelete ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            strSql.AppendFormat( "AM089='{0}'" ,model.AM089 );
            strSql.AppendFormat( " WHERE AM002='{0}'" ,model.AM002 );
            SQLString.Add( strSql.ToString( ) );
        }
        public bool PqyDelete ( string idxList ,string numList ,MulaolaoLibrary.ProductCostSummaryLibrary model ,DataTable dk ,ArrayList SQLString )
        {
            dk = GetDataTablePqy( numList ,idxList );
            if ( dk != null && dk.Rows.Count > 0 )
            {
                for ( int m = 0 ; m < dk.Rows.Count ; m++ )
                {
                    model.AM002 = dk.Rows[m]["PY01"].ToString( );

                    model.AM089 = 0;

                    model.AM089 = string.IsNullOrEmpty( dk.Rows[m]["AK"].ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Rows[m]["AK"].ToString( ) );

                    if ( m == 0 && ExistsOfCount( model.AM002 ) )
                    {
                        ofPqyDelete( model );
                        PqyMaterialDelete( model ,SQLString );
                    }
                    else if ( m > 0 && model.AM002 != dk.Rows[m - 1]["PY01"].ToString( ) )
                    {
                        ofPqyDelete( model );
                        PqyMaterialDelete( model ,SQLString );
                    }                 
                }
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        void ofPqyDelete ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            DataTable da = GetDataTableOfPqy( model.AM002 );
            if ( da != null && da.Rows.Count > 0 )
            {
                if ( model.AM089 != 0 )
                    model.AM089 -= string.IsNullOrEmpty( da.Rows[0]["AM089"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM089"].ToString( ) );
            }
        }

        /// <summary>
        /// 获取317成本
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>        
        public bool PqwDelete ( string idxListOf ,string numList ,MulaolaoLibrary.ProductCostSummaryLibrary model ,DataTable dk ,ArrayList SQLString )
        {
            dk = GetDataTablePqw( numList ,idxListOf );
            if ( dk != null && dk.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < dk.Rows.Count ; i++ )
                {
                    model.AM002 = dk.Rows[i]["GZ01"].ToString( );
                    model.AM045 = model.AM047 = model.AM049 = model.AM051 = model.AM053 = model.AM055 = model.AM057 = model.AM059 = model.AM061 =model.AM063= 0;
                    model.AM045 = string.IsNullOrEmpty( dk.Compute( "SUM(GZ1)" ,"GZ01='" + model.AM002 + "' AND GX04='白坯'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(GZ1)" ,"GZ01='" + model.AM002 + "' AND GX04='白坯'" ) );
                    model.AM047 = string.IsNullOrEmpty( dk.Compute( "SUM(GZ1)" ,"GZ01='" + model.AM002 + "' AND GX04='砂光'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(GZ1)" ,"GZ01='" + model.AM002 + "' AND GX04='砂光'" ) );
                    model.AM049 = string.IsNullOrEmpty( dk.Compute( "SUM(GZ1)" ,"GZ01='" + model.AM002 + "' AND GX04='粘接'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(GZ1)" ,"GZ01='" + model.AM002 + "' AND GX04='粘接'" ) );
                    model.AM051 = string.IsNullOrEmpty( dk.Compute( "SUM(GZ1)" ,"GZ01='" + model.AM002 + "' AND GX04='组装'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(GZ1)" ,"GZ01='" + model.AM002 + "' AND GX04='组装'" ) );
                    model.AM053 = string.IsNullOrEmpty( dk.Compute( "SUM(GZ1)" ,"GZ01='" + model.AM002 + "' AND GX04='检验'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(GZ1)" ,"GZ01='" + model.AM002 + "' AND GX04='检验'" ) );
                    model.AM055 = string.IsNullOrEmpty( dk.Compute( "SUM(GZ1)" ,"GZ01='" + model.AM002 + "' AND GX04='包装'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(GZ1)" ,"GZ01='" + model.AM002 + "' AND GX04='包装'" ) );
                    model.AM057 = string.IsNullOrEmpty( dk.Compute( "SUM(GZ1)" ,"GZ01='" + model.AM002 + "' AND GX04='修理'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(GZ1)" ,"GZ01='" + model.AM002 + "' AND GX04='修理'" ) );
                    model.AM059 = string.IsNullOrEmpty( dk.Compute( "SUM(GZ1)" ,"GZ01='" + model.AM002 + "' AND GX04='后道辅助'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(GZ1)" ,"GZ01='" + model.AM002 + "' AND GX04='后道辅助'" ) );
                    model.AM061 = string.IsNullOrEmpty( dk.Compute( "SUM(GZ1)" ,"GZ01='" + model.AM002 + "' AND GX04='返工'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "SUM(GZ1)" ,"GZ01='" + model.AM002 + "' AND GX04='返工'" ) );
                    model.AM063 = string.IsNullOrEmpty( dk.Compute( "sum(GZ1)" ,"GZ01='" + model.AM002 + "' AND GX04  NOT IN ('白坯','砂光','粘接','组装','检验','包装','修理','后道辅助','返工')" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(GZ1)" ,"GZ01='" + model.AM002 + "' AND GX04  NOT IN ('白坯','砂光','粘接','组装','检验','包装','修理','后道辅助','返工')" ) );
                    if ( i == 0 && ExistsOfCount( model.AM002 ) )
                    {
                        ofTweDelete( model );
                        ProductBeforeAndAfterRoadWagesDelete( model ,SQLString );
                    }
                    else if ( i > 0 && model.AM002 != dk.Rows[i - 1]["GZ01"].ToString( ) )
                    {
                        ofTweDelete( model );
                        ProductBeforeAndAfterRoadWagesDelete( model ,SQLString );
                    }
                }
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        void ofTweDelete ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            DataTable da = GetDataTableOfTwe( model.AM002 );
            if ( da != null && da.Rows.Count > 0 )
            {
                model.AM045 = string.IsNullOrEmpty( da.Rows[0]["AM045"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM045"].ToString( ) ) - model.AM045;
                model.AM047 = string.IsNullOrEmpty( da.Rows[0]["AM047"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM047"].ToString( ) ) - model.AM047;
                model.AM049 = string.IsNullOrEmpty( da.Rows[0]["AM049"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM049"].ToString( ) ) - model.AM049;
                model.AM051 = string.IsNullOrEmpty( da.Rows[0]["AM051"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM051"].ToString( ) ) - model.AM051;
                model.AM053 = string.IsNullOrEmpty( da.Rows[0]["AM053"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM053"].ToString( ) ) - model.AM053;
                model.AM055 = string.IsNullOrEmpty( da.Rows[0]["AM055"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM055"].ToString( ) ) - model.AM055;
                model.AM057 = string.IsNullOrEmpty( da.Rows[0]["AM057"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM057"].ToString( ) ) - model.AM057;
                model.AM059 = string.IsNullOrEmpty( da.Rows[0]["AM059"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM059"].ToString( ) ) - model.AM059;
                model.AM061 = string.IsNullOrEmpty( da.Rows[0]["AM061"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM061"].ToString( ) ) - model.AM061;
                model.AM063 = string.IsNullOrEmpty( da.Rows[0]["AM063"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM063"].ToString( ) ) - model.AM063;
            }
        }
        public void ProductBeforeAndAfterRoadWagesDelete ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            strSql.AppendFormat( "AM045='{0}'," ,model.AM045 );
            strSql.AppendFormat( "AM047='{0}'," ,model.AM047 );
            strSql.AppendFormat( "AM049='{0}'," ,model.AM049 );
            strSql.AppendFormat( "AM051='{0}'," ,model.AM051 );
            strSql.AppendFormat( "AM053='{0}'," ,model.AM053 );
            strSql.AppendFormat( "AM055='{0}'," ,model.AM055 );
            strSql.AppendFormat( "AM057='{0}'," ,model.AM057 );
            strSql.AppendFormat( "AM059='{0}'," ,model.AM059 );
            strSql.AppendFormat( "AM061='{0}'," ,model.AM061 );
            strSql.AppendFormat( "AM063='{0}'" ,model.AM063 );
            strSql.AppendFormat( " WHERE AM002='{0}'" ,model.AM002 );
            SQLString.Add( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取243成本
        /// </summary>
        /// <param name="idxListOfOther"></param>
        /// <param name="model"></param>
        /// <param name="dk"></param>
        /// <param name="SQLString"></param>
        /// <returns></returns>
        public bool PqbeDelete ( string idxListOfOther ,MulaolaoLibrary.ProductCostSummaryLibrary model ,DataTable dk ,ArrayList SQLString )
        {
            dk = GetDataTablePqbe( idxListOfOther );
            if ( dk != null && dk.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < dk.Rows.Count ; i++ )
                {
                    model.AM002 = dk.Rows[i]["BE002"].ToString( );
                    model.AM021 = model.AM023 = model.AM025 = model.AM027 = model.AM029 = 0;

                    model.AM021 = string.IsNullOrEmpty( dk.Compute( "sum(BE007)" ,"BE002='" + model.AM002 + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(BE007)" ,"BE002='" + model.AM002 + "'" ) );
                    model.AM023 = string.IsNullOrEmpty( dk.Compute( "sum(BE008)" ,"BE002='" + model.AM002 + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(BE008)" ,"BE002='" + model.AM002 + "'" ) );
                    model.AM025 = string.IsNullOrEmpty( dk.Compute( "sum(BE009)" ,"BE002='" + model.AM002 + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(BE009)" ,"BE002='" + model.AM002 + "'" ) );
                    model.AM027 = string.IsNullOrEmpty( dk.Compute( "sum(BE010)" ,"BE002='" + model.AM002 + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(BE010)" ,"BE002='" + model.AM002 + "'" ) );
                    model.AM029 = string.IsNullOrEmpty( dk.Compute( "sum(BE011)" ,"BE002='" + model.AM002 + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( dk.Compute( "sum(BE011)" ,"BE002='" + model.AM002 + "'" ) );

                    if ( i == 0 && ExistsOfCount( model.AM002 ) )
                    {
                        ofPqbeDelete( model );
                        PqbeDeleteOf( model ,SQLString );
                    }
                    else if ( i > 0 && model.AM002 != dk.Rows[i - 1]["BE002"].ToString( ) )
                    {
                        ofPqbeDelete( model );
                        PqbeDeleteOf( model ,SQLString );
                    }
                }
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        void ofPqbeDelete ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            DataTable da = GetDataTableOfPqbe( model.AM002 );
            if ( da != null && da.Rows.Count > 0 )
            {
                model.AM021 = string.IsNullOrEmpty( da.Rows[0]["AM021"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM021"].ToString( ) ) - model.AM021;
                model.AM023 = string.IsNullOrEmpty( da.Rows[0]["AM023"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM023"].ToString( ) ) - model.AM023;
                model.AM025 = string.IsNullOrEmpty( da.Rows[0]["AM025"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM025"].ToString( ) ) - model.AM025;
                model.AM027 = string.IsNullOrEmpty( da.Rows[0]["AM027"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM027"].ToString( ) ) - model.AM027;
                model.AM029 = string.IsNullOrEmpty( da.Rows[0]["AM029"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AM029"].ToString( ) ) - model.AM029;
            }
        }
        public void PqbeDeleteOf ( MulaolaoLibrary.ProductCostSummaryLibrary model ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            strSql.AppendFormat( "AM021='{0}'," ,model.AM021 );
            strSql.AppendFormat( "AM023='{0}'," ,model.AM023 );
            strSql.AppendFormat( "AM025='{0}'," ,model.AM025 );
            strSql.AppendFormat( "AM027='{0}'," ,model.AM027 );
            strSql.AppendFormat( "AM029='{0}'" ,model.AM029 );
            strSql.AppendFormat( " WHERE AM002='{0}'" ,model.AM002 );
            SQLString.Add( strSql.ToString( ) );
        }

        /// <summary>
        /// 是否隐藏列
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool UpdateOfHide (string state )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQYZ SET" );
            strSql.Append( " YZ029=@YZ029" );
            SqlParameter[] parameter = {
                new SqlParameter("@YZ029",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = state;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 是否隐藏
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfHide ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT YZ029 FROM R_PQYZ" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfTre ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT BE001,BE002,BE003,BE004,BE005,BE006,BE007,BE008,BE009,BE010,BE011,BE012,idx kin,DGA003 FROM R_PQBE A LEFT JOIN TPADGA B ON A.BE016=B.DGA001 WHERE BE013 IS NULL OR BE013=''" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取480数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfFor ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT A.idx,CQ01,CQ99,CQ100,CQ101,CQ102,CQ103,CQ104,CQ105,CQ106,CQ107,CQ114 FROM R_PQCQ A LEFT JOIN R_REVIEWS B ON A.CQ01=B.RES06 AND RES05='执行' WHERE CQ112='' OR CQ112 IS NULL" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 批量编辑526标记
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool UpdateOfSign (string strWhere )
        {
            string str526 = "", str244 = "", str050 = "", str323 = "", str243 = "";
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT YZ022,YZ023,YZ024,YZ025,YZ027,YZ030 FROM R_PQYZ " );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( " AND YZ003='执行'" );

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            if ( da != null && da.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < da.Rows.Count ; i++ )
                {
                    if ( !string.IsNullOrEmpty( da.Rows[i]["YZ022"].ToString( ) ) )
                    {
                        if ( str526 == "" )
                            str526 = da.Rows[i]["YZ022"].ToString( );
                        else
                            str526 = str526 + "," + da.Rows[i]["YZ022"].ToString( );
                    }
                    if ( !string.IsNullOrEmpty( da.Rows[i]["YZ023"].ToString( ) ) )
                    {
                        if ( str244 == "" )
                            str244 = da.Rows[i]["YZ023"].ToString( );
                        else
                            str244 = str244 + "," + da.Rows[i]["YZ023"].ToString( );
                    }
                    if ( !string.IsNullOrEmpty( da.Rows[i]["YZ024"].ToString( ) ) )
                    {
                        if ( str050 == "" )
                            str050 = da.Rows[i]["YZ024"].ToString( );
                        else
                            str050 = str050 + "," + da.Rows[i]["YZ024"].ToString( );
                    }
                    if ( !string.IsNullOrEmpty( da.Rows[i]["YZ025"].ToString( ) ) )
                    {
                        if ( str050 == "" )
                            str050 = da.Rows[i]["YZ025"].ToString( );
                        else
                            str050 = str050 + "," + da.Rows[i]["YZ025"].ToString( );
                    }
                    if ( !string.IsNullOrEmpty( da.Rows[i]["YZ027"].ToString( ) ) )
                    {
                        if ( str050 == "" )
                            str323 = da.Rows[i]["YZ027"].ToString( );
                        else
                            str323 = str323 + "," + da.Rows[i]["YZ027"].ToString( );
                    }
                    if ( !string.IsNullOrEmpty( da.Rows[i]["YZ030"].ToString( ) ) )
                    {
                        if ( str243 == "" )
                            str243 = da.Rows[i]["YZ030"].ToString( );
                        else
                            str243 = str243 + "," + da.Rows[i]["YZ030"].ToString( );
                    }
                }

                strSql = new StringBuilder( );
                strSql.Append( "UPDATE R_PQAK SET AK017='执行'" );
                strSql.Append( " WHERE idx IN (" + str526 + ")" );

                int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
                if ( row > 0 )
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        /// <summary>
        /// 回写扣借支款到借款木佬佬还款额
        /// </summary>
        /// <param name="unit">使用单位</param>
        /// <param name="person">借款单位</param>
        /// <param name="money">还款额</param>
        /// <returns></returns>
        public bool UpdateJkTo (string handPer, string unit ,string person ,decimal money )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQAO set " );
            strSql . Append ( "AO013=@AO013 " );
            strSql . Append ( "WHERE AO005=@AO005 AND AO006=@AO006 AND AO007=@AO007" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@AO005",SqlDbType.NVarChar,20),
                new SqlParameter("@AO006",SqlDbType.NVarChar,20),
                new SqlParameter("@AO007",SqlDbType.NVarChar,20),
                new SqlParameter("@AO013",SqlDbType.Decimal,11)
            };
            parameter [ 0 ] . Value = handPer;
            parameter [ 1 ] . Value = unit;
            parameter [ 2 ] . Value = person;
            parameter [ 3 ] . Value = money;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }


        /// <summary>
        /// 回写扣借支款到借款木佬佬还款额
        /// </summary>
        /// <param name="unit">使用单位</param>
        /// <param name="person">借款单位</param>
        /// <param name="money">还款额</param>
        /// <returns></returns>
        public bool UpdateJkyTo ( string handPer ,string unit ,string person ,decimal money )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQAR set " );
            strSql . Append ( "AR013=@AR013 " );
            strSql . Append ( "WHERE AR005=@AR005 AND AR006=@AR006 AND AR007=@AR007" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@AR005",SqlDbType.NVarChar,20),
                new SqlParameter("@AR006",SqlDbType.NVarChar,20),
                new SqlParameter("@AR007",SqlDbType.NVarChar,20),
                new SqlParameter("@AR013",SqlDbType.Decimal,11)
            };
            parameter [ 0 ] . Value = handPer;
            parameter [ 1 ] . Value = unit;
            parameter [ 2 ] . Value = person;
            parameter [ 3 ] . Value = money;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

    }
}



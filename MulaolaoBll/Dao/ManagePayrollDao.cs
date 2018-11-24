using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using StudentMgr;
using System.Collections;
using System.Data.SqlClient;

namespace MulaolaoBll.Dao
{
    public class ManagePayrollDao
    {
        /// <summary>
        /// 获取负责人信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePersonInCharge ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DBA001,DBA002 FROM TPADBA" );
            strSql.Append( " WHERE DBA028!=''" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取单位
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableCompany ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT XZ003 FROM R_PQXZ" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
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
            strSql.Append( "DELETE FROM R_PQXZ" );
            strSql.AppendFormat( " WHERE XZ001='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            StringBuilder strS = new StringBuilder( );
            strS.Append( "DELETE FROM R_REVIEWS" );
            strS.AppendFormat( " WHERE RES06='{0}'" ,oddNum );
            SQLString.Add( strS.ToString( ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfWeiHu ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT XZ015 FROM R_PQXZ" );
            strSql.Append( " WHERE XZ001=@XZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@XZ001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 编辑一单记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary . ManagePayrollLibrary _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQXZ SET " );
            strSql . Append ( "XZ013=@XZ013," );
            strSql . Append ( "XZ015=@XZ015," );
            strSql . Append ( "XZ016=@XZ016," );
            strSql . Append ( "XZ017=@XZ017," );
            strSql . Append ( "XZ018=@XZ018," );
            strSql . Append ( "XZ019=@XZ019," );
            strSql . Append ( "XZ020=@XZ020" );
            strSql . Append ( " WHERE XZ001=@XZ001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@XZ015",SqlDbType.NVarChar,2000),
                new SqlParameter("@XZ016",SqlDbType.NVarChar,255),
                new SqlParameter("@XZ017",SqlDbType.NVarChar,20),
                new SqlParameter("@XZ018",SqlDbType.NVarChar,20),
                new SqlParameter("@XZ019",SqlDbType.NVarChar,20),
                new SqlParameter("@XZ020",SqlDbType.Date),
                new SqlParameter("@XZ001",SqlDbType.NVarChar,20),
                new SqlParameter("@XZ013",SqlDbType.Date)
            };
            parameter [ 0 ] . Value = _model . XZ015;
            parameter [ 1 ] . Value = _model . XZ016;
            parameter [ 2 ] . Value = _model . XZ017;
            parameter [ 3 ] . Value = _model . XZ018;
            parameter [ 4 ] . Value = _model . XZ019;
            parameter [ 5 ] . Value = _model . XZ020;
            parameter [ 6 ] . Value = _model . XZ001;
            parameter [ 7 ] . Value = _model . XZ013;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Exists ( MulaolaoLibrary.ManagePayrollLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQXZ" );
            strSql.Append( " WHERE XZ001=@XZ001 AND XZ014=@XZ014 AND XZ002=@XZ002 AND XZ003=@XZ003 AND XZ004=@XZ004" );
            SqlParameter[] parameter = {
                new SqlParameter("@XZ001",SqlDbType.NVarChar,20),
                new SqlParameter("@XZ002",SqlDbType.NVarChar,20),
                new SqlParameter("@XZ003",SqlDbType.NVarChar,20),
                new SqlParameter("@XZ004",SqlDbType.NVarChar,20),
                new SqlParameter("@XZ014",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = _model.XZ001;
            parameter[1].Value = _model.XZ002;
            parameter[2].Value = _model.XZ003;
            parameter[3].Value = _model.XZ004;
            parameter[4].Value = _model.XZ014;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public int Add ( MulaolaoLibrary . ManagePayrollLibrary _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQXZ (" );
            strSql . Append ( "XZ001,XZ002,XZ003,XZ004,XZ005,XZ006,XZ007,XZ008,XZ009,XZ010,XZ011,XZ012,XZ013,XZ014,XZ021,XZ023,XZ024,XZ027,XZ028,XZ029,XZ030,XZ031,XZ032)" );
            strSql . Append ( " VALUES (" );
            strSql . Append ( "@XZ001,@XZ002,@XZ003,@XZ004,@XZ005,@XZ006,@XZ007,@XZ008,@XZ009,@XZ010,@XZ011,@XZ012,@XZ013,@XZ014,@XZ021,@XZ024,@XZ024,@XZ027,@XZ028,@XZ029,@XZ030,@XZ031,@XZ032);" );
            strSql . Append ( "SELECT SCOPE_IDENTITY();" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@XZ001",SqlDbType.NVarChar,20),
                new SqlParameter("@XZ002",SqlDbType.NVarChar,20),
                new SqlParameter("@XZ003",SqlDbType.NVarChar,20),
                new SqlParameter("@XZ004",SqlDbType.NVarChar,20),
                new SqlParameter("@XZ005",SqlDbType.Decimal,8),
                new SqlParameter("@XZ006",SqlDbType.Decimal,5),
                new SqlParameter("@XZ007",SqlDbType.Decimal,5),
                new SqlParameter("@XZ008",SqlDbType.Decimal,6),
                new SqlParameter("@XZ009",SqlDbType.Decimal,6),
                new SqlParameter("@XZ010",SqlDbType.Decimal,6),
                new SqlParameter("@XZ011",SqlDbType.Decimal,6),
                new SqlParameter("@XZ012",SqlDbType.NVarChar,20),
                new SqlParameter("@XZ013",SqlDbType.Date),
                new SqlParameter("@XZ014",SqlDbType.NVarChar,20),
                new SqlParameter("@XZ021",SqlDbType.Decimal,7),
                new SqlParameter("@XZ023",SqlDbType.Decimal,7),
                new SqlParameter("@XZ024",SqlDbType.Decimal,7),
                new SqlParameter("@XZ027",SqlDbType.NVarChar,100),
                new SqlParameter("@XZ028",SqlDbType.NVarChar,20),
                new SqlParameter("@XZ029",SqlDbType.Decimal,7),
                new SqlParameter("@XZ030",SqlDbType.Decimal,18),
                new SqlParameter("@XZ031",SqlDbType.Decimal,18),
                new SqlParameter("@XZ032",SqlDbType.Decimal,18)
            };
            parameter [ 0 ] . Value = _model . XZ001;
            parameter [ 1 ] . Value = _model . XZ002;
            parameter [ 2 ] . Value = _model . XZ003;
            parameter [ 3 ] . Value = _model . XZ004;
            parameter [ 4 ] . Value = _model . XZ005;
            parameter [ 5 ] . Value = _model . XZ006;
            parameter [ 6 ] . Value = _model . XZ007;
            parameter [ 7 ] . Value = _model . XZ008;
            parameter [ 8 ] . Value = _model . XZ009;
            parameter [ 9 ] . Value = _model . XZ010;
            parameter [ 10 ] . Value = _model . XZ011;
            parameter [ 11 ] . Value = _model . XZ012;
            parameter [ 12 ] . Value = _model . XZ013;
            parameter [ 13 ] . Value = _model . XZ014;
            parameter [ 14 ] . Value = _model . XZ021;
            parameter [ 15 ] . Value = _model . XZ023;
            parameter [ 16 ] . Value = _model . XZ024;
            parameter [ 17 ] . Value = _model . XZ027;
            parameter [ 18 ] . Value = _model . XZ028;
            parameter [ 19 ] . Value = _model . XZ029;
            parameter [ 20 ] . Value = _model . XZ030;
            parameter [ 21 ] . Value = _model . XZ031;
            parameter [ 22 ] . Value = _model . XZ032;

            return SqlHelper . ExecuteSqlReturnId ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ManagePayrollLibrary GetModel ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQXZ" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = idx;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da != null && da.Rows.Count > 0 )
                return GetDataRow( da.Rows[0] );
            else
                return null;
        }
        public MulaolaoLibrary.ManagePayrollLibrary GetModel ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQXZ " );
            strSql.Append( " WHERE XZ001=@XZ001 " );//and XZ013 is not null
            SqlParameter [ ] parameter = {
                new SqlParameter("@XZ001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da != null && da.Rows.Count > 0 )
                return GetDataRow( da.Rows[0] );
            else
                return null;
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ManagePayrollLibrary GetDataRow ( DataRow row )
        {
            MulaolaoLibrary.ManagePayrollLibrary _model = new MulaolaoLibrary.ManagePayrollLibrary( );

            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    _model.IDX = int.Parse( row["idx"].ToString( ) );
                if ( row["XZ001"] != null && row["XZ001"].ToString( ) != "" )
                    _model.XZ001 = row["XZ001"].ToString( );
                if ( row["XZ002"] != null && row["XZ002"].ToString( ) != "" )
                    _model.XZ002 = row["XZ002"].ToString( );
                if ( row["XZ003"] != null && row["XZ003"].ToString( ) != "" )
                    _model.XZ003 = row["XZ003"].ToString( );
                if ( row["XZ004"] != null && row["XZ004"].ToString( ) != "" )
                    _model.XZ004 = row["XZ004"].ToString( );
                if ( row["XZ005"] != null && row["XZ005"].ToString( ) != "" )
                    _model.XZ005 = decimal.Parse( row["XZ005"].ToString( ) );
                if ( row["XZ006"] != null && row["XZ006"].ToString( ) != "" )
                    _model.XZ006 = decimal.Parse( row["XZ006"].ToString( ) );
                if ( row["XZ007"] != null && row["XZ007"].ToString( ) != "" )
                    _model.XZ007 = decimal.Parse( row["XZ007"].ToString( ) );
                if ( row["XZ008"] != null && row["XZ008"].ToString( ) != "" )
                    _model.XZ008 = decimal.Parse( row["XZ008"].ToString( ) );
                if ( row["XZ009"] != null && row["XZ009"].ToString( ) != "" )
                    _model.XZ009 = decimal.Parse( row["XZ009"].ToString( ) );
                if ( row["XZ010"] != null && row["XZ010"].ToString( ) != "" )
                    _model.XZ010 = decimal.Parse( row["XZ010"].ToString( ) );
                if ( row["XZ011"] != null && row["XZ011"].ToString( ) != "" )
                    _model.XZ011 = decimal.Parse( row["XZ011"].ToString( ) );
                if ( row["XZ012"] != null && row["XZ012"].ToString( ) != "" )
                    _model.XZ012 = row["XZ012"].ToString( );
                if ( row["XZ013"] != null && row["XZ013"].ToString( ) != "" )
                    _model.XZ013 = DateTime.Parse( row["XZ013"].ToString( ) );
                if ( row["XZ014"] != null && row["XZ014"].ToString( ) != "" )
                    _model.XZ014 = row["XZ014"].ToString( );
                if ( row["XZ015"] != null && row["XZ015"].ToString( ) != "" )
                    _model.XZ015 = row["XZ015"].ToString( );
                if ( row["XZ016"] != null && row["XZ016"].ToString( ) != "" )
                    _model.XZ016 = row["XZ016"].ToString( );
                if ( row["XZ017"] != null && row["XZ017"].ToString( ) != "" )
                    _model.XZ017 = row["XZ017"].ToString( );
                if ( row["XZ018"] != null && row["XZ018"].ToString( ) != "" )
                    _model.XZ018 = row["XZ018"].ToString( );
                if ( row["XZ019"] != null && row["XZ019"].ToString( ) != "" )
                    _model.XZ019 = row["XZ019"].ToString( );
                if ( row["XZ020"] != null && row["XZ020"].ToString( ) != "" )
                    _model.XZ020 = DateTime.Parse( row["XZ020"].ToString( ) );
                if ( row["XZ021"] != null && row["XZ021"].ToString( ) != "" )
                    _model.XZ021 = decimal.Parse( row["XZ021"].ToString( ) );
                if ( row["XZ023"] != null && row["XZ023"].ToString( ) != "" )
                    _model.XZ023 = decimal.Parse( row["XZ023"].ToString( ) );
                if ( row["XZ024"] != null && row["XZ024"].ToString( ) != "" )
                    _model.XZ024 = decimal.Parse( row["XZ024"].ToString( ) );
                if ( row["XZ027"] != null && row["XZ027"].ToString( ) != "" )
                    _model.XZ027 = row["XZ027"].ToString( );
                if ( row["XZ028"] != null && row["XZ028"].ToString( ) != "" )
                    _model.XZ028 = row["XZ028"].ToString( );
                if ( row [ "XZ029" ] != null && row [ "XZ029" ] . ToString ( ) != "" )
                    _model . XZ029 = decimal . Parse ( row [ "XZ029" ] . ToString ( ) );
                if ( row [ "XZ030" ] != null && row [ "XZ030" ] . ToString ( ) != "" )
                    _model . XZ030 = decimal . Parse ( row [ "XZ030" ] . ToString ( ) );
                if ( row [ "XZ031" ] != null && row [ "XZ031" ] . ToString ( ) != "" )
                    _model . XZ031 = decimal . Parse ( row [ "XZ031" ] . ToString ( ) );
                if ( row [ "XZ032" ] != null && row [ "XZ032" ] . ToString ( ) != "" )
                    _model . XZ032 = bool . Parse ( row [ "XZ032" ] . ToString ( ) );
            }

            return _model;
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Updates ( MulaolaoLibrary . ManagePayrollLibrary _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQXZ SET " );
            strSql . Append ( "XZ002=@XZ002," );
            strSql . Append ( "XZ003=@XZ003," );
            strSql . Append ( "XZ004=@XZ004," );
            strSql . Append ( "XZ005=@XZ005," );
            strSql . Append ( "XZ006=@XZ006," );
            strSql . Append ( "XZ007=@XZ007," );
            strSql . Append ( "XZ008=@XZ008," );
            strSql . Append ( "XZ009=@XZ009," );
            strSql . Append ( "XZ010=@XZ010," );
            strSql . Append ( "XZ011=@XZ011," );
            strSql . Append ( "XZ012=@XZ012," );
            strSql . Append ( "XZ013=@XZ013," );
            strSql . Append ( "XZ014=@XZ014," );
            strSql . Append ( "XZ021=@XZ021," );
            strSql . Append ( "XZ023=@XZ023," );
            strSql . Append ( "XZ024=@XZ024," );
            strSql . Append ( "XZ027=@XZ027," );
            strSql . Append ( "XZ028=@XZ028," );
            strSql . Append ( "XZ029=@XZ029," );
            strSql . Append ( "XZ030=@XZ030," );
            strSql . Append ( "XZ031=@XZ031," );
            strSql . Append ( "XZ032=@XZ032 " );
            strSql . Append ( " WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@XZ002",SqlDbType.NVarChar,20),
                new SqlParameter("@XZ003",SqlDbType.NVarChar,20),
                new SqlParameter("@XZ004",SqlDbType.NVarChar,20),
                new SqlParameter("@XZ005",SqlDbType.Decimal,8),
                new SqlParameter("@XZ006",SqlDbType.Decimal,5),
                new SqlParameter("@XZ007",SqlDbType.Decimal,5),
                new SqlParameter("@XZ008",SqlDbType.Decimal,6),
                new SqlParameter("@XZ009",SqlDbType.Decimal,6),
                new SqlParameter("@XZ010",SqlDbType.Decimal,6),
                new SqlParameter("@XZ011",SqlDbType.Decimal,6),
                new SqlParameter("@XZ012",SqlDbType.NVarChar,20),
                new SqlParameter("@XZ013",SqlDbType.Date),
                new SqlParameter("@XZ014",SqlDbType.NVarChar,20),
                new SqlParameter("@XZ021",SqlDbType.Decimal,7),
                new SqlParameter("@XZ023",SqlDbType.Decimal,7),
                new SqlParameter("@XZ024",SqlDbType.Decimal,7),
                new SqlParameter("@XZ027",SqlDbType.NVarChar,100),
                new SqlParameter("@XZ028",SqlDbType.NVarChar,20),
                new SqlParameter("@XZ029",SqlDbType.Decimal,7),
                new SqlParameter("@XZ030",SqlDbType.Decimal,18),
                new SqlParameter("@XZ031",SqlDbType.Decimal,18),
                new SqlParameter("@XZ032",SqlDbType.Bit),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter [ 0 ] . Value = _model . XZ002;
            parameter [ 1 ] . Value = _model . XZ003;
            parameter [ 2 ] . Value = _model . XZ004;
            parameter [ 3 ] . Value = _model . XZ005;
            parameter [ 4 ] . Value = _model . XZ006;
            parameter [ 5 ] . Value = _model . XZ007;
            parameter [ 6 ] . Value = _model . XZ008;
            parameter [ 7 ] . Value = _model . XZ009;
            parameter [ 8 ] . Value = _model . XZ010;
            parameter [ 9 ] . Value = _model . XZ011;
            parameter [ 10 ] . Value = _model . XZ012;
            parameter [ 11 ] . Value = _model . XZ013;
            parameter [ 12 ] . Value = _model . XZ014;
            parameter [ 13 ] . Value = _model . XZ021;
            parameter [ 14 ] . Value = _model . XZ023;
            parameter [ 15 ] . Value = _model . XZ024;
            parameter [ 16 ] . Value = _model . XZ027;
            parameter [ 17 ] . Value = _model . XZ028;
            parameter [ 18 ] . Value = _model . XZ029;
            parameter [ 19 ] . Value = _model . XZ030;
            parameter [ 20 ] . Value = _model . XZ031;
            parameter [ 21 ] . Value = _model . XZ032;
            parameter [ 22 ] . Value = _model . IDX;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Deletes ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQXZ" );
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
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string strWhere ,DateTime dt )
        {
            StringBuilder strSql = new StringBuilder ( );
            if ( dt . Day == 31 )
                strSql . Append ( "SELECT idx,XZ002,XZ003,XZ004,XZ005,XZ006,XZ007,XZ008,XZ009,XZ010,XZ011,XZ012,XZ013,XZ014,XZ021,XZ022,XZ023,XZ024,XZ027,XZ028,XZ029,CONVERT(DECIMAL(18,5),XZ005/(day(dateadd(d,-day(@XZ13),dateadd(m,0,@XZ13)))+1)) U4,CONVERT(DECIMAL(18,5),XZ005/(day(dateadd(d,-day(@XZ13),dateadd(m,0,@XZ13)))+1)*(XZ006+XZ007)) U6,XZ030,XZ031,XZ032 FROM R_PQXZ" );
            else
                strSql . Append ( "SELECT idx,XZ002,XZ003,XZ004,XZ005,XZ006,XZ007,XZ008,XZ009,XZ010,XZ011,XZ012,XZ013,XZ014,XZ021,XZ022,XZ023,XZ024,XZ027,XZ028,XZ029,CONVERT(DECIMAL(18,5),XZ005/day(dateadd(d,-day(@XZ13),dateadd(m,1,@XZ13)))) U4,CONVERT(DECIMAL(18,5),XZ005/day(dateadd(d,-day(@XZ13),dateadd(m,1,@XZ13)))*(XZ006+XZ007)) U6,XZ030,XZ031,XZ032 FROM R_PQXZ" );
            strSql . Append ( " WHERE " + strWhere );
            SqlParameter [ ] parameter = {
                new SqlParameter("@XZ13",SqlDbType.Date)
            };
            parameter [ 0 ] . Value = dt;

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
        }
        public DataTable GetDataTableTwo ( string strWhere ,DateTime dt )
        {
            StringBuilder strSql = new StringBuilder( );
            if ( dt . Day == 31 )
                strSql . Append ( "SELECT idx,XZ002,XZ003,XZ004,XZ005,XZ006,XZ007,XZ008,XZ009,XZ010,XZ011,XZ012,XZ013,XZ014,XZ021,XZ022,XZ023,XZ024,XZ027,XZ028,XZ029,CONVERT(DECIMAL(18,5),XZ005/day(dateadd(d,-day(@XZ13),dateadd(m,0,@XZ13)))) U4,CONVERT(DECIMAL(18,5),XZ005/day(dateadd(d,-day(@XZ13),dateadd(m,0,@XZ13)))*(XZ006+XZ007)) U6,XZ030,XZ031,XZ032 FROM R_PQXZ" );
            else
                strSql . Append ( "SELECT idx,XZ002,XZ003,XZ004,XZ005,XZ006,XZ007,XZ008,XZ009,XZ010,XZ011,XZ012,XZ013,XZ014,XZ021,XZ022,XZ023,XZ024,XZ027,XZ028,XZ029,CONVERT(DECIMAL(18,5),XZ005/day(dateadd(d,-day(@XZ13),dateadd(m,1,@XZ13)))) U4,CONVERT(DECIMAL(18,5),XZ005/day(dateadd(d,-day(@XZ13),dateadd(m,1,@XZ13)))*(XZ006+XZ007)) U6,XZ030,XZ031,XZ032 FROM R_PQXZ" );
            strSql .Append( " WHERE " + strWhere );
            strSql.Append( " AND XZ014='行政' AND XZ028='1'" );
            SqlParameter[] parameter = {
                new SqlParameter("@XZ13",SqlDbType.Date)
            };
            parameter[0].Value = dt;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public DataTable GetDataTableTre ( string strWhere ,DateTime dt )
        {
            StringBuilder strSql = new StringBuilder( );
            if ( dt . Day == 31 )
                strSql .Append( "SELECT idx,XZ002,XZ003,XZ004,XZ005,XZ006,XZ007,XZ008,XZ009,XZ010,XZ011,XZ012,XZ013,XZ014,XZ021,XZ022,XZ023,XZ024,XZ027,XZ028,XZ029,CONVERT(DECIMAL(18,5),XZ005/day(dateadd(d,-day(@XZ13),dateadd(m,0,@XZ13)))) U4,CONVERT(DECIMAL(18,5),XZ005/day(dateadd(d,-day(@XZ13),dateadd(m,0,@XZ13)))*(XZ006+XZ007)) U6,XZ030,XZ031,XZ032 FROM R_PQXZ" );
            else
                strSql . Append ( "SELECT idx,XZ002,XZ003,XZ004,XZ005,XZ006,XZ007,XZ008,XZ009,XZ010,XZ011,XZ012,XZ013,XZ014,XZ021,XZ022,XZ023,XZ024,XZ027,XZ028,XZ029,CONVERT(DECIMAL(18,5),XZ005/day(dateadd(d,-day(@XZ13),dateadd(m,1,@XZ13)))) U4,CONVERT(DECIMAL(18,5),XZ005/day(dateadd(d,-day(@XZ13),dateadd(m,1,@XZ13)))*(XZ006+XZ007)) U6,XZ030,XZ031,XZ032 FROM R_PQXZ" );
            strSql .Append( " WHERE " + strWhere );
            strSql.Append( " AND XZ014='生产部' AND XZ028='1'" );
            SqlParameter[] parameter = {
                new SqlParameter("@XZ13",SqlDbType.Date)
            };
            parameter[0].Value = dt;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public DataTable GetDataTableFor ( string strWhere ,DateTime dt )
        {
            StringBuilder strSql = new StringBuilder( );
            if ( dt . Day == 31 )
                strSql .Append( "SELECT idx,XZ002,XZ003,XZ004,XZ005,XZ006,XZ007,XZ008,XZ009,XZ010,XZ011,XZ012,XZ013,XZ014,XZ021,XZ022,XZ023,XZ024,XZ027,XZ028,XZ029,CONVERT(DECIMAL(18,5),XZ005/day(dateadd(d,-day(@XZ13),dateadd(m,0,@XZ13)))) U4,CONVERT(DECIMAL(18,5),XZ005/day(dateadd(d,-day(@XZ13),dateadd(m,0,@XZ13)))*(XZ006+XZ007)) U6,XZ030,XZ031,XZ032 FROM R_PQXZ" );
            else
                strSql . Append ( "SELECT idx,XZ002,XZ003,XZ004,XZ005,XZ006,XZ007,XZ008,XZ009,XZ010,XZ011,XZ012,XZ013,XZ014,XZ021,XZ022,XZ023,XZ024,XZ027,XZ028,XZ029,CONVERT(DECIMAL(18,5),XZ005/day(dateadd(d,-day(@XZ13),dateadd(m,1,@XZ13)))) U4,CONVERT(DECIMAL(18,5),XZ005/day(dateadd(d,-day(@XZ13),dateadd(m,1,@XZ13)))*(XZ006+XZ007)) U6,XZ030,XZ031,XZ032 FROM R_PQXZ" );
            strSql .Append( " WHERE " + strWhere );
            strSql.Append( " AND XZ028='2'" );
            SqlParameter[] parameter = {
                new SqlParameter("@XZ13",SqlDbType.Date)
            };
            parameter[0].Value = dt;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT XZ001 FROM R_PQXZ" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount ( string strWhere )
        {
            try
            {
                editDate ( );
            }
            catch { }

            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM (SELECT DISTINCT XZ001,SUBSTRING(CONVERT(VARCHAR(12),XZ013),0,8) XZ013 FROM R_PQXZ" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") A" );

            object obj= SqlHelper.GetSingle( strSql.ToString( ) );
            if ( obj == null )
                return 0;
            else
                return Convert.ToInt32( obj );
        }

        //xz013
        void editDate ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQXZ SET R_PQXZ.XZ013=A.XZ013 FROM (SELECT DISTINCT XZ013,XZ001 FROM R_PQXZ WHERE XZ013 IS NOT NULL) A WHERE A.XZ001=R_PQXZ.XZ001" );

            SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTableByChange (string strWhere,int startIndex,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT XZ001,SUBSTRING(CONVERT(VARCHAR(12),XZ013),0,8) XZ013,RES05 FROM (" );
            strSql.Append( "SELECT ROW_NUMBER() OVER(" );
            strSql.Append( "ORDER BY T.XZ001 DESC" );
            strSql.Append( ") AS Row,T.* FROM R_PQXZ T" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") TT LEFT JOIN R_REVIEWS B ON TT.XZ001=B.RES06" );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrint ( string oddNum ,string strPrintWhere)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "WITH CET AS (SELECT XZ002,XZ003,XZ004,XZ005,XZ006,XZ007,XZ008,XZ009,XZ010,XZ011,XZ012,XZ013,XZ014,XZ021,XZ023,XZ024,XZ027,XZ017,XZ018,XZ019,XZ030,XZ031,GETDATE() XZ020,XZ028,XZ029,XZ006+XZ007 U0,XZ010+XZ008+XZ011+XZ009+XZ024+XZ030+XZ031 U2,CASE WHEN XZ013 IS NOT NULL AND DAY(XZ013)=31 THEN CONVERT(DECIMAL(18,5),XZ005/DAY(DATEADD(d,-DAY(XZ013),DATEADD(m,0,XZ013)))) ELSE CONVERT(DECIMAL(18,5),XZ005/DAY(DATEADD(d,-DAY(XZ013),DATEADD(m,1,XZ013)))) END U4,CASE WHEN XZ013 IS NOT NULL AND DAY(XZ013)=31 THEN CONVERT(DECIMAL(18,5),XZ005/DAY(DATEADD(d,-DAY(XZ013),DATEADD(m,0,XZ013)))*(XZ006+XZ007)) ELSE CONVERT(DECIMAL(18,5),XZ005/DAY(DATEADD(d,-DAY(XZ013),DATEADD(m,1,XZ013)))*(XZ006+XZ007)) END U6 FROM R_PQXZ" );
            strSql.Append( " WHERE XZ001=@XZ001");
            strSql.Append( " AND " + strPrintWhere );
            strSql.Append( " )" );
            strSql.Append( "SELECT XZ002,XZ003,XZ004,XZ005,XZ006,XZ007,XZ008,XZ009,XZ010,XZ011,XZ012,XZ013,XZ014,XZ021,XZ023,XZ024,XZ017,XZ018,XZ019,XZ020,XZ028,XZ029,U0,U2,U4,U6,CONVERT(DECIMAL(18,2),XZ023+XZ021+U0*U4+XZ029) U7,CONVERT(DECIMAL(18,2),XZ023+XZ021+U6+XZ029-(XZ010+XZ008+XZ011+XZ009+XZ024+XZ030+XZ031)) U3,CASE WHEN U0=0 THEN 0 ELSE CONVERT(DECIMAL(18,5),(XZ023+XZ021+U0*U4+XZ029)/U0) END U5,XZ027,XZ030,XZ031 FROM CET" );
            //CASE WHEN U0=0 THEN 0 ELSE CONVERT(DECIMAL(18,5),(XZ023+XZ021+U0*U4)/U0) END U5
            SqlParameter [ ] parameter = {
                new SqlParameter("@XZ001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;
            
            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableExport ( string oddNum,string strPrintWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "WITH CET AS (SELECT XZ021,XZ023,XZ029,XZ006+XZ007 U0,XZ010+XZ008+XZ011+XZ009+XZ024+XZ030+XZ031 U2,CASE WHEN XZ013 IS NULL AND DAY(XZ013)=31 THEN CONVERT(DECIMAL(18,5),XZ005/DAY(DATEADD(d,-DAY(XZ013),DATEADD(m,0,XZ013)))) ELSE CONVERT(DECIMAL(18,5),XZ005/DAY(DATEADD(d,-DAY(XZ013),DATEADD(m,1,XZ013)))) END U4 FROM R_PQXZ" );
            strSql.Append( " WHERE XZ001=@XZ001" );
            strSql.Append( " AND " + strPrintWhere );
            strSql.Append( " )" );
            strSql.Append( "SELECT SUM(CONVERT(DECIMAL(18,2),XZ023+XZ021+XZ029+U0*U4-U2)) U3 FROM CET" );
            SqlParameter[] parameter = {
                new SqlParameter("@XZ001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 复制数据
        /// </summary>
        /// <param name="OddNum"></param>
        /// <returns></returns>
        public bool Copy ( string OddNum)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQXZ (" );
            strSql.Append( "XZ014,XZ002,XZ003,XZ004,XZ005,XZ008,XZ009,XZ028,XZ030,XZ031,XZ032)" );
            strSql.Append( " SELECT XZ014,XZ002,XZ003,XZ004,XZ005,XZ008,XZ009,XZ028,XZ030,XZ031,XZ032 FROM R_PQXZ" );
            strSql.Append( " WHERE XZ001=@XZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@XZ001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = OddNum;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除复制数据
        /// </summary>
        /// <returns></returns>
        public bool DeleteOfCopy ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQXZ WHERE XZ001 IS NULL" );

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 编辑复制数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateOfCopy ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQXZ SET " );
            strSql.Append( "XZ001=@XZ001 WHERE XZ001 IS NULL" );
            SqlParameter[] parameter = {
                new SqlParameter("@XZ001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 批量编辑养老
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="yl"></param>
        /// <returns></returns>
        public bool BatchEdit ( string oddNum ,decimal yl)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQXZ SET XZ009=@XZ009 WHERE XZ001=@XZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@XZ009",SqlDbType.Decimal,6),
                new SqlParameter("@XZ001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = yl;
            parameter[1].Value = oddNum;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using StudentMgr;
using System.Collections;

namespace MulaolaoBll.Dao
{
    public class SailsPaymentTaxRefundAndElectricityBillDao
    {
        /// <summary>
        /// 是否存在一条记录
        /// </summary>
        /// <param name="dateYear"></param>
        /// <param name="dateDay"></param>
        /// <param name="term"></param>
        /// <returns></returns>
        public bool Exists ( int dateYear ,int dateDay ,string term )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQNZ" );
            strSql.Append( " WHERE NZ002=@NZ002 AND NZ003=@NZ003 AND NZ004=@NZ004" );
            SqlParameter[] parameter = {
                new SqlParameter("@NZ002",SqlDbType.Int),
                new SqlParameter("@NZ003",SqlDbType.Int),
                new SqlParameter("@NZ004",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = dateYear;
            parameter[1].Value = dateDay;
            parameter[2].Value = term;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }
        public bool Exists ( int dateYear  )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQNZ" );
            strSql.Append( " WHERE NZ002=@NZ002 AND NZ004='订单R-250表额'" );
            SqlParameter[] parameter = {
                new SqlParameter("@NZ002",SqlDbType.Int)
            };
            parameter[0].Value = dateYear;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public int Add ( MulaolaoLibrary.SailsPaymentTaxRefundAndElectricityBillLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQNZ (" );
            strSql.Append( "NZ001,NZ002,NZ003,NZ004,NZ005,NZ008,NZ009,NZ010,NZ011,NZ012,NZ013,NZ014,NZ015,NZ016,NZ017,NZ018,NZ019)" );
            strSql.Append( " VALUES (" );
            strSql.Append( "@NZ001,@NZ002,@NZ003,@NZ004,@NZ005,@NZ008,@NZ009,@NZ010,@NZ011,@NZ012,@NZ013,@NZ014,@NZ015,@NZ016,@NZ017,@NZ018,@NZ019);" );
            strSql.Append( "SELECT SCOPE_IDENTITY();" );
            SqlParameter[] parameter = {
                new SqlParameter("@NZ001",SqlDbType.NVarChar,20),
                new SqlParameter("@NZ002",SqlDbType.Int),
                new SqlParameter("@NZ003",SqlDbType.Int),
                new SqlParameter("@NZ004",SqlDbType.NVarChar,20),
                new SqlParameter("@NZ005",SqlDbType.Int),
                new SqlParameter("@NZ008",SqlDbType.Int),
                new SqlParameter("@NZ009",SqlDbType.Int),
                new SqlParameter("@NZ010",SqlDbType.Decimal,11),
                new SqlParameter("@NZ011",SqlDbType.Decimal,11),
                new SqlParameter("@NZ012",SqlDbType.Decimal,3),
                new SqlParameter("@NZ013",SqlDbType.Int),
                new SqlParameter("@NZ014",SqlDbType.Int),
                new SqlParameter("@NZ015",SqlDbType.Int),
                new SqlParameter("@NZ016",SqlDbType.Int),
                new SqlParameter("@NZ017",SqlDbType.Int),
                new SqlParameter("@NZ018",SqlDbType.Decimal,4),
                new SqlParameter("@NZ019",SqlDbType.Int)
            };
            parameter[0].Value = _model.NZ001;
            parameter[1].Value = _model.NZ002;
            parameter[2].Value = _model.NZ003;
            parameter[3].Value = _model.NZ004;
            parameter[4].Value = _model.NZ005;
            parameter[5].Value = _model.NZ008;
            parameter[6].Value = _model.NZ009;
            parameter[7].Value = _model.NZ010;
            parameter[8].Value = _model.NZ011;
            parameter[9].Value = _model.NZ012;
            parameter[10].Value = _model.NZ013;
            parameter[11].Value = _model.NZ014;
            parameter[12].Value = _model.NZ015;
            parameter[13].Value = _model.NZ016;
            parameter[14].Value = _model.NZ017;
            parameter[15].Value = _model.NZ018;
            parameter[16].Value = _model.NZ019;

            return SqlHelper.ExecuteSqlReturnId( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.SailsPaymentTaxRefundAndElectricityBillLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQNZ SET " );
            strSql.Append( "NZ002=@NZ002," );
            strSql.Append( "NZ003=@NZ003," );
            strSql.Append( "NZ004=@NZ004," );
            strSql.Append( "NZ005=@NZ005," );
            strSql.Append( "NZ008=@NZ008," );
            strSql.Append( "NZ009=@NZ009," );
            strSql.Append( "NZ010=@NZ010," );
            strSql.Append( "NZ011=@NZ011," );
            strSql.Append( "NZ012=@NZ012," );
            strSql.Append( "NZ013=@NZ013," );
            strSql.Append( "NZ014=@NZ014," );
            strSql.Append( "NZ015=@NZ015," );
            strSql.Append( "NZ016=@NZ016," );
            strSql.Append( "NZ017=@NZ017," );
            strSql.Append( "NZ018=@NZ018," );
            strSql.Append( "NZ019=@NZ019" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@NZ002",SqlDbType.Int),
                new SqlParameter("@NZ003",SqlDbType.Int),
                new SqlParameter("@NZ004",SqlDbType.NVarChar,20),
                new SqlParameter("@NZ005",SqlDbType.Int),
                new SqlParameter("@NZ008",SqlDbType.Int),
                new SqlParameter("@NZ009",SqlDbType.Int),
                new SqlParameter("@NZ010",SqlDbType.Decimal,11),
                new SqlParameter("@NZ011",SqlDbType.Decimal,11),
                new SqlParameter("@NZ012",SqlDbType.Decimal,3),
                new SqlParameter("@NZ013",SqlDbType.Int),
                new SqlParameter("@NZ014",SqlDbType.Int),
                new SqlParameter("@NZ015",SqlDbType.Int),
                new SqlParameter("@NZ016",SqlDbType.Int),
                new SqlParameter("@NZ017",SqlDbType.Int),
                new SqlParameter("@NZ018",SqlDbType.Decimal,4),
                new SqlParameter("@NZ019",SqlDbType.Int),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = _model.NZ002;
            parameter[1].Value = _model.NZ003;
            parameter[2].Value = _model.NZ004;
            parameter[3].Value = _model.NZ005;
            parameter[4].Value = _model.NZ008;
            parameter[5].Value = _model.NZ009;
            parameter[6].Value = _model.NZ010;
            parameter[7].Value = _model.NZ011;
            parameter[8].Value = _model.NZ012;
            parameter[9].Value = _model.NZ013;
            parameter[10].Value = _model.NZ014;
            parameter[11].Value = _model.NZ015;
            parameter[12].Value = _model.NZ016;
            parameter[13].Value = _model.NZ017;
            parameter[14].Value = _model.NZ018;
            parameter[15].Value = _model.NZ019;
            parameter[16].Value = _model.IDX;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
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
        public bool Delete ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQNZ" );
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
        public DataTable GetDataTable ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,NZ002,NZ003,NZ004,NZ005,NZ006,NZ007,NZ008,NZ009,NZ010,NZ011,NZ012,NZ013,NZ014,NZ015,NZ016,NZ017,NZ018,NZ019,U0,U3,U9,U2,U8,U10,U11,U16 FROM R_PQNZ" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( " ORDER BY NZ003,NZ002 DESC,NZ004" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableExists ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT NZ020 FROM R_PQNZ" );
            strSql.Append( " WHERE NZ001=@NZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@NZ001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Insert ( MulaolaoLibrary.SailsPaymentTaxRefundAndElectricityBillLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQNZ SET " );
            strSql.Append( "NZ020=@NZ020," );
            strSql.Append( "NZ021=@NZ021" );
            strSql.Append( " WHERE NZ001=@NZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@NZ001",SqlDbType.NVarChar,20),
                new SqlParameter("@NZ020",SqlDbType.NVarChar,2000),
                new SqlParameter("@NZ021",SqlDbType.NVarChar,2000)
            };
            parameter[0].Value = _model.NZ001;
            parameter[1].Value = _model.NZ020;
            parameter[2].Value = _model.NZ021;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
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
            strSql.AppendFormat( "DELETE FROM R_PQNZ WHERE NZ001='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            StringBuilder strS = new StringBuilder( );
            strS.AppendFormat( "DELETE FROM R_REVIEWS WHERE RES06='{0}'" ,oddNum );
            SQLString.Add( strS.ToString( ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.SailsPaymentTaxRefundAndElectricityBillLibrary GetModel ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQNZ" );
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
        public MulaolaoLibrary.SailsPaymentTaxRefundAndElectricityBillLibrary GetModel ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQNZ" );
            strSql.Append( " WHERE NZ001=@NZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@NZ001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

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
        public MulaolaoLibrary.SailsPaymentTaxRefundAndElectricityBillLibrary GetDataRow ( DataRow row )
        {
            MulaolaoLibrary.SailsPaymentTaxRefundAndElectricityBillLibrary _model = new MulaolaoLibrary.SailsPaymentTaxRefundAndElectricityBillLibrary( );

            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    _model.IDX = int.Parse( row["idx"].ToString( ) );
                if ( row["NZ001"] != null && row["NZ001"].ToString( ) != "" )
                    _model.NZ001 = row["NZ001"].ToString( );
                if ( row["NZ002"] != null && row["NZ002"].ToString( ) != "" )
                    _model.NZ002 = int.Parse( row["NZ002"].ToString( ) );
                if ( row["NZ003"] != null && row["NZ003"].ToString( ) != "" )
                    _model.NZ003 = int.Parse( row["NZ003"].ToString( ) );
                if ( row["NZ004"] != null && row["NZ004"].ToString( ) != "" )
                    _model.NZ004 = row["NZ004"].ToString( );
                if ( row["NZ005"] != null && row["NZ005"].ToString( ) != "" )
                    _model.NZ005 = int.Parse( row["NZ005"].ToString( ) );
                if ( row["NZ008"] != null && row["NZ008"].ToString( ) != "" )
                    _model.NZ008 = int.Parse( row["NZ008"].ToString( ) );
                if ( row["NZ009"] != null && row["NZ009"].ToString( ) != "" )
                    _model.NZ009 = int.Parse( row["NZ009"].ToString( ) );
                if ( row["NZ010"] != null && row["NZ010"].ToString( ) != "" )
                    _model.NZ010 = decimal.Parse( row["NZ010"].ToString( ) );
                if ( row["NZ011"] != null && row["NZ011"].ToString( ) != "" )
                    _model.NZ011 = decimal.Parse( row["NZ011"].ToString( ) );
                if ( row["NZ012"] != null && row["NZ012"].ToString( ) != "" )
                    _model.NZ012 = decimal.Parse( row["NZ012"].ToString( ) );
                if ( row["NZ013"] != null && row["NZ013"].ToString( ) != "" )
                    _model.NZ013 = int.Parse( row["NZ013"].ToString( ) );
                if ( row["NZ014"] != null && row["NZ014"].ToString( ) != "" )
                    _model.NZ014 = int.Parse( row["NZ014"].ToString( ) );
                if ( row["NZ015"] != null && row["NZ015"].ToString( ) != "" )
                    _model.NZ015 = int.Parse( row["NZ015"].ToString( ) );
                if ( row["NZ016"] != null && row["NZ016"].ToString( ) != "" )
                    _model.NZ016 = int.Parse( row["NZ016"].ToString( ) );
                if ( row["NZ017"] != null && row["NZ017"].ToString( ) != "" )
                    _model.NZ017 = int.Parse( row["NZ017"].ToString( ) );
                if ( row["NZ018"] != null && row["NZ018"].ToString( ) != "" )
                    _model.NZ018 = decimal.Parse( row["NZ018"].ToString( ) );
                if ( row["NZ019"] != null && row["NZ019"].ToString( ) != "" )
                    _model.NZ019 = int.Parse( row["NZ019"].ToString( ) );
                if ( row["NZ020"] != null && row["NZ020"].ToString( ) != "" )
                    _model.NZ020 = row["NZ020"].ToString( );
                if ( row["NZ021"] != null && row["NZ021"].ToString( ) != "" )
                    _model.NZ021 = row["NZ021"].ToString( );
            }

            return _model;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT NZ002,NZ003,NZ001 FROM R_PQNZ" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM (SELECT DISTINCT NZ001,NZ002,NZ003 FROM R_PQNZ" );
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
            strSql.Append( "SELECT DISTINCT NZ001,NZ002,NZ003,(SELECT RES05 FROM R_REVIEWS WHERE RES04=(SELECT RES04 FROM R_REVIEWS WHERE NZ001=RES06)) RES05 FROM (" );
            strSql.Append( "SELECT ROW_NUMBER() OVER( " );
            strSql.Append( "ORDER BY T.NZ001 DESC" );
            strSql.Append( ") AS Row,T.* FROM R_PQNZ T" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") TT" );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 生成数据
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool AddOf ( MulaolaoLibrary . SailsPaymentTaxRefundAndElectricityBillLibrary _model )
        {
            //含税内销=250上没有美金单价的销售额,也就是只有人名币金额
            //自营出口销售额=250只有美金单价的销售额

            ArrayList SQLString = new ArrayList ( );
            DataTable da = new DataTable ( );
            da = GetDataTableOfSail ( _model . NZ002 );
            if ( da != null && da . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    _model . NZ002 = string . IsNullOrEmpty ( da . Rows [ i ] [ "AE141" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "AE141" ] . ToString ( ) );
                    _model . NZ003 = string . IsNullOrEmpty ( da . Rows [ i ] [ "AE142" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "AE142" ] . ToString ( ) );
                    _model . NZ004 = "订单R-250表额";
                    _model . NZ005 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U0" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "U0" ] . ToString ( ) );
                    _model . NZ008 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U1" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "U1" ] . ToString ( ) );
                    if ( Exists ( _model . NZ002 ,_model . NZ003 ,_model . NZ004 ) )
                        SQLString . Add ( UpdateOfSail ( _model ) );
                    else
                        SQLString . Add ( AddOfSail ( _model ) );
                }
            }

            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                SQLString = new ArrayList ( );
                da = new DataTable ( );
                da = GetDataTableOfBilli ( _model . NZ002 );
                if ( da != null && da . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < da . Rows . Count ; i++ )
                    {
                        _model . NZ002 = string . IsNullOrEmpty ( da . Rows [ i ] [ "AE141" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "AE141" ] . ToString ( ) );
                        _model . NZ003 = string . IsNullOrEmpty ( da . Rows [ i ] [ "AE142" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "AE142" ] . ToString ( ) );
                        _model . NZ004 = "开票.实交金额";
                        _model . NZ005 = string . IsNullOrEmpty ( da . Rows [ i ] [ "AE1" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "AE1" ] . ToString ( ) );
                        _model . NZ008 = string . IsNullOrEmpty ( da . Rows [ i ] [ "AE2" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "AE2" ] . ToString ( ) );
                        if ( Exists ( _model . NZ002 ,_model . NZ003 ,_model . NZ004 ) )
                            SQLString . Add ( UpdateOfSail ( _model ) );
                        else
                            SQLString . Add ( AddOfSail ( _model ) );
                    }
                }
            }
            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                SQLString = new ArrayList ( );
                _model . NZ002 = _model . NZ002 - 1;
                _model . NZ005 = _model . NZ008 = 0;
                _model . NZ004 = "收齐(申报)";
                for ( int i = 1 ; i < 13 ; i++ )
                {
                    _model . NZ003 = i;
                    if ( Exists ( _model . NZ002 ,_model . NZ003 ,_model . NZ004 ) )
                        SQLString . Add ( UpdateOfSail ( _model ) );
                    else
                        SQLString . Add ( AddOfSail ( _model ) );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 销售额
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfSail (int year )
        {
            //含税内销=250上没有美金单价的销售额,也就是只有人名币金额
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "WITH CET AS(" );
            strSql.Append( "SELECT S.* FROM ( SELECT *, row_number() over (partition by AE02 order by AE01) as GROUP_IDX FROM R_PQAE) S where S.GROUP_IDX = 1" );
            strSql.Append( " AND YEAR(AE14)=@YEAR)" );
            strSql.Append( ",CFT AS(" );
            //strSql.Append( "SELECT YEAR(AE14) AE141,MONTH(AE14) AE142,CONVERT(DECIMAL(18,0),SUM(CASE WHEN AE10!=0 THEN AE10*AE11*AE06 ELSE 0 END)) U0,CONVERT(DECIMAL(18,0),SUM(CASE WHEN AE10=0 THEN AE12*AE06 ELSE 0 END)) U1 FROM CET GROUP BY AE02,YEAR(AE14),MONTH(AE14))" );
            //strSql.Append( "SELECT AE141,AE142,SUM(U0) U0,SUM(ISNULL(U1,0)) U1 FROM CFT GROUP BY AE141,AE142 ORDER BY AE142" );
            //AE10*AE11*AE06 ELSE   AE12*AE06
            strSql . Append ( "SELECT YEAR(AE14) AE141,MONTH(AE14) AE142,CONVERT(DECIMAL(18,0),SUM(CASE WHEN ISNULL(AE11,0)=0 THEN 0 ELSE AE10*ISNULL(AE11,0)*AE06 END)) U0,CONVERT(DECIMAL(18,0),SUM(CASE WHEN ISNULL(AE11,0)=0 THEN AE12*AE06 ELSE 0 END)) U1 FROM CET GROUP BY AE02,YEAR(AE14),MONTH(AE14))" );
            strSql . Append ( " SELECT AE141,AE142,SUM(U0) U0,SUM(U1) U1 FROM CFT GROUP BY AE141,AE142 ORDER BY AE142" );
            SqlParameter[] parameter = {
                new SqlParameter("@YEAR",SqlDbType.Int)
            };
            parameter[0].Value = year;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 开票额
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfBilli ( int year )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "WITH CGT AS(" );
            //strSql.Append( "SELECT YEAR(AE23) AE141,MONTH(AE23) AE142,CONVERT(DECIMAL(18,0),SUM(CASE WHEN ISNULL(AE39,0)!=0 THEN ISNULL(AE39,0)*ISNULL(AE10,0)*ISNULL(AE26,0) ELSE 0 END)) AE1,CONVERT(DECIMAL(18,0),SUM(CASE WHEN ISNULL(AE39,0)=0 THEN ISNULL(AE12,0)*ISNULL(AE26,0) ELSE 0 END)) AE2 FROM R_PQAE WHERE YEAR(AE23)=@YEAR" );     ISNULL(AE12,0)*ISNULL(AE26,0)
            strSql . Append ( "SELECT YEAR(AE23) AE141,MONTH(AE23) AE142,CONVERT(DECIMAL(18,0),SUM(CASE WHEN ISNULL(AE39,0)=0 THEN 0 ELSE ISNULL(AE39,0)*ISNULL(AE10,0)*ISNULL(AE26,0) END)) AE1,CONVERT(DECIMAL(18,0),SUM(CASE WHEN ISNULL(AE39,0)=0 THEN ISNULL(AE12,0)*ISNULL(AE26,0) ELSE 0 END)) AE2 FROM R_PQAE" );
            strSql . Append ( " WHERE YEAR(AE23)=@YEAR" );
            strSql.Append( " GROUP BY YEAR(AE23),MONTH(AE23))" );
            //strSql.Append( "SELECT AE141,AE142,SUM(AE1) AE1,SUM(AE2) AE2 FROM CGT GROUP BY AE141,AE142 ORDER BY AE142" );
            strSql . Append ( " SELECT AE141,AE142,SUM(AE1) AE1,SUM(AE2) AE2 FROM CGT GROUP BY AE141,AE142 ORDER BY AE142" );
            SqlParameter[] parameter = {
                new SqlParameter("@YEAR",SqlDbType.Int)
            };
            parameter[0].Value = year;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        public string AddOfSail ( MulaolaoLibrary.SailsPaymentTaxRefundAndElectricityBillLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQNZ (" );
            strSql.Append( "NZ001,NZ002,NZ003,NZ004,NZ005,NZ008)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}','{4}','{5}')" ,_model.NZ001 ,_model.NZ002 ,_model.NZ003 ,_model.NZ004 ,_model.NZ005 ,_model.NZ008 );

            return strSql.ToString( );
        }
        public string UpdateOfSail ( MulaolaoLibrary.SailsPaymentTaxRefundAndElectricityBillLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQNZ SET " );
            strSql.AppendFormat( "NZ005='{0}'," ,_model.NZ005 );
            strSql.AppendFormat( "NZ008='{0}'" ,_model.NZ008 );
            strSql . AppendFormat ( " WHERE NZ002='{0}' AND NZ003='{1}' AND NZ004='{2}'" ,_model . NZ002 ,_model . NZ003 ,_model . NZ004 );

            return strSql.ToString( );
        }
        

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfOddNum ( int year )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT NZ001 FROM R_PQNZ" );
            strSql.Append( " WHERE NZ002=@NZ002 AND NZ004='订单R-250表额'" );
            SqlParameter[] parameter = {
                new SqlParameter("@NZ002",SqlDbType.Int)
            };
            parameter[0].Value = year;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
    }
}

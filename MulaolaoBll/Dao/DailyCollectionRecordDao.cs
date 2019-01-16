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
    public class DailyCollectionRecordDao
    {
        MulaolaoLibrary.DailyCollectionRecordLibrary model = new MulaolaoLibrary.DailyCollectionRecordLibrary( );

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Exists ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQAE" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = idx;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool GetExists ( MulaolaoLibrary.DailyCollectionRecordLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQAE" );
            strSql.Append( " WHERE AE02=@AE02" );

            SqlParameter[] parameter = {
                new SqlParameter("@AE02",SqlDbType.NVarChar)
            };

            parameter[0].Value = model.AE02;

            int idx = SqlHelper.ExecuteSqlReturnId( strSql.ToString( ) ,parameter );
            if ( idx > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add ( MulaolaoLibrary.DailyCollectionRecordLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "INSERT INTO R_PQAE (" );
            strSql.Append( "AE01,AE02,AE03,AE04,AE05,AE06,AE07,AE08,AE09,AE10,AE11,AE12,AE13,AE14,AE15,AE16,AE17,AE18,AE19,AE20,AE26,AE27,AE28,AE29,AE30,AE31,AE33,AE34,AE35,AE36,AE37,AE38,AE39,AE40,AE41,AE42,AE43)" );
            strSql .Append( "VALUES (@AE01,@AE02,@AE03,@AE04,@AE05,@AE06,@AE07,@AE08,@AE09,@AE10,@AE11,@AE12,@AE13,@AE14,@AE15,@AE16,@AE17,@AE18,@AE19,@AE20,@AE26,@AE27,@AE28,@AE29,@AE30,@AE31,@AE33,@AE34,@AE35,@AE36,@AE37,@AE38,@AE39,@AE40,@AE41,@AE42,@AE43);" );
            strSql .Append( "SELECT SCOPE_IDENTITY();" );
            SqlParameter[] parameter = {
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
                new SqlParameter("@AE20",SqlDbType.Decimal),
                new SqlParameter("@AE26",SqlDbType.Int),
                new SqlParameter("@AE27",SqlDbType.Decimal),
                new SqlParameter("@AE28",SqlDbType.Decimal),
                new SqlParameter("@AE29",SqlDbType.Decimal),
                new SqlParameter("@AE30",SqlDbType.Decimal),
                new SqlParameter("@AE31",SqlDbType.Decimal),
                new SqlParameter("@AE33",SqlDbType.Decimal),
                new SqlParameter("@AE34",SqlDbType.Decimal),
                new SqlParameter("@AE35",SqlDbType.NVarChar),
                new SqlParameter("@AE36",SqlDbType.NVarChar),
                new SqlParameter("@AE37",SqlDbType.BigInt),
                new SqlParameter("@AE38",SqlDbType.BigInt),
                new SqlParameter("@AE39",SqlDbType.Decimal,11),
                new SqlParameter("@AE40",SqlDbType.Decimal,11),
                new SqlParameter("@AE41",SqlDbType.Decimal,11),
                new SqlParameter("@AE42",SqlDbType.Decimal,11),
                new SqlParameter("@AE43",SqlDbType.Decimal,11)
            };
            parameter[0].Value = model.AE01;
            parameter[1].Value = model.AE02;
            parameter[2].Value = model.AE03;
            parameter[3].Value = model.AE04;
            parameter[4].Value = model.AE05;
            parameter[5].Value = model.AE06;
            parameter[6].Value = model.AE07;
            parameter[7].Value = model.AE08;
            parameter[8].Value = model.AE09;
            parameter[9].Value = model.AE10;
            parameter[10].Value = model.AE11;
            parameter[11].Value = model.AE12;
            parameter[12].Value = model.AE13;
            parameter[13].Value = model.AE14;
            parameter[14].Value = model.AE15;
            parameter[15].Value = model.AE16;
            parameter[16].Value = model.AE17;
            parameter[17].Value = model.AE18;
            parameter[18].Value = model.AE19;
            parameter[19].Value = model.AE20;
            parameter[20].Value = model.AE26;
            parameter[21].Value = model.AE27;
            parameter[22].Value = model.AE28;
            parameter[23].Value = model.AE29;
            parameter[24].Value = model.AE30;
            parameter[25].Value = model.AE31;
            parameter[26].Value = model.AE33;
            parameter[27].Value = model.AE34;
            parameter[28].Value = model.AE35;
            parameter[29].Value = model.AE36;
            parameter[30].Value = model.AE37;
            parameter[31].Value = model.AE38;
            parameter[32].Value = model.AE39;
            parameter[33].Value = model.AE40;
            parameter[34].Value = model.AE41;
            parameter [ 35 ] . Value = model . AE42;
            parameter [ 36 ] . Value = model . AE43;

            int idx = SqlHelper.ExecuteSqlReturnId( strSql.ToString( ) ,parameter );
            if ( idx > 0 )
            {
                ArrayList SQLString = new ArrayList( );
                StringBuilder strS21 = new StringBuilder( );
                if ( model.AE21 == null )
                    strS21.AppendFormat( "UPDATE R_PQAE SET AE21=NULL WHERE idx='{0}'" ,idx );
                else
                    strS21.AppendFormat( "UPDATE R_PQAE SET AE21='{0}' WHERE idx='{1}'" ,model.AE21 ,idx );
                SQLString.Add( strS21.ToString( ) );
                StringBuilder strS22 = new StringBuilder( );
                if ( model.AE22 == null )
                    strS22.AppendFormat( "UPDATE R_PQAE SET AE22=NULL WHERE idx='{0}'" ,idx );
                else
                    strS22.AppendFormat( "UPDATE R_PQAE SET AE22='{0}' WHERE idx='{1}'" ,model.AE22 ,idx );
                SQLString.Add( strS22.ToString( ) );
                StringBuilder strS23 = new StringBuilder( );
                if ( model.AE23 == null )
                    strS23.AppendFormat( "UPDATE R_PQAE SET AE23=NULL WHERE idx='{0}'" ,idx );
                else
                    strS23.AppendFormat( "UPDATE R_PQAE SET AE23='{0}' WHERE idx='{1}'" ,model.AE23 ,idx );
                SQLString.Add( strS23.ToString( ) );
                StringBuilder strS24 = new StringBuilder( );
                if ( model.AE24 == null )
                    strS24.AppendFormat( "UPDATE R_PQAE SET AE24=NULL WHERE idx='{0}'" ,idx );
                else
                    strS24.AppendFormat( "UPDATE R_PQAE SET AE24='{0}' WHERE idx='{1}'" ,model.AE24 ,idx );
                SQLString.Add( strS24.ToString( ) );
                StringBuilder strS32 = new StringBuilder( );
                if ( model.AE32 == null )
                    strS32.AppendFormat( "UPDATE R_PQAE SET AE32=NULL WHERE idx='{0}'" ,idx );
                else
                    strS32.AppendFormat( "UPDATE R_PQAE SET AE32='{0}' WHERE idx='{1}'" ,model.AE32 ,idx );
                SQLString.Add( strS32.ToString( ) );

                if ( SqlHelper.ExecuteSqlTran( SQLString ) == true )
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        public bool Adds ( MulaolaoLibrary.DailyCollectionRecordLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "INSERT INTO R_PQAE (" );
            strSql.Append( "AE01,AE02,AE03,AE04,AE05,AE06,AE07,AE08,AE09,AE10,AE11,AE12,AE13,AE14,AE15,AE16,AE17,AE18,AE19,AE20)" );
            strSql.Append( "VALUES (@AE01,@AE02,@AE03,@AE04,@AE05,@AE06,@AE07,@AE08,@AE09,@AE10,@AE11,@AE12,@AE13,@AE14,@AE15,@AE16,@AE17,@AE18,@AE19,@AE20);" );
            strSql.Append( "SELECT SCOPE_IDENTITY();" );
            SqlParameter[] parameter = {
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
            parameter[0].Value = model.AE01;
            parameter[1].Value = model.AE02;
            parameter[2].Value = model.AE03;
            parameter[3].Value = model.AE04;
            parameter[4].Value = model.AE05;
            parameter[5].Value = model.AE06;
            parameter[6].Value = model.AE07;
            parameter[7].Value = model.AE08;
            parameter[8].Value = model.AE09;
            parameter[9].Value = model.AE10;
            parameter[10].Value = model.AE11;
            parameter[11].Value = model.AE12;
            parameter[12].Value = model.AE13;
            parameter[13].Value = model.AE14;
            parameter[14].Value = model.AE15;
            parameter[15].Value = model.AE16;
            parameter[16].Value = model.AE17;
            parameter[17].Value = model.AE18;
            parameter[18].Value = model.AE19;
            parameter[19].Value = model.AE20;


            int idx = SqlHelper.ExecuteSqlReturnId( strSql.ToString( ) ,parameter );
            if ( idx > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Updata ( MulaolaoLibrary.DailyCollectionRecordLibrary model )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "UPDATE R_PQAE SET " );
            //strSql.AppendFormat( "AE01='{0}'," ,model.AE01 );
            strSql.AppendFormat( "AE02='{0}'," ,model.AE02 );
            strSql.AppendFormat( "AE03='{0}'," ,model.AE03 );
            strSql.AppendFormat( "AE04='{0}'," ,model.AE04 );
            strSql.AppendFormat( "AE05='{0}'," ,model.AE05 );
            strSql.AppendFormat( "AE06='{0}'," ,model.AE06 );
            strSql.AppendFormat( "AE07='{0}'," ,model.AE07 );
            strSql.AppendFormat( "AE08='{0}'," ,model.AE08 );
            strSql.AppendFormat( "AE09='{0}'," ,model.AE09 );
            strSql.AppendFormat( "AE10='{0}'," ,model.AE10 );
            strSql.AppendFormat( "AE11='{0}'," ,model.AE11 );
            strSql.AppendFormat( "AE12='{0}'," ,model.AE12 );
            strSql.AppendFormat( "AE13='{0}'," ,model.AE13 );
            strSql.AppendFormat( "AE14='{0}'," ,model.AE14 );
            strSql.AppendFormat( "AE15='{0}'," ,model.AE15 );
            strSql.AppendFormat( "AE16='{0}'," ,model.AE16 );
            strSql.AppendFormat( "AE17='{0}'," ,model.AE17 );
            strSql.AppendFormat( "AE18='{0}'," ,model.AE18 );
            strSql.AppendFormat( "AE19='{0}'," ,model.AE19 );
            strSql.AppendFormat( "AE20='{0}'," ,model.AE20 );
            strSql.AppendFormat( "AE26='{0}'," ,model.AE26 );
            strSql.AppendFormat( "AE27='{0}'," ,model.AE27 );
            strSql.AppendFormat( "AE28='{0}'," ,model.AE28 );
            strSql.AppendFormat( "AE29='{0}'," ,model.AE29 );
            strSql.AppendFormat( "AE30='{0}'," ,model.AE30 );
            strSql.AppendFormat( "AE31='{0}'," ,model.AE31 );
            strSql.AppendFormat( "AE32='{0}'," ,model.AE32 );
            strSql.AppendFormat( "AE33='{0}'," ,model.AE33 );
            strSql.AppendFormat( "AE34='{0}'," ,model.AE34 );
            strSql.AppendFormat( "AE35='{0}'," ,model.AE35 );
            strSql.AppendFormat( "AE36='{0}'," ,model.AE36 );
            strSql.AppendFormat( "AE37='{0}'," ,model.AE37 );
            strSql.AppendFormat( "AE38='{0}'," ,model.AE38 );
            strSql.AppendFormat( "AE39='{0}'," ,model.AE39 );
            strSql.AppendFormat( "AE40='{0}'," ,model.AE40 );
            strSql.AppendFormat( "AE41='{0}'," ,model.AE41 );
            strSql . AppendFormat ( "AE42='{0}'," ,model . AE42 );
            strSql . AppendFormat ( "AE43='{0}'" ,model . AE43 );
            strSql .AppendFormat( " WHERE idx='{0}'" ,model.Idx );

            SQLString.Add( strSql.ToString( ) );

            StringBuilder strSA21 = new StringBuilder( );
            if ( model.AE21 == null )
                strSA21.AppendFormat( "UPDATE R_PQAE SET AE21=NULL WHERE idx='{0}'" ,model.Idx );
            else
                strSA21.AppendFormat( "UPDATE R_PQAE SET AE21='{0}' WHERE idx='{1}'" ,model.AE21 ,model.Idx );
            SQLString.Add( strSA21.ToString( ) );
            StringBuilder strSA22 = new StringBuilder( );
            if ( model.AE22 == null )
                strSA22.AppendFormat( "UPDATE R_PQAE SET AE22=NULL WHERE idx='{0}'" ,model.Idx );
            else
                strSA22.AppendFormat( "UPDATE R_PQAE SET AE22='{0}' WHERE idx='{1}'" ,model.AE22 ,model.Idx );
            SQLString.Add( strSA22.ToString( ) );
            StringBuilder strSA23 = new StringBuilder( );
            if ( model.AE23 == null )
                strSA23.AppendFormat( "UPDATE R_PQAE SET AE23=NULL WHERE idx='{0}'" ,model.Idx );
            else
                strSA23.AppendFormat( "UPDATE R_PQAE SET AE23='{0}' WHERE idx='{1}'" ,model.AE23 ,model.Idx );
            SQLString.Add( strSA23.ToString( ) );
            StringBuilder strSA24 = new StringBuilder( );
            if ( model.AE24 == null )
                strSA24.AppendFormat( "UPDATE R_PQAE SET AE24=NULL WHERE idx='{0}'" ,model.Idx );
            else
                strSA24.AppendFormat( "UPDATE R_PQAE SET AE24='{0}' WHERE idx='{1}'" ,model.AE24 ,model.Idx );
            SQLString.Add( strSA24.ToString( ) );
            StringBuilder strSA32 = new StringBuilder( );
            if ( model.AE32 == null )
                strSA32.AppendFormat( "UPDATE R_PQAE SET AE32=NULL WHERE idx='{0}'" ,model.Idx );
            else
                strSA32.AppendFormat( "UPDATE R_PQAE SET AE32='{0}' WHERE idx='{1}'" ,model.AE32 ,model.Idx );
            SQLString.Add( strSA32.ToString( ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        public bool Updatas ( MulaolaoLibrary.DailyCollectionRecordLibrary model )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "UPDATE R_PQAE SET " );
            strSql.AppendFormat( "AE03='{0}'," ,model.AE03 );
            strSql.AppendFormat( "AE04='{0}'," ,model.AE04 );
            strSql.AppendFormat( "AE05='{0}'," ,model.AE05 );
            strSql.AppendFormat( "AE06='{0}'," ,model.AE06 );
            strSql.AppendFormat( "AE07='{0}'," ,model.AE07 );
            strSql.AppendFormat( "AE08='{0}'," ,model.AE08 );
            strSql.AppendFormat( "AE09='{0}'," ,model.AE09 );
            strSql.AppendFormat( "AE10='{0}'," ,model.AE10 );
            strSql.AppendFormat( "AE11='{0}'," ,model.AE11 );
            strSql.AppendFormat( "AE12='{0}'," ,model.AE12 );
            strSql.AppendFormat( "AE13='{0}'," ,model.AE13 );
            strSql.AppendFormat( "AE14='{0}'," ,model.AE14 );
            strSql.AppendFormat( "AE15='{0}'," ,model.AE15 );
            strSql.AppendFormat( "AE16='{0}'," ,model.AE16 );
            strSql.AppendFormat( "AE17='{0}'," ,model.AE17 );
            strSql.AppendFormat( "AE18='{0}'," ,model.AE18 );
            strSql.AppendFormat( "AE19='{0}'," ,model.AE19 );
            strSql.AppendFormat( "AE20='{0}'" ,model.AE20 );
            strSql.AppendFormat( " WHERE AE02='{0}'" ,model.AE02 );
            SQLString.Add( strSql.ToString( ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete ( MulaolaoLibrary.DailyCollectionRecordLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQAE " );
            strSql.Append( "WHERE idx=@idx" );

            SqlParameter[] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = model.Idx;

            int rows = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( rows > 0 )
                return true;
            else
                return false;
        }


        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public bool DeleteList ( string idList )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQAE " );
            strSql.Append( "WHERE idx IN (" + idList + ")" );

            int rows = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( rows > 0 )
                return true;
            else
                return false;
        }


        /// <summary>
        /// 得到一个数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql . Append ( "WITH CET AS(" );
            strSql.Append( "SELECT idx,AE01,AE02,AE03,AE04,AE05,AE06,AE07,AE08,AE09,AE10,AE11,AE12,AE13,AE14,AE15,AE16,AE17,AE18,AE19,AE20,AE21,AE22,AE23,AE24,AE26,AE27,AE28,AE29,AE30,AE31,AE32,AE33,AE34,AE35,AE36,AE37,AE38,ISNULL(AE39,0) AE39,AE40,AE41,AE42,AE43,U0,U7,DATEDIFF( DAY ,AE15 ,AE14 )+3 U2,DATEDIFF( DAY ,AE21 ,AE17 ) U3,DATEDIFF( DAY ,AE21 ,AE23 )+15 U4,DATEDIFF( DAY,AE22 ,AE18) U5,U11 FROM R_PQAE" );
            strSql . Append ( "),CFT AS(" );
            strSql . Append ( "SELECT AE02,MAX(idx) idx,SUM(ISNULL(AE12,0)*ISNULL(AE37,0))-SUM(ISNULL(AE28,0))-SUM(ISNULL(AE30,0))-SUM(ISNULL(AE29,0)*ISNULL(AE11,0))+SUM(ISNULL(AE41,0)) U12,SUM(CONVERT(DECIMAL(18,0),CASE WHEN AE39!=0 AND AE39 IS NOT NULL THEN ISNULL(AE26,0)*ISNULL(AE39,0)*ISNULL(AE10,0) ELSE ISNULL(AE12,0)*ISNULL(AE26,0) END))-SUM(ISNULL(AE28,0))-SUM(ISNULL(AE30,0))-SUM(ISNULL(AE29,0))+SUM(ISNULL(AE40,0)) U13,AE19-SUM(ISNULL(AE30,0))-SUM(ISNULL(AE27,0))-SUM(ISNULL(AE28,0))-SUM(ISNULL(AE29,0))-SUM(ISNULL(AE42,0)) U11 FROM R_PQAE " );
            strSql . Append ( " GROUP BY AE02,AE19)" );
            strSql . Append ( "SELECT A.*,B.U12,B.U13 FROM CET A LEFT JOIN CFT B ON A.idx=B.idx AND A.AE02=B.AE02 " );
            if ( !string . IsNullOrEmpty ( strWhere ) )
            {
                strSql . Append ( " WHERE " + strWhere );
            }
            

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            return da;
        }
        public DataTable GetDataTableTwo ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AE07,AE02,AE03,AE08,AE09,AE05,AE04,AE06,SUM(ISNULL(AE37,0)) AE37,SUM(ISNULL(AE38,0)) AE38,SUM(ISNULL(AE26,0)) AE26,CONVERT(DECIMAL(18,0),SUM(ISNULL(AE12,0)*ISNULL(AE37,0))) U21,AE12,AE10,AE11,CONVERT(DECIMAL(18,0),SUM(ISNULL(AE27,0))) AE27,CONVERT(DECIMAL(18,0),SUM(ISNULL(AE29,0))) AE29,CONVERT(DECIMAL(18,0),SUM(ISNULL(AE30,0))) AE30,CONVERT(DECIMAL(18,0),SUM(ISNULL(AE28,0))) AE28,CONVERT(DECIMAL(18,0),SUM(ISNULL(AE31,0))) AE31,CONVERT(DECIMAL(18,0),SUM(ISNULL(AE33,0))) AE33,CONVERT(DECIMAL(18,0),SUM(ISNULL(AE34,0))) AE34,CONVERT(DECIMAL(18,0),SUM(CASE WHEN AE39!=0 AND AE39 IS NOT NULL THEN ISNULL(AE26,0)*ISNULL(AE39,0)*ISNULL(AE10,0) ELSE ISNULL(AE12,0)*ISNULL(AE26,0) END)) U20,SUM(ISNULL(AE29,0)*ISNULL(AE11,0)) U8,AE19,SUM(ISNULL(AE40,0)) AE40,SUM(ISNULL(AE41,0)) AE41,SUM(ISNULL(AE42,0)) AE42,MAX(AE21) AE21,MAX(AE22) AE22,MAX(AE23) AE23,AE14,AE15,MAX(AE16) AE16,AE17 FROM R_PQAE A " );
            strSql . Append ( "WHERE " + strWhere );
            strSql . Append ( " GROUP BY AE07,AE02,AE03,AE08,AE09,AE05,AE04,AE06,AE12,AE10,AE11,AE19,AE14,AE15,AE17 ORDER BY AE02" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.DailyCollectionRecordLibrary GetModel ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,AE01,AE02,AE03,AE04,AE05,AE06,AE07,AE08,AE09,AE10,AE11,AE12,AE13,AE14,AE15,AE16,AE17,AE18,AE19,AE20,AE21,AE22,AE23,AE24,AE26,AE27,AE28,AE29,AE30,AE31,AE32,AE33,AE34,AE35,AE36,AE37,AE38,AE39,AE40,AE41,AE42,AE43 FROM R_PQAE" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = idx;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da.Rows.Count > 0 )
                return DataRowModel( da.Rows[0] );
            else
                return null;
        }

        
        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.DailyCollectionRecordLibrary DataRowModel ( DataRow row )
        {
            MulaolaoLibrary.DailyCollectionRecordLibrary model = new MulaolaoLibrary.DailyCollectionRecordLibrary( );
            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    model.Idx = int.Parse( row["idx"].ToString( ) );
                if ( row["AE01"] != null && row["AE01"].ToString( ) != "" )
                    model.AE01 = row["AE01"].ToString( );
                if ( row["AE02"] != null && row["AE02"].ToString( ) != "" )
                    model.AE02 = row["AE02"].ToString( );
                if ( row["AE03"] != null && row["AE03"].ToString( ) != "" )
                    model.AE03 = row["AE03"].ToString( );
                if ( row["AE04"] != null && row["AE04"].ToString( ) != "" )
                    model.AE04 = row["AE04"].ToString( );
                if ( row["AE05"] != null && row["AE05"].ToString( ) != "" )
                    model.AE05 = row["AE05"].ToString( );
                if ( row["AE06"] != null && row["AE06"].ToString( ) != "" )
                    model.AE06 = Convert.ToInt64( row["AE06"].ToString( ) );
                if ( row["AE07"] != null && row["AE07"].ToString( ) != "" )
                    model.AE07 = row["AE07"].ToString( );
                if ( row["AE08"] != null && row["AE08"].ToString( ) != "" )
                    model.AE08 = row["AE08"].ToString( );
                if ( row["AE09"] != null && row["AE09"].ToString( ) != "" )
                    model.AE09 = row["AE09"].ToString( );
                if ( row["AE10"] != null && row["AE10"].ToString( ) != "" )
                    model.AE10 = Convert.ToDecimal( row["AE10"].ToString( ) );
                if ( row["AE11"] != null && row["AE11"].ToString( ) != "" )
                    model.AE11 = Convert.ToDecimal( row["AE11"].ToString( ) );
                if ( row["AE12"] != null && row["AE12"].ToString( ) != "" )
                    model.AE12 = Convert.ToDecimal( row["AE12"].ToString( ) );
                if ( row["AE13"] != null && row["AE13"].ToString( ) != "" )
                    model.AE13 = row["AE13"].ToString( );
                if ( row["AE14"] != null && row["AE14"].ToString( ) != "" )
                    model.AE14 = DateTime.Parse( row["AE14"].ToString( ) );
                if ( row["AE15"] != null && row["AE15"].ToString( ) != "" )
                    model.AE15 = Convert.ToDateTime( row["AE15"].ToString( ) );
                if ( row["AE16"] != null && row["AE16"].ToString( ) != "" )
                    model.AE16 = Convert.ToDateTime( row["AE16"].ToString( ) );
                if ( row["AE17"] != null && row["AE17"].ToString( ) != "" )
                    model.AE17 = Convert.ToDateTime( row["AE17"].ToString( ) );
                if ( row["AE18"] != null && row["AE18"].ToString( ) != "" )
                    model.AE18 = Convert.ToDateTime( row["AE18"].ToString( ) );
                if ( row["AE19"] != null && row["AE19"].ToString( ) != "" )
                    model.AE19 = Convert.ToDecimal( row["AE19"].ToString( ) );
                if ( row["AE20"] != null && row["AE20"].ToString( ) != "" )
                    model.AE20 = Convert.ToDecimal( row["AE20"].ToString( ) );
                if ( row["AE21"] != null && row["AE21"].ToString( ) != "" )
                    model.AE21 = Convert.ToDateTime( row["AE21"].ToString( ) );
                if ( row["AE22"] != null && row["AE22"].ToString( ) != "" )
                    model.AE22 = Convert.ToDateTime( row["AE22"].ToString( ) );
                if ( row["AE23"] != null && row["AE23"].ToString( ) != "" )
                    model.AE23 = Convert.ToDateTime( row["AE23"].ToString( ) );
                if ( row["AE24"] != null && row["AE24"].ToString( ) != "" )
                    model.AE24 = Convert.ToDateTime( row["AE24"].ToString( ) );
                if ( row["AE26"] != null && row["AE26"].ToString( ) != "" )
                    model.AE26 = Convert.ToInt32( row["AE26"].ToString( ) );
                if ( row["AE27"] != null && row["AE27"].ToString( ) != "" )
                    model.AE27 = Convert.ToDecimal( row["AE27"].ToString( ) );
                if ( row["AE28"] != null && row["AE28"].ToString( ) != "" )
                    model.AE28 = Convert.ToDecimal( row["AE28"].ToString( ) );
                if ( row["AE29"] != null && row["AE29"].ToString( ) != "" )
                    model.AE29 = Convert.ToDecimal( row["AE29"].ToString( ) );
                if ( row["AE30"] != null && row["AE30"].ToString( ) != "" )
                    model.AE30 = Convert.ToDecimal( row["AE30"].ToString( ) );
                if ( row["AE31"] != null && row["AE31"].ToString( ) != "" )
                    model.AE31 = Convert.ToDecimal( row["AE31"].ToString( ) );
                if ( row["AE32"] != null && row["AE32"].ToString( ) != "" )
                    model.AE32 = DateTime.Parse( row["AE32"].ToString( ) );
                if ( row["AE33"] != null && row["AE33"].ToString( ) != "" )
                    model.AE33 = Convert.ToDecimal( row["AE33"].ToString( ) );
                if ( row["AE34"] != null && row["AE34"].ToString( ) != "" )
                    model.AE34 = Convert.ToDecimal( row["AE34"].ToString( ) );
                if ( row["AE35"] != null && row["AE35"].ToString( ) != "" )
                    model.AE35 = row["AE35"].ToString( );
                if ( row["AE36"] != null && row["AE36"].ToString( ) != "" )
                    model.AE36 = row["AE36"].ToString( );
                if ( row["AE37"] != null && row["AE37"].ToString( ) != "" )
                    model.AE37 = Convert.ToInt64( row["AE37"].ToString( ) );
                if ( row["AE38"] != null && row["AE38"].ToString( ) != "" )
                    model.AE38 = Convert.ToInt64( row["AE38"].ToString( ) );
                if ( row["AE39"] != null && row["AE39"].ToString( ) != "" )
                    model.AE39 = Convert.ToDecimal( row["AE39"].ToString( ) );
                if ( row["AE40"] != null && row["AE40"].ToString( ) != "" )
                    model.AE40 = Convert.ToDecimal( row["AE40"].ToString( ) );
                if ( row["AE41"] != null && row["AE41"].ToString( ) != "" )
                    model.AE41 = Convert.ToDecimal( row["AE41"].ToString( ) );
                if ( row [ "AE42" ] != null && row [ "AE42" ] . ToString ( ) != "" )
                    model . AE42 = Convert . ToDecimal ( row [ "AE42" ] . ToString ( ) );
                if ( row [ "AE43" ] != null && row [ "AE43" ] . ToString ( ) != "" )
                    model . AE43 = Convert . ToDecimal ( row [ "AE43" ] . ToString ( ) );
            }

            return model;
        }


        /// <summary>
        /// 是否执行
        /// </summary>
        /// <param name="model"></param>
        /// <param name="formText"></param>
        /// <returns></returns>
        public bool GetReview (MulaolaoLibrary.DailyCollectionRecordLibrary model,string formText )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_REVIEWS A,R_MLLCXMC B WHERE A.RES01=B.CX01 AND RES05='执行'" );
            strSql.Append( " AND RES06=@RES06 AND CX02=@CX02 " );

            SqlParameter[] parameter = {
                new SqlParameter("@RES06",SqlDbType.NVarChar),
                new SqlParameter("@CX02",SqlDbType.NVarChar)
            };

            parameter[0].Value = model.AE01;
            parameter[1].Value = formText;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da.Rows.Count > 0 )
                return true;
            else
                return false;
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="PQF01"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqf ( string PQF01 )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT PQF01,PQF02,PQF03,PQF04,PQF06,PQF10,(SELECT DFA003 FROM TPADFA WHERE PQF11=DFA001) DFA003,(SELECT DAA002 FROM TPADAA WHERE DAA001 = PQF17) DAA002,(SELECT DBA002 FROM TPADBA WHERE DBA001 = PQF12) DBA002,PQF10,PQF45,PQF09,PQF23,PQF13,CONVERT(VARCHAR(100), (SELECT RES04 FROM R_REVIEWS B WHERE A.PQF01=B.RES06 AND RES05='执行'),23) RES4,CONVERT(VARCHAR(100),(SELECT RES04 FROM R_PQL C,R_REVIEWS D WHERE A.PQF02=C.HT02 AND C.HT64=D.RES06 AND C.HT01=A.PQF01 AND RES05='执行'),23) RES04,PQF31,PQF34 FROM R_PQF A" );
            strSql.Append( " WHERE PQF01=@PQF01" );
            SqlParameter[] parameter = {
                new SqlParameter("@PQF01",SqlDbType.NVarChar)
            };

            parameter[0].Value = PQF01;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }


        /// <summary>
        /// 获取数据列表  单个字段
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableAll ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT AE01,AE02,AE03,AE04,AE05,AE07,AE08,AE09 FROM R_PQAE" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetDailyCollectionRecordCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQAE" );
            if ( !string.IsNullOrEmpty( strWhere ) )
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
        /// 分页获取数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTableByChange ( string strWhere ,string orderby ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,AE01,AE02,AE03,AE04,AE05,AE07,AE08,AE09,(SELECT RES05 FROM R_REVIEWS WHERE RES04=(SELECT MAX(RES04) FROM R_REVIEWS WHERE RES06=AE01)) RES05 FROM (" );
            strSql.Append( " SELECT ROW_NUMBER() OVER(" );
            if ( !string.IsNullOrEmpty( orderby.Trim() ) )
            {
                strSql.Append( " ORDER BY T." + orderby );
            }
            else
            {
                strSql.Append( " ORDER BY T.idx DESC" );
            }
            strSql.Append( ") AS Row,T.* FROM R_PQAE T" );
            if ( !string.IsNullOrEmpty( strWhere.Trim( ) ) )
            {
                strSql.Append( " WHERE " + strWhere );
            }
            strSql.Append( " ) TT" );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取所有已经执行的流水号
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT PQF01,PQF02,PQF03,PQF04,PQF06,PQF10,DFA003,DAA002,DBA002,PQF10,PQF45,PQF09,PQF23,PQF13,CONVERT(VARCHAR(100), (SELECT RES04 FROM R_REVIEWS B WHERE A.PQF01=B.RES06 AND RES05='执行'),23) RES4,CONVERT(VARCHAR(20),B.RES04,23) RES04,PQF31,PQF34,CONVERT(DECIMAL(18,2),CASE WHEN PQF09=0 THEN PQF10*PQF45*PQF06 ELSE PQF09*PQF06 END) AE19,PQF46 AE20 FROM R_PQF A LEFT JOIN TPADFA ON PQF11  = DFA001 LEFT JOIN TPADAA ON DAA001 = PQF17 LEFT JOIN TPADBA ON DBA001 = PQF12 INNER JOIN R_REVIEWS ON PQF01=RES06 AND RES05='执行' LEFT JOIN (SELECT RES04,HT01,HT02 FROM R_PQL A LEFT JOIN R_REVIEWS B ON A.HT64=B.RES06 AND RES05='执行') B ON A.PQF01=B.HT01 AND A.PQF02=B.HT02" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable ExistsDataTable ( string num )
        {
            // WHERE AE26=0 OR AE37=0 OR AE38=0
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AE01,AE26,AE37,AE38,AE22 FROM R_PQAE" );
            strSql.Append( " WHERE AE02=@AE02" );
            SqlParameter[] parameter = {
                new SqlParameter("@AE02",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
    }
}

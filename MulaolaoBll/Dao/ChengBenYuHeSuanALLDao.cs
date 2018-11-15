using StudentMgr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Dao
{
    public class ChengBenYuHeSuanALLDao
    {
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Exists ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQAN" );
            strSql.Append( " WHERE AN002=@AN002" );
            SqlParameter[] parameter = {
                new SqlParameter("@AN002",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }


        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public int idxExists ( MulaolaoLibrary.ChengBenYuHeSuanAllLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx FROM R_PQAN" );
            strSql.Append( " WHERE AN002=@AN002 AND AN012=@AN012 AND AN013=@AN013 AND AN014=@AN014 AND AN023=@AN023" );
            SqlParameter[] parameter = {
                new SqlParameter("@AN002",SqlDbType.Int),
                new SqlParameter("@AN012",SqlDbType.NVarChar),
                new SqlParameter("@AN013",SqlDbType.NVarChar),
                new SqlParameter("@AN014",SqlDbType.NVarChar),
                new SqlParameter("@AN023",SqlDbType.NVarChar)
            };

            parameter[0].Value = model.AN002;
            parameter[1].Value = model.AN012;
            parameter[2].Value = model.AN013;
            parameter[3].Value = model.AN014;
            parameter[4].Value = model.AN023;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da != null && da.Rows.Count > 0 )
                return string.IsNullOrEmpty( da.Rows[0]["idx"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[0]["idx"].ToString( ) );
            else
                return 0;
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool idxExistsPqy ( MulaolaoLibrary.ChengBenYuHeSuanAllLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQAN" );
            strSql.Append( " WHERE AN002=@AN002 AND AN012=@AN012" );
            SqlParameter[] parameter = {
                new SqlParameter("@AN002",SqlDbType.Int),
                new SqlParameter("@AN012",SqlDbType.NVarChar)
            };

            parameter[0].Value = model.AN002;
            parameter[1].Value = model.AN012;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }
        public bool ExistsOf ( MulaolaoLibrary.ChengBenYuHeSuanAllLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQAN" );
            strSql.Append( " WHERE AN002=@AN002 AND AN012=@AN012 AND AN013=@AN013" );
            SqlParameter[] parameter = {
                new SqlParameter("@AN002",SqlDbType.Int),
                new SqlParameter("@AN012",SqlDbType.NVarChar),
                new SqlParameter("@AN013",SqlDbType.NVarChar)
            };

            parameter[0].Value = model.AN002;
            parameter[1].Value = model.AN012;
            parameter[2].Value = model.AN013;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// R_339是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsPqi (MulaolaoLibrary.ChengBenYuHeSuanAllLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQAN" );
            strSql.Append( "  WHERE AN002=@AN002 AND AN012=@AN012" );

            SqlParameter[] parameter = {
                new SqlParameter("@AN002",SqlDbType.NVarChar),
                new SqlParameter("@AN012",SqlDbType.NVarChar)
            };

            parameter[0].Value = model.AN002;
            parameter[1].Value = model.AN012;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }



        /// <summary>
        /// 新增一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add ( MulaolaoLibrary.ChengBenYuHeSuanAllLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAN (" );
            strSql.Append( "AN001,AN002,AN003,AN004,AN005,AN006,AN007,AN008,AN009,AN010,AN011,AN012,AN013,AN014,AN015,AN016,AN017,AN018,AN019,AN020,AN021,AN022,AN023,AN024,AN025)" );
            strSql.Append( " VALUES(" );
            strSql.Append( "@AN001,@AN002,@AN003,@AN004,@AN005,@AN006,@AN007,@AN008,@AN009,@AN010,@AN011,@AN012,@AN013,@AN014,@AN015,@AN016,@AN017,@AN018,@AN019,@AN020,@AN021,@AN022,@AN023,@AN024,@AN025);" );
            strSql.Append( "SELECT SCOPE_IDENTITY();" );

            SqlParameter[] parameter = {
                new SqlParameter("@AN001",SqlDbType.NVarChar,20),
                new SqlParameter("@AN002",SqlDbType.NVarChar),
                new SqlParameter("@AN003",SqlDbType.NVarChar),
                new SqlParameter("@AN004",SqlDbType.NVarChar),
                new SqlParameter("@AN005",SqlDbType.NVarChar),
                new SqlParameter("@AN006",SqlDbType.BigInt),
                new SqlParameter("@AN007",SqlDbType.NVarChar,20),
                new SqlParameter("@AN008",SqlDbType.Date),
                new SqlParameter("@AN009",SqlDbType.Date),
                new SqlParameter("@AN010",SqlDbType.Date),
                new SqlParameter("@AN011",SqlDbType.NVarChar,20),
                new SqlParameter("@AN012",SqlDbType.NVarChar,50),
                new SqlParameter("@AN013",SqlDbType.NVarChar,20),
                new SqlParameter("@AN014",SqlDbType.NVarChar,20),
                new SqlParameter("@AN015",SqlDbType.Decimal),
                new SqlParameter("@AN016",SqlDbType.Decimal),
                new SqlParameter("@AN017",SqlDbType.Decimal),
                new SqlParameter("@AN018",SqlDbType.Decimal),
                new SqlParameter("@AN019",SqlDbType.Decimal),
                new SqlParameter("@AN020",SqlDbType.Decimal),
                new SqlParameter("@AN021",SqlDbType.Int),
                new SqlParameter("@AN022",SqlDbType.Decimal),
                new SqlParameter("@AN023",SqlDbType.NVarChar,20),
                new SqlParameter("@AN024",SqlDbType.NVarChar,2000),
                new SqlParameter("@AN025",SqlDbType.Decimal)
            };

            parameter[0].Value = model.AN001;
            parameter[1].Value = model.AN002;
            parameter[2].Value = model.AN003;
            parameter[3].Value = model.AN004;
            parameter[4].Value = model.AN005;
            parameter[5].Value = model.AN006;
            parameter[6].Value = model.AN007;
            parameter[7].Value = model.AN008;
            parameter[8].Value = model.AN009;
            parameter[9].Value = model.AN010;
            parameter[10].Value = model.AN011;
            parameter[11].Value = model.AN012;
            parameter[12].Value = model.AN013;
            parameter[13].Value = model.AN014;
            parameter[14].Value = model.AN015;
            parameter[15].Value = model.AN016;
            parameter[16].Value = model.AN017;
            parameter[17].Value = model.AN018;
            parameter[18].Value = model.AN019;
            parameter[19].Value = model.AN020;
            parameter[20].Value = model.AN021;
            parameter[21].Value = model.AN022;
            parameter[22].Value = model.AN023;
            parameter[23].Value = model.AN024;
            parameter[24].Value = model.AN025;


            int idx = SqlHelper.ExecuteSqlReturnId( strSql.ToString( ) ,parameter );
            return idx;

        }


        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateContract ( MulaolaoLibrary.ChengBenYuHeSuanAllLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAN SET " );
            //strSql.Append( "AN001=@AN001," );
            //strSql.Append( "AN002=@AN002," );
            strSql.Append( "AN003=@AN003," );
            strSql.Append( "AN004=@AN004," );
            strSql.Append( "AN005=@AN005," );
            strSql.Append( "AN006=@AN006," );
            strSql.Append( "AN007=@AN007," );
            strSql.Append( "AN008=@AN008," );
            strSql.Append( "AN009=@AN009," );
            strSql.Append( "AN010=@AN010," );
            strSql.Append( "AN011=@AN011," );
            //strSql.Append( "AN013=@AN013," );
            //strSql.Append( "AN014=@AN014," );
            strSql.Append( "AN015=@AN015," );
            strSql.Append( "AN016=@AN016," );
            strSql.Append( "AN017=@AN017," );
            strSql.Append( "AN018=@AN018," );
            strSql.Append( "AN019=@AN019," );
            strSql.Append( "AN020=@AN020," );
            strSql.Append( "AN022=@AN022," );
            //strSql.Append( "AN023=@AN023," );
            strSql.Append( "AN024=@AN024," );
            strSql.Append( "AN025=@AN025" );
            strSql.Append( " WHERE idx=@idx" );

            SqlParameter[] parameter = {
                new SqlParameter("@AN003",SqlDbType.NVarChar),
                new SqlParameter("@AN004",SqlDbType.NVarChar),
                new SqlParameter("@AN005",SqlDbType.NVarChar),
                new SqlParameter("@AN006",SqlDbType.BigInt),
                new SqlParameter("@AN007",SqlDbType.NVarChar,20),
                new SqlParameter("@AN008",SqlDbType.Date),
                new SqlParameter("@AN009",SqlDbType.Date),
                new SqlParameter("@AN010",SqlDbType.Date),
                new SqlParameter("@AN011",SqlDbType.NVarChar,20),
                new SqlParameter("@AN015",SqlDbType.Decimal),
                new SqlParameter("@AN016",SqlDbType.Decimal),
                new SqlParameter("@AN017",SqlDbType.Decimal),
                new SqlParameter("@AN018",SqlDbType.Decimal),
                new SqlParameter("@AN019",SqlDbType.Decimal),
                new SqlParameter("@AN020",SqlDbType.Decimal),
                //new SqlParameter("@AN021",SqlDbType.Int),
                new SqlParameter("@AN022",SqlDbType.Decimal),
                new SqlParameter("@AN024",SqlDbType.NVarChar,2000),
                new SqlParameter("@AN025",SqlDbType.Decimal),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            
            parameter[0].Value = model.AN003;
            parameter[1].Value = model.AN004;
            parameter[2].Value = model.AN005;
            parameter[3].Value = model.AN006;
            parameter[4].Value = model.AN007;
            parameter[5].Value = model.AN008;
            parameter[6].Value = model.AN009;
            parameter[7].Value = model.AN010;
            parameter[8].Value = model.AN011;
            parameter[9].Value = model.AN015;
            parameter[10].Value = model.AN016;
            parameter[11].Value = model.AN017;
            parameter[12].Value = model.AN018;
            parameter[13].Value = model.AN019;
            parameter[14].Value = model.AN020;
            //parameter[20].Value = model.AN021;
            parameter[15].Value = model.AN022;
            parameter[16].Value = model.AN024;
            parameter[17].Value = model.AN025;
            parameter[18].Value = model.Idx;

            int rows = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( rows > 0 )
                return true;
            else
                return false;
        }


        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.ChengBenYuHeSuanAllLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAN SET " );
            strSql.Append( "AN001=@AN001," );
            strSql.Append( "AN002=@AN002," );
            strSql.Append( "AN003=@AN003," );
            strSql.Append( "AN004=@AN004," );
            strSql.Append( "AN005=@AN005," );
            strSql.Append( "AN006=@AN006," );
            strSql.Append( "AN007=@AN007," );
            strSql.Append( "AN008=@AN008," );
            strSql.Append( "AN009=@AN009," );
            strSql.Append( "AN010=@AN010," );
            strSql.Append( "AN011=@AN011," );
            strSql.Append( "AN012=@AN012," );
            strSql.Append( "AN013=@AN013," );
            strSql.Append( "AN014=@AN014," );
            strSql.Append( "AN015=@AN015," );
            strSql.Append( "AN016=@AN016," );
            strSql.Append( "AN017=@AN017," );
            strSql.Append( "AN018=@AN018," );
            strSql.Append( "AN019=@AN019," );
            strSql.Append( "AN020=@AN020," );
            strSql.Append( "AN021=@AN021," );
            strSql.Append( "AN022=@AN022," );
            strSql.Append( "AN023=@AN023," );
            strSql.Append( "AN024=@AN024," );
            strSql.Append( "AN025=@AN025" );
            strSql.Append( " WHERE idx=@idx" );

            SqlParameter[] parameter = {
                new SqlParameter("@AN001",SqlDbType.NVarChar,20),
                new SqlParameter("@AN002",SqlDbType.NVarChar),
                new SqlParameter("@AN003",SqlDbType.NVarChar),
                new SqlParameter("@AN004",SqlDbType.NVarChar),
                new SqlParameter("@AN005",SqlDbType.NVarChar),
                new SqlParameter("@AN006",SqlDbType.BigInt),
                new SqlParameter("@AN007",SqlDbType.NVarChar,20),
                new SqlParameter("@AN008",SqlDbType.Date),
                new SqlParameter("@AN009",SqlDbType.Date),
                new SqlParameter("@AN010",SqlDbType.Date),
                new SqlParameter("@AN011",SqlDbType.NVarChar,20),
                new SqlParameter("@AN012",SqlDbType.NVarChar,50),
                new SqlParameter("@AN013",SqlDbType.NVarChar,20),
                new SqlParameter("@AN014",SqlDbType.NVarChar,20),
                new SqlParameter("@AN015",SqlDbType.Decimal),
                new SqlParameter("@AN016",SqlDbType.Decimal),
                new SqlParameter("@AN017",SqlDbType.Decimal),
                new SqlParameter("@AN018",SqlDbType.Decimal),
                new SqlParameter("@AN019",SqlDbType.Decimal),
                new SqlParameter("@AN020",SqlDbType.Decimal),
                new SqlParameter("@AN021",SqlDbType.Int),
                new SqlParameter("@AN022",SqlDbType.Decimal),
                new SqlParameter("@AN023",SqlDbType.NVarChar,20),
                new SqlParameter("@AN024",SqlDbType.NVarChar,2000),
                new SqlParameter("@AN025",SqlDbType.Decimal),
                new SqlParameter("@idx",SqlDbType.Int)
            };

            parameter[0].Value = model.AN001;
            parameter[1].Value = model.AN002;
            parameter[2].Value = model.AN003;
            parameter[3].Value = model.AN004;
            parameter[4].Value = model.AN005;
            parameter[5].Value = model.AN006;
            parameter[6].Value = model.AN007;
            parameter[7].Value = model.AN008;
            parameter[8].Value = model.AN009;
            parameter[9].Value = model.AN010;
            parameter[10].Value = model.AN011;
            parameter[11].Value = model.AN012;
            parameter[12].Value = model.AN013;
            parameter[13].Value = model.AN014;
            parameter[14].Value = model.AN015;
            parameter[15].Value = model.AN016;
            parameter[16].Value = model.AN017;
            parameter[17].Value = model.AN018;
            parameter[18].Value = model.AN019;
            parameter[19].Value = model.AN020;
            parameter[20].Value = model.AN021;
            parameter[21].Value = model.AN022;
            parameter[22].Value = model.AN023;
            parameter[23].Value = model.AN024;
            parameter[24].Value = model.AN025;
            parameter[25].Value = model.Idx;


            int rows = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( rows > 0 )
                return true;
            else
                return false;
        }


        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete ( MulaolaoLibrary.ChengBenYuHeSuanAllLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQAN" );
            strSql.Append( " WHERE idx=@idx" );
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
        /// <param name="idxList"></param>
        /// <returns></returns>
        public bool DeleteList ( string idxList )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQAN" );
            strSql.Append( " WHERE idx IN (" + idxList + ")" );

            int rows = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( rows > 0 )
                return true;
            else
                return false;
        }



        /// <summary>
        /// 获取一个实例对象
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ChengBenYuHeSuanAllLibrary GetModel ( MulaolaoLibrary.ChengBenYuHeSuanAllLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,AN001,AN002,AN003,AN004,AN005,AN006,AN007,AN008,AN009,AN010,AN011,AN012,AN013,AN014,AN015,AN016,AN017,AN018,AN019,AN020,AN021,AN022,AN023,AN024,AN025 FROM R_PQAN" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };

            parameter[0].Value = model.Idx;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da.Rows.Count > 0 )
                return DataRowModel( da.Rows[0] );
            else
                return null;
        }


        
        /// <summary>
        /// 获取一个实例对象
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ChengBenYuHeSuanAllLibrary DataRowModel ( DataRow row )
        {
            MulaolaoLibrary.ChengBenYuHeSuanAllLibrary model = new MulaolaoLibrary.ChengBenYuHeSuanAllLibrary( );
            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    model.Idx = int.Parse( row["idx"].ToString( ) );
                if ( row["AN001"] != null && row["AN001"].ToString( ) != "" )
                    model.AN001 = row["AN001"].ToString( );
                if ( row["AN002"] != null && row["AN002"].ToString( ) != "" )
                    model.AN002 = row["AN002"].ToString( );
                if ( row["AN003"] != null && row["AN003"].ToString( ) != "" )
                    model.AN003 = row["AN003"].ToString( );
                if ( row["AN004"] != null && row["AN004"].ToString( ) != "" )
                    model.AN004 = row["AN004"].ToString( );
                if ( row["AN005"] != null && row["AN005"].ToString( ) != "" )
                    model.AN005 = row["AN005"].ToString( );
                if ( row["AN006"] != null && row["AN006"].ToString( ) != "" )
                    model.AN006 = long.Parse( row["AN006"].ToString( ) );
                if ( row["AN007"] != null && row["AN007"].ToString( ) != "" )
                    model.AN007 = row["AN007"].ToString( );
                if ( row["AN008"] != null && row["AN008"].ToString( ) != "" )
                    model.AN008 = DateTime.Parse( row["AN008"].ToString( ) );
                if ( row["AN009"] != null && row["AN009"].ToString( ) != "" )
                    model.AN009 = DateTime.Parse( row["AN009"].ToString( ) );
                if ( row["AN010"] != null && row["AN010"].ToString( ) != "" )
                    model.AN010 = DateTime.Parse( row["AN010"].ToString( ) );
                if ( row["AN011"] != null && row["AN011"].ToString( ) != "" )
                    model.AN011 = row["AN011"].ToString( );
                if ( row["AN012"] != null && row["AN012"].ToString( ) != "" )
                    model.AN012 = row["AN012"].ToString( );
                if ( row["AN013"] != null && row["AN013"].ToString( ) != "" )
                    model.AN013 = row["AN013"].ToString( );
                if ( row["AN014"] != null && row["AN014"].ToString( ) != "" )
                    model.AN014 = row["AN014"].ToString( );
                if ( row["AN015"] != null && row["AN015"].ToString( ) != "" )
                    model.AN015 = decimal.Parse( row["AN015"].ToString( ) );
                if ( row["AN016"] != null && row["AN016"].ToString( ) != "" )
                    model.AN016 = decimal.Parse( row["AN016"].ToString( ) );
                if ( row["AN017"] != null && row["AN017"].ToString( ) != "" )
                    model.AN017 = decimal.Parse( row["AN017"].ToString( ) );
                if ( row["AN018"] != null && row["AN018"].ToString( ) != "" )
                    model.AN018 = decimal.Parse( row["AN018"].ToString( ) );
                if ( row["AN019"] != null && row["AN019"].ToString( ) != "" )
                    model.AN019 = decimal.Parse( row["AN019"].ToString( ) );
                if ( row["AN020"] != null && row["AN020"].ToString( ) != "" )
                    model.AN020 = decimal.Parse( row["AN020"].ToString( ) );
                if ( row["AN021"] != null && row["AN021"].ToString( ) != "" )
                    model.AN021 = int.Parse( row["AN021"].ToString( ) );
                if ( row["AN022"] != null && row["AN022"].ToString( ) != "" )
                    model.AN022 = decimal.Parse( row["AN022"].ToString( ) );
                if ( row["AN023"] != null && row["AN023"].ToString( ) != "" )
                    model.AN023 = row["AN023"].ToString( );
                if ( row["AN024"] != null && row["AN024"].ToString( ) != "" )
                    model.AN024 = row["AN024"].ToString( );
                if ( row["AN025"] != null && row["AN025"].ToString( ) != "" )
                    model.AN025 = decimal.Parse( row["AN025"].ToString( ) );
            }

            return model;
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQAN" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( " ORDER BY idx" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableRpqaf ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT PQF01,PQF02,PQF03,PQF04,PQF06 FROM R_PQF A,R_REVIEWS B WHERE A.PQF01=B.RES06 AND RES05='执行' AND PQF01 NOT IN (SELECT AN002 FROM R_PQAN)" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableRpqafQuery ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT PQF02,PQF03,PQF04,PQF06,PQF31,PQF13,PQF35,(SELECT DAA002 FROM TPADAA WHERE DAA001 = PQF17) DAA002 FROM R_PQF" );
            strSql.Append( " WHERE PQF01=@PQF01" );
            SqlParameter[] parameter = {
                new SqlParameter("@PQF01",SqlDbType.NVarChar)
            };
            parameter[0].Value = strWhere;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ),parameter );
        }


        /// <summary>
        /// R_195
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqq ( string oddNum )
        {
            //StringBuilder strSql = new StringBuilder( );
            //strSql.Append( "SELECT A.idx,CP54,CP06,CP07,CP13,CONVERT(BIGINT,CP54*CP13*CP10-CP12) U0,CP32,ISNULL((SELECT CONVERT(DECIMAL(6,2),GS04) GS04 FROM R_PQP B WHERE A.CP01=B.GS01 AND A.CP06=B.GS07),0) GS04,ISNULL((SELECT CONVERT(DECIMAL(6,2),GS10) GS10 FROM R_PQP B WHERE A.CP01=B.GS01 AND A.CP06=B.GS07),0) GS10,ISNULL((SELECT CONVERT(DECIMAL(6,2),GS51) GS51 FROM R_PQP B WHERE A.CP01=B.GS01 AND A.CP06=B.GS07),0) GS51 FROM R_PQQ A ,R_REVIEWS B" );
            //strSql.Append( " WHERE A.CP03=B.RES06 AND RES05='执行' AND CP01 LIKE '%" + oddNum + "%'" );

            //return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            /*
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DECLARE @COUNT INT;" );
            strSql.Append( " SET SELECT @COUNT=COUNT(1) FROM R_PQQ WHERE CP09 IN ('/','0') AND CP01 LIKE '%" + oddNum + "%';" );
            strSql.Append( " IF(@COUNT>0)" );
            strSql.Append( " SELECT A.idx,CP54,CP06,CP09,CP07,CP13,CONVERT(BIGINT,CP54*CP13*CP10-CP12) U0,CP32,ISNULL((SELECT CONVERT(DECIMAL(6,2),GS04) GS04 FROM R_PQP B WHERE A.CP01=B.GS01 AND A.CP06=B.GS07),0) GS04,ISNULL((SELECT CONVERT(DECIMAL(6,2),GS10) GS10 FROM R_PQP B WHERE A.CP01=B.GS01 AND A.CP06=B.GS07),0) GS10,ISNULL((SELECT CONVERT(DECIMAL(6,2),GS51) GS51 FROM R_PQP B WHERE A.CP01=B.GS01 AND A.CP06=B.GS07),0) GS51 FROM R_PQQ A ,R_REVIEWS B" );
            strSql.Append( " WHERE A.CP03=B.RES06 AND RES05='执行' AND CP01 LIKE '%" + oddNum + "%'" );
            strSql.Append( " ELSE" );
            strSql.Append( " SELECT A.idx,CP54,CP06,CP09,CP07,CP13,CONVERT(BIGINT,CP54*CP13*CP10-CP12) U0,CP32,ISNULL((SELECT CONVERT(DECIMAL(6,2),GS04) GS04 FROM R_PQP B WHERE A.CP01=B.GS01 AND A.CP09=B.GS35),0) GS04,ISNULL((SELECT CONVERT(DECIMAL(6,2),GS10) GS10 FROM R_PQP B WHERE A.CP01=B.GS01 AND A.CP09=B.GS35),0) GS10,ISNULL((SELECT CONVERT(DECIMAL(6,2),GS51) GS51 FROM R_PQP B WHERE A.CP01=B.GS01 AND A.CP09=B.GS35),0) GS51 FROM R_PQQ A ,R_REVIEWS B" );
            strSql.Append( " WHERE A.CP03=B.RES06 AND RES05='执行' AND CP01 LIKE '%" + oddNum + "%'" );
            */
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT CP54,CASE WHEN CP09='/' OR CP09='0' THEN '委外' ELSE CP09 END CP09,CONVERT(DECIMAL(18,0),SUM(CASE WHEN CP09!='/' AND CP09!='0' THEN CP54*CP13*CP10-CP12 ELSE CP54*CP13*CP11-CP12 END)) U0,CP32 FROM R_PQQ A ,R_REVIEWS B WHERE A.CP03=B.RES06 AND RES05='执行' AND CP01 LIKE '%" + oddNum + "%'" );
            strSql.Append( "GROUP BY CP54,CP09,CP32" );
            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// R_196
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqah ( string oddNum )
        {
            // AND A.AH11=B.GS08
            //StringBuilder strSql = new StringBuilder( );
            //strSql.Append( "SELECT A.idx,AH10,AH11,AH13,AH101,AH05,CONVERT(BIGINT,AH16*AH101*AH13*AH14-AH17) U0,AH111,ISNULL((SELECT CONVERT(DECIMAL(6,2),GS04) GS04 FROM R_PQP B WHERE A.AH01=B.GS01 AND A.AH10=B.GS07),0) GS04,ISNULL((SELECT CONVERT(DECIMAL(6,2),GS10) GS10 FROM R_PQP B WHERE A.AH01=B.GS01 AND A.AH10=B.GS07),0) GS10,ISNULL((SELECT CONVERT(DECIMAL(6,2),GS51) GS51 FROM R_PQP B WHERE A.AH01=B.GS01 AND A.AH10=B.GS07),0) GS51 FROM R_PQAH A,R_REVIEWS B" );
            //strSql.Append( " WHERE A.AH97=B.RES06 AND RES05='执行' AND AH01 LIKE '%" + oddNum + "%'" );

            //return SqlHelper.ExecuteDataTable( strSql.ToString( ) );

            StringBuilder strSql = new StringBuilder( );
            /*
            strSql.Append( "DECLARE @COUNT INT;" );
            strSql.Append( "SET SELECT @COUNT=COUNT(1) FROM R_PQAH WHERE AH18='' AND AH01 LIKE '%" + oddNum + "%'" );
            strSql.Append( "IF(@COUNT>0)" );
            strSql.Append( " SELECT A.idx,AH10,AH11,AH13,AH101,AH05,CONVERT(BIGINT,AH16*AH101*AH13*AH14-AH17) U0,AH111,ISNULL((SELECT CONVERT(DECIMAL(6,2),GS04) GS04 FROM R_PQP B WHERE A.AH01=B.GS01 AND A.AH10=B.GS07),0) GS04,ISNULL((SELECT CONVERT(DECIMAL(6,2),GS10) GS10 FROM R_PQP B WHERE A.AH01=B.GS01 AND A.AH10=B.GS07),0) GS10,ISNULL((SELECT CONVERT(DECIMAL(6,2),GS51) GS51 FROM R_PQP B WHERE A.AH01=B.GS01 AND A.AH10=B.GS07),0) GS51 FROM R_PQAH A,R_REVIEWS B" );
            strSql.Append( " WHERE A.AH97=B.RES06 AND RES05='执行' AND AH01 LIKE '%" + oddNum + "%';" );
            strSql.Append( " ELSE" );
            strSql.Append( " SELECT A.idx,AH10,AH11,AH13,AH101,AH05,CONVERT(BIGINT,AH16*AH101*AH13*AH14-AH17) U0,AH111,ISNULL((SELECT CONVERT(DECIMAL(6,2),GS04) GS04 FROM R_PQP B WHERE A.AH01=B.GS01 AND A.AH18=B.GS35),0) GS04,ISNULL((SELECT CONVERT(DECIMAL(6,2),GS10) GS10 FROM R_PQP B WHERE A.AH01=B.GS01 AND A.AH18=B.GS35),0) GS10,ISNULL((SELECT CONVERT(DECIMAL(6,2),GS51) GS51 FROM R_PQP B WHERE A.AH01=B.GS01 AND A.AH18=B.GS35),0) GS51 FROM R_PQAH A,R_REVIEWS B" );
            strSql.Append( " WHERE A.AH97=B.RES06 AND RES05='执行' AND AH01 LIKE '%" + oddNum + "%';" );
            */
            strSql.Append( "SELECT AH101,AH18,AH05,CONVERT(DECIMAL(18,0),SUM(AH16*AH101*AH13*AH14-AH17)) U0,AH111 FROM R_PQAH A,R_REVIEWS B" );
            strSql.Append( " WHERE A.AH97=B.RES06 AND RES05='执行' AND AH01 LIKE '%" + oddNum + "%'" );
            strSql.Append( " GROUP BY AH101,AH18,AH05,AH111" );
            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// R_338
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqo ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT JM09,SUM(JM103) JM103,JM94,JM95,JM96,JM10,JM14,DBA002,SUM(CONVERT(DECIMAL(18,0),JM11*JM103/JM10)) U0,ISNULL(JM107,'F') JM107,ISNULL((SELECT TOP 1  CONVERT(DECIMAL(6,2),GS11) GS11 FROM R_PQP B WHERE A.JM09=B.GS02 AND A.JM90=B.GS01),0) GS51,ISNULL((SELECT TOP 1  CONVERT(DECIMAL(6,2),GS10) GS10 FROM R_PQP B WHERE A.JM09=B.GS02 AND A.JM90=B.GS01),0) GS10,ISNULL((SELECT TOP 1  CONVERT(DECIMAL(6,2),GS10*GS11) GS04 FROM R_PQP B WHERE A.JM09=B.GS02 AND A.JM90=B.GS01),0) GS04 FROM R_PQO A INNER JOIN R_REVIEWS B ON A.JM01=B.RES06 AND RES05='执行' LEFT JOIN TPADBA C ON A.JM02=C.DBA001" );
            strSql.Append( "  WHERE JM90 LIKE '%" + oddNum + "%' GROUP BY JM09,JM94,JM95,JM96,JM10,JM14,DBA002,JM107,JM90" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// R_339
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqi ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            //strSql.Append( "SELECT YQ03,SUM(CASE WHEN YQ115=0 THEN CONVERT(BIGINT,YQ16*YQ108*YQ112*YQ114*YQ115*YQ116*YQ113*0.0001*YQ13*0.01) WHEN YQ115!=0 THEN CONVERT(BIGINT,YQ16*YQ108*YQ112*YQ114*YQ115*YQ116*YQ113*0.0001*YQ13*0.01+YQ108*YQ112*YQ116*YQ113*YQ13*YQ14*0.01/YQ114/YQ115) END) U2,YQ123,YQ101,YQ04, CONVERT(DECIMAL(6,2),GS36) GS36,CONVERT(BIGINT,ISNULL(SUM(PQK25*(PQK31+PQK10)),0)) U3 FROM R_PQI A LEFT JOIN R_REVIEWS B ON A.YQ99=B.RES06 AND RES05='执行' LEFT JOIN R_PQK C ON A.YQ03=C.PQK02 LEFT JOIN R_PQP D ON A.YQ03=D.GS01 AND D.GS35='油漆'" );
            //strSql.Append( " WHERE YQ03 LIKE '%" + oddNum + "%'" );
            //strSql.Append( " GROUP BY YQ03,YQ123,YQ101,YQ04,GS36" );
            strSql.Append( "SELECT YQ03,CONVERT(DECIMAL(18,0),SUM(ISNULL(PQK10*PQK25+PQK31*PQK25,0))) U2,DBA002,CONVERT(DECIMAL(18,2),SUM(ISNULL(PQK10*PQK25+PQK31*PQK25,0))/PQK23) U3,YQ108,CONVERT(DECIMAL(18,0),SUM(YQ16*YQ108*YQ112*YQ114*YQ115*YQ116*YQ113*0.0001*YQ13*0.01+CASE WHEN YQ114=0 THEN 0 WHEN YQ115=0 THEN 0 ELSE YQ108*YQ112*YQ116*YQ113*YQ13*YQ14*0.01/YQ114/YQ115 END)) U4 FROM R_PQK A RIGHT JOIN R_PQI B ON A.PQK02=B.YQ03 LEFT JOIN TPADBA C ON A.YQ01=C.DBA001 WHERE YQ99 LIKE 'R_339%'" );
            strSql.Append( " AND YQ03=@YQ03" );
            strSql.Append( " GROUP BY YQ03,DBA002,YQ108,PQK23" );
            SqlParameter[] parameter = {
                new SqlParameter("@YQ03",SqlDbType.NVarChar)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        
        /// <summary>
        /// R_344 厂外
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqmz ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT A.idx,PZ009,PZ006,MZ115 PZ023,PZ030,CONVERT(DECIMAL(18,0),PZ026*PZ017+ISNULL(PZ035,0)) MZ1,ISNULL((SELECT TOP 1 CONVERT(DECIMAL(6,2),GS10*GS11) GS04 FROM R_PQP B WHERE A.PZ003=B.GS01 AND A.PZ009=B.GS07),0) GS04,ISNULL((SELECT TOP 1 CONVERT(DECIMAL(6,2),GS10) GS10 FROM R_PQP B WHERE A.PZ003=B.GS01 AND A.PZ009=B.GS07),0) GS10,ISNULL((SELECT  TOP 1 CONVERT(DECIMAL(6,2),GS11) GS11 FROM R_PQP B WHERE A.PZ003=B.GS01 AND A.PZ009=B.GS07),0) GS51 FROM R_PQPZ A LEFT JOIN R_REVIEWS ON PZ001=RES06 AND RES05='执行' LEFT JOIN R_PQMZ C ON A.PZ003=C.MZ002" );
            strSql . AppendFormat ( " WHERE PZ003='{0}'  AND PZ039='厂外'" ,oddNum );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// R_344 厂内
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqmzes ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT A.idx,MZ016,MZ006,MZ031,MZ021,CONVERT(DECIMAL(18,0),MZ022*MZ006*MZ026*MZ024+ISNULL(MZ119,0)) PZ1,ISNULL((SELECT TOP 1 CONVERT(DECIMAL(6,2),GS10*GS11) GS04 FROM R_PQP B WHERE A.MZ002=B.GS01 AND A.MZ016=B.GS07),0) GS04,ISNULL((SELECT TOP 1 CONVERT(DECIMAL(6,2),GS10) GS10 FROM R_PQP B WHERE A.MZ002=B.GS01 AND A.MZ016=B.GS07),0) GS10,ISNULL((SELECT TOP 1 CONVERT(DECIMAL(6,2),GS11) GS11 FROM R_PQP B WHERE A.MZ002=B.GS01 AND A.MZ016=B.GS07),0) GS51 FROM R_PQMZ A LEFT JOIN R_REVIEWS ON MZ001=RES06 AND RES05='执行' " );
            strSql.Append( "WHERE MZ002=@MZ002 AND MZ107='厂内'" );
            SqlParameter[] parameter = {
                new SqlParameter("@MZ002",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;
            
            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        
        /// <summary>
        /// R_344 工资
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqmzs ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            //strSql.Append( "SELECT MZ031,SUM(MZ0) MZ0 FROM (" );
            //strSql.Append( " SELECT MZ031,CONVERT(DECIMAL(18,0),CASE WHEN MZ107='厂内' THEN SUM(MZ022*MZ006*MZ027+ISNULL(MZ118,0)) ELSE 0 END) MZ0 FROM R_PQMZ A" );
            //strSql.Append( " LEFT JOIN R_REVIEWS ON MZ001=RES06 AND RES05='执行'" );
            //strSql.Append( " WHERE MZ002=@MZ002" );
            //strSql.Append( " GROUP BY MZ107,MZ031 ) A WHERE MZ0!=0 GROUP BY MZ031" );
            strSql.Append( "SELECT CONVERT(DECIMAL(18,2),SUM(MZ022*MZ006*MZ027+ISNULL(MZ118,0))) PZ,MZ031 FROM R_PQMZ" );
            strSql.Append( " WHERE MZ002=@MZ002  AND MZ107='厂内'" );
            strSql.Append( " GROUP BY MZ031" ); 
            SqlParameter[] parameter = {
                new SqlParameter("@MZ002",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter ); 
        }

        /// <summary>
        /// R_341
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqv ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT A.idx,PQV80,PQV10,PQV12,PQV68,PQV69,DBA002 PQV05,PQV70,PQV86,CONVERT(BIGINT,PQV80*PQV12*PQV68*PQV69*PQV70*0.000001*PQV11) U0,PQV88,PQV65,CONVERT(DECIMAL(6,2),GS11) GS11,CONVERT(DECIMAL(6,2),GS10) GS10,CONVERT(DECIMAL(6,2),GS11*GS10) GS04 FROM R_PQV A LEFT JOIN R_REVIEWS B ON A.PQV76=B.RES06 AND RES05='执行' LEFT JOIN R_PQP C ON A.PQV01=C.GS01 AND C.GS02=A.PQV86 AND C.GS07=A.PQV10 LEFT JOIN TPADBA D ON A.PQV02=D.DBA001" );
            strSql.Append( " WHERE PQV01 LIKE '%" + oddNum+"%'" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// R_342
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqaf ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            //strSql.Append( "SELECT A.idx,AF006,DBA002 AF010,AF078,AF015,AF016,AF019,AF020,AF021,AF022,CONVERT(DECIMAL(18,0),AF023*AF006*AF019) U0,CONVERT(DECIMAL(6,2),GS10*GS11) GS,CONVERT(DECIMAL(6,2),GS10) GS10,CONVERT(DECIMAL(6,2),GS11) GS11 FROM R_PQAF A LEFT JOIN R_REVIEWS B ON A.AF001=B.RES06 AND RES05='执行' LEFT JOIN R_PQP C ON A.AF002=C.GS01 AND A.AF015=C.GS07 LEFT JOIN TPADBA D ON A.AF007=D.DBA001 " );
            //strSql.Append( " WHERE AF002 LIKE '%" + oddNum + "%'" );
            strSql . Append ( "SELECT A.idx,AF006,DBA002 AF010,AF078,AF015,AF016,AF019,AF020,AF021,AF022,CONVERT(DECIMAL(18,0),AF023*AF006*AF019) U0,CONVERT(DECIMAL(6,2),(SELECT TOP 1 GS10*GS11 FROM R_PQP WHERE AF002=GS01 AND AF015=GS07)) GS,CONVERT(DECIMAL(6,2),(SELECT TOP 1  GS10 FROM R_PQP WHERE AF002=GS01 AND AF015=GS07)) GS10,CONVERT(DECIMAL(6,2),(SELECT TOP 1  GS11 FROM R_PQP WHERE AF002=GS01 AND AF015=GS07)) GS11 FROM R_PQAF A LEFT JOIN R_REVIEWS B ON A.AF001=B.RES06 AND RES05='执行' LEFT JOIN TPADBA D ON A.AF007=D.DBA001 " );
            strSql . Append ( " WHERE AF002 LIKE '%" + oddNum + "%'" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// R_343
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqu ( string oddNum )
        {
            // AND A.PQU12=B.GS08
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT A.idx,PQU101,PQU10,DBA002 PQU05,PQU12,PQU13,CONVERT(DECIMAL(18,0),PQU16*(PQU101*PQU13+PQU14)-PQU17) U0,PQU107,PQU19,ISNULL((SELECT TOP 1 CONVERT(DECIMAL(6,2),GS10*GS11) GS FROM R_PQP B WHERE A.PQU01=B.GS01 AND A.PQU10=B.GS07),0) GS,ISNULL((SELECT TOP 1 CONVERT(DECIMAL(6,2),GS10) GS10 FROM R_PQP B WHERE A.PQU01=B.GS01 AND A.PQU10=B.GS07),0) GS10,ISNULL((SELECT TOP 1 CONVERT(DECIMAL(6,2),GS11) GS11 FROM R_PQP B WHERE A.PQU01=B.GS01 AND A.PQU10=B.GS07),0) GS11 FROM R_PQU A LEFT JOIN R_REVIEWS B ON A.PQU97=B.RES06 AND RES05='执行' LEFT JOIN TPADBA C ON A.PQU02=C.DBA001" );
            strSql.Append( " WHERE PQU01 LIKE '%" + oddNum + "%'" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 345
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqlz ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT SUM(CONVERT(DECIMAL(18,2),LZ022*LZ006*LZ024+LZ026)) LZ,LZ029 FROM R_PQLZ A,R_REVIEWS B WHERE A.LZ001=B.RES06 AND RES05='执行'" );
            strSql.Append( " AND LZ002=@LZ002" );
            strSql.Append( " GROUP BY LZ029" );
            SqlParameter[] parameter = {
                new SqlParameter("@LZ002",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// R_347
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqs ( string oddNum )
        {
            // AND A.PJ89=B.GS08
            StringBuilder strSql = new StringBuilder( );
            //strSql.Append( "SELECT A.idx,PJ96,PJ09,PJ89,PJ04,PJ15,PJ11,PJ100,CONVERT(BIGINT,PJ12*(PJ11*PJ96+PJ10)-PJ16) U0,ISNULL((SELECT CONVERT(DECIMAL(6,2),B.GS04)  FROM (SELECT DISTINCT GS10,GS04,GS51,GS01,GS07,GS08 FROM R_PQP UNION SELECT DISTINCT GS59,GS53,GS61,GS01,GS56,GS57 FROM R_PQP) B WHERE A.PJ01=B.GS01 AND A.PJ09=B.GS07),0) GS04,ISNULL((SELECT CONVERT(DECIMAL(6,2),GS10) FROM (SELECT DISTINCT GS10,GS04,GS51,GS01,GS07,GS08 FROM R_PQP UNION SELECT DISTINCT GS59,GS53,GS61,GS01,GS56,GS57 FROM R_PQP) B WHERE A.PJ01=B.GS01 AND A.PJ09=B.GS07),0) GS10,ISNULL((SELECT CONVERT(DECIMAL(6,2),GS51) GS51 FROM (SELECT DISTINCT GS10,GS04,GS51,GS01,GS07,GS08 FROM R_PQP UNION SELECT DISTINCT GS59,GS53,GS61,GS01,GS56,GS57 FROM R_PQP) B WHERE A.PJ01=B.GS01 AND A.PJ09=B.GS07),0) GS51 FROM R_PQS A,R_REVIEWS B" );
            //strSql.Append( " WHERE A.PJ92=B.RES06 AND RES05='执行' AND PJ01 LIKE '%" + oddNum + "%'" );
            strSql.Append( "SELECT A.idx,PJ96,PJ09,PJ89,DBA002 PJ04,PJ15,PJ11,PJ100,CONVERT(DECIMAL(18,0),PJ12*(PJ11*PJ96+PJ10)-PJ16) U0," );
            strSql.Append( "ISNULL((SELECT CONVERT(DECIMAL(6,2),B.GS04)  FROM (" );
            strSql.Append( "SELECT DISTINCT GS10*GS11 GS04,GS01,GS07 FROM R_PQP " );
            strSql.Append( "WHERE GS01 LIKE '%" + oddNum + "%' AND GS07 IS NOT NULL " );
            strSql.Append( "UNION " );
            strSql.Append( "SELECT DISTINCT GS60*GS59 GS04,GS01,GS56 FROM R_PQP " );
            strSql.Append( "WHERE GS01 LIKE '%" + oddNum + "%' AND GS56 IS NOT NULL " );
            strSql.Append( ") B WHERE A.PJ01=B.GS01 AND A.PJ09=B.GS07),0) GS04," );
            strSql.Append( "ISNULL((SELECT CONVERT(DECIMAL(6,2),GS10) FROM (" );
            strSql.Append( "SELECT DISTINCT GS10,GS01,GS07 FROM R_PQP " );
            strSql.Append( "WHERE GS01 LIKE '%" + oddNum + "%' AND GS07 IS NOT NULL " );
            strSql.Append( "UNION " );
            strSql.Append( "SELECT DISTINCT GS59,GS01,GS56 FROM R_PQP " );
            strSql.Append( "WHERE GS01 LIKE '%" + oddNum + "%' AND GS56 IS NOT NULL " );
            strSql.Append( ") B WHERE A.PJ01=B.GS01 AND A.PJ09=B.GS07),0) GS10," );
            strSql.Append( "ISNULL((SELECT CONVERT(DECIMAL(6,2),GS11) GS11 FROM (" );
            strSql.Append( "SELECT DISTINCT GS11,GS01,GS07 FROM R_PQP " );
            strSql.Append( "WHERE GS01 LIKE '%" + oddNum + "%' AND GS07 IS NOT NULL " );
            strSql.Append( "UNION " );
            strSql.Append( "SELECT DISTINCT GS60,GS01,GS56 FROM R_PQP " );
            strSql.Append( "WHERE GS01 LIKE '%" + oddNum + "%' AND GS56 IS NOT NULL " );
            strSql.Append( ") B WHERE A.PJ01=B.GS01 AND A.PJ09=B.GS07),0) GS51 FROM R_PQS A LEFT JOIN R_REVIEWS B ON A.PJ92=B.RES06 AND RES05='执行' LEFT JOIN TPADBA C ON A.PJ02=C.DBA001 " );
            strSql.Append( "WHERE PJ01 LIKE '%" + oddNum + "%' AND PJ09 IS NOT NULL" );
            
            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 348
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqoz ( string oddNum )
        { 
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "WITH CET AS (SELECT SUM(OZ) OZ,OZ011,COUN FROM (SELECT OZ005*OZ006 OZ,OZ011,COUNT(1) COUN FROM R_PQOZ GROUP BY OZ011,OZ005,OZ006) A GROUP BY OZ011,COUN)" );
            strSql.Append( "SELECT SUM(OZ) OZ,DBA002 WX05,WX90 FROM (SELECT CASE WHEN COUN=0 THEN 0 WHEN OZ=0 THEN 0 ELSE CONVERT(DECIMAL(18,0),SUM(OZ009)/OZ*OZ005*OZ006/COUN) END OZ,WX05,WX90 FROM R_PQOZ TT LEFT JOIN TPADGA B ON TT.OZ014=B.DGA001 LEFT JOIN CET C ON TT.OZ011=C.OZ011 INNER JOIN R_REVIEWS D ON TT.OZ011=D.RES06 AND RES05='执行' LEFT JOIN R_PQT E ON TT.OZ015=E.WX82 LEFT JOIN TPDABA F ON A.WX02=F.DBA001" );
            strSql.Append( " WHERE OZ001=@OZ001" );
            strSql.Append( " GROUP BY OZ001,TT.OZ011,OZ,OZ005,OZ006,WX05,WX90,COUN) A GROUP BY DBA002,WX90" );
            SqlParameter[] parameter = {
                new SqlParameter("@OZ001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// R_349
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqt ( string oddNum )
        {
            // AND A.WX11=B.GS57
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT A.idx,WX86,WX10,DBA002 WX05,WX11,WX14,WX15,WX90,WX17,SUM(CASE WHEN WX10='双瓦外箱' THEN CONVERT( DECIMAL(18,0), ((WX27 + WX28 + WX29) * (WX30 + WX31 + WX32) + (WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15 ) WHEN WX10='小箱式' THEN CONVERT( DECIMAL(18,0), ((WX27 + WX28 + WX29) * (WX30 + WX31 + WX32) + (WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15 ) WHEN WX10='牙膏式' THEN CONVERT( DECIMAL(18,0), ((WX27 + 2*WX28 + WX29) * (2*WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 ) WHEN WX10='插口式' THEN CONVERT( DECIMAL(18,0), ((WX27 + 2*WX28 + WX29) * (2*WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 ) WHEN WX10='天盖' THEN CONVERT( DECIMAL(18,0), ((WX27 + 2*WX28 + WX29) * (WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 ) WHEN WX10='地盖' THEN CONVERT( DECIMAL(18,0), ((WX27 + 2*WX28 + WX29) * (WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 ) WHEN WX10='折叠式' THEN CONVERT( DECIMAL(18,0), ((2*WX27 + 2*WX28 + WX29) * (1.5*WX30 + WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 ) WHEN WX10 NOT IN ('双瓦外箱','小箱式','牙膏式','插口式','天盖','地盖','折叠式') THEN CONVERT( DECIMAL(18,0), (WX23 + WX24) * (WX25 + WX26) * 0.0001 * WX13* WX15) END) PQ ,ISNULL((SELECT TOP 1 CONVERT(DECIMAL(6,2),GS59*GS60) FROM R_PQP B WHERE A.WX01=B.GS01 AND A.WX10=B.GS56),0) GS53,ISNULL((SELECT TOP 1 CONVERT(DECIMAL(6,2),GS59) FROM R_PQP B WHERE A.WX01=B.GS01 AND A.WX10=B.GS56),0) GS59,ISNULL((SELECT TOP 1 CONVERT(DECIMAL(6,2),GS60) FROM R_PQP B WHERE A.WX01=B.GS01 AND A.WX10=B.GS56),0) GS61 FROM R_PQT A LEFT JOIN R_REVIEWS B ON A.WX82=B.RES06 AND RES05='执行'  LEFT JOIN TPADBA C ON A.WX02=C.DBA001 " );
            strSql.Append( " WHERE WX01 LIKE '%" + oddNum + "%' AND LEN(WX01)<=8" );
            strSql.Append( " GROUP BY A.idx,WX86,WX10,WX11,WX14,WX15,WX90,WX17,WX01,DBA002" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// R_495
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqy ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT PY06,CONVERT(DECIMAL(18,0),SUM(U13+U14)) U1 FROM (SELECT PY06,CASE WHEN PY14 = 0 OR PY18 = 0 OR PY21 = 0 THEN 0 WHEN PY14 != 0 AND PY18 != 0 AND PY21 != 0 THEN CONVERT( DECIMAL(18,1),(PY10*PY11*PY15*PY12*PY20/PY21/PY14/PY18+PY13*PY19*PY16*PY10*PY11/PY14/PY18/PY21/2)*(1+PY17/100)) END U13,CONVERT( DECIMAL(18,1),PY23*PY14*PY18*PY11*PY10*PY12*PY15*0.0001 ) U14 FROM R_PQY LEFT JOIN R_REVIEWS ON PY33=RES06 AND RES05='执行'" );
            strSql.Append( " WHERE PY01=@PY01" );
            strSql.Append( " ) T GROUP BY PY06" );
            SqlParameter[] parameter = {
                new SqlParameter("@PY01",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// R_505
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqiz ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            //strSql.Append( "SELECT A.idx,IZ005,IZ008,IZ010,IZ006,CASE WHEN IZ021=0 THEN 0 ELSE CONVERT(DECIMAL(10,3),(IZ005*IZ022/IZ021)*(IZ013*(IZ014+IZ015)*2*IZ016)) END U0 FROM R_PQIZ A,R_REVIEWS B WHERE A.IZ001=B.RES06 AND RES05='执行'" );
            strSql.Append( "SELECT IZ005,IZ006,SUM(CASE WHEN IZ021=0 THEN 0 ELSE CONVERT(DECIMAL(10,3),(IZ005*IZ022/IZ021)*(IZ013*(IZ014+IZ015)*2*IZ016)) END) U0 FROM R_PQIZ A,R_REVIEWS B WHERE A.IZ001=B.RES06 AND RES05='执行'" );
            strSql.Append( " AND IZ002=@IZ002 GROUP BY IZ005,IZ006" );
            SqlParameter[] parameter = {
                new SqlParameter("@IZ002",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// R_317
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqw ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT GX04,GZ30,CONVERT(DECIMAL(18,0),SUM(GZ41*GZ25*GZ06+GZ36*(GZ12+GZ13+GZ14))) GZ,ISNULL(GS36,0) GS36 FROM R_PQW A LEFT JOIN R_PQAA B ON A.GZ04=B.GX02 LEFT JOIN R_PQP C ON B.GX04=C.GS35 AND A.GZ01=C.GS01 " );
            strSql.Append( " WHERE GZ01=@GZ01" );
            strSql.Append( " GROUP BY GX04,GZ30,GS36" );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ01",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public bool ExistsOfPqw ( string gx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQAN" );
            strSql.Append( " WHERE AN013=@AN013" );
            SqlParameter[] parameter = {
                new SqlParameter("@AN013",SqlDbType.NVarChar)
            };
            parameter[0].Value = gx;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }
        public bool UpdateOfPqw ( MulaolaoLibrary.ChengBenYuHeSuanAllLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAN SET " );
            //strSql.Append( "AN002=@AN002," );
            strSql.Append( "AN003=@AN003," );
            strSql.Append( "AN004=@AN004," );
            strSql.Append( "AN005=@AN005," );
            strSql.Append( "AN006=@AN006," );
            strSql.Append( "AN007=@AN007," );
            strSql.Append( "AN008=@AN008," );
            strSql.Append( "AN009=@AN009," );
            strSql.Append( "AN010=@AN010," );
            strSql.Append( "AN011=@AN011," );
            //strSql.Append( "AN012=@AN012," );
            //strSql.Append( "AN013=@AN013," );
            //strSql.Append( "AN014=@AN014," );
            strSql.Append( "AN015=@AN015," );
            strSql.Append( "AN016=@AN016," );
            strSql.Append( "AN017=@AN017," );
            strSql.Append( "AN018=@AN018," );
            strSql.Append( "AN019=@AN019," );
            strSql.Append( "AN020=@AN020," );
            strSql.Append( "AN021=@AN021," );
            strSql.Append( "AN022=@AN022," );
            strSql.Append( "AN023=@AN023," );
            strSql.Append( "AN024=@AN024," );
            strSql.Append( "AN025=@AN025" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@AN003",SqlDbType.NVarChar),
                new SqlParameter("@AN004",SqlDbType.NVarChar),
                new SqlParameter("@AN005",SqlDbType.NVarChar),
                new SqlParameter("@AN006",SqlDbType.BigInt),
                new SqlParameter("@AN007",SqlDbType.NVarChar,20),
                new SqlParameter("@AN008",SqlDbType.Date),
                new SqlParameter("@AN009",SqlDbType.Date),
                new SqlParameter("@AN010",SqlDbType.Date),
                new SqlParameter("@AN011",SqlDbType.NVarChar,20),
                new SqlParameter("@AN015",SqlDbType.Decimal),
                new SqlParameter("@AN016",SqlDbType.Decimal),
                new SqlParameter("@AN017",SqlDbType.Decimal),
                new SqlParameter("@AN018",SqlDbType.Decimal),
                new SqlParameter("@AN019",SqlDbType.Decimal),
                new SqlParameter("@AN020",SqlDbType.Decimal),
                new SqlParameter("@AN021",SqlDbType.Int),
                new SqlParameter("@AN022",SqlDbType.Decimal),
                new SqlParameter("@AN023",SqlDbType.NVarChar,20),
                new SqlParameter("@AN024",SqlDbType.NVarChar,2000),
                new SqlParameter("@AN025",SqlDbType.Decimal),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            
            parameter[0].Value = model.AN003;
            parameter[1].Value = model.AN004;
            parameter[2].Value = model.AN005;
            parameter[3].Value = model.AN006;
            parameter[4].Value = model.AN007;
            parameter[5].Value = model.AN008;
            parameter[6].Value = model.AN009;
            parameter[7].Value = model.AN010;
            parameter[8].Value = model.AN011;
            parameter[9].Value = model.AN015;
            parameter[10].Value = model.AN016;
            parameter[11].Value = model.AN017;
            parameter[12].Value = model.AN018;
            parameter[13].Value = model.AN019;
            parameter[14].Value = model.AN020;
            parameter[15].Value = model.AN021;
            parameter[16].Value = model.AN022;
            parameter[17].Value = model.AN023;
            parameter[18].Value = model.AN024;
            parameter[19].Value = model.AN025;
            parameter[20].Value = model.Idx;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }
        public bool AddOfPqw ( MulaolaoLibrary.ChengBenYuHeSuanAllLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAN (" );
            strSql.Append( "AN001,AN002,AN003,AN004,AN005,AN006,AN007,AN008,AN009,AN010,AN011,AN012,AN013,AN014,AN015,AN016,AN017,AN018,AN019,AN020,AN021,AN022,AN023,AN024,AN025)" );
            strSql.Append( " VALUES (" );
            strSql.Append( "@AN001,@AN002,@AN003,@AN004,@AN005,@AN006,@AN007,@AN008,@AN009,@AN010,@AN011,@AN012,@AN013,@AN014,@AN015,@AN016,@AN017,@AN018,@AN019,@AN020,@AN021,@AN022,@AN023,@AN024,@AN025)" );
            SqlParameter[] parameter = {
                new SqlParameter("@AN001",SqlDbType.NVarChar),
                new SqlParameter("@AN002",SqlDbType.NVarChar),
                new SqlParameter("@AN003",SqlDbType.NVarChar),
                new SqlParameter("@AN004",SqlDbType.NVarChar),
                new SqlParameter("@AN005",SqlDbType.NVarChar),
                new SqlParameter("@AN006",SqlDbType.BigInt),
                new SqlParameter("@AN007",SqlDbType.NVarChar,20),
                new SqlParameter("@AN008",SqlDbType.Date),
                new SqlParameter("@AN009",SqlDbType.Date),
                new SqlParameter("@AN010",SqlDbType.Date),
                new SqlParameter("@AN011",SqlDbType.NVarChar,20),
                new SqlParameter("@AN012",SqlDbType.NVarChar,50),
                new SqlParameter("@AN013",SqlDbType.NVarChar,20),
                new SqlParameter("@AN014",SqlDbType.NVarChar,20),
                new SqlParameter("@AN015",SqlDbType.Decimal),
                new SqlParameter("@AN016",SqlDbType.Decimal),
                new SqlParameter("@AN017",SqlDbType.Decimal),
                new SqlParameter("@AN018",SqlDbType.Decimal),
                new SqlParameter("@AN019",SqlDbType.Decimal),
                new SqlParameter("@AN020",SqlDbType.Decimal),
                new SqlParameter("@AN021",SqlDbType.Int),
                new SqlParameter("@AN022",SqlDbType.Decimal),
                new SqlParameter("@AN023",SqlDbType.NVarChar,20),
                new SqlParameter("@AN024",SqlDbType.NVarChar,2000),
                new SqlParameter("@AN025",SqlDbType.Decimal),
            };
            parameter[0].Value = model.AN001;
            parameter[1].Value = model.AN002;
            parameter[2].Value = model.AN003;
            parameter[3].Value = model.AN004;
            parameter[4].Value = model.AN005;
            parameter[5].Value = model.AN006;
            parameter[6].Value = model.AN007;
            parameter[7].Value = model.AN008;
            parameter[8].Value = model.AN009;
            parameter[9].Value = model.AN010;
            parameter[10].Value = model.AN011;
            parameter[11].Value = model.AN012;
            parameter[12].Value = model.AN013;
            parameter[13].Value = model.AN014;
            parameter[14].Value = model.AN015;
            parameter[15].Value = model.AN016;
            parameter[16].Value = model.AN017;
            parameter[17].Value = model.AN018;
            parameter[18].Value = model.AN019;
            parameter[19].Value = model.AN020;
            parameter[20].Value = model.AN021;
            parameter[21].Value = model.AN022;
            parameter[22].Value = model.AN023;
            parameter[23].Value = model.AN024;
            parameter[24].Value = model.AN025;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetChengCount (string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(*) FROM R_PQAN" );
            strSql.Append( " WHERE " + strWhere );

            object obj = SqlHelper.GetSingle( strSql.ToString( ) );
            if ( obj == null )
                return 0;
            else
                return Convert.ToInt32( obj );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableAll ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT AN001,AN002,AN003,AN004,AN005,AN006 FROM R_PQAN" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTableByPage ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,AN001,AN002,AN003,AN004,AN005,AN006 FROM (" );
            strSql.Append( "SELECT ROW_NUMBER() OVER(" );
            strSql.Append( "ORDER BY T.AN001 DESC" );
            strSql.Append( ") AS Row,T.* FROM R_PQAN T" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " WHERE " + strWhere );
            }
            strSql.Append( " ) TT" );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// get table for print
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable getPrintOne ( string num )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT AN003,AN004,AN005,AN002,AN008,AN009,AN010,AN011 FROM R_PQAN WHERE AN002='{0}'" ,num );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get table for print
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable getPrintTwo ( string num )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT AN012,AN013,AN014,CONVERT(DECIMAL(18,0),AN006*AN015) U0,CONVERT(FLOAT,AN015) AN015,CONVERT(FLOAT,AN016) AN016,CONVERT(FLOAT,AN017) AN017,CONVERT(FLOAT,AN018) AN018,CONVERT(FLOAT,CASE WHEN AN012='胶合板、密度板采购合同书(R_338)' OR AN012='木材采购合同书(R_341)' THEN AN017*AN006 ELSE AN006*AN015*AN018 END) U1,AN006,CONVERT(DECIMAL(18,2),CASE WHEN AN006=0 THEN 0 ELSE AN019/AN006 END) U2,CONVERT(FLOAT,AN019) AN019,CONVERT(DECIMAL(18,2),CASE WHEN AN006=0 THEN 0 ELSE AN020/AN006 END) U3,CONVERT(FLOAT,AN020) AN020,CONVERT(DECIMAL(18,2),CASE WHEN AN006=0 THEN 0 ELSE AN025/AN006 END) U4,CONVERT(FLOAT,AN025) AN025,CONVERT(DECIMAL(18,2),CASE WHEN AN006=0 THEN 0 ELSE AN022/AN006 END) U6,CONVERT(FLOAT,AN022) AN022,CONVERT(FLOAT,(CASE WHEN AN012='胶合板、密度板采购合同书(R_338)' OR AN012='木材采购合同书(R_341)' THEN AN017*AN006 ELSE AN006*AN015*AN018 END)-AN025) U5,CONVERT(DECIMAL(18,2),((CASE WHEN AN012='胶合板、密度板采购合同书(R_338)' OR AN012='木材采购合同书(R_341)' THEN AN017*AN006 ELSE AN006*AN015*AN018 END)-AN025)/AN006) U7,CONVERT(DECIMAL(18,0),(CASE WHEN AN012='胶合板、密度板采购合同书(R_338)' OR AN012='木材采购合同书(R_341)' THEN AN017*AN006 ELSE AN006*AN015*AN018 END)-AN025-AN022) U8,CONVERT(DECIMAL(18,2),CASE WHEN AN006=0 THEN 0 ELSE ((CASE WHEN AN012='胶合板、密度板采购合同书(R_338)' OR AN012='木材采购合同书(R_341)' THEN AN017*AN006 ELSE AN006*AN015*AN018 END)-AN025-AN022)/AN006 END) U9,AN023,AN024 FROM R_PQAN WHERE AN002='{0}'" ,num );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}


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
    public class GunQiChengLanJiaGongDao
    {
        /// <summary>
        /// 是否存在一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists (MulaolaoLibrary.GunQiChengLanJiaGongLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQLZ" );
            strSql.Append( " WHERE LZ002=@LZ002 AND LZ015=@LZ015 AND LZ017=@LZ017 AND LZ018=@LZ018 AND LZ019=@LZ019 AND LZ031=@LZ031" );
            SqlParameter[] parameter = {
                new SqlParameter("@LZ002",SqlDbType.NVarChar,20),
                new SqlParameter("@LZ015",SqlDbType.NVarChar,20),
                new SqlParameter("@LZ017",SqlDbType.NVarChar,20),
                new SqlParameter("@LZ018",SqlDbType.NVarChar,20),
                new SqlParameter("@LZ019",SqlDbType.NVarChar,20),
                new SqlParameter("@LZ031",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = model.LZ002;
            parameter[1].Value = model.LZ015;
            parameter[2].Value = model.LZ017;
            parameter[3].Value = model.LZ018;
            parameter[4].Value = model.LZ019;
            parameter[5].Value = model.LZ031;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }
        
        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert ( MulaolaoLibrary.GunQiChengLanJiaGongLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQLZ (" );//LZ025,
            strSql.Append( "LZ001,LZ002,LZ006,LZ015,LZ016,LZ017,LZ018,LZ019,LZ020,LZ021,LZ022,LZ023,LZ024,LZ026,LZ029,LZ031,LZ032,LZ033,LZ034,LZ035)" );
            strSql.Append( " VALUES (" );//@LZ025,
            strSql.Append( "@LZ001,@LZ002,@LZ006,@LZ015,@LZ016,@LZ017,@LZ018,@LZ019,@LZ020,@LZ021,@LZ022,@LZ023,@LZ024,@LZ026,@LZ029,@LZ031,@LZ032,@LZ033,@LZ034,@LZ035);" );
            strSql.Append( "SELECT SCOPE_IDENTITY();" );
            SqlParameter[] parameter = {
                new SqlParameter("@LZ001",SqlDbType.NVarChar,20),
                new SqlParameter("@LZ015",SqlDbType.NVarChar,20),
                new SqlParameter("@LZ016",SqlDbType.NVarChar,20),
                new SqlParameter("@LZ017",SqlDbType.NVarChar,20),
                new SqlParameter("@LZ018",SqlDbType.NVarChar,20),
                new SqlParameter("@LZ019",SqlDbType.NVarChar,20),
                new SqlParameter("@LZ020",SqlDbType.Decimal,1),
                new SqlParameter("@LZ021",SqlDbType.Int),
                new SqlParameter("@LZ022",SqlDbType.Decimal,7),
                //new SqlParameter("@LZ025",SqlDbType.Decimal,6),
                new SqlParameter("@LZ024",SqlDbType.Decimal,6),
                new SqlParameter("@LZ023",SqlDbType.Decimal,6),
                new SqlParameter("@LZ026",SqlDbType.Int),
                new SqlParameter("@LZ006",SqlDbType.BigInt),
                new SqlParameter("@LZ029",SqlDbType.NVarChar,20),
                new SqlParameter("@LZ002",SqlDbType.NVarChar,20),
                new SqlParameter("@LZ031",SqlDbType.NVarChar,20),
                new SqlParameter("@LZ032",SqlDbType.Decimal,4),
                new SqlParameter("@LZ033",SqlDbType.NVarChar,255),
                new SqlParameter("@LZ034",SqlDbType.Decimal,6),
                new SqlParameter("@LZ035",SqlDbType.NVarChar,4)
            };
            parameter[0].Value = model.LZ001;
            parameter[1].Value = model.LZ015;
            parameter[2].Value = model.LZ016;
            parameter[3].Value = model.LZ017;
            parameter[4].Value = model.LZ018;
            parameter[5].Value = model.LZ019;
            parameter[6].Value = model.LZ020;
            parameter[7].Value = model.LZ021;
            parameter[8].Value = model.LZ022;
            //parameter[9].Value = model.LZ025;
            parameter[9].Value = model.LZ024;
            parameter[10].Value = model.LZ023;
            parameter[11].Value = model.LZ026;
            parameter[12].Value = model.LZ006;
            parameter[13].Value = model.LZ029;
            parameter[14].Value = model.LZ002;
            parameter[15].Value = model.LZ031;
            parameter[16].Value = model.LZ032;
            parameter[17].Value = model.LZ033;
            parameter[18].Value = model.LZ034;
            parameter[19].Value = model.LZ035;

            int row = SqlHelper.ExecuteSqlReturnId( strSql.ToString( ) ,parameter );
            return row;
        }
        
        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.GunQiChengLanJiaGongLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQLZ SET " );
            strSql.Append( "LZ006=@LZ006," );
            strSql.Append( "LZ015=@LZ015," );
            strSql.Append( "LZ016=@LZ016," );
            strSql.Append( "LZ017=@LZ017," );
            strSql.Append( "LZ018=@LZ018," );
            strSql.Append( "LZ019=@LZ019," );
            strSql.Append( "LZ020=@LZ020," );
            strSql.Append( "LZ021=@LZ021," );
            strSql.Append( "LZ022=@LZ022," );
            strSql.Append( "LZ023=@LZ023," );
            strSql.Append( "LZ024=@LZ024," );
            //strSql.Append( "LZ025=@LZ025," );
            strSql.Append( "LZ026=@LZ026," );
            strSql.Append( "LZ029=@LZ029," );
            strSql.Append( "LZ031=@LZ031," );
            strSql.Append( "LZ032=@LZ032," );
            strSql.Append( "LZ033=@LZ033," );
            strSql.Append( "LZ034=@LZ034," );
            strSql.Append( "LZ035=@LZ035" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@LZ016",SqlDbType.NVarChar,20),
                new SqlParameter("@LZ020",SqlDbType.Decimal,5),
                new SqlParameter("@LZ021",SqlDbType.Int),
                new SqlParameter("@LZ022",SqlDbType.Decimal,7),
                //new SqlParameter("@LZ025",SqlDbType.Decimal,6),
                new SqlParameter("@LZ024",SqlDbType.Decimal,6),
                new SqlParameter("@LZ023",SqlDbType.Decimal,6),
                new SqlParameter("@LZ026",SqlDbType.Int),
                new SqlParameter("@idx",SqlDbType.Int),
                new SqlParameter("@LZ006",SqlDbType.BigInt),
                new SqlParameter("@LZ015",SqlDbType.NVarChar,20),
                new SqlParameter("@LZ017",SqlDbType.NVarChar,20),
                new SqlParameter("@LZ018",SqlDbType.NVarChar,20),
                new SqlParameter("@LZ019",SqlDbType.NVarChar,20),
                new SqlParameter("@LZ029",SqlDbType.NVarChar,20),
                new SqlParameter("@LZ031",SqlDbType.NVarChar,20),
                new SqlParameter("@LZ032",SqlDbType.Decimal,4),
                new SqlParameter("@LZ033",SqlDbType.NVarChar,255),
                new SqlParameter("@LZ034",SqlDbType.Decimal,6),
                new SqlParameter("@LZ035",SqlDbType.NVarChar,4)
            };
            parameter[0].Value = model.LZ016;
            parameter[1].Value = model.LZ020;
            parameter[2].Value = model.LZ021;
            parameter[3].Value = model.LZ022;
            //parameter[4].Value = model.LZ025;
            parameter[4].Value = model.LZ024;
            parameter[5].Value = model.LZ023;
            parameter[6].Value = model.LZ026;
            parameter[7].Value = model.IDX;
            parameter[8].Value = model.LZ006;
            parameter[9].Value = model.LZ015;
            parameter[10].Value = model.LZ017;
            parameter[11].Value = model.LZ018;
            parameter[12].Value = model.LZ019;
            parameter[13].Value = model.LZ029;
            parameter[14].Value = model.LZ031;
            parameter[15].Value = model.LZ032;
            parameter[16].Value = model.LZ033;
            parameter[17].Value = model.LZ034;
            parameter[18].Value = model.LZ035;
            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete ( MulaolaoLibrary.GunQiChengLanJiaGongLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQLZ" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = model.IDX;

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
        public MulaolaoLibrary.GunQiChengLanJiaGongLibrary GetModel ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQLZ" );
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
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.GunQiChengLanJiaGongLibrary GetModel ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQLZ" );
            strSql.Append( " WHERE LZ001=@LZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@LZ001",SqlDbType.NVarChar,20)
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
        public MulaolaoLibrary.GunQiChengLanJiaGongLibrary GetDataRow ( DataRow row )
        {
            MulaolaoLibrary.GunQiChengLanJiaGongLibrary model = new MulaolaoLibrary.GunQiChengLanJiaGongLibrary( );
            if ( row !=null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    model.IDX = int.Parse( row["idx"].ToString( ) );
                if ( row["LZ001"] != null && row["LZ001"].ToString( ) != "" )
                    model.LZ001 = row["LZ001"].ToString( );
                if ( row["LZ002"] != null && row["LZ002"].ToString( ) != "" )
                    model.LZ002 = row["LZ002"].ToString( );
                if ( row["LZ003"] != null && row["LZ003"].ToString( ) != "" )
                    model.LZ003 = row["LZ003"].ToString( );
                if ( row["LZ004"] != null && row["LZ004"].ToString( ) != "" )
                    model.LZ004 = row["LZ004"].ToString( );
                if ( row["LZ005"] != null && row["LZ005"].ToString( ) != "" )
                    model.LZ005 = row["LZ005"].ToString( );
                if ( row["LZ006"] != null && row["LZ006"].ToString( ) != "" )
                    model.LZ006 = long.Parse( row["LZ006"].ToString( ) );
                if ( row["LZ007"] != null && row["LZ007"].ToString( ) != "" )
                    model.LZ007 = DateTime.Parse( row["LZ007"].ToString( ) );
                if ( row["LZ008"] != null && row["LZ008"].ToString( ) != "" )
                    model.LZ008 = DateTime.Parse( row["LZ008"].ToString( ) );
                if ( row["LZ009"] != null && row["LZ009"].ToString( ) != "" )
                    model.LZ009 = row["LZ009"].ToString( );
                if ( row["LZ010"] != null && row["LZ010"].ToString( ) != "" )
                    model.LZ010 = DateTime.Parse( row["LZ010"].ToString( ) );
                if ( row["LZ011"] != null && row["LZ011"].ToString( ) != "" )
                    model.LZ011 = row["LZ011"].ToString( );
                if ( row["LZ012"] != null && row["LZ012"].ToString( ) != "" )
                    model.LZ012 = DateTime.Parse( row["LZ012"].ToString( ) );
                if ( row["LZ013"] != null && row["LZ013"].ToString( ) != "" )
                    model.LZ013 = row["LZ013"].ToString( );
                if ( row["LZ014"] != null && row["LZ014"].ToString( ) != "" )
                    model.LZ014 = DateTime.Parse( row["LZ014"].ToString( ) );
                if ( row["LZ015"] != null && row["LZ015"].ToString( ) != "" )
                    model.LZ015 = row["LZ015"].ToString( );
                if ( row["LZ016"] != null && row["LZ016"].ToString( ) != "" )
                    model.LZ016 = row["LZ016"].ToString( );
                if ( row["LZ017"] != null && row["LZ017"].ToString( ) != "" )
                    model.LZ017 = row["LZ017"].ToString( );
                if ( row["LZ018"] != null && row["LZ018"].ToString( ) != "" )
                    model.LZ018 = row["LZ018"].ToString( );
                if ( row["LZ019"] != null && row["LZ019"].ToString( ) != "" )
                    model.LZ019 = row["LZ019"].ToString( );
                if ( row["LZ020"] != null && row["LZ020"].ToString( ) != "" )
                    model.LZ020 = decimal.Parse( row["LZ020"].ToString( ) );
                if ( row["LZ021"] != null && row["LZ021"].ToString( ) != "" )
                    model.LZ021 = int.Parse( row["LZ021"].ToString( ) );
                if ( row["LZ022"] != null && row["LZ022"].ToString( ) != "" )
                    model.LZ022 = decimal.Parse( row["LZ022"].ToString( ) );
                if ( row["LZ023"] != null && row["LZ023"].ToString( ) != "" )
                    model.LZ023 = decimal.Parse( row["LZ023"].ToString( ) );
                if ( row["LZ024"] != null && row["LZ024"].ToString( ) != "" )
                    model.LZ024 = decimal.Parse( row["LZ024"].ToString( ) );
                //if ( row["LZ025"] != null && row["LZ025"].ToString( ) != "" )
                //    model.LZ025 = decimal.Parse( row["LZ025"].ToString( ) );
                if ( row["LZ026"] != null && row["LZ026"].ToString( ) != "" )
                    model.LZ026 = int.Parse( row["LZ026"].ToString( ) );
                if ( row["LZ027"] != null && row["LZ027"].ToString( ) != "" )
                    model.LZ027 = row["LZ027"].ToString( );
                if ( row["LZ029"] != null && row["LZ029"].ToString( ) != "" )
                    model.LZ029 = row["LZ029"].ToString( );
                if ( row["LZ030"] != null && row["LZ030"].ToString( ) != "" )
                    model.LZ030 = row["LZ030"].ToString( );
                if ( row["LZ031"] != null && row["LZ031"].ToString( ) != "" )
                    model.LZ031 = row["LZ031"].ToString( );
                if ( row["LZ032"] != null && row["LZ032"].ToString( ) != "" )
                    model.LZ032 = decimal.Parse( row["LZ032"].ToString( ) );
                if ( row["LZ033"] != null && row["LZ033"].ToString( ) != "" )
                    model.LZ033 = row["LZ033"].ToString( );
                if ( row["LZ034"] != null && row["LZ034"].ToString( ) != "" )
                    model.LZ034 = decimal.Parse( row["LZ034"].ToString( ) );
                if ( row["LZ035"] != null && row["LZ035"].ToString( ) != "" )
                    model.LZ035 = row["LZ035"].ToString( );
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
            strSql.Append( "SELECT * FROM R_PQLZ" );
            strSql.Append( " WHERE " + strWhere );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableNums ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT PQF01,PQF04,PQF02,PQF03,PQF06,PQF31,HT04,PQF07,PQF08 FROM R_PQF A,R_PQL B,R_REVIEWS C WHERE A.PQF01=B.HT01 AND A.PQF02=B.HT02 AND A.PQF01=C.RES06 AND RES05='执行' ORDER BY PQF01 DESC" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount (string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM (SELECT LZ001,LZ002,LZ003,LZ004,LZ005,LZ006,LZ013,CONVERT(DECIMAL(18,0),SUM(LZ022*LZ006*LZ023+LZ026)) LZ0,CONVERT(DECIMAL(18,0),SUM(LZ022*LZ006*LZ034)) LZ1 FROM R_PQLZ" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( " GROUP BY LZ001,LZ002,LZ003,LZ004,LZ005,LZ006,LZ013) A" );

            object obj = SqlHelper.GetSingle( strSql.ToString( ) );
            if ( obj != null )
                return Convert.ToInt32( obj );
            else
                return 0;
        }
        public int GetCounts ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM (SELECT A.idx,LZ001,LZ002,LZ003,LZ004,LZ005,LZ006,LZ013,CONVERT(INT,SUM(LZ022*LZ006*LZ023+LZ026)) LZ0,CONVERT(DECIMAL(18,0),SUM(LZ022*LZ006*LZ034)) LZ1 FROM R_PQLZ A,R_REVIEWS B WHERE A.LZ001=B.RES06 AND RES05='执行'" );
            strSql.Append( " AND " + strWhere );
            strSql.Append( " GROUP BY LZ001,LZ002,LZ003,LZ004,LZ005,LZ006,LZ013,A.idx) A" );

            object obj = SqlHelper.GetSingle( strSql.ToString( ) );
            if ( obj != null )
                return Convert.ToInt32( obj );
            else
                return 0;
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
            strSql.Append( "SELECT DISTINCT LZ001,LZ002,LZ003,LZ004,LZ005,LZ006,LZ013,CONVERT(DECIMAL(18,0),SUM(LZ022*LZ006*LZ023+LZ026)) LZ0,CONVERT(DECIMAL(18,0),SUM(LZ022*LZ006*LZ034)) LZ1,(SELECT RES05 FROM R_REVIEWS WHERE RES04=(SELECT MAX(RES04) FROM R_REVIEWS WHERE RES06=LZ001)) RES05 FROM (" );
            strSql.Append( "SELECT ROW_NUMBER() OVER(" );
            strSql.Append( "ORDER BY T.LZ001 DESC" );
            strSql.Append( ") AS Row,T.* FROM R_PQLZ T" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") TT" );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );
            strSql.Append( " GROUP BY LZ001,LZ002,LZ003,LZ004,LZ005,LZ006,LZ013 ORDER BY LZ001 DESC" );
             
            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableByPages ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT TT.idx,LZ001,LZ002,LZ003,LZ004,LZ005,LZ006,LZ013,CONVERT(INT,SUM(LZ022*LZ006*LZ024+LZ026)) LZ0,CONVERT(DECIMAL(18,0),SUM(LZ022*LZ006*LZ034)) LZ1,RES05 FROM (" );
            strSql.Append( "SELECT ROW_NUMBER() OVER(" );
            strSql.Append( "ORDER BY T.LZ001 DESC" );
            strSql.Append( ") AS Row,T.* FROM R_PQLZ T" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") TT,R_REVIEWS B WHERE TT.LZ001=B.RES06 AND RES05='执行'" );
            strSql.AppendFormat( " AND TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );
            strSql.Append( " GROUP BY LZ001,LZ002,LZ003,LZ004,LZ005,LZ006,LZ013,RES05,TT.idx ORDER BY LZ001 DESC" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT LZ001,LZ002,LZ003,LZ004,LZ005 FROM R_PQLZ" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DeleteAll ( string oddNum )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQLZ" );
            strSql.AppendFormat( " WHERE LZ001='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            StringBuilder strS = new StringBuilder( );
            strS.Append( "DELETE FROM R_REVIEWS" );
            strS.AppendFormat( " WHERE RES06='{0}'" ,oddNum );
            SQLString.Add( strS.ToString( ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateAll ( MulaolaoLibrary.GunQiChengLanJiaGongLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQLZ SET " );
            strSql.Append( "LZ002=@LZ002," );
            strSql.Append( "LZ003=@LZ003," );
            strSql.Append( "LZ004=@LZ004," );
            strSql.Append( "LZ005=@LZ005," );
            strSql.Append( "LZ006=@LZ006," );
            strSql.Append( "LZ007=@LZ007," );
            strSql.Append( "LZ008=@LZ008," );
            strSql.Append( "LZ009=@LZ009," );
            strSql.Append( "LZ010=@LZ010," );
            strSql.Append( "LZ011=@LZ011," );
            strSql.Append( "LZ012=@LZ012," );
            strSql.Append( "LZ013=@LZ013," );
            strSql.Append( "LZ014=@LZ014," );
            strSql.Append( "LZ027=@LZ027," );
            strSql.Append( "LZ028=@LZ028," );
            strSql.Append( "LZ029=@LZ029," );
            strSql.Append( "LZ030=@LZ030" );
            strSql.Append( " WHERE LZ001=@LZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@LZ001",SqlDbType.NVarChar,20),
                new SqlParameter("@LZ002",SqlDbType.NVarChar,20),
                new SqlParameter("@LZ003",SqlDbType.NVarChar,20),
                new SqlParameter("@LZ004",SqlDbType.NVarChar,20),
                new SqlParameter("@LZ005",SqlDbType.NVarChar,20),
                new SqlParameter("@LZ006",SqlDbType.BigInt),
                new SqlParameter("@LZ007",SqlDbType.Date),
                new SqlParameter("@LZ008",SqlDbType.Date),
                new SqlParameter("@LZ009",SqlDbType.NVarChar,20),
                new SqlParameter("@LZ010",SqlDbType.Date),
                new SqlParameter("@LZ011",SqlDbType.NVarChar,20),
                new SqlParameter("@LZ012",SqlDbType.Date),
                new SqlParameter("@LZ013",SqlDbType.NVarChar,20),
                new SqlParameter("@LZ014",SqlDbType.Date),
                new SqlParameter("@LZ028",SqlDbType.NVarChar,2000),
                new SqlParameter("@LZ029",SqlDbType.NVarChar,20),
                new SqlParameter("@LZ030",SqlDbType.NVarChar,20),
                new SqlParameter("@LZ027",SqlDbType.NVarChar,2000)
            };
            parameter[0].Value = model.LZ001;
            parameter[1].Value = model.LZ002;
            parameter[2].Value = model.LZ003;
            parameter[3].Value = model.LZ004;
            parameter[4].Value = model.LZ005;
            parameter[5].Value = model.LZ006;
            parameter[6].Value = model.LZ007;
            parameter[7].Value = model.LZ008;
            parameter[8].Value = model.LZ009;
            parameter[9].Value = model.LZ010;
            parameter[10].Value = model.LZ011;
            parameter[11].Value = model.LZ012;
            parameter[12].Value = model.LZ013;
            parameter[13].Value = model.LZ014;
            parameter[14].Value = model.LZ028;
            parameter[15].Value = model.LZ029;
            parameter[16].Value = model.LZ030;
            parameter[17].Value = model.LZ027;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableWeiHu ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT LZ028 FROM R_PQLZ" );
            strSql.Append( " WHERE LZ001=@LZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@LZ001",SqlDbType.NVarChar)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTableWu ( string oddNum,string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT LZ015,LZ017,LZ018,LZ019 FROM R_PQLZ" );
            strSql.Append( " WHERE LZ001!=@LZ001 AND LZ002=@LZ002" );
            SqlParameter[] parameter = {
                new SqlParameter("@LZ001",SqlDbType.NVarChar,20),
                new SqlParameter("@LZ002",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;
            parameter[1].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Copy ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQLZ (" );
            strSql.Append( "LZ002,LZ003,LZ004,LZ005,LZ006,LZ007,LZ008,LZ015,LZ016,LZ017,LZ018,LZ019,LZ020,LZ021,LZ022,LZ023,LZ024,LZ025,LZ026,LZ031,LZ032,LZ033,LZ034,LZ035)" );
            strSql.Append( " SELECT LZ002,LZ003,LZ004,LZ005,LZ006,LZ007,LZ008,LZ015,LZ016,LZ017,LZ018,LZ019,LZ020,LZ021,LZ022,LZ023,LZ024,LZ025,LZ026,LZ031,LZ032,LZ033,LZ034,LZ035 FROM R_PQLZ" );
            strSql.Append( " WHERE LZ001=@LZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@LZ001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 更改一单记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateCopy ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQLZ SET LZ001=@LZ001 WHERE LZ001 IS NULL" );
            SqlParameter[] parameter = {
                new SqlParameter("@LZ001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <returns></returns>
        public bool DeleteCopy ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQLZ WHERE LZ001 IS NULL" );

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTableOther ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT LZ015,LZ017,LZ021,LZ022,LZ024,LZ026 FROM R_PQLZ" );
            strSql.Append( " WHERE LZ002=@LZ002" );
            SqlParameter[] parameter = {
                new SqlParameter("@LZ002",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTableReadOf ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT GS07 LZ015,GS08 LZ017 FROM R_PQP WHERE GS01=@GS01 AND GS07!=''" );
            SqlParameter[] parameter = {
                new SqlParameter("@GS01",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取打印数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintOne ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT LZ003,LZ004,LZ005,LZ002,LZ006,CONVERT(VARCHAR(20),LZ007,102) LZ007,CONVERT(VARCHAR(20),LZ008,102) LZ008,LZ011,CONVERT(VARCHAR(20),LZ012,102) LZ012,LZ029,LZ013,CONVERT(VARCHAR(20),LZ014,102) LZ014 FROM R_PQLZ" );
            strSql.Append( " WHERE LZ001=@LZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@LZ001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public DataTable GetDataTablePrintTwo ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT LZ015,LZ016,LZ017,LZ032,LZ006,LZ019,LZ020,LZ021,LZ022,CONVERT(DECIMAL(18,2),LZ022*LZ006) LZ0,LZ023,LZ025,CONVERT(DECIMAL(18,2),LZ022*LZ006*LZ023) LZ1,LZ026,LZ033,LZ034,CONVERT(DECIMAL(18,2),LZ022*LZ006*LZ034) LZ2 FROM R_PQLZ" );
            strSql.Append( " WHERE LZ001=@LZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@LZ001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
    }
}

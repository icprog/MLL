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
    public class ZuZhangGongZiKaoHdDao
    {
        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsAzAdd ( MulaolaoLibrary.ZuZhangGongZiKaoHeHdAzLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQAZ" );
            strSql.Append( " WHERE HD074=@HD074 AND HD001=@HD001 AND HD002=@HD002 AND HD003=@HD003" );
            SqlParameter[] parameter = {
                new SqlParameter("@HD074",SqlDbType.NVarChar),
                new SqlParameter("@HD001",SqlDbType.NVarChar),
                new SqlParameter("@HD002",SqlDbType.VarChar),
                new SqlParameter("@HD003",SqlDbType.NVarChar)
            };

            parameter[0].Value = model.HD074;
            parameter[1].Value = model.HD001;
            parameter[2].Value = model.HD002;
            parameter[3].Value = model.HD003;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool ExistsIdxBz ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQBZ" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };

            parameter[0].Value = idx;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表   组长姓名
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableName ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "WITH CET AS (" );
            strSql.Append( " SELECT * FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002='生产部')" );
            strSql.Append( ") ,CFT AS (" );
            strSql.Append( " SELECT * FROM TPADAA WHERE DAA002 IN (SELECT DBA002 FROM CET)" );
            strSql.Append( " ) SELECT DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM CFT)" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add (MulaolaoLibrary.ZuZhangGongZiKaoHeHdAzLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAZ (" );
            strSql.Append( "HD001,HD002,HD003,HD004,HD005,HD007,HD008,HD009,HD011,HD012,HD014,HD015,HD017,HD018,HD019,HD074,HD094)" );
            strSql.Append( " VALUES (" );
            strSql.Append( "@HD001,@HD002,@HD003,@HD004,@HD005,@HD007,@HD008,@HD009,@HD011,@HD012,@HD014,@HD015,@HD017,@HD018,@HD019,@HD074,@HD094);" );
            strSql.Append( "SELECT SCOPE_IDENTITY();" );
            SqlParameter[] parameter = {
                new SqlParameter("@HD001",SqlDbType.NVarChar),
                new SqlParameter("@HD002",SqlDbType.VarChar),
                new SqlParameter("@HD003",SqlDbType.NVarChar),
                new SqlParameter("@HD004",SqlDbType.Decimal),
                new SqlParameter("@HD005",SqlDbType.Decimal),
                new SqlParameter("@HD007",SqlDbType.Decimal),
                new SqlParameter("@HD008",SqlDbType.Decimal),
                new SqlParameter("@HD009",SqlDbType.Decimal),
                new SqlParameter("@HD011",SqlDbType.Int),
                new SqlParameter("@HD012",SqlDbType.Decimal),
                new SqlParameter("@HD014",SqlDbType.Decimal),
                new SqlParameter("@HD015",SqlDbType.Decimal),
                new SqlParameter("@HD017",SqlDbType.Decimal),
                new SqlParameter("@HD018",SqlDbType.Decimal),
                new SqlParameter("@HD019",SqlDbType.Decimal),
                new SqlParameter("@HD074",SqlDbType.NVarChar),
                new SqlParameter("@HD094",SqlDbType.NVarChar)
            };

            parameter[0].Value = model.HD001;
            parameter[1].Value = model.HD002;
            parameter[2].Value = model.HD003;
            parameter[3].Value = model.HD004;
            parameter[4].Value = model.HD005;
            parameter[5].Value = model.HD007;
            parameter[6].Value = model.HD008;
            parameter[7].Value = model.HD009;
            parameter[8].Value = model.HD011;
            parameter[9].Value = model.HD012;
            parameter[10].Value = model.HD014;
            parameter[11].Value = model.HD015;
            parameter[12].Value = model.HD017;
            parameter[13].Value = model.HD018;
            parameter[14].Value = model.HD019;
            parameter[15].Value = model.HD074;
            parameter[16].Value = model.HD094;

            int idx = SqlHelper.ExecuteSqlReturnId( strSql.ToString( ) ,parameter );
            return idx;
        }

        /// <summary>
        /// 复制数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public bool Copy ( MulaolaoLibrary . ZuZhangGongZiKaoHeHdAzLibrary model ,string dateTime)
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQAZ (" );
            strSql . Append ( "HD001,HD002,HD003,HD004,HD005,HD007,HD008,HD009,HD011,HD012,HD014,HD015,HD017,HD018,HD019,HD074,HD094)" );
            strSql . Append ( " VALUES (" );
            strSql . Append ( "@HD001,@HD002,@HD003,@HD004,@HD005,@HD007,@HD008,@HD009,@HD011,@HD012,@HD014,@HD015,@HD017,@HD018,@HD019,@HD074,@HD094);" );
            //strSql . Append ( "SELECT SCOPE_IDENTITY();" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@HD001",SqlDbType.NVarChar),
                new SqlParameter("@HD002",SqlDbType.VarChar),
                new SqlParameter("@HD003",SqlDbType.NVarChar),
                new SqlParameter("@HD004",SqlDbType.Decimal),
                new SqlParameter("@HD005",SqlDbType.Decimal),
                new SqlParameter("@HD007",SqlDbType.Decimal),
                new SqlParameter("@HD008",SqlDbType.Decimal),
                new SqlParameter("@HD009",SqlDbType.Decimal),
                new SqlParameter("@HD011",SqlDbType.Int),
                new SqlParameter("@HD012",SqlDbType.Decimal),
                new SqlParameter("@HD014",SqlDbType.Decimal),
                new SqlParameter("@HD015",SqlDbType.Decimal),
                new SqlParameter("@HD017",SqlDbType.Decimal),
                new SqlParameter("@HD018",SqlDbType.Decimal),
                new SqlParameter("@HD019",SqlDbType.Decimal),
                new SqlParameter("@HD074",SqlDbType.NVarChar),
                new SqlParameter("@HD094",SqlDbType.NVarChar)
            };

            parameter [ 0 ] . Value = model . HD001;
            parameter [ 1 ] . Value = model . HD002;
            parameter [ 2 ] . Value = model . HD003;
            parameter [ 3 ] . Value = model . HD004;
            parameter [ 4 ] . Value = model . HD005;
            parameter [ 5 ] . Value = model . HD007;
            parameter [ 6 ] . Value = model . HD008;
            parameter [ 7 ] . Value = model . HD009;
            parameter [ 8 ] . Value = model . HD011;
            parameter [ 9 ] . Value = model . HD012;
            parameter [ 10 ] . Value = model . HD014;
            parameter [ 11 ] . Value = model . HD015;
            parameter [ 12 ] . Value = model . HD017;
            parameter [ 13 ] . Value = model . HD018;
            parameter [ 14 ] . Value = model . HD019;
            parameter [ 15 ] . Value = model . HD074;
            parameter [ 16 ] . Value = model . HD094;
            SQLString . Add ( strSql ,parameter );
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "INSERT INTO R_PQBZ (HD077,HD078,HD079,HD080,HD021,HD081,HD082,HD084,HD085,HD088,HD089,HD086,HD087,HD083,HD022,HD023,HD024,HD025,HD026,HD027,HD028,HD029,HD030,HD031,HD032,HD033,HD034,HD035,HD036,HD037,HD038,HD039,HD040,HD041,HD042,HD043,HD044,HD045,HD046,HD047,HD048,HD049,HD050,HD051,HD052,HD053,HD054,HD055,HD056,HD057,HD058,HD059,HD060,HD061,HD062,HD063,HD064,HD065,HD066,HD067,HD068,HD069,HD070,HD071,HD072,HD073,HD090,HD091,HD092,HD093) SELECT HD077,HD078,HD079,'{2}' HD080,HD021,HD081,HD082,HD084,HD085,HD088,HD089,HD086,HD087,HD083,HD022,HD023,HD024,HD025,HD026,HD027,HD028,HD029,HD030,HD031,HD032,HD033,HD034,HD035,HD036,HD037,HD038,HD039,HD040,HD041,HD042,HD043,HD044,HD045,HD046,HD047,HD048,HD049,HD050,HD051,HD052,HD053,HD054,HD055,HD056,HD057,HD058,HD059,HD060,HD061,HD062,HD063,HD064,HD065,HD066,HD067,HD068,HD069,HD070,HD071,HD072,HD073,HD090,HD091,HD092,HD093 FROM R_PQBZ WHERE HD077='{0}' AND HD080='{1}'" ,model . HD074 ,dateTime ,model . HD003 );
            SQLString . Add ( strSql ,null );
            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.ZuZhangGongZiKaoHeHdAzLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAZ SET " );
            strSql.Append( "HD001=@HD001," );
            strSql.Append( "HD002=@HD002," );
            strSql.Append( "HD003=@HD003," );
            strSql.Append( "HD004=@HD004," );
            strSql.Append( "HD005=@HD005," );
            strSql.Append( "HD007=@HD007," );
            strSql.Append( "HD008=@HD008," );
            strSql.Append( "HD009=@HD009," );
            strSql.Append( "HD011=@HD011," );
            strSql.Append( "HD012=@HD012," );
            strSql.Append( "HD014=@HD014," );
            strSql.Append( "HD015=@HD015," );
            strSql.Append( "HD017=@HD017," );
            strSql.Append( "HD018=@HD018," );
            strSql.Append( "HD019=@HD019," );
            strSql.Append( "HD074=@HD074," );
            strSql.Append( "HD094=@HD094" );
            strSql.Append( " WHERE idx=@idx" );

            SqlParameter[] parameter = {
                new SqlParameter("@HD001",SqlDbType.NVarChar),
                new SqlParameter("@HD002",SqlDbType.VarChar),
                new SqlParameter("@HD003",SqlDbType.NVarChar),
                new SqlParameter("@HD004",SqlDbType.Decimal),
                new SqlParameter("@HD005",SqlDbType.Decimal),
                new SqlParameter("@HD007",SqlDbType.Decimal),
                new SqlParameter("@HD008",SqlDbType.Decimal),
                new SqlParameter("@HD009",SqlDbType.Decimal),
                new SqlParameter("@HD011",SqlDbType.Int),
                new SqlParameter("@HD012",SqlDbType.Decimal),
                new SqlParameter("@HD014",SqlDbType.Decimal),
                new SqlParameter("@HD015",SqlDbType.Decimal),
                new SqlParameter("@HD017",SqlDbType.Decimal),
                new SqlParameter("@HD018",SqlDbType.Decimal),
                new SqlParameter("@HD019",SqlDbType.Decimal),
                new SqlParameter("@HD074",SqlDbType.NVarChar),
                new SqlParameter("@HD094",SqlDbType.NVarChar),
                new SqlParameter("@idx",SqlDbType.Int)
            };

            parameter[0].Value = model.HD001;
            parameter[1].Value = model.HD002;
            parameter[2].Value = model.HD003;
            parameter[3].Value = model.HD004;
            parameter[4].Value = model.HD005;
            parameter[5].Value = model.HD007;
            parameter[6].Value = model.HD008;
            parameter[7].Value = model.HD009;
            parameter[8].Value = model.HD011;
            parameter[9].Value = model.HD012;
            parameter[10].Value = model.HD014;
            parameter[11].Value = model.HD015;
            parameter[12].Value = model.HD017;
            parameter[13].Value = model.HD018;
            parameter[14].Value = model.HD019;
            parameter[15].Value = model.HD074;
            parameter[16].Value = model.HD094;
            parameter[17].Value = model.IDX;

            int rows = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( rows > 0 )
                return true;
            else
                return false;
        }


        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddBz ( MulaolaoLibrary.ZuZhangGongZiKaoHeBzLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQBZ (" );
            strSql.Append( "HD021,HD022,HD023,HD024,HD025,HD026,HD027,HD028,HD029,HD030,HD031,HD032,HD033,HD034,HD035,HD036,HD037,HD038,HD039,HD040,HD041,HD042,HD043,HD044,HD045,HD046,HD047,HD048,HD049,HD050,HD051,HD052,HD053,HD054,HD055,HD056,HD057,HD058,HD059,HD060,HD061,HD062,HD063,HD064,HD065,HD066,HD067,HD068,HD069,HD070,HD071,HD072,HD073,HD077,HD078,HD079,HD080,HD081,HD082,HD083,HD086,HD087)" );
            strSql.Append( " VALUES (" );
            strSql.Append( "@HD021,@HD022,@HD023,@HD024,@HD025,@HD026,@HD027,@HD028,@HD029,@HD030,@HD031,@HD032,@HD033,@HD034,@HD035,@HD036,@HD037,@HD038,@HD039,@HD040,@HD041,@HD042,@HD043,@HD044,@HD045,@HD046,@HD047,@HD048,@HD049,@HD050,@HD051,@HD052,@HD053,@HD054,@HD055,@HD056,@HD057,@HD058,@HD059,@HD060,@HD061,@HD062,@HD063,@HD064,@HD065,@HD066,@HD067,@HD068,@HD069,@HD070,@HD071,@HD072,@HD073,@HD077,@HD078,@HD079,@HD080,@HD081,@HD082,@HD083,@HD086,@HD087);" );
            strSql.Append( "SELECT SCOPE_IDENTITY();" );
            SqlParameter[] parameter = {
                new SqlParameter("@HD021",SqlDbType.NVarChar),
                new SqlParameter("@HD022",SqlDbType.Decimal),
                new SqlParameter("@HD023",SqlDbType.Int),
                new SqlParameter("@HD024",SqlDbType.Decimal),
                new SqlParameter("@HD025",SqlDbType.Int),
                new SqlParameter("@HD026",SqlDbType.Decimal),
                new SqlParameter("@HD027",SqlDbType.Int),
                new SqlParameter("@HD028",SqlDbType.Decimal),
                new SqlParameter("@HD029",SqlDbType.Int),
                new SqlParameter("@HD030",SqlDbType.Decimal),
                new SqlParameter("@HD031",SqlDbType.Int),
                new SqlParameter("@HD032",SqlDbType.Decimal),
                new SqlParameter("@HD033",SqlDbType.Int),
                new SqlParameter("@HD034",SqlDbType.Decimal),
                new SqlParameter("@HD035",SqlDbType.Int),
                new SqlParameter("@HD036",SqlDbType.Decimal),
                new SqlParameter("@HD037",SqlDbType.Int),
                new SqlParameter("@HD038",SqlDbType.Decimal),
                new SqlParameter("@HD039",SqlDbType.Int),
                new SqlParameter("@HD040",SqlDbType.Decimal),
                new SqlParameter("@HD041",SqlDbType.Int),
                new SqlParameter("@HD042",SqlDbType.Decimal),
                new SqlParameter("@HD043",SqlDbType.Int),
                new SqlParameter("@HD044",SqlDbType.Decimal),
                new SqlParameter("@HD045",SqlDbType.Int),
                new SqlParameter("@HD046",SqlDbType.Decimal),
                new SqlParameter("@HD047",SqlDbType.Int),
                new SqlParameter("@HD048",SqlDbType.Decimal),
                new SqlParameter("@HD049",SqlDbType.Int),
                new SqlParameter("@HD050",SqlDbType.Decimal),
                new SqlParameter("@HD051",SqlDbType.Int),
                new SqlParameter("@HD052",SqlDbType.Decimal),
                new SqlParameter("@HD053",SqlDbType.Int),
                new SqlParameter("@HD054",SqlDbType.Decimal),
                new SqlParameter("@HD055",SqlDbType.Int),
                new SqlParameter("@HD056",SqlDbType.Decimal),
                new SqlParameter("@HD057",SqlDbType.Int),
                new SqlParameter("@HD058",SqlDbType.Decimal),
                new SqlParameter("@HD059",SqlDbType.Int),
                new SqlParameter("@HD060",SqlDbType.Decimal),
                new SqlParameter("@HD061",SqlDbType.Int),
                new SqlParameter("@HD062",SqlDbType.Decimal),
                new SqlParameter("@HD063",SqlDbType.Int),
                new SqlParameter("@HD064",SqlDbType.Decimal),
                new SqlParameter("@HD065",SqlDbType.Int),
                new SqlParameter("@HD066",SqlDbType.Decimal),
                new SqlParameter("@HD067",SqlDbType.Int),
                new SqlParameter("@HD068",SqlDbType.Decimal),
                new SqlParameter("@HD069",SqlDbType.Int),
                new SqlParameter("@HD070",SqlDbType.Decimal),
                new SqlParameter("@HD071",SqlDbType.Int),
                new SqlParameter("@HD072",SqlDbType.Decimal),
                new SqlParameter("@HD073",SqlDbType.Int),
                new SqlParameter("@HD077",SqlDbType.NVarChar),
                new SqlParameter("@HD078",SqlDbType.NVarChar),
                new SqlParameter("@HD079",SqlDbType.VarChar),
                new SqlParameter("@HD080",SqlDbType.NVarChar),
                new SqlParameter("@HD081",SqlDbType.NVarChar),
                new SqlParameter("@HD082",SqlDbType.NVarChar),
                new SqlParameter("@HD083",SqlDbType.Decimal),
                new SqlParameter("@HD086",SqlDbType.Decimal),
                new SqlParameter("@HD087",SqlDbType.Decimal)
            };

            parameter[0].Value = model.HD021;
            parameter[1].Value = model.HD022;
            parameter[2].Value = model.HD023;
            parameter[3].Value = model.HD024;
            parameter[4].Value = model.HD025;
            parameter[5].Value = model.HD026;
            parameter[6].Value = model.HD027;
            parameter[7].Value = model.HD028;
            parameter[8].Value = model.HD029;
            parameter[9].Value = model.HD030;
            parameter[10].Value = model.HD031;
            parameter[11].Value = model.HD032;
            parameter[12].Value = model.HD033;
            parameter[13].Value = model.HD034;
            parameter[14].Value = model.HD035;
            parameter[15].Value = model.HD036;
            parameter[16].Value = model.HD037;
            parameter[17].Value = model.HD038;
            parameter[18].Value = model.HD039;
            parameter[19].Value = model.HD040;
            parameter[20].Value = model.HD041;
            parameter[21].Value = model.HD042;
            parameter[22].Value = model.HD043;
            parameter[23].Value = model.HD044;
            parameter[24].Value = model.HD045;
            parameter[25].Value = model.HD046;
            parameter[26].Value = model.HD047;
            parameter[27].Value = model.HD048;
            parameter[28].Value = model.HD049;
            parameter[29].Value = model.HD050;
            parameter[30].Value = model.HD051;
            parameter[31].Value = model.HD052;
            parameter[32].Value = model.HD053;
            parameter[33].Value = model.HD054;
            parameter[34].Value = model.HD055;
            parameter[35].Value = model.HD056;
            parameter[36].Value = model.HD057;
            parameter[37].Value = model.HD058;
            parameter[38].Value = model.HD059;
            parameter[39].Value = model.HD060;
            parameter[40].Value = model.HD061;
            parameter[41].Value = model.HD062;
            parameter[42].Value = model.HD063;
            parameter[43].Value = model.HD064;
            parameter[44].Value = model.HD065;
            parameter[45].Value = model.HD066;
            parameter[46].Value = model.HD067;
            parameter[47].Value = model.HD068;
            parameter[48].Value = model.HD069;
            parameter[49].Value = model.HD070;
            parameter[50].Value = model.HD071;
            parameter[51].Value = model.HD072;
            parameter[52].Value = model.HD073;
            parameter[53].Value = model.HD077;
            parameter[54].Value = model.HD078;
            parameter[55].Value = model.HD079;
            parameter[56].Value = model.HD080;
            parameter[57].Value = model.HD081;
            parameter[58].Value = model.HD082;
            parameter[59].Value = model.HD083;
            parameter[60].Value = model.HD086;
            parameter[61].Value = model.HD087;

            int idx = SqlHelper.ExecuteSqlReturnId( strSql.ToString( ) ,parameter );
            ArrayList SQLString = new ArrayList( );
            if ( idx > 0 )
            {
                model.IDX = idx;
                StringBuilder strSqls = new StringBuilder( );
                if ( model.HD084 == null )
                    strSqls.AppendFormat( "UPDATE R_PQBZ SET HD084=NULL WHERE idx='{0}'" ,model.IDX );
                else
                    strSqls.AppendFormat( "UPDATE R_PQBZ SET HD084='{0}' WHERE idx='{1}'" ,model.HD084 ,model.IDX );
                SQLString.Add( strSqls.ToString( ) );
                StringBuilder strSq = new StringBuilder( );
                if ( model.HD085 == null )
                    strSq.AppendFormat( "UPDATE R_PQBZ SET HD085=NULL WHERE idx='{0}'" ,model.IDX );
                else
                    strSq.AppendFormat( "UPDATE R_PQBZ SET HD085='{0}' WHERE idx='{1}'" ,model.HD085 ,model.IDX );
                SQLString.Add( strSq.ToString( ) );
                StringBuilder strS = new StringBuilder( );
                if ( model.HD088 == null )
                    strS.AppendFormat( "UPDATE R_PQBZ SET HD088=NULL WHERE idx='{0}'" ,model.IDX );
                else
                    strS.AppendFormat( "UPDATE R_PQBZ SET HD088='{0}' WHERE idx='{1}'" ,model.HD088 ,model.IDX );
                SQLString.Add( strS.ToString( ) );
                StringBuilder str = new StringBuilder( );
                if ( model.HD089 == null )
                    str.AppendFormat( "UPDATE R_PQBZ SET HD089=NULL WHERE idx='{0}'" ,model.IDX );
                else
                    str.AppendFormat( "UPDATE R_PQBZ SET HD089='{0}' WHERE idx='{1}'" ,model.HD089 ,model.IDX );
                SQLString.Add( str.ToString( ) );
                if ( SqlHelper.ExecuteSqlTran( SQLString ) == true )
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateBz ( MulaolaoLibrary.ZuZhangGongZiKaoHeBzLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQBZ SET " );
            strSql.Append( "HD021=@HD021," );
            strSql.Append( "HD022=@HD022," );
            strSql.Append( "HD023=@HD023," );
            strSql.Append( "HD024=@HD024," );
            strSql.Append( "HD025=@HD025," );
            strSql.Append( "HD026=@HD026," );
            strSql.Append( "HD027=@HD027," );
            strSql.Append( "HD028=@HD028," );
            strSql.Append( "HD029=@HD029," );
            strSql.Append( "HD030=@HD030," );
            strSql.Append( "HD031=@HD031," );
            strSql.Append( "HD032=@HD032," );
            strSql.Append( "HD033=@HD033," );
            strSql.Append( "HD034=@HD034," );
            strSql.Append( "HD035=@HD035," );
            strSql.Append( "HD036=@HD036," );
            strSql.Append( "HD037=@HD037," );
            strSql.Append( "HD038=@HD038," );
            strSql.Append( "HD039=@HD039," );
            strSql.Append( "HD040=@HD040," );
            strSql.Append( "HD041=@HD041," );
            strSql.Append( "HD042=@HD042," );
            strSql.Append( "HD043=@HD043," );
            strSql.Append( "HD044=@HD044," );
            strSql.Append( "HD045=@HD045," );
            strSql.Append( "HD046=@HD046," );
            strSql.Append( "HD047=@HD047," );
            strSql.Append( "HD048=@HD048," );
            strSql.Append( "HD049=@HD049," );
            strSql.Append( "HD050=@HD050," );
            strSql.Append( "HD051=@HD051," );
            strSql.Append( "HD052=@HD052," );
            strSql.Append( "HD053=@HD053," );
            strSql.Append( "HD054=@HD054," );
            strSql.Append( "HD055=@HD055," );
            strSql.Append( "HD056=@HD056," );
            strSql.Append( "HD057=@HD057," );
            strSql.Append( "HD058=@HD058," );
            strSql.Append( "HD059=@HD059," );
            strSql.Append( "HD060=@HD060," );
            strSql.Append( "HD061=@HD061," );
            strSql.Append( "HD062=@HD062," );
            strSql.Append( "HD063=@HD063," );
            strSql.Append( "HD064=@HD064," );
            strSql.Append( "HD065=@HD065," );
            strSql.Append( "HD066=@HD066," );
            strSql.Append( "HD067=@HD067," );
            strSql.Append( "HD068=@HD068," );
            strSql.Append( "HD069=@HD069," );
            strSql.Append( "HD070=@HD070," );
            strSql.Append( "HD071=@HD071," );
            strSql.Append( "HD072=@HD072," );
            strSql.Append( "HD077=@HD077," );
            strSql.Append( "HD078=@HD078," );
            strSql.Append( "HD079=@HD079," );
            strSql.Append( "HD080=@HD080," );
            strSql.Append( "HD081=@HD081," );
            strSql.Append( "HD082=@HD082," );
            strSql.Append( "HD083=@HD083," );
            strSql.Append( "HD086=@HD086," );
            strSql.Append( "HD087=@HD087" );
            strSql.Append( " WHERE idx=@idx" );

            SqlParameter[] parameter = {
                new SqlParameter("@HD021",SqlDbType.NVarChar),
                new SqlParameter("@HD022",SqlDbType.Decimal),
                new SqlParameter("@HD023",SqlDbType.Int),
                new SqlParameter("@HD024",SqlDbType.Decimal),
                new SqlParameter("@HD025",SqlDbType.Int),
                new SqlParameter("@HD026",SqlDbType.Decimal),
                new SqlParameter("@HD027",SqlDbType.Int),
                new SqlParameter("@HD028",SqlDbType.Decimal),
                new SqlParameter("@HD029",SqlDbType.Int),
                new SqlParameter("@HD030",SqlDbType.Decimal),
                new SqlParameter("@HD031",SqlDbType.Int),
                new SqlParameter("@HD032",SqlDbType.Decimal),
                new SqlParameter("@HD033",SqlDbType.Int),
                new SqlParameter("@HD034",SqlDbType.Decimal),
                new SqlParameter("@HD035",SqlDbType.Int),
                new SqlParameter("@HD036",SqlDbType.Decimal),
                new SqlParameter("@HD037",SqlDbType.Int),
                new SqlParameter("@HD038",SqlDbType.Decimal),
                new SqlParameter("@HD039",SqlDbType.Int),
                new SqlParameter("@HD040",SqlDbType.Decimal),
                new SqlParameter("@HD041",SqlDbType.Int),
                new SqlParameter("@HD042",SqlDbType.Decimal),
                new SqlParameter("@HD043",SqlDbType.Int),
                new SqlParameter("@HD044",SqlDbType.Decimal),
                new SqlParameter("@HD045",SqlDbType.Int),
                new SqlParameter("@HD046",SqlDbType.Decimal),
                new SqlParameter("@HD047",SqlDbType.Int),
                new SqlParameter("@HD048",SqlDbType.Decimal),
                new SqlParameter("@HD049",SqlDbType.Int),
                new SqlParameter("@HD050",SqlDbType.Decimal),
                new SqlParameter("@HD051",SqlDbType.Int),
                new SqlParameter("@HD052",SqlDbType.Decimal),
                new SqlParameter("@HD053",SqlDbType.Int),
                new SqlParameter("@HD054",SqlDbType.Decimal),
                new SqlParameter("@HD055",SqlDbType.Int),
                new SqlParameter("@HD056",SqlDbType.Decimal),
                new SqlParameter("@HD057",SqlDbType.Int),
                new SqlParameter("@HD058",SqlDbType.Decimal),
                new SqlParameter("@HD059",SqlDbType.Int),
                new SqlParameter("@HD060",SqlDbType.Decimal),
                new SqlParameter("@HD061",SqlDbType.Int),
                new SqlParameter("@HD062",SqlDbType.Decimal),
                new SqlParameter("@HD063",SqlDbType.Int),
                new SqlParameter("@HD064",SqlDbType.Decimal),
                new SqlParameter("@HD065",SqlDbType.Int),
                new SqlParameter("@HD066",SqlDbType.Decimal),
                new SqlParameter("@HD067",SqlDbType.Int),
                new SqlParameter("@HD068",SqlDbType.Decimal),
                new SqlParameter("@HD069",SqlDbType.Int),
                new SqlParameter("@HD070",SqlDbType.Decimal),
                new SqlParameter("@HD071",SqlDbType.Int),
                new SqlParameter("@HD072",SqlDbType.Decimal),
                new SqlParameter("@HD073",SqlDbType.Int),
                new SqlParameter("@HD077",SqlDbType.NVarChar),
                new SqlParameter("@HD078",SqlDbType.NVarChar),
                new SqlParameter("@HD079",SqlDbType.VarChar),
                new SqlParameter("@HD080",SqlDbType.NVarChar),
                new SqlParameter("@HD081",SqlDbType.NVarChar),
                new SqlParameter("@HD082",SqlDbType.NVarChar),
                new SqlParameter("@HD083",SqlDbType.Decimal),
                new SqlParameter("@HD086",SqlDbType.Decimal),
                new SqlParameter("@HD087",SqlDbType.Decimal),
                new SqlParameter("@idx",SqlDbType.Int)
            };

            parameter[0].Value = model.HD021;
            parameter[1].Value = model.HD022;
            parameter[2].Value = model.HD023;
            parameter[3].Value = model.HD024;
            parameter[4].Value = model.HD025;
            parameter[5].Value = model.HD026;
            parameter[6].Value = model.HD027;
            parameter[7].Value = model.HD028;
            parameter[8].Value = model.HD029;
            parameter[9].Value = model.HD030;
            parameter[10].Value = model.HD031;
            parameter[11].Value = model.HD032;
            parameter[12].Value = model.HD033;
            parameter[13].Value = model.HD034;
            parameter[14].Value = model.HD035;
            parameter[15].Value = model.HD036;
            parameter[16].Value = model.HD037;
            parameter[17].Value = model.HD038;
            parameter[18].Value = model.HD039;
            parameter[19].Value = model.HD040;
            parameter[20].Value = model.HD041;
            parameter[21].Value = model.HD042;
            parameter[22].Value = model.HD043;
            parameter[23].Value = model.HD044;
            parameter[24].Value = model.HD045;
            parameter[25].Value = model.HD046;
            parameter[26].Value = model.HD047;
            parameter[27].Value = model.HD048;
            parameter[28].Value = model.HD049;
            parameter[29].Value = model.HD050;
            parameter[30].Value = model.HD051;
            parameter[31].Value = model.HD052;
            parameter[32].Value = model.HD053;
            parameter[33].Value = model.HD054;
            parameter[34].Value = model.HD055;
            parameter[35].Value = model.HD056;
            parameter[36].Value = model.HD057;
            parameter[37].Value = model.HD058;
            parameter[38].Value = model.HD059;
            parameter[39].Value = model.HD060;
            parameter[40].Value = model.HD061;
            parameter[41].Value = model.HD062;
            parameter[42].Value = model.HD063;
            parameter[43].Value = model.HD064;
            parameter[44].Value = model.HD065;
            parameter[45].Value = model.HD066;
            parameter[46].Value = model.HD067;
            parameter[47].Value = model.HD068;
            parameter[48].Value = model.HD069;
            parameter[49].Value = model.HD070;
            parameter[50].Value = model.HD071;
            parameter[51].Value = model.HD072;
            parameter[52].Value = model.HD073;
            parameter[53].Value = model.HD077;
            parameter[54].Value = model.HD078;
            parameter[55].Value = model.HD079;
            parameter[56].Value = model.HD080;
            parameter[57].Value = model.HD081;
            parameter[58].Value = model.HD082;
            parameter[59].Value = model.HD083;
            parameter[60].Value = model.HD086;
            parameter[61].Value = model.HD087;
            parameter[62].Value = model.IDX;

            ArrayList SQLString = new ArrayList( );
            int rows = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( rows > 0 )
            {
                StringBuilder strSqls = new StringBuilder( );
                if ( model.HD084 == null )
                    strSqls.AppendFormat( "UPDATE R_PQBZ SET HD084=NULL WHERE idx='{0}'" ,model.IDX );
                else
                    strSqls.AppendFormat( "UPDATE R_PQBZ SET HD084='{0}' WHERE idx='{1}'" ,model.HD084 ,model.IDX );
                SQLString.Add( strSqls.ToString( ) );
                StringBuilder strSq = new StringBuilder( );
                if ( model.HD085 == null )
                    strSq.AppendFormat( "UPDATE R_PQBZ SET HD085=NULL WHERE idx='{0}'" ,model.IDX );
                else
                    strSq.AppendFormat( "UPDATE R_PQBZ SET HD085='{0}' WHERE idx='{1}'" ,model.HD085 ,model.IDX );
                SQLString.Add( strSq.ToString( ) );
                StringBuilder strS = new StringBuilder( );
                if ( model.HD088 == null )
                    strS.AppendFormat( "UPDATE R_PQBZ SET HD088=NULL WHERE idx='{0}'" ,model.IDX );
                else
                    strS.AppendFormat( "UPDATE R_PQBZ SET HD088='{0}' WHERE idx='{1}'" ,model.HD088 ,model.IDX );
                SQLString.Add( strS.ToString( ) );
                StringBuilder str = new StringBuilder( );
                if ( model.HD089 == null )
                    str.AppendFormat( "UPDATE R_PQBZ SET HD089=NULL WHERE idx='{0}'" ,model.IDX );
                else
                    str.AppendFormat( "UPDATE R_PQBZ SET HD089='{0}' WHERE idx='{1}'" ,model.HD089 ,model.IDX );
                SQLString.Add( str.ToString( ) );
                if ( SqlHelper.ExecuteSqlTran( SQLString ) == true )
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        /// <summary>
        /// 更新维护记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateWeiHu ( MulaolaoLibrary.ZuZhangGongZiKaoHeHdAzLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAZ SET " );
            strSql.Append( "HD075=@HD075," );
            strSql.Append( "HD076=@HD076" );
            strSql.Append( " WHERE HD074=@HD074" );
            SqlParameter[] parameter = {
                new SqlParameter("@HD074",SqlDbType.NVarChar),
                new SqlParameter("@HD075",SqlDbType.NVarChar),
                new SqlParameter("@HD076",SqlDbType.NVarChar)
            };
            parameter[0].Value = model.HD074;
            parameter[1].Value = model.HD075;
            parameter[2].Value = model.HD076;

            int rows = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( MulaolaoLibrary.ZuZhangGongZiKaoHeHdAzLibrary model)
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "DELETE FROM R_PQAZ WHERE idx={0}" ,model.IDX );
            SQLString.Add( strSql.ToString( ) );
            StringBuilder strSqlAz = new StringBuilder( );
            strSqlAz.AppendFormat( "SELECT COUNT(1) FROM R_PQBZ WHERE HD077='{0}' AND HD079='{1}' AND HD080='{2}'" ,model.HD074 ,model.HD002 ,model.HD003 );
            if ( SqlHelper.Exists( strSqlAz.ToString( ) ) )
            {
                StringBuilder strS = new StringBuilder( );
                strS.AppendFormat( "DELETE FROM R_PQBZ WHERE HD077='{0}' AND HD079='{1}' AND HD080='{2}'" ,model.HD074 ,model.HD002 ,model.HD003 );
                SQLString.Add( strS.ToString( ) );
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }


        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteBz ( MulaolaoLibrary.ZuZhangGongZiKaoHeBzLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQBZ" );
            strSql.Append( " WHERE HD077=@HD077," );
            strSql.Append( " AND HD079=@HD079," );
            strSql.Append( " AND HD080=@HD080" );
            SqlParameter[] parameter = {
                new SqlParameter("@HD077",SqlDbType.NVarChar),
                new SqlParameter("@HD079",SqlDbType.VarChar),
                new SqlParameter("@HD080",SqlDbType.NVarChar)
            };

            parameter[0].Value = model.HD077;
            parameter[1].Value = model.HD079;
            parameter[2].Value = model.HD080;

            int rows = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( rows > 0 )
                return true;
            else
                return false;
        }


        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DeleteTran ( string oddNum )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strAz = new StringBuilder( );
            strAz.AppendFormat( "SELECT COUNT(1) FROM R_PQAZ WHERE HD074='{0}'" ,oddNum );
            if ( SqlHelper.Exists( strAz.ToString( ) ) == true )
            {
                StringBuilder strSqlAz = new StringBuilder( );
                strSqlAz.AppendFormat( "DELETE FROM R_PQAZ WHERE HD074='{0}'" ,oddNum );
                SQLString.Add( strSqlAz );
            }
            StringBuilder strBz = new StringBuilder( );
            strBz.AppendFormat( "SELECT COUNT(1) FROM R_PQBZ WHERE HD077='{0}'" ,oddNum );
            if ( SqlHelper.Exists( strBz.ToString( ) ) == true )
            {
                StringBuilder strSqlBz = new StringBuilder( );
                strSqlBz.AppendFormat( "DELETE FROM R_PQBZ WHERE HD077='{0}'" ,oddNum );
                SQLString.Add( strSqlBz );
            }

            if ( SQLString.Count > 0 )
                return SqlHelper.ExecuteSqlTran( SQLString );
            else
                return true;
        }

        /// <summary>
        /// 得到数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableAz ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,HD001,HD002,HD003,HD004,HD005,HD007,HD008,HD009,HD011,HD012,HD014,HD015,HD017,HD018,HD019,HD074,HD094,F03 FROM R_PQAZ" );
            strSql.Append( " WHERE " + strWhere );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ZuZhangGongZiKaoHeHdAzLibrary GetModel ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQAZ" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };

            parameter[0].Value = idx;

            DataTable dt = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( dt.Rows.Count > 0 )
                return GetDataRow( dt.Rows[0] );
            else
                return null;
        }

        /// <summary>
        /// 获取数据实例
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ZuZhangGongZiKaoHeHdAzLibrary GetDataRow ( DataRow row )
        {
            MulaolaoLibrary.ZuZhangGongZiKaoHeHdAzLibrary model = new MulaolaoLibrary.ZuZhangGongZiKaoHeHdAzLibrary( );
            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    model.IDX = int.Parse( row["idx"].ToString( ) );
                if ( row["HD001"] != null && row["HD001"].ToString( ) != "" )
                    model.HD001 = row["HD001"].ToString( );
                if ( row["HD002"] != null && row["HD002"].ToString( ) != "" )
                    model.HD002 = row["HD002"].ToString( );
                if ( row["HD003"] != null && row["HD003"].ToString( ) != "" )
                    model.HD003 = row["HD003"].ToString( );
                if ( row["HD004"] != null && row["HD004"].ToString( ) != "" )
                    model.HD004 = decimal.Parse( row["HD004"].ToString( ) );
                if ( row["HD005"] != null && row["HD005"].ToString( ) != "" )
                    model.HD005 = decimal.Parse( row["HD005"].ToString( ) );
                if ( row["HD007"] != null && row["HD007"].ToString( ) != "" )
                    model.HD007 = decimal.Parse( row["HD007"].ToString( ) );
                if ( row["HD008"] != null && row["HD008"].ToString( ) != "" )
                    model.HD008 = decimal.Parse( row["HD008"].ToString( ) );
                if ( row["HD009"] != null && row["HD009"].ToString( ) != "" )
                    model.HD009 = decimal.Parse( row["HD009"].ToString( ) );
                if ( row["HD011"] != null && row["HD011"].ToString( ) != "" )
                    model.HD011 = int.Parse( row["HD011"].ToString( ) );
                if ( row["HD012"] != null && row["HD012"].ToString( ) != "" )
                    model.HD012 = decimal.Parse( row["HD012"].ToString( ) );
                if ( row["HD014"] != null && row["HD014"].ToString( ) != "" )
                    model.HD014 = decimal.Parse( row["HD014"].ToString( ) );
                if ( row["HD015"] != null && row["HD015"].ToString( ) != "" )
                    model.HD015 = decimal.Parse( row["HD015"].ToString( ) );
                if ( row["HD017"] != null && row["HD017"].ToString( ) != "" )
                    model.HD017 = decimal.Parse( row["HD017"].ToString( ) );
                if ( row["HD018"] != null && row["HD018"].ToString( ) != "" )
                    model.HD018 = decimal.Parse( row["HD018"].ToString( ) );
                if ( row["HD019"] != null && row["HD019"].ToString( ) != "" )
                    model.HD019 = decimal.Parse( row["HD019"].ToString( ) );
                if ( row["HD074"] != null && row["HD074"].ToString( ) != "" )
                    model.HD074 = row["HD074"].ToString( );
                if ( row["HD094"] != null && row["HD094"].ToString( ) != "" )
                    model.HD094 = row["HD094"].ToString( );
            }
            return model;
        }

        /// <summary>
        /// 获取产品名称等信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableNameNum ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT PQF01,PQF03,PQF04 FROM R_PQF A,R_REVIEWS B WHERE A.PQF01=B.RES06 AND B.RES05='执行'" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 是否存在一条记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="formText"></param>
        /// <returns></returns>
        public bool ExistsReview (string oddNum,string formText )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_REVIEWS A,R_MLLCXMC B" );
            strSql.Append( "  WHERE A.RES01=B.CX01 AND RES05='执行' AND RES06=@RES06 AND CX02=@CX02" );
            SqlParameter[] parameter = {
                new SqlParameter("@RES06",SqlDbType.NVarChar),
                new SqlParameter("@CX02",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;
            parameter[1].Value = formText;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableBz ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQBZ" );
            strSql.Append( " WHERE " + strWhere );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetDataTableTwo (MulaolaoLibrary.ZuZhangGongZiKaoHeBzLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT SUM(H23) H23,SUM(H25) H25,SUM(H27) H27,SUM(H29) H29,SUM(H31) H31,SUM(H33) H33,SUM(H35) H35,SUM(H37) H37,SUM(H39) H39,SUM(H41) H41,SUM(H43) H43,SUM(H45) H45,SUM(H47) H47,SUM(H49) H49,SUM(H51) H51,SUM(H53) H53,SUM(H55) H55,SUM(H57) H57,SUM(H59) H59,SUM(H61) H61,SUM(H63) H63,SUM(H65) H65,SUM(HU01) U1,SUM(HU02) U2,SUM(HU03) U3,SUM(HU04) U4,SUM(HU05) U5,SUM(HU06) U6,SUM(HU07) U7,SUM(HU08) U8,SUM(HU09) U9,SUM(HU10) U10,SUM(HU11) U11,SUM(HU12) U12,SUM(HU13) U13,SUM(HU14) U14,SUM(HU15) U15,SUM(HU16) U16,SUM(HU17) U17,SUM(HU18) U18,SUM(HU19) U19,SUM(HU20) U20,SUM(HU21) U21,SUM(HU22) U22,SUM(HU01)+SUM(HU02)+SUM(HU03)+SUM(HU04)+SUM(HU05)+SUM(HU06)+SUM(HU07)+SUM(HU08)+SUM(HU09)+SUM(HU10)+SUM(HU11)+SUM(HU12)+SUM(HU13)+SUM(HU14)+SUM(HU15)+SUM(HU16)+SUM(HU17)+SUM(HU18)+SUM(HU19)+SUM(HU20)+SUM(HU21)+SUM(HU22) HU23 FROM (SELECT SUM(HD023) H23,SUM(HD025) H25,SUM(HD027) H27,SUM(HD029) H29,SUM(HD031) H31,SUM(HD033) H33,SUM(HD035) H35,SUM(HD037) H37,SUM(HD039) H39,SUM(HD041) H41,SUM(HD043) H43,SUM(HD045) H45,SUM(HD047) H47,SUM(HD049) H49,SUM(HD051) H51,SUM(HD053) H53,SUM(HD055) H55,SUM(HD057) H57,SUM(HD059) H59,SUM(HD061) H61,SUM(HD063) H63,SUM(HD065) H65,HD022*SUM(HD023) HU01,HD024*SUM(HD025) HU02,HD026*SUM(HD027) HU03,HD028*SUM(HD029) HU04,HD030*SUM(HD031) HU05,HD032*SUM(HD033) HU06,HD034*SUM(HD035) HU07,HD036*SUM(HD037) HU08,HD038*SUM(HD039) HU09,HD040*SUM(HD041) HU10,HD042*SUM(HD043) HU11,HD044*SUM(HD045) HU12,HD046*SUM(HD047) HU13,HD048*SUM(HD049) HU14,HD050*SUM(HD051) HU15,HD052*SUM(HD053) HU16,HD054*SUM(HD055) HU17,HD056*SUM(HD057) HU18,HD058*SUM(HD059) HU19,HD060*SUM(HD061) HU20,HD062*SUM(HD063) HU21,HD064*SUM(HD065) HU22 FROM R_PQBZ" );
            strSql.Append( " WHERE HD077=@HD077 AND HD079=@HD079" );
            strSql.Append( " GROUP BY HD022,HD024,HD026,HD028,HD030,HD032,HD034,HD036,HD038,HD040,HD042,HD044,HD046,HD048,HD050,HD052,HD054,HD056,HD058,HD060,HD062,HD064) A" );
            SqlParameter[] parameter = {
                new SqlParameter("@HD077",SqlDbType.NVarChar),
                new SqlParameter("@HD079",SqlDbType.NVarChar)
            };

            parameter[0].Value = model.HD077;
            parameter[1].Value = model.HD079;


            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetDataTableOne ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT HD080,ISNULL(SUM(U1),0) U1 FROM (SELECT HD080,(ISNULL(HD022,0)*SUM(ISNULL(HD023,0))+ISNULL(HD024,0)*SUM(ISNULL(HD025,0))+ISNULL(HD026,0)*SUM(ISNULL(HD027,0))+ISNULL(HD028,0)*SUM(ISNULL(HD029,0))+ISNULL(HD030,0)*SUM(ISNULL(HD031,0))+ISNULL(HD032,0)*SUM(ISNULL(HD033,0))+ISNULL(HD034,0)*SUM(ISNULL(HD035,0))+ISNULL(HD036,0)*SUM(ISNULL(HD037,0))+ISNULL(HD038,0)*SUM(ISNULL(HD039,0))+ISNULL(HD040,0)*SUM(ISNULL(HD041,0))+ISNULL(HD042,0)*SUM(ISNULL(HD043,0))+ISNULL(HD044,0)*SUM(ISNULL(HD045,0))+ISNULL(HD046,0)*SUM(ISNULL(HD047,0))+ISNULL(HD048,0)*SUM(ISNULL(HD049,0))+ISNULL(HD050,0)*SUM(ISNULL(HD051,0))+ISNULL(HD052,0)*SUM(ISNULL(HD053,0))+ISNULL(HD054,0)*SUM(ISNULL(HD055,0))+ISNULL(HD056,0)*SUM(ISNULL(HD057,0))+ISNULL(HD058,0)*SUM(ISNULL(HD059,0))+ISNULL(HD060,0)*SUM(ISNULL(HD061,0))+ISNULL(HD062,0)*SUM(ISNULL(HD063,0))+ISNULL(HD064,0)*SUM(ISNULL(HD065,0)))*HD004 U1 FROM R_PQBZ A LEFT JOIN R_PQAZ B ON A.HD078=B.HD001 AND A.HD079=B.HD002  AND  A.HD080=B.HD003" );
            strSql.Append( " WHERE HD077=@HD077" );
            strSql.Append( " GROUP BY HD080,HD022,HD024,HD026,HD028,HD030,HD032,HD034,HD036,HD038,HD040,HD042,HD044,HD046,HD048,HD050,HD052,HD054,HD056,HD058,HD060,HD062,HD064,HD004) A" );
            strSql.Append( " GROUP BY HD080" );
            SqlParameter[] parameter = {
                new SqlParameter("@HD077",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }


        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool DeleteBz ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQBZ" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };

            parameter[0].Value = idx;

            int rows= SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( rows > 0 )
                return true;
            else
                return false;
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT HD074,HD001,HD002 FROM R_PQAZ" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetZuZhangCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM (SELECT DISTINCT HD074,HD001,HD002,HD094 FROM R_PQAZ " );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( " ) A" );

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
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTableByChange ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT HD074,HD001,HD002,HD094 FROM (" );
            strSql.Append( "SELECT ROW_NUMBER() OVER(" );
            strSql.Append( "ORDER BY T.HD074 DESC" );
            strSql.Append( ") AS Row,T.* FROM R_PQAZ T" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") TT" );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableAll ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQAZ" );
            strSql.Append( " WHERE HD074=@HD074" );
            SqlParameter[] parameter = {
                new SqlParameter("@HD074",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="dateYm"></param>
        /// <returns></returns>
        public DataTable GetDataTableDate ( string dateYm ,string name)
        {
            StringBuilder strSql = new StringBuilder( );
            //strSql.Append( "WITH CET AS (SELECT AE02,MAX(AE21) AE21,CONVERT(DECIMAL(18,1),SUM(AE28)) AE28 FROM (SELECT AE02,AE21,CASE WHEN AE12!=0 THEN SUM(AE37*AE12) ELSE SUM(AE37*AE10*AE11) END AE28 FROM R_PQAE" );
            //strSql.AppendFormat( " WHERE SUBSTRING( CONVERT( VARCHAR ,AE17 ) ,0 ,8 ) >='{0}'" ,dateYm );
            //strSql.Append( " GROUP BY AE21,AE02,AE12) A GROUP BY AE02)" );
            //strSql.Append( ",CFT AS(" );
            //strSql.AppendFormat( "SELECT PQF01,PQF03,PQF04,PQF32,PQF31,HT04,CONVERT(DECIMAL(18,1),CASE WHEN SUBSTRING( CONVERT( VARCHAR ,PQF31 ) ,0 ,8 )='{0}' THEN CASE WHEN PQF09!=0 THEN PQF09*PQF06 WHEN PQF09=0 THEN PQF06*PQF10*PQF45 END ELSE 0 END ) U1,CONVERT(DECIMAL(18,1),CASE WHEN SUBSTRING( CONVERT( VARCHAR ,HT04 ) ,0 ,8 )='{0}' THEN CASE WHEN PQF09!=0 THEN PQF09*PQF06 WHEN PQF09=0 THEN PQF06*PQF10*PQF45 END ELSE 0 END) U2,AE21,CASE WHEN SUBSTRING( CONVERT( VARCHAR ,PQF31 ) ,0 ,8 )='{0}' THEN AE28 ELSE 0 END AE28 FROM R_PQF A LEFT JOIN R_PQL B ON A.PQF01=B.HT01 LEFT JOIN CET ON AE02=PQF01" ,dateYm );
            //strSql.AppendFormat( " WHERE PQF17=(SELECT DAA001 FROM TPADAA WHERE DAA002='{0}')" ,name );
            //strSql.AppendFormat( " AND SUBSTRING( CONVERT( VARCHAR ,PQF31 ) ,0 ,8 ) >= '{0}' " ,dateYm );
            //strSql.AppendFormat( "  AND SUBSTRING( CONVERT( VARCHAR ,HT04 ) ,0 ,8 ) <= '{0}'" ,dateYm );
            //strSql.Append( " UNION " );
            //strSql.Append( " SELECT AE02,AE05,AE03,PQF32,PQF31,HT04,0 AS U1,0 AS U2,MAX(AE21) AE21,CONVERT(DECIMAL(18,0),CASE WHEN AE12!=0 THEN SUM(AE37*AE12) ELSE SUM(AE37*AE10*AE11) END) AE28 FROM R_PQAE A LEFT JOIN R_PQF B ON A.AE02=B.PQF01 LEFT JOIN R_PQL C ON B.PQF01=C.HT01 " );
            //strSql.AppendFormat( " WHERE AE08='{0}'" ,name );
            //strSql.AppendFormat( " AND SUBSTRING( CONVERT( VARCHAR ,AE21 ) ,0 ,8 )='{0}'" ,dateYm );
            //strSql.Append( " GROUP BY AE02,AE12,PQF31,PQF32,AE03,AE05,HT04" );
            //strSql.Append( ")" );
            //strSql.Append( " SELECT PQF01,PQF03,PQF04,PQF31,PQF32,HT04,SUM(U1) U1,SUM(U2) U2,AE21,MAX(AE28) AE28 FROM CFT GROUP BY PQF01,PQF03,PQF04,PQF31,PQF32,HT04,AE21" );
            strSql.Append( "WITH CET AS (" );
            strSql.Append( "SELECT AE02,MAX(AE21) AE21,CONVERT(DECIMAL(18,0),SUM(AE28)) AE28 FROM (SELECT AE02,AE21,CASE WHEN AE12!=0 THEN SUM(AE37*AE12) ELSE SUM(AE37*AE10*AE11) END AE28 FROM R_PQAE" );
            strSql.AppendFormat( " WHERE SUBSTRING( CONVERT( VARCHAR ,AE17 ) ,0 ,8 ) >='{0}'" ,dateYm );
            strSql.Append( " GROUP BY AE21,AE02,AE12) A GROUP BY AE02)" );
            strSql.Append( ",CFT AS (" );
            strSql.Append( "SELECT PQF01,PQF03,PQF04,PQF32,PQF31,HT04,CONVERT(DECIMAL(18,0)," );
            strSql.AppendFormat( "CASE WHEN SUBSTRING( CONVERT( VARCHAR ,PQF31 ) ,0 ,8 )='{0}'" ,dateYm );
            strSql.Append( " THEN CASE WHEN PQF09!=0 THEN PQF09*PQF06 WHEN PQF09=0 THEN PQF06*PQF10*PQF45 END ELSE 0 END ) U1,CONVERT(DECIMAL(18,0),CASE WHEN" );
            strSql.AppendFormat( " SUBSTRING( CONVERT( VARCHAR ,HT04 ) ,0 ,8 )='{0}'" ,dateYm );
            strSql.Append( " THEN CASE WHEN PQF09!=0 THEN PQF09*PQF06 WHEN PQF09=0 THEN PQF06*PQF10*PQF45 END ELSE 0 END) U2,AE21," );
            strSql.AppendFormat( " CASE WHEN SUBSTRING( CONVERT( VARCHAR ,PQF31 ) ,0 ,8 )='{0}'" ,dateYm );
            strSql.Append( " THEN AE28 ELSE 0 END AE28 FROM R_PQF A LEFT JOIN R_PQL B ON A.PQF01=B.HT01 LEFT JOIN CET ON AE02=PQF01" );
            strSql.AppendFormat( " WHERE PQF17 IN (SELECT DAA001 FROM TPADAA WHERE DAA002='{0}')" ,name );
            strSql.AppendFormat( " AND SUBSTRING( CONVERT( VARCHAR ,PQF31 ) ,0 ,8 ) >='{0}'" ,dateYm );
            strSql.AppendFormat( " AND SUBSTRING( CONVERT( VARCHAR ,HT04 ) ,0 ,8 ) <='{0}'" ,dateYm );
            strSql.Append( " UNION " );
            strSql.Append( "SELECT AE02,AE05,AE03,PQF32,PQF31,HT04,CONVERT(DECIMAL(18,0),CASE WHEN AE12!=0 THEN SUM(AE06*AE12) ELSE SUM(AE06*AE10*AE11) END) U1,0 AS U2,MAX(AE21) AE21,CONVERT(DECIMAL(18,0),CASE WHEN AE12!=0 THEN SUM(AE37*AE12) ELSE SUM(AE37*AE10*AE11) END) AE28 FROM R_PQAE A LEFT JOIN R_PQF B ON A.AE02=B.PQF01 LEFT JOIN R_PQL C ON B.PQF01=C.HT01" );
            strSql.AppendFormat( " WHERE AE08='{0}'" ,name );
            strSql.AppendFormat( " AND SUBSTRING( CONVERT( VARCHAR ,AE21 ) ,0 ,8 )='{0}'" ,dateYm );
            strSql.Append( " GROUP BY AE02,AE12,PQF31,PQF32,AE03,AE05,HT04" );
            strSql.Append( "),CGT AS (SELECT AE02,MAX(AE21) AE21,CONVERT(DECIMAL(18,0),SUM(CASE WHEN AE12!=0 THEN AE37*AE12 ELSE AE37*AE10*AE11 END)) AE28 FROM R_PQAE" );
            strSql.AppendFormat( " WHERE SUBSTRING( CONVERT( VARCHAR ,AE17 ) ,0 ,8 )<'{0}'" ,dateYm );
            strSql.AppendFormat( " AND AE08='{0}'" ,name );
            strSql.Append( " GROUP BY AE02),CHT AS (SELECT AE02,MAX(AE21) AE21,CONVERT(DECIMAL(18,0),CASE WHEN AE12!=0 THEN AE06*AE12 ELSE AE06*AE10*AE11 END) AE06 FROM R_PQAE" );
            strSql.AppendFormat( " WHERE SUBSTRING( CONVERT( VARCHAR ,AE17 ) ,0 ,8 )<'{0}'" ,dateYm );
            strSql.AppendFormat( " AND AE08='{0}'" ,name );
            strSql.Append( " GROUP BY AE02,AE12,AE06,AE10,AE11),CLT AS(" );
            strSql.Append( "SELECT PQF01,PQF03,PQF04,PQF32,PQF31,HT04,SUM(U1) U1,SUM(U2) U2,AE21,MAX(AE28) AE28 FROM CFT GROUP BY PQF01,PQF03,PQF04,PQF32,PQF31,HT04,AE21" );
            strSql.Append( " UNION" );
            strSql.Append( " SELECT AE02,PQF03,PQF04,PQF32,PQF31,HT04,AE06,U2,AE21,AE28 FROM (SELECT A.AE02,PQF03,PQF04,PQF32,PQF31,B.AE06,0 AS U2,HT04,AE28,A.AE21 FROM CGT A LEFT JOIN CHT B ON A.AE02=B.AE02 LEFT JOIN R_PQF C ON A.AE02=C.PQF01 LEFT JOIN R_PQL D ON A.AE02=D.HT01 WHERE A.AE21 IS NOT NULL GROUP BY A.AE02,AE28,B.AE06,PQF03,PQF04,PQF32,PQF31,HT04,A.AE21 HAVING AE28<B.AE06) A GROUP BY AE02,AE28,AE06,PQF03,PQF04,PQF32,PQF31,HT04,U2,AE21)" );
            strSql.Append( " SELECT PQF01,PQF03,PQF04,PQF32,PQF31,HT04,SUM(U1) U1,SUM(U2) U2,AE21,SUM(AE28) AE28 FROM CLT GROUP BY PQF01,PQF03,PQF04,PQF32,PQF31,HT04,AE21 ORDER BY PQF01" );
            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        
        public DataTable GetDataTableDates ( string dateYm ,string name )
        { 
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT SUM(CONVERT(DECIMAL(18,2),CASE WHEN PQF09!=0 THEN PQF09*PQF06 WHEN PQF09=0 THEN PQF06*PQF10 END )) U2 FROM R_PQF" );
            strSql.AppendFormat( " WHERE SUBSTRING(CONVERT(VARCHAR,PQF31),0,8)='{0}'" ,dateYm );
            strSql.AppendFormat( " AND PQF17=(SELECT DAA001 FROM TPADAA WHERE DAA002='{0}')" ,name );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableDats ( string name )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT MAX(AE21) AE21,SUM(AE28) AE28 FROM (SELECT AE21,SUM(AE37*AE12) AE28 FROM R_PQAE" );
            strSql.AppendFormat( " WHERE AE02='{0}'" ,name );
            strSql.Append( " GROUP BY AE21) A" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 批量更新数据到表
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool UpdateTable ( DataTable table )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQBZ WHERE 1=2" );

            return SqlHelper.UpdateTable( table ,strSql.ToString( ) );
        }
        public bool UpdateTableDelete ( MulaolaoLibrary.ZuZhangGongZiKaoHeBzLibrary modelBz )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "SELECT HD001,HD094,HD002,HD003 FROM R_PQAZ WHERE HD074='{0}'",modelBz.HD077 );
            DataTable dl = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            if ( dl == null || dl.Rows.Count < 1 )
                return false;
            else
            {
                for ( int k = 0 ; k < dl.Rows.Count ; k++ )
                {
                    modelBz.HD078 = dl.Rows[k]["HD001"].ToString( );
                    modelBz.HD079 = dl.Rows[k]["HD002"].ToString( );
                    modelBz.HD080 = dl.Rows[k]["HD003"].ToString( );
                    string qd = dl.Rows[k]["HD094"].ToString( );
                    StringBuilder strSq = new StringBuilder( );
                    strSq.AppendFormat( "SELECT HD021 PQF01,HD082 PQF03,HD081 PQF04,HD085 PQF31,HD084 PQF32,HD089 HT04,HD083 U1,HD086 U2,HD088 AE21,HD087 AE28 FROM R_PQBZ WHERE HD077='{0}' AND HD078='{1}' AND HD079='{2}' AND HD080='{3}'" ,modelBz.HD077 ,modelBz.HD078 ,modelBz.HD079 ,modelBz.HD080 );
                    DataTable da = SqlHelper.ExecuteDataTable( strSq.ToString( ) );
                    DataTable de = GetDataTableDate( modelBz.HD079.Substring( 0 ,4 ) + "-" + modelBz.HD079.Substring( 4 ,2 ) ,qd );
                    if ( tableTheSame( de ,da ) == false )
                    {   
                        for ( int i = 0 ; i < da.Rows.Count ; i++ )
                        {
                            if ( de.Select( "PQF01='" + da.Rows[i]["PQF01"].ToString( ) + "'" ).Length < 1 )
                                SQLString.Add( DeleteOf( da.Rows[i]["PQF01"].ToString( ) ) );
                        }
                    }
                }
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }


        bool tableTheSame ( DataTable dtOne ,DataTable dtTwo )
        {
            if ( dtOne == null || dtTwo == null )
                return false;
            if ( dtOne.Rows.Count != dtTwo.Rows.Count )
                return false;
            if ( dtOne.Columns.Count != dtTwo.Columns.Count )
                return false;
            for ( int i = 0 ; i < dtOne.Rows.Count ; i++ )
            {
                for ( int j = 0 ; j < dtOne.Columns.Count ; j++ )
                {
                    if ( dtOne.Rows[i][j].ToString( ) != dtTwo.Rows[i][j].ToString( ) )
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public DataTable GetDataTable ( string oddNum ,string name ,string yearM ,string monthD )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQBZ" );
            strSql.Append( " WHERE HD077=@HD077 AND HD078=@HD078 AND HD079=@HD079 AND HD080=@HD080" );
            SqlParameter[] parameter = {
                new SqlParameter("@HD077",SqlDbType.NVarChar),
                new SqlParameter("@HD078",SqlDbType.NVarChar),
                new SqlParameter("@HD079",SqlDbType.NVarChar),
                new SqlParameter("@HD080",SqlDbType.NVarChar)
            };
            parameter[0].Value = oddNum;
            parameter[1].Value = name;
            parameter[2].Value = yearM;
            parameter[3].Value = monthD;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public string DeleteOf ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQBZ " );
            strSql.AppendFormat( " WHERE HD021='{0}'" ,num );

            return strSql.ToString( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableAll ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT ZZ002,ZZ003,ZZ004,ZZ005,ZZ006,ZZ007,ZZ008 FROM R_PQZZ WHERE ZZ001 LIKE '%R_502%'" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="tableNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfParameter ( string tableNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQAY WHERE AY001=@AY001" );
            SqlParameter[] parrameter = {
                new SqlParameter("@AY001",SqlDbType.NVarChar)
            };
            parrameter[0].Value = tableNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parrameter );
        }
    }
}

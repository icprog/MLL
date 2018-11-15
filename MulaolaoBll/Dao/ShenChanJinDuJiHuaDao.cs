using StudentMgr;
using System;
using System . Collections;
using System . Collections . Generic;
using System . Data;
using System . Data . SqlClient;
using System . Linq;
using System . Text;

namespace MulaolaoBll.Dao
{
    public class ShenChanJinDuJiHuaDao
    {
        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists ( MulaolaoLibrary.ShenChanJinDuJiHuaLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx FROM R_PQX" );
            strSql.Append( " WHERE PQX33=@PQX33" );
            strSql.Append( " AND PQX14=@PQX14" );
            strSql.Append( " AND PQX15=@PQX15" );

            SqlParameter[] parameter = {
                new SqlParameter("@PQX33",SqlDbType.NVarChar),
                new SqlParameter("@PQX14",SqlDbType.NVarChar),
                new SqlParameter("@PQX15",SqlDbType.NVarChar)
            };

            parameter[0].Value = model.PQX33;
            parameter[1].Value = model.PQX14;
            parameter[2].Value = model.PQX15;

            DataTable table = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( table == null || table . Rows . Count < 1 )
                return false;
            else
            {
                string idx = table . Rows [ 0 ] [ "idx" ] . ToString ( );
                if ( string . IsNullOrEmpty ( idx ) )
                    return false;
                else if ( Convert . ToInt32 ( idx ) == model . Idx )
                    return false;
                else
                    return true;
            }
        }


        /// <summary>
        /// 是否存在相同工序序号
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsId ( MulaolaoLibrary.ShenChanJinDuJiHuaLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQX" );
            strSql.Append( " WHERE PQX33=@PQX33" );
            strSql.Append( " AND PQX14=@PQX14" );
            strSql.Append( " AND PQX16=@PQX16" );
            SqlParameter[] parameter = {
                new SqlParameter("@PQX33",SqlDbType.NVarChar),
                new SqlParameter("@PQX14",SqlDbType.NVarChar),
                new SqlParameter("@PQX16",SqlDbType.Int)
            };

            parameter[0].Value = model.PQX33;
            parameter[1].Value = model.PQX14;
            parameter[2].Value = model.PQX16;


            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }


        /// <summary>
        /// 是否执行
        /// </summary>
        /// <param name="model"></param>
        /// <param name="formText"></param>
        /// <returns></returns>
        public bool ExistsReview ( MulaolaoLibrary.ShenChanJinDuJiHuaLibrary model ,string formText )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_REVIEWS A,R_MLLCXMC B" );
            strSql.Append( " WHERE A.RES01=B.CX01" );
            strSql.Append( " AND RES05='执行'" );
            strSql.Append( "  AND RES06=@RES06" );
            strSql.Append( "  AND CX02=@CX02" );
            SqlParameter[] parameter = {
                new SqlParameter("@RES06",SqlDbType.NVarChar),
                new SqlParameter("@CX02",SqlDbType.NVarChar)
            };
            parameter[0].Value = model.PQX33;
            parameter[1].Value = formText;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }


        /// <summary>
        /// 复制一张表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool GetDataCopy (string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQX (PQX01,PQX29,PQX30,PQX31,PQX32,PQX02,PQX03,PQX04,PQX05,PQX06,PQX07,PQX08,PQX09,PQX10,PQX11,PQX12,PQX13,PQX14,PQX15,PQX16,PQX17,PQX18,PQX19,PQX20,PQX21,PQX22,PQX23,PQX25,PQX26,PQX36,PQX38,PQX24,PQX34)" );
            strSql.Append( "SELECT PQX01,PQX29,PQX30,PQX31,PQX32,PQX02,PQX03,PQX04,PQX05,PQX06,PQX07,PQX08,PQX09,PQX10,PQX11,PQX12,PQX13,PQX14,PQX15,PQX16,PQX17,PQX18,PQX19,PQX20,PQX21,PQX22,PQX23,PQX25,PQX26,PQX36,PQX38,0,0 FROM R_PQX" );
            strSql.Append( " WHERE PQX33=@PQX33" );

            SqlParameter[] parameter = {
                new SqlParameter("@PQX33",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

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
        public int Add ( MulaolaoLibrary . ShenChanJinDuJiHuaLibrary model )
        {
            //PQX22,PQX23,@PQX22,@PQX23,
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQX (" );
            strSql . Append ( " PQX33,PQX01,PQX29,PQX30,PQX31,PQX32,PQX02,PQX03,PQX04,PQX05,PQX06,PQX07,PQX08,PQX09,PQX10,PQX11,PQX12,PQX13,PQX14,PQX15,PQX16,PQX17,PQX18,PQX19,PQX20,PQX21,PQX24,PQX25,PQX34,PQX36,PQX38)" );
            strSql . Append ( " VALUES (" );
            strSql . Append ( " @PQX33,@PQX01,@PQX29,@PQX30,@PQX31,@PQX32,@PQX02,@PQX03,@PQX04,@PQX05,@PQX06,@PQX07,@PQX08,@PQX09,@PQX10,@PQX11,@PQX12,@PQX13,@PQX14,@PQX15,@PQX16,@PQX17,@PQX18,@PQX19,@PQX20,@PQX21,@PQX24,@PQX25,@PQX34,@PQX36,@PQX38);" );
            strSql . Append ( "SELECT SCOPE_IDENTITY();" );

            SqlParameter [ ] parameter = {
                new SqlParameter("@PQX33",SqlDbType.NVarChar),
                new SqlParameter("@PQX01",SqlDbType.NVarChar),
                new SqlParameter("@PQX29",SqlDbType.NVarChar),
                new SqlParameter("@PQX30",SqlDbType.Date),
                new SqlParameter("@PQX31",SqlDbType.NVarChar),
                new SqlParameter("@PQX32",SqlDbType.BigInt),
                new SqlParameter("@PQX02",SqlDbType.NVarChar),
                new SqlParameter("@PQX03",SqlDbType.NVarChar),
                new SqlParameter("@PQX04",SqlDbType.Date),
                new SqlParameter("@PQX05",SqlDbType.Date),
                new SqlParameter("@PQX06",SqlDbType.NVarChar),
                new SqlParameter("@PQX07",SqlDbType.Date),
                new SqlParameter("@PQX08",SqlDbType.NVarChar),
                new SqlParameter("@PQX09",SqlDbType.Date),
                new SqlParameter("@PQX10",SqlDbType.NVarChar),
                new SqlParameter("@PQX11",SqlDbType.Date),
                new SqlParameter("@PQX12",SqlDbType.Date),
                new SqlParameter("@PQX13",SqlDbType.NVarChar),
                new SqlParameter("@PQX14",SqlDbType.NVarChar),
                new SqlParameter("@PQX15",SqlDbType.NVarChar),
                new SqlParameter("@PQX16",SqlDbType.Int),
                new SqlParameter("@PQX17",SqlDbType.NVarChar),
                new SqlParameter("@PQX18",SqlDbType.Int),
                new SqlParameter("@PQX19",SqlDbType.Int),
                new SqlParameter("@PQX20",SqlDbType.NVarChar),
                new SqlParameter("@PQX21",SqlDbType.NVarChar),
                //new SqlParameter("@PQX22",SqlDbType.BigInt),
                //new SqlParameter("@PQX23",SqlDbType.BigInt),
                new SqlParameter("@PQX24",SqlDbType.BigInt),
                new SqlParameter("@PQX25",SqlDbType.Date),
                new SqlParameter("@PQX34",SqlDbType.BigInt),
                new SqlParameter("@PQX36",SqlDbType.Int),
                new SqlParameter("@PQX38",SqlDbType.NVarChar)
            };

            parameter [ 0 ] . Value = model . PQX33;
            parameter [ 1 ] . Value = model . PQX01;
            parameter [ 2 ] . Value = model . PQX29;
            parameter [ 3 ] . Value = model . PQX30;
            parameter [ 4 ] . Value = model . PQX31;
            parameter [ 5 ] . Value = model . PQX32;
            parameter [ 6 ] . Value = model . PQX02;
            parameter [ 7 ] . Value = model . PQX03;
            parameter [ 8 ] . Value = model . PQX04;
            parameter [ 9 ] . Value = model . PQX05;
            parameter [ 10 ] . Value = model . PQX06;
            parameter [ 11 ] . Value = model . PQX07;
            parameter [ 12 ] . Value = model . PQX08;
            parameter [ 13 ] . Value = model . PQX09;
            parameter [ 14 ] . Value = model . PQX10;
            parameter [ 15 ] . Value = model . PQX11;
            parameter [ 16 ] . Value = model . PQX12;
            parameter [ 17 ] . Value = model . PQX13;
            parameter [ 18 ] . Value = model . PQX14;
            parameter [ 19 ] . Value = model . PQX15;
            parameter [ 20 ] . Value = model . PQX16;
            parameter [ 21 ] . Value = model . PQX17;
            parameter [ 22 ] . Value = model . PQX18;
            parameter [ 23 ] . Value = model . PQX19;
            parameter [ 24 ] . Value = model . PQX20;
            parameter [ 25 ] . Value = model . PQX21;
            //parameter[26].Value = model.PQX22;
            //parameter[27].Value = model.PQX23;
            parameter [ 26 ] . Value = model . PQX24;
            parameter [ 27 ] . Value = model . PQX25;
            parameter [ 28 ] . Value = 0;
            parameter [ 29 ] . Value = model . PQX36;
            parameter [ 30 ] . Value = model . PQX38;

            int idx = SqlHelper . ExecuteSqlReturnId ( strSql . ToString ( ) ,parameter );
            return idx;
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary . ShenChanJinDuJiHuaLibrary model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQX SET " );
            strSql . Append ( "PQX33=@PQX33," );
            strSql . Append ( "PQX01=@PQX01," );
            strSql . Append ( "PQX29=@PQX29," );
            strSql . Append ( "PQX30=@PQX30," );
            strSql . Append ( "PQX31=@PQX31," );
            strSql . Append ( "PQX32=@PQX32," );
            strSql . Append ( "PQX02=@PQX02," );
            strSql . Append ( "PQX03=@PQX03," );
            strSql . Append ( "PQX04=@PQX04," );
            strSql . Append ( "PQX05=@PQX05," );
            strSql . Append ( "PQX06=@PQX06," );
            strSql . Append ( "PQX07=@PQX07," );
            strSql . Append ( "PQX08=@PQX08," );
            strSql . Append ( "PQX09=@PQX09," );
            strSql . Append ( "PQX10=@PQX10," );
            strSql . Append ( "PQX11=@PQX11," );
            strSql . Append ( "PQX12=@PQX12," );
            strSql . Append ( "PQX13=@PQX13," );
            strSql . Append ( "PQX14=@PQX14," );
            strSql . Append ( "PQX15=@PQX15," );
            strSql . Append ( "PQX16=@PQX16," );
            strSql . Append ( "PQX17=@PQX17," );
            strSql . Append ( "PQX18=@PQX18," );
            strSql . Append ( "PQX19=@PQX19," );
            strSql . Append ( "PQX20=@PQX20," );
            strSql . Append ( "PQX21=@PQX21," );
            //strSql.Append( "PQX22=@PQX22," );
            //strSql.Append( "PQX23=@PQX23," );
            strSql . Append ( "PQX24=@PQX24," );
            strSql . Append ( "PQX25=@PQX25," );
            //strSql . Append ( "PQX34=@PQX34," );
            strSql . Append ( "PQX36=@PQX36," );
            strSql . Append ( "PQX38=@PQX38" );
            strSql . Append ( " WHERE idx=@idx" );

            SqlParameter [ ] parameter = {
                new SqlParameter("@PQX33",SqlDbType.NVarChar),
                new SqlParameter("@PQX01",SqlDbType.NVarChar),
                new SqlParameter("@PQX29",SqlDbType.NVarChar),
                new SqlParameter("@PQX30",SqlDbType.Date),
                new SqlParameter("@PQX31",SqlDbType.NVarChar),
                new SqlParameter("@PQX32",SqlDbType.BigInt),
                new SqlParameter("@PQX02",SqlDbType.NVarChar),
                new SqlParameter("@PQX03",SqlDbType.NVarChar),
                new SqlParameter("@PQX04",SqlDbType.Date),
                new SqlParameter("@PQX05",SqlDbType.Date),
                new SqlParameter("@PQX06",SqlDbType.NVarChar),
                new SqlParameter("@PQX07",SqlDbType.Date),
                new SqlParameter("@PQX08",SqlDbType.NVarChar),
                new SqlParameter("@PQX09",SqlDbType.Date),
                new SqlParameter("@PQX10",SqlDbType.NVarChar),
                new SqlParameter("@PQX11",SqlDbType.Date),
                new SqlParameter("@PQX12",SqlDbType.Date),
                new SqlParameter("@PQX13",SqlDbType.NVarChar),
                new SqlParameter("@PQX14",SqlDbType.NVarChar),
                new SqlParameter("@PQX15",SqlDbType.NVarChar),
                new SqlParameter("@PQX16",SqlDbType.Int),
                new SqlParameter("@PQX17",SqlDbType.NVarChar),
                new SqlParameter("@PQX18",SqlDbType.Int),
                new SqlParameter("@PQX19",SqlDbType.Int),
                new SqlParameter("@PQX20",SqlDbType.NVarChar),
                new SqlParameter("@PQX21",SqlDbType.NVarChar),
                //new SqlParameter("@PQX22",SqlDbType.BigInt),
                //new SqlParameter("@PQX23",SqlDbType.BigInt),
                new SqlParameter("@PQX24",SqlDbType.BigInt),
                new SqlParameter("@PQX25",SqlDbType.Date),
                //new SqlParameter("@PQX34",SqlDbType.BigInt),
                new SqlParameter("@PQX36",SqlDbType.Int),
                new SqlParameter("@PQX38",SqlDbType.NVarChar),
                new SqlParameter("@idx",SqlDbType.Int)
            };

            parameter [ 0 ] . Value = model . PQX33;
            parameter [ 1 ] . Value = model . PQX01;
            parameter [ 2 ] . Value = model . PQX29;
            parameter [ 3 ] . Value = model . PQX30;
            parameter [ 4 ] . Value = model . PQX31;
            parameter [ 5 ] . Value = model . PQX32;
            parameter [ 6 ] . Value = model . PQX02;
            parameter [ 7 ] . Value = model . PQX03;
            parameter [ 8 ] . Value = model . PQX04;
            parameter [ 9 ] . Value = model . PQX05;
            parameter [ 10 ] . Value = model . PQX06;
            parameter [ 11 ] . Value = model . PQX07;
            parameter [ 12 ] . Value = model . PQX08;
            parameter [ 13 ] . Value = model . PQX09;
            parameter [ 14 ] . Value = model . PQX10;
            parameter [ 15 ] . Value = model . PQX11;
            parameter [ 16 ] . Value = model . PQX12;
            parameter [ 17 ] . Value = model . PQX13;
            parameter [ 18 ] . Value = model . PQX14;
            parameter [ 19 ] . Value = model . PQX15;
            parameter [ 20 ] . Value = model . PQX16;
            parameter [ 21 ] . Value = model . PQX17;
            parameter [ 22 ] . Value = model . PQX18;
            parameter [ 23 ] . Value = model . PQX19;
            parameter [ 24 ] . Value = model . PQX20;
            parameter [ 25 ] . Value = model . PQX21;
            //parameter[26].Value = model.PQX22;
            //parameter[27].Value = model.PQX23;
            parameter [ 26 ] . Value = model . PQX24;
            parameter [ 27 ] . Value = model . PQX25;
            //parameter [ 28 ] . Value = model . PQX34;
            parameter [ 28 ] . Value = model . PQX36;
            parameter [ 29 ] . Value = model . PQX38;
            parameter [ 30 ] . Value = model . Idx;

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 更新维护记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateWeiHu ( MulaolaoLibrary.ShenChanJinDuJiHuaLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQX SET" );
            strSql.Append( " PQX27=@PQX27," );
            strSql.Append( " PQX28=@PQX28" );
            strSql.Append( " WHERE PQX33=@PQX33" );

            SqlParameter[] parameter = {
                new SqlParameter("@PQX27",SqlDbType.NVarChar),
                new SqlParameter("@PQX28",SqlDbType.NVarChar),
                new SqlParameter("@PQX33",SqlDbType.NVarChar)
            };

            parameter[0].Value = model.PQX27;
            parameter[1].Value = model.PQX28;
            parameter[2].Value = model.PQX33;

            int rows = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 批量编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateBatch ( MulaolaoLibrary . ShenChanJinDuJiHuaLibrary model ,string nameOfSpare ,string partCode ,int partNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQX SET " );
            strSql . Append ( "PQX14=@PQX14," );
            strSql . Append ( "PQX17=@PQX17," );
            strSql . Append ( "PQX36=@PQX36" );
            strSql . Append ( " WHERE PQX01=@PQX01 AND PQX14=@PQX4 AND PQX17=@PQX7 AND PQX36=@PQX6" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PQX14",SqlDbType.NVarChar),
                new SqlParameter("@PQX17",SqlDbType.NVarChar),
                new SqlParameter("@PQX36",SqlDbType.Int),
                new SqlParameter("@PQX4",SqlDbType.NVarChar),
                new SqlParameter("@PQX7",SqlDbType.NVarChar),
                new SqlParameter("@PQX6",SqlDbType.Int),
                new SqlParameter("@PQX01",SqlDbType.NVarChar)
            };
            parameter [ 0 ] . Value = model . PQX14;
            parameter [ 1 ] . Value = model . PQX17;
            parameter [ 2 ] . Value = model . PQX36;
            parameter [ 3 ] . Value = nameOfSpare;
            parameter [ 4 ] . Value = partCode;
            parameter [ 5 ] . Value = partNum;
            parameter [ 6 ] . Value = model . PQX01;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateAll ( MulaolaoLibrary . ShenChanJinDuJiHuaLibrary model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQX SET " );
            strSql . Append ( "PQX01=@PQX01," );
            strSql . Append ( "PQX29=@PQX29," );
            strSql . Append ( "PQX30=@PQX30," );
            strSql . Append ( "PQX31=@PQX31," );
            strSql . Append ( "PQX32=@PQX32," );
            strSql . Append ( "PQX02=@PQX02," );
            strSql . Append ( "PQX03=@PQX03," );
            strSql . Append ( "PQX04=@PQX04," );
            strSql . Append ( "PQX05=@PQX05," );
            strSql . Append ( "PQX06=@PQX06," );
            strSql . Append ( "PQX07=@PQX07," );
            strSql . Append ( "PQX08=@PQX08," );
            strSql . Append ( "PQX09=@PQX09," );
            strSql . Append ( "PQX10=@PQX10," );
            strSql . Append ( "PQX11=@PQX11," );
            strSql . Append ( "PQX12=@PQX12" );
            strSql . Append ( " WHERE PQX33=@PQX33" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PQX33",SqlDbType.NVarChar),
                new SqlParameter("@PQX01",SqlDbType.NVarChar),
                new SqlParameter("@PQX29",SqlDbType.NVarChar),
                new SqlParameter("@PQX30",SqlDbType.Date),
                new SqlParameter("@PQX31",SqlDbType.NVarChar),
                new SqlParameter("@PQX32",SqlDbType.BigInt),
                new SqlParameter("@PQX02",SqlDbType.NVarChar),
                new SqlParameter("@PQX03",SqlDbType.NVarChar),
                new SqlParameter("@PQX04",SqlDbType.Date),
                new SqlParameter("@PQX05",SqlDbType.Date),
                new SqlParameter("@PQX06",SqlDbType.NVarChar),
                new SqlParameter("@PQX07",SqlDbType.Date),
                new SqlParameter("@PQX08",SqlDbType.NVarChar),
                new SqlParameter("@PQX09",SqlDbType.Date),
                new SqlParameter("@PQX10",SqlDbType.NVarChar),
                new SqlParameter("@PQX11",SqlDbType.Date),
                new SqlParameter("@PQX12",SqlDbType.Date),
            };

            parameter [ 0 ] . Value = model . PQX33;
            parameter [ 1 ] . Value = model . PQX01;
            parameter [ 2 ] . Value = model . PQX29;
            parameter [ 3 ] . Value = model . PQX30;
            parameter [ 4 ] . Value = model . PQX31;
            parameter [ 5 ] . Value = model . PQX32;
            parameter [ 6 ] . Value = model . PQX02;
            parameter [ 7 ] . Value = model . PQX03;
            parameter [ 8 ] . Value = model . PQX04;
            parameter [ 9 ] . Value = model . PQX05;
            parameter [ 10 ] . Value = model . PQX06;
            parameter [ 11 ] . Value = model . PQX07;
            parameter [ 12 ] . Value = model . PQX08;
            parameter [ 13 ] . Value = model . PQX09;
            parameter [ 14 ] . Value = model . PQX10;
            parameter [ 15 ] . Value = model . PQX11;
            parameter [ 16 ] . Value = model . PQX12;

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 检查是否046有436不存在的零件和工序
        /// </summary>
        /// <param name="num"></param>
        /// <param name="tableOne"></param>
        /// <returns></returns>
        public int checkPart ( string num ,DataTable tableOne )
        {
            StringBuilder strSql = new StringBuilder ( );
            string pqx14 = string . Empty, pqx15 = string . Empty, pqx38 = string . Empty;
            DataTable table = tablePartAndWorkshop ( num );
            if ( table == null || table . Rows . Count < 1 )
            //表示436没有做这个流水号的内容
            {
                strSql . AppendFormat ( "DELETE FROM R_PQX WHERE PQX01='{0}'" ,num );
                if ( SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ) > 0 )
                    //删除成功
                    return 1;
                else
                    //删除失败
                    return 5;
            }
            else
            {
                if ( tableOne == null || tableOne . Rows . Count < 1 )
                    return 0;

                ArrayList SQLString = new ArrayList ( );

                for ( int i = 0 ; i < tableOne . Rows . Count ; i++ )
                {
                    pqx38 = tableOne . Rows [ i ] [ "PQX38" ] . ToString ( );
                    pqx14 = tableOne . Rows [ i ] [ "PQX14" ] . ToString ( );
                    pqx15 = tableOne . Rows [ i ] [ "PQX15" ] . ToString ( );
                    if ( pqx38 . Equals ( "厂内" ) && table . Select ( "DS03='" + pqx14 + "' AND DS04='" + pqx15 + "'" ) . Length < 1 )
                        delete ( SQLString ,strSql ,new string [ ] { num ,pqx14 ,pqx15 } );
                }
                if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
                    //已经删除不存在436的数据
                    return 3;
                else
                    //删除失败
                    return 4;
            }

        }

        void delete ( ArrayList SQLString ,StringBuilder strSql ,string [ ] str )
        {
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM R_PQX WHERE PQX01='{0}' AND PQX14='{1}' AND PQX15='{2}'" ,str [ 0 ] ,str [ 1 ] ,str [ 2 ] );

            SQLString . Add ( strSql );
        }

        /// <summary>
        /// 获取436零件和工序名称
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        DataTable tablePartAndWorkshop ( string num )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT DS03,DS04 FROM R_PQR WHERE DS01='{0}'" ,num );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 更新复制数据的单号
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateCopy ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQX SET" );
            strSql.Append( " PQX33=@PQX33," );
            strSql.Append( " PQX35='复制'" );
            strSql.Append( " WHERE PQX33 IS NULL" );
            SqlParameter[] parameter = {
                new SqlParameter("@PQX33",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            int rows = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除复制内容
        /// </summary>
        public bool DeleteCopy ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQX" );
            strSql.Append( " WHERE PQX33 IS NULL" );

            int rows = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
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
        public bool Delete ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQX" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };

            parameter[0].Value = idx;

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
        public bool DeleteIdxList ( string idxList )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQX" );
            strSql.Append( " WHERE idx IN (" + idxList + ")" );

            int rows = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( rows > 0 )
                return true;
            else
                return false;
        }


        /// <summary>
        /// 批量删除数据  依据单号
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DeleteOddNumList ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQX" );
            strSql.Append( " WHERE PQX33=@PQX33" );
            SqlParameter[] parameter = {
                new SqlParameter("@PQX33",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            int rows = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取一个实体对象
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ShenChanJinDuJiHuaLibrary GetModel ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQX" );
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
        /// 获取一个实体对象
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ShenChanJinDuJiHuaLibrary GetDataRow ( DataRow row )
        {
            MulaolaoLibrary.ShenChanJinDuJiHuaLibrary model = new MulaolaoLibrary.ShenChanJinDuJiHuaLibrary( );
            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    model.Idx = int.Parse( row["idx"].ToString( ) );
                if ( row["PQX33"] != null && row["PQX33"].ToString( ) != "" )
                    model.PQX33 = row["PQX33"].ToString( );
                if ( row["PQX01"] != null && row["PQX01"].ToString( ) != "" )
                    model.PQX01 = row["PQX01"].ToString( );
                if ( row["PQX29"] != null && row["PQX29"].ToString( ) != "" )
                    model.PQX29 = row["PQX29"].ToString( );
                if ( row["PQX30"] != null && row["PQX30"].ToString( ) != "" )
                    model.PQX30 = DateTime.Parse( row["PQX30"].ToString( ) );
                if ( row["PQX31"] != null && row["PQX31"].ToString( ) != "" )
                    model.PQX31 = row["PQX31"].ToString( );
                if ( row["PQX32"] != null && row["PQX32"].ToString( ) != "" )
                    model.PQX32 =long.Parse( row["PQX32"].ToString( ) );
                if ( row["PQX02"] != null && row["PQX02"].ToString( ) != "" )
                    model.PQX02 = row["PQX02"].ToString( );
                if ( row["PQX03"] != null && row["PQX03"].ToString( ) != "" )
                    model.PQX03 = row["PQX03"].ToString( );
                if ( row["PQX04"] != null && row["PQX04"].ToString( ) != "" )
                    model.PQX04 = DateTime.Parse( row["PQX04"].ToString( ) );
                if ( row["PQX05"] != null && row["PQX05"].ToString( ) != "" )
                    model.PQX05 = DateTime.Parse( row["PQX05"].ToString( ) );
                if ( row["PQX06"] != null && row["PQX06"].ToString( ) != "" )
                    model.PQX06 = row["PQX06"].ToString( );
                if ( row["PQX07"] != null && row["PQX07"].ToString( ) != "" )
                    model.PQX07 = DateTime.Parse( row["PQX07"].ToString( ) );
                if ( row["PQX08"] != null && row["PQX08"].ToString( ) != "" )
                    model.PQX08 = row["PQX08"].ToString( );
                if ( row["PQX09"] != null && row["PQX09"].ToString( ) != "" )
                    model.PQX09 = DateTime.Parse( row["PQX09"].ToString( ) );
                if ( row["PQX10"] != null && row["PQX10"].ToString( ) != "" )
                    model.PQX10 = row["PQX10"].ToString( );
                if ( row["PQX11"] != null && row["PQX11"].ToString( ) != "" )
                    model.PQX11 = DateTime.Parse( row["PQX11"].ToString( ) );
                if ( row["PQX12"] != null && row["PQX12"].ToString( ) != "" )
                    model.PQX12 = DateTime.Parse( row["PQX12"].ToString( ) );
                if ( row["PQX13"] != null && row["PQX13"].ToString( ) != "" )
                    model.PQX13 = row["PQX13"].ToString( );
                else
                    model.PQX13 = "";
                if ( row["PQX14"] != null && row["PQX14"].ToString( ) != "" )
                    model.PQX14 = row["PQX14"].ToString( );
                if ( row["PQX15"] != null && row["PQX15"].ToString( ) != "" )
                    model.PQX15 = row["PQX15"].ToString( );
                if ( row["PQX16"] != null && row["PQX16"].ToString( ) != "" )
                    model.PQX16 = int.Parse( row["PQX16"].ToString( ) );
                if ( row["PQX17"] != null && row["PQX17"].ToString( ) != "" )
                    model.PQX17 = row["PQX17"].ToString( );
                if ( row["PQX18"] != null && row["PQX18"].ToString( ) != "" )
                    model.PQX18 = int.Parse( row["PQX18"].ToString( ) );
                if ( row["PQX19"] != null && row["PQX19"].ToString( ) != "" )
                    model.PQX19 = int.Parse( row["PQX19"].ToString( ) );
                if ( row["PQX20"] != null && row["PQX20"].ToString( ) != "" )
                    model.PQX20 = row["PQX20"].ToString( );
                if ( row["PQX21"] != null && row["PQX21"].ToString( ) != "" )
                    model.PQX21 = row["PQX21"].ToString( );
                //if ( row["PQX22"] != null && row["PQX22"].ToString( ) != "" )
                //    model.PQX22 = long.Parse( row["PQX22"].ToString( ) );
                //if ( row["PQX23"] != null && row["PQX23"].ToString( ) != "" )
                //    model.PQX23 = long.Parse( row["PQX23"].ToString( ) );
                if ( row["PQX24"] != null && row["PQX24"].ToString( ) != "" )
                    model.PQX24 = long.Parse( row["PQX24"].ToString( ) );
                if ( row["PQX25"] != null && row["PQX25"].ToString( ) != "" )
                    model.PQX25 = DateTime.Parse( row["PQX25"].ToString( ) );
                if ( row["PQX27"] != null && row["PQX27"].ToString( ) != "" )
                    model.PQX27 = row["PQX27"].ToString( );
                if ( row["PQX34"] != null && row["PQX34"].ToString( ) != "" )
                    model.PQX34 = long.Parse( row["PQX34"].ToString( ) );
                if ( row["PQX36"] != null && row["PQX36"].ToString( ) != "" )
                    model.PQX36 = int.Parse( row["PQX36"].ToString( ) );
                if ( row["PQX37"] != null && row["PQX37"].ToString( ) != "" )
                    model.PQX37 = row["PQX37"].ToString( );
                if ( row [ "PQX38" ] != null && row [ "PQX38" ] . ToString ( ) != "" )
                    model . PQX38 = row [ "PQX38" ] . ToString ( );
            }
            return model;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string strWhere ,string numCount)
        {
            //DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 U1
            //DATEDIFF( DAY ,CONVERT(DATE,GETDATE(),121) ,PQX30 ) - PQX19 - PQX18 U2
            StringBuilder strSql = new StringBuilder( );//DATEADD( DAY ,( -PQX19 - PQX18 ) ,PQX30 ) U3
            /*
            strSql .Append( "SELECT idx,PQX16,PQX17,PQX37,PQX15,PQX30,PQX25,PQX36,DATEDIFF( DAY ,PQX25 ,PQX30 ) U0,PQX19,PQX18,DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 + PQX16 - PQX18 U1,CONVERT(DATE,GETDATE(),121) PQX26,DATEADD(DAY,DATEDIFF( DAY ,CONVERT(DATE,GETDATE(),121) ,PQX30 ) - PQX19 + PQX16 - PQX18,CONVERT(DATE,GETDATE(),121)) U3 ,DATEDIFF( DAY ,CONVERT(DATE,GETDATE(),121) ,PQX30 ) - PQX19 + PQX16 - PQX18 U2 ,DATEDIFF( DAY ,PQX25 ,CONVERT(DATE,GETDATE(),121) ) U4 ,PQX32 ,(SELECT DS06 FROM R_PQR WHERE DS01=PQX01 AND DS03=PQX14 AND DS04=PQX15) PQX22 ,(SELECT CASE WHEN (SELECT COUNT(1) FROM (SELECT GZ35,GZ24,GZ17 FROM R_PQW WHERE CONVERT(DATE,GETDATE(),23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)) AND GZ01 IN (" + numCount+") AND GZ03=PQX14 AND GZ04=PQX15 GROUP BY GZ35,GZ24,GZ17) A)=0 THEN 0 WHEN (SELECT COUNT(1) FROM (SELECT GZ35,GZ24,GZ17 FROM R_PQW WHERE CONVERT(DATE,GETDATE(),23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)) AND GZ01 IN ("+numCount+") AND GZ03=PQX14 AND GZ04=PQX15 GROUP BY GZ35,GZ24,GZ17) A)!=0 THEN SUM(GZ25+GZ26)/(SELECT COUNT(1) FROM (SELECT GZ35,GZ24,GZ17 FROM R_PQW WHERE CONVERT(DATE,GETDATE(),23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)) AND GZ01 IN ("+numCount+") AND GZ03=PQX14 AND GZ04=PQX15 GROUP BY GZ35,GZ24,GZ17) A) END U0 FROM R_PQW WHERE CONVERT(DATE,GETDATE(),23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17))AND GZ01 IN ("+numCount+ ") AND GZ03=PQX14 AND GZ04=PQX15) PQX23 ,CASE WHEN PQX32 = 0 OR PQX32 IS NULL THEN 0 WHEN DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 = 0 THEN 0 WHEN PQX32 != 0 AND PQX32 IS NOT NULL THEN ROUND( PQX32 / ( DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 ) ,0 ) END U7 ,ISNULL((SELECT ISNULL(GZ25,0)+ISNULL(GZ26,0) GZ FROM R_PQW WHERE idx IN (SELECT MAX(B.idx) ID FROM R_PQW B WHERE B.GZ01 IN (" + numCount + ") AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND ISNULL(GZ25,0)+ISNULL(GZ26,0)!=0 GROUP BY GZ03,GZ04)),0)  PQX24,CASE WHEN PQX32 = 0 OR PQX32 IS NULL THEN 0 WHEN DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 = 0 THEN 0 WHEN PQX32 != 0 AND PQX32 IS NOT NULL THEN ROUND( ( DATEDIFF( DAY ,PQX25 ,CONVERT(DATE,GETDATE(),121) ) ) * ( PQX32 / ( DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 ) ) ,0 ) END U13 ,PQX13 ,PQX14 ,PQX20 ,PQX21,(SELECT ISNULL(SUM(GZ25+GZ26),0) GZ FROM R_PQW B WHERE B.GZ01 IN (" + numCount + ") AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND CONVERT(DATE,GETDATE(),23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)))PQX34,ISNULL(U17,0.0) U17,U18,U12 FROM R_PQX A" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " WHERE " + strWhere );
                strSql.Append( " AND PQX14 IS NOT NULL AND PQX14 != ''" );
            }
            strSql.Append( " ORDER BY REVERSE(PQX14) ,PQX17 ASC ,PQX16" );
            */
            //u2  u4 u12 u14 u29
            //strSql . Append ( "SELECT idx,PQX16,PQX17,PQX37,PQX15,PQX30,PQX25,PQX36,DATEDIFF( DAY ,PQX25 ,PQX30 ) U0,PQX19,PQX18,DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 + PQX16 - PQX18 U1,CONVERT(DATE,GETDATE(),121) PQX26,DATEADD(DAY,DATEDIFF( DAY ,CONVERT(DATE,GETDATE(),121) ,PQX30 ) - PQX19 + PQX16 - PQX18,CONVERT(DATE,GETDATE(),121)) U3,ISNULL(U2,0) U2,ISNULL(U4,0) U4 ,PQX32 ,ISNULL((SELECT TOP 1 DS06 FROM R_PQR WHERE DS01=PQX01 AND DS03=PQX14 AND DS04=PQX15),0) PQX22 ,(SELECT CASE WHEN (SELECT COUNT(1) FROM (SELECT GZ35,GZ24,GZ17 FROM R_PQW WHERE CONVERT(DATE,GETDATE(),23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)) AND GZ01 IN (" + numCount + ") AND GZ03=PQX14 AND GZ04=PQX15 GROUP BY GZ35,GZ24,GZ17) A)=0 THEN 0 WHEN (SELECT COUNT(1) FROM (SELECT GZ35,GZ24,GZ17 FROM R_PQW WHERE CONVERT(DATE,GETDATE(),23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)) AND GZ01 IN (" + numCount + ") AND GZ03=PQX14 AND GZ04=PQX15 GROUP BY GZ35,GZ24,GZ17) A)!=0 THEN SUM(GZ25+GZ26)/(SELECT COUNT(1) FROM (SELECT GZ35,GZ24,GZ17 FROM R_PQW WHERE CONVERT(DATE,GETDATE(),23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)) AND GZ01 IN (" + numCount + ") AND GZ03=PQX14 AND GZ04=PQX15 GROUP BY GZ35,GZ24,GZ17) A) END U0 FROM R_PQW WHERE CONVERT(DATE,GETDATE(),23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17))AND GZ01 IN (" + numCount + ") AND GZ03=PQX14 AND GZ04=PQX15) PQX23 ,CASE WHEN PQX38='委外' OR PQX38='采购' OR PQX38='承揽' THEN PQX24 ELSE ISNULL((SELECT ISNULL(GZ25,0)+ISNULL(GZ26,0) GZ FROM R_PQW WHERE idx IN (SELECT MAX(B.idx) ID FROM R_PQW B WHERE B.GZ01 IN (" + numCount + ") AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND ISNULL(GZ25,0)+ISNULL(GZ26,0)!=0 GROUP BY GZ03,GZ04)),0) END  PQX24,CASE WHEN PQX32 = 0 OR PQX32 IS NULL THEN 0 WHEN PQX36 = 0 OR PQX36 IS NULL THEN 0 WHEN DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 +PQX16 - PQX18 = 0 THEN 0 WHEN PQX32 != 0 AND PQX32 IS NOT NULL THEN ROUND( PQX32*PQX36 / (DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 +PQX16- PQX18 ) ,0 ) END U7,CASE WHEN PQX32 = 0 OR PQX32 IS NULL THEN 0 WHEN DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 = 0 THEN 0 WHEN PQX32 != 0 AND PQX32 IS NOT NULL THEN ROUND( ( DATEDIFF( DAY ,PQX25 ,CONVERT(DATE,GETDATE(),121) ) ) * ( PQX32 / ( DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 ) ) ,0 ) END U13 ,PQX13 ,PQX14 ,PQX20 ,PQX21,CASE WHEN PQX38='委外' OR PQX38='采购' OR PQX38='承揽' THEN PQX34 ELSE (SELECT ISNULL(SUM(GZ25+GZ26),0) GZ FROM R_PQW B WHERE B.GZ01 IN (" + numCount + ") AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND CONVERT(DATE,GETDATE(),23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17))) END PQX34,ISNULL(U17,0.0) U17,ISNULL(U18,0) U18,ISNULL(U12,0) U12,ISNULL(U14,0) U14,ISNULL(U29,0) U29,ISNULL(U9,0) U9,PQX38 FROM R_PQX A" );
            //
            strSql . Append ( "SELECT idx,PQX16,PQX17,PQX37,PQX15,PQX30,PQX25,PQX36,DATEDIFF( DAY ,PQX25 ,PQX30 ) U0,PQX19,PQX18,DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 + PQX16 - PQX18 U1,CONVERT(DATE,GETDATE(),121) PQX26,DATEADD(DAY,DATEDIFF( DAY ,CONVERT(DATE,GETDATE(),121) ,PQX30 ) - PQX19 + PQX16 - PQX18,CONVERT(DATE,GETDATE(),121)) U3,ISNULL(U2,0) U2,ISNULL(U4,0) U4 ,PQX32 ,ISNULL((SELECT TOP 1 DS06 FROM R_PQR WHERE DS01=PQX01 AND DS03=PQX14 AND DS04=PQX15),0) PQX22 ,(SELECT CASE WHEN (SELECT COUNT(1) FROM (SELECT GZ35,GZ24,GZ17 FROM R_PQW WHERE CONVERT(DATE,GETDATE(),23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)) AND GZ01 IN (" + numCount + ") AND GZ03=PQX14 AND GZ04=PQX15 GROUP BY GZ35,GZ24,GZ17) A)=0 THEN 0 WHEN (SELECT COUNT(1) FROM (SELECT GZ35,GZ24,GZ17 FROM R_PQW WHERE CONVERT(DATE,GETDATE(),23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)) AND GZ01 IN (" + numCount + ") AND GZ03=PQX14 AND GZ04=PQX15 GROUP BY GZ35,GZ24,GZ17) A)!=0 THEN SUM(GZ25+GZ26)/(SELECT COUNT(1) FROM (SELECT GZ35,GZ24,GZ17 FROM R_PQW WHERE CONVERT(DATE,GETDATE(),23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)) AND GZ01 IN (" + numCount + ") AND GZ03=PQX14 AND GZ04=PQX15 GROUP BY GZ35,GZ24,GZ17) A) END U0 FROM R_PQW WHERE CONVERT(DATE,GETDATE(),23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17))AND GZ01 IN (" + numCount + ") AND GZ03=PQX14 AND GZ04=PQX15) PQX23 ,ISNULL((SELECT ISNULL(GZ25,0)+ISNULL(GZ26,0) GZ FROM R_PQW WHERE idx IN (SELECT MAX(B.idx) ID FROM R_PQW B WHERE B.GZ01 IN (" + numCount + ") AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND ISNULL(GZ25,0)+ISNULL(GZ26,0)!=0 GROUP BY GZ03,GZ04)),0)+PQX24  PQX24,CASE WHEN PQX32 = 0 OR PQX32 IS NULL THEN 0 WHEN PQX36 = 0 OR PQX36 IS NULL THEN 0 WHEN DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 +PQX16 - PQX18 = 0 THEN 0 WHEN PQX32 != 0 AND PQX32 IS NOT NULL THEN ROUND( PQX32*PQX36 / (DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 +PQX16- PQX18 ) ,0 ) END U7,CASE WHEN PQX32 = 0 OR PQX32 IS NULL THEN 0 WHEN DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 = 0 THEN 0 WHEN PQX32 != 0 AND PQX32 IS NOT NULL THEN ROUND( ( DATEDIFF( DAY ,PQX25 ,CONVERT(DATE,GETDATE(),121) ) ) * ( PQX32 / ( DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 ) ) ,0 ) END U13 ,PQX13 ,PQX14 ,PQX20 ,PQX21,(SELECT ISNULL(SUM(GZ25+GZ26),0) GZ FROM R_PQW B WHERE B.GZ01 IN (" + numCount + ") AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND CONVERT(DATE,GETDATE(),23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)))+PQX34 PQX34,ISNULL(U17,0.0) U17,ISNULL(U18,0) U18,CASE WHEN ISNULL(U12,0)<0 THEN 0 ELSE ISNULL(U12,0) END U12,ISNULL(U14,0) U14,ISNULL(U29,0) U29,ISNULL(U9,0) U9,PQX38 FROM R_PQX A" );
            if ( !string . IsNullOrEmpty ( strWhere ) )
            {
                strSql . Append ( " WHERE " + strWhere );
                strSql . Append ( " AND PQX14 IS NOT NULL AND PQX14 != ''" );
            }
            strSql . Append ( " ORDER BY PQX13,PQX16,REVERSE(PQX14),PQX38" );
            
            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 生成配套表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="dateD"></param>
        /// <returns></returns>
        public DataTable GetDataTableProduct ( string strWhere ,DateTime dateD ,string numCount )
        {
            StringBuilder strSql = new StringBuilder ( );
            /*
            strSql . AppendFormat ( "SELECT idx,PQX16,PQX17,PQX15,PQX30,PQX25,PQX36,DATEDIFF( DAY ,PQX25 ,PQX30 ) U0,PQX19,PQX18,DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 + PQX16 - PQX18 U1,CONVERT(DATE,'{0}',121) PQX26,DATEADD(DAY,DATEDIFF( DAY ,CONVERT(DATE,GETDATE(),121) ,PQX30 ) - PQX19 + PQX16 - PQX18,CONVERT(DATE,'{0}',121)) U3 ,DATEDIFF( DAY ,CONVERT(DATE,'{0}',121) ,PQX30 ) - PQX19 + PQX16 - PQX18 U2 ,DATEDIFF( DAY ,PQX25 ,CONVERT(DATE,'{0}',121) ) U4 ,PQX32 ,(SELECT DS06 FROM R_PQR WHERE DS01=PQX01 AND DS03=PQX14 AND DS04=PQX15) PQX22 ,(SELECT CASE WHEN (SELECT COUNT(1) FROM (SELECT GZ35,GZ24,GZ17 FROM R_PQW WHERE CONVERT(DATE,'{0}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)) AND GZ01 IN (" + numCount + ") AND GZ03=PQX14 AND GZ04=PQX15 GROUP BY GZ35,GZ24,GZ17) A)=0 THEN 0 WHEN (SELECT COUNT(1) FROM (SELECT GZ35,GZ24,GZ17 FROM R_PQW WHERE CONVERT(DATE,'{0}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)) AND GZ01  IN (" + numCount + ") AND GZ03=PQX14 AND GZ04=PQX15 GROUP BY GZ35,GZ24,GZ17) A)!=0 THEN SUM(GZ25+GZ26)/(SELECT COUNT(1) FROM (SELECT GZ35,GZ24,GZ17 FROM R_PQW WHERE CONVERT(DATE,'{0}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)) AND GZ01  IN (" + numCount + ") AND GZ03=PQX14 AND GZ04=PQX15 GROUP BY GZ35,GZ24,GZ17) A) END U0 FROM R_PQW WHERE CONVERT(DATE,'{0}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17))AND GZ01  IN (" + numCount + ") AND GZ03=PQX14 AND GZ04=PQX15)PQX23 ,CASE WHEN PQX32 = 0 OR PQX32 IS NULL THEN 0 WHEN DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 = 0 THEN 0 WHEN PQX32 != 0 AND PQX32 IS NOT NULL THEN ROUND( PQX32 / ( DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 ) ,0 ) END U7 ,ISNULL((SELECT ISNULL(GZ25,0)+ISNULL(GZ26,0) GZ FROM R_PQW WHERE idx IN (SELECT MAX(B.idx) ID FROM R_PQW B WHERE B.GZ01 IN (" + numCount + ") AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND ISNULL(GZ25,0)+ISNULL(GZ26,0)!=0 GROUP BY GZ03,GZ04)),0) PQX24,CASE WHEN PQX32 = 0 OR PQX32 IS NULL THEN 0 WHEN DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 = 0 THEN 0 WHEN PQX32 != 0 AND PQX32 IS NOT NULL THEN ROUND( ( DATEDIFF( DAY ,PQX25 ,CONVERT(DATE,'{0}',121) ) ) * ( PQX32 / ( DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 ) ) ,0 ) END U13 ,PQX13 ,PQX17+PQX14 PQX14,PQX20 ,PQX21,(SELECT ISNULL(SUM(GZ25+GZ26),0) GZ FROM R_PQW B WHERE B.GZ01 IN (" + numCount + ") AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND CONVERT(DATE,'{0}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)))PQX34,ISNULL(U17,0.0) U17,U18 FROM R_PQX A" ,dateD );
            strSql . Append ( " WHERE " + strWhere );
            strSql . Append ( " ORDER BY PQX16 DESC,PQX14" );
            */

            strSql . AppendFormat ( "SELECT idx,PQX16,PQX17,PQX15,PQX30,PQX25,PQX36,DATEDIFF( DAY ,PQX25 ,PQX30 ) U0,PQX19,PQX18,DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 + PQX16 - PQX18 U1,CONVERT(DATE,'{0}',121) PQX26,DATEADD(DAY,DATEDIFF( DAY ,CONVERT(DATE,GETDATE(),121) ,PQX30 ) - PQX19 + PQX16 - PQX18,CONVERT(DATE,'{0}',121)) U3,ISNULL(U2,0) U2,ISNULL(U4,0) U4 ,PQX32 ,ISNULL((SELECT TOP 1 DS06 FROM R_PQR WHERE DS01=PQX01 AND DS03=PQX14 AND DS04=PQX15),0) PQX22 ,(SELECT CASE WHEN (SELECT COUNT(1) FROM (SELECT GZ35,GZ24,GZ17 FROM R_PQW WHERE CONVERT(DATE,'{0}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)) AND GZ01 IN (" + numCount + ") AND GZ03=PQX14 AND GZ04=PQX15 GROUP BY GZ35,GZ24,GZ17) A)=0 THEN 0 WHEN (SELECT COUNT(1) FROM (SELECT GZ35,GZ24,GZ17 FROM R_PQW WHERE CONVERT(DATE,'{0}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)) AND GZ01  IN (" + numCount + ") AND GZ03=PQX14 AND GZ04=PQX15 GROUP BY GZ35,GZ24,GZ17) A)!=0 THEN SUM(GZ25+GZ26)/(SELECT COUNT(1) FROM (SELECT GZ35,GZ24,GZ17 FROM R_PQW WHERE CONVERT(DATE,'{0}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)) AND GZ01  IN (" + numCount + ") AND GZ03=PQX14 AND GZ04=PQX15 GROUP BY GZ35,GZ24,GZ17) A) END U0 FROM R_PQW WHERE CONVERT(DATE,'{0}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17))AND GZ01  IN (" + numCount + ") AND GZ03=PQX14 AND GZ04=PQX15) PQX23,ISNULL((SELECT ISNULL(GZ25,0)+ISNULL(GZ26,0) GZ FROM R_PQW WHERE idx IN (SELECT MAX(B.idx) ID FROM R_PQW B WHERE B.GZ01 IN (" + numCount + ") AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND ISNULL(GZ25,0)+ISNULL(GZ26,0)!=0 GROUP BY GZ03,GZ04)),0)+PQX24 PQX24,CASE WHEN PQX32 = 0 OR PQX32 IS NULL THEN 0 WHEN PQX36 = 0 OR PQX36 IS NULL THEN 0 WHEN DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 +PQX16 - PQX18 = 0 THEN 0 WHEN PQX32 != 0 AND PQX32 IS NOT NULL THEN ROUND( PQX32*PQX36 / (DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 +PQX16- PQX18 ) ,0 ) END U7,CASE WHEN PQX32 = 0 OR PQX32 IS NULL THEN 0 WHEN DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 = 0 THEN 0 WHEN PQX32 != 0 AND PQX32 IS NOT NULL THEN ROUND( ( DATEDIFF( DAY ,PQX25 ,CONVERT(DATE,'{0}',121) ) ) * ( PQX32 / ( DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 ) ) ,0 ) END U13 ,PQX13 ,PQX17+PQX14 PQX14,PQX20 ,PQX21,(SELECT ISNULL(SUM(GZ25+GZ26),0) GZ FROM R_PQW B WHERE B.GZ01 IN (" + numCount + ") AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND CONVERT(DATE,'{0}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)))+PQX34 PQX34,ISNULL(U17,0.0) U17,ISNULL(U18,0) U18,CASE WHEN ISNULL(U12,0)<0 THEN 0 ELSE ISNULL(U12,0) END U12,ISNULL(U14,0) U14,ISNULL(U29,0) U29,ISNULL(U9,0) U9,PQX38 FROM R_PQX A " ,dateD );
            //CASE WHEN PQX32 = 0 OR PQX32 IS NULL THEN 0 WHEN DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 = 0 THEN 0 WHEN PQX32 != 0 AND PQX32 IS NOT NULL THEN ROUND( PQX32 / ( DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 ) ,0 ) END U7 ,
            strSql . Append ( " WHERE " + strWhere );
            strSql . Append ( " ORDER BY PQX16,PQX21" );
            //strSql . Append ( " ORDER BY PQX16 DESC,PQX14" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="dateD"></param>
        /// <param name="numCount"></param>
        /// <returns></returns>
        public DataTable printTableOne ( string strWhere ,DateTime dateD ,string numCount )
        {
            StringBuilder strSql = new StringBuilder ( );
            //strSql . AppendFormat ( "WITH CET AS (SELECT idx,PQX16,PQX17,PQX15,PQX30,PQX25,PQX36,DATEDIFF( DAY ,PQX25 ,PQX30 ) U0,PQX19,PQX18,DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 + PQX16 - PQX18 U1,CONVERT(DATE,'{0}',121) PQX26,DATEADD(DAY,DATEDIFF( DAY ,CONVERT(DATE,GETDATE(),121) ,PQX30 ) - PQX19 + PQX16 - PQX18,CONVERT(DATE,'{0}',121)) U3 ,DATEDIFF( DAY ,CONVERT(DATE,'{0}',121) ,PQX30 ) - PQX19 + PQX16 - PQX18 U2 ,DATEDIFF( DAY ,PQX25 ,CONVERT(DATE,'{0}',121) ) U4 ,PQX32 ,(SELECT DS06 FROM R_PQR WHERE DS01=PQX01 AND DS03=PQX14 AND DS04=PQX15) PQX22 ,(SELECT CASE WHEN (SELECT COUNT(1) FROM (SELECT GZ35,GZ24,GZ17 FROM R_PQW WHERE CONVERT(DATE,'{0}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)) AND GZ01 IN (" + numCount + ") AND GZ03=PQX14 AND GZ04=PQX15 GROUP BY GZ35,GZ24,GZ17) A)=0 THEN 0 WHEN (SELECT COUNT(1) FROM (SELECT GZ35,GZ24,GZ17 FROM R_PQW WHERE CONVERT(DATE,'{0}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)) AND GZ01  IN (" + numCount + ") AND GZ03=PQX14 AND GZ04=PQX15 GROUP BY GZ35,GZ24,GZ17) A)!=0 THEN SUM(GZ25+GZ26)/(SELECT COUNT(1) FROM (SELECT GZ35,GZ24,GZ17 FROM R_PQW WHERE CONVERT(DATE,'{0}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)) AND GZ01  IN (" + numCount + ") AND GZ03=PQX14 AND GZ04=PQX15 GROUP BY GZ35,GZ24,GZ17) A) END U0 FROM R_PQW WHERE CONVERT(DATE,'{0}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17))AND GZ01  IN (" + numCount + ") AND GZ03=PQX14 AND GZ04=PQX15)PQX23 ,CASE WHEN PQX32 = 0 OR PQX32 IS NULL THEN 0 WHEN DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 = 0 THEN 0 WHEN PQX32 != 0 AND PQX32 IS NOT NULL THEN ROUND( PQX32 / ( DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 ) ,0 ) END U7 ,ISNULL((SELECT ISNULL(GZ25,0)+ISNULL(GZ26,0) GZ FROM R_PQW WHERE idx IN (SELECT MAX(B.idx) ID FROM R_PQW B WHERE B.GZ01 IN (" + numCount + ") AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND ISNULL(GZ25,0)+ISNULL(GZ26,0)!=0 GROUP BY GZ03,GZ04)),0) PQX24,CASE WHEN PQX32 = 0 OR PQX32 IS NULL THEN 0 WHEN DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 = 0 THEN 0 WHEN PQX32 != 0 AND PQX32 IS NOT NULL THEN ROUND( ( DATEDIFF( DAY ,PQX25 ,CONVERT(DATE,'{0}',121) ) ) * ( PQX32 / ( DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 ) ) ,0 ) END U13 ,PQX13 ,PQX17+PQX14 PQX14,PQX20 ,PQX21,(SELECT ISNULL(SUM(GZ25+GZ26),0) GZ FROM R_PQW B WHERE B.GZ01 IN (" + numCount + ") AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND CONVERT(DATE,'{0}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)))PQX34,ISNULL(U17,0.0) U17,U18 FROM R_PQX A" ,dateD );
            //strSql . Append ( " WHERE " + strWhere );
            //strSql . Append ( " ) SELECT *,CASE WHEN PQX36=0 THEN 0 ELSE (PQX32*PQX36-PQX34)/PQX36 END U19,CASE WHEN U2=0 THEN 0 ELSE (PQX32*PQX36-PQX34)/U2 END U20,CASE WHEN PQX36=0 THEN 0 ELSE PQX24/PQX36 END U21,CASE WHEN U2*PQX36=0 THEN 0 ELSE (PQX36*PQX32-PQX34)/(U2*PQX36) END U22,CASE WHEN U2=0 THEN 0 ELSE PQX24-(PQX32*PQX36-PQX34)/U2 END U23,CASE WHEN U2*PQX36=0 THEN 0 ELSE PQX24-(PQX36*PQX32-PQX34)/(U2*PQX36) END U24,CASE WHEN PQX32*PQX36=0 THEN 0 ELSE CONVERT(DECIMAL(18,2),PQX34*1.0/(PQX32*PQX36)) END U25,CONVERT(VARCHAR,MONTH(U3))+'月'+CONVERT(VARCHAR,DAY(U3))+'日' U3X FROM CET" );
            strSql . AppendFormat ( "WITH CET AS (SELECT idx,PQX16,PQX17,PQX15,PQX30,CONVERT(VARCHAR,MONTH(PQX25))+'月'+CONVERT(VARCHAR,DAY(PQX25))+'日' PQX25,PQX36,DATEDIFF( DAY ,PQX25 ,PQX30 ) U0,PQX19,PQX18,DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 + PQX16 - PQX18 U1,CONVERT(DATE,'{0}',121) PQX26,DATEADD(DAY,DATEDIFF( DAY ,CONVERT(DATE,GETDATE(),121) ,PQX30 ) - PQX19 + PQX16 - PQX18,CONVERT(DATE,'{0}',121)) U3 ,ISNULL(U2,0) U2 ,ISNULL(U4,0) U4 ,PQX32 ,(SELECT  TOP 1 DS06 FROM R_PQR WHERE DS01=PQX01 AND DS03=PQX14 AND DS04=PQX15) PQX22 ,(SELECT CASE WHEN (SELECT COUNT(1) FROM (SELECT GZ35,GZ24,GZ17 FROM R_PQW WHERE CONVERT(DATE,'{0}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)) AND GZ01 IN (" + numCount + ") AND GZ03=PQX14 AND GZ04=PQX15 GROUP BY GZ35,GZ24,GZ17) A)=0 THEN 0 WHEN (SELECT COUNT(1) FROM (SELECT GZ35,GZ24,GZ17 FROM R_PQW WHERE CONVERT(DATE,'{0}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)) AND GZ01  IN (" + numCount + ") AND GZ03=PQX14 AND GZ04=PQX15 GROUP BY GZ35,GZ24,GZ17) A)!=0 THEN SUM(GZ25+GZ26)/(SELECT COUNT(1) FROM (SELECT GZ35,GZ24,GZ17 FROM R_PQW WHERE CONVERT(DATE,'{0}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)) AND GZ01  IN (" + numCount + ") AND GZ03=PQX14 AND GZ04=PQX15 GROUP BY GZ35,GZ24,GZ17) A) END U0 FROM R_PQW WHERE CONVERT(DATE,'{0}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17))AND GZ01  IN (" + numCount + ") AND GZ03=PQX14 AND GZ04=PQX15)PQX23 ,CASE WHEN PQX32 = 0 OR PQX32 IS NULL THEN 0 WHEN DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 = 0 THEN 0 WHEN PQX32 != 0 AND PQX32 IS NOT NULL THEN ROUND( PQX32 / ( DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 ) ,0 ) END U7 ,ISNULL((SELECT ISNULL(GZ25,0)+ISNULL(GZ26,0) GZ FROM R_PQW WHERE idx IN (SELECT MAX(B.idx) ID FROM R_PQW B WHERE B.GZ01 IN (" + numCount + ") AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND ISNULL(GZ25,0)+ISNULL(GZ26,0)!=0 GROUP BY GZ03,GZ04)),0)+PQX24 PQX24,CASE WHEN PQX32 = 0 OR PQX32 IS NULL THEN 0 WHEN DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 = 0 THEN 0 WHEN PQX32 != 0 AND PQX32 IS NOT NULL THEN ROUND( ( DATEDIFF( DAY ,PQX25 ,CONVERT(DATE,'{0}',121) ) ) * ( PQX32 / ( DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 ) ) ,0 ) END U13 ,PQX13 ,PQX17+PQX14 PQX14,PQX20 ,PQX21,(SELECT ISNULL(SUM(GZ25+GZ26),0) GZ FROM R_PQW B WHERE B.GZ01 IN (" + numCount + ") AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND CONVERT(DATE,'{0}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)))+PQX34 PQX34,ISNULL(U17,0.0) U17,ISNULL(U18,0) U18,CASE WHEN ISNULL(U12,0)<0 THEN 0 ELSE ISNULL(U12,0) END U12,ISNULL(U14,0) U14,ISNULL(U29,0) U29,ISNULL(U9,0) U20 FROM R_PQX A" ,dateD );
            strSql . Append ( " WHERE " + strWhere );
            strSql . Append ( " ) ,CFT AS(SELECT *,CASE WHEN PQX36=0 THEN 0 ELSE (PQX32*PQX36-PQX34)/PQX36 END U19,CASE WHEN PQX36=0 THEN 0 ELSE PQX24/PQX36 END U21,CASE WHEN PQX36=0 THEN 0 ELSE U20/PQX36 END U22,CASE WHEN PQX24-U20>0 THEN 0 ELSE PQX24-U20 END U23,CASE WHEN PQX36=0 THEN 0 ELSE U20/PQX36 END U24,CASE WHEN PQX32*PQX36=0 THEN 0 ELSE CONVERT(DECIMAL(18,2),PQX34*1.0/(PQX32*PQX36)) END U25,CONVERT(VARCHAR,MONTH(U3))+'月'+CONVERT(VARCHAR,DAY(U3))+'日' U3X FROM CET) " );
            strSql . Append ( "SELECT * FROM CFT " );//AND U4<0  WHERE U25<1

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }
        
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableAll ( string strWhere,DateTime dateTi ,string numCount)
        {
            //@PQX26    @PQX26  @PQX26  @PQX26  @PQX26  @PQX26  @PQX26   @PQX26
            /*
            SELECT idx,PQX16,PQX17,PQX15,PQX30,PQX25,PQX36,DATEDIFF( DAY ,PQX25 ,PQX30 ) U0,PQX19,PQX18,DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 U1 ,CONVERT(DATE,'{0}',121) PQX26,DATEADD( DAY ,( -PQX19 - PQX18 ) ,PQX30 ) U3 ,DATEDIFF( DAY ,'{0}' ,PQX30 ) - PQX19 - PQX18 U2 ,DATEDIFF( DAY ,PQX25 ,'{0}' ) U4 ,PQX32 ,(SELECT DS06 FROM R_PQR WHERE DS27='{0}' AND DS01=PQX01 AND DS03=PQX14 AND DS04=PQX15)PQX22 ,(SELECT CASE WHEN (SELECT COUNT(1) FROM (SELECT GZ02 FROM R_PQW WHERE GZ35=YEAR('{0}') AND GZ24=MONTH('{0}') AND GZ17=DAY('{0}') AND GZ01=PQX01 AND GZ03=PQX14 AND GZ04=PQX15 GROUP BY GZ02) A)=0 THEN 0 WHEN (SELECT COUNT(1) FROM (SELECT GZ02 FROM R_PQW WHERE GZ35=YEAR('{0}') AND GZ24=MONTH('{0}') AND GZ17=DAY('{0}') AND GZ01=PQX01 AND GZ03=PQX14 AND GZ04=PQX15 GROUP BY GZ02) A)!=0 THEN SUM(GZ25+GZ26)/(SELECT COUNT(1) FROM (SELECT GZ02 FROM R_PQW WHERE GZ35=YEAR('{0}') AND GZ24=MONTH('{0}') AND GZ17=DAY('{0}') AND GZ01=PQX01 AND GZ03=PQX14 AND GZ04=PQX15 GROUP BY GZ02) A) END U0 FROM R_PQW WHERE GZ35=YEAR('{0}') AND GZ24=MONTH('{0}') AND GZ17=DAY('{0}') AND GZ01=PQX01 AND GZ03=PQX14 AND GZ04=PQX15) PQX23 ,CASE WHEN PQX32 = 0 OR PQX32 IS NULL THEN 0 WHEN DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 = 0 THEN 0 WHEN PQX32 != 0 AND PQX32 IS NOT NULL THEN ROUND( PQX32 / ( DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 ) ,0 ) END U7 ,(SELECT ISNULL(SUM(GZ25+GZ26),0) GZ FROM R_PQW B WHERE A.PQX01=B.GZ01 AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND DATEPART(MONTH,'{0}')=B.GZ24 AND DATEPART(DAY,'{0}')=B.GZ17) PQX24,CASE WHEN PQX32 = 0 OR PQX32 IS NULL THEN 0 WHEN DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 = 0 THEN 0 WHEN PQX32 != 0 AND PQX32 IS NOT NULL THEN ROUND( ( DATEDIFF( DAY ,PQX25 ,'{0}' ) ) * ( PQX32 / ( DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 ) ) ,0 ) END U13 ,PQX13 ,PQX14 ,PQX20 ,PQX21,(SELECT ISNULL(SUM(GZ25+GZ26),0) GZ FROM R_PQW B WHERE A.PQX01=B.GZ01 AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND DATEPART(MONTH,'{0}')>=B.GZ24 AND DATEPART(DAY,'{0}')>B.GZ17)PQX34,ISNULL(U17,0.0) U17,U18 FROM R_PQX A
            */ 

            StringBuilder strSql = new StringBuilder( );
            /*
            strSql.AppendFormat( "SELECT idx,PQX16,PQX17,PQX15,PQX30,PQX25,PQX36,DATEDIFF( DAY ,PQX25 ,PQX30 ) U0,PQX19,PQX18,DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 + PQX16 - PQX18 U1,CONVERT(DATE,'{0}',121) PQX26,DATEADD(DAY,DATEDIFF( DAY ,CONVERT(DATE,GETDATE(),121) ,PQX30 ) - PQX19 + PQX16 - PQX18,CONVERT(DATE,'{0}',121)) U3 ,DATEDIFF( DAY ,CONVERT(DATE,'{0}',121) ,PQX30 ) - PQX19 + PQX16 - PQX18 U2 ,DATEDIFF( DAY ,PQX25 ,CONVERT(DATE,'{0}',121) ) U4 ,PQX32 ,(SELECT DS06 FROM R_PQR WHERE DS01=PQX01 AND DS03=PQX14 AND DS04=PQX15) PQX22 ,(SELECT CASE WHEN (SELECT COUNT(1) FROM (SELECT GZ35,GZ24,GZ17 FROM R_PQW WHERE CONVERT(DATE,'{0}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)) AND GZ01 IN (" + numCount+ ") AND GZ03=PQX14 AND GZ04=PQX15 GROUP BY GZ35,GZ24,GZ17) A)=0 THEN 0 WHEN (SELECT COUNT(1) FROM (SELECT GZ35,GZ24,GZ17 FROM R_PQW WHERE CONVERT(DATE,'{0}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)) AND GZ01 IN (" + numCount + ") AND GZ03=PQX14 AND GZ04=PQX15 GROUP BY GZ35,GZ24,GZ17) A)!=0 THEN SUM(GZ25+GZ26)/(SELECT COUNT(1) FROM (SELECT GZ35,GZ24,GZ17 FROM R_PQW WHERE CONVERT(DATE,'{0}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)) AND GZ01 IN (" + numCount + ") AND GZ03=PQX14 AND GZ04=PQX15 GROUP BY GZ35,GZ24,GZ17) A) END U0 FROM R_PQW WHERE CONVERT(DATE,'{0}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17))AND GZ01 IN (" + numCount + ") AND GZ03=PQX14 AND GZ04=PQX15)PQX23 ,CASE WHEN PQX32 = 0 OR PQX32 IS NULL THEN 0 WHEN DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 = 0 THEN 0 WHEN PQX32 != 0 AND PQX32 IS NOT NULL THEN ROUND( PQX32 / ( DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 ) ,0 ) END U7 ,ISNULL((SELECT ISNULL(GZ25,0)+ISNULL(GZ26,0) GZ FROM R_PQW WHERE idx IN (SELECT MAX(B.idx) ID FROM R_PQW B WHERE B.GZ01 IN (" + numCount + ") AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND ISNULL(GZ25,0)+ISNULL(GZ26,0)!=0 GROUP BY GZ03,GZ04)),0) PQX24,CASE WHEN PQX32 = 0 OR PQX32 IS NULL THEN 0 WHEN DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 = 0 THEN 0 WHEN PQX32 != 0 AND PQX32 IS NOT NULL THEN ROUND( ( DATEDIFF( DAY ,PQX25 ,CONVERT(DATE,'{0}',121) ) ) * ( PQX32 / ( DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 ) ) ,0 ) END U13 ,PQX13 ,PQX14 ,PQX20 ,PQX21,(SELECT ISNULL(SUM(GZ25+GZ26),0) GZ FROM R_PQW B WHERE B.GZ01 IN (" + numCount + ") AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND CONVERT(DATE,'{0}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)))PQX34,ISNULL(U17,0.0) U17,U18,U12 FROM R_PQX A" ,dateTi );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " WHERE " + strWhere );
                strSql.Append( " AND PQX14 IS NOT NULL AND PQX14 != ''" );
            }
            strSql.Append( " ORDER BY  REVERSE(PQX14) ,PQX17 ASC ,PQX16" );
            */
            //strSql . AppendFormat ( "SELECT idx,PQX16,PQX17,PQX15,PQX30,PQX25,PQX36,DATEDIFF( DAY ,PQX25 ,PQX30 ) U0,PQX19,PQX18,DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 + PQX16 - PQX18 U1,CONVERT(DATE,'{0}',121) PQX26,DATEADD(DAY,DATEDIFF( DAY ,CONVERT(DATE,GETDATE(),121) ,PQX30 ) - PQX19 + PQX16 - PQX18,CONVERT(DATE,'{0}',121)) U3,ISNULL(U2,0) U2,ISNULL(U4,0) U4 ,PQX32,ISNULL((SELECT TOP 1 DS06 DS06 FROM R_PQR WHERE DS01=PQX01 AND DS03=PQX14 AND DS04=PQX15),0) PQX22 ,(SELECT CASE WHEN (SELECT COUNT(1) FROM (SELECT GZ35,GZ24,GZ17 FROM R_PQW WHERE CONVERT(DATE,'{0}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)) AND GZ01 IN (" + numCount + ") AND GZ03=PQX14 AND GZ04=PQX15 GROUP BY GZ35,GZ24,GZ17) A)=0 THEN 0 WHEN (SELECT COUNT(1) FROM (SELECT GZ35,GZ24,GZ17 FROM R_PQW WHERE CONVERT(DATE,'{0}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)) AND GZ01 IN (" + numCount + ") AND GZ03=PQX14 AND GZ04=PQX15 GROUP BY GZ35,GZ24,GZ17) A)!=0 THEN SUM(GZ25+GZ26)/(SELECT COUNT(1) FROM (SELECT GZ35,GZ24,GZ17 FROM R_PQW WHERE CONVERT(DATE,'{0}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)) AND GZ01 IN (" + numCount + ") AND GZ03=PQX14 AND GZ04=PQX15 GROUP BY GZ35,GZ24,GZ17) A) END U0 FROM R_PQW WHERE CONVERT(DATE,'{0}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17))AND GZ01 IN (" + numCount + ") AND GZ03=PQX14 AND GZ04=PQX15) PQX23 ,CASE WHEN PQX38='委外' OR PQX38='采购' OR PQX38='承揽' THEN PQX24 ELSE  ISNULL((SELECT ISNULL(GZ25,0)+ISNULL(GZ26,0) GZ FROM R_PQW WHERE idx IN (SELECT MAX(B.idx) ID FROM R_PQW B WHERE B.GZ01 IN (" + numCount + ") AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND ISNULL(GZ25,0)+ISNULL(GZ26,0)!=0 GROUP BY GZ03,GZ04)),0) END PQX24,CASE WHEN PQX32 = 0 OR PQX32 IS NULL THEN 0 WHEN PQX36 = 0 OR PQX36 IS NULL THEN 0 WHEN DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 +PQX16 - PQX18 = 0 THEN 0 WHEN PQX32 != 0 AND PQX32 IS NOT NULL THEN ROUND( PQX32*PQX36 / (DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 +PQX16- PQX18 ) ,0 ) END U7,CASE WHEN PQX32 = 0 OR PQX32 IS NULL THEN 0 WHEN DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 = 0 THEN 0 WHEN PQX32 != 0 AND PQX32 IS NOT NULL THEN ROUND( ( DATEDIFF( DAY ,PQX25 ,CONVERT(DATE,'{0}',121) ) ) * ( PQX32 / ( DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 ) ) ,0 ) END U13 ,PQX13 ,PQX14 ,PQX20 ,PQX21,CASE WHEN PQX38='委外' OR PQX38='采购' OR PQX38='承揽' THEN PQX34 ELSE (SELECT ISNULL(SUM(GZ25+GZ26),0) GZ FROM R_PQW B WHERE B.GZ01 IN (" + numCount + ") AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND CONVERT(DATE,'{0}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17))) END PQX34,ISNULL(U17,0.0) U17,ISNULL(U18,0) U18,ISNULL(U12,0) U12,ISNULL(U14,0) U14,ISNULL(U29,0) U29,ISNULL(U9,0) U9,PQX38 FROM R_PQX A" ,dateTi );
            //,CASE WHEN PQX32 = 0 OR PQX32 IS NULL THEN 0 WHEN DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 = 0 THEN 0 WHEN PQX32 != 0 AND PQX32 IS NOT NULL THEN ROUND( PQX32 / ( DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 ) ,0 ) END U7

            strSql . AppendFormat ( "SELECT idx,PQX16,PQX17,PQX15,PQX30,PQX25,PQX36,DATEDIFF( DAY ,PQX25 ,PQX30 ) U0,PQX19,PQX18,DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 + PQX16 - PQX18 U1,CONVERT(DATE,'{0}',121) PQX26,DATEADD(DAY,DATEDIFF( DAY ,CONVERT(DATE,GETDATE(),121) ,PQX30 ) - PQX19 + PQX16 - PQX18,CONVERT(DATE,'{0}',121)) U3,ISNULL(U2,0) U2,ISNULL(U4,0) U4 ,PQX32,ISNULL((SELECT TOP 1 DS06 DS06 FROM R_PQR WHERE DS01=PQX01 AND DS03=PQX14 AND DS04=PQX15),0) PQX22 ,(SELECT CASE WHEN (SELECT COUNT(1) FROM (SELECT GZ35,GZ24,GZ17 FROM R_PQW WHERE CONVERT(DATE,'{0}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)) AND GZ01 IN (" + numCount + ") AND GZ03=PQX14 AND GZ04=PQX15 GROUP BY GZ35,GZ24,GZ17) A)=0 THEN 0 WHEN (SELECT COUNT(1) FROM (SELECT GZ35,GZ24,GZ17 FROM R_PQW WHERE CONVERT(DATE,'{0}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)) AND GZ01 IN (" + numCount + ") AND GZ03=PQX14 AND GZ04=PQX15 GROUP BY GZ35,GZ24,GZ17) A)!=0 THEN SUM(GZ25+GZ26)/(SELECT COUNT(1) FROM (SELECT GZ35,GZ24,GZ17 FROM R_PQW WHERE CONVERT(DATE,'{0}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)) AND GZ01 IN (" + numCount + ") AND GZ03=PQX14 AND GZ04=PQX15 GROUP BY GZ35,GZ24,GZ17) A) END U0 FROM R_PQW WHERE CONVERT(DATE,'{0}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17))AND GZ01 IN (" + numCount + ") AND GZ03=PQX14 AND GZ04=PQX15) PQX23 ,ISNULL((SELECT ISNULL(GZ25,0)+ISNULL(GZ26,0) GZ FROM R_PQW WHERE idx IN (SELECT MAX(B.idx) ID FROM R_PQW B WHERE B.GZ01 IN (" + numCount + ") AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND ISNULL(GZ25,0)+ISNULL(GZ26,0)!=0 GROUP BY GZ03,GZ04)),0)+PQX24 PQX24,CASE WHEN PQX32 = 0 OR PQX32 IS NULL THEN 0 WHEN PQX36 = 0 OR PQX36 IS NULL THEN 0 WHEN DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 +PQX16 - PQX18 = 0 THEN 0 WHEN PQX32 != 0 AND PQX32 IS NOT NULL THEN ROUND( PQX32*PQX36 / (DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 +PQX16- PQX18 ) ,0 ) END U7,CASE WHEN PQX32 = 0 OR PQX32 IS NULL THEN 0 WHEN DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 = 0 THEN 0 WHEN PQX32 != 0 AND PQX32 IS NOT NULL THEN ROUND( ( DATEDIFF( DAY ,PQX25 ,CONVERT(DATE,'{0}',121) ) ) * ( PQX32 / ( DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 ) ) ,0 ) END U13 ,PQX13 ,PQX14 ,PQX20 ,PQX21,(SELECT ISNULL(SUM(GZ25+GZ26),0) GZ FROM R_PQW B WHERE B.GZ01 IN (" + numCount + ") AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND CONVERT(DATE,'{0}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)))+PQX34 PQX34,ISNULL(U17,0.0) U17,ISNULL(U18,0) U18,CASE WHEN ISNULL(U12,0)<0 THEN 0 ELSE ISNULL(U12,0) END U12,ISNULL(U14,0) U14,ISNULL(U29,0) U29,ISNULL(U9,0) U9,PQX38 FROM R_PQX A" ,dateTi );

            if ( !string . IsNullOrEmpty ( strWhere ) )
            {
                strSql . Append ( " WHERE " + strWhere );
                strSql . Append ( " AND PQX14 IS NOT NULL AND PQX14 != ''" );
            }
            strSql . Append ( " ORDER BY PQX13,PQX16,REVERSE(PQX14),PQX38" );


            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataRow GetDataRowAll ( string strWhere ,DateTime dateTi )
        {
            //@PQX26    @PQX26  @PQX26  @PQX26  @PQX26  @PQX26  @PQX26   @PQX26
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "SELECT idx,PQX16,PQX17,PQX15,PQX30,PQX25,PQX36,DATEDIFF( DAY ,PQX25 ,PQX30 ) U0,PQX19,PQX18,DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 U1 ,CONVERT(DATE,'{0}',121) PQX26,DATEADD(DAY,DATEDIFF( DAY ,CONVERT(DATE,GETDATE(),121) ,PQX30 ) - PQX19 + PQX16 - PQX18,CONVERT(DATE,'{0}',121)) U3 ,DATEDIFF( DAY ,'{1}' ,PQX30 ) - PQX19 - PQX18 U2 ,DATEDIFF( DAY ,PQX25 ,'{2}' ) U4 ,PQX32 ,PQX22 ,PQX23 ,CASE WHEN PQX32 = 0 OR PQX32 IS NULL THEN 0 WHEN DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 = 0 THEN 0 WHEN PQX32 != 0 AND PQX32 IS NOT NULL THEN ROUND( PQX32 / ( DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 ) ,0 ) END U7 ,CASE WHEN PQX38='委外' OR PQX38='采购' OR PQX38='承揽' THEN 0 ELSE  (SELECT ISNULL(SUM(GZ25+GZ26),0) GZ FROM R_PQW B WHERE A.PQX01=B.GZ01 AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND DATEPART(MONTH,'{3}')=B.GZ24 AND DATEPART(DAY,'{4}')=B.GZ17) END PQX24,CASE WHEN PQX32 = 0 OR PQX32 IS NULL THEN 0 WHEN DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 = 0 THEN 0 WHEN PQX32 != 0 AND PQX32 IS NOT NULL THEN ROUND( ( DATEDIFF( DAY ,PQX25 ,'{5}' ) ) * ( PQX32 / ( DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 - PQX18 ) ) ,0 ) END U13 ,PQX13 ,PQX14 ,PQX20 ,PQX21,CASE WHEN PQX38='委外' OR PQX38='采购' OR PQX38='承揽' THEN PQX34 ELSE (SELECT ISNULL(SUM(GZ25+GZ26),0) GZ FROM R_PQW B WHERE A.PQX01=B.GZ01 AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND DATEPART(MONTH,'{6}')>=B.GZ24 AND DATEPART(DAY,'{7}')>B.GZ17) END PQX34,ISNULL(U17,0.0) U17,ISNULL(U18,0) U18 FROM R_PQX A" ,dateTi ,dateTi ,dateTi ,dateTi ,dateTi ,dateTi ,dateTi ,dateTi );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " WHERE " + strWhere );
                strSql.Append( " AND PQX14 IS NOT NULL AND PQX14 != ''" );
            }
            strSql.Append( " ORDER BY  REVERSE(PQX14) ,PQX17 ASC ,PQX16 DESC" );
            //SqlParameter[] parameter = {
            //    new SqlParameter("@PQX26",SqlDbType.Date)
            //};

            //parameter[0].Value = dateTi;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ).Rows[0];
        }


        /// <summary>
        /// 获取数据列表  依据单号
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableToOdd ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT PQX28 FROM R_PQX" );
            strSql.Append( " WHERE PQX33=@PQX33" );
            SqlParameter[] parameter = {
                new SqlParameter("@PQX33",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表  com
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetDataTableAll ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT PQX16,PQX17,PQX18,PQX19,PQX22,PQX23 FROM R_PQX" );
            strSql.Append( " WHERE PQX01 IN (" + strWhere + ")" );
            //SqlParameter[] parameter = {
            //    new SqlParameter("@PQX01",SqlDbType.NVarChar)
            //};

            //parameter[0].Value = model.PQX01;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) /*,parameter*/ );
        }

        /// <summary>
        /// 得到数据列表  查询
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT idx,PQX33,PQX01,PQX29,PQX31,PQX32,PQX03,PQX14 FROM R_PQX" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetShenChanCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "SELECT COUNT(1) FROM (SELECT DISTINCT PQX33,PQX01,PQX29,PQX31,PQX32,PQX03 FROM R_PQX WHERE {0} ) A" ,strWhere );

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
        public DataTable GetDataTableByPage ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT PQX33,PQX01,PQX29,PQX31,PQX32,PQX03,PQX30,(SELECT RES05 FROM R_REVIEWS WHERE RES04=(SELECT MAX(RES04) FROM R_REVIEWS WHERE RES06=PQX33)) RES05,PQF13 FROM (" );
            strSql.Append( "SELECT ROW_NUMBER() OVER(" );
            strSql.Append( "ORDER BY T.PQX33 DESC" );
            strSql.Append( ") AS Row,T.* FROM R_PQX T" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " WHERE " + strWhere );
            }
            strSql.Append( ") TT  INNER JOIN R_PQF B ON PQX01=PQF01 " );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}  ORDER BY PQX30 DESC" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取零件名称  从436
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePart ( string strWhere ,string part)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql . AppendFormat ( "SELECT DS03 PQX14,ISNULL(DS29,0) PQX36 FROM R_PQR A INNER JOIN R_PQP B ON A.DS03=B.GS07 WHERE DS01 IN (" + strWhere + ") AND GS02='{0}' GROUP BY DS03,DS29 ORDER BY DS03" ,part );//REVERSE(DS03) 

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) /*,parameter */);
        }
        public DataTable GetDataTablePart ( string strWhere  )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DS03 PQX14,ISNULL(DS29,0) PQX36 FROM R_PQR WHERE DS01 IN (" + strWhere + ") GROUP BY DS03,DS29 ORDER BY DS03"  );//REVERSE(DS03)

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) /*,parameter */);
        }



        public DataTable GetDataTablePartFor509 ( string strWhere ,string part)
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT GZ03 PQX14,ISNULL(CONVERT(DECIMAL(6,0),GS10),0) PQX36 FROM ( SELECT DISTINCT GS07 GZ03,GS10  FROM R_PQP WHERE GS01 IN ({0}) and GS02='{1}' UNION  SELECT DISTINCT GS52 GZ03,GS59 FROM R_PQP WHERE GS01 IN ({0}) and GS52='{1}' ) A WHERE GZ03!='' AND GZ03 IS NOT NULL ORDER BY GZ03" ,strWhere ,part );//REVERSE(GZ03)

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取工艺数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableWorkPro ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT GX02 FROM R_PQAA" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取部件名称
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTableParts ( string strWhere  )
        {
            //string otherWhere = "";
            //switch ( other )
            //{
            //    case "采购":
            //    otherWhere += " AND GS70 IN ('R_338','R_341','R_342','R_519.339','R_343','R_347','R_349.347')";
            //    break;
            //    case "委外":
            //    otherWhere += " AND GS70 IN ('R_342')";
            //    break;
            //    case "厂内":
            //    otherWhere += " AND GS70 IN ('生产')";
            //    break;
            //    case "承揽":
            //    otherWhere += " AND GS70 IN ('生产')";
            //    break;
            //}
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PQX13 FROM (" );
            strSql . Append ( " SELECT DISTINCT GS02 PQX13 FROM R_PQP" );
            strSql . AppendFormat ( " WHERE GS01 IN (" + strWhere + ") "  );
            strSql . Append ( " UNION SELECT DISTINCT GS52 PQX13 FROM R_PQP" );
            strSql . AppendFormat ( " WHERE GS01 IN (" + strWhere + ") "  );
            strSql . Append ( ") A ORDER BY PQX13" );//REVERSE(PQX13)

            //SqlParameter[] parameter = {
            //    new SqlParameter("@PQX01",SqlDbType.NVarChar)
            //};

            //parameter[0].Value = num;

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( )/* ,parameter*/ );
        }

        /// <summary>
        /// 获取工序名称  根据流水号和零件名称
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableWork ( string num ,string partName )
        {
            StringBuilder strSql = new StringBuilder( );
            //strSql.Append( "SELECT GX02 FROM R_PQAA  ORDER BY GX02" );
            strSql . AppendFormat ( "SELECT DISTINCT DS04 GX02 FROM R_PQR WHERE DS01='{0}' AND DS03='{1}' ORDER BY DS04" ,num ,partName );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        public DataTable GetDataTableWork ( string num )
        {
            StringBuilder strSql = new StringBuilder ( );
            //strSql.Append( "SELECT GX02 FROM R_PQAA  ORDER BY GX02" );
            strSql . AppendFormat ( "SELECT DISTINCT GS72 GX02 FROM R_PQP WHERE GS01='{0}' ORDER BY GS72" ,num );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取业务员
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableSalesman ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DBA001,DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002='业务部')  AND (DBA043='F' OR DBA043='' OR DBA043 IS NULL)" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取跟单组长
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableNaman ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DBA001,DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002 IN (SELECT DBA002 FROM TPADBA WHERE DBA005=(SELECT DAA001 FROM TPADAA WHERE DAA002='生产部')) AND (DBA043='F' OR DBA043='' OR DBA043 IS NULL))" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePlan ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DBA001,DBA002 FROM TPADBA WHERE DBA001 IN (SELECT DISTINCT DBB001 FROM R_DBB)  AND (DBA043='F' OR DBA043='' OR DBA043 IS NULL)" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrint ( string num )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT PQX01,PQX29,PQX32,PQX31 FROM R_PQX WHERE PQX01='{0}'" ,num );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 更改隐藏标记
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateHideYes ( MulaolaoLibrary.ShenChanJinDuJiHuaLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQX SET" );
            strSql.Append( " PQX37=@PQX37" );
            //strSql.Append( " WHERE PQX33=@PQX33" );
            SqlParameter[] parameter = {
                new SqlParameter("@PQX37",SqlDbType.NVarChar)
                //new SqlParameter("@PQX33",SqlDbType.NVarChar)
            };

            parameter[0].Value = model.PQX37;
            //parameter[1].Value = model.PQX33;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="numCount"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrice ( string numCount )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT PQX14 FROM R_PQX" );
            strSql.Append( " WHERE PQX36=0 AND PQX01 IN (" + numCount + ")" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="numCount"></param>
        /// <returns></returns>
        public DataTable GetDataTablePri ( string numCount )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT PQX14,GS10 FROM R_PQP,R_PQX" );
            strSql.Append( " WHERE GS01 IN (" + numCount + ") AND GS07=PQX14" );
            strSql.Append( " UNION SELECT DISTINCT PQX14,GS59 FROM R_PQP,R_PQX" );
            strSql.Append( " WHERE GS01 IN (" + numCount + ") AND GS56=PQX14" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 更改每套数量
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdatePrice ( MulaolaoLibrary.ShenChanJinDuJiHuaLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQX SET " );
            strSql.Append( "PQX36=@PQX36" );
            strSql.Append( " WHERE PQX33=@PQX33 AND PQX14=@PQX14" );
            SqlParameter[] parameter = {
                new SqlParameter("@PQX36",SqlDbType.Int),
                new SqlParameter("@PQX33",SqlDbType.NVarChar,20),
                new SqlParameter("@PQX14",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = model.PQX36;
            parameter[1].Value = model.PQX33;
            parameter[2].Value = model.PQX14;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 编辑交货日期  工序计划投产日期+日期差
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool UpdateDate ( string oddNum ,DateTime date ,int dtSpan )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQX SET " );
            strSql . Append ( "PQX30=@PQX30," );
            strSql . AppendFormat ( "PQX25=DATEADD(DAY,{0},PQX25) " ,dtSpan );
            strSql . Append ( " WHERE PQX33=@PQX33" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PQX30",SqlDbType.DateTime),
                new SqlParameter("@PQX33",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = date;
            parameter [ 1 ] . Value = oddNum;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 编辑工序增减道差
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool UpdateNum ( string oddNum ,int num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQX SET " );
            strSql.Append( "PQX18=@PQX18" );
            strSql.Append( " WHERE PQX33=@PQX33" );
            SqlParameter[] parameter = {
                new SqlParameter("@PQX18",SqlDbType.Int),
                new SqlParameter("@PQX33",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = num;
            parameter[1].Value = oddNum;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 编辑部件工序道数
        /// </summary>
        /// <param name="lsNum"></param>
        /// <param name="ljName"></param>
        /// <param name="gx"></param>
        /// <returns></returns>
        public bool UpdateB ( string lsNum ,string ljName ,int gx )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQX SET " );
            strSql . Append ( "PQX19=@PQX19 " );
            strSql . Append ( "WHERE PQX01=@PQX01 AND PQX14=@PQX14 " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PQX01",SqlDbType.NVarChar,20),
                new SqlParameter("@PQX14",SqlDbType.NVarChar,20),
                new SqlParameter("@PQX19",SqlDbType.Int)
            };
            parameter [ 0 ] . Value = lsNum;
            parameter [ 1 ] . Value = ljName;
            parameter [ 2 ] . Value = gx;


            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 批量编辑工艺
        /// </summary>
        /// <param name="ori"></param>
        /// <param name="now"></param>
        /// <returns></returns>
        public bool UpdateBatchWorkPro ( string ori ,string now )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQX SET " );
            strSql.Append( "PQX15=@PQX15" );
            strSql.Append( " WHERE PQX15=@PQX015" );
            SqlParameter[] parameter = {
                new SqlParameter("@PQX15",SqlDbType.NVarChar),
                new SqlParameter("@PQX015",SqlDbType.NVarChar)
            };
            parameter[0].Value = now;
            parameter[1].Value = ori;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 编辑累计部件量=累计部件量+当日生产量（流水，单号，来源，PQX39(当日生产量的日期)）
        /// </summary>
        /// <param name="numCount"></param>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public int EditPQX34 ( string numCount,string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            //strSql . AppendFormat ( "UPDATE R_PQX SET PQX34=ISNULL(PQX34,0)+ISNULL(PQX24,0),PQX24=0 WHERE PQX01 IN ({0}) AND PQX33='{1}' AND PQX38 IN ('采购','承揽','委外') AND CONVERT(VARCHAR,PQX39,112)!=CONVERT(VARCHAR,GETDATE(),112)" ,numCount ,oddNum );
            strSql . AppendFormat ( "UPDATE R_PQX SET PQX24=0 WHERE PQX01 IN ({0}) AND PQX33='{1}' AND CONVERT(VARCHAR,PQX39,112)!=CONVERT(VARCHAR,GETDATE(),112)" ,numCount ,oddNum );//AND PQX38 IN ('采购','承揽','委外') PQX34=ISNULL(PQX34,0)+ISNULL(PQX24,0),

            return SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 当(工序实投产日期)显示≥(工序计划投产日期)时(欠投产天数)栏位开始计数直到(日产部件量)栏位有数值读入时静止计数[(欠投产天数)该栏位的负数值就是该工序的延误投产天数]
        /// </summary>
        /// <param name="num">流水号</param>
        /// <param name="oddNum">单号</param>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public bool EditToOtherColumn ( string num ,string oddNum ,DateTime dt )
        {
            //存储过程:pqxu4
            /*
             EXEC pqxu4
            '17070230',
            'R_046-20170906002',
            '2017/11/22'
             */
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DECLARE @idx INT;" );
            strSql . Append ( "DECLARE @u4 INT;" );
            strSql . Append ( "DECLARE @pqx24 INT;" );
            strSql . Append ( "DECLARE CUR CURSOR FOR " );
            strSql . Append ( "WITH CET AS(" );
            strSql . AppendFormat ( "SELECT A.idx,DATEDIFF(DAY,CONVERT(DATE,'{2}',121),PQX25) U4,PQX24+ISNULL((SELECT ISNULL(GZ25,0)+ISNULL(GZ26,0) GZ FROM R_PQW WHERE idx IN (SELECT MAX(B.idx) ID FROM R_PQW B WHERE B.GZ01 IN ({0}) AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND ISNULL(GZ25,0)+ISNULL(GZ26,0)!=0 GROUP BY GZ03,GZ04)),0) PQX24 FROM R_PQX A WHERE PQX33='{1}' AND PQX14 IS NOT NULL AND PQX14 != '') " ,num ,oddNum ,dt );
            //strSql . Append ( "SELECT idx,CASE WHEN PQX24>0 THEN 0 WHEN U4<0 THEN 0 ELSE U4 END U4 FROM CET " );
            strSql . Append ( "SELECT idx,CASE WHEN U4>0 THEN 0 ELSE U4 END U4,PQX24 FROM CET " );
            strSql . Append ( "OPEN CUR " );
            strSql . Append ( "FETCH NEXT FROM CUR INTO @idx,@u4,@pqx24 " );
            strSql . Append ( "WHILE @@FETCH_STATUS=0 " );
            strSql . Append ( "BEGIN " );
            //strSql . Append ( "IF (@u4>=0 AND @pqx24<0)" );
            strSql . Append ( "IF (@u4<=0 AND @pqx24<=0) " );
            strSql . Append ( "UPDATE R_PQX SET U4=@u4 WHERE idx=@idx " );
            strSql . Append ( "FETCH NEXT FROM CUR INTO @idx,@u4,@pqx24  " );
            strSql . Append ( "END " );
            strSql . Append ( "CLOSE CUR " );
            strSql . Append ( "DEALLOCATE CUR" );

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( rows > 0 )
                return true;
            else
                return false;

            //SqlHelper . StoreProcedure ( "pqxu4" );
            //SqlParameter [ ] parameter = {
            //    new SqlParameter("@numCount",SqlDbType.NVarChar,200),
            //    new SqlParameter("@oddNum",SqlDbType.NVarChar,20),
            //    new SqlParameter("@dateTime",SqlDbType.DateTime)
            //};
            //parameter [ 0 ] . Value = num;
            //parameter [ 1 ] . Value = oddNum;
            //parameter [ 2 ] . Value = dt;

            // SqlHelper . ExecuteNoStore ( parameter );
            //if ( dl != null && dl . Rows . Count > 0 )
            //    return true;
            //else
            //    return false;
        }

        /// <summary>
        /// (工序实投产日期)显示>(工序计划投产日期)或(日产部件量)栏位大于0时(工序实产周期)栏位开始计数直到(还要生产部件)栏位值0≦时(工序实产周期)栏位静止计数[(工序实产周期)该栏位的负数值就是该工序的延迟交期天数]
        /// </summary>
        /// <param name="num">流水号</param>
        /// <param name="oddNum">单号</param>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>        
        public bool EditToOtherColumnForU2 ( string num ,string oddNum ,DateTime dt)
        {
            //存储过程:U2
            /*
             EXEC pqxu2
            '17070230',
            'R_046-20170906002',
            '2017/11/22'
             */
            StringBuilder strSql = new StringBuilder ( );
            //strSql . AppendFormat ( "UPDATE R_PQX SET U2=0 WHERE PQX33='{0}' " ,oddNum );
            strSql . Append ( "DECLARE @idx INT; " );
            strSql . Append ( "DECLARE @u2 INT;" );
            strSql . Append ( "DECLARE @pqx24 INT;" );
            strSql . Append ( "DECLARE @u4 INT;" );
            strSql . Append ( "DECLARE @pqx34 INT;" );
            strSql . Append ( "DECLARE CUR CURSOR FOR " );
            strSql . Append ( "WITH CET AS( " );
            //strSql . AppendFormat ( "SELECT A.idx,PQX32,PQX36,DATEDIFF(DAY,PQX25,CONVERT(DATE,'{2}',121)) U4,CASE WHEN PQX38='委外' OR PQX38='采购' OR PQX38='承揽' THEN 0 ELSE  ISNULL((SELECT ISNULL(GZ25,0)+ISNULL(GZ26,0) GZ FROM R_PQW WHERE idx IN (SELECT MAX(B.idx) ID FROM R_PQW B WHERE B.GZ01 IN ({0}) AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND ISNULL(GZ25,0)+ISNULL(GZ26,0)!=0 GROUP BY GZ03,GZ04)),0) END PQX24,DATEDIFF( DAY ,CONVERT(DATE,'{2}',121) ,PQX30 )-PQX19 + PQX16 - PQX18 U2,CASE WHEN PQX38='委外' OR PQX38='采购' OR PQX38='承揽' THEN PQX32*PQX36-PQX34 ELSE PQX32*PQX36-(SELECT ISNULL(SUM(GZ25+GZ26),0) GZ FROM R_PQW B WHERE B.GZ01 IN ({0}) AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND CONVERT(DATE,'{2}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17))) END PQX34 FROM R_PQX A WHERE PQX33='{1}' AND PQX14 IS NOT NULL AND PQX14 != '' )  " ,num ,oddNum ,dt );
            strSql . AppendFormat ( "SELECT A.idx,PQX32,PQX36,DATEDIFF(DAY,PQX25,CONVERT(DATE,'{2}',121)) U4,ISNULL((SELECT ISNULL(GZ25,0)+ISNULL(GZ26,0) GZ FROM R_PQW WHERE idx IN (SELECT MAX(B.idx) ID FROM R_PQW B WHERE B.GZ01 IN ({0}) AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND ISNULL(GZ25,0)+ISNULL(GZ26,0)!=0 GROUP BY GZ03,GZ04)),0)+PQX24 PQX24,DATEDIFF( DAY ,CONVERT(DATE,'{2}',121) ,PQX30 )-PQX19 + PQX16 - PQX18 U2,PQX32*PQX36-(SELECT ISNULL(SUM(GZ25+GZ26),0) GZ FROM R_PQW B WHERE B.GZ01 IN ({0}) AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND CONVERT(DATE,'{2}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)))-PQX34 PQX34 FROM R_PQX A WHERE PQX33='{1}' AND PQX14 IS NOT NULL AND PQX14 != '' )  " ,num ,oddNum ,dt );
            strSql . Append ( "SELECT idx,U2,U4,PQX24,PQX34 FROM CET WHERE PQX34>0 " );//WHERE (PQX24>=0 OR U4<=0) AND PQX32*PQX36-PQX34>=0
            strSql . Append ( "OPEN CUR " );
            strSql . Append ( "FETCH NEXT FROM CUR INTO @idx,@u2,@u4,@pqx24,@pqx34 " );
            strSql . Append ( "WHILE @@FETCH_STATUS=0 " );
            strSql . Append ( "BEGIN " );
            //2018-7-17 18050150流水  检验工序
            strSql . Append ( "IF((@u4>0 OR @pqx24>0) AND @pqx34>0) " );
            //strSql . Append ( "IF(@u4>=0 OR @pqx24>0) " );
            //2018-7-17 18050150流水  检验工序
            //strSql . Append ( "IF @u4>=0 " );
            strSql . Append ( "UPDATE R_PQX SET U2=@u2 WHERE idx=@idx " );
            strSql . Append ( "FETCH NEXT FROM CUR INTO @idx,@u2,@u4,@pqx24,@pqx34 " );
            strSql . Append ( "END " );
            strSql . Append ( "CLOSE CUR " );
            strSql . Append ( "DEALLOCATE CUR " );

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( rows > 0 )
                return true;
            else
                return false;


            //SqlHelper . StoreProcedure ( "pqxu2" );
            //SqlParameter [ ] parameter = {
            //    new SqlParameter("@numCount",num),
            //    new SqlParameter("@oddNum",oddNum),
            //    new SqlParameter("@dateTime",dt)
            //};

            //DataTable dl = SqlHelper . ExecuteDataTableStore ( parameter );
            //if ( dl != null && dl . Rows . Count > 0 )
            //    return true;
            //else
            //    return false;
        }
        
        /// <summary>
        /// (累欠产量)=(当日欠产量)+前面的累欠产量    注:和(累计已生产量)计算方法相同 
        /// </summary>
        /// <param name="num">流水号</param>
        /// <param name="oddNum">单号</param>
        /// <param name="strWhere">条件</param>
        /// <param name="dt">日期</param>
        /// <returns></returns>
        public bool EditToOtherColumnForU14 ( string num ,string oddNum ,DateTime dt )
        {
            //存储过程:pqxu14
            /*
             EXEC pqxu14
            '17070230',
            'R_046-20170906002',
            '2017/11/22'
             */
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE R_PQX SET U14=0 WHERE PQX33='{0}'" ,oddNum );
            strSql . Append ( "DECLARE @u14 INT;DECLARE @idx INT;DECLARE CUR CURSOR FOR " );
            strSql . Append ( "WITH CET AS (" );
            strSql . AppendFormat ( "SELECT PQX24+ISNULL((SELECT SUM(ISNULL(GZ25,0)+ISNULL(GZ26,0)) GZ FROM R_PQW WHERE idx IN (SELECT B.idx FROM R_PQW B WHERE B.GZ01 IN ({0}) AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND ISNULL(GZ25,0)+ISNULL(GZ26,0)!=0 AND CONVERT(DATE,CONVERT(VARCHAR,GZ35)+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17),102)<='{1}') ),0) PQX24,PQX32,(SELECT ISNULL(SUM(GZ25+GZ26),0) GZ FROM R_PQW B WHERE B.GZ01 IN ({0}) AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND CONVERT(DATE,GETDATE(),23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)))+PQX34 PQX34,PQX36,U2,A.idx FROM R_PQX A WHERE 1=1 AND PQX33='{2}' AND PQX14 IS NOT NULL AND PQX14 != '') " ,num ,dt ,oddNum );
            strSql . Append ( "SELECT SUM(CASE WHEN U2=0 THEN PQX24 WHEN PQX32*PQX36-PQX34<=0 THEN PQX24 ELSE PQX24-(PQX32*PQX36-PQX34)/U2 END) U,idx FROM CET GROUP BY idx " );
            strSql . Append ( "OPEN CUR " );
            strSql . Append ( "FETCH NEXT FROM CUR INTO @u14,@idx " );
            strSql . Append ( "WHILE @@FETCH_STATUS=0 " );
            strSql . Append ( "BEGIN " );
            strSql . Append ( "IF (@u14<=0)" );
            strSql . Append ( "UPDATE R_PQX SET U14=@u14 WHERE idx=@idx " );
            strSql . Append ( "FETCH NEXT FROM CUR INTO @u14,@idx " );
            strSql . Append ( "END " );
            strSql . Append ( "CLOSE CUR " );
            strSql . Append ( "DEALLOCATE CUR " );

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( rows > 0 )
                return true;
            else
                return false;

            //SqlHelper . StoreProcedure ( "pqxu14" );
            //SqlParameter [ ] parameter = {
            //    new SqlParameter("@numCount",num),
            //    new SqlParameter("@oddNum",oddNum),
            //    new SqlParameter("@dateTime",dt)
            //};

            //DataTable dl = SqlHelper . ExecuteDataTableStore ( parameter );
            //if ( dl != null && dl . Rows . Count > 0 )
            //    return true;
            //else
            //    return false;

        }

        /// <summary>
        /// (工序积压亏损数量)=(累已产部件量)下道工序(栏位)减上道工序(栏位)
        /// </summary>
        /// <param name="num">流水号</param>
        /// <param name="oddNum">单号</param>
        /// <returns></returns>
        public bool EditToOtherColounForU12 ( string num ,string oddNum )
        {
            //存储过程:pqxu12
            /*
             EXEC pqxu12
            '17070230',
            'R_046-20170906002'
             */

            //SqlHelper . StoreProcedure ( "pqxu12" );
            //SqlParameter [ ] parameter = {
            //    new SqlParameter("@numCount",num),
            //    new SqlParameter("@oddNum",oddNum)
            //};

            //DataTable dl = SqlHelper . ExecuteDataTableStore ( parameter );
            //if ( dl != null && dl . Rows . Count > 0 )
            //    return true;
            //else
            //    return false;

            StringBuilder strSql = new StringBuilder ( );
            //strSql . AppendFormat ( "UPDATE R_PQX SET U12=0 WHERE PQX33='{0}' " ,oddNum );
            //strSql . Append ( "DECLARE @idx INT;DECLARE @u12 INT;DECLARE @pqx17 NVARCHAR(20); " );
            //strSql . Append ( "DECLARE CUS CURSOR FOR " );
            //strSql . AppendFormat ( "SELECT DISTINCT PQX17 FROM R_PQX WHERE PQX33='{0}' AND PQX14 IS NOT NULL AND PQX14 != '' " ,oddNum );
            //strSql . Append ( "OPEN CUS " );
            //strSql . Append ( "FETCH NEXT FROM CUS INTO @pqx17 " );
            //strSql . Append ( "WHILE @@FETCH_STATUS=0 " );
            //strSql . Append ( "BEGIN " );
            //strSql . Append ( "DECLARE CUR CURSOR FOR " );
            //strSql . AppendFormat ( "WITH CET AS(SELECT idx,PQX13,PQX16,PQX17,(SELECT ISNULL(SUM(GZ25+GZ26),0) GZ FROM R_PQW B WHERE B.GZ01 IN ({0}) AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND CONVERT(DATE,GETDATE(),23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)) ) PQX34 FROM R_PQX A WHERE PQX33='{1}' AND PQX14 IS NOT NULL AND PQX14 != '') " ,num ,oddNum );
            //strSql . Append ( "SELECT idx,PQX34-ISNULL((SELECT TOP 1 PQX34 FROM CET T2 WHERE T2.PQX16<T1.PQX16 AND PQX17=@pqx17 ORDER BY PQX16 DESC ),0) U12 FROM CET T1 WHERE PQX17=@pqx17 " );
            //strSql . Append ( "OPEN CUR " );
            //strSql . Append ( "FETCH NEXT FROM CUR INTO @idx,@u12 " );
            //strSql . Append ( "WHILE @@FETCH_STATUS=0 " );
            //strSql . Append ( "BEGIN " );
            //strSql . Append ( "IF(@u12<0) " );
            //strSql . Append ( "UPDATE R_PQX SET U12=@u12 WHERE idx=@idx " );
            //strSql . Append ( "FETCH NEXT FROM CUR INTO @idx,@u12 " );
            //strSql . Append ( "END " );
            //strSql . Append ( "CLOSE CUR " );
            //strSql . Append ( "DEALLOCATE CUR " );
            //strSql . Append ( "FETCH NEXT FROM CUS INTO @pqx17 " );
            //strSql . Append ( "END " );
            //strSql . Append ( "CLOSE CUS " );
            //strSql . Append ( "DEALLOCATE CUS " );


            strSql . AppendFormat ( "UPDATE R_PQX SET U12=0 WHERE PQX33='{0}' " ,oddNum );
            strSql . Append ( "DECLARE @idx INT;DECLARE @u12 INT;DECLARE @pqx16 NVARCHAR(20);DECLARE @pqx17 NVARCHAR(20); " );
            strSql . Append ( "DECLARE CUS CURSOR FOR " );
            strSql . AppendFormat ( "SELECT DISTINCT PQX17 FROM R_PQX WHERE PQX33='{0}' AND PQX14 IS NOT NULL AND PQX14 != '' " ,oddNum );
            strSql . Append ( "OPEN CUS " );
            strSql . Append ( "FETCH NEXT FROM CUS INTO @pqx17 " );
            strSql . Append ( "WHILE @@FETCH_STATUS=0 " );
            strSql . Append ( "BEGIN " );
            strSql . Append ( "DECLARE CUR CURSOR FOR " );
            strSql . AppendFormat ( "WITH CET AS(SELECT idx,PQX13,PQX16,PQX17,(SELECT ISNULL(SUM(GZ25+GZ26),0) GZ FROM R_PQW B WHERE B.GZ01 IN ({0}) AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND CONVERT(DATE,GETDATE(),23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)) )+PQX34 PQX34 FROM R_PQX A WHERE PQX33='{1}' AND PQX14 IS NOT NULL AND PQX14 != '' and PQX17=@pqx17) " ,num ,oddNum );
            strSql . Append ( "SELECT idx,PQX16,PQX17,PQX34-ISNULL((SELECT TOP 1 PQX34 FROM CET T2 WHERE T2.PQX16>T1.PQX16 AND PQX17=@pqx17 ORDER BY PQX16 ASC ),0) U12 FROM CET T1 WHERE PQX17=@pqx17 ORDER BY PQX16 " );
            strSql . Append ( "OPEN CUR " );
            strSql . Append ( "FETCH NEXT FROM CUR INTO @idx,@pqx16,@pqx17,@u12 " );
            strSql . Append ( "WHILE @@FETCH_STATUS=0 " );
            strSql . Append ( "BEGIN " );
            //strSql . Append ( "IF(@u12<0) " );
            strSql . AppendFormat ( "UPDATE R_PQX SET U12=@u12 WHERE PQX16=(SELECT MIN(PQX16) PQX16 FROM R_PQX WHERE PQX33='{0}' AND PQX17=@pqx17 AND PQX16>@pqx16) AND PQX33='{0}' AND PQX17=@pqx17  " ,oddNum );
            strSql . Append ( "FETCH NEXT FROM CUR INTO @idx,@pqx16,@pqx17,@u12 " );
            strSql . Append ( "END " );
            strSql . Append ( "CLOSE CUR " );
            strSql . Append ( "DEALLOCATE CUR " );
            strSql . Append ( "FETCH NEXT FROM CUS INTO @pqx17 " );
            strSql . Append ( "END " );
            strSql . Append ( "CLOSE CUS " );
            strSql . Append ( "DEALLOCATE CUS " );

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// (日产部件量差)改(R317读入次数)=从R317每读入1次就累加1次
        /// </summary>
        /// <param name="num">流水号</param>
        /// <param name="oddNum">单号</param>
        /// <param name="dt">日期</param>
        /// <returns></returns>
        public bool EditToOtherColumnForU29 ( string num ,string oddNum ,DateTime dt )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE R_PQX SET U29=0 WHERE PQX33='{0}' " ,oddNum );
            strSql . Append ( "DECLARE @idx INT;DECLARE @coun INT; DECLARE CUR CURSOR FOR " );
            strSql . Append ( "WITH CET AS ( " );
            strSql . AppendFormat ( "SELECT GZ03,GZ04,CONVERT(VARCHAR,GZ35)+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17) GZ FROM R_PQW WHERE GZ01 IN ({0}) AND CONVERT(DATE,'{1}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)) GROUP BY GZ03,GZ04,GZ35,GZ24,GZ17) " ,num ,dt );
            strSql . AppendFormat ( "SELECT A.idx,COUNT(B.GZ) COUN FROM R_PQX A INNER JOIN CET B ON A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 WHERE PQX33='{0}' AND PQX14 IS NOT NULL AND PQX14 != '' GROUP BY A.idx " ,oddNum );
            strSql . Append ( "OPEN CUR " );
            strSql . Append ( "FETCH NEXT FROM CUR INTO @idx,@coun " );
            strSql . Append ( "WHILE @@FETCH_STATUS=0 " );
            strSql . Append ( "BEGIN " );
            strSql . Append ( "UPDATE R_PQX SET U29=@coun WHERE idx=@idx " );
            strSql . Append ( "FETCH NEXT FROM CUR INTO @idx,@coun " );
            strSql . Append ( "END " );
            strSql . Append ( "CLOSE CUR " );
            strSql . Append ( "DEALLOCATE CUR " );

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( rows > 0 )
                return true;
            else
                return false;

        }

        /// <summary>
        /// 调整日产部件  工序实产周期大于等于1时计算，否则不变，  还要生产部件等于零时为零
        /// </summary>
        /// <param name="num"></param>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool EditToOtherColumnForU9 ( string num ,string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DECLARE @idx INT;" );
            strSql . Append ( "DECLARE @U2 INT;" );
            strSql . Append ( "DECLARE @U9 INT;" );
            strSql . Append ( "DECLARE CUR CURSOR FOR " );
            strSql . AppendFormat ( "WITH CET AS(SELECT A.idx,PQX32,PQX36,PQX34+(SELECT ISNULL(SUM(GZ25+GZ26),0) GZ FROM R_PQW B WHERE B.GZ01 IN ({0}) AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND CONVERT(DATE,GETDATE(),23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17))) PQX34,U2 FROM R_PQX A WHERE PQX33='{1}') " ,num ,oddNum );
            strSql . Append ( "SELECT idx,CASE WHEN PQX32*PQX36-PQX34=0 THEN 0 WHEN U2=0 THEN 0 ELSE CONVERT(DECIMAL(18,0),(PQX32*PQX36-PQX34)/U2) END U9,U2 FROM CET WHERE U2>=1 " );
            strSql . Append ( "OPEN CUR " );
            strSql . Append ( "FETCH NEXT FROM CUR INTO @idx,@U9,@U2 " );
            strSql . Append ( "WHILE @@FETCH_STATUS=0 " );
            strSql . Append ( "BEGIN " );
            strSql . Append ( "UPDATE R_PQX SET U9=@U9 WHERE idx=@idx " );
            strSql . Append ( "FETCH NEXT FROM CUR INTO @idx,@U9,@U2 " );
            strSql . Append ( "END " );
            strSql . Append ( "CLOSE CUR " );
            strSql . Append ( "DEALLOCATE CUR " );
            strSql . Append ( "UPDATE R_PQX SET U9=0 WHERE ISNULL(U9,0)<0" );

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取累计生产量
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="num">日产部件量</param>
        /// <param name="name">加法还是减法</param>
        /// <returns></returns>
        public int EditAll ( string idx ,int num ,string name )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE R_PQX SET PQX24=PQX24{0}{1},PQX39=GETDATE(),PQX34=PQX34{0}{1} WHERE idx={2}" ,name ,num ,idx );

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( rows > 0 )
            {
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "SELECT PQX24 FROM R_PQX WHERE idx={0}" ,idx );

                DataTable table = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
                if ( table != null && table . Rows . Count > 0 )
                    return string . IsNullOrEmpty ( table . Rows [ 0 ] [ "PQX24" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ 0 ] [ "PQX24" ] . ToString ( ) );
                else
                    return 0;
            }
            else
                return -1;
        }

        /// <summary>
        /// 编辑预计生产日期
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EditWork ( List<DataRow> rows ,MulaolaoLibrary . ShenChanJinDuJiHuaLibrary model )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            foreach ( DataRow row in rows )
            {
                model . PQX38 = row [ "PQX38" ] . ToString ( );
                model . PQX13 = row [ "PQX13" ] . ToString ( );
                model . PQX14 = row [ "PQX14" ] . ToString ( );
                model . PQX15 = row [ "PQX15" ] . ToString ( );
                model . PQX17 = row [ "PQX17" ] . ToString ( );
                model . PQX25 = Convert . ToDateTime ( row [ "PQX25" ] );
                strSql = new StringBuilder ( );
                strSql . Append ( "UPDATE R_PQX SET PQX25=@PQX25 " );
                strSql . Append ( "WHERE PQX33=@PQX33 AND PQX01=@PQX01 AND PQX38=@PQX38 AND PQX13=@PQX13 AND PQX14=@PQX14 AND PQX17=@PQX17 AND PQX15=@PQX15" );
                SqlParameter [ ] parameter = {
                    new SqlParameter("@PQX33",SqlDbType.NVarChar),
                    new SqlParameter("@PQX01",SqlDbType.NVarChar),
                    new SqlParameter("@PQX38",SqlDbType.NVarChar),
                    new SqlParameter("@PQX13",SqlDbType.NVarChar),
                    new SqlParameter("@PQX14",SqlDbType.NVarChar),
                    new SqlParameter("@PQX17",SqlDbType.NVarChar),
                    new SqlParameter("@PQX15",SqlDbType.NVarChar),
                    new SqlParameter("@PQX25",SqlDbType.Date)
                };
                parameter [ 0 ] . Value = model . PQX33;
                parameter [ 1 ] . Value = model . PQX01;
                parameter [ 2 ] . Value = model . PQX38;
                parameter [ 3 ] . Value = model . PQX13;
                parameter [ 4 ] . Value = model . PQX14;
                parameter [ 5 ] . Value = model . PQX17;
                parameter [ 6 ] . Value = model . PQX15;
                parameter [ 7 ] . Value = model . PQX25;
                SQLString . Add ( strSql ,parameter );
            }
            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

    }
}

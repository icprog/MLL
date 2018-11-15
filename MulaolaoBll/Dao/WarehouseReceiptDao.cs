using System . Data;
using System . Text;
using StudentMgr;
using System;
using System . Data . SqlClient;
using System . Collections;

namespace MulaolaoBll . Dao
{
    public class WarehouseReceiptDao
    {
        /// <summary>
        /// 获取入库单数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableS ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT A.idx,WAR001,WAR002,WAR003,WAR004,WAR005,WAR006,WAR007,WAR008,WAR009,WAR010,WAR011,WAR012,WAR006-SUM(WAS006) U7,CONVERT(DECIMAL(18,2),WAR006*WAR009) U6,CONVERT(DECIMAL(18,2),WAR006*WAR009-SUM(WAS006*WAS008)) U8 FROM R_PQWAR A LEFT JOIN R_PQWAS B ON A.idx=B.WAS012  " );
            strSql . Append ( "WHERE " + strWhere );
            strSql . Append ( " GROUP BY A.idx,WAR001,WAR002,WAR003,WAR004,WAR005,WAR006,WAR007,WAR008,WAR009,WAR010,WAR011,WAR012" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ); 
        }

        /// <summary>
        /// 获取入库单数据集
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary . WarehouseReceiptWAREntity GetDataTableS ( int idx )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,WAR001,WAR002,WAR003,WAR004,WAR005,WAR006,WAR007,WAR008,WAR009,WAR010,WAR011,WAR012 FROM R_PQWAR " );
            strSql . AppendFormat ( "WHERE idx={0}" ,idx );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
                return getModelS ( dt . Rows [ 0 ] );
            else
                return null;
        }

        public MulaolaoLibrary . WarehouseReceiptWAREntity getModelS ( DataRow row )
        {
            MulaolaoLibrary . WarehouseReceiptWAREntity model = new MulaolaoLibrary . WarehouseReceiptWAREntity ( );

            if ( row != null )
            {
                if ( row [ "idx" ] != null && row [ "idx" ] . ToString ( ) != "" )
                    model . idx = int . Parse ( row [ "idx" ] . ToString ( ) );
                if ( row [ "WAR001" ] != null && row [ "WAR001" ] . ToString ( ) != "" )
                    model . WAR001 = row [ "WAR001" ] . ToString ( );
                if ( row [ "WAR002" ] != null && row [ "WAR002" ] . ToString ( ) != "" )
                    model . WAR002 = DateTime . Parse ( row [ "WAR002" ] . ToString ( ) );
                if ( row [ "WAR003" ] != null && row [ "WAR003" ] . ToString ( ) != "" )
                    model . WAR003 = row [ "WAR003" ] . ToString ( );
                if ( row [ "WAR004" ] != null && row [ "WAR004" ] . ToString ( ) != "" )
                    model . WAR004 = row [ "WAR004" ] . ToString ( );
                if ( row [ "WAR005" ] != null && row [ "WAR005" ] . ToString ( ) != "" )
                    model . WAR005 = row [ "WAR005" ] . ToString ( );
                if ( row [ "WAR006" ] != null && row [ "WAR006" ] . ToString ( ) != "" )
                    model . WAR006 = decimal . Parse ( row [ "WAR006" ] . ToString ( ) );
                if ( row [ "WAR007" ] != null && row [ "WAR007" ] . ToString ( ) != "" )
                    model . WAR007 = row [ "WAR007" ] . ToString ( );
                if ( row [ "WAR008" ] != null && row [ "WAR008" ] . ToString ( ) != "" )
                    model . WAR008 = decimal . Parse ( row [ "WAR008" ] . ToString ( ) );
                if ( row [ "WAR009" ] != null && row [ "WAR009" ] . ToString ( ) != "" )
                    model . WAR009 = decimal . Parse ( row [ "WAR009" ] . ToString ( ) );
                if ( row [ "WAR010" ] != null && row [ "WAR010" ] . ToString ( ) != "" )
                    model . WAR010 = row [ "WAR010" ] . ToString ( );
                if ( row [ "WAR011" ] != null && row [ "WAR011" ] . ToString ( ) != "" )
                    model . WAR011 = row [ "WAR011" ] . ToString ( );
                if ( row [ "WAR012" ] != null && row [ "WAR012" ] . ToString ( ) != "" )
                    model . WAR012 = row [ "WAR012" ] . ToString ( );
            }

            return model;
        }

        /// <summary>
        /// 是否存在出库记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Exists ( int idx )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM R_PQWAR A INNER JOIN R_PQWAS B ON A.idx=B.WAS012 " );
            strSql . AppendFormat ( "WHERE A.idx={0}" ,idx );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool DeleteS ( int idx )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQWAR " );
            strSql . AppendFormat ( "WHERE idx={0}" ,idx );

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 增加入库单记录
        /// </summary>
        /// <param name="_war"></param>
        /// <returns></returns>
        public bool AddS ( MulaolaoLibrary . WarehouseReceiptWAREntity _war )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQWAR (" );
            strSql . Append ( "WAR001,WAR002,WAR003,WAR004,WAR005,WAR006,WAR007,WAR008,WAR009,WAR010,WAR011,WAR012) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@WAR001,@WAR002,@WAR003,@WAR004,@WAR005,@WAR006,@WAR007,@WAR008,@WAR009,@WAR010,@WAR011,@WAR012) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@WAR001",SqlDbType.NVarChar,20),
                new SqlParameter("@WAR002",SqlDbType.Date),
                new SqlParameter("@WAR003",SqlDbType.NVarChar,20),
                new SqlParameter("@WAR004",SqlDbType.NVarChar,20),
                new SqlParameter("@WAR005",SqlDbType.NVarChar,20),
                new SqlParameter("@WAR006",SqlDbType.Decimal,8),
                new SqlParameter("@WAR007",SqlDbType.NVarChar,20),
                new SqlParameter("@WAR008",SqlDbType.Decimal,11),
                new SqlParameter("@WAR009",SqlDbType.Decimal,11),
                new SqlParameter("@WAR010",SqlDbType.NVarChar,20),
                new SqlParameter("@WAR011",SqlDbType.NVarChar,20),
                new SqlParameter("@WAR012",SqlDbType.NVarChar,50)
            };
            parameter [ 0 ] . Value = _war . WAR001;
            parameter [ 1 ] . Value = _war . WAR002;
            parameter [ 2 ] . Value = _war . WAR003;
            parameter [ 3 ] . Value = _war . WAR004;
            parameter [ 4 ] . Value = _war . WAR005;
            parameter [ 5 ] . Value = _war . WAR006;
            parameter [ 6 ] . Value = _war . WAR007;
            parameter [ 7 ] . Value = _war . WAR008;
            parameter [ 8 ] . Value = _war . WAR009;
            parameter [ 9 ] . Value = _war . WAR010;
            parameter [ 10 ] . Value = _war . WAR011;
            parameter [ 11 ] . Value = _war . WAR012;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 编辑入库单记录
        /// </summary>
        /// <param name="_war"></param>
        /// <returns></returns>
        public bool EditS ( MulaolaoLibrary . WarehouseReceiptWAREntity _war )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQWAR SET " );
            strSql . Append ( "WAR001=@WAR001," );
            strSql . Append ( "WAR002=@WAR002," );
            strSql . Append ( "WAR003=@WAR003," );
            strSql . Append ( "WAR004=@WAR004," );
            strSql . Append ( "WAR005=@WAR005," );
            strSql . Append ( "WAR006=@WAR006," );
            strSql . Append ( "WAR007=@WAR007," );
            strSql . Append ( "WAR008=@WAR008," );
            strSql . Append ( "WAR009=@WAR009," );
            strSql . Append ( "WAR010=@WAR010," );
            strSql . Append ( "WAR011=@WAR011," );
            strSql . Append ( "WAR012=@WAR012 " );
            strSql . Append ( "WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@WAR001",SqlDbType.NVarChar,20),
                new SqlParameter("@WAR002",SqlDbType.Date),
                new SqlParameter("@WAR003",SqlDbType.NVarChar,20),
                new SqlParameter("@WAR004",SqlDbType.NVarChar,20),
                new SqlParameter("@WAR005",SqlDbType.NVarChar,20),
                new SqlParameter("@WAR006",SqlDbType.Decimal,8),
                new SqlParameter("@WAR007",SqlDbType.NVarChar,20),
                new SqlParameter("@WAR008",SqlDbType.Decimal,11),
                new SqlParameter("@WAR009",SqlDbType.Decimal,11),
                new SqlParameter("@WAR010",SqlDbType.NVarChar,20),
                new SqlParameter("@WAR011",SqlDbType.NVarChar,20),
                new SqlParameter("@WAR012",SqlDbType.NVarChar,50),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter [ 0 ] . Value = _war . WAR001;
            parameter [ 1 ] . Value = _war . WAR002;
            parameter [ 2 ] . Value = _war . WAR003;
            parameter [ 3 ] . Value = _war . WAR004;
            parameter [ 4 ] . Value = _war . WAR005;
            parameter [ 5 ] . Value = _war . WAR006;
            parameter [ 6 ] . Value = _war . WAR007;
            parameter [ 7 ] . Value = _war . WAR008;
            parameter [ 8 ] . Value = _war . WAR009;
            parameter [ 9 ] . Value = _war . WAR010;
            parameter [ 10 ] . Value = _war . WAR011;
            parameter [ 11 ] . Value = _war . WAR012;
            parameter [ 12 ] . Value = _war . idx;

            SQLString . Add ( strSql ,parameter );

            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQWAS SET " );
            strSql . Append ( "WAS001=@WAS001," );
            strSql . Append ( "WAS004=@WAS004," );
            strSql . Append ( "WAS005=@WAS005 " );
            strSql . Append ( "WHERE WAS012=@WAS012" );
            SqlParameter [ ] para = {
                new SqlParameter("@WAS001",SqlDbType.NVarChar,20),
                new SqlParameter("@WAS004",SqlDbType.NVarChar,20),
                new SqlParameter("@WAS005",SqlDbType.NVarChar,20),
                new SqlParameter("@WAS012",SqlDbType.Int,4)
            };
            para [ 0 ] . Value = _war . WAR001;
            para [ 1 ] . Value = _war . WAR004;
            para [ 2 ] . Value = _war . WAR005;
            para [ 3 ] . Value = _war . idx;

            SQLString . Add ( strSql ,para );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 获取原单价
        /// </summary>
        /// <param name="types"></param>
        /// <param name="name"></param>
        /// <param name="spece"></param>
        /// <returns></returns>
        public decimal priceS ( string types ,string name ,string spece )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT WAR008 FROM R_PQWAR WHERE idx IN (SELECT MAX(idx) FROM R_PQWAR WHERE WAR001=@WAR001 AND WAR004=@WAR004 AND WAR005=@WAR005) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@WAR001",SqlDbType.NVarChar,20),
                new SqlParameter("@WAR004",SqlDbType.NVarChar,20),
                new SqlParameter("@WAR005",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = types;
            parameter [ 1 ] . Value = types;
            parameter [ 2 ] . Value = types;

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "WAR008" ] . ToString ( ) ) )
                    return 0;
                else
                    return Convert . ToDecimal ( dt . Rows [ 0 ] [ "WAR008" ] . ToString ( ) );
            }
            else
                return 0;
        }


        /// <summary>
        /// 获取出库单数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableL ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT A.idx,WAS001,WAS002,WAR003,WAS004,WAS005,WAS006,WAS007,WAS008,WAS009,WAS010,WAR007,WAR010,WAR011,WAS012,WAS013 FROM R_PQWAS A INNER JOIN R_PQWAR B ON A.WAS012=B.idx  " );
            strSql . Append ( "WHERE " + strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取出库单数据集
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary . WarehouseReceiptWASEntity GetDataTableL ( int idx )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,WAS001,WAS002,WAS003,WAS004,WAS005,WAS006,WAS007,WAS008,WAS009,WAS010,WAS011,WAS012 FROM R_PQWAS " );
            strSql . AppendFormat ( "WHERE idx={0}" ,idx );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
                return getModelL ( dt . Rows [ 0 ] );
            else
                return null;
        }

        public MulaolaoLibrary . WarehouseReceiptWASEntity getModelL ( DataRow row )
        {
            MulaolaoLibrary . WarehouseReceiptWASEntity model = new MulaolaoLibrary . WarehouseReceiptWASEntity ( );

            if ( row != null )
            {
                if ( row [ "idx" ] != null && row [ "idx" ] . ToString ( ) != "" )
                    model . idx = int . Parse ( row [ "idx" ] . ToString ( ) );
                if ( row [ "WAS001" ] != null && row [ "WAS001" ] . ToString ( ) != "" )
                    model . WAS001 = row [ "WAS001" ] . ToString ( );
                if ( row [ "WAS002" ] != null && row [ "WAS002" ] . ToString ( ) != "" )
                    model . WAS002 = DateTime . Parse ( row [ "WAS002" ] . ToString ( ) );
                //if ( row [ "WAS003" ] != null && row [ "WAS003" ] . ToString ( ) != "" )
                //    model . WAS003 = row [ "WAS003" ] . ToString ( );
                if ( row [ "WAS004" ] != null && row [ "WAS004" ] . ToString ( ) != "" )
                    model . WAS004 = row [ "WAS004" ] . ToString ( );
                if ( row [ "WAS005" ] != null && row [ "WAS005" ] . ToString ( ) != "" )
                    model . WAS005 = row [ "WAS005" ] . ToString ( );
                if ( row [ "WAS006" ] != null && row [ "WAS006" ] . ToString ( ) != "" )
                    model . WAS006 = int . Parse ( row [ "WAS006" ] . ToString ( ) );
                if ( row [ "WAS007" ] != null && row [ "WAS007" ] . ToString ( ) != "" )
                    model . WAS007 = decimal . Parse ( row [ "WAS007" ] . ToString ( ) );
                if ( row [ "WAS008" ] != null && row [ "WAS008" ] . ToString ( ) != "" )
                    model . WAS008 = decimal . Parse ( row [ "WAS008" ] . ToString ( ) );
                if ( row [ "WAS009" ] != null && row [ "WAS009" ] . ToString ( ) != "" )
                    model . WAS009 = row [ "WAS009" ] . ToString ( );
                if ( row [ "WAS010" ] != null && row [ "WAS010" ] . ToString ( ) != "" )
                    model . WAS010 = row [ "WAS010" ] . ToString ( );
                if ( row [ "WAS012" ] != null && row [ "WAS012" ] . ToString ( ) != "" )
                    model . WAS012 = int . Parse ( row [ "WAS012" ] . ToString ( ) );
            }

            return model;
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool DeleteL ( int idx )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQWAS " );
            strSql . AppendFormat ( "WHERE idx={0}" ,idx );

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取入库单
        /// </summary>
        /// <param name="types"></param>
        /// <param name="name"></param>
        /// <param name="spece"></param>
        /// <returns></returns>
        public DataTable GetDataTableOther ( string idx )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT WAR003,WAR007,WAR009,WAR010 FROM R_PQWAR " );
            strSql . Append ( "WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter [ 0 ] . Value = idx;

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 增加记录
        /// </summary>
        /// <param name="_was"></param>
        /// <returns></returns>
        public bool AddL ( MulaolaoLibrary . WarehouseReceiptWASEntity _was )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQWAS (" );
            strSql . Append ( "WAS001,WAS002,WAS004,WAS005,WAS006,WAS007,WAS008,WAS009,WAS010,WAS012) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@WAS001,@WAS002,@WAS004,@WAS005,@WAS006,@WAS007,@WAS008,@WAS009,@WAS010,@WAS012) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@WAS001",SqlDbType.NVarChar,20),
                new SqlParameter("@WAS002",SqlDbType.Date),
                new SqlParameter("@WAS004",SqlDbType.NVarChar,20),
                new SqlParameter("@WAS005",SqlDbType.NVarChar,20),
                new SqlParameter("@WAS006",SqlDbType.Decimal,8),
                new SqlParameter("@WAS007",SqlDbType.Decimal,10),
                new SqlParameter("@WAS008",SqlDbType.Decimal,10),
                new SqlParameter("@WAS009",SqlDbType.NVarChar,20),
                new SqlParameter("@WAS010",SqlDbType.NVarChar,50),
                new SqlParameter("@WAS012",SqlDbType.Int)
            };
            parameter [ 0 ] . Value = _was . WAS001;
            parameter [ 1 ] . Value = _was . WAS002;
            parameter [ 2 ] . Value = _was . WAS004;
            parameter [ 3 ] . Value = _was . WAS005;
            parameter [ 4 ] . Value = _was . WAS006;
            parameter [ 5 ] . Value = _was . WAS007;
            parameter [ 6 ] . Value = _was . WAS008;
            parameter [ 7 ] . Value = _was . WAS009;
            parameter [ 8 ] . Value = _was . WAS010;
            parameter [ 9 ] . Value = _was . WAS012;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 编辑记录
        /// </summary>
        /// <param name="_was"></param>
        /// <returns></returns>
        public bool EditL ( MulaolaoLibrary . WarehouseReceiptWASEntity _was )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQWAS SET " );
            strSql . Append ( "WAS001=@WAS001," );
            strSql . Append ( "WAS002=@WAS002," );
            strSql . Append ( "WAS004=@WAS004," );
            strSql . Append ( "WAS005=@WAS005," );
            strSql . Append ( "WAS006=@WAS006," );
            strSql . Append ( "WAS007=@WAS007," );
            strSql . Append ( "WAS008=@WAS008," );
            strSql . Append ( "WAS009=@WAS009," );
            strSql . Append ( "WAS010=@WAS010," );
            strSql . Append ( "WAS012=@WAS012 " );
            strSql . Append ( "WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@WAS001",SqlDbType.NVarChar,20),
                new SqlParameter("@WAS002",SqlDbType.Date),
                new SqlParameter("@WAS004",SqlDbType.NVarChar,20),
                new SqlParameter("@WAS005",SqlDbType.NVarChar,20),
                new SqlParameter("@WAS006",SqlDbType.Decimal,8),
                new SqlParameter("@WAS007",SqlDbType.Decimal,10),
                new SqlParameter("@WAS008",SqlDbType.Decimal,10),
                new SqlParameter("@WAS009",SqlDbType.NVarChar,20),
                new SqlParameter("@WAS010",SqlDbType.NVarChar,50),
                new SqlParameter("@WAS012",SqlDbType.Int),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter [ 0 ] . Value = _was . WAS001;
            parameter [ 1 ] . Value = _was . WAS002;
            parameter [ 2 ] . Value = _was . WAS004;
            parameter [ 3 ] . Value = _was . WAS005;
            parameter [ 4 ] . Value = _was . WAS006;
            parameter [ 5 ] . Value = _was . WAS007;
            parameter [ 6 ] . Value = _was . WAS008;
            parameter [ 7 ] . Value = _was . WAS009;
            parameter [ 8 ] . Value = _was . WAS010;
            parameter [ 9 ] . Value = _was . WAS012;
            parameter [ 10 ] . Value = _was . idx;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取原单价
        /// </summary>
        /// <param name="types"></param>
        /// <param name="name"></param>
        /// <param name="spece"></param>
        /// <returns></returns>
        public decimal price ( string types ,string name ,string spece )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT WAS008 FROM R_PQWAS WHERE idx IN (SELECT MAX(idx) FROM R_PQWAS WHERE WAS001=@WAS001 AND WAS004=@WAS004 AND WAS005=@WAS005) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@WAS001",SqlDbType.NVarChar,20),
                new SqlParameter("@WAS004",SqlDbType.NVarChar,20),
                new SqlParameter("@WAS005",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = types;
            parameter [ 1 ] . Value = name;
            parameter [ 2 ] . Value = spece;

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "WAS008" ] . ToString ( ) ) )
                    return 0;
                else
                    return Convert . ToDecimal ( dt . Rows [ 0 ] [ "WAS008" ] . ToString ( ) );
            }
            else
                return 0;
        }

        /// <summary>
        /// 获取字段值
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( string fileName,string tableName )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT {0} FROM {1} " ,fileName ,tableName );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取人员信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePerson ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT DBA001,DBA002 FROM TPADBA WHERE DBA010!='DS' AND DBA028!=''" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }


        /// <summary>
        /// 获取人员信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableUser ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            //strSql . Append ( "SELECT DISTINCT DBA002 U1 FROM TPADBA WHERE DBA010!='DS' AND DBA028!=''" );
            strSql . Append ( "SELECT DISTINCT WAS013 FROM R_PQWAS" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 入库单获取原单价
        /// </summary>
        /// <param name="types"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public decimal priceOne ( string types ,string name )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT WAR009 FROM R_PQWAR WHERE idx=(SELECT MAX(idx) FROM R_PQWAR WHERE WAR001='{0}' AND WAR004='{1}')" ,types ,name );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "WAR009" ] . ToString ( ) ) )
                    return 0;
                else
                    return Convert . ToDecimal ( dt . Rows [ 0 ] [ "WAR009" ] . ToString ( ) );
            }
            else
                return 0;
        }

        /// <summary>
        /// 出库单获取原单价
        /// </summary>
        /// <param name="types">物料类别</param>
        /// <param name="name">物料名称</param>
        /// <returns></returns>
        public decimal priceTwo ( string types ,string name )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT WAS008 FROM R_PQWAS WHERE idx=(SELECT MAX(idx) FROM R_PQWAS WHERE WAS001='{0}' AND WAS004='{1}')" ,types ,name );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "WAS008" ] . ToString ( ) ) )
                    return 0;
                else
                    return Convert . ToDecimal ( dt . Rows [ 0 ] [ "WAS008" ] . ToString ( ) );
            }
            else
                return 0;
        }

        /// <summary>
        /// 获取出库列表
        /// </summary>
        /// <returns></returns>
        public DataTable getTableView ( string userNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            if ( userNum . Equals ( "MLL-0004" ) )
                strSql . Append ( "SELECT A.idx,WAR001,WAR004,WAR005,WAR006-SUM(ISNULL(WAS006,0)) WAR006,WAR009,WAR006-SUM(ISNULL(WAS006,0)) U0,'' U1,'' U2,'' U3,'301' U4  FROM R_PQWAR A LEFT JOIN R_PQWAS B  ON A.idx=B.WAS012 GROUP BY A.idx,A.WAR001,A.WAR004,A.WAR005,A.WAR006,A.WAR009 HAVING WAR006-SUM(ISNULL(WAS006,0))>0 " );
            else if ( userNum . Equals ( "MLL-0020" ) )
                strSql . Append ( "SELECT A.idx,AC04 WAR001,AC05 WAR004,AC06 WAR005,AC10-SUM(ISNULL(AD12,0)) WAR006,AC09 WAR009,AC10-SUM(ISNULL(AD12,0)) U0,'' U1,'' U2,'' U3,AC18 U4 FROM R_PQAC A LEFT JOIN R_PQAD B ON A.AC18=B.AD01 WHERE AC16 LIKE 'R_337%' AND (AC02!='滚漆' OR AC01 LIKE '%颗粒%') GROUP BY A.idx,AC02,AC04,AC05,AC09,AC10,AC18,AC06 HAVING AC10-SUM(ISNULL(AD12,0))>0" );
            else if ( userNum . Equals ( "MLL-0001" ) )
            {
                strSql . Append ( "SELECT A.idx,WAR001,WAR004,WAR005,WAR006-SUM(ISNULL(WAS006,0)) WAR006,WAR009,WAR006-SUM(ISNULL(WAS006,0)) U0,'' U1,'' U2,'' U3,'301' U4  FROM R_PQWAR A LEFT JOIN R_PQWAS B  ON A.idx=B.WAS012 GROUP BY A.idx,A.WAR001,A.WAR004,A.WAR005,A.WAR006,A.WAR009 HAVING WAR006-SUM(ISNULL(WAS006,0))>0 " );
                strSql . Append ( "UNION ALL " );
                strSql . Append ( "SELECT A.idx,AC04 WAR001,AC05 WAR004,AC06 WAR005,AC10-SUM(ISNULL(AD12,0)) WAR006,AC09 WAR009,AC10-SUM(ISNULL(AD12,0)) U0,'' U1,'' U2,'' U3,AC18 U4 FROM R_PQAC A LEFT JOIN R_PQAD B ON A.AC18=B.AD01 WHERE AC16 LIKE 'R_337%' AND (AC02!='滚漆' OR AC01 LIKE '%颗粒%') GROUP BY A.idx,AC02,AC04,AC05,AC09,AC10,AC18,AC06 HAVING AC10-SUM(ISNULL(AD12,0))>0" );
            }

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取人员信息
        /// </summary>
        /// <returns></returns>
        public DataTable getTableUser ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            //strSql . Append ( "SELECT DAA002 FROM TPADAA WHERE LEN(DAA001)=2" );
            strSql . Append ( "SELECT DISTINCT WAS009 FROM R_PQWAS" );


            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 入库
        /// </summary>
        /// <param name="table"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool Library ( DataTable table,DateTime dt)
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            string nameOf = string . Empty;

            MulaolaoLibrary . WarehouseReceiptWASEntity _was = new MulaolaoLibrary . WarehouseReceiptWASEntity ( );
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _was . WAS001 = table . Rows [ i ] [ "WAR001" ] . ToString ( );
                _was . WAS002 = dt;
                _was . WAS004 = table . Rows [ i ] [ "WAR004" ] . ToString ( );
                _was . WAS005 = table . Rows [ i ] [ "WAR005" ] . ToString ( );
                _was . WAS006 = string . IsNullOrEmpty ( table . Rows [ i ] [ "U0" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "U0" ] . ToString ( ) );
                _was . WAS007 = priceTwo ( _was . WAS001 ,_was . WAS004 );
                _was . WAS008 = string . IsNullOrEmpty ( table . Rows [ i ] [ "WAR009" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "WAR009" ] . ToString ( ) );
                _was . WAS009 = table . Rows [ i ] [ "U1" ] . ToString ( );
                _was . WAS010 = table . Rows [ i ] [ "U2" ] . ToString ( );
                _was . WAS012 = string . IsNullOrEmpty ( table . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "idx" ] . ToString ( ) );
                _was . WAS013 = table . Rows [ i ] [ "U3" ] . ToString ( );
                nameOf = table . Rows [ i ] [ "U4" ] . ToString ( );

                if ( _was . WAS006 > 0 && !string.IsNullOrEmpty( _was . WAS009 ) )
                {
                    strSql = new StringBuilder ( );
                    SqlParameter [ ] parameter = null;
                    if ( nameOf . Equals ( "301" ) )
                    {
                        strSql . Append ( "INSERT INTO R_PQWAS (" );
                        strSql . Append ( "WAS001,WAS002,WAS004,WAS005,WAS006,WAS007,WAS008,WAS009,WAS010,WAS012,WAS013) " );
                        strSql . Append ( "VALUES (" );
                        strSql . Append ( "@WAS001,@WAS002,@WAS004,@WAS005,@WAS006,@WAS007,@WAS008,@WAS009,@WAS010,@WAS012,@WAS013) " );
                        parameter = new SqlParameter [ ]{
                            new SqlParameter("@WAS001",SqlDbType.NVarChar,20),
                            new SqlParameter("@WAS002",SqlDbType.Date),
                            new SqlParameter("@WAS004",SqlDbType.NVarChar,20),
                            new SqlParameter("@WAS005",SqlDbType.NVarChar,20),
                            new SqlParameter("@WAS006",SqlDbType.Decimal,8),
                            new SqlParameter("@WAS007",SqlDbType.Decimal,10),
                            new SqlParameter("@WAS008",SqlDbType.Decimal,10),
                            new SqlParameter("@WAS009",SqlDbType.NVarChar,20),
                            new SqlParameter("@WAS010",SqlDbType.NVarChar,50),
                            new SqlParameter("@WAS012",SqlDbType.Int),
                            new SqlParameter("@WAS013",SqlDbType.NVarChar,20)
                        };
                        parameter [ 0 ] . Value = _was . WAS001;
                        parameter [ 1 ] . Value = _was . WAS002;
                        parameter [ 2 ] . Value = _was . WAS004;
                        parameter [ 3 ] . Value = _was . WAS005;
                        parameter [ 4 ] . Value = _was . WAS006;
                        parameter [ 5 ] . Value = _was . WAS007;
                        parameter [ 6 ] . Value = _was . WAS008;
                        parameter [ 7 ] . Value = _was . WAS009;
                        parameter [ 8 ] . Value = _was . WAS010;
                        parameter [ 9 ] . Value = _was . WAS012;
                        parameter [ 10 ] . Value = _was . WAS013;
                    }
                    else
                    {
                        strSql . Append ( "INSERT INTO R_PQAD (" );
                        strSql . Append ( "AD01,AD17,AD02,AD03,AD04,AD05,AD06,AD07,AD08,AD09,AD10,AD11,AD12,AD13,AD14,AD15,AD16) " );
                        strSql . Append ( "VALUES (" );
                        strSql . Append ( "@AD01,@AD17,@AD02,@AD03,@AD04,@AD05,@AD06,@AD07,@AD08,@AD09,@AD10,@AD11,@AD12,@AD13,@AD14,@AD15,@AD16) " );
                        parameter = new SqlParameter [ ]{
                            new SqlParameter("@AD01",SqlDbType.NVarChar,20),
                            new SqlParameter("@AD17",SqlDbType.NVarChar,20),
                            new SqlParameter("@AD02",SqlDbType.NVarChar,100),
                            new SqlParameter("@AD03",SqlDbType.NVarChar,100),
                            new SqlParameter("@AD04",SqlDbType.NVarChar,100),
                            new SqlParameter("@AD05",SqlDbType.BigInt),
                            new SqlParameter("@AD06",SqlDbType.NVarChar,100),
                            new SqlParameter("@AD07",SqlDbType.NVarChar,100),
                            new SqlParameter("@AD08",SqlDbType.NVarChar,20),
                            new SqlParameter("@AD09",SqlDbType.Decimal,8),
                            new SqlParameter("@AD10",SqlDbType.Decimal,10),
                            new SqlParameter("@AD11",SqlDbType.Decimal,10),
                            new SqlParameter("@AD12",SqlDbType.Decimal,10),
                            new SqlParameter("@AD13",SqlDbType.Date,3),
                            new SqlParameter("@AD14",SqlDbType.NVarChar,255),
                            new SqlParameter("@AD15",SqlDbType.NVarChar,20),
                            new SqlParameter("@AD16",SqlDbType.Date,3)
                        };
                        parameter [ 0 ] . Value = nameOf;
                        parameter [ 1 ] . Value = "R_301";
                        parameter [ 2 ] . Value = string . Empty;
                        parameter [ 3 ] . Value = string . Empty;
                        parameter [ 4 ] . Value = string . Empty;
                        parameter [ 5 ] . Value = 0;
                        parameter [ 6 ] . Value = _was . WAS001;
                        parameter [ 7 ] . Value = _was . WAS004;
                        parameter [ 8 ] . Value = _was . WAS005;
                        parameter [ 9 ] . Value = 0;
                        parameter [ 10 ] . Value = 0;
                        parameter [ 11 ] . Value = _was . WAS008;
                        parameter [ 12 ] . Value = _was . WAS006;
                        parameter [ 13 ] . Value = DateTime . Now;
                        parameter [ 14 ] . Value = string . Empty;
                        parameter [ 15 ] . Value = string . Empty;
                        parameter [ 16 ] . Value = DateTime . Now;
                    }

                    SQLString . Add ( strSql ,parameter );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }


    }
}

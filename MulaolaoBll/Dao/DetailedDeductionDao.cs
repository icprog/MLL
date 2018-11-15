using System;
using System . Collections . Generic;
using System . Data;
using System . Data . SqlClient;
using System . Linq;
using System . Text;
using StudentMgr;
using System . Collections;

namespace MulaolaoBll.Dao
{
    public class DetailedDeductionDao
    {
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQWZ" );
            strSql.Append( " WHERE WZ001=@WZ001 AND (WZ016!='执行' OR WZ016='' OR WZ016 IS NULL)" );
            SqlParameter[] parameter = {
                new SqlParameter("@WZ001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取车间主任信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "WITH CET AS (SELECT DBA001,DBA002,DAA002,DAA001,DAA005 FROM TPADAA A LEFT JOIN TPADBA B ON A.DAA001=B.DBA005 WHERE DAA002='生产部'),CEF AS(SELECT DBA001,DBA002,A.DAA002,A.DAA001,A.DAA005 FROM CET A LEFT JOIN TPADAA B ON A.DAA001=B.DAA005) SELECT DBA001,DBA002 FROM CEF" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取采购人
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfPurchase ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DBA001,DBA002 FROM TPADBA WHERE DBA028!=''" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public int Add ( MulaolaoLibrary.DetailedDeductionLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQWZ (" );
            strSql.Append( "WZ001,WZ002,WZ003,WZ004,WZ005,WZ006,WZ007,WZ008,WZ009,WZ010,WZ011,WZ012,WZ013,WZ014,WZ015)" );
            strSql.Append( " VALUES (" );
            strSql.Append( "@WZ001,@WZ002,@WZ003,@WZ004,@WZ005,@WZ006,@WZ007,@WZ008,@WZ009,@WZ010,@WZ011,@WZ012,@WZ013,@WZ014,@WZ015);" );
            strSql.Append( "SELECT SCOPE_IDENTITY();" );
            SqlParameter[] parameter = {
                new SqlParameter("@WZ001",SqlDbType.NVarChar,20),
                new SqlParameter("@WZ002",SqlDbType.Date),
                new SqlParameter("@WZ003",SqlDbType.NVarChar,20),
                new SqlParameter("@WZ004",SqlDbType.NVarChar,50),
                new SqlParameter("@WZ005",SqlDbType.NVarChar,20),
                new SqlParameter("@WZ006",SqlDbType.NVarChar,20),
                new SqlParameter("@WZ007",SqlDbType.NVarChar,20),
                new SqlParameter("@WZ008",SqlDbType.NVarChar,20),
                new SqlParameter("@WZ009",SqlDbType.NVarChar,50),
                new SqlParameter("@WZ010",SqlDbType.Decimal),
                new SqlParameter("@WZ011",SqlDbType.Decimal),
                new SqlParameter("@WZ012",SqlDbType.Decimal),
                new SqlParameter("@WZ013",SqlDbType.Decimal),
                new SqlParameter("@WZ014",SqlDbType.Decimal),
                new SqlParameter("@WZ015",SqlDbType.NVarChar,100)
            };
            parameter[0].Value = _model.WZ001;
            parameter[1].Value = _model.WZ002;
            parameter[2].Value = _model.WZ003;
            parameter[3].Value = _model.WZ004;
            parameter[4].Value = _model.WZ005;
            parameter[5].Value = _model.WZ006;
            parameter[6].Value = _model.WZ007;
            parameter[7].Value = _model.WZ008;
            parameter[8].Value = _model.WZ009;
            parameter[9].Value = _model.WZ010;
            parameter[10].Value = _model.WZ011;
            parameter[11].Value = _model.WZ012;
            parameter[12].Value = _model.WZ013;
            parameter[13].Value = _model.WZ014;
            parameter[14].Value = _model.WZ015;

            int id = SqlHelper.ExecuteSqlReturnId( strSql.ToString( ) ,parameter );
            return id;
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Edit ( MulaolaoLibrary.DetailedDeductionLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQWZ SET " );
            strSql.Append( "WZ002=@WZ002," );
            strSql.Append( "WZ003=@WZ003," );
            strSql.Append( "WZ004=@WZ004," );
            strSql.Append( "WZ005=@WZ005," );
            strSql.Append( "WZ006=@WZ006," );
            strSql.Append( "WZ007=@WZ007," );
            strSql.Append( "WZ008=@WZ008," );
            strSql.Append( "WZ009=@WZ009," );
            strSql.Append( "WZ010=@WZ010," );
            strSql.Append( "WZ011=@WZ011," );
            strSql.Append( "WZ012=@WZ012," );
            strSql.Append( "WZ013=@WZ013," );
            strSql.Append( "WZ014=@WZ014," );
            strSql.Append( "WZ015=@WZ015" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                 new SqlParameter("@WZ002",SqlDbType.Date),
                new SqlParameter("@WZ003",SqlDbType.NVarChar,20),
                new SqlParameter("@WZ004",SqlDbType.NVarChar,50),
                new SqlParameter("@WZ005",SqlDbType.NVarChar,20),
                new SqlParameter("@WZ006",SqlDbType.NVarChar,20),
                new SqlParameter("@WZ007",SqlDbType.NVarChar,20),
                new SqlParameter("@WZ008",SqlDbType.NVarChar,20),
                new SqlParameter("@WZ009",SqlDbType.NVarChar,50),
                new SqlParameter("@WZ010",SqlDbType.Decimal),
                new SqlParameter("@WZ011",SqlDbType.Decimal),
                new SqlParameter("@WZ012",SqlDbType.Decimal),
                new SqlParameter("@WZ013",SqlDbType.Decimal),
                new SqlParameter("@WZ014",SqlDbType.Decimal),
                new SqlParameter("@WZ015",SqlDbType.NVarChar,100),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = _model.WZ002;
            parameter[1].Value = _model.WZ003;
            parameter[2].Value = _model.WZ004;
            parameter[3].Value = _model.WZ005;
            parameter[4].Value = _model.WZ006;
            parameter[5].Value = _model.WZ007;
            parameter[6].Value = _model.WZ008;
            parameter[7].Value = _model.WZ009;
            parameter[8].Value = _model.WZ010;
            parameter[9].Value = _model.WZ011;
            parameter[10].Value = _model.WZ012;
            parameter[11].Value = _model.WZ013;
            parameter[12].Value = _model.WZ014;
            parameter[13].Value = _model.WZ015;
            parameter[14].Value = _model.IDX;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 是否存在本次付款记录且已经审核或执行
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Exit ( int idx )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM R_PQWY WHERE WY001={0} AND WY004 IN ('审核','执行')" ,idx );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 木佬佬付款是否存在
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Exit_231 ( int idx )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM R_PQYZ WHERE YZ023 LIKE '%{0}%'" ,idx );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 永灵付款是否存在
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Exit_231_yl ( int idx )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM R_PQAP WHERE AP023 LIKE '%{0}%'" ,idx );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 木佬佬扣款是否存在
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Exit_231_MK ( int idx )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM R_PQAO WHERE AO022 LIKE '%{0}%'" ,idx );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }


        /// <summary>
        /// 永灵扣款是否存在
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Exit_231_YL ( int idx )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM R_PQAR WHERE AR022 LIKE '%{0}%'" ,idx );
            
            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQWZ" );
            strSql . AppendFormat ( " WHERE idx={0}" ,idx );
            SQLString . Add ( strSql );
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQWY" );
            strSql . AppendFormat ( " WHERE WY001={0}" ,idx );
            SQLString . Add ( strSql );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableGrid ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT A.idx,WZ002,WZ003,WZ004,WZ005,WZ006,WZ007,WZ008,WZ009,WZ010,WZ011,WZ012,WZ013,WZ014,WZ015,WZ016,SUM(ISNULL(WY002,0)) WZ FROM R_PQWZ A LEFT JOIN R_PQWY B ON A.idx=B.WY001 " );
            strSql . Append ( " WHERE " + strWhere );
            strSql . Append ( " GROUP BY A.idx,WZ002,WZ003,WZ004,WZ005,WZ006,WZ007,WZ008,WZ009,WZ010,WZ011,WZ012,WZ013,WZ014,WZ015,WZ016" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        public DataTable GetDataTableGrid (  )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT A.idx,WZ002,WZ003,WZ004,WZ005,WZ006,WZ007,WZ008,WZ009,WZ010,WZ011,WZ012,WZ013,WZ014,WZ015,WZ016,SUM(ISNULL(WY002,0)) WZ FROM R_PQWZ A LEFT JOIN R_PQWY B ON A.idx=B.WY001 " );
            strSql . Append ( " WHERE  WZ016='' OR WZ016 IS NULL"  );
            strSql . Append ( " GROUP BY A.idx,WZ002,WZ003,WZ004,WZ005,WZ006,WZ007,WZ008,WZ009,WZ010,WZ011,WZ012,WZ013,WZ014,WZ015,WZ016" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        public DataTable GetDataTableZ ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT idx,WY001,WY002,WY003,WY004 FROM R_PQWY WHERE {0} " ,strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT WZ001,WZ002,WZ004,WZ009,SUBSTRING(CONVERT(VARCHAR,WZ002),1,4) WZ FROM R_PQWZ" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQWZ" );
            strSql.Append( " WHERE " + strWhere );

            object boj= SqlHelper.GetSingle( strSql.ToString( ) );
            if ( boj == null )
                return 0;
            else
                return Convert.ToInt32( boj );
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndedx"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTableByChange ( string strWhere ,int startIndedx ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,WZ001,WZ002,WZ004,WZ009 FROM (" );
            strSql.Append( "SELECT ROW_NUMBER() OVER(" );
            strSql.Append( "ORDER BY T.WZ001 DESC" );
            strSql.Append( ") AS Row,T.* FROM R_PQWZ T" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") TT" );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndedx ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.DetailedDeductionLibrary GetModel ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQWZ" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parametre = {
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parametre[0].Value = idx;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parametre );
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
        public MulaolaoLibrary.DetailedDeductionLibrary GetDataRow ( DataRow row )
        {
            MulaolaoLibrary.DetailedDeductionLibrary _model = new MulaolaoLibrary.DetailedDeductionLibrary( );

            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    _model.IDX = int.Parse( row["idx"].ToString( ) );
                if ( row["WZ001"] != null && row["WZ001"].ToString( ) != "" )
                    _model.WZ001 = row["WZ001"].ToString( );
                if ( row["WZ002"] != null && row["WZ002"].ToString( ) != "" )
                    _model.WZ002 = DateTime.Parse( row["WZ002"].ToString( ) );
                if ( row["WZ003"] != null && row["WZ003"].ToString( ) != "" )
                    _model.WZ003 = row["WZ003"].ToString( );
                if ( row["WZ004"] != null && row["WZ004"].ToString( ) != "" )
                    _model.WZ004 = row["WZ004"].ToString( );
                if ( row["WZ005"] != null && row["WZ005"].ToString( ) != "" )
                    _model.WZ005 = row["WZ005"].ToString( );
                if ( row["WZ006"] != null && row["WZ006"].ToString( ) != "" )
                    _model.WZ006 = row["WZ006"].ToString( );
                if ( row["WZ007"] != null && row["WZ007"].ToString( ) != "" )
                    _model.WZ007 = row["WZ007"].ToString( );
                if ( row["WZ008"] != null && row["WZ008"].ToString( ) != "" )
                    _model.WZ008 = row["WZ008"].ToString( );
                if ( row["WZ009"] != null && row["WZ009"].ToString( ) != "" )
                    _model.WZ009 = row["WZ009"].ToString( );
                if ( row["WZ010"] != null && row["WZ010"].ToString( ) != "" )
                    _model.WZ010 = decimal.Parse( row["WZ010"].ToString( ) );
                if ( row["WZ011"] != null && row["WZ011"].ToString( ) != "" )
                    _model.WZ011 = decimal.Parse( row["WZ011"].ToString( ) );
                if ( row["WZ012"] != null && row["WZ012"].ToString( ) != "" )
                    _model.WZ012 = decimal.Parse( row["WZ012"].ToString( ) );
                if ( row["WZ013"] != null && row["WZ013"].ToString( ) != "" )
                    _model.WZ013 = decimal.Parse( row["WZ013"].ToString( ) );
                if ( row["WZ014"] != null && row["WZ014"].ToString( ) != "" )
                    _model.WZ014 = decimal.Parse( row["WZ014"].ToString( ) );
                if ( row["WZ015"] != null && row["WZ015"].ToString( ) != "" )
                    _model.WZ015 = row["WZ015"].ToString( );
                if ( row["WZ016"] != null && row["WZ016"].ToString( ) != "" )
                    _model.WZ016 = row["WZ016"].ToString( );
            }

            return _model;
        }

        /// <summary>
        /// 获取流水号等信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableNum ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT PQF01,PQF03,PQF04 FROM R_PQF" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 供应商
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableSupplier ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DFA003 FROM TPADFA WHERE DFA003 IS NOT NULL UNION SELECT DGA003 FROM TPADGA WHERE DGA003 IS NOT NULL  AND DGA052='F' UNION SELECT WZ004 FROM R_PQWZ WHERE WZ004 IS NOT NULL" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取付款明细
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public DataTable getTableOf ( int idx )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT idx,WY001,WY002,WY003,WY004 FROM R_PQWY WHERE WY001={0} ORDER BY idx" ,idx );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="table"></param>
        /// <param name="idxList"></param>
        /// <param name="logins"></param>
        /// <returns></returns>
        public bool Save ( DataTable table ,List<string> idxList ,string logins )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            MulaolaoLibrary . DetailedDeductionWYLibrary model = new MulaolaoLibrary . DetailedDeductionWYLibrary ( );
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                model . idx = string . IsNullOrEmpty ( table . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "idx" ] . ToString ( ) );
                model . WY001 = string . IsNullOrEmpty ( table . Rows [ i ] [ "WY001" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "WY001" ] . ToString ( ) );
                model . WY002 = string . IsNullOrEmpty ( table . Rows [ i ] [ "WY002" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "WY002" ] . ToString ( ) );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "WY003" ] . ToString ( ) ) )
                    model . WY003 = null;
                else
                    model . WY003 = Convert . ToDateTime ( table . Rows [ i ] [ "WY003" ] . ToString ( ) );
                model . WY004 = table . Rows [ i ] [ "WY004" ] . ToString ( );

                if ( model . idx > 0 )
                {
                    edit_wy ( SQLString ,strSql ,model );
                    SQLString . Add ( Drity . DrityOfComparation ( "R_244" + i ,"244本次付款金额" ,logins ,MulaolaoBll . Drity . GetDt ( ) ,model . idx . ToString ( ) ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新增" ,"新增" ) ,null );
                }
                else
                {
                    add_wy ( SQLString ,strSql ,model );
                    SQLString . Add ( Drity . DrityOfComparation ( "R_244" + i ,"244本次付款金额" ,logins ,MulaolaoBll . Drity . GetDt ( ) ,model . idx . ToString ( ) ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"编辑" ,"编辑" ) ,null );
                }
            }

            if ( idxList . Count > 0 )
            {
                foreach ( string s in idxList )
                {
                    model . idx = Convert . ToInt32 ( s );
                    delete_wy ( SQLString ,strSql ,model );
                    SQLString . Add ( Drity . DrityOfComparation ( "R_244" + model . idx ,"244本次付款金额" ,logins ,MulaolaoBll . Drity . GetDt ( ) ,model . idx . ToString ( ) ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) ,null );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void add_wy ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . DetailedDeductionWYLibrary model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ("INSERT INTO R_PQWY (" );
            strSql . Append ( "WY001,WY002,WY003,WY004) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@WY001,@WY002,@WY003,@WY004) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@WY001",SqlDbType.Int,4),
                new SqlParameter("@WY002",SqlDbType.Decimal),
                new SqlParameter("@WY003",SqlDbType.Date,3),
                new SqlParameter("@WY004",SqlDbType.NVarChar,50)
            };
            parameter [ 0 ] . Value = model . WY001;
            parameter [ 1 ] . Value = model . WY002;
            parameter [ 2 ] . Value = model . WY003;
            parameter [ 3 ] . Value = model . WY004;

            SQLString . Add ( strSql ,parameter );
        }

        void edit_wy ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . DetailedDeductionWYLibrary model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQWY SET " );
            strSql . Append ( "WY002=@WY002 " );
            strSql . Append ( "WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@WY002",SqlDbType.Decimal),
                new SqlParameter("@idx",SqlDbType.Int,4)
            };
            parameter [ 0 ] . Value = model . WY002;
            parameter [ 1 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameter );
        }

        void delete_wy ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . DetailedDeductionWYLibrary model )
        {
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM R_PQWY WHERE idx={0}" ,model . idx );

            SQLString . Add ( strSql ,null );
        }

    }
}

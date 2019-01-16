using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using StudentMgr;
using System . Data;
using System . Collections;
using System . Data . SqlClient;

namespace MulaolaoBll . Dao
{
    public class QuoDao
    {
        /// <summary>
        /// 获取195数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable getTableFor195Info ( DateTime dt )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT CP06,CP07,CP09,CONVERT(FLOAT,CP13) CP13,CONVERT(FLOAT,CP10) CP10 FROM R_PQQ WHERE CP06!='/' AND (CP03 LIKE 'R_195-{0}%' OR CP03 LIKE 'R_195-{1}%' ) ORDER BY CP06" ,dt . Year ,dt . Year - 1 );
            
            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }
        
        /// <summary>
        /// 获取196数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable getTableFor196Info ( DateTime dt)
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT AH10,AH11,AH18,CONVERT(FLOAT,AH13) AH13,CONVERT(FLOAT,AH16) AH16 FROM R_PQAH WHERE AH11!='/' AND (AH97 LIKE 'R_196-{0}%' OR AH97 LIKE 'R_196-{1}%') ORDER BY AH10" ,dt . Year ,dt . Year - 1 );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取338数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable getTableFor338Info (DateTime dt )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT JM09,CONVERT(FLOAT,JM10) JM10,CONVERT(FLOAT,JM11) JM11,JM94,JM95,JM96,CONVERT(FLOAT,JM120) JM120 FROM R_PQO WHERE (JM01 LIKE 'R_338-{0}%' OR JM01 LIKE 'R_338-{1}%')" ,dt . Year ,dt . Year - 1 );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取339数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable getTableFor339Info ( DateTime dt )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT YQ10,YQ112,YQ119 FROM R_PQI WHERE YQ99 LIKE 'R_339%' AND (YQ99 LIKE 'R_339-{0}%' OR YQ99 LIKE 'R_339-{1}%') ORDER BY YQ10" ,dt . Year ,dt . Year - 1 );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取341数据列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable getTableFor341Info ( DateTime dt )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT PQV10,PQV12,CONVERT(FLOAT,PQV11) PQV11,CONVERT(FLOAT,PQV71) PQV71,CONVERT(FLOAT,PQV72) PQV72,CONVERT(FLOAT,PQV73) PQV73 FROM R_PQV WHERE (PQV76 LIKE 'R_341-{0}%' OR PQV76 LIKE 'R_341-{1}%')" ,dt . Year ,dt . Year - 1 );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }
        
        /// <summary>
        /// 获取342数据列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable getTableFor342Info ( DateTime dt )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT AF015,CONVERT(FLOAT,AF019) AF019,CONVERT(FLOAT,AF023) AF023,CONVERT(FLOAT,AF020) AF020,CONVERT(FLOAT,AF021) AF021,CONVERT(FLOAT,AF022) AF022,CONVERT(DECIMAL(18,0),AF023/AF020/AF021/AF022*1000000) AF087,CONVERT(DECIMAL(11,2),AF023*AF019) AF088 FROM R_PQAF WHERE (AF001 LIKE 'R_342-{0}%' OR AF001 LIKE 'R_342-{1}%')" ,dt . Year ,dt . Year - 1 );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取343数据列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable getTableFor343Info ( DateTime dt )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT PQU10,PQU12,CONVERT(FLOAT,PQU13) PQU13,CONVERT(FLOAT,PQU16) PQU16 FROM R_PQU WHERE (PQU97 LIKE 'R_343-{0}%' OR PQU97 LIKE 'R_343-{1}%')" ,dt . Year ,dt . Year - 1 );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取347数据列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable getTableFor347Info ( DateTime dt )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT PJ09,PJ89,CONVERT(FLOAT,PJ11) PJ11,CONVERT(FLOAT,PJ12) PJ12 FROM R_PQS WHERE (PJ92 LIKE 'R_347-{0}%' OR PJ92 LIKE 'R_347-{1}%')" ,dt . Year ,dt . Year - 1 );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取349数据列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable getTableFor349Info ( DateTime dt )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT CASE WHEN WX98 IS NULL THEN WX10 ELSE WX98 END WX10,WX11,CONVERT(FLOAT,WX14) WX14,CONVERT(FLOAT,WX13) WX13 FROM R_PQT WHERE (WX82 LIKE 'R_349-{0}%' OR WX82 LIKE 'R_349-{1}%')" ,dt . Year ,dt . Year - 1 );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取344数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable getTableFor344Info ( DateTime dt )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT MZ016,MZ018,MZ025 FROM R_PQMZ WHERE MZ001 LIKE 'R_344-{0}%' OR MZ001 LIKE 'R_344-{1}%' ORDER BY MZ016" ,dt . Year ,dt . Year - 1 );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取509工段
        /// </summary>
        /// <returns></returns>
        public DataTable getTableFor509GX ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT GS35 FROM R_PQP WHERE GS35 IS NOT NULL AND GS35!=''" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取单号
        /// </summary>
        /// <returns></returns>
        public string getOddNum ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(QUO001) QUO001 FROM R_QUO" );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                string odd = dt . Rows [ 0 ] [ "QUO001" ] . ToString ( );
                if ( string . IsNullOrEmpty ( odd ) )
                    return "R_504-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "0001";
                else
                {
                    if ( odd . Substring ( 6 ,8) . Equals ( Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) ) )
                        return "R_504-" + ( Convert . ToInt64 ( odd . Substring ( 6 ,odd . Length - 6 ) ) + 1 ) . ToString ( );
                    else
                        return "R_504-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "0001";
                }
            }
            else
                return "R_504-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "0001";
        }
        
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTableView ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,QUR001,QUR002,QUR003,QUR004,QUR005,CONVERT(FLOAT,QUR006) QUR006,QUR007,QUR008,QUR009,CONVERT(FLOAT,QUR010) QUR010,CONVERT(FLOAT,QUR011) QUR011,CONVERT(FLOAT,QUR012) QUR012,CONVERT(FLOAT,QUR013) QUR013,CONVERT(FLOAT,QUR014) QUR014,QUR015,QUR016 FROM R_QUR " );
            strSql . AppendFormat ( "WHERE {0}" ,strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM R_QUO WHERE QUO001='{0}'" ,oddNum );

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            return rows > 0 ? true : false;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="_quo"></param>
        /// <param name="table"></param>
        /// <param name="state"></param>
        /// <param name="idxList"></param>
        /// <returns></returns>
        public bool Save ( MulaolaoLibrary . QuoEntity _quo ,DataTable table ,string state ,List<string> idxList )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            if ( state . Equals ( "add" ) )
            {
                _quo . QUO001 = getOddNum ( );
                AddHeader ( SQLString ,strSql ,_quo );
            }
            else
                EditHeader ( SQLString ,strSql ,_quo );
            
            MulaolaoLibrary . QupEntity _qup = new MulaolaoLibrary . QupEntity ( );
            _qup . QUR001 = _quo . QUO001;
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _qup . QUR002 = table . Rows [ i ] [ "QUR002" ] . ToString ( );
                _qup . QUR003 = table . Rows [ i ] [ "QUR003" ] . ToString ( );
                _qup . QUR004 = table . Rows [ i ] [ "QUR004" ] . ToString ( );
                _qup . QUR005 = table . Rows [ i ] [ "QUR005" ] . ToString ( );
                _qup . QUR006 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QUR006" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "QUR006" ] . ToString ( ) );
                _qup . QUR007 = table . Rows [ i ] [ "QUR007" ] . ToString ( );
                _qup . QUR008 = table . Rows [ i ] [ "QUR008" ] . ToString ( );
                _qup . QUR009 = table . Rows [ i ] [ "QUR009" ] . ToString ( );
                _qup . QUR010 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QUR010" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "QUR010" ] . ToString ( ) );
                _qup . QUR011 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QUR011" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "QUR011" ] . ToString ( ) );
                _qup . QUR012 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QUR012" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "QUR012" ] . ToString ( ) );
                _qup . QUR013 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QUR013" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "QUR013" ] . ToString ( ) );
                _qup . QUR014 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QUR014" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "QUR014" ] . ToString ( ) );
                _qup . QUR016 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QUR016" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "QUR016" ] . ToString ( ) );
                _qup . idx = string . IsNullOrEmpty ( table . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "idx" ] . ToString ( ) );
                _qup . QUR015 = table . Rows [ i ] [ "QUR015" ] . ToString ( );
                if ( _qup . idx < 1 )
                    AddBody ( SQLString ,strSql ,_qup );
                else
                    EditBody ( SQLString ,strSql ,_qup );
            }

            if ( idxList . Count > 0 )
            {
                foreach ( string s in idxList )
                {
                    DeleteBody ( SQLString ,strSql ,s );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void AddHeader ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . QuoEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_QUO(" );
            strSql . Append ( "QUO001,QUO002,QUO003,QUO004,QUO005,QUO006,QUO007,QUO008,QUO009,QUO010)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@QUO001,@QUO002,@QUO003,@QUO004,@QUO005,@QUO006,@QUO007,@QUO008,@QUO009,@QUO010)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@QUO001", SqlDbType.NVarChar,20),
                    new SqlParameter("@QUO002", SqlDbType.NVarChar,50),
                    new SqlParameter("@QUO003", SqlDbType.NVarChar,50),
                    new SqlParameter("@QUO004", SqlDbType.NVarChar,50),
                    new SqlParameter("@QUO005", SqlDbType.NVarChar,50),
                    new SqlParameter("@QUO006", SqlDbType.NVarChar,50),
                    new SqlParameter("@QUO007", SqlDbType.Int,4),
                    new SqlParameter("@QUO008", SqlDbType.Date,3),
                    new SqlParameter("@QUO009", SqlDbType.Image),
                    new SqlParameter("@QUO010", SqlDbType.NVarChar,50)
            };
            parameters [ 0 ] . Value = model . QUO001;
            parameters [ 1 ] . Value = model . QUO002;
            parameters [ 2 ] . Value = model . QUO003;
            parameters [ 3 ] . Value = model . QUO004;
            parameters [ 4 ] . Value = model . QUO005;
            parameters [ 5 ] . Value = model . QUO006;
            parameters [ 6 ] . Value = model . QUO007;
            parameters [ 7 ] . Value = model . QUO008;
            parameters [ 8 ] . Value = model . QUO009;
            parameters [ 9 ] . Value = model . QUO010;
            SQLString . Add ( strSql ,parameters );
        }

        void EditHeader ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . QuoEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_QUO set " );
            strSql . Append ( "QUO002=@QUO002," );
            strSql . Append ( "QUO003=@QUO003," );
            strSql . Append ( "QUO004=@QUO004," );
            strSql . Append ( "QUO005=@QUO005," );
            strSql . Append ( "QUO006=@QUO006," );
            strSql . Append ( "QUO007=@QUO007," );
            strSql . Append ( "QUO008=@QUO008," );
            strSql . Append ( "QUO009=@QUO009," );
            strSql . Append ( "QUO010=@QUO010 " );
            strSql . Append ( " where QUO001=@QUO001" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@QUO001", SqlDbType.NVarChar,20),
                    new SqlParameter("@QUO002", SqlDbType.NVarChar,50),
                    new SqlParameter("@QUO003", SqlDbType.NVarChar,50),
                    new SqlParameter("@QUO004", SqlDbType.NVarChar,50),
                    new SqlParameter("@QUO005", SqlDbType.NVarChar,50),
                    new SqlParameter("@QUO006", SqlDbType.NVarChar,50),
                    new SqlParameter("@QUO007", SqlDbType.Int,4),
                    new SqlParameter("@QUO008", SqlDbType.Date,3),
                    new SqlParameter("@QUO009", SqlDbType.Image),
                    new SqlParameter("@QUO010", SqlDbType.NVarChar,50),
            };
            parameters [ 0 ] . Value = model . QUO001;
            parameters [ 1 ] . Value = model . QUO002;
            parameters [ 2 ] . Value = model . QUO003;
            parameters [ 3 ] . Value = model . QUO004;
            parameters [ 4 ] . Value = model . QUO005;
            parameters [ 5 ] . Value = model . QUO006;
            parameters [ 6 ] . Value = model . QUO007;
            parameters [ 7 ] . Value = model . QUO008;
            parameters [ 8 ] . Value = model . QUO009;
            parameters [ 9 ] . Value = model . QUO010;
            SQLString . Add ( strSql ,parameters );
        }

        void AddBody ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . QupEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_QUR(" );
            strSql . Append ( "QUR001,QUR002,QUR003,QUR004,QUR005,QUR006,QUR007,QUR008,QUR009,QUR010,QUR011,QUR012,QUR013,QUR014,QUR015,QUR016)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@QUR001,@QUR002,@QUR003,@QUR004,@QUR005,@QUR006,@QUR007,@QUR008,@QUR009,@QUR010,@QUR011,@QUR012,@QUR013,@QUR014,@QUR015,@QUR016)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@QUR001", SqlDbType.NVarChar,20),
                    new SqlParameter("@QUR002", SqlDbType.NVarChar,50),
                    new SqlParameter("@QUR003", SqlDbType.NVarChar,50),
                    new SqlParameter("@QUR004", SqlDbType.NVarChar,50),
                    new SqlParameter("@QUR005", SqlDbType.NVarChar,50),
                    new SqlParameter("@QUR006", SqlDbType.Decimal,9),
                    new SqlParameter("@QUR007", SqlDbType.NVarChar,20),
                    new SqlParameter("@QUR008", SqlDbType.NVarChar,20),
                    new SqlParameter("@QUR009", SqlDbType.NVarChar,20),
                    new SqlParameter("@QUR010", SqlDbType.Decimal,9),
                    new SqlParameter("@QUR011", SqlDbType.Decimal,9),
                    new SqlParameter("@QUR012", SqlDbType.Decimal,9),
                    new SqlParameter("@QUR013", SqlDbType.Decimal,9),
                    new SqlParameter("@QUR014", SqlDbType.Decimal,9),
                    new SqlParameter("@QUR015", SqlDbType.NVarChar,50),
                    new SqlParameter("@QUR016", SqlDbType.Decimal,9)
            };
            parameters [ 0 ] . Value = model . QUR001;
            parameters [ 1 ] . Value = model . QUR002;
            parameters [ 2 ] . Value = model . QUR003;
            parameters [ 3 ] . Value = model . QUR004;
            parameters [ 4 ] . Value = model . QUR005;
            parameters [ 5 ] . Value = model . QUR006;
            parameters [ 6 ] . Value = model . QUR007;
            parameters [ 7 ] . Value = model . QUR008;
            parameters [ 8 ] . Value = model . QUR009;
            parameters [ 9 ] . Value = model . QUR010;
            parameters [ 10 ] . Value = model . QUR011;
            parameters [ 11 ] . Value = model . QUR012;
            parameters [ 12 ] . Value = model . QUR013;
            parameters [ 13 ] . Value = model . QUR014;
            parameters [ 14 ] . Value = model . QUR015;
            parameters [ 15 ] . Value = model . QUR016;
            SQLString . Add ( strSql ,parameters );
        }

        void EditBody ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . QupEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_QUR set " );
            strSql . Append ( "QUR001=@QUR001," );
            strSql . Append ( "QUR002=@QUR002," );
            strSql . Append ( "QUR003=@QUR003," );
            strSql . Append ( "QUR004=@QUR004," );
            strSql . Append ( "QUR005=@QUR005," );
            strSql . Append ( "QUR006=@QUR006," );
            strSql . Append ( "QUR007=@QUR007," );
            strSql . Append ( "QUR008=@QUR008," );
            strSql . Append ( "QUR009=@QUR009," );
            strSql . Append ( "QUR010=@QUR010," );
            strSql . Append ( "QUR011=@QUR011," );
            strSql . Append ( "QUR012=@QUR012," );
            strSql . Append ( "QUR013=@QUR013," );
            strSql . Append ( "QUR014=@QUR014," );
            strSql . Append ( "QUR015=@QUR015," );
            strSql . Append ( "QUR016=@QUR016 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@QUR001", SqlDbType.NVarChar,20),
                    new SqlParameter("@QUR002", SqlDbType.NVarChar,50),
                    new SqlParameter("@QUR003", SqlDbType.NVarChar,50),
                    new SqlParameter("@QUR004", SqlDbType.NVarChar,50),
                    new SqlParameter("@QUR005", SqlDbType.NVarChar,50),
                    new SqlParameter("@QUR006", SqlDbType.Decimal,9),
                    new SqlParameter("@QUR007", SqlDbType.NVarChar,20),
                    new SqlParameter("@QUR008", SqlDbType.NVarChar,20),
                    new SqlParameter("@QUR009", SqlDbType.NVarChar,20),
                    new SqlParameter("@QUR010", SqlDbType.Decimal,9),
                    new SqlParameter("@QUR011", SqlDbType.Decimal,9),
                    new SqlParameter("@QUR012", SqlDbType.Decimal,9),
                    new SqlParameter("@QUR013", SqlDbType.Decimal,9),
                    new SqlParameter("@QUR014", SqlDbType.Decimal,9),
                    new SqlParameter("@idx", SqlDbType.Int,4),
                    new SqlParameter("@QUR015", SqlDbType.NVarChar,50),
                    new SqlParameter("@QUR016", SqlDbType.Decimal,9)
            };
            parameters [ 0 ] . Value = model . QUR001;
            parameters [ 1 ] . Value = model . QUR002;
            parameters [ 2 ] . Value = model . QUR003;
            parameters [ 3 ] . Value = model . QUR004;
            parameters [ 4 ] . Value = model . QUR005;
            parameters [ 5 ] . Value = model . QUR006;
            parameters [ 6 ] . Value = model . QUR007;
            parameters [ 7 ] . Value = model . QUR008;
            parameters [ 8 ] . Value = model . QUR009;
            parameters [ 9 ] . Value = model . QUR010;
            parameters [ 10 ] . Value = model . QUR011;
            parameters [ 11 ] . Value = model . QUR012;
            parameters [ 12 ] . Value = model . QUR013;
            parameters [ 13 ] . Value = model . QUR014;
            parameters [ 14 ] . Value = model . idx;
            parameters [ 15 ] . Value = model . QUR015;
            parameters [ 16 ] . Value = model . QUR016;
            SQLString . Add ( strSql ,parameters );
        }

        void DeleteBody ( Hashtable SQLString ,StringBuilder strSql ,string idx )
        {
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM R_QUR WHERE idx={0}" ,idx );
            SQLString . Add ( strSql ,null );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable getTableOnlyColumn ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT QUO001,QUO002,QUO003,QUO004,QUO005,QUO006 FROM R_QUO" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取总数量
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int getCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM R_QUO WHERE {0}" ,strWhere );

            object obj = SqlHelper . GetSingle ( strSql . ToString ( ) );
            if ( obj == null )
                return 0;
            else
                return Convert . ToInt32 ( obj );
        }

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable getDataTableByChange ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT QUO001,QUO002,QUO003,QUO004,QUO005,QUO006,QUO007,QUO008 FROM (" );
            strSql . Append ( "SELECT ROW_NUMBER() OVER( " );
            strSql . Append ( "ORDER BY T.QUO001 DESC) " );
            strSql . Append ( "AS ROW,T.* FROM R_QUO T " );
            strSql . Append ( "WHERE " + strWhere );
            strSql . Append ( ") TT " );
            strSql . AppendFormat ( "WHERE TT.ROW BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public MulaolaoLibrary . QuoEntity getModel ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT QUO001,QUO002,QUO003,QUO004,QUO005,QUO006,QUO007,QUO008,QUO009,QUO010 FROM R_QUO WHERE {0}" ,strWhere );

            DataTable table = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( table == null || table . Rows . Count < 1 )
                return null;
            return getModel ( table . Rows [ 0 ] );
        }

        public MulaolaoLibrary . QuoEntity getModel ( DataRow row )
        {
            MulaolaoLibrary . QuoEntity model = new MulaolaoLibrary . QuoEntity ( );
            if ( row != null )
            {
                if ( row [ "QUO001" ] != null )
                {
                    model . QUO001 = row [ "QUO001" ] . ToString ( );
                }
                if ( row [ "QUO002" ] != null )
                {
                    model . QUO002 = row [ "QUO002" ] . ToString ( );
                }
                if ( row [ "QUO003" ] != null )
                {
                    model . QUO003 = row [ "QUO003" ] . ToString ( );
                }
                if ( row [ "QUO004" ] != null )
                {
                    model . QUO004 = row [ "QUO004" ] . ToString ( );
                }
                if ( row [ "QUO005" ] != null )
                {
                    model . QUO005 = row [ "QUO005" ] . ToString ( );
                }
                if ( row [ "QUO006" ] != null )
                {
                    model . QUO006 = row [ "QUO006" ] . ToString ( );
                }
                if ( row [ "QUO007" ] != null && row [ "QUO007" ] . ToString ( ) != "" )
                {
                    model . QUO007 = int . Parse ( row [ "QUO007" ] . ToString ( ) );
                }
                if ( row [ "QUO008" ] != null && row [ "QUO008" ] . ToString ( ) != "" )
                {
                    model . QUO008 = DateTime . Parse ( row [ "QUO008" ] . ToString ( ) );
                }
                if ( row [ "QUO009" ] != null && row [ "QUO009" ] . ToString ( ) != "" )
                {
                    model . QUO009 = ( byte [ ] ) row [ "QUO009" ];
                }
                if ( row [ "QUO010" ] != null && row [ "QUO010" ] . ToString ( ) != "" )
                {
                    model . QUO010 = row [ "QUO010" ] . ToString ( );
                }
            }
            return model;
        }

        /// <summary>
        /// 获取业务人员
        /// </summary>
        /// <returns></returns>
        public DataTable getTableFor ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DBA002 FROM TPADBA WHERE DBA005 LIKE '0201%' AND DBA043='F'" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }


    }
}

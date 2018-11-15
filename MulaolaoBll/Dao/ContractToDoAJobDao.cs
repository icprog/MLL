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
    public class ContractToDoAJobDao
    {
        /// <summary>
        /// 获取生产车间
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableWork ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DBA001,DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002 IN (SELECT DBA002 FROM TPADBA WHERE DBA005=(SELECT DAA001 FROM TPADAA WHERE DAA002='生产部')) AND (DBA043='F' OR DBA043='' OR DBA043 IS NULL))" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取业务员
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableSalesman ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DBA001,DBA002,DBA028 FROM TPADBA WHERE DBA028!='' AND (DBA043='F' OR DBA043='' OR DBA043 IS NULL)" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DeleteAll ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQBA" );
            strSql.AppendFormat( " WHERE BA003='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            if ( ExistsOfReview( oddNum ) )
            {
                StringBuilder strS = new StringBuilder( );
                strS.Append( "DELETE FROM R_REVIEWS" );
                strS.AppendFormat( " WHERE RES06='{0}'" ,oddNum );
                SQLString.Add( strS.ToString( ) );
            }
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );
            if ( stateOfOdd == "维护删除" )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "DELETE FROM R_PQAMB WHERE AMB001='{0}'" ,oddNum );
                SQLString.Add( strSql.ToString( ) );
            }
            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 是否送审或执行
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool ExistsOfReview ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_REVIEWS" );
            strSql.Append( " WHERE RES06=@RES06" );
            SqlParameter[] parameter = {
                new SqlParameter("@RES06",SqlDbType.NVarChar)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.ContractToDoAJobLibrary _model,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQBA SET " );
            //strSql.AppendFormat( "BA001='{0}'," ,_model.BA001);
            strSql.AppendFormat( "BA002='{0}'," ,_model.BA002 );           
            strSql.AppendFormat( "BA004='{0}'," ,_model.BA004 );
            strSql.AppendFormat( "BA005='{0}'," ,_model.BA005 );
            strSql.AppendFormat( "BA015='{0}'," ,_model.BA015 );
            strSql.AppendFormat( "BA016='{0}'," ,_model.BA016 );
            strSql.AppendFormat( "BA017='{0}'," ,_model.BA017 );
            strSql.AppendFormat( "BA018='{0}'," ,_model.BA018 );
            strSql.AppendFormat( "BA019='{0}'," ,_model.BA019 );
            strSql.AppendFormat( "BA020='{0}'," ,_model.BA020 );
            strSql.AppendFormat( "BA021='{0}'," ,_model.BA021 );
            strSql.AppendFormat( "BA022='{0}'," ,_model.BA022 );
            strSql.AppendFormat( "BA023='{0}'," ,_model.BA023 );
            strSql.AppendFormat( "BA024='{0}'," ,_model.BA024 );
            strSql.AppendFormat( "BA025='{0}'," ,_model.BA025 );
            strSql.AppendFormat( "BA026='{0}'," ,_model.BA026 );
            strSql.AppendFormat( "BA027='{0}'," ,_model.BA027 );
            strSql.AppendFormat( "BA028='{0}'," ,_model.BA028 );
            strSql.AppendFormat( "BA029='{0}'," ,_model.BA029 );
            strSql.AppendFormat( "BA030='{0}'," ,_model.BA030 );
            strSql.AppendFormat( "BA031='{0}'," ,_model.BA031 );
            strSql.AppendFormat( "BA032='{0}'," ,_model.BA032 );
            strSql.AppendFormat( "BA033='{0}'," ,_model.BA033 );
            strSql.AppendFormat( "BA034='{0}'," ,_model.BA034 );
            strSql.AppendFormat( "BA035='{0}'," ,_model.BA035 );
            strSql.AppendFormat( "BA036='{0}'," ,_model.BA036 );
            strSql.AppendFormat( "BA037='{0}'," ,_model.BA037 );
            strSql.AppendFormat( "BA038='{0}'," ,_model.BA038 );
            strSql.AppendFormat( "BA039='{0}'," ,_model.BA039 );
            strSql.AppendFormat( "BA040='{0}'," ,_model.BA040 );
            strSql.AppendFormat( "BA041='{0}'," ,_model.BA041 );
            strSql.AppendFormat( "BA042='{0}'," ,_model.BA042 );
            strSql.AppendFormat( "BA043='{0}'," ,_model.BA043 );
            strSql.AppendFormat( "BA044='{0}'," ,_model.BA044 );
            strSql.AppendFormat( "BA045='{0}'," ,_model.BA045 );
            strSql.AppendFormat( "BA046='{0}'," ,_model.BA046 );
            strSql.AppendFormat( "BA047='{0}'," ,_model.BA047 );
            strSql.AppendFormat( "BA048='{0}'," ,_model.BA048 );
            strSql.AppendFormat( "BA049='{0}'," ,_model.BA049 );
            strSql.AppendFormat( "BA050='{0}'," ,_model.BA050 );
            //strSql.AppendFormat( "BA051='{0}'," ,_model.BA051 );
            //strSql.AppendFormat( "BA052='{0}'," ,_model.BA052 );
            //strSql.AppendFormat( "BA053='{0}'," ,_model.BA053 );
            //strSql.AppendFormat( "BA054='{0}'," ,_model.BA054 );
            strSql.AppendFormat( "BA056='{0}'," ,_model.BA056 );
            strSql.AppendFormat( "BA057='{0}'," ,_model.BA057 );
            strSql.AppendFormat( "BA058='{0}'" ,_model.BA058 );
            strSql.AppendFormat( " WHERE BA003='{0}'" ,_model.BA003 );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,_model.BA003 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );
            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 复制数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Copy ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQBA (BA001,BA002,BA004,BA005,BA015,BA016,BA017,BA018,BA019,BA020,BA021,BA022,BA023,BA024,BA025,BA026,BA027,BA028,BA029,BA030,BA031,BA042,BA044,BA045,BA046,BA047,BA048,BA051,BA052,BA053,BA054,BA058) SELECT BA001,BA002,BA004,BA005,BA015,BA016,BA017,BA018,BA019,BA020,BA021,BA022,BA023,BA024,BA025,BA026,BA027,BA028,BA029,BA030,BA031,BA042,BA044,BA045,BA046,BA047,BA048,BA051,BA052,BA053,BA054,BA058 FROM R_PQBA " );
            strSql.AppendFormat( " WHERE BA003='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 编辑复制数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateOfCopy ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQBA SET " );
            strSql.AppendFormat( "BA003='{0}'," ,oddNum );
            strSql.Append( "BA055='复制'" );
            strSql.Append( " WHERE BA003 IS NULL" );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );
            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 删除复制数据
        /// </summary>
        /// <returns></returns>
        public bool DeleteOfCopy ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQBA" );
            strSql.Append( " WHERE BA003 IS NULL" );

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取数据源
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfOnly ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT BA003,BA001,BA051,BA052,BA053,BA044 FROM R_PQBA" );

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
            strSql.Append( "SELECT COUNT(1) FROM (SELECT DISTINCT BA003,BA001,BA051,BA052,BA053,BA044 FROM R_PQBA" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( " ) A" );

            object obj = SqlHelper.GetSingle( strSql.ToString( ) );
            if ( obj == null )
                return 0;
            else
                return Convert.ToInt32( obj );
        }

        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCounts ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQBA" );
            strSql.Append( " WHERE " + strWhere );

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
            strSql.Append( "SELECT DISTINCT BA003,BA001,BA051,BA052,BA053,BA044,BA054,BA056,RES05,BA013*BA054 U2,BA010,BA011,BA032,BA063 FROM (" );
            strSql.Append( " SELECT ROW_NUMBER() OVER (" );
            strSql.Append( " ORDER BY T.BA003 DESC)" );
            strSql.Append( " AS Row,T.* FROM R_PQBA T" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") TT LEFT JOIN R_REVIEWS A ON TT.BA003=A.RES06" );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTableByChanges ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT TT.idx,BA003,BA001,BA051,BA052,BA053,BA044,BA054,BA056,RES05,BA013*BA054 U2,BA010,BA011,BA032,BA063 FROM (" );
            strSql.Append( " SELECT ROW_NUMBER() OVER (" );
            strSql.Append( " ORDER BY T.BA003 DESC)" );
            strSql.Append( " AS Row,T.* FROM R_PQBA T" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") TT LEFT JOIN R_REVIEWS A ON TT.BA003=A.RES06 AND RES05='执行' WHERE NOT EXISTS (SELECT 1 FROM R_PQAL C,R_PQAK D WHERE TT.idx=C.AL003 AND TT.BA003=C.AL002 AND C.AL001=D.idx AND (AK009-AK010-AK011-AK015)<=100)" );
            strSql.AppendFormat( " AND TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool Exists ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQBA" );
            strSql.Append( " WHERE BA001=@BA001" );
            SqlParameter[] parameter = {
                new SqlParameter("@BA001",SqlDbType.NVarChar,1000)
            };
            parameter[0].Value = num;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Add ( MulaolaoLibrary.ContractToDoAJobLibrary _model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string oddNum   ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQBA (" );
            strSql.Append( "BA001,BA002,BA003,BA006,BA007,BA008,BA009,BA010,BA011,BA012,BA013,BA014,BA051,BA052,BA053,BA054,BA059,BA060)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}')" ,_model.BA001,_model.BA002 ,_model.BA003 ,_model.BA006 ,_model.BA007 ,_model.BA008 ,_model.BA009 ,_model.BA010 ,_model.BA011 ,_model.BA012 ,_model.BA013 ,_model.BA014 ,_model.BA051 ,_model.BA052 ,_model.BA053 ,_model.BA054 ,_model.BA059 ,_model.BA060 );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,_model.BA003 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );
            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool DeleteOfOne ( int idx ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string oddNum ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQBA" );
            strSql . AppendFormat ( " WHERE BA003='{1}' AND idx={0}" , idx , oddNum );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,BA001,BA006,BA007,BA008,BA009,BA010,BA011,BA012,BA013,BA014,BA051,BA052,BA053,BA054,BA059,BA060 FROM R_PQBA" );
            strSql.Append( " WHERE " + strWhere );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ContractToDoAJobLibrary GetModel ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQBA" );
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

        public MulaolaoLibrary.ContractToDoAJobLibrary GetModel ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQBA" );
            strSql.Append( " WHERE BA003=@BA003" );
            SqlParameter[] parameter = {
                new SqlParameter("@BA003",SqlDbType.NVarChar)
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
        public MulaolaoLibrary.ContractToDoAJobLibrary GetDataRow ( DataRow row )
        {
            MulaolaoLibrary.ContractToDoAJobLibrary _model = new MulaolaoLibrary.ContractToDoAJobLibrary( );

            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    _model.IDX = int.Parse( row["idx"].ToString( ) );
                if ( row["BA001"] != null && row["BA001"].ToString( ) != "" )
                    _model.BA001 = row["BA001"].ToString( );
                if ( row["BA002"] != null && row["BA002"].ToString( ) != "" )
                    _model.BA002 = row["BA002"].ToString( );
                if ( row["BA003"] != null && row["BA003"].ToString( ) != "" )
                    _model.BA003 = row["BA003"].ToString( );
                if ( row["BA004"] != null && row["BA004"].ToString( ) != "" )
                    _model.BA004 = row["BA004"].ToString( );
                if ( row["BA005"] != null && row["BA005"].ToString( ) != "" )
                    _model.BA005 = row["BA005"].ToString( );
                if ( row["BA006"] != null && row["BA006"].ToString( ) != "" )
                    _model.BA006 = row["BA006"].ToString( );
                if ( row["BA007"] != null && row["BA007"].ToString( ) != "" )
                    _model.BA007 = row["BA007"].ToString( );
                if ( row["BA008"] != null && row["BA008"].ToString( ) != "" )
                    _model.BA008 = row["BA008"].ToString( );
                if ( row["BA009"] != null && row["BA009"].ToString( ) != "" )
                    _model.BA009 = decimal.Parse( row["BA009"].ToString( ) );
                if ( row["BA010"] != null && row["BA010"].ToString( ) != "" )
                    _model.BA010 = decimal.Parse( row["BA010"].ToString( ) );
                if ( row["BA011"] != null && row["BA011"].ToString( ) != "" )
                    _model.BA011 = decimal.Parse( row["BA011"].ToString( ) );
                if ( row["BA012"] != null && row["BA012"].ToString( ) != "" )
                    _model.BA012 = decimal.Parse( row["BA012"].ToString( ) );
                if ( row["BA013"] != null && row["BA013"].ToString( ) != "" )
                    _model.BA013 = decimal.Parse( row["BA013"].ToString( ) );
                if ( row["BA014"] != null && row["BA014"].ToString( ) != "" )
                    _model.BA014 = DateTime.Parse( row["BA014"].ToString( ) );
                if ( row["BA015"] != null && row["BA015"].ToString( ) != "" )
                    _model.BA015 = row["BA015"].ToString( );
                if ( row["BA016"] != null && row["BA016"].ToString( ) != "" )
                    _model.BA016 = row["BA016"].ToString( );
                if ( row["BA017"] != null && row["BA017"].ToString( ) != "" )
                    _model.BA017 = row["BA017"].ToString( );
                if ( row["BA018"] != null && row["BA018"].ToString( ) != "" )
                    _model.BA018 = row["BA018"].ToString( );
                if ( row["BA019"] != null && row["BA019"].ToString( ) != "" )
                    _model.BA019 = int.Parse( row["BA019"].ToString( ) );
                if ( row["BA020"] != null && row["BA020"].ToString( ) != "" )
                    _model.BA020 = row["BA020"].ToString( );
                if ( row["BA021"] != null && row["BA021"].ToString( ) != "" )
                    _model.BA021 = row["BA021"].ToString( );
                if ( row["BA022"] != null && row["BA022"].ToString( ) != "" )
                    _model.BA022 = row["BA022"].ToString( );
                if ( row["BA023"] != null && row["BA023"].ToString( ) != "" )
                    _model.BA023 = row["BA023"].ToString( );
                if ( row["BA024"] != null && row["BA024"].ToString( ) != "" )
                    _model.BA024 = row["BA024"].ToString( );
                if ( row["BA025"] != null && row["BA025"].ToString( ) != "" )
                    _model.BA025 = row["BA025"].ToString( );
                if ( row["BA026"] != null && row["BA026"].ToString( ) != "" )
                    _model.BA026 = row["BA026"].ToString( );
                if ( row["BA027"] != null && row["BA027"].ToString( ) != "" )
                    _model.BA027 = row["BA027"].ToString( );
                if ( row["BA028"] != null && row["BA028"].ToString( ) != "" )
                    _model.BA028 = row["BA028"].ToString( );
                if ( row["BA029"] != null && row["BA029"].ToString( ) != "" )
                    _model.BA029 = row["BA029"].ToString( );
                if ( row["BA030"] != null && row["BA030"].ToString( ) != "" )
                    _model.BA030 = row["BA030"].ToString( );
                if ( row["BA031"] != null && row["BA031"].ToString( ) != "" )
                    _model.BA031 = row["BA031"].ToString( );
                if ( row["BA032"] != null && row["BA032"].ToString( ) != "" )
                    _model.BA032 = row["BA032"].ToString( );
                if ( row["BA033"] != null && row["BA033"].ToString( ) != "" )
                    _model.BA033 = DateTime.Parse( row["BA033"].ToString( ) );
                if ( row["BA034"] != null && row["BA034"].ToString( ) != "" )
                    _model.BA034 = row["BA034"].ToString( );
                if ( row["BA035"] != null && row["BA035"].ToString( ) != "" )
                    _model.BA035 = DateTime.Parse( row["BA035"].ToString( ) );
                if ( row["BA036"] != null && row["BA036"].ToString( ) != "" )
                    _model.BA036 = row["BA036"].ToString( );
                if ( row["BA037"] != null && row["BA037"].ToString( ) != "" )
                    _model.BA037 = DateTime.Parse( row["BA037"].ToString( ) );
                if ( row["BA038"] != null && row["BA038"].ToString( ) != "" )
                    _model.BA038 = row["BA038"].ToString( );
                if ( row["BA039"] != null && row["BA039"].ToString( ) != "" )
                    _model.BA039 = DateTime.Parse( row["BA039"].ToString( ) );
                if ( row["BA040"] != null && row["BA040"].ToString( ) != "" )
                    _model.BA040 = row["BA040"].ToString( );
                if ( row["BA041"] != null && row["BA041"].ToString( ) != "" )
                    _model.BA041 = DateTime.Parse( row["BA041"].ToString( ) );
                if ( row["BA042"] != null && row["BA042"].ToString( ) != "" )
                    _model.BA042 = row["BA042"].ToString( );
                if ( row["BA043"] != null && row["BA043"].ToString( ) != "" )
                    _model.BA043 = DateTime.Parse( row["BA043"].ToString( ) );
                if ( row["BA044"] != null && row["BA044"].ToString( ) != "" )
                    _model.BA044 = row["BA044"].ToString( );
                if ( row["BA045"] != null && row["BA045"].ToString( ) != "" )
                    _model.BA045 = row["BA045"].ToString( );
                if ( row["BA046"] != null && row["BA046"].ToString( ) != "" )
                    _model.BA046 = row["BA046"].ToString( );
                if ( row["BA047"] != null && row["BA047"].ToString( ) != "" )
                    _model.BA047 = row["BA047"].ToString( );
                if ( row["BA048"] != null && row["BA048"].ToString( ) != "" )
                    _model.BA048 = row["BA048"].ToString( );
                if ( row["BA049"] != null && row["BA049"].ToString( ) != "" )
                    _model.BA049 = row["BA049"].ToString( );
                if ( row["BA050"] != null && row["BA050"].ToString( ) != "" )
                    _model.BA050 = row["BA050"].ToString( );
                if ( row["BA051"] != null && row["BA051"].ToString( ) != "" )
                    _model.BA051 = row["BA051"].ToString( );
                if ( row["BA052"] != null && row["BA052"].ToString( ) != "" )
                    _model.BA052 = row["BA052"].ToString( );
                if ( row["BA053"] != null && row["BA053"].ToString( ) != "" )
                    _model.BA053 = row["BA053"].ToString( );
                if ( row["BA054"] != null && row["BA054"].ToString( ) != "" )
                    _model.BA054 = long.Parse( row["BA054"].ToString( ) );
                if ( row["BA055"] != null && row["BA055"].ToString( ) != "" )
                    _model.BA055 = row["BA055"].ToString( );
                if ( row["BA056"] != null && row["BA056"].ToString( ) != "" )
                    _model.BA056 = row["BA056"].ToString( );
                if ( row["BA057"] != null && row["BA057"].ToString( ) != "" )
                    _model.BA057 = row["BA057"].ToString( );
                if ( row["BA058"] != null && row["BA058"].ToString( ) != "" )
                    _model.BA058 = row["BA058"].ToString( );
                if ( row["BA059"] != null && row["BA059"].ToString( ) != "" )
                    _model.BA059 = decimal.Parse( row["BA059"].ToString( ) );
                if ( row["BA060"] != null && row["BA060"].ToString( ) != "" )
                    _model.BA060 = decimal.Parse( row["BA060"].ToString( ) );
            }

            return _model;
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool UpdateOfOne ( MulaolaoLibrary.ContractToDoAJobLibrary _model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string oddNum ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQBA SET " );
            strSql.AppendFormat( "BA001='{0}',",_model.BA001 );
            strSql.AppendFormat( "BA006='{0}'," ,_model.BA006 );
            strSql.AppendFormat( "BA007='{0}'," ,_model.BA007 );
            strSql.AppendFormat( "BA008='{0}'," ,_model.BA008 );
            strSql.AppendFormat( "BA009='{0}'," ,_model.BA009 );
            strSql.AppendFormat( "BA010='{0}'," ,_model.BA010 );
            strSql.AppendFormat( "BA011='{0}'," ,_model.BA011 );
            strSql.AppendFormat( "BA012='{0}'," ,_model.BA012 );
            strSql.AppendFormat( "BA013='{0}'," ,_model.BA013 );
            strSql.AppendFormat( "BA014='{0}'," ,_model.BA014 );
            strSql.AppendFormat( "BA051='{0}'," ,_model.BA051 );
            strSql.AppendFormat( "BA052='{0}'," ,_model.BA052 );
            strSql.AppendFormat( "BA053='{0}'," ,_model.BA053 );
            strSql.AppendFormat( "BA054='{0}'," ,_model.BA054 );
            strSql.AppendFormat( "BA059='{0}'," ,_model.BA059 );
            strSql.AppendFormat( "BA060='{0}'" ,_model.BA060 );
            strSql . AppendFormat ( " WHERE BA003='{1}' AND idx='{0}'" , _model . IDX , _model . BA003 );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,_model.BA003 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取乙方数据
        /// </summary>
        /// <param name="B"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfB ( string B )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT BA045,BA046,BA047,BA048 FROM R_PQBA WHERE BA044=@BA044" );
            SqlParameter[] parameter = {
                new SqlParameter("@BA044",SqlDbType.NVarChar)
            };
            parameter[0].Value = B;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取乙方数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfB ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT BA044,BA045,BA046,BA047,BA048 FROM R_PQBA" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="No"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfNum ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT PQF01,PQF02,PQF03,PQF04,PQF05,PQF06,PQF10,PQF45,PQF09 FROM R_PQF" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfNum ( string num,string oddNum )
        {
            //SELECT BA011,BA013 FROM R_PQBA WHERE idx IN (SELECT MAX(idx) idx FROM R_PQBA WHERE idx<>(SELECT MAX(idx) idx FROM R_PQBA WHERE BA053=@BA053) AND BA053=@BA053)
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT TOP 1 BA011,BA013 FROM R_PQBA WHERE BA053=@BA053 AND BA003!=@BA003 ORDER BY BA003 DESC" );
            SqlParameter[] parameter = {
                new SqlParameter("@BA053",SqlDbType.NVarChar,1000),
                new SqlParameter("@BA003",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = num;
            parameter[1].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfAll ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQBA" );
            strSql.Append( " WHERE BA003=@BA003" );
            SqlParameter[] parameter = {
                new SqlParameter("@BA003",SqlDbType.NVarChar)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrint ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT BA001,BA051,BA053,BA006,BA007,BA054,BA008,BA013,CONVERT(VARCHAR(16),BA014,102) BA014,BA054*BA013 BA,BA052 FROM R_PQBA" );
            strSql.Append( " WHERE BA003=@BA003" );
            SqlParameter[] parameter = {
                new SqlParameter("@BA003",SqlDbType.NVarChar)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrints ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DBA002,DBA028,BA044,BA045,BA046,BA047,BA048,BA015,BA016,BA017,BA018,BA019,BA020,BA021,BA022,BA023,BA024,BA025,BA026,BA027,BA028,BA029,BA030,BA031,BA032,CONVERT(NVARCHAR(16),BA033,102) BA033,BA034,CONVERT(NVARCHAR(16),BA035,102) BA035,BA036,CONVERT(NVARCHAR(16),BA037,102) BA037,BA038,CONVERT(NVARCHAR(16),BA039,102) BA039,BA040,CONVERT(NVARCHAR(16),BA041,102) BA041,BA042,CONVERT(NVARCHAR(16),BA043,102) BA043,BA005,BA004,BA057,BA003,ISNULL(BA056,0) BA056 FROM R_PQBA A LEFT JOIN TPADBA B ON A.BA002=B.DBA001" );
            strSql.Append( " WHERE BA003=@BA003" );
            SqlParameter[] parameter = {
                new SqlParameter("@BA003",SqlDbType.NVarChar)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfRecevable ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT BA001,BA056,BA058,CONVERT(DECIMAL(18,0),SUM(BA011*BA054)) BA FROM R_PQBA A" );
            strSql.Append( " INNER JOIN R_REVIEWS D ON A.BA003=D.RES06 AND RES05='执行'" );
            strSql.AppendFormat( " WHERE BA003='{0}'  AND (BA001!='' AND BA001 IS NOT NULL)" ,oddNum );
            strSql.Append( " GROUP BY BA056,BA058,BA001" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 写数据到241中
        /// </summary>
        /// <param name="modelAm"></param>
        /// <returns></returns>
        public bool UpdateOfRecevable ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum )
        {
            ArrayList SQLString = new ArrayList( );
            ByOneBy( modelAm ,oddNum ,SQLString );
            if ( modelAm.AM108 > 0 )
            {
                StringBuilder strSqlAM108 = new StringBuilder( );
                strSqlAM108.AppendFormat( "UPDATE R_PQAM SET AM108='{0}' WHERE AM002='{1}'" ,modelAm.AM108 ,modelAm.AM002 );
                SQLString.Add( strSqlAM108.ToString( ) );
            }
            if ( modelAm.AM110 > 0 )
            {
                StringBuilder strSqlAM110 = new StringBuilder( );
                strSqlAM110.AppendFormat( "UPDATE R_PQAM SET AM110='{0}' WHERE AM002='{1}'" ,modelAm.AM110 ,modelAm.AM002 );
                SQLString.Add( strSqlAM110.ToString( ) );
            }
            if ( modelAm.AM111 > 0 )
            {
                StringBuilder strSqlAM111 = new StringBuilder( );
                strSqlAM111.AppendFormat( "UPDATE R_PQAM SET AM111='{0}' WHERE AM002='{1}'" ,modelAm.AM111 ,modelAm.AM002 );
                SQLString.Add( strSqlAM111.ToString( ) );
            }
            if ( modelAm.AM115 > 0 )
            {
                StringBuilder strSqlAM115 = new StringBuilder( );
                strSqlAM115.AppendFormat( "UPDATE R_PQAM SET AM115='{0}' WHERE AM002='{1}'" ,modelAm.AM115 ,modelAm.AM002 );
                SQLString.Add( strSqlAM115.ToString( ) );
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        void ByOneBy ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum,ArrayList SQLString )
        {
            // modelAm.AM108 = modelAm.AM110 = modelAm.AM111 = modelAm.AM115 = 0M;
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "SELECT AMB108,AMB110,AMB111,AMB115 FROM R_PQAMB WHERE AMB001='{0}'" ,oddNum );

            DataTable de = SqlHelper.ExecuteDataTable( "SELECT AM108,AM110,AM111,AM115 FROM R_PQAM WHERE AM002='" + modelAm.AM002 + "'" );

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            if ( da != null && da.Rows.Count > 0 )
            {
                if ( modelAm.AM108 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB108='{0}' AND AMB001='{1}'" ,modelAm.AM108 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM110 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB110='{0}' AND AMB001='{1}'" ,modelAm.AM110 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM111 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB111='{0}' AND AMB001='{1}'" ,modelAm.AM111 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM115 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB115='{0}' AND AMB001='{1}'" ,modelAm.AM115 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
               
                if ( de != null && de.Rows.Count > 0 )
                {
                    modelAm.AM108 = modelAm.AM108 - ( string.IsNullOrEmpty( da.Rows[0]["AMB108"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB108"].ToString( ) ) );
                    modelAm.AM110 = modelAm.AM110 - ( string.IsNullOrEmpty( da.Rows[0]["AMB110"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB110"].ToString( ) ) );
                    modelAm.AM111 = modelAm.AM111 - ( string.IsNullOrEmpty( da.Rows[0]["AMB111"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB111"].ToString( ) ) );
                    modelAm.AM115 = modelAm.AM115 - ( string.IsNullOrEmpty( da.Rows[0]["AMB115"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB115"].ToString( ) ) );

                    modelAm.AM108 = modelAm.AM108 + ( string.IsNullOrEmpty( de.Rows[0]["AM108"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM108"].ToString( ) ) );
                    modelAm.AM110 = modelAm.AM110 + ( string.IsNullOrEmpty( de.Rows[0]["AM110"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM110"].ToString( ) ) );
                    modelAm.AM111 = modelAm.AM111 + ( string.IsNullOrEmpty( de.Rows[0]["AM111"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM111"].ToString( ) ) );
                    modelAm.AM115 = modelAm.AM115 + ( string.IsNullOrEmpty( de.Rows[0]["AM115"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM115"].ToString( ) ) );
                }
               
            }
            else
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "INSERT INTO R_PQAMB (AMB001,AMB108,AMB110,AMB111,AMB115) VALUES ('{0}','{1}','{2}','{3}','{4}')" ,oddNum ,modelAm.AM108 ,modelAm.AM110 ,modelAm.AM111 ,modelAm.AM115 );
                SQLString.Add( strSql.ToString( ) );

                if ( de != null && de.Rows.Count > 0 )
                {
                    modelAm.AM108 = modelAm.AM108 + ( string.IsNullOrEmpty( de.Rows[0]["AM108"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM108"].ToString( ) ) );
                    modelAm.AM110 = modelAm.AM110 + ( string.IsNullOrEmpty( de.Rows[0]["AM110"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM110"].ToString( ) ) );
                    modelAm.AM111 = modelAm.AM111 + ( string.IsNullOrEmpty( de.Rows[0]["AM111"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM111"].ToString( ) ) );
                    modelAm.AM115 = modelAm.AM115 + ( string.IsNullOrEmpty( de.Rows[0]["AM115"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM115"].ToString( ) ) );
                }
               
            }
        }
    }
}

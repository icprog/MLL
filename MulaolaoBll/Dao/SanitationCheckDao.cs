using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;
using StudentMgr;
using System . Collections;
using System . Data . SqlClient;

namespace MulaolaoBll . Dao
{
    public class SanitationCheckDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable getTableView ( string code )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT idx,SAD001,SAD002,SAD003,SAD004,SAD005,SAD006,SAD007,SAD008,SAD009 FROM R_SAD WHERE SAD001='{0}' " ,code );
            
            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取单号
        /// </summary>
        /// <returns></returns>
        public string getCode ( )
        {
            DateTime dt = generateOddNum . getTime ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(SAC001) SAC001 FROM R_SAC" );

            DataTable table = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( table == null || table . Rows . Count < 1 )
                return dt . ToString ( "yyyyMMdd" ) + "001";
            else
            {
                string code = table . Rows [ 0 ] [ "SAC001" ] . ToString ( );
                if ( code == string . Empty )
                    return dt . ToString ( "yyyyMMdd" ) + "001";
                else
                {
                    if ( code . Substring ( 0 ,8 ) . Equals ( dt . ToString ( "yyyyMMdd" ) ) )
                        return ( Convert . ToInt64 ( code ) + 1 ) . ToString ( );
                    else
                        return dt . ToString ( "yyyyMMdd" ) + "001";
                }
            }
        }
        
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Delete ( string code )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM R_SAC WHERE SAC001='{0}'" ,code );
            SQLString . Add ( strSql . ToString ( ) );
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM R_SAD WHERE SAD001='{0}'" ,code );
            SQLString . Add ( strSql . ToString ( ) );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Save ( MulaolaoLibrary.SanitationCheckHeaderEntity model,DataTable table )
        {
            Hashtable SQLString = new Hashtable ( );
            model . SAC001 = getCode ( );
            AddHeader ( SQLString ,model );

            MulaolaoLibrary . SanitationCheckBodyEntity entity = new MulaolaoLibrary . SanitationCheckBodyEntity ( );
            entity . SAD001 = model . SAC001;
            foreach ( DataRow row in table . Rows )
            {
                entity . SAD002 = row [ "SAD002" ] . ToString ( );
                entity . SAD003 = row [ "SAD003" ] . ToString ( );
                entity . SAD004 = row [ "SAD004" ] . ToString ( );
                if ( row [ "SAD005" ] == null || row [ "SAD005" ] . ToString ( ) == string . Empty )
                    entity . SAD005 = null;
                else
                    entity . SAD005 = Convert . ToInt32 ( row [ "SAD005" ] . ToString ( ) );
                if ( row [ "SAD006" ] == null || row [ "SAD006" ] . ToString ( ) == string . Empty )
                    entity . SAD006 = null;
                else
                    entity . SAD006 = Convert . ToInt32 ( row [ "SAD006" ] . ToString ( ) );
                entity . SAD007 = row [ "SAD007" ] . ToString ( );
                entity . SAD008 = row [ "SAD008" ] . ToString ( );
                entity . SAD009 = row [ "SAD009" ] . ToString ( );
                //if ( row [ "SAD019" ] == null || row [ "SAD019" ] . ToString ( ) == string . Empty )
                //    entity . SAD019 = null;
                //else
                //    entity . SAD019 = ( byte? [ ] ) ( row [ "SAD019" ] );
                AddBody ( SQLString ,entity );
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="table"></param>
        /// <param name="idxList"></param>
        /// <returns></returns>
        public bool Edit ( MulaolaoLibrary . SanitationCheckHeaderEntity model ,DataTable table ,List<string> idxList )
        {
            Hashtable SQLString = new Hashtable ( );
            EditHeader ( SQLString ,model );

            MulaolaoLibrary . SanitationCheckBodyEntity entity = new MulaolaoLibrary . SanitationCheckBodyEntity ( );
            entity . SAD001 = model . SAC001;
            foreach ( DataRow row in table . Rows )
            {
                entity . idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] );
                entity . SAD002 = row [ "SAD002" ] . ToString ( );
                entity . SAD003 = row [ "SAD003" ] . ToString ( );
                entity . SAD004 = row [ "SAD004" ] . ToString ( );
                if ( row [ "SAD005" ] == null || row [ "SAD005" ] . ToString ( ) == string . Empty )
                    entity . SAD005 = null;
                else
                    entity . SAD005 = Convert . ToInt32 ( row [ "SAD005" ] . ToString ( ) );
                if ( row [ "SAD006" ] == null || row [ "SAD006" ] . ToString ( ) == string . Empty )
                    entity . SAD006 = null;
                else
                    entity . SAD006 = Convert . ToInt32 ( row [ "SAD006" ] . ToString ( ) );
                entity . SAD007 = row [ "SAD007" ] . ToString ( );
                entity . SAD008 = row [ "SAD008" ] . ToString ( );
                entity . SAD009 = row [ "SAD009" ] . ToString ( );
                //if ( row [ "SAD019" ] == null || row [ "SAD019" ] . ToString ( ) == string . Empty )
                //    entity . SAD019 = null;
                //else
                //    entity . SAD019 = ( byte? [ ] ) ( row [ "SAD019" ] );
                if ( entity . idx > 0 )
                    EditBody ( SQLString ,entity );
                else
                    AddBody ( SQLString ,entity );
            }

            foreach ( string s in idxList )
            {
                DeleteBody ( SQLString ,s );
            }
            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void AddHeader ( Hashtable SQLString,MulaolaoLibrary . SanitationCheckHeaderEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_SAC(" );
            strSql . Append ( "SAC001,SAC002,SAC003,SAC004)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@SAC001,@SAC002,@SAC003,@SAC004)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@SAC001", SqlDbType.NVarChar,20),
                    new SqlParameter("@SAC002", SqlDbType.NVarChar,20),
                    new SqlParameter("@SAC003", SqlDbType.Date,3),
                    new SqlParameter("@SAC004", SqlDbType.Date,3)
            };
            parameters [ 0 ] . Value = model . SAC001;
            parameters [ 1 ] . Value = model . SAC002;
            parameters [ 2 ] . Value = model . SAC003;
            parameters [ 3 ] . Value = model . SAC004;
            SQLString . Add ( strSql ,parameters );
        }
        void EditHeader ( Hashtable SQLString ,MulaolaoLibrary . SanitationCheckHeaderEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "update R_SAC set " );
            strSql . Append ( "SAC002=@SAC002," );
            strSql . Append ( "SAC003=@SAC003," );
            strSql . Append ( "SAC004=@SAC004 " );
            strSql . Append ( "WHERE SAC001=@SAC001" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@SAC001", SqlDbType.NVarChar,20),
                    new SqlParameter("@SAC002", SqlDbType.NVarChar,20),
                    new SqlParameter("@SAC003", SqlDbType.Date,3),
                    new SqlParameter("@SAC004", SqlDbType.Date,3)
            };
            parameters [ 0 ] . Value = model . SAC001;
            parameters [ 1 ] . Value = model . SAC002;
            parameters [ 2 ] . Value = model . SAC003;
            parameters [ 3 ] . Value = model . SAC004;
            SQLString . Add ( strSql ,parameters );
        }

        void AddBody ( Hashtable SQLString ,MulaolaoLibrary . SanitationCheckBodyEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_SAD(" );
            strSql . Append ( "SAD001,SAD002,SAD003,SAD004,SAD005,SAD006,SAD007,SAD008,SAD009)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@SAD001,@SAD002,@SAD003,@SAD004,@SAD005,@SAD006,@SAD007,@SAD008,@SAD009)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@SAD001", SqlDbType.NVarChar,20),
                    new SqlParameter("@SAD002", SqlDbType.NVarChar,20),
                    new SqlParameter("@SAD003", SqlDbType.NVarChar,100),
                    new SqlParameter("@SAD004", SqlDbType.NVarChar,255),
                    new SqlParameter("@SAD005", SqlDbType.Int,4),
                    new SqlParameter("@SAD006", SqlDbType.Int,4),
                    new SqlParameter("@SAD007", SqlDbType.NVarChar,20),
                    new SqlParameter("@SAD008", SqlDbType.NVarChar,20),
                    new SqlParameter("@SAD009", SqlDbType.NVarChar,255)
            };
            parameters [ 0 ] . Value = model . SAD001;
            parameters [ 1 ] . Value = model . SAD002;
            parameters [ 2 ] . Value = model . SAD003;
            parameters [ 3 ] . Value = model . SAD004;
            parameters [ 4 ] . Value = model . SAD005;
            parameters [ 5 ] . Value = model . SAD006;
            parameters [ 6 ] . Value = model . SAD007;
            parameters [ 7 ] . Value = model . SAD008;
            parameters [ 8 ] . Value = model . SAD009;
            SQLString . Add ( strSql ,parameters );
        }
        void EditBody ( Hashtable SQLString ,MulaolaoLibrary . SanitationCheckBodyEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "update R_SAD set " );
            strSql . Append ( "SAD002=@SAD002," );
            strSql . Append ( "SAD003=@SAD003," );
            strSql . Append ( "SAD004=@SAD004," );
            strSql . Append ( "SAD005=@SAD005," );
            strSql . Append ( "SAD006=@SAD006," );
            strSql . Append ( "SAD007=@SAD007," );
            strSql . Append ( "SAD008=@SAD008," );
            strSql . Append ( "SAD009=@SAD009" );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@SAD002", SqlDbType.NVarChar,20),
                    new SqlParameter("@SAD003", SqlDbType.NVarChar,100),
                    new SqlParameter("@SAD004", SqlDbType.NVarChar,255),
                    new SqlParameter("@SAD005", SqlDbType.Int,4),
                    new SqlParameter("@SAD006", SqlDbType.Int,4),
                    new SqlParameter("@SAD007", SqlDbType.NVarChar,20),
                    new SqlParameter("@SAD008", SqlDbType.NVarChar,20),
                    new SqlParameter("@SAD009", SqlDbType.NVarChar,255),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . SAD002;
            parameters [ 1 ] . Value = model . SAD003;
            parameters [ 2 ] . Value = model . SAD004;
            parameters [ 3 ] . Value = model . SAD005;
            parameters [ 4 ] . Value = model . SAD006;
            parameters [ 5 ] . Value = model . SAD007;
            parameters [ 6 ] . Value = model . SAD008;
            parameters [ 7 ] . Value = model . SAD009;
            parameters [ 8 ] . Value = model . idx;
            SQLString . Add ( strSql ,parameters );
        }
        void DeleteBody ( Hashtable SQLString ,string s)
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM R_SAD WHERE idx={0}" ,s );
            SQLString . Add ( strSql ,null );
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public DataTable getTableQuery ( string code )
        {
            StringBuilder strSql = new StringBuilder ( );
            if ( code == string . Empty )
                strSql . Append ( "SELECT SAC001,SAC002,SAC003,SAC004 FROM R_SAC ORDER BY SAC001" );
            else
                strSql . AppendFormat ( "SELECT SAC001,SAC002,SAC003,SAC004 FROM R_SAC WHERE SAC001='{0}' ORDER BY SAC001" ,code );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取车间
        /// </summary>
        /// <returns></returns>
        public DataTable getTableWork ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DAA002 FROM TPADAA WHERE DAA001 LIKE '08%' AND LEN(DAA001)=4" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取组长
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable getTableGroup (  )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DAA001,DAA002 FROM TPADAA WHERE DAA001 LIKE '08%' AND LEN(DAA001)>4"  );
            
            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取看板
        /// </summary>
        /// <returns></returns>
        public DataTable getTableAll ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DECLARE @SQL NVARCHAR(MAX);" );
            strSql . Append ( "SELECT @SQL=ISNULL(@SQL+',','')+QUOTENAME(SAD008) FROM R_SAD GROUP BY SAD008;" );
            strSql . Append ( "DECLARE @STR NVARCHAR(MAX) " );
            strSql . Append ( "SET @STR='SELECT * FROM (SELECT SAD002 检查区域,SAD003 检查项目,SAD004 现场检查内容,SAD005 评分标准,SAD006,SAD007 车间,SAD008,SAD009 现在及存在问题描述 FROM R_SAD) A PIVOT(MAX(SAD006) FOR SAD008 IN('+@SQL+')) AS T' " );
            strSql . Append ( "EXEC(@STR)" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}

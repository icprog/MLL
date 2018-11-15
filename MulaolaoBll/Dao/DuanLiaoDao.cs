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
    public class DuanLiaoDao
    {
        /// <summary>
        /// 查询流水号
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableNum ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT PQF01,PQF02,PQF03,PQF04,PQF06 FROM R_PQF A INNER JOIN R_REVIEWS B ON A.PQF01=B.RES06 AND RES05='执行'" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 是否执行
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool GetDataTableReviews (string tableName,string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_REVIEWS" );
            strSql.Append( " WHERE RES01=@RES01 AND RES06=@RES06 AND RES05='执行'" );
            SqlParameter[] parameter = {
                new SqlParameter("@RES01",SqlDbType.NVarChar),
                new SqlParameter("@RES06",SqlDbType.NVarChar)
            };
            parameter[0].Value = tableName;
            parameter[1].Value = oddNum;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteAll (string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQIZ" );
            strSql.AppendFormat( " WHERE IZ001='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            StringBuilder strS = new StringBuilder( );
            strS.Append( "DELETE FROM R_REVIEWS" );
            strS.AppendFormat( " WHERE RES01='R_505' AND RES06='{0}'" ,oddNum );
            SQLString.Add( strS.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );
            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Insert ( MulaolaoLibrary.DuanLiaoLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQIZ (" );
            strSql.Append( "IZ001,IZ005,IZ008,IZ009,IZ010,IZ011,IZ012,IZ013,IZ014,IZ015,IZ016,IZ017,IZ018,IZ019,IZ020,IZ021,IZ022)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}')" ,model.IZ001 ,model.IZ005 ,model.IZ008 ,model.IZ009 ,model.IZ010 ,model.IZ011 ,model.IZ012 ,model.IZ013 ,model.IZ014 ,model.IZ015 ,model.IZ016 ,model.IZ017 ,model.IZ018 ,model.IZ019 ,model.IZ020 ,model.IZ021 ,model.IZ022 );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.IZ001 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );
            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.DuanLiaoLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQIZ SET " );
            strSql.AppendFormat( "IZ005='{0}'," ,model.IZ005 );
            strSql.AppendFormat( "IZ008='{0}'," ,model.IZ008 );
            strSql.AppendFormat( "IZ009='{0}'," ,model.IZ009 );
            strSql.AppendFormat( "IZ010='{0}'," ,model.IZ010 );
            strSql.AppendFormat( "IZ011='{0}'," ,model.IZ011 );
            strSql.AppendFormat( "IZ012='{0}'," ,model.IZ012 );
            strSql.AppendFormat( "IZ013='{0}'," ,model.IZ013 );
            strSql.AppendFormat( "IZ014='{0}'," ,model.IZ014 );
            strSql.AppendFormat( "IZ015='{0}'," ,model.IZ015 );
            strSql.AppendFormat( "IZ016='{0}'," ,model.IZ016 );
            strSql.AppendFormat( "IZ017='{0}'," ,model.IZ017 );
            strSql.AppendFormat( "IZ018='{0}'," ,model.IZ018 );
            strSql.AppendFormat( "IZ019='{0}'," ,model.IZ019 );
            strSql.AppendFormat( "IZ020='{0}'," ,model.IZ020 );
            strSql.AppendFormat( "IZ021='{0}'," ,model.IZ021 );
            strSql.AppendFormat( "IZ022='{0}'" ,model.IZ022 );
            strSql . AppendFormat ( " WHERE IZ001='{1}' AND idx='{0}'" , model . IDX , model . IZ001 );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.IZ001 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd ,string oddNum )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQIZ " );
            strSql . AppendFormat ( " WHERE IZ001='{1}' AND idx={0}" , idx , oddNum );
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
            strSql.Append( "SELECT idx,IZ005,IZ008,IZ009,IZ010,IZ011,IZ012,IZ013,IZ014,IZ015,IZ016,IZ017,IZ018,IZ019,IZ020,IZ021,IZ022 FROM R_PQIZ" );
            strSql.Append( " WHERE " + strWhere );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MulaolaoLibrary.DuanLiaoLibrary GetModel ( int id )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQIZ" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = id;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da != null && da.Rows.Count > 0 )
                return GetDataRow( da.Rows[0] );
            else
                return null;
        }
        public MulaolaoLibrary.DuanLiaoLibrary GetModel ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQIZ" );
            strSql.Append( " WHERE IZ001=@IZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@IZ001",SqlDbType.NVarChar)
            };
            parameter[0].Value = oddNum;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da != null && da.Rows.Count > 0 )
                return GetDataRow( da.Rows[0] );
            else
                return null;
        }

        /// <summary>
        /// 获取数据实体对象
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.DuanLiaoLibrary GetDataRow ( DataRow row )
        {
            MulaolaoLibrary.DuanLiaoLibrary model = new MulaolaoLibrary.DuanLiaoLibrary( );

            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    model.IDX = int.Parse( row["idx"].ToString( ) );
                if ( row["IZ001"] != null && row["IZ001"].ToString( ) != "" )
                    model.IZ001 = row["IZ001"].ToString( );
                if ( row["IZ002"] != null && row["IZ002"].ToString( ) != "" )
                    model.IZ002 = row["IZ002"].ToString( );
                if ( row["IZ003"] != null && row["IZ003"].ToString( ) != "" )
                    model.IZ003 = row["IZ003"].ToString( );
                if ( row["IZ004"] != null && row["IZ004"].ToString( ) != "" )
                    model.IZ004 = row["IZ004"].ToString( );
                if ( row["IZ005"] != null && row["IZ005"].ToString( ) != "" )
                    model.IZ005 = long.Parse( row["IZ005"].ToString( ) );
                if ( row["IZ006"] != null && row["IZ006"].ToString( ) != "" )
                    model.IZ006 = row["IZ006"].ToString( );
                if ( row["IZ007"] != null && row["IZ007"].ToString( ) != "" )
                    model.IZ007 = row["IZ007"].ToString( );
                if ( row["IZ008"] != null && row["IZ008"].ToString( ) != "" )
                    model.IZ008 = row["IZ008"].ToString( );
                if ( row["IZ009"] != null && row["IZ009"].ToString( ) != "" )
                    model.IZ009 = row["IZ009"].ToString( );
                if ( row["IZ010"] != null && row["IZ010"].ToString( ) != "" )
                    model.IZ010 = row["IZ010"].ToString( );
                if ( row["IZ011"] != null && row["IZ011"].ToString( ) != "" )
                    model.IZ011 = int.Parse( row["IZ011"].ToString( ) );
                if ( row["IZ012"] != null && row["IZ012"].ToString( ) != "" )
                    model.IZ012 = row["IZ012"].ToString( );
                if ( row["IZ013"] != null && row["IZ013"].ToString( ) != "" )
                    model.IZ013 = decimal.Parse( row["IZ013"].ToString( ) );
                if ( row["IZ014"] != null && row["IZ014"].ToString( ) != "" )
                    model.IZ014 = decimal.Parse( row["IZ014"].ToString( ) );
                if ( row["IZ015"] != null && row["IZ015"].ToString( ) != "" )
                    model.IZ015 = decimal.Parse( row["IZ015"].ToString( ) );
                if ( row["IZ016"] != null && row["IZ016"].ToString( ) != "" )
                    model.IZ016 = decimal.Parse( row["IZ016"].ToString( ) );
                if ( row["IZ017"] != null && row["IZ017"].ToString( ) != "" )
                    model.IZ017 = DateTime.Parse( row["IZ017"].ToString( ) );
                if ( row["IZ018"] != null && row["IZ018"].ToString( ) != "" )
                    model.IZ018 = DateTime.Parse( row["IZ018"].ToString( ) );
                if ( row["IZ019"] != null && row["IZ019"].ToString( ) != "" )
                    model.IZ019 = decimal.Parse( row["IZ019"].ToString( ) );
                if ( row["IZ020"] != null && row["IZ020"].ToString( ) != "" )
                    model.IZ020 = decimal.Parse( row["IZ020"].ToString( ) );
                if ( row["IZ021"] != null && row["IZ021"].ToString( ) != "" )
                    model.IZ021 = decimal.Parse( row["IZ021"].ToString( ) );
                if ( row["IZ022"] != null && row["IZ022"].ToString( ) != "" )
                    model.IZ022 = int.Parse( row["IZ022"].ToString( ) );
                if ( row["IZ023"] != null && row["IZ023"].ToString( ) != "" )
                    model.IZ023 = row["IZ023"].ToString( );
                if ( row["IZ024"] != null && row["IZ024"].ToString( ) != "" )
                    model.IZ024 = row["IZ024"].ToString( );
                if ( row["IZ025"] != null && row["IZ025"].ToString( ) != "" )
                    model.IZ025 = DateTime.Parse( row["IZ025"].ToString( ) );
                if ( row["IZ026"] != null && row["IZ026"].ToString( ) != "" )
                    model.IZ026 = row["IZ026"].ToString( );
                if ( row["IZ027"] != null && row["IZ027"].ToString( ) != "" )
                    model.IZ027 = DateTime.Parse( row["IZ027"].ToString( ) );
                if ( row["IZ028"] != null && row["IZ028"].ToString( ) != "" )
                    model.IZ028 = row["IZ028"].ToString( );
                if ( row["IZ029"] != null && row["IZ029"].ToString( ) != "" )
                    model.IZ029 = DateTime.Parse( row["IZ029"].ToString( ) );
                if ( row["IZ030"] != null && row["IZ030"].ToString( ) != "" )
                    model.IZ030 = row["IZ030"].ToString( );
                if ( row["IZ031"] != null && row["IZ031"].ToString( ) != "" )
                    model.IZ031 = DateTime.Parse( row["IZ031"].ToString( ) );
                if ( row["IZ032"] != null && row["IZ032"].ToString( ) != "" )
                    model.IZ032 = row["IZ032"].ToString( );
                if ( row["IZ033"] != null && row["IZ033"].ToString( ) != "" )
                    model.IZ033 = row["IZ033"].ToString( );
                if ( row["IZ034"] != null && row["IZ034"].ToString( ) != "" )
                    model.IZ034 = row["IZ034"].ToString( );
                if ( row["IZ035"] != null && row["IZ035"].ToString( ) != "" )
                    model.IZ035 = row["IZ035"].ToString( );
            }

            return model;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT IZ001,IZ002,IZ003,IZ004,IZ034 FROM R_PQIZ" );

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
            strSql.Append( "SELECT COUNT(1) FROM (SELECT DISTINCT idx FROM R_PQIZ" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( " ) A" );

            object obj= SqlHelper.GetSingle( strSql.ToString( ) );
            if ( obj == null )
                return 0;
            else
                return Convert.ToInt32( obj );
        }
        public int GetCountAll ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM (SELECT DISTINCT A.idx FROM R_PQIZ A,R_REVIEWS B WHERE A.IZ001=B.RES06 AND RES05='执行'" );
            strSql.Append( " AND " + strWhere );
            strSql.Append( " ) C" );

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
            strSql.Append( "SELECT DISTINCT idx,IZ001,IZ002,IZ003,IZ004,IZ005,IZ034,IZ008,IZ009,IZ013,IZ014,IZ015,IZ035,CASE WHEN IZ021=0 THEN 0 ELSE (IZ005*IZ022/IZ021)*(IZ013*(IZ014+IZ015)*2*IZ016) END U0,(SELECT RES05 FROM R_REVIEWS WHERE RES04=(SELECT MAX(RES04) FROM R_REVIEWS WHERE RES06=IZ001)) RES05,IZ038 FROM (" );
            strSql.Append( "SELECT ROW_NUMBER() OVER( " );
            strSql.Append( "ORDER BY T.IZ001 DESC" );
            strSql.Append( ") AS Row,T.* FROM R_PQIZ T" );
            strSql.Append( " WHERE " + strWhere );
            strSql.AppendFormat( " ) TT WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );
             
            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableByChangeAll ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT TT.idx,IZ001,IZ002,IZ003,IZ004,IZ005,IZ034,IZ008,IZ009,IZ013,IZ014,IZ015,IZ035,CASE WHEN IZ021=0 THEN 0 ELSE (IZ005*IZ022/IZ021)*(IZ013*(IZ014+IZ015)*2*IZ016) END U0,RES05,IZ038 FROM (" );
            strSql.Append( "SELECT ROW_NUMBER() OVER( " );
            strSql.Append( "ORDER BY T.IZ001 DESC" );
            strSql.Append( ") AS Row,T.* FROM R_PQIZ T" );
            strSql.Append( " WHERE " + strWhere );
            strSql.AppendFormat( " ) TT,R_REVIEWS B WHERE TT.IZ001=B.RES06 AND B.RES05='执行' AND NOT EXISTS (SELECT 1 FROM R_PQAL C,R_PQAK D WHERE TT.idx=C.AL003 AND TT.IZ001=C.AL002 AND C.AL001=D.idx AND (AK009-AK010-AK011-AK015)<=100) AND TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );//AND AK009=AK011

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableMain ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT IZ033 FROM R_PQIZ" );
            strSql.Append( " WHERE IZ001=@IZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@IZ001",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        public DataTable GetDataTableNoMain ( string oddNum,string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT IZ008,IZ009,IZ010 FROM R_PQIZ" );
            strSql.Append( " WHERE IZ001!=@IZ001 AND IZ002=@IZ002" );
            SqlParameter[] parameter = {
                new SqlParameter("@IZ001",SqlDbType.NVarChar),
                new SqlParameter("@IZ002",SqlDbType.NVarChar)
            };
            parameter[0].Value = oddNum;
            parameter[1].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 编辑记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateMain ( MulaolaoLibrary.DuanLiaoLibrary model,string tableNum,string tableName,string logins,DateTime dtOne,string stateOf,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQIZ SET " );
            strSql.AppendFormat( "IZ002='{0}',",model.IZ002 );
            strSql.AppendFormat( "IZ003='{0}'," ,model.IZ003 );
            strSql.AppendFormat( "IZ004='{0}'," ,model.IZ004 );
            strSql.AppendFormat( "IZ005='{0}'," ,model.IZ005 );
            strSql.AppendFormat( "IZ006='{0}'," ,model.IZ006 );
            strSql.AppendFormat( "IZ007='{0}'," ,model.IZ007 );
            strSql.AppendFormat( "IZ023='{0}'," ,model.IZ023 );
            strSql.AppendFormat( "IZ024='{0}'," ,model.IZ024 );
            strSql.AppendFormat( "IZ025='{0}'," ,model.IZ025 );
            strSql.AppendFormat( "IZ026='{0}'," ,model.IZ026 );
            strSql.AppendFormat( "IZ027='{0}'," ,model.IZ027 );
            strSql.AppendFormat( "IZ028='{0}'," ,model.IZ028 );
            strSql.AppendFormat( "IZ029='{0}'," ,model.IZ029 );
            strSql.AppendFormat( "IZ030='{0}'," ,model.IZ030 );
            strSql.AppendFormat( "IZ031='{0}'," ,model.IZ031 );
            strSql.AppendFormat( "IZ032='{0}'," ,model.IZ032 );
            strSql.AppendFormat( "IZ033='{0}'," ,model.IZ033 );
            strSql.AppendFormat( "IZ034='{0}'," ,model.IZ034 );
            strSql.AppendFormat( "IZ035='{0}'" ,model.IZ035 );
            strSql.AppendFormat( " WHERE IZ001='{0}'" ,model.IZ001 );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.IZ001 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 复制一条记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Copy ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQIZ (IZ002,IZ003,IZ004,IZ005,IZ008,IZ009,IZ010,IZ011,IZ012,IZ013,IZ014,IZ015,IZ016,IZ018,IZ019,IZ020,IZ021,IZ022,IZ034)" );
            strSql.Append( " SELECT IZ002,IZ003,IZ004,IZ005,IZ008,IZ009,IZ010,IZ011,IZ012,IZ013,IZ014,IZ015,IZ016,IZ018,IZ019,IZ020,IZ021,IZ022,IZ034 FROM R_PQIZ" );
            strSql.AppendFormat( " WHERE IZ001='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        public bool CopyUpdate ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQIZ SET " );
            strSql.AppendFormat( " IZ001='{0}',IZ017=DATEADD(DAY,5,GETDATE()) WHERE IZ001 IS NULL" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 删出复制记录
        /// </summary>
        /// <returns></returns>
        public bool deleteCopy ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQIZ WHERE IZ001 IS NULL" );

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 是否存在记录ss
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsEdit ( MulaolaoLibrary.DuanLiaoLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQIZ" );
            strSql.Append( " WHERE IZ002=@IZ002 AND IZ008=@IZ008 AND IZ009=@IZ009 AND IZ010=@IZ010" );
            SqlParameter[] parameter = {
                new SqlParameter("@IZ002",SqlDbType.NVarChar,20),
                new SqlParameter("@IZ008",SqlDbType.NVarChar,20),
                new SqlParameter("@IZ009",SqlDbType.NVarChar,20),
                new SqlParameter("@IZ010",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = model.IZ002;
            parameter[1].Value = model.IZ008;
            parameter[2].Value = model.IZ009;
            parameter[3].Value = model.IZ010;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrint (string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT IZ005,IZ008,IZ009,IZ010,IZ011,IZ012,IZ013,IZ014,IZ015,IZ016,CONVERT(varchar(20),IZ017,102) IZ017,CONVERT(varchar(20),IZ018,102) IZ018,IZ019,CONVERT(DECIMAL(5,1),IZ020) IZ020,CONVERT(DECIMAL(4,0),IZ021) IZ021,IZ022,CASE WHEN IZ013=0 THEN 0 WHEN IZ016=0 THEN 0 ELSE CONVERT(DECIMAL(10,0),IZ011/(IZ013*(IZ014+IZ015)*2*IZ016)) END U0,CONVERT(DECIMAL(10,1),IZ013*(IZ014+IZ015)*2) U12,CASE WHEN IZ021=0 THEN 0 ELSE CONVERT(BIGINT,IZ005*IZ022/IZ021) END U13,CONVERT(DECIMAL(10,3),IZ013*(IZ014+IZ015)*2*IZ016) U14,CASE WHEN IZ021=0 THEN 0 WHEN IZ013=0 THEN 0 WHEN IZ016=0 THEN 0 ELSE IZ005*IZ022/IZ021*(IZ013*(IZ014+IZ015)*2*IZ016) END U15,CASE WHEN IZ021=0 THEN 0 ELSE IZ005*IZ022*(IZ013*(IZ014+IZ015)*2*IZ016/IZ021) END U16,CONVERT(DECIMAL(10,0),IZ020*IZ014*IZ015*IZ022*IZ005*0.000001*IZ019) U21,CONVERT(DECIMAL(10,0),IZ020*IZ014*IZ015*IZ022*IZ005*0.000001) U22,CONVERT(DECIMAL(10,1),IZ020*IZ021) U26,CASE WHEN IZ013=0 THEN 0 ELSE CONVERT(DECIMAL(18,2),IZ020*IZ021/IZ013) END U27,CASE WHEN IZ019=0 THEN 0 ELSE CONVERT(DECIMAL(18,2),1/IZ019) END U28,CONVERT(DECIMAL(10,0),IZ005*IZ022) U29,CASE WHEN IZ021=0 THEN 0 ELSE CONVERT(DECIMAL(10,4),IZ013*(IZ014+IZ015)*2*IZ016/IZ021) END U31,CASE WHEN IZ021=0 THEN 0 ELSE CONVERT(DECIMAL(10,4),IZ022*(IZ013*(IZ014+IZ015)*2*IZ016)/IZ021) END U32 FROM R_PQIZ" );
            strSql.Append( " WHERE IZ001=@IZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@IZ001",SqlDbType.NVarChar)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        public DataTable GetDataTablePrints ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT IZ002,IZ003,IZ004,IZ007,IZ023,IZ024,CONVERT(varchar(20),IZ025,102) IZ025,IZ026,CONVERT(varchar(20),IZ027,102) IZ027,IZ028,CONVERT(varchar(20),IZ029,102) IZ029,IZ030,CONVERT(varchar(20),IZ031,102) IZ031,IZ034,IZ035,IZ001 FROM R_PQIZ" );
            strSql.Append( " WHERE IZ001=@IZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@IZ001",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsOf ( MulaolaoLibrary . DuanLiaoLibrary model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM R_PQIZ" );
            strSql . Append ( " WHERE IZ002=@IZ002 AND IZ008=@IZ008 AND IZ013=@IZ013 AND IZ014=@IZ014 AND IZ015=@IZ015 AND IZ006=@IZ006" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@IZ002",SqlDbType.NVarChar),
                new SqlParameter("@IZ008",SqlDbType.NVarChar),
                new SqlParameter("@IZ013",SqlDbType.Decimal),
                new SqlParameter("@IZ014",SqlDbType.Decimal),
                new SqlParameter("@IZ015",SqlDbType.Decimal),
                new SqlParameter("@IZ006",SqlDbType.NVarChar)
            };
            parameter [ 0 ] . Value = model . IZ002;
            parameter [ 1 ] . Value = model . IZ008;
            parameter [ 2 ] . Value = model . IZ013;
            parameter [ 3 ] . Value = model . IZ014;
            parameter [ 4 ] . Value = model . IZ015;
            parameter [ 5 ] . Value = model . IZ006;

            return SqlHelper . Exists ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 获取承揽人
        /// </summary>
        /// <returns></returns>
        public DataTable GetTableOfCl ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT IZ035 FROM R_PQIZ" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfReceviable (string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT IZ002,'夹料' AH,SUM(CASE WHEN IZ021=0 THEN 0 ELSE CONVERT(DECIMAL(18,2),(IZ005*IZ022/IZ021)*(IZ013*(IZ014+IZ015)*2*IZ016)) END) U0  FROM R_PQIZ A LEFT JOIN R_REVIEWS D ON A.IZ001=D.RES06 AND RES05='执行'" );
            strSql.AppendFormat( " WHERE IZ001='{0}' AND (IZ002!='' AND IZ002 IS NOT NULL) GROUP BY IZ002" ,oddNum );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 写数据到241
        /// </summary>
        /// <param name="modelAm"></param>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateOfReceivable ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum )
        {
            ArrayList SQLString = new ArrayList( );
            ByOneBy( modelAm ,oddNum ,SQLString );
            StringBuilder strSql = new StringBuilder( );
            if ( modelAm.AM074 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM074='{0}' WHERE AM002='{1}'" ,modelAm.AM074 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        void ByOneBy ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "SELECT AMB074 FROM R_PQAMB WHERE AMB001='{0}'" ,oddNum );
            DataTable de = SqlHelper.ExecuteDataTable( "SELECT AM074 FROM R_PQAM WHERE AM002='" + modelAm.AM002 + "'" );
            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            if ( da != null && da.Rows.Count > 0 )
            {
                if ( modelAm.AM074 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB074='{0}' WHERE AMB001='{1}'" ,modelAm.AM074 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }

                if ( de != null && de.Rows.Count > 0 )
                {
                    modelAm.AM074 = modelAm.AM074 - ( string.IsNullOrEmpty( da.Rows[0]["AMB074"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB074"].ToString( ) ) );
                    modelAm.AM074 = modelAm.AM074 + ( string.IsNullOrEmpty( de.Rows[0]["AM074"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM074"].ToString( ) ) );
                }
               
            }
            else
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( " INSERT INTO R_PQAMB (AMB001,AMB074) VALUES ('{0}','{1}')" ,oddNum ,modelAm.AM074 );
                SQLString.Add( strSql.ToString( ) );
                if ( de != null && de.Rows.Count > 0 )
                    modelAm.AM074 = modelAm.AM074 + ( string.IsNullOrEmpty( de.Rows[0]["AM074"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM074"].ToString( ) ) );
               
            }
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable getTable ( string num )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT GS07,GS08 FROM R_PQP WHERE GS01='{0}' AND GS07 IS NOT NULL" ,num );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }


    }
}

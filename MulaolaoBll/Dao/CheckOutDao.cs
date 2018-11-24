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
    public class CheckOutDao
    {
        #region BasicMethod
        
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Exists ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQAK" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@idx",SqlDbType.BigInt)
            };
            parameter[0].Value = idx;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsModel ( MulaolaoLibrary.CheckOutLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQAL" );
            strSql.Append( " WHERE AL002=@AL002 AND AL003=@AL003" );
            SqlParameter[] parameter = {
                new SqlParameter("@AL002",SqlDbType.NVarChar,20),
                new SqlParameter("@AL003",SqlDbType.Int)
            };
            parameter[0].Value = model.AK003;
            parameter[1].Value = model.IdxContract;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsAll ( MulaolaoLibrary . CheckOutLibrary model )
        {
            StringBuilder strSql=new StringBuilder();
            //AND AK016 = @AK016   AND AK013 = @AK013   AND AK012 = @AK012
            strSql . Append ( "SELECT COUNT(1) FROM R_PQAK WHERE AK001=@AK001 AND AK002=@AK002 AND AK006=@AK006 AND AK004=@AK004 AND AK005=@AK005 AND AK007=@AK007 AND AK008=@AK008 AND AK009=@AK009 AND AK010 =@AK010 AND AK015 =@AK015 AND AK011 = @AK011 AND AK013 = @AK013  AND AK012 = @AK012 AND AK017 = @AK017" );
            SqlParameter[] parameter= { 
            new SqlParameter("@AK001",SqlDbType.NVarChar,30),
            new SqlParameter("@AK002",SqlDbType.NVarChar),
            new SqlParameter("@AK004",SqlDbType.NVarChar),
            new SqlParameter("@AK005",SqlDbType.NVarChar),
            new SqlParameter("@AK006",SqlDbType.NVarChar),
            new SqlParameter("@AK007",SqlDbType.BigInt),
            new SqlParameter("@AK008",SqlDbType.NVarChar),
            new SqlParameter("@AK009",SqlDbType.Decimal,11),
            new SqlParameter("@AK010",SqlDbType.BigInt),
            new SqlParameter("@AK011",SqlDbType.Decimal,11),
            new SqlParameter("@AK012",SqlDbType.Date),
            new SqlParameter("@AK013",SqlDbType.NVarChar,255),
            new SqlParameter("@AK015",SqlDbType.Decimal,11),
            //new SqlParameter("@AK016",SqlDbType.Date),
            new SqlParameter("@AK017",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = model . AK001; 
            parameter [ 1 ] . Value = model . AK002; 
            parameter [ 2 ] . Value = model . AK004;
            parameter [ 3 ] . Value = model . AK005;
            parameter [ 4 ] . Value = model . AK006;
            parameter [ 5 ] . Value = model . AK007;
            parameter [ 6 ] . Value = model . AK008;
            parameter [ 7 ] . Value = model . AK009;
            parameter [ 8 ] . Value = model . AK010;
            parameter [ 9 ] . Value = model . AK011;
            parameter [ 10 ] . Value = model . AK012;
            parameter [ 11 ] . Value = model . AK013;
            parameter [ 12 ] . Value = model . AK015;
            //parameter [ 13 ] . Value = model . AK016;
            parameter [ 13 ] . Value = model . AK017;

            return SqlHelper . Exists ( strSql . ToString ( ) , parameter );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add ( MulaolaoLibrary.CheckOutLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfState )
        {
            int idx = 0;
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAK (" );
            strSql.Append( "AK014,AK001,AK002,AK003,AK004,AK005,AK006,AK007,AK008,AK009,AK010,AK011,AK012,AK013,AK015,AK017)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}');",model.AK014 ,model.AK001 ,model.AK002 ,model.AK003 ,model.AK004 ,model.AK005 ,model.AK006 ,model.AK007 ,model.AK008 ,model.AK009 ,model.AK010 ,model.AK011 ,model.AK012 ,model.AK013 ,model.AK015 ,model.AK017 );
            strSql.Append( "SELECT SCOPE_IDENTITY();" );
            idx = SqlHelper.ExecuteSqlReturnId( strSql.ToString( ) );
            if ( idx > 0 )
            {
                try
                {
                    SqlHelper.ExecuteNonQuery( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.AK014 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfState ) );
                }
                catch { }
            }
            return idx;
        }

        /// <summary>
        /// 增加一条记录到R_PQAL表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddAl ( MulaolaoLibrary.CheckOutLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfState )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAL (" );
            strSql.Append( "AL001,AL002,AL003)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}')" ,model.Idx ,model.AK003 ,model.IdxContract );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.AK014 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfState ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.CheckOutLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfState )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAK SET " );
            strSql.AppendFormat( "AK001='{0}'," ,model.AK001 );
            strSql.AppendFormat( "AK002='{0}'," ,model.AK002 );
            strSql.AppendFormat( "AK003='{0}'," ,model.AK003 );
            strSql.AppendFormat( "AK004='{0}'," ,model.AK004 );
            strSql.AppendFormat( "AK005='{0}'," ,model.AK005 );
            strSql.AppendFormat( "AK006='{0}'," ,model.AK006 );
            strSql.AppendFormat( "AK007='{0}'," ,model.AK007 );
            strSql.AppendFormat( "AK008='{0}'," ,model.AK008 );
            strSql.AppendFormat( "AK009='{0}'," ,model.AK009 );
            strSql.AppendFormat( "AK010='{0}'," ,model.AK010 );
            strSql.AppendFormat( "AK011='{0}'," ,model.AK011 );
            strSql.AppendFormat( "AK012='{0}'," ,model.AK012 );
            strSql.AppendFormat( "AK013='{0}'," ,model.AK013 );
            //strSql.AppendFormat( "AK014='{0}'," ,model.AK014 );
            strSql.AppendFormat( "AK015='{0}'," ,model.AK015 );
            strSql.AppendFormat( "AK017='{0}'" ,model.AK017 );
            strSql.AppendFormat( " WHERE idx='{0}'" ,model.Idx );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.AK014 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfState ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }


        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete ( MulaolaoLibrary.CheckOutLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfState )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "DELETE FROM R_PQAK WHERE idx='{0}'",model.Idx );
            StringBuilder strS = new StringBuilder( );
            strS.AppendFormat( "DELETE FROM R_PQAL WHERE AL001='{0}'",model.Idx );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( strS.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.AK014 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfState ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.AK014 ,strS.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfState ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }


        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteAl ( MulaolaoLibrary.CheckOutLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfState )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "DELETE FROM R_PQAL WHERE AL001='{0}' " ,model.Idx );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.AK014 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfState ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }


        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="idlist"></param>
        /// <returns></returns>
        public bool DeleteList ( string idlist ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfState ,string oddNum )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQAK " );
            strSql.Append( "WHERE idx in (" + idlist + ")" );
            SQLString.Add( strSql.ToString( ) );
            StringBuilder strSq = new StringBuilder( );
            strSq.Append( "DELETE FROM R_PQAL" );
            strSq.Append( " WHERE AL001 IN (" + idlist + ")" );
            SQLString.Add( strSq.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfState ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSq.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfState ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }


        public void DeleteListAll ( string idlist )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQAL" );
            strSql.Append( " WHERE AL001 IN (" + idlist + ")" );
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.CheckOutLibrary GetMode ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,AK001,AK002,AK003,AK004,AK005,AK006,AK007,AK008,AK009,AK010,AK011,AK012,AK013,AK014,AK015,AK017 FROM R_PQAK" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] paramete = {
                new SqlParameter("@idx",SqlDbType.Int)
            };
            paramete[0].Value = idx;

            DataTable ds = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,paramete );
            if ( ds.Rows.Count > 0 )
                return DataRowModel( ds.Rows[0] );
            else
                return null;
        }

        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.CheckOutLibrary DataRowModel ( DataRow row )
        {
            MulaolaoLibrary.CheckOutLibrary model = new MulaolaoLibrary.CheckOutLibrary( );
            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    model.Idx = int.Parse( row["idx"].ToString( ) );
                if ( row["AK001"] != null && row["AK001"].ToString( ) != "" )
                    model.AK001 = row["AK001"].ToString( );
                if ( row["AK002"] != null && row["AK002"].ToString( ) != "" )
                    model.AK002 = row["AK002"].ToString( );
                if ( row["AK003"] != null && row["AK003"].ToString( ) != "" )
                    model.AK003 = row["AK003"].ToString( );
                if ( row["AK004"] != null && row["AK004"].ToString( ) != "" )
                    model.AK004 = row["AK004"].ToString( );
                if ( row["AK005"] != null && row["AK005"].ToString( ) != "" )
                    model.AK005 = row["AK005"].ToString( );
                if ( row["AK006"] != null && row["AK006"].ToString( ) != "" )
                    model.AK006 = row["AK006"].ToString( );
                if ( row["AK007"] != null && row["AK007"].ToString( ) != "" )
                    model.AK007 = long.Parse( row["AK007"].ToString( ) );
                if ( row["AK008"] != null && row["AK008"].ToString( ) != "" )
                    model.AK008 = row["AK008"].ToString( );
                if ( row["AK009"] != null && row["AK009"].ToString( ) != "" )
                    model.AK009 = decimal.Parse( row["AK009"].ToString( ) );
                if ( row["AK010"] != null && row["AK010"].ToString( ) != "" )
                    model.AK010 = decimal.Parse( row["AK010"].ToString( ) );
                if ( row["AK011"] != null && row["AK011"].ToString( ) != "" )
                    model.AK011 = decimal.Parse( row["AK011"].ToString( ) );
                if ( row["AK012"] != null && row["AK012"].ToString( ) != "" )
                    model.AK012 = DateTime.Parse( row["AK012"].ToString( ) );
                if ( row["AK013"] != null && row["AK013"].ToString( ) != "" )
                    model.AK013 = row["AK013"].ToString( );
                if ( row["AK014"] != null && row["AK014"].ToString( ) != "" )
                    model.AK014 = row["AK014"].ToString( );
                if ( row["AK015"] != null && row["AK015"].ToString( ) != "" )
                    model.AK015 = decimal.Parse( row["AK015"].ToString( ) );
                if ( row["AK017"] != null && row["AK017"].ToString( ) != "" )
                    model.AK017 = row["AK017"].ToString( );
            }

            return model;
        }


        /// <summary>
        /// 得到一个实体对象  单个字段
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnly (  )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT AK001,AK002,AK004,AK005,AK006,AK014,SUBSTRING(AK002,1,2) AK" );
            strSql.Append( " FROM R_PQAK" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetList ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQAK B" );
            if ( strWhere.Trim( ) != "" )
                strSql.Append( " WHERE " + strWhere );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCheckOutCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQAK" );
            if ( strWhere.Trim( ) != "" )
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
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetListByPage ( string strWhere ,string orderby ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM ( " );
            strSql.Append( " SELECT ROW_NUMBER() OVER (" );
            if ( !string.IsNullOrEmpty( orderby.Trim( ) ) )
            {
                strSql.Append( "ORDER BY T." + orderby );
            }
            else
            {
                strSql.Append( "ORDER BY T.idx DESC" );
            }
            strSql.Append( ")AS ROW,T.* FROM R_PQAK T" );
            if ( !string.IsNullOrEmpty( strWhere.Trim( ) ) )
            {
                strSql.Append( " WHERE " + strWhere );
            }
            strSql.Append( " ) TT" );
            strSql.AppendFormat( " WHERE TT.ROW BETWEEN {0} AND {1}" ,startIndex ,endIndex );
            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 获取R_195 数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePqq (string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AL001 idx,CP03,CP06,CP07,CP10,CP13,CP54,CP56,C.idx idx_195 FROM R_PQAL A,R_PQAK B,R_PQQ C WHERE A.AL001=B.idx AND A.AL002=C.CP03 AND A.AL003=C.idx" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " AND " + strWhere );
            }

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTablePqqCount ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT CONVERT(DECIMAL(18,2),SUM(CP)) CP FROM (SELECT CASE WHEN CP11=0 THEN SUM(CP54*CP13*CP10-CP12) WHEN CP10=0 THEN SUM(CP54*CP13*CP11-CP12) ELSE SUM(CP54*CP13*CP10-CP12) END CP FROM R_PQQ" );
            strSql.Append( " WHERE CP03=@CP03" );
            strSql.Append( " GROUP BY CP11,CP10) A" );
            SqlParameter[] parameter = {
                new SqlParameter("@CP03",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取R_485数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqozCount ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "WITH CET AS (SELECT SUM(OZ) OZ,OZ011 FROM (SELECT OZ005*OZ006 OZ,OZ011 FROM R_PQOZ GROUP BY OZ011,OZ005,OZ006,OZ001) A GROUP BY OZ011)" );
            strSql.Append( ",CFT AS (SELECT OZ001,CASE WHEN OZ=0 THEN 0 ELSE SUM(OZ009)/OZ*OZ005*OZ006 END OZ,T.OZ011 FROM R_PQOZ T LEFT JOIN TPADGA B ON T.OZ014=B.DGA001 LEFT JOIN CET C ON T.OZ011=C.OZ011 GROUP BY OZ001,OZ,OZ005,OZ006,T.OZ011)" );
            strSql.Append( " SELECT CONVERT(DECIMAL(18,2),SUM(OZ)) OZ FROM CFT" );
            strSql.Append( " WHERE OZ011=@OZ011" );
            SqlParameter[] parameter = {
                new SqlParameter("@OZ011",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取R_199数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqba ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AL001 idx,BA003,BA006,BA007,BA011,BA054,BA056,C.idx idx_199 FROM R_PQAL A,R_PQAK B,R_PQBA C WHERE A.AL001=B.idx AND A.AL002=C.BA003 AND A.AL003=C.idx" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " AND " + strWhere );
            }

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTablePqbaCount ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT CONVERT(DECIMAL(18,2),SUM(BA013*BA054)) BA FROM R_PQBA" );
            strSql.Append( " WHERE BA003=@BA003" );
            SqlParameter[] parameter = {
                new SqlParameter("@BA003",SqlDbType.NVarChar)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取R_196数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePqah (string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AL001 idx,AH10,AH11,AH12,AH101,AH13,AH14,AH16,AH111,C.idx idx_196 FROM R_PQAL A,R_PQAK B,R_PQAH C WHERE A.AL001=B.idx AND A.AL002=C.AH97 AND A.AL003=C.idx" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " AND " + strWhere );
            }

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTablePqahCount ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT CONVERT(DECIMAL(18,2),SUM(AH16*AH101*AH13*AH14)) AH FROM R_PQAH" );
            strSql.Append( " WHERE AH97=@AH97" );
            SqlParameter[] parameter = {
                new SqlParameter("@AH97",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取R_338数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePqo (string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AL001 idx,JM09,JM94,JM95,JM96,JM10,JM11,JM103,JM107,ISNULL(JM118,0) JM118,convert(decimal(11,0),JM103/JM10+isnull(JM118,0))*JM11 U3_1,C.idx idx_338 FROM R_PQAL A,R_PQAK B,R_PQO C WHERE A.AL001=B.idx AND A.AL002=C.JM01 AND A.AL003=C.idx" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " AND " + strWhere );
            }

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTablePqoCount ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT CONVERT(DECIMAL(18,2),SUM(CASE WHEN JM10=0 THEN isnull(JM118,0)*JM11 ELSE CONVERT(decimal(11,0),JM103/JM10+isnull(JM118,0))*JM11 END)) JM FROM R_PQO " );
            strSql.Append( " WHERE JM01=@JM01" );
            SqlParameter[] parameter = {
                new SqlParameter("@JM01",SqlDbType.NVarChar)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取R_339数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqi ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AL001 idx,YQ10,YQ11,YQ12,YQ108,YQ13,YQ15,YQ14,YQ16,YQ114,YQ115,YQ112,YQ113,YQ116,YQ123,C.idx idx_339 FROM R_PQAL A,R_PQAK B,R_PQI C WHERE A.AL001=B.idx AND A.AL002=C.YQ99 AND A.AL003=C.idx" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " AND " + strWhere );
            }

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTablePqiCount ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT CONVERT(DECIMAL(18,2),SUM(CASE WHEN YQ114=0 OR YQ115=0 THEN 0 WHEN YQ114!=0 AND YQ115!=0 THEN YQ108*YQ112*YQ113*YQ116*YQ13*YQ14*0.01/YQ114/YQ115 END) +SUM(YQ13*YQ16*YQ108*YQ112*YQ113*YQ114*YQ115*YQ116*0.000001)) YQ FROM R_PQI " );
            strSql.Append( " WHERE YQ99=@YQ99" );
            SqlParameter[] parameter = {
                new SqlParameter("@YQ99",SqlDbType.NVarChar)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }


        /// <summary>
        /// 获取R_341数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqv ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AL001 idx,PQV80,PQV10,PQV66,PQV81,PQV67,PQV88,PQV11,PQV12,PQV13,PQV68,PQV69,PQV70,C.idx idx_341 FROM R_PQAL A,R_PQAK B,R_PQV C WHERE A.AL001=B.idx AND A.AL002=C.PQV76 AND A.AL003=C.idx" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " AND " + strWhere );
            }

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTablePqvCount ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            //PQV80*PQV11*PQV12*PQV13*PQV68*PQV69*PQV70*0.000001
            strSql.Append( "SELECT CONVERT(DECIMAL(18,2),SUM(PQV11*PQV66*PQV81*PQV67*PQV13)) PQV FROM R_PQV" );
            strSql.Append( " WHERE PQV76=@PQV76" );
            SqlParameter[] parameter = {
                new SqlParameter("@PQV76",SqlDbType.NVarChar)
            };
            parameter[0].Value = oddNum;


            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }


        /// <summary>
        /// 获取R_342数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqaf ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AL001 idx,AF015,AF006,AF020,AF021,AF022,AF078,AF019,AF023,C.idx idx_342 FROM R_PQAL A,R_PQAK B,R_PQAF C WHERE A.AL001=B.idx AND A.AL002=C.AF001 AND A.AL003=C.idx" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " AND " + strWhere );
            }

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTablePqafCount ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT CONVERT(DECIMAL(18,2),SUM(AF023*AF006*AF019)) AF FROM R_PQAF" );
            strSql.Append( " WHERE AF001=@AF001" );
            SqlParameter[] parameter = {
                new SqlParameter("@AF001",SqlDbType.NVarChar)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }


        /// <summary>
        /// 获取R_343数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqu ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AL001 idx,PQU101,PQU10,PQU12,PQU13,PQU16,PQU107,PQU14,C.idx idx_343 FROM R_PQAL A,R_PQAK B,R_PQU C WHERE A.AL001=B.idx AND A.AL002=C.PQU97 AND A.AL003=C.idx" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " AND " + strWhere );
            }

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTablePquCount ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT CONVERT(DECIMAL(18,2),SUM(PQU16*(PQU101*PQU13+PQU14))) PQ FROM R_PQU" );
            strSql.Append( " WHERE PQU97=@PQU97" );
            SqlParameter[] parameter = {
                new SqlParameter("@PQU97",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }


        /// <summary>
        /// 获取R_347数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqs ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AL001 idx,PJ09,PJ89,PJ96,PJ10,PJ11,PJ12,PJ100,C.idx idx_347 FROM R_PQAL A,R_PQAK B,R_PQS C WHERE A.AL001=B.idx AND A.AL002=C.PJ92 AND A.AL003=C.idx" );

            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " AND " + strWhere );
            }

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTablePqsCount ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT CONVERT(DECIMAL(18,2),SUM(PJ12*(PJ11*PJ96+PJ10))) PQ FROM R_PQS" );
            strSql.Append( " WHERE PJ92=@PJ92" );
            SqlParameter[] parameter = {
                new SqlParameter("@PJ92",SqlDbType.NVarChar)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }


        /// <summary>
        /// 获取R_349数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqt ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AL001 idx,WX10,WX11,WX86,WX13,WX15,WX27,WX28,WX29,WX30,WX31,WX32,WX23,WX24,WX25,WX26,WX90,U3,U4,C.idx idx_349 FROM R_PQAL A,R_PQAK B,R_PQT C WHERE A.AL001=B.idx AND A.AL002=C.WX82 AND A.AL003=C.idx" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " AND " + strWhere );
            }

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTablePqtCount ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT CONVERT(DECIMAL(18,2),SUM(CASE WHEN WX10='双瓦外箱' THEN ((WX27 + WX28 + WX29) * (WX30 + WX31 + WX32) + (WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15 WHEN WX10='小箱式' THEN ((WX27 + WX28 + WX29) * (WX30 + WX31 + WX32) + (WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15 WHEN WX10='牙膏式' THEN ((WX27 + 2*WX28 + WX29) * (2*WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15  WHEN WX10='插口式' THEN ((WX27 + 2*WX28 + WX29) * (2*WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10='天盖' THEN  ((WX27 + 2*WX28 + WX29) * (WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15  WHEN WX10='地盖' THEN ((WX27 + 2*WX28 + WX29) * (WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15  WHEN WX10='折叠式' THEN ((2*WX27 + 2*WX28 + WX29) * (1.5*WX30 + WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10 NOT IN ('双瓦外箱','小箱式','牙膏式','插口式','天盖','地盖','折叠式') THEN (WX23 + WX24) * (WX25 + WX26) * 0.0001 * WX13* WX15 END)) PQ FROM R_PQT" );
            strSql .Append( " WHERE WX82=@WX82" );
            SqlParameter[] parameter = {
                new SqlParameter("@WX82",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取R_495数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqy ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AL001 idx,A.idx idx_495,PY25,PY36,PY10,CASE WHEN PY14 = 0 OR PY18 = 0 OR PY21 = 0 THEN 0 WHEN PY14 != 0 AND PY18 != 0 AND PY21 != 0 THEN CONVERT( DECIMAL(18,3),(PY10*PY11*PY15*PY12*PY20/PY21/PY14/PY18+PY13*PY19*PY16*PY10*PY11/PY14/PY18/PY21/2)*(1+PY17/100)) END U20,CONVERT( DECIMAL(18,3), PY23 * PY14 * PY18 * PY11 * PY10 * PY12 *PY15* 0.0001 ) U21 FROM R_PQY A,R_PQAK B,R_PQAL C WHERE C.AL001=B.idx AND C.AL002=A.PY33 AND C.AL003=A.idx" );
            strSql.Append( " AND " + strWhere );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTablePqyCount ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT CONVERT(DECIMAL(18,2),SUM(U0)) U0 FROM (SELECT idx,SUM(U13+U14) U0 FROM (SELECT idx,CASE WHEN PY14 = 0 OR PY18 = 0 OR PY21 = 0 THEN 0 WHEN PY14 != 0 AND PY18 != 0 AND PY21 != 0 THEN (PY10*PY11*PY15*PY12*PY20/PY21/PY14/PY18+PY13*PY19*PY16*PY10*PY11/PY14/PY18/PY21/2)*(1+PY17/100) END U13,PY23*PY14*PY18*PY11*PY10*PY12*PY15*0.0001 U14 FROM R_PQY WHERE PY33=@PY33) A GROUP BY idx) A" );
            SqlParameter[] parameter = {
                new SqlParameter("@PY33",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取505数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqiz ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AL001 idx,A.idx idx_pqiz,IZ008,IZ009,IZ013,IZ014,IZ015,CASE WHEN IZ021=0 THEN 0 ELSE CONVERT(DECIMAL(10,3),(IZ005*IZ022/IZ021)*(IZ013*(IZ014+IZ015)*2*IZ016)) END U30 FROM R_PQIZ A,R_PQAK B,R_PQAL C WHERE C.AL001=B.idx AND C.AL002=A.IZ001 AND C.AL003=A.idx" );
            strSql.Append( " AND " + strWhere );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTablePqizCount ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT CONVERT(DECIMAL(18,2),SUM((IZ005*IZ022/IZ021)*(IZ013*(IZ014+IZ015)*2*IZ016))) U0 FROM R_PQIZ" );
            strSql.Append( " WHERE IZ001=@IZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@IZ001",SqlDbType.NVarChar)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// R_345
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqlz ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AL001 idx,LZ015,LZ016,LZ019,CONVERT(INT,LZ022*LZ006*LZ024) LZ0,LZ026,C.idx idx_pqlz FROM R_PQAL A,R_PQAK B,R_PQLZ C WHERE A.AL001=B.idx AND A.AL002=C.LZ001 AND A.AL003=C.idx" );
            strSql.Append( " AND " + strWhere );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTablePqlzCount ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT SUM(CONVERT(INT,LZ022*LZ006*LZ024+LZ026)) LZ0 FROM R_PQLZ" );
            strSql.Append( " WHERE LZ001=@LZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@LZ001",SqlDbType.NVarChar)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// R_344
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqmz ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AL001 idx,MZ016,MZ019,MZ023,0 AS MZ1,CONVERT(DECIMAL(18,0),CASE WHEN MZ107='厂内' THEN SUM(MZ022*MZ006*MZ027+ISNULL(MZ118,0)) ELSE SUM(ISNULL(MZ120,0)+MZ022*MZ006*MZ028*MZ024) END) MZ0,C.idx idx_pqmz FROM R_PQAL A,R_PQAK B,R_PQMZ C WHERE A.AL001=B.idx AND A.AL002=C.MZ001 AND A.AL003=C.idx" );
            strSql.Append( " AND " + strWhere );
            strSql.Append( " GROUP BY AL001,MZ016,MZ019,MZ023,C.idx,MZ107" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTablePqmzCount ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT CONVERT(DECIMAL(18,2),CASE WHEN MZ107='厂内' THEN SUM(MZ022*MZ006*MZ027+ISNULL(MZ118,0)) ELSE SUM(ISNULL(MZ120,0)+MZ022*MZ006*MZ028*MZ024) END) MZ0 FROM R_PQMZ" );
            strSql.Append( " WHERE MZ001=@MZ001 " );
            strSql.Append( " GROUP BY MZ107" );
            SqlParameter[] parameter = {
                new SqlParameter("@MZ001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// R_337
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqis ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AL001 idx,YQ11 SM,YQ119 GY,YQ12 SH,YQ109 GL,YQ06 YP,CONVERT(DECIMAL(18,0),YQ109*YQ15) JE,C.idx idx_pqis FROM R_PQI C,R_PQAK B,R_PQAL A WHERE A.AL001=B.idx AND A.AL002=C.YQ99 AND A.AL003=C.idx" );
            strSql.Append( " AND " + strWhere );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTablePqisCount ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT CONVERT(DECIMAL(18,2),SUM(YQ109*YQ15)) YQ FROM R_PQI WHERE YQ99 LIKE 'R_337%'" );
            strSql.Append( " AND YQ99=@YQ99" );
            SqlParameter[] parameter = {
                new SqlParameter("@YQ99",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取本单号本次付款金额的总金额
        /// </summary>
        /// <param name="conTractNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqak ( string conTractNum)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT SUM(AK011) AK011 FROM R_PQAK" );
            strSql.Append( " WHERE AK003=@AK003" );
            SqlParameter[] parameter = {
                new SqlParameter("@AK003",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = conTractNum;


            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 批量编辑状态
        /// </summary>
        /// <param name="str"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool UpdateOfState ( string str ,DateTime dt ,string tableNum ,string tableName ,string logins ,string stateOf ,string stateOfState ,string oddNum )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAK SET" );
            strSql.Append( " AK017='执行'," );
            strSql.AppendFormat( "AK016='{0}'" ,dt );
            strSql.Append( " WHERE idx IN (" + str + ")" );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dt ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfState ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 删除AL中有  AK中没有的数据
        /// </summary>
        /// <returns></returns>
        public bool DeleteOfCheck ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQAL WHERE AL001 IN (SELECT AL001 FROM R_PQAL WHERE AL001 NOT IN (SELECT AL001 FROM R_PQAK A LEFT JOIN R_PQAL B ON A.idx=B.AL001))" );

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrint ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AK001,AK002,AK004,AK005,AK006,AK007,AK009,AK010,AK015,AK011,AK009-AK010-AK011-AK015 AK,AK013 FROM R_PQAK" );
            strSql.Append( " WHERE idx IN (" + strWhere + ")" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfAll ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx FROM R_PQAK C WHERE EXISTS (" );
            strSql.Append( "SELECT AL001 FROM R_PQAL B WHERE C.idx=B.AL001 AND NOT EXISTS (SELECT PJ92,idx FROM R_PQS A WHERE A.PJ92=B.AL002 AND A.idx=B.AL003) AND AL002 LIKE 'R_347%' " );
            strSql.Append( "UNION " );
            strSql.Append( "SELECT AL001 FROM R_PQAL B WHERE C.idx=B.AL001 AND NOT EXISTS (SELECT CP03,idx FROM R_PQQ A WHERE A.CP03=B.AL002 AND A.idx=B.AL003) AND AL002 LIKE 'R_195%' " );
            strSql.Append( "UNION " );
            strSql.Append( "SELECT AL001 FROM R_PQAL B WHERE C.idx=B.AL001 AND NOT EXISTS (SELECT AH97,idx FROM R_PQAH A WHERE A.AH97=B.AL002 AND A.idx=B.AL003) AND AL002 LIKE 'R_196%' " );
            strSql.Append( "UNION " );
            strSql.Append( "SELECT AL001 FROM R_PQAL B WHERE C.idx=B.AL001 AND NOT EXISTS (SELECT BA003,idx FROM R_PQBA A WHERE A.BA003=B.AL002 AND A.idx=B.AL003) AND AL002 LIKE 'R_199%' " );
            strSql.Append( "UNION " );
            strSql.Append( "SELECT AL001 FROM R_PQAL B WHERE C.idx=B.AL001 AND NOT EXISTS (SELECT JM01,idx FROM R_PQO A WHERE A.JM01=B.AL002 AND A.idx=B.AL003) AND AL002 LIKE 'R_338%' " );
            strSql.Append( "UNION " );
            strSql.Append( "SELECT AL001 FROM R_PQAL B WHERE C.idx=B.AL001 AND NOT EXISTS (SELECT PQV76,idx FROM R_PQV A WHERE A.PQV76=B.AL002 AND A.idx=B.AL003) AND AL002 LIKE 'R_341%' " );
            strSql.Append( "UNION " );
            strSql.Append( "SELECT AL001 FROM R_PQAL B WHERE C.idx=B.AL001 AND NOT EXISTS (SELECT AF001,idx FROM R_PQAF A WHERE A.AF001=B.AL002 AND A.idx=B.AL003) AND AL002 LIKE 'R_342%' " );
            strSql.Append( "UNION " );
            strSql.Append( "SELECT AL001 FROM R_PQAL B WHERE C.idx=B.AL001 AND NOT EXISTS (SELECT PQU97,idx FROM R_PQU A WHERE A.PQU97=B.AL002 AND A.idx=B.AL003) AND AL002 LIKE 'R_343%' " );
            strSql.Append( "UNION " );
            strSql.Append( "SELECT AL001 FROM R_PQAL B WHERE C.idx=B.AL001 AND NOT EXISTS (SELECT WX82,idx FROM R_PQT A WHERE A.WX82=B.AL002 AND A.idx=B.AL003) AND AL002 LIKE 'R_349%' " );
            strSql.Append( "UNION " );
            strSql.Append( "SELECT AL001 FROM R_PQAL B WHERE C.idx=B.AL001 AND NOT EXISTS (SELECT IZ001,idx FROM R_PQIZ A WHERE A.IZ001=B.AL002 AND A.idx=B.AL003) AND AL002 LIKE 'R_505%' " );
            strSql.Append( "UNION " );
            strSql.Append( "SELECT AL001 FROM R_PQAL B WHERE C.idx=B.AL001 AND NOT EXISTS (SELECT YQ99,idx FROM R_PQI A WHERE A.YQ99=B.AL002 AND A.idx=B.AL003) AND AL002 LIKE 'R_339%' " );
            strSql.Append( "UNION " );
            strSql.Append( "SELECT AL001 FROM R_PQAL B WHERE C.idx=B.AL001 AND NOT EXISTS (SELECT YQ99,idx FROM R_PQI A WHERE A.YQ99=B.AL002 AND A.idx=B.AL003) AND AL002 LIKE 'R_337%' " );
            strSql.Append( "UNION " );
            strSql.Append( "SELECT AL001 FROM R_PQAL B WHERE C.idx=B.AL001 AND NOT EXISTS (SELECT PY33,idx FROM R_PQY A WHERE A.PY33=B.AL002 AND A.idx=B.AL003) AND AL002 LIKE 'R_495%' " );
            strSql.Append( ") UNION " );
            strSql.Append( "SELECT idx FROM R_PQAK WHERE idx NOT IN (SELECT AL001 FROM R_PQAL)" );
            
            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取供应商
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfG ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT AK001 FROM R_PQAK" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 批量编辑供应商
        /// </summary>
        /// <param name="strNameOne"></param>
        /// <param name="strNameTwo"></param>
        /// <returns></returns>
        public bool UpdateOfG (string strNameOne,string strNameTwo )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE R_PQAK SET AK001='{0}' WHERE AK001='{1}' AND ( AK017='' OR AK017 IS NULL)" , strNameOne , strNameTwo );

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        #endregion
    }
}

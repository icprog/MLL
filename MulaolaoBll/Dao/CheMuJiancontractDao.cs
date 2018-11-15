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
    public class CheMuJiancontractDao
    {
        /// <summary>
        /// 获取数据列表  单个字段
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( string field )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT " );
            strSql.Append( field );
            strSql.Append( " FROM R_PQAF" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 获取数据列表  单个字段
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableSupplied ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT AF008,(SELECT DGA003 FROM TPADGA WHERE AF008=DGA001) DGA002 FROM R_PQAF" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCheMuJianCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQAF" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " WHERE " + strWhere );
            }

            object obj = SqlHelper.GetSingle( strSql.ToString( ) );
            if ( obj == null )
                return 0;
            else
                return Convert.ToInt32( obj );
        }

        /// <summary>
        /// 获取总记录数  财务结账
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCheMuJianCountOne ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQAF TT,R_REVIEWS B WHERE TT.AF001=B.RES06 AND RES05='执行' AND NOT EXISTS (SELECT 1 FROM R_PQAL C,R_PQAK D WHERE TT.idx=C.AL003 AND TT.AF001=C.AL002 AND C.AL001=D.idx)" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " AND " + strWhere );
            }

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
        public DataTable GetDataTableByPage ( string strWhere ,string orderby ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,AF001,AF003,AF002,AF004,AF005,AF006,AF015,AF016,AF017,AF018,AF020,AF021,AF022,AF023,AF019,AF083,AF008,CASE WHEN AF002!='' THEN '' ELSE CASE WHEN AF082='T' THEN '已入' ELSE '未入' END END AF082,(SELECT DGA002 FROM TPADGA WHERE DGA001=AF008) DGA002,(SELECT RES05 FROM R_REVIEWS WHERE RES04=(SELECT MAX(RES04) RES04 FROM R_REVIEWS WHERE RES06=AF001)) RES05,ISNULL(AF078,'F') AF078,AF088,CONVERT(DECIMAL(11,2),AF023*AF019) U1,AF010,CASE WHEN AF020=0 OR AF021=0 OR AF022=0 THEN 0 ELSE AF023/AF020/AF021/AF022*1000000 END U4,AF087,AF084,AF090 FROM (" );
            strSql.Append( " SELECT ROW_NUMBER() OVER (" );
            if ( !string.IsNullOrEmpty( orderby ) )
            {
                strSql.Append( "ORDER BY T." + orderby );
            }
            else
            {
                strSql.Append( "ORDER BY T.idx DESC" );
            }
            strSql.Append( " )AS Row,T.* FROM R_PQAF T" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " WHERE " + strWhere );
            }
            strSql.Append( " ) TT" );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        
        
        /// <summary>
        /// 分页获取数据列表   财务结账
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTableByPage ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT TT.idx,AF001,AF003,AF002,AF004,AF005,AF006,AF015,AF016,AF017,AF018,AF020,AF021,AF022,AF023,AF019,AF083,AF008,CASE WHEN AF002!='' THEN '' ELSE CASE WHEN AF082='T' THEN '已入' ELSE '未入' END END AF082,(SELECT DGA003 FROM TPADGA WHERE DGA001=AF008) DGA002, RES05,ISNULL(AF078,'F') AF078 ,AF088,CONVERT(DECIMAL(11,2),AF023*AF019) U1,AF010,CASE WHEN AF020=0 OR AF021=0 OR AF022=0 THEN 0 ELSE AF023/AF020/AF021/AF022*1000000 END U4,AF087,AF084,AF090 FROM  ( " );
            strSql.Append( " SELECT ROW_NUMBER() OVER (" );
            strSql.Append( "ORDER BY T.AF001 DESC" );
            strSql.Append( " )AS Row,T.* FROM R_PQAF T" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " WHERE " + strWhere );
            }
            strSql.Append( " ) TT,R_REVIEWS B WHERE TT.AF001=B.RES06 AND RES05='执行' AND NOT EXISTS (SELECT 1 FROM R_PQAL C,R_PQAK D WHERE TT.idx=C.AL003 AND TT.AF001=C.AL002 AND C.AL001=D.idx AND (AK009-AK010-AK011-AK015)<=100)" );// AND AK009=AK011
            strSql .AppendFormat( " AND TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取生产人姓名
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePerson ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DBA002,DBA001,DBA028 FROM TPADBA WHERE DBA028!='' AND (DBA043='F' OR DBA043='' OR DBA043 IS NULL) ORDER BY DBA001" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

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
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintOne ( string oddNum ,int startIndex,int endIndex)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql . Append ( "WITH CET AS (" );
            strSql.Append( "SELECT ROW_NUMBER() OVER(ORDER BY AF002) row,AF002,AF003,AF004,AF006,AF015,AF016,AF017,AF018,AF019,CONVERT(DECIMAL(4,2),AF023*AF019) U1,CONVERT(DECIMAL(5,1),AF020*AF021*AF022) U0,AF020,AF021,AF022,AF006*AF019 U3,AF023,CASE WHEN AF023=0 THEN 0 WHEN AF020=0 THEN 0 WHEN AF021=0 THEN 0 WHEN AF022=0 THEN 0 WHEN AF023!=0 AND AF020!=0 AND AF021!=0 AND AF022!=0 THEN CONVERT(BIGINT,ROUND(AF023/(AF020* AF021* AF022)*1000000,0)) END U4,AF023*AF006*AF019 U5,CONVERT(VARCHAR(20),AF024,111) AF024,CONVERT(VARCHAR(20),AF025,111)AF025,AF084 FROM R_PQAF" );
            strSql.Append( " WHERE AF001 =@AF001" );
            strSql . AppendFormat ( ") SELECT * FROM CET WHERE row BETWEEN {0} AND {1}" ,startIndex ,endIndex );
            SqlParameter[] parameter = {
                new SqlParameter("@AF001",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintTwo ( string oddNum ,int startIndex,int endIndex)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql . Append ( "WITH CET AS (" );
            strSql.Append( "SELECT ROW_NUMBER() OVER(ORDER BY AF002) row,'≥'+CONVERT(VARCHAR(20),AF026)+'%' AF026,'≤'+CONVERT(VARCHAR(20),AF027)+'%' AF027,CONVERT(VARCHAR(20),AF028)+'%' AF028,AF029,AF030,AF031,AF032,AF033,AF034 FROM R_PQAF" );
            strSql.Append( " WHERE AF001=@AF001" );
            strSql . AppendFormat ( ") SELECT * FROM CET WHERE row BETWEEN {0} AND {1}" ,startIndex ,endIndex );
            SqlParameter[] parameter = {
                new SqlParameter("@AF001",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintThr ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AF005,(SELECT DBA002 FROM TPADBA WHERE DBA001=AF007) DBA002,(SELECT DBA002 FROM TPADBA WHERE DBA001=AF007) DBA028,(SELECT DGA003 FROM TPADGA WHERE DGA001=AF008) DGA003,(SELECT DGA017 FROM TPADGA WHERE DGA001=AF008) DGA017,(SELECT DGA009 FROM TPADGA WHERE DGA001=AF008) DGA009,(SELECT DGA008 FROM TPADGA WHERE DGA001=AF008) DGA008,AF009,AF010,AF011,AF012,CONVERT(VARCHAR(20),AF013,111) AF013,CONVERT(VARCHAR(20),AF014,111) AF014,AF035,CONVERT(VARCHAR(20),AF036,111) AF036,AF037,AF038,AF039,AF040,AF041,AF042,CONVERT(VARCHAR(20),AF043,111) AF043,AF044,CONVERT(VARCHAR(20),AF045,111) AF045,AF046,AF047,AF048,CONVERT(VARCHAR(20),AF049,111) AF049,AF050,CONVERT(VARCHAR(20),AF051,111) AF051,AF052,AF053,AF054,AF055,AF056,AF057,AF058,AF059,AF060,AF061,AF062,AF063,AF064,AF065,CONVERT(VARCHAR(20),AF066,111) AF066,AF067,AF068,CONVERT(VARCHAR(20),AF069,111) AF069,AF070,CONVERT(VARCHAR(20),AF071,111) AF071,AF072,CONVERT(VARCHAR(20),AF073,111) AF073,AF079,AF001,CASE WHEN AF002='' THEN 'F' WHEN AF002!='' THEN CASE WHEN AF016='库存' THEN 'T' ELSE '1' END END AF,ISNULL(AF078,'F') AF078 FROM R_PQAF" );
            strSql.Append( " WHERE AF001=@AF001" );
            SqlParameter[] parameter = {
                new SqlParameter("@AF001",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 编辑上次更新记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateStr ( MulaolaoLibrary.CheMuJianContractLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAF SET " );
            strSql.Append( "AF080=@AF080," );
            strSql.Append( "AF081=@AF081" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@AF080",SqlDbType.BigInt),
                new SqlParameter("@AF081",SqlDbType.BigInt),
                new SqlParameter("@idx",SqlDbType.Int)
            };

            parameter[0].Value = model.AF080;
            parameter[1].Value = model.AF081;
            parameter[2].Value = model.idx;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 批量编辑数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateBatch ( MulaolaoLibrary.CheMuJianContractLibrary model ,string tableNum,string tableName,string logins,DateTime dtOne,string stateOf,string stateOfOdd)
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAF SET " );
            strSql.AppendFormat( "AF006='{0}'," ,model.AF006 );
            strSql.AppendFormat( "AF017='{0}'," ,model.AF017 );
            strSql.AppendFormat( "AF018='{0}'" ,model.AF018 );
            strSql.AppendFormat( " WHERE idx='{0}'" ,model.idx );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.AF001 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 编辑入库标记
        /// </summary>
        /// <returns></returns>
        public bool EditStorage ( )
        {
            ArrayList SQLString = new ArrayList( );
            string strWhere = "", strNum = "";
            DataTable da = GetDataTableStorage( );
            if ( da != null && da.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < da.Rows.Count ; i++ )
                {
                    string sx = da.Rows[i]["AC16"].ToString( );
                    if ( sx.Contains( "," ) )
                    {
                        foreach ( string s in sx.Split( ',' ) )
                        {
                            if ( strWhere == "" )
                                strWhere = "'" + sx + "'";
                            else
                                strWhere = strWhere + "," + "'" + sx + "'";
                        }
                    }
                    else
                    {
                        if ( strWhere == "" )
                            strWhere = "'" + sx + "'";
                        else
                            strWhere = strWhere + "," + "'" + sx + "'";
                    }

                    if ( strNum == "" )
                        strNum = "'" + da.Rows[i]["AC18"].ToString( ) + "'";
                    else
                        strNum = strNum + "," + "'" + da.Rows[i]["AC18"].ToString( ) + "'";
                }
            }
            if ( strWhere != "" )
                SQLString.Add( EditPqaf( strWhere ) );
            if ( strNum != "" )
                SQLString.Add( EditAc( strWhere ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取入库标记
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableStorage ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT AC16,AC18 FROM R_PQAC WHERE (AC17!='T' OR AC17='' OR AC17 IS NULL) AND AC16 LIKE 'R_342%'" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 编辑入库标记
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public string EditAc ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAC SET AC17='T'" );
            strSql.Append( " WHERE AC18 IN (" + strWhere + ")" );

            return strSql.ToString( );
        }

        /// <summary>
        /// 编辑入库标记
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public string EditPqaf ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAF SET AF082='T'" );
            strSql.Append( " WHERE AF001 IN (" + strWhere + ")" );

            return strSql.ToString( );
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="tableNum"></param>
        /// <param name="tableName"></param>
        /// <param name="logins"></param>
        /// <param name="dtOne"></param>
        /// <param name="stateOf"></param>
        /// <param name="stateOfOdd"></param>
        /// <returns></returns>
        public bool DeleteAll ( MulaolaoLibrary.CheMuJianContractLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf,string stateOfOdd)
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "DELETE FROM R_PQAF WHERE AF001='{0}'" ,model.AF001 );
            SQLString.Add( strSql.ToString( ) );
            StringBuilder strSq = new StringBuilder( );
            strSq.AppendFormat( "DELETE FROM R_REVIEWS WHERE RES01='{0}' AND RES06='{1}'" ,tableNum ,model.AF001 );
            SQLString.Add( strSq.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.AF001 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );
            if ( stateOfOdd == "维护删除" )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "DELETE FROM R_PQAMB WHERE AMB001='{0}'" ,model.AF001 );
                SQLString.Add( strSql.ToString( ) );
            }
            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 更改记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="tableNum"></param>
        /// <param name="tableName"></param>
        /// <param name="logins"></param>
        /// <param name="dtOne"></param>
        /// <param name="stateOf"></param>
        /// <param name="stateOfOdd"></param>
        /// <returns></returns>
        public bool UpdateOfAll ( MulaolaoLibrary.CheMuJianContractLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAF SET " );
            strSql.AppendFormat( "AF002='{0}'," ,model.AF002 );
            strSql.AppendFormat( "AF003='{0}'," ,model.AF003 );
            strSql.AppendFormat( "AF004='{0}'," ,model.AF004 );
            strSql.AppendFormat( "AF005='{0}'," ,model.AF005 );
            strSql.AppendFormat( "AF007='{0}'," ,model.AF007 );
            strSql.AppendFormat( "AF008='{0}'," ,model.AF008 );
            strSql.AppendFormat( "AF009='{0}'," ,model.AF009 );
            strSql.AppendFormat( "AF010='{0}'," ,model.AF010 );
            strSql.AppendFormat( "AF011='{0}'," ,model.AF011 );
            strSql.AppendFormat( "AF012='{0}'," ,model.AF012 );
            strSql.AppendFormat( "AF013='{0}'," ,model.AF013 );
            strSql.AppendFormat( "AF014='{0}'," ,model.AF014 );
            strSql.AppendFormat( "AF035='{0}'," ,model.AF035 );
            strSql.AppendFormat( "AF036='{0}'," ,model.AF036 );
            strSql.AppendFormat( "AF037='{0}'," ,model.AF037 );
            strSql.AppendFormat( "AF038='{0}'," ,model.AF038 );
            strSql.AppendFormat( "AF039='{0}'," ,model.AF039 );
            strSql.AppendFormat( "AF040='{0}'," ,model.AF040 );
            strSql.AppendFormat( "AF041='{0}'," ,model.AF041 );
            strSql.AppendFormat( "AF042='{0}'," ,model.AF042 );
            strSql.AppendFormat( "AF043='{0}'," ,model.AF043 );
            strSql.AppendFormat( "AF044='{0}'," ,model.AF044 );
            strSql.AppendFormat( "AF045='{0}'," ,model.AF045 );
            strSql.AppendFormat( "AF046='{0}'," ,model.AF046 );
            strSql.AppendFormat( "AF047='{0}'," ,model.AF047 );
            strSql.AppendFormat( "AF048='{0}'," ,model.AF048 );
            strSql.AppendFormat( "AF049='{0}'," ,model.AF049 );
            strSql.AppendFormat( "AF050='{0}'," ,model.AF050 );
            strSql.AppendFormat( "AF051='{0}'," ,model.AF051 );
            strSql.AppendFormat( "AF052='{0}'," ,model.AF052 );
            strSql.AppendFormat( "AF053='{0}'," ,model.AF053 );
            strSql.AppendFormat( "AF054='{0}'," ,model.AF054 );
            strSql.AppendFormat( "AF055='{0}'," ,model.AF055 );
            strSql.AppendFormat( "AF056='{0}'," ,model.AF056 );
            strSql.AppendFormat( "AF057='{0}'," ,model.AF057 );
            strSql.AppendFormat( "AF058='{0}'," ,model.AF058 );
            strSql.AppendFormat( "AF059='{0}'," ,model.AF059 );
            strSql.AppendFormat( "AF060='{0}'," ,model.AF060 );
            strSql.AppendFormat( "AF061='{0}'," ,model.AF061 );
            strSql.AppendFormat( "AF062='{0}'," ,model.AF062 );
            strSql.AppendFormat( "AF063='{0}'," ,model.AF063 );
            strSql.AppendFormat( "AF064='{0}'," ,model.AF064 );
            strSql.AppendFormat( "AF065='{0}'," ,model.AF065 );
            strSql.AppendFormat( "AF066='{0}'," ,model.AF066 );
            strSql.AppendFormat( "AF067='{0}'," ,model.AF067 );
            strSql.AppendFormat( "AF068='{0}'," ,model.AF068 );
            strSql.AppendFormat( "AF069='{0}'," ,model.AF069 );
            strSql.AppendFormat( "AF070='{0}'," ,model.AF070 );
            strSql.AppendFormat( "AF071='{0}'," ,model.AF071 );
            strSql.AppendFormat( "AF072='{0}'," ,model.AF072 );
            strSql.AppendFormat( "AF073='{0}'," ,model.AF073 );
            strSql.AppendFormat( "AF074='{0}'," ,model.AF074 );
            strSql.AppendFormat( "AF075='{0}'," ,model.AF075 );
            strSql.AppendFormat( "AF077='{0}'," ,model.AF077 );
            strSql.AppendFormat( "AF078='{0}'," ,model.AF078 );
            strSql.AppendFormat( "AF079='{0}'," ,model.AF079 );
            strSql.AppendFormat( "AF083='{0}'" ,model.AF083 );
            strSql.AppendFormat( " WHERE AF001='{0}'" ,model.AF001 );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.AF001 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="tableNum"></param>
        /// <param name="tableName"></param>
        /// <param name="logins"></param>
        /// <param name="dtOne"></param>
        /// <param name="stateOf"></param>
        /// <param name="stateOfOdd"></param>
        /// <returns></returns>
        public bool Copy ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAF (AF002,AF003,AF004,AF005,AF006,AF007,AF008,AF015,AF016,AF017,AF018,AF019,AF020,AF021,AF022,AF023,AF026,AF027,AF028,AF029,AF030,AF031,AF032,AF033,AF034,AF037,AF038,AF039,AF040,AF046,AF047,AF052,AF053,AF054,AF055,AF056,AF057,AF058,AF059,AF060,AF061,AF062,AF063,AF084) SELECT AF002,AF003,AF004,AF005,AF006,AF007,AF008,AF015,AF016,AF017,AF018,AF019,AF020,AF021,AF022,AF023,AF026,AF027,AF028,AF029,AF030,AF031,AF032,AF033,AF034,AF037,AF038,AF039,AF040,AF046,AF047,AF052,AF053,AF054,AF055,AF056,AF057,AF058,AF059,AF060,AF061,AF062,AF063,AF084 FROM R_PQAF" );
            strSql.AppendFormat( " WHERE AF001='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 更改复制单号
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="tableNum"></param>
        /// <param name="tableName"></param>
        /// <param name="logins"></param>
        /// <param name="dtOne"></param>
        /// <param name="stateOf"></param>
        /// <param name="stateOfOdd"></param>
        /// <returns></returns>
        public bool CopyOdd ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "UPDATE R_PQAF SET AF001='{0}',AF077='复制',AF024=DATEADD(DAY,5,GETDATE()) WHERE AF001 IS NULL" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfReceivable ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            //CASE WHEN AF026='清水' THEN '清水' WHEN  AF026='混水' THEN '混水' END AF026,
            strSql.Append( "SELECT AF002,AF016,CASE WHEN AF078='T' THEN 'T' WHEN AF078='F' OR AF078 IS NULL THEN 'F' END AF078,CONVERT(DECIMAL(18,1),SUM(AF023*AF006*AF019)) AF FROM R_PQAF A INNER JOIN R_REVIEWS D ON A.AF001=D.RES06 AND RES05='执行' WHERE AF002!=''" );
            strSql.AppendFormat( " AND AF001='{0}'  AND (AF002!='' AND AF002 IS NOT NULL) GROUP BY AF002,AF016,AF078" ,oddNum );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 写数据到241
        /// </summary>
        /// <param name="modelAm"></param>
        /// <returns></returns>
        public bool UpdateOfReceivable ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm,string oddNum )
        {
            ArrayList SQLString = new ArrayList( );
            ByOneBy( modelAm ,oddNum ,SQLString );
            //WriteReceivableToGeneralLedger.ByOneByChe( modelAm ,oddNum ,SQLString );
            if ( modelAm.AM270 > 0 )
            {
                StringBuilder strSqlAM270 = new StringBuilder( );
                strSqlAM270.AppendFormat( "UPDATE R_PQAM SET AM270='{0}' WHERE AM002='{1}'" ,modelAm.AM270 ,modelAm.AM002 );
                SQLString.Add( strSqlAM270.ToString( ) );
            }
            if ( modelAm.AM272 > 0 )
            {
                StringBuilder strSqlAM272 = new StringBuilder( );
                strSqlAM272.AppendFormat( "UPDATE R_PQAM SET AM272='{0}' WHERE AM002='{1}'" ,modelAm.AM272 ,modelAm.AM002 );
                SQLString.Add( strSqlAM272.ToString( ) );
            }
            if ( modelAm.AM273 > 0 )
            {
                StringBuilder strSqlAM273 = new StringBuilder( );
                strSqlAM273.AppendFormat( "UPDATE R_PQAM SET AM273='{0}' WHERE AM002='{1}'" ,modelAm.AM273 ,modelAm.AM002 );
                SQLString.Add( strSqlAM273.ToString( ) );
            }
            if ( modelAm.AM277 > 0 )
            {
                StringBuilder strSqlAM277 = new StringBuilder( );
                strSqlAM277.AppendFormat( "UPDATE R_PQAM SET AM277='{0}' WHERE AM002='{1}'" ,modelAm.AM277 ,modelAm.AM002 );
                SQLString.Add( strSqlAM277.ToString( ) );
            }
            if ( modelAm.AM279 > 0 )
            {
                StringBuilder strSqlAM279 = new StringBuilder( );
                strSqlAM279.AppendFormat( "UPDATE R_PQAM SET AM279='{0}' WHERE AM002='{1}'" ,modelAm.AM279 ,modelAm.AM002 );
                SQLString.Add( strSqlAM279.ToString( ) );
            }
            if ( modelAm.AM280 > 0 )
            {
                StringBuilder strSqlAM280 = new StringBuilder( );
                strSqlAM280.AppendFormat( "UPDATE R_PQAM SET AM280='{0}' WHERE AM002='{1}'" ,modelAm.AM280 ,modelAm.AM002 );
                SQLString.Add( strSqlAM280.ToString( ) );
            }
            if ( modelAm.AM283 > 0 )
            {
                StringBuilder strSqlAM283 = new StringBuilder( );
                strSqlAM283.AppendFormat( "UPDATE R_PQAM SET AM283='{0}' WHERE AM002='{1}'" ,modelAm.AM283 ,modelAm.AM002 );
                SQLString.Add( strSqlAM283.ToString( ) );
            }
            if ( modelAm.AM285 > 0 )
            {
                StringBuilder strSqlAM285 = new StringBuilder( );
                strSqlAM285.AppendFormat( "UPDATE R_PQAM SET AM285='{0}' WHERE AM002='{1}'" ,modelAm.AM285 ,modelAm.AM002 );
                SQLString.Add( strSqlAM285.ToString( ) );
            }


            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        
        void ByOneBy ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm,string oddNum,ArrayList SQLString )
        {
            //modelAm.AM270 = modelAm.AM273 = modelAm.AM277 = modelAm.AM280 = modelAm.AM272 = modelAm.AM279 = modelAm.AM283 = modelAm.AM285 = 0;
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "SELECT AMB270,AMB273,AMB277,AMB280,AMB272,AMB279,AMB283,AMB285 FROM R_PQAMB WHERE AMB001='{0}'" ,oddNum );

            DataTable de = SqlHelper.ExecuteDataTable( "SELECT AM270,AM273,AM277,AM280,AM272,AM279,AM283,AM285 FROM R_PQAM WHERE AM002='" + modelAm.AM002 + "'" );
            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            if ( da != null && da.Rows.Count > 0 )
            {
                if ( modelAm.AM270 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB270='{0}' WHERE AMB001='{1}'" ,modelAm.AM270 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM272 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB272='{0}' WHERE AMB001='{1}'" ,modelAm.AM272 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM273 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB273='{0}' WHERE AMB001='{1}'" ,modelAm.AM273 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM277 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB277='{0}' WHERE AMB001='{1}'" ,modelAm.AM277 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM279 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB279='{0}' WHERE AMB001='{1}'" ,modelAm.AM279 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM280 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB280='{0}' WHERE AMB001='{1}'" ,modelAm.AM280 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM283 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB283='{0}' WHERE AMB001='{1}'" ,modelAm.AM283 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM285 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB285='{0}' WHERE AMB001='{1}'" ,modelAm.AM285 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
               
                if ( de != null && de.Rows.Count > 0 )
                {
                    modelAm.AM270 = modelAm.AM270 - ( string.IsNullOrEmpty( da.Rows[0]["AMB270"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB270"].ToString( ) ) );
                    modelAm.AM272 = modelAm.AM272 - ( string.IsNullOrEmpty( da.Rows[0]["AMB272"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB272"].ToString( ) ) );
                    modelAm.AM273 = modelAm.AM273 - ( string.IsNullOrEmpty( da.Rows[0]["AMB273"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB273"].ToString( ) ) );
                    modelAm.AM277 = modelAm.AM277 - ( string.IsNullOrEmpty( da.Rows[0]["AMB277"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB277"].ToString( ) ) );
                    modelAm.AM279 = modelAm.AM279 - ( string.IsNullOrEmpty( da.Rows[0]["AMB279"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB279"].ToString( ) ) );
                    modelAm.AM280 = modelAm.AM280 - ( string.IsNullOrEmpty( da.Rows[0]["AMB280"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB280"].ToString( ) ) );
                    modelAm.AM283 = modelAm.AM283 - ( string.IsNullOrEmpty( da.Rows[0]["AMB283"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB283"].ToString( ) ) );
                    modelAm.AM285 = modelAm.AM285 - ( string.IsNullOrEmpty( da.Rows[0]["AMB285"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB285"].ToString( ) ) );

                    modelAm.AM270 = modelAm.AM270 + ( string.IsNullOrEmpty( de.Rows[0]["AM270"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM270"].ToString( ) ) );
                    modelAm.AM272 = modelAm.AM272 + ( string.IsNullOrEmpty( de.Rows[0]["AM272"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM272"].ToString( ) ) );
                    modelAm.AM273 = modelAm.AM273 + ( string.IsNullOrEmpty( de.Rows[0]["AM273"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM273"].ToString( ) ) );
                    modelAm.AM277 = modelAm.AM277 + ( string.IsNullOrEmpty( de.Rows[0]["AM277"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM277"].ToString( ) ) );
                    modelAm.AM279 = modelAm.AM279 + ( string.IsNullOrEmpty( de.Rows[0]["AM279"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM279"].ToString( ) ) );
                    modelAm.AM280 = modelAm.AM280 + ( string.IsNullOrEmpty( de.Rows[0]["AM280"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM280"].ToString( ) ) );
                    modelAm.AM283 = modelAm.AM283 + ( string.IsNullOrEmpty( de.Rows[0]["AM283"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM283"].ToString( ) ) );
                    modelAm.AM285 = modelAm.AM285 + ( string.IsNullOrEmpty( de.Rows[0]["AM285"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM285"].ToString( ) ) );
                }
                
            }
            else
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "INSERT INTO R_PQAMB (AMB001,AMB270,AMB273,AMB277,AMB280,AMB272,AMB279,AMB283,AMB285) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')" ,oddNum ,modelAm.AM270 ,modelAm.AM273 ,modelAm.AM277 ,modelAm.AM280 ,modelAm.AM272 ,modelAm.AM279 ,modelAm.AM283 ,modelAm.AM285 );
                SQLString.Add( strSql.ToString( ) );
                if ( de != null && de.Rows.Count > 0 )
                {
                    modelAm.AM270 = modelAm.AM270 + ( string.IsNullOrEmpty( de.Rows[0]["AM270"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM270"].ToString( ) ) );
                    modelAm.AM272 = modelAm.AM272 + ( string.IsNullOrEmpty( de.Rows[0]["AM272"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM272"].ToString( ) ) );
                    modelAm.AM273 = modelAm.AM273 + ( string.IsNullOrEmpty( de.Rows[0]["AM273"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM273"].ToString( ) ) );
                    modelAm.AM277 = modelAm.AM277 + ( string.IsNullOrEmpty( de.Rows[0]["AM277"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM277"].ToString( ) ) );
                    modelAm.AM279 = modelAm.AM279 + ( string.IsNullOrEmpty( de.Rows[0]["AM279"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM279"].ToString( ) ) );
                    modelAm.AM280 = modelAm.AM280 + ( string.IsNullOrEmpty( de.Rows[0]["AM280"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM280"].ToString( ) ) );
                    modelAm.AM283 = modelAm.AM283 + ( string.IsNullOrEmpty( de.Rows[0]["AM283"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM283"].ToString( ) ) );
                    modelAm.AM285 = modelAm.AM285 + ( string.IsNullOrEmpty( de.Rows[0]["AM285"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM285"].ToString( ) ) );
                }
                
            }
        }

        /// <summary>
        /// 根据流水和物品名称获取规格和每套用量
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getPartInfo ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT GS08,GS10 FROM R_PQP WHERE {0}" ,strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取原价
        /// </summary>
        /// <param name="liuNum"></param>
        /// <param name="huoNum"></param>
        /// <param name="buJian"></param>
        /// <param name="len"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public decimal getOriPri ( string liuNum,string huoNum,string buJian,string len,string width,string height )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT CONVERT(DECIMAL(18,0),CASE WHEN AF020*AF021*AF022=0 THEN 0 ELSE AF023/AF020/AF021/AF022*1000000 END) AF FROM R_PQAF WHERE AF002=(SELECT MAX(AF002) FROM R_PQAF WHERE AF004='{1}' AND AF002!='{0}' AND AF015='{2}' AND AF020='{3}' AND AF021='{4}' AND AF022='{5}') AND AF004='{1}' AND AF015='{2}' AND AF020='{3}' AND AF021='{4}' AND AF022='{5}'" ,liuNum ,huoNum ,buJian ,len ,width ,height );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
                return string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "AF" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ 0 ] [ "AF" ] . ToString ( ) );
            else
                return 0;
        }

        //[AF023] * [AF019]
        /// <summary>
        /// 获取每套成本原价
        /// </summary>
        /// <param name="liuNum"></param>
        /// <param name="huoNum"></param>
        /// <param name="buJian"></param>
        /// <param name="len"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public decimal getOriPrice ( string liuNum ,string huoNum ,string buJian ,string len ,string width ,string height )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT CONVERT(DECIMAL(18,2),AF023*AF019) AF FROM R_PQAF WHERE AF002=(SELECT MAX(AF002) FROM R_PQAF WHERE AF004='{1}' AND AF002!='{0}' AND AF015='{2}' AND AF020='{3}' AND AF021='{4}' AND AF022='{5}') AND AF004='{1}' AND AF015='{2}' AND AF020='{3}' AND AF021='{4}' AND AF022='{5}'" ,liuNum ,huoNum ,buJian ,len ,width ,height );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
                return string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "AF" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ 0 ] [ "AF" ] . ToString ( ) );
            else
                return 0;
        }

    }
}

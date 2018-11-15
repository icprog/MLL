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
    public class ProductQualityDao
    {
        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQBD" );
            strSql.AppendFormat( " WHERE BD001='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            StringBuilder strSq = new StringBuilder( );
            strSq.Append( "DELETE FROM R_REVIEWS" );
            strSq.AppendFormat( " WHERE RES06='{0}'" ,oddNum );
            SQLString.Add( strSq.ToString( ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 保存表数据
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool SaveOf ( DataTable table )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQBD WHERE 1=2" );

            return SqlHelper.UpdateTable( table ,strSql.ToString( ) );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool SaveOfUpdate ( MulaolaoLibrary.R_FrmProductQualityLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQBD SET " );
            strSql.Append( "BD002=@BD002," );
            strSql.Append( "BD004=@BD004," );
            strSql.Append( "BD006=@BD006," );
            strSql.Append( "BD007=@BD007," );
            strSql.Append( "BD008=@BD008," );
            strSql.Append( "BD009=@BD009," );
            strSql.Append( "BD010=@BD010," );
            strSql.Append( "BD011=@BD011," );
            strSql.Append( "BD012=@BD012," );
            strSql.Append( "BD013=@BD013," );
            strSql.Append( "BD014=@BD014," );
            strSql.Append( "BD040=@BD040," );
            strSql.Append( "BD041=@BD041" );
            strSql.Append( " WHERE BD001=@BD001" );
            SqlParameter[] parameter = {
                new SqlParameter("@BD001",SqlDbType.NVarChar,20),
                new SqlParameter("@BD002",SqlDbType.NVarChar,20),
                new SqlParameter("@BD004",SqlDbType.NVarChar,20),
                new SqlParameter("@BD006",SqlDbType.NVarChar,20),
                new SqlParameter("@BD007",SqlDbType.NVarChar,20),
                new SqlParameter("@BD008",SqlDbType.NVarChar,20),
                new SqlParameter("@BD009",SqlDbType.NVarChar,20),
                new SqlParameter("@BD010",SqlDbType.Date),
                new SqlParameter("@BD011",SqlDbType.Date),
                new SqlParameter("@BD012",SqlDbType.Date),
                new SqlParameter("@BD013",SqlDbType.Date),
                new SqlParameter("@BD014",SqlDbType.Int),
                new SqlParameter("@BD040",SqlDbType.NVarChar,2000),
                new SqlParameter("@BD041",SqlDbType.NVarChar,2000)
            };
            parameter[0].Value = _model.BD001;
            parameter[1].Value = _model.BD002;
            parameter[2].Value = _model.BD004;
            parameter[3].Value = _model.BD006;
            parameter[4].Value = _model.BD007;
            parameter[5].Value = _model.BD008;
            parameter[6].Value = _model.BD009;
            parameter[7].Value = _model.BD010;
            parameter[8].Value = _model.BD011;
            parameter[9].Value = _model.BD012;
            parameter[10].Value = _model.BD013;
            parameter[11].Value = _model.BD014;
            parameter[12].Value = _model.BD040;
            parameter[13].Value = _model.BD041;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 复制一条记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Copys ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQBD (" );
            strSql.Append( "BD002,BD003,BD004,BD005,BD006,BD007,BD008,BD009,BD010,BD011,BD012,BD013,BD014,BD015,BD016,BD017,BD018,BD019,BD020,BD021,BD022,BD023,BD024,BD025,BD026,BD027,BD028,BD029,BD030,BD031,BD032,BD033,BD034,BD035,BD036,BD037,BD038,BD039) SELECT BD002,BD003,BD004,BD005,BD006,BD007,BD008,BD009,BD010,BD011,BD012,BD013,BD014,BD015,BD016,BD017,BD018,BD019,BD020,BD021,BD022,BD023,BD024,BD025,BD026,BD027,BD028,BD029,BD030,BD031,BD032,BD033,BD034,BD035,BD036,BD037,BD038,BD039 FROM R_PQBD WHERE BD001=@BD001" );
            SqlParameter[] parameter = {
                new SqlParameter("@BD001",SqlDbType.NVarChar)
            };
            parameter[0].Value = oddNum;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 编辑复制记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateCopy ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQBD SET " );
            strSql.Append( " BD001=@BD001" );
            strSql.Append( " WHERE BD001 IS NULL" );
            SqlParameter[] parameter = {
                new SqlParameter("@BD001",SqlDbType.NVarChar)
            };
            parameter[0].Value = oddNum;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除复制记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DleteCopy ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQBD WHERE BD001 IS NULL" );

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOf ( string oddNum ,string num )
        {
            MulaolaoLibrary.R_FrmProductQualityLibrary _model = new MulaolaoLibrary.R_FrmProductQualityLibrary( );
            _model.BD001 = oddNum;
            _model.BD003 = num; string maxNum = ""; List<int> strList = new List<int>( );
            ArrayList SQLString = new ArrayList( );
            DataTable da = GetDataTableOfLj( num );
            if ( da != null && da.Rows.Count > 0 )
            {
                DataTable de=SqlHelper.ExecuteDataTable("SELECT BD001,BD043,BD003,BD015,BD042 FROM R_PQBD WHERE BD001='"+_model.BD001+"'");
                for ( int i = 0 ; i < da.Rows.Count ; i++ )
                {
                    _model.BD015 = da.Rows[i]["DS03"].ToString( );
                    _model.BD042 = da.Rows[i]["DS04"].ToString( );
                    if ( de != null && de . Rows . Count > 0 )
                    {
                        if ( de . Select ( "BD003='" + _model . BD003 + "' AND BD015='" + _model . BD015 + "' AND BD042='" + _model . BD042 + "'" ) . Length > 0 )
                        {
                            _model . BD043 = de . Select ( "BD003='" + _model . BD003 + "' AND BD015='" + _model . BD015 + "' AND BD042='" + _model . BD042 + "'" ) [ 0 ] [ "BC043" ] . ToString ( );
                            SQLString . Add ( UpdateOfAll ( _model ) );
                        }
                        else
                        {
                            maxNum = de . Compute ( "MAX(BD043)" , null ) . ToString ( );
                            if ( !string . IsNullOrEmpty ( maxNum ) )
                            {
                                if ( Convert . ToInt32 ( maxNum ) < 9 )
                                    _model . BD043 = "00" + ( Convert . ToInt32 ( maxNum ) + 1 );
                                else if ( Convert . ToInt32 ( maxNum ) >= 9 && Convert . ToInt32 ( maxNum ) < 99 )
                                    _model . BD043 = "0" + ( Convert . ToInt32 ( maxNum ) + 1 );
                                else
                                    _model . BD043 = ( Convert . ToInt32 ( maxNum ) + 1 ) . ToString ( );
                            }
                            else
                            {
                                if ( strList . Count > 0 )
                                {
                                    maxNum = strList . Max ( ) . ToString ( );
                                    if ( Convert . ToInt32 ( maxNum ) < 9 )
                                        _model . BD043 = "00" + ( Convert . ToInt32 ( maxNum ) + 1 );
                                    else if ( Convert . ToInt32 ( maxNum ) >= 9 && Convert . ToInt32 ( maxNum ) < 99 )
                                        _model . BD043 = "0" + ( Convert . ToInt32 ( maxNum ) + 1 );
                                    else
                                        _model . BD043 = ( Convert . ToInt32 ( maxNum ) + 1 ) . ToString ( );
                                }
                                else
                                    _model . BD043 = "001";
                                strList . Add ( Convert . ToInt32 ( _model . BD043 ) );
                            }
                            SQLString . Add ( Add ( _model ) );
                        }
                    }
                    else
                    {
                        if ( strList . Count > 0 )
                        {
                            maxNum = strList . Max ( ) . ToString ( );
                            if ( Convert . ToInt32 ( maxNum ) < 9 )
                                _model . BD043 = "00" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else if ( Convert . ToInt32 ( maxNum ) >= 9 && Convert . ToInt32 ( maxNum ) < 99 )
                                _model . BD043 = "0" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else
                                _model . BD043 = ( Convert . ToInt32 ( maxNum ) + 1 ) . ToString ( );
                        }
                        else
                            _model . BD043 = "001";
                        strList . Add ( Convert . ToInt32 ( _model . BD043 ) );
                        SQLString . Add ( Add ( _model ) );
                    }
                }
            }
            SqlHelper.ExecuteSqlTran( SQLString );

            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQBD" );
            strSql.Append( " WHERE BD001=@BD001" );
            SqlParameter[] parameter = {
                new SqlParameter("@BD001",SqlDbType.NVarChar)
                };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public DataTable GetDataTableOf ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQBD" );
            strSql.Append( " WHERE BD001=@BD001" );
            SqlParameter[] parameter = {
                new SqlParameter("@BD001",SqlDbType.NVarChar)
                };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        public bool ExistsOf ( MulaolaoLibrary.R_FrmProductQualityLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQBD" );
            strSql.Append( " WHERE BD001=@BD001 AND BD003=@BD003 AND BD015=@BD015 AND BD042=@BD042" );
            SqlParameter[] parameter = {
                new SqlParameter("@BD001",SqlDbType.NVarChar,20),
                new SqlParameter("@BD003",SqlDbType.NVarChar,20),
                new SqlParameter("@BD015",SqlDbType.NVarChar,20),
                new SqlParameter("@BD042",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = _model.BD001;
            parameter[1].Value = _model.BD003;
            parameter[2].Value = _model.BD015;
            parameter[3].Value = _model.BD042;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }
        public string Add ( MulaolaoLibrary.R_FrmProductQualityLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQBD (" );
            strSql.Append( "BD001,BD043,BD015,BD042)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}')" ,_model.BD001 ,_model.BD043 ,_model.BD015 ,_model.BD042 );

            return strSql.ToString( );
        }
        public string UpdateOfAll ( MulaolaoLibrary . R_FrmProductQualityLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql . Append ( "UPDATE R_PQBD SET" );
            strSql . AppendFormat ( "BD015='{0}'," , _model . BD015 );
            strSql . AppendFormat ( "BD042='{0}'" , _model . BD042 );
            strSql . AppendFormat ( " WHERE BD001='{0}' AND BD043='{1}'" , _model . BD001 , _model . BD043 );

            return strSql . ToString ( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfLj ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DS03,DS04 FROM R_PQR WHERE DS01=@DS01" );
            SqlParameter[] parameter = {
                new SqlParameter("@DS01",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public MulaolaoLibrary.R_FrmProductQualityLibrary GetModel ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQBD" );
            strSql.Append( " WHERE BD001=@BD001" );
            SqlParameter[] parameter = {
                new SqlParameter("@BD001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da != null && da.Rows.Count > 0 )
                return GetDataRow( da.Rows[0] );
            else
                return null;
        }

        /// <summary>
        /// 得到数据集
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.R_FrmProductQualityLibrary GetDataRow ( DataRow row )
        {
            MulaolaoLibrary.R_FrmProductQualityLibrary _model = new MulaolaoLibrary.R_FrmProductQualityLibrary( );

            if ( row != null )
            {
                if ( row["BD001"] != null && row["BD001"].ToString( ) != "" )
                    _model.BD001 = row["BD001"].ToString( );
                if ( row["BD002"] != null && row["BD002"].ToString( ) != "" )
                    _model.BD002 = row["BD002"].ToString( );
                if ( row["BD003"] != null && row["BD003"].ToString( ) != "" )
                    _model.BD003 = row["BD003"].ToString( );
                if ( row["BD004"] != null && row["BD004"].ToString( ) != "" )
                    _model.BD004 = row["BD004"].ToString( );
                if ( row["BD006"] != null && row["BD006"].ToString( ) != "" )
                    _model.BD006 = row["BD006"].ToString( );
                if ( row["BD007"] != null && row["BD007"].ToString( ) != "" )
                    _model.BD007 = row["BD007"].ToString( );
                if ( row["BD008"] != null && row["BD008"].ToString( ) != "" )
                    _model.BD008 = row["BD008"].ToString( );
                if ( row["BD009"] != null && row["BD009"].ToString( ) != "" )
                    _model.BD009 = row["BD009"].ToString( );
                if ( row["BD010"] != null && row["BD010"].ToString( ) != "" )
                    _model.BD010 = DateTime.Parse( row["BD010"].ToString( ) );
                if ( row["BD011"] != null && row["BD011"].ToString( ) != "" )
                    _model.BD011 = DateTime.Parse( row["BD011"].ToString( ) );
                if ( row["BD012"] != null && row["BD012"].ToString( ) != "" )
                    _model.BD012 = DateTime.Parse( row["BD012"].ToString( ) );
                if ( row["BD013"] != null && row["BD013"].ToString( ) != "" )
                    _model.BD013 = DateTime.Parse( row["BD013"].ToString( ) );
                if ( row["BD014"] != null && row["BD014"].ToString( ) != "" )
                    _model.BD014 = int.Parse( row["BD014"].ToString( ) );
                if ( row["BD040"] != null && row["BD040"].ToString( ) != "" )
                    _model.BD040 = row["BD040"].ToString( );
                if ( row["BD041"] != null && row["BD041"].ToString( ) != "" )
                    _model.BD041 = row["BD041"].ToString( );
            }

            return _model;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT BD001,BD002,BD003,BD004 FROM R_PQBD" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM (SELECT DISTINCT BD001,BD002,BD003,BD004 FROM R_PQBD" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") A" );

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
            strSql.Append( "SELECT DISTINCT BD001,BD002,BD003,BD004,RES05 FROM (" );
            strSql.Append( "SELECT ROW_NUMBER() OVER (" );
            strSql.Append( "ORDER BY T.BD001 DESC" );
            strSql.Append( ") AS Row,T.* FROM R_PQBD T" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( " ) TT LEFT JOIN R_REVIEWS A ON TT.BD001=A.RES06" );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrint ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT BD015,BD016,BD017,CONVERT(VARCHAR(20),BD018,102) BD018,BD019,BD020,BD021,BD022,BD023,BD024,BD025,BD026,BD027,BD028,BD029,BD030,BD031,BD032,BD033,BD034,BD035,BD036,BD037,BD038,BD039,BD042 FROM R_PQBD" );
            strSql.Append( " WHERE BD001=@BD001" );
            SqlParameter[] parameter = {
                new SqlParameter("@BD001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取打印数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableExport ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT BD002,BD003,BD004,BD006,BD007,BD008,BD009,CONVERT(VARCHAR(20),BD010,102) BD010,CONVERT(VARCHAR(20),BD011,102) BD011,CONVERT( VARCHAR( 20 ) ,BD012 ,102 ) BD012 ,CONVERT( VARCHAR( 20 ) ,BD013 ,102 ) BD013 ,BD014 ,BD005 FROM R_PQBD" );
            strSql.Append( " WHERE BD001=@BD001" );
            SqlParameter[] parameter = {
                new SqlParameter("@BD001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
    }
}

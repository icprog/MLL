using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentMgr;
using System.Data.SqlClient;
using System.Data;

namespace MulaolaoBll.Dao
{
    public class QualityTestingDao
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
            strSql.Append( "DELETE FROM R_PQBC" );
            strSql.AppendFormat( " WHERE BC001='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            StringBuilder strSq = new StringBuilder( );
            strSq.Append( "DELETE FROM R_REVIEWS" );
            strSq.AppendFormat( " WHERE RES06='{0}'" ,oddNum );
            SQLString.Add( strSq.ToString( ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 复制一条记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Copys ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQBC (" );
            strSql.Append( "BC002,BC003,BC004,BC005,BC006,BC007,BC008,BC009,BC010,BC011,BC012,BC013,BC014,BC015,BC016,BC017,BC018,BC019,BC020,BC021,BC022,BC023,BC024,BC025,BC026,BC027,BC028,BC029,BC030,BC031,BC032,BC033,BC034,BC035,BC036,BC037,BC038,BC039) SELECT BC002,BC003,BC004,BC005,BC006,BC007,BC008,BC009,BC010,BC011,BC012,BC013,BC014,BC015,BC016,BC017,BC018,BC019,BC020,BC021,BC022,BC023,BC024,BC025,BC026,BC027,BC028,BC029,BC030,BC031,BC032,BC033,BC034,BC035,BC036,BC037,BC038,BC039 FROM R_PQBC WHERE BC001=@BC001" );
            SqlParameter[] parameter = {
                new SqlParameter("@BC001",SqlDbType.NVarChar)
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
            strSql.Append( "UPDATE R_PQBC SET " );
            strSql.Append( " BC001=@BC001" );
            strSql.Append( " WHERE BC001 IS NULL" );
            SqlParameter[] parameter = {
                new SqlParameter("@BC001",SqlDbType.NVarChar)
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
        public bool DleteCopy (  )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQBC WHERE BC001 IS NULL" );

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 保存表数据
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool SaveOf ( DataTable table )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQBC WHERE 1=2" );

            return SqlHelper.UpdateTable( table ,strSql.ToString( ) );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool SaveOfUpdate ( MulaolaoLibrary.QualityTestingLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQBC SET " );
            strSql.Append( "BC002=@BC002," );
            strSql.Append( "BC004=@BC004," );
            strSql.Append( "BC006=@BC006," );
            strSql.Append( "BC007=@BC007," );
            strSql.Append( "BC008=@BC008," );
            strSql.Append( "BC009=@BC009," );
            strSql.Append( "BC010=@BC010," );
            strSql.Append( "BC011=@BC011," );
            strSql.Append( "BC012=@BC012," );
            strSql.Append( "BC013=@BC013," );
            strSql.Append( "BC014=@BC014," );
            strSql.Append( "BC040=@BC040," );
            strSql.Append( "BC041=@BC041" );
            strSql.Append( " WHERE BC001=@BC001" );
            SqlParameter[] parameter = {
                new SqlParameter("@BC001",SqlDbType.NVarChar,20),
                new SqlParameter("@BC002",SqlDbType.NVarChar,20),
                new SqlParameter("@BC004",SqlDbType.NVarChar,20),
                new SqlParameter("@BC006",SqlDbType.NVarChar,20),
                new SqlParameter("@BC007",SqlDbType.NVarChar,20),
                new SqlParameter("@BC008",SqlDbType.NVarChar,20),
                new SqlParameter("@BC009",SqlDbType.NVarChar,20),
                new SqlParameter("@BC010",SqlDbType.Date),
                new SqlParameter("@BC011",SqlDbType.Date),
                new SqlParameter("@BC012",SqlDbType.Date),
                new SqlParameter("@BC013",SqlDbType.Date),
                new SqlParameter("@BC014",SqlDbType.Int),
                new SqlParameter("@BC040",SqlDbType.NVarChar,2000),
                new SqlParameter("@BC041",SqlDbType.NVarChar,2000)
            };
            parameter[0].Value = _model.BC001;
            parameter[1].Value = _model.BC002;
            parameter[2].Value = _model.BC004;
            parameter[3].Value = _model.BC006;
            parameter[4].Value = _model.BC007;
            parameter[5].Value = _model.BC008;
            parameter[6].Value = _model.BC009;
            parameter[7].Value = _model.BC010;
            parameter[8].Value = _model.BC011;
            parameter[9].Value = _model.BC012;
            parameter[10].Value = _model.BC013;
            parameter[11].Value = _model.BC014;
            parameter[12].Value = _model.BC040;
            parameter[13].Value = _model.BC041;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
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
            MulaolaoLibrary.QualityTestingLibrary _model = new MulaolaoLibrary.QualityTestingLibrary( );
            _model.BC001 = oddNum;
            _model.BC003 = num; 
            string maxNum = ""; List<int> strList = new List<int>( );
            ArrayList SQLString = new ArrayList( );
            DataTable da = GetDataTableOfLj( num );
            if ( da != null && da.Rows.Count > 0 )
            {
                DataTable de=SqlHelper.ExecuteDataTable("SELECT BC001,BC043,BC003,BC015,BC042 FROM R_PQBC WHERE BC001='"+_model.BC001+"'");
                for ( int i = 0 ; i < da.Rows.Count ; i++ )
                {
                    _model.BC015 = da.Rows[i]["DS03"].ToString( );
                    _model.BC042 = da.Rows[i]["DS04"].ToString( );

                    if ( de != null && de . Rows . Count > 0 )
                    {
                        if ( de . Select ( "BC003='" + _model . BC003 + "' AND BC015='" + _model . BC015 + "' AND BC042='" + _model . BC042 + "'" ) . Length > 0 )
                        {
                            _model . BC043 = de . Select ( "BC003='" + _model . BC003 + "' AND BC015='" + _model . BC015 + "' AND BC042='" + _model . BC042 + "'" ) [ 0 ] [ "BC043" ] . ToString ( );
                            SQLString . Add ( UpdateOfAll ( _model ) );
                        }
                        else
                        {
                            maxNum = de . Compute ( "MAX(BC043)" , null ) . ToString ( );
                            if ( !string . IsNullOrEmpty ( maxNum ) )
                            {
                                if ( Convert . ToInt32 ( maxNum ) < 9 )
                                    _model . BC043 = "00" + ( Convert . ToInt32 ( maxNum ) + 1 );
                                else if ( Convert . ToInt32 ( maxNum ) >= 9 && Convert . ToInt32 ( maxNum ) < 99 )
                                    _model . BC043 = "0" + ( Convert . ToInt32 ( maxNum ) + 1 );
                                else
                                    _model . BC043 = ( Convert . ToInt32 ( maxNum ) + 1 ) . ToString ( );
                            }
                            else
                            {
                                if ( strList . Count > 0 )
                                {
                                    maxNum = strList . Max ( ) . ToString ( );
                                    if ( Convert . ToInt32 ( maxNum ) < 9 )
                                        _model . BC043 = "00" + ( Convert . ToInt32 ( maxNum ) + 1 );
                                    else if ( Convert . ToInt32 ( maxNum ) >= 9 && Convert . ToInt32 ( maxNum ) < 99 )
                                        _model . BC043 = "0" + ( Convert . ToInt32 ( maxNum ) + 1 );
                                    else
                                        _model . BC043 = ( Convert . ToInt32 ( maxNum ) + 1 ) . ToString ( );
                                }
                                else
                                    _model . BC043 = "001";
                                strList . Add ( Convert . ToInt32 ( _model . BC043 ) );                     
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
                                _model . BC043 = "00" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else if ( Convert . ToInt32 ( maxNum ) >= 9 && Convert . ToInt32 ( maxNum ) < 99 )
                                _model . BC043 = "0" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else
                                _model . BC043 = ( Convert . ToInt32 ( maxNum ) + 1 ) . ToString ( );
                        }
                        else
                            _model . BC043 = "001";
                        strList . Add ( Convert . ToInt32 ( _model . BC043 ) );
                        SQLString . Add ( Add ( _model ) );
                    }
                }
            }

            SqlHelper.ExecuteSqlTran( SQLString );

            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQBC" );
            strSql.Append( " WHERE BC001=@BC001" );
            SqlParameter[] parameter = {
                new SqlParameter("@BC001",SqlDbType.NVarChar)
                };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public DataTable GetDataTableOf ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQBC" );
            strSql.Append( " WHERE BC001=@BC001" );
            SqlParameter[] parameter = {
                new SqlParameter("@BC001",SqlDbType.NVarChar)
                };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        public bool ExistsOf ( MulaolaoLibrary.QualityTestingLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQBC" );
            strSql.Append( " WHERE BC001=@BC001 AND BC003=@BC003 AND BC015=@BC015 AND BC042=@BC042" );
            SqlParameter[] parameter = {
                new SqlParameter("@BC001",SqlDbType.NVarChar,20),
                new SqlParameter("@BC003",SqlDbType.NVarChar,20),
                new SqlParameter("@BC015",SqlDbType.NVarChar,20),
                new SqlParameter("@BC042",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = _model.BC001;
            parameter[1].Value = _model.BC003;
            parameter[2].Value = _model.BC015;
            parameter[3].Value = _model.BC042;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }
        public string Add ( MulaolaoLibrary.QualityTestingLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQBC (" );
            strSql.Append( "BC001,BC043,BC015,BC042)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}')" ,_model.BC001 ,_model.BC043 ,_model.BC015 ,_model.BC042 );

            return strSql.ToString( );
        }
        public string UpdateOfAll ( MulaolaoLibrary . QualityTestingLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql . Append ( "UPDATE R_PQBC SET" );
            strSql . AppendFormat ( "BC015='{0}'," , _model . BC015 );
            strSql . AppendFormat ( "BC042='{0}'" , _model . BC042 );
            strSql . AppendFormat ( " WHERE BC001='{0}' AND BC043='{1}'" , _model . BC001 , _model . BC043 );

            return strSql . ToString ( );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public MulaolaoLibrary.QualityTestingLibrary GetModel ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQBC" );
            strSql.Append( " WHERE BC001=@BC001" );
            SqlParameter[] parameter = {
                new SqlParameter("@BC001",SqlDbType.NVarChar,20)
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
        public MulaolaoLibrary.QualityTestingLibrary GetDataRow ( DataRow row )
        {
            MulaolaoLibrary.QualityTestingLibrary _model = new MulaolaoLibrary.QualityTestingLibrary( );

            if ( row != null )
            {
                if ( row["BC001"] != null && row["BC001"].ToString( ) != "" )
                    _model.BC001 = row["BC001"].ToString( );
                if ( row["BC002"] != null && row["BC002"].ToString( ) != "" )
                    _model.BC002 = row["BC002"].ToString( );
                if ( row["BC003"] != null && row["BC003"].ToString( ) != "" )
                    _model.BC003 = row["BC003"].ToString( );
                if ( row["BC004"] != null && row["BC004"].ToString( ) != "" )
                    _model.BC004 = row["BC004"].ToString( );
                if ( row["BC006"] != null && row["BC006"].ToString( ) != "" )
                    _model.BC006 = row["BC006"].ToString( );
                if ( row["BC007"] != null && row["BC007"].ToString( ) != "" )
                    _model.BC007 = row["BC007"].ToString( );
                if ( row["BC008"] != null && row["BC008"].ToString( ) != "" )
                    _model.BC008 = row["BC008"].ToString( );
                if ( row["BC009"] != null && row["BC009"].ToString( ) != "" )
                    _model.BC009 = row["BC009"].ToString( );
                if ( row["BC010"] != null && row["BC010"].ToString( ) != "" )
                    _model.BC010 = DateTime.Parse( row["BC010"].ToString( ) );
                if ( row["BC011"] != null && row["BC011"].ToString( ) != "" )
                    _model.BC011 = DateTime.Parse( row["BC011"].ToString( ) );
                if ( row["BC012"] != null && row["BC012"].ToString( ) != "" )
                    _model.BC012 = DateTime.Parse( row["BC012"].ToString( ) );
                if ( row["BC013"] != null && row["BC013"].ToString( ) != "" )
                    _model.BC013 = DateTime.Parse( row["BC013"].ToString( ) );
                if ( row["BC014"] != null && row["BC014"].ToString( ) != "" )
                    _model.BC014 = int.Parse( row["BC014"].ToString( ) );
                if ( row["BC040"] != null && row["BC040"].ToString( ) != "" )
                    _model.BC040 = row["BC040"].ToString( );
                if ( row["BC041"] != null && row["BC041"].ToString( ) != "" )
                    _model.BC041 = row["BC041"].ToString( );
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
            strSql.Append( "SELECT DISTINCT BC001,BC002,BC003,BC004 FROM R_PQBC" );

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
            strSql.Append( "SELECT COUNT(1) FROM (SELECT DISTINCT BC001,BC002,BC003,BC004 FROM R_PQBC" );
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
            strSql.Append( "SELECT DISTINCT BC001,BC002,BC003,BC004,RES05 FROM (" );
            strSql.Append( "SELECT ROW_NUMBER() OVER (" );
            strSql.Append( "ORDER BY T.BC001 DESC" );
            strSql.Append( ") AS Row,T.* FROM R_PQBC T" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( " ) TT LEFT JOIN R_REVIEWS A ON TT.BC001=A.RES06" );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfLj (string num )
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
        /// <returns></returns>
        public DataTable GetDataTableOfNum ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "SELECT PQF01,PQF03,PQF04,PQF06 FROM R_PQF A LEFT JOIN R_REVIEWS B ON A.PQF01=B.RES06 AND RES05='执行'" );

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
            strSql.Append( "SELECT BC015,BC016,BC017,CONVERT(VARCHAR(20),BC018,102) BC018,BC019,BC020,BC021,BC022,BC023,BC024,BC025,BC026,BC027,BC028,BC029,BC030,BC031,BC032,BC033,BC034,BC035,BC036,BC037,BC038,BC039,BC042 FROM R_PQBC" );
            strSql.Append( " WHERE BC001=@BC001" );
            SqlParameter[] parameter = {
                new SqlParameter("@BC001",SqlDbType.NVarChar,20)
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
            strSql.Append( "SELECT BC002,BC003,BC004,BC006,BC007,BC008,BC009,CONVERT(VARCHAR(20),BC010,102) BC010,CONVERT(VARCHAR(20),BC011,102) BC011,CONVERT(VARCHAR(20),BC012,102) BC012,CONVERT(VARCHAR(20),BC013,102) BC013,BC014,BC005 FROM R_PQBC" );
            strSql.Append( " WHERE BC001=@BC001" );
            SqlParameter[] parameter = {
                new SqlParameter("@BC001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
    }
}

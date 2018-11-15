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
    public class WaiXianDao
    {
        /// <summary>
        /// 获取流水信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableNum ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT WX82,WX01,WX83,WX84,WX85,CASE WHEN OZ015!='' THEN '已生成' ELSE '未生成' END U1 FROM R_PQT A LEFT JOIN R_REVIEWS B ON A.WX82=B.RES06 AND RES05='执行' LEFT JOIN R_PQOZ C ON A.WX82=C.OZ015 WHERE WX01 LIKE '%,%' ORDER BY WX82 DESC" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 生成
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool GetDataTableGener ( string num ,string oddNum,string oddNumOf349)
        {
            bool result = false;
            ArrayList SQLString = new ArrayList( );
            MulaolaoLibrary.WaiXianLibrary _model = new MulaolaoLibrary.WaiXianLibrary( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT WX10,WX03,WX15,WX82,SUM(CASE WHEN WX10='双瓦外箱' THEN ((WX27 + WX28 + WX29) * (WX30 + WX31 + WX32) + (WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15  WHEN WX10='小箱式' THEN  ((WX27 + WX28 + WX29) * (WX30 + WX31 + WX32) + (WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15 WHEN WX10='牙膏式' THEN  ((WX27 + 2*WX28 + WX29) * (2*WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15  WHEN WX10='插口式' THEN  ((WX27 + 2*WX28 + WX29) * (2*WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15  WHEN WX10='天盖' THEN ((WX27 + 2*WX28 + WX29) * (WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15  WHEN WX10='地盖' THEN ((WX27 + 2*WX28 + WX29) * (WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10='折叠式' THEN ((2*WX27 + 2*WX28 + WX29) * (1.5*WX30 + WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10 NOT IN ('双瓦外箱','小箱式','牙膏式','插口式','天盖','地盖','折叠式') THEN (WX23 + WX24) * (WX25 + WX26) * 0.0001 * WX13* WX15 END) PQ FROM R_PQT " );
            strSql.Append( "WHERE WX82=@WX82" );
            strSql.Append( " GROUP BY WX10,WX15,WX03,WX82" );
            SqlParameter[] parameter = {
                new SqlParameter("@WX82",SqlDbType.NVarChar,2000)
            };
            parameter[0].Value = oddNumOf349;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da.Rows.Count > 0 )
            {
                string[] str = num.Split( ',' );
                foreach ( string s in str )
                {
                    StringBuilder strS = new StringBuilder( );
                    strS.Append( "SELECT PQF02,PQF03,PQF04,PQF06 FROM R_PQF WHERE PQF01=@PQF01" );
                    SqlParameter[] paramete = {
                        new SqlParameter("@PQF01",SqlDbType.NVarChar,20)
                    };
                    paramete[0].Value = s;
                    DataTable de = SqlHelper.ExecuteDataTable( strS.ToString( ) ,paramete );
                    if ( de.Rows.Count > 0 )
                    {
                        _model.OZ001 = s;
                        _model.OZ002 = de.Rows[0]["PQF04"].ToString( );
                        _model.OZ003 = de.Rows[0]["PQF03"].ToString( );
                        _model.OZ004 = de.Rows[0]["PQF02"].ToString( );
                        _model.OZ005 = string.IsNullOrEmpty( de.Rows[0]["PQF06"].ToString( ) ) == true ? 0 : Convert.ToInt32( de.Rows[0]["PQF06"].ToString( ) );
                        _model.OZ006 = 0M;
                        for ( int i = 0 ; i < da.Rows.Count ; i++ )
                        {
                            _model.OZ007 = da.Rows[i]["WX10"].ToString( );
                            _model.OZ008 = string.IsNullOrEmpty( da.Rows[i]["WX15"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[i]["WX15"].ToString( ) );
                            _model.OZ009 = string.IsNullOrEmpty( da.Rows[i]["PQ"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[i]["PQ"].ToString( ) );
                            _model.OZ010 = num;
                            _model.OZ011 = oddNum;
                            _model.OZ014 = da.Rows[i]["WX03"].ToString( );
                            _model.OZ015 = da.Rows[i]["WX82"].ToString( );
                            StringBuilder strSq = new StringBuilder( );
                            strSq.Append( "SELECT COUNT(1) FROM R_PQOZ" );
                            strSq.Append( " WHERE OZ001=@OZ001 AND OZ011=@OZ011 AND OZ007=@OZ007 AND OZ014=@OZ014 AND OZ015=@OZ015" );
                            SqlParameter[] parame = {
                                new SqlParameter("@OZ001",SqlDbType.NVarChar,20),
                                new SqlParameter("@OZ011",SqlDbType.NVarChar,20),
                                new SqlParameter("@OZ007",SqlDbType.NVarChar,20),
                                new SqlParameter("@OZ014",SqlDbType.NVarChar,20),
                                new SqlParameter("@OZ015",SqlDbType.NVarChar,20)
                            };
                            parame[0].Value = _model.OZ001;
                            parame[1].Value = oddNum;
                            parame[2].Value = _model.OZ007;
                            parame[3].Value = _model.OZ014;
                            parame[4].Value = _model.OZ015;
                            if ( SqlHelper.Exists( strSq.ToString( ) ,parame ) == true )
                            {
                                StringBuilder strSqlEdit = new StringBuilder( );
                                strSqlEdit.Append( "UPDATE R_PQOZ SET " );
                                //strSqlEdit.AppendFormat( "OZ001='{0}'" ,_model.OZ001 );
                                strSqlEdit.AppendFormat( "OZ002='{0}'," ,_model.OZ002 );
                                strSqlEdit.AppendFormat( "OZ003='{0}'," ,_model.OZ003 );
                                strSqlEdit.AppendFormat( "OZ004='{0}'," ,_model.OZ004 );
                                strSqlEdit.AppendFormat( "OZ005='{0}'," ,_model.OZ005 );
                                //strSqlEdit.AppendFormat( "OZ006='{0}'," ,_model.OZ006 );
                                //strSqlEdit.AppendFormat( "OZ007='{0}'," ,_model.OZ007 );
                                strSqlEdit.AppendFormat( "OZ008='{0}'," ,_model.OZ008 );
                                strSqlEdit.AppendFormat( "OZ009='{0}'," ,_model.OZ009 );
                                strSqlEdit.AppendFormat( "OZ010='{0}'" ,_model.OZ010 );
                                //strSqlEdit.AppendFormat( "OZ011='{0}'" ,_model.OZ011 );
                                strSqlEdit.AppendFormat( " WHERE OZ001='{0}' AND OZ011='{1}' AND OZ007='{2}'  AND OZ014='{3}'  AND OZ015='{4}'" ,_model.OZ001 ,_model.OZ011 ,_model.OZ007 ,_model.OZ014 ,_model.OZ015 );
                                SQLString.Add( strSqlEdit );
                            }
                            else
                            {
                                StringBuilder strSqlAdd = new StringBuilder( );
                                strSqlAdd.Append( "INSERT INTO R_PQOZ (" );
                                strSqlAdd.Append( "OZ001,OZ002,OZ003,OZ004,OZ005,OZ006,OZ007,OZ008,OZ009,OZ010,OZ011,OZ014,OZ015)" );
                                strSqlAdd.Append( " VALUES (" );
                                strSqlAdd.AppendFormat( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')" ,_model.OZ001 ,_model.OZ002 ,_model.OZ003 ,_model.OZ004 ,_model.OZ005 ,_model.OZ006 ,_model.OZ007 ,_model.OZ008 ,_model.OZ009 ,_model.OZ010 ,_model.OZ011 ,_model.OZ014 ,_model.OZ015 );
                                SQLString.Add( strSqlAdd );
                            }
                        }
                    }
                    else
                        result = false;
                }
                result = SqlHelper.ExecuteSqlTran( SQLString );
            }
            else
                result = false;

            return result;
        }
        
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableAll ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,OZ001,OZ002,OZ003,OZ004,OZ005,OZ006,OZ007,OZ008,OZ009,OZ010,DGA003,OZ011 FROM R_PQOZ A LEFT JOIN TPADGA B ON A.OZ014=B.DGA001" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( " ORDER BY OZ001" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQOZ" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = idx;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="number"></param>
        /// <param name="every"></param>
        /// <returns></returns>
        public bool Update ( string num,long number,decimal every ,string oddNum)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQOZ SET " );
            strSql.Append( "OZ005=@OZ005," );
            strSql.Append( "OZ006=@OZ006" );
            strSql.Append( " WHERE  OZ011=@OZ011 AND OZ001=@OZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@OZ005",SqlDbType.BigInt),
                new SqlParameter("@OZ006",SqlDbType.Decimal,7),
                new SqlParameter("@OZ001",SqlDbType.NVarChar,20),
                new SqlParameter("@OZ011",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = number;
            parameter[1].Value = every;
            parameter[2].Value = num;
            parameter[3].Value = oddNum;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }
        public bool Update ( string num ,string oddNum ,long number ,decimal every )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQOZ SET " );
            strSql.Append( "OZ005=@OZ005," );
            strSql.Append( "OZ006=@OZ006" );
            strSql.Append( " WHERE OZ011=@OZ011 AND OZ001=@OZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@OZ005",SqlDbType.BigInt),
                new SqlParameter("@OZ006",SqlDbType.Decimal,7),
                new SqlParameter("@OZ011",SqlDbType.NVarChar,20),
                new SqlParameter("@OZ001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = number;
            parameter[1].Value = every;
            parameter[2].Value = oddNum;
            parameter[3].Value = num;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT OZ011,OZ001,OZ002,OZ003,OZ004 FROM R_PQOZ" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取供应商
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfSupplier ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT OZ014,DGA003 FROM R_PQOZ A LEFT JOIN TPADGA B ON A.OZ014=B.DGA001" );

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
            strSql.Append( "SELECT COUNT(1) FROM (SELECT DISTINCT OZ011,OZ001 FROM R_PQOZ" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") A" );

            object obj = SqlHelper.GetSingle( strSql.ToString( ) );
            if ( obj == null )
                return 0;
            else
                return Convert.ToInt32( obj );
        }

        public int GetCounts ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM (SELECT DISTINCT OZ011,OZ001 FROM R_PQOZ A INNER JOIN R_REVIEWS B ON A.OZ011=B.RES06 AND RES05='执行'" );
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
            strSql.Append( "WITH CET AS (SELECT SUM(OZ) OZ,OZ011 FROM (SELECT OZ005*OZ006 OZ,OZ011 FROM R_PQOZ GROUP BY OZ011,OZ005,OZ006,OZ001) A GROUP BY OZ011)" );
            strSql.Append( "SELECT DISTINCT OZ001,OZ002,OZ003,OZ004,TT.OZ011,DGA003,CASE WHEN OZ=0 THEN 0 ELSE SUM(OZ009)/OZ*OZ005*OZ006 END OZ,OZ005,(SELECT RES05 FROM R_REVIEWS WHERE RES06=TT.OZ011) RES05 FROM (" );
            strSql.Append( "SELECT ROW_NUMBER() OVER( " );
            strSql.Append( "ORDER BY T.OZ011 DESC" );
            strSql.Append( ") AS Row,T.* FROM R_PQOZ T" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") TT LEFT JOIN TPADGA B ON TT.OZ014=B.DGA001 LEFT JOIN CET C ON TT.OZ011=C.OZ011 " );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );
            strSql.Append( " GROUP BY OZ001,OZ002,OZ003,OZ004,TT.OZ011,DGA003,OZ,OZ005,OZ006" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        public DataTable GetDataTableByChangeOther ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "WITH CET AS (SELECT SUM(OZ) OZ,OZ011 FROM (SELECT OZ005*OZ006 OZ,OZ011 FROM R_PQOZ GROUP BY OZ011,OZ005,OZ006,OZ001) A GROUP BY OZ011)" );
            strSql.Append( "SELECT DISTINCT OZ001,OZ002,OZ003,OZ004,TT.OZ011,DGA003,CASE WHEN OZ=0 THEN 0 ELSE SUM(OZ009)/OZ*OZ005*OZ006 END OZ,OZ005, RES05 FROM (" );
            strSql.Append( "SELECT ROW_NUMBER() OVER( " );
            strSql.Append( "ORDER BY T.OZ011 DESC" );
            strSql.Append( ") AS Row,T.* FROM R_PQOZ T" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") TT LEFT JOIN TPADGA B ON TT.OZ014=B.DGA001 LEFT JOIN CET C ON TT.OZ011=C.OZ011 INNER JOIN R_REVIEWS D ON TT.OZ011=D.RES06 AND RES05='执行'" );
            strSql.AppendFormat( " WHERE NOT EXISTS (SELECT AK003,AK002 FROM R_PQAK WHERE TT.OZ011=AK003 AND TT.OZ001=AK002 AND (AK009-AK010-AK011-AK015)<=100) AND TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );//AND AK009=AK011
            strSql .Append( " GROUP BY OZ001,OZ002,OZ003,OZ004,TT.OZ011,DGA003,OZ,OZ005,OZ006,RES05" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public MulaolaoLibrary.WaiXianLibrary GetModel ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQOZ" );
            strSql.Append( " WHERE OZ011=@OZ011" );
            SqlParameter[] parameter = {
                new SqlParameter("@OZ011",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da.Rows.Count > 0 )
                return GetDataRow( da.Rows[0] );
            else
                return null;
        }
        public MulaolaoLibrary.WaiXianLibrary GetModel ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQOZ" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = idx;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
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
        public MulaolaoLibrary.WaiXianLibrary GetDataRow ( DataRow row )
        {
            MulaolaoLibrary.WaiXianLibrary _model = new MulaolaoLibrary.WaiXianLibrary( );

            if(row!=null)
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    _model.IDX = int.Parse( row["idx"].ToString( ) );
                if ( row["OZ001"] != null && row["OZ001"].ToString( ) != "" )
                    _model.OZ001 = row["OZ001"].ToString( );
                if ( row["OZ002"] != null && row["OZ002"].ToString( ) != "" )
                    _model.OZ002 = row["OZ002"].ToString( );
                if ( row["OZ003"] != null && row["OZ003"].ToString( ) != "" )
                    _model.OZ003 = row["OZ003"].ToString( );
                if ( row["OZ004"] != null && row["OZ004"].ToString( ) != "" )
                    _model.OZ004 = row["OZ004"].ToString( );
                if ( row["OZ005"] != null && row["OZ005"].ToString( ) != "" )
                    _model.OZ005 = long.Parse( row["OZ005"].ToString( ) );
                if ( row["OZ006"] != null && row["OZ006"].ToString( ) != "" )
                    _model.OZ006 = decimal.Parse( row["OZ006"].ToString( ) );
                if ( row["OZ007"] != null && row["OZ007"].ToString( ) != "" )
                    _model.OZ007 = row["OZ007"].ToString( );
                if ( row["OZ008"] != null && row["OZ008"].ToString( ) != "" )
                    _model.OZ008 = int.Parse( row["OZ008"].ToString( ) );
                if ( row["OZ009"] != null && row["OZ009"].ToString( ) != "" )
                    _model.OZ009 = decimal.Parse( row["OZ009"].ToString( ) );
                if ( row["OZ010"] != null && row["OZ010"].ToString( ) != "" )
                    _model.OZ010 = row["OZ010"].ToString( );
                if ( row["OZ011"] != null && row["OZ011"].ToString( ) != "" )
                    _model.OZ011 = row["OZ011"].ToString( );
                if ( row["OZ013"] != null && row["OZ013"].ToString( ) != "" )
                    _model.OZ013 = row["OZ013"].ToString( );
                if ( row["OZ015"] != null && row["OZ015"].ToString( ) != "" )
                    _model.OZ015 = row["OZ015"].ToString( );
            }

            return _model;
        }

        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQOZ" );
            strSql.AppendFormat( " WHERE OZ011='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            StringBuilder strS = new StringBuilder( );
            strS.Append( "DELETE FROM R_REVIEWS" );
            strS.AppendFormat( " WHERE RES06='{0}'" ,oddNum );
            SQLString.Add( strS.ToString( ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableWeiHu ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT OZ012 FROM R_PQOZ" );
            strSql.Append( " WHERE OZ011=@OZ011" );
            SqlParameter[] parameter = {
                new SqlParameter("@OZ011",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 更新维护记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="mainTainStation"></param>
        /// <param name="mainTainRecord"></param>
        /// <returns></returns>
        public bool UpdateMainTain ( string oddNum ,string mainTainStation ,string mainTainRecord )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQOZ SET " );
            strSql.Append( "OZ012=@OZ012," );
            strSql.Append( "OZ013=@OZ013" );
            strSql.Append( " WHERE OZ011=@OZ011" );
            SqlParameter[] parameter = {
                new SqlParameter("@OZ011",SqlDbType.NVarChar,20),
                new SqlParameter("@OZ012",SqlDbType.NVarChar,2000),
                new SqlParameter("@OZ013",SqlDbType.NVarChar,2000)
            };
            parameter[0].Value = oddNum;
            parameter[1].Value = mainTainStation;
            parameter[2].Value = mainTainRecord;

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
        public DataTable GetDataTableCount ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT OZ001,CASE WHEN SUM(OZ005*OZ006)=0 THEN 0 ELSE CONVERT(DECIMAL(18,2),SUM(OZ005)/SUM(OZ005*OZ006)) END U FROM R_PQOZ" );
            strSql.Append( " WHERE OZ011=@OZ011" );
            strSql.Append( " GROUP BY OZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@OZ011",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableSum ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT SUM(OZ008) OZ008 ,CONVERT(DECIMAL(18,2),SUM(OZ009)) OZ009 FROM (SELECT OZ007,OZ008,OZ009 FROM R_PQOZ" );
            strSql.Append( " WHERE OZ011=@OZ011" );
            strSql.Append( " GROUP BY OZ007,OZ008,OZ009) A" );
            SqlParameter[] parameter = {
                new SqlParameter("@OZ011",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableSums ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT SUM(OZ005) OZ005,SUM(OZ006) OZ006 FROM (SELECT OZ001,OZ005,OZ006 FROM R_PQOZ" );
            strSql.Append( " WHERE OZ011=@OZ011" );
            strSql.Append( " GROUP BY OZ001,OZ005,OZ006) A" );
            SqlParameter[] parameter = {
                new SqlParameter("@OZ011",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOf241 ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "WITH CET AS (SELECT SUM(OZ) OZ,OZ011,COUN FROM (SELECT OZ005*OZ006 OZ,OZ011,COUNT(1) COUN FROM R_PQOZ GROUP BY OZ011,OZ005,OZ006) A GROUP BY OZ011,COUN)" );
            strSql.Append( "SELECT OZ001,SUM(OZ) OZ,WX90 FROM (SELECT OZ001,CASE WHEN OZ=0 THEN 0 ELSE CONVERT(DECIMAL(18,0),SUM(OZ009)/OZ*OZ005*OZ006/COUN) END OZ,WX90 FROM R_PQOZ TT LEFT JOIN TPADGA B ON TT.OZ014=B.DGA001 LEFT JOIN CET C ON TT.OZ011=C.OZ011  INNER JOIN R_REVIEWS D ON TT.OZ011=D.RES06 AND RES05='执行' LEFT JOIN R_PQT E ON TT.OZ015=E.WX82" );
            strSql.Append( " WHERE TT.OZ011=@OZ011" );
            strSql.Append( " GROUP BY OZ001,TT.OZ011,OZ,OZ005,OZ006,WX90,COUN) A GROUP BY OZ001,WX90" );
            SqlParameter[] parameter = {
                new SqlParameter("@OZ011",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
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
            //WriteReceivableToGeneralLedger.ByOneByLiao( modelAm ,oddNum ,SQLString );
            StringBuilder strSql = new StringBuilder( );
            if ( modelAm.AM139 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM139='{0}' WHERE AM002='{1}'" ,modelAm.AM139 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( modelAm.AM144 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM144='{0}' WHERE AM002='{1}'" ,modelAm.AM144 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        
        void ByOneBy ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AMB139,AMB144 FROM R_PQAMB" );
            strSql.AppendFormat( " WHERE AMB001='{0}' AND AMB002='{1}'" ,oddNum ,modelAm.AM002 );

            DataTable de = SqlHelper.ExecuteDataTable( "SELECT AM139,AM144 FROM R_PQAM WHERE AM002='" + modelAm.AM002 + "'" );
            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            if ( da != null && da.Rows.Count > 0 )
            {
                if ( modelAm.AM139 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB139='{0}' WHERE AMB001='{1}' AND AMB002='{2}'" ,modelAm.AM139 ,oddNum ,modelAm.AM002 );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM144 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB144='{0}' WHERE AMB001='{1}' AND AMB002='{2}'" ,modelAm.AM144 ,oddNum ,modelAm.AM002 );
                    SQLString.Add( strSql.ToString( ) );
                }

                if ( de != null && de.Rows.Count > 0 )
                {
                    modelAm.AM139 = modelAm.AM139 - ( string.IsNullOrEmpty( da.Rows[0]["AMB139"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB139"].ToString( ) ) );
                    modelAm.AM144 = modelAm.AM144 - ( string.IsNullOrEmpty( da.Rows[0]["AMB144"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB144"].ToString( ) ) );
                    
                    modelAm.AM139 = modelAm.AM139 + ( string.IsNullOrEmpty( de.Rows[0]["AM139"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM139"].ToString( ) ) );
                    modelAm.AM144 = modelAm.AM144 + ( string.IsNullOrEmpty( de.Rows[0]["AM144"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM144"].ToString( ) ) );
                }

            }
            else
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "INSERT INTO R_PQAMB (AMB001,AMB002,AMB139,AMB144) VALUES ('{0}','{1}','{2}','{3}')" ,oddNum ,modelAm.AM002 ,modelAm.AM139 ,modelAm.AM144 );
                SQLString.Add( strSql.ToString( ) );
                if ( de != null && de.Rows.Count > 0 )
                {
                    modelAm.AM139 = modelAm.AM139 + ( string.IsNullOrEmpty( de.Rows[0]["AM139"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM139"].ToString( ) ) );
                    modelAm.AM144 = modelAm.AM144 + ( string.IsNullOrEmpty( de.Rows[0]["AM144"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM144"].ToString( ) ) );
                }

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using StudentMgr;
using System.Collections;

namespace MulaolaoBll.Dao
{
    public class GunQiChenBenDao
    {
        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary . GunQiChenBenLibrary _model ,string logins )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQPZ SET " );
            strSql . AppendFormat ( "PZ017=@PZ017," );
            strSql . AppendFormat ( "PZ036=@PZ036" );
            strSql . AppendFormat ( " WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PZ017",SqlDbType.Decimal,6),
                new SqlParameter("@PZ036",SqlDbType.Decimal,6),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter [ 0 ] . Value = _model . PZ017;
            parameter [ 1 ] . Value = _model . PZ036;
            parameter [ 2 ] . Value = _model . IDX;
            SQLString . Add ( strSql ,parameter );
            SQLString . Add ( Drity . DrityOfComparation ( "R_346" ,"产品滚漆成本汇总表(R_346)" ,logins ,DateTime . Now ,_model . PZ001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"编辑" ,"编辑" ) ,null );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Delete ( int idx ,string logins ,string oddNum )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQPZ " );
            strSql . AppendFormat ( " WHERE idx={0}" ,idx );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_346" ,"产品滚漆成本汇总表(R_346)" ,logins ,DateTime . Now ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        public bool Delete ( )
        {
            ArrayList SQLString = new ArrayList( );
            MulaolaoLibrary.GunQiChenBenLibrary _model = new MulaolaoLibrary.GunQiChenBenLibrary( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT PZ003,PZ009,PZ010,PZ013,PZ014,PZ027 FROM R_PQPZ GROUP BY PZ003,PZ009,PZ010,PZ013,PZ014,PZ027 HAVING COUNT(1)>1" );
            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            if ( da != null && da.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < da.Rows.Count ; i++ )
                {
                    _model.PZ003 = _model.PZ009 = _model.PZ010 = _model.PZ013 = _model.PZ014 = _model.PZ027 = "";
                    _model.PZ003 = da.Rows[i]["PZ003"].ToString( );
                    _model.PZ009 = da.Rows[i]["PZ009"].ToString( );
                    _model.PZ010 = da.Rows[i]["PZ010"].ToString( );
                    _model.PZ013 = da.Rows[i]["PZ013"].ToString( );
                    _model.PZ014 = da.Rows[i]["PZ014"].ToString( );
                    _model.PZ027 = da.Rows[i]["PZ027"].ToString( );
                    SQLString.Add( deleteOf( _model ) );
                }
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        string deleteOf ( MulaolaoLibrary.GunQiChenBenLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "DELETE FROM R_PQPZ WHERE idx =(SELECT TOP 1 idx FROM R_PQPZ WHERE PZ003='{0}' AND PZ009='{1}' AND PZ010='{2}' AND PZ013='{3}' AND PZ014='{4}' AND PZ027='{5}' ORDER BY idx DESC )" ,_model.PZ003 ,_model.PZ009 ,_model.PZ010 ,_model.PZ013 ,_model.PZ014 ,_model.PZ027 );

            return strSql.ToString( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQPZ" );
            strSql.Append( " WHERE PZ001=@PZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@PZ001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取单个字段数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT PZ001,PZ002,PZ003,PZ004,PZ005,PZ006 FROM R_PQPZ ORDER BY PZ001,PZ002,PZ003,PZ004,PZ005,PZ006" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM (SELECT DISTINCT PZ003 FROM R_PQPZ" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( " ) A" );

            object obj= SqlHelper.GetSingle( strSql.ToString( ) );
            if ( obj != null )
                return Convert.ToInt32( obj );
            else
                return 0;
        }

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTableByPage ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT PZ001,PZ002,PZ003,PZ004,PZ005,PZ006,PZ039,PZ040,SUM(CONVERT(DECIMAL(18,1),ISNULL(PZ026,0)*ISNULL(PZ019,0))+PZ035) U0,SUM(CONVERT(DECIMAL(18,1),ISNULL(PZ026,0)*ISNULL(PZ017,0))+PZ034) U1,SUM(CONVERT(DECIMAL(18,0),ISNULL(PZ026,0)*ISNULL(PZ036,0))+PZ033) U5,SUM(CASE WHEN PZ015=0 THEN 0 ELSE CONVERT(DECIMAL(18,1),PZ026*PZ017/PZ015) END) U6,CASE WHEN PZ003 LIKE '16%' THEN '已出' ELSE CASE WHEN AD08='' OR AD08 IS NULL THEN '待出' ELSE '已出' END END U7  FROM( " );
            strSql.Append( "SELECT ROW_NUMBER() OVER(" );
            strSql.Append( "ORDER BY T.PZ001 DESC" );
            strSql.Append( ") AS Row,T.* FROM R_PQPZ T" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ")TT LEFT JOIN (SELECT DISTINCT AD17,AD08 FROM R_PQAD WHERE AD17 LIKE 'R_346%') B ON PZ001=AD17" );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );
            strSql.Append( " GROUP BY PZ001,PZ002,PZ003,PZ004,PZ005,PZ006,PZ039,PZ040,AD08 ORDER BY PZ001 DESC" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.GunQiChenBenLibrary GetModel ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQPZ" );
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
        public MulaolaoLibrary.GunQiChenBenLibrary GetDataRow ( DataRow row )
        {
            MulaolaoLibrary.GunQiChenBenLibrary _model = new MulaolaoLibrary.GunQiChenBenLibrary( );

            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    _model.IDX = int.Parse( row["idx"].ToString( ) );
                if ( row["PZ001"] != null && row["PZ001"].ToString( ) != "" )
                    _model.PZ001 = row["PZ001"].ToString( );
                if ( row["PZ002"] != null && row["PZ002"].ToString( ) != "" )
                    _model.PZ002 = row["PZ002"].ToString( );
                if ( row["PZ003"] != null && row["PZ003"].ToString( ) != "" )
                    _model.PZ003 = row["PZ003"].ToString( );
                if ( row["PZ004"] != null && row["PZ004"].ToString( ) != "" )
                    _model.PZ004 = row["PZ004"].ToString( );
                if ( row["PZ005"] != null && row["PZ005"].ToString( ) != "" )
                    _model.PZ005 = row["PZ005"].ToString( );
                if ( row["PZ006"] != null && row["PZ006"].ToString( ) != "" )
                    _model.PZ006 = long.Parse( row["PZ006"].ToString( ) );
                if ( row["PZ007"] != null && row["PZ007"].ToString( ) != "" )
                    _model.PZ007 = DateTime.Parse( row["PZ007"].ToString( ) );
                if ( row["PZ008"] != null && row["PZ008"].ToString( ) != "" )
                    _model.PZ008 = DateTime.Parse( row["PZ008"].ToString( ) );
                if ( row["PZ017"] != null && row["PZ017"].ToString( ) != "" )
                    _model.PZ017 = decimal.Parse( row["PZ017"].ToString( ) );
                if ( row["PZ018"] != null && row["PZ018"].ToString( ) != "" )
                    _model.PZ018 = decimal.Parse( row["PZ018"].ToString( ) );
                if ( row["PZ021"] != null && row["PZ021"].ToString( ) != "" )
                    _model.PZ021 = row["PZ021"].ToString( );
                if ( row["PZ022"] != null && row["PZ022"].ToString( ) != "" )
                    _model.PZ022 = DateTime.Parse( row["PZ022"].ToString( ) );
                if ( row["PZ023"] != null && row["PZ023"].ToString( ) != "" )
                    _model.PZ023 = row["PZ023"].ToString( );
                if ( row["PZ024"] != null && row["PZ024"].ToString( ) != "" )
                    _model.PZ024 = row["PZ024"].ToString( );
                if ( row["PZ025"] != null && row["PZ025"].ToString( ) != "" )
                    _model.PZ025 = DateTime.Parse( row["PZ025"].ToString( ) );
                if ( row["PZ036"] != null && row["PZ036"].ToString( ) != "" )
                    _model.PZ036 = decimal.Parse( row["PZ036"].ToString( ) );
                if ( row["PZ037"] != null && row["PZ037"].ToString( ) != "" )
                    _model.PZ037 = row["PZ037"].ToString( );
            }

            return _model;
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum ,string oddNumOf,string logins)
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQPZ" );
            strSql.AppendFormat( " WHERE PZ001='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            string str = "";
            if ( oddNumOf.Contains( "," ) )
            {
                foreach ( string s in oddNumOf.Split( ',' ) )
                {
                    if ( str == "" )
                        str = "'" + s + "'";
                    else
                        str = str + "," + "'" + s + "'";
                }
            }
            else
                str = "'" + oddNumOf + "'";
            StringBuilder strS = new StringBuilder( );
            strS.Append( "UPDATE R_PQMZ SET MZ121='F'" );
            strS.AppendFormat( " WHERE MZ001 IN (" + str + ")" );
            SQLString.Add( strS.ToString( ) );
            strS = new StringBuilder ( );
            strS . Append ( "DELETE FROM R_PQAD WHERE AD17='" + oddNum + "'" );
            SQLString . Add ( strS . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_346" ,"产品滚漆成本汇总表(R_346)" ,logins ,DateTime . Now ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 是否隐藏
        /// </summary>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public bool EditHide ( string attribute )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQPZ SET " );
            strSql.Append( "PZ038=@PZ038" );
            SqlParameter[] parameter = {
                new SqlParameter("@PZ038",SqlDbType.NVarChar)
            };
            parameter[0].Value = attribute;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取数据  写入241
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOf ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            //344不会有超补  346是产品生产完之后再填单价  所以比344多出来的金额算是超补已付款
            //strSql.Append( "SELECT MZ002,MZ1,CASE WHEN MZ1>=PZ THEN PZ WHEN MZ1<PZ THEN MZ1 ELSE 0 END PZ,CASE WHEN MZ1<PZ THEN PZ-MZ1 ELSE 0 END PZ1,MZ123 FROM (SELECT PZ003,CONVERT(DECIMAL(18,0),SUM(PZ026*PZ017)) PZ FROM R_PQPZ" );
            //strSql.Append( " WHERE PZ003=@PZ" );
            //strSql.Append( " GROUP BY PZ003) A" );
            //strSql.Append( " RIGHT JOIN (" );
            //strSql.Append( " SELECT MZ002,MZ123, CONVERT(DECIMAL(18,0),SUM(MZ022*MZ006*MZ026*MZ024+ISNULL(MZ119,0))) MZ1 FROM R_PQMZ WHERE MZ107='厂内'" );
            //strSql.Append( " AND MZ002=@PZ" );
            //strSql.Append( " GROUP BY MZ123,MZ002) B ON A.PZ003=B.MZ002" );
            //344厂内漆由346读到241
            strSql.Append( "SELECT PZ003,CONVERT(DECIMAL(18,0),SUM(ISNULL(PZ026,0)*ISNULL(PZ017,0)+isnull(PZ034,0))) PZ FROM R_PQPZ" );
            strSql.Append( " WHERE PZ001=@PZ" );
            strSql.Append( " GROUP BY PZ003" );
            SqlParameter[] parameter = {
                new SqlParameter("@PZ",SqlDbType.NVarChar)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 写数据到241
        /// </summary>
        /// <param name="modelAm"></param>
        /// <returns></returns>
        public bool UpdateOfReceviable ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum )
        {
            ArrayList SQLString = new ArrayList( );
            ByOneBy( modelAm ,oddNum ,SQLString );
            //WriteReceivableToGeneralLedger.ByOneByJiao( modelAm ,oddNum ,SQLString );
            if ( modelAm.AM239 > 0 )
            {
                StringBuilder strSqlAM239 = new StringBuilder( );
                strSqlAM239.AppendFormat( "UPDATE R_PQAM SET AM239={0} WHERE AM002='{1}'" ,modelAm.AM239 ,modelAm.AM002 );
                SQLString.Add( strSqlAM239.ToString( ) );
            }
            if ( modelAm.AM241 > 0 )
            {
                StringBuilder strSqlAM241 = new StringBuilder( );
                strSqlAM241.AppendFormat( "UPDATE R_PQAM SET AM241={0} WHERE AM002='{1}'" ,modelAm.AM241 ,modelAm.AM002 );
                SQLString.Add( strSqlAM241.ToString( ) );
            }
                      
            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        void ByOneBy ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "SELECT AMB239,AMB241 FROM R_PQAMB WHERE AMB001='{0}'" ,oddNum );

            DataTable de = SqlHelper.ExecuteDataTable( "SELECT AM239,AM241 FROM R_PQAM WHERE AM002='" + modelAm.AM002 + "'" );
            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            if ( da != null && da.Rows.Count > 0 )
            {
                if ( modelAm.AM239 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB239='{0}' WHERE AMB001='{1}'" ,modelAm.AM239 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM241 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB241='{0}' WHERE AMB001='{1}'" ,modelAm.AM241 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }               

                if ( de != null && de.Rows.Count > 0 )
                {
                    modelAm.AM239 = modelAm.AM239 - ( string.IsNullOrEmpty( da.Rows[0]["AMB239"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB239"].ToString( ) ) );
                    modelAm.AM241 = modelAm.AM241 - ( string.IsNullOrEmpty( da.Rows[0]["AMB241"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB241"].ToString( ) ) );
                    
                    modelAm.AM239 = modelAm.AM239 + ( string.IsNullOrEmpty( de.Rows[0]["AM239"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM239"].ToString( ) ) );
                    modelAm.AM241 = modelAm.AM241 + ( string.IsNullOrEmpty( de.Rows[0]["AM241"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM241"].ToString( ) ) );
                }

            }
            else
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "INSERT INTO R_PQAMB (AMB001,AMB239,AMB241) VALUES ('{0}','{1}','{2}')" ,oddNum ,modelAm.AM239 ,modelAm.AM241 );
                SQLString.Add( strSql.ToString( ) );
                if ( de != null && de.Rows.Count > 0 )
                {
                    modelAm.AM239 = modelAm.AM296 + ( string.IsNullOrEmpty( de.Rows[0]["AM239"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM239"].ToString( ) ) );
                    modelAm.AM241 = modelAm.AM298 + ( string.IsNullOrEmpty( de.Rows[0]["AM241"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM241"].ToString( ) ) );
                }

            }
        }

        /// <summary>
        /// 获取色号等
        /// </summary>
        /// <param name="AC18"></param>
        /// <returns></returns>
        public DataTable GetDataTableAC ( string AC18 )
        {
            /*
             model . MZ023 = bandedGridView1 . GetDataRow ( i ) [ "MZ023" ] . ToString ( );
                model . MZ019 = bandedGridView1 . GetDataRow ( i ) [ "MZ019" ] . ToString ( );
                model . MZ032 = bandedGridView1 . GetDataRow ( i ) [ "MZ124" ] . ToString ( );
             */

            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT AC04,AC05,AC06 FROM R_PQAC " );
            strSql . Append ( "WHERE AC18=@AC18" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@AC18",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = AC18;

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
        }

    }
}

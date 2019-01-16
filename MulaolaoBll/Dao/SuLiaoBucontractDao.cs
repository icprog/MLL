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
    public class SuLiaoBucontractDao
    {
        /// <summary>
        /// 获取数据列表  单个字段
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string field )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT " );
            strSql.Append( field );
            strSql.Append( " FROM R_PQS" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 获取数据列表   供应商
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT PJ03,(SELECT DGA003 FROM TPADGA WHERE DGA001=PJ03) DGA002 FROM R_PQS" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetSuLiaoBuCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQS" );
            if ( !string.IsNullOrEmpty( strWhere.Trim( ) ) )
            {
                strSql.Append( " WHERE " + strWhere );
            }

            Object obj = SqlHelper.GetSingle( strSql.ToString( ) );
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
        public int GetSuLiaoBuCountOne ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQS TT,R_REVIEWS B WHERE TT.PJ92=B.RES06 AND RES05='执行' AND NOT EXISTS (SELECT 1 FROM R_PQAL C,R_PQAK D WHERE TT.idx=C.AL003 AND TT.PJ92=C.AL002 AND C.AL001=D.idx)" );
            if ( !string.IsNullOrEmpty( strWhere.Trim( ) ) )
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
            strSql.Append( "SELECT idx,PJ92,PJ01,PJ93,PJ94,PJ95,PJ96,PJ03,PJ11,PJ12,PJ13,PJ89,PJ10,CASE WHEN PJ01!='' THEN '' ELSE CASE WHEN PJ104='T' THEN '已入' ELSE '未入' END END PJ104,(SELECT DGA003 FROM TPADGA WHERE PJ03=DGA001) DGA002,PJ09,PJ15,PJ14,PJ97,PJ100,PJ106,(SELECT RES05 FROM R_REVIEWS WHERE RES04=(SELECT MAX(RES04) FROM R_REVIEWS WHERE RES06=PJ92)) RES05,PJ12*(PJ11*PJ96+PJ10) U2,DBA002,PJ04,PJ110 FROM (" );
            strSql.Append( " SELECT ROW_NUMBER() OVER(" );
            if ( !string.IsNullOrEmpty( orderby ) )
            {
                strSql.Append( "ORDER BY T." + orderby );
            }
            else
            {
                strSql.Append( "ORDER BY T.idx DESC" );
            }
            strSql.Append( ") AS Row,T.* FROM R_PQS T" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " WHERE " + strWhere );
            }
            strSql.Append( ") TT LEFT JOIN TPADBA B ON TT.PJ02=B.DBA001 " );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTableByPage ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT TT.idx,PJ92,PJ01,PJ93,PJ94,PJ95,PJ96,PJ03,PJ89,PJ11,PJ12,PJ13,PJ10,CASE WHEN PJ01!='' THEN '' ELSE CASE WHEN PJ104='T' THEN '已入' ELSE '未入' END END PJ104,(SELECT DGA003 FROM TPADGA WHERE PJ03=DGA001) DGA002,PJ09,PJ15,PJ14,PJ97,PJ100,PJ106,RES05,PJ12*(PJ11*PJ96+PJ10) U2,PJ04,PJ110 FROM (" );
            strSql.Append( " SELECT ROW_NUMBER() OVER(" );
            strSql.Append( "ORDER BY T.PJ92 DESC" );
            strSql.Append( ") AS Row,T.* FROM R_PQS T" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " WHERE " + strWhere );
            }
            strSql.Append( ") TT,R_REVIEWS B WHERE TT.PJ92=B.RES06 AND RES05='执行' AND NOT EXISTS (SELECT 1 FROM R_PQAL C,R_PQAK D WHERE TT.idx=C.AL003 AND TT.PJ92=C.AL002 AND C.AL001=D.idx AND (AK009-AK010-AK011-AK015)<=100)" );//AND AK009=AK011
            strSql .AppendFormat( " AND TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 编辑上次入库记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateStr ( MulaolaoLibrary.SuLiaoBuQiContractLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQS SET " );
            strSql.Append( "PJ102=@PJ102," );
            strSql.Append( "PJ103=@PJ103" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@PJ102",SqlDbType.BigInt),
                new SqlParameter("@PJ103",SqlDbType.Decimal),
                new SqlParameter("@PJ102",SqlDbType.Int)
            };

            parameter[0].Value = model.PJ102;
            parameter[1].Value = model.PJ103;
            parameter[2].Value = model.IDX;

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
        public bool UpdateBatch ( MulaolaoLibrary . SuLiaoBuQiContractLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQS SET " );
            strSql . AppendFormat ( "PJ96={0}," ,model . PJ96 );
            strSql . AppendFormat ( "PJ14={0}," ,model . PJ14 );
            strSql . AppendFormat ( "PJ97={0}" ,model . PJ97 );
            strSql . AppendFormat ( " WHERE idx='{0}'" ,model . IDX );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( tableNum ,tableName ,logins ,dtOne ,model . PJ92 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 获取联系人
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
        /// 编辑入库标识
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
                        foreach ( string st in sx.Split( ',' ) )
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
                SQLString.Add( EditStorage( strWhere ) );
            if ( strNum != "" )
                SQLString.Add( EditAc( strNum ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取入库标识
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableStorage ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT AC16,AC18 FROM R_PQAC WHERE (AC17!='T' OR AC17='' OR AC17 IS NULL) AND AC16 LIKE 'R_347%'" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 编辑入库标识
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
        /// 编辑入库标识
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public string EditStorage ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQS SET PJ104='T'" );
            strSql.Append( " WHERE PJ92 IN (" + strWhere + ")" );

            return strSql.ToString( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="numOfGoods"></param>
        /// <param name="nameOfPrice"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfPrice ( string numOfGoods ,string nameOfPrice )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT TOP 1 PJ12 FROM R_PQS" );
            strSql.Append( " WHERE PJ95=@PJ95 AND PJ09=@PJ09 ORDER BY idx DESC" );
            SqlParameter[] parameter = {
                new SqlParameter("@PJ95",SqlDbType.NVarChar),
                new SqlParameter("@PJ09",SqlDbType.NVarChar)
            };
            parameter[0].Value = numOfGoods;
            parameter[1].Value = nameOfPrice;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="tableNum"></param>
        /// <param name="tableName"></param>
        /// <param name="logins"></param>
        /// <param name="dtOne"></param>
        /// <param name="oddNum"></param>
        /// <param name="stateOf"></param>
        /// <param name="stateOfOdd"></param>
        /// <returns></returns>
        public bool DeleteAll ( string tableNum ,string tableName ,string logins ,DateTime dtOne ,string oddNum ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "DELETE FROM R_PQS WHERE PJ92='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            StringBuilder strSq = new StringBuilder( );
            strSq.AppendFormat( "DELETE FROM R_REVIEWS WHERE RES01='{0}' AND RES06='{1}'" ,tableNum ,oddNum );
            SQLString.Add( strSq.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="tableNum"></param>
        /// <param name="tableName"></param>
        /// <param name="logins"></param>
        /// <param name="dtOne"></param>
        /// <param name="oddNum"></param>
        /// <param name="stateOf"></param>
        /// <param name="stateOfOdd"></param>
        /// <returns></returns>
        public bool Copy ( string tableNum ,string tableName ,string logins ,DateTime dtOne ,string oddNum ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "INSERT INTO R_PQS (PJ01,PJ93,PJ94,PJ95,PJ96,PJ03,PJ09,PJ10,PJ11,PJ12,PJ13,PJ97,PJ14,PJ15,PJ16,PJ17,PJ18,PJ21,PJ24,PJ27,PJ30,PJ33,PJ34,PJ35,PJ36,PJ37,PJ38,PJ39,PJ40,PJ41,PJ42,PJ43,PJ44,PJ45,PJ46,PJ47,PJ48,PJ49,PJ50,PJ51,PJ52,PJ53,PJ54,PJ55,PJ56,PJ57,PJ58,PJ59,PJ60,PJ61,PJ62,PJ63,PJ64,PJ65,PJ66,PJ67,PJ68,PJ69,PJ70,PJ71,PJ72,PJ73,PJ74,PJ75,PJ76,PJ77,PJ89,PJ105) SELECT PJ01,PJ93,PJ94,PJ95,PJ96,PJ03,PJ09,PJ10,PJ11,PJ12,PJ13,PJ97,PJ14,PJ15,PJ16,PJ17,PJ18,PJ21,PJ24,PJ27,PJ30,PJ33,PJ34,PJ35,PJ36,PJ37,PJ38,PJ39,PJ40,PJ41,PJ42,PJ43,PJ44,PJ45,PJ46,PJ47,PJ48,PJ49,PJ50,PJ51,PJ52,PJ53,PJ54,PJ55,PJ56,PJ57,PJ58,PJ59,PJ60,PJ61,PJ62,PJ63,PJ64,PJ65,PJ66,PJ67,PJ68,PJ69,PJ70,PJ71,PJ72,PJ73,PJ74,PJ75,PJ76,PJ77,PJ89,PJ105 FROM R_PQS WHERE PJ92='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        
        /// <summary>
        /// 更改复制单号
        /// </summary>
        /// <param name="tableNum"></param>
        /// <param name="tableName"></param>
        /// <param name="logins"></param>
        /// <param name="dtOne"></param>
        /// <param name="oddNum"></param>
        /// <param name="stateOf"></param>
        /// <param name="stateOfOdd"></param>
        /// <returns></returns>
        public bool CopyAll ( string tableNum ,string tableName ,string logins ,DateTime dtOne ,string oddNum ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "UPDATE R_PQS SET PJ92='{0}',PJ99='复制',PJ19=DATEADD(DAY,5,GETDATE()) WHERE PJ92 IS NULL" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTabelOfReceivable ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT PJ01,PJ15,CASE WHEN PJ100='T' THEN 'T' ELSE 'F' END PJ100,CONVERT(DECIMAL(18,1),SUM(PJ12*(PJ11*PJ96+PJ10))) PQ,PJ105 FROM R_PQS A  LEFT JOIN R_REVIEWS D ON A.PJ92=D.RES06 AND RES01='R_347' AND RES05='执行'" );
            strSql.AppendFormat( " WHERE PJ92='{0}' AND (PJ01!='' AND PJ01 IS NOT NULL) GROUP BY PJ100,PJ105,PJ01,PJ15" , oddNum );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 写数据到241
        /// </summary>
        /// <param name="modelAm"></param>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateOfReveciable ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum )
        {
            ArrayList SQLString = new ArrayList( );
            ByOneBy( modelAm ,oddNum ,SQLString );
            //WriteReceivableToGeneralLedger.ByOneBySu( modelAm ,oddNum ,SQLString );
            StringBuilder strSql = new StringBuilder( );
            if ( modelAm.AM212 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM212='{0}' WHERE AM002='{1}'" ,modelAm.AM212 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( modelAm.AM215 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM215='{0}' WHERE AM002='{1}'" ,modelAm.AM215 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( modelAm.AM217 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM217='{0}' WHERE AM002='{1}'" ,modelAm.AM217 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( modelAm.AM218 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM218='{0}' WHERE AM002='{1}'" ,modelAm.AM218 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( modelAm.AM221 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM221='{0}' WHERE AM002='{1}'" ,modelAm.AM221 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( modelAm.AM223 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM223='{0}' WHERE AM002='{1}'" ,modelAm.AM223 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( modelAm . AM229 > 0 )
            {
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "UPDATE R_PQAM SET AM229='{0}' WHERE AM002='{1}'" , modelAm . AM229 , modelAm . AM002 );
                SQLString . Add ( strSql . ToString ( ) );
            }
            if ( modelAm . AM231 > 0 )
            {
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "UPDATE R_PQAM SET AM231='{0}' WHERE AM002='{1}'" , modelAm . AM231 , modelAm . AM002 );
                SQLString . Add ( strSql . ToString ( ) );
            }
            if ( modelAm . AM233 > 0 )
            {
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "UPDATE R_PQAM SET AM233='{0}' WHERE AM002='{1}'" , modelAm . AM233 , modelAm . AM002 );
                SQLString . Add ( strSql . ToString ( ) );
            }
            if ( modelAm . AM235 > 0 )
            {
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "UPDATE R_PQAM SET AM235='{0}' WHERE AM002='{1}'" , modelAm . AM235 , modelAm . AM002 );
                SQLString . Add ( strSql . ToString ( ) );
            }
            if ( modelAm . AM237 > 0 )
            {
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "UPDATE R_PQAM SET AM237='{0}' WHERE AM002='{1}'" , modelAm . AM237 , modelAm . AM002 );
                SQLString . Add ( strSql . ToString ( ) );
            }
            if ( modelAm . AM255 > 0 )
            {
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "UPDATE R_PQAM SET AM255='{0}' WHERE AM002='{1}'" , modelAm . AM255 , modelAm . AM002 );
                SQLString . Add ( strSql . ToString ( ) );
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        
        void ByOneBy ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum,ArrayList SQLString)
        {
            //modelAm.AM212 = modelAm.AM217 = modelAm.AM215 = modelAm.AM221 = modelAm.AM218 = modelAm.AM223 = 0;
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "SELECT AMB212,AMB215,AMB217,AMB218,AMB221,AMB223,AMB229,AMB231,AMB233,AMB235,AMB237,AMB255 FROM R_PQAMB WHERE AMB001='{0}'" , oddNum );
            DataTable de = SqlHelper.ExecuteDataTable( "SELECT AM212,AM215,AM217,AM218,AM221,AM223,AM229,AM231,AM233,AM235,AM237,AM255 FROM R_PQAM WHERE AM002='" + modelAm.AM002 + "'" );
            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            if ( da != null && da.Rows.Count > 0 )
            {
                if ( modelAm.AM212 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB212='{0}' WHERE AMB001='{1}'" ,modelAm.AM212 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM215 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB215='{0}' WHERE AMB001='{1}'" ,modelAm.AM215 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM217 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB217='{0}' WHERE AMB001='{1}'" ,modelAm.AM217 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM218 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB218='{0}' WHERE AMB001='{1}'" ,modelAm.AM218 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM221 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB221='{0}' WHERE AMB001='{1}'" ,modelAm.AM221 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM223 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB223='{0}' WHERE AMB001='{1}'" ,modelAm.AM223 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm . AM229 > 0 )
                {
                    strSql = new StringBuilder ( );
                    strSql . AppendFormat ( "UPDATE R_PQAMB SET AMB229='{0}' WHERE AMB001='{1}'" , modelAm . AM229 , oddNum );
                    SQLString . Add ( strSql . ToString ( ) );
                }
                if ( modelAm . AM231 > 0 )
                {
                    strSql = new StringBuilder ( );
                    strSql . AppendFormat ( "UPDATE R_PQAMB SET AMB231='{0}' WHERE AMB001='{1}'" , modelAm . AM231 , oddNum );
                    SQLString . Add ( strSql . ToString ( ) );
                }
                if ( modelAm . AM233 > 0 )
                {
                    strSql = new StringBuilder ( );
                    strSql . AppendFormat ( "UPDATE R_PQAMB SET AMB233='{0}' WHERE AMB001='{1}'" , modelAm . AM233 , oddNum );
                    SQLString . Add ( strSql . ToString ( ) );
                }
                if ( modelAm . AM235 > 0 )
                {
                    strSql = new StringBuilder ( );
                    strSql . AppendFormat ( "UPDATE R_PQAMB SET AMB235='{0}' WHERE AMB001='{1}'" , modelAm . AM235 , oddNum );
                    SQLString . Add ( strSql . ToString ( ) );
                }
                if ( modelAm . AM237 > 0 )
                {
                    strSql = new StringBuilder ( );
                    strSql . AppendFormat ( "UPDATE R_PQAMB SET AMB237='{0}' WHERE AMB001='{1}'" , modelAm . AM237 , oddNum );
                    SQLString . Add ( strSql . ToString ( ) );
                }
                if ( modelAm . AM255 > 0 )
                {
                    strSql = new StringBuilder ( );
                    strSql . AppendFormat ( "UPDATE R_PQAMB SET AMB255='{0}' WHERE AMB001='{1}'" , modelAm . AM255 , oddNum );
                    SQLString . Add ( strSql . ToString ( ) );
                }

                if ( de != null && de.Rows.Count > 0 )
                {
                    modelAm.AM212 = modelAm.AM212 - ( string.IsNullOrEmpty( da.Rows[0]["AMB212"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB212"].ToString( ) ) );
                    modelAm.AM215 = modelAm.AM215 - ( string.IsNullOrEmpty( da.Rows[0]["AMB215"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB215"].ToString( ) ) );
                    modelAm.AM217 = modelAm.AM217 - ( string.IsNullOrEmpty( da.Rows[0]["AMB217"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB217"].ToString( ) ) );
                    modelAm.AM218 = modelAm.AM218 - ( string.IsNullOrEmpty( da.Rows[0]["AMB218"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB218"].ToString( ) ) );
                    modelAm.AM221 = modelAm.AM221 - ( string.IsNullOrEmpty( da.Rows[0]["AMB221"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB221"].ToString( ) ) );
                    modelAm.AM223 = modelAm.AM223 - ( string.IsNullOrEmpty( da.Rows[0]["AMB223"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB223"].ToString( ) ) );
                    modelAm . AM229 = modelAm . AM229 - ( string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AMB229" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AMB229" ] . ToString ( ) ) );
                    modelAm . AM231 = modelAm . AM231 - ( string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AMB231" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AMB231" ] . ToString ( ) ) );
                    modelAm . AM233 = modelAm . AM233 - ( string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AMB233" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AMB233" ] . ToString ( ) ) );
                    modelAm . AM235 = modelAm . AM235 - ( string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AMB235" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AMB235" ] . ToString ( ) ) );
                    modelAm . AM237 = modelAm . AM237 - ( string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AMB237" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AMB237" ] . ToString ( ) ) );
                    modelAm . AM255 = modelAm . AM255 - ( string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AMB255" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AMB255" ] . ToString ( ) ) );

                    modelAm .AM212 = modelAm.AM212 + ( string.IsNullOrEmpty( de.Rows[0]["AM212"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM212"].ToString( ) ) );
                    modelAm.AM215 = modelAm.AM215 + ( string.IsNullOrEmpty( de.Rows[0]["AM215"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM215"].ToString( ) ) );
                    modelAm.AM217 = modelAm.AM217 + ( string.IsNullOrEmpty( de.Rows[0]["AM217"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM217"].ToString( ) ) );
                    modelAm.AM218 = modelAm.AM218 + ( string.IsNullOrEmpty( de.Rows[0]["AM218"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM218"].ToString( ) ) );
                    modelAm.AM221 = modelAm.AM221 + ( string.IsNullOrEmpty( de.Rows[0]["AM221"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM221"].ToString( ) ) );
                    modelAm.AM223 = modelAm.AM223 + ( string.IsNullOrEmpty( de.Rows[0]["AM223"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM223"].ToString( ) ) );
                    modelAm . AM229 = modelAm . AM229 + ( string . IsNullOrEmpty ( de . Rows [ 0 ] [ "AM229" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ 0 ] [ "AM229" ] . ToString ( ) ) );
                    modelAm . AM231 = modelAm . AM231 + ( string . IsNullOrEmpty ( de . Rows [ 0 ] [ "AM231" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ 0 ] [ "AM231" ] . ToString ( ) ) );
                    modelAm . AM233 = modelAm . AM233 + ( string . IsNullOrEmpty ( de . Rows [ 0 ] [ "AM233" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ 0 ] [ "AM233" ] . ToString ( ) ) );
                    modelAm . AM235 = modelAm . AM231 + ( string . IsNullOrEmpty ( de . Rows [ 0 ] [ "AM235" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ 0 ] [ "AM235" ] . ToString ( ) ) );
                    modelAm . AM237 = modelAm . AM231 + ( string . IsNullOrEmpty ( de . Rows [ 0 ] [ "AM237" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ 0 ] [ "AM237" ] . ToString ( ) ) );
                    modelAm . AM255 = modelAm . AM231 + ( string . IsNullOrEmpty ( de . Rows [ 0 ] [ "AM255" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ 0 ] [ "AM255" ] . ToString ( ) ) );
                }
                
            }
            else
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "INSERT INTO R_PQAMB (AMB001,AMB212,AMB215,AMB217,AMB218,AMB221,AMB223,AMB229,AMB231,AMB233,AMB235,AMB237,AMB255) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')" , oddNum ,modelAm.AM212 ,modelAm.AM215 ,modelAm.AM217 ,modelAm.AM218 ,modelAm.AM221 ,modelAm.AM223 , modelAm . AM229 , modelAm . AM231 , modelAm . AM233 , modelAm . AM235 , modelAm . AM237 , modelAm . AM255 );
                SQLString.Add( strSql.ToString( ) );
                if ( de != null && de.Rows.Count > 0 )
                {
                    modelAm.AM212 = modelAm.AM212 + ( string.IsNullOrEmpty( de.Rows[0]["AM212"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM212"].ToString( ) ) );
                    modelAm.AM215 = modelAm.AM215 + ( string.IsNullOrEmpty( de.Rows[0]["AM215"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM215"].ToString( ) ) );
                    modelAm.AM217 = modelAm.AM217 + ( string.IsNullOrEmpty( de.Rows[0]["AM217"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM217"].ToString( ) ) );
                    modelAm.AM218 = modelAm.AM218 + ( string.IsNullOrEmpty( de.Rows[0]["AM218"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM218"].ToString( ) ) );
                    modelAm.AM221 = modelAm.AM221 + ( string.IsNullOrEmpty( de.Rows[0]["AM221"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM221"].ToString( ) ) );
                    modelAm.AM223 = modelAm.AM223 + ( string.IsNullOrEmpty( de.Rows[0]["AM223"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM223"].ToString( ) ) );
                    modelAm . AM229 = modelAm . AM229 + ( string . IsNullOrEmpty ( de . Rows [ 0 ] [ "AM229" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ 0 ] [ "AM229" ] . ToString ( ) ) );
                    modelAm . AM231 = modelAm . AM229 + ( string . IsNullOrEmpty ( de . Rows [ 0 ] [ "AM231" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ 0 ] [ "AM231" ] . ToString ( ) ) );
                    modelAm . AM233 = modelAm . AM229 + ( string . IsNullOrEmpty ( de . Rows [ 0 ] [ "AM233" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ 0 ] [ "AM233" ] . ToString ( ) ) );
                    modelAm . AM235 = modelAm . AM229 + ( string . IsNullOrEmpty ( de . Rows [ 0 ] [ "AM235" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ 0 ] [ "AM235" ] . ToString ( ) ) );
                    modelAm . AM237 = modelAm . AM229 + ( string . IsNullOrEmpty ( de . Rows [ 0 ] [ "AM237" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ 0 ] [ "AM237" ] . ToString ( ) ) );
                    modelAm . AM255 = modelAm . AM229 + ( string . IsNullOrEmpty ( de . Rows [ 0 ] [ "AM255" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ 0 ] [ "AM255" ] . ToString ( ) ) );
                }
                
            }
        }
    }
}

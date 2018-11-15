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
    public class WaiXiancontractDao
    {
       
        /// <summary>
        /// 获取数据列表   单个字段
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string field )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT " );
            strSql.Append( field );
            strSql.Append( " FROM R_PQT" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 获取数据列表  供应商
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT WX03,(SELECT DGA003 FROM TPADGA WHERE DGA001=WX03) DGA002 FROM R_PQT" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetWaiXianCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQT" );
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
        /// 获取总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetWaiXianCountOne ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQT TT,R_REVIEWS B WHERE TT.WX82=B.RES06 AND RES05='执行' AND NOT EXISTS (SELECT 1 FROM R_PQAL C ,R_PQAK D WHERE TT.idx=C.AL003 AND TT.WX82=C.AL002 AND C.AL001=D.idx)" );
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
            strSql.Append( "SELECT idx,WX82,WX01,WX83,WX84,WX85,WX10,WX11,WX86,WX12,WX13,WX15,WX16,WX87,WX17,WX27,WX28,WX29,WX30,WX31,WX32,WX23,WX24,WX25,WX26,WX90,WX03,U3,U4,(SELECT DGA003 FROM TPADGA WHERE DGA001=WX03) DGA002,(SELECT RES05 FROM R_REVIEWS WHERE RES04=(SELECT MAX(RES04) FROM R_REVIEWS WHERE WX82=RES06)) RES05,DBA002,WX05,WX97 FROM (" );
            strSql.Append( " SELECT ROW_NUMBER() OVER(" );
            if ( !string.IsNullOrEmpty( orderby ) )
            {
                strSql.Append( "ORDER BY T." + orderby );
            }
            else
            {
                strSql.Append( "ORDER BY T.idx" );
            }
            strSql.Append( ") AS Row,T.* FROM R_PQT T" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " WHERE " + strWhere );
            }
            strSql.Append( ") TT LEFT JOIN TPADBA B ON TT.WX02=B.DBA001 " );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 分页获取数据列表  财务结账
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTableByPage ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT TT.idx,WX82,WX01,WX83,WX84,WX85,WX10,WX11,WX86,WX12,WX13,WX15,WX16,WX87,WX17,WX27,WX28,WX29,WX30,WX31,WX32,WX23,WX24,WX25,WX26,WX90,WX03,U3,U4,(SELECT DGA003 FROM TPADGA WHERE DGA001=WX03) DGA002,RES05,WX05,WX97 FROM( " );
            strSql.Append( " SELECT ROW_NUMBER() OVER(" );
            strSql.Append( "ORDER BY T.WX82 DESC" );
            strSql.Append( ") AS Row,T.* FROM R_PQT T" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " WHERE " + strWhere );
            }
            strSql.Append( ") TT,R_REVIEWS B WHERE TT.WX82=B.RES06 AND RES05='执行' AND NOT EXISTS (SELECT 1 FROM R_PQAL C ,R_PQAK D WHERE TT.idx=C.AL003 AND TT.WX82=C.AL002 AND C.AL001=D.idx AND (AK009-AK010-AK011-AK015)<=100)" );//AND AK009=AK011
            strSql .AppendFormat( " AND TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 编辑上次入库记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateStr ( MulaolaoLibrary.WaiXianContractLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQT SET " );
            strSql.Append( "WX92=@WX92," );
            strSql.Append( "WX93=@WX93" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@WX92",SqlDbType.BigInt),
                new SqlParameter("@WX93",SqlDbType.BigInt),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = model.WX92;
            parameter[0].Value = model.WX93;
            parameter[0].Value = model.IDX;

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
        public bool UpdateBatch ( MulaolaoLibrary . WaiXianContractLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd ,string oddNum )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQT SET " );
            strSql . AppendFormat ( "WX15='{0}'," ,model . WX15 );
            strSql . AppendFormat ( "WX86='{0}'," ,model . WX86 );
            strSql . AppendFormat ( "WX16='{0}'," ,model . WX16 );
            strSql . AppendFormat ( "WX87='{0}'" ,model . WX87 );
            strSql . AppendFormat ( " WHERE idx='{0}'" ,model . IDX );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

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
        /// 获取数据列表
        /// </summary>
        /// <param name="numOfGoods"></param>
        /// <param name="nameOfPrice"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfPrice ( string numOfGoods ,string nameOfPrice )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT TOP 1 WX13 FROM R_PQT" );
            strSql.Append( " WHERE WX85=@WX85 AND WX10=@WX10 ORDER BY idx DESC" );
            SqlParameter[] parameter = {
                new SqlParameter("@WX85",SqlDbType.NVarChar),
                new SqlParameter("@WX10",SqlDbType.NVarChar)
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
            strSql.AppendFormat( "DELETE FROM R_PQT WHERE WX82='{0}'" ,oddNum );
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
            strSql.AppendFormat( "INSERT INTO R_PQT (WX01,WX83,WX84,WX85,WX86,WX02,WX10,WX11,WX12,WX13,WX14,WX15,WX16,WX87,WX17,WX18,WX19,WX20,WX23,WX24,WX25,WX26,WX27,WX28,WX29,WX30,WX31,WX32,WX33,WX35,WX36,WX37,WX38,WX39,WX40,WX41,WX42,WX43,WX44,WX45,WX46,WX47,WX48,WX49,WX50,WX51,WX56,WX57,WX58,WX59,WX60,WX61,WX62,WX63,WX64,WX65,WX66,WX67,WX68,WX72,WX77,WX78,WX79) SELECT WX01,WX83,WX84,WX85,WX86,WX02,WX10,WX11,WX12,WX13,WX14,WX15,WX16,WX87,WX17,WX18,WX19,WX20,WX23,WX24,WX25,WX26,WX27,WX28,WX29,WX30,WX31,WX32,WX33,WX35,WX36,WX37,WX38,WX39,WX40,WX41,WX42,WX43,WX44,WX45,WX46,WX47,WX48,WX49,WX50,WX51,WX56,WX57,WX58,WX59,WX60,WX61,WX62,WX63,WX64,WX65,WX66,WX67,WX68,WX72,WX77,WX78,WX79 FROM R_PQT WHERE WX82='{0}'" ,oddNum );
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
            strSql.AppendFormat( "UPDATE R_PQT SET WX82='{0}',WX89='复制',WX21=DATEADD(DAY,5,GETDATE()) WHERE WX82 IS NULL" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
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
            if ( modelAm.AM130 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM130='{0}' WHERE AM002='{1}'" ,modelAm.AM130 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( modelAm.AM133 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM133='{0}' WHERE AM002='{1}'" ,modelAm.AM133 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( modelAm.AM136 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM136='{0}' WHERE AM002='{1}'" ,modelAm.AM136 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( modelAm.AM138 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM138='{0}' WHERE AM002='{1}'" ,modelAm.AM138 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( modelAm.AM139 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM139='{0}' WHERE AM002='{1}'" ,modelAm.AM139 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( modelAm.AM142 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM142='{0}' WHERE AM002='{1}'" ,modelAm.AM142 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( modelAm.AM144 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM144='{0}' WHERE AM002='{1}'" ,modelAm.AM144 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( modelAm.AM145 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM145='{0}' WHERE AM002='{1}'" ,modelAm.AM145 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( modelAm.AM148 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM148='{0}' WHERE AM002='{1}'" ,modelAm.AM148 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( modelAm.AM150 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM150='{0}' WHERE AM002='{1}'" ,modelAm.AM150 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }


            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        void  ByOneBy ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AMB130,AMB133,AMB136,AMB138,AMB139,AMB142,AMB144,AMB145,AMB148,AMB150 FROM R_PQAMB" );
            strSql.AppendFormat( " WHERE AMB001='{0}'" ,oddNum );

            DataTable de = SqlHelper.ExecuteDataTable( "SELECT AM130,AM133,AM136,AM138,AM139,AM142,AM144,AM145,AM148,AM150 FROM R_PQAM WHERE AM002='"+modelAm.AM002+"'" );
            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            if ( da != null && da.Rows.Count > 0 )
            {
                if ( modelAm.AM130 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB130='{0}' WHERE AMB001='{1}'" ,modelAm.AM130 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM133 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB133='{0}' WHERE AMB001='{1}'" ,modelAm.AM133 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM136 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB136='{0}' WHERE AMB001='{1}'" ,modelAm.AM136 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM138 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB138='{0}' WHERE AMB001='{1}'" ,modelAm.AM138 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM139 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB139='{0}' WHERE AMB001='{1}'" ,modelAm.AM139 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM142 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB142='{0}' WHERE AMB001='{1}'" ,modelAm.AM142 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM144 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB144='{0}' WHERE AMB001='{1}'" ,modelAm.AM144 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM145 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB145='{0}' WHERE AMB001='{1}'" ,modelAm.AM145 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM148 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB148='{0}' WHERE AMB001='{1}'" ,modelAm.AM148 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM150 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB150='{0}' WHERE AMB001='{1}'" ,modelAm.AM150 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                
                if ( de != null && de.Rows.Count > 0 )
                {
                    modelAm.AM130 = modelAm.AM130 - ( string.IsNullOrEmpty( da.Rows[0]["AMB130"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB130"].ToString( ) ) );
                    modelAm.AM133 = modelAm.AM133 - ( string.IsNullOrEmpty( da.Rows[0]["AMB133"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB133"].ToString( ) ) );
                    modelAm.AM136 = modelAm.AM136 - ( string.IsNullOrEmpty( da.Rows[0]["AMB136"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB136"].ToString( ) ) );
                    modelAm.AM138 = modelAm.AM138 - ( string.IsNullOrEmpty( da.Rows[0]["AMB138"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB138"].ToString( ) ) );
                    modelAm.AM139 = modelAm.AM139 - ( string.IsNullOrEmpty( da.Rows[0]["AMB139"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB139"].ToString( ) ) );
                    modelAm.AM142 = modelAm.AM142 - ( string.IsNullOrEmpty( da.Rows[0]["AMB142"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB142"].ToString( ) ) );
                    modelAm.AM144 = modelAm.AM144 - ( string.IsNullOrEmpty( da.Rows[0]["AMB144"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB144"].ToString( ) ) );
                    modelAm.AM145 = modelAm.AM145 - ( string.IsNullOrEmpty( da.Rows[0]["AMB145"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB145"].ToString( ) ) );
                    modelAm.AM148 = modelAm.AM148 - ( string.IsNullOrEmpty( da.Rows[0]["AMB148"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB148"].ToString( ) ) );
                    modelAm.AM150 = modelAm.AM150 - ( string.IsNullOrEmpty( da.Rows[0]["AMB150"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB150"].ToString( ) ) );

                    modelAm.AM130 = modelAm.AM130 + ( string.IsNullOrEmpty( de.Rows[0]["AM130"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM130"].ToString( ) ) );
                    modelAm.AM133 = modelAm.AM133 + ( string.IsNullOrEmpty( de.Rows[0]["AM133"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM133"].ToString( ) ) );
                    modelAm.AM136 = modelAm.AM136 + ( string.IsNullOrEmpty( de.Rows[0]["AM136"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM136"].ToString( ) ) );
                    modelAm.AM138 = modelAm.AM138 + ( string.IsNullOrEmpty( de.Rows[0]["AM138"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM138"].ToString( ) ) );
                    modelAm.AM139 = modelAm.AM139 + ( string.IsNullOrEmpty( de.Rows[0]["AM139"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM139"].ToString( ) ) );
                    modelAm.AM142 = modelAm.AM142 + ( string.IsNullOrEmpty( de.Rows[0]["AM142"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM142"].ToString( ) ) );
                    modelAm.AM144 = modelAm.AM144 + ( string.IsNullOrEmpty( de.Rows[0]["AM144"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM144"].ToString( ) ) );
                    modelAm.AM145 = modelAm.AM145 + ( string.IsNullOrEmpty( de.Rows[0]["AM145"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM145"].ToString( ) ) );
                    modelAm.AM148 = modelAm.AM148 + ( string.IsNullOrEmpty( de.Rows[0]["AM148"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM148"].ToString( ) ) );
                    modelAm.AM150 = modelAm.AM150 + ( string.IsNullOrEmpty( de.Rows[0]["AM150"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM150"].ToString( ) ) );
                }
                
            }
            else
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "INSERT INTO R_PQAMB (AMB001,AMB130,AMB133,AMB136,AMB138,AMB139,AMB142,AMB144,AMB145,AMB148,AMB150) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')" ,oddNum ,modelAm.AM130 ,modelAm.AM133 ,modelAm.AM136 ,modelAm.AM138 ,modelAm.AM139 ,modelAm.AM142 ,modelAm.AM144 ,modelAm.AM145 ,modelAm.AM148 ,modelAm.AM150 );
                SQLString.Add( strSql.ToString( ) );
                if ( de != null && de.Rows.Count > 0 )
                {
                    modelAm.AM130 = modelAm.AM130 + ( string.IsNullOrEmpty( de.Rows[0]["AM130"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM130"].ToString( ) ) );
                    modelAm.AM133 = modelAm.AM133 + ( string.IsNullOrEmpty( de.Rows[0]["AM133"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM133"].ToString( ) ) );
                    modelAm.AM136 = modelAm.AM136 + ( string.IsNullOrEmpty( de.Rows[0]["AM136"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM136"].ToString( ) ) );
                    modelAm.AM138 = modelAm.AM138 + ( string.IsNullOrEmpty( de.Rows[0]["AM138"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM138"].ToString( ) ) );
                    modelAm.AM139 = modelAm.AM139 + ( string.IsNullOrEmpty( de.Rows[0]["AM139"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM139"].ToString( ) ) );
                    modelAm.AM142 = modelAm.AM142 + ( string.IsNullOrEmpty( de.Rows[0]["AM142"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM142"].ToString( ) ) );
                    modelAm.AM144 = modelAm.AM144 + ( string.IsNullOrEmpty( de.Rows[0]["AM144"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM144"].ToString( ) ) );
                    modelAm.AM145 = modelAm.AM145 + ( string.IsNullOrEmpty( de.Rows[0]["AM145"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM145"].ToString( ) ) );
                    modelAm.AM148 = modelAm.AM148 + ( string.IsNullOrEmpty( de.Rows[0]["AM148"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM148"].ToString( ) ) );
                    modelAm.AM150 = modelAm.AM150 + ( string.IsNullOrEmpty( de.Rows[0]["AM150"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM150"].ToString( ) ) );
                }
               
            }
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfReceiveable ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT WX01,CASE WHEN WX90='T' THEN 'T' ELSE 'F' END WX90,WX20,SUM(CASE WHEN WX10='双瓦外箱' THEN CONVERT( DECIMAL( 11, 1 ), ((WX27 + WX28 + WX29) * (WX30 + WX31 + WX32) + (WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15 ) WHEN WX10='小箱式' THEN CONVERT( DECIMAL( 11, 1 ), ((WX27 + WX28 + WX29) * (WX30 + WX31 + WX32) + (WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15 ) WHEN WX10='牙膏式' THEN CONVERT( DECIMAL( 11, 1 ), ((WX27 + 2*WX28 + WX29) * (2*WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 ) WHEN WX10='插口式' THEN CONVERT( DECIMAL( 11, 1 ), ((WX27 + 2*WX28 + WX29) * (2*WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 ) WHEN WX10='天盖' THEN CONVERT( DECIMAL( 11, 1 ), ((WX27 + 2*WX28 + WX29) * (WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 ) WHEN WX10='地盖' THEN CONVERT( DECIMAL( 11, 1 ), ((WX27 + 2*WX28 + WX29) * (WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 ) WHEN WX10='折叠式' THEN CONVERT( DECIMAL( 11, 1 ), ((2*WX27 + 2*WX28 + WX29) * (1.5*WX30 + WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 ) WHEN WX10 NOT IN ('双瓦外箱','小箱式','牙膏式','插口式','天盖','地盖','折叠式') THEN CONVERT( DECIMAL( 11, 1 ), (WX23 + WX24) * (WX25 + WX26) * 0.0001 * WX13* WX15) END) PQ FROM R_PQT A INNER JOIN R_REVIEWS D ON A.WX82=D.RES06 AND RES05='执行'" );
            strSql.AppendFormat( " WHERE WX82='{0}' AND (WX01!='' AND WX01 IS NOT NULL) AND LEN(WX01)<=8" ,oddNum );
            strSql.Append( " GROUP BY WX20,WX90,WX01" );
            
            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        } 
    }
}

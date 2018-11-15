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
    public class WuJincontractDao
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
            strSql.Append( " FROM R_PQU" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 获取数据列表  供应商
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableSupplied ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT PQU03,(SELECT DGA003 FROM TPADGA WHERE PQU03=DGA001) DGA002 FROM R_PQU" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetWuJinCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQU" );
            if ( !string.IsNullOrEmpty( strWhere.Trim( ) ) )
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
        public int GetWuJinCountOne ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQU TT,R_REVIEWS B WHERE TT.PQU97=B.RES06 AND RES05='执行' AND NOT EXISTS (SELECT 1 FROM R_PQAL C,R_PQAK D WHERE TT.idx=C.AL003 AND TT.PQU97=C.AL002 AND C.AL001=D.idx)" );
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
            strSql.Append( "SELECT idx,PQU97,PQU01,PQU98,PQU99,PQU100,PQU101,PQU14,PQU16,PQU03,CASE WHEN PQU01!='' THEN '' ELSE CASE WHEN PQU111='T' THEN '已入' ELSE '未入' END END PQU111,(SELECT DGA002 FROM TPADGA WHERE PQU03=DGA001) DGA002,PQU10,PQU12,PQU19,PQU18,PQU104,PQU13,PQU107,PQU112,(SELECT RES05 FROM R_REVIEWS WHERE RES04 = (SELECT MAX(RES04) FROM R_REVIEWS WHERE PQU97 = RES06)) RES05,PQU16*(PQU13*PQU101+PQU14) U1,PQU05,PQU15,PQU116  FROM (" );
            strSql.Append( " SELECT ROW_NUMBER() OVER(" );
            if ( !string.IsNullOrEmpty( orderby ) )
            {
                strSql.Append( " ORDER BY T." + orderby );
            }
            else
            {
                strSql.Append( " ORDER BY T.idx DESC" );
            }
            strSql.Append( ") AS Row,T.* FROM R_PQU T" );
            if ( !string.IsNullOrEmpty( strWhere.Trim( ) ) )
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
            strSql.Append( "SELECT TT.idx,PQU97,PQU01,PQU98,PQU99,PQU100,PQU101,PQU14,PQU16,PQU03,CASE WHEN PQU01!='' THEN '' ELSE CASE WHEN PQU111='T' THEN '已入' ELSE '未入' END END PQU111,(SELECT DGA003 FROM TPADGA WHERE PQU03=DGA001) DGA002,PQU10,PQU12,PQU19,PQU18,PQU104,PQU13,PQU107,PQU112,RES05,PQU16*(PQU13*PQU101+PQU14) U1,PQU05,PQU15,PQU116 FROM ( " );
            strSql.Append( " SELECT ROW_NUMBER() OVER(" );
            strSql.Append( " ORDER BY T.PQU97 DESC" );
            strSql.Append( ") AS Row,T.* FROM R_PQU T" );
            if ( !string.IsNullOrEmpty( strWhere.Trim( ) ) )
            {
                strSql.Append( " WHERE " + strWhere );
            }
            strSql.Append( " ) TT,R_REVIEWS B WHERE TT.PQU97=B.RES06 AND RES05='执行' AND NOT EXISTS (SELECT 1 FROM R_PQAL C,R_PQAK D WHERE TT.idx=C.AL003 AND TT.PQU97=C.AL002 AND C.AL001=D.idx AND (AK009-AK010-AK011-AK015)<=100)" );//AND AK009=AK011
            strSql .AppendFormat( " AND TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 编辑上次入库记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateStr ( MulaolaoLibrary.WuJinContractLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQU SET " );
            strSql.Append( "PQU109=@PQU109," );
            strSql.Append( "PQU110=@PQU110" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@PQU109",SqlDbType.BigInt),
                new SqlParameter("@PQU110",SqlDbType.BigInt),
                new SqlParameter("@PQU109",SqlDbType.BigInt),
            };
            parameter[0].Value = model.PQU109;
            parameter[0].Value = model.PQU110;
            parameter[0].Value = model.IDX;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 批量编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateBatch ( MulaolaoLibrary.WuJinContractLibrary model,string tableNum,string tableName,string logins,DateTime dtOne,string oddNum,string stateOf,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQU SET " );
            strSql.AppendFormat( "PQU101='{0}',",model.PQU101 );
            strSql.AppendFormat( "PQU104='{0}',",model.PQU104 );
            strSql.AppendFormat( "PQU18='{0}'" ,model.PQU18 );
            strSql.AppendFormat( " WHERE idx='{0}'" ,model.IDX );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
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
        /// 编辑入库标记
        /// </summary>
        /// <returns></returns>
        public bool EditStorage ( )
        {
            ArrayList SQLString = new ArrayList( );
            string strWhere = "", strNum = "";
            DataTable da = GetDataTableStory( );
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
                SQLString.Add( EditPqaf( strWhere ) );
            if ( strNum != "" )
                SQLString.Add( EditAc( strNum ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取入库标记
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableStory ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT AC16,AC18 FROM R_PQAC WHERE (AC17!='T' OR AC17='' OR AC17 IS NULL) AND AC16 LIKE 'R_343%'" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 编辑入库标记
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public string EditAc (string strWhere )
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
            strSql.Append( "UPDATE R_PQU SET PQU111='T'" );
            strSql.Append( " WHERE PQU97 IN (" + strWhere + ")" );

            return strSql.ToString( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="numOfGoods"></param>
        /// <param name="nameOfPart"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfPrice ( string numOfGoods ,string nameOfPart )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT TOP 1 PQU16 FROM R_PQU " );
            strSql.Append( " WHERE PQU100=@PQU100 AND PQU10=@PQU10 ORDER BY idx DESC" );
            SqlParameter[] parameter = {
                new SqlParameter("@PQU100",SqlDbType.NVarChar),
                new SqlParameter("@PQU10",SqlDbType.NVarChar)
            };
            parameter[0].Value = numOfGoods;
            parameter[1].Value = nameOfPart;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="tableNum"></param>
        /// <param name="tableName"></param>
        /// <param name="logins"></param>
        /// <param name="dtOne"></param>
        /// <param name="stateOf"></param>
        /// <param name="stateOfOdd"></param>
        /// <returns></returns>
        public bool DeleteAll ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "DELETE FROM R_PQU WHERE PQU97='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            StringBuilder strSq = new StringBuilder( );
            strSq.AppendFormat( "DELETE FROM R_REVIEWS WHERE RES01='{0}' AND RES06='{1}'" ,tableNum ,oddNum );
            SQLString.Add( strSq.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );
            if ( stateOfOdd == "维护删除" )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "DELETE FROM R_PQAMB WHERE AMB001='{0}'" ,oddNum );
                SQLString.Add( strSql.ToString( ) );
            }
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
            strSql.AppendFormat( "INSERT INTO R_PQU (PQU01,PQU98,PQU99,PQU100,PQU101,PQU02,PQU03,PQU10,PQU11,PQU12,PQU13,PQU14,PQU15,PQU16,PQU17,PQU104,PQU18,PQU19,PQU20,PQU21,PQU24,PQU25,PQU26,PQU27,PQU28,PQU29,PQU32,PQU33,PQU34,PQU35,PQU36,PQU37,PQU38,PQU39,PQU40,PQU41,PQU42,PQU43,PQU44,PQU47,PQU49,PQU50,PQU51,PQU52,PQU53,PQU54,PQU55,PQU56,PQU57,PQU58,PQU59,PQU60,PQU61,PQU62,PQU63,PQU64,PQU65,PQU66,PQU67,PQU68,PQU69,PQU70,PQU72,PQU73,PQU76,PQU77,PQU78,PQU79,PQU80,PQU81,PQU82,PQU83,PQU84,PQU85) SELECT PQU01,PQU98,PQU99,PQU100,PQU101,PQU02,PQU03,PQU10,PQU11,PQU12,PQU13,PQU14,PQU15,PQU16,PQU17,PQU104,PQU18,PQU19,PQU20,PQU21,PQU24,PQU25,PQU26,PQU27,PQU28,PQU29,PQU32,PQU33,PQU34,PQU35,PQU36,PQU37,PQU38,PQU39,PQU40,PQU41,PQU42,PQU43,PQU44,PQU47,PQU49,PQU50,PQU51,PQU52,PQU53,PQU54,PQU55,PQU56,PQU57,PQU58,PQU59,PQU60,PQU61,PQU62,PQU63,PQU64,PQU65,PQU66,PQU67,PQU68,PQU69,PQU70,PQU72,PQU73,PQU76,PQU77,PQU78,PQU79,PQU80,PQU81,PQU82,PQU83,PQU84,PQU85 FROM R_PQU WHERE PQU97='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 复制保存
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="tableNum"></param>
        /// <param name="tableName"></param>
        /// <param name="logins"></param>
        /// <param name="dtOne"></param>
        /// <param name="stateOf"></param>
        /// <param name="stateOfOdd"></param>
        /// <returns></returns>
        public bool CopyAll ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "UPDATE R_PQU SET PQU97='{0}',PQU106='复制',PQU22=DATEADD(DAY,5,GETDATE()) WHERE PQU97 IS NULL" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable UpdateOfReceviable ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "SELECT PQU01,PQU19,CASE WHEN PQU107='T' THEN 'T' ELSE 'F' END PQU107,CONVERT(DECIMAL(18,1),SUM(PQU16*(PQU101*PQU13+PQU14))) PQ FROM R_PQU A  INNER JOIN R_REVIEWS D ON A.PQU97=D.RES06 AND RES05='执行' WHERE PQU97='{0}'  AND (PQU01!='' AND PQU01 IS NOT NULL) GROUP BY PQU107,PQU01,PQU19" , oddNum );
            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 写数据到241
        /// </summary>
        /// <param name="modelAm"></param>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateOfRece ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum )
        {
            ArrayList SQLString = new ArrayList( );
            ByOneBy( modelAm ,oddNum ,SQLString );
            //WriteReceivableToGeneralLedger.ByOneByWu( modelAm ,oddNum ,SQLString );
            StringBuilder strSql = new StringBuilder( );
            if ( modelAm.AM209 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM209='{0}' WHERE AM002='{1}'" ,modelAm.AM209 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( modelAm.AM211 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM211='{0}' WHERE AM002='{1}'" ,modelAm.AM211 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( modelAm . AM225 > 0 )
            {
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "UPDATE R_PQAM SET AM225='{0}' WHERE AM002='{1}'" , modelAm . AM225 , modelAm . AM002 );
                SQLString . Add ( strSql . ToString ( ) );
            }
            if ( modelAm . AM227 > 0 )
            {
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "UPDATE R_PQAM SET AM227='{0}' WHERE AM002='{1}'" , modelAm . AM227 , modelAm . AM002 );
                SQLString . Add ( strSql . ToString ( ) );
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        
        void ByOneBy ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "SELECT AMB209,AMB211,AMB225,AMB227 FROM R_PQAMB WHERE AMB001='{0}'" ,oddNum );

            DataTable de = SqlHelper.ExecuteDataTable( "SELECT AM209,AM211,AM225,AM227 FROM R_PQAM WHERE AM002='" + modelAm.AM002 + "'" );
            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            if ( da != null && da.Rows.Count > 0 )
            {
                if ( modelAm.AM209 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB209='{0}' WHERE AMB001='{1}'" ,modelAm.AM209 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM211 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB211='{0}' WHERE AMB001='{1}'" ,modelAm.AM211 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm . AM225 > 0 )
                {
                    strSql = new StringBuilder ( );
                    strSql . AppendFormat ( "UPDATE R_PQAMB SET AMB225='{0}' WHERE AMB001='{1}'" , modelAm . AM225 , oddNum );
                    SQLString . Add ( strSql . ToString ( ) );
                }
                if ( modelAm . AM227 > 0 )
                {
                    strSql = new StringBuilder ( );
                    strSql . AppendFormat ( "UPDATE R_PQAMB SET AMB227='{0}' WHERE AMB001='{1}'" , modelAm . AM227 , oddNum );
                    SQLString . Add ( strSql . ToString ( ) );
                }

                if ( de != null && de.Rows.Count > 0 )
                {
                    modelAm.AM209 = modelAm.AM209 - ( string.IsNullOrEmpty( da.Rows[0]["AMB209"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB209"].ToString( ) ) );
                    modelAm.AM211 = modelAm.AM211 - ( string.IsNullOrEmpty( da.Rows[0]["AMB211"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB211"].ToString( ) ) );
                    modelAm . AM225 = modelAm . AM225 - ( string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AMB225" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AMB225" ] . ToString ( ) ) );
                    modelAm . AM227 = modelAm . AM225 - ( string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AMB227" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AMB227" ] . ToString ( ) ) );

                    modelAm .AM209 = modelAm.AM209 + ( string.IsNullOrEmpty( de.Rows[0]["AM209"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM209"].ToString( ) ) );
                    modelAm.AM211 = modelAm.AM211 + ( string.IsNullOrEmpty( de.Rows[0]["AM211"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM211"].ToString( ) ) );
                    modelAm . AM225 = modelAm . AM211 + ( string . IsNullOrEmpty ( de . Rows [ 0 ] [ "AM225" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ 0 ] [ "AM225" ] . ToString ( ) ) );
                    modelAm . AM227 = modelAm . AM211 + ( string . IsNullOrEmpty ( de . Rows [ 0 ] [ "AM227" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ 0 ] [ "AM227" ] . ToString ( ) ) );
                }
                
            }
            else
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "INSERT INTO R_PQAMB (AMB001,AMB209,AMB211,AMB225,AMB227) VALUES ('{0}','{1}','{2}','{3}','{4}')" , oddNum ,modelAm.AM209 ,modelAm. AM211 , modelAm . AM225 , modelAm . AM227 );
                SQLString.Add( strSql.ToString( ) );
                if ( de != null && de.Rows.Count > 0 )
                {
                    modelAm.AM209 = modelAm.AM209 + ( string.IsNullOrEmpty( de.Rows[0]["AM209"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM209"].ToString( ) ) );
                    modelAm.AM211 = modelAm.AM211 + ( string.IsNullOrEmpty( de.Rows[0]["AM211"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM211"].ToString( ) ) );
                    modelAm . AM225 = modelAm . AM225 + ( string . IsNullOrEmpty ( de . Rows [ 0 ] [ "AM225" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ 0 ] [ "AM225" ] . ToString ( ) ) );
                    modelAm . AM227 = modelAm . AM227 + ( string . IsNullOrEmpty ( de . Rows [ 0 ] [ "AM227" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ 0 ] [ "AM227" ] . ToString ( ) ) );
                }
                
            }
        }
    }
}

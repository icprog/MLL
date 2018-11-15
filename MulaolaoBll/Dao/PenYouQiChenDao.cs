using StudentMgr;
using System;
using System . Collections;
using System . Collections . Generic;
using System . Data;
using System . Data . SqlClient;
using System . Linq;
using System . Text;

namespace MulaolaoBll.Dao
{
    public class PenYouQiChenDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT PY33,PY01,PY30,PY06,PY38,PY31 FROM R_PQY" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        
        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount ( string strWhere)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM (SELECT DISTINCT PY33,PY01,PY07,PY30,PY27,PY06,PY38,PY31,PY46 FROM R_PQY ) A" );
            strSql.Append( " WHERE " + strWhere );

            object obj= SqlHelper.GetSingle( strSql.ToString( ) );
            if ( obj != null )
                return Convert.ToInt32( obj );
            else
                return 0;
        }
        public int GetCoun ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM (SELECT DISTINCT PY33,PY01,PY07,PY30,PY27,PY06,PY38,PY31,PY46 FROM R_PQY) A " );
            strSql.Append( " WHERE " + strWhere );

            object obj = SqlHelper.GetSingle( strSql.ToString( ) );
            if ( obj != null )
                return Convert.ToInt32( obj );
            else
                return 0;
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTableByPage ( string strWhere ,int startIndex ,int endIndex )
        {
            //CASE WHEN PY14=0 THEN 0 WHEN PY18=0 THEN 0 WHEN PY21=0 THEN 0 ELSE (PY10*PY11*PY15*PY12*PY20/PY21/PY14/PY18+PY13*PY19*PY16*PY10*PY11/PY14/PY18/PY21/2)*(1+PY17/100)/PY10+PY23*PY14*PY18*PY11*PY10*PY12*PY15*0.0001 END U2
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT idx,PY33,PY01,PY07,PY30,PY27,PY06,PY38,PY31,PQF31,RES05,SUM(U13+U14) U1,PY46,CONVERT(DECIMAL(11,2),SUM(U2)) U2 FROM (" );
            strSql.Append( "( SELECT ROW_NUMBER() OVER (" );
            strSql.Append( "ORDER BY T.PY33 DESC" );
            strSql.Append( " ) AS Row,T.* FROM  (SELECT DISTINCT R_PQY.idx,PY33,PY01,PY07,PY30,PY27,PY06,PY38,PY31,(SELECT PQF31 FROM R_PQF WHERE PQF01=PY01) PQF31,RES05,CASE WHEN PY14 = 0 OR PY18 = 0 OR PY21 = 0 THEN 0 WHEN PY14 != 0 AND PY18 != 0 AND PY21 != 0 THEN (PY10*PY11*PY15*PY12*PY20/PY21/PY14/PY18+PY13*PY19*PY16*PY10*PY11/PY14/PY18/PY21/2)*(1+PY17/100) END U13, PY23*PY14*PY18*PY11*PY10*PY12*PY15*0.0001 U14,PY46,CASE WHEN PY10=0 THEN 0 WHEN PY14*PY18*PY21=0 THEN PY23*PY14*PY18*PY11*PY10*PY12*PY15*0.0001/PY10 ELSE ((PY10*PY11*PY15*PY12*PY20/PY21/PY14/PY18+PY13*PY19*PY16*PY10*PY11/PY14/PY18/PY21/2)*(1+PY17/100)+PY23*PY14*PY18*PY11*PY10*PY12*PY15*0.0001)/PY10 END U2 FROM R_PQY,R_REVIEWS WHERE PY33=RES06 AND RES05='执行' ) T" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") ) TT WHERE NOT EXISTS (SELECT 1 FROM R_PQAL C,R_PQAK D WHERE TT.idx=C.AL003 AND TT.PY33=C.AL002 AND C.AL001=D.idx AND (AK009-AK010-AK011-AK015)<=100)" );//AND AK009=AK011
            strSql .AppendFormat( " AND TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );
            strSql.Append( "GROUP BY idx,PY33,PY01,PY07,PY30,PY27,PY06,PY38,PY31,PQF31,RES05,PY46" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableByPages ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT PY33,PY01,PY07,PY30,PY27,PY06,PY38,PY31,PQF31,RES05,SUM(U13+U14) U1,PY46,CONVERT(DECIMAL(11,2),SUM(U2)) U2 FROM (" );
            strSql.Append( "( SELECT ROW_NUMBER() OVER (" );
            strSql.Append( "ORDER BY T.PY33 DESC" );
            strSql.Append( " ) AS Row,T.* FROM  (SELECT DISTINCT PY33,PY01,PY07,PY30,PY27,PY06,PY38,PY31,PY25,PY36,PY26,(SELECT PQF31 FROM R_PQF WHERE PQF01=PY01) PQF31,(SELECT RES05 FROM R_REVIEWS WHERE RES04=(SELECT MAX(RES04) FROM R_REVIEWS WHERE RES06=PY33)) RES05,CASE WHEN PY14 = 0 OR PY18 = 0 OR PY21 = 0 THEN 0 WHEN PY14 != 0 AND PY18 != 0 AND PY21 != 0 THEN (PY10*PY11*PY15*PY12*PY20/PY21/PY14/PY18+PY13*PY19*PY16*PY10*PY11/PY14/PY18/PY21/2)*(1+PY17/100) END U13,PY23*PY14*PY18*PY11*PY10*PY12*PY15*0.0001 U14,PY46,CASE WHEN PY10=0 THEN 0 WHEN PY14*PY18*PY21=0 THEN PY23*PY14*PY18*PY11*PY10*PY12*PY15*0.0001/PY10 ELSE ((PY10*PY11*PY15*PY12*PY20/PY21/PY14/PY18+PY13*PY19*PY16*PY10*PY11/PY14/PY18/PY21/2)*(1+PY17/100)+PY23*PY14*PY18*PY11*PY10*PY12*PY15*0.0001)/PY10 END U2 FROM R_PQY )  T" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") ) TT" );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );
            strSql.Append( "GROUP BY PY33,PY01,PY07,PY30,PY27,PY06,PY38,PY31,PQF31,RES05,PY46" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
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
        public bool Delete ( string tableNum ,string tableName ,string logins ,DateTime dtOne ,string oddNum ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "DELETE FROM R_PQY WHERE PY33='{0}'" ,oddNum );
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
            strSql.AppendFormat( "INSERT INTO R_PQY (PY01,PY30,PY31,PY38,PY27,PY02,PY07,PY10,PY11,PY12,PY13,PY14,PY15,PY16,PY17,PY18,PY19,PY20,PY21,PY22,PY23,PY24,PY25,PY36,PY26,PY42,PY43) SELECT PY01,PY30,PY31,PY38,PY27,PY02,PY07,PY10,PY11,PY12,PY13,PY14,PY15,PY16,PY17,PY18,PY19,PY20,PY21,PY22,PY23,PY24,PY25,PY36,PY26,PY42,PY43 FROM R_PQY WHERE PY33='{0}'" ,oddNum );
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
            strSql.AppendFormat( "UPDATE R_PQY SET PY33='{0}',PY37='' WHERE PY33 IS NULL" ,oddNum );
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
            strSql.Append( "SELECT PY01,'喷漆' AH18,SUM((CASE WHEN PY14 = 0 OR PY18 = 0 OR PY21 = 0 THEN 0 WHEN PY14 != 0 AND PY18 != 0 AND PY21 != 0 THEN CONVERT(DECIMAL(18,3),(PY10*PY11*PY15*PY12*PY20/PY21/PY14/PY18+PY13*PY19*PY16*PY10*PY11/PY14/PY18/PY21/2)*(1+PY17/100)) END )+CONVERT(DECIMAL(18,3),PY23*PY14*PY18*PY11*PY10*PY12*PY15*0.0001)) U14 FROM R_PQY A LEFT JOIN R_REVIEWS D ON A.PY33=D.RES06 AND RES01='R_495' AND RES05='执行'" );
            strSql.AppendFormat( " WHERE PY33='{0}'" ,oddNum );
            strSql.AppendFormat( " AND (PY01!='' AND PY01 IS NOT NULL) GROUP BY PY01" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 写数据到241
        /// </summary>
        /// <param name="modelAm"></param>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateOfReceivable ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm,string oddNum )
        {
            ArrayList SQLString = new ArrayList( );
            ByOneBy( modelAm ,oddNum ,SQLString );
            //WriteReceivableToGeneralLedger.ByOneByQiGong( modelAm ,oddNum ,SQLString );
            StringBuilder strSql = new StringBuilder( );
            if ( modelAm.AM088 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM088='{0}' WHERE AM002='{1}'" ,modelAm.AM088 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        void ByOneBy ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "SELECT AMB088 FROM R_PQAMB WHERE AMB001='{0}'" ,oddNum );
            DataTable de = SqlHelper.ExecuteDataTable( "SELECT AM088 FROM R_PQAM WHERE AM002='" + modelAm.AM002 + "'" );
            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            if ( da != null && da.Rows.Count > 0 )
            {
                if ( modelAm.AM088 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB088='{0}' WHERE AMB001='{1}'" ,modelAm.AM088 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }

                if ( de != null && de.Rows.Count > 0 )
                {
                    modelAm.AM088 = modelAm.AM088 - ( string.IsNullOrEmpty( da.Rows[0]["AMB088"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB088"].ToString( ) ) );
                    modelAm.AM088 = modelAm.AM088 + ( string.IsNullOrEmpty( da.Rows[0]["AMB088"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB088"].ToString( ) ) );
                }
            }
            else
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "INSERT INTO R_PQAMB (AMB001,AMB088) VALUES ('{0}','{1}')" ,oddNum ,modelAm.AM088 );
                SQLString.Add( strSql.ToString( ) );
                if ( de != null && de.Rows.Count > 0 )
                    modelAm.AM088 = modelAm.AM088 + ( string.IsNullOrEmpty( de.Rows[0]["AM088"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM088"].ToString( ) ) );
               
            }
        }

        /// <summary>
        /// 获取流水等信息
        /// </summary>
        /// <returns></returns>
        public DataTable getProductInfo ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PQF01,PQF02,PQF03,PQF04,PQF06,PQF31 FROM R_PQF A INNER JOIN R_REVIEWS B ON A.PQF01=B.RES06 WHERE RES05 = '执行' ORDER BY PQF01 DESC" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Insert ( MulaolaoLibrary . FrmpenyouqichenEntity _model ,string logins ,string stateOfOdd )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQY (PY10,PY11,PY12,PY13,PY14,PY15,PY16,PY17,PY18,PY19,PY20,PY21,PY22,PY23,PY24,PY25,PY26,PY33,PY36,PY31,PY43,PY42)" );
            strSql . Append ( "VALUES (@PY10,@PY11,@PY12,@PY13,@PY14,@PY15,@PY16,@PY17,@PY18,@PY19,@PY20,@PY21,@PY22,@PY23,@PY24,@PY25,@PY26,@PY33,@PY36,@PY31,@PY43,@PY42)" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PY10",SqlDbType.BigInt,8),
                new SqlParameter("@PY11",SqlDbType.Int,4),
                new SqlParameter("@PY12",SqlDbType.Int,4),
                new SqlParameter("@PY13",SqlDbType.Int,4),
                new SqlParameter("@PY14",SqlDbType.Int,4),
                new SqlParameter("@PY15",SqlDbType.Int,4),
                new SqlParameter("@PY16",SqlDbType.Decimal,2),
                new SqlParameter("@PY17",SqlDbType.Decimal,3),
                new SqlParameter("@PY18",SqlDbType.Decimal,2),
                new SqlParameter("@PY19",SqlDbType.Int,4),
                new SqlParameter("@PY20",SqlDbType.Int,4),
                new SqlParameter("@PY21",SqlDbType.Int,4),
                new SqlParameter("@PY22",SqlDbType.NVarChar,20),
                new SqlParameter("@PY23",SqlDbType.Decimal,2),
                new SqlParameter("@PY24",SqlDbType.NVarChar,50),
                new SqlParameter("@PY25",SqlDbType.NVarChar,20),
                new SqlParameter("@PY26",SqlDbType.NVarChar,50),
                new SqlParameter("@PY33",SqlDbType.NVarChar,20),
                new SqlParameter("@PY36",SqlDbType.NVarChar,20),
                new SqlParameter("@PY31",SqlDbType.NVarChar,200),
                new SqlParameter("@PY43",SqlDbType.NVarChar,50),
                new SqlParameter("@PY42",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _model . PY10;
            parameter [ 1 ] . Value = _model . PY11;
            parameter [ 2 ] . Value = _model . PY12;
            parameter [ 3 ] . Value = _model . PY13;
            parameter [ 4 ] . Value = _model . PY14;
            parameter [ 5 ] . Value = _model . PY15;
            parameter [ 6 ] . Value = _model . PY16;
            parameter [ 7 ] . Value = _model . PY17;
            parameter [ 8 ] . Value = _model . PY18;
            parameter [ 9 ] . Value = _model . PY19;
            parameter [ 10 ] . Value = _model . PY20;
            parameter [ 11 ] . Value = _model . PY21;
            parameter [ 12 ] . Value = _model . PY22;
            parameter [ 13 ] . Value = _model . PY23;
            parameter [ 14 ] . Value = _model . PY24;
            parameter [ 15 ] . Value = _model . PY25;
            parameter [ 16 ] . Value = _model . PY26;
            parameter [ 17 ] . Value = _model . PY33;
            parameter [ 18 ] . Value = _model . PY36;
            parameter [ 19 ] . Value = _model . PY31;
            parameter [ 20 ] . Value = _model . PY43;
            parameter [ 21 ] . Value = _model . PY42;

            SQLString . Add ( strSql ,parameter );
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "INSERT INTO R_PQY (PY10,PY11,PY12,PY13,PY14,PY15,PY16,PY17,PY18,PY19,PY20,PY21,PY22,PY23,PY24,PY25,PY26,PY33,PY36,PY31,PY43,PY42) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}')" ,_model . PY10 ,_model . PY11 ,_model . PY12 ,_model . PY13 ,_model . PY14 ,_model . PY15 ,_model . PY16 ,_model . PY17 ,_model . PY18 ,_model . PY19 ,_model . PY20 ,_model . PY21 ,_model . PY22 ,_model . PY23 ,_model . PY24 ,_model . PY25 ,_model . PY26 ,_model . PY33 ,_model . PY36 ,_model . PY31 ,_model . PY43 ,_model . PY42 );
            SQLString . Add ( MulaolaoBll . Drity . DrityOfComparation ( "R_495" ,"喷油漆承揽生产加工合同" ,logins ,MulaolaoBll . Drity . GetDt ( ) ,_model . PY33 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新建" ,stateOfOdd ) ,null );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 是否存在同流水，开合同人，零件名称，工序
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool ExistsBody ( MulaolaoLibrary . FrmpenyouqichenEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM R_PQY WHERE PY01='{0}' AND PY06='{1}' AND PY25='{2}' AND PY36='{3}'" ,_model . PY01 ,_model . PY06 ,_model . PY25 ,_model . PY36 );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="logins"></param>
        /// <param name="stateOfOdd"></param>
        /// <returns></returns>
        public bool Edit ( MulaolaoLibrary . FrmpenyouqichenEntity _model ,string logins ,string stateOfOdd )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE R_PQY SET "  );
            strSql . Append ( "PY10=@PY10," );
            strSql . Append ( "PY11=@PY11," );
            strSql . Append ( "PY12=@PY12," );
            strSql . Append ( "PY13=@PY13," );
            strSql . Append ( "PY14=@PY14," );
            strSql . Append ( "PY15=@PY15," );
            strSql . Append ( "PY16=@PY16," );
            strSql . Append ( "PY17=@PY17," );
            strSql . Append ( "PY18=@PY18," );
            strSql . Append ( "PY19=@PY19," );
            strSql . Append ( "PY20=@PY20," );
            strSql . Append ( "PY21=@PY21," );
            strSql . Append ( "PY22=@PY22," );
            strSql . Append ( "PY23=@PY23," );
            strSql . Append ( "PY24=@PY24," );
            strSql . Append ( "PY25=@PY25," );
            strSql . Append ( "PY26=@PY26," );
            strSql . Append ( "PY36=@PY36," );
            strSql . Append ( "PY42=@PY42," );
            strSql . Append ( "PY43=@PY43 " );
            strSql . Append ( "WHERE PY33=@PY33 AND idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PY10",SqlDbType.BigInt,8),
                new SqlParameter("@PY11",SqlDbType.Int,4),
                new SqlParameter("@PY12",SqlDbType.Int,4),
                new SqlParameter("@PY13",SqlDbType.Int,4),
                new SqlParameter("@PY14",SqlDbType.Int,4),
                new SqlParameter("@PY15",SqlDbType.Int,4),
                new SqlParameter("@PY16",SqlDbType.Decimal,2),
                new SqlParameter("@PY17",SqlDbType.Decimal,3),
                new SqlParameter("@PY18",SqlDbType.Decimal,2),
                new SqlParameter("@PY19",SqlDbType.Int,4),
                new SqlParameter("@PY20",SqlDbType.Int,4),
                new SqlParameter("@PY21",SqlDbType.Int,4),
                new SqlParameter("@PY22",SqlDbType.NVarChar,20),
                new SqlParameter("@PY23",SqlDbType.Decimal,2),
                new SqlParameter("@PY24",SqlDbType.NVarChar,50),
                new SqlParameter("@PY25",SqlDbType.NVarChar,20),
                new SqlParameter("@PY26",SqlDbType.NVarChar,50),
                new SqlParameter("@PY33",SqlDbType.NVarChar,20),
                new SqlParameter("@PY36",SqlDbType.NVarChar,20),
                new SqlParameter("@PY43",SqlDbType.NVarChar,50),
                new SqlParameter("@PY42",SqlDbType.NVarChar,20),
                new SqlParameter("@idx",SqlDbType.Int,4)
            };
            parameter [ 0 ] . Value = _model . PY10;
            parameter [ 1 ] . Value = _model . PY11;
            parameter [ 2 ] . Value = _model . PY12;
            parameter [ 3 ] . Value = _model . PY13;
            parameter [ 4 ] . Value = _model . PY14;
            parameter [ 5 ] . Value = _model . PY15;
            parameter [ 6 ] . Value = _model . PY16;
            parameter [ 7 ] . Value = _model . PY17;
            parameter [ 8 ] . Value = _model . PY18;
            parameter [ 9 ] . Value = _model . PY19;
            parameter [ 10 ] . Value = _model . PY20;
            parameter [ 11 ] . Value = _model . PY21;
            parameter [ 12 ] . Value = _model . PY22;
            parameter [ 13 ] . Value = _model . PY23;
            parameter [ 14 ] . Value = _model . PY24;
            parameter [ 15 ] . Value = _model . PY25;
            parameter [ 16 ] . Value = _model . PY26;
            parameter [ 17 ] . Value = _model . PY33;
            parameter [ 18 ] . Value = _model . PY36;
            parameter [ 19 ] . Value = _model . PY43;
            parameter [ 20 ] . Value = _model . PY42;
            parameter [ 21 ] . Value = _model . idx;
            SQLString . Add ( strSql ,parameter );
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE R_PQY SET PY10='{0}',PY11='{1}',PY12='{2}',PY13='{3}',PY14='{4}',PY15='{5}',PY16='{6}',PY17='{7}',PY18='{8}',PY19='{9}',PY20='{10}',PY21='{11}',PY22='{12}',PY23='{13}',PY24='{14}',PY25='{15}',PY26='{16}',PY36='{17}',PY42='{18}',PY43='{19}' WHERE PY33='{21}' AND idx='{20}'" ,_model . PY10 ,_model . PY11 ,_model . PY12 ,_model . PY13 ,_model . PY14 ,_model . PY15 ,_model . PY16 ,_model . PY17 ,_model . PY18 ,_model . PY19 ,_model . PY20 ,_model . PY21 ,_model . PY22 ,_model . PY23 ,_model . PY24 ,_model . PY25 ,_model . PY26 ,_model . PY36 ,_model . PY42 ,_model . PY43 ,_model . idx ,_model . PY33 );
            SQLString . Add ( MulaolaoBll . Drity . DrityOfComparation ( "R_495" ,"喷油漆承揽生产加工合同" ,logins ,MulaolaoBll . Drity . GetDt ( ) ,_model . PY33 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"编辑" ,stateOfOdd ) ,null );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 批量编辑数据
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="logins"></param>
        /// <param name="stateOfOdd"></param>
        /// <returns></returns>
        public bool BatchEdit ( MulaolaoLibrary . FrmpenyouqichenEntity _model ,string logins ,string stateOfOdd )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE R_PQY SET PY10='{1}' WHERE PY33='{0}'" ,_model . PY33 ,_model . PY10 );
            SQLString . Add ( strSql ,null );
            SQLString . Add ( MulaolaoBll . Drity . DrityOfComparation ( "R_495" ,"喷油漆承揽生产加工合同" ,logins ,MulaolaoBll . Drity . GetDt ( ) ,_model . PY33 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"批量编辑" ,stateOfOdd ) ,null );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="logins"></param>
        /// <param name="stateOfOdd"></param>
        /// <returns></returns>
        public bool Delete ( MulaolaoLibrary . FrmpenyouqichenEntity _model ,string logins ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM R_PQY WHERE PY33='{1}' AND idx={0}" ,_model . idx ,_model . PY33 );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( MulaolaoBll . Drity . DrityOfComparation ( "R_495" ,"喷油漆承揽生产加工合同" ,logins ,MulaolaoBll . Drity . GetDt ( ) ,_model . PY33 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,stateOfOdd ) );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable getTableToView ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT idx,PY02,PY03,PY04,PY05,PY07,PY08,PY09,PY10,PY11,PY12,PY13,PY14,PY15,PY16,PY17,PY18,PY19,PY20,PY21,PY23,PY22,PY24,PY25,PY26,PY35,PY36,PY42,PY43,U12,U14 FROM R_PQY WHERE PY33='{0}' AND PY25!='' AND PY25 IS NOT NULL ORDER BY idx DESC" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary . FrmpenyouqichenEntity getModel ( long idx )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT idx,PY33,PY01,PY30,PY31,PY38,PY27,PY02,PY03,PY04,PY05,PY06,PY07,PY08,PY09,PY32,PY34,PY10,PY11,PY12,PY13,PY14,PY15,PY16,PY17,PY18,PY19,PY20,PY21,PY22,PY23,PY24,PY25,PY36,PY26,PY28,PY29,PY35,PY37,PY39,PY40,PY41,PY42,PY43,PY44,PY45,PY46,PY47 FROM R_PQY WHERE idx={0}" ,idx );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
                return getModel ( dt . Rows [ 0 ] );
            else
                return null;
        }
        public MulaolaoLibrary . FrmpenyouqichenEntity getModel ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT idx,PY33,PY01,PY30,PY31,PY38,PY27,PY02,PY03,PY04,PY05,PY06,PY07,PY08,PY09,PY32,PY34,PY10,PY11,PY12,PY13,PY14,PY15,PY16,PY17,PY18,PY19,PY20,PY21,PY22,PY23,PY24,PY25,PY36,PY26,PY28,PY29,PY35,PY37,PY39,PY40,PY41,PY42,PY43,PY44,PY45,PY46,PY47 FROM R_PQY WHERE PY33='{0}'" ,oddNum );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
                return getModel ( dt . Rows [ 0 ] );
            else
                return null;
        }

        public MulaolaoLibrary . FrmpenyouqichenEntity getModel ( DataRow row )
        {
            MulaolaoLibrary . FrmpenyouqichenEntity model = new MulaolaoLibrary . FrmpenyouqichenEntity ( );

            if ( row != null )
            {
                if ( row [ "idx" ] != null && row [ "idx" ] . ToString ( ) != "" )
                {
                    model . idx = long . Parse ( row [ "idx" ] . ToString ( ) );
                }
                if ( row [ "PY33" ] != null )
                {
                    model . PY33 = row [ "PY33" ] . ToString ( );
                }
                if ( row [ "PY01" ] != null )
                {
                    model . PY01 = row [ "PY01" ] . ToString ( );
                }
                if ( row [ "PY30" ] != null )
                {
                    model . PY30 = row [ "PY30" ] . ToString ( );
                }
                if ( row [ "PY31" ] != null )
                {
                    model . PY31 = row [ "PY31" ] . ToString ( );
                }
                if ( row [ "PY38" ] != null )
                {
                    model . PY38 = row [ "PY38" ] . ToString ( );
                }
                if ( row [ "PY27" ] != null && row [ "PY27" ] . ToString ( ) != "" )
                {
                    model . PY27 = long . Parse ( row [ "PY27" ] . ToString ( ) );
                }
                if ( row [ "PY02" ] != null )
                {
                    model . PY02 = row [ "PY02" ] . ToString ( );
                }
                if ( row [ "PY03" ] != null && row [ "PY03" ] . ToString ( ) != "" )
                {
                    model . PY03 = DateTime . Parse ( row [ "PY03" ] . ToString ( ) );
                }
                if ( row [ "PY04" ] != null )
                {
                    model . PY04 = row [ "PY04" ] . ToString ( );
                }
                if ( row [ "PY05" ] != null && row [ "PY05" ] . ToString ( ) != "" )
                {
                    model . PY05 = DateTime . Parse ( row [ "PY05" ] . ToString ( ) );
                }
                if ( row [ "PY06" ] != null )
                {
                    model . PY06 = row [ "PY06" ] . ToString ( );
                }
                if ( row [ "PY07" ] != null )
                {
                    model . PY07 = row [ "PY07" ] . ToString ( );
                }
                if ( row [ "PY08" ] != null && row [ "PY08" ] . ToString ( ) != "" )
                {
                    model . PY08 = DateTime . Parse ( row [ "PY08" ] . ToString ( ) );
                }
                if ( row [ "PY09" ] != null && row [ "PY09" ] . ToString ( ) != "" )
                {
                    model . PY09 = DateTime . Parse ( row [ "PY09" ] . ToString ( ) );
                }
                if ( row [ "PY32" ] != null )
                {
                    model . PY32 = row [ "PY32" ] . ToString ( );
                }
                if ( row [ "PY34" ] != null && row [ "PY34" ] . ToString ( ) != "" )
                {
                    model . PY34 = DateTime . Parse ( row [ "PY34" ] . ToString ( ) );
                }
                if ( row [ "PY10" ] != null && row [ "PY10" ] . ToString ( ) != "" )
                {
                    model . PY10 = long . Parse ( row [ "PY10" ] . ToString ( ) );
                }
                if ( row [ "PY11" ] != null && row [ "PY11" ] . ToString ( ) != "" )
                {
                    model . PY11 = int . Parse ( row [ "PY11" ] . ToString ( ) );
                }
                if ( row [ "PY12" ] != null && row [ "PY12" ] . ToString ( ) != "" )
                {
                    model . PY12 = int . Parse ( row [ "PY12" ] . ToString ( ) );
                }
                if ( row [ "PY13" ] != null && row [ "PY13" ] . ToString ( ) != "" )
                {
                    model . PY13 = int . Parse ( row [ "PY13" ] . ToString ( ) );
                }
                if ( row [ "PY14" ] != null && row [ "PY14" ] . ToString ( ) != "" )
                {
                    model . PY14 = int . Parse ( row [ "PY14" ] . ToString ( ) );
                }
                if ( row [ "PY15" ] != null && row [ "PY15" ] . ToString ( ) != "" )
                {
                    model . PY15 = int . Parse ( row [ "PY15" ] . ToString ( ) );
                }
                if ( row [ "PY16" ] != null && row [ "PY16" ] . ToString ( ) != "" )
                {
                    model . PY16 = decimal . Parse ( row [ "PY16" ] . ToString ( ) );
                }
                if ( row [ "PY17" ] != null && row [ "PY17" ] . ToString ( ) != "" )
                {
                    model . PY17 = decimal . Parse ( row [ "PY17" ] . ToString ( ) );
                }
                if ( row [ "PY18" ] != null && row [ "PY18" ] . ToString ( ) != "" )
                {
                    model . PY18 = decimal . Parse ( row [ "PY18" ] . ToString ( ) );
                }
                if ( row [ "PY19" ] != null && row [ "PY19" ] . ToString ( ) != "" )
                {
                    model . PY19 = int . Parse ( row [ "PY19" ] . ToString ( ) );
                }
                if ( row [ "PY20" ] != null && row [ "PY20" ] . ToString ( ) != "" )
                {
                    model . PY20 = int . Parse ( row [ "PY20" ] . ToString ( ) );
                }
                if ( row [ "PY21" ] != null && row [ "PY21" ] . ToString ( ) != "" )
                {
                    model . PY21 = int . Parse ( row [ "PY21" ] . ToString ( ) );
                }
                if ( row [ "PY22" ] != null )
                {
                    model . PY22 = row [ "PY22" ] . ToString ( );
                }
                if ( row [ "PY23" ] != null && row [ "PY23" ] . ToString ( ) != "" )
                {
                    model . PY23 = decimal . Parse ( row [ "PY23" ] . ToString ( ) );
                }
                if ( row [ "PY24" ] != null )
                {
                    model . PY24 = row [ "PY24" ] . ToString ( );
                }
                if ( row [ "PY25" ] != null )
                {
                    model . PY25 = row [ "PY25" ] . ToString ( );
                }
                if ( row [ "PY36" ] != null )
                {
                    model . PY36 = row [ "PY36" ] . ToString ( );
                }
                if ( row [ "PY26" ] != null )
                {
                    model . PY26 = row [ "PY26" ] . ToString ( );
                }
                if ( row [ "PY28" ] != null )
                {
                    model . PY28 = row [ "PY28" ] . ToString ( );
                }
                if ( row [ "PY29" ] != null )
                {
                    model . PY29 = row [ "PY29" ] . ToString ( );
                }
                if ( row [ "PY35" ] != null && row [ "PY35" ] . ToString ( ) != "" )
                {
                    model . PY35 = decimal . Parse ( row [ "PY35" ] . ToString ( ) );
                }
                if ( row [ "PY37" ] != null )
                {
                    model . PY37 = row [ "PY37" ] . ToString ( );
                }
                if ( row [ "PY39" ] != null )
                {
                    model . PY39 = row [ "PY39" ] . ToString ( );
                }
                if ( row [ "PY40" ] != null && row [ "PY40" ] . ToString ( ) != "" )
                {
                    model . PY40 = DateTime . Parse ( row [ "PY40" ] . ToString ( ) );
                }
                if ( row [ "PY41" ] != null )
                {
                    model . PY41 = row [ "PY41" ] . ToString ( );
                }
                if ( row [ "PY42" ] != null )
                {
                    model . PY42 = row [ "PY42" ] . ToString ( );
                }
                if ( row [ "PY43" ] != null )
                {
                    model . PY43 = row [ "PY43" ] . ToString ( );
                }
                if ( row [ "PY44" ] != null && !string . IsNullOrEmpty ( row [ "PY44" ] . ToString ( ) ) )
                {
                    model . PY44 = DateTime . Parse ( row [ "PY44" ] . ToString ( ) );
                }
                if ( row [ "PY45" ] != null )
                {
                    model . PY45 = row [ "PY45" ] . ToString ( );
                }
                if ( row [ "PY46" ] != null && row [ "PY46" ] . ToString ( ) != string . Empty )
                {
                    model . PY46 = row [ "PY46" ] . ToString ( );
                }
                if ( row [ "PY47" ] != null && row [ "PY47" ] . ToString ( ) != string . Empty )
                {
                    model . PY47 = bool . Parse ( row [ "PY47" ] . ToString ( ) );
                }
            }

            return model;

        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="logins"></param>
        /// <param name="stateOfOdd"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary . FrmpenyouqichenEntity model ,string logins ,string stateOfOdd )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQY SET " );
            strSql . Append ( "PY01=@PY01," );
            strSql . Append ( "PY02=@PY02," );
            strSql . Append ( "PY03=@PY03," );
            strSql . Append ( "PY04=@PY04," );
            strSql . Append ( "PY05=@PY05," );
            strSql . Append ( "PY06=@PY06," );
            strSql . Append ( "PY07=@PY07," );
            strSql . Append ( "PY08=@PY08," );
            strSql . Append ( "PY09=@PY09," );
            strSql . Append ( "PY27=@PY27," );
            strSql . Append ( "PY28=@PY28," );
            strSql . Append ( "PY29=@PY29," );
            strSql . Append ( "PY30=@PY30," );
            strSql . Append ( "PY31=@PY31," );
            strSql . Append ( "PY32=@PY32," );
            strSql . Append ( "PY34=@PY34," );
            strSql . Append ( "PY38=@PY38," );
            strSql . Append ( "PY39=@PY39," );
            strSql . Append ( "PY40=@PY40, " );
            strSql . Append ( "PY41=@PY41," );
            strSql . Append ( "PY47=@PY47 " );
            strSql . Append ( "WHERE PY33=@PY33" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@PY01", SqlDbType.NVarChar,200),
                    new SqlParameter("@PY02", SqlDbType.NVarChar,10),
                    new SqlParameter("@PY03", SqlDbType.Date,3),
                    new SqlParameter("@PY04", SqlDbType.NVarChar,10),
                    new SqlParameter("@PY05", SqlDbType.Date,3),
                    new SqlParameter("@PY06", SqlDbType.NVarChar,10),
                    new SqlParameter("@PY07", SqlDbType.NVarChar,10),
                    new SqlParameter("@PY08", SqlDbType.Date,3),
                    new SqlParameter("@PY09", SqlDbType.Date,3),
                    new SqlParameter("@PY27", SqlDbType.BigInt,8),
                    new SqlParameter("@PY28", SqlDbType.NVarChar,255),
                    new SqlParameter("@PY29", SqlDbType.NVarChar,200),
                    new SqlParameter("@PY30", SqlDbType.NVarChar,200),
                    new SqlParameter("@PY31", SqlDbType.NVarChar,200),
                    new SqlParameter("@PY32", SqlDbType.NVarChar,10),
                    new SqlParameter("@PY34", SqlDbType.Date,3),
                    new SqlParameter("@PY38", SqlDbType.NVarChar,200),
                    new SqlParameter("@PY39", SqlDbType.NVarChar,20),
                    new SqlParameter("@PY40", SqlDbType.Date,3),
                    new SqlParameter("@PY41", SqlDbType.NVarChar,20),
                    new SqlParameter("@PY47", SqlDbType.Bit),
                    new SqlParameter("@PY33", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = model . PY01;
            parameters [ 1 ] . Value = model . PY02;
            parameters [ 2 ] . Value = model . PY03;
            parameters [ 3 ] . Value = model . PY04;
            parameters [ 4 ] . Value = model . PY05;
            parameters [ 5 ] . Value = model . PY06;
            parameters [ 6 ] . Value = model . PY07;
            parameters [ 7 ] . Value = model . PY08;
            parameters [ 8 ] . Value = model . PY09;
            parameters [ 9 ] . Value = model . PY27;
            parameters [ 10 ] . Value = model . PY28;
            parameters [ 11 ] . Value = model . PY29;
            parameters [ 12 ] . Value = model . PY30;
            parameters [ 13 ] . Value = model . PY31;
            parameters [ 14 ] . Value = model . PY32;
            parameters [ 15 ] . Value = model . PY34;
            parameters [ 16 ] . Value = model . PY38;
            parameters [ 17 ] . Value = model . PY39;
            parameters [ 18 ] . Value = model . PY40;
            parameters [ 19 ] . Value = model . PY41;
            parameters [ 20 ] . Value = model . PY47;
            parameters [ 21 ] . Value = model . PY33;
            SQLString . Add ( strSql ,parameters );
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE R_PQY SET PY01='{0}',PY02='{1}',PY03='{2}',PY04='{3}',PY05='{4}',PY06='{5}',PY07='{6}',PY08='{7}',PY09='{8}',PY27='{9}',PY28='{10}',PY29='{11}',PY30='{12}',PY31='{13}',PY32='{14}',PY34='{15}',PY38='{16}',PY39='{17}',PY40='{18}',PY41='{19}',PY47='{21}' WHERE PY33='{20}'" ,model . PY01 ,model . PY02 ,model . PY03 ,model . PY04 ,model . PY05 ,model . PY06 ,model . PY07 ,model . PY08 ,model . PY09 ,model . PY27 ,model . PY28 ,model . PY29 ,model . PY30 ,model . PY31 ,model . PY32 ,model . PY34 ,model . PY38 ,model . PY39 ,model . PY40 ,model . PY41 ,model . PY33 ,model . PY47 );
            SQLString . Add ( MulaolaoBll . Drity . DrityOfComparation ( "R_495" ,"喷油漆承揽生产加工合同" ,logins ,MulaolaoBll . Drity . GetDt ( ) ,model . PY33 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"保存" ,stateOfOdd ) ,null );
            //SQLString . Add ( MulaolaoBll . Drity . DrityOfCopy ( "R_PQYC" ,"R_PQY" ,"PY33" ,model . PY33 ) ,null );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 增加数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="logins"></param>
        /// <param name="stateOfOdd"></param>
        /// <returns></returns>
        public bool Add ( MulaolaoLibrary . FrmpenyouqichenEntity model ,string logins ,string stateOfOdd )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQY (PY01,PY02,PY03,PY04,PY05,PY06,PY07,PY08,PY09,PY27,PY33,PY28,PY29,PY30,PY31,PY32,PY34,PY38,PY39,PY40,PY41,PY47) VALUES (@PY01,@PY02,@PY03,@PY04,@PY05,@PY06,@PY07,@PY08,@PY09,@PY27,@PY33,@PY28,@PY29,@PY30,@PY31,@PY32,@PY34,@PY38,@PY39,@PY40,@PY41,@PY47)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@PY01", SqlDbType.NVarChar,200),
                    new SqlParameter("@PY02", SqlDbType.NVarChar,10),
                    new SqlParameter("@PY03", SqlDbType.Date,3),
                    new SqlParameter("@PY04", SqlDbType.NVarChar,10),
                    new SqlParameter("@PY05", SqlDbType.Date,3),
                    new SqlParameter("@PY06", SqlDbType.NVarChar,10),
                    new SqlParameter("@PY07", SqlDbType.NVarChar,10),
                    new SqlParameter("@PY08", SqlDbType.Date,3),
                    new SqlParameter("@PY09", SqlDbType.Date,3),
                    new SqlParameter("@PY27", SqlDbType.BigInt,8),
                    new SqlParameter("@PY28", SqlDbType.NVarChar,255),
                    new SqlParameter("@PY29", SqlDbType.NVarChar,200),
                    new SqlParameter("@PY30", SqlDbType.NVarChar,200),
                    new SqlParameter("@PY31", SqlDbType.NVarChar,200),
                    new SqlParameter("@PY32", SqlDbType.NVarChar,10),
                    new SqlParameter("@PY34", SqlDbType.Date,3),
                    new SqlParameter("@PY38", SqlDbType.NVarChar,200),
                    new SqlParameter("@PY39", SqlDbType.NVarChar,20),
                    new SqlParameter("@PY40", SqlDbType.Date,3),
                    new SqlParameter("@PY41", SqlDbType.NVarChar,20),
                    new SqlParameter("@PY47", SqlDbType.Bit),
                    new SqlParameter("@PY33", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = model . PY01;
            parameters [ 1 ] . Value = model . PY02;
            parameters [ 2 ] . Value = model . PY03;
            parameters [ 3 ] . Value = model . PY04;
            parameters [ 4 ] . Value = model . PY05;
            parameters [ 5 ] . Value = model . PY06;
            parameters [ 6 ] . Value = model . PY07;
            parameters [ 7 ] . Value = model . PY08;
            parameters [ 8 ] . Value = model . PY09;
            parameters [ 9 ] . Value = model . PY27;
            parameters [ 10 ] . Value = model . PY28;
            parameters [ 11 ] . Value = model . PY29;
            parameters [ 12 ] . Value = model . PY30;
            parameters [ 13 ] . Value = model . PY31;
            parameters [ 14 ] . Value = model . PY32;
            parameters [ 15 ] . Value = model . PY34;
            parameters [ 16 ] . Value = model . PY38;
            parameters [ 17 ] . Value = model . PY39;
            parameters [ 18 ] . Value = model . PY40;
            parameters [ 19 ] . Value = model . PY41;
            parameters [ 20 ] . Value = model . PY47;
            parameters [ 21 ] . Value = model . PY33;
            SQLString . Add ( strSql ,parameters );
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "INSERT INTO R_PQY (PY01,PY02,PY03,PY04,PY05,PY06,PY07,PY08,PY09,PY27,PY33,PY28,PY29,PY30,PY31,PY32,PY34,PY38,PY39,PY40,PY41,PY47) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}')" ,model . PY01 ,model . PY02 ,model . PY03 ,model . PY04 ,model . PY05 ,model . PY06 ,model . PY07 ,model . PY08 ,model . PY09 ,model . PY27 ,model . PY33 ,model . PY28 ,model . PY29 ,model . PY30 ,model . PY31 ,model . PY32 ,model . PY34 ,model . PY38 ,model . PY39 ,model . PY40 ,model . PY41 ,model . PY47 );
            SQLString . Add ( MulaolaoBll . Drity . DrityOfComparation ( "R_495" ,"喷油漆承揽生产加工合同" ,logins ,MulaolaoBll . Drity . GetDt ( ) ,model . PY33 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"保存" ,stateOfOdd ) ,null );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

    }
}

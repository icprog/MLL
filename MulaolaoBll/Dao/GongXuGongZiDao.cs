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
    public class GongXuGongZiDao
    {
        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists ( MulaolaoLibrary.GongXuGongZiLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQR" );
            strSql.Append( " WHERE  DS21=@DS21 AND DS03=@DS03 AND DS04=@DS04" );
            SqlParameter[] parameter = {
                new SqlParameter("@DS21",SqlDbType.NVarChar),
                new SqlParameter("@DS03",SqlDbType.NVarChar),
                new SqlParameter("@DS04",SqlDbType.NVarChar)
            };

            parameter[0].Value = model.DS21;
            parameter[1].Value = model.DS03;
            parameter[2].Value = model.DS04;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 是否存在流水号
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool Exists ( string num ,string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM R_PQR WHERE DS01='{0}' AND DS21!='{1}'" ,num ,oddNum );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 同填表人，同流水只能有一张表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsUserAndNum ( MulaolaoLibrary . GongXuGongZiLibrary model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM R_PQR" );
            strSql . Append ( " WHERE  DS01=@DS01 AND DS11=@DS11 AND DS21!=@DS21" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@DS01",SqlDbType.NVarChar),
                new SqlParameter("@DS11",SqlDbType.NVarChar),
                new SqlParameter("@DS21",SqlDbType.NVarChar)
            };
            parameter [ 0 ] . Value = model . DS01;
            parameter [ 1 ] . Value = model . DS11;
            parameter [ 2 ] . Value = model . DS21;

            return SqlHelper . Exists ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add ( MulaolaoLibrary.GongXuGongZiLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQR (" );
            strSql.Append( "DS01,DS02,DS03,DS04,DS05,DS06,DS09,DS18,DS21,DS22,DS24,DS25,DS26,DS27,DS29)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}')" ,model.DS01 ,model.DS02 ,model.DS03 ,model.DS04 ,model.DS05 ,model.DS06 ,model.DS09 ,model.DS18 ,model.DS21 ,model.DS22 ,model.DS24 ,model.DS25 ,model.DS26 ,model.DS27 ,model.DS29 );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.DS21 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }


        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.GongXuGongZiLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            Hashtable SQLString = new Hashtable ( );
            //ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQR SET " );
            strSql.AppendFormat( "DS01='{0}'," ,model.DS01 );
            strSql.AppendFormat( "DS02='{0}'," ,model.DS02 );
            strSql.AppendFormat( "DS03='{0}'," ,model.DS03 );
            strSql.AppendFormat( "DS04='{0}'," ,model.DS04 );
            strSql.AppendFormat( "DS05='{0}'," ,model.DS05 );
            strSql.AppendFormat( "DS06='{0}'," ,model.DS06 );
            strSql.AppendFormat( "DS09='{0}'," ,model.DS09 );
            strSql.AppendFormat( "DS18='{0}'," ,model.DS18 );
            strSql.AppendFormat( "DS21='{0}'," ,model.DS21 );
            strSql.AppendFormat( "DS22='{0}'," ,model.DS22 );
            strSql.AppendFormat( "DS24='{0}'," ,model.DS24 );
            strSql.AppendFormat( "DS25='{0}'," ,model.DS25 );
            strSql.AppendFormat( "DS26='{0}'," ,model.DS26 );
            strSql.Append( "DS27=@DS27," );
            strSql.AppendFormat( "DS29='{0}'" ,model.DS29 );
            strSql.AppendFormat( " WHERE idx='{0}'" ,model.Idx );
            SqlParameter [ ] parameter = {
                new SqlParameter("@DS27",SqlDbType.Date)
            };
            parameter [ 0 ] . Value = model . DS27;
            SQLString.Add( strSql.ToString( ),parameter );
            SQLString . Add ( Drity . DrityOfComparation ( tableNum ,tableName ,logins ,dtOne ,model . DS21 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,stateOf ,stateOfOdd ) ,null );

            return SqlHelper.ExecuteSqlTran( SQLString );   
        }
        

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateWei ( MulaolaoLibrary.GongXuGongZiLibrary model  )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQR SET" );
            strSql.AppendFormat( " DS10='{0}',",model.DS10 );
            strSql.AppendFormat( " DS11='{0}'," ,model.DS11 );
            strSql.AppendFormat( " DS12='{0}'," ,model.DS12 );
            strSql.AppendFormat( " DS13='{0}'," ,model.DS13 );
            strSql.AppendFormat( " DS14='{0}'," ,model.DS14 );
            strSql.AppendFormat( " DS19='{0}'," ,model.DS19 );
            strSql.AppendFormat( " DS20='{0}'," ,model.DS20 );
            strSql.AppendFormat( " DS01='{0}'," ,model.DS01 );
            strSql.AppendFormat( " DS22='{0}'," ,model.DS22 );
            strSql.AppendFormat( " DS24='{0}'," ,model.DS24 );
            strSql.AppendFormat( " DS25='{0}'," ,model.DS25 );
            strSql.AppendFormat( " DS26='{0}'," ,model.DS26 );
            strSql.AppendFormat( " DS27='{0}'" ,model.DS27 );
            strSql.AppendFormat( " WHERE DS21='{0}'" ,model.DS21 );
            SQLString.Add( strSql.ToString( ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }


        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateOther ( MulaolaoLibrary.GongXuGongZiLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQR SET" );
            strSql.AppendFormat( " DS10='{0}'," ,model.DS10 );
            strSql.AppendFormat( " DS11='{0}'," ,model.DS11 );
            strSql.AppendFormat( " DS12='{0}'," ,model.DS12 );
            strSql.AppendFormat( " DS13='{0}'," ,model.DS13 );
            strSql.AppendFormat( " DS14='{0}'," ,model.DS14 );
            strSql.AppendFormat( " DS01='{0}'," ,model.DS01 );
            strSql.AppendFormat( " DS22='{0}'," ,model.DS22 );
            strSql.AppendFormat( " DS24='{0}'," ,model.DS24 );
            strSql.AppendFormat( " DS25='{0}'," ,model.DS25 );
            strSql.AppendFormat( " DS26='{0}'," ,model.DS26 );
            strSql.AppendFormat( " DS27='{0}'" ,model.DS27 );
            strSql.AppendFormat( " WHERE DS21='{0}'" ,model.DS21 );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.DS21 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
            
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd ,string oddNum )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQR" );
            strSql.AppendFormat( " WHERE idx='{0}'" ,idx );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }


        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DeleteOddNum ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQR" );
            strSql.AppendFormat( " WHERE DS21='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string strWhere)
        {
            //A.GZ01=B.DS01 AND 
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) S,SUM(U0) D0,SUM(U1) D1,SUM(U2) D2,SUM(U3) D3,B.idx,DS02,DS03,DS04,DS06,DS09,DS18,DS05,DS25,DS29 FROM (SELECT GZ01,GZ03,GZ04,SUM(GZ06*GZ25+GZ05*(GZ12+GZ13+GZ14)) U0,SUM(GZ25+GZ26) U1,SUM(GZ06*GZ25) U2,SUM(GZ05*(GZ12+GZ13+GZ14)) U3 FROM R_PQW GROUP BY GZ01,GZ35,GZ24,GZ17,GZ03,GZ04)A RIGHT JOIN R_PQR B ON A.GZ03=B.DS03 AND A.GZ04=B.DS04 AND GZ01=DS01" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( " GROUP BY B.idx,DS02,DS05,DS18,DS03,DS04,DS06,DS09,DS18,DS29,DS25 ORDER BY REVERSE(DS03)" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTable ( string strWhere ,string numCount)
        {
            //A.GZ01=B.DS01 AND 
            StringBuilder strSql = new StringBuilder( );
            //strSql.Append( "SELECT COUNT(1) S,ISNULL(SUM(U0),0) D0,ISNULL(SUM(U1),0) D1,ISNULL(SUM(U2),0) D2,ISNULL(SUM(U3),0) D3,B.idx,DS02,DS03,DS04,DS06,DS09,DS18,DS05,DS25,DS29 FROM (SELECT GZ01,GZ03,GZ04,SUM(GZ06*GZ25+GZ05*(GZ12+GZ13+GZ14)) U0,SUM(GZ25+GZ26) U1,SUM(GZ06*GZ25) U2,SUM(GZ05*(GZ12+GZ13+GZ14)) U3 FROM R_PQW GROUP BY GZ01,GZ35,GZ24,GZ17,GZ03,GZ04)A RIGHT JOIN R_PQR B ON A.GZ03=B.DS03 AND A.GZ04=B.DS04 AND GZ01=DS01" );
            //strSql.Append( " WHERE DS01 IN (" + numCount + ")" );
            //strSql.Append( " AND " + strWhere );
            //strSql.Append( " GROUP BY B.idx,DS02,DS05,DS18,DS03,DS04,DS06,DS09,DS18,DS29,DS25 ORDER BY REVERSE(DS03)" );
            strSql . AppendFormat ( "SELECT SUM(ISNULL(GZ,0)) S,ISNULL(SUM(U0),0) D0,ISNULL(SUM(U1),0) D1,ISNULL(SUM(U2),0) D2,ISNULL(SUM(U3),0) D3,B.idx,DS02,DS03,DS04,DS06,DS09,DS18,DS05,DS25,DS29 FROM (SELECT SUM(GZ09+GZ10+GZ11+GZ12+GZ13+GZ14) GZ,GZ01,GZ03,GZ04,SUM(GZ06*GZ25+GZ05*(GZ12+GZ13+GZ14)) U0,SUM(GZ25+GZ26) U1,SUM(GZ06*GZ25) U2,SUM(GZ05*(GZ12+GZ13+GZ14)) U3 FROM R_PQW WHERE GZ01 IN ({0}) GROUP BY GZ01,GZ35,GZ24,GZ17,GZ03,GZ04 )A RIGHT JOIN R_PQR B ON A.GZ03=B.DS03 AND A.GZ04=B.DS04 AND GZ01=DS01" ,numCount );
            strSql . Append ( " WHERE DS01 IN (" + numCount + ")" );
            strSql . Append ( " AND " + strWhere );
            strSql . Append ( " GROUP BY B.idx,DS02,DS05,DS18,DS03,DS04,DS06,DS09,DS18,DS29,DS25 ORDER BY REVERSE(DS03)" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表 定日工资额
        /// </summary>
        /// <param name="workPrice"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrice ( string workPrice )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT GX03 FROM R_PQAA" );
            strSql.Append( " WHERE GX02=@GX02" );
            SqlParameter[] parameter = {
                new SqlParameter("@GX02",SqlDbType.NVarChar)
            };

            parameter[0].Value = workPrice;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 是否送审
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="formText"></param>
        /// <returns></returns>
        public bool ExistsReview ( string oddNum,string formText )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_REVIEWS A,R_MLLCXMC B" );
            strSql.AppendFormat( "  WHERE A.RES01=B.CX01 AND RES05='执行' AND RES06='{0}' AND CX02='{1}'" ,oddNum ,formText );

            return SqlHelper.Exists( strSql.ToString( ) );
        }


        /// <summary>
        /// 得到数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableAll ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQR" );
            strSql.Append( " WHERE DS21=@DS21" );
            SqlParameter[] parameter = {
                new SqlParameter("@DS21",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }



        /// <summary>
        /// 得到实体对象 查询
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT DS21,DS01,DS22,DS24,DS25,DS26,DS02 FROM R_PQR" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetGongXuCount (string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM (SELECT DISTINCT DS01,DS02,DS21,DS22,DS24,DS26 FROM R_PQR) A" );
            strSql.Append( " WHERE " + strWhere );

            object obj = SqlHelper.GetSingle( strSql.ToString( ) );
            if ( obj == null )
                return 0;
            else
                return Convert.ToInt32( obj );
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTableByChange ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT DS21,DS01,DS22,DS24,DS25,DS26,DS02,(SELECT RES05 FROM R_REVIEWS WHERE RES04=(SELECT MAX(RES04) FROM R_REVIEWS WHERE RES06=DS21)) RES05 FROM (" );
            strSql.Append( "SELECT ROW_NUMBER() OVER(" );
            strSql.Append( "ORDER BY T.DS21 DESC" );
            strSql.Append( ") AS Row,T.* FROM (SELECT DISTINCT DS21,DS01,DS22,DS24,DS25,DS26,DS02 FROM R_PQR) T" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") TT" );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取一个实例对象
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.GongXuGongZiLibrary GetModel ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQR" );
            strSql.Append( " WHERE idx=@idx" );

            SqlParameter[] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };

            parameter[0].Value = idx;

            DataTable dt = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( dt.Rows.Count > 0 )
                return GetDataRow( dt.Rows[0] );
            else
                return null;
        }


        /// <summary>
        /// 获取一个实例对象
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.GongXuGongZiLibrary GetDataRow ( DataRow row )
        {
            MulaolaoLibrary.GongXuGongZiLibrary model = new MulaolaoLibrary.GongXuGongZiLibrary( );

            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    model.Idx = int.Parse( row["idx"].ToString( ) );
                if ( row["DS01"] != null && row["DS01"].ToString( ) != "" )
                    model.DS01 = row["DS01"].ToString( );
                if ( row["DS02"] != null && row["DS02"].ToString( ) != "" )
                    model.DS02 = row["DS02"].ToString( );
                if ( row["DS03"] != null && row["DS03"].ToString( ) != "" )
                    model.DS03 = row["DS03"].ToString( );
                if ( row["DS04"] != null && row["DS04"].ToString( ) != "" )
                    model.DS04 = row["DS04"].ToString( );
                if ( row["DS05"] != null && row["DS05"].ToString( ) != "" )
                    model.DS05 = long.Parse( row["DS05"].ToString( ) );
                if ( row["DS06"] != null && row["DS06"].ToString( ) != "" )
                    model.DS06 = long.Parse( row["DS06"].ToString( ) );
                //if ( row["DS07"] != null && row["DS07"].ToString( ) != "" )
                //    model.DS07 = decimal.Parse( row["DS07"].ToString( ) );
                if ( row["DS08"] != null && row["DS08"].ToString( ) != "" )
                    model.DS08 = long.Parse( row["DS08"].ToString( ) );
                if ( row["DS09"] != null && row["DS09"].ToString( ) != "" )
                    model.DS09 = row["DS09"].ToString( );
                if ( row["DS10"] != null && row["DS10"].ToString( ) != "" )
                    model.DS10 = row["DS10"].ToString( );
                if ( row["DS11"] != null && row["DS11"].ToString( ) != "" )
                    model.DS11 = row["DS11"].ToString( );
                if ( row["DS12"] != null && row["DS12"].ToString( ) != "" )
                    model.DS12 = DateTime.Parse( row["DS12"].ToString( ) );
                if ( row["DS13"] != null && row["DS13"].ToString( ) != "" )
                    model.DS13 = row["DS13"].ToString( );
                if ( row["DS14"] != null && row["DS14"].ToString( ) != "" )
                    model.DS14 = DateTime.Parse( row["DS14"].ToString( ) );
                //if ( row["DS15"] != null && row["DS15"].ToString( ) != "" )
                //    model.DS15 = decimal.Parse( row["DS15"].ToString( ) );
                if ( row["DS16"] != null && row["DS16"].ToString( ) != "" )
                    model.DS16 = long.Parse( row["DS16"].ToString( ) );
                if ( row["DS17"] != null && row["DS17"].ToString( ) != "" )
                    model.DS17 = row["DS17"].ToString( );
                if ( row["DS18"] != null && row["DS18"].ToString( ) != "" )
                    model.DS18 = decimal.Parse( row["DS18"].ToString( ) );
                if ( row["DS19"] != null && row["DS19"].ToString( ) != "" )
                    model.DS19 = row["DS19"].ToString( );
                if ( row["DS20"] != null && row["DS20"].ToString( ) != "" )
                    model.DS20 = row["DS20"].ToString( );
                if ( row["DS21"] != null && row["DS21"].ToString( ) != "" )
                    model.DS21 = row["DS21"].ToString( );
                if ( row["DS22"] != null && row["DS22"].ToString( ) != "" )
                    model.DS22 = row["DS22"].ToString( );
                if ( row["DS24"] != null && row["DS24"].ToString( ) != "" )
                    model.DS24 = row["DS24"].ToString( );
                if ( row["DS25"] != null && row["DS25"].ToString( ) != "" )
                    model.DS25 = long.Parse( row["DS25"].ToString( ) );
                if ( row["DS26"] != null && row["DS26"].ToString( ) != "" )
                    model.DS26 = row["DS26"].ToString( );
                if ( row["DS27"] != null && row["DS27"].ToString( ) != "" )
                    model.DS27 = DateTime.Parse( row["DS27"].ToString( ) );
                if ( row["DS28"] != null && row["DS28"].ToString( ) != "" )
                    model.DS28 = int.Parse( row["DS28"].ToString( ) );
                if ( row["DS29"] != null && row["DS29"].ToString( ) != "" )
                    model.DS29 = int.Parse( row["DS29"].ToString( ) );
            }

            return model;
        }

        /// <summary>
        /// 获取本工序名称
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTableWork ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT DS17 FROM R_PQR" );
            strSql.Append( " WHERE DS24=@DS24" );
            SqlParameter[] parameter = {
                new SqlParameter("@DS24",SqlDbType.NVarChar)
            };

            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }


        /// <summary>
        /// 获取零件等信息
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTableProcuce ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            //strSql.Append( "SELECT DISTINCT PQX14,PQX15 FROM R_PQX" );
            //strSql.Append( " WHERE PQX31=@PQX31" );
            //strSql.Append( " UNION" );
            //strSql.Append( " SELECT DISTINCT DS03 ,DS04 FROM R_PQR" );
            //strSql.Append( " WHERE DS24=@PQX31" );
            strSql.Append( "SELECT DISTINCT GS07 FROM R_PQP WHERE GS48=@GS48 AND GS07!='' AND GS07 IS NOT NULL" );
            strSql.Append( " UNION SELECT DISTINCT GS56 GS07 FROM R_PQP WHERE GS48=@GS48 AND GS56!='' AND GS56 IS NOT NULL" );
            SqlParameter[] parameter = {
                new SqlParameter("@GS48",SqlDbType.NVarChar)
            };

            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取工序名称
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableGongXu ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT GZ03,GZ04 FROM R_PQW" );
            strSql.Append( " WHERE GZ01=@GZ01" );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ01",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取生产车间
        /// </summary>
        /// <param name="nameNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableCheJian ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DBA002,DBA001 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002 IN (SELECT DBA002 FROM TPADBA WHERE DBA005=(SELECT DAA001 FROM TPADAA WHERE DAA002='生产部')))" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取流水号等信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableNum ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT PQF01,PQF04,PQF03,PQF06,PQF17,(SELECT DAA002 FROM TPADAA WHERE PQF17=DAA001) DAA002,PQF31 FROM R_PQF A,R_REVIEWS B WHERE  A.PQF01=B.RES06 AND RES05='执行' ORDER BY PQF31 DESC" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 获取工段信息
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTableWorkShop ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT GS35,GS36 FROM R_PQP" );
            strSql.Append( " WHERE GS48=@GS48" );
            strSql.Append( " AND GS35!='' AND GS35 IS NOT NULL" );
            SqlParameter[] parameter = {
                new SqlParameter("@GS48",SqlDbType.NVarChar)
            };

            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }


        /// <summary>
        /// 获取定日产量
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public DataTable GetDataTableDing ( string other ,string num,string GongXu)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT SUM(U0) U0,GZ06,SUM(U1) U1 FROM (SELECT (GZ25+GZ26) U0,GZ06,CONVERT(BIGINT,GZ05*(GZ12+GZ13+GZ14)) U1 FROM R_PQW WHERE GZ03=@GZ03 AND GZ01=@GZ01 AND GZ04=@GZ04) A GROUP BY GZ06" );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ03",SqlDbType.NVarChar),
                new SqlParameter("@GZ01",SqlDbType.NVarChar),
                new SqlParameter("@GZ04",SqlDbType.NVarChar)
            };

            parameter[0].Value = other;
            parameter[1].Value = num;
            parameter[2].Value = GongXu;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 是否存在一条记录
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="mouth">月</param>
        /// <param name="day">日</param>
        /// <param name="num">流水</param>
        /// <param name="partName">零件名称</param>
        /// <param name="workPrice">工序</param>
        /// <returns></returns>
        public bool ExistsWrite ( string year ,int mouth ,int day ,string num ,string partName ,string workPrice )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQW" );
            strSql.Append( " WHERE GZ35=@GZ35 AND GZ24=@GZ24 AND GZ17=@GZ17 AND GZ01=@GZ01 AND GZ03=@GZ03 AND GZ04=@GZ04" );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ35",SqlDbType.NVarChar),
                new SqlParameter("@GZ24",SqlDbType.Int),
                new SqlParameter("@GZ17",SqlDbType.Int),
                new SqlParameter("@GZ01",SqlDbType.NVarChar),
                new SqlParameter("@GZ03",SqlDbType.NVarChar),
                new SqlParameter("@GZ04",SqlDbType.NVarChar)
            };
            parameter[0].Value = year;
            parameter[1].Value = mouth;
            parameter[2].Value = day;
            parameter[3].Value = num;
            parameter[4].Value = partName;
            parameter[5].Value = workPrice;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 更改一条记录
        /// </summary>
        /// <param name="year"></param>
        /// <param name="mouth"></param>
        /// <param name="day"></param>
        /// <param name="num"></param>
        /// <param name="partName"></param>
        /// <param name="workPrice"></param>
        /// <returns></returns>
        public bool UpdateWrite ( string year ,int mouth ,int day ,string num ,string partName ,string workPrice ,decimal price)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQW SET" );
            strSql.Append( " GZ27=@GZ27" );
            strSql.Append( " WHERE GZ35=@GZ35 AND GZ24=@GZ24 AND GZ17=@GZ17 AND GZ01=@GZ01 AND GZ03=@GZ03 AND GZ04=@GZ04" );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ35",SqlDbType.NVarChar),
                new SqlParameter("@GZ24",SqlDbType.Int),
                new SqlParameter("@GZ17",SqlDbType.Int),
                new SqlParameter("@GZ01",SqlDbType.NVarChar),
                new SqlParameter("@GZ03",SqlDbType.NVarChar),
                new SqlParameter("@GZ04",SqlDbType.NVarChar),
                new SqlParameter("@GZ27",SqlDbType.Decimal)
            };
            parameter[0].Value = year;
            parameter[1].Value = mouth;
            parameter[2].Value = day;
            parameter[3].Value = num;
            parameter[4].Value = partName;
            parameter[5].Value = workPrice;
            parameter[6].Value = price;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTableGen ( string num)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT GZ03,GZ04,GX03,GZ40 FROM R_PQW A,R_PQAA B WHERE A.GZ04=B.GX02" );
            strSql.Append( " AND GZ01 IN ("+num+")" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTableLocal ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DS21,DS03,DS04 FROM R_PQR" );
            strSql.Append( " WHERE DS01 IN (" + num + ")" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertGen ( MulaolaoLibrary.GongXuGongZiLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQR (" );
            strSql.Append( " DS21,DS01,DS22,DS24,DS25,DS03,DS04,DS05)" );
            strSql.Append( " VALUES (" );
            strSql.Append( "@DS21,@DS03,@DS04,@DS05)" );
            SqlParameter[] parameter = {
                new SqlParameter("@DS21",SqlDbType.NVarChar),
                new SqlParameter("@DS03",SqlDbType.NVarChar),
                new SqlParameter("@DS04",SqlDbType.NVarChar),
                new SqlParameter("@DS05",SqlDbType.BigInt)
            };
            parameter[0].Value = model.DS21;
            parameter[1].Value = model.DS03;
            parameter[2].Value = model.DS04;
            parameter[3].Value = model.DS05;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTableWorkShops ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,GZ03,CONVERT(FLOAT,ISNULL(CONVERT(DECIMAL(6,0),GS10),0)) GS10 FROM (" );
            strSql.Append( " SELECT DISTINCT idx,GS07 GZ03,GS10  FROM R_PQP" );
            strSql.Append( " WHERE GS01=@DS01" );
            strSql.Append( " UNION SELECT DISTINCT idx,GS56 GZ03,GS59 FROM R_PQP" );
            strSql.Append( " WHERE GS01=@DS01" );
            strSql.Append( " ) A WHERE GZ03!='' AND GZ03 IS NOT NULL ORDER BY REVERSE(GZ03)" );
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
        public DataTable GetDataTableBom ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT GX02,GX03 FROM R_PQAA ORDER BY GX02" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 复制一条记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Copy ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQR (" );
            strSql.Append( "DS01,DS22,DS24,DS25,DS26,DS27,DS02,DS18,DS03,DS04,DS17,DS05,DS06,DS07,DS08,DS15,DS16,DS09,DS10,DS29,DS11)" );
            strSql . AppendFormat ( " SELECT DS01,DS22,DS24,DS25,DS26,DS27,DS02,DS18,DS03,DS04,DS17,DS05,DS06,DS07,DS08,DS15,DS16,DS09,DS10,DS29,'{0}' DS11 FROM R_PQR" ,logins );
            strSql.AppendFormat( " WHERE DS21='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 编译一单记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool CopyUpdate ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "UPDATE R_PQR SET DS21='{0}' WHERE DS21 IS NULL" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 批量编辑部件名称
        /// </summary>
        /// <param name="num"></param>
        /// <param name="oddNum"></param>
        /// <param name="tableName"></param>
        /// <param name="tableNum"></param>
        /// <param name="logins"></param>
        /// <param name="dtOne"></param>
        /// <param name="stateOf"></param>
        /// <param name="stateOfOdd"></param>
        /// <param name="part"></param>
        /// <param name="prePart"></param>
        /// <returns></returns>
        public bool Batch ( string num,string oddNum,string tableName,string tableNum,string logins,DateTime dtOne,string stateOf,string stateOfOdd,string part,string prePart )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE R_PQR SET DS03='{0}' WHERE DS03='{1}' AND DS01='{2}' AND DS21='{3}'" ,part ,prePart ,num ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,stateOf ,stateOfOdd ) );
            
            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 批量编辑工序名称  同流水，同工序
        /// </summary>
        /// <param name="num"></param>
        /// <param name="oddNum"></param>
        /// <param name="tableName"></param>
        /// <param name="tableNum"></param>
        /// <param name="logins"></param>
        /// <param name="dtOne"></param>
        /// <param name="stateOf"></param>
        /// <param name="stateOfOdd"></param>
        /// <param name="work"></param>
        /// <param name="part"></param>
        /// <returns></returns>
        public bool BatchGX ( string num ,string oddNum ,string tableName ,string tableNum ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd ,string work ,string part)
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE R_PQR SET DS04='{0}' WHERE DS01='{1}' AND DS21='{2}' AND DS04='{3}' " ,work ,num ,oddNum ,part );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 删除复制数据
        /// </summary>
        /// <returns></returns>
        public bool DeleteCopy ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQR WHERE DS21 IS NULL" );

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 编辑零件数量
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool UpdateLJ ( string num ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd ,string oddNum )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQR SET DS29=(SELECT GS FROM (SELECT DISTINCT GS01,GS07 GZ,CONVERT(DECIMAL(6,0),GS10) GS  FROM R_PQP) A WHERE GZ!='' AND GZ IS NOT NULL AND A.GS01=DS01 AND A.GZ=DS03)" );
            strSql.AppendFormat( " WHERE DS01='{0}'" ,num );
            SQLString.Add( strSql.ToString( ) );

            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );
            return SqlHelper.ExecuteSqlTran( SQLString );

        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="groupLeader"></param>
        /// <param name="staff"></param>
        /// <returns></returns>
        public DataTable GetDataTableLimit (string groupLeader,string staff )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM TPADAA LEFT JOIN TPADBA ON DAA001=DBA005 WHERE DAA002=@DAA002 AND DBA002=@DBA002" );
            SqlParameter[] parameter = {
                new SqlParameter("@DAA002",SqlDbType.NVarChar),
                new SqlParameter("@DBA002",SqlDbType.NVarChar)
            };
            parameter[0].Value = groupLeader;
            parameter[1].Value = staff;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取预生产产品信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableSeriableNum ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT BG001,BG002,BG003,BG004 FROM R_PQBG" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable getPrintOne ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT DS22,DS01,DS24,DS25,DS27 FROM R_PQR WHERE DS21='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable getPrintTwo ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DS03,DS04,ISNULL(DS25,0)*ISNULL(DS29,0) DS1,ISNULL(DS29,0) DS29,CONVERT(DECIMAL(18,4),CASE WHEN DS06=0 THEN 0 ELSE DS05*1.0/DS06 END) DS2,CONVERT(DECIMAL(18,4),CASE WHEN DS05=0 THEN 0 ELSE ISNULL(DS29,0)*(DS05*1.0/DS06) END) DS3,DS09 FROM R_PQR WHERE DS21='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}


using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using StudentMgr;
using System.Collections;

namespace MulaolaoBll.Dao
{
    public class CostIndexDao
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
            strSql.Append( "DELETE FROM R_PQAT" );
            strSql.AppendFormat( " WHERE AT001='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            //StringBuilder strS = new StringBuilder( );
            //strS.Append( "DELETE FROM R_REVIEWS" );
            //strS.AppendFormat( " WHERE RES06='{0}'" ,oddNum );
            //SQLString.Add( strS.ToString( ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        public bool DeleteTwo ( DateTime dtTime )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQAV" );
            strSql.AppendFormat( " WHERE AV001='{0}'" ,dtTime );
            SQLString.Add( strSql.ToString( ) );
            StringBuilder strS = new StringBuilder( );
            strS.Append( "DELETE FROM R_PQAW" );
            strS.AppendFormat( " WHERE AW001='{0}'" ,dtTime );
            StringBuilder strSt = new StringBuilder( );
            strSt.Append( "DELETE FROM R_PQAX" );
            strSt.AppendFormat( " WHERE AX001='{0}'" ,dtTime );
            SQLString.Add( strSt.ToString( ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT AT001 FROM R_PQAT" );

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
            strSql.Append( "SELECT COUNT(1) FROM (SELECT DISTINCT AT001,AT020 FROM R_PQAT" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") A" );

            Object obj = SqlHelper.GetSingle( strSql.ToString( ) );
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
            strSql.Append( "SELECT DISTINCT AT001,AT020 FROM (" );
            strSql.Append( "SELECT ROW_NUMBER() OVER( " );
            strSql.Append( "ORDER BY T.AT001 DESC" );
            strSql.Append( ") AS Row,T.* FROM R_PQAT T " );
            strSql . Append ( "WHERE " + strWhere );
            strSql.Append( ") TT" );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 生成数据
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool GetDataTableGenerate ( MulaolaoLibrary.CostIndexLibrary _model )
        {
            bool result = false;
            ArrayList SQLString = new ArrayList( );
            DataTable da = new DataTable( );
            _model.AT002 = "";
            _model.AT003 = _model.AT004 = _model.AT005 = _model.AT006 = _model.AT007 = _model.AT008 = _model.AT009 = _model.AT010 = _model.AT011 = _model.AT012 = _model.AT013 = _model.AT014 = _model.AT015 = _model.AT016 = _model.AT017 = _model.AT018 = _model.AT019 = _model.AT021 = 0;
            da = GetDataTableOfCost( _model.AT020.Year ,_model.AT020.Month );
            if ( da != null && da.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < da.Rows.Count ; i++ )
                {
                    _model.AT002 = da.Rows[i]["DA"].ToString( );                
                    _model.AT004 = string.IsNullOrEmpty( da.Rows[i]["AE"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[i]["AE"].ToString( ) );                 
                    if ( Exists( _model.AT002 ,_model.AT020 ,_model.AT001 ) )
                        SQLString.Add( UpdateOfCost( _model ) );
                    else
                        SQLString.Add( AddOfCost( _model ) );
                }
            }
            else
                result = false;

            if ( SqlHelper.ExecuteSqlTran( SQLString ) )
            {
                _model . AT003 = _model . AT004 = _model . AT005 = _model . AT006 = _model . AT007 = _model . AT008 = _model . AT009 = _model . AT010 = _model . AT011 = _model . AT012 = _model . AT013 = _model . AT014 = _model . AT015 = _model . AT016 = _model . AT017 = _model . AT018 = _model . AT019 = _model . AT021 = 0;
                SQLString = new ArrayList( );
                da = new DataTable( );
                da = GetDataTableOfCheckOnWorkAttendance( _model.AT020.Year ,_model.AT020.Month );
                if ( da != null && da.Rows.Count > 0 )
                {
                    for ( int i = 0 ; i < da.Rows.Count ; i++ )
                    {
                        _model.AT002 = da.Rows[i]["GZ30"].ToString( );
                        _model.AT003 = string.IsNullOrEmpty( da.Rows[i]["GZ"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[i]["GZ"].ToString( ) );
                        if ( Exists( _model.AT002 ,_model.AT020 ,_model.AT001 ) )
                            SQLString.Add( UpdateOfCheckOnWorkAttendance( _model ) );
                        else
                            SQLString.Add( AddOfCost( _model ) );
                    }
                }
                else
                    result = false;
            }
            else
                result = false;

            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                _model . AT003 = _model . AT004 = _model . AT005 = _model . AT006 = _model . AT007 = _model . AT008 = _model . AT009 = _model . AT010 = _model . AT011 = _model . AT012 = _model . AT013 = _model . AT014 = _model . AT015 = _model . AT016 = _model . AT017 = _model . AT018 = _model . AT019 = _model . AT021 = 0;
                SQLString = new ArrayList ( );
                da = new DataTable ( );
                da = GetDataTableOfFrontRoadCost ( _model . AT020 . Year ,_model . AT020 . Month );
                if ( da != null && da . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < da . Rows . Count ; i++ )
                    {
                        _model . AT002 = da . Rows [ i ] [ "AM009" ] . ToString ( );
                        //原材料：材料正常成本合同合计应付款
                        _model . AT005 = string . IsNullOrEmpty ( da . Rows [ i ] [ "one" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "one" ] . ToString ( ) );
                        //材料超补：超补材料合同合计应付款+用库存材料超补合同合计应付款
                        _model . AT006 = string . IsNullOrEmpty ( da . Rows [ i ] [ "fore" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "fore" ] . ToString ( ) );
                        //工人工资：工资正常成本合同合计应付款额
                        _model . AT007 = string . IsNullOrEmpty ( da . Rows [ i ] [ "two" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "two" ] . ToString ( ) );
                        //其它：装运费正常成本合同合计应付款
                        _model . AT008 = string . IsNullOrEmpty ( da . Rows [ i ] [ "tre" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "tre" ] . ToString ( ) );
                        if ( Exists ( _model . AT002 ,_model . AT020 ,_model . AT001 ) )
                            SQLString . Add ( UpdateOfFrontRoadCost ( _model ) );
                        else
                            SQLString . Add ( AddOfCost ( _model ) );
                    }
                }
                else
                    result = false;
            }
            else
                result = false;

            if ( SqlHelper.ExecuteSqlTran( SQLString ) )
            {
                _model . AT003 = _model . AT004 = _model . AT005 = _model . AT006 = _model . AT007 = _model . AT008 = _model . AT009 = _model . AT010 = _model . AT011 = _model . AT012 = _model . AT013 = _model . AT014 = _model . AT015 = _model . AT016 = _model . AT017 = _model . AT018 = _model . AT019 = _model . AT021 = 0;
                SQLString = new ArrayList( );
                da = new DataTable( );
                da = GetDataTableOfReadRoadCost( _model.AT020 );
                if ( da != null && da.Rows.Count > 0 )
                {
                    for ( int i = 0 ; i < da.Rows.Count ; i++ )
                    {
                        _model.AT002 = da.Rows[i]["Z"].ToString( );
                        _model.AT009 = string.IsNullOrEmpty( da.Rows[i]["S2"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[i]["S2"].ToString( ) );
                        _model.AT010 = string.IsNullOrEmpty( da.Rows[i]["S1"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[i]["S1"].ToString( ) );
                        _model.AT011 = string.IsNullOrEmpty( da.Rows[i]["S3"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[i]["S3"].ToString( ) );
                        _model.AT018 = string.IsNullOrEmpty( da.Rows[i]["S"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[i]["S"].ToString( ) );
                        if ( Exists( _model.AT002 ,_model.AT020 ,_model.AT001 ) )
                            SQLString.Add( UpdateOfReadRoadCost( _model ) );
                        else
                            SQLString.Add( AddOfCost( _model ) );
                    }
                }
                else
                    result = false;
            }
            else
                result = false;

            result = SqlHelper.ExecuteSqlTran( SQLString );

            return result;
        }

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="names"></param>
        /// <param name="dt"></param>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Exists ( string names ,DateTime dt ,string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQAT" );
            strSql.Append( " WHERE AT001=@AT001 AND AT020=@AT020 AND AT002=@AT002" );
            SqlParameter[] parameter = {
                new SqlParameter("@AT001",SqlDbType.NVarChar,20),
                new SqlParameter("@AT002",SqlDbType.NVarChar,20),
                new SqlParameter("@AT020",SqlDbType.Date)
            };
            parameter[0].Value = oddNum;
            parameter[1].Value = names;
            parameter[2].Value = dt;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取销售额
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfCost (int year,int month )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT CONVERT(DECIMAL(18,0),SUM(AE)) AE,DA  FROM (" );
            strSql . AppendFormat ( "SELECT SUM(AE19) AE,CASE WHEN DA IS NULL OR DA='生产部' THEN DAA002 ELSE DA END DA FROM (SELECT  AE19,A.DAA002 DA,B.DAA002 FROM R_PQAE LEFT JOIN (SELECT DISTINCT DBA002,DAA002 FROM TPADAA LEFT JOIN TPADBA ON DAA001=DBA005) A ON A.DBA002=AE08 LEFT JOIN TPADAA B ON B.DAA002=AE08 WHERE YEAR(AE21)={0} AND MONTH(AE21)={1} GROUP BY A.DAA002,B.DAA002,AE02,AE21,AE19" ,year ,month );
            strSql.Append( " ) A GROUP BY DA,DAA002" );
            strSql.Append( " ) A WHERE AE!=0 GROUP BY DA" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public string UpdateOfCost ( MulaolaoLibrary.CostIndexLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAT SET " );
            strSql.AppendFormat( "AT004='{0}'" ,_model.AT004 );
            strSql.AppendFormat( " WHERE AT001='{0}' AND AT002='{1}'" ,_model.AT001 ,_model.AT002 );

            return strSql.ToString( );
        }
        public string AddOfCost ( MulaolaoLibrary.CostIndexLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAT (" );
            strSql.Append( "AT001,AT002,AT003,AT004,AT005,AT006,AT007,AT008,AT009,AT010,AT011,AT012,AT013,AT014,AT015,AT016,AT017,AT018,AT019,AT020,AT021)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}')" ,_model.AT001 ,_model.AT002 ,_model.AT003 ,_model.AT004 ,_model.AT005 ,_model.AT006 ,_model.AT007 ,_model.AT008 ,_model.AT009 ,_model.AT010 ,_model.AT011 ,_model.AT012 ,_model.AT013 ,_model.AT014 ,_model.AT015 ,_model.AT016 ,_model.AT017 ,_model.AT018 ,_model.AT019 ,_model.AT020 ,_model.AT021 );

            return strSql.ToString( );
        }

        /// <summary>
        /// 获取考勤天数
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfCheckOnWorkAttendance (int year,int month )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT CONVERT(DECIMAL(18,0),SUM(GZ09+GZ10+GZ11+GZ12+GZ13+GZ14)) GZ,GZ30 FROM R_PQW " );
            strSql.Append( "WHERE GZ35=@YEAR AND GZ24=@MONTH" );
            strSql.Append( " GROUP BY GZ30" );
            SqlParameter[] parameter = {
                new SqlParameter("@YEAR",SqlDbType.Int),
                new SqlParameter("@MONTH",SqlDbType.Int)
            };
            parameter[0].Value = year;
            parameter[1].Value = month;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public string UpdateOfCheckOnWorkAttendance ( MulaolaoLibrary.CostIndexLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAT SET " );
            strSql.AppendFormat( "AT003='{0}'" ,_model.AT003 );
            strSql.AppendFormat( " WHERE AT001='{0}' AND AT002='{1}'" ,_model.AT001,_model.AT002 );

            return strSql.ToString( );
        }
        public string AddOfCheckOnWorkAttendance ( MulaolaoLibrary.CostIndexLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAT (" );
            strSql.Append( "AT001,AT002,AT003,AT020)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}')" ,_model.AT001 ,_model.AT002 ,_model.AT003 ,_model.AT020 );

            return strSql.ToString( );
        }

        /// <summary>
        /// 获取241数据  前道
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfFrontRoadCost (int year,int month )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql . Append ( "WITH CET AS (" );
            strSql . AppendFormat ( "SELECT A.idx,AM336+AM343+AM361+AM346+AM349+AM367+AM352+AM370+AM355+AM153+AM339+AM364+AM157+AM330+AM333+AM358+AM373+AM376+AM379+AM385+AM388+AM391+AM298+AM301+AM307+AM311+AM304+AM318+AM315+AM321+AM270+AM273+AM277+AM280+AM249+AM242+AM245+AM239+AM209+AM212+AM215+AM225+AM229+AM233+AM175+AM178+AM182+AM185+AM188+AM191+AM194+AM197+AM136+AM139+AM142+AM145+AM148+AM237+AM108+AM111+AM084 U104,AM070+AM072+AM074+AM076+AM078+AM080+AM082+AM086+AM088+AM090+AM092+AM044+AM046+AM048+AM050+AM052+AM054+AM056+AM058+AM060+AM062 U105,AM020+AM022+AM024+AM026+AM028 U106,AM338+AM351+AM381+AM357+AM363+AM294+AM369+AM292+AM332+AM155+AM345+AM390+AM300+AM306+AM320+AM324+AM272+AM279+AM211+AM217+AM221+AM255+AM241+AM247+AM252+AM177+AM184+AM190+AM196 U107,AM158+AM261+AM263+AM265+AM267+AM287+AM288+AM290+AM375+AM382+AM313+AM328+AM326+AM296+AM283+AM285+AM227+AM231+AM235+AM255+AM241+AM200+AM203+AM205+AM207 U108,CASE WHEN AM009='' OR AM009='生产部' THEN AM008 ELSE AM009 END AM009 FROM R_PQAM A LEFT JOIN R_PQF B ON A.AM002=B.PQF01 WHERE YEAR(B.PQF31)={0} AND MONTH(B.PQF31)={1})  " ,year ,month );
            strSql . AppendFormat ( "SELECT SUM(CONVERT(DECIMAL(18,0),U104)) one,SUM(CONVERT(DECIMAL(18,0),U105)) two,SUM(CONVERT(DECIMAL(18,0),U106)) tre,SUM(CONVERT(DECIMAL(18,0),U107)+CONVERT(DECIMAL(18,0),U108)) fore,AM009 FROM CET GROUP BY AM009" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }
        public string UpdateOfFrontRoadCost ( MulaolaoLibrary.CostIndexLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAT SET " );
            strSql.AppendFormat( "AT005='{0}'," ,_model.AT005 );
            strSql.AppendFormat( "AT006='{0}'," ,_model.AT006 );
            strSql.AppendFormat( "AT007='{0}'," ,_model.AT007 );
            strSql.AppendFormat( "AT008='{0}'" ,_model.AT008 );
            strSql.AppendFormat( " WHERE AT001='{0}' AND AT002='{1}'" ,_model.AT001 ,_model.AT002 );

            return strSql.ToString( );
        }
        public string AddOfFrontRoadCost ( MulaolaoLibrary.CostIndexLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAT (" );
            strSql.Append( "AT001,AT002,AT005,AT006,AT007,AT008,AT020)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}')" ,_model.AT001 ,_model.AT002 ,_model.AT005 ,_model.AT006 ,_model.AT007 ,_model.AT008 ,_model.AT020 );

            return strSql.ToString( ); 
        }

        /// <summary>
        /// 获取后道工资
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfReadRoadCost ( DateTime dt )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "WITH CET AS(" );
            strSql.Append( "SELECT sum(ISNULL(XZ023,0)+ISNULL(XZ021,0)+CONVERT(DECIMAL(18,5),ISNULL(XZ005,0)/day(dateadd(d,-day(@dt),dateadd(m,1,@dt))))*(ISNULL(XZ006,0)+ISNULL(XZ007,0))-(ISNULL(XZ010,0)+ISNULL(XZ008,0)+ISNULL(XZ011,0)+ISNULL(XZ009,0)+ISNULL(XZ024,0))) S,CASE  WHEN XZ003='车间主任' THEN XZ004  END Z FROM R_PQXZ" );
            strSql.Append( " WHERE YEAR(XZ013)=@YEAR AND MONTH(XZ013)=@MONTH" );
            strSql.Append( " GROUP BY XZ003,XZ004)" );
            strSql.Append( " ,CFT AS (" );
            strSql.Append( "SELECT sum(ISNULL(XZ023,0)+ISNULL(XZ021,0)+CONVERT(DECIMAL(18,5),ISNULL(XZ005,0)/day(dateadd(d,-day(@dt),dateadd(m,1,@dt))))*(ISNULL(XZ006,0)+ISNULL(XZ007,0))-(ISNULL(XZ010,0)+ISNULL(XZ008,0)+ISNULL(XZ011,0)+ISNULL(XZ009,0)+ISNULL(XZ024,0))) S1,CASE WHEN XZ003='统计员' THEN XZ002 END Z FROM R_PQXZ" );
            strSql.Append( " WHERE YEAR(XZ013)=@YEAR AND MONTH(XZ013)=@MONTH" );
            strSql.Append( " GROUP BY XZ003,XZ002)" );
            strSql.Append( ",CGT AS(" );
            strSql.Append( "SELECT sum(ISNULL(XZ023,0)+ISNULL(XZ021,0)+CONVERT(DECIMAL(18,5),ISNULL(XZ005,0)/day(dateadd(d,-day(@dt),dateadd(m,1,@dt))))*(ISNULL(XZ006,0)+ISNULL(XZ007,0))-(ISNULL(XZ010,0)+ISNULL(XZ008,0)+ISNULL(XZ011,0)+ISNULL(XZ009,0)+ISNULL(XZ024,0))) S2,CASE WHEN XZ003 LIKE '第_组' THEN XZ002  END Z FROM R_PQXZ" );
            strSql.Append( " WHERE YEAR(XZ013)=@YEAR AND MONTH(XZ013)=@MONTH" );
            strSql.Append( " GROUP BY XZ003,XZ002)" );
            strSql.Append( ",CHT AS(" );
            strSql.Append( "SELECT sum(ISNULL(XZ023,0)+ISNULL(XZ021,0)+CONVERT(DECIMAL(18,5),ISNULL(XZ005,0)/day(dateadd(d,-day(@dt),dateadd(m,1,@dt))))*(ISNULL(XZ006,0)+ISNULL(XZ007,0))-(ISNULL(XZ010,0)+ISNULL(XZ008,0)+ISNULL(XZ011,0)+ISNULL(XZ009,0)+ISNULL(XZ024,0))) S3,CASE WHEN XZ003 LIKE '%杂工%' THEN XZ002  END Z FROM R_PQXZ" );
            strSql.Append( " WHERE YEAR(XZ013)=@YEAR AND MONTH(XZ013)=@MONTH" );
            strSql.Append( " GROUP BY XZ003,XZ002)" );
            strSql.Append( " SELECT S,S1,S2,S3,A.Z FROM (" );
            strSql.Append( " SELECT CONVERT(DECIMAL(18,0),SUM(S)) S ,Z FROM CET WHERE Z IS NOT NULL GROUP BY Z) A" );
            strSql.Append( " LEFT JOIN (" );
            strSql.Append( " SELECT CONVERT(DECIMAL(18,0),SUM(S1)) S1 ,Z FROM CFT WHERE Z IS NOT NULL GROUP BY Z) B" );
            strSql.Append( " ON A.Z=B.Z" );
            strSql.Append( " LEFT JOIN (" );
            strSql.Append( " SELECT CONVERT(DECIMAL(18,0),SUM(S2)) S2 ,Z FROM CGT WHERE Z IS NOT NULL GROUP BY Z) C" );
            strSql.Append( " ON A.Z=C.Z" );
            strSql.Append( " LEFT JOIN (" );
            strSql.Append( " SELECT CONVERT(DECIMAL(18,0),SUM(S3)) S3 ,Z FROM CHT WHERE Z IS NOT NULL GROUP BY Z) D" );
            strSql.Append( " ON A.Z=D.Z" );
            SqlParameter[] parameter = {
                new SqlParameter("@dt",SqlDbType.Date),
                new SqlParameter("@YEAR",SqlDbType.Int),
                new SqlParameter("@MONTH",SqlDbType.Int)
            };
            parameter[0].Value = dt;
            parameter[1].Value = dt.Year;
            parameter[2].Value = dt.Month;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public string UpdateOfReadRoadCost ( MulaolaoLibrary.CostIndexLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAT SET " );
            strSql.AppendFormat( "AT009='{0}'," ,_model.AT009 );
            strSql.AppendFormat( "AT010='{0}'," ,_model.AT010 );
            strSql.AppendFormat( "AT011='{0}'," ,_model.AT011 );
            strSql.AppendFormat( "AT018='{0}'" ,_model.AT018 );
            strSql.AppendFormat( " WHERE AT001='{0}' AND AT002='{1}'" ,_model.AT001 ,_model.AT002 );

            return strSql.ToString( );
        }
        public string AddOfReadRoadCost ( MulaolaoLibrary.CostIndexLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAT (" );
            strSql.Append( "AT001,AT002,AT009,AT010,AT011,AT018,AT020)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}')" ,_model.AT001 ,_model.AT002 ,_model.AT009 ,_model.AT010 ,_model.AT011 ,_model.AT018 ,_model.AT020 );

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
            strSql.Append( "SELECT * FROM R_PQAT" );
            strSql.Append( " WHERE AT001=@AT001" );
            SqlParameter[] parameter = {
                new SqlParameter("@AT001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public DataTable GetDataTable ( DateTime dtTime )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT *,0.00 AS T1 FROM R_PQAV" );
            strSql.Append( " WHERE AV001=@AV001" );
            SqlParameter[] parameter = {
                new SqlParameter("@AV001",SqlDbType.Date)
            };
            parameter[0].Value = dtTime;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public DataTable GetDataTableOne ( DateTime dtTime )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT *,0 AS T3,0 AS T4,0.000 AS T6 FROM R_PQAW" );
            strSql.Append( " WHERE AW001=@AW001" );
            SqlParameter[] parameter = {
                new SqlParameter("@AW001",SqlDbType.Date)
            };
            parameter[0].Value = dtTime;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public DataTable GetDataTableTwo ( DateTime dtTime )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT *,0 AS T7,0 AS T8,0 AS T12 FROM R_PQAX" );
            strSql.Append( " WHERE AX001=@AX001" );
            SqlParameter[] parameter = {
                new SqlParameter("@AX001",SqlDbType.Date)
            };
            parameter[0].Value = dtTime;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool AddTable ( DataTable table)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AT001,AT002,AT003,AT004,AT005,AT006,AT007,AT008,AT009,AT010,AT011,AT012,AT013,AT014,AT015,AT016,AT017,AT018,AT019,AT020 FROM R_PQAT" );
            strSql.Append( " WHERE 1=2" );

            return SqlHelper.UpdateTable( table ,strSql.ToString( ) );
        }
        public bool AddTableOne ( DataTable table )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AV001,AV002,AV003,AV004,AV005,AV006 FROM R_PQAV" );
            strSql.Append( " WHERE 1=2" );

            return SqlHelper.UpdateTable( table ,strSql.ToString( ) );
        }
        public bool AddTableTwo ( DataTable table )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AW001,AW002,AW003 FROM R_PQAW" );
            strSql.Append( " WHERE 1=2" );

            return SqlHelper.UpdateTable( table ,strSql.ToString( ) );
        }
        public bool AddTableTre ( DataTable table )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AX001,AX002,AX003,AX004,AX005,AX006,AX007,AX008,AX009,AX010,AX011,AX012,AX013,AX014,AX015,AX016,AX017,AX018,AX019,AX020 FROM R_PQAX" );
            strSql.Append( " WHERE 1=2" );

            return SqlHelper.UpdateTable( table ,strSql.ToString( ) );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable GetDataTableTwo (int dt )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT SUM(AT003) AT003,SUM(AT004) AT004,SUM(AT005) AT005,SUM(AT006) AT006,SUM(AT007) AT007,SUM(AT008) AT008,SUM(AT009) AT009,SUM(AT010) AT010,SUM(AT011) AT011,SUM(AT012) AT012,SUM(AT013) AT013,SUM(AT014) AT014,SUM(AT015) AT015,SUM(AT016) AT016,SUM(AT017) AT017,SUM(AT018) AT018,SUM(AT019) AT019,SUM(AT021) AT021,AT002 FROM R_PQAT" );
            strSql.Append( " WHERE YEAR(AT020)=@AT020" );
            strSql.Append( " GROUP BY AT002" );
            SqlParameter[] parameter = {
                new SqlParameter("@AT020",SqlDbType.Int)
            };
            parameter[0].Value = dt;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 生成年度报表
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool GetDataTableGenerate ( MulaolaoLibrary.CostIndexOneLibrary _model )
        {
            ArrayList SQLString = new ArrayList( );
            DataTable da = new DataTable( );
            da = GetDataTableOfDelivery( _model.AX001.Year );
            if ( da != null && da.Rows.Count > 0 )
            {
                _model.AV002 = string.IsNullOrEmpty( da.Rows[0]["AE"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[0]["AE"].ToString( ) );
                if ( ExistsOfDelivery( _model.AV001 ) )
                    SQLString.Add( UpdateOfDelivery( _model ) );
                else
                    SQLString.Add( AddOfDelivery( _model ) );
            }
            da = GetDataTableOfOutSource( _model.AW001.Year );
            if ( da != null && da.Rows.Count > 0 )
            {
                _model.AW002 = string.IsNullOrEmpty( da.Rows[0]["AE"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[0]["AE"].ToString( ) );
                if ( ExistsOfOutSource( _model.AW001 ) )
                    SQLString.Add( UpdateOfOutSource( _model ) );
                else
                    SQLString.Add( AddOfOutSource( _model ) );
            }
            da = GetDataTableOfSail( _model.AX001.Year );
            if ( da != null && da.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < da.Rows.Count ; i++ )
                {
                    _model.AX002 = da.Rows[i]["AE08"].ToString( );
                    if ( _model.AX002 == "" )
                        _model.AX002 = "生产部";
                    _model.AX004 = string.IsNullOrEmpty( da.Rows[i]["AE"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[i]["AE"].ToString( ) );
                    _model.AX005 = string.IsNullOrEmpty( da.Rows[i]["AE1"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[i]["AE1"].ToString( ) );
                    _model.AX006 = string.IsNullOrEmpty( da.Rows[i]["AE2"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[i]["AE2"].ToString( ) );
                    _model.AX007 = string.IsNullOrEmpty( da.Rows[i]["AE3"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[i]["AE3"].ToString( ) );
                    _model.AX008 = string.IsNullOrEmpty( da.Rows[i]["AE5"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[i]["AE5"].ToString( ) );
                    _model.AX009 = string.IsNullOrEmpty( da.Rows[i]["AE4"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[i]["AE4"].ToString( ) );
                    if ( ExistsOfSail( _model.AX001 ,_model.AX002 ) )
                        SQLString.Add( UpdateOfSail( _model ) );
                    else
                        SQLString.Add( AddOfSail( _model ) );
                }
            }

            if ( SqlHelper.ExecuteSqlTran( SQLString ) )
            {
                SQLString = new ArrayList( );
                da = GetDataTableOfPaid( _model.AX001.Year );
                if ( da != null && da.Rows.Count > 0 )
                {
                    for ( int i = 0 ; i < da.Rows.Count ; i++ )
                    {
                        _model.AX002 = da.Rows[i]["AM008"].ToString( );
                        _model.AX012 = string.IsNullOrEmpty( da.Rows[i]["U"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[i]["U"].ToString( ) );
                        if ( ExistsOfSail( _model.AX001 ,_model.AX002 ) )
                            SQLString.Add( UpdateOfPaid( _model ) );
                        else
                            SQLString.Add( AddOfPaid( _model ) );
                    }
                }
            }

            if ( SqlHelper.ExecuteSqlTran( SQLString ) )
            {
                SQLString = new ArrayList( );
                da = GetDataTableOfWages( _model.AX001.Year );
                if ( da != null && da.Rows.Count > 0 )
                {
                    for ( int i = 0 ; i < da.Rows.Count ; i++ )
                    {
                        _model.AX002 = da.Rows[i]["XZ004"].ToString( );
                        _model.AX019 = string.IsNullOrEmpty( da.Rows[i]["XZ"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[i]["XZ"].ToString( ) );
                        if ( ExistsOfSail( _model.AX001 ,_model.AX002 ) )
                            SQLString.Add( UpdateOfWages( _model ) );
                        else
                            SQLString.Add( AddOfWages( _model ) );
                    }
                }
            }

            UpdateOf( SQLString );
           
            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        public void UpdateOf ( ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAX SET " );
            strSql.Append( "AX004=0" );
            strSql.AppendFormat( " WHERE AX004 IS NULL" );
            SQLString.Add( strSql.ToString( ) );
            StringBuilder strSq = new StringBuilder( );
            strSq.Append( "UPDATE R_PQAX SET " );
            strSq.Append( "AX005=0" );
            strSq.AppendFormat( " WHERE AX005 IS NULL" );
            SQLString.Add( strSq.ToString( ) );
            StringBuilder strS = new StringBuilder( );
            strS.Append( "UPDATE R_PQAX SET " );
            strS.Append( "AX006=0" );
            strS.AppendFormat( " WHERE AX006 IS NULL" );
            SQLString.Add( strS.ToString( ) );
            StringBuilder str = new StringBuilder( );
            str.Append( "UPDATE R_PQAX SET " );
            str.Append( "AX007=0" );
            str.AppendFormat( " WHERE AX007 IS NULL" );
            SQLString.Add( str.ToString( ) );
            StringBuilder st = new StringBuilder( );
            st.Append( "UPDATE R_PQAX SET " );
            st.Append( "AX008=0" );
            st.AppendFormat( " WHERE AX008 IS NULL" );
            SQLString.Add( st.ToString( ) );
            StringBuilder s = new StringBuilder( );
            s.Append( "UPDATE R_PQAX SET " );
            s.Append( "AX009=0" );
            s.AppendFormat( " WHERE AX009 IS NULL" );
            SQLString.Add( s.ToString( ) );
            StringBuilder sbx = new StringBuilder( );
            sbx.Append( "UPDATE R_PQAX SET " );
            sbx.Append( "AX011=0" );
            sbx.AppendFormat( " WHERE AX011 IS NULL" );
            SQLString.Add( sbx.ToString( ) );
            StringBuilder sb = new StringBuilder( );
            sb.Append( "UPDATE R_PQAX SET " );
            sb.Append( "AX012=0" );
            sb.AppendFormat( " WHERE AX012 IS NULL" );
            SQLString.Add( sb.ToString( ) );
            StringBuilder sbs = new StringBuilder( );
            sbs.Append( "UPDATE R_PQAX SET " );
            sbs.Append( "AX019=0" );
            sbs.AppendFormat( " WHERE AX019 IS NULL" );
            SQLString.Add( sbs.ToString( ) );
        }

        /// <summary>
        /// 获取全年销售额
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfDelivery (int year )
        {
            //按发货日期算
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT CONVERT(DECIMAL(18,0),SUM(CASE WHEN AE12=0 THEN AE10*AE11*AE37 ELSE AE12*AE37 END)) AE FROM R_PQAE" );
            strSql.AppendFormat( " WHERE YEAR(AE21)={0}" ,year );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public bool ExistsOfDelivery ( DateTime dtTime)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQAV" );
            strSql.Append( " WHERE AV001=@AV001" );
            SqlParameter[] parameter = {
                new SqlParameter("@AV001",SqlDbType.Date)
            };
            parameter[0].Value = dtTime;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }
        public string AddOfDelivery ( MulaolaoLibrary.CostIndexOneLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAV (" );
            strSql.Append( "AV001,AV002)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( " '{0}','{1}')" ,_model.AV001 ,_model.AV002 );

            return strSql.ToString( );
        }
        public string UpdateOfDelivery ( MulaolaoLibrary.CostIndexOneLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAV SET " );
            strSql.AppendFormat( "AV002='{0}'" ,_model.AV002 );
            strSql.AppendFormat( " WHERE AV001='{0}'" ,_model.AV001 );

            return strSql.ToString( );
        }

        /// <summary>
        /// 获取全年的委外销售额
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfOutSource ( int year )
        {
            //按发货日期算
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT CONVERT(DECIMAL(18,0),SUM(CASE WHEN AE12=0 THEN AE10*AE11*AE37 ELSE AE12*AE37 END)) AE FROM R_PQAE" );
            strSql.AppendFormat( " WHERE YEAR(AE21)={0}" ,year );
            strSql.Append( "  AND AE08='委外'" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public bool ExistsOfOutSource ( DateTime dtTime )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQAW" );
            strSql.Append( " WHERE AW001=@AW001" );
            SqlParameter[] parameter = {
                new SqlParameter("@AW001",SqlDbType.Date)
            };
            parameter[0].Value = dtTime;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }
        public string AddOfOutSource ( MulaolaoLibrary.CostIndexOneLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAW (" );
            strSql.Append( "AW001,AW002)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}')" ,_model.AW001 ,_model.AW002 );

            return strSql.ToString( );
        }
        public string UpdateOfOutSource ( MulaolaoLibrary.CostIndexOneLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAW SET " );
            strSql.AppendFormat( "AW002='{0}'" ,_model.AW002 );
            strSql.AppendFormat( " WHERE AW001='{0}'" ,_model.AW001 );

            return strSql.ToString( );
        }

        /// <summary>
        /// 获取各车间主任的销售额
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfSail ( int year )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "WITH CET AS(" );
            strSql.Append( "SELECT CONVERT(DECIMAL(18,0),SUM(ISNULL(AE37,0)*ISNULL(AE12,0))) AE,CONVERT(DECIMAL(18,0),SUM(CASE WHEN AE10=0 THEN AE12*AE37 ELSE 0 END)) AE4,CONVERT(DECIMAL(18,0),SUM(CASE WHEN AE10!=0 THEN AE10*AE11*AE37 ELSE 0 END)) AE5,AE08,AE02 FROM R_PQAE" );
            strSql.Append( " WHERE YEAR(AE21)=@YEAR" );
            strSql.Append( " GROUP BY AE08,AE02)" );
            strSql.Append( ",CFT AS(" );
            strSql.Append( "SELECT AE08,SUM(AE) AE,SUM(AE4) AE4,SUM(AE5) AE5,CASE WHEN AE>500000 THEN SUM(AE) ELSE 0 END AE1,CASE WHEN 150000<=AE AND AE<=500000 THEN SUM(AE) ELSE 0 END AE2,CASE WHEN AE<150000 THEN SUM(AE) ELSE 0 END AE3 FROM CET GROUP BY AE08,AE)" );
            strSql.Append( " SELECT AE08,SUM(AE) AE,SUM(AE1) AE1,SUM(AE2) AE2,SUM(AE3) AE3,SUM(AE4) AE4,SUM(AE5) AE5 FROM CFT GROUP BY AE08" );
            SqlParameter[] parameter = {
                new SqlParameter("@YEAR",SqlDbType.Int)
            };
            parameter[0].Value = year;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public bool ExistsOfSail ( DateTime dtTime ,string director )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQAX" );
            strSql.Append( " WHERE AX001=@AX001 AND AX002=@AX002" );
            SqlParameter[] parameter = {
                new SqlParameter("@AX001",SqlDbType.Date),
                new SqlParameter("@AX002",SqlDbType.NVarChar)
            };
            parameter[0].Value = dtTime;
            parameter[1].Value = director;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }
        public string AddOfSail ( MulaolaoLibrary.CostIndexOneLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAX (" );
            strSql.Append( "AX001,AX002,AX004,AX005,AX006,AX007,AX008,AX009)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')" ,_model.AX001 ,_model.AX002 ,_model.AX004 ,_model.AX005 ,_model.AX006 ,_model.AX007 ,_model.AX008 ,_model.AX009 );

            return strSql.ToString( );
        }
        public string UpdateOfSail ( MulaolaoLibrary.CostIndexOneLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAX SET " );
            strSql.AppendFormat( "AX004='{0}'," ,_model.AX004 );
            strSql.AppendFormat( "AX005='{0}'," ,_model.AX005 );
            strSql.AppendFormat( "AX006='{0}'," ,_model.AX006 );
            strSql.AppendFormat( "AX007='{0}'," ,_model.AX007 );
            strSql.AppendFormat( "AX008='{0}'," ,_model.AX008 );
            strSql.AppendFormat( "AX009='{0}'" ,_model.AX009 );
            strSql.AppendFormat( " WHERE AX001='{0}' AND AX002='{1}'" ,_model.AX001 ,_model.AX002 );

            return strSql.ToString( );
        }

        /// <summary>
        /// 获取241应付款金额
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfPaid ( int year )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql . Append ( "WITH CET AS (" );
            strSql . AppendFormat ( "SELECT A.idx,AM336+AM343+AM361+AM346+AM349+AM367+AM352+AM370+AM355+AM153+AM339+AM364+AM157+AM330+AM333+AM358+AM373+AM376+AM379+AM385+AM388+AM391+AM298+AM301+AM307+AM311+AM304+AM318+AM315+AM321+AM270+AM273+AM277+AM280+AM249+AM242+AM245+AM239+AM209+AM212+AM215+AM225+AM229+AM233+AM175+AM178+AM182+AM185+AM188+AM191+AM194+AM197+AM136+AM139+AM142+AM145+AM148+AM237+AM108+AM111+AM084 U104,AM070+AM072+AM074+AM076+AM078+AM080+AM082+AM086+AM088+AM090+AM092+AM044+AM046+AM048+AM050+AM052+AM054+AM056+AM058+AM060+AM062 U105,AM020+AM022+AM024+AM026+AM028 U106,AM338+AM351+AM381+AM357+AM363+AM294+AM369+AM292+AM332+AM155+AM345+AM390+AM300+AM306+AM320+AM324+AM272+AM279+AM211+AM217+AM221+AM255+AM241+AM247+AM252+AM177+AM184+AM190+AM196 U107,AM158+AM261+AM263+AM265+AM267+AM287+AM288+AM290+AM375+AM382+AM313+AM328+AM326+AM296+AM283+AM285+AM227+AM231+AM235+AM255+AM241+AM200+AM203+AM205+AM207 U108,AM008 FROM R_PQAM A LEFT JOIN R_PQF B ON A.AM002=B.PQF01 WHERE YEAR(B.PQF31)={0})  " ,year  );
            strSql . AppendFormat ( "SELECT AM008,CONVERT(DECIMAL(18,0),SUM(U104+U105+U106+U107+U108)) U FROM CET GROUP BY AM008" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( )  );
        }
        public string AddOfPaid ( MulaolaoLibrary.CostIndexOneLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAX (" );
            strSql.Append( "AX001,AX002,AX012)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}')" ,_model.AX001 ,_model.AX002 ,_model.AX012 );

            return strSql.ToString( );
        }
        public string UpdateOfPaid ( MulaolaoLibrary.CostIndexOneLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAX SET " );
            strSql.AppendFormat( "AX012='{0}'" ,_model.AX012 );
            strSql.AppendFormat( " WHERE AX001='{0}' AND AX002='{1}'" ,_model.AX001 ,_model.AX002 );

            return strSql.ToString( );
        }

        /// <summary>
        /// 获取526车间主任工资
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfWages ( int year )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "WITH CET AS(" );
            strSql.Append( "SELECT CASE WHEN XZ003='车间主任' THEN XZ004 ELSE '' END XZ004,CONVERT(DECIMAL(18,0),SUM(XZ023+XZ021+XZ005/day(dateadd(d,-day(XZ013),dateadd(m,1,XZ013)))*(XZ006+XZ007)-(XZ010+XZ008+XZ011+XZ009+XZ024))) XZ FROM R_PQXZ" );
            strSql.Append( " WHERE YEAR(XZ013)=@YEAR" );
            strSql.Append( " GROUP BY XZ003,XZ004)" );
            strSql.Append( " SELECT * FROM CET WHERE XZ004!=''" );
            SqlParameter[] parameter = {
                new SqlParameter("@YEAR",SqlDbType.Int)
            };
            parameter[0].Value = year;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public string AddOfWages ( MulaolaoLibrary.CostIndexOneLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAX (" );
            strSql.Append( "AX001,AX002,AX019)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}')" ,_model.AX001 ,_model.AX002 ,_model.AX019 );

            return strSql.ToString( );
        }
        public string UpdateOfWages ( MulaolaoLibrary.CostIndexOneLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAX SET " );
            strSql.AppendFormat( "AX019='{0}'" ,_model.AX019 );
            strSql.AppendFormat( " WHERE AX001='{0}' AND AX002='{1}'" ,_model.AX001 ,_model.AX002 );

            return strSql.ToString( );
        }
    }
}

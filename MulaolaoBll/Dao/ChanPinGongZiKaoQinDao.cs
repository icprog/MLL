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
    public class ChanPinGongZiKaoQinDao
    {
        
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists ( MulaolaoLibrary.ChanPinGongZiKaoQinLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQW" );
            strSql.Append( " WHERE GZ29=@GZ29 AND GZ03=@GZ03 AND GZ04=@GZ04 AND GZ24=@GZ24 AND GZ17=@GZ17 AND GZ01=@GZ01" );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ29",SqlDbType.NVarChar),
                new SqlParameter("@GZ03",SqlDbType.NVarChar),
                new SqlParameter("@GZ04",SqlDbType.NVarChar),
                new SqlParameter("@GZ24",SqlDbType.Int),
                new SqlParameter("@GZ17",SqlDbType.Int),
                new SqlParameter("@GZ01",SqlDbType.NVarChar)
            };

            parameter[0].Value = model.GZ29;
            parameter[1].Value = model.GZ03;
            parameter[2].Value = model.GZ04;
            parameter[3].Value = model.GZ24;
            parameter[4].Value = model.GZ17;
            parameter[5].Value = model.GZ01;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsIdx ( MulaolaoLibrary.ChanPinGongZiKaoQinLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQW" );
            strSql.Append( " WHERE GZ29=@GZ29 AND GZ03=@GZ03 AND GZ04=@GZ04 AND GZ24=@GZ24 AND GZ17=@GZ17 AND GZ01=@GZ01 AND idx!=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ29",SqlDbType.NVarChar),
                new SqlParameter("@GZ03",SqlDbType.NVarChar),
                new SqlParameter("@GZ04",SqlDbType.NVarChar),
                new SqlParameter("@GZ24",SqlDbType.Int),
                new SqlParameter("@GZ17",SqlDbType.Int),
                new SqlParameter("@GZ01",SqlDbType.NVarChar),
                new SqlParameter("@idx",SqlDbType.Int)
            };

            parameter[0].Value = model.GZ29;
            parameter[1].Value = model.GZ03;
            parameter[2].Value = model.GZ04;
            parameter[3].Value = model.GZ24;
            parameter[4].Value = model.GZ17;
            parameter[5].Value = model.GZ01;
            parameter[6].Value = model.Idx;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 是否存在总毛量为0
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable  ExistsIsZero ( MulaolaoLibrary.ChanPinGongZiKaoQinLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT a.GZ23,a.GZ03,a.GZ04,a.idx" );
            strSql.Append( " FROM R_PQW a WHERE not exists(SELECT 1 FROM R_PQW WHERE GZ23 = a.GZ23 AND GZ03=a.GZ03 and GZ04=a.GZ04  and idx < a.idx)  and  (GZ41 IS NULL OR GZ41=0) AND GZ25+GZ26=0 " );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable ExistsOddNum ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT GZ21 FROM R_PQW" );
            strSql.Append( " WHERE GZ29=@GZ29" );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ29",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add ( MulaolaoLibrary.ChanPinGongZiKaoQinLibrary model ,string tableNum,string tableName,string logins,DateTime dtOne,string stateOf,string stateOfState )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQW (" );
            strSql.Append( "GZ01,GZ02,GZ03,GZ04,GZ05,GZ06,GZ07,GZ08,GZ09,GZ10,GZ11,GZ12,GZ13,GZ14,GZ16,GZ17,GZ18,GZ22,GZ23,GZ24,GZ25,GZ26,GZ27,GZ29,GZ30,GZ31,GZ32,GZ33,GZ34,GZ35,GZ36,GZ37,GZ38,GZ40,GZ42,GZ43)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "@GZ01,@GZ02,@GZ03,@GZ04,@GZ05,@GZ06,@GZ07,@GZ08,@GZ09,@GZ10,@GZ11,@GZ12,@GZ13,@GZ14,@GZ16,@GZ17,@GZ18,@GZ22,@GZ23,@GZ24,@GZ25,@GZ26,@GZ27,@GZ29,@GZ30,@GZ31,@GZ32,@GZ33,@GZ34,@GZ35,@GZ36,@GZ37,@GZ38,@GZ40,@GZ42,@GZ43)" );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ01",SqlDbType.NVarChar,20),
                new SqlParameter("@GZ02",SqlDbType.NVarChar,20),
                new SqlParameter("@GZ03",SqlDbType.NVarChar,20),
                new SqlParameter("@GZ04",SqlDbType.NVarChar,20),
                new SqlParameter("@GZ05",SqlDbType.Int),
                new SqlParameter("@GZ06",SqlDbType.Decimal,7),
                new SqlParameter("@GZ07",SqlDbType.NVarChar,50),
                new SqlParameter("@GZ08",SqlDbType.Decimal,4),
                new SqlParameter("@GZ09",SqlDbType.Decimal,4),
                new SqlParameter("@GZ10",SqlDbType.Decimal,4),
                new SqlParameter("@GZ11",SqlDbType.Decimal,4),
                new SqlParameter("@GZ12",SqlDbType.Decimal,4),
                new SqlParameter("@GZ13",SqlDbType.Decimal,4),
                new SqlParameter("@GZ14",SqlDbType.Decimal,4),
                new SqlParameter("@GZ16",SqlDbType.NVarChar,20),
                new SqlParameter("@GZ17",SqlDbType.Int),
                new SqlParameter("@GZ18",SqlDbType.NVarChar,255),
                new SqlParameter("@GZ22",SqlDbType.NVarChar,100),
                new SqlParameter("@GZ23",SqlDbType.NVarChar,100),
                new SqlParameter("@GZ24",SqlDbType.Int),
                new SqlParameter("@GZ25",SqlDbType.BigInt),
                new SqlParameter("@GZ26",SqlDbType.BigInt),
                new SqlParameter("@GZ27",SqlDbType.Decimal,7),
                new SqlParameter("@GZ29",SqlDbType.NVarChar,20),
                new SqlParameter("@GZ30",SqlDbType.NVarChar,20),
                new SqlParameter("@GZ31",SqlDbType.NVarChar,20),
                new SqlParameter("@GZ32",SqlDbType.NVarChar,20),
                new SqlParameter("@GZ33",SqlDbType.NVarChar,20),
                new SqlParameter("@GZ34",SqlDbType.BigInt),
                new SqlParameter("@GZ35",SqlDbType.NVarChar,20),
                new SqlParameter("@GZ36",SqlDbType.Decimal,5),
                new SqlParameter("@GZ37",SqlDbType.NVarChar,20),
                new SqlParameter("@GZ38",SqlDbType.NVarChar,20),
                new SqlParameter("@GZ40",SqlDbType.Int),
                new SqlParameter("@GZ42",SqlDbType.NVarChar,20),
                new SqlParameter("@GZ43",SqlDbType.Date)
            };
            //SQLString.Add( strSql.ToString( ) );
            

            //return SqlHelper.ExecuteSqlTran( SQLString );
            parameter[0].Value = model.GZ01;
            parameter[1].Value = model.GZ02;
            parameter[2].Value = model.GZ03;
            parameter[3].Value = model.GZ04;
            parameter[4].Value = model.GZ05;
            parameter[5].Value = model.GZ06;
            parameter[6].Value = model.GZ07;
            parameter[7].Value = model.GZ08;
            parameter[8].Value = model.GZ09;
            parameter[9].Value = model.GZ10;
            parameter[10].Value = model.GZ11;
            parameter[11].Value = model.GZ12;
            parameter[12].Value = model.GZ13;
            parameter[13].Value = model.GZ14;
            parameter[14].Value = model.GZ16;
            parameter[15].Value = model.GZ17;
            parameter[16].Value = model.GZ18;
            parameter[17].Value = model.GZ22;
            parameter[18].Value = model.GZ23;
            parameter[19].Value = model.GZ24;
            parameter[20].Value = model.GZ25;
            parameter[21].Value = model.GZ26;
            parameter[22].Value = model.GZ27;
            parameter[23].Value = model.GZ29;
            parameter[24].Value = model.GZ30;
            parameter[25].Value = model.GZ31;
            parameter[26].Value = model.GZ32;
            parameter[27].Value = model.GZ33;
            parameter[28].Value = model.GZ34;
            parameter[29].Value = model.GZ35;
            parameter[30].Value = model.GZ36;
            parameter[31].Value = model.GZ37;
            parameter[32].Value = model.GZ38;
            parameter[33].Value = model.GZ40;
            parameter[34].Value = model.GZ42;
            parameter[35].Value = model.GZ43;
            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
            {
                strSql = new StringBuilder( );
                strSql.Append( "GZ01,GZ02,GZ03,GZ04,GZ05,GZ06,GZ07,GZ08,GZ09,GZ10,GZ11,GZ12,GZ13,GZ14,GZ16,GZ17,GZ18,GZ22,GZ23,GZ24,GZ25,GZ26,GZ27,GZ29,GZ30,GZ31,GZ32,GZ33,GZ34,GZ35,GZ36,GZ37,GZ38,GZ40,GZ42,GZ43)" );
                strSql.Append( " VALUES (" );
                strSql.AppendFormat( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}')" ,model.GZ01 ,model.GZ02 ,model.GZ03 ,model.GZ04 ,model.GZ05 ,model.GZ06 ,model.GZ07 ,model.GZ08 ,model.GZ09 ,model.GZ10 ,model.GZ11 ,model.GZ12 ,model.GZ13 ,model.GZ14 ,model.GZ16 ,model.GZ17 ,model.GZ18 ,model.GZ22 ,model.GZ23 ,model.GZ24 ,model.GZ25 ,model.GZ26 ,model.GZ27 ,model.GZ29 ,model.GZ30 ,model.GZ31 ,model.GZ32 ,model.GZ33 ,model.GZ34 ,model.GZ35 ,model.GZ36 ,model.GZ37 ,model.GZ38 ,model.GZ40 ,model.GZ42 ,model.GZ43 );
                try
                {
                    SqlHelper.ExecuteNonQuery( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.GZ29 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfState ) );
                }
                catch { }
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 更新计件率
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool calCu ( MulaolaoLibrary.ChanPinGongZiKaoQinLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQW SET GZ41=0 WHERE GZ01=@GZ01 AND GZ03=@GZ03 AND GZ04=@GZ04;" );
            strSql.Append( "WITH CET AS( " );
            strSql.Append( "SELECT SU,GZ01,GZ03,GZ04 FROM (SELECT CONVERT(DECIMAL(14,6),CASE WHEN SUM(ISNULL(GZ25,0))=0 THEN 0 ELSE (ISNULL(GZ34*GZ40*1.0,0)-SUM(ISNULL(GZ26,0)))/SUM(ISNULL(GZ25,0)) END) SU,GZ01,GZ03,GZ04 FROM R_PQW GROUP BY GZ34,GZ40,GZ01,GZ03,GZ04) A)" );
            strSql.Append( " UPDATE R_PQW SET GZ41=A.SU FROM CET A,R_PQW B WHERE A.GZ01=B.GZ01 AND A.GZ03=B.GZ03 AND A.GZ04=B.GZ04" );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ01",SqlDbType.NVarChar,20),
                new SqlParameter("@GZ03",SqlDbType.NVarChar,20),
                new SqlParameter("@GZ04",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = model.GZ01;
            parameter[1].Value = model.GZ03;
            parameter[2].Value = model.GZ04;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.ChanPinGongZiKaoQinLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfState )
        {
            ArrayList SQLString = new ArrayList( );

            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQW SET" );
            strSql.Append( " GZ01=@GZ01," );
            strSql.Append( "GZ02=@GZ02," );
            strSql.Append( "GZ03=@GZ03," );
            strSql.Append( "GZ04=@GZ04," );
            strSql.Append( "GZ05=@GZ05," );
            strSql.Append( "GZ06=@GZ06," );
            strSql.Append( "GZ07=@GZ07," );
            strSql.Append( "GZ08=@GZ08," );
            strSql.Append( "GZ09=@GZ09," );
            strSql.Append( "GZ10=@GZ10," );
            strSql.Append( "GZ11=@GZ11," );
            strSql.Append( "GZ12=@GZ12," );
            strSql.Append( "GZ13=@GZ13," );
            strSql.Append( "GZ14=@GZ14," );
            strSql.Append( "GZ16=@GZ16," );
            strSql.Append( "GZ17=@GZ17," );
            strSql.Append( "GZ18=@GZ18," );
            strSql.Append( "GZ22=@GZ22," );
            strSql.Append( "GZ23=@GZ23," );
            strSql.Append( "GZ24=@GZ24," );
            strSql.Append( "GZ25=@GZ25," );
            strSql.Append( "GZ26=@GZ26," );
            strSql.Append( "GZ27=@GZ27," );
            strSql.Append( "GZ29=@GZ29," );
            strSql.Append( "GZ30=@GZ30," );
            strSql.Append( "GZ31=@GZ31," );
            strSql.Append( "GZ32=@GZ32," );
            strSql.Append( "GZ33=@GZ33," );
            strSql.Append( "GZ34=@GZ34," );
            strSql.Append( "GZ35=@GZ35," );
            strSql.Append( "GZ36=@GZ36," );
            strSql.Append( "GZ37=@GZ37," );
            strSql.Append( "GZ38=@GZ38," );
            strSql.Append( "GZ40=@GZ40," );
            strSql.Append( "GZ42=@GZ42," );
            strSql.Append( "GZ43=@GZ43" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ01",SqlDbType.NVarChar,20),
                new SqlParameter("@GZ02",SqlDbType.NVarChar,20),
                new SqlParameter("@GZ03",SqlDbType.NVarChar,20),
                new SqlParameter("@GZ04",SqlDbType.NVarChar,20),
                new SqlParameter("@GZ05",SqlDbType.Int),
                new SqlParameter("@GZ06",SqlDbType.Decimal,7),
                new SqlParameter("@GZ07",SqlDbType.NVarChar,50),
                new SqlParameter("@GZ08",SqlDbType.Decimal,4),
                new SqlParameter("@GZ09",SqlDbType.Decimal,4),
                new SqlParameter("@GZ10",SqlDbType.Decimal,4),
                new SqlParameter("@GZ11",SqlDbType.Decimal,4),
                new SqlParameter("@GZ12",SqlDbType.Decimal,4),
                new SqlParameter("@GZ13",SqlDbType.Decimal,4),
                new SqlParameter("@GZ14",SqlDbType.Decimal,4),
                new SqlParameter("@GZ16",SqlDbType.NVarChar,20),
                new SqlParameter("@GZ17",SqlDbType.Int),
                new SqlParameter("@GZ18",SqlDbType.NVarChar,255),
                new SqlParameter("@GZ22",SqlDbType.NVarChar,100),
                new SqlParameter("@GZ23",SqlDbType.NVarChar,100),
                new SqlParameter("@GZ24",SqlDbType.Int),
                new SqlParameter("@GZ25",SqlDbType.BigInt),
                new SqlParameter("@GZ26",SqlDbType.BigInt),
                new SqlParameter("@GZ27",SqlDbType.Decimal,7),
                new SqlParameter("@GZ29",SqlDbType.NVarChar,20),
                new SqlParameter("@GZ30",SqlDbType.NVarChar,20),
                new SqlParameter("@GZ31",SqlDbType.NVarChar,20),
                new SqlParameter("@GZ32",SqlDbType.NVarChar,20),
                new SqlParameter("@GZ33",SqlDbType.NVarChar,20),
                new SqlParameter("@GZ34",SqlDbType.BigInt),
                new SqlParameter("@GZ35",SqlDbType.NVarChar,20),
                new SqlParameter("@GZ36",SqlDbType.Decimal,5),
                new SqlParameter("@GZ37",SqlDbType.NVarChar,20),
                new SqlParameter("@GZ38",SqlDbType.NVarChar,20),
                new SqlParameter("@GZ40",SqlDbType.Int),
                new SqlParameter("@GZ42",SqlDbType.NVarChar,20),
                new SqlParameter("@GZ43",SqlDbType.Date),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = model.GZ01;
            parameter[1].Value = model.GZ02;
            parameter[2].Value = model.GZ03;
            parameter[3].Value = model.GZ04;
            parameter[4].Value = model.GZ05;
            parameter[5].Value = model.GZ06;
            parameter[6].Value = model.GZ07;
            parameter[7].Value = model.GZ08;
            parameter[8].Value = model.GZ09;
            parameter[9].Value = model.GZ10;
            parameter[10].Value = model.GZ11;
            parameter[11].Value = model.GZ12;
            parameter[12].Value = model.GZ13;
            parameter[13].Value = model.GZ14;
            parameter[14].Value = model.GZ16;
            parameter[15].Value = model.GZ17;
            parameter[16].Value = model.GZ18;
            parameter[17].Value = model.GZ22;
            parameter[18].Value = model.GZ23;
            parameter[19].Value = model.GZ24;
            parameter[20].Value = model.GZ25;
            parameter[21].Value = model.GZ26;
            parameter[22].Value = model.GZ27;
            parameter[23].Value = model.GZ29;
            parameter[24].Value = model.GZ30;
            parameter[25].Value = model.GZ31;
            parameter[26].Value = model.GZ32;
            parameter[27].Value = model.GZ33;
            parameter[28].Value = model.GZ34;
            parameter[29].Value = model.GZ35;
            parameter[30].Value = model.GZ36;
            parameter[31].Value = model.GZ37;
            parameter[32].Value = model.GZ38;
            parameter[33].Value = model.GZ40;
            parameter[34].Value = model.GZ42;
            parameter[35].Value = model.GZ43;
            parameter[36].Value = model.Idx;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
            {
                strSql = new StringBuilder( );
                strSql.Append( "UPDATE R_PQW SET" );
                strSql.AppendFormat( " GZ01='{0}'," ,model.GZ01 );
                strSql.AppendFormat( "GZ02='{0}'," ,model.GZ02 );
                strSql.AppendFormat( "GZ03='{0}'," ,model.GZ03 );
                strSql.AppendFormat( "GZ04='{0}'," ,model.GZ04 );
                strSql.AppendFormat( "GZ05='{0}'," ,model.GZ05 );
                strSql.AppendFormat( "GZ06='{0}'," ,model.GZ06 );
                strSql.AppendFormat( "GZ07='{0}'," ,model.GZ07 );
                strSql.AppendFormat( "GZ08='{0}'," ,model.GZ08 );
                strSql.AppendFormat( "GZ09='{0}'," ,model.GZ09 );
                strSql.AppendFormat( "GZ10='{0}'," ,model.GZ10 );
                strSql.AppendFormat( "GZ11='{0}'," ,model.GZ11 );
                strSql.AppendFormat( "GZ12='{0}'," ,model.GZ12 );
                strSql.AppendFormat( "GZ13='{0}'," ,model.GZ13 );
                strSql.AppendFormat( "GZ14='{0}'," ,model.GZ14 );
                strSql.AppendFormat( "GZ16='{0}'," ,model.GZ16 );
                strSql.AppendFormat( "GZ17='{0}'," ,model.GZ17 );
                strSql.AppendFormat( "GZ18='{0}'," ,model.GZ18 );
                strSql.AppendFormat( "GZ22='{0}'," ,model.GZ22 );
                strSql.AppendFormat( "GZ23='{0}'," ,model.GZ23 );
                strSql.AppendFormat( "GZ24='{0}'," ,model.GZ24 );
                strSql.AppendFormat( "GZ25='{0}'," ,model.GZ25 );
                strSql.AppendFormat( "GZ26='{0}'," ,model.GZ26 );
                strSql.AppendFormat( "GZ27='{0}'," ,model.GZ27 );
                strSql.AppendFormat( "GZ29='{0}'," ,model.GZ29 );
                strSql.AppendFormat( "GZ30='{0}'," ,model.GZ30 );
                strSql.AppendFormat( "GZ31='{0}'," ,model.GZ31 );
                strSql.AppendFormat( "GZ32='{0}'," ,model.GZ32 );
                strSql.AppendFormat( "GZ33='{0}'," ,model.GZ33 );
                strSql.AppendFormat( "GZ34='{0}'," ,model.GZ34 );
                strSql.AppendFormat( "GZ35='{0}'," ,model.GZ35 );
                strSql.AppendFormat( "GZ36='{0}'," ,model.GZ36 );
                strSql.AppendFormat( "GZ37='{0}'," ,model.GZ37 );
                strSql.AppendFormat( "GZ38='{0}'," ,model.GZ38 );
                strSql.AppendFormat( "GZ40='{0}'," ,model.GZ40 );
                strSql.AppendFormat( "GZ42='{0}'," ,model.GZ42 );
                strSql.AppendFormat( "GZ43='{0}'" ,model.GZ43 );
                strSql.AppendFormat( " WHERE idx='{0}'" ,model.Idx );
                try
                {
                    SqlHelper.ExecuteNonQuery( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.GZ29 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfState ) );
                }
                catch { }

                return true;
            }
            else
                return false;
           
        }


        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateWei ( MulaolaoLibrary.ChanPinGongZiKaoQinLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQW SET" );
            strSql.Append( " GZ20=@GZ20," );
            strSql.Append( " GZ21=@GZ21" );
            strSql.Append( " WHERE GZ29=@GZ29" );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ20",SqlDbType.NVarChar),
                new SqlParameter("@GZ21",SqlDbType.NVarChar),
                new SqlParameter("@GZ29",SqlDbType.NVarChar)
            };

            parameter[0].Value = model.GZ20;
            parameter[1].Value = model.GZ21;
            parameter[2].Value = model.GZ29;

            int rows = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( rows > 0 )
                return true;
            else
                return false;
        }


        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateAll ( MulaolaoLibrary.ChanPinGongZiKaoQinLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQW SET" );
            strSql.Append( " GZ02=@GZ02" );
            strSql.Append( " WHERE GZ29=@GZ29" );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ02",SqlDbType.NVarChar),
                new SqlParameter("@GZ29",SqlDbType.NVarChar)
            };

            parameter[0].Value = model.GZ02;
            parameter[1].Value = model.GZ29;

            int rows = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 批量编辑月份数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool UpdateBatch ( int mouth)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQW SET" );
            strSql.Append( " GZ28=@GZ28" );
            strSql.Append( " WHERE ( GZ39!='执行' OR GZ39 IS NULL OR GZ39='') AND GZ01 IN (SELECT DISTINCT AE02 FROM R_PQAE WHERE AE37>0  AND MONTH(AE21)=@GZ28)" );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ28",SqlDbType.Int)
            };

            parameter[0].Value = mouth;

            int rows = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( rows > 0 )
                return true;
            else
                return false;
        }
        public bool UpdateBatch ( int startMonth ,string oddNum ,int mouth )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQW SET" );
            strSql.Append( " GZ28=@GZ28" );
            strSql.Append( " WHERE GZ24=@GZ24 AND GZ29=@GZ29 AND ( GZ39!='执行' OR GZ39 IS NULL OR GZ39='')" );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ28",SqlDbType.Int),
                new SqlParameter("@GZ24",SqlDbType.Int),
                new SqlParameter("@GZ29",SqlDbType.NVarChar)
            };

            parameter[0].Value = mouth;
            parameter[1].Value = startMonth;
            parameter[2].Value = oddNum;

            int rows = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( rows > 0 )
                return true;
            else
                return false;
        }
        public bool ExistsNum ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQAE" );
            strSql.Append( " WHERE AE37>0 AND AE02=@AE02" );
            SqlParameter[] parameter = {
                new SqlParameter("@AE02",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = num;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 批量编辑部件名称
        /// </summary>
        /// <param name="num"></param>
        /// <param name="pro"></param>
        /// <returns></returns>
        public bool UpdateBatchPro ( string num ,string oddNum ,string pro ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfState ,string buJ ,string gX,string dhCheck ,string gxCheck )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQW SET " );
            strSql . Append ( "GZ03=@GZ03" );
            strSql . Append ( " WHERE GZ01=@GZ01 AND GZ03=@GZ3 AND idx NOT IN (SELECT FZ002 FROM R_PQFZ WHERE FZ001 IN (SELECT R_PQEZ.idx FROM R_PQEZ,R_REVIEWS WHERE EZ001=RES06 AND RES05='执行')) AND GZ39 IS NULL" );//AND GZ29=@GZ29 AND GZ04=@GZ04
            if ( dhCheck . Equals ( "单号" ) )
                strSql . AppendFormat ( " AND GZ29='{0}'" ,oddNum );
            if ( gxCheck . Equals ( "工序" ) )
                strSql . AppendFormat ( " AND GZ04='{0}'" ,gX );
            SqlParameter [ ] parameter = {
                new SqlParameter("@GZ03",SqlDbType.NVarChar,20),
                new SqlParameter("@GZ01",SqlDbType.NVarChar,100),
                new SqlParameter("@GZ3",SqlDbType.NVarChar,20)//,
                //new SqlParameter("@GZ04",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = pro;
            parameter [ 1 ] . Value = num;
            parameter [ 2 ] . Value = buJ;
            //parameter [ 3 ] . Value = gX;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
            {
                try
                {
                    strSql = new StringBuilder ( );
                    strSql . Append ( "UPDATE R_PQW SET " );
                    strSql . AppendFormat ( "GZ03='{0}'" ,pro );
                    strSql . AppendFormat ( " WHERE GZ01='{0}' AND GZ03='{1}' AND idx NOT IN (SELECT FZ002 FROM R_PQFZ WHERE FZ001 IN (SELECT R_PQEZ.idx FROM R_PQEZ,R_REVIEWS WHERE EZ001=RES06 AND RES05='执行')) AND GZ39 IS NULL" ,num ,buJ /*,gX,oddNum*/ );//AND GZ29='{1}'  AND GZ04='{2}'
                    SqlHelper . ExecuteNonQuery ( Drity . DrityOfComparation ( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,stateOf ,stateOfState ) );
                }
                catch { }
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 批量编辑工序实际单价
        /// </summary>
        /// <returns></returns>
        public bool UpdateBatchPrice ( decimal price ,string num ,string parts ,string proce ,string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfState )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQW SET " );
            strSql.AppendFormat( "GZ06=@GZ06" ,price );
            strSql.AppendFormat( " WHERE GZ01=@GZ01 AND GZ03=@GZ03 AND GZ04=@GZ04" ,num ,parts ,proce );
            strSql.Append( " AND (GZ39!='执行' OR GZ39 IS NULL OR GZ39='')" );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ06",SqlDbType.Decimal,7),
                new SqlParameter("@GZ01",SqlDbType.NVarChar,100),
                new SqlParameter("@GZ03",SqlDbType.NVarChar,20),
                new SqlParameter("@GZ04",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = price;
            parameter[1].Value = num;
            parameter[2].Value = parts;
            parameter[3].Value = proce;
            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
            {
                try
                {
                    strSql = new StringBuilder( );
                    strSql.Append( "UPDATE R_PQW SET " );
                    strSql.AppendFormat( "GZ06='{0}'" ,price );
                    strSql.AppendFormat( " WHERE GZ01='{0}' AND GZ03='{1}' AND GZ04='{2}'" ,num ,parts ,proce );
                    strSql.Append( " AND (GZ39!='执行' OR GZ39 IS NULL OR GZ39='')" );
                    SqlHelper.ExecuteNonQuery( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfState ) );
                }
                catch { }
                return true;
            }
            else
                return false;
            
        }

        /// <summary>
        /// 批量编辑工序
        /// </summary>
        /// <param name="ori"></param>
        /// <param name="now"></param>
        /// <returns></returns>
        public bool UpdateBarchWork ( string ori ,string now,string num,string njName ,string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfState )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQW SET " );
            strSql.Append( "GZ04=@GZ04" );
            strSql.Append( " WHERE GZ04=@GZ4 AND GZ01=@GZ01 AND GZ03=@GZ03" );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ04",SqlDbType.NVarChar,20),
                new SqlParameter("@GZ4",SqlDbType.NVarChar,20),
                new SqlParameter("@GZ01",SqlDbType.NVarChar,100),
                new SqlParameter("@GZ03",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = now;
            parameter[1].Value = ori;
            parameter[2].Value = num;
            parameter[3].Value = njName;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
            {
                try
                {
                    strSql = new StringBuilder( );
                    strSql.Append( "UPDATE R_PQW SET " );
                    strSql.AppendFormat( "GZ04='{0}'" ,now );
                    strSql.AppendFormat( " WHERE GZ04='{0}' AND GZ01='{1}' AND GZ03='{2}'" ,ori ,num ,njName );
                    SqlHelper.ExecuteNonQuery( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfState ) );
                }
                catch { }
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( MulaolaoLibrary.ChanPinGongZiKaoQinLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfState )
        {
            ArrayList SQLString = new ArrayList( );
            bool result = false;
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQW" );
            strSql.AppendFormat( " WHERE idx='{0}'" ,model.Idx );
            SQLString.Add( strSql.ToString( ) );
            result = SqlHelper.ExecuteSqlTran( SQLString );
            if ( result == true )
            {
                try
                {
                    SqlHelper.ExecuteNonQuery( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.GZ29 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfState ) );
                }
                catch { }
            }

            return result;
        }
        

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DeleteOddNum ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dton ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQW" );
            strSql.AppendFormat( " WHERE GZ29='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dton ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }


        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ChanPinGongZiKaoQinLibrary GetModel ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQW" );
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
        /// 得到一个实体对象
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ChanPinGongZiKaoQinLibrary GetDataRow ( DataRow row )
        {
            MulaolaoLibrary.ChanPinGongZiKaoQinLibrary model = new MulaolaoLibrary.ChanPinGongZiKaoQinLibrary( );
            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    model.Idx = int.Parse( row["idx"].ToString( ) );
                if ( row["GZ01"] != null && row["GZ01"].ToString( ) != "" )
                    model.GZ01 = row["GZ01"].ToString( );
                if ( row["GZ02"] != null && row["GZ02"].ToString( ) != "" )
                    model.GZ02 = row["GZ02"].ToString( );
                if ( row["GZ03"] != null && row["GZ03"].ToString( ) != "" )
                    model.GZ03 = row["GZ03"].ToString( );
                if ( row["GZ04"] != null && row["GZ04"].ToString( ) != "" )
                    model.GZ04 = row["GZ04"].ToString( );
                if ( row["GZ05"] != null && row["GZ05"].ToString( ) != "" )
                    model.GZ05 = int.Parse( row["GZ05"].ToString( ) );
                if ( row["GZ06"] != null && row["GZ06"].ToString( ) != "" )
                    model.GZ06 = decimal.Parse( row["GZ06"].ToString( ) );
                if ( row["GZ07"] != null && row["GZ07"].ToString( ) != "" )
                    model.GZ07 = row["GZ07"].ToString( );
                if ( row["GZ08"] != null && row["GZ08"].ToString( ) != "" )
                    model.GZ08 = decimal.Parse( row["GZ08"].ToString( ) );
                if ( row["GZ09"] != null && row["GZ09"].ToString( ) != "" )
                    model.GZ09 = decimal.Parse( row["GZ09"].ToString( ) );
                if ( row["GZ10"] != null && row["GZ10"].ToString( ) != "" )
                    model.GZ10 = decimal.Parse( row["GZ10"].ToString( ) );
                if ( row["GZ11"] != null && row["GZ11"].ToString( ) != "" )
                    model.GZ11 = decimal.Parse( row["GZ11"].ToString( ) );
                if ( row["GZ12"] != null && row["GZ12"].ToString( ) != "" )
                    model.GZ12 = decimal.Parse( row["GZ12"].ToString( ) );
                if ( row["GZ13"] != null && row["GZ13"].ToString( ) != "" )
                    model.GZ13 = decimal.Parse( row["GZ13"].ToString( ) );
                if ( row["GZ14"] != null && row["GZ14"].ToString( ) != "" )
                    model.GZ14 = decimal.Parse( row["GZ14"].ToString( ) );
                //if ( row["GZ15"] != null && row["GZ15"].ToString( ) != "" )
                //    model.GZ15 = int.Parse( row["GZ15"].ToString( ) );
                if ( row["GZ16"] != null && row["GZ16"].ToString( ) != "" )
                    model.GZ16 = row["GZ16"].ToString( );
                if ( row["GZ17"] != null && row["GZ17"].ToString( ) != "" )
                    model.GZ17 = int.Parse( row["GZ17"].ToString( ) );
                if ( row["GZ18"] != null && row["GZ18"].ToString( ) != "" )
                    model.GZ18 = row["GZ18"].ToString( );
                //if ( row["GZ19"] != null && row["GZ19"].ToString( ) != "" )
                //    model.GZ19 = decimal.Parse( row["GZ19"].ToString( ) );
                if ( row["GZ20"] != null && row["GZ20"].ToString( ) != "" )
                    model.GZ20 = row["GZ20"].ToString( );
                if ( row["GZ21"] != null && row["GZ21"].ToString( ) != "" )
                    model.GZ21 = row["GZ21"].ToString( );
                if ( row["GZ22"] != null && row["GZ22"].ToString( ) != "" )
                    model.GZ22 = row["GZ22"].ToString( );
                if ( row["GZ23"] != null && row["GZ23"].ToString( ) != "" )
                    model.GZ23 = row["GZ23"].ToString( );
                if ( row["GZ24"] != null && row["GZ24"].ToString( ) != "" )
                    model.GZ24 = int.Parse( row["GZ24"].ToString( ) );
                if ( row["GZ25"] != null && row["GZ25"].ToString( ) != "" )
                    model.GZ25 = long.Parse( row["GZ25"].ToString( ) );
                if ( row["GZ26"] != null && row["GZ26"].ToString( ) != "" )
                    model.GZ26 = long.Parse( row["GZ26"].ToString( ) );
                if ( row["GZ27"] != null && row["GZ27"].ToString( ) != "" )
                    model.GZ27 = decimal.Parse( row["GZ27"].ToString( ) );
                if ( row["GZ28"] != null && row["GZ28"].ToString( ) != "" )
                    model.GZ28 = int.Parse( row["GZ28"].ToString( ) );
                if ( row["GZ29"] != null && row["GZ29"].ToString( ) != "" )
                    model.GZ29 = row["GZ29"].ToString( );
                if ( row["GZ30"] != null && row["GZ30"].ToString( ) != "" )
                    model.GZ30 = row["GZ30"].ToString( );
                if ( row["GZ31"] != null && row["GZ31"].ToString( ) != "" )
                    model.GZ31 = row["GZ31"].ToString( );
                if ( row["GZ32"] != null && row["GZ32"].ToString( ) != "" )
                    model.GZ32 = row["GZ32"].ToString( );
                if ( row["GZ33"] != null && row["GZ33"].ToString( ) != "" )
                    model.GZ33 = row["GZ33"].ToString( );
                if ( row["GZ34"] != null && row["GZ34"].ToString( ) != "" )
                    model.GZ34 = long.Parse( row["GZ34"].ToString( ) );
                if ( row["GZ35"] != null && row["GZ35"].ToString( ) != "" )
                    model.GZ35 = row["GZ35"].ToString( );
                if ( row["GZ36"] != null && row["GZ36"].ToString( ) != "" )
                    model.GZ36 = decimal.Parse( row["GZ36"].ToString( ) );
                if ( row["GZ37"] != null && row["GZ37"].ToString( ) != "" )
                    model.GZ37 = row["GZ37"].ToString( );
                if ( row["GZ38"] != null && row["GZ38"].ToString( ) != "" )
                    model.GZ38 = row["GZ38"].ToString( );
                if ( row["GZ39"] != null && row["GZ39"].ToString( ) != "" )
                    model.GZ39 = row["GZ39"].ToString( );
            }
            return model;   
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOf ( string strWhere ,string numOfTj)
        {
            /*CASE WHEN GZ01>='16080100' THEN CONVERT(DECIMAL(18,0),GZ06*GZ25*GZ41) ELSE CONVERT(DECIMAL(18,0),GZ06*GZ25) END U3*/
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT  A.idx,GZ01,GZ02,GZ03,GZ04,GX04,GZ05,GZ06,GZ07,GZ08,GZ09,GZ10,GZ11,GZ12,GZ13,GZ14,GZ16,GZ17,GZ18,GZ22,GZ23,GZ24,GZ25,GZ26,GZ27,GZ28,GZ29,GZ30,GZ31,GZ32,GZ33,GZ34,GZ36,GZ37,GZ38,GZ20,GZ39,GZ40,GZ41,GZ35,GZ44 FROM R_PQW  A LEFT JOIN R_PQAA B ON A.GZ04=B.GX02" );
            strSql.Append( " WHERE " + strWhere );
            //strSql.Append( " AND A.idx NOT IN (SELECT FZ002 FROM R_PQFZ WHERE FZ001 IN (SELECT A.idx FROM R_PQEZ A,R_REVIEWS B WHERE A.EZ001=B.RES06 AND RES05='执行'))" );
            strSql.Append( " AND GZ38=@GZ38" );
            strSql.Append( " ORDER BY GZ24 DESC,GZ17 DESC,GZ35 DESC,GZ04,REVERSE(GZ03)" );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ38",SqlDbType.NVarChar)
            };
            parameter[0].Value = numOfTj;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public DataTable GetDataTable ( string strWhere ,string num )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "IF OBJECT_ID(N'tempdb.dbo.#" + num + "') IS NOT NULL" );
            strSql . Append ( " DROP TABLE #" + num + "" );
            strSql . Append ( " ELSE" );
            strSql . Append ( " SELECT * INTO #" + num + " FROM R_PQW A" );
            strSql . Append ( " WHERE " + strWhere );
            //int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            //if ( row > 0 )
            //{
            //    strSql = new StringBuilder ( );
            strSql . Append ( " SELECT A.idx,GZ01,GZ02,GZ03,GZ04,GX04,GZ05,GZ06,GZ07,GZ08,GZ09,GZ10,GZ11,GZ12,GZ13,GZ14,GZ16,GZ17,GZ18,GZ22,GZ23,GZ24,GZ25,GZ26,GZ27,GZ28,GZ29,GZ30,GZ31,GZ32,GZ33,GZ34,GZ36,GZ37,GZ38,GZ20,GZ39,GZ40,GZ41,GZ35,GZ44 FROM #" + num + " A LEFT JOIN R_PQAA B ON A.GZ04=B.GX02 ORDER BY GZ35 DESC,GZ24 DESC,GZ17 DESC,GZ04,REVERSE(GZ03)" );
            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            //}
            //else
            //return null;            
        }
        public DataTable GetDataTable ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT A.idx,GZ01,GZ02,GZ03,GZ04,GX04,GZ05,GZ06,GZ07,GZ08,GZ09,GZ10,GZ11,GZ12,GZ13,GZ14,GZ16,GZ17,GZ18,GZ22,GZ23,GZ24,GZ25,GZ26,GZ27,GZ28,GZ29,GZ30,GZ31,GZ32,GZ33,GZ34,GZ36,GZ37,GZ38,GZ20,GZ39,GZ40,GZ41,GZ35,GZ44 FROM R_PQW A LEFT JOIN R_PQAA B ON A.GZ04=B.GX02 ORDER BY GZ35 DESC,GZ24 DESC,GZ17 DESC,GZ04,REVERSE(GZ03)" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }
        
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT idx,GZ29,GZ01,GZ22,GZ23,GZ03 FROM R_PQW" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取统计员
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableTj ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT GZ16,GZ32 FROM R_PQW WHERE GZ37 IS NOT NULL" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取生产人信息
        /// </summary>
        /// <param name="nameOfTjNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableWorkPerSon ( string nameOfTjNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT GZ02,GZ33 FROM R_PQW" );
            strSql.Append( " WHERE " + nameOfTjNum );
            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        
        /// <summary>
        /// 获取统计员
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public DataTable GetDataTableLeadesr (string number )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT GZ37,GZ38 FROM R_PQW" );
            strSql.Append( " WHERE GZ32=@GZ32" );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ32",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = number;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTableWork ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,GZ03,ISNULL(CONVERT(DECIMAL(6,0),GS10),0) GS,'' GX02,'' DS1 FROM (" );
            strSql.Append( " SELECT DISTINCT idx,GS07 GZ03,GS10  FROM R_PQP" );
            strSql.Append( " WHERE GS01=@GZ01" );
            strSql.Append( " UNION SELECT DISTINCT idx,GS56 GZ03,GS59 FROM R_PQP" );
            strSql.Append( " WHERE GS01=@GZ01" );
            strSql.Append( " ) A WHERE GZ03!='' AND GZ03 IS NOT NULL ORDER BY REVERSE(GZ03)" );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ01",SqlDbType.NVarChar)
            };

            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public DataTable GetDataTableWorkProcedure ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            //strSql.Append( "SELECT idx,DS03 GZ03,ISNULL(DS29,0) GS,DS04 GX02,CASE WHEN DS06!=0 THEN CONVERT(DECIMAL(18,4),DS05*1.0/DS06) ELSE 0 END DS1 FROM R_PQR WHERE DS01=@DS01 ORDER BY REVERSE(DS03)" );
            //SqlParameter[] parameter = {
            //    new SqlParameter("@DS01",SqlDbType.NVarChar)
            //};
            //parameter[0].Value = num;
            strSql . Append ( "WITH CET AS (" );
            strSql . Append ( "SELECT PQX14 GZ03,PQX36 GS,PQX15 GX02,CASE WHEN DS06!=0 THEN CONVERT(DECIMAL(18,4),DS05*1.0/DS06) ELSE 0 END DS1,'R_046' TAB FROM R_PQX A LEFT JOIN R_PQR ON DS01=PQX01 AND PQX14=DS03 AND PQX15=DS04 " );
            strSql . Append ( "WHERE PQX01=@PQX01 " );
            strSql . Append ( "UNION " );
            strSql . Append ( "SELECT DS03 GZ03,ISNULL(DS29,0) GS,DS04 GX02,CASE WHEN DS06!=0 THEN CONVERT(DECIMAL(18,4),DS05*1.0/DS06) ELSE 0 END DS1,'R_436' TAB FROM R_PQR  " );
            strSql . Append ( "WHERE DS01=@PQX01 " );
            strSql . Append ( ") " );
            strSql . Append ( "SELECT ROW_NUMBER() over(order by GZ03) idx,GZ03,GS,GX02,DS1,MIN(TAB) TAB FROM CET GROUP BY GZ03,GS,GX02,DS1 ORDER BY REVERSE(GZ03)" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PQX01",SqlDbType.NVarChar)
            };
            parameter [ 0 ] . Value = num;

            return SqlHelper .ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取工序名称
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableWorkPro ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT GX02 FROM R_PQAA" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableBom ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT GX02 FROM R_PQAA ORDER BY GX02" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableBom ( string num ,string partName )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql . Append ( "WITH CET AS (" );
            strSql . Append ( "SELECT PQX15 GX02,'R_046' TAB FROM R_PQX WHERE PQX01=@PQX01 AND PQX14=@PQX14 " );
            strSql . Append ( "UNION " );
            strSql.Append( "SELECT DS04 GX02,'R_436' TAB FROM R_PQR WHERE DS01=@PQX01 AND DS03=@PQX14" );
            strSql . Append ( ") " );
            strSql . Append ( "SELECT GX02,MIN(TAB) TAB FROM CET  GROUP  BY GX02 ORDER BY GX02" );
            SqlParameter[] parameter = {
                new SqlParameter("@PQX01",SqlDbType.NVarChar),
                new SqlParameter("@PQX14",SqlDbType.NVarChar)
            };
            parameter [ 0 ] . Value = num;
            parameter [ 1 ] . Value = partName;
            
            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetDataTableProcess ( MulaolaoLibrary.ChanPinGongZiKaoQinLibrary model)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DS07 FROM R_PQR" );
            strSql.Append( " WHERE DS01=@DS01 AND DS03=@DS03 AND DS04=@DS04" );
            SqlParameter[] parameter = {
                new SqlParameter("@DS01",SqlDbType.NVarChar),
                new SqlParameter("@DS03",SqlDbType.NVarChar),
                new SqlParameter("@DS04",SqlDbType.NVarChar)
            };

            parameter[0].Value = model.GZ01;
            parameter[1].Value = model.GZ03;
            parameter[2].Value = model.GZ04;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }



        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTableAll (string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT GZ02,GZ05,GZ06,GZ07,GZ15,GZ08,GZ16 FROM R_PQW" );
            strSql.Append( " WHERE GZ23=@GZ23" );

            SqlParameter[] parameter = {
                new SqlParameter("@GZ23",SqlDbType.NVarChar)
            };

            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOne ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DBA002,DBA001 FROM TPADBA WHERE DBA005=(SELECT DAA001 FROM TPADAA WHERE DAA002='生产部') AND (DBA043='F' OR DBA043='' OR DBA043 IS NULL)" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetChanPinCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQW" );
            strSql.Append( " WHERE " + strWhere );

            object count = SqlHelper.GetSingle( strSql.ToString( ) );
            if ( count == null )
                return 0;
            else
                return Convert.ToInt32( count );
        }


        /// <summary>
        /// 是否送审
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="formText"></param>
        /// <returns></returns>
        public bool ExistsReview ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQW " );
            strSql.Append( " WHERE GZ29=@GZ29 AND GZ39='执行'" );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ29",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTableByChange ( string strWhere ,int startIndex,int endIndex)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT idx,GZ29,GZ01,GZ22,GZ23,GZ02,GZ03,GZ16,GZ37,GZ39 RES05 FROM (" );
            strSql.Append( "SELECT ROW_NUMBER() OVER(" );
            strSql.Append( "ORDER BY T.GZ29 DESC" );
            strSql.Append( ") AS ROW,T.* FROM R_PQW T" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( " ) TT" );
            strSql.AppendFormat( " WHERE TT.ROW BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Update ( )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQW SET GZ39='送审' WHERE (GZ39='' OR GZ39 IS NULL) AND GZ29 IN (SELECT RES06 FROM R_REVIEWS WHERE RES01='R_317' AND RES05='送审')" );
            StringBuilder strS= new StringBuilder( );
            strS.Append( "UPDATE R_PQW SET GZ39='执行' WHERE idx IN (SELECT FZ002 FROM R_PQFZ WHERE FZ001 IN (SELECT A.idx FROM R_PQEZ A,R_REVIEWS B WHERE RES06=EZ001 AND RES05='执行'))" );
            SQLString.Add( strS.ToString( ) );
            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取写入046数据
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTableWrite ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT GZ01,GZ03,GZ04,GZ24,GZ17,SUM(GZ25+GZ26) GZ FROM R_PQW " );
            strSql.Append( "WHERE GZ01=@GZ01 GROUP BY GZ01,GZ03,GZ04,GZ24,GZ17" );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ01",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }


        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="nu"></param>
        /// <returns></returns>
        public bool UpdateSum ( MulaolaoLibrary.ChanPinGongZiKaoQinLibrary model ,int GZ)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQX SET" );
            strSql.Append( " PQX24=@GZ" );
            strSql.Append( " WHERE PQX01=@GZ01 AND PQX14=@GZ03 AND PQX15=@GZ04 AND DATEPART(MONTH,PQX26)=@GZ24 AND DATEPART(DAY,PQX26)=@GZ17" );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ01",SqlDbType.NVarChar),
                new SqlParameter("@GZ03",SqlDbType.NVarChar),
                new SqlParameter("@GZ04",SqlDbType.NVarChar),
                new SqlParameter("@GZ24",SqlDbType.Int),
                new SqlParameter("@GZ17",SqlDbType.Int),
                new SqlParameter("@GZ",SqlDbType.Int)
            };

            parameter[0].Value = model.GZ01;
            parameter[1].Value = model.GZ03;
            parameter[2].Value = model.GZ04;
            parameter[3].Value = model.GZ24;
            parameter[4].Value = model.GZ17;
            parameter[5].Value = GZ;

            int rows = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取数据列表  组长
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataTable GetDataTableLeaderY (  )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DBA002,DBA001 FROM TPADBA " );
            strSql . Append ( "WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002 IN (SELECT DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002 IN (SELECT DBA002 FROM TPADBA WHERE DBA005=(SELECT DAA001 FROM TPADAA WHERE DAA002='生产部')) AND (DBA043='F' OR DBA043='' OR DBA043 IS NULL)))) AND (DBA043='F' OR DBA043='' OR DBA043 IS NULL)" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        public DataTable GetDataTableLeader( string name )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DBA002,DBA001 FROM TPADBA " );//AND DBA043='F'
            strSql . AppendFormat ( "WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002='{0}') " ,name );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据列表组长
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableLeader ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DBA001,DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002 IN (SELECT DBA002 FROM TPADBA WHERE DBA005=(SELECT DAA001 FROM TPADAA WHERE DAA002='生产部')) AND (DBA043='F' OR DBA043='' OR DBA043 IS NULL))" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取统计员
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableSta ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT DBA001,DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002='统计员')  AND (DBA043='F' OR DBA043='' OR DBA043 IS NULL)" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表  定日工资额
        /// </summary>
        /// <param name="workProcedure"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrice ( string workProcedure )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT GX03 FROM R_PQAA" );
            strSql.Append( " WHERE GX02=@GX02" );
            SqlParameter[] parameter = {
                new SqlParameter("@GX02",SqlDbType.NVarChar)
            };

            parameter[0].Value = workProcedure;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePlanPrice (string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DS01,DS03,DS04,CASE WHEN DS06=0 THEN 0 WHEN DS06!=0 THEN CONVERT(DECIMAL(10,4),DS05*1.0/DS06) END DS FROM R_PQR" );
            strSql.Append( " WHERE DS01=@DS01" );
            SqlParameter[] parameter = {
                new SqlParameter("@DS01",SqlDbType.NVarChar)
            };

            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdatePlanPrice ( MulaolaoLibrary.ChanPinGongZiKaoQinLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQW SET " );
            strSql.Append( "GZ27=@GZ27" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ27",SqlDbType.Decimal),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = model.GZ27;
            parameter[1].Value = model.Idx;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除送审记录
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DeleteReview ( string tableName ,string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_REVIEWS" );
            strSql.Append( " WHERE RES01=@RES01 AND RES06=@RES06" );
            SqlParameter[] parameter = {
                new SqlParameter("@RES01",SqlDbType.NVarChar),
                new SqlParameter("@RES06",SqlDbType.NVarChar)
            };

            parameter[0].Value = tableName;
            parameter[1].Value = oddNum;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 是否存在统计员
        /// </summary>
        /// <param name="nameOfTj"></param>
        /// <returns></returns>
        public bool ExistsTJ ( string nameOfTj )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQW" );
            strSql.Append( " WHERE GZ38=@GZ38" );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ38",SqlDbType.NVarChar)
            };
            parameter[0].Value = nameOfTj;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="nameOfWork"></param>
        /// <param name="nameOfLeader"></param>
        /// <returns></returns>
        public DataTable GetDataTableOddOne ( string nameOfWork ,string nameOfLeader ,string nameOfT )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT GZ29 FROM R_PQW" );
            strSql . Append ( "  WHERE GZ02=@GZ02 AND GZ16=@GZ16 AND GZ37=@GZ37" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@GZ02",SqlDbType.NVarChar),
                new SqlParameter("@GZ16",SqlDbType.NVarChar),
                new SqlParameter("@GZ37",SqlDbType.NVarChar)
            };
            parameter [ 0 ] . Value = nameOfWork;
            parameter [ 1 ] . Value = nameOfLeader;
            parameter [ 2 ] . Value = nameOfT;

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableNum ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT AE02,AE03,GZ44,GZ28,MONTH(AE21) AE21 FROM R_PQAE A RIGHT JOIN R_PQW B ON A.AE02=B.GZ01 WHERE AE21 IS NOT NULL AND AE21!='' AND (GZ39!='执行' OR GZ39='' OR GZ39 IS NULL) ORDER BY AE02" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 批量编辑结算月份
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool BatchEdit ( List<string> stList,DateTime dtOne ,string signOf,DateTime dt ,string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtTwo ,string stateOf ,string stateOfOdd ,string other )
        {
            MulaolaoLibrary.ChanPinGongZiKaoQinLibrary _model = new MulaolaoLibrary.ChanPinGongZiKaoQinLibrary( );
            ArrayList SQLString = new ArrayList( );
            if ( other == 0.ToString( ) )
            {
                foreach ( string str in stList )
                {
                    _model.GZ01 = str;
                    StringBuilder strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQW SET GZ28=0,GZ42='',GZ43='',GZ44=0 WHERE GZ01='{0}' AND ( GZ39='' OR GZ39 IS NULL )" ,_model.GZ01 );
                    SQLString.Add( strSql.ToString( ) );
                    SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtTwo ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );
                }
            }
            else
            {
                foreach ( string str in stList )
                {
                    _model.GZ01 = str;
                    _model.GZ28 = dtOne.Month;
                    _model.GZ44 = dtOne.Year;
                    StringBuilder strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQW SET GZ28={0},GZ42='{2}',GZ43='{3}',GZ44={4} WHERE GZ01='{1}' AND GZ28=0 AND GZ44=0" ,_model.GZ28 ,_model.GZ01 ,signOf ,dt ,_model.GZ44 );
                    /*AND (GZ39!='执行' OR GZ39='' OR GZ39 IS NULL)*/
                    SQLString.Add( strSql.ToString( ) );
                    SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtTwo ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );
                }
            }

            StringBuilder strSq = new StringBuilder( );
            strSq.Append( "UPDATE R_PQW SET GZ28='' WHERE idx IN (SELECT idx FROM R_PQW WHERE GZ01 IN (SELECT DISTINCT AE02 FROM R_PQAE WHERE AE02 NOT IN (SELECT DISTINCT AE02 FROM R_PQAE  WHERE AE21 IS NOT NULL)) AND GZ28!=0 AND (GZ39!='执行' OR GZ39 IS NULL))" );
            SQLString.Add( strSq.ToString( ) );
            StringBuilder strS = new StringBuilder( );
            strS.Append( "UPDATE R_PQW SET GZ28=0 WHERE GZ01 NOT IN (SELECT DISTINCT AE02 FROM R_PQAE) AND GZ28!=0" );
            SQLString.Add( strS.ToString( ) );
            
            
            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 更改GZ25=1
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool isZeroId ( string strWhere)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQW SET GZ25=1" );
            strSql.Append( " WHERE idx in (" + strWhere + ")" );

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }
        public bool calCuIsZero ( )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "WITH CET AS( " );
            strSql.Append( "SELECT SU,GZ01,GZ03,GZ04 FROM (SELECT CONVERT(DECIMAL(14,6),CASE WHEN SUM(ISNULL(GZ25,0))=0 THEN 0 ELSE (ISNULL(GZ34*GZ40*1.0,0)-SUM(ISNULL(GZ26,0)))/SUM(ISNULL(GZ25,0)) END) SU,GZ01,GZ03,GZ04 FROM R_PQW GROUP BY GZ34,GZ40,GZ01,GZ03,GZ04) A)" );
            strSql.Append( " UPDATE R_PQW SET GZ41=A.SU FROM CET A,R_PQW B WHERE A.GZ01=B.GZ01 AND A.GZ03=B.GZ03 AND A.GZ04=B.GZ04" );
            SQLString.Add( strSql.ToString( ) );
            StringBuilder strSq = new StringBuilder( );
            strSq.Append( "UPDATE R_PQW SET GZ41=1.000000 WHERE GZ41>1" );
            SQLString.Add( strSq.ToString( ) );
            StringBuilder strS = new StringBuilder( );
            strS.Append( "UPDATE R_PQW SET GZ41=0.000000 WHERE GZ41<0" );
            SQLString.Add( strS.ToString( ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取流水号
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfNum ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT PQF01,PQF03,PQF04,PQF06 FROM R_PQF ORDER BY PQF01 DESC" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        public DataTable GetDataTableOfNumS ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT BG001,BG002,BG003,BG004 FROM R_PQBG" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 批量编辑
        /// </summary>
        /// <param name="numOne"></param>
        /// <param name="numTwo"></param>
        /// <param name="tableNum"></param>
        /// <param name="tableName"></param>
        /// <param name="logins"></param>
        /// <param name="dtOne"></param>
        /// <param name="oddNum"></param>
        /// <param name="stateOf"></param>
        /// <param name="stateOfOdd"></param>
        /// <returns></returns>
        public bool UpdateOfNum ( string numOne ,string numTwo ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string oddNum ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "UPDATE R_PQW SET GZ01='{0}' WHERE GZ01='{1}'" ,numOne ,numTwo );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );
            strSql = new StringBuilder( );
            strSql.AppendFormat( "UPDATE R_PQBG SET BG005='{0}' WHERE BG001='{1}'" ,numOne ,numTwo );
            SQLString.Add( strSql.ToString( ) );
            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 批量编辑人员隶属关系
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userNum"></param>
        /// <returns></returns>
        public bool changeUserForLeader ( string userName ,List<string> strList ,string logins)
        {
            string str = string . Empty;
            foreach ( string s in strList )
            {
                if ( str == string . Empty )
                    str = "'" + s + "'";
                else
                    str = str + "," + "'" + s + "'";
            }
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE TPADBA SET DBA005=(SELECT TOP 1 DAA001 FROM TPADAA WHERE DAA002='{0}') WHERE DBA001 IN ({1})" ,userName ,str );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_318" ,"人员隶属关系批量变更(R_318)" ,logins ,DateTime . Now ,"" ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"批量编辑人员隶属关系" ,"批量编辑人员隶属关系" ) );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 获取317未执行的组长和统计员
        /// </summary>
        /// <returns></returns>
        public DataTable getTableOfPQW ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT GZ37,GZ38,GZ16,GZ32 FROM R_PQW WHERE GZ39='' OR GZ39 IS NULL" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取317未执行的车间主任
        /// </summary>
        /// <returns></returns>
        public DataTable getTableOfPQWC ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT GZ30,GZ31 FROM R_PQW WHERE GZ39='' OR GZ39 IS NULL" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 317组长批量变更
        /// </summary>
        /// <param name="orOneNum">变更后组长编号/param>
        /// <param name="orOneName">变更后组长姓名</param>
        /// <param name="orTwoNum">变更前组长编号</param>
        /// <param name="orTwoName">变更前组长姓名</param>
        /// <returns></returns>
        public bool EditOrder ( string orOneNum,string orOneName,string orTwoNum,string orTwoName )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE R_PQW SET GZ16='{0}',GZ32='{1}' WHERE GZ16='{2}' AND GZ32='{3}' AND (GZ39='' OR GZ39 IS NULL)" ,orOneName ,orOneNum ,orTwoName ,orTwoNum );

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 317统计员批量变更
        /// </summary>
        /// <returns></returns>
        public bool EditOrder ( string orOneNum ,string orOneName ,string tOneNum ,string tOneName,string tTwoNum,string tTwoName )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE R_PQW SET GZ37='{0}',GZ38='{1}' WHERE GZ16='{2}' AND GZ32='{3}' AND GZ37='{4}' AND GZ38='{5}' AND (GZ39='' OR GZ39 IS NULL)" ,tOneName ,tOneNum ,orOneName ,orOneNum ,tTwoName ,tTwoNum );

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 317车间主任批量变更
        /// </summary>
        /// <returns></returns>
        public bool EditOrderC ( string orOneNum ,string orOneName ,string cOneNum ,string cOneName ,string cTwoNum ,string cTwoName )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE R_PQW SET GZ30='{0}',GZ31='{1}' WHERE GZ16='{2}' AND GZ32='{3}' AND GZ30='{4}' AND GZ31='{5}' AND (GZ39='' OR GZ39 IS NULL)" ,cTwoName ,cTwoNum ,orOneName ,orOneNum ,cOneName ,cOneNum );

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取人员信息
        /// </summary>
        /// <returns></returns>
        public DataTable getUserFor317 ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT GZ02,GZ33 FROM R_PQW WHERE GZ39='' OR GZ39 IS NULL" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTableView ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT GZ02,GZ33,GZ04,GZ36,0 GZ FROM R_PQW WHERE (GZ39='' OR GZ39 IS NULL) AND {0} " ,strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 批量编辑计时日工资
        /// </summary>
        /// <param name="table"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public bool UpdateSales ( DataTable table ,int year ,int month )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            MulaolaoLibrary . ChanPinGongZiKaoQinLibrary model = new MulaolaoLibrary . ChanPinGongZiKaoQinLibrary ( );
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                //调整后的计时日工资
                model . GZ09 = string . IsNullOrEmpty ( table . Rows [ i ] [ "GZ" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "GZ" ] . ToString ( ) );
                if ( model . GZ09 > 0 )
                {
                    model . GZ33 = table . Rows [ i ] [ "GZ33" ] . ToString ( );
                    model . GZ04 = table . Rows [ i ] [ "GZ04" ] . ToString ( );
                    model . GZ35 = year . ToString ( );
                    model . GZ24 = month;
                    strSql = new StringBuilder ( );
                    //没有执行+人+工序+年+月
                    strSql . AppendFormat ( "UPDATE R_PQW SET GZ36='{0}' WHERE (GZ39='' OR GZ39 IS NULL) AND GZ33='{1}' AND GZ04='{2}' AND GZ35={3} AND GZ24={4}" ,model . GZ09 ,model . GZ33 ,model . GZ04 ,model . GZ35 ,model . GZ24 );
                    SQLString . Add ( strSql ,null );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

    }
}

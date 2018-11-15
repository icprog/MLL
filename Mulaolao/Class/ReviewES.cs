using StudentMgr;
using System;
using System . Data;
using System . Data . SqlClient;
using System . Text;
using System . Windows . Forms;

namespace Mulaolao . Class
{
    public static class ReviewES
    {
        //有合同编号且唯一
        /// <summary>
        /// 送审
        /// </summary>
        /// <param name="RES01">程序编号+合同号/程序编号+合同批次号</param>
        /// <param name="RES02">是否补充等状态</param>
        /// <param name="RES03">处理人编号</param>
        /// <param name="RES05">送审状态</param>
        /// <param name="RES06">送审内容</param>
        /// <param name="RES07">送审意见</param>
        /// <param name="variables">合同号或者流水号或者其它唯一识别号</param>
        /// <param name="num">送审人编号</param>
        /// <returns></returns>
        /// string reve,
        public static int Revie ( Form fm ,string num ,string RES02 ,string RES05 ,string RES06 ,string RES07 ,DateTime? dt )
        {
            StringBuilder strSql = new StringBuilder ( );
            string RES01 = fm . Text . Substring ( fm . Text . LastIndexOf ( "(" ) + 1 ,fm . Text . LastIndexOf ( ")" ) - fm . Text . LastIndexOf ( "(" ) - 1 );
            string RES03 = num;
            int count = 0;
            DataTable dwf = SqlHelper . ExecuteDataTable ( "SELECT * FROM R_REVIEWS A,R_MLLCXMC B WHERE A.RES01=B.CX01 AND CX02=@CX02 AND RES06=@RES06" ,new SqlParameter ( "@CX02" ,fm . Text ) ,new SqlParameter ( "@RES06" ,RES06 ) );
            if ( dwf != null && dwf . Rows . Count > 0 )
            {
                if ( dwf . Select ( "RES05='执行'" ) . Length < 1 || RES05 == "驳回" )
                {
                    //AND RES03=@RES03
                    SqlHelper . ExecuteNonQuery ( "DELETE FROM R_REVIEWS WHERE RES01 IN (SELECT RES01 FROM R_REVIEWS A,R_MLLCXMC B WHERE A.RES01=B.CX01 AND CX02=@CX02) AND RES06=@RES06" ,new SqlParameter ( "@CX02" ,fm . Text ) ,new SqlParameter ( "@RES06" ,RES06 )/*, new SqlParameter( "@RES03", RES03 )*/ );

                    count = getSql ( strSql ,new object [ ] { RES01 ,RES02 ,RES03 ,RES05 ,RES06 ,RES07 ,dt } );

                    //count = SqlHelper . ExecuteNonQuery ( "INSERT INTO R_REVIEWS (RES01,RES02,RES03,RES05,RES06,RES07,RES08) VALUES (@RES01,@RES02,@RES03,@RES05,@RES06,@RES07,@RES08)" ,new SqlParameter ( "@RES01" ,RES01 ) ,new SqlParameter ( "@RES02" ,RES02
                        //) ,new SqlParameter ( "@RES03" ,RES03 ) ,new SqlParameter ( "@RES05" ,RES05 ) ,new SqlParameter ( "@RES06" ,RES06 ) ,new SqlParameter ( "@RES07" ,RES07 ) ,new SqlParameter ( "@RES08" ,dt ) );
                }
                else if ( RES05 == "执行" )
                    MessageBox . Show ( "此单据的状态已经为执行,若要继续送审,请选择状态为驳回" );

            }
            else
            {
                count = getSql ( strSql ,new object [ ] { RES01 ,RES02 ,RES03 ,RES05 ,RES06 ,RES07 ,dt } );
                //count = SqlHelper . ExecuteNonQuery ( "INSERT INTO R_REVIEWS (RES01,RES02,RES03,RES05,RES06,RES07,RES08) VALUES (@RES01,@RES02,@RES03,@RES05,@RES06,@RES07,@RES08)" ,new SqlParameter ( "@RES01" ,RES01 ) ,new SqlParameter ( "@RES02" ,RES02 ) ,new SqlParameter ( "@RES03" ,RES03 ) ,new SqlParameter ( "@RES05" ,RES05 ) ,new SqlParameter ( "@RES06" ,RES06 ) ,new SqlParameter ( "@RES07" ,RES07 ) ,new SqlParameter ( "@RES08" ,dt ) );
            }

            return count;
        }

       static int getSql ( StringBuilder strSql,object[] obj )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_REVIEWS (RES01,RES02,RES03,RES05,RES06,RES07,RES08) VALUES (@RES01,@RES02,@RES03,@RES05,@RES06,@RES07,@RES08)" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@RES01",SqlDbType.NVarChar,50),
                new SqlParameter("@RES02",SqlDbType.NVarChar,50),
                new SqlParameter("@RES03",SqlDbType.NVarChar,50),
                new SqlParameter("@RES05",SqlDbType.NVarChar,20),
                new SqlParameter("@RES06",SqlDbType.NVarChar,50),
                new SqlParameter("@RES07",SqlDbType.NVarChar,255),
                new SqlParameter("@RES08",SqlDbType.Date)
            };
            parameter [ 0 ] . Value = obj [ 0 ];
            parameter [ 1 ] . Value = obj [ 1 ];
            parameter [ 2 ] . Value = obj [ 2 ];
            parameter [ 3 ] . Value = obj [ 3 ];
            parameter [ 4 ] . Value = obj [ 4 ];
            parameter [ 5 ] . Value = obj [ 5 ];
            if ( obj [ 6 ] != null )
                parameter [ 6 ] . Value = obj [ 6 ];
            else
                parameter [ 6 ] . Value = DBNull . Value;

            return SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
        }

    }
}

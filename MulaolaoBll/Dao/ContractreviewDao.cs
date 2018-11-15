using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;
using StudentMgr;
using System . Collections;
using System . Data . SqlClient;

namespace MulaolaoBll . Dao
{
    public class ContractreviewDao
    {
        public DataTable GetDataTableOfWork ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DAA001,DAA002 FROM TPADAA WHERE DAA002 IN (SELECT DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002 IN (SELECT DBA002 FROM TPADBA WHERE DBA005=(SELECT DAA001 FROM TPADAA WHERE DAA002='生产部'))  AND (DBA043='F' OR DBA043='' OR DBA043 IS NULL) )) UNION SELECT DAA001,DAA002 FROM TPADAA WHERE DAA001 LIKE '13%'" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        public bool delete ( string logins )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQL WHERE HT04='' AND HT04 IS NULL" );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_021" ,"合同评审表(R_021)" ,logins ,Drity . GetDt ( ) ,"" ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除空白" ) );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        public DataTable printOne ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT PQF03,PQF04,PQF05,PQF06,CONVERT(varchar(100), PQF31, 102) PQF31,PQF07,PQF08,HT07,PQF01 FROM R_PQF A, R_PQL B WHERE A.PQF01 = B.HT01 AND HT64= '{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        public DataTable printTwo ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT HT02,HT03,CONVERT(varchar(100), HT04, 102) HT04,DFA002,DFA015,DFA016,HT10,HT11,CONVERT(varchar(100), HT12, 102) HT12,HT18,HT20,HT21,HT23,HT25,HT26,HT28,HT30,HT32,HT34,HT35,HT37,HT39,HT40,HT42,HT44,HT45,HT49,HT51,HT52 FROM R_PQL A,R_PQF B,TPADFA C WHERE A.HT02 = B.PQF02 AND B.PQF11 = C.DFA001 AND HT64 = '{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        public DataTable getTable ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT HT63 FROM R_PQL WHERE HT64='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        public bool Save ( MulaolaoLibrary . ContractreviewEntity model )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            
            strSql . Append ( "update R_PQL set " );
            strSql . Append ( "HT02=@HT02," );
            strSql . Append ( "HT03=@HT03," );
            strSql . Append ( "HT04=@HT04," );
            strSql . Append ( "HT08=@HT08," );
            strSql . Append ( "HT09=@HT09," );
            strSql . Append ( "HT10=@HT10," );
            strSql . Append ( "HT11=@HT11," );
            strSql . Append ( "HT12=@HT12," );
            strSql . Append ( "HT18=@HT18," );
            strSql . Append ( "HT20=@HT20," );
            strSql . Append ( "HT21=@HT21," );
            strSql . Append ( "HT23=@HT23," );
            strSql . Append ( "HT25=@HT25," );
            strSql . Append ( "HT26=@HT26," );
            strSql . Append ( "HT28=@HT28," );
            strSql . Append ( "HT30=@HT30," );
            strSql . Append ( "HT32=@HT32," );
            strSql . Append ( "HT34=@HT34," );
            strSql . Append ( "HT35=@HT35," );
            strSql . Append ( "HT37=@HT37," );
            strSql . Append ( "HT39=@HT39," );
            strSql . Append ( "HT40=@HT40," );
            strSql . Append ( "HT42=@HT42," );
            strSql . Append ( "HT44=@HT44," );
            strSql . Append ( "HT45=@HT45," );
            strSql . Append ( "HT47=@HT47," );
            strSql . Append ( "HT49=@HT49," );
            strSql . Append ( "HT51=@HT51," );
            strSql . Append ( "HT52=@HT52," );
            strSql . Append ( "HT55=@HT55," );
            strSql . Append ( "HT58=@HT58," );
            strSql . Append ( "HT59=@HT59," );
            strSql . Append ( "HT60=@HT60," );
            strSql . Append ( "HT61=@HT61," );
            strSql . Append ( "HT62=@HT62," );
            strSql . Append ( "HT63=@HT63 " );
            strSql . Append ( " where HT64=@HT64" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@HT02", SqlDbType.NVarChar,20),
                    new SqlParameter("@HT03", SqlDbType.NVarChar,20),
                    new SqlParameter("@HT04", SqlDbType.Date,3),
                    new SqlParameter("@HT08", SqlDbType.VarBinary,-1),
                    new SqlParameter("@HT09", SqlDbType.NVarChar,10),
                    new SqlParameter("@HT10", SqlDbType.NVarChar,10),
                    new SqlParameter("@HT11", SqlDbType.NVarChar,10),
                    new SqlParameter("@HT12", SqlDbType.Date,3),
                    new SqlParameter("@HT18", SqlDbType.NVarChar,100),
                    new SqlParameter("@HT20", SqlDbType.NVarChar,100),
                    new SqlParameter("@HT21", SqlDbType.NVarChar,50),
                    new SqlParameter("@HT23", SqlDbType.NVarChar,100),
                    new SqlParameter("@HT25", SqlDbType.NVarChar,255),
                    new SqlParameter("@HT26", SqlDbType.NVarChar,50),
                    new SqlParameter("@HT28", SqlDbType.NVarChar,100),
                    new SqlParameter("@HT30", SqlDbType.NVarChar,100),
                    new SqlParameter("@HT32", SqlDbType.NVarChar,100),
                    new SqlParameter("@HT34", SqlDbType.NVarChar,100),
                    new SqlParameter("@HT35", SqlDbType.NVarChar,50),
                    new SqlParameter("@HT37", SqlDbType.NVarChar,100),
                    new SqlParameter("@HT39", SqlDbType.NVarChar,100),
                    new SqlParameter("@HT40", SqlDbType.NVarChar,50),
                    new SqlParameter("@HT42", SqlDbType.NVarChar,100),
                    new SqlParameter("@HT44", SqlDbType.NVarChar,100),
                    new SqlParameter("@HT45", SqlDbType.NVarChar,50),
                    new SqlParameter("@HT47", SqlDbType.NVarChar,100),
                    new SqlParameter("@HT49", SqlDbType.NVarChar,100),
                    new SqlParameter("@HT51", SqlDbType.NVarChar,100),
                    new SqlParameter("@HT52", SqlDbType.NVarChar,50),
                    new SqlParameter("@HT55", SqlDbType.NVarChar,255),
                    new SqlParameter("@HT58", SqlDbType.VarBinary,-1),
                    new SqlParameter("@HT59", SqlDbType.VarBinary,-1),
                    new SqlParameter("@HT60", SqlDbType.VarBinary,-1),
                    new SqlParameter("@HT61", SqlDbType.VarBinary,-1),
                    new SqlParameter("@HT62", SqlDbType.VarBinary,-1),
                    new SqlParameter("@HT63", SqlDbType.NVarChar,-1),
                    new SqlParameter("@HT64", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = model . HT02;
            parameters [ 1 ] . Value = model . HT03;
            parameters [ 2 ] . Value = model . HT04;
            parameters [ 3 ] . Value = model . HT08;
            parameters [ 4 ] . Value = model . HT09;
            parameters [ 5 ] . Value = model . HT10;
            parameters [ 6 ] . Value = model . HT11;
            parameters [ 7 ] . Value = model . HT12;
            parameters [ 8 ] . Value = model . HT18;
            parameters [ 9 ] . Value = model . HT20;
            parameters [ 10 ] . Value = model . HT21;
            parameters [ 11 ] . Value = model . HT23;
            parameters [ 12 ] . Value = model . HT25;
            parameters [ 13 ] . Value = model . HT26;
            parameters [ 14 ] . Value = model . HT28;
            parameters [ 15 ] . Value = model . HT30;
            parameters [ 16 ] . Value = model . HT32;
            parameters [ 17 ] . Value = model . HT34;
            parameters [ 18 ] . Value = model . HT35;
            parameters [ 19 ] . Value = model . HT37;
            parameters [ 20 ] . Value = model . HT39;
            parameters [ 21 ] . Value = model . HT40;
            parameters [ 22 ] . Value = model . HT42;
            parameters [ 23 ] . Value = model . HT44;
            parameters [ 24 ] . Value = model . HT45;
            parameters [ 25 ] . Value = model . HT47;
            parameters [ 26 ] . Value = model . HT49;
            parameters [ 27 ] . Value = model . HT51;
            parameters [ 28 ] . Value = model . HT52;
            parameters [ 29 ] . Value = model . HT55;
            parameters [ 30 ] . Value = model . HT58;
            parameters [ 31 ] . Value = model . HT59;
            parameters [ 32 ] . Value = model . HT60;
            parameters [ 33 ] . Value = model . HT61;
            parameters [ 34 ] . Value = model . HT62;
            parameters [ 35 ] . Value = model . HT63;
            parameters [ 36 ] . Value = model . HT64;
            SQLString . Add ( strSql ,parameters );

            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQF SET PQF30=@PQF30 WHERE PQF02=@PQF02" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PQF30",SqlDbType.Date,3),
                new SqlParameter("@PQF02",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = model . HT04;
            parameter [ 1 ] . Value = model . HT02;
            SQLString . Add ( strSql ,parameter );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        public bool Edit ( MulaolaoLibrary . ContractreviewEntity model )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQL (HT02,HT03,HT04,HT08,HT09,HT10,HT11,HT12,HT18,HT20,HT21,HT23,HT25,HT26,HT28,HT30,HT32,HT34,HT35,HT37,HT39,HT40,HT42,HT44,HT45,HT47,HT49,HT51,HT52,HT55,HT58,HT59,HT60,HT61,HT62,HT63,HT64)" );
            strSql . Append ( " VALUES (@HT02,@HT03,@HT04,@HT08,@HT09,@HT10,@HT11,@HT12,@HT18,@HT20,@HT21,@HT23,@HT25,@HT26,@HT28,@HT30,@HT32,@HT34,@HT35,@HT37,@HT39,@HT40,@HT42,@HT44,@HT45,@HT47,@HT49,@HT51,@HT52,@HT55,@HT58,@HT59,@HT60,@HT61,@HT62,@HT63,@HT64)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@HT02", SqlDbType.NVarChar,20),
                    new SqlParameter("@HT03", SqlDbType.NVarChar,20),
                    new SqlParameter("@HT04", SqlDbType.Date,3),
                    new SqlParameter("@HT08", SqlDbType.VarBinary,-1),
                    new SqlParameter("@HT09", SqlDbType.NVarChar,10),
                    new SqlParameter("@HT10", SqlDbType.NVarChar,10),
                    new SqlParameter("@HT11", SqlDbType.NVarChar,10),
                    new SqlParameter("@HT12", SqlDbType.Date,3),
                    new SqlParameter("@HT18", SqlDbType.NVarChar,100),
                    new SqlParameter("@HT20", SqlDbType.NVarChar,100),
                    new SqlParameter("@HT21", SqlDbType.NVarChar,50),
                    new SqlParameter("@HT23", SqlDbType.NVarChar,100),
                    new SqlParameter("@HT25", SqlDbType.NVarChar,255),
                    new SqlParameter("@HT26", SqlDbType.NVarChar,50),
                    new SqlParameter("@HT28", SqlDbType.NVarChar,100),
                    new SqlParameter("@HT30", SqlDbType.NVarChar,100),
                    new SqlParameter("@HT32", SqlDbType.NVarChar,100),
                    new SqlParameter("@HT34", SqlDbType.NVarChar,100),
                    new SqlParameter("@HT35", SqlDbType.NVarChar,50),
                    new SqlParameter("@HT37", SqlDbType.NVarChar,100),
                    new SqlParameter("@HT39", SqlDbType.NVarChar,100),
                    new SqlParameter("@HT40", SqlDbType.NVarChar,50),
                    new SqlParameter("@HT42", SqlDbType.NVarChar,100),
                    new SqlParameter("@HT44", SqlDbType.NVarChar,100),
                    new SqlParameter("@HT45", SqlDbType.NVarChar,50),
                    new SqlParameter("@HT47", SqlDbType.NVarChar,100),
                    new SqlParameter("@HT49", SqlDbType.NVarChar,100),
                    new SqlParameter("@HT51", SqlDbType.NVarChar,100),
                    new SqlParameter("@HT52", SqlDbType.NVarChar,50),
                    new SqlParameter("@HT55", SqlDbType.NVarChar,255),
                    new SqlParameter("@HT58", SqlDbType.VarBinary,-1),
                    new SqlParameter("@HT59", SqlDbType.VarBinary,-1),
                    new SqlParameter("@HT60", SqlDbType.VarBinary,-1),
                    new SqlParameter("@HT61", SqlDbType.VarBinary,-1),
                    new SqlParameter("@HT62", SqlDbType.VarBinary,-1),
                    new SqlParameter("@HT63", SqlDbType.NVarChar,-1),
                    new SqlParameter("@HT64", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = model . HT02;
            parameters [ 1 ] . Value = model . HT03;
            parameters [ 2 ] . Value = model . HT04;
            parameters [ 3 ] . Value = model . HT08;
            parameters [ 4 ] . Value = model . HT09;
            parameters [ 5 ] . Value = model . HT10;
            parameters [ 6 ] . Value = model . HT11;
            parameters [ 7 ] . Value = model . HT12;
            parameters [ 8 ] . Value = model . HT18;
            parameters [ 9 ] . Value = model . HT20;
            parameters [ 10 ] . Value = model . HT21;
            parameters [ 11 ] . Value = model . HT23;
            parameters [ 12 ] . Value = model . HT25;
            parameters [ 13 ] . Value = model . HT26;
            parameters [ 14 ] . Value = model . HT28;
            parameters [ 15 ] . Value = model . HT30;
            parameters [ 16 ] . Value = model . HT32;
            parameters [ 17 ] . Value = model . HT34;
            parameters [ 18 ] . Value = model . HT35;
            parameters [ 19 ] . Value = model . HT37;
            parameters [ 20 ] . Value = model . HT39;
            parameters [ 21 ] . Value = model . HT40;
            parameters [ 22 ] . Value = model . HT42;
            parameters [ 23 ] . Value = model . HT44;
            parameters [ 24 ] . Value = model . HT45;
            parameters [ 25 ] . Value = model . HT47;
            parameters [ 26 ] . Value = model . HT49;
            parameters [ 27 ] . Value = model . HT51;
            parameters [ 28 ] . Value = model . HT52;
            parameters [ 29 ] . Value = model . HT55;
            parameters [ 30 ] . Value = model . HT58;
            parameters [ 31 ] . Value = model . HT59;
            parameters [ 32 ] . Value = model . HT60;
            parameters [ 33 ] . Value = model . HT61;
            parameters [ 34 ] . Value = model . HT62;
            parameters [ 35 ] . Value = model . HT63;
            parameters [ 36 ] . Value = model . HT64;
            SQLString . Add ( strSql ,parameters );
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQF SET PQF30=@PQF30 WHERE PQF02=@PQF02" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PQF30",SqlDbType.Date,3),
                new SqlParameter("@PQF02",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = model . HT04;
            parameter [ 1 ] . Value = model . HT02;
            SQLString . Add ( strSql ,parameter );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        public bool delete ( string oddNum ,string logins )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM R_PQL WHERE HT64='{0}'" ,oddNum );
            SQLString . Add ( strSql ,null );
            SQLString . Add ( Drity . DrityOfComparation ( "R_021" ,"合同评审表(R_021)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"取消删除" ) ,null );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        public bool saveTo ( DataTable table,string logins )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );

            MulaolaoLibrary . ContractreviewEntity _model = new MulaolaoLibrary . ContractreviewEntity ( );
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _model . HT01 = table . Rows [ i ] [ "PQF01" ] . ToString ( );
                _model . HT66 = table . Rows [ i ] [ "HT66" ] . ToString ( );

                if ( Exists ( _model . HT01 ) )
                {
                    strSql = new StringBuilder ( );
                    strSql . AppendFormat ( "UPDATE R_PQAE SET AE08='{0}' WHERE AE02='{1}'" ,_model . HT66 ,_model . HT01 );
                    SQLString . Add ( strSql . ToString ( ) );
                    SQLString . Add ( Drity . DrityOfComparation ( "R_021" ,"合同评审表(R_021)" ,logins ,Drity . GetDt ( ) ,_model . HT64 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"编辑" ,"编辑250生产车间" ) );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        bool Exists ( string num )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM R_PQAE WHERE AE02='{0}' " ,num );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        public bool Delete ( string oddNum ,string tableName ,string logins )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM R_PQL WHERE HT64='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_021" ,"合同评审表(R_021)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM R_REVIEWS WHERE RES01=(SELECT CX01 FROM R_MLLCXMC WHERE CX02='{0}') AND RES06='{1}'" ,tableName ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_021" ,"合同评审表(R_021)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除送审内容" ) );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        public bool Update ( MulaolaoLibrary . ContractreviewEntity _mode ,string logins )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE R_PQL SET HT01='{0}',HT07='{1}',HT65='{2}',HT66='{3}' WHERE idx={4}" ,_mode . HT01 ,_mode . HT07 ,_mode . HT65 ,_mode . HT66 ,_mode . idx );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_021" ,"合同评审表(R_021)" ,logins ,Drity . GetDt ( ) ,_mode . HT64 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"编辑" ,"编辑流水等" ) );
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE R_PQF SET PQF25='{0}',PQF17='{1}',PQF66='{2}' WHERE PQF01='{3}'" ,_mode . HT07 ,_mode . HT65 ,_mode . HT66 ,_mode . HT01 );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_021" ,"合同评审表(R_021)" ,logins ,Drity . GetDt ( ) ,_mode . HT64 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"编辑" ,"编辑流水等" ) );
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE R_PQAE SET AE08='{0}' WHERE AE02='{1}'" ,_mode . HT66 ,_mode . HT01 );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_021" ,"合同评审表(R_021)" ,logins ,Drity . GetDt ( ) ,_mode . HT64 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"编辑" ,"编辑流水等" ) );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        public bool Delete ( MulaolaoLibrary . ContractreviewEntity _mode ,string logins )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM R_PQL WHERE idx={0}" ,_mode . idx );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_021" ,"合同评审表(R_021)" ,logins ,Drity . GetDt ( ) ,_mode . HT64 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE R_PQF SET PQF25='{0}' WHERE PQF01='{1}'" ,_mode . HT07 ,_mode . HT01 );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_021" ,"合同评审表(R_021)" ,logins ,Drity . GetDt ( ) ,_mode . HT64 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除编辑001PQF25字段" ) );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        public bool Insert ( MulaolaoLibrary . ContractreviewEntity _mode ,string logins )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "INSERT INTO R_PQL (HT64,HT01,HT02,HT07,HT65,HT66) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')" ,_mode . HT64 ,_mode . HT01 ,_mode . HT02 ,_mode . HT07 ,_mode . HT65 ,_mode . HT66 );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_021" ,"合同评审表(R_021)" ,logins ,Drity . GetDt ( ) ,_mode . HT64 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新建" ,"新建" ) );
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE R_PQF SET PQF25='{0}',PQF17='{1}',PQF66='{2}' WHERE PQF01='{3}'" ,_mode . HT07 ,_mode . HT65 ,_mode . HT66 ,_mode . HT01 );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_021" ,"合同评审表(R_021)" ,logins ,Drity . GetDt ( ) ,_mode . HT64 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新建" ,"更改001生产车间" ) );
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE R_PQAE SET AE08='{0}'  WHERE AE02='{1}'" ,_mode . HT66 ,_mode . HT01 );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_021" ,"合同评审表(R_021)" ,logins ,Drity . GetDt ( ) ,_mode . HT64 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新建" ,"更改001生产车间" ) );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        public bool ExistsNum ( string num )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM R_PQL WHERE HT01='{0}'" ,num );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        public DataTable getTableView (string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT B.idx,PQF01 ,PQF03 ,PQF04 ,PQF05 ,PQF06 ,PQF07 ,PQF08 ,PQF09 ,PQF31 ,HT07,HT65,HT66  FROM R_PQF A,R_PQL B WHERE A.PQF01=B.HT01 AND HT64='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }


        /// <summary>
        /// get max oddNum from r_pqdJ
        /// </summary>
        /// <returns></returns>
        public string getOddNum ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(HT64) HT64 FROM R_PQL " );
            strSql . AppendFormat ( "WHERE HT64 LIKE 'R_021-{0}%'" ,Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                string oddNum = dt . Rows [ 0 ] [ "HT64" ] . ToString ( );
                if ( string . IsNullOrEmpty ( oddNum ) )
                    return "R_021-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "0001";
                else
                {
                    oddNum = "R_021-" + ( Convert . ToInt64 ( oddNum . Substring ( 6 ,12 ) ) + 1 ) . ToString ( );
                    return oddNum;
                }
            }
            else
                return "R_021-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "0001";
        }

        /// <summary>
        /// 获取列数据
        /// </summary>
        /// <returns></returns>
        public DataTable getTableOnly ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT PQF01,PQF04,HT02,HT66,PQF67 FROM R_PQL A,R_PQF B,TPADFA C WHERE A.HT01=B.PQF01 AND B.PQF11=C.DFA001" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取列数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "WITH CET AS (SELECT PQF01,PQF04,HT64,HT02,HT03,HT04,DFA003,DFA015,DFA016,(SELECT RES05 FROM R_REVIEWS WHERE RES04=(SELECT MAX(RES04) FROM R_REVIEWS WHERE RES06=HT64)) RES05,HT66,PQF31,PQF32,PQF67 FROM R_PQL A LEFT JOIN R_PQF B ON  A.HT01=B.PQF01 LEFT JOIN TPADFA C ON B.PQF11=C.DFA001 WHERE {0} )" ,strWhere );
            strSql . AppendFormat ( " SELECT COUNT(1) FROM CET " );

            object obj = SqlHelper . GetSingle ( strSql . ToString ( ) );
            if ( obj == null )
                return 0;
            else
                return Convert . ToInt32 ( obj );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTableByChange ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "WITH CET AS (SELECT PQF01,PQF04,HT64,HT02,HT03,HT04,DFA003,DFA015,DFA016,(SELECT RES05 FROM R_REVIEWS WHERE RES04=(SELECT MAX(RES04) FROM R_REVIEWS WHERE RES06=HT64)) RES05,HT66,PQF31,PQF32,PQF67 FROM R_PQL A LEFT JOIN R_PQF B ON  A.HT01=B.PQF01 LEFT JOIN TPADFA C ON B.PQF11=C.DFA001 WHERE {0} ) " ,strWhere );
            strSql . Append ( "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY T.PQF01) AS ROW,T.* FROM CET T) TT " );
            strSql . AppendFormat ( " WHERE TT.ROW BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    } 
}

using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using StudentMgr;
using System . Data;
using System . Threading . Tasks;

namespace MulaolaoBll . Dao
{
    public class shenchanjindujihuaReportDao
    {
        /// <summary>
        /// get table to view 
        /// </summary>
        /// <returns></returns>
        public DataTable getTableToView (   )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "WITH CHT AS(SELECT AE02 FROM R_PQAE WHERE AE02 NOT IN (SELECT AE02 FROM R_PQAE WHERE AE21 IS NOT NULL))," );
            strSql . AppendFormat ( " CET AS (SELECT idx,PQX01,PQX29,PQX31,PQX16,PQX15,PQX36,DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 + PQX16 - PQX18 U1,ISNULL(U2,0) U2,ISNULL(U4,0) U4 ,PQX32,ISNULL((SELECT ISNULL(GZ25,0)+ISNULL(GZ26,0) GZ FROM R_PQW WHERE idx IN (SELECT MAX(B.idx) ID FROM R_PQW B WHERE A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND ISNULL(GZ25,0)+ISNULL(GZ26,0)!=0 GROUP BY GZ03,GZ04)),0) PQX24,PQX14,PQX21,(SELECT ISNULL(SUM(GZ25+GZ26),0) GZ FROM R_PQW B WHERE A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND CONVERT(DATE,GETDATE(),23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)))PQX34,ISNULL(U12,0) U12,ISNULL(U14,0) U14,ISNULL(U29,0) U29,ISNULL(U9,0) U9 FROM R_PQX A WHERE (U4<=-3 OR U2<=-3) AND PQX14 IS NOT NULL AND PQX14 != '' AND PQX01 IN (SELECT AE02 FROM CHT))" );
            strSql . AppendFormat ( ",CFT AS (SELECT PQX01,PQX14,MIN(PQX16) PQX16 FROM R_PQX WHERE U2<=-3 AND PQX01 IN (SELECT AE02 FROM CHT) GROUP BY PQX01,PQX14 "  );
            strSql . AppendFormat ( "UNION SELECT PQX01,PQX14,MIN(PQX16) PQX16 FROM R_PQX WHERE U4<=-3 AND PQX01 IN (SELECT AE02 FROM CHT) GROUP BY PQX01,PQX14)"  );
            strSql . AppendFormat ( "SELECT B.PQX01,PQX29,PQX31,B.PQX14,PQX15,B.PQX16,U29,U2,U4,U12,CASE WHEN PQX32*PQX36-PQX34<=0 THEN 0 ELSE CASE WHEN PQX24-U9>0 THEN 0 ELSE PQX24-U9 END END U8,CASE WHEN U1!=0 THEN U14/U1 ELSE 0 END U15,U14,B.PQX21 FROM CET B INNER JOIN CFT A ON B.PQX01=A.PQX01 AND B.PQX14=A.PQX14 AND B.PQX16=A.PQX16  ORDER BY U2,U4,A.PQX01" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get table of only column
        /// </summary>
        /// <returns></returns>
        public DataTable getTableOfPro ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT PQX01,PQX29,PQX31,PQX14,PQX15,PQX21 FROM R_PQX WHERE U4<=-3 OR U2<=-3" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        public string Calcu ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            //获取250未发货的产品
            strSql . Append ( "SELECT DISTINCT PQX33,PQX01 FROM R_PQX WHERE PQX01 IN (SELECT AE02 FROM R_PQAE WHERE AE02 NOT IN (SELECT AE02 FROM R_PQAE WHERE AE21 IS NOT NULL)) " );
            DataTable table = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( table == null || table . Rows . Count < 1 )
                return string . Empty;
            string nunCount = string . Empty, oddNum = string . Empty;
            DateTime dt = MulaolaoBll . Drity . GetDt ( );
            foreach ( DataRow row in table . Rows )
            {
                nunCount = row [ "PQX01" ] . ToString ( );
                oddNum = row [ "PQX33" ] . ToString ( );
                EditPQX34 ( nunCount ,oddNum );
                EditToOtherColumn ( nunCount ,oddNum ,dt );
                EditToOtherColumnForU2 ( nunCount ,oddNum ,dt );
                EditToOtherColumnForU14 ( nunCount ,oddNum ,dt );
                EditToOtherColounForU12 ( nunCount ,oddNum );
                EditToOtherColumnForU29 ( nunCount ,oddNum ,dt );
                EditToOtherColumnForU9 ( nunCount ,oddNum );
            }
            return string . Empty;
        }

        /// <summary>
        /// 编辑累计部件量=累计部件量+当日生产量（流水，单号，来源，PQX39(当日生产量的日期)）
        /// </summary>
        /// <param name="numCount"></param>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public int EditPQX34 ( string numCount ,string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            //strSql . AppendFormat ( "UPDATE R_PQX SET PQX34=ISNULL(PQX34,0)+ISNULL(PQX24,0),PQX24=0 WHERE PQX01 IN ({0}) AND PQX33='{1}' AND PQX38 IN ('采购','承揽','委外') AND CONVERT(VARCHAR,PQX39,112)!=CONVERT(VARCHAR,GETDATE(),112)" ,numCount ,oddNum );
            strSql . AppendFormat ( "UPDATE R_PQX SET PQX24=0 WHERE PQX01 IN ({0}) AND PQX33='{1}' AND CONVERT(VARCHAR,PQX39,112)!=CONVERT(VARCHAR,GETDATE(),112)" ,numCount ,oddNum );//AND PQX38 IN ('采购','承揽','委外') PQX34=ISNULL(PQX34,0)+ISNULL(PQX24,0),

            return SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 当(工序实投产日期)显示≥(工序计划投产日期)时(欠投产天数)栏位开始计数直到(日产部件量)栏位有数值读入时静止计数[(欠投产天数)该栏位的负数值就是该工序的延误投产天数]
        /// </summary>
        /// <param name="num">流水号</param>
        /// <param name="oddNum">单号</param>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public bool EditToOtherColumn ( string num ,string oddNum ,DateTime dt )
        {
            //存储过程:pqxu4
            /*
             EXEC pqxu4
            '17070230',
            'R_046-20170906002',
            '2017/11/22'
             */
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DECLARE @idx INT;" );
            strSql . Append ( "DECLARE @u4 INT;" );
            strSql . Append ( "DECLARE @pqx24 INT;" );
            strSql . Append ( "DECLARE CUR CURSOR FOR " );
            strSql . Append ( "WITH CET AS(" );
            strSql . AppendFormat ( "SELECT A.idx,DATEDIFF(DAY,CONVERT(DATE,'{2}',121),PQX25) U4,PQX24+ISNULL((SELECT ISNULL(GZ25,0)+ISNULL(GZ26,0) GZ FROM R_PQW WHERE idx IN (SELECT MAX(B.idx) ID FROM R_PQW B WHERE B.GZ01 IN ({0}) AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND ISNULL(GZ25,0)+ISNULL(GZ26,0)!=0 GROUP BY GZ03,GZ04)),0) PQX24 FROM R_PQX A WHERE PQX33='{1}' AND PQX14 IS NOT NULL AND PQX14 != '') " ,num ,oddNum ,dt );
            //strSql . Append ( "SELECT idx,CASE WHEN PQX24>0 THEN 0 WHEN U4<0 THEN 0 ELSE U4 END U4 FROM CET " );
            strSql . Append ( "SELECT idx,CASE WHEN U4>0 THEN 0 ELSE U4 END U4,PQX24 FROM CET " );
            strSql . Append ( "OPEN CUR " );
            strSql . Append ( "FETCH NEXT FROM CUR INTO @idx,@u4,@pqx24 " );
            strSql . Append ( "WHILE @@FETCH_STATUS=0 " );
            strSql . Append ( "BEGIN " );
            //strSql . Append ( "IF (@u4>=0 AND @pqx24<0)" );
            strSql . Append ( "IF (@u4<=0 AND @pqx24<=0) " );
            strSql . Append ( "UPDATE R_PQX SET U4=@u4 WHERE idx=@idx " );
            strSql . Append ( "FETCH NEXT FROM CUR INTO @idx,@u4,@pqx24  " );
            strSql . Append ( "END " );
            strSql . Append ( "CLOSE CUR " );
            strSql . Append ( "DEALLOCATE CUR" );

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( rows > 0 )
                return true;
            else
                return false;

            //SqlHelper . StoreProcedure ( "pqxu4" );
            //SqlParameter [ ] parameter = {
            //    new SqlParameter("@numCount",SqlDbType.NVarChar,200),
            //    new SqlParameter("@oddNum",SqlDbType.NVarChar,20),
            //    new SqlParameter("@dateTime",SqlDbType.DateTime)
            //};
            //parameter [ 0 ] . Value = num;
            //parameter [ 1 ] . Value = oddNum;
            //parameter [ 2 ] . Value = dt;

            // SqlHelper . ExecuteNoStore ( parameter );
            //if ( dl != null && dl . Rows . Count > 0 )
            //    return true;
            //else
            //    return false;
        }

        /// <summary>
        /// (工序实投产日期)显示>(工序计划投产日期)或(日产部件量)栏位大于0时(工序实产周期)栏位开始计数直到(还要生产部件)栏位值0≦时(工序实产周期)栏位静止计数[(工序实产周期)该栏位的负数值就是该工序的延迟交期天数]
        /// </summary>
        /// <param name="num">流水号</param>
        /// <param name="oddNum">单号</param>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>        
        public bool EditToOtherColumnForU2 ( string num ,string oddNum ,DateTime dt )
        {
            //存储过程:U2
            /*
             EXEC pqxu2
            '17070230',
            'R_046-20170906002',
            '2017/11/22'
             */
            StringBuilder strSql = new StringBuilder ( );
            //strSql . AppendFormat ( "UPDATE R_PQX SET U2=0 WHERE PQX33='{0}' " ,oddNum );
            strSql . Append ( "DECLARE @idx INT; " );
            strSql . Append ( "DECLARE @u2 INT;" );
            strSql . Append ( "DECLARE @pqx24 INT;" );
            strSql . Append ( "DECLARE @u4 INT;" );
            strSql . Append ( "DECLARE @pqx34 INT;" );
            strSql . Append ( "DECLARE CUR CURSOR FOR " );
            strSql . Append ( "WITH CET AS( " );
            //strSql . AppendFormat ( "SELECT A.idx,PQX32,PQX36,DATEDIFF(DAY,PQX25,CONVERT(DATE,'{2}',121)) U4,CASE WHEN PQX38='委外' OR PQX38='采购' OR PQX38='承揽' THEN 0 ELSE  ISNULL((SELECT ISNULL(GZ25,0)+ISNULL(GZ26,0) GZ FROM R_PQW WHERE idx IN (SELECT MAX(B.idx) ID FROM R_PQW B WHERE B.GZ01 IN ({0}) AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND ISNULL(GZ25,0)+ISNULL(GZ26,0)!=0 GROUP BY GZ03,GZ04)),0) END PQX24,DATEDIFF( DAY ,CONVERT(DATE,'{2}',121) ,PQX30 )-PQX19 + PQX16 - PQX18 U2,CASE WHEN PQX38='委外' OR PQX38='采购' OR PQX38='承揽' THEN PQX32*PQX36-PQX34 ELSE PQX32*PQX36-(SELECT ISNULL(SUM(GZ25+GZ26),0) GZ FROM R_PQW B WHERE B.GZ01 IN ({0}) AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND CONVERT(DATE,'{2}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17))) END PQX34 FROM R_PQX A WHERE PQX33='{1}' AND PQX14 IS NOT NULL AND PQX14 != '' )  " ,num ,oddNum ,dt );
            strSql . AppendFormat ( "SELECT A.idx,PQX32,PQX36,DATEDIFF(DAY,PQX25,CONVERT(DATE,'{2}',121)) U4,ISNULL((SELECT ISNULL(GZ25,0)+ISNULL(GZ26,0) GZ FROM R_PQW WHERE idx IN (SELECT MAX(B.idx) ID FROM R_PQW B WHERE B.GZ01 IN ({0}) AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND ISNULL(GZ25,0)+ISNULL(GZ26,0)!=0 GROUP BY GZ03,GZ04)),0)+PQX24 PQX24,DATEDIFF( DAY ,CONVERT(DATE,'{2}',121) ,PQX30 )-PQX19 + PQX16 - PQX18 U2,PQX32*PQX36-(SELECT ISNULL(SUM(GZ25+GZ26),0) GZ FROM R_PQW B WHERE B.GZ01 IN ({0}) AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND CONVERT(DATE,'{2}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)))-PQX34 PQX34 FROM R_PQX A WHERE PQX33='{1}' AND PQX14 IS NOT NULL AND PQX14 != '' )  " ,num ,oddNum ,dt );
            strSql . Append ( "SELECT idx,U2,U4,PQX24,PQX34 FROM CET WHERE PQX34>0 " );//WHERE (PQX24>=0 OR U4<=0) AND PQX32*PQX36-PQX34>=0
            strSql . Append ( "OPEN CUR " );
            strSql . Append ( "FETCH NEXT FROM CUR INTO @idx,@u2,@u4,@pqx24,@pqx34 " );
            strSql . Append ( "WHILE @@FETCH_STATUS=0 " );
            strSql . Append ( "BEGIN " );
            //2018-7-17 18050150流水  检验工序
            strSql . Append ( "IF((@u4>0 OR @pqx24>0) AND @pqx34>0) " );
            //strSql . Append ( "IF(@u4>=0 OR @pqx24>0) " );
            //2018-7-17 18050150流水  检验工序
            //strSql . Append ( "IF @u4>=0 " );
            strSql . Append ( "UPDATE R_PQX SET U2=@u2 WHERE idx=@idx " );
            strSql . Append ( "FETCH NEXT FROM CUR INTO @idx,@u2,@u4,@pqx24,@pqx34 " );
            strSql . Append ( "END " );
            strSql . Append ( "CLOSE CUR " );
            strSql . Append ( "DEALLOCATE CUR " );

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( rows > 0 )
                return true;
            else
                return false;


            //SqlHelper . StoreProcedure ( "pqxu2" );
            //SqlParameter [ ] parameter = {
            //    new SqlParameter("@numCount",num),
            //    new SqlParameter("@oddNum",oddNum),
            //    new SqlParameter("@dateTime",dt)
            //};

            //DataTable dl = SqlHelper . ExecuteDataTableStore ( parameter );
            //if ( dl != null && dl . Rows . Count > 0 )
            //    return true;
            //else
            //    return false;
        }

        /// <summary>
        /// (累欠产量)=(当日欠产量)+前面的累欠产量    注:和(累计已生产量)计算方法相同 
        /// </summary>
        /// <param name="num">流水号</param>
        /// <param name="oddNum">单号</param>
        /// <param name="strWhere">条件</param>
        /// <param name="dt">日期</param>
        /// <returns></returns>
        public bool EditToOtherColumnForU14 ( string num ,string oddNum ,DateTime dt )
        {
            //存储过程:pqxu14
            /*
             EXEC pqxu14
            '17070230',
            'R_046-20170906002',
            '2017/11/22'
             */
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE R_PQX SET U14=0 WHERE PQX33='{0}'" ,oddNum );
            strSql . Append ( "DECLARE @u14 INT;DECLARE @idx INT;DECLARE CUR CURSOR FOR " );
            strSql . Append ( "WITH CET AS (" );
            strSql . AppendFormat ( "SELECT PQX24+ISNULL((SELECT SUM(ISNULL(GZ25,0)+ISNULL(GZ26,0)) GZ FROM R_PQW WHERE idx IN (SELECT B.idx FROM R_PQW B WHERE B.GZ01 IN ({0}) AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND ISNULL(GZ25,0)+ISNULL(GZ26,0)!=0 AND CONVERT(DATE,CONVERT(VARCHAR,GZ35)+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17),102)<='{1}') ),0) PQX24,PQX32,(SELECT ISNULL(SUM(GZ25+GZ26),0) GZ FROM R_PQW B WHERE B.GZ01 IN ({0}) AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND CONVERT(DATE,GETDATE(),23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)))+PQX34 PQX34,PQX36,U2,A.idx FROM R_PQX A WHERE 1=1 AND PQX33='{2}' AND PQX14 IS NOT NULL AND PQX14 != '') " ,num ,dt ,oddNum );
            strSql . Append ( "SELECT SUM(CASE WHEN U2=0 THEN PQX24 WHEN PQX32*PQX36-PQX34<=0 THEN PQX24 ELSE PQX24-(PQX32*PQX36-PQX34)/U2 END) U,idx FROM CET GROUP BY idx " );
            strSql . Append ( "OPEN CUR " );
            strSql . Append ( "FETCH NEXT FROM CUR INTO @u14,@idx " );
            strSql . Append ( "WHILE @@FETCH_STATUS=0 " );
            strSql . Append ( "BEGIN " );
            strSql . Append ( "IF (@u14<=0)" );
            strSql . Append ( "UPDATE R_PQX SET U14=@u14 WHERE idx=@idx " );
            strSql . Append ( "FETCH NEXT FROM CUR INTO @u14,@idx " );
            strSql . Append ( "END " );
            strSql . Append ( "CLOSE CUR " );
            strSql . Append ( "DEALLOCATE CUR " );

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( rows > 0 )
                return true;
            else
                return false;

            //SqlHelper . StoreProcedure ( "pqxu14" );
            //SqlParameter [ ] parameter = {
            //    new SqlParameter("@numCount",num),
            //    new SqlParameter("@oddNum",oddNum),
            //    new SqlParameter("@dateTime",dt)
            //};

            //DataTable dl = SqlHelper . ExecuteDataTableStore ( parameter );
            //if ( dl != null && dl . Rows . Count > 0 )
            //    return true;
            //else
            //    return false;

        }

        /// <summary>
        /// (工序积压亏损数量)=(累已产部件量)下道工序(栏位)减上道工序(栏位)
        /// </summary>
        /// <param name="num">流水号</param>
        /// <param name="oddNum">单号</param>
        /// <returns></returns>
        public bool EditToOtherColounForU12 ( string num ,string oddNum )
        {
            //存储过程:pqxu12
            /*
             EXEC pqxu12
            '17070230',
            'R_046-20170906002'
             */

            //SqlHelper . StoreProcedure ( "pqxu12" );
            //SqlParameter [ ] parameter = {
            //    new SqlParameter("@numCount",num),
            //    new SqlParameter("@oddNum",oddNum)
            //};

            //DataTable dl = SqlHelper . ExecuteDataTableStore ( parameter );
            //if ( dl != null && dl . Rows . Count > 0 )
            //    return true;
            //else
            //    return false;

            StringBuilder strSql = new StringBuilder ( );
            //strSql . AppendFormat ( "UPDATE R_PQX SET U12=0 WHERE PQX33='{0}' " ,oddNum );
            //strSql . Append ( "DECLARE @idx INT;DECLARE @u12 INT;DECLARE @pqx17 NVARCHAR(20); " );
            //strSql . Append ( "DECLARE CUS CURSOR FOR " );
            //strSql . AppendFormat ( "SELECT DISTINCT PQX17 FROM R_PQX WHERE PQX33='{0}' AND PQX14 IS NOT NULL AND PQX14 != '' " ,oddNum );
            //strSql . Append ( "OPEN CUS " );
            //strSql . Append ( "FETCH NEXT FROM CUS INTO @pqx17 " );
            //strSql . Append ( "WHILE @@FETCH_STATUS=0 " );
            //strSql . Append ( "BEGIN " );
            //strSql . Append ( "DECLARE CUR CURSOR FOR " );
            //strSql . AppendFormat ( "WITH CET AS(SELECT idx,PQX13,PQX16,PQX17,(SELECT ISNULL(SUM(GZ25+GZ26),0) GZ FROM R_PQW B WHERE B.GZ01 IN ({0}) AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND CONVERT(DATE,GETDATE(),23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)) ) PQX34 FROM R_PQX A WHERE PQX33='{1}' AND PQX14 IS NOT NULL AND PQX14 != '') " ,num ,oddNum );
            //strSql . Append ( "SELECT idx,PQX34-ISNULL((SELECT TOP 1 PQX34 FROM CET T2 WHERE T2.PQX16<T1.PQX16 AND PQX17=@pqx17 ORDER BY PQX16 DESC ),0) U12 FROM CET T1 WHERE PQX17=@pqx17 " );
            //strSql . Append ( "OPEN CUR " );
            //strSql . Append ( "FETCH NEXT FROM CUR INTO @idx,@u12 " );
            //strSql . Append ( "WHILE @@FETCH_STATUS=0 " );
            //strSql . Append ( "BEGIN " );
            //strSql . Append ( "IF(@u12<0) " );
            //strSql . Append ( "UPDATE R_PQX SET U12=@u12 WHERE idx=@idx " );
            //strSql . Append ( "FETCH NEXT FROM CUR INTO @idx,@u12 " );
            //strSql . Append ( "END " );
            //strSql . Append ( "CLOSE CUR " );
            //strSql . Append ( "DEALLOCATE CUR " );
            //strSql . Append ( "FETCH NEXT FROM CUS INTO @pqx17 " );
            //strSql . Append ( "END " );
            //strSql . Append ( "CLOSE CUS " );
            //strSql . Append ( "DEALLOCATE CUS " );


            strSql . AppendFormat ( "UPDATE R_PQX SET U12=0 WHERE PQX33='{0}' " ,oddNum );
            strSql . Append ( "DECLARE @idx INT;DECLARE @u12 INT;DECLARE @pqx16 NVARCHAR(20);DECLARE @pqx17 NVARCHAR(20); " );
            strSql . Append ( "DECLARE CUS CURSOR FOR " );
            strSql . AppendFormat ( "SELECT DISTINCT PQX17 FROM R_PQX WHERE PQX33='{0}' AND PQX14 IS NOT NULL AND PQX14 != '' " ,oddNum );
            strSql . Append ( "OPEN CUS " );
            strSql . Append ( "FETCH NEXT FROM CUS INTO @pqx17 " );
            strSql . Append ( "WHILE @@FETCH_STATUS=0 " );
            strSql . Append ( "BEGIN " );
            strSql . Append ( "DECLARE CUR CURSOR FOR " );
            strSql . AppendFormat ( "WITH CET AS(SELECT idx,PQX13,PQX16,PQX17,(SELECT ISNULL(SUM(GZ25+GZ26),0) GZ FROM R_PQW B WHERE B.GZ01 IN ({0}) AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND CONVERT(DATE,GETDATE(),23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)) )+PQX34 PQX34 FROM R_PQX A WHERE PQX33='{1}' AND PQX14 IS NOT NULL AND PQX14 != '' and PQX17=@pqx17) " ,num ,oddNum );
            strSql . Append ( "SELECT idx,PQX16,PQX17,PQX34-ISNULL((SELECT TOP 1 PQX34 FROM CET T2 WHERE T2.PQX16>T1.PQX16 AND PQX17=@pqx17 ORDER BY PQX16 ASC ),0) U12 FROM CET T1 WHERE PQX17=@pqx17 ORDER BY PQX16 " );
            strSql . Append ( "OPEN CUR " );
            strSql . Append ( "FETCH NEXT FROM CUR INTO @idx,@pqx16,@pqx17,@u12 " );
            strSql . Append ( "WHILE @@FETCH_STATUS=0 " );
            strSql . Append ( "BEGIN " );
            //strSql . Append ( "IF(@u12<0) " );
            strSql . AppendFormat ( "UPDATE R_PQX SET U12=@u12 WHERE PQX16=(SELECT MIN(PQX16) PQX16 FROM R_PQX WHERE PQX33='{0}' AND PQX17=@pqx17 AND PQX16>@pqx16) AND PQX33='{0}' AND PQX17=@pqx17  " ,oddNum );
            strSql . Append ( "FETCH NEXT FROM CUR INTO @idx,@pqx16,@pqx17,@u12 " );
            strSql . Append ( "END " );
            strSql . Append ( "CLOSE CUR " );
            strSql . Append ( "DEALLOCATE CUR " );
            strSql . Append ( "FETCH NEXT FROM CUS INTO @pqx17 " );
            strSql . Append ( "END " );
            strSql . Append ( "CLOSE CUS " );
            strSql . Append ( "DEALLOCATE CUS " );

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// (日产部件量差)改(R317读入次数)=从R317每读入1次就累加1次
        /// </summary>
        /// <param name="num">流水号</param>
        /// <param name="oddNum">单号</param>
        /// <param name="dt">日期</param>
        /// <returns></returns>
        public bool EditToOtherColumnForU29 ( string num ,string oddNum ,DateTime dt )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE R_PQX SET U29=0 WHERE PQX33='{0}' " ,oddNum );
            strSql . Append ( "DECLARE @idx INT;DECLARE @coun INT; DECLARE CUR CURSOR FOR " );
            strSql . Append ( "WITH CET AS ( " );
            strSql . AppendFormat ( "SELECT GZ03,GZ04,CONVERT(VARCHAR,GZ35)+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17) GZ FROM R_PQW WHERE GZ01 IN ({0}) AND CONVERT(DATE,'{1}',23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17)) GROUP BY GZ03,GZ04,GZ35,GZ24,GZ17) " ,num ,dt );
            strSql . AppendFormat ( "SELECT A.idx,COUNT(B.GZ) COUN FROM R_PQX A INNER JOIN CET B ON A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 WHERE PQX33='{0}' AND PQX14 IS NOT NULL AND PQX14 != '' GROUP BY A.idx " ,oddNum );
            strSql . Append ( "OPEN CUR " );
            strSql . Append ( "FETCH NEXT FROM CUR INTO @idx,@coun " );
            strSql . Append ( "WHILE @@FETCH_STATUS=0 " );
            strSql . Append ( "BEGIN " );
            strSql . Append ( "UPDATE R_PQX SET U29=@coun WHERE idx=@idx " );
            strSql . Append ( "FETCH NEXT FROM CUR INTO @idx,@coun " );
            strSql . Append ( "END " );
            strSql . Append ( "CLOSE CUR " );
            strSql . Append ( "DEALLOCATE CUR " );

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( rows > 0 )
                return true;
            else
                return false;

        }

        /// <summary>
        /// 调整日产部件  工序实产周期大于等于1时计算，否则不变，  还要生产部件等于零时为零
        /// </summary>
        /// <param name="num"></param>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool EditToOtherColumnForU9 ( string num ,string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DECLARE @idx INT;" );
            strSql . Append ( "DECLARE @U2 INT;" );
            strSql . Append ( "DECLARE @U9 INT;" );
            strSql . Append ( "DECLARE CUR CURSOR FOR " );
            strSql . AppendFormat ( "WITH CET AS(SELECT A.idx,PQX32,PQX36,PQX34+(SELECT ISNULL(SUM(GZ25+GZ26),0) GZ FROM R_PQW B WHERE B.GZ01 IN ({0}) AND A.PQX14=B.GZ03 AND A.PQX15=B.GZ04 AND CONVERT(DATE,GETDATE(),23)>=CONVERT(DATE,GZ35+'-'+CONVERT(VARCHAR,GZ24)+'-'+CONVERT(VARCHAR,GZ17))) PQX34,U2 FROM R_PQX A WHERE PQX33='{1}') " ,num ,oddNum );
            strSql . Append ( "SELECT idx,CASE WHEN PQX32*PQX36-PQX34=0 THEN 0 WHEN U2=0 THEN 0 ELSE CONVERT(DECIMAL(18,0),(PQX32*PQX36-PQX34)/U2) END U9,U2 FROM CET WHERE U2>=1 " );
            strSql . Append ( "OPEN CUR " );
            strSql . Append ( "FETCH NEXT FROM CUR INTO @idx,@U9,@U2 " );
            strSql . Append ( "WHILE @@FETCH_STATUS=0 " );
            strSql . Append ( "BEGIN " );
            strSql . Append ( "UPDATE R_PQX SET U9=@U9 WHERE idx=@idx " );
            strSql . Append ( "FETCH NEXT FROM CUR INTO @idx,@U9,@U2 " );
            strSql . Append ( "END " );
            strSql . Append ( "CLOSE CUR " );
            strSql . Append ( "DEALLOCATE CUR " );
            strSql . Append ( "UPDATE R_PQX SET U9=0 WHERE ISNULL(U9,0)<0" );

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( rows > 0 )
                return true;
            else
                return false;
        }



    }
}

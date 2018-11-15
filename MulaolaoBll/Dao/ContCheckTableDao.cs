using System . Text;
using StudentMgr;
using System . Data;
using System . Collections;
using System;
using System . Data . SqlClient;

namespace MulaolaoBll . Dao
{
    public class ContCheckTableDao
    {
        /// <summary>
        /// 获取所有的采购合同执行未结账
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable getTable ( int year ,bool state ,string tableNum )
        {
            StringBuilder strSql = new StringBuilder ( );

            if ( tableNum == string . Empty )
                tableNum = "R_195,R_196,R_199,R_338,R_337,R_339,R_341,R_342,R_343,R_344,R_347,R_349,R_495,R_505";


            strSql . Append ( "WITH CET AS (" );
            if ( tableNum . Contains ( "R_195" ) )
            {
                strSql . Append ( "SELECT CP03,CP01,CONVERT(NVARCHAR,RES04,102) RES04,CASE WHEN AK014='' OR AK014 IS NULL THEN '未结' ELSE '已结' END AK,CONVERT(DECIMAL(11,2),SUM(CASE WHEN CP10=0 THEN CP11*CP13*CP54-CP12 WHEN CP11=0 THEN CP10*CP13*CP54-CP12 ELSE CP10*CP13*CP54-CP12 END)) U2 FROM R_PQQ A LEFT JOIN R_REVIEWS B ON A.CP03=B.RES06 LEFT JOIN R_PQAK C ON A.CP03=C.AK003 WHERE RES05='执行' " );
                if ( year > 0 )
                    strSql . AppendFormat ( " AND YEAR(RES04)={0} " ,year );
                strSql . Append ( " GROUP BY CP03,CP01,RES04,AK014 " );
                //strSql . Append ( "UNION ALL " );
            }
            if ( tableNum . Contains ( "R_196" ) )
            {
                if ( strSql . ToString ( ) . Contains ( "SELECT" ) )
                    strSql . Append ( " UNION " );
                strSql . Append ( "SELECT AH97 CP03,AH01 CP01,CONVERT(NVARCHAR,RES04,102) RES04,CASE WHEN AK014='' OR AK014 IS NULL THEN '未结' ELSE '已结' END AK,CONVERT(DECIMAL(11,2),SUM(AH16*AH101*AH13*AH14)) U2 FROM R_PQAH A LEFT JOIN R_REVIEWS B ON A.AH97=B.RES06 LEFT JOIN R_PQAK C ON A.AH97=C.AK003 WHERE RES05='执行' " );
                if ( year > 0 )
                    strSql . AppendFormat ( " AND YEAR(RES04)={0}  " ,year );
                //strSql . Append ( "UNION ALL " );
                strSql . Append ( " GROUP BY AH97,AH01,RES04,AK014" );
            }
            if ( tableNum . Contains ( "R_199" ) )
            {
                if ( strSql . ToString ( ) . Contains ( "SELECT" ) )
                    strSql . Append ( " UNION " );
                strSql . Append ( "SELECT BA003 CP03,BA001 CP01,CONVERT(NVARCHAR,RES04,102) RES04,CASE WHEN AK014='' OR AK014 IS NULL THEN '未结' ELSE '已结' END AK,CONVERT(DECIMAL(11,2),SUM(BA013*BA054)) U2 FROM R_PQBA A LEFT JOIN R_REVIEWS B ON A.BA003=B.RES06 LEFT JOIN R_PQAK C ON A.BA003=C.AK003 WHERE RES05='执行' " );
                if ( year > 0 )
                    strSql . AppendFormat ( " AND YEAR(RES04)={0} " ,year );
                //strSql . Append ( "UNION ALL " );
                strSql . Append ( " GROUP BY BA003,BA001,RES04,AK014 " );
            }
            if ( tableNum . Contains ( "R_338" ) )
            {
                if ( strSql . ToString ( ) . Contains ( "SELECT" ) )
                    strSql . Append ( " UNION " );
                strSql . Append ( "SELECT JM01 CP03,JM90 CP01,CONVERT(NVARCHAR,RES04,102) RES04,CASE WHEN AK014='' OR AK014 IS NULL THEN '未结' ELSE '已结' END AK,CONVERT(DECIMAL(11,2),SUM(CASE WHEN JM10=0 THEN 0 ELSE JM103/JM10*JM11 END)) U2 FROM R_PQO A LEFT JOIN R_REVIEWS B ON A.JM01=B.RES06 LEFT JOIN R_PQAK C ON A.JM01=C.AK003 WHERE RES05='执行' AND JM14='外购' " );
                if ( year > 0 )
                    strSql . AppendFormat ( " AND YEAR(RES04)={0} " ,year );
                //strSql . Append ( "UNION ALL " );
                strSql . Append ( " GROUP BY JM01,JM90,RES04,AK014" );
            }
            if ( tableNum . Contains ( "R_337" ) || tableNum . Contains ( "R_339" ) )
            {
                if ( strSql . ToString ( ) . Contains ( "SELECT" ) )
                    strSql . Append ( " UNION " );
                strSql . Append ( "SELECT YQ99 CP03,YQ03 CP01,CONVERT(NVARCHAR,RES04,102) RES04,CASE WHEN AK014='' OR AK014 IS NULL THEN '未结' ELSE '已结' END AK,CASE WHEN YQ99 LIKE 'R_337%' THEN CONVERT(DECIMAL(11,2),SUM(YQ109*YQ15)) ELSE CONVERT(DECIMAL(11,2),SUM(YQ16*YQ108*YQ112*YQ114*YQ115*YQ116*YQ113*YQ13*0.0001*0.01+YQ108*YQ112*YQ116*YQ113*YQ13*YQ14*0.01/YQ114/YQ115)) END U2 FROM R_PQI A LEFT JOIN R_REVIEWS B ON A.YQ99=B.RES06 LEFT JOIN R_PQAK C ON A.YQ99=C.AK003 WHERE RES05='执行'  " );
                if ( year > 0 )
                    strSql . AppendFormat ( " AND YEAR(RES04)={0} " ,year );
                //strSql . Append ( "UNION ALL " );
                strSql . Append ( " GROUP BY YQ99,YQ03,RES04,AK014" );
            }
            if ( tableNum . Contains ( "R_341" ) )
            {
                if ( strSql . ToString ( ) . Contains ( "SELECT" ) )
                    strSql . Append ( " UNION " );
                strSql . Append ( "SELECT PQV76 CP03,PQV01 CP01,CONVERT(NVARCHAR,RES04,102) RES04,CASE WHEN AK014='' OR AK014 IS NULL THEN '未结' ELSE '已结' END AK,CONVERT(DECIMAL(11,2),SUM(PQV11*PQV66*PQV81*PQV67*PQV13)) U2 FROM R_PQV A LEFT JOIN R_REVIEWS B ON A.PQV76=B.RES06 LEFT JOIN R_PQAK C ON A.PQV76=C.AK003 WHERE RES05='执行' AND PQV65='外购' " );
                if ( year > 0 )
                    strSql . AppendFormat ( " AND YEAR(RES04)={0} " ,year );
                //strSql . Append ( "UNION ALL " );
                strSql . Append ( " GROUP BY PQV76,PQV01,RES04,AK014" );
            }
            if ( tableNum . Contains ( "R_342" ) )
            {
                if ( strSql . ToString ( ) . Contains ( "SELECT" ) )
                    strSql . Append ( " UNION " );
                strSql . Append ( "SELECT AF001 CP03,AF002 CP01,CONVERT(NVARCHAR,RES04,102) RES04,CASE WHEN AK014='' OR AK014 IS NULL THEN '未结' ELSE '已结' END AK,CONVERT(DECIMAL(11,2),SUM(AF023*AF006*AF019)) U2 FROM R_PQAF A LEFT JOIN R_REVIEWS B ON A.AF001=B.RES06 LEFT JOIN R_PQAK C ON A.AF001=C.AK003 WHERE RES05='执行' AND AF016='外购' " );
                if ( year > 0 )
                    strSql . AppendFormat ( " AND YEAR(RES04)={0} " ,year );
                //strSql . Append ( "UNION ALL " );
                strSql . Append ( " GROUP BY AF001,AF002,RES04,AK014" );
            }
            if ( tableNum . Contains ( "R_343" ) )
            {
                if ( strSql . ToString ( ) . Contains ( "SELECT" ) )
                    strSql . Append ( " UNION " );
                strSql . Append ( "SELECT PQU97 CP03,PQU01 CP01,CONVERT(NVARCHAR,RES04,102) RES04,CASE WHEN AK014='' OR AK014 IS NULL THEN '未结' ELSE '已结' END AK,CONVERT(DECIMAL(11,2),SUM(PQU16*(PQU13*PQU101+PQU14))) U2  FROM R_PQU A LEFT JOIN R_REVIEWS B ON A.PQU97=B.RES06 LEFT JOIN R_PQAK C ON A.PQU97=C.AK003 WHERE RES05='执行' AND PQU19='外购' " );
                if ( year > 0 )
                    strSql . AppendFormat ( " AND YEAR(RES04)={0} " ,year );
                //strSql . Append ( "UNION ALL " );
                strSql . Append ( " GROUP BY PQU97,PQU01,RES04,AK014" );
            }
            if ( tableNum . Contains ( "R_344" ) )
            {
                if ( strSql . ToString ( ) . Contains ( "SELECT" ) )
                    strSql . Append ( " UNION " );
                strSql . Append ( "SELECT MZ001 CP03,MZ002 CP01,CONVERT(NVARCHAR,RES04,102) RES04,CASE WHEN AK014='' OR AK014 IS NULL THEN '未结' ELSE '已结' END AK,CONVERT(DECIMAL(11,2),SUM(MZ022*MZ006*MZ027+ISNULL(MZ118,0))) MZ2 FROM R_PQMZ A LEFT JOIN R_REVIEWS B ON A.MZ001=B.RES06 LEFT JOIN R_PQAK C ON A.MZ001=C.AK003 WHERE RES05='执行' " );
                if ( year > 0 )
                    strSql . AppendFormat ( " AND YEAR(RES04)={0} " ,year );
                //strSql . Append ( "UNION ALL " );
                strSql . Append ( " GROUP BY MZ001,MZ002,RES04,AK014" );
            }
            if ( tableNum . Contains ( "R_347" ) )
            {
                if ( strSql . ToString ( ) . Contains ( "SELECT" ) )
                    strSql . Append ( " UNION " );
                strSql . Append ( "SELECT PJ92 CP03,PJ01 CP01,CONVERT(NVARCHAR,RES04,102) RES04,CASE WHEN AK014='' OR AK014 IS NULL THEN '未结' ELSE '已结' END AK,CONVERT(DECIMAL(11,2),SUM(PJ12*(PJ11*PJ96+PJ10))) U2 FROM R_PQS A LEFT JOIN R_REVIEWS B ON A.PJ92=B.RES06 LEFT JOIN R_PQAK C ON A.PJ92=C.AK003 WHERE RES05='执行' AND PJ15='外购' " );
                if ( year > 0 )
                    strSql . AppendFormat ( " AND YEAR(RES04)={0} " ,year );
                //strSql . Append ( "UNION ALL " );
                strSql . Append ( " GROUP BY PJ92,PJ01,RES04,AK014" );
            }
            if ( tableNum . Contains ( "R_349" ) )
            {
                if ( strSql . ToString ( ) . Contains ( "SELECT" ) )
                    strSql . Append ( " UNION " );
                strSql . Append ( "SELECT WX82 CP03,WX01 CP01,CONVERT(NVARCHAR,RES04,102) RES04,CASE WHEN AK014='' OR AK014 IS NULL THEN '未结' ELSE '已结' END AK,CONVERT(DECIMAL(11,2),SUM(CASE WHEN WX10='双瓦外箱' THEN ((WX27 + WX28 + WX29) * (WX30 + WX31 + WX32) + (WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15 WHEN WX10='小箱式' THEN ((WX27 + WX28 + WX29) * (WX30 + WX31 + WX32) + (WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15 WHEN WX10='牙膏式' THEN ((WX27 + 2*WX28 + WX29) * (2*WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15  WHEN WX10='插口式' THEN ((WX27 + 2*WX28 + WX29) * (2*WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10='天盖' THEN ((WX27 + 2*WX28 + WX29) * (WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10='地盖' THEN ((WX27 + 2*WX28 + WX29) * (WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10='折叠式' THEN ((2*WX27 + 2*WX28 + WX29) * (1.5*WX30 + WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10 NOT IN ('双瓦外箱','小箱式','牙膏式','插口式','天盖','地盖','折叠式') THEN (WX23 + WX24) * (WX25 + WX26) * 0.0001 * WX13* WX15 END)) U2 FROM R_PQT A LEFT JOIN R_REVIEWS B ON A.WX82=B.RES06 LEFT JOIN R_PQAK C ON A.WX82=C.AK003 WHERE RES05='执行' AND WX17='外购' " );
                if ( year > 0 )
                    strSql . AppendFormat ( " AND YEAR(RES04)={0} " ,year );
                //strSql . Append ( "UNION ALL " );
                strSql . Append ( " GROUP BY WX82,WX01,RES04,AK014" );
            }
            if ( tableNum . Contains ( "R_505" ) )
            {
                if ( strSql . ToString ( ) . Contains ( "SELECT" ) )
                    strSql . Append ( " UNION " );
                strSql . Append ( "SELECT IZ001 CP03,IZ002 CP01,CONVERT(NVARCHAR,RES04,102) RES04,CASE WHEN AK014='' OR AK014 IS NULL THEN '未结' ELSE '已结' END AK,CONVERT(DECIMAL(11,2),SUM(CASE WHEN IZ021=0 THEN 0 ELSE (IZ005*IZ022/IZ021)*(IZ013*(IZ014+IZ015)*2*IZ016) END)) U2 FROM R_PQIZ A LEFT JOIN R_REVIEWS B ON A.IZ001=B.RES06 LEFT JOIN R_PQAK C ON A.IZ001=C.AK003 WHERE RES05='执行' " );
                if ( year > 0 )
                    strSql . AppendFormat ( " AND YEAR(RES04)={0} " ,year );
                //strSql . Append ( "UNION ALL " );
                strSql . Append ( " GROUP BY IZ001,IZ002,RES04,AK014" );
            }
            if ( tableNum . Contains ( "R_495" ) )
            {
                if ( strSql . ToString ( ) . Contains ( "SELECT" ) )
                    strSql . Append ( " UNION " );
                strSql . Append ( "SELECT PY33 CP03,PY01 CP01,CONVERT(NVARCHAR,RES04,102) RES04,CASE WHEN AK014='' OR AK014 IS NULL THEN '未结' ELSE '已结' END AK,CONVERT(DECIMAL(11,2),SUM(CASE WHEN PY14 = 0 OR PY18 = 0 OR PY21 = 0 THEN 0 WHEN PY14 != 0 AND PY18 != 0 AND PY21 != 0 THEN (PY10*PY11*PY15*PY12*PY20/PY21/PY14/PY18+PY13*PY19*PY16*PY10*PY11/PY14/PY18/PY21/2)*(1+PY17/100) END+PY23*PY14*PY18*PY11*PY10*PY12*PY15*0.0001)) U2 FROM R_PQY A LEFT JOIN R_REVIEWS B ON A.PY33=B.RES06 LEFT JOIN R_PQAK C ON A.PY33=C.AK003 WHERE RES05='执行' " );
                if ( year > 0 )
                    strSql . AppendFormat ( " AND YEAR(RES04)={0} " ,year );
                strSql . Append ( " GROUP BY PY33,PY01,RES04,AK014" );
            }
            strSql . Append ( ") SELECT A.*,B.EA005 FROM CET A LEFT JOIN R_PQEA B ON A.CP03=B.EA001 AND A.CP01=B.EA002 " );
            strSql . Append ( " WHERE AK='未结' " );
            //if ( !string . IsNullOrEmpty ( tableNum ) )
            //    strSql . AppendFormat ( " AND CP03 LIKE '{0}%'" ,tableNum );
            if ( !state )
                strSql . AppendFormat ( " AND (EA005=0 OR EA005 IS NULL OR EA005='')" );
            
            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }
        


        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Update ( DataTable table )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            if ( table != null && table . Rows . Count > 0 )
            {
                MulaolaoLibrary . ContCheckTableEntity _model = new MulaolaoLibrary . ContCheckTableEntity ( );
                for ( int i = 0 ; i < table . Rows . Count ; i++ )
                {
                    _model . EA001 = table . Rows [ i ] [ "CP03" ] . ToString ( );
                    _model . EA002 = table . Rows [ i ] [ "CP01" ] . ToString ( );
                    if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "RES04" ] . ToString ( ) ) )
                        _model . EA003 = null;
                    else
                        _model . EA003 = Convert . ToDateTime ( table . Rows [ i ] [ "RES04" ] . ToString ( ) );
                    _model . EA004 = string . IsNullOrEmpty ( table . Rows [ i ] [ "AK" ] . ToString ( ) ) == true ? false : ( table . Rows [ i ] [ "AK" ] . ToString ( ) . Equals ( "已结" ) ? true : false );
                    _model . EA005 = string . IsNullOrEmpty ( table . Rows [ i ] [ "EA005" ] . ToString ( ) ) == true ? false : true;
                    if ( !Exists ( _model ) )
                        Add ( SQLString ,strSql ,_model );
                    else
                        Edit ( SQLString ,strSql ,_model );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        bool Exists ( MulaolaoLibrary . ContCheckTableEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM R_PQEA WHERE EA001='{0}' AND EA002='{1}'" ,_model . EA001 ,_model . EA002 );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        void Add ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . ContCheckTableEntity _model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQEA (" );
            strSql . Append ( "EA001,EA002,EA003,EA004,EA005) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@EA001,@EA002,@EA003,@EA004,@EA005)" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@EA001",SqlDbType.NVarChar,50),
                new SqlParameter("@EA002",SqlDbType.NVarChar,255),
                new SqlParameter("@EA003",SqlDbType.Date),
                new SqlParameter("@EA004",SqlDbType.Bit),
                new SqlParameter("@EA005",SqlDbType.Bit)
            };
            parameter [ 0 ] . Value = _model . EA001;
            parameter [ 1 ] . Value = _model . EA002;
            parameter [ 2 ] . Value = _model . EA003;
            parameter [ 3 ] . Value = _model . EA004;
            parameter [ 4 ] . Value = _model . EA005;

            SQLString . Add ( strSql ,parameter );
        }

        void Edit ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . ContCheckTableEntity _model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQEA SET " );
            strSql . Append ( "EA003=@EA003," );
            strSql . Append ( "EA004=@EA004," );
            strSql . Append ( "EA005=@EA005 " );
            strSql . Append ( " WHERE EA001=@EA001" );
            strSql . Append ( " AND EA002=@EA002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@EA001",SqlDbType.NVarChar,50),
                new SqlParameter("@EA002",SqlDbType.NVarChar,255),
                new SqlParameter("@EA003",SqlDbType.Date),
                new SqlParameter("@EA004",SqlDbType.Bit),
                new SqlParameter("@EA005",SqlDbType.Bit)
            };
            parameter [ 0 ] . Value = _model . EA001;
            parameter [ 1 ] . Value = _model . EA002;
            parameter [ 2 ] . Value = _model . EA003;
            parameter [ 3 ] . Value = _model . EA004;
            parameter [ 4 ] . Value = _model . EA005;

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Delete ( MulaolaoLibrary . ContCheckTableEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM R_PQEA WHERE EA001='{0}' AND EA002='{1}'" ,_model . EA001 ,_model . EA002 );

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

    }
}

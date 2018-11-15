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
    public class QualityFinalInspsctionDao
    {
        /// <summary>
        /// get table from r_pqf
        /// </summary>
        /// <returns></returns>
        public DataTable getSupplier ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PQF01,PQF03,PQF04,PQF06,PQF07,PQF08,MIN(PQX25) PQX25 FROM R_PQF A LEFT JOIN R_PQX B ON A.PQF01=B.PQX01 AND B.PQX15='包装' GROUP BY PQF01,PQF03,PQF04,PQF06,PQF07,PQF08 ORDER BY PQF01 DESC" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get columns value from r_pqdi
        /// </summary>
        /// <returns></returns>
        public DataTable getColumnOnly ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT DI001,DI002,DI003,DI004,DI011 FROM R_PQDI " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get count from r_pqdi 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int getCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM (SELECT DISTINCT DI001,DI002,DI003,DI004,DI011 FROM R_PQDI WHERE {0}) A" ,strWhere );

            object obj = SqlHelper . GetSingle ( strSql . ToString ( ) );
            if ( obj == null )
                return 0;
            else
                return Convert . ToInt32 ( obj );
        }

        /// <summary>
        /// get data by page for change
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable getDataTableByChange ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT DI001,DI002,DI003,DI004,DI011,RES05 FROM ( " );
            strSql . Append ( "SELECT ROW_NUMBER() OVER( " );
            strSql . Append ( "ORDER BY T.DI001 DESC) " );
            strSql . Append ( "AS ROW,T.* FROM R_PQDI T " );
            strSql . Append ( "WHERE " + strWhere );
            strSql . Append ( ") TT LEFT JOIN R_REVIEWS ON DI001=RES06" );
            strSql . AppendFormat ( " WHERE TT.ROW BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get datasource from r_pqdi
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public MulaolaoLibrary . QualityFinalInspsctionDIEntity getModel ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT  A.idx,DI001,DI002,DI003,DI004,DI005,DI006,DI007,DI008,DI009,DI010,DI011,DI012,DI013,DI014,DI015,DI016,DI017,DI018,DI019,DI020,DI021,DI022,DI023,DI024,DI025,DI026,SUM(CASE WHEN DJ002='' THEN 0 WHEN DJ002 IS NULL THEN 0 WHEN DJ002 LIKE '极严重%' THEN DJ008 ELSE 0 END) DI027,DI028,DI029,DI030,SUM(CASE WHEN DJ002='' THEN 0 WHEN DJ002 IS NULL THEN 0 WHEN DJ002 LIKE '严重%' THEN DJ008 ELSE 0 END) DI031,DI032,DI033,DI034,SUM(CASE WHEN DJ002='' THEN 0 WHEN DJ002 IS NULL THEN 0 WHEN DJ002 LIKE '轻微%' THEN DJ008 ELSE 0 END) DI035 FROM R_PQDI A LEFT JOIN R_PQDJ B ON A.DI001=B.DJ001 " );
            strSql . AppendFormat ( " WHERE DI001='{0}' " ,oddNum );
            strSql . Append ( "GROUP BY A.idx,DI001,DI002,DI003,DI004,DI005,DI006,DI007,DI008,DI009,DI010,DI011,DI012,DI013,DI014,DI015,DI016,DI017,DI018,DI019,DI020,DI021,DI022,DI023,DI024,DI025,DI026,DI028,DI029,DI030,DI032,DI033,DI034 " );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
                return getModel ( dt . Rows [ 0 ] );
            else
                return null;
        }

        public MulaolaoLibrary . QualityFinalInspsctionDIEntity getModel ( DataRow row )
        {
            MulaolaoLibrary . QualityFinalInspsctionDIEntity model = new MulaolaoLibrary . QualityFinalInspsctionDIEntity ( );

            if ( row != null )
            {
                if ( row [ "idx" ] != null && row [ "idx" ] . ToString ( ) != "" )
                {
                    model . idx = int . Parse ( row [ "idx" ] . ToString ( ) );
                }
                if ( row [ "DI001" ] != null )
                {
                    model . DI001 = row [ "DI001" ] . ToString ( );
                }
                if ( row [ "DI002" ] != null )
                {
                    model . DI002 = row [ "DI002" ] . ToString ( );
                }
                if ( row [ "DI003" ] != null )
                {
                    model . DI003 = row [ "DI003" ] . ToString ( );
                }
                if ( row [ "DI004" ] != null )
                {
                    model . DI004 = row [ "DI004" ] . ToString ( );
                }
                if ( row [ "DI005" ] != null && row [ "DI005" ] . ToString ( ) != "" )
                {
                    model . DI005 = int . Parse ( row [ "DI005" ] . ToString ( ) );
                }
                if ( row [ "DI006" ] != null )
                {
                    model . DI006 = row [ "DI006" ] . ToString ( );
                }
                if ( row [ "DI007" ] != null )
                {
                    model . DI007 = row [ "DI007" ] . ToString ( );
                }
                if ( row [ "DI008" ] != null && row [ "DI008" ] . ToString ( ) != "" )
                {
                    model . DI008 = int . Parse ( row [ "DI008" ] . ToString ( ) );
                }
                if ( row [ "DI009" ] != null && row [ "DI009" ] . ToString ( ) != "" )
                {
                    model . DI009 = DateTime . Parse ( row [ "DI009" ] . ToString ( ) );
                }
                if ( row [ "DI010" ] != null && row [ "DI010" ] . ToString ( ) != "" )
                {
                    model . DI010 = DateTime . Parse ( row [ "DI010" ] . ToString ( ) );
                }
                if ( row [ "DI011" ] != null )
                {
                    model . DI011 = row [ "DI011" ] . ToString ( );
                }
                if ( row [ "DI012" ] != null && row [ "DI012" ] . ToString ( ) != "" )
                {
                    model . DI012 = DateTime . Parse ( row [ "DI012" ] . ToString ( ) );
                }
                if ( row [ "DI013" ] != null && row [ "DI013" ] . ToString ( ) != "" )
                {
                    model . DI013 = DateTime . Parse ( row [ "DI013" ] . ToString ( ) );
                }
                if ( row [ "DI014" ] != null )
                {
                    model . DI014 = row [ "DI014" ] . ToString ( );
                }
                if ( row [ "DI015" ] != null && row [ "DI015" ] . ToString ( ) != "" )
                {
                    model . DI015 = DateTime . Parse ( row [ "DI015" ] . ToString ( ) );
                }
                if ( row [ "DI016" ] != null && row [ "DI016" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DI016" ] . ToString ( ) == "1" ) || ( row [ "DI016" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DI016 = true;
                    }
                    else
                    {
                        model . DI016 = false;
                    }
                }
                if ( row [ "DI017" ] != null && row [ "DI017" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DI017" ] . ToString ( ) == "1" ) || ( row [ "DI017" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DI017 = true;
                    }
                    else
                    {
                        model . DI017 = false;
                    }
                }
                if ( row [ "DI018" ] != null && row [ "DI018" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DI018" ] . ToString ( ) == "1" ) || ( row [ "DI018" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DI018 = true;
                    }
                    else
                    {
                        model . DI018 = false;
                    }
                }
                if ( row [ "DI019" ] != null && row [ "DI019" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DI019" ] . ToString ( ) == "1" ) || ( row [ "DI019" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DI019 = true;
                    }
                    else
                    {
                        model . DI019 = false;
                    }
                }
                if ( row [ "DI020" ] != null && row [ "DI020" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DI020" ] . ToString ( ) == "1" ) || ( row [ "DI020" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DI020 = true;
                    }
                    else
                    {
                        model . DI020 = false;
                    }
                }
                if ( row [ "DI021" ] != null && row [ "DI021" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DI021" ] . ToString ( ) == "1" ) || ( row [ "DI021" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DI021 = true;
                    }
                    else
                    {
                        model . DI021 = false;
                    }
                }
                if ( row [ "DI022" ] != null && row [ "DI022" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DI022" ] . ToString ( ) == "1" ) || ( row [ "DI022" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DI022 = true;
                    }
                    else
                    {
                        model . DI022 = false;
                    }
                }
                if ( row [ "DI023" ] != null && row [ "DI023" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DI023" ] . ToString ( ) == "1" ) || ( row [ "DI023" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DI023 = true;
                    }
                    else
                    {
                        model . DI023 = false;
                    }
                }
                if ( row [ "DI024" ] != null && row [ "DI024" ] . ToString ( ) != "" )
                {
                    model . DI024 = decimal . Parse ( row [ "DI024" ] . ToString ( ) );
                }
                if ( row [ "DI025" ] != null && row [ "DI025" ] . ToString ( ) != "" )
                {
                    model . DI025 = int . Parse ( row [ "DI025" ] . ToString ( ) );
                }
                if ( row [ "DI026" ] != null && row [ "DI026" ] . ToString ( ) != "" )
                {
                    model . DI026 = int . Parse ( row [ "DI026" ] . ToString ( ) );
                }
                if ( row [ "DI027" ] != null && row [ "DI027" ] . ToString ( ) != "" )
                {
                    model . DI027 = int . Parse ( row [ "DI027" ] . ToString ( ) );
                }
                if ( row [ "DI028" ] != null && row [ "DI028" ] . ToString ( ) != "" )
                {
                    model . DI028 = decimal . Parse ( row [ "DI028" ] . ToString ( ) );
                }
                if ( row [ "DI029" ] != null && row [ "DI029" ] . ToString ( ) != "" )
                {
                    model . DI029 = int . Parse ( row [ "DI029" ] . ToString ( ) );
                }
                if ( row [ "DI030" ] != null && row [ "DI030" ] . ToString ( ) != "" )
                {
                    model . DI030 = int . Parse ( row [ "DI030" ] . ToString ( ) );
                }
                if ( row [ "DI031" ] != null && row [ "DI031" ] . ToString ( ) != "" )
                {
                    model . DI031 = int . Parse ( row [ "DI031" ] . ToString ( ) );
                }
                if ( row [ "DI032" ] != null && row [ "DI032" ] . ToString ( ) != "" )
                {
                    model . DI032 = decimal . Parse ( row [ "DI032" ] . ToString ( ) );
                }
                if ( row [ "DI033" ] != null && row [ "DI033" ] . ToString ( ) != "" )
                {
                    model . DI033 = int . Parse ( row [ "DI033" ] . ToString ( ) );
                }
                if ( row [ "DI034" ] != null && row [ "DI034" ] . ToString ( ) != "" )
                {
                    model . DI034 = int . Parse ( row [ "DI034" ] . ToString ( ) );
                }
                if ( row [ "DI035" ] != null && row [ "DI035" ] . ToString ( ) != "" )
                {
                    model . DI035 = int . Parse ( row [ "DI035" ] . ToString ( ) );
                }
            }

            return model;
        }

        /// <summary>
        /// get table from r_pqdj
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable getTableView ( string oddNum )
        {
            addViewToDataBase ( oddNum );
            
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,DJ001,DJ002,DJ003,DJ004,DJ005,DJ006,DJ007,DJ008 FROM R_PQDJ " );
            strSql . AppendFormat ( "WHERE DJ001='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        void addViewToDataBase ( string oddNum )
        {
            ArrayList SQLString = new ArrayList ( );

            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM R_PQDJ WHERE DJ001='{0}'" ,oddNum );
            if ( SqlHelper . Exists ( strSql . ToString ( ) ) == true )
                return;
            MulaolaoLibrary . QualityFinalInspsctionDJEntity _dj = new MulaolaoLibrary . QualityFinalInspsctionDJEntity ( );
            _dj . DJ001 = oddNum;
            add_di ( _dj ,SQLString );

            _dj . DJ002 = "极严重缺陷不允许";
            _dj . DJ003 = "木质虫蛀、霉烂、利器、蚊虫";
            _dj . DJ004 = "不应出现，管理措施符合情况";

            add_dj ( _dj ,SQLString );

            _dj . DJ002 = "极严重缺陷不允许";
            _dj . DJ003 = "童床、摇篮等绳索";
            _dj . DJ004 = "不应松脱、断裂";

            add_dj ( _dj ,SQLString );

            _dj . DJ002 = "极严重缺陷不允许";
            _dj . DJ003 = "可拆卸小零件";
            _dj . DJ004 = "不得容入小圆桶";

            add_dj ( _dj ,SQLString );

            _dj . DJ002 = "极严重缺陷不允许";
            _dj . DJ003 = "不可拆卸小零件";
            _dj . DJ004 = "90N力不脱落";

            add_dj ( _dj ,SQLString );

            _dj . DJ002 = "极严重缺陷不允许";
            _dj . DJ003 = "尖端、快口";
            _dj . DJ004 = "不应有危机安全的尖端和快口";

            add_dj ( _dj ,SQLString );

            _dj . DJ002 = "极严重缺陷不允许";
            _dj . DJ003 = "塑料袋厚度";
            _dj . DJ004 = "≥0.038mm";

            add_dj ( _dj ,SQLString );

            _dj . DJ002 = "极严重缺陷不允许";
            _dj . DJ003 = "警告标识、标签和使用说明";
            _dj . DJ004 = "品质检验规程相关要求";

            add_dj ( _dj ,SQLString );

            _dj . DJ002 = "严重缺陷AQL=1.5";
            _dj . DJ003 = "含水率";
            _dj . DJ004 = "应小于14%，是否有R - 122表记录";

            add_dj ( _dj ,SQLString );

            _dj . DJ002 = "严重缺陷AQL=1.5";
            _dj . DJ003 = "木质基质";
            _dj . DJ004 = "不得有黑点、结疤、裂纹、明显色差";

            add_dj ( _dj ,SQLString );

            _dj . DJ002 = "严重缺陷AQL=1.5";
            _dj . DJ003 = "产品功能";
            _dj . DJ004 = "不应出现功能性缺陷";

            add_dj ( _dj ,SQLString );

            _dj . DJ002 = "严重缺陷AQL=1.5";
            _dj . DJ003 = "装配质量";
            _dj . DJ004 = "装配平整、牢固、活动灵活，无卡滞";

            add_dj ( _dj ,SQLString );

            _dj . DJ002 = "轻微缺陷AQL=4.0";
            _dj . DJ003 = "木制零件外观";
            _dj . DJ004 = "形状一致、无起翘、变形、毛刺、划痕";

            add_dj ( _dj ,SQLString );

            _dj . DJ002 = "轻微缺陷AQL=4.0";
            _dj . DJ003 = "塑料零件外观";
            _dj . DJ004 = "不得有气孔、裂痕、变形、溢边";

            add_dj ( _dj ,SQLString );

            _dj . DJ002 = "轻微缺陷AQL=4.0";
            _dj . DJ003 = "镀膜零件外观";
            _dj . DJ004 = "不得有气泡、剥落、露底";

            add_dj ( _dj ,SQLString );

            _dj . DJ002 = "轻微缺陷AQL=4.0";
            _dj . DJ003 = "表面涂层";
            _dj . DJ004 = "不得有堆漆、染色、剥落、露底、泛白、色差";

            add_dj ( _dj ,SQLString );

            _dj . DJ002 = "轻微缺陷AQL=4.0";
            _dj . DJ003 = "印刷、彩绘";
            _dj . DJ004 = "印刷位置、色泽、图案、唛头文字符合封样要求";

            add_dj ( _dj ,SQLString );

            _dj . DJ002 = "轻微缺陷AQL=4.0";
            _dj . DJ003 = "清洁度";
            _dj . DJ004 = "不得有污迹、灰尘、头发、杂物";

            add_dj ( _dj ,SQLString );

            _dj . DJ002 = string . Empty;
            _dj . DJ003 = "跌落测试";
            _dj . DJ004 = "EN71测试标准：850mm×5times";

            add_dj ( _dj ,SQLString );

            _dj . DJ002 = string . Empty;
            _dj . DJ003 = "跌落测试";
            _dj . DJ004 = "ASTM测试标准0 - 18：1370mm×10times＜1.4kg 18 - 36：910mm×4times＜1.8kg 36 - 96：910mm×4times＜4.5kg";

            add_dj ( _dj ,SQLString );

            _dj . DJ002 = string . Empty;
            _dj . DJ003 = "拉力测试";
            _dj . DJ004 = "EN71测试标准：￠≤6mm 50N￠＞6mm 90N";

            add_dj ( _dj ,SQLString );

            _dj . DJ002 = string . Empty;
            _dj . DJ003 = "拉力测试";
            _dj . DJ004 = "ASTM测试标准:0-18：44.5N 18 - 96：66.8N";

            add_dj ( _dj ,SQLString );

            _dj . DJ002 = string . Empty;
            _dj . DJ003 = "扭力测试";
            _dj . DJ004 = "EN71测试标准：0.34Nm";

            add_dj ( _dj ,SQLString );

            _dj . DJ002 = string . Empty;
            _dj . DJ003 = "扭力测试";
            _dj . DJ004 = "ASTM测试标准：0-18：0.23Nm 18 - 36：0.34Nm 36 - 96：0.45Nm";

            add_dj ( _dj ,SQLString );

            _dj . DJ002 = string . Empty;
            _dj . DJ003 = "压力测试";
            _dj . DJ004 = "EN71测试标准：110N";

            add_dj ( _dj ,SQLString );

            _dj . DJ002 = string . Empty;
            _dj . DJ003 = "压力测试";
            _dj . DJ004 = "ASTM测试标准：0-18：89N 18-36：111.3N 36-96：133.5N";

            add_dj ( _dj ,SQLString );

            _dj . DJ002 = string . Empty;
            _dj . DJ003 = "摔箱测试";
            _dj . DJ004 = "产品功能须正常；产品表面、包装本身不能有较大受损；产品配件不能松动或脱落";

            add_dj ( _dj ,SQLString );

            _dj . DJ002 = string . Empty;
            _dj . DJ003 = string . Empty;
            _dj . DJ004 = "主要原材料、配件是否齐全";

            add_dj ( _dj ,SQLString );

            _dj . DJ002 = string . Empty;
            _dj . DJ003 = string . Empty;
            _dj . DJ004 = "包装方法是否符合封样要求";

            add_dj ( _dj ,SQLString );

            _dj . DJ002 = string . Empty;
            _dj . DJ003 = string . Empty;
            _dj . DJ004 = "包装产品标识是否清楚";

            add_dj ( _dj ,SQLString );

            _dj . DJ002 = string . Empty;
            _dj . DJ003 = string . Empty;
            _dj . DJ004 = "与登记产品是否一致，部件数量是否齐全、相符";

            add_dj ( _dj ,SQLString );

            _dj . DJ002 = string . Empty;
            _dj . DJ003 = string . Empty;
            _dj . DJ004 = "包装人员岗前是否培训";

            add_dj ( _dj ,SQLString );

            _dj . DJ002 = string . Empty;
            _dj . DJ003 = string . Empty;
            _dj . DJ004 = "其他";

            add_dj ( _dj ,SQLString );

            SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void add_di ( MulaolaoLibrary . QualityFinalInspsctionDJEntity model ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "INSERT INTO R_PQDI (DI001) VALUES ('{0}')" ,model . DJ001 );
            SQLString . Add ( strSql . ToString ( ) );
        }

        void add_dj ( MulaolaoLibrary . QualityFinalInspsctionDJEntity model ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "INSERT INTO R_PQDJ (DJ001,DJ002,DJ003,DJ004) VALUES ('{0}','{1}','{2}','{3}')" ,model . DJ001 ,model . DJ002 ,model . DJ003 ,model . DJ004 );
            SQLString . Add ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get max oddNum from r_pqdJ
        /// </summary>
        /// <returns></returns>
        public string getOddNum ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(DI001) DI001 FROM R_PQDI " );
            strSql . AppendFormat ( "WHERE DI001 LIKE 'R_101-{0}%'" ,Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                string oddNum = dt . Rows [ 0 ] [ "DI001" ] . ToString ( );
                if ( string . IsNullOrEmpty ( oddNum ) )
                    return "R_101-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "0001";
                else
                {
                    oddNum = "R_101-" + ( Convert . ToInt64 ( oddNum . Substring ( 6 ,12 ) ) + 1 ) . ToString ( );
                    return oddNum;
                }
            }
            else
                return "R_101-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "0001";
        }

        /// <summary>
        /// delete data from table
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum ,string logins )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM R_PQDI WHERE DI001='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_101" ,"品质终检报告单(R_101)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM R_PQDJ WHERE DJ001='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_101" ,"品质终检报告单(R_101)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM R_REVIEWS WHERE RES06='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_101" ,"品质终检报告单(R_101)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// save data to database
        /// </summary>
        /// <param name="table"></param>
        /// <param name="_di"></param>
        /// <param name="bodyList"></param>
        /// <param name="logins"></param>
        /// <returns></returns>
        public bool Save ( DataTable table ,MulaolaoLibrary . QualityFinalInspsctionDIEntity _di ,List<string> bodyList ,string logins )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            if ( _di . idx > 0 )
            {
                edit_di ( SQLString ,strSql ,_di );
                SQLString . Add ( Drity . DrityOfComparation ( "R_101" ,"品质终检报告单(R_101)" ,logins ,Drity . GetDt ( ) ,_di . DI001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"编辑" ,"编辑表头" ) ,null );
            }
            else
            {
                _di . DI001 = getOddNum ( );
                add_di ( SQLString ,strSql ,_di );
                SQLString . Add ( Drity . DrityOfComparation ( "R_101" ,"品质终检报告单(R_101)" ,logins ,Drity . GetDt ( ) ,_di . DI001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新增" ,"新增表头" ) ,null );
            }

            MulaolaoLibrary . QualityFinalInspsctionDJEntity model = new MulaolaoLibrary . QualityFinalInspsctionDJEntity ( );
            model . DJ001 = _di . DI001;
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                model . idx = string . IsNullOrEmpty ( table . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "idx" ] . ToString ( ) );
                model . DJ002 = table . Rows [ i ] [ "DJ002" ] . ToString ( );
                model . DJ003 = table . Rows [ i ] [ "DJ003" ] . ToString ( );
                model . DJ004 = table . Rows [ i ] [ "DJ004" ] . ToString ( );
                model . DJ005 = table . Rows [ i ] [ "DJ005" ] . ToString ( );
                model . DJ006 = table . Rows [ i ] [ "DJ006" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "DJ007" ] . ToString ( ) ) )
                    model . DJ007 = null;
                else
                    model . DJ007 = Convert . ToDateTime ( table . Rows [ i ] [ "DJ007" ] . ToString ( ) );
                model . DJ008 = string . IsNullOrEmpty ( table . Rows [ i ] [ "DJ008" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "DJ008" ] . ToString ( ) );
                if ( model . idx > 0 )
                {
                    edit_dj ( SQLString ,strSql ,model );
                    SQLString . Add ( Drity . DrityOfComparation ( "R_101" + i ,"品质终检报告单(R_101)" ,logins ,Drity . GetDt ( ) ,_di . DI001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"编辑" ,"编辑表身" ) ,null );
                }
                else
                {
                    add_dj ( SQLString ,strSql ,model );
                    SQLString . Add ( Drity . DrityOfComparation ( "R_101" + i ,"品质终检报告单(R_101)" ,logins ,Drity . GetDt ( ) ,_di . DI001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新增" ,"新增表身" ) ,null );
                }
            }

            if ( bodyList . Count > 0 )
            {
                foreach ( string s in bodyList )
                {
                    model . idx = Convert . ToInt32 ( s );
                    delete_dj ( SQLString ,strSql ,model );
                    SQLString . Add ( Drity . DrityOfComparation ( "R_101" + model . idx ,"品质终检报告单(R_101)" ,logins ,Drity . GetDt ( ) ,_di . DI001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除表身" ) ,null );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void add_di ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . QualityFinalInspsctionDIEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_PQDI(" );
            strSql . Append ( "DI001,DI002,DI003,DI004,DI005,DI006,DI007,DI008,DI009,DI010,DI011,DI012,DI013,DI014,DI015,DI016,DI017,DI018,DI019,DI020,DI021,DI022,DI023,DI024,DI025,DI026,DI027,DI028,DI029,DI030,DI031,DI032,DI033,DI034,DI035)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@DI001,@DI002,@DI003,@DI004,@DI005,@DI006,@DI007,@DI008,@DI009,@DI010,@DI011,@DI012,@DI013,@DI014,@DI015,@DI016,@DI017,@DI018,@DI019,@DI020,@DI021,@DI022,@DI023,@DI024,@DI025,@DI026,@DI027,@DI028,@DI029,@DI030,@DI031,@DI032,@DI033,@DI034,@DI035)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@DI001", SqlDbType.NVarChar,20),
                    new SqlParameter("@DI002", SqlDbType.NVarChar,20),
                    new SqlParameter("@DI003", SqlDbType.NVarChar,50),
                    new SqlParameter("@DI004", SqlDbType.NVarChar,20),
                    new SqlParameter("@DI005", SqlDbType.Int,4),
                    new SqlParameter("@DI006", SqlDbType.NVarChar,20),
                    new SqlParameter("@DI007", SqlDbType.NVarChar,20),
                    new SqlParameter("@DI008", SqlDbType.Int,4),
                    new SqlParameter("@DI009", SqlDbType.Date,3),
                    new SqlParameter("@DI010", SqlDbType.Date,3),
                    new SqlParameter("@DI011", SqlDbType.NVarChar,20),
                    new SqlParameter("@DI012", SqlDbType.Date,3),
                    new SqlParameter("@DI013", SqlDbType.Date,3),
                    new SqlParameter("@DI014", SqlDbType.NVarChar,20),
                    new SqlParameter("@DI015", SqlDbType.Date,3),
                    new SqlParameter("@DI016", SqlDbType.Bit,1),
                    new SqlParameter("@DI017", SqlDbType.Bit,1),
                    new SqlParameter("@DI018", SqlDbType.Bit,1),
                    new SqlParameter("@DI019", SqlDbType.Bit,1),
                    new SqlParameter("@DI020", SqlDbType.Bit,1),
                    new SqlParameter("@DI021", SqlDbType.Bit,1),
                    new SqlParameter("@DI022", SqlDbType.Bit,1),
                    new SqlParameter("@DI023", SqlDbType.Bit,1),
                    new SqlParameter("@DI024", SqlDbType.Decimal,9),
                    new SqlParameter("@DI025", SqlDbType.Int,4),
                    new SqlParameter("@DI026", SqlDbType.Int,4),
                    new SqlParameter("@DI027", SqlDbType.Int,4),
                    new SqlParameter("@DI028", SqlDbType.Decimal,9),
                    new SqlParameter("@DI029", SqlDbType.Int,4),
                    new SqlParameter("@DI030", SqlDbType.Int,4),
                    new SqlParameter("@DI031", SqlDbType.Int,4),
                    new SqlParameter("@DI032", SqlDbType.Decimal,9),
                    new SqlParameter("@DI033", SqlDbType.Int,4),
                    new SqlParameter("@DI034", SqlDbType.Int,4),
                    new SqlParameter("@DI035", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . DI001;
            parameters [ 1 ] . Value = model . DI002;
            parameters [ 2 ] . Value = model . DI003;
            parameters [ 3 ] . Value = model . DI004;
            parameters [ 4 ] . Value = model . DI005;
            parameters [ 5 ] . Value = model . DI006;
            parameters [ 6 ] . Value = model . DI007;
            parameters [ 7 ] . Value = model . DI008;
            parameters [ 8 ] . Value = model . DI009;
            parameters [ 9 ] . Value = model . DI010;
            parameters [ 10 ] . Value = model . DI011;
            parameters [ 11 ] . Value = model . DI012;
            parameters [ 12 ] . Value = model . DI013;
            parameters [ 13 ] . Value = model . DI014;
            parameters [ 14 ] . Value = model . DI015;
            parameters [ 15 ] . Value = model . DI016;
            parameters [ 16 ] . Value = model . DI017;
            parameters [ 17 ] . Value = model . DI018;
            parameters [ 18 ] . Value = model . DI019;
            parameters [ 19 ] . Value = model . DI020;
            parameters [ 20 ] . Value = model . DI021;
            parameters [ 21 ] . Value = model . DI022;
            parameters [ 22 ] . Value = model . DI023;
            parameters [ 23 ] . Value = model . DI024;
            parameters [ 24 ] . Value = model . DI025;
            parameters [ 25 ] . Value = model . DI026;
            parameters [ 26 ] . Value = model . DI027;
            parameters [ 27 ] . Value = model . DI028;
            parameters [ 28 ] . Value = model . DI029;
            parameters [ 29 ] . Value = model . DI030;
            parameters [ 30 ] . Value = model . DI031;
            parameters [ 31 ] . Value = model . DI032;
            parameters [ 32 ] . Value = model . DI033;
            parameters [ 33 ] . Value = model . DI034;
            parameters [ 34 ] . Value = model . DI035;

            SQLString . Add ( strSql ,parameters );
        }

        void edit_di ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . QualityFinalInspsctionDIEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQDI set " );
            strSql . Append ( "DI001=@DI001," );
            strSql . Append ( "DI002=@DI002," );
            strSql . Append ( "DI003=@DI003," );
            strSql . Append ( "DI004=@DI004," );
            strSql . Append ( "DI005=@DI005," );
            strSql . Append ( "DI006=@DI006," );
            strSql . Append ( "DI007=@DI007," );
            strSql . Append ( "DI008=@DI008," );
            strSql . Append ( "DI009=@DI009," );
            strSql . Append ( "DI010=@DI010," );
            strSql . Append ( "DI011=@DI011," );
            strSql . Append ( "DI012=@DI012," );
            strSql . Append ( "DI013=@DI013," );
            strSql . Append ( "DI014=@DI014," );
            strSql . Append ( "DI015=@DI015," );
            strSql . Append ( "DI016=@DI016," );
            strSql . Append ( "DI017=@DI017," );
            strSql . Append ( "DI018=@DI018," );
            strSql . Append ( "DI019=@DI019," );
            strSql . Append ( "DI020=@DI020," );
            strSql . Append ( "DI021=@DI021," );
            strSql . Append ( "DI022=@DI022," );
            strSql . Append ( "DI023=@DI023," );
            strSql . Append ( "DI024=@DI024," );
            strSql . Append ( "DI025=@DI025," );
            strSql . Append ( "DI026=@DI026," );
            strSql . Append ( "DI027=@DI027," );
            strSql . Append ( "DI028=@DI028," );
            strSql . Append ( "DI029=@DI029," );
            strSql . Append ( "DI030=@DI030," );
            strSql . Append ( "DI031=@DI031," );
            strSql . Append ( "DI032=@DI032," );
            strSql . Append ( "DI033=@DI033," );
            strSql . Append ( "DI034=@DI034," );
            strSql . Append ( "DI035=@DI035 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@DI001", SqlDbType.NVarChar,20),
                    new SqlParameter("@DI002", SqlDbType.NVarChar,20),
                    new SqlParameter("@DI003", SqlDbType.NVarChar,50),
                    new SqlParameter("@DI004", SqlDbType.NVarChar,20),
                    new SqlParameter("@DI005", SqlDbType.Int,4),
                    new SqlParameter("@DI006", SqlDbType.NVarChar,20),
                    new SqlParameter("@DI007", SqlDbType.NVarChar,20),
                    new SqlParameter("@DI008", SqlDbType.Int,4),
                    new SqlParameter("@DI009", SqlDbType.Date,3),
                    new SqlParameter("@DI010", SqlDbType.Date,3),
                    new SqlParameter("@DI011", SqlDbType.NVarChar,20),
                    new SqlParameter("@DI012", SqlDbType.Date,3),
                    new SqlParameter("@DI013", SqlDbType.Date,3),
                    new SqlParameter("@DI014", SqlDbType.NVarChar,20),
                    new SqlParameter("@DI015", SqlDbType.Date,3),
                    new SqlParameter("@DI016", SqlDbType.Bit,1),
                    new SqlParameter("@DI017", SqlDbType.Bit,1),
                    new SqlParameter("@DI018", SqlDbType.Bit,1),
                    new SqlParameter("@DI019", SqlDbType.Bit,1),
                    new SqlParameter("@DI020", SqlDbType.Bit,1),
                    new SqlParameter("@DI021", SqlDbType.Bit,1),
                    new SqlParameter("@DI022", SqlDbType.Bit,1),
                    new SqlParameter("@DI023", SqlDbType.Bit,1),
                    new SqlParameter("@DI024", SqlDbType.Decimal,9),
                    new SqlParameter("@DI025", SqlDbType.Int,4),
                    new SqlParameter("@DI026", SqlDbType.Int,4),
                    new SqlParameter("@DI027", SqlDbType.Int,4),
                    new SqlParameter("@DI028", SqlDbType.Decimal,9),
                    new SqlParameter("@DI029", SqlDbType.Int,4),
                    new SqlParameter("@DI030", SqlDbType.Int,4),
                    new SqlParameter("@DI031", SqlDbType.Int,4),
                    new SqlParameter("@DI032", SqlDbType.Decimal,9),
                    new SqlParameter("@DI033", SqlDbType.Int,4),
                    new SqlParameter("@DI034", SqlDbType.Int,4),
                    new SqlParameter("@DI035", SqlDbType.Int,4),
                    new SqlParameter("@idx", SqlDbType.Int,4)};
            parameters [ 0 ] . Value = model . DI001;
            parameters [ 1 ] . Value = model . DI002;
            parameters [ 2 ] . Value = model . DI003;
            parameters [ 3 ] . Value = model . DI004;
            parameters [ 4 ] . Value = model . DI005;
            parameters [ 5 ] . Value = model . DI006;
            parameters [ 6 ] . Value = model . DI007;
            parameters [ 7 ] . Value = model . DI008;
            parameters [ 8 ] . Value = model . DI009;
            parameters [ 9 ] . Value = model . DI010;
            parameters [ 10 ] . Value = model . DI011;
            parameters [ 11 ] . Value = model . DI012;
            parameters [ 12 ] . Value = model . DI013;
            parameters [ 13 ] . Value = model . DI014;
            parameters [ 14 ] . Value = model . DI015;
            parameters [ 15 ] . Value = model . DI016;
            parameters [ 16 ] . Value = model . DI017;
            parameters [ 17 ] . Value = model . DI018;
            parameters [ 18 ] . Value = model . DI019;
            parameters [ 19 ] . Value = model . DI020;
            parameters [ 20 ] . Value = model . DI021;
            parameters [ 21 ] . Value = model . DI022;
            parameters [ 22 ] . Value = model . DI023;
            parameters [ 23 ] . Value = model . DI024;
            parameters [ 24 ] . Value = model . DI025;
            parameters [ 25 ] . Value = model . DI026;
            parameters [ 26 ] . Value = model . DI027;
            parameters [ 27 ] . Value = model . DI028;
            parameters [ 28 ] . Value = model . DI029;
            parameters [ 29 ] . Value = model . DI030;
            parameters [ 30 ] . Value = model . DI031;
            parameters [ 31 ] . Value = model . DI032;
            parameters [ 32 ] . Value = model . DI033;
            parameters [ 33 ] . Value = model . DI034;
            parameters [ 34 ] . Value = model . DI035;
            parameters [ 35 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
        }

        void add_dj ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . QualityFinalInspsctionDJEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_PQDJ(" );
            strSql . Append ( "DJ001,DJ002,DJ003,DJ004,DJ005,DJ006,DJ007,DJ008)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@DJ001,@DJ002,@DJ003,@DJ004,@DJ005,@DJ006,@DJ007,@DJ008)" );

            SqlParameter [ ] parameters = {
                    new SqlParameter("@DJ001", SqlDbType.NVarChar,20),
                    new SqlParameter("@DJ002", SqlDbType.NVarChar,50),
                    new SqlParameter("@DJ003", SqlDbType.NVarChar,50),
                    new SqlParameter("@DJ004", SqlDbType.NVarChar,50),
                    new SqlParameter("@DJ005", SqlDbType.NVarChar,50),
                    new SqlParameter("@DJ006", SqlDbType.NVarChar,20),
                    new SqlParameter("@DJ007", SqlDbType.Date,3),
                    new SqlParameter("@DJ008", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . DJ001;
            parameters [ 1 ] . Value = model . DJ002;
            parameters [ 2 ] . Value = model . DJ003;
            parameters [ 3 ] . Value = model . DJ004;
            parameters [ 4 ] . Value = model . DJ005;
            parameters [ 5 ] . Value = model . DJ006;
            parameters [ 6 ] . Value = model . DJ007;
            parameters [ 7 ] . Value = model . DJ008;

            SQLString . Add ( strSql ,parameters );
        }

        void edit_dj ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . QualityFinalInspsctionDJEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQDJ set " );
            strSql . Append ( "DJ001=@DJ001," );
            strSql . Append ( "DJ002=@DJ002," );
            strSql . Append ( "DJ003=@DJ003," );
            strSql . Append ( "DJ004=@DJ004," );
            strSql . Append ( "DJ005=@DJ005," );
            strSql . Append ( "DJ006=@DJ006," );
            strSql . Append ( "DJ007=@DJ007," );
            strSql . Append ( "DJ008=@DJ008 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@DJ001", SqlDbType.NVarChar,20),
                    new SqlParameter("@DJ002", SqlDbType.NVarChar,50),
                    new SqlParameter("@DJ003", SqlDbType.NVarChar,50),
                    new SqlParameter("@DJ004", SqlDbType.NVarChar,50),
                    new SqlParameter("@DJ005", SqlDbType.NVarChar,50),
                    new SqlParameter("@DJ006", SqlDbType.NVarChar,20),
                    new SqlParameter("@DJ007", SqlDbType.Date,3),
                    new SqlParameter("@DJ008", SqlDbType.Int,4),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . DJ001;
            parameters [ 1 ] . Value = model . DJ002;
            parameters [ 2 ] . Value = model . DJ003;
            parameters [ 3 ] . Value = model . DJ004;
            parameters [ 4 ] . Value = model . DJ005;
            parameters [ 5 ] . Value = model . DJ006;
            parameters [ 6 ] . Value = model . DJ007;
            parameters [ 7 ] . Value = model . DJ008;
            parameters [ 8 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
        }

        void delete_dj ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . QualityFinalInspsctionDJEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "delete from R_PQDJ " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
        }

        /// <summary>
        /// get sampling from baseISO 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable getSam ( int num )
        {
            StringBuilder strSql = new StringBuilder ( );
            //strSql . AppendFormat ( "SELECT CL003,CL004,CL005,CL006,CL007 FROM R_PQCL WHERE {0} between CL001 and CL002 order by CL001" ,num );
            strSql . AppendFormat ( "SELECT CL004,CL005,CL006,CL007 FROM R_PQCL WHERE CL003={0}" ,num );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get table for print
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable getPrintOne ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT  A.idx,DI001,DI002,DI003,DI004,DI005,DI006,DI007,DI008,DI009,DI010,DI011,DI012,DI013,DI014,DI015,DI016,DI017,DI018,DI019,DI020,DI021,DI022,DI023,DI024,DI025,DI026,SUM(CASE WHEN DJ002='' THEN 0 WHEN DJ002 IS NULL THEN 0 WHEN DJ002 LIKE '极严重%' THEN DJ008 ELSE 0 END) DI027,DI028,DI029,DI030,SUM(CASE WHEN DJ002='' THEN 0 WHEN DJ002 IS NULL THEN 0 WHEN DJ002 LIKE '严重%' THEN DJ008 ELSE 0 END) DI031,DI032,DI033,DI034,SUM(CASE WHEN DJ002='' THEN 0 WHEN DJ002 IS NULL THEN 0 WHEN DJ002 LIKE '轻微%' THEN DJ008 ELSE 0 END) DI035 FROM R_PQDI A LEFT JOIN R_PQDJ B ON A.DI001=B.DJ001 " );
            strSql . AppendFormat ( " WHERE DI001='{0}' " ,oddNum );
            strSql . Append ( "GROUP BY A.idx,DI001,DI002,DI003,DI004,DI005,DI006,DI007,DI008,DI009,DI010,DI011,DI012,DI013,DI014,DI015,DI016,DI017,DI018,DI019,DI020,DI021,DI022,DI023,DI024,DI025,DI026,DI028,DI029,DI030,DI032,DI033,DI034 " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get table for print
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable getPrintTwo ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT idx,DJ001,DJ002,DJ003,DJ004,DJ005,DJ006,DJ007,DJ008 FROM R_PQDJ WHERE DJ001='{0}' ORDER BY DJ002 DESC " ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}

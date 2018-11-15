using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using System . Data;
using StudentMgr;
using System . Data . SqlClient;
using System . Collections;

namespace MulaolaoBll . Dao
{
    public class MaterialProcurementSummaryDao
    {
        /// <summary>
        /// 生成337
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool GenerateGun ( string oddNum )
        {
            MulaolaoLibrary . MaterialProcurementSummaryBH _model = new MulaolaoLibrary . MaterialProcurementSummaryBH ( );
            _model . BH001 = oddNum;
            ArrayList SQLString = new ArrayList ( );
            DataTable de = SqlHelper . ExecuteDataTable ( "SELECT BH002,BH003,BH004 FROM R_PQBH WHERE BH001='" + _model . BH001 + "'" );
            DataTable da = GetDataTableOfGun ( );
            List<int> strList = new List<int> ( );
            StringBuilder strSql = new StringBuilder ( );
            if ( da != null && da . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    _model . BH003 = da . Rows [ i ] [ "YQ119" ] . ToString ( );
                    _model . BH004 = da . Rows [ i ] [ "YQ11" ] . ToString ( );
                    noSingle ( de ,_model ,strList );
                    _model . BH005 = string . IsNullOrEmpty ( da . Rows [ i ] [ "YQ109" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "YQ109" ] . ToString ( ) );
                    _model . BH009 = string . IsNullOrEmpty ( da . Rows [ i ] [ "YQ" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "YQ" ] . ToString ( ) );
                    if ( de . Select ( "BH002='" + _model . BH002 + "'" ) . Length > 0 )
                        SQLString . Add ( updateGun ( _model ,strSql ) );
                    else
                        SQLString . Add ( addGun ( _model ,strSql ) );
                }
            }
            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                SQLString . Clear ( );
                strList . Clear ( );
                de = SqlHelper . ExecuteDataTable ( "SELECT BH002,BH003,BH004 FROM R_PQBH WHERE BH001='" + _model . BH001 + "'" );
                da = GetDataTableOfPlanGun ( );
                if ( da != null && da . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < da . Rows . Count ; i++ )
                    {
                        _model . BH003 = "滚漆";
                        _model . BH004 = da . Rows [ i ] [ "MZ023" ] . ToString ( );
                        noSingle ( de , _model , strList );
                        _model . BH006 = string . IsNullOrEmpty ( da . Rows [ i ] [ "MZ0" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "MZ0" ] . ToString ( ) );
                        _model . BH010 = string . IsNullOrEmpty ( da . Rows [ i ] [ "MZ1" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "MZ1" ] . ToString ( ) );
                        if ( de . Select ( "BH002='" + _model . BH002 + "'" ) . Length > 0 )
                            SQLString . Add ( updatePlanGun ( _model , strSql ) );
                        else
                            SQLString . Add ( addPlanGun ( _model , strSql ) );
                    }
                }
            }
            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                SQLString . Clear ( );
                strList . Clear ( );
                de = SqlHelper . ExecuteDataTable ( "SELECT BH002,BH003,BH004 FROM R_PQBH WHERE BH001='" + _model . BH001 + "'" );
                da = GetDataTableOfAcGun ( );
                if ( da != null && da . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < da . Rows . Count ; i++ )
                    {
                        _model . BH003 = da . Rows [ i ] [ "AC02" ] . ToString ( );
                        _model . BH004 = da . Rows [ i ] [ "PZ014" ] . ToString ( );
                        noSingle ( de , _model , strList );
                        _model . BH007 = string . IsNullOrEmpty ( da . Rows [ i ] [ "PZ0" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "PZ0" ] . ToString ( ) );
                        _model . BH011 = string . IsNullOrEmpty ( da . Rows [ i ] [ "PZ1" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "PZ1" ] . ToString ( ) );
                        if ( de . Select ( "BH002='" + _model . BH002 + "'" ) . Length > 0 )
                            SQLString . Add ( updateAcGun ( _model , strSql ) );
                        else
                            SQLString . Add ( addAcGun ( _model , strSql ) );
                    }
                }
            }
            else
                deleteOfGun ( _model . BH001 );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void noSingle ( DataTable de , MulaolaoLibrary . MaterialProcurementSummaryBH _model , List<int> strList )
        {
            string maxNum = "";
            if ( de != null && de . Rows . Count > 0 )
            {
                if ( de . Select ( "BH003='" + _model . BH003 + "' AND BH004='" + _model . BH004 + "'" ) . Length > 0 )
                {
                    _model . BH002 = de . Select ( "BH003='" + _model . BH003 + "' AND BH004='" + _model . BH004 + "'" ) [ 0 ] [ "BH002" ] . ToString ( );
                    strList . Add ( Convert . ToInt32 ( _model . BH002 ) );
                }
                else
                {
                    maxNum = de . Compute ( "MAX(BH002)" , null ) . ToString ( );
                    if ( !string . IsNullOrEmpty ( maxNum ) )
                    {
                        if ( strList . Contains ( Convert . ToInt32 ( maxNum ) ) )
                        {
                            maxNum = strList . Max ( ) . ToString ( );
                            if ( Convert . ToInt32 ( maxNum ) < 9 )
                                _model . BH002 = "00" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else if ( Convert . ToInt32 ( maxNum ) >= 9 && Convert . ToInt32 ( maxNum ) < 99 )
                                _model . BH002 = "0" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else
                                _model . BH002 = ( Convert . ToInt32 ( maxNum ) + 1 ) . ToString ( );

                            strList . Add ( Convert . ToInt32 ( _model . BH002 ) );
                        }
                        else
                        {
                            strList . Add ( Convert . ToInt32 ( maxNum ) );
                            if ( Convert . ToInt32 ( maxNum ) < 9 )
                                _model . BH002 = "00" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else if ( Convert . ToInt32 ( maxNum ) >= 9 && Convert . ToInt32 ( maxNum ) < 99 )
                                _model . BH002 = "0" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else
                                _model . BH002 = ( Convert . ToInt32 ( maxNum ) + 1 ) . ToString ( );
                        }
                        strList . Add ( Convert . ToInt32 ( _model . BH002 ) );
                    }
                    else
                    {
                        if ( strList . Count > 0 )
                        {
                            maxNum = strList . Max ( ) . ToString ( );
                            if ( Convert . ToInt32 ( maxNum ) < 9 )
                                _model . BH002 = "00" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else if ( Convert . ToInt32 ( maxNum ) >= 9 && Convert . ToInt32 ( maxNum ) < 99 )
                                _model . BH002 = "0" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else
                                _model . BH002 = ( Convert . ToInt32 ( maxNum ) + 1 ) . ToString ( );
                        }
                        else
                            _model . BH002 = "001";

                        strList . Add ( Convert . ToInt32 ( _model . BH002 ) );
                    }
                }
            }
            else
            {
                if ( strList . Count > 0 )
                {
                    maxNum = strList . Max ( ) . ToString ( );
                    if ( Convert . ToInt32 ( maxNum ) < 9 )
                        _model . BH002 = "00" + ( Convert . ToInt32 ( maxNum ) + 1 );
                    else if ( Convert . ToInt32 ( maxNum ) >= 9 && Convert . ToInt32 ( maxNum ) < 99 )
                        _model . BH002 = "0" + ( Convert . ToInt32 ( maxNum ) + 1 );
                    else
                        _model . BH002 = ( Convert . ToInt32 ( maxNum ) + 1 ) . ToString ( );
                }
                else
                    _model . BH002 = "001";
                strList . Add ( Convert . ToInt32 ( _model . BH002 ) );
            }
        }

        string updateGun ( MulaolaoLibrary . MaterialProcurementSummaryBH _model , StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQBH SET " );
            strSql . AppendFormat ( "BH003='{0}'," ,_model . BH003 );
            strSql . AppendFormat ( "BH004='{0}'," ,_model . BH004 );
            strSql . AppendFormat ( "BH005='{0}'," , _model . BH005 );
            strSql . AppendFormat ( "BH009='{0}'" , _model . BH009 );
            strSql . AppendFormat ( " WHERE BH001='{0}'" , _model . BH001 );
            strSql . AppendFormat ( " AND BH002='{0}' " , _model . BH002 );
            //SqlParameter [ ] parameter = {
            //    new SqlParameter("@BH001",SqlDbType.NVarChar,20),
            //    new SqlParameter("@BH002",SqlDbType.NVarChar,20),
            //    new SqlParameter("@BH003",SqlDbType.NVarChar,20),
            //    new SqlParameter("@BH004",SqlDbType.NVarChar,20),
            //    new SqlParameter("@BH005",SqlDbType.Decimal,11),
            //    new SqlParameter("@BH009",SqlDbType.Decimal,11)
            //};
            //parameter [ 0 ] . Value = _model . BH001;
            //parameter [ 1 ] . Value = _model . BH002;
            //parameter [ 2 ] . Value = _model . BH003;
            //parameter [ 3 ] . Value = _model . BH004;
            //parameter [ 4 ] . Value = _model . BH005;
            //parameter [ 5 ] . Value = _model . BH009;

            return strSql . ToString ( );
        }
        string addGun ( MulaolaoLibrary . MaterialProcurementSummaryBH _model , StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQBH (" );
            strSql . Append ( "BH001,BH002,BH003,BH004,BH005,BH009)" );
            strSql . Append ( " VALUES (" );
            strSql . AppendFormat ( "'{0}','{1}','{2}','{3}','{4}','{5}')" , _model . BH001 , _model . BH002 , _model . BH003 , _model . BH004 , _model . BH005 , _model . BH009 );
            //SqlParameter [ ] parameter = {
            //    new SqlParameter("@BH001",SqlDbType.NVarChar,20),
            //    new SqlParameter("@BH002",SqlDbType.NVarChar,20),
            //    new SqlParameter("@BH003",SqlDbType.NVarChar,20),
            //    new SqlParameter("@BH004",SqlDbType.NVarChar,20),
            //    new SqlParameter("@BH005",SqlDbType.Decimal,11),
            //    new SqlParameter("@BH009",SqlDbType.Decimal,11)
            //};
            //parameter [ 0 ] . Value = _model . BH001;
            //parameter [ 1 ] . Value = _model . BH002;
            //parameter [ 2 ] . Value = _model . BH003;
            //parameter [ 3 ] . Value = _model . BH004;
            //parameter [ 4 ] . Value = _model . BH005;
            //parameter [ 5 ] . Value = _model . BH009;

            return strSql . ToString ( );
        }

        string updatePlanGun ( MulaolaoLibrary . MaterialProcurementSummaryBH _model , StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQBH SET " );
            strSql . AppendFormat ( "BH003='{0}'," , _model . BH003 );
            strSql . AppendFormat ( "BH004='{0}'," , _model . BH004 );
            strSql . AppendFormat ( "BH006='{0}'," , _model . BH006 );
            strSql . AppendFormat ( "BH010='{0}'" , _model . BH010 );
            strSql . AppendFormat ( " WHERE BH001='{0}'" , _model . BH001 );
            strSql . AppendFormat ( " AND BH002='{0}'" , _model . BH002 );
            //SqlParameter [ ] parameter = {
            //    new SqlParameter("@BH001",SqlDbType.NVarChar,20),
            //    new SqlParameter("@BH002",SqlDbType.NVarChar,20),
            //    new SqlParameter("@BH003",SqlDbType.NVarChar,20),
            //    new SqlParameter("@BH004",SqlDbType.NVarChar,20),
            //    new SqlParameter("@BH006",SqlDbType.Decimal,11),
            //    new SqlParameter("@BH010",SqlDbType.Decimal,11)
            //};
            //parameter [ 0 ] . Value = _model . BH001;
            //parameter [ 1 ] . Value = _model . BH002;
            //parameter [ 2 ] . Value = _model . BH003;
            //parameter [ 3 ] . Value = _model . BH004;
            //parameter [ 4 ] . Value = _model . BH006;
            //parameter [ 5 ] . Value = _model . BH010;

            return strSql . ToString ( );
        }
        string addPlanGun ( MulaolaoLibrary . MaterialProcurementSummaryBH _model , StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQBH (" );
            strSql . Append ( "BH001,BH002,BH003,BH004,BH006,BH010)" );
            strSql . Append ( " VALUES (" );
            strSql . AppendFormat ( "'{0}','{1}','{2}','{3}','{4}','{5}')" , _model . BH001 , _model . BH002 , _model . BH003 , _model . BH004 , _model . BH006 , _model . BH010 );
            //SqlParameter [ ] parameter = {
            //    new SqlParameter("@BH001",SqlDbType.NVarChar,20),
            //    new SqlParameter("@BH002",SqlDbType.NVarChar,20),
            //    new SqlParameter("@BH003",SqlDbType.NVarChar,20),
            //    new SqlParameter("@BH004",SqlDbType.NVarChar,20),
            //    new SqlParameter("@BH006",SqlDbType.Decimal,11),
            //    new SqlParameter("@BH010",SqlDbType.Decimal,11)
            //};
            //parameter [ 0 ] . Value = _model . BH001;
            //parameter [ 1 ] . Value = _model . BH002;
            //parameter [ 2 ] . Value = _model . BH003;
            //parameter [ 3 ] . Value = _model . BH004;
            //parameter [ 4 ] . Value = _model . BH006;
            //parameter [ 5 ] . Value = _model . BH010;

            return strSql . ToString ( );
        }

        string updateAcGun ( MulaolaoLibrary . MaterialProcurementSummaryBH _model , StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQBH SET " );
            strSql . AppendFormat ( "BH003='{0}'," , _model . BH003 );
            strSql . AppendFormat ( "BH004='{0}'," , _model . BH004 );
            strSql . AppendFormat ( "BH007='{0}'," , _model . BH007 );
            strSql . AppendFormat ( "BH011='{0}'" , _model . BH011 );
            strSql . AppendFormat ( " WHERE BH001='{0}'" , _model . BH001 );
            strSql . AppendFormat ( " AND BH002='{0}'" , _model . BH002 );
            //SqlParameter [ ] parameter = {
            //    new SqlParameter("@BH001",SqlDbType.NVarChar,20),
            //    new SqlParameter("@BH002",SqlDbType.NVarChar,20),
            //    new SqlParameter("@BH003",SqlDbType.NVarChar,20),
            //    new SqlParameter("@BH004",SqlDbType.NVarChar,20),
            //    new SqlParameter("@BH007",SqlDbType.Decimal,11),
            //    new SqlParameter("@BH011",SqlDbType.Decimal,11)
            //};
            //parameter [ 0 ] . Value = _model . BH001;
            //parameter [ 1 ] . Value = _model . BH002;
            //parameter [ 2 ] . Value = _model . BH003;
            //parameter [ 3 ] . Value = _model . BH004;
            //parameter [ 4 ] . Value = _model . BH007;
            //parameter [ 5 ] . Value = _model . BH011;

            return strSql . ToString ( );
        }
        string addAcGun ( MulaolaoLibrary . MaterialProcurementSummaryBH _model , StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQBH (" );
            strSql . Append ( "BH001,BH002,BH003,BH004,BH007,BH011)" );
            strSql . Append ( " VALUES (" );
            strSql . AppendFormat ( "'{0}','{1}','{2}','{3}','{4}','{5}')" , _model . BH001 , _model . BH002 , _model . BH003 , _model . BH004 , _model . BH007 , _model . BH011 );
            //SqlParameter [ ] parameter = {
            //    new SqlParameter("@BH001",SqlDbType.NVarChar,20),
            //    new SqlParameter("@BH002",SqlDbType.NVarChar,20),
            //    new SqlParameter("@BH003",SqlDbType.NVarChar,20),
            //    new SqlParameter("@BH004",SqlDbType.NVarChar,20),
            //    new SqlParameter("@BH007",SqlDbType.Decimal,11),
            //    new SqlParameter("@BH011",SqlDbType.Decimal,11)
            //};
            //parameter [ 0 ] . Value = _model . BH001;
            //parameter [ 1 ] . Value = _model . BH002;
            //parameter [ 2 ] . Value = _model . BH003;
            //parameter [ 3 ] . Value = _model . BH004;
            //parameter [ 4 ] . Value = _model . BH007;
            //parameter [ 5 ] . Value = _model . BH011;

            return strSql . ToString ( );
        }

        /// <summary>
        /// 337漆
        /// </summary>
        /// <returns></returns>
        private DataTable GetDataTableOfGun ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT AC02 YQ119,AC04 YQ11,CONVERT(DECIMAL(18,0),SUM(AC10+ISNULL(AC27,0))) YQ109,CONVERT(DECIMAL(18,0),SUM(AC09*(AC10+ISNULL(AC27,0)))) YQ FROM R_PQAC WHERE AC16 LIKE 'R_337%' GROUP BY AC02,AC04 ORDER BY AC02,AC04" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 344漆
        /// </summary>
        /// <returns></returns>
        private DataTable GetDataTableOfPlanGun ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT ISNULL(MZ023,'') MZ023,CONVERT(DECIMAL(18,0),SUM(CASE WHEN MZ025=0 THEN 0 ELSE MZ022*MZ006*MZ026*MZ024/MZ025 END)) MZ0,CONVERT(DECIMAL(18,0),SUM(MZ022*MZ006*MZ026*MZ024)) MZ1 FROM R_PQMZ WHERE MZ107='厂内' GROUP BY ISNULL(MZ023,'')" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 346漆
        /// </summary>
        /// <returns></returns>
        private DataTable GetDataTableOfAcGun ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            //strSql . Append ( "SELECT PZ014,CONVERT(DECIMAL(18,0),SUM(CASE WHEN PZ015=0 THEN 0 ELSE PZ026*PZ017/PZ015 END)) PZ0,CONVERT(DECIMAL(18,0),SUM(PZ026*PZ017)) PZ1 FROM R_PQPZ GROUP BY PZ014" );
            strSql . Append ( "SELECT AC02,AC04 PZ014,CONVERT(DECIMAL(18,0),SUM(AD12)) PZ0,CONVERT(DECIMAL(18,0),SUM(AC09*AD12)) PZ1 FROM R_PQAD A INNER JOIN R_PQAC B ON A.AD01=B.AC18 WHERE (AD17 LIKE 'R_344%' OR AD17 LIKE 'R_346%' OR AD17='R_301' OR AD17='') GROUP BY AC04,AC02" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfGunList ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT * FROM R_PQBH" );
            strSql . Append ( " WHERE " + strWhere );
            strSql . Append ( "  ORDER BY BH003,BH004" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 保存337数据
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool saveOfGum ( DataTable table )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT * FROM R_PQBH WHERE 1=2" );

            return SqlHelper . UpdateTable ( table , strSql . ToString ( ) );
        }

        /// <summary>
        /// 删除337数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool deleteOfGun ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQBH" );
            strSql . Append ( " WHERE BH001=@BH001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@BH001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = oddNum;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) , parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }


        /// <summary>
        /// 生成338
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool GenerateOfJiao ( string oddNum )
        {
            MulaolaoLibrary . MaterialProcurementSummaryBI _model = new MulaolaoLibrary . MaterialProcurementSummaryBI ( );
            _model . BI001 = oddNum;
            ArrayList SQLString = new ArrayList ( );
            DataTable de = SqlHelper . ExecuteDataTable ( "SELECT BI002,BI004,BI006,BI007,BI009,BI012,BI013,BI014 FROM R_PQBI WHERE BI001='" + _model . BI001 + "'" );
            DataTable da = GetDataTableOfJiao ( );
            List<int> strList = new List<int> ( );
            StringBuilder strSql = new StringBuilder ( );
            if ( da != null && da . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    _model . BI003 = da . Rows [ i ] [ "AC01" ] . ToString ( );
                    _model . BI004 = da . Rows [ i ] [ "AC02" ] . ToString ( );
                    _model . BI005 = string . Empty;
                    _model . BI006 = da . Rows [ i ] [ "AC04" ] . ToString ( );
                    _model . BI007 = da . Rows [ i ] [ "AC05" ] . ToString ( );              
                    _model . BI008 = da . Rows [ i ] [ "AC06" ] . ToString ( );
                    _model . BI009 = string . IsNullOrEmpty ( da . Rows [ i ] [ "AC09" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "AC09" ] . ToString ( ) );
                    _model . BI010 = string . IsNullOrEmpty ( da . Rows [ i ] [ "AC1" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "AC1" ] . ToString ( ) );
                    _model . BI012 = string . IsNullOrEmpty ( da . Rows [ i ] [ "AC07" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "AC07" ] . ToString ( ) );
                    _model . BI013 = string . IsNullOrEmpty ( da . Rows [ i ] [ "AC12" ] . ToString ( ) ) == true ? DateTime . Now : Convert . ToDateTime ( da . Rows [ i ] [ "AC12" ] . ToString ( ) );
                    _model . BI014 = da . Rows [ i ] [ "AC11" ] . ToString ( );
                    _model . BI015 = string . Empty;
                    _model . BI016 = string . IsNullOrEmpty ( da . Rows [ i ] [ "AC20" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "AC20" ] . ToString ( ) );
                    _model . BI017 = da . Rows [ i ] [ "AC19" ] . ToString ( );
                    noSingleOfJiao ( de , _model , strList );

                    if ( de . Select ( "BI004='" + _model . BI004 + "' AND BI006='" + _model . BI006 + "' AND BI007='" + _model . BI007 + "' AND BI009='" + _model . BI009 + "'  AND BI012='" + _model . BI012 + "'  AND BI013='" + _model . BI013 + "'  AND BI014='" + _model . BI014 + "'" ) . Length > 0 )
                        SQLString . Add ( updateOfJiao ( _model , strSql ) );
                    else
                        SQLString . Add ( addOfJiao ( _model , strSql ) );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 338
        /// </summary>
        /// <returns></returns>
        private DataTable GetDataTableOfJiao ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "WITH CET AS (" );
            strSql . Append ( "SELECT AC01,AC02,AC04,AC05,AC06,CASE WHEN ISNULL(AC10,0)+ISNULL(AC27,0)=0 THEN 0 ELSE CONVERT(FLOAT,(ISNULL(AC03,0)+ISNULL(AC26,0))/(ISNULL(AC10,0)+ISNULL(AC27,0))) END AC07,CONVERT(FLOAT,CONVERT(DECIMAL(18,2),AC09)) AC09,AC11,AC12,ISNULL(AC19,'') AC19,ISNULL ( AC20 , 0 ) AC20 , ISNULL(AC03,0)+ISNULL(AC26,0)-SUM(ISNULL(AD05,0)+ISNULL(AD20,0)) AC0,ISNULL(AC10,0)+ISNULL(AC27,0)-SUM(ISNULL(AD12,0)+ISNULL(AD21,0)) AC1 FROM R_PQAC A LEFT JOIN R_PQAD B ON A.AC18=B.AD01 WHERE AC16 LIKE 'R_338%' GROUP BY AC01,AC02,AC04,AC05,AC06,AC07,AC09,AC11,AC12,AC19,AC20,AC03,ISNULL(AC26,0),AC10,ISNULL(AC27,0))" );
            strSql . Append ( "SELECT AC01,AC02,AC04,AC05,AC06,AC07,AC09,AC11,AC12,AC19,AC20,SUM(AC0) AC0,SUM(AC1) AC1 FROM CET GROUP BY AC01,AC02,AC04,AC05,AC06,AC07,AC09,AC11,AC12,AC19,AC20" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        void noSingleOfJiao ( DataTable de , MulaolaoLibrary . MaterialProcurementSummaryBI _model , List<int> strList )
        {
            string maxNum = "";
            if ( de != null && de . Rows . Count > 0 )
            {
                if ( de . Select ( "BI004='" + _model . BI004 + "' AND BI006='" + _model . BI006 + "' AND BI007='" + _model . BI007 + "' AND BI009='" + _model . BI009 + "'  AND BI012='" + _model . BI012 + "'  AND BI013='" + _model . BI013 + "'  AND BI014='" + _model . BI014 + "'" ) . Length > 0 )
                {
                    _model . BI002 = de . Select ( "BI004='" + _model . BI004 + "' AND BI006='" + _model . BI006 + "' AND BI007='" + _model . BI007 + "' AND BI009='" + _model . BI009 + "'  AND BI012='" + _model . BI012 + "'  AND BI013='" + _model . BI013 + "'  AND BI014='" + _model . BI014 + "'" ) [ 0 ] [ "BI002" ] . ToString ( );
                    strList . Add ( Convert . ToInt32 ( _model . BI002 ) );
                }
                else
                {
                    maxNum = de . Compute ( "MAX(BI002)" , null ) . ToString ( );
                    if ( !string . IsNullOrEmpty ( maxNum ) )
                    {
                        if ( strList . Contains ( Convert . ToInt32 ( maxNum ) ) )
                        {
                            maxNum = strList . Max ( ) . ToString ( );
                            if ( Convert . ToInt32 ( maxNum ) < 9 )
                                _model . BI002 = "00" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else if ( Convert . ToInt32 ( maxNum ) >= 9 && Convert . ToInt32 ( maxNum ) < 99 )
                                _model . BI002 = "0" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else
                                _model . BI002 = ( Convert . ToInt32 ( maxNum ) + 1 ) . ToString ( );

                            strList . Add ( Convert . ToInt32 ( _model . BI002 ) );
                        }
                        else
                        {
                            strList . Add ( Convert . ToInt32 ( maxNum ) );
                            if ( Convert . ToInt32 ( maxNum ) < 9 )
                                _model . BI002 = "00" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else if ( Convert . ToInt32 ( maxNum ) >= 9 && Convert . ToInt32 ( maxNum ) < 99 )
                                _model . BI002 = "0" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else
                                _model . BI002 = ( Convert . ToInt32 ( maxNum ) + 1 ) . ToString ( );
                        }
                        strList . Add ( Convert . ToInt32 ( _model . BI002 ) );
                    }
                    else
                    {
                        if ( strList . Count > 0 )
                        {
                            maxNum = strList . Max ( ) . ToString ( );
                            if ( Convert . ToInt32 ( maxNum ) < 9 )
                                _model . BI002 = "00" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else if ( Convert . ToInt32 ( maxNum ) >= 9 && Convert . ToInt32 ( maxNum ) < 99 )
                                _model . BI002 = "0" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else
                                _model . BI002 = ( Convert . ToInt32 ( maxNum ) + 1 ) . ToString ( );
                        }
                        else
                            _model . BI002 = "001";

                        strList . Add ( Convert . ToInt32 ( _model . BI002 ) );
                    }
                }
            }
            else
            {
                if ( strList . Count > 0 )
                {
                    maxNum = strList . Max ( ) . ToString ( );
                    if ( Convert . ToInt32 ( maxNum ) < 9 )
                        _model . BI002 = "00" + ( Convert . ToInt32 ( maxNum ) + 1 );
                    else if ( Convert . ToInt32 ( maxNum ) >= 9 && Convert . ToInt32 ( maxNum ) < 99 )
                        _model . BI002 = "0" + ( Convert . ToInt32 ( maxNum ) + 1 );
                    else
                        _model . BI002 = ( Convert . ToInt32 ( maxNum ) + 1 ) . ToString ( );
                }
                else
                    _model . BI002 = "001";
                strList . Add ( Convert . ToInt32 ( _model . BI002 ) );
            }
        }

        string updateOfJiao ( MulaolaoLibrary . MaterialProcurementSummaryBI _model , StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQBI SET " );
            strSql . AppendFormat ( "BI003='{0}'," , _model . BI003 );
            strSql . AppendFormat ( "BI004='{0}'," , _model . BI004 );
            strSql . AppendFormat ( "BI005='{0}'," , _model . BI005 );
            strSql . AppendFormat ( "BI006='{0}'," , _model . BI006 );
            strSql . AppendFormat ( "BI007='{0}'," , _model . BI007 );
            strSql . AppendFormat ( "BI008='{0}'," , _model . BI008 );
            strSql . AppendFormat ( "BI009='{0}'," , _model . BI009 );
            strSql . AppendFormat ( "BI010='{0}'," , _model . BI010 );
            strSql . AppendFormat ( "BI012='{0}'," , _model . BI012 );
            strSql . AppendFormat ( "BI013='{0}'," , _model . BI013 );
            strSql . AppendFormat ( "BI014='{0}'," , _model . BI014 );
            strSql . AppendFormat ( "BI015='{0}'," , _model . BI015 );
            strSql . AppendFormat ( "BI016='{0}'," , _model . BI016 );
            strSql . AppendFormat ( "BI017='{0}'" , _model . BI017 );
            strSql . AppendFormat ( " WHERE BI001='{0}'" , _model . BI001 );
            strSql . AppendFormat ( " AND BI002='{0}'" , _model . BI002 );

            return strSql . ToString ( );
        }
        string addOfJiao ( MulaolaoLibrary . MaterialProcurementSummaryBI _model , StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQBI (BI001,BI002,BI003,BI004,BI005,BI006,BI007,BI008,BI009,BI010,BI012,BI013,BI014,BI015,BI016,BI017)" );
            strSql . AppendFormat ( " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}')" , _model . BI001 , _model . BI002 , _model . BI003 , _model . BI004 , _model . BI005 , _model . BI006 , _model . BI007 , _model . BI008 , _model . BI009 , _model . BI010 , _model . BI012 , _model . BI013 , _model . BI014 , _model . BI015 , _model . BI016 , _model . BI017 );

            return strSql . ToString ( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfJiaoList ( string strWhere )
        {
            //BI001,BI002,BI003,BI004,BI005,BI006,BI007,BI008,BI009,BI010,BI011,CONVERT(FLOAT,BI012) BI012,BI013,BI014,BI015,BI016,BI017,BI018
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT * FROM R_PQBI" );
            strSql . Append ( " WHERE " + strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 删除338数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool deleteOfJiao ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQBI" );
            strSql . Append ( " WHERE BI001=@BI001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@BI001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = oddNum;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) , parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 保存338数据
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool saveOfJiao ( DataTable table )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT * FROM R_PQBI" );
            strSql . Append ( " WHERE 1=2" );

            return SqlHelper . UpdateTable ( table , strSql . ToString ( ) );
        }


        /// <summary>
        /// 343生成
        /// </summary>
        /// <returns></returns>
        public bool GenerateChe ( string oddNum )
        {
            MulaolaoLibrary . MaterialProcurementSummaryBJ _model = new MulaolaoLibrary . MaterialProcurementSummaryBJ ( );
            _model . BJ001 = oddNum;
            ArrayList SQLString = new ArrayList ( );
            DataTable de = SqlHelper . ExecuteDataTable ( "SELECT BJ002,BJ004,BJ006,BJ007,BJ009,BJ012,BJ013,BJ014 FROM R_PQBJ WHERE BJ001='" + _model . BJ001 + "'" );
            DataTable da = GetDataTableOfChe ( );
            List<int> strList = new List<int> ( );
            StringBuilder strSql = new StringBuilder ( );
            if ( da != null && da . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    _model . BJ003 = da . Rows [ i ] [ "AC01" ] . ToString ( );
                    _model . BJ004 = da . Rows [ i ] [ "AC02" ] . ToString ( );
                    _model . BJ005 = string . Empty;
                    _model . BJ006 = da . Rows [ i ] [ "AC04" ] . ToString ( );
                    _model . BJ007 = da . Rows [ i ] [ "AC05" ] . ToString ( );                 
                    _model . BJ008 = da . Rows [ i ] [ "AC06" ] . ToString ( );
                    _model . BJ009 = string . IsNullOrEmpty ( da . Rows [ i ] [ "AC09" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "AC09" ] . ToString ( ) );
                    _model . BJ010 = string . IsNullOrEmpty ( da . Rows [ i ] [ "AC1" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "AC1" ] . ToString ( ) );
                    _model . BJ012 = string . IsNullOrEmpty ( da . Rows [ i ] [ "AC07" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "AC07" ] . ToString ( ) );
                    _model . BJ013 = string . IsNullOrEmpty ( da . Rows [ i ] [ "AC12" ] . ToString ( ) ) == true ? DateTime . Now : Convert . ToDateTime ( da . Rows [ i ] [ "AC12" ] . ToString ( ) );
                    _model . BJ014 = da . Rows [ i ] [ "AC11" ] . ToString ( );
                    _model . BJ015 = string . Empty;
                    _model . BJ016 = string . IsNullOrEmpty ( da . Rows [ i ] [ "AC20" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "AC20" ] . ToString ( ) );
                    _model . BJ017 = da . Rows [ i ] [ "AC19" ] . ToString ( );
                    noSingleOfChe ( de , _model , strList );
                    if ( de . Select ( "BJ004='" + _model . BJ004 + "' AND BJ006='" + _model . BJ006 + "' AND BJ007='" + _model . BJ007 + "' AND BJ009='" + _model . BJ009 + "' AND BJ012='" + _model . BJ012 + "' AND BJ013='" + _model . BJ013 + "' AND BJ014='" + _model . BJ014 + "'" ) . Length > 0 )
                        SQLString . Add ( updateOfChe ( _model , strSql ) );
                    else
                        SQLString . Add ( addOfChe ( _model , strSql ) );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 343
        /// </summary>
        /// <returns></returns>
        private DataTable GetDataTableOfChe ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "WITH CET AS (" );
            strSql . Append ( "SELECT AC01,AC02,AC04,AC05,AC06,CONVERT(FLOAT,AC07) AC07,CONVERT(FLOAT,CONVERT(DECIMAL(18,2),AC09)) AC09,AC11,AC12,ISNULL(AC19,'') AC19,ISNULL ( AC20 , 0 ) AC20 , ISNULL(AC03,0)+ISNULL(AC26,0)-SUM(ISNULL(AD05,0)+ISNULL(AD20,0)) AC0,CONVERT(DECIMAL(18,0),ISNULL(AC10,0)+ISNULL(AC27,0)-SUM(ISNULL(AD12,0)+ISNULL(AD21,0))) AC1 FROM R_PQAC A LEFT JOIN R_PQAD B ON A.AC18=B.AD01 WHERE AC16 LIKE 'R_343%' GROUP BY AC01,AC02,AC04,AC05,AC06,AC07,AC09,AC11,AC12,AC19,AC20,AC03,ISNULL(AC26,0),AC10,ISNULL(AC27,0))" );
            strSql . Append ( "SELECT AC01,AC02,AC04,AC05,AC06,AC07,AC09,AC11,AC12,AC19,AC20,SUM(AC0) AC0,SUM(AC1) AC1 FROM CET GROUP BY AC01,AC02,AC04,AC05,AC06,AC07,AC09,AC11,AC12,AC19,AC20" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        void noSingleOfChe ( DataTable de , MulaolaoLibrary . MaterialProcurementSummaryBJ _model , List<int> strList )
        {
            string maxNum = "";
            if ( de != null && de . Rows . Count > 0 )
            {
                if ( de . Select ( "BJ004='" + _model . BJ004 + "' AND BJ006='" + _model . BJ006 + "' AND BJ007='" + _model . BJ007 + "' AND BJ009='" + _model . BJ009 + "' AND BJ012='" + _model . BJ012 + "' AND BJ013='" + _model . BJ013 + "' AND BJ014='" + _model . BJ014 + "'" ) . Length > 0 )
                {
                    _model . BJ002 = de . Select ( "BJ004='" + _model . BJ004 + "' AND BJ006='" + _model . BJ006 + "' AND BJ007='" + _model . BJ007 + "' AND BJ009='" + _model . BJ009 + "' AND BJ012='" + _model . BJ012 + "' AND BJ013='" + _model . BJ013 + "' AND BJ014='" + _model . BJ014 + "'" ) [ 0 ] [ "BJ002" ] . ToString ( );
                    strList . Add ( Convert . ToInt32 ( _model . BJ002 ) );
                }
                else
                {
                    maxNum = de . Compute ( "MAX(BJ002)" , null ) . ToString ( );
                    if ( !string . IsNullOrEmpty ( maxNum ) )
                    {
                        if ( strList . Contains ( Convert . ToInt32 ( maxNum ) ) )
                        {
                            maxNum = strList . Max ( ) . ToString ( );
                            if ( Convert . ToInt32 ( maxNum ) < 9 )
                                _model . BJ002 = "00" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else if ( Convert . ToInt32 ( maxNum ) >= 9 && Convert . ToInt32 ( maxNum ) < 99 )
                                _model . BJ002 = "0" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else
                                _model . BJ002 = ( Convert . ToInt32 ( maxNum ) + 1 ) . ToString ( );

                            strList . Add ( Convert . ToInt32 ( _model . BJ002 ) );
                        }
                        else
                        {
                            strList . Add ( Convert . ToInt32 ( maxNum ) );
                            if ( Convert . ToInt32 ( maxNum ) < 9 )
                                _model . BJ002 = "00" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else if ( Convert . ToInt32 ( maxNum ) >= 9 && Convert . ToInt32 ( maxNum ) < 99 )
                                _model . BJ002 = "0" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else
                                _model . BJ002 = ( Convert . ToInt32 ( maxNum ) + 1 ) . ToString ( );
                        }
                        strList . Add ( Convert . ToInt32 ( _model . BJ002 ) );
                    }
                    else
                    {
                        if ( strList . Count > 0 )
                        {
                            maxNum = strList . Max ( ) . ToString ( );
                            if ( Convert . ToInt32 ( maxNum ) < 9 )
                                _model . BJ002 = "00" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else if ( Convert . ToInt32 ( maxNum ) >= 9 && Convert . ToInt32 ( maxNum ) < 99 )
                                _model . BJ002 = "0" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else
                                _model . BJ002 = ( Convert . ToInt32 ( maxNum ) + 1 ) . ToString ( );
                        }
                        else
                            _model . BJ002 = "001";

                        strList . Add ( Convert . ToInt32 ( _model . BJ002 ) );
                    }
                }
            }
            else
            {
                if ( strList . Count > 0 )
                {
                    maxNum = strList . Max ( ) . ToString ( );
                    if ( Convert . ToInt32 ( maxNum ) < 9 )
                        _model . BJ002 = "00" + ( Convert . ToInt32 ( maxNum ) + 1 );
                    else if ( Convert . ToInt32 ( maxNum ) >= 9 && Convert . ToInt32 ( maxNum ) < 99 )
                        _model . BJ002 = "0" + ( Convert . ToInt32 ( maxNum ) + 1 );
                    else
                        _model . BJ002 = ( Convert . ToInt32 ( maxNum ) + 1 ) . ToString ( );
                }
                else
                    _model . BJ002 = "001";
                strList . Add ( Convert . ToInt32 ( _model . BJ002 ) );
            }
        }

        string updateOfChe ( MulaolaoLibrary . MaterialProcurementSummaryBJ _model , StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQBJ SET " );
            strSql . AppendFormat ( "BJ003='{0}'," , _model . BJ003 );
            strSql . AppendFormat ( "BJ004='{0}'," , _model . BJ004 );
            strSql . AppendFormat ( "BJ005='{0}'," , _model . BJ005 );
            strSql . AppendFormat ( "BJ006='{0}'," , _model . BJ006 );
            strSql . AppendFormat ( "BJ007='{0}'," , _model . BJ007 );
            strSql . AppendFormat ( "BJ008='{0}'," , _model . BJ008 );
            strSql . AppendFormat ( "BJ009='{0}'," , _model . BJ009 );
            strSql . AppendFormat ( "BJ010='{0}'," , _model . BJ010 );
            strSql . AppendFormat ( "BJ012='{0}'," , _model . BJ012 );
            strSql . AppendFormat ( "BJ013='{0}'," , _model . BJ013 );
            strSql . AppendFormat ( "BJ014='{0}'," , _model . BJ014 );
            strSql . AppendFormat ( "BJ015='{0}'," , _model . BJ015 );
            strSql . AppendFormat ( "BJ016='{0}'," , _model . BJ016 );
            strSql . AppendFormat ( "BJ017='{0}'" , _model . BJ017 );
            strSql . AppendFormat ( " WHERE BJ001='{0}'" , _model . BJ001 );
            strSql . AppendFormat ( " AND BJ002='{0}'" , _model . BJ002 );

            return strSql . ToString ( );
        }
        string addOfChe ( MulaolaoLibrary . MaterialProcurementSummaryBJ _model , StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQBJ (BJ001,BJ002,BJ003,BJ004,BJ005,BJ006,BJ007,BJ008,BJ009,BJ010,BJ012,BJ013,BJ014,BJ015,BJ016,BJ017)" );
            strSql . AppendFormat ( " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}')" , _model . BJ001 , _model . BJ002 , _model . BJ003 , _model . BJ004 , _model . BJ005 , _model . BJ006 , _model . BJ007 , _model . BJ008 , _model . BJ009 , _model . BJ010 , _model . BJ012 , _model . BJ013 , _model . BJ014 , _model . BJ015 , _model . BJ016 , _model . BJ017 );

            return strSql . ToString ( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfCheList ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT BJ001,BJ002,BJ003,BJ004,BJ005,BJ006,BJ007,BJ008,BJ009,BJ010,BJ011,CONVERT(FLOAT,BJ012) BJ012,BJ013,BJ014,BJ015,BJ016,BJ017,BJ018 FROM R_PQBJ" );
            strSql . Append ( " WHERE " + strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 保存343数据
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool saveOfChe ( DataTable table )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT BJ001,BJ002,BJ003,BJ004,BJ005,BJ006,BJ007,BJ008,BJ009,BJ010,BJ011,BJ012,BJ013,BJ014,BJ015,BJ016,BJ017,BJ018 FROM R_PQBJ" );
            strSql . Append ( " WHERE 1=2" );

            return SqlHelper . UpdateTable ( table , strSql . ToString ( ) );
        }

        /// <summary>
        /// 删除343数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool deleteOfChe ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQBJ" );
            strSql . Append ( " WHERE BJ001=@BJ001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@BJ001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = oddNum;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) , parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }


        /// <summary>
        /// 347生成
        /// </summary>
        /// <returns></returns>
        public bool GenerateSu ( string oddNum )
        {
            MulaolaoLibrary . MaterialProcurementSummaryBK _model = new MulaolaoLibrary . MaterialProcurementSummaryBK ( );
            _model . BK001 = oddNum;
            ArrayList SQLString = new ArrayList ( );
            DataTable de = SqlHelper . ExecuteDataTable ( "SELECT BK002,BK004,BK006,BK007,BK009,BK012,BK013,BK014 FROM R_PQBK WHERE BK001='" + _model . BK001 + "'" );
            DataTable da = GetDataTableOfSu ( );
            List<int> strList = new List<int> ( );
            StringBuilder strSql = new StringBuilder ( );
            if ( da != null && da . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    _model . BK003 = da . Rows [ i ] [ "AC01" ] . ToString ( );
                    _model . BK004 = da . Rows [ i ] [ "AC02" ] . ToString ( );
                    _model . BK005 = string . Empty;
                    _model . BK006 = da . Rows [ i ] [ "AC04" ] . ToString ( );
                    _model . BK007 = da . Rows [ i ] [ "AC05" ] . ToString ( );                 
                    _model . BK008 = da . Rows [ i ] [ "AC06" ] . ToString ( );
                    _model . BK009 = string . IsNullOrEmpty ( da . Rows [ i ] [ "AC09" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "AC09" ] . ToString ( ) );
                    _model . BK010 = string . IsNullOrEmpty ( da . Rows [ i ] [ "AC1" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "AC1" ] . ToString ( ) );
                    _model . BK012 = string . IsNullOrEmpty ( da . Rows [ i ] [ "AC07" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "AC07" ] . ToString ( ) );
                    _model . BK013 = string . IsNullOrEmpty ( da . Rows [ i ] [ "AC12" ] . ToString ( ) ) == true ? DateTime . Now : Convert . ToDateTime ( da . Rows [ i ] [ "AC12" ] . ToString ( ) );
                    _model . BK014 = da . Rows [ i ] [ "AC11" ] . ToString ( );
                    _model . BK015 = string . Empty;
                    _model . BK016 = string . IsNullOrEmpty ( da . Rows [ i ] [ "AC20" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "AC20" ] . ToString ( ) );
                    _model . BK017 = da . Rows [ i ] [ "AC19" ] . ToString ( );
                    noSingleOfSu ( de , _model , strList );
                    if ( de . Select ( "BK004='" + _model . BK004 + "' AND BK006='" + _model . BK006 + "' AND BK007='" + _model . BK007 + "' AND BK009='" + _model . BK009 + "' AND BK012='" + _model . BK012 + "' AND BK013='" + _model . BK013 + "' AND BK014='" + _model . BK014 + "'" ) . Length > 0 )
                        SQLString . Add ( updateOfSu ( _model , strSql ) );
                    else
                        SQLString . Add ( addOfSu ( _model , strSql ) );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 347
        /// </summary>
        /// <returns></returns>
        private DataTable GetDataTableOfSu ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "WITH CET AS (" );
            strSql . Append ( "SELECT AC01,AC02,AC04,AC05,AC06,CONVERT(FLOAT,AC07) AC07,AC09,AC11,AC12,ISNULL(AC19,'') AC19,ISNULL ( AC20 , 0 ) AC20 , ISNULL(AC03,0)+ISNULL(AC26,0)-SUM(ISNULL(AD05,0)+ISNULL(AD20,0)) AC0,CONVERT(DECIMAL(18,0),ISNULL(AC10,0)+ISNULL(AC27,0)-SUM(ISNULL(AD12,0)+ISNULL(AD21,0))) AC1 FROM R_PQAC A LEFT JOIN R_PQAD B ON A.AC18=B.AD01 WHERE AC16 LIKE 'R_347%' GROUP BY AC01,AC02,AC04,AC05,AC06,AC07,AC09,AC11,AC12,AC19,AC20,AC03,AC10,ISNULL(AC26,0),ISNULL(AC27,0))" );
            strSql . Append ( "SELECT AC01,AC02,AC04,AC05,AC06,AC07,AC09,AC11,AC12,AC19,AC20,SUM(AC0) AC0,SUM(AC1) AC1 FROM CET GROUP BY AC01,AC02,AC04,AC05,AC06,AC07,AC09,AC11,AC12,AC19,AC20" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        void noSingleOfSu ( DataTable de , MulaolaoLibrary . MaterialProcurementSummaryBK _model , List<int> strList )
        {
            string maxNum = "";
            if ( de != null && de . Rows . Count > 0 )
            {
                if ( de . Select ( "BK004='" + _model . BK004 + "' AND BK006='" + _model . BK006 + "' AND BK007='" + _model . BK007 + "' AND BK009='" + _model . BK009 + "' AND BK012='" + _model . BK012 + "' AND BK013='" + _model . BK013 + "' AND BK014='" + _model . BK014 + "'" ) . Length > 0 )
                {
                    _model . BK002 = de . Select ( "BK004='" + _model . BK004 + "' AND BK006='" + _model . BK006 + "' AND BK007='" + _model . BK007 + "' AND BK009='" + _model . BK009 + "' AND BK012='" + _model . BK012 + "' AND BK013='" + _model . BK013 + "' AND BK014='" + _model . BK014 + "'" ) [ 0 ] [ "BK002" ] . ToString ( );
                    strList . Add ( Convert . ToInt32 ( _model . BK002 ) );
                }
                else
                {
                    maxNum = de . Compute ( "MAX(BK002)" , null ) . ToString ( );
                    if ( !string . IsNullOrEmpty ( maxNum ) )
                    {
                        if ( strList . Contains ( Convert . ToInt32 ( maxNum ) ) )
                        {
                            maxNum = strList . Max ( ) . ToString ( );
                            if ( Convert . ToInt32 ( maxNum ) < 9 )
                                _model . BK002 = "00" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else if ( Convert . ToInt32 ( maxNum ) >= 9 && Convert . ToInt32 ( maxNum ) < 99 )
                                _model . BK002 = "0" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else
                                _model . BK002 = ( Convert . ToInt32 ( maxNum ) + 1 ) . ToString ( );

                            strList . Add ( Convert . ToInt32 ( _model . BK002 ) );
                        }
                        else
                        {
                            strList . Add ( Convert . ToInt32 ( maxNum ) );
                            if ( Convert . ToInt32 ( maxNum ) < 9 )
                                _model . BK002 = "00" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else if ( Convert . ToInt32 ( maxNum ) >= 9 && Convert . ToInt32 ( maxNum ) < 99 )
                                _model . BK002 = "0" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else
                                _model . BK002 = ( Convert . ToInt32 ( maxNum ) + 1 ) . ToString ( );
                        }
                        strList . Add ( Convert . ToInt32 ( _model . BK002 ) );
                    }
                    else
                    {
                        if ( strList . Count > 0 )
                        {
                            maxNum = strList . Max ( ) . ToString ( );
                            if ( Convert . ToInt32 ( maxNum ) < 9 )
                                _model . BK002 = "00" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else if ( Convert . ToInt32 ( maxNum ) >= 9 && Convert . ToInt32 ( maxNum ) < 99 )
                                _model . BK002 = "0" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else
                                _model . BK002 = ( Convert . ToInt32 ( maxNum ) + 1 ) . ToString ( );
                        }
                        else
                            _model . BK002 = "001";

                        strList . Add ( Convert . ToInt32 ( _model . BK002 ) );
                    }
                }
            }
            else
            {
                if ( strList . Count > 0 )
                {
                    maxNum = strList . Max ( ) . ToString ( );
                    if ( Convert . ToInt32 ( maxNum ) < 9 )
                        _model . BK002 = "00" + ( Convert . ToInt32 ( maxNum ) + 1 );
                    else if ( Convert . ToInt32 ( maxNum ) >= 9 && Convert . ToInt32 ( maxNum ) < 99 )
                        _model . BK002 = "0" + ( Convert . ToInt32 ( maxNum ) + 1 );
                    else
                        _model . BK002 = ( Convert . ToInt32 ( maxNum ) + 1 ) . ToString ( );
                }
                else
                    _model . BK002 = "001";
                strList . Add ( Convert . ToInt32 ( _model . BK002 ) );
            }
        }

        string updateOfSu ( MulaolaoLibrary . MaterialProcurementSummaryBK _model , StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQBK SET " );
            strSql . AppendFormat ( "BK003='{0}'," , _model . BK003 );
            strSql . AppendFormat ( "BK004='{0}'," , _model . BK004 );
            strSql . AppendFormat ( "BK005='{0}'," , _model . BK005 );
            strSql . AppendFormat ( "BK006='{0}'," , _model . BK006 );
            strSql . AppendFormat ( "BK007='{0}'," , _model . BK007 );
            strSql . AppendFormat ( "BK008='{0}'," , _model . BK008 );
            strSql . AppendFormat ( "BK009='{0}'," , _model . BK009 );
            strSql . AppendFormat ( "BK010='{0}'," , _model . BK010 );
            strSql . AppendFormat ( "BK012='{0}'," , _model . BK012 );
            strSql . AppendFormat ( "BK013='{0}'," , _model . BK013 );
            strSql . AppendFormat ( "BK014='{0}'," , _model . BK014 );
            strSql . AppendFormat ( "BK015='{0}'," , _model . BK015 );
            strSql . AppendFormat ( "BK016='{0}'," , _model . BK016 );
            strSql . AppendFormat ( "BK017='{0}'" , _model . BK017 );
            strSql . AppendFormat ( " WHERE BK001='{0}'" , _model . BK001 );
            strSql . AppendFormat ( " AND BK002='{0}'" , _model . BK002 );

            return strSql . ToString ( );
        }
        string addOfSu ( MulaolaoLibrary . MaterialProcurementSummaryBK _model , StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQBK (BK001,BK002,BK003,BK004,BK005,BK006,BK007,BK008,BK009,BK010,BK012,BK013,BK014,BK015,BK016,BK017)" );
            strSql . AppendFormat ( " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}')" , _model . BK001 , _model . BK002 , _model . BK003 , _model . BK004 , _model . BK005 , _model . BK006 , _model . BK007 , _model . BK008 , _model . BK009 , _model . BK010 , _model . BK012 , _model . BK013 , _model . BK014 , _model . BK015 , _model . BK016 , _model . BK017 );

            return strSql . ToString ( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfSuList ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT BK001,BK002,BK003,BK004,BK005,BK006,BK007,BK008,BK009,BK010,BK011,CONVERT(FLOAT,BK012) BK012,BK013,BK014,BK015,BK016,BK017,BK018 FROM R_PQBK" );
            strSql . Append ( " WHERE " + strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 保存347数据
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool saveOfSu ( DataTable table )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT BK001,BK002,BK003,BK004,BK005,BK006,BK007,BK008,BK009,BK010,BK011,BK012,BK013,BK014,BK015,BK016,BK017,BK018 FROM R_PQBK" );
            strSql . Append ( " WHERE 1=2" );

            return SqlHelper . UpdateTable ( table , strSql . ToString ( ) );
        }

        /// <summary>
        /// 删除347数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool deleteOfSu ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQBK" );
            strSql . Append ( " WHERE BK001=@BK001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@BK001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = oddNum;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) , parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 341生成
        /// </summary>
        /// <returns></returns>
        public bool GenerateMu ( string oddNum )
        {
            MulaolaoLibrary . MaterialProcurementSummaryBL _model = new MulaolaoLibrary . MaterialProcurementSummaryBL ( );
            _model . BL001 = oddNum;
            ArrayList SQLString = new ArrayList ( );
            DataTable de = SqlHelper . ExecuteDataTable ( "SELECT BL002,BL006,BL007,BL009,BL012,BL013,BL014 FROM R_PQBL WHERE BL001='" + _model . BL001 + "'" );
            DataTable da = GetDataTableOfMu ( );
            List<int> strList = new List<int> ( );
            StringBuilder strSql = new StringBuilder ( );
            if ( da != null && da . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    _model . BL003 = da . Rows [ i ] [ "AC01" ] . ToString ( );
                    _model . BL004 = da . Rows [ i ] [ "AC02" ] . ToString ( );
                    _model . BL005 = string . Empty;
                    _model . BL006 = da . Rows [ i ] [ "AC04" ] . ToString ( );
                    _model . BL007 = da . Rows [ i ] [ "AC05" ] . ToString ( );
                    _model . BL008 = da . Rows [ i ] [ "AC06" ] . ToString ( );
                    _model . BL009 = string . IsNullOrEmpty ( da . Rows [ i ] [ "AC09" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "AC09" ] . ToString ( ) );
                    _model . BL010 = string . IsNullOrEmpty ( da . Rows [ i ] [ "AC1" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "AC1" ] . ToString ( ) );
                    _model . BL012 = string . IsNullOrEmpty ( da . Rows [ i ] [ "AC07" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "AC07" ] . ToString ( ) );
                    _model . BL013 = string . IsNullOrEmpty ( da . Rows [ i ] [ "AC12" ] . ToString ( ) ) == true ? DateTime . Now : Convert . ToDateTime ( da . Rows [ i ] [ "AC12" ] . ToString ( ) );
                    _model . BL014 = da . Rows [ i ] [ "AC11" ] . ToString ( );
                    _model . BL015 = string . Empty;
                    _model . BL016 = string . IsNullOrEmpty ( da . Rows [ i ] [ "AC20" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "AC20" ] . ToString ( ) );
                    _model . BL017 = da . Rows [ i ] [ "AC19" ] . ToString ( );
                    noSingleOfMu ( de , _model , strList );
                    if ( de . Select ( "BL006='" + _model . BL006 + "' AND BL007='" + _model . BL007 + "' AND BL009='" + _model . BL009 + "' AND BL012='" + _model . BL012 + "' AND BL013='" + _model . BL013 + "' AND BL014='" + _model . BL014 + "'" ) . Length > 0 )
                        SQLString . Add ( updateOfMu ( _model , strSql ) );
                    else
                        SQLString . Add ( addOfMu ( _model , strSql ) );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 341
        /// </summary>
        /// <returns></returns>
        private DataTable GetDataTableOfMu ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "WITH CET AS (" );
            strSql . Append ( "SELECT AC01,AC02,AC04,AC05,AC06,AC07,CONVERT(FLOAT,CONVERT(DECIMAL(18,2),AC09)) AC09,AC11,AC12,ISNULL(AC19,'') AC19,ISNULL ( AC20 , 0 ) AC20 , ISNULL(AC03,0)+ISNULL(AC26,0)-SUM(ISNULL(AD05,0)+ISNULL(AD20,0)) AC0,CONVERT(DECIMAL(18,4),ISNULL(AC10,0)+ISNULL(AC27,0)-SUM(ISNULL(AD12,0)+ISNULL(AD21,0))) AC1 FROM R_PQAC A LEFT JOIN R_PQAD B ON A.AC18=B.AD01 WHERE AC16 LIKE 'R_341%' GROUP BY AC01,AC02,AC04,AC05,AC06,AC07,AC09,AC11,AC12,AC19,AC20,AC03,ISNULL(AC26,0),ISNULL(AC27,0),AC10)" );
            strSql . Append ( "SELECT AC01,AC02,AC04,AC05,AC06,AC07,AC09,AC11,AC12,AC19,AC20,SUM(AC0) AC0,SUM(AC1) AC1 FROM CET GROUP BY AC01,AC02,AC04,AC05,AC06,AC07,AC09,AC11,AC12,AC19,AC20" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        void noSingleOfMu ( DataTable de , MulaolaoLibrary . MaterialProcurementSummaryBL _model , List<int> strList )
        {
            string maxNum = "";
            if ( de != null && de . Rows . Count > 0 )
            {
                if ( de . Select ( "BL006='" + _model . BL006 + "' AND BL007='" + _model . BL007 + "' AND BL009='" + _model . BL009 + "' AND BL012='" + _model . BL012 + "' AND BL013='" + _model . BL013 + "' AND BL014='" + _model . BL014 + "'" ) . Length > 0 )
                {
                    _model . BL002 = de . Select ( "BL006='" + _model . BL006 + "' AND BL007='" + _model . BL007 + "' AND BL009='" + _model . BL009 + "' AND BL012='" + _model . BL012 + "' AND BL013='" + _model . BL013 + "' AND BL014='" + _model . BL014 + "'" ) [ 0 ] [ "BL002" ] . ToString ( );
                    strList . Add ( Convert . ToInt32 ( _model . BL002 ) );
                }
                else
                {
                    maxNum = de . Compute ( "MAX(BL002)" , null ) . ToString ( );
                    if ( !string . IsNullOrEmpty ( maxNum ) )
                    {
                        if ( strList . Contains ( Convert . ToInt32 ( maxNum ) ) )
                        {
                            maxNum = strList . Max ( ) . ToString ( );
                            if ( Convert . ToInt32 ( maxNum ) < 9 )
                                _model . BL002 = "00" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else if ( Convert . ToInt32 ( maxNum ) >= 9 && Convert . ToInt32 ( maxNum ) < 99 )
                                _model . BL002 = "0" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else
                                _model . BL002 = ( Convert . ToInt32 ( maxNum ) + 1 ) . ToString ( );

                            strList . Add ( Convert . ToInt32 ( _model . BL002 ) );
                        }
                        else
                        {
                            strList . Add ( Convert . ToInt32 ( maxNum ) );
                            if ( Convert . ToInt32 ( maxNum ) < 9 )
                                _model . BL002 = "00" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else if ( Convert . ToInt32 ( maxNum ) >= 9 && Convert . ToInt32 ( maxNum ) < 99 )
                                _model . BL002 = "0" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else
                                _model . BL002 = ( Convert . ToInt32 ( maxNum ) + 1 ) . ToString ( );
                        }
                        strList . Add ( Convert . ToInt32 ( _model . BL002 ) );
                    }
                    else
                    {
                        if ( strList . Count > 0 )
                        {
                            maxNum = strList . Max ( ) . ToString ( );
                            if ( Convert . ToInt32 ( maxNum ) < 9 )
                                _model . BL002 = "00" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else if ( Convert . ToInt32 ( maxNum ) >= 9 && Convert . ToInt32 ( maxNum ) < 99 )
                                _model . BL002 = "0" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else
                                _model . BL002 = ( Convert . ToInt32 ( maxNum ) + 1 ) . ToString ( );
                        }
                        else
                            _model . BL002 = "001";

                        strList . Add ( Convert . ToInt32 ( _model . BL002 ) );
                    }
                }
            }
            else
            {
                if ( strList . Count > 0 )
                {
                    maxNum = strList . Max ( ) . ToString ( );
                    if ( Convert . ToInt32 ( maxNum ) < 9 )
                        _model . BL002 = "00" + ( Convert . ToInt32 ( maxNum ) + 1 );
                    else if ( Convert . ToInt32 ( maxNum ) >= 9 && Convert . ToInt32 ( maxNum ) < 99 )
                        _model . BL002 = "0" + ( Convert . ToInt32 ( maxNum ) + 1 );
                    else
                        _model . BL002 = ( Convert . ToInt32 ( maxNum ) + 1 ) . ToString ( );
                }
                else
                    _model . BL002 = "001";
                strList . Add ( Convert . ToInt32 ( _model . BL002 ) );
            }
        }

        string updateOfMu ( MulaolaoLibrary . MaterialProcurementSummaryBL _model , StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQBL SET " );
            strSql . AppendFormat ( "BL003='{0}'," , _model . BL003 );
            strSql . AppendFormat ( "BL004='{0}'," , _model . BL004 );
            strSql . AppendFormat ( "BL005='{0}'," , _model . BL005 );
            strSql . AppendFormat ( "BL006='{0}'," , _model . BL006 );
            strSql . AppendFormat ( "BL007='{0}'," , _model . BL007 );
            strSql . AppendFormat ( "BL008='{0}'," , _model . BL008 );
            strSql . AppendFormat ( "BL009='{0}'," , _model . BL009 );
            strSql . AppendFormat ( "BL010='{0}'," , _model . BL010 );
            strSql . AppendFormat ( "BL012='{0}'," , _model . BL012 );
            strSql . AppendFormat ( "BL013='{0}'," , _model . BL013 );
            strSql . AppendFormat ( "BL014='{0}'," , _model . BL014 );
            strSql . AppendFormat ( "BL015='{0}'," , _model . BL015 );
            strSql . AppendFormat ( "BL016='{0}'," , _model . BL016 );
            strSql . AppendFormat ( "BL017='{0}'" , _model . BL017 );
            strSql . AppendFormat ( " WHERE BL001='{0}'" , _model . BL001 );
            strSql . AppendFormat ( " AND BL002='{0}'" , _model . BL002 );

            return strSql . ToString ( );
        }
        string addOfMu ( MulaolaoLibrary . MaterialProcurementSummaryBL _model , StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQBL (BL001,BL002,BL003,BL004,BL005,BL006,BL007,BL008,BL009,BL010,BL012,BL013,BL014,BL015,BL016,BL017)" );
            strSql . AppendFormat ( " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}')" , _model . BL001 , _model . BL002 , _model . BL003 , _model . BL004 , _model . BL005 , _model . BL006 , _model . BL007 , _model . BL008 , _model . BL009 , _model . BL010 , _model . BL012 , _model . BL013 , _model . BL014 , _model . BL015 , _model . BL016 , _model . BL017 );

            return strSql . ToString ( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfMuList ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT BL001,BL002,BL003,BL004,BL005,BL006,BL007,BL008,CONVERT(FLOAT,BL009) BL009,CONVERT(FLOAT,BL010) BL010,CONVERT(FLOAT,BL011) BL011,BL012,BL013,BL014,BL015,BL016,BL017,BL018 FROM R_PQBL" );
            strSql . Append ( " WHERE " + strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 保存341数据
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool saveOfMu ( DataTable table )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT BL001,BL002,BL003,BL004,BL005,BL006,BL007,BL008,BL009,BL010,BL011,BL012,BL013,BL014,BL015,BL016,BL017,BL018 FROM R_PQBL" );
            strSql . Append ( " WHERE 1=2" );

            return SqlHelper . UpdateTable ( table , strSql . ToString ( ) );
        }

        /// <summary>
        /// 删除341数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool deleteOfMu ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQBL" );
            strSql . Append ( " WHERE BL001=@BL001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@BL001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = oddNum;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) , parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }


        /// <summary>
        /// 342生成
        /// </summary>
        /// <returns></returns>
        public bool GenerateWu ( string oddNum )
        {
            MulaolaoLibrary . MaterialProcurementSummaryBM _model = new MulaolaoLibrary . MaterialProcurementSummaryBM ( );
            _model . BM001 = oddNum;
            ArrayList SQLString = new ArrayList ( );
            DataTable de = SqlHelper . ExecuteDataTable ( "SELECT BM002,BM004,BM006,BM007 FROM R_PQBM WHERE BM001='" + _model . BM001 + "'" );
            DataTable da = GetDataTableOfWu ( );
            List<int> strList = new List<int> ( );
            StringBuilder strSql = new StringBuilder ( );
            if ( da != null && da . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    _model . BM003 = da . Rows [ i ] [ "AC01" ] . ToString ( );
                    _model . BM004 = da . Rows [ i ] [ "AC02" ] . ToString ( );
                    _model . BM005 = string . Empty;
                    _model . BM006 = da . Rows [ i ] [ "AC04" ] . ToString ( );
                    _model . BM007 = da . Rows [ i ] [ "AC05" ] . ToString ( );
                    noSingleOfWu ( de , _model , strList );
                    _model . BM008 = da . Rows [ i ] [ "AC06" ] . ToString ( );
                    _model . BM009 = string . IsNullOrEmpty ( da . Rows [ i ] [ "AC09" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "AC09" ] . ToString ( ) );
                    _model . BM010 = string . IsNullOrEmpty ( da . Rows [ i ] [ "AC1" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "AC1" ] . ToString ( ) );
                    _model . BM012 = string . IsNullOrEmpty ( da . Rows [ i ] [ "AC07" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "AC07" ] . ToString ( ) );
                    _model . BM013 = string . IsNullOrEmpty ( da . Rows [ i ] [ "AC12" ] . ToString ( ) ) == true ? DateTime . Now : Convert . ToDateTime ( da . Rows [ i ] [ "AC12" ] . ToString ( ) );
                    _model . BM014 = da . Rows [ i ] [ "AC11" ] . ToString ( );
                    _model . BM015 = string . Empty;
                    _model . BM016 = string . IsNullOrEmpty ( da . Rows [ i ] [ "AC20" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "AC20" ] . ToString ( ) );
                    _model . BM017 = da . Rows [ i ] [ "AC19" ] . ToString ( );
                    if ( de . Select ( "BM004='" + _model . BM004 + "' AND BM006='" + _model . BM006 + "' AND BM007='" + _model . BM007 + "'" ) . Length > 0 )
                        SQLString . Add ( updateOfMu ( _model , strSql ) );
                    else
                        SQLString . Add ( addOfMu ( _model , strSql ) );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 342
        /// </summary>
        /// <returns></returns>
        private DataTable GetDataTableOfWu ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "WITH CET AS (" );
            strSql . Append ( "SELECT AC01,AC02,AC04,AC05,AC06,CONVERT(FLOAT,AC07) AC07,CONVERT(FLOAT,CONVERT(DECIMAL(18,2),AC09)) AC09,AC11,AC12,ISNULL(AC19,'') AC19,ISNULL ( AC20 , 0 ) AC20 , ISNULL(AC03,0)+ISNULL(AC26,0)-SUM(ISNULL(AD05,0)+ISNULL(AD20,0)) AC0,CONVERT(DECIMAL(18,0),ISNULL(AC10,0)+ISNULL(AC27,0)-SUM(ISNULL(AD12,0)+ISNULL(AD21,0))) AC1 FROM R_PQAC A LEFT JOIN R_PQAD B ON A.AC18=B.AD01 WHERE AC16 LIKE 'R_342%' GROUP BY AC01,AC02,AC04,AC05,AC06,AC07,AC09,AC11,AC12,AC19,AC20,AC03,ISNULL(AC26,0),AC10,ISNULL(AC27,0))" );
            strSql . Append ( "SELECT AC01,AC02,AC04,AC05,AC06,AC07,AC09,AC11,AC12,AC19,AC20,SUM(AC0) AC0,SUM(AC1) AC1 FROM CET GROUP BY AC01,AC02,AC04,AC05,AC06,AC07,AC09,AC11,AC12,AC19,AC20" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        void noSingleOfWu ( DataTable de , MulaolaoLibrary . MaterialProcurementSummaryBM _model , List<int> strList )
        {
            string maxNum = "";
            if ( de != null && de . Rows . Count > 0 )
            {
                if ( de . Select ( "BM004='" + _model . BM004 + "' AND BM006='" + _model . BM006 + "' AND BM007='" + _model . BM007 + "'" ) . Length > 0 )
                {
                    _model . BM002 = de . Select ( "BM004='" + _model . BM004 + "' AND BM006='" + _model . BM006 + "' AND BM007='" + _model . BM007 + "'" ) [ 0 ] [ "BM002" ] . ToString ( );
                    strList . Add ( Convert . ToInt32 ( _model . BM002 ) );
                }
                else
                {
                    maxNum = de . Compute ( "MAX(BM002)" , null ) . ToString ( );
                    if ( !string . IsNullOrEmpty ( maxNum ) )
                    {
                        if ( strList . Contains ( Convert . ToInt32 ( maxNum ) ) )
                        {
                            maxNum = strList . Max ( ) . ToString ( );
                            if ( Convert . ToInt32 ( maxNum ) < 9 )
                                _model . BM002 = "00" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else if ( Convert . ToInt32 ( maxNum ) >= 9 && Convert . ToInt32 ( maxNum ) < 99 )
                                _model . BM002 = "0" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else
                                _model . BM002 = ( Convert . ToInt32 ( maxNum ) + 1 ) . ToString ( );

                            strList . Add ( Convert . ToInt32 ( _model . BM002 ) );
                        }
                        else
                        {
                            strList . Add ( Convert . ToInt32 ( maxNum ) );
                            if ( Convert . ToInt32 ( maxNum ) < 9 )
                                _model . BM002 = "00" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else if ( Convert . ToInt32 ( maxNum ) >= 9 && Convert . ToInt32 ( maxNum ) < 99 )
                                _model . BM002 = "0" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else
                                _model . BM002 = ( Convert . ToInt32 ( maxNum ) + 1 ) . ToString ( );
                        }
                        strList . Add ( Convert . ToInt32 ( _model . BM002 ) );
                    }
                    else
                    {
                        if ( strList . Count > 0 )
                        {
                            maxNum = strList . Max ( ) . ToString ( );
                            if ( Convert . ToInt32 ( maxNum ) < 9 )
                                _model . BM002 = "00" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else if ( Convert . ToInt32 ( maxNum ) >= 9 && Convert . ToInt32 ( maxNum ) < 99 )
                                _model . BM002 = "0" + ( Convert . ToInt32 ( maxNum ) + 1 );
                            else
                                _model . BM002 = ( Convert . ToInt32 ( maxNum ) + 1 ) . ToString ( );
                        }
                        else
                            _model . BM002 = "001";

                        strList . Add ( Convert . ToInt32 ( _model . BM002 ) );
                    }
                }
            }
            else
            {
                if ( strList . Count > 0 )
                {
                    maxNum = strList . Max ( ) . ToString ( );
                    if ( Convert . ToInt32 ( maxNum ) < 9 )
                        _model . BM002 = "00" + ( Convert . ToInt32 ( maxNum ) + 1 );
                    else if ( Convert . ToInt32 ( maxNum ) >= 9 && Convert . ToInt32 ( maxNum ) < 99 )
                        _model . BM002 = "0" + ( Convert . ToInt32 ( maxNum ) + 1 );
                    else
                        _model . BM002 = ( Convert . ToInt32 ( maxNum ) + 1 ) . ToString ( );
                }
                else
                    _model . BM002 = "001";
                strList . Add ( Convert . ToInt32 ( _model . BM002 ) );
            }
        }

        string updateOfMu ( MulaolaoLibrary . MaterialProcurementSummaryBM _model , StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQBM SET " );
            strSql . AppendFormat ( "BM003='{0}'," , _model . BM003 );
            strSql . AppendFormat ( "BM004='{0}'," , _model . BM004 );
            strSql . AppendFormat ( "BM005='{0}'," , _model . BM005 );
            strSql . AppendFormat ( "BM006='{0}'," , _model . BM006 );
            strSql . AppendFormat ( "BM007='{0}'," , _model . BM007 );
            strSql . AppendFormat ( "BM008='{0}'," , _model . BM008 );
            strSql . AppendFormat ( "BM009='{0}'," , _model . BM009 );
            strSql . AppendFormat ( "BM010='{0}'," , _model . BM010 );
            strSql . AppendFormat ( "BM012='{0}'," , _model . BM012 );
            strSql . AppendFormat ( "BM013='{0}'," , _model . BM013 );
            strSql . AppendFormat ( "BM014='{0}'," , _model . BM014 );
            strSql . AppendFormat ( "BM015='{0}'," , _model . BM015 );
            strSql . AppendFormat ( "BM016='{0}'," , _model . BM016 );
            strSql . AppendFormat ( "BM017='{0}'" , _model . BM017 );
            strSql . AppendFormat ( " WHERE BM001='{0}'" , _model . BM001 );
            strSql . AppendFormat ( " AND BM002='{0}'" , _model . BM002 );

            return strSql . ToString ( );
        }
        string addOfMu ( MulaolaoLibrary . MaterialProcurementSummaryBM _model , StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQBM (BM001,BM002,BM003,BM004,BM005,BM006,BM007,BM008,BM009,BM010,BM012,BM013,BM014,BM015,BM016,BM017)" );
            strSql . AppendFormat ( " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}')" , _model . BM001 , _model . BM002 , _model . BM003 , _model . BM004 , _model . BM005 , _model . BM006 , _model . BM007 , _model . BM008 , _model . BM009 , _model . BM010 , _model . BM012 , _model . BM013 , _model . BM014 , _model . BM015 , _model . BM016 , _model . BM017 );

            return strSql . ToString ( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfWuList ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT BM001,BM002,BM003,BM004,BM005,BM006,BM007,BM008,BM009,BM010,BM011,CONVERT(FLOAT,BM012) BM012,BM013,BM014,BM015,BM016,BM017,BM018 FROM R_PQBM" );
            strSql . Append ( " WHERE " + strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 保存342数据
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool saveOfWu ( DataTable table )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT BM001,BM002,BM003,BM004,BM005,BM006,BM007,BM008,BM009,BM010,BM011,BM012,BM013,BM014,BM015,BM016,BM017,BM018 FROM R_PQBM" );
            strSql . Append ( " WHERE 1=2" );

            return SqlHelper . UpdateTable ( table , strSql . ToString ( ) );
        }

        /// <summary>
        /// 删除342数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool deleteOfWu ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQBM" );
            strSql . Append ( " WHERE BM001=@BM001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@BM001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = oddNum;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) , parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 汇总
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Query ( string oddNum )
        {
            MulaolaoLibrary . MaterialProcurementSummaryBO _model = new MulaolaoLibrary . MaterialProcurementSummaryBO ( );
            _model . BO001 = oddNum;
            StringBuilder strSql = new StringBuilder ( );
            ArrayList SQLString = new ArrayList ( );
            DataTable da = GetDataTableBh ( );
            if ( da != null && da . Rows . Count > 0 )
            {
                _model . BO002 = string . IsNullOrEmpty ( da . Rows [ 0 ] [ "SK" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ 0 ] [ "SK" ] . ToString ( ) );
                _model . BO003 = string . IsNullOrEmpty ( da . Rows [ 0 ] [ "PK" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ 0 ] [ "PK" ] . ToString ( ) );
                if ( exists ( _model . BO001 ) == true )
                    SQLString . Add ( updateBh ( _model , strSql ) );
                else
                    SQLString . Add ( addBh ( _model , strSql ) );
            }
           if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                SQLString . Clear ( );
                da = GetDataTableBi ( );
                if ( da != null && da . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < da . Rows . Count ; i++ )
                    {
                        if ( da . Rows [ i ] [ "BI006" ] . ToString ( ) == "胶合板" )
                        {
                            _model . BO004 = string . IsNullOrEmpty ( da . Rows [ i ] [ "SK" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "SK" ] . ToString ( ) );
                            _model . BO005 = string . IsNullOrEmpty ( da . Rows [ i ] [ "PK" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "PK" ] . ToString ( ) );
                        }
                        else
                        {
                            _model . BO006 = string . IsNullOrEmpty ( da . Rows [ i ] [ "SK" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "SK" ] . ToString ( ) );
                            _model . BO007 = string . IsNullOrEmpty ( da . Rows [ i ] [ "PK" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "PK" ] . ToString ( ) );
                        }
                    }
                    if ( exists ( _model . BO001 ) == true )
                        SQLString . Add ( updateBi ( _model , strSql ) );
                    else
                        SQLString . Add ( addBi ( _model , strSql ) );
                }
            }

            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                SQLString . Clear ( );
                da = GetDataTableBj ( );
                if ( da != null && da . Rows . Count > 0 )
                {
                    _model . BO008 = string . IsNullOrEmpty ( da . Rows [ 0 ] [ "SK" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ 0 ] [ "SK" ] . ToString ( ) );
                    _model . BO009 = string . IsNullOrEmpty ( da . Rows [ 0 ] [ "PK" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ 0 ] [ "PK" ] . ToString ( ) );
                    if ( exists ( _model . BO001 ) == true )
                        SQLString . Add ( updateBj ( _model , strSql ) );
                    else
                        SQLString . Add ( addBj ( _model , strSql ) );
                }
            }

            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                SQLString . Clear ( );
                da = GetDataTableBk ( );
                if ( da != null && da . Rows . Count > 0 )
                {
                    _model . BO010 = string . IsNullOrEmpty ( da . Rows [ 0 ] [ "SK" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ 0 ] [ "SK" ] . ToString ( ) );
                    _model . BO011 = string . IsNullOrEmpty ( da . Rows [ 0 ] [ "PK" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ 0 ] [ "PK" ] . ToString ( ) );
                    if ( exists ( _model . BO001 ) == true )
                        SQLString . Add ( updateBk ( _model , strSql ) );
                    else
                        SQLString . Add ( addBk ( _model , strSql ) );
                }
            }

            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                SQLString . Clear ( );
                da = GetDataTableBl ( );
                if ( da != null && da . Rows . Count > 0 )
                {
                    _model . BO012 = string . IsNullOrEmpty ( da . Rows [ 0 ] [ "SK" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ 0 ] [ "SK" ] . ToString ( ) );
                    _model . BO013 = string . IsNullOrEmpty ( da . Rows [ 0 ] [ "PK" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ 0 ] [ "PK" ] . ToString ( ) );
                    if ( exists ( _model . BO001 ) == true )
                        SQLString . Add ( updateBl ( _model , strSql ) );
                    else
                        SQLString . Add ( addBl ( _model , strSql ) );
                }
            }

            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                SQLString . Clear ( );
                da = GetDataTableBm ( );
                if ( da != null && da . Rows . Count > 0 )
                {
                    _model . BO014 = string . IsNullOrEmpty ( da . Rows [ 0 ] [ "SK" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ 0 ] [ "SK" ] . ToString ( ) );
                    _model . BO015 = string . IsNullOrEmpty ( da . Rows [ 0 ] [ "PK" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ 0 ] [ "PK" ] . ToString ( ) );
                    if ( exists ( _model . BO001 ) == true )
                        SQLString . Add ( updateBm ( _model , strSql ) );
                    else
                        SQLString . Add ( addBm ( _model , strSql ) );
                }
            }


            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        bool exists ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM R_PQBO WHERE BO001='" + oddNum + "'" );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 337金额
        /// </summary>
        /// <returns></returns>
        private DataTable GetDataTableBh ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT SUM(ISNULL(BH009,0)-ISNULL(BH011,0)) SK,SUM(ISNULL(BH012,0)) PK FROM R_PQBH" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        string updateBh ( MulaolaoLibrary . MaterialProcurementSummaryBO _model , StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQBO SET " );
            strSql . AppendFormat ( " BO002='{0}'," , _model . BO002 );
            strSql . AppendFormat ( " BO003='{0}'" , _model . BO003 );
            strSql . AppendFormat ( " WHERE BO001='{0}'" , _model . BO001 );

            return strSql . ToString ( );
        }
        string addBh ( MulaolaoLibrary . MaterialProcurementSummaryBO _model , StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQBO (BO001,BO002,BO003) " );
            strSql . AppendFormat ( " VALUES ('{0}','{1}','{2}')" , _model . BO001 , _model . BO002 , _model . BO003 );

            return strSql . ToString ( );
        }

        /// <summary>
        /// 338
        /// </summary>
        /// <returns></returns>
        private DataTable GetDataTableBi ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "WITH CET AS (SELECT CASE WHEN BI006='密度板' THEN '密度板' ELSE '胶合板' END BI006,CONVERT(DECIMAL(18,0),ISNULL(BI009,0)*ISNULL(BI010,0)) SK,CONVERT(DECIMAL(18,0),ISNULL(BI009,0)*ISNULL(BI011,0)) PK FROM R_PQBI)" );
            strSql . Append ( "SELECT BI006,SUM(SK) SK,SUM(PK) PK FROM CET GROUP BY BI006" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        string updateBi ( MulaolaoLibrary . MaterialProcurementSummaryBO _model , StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQBO SET " );
            strSql . AppendFormat ( " BO004='{0}'," , _model . BO004 );
            strSql . AppendFormat ( " BO005='{0}'," , _model . BO005 );
            strSql . AppendFormat ( " BO006='{0}'," , _model . BO006 );
            strSql . AppendFormat ( " BO007='{0}'" , _model . BO007 );
            strSql . AppendFormat ( " WHERE BO001='{0}'" , _model . BO001 );

            return strSql . ToString ( );
        }
        string addBi ( MulaolaoLibrary . MaterialProcurementSummaryBO _model , StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQBO (BO001,BO004,BO005,BO006,BO007) " );
            strSql . AppendFormat ( " VALUES ('{0}','{1}','{2}','{3}','{4}')" , _model . BO001 , _model . BO004 , _model . BO005 , _model . BO006 , _model . BO007 );

            return strSql . ToString ( );
        }

        /// <summary>
        /// 343
        /// </summary>
        /// <returns></returns>
        private DataTable GetDataTableBj ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT CONVERT(DECIMAL(18,0),SUM(ISNULL(BJ010,0)*ISNULL(BJ009,0))) SK,CONVERT(DECIMAL(18,0),SUM(ISNULL(BJ011,0)*ISNULL(BJ009,0))) PK FROM R_PQBJ" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        string updateBj ( MulaolaoLibrary . MaterialProcurementSummaryBO _model , StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQBO SET " );
            strSql . AppendFormat ( " BO008='{0}'," , _model . BO008 );
            strSql . AppendFormat ( " BO009='{0}'" , _model . BO009 );
            strSql . AppendFormat ( " WHERE BO001='{0}'" , _model . BO001 );

            return strSql . ToString ( );
        }
        string addBj ( MulaolaoLibrary . MaterialProcurementSummaryBO _model , StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQBO (BO001,BO008,BO009) " );
            strSql . AppendFormat ( " VALUES ('{0}','{1}','{2}')" , _model . BO001 , _model . BO008 , _model . BO009 );

            return strSql . ToString ( );
        }

        /// <summary>
        /// 347
        /// </summary>
        /// <returns></returns>
        private DataTable GetDataTableBk ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT CONVERT(DECIMAL(18,0),SUM(ISNULL(BK009,0)*ISNULL(BK010,0))) SK,CONVERT(DECIMAL(18,0),SUM(ISNULL(BK009,0)*ISNULL(BK011,0))) PK FROM R_PQBK" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        string updateBk ( MulaolaoLibrary . MaterialProcurementSummaryBO _model , StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQBO SET " );
            strSql . AppendFormat ( " BO010='{0}'," , _model . BO010 );
            strSql . AppendFormat ( " BO011='{0}'" , _model . BO011 );
            strSql . AppendFormat ( " WHERE BO001='{0}'" , _model . BO001 );

            return strSql . ToString ( );
        }
        string addBk ( MulaolaoLibrary . MaterialProcurementSummaryBO _model , StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQBO (BO001,BO010,BO011) " );
            strSql . AppendFormat ( " VALUES ('{0}','{1}','{2}')" , _model . BO001 , _model . BO010 , _model . BO011 );

            return strSql . ToString ( );
        }

        /// <summary>
        /// 341
        /// </summary>
        /// <returns></returns>
        private DataTable GetDataTableBl ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT CONVERT(DECIMAL(18,0),SUM(ISNULL(BL010,0)*ISNULL(BL009,0))) SK,CONVERT(DECIMAL(18,0),SUM(ISNULL(BL009,0)*ISNULL(BL011,0))) PK FROM R_PQBL" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        string updateBl ( MulaolaoLibrary . MaterialProcurementSummaryBO _model , StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQBO SET " );
            strSql . AppendFormat ( " BO012='{0}'," , _model . BO012 );
            strSql . AppendFormat ( " BO013='{0}'" , _model . BO013 );
            strSql . AppendFormat ( " WHERE BO001='{0}'" , _model . BO001 );

            return strSql . ToString ( );
        }
        string addBl ( MulaolaoLibrary . MaterialProcurementSummaryBO _model , StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQBO (BO001,BO012,BO013) " );
            strSql . AppendFormat ( " VALUES ('{0}','{1}','{2}')" , _model . BO001 , _model . BO012 , _model . BO013 );

            return strSql . ToString ( );
        }

        /// <summary>
        /// 342
        /// </summary>
        /// <returns></returns>
        private DataTable GetDataTableBm ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT CONVERT(DECIMAL(18,0),SUM(ISNULL(BM010,0)*ISNULL(BM009,0))) SK,CONVERT(DECIMAL(18,0),SUM(ISNULL(BM009,0)*ISNULL(BM011,0))) PK FROM R_PQBM" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        string updateBm ( MulaolaoLibrary . MaterialProcurementSummaryBO _model , StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQBO SET " );
            strSql . AppendFormat ( " BO014='{0}'," , _model . BO014 );
            strSql . AppendFormat ( " BO015='{0}'," , _model . BO015 );
            strSql . AppendFormat ( " BO016='{0}'," , _model . BO016 );
            strSql . AppendFormat ( " BO017='{0}'" , _model . BO017 );
            strSql . AppendFormat ( " WHERE BO001='{0}'" , _model . BO001 );

            return strSql . ToString ( );
        }
        string addBm ( MulaolaoLibrary . MaterialProcurementSummaryBO _model , StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQBO (BO001,BO014,BO015,BO016,BO017) " );
            strSql . AppendFormat ( " VALUES ('{0}','{1}','{2}')" , _model . BO001 , _model . BO014 , _model . BO015 , _model . BO016 , _model . BO017 );

            return strSql . ToString ( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfAll ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT * FROM R_PQBO WHERE BO001='" + oddNum + "'" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool deleteOfAll ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQBO" );
            strSql . Append ( " WHERE BO001=@BO001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@BO001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = oddNum;

            int row= SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) , parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }
    }
}

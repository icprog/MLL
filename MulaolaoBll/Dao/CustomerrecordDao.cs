using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;
using StudentMgr;
using System . Data . SqlClient;
using System . Collections;

namespace MulaolaoBll . Dao
{
    public class CustomerrecordDao
    {
        /// <summary>
        /// get customer info from tpadfa
        /// </summary>
        /// <returns></returns>
        public DataTable getCustomNameInfo ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DFA002 FROM TPADFA ORDER BY DFA002" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get salesman info from tpadba
        /// </summary>
        /// <returns></returns>
        public DataTable getSalesmanInfo ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DBA002 FROM TPADBA" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get base info from r_pqn
        /// </summary>
        /// <returns></returns>
        public DataTable getAllInfo ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT KH02,KH03,KH04,KH05,KH14,KH17,KH19 FROM R_PQN" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get only columns from r_pqn
        /// </summary>
        /// <returns></returns>
        public DataTable getColumnOnly ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT KH01,KH02,KH05,KH04,KH03 FROM R_PQN " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get count from r_pqn
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int getCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM (SELECT DISTINCT KH01,KH02,KH03,KH04,KH05 FROM R_PQN WHERE {0}) A" ,strWhere );

            object obj = SqlHelper . GetSingle ( strSql . ToString ( ) );
            if ( obj == null )
                return 0;
            else
                return Convert . ToInt32 ( obj );
        }

        /// <summary>
        /// get data from r_pqn by change page
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable getDataTableByChange ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT KH01,KH02,KH03,KH04,KH05 FROM (" );
            strSql . Append ( "SELECT ROW_NUMBER() OVER( " );
            strSql . Append ( "ORDER BY T.KH01 DESC) " );
            strSql . Append ( "AS ROW,T.* FROM R_PQN T " );
            strSql . Append ( "WHERE " + strWhere );
            strSql . Append ( ") TT " );
            strSql . AppendFormat ( "WHERE TT.ROW BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get data from r_pqna to view
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTableView ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,NA002,NA003,NA004,NA005,NA006,NA007,NA008,NA009 FROM R_PQNA " );
            strSql . Append ( "WHERE " + strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get datasource from r_pqn
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public MulaolaoLibrary . CustomerrecordEntity getModel ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT KH01,KH02,KH03,KH04,KH05,KH06,KH07,KH08,KH09,KH10,KH11,KH12,KH13,KH14,KH15,KH16,KH17,KH18,KH19,KH20,KH21,KH22,KH23,KH24,KH25,KH26,KH27,KH28,KH29,KH30,KH31,KH32,KH33,KH34,KH35 FROM R_PQN " );
            strSql . Append ( "WHERE KH01=@KH01" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@KH01", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = oddNum;

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameters );
            if ( dt != null && dt . Rows . Count > 0 )
                return getModel ( dt . Rows [ 0 ] );
            else
                return null;
        }

        public MulaolaoLibrary . CustomerrecordEntity getModel ( DataRow row )
        {
            MulaolaoLibrary . CustomerrecordEntity model = new MulaolaoLibrary . CustomerrecordEntity ( );

            if ( row != null )
            {
                if ( row [ "KH01" ] != null )
                {
                    model . KH01 = row [ "KH01" ] . ToString ( );
                }
                if ( row [ "KH02" ] != null )
                {
                    model . KH02 = row [ "KH02" ] . ToString ( );
                }
                if ( row [ "KH03" ] != null )
                {
                    model . KH03 = row [ "KH03" ] . ToString ( );
                }
                if ( row [ "KH04" ] != null )
                {
                    model . KH04 = row [ "KH04" ] . ToString ( );
                }
                if ( row [ "KH05" ] != null )
                {
                    model . KH05 = row [ "KH05" ] . ToString ( );
                }
                if ( row [ "KH06" ] != null && row [ "KH06" ] . ToString ( ) != "" )
                {
                    model . KH06 = int . Parse ( row [ "KH06" ] . ToString ( ) );
                }
                if ( row [ "KH07" ] != null && row [ "KH07" ] . ToString ( ) != "" )
                {
                    model . KH07 = ( byte [ ] ) row [ "KH07" ];
                }
                else
                    model . KH07 = new byte [ 0 ];
                if ( row [ "KH08" ] != null && row [ "KH08" ] . ToString ( ) != "" )
                {
                    model . KH08 = DateTime . Parse ( row [ "KH08" ] . ToString ( ) );
                }
                if ( row [ "KH09" ] != null )
                {
                    model . KH09 = row [ "KH09" ] . ToString ( );
                }
                if ( row [ "KH10" ] != null )
                {
                    model . KH10 = row [ "KH10" ] . ToString ( );
                }
                if ( row [ "KH11" ] != null && row [ "KH11" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "KH11" ] . ToString ( ) == "1" ) || ( row [ "KH11" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . KH11 = true;
                    }
                    else
                    {
                        model . KH11 = false;
                    }
                }
                if ( row [ "KH12" ] != null && row [ "KH12" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "KH12" ] . ToString ( ) == "1" ) || ( row [ "KH12" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . KH12 = true;
                    }
                    else
                    {
                        model . KH12 = false;
                    }
                }
                if ( row [ "KH13" ] != null && row [ "KH13" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "KH13" ] . ToString ( ) == "1" ) || ( row [ "KH13" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . KH13 = true;
                    }
                    else
                    {
                        model . KH13 = false;
                    }
                }
                if ( row [ "KH14" ] != null )
                {
                    model . KH14 = row [ "KH14" ] . ToString ( );
                }
                if ( row [ "KH15" ] != null && row [ "KH15" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "KH15" ] . ToString ( ) == "1" ) || ( row [ "KH15" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . KH15 = true;
                    }
                    else
                    {
                        model . KH15 = false;
                    }
                }
                if ( row [ "KH16" ] != null && row [ "KH16" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "KH16" ] . ToString ( ) == "1" ) || ( row [ "KH16" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . KH16 = true;
                    }
                    else
                    {
                        model . KH16 = false;
                    }
                }
                if ( row [ "KH17" ] != null )
                {
                    model . KH17 = row [ "KH17" ] . ToString ( );
                }
                if ( row [ "KH18" ] != null && row [ "KH18" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "KH18" ] . ToString ( ) == "1" ) || ( row [ "KH18" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . KH18 = true;
                    }
                    else
                    {
                        model . KH18 = false;
                    }
                }
                if ( row [ "KH19" ] != null )
                {
                    model . KH19 = row [ "KH19" ] . ToString ( );
                }
                if ( row [ "KH20" ] != null && row [ "KH20" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "KH20" ] . ToString ( ) == "1" ) || ( row [ "KH20" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . KH20 = true;
                    }
                    else
                    {
                        model . KH20 = false;
                    }
                }
                if ( row [ "KH21" ] != null && row [ "KH21" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "KH21" ] . ToString ( ) == "1" ) || ( row [ "KH21" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . KH21 = true;
                    }
                    else
                    {
                        model . KH21 = false;
                    }
                }
                if ( row [ "KH22" ] != null && row [ "KH22" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "KH22" ] . ToString ( ) == "1" ) || ( row [ "KH22" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . KH22 = true;
                    }
                    else
                    {
                        model . KH22 = false;
                    }
                }
                if ( row [ "KH23" ] != null && row [ "KH23" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "KH23" ] . ToString ( ) == "1" ) || ( row [ "KH23" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . KH23 = true;
                    }
                    else
                    {
                        model . KH23 = false;
                    }
                }
                if ( row [ "KH24" ] != null && row [ "KH24" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "KH24" ] . ToString ( ) == "1" ) || ( row [ "KH24" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . KH24 = true;
                    }
                    else
                    {
                        model . KH24 = false;
                    }
                }
                if ( row [ "KH25" ] != null && row [ "KH25" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "KH25" ] . ToString ( ) == "1" ) || ( row [ "KH25" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . KH25 = true;
                    }
                    else
                    {
                        model . KH25 = false;
                    }
                }
                if ( row [ "KH26" ] != null )
                {
                    model . KH26 = row [ "KH26" ] . ToString ( );
                }
                if ( row [ "KH27" ] != null )
                {
                    model . KH27 = row [ "KH27" ] . ToString ( );
                }
                if ( row [ "KH28" ] != null )
                {
                    model . KH28 = row [ "KH28" ] . ToString ( );
                }
                if ( row [ "KH29" ] != null )
                {
                    model . KH29 = row [ "KH29" ] . ToString ( );
                }
                if ( row [ "KH30" ] != null )
                {
                    model . KH30 = row [ "KH30" ] . ToString ( );
                }
                if ( row [ "KH31" ] != null && row [ "KH31" ] . ToString ( ) != "" )
                {
                    model . KH31 = DateTime . Parse ( row [ "KH31" ] . ToString ( ) );
                }
                if ( row [ "KH32" ] != null )
                {
                    model . KH32 = row [ "KH32" ] . ToString ( );
                }
                if ( row [ "KH33" ] != null && row [ "KH33" ] . ToString ( ) != "" )
                {
                    model . KH33 = DateTime . Parse ( row [ "KH33" ] . ToString ( ) );
                }
                if ( row [ "KH34" ] != null )
                {
                    model . KH34 = row [ "KH34" ] . ToString ( );
                }
                if ( row [ "KH35" ] != null )
                {
                    model . KH35 = row [ "KH35" ] . ToString ( );
                }
            }

            return model;
        }

        /// <summary>
        /// delete data from r_pqn,r_pqna,r_reviews
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="logins"></param>
        /// <param name="stateOdd"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum ,string logins )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM R_REVIEWS WHERE RES06='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_369" ,"客户信息传递记录表(R_369)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除送审" ) );
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM R_PQN WHERE KH01='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_369" ,"客户信息传递记录表(R_369)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除表头" ) );
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM R_PQNA WHERE NA001='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_369" ,"客户信息传递记录表(R_369)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除表身" ) );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// get data from r_pqn for print
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable getPrintOne ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT KH01,KH02,KH05,KH03,KH04,KH06,KH08,KH11,KH12,KH13,KH14,KH15,KH16,KH17,KH18,KH19,KH20,KH21,KH22,KH23,KH24,KH25,KH26,KH27,KH28,KH29,KH30,KH32,KH31,KH33,KH35 FROM R_PQN " );
            strSql . AppendFormat ( "WHERE KH01='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get data from r_pqna for print
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable getPrintTwo ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT NA002,NA003,NA004,NA005,NA006,NA007,NA008,NA009 FROM R_PQNA " );
            strSql . AppendFormat ( "WHERE NA001='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// save data to r_pqn,r_pqna
        /// </summary>
        /// <param name="model"></param>
        /// <param name="table"></param>
        /// <param name="strList"></param>
        /// <param name="logins"></param>
        /// <returns></returns>
        public bool Save ( MulaolaoLibrary . CustomerrecordEntity model ,DataTable table ,string logins )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            model . KH01 = getOddNum ( );
            add_pqn ( SQLString ,strSql ,model );
            SQLString . Add ( Drity . DrityOfComparation ( "R_369" ,"客户信息传递记录表(R_369)" ,logins ,Drity . GetDt ( ) ,model . KH01 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新增" ,"增加" ) ,null );

            MulaolaoLibrary . CustomerrecordNAEntity _na = new MulaolaoLibrary . CustomerrecordNAEntity ( );
            _na . NA001 = model . KH01;
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _na . NA002 = table . Rows [ i ] [ "NA002" ] . ToString ( );
                _na . NA003 = table . Rows [ i ] [ "NA003" ] . ToString ( );
                _na . NA004 = table . Rows [ i ] [ "NA004" ] . ToString ( );
                _na . NA005 = table . Rows [ i ] [ "NA005" ] . ToString ( );
                _na . NA006 = table . Rows [ i ] [ "NA006" ] . ToString ( );
                _na . NA007 = table . Rows [ i ] [ "NA007" ] . ToString ( );
                _na . NA008 = table . Rows [ i ] [ "NA008" ] . ToString ( );
                _na . NA009 = table . Rows [ i ] [ "NA009" ] . ToString ( );
                add_pqna ( SQLString ,strSql ,_na );
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void add_pqn ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . CustomerrecordEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_PQN(" );
            strSql . Append ( "KH01,KH02,KH03,KH04,KH05,KH06,KH07,KH08,KH09,KH10,KH11,KH12,KH13,KH14,KH15,KH16,KH17,KH18,KH19,KH20,KH21,KH22,KH23,KH24,KH25,KH26,KH27,KH28,KH29,KH30,KH31,KH32,KH33,KH34,KH35)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@KH01,@KH02,@KH03,@KH04,@KH05,@KH06,@KH07,@KH08,@KH09,@KH10,@KH11,@KH12,@KH13,@KH14,@KH15,@KH16,@KH17,@KH18,@KH19,@KH20,@KH21,@KH22,@KH23,@KH24,@KH25,@KH26,@KH27,@KH28,@KH29,@KH30,@KH31,@KH32,@KH33,@KH34,@KH35)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@KH01", SqlDbType.NVarChar,20),
                    new SqlParameter("@KH02", SqlDbType.NVarChar,20),
                    new SqlParameter("@KH03", SqlDbType.NVarChar,20),
                    new SqlParameter("@KH04", SqlDbType.NVarChar,20),
                    new SqlParameter("@KH05", SqlDbType.NVarChar,20),
                    new SqlParameter("@KH06", SqlDbType.Int,4),
                    new SqlParameter("@KH07", SqlDbType.VarBinary,-1),
                    new SqlParameter("@KH08", SqlDbType.Date,3),
                    new SqlParameter("@KH09", SqlDbType.NVarChar,20),
                    new SqlParameter("@KH10", SqlDbType.NVarChar,20),
                    new SqlParameter("@KH11", SqlDbType.Bit,1),
                    new SqlParameter("@KH12", SqlDbType.Bit,1),
                    new SqlParameter("@KH13", SqlDbType.Bit,1),
                    new SqlParameter("@KH14", SqlDbType.NVarChar,20),
                    new SqlParameter("@KH15", SqlDbType.Bit,1),
                    new SqlParameter("@KH16", SqlDbType.Bit,1),
                    new SqlParameter("@KH17", SqlDbType.NVarChar,20),
                    new SqlParameter("@KH18", SqlDbType.Bit,1),
                    new SqlParameter("@KH19", SqlDbType.NVarChar,20),
                    new SqlParameter("@KH20", SqlDbType.Bit,1),
                    new SqlParameter("@KH21", SqlDbType.Bit,1),
                    new SqlParameter("@KH22", SqlDbType.Bit,1),
                    new SqlParameter("@KH23", SqlDbType.Bit,1),
                    new SqlParameter("@KH24", SqlDbType.Bit,1),
                    new SqlParameter("@KH25", SqlDbType.Bit,1),
                    new SqlParameter("@KH26", SqlDbType.NVarChar,100),
                    new SqlParameter("@KH27", SqlDbType.NVarChar,100),
                    new SqlParameter("@KH28", SqlDbType.NVarChar,100),
                    new SqlParameter("@KH29", SqlDbType.NVarChar,100),
                    new SqlParameter("@KH30", SqlDbType.NVarChar,20),
                    new SqlParameter("@KH31", SqlDbType.Date,3),
                    new SqlParameter("@KH32", SqlDbType.NVarChar,20),
                    new SqlParameter("@KH33", SqlDbType.Date,3),
                    new SqlParameter("@KH34", SqlDbType.NVarChar,200),
                    new SqlParameter("@KH35", SqlDbType.NVarChar,200)
            };
            parameters [ 0 ] . Value = model . KH01;
            parameters [ 1 ] . Value = model . KH02;
            parameters [ 2 ] . Value = model . KH03;
            parameters [ 3 ] . Value = model . KH04;
            parameters [ 4 ] . Value = model . KH05;
            parameters [ 5 ] . Value = model . KH06;
            parameters [ 6 ] . Value = model . KH07;
            parameters [ 7 ] . Value = model . KH08;
            parameters [ 8 ] . Value = model . KH09;
            parameters [ 9 ] . Value = model . KH10;
            parameters [ 10 ] . Value = model . KH11;
            parameters [ 11 ] . Value = model . KH12;
            parameters [ 12 ] . Value = model . KH13;
            parameters [ 13 ] . Value = model . KH14;
            parameters [ 14 ] . Value = model . KH15;
            parameters [ 15 ] . Value = model . KH16;
            parameters [ 16 ] . Value = model . KH17;
            parameters [ 17 ] . Value = model . KH18;
            parameters [ 18 ] . Value = model . KH19;
            parameters [ 19 ] . Value = model . KH20;
            parameters [ 20 ] . Value = model . KH21;
            parameters [ 21 ] . Value = model . KH22;
            parameters [ 22 ] . Value = model . KH23;
            parameters [ 23 ] . Value = model . KH24;
            parameters [ 24 ] . Value = model . KH25;
            parameters [ 25 ] . Value = model . KH26;
            parameters [ 26 ] . Value = model . KH27;
            parameters [ 27 ] . Value = model . KH28;
            parameters [ 28 ] . Value = model . KH29;
            parameters [ 29 ] . Value = model . KH30;
            parameters [ 30 ] . Value = model . KH31;
            parameters [ 31 ] . Value = model . KH32;
            parameters [ 32 ] . Value = model . KH33;
            parameters [ 33 ] . Value = model . KH34;
            parameters [ 34 ] . Value = model . KH35;

            SQLString . Add ( strSql ,parameters );
        }

        void add_pqna ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . CustomerrecordNAEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_PQNA(" );
            strSql . Append ( "NA001,NA002,NA003,NA004,NA005,NA006,NA007,NA008,NA009)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@NA001,@NA002,@NA003,@NA004,@NA005,@NA006,@NA007,@NA008,@NA009)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@NA001", SqlDbType.NVarChar,20),
                    new SqlParameter("@NA002", SqlDbType.NVarChar,20),
                    new SqlParameter("@NA003", SqlDbType.NVarChar,20),
                    new SqlParameter("@NA004", SqlDbType.NVarChar,20),
                    new SqlParameter("@NA005", SqlDbType.NVarChar,20),
                    new SqlParameter("@NA006", SqlDbType.NVarChar,20),
                    new SqlParameter("@NA007", SqlDbType.NVarChar,20),
                    new SqlParameter("@NA008", SqlDbType.NVarChar,50),
                    new SqlParameter("@NA009", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = model . NA001;
            parameters [ 1 ] . Value = model . NA002;
            parameters [ 2 ] . Value = model . NA003;
            parameters [ 3 ] . Value = model . NA004;
            parameters [ 4 ] . Value = model . NA005;
            parameters [ 5 ] . Value = model . NA006;
            parameters [ 6 ] . Value = model . NA007;
            parameters [ 7 ] . Value = model . NA008;
            parameters [ 8 ] . Value = model . NA009;

            SQLString . Add ( strSql ,parameters );
        }
        
        /// <summary>
        /// edit data to r_pqn,r_pqna
        /// </summary>
        /// <param name="model"></param>
        /// <param name="table"></param>
        /// <param name="logins"></param>
        /// <param name="strList"></param>
        /// <returns></returns>
        public bool Edit ( MulaolaoLibrary . CustomerrecordEntity model ,DataTable table ,string logins ,List<string> strList )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            edit_pqn ( SQLString ,strSql ,model );
            SQLString . Add ( Drity . DrityOfComparation ( "R_369" ,"客户信息传递记录表(R_369)" ,logins ,Drity . GetDt ( ) ,model . KH01 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"编辑" ,"编辑" ) ,null );

            MulaolaoLibrary . CustomerrecordNAEntity _na = new MulaolaoLibrary . CustomerrecordNAEntity ( );
            _na . NA001 = model . KH01;
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _na . idx = string . IsNullOrEmpty ( table . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "idx" ] . ToString ( ) );
                _na . NA002 = table . Rows [ i ] [ "NA002" ] . ToString ( );
                _na . NA003 = table . Rows [ i ] [ "NA003" ] . ToString ( );
                _na . NA004 = table . Rows [ i ] [ "NA004" ] . ToString ( );
                _na . NA005 = table . Rows [ i ] [ "NA005" ] . ToString ( );
                _na . NA006 = table . Rows [ i ] [ "NA006" ] . ToString ( );
                _na . NA007 = table . Rows [ i ] [ "NA007" ] . ToString ( );
                _na . NA008 = table . Rows [ i ] [ "NA008" ] . ToString ( );
                _na . NA009 = table . Rows [ i ] [ "NA009" ] . ToString ( );
                if ( _na . idx < 1 )
                    add_pqna ( SQLString ,strSql ,_na );
                else
                    edit_pqna ( SQLString ,strSql ,_na );
            }

            if ( strList . Count > 0 )
            {
                foreach ( string s in strList )
                {
                    _na . idx = Convert . ToInt32 ( s );
                    delete_pqna ( SQLString ,strSql ,_na );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void edit_pqn ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . CustomerrecordEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQN set " );
            strSql . Append ( "KH02=@KH02," );
            strSql . Append ( "KH03=@KH03," );
            strSql . Append ( "KH04=@KH04," );
            strSql . Append ( "KH05=@KH05," );
            strSql . Append ( "KH06=@KH06," );
            strSql . Append ( "KH07=@KH07," );
            strSql . Append ( "KH08=@KH08," );
            strSql . Append ( "KH09=@KH09," );
            strSql . Append ( "KH10=@KH10," );
            strSql . Append ( "KH11=@KH11," );
            strSql . Append ( "KH12=@KH12," );
            strSql . Append ( "KH13=@KH13," );
            strSql . Append ( "KH14=@KH14," );
            strSql . Append ( "KH15=@KH15," );
            strSql . Append ( "KH16=@KH16," );
            strSql . Append ( "KH17=@KH17," );
            strSql . Append ( "KH18=@KH18," );
            strSql . Append ( "KH19=@KH19," );
            strSql . Append ( "KH20=@KH20," );
            strSql . Append ( "KH21=@KH21," );
            strSql . Append ( "KH22=@KH22," );
            strSql . Append ( "KH23=@KH23," );
            strSql . Append ( "KH24=@KH24," );
            strSql . Append ( "KH25=@KH25," );
            strSql . Append ( "KH26=@KH26," );
            strSql . Append ( "KH27=@KH27," );
            strSql . Append ( "KH28=@KH28," );
            strSql . Append ( "KH29=@KH29," );
            strSql . Append ( "KH30=@KH30," );
            strSql . Append ( "KH31=@KH31," );
            strSql . Append ( "KH32=@KH32," );
            strSql . Append ( "KH33=@KH33," );
            strSql . Append ( "KH34=@KH34," );
            strSql . Append ( "KH35=@KH35 " );
            strSql . Append ( " where KH01=@KH01" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@KH01", SqlDbType.NVarChar,20),
                    new SqlParameter("@KH02", SqlDbType.NVarChar,20),
                    new SqlParameter("@KH03", SqlDbType.NVarChar,20),
                    new SqlParameter("@KH04", SqlDbType.NVarChar,20),
                    new SqlParameter("@KH05", SqlDbType.NVarChar,20),
                    new SqlParameter("@KH06", SqlDbType.Int,4),
                    new SqlParameter("@KH07", SqlDbType.VarBinary,-1),
                    new SqlParameter("@KH08", SqlDbType.Date,3),
                    new SqlParameter("@KH09", SqlDbType.NVarChar,20),
                    new SqlParameter("@KH10", SqlDbType.NVarChar,20),
                    new SqlParameter("@KH11", SqlDbType.Bit,1),
                    new SqlParameter("@KH12", SqlDbType.Bit,1),
                    new SqlParameter("@KH13", SqlDbType.Bit,1),
                    new SqlParameter("@KH14", SqlDbType.NVarChar,20),
                    new SqlParameter("@KH15", SqlDbType.Bit,1),
                    new SqlParameter("@KH16", SqlDbType.Bit,1),
                    new SqlParameter("@KH17", SqlDbType.NVarChar,20),
                    new SqlParameter("@KH18", SqlDbType.Bit,1),
                    new SqlParameter("@KH19", SqlDbType.NVarChar,20),
                    new SqlParameter("@KH20", SqlDbType.Bit,1),
                    new SqlParameter("@KH21", SqlDbType.Bit,1),
                    new SqlParameter("@KH22", SqlDbType.Bit,1),
                    new SqlParameter("@KH23", SqlDbType.Bit,1),
                    new SqlParameter("@KH24", SqlDbType.Bit,1),
                    new SqlParameter("@KH25", SqlDbType.Bit,1),
                    new SqlParameter("@KH26", SqlDbType.NVarChar,100),
                    new SqlParameter("@KH27", SqlDbType.NVarChar,100),
                    new SqlParameter("@KH28", SqlDbType.NVarChar,100),
                    new SqlParameter("@KH29", SqlDbType.NVarChar,100),
                    new SqlParameter("@KH30", SqlDbType.NVarChar,20),
                    new SqlParameter("@KH31", SqlDbType.Date,3),
                    new SqlParameter("@KH32", SqlDbType.NVarChar,20),
                    new SqlParameter("@KH33", SqlDbType.Date,3),
                    new SqlParameter("@KH34", SqlDbType.NVarChar,200),
                    new SqlParameter("@KH35", SqlDbType.NVarChar,200)
            };
            parameters [ 0 ] . Value = model . KH01;
            parameters [ 1 ] . Value = model . KH02;
            parameters [ 2 ] . Value = model . KH03;
            parameters [ 3 ] . Value = model . KH04;
            parameters [ 4 ] . Value = model . KH05;
            parameters [ 5 ] . Value = model . KH06;
            parameters [ 6 ] . Value = model . KH07;
            parameters [ 7 ] . Value = model . KH08;
            parameters [ 8 ] . Value = model . KH09;
            parameters [ 9 ] . Value = model . KH10;
            parameters [ 10 ] . Value = model . KH11;
            parameters [ 11 ] . Value = model . KH12;
            parameters [ 12 ] . Value = model . KH13;
            parameters [ 13 ] . Value = model . KH14;
            parameters [ 14 ] . Value = model . KH15;
            parameters [ 15 ] . Value = model . KH16;
            parameters [ 16 ] . Value = model . KH17;
            parameters [ 17 ] . Value = model . KH18;
            parameters [ 18 ] . Value = model . KH19;
            parameters [ 19 ] . Value = model . KH20;
            parameters [ 20 ] . Value = model . KH21;
            parameters [ 21 ] . Value = model . KH22;
            parameters [ 22 ] . Value = model . KH23;
            parameters [ 23 ] . Value = model . KH24;
            parameters [ 24 ] . Value = model . KH25;
            parameters [ 25 ] . Value = model . KH26;
            parameters [ 26 ] . Value = model . KH27;
            parameters [ 27 ] . Value = model . KH28;
            parameters [ 28 ] . Value = model . KH29;
            parameters [ 29 ] . Value = model . KH30;
            parameters [ 30 ] . Value = model . KH31;
            parameters [ 31 ] . Value = model . KH32;
            parameters [ 32 ] . Value = model . KH33;
            parameters [ 33 ] . Value = model . KH34;
            parameters [ 34 ] . Value = model . KH35;

            SQLString . Add ( strSql ,parameters );
        }

        void edit_pqna ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . CustomerrecordNAEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQNA set " );
            strSql . Append ( "NA001=@NA001," );
            strSql . Append ( "NA002=@NA002," );
            strSql . Append ( "NA003=@NA003," );
            strSql . Append ( "NA004=@NA004," );
            strSql . Append ( "NA005=@NA005," );
            strSql . Append ( "NA006=@NA006," );
            strSql . Append ( "NA007=@NA007," );
            strSql . Append ( "NA008=@NA008," );
            strSql . Append ( "NA009=@NA009 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@NA001", SqlDbType.NVarChar,20),
                    new SqlParameter("@NA002", SqlDbType.NVarChar,20),
                    new SqlParameter("@NA003", SqlDbType.NVarChar,20),
                    new SqlParameter("@NA004", SqlDbType.NVarChar,20),
                    new SqlParameter("@NA005", SqlDbType.NVarChar,20),
                    new SqlParameter("@NA006", SqlDbType.NVarChar,20),
                    new SqlParameter("@NA007", SqlDbType.NVarChar,20),
                    new SqlParameter("@NA008", SqlDbType.NVarChar,50),
                    new SqlParameter("@NA009", SqlDbType.NVarChar,20),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . NA001;
            parameters [ 1 ] . Value = model . NA002;
            parameters [ 2 ] . Value = model . NA003;
            parameters [ 3 ] . Value = model . NA004;
            parameters [ 4 ] . Value = model . NA005;
            parameters [ 5 ] . Value = model . NA006;
            parameters [ 6 ] . Value = model . NA007;
            parameters [ 7 ] . Value = model . NA008;
            parameters [ 8 ] . Value = model . NA009;
            parameters [ 9 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
        }

        void delete_pqna ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . CustomerrecordNAEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQNA " );
            strSql . AppendFormat ( "WHERE idx={0}" ,model . idx );

            SQLString . Add ( strSql ,null );
        }

        /// <summary>
        /// get max oddNum from r_pqn
        /// </summary>
        /// <returns></returns>
        public string getOddNum ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(KH01) KH01 FROM R_PQN " );
            strSql . AppendFormat ( "WHERE KH01 LIKE 'R_369-{0}%'" ,Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                string oddNum = dt . Rows [ 0 ] [ "KH01" ] . ToString ( );
                if ( string . IsNullOrEmpty ( oddNum ) )
                    return "R_369-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "0001";
                else
                {
                    oddNum = "R_369-" + ( Convert . ToInt64 ( oddNum . Substring ( 6 ,12 ) ) + 1 ) . ToString ( );
                    return oddNum;
                }
            }
            else
                return "R_369-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "0001";
        }

    }
}

using System;
using System . Text;
using StudentMgr;
using System . Collections;
using System . Data;

namespace MulaolaoBll . Dao
{
    public class CustomerInspectionTableDao
    {
        /// <summary>
        /// read data from r_293 to view
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public bool Read ( int year )
        {
            //398

            //出货批次=直通批次+二次通过+条件接受

            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            strSql . AppendFormat ( "DELETE FROM R_PQDM WHERE DM001='{0}'" ,year );
            
            SQLString . Add ( strSql ,null );
            if ( SQLString . Count > 0 && SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                SQLString . Clear ( );

                MulaolaoLibrary . CustomerInspectionTableDMEntity model = new MulaolaoLibrary . CustomerInspectionTableDMEntity ( );
                model . DM001 = year;

                //怡人  出货批次
                DataTable da = getTableCount ( year );
                if ( da != null && da . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < da . Rows . Count ; i++ )
                    {
                        model . DM002 = da . Rows [ i ] [ "DK007" ] . ToString ( );
                        model . DM003 = da . Rows [ i ] [ "DK008" ] . ToString ( );
                        model . DM004 = string . IsNullOrEmpty ( da . Rows [ i ] [ "DK015" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "DK015" ] . ToString ( ) );
                        model . DM005 = string . IsNullOrEmpty ( da . Rows [ i ] [ "COUN" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "COUN" ] . ToString ( ) );
                        if ( model . DM004 > 0 )
                        {
                            if ( Exists ( model ) )
                                editdm005 ( SQLString ,strSql ,model );
                            else
                                adddm005 ( SQLString ,strSql ,model );
                        }
                    }

                    if ( SQLString . Count > 0 && SqlHelper . ExecuteSqlTran ( SQLString ) )
                    {
                        SQLString . Clear ( );
                        //班组合计  出货批次
                        da = getTableCountAll ( year );
                        if ( da != null && da . Rows . Count > 0 )
                        {
                            for ( int i = 0 ; i < da . Rows . Count ; i++ )
                            {
                                model . DM002 = da . Rows [ i ] [ "DK007" ] . ToString ( );
                                model . DM003 = da . Rows [ i ] [ "DK008" ] . ToString ( );
                                model . DM004 = string . IsNullOrEmpty ( da . Rows [ i ] [ "DK015" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "DK015" ] . ToString ( ) );
                                model . DM005 = string . IsNullOrEmpty ( da . Rows [ i ] [ "COUN" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "COUN" ] . ToString ( ) );
                                if ( model . DM004 > 0 )
                                {
                                    if ( Exists ( model ) )
                                        editdm005 ( SQLString ,strSql ,model );
                                    else
                                        adddm005 ( SQLString ,strSql ,model );
                                }
                            }
                        }
                    }

                   if ( SQLString . Count > 0 && SqlHelper . ExecuteSqlTran ( SQLString ) )
                    {
                        SQLString . Clear ( );
                        // 怡人 通过
                        da = getTableOneCount ( year );
                        if ( da != null && da . Rows . Count > 0 )
                        {
                            for ( int i = 0 ; i < da . Rows . Count ; i++ )
                            {
                                model . DM002 = da . Rows [ i ] [ "DK007" ] . ToString ( );
                                model . DM003 = da . Rows [ i ] [ "DK008" ] . ToString ( );
                                model . DM004 = string . IsNullOrEmpty ( da . Rows [ i ] [ "DK015" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "DK015" ] . ToString ( ) );
                                model . DM006 = string . IsNullOrEmpty ( da . Rows [ i ] [ "COUN" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "COUN" ] . ToString ( ) );
                                model . DM005 = 0;
                                model . DM007 = 0;
                                model . DM008 = 0;
                                model . DM009 = 0;
                                if ( Exists ( model ) )
                                    editdm006 ( SQLString ,strSql ,model );
                                else
                                    adddm005 ( SQLString ,strSql ,model );
                            }
                        }
                    }

                    if ( SQLString . Count > 0 && SqlHelper . ExecuteSqlTran ( SQLString ) )
                    {
                        SQLString . Clear ( );
                        //班组合计 通过
                        da = getTableOneCountAll ( year );
                        if ( da != null && da . Rows . Count > 0 )
                        {
                            for ( int i = 0 ; i < da . Rows . Count ; i++ )
                            {
                                model . DM002 = da . Rows [ i ] [ "DK007" ] . ToString ( );
                                model . DM003 = da . Rows [ i ] [ "DK008" ] . ToString ( );
                                model . DM004 = string . IsNullOrEmpty ( da . Rows [ i ] [ "DK015" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "DK015" ] . ToString ( ) );
                                model . DM006 = string . IsNullOrEmpty ( da . Rows [ i ] [ "COUN" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "COUN" ] . ToString ( ) );
                                model . DM005 = 0;
                                model . DM007 = 0;
                                model . DM008 = 0;
                                model . DM009 = 0;
                                if ( Exists ( model ) )
                                    editdm006 ( SQLString ,strSql ,model );
                                else
                                    adddm005 ( SQLString ,strSql ,model );
                            }
                        }
                    }

                    if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
                    {
                        SQLString . Clear ( );
                        //怡人  二次通过
                        da = getTableThanOneCount ( year );
                        if ( da != null && da . Rows . Count > 0 )
                        {
                            for ( int i = 0 ; i < da . Rows . Count ; i++ )
                            {
                                model . DM002 = da . Rows [ i ] [ "DK007" ] . ToString ( );
                                model . DM003 = da . Rows [ i ] [ "DK008" ] . ToString ( );
                                model . DM004 = string . IsNullOrEmpty ( da . Rows [ i ] [ "DK015" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "DK015" ] . ToString ( ) );
                                model . DM007 = string . IsNullOrEmpty ( da . Rows [ i ] [ "COUN" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "COUN" ] . ToString ( ) );
                                model . DM005 = 0;
                                model . DM006 = 0;
                                model . DM008 = 0;
                                model . DM009 = 0;
                                if ( Exists ( model ) )
                                    editdm007 ( SQLString ,strSql ,model );
                                else
                                    adddm005 ( SQLString ,strSql ,model );
                            }
                        }
                    }

                    if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
                    {
                        SQLString . Clear ( );
                        //班组合计  二次通过
                        da = getTableThanOneCountAll ( year );
                        if ( da != null && da . Rows . Count > 0 )
                        {
                            for ( int i = 0 ; i < da . Rows . Count ; i++ )
                            {
                                model . DM002 = da . Rows [ i ] [ "DK007" ] . ToString ( );
                                model . DM003 = da . Rows [ i ] [ "DK008" ] . ToString ( );
                                model . DM004 = string . IsNullOrEmpty ( da . Rows [ i ] [ "DK015" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "DK015" ] . ToString ( ) );
                                model . DM007 = string . IsNullOrEmpty ( da . Rows [ i ] [ "COUN" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "COUN" ] . ToString ( ) );
                                model . DM005 = 0;
                                model . DM006 = 0;
                                model . DM008 = 0;
                                model . DM009 = 0;
                                if ( Exists ( model ) )
                                    editdm007 ( SQLString ,strSql ,model );
                                else
                                    adddm005 ( SQLString ,strSql ,model );
                            }
                        }
                    }
                    if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
                    {
                        SQLString . Clear ( );
                        //怡人  退货
                        da = getTableThCount ( year );
                        if ( da != null && da . Rows . Count > 0 )
                        {
                            for ( int i = 0 ; i < da . Rows . Count ; i++ )
                            {
                                model . DM002 = da . Rows [ i ] [ "DK007" ] . ToString ( );
                                model . DM003 = da . Rows [ i ] [ "DK008" ] . ToString ( );
                                model . DM004 = string . IsNullOrEmpty ( da . Rows [ i ] [ "DK015" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "DK015" ] . ToString ( ) );
                                model . DM008 = string . IsNullOrEmpty ( da . Rows [ i ] [ "COUN" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "COUN" ] . ToString ( ) );
                                model . DM005 = 0;
                                model . DM006 = 0;
                                model . DM007 = 0;
                                model . DM009 = 0;
                                if ( Exists ( model ) )
                                    editdm008 ( SQLString ,strSql ,model );
                                else
                                    adddm005 ( SQLString ,strSql ,model );
                            }
                        }
                    }

                    if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
                    {
                        SQLString . Clear ( );
                        //班组合计 退货
                        da = getTableThCountAll ( year );
                        if ( da != null && da . Rows . Count > 0 )
                        {
                            for ( int i = 0 ; i < da . Rows . Count ; i++ )
                            {
                                model . DM002 = da . Rows [ i ] [ "DK007" ] . ToString ( );
                                model . DM003 = da . Rows [ i ] [ "DK008" ] . ToString ( );
                                model . DM004 = string . IsNullOrEmpty ( da . Rows [ i ] [ "DK015" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "DK015" ] . ToString ( ) );
                                model . DM008 = string . IsNullOrEmpty ( da . Rows [ i ] [ "COUN" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "COUN" ] . ToString ( ) );
                                model . DM005 = 0;
                                model . DM006 = 0;
                                model . DM007 = 0;
                                model . DM009 = 0;
                                if ( Exists ( model ) )
                                    editdm008 ( SQLString ,strSql ,model );
                                else
                                    adddm005 ( SQLString ,strSql ,model );
                            }
                        }
                    }
                    if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
                    {
                        SQLString . Clear ( );
                        //怡人  条件接收
                        da = getTableTjCount ( year );
                        if ( da != null && da . Rows . Count > 0 )
                        {
                            for ( int i = 0 ; i < da . Rows . Count ; i++ )
                            {
                                model . DM002 = da . Rows [ i ] [ "DK007" ] . ToString ( );
                                model . DM003 = da . Rows [ i ] [ "DK008" ] . ToString ( );
                                model . DM004 = string . IsNullOrEmpty ( da . Rows [ i ] [ "DK015" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "DK015" ] . ToString ( ) );
                                model . DM009 = string . IsNullOrEmpty ( da . Rows [ i ] [ "COUN" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "COUN" ] . ToString ( ) );
                                model . DM005 = 0;
                                model . DM006 = 0;
                                model . DM007 = 0;
                                model . DM008 = 0;
                                if ( Exists ( model ) )
                                    editdm009 ( SQLString ,strSql ,model );
                                else
                                    adddm005 ( SQLString ,strSql ,model );
                            }
                        }
                    }

                    if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
                    {
                        SQLString . Clear ( );
                        //班组合计  条件接收
                        da = getTableTjCountAll ( year );
                        if ( da != null && da . Rows . Count > 0 )
                        {
                            for ( int i = 0 ; i < da . Rows . Count ; i++ )
                            {
                                model . DM002 = da . Rows [ i ] [ "DK007" ] . ToString ( );
                                model . DM003 = da . Rows [ i ] [ "DK008" ] . ToString ( );
                                model . DM004 = string . IsNullOrEmpty ( da . Rows [ i ] [ "DK015" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "DK015" ] . ToString ( ) );
                                model . DM009 = string . IsNullOrEmpty ( da . Rows [ i ] [ "COUN" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "COUN" ] . ToString ( ) );
                                model . DM005 = 0;
                                model . DM006 = 0;
                                model . DM007 = 0;
                                model . DM008 = 0;
                                if ( Exists ( model ) )
                                    editdm009 ( SQLString ,strSql ,model );
                                else
                                    adddm005 ( SQLString ,strSql ,model );
                            }
                        }
                    }
                    return SqlHelper . ExecuteSqlTran ( SQLString );
                }
            }
            else
                return false;

            return true;
        }

        /// <summary>
        ///  班组合计  条件接收
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        DataTable getTableTjCountAll ( int year )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT MONTH(DK012) DK015,COUNT(1) COUN,DK008,'班组合计' DK007 FROM R_PQDK WHERE YEAR(DK012)={0} AND DK038='条件接收' GROUP BY MONTH(DK012),DK008" ,year );//DK011>1

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 怡人  非怡人  非二次通过  出货批次
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        DataTable getTableCount ( int year )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT MONTH(DK012) DK015,COUNT(1) COUN,DK008,CASE WHEN DK007 LIKE '%怡人%' THEN '怡人' ELSE '非怡人' END DK007 FROM R_PQDK WHERE YEAR(DK012)={0} AND DK038!='二次通过' GROUP BY MONTH(DK012),DK008,CASE WHEN DK007 LIKE '%怡人%' THEN '怡人' ELSE '非怡人' END" ,year );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 班组合计  非二次通过
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        DataTable getTableCountAll ( int year )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT MONTH(DK012) DK015,COUNT(1) COUN,DK008,'班组合计' DK007 FROM R_PQDK WHERE YEAR(DK012)={0} AND DK038!='二次通过' GROUP BY MONTH(DK012),DK008" ,year );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 班组合计   二次通过
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        DataTable getTableCountAllTwo ( int year )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT MONTH(DK012) DK015,COUNT(1) COUN,DK008,'班组合计' DK007 FROM R_PQDK WHERE YEAR(DK012)={0} AND DK038='二次通过' GROUP BY MONTH(DK012),DK008" ,year );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        ///   班组合计   二次通过
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        DataTable getTableThanOneCountAll ( int year )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT MONTH(DK012) DK015,COUNT(1) COUN,DK008,'班组合计' DK007 FROM R_PQDK WHERE YEAR(DK012)={0} AND DK038='二次通过' GROUP BY MONTH(DK012),DK008" ,year );//DK011>1

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 班组合计    通过
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        DataTable getTableOneCountAll ( int year )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT MONTH(DK012) DK015,COUNT(1) COUN,DK008,'班组合计' DK007 FROM R_PQDK WHERE YEAR(DK012)={0} AND DK038='通过' GROUP BY MONTH(DK012),DK008" ,year );//DK011=1

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }


        /// <summary>
        ///  班组合计  退货
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        DataTable getTableThCountAll ( int year )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT MONTH(DK012) DK015,COUNT(1) COUN,DK008,'班组合计' DK007 FROM R_PQDK WHERE YEAR(DK012)={0} AND DK038='退货' GROUP BY MONTH(DK012),DK008" ,year );//DK011>1

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 怡人  非怡人  二次通过  出货批次
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        DataTable getTableCountTwo ( int year )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT MONTH(DK012) DK015,COUNT(1) COUN,DK008,CASE WHEN DK007 LIKE '%怡人%' THEN '怡人' ELSE '非怡人' END DK007 FROM R_PQDK WHERE YEAR(DK012)={0} AND DK038='二次通过' GROUP BY MONTH(DK012),DK008,CASE WHEN DK007 LIKE '%怡人%' THEN '怡人' ELSE '非怡人' END" ,year );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        ///  怡人  非怡人   二次通过
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        DataTable getTableThanOneCount ( int year )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT MONTH(DK012) DK015,COUNT(1) COUN,DK008,CASE WHEN DK007 LIKE '%怡人%' THEN '怡人' ELSE '非怡人' END DK007 FROM R_PQDK WHERE YEAR(DK012)={0} AND DK038='二次通过' GROUP BY MONTH(DK012),DK008,CASE WHEN DK007 LIKE '%怡人%' THEN '怡人' ELSE '非怡人' END" ,year );//DK011>1

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 怡人  非怡人   通过
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        DataTable getTableOneCount ( int year )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT MONTH(DK012) DK015,COUNT(1) COUN,DK008,CASE WHEN DK007 LIKE '%怡人%' THEN '怡人' ELSE '非怡人' END DK007 FROM R_PQDK WHERE YEAR(DK012)={0} AND DK038='通过'  GROUP BY MONTH(DK012),DK008,CASE WHEN DK007 LIKE '%怡人%' THEN '怡人' ELSE '非怡人' END" ,year );//AND DK011=1

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }


        /// <summary>
        ///  怡人  非怡人  退货
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        DataTable getTableThCount ( int year )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT MONTH(DK012) DK015,COUNT(1) COUN,DK008,CASE WHEN DK007 LIKE '%怡人%' THEN '怡人' ELSE '非怡人' END DK007 FROM R_PQDK WHERE YEAR(DK012)={0} AND DK038='退货' GROUP BY MONTH(DK012),DK008,CASE WHEN DK007 LIKE '%怡人%' THEN '怡人' ELSE '非怡人' END" ,year );//DK011>1

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }



        /// <summary>
        ///  怡人  非怡人   条件接收
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        DataTable getTableTjCount ( int year )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT MONTH(DK012) DK015,COUNT(1) COUN,DK008,CASE WHEN DK007 LIKE '%怡人%' THEN '怡人' ELSE '非怡人' END DK007 FROM R_PQDK WHERE YEAR(DK012)={0} AND DK038='条件接收' GROUP BY MONTH(DK012),DK008,CASE WHEN DK007 LIKE '%怡人%' THEN '怡人' ELSE '非怡人' END" ,year );//DK011>1

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }



        /// <summary>
        /// exists this year and month
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        bool Exists ( MulaolaoLibrary.CustomerInspectionTableDMEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM R_PQDM " );
            strSql . AppendFormat ( "WHERE DM001={0} AND DM004={1} AND DM002='{2}' AND DM003='{3}'" ,model . DM001 ,model . DM004 ,model . DM002 ,model . DM003 );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        void editdm005 ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . CustomerInspectionTableDMEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQDM SET " );
            strSql . AppendFormat ( "DM005={0} " ,model . DM005 );
            strSql . AppendFormat ( "WHERE DM001={0} AND DM004={1} AND DM002='{2}' AND DM003='{3}'" ,model . DM001 ,model . DM004 ,model . DM002 ,model . DM003 );

            SQLString . Add ( strSql ,null );
        }

        void editdm006 ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . CustomerInspectionTableDMEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQDM SET " );
            strSql . AppendFormat ( "DM006={0} " ,model . DM006 );
            strSql . AppendFormat ( "WHERE DM001={0} AND DM004={1} AND DM002='{2}' AND DM003='{3}'" ,model . DM001 ,model . DM004 ,model . DM002 ,model . DM003 );

            SQLString . Add ( strSql ,null );
        }

        void editdm007 ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . CustomerInspectionTableDMEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQDM SET " );
            strSql . AppendFormat ( "DM007={0} " ,model . DM007 );
            strSql . AppendFormat ( "WHERE DM001={0} AND DM004={1} AND DM002='{2}' AND DM003='{3}'" ,model . DM001 ,model . DM004 ,model . DM002 ,model . DM003 );

            SQLString . Add ( strSql ,null );
        }

        void editdm008 ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . CustomerInspectionTableDMEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQDM SET " );
            strSql . AppendFormat ( "DM008={0} " ,model . DM008 );
            strSql . AppendFormat ( "WHERE DM001={0} AND DM004={1} AND DM002='{2}' AND DM003='{3}'" ,model . DM001 ,model . DM004 ,model . DM002 ,model . DM003 );

            SQLString . Add ( strSql ,null );
        }

        void editdm009 ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . CustomerInspectionTableDMEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQDM SET " );
            strSql . AppendFormat ( "DM009={0} " ,model . DM009 );
            strSql . AppendFormat ( "WHERE DM001={0} AND DM004={1} AND DM002='{2}' AND DM003='{3}'" ,model . DM001 ,model . DM004 ,model . DM002 ,model . DM003 );

            SQLString . Add ( strSql ,null );
        }

        void adddm005 ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . CustomerInspectionTableDMEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQDM (" );
            strSql . Append ( "DM001,DM002,DM003,DM004,DM005,DM006,DM007,DM008,DM009) " );
            strSql . Append ( "VALUES (" );
            strSql . AppendFormat ( "{0},'{1}','{2}',{3},{4},{5},{6},{7},{8})" ,model . DM001 ,model . DM002 ,model . DM003 ,model . DM004 ,model . DM005 ,model . DM006 ,model . DM007 ,model . DM008 ,model . DM009 );

            SQLString . Add ( strSql ,null );
        }

        /// <summary>
        /// get table from r_pqdm to view
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable getTableView ( int year )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT idx,DM001,DM002,DM003,DM004,DM005,DM006,DM007,DM008,DM009 FROM R_PQDM WHERE DM001={0} ORDER BY DM001,DM004,DM002,DM003" ,year );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// delete data for year 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public bool Delete ( int year )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM R_PQDM WHERE DM001={0}" ,year );

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

    }
}

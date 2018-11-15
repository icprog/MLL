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
    public class StandardTestDao
    {
        /// <summary>
        /// get data from r_pqcl to view 
        /// </summary>
        /// <returns></returns>
        public DataTable getViewOne ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,CL001,CL002,CL003,CL004,CL005,CL006,CL007 FROM R_PQCL ORDER BY CL001" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get data from r_pqcm to view 
        /// </summary>
        /// <returns></returns>
        public DataTable getViewTwo ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,CM001,CM002,CM003,CM004,CM005,CM006,CM007 FROM R_PQCM ORDER BY CM001" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// save data to database for r_pqcl r_pqcm
        /// </summary>
        /// <param name="tableOne"></param>
        /// <param name="tableTwo"></param>
        /// <param name="strList"></param>
        /// <param name="strL"></param>
        /// <returns></returns>
        public bool Save ( DataTable tableOne ,DataTable tableTwo ,List<string> strList ,List<string> strL )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            MulaolaoLibrary . StandardTestCLEntity _cl = new MulaolaoLibrary . StandardTestCLEntity ( );
            for ( int i = 0 ; i < tableOne . Rows . Count ; i++ )
            {
                if ( string . IsNullOrEmpty ( tableOne . Rows [ i ] [ "CL001" ] . ToString ( ) ) )
                    _cl . CL001 = null;
                else
                    _cl . CL001 = int . Parse ( tableOne . Rows [ i ] [ "CL001" ] . ToString ( ) );
                if ( string . IsNullOrEmpty ( tableOne . Rows [ i ] [ "CL002" ] . ToString ( ) ) )
                    _cl . CL002 = null;
                else
                    _cl . CL002 = int . Parse ( tableOne . Rows [ i ] [ "CL002" ] . ToString ( ) );
                if ( string . IsNullOrEmpty ( tableOne . Rows [ i ] [ "CL003" ] . ToString ( ) ) )
                    _cl . CL003 = null;
                else
                    _cl . CL003 = int . Parse ( tableOne . Rows [ i ] [ "CL003" ] . ToString ( ) );
                if ( string . IsNullOrEmpty ( tableOne . Rows [ i ] [ "CL004" ] . ToString ( ) ) )
                    _cl . CL004 = null;
                else
                    _cl . CL004 = int . Parse ( tableOne . Rows [ i ] [ "CL004" ] . ToString ( ) );
                if ( string . IsNullOrEmpty ( tableOne . Rows [ i ] [ "CL005" ] . ToString ( ) ) )
                    _cl . CL005 = null;
                else
                    _cl . CL005 = int . Parse ( tableOne . Rows [ i ] [ "CL005" ] . ToString ( ) );
                if ( string . IsNullOrEmpty ( tableOne . Rows [ i ] [ "CL006" ] . ToString ( ) ) )
                    _cl . CL006 = null;
                else
                    _cl . CL006 = int . Parse ( tableOne . Rows [ i ] [ "CL006" ] . ToString ( ) );
                if ( string . IsNullOrEmpty ( tableOne . Rows [ i ] [ "CL007" ] . ToString ( ) ) )
                    _cl . CL007 = null;
                else
                    _cl . CL007 = int . Parse ( tableOne . Rows [ i ] [ "CL007" ] . ToString ( ) );
                _cl . idx = string . IsNullOrEmpty ( tableOne . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableOne . Rows [ i ] [ "idx" ] . ToString ( ) );
                if ( _cl . idx > 0 )
                    edit_cl ( SQLString ,strSql ,_cl );
                else
                    add_cl ( SQLString ,strSql ,_cl );
            }

            if ( strList . Count > 0 )
            {
                foreach ( string s in strList )
                {
                    _cl . idx = Convert . ToInt32 ( s );
                    delete_cl ( SQLString ,strSql ,_cl );
                }
            }

            MulaolaoLibrary . StandardTestCMEntity _cm = new MulaolaoLibrary . StandardTestCMEntity ( );
            for ( int i = 0 ; i < tableTwo . Rows . Count ; i++ )
            {
                if ( string . IsNullOrEmpty ( tableTwo . Rows [ i ] [ "CM001" ] . ToString ( ) ) )
                    _cm . CM001 = null;
                else
                    _cm . CM001 = int . Parse ( tableTwo . Rows [ i ] [ "CM001" ] . ToString ( ) );
                if ( string . IsNullOrEmpty ( tableTwo . Rows [ i ] [ "CM002" ] . ToString ( ) ) )
                    _cm . CM002 = null;
                else
                    _cm . CM002 = int . Parse ( tableTwo . Rows [ i ] [ "CM002" ] . ToString ( ) );
                if ( string . IsNullOrEmpty ( tableTwo . Rows [ i ] [ "CM003" ] . ToString ( ) ) )
                    _cm . CM003 = null;
                else
                    _cm . CM003 = int . Parse ( tableTwo . Rows [ i ] [ "CM003" ] . ToString ( ) );
                if ( string . IsNullOrEmpty ( tableTwo . Rows [ i ] [ "CM004" ] . ToString ( ) ) )
                    _cm . CM004 = null;
                else
                    _cm . CM004 = int . Parse ( tableTwo . Rows [ i ] [ "CM004" ] . ToString ( ) );
                if ( string . IsNullOrEmpty ( tableTwo . Rows [ i ] [ "CM005" ] . ToString ( ) ) )
                    _cm . CM005 = null;
                else
                    _cm . CM005 = int . Parse ( tableTwo . Rows [ i ] [ "CM005" ] . ToString ( ) );
                if ( string . IsNullOrEmpty ( tableTwo . Rows [ i ] [ "CM006" ] . ToString ( ) ) )
                    _cm . CM006 = null;
                else
                    _cm . CM006 = int . Parse ( tableTwo . Rows [ i ] [ "CM006" ] . ToString ( ) );
                if ( string . IsNullOrEmpty ( tableTwo . Rows [ i ] [ "CM007" ] . ToString ( ) ) )
                    _cm . CM007 = null;
                else
                    _cm . CM007 = int . Parse ( tableTwo . Rows [ i ] [ "CM007" ] . ToString ( ) );
                _cm . idx = string . IsNullOrEmpty ( tableTwo . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableTwo . Rows [ i ] [ "idx" ] . ToString ( ) );
                if ( _cm . idx > 0 )
                    edit_cm ( SQLString ,strSql ,_cm );
                else
                    add_cm ( SQLString ,strSql ,_cm );
            }

            if ( strL . Count > 0 )
            {
                foreach ( string s in strL )
                {
                    _cm . idx = Convert . ToInt32 ( s );
                    delete_cm ( SQLString ,strSql ,_cm );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void add_cl ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . StandardTestCLEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_PQCL(" );
            strSql . Append ( "CL001,CL002,CL003,CL004,CL005,CL006,CL007)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@CL001,@CL002,@CL003,@CL004,@CL005,@CL006,@CL007)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CL001", SqlDbType.Int,4),
                    new SqlParameter("@CL002", SqlDbType.Int,4),
                    new SqlParameter("@CL003", SqlDbType.Int,4),
                    new SqlParameter("@CL004", SqlDbType.Int,4),
                    new SqlParameter("@CL005", SqlDbType.Int,4),
                    new SqlParameter("@CL006", SqlDbType.Int,4),
                    new SqlParameter("@CL007", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . CL001;
            parameters [ 1 ] . Value = model . CL002;
            parameters [ 2 ] . Value = model . CL003;
            parameters [ 3 ] . Value = model . CL004;
            parameters [ 4 ] . Value = model . CL005;
            parameters [ 5 ] . Value = model . CL006;
            parameters [ 6 ] . Value = model . CL007;

            SQLString . Add ( strSql ,parameters );
        }

        void edit_cl ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . StandardTestCLEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQCL set " );
            strSql . Append ( "CL001=@CL001," );
            strSql . Append ( "CL002=@CL002," );
            strSql . Append ( "CL003=@CL003," );
            strSql . Append ( "CL004=@CL004," );
            strSql . Append ( "CL005=@CL005," );
            strSql . Append ( "CL006=@CL006," );
            strSql . Append ( "CL007=@CL007 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CL001", SqlDbType.Int,4),
                    new SqlParameter("@CL002", SqlDbType.Int,4),
                    new SqlParameter("@CL003", SqlDbType.Int,4),
                    new SqlParameter("@CL004", SqlDbType.Int,4),
                    new SqlParameter("@CL005", SqlDbType.Int,4),
                    new SqlParameter("@CL006", SqlDbType.Int,4),
                    new SqlParameter("@CL007", SqlDbType.Int,4),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . CL001;
            parameters [ 1 ] . Value = model . CL002;
            parameters [ 2 ] . Value = model . CL003;
            parameters [ 3 ] . Value = model . CL004;
            parameters [ 4 ] . Value = model . CL005;
            parameters [ 5 ] . Value = model . CL006;
            parameters [ 6 ] . Value = model . CL007;
            parameters [ 7 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
        }

        void delete_cl ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . StandardTestCLEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQCL " );
            strSql . AppendFormat ( "WHERE idx={0}" ,model . idx );

            SQLString . Add ( strSql ,null );
        }

        void add_cm ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . StandardTestCMEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_PQCM(" );
            strSql . Append ( "CM001,CM002,CM003,CM004,CM005,CM006,CM007)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@CM001,@CM002,@CM003,@CM004,@CM005,@CM006,@CM007)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CM001", SqlDbType.Int,4),
                    new SqlParameter("@CM002", SqlDbType.Int,4),
                    new SqlParameter("@CM003", SqlDbType.Int,4),
                    new SqlParameter("@CM004", SqlDbType.Int,4),
                    new SqlParameter("@CM005", SqlDbType.Int,4),
                    new SqlParameter("@CM006", SqlDbType.Int,4),
                    new SqlParameter("@CM007", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . CM001;
            parameters [ 1 ] . Value = model . CM002;
            parameters [ 2 ] . Value = model . CM003;
            parameters [ 3 ] . Value = model . CM004;
            parameters [ 4 ] . Value = model . CM005;
            parameters [ 5 ] . Value = model . CM006;
            parameters [ 6 ] . Value = model . CM007;

            SQLString . Add ( strSql ,parameters );
        }

        void edit_cm ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . StandardTestCMEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQCM set " );
            strSql . Append ( "CM001=@CM001," );
            strSql . Append ( "CM002=@CM002," );
            strSql . Append ( "CM003=@CM003," );
            strSql . Append ( "CM004=@CM004," );
            strSql . Append ( "CM005=@CM005," );
            strSql . Append ( "CM006=@CM006," );
            strSql . Append ( "CM007=@CM007 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CM001", SqlDbType.Int,4),
                    new SqlParameter("@CM002", SqlDbType.Int,4),
                    new SqlParameter("@CM003", SqlDbType.Int,4),
                    new SqlParameter("@CM004", SqlDbType.Int,4),
                    new SqlParameter("@CM005", SqlDbType.Int,4),
                    new SqlParameter("@CM006", SqlDbType.Int,4),
                    new SqlParameter("@CM007", SqlDbType.Int,4),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . CM001;
            parameters [ 1 ] . Value = model . CM002;
            parameters [ 2 ] . Value = model . CM003;
            parameters [ 3 ] . Value = model . CM004;
            parameters [ 4 ] . Value = model . CM005;
            parameters [ 5 ] . Value = model . CM006;
            parameters [ 6 ] . Value = model . CM007;
            parameters [ 7 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
        }

        void delete_cm ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . StandardTestCMEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQCM " );
            strSql . AppendFormat ( "WHERE idx={0}" ,model . idx );

            SQLString . Add ( strSql ,null );
        }

    }
}

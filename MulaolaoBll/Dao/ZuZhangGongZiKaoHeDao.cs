using StudentMgr;
using System;
using System . Collections;
using System . Data;
using System . Data . SqlClient;
using System . Text;

namespace MulaolaoBll . Dao
{
    public class ZuZhangGongZiKaoHeDao
    {
        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists ( MulaolaoLibrary.ZuZhangGongZiKaoHeZaLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQZA" );
            strSql.Append( " WHERE QD001=@QD001 AND QD002=@QD002 AND QD003=@QD003" );
            SqlParameter[] parameter = {
                new SqlParameter("@QD001",SqlDbType.NVarChar),
                new SqlParameter("@QD002",SqlDbType.VarChar),
                new SqlParameter("@QD003",SqlDbType.NVarChar)
            };

            parameter[0].Value = model.QD001;
            parameter[1].Value = model.QD002;
            parameter[2].Value = model.QD003;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }


        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool ExistsIdx ( int idx ,DataTable tableQueryTwo ,MulaolaoLibrary.ZuZhangGongZiKaoHeZbLibrary modelZb ,string oddNum ,string yearMoth ,string nameOfLeader )
        {
            bool result = false;
            if ( tableQueryTwo != null )
            {
                for ( int i = 0 ; i < tableQueryTwo.Rows.Count ; i++ )
                {
                    #region
                    modelZb.QD021 = tableQueryTwo.Rows[i]["QD021"].ToString( );
                    modelZb.QD022 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD022"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["QD022"].ToString( ) );
                    modelZb.QD023 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD023"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["QD023"].ToString( ) );
                    modelZb.QD024 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD024"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["QD024"].ToString( ) );
                    modelZb.QD025 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD025"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["QD025"].ToString( ) );
                    modelZb.QD026 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD026"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["QD026"].ToString( ) );
                    modelZb.QD027 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD027"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["QD027"].ToString( ) );
                    modelZb.QD028 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD028"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["QD028"].ToString( ) );
                    modelZb.QD029 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD029"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["QD029"].ToString( ) );
                    modelZb.QD030 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD030"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["QD030"].ToString( ) );
                    modelZb.QD031 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD031"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["QD031"].ToString( ) );
                    modelZb.QD032 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD032"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["QD032"].ToString( ) );
                    modelZb.QD033 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD033"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["QD033"].ToString( ) );
                    modelZb.QD034 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD034"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["QD034"].ToString( ) );
                    modelZb.QD035 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD035"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["QD035"].ToString( ) );
                    modelZb.QD036 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD036"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["QD036"].ToString( ) );
                    modelZb.QD037 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD037"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["QD037"].ToString( ) );
                    modelZb.QD038 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD038"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["QD038"].ToString( ) );
                    modelZb.QD039 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD039"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["QD039"].ToString( ) );
                    modelZb.QD040 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD040"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["QD040"].ToString( ) );
                    modelZb.QD041 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD041"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["QD041"].ToString( ) );
                    modelZb.QD042 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD042"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["QD042"].ToString( ) );
                    modelZb.QD043 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD043"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["QD043"].ToString( ) );
                    modelZb.QD044 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD044"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["QD044"].ToString( ) );
                    modelZb.QD045 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD045"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["QD045"].ToString( ) );
                    modelZb.QD046 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD046"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["QD046"].ToString( ) );
                    modelZb.QD047 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD047"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["QD047"].ToString( ) );
                    modelZb.QD048 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD048"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["QD048"].ToString( ) );
                    modelZb.QD049 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD049"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["QD049"].ToString( ) );
                    modelZb.QD050 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD050"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["QD050"].ToString( ) );
                    modelZb.QD051 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD051"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["QD051"].ToString( ) );
                    modelZb.QD052 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD052"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["QD052"].ToString( ) );
                    modelZb.QD053 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD053"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["QD053"].ToString( ) );
                    modelZb.QD054 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD054"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["QD054"].ToString( ) );
                    modelZb.QD055 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD055"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["QD055"].ToString( ) );
                    modelZb.QD056 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD056"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["QD056"].ToString( ) );
                    modelZb.QD057 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD057"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["QD057"].ToString( ) );
                    modelZb.QD058 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD058"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["QD058"].ToString( ) );
                    modelZb.QD059 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD059"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["QD059"].ToString( ) );
                    modelZb.QD060 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD060"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["QD060"].ToString( ) );
                    modelZb.QD061 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD061"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["QD061"].ToString( ) );
                    modelZb.QD062 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD062"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["QD062"].ToString( ) );
                    modelZb.QD063 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD063"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["QD063"].ToString( ) );
                    modelZb.QD064 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD064"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["QD064"].ToString( ) );
                    modelZb.QD065 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD065"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["QD065"].ToString( ) );
                    modelZb.QD066 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD066"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["QD066"].ToString( ) );
                    modelZb.QD067 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD067"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["QD067"].ToString( ) );
                    modelZb.QD068 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD068"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["QD068"].ToString( ) );
                    modelZb.QD069 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD069"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["QD069"].ToString( ) );
                    modelZb.QD070 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD070"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["QD070"].ToString( ) );
                    modelZb.QD071 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD071"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["QD071"].ToString( ) );
                    modelZb.QD072 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD072"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["QD072"].ToString( ) );
                    modelZb.QD073 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD073"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["QD073"].ToString( ) );
                    if ( string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD099"].ToString( ) ) )
                        modelZb.QD099 = null;
                    else
                        modelZb.QD099 = Convert.ToDateTime( tableQueryTwo.Rows[i]["QD099"].ToString( ) );
                    if ( string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD100"].ToString( ) ) )
                        modelZb.QD100 = null;
                    else
                        modelZb.QD100 = Convert.ToDateTime( tableQueryTwo.Rows[i]["QD100"].ToString( ) );
                    if ( string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD101"].ToString( ) ) )
                        modelZb.QD101 = null;
                    else
                        modelZb.QD101 = Convert.ToDateTime( tableQueryTwo.Rows[i]["QD101"].ToString( ) );
                    if ( string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD104"].ToString( ) ) )
                        modelZb.QD104 = null;
                    else
                        modelZb.QD104 = Convert.ToDateTime( tableQueryTwo.Rows[i]["QD104"].ToString( ) );
                    modelZb.QD102 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD102"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["QD102"].ToString( ) );
                    modelZb.QD103 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD103"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["QD103"].ToString( ) );
                    modelZb.QD077 = oddNum;
                    modelZb.QD078 = nameOfLeader;
                    modelZb.QD079 = yearMoth;
                    modelZb.QD095 = tableQueryTwo.Rows[i]["QD095"].ToString( );
                    modelZb.QD096 = tableQueryTwo.Rows[i]["QD096"].ToString( );
                    modelZb.QD098 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["QD098"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["QD098"].ToString( ) );
                    modelZb.Idx = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["idx"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["idx"].ToString( ) );
                    #endregion

                    StringBuilder strSql = new StringBuilder( );
                    strSql.Append( "SELECT COUNT(1) FROM R_PQZB" );
                    strSql.Append( " WHERE idx=@idx" );
                    SqlParameter[] parameter = {
                            new SqlParameter("@idx",SqlDbType.Int)
                    };
                    parameter[0].Value = idx;

                    if ( SqlHelper.Exists( strSql.ToString( ) ,parameter ) == true )
                    {
                        result = UpdateZb( modelZb );
                        if ( i == tableQueryTwo.Rows.Count - 1 )
                        {
                            tableQueryTwo = null;
                            break;
                        }
                    }
                    else
                    {
                        result = AddZb( modelZb );
                        if ( i == tableQueryTwo.Rows.Count - 1 )
                        {
                            tableQueryTwo = null;
                            break;
                        }
                    }
                }
            }
            return result;
        }
        public bool UpdateTable ( DataTable table )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQZB WHERE 1=2" );

            return SqlHelper.UpdateTable( table ,strSql.ToString( ) );
        }
        public bool UpdateTableOfDelete (MulaolaoLibrary.ZuZhangGongZiKaoHeZbLibrary modelZb )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strS = new StringBuilder( );
            strS.AppendFormat( "SELECT QD078,QD079,QD094 FROM R_PQZB WHERE QD077='{0}'" ,modelZb.QD077 );
            DataTable dl = SqlHelper.ExecuteDataTable( strS.ToString( ) );
            if ( dl == null || dl.Rows.Count < 1 )
                return false;
            else
            {
                for ( int k = 0 ; k < dl.Rows.Count ; k++ )
                {
                    modelZb.QD078 = dl.Rows[k]["QD078"].ToString( );
                    modelZb.QD079 = dl.Rows[k]["QD079"].ToString( );
                    modelZb.QD094 = dl.Rows[k]["QD094"].ToString( );
                    StringBuilder strSql = new StringBuilder( );
                    strSql.Append( "SELECT QD021 PQF01,QD096 PQF03,QD095 PQF04,QD099 PQF32,QD100 PQF31,QD104 HT04,QD098 U1,QD102 U2,QD101 AE21,QD103 AE28 FROM R_PQZB " );
                    strSql.AppendFormat( " WHERE QD077='{0}' AND QD078='{1}' AND QD079='{2}' AND QD094='{3}'" ,modelZb.QD077 ,modelZb.QD078 ,modelZb.QD079 ,modelZb.QD094 );
                    DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
                    DataTable de = GetDataTableDate( modelZb.QD079.Substring( 0 ,4 ) + "-" + modelZb.QD079.Substring( 4 ,2 ) ,modelZb.QD078 );
                    if ( tableTheSame( de ,da ) == false )
                    {
                        for ( int i = 0 ; i < da.Rows.Count ; i++ )
                        {
                            if ( de.Select( "PQF01='" + da.Rows[i]["PQF01"].ToString( ) + "'" ).Length < 1 )
                                SQLString.Add( DeleteOf( da.Rows[i]["PQF01"].ToString( ) ) );
                        }
                    }
                }
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        public string DeleteOf ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQZB" );
            strSql.AppendFormat( " WHERE QD021='{0}'" ,num );

            return strSql.ToString( );
        }

        public bool UpdateTable ( DataTable table ,MulaolaoLibrary.ZuZhangGongZiKaoHeZbLibrary modelZb )
        {
            bool result = false;
            ArrayList SQLString = new ArrayList( );
            if ( table != null )
            {
                if ( tableTheSame( table ,GetDataTable( modelZb.QD077 ,modelZb.QD078 ,modelZb.QD079 ,modelZb.QD094 ) ) )
                    result = true;
                else
                {
                    for ( int i = 0 ; i < table.Rows.Count ; i++ )
                    {
                        modelZb.QD021 = table.Rows[i]["QD021"].ToString( );
                        modelZb.QD022 = string.IsNullOrEmpty( table.Rows[i]["QD022"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD022"].ToString( ) );
                        modelZb.QD023 = string.IsNullOrEmpty( table.Rows[i]["QD023"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD023"].ToString( ) );
                        modelZb.QD024 = string.IsNullOrEmpty( table.Rows[i]["QD024"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD024"].ToString( ) );
                        modelZb.QD025 = string.IsNullOrEmpty( table.Rows[i]["QD025"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD025"].ToString( ) );
                        modelZb.QD026 = string.IsNullOrEmpty( table.Rows[i]["QD026"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD026"].ToString( ) );
                        modelZb.QD027 = string.IsNullOrEmpty( table.Rows[i]["QD027"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD027"].ToString( ) );
                        modelZb.QD028 = string.IsNullOrEmpty( table.Rows[i]["QD028"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD028"].ToString( ) );
                        modelZb.QD029 = string.IsNullOrEmpty( table.Rows[i]["QD029"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD029"].ToString( ) );
                        modelZb.QD030 = string.IsNullOrEmpty( table.Rows[i]["QD030"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD030"].ToString( ) );
                        modelZb.QD031 = string.IsNullOrEmpty( table.Rows[i]["QD031"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD031"].ToString( ) );
                        modelZb.QD032 = string.IsNullOrEmpty( table.Rows[i]["QD032"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD032"].ToString( ) );
                        modelZb.QD033 = string.IsNullOrEmpty( table.Rows[i]["QD033"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD033"].ToString( ) );
                        modelZb.QD034 = string.IsNullOrEmpty( table.Rows[i]["QD034"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD034"].ToString( ) );
                        modelZb.QD035 = string.IsNullOrEmpty( table.Rows[i]["QD035"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD035"].ToString( ) );
                        modelZb.QD036 = string.IsNullOrEmpty( table.Rows[i]["QD036"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD036"].ToString( ) );
                        modelZb.QD037 = string.IsNullOrEmpty( table.Rows[i]["QD037"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD037"].ToString( ) );
                        modelZb.QD038 = string.IsNullOrEmpty( table.Rows[i]["QD038"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD038"].ToString( ) );
                        modelZb.QD039 = string.IsNullOrEmpty( table.Rows[i]["QD039"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD039"].ToString( ) );
                        modelZb.QD040 = string.IsNullOrEmpty( table.Rows[i]["QD040"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD040"].ToString( ) );
                        modelZb.QD041 = string.IsNullOrEmpty( table.Rows[i]["QD041"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD041"].ToString( ) );
                        modelZb.QD042 = string.IsNullOrEmpty( table.Rows[i]["QD042"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD042"].ToString( ) );
                        modelZb.QD043 = string.IsNullOrEmpty( table.Rows[i]["QD043"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD043"].ToString( ) );
                        modelZb.QD044 = string.IsNullOrEmpty( table.Rows[i]["QD044"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD044"].ToString( ) );
                        modelZb.QD045 = string.IsNullOrEmpty( table.Rows[i]["QD045"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD045"].ToString( ) );
                        modelZb.QD046 = string.IsNullOrEmpty( table.Rows[i]["QD046"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD046"].ToString( ) );
                        modelZb.QD047 = string.IsNullOrEmpty( table.Rows[i]["QD047"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD047"].ToString( ) );
                        modelZb.QD048 = string.IsNullOrEmpty( table.Rows[i]["QD048"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD048"].ToString( ) );
                        modelZb.QD049 = string.IsNullOrEmpty( table.Rows[i]["QD049"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD049"].ToString( ) );
                        modelZb.QD050 = string.IsNullOrEmpty( table.Rows[i]["QD050"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD050"].ToString( ) );
                        modelZb.QD051 = string.IsNullOrEmpty( table.Rows[i]["QD051"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD051"].ToString( ) );
                        modelZb.QD052 = string.IsNullOrEmpty( table.Rows[i]["QD052"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD052"].ToString( ) );
                        modelZb.QD053 = string.IsNullOrEmpty( table.Rows[i]["QD053"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD053"].ToString( ) );
                        modelZb.QD054 = string.IsNullOrEmpty( table.Rows[i]["QD054"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD054"].ToString( ) );
                        modelZb.QD055 = string.IsNullOrEmpty( table.Rows[i]["QD055"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD055"].ToString( ) );
                        modelZb.QD056 = string.IsNullOrEmpty( table.Rows[i]["QD056"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD056"].ToString( ) );
                        modelZb.QD057 = string.IsNullOrEmpty( table.Rows[i]["QD057"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD057"].ToString( ) );
                        modelZb.QD058 = string.IsNullOrEmpty( table.Rows[i]["QD058"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD058"].ToString( ) );
                        modelZb.QD059 = string.IsNullOrEmpty( table.Rows[i]["QD059"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD059"].ToString( ) );
                        modelZb.QD060 = string.IsNullOrEmpty( table.Rows[i]["QD060"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD060"].ToString( ) );
                        modelZb.QD061 = string.IsNullOrEmpty( table.Rows[i]["QD061"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD061"].ToString( ) );
                        modelZb.QD062 = string.IsNullOrEmpty( table.Rows[i]["QD062"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD062"].ToString( ) );
                        modelZb.QD063 = string.IsNullOrEmpty( table.Rows[i]["QD063"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD063"].ToString( ) );
                        modelZb.QD064 = string.IsNullOrEmpty( table.Rows[i]["QD064"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD064"].ToString( ) );
                        modelZb.QD065 = string.IsNullOrEmpty( table.Rows[i]["QD065"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD065"].ToString( ) );
                        modelZb.QD066 = string.IsNullOrEmpty( table.Rows[i]["QD066"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD066"].ToString( ) );
                        modelZb.QD067 = string.IsNullOrEmpty( table.Rows[i]["QD067"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD067"].ToString( ) );
                        modelZb.QD068 = string.IsNullOrEmpty( table.Rows[i]["QD068"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD068"].ToString( ) );
                        modelZb.QD069 = string.IsNullOrEmpty( table.Rows[i]["QD069"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD069"].ToString( ) );
                        modelZb.QD070 = string.IsNullOrEmpty( table.Rows[i]["QD069"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD069"].ToString( ) );
                        modelZb.QD071 = string.IsNullOrEmpty( table.Rows[i]["QD069"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD069"].ToString( ) );
                        modelZb.QD072 = string.IsNullOrEmpty( table.Rows[i]["QD069"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD069"].ToString( ) );
                        modelZb.QD073 = string.IsNullOrEmpty( table.Rows[i]["QD069"].ToString( ) ) == true ? 0M : Convert.ToDecimal( table.Rows[i]["QD069"].ToString( ) );
                        modelZb.QD095 = table.Rows[i]["QD095"].ToString( );
                        modelZb.QD096 = table.Rows[i]["QD096"].ToString( );
                        modelZb.QD097 = string.IsNullOrEmpty( table.Rows[i]["QD097"].ToString( ) ) == true ? 0 : Convert.ToInt32( table.Rows[i]["QD097"].ToString( ) );
                        modelZb.QD098 = string.IsNullOrEmpty( table.Rows[i]["QD098"].ToString( ) ) == true ? 0 : Convert.ToDecimal( table.Rows[i]["QD098"].ToString( ) );
                        modelZb.QD102 = string.IsNullOrEmpty( table.Rows[i]["QD102"].ToString( ) ) == true ? 0 : Convert.ToDecimal( table.Rows[i]["QD102"].ToString( ) );
                        modelZb.QD103 = string.IsNullOrEmpty( table.Rows[i]["QD103"].ToString( ) ) == true ? 0 : Convert.ToDecimal( table.Rows[i]["QD103"].ToString( ) );
                        if ( string.IsNullOrEmpty( table.Rows[i]["QD099"].ToString( ) ) )
                            modelZb.QD099 = null;
                        else
                            modelZb.QD099 = Convert.ToDateTime( table.Rows[i]["QD099"].ToString( ) );
                        if ( string.IsNullOrEmpty( table.Rows[i]["QD100"].ToString( ) ) )
                            modelZb.QD100 = null;
                        else
                            modelZb.QD100 = Convert.ToDateTime( table.Rows[i]["QD100"].ToString( ) );
                        if ( string.IsNullOrEmpty( table.Rows[i]["QD101"].ToString( ) ) )
                            modelZb.QD101 = null;
                        else
                            modelZb.QD101 = Convert.ToDateTime( table.Rows[i]["QD101"].ToString( ) );
                        if ( string.IsNullOrEmpty( table.Rows[i]["QD104"].ToString( ) ) )
                            modelZb.QD104 = null;
                        else
                            modelZb.QD104 = Convert.ToDateTime( table.Rows[i]["QD104"].ToString( ) );
                        if ( Exists( modelZb ) )
                            SQLString.Add( Update( modelZb ) );
                        else
                            SQLString.Add( Add( modelZb ) );
                    }
                    result = SqlHelper.ExecuteSqlTran( SQLString );
                }
            }

            return result;
        }

        public bool Exists ( MulaolaoLibrary.ZuZhangGongZiKaoHeZbLibrary modelZb )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQZB" );
            strSql.Append( " WHERE QD077=@QD077 AND QD078=@QD078 AND QD079=@QD079 AND QD094=@QD094 AND QD021=@QD021" );
            SqlParameter[] parameter = {
                new SqlParameter("@QD077",SqlDbType.NVarChar),
                new SqlParameter("@QD078",SqlDbType.NVarChar),
                new SqlParameter("@QD079",SqlDbType.NVarChar),
                new SqlParameter("@QD094",SqlDbType.NVarChar),
                new SqlParameter("@QD021",SqlDbType.NVarChar)
            };
            parameter[0].Value = modelZb.QD077;
            parameter[1].Value = modelZb.QD078;
            parameter[2].Value = modelZb.QD079;
            parameter[3].Value = modelZb.QD094;
            parameter[4].Value = modelZb.QD021;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }
        public string Update ( MulaolaoLibrary.ZuZhangGongZiKaoHeZbLibrary modelZb )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQZB SET " );
            strSql.AppendFormat( "QD021='{0}'," ,modelZb.QD021 );
            strSql.AppendFormat( "QD022='{0}'," ,modelZb.QD022 );
            strSql.AppendFormat( "QD023='{0}'," ,modelZb.QD023 );
            strSql.AppendFormat( "QD024='{0}'," ,modelZb.QD024 );
            strSql.AppendFormat( "QD025='{0}'," ,modelZb.QD025 );
            strSql.AppendFormat( "QD026='{0}'," ,modelZb.QD026 );
            strSql.AppendFormat( "QD027='{0}'," ,modelZb.QD027 );
            strSql.AppendFormat( "QD028='{0}'," ,modelZb.QD028 );
            strSql.AppendFormat( "QD029='{0}'," ,modelZb.QD029 );
            strSql.AppendFormat( "QD030='{0}'," ,modelZb.QD030 );
            strSql.AppendFormat( "QD031='{0}'," ,modelZb.QD031 );
            strSql.AppendFormat( "QD032='{0}'," ,modelZb.QD032 );
            strSql.AppendFormat( "QD033='{0}'," ,modelZb.QD033 );
            strSql.AppendFormat( "QD034='{0}'," ,modelZb.QD034 );
            strSql.AppendFormat( "QD035='{0}'," ,modelZb.QD035 );
            strSql.AppendFormat( "QD036='{0}'," ,modelZb.QD036 );
            strSql.AppendFormat( "QD037='{0}'," ,modelZb.QD037 );
            strSql.AppendFormat( "QD038='{0}'," ,modelZb.QD038 );
            strSql.AppendFormat( "QD039='{0}'," ,modelZb.QD039 );
            strSql.AppendFormat( "QD040='{0}'," ,modelZb.QD040 );
            strSql.AppendFormat( "QD041='{0}'," ,modelZb.QD041 );
            strSql.AppendFormat( "QD042='{0}'," ,modelZb.QD042 );
            strSql.AppendFormat( "QD043='{0}'," ,modelZb.QD043 );
            strSql.AppendFormat( "QD044='{0}'," ,modelZb.QD044 );
            strSql.AppendFormat( "QD045='{0}'," ,modelZb.QD045 );
            strSql.AppendFormat( "QD046='{0}'," ,modelZb.QD046 );
            strSql.AppendFormat( "QD047='{0}'," ,modelZb.QD047 );
            strSql.AppendFormat( "QD048='{0}'," ,modelZb.QD048 );
            strSql.AppendFormat( "QD049='{0}'," ,modelZb.QD049 );
            strSql.AppendFormat( "QD050='{0}'," ,modelZb.QD050 );
            strSql.AppendFormat( "QD051='{0}'," ,modelZb.QD051 );
            strSql.AppendFormat( "QD052='{0}'," ,modelZb.QD052 );
            strSql.AppendFormat( "QD053='{0}'," ,modelZb.QD053 );
            strSql.AppendFormat( "QD054='{0}'," ,modelZb.QD054 );
            strSql.AppendFormat( "QD055='{0}'," ,modelZb.QD055 );
            strSql.AppendFormat( "QD056='{0}'," ,modelZb.QD056 );
            strSql.AppendFormat( "QD057='{0}'," ,modelZb.QD057 );
            strSql.AppendFormat( "QD058='{0}'," ,modelZb.QD058 );
            strSql.AppendFormat( "QD059='{0}'," ,modelZb.QD059 );
            strSql.AppendFormat( "QD060='{0}'," ,modelZb.QD060 );
            strSql.AppendFormat( "QD061='{0}'," ,modelZb.QD061 );
            strSql.AppendFormat( "QD062='{0}'," ,modelZb.QD062 );
            strSql.AppendFormat( "QD063='{0}'," ,modelZb.QD063 );
            strSql.AppendFormat( "QD064='{0}'," ,modelZb.QD064 );
            strSql.AppendFormat( "QD065='{0}'," ,modelZb.QD065 );
            strSql.AppendFormat( "QD066='{0}'," ,modelZb.QD066 );
            strSql.AppendFormat( "QD067='{0}'," ,modelZb.QD067 );
            strSql.AppendFormat( "QD068='{0}'," ,modelZb.QD068 );
            strSql.AppendFormat( "QD069='{0}'," ,modelZb.QD069 );
            strSql.AppendFormat( "QD070='{0}'," ,modelZb.QD070 );
            strSql.AppendFormat( "QD071='{0}'," ,modelZb.QD071 );
            strSql.AppendFormat( "QD072='{0}'," ,modelZb.QD072 );
            strSql.AppendFormat( "QD073='{0}'," ,modelZb.QD073 );
            strSql.AppendFormat( "QD095='{0}'," ,modelZb.QD095 );
            strSql.AppendFormat( "QD096='{0}'," ,modelZb.QD096 );
            strSql.AppendFormat( "QD097='{0}'," ,modelZb.QD097 );
            strSql.AppendFormat( "QD098='{0}'," ,modelZb.QD098 );
            strSql.AppendFormat( "QD102='{0}'," ,modelZb.QD102 );
            strSql.AppendFormat( "QD103='{0}'," ,modelZb.QD103 );
            if ( modelZb.QD099 == null )
                strSql.Append( "QD099=NULL," );
            else
                strSql.AppendFormat( "QD099='{0}'," ,modelZb.QD099 );
            if ( modelZb.QD100 == null )
                strSql.Append( "QD100=NULL," );
            else
                strSql.AppendFormat( "QD100='{0}'," ,modelZb.QD100 );
            if ( modelZb.QD101 == null )
                strSql.Append( "QD101=NULL," );
            else
                strSql.AppendFormat( "QD101='{0}'," ,modelZb.QD101 );
            if ( modelZb.QD104 == null )
                strSql.Append( "QD104=NULL" );
            else
                strSql.AppendFormat( "QD104='{0}'" ,modelZb.QD104 );
            strSql.AppendFormat( " WHERE QD077='{0}' AND QD078='{1}' AND QD079='{2}' AND QD094='{3}' AND QD021='{4}'" ,modelZb.QD077 ,modelZb.QD078 ,modelZb.QD079 ,modelZb.QD094 ,modelZb.QD021 );

            return strSql.ToString( );
        }
        public string Add ( MulaolaoLibrary.ZuZhangGongZiKaoHeZbLibrary modelZb )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQZB (" );
            strSql.Append( "QD021,QD022,QD023,QD024,QD025,QD026,QD027,QD028,QD029,QD030,QD031,QD032,QD033,QD034,QD035,QD036,QD037,QD038,QD039,QD040,QD041,QD042,QD043,QD044,QD045,QD046,QD047,QD048,QD049,QD050,QD051,QD052,QD053,QD054,QD055,QD056,QD057,QD058,QD059,QD060,QD061,QD062,QD063,QD064,QD065,QD066,QD067,QD068,QD069,QD070,QD071,QD072,QD073,QD077,QD078,QD079,QD094,QD095,QD096,QD097,QD098,QD102,QD103)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}','{38}','{39}','{40}','{41}','{42}','{43}','{44}','{45}','{46}','{47}','{48}','{49}','{50}','{51}','{52}','{53}','{54}','{55}','{56}','{57}','{58}','{59}','{60}','{61}','{62}');" ,modelZb.QD021 ,modelZb.QD022 ,modelZb.QD023 ,modelZb.QD024 ,modelZb.QD025 ,modelZb.QD026 ,modelZb.QD027 ,modelZb.QD028 ,modelZb.QD029 ,modelZb.QD030 ,modelZb.QD031 ,modelZb.QD032 ,modelZb.QD033 ,modelZb.QD034 ,modelZb.QD035 ,modelZb.QD036 ,modelZb.QD037 ,modelZb.QD038 ,modelZb.QD039 ,modelZb.QD040 ,modelZb.QD041 ,modelZb.QD042 ,modelZb.QD043 ,modelZb.QD044 ,modelZb.QD045 ,modelZb.QD046 ,modelZb.QD047 ,modelZb.QD048 ,modelZb.QD049 ,modelZb.QD050 ,modelZb.QD051 ,modelZb.QD052 ,modelZb.QD053 ,modelZb.QD054 ,modelZb.QD055 ,modelZb.QD056 ,modelZb.QD057 ,modelZb.QD058 ,modelZb.QD059 ,modelZb.QD060 ,modelZb.QD061 ,modelZb.QD062 ,modelZb.QD063 ,modelZb.QD064 ,modelZb.QD065 ,modelZb.QD066 ,modelZb.QD067 ,modelZb.QD068 ,modelZb.QD069 ,modelZb.QD070 ,modelZb.QD071 ,modelZb.QD072 ,modelZb.QD073 ,modelZb.QD077 ,modelZb.QD078 ,modelZb.QD079 ,modelZb.QD094 ,modelZb.QD095 ,modelZb.QD096 ,modelZb.QD097 ,modelZb.QD098 ,modelZb.QD102 ,modelZb.QD103 );
            strSql.Append( "UPDATE R_PQZB SET" );
            if ( modelZb.QD099 == null )
                strSql.Append( " QD099=NULL," );
            else
                strSql.AppendFormat( " QD099='{0}'," ,modelZb.QD099 );
            if ( modelZb.QD100 == null )
                strSql.Append( "QD100=NULL," );
            else
                strSql.AppendFormat( "QD100='{0}'," ,modelZb.QD100 );
            if ( modelZb.QD101 == null )
                strSql.Append( "QD101=NULL," );
            else
                strSql.AppendFormat( "QD101='{0}'," ,modelZb.QD101 );
            if ( modelZb.QD104 == null )
                strSql.Append( "QD104=NULL" );
            else
                strSql.AppendFormat( "QD104='{0}'" ,modelZb.QD104 );
            strSql.AppendFormat( " WHERE QD077='{0}' AND QD078='{1}' AND QD079='{2}' AND QD094='{3}' AND QD021='{4}'" ,modelZb.QD077 ,modelZb.QD078 ,modelZb.QD079 ,modelZb.QD094 ,modelZb.QD021 );

            return strSql.ToString( );
        }

        bool tableTheSame ( DataTable dtOne ,DataTable dtTwo )
        {
            if ( dtOne == null || dtTwo == null )
                return false;
            if ( dtOne.Rows.Count != dtTwo.Rows.Count )
                return false;
            if ( dtOne.Columns.Count != dtTwo.Columns.Count )
                return false;
            for ( int i = 0 ; i < dtOne.Rows.Count ; i++ )
            {
                for ( int j = 0 ; j < dtOne.Columns.Count ; j++ )
                {
                    if ( dtOne.Rows[i][j].ToString( ) != dtTwo.Rows[i][j].ToString( ) )
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public DataTable GetDataTable (string oddNum,string name,string yearM,string monthD )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQZB" );
            strSql.Append( " WHERE QD077=@QD077 AND QD078=@QD078 AND QD079=@QD079 AND QD094=@QD094"  );
            SqlParameter[] parameter = {
                new SqlParameter("@QD077",SqlDbType.NVarChar),
                new SqlParameter("@QD078",SqlDbType.NVarChar),
                new SqlParameter("@QD079",SqlDbType.NVarChar),
                new SqlParameter("@QD094",SqlDbType.NVarChar)
            };
            parameter[0].Value = oddNum;
            parameter[1].Value = name;
            parameter[2].Value = yearM;
            parameter[3].Value = monthD;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsIdxZb ( MulaolaoLibrary.ZuZhangGongZiKaoHeZbLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQZB" );
            strSql.Append( " WHERE QD077=@QD077 AND QD079=@QD079 AND QD094=@QD094" );
            SqlParameter[] parameter = {
                new SqlParameter("@QD077",SqlDbType.NVarChar),
                new SqlParameter("@QD079",SqlDbType.NVarChar),
                new SqlParameter("@QD094",SqlDbType.NVarChar)
            };

            parameter[0].Value = model.QD077;
            parameter[1].Value = model.QD079;
            parameter[2].Value = model.QD094;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add ( MulaolaoLibrary.ZuZhangGongZiKaoHeZaLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQZA (" );
            strSql.Append( "QD001,QD002,QD003,QD004,QD005,QD007,QD008,QD009,QD011,QD012,QD014,QD015,QD017,QD018,QD019,QD074)" );
            strSql.Append( " VALUES (" );
            strSql.Append( "@QD001,@QD002,@QD003,@QD004,@QD005,@QD007,@QD008,@QD009,@QD011,@QD012,@QD014,@QD015,@QD017,@QD018,@QD019,@QD074);" );
            strSql.Append( "SELECT SCOPE_IDENTITY();" );
            
            SqlParameter[] parameter = {
                new SqlParameter("@QD001",SqlDbType.NVarChar),
                new SqlParameter("@QD002",SqlDbType.VarChar),
                new SqlParameter("@QD003",SqlDbType.NVarChar),
                new SqlParameter("@QD004",SqlDbType.Decimal),
                new SqlParameter("@QD005",SqlDbType.Decimal),
                new SqlParameter("@QD007",SqlDbType.Decimal),
                new SqlParameter("@QD008",SqlDbType.Decimal),
                new SqlParameter("@QD009",SqlDbType.Decimal),
                new SqlParameter("@QD011",SqlDbType.BigInt),
                new SqlParameter("@QD012",SqlDbType.Decimal),
                new SqlParameter("@QD014",SqlDbType.Decimal),
                new SqlParameter("@QD015",SqlDbType.Decimal),
                new SqlParameter("@QD017",SqlDbType.Decimal),
                new SqlParameter("@QD018",SqlDbType.Decimal),
                new SqlParameter("@QD019",SqlDbType.Decimal),
                new SqlParameter("@QD074",SqlDbType.NVarChar)
            };

            parameter[0].Value = model.QD001;
            parameter[1].Value = model.QD002;
            parameter[2].Value = model.QD003;
            parameter[3].Value = model.QD004;
            parameter[4].Value = model.QD005;
            parameter[5].Value = model.QD007;
            parameter[6].Value = model.QD008;
            parameter[7].Value = model.QD009;
            parameter[8].Value = model.QD011;
            parameter[9].Value = model.QD012;
            parameter[10].Value = model.QD014;
            parameter[11].Value = model.QD015;
            parameter[12].Value = model.QD017;
            parameter[13].Value = model.QD018;
            parameter[14].Value = model.QD019;
            parameter[15].Value = model.QD074;

            int idx = SqlHelper.ExecuteSqlReturnId( strSql.ToString( ) ,parameter );
            return idx;
        }

        /// <summary>
        /// 复制数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public bool Copy ( MulaolaoLibrary . ZuZhangGongZiKaoHeZaLibrary model,string dateTime )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQZA (" );
            strSql . Append ( "QD001,QD002,QD003,QD004,QD005,QD007,QD008,QD009,QD011,QD012,QD014,QD015,QD017,QD018,QD019,QD074)" );
            strSql . Append ( " VALUES (" );
            strSql . Append ( "@QD001,@QD002,@QD003,@QD004,@QD005,@QD007,@QD008,@QD009,@QD011,@QD012,@QD014,@QD015,@QD017,@QD018,@QD019,@QD074);" );
            //strSql . Append ( "SELECT SCOPE_IDENTITY();" );

            SqlParameter [ ] parameter = {
                new SqlParameter("@QD001",SqlDbType.NVarChar),
                new SqlParameter("@QD002",SqlDbType.VarChar),
                new SqlParameter("@QD003",SqlDbType.NVarChar),
                new SqlParameter("@QD004",SqlDbType.Decimal),
                new SqlParameter("@QD005",SqlDbType.Decimal),
                new SqlParameter("@QD007",SqlDbType.Decimal),
                new SqlParameter("@QD008",SqlDbType.Decimal),
                new SqlParameter("@QD009",SqlDbType.Decimal),
                new SqlParameter("@QD011",SqlDbType.BigInt),
                new SqlParameter("@QD012",SqlDbType.Decimal),
                new SqlParameter("@QD014",SqlDbType.Decimal),
                new SqlParameter("@QD015",SqlDbType.Decimal),
                new SqlParameter("@QD017",SqlDbType.Decimal),
                new SqlParameter("@QD018",SqlDbType.Decimal),
                new SqlParameter("@QD019",SqlDbType.Decimal),
                new SqlParameter("@QD074",SqlDbType.NVarChar)
            };

            parameter [ 0 ] . Value = model . QD001;
            parameter [ 1 ] . Value = model . QD002;
            parameter [ 2 ] . Value = model . QD003;
            parameter [ 3 ] . Value = model . QD004;
            parameter [ 4 ] . Value = model . QD005;
            parameter [ 5 ] . Value = model . QD007;
            parameter [ 6 ] . Value = model . QD008;
            parameter [ 7 ] . Value = model . QD009;
            parameter [ 8 ] . Value = model . QD011;
            parameter [ 9 ] . Value = model . QD012;
            parameter [ 10 ] . Value = model . QD014;
            parameter [ 11 ] . Value = model . QD015;
            parameter [ 12 ] . Value = model . QD017;
            parameter [ 13 ] . Value = model . QD018;
            parameter [ 14 ] . Value = model . QD019;
            parameter [ 15 ] . Value = model . QD074;
            SQLString . Add ( strSql ,parameter );
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "INSERT INTO R_PQZB  (QD077,QD078,QD079,QD094,QD021,QD095,QD096,QD099,QD100,QD101,QD104,QD102,QD103,QD098,QD022,QD023,QD024,QD025,QD026,QD027,QD028,QD029,QD030,QD031,QD032,QD033,QD034,QD035,QD036,QD037,QD038,QD039,QD040,QD041,QD042,QD043,QD044,QD045,QD046,QD047,QD048,QD049,QD050,QD051,QD052,QD053,QD054,QD055,QD056,QD057,QD058,QD059,QD060,QD061,QD062,QD063,QD064,QD065,QD066,QD067,QD068,QD069,QD070,QD071,QD072,QD073,QD097,QD105,QD106,QD107) SELECT QD077,QD078,QD079,'{2}' QD094,QD021,QD095,QD096,QD099,QD100,QD101,QD104,QD102,QD103,QD098,QD022,QD023,QD024,QD025,QD026,QD027,QD028,QD029,QD030,QD031,QD032,QD033,QD034,QD035,QD036,QD037,QD038,QD039,QD040,QD041,QD042,QD043,QD044,QD045,QD046,QD047,QD048,QD049,QD050,QD051,QD052,QD053,QD054,QD055,QD056,QD057,QD058,QD059,QD060,QD061,QD062,QD063,QD064,QD065,QD066,QD067,QD068,QD069,QD070,QD071,QD072,QD073,QD097,QD105,QD106,QD107 FROM R_PQZB WHERE QD077='{0}' AND QD094='{1}'" ,model . QD074 ,dateTime ,model . QD003 );
            SQLString . Add ( strSql ,null );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 增加一条记录  表2
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddZb ( MulaolaoLibrary.ZuZhangGongZiKaoHeZbLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQZB (" );
            strSql.Append( "QD021,QD022,QD023,QD024,QD025,QD026,QD027,QD028,QD029,QD030,QD031,QD032,QD033,QD034,QD035,QD036,QD037,QD038,QD039,QD040,QD041,QD042,QD043,QD044,QD045,QD046,QD047,QD048,QD049,QD050,QD051,QD052,QD053,QD054,QD055,QD056,QD057,QD058,QD059,QD060,QD061,QD062,QD063,QD064,QD065,QD066,QD067,QD068,QD069,QD070,QD071,QD072,QD073,QD077,QD078,QD079,QD094,QD095,QD096,QD098,QD102,QD103)" );
            strSql.Append( " VALUES (" );
            strSql.Append( "@QD021,@QD022,@QD023,@QD024,@QD025,@QD026,@QD027,@QD028,@QD029,@QD030,@QD031,@QD032,@QD033,@QD034,@QD035,@QD036,@QD037,@QD038,@QD039,@QD040,@QD041,@QD042,@QD043,@QD044,@QD045,@QD046,@QD047,@QD048,@QD049,@QD050,@QD051,@QD052,@QD053,@QD054,@QD055,@QD056,@QD057,@QD058,@QD059,@QD060,@QD061,@QD062,@QD063,@QD064,@QD065,@QD066,@QD067,@QD068,@QD069,@QD070,@QD071,@QD072,@QD073,@QD077,@QD078,@QD079,@QD094,@QD095,@QD096,@QD098,@QD102,@QD103);" );
            strSql.Append( "SELECT SCOPE_IDENTITY();" );
            SqlParameter[] parameter = {
                new SqlParameter("@QD021",SqlDbType.NVarChar),
                new SqlParameter("@QD022",SqlDbType.Decimal),
                new SqlParameter("@QD023",SqlDbType.Int),
                new SqlParameter("@QD024",SqlDbType.Decimal),
                new SqlParameter("@QD025",SqlDbType.Int),
                new SqlParameter("@QD026",SqlDbType.Decimal),
                new SqlParameter("@QD027",SqlDbType.Int),
                new SqlParameter("@QD028",SqlDbType.Decimal),
                new SqlParameter("@QD029",SqlDbType.Int),
                new SqlParameter("@QD030",SqlDbType.Decimal),
                new SqlParameter("@QD031",SqlDbType.Int),
                new SqlParameter("@QD032",SqlDbType.Decimal),
                new SqlParameter("@QD033",SqlDbType.Int),
                new SqlParameter("@QD034",SqlDbType.Decimal),
                new SqlParameter("@QD035",SqlDbType.Int),
                new SqlParameter("@QD036",SqlDbType.Decimal),
                new SqlParameter("@QD037",SqlDbType.Int),
                new SqlParameter("@QD038",SqlDbType.Decimal),
                new SqlParameter("@QD039",SqlDbType.Int),
                new SqlParameter("@QD040",SqlDbType.Decimal),
                new SqlParameter("@QD041",SqlDbType.Int),
                new SqlParameter("@QD042",SqlDbType.Decimal),
                new SqlParameter("@QD043",SqlDbType.Int),
                new SqlParameter("@QD044",SqlDbType.Decimal),
                new SqlParameter("@QD045",SqlDbType.Int),
                new SqlParameter("@QD046",SqlDbType.Decimal),
                new SqlParameter("@QD047",SqlDbType.Int),
                new SqlParameter("@QD048",SqlDbType.Decimal),
                new SqlParameter("@QD049",SqlDbType.Int),
                new SqlParameter("@QD050",SqlDbType.Decimal),
                new SqlParameter("@QD051",SqlDbType.Int),
                new SqlParameter("@QD052",SqlDbType.Decimal),
                new SqlParameter("@QD053",SqlDbType.Int),
                new SqlParameter("@QD054",SqlDbType.Decimal),
                new SqlParameter("@QD055",SqlDbType.Int),
                new SqlParameter("@QD056",SqlDbType.Decimal),
                new SqlParameter("@QD057",SqlDbType.Int),
                new SqlParameter("@QD058",SqlDbType.Decimal),
                new SqlParameter("@QD059",SqlDbType.Int),
                new SqlParameter("@QD060",SqlDbType.Decimal),
                new SqlParameter("@QD061",SqlDbType.Int),
                new SqlParameter("@QD062",SqlDbType.Decimal),
                new SqlParameter("@QD063",SqlDbType.Int),
                new SqlParameter("@QD064",SqlDbType.Decimal),
                new SqlParameter("@QD065",SqlDbType.Int),
                new SqlParameter("@QD066",SqlDbType.Decimal),
                new SqlParameter("@QD067",SqlDbType.Int),
                new SqlParameter("@QD068",SqlDbType.Decimal),
                new SqlParameter("@QD069",SqlDbType.Int),
                new SqlParameter("@QD070",SqlDbType.Decimal),
                new SqlParameter("@QD071",SqlDbType.Int),
                new SqlParameter("@QD072",SqlDbType.Decimal),
                new SqlParameter("@QD073",SqlDbType.Int),
                new SqlParameter("@QD077",SqlDbType.NVarChar),
                new SqlParameter("@QD078",SqlDbType.NVarChar),
                new SqlParameter("@QD079",SqlDbType.VarChar),
                new SqlParameter("@QD094",SqlDbType.NVarChar),
                new SqlParameter("@QD095",SqlDbType.NVarChar),
                new SqlParameter("@QD096",SqlDbType.NVarChar),
                new SqlParameter("@QD098",SqlDbType.Decimal),
                new SqlParameter("@QD102",SqlDbType.Decimal),
                new SqlParameter("@QD103",SqlDbType.Decimal)
            };

            parameter[0].Value = model.QD021;
            parameter[1].Value = model.QD022;
            parameter[2].Value = model.QD023;
            parameter[3].Value = model.QD024;
            parameter[4].Value = model.QD025;
            parameter[5].Value = model.QD026;
            parameter[6].Value = model.QD027;
            parameter[7].Value = model.QD028;
            parameter[8].Value = model.QD029;
            parameter[9].Value = model.QD030;
            parameter[10].Value = model.QD031;
            parameter[11].Value = model.QD032;
            parameter[12].Value = model.QD033;
            parameter[13].Value = model.QD034;
            parameter[14].Value = model.QD035;
            parameter[15].Value = model.QD036;
            parameter[16].Value = model.QD037;
            parameter[17].Value = model.QD038;
            parameter[18].Value = model.QD039;
            parameter[19].Value = model.QD040;
            parameter[20].Value = model.QD041;
            parameter[21].Value = model.QD042;
            parameter[22].Value = model.QD043;
            parameter[23].Value = model.QD044;
            parameter[24].Value = model.QD045;
            parameter[25].Value = model.QD046;
            parameter[26].Value = model.QD047;
            parameter[27].Value = model.QD048;
            parameter[28].Value = model.QD049;
            parameter[29].Value = model.QD050;
            parameter[30].Value = model.QD051;
            parameter[31].Value = model.QD052;
            parameter[32].Value = model.QD053;
            parameter[33].Value = model.QD054;
            parameter[34].Value = model.QD055;
            parameter[35].Value = model.QD056;
            parameter[36].Value = model.QD057;
            parameter[37].Value = model.QD058;
            parameter[38].Value = model.QD059;
            parameter[39].Value = model.QD060;
            parameter[40].Value = model.QD061;
            parameter[41].Value = model.QD062;
            parameter[42].Value = model.QD063;
            parameter[43].Value = model.QD064;
            parameter[44].Value = model.QD065;
            parameter[45].Value = model.QD066;
            parameter[46].Value = model.QD067;
            parameter[47].Value = model.QD068;
            parameter[48].Value = model.QD069;
            parameter[49].Value = model.QD070;
            parameter[50].Value = model.QD071;
            parameter[51].Value = model.QD072;
            parameter[52].Value = model.QD073;
            parameter[53].Value = model.QD077;
            parameter[54].Value = model.QD078;
            parameter[55].Value = model.QD079;
            parameter[56].Value = model.QD094;
            parameter[57].Value = model.QD095;
            parameter[58].Value = model.QD096;
            parameter[59].Value = model.QD098;
            parameter[60].Value = model.QD102;
            parameter[61].Value = model.QD103;

            int idx = SqlHelper.ExecuteSqlReturnId( strSql.ToString( ) ,parameter );
           
            if ( idx > 0 )
            {
                model.Idx = idx;
                ArrayList SQLString = new ArrayList( );
                StringBuilder strSqls = new StringBuilder( );
                if ( model.QD099 == null )
                    strSqls.AppendFormat( "UPDATE R_PQZB SET QD099=NULL WHERE idx='{0}'" ,model.Idx );
                else
                    strSqls.AppendFormat( "UPDATE R_PQZB SET QD099='{0}' WHERE idx='{1}'" ,model.QD099 ,model.Idx );
                SQLString.Add( strSqls.ToString( ) );
                StringBuilder strSq = new StringBuilder( );
                if ( model.QD100 == null )
                    strSq.AppendFormat( "UPDATE R_PQZB SET QD100=NULL WHERE idx='{0}'" ,model.Idx );
                else
                    strSq.AppendFormat( "UPDATE R_PQZB SET QD100='{0}' WHERE idx='{1}'" ,model.QD100 ,model.Idx );
                SQLString.Add( strSq.ToString( ) );
                StringBuilder strS = new StringBuilder( );
                if ( model.QD101 == null )
                    strS.AppendFormat( "UPDATE R_PQZB SET QD101=NULL WHERE idx='{0}'" ,model.Idx );
                else
                    strS.AppendFormat( "UPDATE R_PQZB SET QD101='{0}' WHERE idx='{1}'" ,model.QD101 ,model.Idx );
                SQLString.Add( strS.ToString( ) );
                StringBuilder str = new StringBuilder( );
                if ( model.QD104 == null )
                    str.AppendFormat( "UPDATE R_PQZB QD104=NULL WHERE idx='{0}'" ,model.Idx );
                else
                    str.AppendFormat( "UPDATE R_PQZB QD104='{0}' WHERE idx='{1}'" ,model.QD104 ,model.Idx );
                SQLString.Add( str.ToString( ) );

                return SqlHelper.ExecuteSqlTran( SQLString );
            }
            else
                return false;
        }


        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.ZuZhangGongZiKaoHeZaLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQZA SET " );
            strSql.Append( "QD001=@QD001," );
            strSql.Append( "QD002=@QD002," );
            strSql.Append( "QD003=@QD003," );
            strSql.Append( "QD004=@QD004," );
            strSql.Append( "QD005=@QD005," );
            strSql.Append( "QD007=@QD007," );
            strSql.Append( "QD008=@QD008," );
            strSql.Append( "QD009=@QD009," );
            strSql.Append( "QD011=@QD011," );
            strSql.Append( "QD012=@QD012," );
            strSql.Append( "QD014=@QD014," );
            strSql.Append( "QD015=@QD015," );
            strSql.Append( "QD017=@QD017," );
            strSql.Append( "QD018=@QD018," );
            strSql.Append( "QD019=@QD019," );
            strSql.Append( "QD074=@QD074" );
            strSql.Append( " WHERE idx=@idx" );

            SqlParameter[] parameter = {
                new SqlParameter("@QD001",SqlDbType.NVarChar),
                new SqlParameter("@QD002",SqlDbType.VarChar),
                new SqlParameter("@QD003",SqlDbType.NVarChar),
                new SqlParameter("@QD004",SqlDbType.Decimal),
                new SqlParameter("@QD005",SqlDbType.Decimal),
                new SqlParameter("@QD007",SqlDbType.Decimal),
                new SqlParameter("@QD008",SqlDbType.Decimal),
                new SqlParameter("@QD009",SqlDbType.Decimal),
                new SqlParameter("@QD011",SqlDbType.BigInt),
                new SqlParameter("@QD012",SqlDbType.Decimal),
                new SqlParameter("@QD014",SqlDbType.Decimal),
                new SqlParameter("@QD015",SqlDbType.Decimal),
                new SqlParameter("@QD017",SqlDbType.Decimal),
                new SqlParameter("@QD018",SqlDbType.Decimal),
                new SqlParameter("@QD019",SqlDbType.Decimal),
                new SqlParameter("@QD074",SqlDbType.NVarChar),
                new SqlParameter("@idx",SqlDbType.Int)
            };

            parameter[0].Value = model.QD001;
            parameter[1].Value = model.QD002;
            parameter[2].Value = model.QD003;
            parameter[3].Value = model.QD004;
            parameter[4].Value = model.QD005;
            parameter[5].Value = model.QD007;
            parameter[6].Value = model.QD008;
            parameter[7].Value = model.QD009;
            parameter[8].Value = model.QD011;
            parameter[9].Value = model.QD012;
            parameter[10].Value = model.QD014;
            parameter[11].Value = model.QD015;
            parameter[12].Value = model.QD017;
            parameter[13].Value = model.QD018;
            parameter[14].Value = model.QD019;
            parameter[15].Value = model.QD074;
            parameter[16].Value = model.Idx;

            int rows = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 更新一条记录  表二
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateZb ( MulaolaoLibrary.ZuZhangGongZiKaoHeZbLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQZB SET " );
            strSql.Append( "QD021=@QD021," );
            strSql.Append( "QD022=@QD022," );
            strSql.Append( "QD023=@QD023," );
            strSql.Append( "QD024=@QD024," );
            strSql.Append( "QD025=@QD025," );
            strSql.Append( "QD026=@QD026," );
            strSql.Append( "QD027=@QD027," );
            strSql.Append( "QD028=@QD028," );
            strSql.Append( "QD029=@QD029," );
            strSql.Append( "QD030=@QD030," );
            strSql.Append( "QD031=@QD031," );
            strSql.Append( "QD032=@QD032," );
            strSql.Append( "QD033=@QD033," );
            strSql.Append( "QD034=@QD034," );
            strSql.Append( "QD035=@QD035," );
            strSql.Append( "QD036=@QD036," );
            strSql.Append( "QD037=@QD037," );
            strSql.Append( "QD038=@QD038," );
            strSql.Append( "QD039=@QD039," );
            strSql.Append( "QD040=@QD040," );
            strSql.Append( "QD041=@QD041," );
            strSql.Append( "QD042=@QD042," );
            strSql.Append( "QD043=@QD043," );
            strSql.Append( "QD044=@QD044," );
            strSql.Append( "QD045=@QD045," );
            strSql.Append( "QD046=@QD046," );
            strSql.Append( "QD047=@QD047," );
            strSql.Append( "QD048=@QD048," );
            strSql.Append( "QD049=@QD049," );
            strSql.Append( "QD050=@QD050," );
            strSql.Append( "QD051=@QD051," );
            strSql.Append( "QD052=@QD052," );
            strSql.Append( "QD053=@QD053," );
            strSql.Append( "QD054=@QD054," );
            strSql.Append( "QD055=@QD055," );
            strSql.Append( "QD056=@QD056," );
            strSql.Append( "QD057=@QD057," );
            strSql.Append( "QD058=@QD058," );
            strSql.Append( "QD059=@QD059," );
            strSql.Append( "QD060=@QD060," );
            strSql.Append( "QD061=@QD061," );
            strSql.Append( "QD062=@QD062," );
            strSql.Append( "QD063=@QD063," );
            strSql.Append( "QD064=@QD064," );
            strSql.Append( "QD065=@QD065," );
            strSql.Append( "QD066=@QD066," );
            strSql.Append( "QD067=@QD067," );
            strSql.Append( "QD068=@QD068," );
            strSql.Append( "QD069=@QD069," );
            strSql.Append( "QD070=@QD070," );
            strSql.Append( "QD071=@QD071," );
            strSql.Append( "QD072=@QD072," );
            strSql.Append( "QD073=@QD073," );
            strSql.Append( "QD077=@QD077," );
            strSql.Append( "QD078=@QD078," );
            strSql.Append( "QD079=@QD079," );
            strSql.Append( "QD094=@QD094," );
            strSql.Append( "QD095=@QD095," );
            strSql.Append( "QD096=@QD096," );
            strSql.Append( "QD098=@QD098," );
            strSql.Append( "QD102=@QD102," );
            strSql.Append( "QD103=@QD103" );
            strSql.Append( " WHERE idx=@idx" );


            SqlParameter[] parameter = {
                new SqlParameter("@QD021",SqlDbType.NVarChar),
                new SqlParameter("@QD022",SqlDbType.Decimal),
                new SqlParameter("@QD023",SqlDbType.Int),
                new SqlParameter("@QD024",SqlDbType.Decimal),
                new SqlParameter("@QD025",SqlDbType.Int),
                new SqlParameter("@QD026",SqlDbType.Decimal),
                new SqlParameter("@QD027",SqlDbType.Int),
                new SqlParameter("@QD028",SqlDbType.Decimal),
                new SqlParameter("@QD029",SqlDbType.Int),
                new SqlParameter("@QD030",SqlDbType.Decimal),
                new SqlParameter("@QD031",SqlDbType.Int),
                new SqlParameter("@QD032",SqlDbType.Decimal),
                new SqlParameter("@QD033",SqlDbType.Int),
                new SqlParameter("@QD034",SqlDbType.Decimal),
                new SqlParameter("@QD035",SqlDbType.Int),
                new SqlParameter("@QD036",SqlDbType.Decimal),
                new SqlParameter("@QD037",SqlDbType.Int),
                new SqlParameter("@QD038",SqlDbType.Decimal),
                new SqlParameter("@QD039",SqlDbType.Int),
                new SqlParameter("@QD040",SqlDbType.Decimal),
                new SqlParameter("@QD041",SqlDbType.Int),
                new SqlParameter("@QD042",SqlDbType.Decimal),
                new SqlParameter("@QD043",SqlDbType.Int),
                new SqlParameter("@QD044",SqlDbType.Decimal),
                new SqlParameter("@QD045",SqlDbType.Int),
                new SqlParameter("@QD046",SqlDbType.Decimal),
                new SqlParameter("@QD047",SqlDbType.Int),
                new SqlParameter("@QD048",SqlDbType.Decimal),
                new SqlParameter("@QD049",SqlDbType.Int),
                new SqlParameter("@QD050",SqlDbType.Decimal),
                new SqlParameter("@QD051",SqlDbType.Int),
                new SqlParameter("@QD052",SqlDbType.Decimal),
                new SqlParameter("@QD053",SqlDbType.Int),
                new SqlParameter("@QD054",SqlDbType.Decimal),
                new SqlParameter("@QD055",SqlDbType.Int),
                new SqlParameter("@QD056",SqlDbType.Decimal),
                new SqlParameter("@QD057",SqlDbType.Int),
                new SqlParameter("@QD058",SqlDbType.Decimal),
                new SqlParameter("@QD059",SqlDbType.Int),
                new SqlParameter("@QD060",SqlDbType.Decimal),
                new SqlParameter("@QD061",SqlDbType.Int),
                new SqlParameter("@QD062",SqlDbType.Decimal),
                new SqlParameter("@QD063",SqlDbType.Int),
                new SqlParameter("@QD064",SqlDbType.Decimal),
                new SqlParameter("@QD065",SqlDbType.Int),
                new SqlParameter("@QD066",SqlDbType.Decimal),
                new SqlParameter("@QD067",SqlDbType.Int),
                new SqlParameter("@QD068",SqlDbType.Decimal),
                new SqlParameter("@QD069",SqlDbType.Int),
                new SqlParameter("@QD070",SqlDbType.Decimal),
                new SqlParameter("@QD071",SqlDbType.Int),
                new SqlParameter("@QD072",SqlDbType.Decimal),
                new SqlParameter("@QD073",SqlDbType.Int),
                new SqlParameter("@QD077",SqlDbType.NVarChar),
                new SqlParameter("@QD078",SqlDbType.NVarChar),
                new SqlParameter("@QD079",SqlDbType.VarChar),
                new SqlParameter("@QD094",SqlDbType.NVarChar),
                new SqlParameter("@QD095",SqlDbType.NVarChar),
                new SqlParameter("@QD096",SqlDbType.NVarChar),
                new SqlParameter("@QD098",SqlDbType.Decimal),
                new SqlParameter("@QD102",SqlDbType.Decimal),
                new SqlParameter("@QD103",SqlDbType.Decimal),
                new SqlParameter("@idx",SqlDbType.Int)
            };

            parameter[0].Value = model.QD021;
            parameter[1].Value = model.QD022;
            parameter[2].Value = model.QD023;
            parameter[3].Value = model.QD024;
            parameter[4].Value = model.QD025;
            parameter[5].Value = model.QD026;
            parameter[6].Value = model.QD027;
            parameter[7].Value = model.QD028;
            parameter[8].Value = model.QD029;
            parameter[9].Value = model.QD030;
            parameter[10].Value = model.QD031;
            parameter[11].Value = model.QD032;
            parameter[12].Value = model.QD033;
            parameter[13].Value = model.QD034;
            parameter[14].Value = model.QD035;
            parameter[15].Value = model.QD036;
            parameter[16].Value = model.QD037;
            parameter[17].Value = model.QD038;
            parameter[18].Value = model.QD039;
            parameter[19].Value = model.QD040;
            parameter[20].Value = model.QD041;
            parameter[21].Value = model.QD042;
            parameter[22].Value = model.QD043;
            parameter[23].Value = model.QD044;
            parameter[24].Value = model.QD045;
            parameter[25].Value = model.QD046;
            parameter[26].Value = model.QD047;
            parameter[27].Value = model.QD048;
            parameter[28].Value = model.QD049;
            parameter[29].Value = model.QD050;
            parameter[30].Value = model.QD051;
            parameter[31].Value = model.QD052;
            parameter[32].Value = model.QD053;
            parameter[33].Value = model.QD054;
            parameter[34].Value = model.QD055;
            parameter[35].Value = model.QD056;
            parameter[36].Value = model.QD057;
            parameter[37].Value = model.QD058;
            parameter[38].Value = model.QD059;
            parameter[39].Value = model.QD060;
            parameter[40].Value = model.QD061;
            parameter[41].Value = model.QD062;
            parameter[42].Value = model.QD063;
            parameter[43].Value = model.QD064;
            parameter[44].Value = model.QD065;
            parameter[45].Value = model.QD066;
            parameter[46].Value = model.QD067;
            parameter[47].Value = model.QD068;
            parameter[48].Value = model.QD069;
            parameter[49].Value = model.QD070;
            parameter[50].Value = model.QD071;
            parameter[51].Value = model.QD072;
            parameter[52].Value = model.QD073;
            parameter[53].Value = model.QD077;
            parameter[54].Value = model.QD078;
            parameter[55].Value = model.QD079;
            parameter[56].Value = model.QD094;
            parameter[57].Value = model.QD095;
            parameter[58].Value = model.QD096;
            parameter[59].Value = model.QD098;
            parameter[60].Value = model.QD102;
            parameter[61].Value = model.QD103;
            parameter[62].Value = model.Idx;

            int rows = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            ArrayList SQLString = new ArrayList( );
            if ( rows > 0 )
            {
                StringBuilder strSqls = new StringBuilder( );
                if ( model.QD099 == null )
                    strSqls.AppendFormat( "UPDATE R_PQZB QD099=NULL WHERE idx='{0}'" ,model.Idx );
                else
                    strSqls.AppendFormat( "UPDATE R_PQZB QD099='{0}' WHERE idx='{1}'" ,model.QD099 ,model.Idx );
                SQLString.Add( strSqls.ToString( ) );
                StringBuilder strSq = new StringBuilder( );
                if ( model.QD100 == null )
                    strSq.AppendFormat( "UPDATE R_PQZB QD0100=NULL WHERE idx='{0}'" ,model.Idx );
                else
                    strSq.AppendFormat( "UPDATE R_PQZB QD0100='{0}' WHERE idx='{1}'" ,model.QD100 ,model.Idx );
                SQLString.Add( strSq.ToString( ) );
                StringBuilder strS = new StringBuilder( );
                if ( model.QD101 == null )
                    strS.AppendFormat( "UPDATE R_PQZB QD101=NULL WHERE idx='{0}'" ,model.Idx );
                else
                    strS.AppendFormat( "UPDATE R_PQZB QD101='{0}' WHERE idx='{1}'" ,model.QD101 ,model.Idx );
                SQLString.Add( strS.ToString( ) );
                StringBuilder str = new StringBuilder( );
                if ( model.QD104 == null )
                    str.AppendFormat( "UPDATE R_PQZB QD104=NULL WHERE idx='{0}'" ,model.Idx );
                else
                    str.AppendFormat( "UPDATE R_PQZB QD104='{0}' WHERE idx='{1}'" ,model.QD104 ,model.Idx );
                SQLString.Add( str.ToString( ) );

                return SqlHelper.ExecuteSqlTran( SQLString );
            }
                return false;
        }


        /// <summary>
        /// 维护
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateWei ( MulaolaoLibrary.ZuZhangGongZiKaoHeZaLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQZA SET " );
            strSql.Append( "QD075=@QD075," );
            strSql.Append( "QD076=@QD076" );
            strSql.Append( " WHERE QD074=@QD074" );

            SqlParameter[] parameter = {
                new SqlParameter("@QD074",SqlDbType.NVarChar),
                new SqlParameter("@QD075",SqlDbType.NVarChar),
                new SqlParameter("@QD076",SqlDbType.NVarChar)
            };

            parameter[0].Value = model.QD074;
            parameter[1].Value = model.QD075;
            parameter[2].Value = model.QD076;

            int rows = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool DeleteIdxZa ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "DELETE FROM R_PQZA WHERE idx={0}" ,idx );

            int rows = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( rows > 0 )
                return true;
            else
                return false;
        }


        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx,string oddNum,string yearMonth,string day )
        {
            ArrayList SQLStringList = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "DELETE FROM R_PQZA WHERE idx={0}" ,idx );
            SQLStringList.Add( strSql );
            StringBuilder strSqlZb = new StringBuilder( );
            strSqlZb.AppendFormat( "DELETE FROM R_PQZB WHERE QD077='{0}' AND QD079='{1}' AND QD094='{2}'" ,oddNum ,yearMonth ,day );
            SQLStringList.Add( strSqlZb );

            return SqlHelper.ExecuteSqlTran( SQLStringList );
        }

        /// <summary>
        /// 删除多条记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DeleteOddNum ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQZA" );
            strSql.Append( " WHERE QD074=@QD074" );
            SqlParameter[] parameter = {
                new SqlParameter("@QD074",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            int rows = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool DeleteZb ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQZB" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };

            parameter[0].Value = idx;

            int rows= SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除多条记录  表二
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DeleteOddNumZb ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQAB" );
            strSql.Append( " WHERE QD077=@QD077" );
            SqlParameter[] parameter = {
                new SqlParameter("@QD077",SqlDbType.NVarChar)
            };
          
            parameter[0].Value = oddNum;

            int rows = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ZuZhangGongZiKaoHeZaLibrary GetModel ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,QD001,QD002,QD003,QD004,QD005,QD007,QD008,QD009,QD011,QD012,QD014,QD015,QD017,QD018,QD019,QD074,QD075,QD076 FROM R_PQZA" );
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
        /// 获取数据列表
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ZuZhangGongZiKaoHeZaLibrary GetDataRow ( DataRow row )
        {
            MulaolaoLibrary.ZuZhangGongZiKaoHeZaLibrary model = new MulaolaoLibrary.ZuZhangGongZiKaoHeZaLibrary( );

            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    model.Idx = int.Parse( row["idx"].ToString( ) );
                if ( row["QD001"] != null && row["QD001"].ToString( ) != "" )
                    model.QD001 = row["QD001"].ToString( );
                if ( row["QD002"] != null && row["QD002"].ToString( ) != "" )
                    model.QD002 = row["QD002"].ToString( );
                if ( row["QD003"] != null && row["QD003"].ToString( ) != "" )
                    model.QD003 = row["QD003"].ToString( );
                if ( row["QD004"] != null && row["QD004"].ToString( ) != "" )
                    model.QD004 = decimal.Parse( row["QD004"].ToString( ) );
                if ( row["QD005"] != null && row["QD005"].ToString( ) != "" )
                    model.QD005 = decimal.Parse( row["QD005"].ToString( ) );
                //if ( row["QD006"] != null && row["QD006"].ToString( ) != "" )
                //    model.QD006 = int.Parse( row["QD006"].ToString( ) );
                if ( row["QD007"] != null && row["QD007"].ToString( ) != "" )
                    model.QD007 = decimal.Parse( row["QD007"].ToString( ) );
                if ( row["QD008"] != null && row["QD008"].ToString( ) != "" )
                    model.QD008 = decimal.Parse( row["QD008"].ToString( ) );
                if ( row["QD009"] != null && row["QD009"].ToString( ) != "" )
                    model.QD009 = decimal.Parse( row["QD009"].ToString( ) );
                if ( row["QD011"] != null && row["QD011"].ToString( ) != "" )
                    model.QD011 = long.Parse( row["QD011"].ToString( ) );
                if ( row["QD012"] != null && row["QD012"].ToString( ) != "" )
                    model.QD012 = decimal.Parse( row["QD012"].ToString( ) );
                if ( row["QD014"] != null && row["QD014"].ToString( ) != "" )
                    model.QD014 = decimal.Parse( row["QD014"].ToString( ) );
                if ( row["QD015"] != null && row["QD015"].ToString( ) != "" )
                    model.QD015 = decimal.Parse( row["QD015"].ToString( ) );
                //if ( row["QD016"] != null && row["QD016"].ToString( ) != "" )
                //    model.QD016 = row["QD016"].ToString( );
                if ( row["QD017"] != null && row["QD017"].ToString( ) != "" )
                    model.QD017 = decimal.Parse( row["QD017"].ToString( ) );
                if ( row["QD018"] != null && row["QD018"].ToString( ) != "" )
                    model.QD018 = decimal.Parse( row["QD018"].ToString( ) );
                if ( row["QD019"] != null && row["QD019"].ToString( ) != "" )
                    model.QD019 = decimal.Parse( row["QD019"].ToString( ) );
                if ( row["QD074"] != null && row["QD074"].ToString( ) != "" )
                    model.QD074 = row["QD074"].ToString( );
                if ( row["QD075"] != null && row["QD075"].ToString( ) != "" )
                    model.QD075 = row["QD075"].ToString( );
                if ( row["QD076"] != null && row["QD076"].ToString( ) != "" )
                    model.QD076 = row["QD076"].ToString( );
            }

            return model;
        }

        /// <summary>
        /// 获取数据库列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTable (string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,QD001,QD002,QD003,QD004,QD005,QD007,QD008,QD009,QD011,QD012,QD014,QD015,QD017,QD018,QD019,F03 FROM R_PQZA" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( " ORDER BY QD003" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 是否已经执行
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="formText"></param>
        /// <returns></returns>
        public bool ExistsReview ( string oddNum ,string formText )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_REVIEWS A,R_MLLCXMC B" );
            strSql.Append( "  WHERE A.RES01=B.CX01 AND RES05='执行' AND RES06=@RES06 AND CX02=@CX02" );
            SqlParameter[] parameter = {
                new SqlParameter("@RES06",SqlDbType.NVarChar),
                new SqlParameter("@CX02",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;
            parameter[1].Value = formText;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }


        /// <summary>
        /// 得到一个实体数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableAll ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT QD075 FROM R_PQZA" );
            strSql.Append( " WHERE QD074=@QD074" );
            SqlParameter[] parameter = {
                new SqlParameter("@QD074",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取实体数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableTwo (string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQZB" );
            strSql.Append( " WHERE " + strWhere );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取产品名称等信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableName ( )
        {
            //SELECT PQF01 QD021,PQF03 QD096,PQF04 QD095 FROM R_PQF A,R_REVIEWS B WHERE A.PQF01=B.RES06 AND B.RES05='执行'
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT PQF01,PQF03,PQF04 FROM R_PQF A,R_REVIEWS B WHERE A.PQF01=B.RES06 AND B.RES05='执行'" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取组长姓名
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableHeadMan ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "WITH CET AS (" );
            strSql.Append( " SELECT * FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002='生产部')" );
            strSql.Append( "),CFT AS (" );
            strSql.Append( "SELECT * FROM TPADAA WHERE DAA002 IN (SELECT DBA002 FROM CET))" );
            strSql.Append( " SELECT DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM CFT)" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 执行数据库事务  删除表内容
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DeleteTran (string oddNum)
        {
            ArrayList SQLStringList = new ArrayList( );
            StringBuilder strZa = new StringBuilder( );
            strZa.AppendFormat( "SELECT COUNT(1) FROM R_PQZA WHERE QD074='{0}'" ,oddNum );
            if ( SqlHelper.Exists( strZa.ToString( ) ) == true )
            {
                StringBuilder strSql = new StringBuilder( );
                strSql.AppendFormat( "DELETE FROM R_PQZA WHERE QD074='{0}'" ,oddNum );
                SQLStringList.Add( strSql.ToString( ) );
            }
            StringBuilder strZb = new StringBuilder( );
            strZb.AppendFormat( "SELECT COUNT(1) FROM R_PQZB WHERE QD077='{0}'" ,oddNum );
            if ( SqlHelper.Exists( strZb.ToString( ) ) == true )
            {
                StringBuilder strSqlTwo = new StringBuilder( );
                strSqlTwo.AppendFormat( "DELETE FROM R_PQZB WHERE QD077='{0}'" ,oddNum );
                SQLStringList.Add( strSqlTwo.ToString( ) );
            }
            if ( SQLStringList.Count > 0 )
                return SqlHelper.ExecuteSqlTran( SQLStringList );
            else
                return true;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableSign ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT QD074,QD001,QD002 FROM R_PQZA" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM (SELECT DISTINCT QD074,QD001,QD002 FROM R_PQZA" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( " ) A" );

            object obj = SqlHelper.GetSingle( strSql.ToString( ) );
            if ( obj == null )
                return 0;
            else
                return Convert.ToInt32( obj );
        }


        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTableByChange ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT QD074,QD001,QD002 FROM (" );
            strSql.Append( "SELECT ROW_NUMBER() OVER(" );
            strSql.Append( "ORDER BY T.QD074" );
            strSql.Append( ") AS Row,T.* FROM R_PQZA T" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") TT" );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetDataTableOne ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT ISNULL(SUM(U1),0) U1,QD094 FROM (SELECT QD094,(ISNULL(QD022,0)*SUM(ISNULL(QD023,0))+ISNULL(QD024,0)*SUM(ISNULL(QD025,0))+ISNULL(QD026,0)*SUM(ISNULL(QD027,0))+ISNULL(QD028,0)*SUM(ISNULL(QD029,0))+ISNULL(QD030,0)*SUM(ISNULL(QD031,0))+ISNULL(QD032,0)*SUM(ISNULL(QD033,0))+ISNULL(QD034,0)*SUM(ISNULL(QD035,0))+ISNULL(QD036,0)*SUM(ISNULL(QD037,0))+ISNULL(QD038,0)*SUM(ISNULL(QD039,0))+ISNULL(QD040,0)*SUM(ISNULL(QD041,0))+ISNULL(QD042,0)*SUM(ISNULL(QD043,0))+ISNULL(QD044,0)*SUM(ISNULL(QD045,0))+ISNULL(QD046,0)*SUM(ISNULL(QD047,0))+ISNULL(QD048,0)*SUM(ISNULL(QD049,0))+ISNULL(QD050,0)*SUM(ISNULL(QD051,0))+ISNULL(QD052,0)*SUM(ISNULL(QD053,0))+ISNULL(QD054,0)*SUM(ISNULL(QD055,0))+ISNULL(QD056,0)*SUM(ISNULL(QD057,0))+ISNULL(QD058,0)*SUM(ISNULL(QD059,0))+ISNULL(QD060,0)*SUM(ISNULL(QD061,0))+ISNULL(QD062,0)*SUM(ISNULL(QD063,0))+ISNULL(QD064,0)*SUM(ISNULL(QD065,0))+ISNULL(QD066,0)*SUM(ISNULL(QD067,0))+ISNULL(QD068,0)*SUM(ISNULL(QD069,0))+ISNULL(QD070,0)*SUM(ISNULL(QD071,0))+ISNULL(QD072,0)*SUM(ISNULL(QD073,0)))*QD004 U1 FROM R_PQZB C,R_PQZA B" );
            strSql.Append( " WHERE C.QD077=B.QD074 AND C.QD078=B.QD001 AND C.QD079=B.QD002 AND C.QD094=B.QD003 AND QD077=@QD077" );
            strSql.Append( " GROUP BY QD022,QD024,QD026,QD028,QD030,QD032,QD034,QD036,QD038,QD040,QD042,QD044,QD046,QD048,QD050,QD052,QD054,QD056,QD058,QD060,QD062,QD064,QD004,QD094,QD066,QD068,QD070,QD072 ) A" );
            strSql.Append( " GROUP BY QD094" );
            SqlParameter[] parameter = {
                new SqlParameter("@QD077",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetDataTableTwo ( MulaolaoLibrary.ZuZhangGongZiKaoHeZbLibrary model )
        {
            //,SUM(Q24) Q24,SUM(Q25) Q25,SUM(Q26) Q26,SUM(Q27) Q27,,SUM(Q24)+SUM(Q25)+SUM(Q26) Q28 ,CONVERT(INT,SUM(QD067)*QD066) Q24,CONVERT(INT,SUM(QD069)*QD068) Q25,CONVERT(INT,SUM(QD071)*QD070) Q26,CONVERT(INT,SUM(QD073)*QD072) Q27 ,QD066,QD068,QD070,QD072
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT SUM(QD23) QD23,SUM(QD25) QD25,SUM(QD27) QD27,SUM(Q29) Q29,SUM(Q31) Q31,SUM(Q33) Q33,SUM(Q35) Q35,SUM(Q37) Q37,SUM(Q39) Q39,SUM(Q41) Q41,SUM(Q43) Q43,SUM(Q45) Q45,SUM(Q47) Q47,SUM(Q49) Q49,SUM(Q51) Q51,SUM(Q53) Q53,SUM(Q55) Q55,SUM(Q57) Q57,SUM(Q59) Q59,SUM(Q61) Q61,SUM(Q63) Q63,SUM(Q65) Q65,SUM(Q67) Q67,SUM(Q69) Q69,SUM(Q71) Q71,SUM(Q73) Q73,SUM(Q1) Q1,SUM(Q2) Q2,SUM(Q3) Q3,SUM(Q4) Q4,SUM(Q5) Q5,SUM(Q6) Q6,SUM(Q7) Q7,SUM(Q8) Q8,SUM(Q9) Q9,SUM(Q10) Q10,SUM(Q11) Q11,SUM(Q12) Q12,SUM(Q13) Q13,SUM(Q14) Q14,SUM(Q15) Q15,SUM(Q16) Q16,SUM(Q17) Q17,SUM(Q18) Q18,SUM(Q19) Q19,SUM(Q20) Q20,SUM(Q21) Q21,SUM(Q22) Q22,SUM(Q1)+SUM(Q2)+SUM(Q3)+SUM(Q4)+SUM(Q5)+SUM(Q6)+SUM(Q7)+SUM(Q8)+SUM(Q9)+SUM(Q10)+SUM(Q11)+SUM(Q12)+SUM(Q13)+SUM(Q14)+SUM(Q15)+SUM(Q16)+SUM(Q17)+SUM(Q18)+SUM(Q19)+SUM(Q20)+SUM(Q21)+SUM(Q22) Q23 FROM(SELECT SUM(QD023) QD23,SUM(QD025) QD25,SUM(QD027) QD27,SUM(QD029) Q29,SUM(QD031) Q31,SUM(QD033) Q33,SUM(QD035) Q35,SUM(QD037) Q37,SUM(QD039) Q39,SUM(QD041) Q41,SUM(QD043) Q43,SUM(QD045) Q45,SUM(QD047) Q47,SUM(QD049) Q49,SUM(QD051) Q51,SUM(QD053) Q53,SUM(QD055) Q55,SUM(QD057) Q57,SUM(QD059) Q59,SUM(QD061) Q61,SUM(QD063) Q63,SUM(QD065) Q65,SUM(QD067) Q67,SUM(QD069) Q69,SUM(QD071) Q71,SUM(QD073) Q73,CONVERT(INT,SUM(QD023)*QD022) Q1,CONVERT(INT,SUM(QD025)*QD024) Q2,CONVERT(INT,SUM(QD027)*QD026) Q3,CONVERT(INT,SUM(QD029)*QD028) Q4,CONVERT(INT,SUM(QD031)*QD030) Q5,CONVERT(INT,SUM(QD033)*QD032) Q6,CONVERT(INT,SUM(QD035)*QD034) Q7,CONVERT(INT,SUM(QD037)*QD036) Q8,CONVERT(INT,SUM(QD039)*QD038) Q9,CONVERT(INT,SUM(QD041)*QD040) Q10,CONVERT(INT,SUM(QD043)*QD042) Q11,CONVERT(INT,SUM(QD045)*QD044) Q12,CONVERT(INT,SUM(QD047)*QD046) Q13,CONVERT(INT,SUM(QD049)*QD048) Q14,CONVERT(INT,SUM(QD051)*QD050) Q15,CONVERT(INT,SUM(QD053)*QD052) Q16,CONVERT(INT,SUM(QD055)*QD054) Q17,CONVERT(INT,SUM(QD057)*QD056) Q18,CONVERT(INT,SUM(QD059)*QD058) Q19,CONVERT(INT,SUM(QD061)*QD060) Q20,CONVERT(INT,SUM(QD063)*QD062) Q21,CONVERT(INT,SUM(QD065)*QD064) Q22 FROM R_PQZB" );
            strSql.Append( " WHERE QD079=@QD079 AND QD077=@QD077" );
            strSql.Append( " GROUP BY QD022,QD024,QD026,QD028,QD030,QD032,QD034,QD036,QD038,QD040,QD042,QD044,QD046,QD048,QD050,QD052,QD054,QD056,QD058,QD060,QD062,QD064) A" );
            SqlParameter[] parameter = {
                new SqlParameter("@QD077",SqlDbType.NVarChar),
                new SqlParameter("@QD079",SqlDbType.NVarChar)
            };

            parameter[0].Value = model.QD077;
            parameter[1].Value = model.QD079;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="dateYm"></param>
        /// <returns></returns>
        public DataTable GetDataTableDate ( string dateYm ,string name)
        {
            StringBuilder strSql = new StringBuilder( );
            
            /*
            strSql.Append( "WITH CET AS (SELECT AE02,MAX(AE21) AE21,CONVERT(DECIMAL(18,1),SUM(AE28)) AE28 FROM (SELECT AE02,AE21,CASE WHEN AE12!=0 THEN SUM(AE37*AE12) ELSE SUM(AE37*AE10*AE11) END AE28 FROM R_PQAE" );
            strSql.AppendFormat( " WHERE SUBSTRING( CONVERT( VARCHAR ,AE17 ) ,0 ,8 ) >='{0}'" ,dateYm );
            strSql.Append( " GROUP BY AE21,AE02,AE12) A GROUP BY AE02)" );
            strSql.Append( ", CFT AS (" );
            strSql.AppendFormat( "SELECT PQF01,PQF03,PQF04,PQF32,PQF31,HT04,CONVERT(DECIMAL(18,1),CASE WHEN SUBSTRING( CONVERT( VARCHAR ,PQF31 ) ,0 ,8 )='{0}' THEN CASE WHEN PQF09!=0 THEN PQF09*PQF06 WHEN PQF09=0 THEN PQF06*PQF10*PQF45 END ELSE 0 END ) U1,CONVERT(DECIMAL(18,1),CASE WHEN SUBSTRING( CONVERT( VARCHAR ,HT04 ) ,0 ,8 )='{0}' THEN CASE WHEN PQF09!=0 THEN PQF09*PQF06 WHEN PQF09=0 THEN PQF06*PQF10*PQF45 END ELSE 0 END) U2,AE21,CASE WHEN SUBSTRING( CONVERT( VARCHAR ,PQF31 ) ,0 ,8 )='{0}' THEN AE28 ELSE 0 END AE28 FROM R_PQF A LEFT JOIN R_PQL B ON A.PQF01=B.HT01 LEFT JOIN CET ON AE02=PQF01" ,dateYm );
            strSql.AppendFormat( " WHERE PQF17=(SELECT DAA001 FROM TPADAA WHERE DAA002='{0}')" ,name );
            strSql.AppendFormat( " AND SUBSTRING( CONVERT( VARCHAR ,PQF31 ) ,0 ,8 ) >= '{0}' " ,dateYm );
            strSql.AppendFormat( "  AND SUBSTRING( CONVERT( VARCHAR ,HT04 ) ,0 ,8 ) <= '{0}'" ,dateYm );
            strSql.Append( " UNION " );
            strSql.Append( "SELECT AE02,AE05,AE03,PQF32,PQF31,HT04,0 AS U1,0 AS U2,MAX(AE21) AE21,CONVERT(DECIMAL(18,0),CASE WHEN AE12!=0 THEN SUM(AE37*AE12) ELSE SUM(AE37*AE10*AE11) END) AE28 FROM R_PQAE A LEFT JOIN R_PQF B ON A.AE02=B.PQF01 LEFT JOIN R_PQL C ON B.PQF01=C.HT01" );
            strSql.AppendFormat( " WHERE AE08='{0}'" ,name );
            strSql.AppendFormat( " AND SUBSTRING( CONVERT( VARCHAR ,AE21 ) ,0 ,8 )='{0}'" ,dateYm );
            strSql.Append( " GROUP BY AE02,AE12,PQF31,PQF32,AE03,AE05,HT04" );
            strSql.Append( ")" );
            strSql.Append( " SELECT PQF01,PQF03,PQF04,PQF32,PQF31,HT04,SUM(U1) U1,SUM(U2) U2,AE21,MAX(AE28) AE28 FROM CFT GROUP BY PQF01,PQF03,PQF04,PQF32,PQF31,HT04,AE21" );
            */
            
            strSql.Append( "WITH CET AS (" );
            strSql.Append( "SELECT AE02,MAX(AE21) AE21,CONVERT(DECIMAL(18,0),SUM(AE28)) AE28 FROM (SELECT AE02,AE21,CASE WHEN AE12!=0 THEN SUM(AE37*AE12) ELSE SUM(AE37*AE10*AE11) END AE28 FROM R_PQAE" );
            strSql.AppendFormat( " WHERE SUBSTRING( CONVERT( VARCHAR ,AE17 ) ,0 ,8 ) >='{0}'" ,dateYm );
            strSql.Append( " GROUP BY AE21,AE02,AE12) A GROUP BY AE02)" );
            strSql.Append( ",CFT AS (" );
            strSql.Append( "SELECT PQF01,PQF03,PQF04,PQF32,PQF31,HT04,CONVERT(DECIMAL(18,0)," );
            strSql.AppendFormat( "CASE WHEN SUBSTRING( CONVERT( VARCHAR ,PQF31 ) ,0 ,8 )='{0}'" ,dateYm );
            strSql.Append( " THEN CASE WHEN PQF09!=0 THEN PQF09*PQF06 WHEN PQF09=0 THEN PQF06*PQF10*PQF45 END ELSE 0 END ) U1,CONVERT(DECIMAL(18,0),CASE WHEN" );
            strSql.AppendFormat( " SUBSTRING( CONVERT( VARCHAR ,HT04 ) ,0 ,8 )='{0}'" ,dateYm );
            strSql.Append( " THEN CASE WHEN PQF09!=0 THEN PQF09*PQF06 WHEN PQF09=0 THEN PQF06*PQF10*PQF45 END ELSE 0 END) U2,AE21," );
            strSql.AppendFormat( " CASE WHEN SUBSTRING( CONVERT( VARCHAR ,PQF31 ) ,0 ,8 )='{0}'" ,dateYm );
            strSql.Append( " THEN AE28 ELSE 0 END AE28 FROM R_PQF A LEFT JOIN R_PQL B ON A.PQF01=B.HT01 LEFT JOIN CET ON AE02=PQF01" );
            strSql.AppendFormat( " WHERE PQF17 IN (SELECT DAA001 FROM TPADAA WHERE DAA002='{0}')" ,name );
            strSql.AppendFormat( " AND SUBSTRING( CONVERT( VARCHAR ,PQF31 ) ,0 ,8 ) >='{0}'" ,dateYm );
            strSql.AppendFormat( " AND SUBSTRING( CONVERT( VARCHAR ,HT04 ) ,0 ,8 ) <='{0}'" ,dateYm );
            strSql.Append( " UNION " );
            strSql.Append( "SELECT AE02,AE05,AE03,PQF32,PQF31,HT04,CONVERT(DECIMAL(18,0),CASE WHEN AE12!=0 THEN SUM(AE06*AE12) ELSE SUM(AE06*AE10*AE11) END) U1,0 AS U2,MAX(AE21) AE21,CONVERT(DECIMAL(18,0),CASE WHEN AE12!=0 THEN SUM(AE37*AE12) ELSE SUM(AE37*AE10*AE11) END) AE28 FROM R_PQAE A LEFT JOIN R_PQF B ON A.AE02=B.PQF01 LEFT JOIN R_PQL C ON B.PQF01=C.HT01" );
            strSql.AppendFormat( " WHERE AE08='{0}'" ,name );
            strSql.AppendFormat( " AND SUBSTRING( CONVERT( VARCHAR ,AE21 ) ,0 ,8 )='{0}'" ,dateYm );
            strSql.Append( " GROUP BY AE02,AE12,PQF31,PQF32,AE03,AE05,HT04" );
            strSql.Append( "),CGT AS (SELECT AE02,MAX(AE21) AE21,CONVERT(DECIMAL(18,0),SUM(CASE WHEN AE12!=0 THEN AE37*AE12 ELSE AE37*AE10*AE11 END)) AE28 FROM R_PQAE" );
            strSql.AppendFormat( " WHERE SUBSTRING( CONVERT( VARCHAR ,AE17 ) ,0 ,8 )<'{0}'" ,dateYm );
            strSql.AppendFormat( " AND AE08='{0}'" ,name );
            strSql.Append( " GROUP BY AE02),CHT AS (SELECT AE02,MAX(AE21) AE21,CONVERT(DECIMAL(18,0),CASE WHEN AE12!=0 THEN AE06*AE12 ELSE AE06*AE10*AE11 END) AE06 FROM R_PQAE" );
            strSql.AppendFormat( " WHERE SUBSTRING( CONVERT( VARCHAR ,AE17 ) ,0 ,8 )<'{0}'" ,dateYm );
            strSql.AppendFormat( " AND AE08='{0}'" ,name );
            strSql.Append( " GROUP BY AE02,AE12,AE06,AE10,AE11),CLT AS(" );
            strSql.Append( "SELECT PQF01,PQF03,PQF04,PQF32,PQF31,HT04,SUM(U1) U1,SUM(U2) U2,AE21,MAX(AE28) AE28 FROM CFT GROUP BY PQF01,PQF03,PQF04,PQF32,PQF31,HT04,AE21" );
            strSql.Append( " UNION" );
            strSql.Append( " SELECT AE02,PQF03,PQF04,PQF32,PQF31,HT04,AE06,U2,AE21,AE28 FROM (SELECT A.AE02,PQF03,PQF04,PQF32,PQF31,B.AE06,0 AS U2,HT04,AE28,A.AE21 FROM CGT A LEFT JOIN CHT B ON A.AE02=B.AE02 LEFT JOIN R_PQF C ON A.AE02=C.PQF01 LEFT JOIN R_PQL D ON A.AE02=D.HT01 WHERE A.AE21 IS NOT NULL GROUP BY A.AE02,AE28,B.AE06,PQF03,PQF04,PQF32,PQF31,HT04,A.AE21 HAVING AE28<B.AE06) A GROUP BY AE02,AE28,AE06,PQF03,PQF04,PQF32,PQF31,HT04,U2,AE21)" );
            strSql.Append( " SELECT PQF01,PQF03,PQF04,PQF32,PQF31,HT04,SUM(U1) U1,SUM(U2) U2,AE21,SUM(AE28) AE28 FROM CLT GROUP BY PQF01,PQF03,PQF04,PQF32,PQF31,HT04,AE21 ORDER BY PQF01" );
            
            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableDateOf ( string yearMonth ,string name)
        {
            DataTable da, de;
            do
            {
                string year = "";
                da = GetDataTableDate( yearMonth.Substring( 0 ,4 ) + "-" + yearMonth.Substring( 4 ,2 ) ,name );
                if ( Convert.ToInt32( yearMonth.Substring( 3 ,2 ) ) == 1 )
                    year = ( Convert.ToInt32( yearMonth ) + 1 ).ToString( );
                else
                    year = ( Convert.ToInt32( yearMonth ) - 1 ).ToString( );
                de = GetDataTableDate( year.Substring( 0 ,4 ) + "-" + year.Substring( 4 ,2 ) ,name );
            }
            while ( tableTheSame( da ,de ) == true );

            return da;
        }
        public DataTable GetDataTableDates ( string dateYm ,string name )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AE02,AE03,AE05,PQF31,PQF32,HT04,AE21,CONVERT(DECIMAL(18,0),CASE WHEN AE12!=0 THEN SUM(AE37*AE12) ELSE SUM(AE37*AE10*AE11) END) AE28 FROM R_PQAE A LEFT JOIN R_PQF B ON A.AE02=B.PQF01 LEFT JOIN R_PQL C ON B.PQF01=C.HT01" );
            strSql.AppendFormat( " WHERE AE08='{0}'" ,name );
            strSql.AppendFormat( " AND SUBSTRING( CONVERT( VARCHAR ,AE21 ) ,0 ,8 )='{0}'" ,dateYm );
            strSql.Append( " GROUP BY AE02,AE21,AE12,PQF31,PQF32,AE03,AE05,HT04" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableDats ( string name )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT MAX(AE21) AE21,CONVERT(DECIMAL(18,1),SUM(AE28)) AE28 FROM (SELECT AE21,SUM(AE37*AE12) AE28 FROM R_PQAE" );
            strSql.AppendFormat( " WHERE AE02='{0}'" ,name );
            strSql.Append( " GROUP BY AE21) A" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableAll ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT ZZ002,ZZ003,ZZ004,ZZ005,ZZ006,ZZ007,ZZ008 FROM R_PQZZ WHERE ZZ001 LIKE '%R_501%'" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="tableNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfParameter ( string tableNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQAY WHERE AY001=@AY001" );
            SqlParameter[] parrameter = {
                new SqlParameter("@AY001",SqlDbType.NVarChar)
            };
            parrameter[0].Value = tableNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parrameter );
        }

        public bool AddOfParameter ( DataTable table ,string sign )
        {
            //StringBuilder strSql = new StringBuilder( );
            //strSql.Append( "SELECT * FROM R_PQAY WHERE 1=2" );

            //return SqlHelper.UpdateTable( table ,strSql.ToString( ) );

            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            MulaolaoLibrary . ZuZhangGongZiKaoHeOneEntity entity = new MulaolaoLibrary . ZuZhangGongZiKaoHeOneEntity ( );

            if ( sign . Equals ( "1" ) )
            {
                entity . AY001 = "R_501";
                MulaolaoLibrary . ZuZhangGongZiKaoHeZbLibrary model = new MulaolaoLibrary . ZuZhangGongZiKaoHeZbLibrary ( );

                for ( int i = 0 ; i < table . Rows . Count ; i++ )
                {
                    model . QD022 = entity . AY002 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY002" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY002" ] . ToString ( ) );
                    model . QD024 = entity . AY003 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY003" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY003" ] . ToString ( ) );
                    model . QD026 = entity . AY004 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY004" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY004" ] . ToString ( ) );
                    model . QD028 = entity . AY005 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY005" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY005" ] . ToString ( ) );
                    model . QD030 = entity . AY006 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY006" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY006" ] . ToString ( ) );
                    model . QD032 = entity . AY007 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY007" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY007" ] . ToString ( ) );
                    model . QD034 = entity . AY008 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY008" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY008" ] . ToString ( ) );
                    model . QD036 = entity . AY009 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY009" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY009" ] . ToString ( ) );
                    model . QD038 = entity . AY010 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY010" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY010" ] . ToString ( ) );
                    model . QD040 = entity . AY011 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY011" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY011" ] . ToString ( ) );
                    model . QD042 = entity . AY012 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY012" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY012" ] . ToString ( ) );
                    model . QD044 = entity . AY013 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY013" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY013" ] . ToString ( ) );
                    model . QD046 = entity . AY014 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY014" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY014" ] . ToString ( ) );
                    model . QD048 = entity . AY015 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY015" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY015" ] . ToString ( ) );
                    model . QD050 = entity . AY016 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY016" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY016" ] . ToString ( ) );
                    model . QD052 = entity . AY017 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY017" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY017" ] . ToString ( ) );
                    model . QD054 = entity . AY018 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY018" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY018" ] . ToString ( ) );
                    model . QD056 = entity . AY019 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY019" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY019" ] . ToString ( ) );
                    model . QD058 = entity . AY020 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY020" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY020" ] . ToString ( ) );
                    model . QD060 = entity . AY021 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY021" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY021" ] . ToString ( ) );
                    model . QD062 = entity . AY022 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY022" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY022" ] . ToString ( ) );
                    model . QD064 = entity . AY023 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY023" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY023" ] . ToString ( ) );
                    model . QD066 = entity . AY027 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY027" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY027" ] . ToString ( ) );
                    model . QD068 = entity . AY024 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY024" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY024" ] . ToString ( ) );
                    model . QD070 = entity . AY025 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY025" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY025" ] . ToString ( ) );
                    model . QD072 = entity . AY026 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY026" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY026" ] . ToString ( ) );
                    edit_zb ( SQLString ,strSql ,model );
                    edit_ay_one ( SQLString ,strSql ,entity );
                }
            }
            else if ( sign . Equals ( "2" ) )
            {
                entity . AY001 = "R_502";
                MulaolaoLibrary . ZuZhangGongZiKaoHeBzLibrary model = new MulaolaoLibrary . ZuZhangGongZiKaoHeBzLibrary ( );
                for ( int i = 0 ; i < table . Rows . Count ; i++ )
                {
                    model . HD022 = entity . AY002 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY002" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY002" ] . ToString ( ) );
                    model . HD024 = entity . AY003 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY003" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY003" ] . ToString ( ) );
                    model . HD026 = entity . AY004 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY004" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY004" ] . ToString ( ) );
                    model . HD028 = entity . AY005 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY005" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY005" ] . ToString ( ) );
                    model . HD030 = entity . AY006 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY006" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY006" ] . ToString ( ) );
                    model . HD032 = entity . AY007 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY007" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY007" ] . ToString ( ) );
                    model . HD034 = entity . AY008 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY008" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY008" ] . ToString ( ) );
                    model . HD036 = entity . AY009 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY009" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY009" ] . ToString ( ) );
                    model . HD038 = entity . AY010 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY010" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY010" ] . ToString ( ) );
                    model . HD040 = entity . AY011 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY011" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY011" ] . ToString ( ) );
                    model . HD042 = entity . AY012 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY012" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY012" ] . ToString ( ) );
                    model . HD044 = entity . AY013 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY013" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY013" ] . ToString ( ) );
                    model . HD046 = entity . AY014 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY014" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY014" ] . ToString ( ) );
                    model . HD048 = entity . AY015 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY015" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY015" ] . ToString ( ) );
                    model . HD050 = entity . AY016 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY016" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY016" ] . ToString ( ) );
                    model . HD052 = entity . AY017 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY017" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY017" ] . ToString ( ) );
                    model . HD054 = entity . AY018 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY018" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY018" ] . ToString ( ) );
                    model . HD056 = entity . AY019 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY019" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY019" ] . ToString ( ) );
                    model . HD058 = entity . AY020 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY020" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY020" ] . ToString ( ) );
                    model . HD060 = entity . AY021 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY021" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY021" ] . ToString ( ) );
                    model . HD062 = entity . AY022 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY022" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY022" ] . ToString ( ) );
                    model . HD064 = entity . AY023 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY023" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY023" ] . ToString ( ) );
                    model . HD066 = entity . AY027 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY024" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY024" ] . ToString ( ) );
                    model . HD068 = entity . AY024 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY025" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY025" ] . ToString ( ) );
                    model . HD070 = entity . AY025 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY026" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY026" ] . ToString ( ) );
                    model . HD072 = entity . AY026 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "AY027" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ 0 ] [ "AY027" ] . ToString ( ) );
                    edit_bz ( SQLString ,strSql ,model );
                    edit_ay_one ( SQLString ,strSql ,entity );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void edit_zb ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . ZuZhangGongZiKaoHeZbLibrary model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQZB set " );
            strSql . Append ( "QD022=@QD022," );
            strSql . Append ( "QD024=@QD024," );
            strSql . Append ( "QD026=@QD026," );
            strSql . Append ( "QD028=@QD028," );
            strSql . Append ( "QD030=@QD030," );
            strSql . Append ( "QD032=@QD032," );
            strSql . Append ( "QD034=@QD034," );
            strSql . Append ( "QD036=@QD036," );
            strSql . Append ( "QD038=@QD038," );
            strSql . Append ( "QD040=@QD040," );
            strSql . Append ( "QD042=@QD042," );
            strSql . Append ( "QD044=@QD044," );
            strSql . Append ( "QD046=@QD046," );
            strSql . Append ( "QD048=@QD048," );
            strSql . Append ( "QD050=@QD050," );
            strSql . Append ( "QD052=@QD052," );
            strSql . Append ( "QD054=@QD054," );
            strSql . Append ( "QD056=@QD056," );
            strSql . Append ( "QD058=@QD058," );
            strSql . Append ( "QD060=@QD060," );
            strSql . Append ( "QD062=@QD062," );
            strSql . Append ( "QD064=@QD064," );
            strSql . Append ( "QD066=@QD066," );
            strSql . Append ( "QD068=@QD068," );
            strSql . Append ( "QD070=@QD070," );
            strSql . Append ( "QD072=@QD072 " );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@QD022", SqlDbType.Decimal,5),
                    new SqlParameter("@QD024", SqlDbType.Decimal,5),
                    new SqlParameter("@QD026", SqlDbType.Decimal,5),
                    new SqlParameter("@QD028", SqlDbType.Decimal,5),
                    new SqlParameter("@QD030", SqlDbType.Decimal,5),
                    new SqlParameter("@QD032", SqlDbType.Decimal,5),
                    new SqlParameter("@QD034", SqlDbType.Decimal,5),
                    new SqlParameter("@QD036", SqlDbType.Decimal,5),
                    new SqlParameter("@QD038", SqlDbType.Decimal,5),
                    new SqlParameter("@QD040", SqlDbType.Decimal,5),
                    new SqlParameter("@QD042", SqlDbType.Decimal,5),
                    new SqlParameter("@QD044", SqlDbType.Decimal,5),
                    new SqlParameter("@QD046", SqlDbType.Decimal,5),
                    new SqlParameter("@QD048", SqlDbType.Decimal,5),
                    new SqlParameter("@QD050", SqlDbType.Decimal,5),
                    new SqlParameter("@QD052", SqlDbType.Decimal,5),
                    new SqlParameter("@QD054", SqlDbType.Decimal,5),
                    new SqlParameter("@QD056", SqlDbType.Decimal,5),
                    new SqlParameter("@QD058", SqlDbType.Decimal,5),
                    new SqlParameter("@QD060", SqlDbType.Decimal,5),
                    new SqlParameter("@QD062", SqlDbType.Decimal,5),
                    new SqlParameter("@QD064", SqlDbType.Decimal,5),
                    new SqlParameter("@QD066", SqlDbType.Decimal,5),
                    new SqlParameter("@QD068", SqlDbType.Decimal,5),
                    new SqlParameter("@QD070", SqlDbType.Decimal,5),
                    new SqlParameter("@QD072", SqlDbType.Decimal,5)
            };
            parameters [ 0 ] . Value = model . QD022;
            parameters [ 1 ] . Value = model . QD024;
            parameters [ 2 ] . Value = model . QD026;
            parameters [ 3 ] . Value = model . QD028;
            parameters [ 4 ] . Value = model . QD030;
            parameters [ 5 ] . Value = model . QD032;
            parameters [ 6 ] . Value = model . QD034;
            parameters [ 7 ] . Value = model . QD036;
            parameters [ 8 ] . Value = model . QD038;
            parameters [ 9 ] . Value = model . QD040;
            parameters [ 10 ] . Value = model . QD042;
            parameters [ 11 ] . Value = model . QD044;
            parameters [ 12 ] . Value = model . QD046;
            parameters [ 13 ] . Value = model . QD048;
            parameters [ 14 ] . Value = model . QD050;
            parameters [ 15 ] . Value = model . QD052;
            parameters [ 16 ] . Value = model . QD054;
            parameters [ 17 ] . Value = model . QD056;
            parameters [ 18 ] . Value = model . QD058;
            parameters [ 19 ] . Value = model . QD060;
            parameters [ 20 ] . Value = model . QD062;
            parameters [ 21 ] . Value = model . QD064;
            parameters [ 22 ] . Value = model . QD066;
            parameters [ 23 ] . Value = model . QD068;
            parameters [ 24 ] . Value = model . QD070;
            parameters [ 25 ] . Value = model . QD072;

            SQLString . Add ( strSql ,parameters );
        }

        void edit_ay_one ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . ZuZhangGongZiKaoHeOneEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQAY set " );
            strSql . Append ( "AY002=@AY002," );
            strSql . Append ( "AY003=@AY003," );
            strSql . Append ( "AY004=@AY004," );
            strSql . Append ( "AY005=@AY005," );
            strSql . Append ( "AY006=@AY006," );
            strSql . Append ( "AY007=@AY007," );
            strSql . Append ( "AY008=@AY008," );
            strSql . Append ( "AY009=@AY009," );
            strSql . Append ( "AY010=@AY010," );
            strSql . Append ( "AY011=@AY011," );
            strSql . Append ( "AY012=@AY012," );
            strSql . Append ( "AY013=@AY013," );
            strSql . Append ( "AY014=@AY014," );
            strSql . Append ( "AY015=@AY015," );
            strSql . Append ( "AY016=@AY016," );
            strSql . Append ( "AY017=@AY017," );
            strSql . Append ( "AY018=@AY018," );
            strSql . Append ( "AY019=@AY019," );
            strSql . Append ( "AY020=@AY020," );
            strSql . Append ( "AY021=@AY021," );
            strSql . Append ( "AY022=@AY022," );
            strSql . Append ( "AY023=@AY023," );
            strSql . Append ( "AY024=@AY024," );
            strSql . Append ( "AY025=@AY025," );
            strSql . Append ( "AY026=@AY026," );
            strSql . Append ( "AY027=@AY027 " );
            strSql . Append ( " WHERE AY001=@AY001" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@AY002", SqlDbType.Decimal,5),
                    new SqlParameter("@AY003", SqlDbType.Decimal,5),
                    new SqlParameter("@AY004", SqlDbType.Decimal,5),
                    new SqlParameter("@AY005", SqlDbType.Decimal,5),
                    new SqlParameter("@AY006", SqlDbType.Decimal,5),
                    new SqlParameter("@AY007", SqlDbType.Decimal,5),
                    new SqlParameter("@AY008", SqlDbType.Decimal,5),
                    new SqlParameter("@AY009", SqlDbType.Decimal,5),
                    new SqlParameter("@AY010", SqlDbType.Decimal,5),
                    new SqlParameter("@AY011", SqlDbType.Decimal,5),
                    new SqlParameter("@AY012", SqlDbType.Decimal,5),
                    new SqlParameter("@AY013", SqlDbType.Decimal,5),
                    new SqlParameter("@AY014", SqlDbType.Decimal,5),
                    new SqlParameter("@AY015", SqlDbType.Decimal,5),
                    new SqlParameter("@AY016", SqlDbType.Decimal,5),
                    new SqlParameter("@AY017", SqlDbType.Decimal,5),
                    new SqlParameter("@AY018", SqlDbType.Decimal,5),
                    new SqlParameter("@AY019", SqlDbType.Decimal,5),
                    new SqlParameter("@AY020", SqlDbType.Decimal,5),
                    new SqlParameter("@AY021", SqlDbType.Decimal,5),
                    new SqlParameter("@AY022", SqlDbType.Decimal,5),
                    new SqlParameter("@AY023", SqlDbType.Decimal,5),
                    new SqlParameter("@AY024", SqlDbType.Decimal,5),
                    new SqlParameter("@AY025", SqlDbType.Decimal,5),
                    new SqlParameter("@AY026", SqlDbType.Decimal,5),
                    new SqlParameter("@AY027", SqlDbType.Decimal,5),
                    new SqlParameter("@AY001",SqlDbType.NVarChar,10)
            };
            parameters [ 0 ] . Value = model . AY002;
            parameters [ 1 ] . Value = model . AY003;
            parameters [ 2 ] . Value = model . AY004;
            parameters [ 3 ] . Value = model . AY005;
            parameters [ 4 ] . Value = model . AY006;
            parameters [ 5 ] . Value = model . AY007;
            parameters [ 6 ] . Value = model . AY008;
            parameters [ 7 ] . Value = model . AY009;
            parameters [ 8 ] . Value = model . AY010;
            parameters [ 9 ] . Value = model . AY011;
            parameters [ 10 ] . Value = model . AY012;
            parameters [ 11 ] . Value = model . AY013;
            parameters [ 12 ] . Value = model . AY014;
            parameters [ 13 ] . Value = model . AY015;
            parameters [ 14 ] . Value = model . AY016;
            parameters [ 15 ] . Value = model . AY017;
            parameters [ 16 ] . Value = model . AY018;
            parameters [ 17 ] . Value = model . AY019;
            parameters [ 18 ] . Value = model . AY020;
            parameters [ 19 ] . Value = model . AY021;
            parameters [ 20 ] . Value = model . AY022;
            parameters [ 21 ] . Value = model . AY023;
            parameters [ 22 ] . Value = model . AY024;
            parameters [ 23 ] . Value = model . AY025;
            parameters [ 24 ] . Value = model . AY026;
            parameters [ 25 ] . Value = model . AY027;
            parameters [ 26 ] . Value = model . AY001;

            SQLString . Add ( strSql ,parameters );
        }

        void edit_bz ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . ZuZhangGongZiKaoHeBzLibrary model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQBZ set " );
            strSql . Append ( "HD022=@HD022," );
            strSql . Append ( "HD024=@HD024," );
            strSql . Append ( "HD026=@HD026," );
            strSql . Append ( "HD028=@HD028," );
            strSql . Append ( "HD030=@HD030," );
            strSql . Append ( "HD032=@HD032," );
            strSql . Append ( "HD034=@HD034," );
            strSql . Append ( "HD036=@HD036," );
            strSql . Append ( "HD038=@HD038," );
            strSql . Append ( "HD040=@HD040," );
            strSql . Append ( "HD042=@HD042," );
            strSql . Append ( "HD044=@HD044," );
            strSql . Append ( "HD046=@HD046," );
            strSql . Append ( "HD048=@HD048," );
            strSql . Append ( "HD050=@HD050," );
            strSql . Append ( "HD052=@HD052," );
            strSql . Append ( "HD054=@HD054," );
            strSql . Append ( "HD056=@HD056," );
            strSql . Append ( "HD058=@HD058," );
            strSql . Append ( "HD060=@HD060," );
            strSql . Append ( "HD062=@HD062," );
            strSql . Append ( "HD064=@HD064," );
            strSql . Append ( "HD066=@HD066," );
            strSql . Append ( "HD068=@HD068," );
            strSql . Append ( "HD070=@HD070," );
            strSql . Append ( "HD072=@HD072 " );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@HD022", SqlDbType.Decimal,5),
                    new SqlParameter("@HD024", SqlDbType.Decimal,5),
                    new SqlParameter("@HD026", SqlDbType.Decimal,5),
                    new SqlParameter("@HD028", SqlDbType.Decimal,5),
                    new SqlParameter("@HD030", SqlDbType.Decimal,5),
                    new SqlParameter("@HD032", SqlDbType.Decimal,5),
                    new SqlParameter("@HD034", SqlDbType.Decimal,5),
                    new SqlParameter("@HD036", SqlDbType.Decimal,5),
                    new SqlParameter("@HD038", SqlDbType.Decimal,5),
                    new SqlParameter("@HD040", SqlDbType.Decimal,5),
                    new SqlParameter("@HD042", SqlDbType.Decimal,5),
                    new SqlParameter("@HD044", SqlDbType.Decimal,5),
                    new SqlParameter("@HD046", SqlDbType.Decimal,5),
                    new SqlParameter("@HD048", SqlDbType.Decimal,5),
                    new SqlParameter("@HD050", SqlDbType.Decimal,5),
                    new SqlParameter("@HD052", SqlDbType.Decimal,5),
                    new SqlParameter("@HD054", SqlDbType.Decimal,5),
                    new SqlParameter("@HD056", SqlDbType.Decimal,5),
                    new SqlParameter("@HD058", SqlDbType.Decimal,5),
                    new SqlParameter("@HD060", SqlDbType.Decimal,5),
                    new SqlParameter("@HD062", SqlDbType.Decimal,5),
                    new SqlParameter("@HD064", SqlDbType.Decimal,5),
                    new SqlParameter("@HD066", SqlDbType.Decimal,5),
                    new SqlParameter("@HD068", SqlDbType.Decimal,5),
                    new SqlParameter("@HD070", SqlDbType.Decimal,5),
                    new SqlParameter("@HD072", SqlDbType.Decimal,5)
            };
            parameters [ 0 ] . Value = model . HD022;
            parameters [ 1 ] . Value = model . HD024;
            parameters [ 2 ] . Value = model . HD026;
            parameters [ 3 ] . Value = model . HD028;
            parameters [ 4 ] . Value = model . HD030;
            parameters [ 5 ] . Value = model . HD032;
            parameters [ 6 ] . Value = model . HD034;
            parameters [ 7 ] . Value = model . HD036;
            parameters [ 8 ] . Value = model . HD038;
            parameters [ 9 ] . Value = model . HD040;
            parameters [ 10 ] . Value = model . HD042;
            parameters [ 11 ] . Value = model . HD044;
            parameters [ 12 ] . Value = model . HD046;
            parameters [ 13 ] . Value = model . HD048;
            parameters [ 14 ] . Value = model . HD050;
            parameters [ 15 ] . Value = model . HD052;
            parameters [ 16 ] . Value = model . HD054;
            parameters [ 17 ] . Value = model . HD056;
            parameters [ 18 ] . Value = model . HD058;
            parameters [ 19 ] . Value = model . HD060;
            parameters [ 20 ] . Value = model . HD062;
            parameters [ 21 ] . Value = model . HD064;
            parameters [ 22 ] . Value = model . HD066;
            parameters [ 23 ] . Value = model . HD068;
            parameters [ 24 ] . Value = model . HD070;
            parameters [ 25 ] . Value = model . HD072;

            SQLString . Add ( strSql ,parameters );
        }

    }
}

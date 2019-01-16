using StudentMgr;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Dao
{
    public class GunQiContractDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableQuery ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql . Append ( "SELECT idx,MZ006,MZ016,MZ017,MZ018,MZ019,MZ020,MZ021,MZ022,MZ023,MZ024,MZ025,MZ026,MZ027,MZ028,MZ032,MZ105,MZ106,MZ107,MZ118,MZ119,MZ120,MZ122,MZ124,MZ125,ISNULL(MZ126,0) MZ126,MZ130 FROM R_PQMZ" );
            strSql . Append ( " WHERE " + strWhere );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 是否存在一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists ( MulaolaoLibrary.GunQiContractLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQMZ" );
            strSql.Append( " WHERE MZ002=@MZ002 AND MZ016=@MZ016 AND MZ018=@MZ018 AND MZ019=@MZ019 AND MZ023=@MZ023 AND MZ032=@MZ032" );
            SqlParameter[] parameter = {
                new SqlParameter("@MZ002",SqlDbType.NVarChar,20),
                new SqlParameter("@MZ016",SqlDbType.NVarChar,20),
                new SqlParameter("@MZ018",SqlDbType.NVarChar,20),
                new SqlParameter("@MZ019",SqlDbType.NVarChar,20),
                new SqlParameter("@MZ023",SqlDbType.NVarChar,20),
                new SqlParameter("@MZ032",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = model.MZ002;
            parameter[1].Value = model.MZ016;
            parameter[2].Value = model.MZ018;
            parameter[3].Value = model.MZ019;
            parameter[4].Value = model.MZ023;
            parameter[5].Value = model.MZ032;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }
        
        /// <summary>
        /// 获取序号
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfSerialNum ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT MAX(CONVERT(INT,MZ125)) MZ125 FROM R_PQMZ WHERE MZ001=@MZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@MZ001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 增肌一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Insert ( MulaolaoLibrary.GunQiContractLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQMZ (" );
            strSql.Append( "MZ001,MZ002,MZ006,MZ016,MZ017,MZ018,MZ019,MZ020,MZ021,MZ022,MZ023,MZ024,MZ025,MZ026,MZ027,MZ028,MZ031,MZ032,MZ105,MZ106,MZ107,MZ108,MZ118,MZ119,MZ120,MZ122,MZ124,MZ125,MZ126,MZ130)" );
            strSql.Append( " VALUES (" );
            strSql . AppendFormat ( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}')" ,model . MZ001 ,model . MZ002 ,model . MZ006 ,model . MZ016 ,model . MZ017 ,model . MZ018 ,model . MZ019 ,model . MZ020 ,model . MZ021 ,model . MZ022 ,model . MZ023 ,model . MZ024 ,model . MZ025 ,model . MZ026 ,model . MZ027 ,model . MZ028 ,model . MZ031 ,model . MZ032 ,model . MZ105 ,model . MZ106 ,model . MZ107 ,model . MZ108 ,model . MZ118 ,model . MZ119 ,model . MZ120 ,model . MZ122 ,model . MZ124 ,model . MZ125 ,model . MZ126 ,model . MZ130 );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.MZ001 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 编辑一条
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary . GunQiContractLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQMZ SET " );
            strSql . AppendFormat ( "MZ002='{0}'," ,model . MZ002 );
            strSql . AppendFormat ( "MZ006='{0}'," ,model . MZ006 );
            strSql . AppendFormat ( "MZ016='{0}'," ,model . MZ016 );
            strSql . AppendFormat ( "MZ017='{0}'," ,model . MZ017 );
            strSql . AppendFormat ( "MZ018='{0}'," ,model . MZ018 );
            strSql . AppendFormat ( "MZ019='{0}'," ,model . MZ019 );
            strSql . AppendFormat ( "MZ020='{0}'," ,model . MZ020 );
            strSql . AppendFormat ( "MZ021='{0}'," ,model . MZ021 );
            strSql . AppendFormat ( "MZ022='{0}'," ,model . MZ022 );
            strSql . AppendFormat ( "MZ023='{0}'," ,model . MZ023 );
            strSql . AppendFormat ( "MZ024='{0}'," ,model . MZ024 );
            strSql . AppendFormat ( "MZ025='{0}'," ,model . MZ025 );
            strSql . AppendFormat ( "MZ026='{0}'," ,model . MZ026 );
            strSql . AppendFormat ( "MZ027='{0}'," ,model . MZ027 );
            strSql . AppendFormat ( "MZ028='{0}'," ,model . MZ028 );
            strSql . AppendFormat ( "MZ032='{0}'," ,model . MZ032 );
            strSql . AppendFormat ( "MZ105='{0}'," ,model . MZ105 );
            strSql . AppendFormat ( "MZ106='{0}'," ,model . MZ106 );
            strSql . AppendFormat ( "MZ107='{0}'," ,model . MZ107 );
            strSql . AppendFormat ( "MZ118='{0}'," ,model . MZ118 );
            strSql . AppendFormat ( "MZ119='{0}'," ,model . MZ119 );
            strSql . AppendFormat ( "MZ120='{0}'," ,model . MZ120 );
            strSql . AppendFormat ( "MZ122='{0}'," ,model . MZ122 );
            strSql . AppendFormat ( "MZ124='{0}'," ,model . MZ124 );
            strSql . AppendFormat ( "MZ126='{0}'," ,model . MZ126 );
            strSql . AppendFormat ( "MZ130='{0}' " ,model . MZ130 );
            strSql . AppendFormat ( " WHERE MZ001='{0}' AND MZ125='{1}'" ,model . MZ001 ,model . MZ125 );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( tableNum ,tableName ,logins ,dtOne ,model . MZ001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper . ExecuteSqlTran ( SQLString );

        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( string serialNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd ,string oddNum )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQMZ" );
            strSql.AppendFormat( " WHERE MZ001='{0}' AND MZ125='{1}'" ,oddNum ,serialNum );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.GunQiContractLibrary GetModel ( string serialNum,string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQMZ" );
            strSql.Append( " WHERE MZ001=@MZ001 AND MZ125=@MZ125" );
            SqlParameter[] parameter = {
                new SqlParameter("@MZ001",SqlDbType.NVarChar,20),
                new SqlParameter("@MZ125",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;
            parameter[1].Value = serialNum;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da.Rows.Count > 0 )
                return GetDataRow( da.Rows[0] );
            else
                return null;
        }
        public MulaolaoLibrary.GunQiContractLibrary GetModel ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQMZ" );
            strSql.Append( " WHERE MZ001=@MZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@MZ001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da.Rows.Count > 0 )
                return GetDataRow( da.Rows[0] );
            else
                return null;
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.GunQiContractLibrary GetDataRow ( DataRow row )
        {
            MulaolaoLibrary.GunQiContractLibrary model = new MulaolaoLibrary.GunQiContractLibrary( );
            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    model.IDX = int.Parse( row["idx"].ToString( ) );
                if ( row["MZ001"] != null && row["MZ001"].ToString( ) != "" )
                    model.MZ001 = row["MZ001"].ToString( );
                if ( row["MZ002"] != null && row["MZ002"].ToString( ) != "" )
                    model.MZ002 = row["MZ002"].ToString( );
                if ( row["MZ003"] != null && row["MZ003"].ToString( ) != "" )
                    model.MZ003 = row["MZ003"].ToString( );
                if ( row["MZ004"] != null && row["MZ004"].ToString( ) != "" )
                    model.MZ004 = row["MZ004"].ToString( );
                if ( row["MZ005"] != null && row["MZ005"].ToString( ) != "" )
                    model.MZ005 = row["MZ005"].ToString( );
                if ( row["MZ006"] != null && row["MZ006"].ToString( ) != "" )
                    model.MZ006 = long.Parse( row["MZ006"].ToString( ) );
                if ( row["MZ007"] != null && row["MZ007"].ToString( ) != "" )
                    model.MZ007 = DateTime.Parse( row["MZ007"].ToString( ) );
                if ( row["MZ008"] != null && row["MZ008"].ToString( ) != "" )
                    model.MZ008 = DateTime.Parse( row["MZ008"].ToString( ) );
                if ( row["MZ009"] != null && row["MZ009"].ToString( ) != "" )
                    model.MZ009 = row["MZ009"].ToString( );
                if ( row["MZ010"] != null && row["MZ010"].ToString( ) != "" )
                    model.MZ010 = DateTime.Parse( row["MZ010"].ToString( ) );
                if ( row["MZ011"] != null && row["MZ011"].ToString( ) != "" )
                    model.MZ011 = row["MZ011"].ToString( );
                if ( row["MZ012"] != null && row["MZ012"].ToString( ) != "" )
                    model.MZ012 = DateTime.Parse( row["MZ012"].ToString( ) );
                if ( row["MZ013"] != null && row["MZ013"].ToString( ) != "" )
                    model.MZ013 = row["MZ013"].ToString( );
                if ( row["MZ014"] != null && row["MZ014"].ToString( ) != "" )
                    model.MZ014 = row["MZ014"].ToString( );
                if ( row["MZ015"] != null && row["MZ015"].ToString( ) != "" )
                    model.MZ015 = DateTime.Parse( row["MZ015"].ToString( ) );
                if ( row["MZ016"] != null && row["MZ016"].ToString( ) != "" )
                    model.MZ016 = row["MZ016"].ToString( );
                if ( row["MZ017"] != null && row["MZ017"].ToString( ) != "" )
                    model.MZ017 = row["MZ017"].ToString( );
                if ( row["MZ018"] != null && row["MZ018"].ToString( ) != "" )
                    model.MZ018 = row["MZ018"].ToString( );
                if ( row["MZ019"] != null && row["MZ019"].ToString( ) != "" )
                    model.MZ019 = row["MZ019"].ToString( );
                if ( row["MZ020"] != null && row["MZ020"].ToString( ) != "" )
                    model.MZ020 = decimal.Parse( row["MZ020"].ToString( ) );
                if ( row["MZ021"] != null && row["MZ021"].ToString( ) != "" )
                    model.MZ021 = int.Parse( row["MZ021"].ToString( ) );
                if ( row["MZ022"] != null && row["MZ022"].ToString( ) != "" )
                    model.MZ022 = decimal.Parse( row["MZ022"].ToString( ) );
                if ( row["MZ023"] != null && row["MZ023"].ToString( ) != "" )
                    model.MZ023 = row["MZ023"].ToString( );
                if ( row["MZ024"] != null && row["MZ024"].ToString( ) != "" )
                    model.MZ024 = int.Parse( row["MZ024"].ToString( ) );
                if ( row["MZ025"] != null && row["MZ025"].ToString( ) != "" )
                    model.MZ025 = decimal.Parse( row["MZ025"].ToString( ) );
                if ( row["MZ026"] != null && row["MZ026"].ToString( ) != "" )
                    model.MZ026 = decimal.Parse( row["MZ026"].ToString( ) );
                if ( row["MZ027"] != null && row["MZ027"].ToString( ) != "" )
                    model.MZ027 = decimal.Parse( row["MZ027"].ToString( ) );
                if ( row["MZ028"] != null && row["MZ028"].ToString( ) != "" )
                    model.MZ028 = decimal.Parse( row["MZ028"].ToString( ) );
                if ( row["MZ029"] != null && row["MZ029"].ToString( ) != "" )
                    model.MZ029 = row["MZ029"].ToString( );
                if ( row["MZ030"] != null && row["MZ030"].ToString( ) != "" )
                    model.MZ030 = row["MZ030"].ToString( );
                if ( row["MZ031"] != null && row["MZ031"].ToString( ) != "" )
                    model.MZ031 = row["MZ031"].ToString( );
                if ( row["MZ032"] != null && row["MZ032"].ToString( ) != "" )
                    model.MZ032 = row["MZ032"].ToString( );
                if ( row["MZ033"] != null && row["MZ033"].ToString( ) != "" )
                    model.MZ033 = row["MZ033"].ToString( );
                if ( row["MZ034"] != null && row["MZ034"].ToString( ) != "" )
                    model.MZ034 = row["MZ034"].ToString( );
                if ( row["MZ035"] != null && row["MZ035"].ToString( ) != "" )
                    model.MZ035 = row["MZ035"].ToString( );
                if ( row["MZ036"] != null && row["MZ036"].ToString( ) != "" )
                    model.MZ036 = row["MZ036"].ToString( );
                if ( row["MZ037"] != null && row["MZ037"].ToString( ) != "" )
                    model.MZ037 = row["MZ037"].ToString( );
                if ( row["MZ038"] != null && row["MZ038"].ToString( ) != "" )
                    model.MZ038 = row["MZ038"].ToString( );
                if ( row["MZ039"] != null && row["MZ039"].ToString( ) != "" )
                    model.MZ039 = row["MZ039"].ToString( );
                if ( row["MZ040"] != null && row["MZ040"].ToString( ) != "" )
                    model.MZ040 = row["MZ040"].ToString( );
                if ( row["MZ041"] != null && row["MZ041"].ToString( ) != "" )
                    model.MZ041 = DateTime.Parse( row["MZ041"].ToString( ) );
                if ( row["MZ042"] != null && row["MZ042"].ToString( ) != "" )
                    model.MZ042 = row["MZ042"].ToString( );
                if ( row["MZ043"] != null && row["MZ043"].ToString( ) != "" )
                    model.MZ043 = DateTime.Parse( row["MZ043"].ToString( ) );
                if ( row["MZ044"] != null && row["MZ044"].ToString( ) != "" )
                    model.MZ044 = row["MZ044"].ToString( );
                if ( row["MZ045"] != null && row["MZ045"].ToString( ) != "" )
                    model.MZ045 = row["MZ045"].ToString( );
                if ( row["MZ046"] != null && row["MZ046"].ToString( ) != "" )
                    model.MZ046 = row["MZ046"].ToString( );
                if ( row["MZ047"] != null && row["MZ047"].ToString( ) != "" )
                    model.MZ047 = row["MZ047"].ToString( );
                if ( row["MZ048"] != null && row["MZ048"].ToString( ) != "" )
                    model.MZ048 = row["MZ048"].ToString( );
                if ( row["MZ049"] != null && row["MZ049"].ToString( ) != "" )
                    model.MZ049 = row["MZ049"].ToString( );
                if ( row["MZ050"] != null && row["MZ050"].ToString( ) != "" )
                    model.MZ050 = row["MZ050"].ToString( );
                if ( row["MZ051"] != null && row["MZ051"].ToString( ) != "" )
                    model.MZ051 = row["MZ051"].ToString( );
                if ( row["MZ052"] != null && row["MZ052"].ToString( ) != "" )
                    model.MZ052 = row["MZ052"].ToString( );
                if ( row["MZ053"] != null && row["MZ053"].ToString( ) != "" )
                    model.MZ053 = row["MZ053"].ToString( );
                if ( row["MZ054"] != null && row["MZ054"].ToString( ) != "" )
                    model.MZ054 = row["MZ054"].ToString( );
                if ( row["MZ055"] != null && row["MZ055"].ToString( ) != "" )
                    model.MZ055 = row["MZ055"].ToString( );
                if ( row["MZ056"] != null && row["MZ056"].ToString( ) != "" )
                    model.MZ056 = row["MZ056"].ToString( );
                if ( row["MZ057"] != null && row["MZ057"].ToString( ) != "" )
                    model.MZ057 = row["MZ057"].ToString( );
                if ( row["MZ058"] != null && row["MZ058"].ToString( ) != "" )
                    model.MZ058 = row["MZ058"].ToString( );
                if ( row["MZ059"] != null && row["MZ059"].ToString( ) != "" )
                    model.MZ059 = row["MZ059"].ToString( );
                if ( row["MZ060"] != null && row["MZ060"].ToString( ) != "" )
                    model.MZ060 = row["MZ060"].ToString( );
                if ( row["MZ061"] != null && row["MZ061"].ToString( ) != "" )
                    model.MZ061 = row["MZ061"].ToString( );
                if ( row["MZ062"] != null && row["MZ062"].ToString( ) != "" )
                    model.MZ062 = DateTime.Parse( row["MZ062"].ToString( ) );
                if ( row["MZ063"] != null && row["MZ063"].ToString( ) != "" )
                    model.MZ063 = row["MZ063"].ToString( );
                if ( row["MZ064"] != null && row["MZ064"].ToString( ) != "" )
                    model.MZ064 = row["MZ064"].ToString( );
                if ( row["MZ065"] != null && row["MZ065"].ToString( ) != "" )
                    model.MZ065 = row["MZ065"].ToString( );
                if ( row["MZ066"] != null && row["MZ066"].ToString( ) != "" )
                    model.MZ066 = row["MZ066"].ToString( );
                if ( row["MZ067"] != null && row["MZ067"].ToString( ) != "" )
                    model.MZ067 = row["MZ067"].ToString( );
                if ( row["MZ068"] != null && row["MZ068"].ToString( ) != "" )
                    model.MZ068 = row["MZ068"].ToString( );
                if ( row["MZ069"] != null && row["MZ069"].ToString( ) != "" )
                    model.MZ069 = row["MZ069"].ToString( );
                if ( row["MZ070"] != null && row["MZ070"].ToString( ) != "" )
                    model.MZ070 = row["MZ070"].ToString( );
                if ( row["MZ071"] != null && row["MZ071"].ToString( ) != "" )
                    model.MZ071 = row["MZ071"].ToString( );
                if ( row["MZ072"] != null && row["MZ072"].ToString( ) != "" )
                    model.MZ072 = row["MZ072"].ToString( );
                if ( row["MZ073"] != null && row["MZ073"].ToString( ) != "" )
                    model.MZ073 = row["MZ073"].ToString( );
                if ( row["MZ074"] != null && row["MZ074"].ToString( ) != "" )
                    model.MZ074 = row["MZ074"].ToString( );
                if ( row["MZ075"] != null && row["MZ075"].ToString( ) != "" )
                    model.MZ075 = row["MZ075"].ToString( );
                if ( row["MZ076"] != null && row["MZ076"].ToString( ) != "" )
                    model.MZ076 = row["MZ076"].ToString( );
                if ( row["MZ077"] != null && row["MZ077"].ToString( ) != "" )
                    model.MZ077 = row["MZ077"].ToString( );
                if ( row["MZ078"] != null && row["MZ078"].ToString( ) != "" )
                    model.MZ078 = row["MZ078"].ToString( );
                if ( row["MZ079"] != null && row["MZ079"].ToString( ) != "" )
                    model.MZ079 = row["MZ079"].ToString( );
                if ( row["MZ080"] != null && row["MZ080"].ToString( ) != "" )
                    model.MZ080 = row["MZ080"].ToString( );
                if ( row["MZ081"] != null && row["MZ081"].ToString( ) != "" )
                    model.MZ081 = row["MZ081"].ToString( );
                if ( row["MZ082"] != null && row["MZ082"].ToString( ) != "" )
                    model.MZ082 = row["MZ082"].ToString( );
                if ( row["MZ083"] != null && row["MZ083"].ToString( ) != "" )
                    model.MZ083 = row["MZ083"].ToString( );
                if ( row["MZ084"] != null && row["MZ084"].ToString( ) != "" )
                    model.MZ084 = row["MZ084"].ToString( );
                if ( row["MZ085"] != null && row["MZ085"].ToString( ) != "" )
                    model.MZ085 = row["MZ085"].ToString( );
                if ( row["MZ086"] != null && row["MZ086"].ToString( ) != "" )
                    model.MZ086 = row["MZ086"].ToString( );
                if ( row["MZ087"] != null && row["MZ087"].ToString( ) != "" )
                    model.MZ087 = row["MZ087"].ToString( );
                if ( row["MZ088"] != null && row["MZ088"].ToString( ) != "" )
                    model.MZ088 = row["MZ088"].ToString( );
                if ( row["MZ089"] != null && row["MZ089"].ToString( ) != "" )
                    model.MZ089 = row["MZ089"].ToString( );
                if ( row["MZ090"] != null && row["MZ090"].ToString( ) != "" )
                    model.MZ090 = DateTime.Parse( row["MZ090"].ToString( ) );
                if ( row["MZ091"] != null && row["MZ091"].ToString( ) != "" )
                    model.MZ091 = int.Parse( row["MZ091"].ToString( ) );
                if ( row["MZ092"] != null && row["MZ092"].ToString( ) != "" )
                    model.MZ092 = row["MZ092"].ToString( );
                if ( row["MZ093"] != null && row["MZ093"].ToString( ) != "" )
                    model.MZ093 = row["MZ093"].ToString( );
                if ( row["MZ094"] != null && row["MZ094"].ToString( ) != "" )
                    model.MZ094 = DateTime.Parse( row["MZ094"].ToString( ) );
                if ( row["MZ095"] != null && row["MZ095"].ToString( ) != "" )
                    model.MZ095 = int.Parse( row["MZ095"].ToString( ) );
                if ( row["MZ096"] != null && row["MZ096"].ToString( ) != "" )
                    model.MZ096 = int.Parse( row["MZ096"].ToString( ) );
                if ( row["MZ097"] != null && row["MZ097"].ToString( ) != "" )
                    model.MZ097 = int.Parse( row["MZ097"].ToString( ) );
                if ( row["MZ098"] != null && row["MZ098"].ToString( ) != "" )
                    model.MZ098 = int.Parse( row["MZ098"].ToString( ) );
                if ( row["MZ099"] != null && row["MZ099"].ToString( ) != "" )
                    model.MZ099 = int.Parse( row["MZ099"].ToString( ) );
                if ( row["MZ100"] != null && row["MZ100"].ToString( ) != "" )
                    model.MZ100 = int.Parse( row["MZ100"].ToString( ) );
                if ( row["MZ101"] != null && row["MZ101"].ToString( ) != "" )
                    model.MZ101 = int.Parse( row["MZ101"].ToString( ) );
                if ( row["MZ102"] != null && row["MZ102"].ToString( ) != "" )
                    model.MZ102 = int.Parse( row["MZ102"].ToString( ) );
                if ( row["MZ103"] != null && row["MZ103"].ToString( ) != "" )
                    model.MZ103 = int.Parse( row["MZ103"].ToString( ) );
                if ( row["MZ104"] != null && row["MZ104"].ToString( ) != "" )
                    model.MZ104 = row["MZ104"].ToString( );
                if ( row["MZ105"] != null && row["MZ105"].ToString( ) != "" )
                    model.MZ105 = decimal.Parse( row["MZ105"].ToString( ) );
                if ( row["MZ106"] != null && row["MZ106"].ToString( ) != "" )
                    model.MZ106 = row["MZ106"].ToString( );
                if ( row["MZ107"] != null && row["MZ107"].ToString( ) != "" )
                    model.MZ107 = row["MZ107"].ToString( );
                if ( row["MZ108"] != null && row["MZ108"].ToString( ) != "" )
                    model.MZ108 = row["MZ108"].ToString( );
                if ( row["MZ109"] != null && row["MZ109"].ToString( ) != "" )
                    model.MZ109 = row["MZ109"].ToString( );
                if ( row["MZ110"] != null && row["MZ110"].ToString( ) != "" )
                    model.MZ110 = row["MZ110"].ToString( );
                if ( row["MZ111"] != null && row["MZ111"].ToString( ) != "" )
                    model.MZ111 = row["MZ111"].ToString( );
                if ( row["MZ112"] != null && row["MZ112"].ToString( ) != "" )
                    model.MZ112 = row["MZ112"].ToString( );
                if ( row["MZ113"] != null && row["MZ113"].ToString( ) != "" )
                    model.MZ113 = row["MZ113"].ToString( );
                if ( row["MZ114"] != null && row["MZ114"].ToString( ) != "" )
                    model.MZ114 = row["MZ114"].ToString( );
                if ( row["MZ115"] != null && row["MZ115"].ToString( ) != "" )
                    model.MZ115 = row["MZ115"].ToString( );
                if ( row["MZ116"] != null && row["MZ116"].ToString( ) != "" )
                    model.MZ116 = row["MZ116"].ToString( );
                if ( row["MZ117"] != null && row["MZ117"].ToString( ) != "" )
                    model.MZ117 = row["MZ117"].ToString( );
                if ( row["MZ118"] != null && row["MZ118"].ToString( ) != "" )
                    model.MZ118 = int.Parse( row["MZ118"].ToString( ) );
                if ( row["MZ119"] != null && row["MZ119"].ToString( ) != "" )
                    model.MZ119 = int.Parse( row["MZ119"].ToString( ) );
                if ( row["MZ120"] != null && row["MZ120"].ToString( ) != "" )
                    model.MZ120 = int.Parse( row["MZ120"].ToString( ) );
                if ( row["MZ123"] != null && row["MZ123"].ToString( ) != "" )
                    model.MZ123 = row["MZ123"].ToString( );
                if ( row["MZ124"] != null && row["MZ124"].ToString( ) != "" )
                    model.MZ124 = row["MZ124"].ToString( );
                if ( row["MZ125"] != null && row["MZ125"].ToString( ) != "" )
                    model.MZ125 = row["MZ125"].ToString( );
                if ( row [ "MZ126" ] != null && row [ "MZ126" ] . ToString ( ) != "" )
                    model . MZ126 = decimal . Parse ( row [ "MZ126" ] . ToString ( ) );
                if ( row [ "MZ130" ] != null && row [ "MZ130" ] . ToString ( ) != "" )
                    model . MZ130 = row [ "MZ130" ] . ToString ( );
            }
            return model;
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DeleteAll ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQMZ" );
            strSql.AppendFormat( " WHERE MZ001='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            StringBuilder strS = new StringBuilder( );
            strS.Append( "DELETE FROM R_REVIEWS" );
            strS.AppendFormat( " WHERE RES06='{0}'" ,oddNum );
            SQLString.Add( strS.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 更改记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateAll ( MulaolaoLibrary.GunQiContractLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQMZ SET " );
            strSql.AppendFormat( "MZ002='{0}'," ,model.MZ002 );
            strSql.AppendFormat( "MZ003='{0}'," ,model.MZ003 );
            strSql.AppendFormat( "MZ004='{0}'," ,model.MZ004 );
            strSql.AppendFormat( "MZ005='{0}'," ,model.MZ005 );
            strSql.AppendFormat( "MZ006='{0}'," ,model.MZ006 );
            strSql.AppendFormat( "MZ007='{0}'," ,model.MZ007 );
            strSql.AppendFormat( "MZ008='{0}'," ,model.MZ008 );
            strSql.AppendFormat( "MZ009='{0}'," ,model.MZ009 );
            strSql.AppendFormat( "MZ010='{0}'," ,model.MZ010 );
            strSql.AppendFormat( "MZ011='{0}'," ,model.MZ011 );
            strSql.AppendFormat( "MZ012='{0}'," ,model.MZ012 );
            strSql.AppendFormat( "MZ013='{0}'," ,model.MZ013 );
            strSql.AppendFormat( "MZ014='{0}'," ,model.MZ014 );
            strSql.AppendFormat( "MZ015='{0}'," ,model.MZ015 );
            strSql.AppendFormat( "MZ029='{0}'," ,model.MZ029 );
            strSql.AppendFormat( "MZ030='{0}'," ,model.MZ030 );
            strSql.AppendFormat( "MZ031='{0}'," ,model.MZ031 );
            strSql.AppendFormat( "MZ033='{0}'," ,model.MZ033 );
            strSql.AppendFormat( "MZ034='{0}'," ,model.MZ034 );
            strSql.AppendFormat( "MZ035='{0}'," ,model.MZ035 );
            strSql.AppendFormat( "MZ036='{0}'," ,model.MZ036 );
            strSql.AppendFormat( "MZ037='{0}'," ,model.MZ037 );
            strSql.AppendFormat( "MZ038='{0}'," ,model.MZ038 );
            strSql.AppendFormat( "MZ039='{0}'," ,model.MZ039 );
            strSql.AppendFormat( "MZ040='{0}'," ,model.MZ040 );
            strSql.AppendFormat( "MZ041='{0}'," ,model.MZ041 );
            strSql.AppendFormat( "MZ042='{0}'," ,model.MZ042 );
            strSql.AppendFormat( "MZ043='{0}'," ,model.MZ043 );
            strSql.AppendFormat( "MZ044='{0}'," ,model.MZ044 );
            strSql.AppendFormat( "MZ045='{0}'," ,model.MZ045 );
            strSql.AppendFormat( "MZ046='{0}'," ,model.MZ046 );
            strSql.AppendFormat( "MZ047='{0}'," ,model.MZ047 );
            strSql.AppendFormat( "MZ048='{0}'," ,model.MZ048 );
            strSql.AppendFormat( "MZ049='{0}'," ,model.MZ049 );
            strSql.AppendFormat( "MZ050='{0}'," ,model.MZ050 );
            strSql.AppendFormat( "MZ051='{0}'," ,model.MZ051 );
            strSql.AppendFormat( "MZ052='{0}'," ,model.MZ052 );
            strSql.AppendFormat( "MZ053='{0}'," ,model.MZ053 );
            strSql.AppendFormat( "MZ054='{0}'," ,model.MZ054 );
            strSql.AppendFormat( "MZ055='{0}'," ,model.MZ055 );
            strSql.AppendFormat( "MZ056='{0}'," ,model.MZ056 );
            strSql.AppendFormat( "MZ057='{0}'," ,model.MZ057 );
            strSql.AppendFormat( "MZ058='{0}'," ,model.MZ058 );
            strSql.AppendFormat( "MZ059='{0}'," ,model.MZ059 );
            strSql.AppendFormat( "MZ060='{0}'," ,model.MZ060 );
            strSql.AppendFormat( "MZ061='{0}'," ,model.MZ061 );
            strSql.AppendFormat( "MZ062='{0}'," ,model.MZ062 );
            strSql.AppendFormat( "MZ063='{0}'," ,model.MZ063 );
            strSql.AppendFormat( "MZ064='{0}'," ,model.MZ064 );
            strSql.AppendFormat( "MZ065='{0}'," ,model.MZ065 );
            strSql.AppendFormat( "MZ066='{0}'," ,model.MZ066 );
            strSql.AppendFormat( "MZ067='{0}'," ,model.MZ067 );
            strSql.AppendFormat( "MZ068='{0}'," ,model.MZ068 );
            strSql.AppendFormat( "MZ069='{0}'," ,model.MZ069 );
            strSql.AppendFormat( "MZ070='{0}'," ,model.MZ070 );
            strSql.AppendFormat( "MZ071='{0}'," ,model.MZ071 );
            strSql.AppendFormat( "MZ072='{0}'," ,model.MZ072 );
            strSql.AppendFormat( "MZ073='{0}'," ,model.MZ073 );
            strSql.AppendFormat( "MZ074='{0}'," ,model.MZ074 );
            strSql.AppendFormat( "MZ075='{0}'," ,model.MZ075 );
            strSql.AppendFormat( "MZ076='{0}'," ,model.MZ076 );
            strSql.AppendFormat( "MZ077='{0}'," ,model.MZ077 );
            strSql.AppendFormat( "MZ078='{0}'," ,model.MZ078 );
            strSql.AppendFormat( "MZ079='{0}'," ,model.MZ079 );
            strSql.AppendFormat( "MZ080='{0}'," ,model.MZ080 );
            strSql.AppendFormat( "MZ081='{0}'," ,model.MZ081 );
            strSql.AppendFormat( "MZ082='{0}'," ,model.MZ082 );
            strSql.AppendFormat( "MZ083='{0}'," ,model.MZ083 );
            strSql.AppendFormat( "MZ084='{0}'," ,model.MZ084 );
            strSql.AppendFormat( "MZ085='{0}'," ,model.MZ085 );
            strSql.AppendFormat( "MZ086='{0}'," ,model.MZ086 );
            strSql.AppendFormat( "MZ087='{0}'," ,model.MZ087 );
            strSql.AppendFormat( "MZ088='{0}'," ,model.MZ088 );
            strSql.AppendFormat( "MZ089='{0}'," ,model.MZ089 );
            strSql.AppendFormat( "MZ090='{0}'," ,model.MZ090 );
            strSql.AppendFormat( "MZ091='{0}'," ,model.MZ091 );
            strSql.AppendFormat( "MZ092='{0}'," ,model.MZ092 );
            strSql.AppendFormat( "MZ093='{0}'," ,model.MZ093 );
            strSql.AppendFormat( "MZ094='{0}'," ,model.MZ094 );
            strSql.AppendFormat( "MZ095='{0}'," ,model.MZ095 );
            strSql.AppendFormat( "MZ096='{0}'," ,model.MZ096 );
            strSql.AppendFormat( "MZ097='{0}'," ,model.MZ097 );
            strSql.AppendFormat( "MZ098='{0}'," ,model.MZ098 );
            strSql.AppendFormat( "MZ099='{0}'," ,model.MZ099 );
            strSql.AppendFormat( "MZ100='{0}'," ,model.MZ100 );
            strSql.AppendFormat( "MZ101='{0}'," ,model.MZ101 );
            strSql.AppendFormat( "MZ102='{0}'," ,model.MZ102 );
            strSql.AppendFormat( "MZ103='{0}'," ,model.MZ103 );
            strSql.AppendFormat( "MZ104='{0}'," ,model.MZ104 );
            strSql.AppendFormat( "MZ108='{0}'," ,model.MZ108 );
            strSql.AppendFormat( "MZ123='{0}'" ,model.MZ123 );
            strSql.AppendFormat( " WHERE MZ001='{0}'" ,model.MZ001 );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.MZ001 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableMain ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT MZ030 FROM R_PQMZ" );
            strSql.Append( " WHERE MZ001=@MZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@MZ001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTableWeiHu ( string oddNum ,string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT MZ016,MZ018,MZ019,MZ023 FROM R_PQMZ" );
            strSql.Append( " WHERE MZ001!=@MZ001 AND MZ002=@MZ002" );
            SqlParameter[] parameter = {
                new SqlParameter("@MZ001",SqlDbType.NVarChar,20),
                new SqlParameter("@MZ002",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;
            parameter[1].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 复制一条记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Copy ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQMZ (" );
            strSql.Append( "MZ002,MZ003,MZ004,MZ005,MZ006,MZ016,MZ017,MZ018,MZ019,MZ020,MZ021,MZ022,MZ023,MZ024,MZ025,MZ026,MZ027,MZ028,MZ032,MZ033,MZ034,MZ035,MZ036,MZ037,MZ038,MZ039,MZ040,MZ042,MZ044,MZ045,MZ046,MZ047,MZ048,MZ049,MZ050,MZ051,MZ052,MZ053,MZ054,MZ055,MZ056,MZ057,MZ058,MZ059,MZ060,MZ061,MZ063,MZ064,MZ065,MZ066,MZ067,MZ068,MZ069,MZ070,MZ071,MZ072,MZ073,MZ074,MZ075,MZ076,MZ077,MZ078,MZ079,MZ080,MZ081,MZ082,MZ083,MZ084,MZ085,MZ086,MZ087,MZ088,MZ089,MZ091,MZ092,MZ093,MZ095,MZ096,MZ097,MZ098,MZ099,MZ100,MZ101,MZ102,MZ103,MZ104,MZ105,MZ106,MZ107,MZ108,MZ109,MZ110,MZ111,MZ112,MZ113,MZ114,MZ115,MZ116,MZ117,MZ118,MZ119,MZ120,MZ124,MZ125,MZ126)" );
            strSql.Append( " SELECT MZ002,MZ003,MZ004,MZ005,MZ006,MZ016,MZ017,MZ018,MZ019,MZ020,MZ021,MZ022,MZ023,MZ024,MZ025,MZ026,MZ027,MZ028,MZ032,MZ033,MZ034,MZ035,MZ036,MZ037,MZ038,MZ039,MZ040,MZ042,MZ044,MZ045,MZ046,MZ047,MZ048,MZ049,MZ050,MZ051,MZ052,MZ053,MZ054,MZ055,MZ056,MZ057,MZ058,MZ059,MZ060,MZ061,MZ063,MZ064,MZ065,MZ066,MZ067,MZ068,MZ069,MZ070,MZ071,MZ072,MZ073,MZ074,MZ075,MZ076,MZ077,MZ078,MZ079,MZ080,MZ081,MZ082,MZ083,MZ084,MZ085,MZ086,MZ087,MZ088,MZ089,MZ091,MZ092,MZ093,MZ095,MZ096,MZ097,MZ098,MZ099,MZ100,MZ101,MZ102,MZ103,MZ104,MZ105,MZ106,MZ107,MZ108,MZ109,MZ110,MZ111,MZ112,MZ113,MZ114,MZ115,MZ116,MZ117,MZ118,MZ119,MZ120,MZ124,MZ125,MZ126 FROM R_PQMZ" );
            strSql.AppendFormat( " WHERE MZ001='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        
        /// <summary>
        /// 更改复制记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateCopy ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQMZ SET " );
            strSql.AppendFormat( "MZ001='{0}'" ,oddNum );
            strSql.Append( " WHERE MZ001 IS NULL" );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 删除复制记录
        /// </summary>
        /// <returns></returns>
        public bool DeleteCopy ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQMZ WHERE MZ001 IS NULL" );

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取零件名称
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable DataTablePart ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQLZ A INNER JOIN R_REVIEWS B ON A.LZ001=B.RES06 AND RES05='执行'" );
            strSql.Append( "WHERE LZ002=@LZ002 AND NOT EXISTS (SELECT 1 FROM R_PQMZ WHERE LZ002=MZ002 AND LZ015=MZ016 AND LZ016=MZ017 AND LZ017=MZ018 AND LZ018=MZ019 AND LZ019=MZ023)" );
            SqlParameter[] parameter = {
                new SqlParameter("@LZ002",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT MZ001,MZ002,MZ003,MZ004,MZ005,MZ019 FROM R_PQMZ" );

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
            strSql.Append( "SELECT COUNT(1) FROM ( SELECT DISTINCT MZ001,MZ002,MZ003,MZ004,MZ005,MZ006,MZ107,MZ014 FROM R_PQMZ" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") A" );

            object obj = SqlHelper.GetSingle( strSql.ToString( ) );
            if ( obj == null )
                return 0;
            else
                return Convert.ToInt32( obj );
        }
        public int GetCounts ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM (SELECT A.idx,MZ001,MZ002,MZ003,MZ004,MZ005,MZ006 FROM R_PQMZ A,R_REVIEWS B WHERE A.MZ001=B.RES06 AND RES05='执行'" );
            strSql.Append( " AND " + strWhere );
            strSql.Append( ") A" );

            object obj = SqlHelper.GetSingle( strSql.ToString( ) );
            if ( obj == null )
                return 0;
            else
                return Convert.ToInt32( obj );
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTableByPage ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT MZ001,MZ002,MZ003,MZ004,MZ005,MZ006,MZ031,DGA003,MZ014,SUM(MZ0) MZ0,SUM(MZ1) MZ1,SUM(MZ2) MZ2,RES05,MZ121,MZ107,AD08,MZ026,MZ027,MZ028,MZ129 FROM (SELECT MZ001,DGA003,MZ002,MZ003,MZ004,MZ005,MZ006,MZ019,MZ014,MZ031,CASE WHEN MZ121='F' OR MZ121='' OR MZ121 IS NULL THEN '待入' ELSE '已入' END MZ121,MZ022*MZ006*MZ028*MZ024+ISNULL(MZ120,0) MZ0,MZ022*MZ006*MZ027+ISNULL(MZ118,0) MZ2,MZ022*MZ006*MZ026*MZ024+ISNULL(MZ119,0) MZ1,MZ107,(SELECT RES05 FROM R_REVIEWS WHERE RES04=(SELECT MAX(RES04) FROM R_REVIEWS WHERE MZ001=RES06)) RES05,CASE WHEN AD17='' OR AD17 IS NULL THEN '未出' ELSE '已出' END AD08,MZ026,MZ027,MZ028,MZ129 FROM (" );
            strSql.Append( "SELECT ROW_NUMBER() OVER( " );
            strSql.Append( "ORDER BY T.MZ001 DESC" );
            strSql.Append( ") AS Row,T.* FROM R_PQMZ T" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") TT LEFT JOIN TPADGA C ON TT.MZ108=C.DGA001 LEFT JOIN (SELECT DISTINCT AD17 FROM R_PQAD) D ON TT.MZ001=AD17" );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );
            strSql . Append ( ") A GROUP BY MZ001,MZ002,MZ003,MZ004,MZ005,MZ006,MZ031,RES05,MZ121,MZ107,DGA003,MZ014,AD08,MZ026,MZ027,MZ028,MZ129 ORDER BY MZ001 DESC" );
            //strSql.Append( " GROUP BY TT.idx,MZ001,MZ002,MZ003,MZ004,MZ005,MZ006,MZ031,MZ121,MZ107,DGA003,MZ019,MZ014,AD08" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableByPages ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,MZ001,MZ002,MZ003,MZ004,MZ005,MZ006,MZ031,DGA003,MZ014,MZ107,SUM(MZ0) MZ0,SUM(MZ1) MZ1,MZ026,MZ027,MZ028,MZ129 FROM (SELECT TT.idx,MZ001,MZ002,MZ003,MZ004,MZ005,MZ006,DGA003,MZ014,RES05,MZ031,MZ107,CASE WHEN MZ107='厂外' THEN SUM(ISNULL(MZ120,0)+MZ022*MZ006*MZ028*MZ024) ELSE 0 END AS MZ0,CASE WHEN MZ107='厂内' THEN SUM(MZ022*MZ006*MZ027+ISNULL(MZ118,0)) ELSE 0 END MZ1,MZ026,MZ027,MZ028,MZ129 FROM (" );
            strSql.Append( "SELECT ROW_NUMBER() OVER( " );
            strSql.Append( "ORDER BY T.MZ001 DESC" );
            strSql.Append( ") AS Row,T.* FROM R_PQMZ T" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") TT,R_REVIEWS A,TPADGA C  WHERE TT.MZ001=A.RES06 AND RES05='执行' AND TT.MZ108=C.DGA001 AND NOT EXISTS (SELECT 1 FROM R_PQAL C,R_PQAK D WHERE TT.idx=C.AL003 AND TT.MZ001=C.AL002 AND C.AL001=D.idx AND (AK009-AK010-AK011-AK015)<=100) " );
            strSql.AppendFormat( " AND TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );
            strSql.Append( "GROUP BY TT.idx,MZ001,MZ002,MZ003,MZ004,MZ005,MZ006,RES05,MZ031,MZ107,DGA003,MZ014,MZ026,MZ027,MZ028,MZ129) A GROUP BY MZ001,MZ002,MZ003,MZ004,MZ005,MZ006,MZ031,MZ107,DGA003,MZ014,idx,MZ026,MZ027,MZ028,MZ129 ORDER BY MZ001 DESC" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrint ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT MZ016,MZ017,MZ105,MZ106,MZ023,MZ019,MZ024,MZ006,CONVERT(DECIMAL(18,0),MZ022*MZ006) MZ0,MZ025,MZ026,CASE WHEN MZ025=0 THEN 0 ELSE CONVERT(DECIMAL(18,2),MZ022*MZ006*MZ026/MZ025) END MZ1,MZ028-(MZ026+MZ027) MZ2,CASE WHEN MZ022*MZ006*MZ028*MZ024=0 THEN 0 ELSE CONVERT(DECIMAL(18,2),1-(MZ022*MZ006)*(MZ027+MZ026*MZ024)/(MZ022*MZ006*MZ028*MZ024)) END MZ3,CASE WHEN MZ006=0 THEN 0 ELSE CONVERT(DECIMAL(18,3),MZ022*MZ026*MZ024) END MZ4,MZ022*MZ006*MZ026*MZ024 MZ5,ISNULL(MZ119,0) MZ119 FROM R_PQMZ" );
            strSql.Append( " WHERE MZ001=@MZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@MZ001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableExport ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT MZ002,MZ003,MZ004,MZ005,MZ006,CONVERT(VARCHAR(20),MZ007,102) MZ007,CONVERT(VARCHAR(20),MZ008,102) MZ008,MZ009,CONVERT(VARCHAR(20),MZ010,102) MZ010,MZ011,CONVERT(VARCHAR(20),MZ012,102) MZ102,MZ013,MZ014 ,MZ033,MZ034,CONVERT(NCHAR(1),MZ035) MZ035,CONVERT(NCHAR(1),MZ036) MZ036,CONVERT(NCHAR(1),MZ037) MZ037,CONVERT(NCHAR(1),MZ038) MZ038,CONVERT(NCHAR(1),MZ039) MZ039,MZ040,CONVERT(VARCHAR(20),MZ041,102) MZ041,MZ042,CONVERT(VARCHAR(20),MZ043,102) MZ043,CASE WHEN MZ044='T' OR MZ045='T' OR MZ046='T' OR MZ047='T' THEN 'T' ELSE 'F' END U0,CONVERT(NCHAR(1),MZ044) MZ044,CONVERT(NCHAR(1),MZ045) MZ045,CONVERT(NCHAR(1),MZ046) MZ046,CONVERT(NCHAR(1),MZ047) MZ047,CONVERT(NCHAR(1),MZ048) MZ048,CONVERT(NCHAR(1),MZ049) MZ049,CONVERT(NCHAR(1),MZ050) MZ050,CONVERT(NCHAR(1),MZ051) MZ051,CONVERT(NCHAR(1),MZ052) MZ052,CONVERT(NCHAR(1),MZ053) MZ053,CONVERT(NCHAR(1),MZ054) MZ054,MZ055,MZ056,CONVERT(NCHAR(2),MZ057) MZ057,CONVERT(NCHAR(2),MZ058) MZ058,CONVERT(NCHAR(2),MZ059) MZ059,MZ060,MZ061,CONVERT(VARCHAR(20),MZ062,102) MZ062,CONVERT(NCHAR(1),MZ063) MZ063,CONVERT(NCHAR(1),MZ064) MZ064,CONVERT(NCHAR(1),MZ065) MZ065,CONVERT(NCHAR(1),MZ066) MZ066,CONVERT(NCHAR(1),MZ067) MZ067,CONVERT(NCHAR(1),MZ068) MZ068,CONVERT(NCHAR(1),MZ069) MZ069,CONVERT(NCHAR(1),MZ070) MZ070,CONVERT(NCHAR(1),MZ071) MZ071,CONVERT(NCHAR(1),MZ072) MZ072,CONVERT(NCHAR(1),MZ073) MZ073,CONVERT(NCHAR(1),MZ074) MZ074,CONVERT(NCHAR(1),MZ075) MZ075,CONVERT(NCHAR(1),MZ076) MZ076,CONVERT(NCHAR(1),MZ077) MZ077,CONVERT(NCHAR(1),MZ078) MZ078,CONVERT(NCHAR(1),MZ079) MZ079,CONVERT(NCHAR(1),MZ080) MZ080,CONVERT(NCHAR(1),MZ081) MZ081,CONVERT(NCHAR(1),MZ082) MZ082,CONVERT(NCHAR(1),MZ083) MZ083,CONVERT(NCHAR(1),MZ084) MZ084,CONVERT(NCHAR(1),MZ085) MZ085,CONVERT(NCHAR(1),MZ086) MZ086,MZ087,MZ088,MZ089,CONVERT(VARCHAR(20),MZ090,102) MZ090,MZ091,CONVERT(NCHAR(2),MZ092) MZ092,MZ093,CONVERT(VARCHAR(20),MZ094,102) MZ094,MZ095,MZ096,MZ097,MZ098,MZ099,MZ100,MZ101,MZ102,MZ103,MZ104,MZ109,MZ110,MZ111,MZ112,MZ113,MZ114,MZ115,MZ116,MZ001 FROM R_PQMZ" );
            strSql.Append( " WHERE MZ001=@MZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@MZ001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 写入R_346
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool WriteTo ( string oddNum )
        {
            bool result = false;
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,MZ001,MZ002,MZ003,MZ004,MZ005,MZ006,MZ007,MZ008,MZ011,MZ012,MZ031,MZ014,MZ015,MZ016,MZ017,MZ019,MZ020,MZ021,MZ022,MZ105,MZ106,MZ023,MZ024,MZ032,CONVERT(DECIMAL(18,0),MZ022*MZ006) MZ,MZ025,MZ026,MZ026+MZ027 MZ01,MZ028,MZ027,MZ006*MZ021 MZ1,MZ118,MZ119,MZ120,MZ121,MZ107,MZ125 FROM R_PQMZ" );
            strSql.Append( " WHERE MZ002=@MZ002 AND MZ107='厂内'" );
            strSql.Append( " GROUP BY idx,MZ001,MZ002,MZ003,MZ004,MZ005,MZ007,MZ008,MZ011,MZ012,MZ031,MZ014,MZ015,MZ016,MZ017,MZ019,MZ105,MZ106,MZ023,MZ032,MZ025,MZ026,MZ027,MZ028,MZ006,MZ022,MZ027,MZ024,MZ020,MZ021,MZ022,MZ118,MZ119,MZ120,MZ121,MZ107,MZ125" );
            SqlParameter[] parameter = {
                new SqlParameter("@MZ002",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da.Rows.Count > 0 )
                result = WriteDataTable( da );
            else
                result = false;

            return result;
        }
        public bool WriteDataTable ( DataTable da )
        {
            bool result = false;
            if ( da.Rows.Count > 0 )
            {
                //string oddN =/* generateOddNum.purchaseContract( "SELECT MAX(AJ029) AJ029 FROM R_PQAJ" ,"AJ029" ,"R_346-" );*/
                ArrayList SQLString = new ArrayList( );
                MulaolaoLibrary.GunQiChenBenLibrary _model = new MulaolaoLibrary.GunQiChenBenLibrary( );
                if ( Exists ( da . Rows [ 0 ] [ "MZ002" ] . ToString ( ) ) == false )
                    return false;

                string sign = "";
                int id = 0;
                _model . PZ003 = da . Rows [ 0 ] [ "MZ002" ] . ToString ( );
                _model . PZ001 = getOddNum ( _model . PZ003 );
                for ( int i = 0 ; i < da.Rows.Count ; i++ )
                {
                    sign = da.Rows[i]["MZ121"].ToString( );
                    id = string.IsNullOrEmpty( da.Rows[i]["idx"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[i]["idx"].ToString( ) );
                    _model.PZ037 = da.Rows[i]["MZ001"].ToString( );
                    _model.PZ020 = da.Rows[i]["MZ125"].ToString( );
                    _model.PZ002 = da.Rows[i]["MZ003"].ToString( );                  
                    _model .PZ004 = da.Rows[i]["MZ005"].ToString( );
                    _model.PZ005 = da.Rows[i]["MZ004"].ToString( );
                    _model.PZ006 = string.IsNullOrEmpty( da.Rows[i]["MZ006"].ToString( ) ) == true ? 0 : Convert.ToInt64( da.Rows[i]["MZ006"].ToString( ) );
                    _model.PZ007 = string.IsNullOrEmpty( da.Rows[i]["MZ007"].ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( da.Rows[i]["MZ007"].ToString( ) );
                    _model.PZ008 = string.IsNullOrEmpty( da.Rows[i]["MZ008"].ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( da.Rows[i]["MZ008"].ToString( ) );
                    _model.PZ009 = da.Rows[i]["MZ016"].ToString( );
                    _model.PZ010 = da.Rows[i]["MZ017"].ToString( );
                    _model.PZ011 = string.IsNullOrEmpty( da.Rows[i]["MZ105"].ToString( ) ) == true ? 0M : Convert.ToDecimal( da.Rows[i]["MZ105"].ToString( ) );
                    _model.PZ012 = da.Rows[i]["MZ106"].ToString( );
                    _model.PZ013 = da.Rows[i]["MZ032"].ToString( );
                    _model.PZ014 = da.Rows[i]["MZ023"].ToString( );
                    _model.PZ015 = string.IsNullOrEmpty( da.Rows[i]["MZ025"].ToString( ) ) == true ? 0M : Convert.ToDecimal( da.Rows[i]["MZ025"].ToString( ) );
                    _model . PZ017 = _model . PZ016 = string . IsNullOrEmpty ( da . Rows [ i ] [ "MZ026" ] . ToString ( ) ) == true ? 0M : Convert . ToDecimal ( da . Rows [ i ] [ "MZ026" ] . ToString ( ) );
                    _model . PZ036 = _model . PZ018 = string . IsNullOrEmpty ( da . Rows [ i ] [ "MZ027" ] . ToString ( ) ) == true ? 0M : Convert . ToDecimal ( da . Rows [ i ] [ "MZ027" ] . ToString ( ) );
                    _model.PZ019 = string.IsNullOrEmpty( da.Rows[i]["MZ028"].ToString( ) ) == true ? 0M : Convert.ToDecimal( da.Rows[i]["MZ028"].ToString( ) );
                    //_model.PZ020 = string.IsNullOrEmpty( da.Rows[i]["MZ01"].ToString( ) ) == true ? 0M : Convert.ToDecimal( da.Rows[i]["MZ01"].ToString( ) );
                    _model.PZ021 = da.Rows[i]["MZ011"].ToString( );
                    _model.PZ022 = string.IsNullOrEmpty( da.Rows[i]["MZ012"].ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( da.Rows[i]["MZ012"].ToString( ) );
                    _model.PZ023 = da.Rows[i]["MZ031"].ToString( );
                    _model.PZ024 = da.Rows[i]["MZ014"].ToString( );
                    _model.PZ025 = string.IsNullOrEmpty( da.Rows[i]["MZ015"].ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( da.Rows[i]["MZ015"].ToString( ) );
                    _model.PZ026 = string.IsNullOrEmpty( da.Rows[i]["MZ"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[i]["MZ"].ToString( ) );
                    _model.PZ027 = da.Rows[i]["MZ019"].ToString( );
                    _model.PZ028 = string.IsNullOrEmpty( da.Rows[i]["MZ024"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[i]["MZ024"].ToString( ) );
                    _model.PZ029 = string.IsNullOrEmpty( da.Rows[i]["MZ020"].ToString( ) ) == true ? 0M : Convert.ToDecimal( da.Rows[i]["MZ020"].ToString( ) );
                    _model.PZ030 = string.IsNullOrEmpty( da.Rows[i]["MZ021"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[i]["MZ021"].ToString( ) );
                    _model.PZ031 = string.IsNullOrEmpty( da.Rows[i]["MZ022"].ToString( ) ) == true ? 0M : Convert.ToDecimal( da.Rows[i]["MZ022"].ToString( ) );
                    _model.PZ032 = string.IsNullOrEmpty( da.Rows[i]["MZ1"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[i]["MZ1"].ToString( ) );
                    _model.PZ033 = string.IsNullOrEmpty( da.Rows[i]["MZ118"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[i]["MZ118"].ToString( ) );
                    _model.PZ034 = string.IsNullOrEmpty( da.Rows[i]["MZ119"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[i]["MZ119"].ToString( ) );
                    _model.PZ035 = string.IsNullOrEmpty( da.Rows[i]["MZ120"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[i]["MZ120"].ToString( ) );
                    //_model . PZ036 = string . IsNullOrEmpty ( da . Rows [ i ] [ "MZ027" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "MZ027" ] . ToString ( ) );
                    _model .PZ039 = da.Rows[i]["MZ107"].ToString( );
                    _model.PZ040 = da.Rows[i]["MZ014"].ToString( );

                    SQLString . Add ( Edits ( _model ) );
                    //if ( de != null && de.Rows.Count > 0 )
                    //{
                    //    _model.PZ001 = de.Rows[0]["PZ001"].ToString( );
                    //    if ( de.Select( "PZ037='" + _model.PZ037 + "' AND PZ020='" + _model.PZ020 + "'" ).Length > 0 )
                    //        SQLString . Add ( Edit ( _model ) );
                    //    else
                    //        SQLString.Add( Inserts( _model ) );
                    //if ( sign.Trim( ) == "T" )
                    //    SQLString.Add( Edit( _model ) );
                    //else
                    //{
                    //    if ( string.IsNullOrEmpty( _model.PZ037 ) || ( string.IsNullOrEmpty( _model.PZ037 ) && !_model.PZ037.Contains( de.Rows[0]["PZ037"].ToString( ) ) ) )
                    //        _model.PZ037 = _model.PZ037 + "," + de.Rows[0]["PZ037"].ToString( );
                    //    _model.PZ006 = _model.PZ006 + ( string.IsNullOrEmpty( de.Rows[0]["PZ006"].ToString( ) ) == true ? 0 : Convert.ToInt32( de.Rows[0]["PZ006"].ToString( ) ) );
                    //    _model.PZ026 = _model.PZ026 + ( string.IsNullOrEmpty( de.Rows[0]["PZ026"].ToString( ) ) == true ? 0 : Convert.ToInt32( de.Rows[0]["PZ026"].ToString( ) ) );
                    //    _model.PZ032 = _model.PZ032 + ( string.IsNullOrEmpty( de.Rows[0]["PZ032"].ToString( ) ) == true ? 0 : Convert.ToInt32( de.Rows[0]["PZ032"].ToString( ) ) );
                    //    _model.PZ033 = _model.PZ033 + ( string.IsNullOrEmpty( de.Rows[0]["PZ033"].ToString( ) ) == true ? 0 : Convert.ToInt32( de.Rows[0]["PZ033"].ToString( ) ) );
                    //    _model.PZ034 = _model.PZ034 + ( string.IsNullOrEmpty( de.Rows[0]["PZ034"].ToString( ) ) == true ? 0 : Convert.ToInt32( de.Rows[0]["PZ034"].ToString( ) ) );
                    //    _model.PZ035 = _model.PZ035 + ( string.IsNullOrEmpty( de.Rows[0]["PZ035"].ToString( ) ) == true ? 0 : Convert.ToInt32( de.Rows[0]["PZ035"].ToString( ) ) );

                    //}
                    //}
                    //else
                    //{
                    //_model.PZ001 = Exists( _model.PZ003 );
                    //SQLString.Add( Edits( _model ) );
                    //if ( _model.PZ001 != null )
                    //    SQLString.Add( Insert( _model ) );
                    //else
                    //{
                    //_model.PZ001 = oddN;
                    SQLString . Add ( Inserts ( _model ) );
                        //}
                    //}

                    //DataTable dl = ExistsDelete( _model.PZ003 );
                    //if ( dl != null && dl.Rows.Count > 0 )
                    //{
                    //    for ( int k = 0 ; k < dl.Rows.Count ; k++ )
                    //    {
                    //        _model.PZ009 = dl.Rows[k]["PZ009"].ToString( );
                    //        _model.PZ010 = dl.Rows[k]["PZ010"].ToString( );
                    //        _model.PZ013 = dl.Rows[k]["PZ013"].ToString( );
                    //        _model.PZ014 = dl.Rows[k]["PZ014"].ToString( );
                    //        _model.PZ027 = dl.Rows[k]["PZ027"].ToString( );
                    //        if ( da.Select( "MZ016='" + _model.PZ009 + "' AND MZ017='" + _model.PZ010 + "' AND MZ032='" + _model.PZ013 + "' AND MZ023='" + _model.PZ014 + "' AND MZ019='" + _model.PZ027 + "'" ).Length < 1 )
                    //            SQLString.Add( DeleteOf( _model ) );
                    //    }
                    //}

                    //if ( de != null && de.Rows.Count > 0 )
                    //{
                    //    for ( int k = 0 ; k < de.Rows.Count ; k++ )
                    //    {
                    //        _model.PZ037 = de.Rows[k]["PZ037"].ToString( );
                    //        _model.PZ020 = de.Rows[k]["PZ020"].ToString( );
                    //        _model.PZ001 = de.Rows[k]["PZ001"].ToString( );
                    //        if ( da.Select( "MZ001='" + _model.PZ037 + "' AND MZ125='" + _model.PZ020 + "'" ).Length < 1 )
                    //            SQLString.Add( DeleteOf( _model ) );
                    //    }
                    //}

                }

                result = SqlHelper.ExecuteSqlTran( SQLString );
            }
            else
                result = false;
            return result;
        }

        /// <summary>
        /// 是否存在此流水号,若存在则删除全部记录,然后重新写入
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool Exists ( string num )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM R_PQPZ " );
            strSql . Append ( " WHERE PZ003=@PZ003" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PZ003",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = num;

            if ( SqlHelper . Exists ( strSql . ToString ( ) ,parameter ) )
            {
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "DELETE FROM R_PQPZ WHERE PZ003='{0}'" ,num );
                int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
                if ( rows > 0 )
                    return true;
                else
                    return false;
            }
            else
                return true;
        }
        public string Edit ( MulaolaoLibrary . GunQiChenBenLibrary _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQPZ SET " );
            strSql . AppendFormat ( "PZ002='{0}'," , _model . PZ002 );
            strSql . AppendFormat ( "PZ004='{0}'," , _model . PZ004 );
            strSql . AppendFormat ( "PZ005='{0}'," , _model . PZ005 );
            strSql . AppendFormat ( "PZ006='{0}'," , _model . PZ006 );
            strSql . AppendFormat ( "PZ007='{0}'," , _model . PZ007 );
            strSql . AppendFormat ( "PZ008='{0}'," , _model . PZ008 );
            strSql . AppendFormat ( "PZ011='{0}'," , _model . PZ011 );
            strSql . AppendFormat ( "PZ012='{0}'," , _model . PZ012 );
            strSql . AppendFormat ( "PZ015='{0}'," , _model . PZ015 );
            strSql . AppendFormat ( "PZ016='{0}'," , _model . PZ016 );
            //strSql.AppendFormat( "PZ017='{0}'," ,_model.PZ017 );
            strSql . AppendFormat ( "PZ018='{0}'," , _model . PZ018 );
            strSql . AppendFormat ( "PZ019='{0}'," , _model . PZ019 );
            //strSql.AppendFormat( "PZ020='{0}'," ,_model.PZ020 );
            strSql . AppendFormat ( "PZ021='{0}'," , _model . PZ021 );
            strSql . AppendFormat ( "PZ022='{0}'," , _model . PZ022 );
            strSql . AppendFormat ( "PZ023='{0}'," , _model . PZ023 );
            strSql . AppendFormat ( "PZ024='{0}'," , _model . PZ024 );
            strSql . AppendFormat ( "PZ025='{0}'," , _model . PZ025 );
            strSql . AppendFormat ( "PZ026='{0}'," , _model . PZ026 );
            //strSql.AppendFormat( "PZ027='{0}'," ,_model.PZ027 );
            strSql . AppendFormat ( "PZ028='{0}'," , _model . PZ028 );
            strSql . AppendFormat ( "PZ029='{0}'," , _model . PZ029 );
            strSql . AppendFormat ( "PZ030='{0}'," , _model . PZ030 );
            strSql . AppendFormat ( "PZ031='{0}'," , _model . PZ031 );
            strSql . AppendFormat ( "PZ032='{0}'," , _model . PZ032 );
            strSql . AppendFormat ( "PZ033='{0}'," , _model . PZ033 );
            strSql . AppendFormat ( "PZ034='{0}'," , _model . PZ034 );
            strSql . AppendFormat ( "PZ035='{0}'," , _model . PZ035 );
            strSql . AppendFormat ( "PZ036='{0}'," , _model . PZ036 );
            //strSql.AppendFormat( "PZ037='{0}'," ,_model.PZ037 );
            strSql . AppendFormat ( "PZ039='{0}'," , _model . PZ039 );
            strSql . AppendFormat ( "PZ040='{0}'," , _model . PZ040 );
            strSql . AppendFormat ( "PZ003='{0}'," , _model . PZ003 );
            strSql . AppendFormat ( "PZ009='{0}'," , _model . PZ009 );
            strSql . AppendFormat ( "PZ010='{0}'," , _model . PZ010 );
            strSql . AppendFormat ( "PZ013='{0}'," , _model . PZ013 );
            strSql . AppendFormat ( "PZ014='{0}'," , _model . PZ014 );
            strSql . AppendFormat ( "PZ027='{0}'," , _model . PZ027 );
            strSql . AppendFormat ( "PZ017='{0}' " ,_model . PZ017 );
            //strSql . AppendFormat ( "PZ036='{0}' " ,_model . PZ036 );
            strSql . Append ( " WHERE " );
            strSql . AppendFormat ( "PZ001='{0}'" , _model . PZ001 );
            strSql . AppendFormat ( " AND PZ037='{0}'" , _model . PZ037 );
            strSql . AppendFormat ( " AND PZ020='{0}'" , _model . PZ020 );


            return strSql . ToString ( );
        }
        public string Edits ( MulaolaoLibrary.GunQiChenBenLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQMZ SET " );
            strSql.Append( "MZ121='T'" );
            //strSql.AppendFormat( " WHERE idx={0}" ,id );
            strSql.AppendFormat( " WHERE MZ001='{0}' AND MZ125='{1}'" ,_model.PZ037 ,_model.PZ020 );

            return strSql.ToString( );
        }
        /*
        public string Exists ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT PZ001 FROM R_PQPZ" );
            strSql.Append( " WHERE PZ003=@PZ003" );
            SqlParameter[] parameter = {
                new SqlParameter("@PZ003",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            DataTable de = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( de.Rows.Count > 0 )
            {
                if ( string.IsNullOrEmpty( de.Rows[0]["PZ001"].ToString( ) ) )
                    return null;
                else
                    return de.Rows[0]["PZ001"].ToString( );
            }
            else
                return null;
        }
        */
        public string Insert ( MulaolaoLibrary.GunQiChenBenLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQPZ (" );
            strSql.Append( "PZ001,PZ002,PZ003,PZ004,PZ005,PZ006,PZ007,PZ008,PZ009,PZ010,PZ011,PZ012,PZ013,PZ014,PZ015,PZ016,PZ017,PZ018,PZ019,PZ021,PZ022,PZ023,PZ024,PZ025,PZ026,PZ027,PZ028,PZ029,PZ030,PZ031,PZ032,PZ033,PZ034,PZ035,PZ037,PZ039,PZ040,PZ036)" );
            strSql.Append( " VALUES (" );
            strSql . AppendFormat ( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}')" , _model . PZ001 , _model . PZ002 , _model . PZ003 , _model . PZ004 , _model . PZ005 , _model . PZ006 , _model . PZ007 , _model . PZ008 , _model . PZ009 , _model . PZ010 , _model . PZ011 , _model . PZ012 , _model . PZ013 , _model . PZ014 , _model . PZ015 , _model . PZ016 , _model . PZ017 , _model . PZ018 , _model . PZ019 , _model . PZ021 , _model . PZ022 , _model . PZ023 , _model . PZ024 , _model . PZ025 , _model . PZ026 , _model . PZ027 , _model . PZ028 , _model . PZ029 , _model . PZ030 , _model . PZ031 , _model . PZ032 , _model . PZ033 , _model . PZ034 , _model . PZ035 , _model . PZ037 , _model . PZ039 , _model . PZ040 , _model . PZ036 );

            return strSql.ToString( );
        }
        public string Inserts ( MulaolaoLibrary.GunQiChenBenLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQPZ (" );
            strSql.Append( "PZ001,PZ002,PZ003,PZ004,PZ005,PZ006,PZ007,PZ008,PZ009,PZ010,PZ011,PZ012,PZ013,PZ014,PZ015,PZ016,PZ017,PZ018,PZ019,PZ021,PZ022,PZ023,PZ024,PZ025,PZ026,PZ027,PZ028,PZ029,PZ030,PZ031,PZ032,PZ033,PZ034,PZ035,PZ037,PZ039,PZ040,PZ020,PZ036)" );
            strSql.Append( " VALUES (" );
            strSql . AppendFormat ( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}','{38}')" , _model . PZ001 , _model . PZ002 , _model . PZ003 , _model . PZ004 , _model . PZ005 , _model . PZ006 , _model . PZ007 , _model . PZ008 , _model . PZ009 , _model . PZ010 , _model . PZ011 , _model . PZ012 , _model . PZ013 , _model . PZ014 , _model . PZ015 , _model . PZ016 , _model . PZ017 , _model . PZ018 , _model . PZ019 , _model . PZ021 , _model . PZ022 , _model . PZ023 , _model . PZ024 , _model . PZ025 , _model . PZ026 , _model . PZ027 , _model . PZ028 , _model . PZ029 , _model . PZ030 , _model . PZ031 , _model . PZ032 , _model . PZ033 , _model . PZ034 , _model . PZ035 , _model . PZ037 , _model . PZ039 , _model . PZ040 , _model . PZ020 , _model . PZ036 );

            return strSql.ToString( );
        }

        public DataTable ExistsDelete ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "SELECT PZ003,PZ009,PZ010,PZ013,PZ014,PZ027 FROM R_PQPZ WHERE PZ003='{0}'" ,num );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public string DeleteOf ( MulaolaoLibrary.GunQiChenBenLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQPZ" );
            strSql.AppendFormat( " WHERE PZ001='{0}' AND PZ037='{1}' AND PZ020='{2}'" ,_model.PZ001 ,_model.PZ037 ,_model.PZ020 );

            return strSql.ToString( );
        }

        string getOddNum ( string num )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT PZ001 FROM R_PQPZ WHERE PZ003='{0}'" ,num );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PZ001" ] . ToString ( ) ) )
                    return getOddN ( );
                else
                    return dt . Rows [ 0 ] [ "PZ001" ] . ToString ( );
            }
            else
                return getOddN ( );
        }

        string getOddN ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT MAX(PZ001) PZ001 FROM R_PQPZ " );

            DataTable dl = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dl != null && dl . Rows . Count > 0 )
            {
                string str = dl . Rows [ 0 ] [ "PZ001" ] . ToString ( );
                if ( str . Substring ( 6 ,8 ) . Equals ( MulaolaoBll . Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) ) )
                    return "R_346-" + ( Convert . ToInt64 ( str . Substring ( 6 ,11 ) ) + 1 ) . ToString ( );
                else
                    return "R_346-" + MulaolaoBll . Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "001";
            }
            else
                return "R_346-" + MulaolaoBll . Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "001";
        }

        /// <summary>
        /// 获取346单号
        /// </summary>
        /// <returns></returns>
        //public string getOddFor346 ( )
        //{
        //    StringBuilder strSql = new StringBuilder ( );
        //    strSql . Append ( "SELECT MAX(PZ001) PZ001 FROM R_PQPZ" );

        //    string oddNum = string . Empty;

        //    DataTable table = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        //    if ( table != null && table . Rows . Count > 0 )
        //    {
        //        oddNum = table . Rows [ 0 ] [ "PZ001" ] . ToString ( );
        //        if ( string . IsNullOrEmpty ( table . Rows [ 0 ] [ "PZ001" ] . ToString ( ) ) )
        //            return "R_346-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "001";
        //        else
        //        {
        //            if(oddNum.Substring(6,8)==)
        //        }
        //    }
        //    else
        //        return "R_346-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "001";
        //}
        
        /// <summary>
        /// 获取零件名称
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfPart ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            //strSql.Append( "SELECT DISTINCT GS07 LZ015,GS08 LZ017 FROM R_PQP WHERE GS01=@GS01 AND GS07!=''" );
            //SqlParameter[] parameter = {
            //    new SqlParameter("@GS01",SqlDbType.NVarChar,20)
            //};
            //parameter[0].Value = num;
            strSql . AppendFormat ( "SELECT GS02,GS07,GS08,CONVERT(FLOAT,GS78) GS78 FROM R_PQP WHERE GS78>0 AND GS01='{0}'" ,num );
            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT MZ124,MZ024 FROM R_PQMZ" );
            strSql.Append( " WHERE MZ002=@MZ002" );
            SqlParameter[] parameter = {
                new SqlParameter("@MZ002",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="colorNum"></param>
        /// <param name="brand"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfPqac ( string colorNum ,string brand )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT AC05 FROM R_PQAC WHERE AC04=@AC04 AND AC06=@AC06 AND AC02='滚漆'" );
            SqlParameter[] parameter = {
                new SqlParameter("@AC04",SqlDbType.NVarChar),
                new SqlParameter("@AC06",SqlDbType.NVarChar)
            };
            parameter[0].Value = colorNum;
            parameter[1].Value = brand;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取供应商信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableP ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DGA001,DGA003,DGA008,DGA011,DGA017,DGA009,DGA012 FROM TPADGA WHERE DGA052='F'" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取联系人
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableBusi ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT DBA002,DBA001,DBA028 FROM TPADBA WHERE DBA028!='' AND (DBA043='F' OR DBA043='' OR DBA043 IS NULL) ORDER BY DBA001" );


            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 批量编辑产品数量
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool batchUpdate ( string oddNum ,long num ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQMZ SET" );
            strSql.AppendFormat( " MZ006='{0}'" ,num );
            strSql.AppendFormat( " WHERE MZ001='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePri ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT MZ002,MZ003,MZ004,MZ005,MZ006,CONVERT(VARCHAR(20),MZ007,102) MZ007,CONVERT( VARCHAR( 20 ) ,MZ008 ,102 ) MZ008 ,MZ031 ,CONVERT( VARCHAR( 20 ) ,MZ010 ,102 ) MZ010 ,CONVERT( VARCHAR( 20 ) ,MZ015 ,102 ) MZ015,MZ014 FROM R_PQMZ" );
            strSql.Append( " WHERE MZ001=@MZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@MZ001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableExp ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT MZ016,MZ017,MZ105,MZ106,MZ023,MZ006,CONVERT(DECIMAL(18,0),MZ022*MZ006) MZ,MZ027,CONVERT(DECIMAL(18,2),MZ028-MZ026-MZ027) MZ1,CASE WHEN MZ006=0 THEN 0 ELSE CONVERT(DECIMAL(18,3),MZ022*MZ006*MZ027/MZ006) END MZ2,MZ022*MZ006*MZ027 MZ3,ISNULL(MZ118,0) MZ118,MZ001 FROM R_PQMZ" );
            strSql.Append( " WHERE MZ001=@MZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@MZ001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOther ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT MZ016,MZ017,MZ105,MZ106,MZ023,MZ019,MZ024,MZ006,CONVERT(DECIMAL(18,0),MZ022*MZ006) MZ0,MZ026+MZ027 MZ1,MZ028,MZ028-MZ026-MZ027 MZ2,CASE WHEN MZ022*MZ006*MZ028=0 THEN 0 ELSE CONVERT(DECIMAL(18,2),(MZ022*MZ006*MZ027+MZ022*MZ006*MZ026*MZ024)/(MZ022*MZ006*MZ028)) END MZ3,MZ022*MZ028*MZ024 MZ4,MZ022*MZ006*MZ028*MZ024 MZ5,ISNULL(MZ120,0) MZ120 FROM R_PQMZ" );
            strSql.Append( " WHERE MZ001=@MZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@MZ001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOtherTwo ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT MZ002,MZ003,MZ004,MZ005,MZ006,CONVERT(VARCHAR(20),MZ007,102) MZ007,CONVERT(VARCHAR(20),MZ008,102) MZ008,MZ009,CONVERT(VARCHAR(20),MZ010,102) MZ010,MZ011,CONVERT(VARCHAR(20),MZ012,102) MZ102,MZ013,MZ014 ,MZ033,MZ034,CONVERT(NCHAR(1),MZ035) MZ035,CONVERT(NCHAR(1),MZ036) MZ036,CONVERT(NCHAR(1),MZ037) MZ037,CONVERT(NCHAR(1),MZ038) MZ038,CONVERT(NCHAR(1),MZ039) MZ039,MZ040,CONVERT(VARCHAR(20),MZ041,102) MZ041,MZ042,CONVERT(VARCHAR(20),MZ043,102) MZ043,CASE WHEN MZ044='T' OR MZ045='T' OR MZ046='T' OR MZ047='T' THEN 'T' ELSE 'F' END U0,CONVERT(NCHAR(1),MZ044) MZ044,CONVERT(NCHAR(1),MZ045) MZ045,CONVERT(NCHAR(1),MZ046) MZ046,CONVERT(NCHAR(1),MZ047) MZ047,CONVERT(NCHAR(1),MZ048) MZ048,CONVERT(NCHAR(1),MZ049) MZ049,CONVERT(NCHAR(1),MZ050) MZ050,CONVERT(NCHAR(1),MZ051) MZ051,CONVERT(NCHAR(1),MZ052) MZ052,CONVERT(NCHAR(1),MZ053) MZ053,CONVERT(NCHAR(1),MZ054) MZ054,MZ055,MZ056,CONVERT(NCHAR(2),MZ057) MZ057,CONVERT(NCHAR(2),MZ058) MZ058,CONVERT(NCHAR(2),MZ059) MZ059,MZ060,MZ061,CONVERT(VARCHAR(20),MZ062,102) MZ062,CONVERT(NCHAR(1),MZ063) MZ063,CONVERT(NCHAR(1),MZ064) MZ064,CONVERT(NCHAR(1),MZ065) MZ065,CONVERT(NCHAR(1),MZ066) MZ066,CONVERT(NCHAR(1),MZ067) MZ067,CONVERT(NCHAR(1),MZ068) MZ068,CONVERT(NCHAR(1),MZ069) MZ069,CONVERT(NCHAR(1),MZ070) MZ070,CONVERT(NCHAR(1),MZ071) MZ071,CONVERT(NCHAR(1),MZ072) MZ072,CONVERT(NCHAR(1),MZ073) MZ073,CONVERT(NCHAR(1),MZ074) MZ074,CONVERT(NCHAR(1),MZ075) MZ075,CONVERT(NCHAR(1),MZ076) MZ076,CONVERT(NCHAR(1),MZ077) MZ077,CONVERT(NCHAR(1),MZ078) MZ078,CONVERT(NCHAR(1),MZ079) MZ079,CONVERT(NCHAR(1),MZ080) MZ080,CONVERT(NCHAR(1),MZ081) MZ081,CONVERT(NCHAR(1),MZ082) MZ082,CONVERT(NCHAR(1),MZ083) MZ083,CONVERT(NCHAR(1),MZ084) MZ084,CONVERT(NCHAR(1),MZ085) MZ085,CONVERT(NCHAR(1),MZ086) MZ086,MZ087,MZ088,MZ089,CONVERT(VARCHAR(20),MZ090,102) MZ090,MZ091,CONVERT(NCHAR(2),MZ092) MZ092,MZ093,CONVERT(VARCHAR(20),MZ094,102) MZ094,MZ095,MZ096,MZ097,MZ098,MZ099,MZ100,MZ101,MZ102,MZ103,MZ104,DGA003 MZ109,DGA017 MZ110,DGA008 MZ111,DGA012 MZ112,DGA009 MZ113,DGA011 MZ114,MZ115,MZ116,MZ001 FROM R_PQMZ A INNER JOIN TPADGA B ON A.MZ108=B.DGA001" );
            strSql.Append( " WHERE MZ001=@MZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@MZ001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableTre ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT CASE WHEN SUM(MZ022*MZ006)=0 THEN 0 ELSE CONVERT(DECIMAL(18,1),SUM(MZ022*MZ006*MZ027)/SUM(MZ022*MZ006))+CONVERT(DECIMAL(18,2),SUM(MZ022*MZ006*MZ026*MZ024)/SUM(MZ022*MZ006)) END One,CASE WHEN SUM(MZ022*MZ006)=0 THEN 0 ELSE CONVERT(DECIMAL(18,2),SUM(MZ022*MZ006*MZ028*MZ024)/SUM(MZ022*MZ006)) END Two,CASE WHEN SUM(MZ022*MZ006*MZ028*MZ024)=0 THEN 0 ELSE CONVERT(DECIMAL(18,0),(SUM(MZ022*MZ006*MZ027)+SUM(MZ022*MZ006*MZ026*MZ024))/SUM(MZ022*MZ006*MZ028*MZ024)) END Tre,CASE WHEN MZ006=0 THEN 0 ELSE CONVERT(DECIMAL(18,2),SUM(MZ022*MZ006*MZ028*MZ024)/MZ006) END Fore,SUM(MZ022*MZ006*MZ028*MZ024)+SUM(ISNULL(MZ120,0)) Fiv FROM R_PQMZ" );
            strSql.Append( " WHERE MZ001=@MZ001" );
            strSql.Append( " GROUP BY MZ006" );
            SqlParameter[] parameter = {
                new SqlParameter("@MZ001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="colorNum"></param>
        /// <param name="colorName"></param>
        /// <param name="brand"></param>
        /// <returns></returns>
        public DataTable GetDataTableStock ( string colorNum ,string colorName ,string brand )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT SUM(AC10) AC10 FROM (SELECT CONVERT(DECIMAL(18,2),AC10-ISNULL(SUM(AD12),0)) AC10 FROM R_PQAC LEFT JOIN R_PQAD ON AC18=AD01 AND AC02=AD03 AND AC04=AD06 AND AC05=AD07" );//AC04=@AC04 AND AC05=@AC05 AND 
            strSql .Append( " WHERE AC06=@AC06 AND AC02='滚漆'" );
            strSql.Append( " GROUP BY AC10) A" );
            SqlParameter[] parameter = {
                //new SqlParameter("@AC04",SqlDbType.NVarChar),
                //new SqlParameter("@AC05",SqlDbType.NVarChar),
                new SqlParameter("@AC06",SqlDbType.NVarChar)
            };
            //parameter[0].Value = colorName;
            //parameter[1].Value = colorNum;
            parameter[0].Value = brand;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 是否出库
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool ExistsOfLibrary ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQAD WHERE AD17=@AD17" );
            SqlParameter[] parametre = {
                new SqlParameter("@AD17",SqlDbType.NVarChar,20)
            };
            parametre[0].Value = oddNum;

            return SqlHelper.Exists( strSql.ToString( ) ,parametre );
        }

        /// <summary>
        /// 获取乙方
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfYf ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT MZ014 FROM R_PQMZ" );


            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取供应商
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfGy ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DGA003,DGA008,DGA011,DGA017,DGA009,DGA012 FROM TPADGA" );
            strSql.Append( " WHERE DGA001=@DGA001" );
            SqlParameter[] parameter = {
                new SqlParameter("@DGA001",SqlDbType.NVarChar)
            };

            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表   漆款
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfReceviable ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT MZ123,MZ002,CONVERT(DECIMAL(18,0),SUM(MZ022*MZ006*MZ028*MZ024+ISNULL(MZ120,0))) MZ2 FROM R_PQMZ A  LEFT JOIN R_REVIEWS ON MZ001=RES06 AND RES05='执行'" );
            strSql.AppendFormat( " WHERE MZ001='{0}'  AND (MZ002!='' AND MZ002 IS NOT NULL) AND MZ107='厂外' GROUP BY MZ002,MZ123" ,oddNum );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表  工资
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfRecevable ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT MZ002,CONVERT(DECIMAL(18,0),CASE WHEN MZ107='厂内' THEN SUM(MZ022*MZ006*MZ027+ISNULL(MZ118,0)) ELSE 0 END) MZ0 FROM R_PQMZ A LEFT JOIN R_REVIEWS ON MZ001=RES06 AND RES05='执行'" );
            strSql.AppendFormat( " WHERE MZ001='{0}'  AND (MZ002!='' AND MZ002 IS NOT NULL) GROUP BY MZ002,MZ107" ,oddNum );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 写数据到241
        /// </summary>
        /// <param name="modelAm"></param>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateOfReceviable ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum )
        {
            ArrayList SQLString = new ArrayList( );
            ByOneBy( modelAm ,oddNum ,SQLString );
            StringBuilder strSql = new StringBuilder( );
            if ( modelAm.AM242 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM242='{0}' WHERE AM002='{1}'" ,modelAm.AM242 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( modelAm.AM247 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM247='{0}' WHERE AM002='{1}'" ,modelAm.AM247 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }
            if ( modelAm.AM249 > 0 )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "UPDATE R_PQAM SET AM249='{0}' WHERE AM002='{1}'" ,modelAm.AM249 ,modelAm.AM002 );
                SQLString.Add( strSql.ToString( ) );
            }
            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        void ByOneBy ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            //modelAm.AM249 = 0M;modelAm.AM242 = modelAm.AM247 = 0M;
            strSql.AppendFormat( "SELECT AMB249,AMB242,AMB247 FROM R_PQAMB WHERE AMB001='{0}'" ,oddNum );
            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            DataTable de = SqlHelper.ExecuteDataTable( "SELECT AM242,AM247,AM249 FROM R_PQAM WHERE AM002='" + modelAm.AM002 + "'" );
            if ( da != null && da.Rows.Count > 0 )
            {
                if ( modelAm.AM242 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB242='{0}' WHERE AMB001='{1}'" ,modelAm.AM242 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM247 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB247='{0}' WHERE AMB001='{1}'" ,modelAm.AM247 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM249 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB249='{0}' WHERE AMB001='{1}'" ,modelAm.AM249 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                
                if ( de != null && de.Rows.Count > 0 )
                {
                    modelAm.AM242 = modelAm.AM242 - ( string.IsNullOrEmpty( da.Rows[0]["AMB242"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB242"].ToString( ) ) );
                    modelAm.AM247 = modelAm.AM247 - ( string.IsNullOrEmpty( da.Rows[0]["AMB247"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB247"].ToString( ) ) );
                    modelAm.AM249 = modelAm.AM249 - ( string.IsNullOrEmpty( da.Rows[0]["AMB249"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB249"].ToString( ) ) );

                    modelAm.AM242 = modelAm.AM242 + ( string.IsNullOrEmpty( de.Rows[0]["AM242"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM242"].ToString( ) ) );
                    modelAm.AM247 = modelAm.AM247 + ( string.IsNullOrEmpty( de.Rows[0]["AM247"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM247"].ToString( ) ) );
                    modelAm.AM249 = modelAm.AM249 + ( string.IsNullOrEmpty( de.Rows[0]["AM249"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM249"].ToString( ) ) );
                }               
            }
            else
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "INSERT INTO R_PQAMB (AMB001,AMB242,AMB247,AMB249) VALUES ('{0}','{1}','{2}','{3}')" ,oddNum ,modelAm.AM242 ,modelAm.AM247 ,modelAm.AM249 );
                SQLString.Add( strSql.ToString( ) );
                if ( de != null && de.Rows.Count > 0 )
                {
                    modelAm.AM242 = modelAm.AM242 + ( string.IsNullOrEmpty( de.Rows[0]["AM242"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM242"].ToString( ) ) );
                    modelAm.AM247 = modelAm.AM247 + ( string.IsNullOrEmpty( de.Rows[0]["AM247"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM247"].ToString( ) ) );
                    modelAm.AM249 = modelAm.AM249 + ( string.IsNullOrEmpty( de.Rows[0]["AM249"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM249"].ToString( ) ) );
                }               
            }
        }

        /// <summary>
        /// 获取剩余出库内容
        /// </summary>
        /// <returns></returns>
        public DataTable getAutoLibrary ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT AC18,AC05,AC02,AC04,AC06,AC10+ISNULL(AC27,0)-SUM(ISNULL(AD12,0)+ISNULL(AD21,0)) ONE FROM R_PQAC A LEFT JOIN R_PQAD B ON A.AC18=B.AD01 WHERE AC02='滚漆' GROUP BY AC18,AC02,AC05,AC04,AC06,AC10,AC03,ISNULL(AC27,0)  HAVING AC10+ISNULL(AC27,0)-SUM(ISNULL(AD12,0)+ISNULL(AD21,0))>0" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 删除入库记录
        /// </summary>
        /// <param name="ad17"></param>
        /// <returns></returns>
        public bool DeleteLibrary ( string ad17 )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "select count(1) from R_PQAD where AD17='{0}'" ,ad17 );
            if ( SqlHelper . Exists ( strSql . ToString ( ) ) )
            {
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "DELETE FROM R_PQAD WHERE AD17='{0}'" ,ad17 );

                int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
                return rows >= 0 ? true : false;
            }
            else
                return true;
        }

    }
}

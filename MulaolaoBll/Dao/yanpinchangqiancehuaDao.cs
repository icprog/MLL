using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentMgr;
using System.Data;
using System.Data.SqlClient;

namespace MulaolaoBll.Dao
{
    public class yanpinchangqiancehuaDao
    {
        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <returns></returns>
        public bool DeleteOfAll (string oddNum ,string tableNum,string tableName,string logins,DateTime dtOne,string stateOf,string stateOfOdd)
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "DELETE FROM R_PQCQ WHERE CQ01='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            StringBuilder strSq = new StringBuilder( );
            strSq = new StringBuilder( );
            strSq.AppendFormat( "DELETE FROM R_REVIEWS WHERE RES06='{0}'" ,oddNum );
            SQLString.Add( strSq.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取维护记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public string GetDataTableOfWeiHu ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT CQ97 FROM R_PQCQ" );
            strSql.Append( " WHERE CQ01=@CQ01" );
            SqlParameter[] parameter = {
                new SqlParameter("@CQ01",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da != null && da.Rows.Count > 0 )
                return da.Rows[0]["CQ97"].ToString( );
            else
                return "";
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public bool SaveOfAll ( MulaolaoLibrary.yanpinchangqiancehuaLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            using ( SqlConnection conn = new SqlConnection( SqlHelper.connstr ) )
            {
                conn.Open( );
                SqlCommand cmd = new SqlCommand( );
                cmd.Connection = conn;
                SqlTransaction tran = conn.BeginTransaction( );
                cmd.Transaction = tran;
                try
                {
                    StringBuilder strSql = new StringBuilder( );
                    strSql.Append( "UPDATE R_PQCQ SET " );
                    strSql.Append( "CQ02=@CQ02," );
                    strSql.Append( "CQ03=@CQ03," );
                    strSql.Append( "CQ04=@CQ04," );
                    strSql.Append( "CQ05=@CQ05," );
                    strSql.Append( "CQ06=@CQ06," );
                    strSql.Append( "CQ07=@CQ07," );
                    strSql.Append( "CQ08=@CQ08," );
                    strSql.Append( "CQ09=@CQ09," );
                    strSql.Append( "CQ10=@CQ10," );
                    strSql.Append( "CQ11=@CQ11," );
                    strSql.Append( "CQ12=@CQ12," );
                    strSql.Append( "CQ13=@CQ13," );
                    strSql.Append( "CQ14=@CQ14," );
                    strSql.Append( "CQ15=@CQ15," );
                    strSql.Append( "CQ16=@CQ16," );
                    strSql.Append( "CQ17=@CQ17," );
                    strSql.Append( "CQ18=@CQ18," );
                    strSql.Append( "CQ19=@CQ19," );
                    strSql.Append( "CQ20=@CQ20," );
                    strSql.Append( "CQ21=@CQ21," );
                    strSql.Append( "CQ22=@CQ22," );
                    strSql.Append( "CQ23=@CQ23," );
                    strSql.Append( "CQ24=@CQ24," );
                    strSql.Append( "CQ25=@CQ25," );
                    strSql.Append( "CQ26=@CQ26," );
                    strSql.Append( "CQ27=@CQ27," );
                    strSql.Append( "CQ28=@CQ28," );
                    strSql.Append( "CQ29=@CQ29," );
                    strSql.Append( "CQ30=@CQ30," );
                    strSql.Append( "CQ31=@CQ31," );
                    strSql.Append( "CQ32=@CQ32," );
                    strSql.Append( "CQ33=@CQ33," );
                    strSql.Append( "CQ34=@CQ34," );
                    strSql.Append( "CQ35=@CQ35," );
                    strSql.Append( "CQ36=@CQ36," );
                    strSql.Append( "CQ37=@CQ37," );
                    strSql.Append( "CQ38=@CQ38," );
                    strSql.Append( "CQ39=@CQ39," );
                    strSql.Append( "CQ40=@CQ40," );
                    strSql.Append( "CQ41=@CQ41," );
                    strSql.Append( "CQ42=@CQ42," );
                    strSql.Append( "CQ43=@CQ43," );
                    strSql.Append( "CQ44=@CQ44," );
                    strSql.Append( "CQ45=@CQ45," );
                    strSql.Append( "CQ46=@CQ46," );
                    strSql.Append( "CQ47=@CQ47," );
                    strSql.Append( "CQ48=@CQ48," );
                    strSql.Append( "CQ49=@CQ49," );
                    strSql.Append( "CQ50=@CQ50," );
                    strSql.Append( "CQ51=@CQ51," );
                    strSql.Append( "CQ52=@CQ52," );
                    strSql.Append( "CQ53=@CQ53," );
                    strSql.Append( "CQ54=@CQ54," );
                    strSql.Append( "CQ55=@CQ55," );
                    strSql.Append( "CQ56=@CQ56," );
                    strSql.Append( "CQ57=@CQ57," );
                    strSql.Append( "CQ58=@CQ58," );
                    strSql.Append( "CQ59=@CQ59," );
                    strSql.Append( "CQ60=@CQ60," );
                    strSql.Append( "CQ61=@CQ61," );
                    strSql.Append( "CQ62=@CQ62," );
                    strSql.Append( "CQ63=@CQ63," );
                    strSql.Append( "CQ64=@CQ64," );
                    strSql.Append( "CQ65=@CQ65," );
                    strSql.Append( "CQ66=@CQ66," );
                    strSql.Append( "CQ67=@CQ67," );
                    strSql.Append( "CQ68=@CQ68," );
                    strSql.Append( "CQ69=@CQ69," );
                    strSql.Append( "CQ70=@CQ70," );
                    strSql.Append( "CQ71=@CQ71," );
                    strSql.Append( "CQ72=@CQ72," );
                    strSql.Append( "CQ73=@CQ73," );
                    strSql.Append( "CQ74=@CQ74," );
                    strSql.Append( "CQ75=@CQ75," );
                    strSql.Append( "CQ76=@CQ76," );
                    strSql.Append( "CQ77=@CQ77," );
                    strSql.Append( "CQ78=@CQ78," );
                    strSql.Append( "CQ79=@CQ79," );
                    strSql.Append( "CQ80=@CQ80," );
                    strSql.Append( "CQ81=@CQ81," );
                    strSql.Append( "CQ82=@CQ82," );
                    strSql.Append( "CQ83=@CQ83," );
                    strSql.Append( "CQ84=@CQ84," );
                    strSql.Append( "CQ85=@CQ85," );
                    strSql.Append( "CQ86=@CQ86," );
                    strSql.Append( "CQ87=@CQ87," );
                    strSql.Append( "CQ88=@CQ88," );
                    strSql.Append( "CQ89=@CQ89," );
                    strSql.Append( "CQ90=@CQ90," );
                    strSql.Append( "CQ91=@CQ91," );
                    strSql.Append( "CQ92=@CQ92," );
                    strSql.Append( "CQ93=@CQ93," );
                    strSql.Append( "CQ94=@CQ94," );
                    strSql.Append( "CQ95=@CQ95," );
                    strSql.Append( "CQ96=@CQ96," );
                    strSql.Append( "CQ97=@CQ97," );
                    strSql.Append( "CQ98=@CQ98," );
                    strSql.Append( "CQ108=@CQ108," );
                    strSql.Append( "CQ109=@CQ109," );
                    strSql.Append( "CQ110=@CQ110," );
                    strSql.Append( "CQ111=@CQ111" );
                    strSql.Append( " WHERE CQ01=@CQ01" );
                    SqlParameter[] parameter = {
                        new SqlParameter("@CQ01",SqlDbType.NVarChar,20),
                        new SqlParameter("@CQ02",SqlDbType.NVarChar,50),
                        new SqlParameter("@CQ03",SqlDbType.NVarChar,50),
                        new SqlParameter("@CQ04",SqlDbType.NVarChar,50),
                        new SqlParameter("@CQ05",SqlDbType.NVarChar,50),
                        new SqlParameter("@CQ06",SqlDbType.Date),
                        new SqlParameter("@CQ07",SqlDbType.Date),
                        new SqlParameter("@CQ08",SqlDbType.NVarChar,10),
                        new SqlParameter("@CQ09",SqlDbType.NVarChar,10),
                        new SqlParameter("@CQ10",SqlDbType.NVarChar,10),
                        new SqlParameter("@CQ11",SqlDbType.NVarChar,10),
                        new SqlParameter("@CQ12",SqlDbType.NVarChar,20),
                        new SqlParameter("@CQ13",SqlDbType.NVarChar,20),
                        new SqlParameter("@CQ14",SqlDbType.Int),
                        new SqlParameter("@CQ15",SqlDbType.NVarChar,15),
                        new SqlParameter("@CQ16",SqlDbType.NVarChar,15),
                        new SqlParameter("@CQ17",SqlDbType.NVarChar,15),
                        new SqlParameter("@CQ18",SqlDbType.NVarChar,15),
                        new SqlParameter("@CQ19",SqlDbType.NVarChar,15),
                        new SqlParameter("@CQ20",SqlDbType.NVarChar,50),
                        new SqlParameter("@CQ21",SqlDbType.NVarChar,100),
                        new SqlParameter("@CQ22",SqlDbType.NVarChar,15),
                        new SqlParameter("@CQ23",SqlDbType.NVarChar,15),
                        new SqlParameter("@CQ24",SqlDbType.NVarChar,15),
                        new SqlParameter("@CQ25",SqlDbType.NVarChar,15),
                        new SqlParameter("@CQ26",SqlDbType.NVarChar,15),
                        new SqlParameter("@CQ27",SqlDbType.NVarChar,15),
                        new SqlParameter("@CQ28",SqlDbType.NVarChar,50),
                        new SqlParameter("@CQ29",SqlDbType.NVarChar,15),
                        new SqlParameter("@CQ30",SqlDbType.NVarChar,15),
                        new SqlParameter("@CQ31",SqlDbType.NVarChar,15),
                        new SqlParameter("@CQ32",SqlDbType.NVarChar,15),
                        new SqlParameter("@CQ33",SqlDbType.NVarChar,50),
                        new SqlParameter("@CQ34",SqlDbType.VarBinary),
                        new SqlParameter("@CQ35",SqlDbType.NVarChar,20),
                        new SqlParameter("@CQ36",SqlDbType.NVarChar,20),
                        new SqlParameter("@CQ37",SqlDbType.NVarChar,20),
                        new SqlParameter("@CQ38",SqlDbType.NVarChar,20),
                        new SqlParameter("@CQ39",SqlDbType.NVarChar,20),
                        new SqlParameter("@CQ40",SqlDbType.NVarChar,20),
                        new SqlParameter("@CQ41",SqlDbType.NVarChar,20),
                        new SqlParameter("@CQ42",SqlDbType.NVarChar,20),
                        new SqlParameter("@CQ43",SqlDbType.NVarChar,20),
                        new SqlParameter("@CQ44",SqlDbType.NVarChar,20),
                        new SqlParameter("@CQ45",SqlDbType.NVarChar,20),
                        new SqlParameter("@CQ46",SqlDbType.Int),
                        new SqlParameter("@CQ47",SqlDbType.Int),
                        new SqlParameter("@CQ48",SqlDbType.Int),
                        new SqlParameter("@CQ49",SqlDbType.Int),
                        new SqlParameter("@CQ50",SqlDbType.Int),
                        new SqlParameter("@CQ51",SqlDbType.Int),
                        new SqlParameter("@CQ52",SqlDbType.Int),
                        new SqlParameter("@CQ53",SqlDbType.Int),
                        new SqlParameter("@CQ54",SqlDbType.Int),
                        new SqlParameter("@CQ55",SqlDbType.Int),
                        new SqlParameter("@CQ56",SqlDbType.Int),
                        new SqlParameter("@CQ57",SqlDbType.Date),
                        new SqlParameter("@CQ58",SqlDbType.Date),
                        new SqlParameter("@CQ59",SqlDbType.Date),
                        new SqlParameter("@CQ60",SqlDbType.Date),
                        new SqlParameter("@CQ61",SqlDbType.Date),
                        new SqlParameter("@CQ62",SqlDbType.Date),
                        new SqlParameter("@CQ63",SqlDbType.Date),
                        new SqlParameter("@CQ64",SqlDbType.Date),
                        new SqlParameter("@CQ65",SqlDbType.Date),
                        new SqlParameter("@CQ66",SqlDbType.Date),
                        new SqlParameter("@CQ67",SqlDbType.Date),
                        new SqlParameter("@CQ68",SqlDbType.Date),
                        new SqlParameter("@CQ69",SqlDbType.Date),
                        new SqlParameter("@CQ70",SqlDbType.Date),
                        new SqlParameter("@CQ71",SqlDbType.Date),
                        new SqlParameter("@CQ72",SqlDbType.Date),
                        new SqlParameter("@CQ73",SqlDbType.Date),
                        new SqlParameter("@CQ74",SqlDbType.Date),
                        new SqlParameter("@CQ75",SqlDbType.Date),
                        new SqlParameter("@CQ76",SqlDbType.Date),
                        new SqlParameter("@CQ77",SqlDbType.Date),
                        new SqlParameter("@CQ78",SqlDbType.Date),
                        new SqlParameter("@CQ79",SqlDbType.NVarChar,10),
                        new SqlParameter("@CQ80",SqlDbType.NVarChar,10),
                        new SqlParameter("@CQ81",SqlDbType.NVarChar,10),
                        new SqlParameter("@CQ82",SqlDbType.NVarChar,10),
                        new SqlParameter("@CQ83",SqlDbType.NVarChar,10),
                        new SqlParameter("@CQ84",SqlDbType.NVarChar,10),
                        new SqlParameter("@CQ85",SqlDbType.NVarChar,10),
                        new SqlParameter("@CQ86",SqlDbType.NVarChar,10),
                        new SqlParameter("@CQ87",SqlDbType.NVarChar,150),
                        new SqlParameter("@CQ88",SqlDbType.NVarChar,150),
                        new SqlParameter("@CQ89",SqlDbType.NVarChar,20),
                        new SqlParameter("@CQ90",SqlDbType.NVarChar,20),
                        new SqlParameter("@CQ91",SqlDbType.NVarChar,20),
                        new SqlParameter("@CQ92",SqlDbType.NVarChar,20),
                        new SqlParameter("@CQ93",SqlDbType.NVarChar,20),
                        new SqlParameter("@CQ94",SqlDbType.NVarChar,20),
                        new SqlParameter("@CQ95",SqlDbType.NVarChar,20),
                        new SqlParameter("@CQ96",SqlDbType.Date),
                        new SqlParameter("@CQ97",SqlDbType.NVarChar,255),
                        new SqlParameter("@CQ98",SqlDbType.NVarChar,150),
                        new SqlParameter("@CQ108",SqlDbType.NVarChar,150),
                        new SqlParameter("@CQ109",SqlDbType.NVarChar,10),
                        new SqlParameter("@CQ110",SqlDbType.NVarChar,10),
                        new SqlParameter("@CQ111",SqlDbType.NVarChar,10)
                    };
                    parameter[0].Value = model.CQ01;
                    parameter[1].Value = model.CQ02;
                    parameter[2].Value = model.CQ03;
                    parameter[3].Value = model.CQ04;
                    parameter[4].Value = model.CQ05;
                    parameter[5].Value = model.CQ06;
                    parameter[6].Value = model.CQ07;
                    parameter[7].Value = model.CQ08;
                    parameter[8].Value = model.CQ09;
                    parameter[9].Value = model.CQ10;
                    parameter[10].Value = model.CQ11;
                    parameter[11].Value = model.CQ12;
                    parameter[12].Value = model.CQ13;
                    parameter[13].Value = model.CQ14;
                    parameter[14].Value = model.CQ15;
                    parameter[15].Value = model.CQ16;
                    parameter[16].Value = model.CQ17;
                    parameter[17].Value = model.CQ18;
                    parameter[18].Value = model.CQ19;
                    parameter[19].Value = model.CQ20;
                    parameter[20].Value = model.CQ21;
                    parameter[21].Value = model.CQ22;
                    parameter[22].Value = model.CQ23;
                    parameter[23].Value = model.CQ24;
                    parameter[24].Value = model.CQ25;
                    parameter[25].Value = model.CQ26;
                    parameter[26].Value = model.CQ27;
                    parameter[27].Value = model.CQ28;
                    parameter[28].Value = model.CQ29;
                    parameter[29].Value = model.CQ30;
                    parameter[30].Value = model.CQ31;
                    parameter[31].Value = model.CQ32;
                    parameter[32].Value = model.CQ33;
                    parameter[33].Value = model.CQ34;
                    parameter[34].Value = model.CQ35;
                    parameter[35].Value = model.CQ36;
                    parameter[36].Value = model.CQ37;
                    parameter[37].Value = model.CQ38;
                    parameter[38].Value = model.CQ39;
                    parameter[39].Value = model.CQ40;
                    parameter[40].Value = model.CQ41;
                    parameter[41].Value = model.CQ42;
                    parameter[42].Value = model.CQ43;
                    parameter[43].Value = model.CQ44;
                    parameter[44].Value = model.CQ45;
                    parameter[45].Value = model.CQ46;
                    parameter[46].Value = model.CQ47;
                    parameter[47].Value = model.CQ48;
                    parameter[48].Value = model.CQ49;
                    parameter[49].Value = model.CQ50;
                    parameter[50].Value = model.CQ51;
                    parameter[51].Value = model.CQ52;
                    parameter[52].Value = model.CQ53;
                    parameter[53].Value = model.CQ54;
                    parameter[54].Value = model.CQ55;
                    parameter[55].Value = model.CQ56;
                    parameter[56].Value = model.CQ57;
                    parameter[57].Value = model.CQ58;
                    parameter[58].Value = model.CQ59;
                    parameter[59].Value = model.CQ60;
                    parameter[60].Value = model.CQ61;
                    parameter[61].Value = model.CQ62;
                    parameter[62].Value = model.CQ63;
                    parameter[63].Value = model.CQ64;
                    parameter[64].Value = model.CQ65;
                    parameter[65].Value = model.CQ66;
                    parameter[66].Value = model.CQ67;
                    parameter[67].Value = model.CQ68;
                    parameter[68].Value = model.CQ69;
                    parameter[69].Value = model.CQ70;
                    parameter[70].Value = model.CQ71;
                    parameter[71].Value = model.CQ72;
                    parameter[72].Value = model.CQ73;
                    parameter[73].Value = model.CQ74;
                    parameter[74].Value = model.CQ75;
                    parameter[75].Value = model.CQ76;
                    parameter[76].Value = model.CQ77;
                    parameter[77].Value = model.CQ78;
                    parameter[78].Value = model.CQ79;
                    parameter[79].Value = model.CQ80;
                    parameter[80].Value = model.CQ81;
                    parameter[81].Value = model.CQ82;
                    parameter[82].Value = model.CQ83;
                    parameter[83].Value = model.CQ84;
                    parameter[84].Value = model.CQ85;
                    parameter[85].Value = model.CQ86;
                    parameter[86].Value = model.CQ87;
                    parameter[87].Value = model.CQ88;
                    parameter[88].Value = model.CQ89;
                    parameter[89].Value = model.CQ90;
                    parameter[90].Value = model.CQ91;
                    parameter[91].Value = model.CQ92;
                    parameter[92].Value = model.CQ93;
                    parameter[93].Value = model.CQ94;
                    parameter[94].Value = model.CQ95;
                    parameter[95].Value = model.CQ96;
                    parameter[96].Value = model.CQ97;
                    parameter[97].Value = model.CQ98;
                    parameter[98].Value = model.CQ108;
                    parameter[99].Value = model.CQ109;
                    parameter[100].Value = model.CQ110;
                    parameter[101].Value = model.CQ111;
                    cmd.Parameters.Clear( );
                    SqlHelper.PrepareCommand( cmd ,conn ,tran ,strSql.ToString( ) ,parameter );
                    cmd.CommandText = strSql.ToString( );
                    cmd.ExecuteNonQuery( );
                    StringBuilder strS = new StringBuilder( );
                    strS.Append( "UPDATE R_PQCQ SET " );
                    strS.AppendFormat( "CQ02='{0}',",model.CQ02 );
                    strS.AppendFormat( "CQ03='{0}'," ,model.CQ03 );
                    strS.AppendFormat( "CQ04='{0}'," ,model.CQ04 );
                    strS.AppendFormat( "CQ05='{0}'," ,model.CQ05 );
                    strS.AppendFormat( "CQ06='{0}'," ,model.CQ06 );
                    strS.AppendFormat( "CQ07='{0}'," ,model.CQ07 );
                    strS.AppendFormat( "CQ08='{0}'," ,model.CQ08 );
                    strS.AppendFormat( "CQ09='{0}'," ,model.CQ09 );
                    strS.AppendFormat( "CQ10='{0}'," ,model.CQ10 );
                    strS.AppendFormat( "CQ11='{0}'," ,model.CQ11 );
                    strS.AppendFormat( "CQ12='{0}'," ,model.CQ12 );
                    strS.AppendFormat( "CQ13='{0}'," ,model.CQ13 );
                    strS.AppendFormat( "CQ14='{0}'," ,model.CQ14 );
                    strS.AppendFormat( "CQ15='{0}'," ,model.CQ15 );
                    strS.AppendFormat( "CQ16='{0}'," ,model.CQ16 );
                    strS.AppendFormat( "CQ17='{0}'," ,model.CQ17 );
                    strS.AppendFormat( "CQ18='{0}'," ,model.CQ18 );
                    strS.AppendFormat( "CQ19='{0}'," ,model.CQ19 );
                    strS.AppendFormat( "CQ20='{0}'," ,model.CQ20 );
                    strS.AppendFormat( "CQ21='{0}'," ,model.CQ21 );
                    strS.AppendFormat( "CQ22='{0}'," ,model.CQ22 );
                    strS.AppendFormat( "CQ23='{0}'," ,model.CQ23 );
                    strS.AppendFormat( "CQ24='{0}'," ,model.CQ24 );
                    strS.AppendFormat( "CQ25='{0}'," ,model.CQ25 );
                    strS.AppendFormat( "CQ26='{0}'," ,model.CQ26 );
                    strS.AppendFormat( "CQ27='{0}'," ,model.CQ27 );
                    strS.AppendFormat( "CQ28='{0}'," ,model.CQ28 );
                    strS.AppendFormat( "CQ29='{0}'," ,model.CQ29 );
                    strS.AppendFormat( "CQ30='{0}'," ,model.CQ30 );
                    strS.AppendFormat( "CQ31='{0}'," ,model.CQ31 );
                    strS.AppendFormat( "CQ32='{0}'," ,model.CQ32 );
                    strS.AppendFormat( "CQ33='{0}'," ,model.CQ33 );
                    strS.AppendFormat( "CQ35='{0}'," ,model.CQ35 );
                    strS.AppendFormat( "CQ36='{0}'," ,model.CQ36 );
                    strS.AppendFormat( "CQ37='{0}'," ,model.CQ37 );
                    strS.AppendFormat( "CQ38='{0}'," ,model.CQ38 );
                    strS.AppendFormat( "CQ39='{0}'," ,model.CQ39 );
                    strS.AppendFormat( "CQ40='{0}'," ,model.CQ40 );
                    strS.AppendFormat( "CQ41='{0}'," ,model.CQ41 );
                    strS.AppendFormat( "CQ42='{0}'," ,model.CQ42 );
                    strS.AppendFormat( "CQ43='{0}'," ,model.CQ43 );
                    strS.AppendFormat( "CQ44='{0}'," ,model.CQ44 );
                    strS.AppendFormat( "CQ45='{0}'," ,model.CQ45 );
                    strS.AppendFormat( "CQ46='{0}'," ,model.CQ46 );
                    strS.AppendFormat( "CQ47='{0}'," ,model.CQ47 );
                    strS.AppendFormat( "CQ48='{0}'," ,model.CQ48 );
                    strS.AppendFormat( "CQ49='{0}'," ,model.CQ49 );
                    strS.AppendFormat( "CQ50='{0}'," ,model.CQ50 );
                    strS.AppendFormat( "CQ51='{0}'," ,model.CQ51 );
                    strS.AppendFormat( "CQ52='{0}'," ,model.CQ52 );
                    strS.AppendFormat( "CQ53='{0}'," ,model.CQ53 );
                    strS.AppendFormat( "CQ54='{0}'," ,model.CQ54 );
                    strS.AppendFormat( "CQ55='{0}'," ,model.CQ55 );
                    strS.AppendFormat( "CQ56='{0}'," ,model.CQ56 );
                    strS.AppendFormat( "CQ57='{0}'," ,model.CQ57 );
                    strS.AppendFormat( "CQ58='{0}'," ,model.CQ58 );
                    strS.AppendFormat( "CQ59='{0}'," ,model.CQ59 );
                    strS.AppendFormat( "CQ60='{0}'," ,model.CQ60 );
                    strS.AppendFormat( "CQ61='{0}'," ,model.CQ61 );
                    strS.AppendFormat( "CQ62='{0}'," ,model.CQ62 );
                    strS.AppendFormat( "CQ63='{0}'," ,model.CQ63 );
                    strS.AppendFormat( "CQ64='{0}'," ,model.CQ64 );
                    strS.AppendFormat( "CQ65='{0}'," ,model.CQ65 );
                    strS.AppendFormat( "CQ66='{0}'," ,model.CQ66 );
                    strS.AppendFormat( "CQ67='{0}'," ,model.CQ67 );
                    strS.AppendFormat( "CQ68='{0}'," ,model.CQ68 );
                    strS.AppendFormat( "CQ69='{0}'," ,model.CQ69 );
                    strS.AppendFormat( "CQ70='{0}'," ,model.CQ70 );
                    strS.AppendFormat( "CQ71='{0}'," ,model.CQ71 );
                    strS.AppendFormat( "CQ72='{0}'," ,model.CQ72 );
                    strS.AppendFormat( "CQ73='{0}'," ,model.CQ73 );
                    strS.AppendFormat( "CQ74='{0}'," ,model.CQ74 );
                    strS.AppendFormat( "CQ75='{0}'," ,model.CQ75 );
                    strS.AppendFormat( "CQ76='{0}'," ,model.CQ76 );
                    strS.AppendFormat( "CQ77='{0}'," ,model.CQ77 );
                    strS.AppendFormat( "CQ78='{0}'," ,model.CQ78 );
                    strS.AppendFormat( "CQ79='{0}'," ,model.CQ79 );
                    strS.AppendFormat( "CQ80='{0}'," ,model.CQ80 );
                    strS.AppendFormat( "CQ81='{0}'," ,model.CQ81 );
                    strS.AppendFormat( "CQ82='{0}'," ,model.CQ82 );
                    strS.AppendFormat( "CQ83='{0}'," ,model.CQ83 );
                    strS.AppendFormat( "CQ84='{0}'," ,model.CQ84 );
                    strS.AppendFormat( "CQ85='{0}'," ,model.CQ85 );
                    strS.AppendFormat( "CQ86='{0}'," ,model.CQ86 );
                    strS.AppendFormat( "CQ87='{0}'," ,model.CQ87 );
                    strS.AppendFormat( "CQ88='{0}'," ,model.CQ88 );
                    strS.AppendFormat( "CQ89='{0}'," ,model.CQ89 );
                    strS.AppendFormat( "CQ90='{0}'," ,model.CQ90 );
                    strS.AppendFormat( "CQ91='{0}'," ,model.CQ91 );
                    strS.AppendFormat( "CQ92='{0}'," ,model.CQ92 );
                    strS.AppendFormat( "CQ93='{0}'," ,model.CQ93 );
                    strS.AppendFormat( "CQ94='{0}'," ,model.CQ94 );
                    strS.AppendFormat( "CQ95='{0}'," ,model.CQ95 );
                    strS.AppendFormat( "CQ96='{0}'," ,model.CQ96 );
                    strS.AppendFormat( "CQ97='{0}'," ,model.CQ97 );
                    strS.AppendFormat( "CQ98='{0}'," ,model.CQ98 );
                    strS.AppendFormat( "CQ108='{0}'," ,model.CQ108 );
                    strS.AppendFormat( "CQ109='{0}'," ,model.CQ109 );
                    strS.AppendFormat( "CQ110='{0}'," ,model.CQ110 );
                    strS.AppendFormat( "CQ111='{0}'" ,model.CQ111 );
                    strS.AppendFormat( " WHERE CQ01='{0}'" ,model.CQ01 );
                    cmd.CommandText = Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.CQ01 ,strS.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd );
                    cmd.ExecuteNonQuery( );
                    tran.Commit( );
                    return true;
                }
                catch {
                    tran.Rollback( );
                    return false;
                }
                finally
                {
                    cmd.Dispose( );
                    conn.Close( );
                }
            }
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfOnly ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT CQ01,CQ02,CQ03,CQ04,CQ99,CQ100 FROM R_PQCQ" );

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
            strSql.Append( "SELECT COUNT(1) FROM (SELECT DISTINCT CQ01,CQ02,CQ04,CQ03,CQ14,CQ99,CQ100 FROM R_PQCQ) A" );

            object obj = SqlHelper.GetSingle( strSql.ToString( ) );
            if ( obj != null )
                return Convert.ToInt32( obj );
            else
                return 0;
        }

        /// <summary>
        /// 获取分页数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTableByChange ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT  DISTINCT CQ01,CQ02,CQ03,CQ04,CQ14,CQ99,CQ100,RES05,CQ114,CQ112,CONVERT(FLOAT,CONVERT(DECIMAL(11,2),CQ102*CQ103*CQ105)) U0 FROM (" );
            strSql.Append( " SELECT ROW_NUMBER() OVER(" );
            strSql.Append( " ORDER BY T.idx DESC" );
            strSql.Append( ") AS Row,T.* FROM R_PQCQ T" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( " ) TT LEFT JOIN R_REVIEWS B ON TT.CQ01=B.RES06" );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public MulaolaoLibrary.yanpinchangqiancehuaLibrary GetDataTableOfModel ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQCQ" );
            strSql.Append( " WHERE CQ01=@CQ01" );
            SqlParameter[] parameter = {
                new SqlParameter("@CQ01",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da != null && da.Rows.Count > 0 )
                return GetModel( da.Rows[0] );
            else
                return null;
        }

        public MulaolaoLibrary.yanpinchangqiancehuaLibrary GetModel ( DataRow row )
        {
            MulaolaoLibrary.yanpinchangqiancehuaLibrary model = new MulaolaoLibrary.yanpinchangqiancehuaLibrary( );

            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    model.idx = int.Parse( row["idx"].ToString( ) );
                if ( row["CQ01"] != null && row["CQ01"].ToString( ) != "" )
                    model.CQ01 = row["CQ01"].ToString( );
                if ( row["CQ02"] != null && row["CQ02"].ToString( ) != "" )
                    model.CQ02 = row["CQ02"].ToString( );
                if ( row["CQ03"] != null && row["CQ03"].ToString( ) != "" )
                    model.CQ03 = row["CQ03"].ToString( );
                if ( row["CQ04"] != null && row["CQ04"].ToString( ) != "" )
                    model.CQ04 = row["CQ04"].ToString( );
                if ( row["CQ05"] != null && row["CQ05"].ToString( ) != "" )
                    model.CQ05 = row["CQ05"].ToString( );
                if ( row["CQ06"] != null && row["CQ06"].ToString( ) != "" )
                    model.CQ06 = DateTime.Parse( row["CQ06"].ToString( ) );
                if ( row["CQ07"] != null && row["CQ07"].ToString( ) != "" )
                    model.CQ07 = DateTime.Parse( row["CQ07"].ToString( ) );
                if ( row["CQ08"] != null && row["CQ08"].ToString( ) != "" )
                    model.CQ08 = row["CQ08"].ToString( );
                if ( row["CQ09"] != null && row["CQ09"].ToString( ) != "" )
                    model.CQ09 = row["CQ09"].ToString( );
                if ( row["CQ10"] != null && row["CQ10"].ToString( ) != "" )
                    model.CQ10 = row["CQ10"].ToString( );
                if ( row["CQ11"] != null && row["CQ11"].ToString( ) != "" )
                    model.CQ11 = row["CQ11"].ToString( );
                if ( row["CQ12"] != null && row["CQ12"].ToString( ) != "" )
                    model.CQ12 = row["CQ12"].ToString( );
                if ( row["CQ13"] != null && row["CQ13"].ToString( ) != "" )
                    model.CQ13 = row["CQ13"].ToString( );
                if ( row["CQ14"] != null && row["CQ14"].ToString( ) != "" )
                    model.CQ14 = int.Parse( row["CQ14"].ToString( ) );
                if ( row["CQ15"] != null && row["CQ15"].ToString( ) != "" )
                    model.CQ15 = row["CQ15"].ToString( );
                if ( row["CQ16"] != null && row["CQ16"].ToString( ) != "" )
                    model.CQ16 = row["CQ16"].ToString( );
                if ( row["CQ17"] != null && row["CQ17"].ToString( ) != "" )
                    model.CQ17 = row["CQ17"].ToString( );
                if ( row["CQ18"] != null && row["CQ18"].ToString( ) != "" )
                    model.CQ18 = row["CQ18"].ToString( );
                if ( row["CQ19"] != null && row["CQ19"].ToString( ) != "" )
                    model.CQ19 = row["CQ19"].ToString( );
                if ( row["CQ20"] != null && row["CQ20"].ToString( ) != "" )
                    model.CQ20 = row["CQ20"].ToString( );
                if ( row["CQ21"] != null && row["CQ21"].ToString( ) != "" )
                    model.CQ21 = row["CQ21"].ToString( );
                if ( row["CQ22"] != null && row["CQ22"].ToString( ) != "" )
                    model.CQ22 = row["CQ22"].ToString( );
                if ( row["CQ23"] != null && row["CQ23"].ToString( ) != "" )
                    model.CQ23 = row["CQ23"].ToString( );
                if ( row["CQ24"] != null && row["CQ24"].ToString( ) != "" )
                    model.CQ24 = row["CQ24"].ToString( );
                if ( row["CQ25"] != null && row["CQ25"].ToString( ) != "" )
                    model.CQ25 = row["CQ25"].ToString( );
                if ( row["CQ26"] != null && row["CQ26"].ToString( ) != "" )
                    model.CQ26 = row["CQ26"].ToString( );
                if ( row["CQ27"] != null && row["CQ27"].ToString( ) != "" )
                    model.CQ27 = row["CQ27"].ToString( );
                if ( row["CQ28"] != null && row["CQ28"].ToString( ) != "" )
                    model.CQ28 = row["CQ28"].ToString( );
                if ( row["CQ29"] != null && row["CQ29"].ToString( ) != "" )
                    model.CQ29 = row["CQ29"].ToString( );
                if ( row["CQ30"] != null && row["CQ30"].ToString( ) != "" )
                    model.CQ30 = row["CQ30"].ToString( );
                if ( row["CQ31"] != null && row["CQ31"].ToString( ) != "" )
                    model.CQ31 = row["CQ31"].ToString( );
                if ( row["CQ32"] != null && row["CQ32"].ToString( ) != "" )
                    model.CQ32 = row["CQ32"].ToString( );
                if ( row["CQ33"] != null && row["CQ33"].ToString( ) != "" )
                    model.CQ33 = row["CQ33"].ToString( );
                if ( row["CQ35"] != null && row["CQ35"].ToString( ) != "" )
                    model.CQ35 = row["CQ35"].ToString( );
                if ( row["CQ36"] != null && row["CQ36"].ToString( ) != "" )
                    model.CQ36 = row["CQ36"].ToString( );
                if ( row["CQ37"] != null && row["CQ37"].ToString( ) != "" )
                    model.CQ37 = row["CQ37"].ToString( );
                if ( row["CQ38"] != null && row["CQ38"].ToString( ) != "" )
                    model.CQ38 = row["CQ38"].ToString( );
                if ( row["CQ39"] != null && row["CQ39"].ToString( ) != "" )
                    model.CQ39 = row["CQ39"].ToString( );
                if ( row["CQ40"] != null && row["CQ40"].ToString( ) != "" )
                    model.CQ40 = row["CQ40"].ToString( );
                if ( row["CQ41"] != null && row["CQ41"].ToString( ) != "" )
                    model.CQ41 = row["CQ41"].ToString( );
                if ( row["CQ42"] != null && row["CQ42"].ToString( ) != "" )
                    model.CQ42 = row["CQ42"].ToString( );
                if ( row["CQ43"] != null && row["CQ43"].ToString( ) != "" )
                    model.CQ43 = row["CQ43"].ToString( );
                if ( row["CQ44"] != null && row["CQ44"].ToString( ) != "" )
                    model.CQ44 = row["CQ44"].ToString( );
                if ( row["CQ45"] != null && row["CQ45"].ToString( ) != "" )
                    model.CQ45 = row["CQ45"].ToString( );
                if ( row["CQ46"] != null && row["CQ46"].ToString( ) != "" )
                    model.CQ46 = int.Parse( row["CQ46"].ToString( ) );
                if ( row["CQ47"] != null && row["CQ47"].ToString( ) != "" )
                    model.CQ47 = int.Parse( row["CQ47"].ToString( ) );
                if ( row["CQ48"] != null && row["CQ48"].ToString( ) != "" )
                    model.CQ48 = int.Parse( row["CQ48"].ToString( ) );
                if ( row["CQ49"] != null && row["CQ49"].ToString( ) != "" )
                    model.CQ49 = int.Parse( row["CQ49"].ToString( ) );
                if ( row["CQ50"] != null && row["CQ50"].ToString( ) != "" )
                    model.CQ50 = int.Parse( row["CQ50"].ToString( ) );
                if ( row["CQ51"] != null && row["CQ51"].ToString( ) != "" )
                    model.CQ51 = int.Parse( row["CQ51"].ToString( ) );
                if ( row["CQ52"] != null && row["CQ52"].ToString( ) != "" )
                    model.CQ52 = int.Parse( row["CQ52"].ToString( ) );
                if ( row["CQ53"] != null && row["CQ53"].ToString( ) != "" )
                    model.CQ53 = int.Parse( row["CQ53"].ToString( ) );
                if ( row["CQ54"] != null && row["CQ54"].ToString( ) != "" )
                    model.CQ54 = int.Parse( row["CQ54"].ToString( ) );
                if ( row["CQ55"] != null && row["CQ55"].ToString( ) != "" )
                    model.CQ55 = int.Parse( row["CQ55"].ToString( ) );
                if ( row["CQ56"] != null && row["CQ56"].ToString( ) != "" )
                    model.CQ56 = int.Parse( row["CQ56"].ToString( ) );
                if ( row["CQ57"] != null && row["CQ57"].ToString( ) != "" )
                    model.CQ57 = DateTime.Parse( row["CQ57"].ToString( ) );
                if ( row["CQ58"] != null && row["CQ58"].ToString( ) != "" )
                    model.CQ58 = DateTime.Parse( row["CQ58"].ToString( ) );
                if ( row["CQ59"] != null && row["CQ59"].ToString( ) != "" )
                    model.CQ59 = DateTime.Parse( row["CQ59"].ToString( ) );
                if ( row["CQ60"] != null && row["CQ60"].ToString( ) != "" )
                    model.CQ60 = DateTime.Parse( row["CQ60"].ToString( ) );
                if ( row["CQ61"] != null && row["CQ61"].ToString( ) != "" )
                    model.CQ61 = DateTime.Parse( row["CQ61"].ToString( ) );
                if ( row["CQ62"] != null && row["CQ62"].ToString( ) != "" )
                    model.CQ62 = DateTime.Parse( row["CQ62"].ToString( ) );
                if ( row["CQ63"] != null && row["CQ63"].ToString( ) != "" )
                    model.CQ63 = DateTime.Parse( row["CQ63"].ToString( ) );
                if ( row["CQ64"] != null && row["CQ64"].ToString( ) != "" )
                    model.CQ64 = DateTime.Parse( row["CQ64"].ToString( ) );
                if ( row["CQ65"] != null && row["CQ65"].ToString( ) != "" )
                    model.CQ65 = DateTime.Parse( row["CQ65"].ToString( ) );
                if ( row["CQ66"] != null && row["CQ66"].ToString( ) != "" )
                    model.CQ66 = DateTime.Parse( row["CQ66"].ToString( ) );
                if ( row["CQ67"] != null && row["CQ67"].ToString( ) != "" )
                    model.CQ67 = DateTime.Parse( row["CQ67"].ToString( ) );
                if ( row["CQ68"] != null && row["CQ68"].ToString( ) != "" )
                    model.CQ68 = DateTime.Parse( row["CQ68"].ToString( ) );
                if ( row["CQ69"] != null && row["CQ69"].ToString( ) != "" )
                    model.CQ69 = DateTime.Parse( row["CQ69"].ToString( ) );
                if ( row["CQ70"] != null && row["CQ70"].ToString( ) != "" )
                    model.CQ70 = DateTime.Parse( row["CQ70"].ToString( ) );
                if ( row["CQ71"] != null && row["CQ71"].ToString( ) != "" )
                    model.CQ71 = DateTime.Parse( row["CQ71"].ToString( ) );
                if ( row["CQ72"] != null && row["CQ72"].ToString( ) != "" )
                    model.CQ72 = DateTime.Parse( row["CQ72"].ToString( ) );
                if ( row["CQ73"] != null && row["CQ73"].ToString( ) != "" )
                    model.CQ73 = DateTime.Parse( row["CQ73"].ToString( ) );
                if ( row["CQ74"] != null && row["CQ74"].ToString( ) != "" )
                    model.CQ74 = DateTime.Parse( row["CQ74"].ToString( ) );
                if ( row["CQ75"] != null && row["CQ75"].ToString( ) != "" )
                    model.CQ75 = DateTime.Parse( row["CQ75"].ToString( ) );
                if ( row["CQ76"] != null && row["CQ76"].ToString( ) != "" )
                    model.CQ76 = DateTime.Parse( row["CQ76"].ToString( ) );
                if ( row["CQ77"] != null && row["CQ77"].ToString( ) != "" )
                    model.CQ77 = DateTime.Parse( row["CQ77"].ToString( ) );
                if ( row["CQ78"] != null && row["CQ78"].ToString( ) != "" )
                    model.CQ78 = DateTime.Parse( row["CQ78"].ToString( ) );
                if ( row["CQ79"] != null && row["CQ79"].ToString( ) != "" )
                    model.CQ79 = row["CQ79"].ToString( );
                if ( row["CQ80"] != null && row["CQ80"].ToString( ) != "" )
                    model.CQ80 = row["CQ80"].ToString( );
                if ( row["CQ81"] != null && row["CQ81"].ToString( ) != "" )
                    model.CQ81 = row["CQ81"].ToString( );
                if ( row["CQ82"] != null && row["CQ82"].ToString( ) != "" )
                    model.CQ82 = row["CQ82"].ToString( );
                if ( row["CQ83"] != null && row["CQ83"].ToString( ) != "" )
                    model.CQ83 = row["CQ83"].ToString( );
                if ( row["CQ84"] != null && row["CQ84"].ToString( ) != "" )
                    model.CQ84 = row["CQ84"].ToString( );
                if ( row["CQ85"] != null && row["CQ85"].ToString( ) != "" )
                    model.CQ85 = row["CQ85"].ToString( );
                if ( row["CQ86"] != null && row["CQ86"].ToString( ) != "" )
                    model.CQ86 = row["CQ86"].ToString( );
                if ( row["CQ87"] != null && row["CQ87"].ToString( ) != "" )
                    model.CQ87 = row["CQ87"].ToString( );
                if ( row["CQ88"] != null && row["CQ88"].ToString( ) != "" )
                    model.CQ88 = row["CQ88"].ToString( );
                if ( row["CQ89"] != null && row["CQ89"].ToString( ) != "" )
                    model.CQ89 = row["CQ89"].ToString( );
                if ( row["CQ90"] != null && row["CQ90"].ToString( ) != "" )
                    model.CQ90 = row["CQ90"].ToString( );
                if ( row["CQ91"] != null && row["CQ91"].ToString( ) != "" )
                    model.CQ91 = row["CQ91"].ToString( );
                if ( row["CQ92"] != null && row["CQ92"].ToString( ) != "" )
                    model.CQ92 = row["CQ92"].ToString( );
                if ( row["CQ93"] != null && row["CQ93"].ToString( ) != "" )
                    model.CQ93 = row["CQ93"].ToString( );
                if ( row["CQ94"] != null && row["CQ94"].ToString( ) != "" )
                    model.CQ94 = row["CQ94"].ToString( );
                if ( row["CQ95"] != null && row["CQ95"].ToString( ) != "" )
                    model.CQ95 = row["CQ95"].ToString( );
                if ( row["CQ96"] != null && row["CQ96"].ToString( ) != "" )
                    model.CQ96 = DateTime.Parse( row["CQ96"].ToString( ) );
                if ( row["CQ98"] != null && row["CQ98"].ToString( ) != "" )
                    model.CQ98 = row["CQ98"].ToString( );
                if ( row["CQ108"] != null && row["CQ108"].ToString( ) != "" )
                    model.CQ108 = row["CQ108"].ToString( );
                if ( row["CQ109"] != null && row["CQ109"].ToString( ) != "" )
                    model.CQ109 = row["CQ109"].ToString( );
                if ( row["CQ110"] != null && row["CQ110"].ToString( ) != "" )
                    model.CQ110 = row["CQ110"].ToString( );
                if ( row["CQ111"] != null && row["CQ111"].ToString( ) != "" )
                    model.CQ111 = row["CQ111"].ToString( );
            }

            return model;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.yanpinchangqiancehuaLibrary GetDataModel ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,CQ01,CQ99,CQ100,CQ101,CQ102,CQ103,CQ104,CQ105,CQ106,CQ107,CQ112,CQ113,CQ114 FROM R_PQCQ" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = idx;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da != null && da.Rows.Count > 0 )
                return GetModels( da.Rows[0] );
            else
                return null;
        }

        public MulaolaoLibrary.yanpinchangqiancehuaLibrary GetModels ( DataRow row )
        {
            MulaolaoLibrary.yanpinchangqiancehuaLibrary model = new MulaolaoLibrary.yanpinchangqiancehuaLibrary( );

            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    model.idx = int.Parse( row["idx"].ToString( ) );
                if ( row["CQ01"] != null && row["CQ01"].ToString( ) != "" )
                    model.CQ01 = row["CQ01"].ToString( );
                if ( row["CQ99"] != null && row["CQ99"].ToString( ) != "" )
                    model.CQ99 = row["CQ99"].ToString( );
                if ( row["CQ100"] != null && row["CQ100"].ToString( ) != "" )
                    model.CQ100 = row["CQ100"].ToString( );
                if ( row["CQ101"] != null && row["CQ101"].ToString( ) != "" )
                    model.CQ101 = row["CQ101"].ToString( );
                if ( row["CQ102"] != null && row["CQ102"].ToString( ) != "" )
                    model.CQ102 = int.Parse( row["CQ102"].ToString( ) );
                if ( row["CQ103"] != null && row["CQ103"].ToString( ) != "" )
                    model.CQ103 = decimal.Parse( row["CQ103"].ToString( ) );
                if ( row["CQ104"] != null && row["CQ104"].ToString( ) != "" )
                    model.CQ104 = row["CQ104"].ToString( );
                if ( row["CQ105"] != null && row["CQ105"].ToString( ) != "" )
                    model.CQ105 = decimal.Parse( row["CQ105"].ToString( ) );
                if ( row["CQ106"] != null && row["CQ106"].ToString( ) != "" )
                    model.CQ106 = DateTime.Parse( row["CQ106"].ToString( ) );
                if ( row["CQ107"] != null && row["CQ107"].ToString( ) != "" )
                    model.CQ107 = DateTime.Parse( row["CQ107"].ToString( ) );
                if ( row [ "CQ112" ] != null && row [ "CQ112" ] . ToString ( ) != "" )
                    model . CQ112 = row [ "CQ112" ] . ToString ( );
                if ( row [ "CQ113" ] != null && row [ "CQ113" ] . ToString ( ) != "" )
                    model . CQ113 = DateTime . Parse ( row [ "CQ113" ] . ToString ( ) );
                if ( row [ "CQ114" ] != null && row [ "CQ114" ] . ToString ( ) != "" )
                    model . CQ114 = row [ "CQ114" ] . ToString ( );
            }

            return model;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfTable ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,CQ99,CQ100,CQ101,CQ102,CQ103,CQ104,CQ105,CQ106,CQ107,CQ112,CQ113,CQ114 FROM R_PQCQ" );
            strSql.Append( " WHERE " + strWhere );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 增加一行记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="tableNum"></param>
        /// <param name="tableName"></param>
        /// <param name="logins"></param>
        /// <param name="dtOne"></param>
        /// <param name="stateOf"></param>
        /// <param name="stateOfOdd"></param>
        /// <returns></returns>
        public bool Add ( MulaolaoLibrary.yanpinchangqiancehuaLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQCQ (" );
            strSql.Append( "CQ99,CQ100,CQ101,CQ102,CQ103,CQ104,CQ105,CQ106,CQ107,CQ01,CQ114)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')" ,model.CQ99 ,model.CQ100 ,model.CQ101 ,model.CQ102 ,model.CQ103 ,model.CQ104 ,model.CQ105 ,model.CQ106 ,model.CQ107 ,model.CQ01 ,model . CQ114 );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.CQ01 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// 编辑一行记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="tableNum"></param>
        /// <param name="tableName"></param>
        /// <param name="logins"></param>
        /// <param name="dtOne"></param>
        /// <param name="stateOf"></param>
        /// <param name="stateOfOdd"></param>
        /// <returns></returns>
        public bool Edit ( MulaolaoLibrary.yanpinchangqiancehuaLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQCQ SET " );
            strSql.AppendFormat( "CQ99='{0}'," ,model.CQ99 );
            strSql.AppendFormat( "CQ100='{0}'," ,model.CQ100 );
            strSql.AppendFormat( "CQ101='{0}'," ,model.CQ101 );
            strSql.AppendFormat( "CQ102='{0}'," ,model.CQ102 );
            strSql.AppendFormat( "CQ103='{0}'," ,model.CQ103 );
            strSql.AppendFormat( "CQ104='{0}'," ,model.CQ104 );
            strSql.AppendFormat( "CQ105='{0}'," ,model.CQ105 );
            strSql.AppendFormat( "CQ106='{0}'," ,model.CQ106 );
            strSql.AppendFormat( "CQ107='{0}'," ,model.CQ107 );
            strSql . AppendFormat ( "CQ114='{0}'" ,model . CQ114 );
            strSql .AppendFormat( " WHERE idx='{0}'" ,model.idx );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.CQ01 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }


        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="tableNum"></param>
        /// <param name="tableName"></param>
        /// <param name="logins"></param>
        /// <param name="dtOne"></param>
        /// <param name="stateOf"></param>
        /// <param name="stateOfOdd"></param>
        /// <returns></returns>
        public bool Delete ( MulaolaoLibrary.yanpinchangqiancehuaLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQCQ" );
            strSql.AppendFormat( " WHERE idx='{0}'" ,model.idx );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,MulaolaoBll . Drity . GetDt ( ) ,model.CQ01 ,strSql.ToString( ).Replace( "'" ,"''" ) ,"删除" ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取图片数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfPic ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT CQ34 FROM R_PQCQ" );
            strSql.Append( " WHERE CQ01=@CQ01" );
            SqlParameter[] parameter = {
                new SqlParameter("@CQ01",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 复制一单记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="tableNum"></param>
        /// <param name="tableName"></param>
        /// <param name="logins"></param>
        /// <param name="dtOne"></param>
        /// <param name="stateOf"></param>
        /// <param name="stateOfOdd"></param>
        /// <returns></returns>
        public bool Copy (string oddNum,string tableNum,string tableName,string logins,DateTime dtOne,string stateOf,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQCQ (CQ02,CQ03,CQ04,CQ05,CQ06,CQ07,CQ08,CQ09,CQ10,CQ11,CQ12,CQ13,CQ14,CQ15,CQ16,CQ17,CQ18,CQ19,CQ20,CQ21,CQ22,CQ23,CQ24,CQ25,CQ26,CQ27,CQ28,CQ29,CQ30,CQ31,CQ32,CQ33,CQ34,CQ35,CQ36,CQ37,CQ38,CQ39,CQ40,CQ41,CQ42,CQ43,CQ44,CQ45,CQ46,CQ47,CQ48,CQ49,CQ50,CQ51,CQ52,CQ53,CQ54,CQ55,CQ56,CQ57,CQ58,CQ59,CQ60,CQ61,CQ62,CQ63,CQ64,CQ65,CQ66,CQ67,CQ68,CQ69,CQ70,CQ71,CQ72,CQ73,CQ74,CQ75,CQ76,CQ77,CQ78,CQ79,CQ80,CQ81,CQ82,CQ83,CQ84,CQ85,CQ86,CQ87,CQ88,CQ99,CQ100,CQ101,CQ102,CQ103,CQ104,CQ105,CQ106,CQ107,CQ108,CQ109,CQ110,CQ111) SELECT CQ02,CQ03,CQ04,CQ05,CQ06,CQ07,CQ08,CQ09,CQ10,CQ11,CQ12,CQ13,CQ14,CQ15,CQ16,CQ17,CQ18,CQ19,CQ20,CQ21,CQ22,CQ23,CQ24,CQ25,CQ26,CQ27,CQ28,CQ29,CQ30,CQ31,CQ32,CQ33,CQ34,CQ35,CQ36,CQ37,CQ38,CQ39,CQ40,CQ41,CQ42,CQ43,CQ44,CQ45,CQ46,CQ47,CQ48,CQ49,CQ50,CQ51,CQ52,CQ53,CQ54,CQ55,CQ56,CQ57,CQ58,CQ59,CQ60,CQ61,CQ62,CQ63,CQ64,CQ65,CQ66,CQ67,CQ68,CQ69,CQ70,CQ71,CQ72,CQ73,CQ74,CQ75,CQ76,CQ77,CQ78,CQ79,CQ80,CQ81,CQ82,CQ83,CQ84,CQ85,CQ86,CQ87,CQ88,CQ99,CQ100,CQ101,CQ102,CQ103,CQ104,CQ105,CQ106,CQ107,CQ108,CQ109,CQ110,CQ111 FROM R_PQCQ " );
            strSql.AppendFormat( " WHERE CQ01='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 更改复制单号
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="tableNum"></param>
        /// <param name="tableName"></param>
        /// <param name="logins"></param>
        /// <param name="dtOne"></param>
        /// <param name="stateOf"></param>
        /// <param name="stateOfOdd"></param>
        /// <returns></returns>
        public bool CopyOf ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "UPDATE R_PQCQ SET CQ01='{0}' WHERE CQ01 IS NULL" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 删除复制数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="tableNum"></param>
        /// <param name="tableName"></param>
        /// <param name="logins"></param>
        /// <param name="dtOne"></param>
        /// <param name="stateOf"></param>
        /// <param name="stateOfOdd"></param>
        /// <returns></returns>
        public bool DeleteOfCopy ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQCQ WHERE CQ01 IS NULL" );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,"" ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取打印列表数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfPrintOne ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT CQ99,CQ100,CQ101,CQ102,CQ102*CQ103 U0,CQ102*CQ103*CQ105 U1,CQ103,CQ104,CQ105,CONVERT(NVARCHAR(20),CQ106,102) CQ106,CONVERT(NVARCHAR(20),CQ107,102) CQ107 FROM R_PQCQ" );
            strSql.Append( " WHERE CQ01=@CQ01" );
            SqlParameter[] parameter = {
                new SqlParameter("@CQ01",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfPrintTwo ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT CQ01,CQ02,CQ03,CQ04,CQ05,CONVERT(NVARCHAR(20),CQ06,102) CQ06,CONVERT(NVARCHAR(20),CQ07,102) CQ07,CQ08,CQ09,CQ10,CQ11,CQ12,CQ13,CQ14,CQ15,CQ16,CQ17,CQ18,CQ19,CQ20,CQ21,CQ22,CQ23,CQ24,CQ25,CQ26,CQ27,CQ28,CQ29,CQ30,CQ31,CQ32,CQ33,CQ34,CQ35,CQ36,CQ37,CQ38,CQ39,CQ40,CQ41,CQ42,CQ43,CQ44,CQ45,CQ46,CQ47,CQ48,CQ49,CQ50,CQ51,CQ52,CQ53,CQ54,CQ55,CQ56,CONVERT(NVARCHAR(20),CQ57,102) CQ57,CONVERT(NVARCHAR(20),CQ58,102) CQ58,CONVERT(NVARCHAR(20),CQ59,102) CQ59,CONVERT(NVARCHAR(20),CQ60,102) CQ60,CONVERT(NVARCHAR(20),CQ61,102) CQ61,CONVERT(NVARCHAR(20),CQ62,102) CQ62,CONVERT(NVARCHAR(20),CQ63,102) CQ63,CONVERT(NVARCHAR(20),CQ64,102) CQ64,CONVERT(NVARCHAR(20),CQ65,102) CQ65,CONVERT(NVARCHAR(20),CQ66,102) CQ66,CONVERT(NVARCHAR(20),CQ67,102) CQ67,CONVERT(NVARCHAR(20),CQ68,102) CQ68,CONVERT(NVARCHAR(20),CQ69,102) CQ69,CONVERT(NVARCHAR(20),CQ70,102) CQ70,CONVERT(NVARCHAR(20),CQ71,102) CQ71,CONVERT(NVARCHAR(20),CQ72,102) CQ72,CONVERT(NVARCHAR(20),CQ73,102) CQ73,CONVERT(NVARCHAR(20),CQ74,102) CQ74,CONVERT(NVARCHAR(20),CQ75,102) CQ75,CONVERT(NVARCHAR(20),CQ76,102) CQ76,CONVERT(NVARCHAR(20),CQ77,102) CQ77,CONVERT(NVARCHAR(20),CQ78,102) CQ78,CQ79,CQ80,CQ81,CQ82,CQ83,CQ84,CQ85,CQ86,CQ87,CQ88,CQ89,CQ90,CQ91,CQ92,CQ93,CQ94,CQ95,CONVERT(NVARCHAR(20),CQ96,102) CQ96,CQ108,CQ109,CQ110,CQ111 FROM R_PQCQ" );
            strSql.Append( " WHERE CQ01=@CQ01" );
            SqlParameter[] parameter = {
                new SqlParameter("@CQ01",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( string fileName )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT {0} FROM R_PQCQ" ,fileName );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }
    }
}

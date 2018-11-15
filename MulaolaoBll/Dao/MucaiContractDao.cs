using StudentMgr;
using System;
using System . Collections;
using System . Data;
using System . Data . SqlClient;
using System . Text;

namespace MulaolaoBll . Dao
{
    public class MucaiContractDao
    {
        /// <summary>
        /// 获取数据列表   单个字段
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnely ( string field )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT " );
            strSql.Append( field );
            strSql.Append( " FROM R_PQV" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表  单个字段
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableSupplied ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT PQV03,(SELECT DGA003 FROM TPADGA WHERE PQV03=DGA001) DGA002 FROM R_PQV" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetMucaiCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQV" );
            if ( !string.IsNullOrEmpty( strWhere.Trim( ) ) )
            {
                strSql.Append( " WHERE " + strWhere );
            }

            object obj = SqlHelper.GetSingle( strSql.ToString( ) );
            if ( obj == null )
                return 0;
            else
                return Convert.ToInt32( obj );
        }

        /// <summary>
        /// 获取总记录数  财务结账
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetMucaiCountOne ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQV TT,R_REVIEWS B WHERE TT.PQV76=B.RES06 AND RES05='执行' AND NOT EXISTS (SELECT 1 FROM R_PQAL C,R_PQAK D WHERE TT.idx=C.AL003 AND TT.PQV76=C.AL002 AND C.AL001=D.idx)" );
            if ( !string.IsNullOrEmpty( strWhere.Trim( ) ) )
            {
                strSql.Append( " AND " + strWhere );
            }

            object obj = SqlHelper.GetSingle( strSql.ToString( ) );
            if ( obj == null )
                return 0;
            else
                return Convert.ToInt32( obj );
        }

        /// <summary>
        /// 分页获取数据集
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTableByPage ( string strWhere ,string orderby ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT TT.idx,PQV11,PQV12,PQV13,PQV68,PQV69,PQV70,PQV76,PQV01,PQV77,PQV78,PQV79,PQV80,PQV88,PQV10,PQV65,PQV64,PQV82,PQV66,PQV81,PQV67,PQV94,PQV03,CASE WHEN PQV01!='' THEN '' ELSE CASE WHEN PQV93='T' THEN '已入' ELSE '未入' END END PQV93,(SELECT DGA002 FROM TPADGA WHERE PQV03=DGA001) DGA002,(SELECT RES05 FROM R_REVIEWS WHERE RES04 = ( SELECT MAX(RES04) RES04 FROM R_REVIEWS WHERE RES06 = PQV76)) RES05,PQV11*PQV66*PQV81*PQV67*PQV13 U0,PQV05,PQV97,CONVERT(DECIMAL(18,3),PQV12*PQV68*PQV69*PQV70*0.000001*PQV11) U1,PQV99 FROM (" );
            strSql.Append( " SELECT ROW_NUMBER() OVER (" );
            if ( !string.IsNullOrEmpty( orderby ) )
            {
                strSql.Append( "ORDER BY T." + orderby );
            }
            else
            {
                strSql.Append( "ORDER BY T.idx DESC" );
            }
            strSql.Append( ") AS Row,T.* FROM R_PQV T" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " WHERE " + strWhere );
            }
            strSql.Append( " ) TT" );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 分页获取数据集  财务结账
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTableByPage ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT TT.idx,PQV76,PQV01,PQV77,PQV78,PQV79,PQV80,PQV10,PQV65,PQV64,PQV82,PQV88,PQV66,PQV81,PQV67,PQV11,PQV12,PQV13,PQV68,PQV69,PQV70,PQV94,PQV03,CASE WHEN PQV01!='' THEN '' ELSE CASE WHEN PQV93='T' THEN '已入' ELSE '未入' END END PQV93,(SELECT DGA003 FROM TPADGA WHERE PQV03=DGA001) DGA002,RES05,PQV11*PQV66*PQV81*PQV67*PQV13 U0,PQV05,PQV97,CONVERT(DECIMAL(18,3),PQV12*PQV68*PQV69*PQV70*0.000001*PQV11) U1,PQV99 FROM( " );
            strSql.Append( " SELECT ROW_NUMBER() OVER (" );
            strSql.Append( "ORDER BY T.PQV76 DESC" );
            strSql.Append( ") AS Row,T.* FROM R_PQV T" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " WHERE " + strWhere );
            }
            strSql.Append( " ) TT,R_REVIEWS B WHERE TT.PQV76=B.RES06 AND RES05='执行' AND NOT EXISTS (SELECT 1 FROM R_PQAL C,R_PQAK D WHERE TT.idx=C.AL003 AND TT.PQV76=C.AL002 AND C.AL001=D.idx AND (AK009-AK010-AK011-AK015)<=100)" );//AND AK009=AK011
            strSql .AppendFormat( " AND TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取生产人姓名
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePerson ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DBA002,DBA001,DBA028 FROM TPADBA WHERE DBA028!='' AND (DBA043='F' OR DBA043='' OR DBA043 IS NULL) ORDER BY DBA001" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取生产车间
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableWork ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DBA001,DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002 IN (SELECT DBA002 FROM TPADBA WHERE DBA005=(SELECT DAA001 FROM TPADAA WHERE DAA002='生产部')) AND (DBA043='F' OR DBA043='' OR DBA043 IS NULL))" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetDataTableYesNoAcPlan ( MulaolaoLibrary.MuCaiContractLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AC03+ISNULL(AC26,0) AC03,AC18 FROM R_PQAC WHERE AC18=(SELECT MAX(AC18) FROM R_PQAC WHERE AC04=@AC04 AND AC05=@AC05)" );
            SqlParameter[] parameter = {
                new SqlParameter("@AC04",SqlDbType.NVarChar),
                new SqlParameter("@AC05",SqlDbType.NVarChar)
            };
            parameter[0].Value = model.PQV86;
            parameter[1].Value = model.PQV67;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableYseNoAdPlan ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT SUM(AD05) AD05 FROM R_PQAD WHERE AD01=@AD01" );
            SqlParameter[] parameter = {
                new SqlParameter("@AD01",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetDataTableContrast (MulaolaoLibrary.MuCaiContractLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQV WHERE PQV79=@PQV79 AND PQV10=@PQV10 AND PQV66=@PQV66 AND PQV81=@PQV81 AND PQV67=@PQV67 AND PQV01='' AND PQV76=(SELECT MAX(PQV76) FROM R_PQV WHERE PQV01='' AND PQV79=@PQV79 AND PQV10=@PQV10 AND PQV66=@PQV66 AND PQV81=@PQV81 AND PQV67=@PQV67)" );
            SqlParameter[] parameter = {
                new SqlParameter("@PQV79",SqlDbType.NVarChar),
                new SqlParameter("@PQV10",SqlDbType.NVarChar),
                new SqlParameter("@PQV66",SqlDbType.Decimal),
                new SqlParameter("@PQV81",SqlDbType.Decimal),
                new SqlParameter("@PQV67",SqlDbType.Decimal)
            };
            parameter[0].Value = model.PQV79;
            parameter[1].Value = model.PQV10;
            parameter[2].Value = model.PQV66;
            parameter[3].Value = model.PQV81;
            parameter[4].Value = model.PQV67;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 是否存在一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsTable ( MulaolaoLibrary.MuCaiContractLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQV" );
            strSql.Append( " WHERE PQV76=@PQV76 AND PQV10=@PQV10 AND PQV66=@PQV66 AND PQV81=@PQV81 AND PQV67=@PQV67" );
            SqlParameter[] parameter = {
                new SqlParameter("@PQV76",SqlDbType.NVarChar),
                new SqlParameter("@PQV10",SqlDbType.NVarChar),
                new SqlParameter("@PQV66",SqlDbType.Decimal),
                new SqlParameter("@PQV81",SqlDbType.Decimal),
                new SqlParameter("@PQV67",SqlDbType.Decimal)
            };

            parameter[0].Value = model.PQV76;
            parameter[1].Value = model.PQV10;
            parameter[2].Value = model.PQV66;
            parameter[3].Value = model.PQV81;
            parameter[4].Value = model.PQV67;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add ( MulaolaoLibrary.MuCaiContractLibrary model, string tableNum ,string tableName ,string logins ,DateTime dtOne  ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQV (" );
            strSql.Append( "PQV03,PQV10,PQV11,PQV12,PQV13,PQV14,PQV15,PQV16,PQV17,PQV18,PQV19,PQV20,PQV21,PQV22,PQV23,PQV24,PQV64,PQV65,PQV66,PQV67,PQV68,PQV69,PQV70,PQV71,PQV72,PQV73,PQV76,PQV80,PQV81,PQV82,PQV84,PQV86,PQV97)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}')" ,model.PQV03 ,model.PQV10 ,model.PQV11 ,model.PQV12 ,model.PQV13 ,model.PQV14 ,model.PQV15 ,model.PQV16 ,model.PQV17 ,model.PQV18 ,model.PQV19 ,model.PQV20 ,model.PQV21 ,model.PQV22 ,model.PQV23 ,model.PQV24 ,model.PQV64 ,model.PQV65 ,model.PQV66 ,model.PQV67 ,model.PQV68 ,model.PQV69 ,model.PQV70 ,model.PQV71 ,model.PQV72 ,model.PQV73 ,model.PQV76 ,model.PQV80 ,model.PQV81 ,model.PQV82 ,model.PQV84 ,model. PQV86 ,model . PQV97 );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.PQV76 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.MuCaiContractLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQV SET " );
            strSql.AppendFormat( "PQV10='{0}'," ,model.PQV10 );
            strSql.AppendFormat( "PQV11='{0}'," ,model.PQV11 );
            strSql.AppendFormat( "PQV12='{0}'," ,model.PQV12 );
            strSql.AppendFormat( "PQV13='{0}'," ,model.PQV13 );
            strSql.AppendFormat( "PQV14='{0}'," ,model.PQV14 );
            strSql.AppendFormat( "PQV15='{0}'," ,model.PQV15 );
            strSql.AppendFormat( "PQV16='{0}'," ,model.PQV16 );
            strSql.AppendFormat( "PQV17='{0}'," ,model.PQV17 );
            strSql.AppendFormat( "PQV18='{0}'," ,model.PQV18 );
            strSql.AppendFormat( "PQV19='{0}'," ,model.PQV19 );
            strSql.AppendFormat( "PQV20='{0}'," ,model.PQV20 );
            strSql.AppendFormat( "PQV21='{0}'," ,model.PQV21 );
            strSql.AppendFormat( "PQV22='{0}'," ,model.PQV22 );
            strSql.AppendFormat( "PQV23='{0}'," ,model.PQV23 );
            strSql.AppendFormat( "PQV24='{0}'," ,model.PQV24 );
            strSql.AppendFormat( "PQV64='{0}'," ,model.PQV64 );
            strSql.AppendFormat( "PQV65='{0}'," ,model.PQV65 );
            strSql.AppendFormat( "PQV66='{0}'," ,model.PQV66 );
            strSql.AppendFormat( "PQV67='{0}'," ,model.PQV67 );
            strSql.AppendFormat( "PQV68='{0}'," ,model.PQV68 );
            strSql.AppendFormat( "PQV69='{0}'," ,model.PQV69 );
            strSql.AppendFormat( "PQV70='{0}'," ,model.PQV70 );
            strSql.AppendFormat( "PQV71='{0}'," ,model.PQV71 );
            strSql.AppendFormat( "PQV72='{0}'," ,model.PQV72 );
            strSql.AppendFormat( "PQV73='{0}'," ,model.PQV73 );
            strSql.AppendFormat( "PQV80='{0}'," ,model.PQV80 );
            strSql.AppendFormat( "PQV81='{0}'," ,model.PQV81 );
            strSql.AppendFormat( "PQV82='{0}'," ,model.PQV82 );
            strSql.AppendFormat( "PQV84='{0}'," ,model.PQV84 );
            strSql.AppendFormat( "PQV86='{0}'," ,model.PQV86 );
            strSql . AppendFormat ( "PQV97='{0}'" ,model . PQV97 );
            strSql . AppendFormat ( " WHERE PQV76='{1}' AND idx='{0}'" , model . IDX , model . PQV76 );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.PQV76 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetDataTablePlan ( MulaolaoLibrary.MuCaiContractLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AC03+ISNULL(AC26,0)-(SELECT SUM(AD05+ISNULL(AD20,0)) AD05 FROM R_PQAD  WHERE AC18=AD01) AD05  FROM R_PQAC WHERE AC18=(SELECT MAX(AC18) FROM R_PQAC WHERE  AC04=@AC04 AND AC05=@AC05) GROUP BY AC03,AC18,ISNULL(AC26,0)" );
            SqlParameter[] parameter = {
                new SqlParameter("@AC04",SqlDbType.NVarChar),
                new SqlParameter("@AC05",SqlDbType.Decimal)
            };

            parameter[0].Value = model.PQV86;
            parameter[1].Value = model.PQV67;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetDataTableDwo ( MulaolaoLibrary.MuCaiContractLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQV" );
            strSql.Append( " WHERE PQV10=@PQV10 AND PQV66=@PQV66 AND PQV81=@PQV81 AND PQV67=@PQV67 AND PQV65=@PQV65" );
            SqlParameter[] parameter = {
                new SqlParameter("@PQV10",SqlDbType.NVarChar),
                new SqlParameter("@PQV66",SqlDbType.Decimal),
                new SqlParameter("@PQV81",SqlDbType.Decimal),
                new SqlParameter("@PQV67",SqlDbType.Decimal),
                new SqlParameter("@PQV65",SqlDbType.NVarChar)
            };
            parameter[0].Value = model.PQV10;
            parameter[1].Value = model.PQV66;
            parameter[2].Value = model.PQV81;
            parameter[3].Value = model.PQV67;
            parameter[4].Value = model.PQV65;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd ,string oddNum )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQV" );
            strSql . AppendFormat ( " WHERE PQV76='{1}' AND idx='{0}'" , idx , oddNum );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTabelTable ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,PQV10,PQV80,PQV11,PQV12,PQV13,PQV14,PQV15,PQV16,PQV17,PQV18,PQV19,PQV20,PQV21,PQV22,PQV23,PQV24,PQV64,PQV65,PQV66,PQV67,PQV68,PQV69,PQV70,PQV71,PQV72,PQV73,CASE WHEN PQV66=0 THEN 0 WHEN PQV67=0 THEN 0 WHEN PQV66!=0 AND PQV67!=0 THEN SUM(PQV71*PQV72*PQV73*PQV20*PQV80*PQV12*0.000001)/PQV66/PQV67 END U2,PQV82,PQV81,PQV84,PQV86,PQV88,PQV90,PQV91,PQV97 FROM R_PQV" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( " GROUP BY PQV01,PQV10,PQV80,PQV11,PQV12,PQV13,PQV14,PQV15,PQV16,PQV17,PQV18,PQV19,PQV20,PQV21,PQV22,PQV23,PQV24,PQV64,PQV65,PQV66,PQV67,PQV68,PQV69,PQV70,PQV71,PQV72,PQV73,PQV66,PQV67,PQV82,PQV81,PQV84,PQV86,PQV88,PQV90,PQV91,PQV97,idx ORDER BY idx DESC" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintOne ( string oddNum ,int startIndex,int endIndex)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql . Append ( "WITH CET AS (" );
            strSql.Append( "SELECT ROW_NUMBER() OVER(ORDER BY PQV86) ROW,PQV86,PQV65,PQV01, PQV10, PQV80, PQV12,CASE WHEN PQV68 = 0 THEN 0 WHEN PQV68 != 0 THEN CONVERT( DECIMAL( 15, 1 ), PQV66 / PQV68 / 0.01 ) END U1,CASE WHEN PQV80 = 0 THEN 0 WHEN PQV80 != 0 THEN CONVERT( DECIMAL( 15, 2 ), PQV66*PQV81*PQV67*PQV11*PQV13/PQV80 ) END U2,PQV66,PQV81,PQV67,CONVERT( DECIMAL( 15, 2 ), PQV66*PQV81*PQV67 ) U4,PQV11, PQV13,CONVERT( DECIMAL( 15, 4 ), PQV66*PQV81*PQV67*PQV13 ) U5,PQV11*PQV66*PQV81*PQV67*PQV13 U6,CONVERT( VARCHAR( 20 ), PQV23, 102 ) PQV23,CONVERT( VARCHAR( 20 ), PQV24, 102 ) PQV24,CONVERT( DECIMAL( 15, 2 ),PQV12*PQV68*PQV69*PQV70*0.000001*PQV11 ) U7,PQV68, PQV69, PQV70,CONVERT( DECIMAL( 15, 2 ), PQV68 * PQV69 * PQV70 ) U8,CONVERT( DECIMAL( 15, 4 ), PQV80*PQV12*PQV68*PQV69*PQV70* 0.000001 ) U9,CONVERT( DECIMAL( 15, 4 ), PQV71*PQV72*PQV73*PQV84*PQV80*PQV12*0.000001) U10,PQV80*PQV12*PQV68*PQV69*PQV70*0.000001*PQV11 U11,PQV71*PQV72*PQV73*PQV84*PQV80*PQV12*0.000001*PQV11 U12,'≥' + CONVERT( VARCHAR( 20 ), PQV16 ) + '%' PQV16,'≤' + CONVERT( VARCHAR( 20 ), PQV14 ) + '%' PQV14,CONVERT( VARCHAR( 20 ), PQV17 ) + '%' PQV17,PQV15, PQV18, PQV21, PQV19, PQV71, PQV72, PQV73,CONVERT( DECIMAL( 15, 2 ), PQV71 * PQV72 * PQV73 ) U13,PQV20,CASE WHEN PQV68 = 0 THEN 0 WHEN PQV68 != 0 THEN CONVERT( DECIMAL( 15, 2 ), PQV71 / PQV68 ) END U14,CASE WHEN PQV84 = 0 THEN 0 WHEN PQV84 != 0 THEN CONVERT( DECIMAL(10,2),1/PQV84) END U15,PQV22 FROM R_PQV" );
            strSql.Append( " WHERE PQV76=@PQV76 GROUP BY PQV64,PQV65,PQV01,PQV10,PQV80,PQV12,PQV13,PQV11,PQV14,PQV15,PQV16,PQV17,PQV18,PQV19,PQV20,PQV21,PQV22,PQV23,PQV24,PQV66,PQV67,PQV68,PQV69,PQV70,PQV71,PQV72,PQV73,PQV81,PQV84,PQV86" );
            strSql . Append ( ") " );
            strSql . AppendFormat ( "SELECT * FROM CET WHERE ROW BETWEEN {0} AND {1}" ,startIndex ,endIndex );
            SqlParameter[] parameter = {
                new SqlParameter("@PQV76",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintTwo ( string oddNum ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql . Append ( "WITH CET AS (" );
            strSql.Append( "SELECT DISTINCT ROW_NUMBER() OVER(ORDER BY PQV76) ROW,DBA002,DBA028,DGA003,DGA017,DGA009,DGA011,DGA008,DGA012,PQV01,PQV77,PQV79,PQV05,CONVERT(VARCHAR(20),PQV06,102) PQV06,PQV07,CONVERT(VARCHAR(20),PQV08,102) PQV08,PQV09,PQV25,CONVERT(VARCHAR(20),PQV26,102) PQV26,PQV27,PQV28,PQV29,PQV30,PQV31,PQV32,CONVERT(VARCHAR(20),PQV33,102) PQV33,PQV34,CONVERT(VARCHAR(20),PQV35,102) PQV35,PQV36,CONVERT(VARCHAR(20),PQV37,102) PQV37,PQV38,PQV39,PQV40,CONVERT(VARCHAR(20),PQV41,102) PQV41,PQV42,PQV43,PQV44,PQV45,PQV46,PQV47,PQV48,PQV49,PQV50,PQV51,PQV52,PQV53,PQV54,PQV55,CONVERT(VARCHAR(20),PQV56,102) PQV56,PQV57,PQV58,CONVERT(VARCHAR(20),PQV59,102) PQV59,PQV60,CONVERT(VARCHAR(20),PQV61,102) PQV61,PQV62,CONVERT(VARCHAR(20),PQV63,102) PQV63,PQV89,PQV76,CASE WHEN PQV01='' THEN 'F' WHEN PQV01!='' THEN CASE WHEN PQV65='库存' THEN 'T' ELSE '1' END END PQV,ISNULL(PQV88,'F') PQV88 FROM  R_PQV A LEFT JOIN TPADBA B ON  A.PQV02=B.DBA001 LEFT JOIN TPADGA C ON A.PQV03=C.DGA001" );
            strSql.Append( " WHERE PQV76=@PQV76" );
            strSql . Append ( ")" );
            strSql . AppendFormat ( "SELECT * FROM CET WHERE ROW BETWEEN {0} AND {1}" ,startIndex ,endIndex );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PQV76",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 是否已经执行
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="formText"></param>
        /// <returns></returns>
        public bool ExistsReeviews ( string oddNum ,string formText )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_REVIEWS" );
            strSql.Append( " WHERE RES05='执行' AND RES01=@RES01 AND RES06=@RES06" );
            SqlParameter[] parameter = {
                new SqlParameter("@RES01",SqlDbType.NVarChar),
                new SqlParameter("@RES06",SqlDbType.NVarChar)
            };
            parameter[0].Value = formText;
            parameter[1].Value = oddNum;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DeleteOddNum ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQV" );
            strSql.AppendFormat( " WHERE PQV76='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            StringBuilder strSq = new StringBuilder( );
            strSq.Append( "DELETE FROM R_REVIEWS" );
            strSq.AppendFormat( " WHERE RES01='{0}' AND RES06='{1}'" ,tableNum ,oddNum );
            SQLString.Add( strSq.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );
            if ( stateOfOdd == "维护删除" )
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "DELETE FROM R_PQAMB WHERE AMB001='{0}'" ,oddNum );
                SQLString.Add( strSql.ToString( ) );
            }
            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 删除送审记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="formText"></param>
        /// <returns></returns>
        public bool DeleteReview ( string oddNum ,string formText)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_REVIEWS" );
            strSql.Append( " WHERE RES01=@RES01 AND RES06=@RES06" );
            SqlParameter[] parameter = {
                new SqlParameter("@RES01",SqlDbType.NVarChar),
                new SqlParameter("@RES06",SqlDbType.NVarChar)
            };

            parameter[0].Value = formText;
            parameter[1].Value = oddNum;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }
        
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableAll ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT PQV75 FROM R_PQV" );
            strSql.Append( " WHERE PQV76=@PQV76" );
            SqlParameter[] parameter = {
                new SqlParameter("@PQV76",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateWeiHu ( MulaolaoLibrary.MuCaiContractLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQV SET " );
            strSql.AppendFormat( "PQV01='{0}',",model.PQV01 );
            strSql.AppendFormat( "PQV02='{0}'," ,model.PQV02 );
            strSql.AppendFormat( "PQV03='{0}'," ,model.PQV03 );
            strSql.AppendFormat( "PQV04='{0}'," ,model.PQV04 );
            strSql.AppendFormat( "PQV05='{0}'," ,model.PQV05 );
            strSql.AppendFormat( "PQV06='{0}'," ,model.PQV06 );
            strSql.AppendFormat( "PQV07='{0}'," ,model.PQV07 );
            strSql.AppendFormat( "PQV08='{0}'," ,model.PQV08 );
            strSql.AppendFormat( "PQV09='{0}'," ,model.PQV09 );
            strSql.AppendFormat( "PQV25='{0}'," ,model.PQV25 );
            strSql.AppendFormat( "PQV26='{0}'," ,model.PQV26 );
            strSql.AppendFormat( "PQV27='{0}'," ,model.PQV27 );
            strSql.AppendFormat( "PQV28='{0}'," ,model.PQV28 );
            strSql.AppendFormat( "PQV29='{0}'," ,model.PQV29 );
            strSql.AppendFormat( "PQV30='{0}'," ,model.PQV30 );
            strSql.AppendFormat( "PQV31='{0}'," ,model.PQV31 );
            strSql.AppendFormat( "PQV32='{0}'," ,model.PQV32 );
            strSql.AppendFormat( "PQV33='{0}'," ,model.PQV33 );
            strSql.AppendFormat( "PQV34='{0}'," ,model.PQV34 );
            strSql.AppendFormat( "PQV35='{0}'," ,model.PQV35 );
            strSql.AppendFormat( "PQV36='{0}'," ,model.PQV36 );
            strSql.AppendFormat( "PQV37='{0}'," ,model.PQV37 );
            strSql.AppendFormat( "PQV38='{0}'," ,model.PQV38 );
            strSql.AppendFormat( "PQV39='{0}'," ,model.PQV39 );
            strSql.AppendFormat( "PQV40='{0}'," ,model.PQV40 );
            strSql.AppendFormat( "PQV41='{0}'," ,model.PQV41 );
            strSql.AppendFormat( "PQV42='{0}'," ,model.PQV42 );
            strSql.AppendFormat( "PQV43='{0}'," ,model.PQV43 );
            strSql.AppendFormat( "PQV44='{0}'," ,model.PQV44 );
            strSql.AppendFormat( "PQV45='{0}'," ,model.PQV45 );
            strSql.AppendFormat( "PQV46='{0}'," ,model.PQV46 );
            strSql.AppendFormat( "PQV47='{0}'," ,model.PQV47 );
            strSql.AppendFormat( "PQV48='{0}'," ,model.PQV48 );
            strSql.AppendFormat( "PQV49='{0}'," ,model.PQV49 );
            strSql.AppendFormat( "PQV50='{0}'," ,model.PQV50 );
            strSql.AppendFormat( "PQV51='{0}'," ,model.PQV51 );
            strSql.AppendFormat( "PQV52='{0}'," ,model.PQV52 );
            strSql.AppendFormat( "PQV53='{0}'," ,model.PQV53 );
            strSql.AppendFormat( "PQV54='{0}'," ,model.PQV54 );
            strSql.AppendFormat( "PQV55='{0}'," ,model.PQV55 );
            strSql.AppendFormat( "PQV56='{0}'," ,model.PQV56 );
            strSql.AppendFormat( "PQV57='{0}'," ,model.PQV57 );
            strSql.AppendFormat( "PQV58='{0}'," ,model.PQV58 );
            strSql.AppendFormat( "PQV59='{0}'," ,model.PQV59 );
            strSql.AppendFormat( "PQV60='{0}'," ,model.PQV60 );
            strSql.AppendFormat( "PQV61='{0}'," ,model.PQV61 );
            strSql.AppendFormat( "PQV62='{0}'," ,model.PQV62 );
            strSql.AppendFormat( "PQV63='{0}'," ,model.PQV63 );
            strSql.AppendFormat( "PQV74='{0}'," ,model.PQV74 );
            strSql.AppendFormat( "PQV75='{0}'," ,model.PQV75 );
            strSql.AppendFormat( "PQV77='{0}'," ,model.PQV77 );
            strSql.AppendFormat( "PQV78='{0}'," ,model.PQV78 );
            strSql.AppendFormat( "PQV79='{0}'," ,model.PQV79 );
            strSql.AppendFormat( "PQV87='{0}'," ,model.PQV87 );
            strSql.AppendFormat( "PQV88='{0}'," ,model.PQV88 );
            strSql.AppendFormat( "PQV89='{0}'," ,model.PQV89 );
            strSql.AppendFormat( "PQV92='{0}'," ,model.PQV92 );
            strSql.AppendFormat( "PQV94='{0}'" ,model.PQV94 );
            strSql.AppendFormat( " WHERE PQV76='{0}'" ,model.PQV76 );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.PQV76 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 批量编辑数量
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateBatch ( MulaolaoLibrary.MuCaiContractLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQV SET " );
            strSql.AppendFormat( "PQV80='{0}',",model.PQV80 );
            strSql.AppendFormat( "PQV82='{0}'," ,model.PQV82 );
            strSql.AppendFormat( "PQV64='{0}'" ,model.PQV64 );
            strSql.AppendFormat( " WHERE idx='{0}'" ,model.IDX );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,model.PQV76 ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 复制一条记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool AddCopy ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQV (" );
            strSql.Append( "PQV01,PQV77,PQV78,PQV79,PQV80,PQV02,PQV03,PQV10,PQV11,PQV12,PQV13,PQV14,PQV15,PQV16,PQV17,PQV18,PQV19,PQV20,PQV84,PQV21,PQV22,PQV27,PQV28,PQV29,PQV30,PQV31,PQV36,PQV38,PQV39,PQV40,PQV42,PQV43,PQV44,PQV45,PQV46,PQV47,PQV48,PQV49,PQV50,PQV51,PQV52,PQV53,PQV64,PQV82,PQV65,PQV66,PQV81,PQV67,PQV68,PQV69,PQV70,PQV71,PQV72,PQV73,PQV86)" );
            strSql.Append( "SELECT PQV01,PQV77,PQV78,PQV79,PQV80,PQV02,PQV03,PQV10,PQV11,PQV12,PQV13,PQV14,PQV15,PQV16,PQV17,PQV18,PQV19,PQV20,PQV84,PQV21,PQV22,PQV27,PQV28,PQV29,PQV30,PQV31,PQV36,PQV38,PQV39,PQV40,PQV42,PQV43,PQV44,PQV45,PQV46,PQV47,PQV48,PQV49,PQV50,PQV51,PQV52,PQV53,PQV64,PQV82,PQV65,PQV66,PQV81,PQV67,PQV68,PQV69,PQV70,PQV71,PQV72,PQV73,PQV86 FROM R_PQV" );
            strSql.AppendFormat( " WHERE PQV76='{0}'" ,oddNum );
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
            strSql.AppendFormat( "UPDATE R_PQV SET PQV76='{0}',PQV87='复制',PQV23=DATEADD(DAY,5,GETDATE()) WHERE PQV76 IS NULL" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            SQLString.Add( Drity.DrityOfComparation( tableNum ,tableName ,logins ,dtOne ,oddNum ,strSql.ToString( ).Replace( "'" ,"''" ) ,stateOf ,stateOfOdd ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 删除复制记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DeleteCopy ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQV WHERE PQV76 IS NULL" );

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.MuCaiContractLibrary GetModel ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,PQV03,PQV10,PQV11,PQV12,PQV13,PQV14,PQV15,PQV16,PQV17,PQV18,PQV19,PQV20,PQV21,PQV22,PQV23,PQV24,PQV64,PQV65,PQV66,PQV67,PQV68,PQV69,PQV70,PQV71,PQV72,PQV73,PQV76,PQV80,PQV81,PQV82,PQV84,PQV86,PQV97 FROM R_PQV" );
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
        public MulaolaoLibrary.MuCaiContractLibrary GetDataRow ( DataRow row )
        {
            MulaolaoLibrary.MuCaiContractLibrary model = new MulaolaoLibrary.MuCaiContractLibrary( );

            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    model.IDX = int.Parse( row["idx"].ToString( ) );
                if ( row["PQV03"] != null && row["PQV03"].ToString( ) != "" )
                    model.PQV03 = row["PQV03"].ToString( );
                if ( row["PQV10"] != null && row["PQV10"].ToString( ) != "" )
                    model.PQV10 = row["PQV10"].ToString( );
                if ( row["PQV11"] != null && row["PQV11"].ToString( ) != "" )
                    model.PQV11 = decimal.Parse( row["PQV11"].ToString( ) );
                if ( row["PQV12"] != null && row["PQV12"].ToString( ) != "" )
                    model.PQV12 = int.Parse( row["PQV12"].ToString( ) );
                if ( row["PQV13"] != null && row["PQV13"].ToString( ) != "" )
                    model.PQV13 = int.Parse( row["PQV13"].ToString( ) );
                if ( row["PQV14"] != null && row["PQV14"].ToString( ) != "" )
                    model.PQV14 = int.Parse( row["PQV14"].ToString( ) );
                if ( row["PQV15"] != null && row["PQV15"].ToString( ) != "" )
                    model.PQV15 = int.Parse( row["PQV15"].ToString( ) );
                if ( row["PQV16"] != null && row["PQV16"].ToString( ) != "" )
                    model.PQV16 = row["PQV16"].ToString( );
                if ( row["PQV17"] != null && row["PQV17"].ToString( ) != "" )
                    model.PQV17 = int.Parse( row["PQV17"].ToString( ) );
                if ( row["PQV18"] != null && row["PQV18"].ToString( ) != "" )
                    model.PQV18 = int.Parse( row["PQV18"].ToString( ) );
                if ( row["PQV19"] != null && row["PQV19"].ToString( ) != "" )
                    model.PQV19 = int.Parse( row["PQV19"].ToString( ) );
                if ( row["PQV20"] != null && row["PQV20"].ToString( ) != "" )
                    model.PQV20 = decimal.Parse( row["PQV20"].ToString( ) );
                if ( row["PQV21"] != null && row["PQV21"].ToString( ) != "" )
                    model.PQV21 = int.Parse( row["PQV21"].ToString( ) );
                if ( row["PQV22"] != null && row["PQV22"].ToString( ) != "" )
                    model.PQV22 = int.Parse( row["PQV22"].ToString( ) );
                if ( row["PQV23"] != null && row["PQV23"].ToString( ) != "" )
                    model.PQV23 = DateTime.Parse( row["PQV23"].ToString( ) );
                if ( row["PQV24"] != null && row["PQV24"].ToString( ) != "" )
                    model.PQV24 = DateTime.Parse( row["PQV24"].ToString( ) );
                if ( row["PQV64"] != null && row["PQV64"].ToString( ) != "" )
                    model.PQV64 = decimal.Parse( row["PQV64"].ToString( ) );
                if ( row["PQV65"] != null && row["PQV65"].ToString( ) != "" )
                    model.PQV65 = row["PQV65"].ToString( );
                if ( row["PQV66"] != null && row["PQV66"].ToString( ) != "" )
                    model.PQV66 = decimal.Parse( row["PQV66"].ToString( ) );
                if ( row["PQV67"] != null && row["PQV67"].ToString( ) != "" )
                    model.PQV67 = decimal.Parse( row["PQV67"].ToString( ) );
                if ( row["PQV68"] != null && row["PQV68"].ToString( ) != "" )
                    model.PQV68 = decimal.Parse( row["PQV68"].ToString( ) );
                if ( row["PQV69"] != null && row["PQV69"].ToString( ) != "" )
                    model.PQV69 = decimal.Parse( row["PQV69"].ToString( ) );
                if ( row["PQV70"] != null && row["PQV70"].ToString( ) != "" )
                    model.PQV70 = decimal.Parse( row["PQV70"].ToString( ) );
                if ( row["PQV71"] != null && row["PQV71"].ToString( ) != "" )
                    model.PQV71 = decimal.Parse( row["PQV71"].ToString( ) );
                if ( row["PQV72"] != null && row["PQV72"].ToString( ) != "" )
                    model.PQV72 = decimal.Parse( row["PQV72"].ToString( ) );
                if ( row["PQV73"] != null && row["PQV73"].ToString( ) != "" )
                    model.PQV73 = decimal.Parse( row["PQV73"].ToString( ) );
                if ( row["PQV76"] != null && row["PQV76"].ToString( ) != "" )
                    model.PQV76 = row["PQV76"].ToString( );
                if ( row["PQV80"] != null && row["PQV80"].ToString( ) != "" )
                    model.PQV80 = long.Parse( row["PQV80"].ToString( ) );
                if ( row["PQV81"] != null && row["PQV81"].ToString( ) != "" )
                    model.PQV81 = decimal.Parse( row["PQV81"].ToString( ) );
                if ( row["PQV82"] != null && row["PQV82"].ToString( ) != "" )
                    model.PQV82 = decimal.Parse( row["PQV82"].ToString( ) );
                if ( row["PQV84"] != null && row["PQV84"].ToString( ) != "" )
                    model.PQV84 = decimal.Parse( row["PQV84"].ToString( ) );
                if ( row["PQV86"] != null && row["PQV86"].ToString( ) != "" )
                    model.PQV86 = row["PQV86"].ToString( );
                if ( row [ "PQV97" ] != null && row [ "PQV97" ] . ToString ( ) != "" )
                    model . PQV97 = decimal . Parse ( row [ "PQV97" ] . ToString ( ) );
            }

            return model;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.MuCaiContractLibrary GetMo ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQV" );
            strSql.Append( " WHERE PQV76=@PQV76" );
            SqlParameter[] parameter = {
                new SqlParameter("@PQV76",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;
            DataTable dt = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( dt.Rows.Count >= 1 )
                return GetDataR( dt.Rows[0] );
            else
                return null;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.MuCaiContractLibrary GetDataR ( DataRow row )
        {
            MulaolaoLibrary.MuCaiContractLibrary model = new MulaolaoLibrary.MuCaiContractLibrary( );

            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    model.IDX = int.Parse( row["idx"].ToString( ) );
                if ( row["PQV01"] != null && row["PQV01"].ToString( ) != "" )
                    model.PQV01 = row["PQV01"].ToString( );
                if ( row["PQV02"] != null && row["PQV02"].ToString( ) != "" )
                    model.PQV02 = row["PQV02"].ToString( );
                if ( row["PQV03"] != null && row["PQV03"].ToString( ) != "" )
                    model.PQV03 = row["PQV03"].ToString( );
                if ( row["PQV04"] != null && row["PQV04"].ToString( ) != "" )
                    model.PQV04 = DateTime.Parse( row["PQV04"].ToString( ) );
                if ( row["PQV05"] != null && row["PQV05"].ToString( ) != "" )
                    model.PQV05 = row["PQV05"].ToString( );
                if ( row["PQV06"] != null && row["PQV06"].ToString( ) != "" )
                    model.PQV06 = DateTime.Parse( row["PQV06"].ToString( ) );
                if ( row["PQV07"] != null && row["PQV07"].ToString( ) != "" )
                    model.PQV07 = row["PQV07"].ToString( );
                if ( row["PQV08"] != null && row["PQV08"].ToString( ) != "" )
                    model.PQV08 = DateTime.Parse( row["PQV08"].ToString( ) );
                if ( row["PQV09"] != null && row["PQV09"].ToString( ) != "" )
                    model.PQV09 = row["PQV09"].ToString( );
                if ( row["PQV25"] != null && row["PQV25"].ToString( ) != "" )
                    model.PQV25 = row["PQV25"].ToString( );
                if ( row["PQV26"] != null && row["PQV26"].ToString( ) != "" )
                    model.PQV26 = DateTime.Parse( row["PQV26"].ToString( ) );
                if ( row["PQV27"] != null && row["PQV27"].ToString( ) != "" )
                    model.PQV27 = row["PQV27"].ToString( );
                if ( row["PQV28"] != null && row["PQV28"].ToString( ) != "" )
                    model.PQV28 = row["PQV28"].ToString( );
                if ( row["PQV29"] != null && row["PQV29"].ToString( ) != "" )
                    model.PQV29 = row["PQV29"].ToString( );
                if ( row["PQV30"] != null && row["PQV30"].ToString( ) != "" )
                    model.PQV30 = row["PQV30"].ToString( );
                if ( row["PQV31"] != null && row["PQV31"].ToString( ) != "" )
                    model.PQV31 = row["PQV31"].ToString( );
                if ( row["PQV32"] != null && row["PQV32"].ToString( ) != "" )
                    model.PQV32 = row["PQV32"].ToString( );
                if ( row["PQV33"] != null && row["PQV33"].ToString( ) != "" )
                    model.PQV33 = DateTime.Parse( row["PQV33"].ToString( ) );
                if ( row["PQV34"] != null && row["PQV34"].ToString( ) != "" )
                    model.PQV34 = row["PQV34"].ToString( );
                if ( row["PQV35"] != null && row["PQV35"].ToString( ) != "" )
                    model.PQV35 = DateTime.Parse( row["PQV35"].ToString( ) );
                if ( row["PQV36"] != null && row["PQV36"].ToString( ) != "" )
                    model.PQV36 = row["PQV36"].ToString( );
                if ( row["PQV37"] != null && row["PQV37"].ToString( ) != "" )
                    model.PQV37 = DateTime.Parse( row["PQV37"].ToString( ) );
                if ( row["PQV38"] != null && row["PQV38"].ToString( ) != "" )
                    model.PQV38 = row["PQV38"].ToString( );
                if ( row["PQV39"] != null && row["PQV39"].ToString( ) != "" )
                    model.PQV39 = row["PQV39"].ToString( );
                if ( row["PQV40"] != null && row["PQV40"].ToString( ) != "" )
                    model.PQV40 = row["PQV40"].ToString( );
                if ( row["PQV41"] != null && row["PQV41"].ToString( ) != "" )
                    model.PQV41 = DateTime.Parse( row["PQV41"].ToString( ) );
                if ( row["PQV42"] != null && row["PQV42"].ToString( ) != "" )
                    model.PQV42 = long.Parse( row["PQV42"].ToString( ) );
                if ( row["PQV43"] != null && row["PQV43"].ToString( ) != "" )
                    model.PQV43 = row["PQV43"].ToString( );
                if ( row["PQV44"] != null && row["PQV44"].ToString( ) != "" )
                    model.PQV44 = row["PQV44"].ToString( );
                if ( row["PQV45"] != null && row["PQV45"].ToString( ) != "" )
                    model.PQV45 = long.Parse( row["PQV45"].ToString( ) );
                if ( row["PQV46"] != null && row["PQV46"].ToString( ) != "" )
                    model.PQV46 = long.Parse( row["PQV46"].ToString( ) );
                if ( row["PQV47"] != null && row["PQV47"].ToString( ) != "" )
                    model.PQV47 = long.Parse( row["PQV47"].ToString( ) );
                if ( row["PQV48"] != null && row["PQV48"].ToString( ) != "" )
                    model.PQV48 = long.Parse( row["PQV48"].ToString( ) );
                if ( row["PQV49"] != null && row["PQV49"].ToString( ) != "" )
                    model.PQV49 = long.Parse( row["PQV49"].ToString( ) );
                if ( row["PQV50"] != null && row["PQV50"].ToString( ) != "" )
                    model.PQV50 = long.Parse( row["PQV50"].ToString( ) );
                if ( row["PQV51"] != null && row["PQV51"].ToString( ) != "" )
                    model.PQV51 = long.Parse( row["PQV51"].ToString( ) );
                if ( row["PQV52"] != null && row["PQV52"].ToString( ) != "" )
                    model.PQV52 = long.Parse( row["PQV52"].ToString( ) );
                if ( row["PQV53"] != null && row["PQV53"].ToString( ) != "" )
                    model.PQV53 = long.Parse( row["PQV53"].ToString( ) );
                if ( row["PQV54"] != null && row["PQV54"].ToString( ) != "" )
                    model.PQV54 = row["PQV54"].ToString( );
                if ( row["PQV55"] != null && row["PQV55"].ToString( ) != "" )
                    model.PQV55 = row["PQV55"].ToString( );
                if ( row["PQV56"] != null && row["PQV56"].ToString( ) != "" )
                    model.PQV56 = DateTime.Parse( row["PQV56"].ToString( ) );
                if ( row["PQV57"] != null && row["PQV57"].ToString( ) != "" )
                    model.PQV57 = row["PQV57"].ToString( );
                if ( row["PQV58"] != null && row["PQV58"].ToString( ) != "" )
                    model.PQV58 = row["PQV58"].ToString( );
                if ( row["PQV59"] != null && row["PQV59"].ToString( ) != "" )
                    model.PQV59 = DateTime.Parse( row["PQV59"].ToString( ) );
                if ( row["PQV60"] != null && row["PQV60"].ToString( ) != "" )
                    model.PQV60 = row["PQV60"].ToString( );
                if ( row["PQV61"] != null && row["PQV61"].ToString( ) != "" )
                    model.PQV61 = DateTime.Parse( row["PQV61"].ToString( ) );
                if ( row["PQV62"] != null && row["PQV62"].ToString( ) != "" )
                    model.PQV62 = row["PQV62"].ToString( );
                if ( row["PQV63"] != null && row["PQV63"].ToString( ) != "" )
                    model.PQV63 = DateTime.Parse( row["PQV63"].ToString( ) );
                if ( row["PQV74"] != null && row["PQV74"].ToString( ) != "" )
                    model.PQV74 = row["PQV74"].ToString( );
                if ( row["PQV75"] != null && row["PQV75"].ToString( ) != "" )
                    model.PQV75 = row["PQV75"].ToString( );
                if ( row["PQV76"] != null && row["PQV76"].ToString( ) != "" )
                    model.PQV76 = row["PQV76"].ToString( );
                if ( row["PQV77"] != null && row["PQV77"].ToString( ) != "" )
                    model.PQV77 = row["PQV77"].ToString( );
                if ( row["PQV78"] != null && row["PQV78"].ToString( ) != "" )
                    model.PQV78 = row["PQV78"].ToString( );
                if ( row["PQV79"] != null && row["PQV79"].ToString( ) != "" )
                    model.PQV79 = row["PQV79"].ToString( );
                if ( row["PQV80"] != null && row["PQV80"].ToString( ) != "" )
                    model.PQV80 = long.Parse( row["PQV80"].ToString( ) );
                if ( row["PQV87"] != null && row["PQV87"].ToString( ) != "" )
                    model.PQV87 = row["PQV87"].ToString( );
                if ( row["PQV88"] != null && row["PQV88"].ToString( ) != "" )
                    model.PQV88 = row["PQV88"].ToString( );
                if ( row["PQV89"] != null && row["PQV89"].ToString( ) != "" )
                    model.PQV89 = row["PQV89"].ToString( );
                if ( row["PQV92"] != null && row["PQV92"].ToString( ) != "" )
                    model.PQV92 = row["PQV92"].ToString( );
                if ( row["PQV94"] != null && row["PQV94"].ToString( ) != "" )
                    model.PQV94 = row["PQV94"].ToString( );
            }

            return model;
        }

        /// <summary>
        /// 获取乙方
        /// </summary>
        /// <param name="numBer"></param>
        /// <returns></returns>
        public DataTable GetDataTableSecond ( string numBer )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DGA003,DGA008,DGA011,DGA017,DGA009,DGA012 FROM TPADGA" );
            strSql.Append( " WHERE DGA001=@DGA001" );
            SqlParameter[] parameter = {
                new SqlParameter("@DGA001",SqlDbType.NVarChar)
            };

            parameter[0].Value = numBer;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 编辑上次入库记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateStr ( MulaolaoLibrary.MuCaiContractLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQV SET " );
            strSql.Append( "PQV90=@PQV90," );
            strSql.Append( "PQV91=@PQV91" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@PQV90",SqlDbType.BigInt),
                new SqlParameter("@PQV91",SqlDbType.Decimal),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = model.PQV90;
            parameter[1].Value = model.PQV91;
            parameter[2].Value = model.IDX;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 更改入库标记
        /// </summary>
        /// <returns></returns>
        public bool EditStroageMark ( )
        {
            ArrayList SQLString = new ArrayList( );
            string strWhere = "", strNum = "";
            DataTable da = GetDataTableAc( );
            if ( da != null && da.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < da.Rows.Count ; i++ )
                {
                    string sx = da.Rows[i]["AC16"].ToString( );
                    if ( sx.Contains( "," ) )
                    {
                        foreach ( string st in sx.Split( ',' ) )
                        {
                            if ( strWhere == "" )
                                strWhere = "'" + sx + "'";
                            else
                                strWhere = strWhere + "," + "'" + sx + "'";
                        }
                    }
                    else
                    {
                        if ( strWhere == "" )
                            strWhere = "'" + sx + "'";
                        else
                            strWhere = strWhere + "," + "'" + sx + "'";
                    }

                    if ( strNum == "" )
                        strNum = "'" + da.Rows[i]["AC18"].ToString( ) + "'";
                    else
                        strNum = strNum + "," + "'" + da.Rows[i]["AC18"].ToString( ) + "'";
                }
            }
            if ( strWhere != "" )
                SQLString.Add( EditPqv( strWhere ) );
            if ( strNum != "" )
                SQLString.Add( EditAc( strNum ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取入库记录
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableAc ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT AC16,AC18 FROM R_PQAC WHERE (AC17!='T' OR AC17='' OR AC17 IS NULL) AND AC16 LIKE 'R_341%'" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 更改入库标记
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public string EditAc (string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAC SET AC17='T'" );
            strSql.Append( " WHERE AC16 IN (" + strWhere + ")" );

            return strSql.ToString( );
        }

        /// <summary>
        /// 更改341入库标记
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public string EditPqv ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQV SET PQV93='T'" );
            strSql.Append( " WHERE PQV76 IN (" + strWhere + ")" );

            return strSql.ToString( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfReceviable ( string oddNum )
        {
            //CASE WHEN PQV16>'95' OR PQV16='清水' THEN '清水' WHEN PQV16<'95' OR PQV16='混水' THEN '混水' END PQV16,
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT PQV01,CASE WHEN PQV92='F' OR PQV92 IS NULL THEN 'F' WHEN PQV92='T' THEN 'T' END PQV92,CASE WHEN PQV86 LIKE '%荷%' THEN '荷木' WHEN PQV86 LIKE '%松%' THEN '新西兰松' WHEN PQV86 LIKE '%榉%' THEN '榉木' WHEN PQV86 LIKE '%椴%' THEN '椴木' WHEN PQV86 LIKE '%桦%' THEN '桦木' ELSE '杂木' END PQV86,PQV65,CASE WHEN PQV88='T' THEN 'T' ELSE 'F' END PQV88,CONVERT(DECIMAL(18,1),SUM(PQV11*PQV66*PQV81*PQV67*PQV13)) PQV FROM R_PQV A INNER JOIN R_REVIEWS D ON A.PQV76=D.RES06 AND RES05='执行'" );
            strSql.AppendFormat( " WHERE PQV01!='' AND PQV76='{0}' AND (PQV01!='' AND PQV01 IS NOT NULL) GROUP BY PQV01,PQV86,PQV65,PQV88,PQV92" ,oddNum );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 写数据到241
        /// </summary>
        /// <param name="modelAm"></param>
        /// <returns></returns>
        public bool UpdateOfReceviable ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum )
        {
            ArrayList SQLString = new ArrayList( );
            ByOneBy( modelAm ,oddNum ,SQLString );
            //WriteReceivableToGeneralLedger.ByOneByMuCai( modelAm ,oddNum ,SQLString );
            if ( modelAm.AM261 > 0 )
            {
                StringBuilder strSqlAM261 = new StringBuilder( );
                strSqlAM261.AppendFormat( "UPDATE R_PQAM SET AM261='{0}' WHERE AM002='{1}'" ,modelAm.AM261 ,modelAm.AM002 );
                SQLString.Add( strSqlAM261.ToString( ) );
            }
            if ( modelAm.AM263 > 0 )
            {
                StringBuilder strSqlAM263 = new StringBuilder( );
                strSqlAM263.AppendFormat( "UPDATE R_PQAM SET AM263='{0}' WHERE AM002='{1}'" ,modelAm.AM263 ,modelAm.AM002 );
                SQLString.Add( strSqlAM263.ToString( ) );
            }
            if ( modelAm.AM265 > 0 )
            {
                StringBuilder strSqlAM265 = new StringBuilder( );
                strSqlAM265.AppendFormat( "UPDATE R_PQAM SET AM265='{0}' WHERE AM002='{1}'" ,modelAm.AM265 ,modelAm.AM002 );
                SQLString.Add( strSqlAM265.ToString( ) );
            }
            if ( modelAm.AM267 > 0 )
            {
                StringBuilder strSqlAM267 = new StringBuilder( );
                strSqlAM267.AppendFormat( "UPDATE R_PQAM SET AM267='{0}' WHERE AM002='{1}'" ,modelAm.AM267 ,modelAm.AM002 );
                SQLString.Add( strSqlAM267.ToString( ) );
            }
            if ( modelAm.AM287 > 0 )
            {
                StringBuilder strSqlAM287 = new StringBuilder( );
                strSqlAM287.AppendFormat( "UPDATE R_PQAM SET AM287='{0}' WHERE AM002='{1}'" ,modelAm.AM287 ,modelAm.AM002 );
                SQLString.Add( strSqlAM287.ToString( ) );
            }
            if ( modelAm.AM288 > 0 )
            {
                StringBuilder strSqlAM288 = new StringBuilder( );
                strSqlAM288.AppendFormat( "UPDATE R_PQAM SET AM288='{0}' WHERE AM002='{1}'" ,modelAm.AM288 ,modelAm.AM002 );
                SQLString.Add( strSqlAM288.ToString( ) );
            }
            if ( modelAm.AM290 > 0 )
            {
                StringBuilder strSqlAM290 = new StringBuilder( );
                strSqlAM290.AppendFormat( "UPDATE R_PQAM SET AM290='{0}' WHERE AM002='{1}'" ,modelAm.AM290 ,modelAm.AM002 );
                SQLString.Add( strSqlAM290.ToString( ) );
            }
            if ( modelAm.AM292 > 0 )
            {
                StringBuilder strSqlAM292 = new StringBuilder( );
                strSqlAM292.AppendFormat( "UPDATE R_PQAM SET AM292='{0}' WHERE AM002='{1}'" ,modelAm.AM292 ,modelAm.AM002 );
                SQLString.Add( strSqlAM292.ToString( ) );
            }
            if ( modelAm.AM294 > 0 )
            {
                StringBuilder strSqlAM294 = new StringBuilder( );
                strSqlAM294.AppendFormat( "UPDATE R_PQAM SET AM294='{0}' WHERE AM002='{1}'" ,modelAm.AM294 ,modelAm.AM002 );
                SQLString.Add( strSqlAM294.ToString( ) );
            }
            if ( modelAm.AM330 > 0 )
            {
                StringBuilder strSqlAM330 = new StringBuilder( );
                strSqlAM330.AppendFormat( "UPDATE R_PQAM SET AM330='{0}' WHERE AM002='{1}'" ,modelAm.AM330 ,modelAm.AM002 );
                SQLString.Add( strSqlAM330.ToString( ) );
            }
            if ( modelAm.AM332 > 0 )
            {
                StringBuilder strSqlAM332 = new StringBuilder( );
                strSqlAM332.AppendFormat( "UPDATE R_PQAM SET AM332='{0}' WHERE AM002='{1}'" ,modelAm.AM332 ,modelAm.AM002 );
                SQLString.Add( strSqlAM332.ToString( ) );
            }
            if ( modelAm.AM333 > 0 )
            {
                StringBuilder strSqlAM333 = new StringBuilder( );
                strSqlAM333.AppendFormat( "UPDATE R_PQAM SET AM333='{0}' WHERE AM002='{1}'" ,modelAm.AM333 ,modelAm.AM002 );
                SQLString.Add( strSqlAM333.ToString( ) );
            }
            if ( modelAm.AM336 > 0 )
            {
                StringBuilder strSqlAM336 = new StringBuilder( );
                strSqlAM336.AppendFormat( "UPDATE R_PQAM SET AM336='{0}' WHERE AM002='{1}'" ,modelAm.AM336 ,modelAm.AM002 );
                SQLString.Add( strSqlAM336.ToString( ) );
            }
            if ( modelAm.AM338 > 0 )
            {
                StringBuilder strSqlAM338 = new StringBuilder( );
                strSqlAM338.AppendFormat( "UPDATE R_PQAM SET AM338='{0}' WHERE AM002='{1}'" ,modelAm.AM338 ,modelAm.AM002 );
                SQLString.Add( strSqlAM338.ToString( ) );
            }
            if ( modelAm.AM343 > 0 )
            {
                StringBuilder strSqlAM343 = new StringBuilder( );
                strSqlAM343.AppendFormat( "UPDATE R_PQAM SET AM343='{0}' WHERE AM002='{1}'" ,modelAm.AM343 ,modelAm.AM002 );
                SQLString.Add( strSqlAM343.ToString( ) );
            }
            if ( modelAm.AM345 > 0 )
            {
                StringBuilder strSqlAM345 = new StringBuilder( );
                strSqlAM345.AppendFormat( "UPDATE R_PQAM SET AM345='{0}' WHERE AM002='{1}'" ,modelAm.AM345 ,modelAm.AM002 );
                SQLString.Add( strSqlAM345.ToString( ) );
            }
            if ( modelAm.AM346 > 0 )
            {
                StringBuilder strSqlAM346 = new StringBuilder( );
                strSqlAM346.AppendFormat( "UPDATE R_PQAM SET AM346='{0}' WHERE AM002='{1}'" ,modelAm.AM346 ,modelAm.AM002 );
                SQLString.Add( strSqlAM346.ToString( ) );
            }
            if ( modelAm.AM349 > 0 )
            {
                StringBuilder strSqlAM349 = new StringBuilder( );
                strSqlAM349.AppendFormat( "UPDATE R_PQAM SET AM349='{0}' WHERE AM002='{1}'" ,modelAm.AM349 ,modelAm.AM002 );
                SQLString.Add( strSqlAM349.ToString( ) );
            }
            if ( modelAm.AM351 > 0 )
            {
                StringBuilder strSqlAM351 = new StringBuilder( );
                strSqlAM351.AppendFormat( "UPDATE R_PQAM SET AM351='{0}' WHERE AM002='{1}'" ,modelAm.AM351 ,modelAm.AM002 );
                SQLString.Add( strSqlAM351.ToString( ) );
            }
            if ( modelAm.AM352 > 0 )
            {
                StringBuilder strSqlAM352 = new StringBuilder( );
                strSqlAM352.AppendFormat( "UPDATE R_PQAM SET AM352='{0}' WHERE AM002='{1}'" ,modelAm.AM352 ,modelAm.AM002 );
                SQLString.Add( strSqlAM352.ToString( ) );
            }
            if ( modelAm.AM355 > 0 )
            {
                StringBuilder strSqlAM355 = new StringBuilder( );
                strSqlAM355.AppendFormat( "UPDATE R_PQAM SET AM355='{0}' WHERE AM002='{1}'" ,modelAm.AM355 ,modelAm.AM002 );
                SQLString.Add( strSqlAM355.ToString( ) );
            }
            if ( modelAm.AM357 > 0 )
            {
                StringBuilder strSqlAM357 = new StringBuilder( );
                strSqlAM357.AppendFormat( "UPDATE R_PQAM SET AM357='{0}' WHERE AM002='{1}'" ,modelAm.AM357 ,modelAm.AM002 );
                SQLString.Add( strSqlAM357.ToString( ) );
            }
            if ( modelAm.AM358 > 0 )
            {
                StringBuilder strSqlAM358 = new StringBuilder( );
                strSqlAM358.AppendFormat( "UPDATE R_PQAM SET AM358='{0}' WHERE AM002='{1}'" ,modelAm.AM358 ,modelAm.AM002 );
                SQLString.Add( strSqlAM358.ToString( ) );
            }
            if ( modelAm.AM361 > 0 )
            {
                StringBuilder strSqlAM361 = new StringBuilder( );
                strSqlAM361.AppendFormat( "UPDATE R_PQAM SET AM361='{0}' WHERE AM002='{1}'" ,modelAm.AM361 ,modelAm.AM002 );
                SQLString.Add( strSqlAM361.ToString( ) );
            }
            if ( modelAm.AM363 > 0 )
            {
                StringBuilder strSqlAM363 = new StringBuilder( );
                strSqlAM363.AppendFormat( "UPDATE R_PQAM SET AM363='{0}' WHERE AM002='{1}'" ,modelAm.AM363 ,modelAm.AM002 );
                SQLString.Add( strSqlAM363.ToString( ) );
            }
            if ( modelAm.AM364 > 0 )
            {
                StringBuilder strSqlAM364 = new StringBuilder( );
                strSqlAM364.AppendFormat( "UPDATE R_PQAM SET AM364='{0}' WHERE AM002='{1}'" ,modelAm.AM364 ,modelAm.AM002 );
                SQLString.Add( strSqlAM364.ToString( ) );
            }
            if ( modelAm.AM367 > 0 )
            {
                StringBuilder strSqlAM367 = new StringBuilder( );
                strSqlAM367.AppendFormat( "UPDATE R_PQAM SET AM367='{0}' WHERE AM002='{1}'" ,modelAm.AM367 ,modelAm.AM002 );
                SQLString.Add( strSqlAM367.ToString( ) );
            }
            if ( modelAm.AM369 > 0 )
            {
                StringBuilder strSqlAM369 = new StringBuilder( );
                strSqlAM369.AppendFormat( "UPDATE R_PQAM SET AM369='{0}' WHERE AM002='{1}'" ,modelAm.AM369 ,modelAm.AM002 );
                SQLString.Add( strSqlAM369.ToString( ) );
            }
            if ( modelAm.AM370 > 0 )
            {
                StringBuilder strSqlAM370 = new StringBuilder( );
                strSqlAM370.AppendFormat( "UPDATE R_PQAM SET AM370='{0}' WHERE AM002='{1}'" ,modelAm.AM370 ,modelAm.AM002 );
                SQLString.Add( strSqlAM370.ToString( ) );
            }
            if ( modelAm.AM373 > 0 )
            {
                StringBuilder strSqlAM373 = new StringBuilder( );
                strSqlAM373.AppendFormat( "UPDATE R_PQAM SET AM373='{0}' WHERE AM002='{1}'" ,modelAm.AM373 ,modelAm.AM002 );
                SQLString.Add( strSqlAM373.ToString( ) );
            }
            if ( modelAm.AM375 > 0 )
            {
                StringBuilder strSqlAM375 = new StringBuilder( );
                strSqlAM375.AppendFormat( "UPDATE R_PQAM SET AM375='{0}' WHERE AM002='{1}'" ,modelAm.AM375 ,modelAm.AM002 );
                SQLString.Add( strSqlAM375.ToString( ) );
            }
            if ( modelAm.AM376 > 0 )
            {
                StringBuilder strSqlAM376 = new StringBuilder( );
                strSqlAM376.AppendFormat( "UPDATE R_PQAM SET AM376='{0}' WHERE AM002='{1}'" ,modelAm.AM376 ,modelAm.AM002 );
                SQLString.Add( strSqlAM376.ToString( ) );
            }
            if ( modelAm.AM379 > 0 )
            {
                StringBuilder strSqlAM379 = new StringBuilder( );
                strSqlAM379.AppendFormat( "UPDATE R_PQAM SET AM379='{0}' WHERE AM002='{1}'" ,modelAm.AM379 ,modelAm.AM002 );
                SQLString.Add( strSqlAM379.ToString( ) );
            }
            if ( modelAm.AM381 > 0 )
            {
                StringBuilder strSqlAM381 = new StringBuilder( );
                strSqlAM381.AppendFormat( "UPDATE R_PQAM SET AM381='{0}' WHERE AM002='{1}'" ,modelAm.AM381 ,modelAm.AM002 );
                SQLString.Add( strSqlAM381.ToString( ) );
            }
            if ( modelAm.AM382 > 0 )
            {
                StringBuilder strSqlAM382 = new StringBuilder( );
                strSqlAM382.AppendFormat( "UPDATE R_PQAM SET AM382='{0}' WHERE AM002='{1}'" ,modelAm.AM382 ,modelAm.AM002 );
                SQLString.Add( strSqlAM382.ToString( ) );
            }
            if ( modelAm.AM385 > 0 )
            {
                StringBuilder strSqlAM385 = new StringBuilder( );
                strSqlAM385.AppendFormat( "UPDATE R_PQAM SET AM385='{0}' WHERE AM002='{1}'" ,modelAm.AM385 ,modelAm.AM002 );
                SQLString.Add( strSqlAM385.ToString( ) );
            }
            if ( modelAm.AM388 > 0 )
            {
                StringBuilder strSqlAM388 = new StringBuilder( );
                strSqlAM388.AppendFormat( "UPDATE R_PQAM SET AM388='{0}' WHERE AM002='{1}'" ,modelAm.AM388 ,modelAm.AM002 );
                SQLString.Add( strSqlAM388.ToString( ) );
            }
            if ( modelAm.AM390 > 0 )
            {
                StringBuilder strSqlAM390 = new StringBuilder( );
                strSqlAM390.AppendFormat( "UPDATE R_PQAM SET AM390='{0}' WHERE AM002='{1}'" ,modelAm.AM390 ,modelAm.AM002 );
                SQLString.Add( strSqlAM390.ToString( ) );
            }
            if ( modelAm.AM391 > 0 )
            {
                StringBuilder strSqlAM391 = new StringBuilder( );
                strSqlAM391.AppendFormat( "UPDATE R_PQAM SET AM391='{0}' WHERE AM002='{1}'" ,modelAm.AM391 ,modelAm.AM002 );
                SQLString.Add( strSqlAM391.ToString( ) );
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        
        void ByOneBy ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum ,ArrayList SQLString )
        {
            //modelAm.AM261 = modelAm.AM263 = modelAm.AM265 = modelAm.AM267 = modelAm.AM287 = modelAm.AM288 = modelAm.AM290 = modelAm.AM292 = modelAm.AM294 = modelAm.AM330 = modelAm.AM332 = modelAm.AM333 = modelAm.AM336 = modelAm.AM338 = modelAm.AM343 = modelAm.AM345 = modelAm.AM346 = modelAm.AM349 = modelAm.AM351 = modelAm.AM352 = modelAm.AM355 = modelAm.AM357 = modelAm.AM358 = modelAm.AM361 = modelAm.AM363 = modelAm.AM364 = modelAm.AM367 = modelAm.AM369 = modelAm.AM370 = modelAm.AM373 = modelAm.AM375 = modelAm.AM376 = modelAm.AM379 = modelAm.AM381 = modelAm.AM382 = modelAm.AM385 = modelAm.AM388 = modelAm.AM390 = modelAm.AM391 = 0;
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "SELECT AMB261,AMB263,AMB265,AMB267,AMB287,AMB288,AMB290,AMB292,AMB294,AMB330,AMB332,AMB333,AMB336,AMB338,AMB343,AMB345,AMB346,AMB349,AMB351,AMB352,AMB355,AMB357,AMB358,AMB361,AMB363,AMB364,AMB367,AMB369,AMB370,AMB373,AMB375,AMB376,AMB379,AMB381,AMB382,AMB385,AMB388,AMB390,AMB391 FROM R_PQAMB WHERE AMB001='{0}'" ,oddNum );

            DataTable de = SqlHelper.ExecuteDataTable( "SELECT AM261,AM263,AM265,AM267,AM287,AM288,AM290,AM292,AM294,AM330,AM332,AM333,AM336,AM338,AM343,AM345,AM346,AM349,AM351,AM352,AM355,AM357,AM358,AM361,AM363,AM364,AM367,AM369,AM370,AM373,AM375,AM376,AM379,AM381,AM382,AM385,AM388,AM390,AM391 FROM R_PQAM WHERE AM002='" + modelAm.AM002 + "'" );
            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) );

            if ( da != null && da.Rows.Count > 0 )
            {
                if ( modelAm.AM261 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB261='{0}' WHERE AMB001='{1}'" ,modelAm.AM261 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM263 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB263='{0}' WHERE AMB001='{1}'" ,modelAm.AM263 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM265 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB265='{0}' WHERE AMB001='{1}'" ,modelAm.AM265 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM267 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB267='{0}' WHERE AMB001='{1}'" ,modelAm.AM267 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM287 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB287='{0}' WHERE AMB001='{1}'" ,modelAm.AM287 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM288 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB288='{0}' WHERE AMB001='{1}'" ,modelAm.AM288 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM290 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB290='{0}' WHERE AMB001='{1}'" ,modelAm.AM290 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM292 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB292='{0}' WHERE AMB001='{1}'" ,modelAm.AM292 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM294 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB294='{0}' WHERE AMB001='{1}'" ,modelAm.AM294 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM330 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB330='{0}' WHERE AMB001='{1}'" ,modelAm.AM330 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM332 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB332='{0}' WHERE AMB001='{1}'" ,modelAm.AM332 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM333 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB333='{0}' WHERE AMB001='{1}'" ,modelAm.AM333 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM336 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB336='{0}' WHERE AMB001='{1}'" ,modelAm.AM336 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM338 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB338='{0}' WHERE AMB001='{1}'" ,modelAm.AM338 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM343 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB343='{0}' WHERE AMB001='{1}'" ,modelAm.AM343 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM345 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB345='{0}' WHERE AMB001='{1}'" ,modelAm.AM345 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM346 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB346='{0}' WHERE AMB001='{1}'" ,modelAm.AM346 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM349 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB349='{0}' WHERE AMB001='{1}'" ,modelAm.AM349 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM351 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB351='{0}' WHERE AMB001='{1}'" ,modelAm.AM351 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM352 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB352='{0}' WHERE AMB001='{1}'" ,modelAm.AM352 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM355 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB355='{0}' WHERE AMB001='{1}'" ,modelAm.AM355 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM357 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB357='{0}' WHERE AMB001='{1}'" ,modelAm.AM357 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM358 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB358='{0}' WHERE AMB001='{1}'" ,modelAm.AM358 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM361 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB361='{0}' WHERE AMB001='{1}'" ,modelAm.AM361 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM363 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB363='{0}' WHERE AMB001='{1}'" ,modelAm.AM363 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM364 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB364='{0}' WHERE AMB001='{1}'" ,modelAm.AM364 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM367 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB367='{0}' WHERE AMB001='{1}'" ,modelAm.AM367 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM369 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB369='{0}' WHERE AMB001='{1}'" ,modelAm.AM369 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM370 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB370='{0}' WHERE AMB001='{1}'" ,modelAm.AM370 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM373 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB373='{0}' WHERE AMB001='{1}'" ,modelAm.AM373 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM375 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB375='{0}' WHERE AMB001='{1}'" ,modelAm.AM375 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM376 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB376='{0}' WHERE AMB001='{1}'" ,modelAm.AM376 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM379 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB379='{0}' WHERE AMB001='{1}'" ,modelAm.AM379 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM381 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB381='{0}' WHERE AMB001='{1}'" ,modelAm.AM381 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM382 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB382='{0}' WHERE AMB001='{1}'" ,modelAm.AM382 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM385 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB385='{0}' WHERE AMB001='{1}'" ,modelAm.AM385 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM388 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB388='{0}' WHERE AMB001='{1}'" ,modelAm.AM388 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM390 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB390='{0}' WHERE AMB001='{1}'" ,modelAm.AM390 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM391 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB391='{0}' WHERE AMB001='{1}'" ,modelAm.AM391 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                
                if ( de != null && de.Rows.Count > 0 )
                {
                    modelAm.AM261 = modelAm.AM261 - ( string.IsNullOrEmpty( da.Rows[0]["AMB261"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB261"].ToString( ) ) );
                    modelAm.AM263 = modelAm.AM263 - ( string.IsNullOrEmpty( da.Rows[0]["AMB263"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB263"].ToString( ) ) );
                    modelAm.AM265 = modelAm.AM265 - ( string.IsNullOrEmpty( da.Rows[0]["AMB265"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB265"].ToString( ) ) );
                    modelAm.AM267 = modelAm.AM267 - ( string.IsNullOrEmpty( da.Rows[0]["AMB267"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB267"].ToString( ) ) );
                    modelAm.AM287 = modelAm.AM287 - ( string.IsNullOrEmpty( da.Rows[0]["AMB287"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB287"].ToString( ) ) );
                    modelAm.AM288 = modelAm.AM288 - ( string.IsNullOrEmpty( da.Rows[0]["AMB288"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB288"].ToString( ) ) );
                    modelAm.AM290 = modelAm.AM290 - ( string.IsNullOrEmpty( da.Rows[0]["AMB290"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB290"].ToString( ) ) );
                    modelAm.AM292 = modelAm.AM292 - ( string.IsNullOrEmpty( da.Rows[0]["AMB292"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB292"].ToString( ) ) );
                    modelAm.AM294 = modelAm.AM294 - ( string.IsNullOrEmpty( da.Rows[0]["AMB294"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB294"].ToString( ) ) );
                    modelAm.AM330 = modelAm.AM330 - ( string.IsNullOrEmpty( da.Rows[0]["AMB330"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB330"].ToString( ) ) );
                    modelAm.AM333 = modelAm.AM333 - ( string.IsNullOrEmpty( da.Rows[0]["AMB333"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB333"].ToString( ) ) );
                    modelAm.AM336 = modelAm.AM336 - ( string.IsNullOrEmpty( da.Rows[0]["AMB336"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB336"].ToString( ) ) );
                    modelAm.AM338 = modelAm.AM338 - ( string.IsNullOrEmpty( da.Rows[0]["AMB338"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB338"].ToString( ) ) );
                    modelAm.AM343 = modelAm.AM343 - ( string.IsNullOrEmpty( da.Rows[0]["AMB343"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB343"].ToString( ) ) );
                    modelAm.AM345 = modelAm.AM345 - ( string.IsNullOrEmpty( da.Rows[0]["AMB345"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB345"].ToString( ) ) );
                    modelAm.AM346 = modelAm.AM346 - ( string.IsNullOrEmpty( da.Rows[0]["AMB346"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB346"].ToString( ) ) );
                    modelAm.AM349 = modelAm.AM349 - ( string.IsNullOrEmpty( da.Rows[0]["AMB349"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB349"].ToString( ) ) );
                    modelAm.AM351 = modelAm.AM351 - ( string.IsNullOrEmpty( da.Rows[0]["AMB351"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB351"].ToString( ) ) );
                    modelAm.AM352 = modelAm.AM352 - ( string.IsNullOrEmpty( da.Rows[0]["AMB352"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB352"].ToString( ) ) );
                    modelAm.AM355 = modelAm.AM355 - ( string.IsNullOrEmpty( da.Rows[0]["AMB355"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB355"].ToString( ) ) );
                    modelAm.AM357 = modelAm.AM357 - ( string.IsNullOrEmpty( da.Rows[0]["AMB357"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB357"].ToString( ) ) );
                    modelAm.AM358 = modelAm.AM358 - ( string.IsNullOrEmpty( da.Rows[0]["AMB358"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB358"].ToString( ) ) );
                    modelAm.AM361 = modelAm.AM361 - ( string.IsNullOrEmpty( da.Rows[0]["AMB361"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB361"].ToString( ) ) );
                    modelAm.AM363 = modelAm.AM363 - ( string.IsNullOrEmpty( da.Rows[0]["AMB363"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB363"].ToString( ) ) );
                    modelAm.AM364 = modelAm.AM364 - ( string.IsNullOrEmpty( da.Rows[0]["AMB364"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB364"].ToString( ) ) );
                    modelAm.AM367 = modelAm.AM367 - ( string.IsNullOrEmpty( da.Rows[0]["AMB367"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB367"].ToString( ) ) );
                    modelAm.AM369 = modelAm.AM369 - ( string.IsNullOrEmpty( da.Rows[0]["AMB369"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB369"].ToString( ) ) );
                    modelAm.AM370 = modelAm.AM370 - ( string.IsNullOrEmpty( da.Rows[0]["AMB370"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB370"].ToString( ) ) );
                    modelAm.AM373 = modelAm.AM373 - ( string.IsNullOrEmpty( da.Rows[0]["AMB373"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB373"].ToString( ) ) );
                    modelAm.AM375 = modelAm.AM375 - ( string.IsNullOrEmpty( da.Rows[0]["AMB375"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB375"].ToString( ) ) );
                    modelAm.AM376 = modelAm.AM376 - ( string.IsNullOrEmpty( da.Rows[0]["AMB376"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB376"].ToString( ) ) );
                    modelAm.AM379 = modelAm.AM379 - ( string.IsNullOrEmpty( da.Rows[0]["AMB379"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB379"].ToString( ) ) );
                    modelAm.AM381 = modelAm.AM381 - ( string.IsNullOrEmpty( da.Rows[0]["AMB381"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB381"].ToString( ) ) );
                    modelAm.AM382 = modelAm.AM382 - ( string.IsNullOrEmpty( da.Rows[0]["AMB382"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB382"].ToString( ) ) );
                    modelAm.AM385 = modelAm.AM385 - ( string.IsNullOrEmpty( da.Rows[0]["AMB385"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB385"].ToString( ) ) );
                    modelAm.AM388 = modelAm.AM388 - ( string.IsNullOrEmpty( da.Rows[0]["AMB388"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB388"].ToString( ) ) );
                    modelAm.AM390 = modelAm.AM390 - ( string.IsNullOrEmpty( da.Rows[0]["AMB390"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB390"].ToString( ) ) );
                    modelAm.AM391 = modelAm.AM391 - ( string.IsNullOrEmpty( da.Rows[0]["AMB391"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB391"].ToString( ) ) );

                    modelAm.AM261 = modelAm.AM261 + ( string.IsNullOrEmpty( de.Rows[0]["AM261"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM261"].ToString( ) ) );
                    modelAm.AM263 = modelAm.AM263 + ( string.IsNullOrEmpty( de.Rows[0]["AM263"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM263"].ToString( ) ) );
                    modelAm.AM265 = modelAm.AM265 + ( string.IsNullOrEmpty( de.Rows[0]["AM265"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM265"].ToString( ) ) );
                    modelAm.AM267 = modelAm.AM267 + ( string.IsNullOrEmpty( de.Rows[0]["AM267"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM267"].ToString( ) ) );
                    modelAm.AM287 = modelAm.AM287 + ( string.IsNullOrEmpty( de.Rows[0]["AM287"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM287"].ToString( ) ) );
                    modelAm.AM288 = modelAm.AM288 + ( string.IsNullOrEmpty( de.Rows[0]["AM288"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM288"].ToString( ) ) );
                    modelAm.AM290 = modelAm.AM290 + ( string.IsNullOrEmpty( de.Rows[0]["AM290"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM290"].ToString( ) ) );
                    modelAm.AM292 = modelAm.AM292 + ( string.IsNullOrEmpty( de.Rows[0]["AM292"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM292"].ToString( ) ) );
                    modelAm.AM294 = modelAm.AM294 + ( string.IsNullOrEmpty( de.Rows[0]["AM294"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM294"].ToString( ) ) );
                    modelAm.AM330 = modelAm.AM330 + ( string.IsNullOrEmpty( de.Rows[0]["AM330"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM330"].ToString( ) ) );
                    modelAm.AM333 = modelAm.AM333 + ( string.IsNullOrEmpty( de.Rows[0]["AM333"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM333"].ToString( ) ) );
                    modelAm.AM336 = modelAm.AM336 + ( string.IsNullOrEmpty( de.Rows[0]["AM336"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM336"].ToString( ) ) );
                    modelAm.AM338 = modelAm.AM338 + ( string.IsNullOrEmpty( de.Rows[0]["AM338"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM338"].ToString( ) ) );
                    modelAm.AM343 = modelAm.AM343 + ( string.IsNullOrEmpty( de.Rows[0]["AM343"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM343"].ToString( ) ) );
                    modelAm.AM345 = modelAm.AM345 + ( string.IsNullOrEmpty( de.Rows[0]["AM345"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM345"].ToString( ) ) );
                    modelAm.AM346 = modelAm.AM346 + ( string.IsNullOrEmpty( de.Rows[0]["AM346"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM346"].ToString( ) ) );
                    modelAm.AM349 = modelAm.AM349 + ( string.IsNullOrEmpty( de.Rows[0]["AM349"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM349"].ToString( ) ) );
                    modelAm.AM351 = modelAm.AM351 + ( string.IsNullOrEmpty( de.Rows[0]["AM351"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM351"].ToString( ) ) );
                    modelAm.AM352 = modelAm.AM352 + ( string.IsNullOrEmpty( de.Rows[0]["AM352"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM352"].ToString( ) ) );
                    modelAm.AM355 = modelAm.AM355 + ( string.IsNullOrEmpty( de.Rows[0]["AM355"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM355"].ToString( ) ) );
                    modelAm.AM357 = modelAm.AM357 + ( string.IsNullOrEmpty( de.Rows[0]["AM357"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM357"].ToString( ) ) );
                    modelAm.AM358 = modelAm.AM358 + ( string.IsNullOrEmpty( de.Rows[0]["AM358"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM358"].ToString( ) ) );
                    modelAm.AM361 = modelAm.AM361 + ( string.IsNullOrEmpty( de.Rows[0]["AM361"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM361"].ToString( ) ) );
                    modelAm.AM363 = modelAm.AM363 + ( string.IsNullOrEmpty( de.Rows[0]["AM363"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM363"].ToString( ) ) );
                    modelAm.AM364 = modelAm.AM364 + ( string.IsNullOrEmpty( de.Rows[0]["AM364"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM364"].ToString( ) ) );
                    modelAm.AM367 = modelAm.AM367 + ( string.IsNullOrEmpty( de.Rows[0]["AM367"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM367"].ToString( ) ) );
                    modelAm.AM369 = modelAm.AM369 + ( string.IsNullOrEmpty( de.Rows[0]["AM369"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM369"].ToString( ) ) );
                    modelAm.AM370 = modelAm.AM370 + ( string.IsNullOrEmpty( de.Rows[0]["AM370"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM370"].ToString( ) ) );
                    modelAm.AM373 = modelAm.AM373 + ( string.IsNullOrEmpty( de.Rows[0]["AM373"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM373"].ToString( ) ) );
                    modelAm.AM375 = modelAm.AM375 + ( string.IsNullOrEmpty( de.Rows[0]["AM375"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM375"].ToString( ) ) );
                    modelAm.AM376 = modelAm.AM376 + ( string.IsNullOrEmpty( de.Rows[0]["AM376"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM376"].ToString( ) ) );
                    modelAm.AM379 = modelAm.AM379 + ( string.IsNullOrEmpty( de.Rows[0]["AM379"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM379"].ToString( ) ) );
                    modelAm.AM381 = modelAm.AM381 + ( string.IsNullOrEmpty( de.Rows[0]["AM381"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM381"].ToString( ) ) );
                    modelAm.AM382 = modelAm.AM382 + ( string.IsNullOrEmpty( de.Rows[0]["AM382"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM382"].ToString( ) ) );
                    modelAm.AM385 = modelAm.AM385 + ( string.IsNullOrEmpty( de.Rows[0]["AM385"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM385"].ToString( ) ) );
                    modelAm.AM388 = modelAm.AM388 + ( string.IsNullOrEmpty( de.Rows[0]["AM388"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM388"].ToString( ) ) );
                    modelAm.AM390 = modelAm.AM390 + ( string.IsNullOrEmpty( de.Rows[0]["AM390"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM390"].ToString( ) ) );
                    modelAm.AM391 = modelAm.AM391 + ( string.IsNullOrEmpty( de.Rows[0]["AM391"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM391"].ToString( ) ) );
                }
                
            }
            else
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "INSERT INTO R_PQAMB  (AMB001,AMB261,AMB263,AMB265,AMB267,AMB287,AMB288,AMB290,AMB292,AMB294,AMB330,AMB332,AMB333,AMB336,AMB338,AMB343,AMB345,AMB346,AMB349,AMB351,AMB352,AMB355,AMB357,AMB358,AMB361,AMB363,AMB364,AMB367,AMB369,AMB370,AMB373,AMB375,AMB376,AMB379,AMB381,AMB382,AMB385,AMB388,AMB390,AMB391) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}','{38}','{39}')" ,oddNum ,modelAm.AM261 ,modelAm.AM263 ,modelAm.AM265 ,modelAm.AM267 ,modelAm.AM287 ,modelAm.AM288 ,modelAm.AM290 ,modelAm.AM292 ,modelAm.AM294 ,modelAm.AM330 ,modelAm.AM332 ,modelAm.AM333 ,modelAm.AM336 ,modelAm.AM338 ,modelAm.AM343 ,modelAm.AM345 ,modelAm.AM346 ,modelAm.AM349 ,modelAm.AM351 ,modelAm.AM352 ,modelAm.AM355 ,modelAm.AM357 ,modelAm.AM358 ,modelAm.AM361 ,modelAm.AM363 ,modelAm.AM364 ,modelAm.AM367 ,modelAm.AM369 ,modelAm.AM370 ,modelAm.AM373 ,modelAm.AM375 ,modelAm.AM376 ,modelAm.AM379 ,modelAm.AM381 ,modelAm.AM382 ,modelAm.AM385 ,modelAm.AM388 ,modelAm.AM390 ,modelAm.AM391 );
                SQLString.Add( strSql.ToString( ) );
                if ( de != null && de.Rows.Count > 0 )
                {
                    modelAm.AM261 = modelAm.AM261 + ( string.IsNullOrEmpty( de.Rows[0]["AM261"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM261"].ToString( ) ) );
                    modelAm.AM263 = modelAm.AM263 + ( string.IsNullOrEmpty( de.Rows[0]["AM263"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM263"].ToString( ) ) );
                    modelAm.AM265 = modelAm.AM265 + ( string.IsNullOrEmpty( de.Rows[0]["AM265"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM265"].ToString( ) ) );
                    modelAm.AM267 = modelAm.AM267 + ( string.IsNullOrEmpty( de.Rows[0]["AM267"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM267"].ToString( ) ) );
                    modelAm.AM287 = modelAm.AM287 + ( string.IsNullOrEmpty( de.Rows[0]["AM287"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM287"].ToString( ) ) );
                    modelAm.AM288 = modelAm.AM288 + ( string.IsNullOrEmpty( de.Rows[0]["AM288"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM288"].ToString( ) ) );
                    modelAm.AM290 = modelAm.AM290 + ( string.IsNullOrEmpty( de.Rows[0]["AM290"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM290"].ToString( ) ) );
                    modelAm.AM292 = modelAm.AM292 + ( string.IsNullOrEmpty( de.Rows[0]["AM292"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM292"].ToString( ) ) );
                    modelAm.AM294 = modelAm.AM294 + ( string.IsNullOrEmpty( de.Rows[0]["AM294"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM294"].ToString( ) ) );
                    modelAm.AM330 = modelAm.AM330 + ( string.IsNullOrEmpty( de.Rows[0]["AM330"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM330"].ToString( ) ) );
                    modelAm.AM333 = modelAm.AM333 + ( string.IsNullOrEmpty( de.Rows[0]["AM333"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM333"].ToString( ) ) );
                    modelAm.AM336 = modelAm.AM336 + ( string.IsNullOrEmpty( de.Rows[0]["AM336"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM336"].ToString( ) ) );
                    modelAm.AM338 = modelAm.AM338 + ( string.IsNullOrEmpty( de.Rows[0]["AM338"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM338"].ToString( ) ) );
                    modelAm.AM343 = modelAm.AM343 + ( string.IsNullOrEmpty( de.Rows[0]["AM343"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM343"].ToString( ) ) );
                    modelAm.AM345 = modelAm.AM345 + ( string.IsNullOrEmpty( de.Rows[0]["AM345"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM345"].ToString( ) ) );
                    modelAm.AM346 = modelAm.AM346 + ( string.IsNullOrEmpty( de.Rows[0]["AM346"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM346"].ToString( ) ) );
                    modelAm.AM349 = modelAm.AM349 + ( string.IsNullOrEmpty( de.Rows[0]["AM349"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM349"].ToString( ) ) );
                    modelAm.AM351 = modelAm.AM351 + ( string.IsNullOrEmpty( de.Rows[0]["AM351"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM351"].ToString( ) ) );
                    modelAm.AM352 = modelAm.AM352 + ( string.IsNullOrEmpty( de.Rows[0]["AM352"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM352"].ToString( ) ) );
                    modelAm.AM355 = modelAm.AM355 + ( string.IsNullOrEmpty( de.Rows[0]["AM355"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM355"].ToString( ) ) );
                    modelAm.AM357 = modelAm.AM357 + ( string.IsNullOrEmpty( de.Rows[0]["AM357"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM357"].ToString( ) ) );
                    modelAm.AM358 = modelAm.AM358 + ( string.IsNullOrEmpty( de.Rows[0]["AM358"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM358"].ToString( ) ) );
                    modelAm.AM361 = modelAm.AM361 + ( string.IsNullOrEmpty( de.Rows[0]["AM361"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM361"].ToString( ) ) );
                    modelAm.AM363 = modelAm.AM363 + ( string.IsNullOrEmpty( de.Rows[0]["AM363"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM363"].ToString( ) ) );
                    modelAm.AM364 = modelAm.AM364 + ( string.IsNullOrEmpty( de.Rows[0]["AM364"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM364"].ToString( ) ) );
                    modelAm.AM367 = modelAm.AM367 + ( string.IsNullOrEmpty( de.Rows[0]["AM367"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM367"].ToString( ) ) );
                    modelAm.AM369 = modelAm.AM369 + ( string.IsNullOrEmpty( de.Rows[0]["AM369"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM369"].ToString( ) ) );
                    modelAm.AM370 = modelAm.AM370 + ( string.IsNullOrEmpty( de.Rows[0]["AM370"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM370"].ToString( ) ) );
                    modelAm.AM373 = modelAm.AM373 + ( string.IsNullOrEmpty( de.Rows[0]["AM373"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM373"].ToString( ) ) );
                    modelAm.AM375 = modelAm.AM375 + ( string.IsNullOrEmpty( de.Rows[0]["AM375"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM375"].ToString( ) ) );
                    modelAm.AM376 = modelAm.AM376 + ( string.IsNullOrEmpty( de.Rows[0]["AM376"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM376"].ToString( ) ) );
                    modelAm.AM379 = modelAm.AM379 + ( string.IsNullOrEmpty( de.Rows[0]["AM379"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM379"].ToString( ) ) );
                    modelAm.AM381 = modelAm.AM381 + ( string.IsNullOrEmpty( de.Rows[0]["AM381"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM381"].ToString( ) ) );
                    modelAm.AM382 = modelAm.AM382 + ( string.IsNullOrEmpty( de.Rows[0]["AM382"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM382"].ToString( ) ) );
                    modelAm.AM385 = modelAm.AM385 + ( string.IsNullOrEmpty( de.Rows[0]["AM385"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM385"].ToString( ) ) );
                    modelAm.AM388 = modelAm.AM388 + ( string.IsNullOrEmpty( de.Rows[0]["AM388"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM388"].ToString( ) ) );
                    modelAm.AM390 = modelAm.AM390 + ( string.IsNullOrEmpty( de.Rows[0]["AM390"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM390"].ToString( ) ) );
                    modelAm.AM391 = modelAm.AM391 + ( string.IsNullOrEmpty( de.Rows[0]["AM391"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM391"].ToString( ) ) );
                }
                

            }
        }

        /// <summary>
        /// 获取原价切削
        /// </summary>
        /// <param name="numOfGoods">货号</param>
        /// <param name="cName">材料</param>
        /// <param name="lName">零件</param>
        /// <param name="len">半成品长</param>
        /// <param name="width">半成品宽</param>
        /// <param name="height">半成品高</param>
        /// <param name="oddNum">单号</param>
        /// <returns></returns>
        public decimal getPreviousCost ( string numOfGoods ,string cName ,string lName ,string len ,string width ,string height ,string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT CONVERT(DECIMAL(18,3),PQV12*PQV68*PQV69*PQV70*0.000001*PQV11) PQV FROM R_PQV WHERE idx=(SELECT MAX(idx) idx FROM R_PQV WHERE PQV79='{0}' AND PQV86='{1}' AND PQV10='{2}' AND PQV68='{3}' AND PQV69='{4}' AND PQV70='{5}' AND PQV76<'{6}')" ,numOfGoods ,cName ,lName ,len ,width ,height ,oddNum );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
                return string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PQV" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ 0 ] [ "PQV" ] . ToString ( ) );
            else
                return 0;
        }

        /// <summary>
        /// 获取规格
        /// </summary>
        /// <param name="num"></param>
        /// <param name="cz"></param>
        /// <param name="lj"></param>
        /// <returns></returns>
        public DataTable getSpe ( string num,string cz,string lj )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT GS08,GS10 FROM R_PQP WHERE GS01='{0}' AND GS02='{1}' AND GS07='{2}' AND GS70='R_341'" ,num ,cz ,lj );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            
        }


    }
}

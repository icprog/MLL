using StudentMgr;
using System . Collections;
using System . Data;
using System . Text;

namespace MulaolaoBll
{
    public class WriteReceivableToGeneralLedger
    {
        /// <summary>
        /// 195
        /// </summary>
        /// <param name="model"></param>
        /// <param name="oddNum"></param>
        /// <param name="SQLString"></param>
        public static void ByOneByChanPintZhiBao ( MulaolaoLibrary.ProductCostSummaryLibrary model ,string oddNum ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "SELECT AMB108,AMB110,AMB111,AMB115 FROM R_PQAMB WHERE AMB001='{0}'" ,oddNum );

            //DataTable de = SqlHelper.ExecuteDataTable( "SELECT AM108,AM110,AM111,AM115 FROM R_PQAM WHERE AM002='" + model.AM002 + "'" );
            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            if ( da != null && da.Rows.Count > 0 )
            {
                if ( model.AM108 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB108='{0}' WHERE AMB001='{1}'" ,model.AM108 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( model.AM110 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB110='{0}' WHERE AMB001='{1}'" ,model.AM110 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( model.AM111 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB111='{0}' WHERE AMB001='{1}'" ,model.AM111 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( model.AM115 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB115='{0}' WHERE AMB001='{1}'" ,model.AM115 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }

                //if ( de != null && de.Rows.Count > 0 )
                //{
                //    model.AM108 = model.AM108 - ( string.IsNullOrEmpty( da.Rows[0]["AMB108"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB108"].ToString( ) ) );
                //    model.AM110 = model.AM110 - ( string.IsNullOrEmpty( da.Rows[0]["AMB110"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB110"].ToString( ) ) );
                //    model.AM111 = model.AM111 - ( string.IsNullOrEmpty( da.Rows[0]["AMB111"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB111"].ToString( ) ) );
                //    model.AM115 = model.AM115 - ( string.IsNullOrEmpty( da.Rows[0]["AMB115"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB115"].ToString( ) ) );

                //    model.AM108 = model.AM108 + ( string.IsNullOrEmpty( de.Rows[0]["AM108"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM108"].ToString( ) ) );
                //    model.AM110 = model.AM110 + ( string.IsNullOrEmpty( de.Rows[0]["AM110"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM110"].ToString( ) ) );
                //    model.AM111 = model.AM111 + ( string.IsNullOrEmpty( de.Rows[0]["AM111"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM111"].ToString( ) ) );
                //    model.AM115 = model.AM115 + ( string.IsNullOrEmpty( de.Rows[0]["AM115"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM115"].ToString( ) ) );
                //}


            }
            else
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "INSERT INTO R_PQAMB (AMB001,AMB108,AMB110,AMB111,AMB115) VALUES ('{0}','{1}','{2}','{3}','{4}')" ,oddNum ,model.AM108 ,model.AM110 ,model.AM111 ,model.AM115 );
                SQLString.Add( strSql.ToString( ) );
                //if ( de != null && de.Rows.Count > 0 )
                //{
                //    model.AM108 = model.AM108 + ( string.IsNullOrEmpty( de.Rows[0]["AM108"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM108"].ToString( ) ) );
                //    model.AM110 = model.AM110 + ( string.IsNullOrEmpty( de.Rows[0]["AM110"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM110"].ToString( ) ) );
                //    model.AM111 = model.AM111 + ( string.IsNullOrEmpty( de.Rows[0]["AM111"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM111"].ToString( ) ) );
                //    model.AM115 = model.AM115 + ( string.IsNullOrEmpty( de.Rows[0]["AM115"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM115"].ToString( ) ) );
                //}
            }
        }

        /// <summary>
        /// 196
        /// </summary>
        /// <param name="modelAm"></param>
        /// <param name="oddNum"></param>
        /// <param name="SQLString"></param>
        public static void ByOneByGongXu ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "SELECT AMB108,AMB110,AMB111,AMB115,AMB070,AMB072,AMB074,AMB076,AMB078,AMB080,AMB082,AMB084,AMB086,AMB088,AMB090,AMB092 FROM R_PQAMB WHERE AMB001='{0}'" ,oddNum );

            //DataTable de = SqlHelper.ExecuteDataTable( "SELECT AM108,AM110,AM111,AM115,AM070,AM072,AM074,AM076,AM078,AM080,AM082,AM084,AM086,AM088,AM090,AM092 FROM R_PQAM WHERE AM002='" + modelAm.AM002 + "'" );
            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            if ( da != null && da.Rows.Count > 0 )
            {
                if ( modelAm.AM108 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB108='{0}' WHERE AMB001='{1}'" ,modelAm.AM108 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM110 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB110='{0}' WHERE AMB001='{1}'" ,modelAm.AM110 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM111 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB111='{0}' WHERE AMB001='{1}'" ,modelAm.AM111 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM115 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB115='{0}' WHERE AMB001='{1}'" ,modelAm.AM115 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM070 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB070='{0}' WHERE AMB001='{1}'" ,modelAm.AM070 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM072 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB072='{0}' WHERE AMB001='{1}'" ,modelAm.AM072 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM074 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB074='{0}' WHERE AMB001='{1}'" ,modelAm.AM074 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM076 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB076='{0}' WHERE AMB001='{1}'" ,modelAm.AM076 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM078 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB078='{0}' WHERE AMB001='{1}'" ,modelAm.AM078 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM080 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB080='{0}' WHERE AMB001='{1}'" ,modelAm.AM080 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM082 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB082='{0}' WHERE AMB001='{1}'" ,modelAm.AM082 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM084 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB084='{0}' WHERE AMB001='{1}'" ,modelAm.AM084 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM086 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB086='{0}' WHERE AMB001='{1}'" ,modelAm.AM086 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM088 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB088='{0}' WHERE AMB001='{1}'" ,modelAm.AM088 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM090 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB090='{0}' WHERE AMB001='{1}'" ,modelAm.AM090 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM092 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB092='{0}' WHERE AMB001='{1}'" ,modelAm.AM092 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }

                //if ( de != null && de.Rows.Count > 0 )
                //{
                //    modelAm.AM108 = modelAm.AM108 - ( string.IsNullOrEmpty( da.Rows[0]["AMB108"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB108"].ToString( ) ) );
                //    modelAm.AM110 = modelAm.AM110 - ( string.IsNullOrEmpty( da.Rows[0]["AMB110"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB110"].ToString( ) ) );
                //    modelAm.AM111 = modelAm.AM111 - ( string.IsNullOrEmpty( da.Rows[0]["AMB111"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB111"].ToString( ) ) );
                //    modelAm.AM115 = modelAm.AM115 - ( string.IsNullOrEmpty( da.Rows[0]["AMB115"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB115"].ToString( ) ) );
                //    modelAm.AM070 = modelAm.AM070 - ( string.IsNullOrEmpty( da.Rows[0]["AMB070"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB070"].ToString( ) ) );
                //    modelAm.AM072 = modelAm.AM072 - ( string.IsNullOrEmpty( da.Rows[0]["AMB072"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB072"].ToString( ) ) );
                //    modelAm.AM074 = modelAm.AM074 - ( string.IsNullOrEmpty( da.Rows[0]["AMB074"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB074"].ToString( ) ) );
                //    modelAm.AM076 = modelAm.AM076 - ( string.IsNullOrEmpty( da.Rows[0]["AMB076"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB076"].ToString( ) ) );
                //    modelAm.AM078 = modelAm.AM078 - ( string.IsNullOrEmpty( da.Rows[0]["AMB078"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB078"].ToString( ) ) );
                //    modelAm.AM080 = modelAm.AM080 - ( string.IsNullOrEmpty( da.Rows[0]["AMB080"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB080"].ToString( ) ) );
                //    modelAm.AM082 = modelAm.AM082 - ( string.IsNullOrEmpty( da.Rows[0]["AMB082"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB082"].ToString( ) ) );
                //    modelAm.AM084 = modelAm.AM084 - ( string.IsNullOrEmpty( da.Rows[0]["AMB084"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB084"].ToString( ) ) );
                //    modelAm.AM086 = modelAm.AM086 - ( string.IsNullOrEmpty( da.Rows[0]["AMB086"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB086"].ToString( ) ) );
                //    modelAm.AM088 = modelAm.AM088 - ( string.IsNullOrEmpty( da.Rows[0]["AMB088"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB088"].ToString( ) ) );
                //    modelAm.AM090 = modelAm.AM090 - ( string.IsNullOrEmpty( da.Rows[0]["AMB090"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB090"].ToString( ) ) );
                //    modelAm.AM092 = modelAm.AM092 - ( string.IsNullOrEmpty( da.Rows[0]["AMB092"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB092"].ToString( ) ) );

                //    modelAm.AM108 = modelAm.AM108 + ( string.IsNullOrEmpty( de.Rows[0]["AM108"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM108"].ToString( ) ) );
                //    modelAm.AM110 = modelAm.AM110 + ( string.IsNullOrEmpty( de.Rows[0]["AM110"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM110"].ToString( ) ) );
                //    modelAm.AM111 = modelAm.AM111 + ( string.IsNullOrEmpty( de.Rows[0]["AM111"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM111"].ToString( ) ) );
                //    modelAm.AM115 = modelAm.AM115 + ( string.IsNullOrEmpty( de.Rows[0]["AM115"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM115"].ToString( ) ) );
                //    modelAm.AM070 = modelAm.AM070 + ( string.IsNullOrEmpty( de.Rows[0]["AM070"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM070"].ToString( ) ) );
                //    modelAm.AM072 = modelAm.AM072 + ( string.IsNullOrEmpty( de.Rows[0]["AM072"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM072"].ToString( ) ) );
                //    modelAm.AM074 = modelAm.AM074 + ( string.IsNullOrEmpty( de.Rows[0]["AM074"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM074"].ToString( ) ) );
                //    modelAm.AM076 = modelAm.AM076 + ( string.IsNullOrEmpty( de.Rows[0]["AM076"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM076"].ToString( ) ) );
                //    modelAm.AM078 = modelAm.AM078 + ( string.IsNullOrEmpty( de.Rows[0]["AM078"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM078"].ToString( ) ) );
                //    modelAm.AM080 = modelAm.AM080 + ( string.IsNullOrEmpty( de.Rows[0]["AM080"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM080"].ToString( ) ) );
                //    modelAm.AM082 = modelAm.AM082 + ( string.IsNullOrEmpty( de.Rows[0]["AM082"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM082"].ToString( ) ) );
                //    modelAm.AM084 = modelAm.AM084 + ( string.IsNullOrEmpty( de.Rows[0]["AM084"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM084"].ToString( ) ) );
                //    modelAm.AM086 = modelAm.AM086 + ( string.IsNullOrEmpty( de.Rows[0]["AM086"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM086"].ToString( ) ) );
                //    modelAm.AM088 = modelAm.AM088 + ( string.IsNullOrEmpty( de.Rows[0]["AM088"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM088"].ToString( ) ) );
                //    modelAm.AM090 = modelAm.AM090 + ( string.IsNullOrEmpty( de.Rows[0]["AM090"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM090"].ToString( ) ) );
                //    modelAm.AM092 = modelAm.AM092 + ( string.IsNullOrEmpty( de.Rows[0]["AM092"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM092"].ToString( ) ) );
                //}


            }
            else
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "INSERT INTO R_PQAMB (AMB001,AMB108,AMB110,AMB111,AMB115,AMB070,AMB072,AMB074,AMB076,AMB078,AMB080,AMB082,AMB084,AMB086,AMB088,AMB090,AMB092) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}')" ,oddNum ,modelAm.AM108 ,modelAm.AM110 ,modelAm.AM111 ,modelAm.AM115 ,modelAm.AM070 ,modelAm.AM072 ,modelAm.AM074 ,modelAm.AM076 ,modelAm.AM078 ,modelAm.AM080 ,modelAm.AM082 ,modelAm.AM084 ,modelAm.AM086 ,modelAm.AM088 ,modelAm.AM090 ,modelAm.AM092 );
                SQLString.Add( strSql.ToString( ) );
                //if ( de != null && de.Rows.Count > 0 )
                //{
                //    modelAm.AM108 = modelAm.AM108 + ( string.IsNullOrEmpty( de.Rows[0]["AM108"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM108"].ToString( ) ) );
                //    modelAm.AM110 = modelAm.AM110 + ( string.IsNullOrEmpty( de.Rows[0]["AM110"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM110"].ToString( ) ) );
                //    modelAm.AM111 = modelAm.AM111 + ( string.IsNullOrEmpty( de.Rows[0]["AM111"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM111"].ToString( ) ) );
                //    modelAm.AM115 = modelAm.AM115 + ( string.IsNullOrEmpty( de.Rows[0]["AM115"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM115"].ToString( ) ) );
                //    modelAm.AM070 = modelAm.AM070 + ( string.IsNullOrEmpty( de.Rows[0]["AM070"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM070"].ToString( ) ) );
                //    modelAm.AM072 = modelAm.AM072 + ( string.IsNullOrEmpty( de.Rows[0]["AM072"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM072"].ToString( ) ) );
                //    modelAm.AM074 = modelAm.AM074 + ( string.IsNullOrEmpty( de.Rows[0]["AM074"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM074"].ToString( ) ) );
                //    modelAm.AM076 = modelAm.AM076 + ( string.IsNullOrEmpty( de.Rows[0]["AM076"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM076"].ToString( ) ) );
                //    modelAm.AM078 = modelAm.AM078 + ( string.IsNullOrEmpty( de.Rows[0]["AM078"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM078"].ToString( ) ) );
                //    modelAm.AM080 = modelAm.AM080 + ( string.IsNullOrEmpty( de.Rows[0]["AM080"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM080"].ToString( ) ) );
                //    modelAm.AM082 = modelAm.AM082 + ( string.IsNullOrEmpty( de.Rows[0]["AM082"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM082"].ToString( ) ) );
                //    modelAm.AM084 = modelAm.AM084 + ( string.IsNullOrEmpty( de.Rows[0]["AM084"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM084"].ToString( ) ) );
                //    modelAm.AM086 = modelAm.AM086 + ( string.IsNullOrEmpty( de.Rows[0]["AM086"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM086"].ToString( ) ) );
                //    modelAm.AM088 = modelAm.AM088 + ( string.IsNullOrEmpty( de.Rows[0]["AM088"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM088"].ToString( ) ) );
                //    modelAm.AM090 = modelAm.AM090 + ( string.IsNullOrEmpty( de.Rows[0]["AM090"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM090"].ToString( ) ) );
                //    modelAm.AM092 = modelAm.AM092 + ( string.IsNullOrEmpty( de.Rows[0]["AM092"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM092"].ToString( ) ) );
                //}

            }
        }

        /// <summary>
        /// 338
        /// </summary>
        /// <param name="modelAm"></param>
        /// <param name="oddNum"></param>
        /// <param name="SQLString"></param>
        public static void ByOneByJiao ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "SELECT AMB296,AMB298,AMB300,AMB301,AMB304,AMB306,AMB307,AMB311,AMB313,AMB315,AMB318,AMB320,AMB321,AMB324,AMB326,AMB328 FROM R_PQAMB WHERE AMB001='{0}'" ,oddNum );

            //DataTable de = SqlHelper.ExecuteDataTable( "SELECT AM296,AM298,AM300,AM301,AM304,AM306,AM307,AM311,AM313,AM315,AM318,AM320,AM321,AM324,AM326,AM328 FROM R_PQAM WHERE AM002='" + modelAm.AM002 + "'" );
            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            if ( da != null && da.Rows.Count > 0 )
            {
                if ( modelAm.AM296 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB296='{0}' WHERE AMB001='{1}'" ,modelAm.AM296 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM298 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB298='{0}' WHERE AMB001='{1}'" ,modelAm.AM298 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM300 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB300='{0}' WHERE AMB001='{1}'" ,modelAm.AM300 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM301 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB301='{0}' WHERE AMB001='{1}'" ,modelAm.AM301 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM304 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB304='{0}' WHERE AMB001='{1}'" ,modelAm.AM304 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM306 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB306='{0}' WHERE AMB001='{1}'" ,modelAm.AM306 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM307 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB307='{0}' WHERE AMB001='{1}'" ,modelAm.AM307 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM311 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB311='{0}' WHERE AMB001='{1}'" ,modelAm.AM311 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM313 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB313='{0}' WHERE AMB001='{1}'" ,modelAm.AM313 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM315 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB315='{0}' WHERE AMB001='{1}'" ,modelAm.AM315 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM318 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB318='{0}' WHERE AMB001='{1}'" ,modelAm.AM318 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM320 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB320='{0}' WHERE AMB001='{1}'" ,modelAm.AM320 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM321 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB321='{0}' WHERE AMB001='{1}'" ,modelAm.AM321 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM324 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB324='{0}' WHERE AMB001='{1}'" ,modelAm.AM324 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM326 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB326='{0}' WHERE AMB001='{1}'" ,modelAm.AM326 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM328 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB328='{0}' WHERE AMB001='{1}'" ,modelAm.AM328 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }

                //if ( de != null && de.Rows.Count > 0 )
                //{
                //    modelAm.AM296 = modelAm.AM296 - ( string.IsNullOrEmpty( da.Rows[0]["AMB296"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB296"].ToString( ) ) );
                //    modelAm.AM298 = modelAm.AM298 - ( string.IsNullOrEmpty( da.Rows[0]["AMB298"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB298"].ToString( ) ) );
                //    modelAm.AM300 = modelAm.AM300 - ( string.IsNullOrEmpty( da.Rows[0]["AMB300"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB300"].ToString( ) ) );
                //    modelAm.AM301 = modelAm.AM301 - ( string.IsNullOrEmpty( da.Rows[0]["AMB301"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB301"].ToString( ) ) );
                //    modelAm.AM304 = modelAm.AM304 - ( string.IsNullOrEmpty( da.Rows[0]["AMB304"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB304"].ToString( ) ) );
                //    modelAm.AM306 = modelAm.AM306 - ( string.IsNullOrEmpty( da.Rows[0]["AMB306"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB306"].ToString( ) ) );
                //    modelAm.AM307 = modelAm.AM307 - ( string.IsNullOrEmpty( da.Rows[0]["AMB307"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB307"].ToString( ) ) );
                //    modelAm.AM311 = modelAm.AM311 - ( string.IsNullOrEmpty( da.Rows[0]["AMB311"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB311"].ToString( ) ) );
                //    modelAm.AM313 = modelAm.AM313 - ( string.IsNullOrEmpty( da.Rows[0]["AMB313"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB313"].ToString( ) ) );
                //    modelAm.AM315 = modelAm.AM315 - ( string.IsNullOrEmpty( da.Rows[0]["AMB315"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB315"].ToString( ) ) );
                //    modelAm.AM318 = modelAm.AM318 - ( string.IsNullOrEmpty( da.Rows[0]["AMB318"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB318"].ToString( ) ) );
                //    modelAm.AM320 = modelAm.AM320 - ( string.IsNullOrEmpty( da.Rows[0]["AMB320"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB320"].ToString( ) ) );
                //    modelAm.AM321 = modelAm.AM321 - ( string.IsNullOrEmpty( da.Rows[0]["AMB321"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB321"].ToString( ) ) );
                //    modelAm.AM324 = modelAm.AM324 - ( string.IsNullOrEmpty( da.Rows[0]["AMB324"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB324"].ToString( ) ) );
                //    modelAm.AM326 = modelAm.AM326 - ( string.IsNullOrEmpty( da.Rows[0]["AMB326"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB326"].ToString( ) ) );
                //    modelAm.AM328 = modelAm.AM328 - ( string.IsNullOrEmpty( da.Rows[0]["AMB328"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB328"].ToString( ) ) );

                //    modelAm.AM296 = modelAm.AM296 + ( string.IsNullOrEmpty( de.Rows[0]["AM296"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM296"].ToString( ) ) );
                //    modelAm.AM298 = modelAm.AM298 + ( string.IsNullOrEmpty( de.Rows[0]["AM298"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM298"].ToString( ) ) );
                //    modelAm.AM300 = modelAm.AM300 + ( string.IsNullOrEmpty( de.Rows[0]["AM300"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM300"].ToString( ) ) );
                //    modelAm.AM301 = modelAm.AM301 + ( string.IsNullOrEmpty( de.Rows[0]["AM301"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM301"].ToString( ) ) );
                //    modelAm.AM304 = modelAm.AM304 + ( string.IsNullOrEmpty( de.Rows[0]["AM304"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM304"].ToString( ) ) );
                //    modelAm.AM306 = modelAm.AM306 + ( string.IsNullOrEmpty( de.Rows[0]["AM306"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM306"].ToString( ) ) );
                //    modelAm.AM307 = modelAm.AM307 + ( string.IsNullOrEmpty( de.Rows[0]["AM307"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM307"].ToString( ) ) );
                //    modelAm.AM311 = modelAm.AM311 + ( string.IsNullOrEmpty( de.Rows[0]["AM311"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM311"].ToString( ) ) );
                //    modelAm.AM313 = modelAm.AM313 + ( string.IsNullOrEmpty( de.Rows[0]["AM313"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM313"].ToString( ) ) );
                //    modelAm.AM315 = modelAm.AM315 + ( string.IsNullOrEmpty( de.Rows[0]["AM315"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM315"].ToString( ) ) );
                //    modelAm.AM318 = modelAm.AM318 + ( string.IsNullOrEmpty( de.Rows[0]["AM318"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM318"].ToString( ) ) );
                //    modelAm.AM320 = modelAm.AM320 + ( string.IsNullOrEmpty( de.Rows[0]["AM320"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM320"].ToString( ) ) );
                //    modelAm.AM321 = modelAm.AM321 + ( string.IsNullOrEmpty( de.Rows[0]["AM321"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM321"].ToString( ) ) );
                //    modelAm.AM324 = modelAm.AM324 + ( string.IsNullOrEmpty( de.Rows[0]["AM324"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM324"].ToString( ) ) );
                //    modelAm.AM326 = modelAm.AM326 + ( string.IsNullOrEmpty( de.Rows[0]["AM326"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM326"].ToString( ) ) );
                //    modelAm.AM328 = modelAm.AM328 + ( string.IsNullOrEmpty( de.Rows[0]["AM328"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM328"].ToString( ) ) );
                //}

            }
            else
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "INSERT INTO R_PQAMB (AMB001,AMB296,AMB298,AMB300,AMB301,AMB304,AMB306,AMB307,AMB311,AMB313,AMB315,AMB318,AMB320,AMB321,AMB324,AMB326,AMB328) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}')" ,oddNum ,modelAm.AM296 ,modelAm.AM298 ,modelAm.AM300 ,modelAm.AM301 ,modelAm.AM304 ,modelAm.AM306 ,modelAm.AM307 ,modelAm.AM311 ,modelAm.AM313 ,modelAm.AM315 ,modelAm.AM318 ,modelAm.AM320 ,modelAm.AM321 ,modelAm.AM324 ,modelAm.AM326 ,modelAm.AM328 );
                SQLString.Add( strSql.ToString( ) );
                //if ( de != null && de.Rows.Count > 0 )
                //{
                //    modelAm.AM296 = modelAm.AM296 + ( string.IsNullOrEmpty( de.Rows[0]["AM296"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM296"].ToString( ) ) );
                //    modelAm.AM298 = modelAm.AM298 + ( string.IsNullOrEmpty( de.Rows[0]["AM298"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM298"].ToString( ) ) );
                //    modelAm.AM300 = modelAm.AM300 + ( string.IsNullOrEmpty( de.Rows[0]["AM300"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM300"].ToString( ) ) );
                //    modelAm.AM301 = modelAm.AM301 + ( string.IsNullOrEmpty( de.Rows[0]["AM301"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM301"].ToString( ) ) );
                //    modelAm.AM304 = modelAm.AM304 + ( string.IsNullOrEmpty( de.Rows[0]["AM304"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM304"].ToString( ) ) );
                //    modelAm.AM306 = modelAm.AM306 + ( string.IsNullOrEmpty( de.Rows[0]["AM306"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM306"].ToString( ) ) );
                //    modelAm.AM307 = modelAm.AM307 + ( string.IsNullOrEmpty( de.Rows[0]["AM307"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM307"].ToString( ) ) );
                //    modelAm.AM311 = modelAm.AM311 + ( string.IsNullOrEmpty( de.Rows[0]["AM311"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM311"].ToString( ) ) );
                //    modelAm.AM313 = modelAm.AM313 + ( string.IsNullOrEmpty( de.Rows[0]["AM313"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM313"].ToString( ) ) );
                //    modelAm.AM315 = modelAm.AM315 + ( string.IsNullOrEmpty( de.Rows[0]["AM315"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM315"].ToString( ) ) );
                //    modelAm.AM318 = modelAm.AM318 + ( string.IsNullOrEmpty( de.Rows[0]["AM318"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM318"].ToString( ) ) );
                //    modelAm.AM320 = modelAm.AM320 + ( string.IsNullOrEmpty( de.Rows[0]["AM320"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM320"].ToString( ) ) );
                //    modelAm.AM321 = modelAm.AM321 + ( string.IsNullOrEmpty( de.Rows[0]["AM321"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM321"].ToString( ) ) );
                //    modelAm.AM324 = modelAm.AM324 + ( string.IsNullOrEmpty( de.Rows[0]["AM324"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM324"].ToString( ) ) );
                //    modelAm.AM326 = modelAm.AM326 + ( string.IsNullOrEmpty( de.Rows[0]["AM326"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM326"].ToString( ) ) );
                //    modelAm.AM328 = modelAm.AM328 + ( string.IsNullOrEmpty( de.Rows[0]["AM328"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM328"].ToString( ) ) );
                //}

            }
        }

        /// <summary>
        /// 339
        /// </summary>
        /// <param name="modelAm"></param>
        /// <param name="oddNum"></param>
        /// <param name="SQLString"></param>
        public static void ByOneByYouQi ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "SELECT AMB175,AMB177,AMB178,AMB182,AMB184,AMB185,AMB188,AMB190,AMB191,AMB194,AMB196,AMB197,AMB200,AMB203,AMB205,AMB207 FROM R_PQAMB WHERE AMB001='{0}'" ,oddNum );

            //DataTable de = SqlHelper.ExecuteDataTable( "SELECT AM175,AM177,AM178,AM182,AM184,AM185,AM188,AM190,AM191,AM194,AM196,AM197,AM200,AM203,AM205,AM207 FROM R_PQAM WHERE AM002='" + modelAm.AM002 + "'" );
            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            if ( da != null && da.Rows.Count > 0 )
            {
                if ( modelAm.AM175 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB175='{0}' WHERE AMB001='{1}'" ,modelAm.AM175 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM177 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB177='{0}' WHERE AMB001='{1}'" ,modelAm.AM177 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM178 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB178='{0}' WHERE AMB001='{1}'" ,modelAm.AM178 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM182 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB182='{0}' WHERE AMB001='{1}'" ,modelAm.AM182 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM184 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB184='{0}' WHERE AMB001='{1}'" ,modelAm.AM184 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM185 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB185='{0}' WHERE AMB001='{1}'" ,modelAm.AM185 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM188 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB188='{0}' WHERE AMB001='{1}'" ,modelAm.AM188 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM190 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB190='{0}' WHERE AMB001='{1}'" ,modelAm.AM190 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM191 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB191='{0}' WHERE AMB001='{1}'" ,modelAm.AM191 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM194 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB194='{0}' WHERE AMB001='{1}'" ,modelAm.AM194 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM196 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB196='{0}' WHERE AMB001='{1}'" ,modelAm.AM196 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM197 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB197='{0}' WHERE AMB001='{1}'" ,modelAm.AM197 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM200 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB200='{0}' WHERE AMB001='{1}'" ,modelAm.AM200 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM203 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB203='{0}' WHERE AMB001='{1}'" ,modelAm.AM203 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM205 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB205='{0}' WHERE AMB001='{1}'" ,modelAm.AM205 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM207 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB207='{0}' WHERE AMB001='{1}'" ,modelAm.AM207 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }


                //if ( de != null && de.Rows.Count > 0 )
                //{
                //    modelAm.AM175 = modelAm.AM175 - ( string.IsNullOrEmpty( da.Rows[0]["AMB175"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB175"].ToString( ) ) );
                //    modelAm.AM177 = modelAm.AM177 - ( string.IsNullOrEmpty( da.Rows[0]["AMB177"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB177"].ToString( ) ) );
                //    modelAm.AM178 = modelAm.AM178 - ( string.IsNullOrEmpty( da.Rows[0]["AMB178"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB178"].ToString( ) ) );
                //    modelAm.AM182 = modelAm.AM182 - ( string.IsNullOrEmpty( da.Rows[0]["AMB182"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB182"].ToString( ) ) );
                //    modelAm.AM184 = modelAm.AM184 - ( string.IsNullOrEmpty( da.Rows[0]["AMB184"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB184"].ToString( ) ) );
                //    modelAm.AM185 = modelAm.AM185 - ( string.IsNullOrEmpty( da.Rows[0]["AMB185"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB185"].ToString( ) ) );
                //    modelAm.AM188 = modelAm.AM188 - ( string.IsNullOrEmpty( da.Rows[0]["AMB188"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB188"].ToString( ) ) );
                //    modelAm.AM190 = modelAm.AM190 - ( string.IsNullOrEmpty( da.Rows[0]["AMB190"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB190"].ToString( ) ) );
                //    modelAm.AM191 = modelAm.AM191 - ( string.IsNullOrEmpty( da.Rows[0]["AMB191"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB191"].ToString( ) ) );
                //    modelAm.AM194 = modelAm.AM194 - ( string.IsNullOrEmpty( da.Rows[0]["AMB194"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB194"].ToString( ) ) );
                //    modelAm.AM196 = modelAm.AM196 - ( string.IsNullOrEmpty( da.Rows[0]["AMB196"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB196"].ToString( ) ) );
                //    modelAm.AM197 = modelAm.AM197 - ( string.IsNullOrEmpty( da.Rows[0]["AMB197"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB197"].ToString( ) ) );
                //    modelAm.AM200 = modelAm.AM200 - ( string.IsNullOrEmpty( da.Rows[0]["AMB200"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB200"].ToString( ) ) );
                //    modelAm.AM203 = modelAm.AM203 - ( string.IsNullOrEmpty( da.Rows[0]["AMB203"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB203"].ToString( ) ) );
                //    modelAm.AM205 = modelAm.AM205 - ( string.IsNullOrEmpty( da.Rows[0]["AMB205"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB205"].ToString( ) ) );
                //    modelAm.AM207 = modelAm.AM207 - ( string.IsNullOrEmpty( da.Rows[0]["AMB207"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB207"].ToString( ) ) );

                //    modelAm.AM175 = modelAm.AM175 + ( string.IsNullOrEmpty( de.Rows[0]["AM175"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM175"].ToString( ) ) );
                //    modelAm.AM177 = modelAm.AM177 + ( string.IsNullOrEmpty( de.Rows[0]["AM177"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM177"].ToString( ) ) );
                //    modelAm.AM178 = modelAm.AM178 + ( string.IsNullOrEmpty( de.Rows[0]["AM178"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM178"].ToString( ) ) );
                //    modelAm.AM182 = modelAm.AM182 + ( string.IsNullOrEmpty( de.Rows[0]["AM182"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM182"].ToString( ) ) );
                //    modelAm.AM184 = modelAm.AM184 + ( string.IsNullOrEmpty( de.Rows[0]["AM184"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM184"].ToString( ) ) );
                //    modelAm.AM185 = modelAm.AM185 + ( string.IsNullOrEmpty( de.Rows[0]["AM185"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM185"].ToString( ) ) );
                //    modelAm.AM188 = modelAm.AM188 + ( string.IsNullOrEmpty( de.Rows[0]["AM188"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM188"].ToString( ) ) );
                //    modelAm.AM190 = modelAm.AM190 + ( string.IsNullOrEmpty( de.Rows[0]["AM190"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM190"].ToString( ) ) );
                //    modelAm.AM191 = modelAm.AM191 + ( string.IsNullOrEmpty( de.Rows[0]["AM191"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM191"].ToString( ) ) );
                //    modelAm.AM194 = modelAm.AM194 + ( string.IsNullOrEmpty( de.Rows[0]["AM194"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM194"].ToString( ) ) );
                //    modelAm.AM196 = modelAm.AM196 + ( string.IsNullOrEmpty( de.Rows[0]["AM196"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM196"].ToString( ) ) );
                //    modelAm.AM197 = modelAm.AM197 + ( string.IsNullOrEmpty( de.Rows[0]["AM197"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM197"].ToString( ) ) );
                //    modelAm.AM200 = modelAm.AM200 + ( string.IsNullOrEmpty( de.Rows[0]["AM200"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM200"].ToString( ) ) );
                //    modelAm.AM203 = modelAm.AM203 + ( string.IsNullOrEmpty( de.Rows[0]["AM203"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM203"].ToString( ) ) );
                //    modelAm.AM205 = modelAm.AM205 + ( string.IsNullOrEmpty( de.Rows[0]["AM205"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM205"].ToString( ) ) );
                //    modelAm.AM207 = modelAm.AM207 + ( string.IsNullOrEmpty( de.Rows[0]["AM207"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM207"].ToString( ) ) );
                //}

            }
            else
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "INSERT INTO R_PQAMB (AMB001,AMB175,AMB177,AMB178,AMB182,AMB184,AMB185,AMB188,AMB190,AMB191,AMB194,AMB196,AMB197,AMB200,AMB203,AMB205,AMB207) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}')" ,oddNum ,modelAm.AM175 ,modelAm.AM177 ,modelAm.AM178 ,modelAm.AM182 ,modelAm.AM184 ,modelAm.AM185 ,modelAm.AM188 ,modelAm.AM190 ,modelAm.AM191 ,modelAm.AM194 ,modelAm.AM196 ,modelAm.AM197 ,modelAm.AM200 ,modelAm.AM203 ,modelAm.AM205 ,modelAm.AM207 );
                SQLString.Add( strSql.ToString( ) );
                //if ( de != null && de.Rows.Count > 0 )
                //{
                //    modelAm.AM175 = modelAm.AM175 + ( string.IsNullOrEmpty( de.Rows[0]["AM175"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM175"].ToString( ) ) );
                //    modelAm.AM177 = modelAm.AM177 + ( string.IsNullOrEmpty( de.Rows[0]["AM177"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM177"].ToString( ) ) );
                //    modelAm.AM178 = modelAm.AM178 + ( string.IsNullOrEmpty( de.Rows[0]["AM178"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM178"].ToString( ) ) );
                //    modelAm.AM182 = modelAm.AM182 + ( string.IsNullOrEmpty( de.Rows[0]["AM182"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM182"].ToString( ) ) );
                //    modelAm.AM184 = modelAm.AM184 + ( string.IsNullOrEmpty( de.Rows[0]["AM184"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM184"].ToString( ) ) );
                //    modelAm.AM185 = modelAm.AM185 + ( string.IsNullOrEmpty( de.Rows[0]["AM185"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM185"].ToString( ) ) );
                //    modelAm.AM188 = modelAm.AM188 + ( string.IsNullOrEmpty( de.Rows[0]["AM188"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM188"].ToString( ) ) );
                //    modelAm.AM190 = modelAm.AM190 + ( string.IsNullOrEmpty( de.Rows[0]["AM190"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM190"].ToString( ) ) );
                //    modelAm.AM191 = modelAm.AM191 + ( string.IsNullOrEmpty( de.Rows[0]["AM191"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM191"].ToString( ) ) );
                //    modelAm.AM194 = modelAm.AM194 + ( string.IsNullOrEmpty( de.Rows[0]["AM194"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM194"].ToString( ) ) );
                //    modelAm.AM196 = modelAm.AM196 + ( string.IsNullOrEmpty( de.Rows[0]["AM196"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM196"].ToString( ) ) );
                //    modelAm.AM197 = modelAm.AM197 + ( string.IsNullOrEmpty( de.Rows[0]["AM197"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM197"].ToString( ) ) );
                //    modelAm.AM200 = modelAm.AM200 + ( string.IsNullOrEmpty( de.Rows[0]["AM200"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM200"].ToString( ) ) );
                //    modelAm.AM203 = modelAm.AM203 + ( string.IsNullOrEmpty( de.Rows[0]["AM203"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM203"].ToString( ) ) );
                //    modelAm.AM205 = modelAm.AM205 + ( string.IsNullOrEmpty( de.Rows[0]["AM205"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM205"].ToString( ) ) );
                //    modelAm.AM207 = modelAm.AM207 + ( string.IsNullOrEmpty( de.Rows[0]["AM207"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM207"].ToString( ) ) );
                //}

            }
        }
        
        /// <summary>
        /// 341
        /// </summary>
        /// <param name="modelAm"></param>
        /// <param name="oddNum"></param>
        /// <param name="SQLString"></param>
        public static void ByOneByMuCai ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum ,ArrayList SQLString )
        {
            //modelAm.AM261 = modelAm.AM263 = modelAm.AM265 = modelAm.AM267 = modelAm.AM287 = modelAm.AM288 = modelAm.AM290 = modelAm.AM292 = modelAm.AM294 = modelAm.AM330 = modelAm.AM332 = modelAm.AM333 = modelAm.AM336 = modelAm.AM338 = modelAm.AM343 = modelAm.AM345 = modelAm.AM346 = modelAm.AM349 = modelAm.AM351 = modelAm.AM352 = modelAm.AM355 = modelAm.AM357 = modelAm.AM358 = modelAm.AM361 = modelAm.AM363 = modelAm.AM364 = modelAm.AM367 = modelAm.AM369 = modelAm.AM370 = modelAm.AM373 = modelAm.AM375 = modelAm.AM376 = modelAm.AM379 = modelAm.AM381 = modelAm.AM382 = modelAm.AM385 = modelAm.AM388 = modelAm.AM390 = modelAm.AM391 = 0;
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "SELECT AMB261,AMB263,AMB265,AMB267,AMB287,AMB288,AMB290,AMB292,AMB294,AMB330,AMB332,AMB333,AMB336,AMB338,AMB343,AMB345,AMB346,AMB349,AMB351,AMB352,AMB355,AMB357,AMB358,AMB361,AMB363,AMB364,AMB367,AMB369,AMB370,AMB373,AMB375,AMB376,AMB379,AMB381,AMB382,AMB385,AMB388,AMB390,AMB391 FROM R_PQAMB WHERE AMB001='{0}'" ,oddNum );

            //DataTable de = SqlHelper.ExecuteDataTable( "SELECT AM261,AM263,AM265,AM267,AM287,AM288,AM290,AM292,AM294,AM330,AM332,AM333,AM336,AM338,AM343,AM345,AM346,AM349,AM351,AM352,AM355,AM357,AM358,AM361,AM363,AM364,AM367,AM369,AM370,AM373,AM375,AM376,AM379,AM381,AM382,AM385,AM388,AM390,AM391 FROM R_PQAM WHERE AM002='" + modelAm.AM002 + "'" );
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
                
                //if ( de != null && de.Rows.Count > 0 )
                //{
                //    modelAm.AM261 = modelAm.AM261 - ( string.IsNullOrEmpty( da.Rows[0]["AMB261"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB261"].ToString( ) ) );
                //    modelAm.AM263 = modelAm.AM263 - ( string.IsNullOrEmpty( da.Rows[0]["AMB263"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB263"].ToString( ) ) );
                //    modelAm.AM265 = modelAm.AM265 - ( string.IsNullOrEmpty( da.Rows[0]["AMB265"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB265"].ToString( ) ) );
                //    modelAm.AM267 = modelAm.AM267 - ( string.IsNullOrEmpty( da.Rows[0]["AMB267"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB267"].ToString( ) ) );
                //    modelAm.AM287 = modelAm.AM287 - ( string.IsNullOrEmpty( da.Rows[0]["AMB287"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB287"].ToString( ) ) );
                //    modelAm.AM288 = modelAm.AM288 - ( string.IsNullOrEmpty( da.Rows[0]["AMB288"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB288"].ToString( ) ) );
                //    modelAm.AM290 = modelAm.AM290 - ( string.IsNullOrEmpty( da.Rows[0]["AMB290"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB290"].ToString( ) ) );
                //    modelAm.AM292 = modelAm.AM292 - ( string.IsNullOrEmpty( da.Rows[0]["AMB292"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB292"].ToString( ) ) );
                //    modelAm.AM294 = modelAm.AM294 - ( string.IsNullOrEmpty( da.Rows[0]["AMB294"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB294"].ToString( ) ) );
                //    modelAm.AM330 = modelAm.AM330 - ( string.IsNullOrEmpty( da.Rows[0]["AMB330"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB330"].ToString( ) ) );
                //    modelAm.AM333 = modelAm.AM333 - ( string.IsNullOrEmpty( da.Rows[0]["AMB333"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB333"].ToString( ) ) );
                //    modelAm.AM336 = modelAm.AM336 - ( string.IsNullOrEmpty( da.Rows[0]["AMB336"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB336"].ToString( ) ) );
                //    modelAm.AM338 = modelAm.AM338 - ( string.IsNullOrEmpty( da.Rows[0]["AMB338"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB338"].ToString( ) ) );
                //    modelAm.AM343 = modelAm.AM343 - ( string.IsNullOrEmpty( da.Rows[0]["AMB343"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB343"].ToString( ) ) );
                //    modelAm.AM345 = modelAm.AM345 - ( string.IsNullOrEmpty( da.Rows[0]["AMB345"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB345"].ToString( ) ) );
                //    modelAm.AM346 = modelAm.AM346 - ( string.IsNullOrEmpty( da.Rows[0]["AMB346"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB346"].ToString( ) ) );
                //    modelAm.AM349 = modelAm.AM349 - ( string.IsNullOrEmpty( da.Rows[0]["AMB349"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB349"].ToString( ) ) );
                //    modelAm.AM351 = modelAm.AM351 - ( string.IsNullOrEmpty( da.Rows[0]["AMB351"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB351"].ToString( ) ) );
                //    modelAm.AM352 = modelAm.AM352 - ( string.IsNullOrEmpty( da.Rows[0]["AMB352"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB352"].ToString( ) ) );
                //    modelAm.AM355 = modelAm.AM355 - ( string.IsNullOrEmpty( da.Rows[0]["AMB355"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB355"].ToString( ) ) );
                //    modelAm.AM357 = modelAm.AM357 - ( string.IsNullOrEmpty( da.Rows[0]["AMB357"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB357"].ToString( ) ) );
                //    modelAm.AM358 = modelAm.AM358 - ( string.IsNullOrEmpty( da.Rows[0]["AMB358"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB358"].ToString( ) ) );
                //    modelAm.AM361 = modelAm.AM361 - ( string.IsNullOrEmpty( da.Rows[0]["AMB361"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB361"].ToString( ) ) );
                //    modelAm.AM363 = modelAm.AM363 - ( string.IsNullOrEmpty( da.Rows[0]["AMB363"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB363"].ToString( ) ) );
                //    modelAm.AM364 = modelAm.AM364 - ( string.IsNullOrEmpty( da.Rows[0]["AMB364"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB364"].ToString( ) ) );
                //    modelAm.AM367 = modelAm.AM367 - ( string.IsNullOrEmpty( da.Rows[0]["AMB367"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB367"].ToString( ) ) );
                //    modelAm.AM369 = modelAm.AM369 - ( string.IsNullOrEmpty( da.Rows[0]["AMB369"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB369"].ToString( ) ) );
                //    modelAm.AM370 = modelAm.AM370 - ( string.IsNullOrEmpty( da.Rows[0]["AMB370"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB370"].ToString( ) ) );
                //    modelAm.AM373 = modelAm.AM373 - ( string.IsNullOrEmpty( da.Rows[0]["AMB373"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB373"].ToString( ) ) );
                //    modelAm.AM375 = modelAm.AM375 - ( string.IsNullOrEmpty( da.Rows[0]["AMB375"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB375"].ToString( ) ) );
                //    modelAm.AM376 = modelAm.AM376 - ( string.IsNullOrEmpty( da.Rows[0]["AMB376"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB376"].ToString( ) ) );
                //    modelAm.AM379 = modelAm.AM379 - ( string.IsNullOrEmpty( da.Rows[0]["AMB379"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB379"].ToString( ) ) );
                //    modelAm.AM381 = modelAm.AM381 - ( string.IsNullOrEmpty( da.Rows[0]["AMB381"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB381"].ToString( ) ) );
                //    modelAm.AM382 = modelAm.AM382 - ( string.IsNullOrEmpty( da.Rows[0]["AMB382"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB382"].ToString( ) ) );
                //    modelAm.AM385 = modelAm.AM385 - ( string.IsNullOrEmpty( da.Rows[0]["AMB385"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB385"].ToString( ) ) );
                //    modelAm.AM388 = modelAm.AM388 - ( string.IsNullOrEmpty( da.Rows[0]["AMB388"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB388"].ToString( ) ) );
                //    modelAm.AM390 = modelAm.AM390 - ( string.IsNullOrEmpty( da.Rows[0]["AMB390"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB390"].ToString( ) ) );
                //    modelAm.AM391 = modelAm.AM391 - ( string.IsNullOrEmpty( da.Rows[0]["AMB391"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB391"].ToString( ) ) );

                //    modelAm.AM261 = modelAm.AM261 + ( string.IsNullOrEmpty( de.Rows[0]["AM261"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM261"].ToString( ) ) );
                //    modelAm.AM263 = modelAm.AM263 + ( string.IsNullOrEmpty( de.Rows[0]["AM263"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM263"].ToString( ) ) );
                //    modelAm.AM265 = modelAm.AM265 + ( string.IsNullOrEmpty( de.Rows[0]["AM265"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM265"].ToString( ) ) );
                //    modelAm.AM267 = modelAm.AM267 + ( string.IsNullOrEmpty( de.Rows[0]["AM267"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM267"].ToString( ) ) );
                //    modelAm.AM287 = modelAm.AM287 + ( string.IsNullOrEmpty( de.Rows[0]["AM287"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM287"].ToString( ) ) );
                //    modelAm.AM288 = modelAm.AM288 + ( string.IsNullOrEmpty( de.Rows[0]["AM288"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM288"].ToString( ) ) );
                //    modelAm.AM290 = modelAm.AM290 + ( string.IsNullOrEmpty( de.Rows[0]["AM290"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM290"].ToString( ) ) );
                //    modelAm.AM292 = modelAm.AM292 + ( string.IsNullOrEmpty( de.Rows[0]["AM292"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM292"].ToString( ) ) );
                //    modelAm.AM294 = modelAm.AM294 + ( string.IsNullOrEmpty( de.Rows[0]["AM294"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM294"].ToString( ) ) );
                //    modelAm.AM330 = modelAm.AM330 + ( string.IsNullOrEmpty( de.Rows[0]["AM330"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM330"].ToString( ) ) );
                //    modelAm.AM333 = modelAm.AM333 + ( string.IsNullOrEmpty( de.Rows[0]["AM333"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM333"].ToString( ) ) );
                //    modelAm.AM336 = modelAm.AM336 + ( string.IsNullOrEmpty( de.Rows[0]["AM336"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM336"].ToString( ) ) );
                //    modelAm.AM338 = modelAm.AM338 + ( string.IsNullOrEmpty( de.Rows[0]["AM338"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM338"].ToString( ) ) );
                //    modelAm.AM343 = modelAm.AM343 + ( string.IsNullOrEmpty( de.Rows[0]["AM343"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM343"].ToString( ) ) );
                //    modelAm.AM345 = modelAm.AM345 + ( string.IsNullOrEmpty( de.Rows[0]["AM345"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM345"].ToString( ) ) );
                //    modelAm.AM346 = modelAm.AM346 + ( string.IsNullOrEmpty( de.Rows[0]["AM346"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM346"].ToString( ) ) );
                //    modelAm.AM349 = modelAm.AM349 + ( string.IsNullOrEmpty( de.Rows[0]["AM349"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM349"].ToString( ) ) );
                //    modelAm.AM351 = modelAm.AM351 + ( string.IsNullOrEmpty( de.Rows[0]["AM351"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM351"].ToString( ) ) );
                //    modelAm.AM352 = modelAm.AM352 + ( string.IsNullOrEmpty( de.Rows[0]["AM352"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM352"].ToString( ) ) );
                //    modelAm.AM355 = modelAm.AM355 + ( string.IsNullOrEmpty( de.Rows[0]["AM355"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM355"].ToString( ) ) );
                //    modelAm.AM357 = modelAm.AM357 + ( string.IsNullOrEmpty( de.Rows[0]["AM357"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM357"].ToString( ) ) );
                //    modelAm.AM358 = modelAm.AM358 + ( string.IsNullOrEmpty( de.Rows[0]["AM358"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM358"].ToString( ) ) );
                //    modelAm.AM361 = modelAm.AM361 + ( string.IsNullOrEmpty( de.Rows[0]["AM361"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM361"].ToString( ) ) );
                //    modelAm.AM363 = modelAm.AM363 + ( string.IsNullOrEmpty( de.Rows[0]["AM363"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM363"].ToString( ) ) );
                //    modelAm.AM364 = modelAm.AM364 + ( string.IsNullOrEmpty( de.Rows[0]["AM364"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM364"].ToString( ) ) );
                //    modelAm.AM367 = modelAm.AM367 + ( string.IsNullOrEmpty( de.Rows[0]["AM367"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM367"].ToString( ) ) );
                //    modelAm.AM369 = modelAm.AM369 + ( string.IsNullOrEmpty( de.Rows[0]["AM369"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM369"].ToString( ) ) );
                //    modelAm.AM370 = modelAm.AM370 + ( string.IsNullOrEmpty( de.Rows[0]["AM370"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM370"].ToString( ) ) );
                //    modelAm.AM373 = modelAm.AM373 + ( string.IsNullOrEmpty( de.Rows[0]["AM373"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM373"].ToString( ) ) );
                //    modelAm.AM375 = modelAm.AM375 + ( string.IsNullOrEmpty( de.Rows[0]["AM375"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM375"].ToString( ) ) );
                //    modelAm.AM376 = modelAm.AM376 + ( string.IsNullOrEmpty( de.Rows[0]["AM376"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM376"].ToString( ) ) );
                //    modelAm.AM379 = modelAm.AM379 + ( string.IsNullOrEmpty( de.Rows[0]["AM379"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM379"].ToString( ) ) );
                //    modelAm.AM381 = modelAm.AM381 + ( string.IsNullOrEmpty( de.Rows[0]["AM381"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM381"].ToString( ) ) );
                //    modelAm.AM382 = modelAm.AM382 + ( string.IsNullOrEmpty( de.Rows[0]["AM382"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM382"].ToString( ) ) );
                //    modelAm.AM385 = modelAm.AM385 + ( string.IsNullOrEmpty( de.Rows[0]["AM385"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM385"].ToString( ) ) );
                //    modelAm.AM388 = modelAm.AM388 + ( string.IsNullOrEmpty( de.Rows[0]["AM388"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM388"].ToString( ) ) );
                //    modelAm.AM390 = modelAm.AM390 + ( string.IsNullOrEmpty( de.Rows[0]["AM390"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM390"].ToString( ) ) );
                //    modelAm.AM391 = modelAm.AM391 + ( string.IsNullOrEmpty( de.Rows[0]["AM391"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM391"].ToString( ) ) );
                //}

            }
            else
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "INSERT INTO R_PQAMB  (AMB001,AMB261,AMB263,AMB265,AMB267,AMB287,AMB288,AMB290,AMB292,AMB294,AMB330,AMB332,AMB333,AMB336,AMB338,AMB343,AMB345,AMB346,AMB349,AMB351,AMB352,AMB355,AMB357,AMB358,AMB361,AMB363,AMB364,AMB367,AMB369,AMB370,AMB373,AMB375,AMB376,AMB379,AMB381,AMB382,AMB385,AMB388,AMB390,AMB391) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}','{38}','{39}')" ,oddNum ,modelAm.AM261 ,modelAm.AM263 ,modelAm.AM265 ,modelAm.AM267 ,modelAm.AM287 ,modelAm.AM288 ,modelAm.AM290 ,modelAm.AM292 ,modelAm.AM294 ,modelAm.AM330 ,modelAm.AM332 ,modelAm.AM333 ,modelAm.AM336 ,modelAm.AM338 ,modelAm.AM343 ,modelAm.AM345 ,modelAm.AM346 ,modelAm.AM349 ,modelAm.AM351 ,modelAm.AM352 ,modelAm.AM355 ,modelAm.AM357 ,modelAm.AM358 ,modelAm.AM361 ,modelAm.AM363 ,modelAm.AM364 ,modelAm.AM367 ,modelAm.AM369 ,modelAm.AM370 ,modelAm.AM373 ,modelAm.AM375 ,modelAm.AM376 ,modelAm.AM379 ,modelAm.AM381 ,modelAm.AM382 ,modelAm.AM385 ,modelAm.AM388 ,modelAm.AM390 ,modelAm.AM391 );
                SQLString.Add( strSql.ToString( ) );
                //if ( de != null && de.Rows.Count > 0 )
                //{
                //    modelAm.AM261 = modelAm.AM261 + ( string.IsNullOrEmpty( de.Rows[0]["AM261"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM261"].ToString( ) ) );
                //    modelAm.AM263 = modelAm.AM263 + ( string.IsNullOrEmpty( de.Rows[0]["AM263"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM263"].ToString( ) ) );
                //    modelAm.AM265 = modelAm.AM265 + ( string.IsNullOrEmpty( de.Rows[0]["AM265"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM265"].ToString( ) ) );
                //    modelAm.AM267 = modelAm.AM267 + ( string.IsNullOrEmpty( de.Rows[0]["AM267"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM267"].ToString( ) ) );
                //    modelAm.AM287 = modelAm.AM287 + ( string.IsNullOrEmpty( de.Rows[0]["AM287"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM287"].ToString( ) ) );
                //    modelAm.AM288 = modelAm.AM288 + ( string.IsNullOrEmpty( de.Rows[0]["AM288"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM288"].ToString( ) ) );
                //    modelAm.AM290 = modelAm.AM290 + ( string.IsNullOrEmpty( de.Rows[0]["AM290"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM290"].ToString( ) ) );
                //    modelAm.AM292 = modelAm.AM292 + ( string.IsNullOrEmpty( de.Rows[0]["AM292"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM292"].ToString( ) ) );
                //    modelAm.AM294 = modelAm.AM294 + ( string.IsNullOrEmpty( de.Rows[0]["AM294"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM294"].ToString( ) ) );
                //    modelAm.AM330 = modelAm.AM330 + ( string.IsNullOrEmpty( de.Rows[0]["AM330"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM330"].ToString( ) ) );
                //    modelAm.AM333 = modelAm.AM333 + ( string.IsNullOrEmpty( de.Rows[0]["AM333"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM333"].ToString( ) ) );
                //    modelAm.AM336 = modelAm.AM336 + ( string.IsNullOrEmpty( de.Rows[0]["AM336"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM336"].ToString( ) ) );
                //    modelAm.AM338 = modelAm.AM338 + ( string.IsNullOrEmpty( de.Rows[0]["AM338"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM338"].ToString( ) ) );
                //    modelAm.AM343 = modelAm.AM343 + ( string.IsNullOrEmpty( de.Rows[0]["AM343"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM343"].ToString( ) ) );
                //    modelAm.AM345 = modelAm.AM345 + ( string.IsNullOrEmpty( de.Rows[0]["AM345"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM345"].ToString( ) ) );
                //    modelAm.AM346 = modelAm.AM346 + ( string.IsNullOrEmpty( de.Rows[0]["AM346"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM346"].ToString( ) ) );
                //    modelAm.AM349 = modelAm.AM349 + ( string.IsNullOrEmpty( de.Rows[0]["AM349"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM349"].ToString( ) ) );
                //    modelAm.AM351 = modelAm.AM351 + ( string.IsNullOrEmpty( de.Rows[0]["AM351"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM351"].ToString( ) ) );
                //    modelAm.AM352 = modelAm.AM352 + ( string.IsNullOrEmpty( de.Rows[0]["AM352"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM352"].ToString( ) ) );
                //    modelAm.AM355 = modelAm.AM355 + ( string.IsNullOrEmpty( de.Rows[0]["AM355"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM355"].ToString( ) ) );
                //    modelAm.AM357 = modelAm.AM357 + ( string.IsNullOrEmpty( de.Rows[0]["AM357"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM357"].ToString( ) ) );
                //    modelAm.AM358 = modelAm.AM358 + ( string.IsNullOrEmpty( de.Rows[0]["AM358"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM358"].ToString( ) ) );
                //    modelAm.AM361 = modelAm.AM361 + ( string.IsNullOrEmpty( de.Rows[0]["AM361"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM361"].ToString( ) ) );
                //    modelAm.AM363 = modelAm.AM363 + ( string.IsNullOrEmpty( de.Rows[0]["AM363"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM363"].ToString( ) ) );
                //    modelAm.AM364 = modelAm.AM364 + ( string.IsNullOrEmpty( de.Rows[0]["AM364"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM364"].ToString( ) ) );
                //    modelAm.AM367 = modelAm.AM367 + ( string.IsNullOrEmpty( de.Rows[0]["AM367"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM367"].ToString( ) ) );
                //    modelAm.AM369 = modelAm.AM369 + ( string.IsNullOrEmpty( de.Rows[0]["AM369"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM369"].ToString( ) ) );
                //    modelAm.AM370 = modelAm.AM370 + ( string.IsNullOrEmpty( de.Rows[0]["AM370"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM370"].ToString( ) ) );
                //    modelAm.AM373 = modelAm.AM373 + ( string.IsNullOrEmpty( de.Rows[0]["AM373"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM373"].ToString( ) ) );
                //    modelAm.AM375 = modelAm.AM375 + ( string.IsNullOrEmpty( de.Rows[0]["AM375"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM375"].ToString( ) ) );
                //    modelAm.AM376 = modelAm.AM376 + ( string.IsNullOrEmpty( de.Rows[0]["AM376"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM376"].ToString( ) ) );
                //    modelAm.AM379 = modelAm.AM379 + ( string.IsNullOrEmpty( de.Rows[0]["AM379"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM379"].ToString( ) ) );
                //    modelAm.AM381 = modelAm.AM381 + ( string.IsNullOrEmpty( de.Rows[0]["AM381"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM381"].ToString( ) ) );
                //    modelAm.AM382 = modelAm.AM382 + ( string.IsNullOrEmpty( de.Rows[0]["AM382"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM382"].ToString( ) ) );
                //    modelAm.AM385 = modelAm.AM385 + ( string.IsNullOrEmpty( de.Rows[0]["AM385"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM385"].ToString( ) ) );
                //    modelAm.AM388 = modelAm.AM388 + ( string.IsNullOrEmpty( de.Rows[0]["AM388"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM388"].ToString( ) ) );
                //    modelAm.AM390 = modelAm.AM390 + ( string.IsNullOrEmpty( de.Rows[0]["AM390"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM390"].ToString( ) ) );
                //    modelAm.AM391 = modelAm.AM391 + ( string.IsNullOrEmpty( de.Rows[0]["AM391"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM391"].ToString( ) ) );
                //}


            }
        }

        /// <summary>
        /// 342
        /// </summary>
        /// <param name="modelAm"></param>
        /// <param name="oddNum"></param>
        /// <param name="SQLString"></param>
        public static void ByOneByChe ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum ,ArrayList SQLString )
        {
            //modelAm.AM270 = modelAm.AM273 = modelAm.AM277 = modelAm.AM280 = modelAm.AM272 = modelAm.AM279 = modelAm.AM283 = modelAm.AM285 = 0;
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "SELECT AMB270,AMB273,AMB277,AMB280,AMB272,AMB279,AMB283,AMB285 FROM R_PQAMB WHERE AMB001='{0}'" ,oddNum );

            //DataTable de = SqlHelper.ExecuteDataTable( "SELECT AM270,AM273,AM277,AM280,AM272,AM279,AM283,AM285 FROM R_PQAM WHERE AM002='" + modelAm.AM002 + "'" );
            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            if ( da != null && da.Rows.Count > 0 )
            {
                if ( modelAm.AM270 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB270='{0}' WHERE AMB001='{1}'" ,modelAm.AM270 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM272 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB272='{0}' WHERE AMB001='{1}'" ,modelAm.AM272 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM273 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB273='{0}' WHERE AMB001='{1}'" ,modelAm.AM273 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM277 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB277='{0}' WHERE AMB001='{1}'" ,modelAm.AM277 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM279 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB279='{0}' WHERE AMB001='{1}'" ,modelAm.AM279 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM280 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB280='{0}' WHERE AMB001='{1}'" ,modelAm.AM280 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM283 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB283='{0}' WHERE AMB001='{1}'" ,modelAm.AM283 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM285 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB285='{0}' WHERE AMB001='{1}'" ,modelAm.AM285 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
               
                //if ( de != null && de.Rows.Count > 0 )
                //{
                //    modelAm.AM270 = modelAm.AM270 - ( string.IsNullOrEmpty( da.Rows[0]["AMB270"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB270"].ToString( ) ) );
                //    modelAm.AM272 = modelAm.AM272 - ( string.IsNullOrEmpty( da.Rows[0]["AMB272"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB272"].ToString( ) ) );
                //    modelAm.AM273 = modelAm.AM273 - ( string.IsNullOrEmpty( da.Rows[0]["AMB273"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB273"].ToString( ) ) );
                //    modelAm.AM277 = modelAm.AM277 - ( string.IsNullOrEmpty( da.Rows[0]["AMB277"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB277"].ToString( ) ) );
                //    modelAm.AM279 = modelAm.AM279 - ( string.IsNullOrEmpty( da.Rows[0]["AMB279"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB279"].ToString( ) ) );
                //    modelAm.AM280 = modelAm.AM280 - ( string.IsNullOrEmpty( da.Rows[0]["AMB280"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB280"].ToString( ) ) );
                //    modelAm.AM283 = modelAm.AM283 - ( string.IsNullOrEmpty( da.Rows[0]["AMB283"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB283"].ToString( ) ) );
                //    modelAm.AM285 = modelAm.AM285 - ( string.IsNullOrEmpty( da.Rows[0]["AMB285"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB285"].ToString( ) ) );

                //    modelAm.AM270 = modelAm.AM270 + ( string.IsNullOrEmpty( de.Rows[0]["AM270"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM270"].ToString( ) ) );
                //    modelAm.AM272 = modelAm.AM272 + ( string.IsNullOrEmpty( de.Rows[0]["AM272"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM272"].ToString( ) ) );
                //    modelAm.AM273 = modelAm.AM273 + ( string.IsNullOrEmpty( de.Rows[0]["AM273"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM273"].ToString( ) ) );
                //    modelAm.AM277 = modelAm.AM277 + ( string.IsNullOrEmpty( de.Rows[0]["AM277"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM277"].ToString( ) ) );
                //    modelAm.AM279 = modelAm.AM279 + ( string.IsNullOrEmpty( de.Rows[0]["AM279"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM279"].ToString( ) ) );
                //    modelAm.AM280 = modelAm.AM280 + ( string.IsNullOrEmpty( de.Rows[0]["AM280"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM280"].ToString( ) ) );
                //    modelAm.AM283 = modelAm.AM283 + ( string.IsNullOrEmpty( de.Rows[0]["AM283"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM283"].ToString( ) ) );
                //    modelAm.AM285 = modelAm.AM285 + ( string.IsNullOrEmpty( de.Rows[0]["AM285"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM285"].ToString( ) ) );
                //}

            }
            else
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "INSERT INTO R_PQAMB (AMB001,AMB270,AMB273,AMB277,AMB280,AMB272,AMB279,AMB283,AMB285) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')" ,oddNum ,modelAm.AM270 ,modelAm.AM273 ,modelAm.AM277 ,modelAm.AM280 ,modelAm.AM272 ,modelAm.AM279 ,modelAm.AM283 ,modelAm.AM285 );
                SQLString.Add( strSql.ToString( ) );
                //if ( de != null && de.Rows.Count > 0 )
                //{
                //    modelAm.AM270 = modelAm.AM270 + ( string.IsNullOrEmpty( de.Rows[0]["AM270"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM270"].ToString( ) ) );
                //    modelAm.AM272 = modelAm.AM272 + ( string.IsNullOrEmpty( de.Rows[0]["AM272"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM272"].ToString( ) ) );
                //    modelAm.AM273 = modelAm.AM273 + ( string.IsNullOrEmpty( de.Rows[0]["AM273"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM273"].ToString( ) ) );
                //    modelAm.AM277 = modelAm.AM277 + ( string.IsNullOrEmpty( de.Rows[0]["AM277"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM277"].ToString( ) ) );
                //    modelAm.AM279 = modelAm.AM279 + ( string.IsNullOrEmpty( de.Rows[0]["AM279"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM279"].ToString( ) ) );
                //    modelAm.AM280 = modelAm.AM280 + ( string.IsNullOrEmpty( de.Rows[0]["AM280"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM280"].ToString( ) ) );
                //    modelAm.AM283 = modelAm.AM283 + ( string.IsNullOrEmpty( de.Rows[0]["AM283"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM283"].ToString( ) ) );
                //    modelAm.AM285 = modelAm.AM285 + ( string.IsNullOrEmpty( de.Rows[0]["AM285"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM285"].ToString( ) ) );
                //}

            }
        }

        /// <summary>
        /// 343
        /// </summary>
        /// <param name="modelAm"></param>
        /// <param name="oddNum"></param>
        /// <param name="SQLString"></param>
        public static void ByOneByWu ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "SELECT AMB209,AMB211,AMB225,AMB227 FROM R_PQAMB WHERE AMB001='{0}'" ,oddNum );

            //DataTable de = SqlHelper.ExecuteDataTable( "SELECT AM209,AM211 FROM R_PQAM WHERE AM002='" + modelAm.AM002 + "'" );
            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            if ( da != null && da.Rows.Count > 0 )
            {
                if ( modelAm.AM209 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB209='{0}' WHERE AMB001='{1}'" ,modelAm.AM209 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM211 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB211='{0}' WHERE AMB001='{1}'" ,modelAm.AM211 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm . AM225 > 0 )
                {
                    strSql = new StringBuilder ( );
                    strSql . AppendFormat ( "UPDATE R_PQAMB SET AMB225='{0}' WHERE AMB001='{1}'" , modelAm . AM225 , oddNum );
                    SQLString . Add ( strSql . ToString ( ) );
                }
                if ( modelAm . AM227 > 0 )
                {
                    strSql = new StringBuilder ( );
                    strSql . AppendFormat ( "UPDATE R_PQAMB SET AMB227='{0}' WHERE AMB001='{1}'" , modelAm . AM227 , oddNum );
                    SQLString . Add ( strSql . ToString ( ) );
                }

                //if ( de != null && de.Rows.Count > 0 )
                //{
                //    modelAm.AM209 = modelAm.AM209 - ( string.IsNullOrEmpty( da.Rows[0]["AMB209"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB209"].ToString( ) ) );
                //    modelAm.AM211 = modelAm.AM211 - ( string.IsNullOrEmpty( da.Rows[0]["AMB211"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB211"].ToString( ) ) );

                //    modelAm.AM209 = modelAm.AM209 + ( string.IsNullOrEmpty( de.Rows[0]["AM209"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM209"].ToString( ) ) );
                //    modelAm.AM211 = modelAm.AM211 + ( string.IsNullOrEmpty( de.Rows[0]["AM211"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM211"].ToString( ) ) );
                //}

            }
            else
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "INSERT INTO R_PQAMB (AMB001,AMB209,AMB211,AMB225,AMB227) VALUES ('{0}','{1}','{2}','{3}','{4}')" , oddNum ,modelAm.AM209 ,modelAm. AM211 , modelAm . AM225 , modelAm . AM227 );
                SQLString.Add( strSql.ToString( ) );
                //if ( de != null && de.Rows.Count > 0 )
                //{
                //    modelAm.AM209 = modelAm.AM209 + ( string.IsNullOrEmpty( de.Rows[0]["AM209"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM209"].ToString( ) ) );
                //    modelAm.AM211 = modelAm.AM211 + ( string.IsNullOrEmpty( de.Rows[0]["AM211"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM211"].ToString( ) ) );
                //}

            }
        }

        /// <summary>
        /// 343 漆
        /// </summary>
        /// <param name="modelAm"></param>
        /// <param name="oddNum"></param>
        /// <param name="SQLString"></param>
        public static void ByOneByQi ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            //modelAm.AM249 = 0M;modelAm.AM242 = modelAm.AM247 = 0M;
            strSql.AppendFormat( "SELECT AMB249,AMB242,AMB247 FROM R_PQAMB WHERE AMB001='{0}'" ,oddNum );
            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            //DataTable de = SqlHelper.ExecuteDataTable( "SELECT AM242,AM247,AM249 FROM R_PQAM WHERE AM002='" + modelAm.AM002 + "'" );
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
                
                //if ( de != null && de.Rows.Count > 0 )
                //{
                //    modelAm.AM242 = modelAm.AM242 - ( string.IsNullOrEmpty( da.Rows[0]["AMB242"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB242"].ToString( ) ) );
                //    modelAm.AM247 = modelAm.AM247 - ( string.IsNullOrEmpty( da.Rows[0]["AMB247"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB247"].ToString( ) ) );
                //    modelAm.AM249 = modelAm.AM249 - ( string.IsNullOrEmpty( da.Rows[0]["AMB249"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB249"].ToString( ) ) );

                //    modelAm.AM242 = modelAm.AM242 + ( string.IsNullOrEmpty( de.Rows[0]["AM242"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM242"].ToString( ) ) );
                //    modelAm.AM247 = modelAm.AM247 + ( string.IsNullOrEmpty( de.Rows[0]["AM247"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM247"].ToString( ) ) );
                //    modelAm.AM249 = modelAm.AM249 + ( string.IsNullOrEmpty( de.Rows[0]["AM249"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM249"].ToString( ) ) );
                //}
            }
            else
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "INSERT INTO R_PQAMB (AMB001,AMB242,AMB247,AMB249) VALUES ('{0}','{1}','{2}','{3}')" ,oddNum ,modelAm.AM242 ,modelAm.AM247 ,modelAm.AM249 );
                SQLString.Add( strSql.ToString( ) );
                //if ( de != null && de.Rows.Count > 0 )
                //{
                //    modelAm.AM242 = modelAm.AM242 + ( string.IsNullOrEmpty( de.Rows[0]["AM242"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM242"].ToString( ) ) );
                //    modelAm.AM247 = modelAm.AM247 + ( string.IsNullOrEmpty( de.Rows[0]["AM247"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM247"].ToString( ) ) );
                //    modelAm.AM249 = modelAm.AM249 + ( string.IsNullOrEmpty( de.Rows[0]["AM249"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM249"].ToString( ) ) );
                //}
            }
        }

        /// <summary>
        /// 347
        /// </summary>
        /// <param name="modelAm"></param>
        /// <param name="oddNum"></param>
        /// <param name="SQLString"></param>
        public static void ByOneBySu ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum ,ArrayList SQLString )
        {
            //modelAm.AM212 = modelAm.AM217 = modelAm.AM215 = modelAm.AM221 = modelAm.AM218 = modelAm.AM223 = 0;
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "SELECT AMB212,AMB215,AMB217,AMB218,AMB221,AMB223,AMB229,AMB231,AMB233,AMB235 FROM R_PQAMB WHERE AMB001='{0}'" , oddNum );
            //DataTable de = SqlHelper.ExecuteDataTable( "SELECT AM212,AM215,AM217,AM218,AM221,AM223 FROM R_PQAM WHERE AM002='" + modelAm.AM002 + "'" );
            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            if ( da != null && da.Rows.Count > 0 )
            {
                if ( modelAm.AM212 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB212='{0}' WHERE AMB001='{1}'" ,modelAm.AM212 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM215 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB215='{0}' WHERE AMB001='{1}'" ,modelAm.AM215 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM217 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB217='{0}' WHERE AMB001='{1}'" ,modelAm.AM217 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM218 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB218='{0}' WHERE AMB001='{1}'" ,modelAm.AM218 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM221 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB221='{0}' WHERE AMB001='{1}'" ,modelAm.AM221 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM223 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB223='{0}' WHERE AMB001='{1}'" ,modelAm.AM223 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm . AM229 > 0 )
                {
                    strSql = new StringBuilder ( );
                    strSql . AppendFormat ( "UPDATE R_PQAMB SET AMB229='{0}' WHERE AMB001='{1}'" , modelAm . AM229 , oddNum );
                    SQLString . Add ( strSql . ToString ( ) );
                }
                if ( modelAm . AM231 > 0 )
                {
                    strSql = new StringBuilder ( );
                    strSql . AppendFormat ( "UPDATE R_PQAMB SET AMB231='{0}' WHERE AMB001='{1}'" , modelAm . AM231 , oddNum );
                    SQLString . Add ( strSql . ToString ( ) );
                }
                if ( modelAm . AM233 > 0 )
                {
                    strSql = new StringBuilder ( );
                    strSql . AppendFormat ( "UPDATE R_PQAMB SET AMB233='{0}' WHERE AMB001='{1}'" , modelAm . AM233 , oddNum );
                    SQLString . Add ( strSql . ToString ( ) );
                }
                if ( modelAm . AM235 > 0 )
                {
                    strSql = new StringBuilder ( );
                    strSql . AppendFormat ( "UPDATE R_PQAMB SET AMB235='{0}' WHERE AMB001='{1}'" , modelAm . AM235 , oddNum );
                    SQLString . Add ( strSql . ToString ( ) );
                }

                //if ( de != null && de.Rows.Count > 0 )
                //{
                //    modelAm.AM212 = modelAm.AM212 - ( string.IsNullOrEmpty( da.Rows[0]["AMB212"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB212"].ToString( ) ) );
                //    modelAm.AM215 = modelAm.AM215 - ( string.IsNullOrEmpty( da.Rows[0]["AMB215"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB215"].ToString( ) ) );
                //    modelAm.AM217 = modelAm.AM217 - ( string.IsNullOrEmpty( da.Rows[0]["AMB217"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB217"].ToString( ) ) );
                //    modelAm.AM218 = modelAm.AM218 - ( string.IsNullOrEmpty( da.Rows[0]["AMB218"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB218"].ToString( ) ) );
                //    modelAm.AM221 = modelAm.AM221 - ( string.IsNullOrEmpty( da.Rows[0]["AMB221"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB221"].ToString( ) ) );
                //    modelAm.AM223 = modelAm.AM223 - ( string.IsNullOrEmpty( da.Rows[0]["AMB223"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB223"].ToString( ) ) );

                //    modelAm.AM212 = modelAm.AM212 + ( string.IsNullOrEmpty( de.Rows[0]["AM212"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM212"].ToString( ) ) );
                //    modelAm.AM215 = modelAm.AM215 + ( string.IsNullOrEmpty( de.Rows[0]["AM215"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM215"].ToString( ) ) );
                //    modelAm.AM217 = modelAm.AM217 + ( string.IsNullOrEmpty( de.Rows[0]["AM217"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM217"].ToString( ) ) );
                //    modelAm.AM218 = modelAm.AM218 + ( string.IsNullOrEmpty( de.Rows[0]["AM218"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM218"].ToString( ) ) );
                //    modelAm.AM221 = modelAm.AM221 + ( string.IsNullOrEmpty( de.Rows[0]["AM221"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM221"].ToString( ) ) );
                //    modelAm.AM223 = modelAm.AM223 + ( string.IsNullOrEmpty( de.Rows[0]["AM223"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM223"].ToString( ) ) );
                //}

            }
            else
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "INSERT INTO R_PQAMB (AMB001,AMB212,AMB215,AMB217,AMB218,AMB221,AMB223,AMB229,AMB231,AMB233,AMB235) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')" , oddNum ,modelAm.AM212 ,modelAm.AM215 ,modelAm.AM217 ,modelAm.AM218 ,modelAm.AM221 ,modelAm.AM223 , modelAm . AM229 , modelAm . AM231 , modelAm . AM233 , modelAm . AM235 );
                SQLString.Add( strSql.ToString( ) );
                //if ( de != null && de.Rows.Count > 0 )
                //{
                //    modelAm.AM212 = modelAm.AM212 + ( string.IsNullOrEmpty( de.Rows[0]["AM212"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM212"].ToString( ) ) );
                //    modelAm.AM215 = modelAm.AM215 + ( string.IsNullOrEmpty( de.Rows[0]["AM215"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM215"].ToString( ) ) );
                //    modelAm.AM217 = modelAm.AM217 + ( string.IsNullOrEmpty( de.Rows[0]["AM217"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM217"].ToString( ) ) );
                //    modelAm.AM218 = modelAm.AM218 + ( string.IsNullOrEmpty( de.Rows[0]["AM218"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM218"].ToString( ) ) );
                //    modelAm.AM221 = modelAm.AM221 + ( string.IsNullOrEmpty( de.Rows[0]["AM221"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM221"].ToString( ) ) );
                //    modelAm.AM223 = modelAm.AM223 + ( string.IsNullOrEmpty( de.Rows[0]["AM223"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM223"].ToString( ) ) );
                //}

            }
        }

        /// <summary>
        /// 349
        /// </summary>
        /// <param name="modelAm"></param>
        /// <param name="oddNum"></param>
        /// <param name="SQLString"></param>
        public static void ByOneByLiao ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AMB130,AMB133,AMB136,AMB138,AMB139,AMB142,AMB144,AMB145,AMB148,AMB150 FROM R_PQAMB" );
            strSql.AppendFormat( " WHERE AMB001='{0}'" ,oddNum );

            //DataTable de = SqlHelper.ExecuteDataTable( "SELECT AM130,AM133,AM136,AM138,AM139,AM142,AM144,AM145,AM148,AM150 FROM R_PQAM WHERE AM002='" + modelAm.AM002 + "'" );
            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            if ( da != null && da.Rows.Count > 0 )
            {
                if ( modelAm.AM130 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB130='{0}' WHERE AMB001='{1}'" ,modelAm.AM130 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM133 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB133='{0}' WHERE AMB001='{1}'" ,modelAm.AM133 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM136 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB136='{0}' WHERE AMB001='{1}'" ,modelAm.AM136 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM138 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB138='{0}' WHERE AMB001='{1}'" ,modelAm.AM138 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM139 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB139='{0}' WHERE AMB001='{1}'" ,modelAm.AM139 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM142 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB142='{0}' WHERE AMB001='{1}'" ,modelAm.AM142 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM144 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB144='{0}' WHERE AMB001='{1}'" ,modelAm.AM144 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM145 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB145='{0}' WHERE AMB001='{1}'" ,modelAm.AM145 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM148 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB148='{0}' WHERE AMB001='{1}'" ,modelAm.AM148 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM150 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB150='{0}' WHERE AMB001='{1}'" ,modelAm.AM150 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }
                
                //if ( de != null && de.Rows.Count > 0 )
                //{
                //    modelAm.AM130 = modelAm.AM130 - ( string.IsNullOrEmpty( da.Rows[0]["AMB130"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB130"].ToString( ) ) );
                //    modelAm.AM133 = modelAm.AM133 - ( string.IsNullOrEmpty( da.Rows[0]["AMB133"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB133"].ToString( ) ) );
                //    modelAm.AM136 = modelAm.AM136 - ( string.IsNullOrEmpty( da.Rows[0]["AMB136"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB136"].ToString( ) ) );
                //    modelAm.AM138 = modelAm.AM138 - ( string.IsNullOrEmpty( da.Rows[0]["AMB138"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB138"].ToString( ) ) );
                //    modelAm.AM139 = modelAm.AM139 - ( string.IsNullOrEmpty( da.Rows[0]["AMB139"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB139"].ToString( ) ) );
                //    modelAm.AM142 = modelAm.AM142 - ( string.IsNullOrEmpty( da.Rows[0]["AMB142"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB142"].ToString( ) ) );
                //    modelAm.AM144 = modelAm.AM144 - ( string.IsNullOrEmpty( da.Rows[0]["AMB144"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB144"].ToString( ) ) );
                //    modelAm.AM145 = modelAm.AM145 - ( string.IsNullOrEmpty( da.Rows[0]["AMB145"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB145"].ToString( ) ) );
                //    modelAm.AM148 = modelAm.AM148 - ( string.IsNullOrEmpty( da.Rows[0]["AMB148"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB148"].ToString( ) ) );
                //    modelAm.AM150 = modelAm.AM150 - ( string.IsNullOrEmpty( da.Rows[0]["AMB150"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB150"].ToString( ) ) );

                //    modelAm.AM130 = modelAm.AM130 + ( string.IsNullOrEmpty( de.Rows[0]["AM130"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM130"].ToString( ) ) );
                //    modelAm.AM133 = modelAm.AM133 + ( string.IsNullOrEmpty( de.Rows[0]["AM133"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM133"].ToString( ) ) );
                //    modelAm.AM136 = modelAm.AM136 + ( string.IsNullOrEmpty( de.Rows[0]["AM136"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM136"].ToString( ) ) );
                //    modelAm.AM138 = modelAm.AM138 + ( string.IsNullOrEmpty( de.Rows[0]["AM138"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM138"].ToString( ) ) );
                //    modelAm.AM139 = modelAm.AM139 + ( string.IsNullOrEmpty( de.Rows[0]["AM139"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM139"].ToString( ) ) );
                //    modelAm.AM142 = modelAm.AM142 + ( string.IsNullOrEmpty( de.Rows[0]["AM142"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM142"].ToString( ) ) );
                //    modelAm.AM144 = modelAm.AM144 + ( string.IsNullOrEmpty( de.Rows[0]["AM144"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM144"].ToString( ) ) );
                //    modelAm.AM145 = modelAm.AM145 + ( string.IsNullOrEmpty( de.Rows[0]["AM145"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM145"].ToString( ) ) );
                //    modelAm.AM148 = modelAm.AM148 + ( string.IsNullOrEmpty( de.Rows[0]["AM148"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM148"].ToString( ) ) );
                //    modelAm.AM150 = modelAm.AM150 + ( string.IsNullOrEmpty( de.Rows[0]["AM150"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM150"].ToString( ) ) );
                //}

            }
            else
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "INSERT INTO R_PQAMB (AMB001,AMB130,AMB133,AMB136,AMB138,AMB139,AMB142,AMB144,AMB145,AMB148,AMB150) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')" ,oddNum ,modelAm.AM130 ,modelAm.AM133 ,modelAm.AM136 ,modelAm.AM138 ,modelAm.AM139 ,modelAm.AM142 ,modelAm.AM144 ,modelAm.AM145 ,modelAm.AM148 ,modelAm.AM150 );
                SQLString.Add( strSql.ToString( ) );
                //if ( de != null && de.Rows.Count > 0 )
                //{
                //    modelAm.AM130 = modelAm.AM130 + ( string.IsNullOrEmpty( de.Rows[0]["AM130"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM130"].ToString( ) ) );
                //    modelAm.AM133 = modelAm.AM133 + ( string.IsNullOrEmpty( de.Rows[0]["AM133"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM133"].ToString( ) ) );
                //    modelAm.AM136 = modelAm.AM136 + ( string.IsNullOrEmpty( de.Rows[0]["AM136"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM136"].ToString( ) ) );
                //    modelAm.AM138 = modelAm.AM138 + ( string.IsNullOrEmpty( de.Rows[0]["AM138"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM138"].ToString( ) ) );
                //    modelAm.AM139 = modelAm.AM139 + ( string.IsNullOrEmpty( de.Rows[0]["AM139"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM139"].ToString( ) ) );
                //    modelAm.AM142 = modelAm.AM142 + ( string.IsNullOrEmpty( de.Rows[0]["AM142"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM142"].ToString( ) ) );
                //    modelAm.AM144 = modelAm.AM144 + ( string.IsNullOrEmpty( de.Rows[0]["AM144"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM144"].ToString( ) ) );
                //    modelAm.AM145 = modelAm.AM145 + ( string.IsNullOrEmpty( de.Rows[0]["AM145"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM145"].ToString( ) ) );
                //    modelAm.AM148 = modelAm.AM148 + ( string.IsNullOrEmpty( de.Rows[0]["AM148"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM148"].ToString( ) ) );
                //    modelAm.AM150 = modelAm.AM150 + ( string.IsNullOrEmpty( de.Rows[0]["AM150"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM150"].ToString( ) ) );
                //}

            }
        }

        /// <summary>
        /// 348
        /// </summary>
        /// <param name="modelAm"></param>
        /// <param name="oddNum"></param>
        /// <param name="SQLString"></param>
        public static void ByOneByLiaos ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AMB139,AMB144 FROM R_PQAMB" );
            strSql.AppendFormat( " WHERE AMB001='{0}' AND AMB002='{1}'" ,oddNum ,modelAm.AM002 );

            //DataTable de = SqlHelper.ExecuteDataTable( "SELECT AM139,AM144 FROM R_PQAM WHERE AM002='" + modelAm.AM002 + "'" );
            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            if ( da != null && da.Rows.Count > 0 )
            {
                if ( modelAm.AM139 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB139='{0}' WHERE AMB001='{1}' AND AMB002='{2}'" ,modelAm.AM139 ,oddNum ,modelAm.AM002 );
                    SQLString.Add( strSql.ToString( ) );
                }
                if ( modelAm.AM144 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB144='{0}' WHERE AMB001='{1}' AND AMB002='{2}'" ,modelAm.AM144 ,oddNum ,modelAm.AM002 );
                    SQLString.Add( strSql.ToString( ) );
                }

                //if ( de != null && de.Rows.Count > 0 )
                //{
                //    modelAm.AM139 = modelAm.AM139 - ( string.IsNullOrEmpty( da.Rows[0]["AMB139"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB139"].ToString( ) ) );
                //    modelAm.AM144 = modelAm.AM144 - ( string.IsNullOrEmpty( da.Rows[0]["AMB144"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB144"].ToString( ) ) );

                //    modelAm.AM139 = modelAm.AM139 + ( string.IsNullOrEmpty( de.Rows[0]["AM139"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM139"].ToString( ) ) );
                //    modelAm.AM144 = modelAm.AM144 + ( string.IsNullOrEmpty( de.Rows[0]["AM144"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM144"].ToString( ) ) );
                //}

            }
            else
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "INSERT INTO R_PQAMB (AMB001,AMB002,AMB139,AMB144) VALUES ('{0}','{1}','{2}','{3}')" ,oddNum ,modelAm.AM002 ,modelAm.AM139 ,modelAm.AM144 );
                SQLString.Add( strSql.ToString( ) );
                //if ( de != null && de.Rows.Count > 0 )
                //{
                //    modelAm.AM139 = modelAm.AM139 + ( string.IsNullOrEmpty( de.Rows[0]["AM139"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM139"].ToString( ) ) );
                //    modelAm.AM144 = modelAm.AM144 + ( string.IsNullOrEmpty( de.Rows[0]["AM144"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM144"].ToString( ) ) );
                //}

            }
        }

        /// <summary>
        /// 495
        /// </summary>
        /// <param name="modelAm"></param>
        /// <param name="oddNum"></param>
        /// <param name="SQLString"></param>
       public static void ByOneByQiGong ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "SELECT AMB088 FROM R_PQAMB WHERE AMB001='{0}'" ,oddNum );
            //DataTable de = SqlHelper.ExecuteDataTable( "SELECT AM088 FROM R_PQAM WHERE AM002='" + modelAm.AM002 + "'" );
            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            if ( da != null && da.Rows.Count > 0 )
            {
                if ( modelAm.AM088 > 0 )
                {
                    strSql = new StringBuilder( );
                    strSql.AppendFormat( "UPDATE R_PQAMB SET AMB088='{0}' WHERE AMB001='{1}'" ,modelAm.AM088 ,oddNum );
                    SQLString.Add( strSql.ToString( ) );
                }

                //if ( de != null && de.Rows.Count > 0 )
                //{
                //    modelAm.AM088 = modelAm.AM088 - ( string.IsNullOrEmpty( da.Rows[0]["AMB088"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["AMB088"].ToString( ) ) );
                //    modelAm.AM088 = modelAm.AM088 + ( string.IsNullOrEmpty( de.Rows[0]["AM088"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM088"].ToString( ) ) );
                //}    

            }
            else
            {
                strSql = new StringBuilder( );
                strSql.AppendFormat( "INSERT INTO R_PQAMB (AMB001,AMB088) VALUES ('{0}','{1}')" ,oddNum ,modelAm.AM088 );
                SQLString.Add( strSql.ToString( ) );
                //if ( de != null && de.Rows.Count > 0 )
                //    modelAm.AM088 = modelAm.AM088 + ( string.IsNullOrEmpty( de.Rows[0]["AM088"].ToString( ) ) == true ? 0 : Convert.ToDecimal( de.Rows[0]["AM088"].ToString( ) ) );

            }
        }

        /// <summary>
        /// 285
        /// </summary>
        /// <param name="modelAm"></param>
        /// <param name="oddNum"></param>
        /// <param name="SQLString"></param>
        public static void ByOneByQiSum ( MulaolaoLibrary . ProductCostSummaryLibrary modelAm , string oddNum , ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT AMB173 FROM R_PQAMB WHERE AMB001='{0}'" , oddNum );

            //DataTable de = SqlHelper . ExecuteDataTable ( "SELECT AM173 FROM R_PQAM WHERE AM002='" + modelAm . AM002 + "'" );
            DataTable da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( da != null && da . Rows . Count > 0 )
            {
                if ( modelAm . AM173 > 0 )
                {
                    strSql = new StringBuilder ( );
                    strSql . AppendFormat ( "UPDATE R_PQAMB SET AMB173='{0}' WHERE AMB001='{1}'" , modelAm . AM173 , oddNum );
                    SQLString . Add ( strSql . ToString ( ) );
                }

                //if ( de != null && de . Rows . Count > 0 )
                //{
                //    modelAm . AM173 = modelAm . AM173 - ( string . IsNullOrEmpty ( da . Rows [ 0 ] [ "AMB173" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "AMB173" ] . ToString ( ) ) );

                //    modelAm . AM173 = modelAm . AM173 + ( string . IsNullOrEmpty ( de . Rows [ 0 ] [ "AM173" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ 0 ] [ "AM173" ] . ToString ( ) ) );
                //}
            }
            else
            {
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "INSERT INTO R_PQAMB (AMB001,AMB173) VALUES ('{0}','{1}')" , oddNum , modelAm . AM173 );
                SQLString . Add ( strSql . ToString ( ) );
                //if ( de != null && de . Rows . Count > 0 )
                //{
                //    modelAm . AM173 = modelAm . AM173 + ( string . IsNullOrEmpty ( de . Rows [ 0 ] [ "AM173" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ 0 ] [ "AM173" ] . ToString ( ) ) );
                //}

            }
        }

        /// <summary>
        /// 是否存在供应商
        /// </summary>
        /// <param name="supNum"></param>
        /// <returns></returns>
        public static bool ExistsSup ( string supNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM TPADGA WHERE DGA001='{0}' AND DGA052='F'" ,supNum );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

    }
}

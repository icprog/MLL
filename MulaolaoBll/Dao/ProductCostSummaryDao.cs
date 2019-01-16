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
    public class ProductCostSummaryDao
    {
        #region BasicMethod
        
        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Exists ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQAM" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };

            parameter[0].Value = idx;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsModel ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQAM" );
            strSql.Append( " WHERE AM002=@AM002" );
            SqlParameter[] parameter = {
                new SqlParameter("@AM002",SqlDbType.NVarChar,20)
            };

            parameter[0].Value = model.AM002;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsModel ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQAM" );
            strSql.Append( " WHERE AM002=@AM002" );
            SqlParameter[] parameter = {
                new SqlParameter("@AM002",SqlDbType.NVarChar,20)
            };

            parameter[0].Value = num;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 是否存在idx
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTableExists ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx FROM R_PQAM" );
            strSql.Append( " WHERE AM002=@AM002" );
            SqlParameter[] parameter = {
                new SqlParameter("@AM002",SqlDbType.NVarChar,20)
            };

            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAM (" );
            strSql.Append( "AM001,AM002,AM003,AM004,AM005,AM006,AM007,AM008,AM009,AM010,AM011,AM012,AM013,AM014,AM015,AM016,AM017,AM018,AM019,AM044,AM045,AM046,AM047,AM048,AM049,AM050,AM051,AM052,AM053,AM054,AM055,AM056,AM057,AM058,AM059,AM060,AM061,AM070,AM071,AM072,AM073,AM074,AM075,AM076,AM077,AM078,AM079,AM080,AM081,AM082,AM083,AM084,AM085,AM086,AM087,AM088,AM089,AM090,AM091,AM092,AM093,AM108,AM109,AM110,AM111,AM112,AM113,AM130,AM131,AM133,AM134,AM135,AM136,AM137,AM138,AM139,AM140,AM141,AM142,AM143,AM144,AM145,AM146,AM147,AM148,AM149,AM150,AM151,AM152,AM173,AM175,AM176,AM177,AM178,AM179,AM180,AM182,AM183,AM184,AM185,AM186,AM187,AM188,AM189,AM190,AM191,AM192,AM193,AM194,AM195,AM196,AM197,AM198,AM199,AM200,AM201,AM203,AM204,AM205,AM206,AM207,AM208,AM209,AM210,AM211,AM212,AM213,AM214,AM215,AM216,AM217,AM218,AM219,AM220,AM221,AM222,AM223,AM224,AM239,AM240,AM241,AM242,AM243,AM244,AM245,AM246,AM247,AM249,AM250,AM251,AM252,AM253,AM261,AM262,AM263,AM264,AM265,AM266,AM267,AM268,AM269,AM270,AM271,AM272,AM273,AM274,AM275,AM277,AM278,AM279,AM280,AM281,AM282,AM283,AM284,AM285,AM286,AM287,AM288,AM289,AM290,AM291,AM292,AM293,AM294,AM295,AM296,AM297,AM298,AM299,AM300,AM301,AM302,AM303,AM304,AM305,AM306,AM307,AM308,AM309,AM311,AM312,AM313,AM315,AM316,AM317,AM318,AM319,AM320,AM321,AM322,AM323,AM324,AM325,AM326,AM327,AM328,AM329,AM330,AM331,AM332,AM333,AM334,AM335,AM336,AM337,AM338,AM339,AM340,AM341,AM343,AM344,AM345,AM346,AM347,AM348,AM349,AM350,AM351,AM352,AM353,AM354,AM355,AM356,AM357,AM358,AM359,AM360,AM361,AM362,AM363,AM364,AM365,AM366,AM367,AM368,AM369,AM370,AM371,AM372,AM373,AM374,AM375,AM376,AM377,AM378,AM379,AM380,AM381,AM382,AM383,AM385,AM386,AM387,AM388,AM389,AM390,AM391,AM392,AM393,AM020,AM021,AM022,AM023,AM024,AM025,AM026,AM027,AM028,AM029,AM225,AM226,AM227,AM228,AM229,AM230,AM231,AM232,AM233,AM234,AM235,AM236,AM237,AM238,AM255,AM256,AM153,AM154,AM155,AM156,AM157,AM158,AM248,AM062,AM063)" );
            strSql.Append( " VALUES (" );
            strSql.Append( "@AM001,@AM002,@AM003,@AM004,@AM005,@AM006,@AM007,@AM008,@AM009,@AM010,@AM011,@AM012,@AM013,@AM014,@AM015,@AM016,@AM017,@AM018,@AM019,@AM044,@AM045,@AM046,@AM047,@AM048,@AM049,@AM050,@AM051,@AM052,@AM053,@AM054,@AM055,@AM056,@AM057,@AM058,@AM059,@AM060,@AM061,@AM070,@AM071,@AM072,@AM073,@AM074,@AM075,@AM076,@AM077,@AM078,@AM079,@AM080,@AM081,@AM082,@AM083,@AM084,@AM085,@AM086,@AM087,@AM088,@AM089,@AM090,@AM091,@AM092,@AM093,@AM108,@AM109,@AM110,@AM111,@AM112,@AM113,@AM130,@AM131,@AM133,@AM134,@AM135,@AM136,@AM137,@AM138,@AM139,@AM140,@AM141,@AM142,@AM143,@AM144,@AM145,@AM146,@AM147,@AM148,@AM149,@AM150,@AM151,@AM152,@AM173,@AM175,@AM176,@AM177,@AM178,@AM179,@AM180,@AM182,@AM183,@AM184,@AM185,@AM186,@AM187,@AM188,@AM189,@AM190,@AM191,@AM192,@AM193,@AM194,@AM195,@AM196,@AM197,@AM198,@AM199,@AM200,@AM201,@AM203,@AM204,@AM205,@AM206,@AM207,@AM208,@AM209,@AM210,@AM211,@AM212,@AM213,@AM214,@AM215,@AM216,@AM217,@AM218,@AM219,@AM220,@AM221,@AM222,@AM223,@AM224,@AM239,@AM240,@AM241,@AM242,@AM243,@AM244,@AM245,@AM246,@AM247,@AM249,@AM250,@AM251,@AM252,@AM253,@AM261,@AM262,@AM263,@AM264,@AM265,@AM266,@AM267,@AM268,@AM269,@AM270,@AM271,@AM272,@AM273,@AM274,@AM275,@AM277,@AM278,@AM279,@AM280,@AM281,@AM282,@AM283,@AM284,@AM285,@AM286,@AM287,@AM288,@AM289,@AM290,@AM291,@AM292,@AM293,@AM294,@AM295,@AM296,@AM297,@AM298,@AM299,@AM300,@AM301,@AM302,@AM303,@AM304,@AM305,@AM306,@AM307,@AM308,@AM309,@AM311,@AM312,@AM313,@AM315,@AM316,@AM317,@AM318,@AM319,@AM320,@AM321,@AM322,@AM323,@AM324,@AM325,@AM326,@AM327,@AM328,@AM329,@AM330,@AM331,@AM332,@AM333,@AM334,@AM335,@AM336,@AM337,@AM338,@AM339,@AM340,@AM341,@AM343,@AM344,@AM345,@AM346,@AM347,@AM348,@AM349,@AM350,@AM351,@AM352,@AM353,@AM354,@AM355,@AM356,@AM357,@AM358,@AM359,@AM360,@AM361,@AM362,@AM363,@AM364,@AM365,@AM366,@AM367,@AM368,@AM369,@AM370,@AM371,@AM372,@AM373,@AM374,@AM375,@AM376,@AM377,@AM378,@AM379,@AM380,@AM381,@AM382,@AM383,@AM385,@AM386,@AM387,@AM388,@AM389,@AM390,@AM391,@AM392,@AM393,@AM020,@AM021,@AM022,@AM023,@AM024,@AM025,@AM026,@AM027,@AM028,@AM029,@AM225,@AM226,@AM227,@AM228,@AM229,@AM230,@AM231,@AM232,@AM233,@AM234,@AM235,@AM236,@AM237,@AM238,@AM255,@AM256,@AM153,@AM154,@AM155,@AM156,@AM157,@AM158,@AM248,@AM062,@AM063);" );
            strSql.Append( "SELECT SCOPE_IDENTITY();" );


            SqlParameter[] parameter = {
                new SqlParameter("@AM001",SqlDbType.NVarChar,20),
                new SqlParameter("@AM002",SqlDbType.NVarChar,20),
                new SqlParameter("@AM003",SqlDbType.NVarChar,20),
                new SqlParameter("@AM004",SqlDbType.NVarChar,20),
                new SqlParameter("@AM005",SqlDbType.NVarChar,20),
                new SqlParameter("@AM006",SqlDbType.BigInt),
                new SqlParameter("@AM007",SqlDbType.Date),
                new SqlParameter("@AM008",SqlDbType.NVarChar,20),
                new SqlParameter("@AM009",SqlDbType.NVarChar,20),
                new SqlParameter("@AM010",SqlDbType.NVarChar,20),
                new SqlParameter("@AM011",SqlDbType.NVarChar,20),
                new SqlParameter("@AM012",SqlDbType.NChar,10),
                new SqlParameter("@AM013",SqlDbType.NVarChar,20),
                new SqlParameter("@AM014",SqlDbType.NVarChar,20),
                new SqlParameter("@AM015",SqlDbType.BigInt),
                new SqlParameter("@AM016",SqlDbType.Decimal,10),
                new SqlParameter("@AM017",SqlDbType.Decimal,10),
                new SqlParameter("@AM018",SqlDbType.Decimal,10),
                new SqlParameter("@AM019",SqlDbType.Decimal,10),
                new SqlParameter("@AM044",SqlDbType.Decimal,10),
                new SqlParameter("@AM045",SqlDbType.Decimal,10),
                new SqlParameter("@AM046",SqlDbType.Decimal,10),
                new SqlParameter("@AM047",SqlDbType.Decimal,10),
                new SqlParameter("@AM048",SqlDbType.Decimal,10),
                new SqlParameter("@AM049",SqlDbType.Decimal,10),
                new SqlParameter("@AM050",SqlDbType.Decimal,10),
                new SqlParameter("@AM051",SqlDbType.Decimal,10),
                new SqlParameter("@AM052",SqlDbType.Decimal,10),
                new SqlParameter("@AM053",SqlDbType.Decimal,10),
                new SqlParameter("@AM054",SqlDbType.Decimal,10),
                new SqlParameter("@AM055",SqlDbType.Decimal,10),
                new SqlParameter("@AM056",SqlDbType.Decimal,10),
                new SqlParameter("@AM057",SqlDbType.Decimal,10),
                new SqlParameter("@AM058",SqlDbType.Decimal,10),
                new SqlParameter("@AM059",SqlDbType.Decimal,10),
                new SqlParameter("@AM060",SqlDbType.Decimal,10),
                new SqlParameter("@AM061",SqlDbType.Decimal,10),
                new SqlParameter("@AM070",SqlDbType.Decimal,10),
                new SqlParameter("@AM071",SqlDbType.Decimal,10),
                new SqlParameter("@AM072",SqlDbType.Decimal,10),
                new SqlParameter("@AM073",SqlDbType.Decimal,10),
                new SqlParameter("@AM074",SqlDbType.Decimal,10),
                new SqlParameter("@AM075",SqlDbType.Decimal,10),
                new SqlParameter("@AM076",SqlDbType.Decimal,10),
                new SqlParameter("@AM077",SqlDbType.Decimal,10),
                new SqlParameter("@AM078",SqlDbType.Decimal,10),
                new SqlParameter("@AM079",SqlDbType.Decimal,10),
                new SqlParameter("@AM080",SqlDbType.Decimal,10),
                new SqlParameter("@AM081",SqlDbType.Decimal,10),
                new SqlParameter("@AM082",SqlDbType.Decimal,10),
                new SqlParameter("@AM083",SqlDbType.Decimal,10),
                new SqlParameter("@AM084",SqlDbType.Decimal,10),
                new SqlParameter("@AM085",SqlDbType.Decimal,10),
                new SqlParameter("@AM086",SqlDbType.Decimal,10),
                new SqlParameter("@AM087",SqlDbType.Decimal,10),
                new SqlParameter("@AM088",SqlDbType.Decimal,10),
                new SqlParameter("@AM089",SqlDbType.Decimal,10),
                new SqlParameter("@AM090",SqlDbType.Decimal,10),
                new SqlParameter("@AM091",SqlDbType.Decimal,10),
                new SqlParameter("@AM092",SqlDbType.Decimal,10),
                new SqlParameter("@AM093",SqlDbType.Decimal,10),
                new SqlParameter("@AM108",SqlDbType.Decimal,10),
                new SqlParameter("@AM109",SqlDbType.Decimal,10),
                new SqlParameter("@AM110",SqlDbType.Decimal,10),
                new SqlParameter("@AM111",SqlDbType.Decimal,10),
                new SqlParameter("@AM112",SqlDbType.Decimal,10),
                new SqlParameter("@AM113",SqlDbType.Decimal,10),
                new SqlParameter("@AM130",SqlDbType.Decimal,10),
                new SqlParameter("@AM131",SqlDbType.Decimal,10),
                new SqlParameter("@AM133",SqlDbType.Decimal,10),
                new SqlParameter("@AM134",SqlDbType.Decimal,10),
                new SqlParameter("@AM135",SqlDbType.Decimal,10),
                new SqlParameter("@AM136",SqlDbType.Decimal,10),
                new SqlParameter("@AM137",SqlDbType.Decimal,10),
                new SqlParameter("@AM138",SqlDbType.Decimal,10),
                new SqlParameter("@AM139",SqlDbType.Decimal,10),
                new SqlParameter("@AM140",SqlDbType.Decimal,10),
                new SqlParameter("@AM141",SqlDbType.Decimal,10),
                new SqlParameter("@AM142",SqlDbType.Decimal,10),
                new SqlParameter("@AM143",SqlDbType.Decimal,10),
                new SqlParameter("@AM144",SqlDbType.Decimal,10),
                new SqlParameter("@AM145",SqlDbType.Decimal,10),
                new SqlParameter("@AM146",SqlDbType.Decimal,10),
                new SqlParameter("@AM147",SqlDbType.Decimal,10),
                new SqlParameter("@AM148",SqlDbType.Decimal,10),
                new SqlParameter("@AM149",SqlDbType.Decimal,10),
                new SqlParameter("@AM150",SqlDbType.Decimal,10),
                new SqlParameter("@AM151",SqlDbType.Decimal,10),
                new SqlParameter("@AM152",SqlDbType.Decimal,10),
                new SqlParameter("@AM175",SqlDbType.Decimal,10),
                new SqlParameter("@AM176",SqlDbType.Decimal,10),
                new SqlParameter("@AM177",SqlDbType.Decimal,10),
                new SqlParameter("@AM178",SqlDbType.Decimal,10),
                new SqlParameter("@AM179",SqlDbType.Decimal,10),
                new SqlParameter("@AM180",SqlDbType.Decimal,10),
                new SqlParameter("@AM182",SqlDbType.Decimal,10),
                new SqlParameter("@AM183",SqlDbType.Decimal,10),
                new SqlParameter("@AM184",SqlDbType.Decimal,10),
                new SqlParameter("@AM185",SqlDbType.Decimal,10),
                new SqlParameter("@AM186",SqlDbType.Decimal,10),
                new SqlParameter("@AM187",SqlDbType.Decimal,10),
                new SqlParameter("@AM188",SqlDbType.Decimal,10),
                new SqlParameter("@AM189",SqlDbType.Decimal,10),
                new SqlParameter("@AM190",SqlDbType.Decimal,10),
                new SqlParameter("@AM191",SqlDbType.Decimal,10),
                new SqlParameter("@AM192",SqlDbType.Decimal,10),
                new SqlParameter("@AM193",SqlDbType.Decimal,10),
                new SqlParameter("@AM194",SqlDbType.Decimal,10),
                new SqlParameter("@AM195",SqlDbType.Decimal,10),
                new SqlParameter("@AM196",SqlDbType.Decimal,10),
                new SqlParameter("@AM197",SqlDbType.Decimal,10),
                new SqlParameter("@AM198",SqlDbType.Decimal,10),
                new SqlParameter("@AM199",SqlDbType.Decimal,10),
                new SqlParameter("@AM200",SqlDbType.Decimal,10),
                new SqlParameter("@AM201",SqlDbType.Decimal,10),
                //new SqlParameter("@AM202",SqlDbType.Decimal,10),
                new SqlParameter("@AM203",SqlDbType.Decimal,10),
                new SqlParameter("@AM204",SqlDbType.Decimal,10),
                new SqlParameter("@AM205",SqlDbType.Decimal,10),
                new SqlParameter("@AM206",SqlDbType.Decimal,10),
                new SqlParameter("@AM207",SqlDbType.Decimal,10),
                new SqlParameter("@AM208",SqlDbType.Decimal,10),
                new SqlParameter("@AM209",SqlDbType.Decimal,10),
                new SqlParameter("@AM210",SqlDbType.Decimal,10),
                new SqlParameter("@AM211",SqlDbType.Decimal,10),
                new SqlParameter("@AM212",SqlDbType.Decimal,10),
                new SqlParameter("@AM213",SqlDbType.Decimal,10),
                new SqlParameter("@AM214",SqlDbType.Decimal,10),
                new SqlParameter("@AM215",SqlDbType.Decimal,10),
                new SqlParameter("@AM216",SqlDbType.Decimal,10),
                new SqlParameter("@AM217",SqlDbType.Decimal,10),
                new SqlParameter("@AM218",SqlDbType.Decimal,10),
                new SqlParameter("@AM219",SqlDbType.Decimal,10),
                new SqlParameter("@AM220",SqlDbType.Decimal,10),
                new SqlParameter("@AM221",SqlDbType.Decimal,10),
                new SqlParameter("@AM222",SqlDbType.Decimal,10),
                new SqlParameter("@AM223",SqlDbType.Decimal,10),
                new SqlParameter("@AM224",SqlDbType.Decimal,10),
                new SqlParameter("@AM239",SqlDbType.Decimal,10),
                new SqlParameter("@AM240",SqlDbType.Decimal,10),
                new SqlParameter("@AM241",SqlDbType.Decimal,10),
                new SqlParameter("@AM242",SqlDbType.Decimal,10),
                new SqlParameter("@AM243",SqlDbType.Decimal,10),
                new SqlParameter("@AM244",SqlDbType.Decimal,10),
                new SqlParameter("@AM245",SqlDbType.Decimal,10),
                new SqlParameter("@AM246",SqlDbType.Decimal,10),
                new SqlParameter("@AM247",SqlDbType.Decimal,10),
                //new SqlParameter("@AM248",SqlDbType.Decimal,10),
                new SqlParameter("@AM249",SqlDbType.Decimal,10),
                new SqlParameter("@AM250",SqlDbType.Decimal,10),
                new SqlParameter("@AM251",SqlDbType.Decimal,10),
                new SqlParameter("@AM252",SqlDbType.Decimal,10),
                new SqlParameter("@AM253",SqlDbType.Decimal,10),
                new SqlParameter("@AM261",SqlDbType.Decimal,10),
                new SqlParameter("@AM262",SqlDbType.Decimal,10),
                new SqlParameter("@AM263",SqlDbType.Decimal,10),
                new SqlParameter("@AM264",SqlDbType.Decimal,10),
                new SqlParameter("@AM265",SqlDbType.Decimal,10),
                new SqlParameter("@AM266",SqlDbType.Decimal,10),
                new SqlParameter("@AM267",SqlDbType.Decimal,10),
                new SqlParameter("@AM268",SqlDbType.Decimal,10),
                new SqlParameter("@AM269",SqlDbType.Decimal,10),
                new SqlParameter("@AM270",SqlDbType.Decimal,10),
                new SqlParameter("@AM271",SqlDbType.Decimal,10),
                new SqlParameter("@AM272",SqlDbType.Decimal,10),
                new SqlParameter("@AM273",SqlDbType.Decimal,10),
                new SqlParameter("@AM274",SqlDbType.Decimal,10),
                new SqlParameter("@AM275",SqlDbType.Decimal,10),
                new SqlParameter("@AM277",SqlDbType.Decimal,10),
                new SqlParameter("@AM278",SqlDbType.Decimal,10),
                new SqlParameter("@AM279",SqlDbType.Decimal,10),
                new SqlParameter("@AM280",SqlDbType.Decimal,10),
                new SqlParameter("@AM281",SqlDbType.Decimal,10),
                new SqlParameter("@AM282",SqlDbType.Decimal,10),
                new SqlParameter("@AM283",SqlDbType.Decimal,10),
                new SqlParameter("@AM284",SqlDbType.Decimal,10),
                new SqlParameter("@AM285",SqlDbType.Decimal,10),
                new SqlParameter("@AM286",SqlDbType.Decimal,10),
                new SqlParameter("@AM287",SqlDbType.Decimal,10),
                new SqlParameter("@AM288",SqlDbType.Decimal,10),
                new SqlParameter("@AM289",SqlDbType.Decimal,10),
                new SqlParameter("@AM290",SqlDbType.Decimal,10),
                new SqlParameter("@AM291",SqlDbType.Decimal,10),
                new SqlParameter("@AM292",SqlDbType.Decimal,10),
                new SqlParameter("@AM293",SqlDbType.Decimal,10),
                new SqlParameter("@AM294",SqlDbType.Decimal,10),
                new SqlParameter("@AM295",SqlDbType.Decimal,10),
                new SqlParameter("@AM296",SqlDbType.Decimal,10),
                new SqlParameter("@AM297",SqlDbType.Decimal,10),
                new SqlParameter("@AM298",SqlDbType.Decimal,10),
                new SqlParameter("@AM299",SqlDbType.Decimal,10),
                new SqlParameter("@AM300",SqlDbType.Decimal,10),
                new SqlParameter("@AM301",SqlDbType.Decimal,10),
                new SqlParameter("@AM302",SqlDbType.Decimal,10),
                new SqlParameter("@AM303",SqlDbType.Decimal,10),
                new SqlParameter("@AM304",SqlDbType.Decimal,10),
                new SqlParameter("@AM305",SqlDbType.Decimal,10),
                new SqlParameter("@AM306",SqlDbType.Decimal,10),
                new SqlParameter("@AM307",SqlDbType.Decimal,10),
                new SqlParameter("@AM308",SqlDbType.Decimal,10),
                new SqlParameter("@AM309",SqlDbType.Decimal,10),
                new SqlParameter("@AM311",SqlDbType.Decimal,10),
                new SqlParameter("@AM312",SqlDbType.Decimal,10),
                new SqlParameter("@AM313",SqlDbType.Decimal,10),
                new SqlParameter("@AM315",SqlDbType.Decimal,10),
                new SqlParameter("@AM316",SqlDbType.Decimal,10),
                new SqlParameter("@AM317",SqlDbType.Decimal,10),
                new SqlParameter("@AM318",SqlDbType.Decimal,10),
                new SqlParameter("@AM319",SqlDbType.Decimal,10),
                new SqlParameter("@AM320",SqlDbType.Decimal,10),
                new SqlParameter("@AM321",SqlDbType.Decimal,10),
                new SqlParameter("@AM322",SqlDbType.Decimal,10),
                new SqlParameter("@AM323",SqlDbType.Decimal,10),
                new SqlParameter("@AM324",SqlDbType.Decimal,10),
                new SqlParameter("@AM325",SqlDbType.Decimal,10),
                new SqlParameter("@AM326",SqlDbType.Decimal,10),
                new SqlParameter("@AM327",SqlDbType.Decimal,10),
                new SqlParameter("@AM328",SqlDbType.Decimal,10),
                new SqlParameter("@AM329",SqlDbType.Decimal,10),
                new SqlParameter("@AM330",SqlDbType.Decimal,10),
                new SqlParameter("@AM331",SqlDbType.Decimal,10),
                new SqlParameter("@AM332",SqlDbType.Decimal,10),
                new SqlParameter("@AM333",SqlDbType.Decimal,10),
                new SqlParameter("@AM334",SqlDbType.Decimal,10),
                new SqlParameter("@AM335",SqlDbType.Decimal,10),
                new SqlParameter("@AM336",SqlDbType.Decimal,10),
                new SqlParameter("@AM337",SqlDbType.Decimal,10),
                new SqlParameter("@AM338",SqlDbType.Decimal,10),
                new SqlParameter("@AM339",SqlDbType.Decimal,10),
                new SqlParameter("@AM340",SqlDbType.Decimal,10),
                new SqlParameter("@AM341",SqlDbType.Decimal,10),
                new SqlParameter("@AM343",SqlDbType.Decimal,10),
                new SqlParameter("@AM344",SqlDbType.Decimal,10),
                new SqlParameter("@AM345",SqlDbType.Decimal,10),
                new SqlParameter("@AM346",SqlDbType.Decimal,10),
                new SqlParameter("@AM347",SqlDbType.Decimal,10),
                new SqlParameter("@AM348",SqlDbType.Decimal,10),
                new SqlParameter("@AM349",SqlDbType.Decimal,10),
                new SqlParameter("@AM350",SqlDbType.Decimal,10),
                new SqlParameter("@AM351",SqlDbType.Decimal,10),
                new SqlParameter("@AM352",SqlDbType.Decimal,10),
                new SqlParameter("@AM353",SqlDbType.Decimal,10),
                new SqlParameter("@AM354",SqlDbType.Decimal,10),
                new SqlParameter("@AM355",SqlDbType.Decimal,10),
                new SqlParameter("@AM356",SqlDbType.Decimal,10),
                new SqlParameter("@AM357",SqlDbType.Decimal,10),
                new SqlParameter("@AM358",SqlDbType.Decimal,10),
                new SqlParameter("@AM359",SqlDbType.Decimal,10),
                new SqlParameter("@AM360",SqlDbType.Decimal,10),
                new SqlParameter("@AM361",SqlDbType.Decimal,10),
                new SqlParameter("@AM362",SqlDbType.Decimal,10),
                new SqlParameter("@AM363",SqlDbType.Decimal,10),
                new SqlParameter("@AM364",SqlDbType.Decimal,10),
                new SqlParameter("@AM365",SqlDbType.Decimal,10),
                new SqlParameter("@AM366",SqlDbType.Decimal,10),
                new SqlParameter("@AM367",SqlDbType.Decimal,10),
                new SqlParameter("@AM368",SqlDbType.Decimal,10),
                new SqlParameter("@AM369",SqlDbType.Decimal,10),
                new SqlParameter("@AM370",SqlDbType.Decimal,10),
                new SqlParameter("@AM371",SqlDbType.Decimal,10),
                new SqlParameter("@AM372",SqlDbType.Decimal,10),
                new SqlParameter("@AM373",SqlDbType.Decimal,10),
                new SqlParameter("@AM374",SqlDbType.Decimal,10),
                new SqlParameter("@AM375",SqlDbType.Decimal,10),
                new SqlParameter("@AM376",SqlDbType.Decimal,10),
                new SqlParameter("@AM377",SqlDbType.Decimal,10),
                new SqlParameter("@AM378",SqlDbType.Decimal,10),
                new SqlParameter("@AM379",SqlDbType.Decimal,10),
                new SqlParameter("@AM380",SqlDbType.Decimal,10),
                new SqlParameter("@AM381",SqlDbType.Decimal,10),
                new SqlParameter("@AM382",SqlDbType.Decimal,10),
                new SqlParameter("@AM383",SqlDbType.Decimal,10),
                new SqlParameter("@AM385",SqlDbType.Decimal,10),
                new SqlParameter("@AM386",SqlDbType.Decimal,10),
                new SqlParameter("@AM387",SqlDbType.Decimal,10),
                new SqlParameter("@AM388",SqlDbType.Decimal,10),
                new SqlParameter("@AM389",SqlDbType.Decimal,10),
                new SqlParameter("@AM390",SqlDbType.Decimal,10),
                new SqlParameter("@AM391",SqlDbType.Decimal,10),
                new SqlParameter("@AM392",SqlDbType.Decimal,10),
                new SqlParameter("@AM393",SqlDbType.Decimal,10),
                new SqlParameter("@AM020",SqlDbType.Decimal,10),
                new SqlParameter("@AM021",SqlDbType.Decimal,10),
                new SqlParameter("@AM022",SqlDbType.Decimal,10),
                new SqlParameter("@AM023",SqlDbType.Decimal,10),
                new SqlParameter("@AM024",SqlDbType.Decimal,10),
                new SqlParameter("@AM025",SqlDbType.Decimal,10),
                new SqlParameter("@AM026",SqlDbType.Decimal,10),
                new SqlParameter("@AM027",SqlDbType.Decimal,10),
                new SqlParameter("@AM028",SqlDbType.Decimal,10),
                new SqlParameter("@AM029",SqlDbType.Decimal,10),
                new SqlParameter("@AM173",SqlDbType.Decimal,10),
                new SqlParameter("@AM225",SqlDbType.Decimal,10),
                new SqlParameter("@AM226",SqlDbType.Decimal,10),
                new SqlParameter("@AM227",SqlDbType.Decimal,10),
                new SqlParameter("@AM228",SqlDbType.Decimal,10),
                new SqlParameter("@AM229",SqlDbType.Decimal,10),
                new SqlParameter("@AM230",SqlDbType.Decimal,10),
                new SqlParameter("@AM231",SqlDbType.Decimal,10),
                new SqlParameter("@AM232",SqlDbType.Decimal,10),
                new SqlParameter("@AM233",SqlDbType.Decimal,10),
                new SqlParameter("@AM234",SqlDbType.Decimal,10),
                new SqlParameter("@AM235",SqlDbType.Decimal,10),
                new SqlParameter("@AM236",SqlDbType.Decimal,10),
                new SqlParameter("@AM237",SqlDbType.Decimal,10),
                new SqlParameter("@AM238",SqlDbType.Decimal,10),
                new SqlParameter("@AM255",SqlDbType.Decimal,10),
                new SqlParameter("@AM256",SqlDbType.Decimal,10),
                new SqlParameter("@AM153",SqlDbType.Decimal,10),
                new SqlParameter("@AM154",SqlDbType.Decimal,10),
                new SqlParameter("@AM155",SqlDbType.Decimal,10),
                new SqlParameter("@AM156",SqlDbType.Decimal,10),
                new SqlParameter("@AM157",SqlDbType.Decimal,10),
                new SqlParameter("@AM158",SqlDbType.Decimal,10),
                new SqlParameter("@AM248",SqlDbType.Decimal,10),
                new SqlParameter("@AM062",SqlDbType.Decimal,10),
                new SqlParameter("@AM063",SqlDbType.Decimal,10)
            };
            parameter[0].Value = model.AM001;
            parameter[1].Value = model.AM002;
            parameter[2].Value = model.AM003;
            parameter[3].Value = model.AM004;
            parameter[4].Value = model.AM005;
            parameter[5].Value = model.AM006;
            parameter[6].Value = model.AM007;
            parameter[7].Value = model.AM008;
            parameter[8].Value = model.AM009;
            parameter[9].Value = model.AM010;
            parameter[10].Value = model.AM011;
            parameter[11].Value = model.AM012;
            parameter[12].Value = model.AM013;
            parameter[13].Value = model.AM014;
            parameter[14].Value = model.AM015;
            parameter[15].Value = model.AM016;
            parameter[16].Value = model.AM017;
            parameter[17].Value = model.AM018;
            parameter[18].Value = model.AM019;
            parameter[19].Value = model.AM044;
            parameter[20].Value = model.AM045;
            parameter[21].Value = model.AM046;
            parameter[22].Value = model.AM047;
            parameter[23].Value = model.AM048;
            parameter[24].Value = model.AM049;
            parameter[25].Value = model.AM050;
            parameter[26].Value = model.AM051;
            parameter[27].Value = model.AM052;
            parameter[28].Value = model.AM053;
            parameter[29].Value = model.AM054;
            parameter[30].Value = model.AM055;
            parameter[31].Value = model.AM056;
            parameter[32].Value = model.AM057;
            parameter[33].Value = model.AM058;
            parameter[34].Value = model.AM059;
            parameter[35].Value = model.AM060;
            parameter[36].Value = model.AM061;
            parameter[37].Value = model.AM070;
            parameter[38].Value = model.AM071;
            parameter[39].Value = model.AM072;
            parameter[40].Value = model.AM073;
            parameter[41].Value = model.AM074;
            parameter[42].Value = model.AM075;
            parameter[43].Value = model.AM076;
            parameter[44].Value = model.AM077;
            parameter[45].Value = model.AM078;
            parameter[46].Value = model.AM079;
            parameter[47].Value = model.AM080;
            parameter[48].Value = model.AM081;
            parameter[49].Value = model.AM082;
            parameter[50].Value = model.AM083;
            parameter[51].Value = model.AM084;
            parameter[52].Value = model.AM085;
            parameter[53].Value = model.AM086;
            parameter[54].Value = model.AM087;
            parameter[55].Value = model.AM088;
            parameter[56].Value = model.AM089;
            parameter[57].Value = model.AM090;
            parameter[58].Value = model.AM091;
            parameter[59].Value = model.AM092;
            parameter[60].Value = model.AM093;
            parameter[61].Value = model.AM108;
            parameter[62].Value = model.AM109;
            parameter[63].Value = model.AM110;
            parameter[64].Value = model.AM111;
            parameter[65].Value = model.AM112;
            parameter[66].Value = model.AM113;
            parameter[67].Value = model.AM130;
            parameter[68].Value = model.AM131;
            parameter[69].Value = model.AM133;
            parameter[70].Value = model.AM134;
            parameter[71].Value = model.AM135;
            parameter[72].Value = model.AM136;
            parameter[73].Value = model.AM137;
            parameter[74].Value = model.AM138;
            parameter[75].Value = model.AM139;
            parameter[76].Value = model.AM140;
            parameter[77].Value = model.AM141;
            parameter[78].Value = model.AM142;
            parameter[79].Value = model.AM143;
            parameter[80].Value = model.AM144;
            parameter[81].Value = model.AM145;
            parameter[82].Value = model.AM146;
            parameter[83].Value = model.AM147;
            parameter[84].Value = model.AM148;
            parameter[85].Value = model.AM149;
            parameter[86].Value = model.AM150;
            parameter[87].Value = model.AM151;
            parameter[88].Value = model.AM152;
            parameter[89].Value = model.AM175;
            parameter[90].Value = model.AM176;
            parameter[91].Value = model.AM177;
            parameter[92].Value = model.AM178;
            parameter[93].Value = model.AM179;
            parameter[94].Value = model.AM180;
            parameter[95].Value = model.AM182;
            parameter[96].Value = model.AM183;
            parameter[97].Value = model.AM184;
            parameter[98].Value = model.AM185;
            parameter[99].Value = model.AM186;
            parameter[100].Value = model.AM187;
            parameter[101].Value = model.AM188;
            parameter[102].Value = model.AM189;
            parameter[103].Value = model.AM190;
            parameter[104].Value = model.AM191;
            parameter[105].Value = model.AM192;
            parameter[106].Value = model.AM193;
            parameter[107].Value = model.AM194;
            parameter[108].Value = model.AM195;
            parameter[109].Value = model.AM196;
            parameter[110].Value = model.AM197;
            parameter[111].Value = model.AM198;
            parameter[112].Value = model.AM199;
            parameter[113].Value = model.AM200;
            parameter[114].Value = model.AM201;
            parameter[115].Value = model.AM203;
            parameter[116].Value = model.AM204;
            parameter[117].Value = model.AM205;
            parameter[118].Value = model.AM206;
            parameter[119].Value = model.AM207;
            parameter[120].Value = model.AM208;
            parameter[121].Value = model.AM209;
            parameter[122].Value = model.AM210;
            parameter[123].Value = model.AM211;
            parameter[124].Value = model.AM212;
            parameter[125].Value = model.AM213;
            parameter[126].Value = model.AM214;
            parameter[127].Value = model.AM215;
            parameter[128].Value = model.AM216;
            parameter[129].Value = model.AM217;
            parameter[130].Value = model.AM218;
            parameter[131].Value = model.AM219;
            parameter[132].Value = model.AM220;
            parameter[133].Value = model.AM221;
            parameter[134].Value = model.AM222;
            parameter[135].Value = model.AM223;
            parameter[136].Value = model.AM224;
            parameter[137].Value = model.AM239;
            parameter[138].Value = model.AM240;
            parameter[139].Value = model.AM241;
            parameter[140].Value = model.AM242;
            parameter[141].Value = model.AM243;
            parameter[142].Value = model.AM244;
            parameter[143].Value = model.AM245;
            parameter[144].Value = model.AM246;
            parameter[145].Value = model.AM247;
            //parameter[146].Value = model.AM248;
            parameter[146].Value = model.AM249;
            parameter[147].Value = model.AM250;
            parameter[148].Value = model.AM251;
            parameter[149].Value = model.AM252;
            parameter[150].Value = model.AM253;
            parameter[151].Value = model.AM261;
            parameter[152].Value = model.AM262;
            parameter[153].Value = model.AM263;
            parameter[154].Value = model.AM264;
            parameter[155].Value = model.AM265;
            parameter[156].Value = model.AM266;
            parameter[157].Value = model.AM267;
            parameter[158].Value = model.AM268;
            parameter[159].Value = model.AM269;
            parameter[160].Value = model.AM270;
            parameter[161].Value = model.AM271;
            parameter[162].Value = model.AM272;
            parameter[163].Value = model.AM273;
            parameter[164].Value = model.AM274;
            parameter[165].Value = model.AM275;
            parameter[166].Value = model.AM277;
            parameter[167].Value = model.AM278;
            parameter[168].Value = model.AM279;
            parameter[169].Value = model.AM280;
            parameter[170].Value = model.AM281;
            parameter[171].Value = model.AM282;
            parameter[172].Value = model.AM283;
            parameter[173].Value = model.AM284;
            parameter[174].Value = model.AM285;
            parameter[175].Value = model.AM286;
            parameter[176].Value = model.AM287;
            parameter[177].Value = model.AM288;
            parameter[178].Value = model.AM289;
            parameter[179].Value = model.AM290;
            parameter[180].Value = model.AM291;
            parameter[181].Value = model.AM292;
            parameter[182].Value = model.AM293;
            parameter[183].Value = model.AM294;
            parameter[184].Value = model.AM295;
            parameter[185].Value = model.AM296;
            parameter[186].Value = model.AM297;
            parameter[187].Value = model.AM298;
            parameter[188].Value = model.AM299;
            parameter[189].Value = model.AM300;
            parameter[190].Value = model.AM301;
            parameter[191].Value = model.AM302;
            parameter[192].Value = model.AM303;
            parameter[193].Value = model.AM304;
            parameter[194].Value = model.AM305;
            parameter[195].Value = model.AM306;
            parameter[196].Value = model.AM307;
            parameter[197].Value = model.AM308;
            parameter[198].Value = model.AM309;
            parameter[199].Value = model.AM311;
            parameter[200].Value = model.AM312;
            parameter[201].Value = model.AM313;
            //parameter[203].Value = model.AM314;
            parameter[202].Value = model.AM315;
            parameter[203].Value = model.AM316;
            parameter[204].Value = model.AM317;
            parameter[205].Value = model.AM318;
            parameter[206].Value = model.AM319;
            parameter[207].Value = model.AM320;
            parameter[208].Value = model.AM321;
            parameter[209].Value = model.AM322;
            parameter[210].Value = model.AM323;
            parameter[211].Value = model.AM324;
            parameter[212].Value = model.AM325;
            parameter[213].Value = model.AM326;
            parameter[214].Value = model.AM327;
            parameter[215].Value = model.AM328;
            parameter[216].Value = model.AM329;
            parameter[217].Value = model.AM330;
            parameter[218].Value = model.AM331;
            parameter[219].Value = model.AM332;
            parameter[220].Value = model.AM333;
            parameter[221].Value = model.AM334;
            parameter[222].Value = model.AM335;
            parameter[223].Value = model.AM336;
            parameter[224].Value = model.AM337;
            parameter[225].Value = model.AM338;
            parameter[226].Value = model.AM339;
            parameter[227].Value = model.AM340;
            parameter[228].Value = model.AM341;
            parameter[229].Value = model.AM343;
            parameter[230].Value = model.AM344;
            parameter[231].Value = model.AM345;
            parameter[232].Value = model.AM346;
            parameter[233].Value = model.AM347;
            parameter[234].Value = model.AM348;
            parameter[235].Value = model.AM349;
            parameter[236].Value = model.AM350;
            parameter[237].Value = model.AM351;
            parameter[238].Value = model.AM352;
            parameter[239].Value = model.AM353;
            parameter[240].Value = model.AM354;
            parameter[241].Value = model.AM355;
            parameter[242].Value = model.AM356;
            parameter[243].Value = model.AM357;
            parameter[244].Value = model.AM358;
            parameter[245].Value = model.AM359;
            parameter[246].Value = model.AM360;
            parameter[247].Value = model.AM361;
            parameter[248].Value = model.AM362;
            parameter[249].Value = model.AM363;
            parameter[250].Value = model.AM364;
            parameter[251].Value = model.AM365;
            parameter[252].Value = model.AM366;
            parameter[253].Value = model.AM367;
            parameter[254].Value = model.AM368;
            parameter[255].Value = model.AM369;
            parameter[256].Value = model.AM370;
            parameter[257].Value = model.AM371;
            parameter[258].Value = model.AM372;
            parameter[259].Value = model.AM373;
            parameter[260].Value = model.AM374;
            parameter[261].Value = model.AM375;
            parameter[262].Value = model.AM376;
            parameter[263].Value = model.AM377;
            parameter[264].Value = model.AM378;
            parameter[265].Value = model.AM379;
            parameter[266].Value = model.AM380;
            parameter[267].Value = model.AM381;
            parameter[268].Value = model.AM382;
            parameter[269].Value = model.AM383;
            parameter[270].Value = model.AM385;
            parameter[271].Value = model.AM386;
            parameter[272].Value = model.AM387;
            parameter[273].Value = model.AM388;
            parameter[274].Value = model.AM389;
            parameter[275].Value = model.AM390;
            parameter[276].Value = model.AM391;
            parameter[277].Value = model.AM392;
            parameter[278].Value = model.AM393;
            parameter[279].Value = model.AM020;
            parameter[280].Value = model.AM021;
            parameter[281].Value = model.AM022;
            parameter[282].Value = model.AM023;
            parameter[283].Value = model.AM024;
            parameter[284].Value = model.AM025;
            parameter[285].Value = model.AM026;
            parameter[286].Value = model.AM027;
            parameter[287].Value = model.AM028;
            parameter[288].Value = model.AM029;
            parameter [ 289 ] . Value = model . AM173;
            parameter [ 290 ] . Value = model . AM225;
            parameter [ 291 ] . Value = model . AM226;
            parameter [ 292 ] . Value = model . AM227;
            parameter [ 293 ] . Value = model . AM228;
            parameter [ 294 ] . Value = model . AM229;
            parameter [ 295 ] . Value = model . AM230;
            parameter [ 296 ] . Value = model . AM231;
            parameter [ 297 ] . Value = model . AM232;
            parameter [ 298 ] . Value = model . AM233;
            parameter [ 299 ] . Value = model . AM234;
            parameter [ 300 ] . Value = model . AM235;
            parameter [ 301 ] . Value = model . AM236;
            parameter [ 302 ] . Value = model . AM237;
            parameter [ 303 ] . Value = model . AM238;
            parameter [ 304 ] . Value = model . AM255;
            parameter [ 305 ] . Value = model . AM256;
            parameter [ 306 ] . Value = model . AM153;
            parameter [ 307 ] . Value = model . AM154;
            parameter [ 308 ] . Value = model . AM155;
            parameter [ 309 ] . Value = model . AM156;
            parameter [ 310 ] . Value = model . AM157;
            parameter [ 311 ] . Value = model . AM158;
            parameter [ 312 ] . Value = model . AM248;
            parameter [ 313 ] . Value = model . AM062;
            parameter [ 314 ] . Value = model . AM063;

            int idx = SqlHelper.ExecuteSqlReturnId( strSql.ToString( ) ,parameter );
            return idx;
        }
        DataTable dataTable ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT CONVERT(DECIMAL(18,1),SUM(ISNULL(AM262,0)+ISNULL(AM264,0)+ISNULL(AM266,0)+ISNULL(AM268,0)+ISNULL(AM269,0)+ISNULL(AM289,0)+ISNULL(AM291,0)+ISNULL(AM293,0)+ISNULL(AM295,0)+ISNULL(AM331,0)+ISNULL(AM334,0)+ISNULL(AM335,0)+ISNULL(AM337,0)+ISNULL(AM340,0)+ISNULL(AM341,0)+ISNULL(AM344,0)+ISNULL(AM347,0)+ISNULL(AM348,0)+ISNULL(AM350,0)+ISNULL(AM353,0)+ISNULL(AM354,0)+ISNULL(AM356,0)+ISNULL(AM359,0)+ISNULL(AM360,0)+ISNULL(AM362,0)+ISNULL(AM365,0)+ISNULL(AM366,0)+ISNULL(AM368,0)+ISNULL(AM371,0)+ISNULL(AM372,0)+ISNULL(AM374,0)+ISNULL(AM377,0)+ISNULL(AM378,0)+ISNULL(AM380,0)+ISNULL(AM383,0)+ISNULL(AM386,0)+ISNULL(AM387,0)+ISNULL(AM389,0)+ISNULL(AM392,0)+ISNULL(AM393,0)+ISNULL(AM299,0)+ISNULL(AM302,0)+ISNULL(AM305,0)+ISNULL(AM308,0)+ISNULL(AM312,0)+ISNULL(AM316,0)+ISNULL(AM319,0)+ISNULL(AM322,0)+ISNULL(AM303,0)+ISNULL(AM309,0)+ISNULL(AM317,0)+ISNULL(AM323,0)+ISNULL(AM325,0)+ISNULL(AM327,0)+ISNULL(AM329,0)+ISNULL(AM297,0)+ISNULL(AM271,0)+ISNULL(AM274,0)+ISNULL(AM275,0)+ISNULL(AM278,0)+ISNULL(AM281,0)+ISNULL(AM282,0)+ISNULL(AM284,0)+ISNULL(AM286,0)+ISNULL(AM243,0)+ISNULL(AM246,0)+ISNULL(AM250,0)+ISNULL(AM251,0)+ISNULL(AM253,0)+ISNULL(AM210,0)+ISNULL(AM213,0)+ISNULL(AM214,0)+ISNULL(AM216,0)+ISNULL(AM219,0)+ISNULL(AM220,0)+ISNULL(AM222,0)+ISNULL(AM224,0)+ISNULL(AM176,0)+ISNULL(AM179,0)+ISNULL(AM180,0)+ISNULL(AM183,0)+ISNULL(AM186,0)+ISNULL(AM187,0)+ISNULL(AM189,0)+ISNULL(AM192,0)+ISNULL(AM193,0)+ISNULL(AM195,0)+ISNULL(AM198,0)+ISNULL(AM199,0)+ISNULL(AM201,0)+ISNULL(AM204,0)+ISNULL(AM206,0)+ISNULL(AM208,0)+ISNULL(AM137,0)+ISNULL(AM140,0)+ISNULL(AM143,0)+ISNULL(AM146,0)+ISNULL(AM149,0)+ISNULL(AM141,0)+ISNULL(AM147,0)+ISNULL(AM135,0)+ISNULL(AM134,0)+ISNULL(AM131,0)+ISNULL(AM109,0)+ISNULL(AM112,0)+ISNULL(AM071,0)+ISNULL(AM073,0)+ISNULL(AM075,0)+ISNULL(AM077,0)+ISNULL(AM079,0)+ISNULL(AM081,0)+ISNULL(AM083,0)+ISNULL(AM085,0)+ISNULL(AM087,0)+ISNULL(AM089,0)+ISNULL(AM091,0)+ISNULL(AM093,0)+ISNULL(AM045,0)+ISNULL(AM047,0)+ISNULL(AM049,0)+ISNULL(AM051,0)+ISNULL(AM053,0)+ISNULL(AM055,0)+ISNULL(AM057,0)+ISNULL(AM059,0)+ISNULL(AM061,0)+ISNULL(AM063,0)+ISNULL(AM021,0)+ISNULL(AM023,0)+ISNULL(AM025,0)+ISNULL(AM027,0)+ISNULL(AM029,0)+ISNULL(AM113,0)+ISNULL(AM116,0)+ISNULL(AM226,0)+ISNULL(AM228,0)+ISNULL(AM230,0)+ISNULL(AM232,0)+ISNULL(AM234,0)+ISNULL(AM236,0)+ISNULL(AM238,0)+ISNULL(AM256,0)+ISNULL(AM154,0)+ISNULL(AM156,0)+ISNULL(AM157,0)+ISNULL(AM158,0))) U16  FROM R_PQAM" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public bool UpdateOfRpqbb ( )
        {
            DataTable da = dataTable( );
            if ( da != null && da.Rows.Count > 0 )
            {
                StringBuilder strSql = new StringBuilder( );
                strSql.Append( "UPDATE R_PQBB SET " );
                strSql.Append( "BB002=@BB002," );
                strSql.Append( "BB003=@BB003" );
                SqlParameter[] para = {
                        new SqlParameter("@BB002",SqlDbType.Date),
                        new SqlParameter("@BB003",SqlDbType.Decimal)
                    };
                para[0].Value = MulaolaoBll . Drity . GetDt ( );
                para[1].Value = string.IsNullOrEmpty( da.Rows[0]["U16"].ToString( ) ) == true ? 0 : Convert.ToDecimal( da.Rows[0]["U16"].ToString( ) );

                int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,para );
                if ( row > 0 )
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        public bool UpdateAgent ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            strSql.Append( "AM020=@AM020," );
            strSql.Append( "AM021=@AM021," );
            strSql.Append( "AM022=@AM022," );
            strSql.Append( "AM023=@AM023," );
            strSql.Append( "AM024=@AM024," );
            strSql.Append( "AM025=@AM025," );
            strSql.Append( "AM026=@AM026," );
            strSql.Append( "AM027=@AM027," );
            strSql.Append( "AM028=@AM028," );
            strSql.Append( "AM029=@AM029" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@AM020",SqlDbType.Decimal,10),
                new SqlParameter("@AM021",SqlDbType.Decimal,10),
                new SqlParameter("@AM022",SqlDbType.Decimal,10),
                new SqlParameter("@AM023",SqlDbType.Decimal,10),
                new SqlParameter("@AM024",SqlDbType.Decimal,10),
                new SqlParameter("@AM025",SqlDbType.Decimal,10),
                new SqlParameter("@AM026",SqlDbType.Decimal,10),
                new SqlParameter("@AM027",SqlDbType.Decimal,10),
                new SqlParameter("@AM028",SqlDbType.Decimal,10),
                new SqlParameter("@AM029",SqlDbType.Decimal,10),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = model.AM020;
            parameter[1].Value = model.AM021;
            parameter[2].Value = model.AM022;
            parameter[3].Value = model.AM023;
            parameter[4].Value = model.AM024;
            parameter[5].Value = model.AM025;
            parameter[6].Value = model.AM026;
            parameter[7].Value = model.AM027;
            parameter[8].Value = model.AM028;
            parameter[9].Value = model.AM029;
            parameter[10].Value = model.Idx;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }
        public bool ProductBeforeAndAfterRoadWages ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            strSql.Append( "AM044=@AM044," );
            strSql.Append( "AM045=@AM045," );
            strSql.Append( "AM046=@AM046," );
            strSql.Append( "AM047=@AM047," );
            strSql.Append( "AM048=@AM048," );
            strSql.Append( "AM049=@AM049," );
            strSql.Append( "AM050=@AM050," );
            strSql.Append( "AM051=@AM051," );
            strSql.Append( "AM052=@AM052," );
            strSql.Append( "AM053=@AM053," );
            strSql.Append( "AM054=@AM054," );
            strSql.Append( "AM055=@AM055," );
            strSql.Append( "AM056=@AM056," );
            strSql.Append( "AM057=@AM057," );
            strSql.Append( "AM058=@AM058," );
            strSql.Append( "AM059=@AM059," );
            strSql.Append( "AM060=@AM060," );
            strSql.Append( "AM061=@AM061," );
            strSql.Append( "AM062=@AM062," );
            strSql.Append( "AM063=@AM063" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@AM044",SqlDbType.Decimal,10),
                new SqlParameter("@AM045",SqlDbType.Decimal,10),
                new SqlParameter("@AM046",SqlDbType.Decimal,10),
                new SqlParameter("@AM047",SqlDbType.Decimal,10),
                new SqlParameter("@AM048",SqlDbType.Decimal,10),
                new SqlParameter("@AM049",SqlDbType.Decimal,10),
                new SqlParameter("@AM050",SqlDbType.Decimal,10),
                new SqlParameter("@AM051",SqlDbType.Decimal,10),
                new SqlParameter("@AM052",SqlDbType.Decimal,10),
                new SqlParameter("@AM053",SqlDbType.Decimal,10),
                new SqlParameter("@AM054",SqlDbType.Decimal,10),
                new SqlParameter("@AM055",SqlDbType.Decimal,10),
                new SqlParameter("@AM056",SqlDbType.Decimal,10),
                new SqlParameter("@AM057",SqlDbType.Decimal,10),
                new SqlParameter("@AM058",SqlDbType.Decimal,10),
                new SqlParameter("@AM059",SqlDbType.Decimal,10),
                new SqlParameter("@AM060",SqlDbType.Decimal,10),
                new SqlParameter("@AM061",SqlDbType.Decimal,10),
                new SqlParameter("@AM062",SqlDbType.Decimal,10),
                new SqlParameter("@AM063",SqlDbType.Decimal,10),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = model.AM044;
            parameter[1].Value = model.AM045;
            parameter[2].Value = model.AM046;
            parameter[3].Value = model.AM047;
            parameter[4].Value = model.AM048;
            parameter[5].Value = model.AM049;
            parameter[6].Value = model.AM050;
            parameter[7].Value = model.AM051;
            parameter[8].Value = model.AM052;
            parameter[9].Value = model.AM053;
            parameter[10].Value = model.AM054;
            parameter[11].Value = model.AM055;
            parameter[12].Value = model.AM056;
            parameter[13].Value = model.AM057;
            parameter[14].Value = model.AM058;
            parameter[15].Value = model.AM059;
            parameter[16].Value = model.AM060;
            parameter[17].Value = model.AM061;
            parameter[18].Value = model.AM062;
            parameter[19].Value = model.AM063;
            parameter[20].Value = model.Idx;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }
        public bool ContractProcess ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            strSql.Append( "AM070=@AM070," );
            strSql.Append( "AM071=@AM071," );
            strSql.Append( "AM072=@AM072," );
            strSql.Append( "AM073=@AM073," );
            strSql.Append( "AM074=@AM074," );
            strSql.Append( "AM075=@AM075," );
            strSql.Append( "AM076=@AM076," );
            strSql.Append( "AM077=@AM077," );
            strSql.Append( "AM078=@AM078," );
            strSql.Append( "AM079=@AM079," );
            strSql.Append( "AM080=@AM080," );
            strSql.Append( "AM081=@AM081," );
            strSql.Append( "AM082=@AM082," );
            strSql.Append( "AM083=@AM083," );
            strSql.Append( "AM084=@AM084," );
            strSql.Append( "AM085=@AM085," );
            strSql.Append( "AM086=@AM086," );
            strSql.Append( "AM087=@AM087," );
            strSql.Append( "AM088=@AM088," );
            strSql.Append( "AM089=@AM089," );
            strSql.Append( "AM090=@AM090," );
            strSql.Append( "AM091=@AM092," );
            strSql.Append( "AM092=@AM092," );
            strSql.Append( "AM093=@AM093" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@AM070",SqlDbType.Decimal,10),
                new SqlParameter("@AM071",SqlDbType.Decimal,10),
                new SqlParameter("@AM072",SqlDbType.Decimal,10),
                new SqlParameter("@AM073",SqlDbType.Decimal,10),
                new SqlParameter("@AM074",SqlDbType.Decimal,10),
                new SqlParameter("@AM075",SqlDbType.Decimal,10),
                new SqlParameter("@AM076",SqlDbType.Decimal,10),
                new SqlParameter("@AM077",SqlDbType.Decimal,10),
                new SqlParameter("@AM078",SqlDbType.Decimal,10),
                new SqlParameter("@AM079",SqlDbType.Decimal,10),
                new SqlParameter("@AM080",SqlDbType.Decimal,10),
                new SqlParameter("@AM081",SqlDbType.Decimal,10),
                new SqlParameter("@AM082",SqlDbType.Decimal,10),
                new SqlParameter("@AM083",SqlDbType.Decimal,10),
                new SqlParameter("@AM084",SqlDbType.Decimal,10),
                new SqlParameter("@AM085",SqlDbType.Decimal,10),
                new SqlParameter("@AM086",SqlDbType.Decimal,10),
                new SqlParameter("@AM087",SqlDbType.Decimal,10),
                new SqlParameter("@AM088",SqlDbType.Decimal,10),
                new SqlParameter("@AM089",SqlDbType.Decimal,10),
                new SqlParameter("@AM090",SqlDbType.Decimal,10),
                new SqlParameter("@AM091",SqlDbType.Decimal,10),
                new SqlParameter("@AM092",SqlDbType.Decimal,10),
                new SqlParameter("@AM093",SqlDbType.Decimal,10),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = model.AM070;
            parameter[1].Value = model.AM071;
            parameter[2].Value = model.AM072;
            parameter[3].Value = model.AM073;
            parameter[4].Value = model.AM074;
            parameter[5].Value = model.AM075;
            parameter[6].Value = model.AM076;
            parameter[7].Value = model.AM077;
            parameter[8].Value = model.AM078;
            parameter[9].Value = model.AM079;
            parameter[10].Value = model.AM080;
            parameter[11].Value = model.AM081;
            parameter[12].Value = model.AM082;
            parameter[13].Value = model.AM083;
            parameter[14].Value = model.AM084;
            parameter[15].Value = model.AM085;
            parameter[16].Value = model.AM086;
            parameter[17].Value = model.AM087;
            parameter[18].Value = model.AM088;
            parameter[19].Value = model.AM089;
            parameter[20].Value = model.AM090;
            parameter[21].Value = model.AM091;
            parameter[22].Value = model.AM092;
            parameter[23].Value = model.AM093;
            parameter[24].Value = model.Idx;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }
        public bool FinishedProductOutsourcing ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            strSql.Append( "AM108=@AM108," );
            strSql.Append( "AM109=@AM109," );
            strSql.Append( "AM110=@AM110," );
            strSql.Append( "AM111=@AM111," );
            strSql.Append( "AM112=@AM112," );
            strSql.Append( "AM113=@AM113," );
            strSql.Append( "AM115=@AM115," );
            strSql.Append( "AM116=@AM116" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@AM108",SqlDbType.Decimal,10),
                new SqlParameter("@AM109",SqlDbType.Decimal,10),
                new SqlParameter("@AM110",SqlDbType.Decimal,10),
                new SqlParameter("@AM111",SqlDbType.Decimal,10),
                new SqlParameter("@AM112",SqlDbType.Decimal,10),
                new SqlParameter("@AM113",SqlDbType.Decimal,10),
                new SqlParameter("@AM115",SqlDbType.Decimal,10),
                new SqlParameter("@AM116",SqlDbType.Decimal,10),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = model.AM108;
            parameter[1].Value = model.AM109;
            parameter[2].Value = model.AM110;
            parameter[3].Value = model.AM111;
            parameter[4].Value = model.AM112;
            parameter[5].Value = model.AM113;
            parameter[6].Value = model.AM115;
            parameter[7].Value = model.AM116;
            parameter[8].Value = model.Idx;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }
        public bool PackageMaterial ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            strSql.Append( "AM130=@AM130," );
            strSql.Append( "AM131=@AM131," );
            strSql.Append( "AM133=@AM133," );
            strSql.Append( "AM134=@AM134," );
            strSql.Append( "AM135=@AM135," );
            strSql.Append( "AM136=@AM136," );
            strSql.Append( "AM137=@AM137," );
            strSql.Append( "AM138=@AM138," );
            strSql.Append( "AM139=@AM139," );
            strSql.Append( "AM140=@AM140," );
            strSql.Append( "AM141=@AM141," );
            strSql.Append( "AM142=@AM142," );
            strSql.Append( "AM143=@AM143," );
            strSql.Append( "AM144=@AM144," );
            strSql.Append( "AM145=@AM145," );
            strSql.Append( "AM146=@AM146," );
            strSql.Append( "AM147=@AM147," );
            strSql.Append( "AM148=@AM148," );
            strSql.Append( "AM149=@AM149," );
            strSql.Append( "AM150=@AM150" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@AM136",SqlDbType.Decimal,10),
                new SqlParameter("@AM137",SqlDbType.Decimal,10),
                new SqlParameter("@AM138",SqlDbType.Decimal,10),
                new SqlParameter("@AM139",SqlDbType.Decimal,10),
                new SqlParameter("@AM140",SqlDbType.Decimal,10),
                new SqlParameter("@AM141",SqlDbType.Decimal,10),
                new SqlParameter("@AM142",SqlDbType.Decimal,10),
                new SqlParameter("@AM143",SqlDbType.Decimal,10),
                new SqlParameter("@AM144",SqlDbType.Decimal,10),
                new SqlParameter("@AM145",SqlDbType.Decimal,10),
                new SqlParameter("@AM146",SqlDbType.Decimal,10),
                new SqlParameter("@AM147",SqlDbType.Decimal,10),
                new SqlParameter("@AM148",SqlDbType.Decimal,10),
                new SqlParameter("@AM149",SqlDbType.Decimal,10),
                new SqlParameter("@AM150",SqlDbType.Decimal,10),
                new SqlParameter("@AM130",SqlDbType.Decimal,10),
                new SqlParameter("@AM131",SqlDbType.Decimal,10),
                new SqlParameter("@AM133",SqlDbType.Decimal,10),
                new SqlParameter("@AM134",SqlDbType.Decimal,10),
                new SqlParameter("@AM135",SqlDbType.Decimal,10),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = model.AM136;
            parameter[1].Value = model.AM137;
            parameter[2].Value = model.AM138;
            parameter[3].Value = model.AM139;
            parameter[4].Value = model.AM140;
            parameter[5].Value = model.AM141;
            parameter[6].Value = model.AM142;
            parameter[7].Value = model.AM143;
            parameter[8].Value = model.AM144;
            parameter[9].Value = model.AM145;
            parameter[10].Value = model.AM146;
            parameter[11].Value = model.AM147;
            parameter[12].Value = model.AM148;
            parameter[13].Value = model.AM149;
            parameter[14].Value = model.AM150;
            parameter[15].Value = model.AM130;
            parameter[16].Value = model.AM131;
            parameter[17].Value = model.AM133;
            parameter[18].Value = model.AM134;
            parameter[19].Value = model.AM135;
            parameter[20].Value = model.Idx;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }
        public bool Paint ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            strSql.Append( "AM175=@AM175," );
            strSql.Append( "AM176=@AM176," );
            strSql.Append( "AM177=@AM177," );
            strSql.Append( "AM178=@AM178," );
            strSql.Append( "AM179=@AM179," );
            strSql.Append( "AM180=@AM180," );
            strSql.Append( "AM182=@AM182," );
            strSql.Append( "AM183=@AM183," );
            strSql.Append( "AM184=@AM184," );
            strSql.Append( "AM185=@AM185," );
            strSql.Append( "AM186=@AM186," );
            strSql.Append( "AM187=@AM187," );
            strSql.Append( "AM188=@AM188," );
            strSql.Append( "AM189=@AM189," );
            strSql.Append( "AM190=@AM190," );
            strSql.Append( "AM191=@AM191," );
            strSql.Append( "AM192=@AM192," );
            strSql.Append( "AM193=@AM193," );
            strSql.Append( "AM194=@AM194," );
            strSql.Append( "AM195=@AM195," );
            strSql.Append( "AM196=@AM196," );
            strSql.Append( "AM197=@AM197," );
            strSql.Append( "AM198=@AM198," );
            strSql.Append( "AM199=@AM199," );
            strSql.Append( "AM200=@AM200," );
            strSql.Append( "AM201=@AM201," );
            strSql.Append( "AM203=@AM203," );
            strSql.Append( "AM204=@AM204," );
            strSql.Append( "AM205=@AM205," );
            strSql.Append( "AM206=@AM206," );
            strSql.Append( "AM207=@AM207," );
            strSql.Append( "AM208=@AM208," );
            strSql . Append ( "AM173=@AM173" );
            strSql .Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@AM175",SqlDbType.Decimal,10),
                new SqlParameter("@AM176",SqlDbType.Decimal,10),
                new SqlParameter("@AM177",SqlDbType.Decimal,10),
                new SqlParameter("@AM178",SqlDbType.Decimal,10),
                new SqlParameter("@AM179",SqlDbType.Decimal,10),
                new SqlParameter("@AM180",SqlDbType.Decimal,10),
                new SqlParameter("@AM182",SqlDbType.Decimal,10),
                new SqlParameter("@AM183",SqlDbType.Decimal,10),
                new SqlParameter("@AM184",SqlDbType.Decimal,10),
                new SqlParameter("@AM185",SqlDbType.Decimal,10),
                new SqlParameter("@AM186",SqlDbType.Decimal,10),
                new SqlParameter("@AM187",SqlDbType.Decimal,10),
                new SqlParameter("@AM188",SqlDbType.Decimal,10),
                new SqlParameter("@AM189",SqlDbType.Decimal,10),
                new SqlParameter("@AM190",SqlDbType.Decimal,10),
                new SqlParameter("@AM191",SqlDbType.Decimal,10),
                new SqlParameter("@AM192",SqlDbType.Decimal,10),
                new SqlParameter("@AM193",SqlDbType.Decimal,10),
                new SqlParameter("@AM194",SqlDbType.Decimal,10),
                new SqlParameter("@AM195",SqlDbType.Decimal,10),
                new SqlParameter("@AM196",SqlDbType.Decimal,10),
                new SqlParameter("@AM197",SqlDbType.Decimal,10),
                new SqlParameter("@AM198",SqlDbType.Decimal,10),
                new SqlParameter("@AM199",SqlDbType.Decimal,10),
                new SqlParameter("@AM200",SqlDbType.Decimal,10),
                new SqlParameter("@AM201",SqlDbType.Decimal,10),
                new SqlParameter("@AM203",SqlDbType.Decimal,10),
                new SqlParameter("@AM204",SqlDbType.Decimal,10),
                new SqlParameter("@AM205",SqlDbType.Decimal,10),
                new SqlParameter("@AM206",SqlDbType.Decimal,10),
                new SqlParameter("@AM207",SqlDbType.Decimal,10),
                new SqlParameter("@AM208",SqlDbType.Decimal,10),
                new SqlParameter("@AM173",SqlDbType.Decimal,10),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = model.AM175;
            parameter[1].Value = model.AM176;
            parameter[2].Value = model.AM177;
            parameter[3].Value = model.AM178;
            parameter[4].Value = model.AM179;
            parameter[5].Value = model.AM180;
            parameter[6].Value = model.AM182;
            parameter[7].Value = model.AM183;
            parameter[8].Value = model.AM184;
            parameter[9].Value = model.AM185;
            parameter[10].Value = model.AM186;
            parameter[11].Value = model.AM187;
            parameter[12].Value = model.AM188;
            parameter[13].Value = model.AM189;
            parameter[14].Value = model.AM190;
            parameter[15].Value = model.AM191;
            parameter[16].Value = model.AM192;
            parameter[17].Value = model.AM193;
            parameter[18].Value = model.AM194;
            parameter[19].Value = model.AM195;
            parameter[20].Value = model.AM196;
            parameter[21].Value = model.AM197;
            parameter[22].Value = model.AM198;
            parameter[23].Value = model.AM199;
            parameter[24].Value = model.AM200;
            parameter[25].Value = model.AM201;
            parameter[26].Value = model.AM203;
            parameter[27].Value = model.AM204;
            parameter[28].Value = model.AM205;
            parameter[29].Value = model.AM206;
            parameter[30].Value = model.AM207;
            parameter[31].Value = model.AM208;
            parameter [ 32 ] . Value = model . AM173;
            parameter [33].Value = model.Idx;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }
        public bool Lron ( MulaolaoLibrary . ProductCostSummaryLibrary model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQAM SET " );
            strSql . Append ( "AM209=@AM209," );
            strSql . Append ( "AM210=@AM210," );
            strSql . Append ( "AM211=@AM211," );
            strSql . Append ( "AM212=@AM212," );
            strSql . Append ( "AM213=@AM213," );
            strSql . Append ( "AM214=@AM214," );
            strSql . Append ( "AM215=@AM215," );
            strSql . Append ( "AM216=@AM216," );
            strSql . Append ( "AM217=@AM217," );
            strSql . Append ( "AM218=@AM218," );
            strSql . Append ( "AM219=@AM219," );
            strSql . Append ( "AM220=@AM220," );
            strSql . Append ( "AM221=@AM221," );
            strSql . Append ( "AM222=@AM222," );
            strSql . Append ( "AM223=@AM223," );
            strSql . Append ( "AM224=@AM224," );
            strSql . Append ( "AM225=@AM225," );
            strSql . Append ( "AM226=@AM226," );
            strSql . Append ( "AM227=@AM227," );
            strSql . Append ( "AM228=@AM228," );
            strSql . Append ( "AM229=@AM229," );
            strSql . Append ( "AM230=@AM230," );
            strSql . Append ( "AM231=@AM231," );
            strSql . Append ( "AM232=@AM232," );
            strSql . Append ( "AM233=@AM233," );
            strSql . Append ( "AM234=@AM234," );
            strSql . Append ( "AM235=@AM235," );
            strSql . Append ( "AM236=@AM236," );
            strSql . Append ( "AM237=@AM237," );
            strSql . Append ( "AM238=@AM238," );
            strSql . Append ( "AM255=@AM255," );
            strSql . Append ( "AM256=@AM256" );
            strSql . Append ( " WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@AM209",SqlDbType.Decimal,10),
                new SqlParameter("@AM210",SqlDbType.Decimal,10),
                new SqlParameter("@AM211",SqlDbType.Decimal,10),
                new SqlParameter("@AM212",SqlDbType.Decimal,10),
                new SqlParameter("@AM213",SqlDbType.Decimal,10),
                new SqlParameter("@AM214",SqlDbType.Decimal,10),
                new SqlParameter("@AM215",SqlDbType.Decimal,10),
                new SqlParameter("@AM216",SqlDbType.Decimal,10),
                new SqlParameter("@AM217",SqlDbType.Decimal,10),
                new SqlParameter("@AM218",SqlDbType.Decimal,10),
                new SqlParameter("@AM219",SqlDbType.Decimal,10),
                new SqlParameter("@AM220",SqlDbType.Decimal,10),
                new SqlParameter("@AM221",SqlDbType.Decimal,10),
                new SqlParameter("@AM222",SqlDbType.Decimal,10),
                new SqlParameter("@AM223",SqlDbType.Decimal,10),
                new SqlParameter("@AM224",SqlDbType.Decimal,10),
                new SqlParameter("@AM225",SqlDbType.Decimal,10),
                new SqlParameter("@AM226",SqlDbType.Decimal,10),
                new SqlParameter("@AM227",SqlDbType.Decimal,10),
                new SqlParameter("@AM228",SqlDbType.Decimal,10),
                new SqlParameter("@AM229",SqlDbType.Decimal,10),
                new SqlParameter("@AM230",SqlDbType.Decimal,10),
                new SqlParameter("@AM231",SqlDbType.Decimal,10),
                new SqlParameter("@AM232",SqlDbType.Decimal,10),
                new SqlParameter("@AM233",SqlDbType.Decimal,10),
                new SqlParameter("@AM234",SqlDbType.Decimal,10),
                new SqlParameter("@AM235",SqlDbType.Decimal,10),
                new SqlParameter("@AM236",SqlDbType.Decimal,10),
                new SqlParameter("@AM237",SqlDbType.Decimal,10),
                new SqlParameter("@AM238",SqlDbType.Decimal,10),
                new SqlParameter("@AM255",SqlDbType.Decimal,10),
                new SqlParameter("@AM256",SqlDbType.Decimal,10),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter [ 0 ] . Value = model . AM209;
            parameter [ 1 ] . Value = model . AM210;
            parameter [ 2 ] . Value = model . AM211;
            parameter [ 3 ] . Value = model . AM212;
            parameter [ 4 ] . Value = model . AM213;
            parameter [ 5 ] . Value = model . AM214;
            parameter [ 6 ] . Value = model . AM215;
            parameter [ 7 ] . Value = model . AM216;
            parameter [ 8 ] . Value = model . AM217;
            parameter [ 9 ] . Value = model . AM218;
            parameter [ 10 ] . Value = model . AM219;
            parameter [ 11 ] . Value = model . AM220;
            parameter [ 12 ] . Value = model . AM221;
            parameter [ 13 ] . Value = model . AM222;
            parameter [ 14 ] . Value = model . AM223;
            parameter [ 15 ] . Value = model . AM224;
            parameter [ 16 ] . Value = model . AM225;
            parameter [ 17 ] . Value = model . AM226;
            parameter [ 18 ] . Value = model . AM227;
            parameter [ 19 ] . Value = model . AM228;
            parameter [ 20 ] . Value = model . AM229;
            parameter [ 21 ] . Value = model . AM230;
            parameter [ 22 ] . Value = model . AM231;
            parameter [ 23 ] . Value = model . AM232;
            parameter [ 24 ] . Value = model . AM233;
            parameter [ 25 ] . Value = model . AM234;
            parameter [ 26 ] . Value = model . AM235;
            parameter [ 27 ] . Value = model . AM236;
            parameter [ 28 ] . Value = model . AM237;
            parameter [ 29 ] . Value = model . AM238;
            parameter [ 30 ] . Value = model . AM255;
            parameter [ 31 ] . Value = model . AM256;
            parameter [ 32 ] . Value = model . Idx;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) , parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }
        public bool GunPaint ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            strSql.Append( "AM239=@AM239," );
            strSql.Append( "AM240=@AM240," );
            strSql.Append( "AM241=@AM241," );
            strSql.Append( "AM242=@AM242," );
            strSql.Append( "AM243=@AM243," );
            strSql.Append( "AM244=@AM244," );
            strSql.Append( "AM245=@AM245," );
            strSql.Append( "AM246=@AM246," );
            strSql.Append( "AM247=@AM247," );
            strSql.Append( "AM249=@AM249," );
            strSql.Append( "AM250=@AM250," );
            strSql.Append( "AM251=@AM251," );
            strSql.Append( "AM252=@AM252," );
            strSql.Append( "AM253=@AM253" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@AM239",SqlDbType.Decimal,10),
                new SqlParameter("@AM240",SqlDbType.Decimal,10),
                new SqlParameter("@AM241",SqlDbType.Decimal,10),
                new SqlParameter("@AM242",SqlDbType.Decimal,10),
                new SqlParameter("@AM243",SqlDbType.Decimal,10),
                new SqlParameter("@AM244",SqlDbType.Decimal,10),
                new SqlParameter("@AM245",SqlDbType.Decimal,10),
                new SqlParameter("@AM246",SqlDbType.Decimal,10),
                new SqlParameter("@AM247",SqlDbType.Decimal,10),
                new SqlParameter("@AM249",SqlDbType.Decimal,10),
                new SqlParameter("@AM250",SqlDbType.Decimal,10),
                new SqlParameter("@AM251",SqlDbType.Decimal,10),
                new SqlParameter("@AM252",SqlDbType.Decimal,10),
                new SqlParameter("@AM253",SqlDbType.Decimal,10),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = model.AM239;
            parameter[1].Value = model.AM240;
            parameter[2].Value = model.AM241;
            parameter[3].Value = model.AM242;
            parameter[4].Value = model.AM243;
            parameter[5].Value = model.AM244;
            parameter[6].Value = model.AM245;
            parameter[7].Value = model.AM246;
            parameter[8].Value = model.AM247;
            parameter[9].Value = model.AM249;
            parameter[10].Value = model.AM250;
            parameter[11].Value = model.AM251;
            parameter[12].Value = model.AM252;
            parameter[13].Value = model.AM253;
            parameter[14].Value = model.Idx;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }
        public bool VehicleWoodPieces ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            strSql.Append( "AM270=@AM270," );
            strSql.Append( "AM271=@AM271," );
            strSql.Append( "AM272=@AM272," );
            strSql.Append( "AM273=@AM273," );
            strSql.Append( "AM274=@AM274," );
            strSql.Append( "AM275=@AM275," );
            strSql.Append( "AM277=@AM277," );
            strSql.Append( "AM278=@AM278," );
            strSql.Append( "AM279=@AM279," );
            strSql.Append( "AM280=@AM280," );
            strSql.Append( "AM281=@AM281," );
            strSql.Append( "AM282=@AM282" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@AM270",SqlDbType.Decimal,10),
                new SqlParameter("@AM271",SqlDbType.Decimal,10),
                new SqlParameter("@AM272",SqlDbType.NChar,10),
                new SqlParameter("@AM273",SqlDbType.Decimal,10),
                new SqlParameter("@AM274",SqlDbType.Decimal,10),
                new SqlParameter("@AM275",SqlDbType.NChar,10),
                new SqlParameter("@AM277",SqlDbType.Decimal,10),
                new SqlParameter("@AM278",SqlDbType.Decimal,10),
                new SqlParameter("@AM279",SqlDbType.NChar,10),
                new SqlParameter("@AM280",SqlDbType.Decimal,10),
                new SqlParameter("@AM281",SqlDbType.Decimal,10),
                new SqlParameter("@AM282",SqlDbType.NChar,10),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = model.AM270;
            parameter[1].Value = model.AM271;
            parameter[2].Value = model.AM272;
            parameter[3].Value = model.AM273;
            parameter[4].Value = model.AM274;
            parameter[5].Value = model.AM275;
            parameter[6].Value = model.AM277;
            parameter[7].Value = model.AM278;
            parameter[8].Value = model.AM279;
            parameter[9].Value = model.AM280;
            parameter[10].Value = model.AM281;
            parameter[11].Value = model.AM282;
            parameter[12].Value = model.Idx;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }
        public bool Plywood ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            strSql.Append( "AM296=@AM296," );
            strSql.Append( "AM297=@AM297," );
            strSql.Append( "AM298=@AM298," );
            strSql.Append( "AM299=@AM299," );
            strSql.Append( "AM300=@AM300," );
            strSql.Append( "AM301=@AM301," );
            strSql.Append( "AM302=@AM302," );
            strSql.Append( "AM303=@AM303," );
            strSql.Append( "AM304=@AM304," );
            strSql.Append( "AM305=@AM305," );
            strSql.Append( "AM306=@AM306," );
            strSql.Append( "AM307=@AM307," );
            strSql.Append( "AM308=@AM308," );
            strSql.Append( "AM309=@AM309," );
            strSql.Append( "AM311=@AM311," );
            strSql.Append( "AM312=@AM312," );
            strSql.Append( "AM313=@AM313," );
            strSql.Append( "AM315=@AM315," );
            strSql.Append( "AM316=@AM316," );
            strSql.Append( "AM317=@AM317," );
            strSql.Append( "AM318=@AM318," );
            strSql.Append( "AM319=@AM319," );
            strSql.Append( "AM320=@AM320," );
            strSql.Append( "AM321=@AM321," );
            strSql.Append( "AM322=@AM322," );
            strSql.Append( "AM323=@AM323," );
            strSql.Append( "AM324=@AM324," );
            strSql.Append( "AM325=@AM325," );
            strSql.Append( "AM326=@AM326," );
            strSql.Append( "AM327=@AM327," );
            strSql.Append( "AM328=@AM328," );
            strSql.Append( "AM329=@AM329" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@AM298",SqlDbType.Decimal,10),
                new SqlParameter("@AM299",SqlDbType.Decimal,10),
                new SqlParameter("@AM300",SqlDbType.Decimal,10),
                new SqlParameter("@AM301",SqlDbType.Decimal,10),
                new SqlParameter("@AM302",SqlDbType.Decimal,10),
                new SqlParameter("@AM303",SqlDbType.Decimal,10),
                new SqlParameter("@AM304",SqlDbType.Decimal,10),
                new SqlParameter("@AM305",SqlDbType.Decimal,10),
                new SqlParameter("@AM306",SqlDbType.Decimal,10),
                new SqlParameter("@AM307",SqlDbType.Decimal,10),
                new SqlParameter("@AM308",SqlDbType.Decimal,10),
                new SqlParameter("@AM309",SqlDbType.Decimal,10),
                new SqlParameter("@AM311",SqlDbType.Decimal,10),
                new SqlParameter("@AM312",SqlDbType.Decimal,10),
                new SqlParameter("@AM313",SqlDbType.Decimal,10),
                new SqlParameter("@AM315",SqlDbType.Decimal,10),
                new SqlParameter("@AM316",SqlDbType.Decimal,10),
                new SqlParameter("@AM317",SqlDbType.Decimal,10),
                new SqlParameter("@AM318",SqlDbType.Decimal,10),
                new SqlParameter("@AM319",SqlDbType.Decimal,10),
                new SqlParameter("@AM320",SqlDbType.Decimal,10),
                new SqlParameter("@AM321",SqlDbType.Decimal,10),
                new SqlParameter("@AM322",SqlDbType.Decimal,10),
                new SqlParameter("@AM323",SqlDbType.Decimal,10),
                new SqlParameter("@AM324",SqlDbType.Decimal,10),
                new SqlParameter("@AM325",SqlDbType.Decimal,10),
                new SqlParameter("@AM326",SqlDbType.Decimal,10),
                new SqlParameter("@AM327",SqlDbType.Decimal,10),
                new SqlParameter("@AM328",SqlDbType.Decimal,10),
                new SqlParameter("@AM329",SqlDbType.Decimal,10),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = model.AM298;
            parameter[1].Value = model.AM299;
            parameter[2].Value = model.AM300;
            parameter[3].Value = model.AM301;
            parameter[4].Value = model.AM302;
            parameter[5].Value = model.AM303;
            parameter[6].Value = model.AM304;
            parameter[7].Value = model.AM305;
            parameter[8].Value = model.AM306;
            parameter[9].Value = model.AM307;
            parameter[10].Value = model.AM308;
            parameter[11].Value = model.AM309;
            parameter[12].Value = model.AM311;
            parameter[13].Value = model.AM312;
            parameter[14].Value = model.AM313;
            parameter[15].Value = model.AM315;
            parameter[16].Value = model.AM316;
            parameter[17].Value = model.AM317;
            parameter[18].Value = model.AM318;
            parameter[19].Value = model.AM319;
            parameter[20].Value = model.AM320;
            parameter[21].Value = model.AM321;
            parameter[22].Value = model.AM322;
            parameter[23].Value = model.AM323;
            parameter[24].Value = model.AM324;
            parameter[25].Value = model.AM325;
            parameter[26].Value = model.AM326;
            parameter[27].Value = model.AM327;
            parameter[28].Value = model.AM328;
            parameter[29].Value = model.AM329;
            parameter[30].Value = model.Idx;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }
        public bool Wood ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            strSql.Append( "AM261=@AM261," );
            strSql.Append( "AM262=@AM262," );
            strSql.Append( "AM263=@AM263," );
            strSql.Append( "AM264=@AM264," );
            strSql.Append( "AM265=@AM265," );
            strSql.Append( "AM266=@AM266," );
            strSql.Append( "AM267=@AM267," );
            strSql.Append( "AM268=@AM268," );
            strSql.Append( "AM269=@AM269," );
            strSql.Append( "AM287=@AM287," );
            strSql.Append( "AM288=@AM288," );
            strSql.Append( "AM289=@AM289," );
            strSql.Append( "AM290=@AM290," );
            strSql.Append( "AM291=@AM291," );
            strSql.Append( "AM292=@AM292," );
            strSql.Append( "AM293=@AM293," );
            strSql.Append( "AM294=@AM294," );
            strSql.Append( "AM295=@AM295," );
            strSql.Append( "AM330=@AM330," );
            strSql.Append( "AM331=@AM331," );
            strSql.Append( "AM332=@AM332," );
            strSql.Append( "AM333=@AM333," );
            strSql.Append( "AM334=@AM334," );
            strSql.Append( "AM335=@AM335," );
            strSql.Append( "AM336=@AM336," );
            strSql.Append( "AM337=@AM337," );
            strSql.Append( "AM338=@AM338," );
            strSql.Append( "AM339=@AM339," );
            strSql.Append( "AM340=@AM340," );
            strSql.Append( "AM341=@AM341," );
            strSql.Append( "AM343=@AM343," );
            strSql.Append( "AM344=@AM344," );
            strSql.Append( "AM345=@AM345," );
            strSql.Append( "AM346=@AM346," );
            strSql.Append( "AM347=@AM347," );
            strSql.Append( "AM348=@AM348," );
            strSql.Append( "AM349=@AM349," );
            strSql.Append( "AM350=@AM350," );
            strSql.Append( "AM351=@AM351," );
            strSql.Append( "AM352=@AM352," );
            strSql.Append( "AM353=@AM353," );
            strSql.Append( "AM354=@AM354," );
            strSql.Append( "AM355=@AM355," );
            strSql.Append( "AM356=@AM356," );
            strSql.Append( "AM357=@AM357," );
            strSql.Append( "AM358=@AM358," );
            strSql.Append( "AM359=@AM359," );
            strSql.Append( "AM360=@AM360," );
            strSql.Append( "AM361=@AM361," );
            strSql.Append( "AM362=@AM362," );
            strSql.Append( "AM363=@AM363," );
            strSql.Append( "AM364=@AM364," );
            strSql.Append( "AM365=@AM365," );
            strSql.Append( "AM366=@AM366," );
            strSql.Append( "AM367=@AM367," );
            strSql.Append( "AM368=@AM368," );
            strSql.Append( "AM369=@AM369," );
            strSql.Append( "AM370=@AM370," );
            strSql.Append( "AM371=@AM371," );
            strSql.Append( "AM372=@AM372," );
            strSql.Append( "AM373=@AM373," );
            strSql.Append( "AM374=@AM374," );
            strSql.Append( "AM375=@AM375," );
            strSql.Append( "AM376=@AM376," );
            strSql.Append( "AM377=@AM377," );
            strSql.Append( "AM378=@AM378," );
            strSql.Append( "AM379=@AM379," );
            strSql.Append( "AM380=@AM380," );
            strSql.Append( "AM381=@AM381," );
            strSql.Append( "AM385=@AM385," );
            strSql.Append( "AM386=@AM386," );
            strSql.Append( "AM387=@AM387," );
            strSql.Append( "AM388=@AM388," );
            strSql.Append( "AM389=@AM389," );
            strSql.Append( "AM390=@AM390," );
            strSql.Append( "AM391=@AM391," );
            strSql.Append( "AM392=@AM392," );
            strSql.Append( "AM393=@AM393" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@AM261",SqlDbType.Decimal,10),
                new SqlParameter("@AM262",SqlDbType.Decimal,10),
                new SqlParameter("@AM263",SqlDbType.Decimal,10),
                new SqlParameter("@AM264",SqlDbType.Decimal,10),
                new SqlParameter("@AM265",SqlDbType.Decimal,10),
                new SqlParameter("@AM266",SqlDbType.Decimal,10),
                new SqlParameter("@AM267",SqlDbType.Decimal,10),
                new SqlParameter("@AM268",SqlDbType.Decimal,10),
                new SqlParameter("@AM269",SqlDbType.Decimal,10),
                new SqlParameter("@AM287",SqlDbType.Decimal,10),
                new SqlParameter("@AM288",SqlDbType.Decimal,10),
                new SqlParameter("@AM289",SqlDbType.Decimal,10),
                new SqlParameter("@AM290",SqlDbType.Decimal,10),
                new SqlParameter("@AM291",SqlDbType.Decimal,10),
                new SqlParameter("@AM292",SqlDbType.Decimal,10),
                new SqlParameter("@AM293",SqlDbType.Decimal,10),
                new SqlParameter("@AM294",SqlDbType.Decimal,10),
                new SqlParameter("@AM295",SqlDbType.Decimal,10),
                new SqlParameter("@AM330",SqlDbType.Decimal,10),
                new SqlParameter("@AM331",SqlDbType.Decimal,10),
                new SqlParameter("@AM332",SqlDbType.Decimal,10),
                new SqlParameter("@AM333",SqlDbType.Decimal,10),
                new SqlParameter("@AM334",SqlDbType.Decimal,10),
                new SqlParameter("@AM335",SqlDbType.Decimal,10),
                new SqlParameter("@AM336",SqlDbType.Decimal,10),
                new SqlParameter("@AM337",SqlDbType.Decimal,10),
                new SqlParameter("@AM338",SqlDbType.Decimal,10),
                new SqlParameter("@AM339",SqlDbType.Decimal,10),
                new SqlParameter("@AM340",SqlDbType.Decimal,10),
                new SqlParameter("@AM341",SqlDbType.Decimal,10),
                new SqlParameter("@AM343",SqlDbType.Decimal,10),
                new SqlParameter("@AM344",SqlDbType.Decimal,10),
                new SqlParameter("@AM345",SqlDbType.Decimal,10),
                new SqlParameter("@AM346",SqlDbType.Decimal,10),
                new SqlParameter("@AM347",SqlDbType.Decimal,10),
                new SqlParameter("@AM348",SqlDbType.Decimal,10),
                new SqlParameter("@AM349",SqlDbType.Decimal,10),
                new SqlParameter("@AM350",SqlDbType.Decimal,10),
                new SqlParameter("@AM351",SqlDbType.Decimal,10),
                new SqlParameter("@AM352",SqlDbType.Decimal,10),
                new SqlParameter("@AM353",SqlDbType.Decimal,10),
                new SqlParameter("@AM354",SqlDbType.Decimal,10),
                new SqlParameter("@AM355",SqlDbType.Decimal,10),
                new SqlParameter("@AM356",SqlDbType.Decimal,10),
                new SqlParameter("@AM357",SqlDbType.Decimal,10),
                new SqlParameter("@AM358",SqlDbType.Decimal,10),
                new SqlParameter("@AM359",SqlDbType.Decimal,10),
                new SqlParameter("@AM360",SqlDbType.Decimal,10),
                new SqlParameter("@AM361",SqlDbType.Decimal,10),
                new SqlParameter("@AM362",SqlDbType.Decimal,10),
                new SqlParameter("@AM363",SqlDbType.Decimal,10),
                new SqlParameter("@AM364",SqlDbType.Decimal,10),
                new SqlParameter("@AM365",SqlDbType.Decimal,10),
                new SqlParameter("@AM366",SqlDbType.Decimal,10),
                new SqlParameter("@AM367",SqlDbType.Decimal,10),
                new SqlParameter("@AM368",SqlDbType.Decimal,10),
                new SqlParameter("@AM369",SqlDbType.Decimal,10),
                new SqlParameter("@AM370",SqlDbType.Decimal,10),
                new SqlParameter("@AM371",SqlDbType.Decimal,10),
                new SqlParameter("@AM372",SqlDbType.Decimal,10),
                new SqlParameter("@AM373",SqlDbType.Decimal,10),
                new SqlParameter("@AM374",SqlDbType.Decimal,10),
                new SqlParameter("@AM375",SqlDbType.Decimal,10),
                new SqlParameter("@AM376",SqlDbType.Decimal,10),
                new SqlParameter("@AM377",SqlDbType.Decimal,10),
                new SqlParameter("@AM378",SqlDbType.Decimal,10),
                new SqlParameter("@AM379",SqlDbType.Decimal,10),
                new SqlParameter("@AM380",SqlDbType.Decimal,10),
                new SqlParameter("@AM381",SqlDbType.Decimal,10),
                new SqlParameter("@AM382",SqlDbType.Decimal,10),
                new SqlParameter("@AM383",SqlDbType.Decimal,10),
                new SqlParameter("@AM385",SqlDbType.Decimal,10),
                new SqlParameter("@AM386",SqlDbType.Decimal,10),
                new SqlParameter("@AM387",SqlDbType.Decimal,10),
                new SqlParameter("@AM388",SqlDbType.Decimal,10),
                new SqlParameter("@AM389",SqlDbType.Decimal,10),
                new SqlParameter("@AM390",SqlDbType.Decimal,10),
                new SqlParameter("@AM391",SqlDbType.Decimal,10),
                new SqlParameter("@AM392",SqlDbType.Decimal,10),
                new SqlParameter("@AM393",SqlDbType.Decimal,10),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = model.AM261;
            parameter[1].Value = model.AM262;
            parameter[2].Value = model.AM263;
            parameter[3].Value = model.AM264;
            parameter[4].Value = model.AM265;
            parameter[5].Value = model.AM266;
            parameter[6].Value = model.AM267;
            parameter[7].Value = model.AM268;
            parameter[8].Value = model.AM269;
            parameter[9].Value = model.AM287;
            parameter[10].Value = model.AM288;
            parameter[11].Value = model.AM289;
            parameter[12].Value = model.AM290;
            parameter[13].Value = model.AM291;
            parameter[14].Value = model.AM292;
            parameter[15].Value = model.AM293;
            parameter[16].Value = model.AM294;
            parameter[17].Value = model.AM295;
            parameter[18].Value = model.AM330;
            parameter[19].Value = model.AM331;
            parameter[20].Value = model.AM332;
            parameter[21].Value = model.AM333;
            parameter[22].Value = model.AM334;
            parameter[23].Value = model.AM335;
            parameter[24].Value = model.AM336;
            parameter[25].Value = model.AM337;
            parameter[26].Value = model.AM338;
            parameter[27].Value = model.AM339;
            parameter[28].Value = model.AM340;
            parameter[29].Value = model.AM341;
            parameter[30].Value = model.AM343;
            parameter[31].Value = model.AM344;
            parameter[32].Value = model.AM345;
            parameter[33].Value = model.AM346;
            parameter[34].Value = model.AM347;
            parameter[35].Value = model.AM348;
            parameter[36].Value = model.AM349;
            parameter[37].Value = model.AM350;
            parameter[38].Value = model.AM351;
            parameter[39].Value = model.AM352;
            parameter[40].Value = model.AM353;
            parameter[41].Value = model.AM354;
            parameter[42].Value = model.AM355;
            parameter[43].Value = model.AM356;
            parameter[44].Value = model.AM357;
            parameter[45].Value = model.AM358;
            parameter[46].Value = model.AM359;
            parameter[47].Value = model.AM360;
            parameter[48].Value = model.AM361;
            parameter[49].Value = model.AM362;
            parameter[50].Value = model.AM363;
            parameter[51].Value = model.AM364;
            parameter[52].Value = model.AM365;
            parameter[53].Value = model.AM366;
            parameter[54].Value = model.AM367;
            parameter[55].Value = model.AM368;
            parameter[56].Value = model.AM369;
            parameter[57].Value = model.AM370;
            parameter[58].Value = model.AM371;
            parameter[59].Value = model.AM372;
            parameter[60].Value = model.AM373;
            parameter[61].Value = model.AM374;
            parameter[62].Value = model.AM375;
            parameter[63].Value = model.AM376;
            parameter[64].Value = model.AM377;
            parameter[65].Value = model.AM378;
            parameter[66].Value = model.AM379;
            parameter[67].Value = model.AM380;
            parameter[68].Value = model.AM381;
            parameter[69].Value = model.AM382;
            parameter[70].Value = model.AM383;
            parameter[71].Value = model.AM385;
            parameter[72].Value = model.AM386;
            parameter[73].Value = model.AM387;
            parameter[74].Value = model.AM388;
            parameter[75].Value = model.AM389;
            parameter[76].Value = model.AM390;
            parameter[77].Value = model.AM391;
            parameter[78].Value = model.AM392;
            parameter[79].Value = model.AM393;
            parameter[80].Value = model.Idx;
        
            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary . ProductCostSummaryLibrary model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQAM SET " );
            strSql . Append ( " AM001=@AM001," );
            strSql . Append ( " AM002=@AM002," );
            strSql . Append ( " AM003=@AM003," );
            strSql . Append ( " AM004=@AM004," );
            strSql . Append ( " AM005=@AM005," );
            strSql . Append ( " AM006=@AM006," );
            strSql . Append ( " AM007=@AM007," );
            strSql . Append ( " AM008=@AM008," );
            strSql . Append ( " AM009=@AM009," );
            strSql . Append ( " AM010=@AM010," );
            strSql . Append ( " AM011=@AM011," );
            strSql . Append ( " AM012=@AM012," );
            strSql . Append ( " AM013=@AM013," );
            strSql . Append ( " AM014=@AM014," );
            strSql . Append ( " AM015=@AM015," );
            strSql . Append ( " AM016=@AM016," );
            strSql . Append ( " AM017=@AM017," );
            strSql . Append ( " AM018=@AM018," );
            strSql . Append ( " AM019=@AM019," );
            strSql . Append ( " AM020=@AM020," );
            strSql . Append ( " AM021=@AM021," );
            strSql . Append ( " AM022=@AM022," );
            strSql . Append ( " AM023=@AM023," );
            strSql . Append ( " AM024=@AM024," );
            strSql . Append ( " AM025=@AM025," );
            strSql . Append ( " AM026=@AM026," );
            strSql . Append ( " AM027=@AM027," );
            strSql . Append ( " AM028=@AM028," );
            strSql . Append ( " AM029=@AM029," );
            strSql . Append ( " AM044=@AM044," );
            strSql . Append ( " AM045=@AM045," );
            strSql . Append ( " AM046=@AM046," );
            strSql . Append ( " AM047=@AM047," );
            strSql . Append ( " AM048=@AM048," );
            strSql . Append ( " AM049=@AM049," );
            strSql . Append ( " AM050=@AM050," );
            strSql . Append ( " AM051=@AM051," );
            strSql . Append ( " AM052=@AM052," );
            strSql . Append ( " AM053=@AM053," );
            strSql . Append ( " AM054=@AM054," );
            strSql . Append ( " AM055=@AM055," );
            strSql . Append ( " AM056=@AM056," );
            strSql . Append ( " AM057=@AM057," );
            strSql . Append ( " AM058=@AM058," );
            strSql . Append ( " AM059=@AM059," );
            strSql . Append ( " AM060=@AM060," );
            strSql . Append ( " AM061=@AM061," );
            strSql . Append ( " AM070=@AM070," );
            strSql . Append ( " AM071=@AM071," );
            strSql . Append ( " AM072=@AM072," );
            strSql . Append ( " AM073=@AM073," );
            strSql . Append ( " AM074=@AM074," );
            strSql . Append ( " AM075=@AM075," );
            strSql . Append ( " AM076=@AM076," );
            strSql . Append ( " AM077=@AM077," );
            strSql . Append ( " AM078=@AM078," );
            strSql . Append ( " AM079=@AM079," );
            strSql . Append ( " AM080=@AM080," );
            strSql . Append ( " AM081=@AM081," );
            strSql . Append ( " AM082=@AM082," );
            strSql . Append ( " AM083=@AM083," );
            strSql . Append ( " AM084=@AM084," );
            strSql . Append ( " AM085=@AM085," );
            strSql . Append ( " AM086=@AM086," );
            strSql . Append ( " AM087=@AM087," );
            strSql . Append ( " AM088=@AM088," );
            strSql . Append ( " AM089=@AM089," );
            strSql . Append ( " AM090=@AM090," );
            strSql . Append ( " AM091=@AM091," );
            strSql . Append ( " AM092=@AM092," );
            strSql . Append ( " AM093=@AM093," );
            strSql . Append ( " AM108=@AM108," );
            strSql . Append ( " AM109=@AM109," );
            strSql . Append ( " AM110=@AM110," );
            strSql . Append ( " AM111=@AM111," );
            strSql . Append ( " AM112=@AM112," );
            strSql . Append ( " AM113=@AM113," );
            strSql . Append ( " AM130=@AM130," );
            strSql . Append ( " AM131=@AM131," );
            strSql . Append ( " AM133=@AM133," );
            strSql . Append ( " AM134=@AM134," );
            strSql . Append ( " AM135=@AM135," );
            strSql . Append ( " AM136=@AM136," );
            strSql . Append ( " AM137=@AM137," );
            strSql . Append ( " AM138=@AM138," );
            strSql . Append ( " AM139=@AM139," );
            strSql . Append ( " AM140=@AM140," );
            strSql . Append ( " AM141=@AM141," );
            strSql . Append ( " AM142=@AM142," );
            strSql . Append ( " AM143=@AM143," );
            strSql . Append ( " AM144=@AM144," );
            strSql . Append ( " AM145=@AM145," );
            strSql . Append ( " AM146=@AM146," );
            strSql . Append ( " AM147=@AM147," );
            strSql . Append ( " AM148=@AM148," );
            strSql . Append ( " AM149=@AM149," );
            strSql . Append ( " AM150=@AM150," );
            strSql . Append ( " AM151=@AM151," );
            strSql . Append ( " AM152=@AM152," );
            strSql . Append ( " AM173=@AM173," );
            strSql . Append ( " AM175=@AM175," );
            strSql . Append ( " AM176=@AM176," );
            strSql . Append ( " AM177=@AM177," );
            strSql . Append ( " AM178=@AM178," );
            strSql . Append ( " AM179=@AM179," );
            strSql . Append ( " AM180=@AM180," );
            strSql . Append ( " AM182=@AM182," );
            strSql . Append ( " AM183=@AM183," );
            strSql . Append ( " AM184=@AM184," );
            strSql . Append ( " AM185=@AM185," );
            strSql . Append ( " AM186=@AM186," );
            strSql . Append ( " AM187=@AM187," );
            strSql . Append ( " AM188=@AM188," );
            strSql . Append ( " AM189=@AM189," );
            strSql . Append ( " AM190=@AM190," );
            strSql . Append ( " AM191=@AM191," );
            strSql . Append ( " AM192=@AM192," );
            strSql . Append ( " AM193=@AM193," );
            strSql . Append ( " AM194=@AM194," );
            strSql . Append ( " AM195=@AM195," );
            strSql . Append ( " AM196=@AM196," );
            strSql . Append ( " AM197=@AM197," );
            strSql . Append ( " AM198=@AM198," );
            strSql . Append ( " AM199=@AM199," );
            strSql . Append ( " AM200=@AM200," );
            strSql . Append ( " AM201=@AM201," );
            strSql . Append ( " AM203=@AM203," );
            strSql . Append ( " AM204=@AM204," );
            strSql . Append ( " AM205=@AM205," );
            strSql . Append ( " AM206=@AM206," );
            strSql . Append ( " AM207=@AM207," );
            strSql . Append ( " AM208=@AM208," );
            strSql . Append ( " AM209=@AM209," );
            strSql . Append ( " AM210=@AM210," );
            strSql . Append ( " AM211=@AM211," );
            strSql . Append ( " AM212=@AM212," );
            strSql . Append ( " AM213=@AM213," );
            strSql . Append ( " AM214=@AM214," );
            strSql . Append ( " AM215=@AM215," );
            strSql . Append ( " AM216=@AM216," );
            strSql . Append ( " AM217=@AM217," );
            strSql . Append ( " AM218=@AM218," );
            strSql . Append ( " AM219=@AM219," );
            strSql . Append ( " AM220=@AM220," );
            strSql . Append ( " AM221=@AM221," );
            strSql . Append ( " AM222=@AM222," );
            strSql . Append ( " AM223=@AM223," );
            strSql . Append ( " AM224=@AM224," );
            strSql . Append ( " AM239=@AM239," );
            strSql . Append ( " AM240=@AM240," );
            strSql . Append ( " AM241=@AM241," );
            strSql . Append ( " AM242=@AM242," );
            strSql . Append ( " AM243=@AM243," );
            strSql . Append ( " AM244=@AM244," );
            strSql . Append ( " AM245=@AM245," );
            strSql . Append ( " AM246=@AM246," );
            strSql . Append ( " AM247=@AM247," );
            strSql . Append ( " AM249=@AM249," );
            strSql . Append ( " AM250=@AM250," );
            strSql . Append ( " AM251=@AM251," );
            strSql . Append ( " AM252=@AM252," );
            strSql . Append ( " AM253=@AM253," );
            strSql . Append ( " AM261=@AM261," );
            strSql . Append ( " AM262=@AM262," );
            strSql . Append ( " AM263=@AM263," );
            strSql . Append ( " AM264=@AM264," );
            strSql . Append ( " AM265=@AM265," );
            strSql . Append ( " AM266=@AM266," );
            strSql . Append ( " AM267=@AM267," );
            strSql . Append ( " AM268=@AM268," );
            strSql . Append ( " AM269=@AM269," );
            strSql . Append ( " AM270=@AM270," );
            strSql . Append ( " AM271=@AM271," );
            strSql . Append ( " AM272=@AM272," );
            strSql . Append ( " AM273=@AM273," );
            strSql . Append ( " AM274=@AM274," );
            strSql . Append ( " AM275=@AM275," );
            strSql . Append ( " AM277=@AM277," );
            strSql . Append ( " AM278=@AM278," );
            strSql . Append ( " AM279=@AM279," );
            strSql . Append ( " AM280=@AM280," );
            strSql . Append ( " AM281=@AM281," );
            strSql . Append ( " AM282=@AM282," );
            strSql . Append ( " AM283=@AM283," );
            strSql . Append ( " AM284=@AM284," );
            strSql . Append ( " AM285=@AM285," );
            strSql . Append ( " AM286=@AM286," );
            strSql . Append ( " AM287=@AM287," );
            strSql . Append ( " AM288=@AM288," );
            strSql . Append ( " AM289=@AM289," );
            strSql . Append ( " AM290=@AM290," );
            strSql . Append ( " AM291=@AM291," );
            strSql . Append ( " AM292=@AM292," );
            strSql . Append ( " AM293=@AM293," );
            strSql . Append ( " AM294=@AM294," );
            strSql . Append ( " AM295=@AM295," );
            strSql . Append ( " AM296=@AM296," );
            strSql . Append ( " AM297=@AM297," );
            strSql . Append ( " AM298=@AM298," );
            strSql . Append ( " AM299=@AM299," );
            strSql . Append ( " AM300=@AM300," );
            strSql . Append ( " AM301=@AM301," );
            strSql . Append ( " AM302=@AM302," );
            strSql . Append ( " AM303=@AM303," );
            strSql . Append ( " AM304=@AM304," );
            strSql . Append ( " AM305=@AM305," );
            strSql . Append ( " AM306=@AM306," );
            strSql . Append ( " AM307=@AM307," );
            strSql . Append ( " AM308=@AM308," );
            strSql . Append ( " AM309=@AM309," );
            strSql . Append ( " AM311=@AM311," );
            strSql . Append ( " AM312=@AM312," );
            strSql . Append ( " AM313=@AM313," );
            strSql . Append ( " AM315=@AM315," );
            strSql . Append ( " AM316=@AM316," );
            strSql . Append ( " AM317=@AM317," );
            strSql . Append ( " AM318=@AM318," );
            strSql . Append ( " AM319=@AM319," );
            strSql . Append ( " AM320=@AM320," );
            strSql . Append ( " AM321=@AM321," );
            strSql . Append ( " AM322=@AM322," );
            strSql . Append ( " AM323=@AM323," );
            strSql . Append ( " AM324=@AM324," );
            strSql . Append ( " AM325=@AM325," );
            strSql . Append ( " AM326=@AM326," );
            strSql . Append ( " AM327=@AM327," );
            strSql . Append ( " AM328=@AM328," );
            strSql . Append ( " AM329=@AM329," );
            strSql . Append ( " AM330=@AM330," );
            strSql . Append ( " AM331=@AM331," );
            strSql . Append ( " AM332=@AM332," );
            strSql . Append ( " AM333=@AM333," );
            strSql . Append ( " AM334=@AM334," );
            strSql . Append ( " AM335=@AM335," );
            strSql . Append ( " AM336=@AM336," );
            strSql . Append ( " AM337=@AM337," );
            strSql . Append ( " AM338=@AM338," );
            strSql . Append ( " AM339=@AM339," );
            strSql . Append ( " AM340=@AM340," );
            strSql . Append ( " AM341=@AM341," );
            strSql . Append ( " AM343=@AM343," );
            strSql . Append ( " AM344=@AM344," );
            strSql . Append ( " AM345=@AM345," );
            strSql . Append ( " AM346=@AM346," );
            strSql . Append ( " AM347=@AM347," );
            strSql . Append ( " AM348=@AM348," );
            strSql . Append ( " AM349=@AM349," );
            strSql . Append ( " AM350=@AM350," );
            strSql . Append ( " AM351=@AM351," );
            strSql . Append ( " AM352=@AM352," );
            strSql . Append ( " AM353=@AM353," );
            strSql . Append ( " AM354=@AM354," );
            strSql . Append ( " AM355=@AM355," );
            strSql . Append ( " AM356=@AM356," );
            strSql . Append ( " AM357=@AM357," );
            strSql . Append ( " AM358=@AM358," );
            strSql . Append ( " AM359=@AM359," );
            strSql . Append ( " AM360=@AM360," );
            strSql . Append ( " AM361=@AM361," );
            strSql . Append ( " AM362=@AM362," );
            strSql . Append ( " AM363=@AM363," );
            strSql . Append ( " AM364=@AM364," );
            strSql . Append ( " AM365=@AM365," );
            strSql . Append ( " AM366=@AM366," );
            strSql . Append ( " AM367=@AM367," );
            strSql . Append ( " AM368=@AM368," );
            strSql . Append ( " AM369=@AM369," );
            strSql . Append ( " AM370=@AM370," );
            strSql . Append ( " AM371=@AM371," );
            strSql . Append ( " AM372=@AM372," );
            strSql . Append ( " AM373=@AM373," );
            strSql . Append ( " AM374=@AM374," );
            strSql . Append ( " AM375=@AM375," );
            strSql . Append ( " AM376=@AM376," );
            strSql . Append ( " AM377=@AM377," );
            strSql . Append ( " AM378=@AM378," );
            strSql . Append ( " AM379=@AM379," );
            strSql . Append ( " AM380=@AM380," );
            strSql . Append ( " AM381=@AM381," );
            strSql . Append ( " AM382=@AM382," );
            strSql . Append ( " AM383=@AM383," );
            strSql . Append ( " AM385=@AM385," );
            strSql . Append ( " AM386=@AM386," );
            strSql . Append ( " AM387=@AM387," );
            strSql . Append ( " AM388=@AM388," );
            strSql . Append ( " AM389=@AM389," );
            strSql . Append ( " AM390=@AM390," );
            strSql . Append ( " AM391=@AM391," );
            strSql . Append ( " AM392=@AM392," );
            strSql . Append ( " AM393=@AM393," );
            strSql . Append ( " AM062=@AM062," );
            strSql . Append ( " AM063=@AM063," );
            strSql . Append ( " AM225=@AM225," );
            strSql . Append ( " AM226=@AM226," );
            strSql . Append ( " AM227=@AM227," );
            strSql . Append ( " AM228=@AM228," );
            strSql . Append ( " AM229=@AM229," );
            strSql . Append ( " AM230=@AM230," );
            strSql . Append ( " AM231=@AM231," );
            strSql . Append ( " AM232=@AM232," );
            strSql . Append ( " AM233=@AM233," );
            strSql . Append ( " AM234=@AM234," );
            strSql . Append ( " AM235=@AM235," );
            strSql . Append ( " AM236=@AM236," );
            strSql . Append ( " AM237=@AM237," );
            strSql . Append ( " AM238=@AM238," );
            strSql . Append ( " AM255=@AM255," );
            strSql . Append ( " AM256=@AM256," );
            strSql . Append ( " AM153=@AM153," );
            strSql . Append ( " AM154=@AM154," );
            strSql . Append ( " AM155=@AM155," );
            strSql . Append ( " AM156=@AM156," );
            strSql . Append ( " AM157=@AM157," );
            strSql . Append ( " AM158=@AM158," );
            strSql . Append ( " AM248=@AM248 " );
            strSql . Append ( " WHERE idx=@idx" );

            SqlParameter [ ] parameter = {
                new SqlParameter("@AM001",SqlDbType.NVarChar,20),
                new SqlParameter("@AM002",SqlDbType.NVarChar,20),
                new SqlParameter("@AM003",SqlDbType.NVarChar,20),
                new SqlParameter("@AM004",SqlDbType.NVarChar,20),
                new SqlParameter("@AM005",SqlDbType.NVarChar,20),
                new SqlParameter("@AM006",SqlDbType.BigInt),
                new SqlParameter("@AM007",SqlDbType.Date,3),
                new SqlParameter("@AM008",SqlDbType.NVarChar,20),
                new SqlParameter("@AM009",SqlDbType.NVarChar,20),
                new SqlParameter("@AM010",SqlDbType.NVarChar,20),
                new SqlParameter("@AM011",SqlDbType.NVarChar,20),
                new SqlParameter("@AM012",SqlDbType.NChar,10),
                new SqlParameter("@AM013",SqlDbType.NVarChar,20),
                new SqlParameter("@AM014",SqlDbType.NVarChar,20),
                new SqlParameter("@AM015",SqlDbType.BigInt),
                new SqlParameter("@AM016",SqlDbType.Decimal,10),
                new SqlParameter("@AM017",SqlDbType.Decimal,10),
                new SqlParameter("@AM018",SqlDbType.Decimal,10),
                new SqlParameter("@AM019",SqlDbType.Decimal,10),
                new SqlParameter("@AM044",SqlDbType.Decimal,10),
                new SqlParameter("@AM045",SqlDbType.Decimal,10),
                new SqlParameter("@AM046",SqlDbType.Decimal,10),
                new SqlParameter("@AM047",SqlDbType.Decimal,10),
                new SqlParameter("@AM048",SqlDbType.Decimal,10),
                new SqlParameter("@AM049",SqlDbType.Decimal,10),
                new SqlParameter("@AM050",SqlDbType.Decimal,10),
                new SqlParameter("@AM051",SqlDbType.Decimal,10),
                new SqlParameter("@AM052",SqlDbType.Decimal,10),
                new SqlParameter("@AM053",SqlDbType.Decimal,10),
                new SqlParameter("@AM054",SqlDbType.Decimal,10),
                new SqlParameter("@AM055",SqlDbType.Decimal,10),
                new SqlParameter("@AM056",SqlDbType.Decimal,10),
                new SqlParameter("@AM057",SqlDbType.Decimal,10),
                new SqlParameter("@AM058",SqlDbType.Decimal,10),
                new SqlParameter("@AM059",SqlDbType.Decimal,10),
                new SqlParameter("@AM060",SqlDbType.Decimal,10),
                new SqlParameter("@AM061",SqlDbType.Decimal,10),
                new SqlParameter("@AM070",SqlDbType.Decimal,10),
                new SqlParameter("@AM071",SqlDbType.Decimal,10),
                new SqlParameter("@AM072",SqlDbType.Decimal,10),
                new SqlParameter("@AM073",SqlDbType.Decimal,10),
                new SqlParameter("@AM074",SqlDbType.Decimal,10),
                new SqlParameter("@AM075",SqlDbType.Decimal,10),
                new SqlParameter("@AM076",SqlDbType.Decimal,10),
                new SqlParameter("@AM077",SqlDbType.Decimal,10),
                new SqlParameter("@AM078",SqlDbType.Decimal,10),
                new SqlParameter("@AM079",SqlDbType.Decimal,10),
                new SqlParameter("@AM080",SqlDbType.Decimal,10),
                new SqlParameter("@AM081",SqlDbType.Decimal,10),
                new SqlParameter("@AM082",SqlDbType.Decimal,10),
                new SqlParameter("@AM083",SqlDbType.Decimal,10),
                new SqlParameter("@AM084",SqlDbType.Decimal,10),
                new SqlParameter("@AM085",SqlDbType.Decimal,10),
                new SqlParameter("@AM086",SqlDbType.Decimal,10),
                new SqlParameter("@AM087",SqlDbType.Decimal,10),
                new SqlParameter("@AM088",SqlDbType.Decimal,10),
                new SqlParameter("@AM089",SqlDbType.Decimal,10),
                new SqlParameter("@AM090",SqlDbType.Decimal,10),
                new SqlParameter("@AM091",SqlDbType.Decimal,10),
                new SqlParameter("@AM092",SqlDbType.Decimal,10),
                new SqlParameter("@AM093",SqlDbType.Decimal,10),
                new SqlParameter("@AM108",SqlDbType.Decimal,10),
                new SqlParameter("@AM109",SqlDbType.Decimal,10),
                new SqlParameter("@AM110",SqlDbType.Decimal,10),
                new SqlParameter("@AM111",SqlDbType.Decimal,10),
                new SqlParameter("@AM112",SqlDbType.Decimal,10),
                new SqlParameter("@AM113",SqlDbType.Decimal,10),
                new SqlParameter("@AM130",SqlDbType.Decimal,10),
                new SqlParameter("@AM131",SqlDbType.Decimal,10),
                new SqlParameter("@AM133",SqlDbType.Decimal,10),
                new SqlParameter("@AM134",SqlDbType.Decimal,10),
                new SqlParameter("@AM135",SqlDbType.Decimal,10),
                new SqlParameter("@AM136",SqlDbType.Decimal,10),
                new SqlParameter("@AM137",SqlDbType.Decimal,10),
                new SqlParameter("@AM138",SqlDbType.Decimal,10),
                new SqlParameter("@AM139",SqlDbType.Decimal,10),
                new SqlParameter("@AM140",SqlDbType.Decimal,10),
                new SqlParameter("@AM141",SqlDbType.Decimal,10),
                new SqlParameter("@AM142",SqlDbType.Decimal,10),
                new SqlParameter("@AM143",SqlDbType.Decimal,10),
                new SqlParameter("@AM144",SqlDbType.Decimal,10),
                new SqlParameter("@AM145",SqlDbType.Decimal,10),
                new SqlParameter("@AM146",SqlDbType.Decimal,10),
                new SqlParameter("@AM147",SqlDbType.Decimal,10),
                new SqlParameter("@AM148",SqlDbType.Decimal,10),
                new SqlParameter("@AM149",SqlDbType.Decimal,10),
                new SqlParameter("@AM150",SqlDbType.Decimal,10),
                new SqlParameter("@AM151",SqlDbType.Decimal,10),
                new SqlParameter("@AM152",SqlDbType.Decimal,10),
                new SqlParameter("@AM175",SqlDbType.Decimal,10),
                new SqlParameter("@AM176",SqlDbType.Decimal,10),
                new SqlParameter("@AM177",SqlDbType.Decimal,10),
                new SqlParameter("@AM178",SqlDbType.Decimal,10),
                new SqlParameter("@AM179",SqlDbType.Decimal,10),
                new SqlParameter("@AM180",SqlDbType.Decimal,10),
                new SqlParameter("@AM182",SqlDbType.Decimal,10),
                new SqlParameter("@AM183",SqlDbType.Decimal,10),
                new SqlParameter("@AM184",SqlDbType.Decimal,10),
                new SqlParameter("@AM185",SqlDbType.Decimal,10),
                new SqlParameter("@AM186",SqlDbType.Decimal,10),
                new SqlParameter("@AM187",SqlDbType.Decimal,10),
                new SqlParameter("@AM188",SqlDbType.Decimal,10),
                new SqlParameter("@AM189",SqlDbType.Decimal,10),
                new SqlParameter("@AM190",SqlDbType.Decimal,10),
                new SqlParameter("@AM191",SqlDbType.Decimal,10),
                new SqlParameter("@AM192",SqlDbType.Decimal,10),
                new SqlParameter("@AM193",SqlDbType.Decimal,10),
                new SqlParameter("@AM194",SqlDbType.Decimal,10),
                new SqlParameter("@AM195",SqlDbType.Decimal,10),
                new SqlParameter("@AM196",SqlDbType.Decimal,10),
                new SqlParameter("@AM197",SqlDbType.Decimal,10),
                new SqlParameter("@AM198",SqlDbType.Decimal,10),
                new SqlParameter("@AM199",SqlDbType.Decimal,10),
                new SqlParameter("@AM200",SqlDbType.Decimal,10),
                new SqlParameter("@AM201",SqlDbType.Decimal,10),
                //new SqlParameter("@AM202",SqlDbType.Decimal,10),
                new SqlParameter("@AM203",SqlDbType.Decimal,10),
                new SqlParameter("@AM204",SqlDbType.Decimal,10),
                new SqlParameter("@AM205",SqlDbType.Decimal,10),
                new SqlParameter("@AM206",SqlDbType.Decimal,10),
                new SqlParameter("@AM207",SqlDbType.Decimal,10),
                new SqlParameter("@AM208",SqlDbType.Decimal,10),
                new SqlParameter("@AM209",SqlDbType.Decimal,10),
                new SqlParameter("@AM210",SqlDbType.Decimal,10),
                new SqlParameter("@AM211",SqlDbType.Decimal,10),
                new SqlParameter("@AM212",SqlDbType.Decimal,10),
                new SqlParameter("@AM213",SqlDbType.Decimal,10),
                new SqlParameter("@AM214",SqlDbType.Decimal,10),
                new SqlParameter("@AM215",SqlDbType.Decimal,10),
                new SqlParameter("@AM216",SqlDbType.Decimal,10),
                new SqlParameter("@AM217",SqlDbType.Decimal,10),
                new SqlParameter("@AM218",SqlDbType.Decimal,10),
                new SqlParameter("@AM219",SqlDbType.Decimal,10),
                new SqlParameter("@AM220",SqlDbType.Decimal,10),
                new SqlParameter("@AM221",SqlDbType.Decimal,10),
                new SqlParameter("@AM222",SqlDbType.Decimal,10),
                new SqlParameter("@AM223",SqlDbType.Decimal,10),
                new SqlParameter("@AM224",SqlDbType.Decimal,10),
                new SqlParameter("@AM239",SqlDbType.Decimal,10),
                new SqlParameter("@AM240",SqlDbType.Decimal,10),
                new SqlParameter("@AM241",SqlDbType.Decimal,10),
                new SqlParameter("@AM242",SqlDbType.Decimal,10),
                new SqlParameter("@AM243",SqlDbType.Decimal,10),
                new SqlParameter("@AM244",SqlDbType.Decimal,10),
                new SqlParameter("@AM245",SqlDbType.Decimal,10),
                new SqlParameter("@AM246",SqlDbType.Decimal,10),
                new SqlParameter("@AM247",SqlDbType.Decimal,10),
                //new SqlParameter("@AM248",SqlDbType.Decimal,10),
                new SqlParameter("@AM249",SqlDbType.Decimal,10),
                new SqlParameter("@AM250",SqlDbType.Decimal,10),
                new SqlParameter("@AM251",SqlDbType.Decimal,10),
                new SqlParameter("@AM252",SqlDbType.Decimal,10),
                new SqlParameter("@AM253",SqlDbType.Decimal,10),
                new SqlParameter("@AM261",SqlDbType.Decimal,10),
                new SqlParameter("@AM262",SqlDbType.Decimal,10),
                new SqlParameter("@AM263",SqlDbType.Decimal,10),
                new SqlParameter("@AM264",SqlDbType.Decimal,10),
                new SqlParameter("@AM265",SqlDbType.Decimal,10),
                new SqlParameter("@AM266",SqlDbType.Decimal,10),
                new SqlParameter("@AM267",SqlDbType.Decimal,10),
                new SqlParameter("@AM268",SqlDbType.Decimal,10),
                new SqlParameter("@AM269",SqlDbType.Decimal,10),
                new SqlParameter("@AM270",SqlDbType.Decimal,10),
                new SqlParameter("@AM271",SqlDbType.Decimal,10),
                new SqlParameter("@AM272",SqlDbType.Decimal,10),
                new SqlParameter("@AM273",SqlDbType.Decimal,10),
                new SqlParameter("@AM274",SqlDbType.Decimal,10),
                new SqlParameter("@AM275",SqlDbType.Decimal,10),
                new SqlParameter("@AM277",SqlDbType.Decimal,10),
                new SqlParameter("@AM278",SqlDbType.Decimal,10),
                new SqlParameter("@AM279",SqlDbType.Decimal,10),
                new SqlParameter("@AM280",SqlDbType.Decimal,10),
                new SqlParameter("@AM281",SqlDbType.Decimal,10),
                new SqlParameter("@AM282",SqlDbType.Decimal,10),
                new SqlParameter("@AM283",SqlDbType.Decimal,10),
                new SqlParameter("@AM284",SqlDbType.Decimal,10),
                new SqlParameter("@AM285",SqlDbType.Decimal,10),
                new SqlParameter("@AM286",SqlDbType.Decimal,10),
                new SqlParameter("@AM287",SqlDbType.Decimal,10),
                new SqlParameter("@AM288",SqlDbType.Decimal,10),
                new SqlParameter("@AM289",SqlDbType.Decimal,10),
                new SqlParameter("@AM290",SqlDbType.Decimal,10),
                new SqlParameter("@AM291",SqlDbType.Decimal,10),
                new SqlParameter("@AM292",SqlDbType.Decimal,10),
                new SqlParameter("@AM293",SqlDbType.Decimal,10),
                new SqlParameter("@AM294",SqlDbType.Decimal,10),
                new SqlParameter("@AM295",SqlDbType.Decimal,10),
                new SqlParameter("@AM296",SqlDbType.Decimal,10),
                new SqlParameter("@AM297",SqlDbType.Decimal,10),
                new SqlParameter("@AM298",SqlDbType.Decimal,10),
                new SqlParameter("@AM299",SqlDbType.Decimal,10),
                new SqlParameter("@AM300",SqlDbType.Decimal,10),
                new SqlParameter("@AM301",SqlDbType.Decimal,10),
                new SqlParameter("@AM302",SqlDbType.Decimal,10),
                new SqlParameter("@AM303",SqlDbType.Decimal,10),
                new SqlParameter("@AM304",SqlDbType.Decimal,10),
                new SqlParameter("@AM305",SqlDbType.Decimal,10),
                new SqlParameter("@AM306",SqlDbType.Decimal,10),
                new SqlParameter("@AM307",SqlDbType.Decimal,10),
                new SqlParameter("@AM308",SqlDbType.Decimal,10),
                new SqlParameter("@AM309",SqlDbType.Decimal,10),
                new SqlParameter("@AM311",SqlDbType.Decimal,10),
                new SqlParameter("@AM312",SqlDbType.Decimal,10),
                new SqlParameter("@AM313",SqlDbType.Decimal,10),
                new SqlParameter("@AM315",SqlDbType.Decimal,10),
                new SqlParameter("@AM316",SqlDbType.Decimal,10),
                new SqlParameter("@AM317",SqlDbType.Decimal,10),
                new SqlParameter("@AM318",SqlDbType.Decimal,10),
                new SqlParameter("@AM319",SqlDbType.Decimal,10),
                new SqlParameter("@AM320",SqlDbType.Decimal,10),
                new SqlParameter("@AM321",SqlDbType.Decimal,10),
                new SqlParameter("@AM322",SqlDbType.Decimal,10),
                new SqlParameter("@AM323",SqlDbType.Decimal,10),
                new SqlParameter("@AM324",SqlDbType.Decimal,10),
                new SqlParameter("@AM325",SqlDbType.Decimal,10),
                new SqlParameter("@AM326",SqlDbType.Decimal,10),
                new SqlParameter("@AM327",SqlDbType.Decimal,10),
                new SqlParameter("@AM328",SqlDbType.Decimal,10),
                new SqlParameter("@AM329",SqlDbType.Decimal,10),
                new SqlParameter("@AM330",SqlDbType.Decimal,10),
                new SqlParameter("@AM331",SqlDbType.Decimal,10),
                new SqlParameter("@AM332",SqlDbType.Decimal,10),
                new SqlParameter("@AM333",SqlDbType.Decimal,10),
                new SqlParameter("@AM334",SqlDbType.Decimal,10),
                new SqlParameter("@AM335",SqlDbType.Decimal,10),
                new SqlParameter("@AM336",SqlDbType.Decimal,10),
                new SqlParameter("@AM337",SqlDbType.Decimal,10),
                new SqlParameter("@AM338",SqlDbType.Decimal,10),
                new SqlParameter("@AM339",SqlDbType.Decimal,10),
                new SqlParameter("@AM340",SqlDbType.Decimal,10),
                new SqlParameter("@AM341",SqlDbType.Decimal,10),
                new SqlParameter("@AM343",SqlDbType.Decimal,10),
                new SqlParameter("@AM344",SqlDbType.Decimal,10),
                new SqlParameter("@AM345",SqlDbType.Decimal,10),
                new SqlParameter("@AM346",SqlDbType.Decimal,10),
                new SqlParameter("@AM347",SqlDbType.Decimal,10),
                new SqlParameter("@AM348",SqlDbType.Decimal,10),
                new SqlParameter("@AM349",SqlDbType.Decimal,10),
                new SqlParameter("@AM350",SqlDbType.Decimal,10),
                new SqlParameter("@AM351",SqlDbType.Decimal,10),
                new SqlParameter("@AM352",SqlDbType.Decimal,10),
                new SqlParameter("@AM353",SqlDbType.Decimal,10),
                new SqlParameter("@AM354",SqlDbType.Decimal,10),
                new SqlParameter("@AM355",SqlDbType.Decimal,10),
                new SqlParameter("@AM356",SqlDbType.Decimal,10),
                new SqlParameter("@AM357",SqlDbType.Decimal,10),
                new SqlParameter("@AM358",SqlDbType.Decimal,10),
                new SqlParameter("@AM359",SqlDbType.Decimal,10),
                new SqlParameter("@AM360",SqlDbType.Decimal,10),
                new SqlParameter("@AM361",SqlDbType.Decimal,10),
                new SqlParameter("@AM362",SqlDbType.Decimal,10),
                new SqlParameter("@AM363",SqlDbType.Decimal,10),
                new SqlParameter("@AM364",SqlDbType.Decimal,10),
                new SqlParameter("@AM365",SqlDbType.Decimal,10),
                new SqlParameter("@AM366",SqlDbType.Decimal,10),
                new SqlParameter("@AM367",SqlDbType.Decimal,10),
                new SqlParameter("@AM368",SqlDbType.Decimal,10),
                new SqlParameter("@AM369",SqlDbType.Decimal,10),
                new SqlParameter("@AM370",SqlDbType.Decimal,10),
                new SqlParameter("@AM371",SqlDbType.Decimal,10),
                new SqlParameter("@AM372",SqlDbType.Decimal,10),
                new SqlParameter("@AM373",SqlDbType.Decimal,10),
                new SqlParameter("@AM374",SqlDbType.Decimal,10),
                new SqlParameter("@AM375",SqlDbType.Decimal,10),
                new SqlParameter("@AM376",SqlDbType.Decimal,10),
                new SqlParameter("@AM377",SqlDbType.Decimal,10),
                new SqlParameter("@AM378",SqlDbType.Decimal,10),
                new SqlParameter("@AM379",SqlDbType.Decimal,10),
                new SqlParameter("@AM380",SqlDbType.Decimal,10),
                new SqlParameter("@AM381",SqlDbType.Decimal,10),
                new SqlParameter("@AM382",SqlDbType.Decimal,10),
                new SqlParameter("@AM383",SqlDbType.Decimal,10),
                new SqlParameter("@AM385",SqlDbType.Decimal,10),
                new SqlParameter("@AM386",SqlDbType.Decimal,10),
                new SqlParameter("@AM387",SqlDbType.Decimal,10),
                new SqlParameter("@AM388",SqlDbType.Decimal,10),
                new SqlParameter("@AM389",SqlDbType.Decimal,10),
                new SqlParameter("@AM390",SqlDbType.Decimal,10),
                new SqlParameter("@AM391",SqlDbType.Decimal,10),
                new SqlParameter("@AM392",SqlDbType.Decimal,10),
                new SqlParameter("@AM393",SqlDbType.Decimal,10),
                new SqlParameter("@AM020",SqlDbType.Decimal,10),
                new SqlParameter("@AM021",SqlDbType.Decimal,10),
                new SqlParameter("@AM022",SqlDbType.Decimal,10),
                new SqlParameter("@AM023",SqlDbType.Decimal,10),
                new SqlParameter("@AM024",SqlDbType.Decimal,10),
                new SqlParameter("@AM025",SqlDbType.Decimal,10),
                new SqlParameter("@AM026",SqlDbType.Decimal,10),
                new SqlParameter("@AM027",SqlDbType.Decimal,10),
                new SqlParameter("@AM028",SqlDbType.Decimal,10),
                new SqlParameter("@AM029",SqlDbType.Decimal,10),
                new SqlParameter("@AM062",SqlDbType.Decimal,10),
                new SqlParameter("@AM063",SqlDbType.Decimal,10),
                new SqlParameter("@AM173",SqlDbType.Decimal,10),
                new SqlParameter("@AM225",SqlDbType.Decimal,10),
                new SqlParameter("@AM226",SqlDbType.Decimal,10),
                new SqlParameter("@AM227",SqlDbType.Decimal,10),
                new SqlParameter("@AM228",SqlDbType.Decimal,10),
                new SqlParameter("@AM229",SqlDbType.Decimal,10),
                new SqlParameter("@AM230",SqlDbType.Decimal,10),
                new SqlParameter("@AM231",SqlDbType.Decimal,10),
                new SqlParameter("@AM232",SqlDbType.Decimal,10),
                new SqlParameter("@AM233",SqlDbType.Decimal,10),
                new SqlParameter("@AM234",SqlDbType.Decimal,10),
                new SqlParameter("@AM235",SqlDbType.Decimal,10),
                new SqlParameter("@AM236",SqlDbType.Decimal,10),
                new SqlParameter("@AM237",SqlDbType.Decimal,10),
                new SqlParameter("@AM238",SqlDbType.Decimal,10),
                new SqlParameter("@AM255",SqlDbType.Decimal,10),
                new SqlParameter("@AM256",SqlDbType.Decimal,10),
                new SqlParameter("@AM153",SqlDbType.Decimal,10),
                new SqlParameter("@AM154",SqlDbType.Decimal,10),
                new SqlParameter("@AM155",SqlDbType.Decimal,10),
                new SqlParameter("@AM156",SqlDbType.Decimal,10),
                new SqlParameter("@AM157",SqlDbType.Decimal,10),
                new SqlParameter("@AM158",SqlDbType.Decimal,10),
                new SqlParameter("@AM248",SqlDbType.Decimal,10),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter [ 0 ] . Value = model . AM001;
            parameter [ 1 ] . Value = model . AM002;
            parameter [ 2 ] . Value = model . AM003;
            parameter [ 3 ] . Value = model . AM004;
            parameter [ 4 ] . Value = model . AM005;
            parameter [ 5 ] . Value = model . AM006;
            if ( model . AM007 != null )
                parameter [ 6 ] . Value = model . AM007;
            else
                parameter [ 6 ] . Value = DBNull . Value;
            parameter [ 7 ] . Value = model . AM008;
            parameter [ 8 ] . Value = model . AM009;
            parameter [ 9 ] . Value = model . AM010;
            parameter [ 10 ] . Value = model . AM011;
            parameter [ 11 ] . Value = model . AM012;
            parameter [ 12 ] . Value = model . AM013;
            parameter [ 13 ] . Value = model . AM014;
            parameter [ 14 ] . Value = model . AM015;
            parameter [ 15 ] . Value = model . AM016;
            parameter [ 16 ] . Value = model . AM017;
            parameter [ 17 ] . Value = model . AM018;
            parameter [ 18 ] . Value = model . AM019;
            parameter [ 19 ] . Value = model . AM044;
            parameter [ 20 ] . Value = model . AM045;
            parameter [ 21 ] . Value = model . AM046;
            parameter [ 22 ] . Value = model . AM047;
            parameter [ 23 ] . Value = model . AM048;
            parameter [ 24 ] . Value = model . AM049;
            parameter [ 25 ] . Value = model . AM050;
            parameter [ 26 ] . Value = model . AM051;
            parameter [ 27 ] . Value = model . AM052;
            parameter [ 28 ] . Value = model . AM053;
            parameter [ 29 ] . Value = model . AM054;
            parameter [ 30 ] . Value = model . AM055;
            parameter [ 31 ] . Value = model . AM056;
            parameter [ 32 ] . Value = model . AM057;
            parameter [ 33 ] . Value = model . AM058;
            parameter [ 34 ] . Value = model . AM059;
            parameter [ 35 ] . Value = model . AM060;
            parameter [ 36 ] . Value = model . AM061;
            parameter [ 37 ] . Value = model . AM070;
            parameter [ 38 ] . Value = model . AM071;
            parameter [ 39 ] . Value = model . AM072;
            parameter [ 40 ] . Value = model . AM073;
            parameter [ 41 ] . Value = model . AM074;
            parameter [ 42 ] . Value = model . AM075;
            parameter [ 43 ] . Value = model . AM076;
            parameter [ 44 ] . Value = model . AM077;
            parameter [ 45 ] . Value = model . AM078;
            parameter [ 46 ] . Value = model . AM079;
            parameter [ 47 ] . Value = model . AM080;
            parameter [ 48 ] . Value = model . AM081;
            parameter [ 49 ] . Value = model . AM082;
            parameter [ 50 ] . Value = model . AM083;
            parameter [ 51 ] . Value = model . AM084;
            parameter [ 52 ] . Value = model . AM085;
            parameter [ 53 ] . Value = model . AM086;
            parameter [ 54 ] . Value = model . AM087;
            parameter [ 55 ] . Value = model . AM088;
            parameter [ 56 ] . Value = model . AM089;
            parameter [ 57 ] . Value = model . AM090;
            parameter [ 58 ] . Value = model . AM091;
            parameter [ 59 ] . Value = model . AM092;
            parameter [ 60 ] . Value = model . AM093;
            parameter [ 61 ] . Value = model . AM108;
            parameter [ 62 ] . Value = model . AM109;
            parameter [ 63 ] . Value = model . AM110;
            parameter [ 64 ] . Value = model . AM111;
            parameter [ 65 ] . Value = model . AM112;
            parameter [ 66 ] . Value = model . AM113;
            parameter [ 67 ] . Value = model . AM130;
            parameter [ 68 ] . Value = model . AM131;
            parameter [ 69 ] . Value = model . AM133;
            parameter [ 70 ] . Value = model . AM134;
            parameter [ 71 ] . Value = model . AM135;
            parameter [ 72 ] . Value = model . AM136;
            parameter [ 73 ] . Value = model . AM137;
            parameter [ 74 ] . Value = model . AM138;
            parameter [ 75 ] . Value = model . AM139;
            parameter [ 76 ] . Value = model . AM140;
            parameter [ 77 ] . Value = model . AM141;
            parameter [ 78 ] . Value = model . AM142;
            parameter [ 79 ] . Value = model . AM143;
            parameter [ 80 ] . Value = model . AM144;
            parameter [ 81 ] . Value = model . AM145;
            parameter [ 82 ] . Value = model . AM146;
            parameter [ 83 ] . Value = model . AM147;
            parameter [ 84 ] . Value = model . AM148;
            parameter [ 85 ] . Value = model . AM149;
            parameter [ 86 ] . Value = model . AM150;
            parameter [ 87 ] . Value = model . AM151;
            parameter [ 88 ] . Value = model . AM152;
            parameter [ 89 ] . Value = model . AM175;
            parameter [ 90 ] . Value = model . AM176;
            parameter [ 91 ] . Value = model . AM177;
            parameter [ 92 ] . Value = model . AM178;
            parameter [ 93 ] . Value = model . AM179;
            parameter [ 94 ] . Value = model . AM180;
            parameter [ 95 ] . Value = model . AM182;
            parameter [ 96 ] . Value = model . AM183;
            parameter [ 97 ] . Value = model . AM184;
            parameter [ 98 ] . Value = model . AM185;
            parameter [ 99 ] . Value = model . AM186;
            parameter [ 100 ] . Value = model . AM187;
            parameter [ 101 ] . Value = model . AM188;
            parameter [ 102 ] . Value = model . AM189;
            parameter [ 103 ] . Value = model . AM190;
            parameter [ 104 ] . Value = model . AM191;
            parameter [ 105 ] . Value = model . AM192;
            parameter [ 106 ] . Value = model . AM193;
            parameter [ 107 ] . Value = model . AM194;
            parameter [ 108 ] . Value = model . AM195;
            parameter [ 109 ] . Value = model . AM196;
            parameter [ 110 ] . Value = model . AM197;
            parameter [ 111 ] . Value = model . AM198;
            parameter [ 112 ] . Value = model . AM199;
            parameter [ 113 ] . Value = model . AM200;
            parameter [ 114 ] . Value = model . AM201;
            parameter [ 115 ] . Value = model . AM203;
            parameter [ 116 ] . Value = model . AM204;
            parameter [ 117 ] . Value = model . AM205;
            parameter [ 118 ] . Value = model . AM206;
            parameter [ 119 ] . Value = model . AM207;
            parameter [ 120 ] . Value = model . AM208;
            parameter [ 121 ] . Value = model . AM209;
            parameter [ 122 ] . Value = model . AM210;
            parameter [ 123 ] . Value = model . AM211;
            parameter [ 124 ] . Value = model . AM212;
            parameter [ 125 ] . Value = model . AM213;
            parameter [ 126 ] . Value = model . AM214;
            parameter [ 127 ] . Value = model . AM215;
            parameter [ 128 ] . Value = model . AM216;
            parameter [ 129 ] . Value = model . AM217;
            parameter [ 130 ] . Value = model . AM218;
            parameter [ 131 ] . Value = model . AM219;
            parameter [ 132 ] . Value = model . AM220;
            parameter [ 133 ] . Value = model . AM221;
            parameter [ 134 ] . Value = model . AM222;
            parameter [ 135 ] . Value = model . AM223;
            parameter [ 136 ] . Value = model . AM224;
            parameter [ 137 ] . Value = model . AM239;
            parameter [ 138 ] . Value = model . AM240;
            parameter [ 139 ] . Value = model . AM241;
            parameter [ 140 ] . Value = model . AM242;
            parameter [ 141 ] . Value = model . AM243;
            parameter [ 142 ] . Value = model . AM244;
            parameter [ 143 ] . Value = model . AM245;
            parameter [ 144 ] . Value = model . AM246;
            parameter [ 145 ] . Value = model . AM247;
            //parameter[146].Value = model.AM248;
            parameter [ 146 ] . Value = model . AM249;
            parameter [ 147 ] . Value = model . AM250;
            parameter [ 148 ] . Value = model . AM251;
            parameter [ 149 ] . Value = model . AM252;
            parameter [ 150 ] . Value = model . AM253;
            parameter [ 151 ] . Value = model . AM261;
            parameter [ 152 ] . Value = model . AM262;
            parameter [ 153 ] . Value = model . AM263;
            parameter [ 154 ] . Value = model . AM264;
            parameter [ 155 ] . Value = model . AM265;
            parameter [ 156 ] . Value = model . AM266;
            parameter [ 157 ] . Value = model . AM267;
            parameter [ 158 ] . Value = model . AM268;
            parameter [ 159 ] . Value = model . AM269;
            parameter [ 160 ] . Value = model . AM270;
            parameter [ 161 ] . Value = model . AM271;
            parameter [ 162 ] . Value = model . AM272;
            parameter [ 163 ] . Value = model . AM273;
            parameter [ 164 ] . Value = model . AM274;
            parameter [ 165 ] . Value = model . AM275;
            parameter [ 166 ] . Value = model . AM277;
            parameter [ 167 ] . Value = model . AM278;
            parameter [ 168 ] . Value = model . AM279;
            parameter [ 169 ] . Value = model . AM280;
            parameter [ 170 ] . Value = model . AM281;
            parameter [ 171 ] . Value = model . AM282;
            parameter [ 172 ] . Value = model . AM283;
            parameter [ 173 ] . Value = model . AM284;
            parameter [ 174 ] . Value = model . AM285;
            parameter [ 175 ] . Value = model . AM286;
            parameter [ 176 ] . Value = model . AM287;
            parameter [ 177 ] . Value = model . AM288;
            parameter [ 178 ] . Value = model . AM289;
            parameter [ 179 ] . Value = model . AM290;
            parameter [ 180 ] . Value = model . AM291;
            parameter [ 181 ] . Value = model . AM292;
            parameter [ 182 ] . Value = model . AM293;
            parameter [ 183 ] . Value = model . AM294;
            parameter [ 184 ] . Value = model . AM295;
            parameter [ 185 ] . Value = model . AM296;
            parameter [ 186 ] . Value = model . AM297;
            parameter [ 187 ] . Value = model . AM298;
            parameter [ 188 ] . Value = model . AM299;
            parameter [ 189 ] . Value = model . AM300;
            parameter [ 190 ] . Value = model . AM301;
            parameter [ 191 ] . Value = model . AM302;
            parameter [ 192 ] . Value = model . AM303;
            parameter [ 193 ] . Value = model . AM304;
            parameter [ 194 ] . Value = model . AM305;
            parameter [ 195 ] . Value = model . AM306;
            parameter [ 196 ] . Value = model . AM307;
            parameter [ 197 ] . Value = model . AM308;
            parameter [ 198 ] . Value = model . AM309;
            parameter [ 199 ] . Value = model . AM311;
            parameter [ 200 ] . Value = model . AM312;
            parameter [ 201 ] . Value = model . AM313;
            //parameter[203].Value = model.AM314;
            parameter [ 202 ] . Value = model . AM315;
            parameter [ 203 ] . Value = model . AM316;
            parameter [ 204 ] . Value = model . AM317;
            parameter [ 205 ] . Value = model . AM318;
            parameter [ 206 ] . Value = model . AM319;
            parameter [ 207 ] . Value = model . AM320;
            parameter [ 208 ] . Value = model . AM321;
            parameter [ 209 ] . Value = model . AM322;
            parameter [ 210 ] . Value = model . AM323;
            parameter [ 211 ] . Value = model . AM324;
            parameter [ 212 ] . Value = model . AM325;
            parameter [ 213 ] . Value = model . AM326;
            parameter [ 214 ] . Value = model . AM327;
            parameter [ 215 ] . Value = model . AM328;
            parameter [ 216 ] . Value = model . AM329;
            parameter [ 217 ] . Value = model . AM330;
            parameter [ 218 ] . Value = model . AM331;
            parameter [ 219 ] . Value = model . AM332;
            parameter [ 220 ] . Value = model . AM333;
            parameter [ 221 ] . Value = model . AM334;
            parameter [ 222 ] . Value = model . AM335;
            parameter [ 223 ] . Value = model . AM336;
            parameter [ 224 ] . Value = model . AM337;
            parameter [ 225 ] . Value = model . AM338;
            parameter [ 226 ] . Value = model . AM339;
            parameter [ 227 ] . Value = model . AM340;
            parameter [ 228 ] . Value = model . AM341;
            parameter [ 229 ] . Value = model . AM343;
            parameter [ 230 ] . Value = model . AM344;
            parameter [ 231 ] . Value = model . AM345;
            parameter [ 232 ] . Value = model . AM346;
            parameter [ 233 ] . Value = model . AM347;
            parameter [ 234 ] . Value = model . AM348;
            parameter [ 235 ] . Value = model . AM349;
            parameter [ 236 ] . Value = model . AM350;
            parameter [ 237 ] . Value = model . AM351;
            parameter [ 238 ] . Value = model . AM352;
            parameter [ 239 ] . Value = model . AM353;
            parameter [ 240 ] . Value = model . AM354;
            parameter [ 241 ] . Value = model . AM355;
            parameter [ 242 ] . Value = model . AM356;
            parameter [ 243 ] . Value = model . AM357;
            parameter [ 244 ] . Value = model . AM358;
            parameter [ 245 ] . Value = model . AM359;
            parameter [ 246 ] . Value = model . AM360;
            parameter [ 247 ] . Value = model . AM361;
            parameter [ 248 ] . Value = model . AM362;
            parameter [ 249 ] . Value = model . AM363;
            parameter [ 250 ] . Value = model . AM364;
            parameter [ 251 ] . Value = model . AM365;
            parameter [ 252 ] . Value = model . AM366;
            parameter [ 253 ] . Value = model . AM367;
            parameter [ 254 ] . Value = model . AM368;
            parameter [ 255 ] . Value = model . AM369;
            parameter [ 256 ] . Value = model . AM370;
            parameter [ 257 ] . Value = model . AM371;
            parameter [ 258 ] . Value = model . AM372;
            parameter [ 259 ] . Value = model . AM373;
            parameter [ 260 ] . Value = model . AM374;
            parameter [ 261 ] . Value = model . AM375;
            parameter [ 262 ] . Value = model . AM376;
            parameter [ 263 ] . Value = model . AM377;
            parameter [ 264 ] . Value = model . AM378;
            parameter [ 265 ] . Value = model . AM379;
            parameter [ 266 ] . Value = model . AM380;
            parameter [ 267 ] . Value = model . AM381;
            parameter [ 268 ] . Value = model . AM382;
            parameter [ 269 ] . Value = model . AM383;
            parameter [ 270 ] . Value = model . AM385;
            parameter [ 271 ] . Value = model . AM386;
            parameter [ 272 ] . Value = model . AM387;
            parameter [ 273 ] . Value = model . AM388;
            parameter [ 274 ] . Value = model . AM389;
            parameter [ 275 ] . Value = model . AM390;
            parameter [ 276 ] . Value = model . AM391;
            parameter [ 277 ] . Value = model . AM392;
            parameter [ 278 ] . Value = model . AM393;
            parameter [ 279 ] . Value = model . AM020;
            parameter [ 280 ] . Value = model . AM021;
            parameter [ 281 ] . Value = model . AM022;
            parameter [ 282 ] . Value = model . AM023;
            parameter [ 283 ] . Value = model . AM024;
            parameter [ 284 ] . Value = model . AM025;
            parameter [ 285 ] . Value = model . AM026;
            parameter [ 286 ] . Value = model . AM027;
            parameter [ 287 ] . Value = model . AM028;
            parameter [ 288 ] . Value = model . AM029;
            parameter [ 289 ] . Value = model . AM062;
            parameter [ 290 ] . Value = model . AM063;
            parameter [ 291 ] . Value = model . AM173;
            parameter [ 292 ] . Value = model . AM225;
            parameter [ 293 ] . Value = model . AM226;
            parameter [ 294 ] . Value = model . AM227;
            parameter [ 295 ] . Value = model . AM228;
            parameter [ 296 ] . Value = model . AM229;
            parameter [ 297 ] . Value = model . AM230;
            parameter [ 298 ] . Value = model . AM231;
            parameter [ 299 ] . Value = model . AM232;
            parameter [ 300 ] . Value = model . AM233;
            parameter [ 301 ] . Value = model . AM234;
            parameter [ 302 ] . Value = model . AM235;
            parameter [ 303 ] . Value = model . AM236;
            parameter [ 304 ] . Value = model . AM237;
            parameter [ 305 ] . Value = model . AM238;
            parameter [ 306 ] . Value = model . AM255;
            parameter [ 307 ] . Value = model . AM256;
            parameter [ 308 ] . Value = model . AM153;
            parameter [ 309 ] . Value = model . AM154;
            parameter [ 310 ] . Value = model . AM155;
            parameter [ 311 ] . Value = model . AM156;
            parameter [ 312 ] . Value = model . AM157;
            parameter [ 313 ] . Value = model . AM158;
            parameter [ 314 ] . Value = model . AM248;
            parameter [ 315 ] . Value = model . Idx;

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

        public bool UpdateMain ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET " );
            strSql.Append( " AM002=@AM002," );
            strSql.Append( " AM003=@AM003," );
            strSql.Append( " AM004=@AM004," );
            strSql.Append( " AM005=@AM005," );
            strSql.Append( " AM006=@AM006," );
            strSql.Append( " AM007=@AM007," );
            strSql.Append( " AM008=@AM008," );
            strSql.Append( " AM009=@AM009," );
            strSql.Append( " AM010=@AM010," );
            strSql.Append( " AM011=@AM011," );
            strSql.Append( " AM012=@AM012," );
            strSql.Append( " AM013=@AM013," );
            strSql.Append( " AM014=@AM014," );
            strSql.Append( " AM015=@AM015," );
            strSql.Append( " AM016=@AM016," );
            strSql.Append( " AM017=@AM017," );
            strSql.Append( " AM018=@AM018," );
            strSql.Append( " AM019=@AM019" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
            new SqlParameter( "@AM002" ,SqlDbType.NVarChar ,20 ),
                new SqlParameter( "@AM003" ,SqlDbType.NVarChar ,20 ),
                new SqlParameter( "@AM004" ,SqlDbType.NVarChar ,20 ),
                new SqlParameter( "@AM005" ,SqlDbType.NVarChar ,20 ),
                new SqlParameter( "@AM006" ,SqlDbType.BigInt ),
                new SqlParameter( "@AM007" ,SqlDbType.Date ),
                new SqlParameter( "@AM008" ,SqlDbType.NVarChar ,20 ),
                new SqlParameter( "@AM009" ,SqlDbType.NVarChar ,20 ),
                new SqlParameter( "@AM010" ,SqlDbType.NVarChar ,20 ),
                new SqlParameter( "@AM011" ,SqlDbType.NVarChar ,20 ),
                new SqlParameter( "@AM012" ,SqlDbType.NChar ,10 ),
                new SqlParameter( "@AM013" ,SqlDbType.NVarChar ,20 ),
                new SqlParameter( "@AM014" ,SqlDbType.NVarChar ,20 ),
                new SqlParameter( "@AM015" ,SqlDbType.BigInt ),
                new SqlParameter( "@AM016" ,SqlDbType.Decimal ),
                new SqlParameter( "@AM017" ,SqlDbType.Decimal ),
                new SqlParameter( "@AM018" ,SqlDbType.Decimal ),
                new SqlParameter( "@AM019" ,SqlDbType.Decimal ),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = model.AM002;
            parameter[1].Value = model.AM003;
            parameter[2].Value = model.AM004;
            parameter[3].Value = model.AM005;
            parameter[4].Value = model.AM006;
            parameter[5].Value = model.AM007;
            parameter[6].Value = model.AM008;
            parameter[7].Value = model.AM009;
            parameter[8].Value = model.AM010;
            parameter[9].Value = model.AM011;
            parameter[10].Value = model.AM012;
            parameter[11].Value = model.AM013;
            parameter[12].Value = model.AM014;
            parameter[13].Value = model.AM015;
            parameter[14].Value = model.AM016;
            parameter[15].Value = model.AM017;
            parameter[16].Value = model.AM018;
            parameter[17].Value = model.AM019;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQAM " );
            strSql.Append( "WHERE idx=@idx" );

            SqlParameter[] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };

            parameter[0].Value = model.Idx;

            int rows = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( rows > 0 )
                return true;
            else
                return false;
        }



        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="idlist"></param>
        /// <returns></returns>
        public bool DeleteList ( string idlist )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQAM " );
            strSql.Append( "WHERE idx IN (" + idlist + ")" );

            int rows = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );

            if ( rows > 0 )
                return true;
            else
                return false;
        }


        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ProductCostSummaryLibrary GetModel ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQAM" );
            strSql.Append( " WHERE idx=@idx" );

            SqlParameter[] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };

            parameter[0].Value = idx;

            DataTable dt = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( dt.Rows.Count > 0 )
                return DataRowModel( dt.Rows[0] );
            else
                return null;
        }

        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ProductCostSummaryLibrary DataRowModel ( DataRow row )
        {
            MulaolaoLibrary.ProductCostSummaryLibrary model = new MulaolaoLibrary.ProductCostSummaryLibrary( );

            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    model.Idx = int.Parse( row["idx"].ToString( ) );
                if ( row["AM001"] != null && row["AM001"].ToString( ) != "" )
                    model.AM001 = row["AM001"].ToString( );
                if ( row["AM002"] != null && row["AM002"].ToString( ) != "" )
                    model.AM002 = row["AM002"].ToString( );
                if ( row["AM003"] != null && row["AM003"].ToString( ) != "" )
                    model.AM003 = row["AM003"].ToString( );
                if ( row["AM004"] != null && row["AM004"].ToString( ) != "" )
                    model.AM004 = row["AM004"].ToString( );
                if ( row["AM005"] != null && row["AM005"].ToString( ) != "" )
                    model.AM005 = row["AM005"].ToString( );
                if ( row["AM006"] != null && row["AM006"].ToString( ) != "" )
                    model.AM006 = long.Parse( row["AM006"].ToString( ) );
                if ( row["AM007"] != null && row["AM007"].ToString( ) != "" )
                    model.AM007 = DateTime.Parse( row["AM007"].ToString( ) );
                if ( row["AM008"] != null && row["AM008"].ToString( ) != "" )
                    model.AM008 = row["AM008"].ToString( );
                if ( row["AM009"] != null && row["AM009"].ToString( ) != "" )
                    model.AM009 = row["AM009"].ToString( );
                if ( row["AM010"] != null && row["AM010"].ToString( ) != "" )
                    model.AM010 = row["AM010"].ToString( );
                if ( row["AM011"] != null && row["AM011"].ToString( ) != "" )
                    model.AM011 = row["AM011"].ToString( );
                if ( row["AM012"] != null && row["AM012"].ToString( ) != "" )
                    model.AM012 = row["AM012"].ToString( );
                if ( row["AM013"] != null && row["AM013"].ToString( ) != "" )
                    model.AM013 = row["AM013"].ToString( );
                if ( row["AM014"] != null && row["AM014"].ToString( ) != "" )
                    model.AM014 = row["AM014"].ToString( );
                if ( row["AM015"] != null && row["AM015"].ToString( ) != "" )
                    model.AM015 = long.Parse( row["AM015"].ToString( ) );
                if ( row["AM016"] != null && row["AM016"].ToString( ) != "" )
                    model.AM016 = decimal.Parse( row["AM016"].ToString( ) );
                if ( row["AM017"] != null && row["AM017"].ToString( ) != "" )
                    model.AM017 = decimal.Parse( row["AM017"].ToString( ) );
                if ( row["AM018"] != null && row["AM018"].ToString( ) != "" )
                    model.AM018 = decimal.Parse( row["AM018"].ToString( ) );
                if ( row["AM019"] != null && row["AM019"].ToString( ) != "" )
                    model.AM019 = decimal.Parse( row["AM019"].ToString( ) );
                if ( row["AM020"] != null && row["AM020"].ToString( ) != "" )
                    model.AM020 = decimal.Parse( row["AM020"].ToString( ) );
                if ( row["AM021"] != null && row["AM021"].ToString( ) != "" )
                    model.AM021 = decimal.Parse( row["AM021"].ToString( ) );
                if ( row["AM022"] != null && row["AM022"].ToString( ) != "" )
                    model.AM022 = decimal.Parse( row["AM022"].ToString( ) );
                if ( row["AM023"] != null && row["AM023"].ToString( ) != "" )
                    model.AM023 = decimal.Parse( row["AM023"].ToString( ) );
                if ( row["AM024"] != null && row["AM024"].ToString( ) != "" )
                    model.AM024 = decimal.Parse( row["AM024"].ToString( ) );
                if ( row["AM025"] != null && row["AM025"].ToString( ) != "" )
                    model.AM025 = decimal.Parse( row["AM025"].ToString( ) );
                if ( row["AM026"] != null && row["AM026"].ToString( ) != "" )
                    model.AM026 = decimal.Parse( row["AM026"].ToString( ) );
                if ( row["AM027"] != null && row["AM027"].ToString( ) != "" )
                    model.AM027 = decimal.Parse( row["AM027"].ToString( ) );
                if ( row["AM028"] != null && row["AM028"].ToString( ) != "" )
                    model.AM028 = decimal.Parse( row["AM028"].ToString( ) );
                if ( row["AM029"] != null && row["AM029"].ToString( ) != "" )
                    model.AM029 = decimal.Parse( row["AM029"].ToString( ) );
                if ( row["AM044"] != null && row["AM044"].ToString( ) != "" )
                    model.AM044 = decimal.Parse( row["AM044"].ToString( ) );
                if ( row["AM045"] != null && row["AM045"].ToString( ) != "" )
                    model.AM045 = decimal.Parse( row["AM045"].ToString( ) );
                if ( row["AM046"] != null && row["AM046"].ToString( ) != "" )
                    model.AM046 = decimal.Parse( row["AM046"].ToString( ) );
                if ( row["AM047"] != null && row["AM047"].ToString( ) != "" )
                    model.AM047 = decimal.Parse( row["AM047"].ToString( ) );
                if ( row["AM048"] != null && row["AM048"].ToString( ) != "" )
                    model.AM048 = decimal.Parse( row["AM048"].ToString( ) );
                if ( row["AM049"] != null && row["AM049"].ToString( ) != "" )
                    model.AM049 = decimal.Parse( row["AM049"].ToString( ) );
                if ( row["AM050"] != null && row["AM050"].ToString( ) != "" )
                    model.AM050 = decimal.Parse( row["AM050"].ToString( ) );
                if ( row["AM051"] != null && row["AM051"].ToString( ) != "" )
                    model.AM051 = decimal.Parse( row["AM051"].ToString( ) );
                if ( row["AM052"] != null && row["AM052"].ToString( ) != "" )
                    model.AM052 = decimal.Parse( row["AM052"].ToString( ) );
                if ( row["AM053"] != null && row["AM053"].ToString( ) != "" )
                    model.AM053 = decimal.Parse( row["AM053"].ToString( ) );
                if ( row["AM054"] != null && row["AM054"].ToString( ) != "" )
                    model.AM054 = decimal.Parse( row["AM054"].ToString( ) );
                if ( row["AM055"] != null && row["AM055"].ToString( ) != "" )
                    model.AM055 = decimal.Parse( row["AM055"].ToString( ) );
                if ( row["AM056"] != null && row["AM056"].ToString( ) != "" )
                    model.AM056 = decimal.Parse( row["AM056"].ToString( ) );
                if ( row["AM057"] != null && row["AM057"].ToString( ) != "" )
                    model.AM057 = decimal.Parse( row["AM057"].ToString( ) );
                if ( row["AM058"] != null && row["AM058"].ToString( ) != "" )
                    model.AM058 = decimal.Parse( row["AM058"].ToString( ) );
                if ( row["AM059"] != null && row["AM059"].ToString( ) != "" )
                    model.AM059 = decimal.Parse( row["AM059"].ToString( ) );
                if ( row["AM060"] != null && row["AM060"].ToString( ) != "" )
                    model.AM060 = decimal.Parse( row["AM060"].ToString( ) );
                if ( row["AM061"] != null && row["AM061"].ToString( ) != "" )
                    model.AM061 = decimal.Parse( row["AM061"].ToString( ) );
                if ( row["AM070"] != null && row["AM070"].ToString( ) != "" )
                    model.AM070 = decimal.Parse( row["AM070"].ToString( ) );
                if ( row["AM071"] != null && row["AM071"].ToString( ) != "" )
                    model.AM071 = decimal.Parse( row["AM071"].ToString( ) );
                if ( row["AM072"] != null && row["AM072"].ToString( ) != "" )
                    model.AM072 = decimal.Parse( row["AM072"].ToString( ) );
                if ( row["AM073"] != null && row["AM073"].ToString( ) != "" )
                    model.AM073 = decimal.Parse( row["AM073"].ToString( ) );
                if ( row["AM074"] != null && row["AM074"].ToString( ) != "" )
                    model.AM074 = decimal.Parse( row["AM074"].ToString( ) );
                if ( row["AM075"] != null && row["AM075"].ToString( ) != "" )
                    model.AM075 = decimal.Parse( row["AM075"].ToString( ) );
                if ( row["AM076"] != null && row["AM076"].ToString( ) != "" )
                    model.AM076 = decimal.Parse( row["AM076"].ToString( ) );
                if ( row["AM077"] != null && row["AM077"].ToString( ) != "" )
                    model.AM077 = decimal.Parse( row["AM077"].ToString( ) );
                if ( row["AM078"] != null && row["AM078"].ToString( ) != "" )
                    model.AM078 = decimal.Parse( row["AM078"].ToString( ) );
                if ( row["AM079"] != null && row["AM079"].ToString( ) != "" )
                    model.AM079 = decimal.Parse( row["AM079"].ToString( ) );
                if ( row["AM080"] != null && row["AM080"].ToString( ) != "" )
                    model.AM080 = decimal.Parse( row["AM080"].ToString( ) );
                if ( row["AM081"] != null && row["AM081"].ToString( ) != "" )
                    model.AM081 = decimal.Parse( row["AM081"].ToString( ) );
                if ( row["AM082"] != null && row["AM082"].ToString( ) != "" )
                    model.AM082 = decimal.Parse( row["AM082"].ToString( ) );
                if ( row["AM083"] != null && row["AM083"].ToString( ) != "" )
                    model.AM083 = decimal.Parse( row["AM083"].ToString( ) );
                if ( row["AM084"] != null && row["AM084"].ToString( ) != "" )
                    model.AM084 = decimal.Parse( row["AM084"].ToString( ) );
                if ( row["AM085"] != null && row["AM085"].ToString( ) != "" )
                    model.AM085 = decimal.Parse( row["AM085"].ToString( ) );
                if ( row["AM086"] != null && row["AM086"].ToString( ) != "" )
                    model.AM086 = decimal.Parse( row["AM086"].ToString( ) );
                if ( row["AM087"] != null && row["AM087"].ToString( ) != "" )
                    model.AM087 = decimal.Parse( row["AM087"].ToString( ) );
                if ( row["AM088"] != null && row["AM088"].ToString( ) != "" )
                    model.AM088 = decimal.Parse( row["AM088"].ToString( ) );
                if ( row["AM089"] != null && row["AM089"].ToString( ) != "" )
                    model.AM089 = decimal.Parse( row["AM089"].ToString( ) );
                if ( row["AM090"] != null && row["AM090"].ToString( ) != "" )
                    model.AM090 = decimal.Parse( row["AM090"].ToString( ) );
                if ( row["AM091"] != null && row["AM091"].ToString( ) != "" )
                    model.AM091 = decimal.Parse( row["AM091"].ToString( ) );
                if ( row["AM092"] != null && row["AM092"].ToString( ) != "" )
                    model.AM092 = decimal.Parse( row["AM092"].ToString( ) );
                if ( row["AM093"] != null && row["AM093"].ToString( ) != "" )
                    model.AM093 = decimal.Parse( row["AM093"].ToString( ) );         
                if ( row["AM108"] != null && row["AM108"].ToString( ) != "" )
                    model.AM108 = decimal.Parse( row["AM108"].ToString( ) );
                if ( row["AM109"] != null && row["AM109"].ToString( ) != "" )
                    model.AM109 = decimal.Parse( row["AM109"].ToString( ) );
                if ( row["AM110"] != null && row["AM110"].ToString( ) != "" )
                    model.AM110 = decimal.Parse( row["AM110"].ToString( ) );
                if ( row["AM111"] != null && row["AM111"].ToString( ) != "" )
                    model.AM111 = decimal.Parse( row["AM111"].ToString( ) );
                if ( row["AM112"] != null && row["AM112"].ToString( ) != "" )
                    model.AM112 = decimal.Parse( row["AM112"].ToString( ) );
                if ( row["AM113"] != null && row["AM113"].ToString( ) != "" )
                    model.AM113 = decimal.Parse( row["AM113"].ToString( ) );
                //if ( row["AM114"] != null && row["AM114"].ToString( ) != "" )
                //    model.AM114 = row["AM114"].ToString( );
                if ( row["AM130"] != null && row["AM130"].ToString( ) != "" )
                    model.AM130 = decimal.Parse( row["AM130"].ToString( ) );
                if ( row["AM131"] != null && row["AM131"].ToString( ) != "" )
                    model.AM131 = decimal.Parse( row["AM131"].ToString( ) );
                if ( row["AM133"] != null && row["AM133"].ToString( ) != "" )
                    model.AM133 = decimal.Parse( row["AM133"].ToString( ) );
                if ( row["AM134"] != null && row["AM134"].ToString( ) != "" )
                    model.AM134 = decimal.Parse( row["AM134"].ToString( ) );
                if ( row["AM135"] != null && row["AM135"].ToString( ) != "" )
                    model.AM135 = decimal.Parse( row["AM135"].ToString( ) );
                if ( row["AM136"] != null && row["AM136"].ToString( ) != "" )
                    model.AM136 = decimal.Parse( row["AM136"].ToString( ) );
                if ( row["AM137"] != null && row["AM137"].ToString( ) != "" )
                    model.AM137 = decimal.Parse( row["AM137"].ToString( ) );
                if ( row["AM138"] != null && row["AM138"].ToString( ) != "" )
                    model.AM138 = decimal.Parse( row["AM138"].ToString( ) );
                if ( row["AM139"] != null && row["AM139"].ToString( ) != "" )
                    model.AM139 = decimal.Parse( row["AM139"].ToString( ) );
                if ( row["AM140"] != null && row["AM140"].ToString( ) != "" )
                    model.AM140 = decimal.Parse( row["AM140"].ToString( ) );
                if ( row["AM141"] != null && row["AM141"].ToString( ) != "" )
                    model.AM141 = decimal.Parse( row["AM141"].ToString( ) );
                if ( row["AM142"] != null && row["AM142"].ToString( ) != "" )
                    model.AM142 = decimal.Parse( row["AM142"].ToString( ) );
                if ( row["AM143"] != null && row["AM143"].ToString( ) != "" )
                    model.AM143 = decimal.Parse( row["AM143"].ToString( ) );
                if ( row["AM144"] != null && row["AM144"].ToString( ) != "" )
                    model.AM144 = decimal.Parse( row["AM144"].ToString( ) );
                if ( row["AM145"] != null && row["AM145"].ToString( ) != "" )
                    model.AM145 = decimal.Parse( row["AM145"].ToString( ) );
                if ( row["AM146"] != null && row["AM146"].ToString( ) != "" )
                    model.AM146 = decimal.Parse( row["AM146"].ToString( ) );
                if ( row["AM147"] != null && row["AM147"].ToString( ) != "" )
                    model.AM147 = decimal.Parse( row["AM147"].ToString( ) );
                if ( row["AM148"] != null && row["AM148"].ToString( ) != "" )
                    model.AM148 = decimal.Parse( row["AM148"].ToString( ) );
                if ( row["AM149"] != null && row["AM149"].ToString( ) != "" )
                    model.AM149 = decimal.Parse( row["AM149"].ToString( ) );
                if ( row["AM150"] != null && row["AM150"].ToString( ) != "" )
                    model.AM150 = decimal.Parse( row["AM150"].ToString( ) );
                if ( row["AM151"] != null && row["AM151"].ToString( ) != "" )
                    model.AM151 = decimal.Parse( row["AM151"].ToString( ) );
                if ( row["AM152"] != null && row["AM152"].ToString( ) != "" )
                    model.AM152 = decimal.Parse( row["AM152"].ToString( ) );
                //if ( row["AM153"] != null && row["AM153"].ToString( ) != "" )
                //    model.AM153 = row["AM153"].ToString( );
                if ( row["AM175"] != null && row["AM175"].ToString( ) != "" )
                    model.AM175 = decimal.Parse( row["AM175"].ToString( ) );
                if ( row["AM176"] != null && row["AM176"].ToString( ) != "" )
                    model.AM176 = decimal.Parse( row["AM176"].ToString( ) );
                if ( row["AM177"] != null && row["AM177"].ToString( ) != "" )
                    model.AM177 = decimal.Parse( row["AM177"].ToString( ) );
                if ( row["AM178"] != null && row["AM178"].ToString( ) != "" )
                    model.AM178 = decimal.Parse( row["AM178"].ToString( ) );
                if ( row["AM179"] != null && row["AM179"].ToString( ) != "" )
                    model.AM179 = decimal.Parse( row["AM179"].ToString( ) );
                if ( row["AM180"] != null && row["AM180"].ToString( ) != "" )
                    model.AM180 = decimal.Parse( row["AM180"].ToString( ) );
                //if ( row["AM181"] != null && row["AM181"].ToString( ) != "" )
                //    model.AM181 = row["AM181"].ToString( );
                if ( row["AM182"] != null && row["AM182"].ToString( ) != "" )
                    model.AM182 = decimal.Parse( row["AM182"].ToString( ) );
                if ( row["AM183"] != null && row["AM183"].ToString( ) != "" )
                    model.AM183 = decimal.Parse( row["AM183"].ToString( ) );
                if ( row["AM184"] != null && row["AM184"].ToString( ) != "" )
                    model.AM184 = decimal.Parse( row["AM184"].ToString( ) );
                if ( row["AM185"] != null && row["AM185"].ToString( ) != "" )
                    model.AM185 = decimal.Parse( row["AM185"].ToString( ) );
                if ( row["AM186"] != null && row["AM186"].ToString( ) != "" )
                    model.AM186 = decimal.Parse( row["AM186"].ToString( ) );
                if ( row["AM187"] != null && row["AM187"].ToString( ) != "" )
                    model.AM187 = decimal.Parse( row["AM187"].ToString( ) );
                if ( row["AM188"] != null && row["AM188"].ToString( ) != "" )
                    model.AM188 = decimal.Parse( row["AM188"].ToString( ) );
                if ( row["AM189"] != null && row["AM189"].ToString( ) != "" )
                    model.AM189 = decimal.Parse( row["AM189"].ToString( ) );
                if ( row["AM190"] != null && row["AM190"].ToString( ) != "" )
                    model.AM190 = decimal.Parse( row["AM190"].ToString( ) );
                if ( row["AM191"] != null && row["AM191"].ToString( ) != "" )
                    model.AM191 = decimal.Parse( row["AM191"].ToString( ) );
                if ( row["AM192"] != null && row["AM192"].ToString( ) != "" )
                    model.AM192 = decimal.Parse( row["AM192"].ToString( ) );
                if ( row["AM193"] != null && row["AM193"].ToString( ) != "" )
                    model.AM193 = decimal.Parse( row["AM193"].ToString( ) );
                if ( row["AM196"] != null && row["AM196"].ToString( ) != "" )
                    model.AM196 = decimal.Parse( row["AM196"].ToString( ) );
                if ( row["AM199"] != null && row["AM199"].ToString( ) != "" )
                    model.AM199 = decimal.Parse( row["AM199"].ToString( ) );
                if ( row["AM200"] != null && row["AM200"].ToString( ) != "" )
                    model.AM200 = decimal.Parse( row["AM200"].ToString( ) );
                if ( row["AM201"] != null && row["AM201"].ToString( ) != "" )
                    model.AM201 = decimal.Parse( row["AM201"].ToString( ) );
                if ( row["AM203"] != null && row["AM203"].ToString( ) != "" )
                    model.AM203 = decimal.Parse( row["AM203"].ToString( ) );
                if ( row["AM204"] != null && row["AM204"].ToString( ) != "" )
                    model.AM204 = decimal.Parse( row["AM204"].ToString( ) );
                if ( row["AM205"] != null && row["AM205"].ToString( ) != "" )
                    model.AM205 = decimal.Parse( row["AM205"].ToString( ) );
                if ( row["AM206"] != null && row["AM206"].ToString( ) != "" )
                    model.AM206 = decimal.Parse( row["AM206"].ToString( ) );
                if ( row["AM207"] != null && row["AM207"].ToString( ) != "" )
                    model.AM207 = decimal.Parse( row["AM207"].ToString( ) );
                if ( row["AM208"] != null && row["AM208"].ToString( ) != "" )
                    model.AM208 = decimal.Parse( row["AM208"].ToString( ) );
                if ( row["AM209"] != null && row["AM209"].ToString( ) != "" )
                    model.AM209 = decimal.Parse( row["AM209"].ToString( ) );
                if ( row["AM210"] != null && row["AM210"].ToString( ) != "" )
                    model.AM210 = decimal.Parse( row["AM210"].ToString( ) );
                if ( row["AM211"] != null && row["AM211"].ToString( ) != "" )
                    model.AM211 = decimal.Parse( row["AM211"].ToString( ) );
                if ( row["AM212"] != null && row["AM212"].ToString( ) != "" )
                    model.AM212 = decimal.Parse( row["AM212"].ToString( ) );
                if ( row["AM213"] != null && row["AM213"].ToString( ) != "" )
                    model.AM213 = decimal.Parse( row["AM213"].ToString( ) );
                if ( row["AM214"] != null && row["AM214"].ToString( ) != "" )
                    model.AM214 = decimal.Parse( row["AM214"].ToString( ) );
                if ( row["AM215"] != null && row["AM215"].ToString( ) != "" )
                    model.AM215 = decimal.Parse( row["AM215"].ToString( ) );
                if ( row["AM216"] != null && row["AM216"].ToString( ) != "" )
                    model.AM216 = decimal.Parse( row["AM216"].ToString( ) );
                if ( row["AM217"] != null && row["AM217"].ToString( ) != "" )
                    model.AM217 = decimal.Parse( row["AM217"].ToString( ) );
                if ( row["AM218"] != null && row["AM218"].ToString( ) != "" )
                    model.AM218 = decimal.Parse( row["AM218"].ToString( ) );
                if ( row["AM219"] != null && row["AM219"].ToString( ) != "" )
                    model.AM219 = decimal.Parse( row["AM219"].ToString( ) );
                if ( row["AM220"] != null && row["AM220"].ToString( ) != "" )
                    model.AM220 = decimal.Parse( row["AM220"].ToString( ) );
                if ( row["AM221"] != null && row["AM221"].ToString( ) != "" )
                    model.AM221 = decimal.Parse( row["AM221"].ToString( ) );
                if ( row["AM222"] != null && row["AM222"].ToString( ) != "" )
                    model.AM222 = decimal.Parse( row["AM222"].ToString( ) );
                if ( row["AM223"] != null && row["AM223"].ToString( ) != "" )
                    model.AM223 = decimal.Parse( row["AM223"].ToString( ) );
                if ( row["AM224"] != null && row["AM224"].ToString( ) != "" )
                    model.AM224 = decimal.Parse( row["AM224"].ToString( ) );
                if ( row["AM239"] != null && row["AM239"].ToString( ) != "" )
                    model.AM239 = decimal.Parse( row["AM239"].ToString( ) );
                if ( row["AM240"] != null && row["AM240"].ToString( ) != "" )
                    model.AM240 = decimal.Parse( row["AM240"].ToString( ) );
                if ( row["AM241"] != null && row["AM241"].ToString( ) != "" )
                    model.AM241 = decimal.Parse( row["AM241"].ToString( ) );
                if ( row["AM242"] != null && row["AM242"].ToString( ) != "" )
                    model.AM242 = decimal.Parse( row["AM242"].ToString( ) );
                if ( row["AM243"] != null && row["AM243"].ToString( ) != "" )
                    model.AM243 = decimal.Parse( row["AM243"].ToString( ) );
                if ( row["AM244"] != null && row["AM244"].ToString( ) != "" )
                    model.AM244 = decimal.Parse( row["AM244"].ToString( ) );
                if ( row["AM245"] != null && row["AM245"].ToString( ) != "" )
                    model.AM245 = decimal.Parse( row["AM245"].ToString( ) );
                if ( row["AM246"] != null && row["AM246"].ToString( ) != "" )
                    model.AM246 = decimal.Parse( row["AM246"].ToString( ) );
                if ( row["AM247"] != null && row["AM247"].ToString( ) != "" )
                    model.AM247 = decimal.Parse( row["AM247"].ToString( ) );
                if ( row [ "AM248" ] != null && row [ "AM248" ] . ToString ( ) != "" )
                    model . AM248 = Decimal . Parse ( row [ "AM248" ] . ToString ( ) );
                if ( row["AM249"] != null && row["AM249"].ToString( ) != "" )
                    model.AM249 = decimal.Parse( row["AM249"].ToString( ) );
                if ( row["AM250"] != null && row["AM250"].ToString( ) != "" )
                    model.AM250 = decimal.Parse( row["AM250"].ToString( ) );
                if ( row["AM251"] != null && row["AM251"].ToString( ) != "" )
                    model.AM251 = decimal.Parse( row["AM251"].ToString( ) );
                if ( row["AM252"] != null && row["AM252"].ToString( ) != "" )
                    model.AM252 = decimal.Parse( row["AM252"].ToString( ) );
                if ( row["AM253"] != null && row["AM253"].ToString( ) != "" )
                    model.AM253 = decimal.Parse( row["AM253"].ToString( ) );
                if ( row["AM261"] != null && row["AM261"].ToString( ) != "" )
                    model.AM261 = decimal.Parse( row["AM261"].ToString( ) );
                if ( row["AM262"] != null && row["AM262"].ToString( ) != "" )
                    model.AM262 = decimal.Parse( row["AM262"].ToString( ) );
                if ( row["AM263"] != null && row["AM263"].ToString( ) != "" )
                    model.AM263 = decimal.Parse( row["AM263"].ToString( ) );
                if ( row["AM264"] != null && row["AM264"].ToString( ) != "" )
                    model.AM264 = decimal.Parse( row["AM264"].ToString( ) );
                if ( row["AM265"] != null && row["AM265"].ToString( ) != "" )
                    model.AM265 = decimal.Parse( row["AM265"].ToString( ) );
                if ( row["AM266"] != null && row["AM266"].ToString( ) != "" )
                    model.AM266 = decimal.Parse( row["AM266"].ToString( ) );
                if ( row["AM267"] != null && row["AM267"].ToString( ) != "" )
                    model.AM267 = decimal.Parse( row["AM267"].ToString( ) );
                if ( row["AM268"] != null && row["AM268"].ToString( ) != "" )
                    model.AM268 = decimal.Parse( row["AM268"].ToString( ) );
                if ( row["AM269"] != null && row["AM269"].ToString( ) != "" )
                    model.AM269 = decimal.Parse( row["AM269"].ToString( ) );
                if ( row["AM270"] != null && row["AM270"].ToString( ) != "" )
                    model.AM270 = decimal.Parse( row["AM270"].ToString( ) );
                if ( row["AM271"] != null && row["AM271"].ToString( ) != "" )
                    model.AM271 = decimal.Parse( row["AM271"].ToString( ) );
                if ( row["AM272"] != null && row["AM272"].ToString( ) != "" )
                    model.AM272 = decimal.Parse( row["AM272"].ToString( ) );
                if ( row["AM273"] != null && row["AM273"].ToString( ) != "" )
                    model.AM273 = decimal.Parse( row["AM273"].ToString( ) );
                if ( row["AM274"] != null && row["AM274"].ToString( ) != "" )
                    model.AM274 = decimal.Parse( row["AM274"].ToString( ) );
                if ( row["AM275"] != null && row["AM275"].ToString( ) != "" )
                    model.AM275 = decimal.Parse( row["AM275"].ToString( ) );
                if ( row["AM276"] != null && row["AM276"].ToString( ) != "" )
                    model.AM276 = row["AM276"].ToString( );
                if ( row["AM277"] != null && row["AM277"].ToString( ) != "" )
                    model.AM277 = decimal.Parse( row["AM277"].ToString( ) );
                if ( row["AM278"] != null && row["AM278"].ToString( ) != "" )
                    model.AM278 = decimal.Parse( row["AM278"].ToString( ) );
                if ( row["AM279"] != null && row["AM279"].ToString( ) != "" )
                    model.AM279 = decimal.Parse( row["AM279"].ToString( ) );
                if ( row["AM280"] != null && row["AM280"].ToString( ) != "" )
                    model.AM280 = decimal.Parse( row["AM280"].ToString( ) );
                if ( row["AM281"] != null && row["AM281"].ToString( ) != "" )
                    model.AM281 = decimal.Parse( row["AM281"].ToString( ) );
                if ( row["AM282"] != null && row["AM282"].ToString( ) != "" )
                    model.AM282 = decimal.Parse( row["AM282"].ToString( ) );
                if ( row["AM283"] != null && row["AM283"].ToString( ) != "" )
                    model.AM283 = decimal.Parse( row["AM283"].ToString( ) );
                if ( row["AM284"] != null && row["AM284"].ToString( ) != "" )
                    model.AM284 = decimal.Parse( row["AM284"].ToString( ) );
                if ( row["AM285"] != null && row["AM285"].ToString( ) != "" )
                    model.AM285 = decimal.Parse( row["AM285"].ToString( ) );
                if ( row["AM286"] != null && row["AM286"].ToString( ) != "" )
                    model.AM286 = decimal.Parse( row["AM286"].ToString( ) );
                if ( row["AM287"] != null && row["AM287"].ToString( ) != "" )
                    model.AM287 = decimal.Parse( row["AM287"].ToString( ) );
                if ( row["AM288"] != null && row["AM288"].ToString( ) != "" )
                    model.AM288 = decimal.Parse( row["AM288"].ToString( ) );
                if ( row["AM289"] != null && row["AM289"].ToString( ) != "" )
                    model.AM289 = decimal.Parse( row["AM289"].ToString( ) );
                if ( row["AM290"] != null && row["AM290"].ToString( ) != "" )
                    model.AM290 = decimal.Parse( row["AM290"].ToString( ) );
                if ( row["AM291"] != null && row["AM291"].ToString( ) != "" )
                    model.AM291 = decimal.Parse( row["AM291"].ToString( ) );
                if ( row["AM292"] != null && row["AM292"].ToString( ) != "" )
                    model.AM292 = decimal.Parse( row["AM292"].ToString( ) );
                if ( row["AM293"] != null && row["AM293"].ToString( ) != "" )
                    model.AM293 = decimal.Parse( row["AM293"].ToString( ) );
                if ( row["AM294"] != null && row["AM294"].ToString( ) != "" )
                    model.AM294 = decimal.Parse( row["AM294"].ToString( ) );
                if ( row["AM295"] != null && row["AM295"].ToString( ) != "" )
                    model.AM295 = decimal.Parse( row["AM295"].ToString( ) );
                if ( row["AM296"] != null && row["AM296"].ToString( ) != "" )
                    model.AM296 = decimal.Parse( row["AM296"].ToString( ) );
                if ( row["AM297"] != null && row["AM297"].ToString( ) != "" )
                    model.AM297 = decimal.Parse( row["AM297"].ToString( ) );
                if ( row["AM298"] != null && row["AM298"].ToString( ) != "" )
                    model.AM298 = decimal.Parse( row["AM298"].ToString( ) );
                if ( row["AM299"] != null && row["AM299"].ToString( ) != "" )
                    model.AM299 = decimal.Parse( row["AM299"].ToString( ) );
                if ( row["AM300"] != null && row["AM300"].ToString( ) != "" )
                    model.AM300 = decimal.Parse( row["AM300"].ToString( ) );
                if ( row["AM301"] != null && row["AM301"].ToString( ) != "" )
                    model.AM301 = decimal.Parse( row["AM301"].ToString( ) );
                if ( row["AM302"] != null && row["AM302"].ToString( ) != "" )
                    model.AM302 = decimal.Parse( row["AM302"].ToString( ) );
                if ( row["AM303"] != null && row["AM303"].ToString( ) != "" )
                    model.AM303 = decimal.Parse( row["AM303"].ToString( ) );
                if ( row["AM304"] != null && row["AM304"].ToString( ) != "" )
                    model.AM304 = decimal.Parse( row["AM304"].ToString( ) );
                if ( row["AM305"] != null && row["AM305"].ToString( ) != "" )
                    model.AM305 = decimal.Parse( row["AM305"].ToString( ) );
                if ( row["AM306"] != null && row["AM306"].ToString( ) != "" )
                    model.AM306 = decimal.Parse( row["AM306"].ToString( ) );
                if ( row["AM307"] != null && row["AM307"].ToString( ) != "" )
                    model.AM307 = decimal.Parse( row["AM307"].ToString( ) );
                if ( row["AM308"] != null && row["AM308"].ToString( ) != "" )
                    model.AM308 = decimal.Parse( row["AM308"].ToString( ) );
                if ( row["AM309"] != null && row["AM309"].ToString( ) != "" )
                    model.AM309 = decimal.Parse( row["AM309"].ToString( ) );
                if ( row["AM310"] != null && row["AM310"].ToString( ) != "" )
                    model.AM310 = row["AM310"].ToString( );
                if ( row["AM311"] != null && row["AM311"].ToString( ) != "" )
                    model.AM311 = decimal.Parse( row["AM311"].ToString( ) );
                if ( row["AM312"] != null && row["AM312"].ToString( ) != "" )
                    model.AM312 = decimal.Parse( row["AM312"].ToString( ) );
                if ( row["AM313"] != null && row["AM313"].ToString( ) != "" )
                    model.AM313 = decimal.Parse( row["AM313"].ToString( ) );
                if ( row["AM314"] != null && row["AM314"].ToString( ) != "" )
                    model.AM314 = row["AM314"].ToString( );
                if ( row["AM315"] != null && row["AM315"].ToString( ) != "" )
                    model.AM315 = decimal.Parse( row["AM315"].ToString( ) );
                if ( row["AM316"] != null && row["AM316"].ToString( ) != "" )
                    model.AM316 = decimal.Parse( row["AM316"].ToString( ) );
                if ( row["AM317"] != null && row["AM317"].ToString( ) != "" )
                    model.AM317 = decimal.Parse( row["AM317"].ToString( ) );
                if ( row["AM318"] != null && row["AM318"].ToString( ) != "" )
                    model.AM318 = decimal.Parse( row["AM318"].ToString( ) );
                if ( row["AM319"] != null && row["AM319"].ToString( ) != "" )
                    model.AM319 = decimal.Parse( row["AM319"].ToString( ) );
                if ( row["AM320"] != null && row["AM320"].ToString( ) != "" )
                    model.AM320 = decimal.Parse( row["AM320"].ToString( ) );
                if ( row["AM321"] != null && row["AM321"].ToString( ) != "" )
                    model.AM321 = decimal.Parse( row["AM321"].ToString( ) );
                if ( row["AM322"] != null && row["AM322"].ToString( ) != "" )
                    model.AM322 = decimal.Parse( row["AM322"].ToString( ) );
                if ( row["AM323"] != null && row["AM323"].ToString( ) != "" )
                    model.AM323 = decimal.Parse( row["AM323"].ToString( ) );
                if ( row["AM324"] != null && row["AM324"].ToString( ) != "" )
                    model.AM324 = decimal.Parse( row["AM324"].ToString( ) );
                if ( row["AM325"] != null && row["AM325"].ToString( ) != "" )
                    model.AM325 = decimal.Parse( row["AM325"].ToString( ) );
                if ( row["AM326"] != null && row["AM326"].ToString( ) != "" )
                    model.AM326 = decimal.Parse( row["AM326"].ToString( ) );
                if ( row["AM327"] != null && row["AM327"].ToString( ) != "" )
                    model.AM327 = decimal.Parse( row["AM327"].ToString( ) );
                if ( row["AM328"] != null && row["AM328"].ToString( ) != "" )
                    model.AM328 = decimal.Parse( row["AM328"].ToString( ) );
                if ( row["AM329"] != null && row["AM329"].ToString( ) != "" )
                    model.AM329 = decimal.Parse( row["AM329"].ToString( ) );
                if ( row["AM330"] != null && row["AM330"].ToString( ) != "" )
                    model.AM330 = decimal.Parse( row["AM336"].ToString( ) );
                if ( row["AM331"] != null && row["AM331"].ToString( ) != "" )
                    model.AM331 = decimal.Parse( row["AM331"].ToString( ) );
                if ( row["AM332"] != null && row["AM332"].ToString( ) != "" )
                    model.AM332 = decimal.Parse( row["AM332"].ToString( ) );
                if ( row["AM333"] != null && row["AM333"].ToString( ) != "" )
                    model.AM333 = decimal.Parse( row["AM333"].ToString( ) );
                if ( row["AM334"] != null && row["AM334"].ToString( ) != "" )
                    model.AM334 = decimal.Parse( row["AM334"].ToString( ) );
                if ( row["AM335"] != null && row["AM335"].ToString( ) != "" )
                    model.AM335 = decimal.Parse( row["AM335"].ToString( ) );
                if ( row["AM336"] != null && row["AM336"].ToString( ) != "" )
                    model.AM336 = decimal.Parse( row["AM336"].ToString( ) );
                if ( row["AM337"] != null && row["AM337"].ToString( ) != "" )
                    model.AM337 = decimal.Parse( row["AM337"].ToString( ) );
                if ( row["AM338"] != null && row["AM338"].ToString( ) != "" )
                    model.AM338 = decimal.Parse( row["AM338"].ToString( ) );
                if ( row["AM339"] != null && row["AM339"].ToString( ) != "" )
                    model.AM339 = decimal.Parse( row["AM339"].ToString( ) );
                if ( row["AM340"] != null && row["AM340"].ToString( ) != "" )
                    model.AM340 = decimal.Parse( row["AM340"].ToString( ) );
                if ( row["AM341"] != null && row["AM341"].ToString( ) != "" )
                    model.AM341 = decimal.Parse( row["AM341"].ToString( ) );
                if ( row["AM342"] != null && row["AM342"].ToString( ) != "" )
                    model.AM342 = row["AM342"].ToString( );
                if ( row["AM343"] != null && row["AM343"].ToString( ) != "" )
                    model.AM343 = decimal.Parse( row["AM343"].ToString( ) );
                if ( row["AM344"] != null && row["AM344"].ToString( ) != "" )
                    model.AM344 = decimal.Parse( row["AM344"].ToString( ) );
                if ( row["AM345"] != null && row["AM345"].ToString( ) != "" )
                    model.AM345 = decimal.Parse( row["AM345"].ToString( ) );
                if ( row["AM346"] != null && row["AM346"].ToString( ) != "" )
                    model.AM346 = decimal.Parse( row["AM346"].ToString( ) );
                if ( row["AM347"] != null && row["AM347"].ToString( ) != "" )
                    model.AM347 = decimal.Parse( row["AM347"].ToString( ) );
                if ( row["AM348"] != null && row["AM348"].ToString( ) != "" )
                    model.AM348 = decimal.Parse( row["AM348"].ToString( ) );
                if ( row["AM349"] != null && row["AM349"].ToString( ) != "" )
                    model.AM349 = decimal.Parse( row["AM349"].ToString( ) );
                if ( row["AM350"] != null && row["AM350"].ToString( ) != "" )
                    model.AM350 = decimal.Parse( row["AM350"].ToString( ) );
                if ( row["AM351"] != null && row["AM351"].ToString( ) != "" )
                    model.AM351 = decimal.Parse( row["AM351"].ToString( ) );
                if ( row["AM352"] != null && row["AM352"].ToString( ) != "" )
                    model.AM352 = decimal.Parse( row["AM352"].ToString( ) );
                if ( row["AM353"] != null && row["AM353"].ToString( ) != "" )
                    model.AM353 = decimal.Parse( row["AM353"].ToString( ) );
                if ( row["AM354"] != null && row["AM354"].ToString( ) != "" )
                    model.AM354 = decimal.Parse( row["AM354"].ToString( ) );
                if ( row["AM355"] != null && row["AM355"].ToString( ) != "" )
                    model.AM355 = decimal.Parse( row["AM355"].ToString( ) );
                if ( row["AM356"] != null && row["AM356"].ToString( ) != "" )
                    model.AM356 = decimal.Parse( row["AM356"].ToString( ) );
                if ( row["AM357"] != null && row["AM357"].ToString( ) != "" )
                    model.AM354 = decimal.Parse( row["AM357"].ToString( ) );
                if ( row["AM358"] != null && row["AM358"].ToString( ) != "" )
                    model.AM358 = decimal.Parse( row["AM358"].ToString( ) );
                if ( row["AM359"] != null && row["AM359"].ToString( ) != "" )
                    model.AM359 = decimal.Parse( row["AM359"].ToString( ) );
                if ( row["AM360"] != null && row["AM360"].ToString( ) != "" )
                    model.AM360 = decimal.Parse( row["AM360"].ToString( ) );
                if ( row["AM361"] != null && row["AM361"].ToString( ) != "" )
                    model.AM361 = decimal.Parse( row["AM361"].ToString( ) );
                if ( row["AM362"] != null && row["AM362"].ToString( ) != "" )
                    model.AM362 = decimal.Parse( row["AM362"].ToString( ) );
                if ( row["AM363"] != null && row["AM363"].ToString( ) != "" )
                    model.AM363 = decimal.Parse( row["AM363"].ToString( ) );
                if ( row["AM364"] != null && row["AM364"].ToString( ) != "" )
                    model.AM364 = decimal.Parse( row["AM364"].ToString( ) );
                if ( row["AM365"] != null && row["AM365"].ToString( ) != "" )
                    model.AM365 = decimal.Parse( row["AM365"].ToString( ) );
                if ( row["AM366"] != null && row["AM366"].ToString( ) != "" )
                    model.AM366 = decimal.Parse( row["AM366"].ToString( ) );
                if ( row["AM367"] != null && row["AM367"].ToString( ) != "" )
                    model.AM367 = decimal.Parse( row["AM367"].ToString( ) );
                if ( row["AM368"] != null && row["AM368"].ToString( ) != "" )
                    model.AM368 = decimal.Parse( row["AM368"].ToString( ) );
                if ( row["AM369"] != null && row["AM369"].ToString( ) != "" )
                    model.AM369 = decimal.Parse( row["AM369"].ToString( ) );
                if ( row["AM370"] != null && row["AM370"].ToString( ) != "" )
                    model.AM370 = decimal.Parse( row["AM370"].ToString( ) );
                if ( row["AM371"] != null && row["AM371"].ToString( ) != "" )
                    model.AM371 = decimal.Parse( row["AM371"].ToString( ) );
                if ( row["AM372"] != null && row["AM372"].ToString( ) != "" )
                    model.AM372 = decimal.Parse( row["AM372"].ToString( ) );
                if ( row["AM373"] != null && row["AM373"].ToString( ) != "" )
                    model.AM373 = decimal.Parse( row["AM373"].ToString( ) );
                if ( row["AM374"] != null && row["AM374"].ToString( ) != "" )
                    model.AM374 = decimal.Parse( row["AM374"].ToString( ) );
                if ( row["AM375"] != null && row["AM375"].ToString( ) != "" )
                    model.AM375 = decimal.Parse( row["AM375"].ToString( ) );
                if ( row["AM376"] != null && row["AM376"].ToString( ) != "" )
                    model.AM376 = decimal.Parse( row["AM376"].ToString( ) );
                if ( row["AM377"] != null && row["AM377"].ToString( ) != "" )
                    model.AM377 = decimal.Parse( row["AM377"].ToString( ) );
                if ( row["AM378"] != null && row["AM378"].ToString( ) != "" )
                    model.AM378 = decimal.Parse( row["AM378"].ToString( ) );
                if ( row["AM379"] != null && row["AM379"].ToString( ) != "" )
                    model.AM379 = decimal.Parse( row["AM379"].ToString( ) );
                if ( row["AM380"] != null && row["AM380"].ToString( ) != "" )
                    model.AM380 = decimal.Parse( row["AM380"].ToString( ) );
                if ( row["AM381"] != null && row["AM381"].ToString( ) != "" )
                    model.AM381 = decimal.Parse( row["AM381"].ToString( ) );
                if ( row["AM382"] != null && row["AM382"].ToString( ) != "" )
                    model.AM382 = decimal.Parse( row["AM382"].ToString( ) );
                if ( row["AM383"] != null && row["AM383"].ToString( ) != "" )
                    model.AM383 = decimal.Parse( row["AM383"].ToString( ) );
                if ( row["AM385"] != null && row["AM385"].ToString( ) != "" )
                    model.AM385 = decimal.Parse( row["AM385"].ToString( ) );
                if ( row["AM386"] != null && row["AM386"].ToString( ) != "" )
                    model.AM386 = decimal.Parse( row["AM386"].ToString( ) );
                if ( row["AM387"] != null && row["AM387"].ToString( ) != "" )
                    model.AM387 = decimal.Parse( row["AM387"].ToString( ) );
                if ( row["AM388"] != null && row["AM388"].ToString( ) != "" )
                    model.AM388 = decimal.Parse( row["AM388"].ToString( ) );
                if ( row["AM389"] != null && row["AM389"].ToString( ) != "" )
                    model.AM389 = decimal.Parse( row["AM389"].ToString( ) );
                if ( row["AM390"] != null && row["AM390"].ToString( ) != "" )
                    model.AM390 = decimal.Parse( row["AM390"].ToString( ) );
                if ( row["AM391"] != null && row["AM391"].ToString( ) != "" )
                    model.AM391 = decimal.Parse( row["AM391"].ToString( ) );
                if ( row["AM392"] != null && row["AM392"].ToString( ) != "" )
                    model.AM392 = decimal.Parse( row["AM392"].ToString( ) );
                if ( row["AM393"] != null && row["AM393"].ToString( ) != "" )
                    model.AM393 = decimal.Parse( row["AM393"].ToString( ) );
            }

            return model;
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetList ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQAM" );
            if ( !string.IsNullOrEmpty( strWhere ) )
            {
                strSql.Append( " WHERE " + strWhere );
            }

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableAll ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT AM002,AM003,AM004,AM005,AM009,AM011 FROM R_PQAM" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int ProductCostSummaryCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQAM A LEFT JOIN R_PQF B ON A.AM002=B.PQF01 " );
            if ( !string.IsNullOrEmpty( strWhere ) )
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
        /// 分页获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTableByPage ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT TT.idx,AM001,AM002,AM003,AM004,AM005,AM009,AM011,PQF31,PQF13,(SELECT RES05 FROM R_REVIEWS WHERE RES04=(SELECT MAX(RES04) FROM R_REVIEWS WHERE RES06=AM001)) RES05 FROM (" );
            strSql.Append( " SELECT ROW_NUMBER() OVER(" );
            strSql.Append( " ORDER BY T.idx DESC" );
            strSql.Append( ") AS Row,T.*,B.PQF31,B.PQF13 FROM R_PQAM T LEFT JOIN R_PQF B ON T.AM002=B.PQF01" );
            if ( !string.IsNullOrEmpty( strWhere.Trim( ) ) )
            {
                strSql.Append( " WHERE " + strWhere );
            }
            strSql.Append( " ) TT" );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 获取计算结果
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableCalCu (string strWhere )
        {
            //U24 U26:木材 U29 U31:胶合板 U34 U36:车木件 U39 U41:滚漆 U44 U46:铁件 U49 U51:油漆 U54 U56:包装材料 U59 U61:成品委外 U64 U66:承揽加工 U69 U71:前后道工资 U74 U76:装运代理
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "WITH CET AS (SELECT idx,AM336+AM343+AM361+AM346+AM349+AM367+AM352+AM370+AM355+AM153+AM339+AM364+AM157+AM330+AM333+AM358+AM373+AM376+AM379+AM385+AM388+AM391+AM298+AM301+AM307+AM311+AM304+AM318+AM315+AM321+AM270+AM273+AM277+AM280+AM249+AM242+AM245+AM239+AM209+AM212+AM215+AM225+AM229+AM233+AM175+AM178+AM182+AM185+AM188+AM191+AM194+AM197+AM136+AM139+AM142+AM145+AM148+AM237+AM108+AM111+AM084 U104,AM070+AM072+AM074+AM076+AM078+AM080+AM082+AM086+AM088+AM090+AM092+AM044+AM046+AM048+AM050+AM052+AM054+AM056+AM058+AM060+AM062 U105,AM020+AM022+AM024+AM026+AM028 U106,AM338+AM351+AM381+AM357+AM363+AM294+AM369+AM292+AM332+AM155+AM345+AM390+AM300+AM306+AM320+AM324+AM272+AM279+AM211+AM217+AM221+AM255+AM241+AM247+AM252+AM177+AM184+AM190+AM196 U107,AM158+AM261+AM263+AM265+AM267+AM287+AM288+AM290+AM375+AM382+AM313+AM328+AM326+AM296+AM283+AM285+AM227+AM231+AM235+AM255+AM241+AM200+AM203+AM205+AM207 U108,AM337+AM344+AM362+AM347+AM350+AM368+AM353+AM371+AM365+AM154+AM340+AM356+AM157+AM330+AM333+AM358+AM373+AM376+AM379+AM385+AM388+AM391+AM299+AM302+AM308+AM312+AM304+AM318+AM315+AM321+AM271+AM274+AM277+AM280+AM250+AM243+AM246+AM240+AM210+AM213+AM216+AM226+AM230+AM234+AM176+AM179+AM183+AM186+AM189+AM192+AM195+AM198+AM137+AM140+AM143+AM146+AM149+AM238+AM109+AM112+AM085 U109,AM071+AM073+AM075+AM077+AM079+AM081+AM083+AM087+AM089+AM091+AM093+AM045+AM047+AM049+AM051+AM053+AM055+AM057+AM059+AM061+AM063 U110,AM021+AM023+AM025+AM027+AM029 U111,AM341+AM354+AM387+AM360+AM366+AM295+AM372+AM293+AM335+AM156+AM348+AM393+AM303+AM309+AM323+AM325+AM275+AM282+AM214+AM220+AM222+AM256 U112,AM158+AM261+AM263+AM265+AM267+AM287+AM288+AM290+AM375+AM382+AM313+AM328+AM326+AM296+AM283+AM285+AM227+AM231+AM235+AM255 U113,AM338+AM351+AM381+AM357+AM363+AM294+AM369+AM292+AM332+AM155+AM345+AM390+AM336+AM343+AM361+AM346+AM349+AM367+AM352+AM370+AM355+AM153+AM339+AM364 U24,AM341+AM354+AM387+AM360+AM366+AM295+AM372+AM293+AM335+AM156+AM348+AM393+AM365+AM340+AM154+AM337+AM344+AM362+AM347+AM350+AM368+AM353+AM371+AM356 U26,AM298+AM301+AM307+AM311+AM300+AM306+AM320+AM324 U29,AM299+AM302+AM308+AM312+AM303+AM309+AM323+AM325 U31,AM270+AM273+AM272+AM279 U34,AM271+AM274+AM275+AM282 U36,AM249+AM242+AM245+AM241+AM247+AM252 U39,AM244+AM251+AM253+AM250+AM243+AM246 U41,AM209+AM212+AM215+AM211+AM217+AM221 U44,AM210+AM213+AM216+AM214+AM220+AM222 U46,AM175+AM178+AM182+AM185+AM177+AM184+AM190+AM196 U49,AM176+AM179+AM183+AM186+AM180+AM187+AM193+AM199 U51,AM136+AM139+AM142+AM145+AM148+AM255+AM218+AM138 U54,AM137+AM140+AM143+AM146+AM149+AM256+AM219+AM141 U56,AM020+AM022+AM024+AM026+AM028 U74,AM021+AM023+AM025+AM027+AM029 U76,AM108+AM111 U59,AM109+AM112 U61,AM070+AM072+AM074+AM076+AM078+AM080+AM082+AM084+AM086+AM088+AM090+AM092 U64,AM071+AM073+AM075+AM077+AM079+AM081+AM083+AM085+AM087+AM089+AM091+AM093 U66,AM044+AM046+AM048+AM050+AM052+AM054+AM056+AM058+AM060+AM062 U69,AM045+AM047+AM049+AM051+AM053+AM055+AM057+AM059+AM061+AM063 U71,AM006,AM016,AM017,AM018 FROM R_PQAM" );
            strSql.Append( " WHERE " + strWhere );
            strSql . Append ( ") SELECT *,U104+U105+U106+U107+U108+AM006*AM016*(AM017+AM018) F0,U109+U110+U111+U112+U113+AM006*AM016*(AM017+AM018) F1,U24+U29+U34+U39+U44+U49+U54+U59+U64+U69+U74 U14,U26+U31+U36+U41+U46+U51+U56+U61+U66+U71+U76 U16 FROM CET " );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取隐藏后的计算结果
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableCalCuHide ( string strWhere)
        {
            //二类 B类 的都隐藏
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "WITH CET AS (SELECT idx,AM336+AM343+AM361+AM346+AM349+AM367+AM352+AM370+AM355+AM153+AM157+AM330+AM333+AM358+AM373+AM376+AM379+AM385+AM388+AM391+AM298+AM301+AM307+AM311+AM304+AM318+AM315+AM321+AM270+AM273+AM277+AM280+AM249+AM242+AM245+AM239+AM209+AM212+AM215+AM225+AM229+AM233+AM175+AM178+AM182+AM185+AM188+AM191+AM194+AM197+AM136+AM139+AM142+AM145+AM148+AM237+AM108+AM084 U104 ,AM070 + AM072 + AM074 + AM076 + AM078 + AM080 + AM082 + AM086 + AM088 + AM090 + AM092 + AM044 + AM046 + AM048 + AM050 + AM052 + AM054 + AM056 + AM058 + AM060 + AM062 U105 ,AM020 + AM022 + AM024 + AM026 + AM028 U106 ,AM338 + AM351 + AM381 + AM357 + AM363 + AM294 + AM369 + AM292 + AM332 + AM155 + AM390 + AM300 + AM306 + AM320 + AM324 + AM272 + AM279 + AM211 + AM217 + AM221 + AM255 +AM241 + AM247 + AM252 + AM177 + AM184 + AM190 + AM196 U107 ,AM158 + AM261 + AM263 + AM265 + AM267 + AM287 + AM288 + AM290 + AM375 + AM382 + AM313 + AM328 + AM326 + AM296 + AM283 + AM285 + AM227 + AM231 + AM235 + AM255 + AM241 +AM200 + AM203 + AM205 + AM207 U108 ,AM337+AM344+AM362+AM347+AM350+AM368+AM353+AM371+AM365+AM154+AM157+AM330+AM333+AM358+AM373+AM376+AM379+AM385+AM388+AM391+AM299+AM302+AM308+AM312+AM304+AM318+AM315+AM321+AM271+AM274+AM277+AM280+AM250+AM243+AM246+AM240+AM210+AM213+AM216+AM226+AM230+AM234+AM176+AM179+AM183+AM186+AM189+AM192+AM195+AM198+AM137+AM140+AM143+AM146+AM149+AM238+AM109+AM085 U109 ,AM071 + AM073 + AM075 + AM077 + AM079 + AM081 + AM083 + AM087 + AM089 + AM091 + AM093 + AM045 + AM047 + AM049 + AM051 + AM053 + AM055 + AM057 + AM059 + AM061 + AM063 U110 ,AM021 + AM023 + AM025 + AM027 + AM029 U111 ,AM341 + AM354 + AM387 + AM360 + AM366 + AM295 + AM372 + AM293 + AM335 + AM156 + AM303 + AM309 + AM323 + AM325 + AM275 + AM282 + AM214 + AM220 + AM222 + AM256 U112 ,AM158 + AM261 + AM263 + AM265 + AM267 + AM287 + AM288 + AM290 + AM375 + AM382 + AM313 + AM328 + AM326 + AM296 + AM283 + AM285 + AM227 + AM231 + AM235 + AM255 U113 ,AM338 + AM351 + AM381 + AM357 + AM363 + AM294 + AM369 + AM292 + AM332 + AM155 + AM390 + AM336 + AM343 + AM361 + AM346 + AM349 + AM367 + AM352 + AM370 + AM355 + AM153 U24 ,AM341 + AM354 + AM387 + AM360 + AM366 + AM295 + AM372 + AM293 + AM335 + AM156 + AM365 + AM154 + AM337 + AM344 + AM362 + AM347 + AM350 + AM368 + AM353 + AM371 + AM356 U26 ,AM298 + AM301 + AM307 + AM311 + AM300 + AM306 + AM320 + AM324 U29 ,AM299 + AM302 + AM308 + AM312 + AM303 + AM309 + AM323 + AM325 U31 ,AM270 + AM273 + AM272 + AM279 U34 ,AM271 + AM274 + AM275 + AM282 U36 ,AM249 + AM242 + AM245 + AM241 + AM247 + AM252 U39 ,AM244 + AM251 + AM253 + AM250 + AM243 + AM246 U41 ,AM209 + AM212 + AM215 + AM211 + AM217 + AM221 U44 ,AM210 + AM213 + AM216 + AM214 + AM220 + AM222 U46 ,AM175 + AM178 + AM182 + AM185 + AM177 + AM184 + AM190 + AM196 U49 ,AM176 + AM179 + AM183 + AM186 + AM180 + AM187 + AM193 + AM199 U51 ,AM136 + AM139 + AM142 + AM145 + AM148 + AM255+AM218+AM138 U54 ,AM137 + AM140 + AM143 + AM146 + AM149 + AM256+AM219+AM141 U56 ,AM020 + AM022 + AM024 + AM026 + AM028 U74 ,AM021 + AM023 + AM025 + AM027 + AM029 U76 ,AM108 U59 ,AM109 U61 ,AM070 + AM072 + AM074 + AM076 + AM078 + AM080 + AM082 + AM084 + AM086 + AM088 + AM090 + AM092 U64 ,AM071 + AM073 + AM075 + AM077 + AM079 + AM081 + AM083 + AM085 + AM087 + AM089 + AM091 + AM093  U66 ,AM044 + AM046 + AM048 + AM050 + AM052 + AM054 + AM056 + AM058 + AM060 + AM062 U69 ,AM045 + AM047 + AM049 + AM051 + AM053 + AM055 + AM057 + AM059 + AM061 + AM063 U71,AM006,AM016,AM017,AM018 FROM R_PQAM" );
            strSql .Append( " WHERE " + strWhere );
            strSql . Append ( ") SELECT *,U104+U105+U106+U107+U108+AM006*AM016*(AM017+AM018) F0,U109+U110+U111+U112+U113+AM006*AM016*(AM017+AM018) F1,U24+U29+U34+U39+U44+U49+U54+U59+U64+U69+U74 U14,U26+U31+U36+U41+U46+U51+U56+U61+U66+U71+U76 U16 FROM CET" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 隐藏
        /// </summary>
        /// <returns></returns>
        public bool GetHide ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET AM114='T',AM342='T',AM384='T',AM181='T',AM202='T'" );

            int rows = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( rows > 0 )
                return true;
            else
                return false;
        }


        /// <summary>
        /// 取消隐藏
        /// </summary>
        /// <returns></returns>
        public bool GetHideCanCel ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAM SET AM114='F',AM342='F',AM384='F',AM181='F',AM202='F'" );

            int rows = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取347数据
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqsTwo ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,PJ100,PJ09,PJ,PQ,CASE WHEN AK>=PQ THEN PQ WHEN AK<PQ THEN AK ELSE 0 END AK FROM (SELECT A.idx,CASE WHEN PJ100='T' THEN 'T' ELSE 'F' END PJ100,PJ09,ISNULL(AK011,0) AK,CONVERT(DECIMAL(18,1),SUM(PJ12*(PJ11*PJ96+PJ10))) PQ,PJ105 PJ FROM R_PQS A LEFT JOIN R_PQAL B ON A.PJ92=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx  AND C.AK017 IN ('执行','审核') LEFT JOIN R_REVIEWS D ON A.PJ92=D.RES06 AND RES01='R_347' AND RES05='执行'" );
            strSql.Append( " WHERE PJ01=@PJ01 AND (PJ01!='' AND PJ01 IS NOT NULL)" );
            strSql.Append( " GROUP BY PJ100,PJ09,AK011,PJ105,A.idx) A GROUP BY PJ100,PJ09,PJ,PQ,AK,idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@PJ01",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        ///   获取R_250数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableOne ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "WITH CET AS(SELECT DBA002,DAA002 FROM TPADBA A INNER JOIN (SELECT DAA001,DAA002 FROM TPADAA WHERE DAA002 IN (SELECT DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002='生产部'))) B ON A.DBA005=B.DAA001)" );
            strSql.Append( "SELECT AE08,AE09,AE07,AE04,AE03,AE06,SUM(AE37) AE37,AE12,AE13,AE05,DAA002 FROM R_PQAE A LEFT JOIN CET B ON A.AE08=B.DBA002" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( " GROUP BY AE02,AE08,AE09,AE07,AE04,AE03,AE06,AE12,AE13,AE05,DAA002" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }


        /// <summary>
        /// 获取R_196数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableTwo ( string num )
        {
            StringBuilder strSql = new StringBuilder( );

            //strSql . Append ( "SELECT CP01,CP09 AH18,CASE WHEN CP58='' THEN 'F' ELSE CP58 END CP58,CASE WHEN CP56='' THEN 'F' ELSE CP56 END CP56,SUM(ISNULL(CP,0)) AH,CASE WHEN ISNULL(AK011,0)<SUM(ISNULL(CP,0)) THEN ISNULL(AK011,0) ELSE SUM(ISNULL(CP,0)) END AK,A.AK017 FROM (" );
            //strSql . Append ( "SELECT A.idx,CP01,CASE WHEN CP09 LIKE '%雕刻%' THEN '雕刻' WHEN CP09 LIKE '%绕锯%' THEN '绕锯' WHEN CP09 LIKE '%夹料%' THEN '夹料' WHEN CP09 LIKE '%砂皮%' THEN '擦砂皮' WHEN CP09 LIKE '%丝印%' THEN '丝印' WHEN CP09 LIKE '%走台印%' THEN '走台印' WHEN CP09 LIKE '%移印%' THEN '移印' WHEN CP09 LIKE '%热转印%' THEN '热转印' WHEN CP09 LIKE '%烫印%' THEN '烫印' WHEN CP09 LIKE '%喷漆%' THEN '喷漆' WHEN CP09 LIKE '%冲压%' THEN '冲压' WHEN CP09 LIKE '%/%' THEN '委外' ELSE '手工剪切、其它' END CP09,CONVERT(DECIMAL(18,2),CASE WHEN CP10=0 THEN CP13*CP54*CP11-CP12 ELSE CP13*CP54*CP10-CP12 END) CP,ISNULL(CP58,'F') CP58,ISNULL(CP56,'F') CP56,CP03,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQQ A LEFT JOIN R_PQAL B ON A.CP03=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx INNER JOIN R_REVIEWS D ON A.CP03=D.RES06 " );
            //strSql . Append ( "WHERE CP01 IN ('" + num + "')  AND RES05='执行'  AND  (CP01!='' AND CP01 IS NOT NULL) GROUP BY A.idx,CP03,CP01,CP09,CP10,CP13,CP54,CP11,CP12,CP56,CP58,AK017 " );
            //strSql . Append ( "UNION ALL " );
            //strSql . Append ( "SELECT A.idx,AH01,CASE WHEN AH18 LIKE '%雕刻%' THEN '雕刻' WHEN AH18 LIKE '%绕锯%' THEN '绕锯' WHEN AH18 LIKE '%夹料%' THEN '夹料' WHEN AH18 LIKE '%砂皮%' THEN '擦砂皮' WHEN AH18 LIKE '%丝印%' THEN '丝印' WHEN AH18 LIKE '%走台印%' THEN '走台印' WHEN AH18 LIKE '%移印%' THEN '移印' WHEN AH18 LIKE '%热转印%' THEN '热转印' WHEN AH18 LIKE '%烫印%' THEN '烫印' WHEN AH18 LIKE '%喷漆%' THEN '喷漆' WHEN AH18 LIKE '%冲压%' THEN '冲压' WHEN AH18 LIKE '%/%' THEN '委外' ELSE '手工剪切、其它' END AH18,CONVERT(DECIMAL(18,2),AH16*AH101*AH13*AH14-AH17) AH,ISNULL(AH113,'F') AH113,AH111,AH97,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQAH A LEFT JOIN R_PQAL B ON A.AH97=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx INNER JOIN R_REVIEWS D ON A.AH97=D.RES06 " );
            //strSql . Append ( "WHERE AH01 IN ('" + num + "') AND RES05='执行'  AND (AH01!='' AND AH01 IS NOT NULL) GROUP BY A.idx,AH01,AH18,AH16,AH101,AH13,AH14,AH17,AH111,AH113,AH97,AK017 " );
            //strSql . Append ( "UNION ALL " );
            //strSql . Append ( "SELECT A.idx,IZ002,'夹料' AH,CASE WHEN IZ021=0 THEN 0 ELSE CONVERT(DECIMAL(18,2),(IZ005*IZ022/IZ021)*(IZ013*(IZ014+IZ015)*2*IZ016)) END U0,'','',IZ001,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQIZ A LEFT JOIN R_PQAL B ON A.IZ001=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON C.idx=B.AL001  LEFT JOIN R_REVIEWS D ON A.IZ001=D.RES06 " );
            //strSql . Append ( "WHERE IZ002 IN ('" + num + "') AND RES05='执行' AND (IZ002!='' AND IZ002 IS NOT NULL) GROUP BY A.idx,IZ002,IZ021,IZ005,IZ022,IZ021,IZ013,IZ014,IZ015,IZ016,IZ001,AK017 " );
            //strSql . Append ( "UNION ALL " );
            //strSql . Append ( "SELECT A.idx,PY01,'喷漆' X,CONVERT(DECIMAL(18,2),(CASE WHEN PY14 = 0 OR PY18 = 0 OR PY21 = 0 THEN 0 WHEN PY14 != 0 AND PY18 != 0 AND PY21 != 0 THEN (PY10*PY11*PY15*PY12*PY20/PY21/PY14/PY18+PY13*PY19*PY16*PY10*PY11/PY14/PY18/PY21/2)*(1+PY17/100) END )+PY23*PY14*PY18*PY11*PY10*PY12*PY15*0.0001) U14,'' X3,'' X4,PY33,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQY A LEFT JOIN R_PQAL B ON A.PY33=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx LEFT JOIN R_REVIEWS D ON A.PY33=D.RES06 " );
            //strSql . Append ( "WHERE PY01 IN ('" + num + "')  AND RES05='执行' AND RES01='R_495' AND (PY01!='' AND PY01 IS NOT NULL) GROUP BY A.idx,PY01,PY14,PY18,PY21,PY10,PY11,PY12,PY15,PY13,PY16,PY19,PY20,PY17,PY33,PY23,AK017 " );
            //strSql . Append ( ") A GROUP BY CP09,CP01,CP58,CP56,ISNULL(AK011,0),A.AK017,CP03 ORDER BY CP01" );

            strSql . Append ( "SELECT CP01,CP09 AH18,CASE WHEN CP58='' THEN 'F' ELSE CP58 END CP58,CASE WHEN CP56='' THEN 'F' ELSE CP56 END CP56,SUM(ISNULL(CP,0)) AH,CASE WHEN ISNULL(AK011,0)<SUM(ISNULL(CP,0)) THEN ISNULL(AK011,0) ELSE SUM(ISNULL(CP,0)) END AK,A.AK017 FROM (" );
            strSql . Append ( "SELECT A.idx,CP01,CASE WHEN CP09 LIKE '%雕刻%' THEN '雕刻' WHEN CP09 LIKE '%绕锯%' THEN '绕锯' WHEN CP09 LIKE '%夹料%' THEN '夹料' WHEN CP09 LIKE '%砂皮%' THEN '擦砂皮' WHEN CP09 LIKE '%丝印%' THEN '丝印' WHEN CP09 LIKE '%走台印%' THEN '走台印' WHEN CP09 LIKE '%移印%' THEN '移印' WHEN CP09 LIKE '%热转印%' THEN '热转印' WHEN CP09 LIKE '%烫印%' THEN '烫印' WHEN CP09 LIKE '%喷漆%' THEN '喷漆' WHEN CP09 LIKE '%冲压%' THEN '冲压' WHEN CP09 LIKE '%/%' THEN '委外' ELSE '手工剪切、其它' END CP09,CONVERT(DECIMAL(18,2),CASE WHEN CP10=0 THEN CP13*CP54*CP11-CP12 ELSE CP13*CP54*CP10-CP12 END) CP,ISNULL(CP58,'F') CP58,ISNULL(CP56,'F') CP56,CP03,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQQ A LEFT JOIN R_PQAL B ON A.CP03=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx INNER JOIN R_REVIEWS D ON A.CP03=D.RES06 " );
            strSql . Append ( "WHERE CP01 IN ('" + num + "')  AND RES05='执行'  AND  (CP01!='' AND CP01 IS NOT NULL) GROUP BY A.idx,CP03,CP01,CP09,CP10,CP13,CP54,CP11,CP12,CP56,CP58,AK017 " );
            strSql . Append ( "UNION ALL " );
            strSql . Append ( "SELECT A.idx,AH01,CASE WHEN AH18 LIKE '%雕刻%' THEN '雕刻' WHEN AH18 LIKE '%绕锯%' THEN '绕锯' WHEN AH18 LIKE '%夹料%' THEN '夹料' WHEN AH18 LIKE '%砂皮%' THEN '擦砂皮' WHEN AH18 LIKE '%丝印%' THEN '丝印' WHEN AH18 LIKE '%走台印%' THEN '走台印' WHEN AH18 LIKE '%移印%' THEN '移印' WHEN AH18 LIKE '%热转印%' THEN '热转印' WHEN AH18 LIKE '%烫印%' THEN '烫印' WHEN AH18 LIKE '%喷漆%' THEN '喷漆' WHEN AH18 LIKE '%冲压%' THEN '冲压' WHEN AH18 LIKE '%/%' THEN '委外' ELSE '手工剪切、其它' END AH18,CONVERT(DECIMAL(18,2),AH16*AH101*AH13*AH14-AH17) AH,ISNULL(AH113,'F') AH113,AH111,AH97,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQAH A LEFT JOIN R_PQAL B ON A.AH97=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx INNER JOIN R_REVIEWS D ON A.AH97=D.RES06 " );
            strSql . Append ( "WHERE AH01 IN ('" + num + "') AND RES05='执行'  AND (AH01!='' AND AH01 IS NOT NULL) GROUP BY A.idx,AH01,AH18,AH16,AH101,AH13,AH14,AH17,AH111,AH113,AH97,AK017 " );
            strSql . Append ( "UNION ALL " );
            strSql . Append ( "SELECT A.idx,IZ002,'夹料' AH,CASE WHEN IZ021=0 THEN 0 ELSE CONVERT(DECIMAL(18,2),(IZ005*IZ022/IZ021)*(IZ013*(IZ014+IZ015)*2*IZ016)) END U0,'','',IZ001,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQIZ A LEFT JOIN R_PQAL B ON A.IZ001=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON C.idx=B.AL001  LEFT JOIN R_REVIEWS D ON A.IZ001=D.RES06 " );
            strSql . Append ( "WHERE IZ002 IN ('" + num + "') AND RES05='执行' AND (IZ002!='' AND IZ002 IS NOT NULL) GROUP BY A.idx,IZ002,IZ021,IZ005,IZ022,IZ021,IZ013,IZ014,IZ015,IZ016,IZ001,AK017 " );
            strSql . Append ( "UNION ALL " );
            strSql . Append ( "SELECT A.idx,PY01,'喷漆' X,CONVERT(DECIMAL(18,2),(CASE WHEN PY14 = 0 OR PY18 = 0 OR PY21 = 0 THEN 0 WHEN PY14 != 0 AND PY18 != 0 AND PY21 != 0 THEN (PY10*PY11*PY15*PY12*PY20/PY21/PY14/PY18+PY13*PY19*PY16*PY10*PY11/PY14/PY18/PY21/2)*(1+PY17/100) END )+PY23*PY14*PY18*PY11*PY10*PY12*PY15*0.0001) U14,'' X3,'' X4,PY33,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQY A LEFT JOIN R_PQAL B ON A.PY33=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx LEFT JOIN R_REVIEWS D ON A.PY33=D.RES06 " );
            strSql . Append ( "WHERE PY01 IN ('" + num + "')  AND RES05='执行' AND RES01='R_495' AND (PY01!='' AND PY01 IS NOT NULL) GROUP BY A.idx,PY01,PY14,PY18,PY21,PY10,PY11,PY12,PY15,PY13,PY16,PY19,PY20,PY17,PY33,PY23,AK017 " );
            strSql . Append ( ") A WHERE AK017 IN ('审核','执行') GROUP BY CP09,CP01,CP58,CP56,ISNULL(AK011,0),A.AK017,CP03 ORDER BY CP01" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public bool UpdatePqah ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT A.CP03,CP01,CONVERT(DECIMAL(18,2),SUM(CASE WHEN CP10=0 THEN CP13*CP54*CP11-CP12 ELSE CP13*CP54*CP10-CP12 END)) CP,ISNULL(CP58,'F') CP58,ISNULL(CP56,'F') CP56,CASE WHEN CP09 LIKE '%雕刻%' THEN '雕刻' WHEN CP09 LIKE '%绕锯%' THEN '绕锯' WHEN CP09 LIKE '%夹料%' THEN '夹料' WHEN CP09 LIKE '%砂皮%' THEN '擦砂皮' WHEN CP09 LIKE '%丝印%' THEN '丝印' WHEN CP09 LIKE '%走台印%' THEN '走台印' WHEN CP09 LIKE '%移印%' THEN '移印' WHEN CP09 LIKE '%热转印%' THEN '热转印' WHEN CP09 LIKE '%烫印%' THEN '烫印' WHEN CP09 LIKE '%喷漆%' THEN '喷漆' WHEN CP09 LIKE '%冲压%' THEN '冲压' WHEN CP09 LIKE '%/%' THEN '委外' ELSE '手工剪切、其它' END CP09 FROM R_PQQ A LEFT JOIN R_REVIEWS D ON A.CP03=D.RES06" );
            strSql.Append( " WHERE CP01=@CP01  AND RES05='执行'" );
            strSql.Append( " GROUP BY A.CP03,CP01,CP58,CP56,CP09" );
            strSql.Append( " UNION" );
            strSql.Append( " SELECT A.AH97,AH01,CONVERT(DECIMAL(18,2),SUM(AH16*AH101*AH13*AH14-AH17)) AH, ISNULL(AH113,'F') AH113,AH111,CASE WHEN AH18 LIKE '%雕刻%' THEN '雕刻' WHEN AH18 LIKE '%绕锯%' THEN '绕锯' WHEN AH18 LIKE '%夹料%' THEN '夹料' WHEN AH18 LIKE '%砂皮%' THEN '擦砂皮' WHEN AH18 LIKE '%丝印%' THEN '丝印' WHEN AH18 LIKE '%走台印%' THEN '走台印' WHEN AH18 LIKE '%移印%' THEN '移印' WHEN AH18 LIKE '%热转印%' THEN '热转印' WHEN AH18 LIKE '%烫印%' THEN '烫印' WHEN AH18 LIKE '%喷漆%' THEN '喷漆' WHEN AH18 LIKE '%冲压%' THEN '冲压' WHEN AH18 LIKE '%/%' THEN '委外' ELSE '手工剪切、其它' END AH18 FROM R_PQAH A LEFT JOIN R_REVIEWS D ON A.AH97=D.RES06" );
            strSql.Append( " WHERE AH01=@CP01  AND RES05='执行'" );
            strSql.Append( "  GROUP BY AH18,A.AH97,AH01,AH113,AH111,AH18" );
            strSql.Append( " UNION" );
            strSql.Append( " SELECT A.IZ001,IZ002,SUM(CASE WHEN IZ021=0 THEN 0 ELSE CONVERT(DECIMAL(18,2),(IZ005*IZ022/IZ021)*(IZ013*(IZ014+IZ015)*2*IZ016)) END) U0,'' X,'' Y,'夹料' AH FROM R_PQIZ A LEFT JOIN R_REVIEWS D ON A.IZ001=D.RES06" );
            strSql.Append( " WHERE IZ002=@CP01  AND RES05='执行'" );
            strSql.Append( " GROUP BY IZ001,IZ002" );
            strSql.Append( " UNION" );
            strSql.Append( " SELECT A.PY33,PY01,SUM((CASE WHEN PY14 = 0 OR PY18 = 0 OR PY21 = 0 THEN 0 WHEN PY14 != 0 AND PY18 != 0 AND PY21 != 0 THEN  CONVERT(DECIMAL(18,3),(PY10*PY11*PY15*PY12*PY20/PY21/PY14/PY18+PY13*PY19*PY16*PY10*PY11/PY14/PY18/PY21/2)*(1+PY17/100)) END )+ CONVERT(DECIMAL(18,3),PY23*PY14*PY18*PY11*PY10*PY12*PY15*0.0001)) U14,'' X3,'' X4,'喷漆' X  FROM R_PQY A LEFT JOIN R_REVIEWS D ON A.PY33=D.RES06 AND RES01='R_495' AND RES05='执行'" );
            strSql.Append( " WHERE PY01=@CP01" );
            strSql.Append( " GROUP BY PY33,PY01" );
            SqlParameter[] parameter = {
                new SqlParameter("@CP01",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = model.AM002;

            DataTable da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
            if ( da != null && da.Rows.Count > 0 )
            {
                string oddNum = "";
                for ( int i = 0 ; i < da.Rows.Count ; i++ )
                {
                    oddNum = da.Rows[i]["CP03"].ToString( );
                    WriteReceivableToGeneralLedger.ByOneByGongXu( model ,oddNum ,SQLString );
                }
            }

            if ( SQLString.Count > 0 )
                return SqlHelper.ExecuteSqlTran( SQLString );
            else
                return true;
        }
        
        /// <summary>
        /// 获取195数据
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqq ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            //strSql . Append ( "SELECT CP56,CP58,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(CP)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(CP)) END AK,CONVERT(DECIMAL(18,2),SUM(CP)) CP,AK017 FROM (" );
            //strSql . Append ( "SELECT A.idx,CASE WHEN CP09 LIKE '%雕刻%' THEN '雕刻' WHEN CP09 LIKE '%绕锯%' THEN '绕锯' WHEN CP09 LIKE '%夹料%' THEN '夹料' WHEN CP09 LIKE '%砂皮%' THEN '擦砂皮' WHEN CP09 LIKE '%丝印%' THEN '丝印' WHEN CP09 LIKE '%走台印%' THEN '走台印' WHEN CP09 LIKE '%移印%' THEN '移印' WHEN CP09 LIKE '%热转印%' THEN '热转印' WHEN CP09 LIKE '%烫印%' THEN '烫印' WHEN CP09 LIKE '%喷漆%' THEN '喷漆' WHEN CP09 LIKE '%冲压%' THEN '冲压' WHEN CP09 LIKE '%/%' THEN '委外' ELSE '手工剪切、其它' END CP09,CASE CP56 WHEN 'T' THEN 'T' ELSE 'F' END CP56,CASE CP58 WHEN 'T' THEN 'T' ELSE 'F' END CP58,CP01,CASE WHEN CP10=0 THEN CP13*CP54*CP11-CP12 ELSE CP13*CP54*CP10-CP12 END CP,CP03,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQQ A LEFT JOIN R_PQAL B ON A.CP03=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx AND C.AK017 IN ('执行','审核') INNER JOIN R_REVIEWS D ON A.CP03=D.RES06 " );
            //strSql . Append ( "WHERE CP01=@CP01 AND RES05='执行' " );
            //strSql . Append ( "GROUP BY A.idx,CP09,CP56,CP58,CP01,CP10,CP13,CP54,CP11,CP12,CP03,AK017) A WHERE CP09='委外' GROUP BY CP09,CP56,CP58,ISNULL(AK011,0),AK017 " );
            //strSql . Append ( " UNION ALL " );
            //strSql . Append ( "SELECT BA056,BA058,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(BA)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(BA)) END AK,CONVERT(DECIMAL(18,2),SUM(BA)) BA,AK017 FROM (SELECT BA056,BA058,BA013*BA054 BA,BA003,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQBA A LEFT JOIN R_PQAL B ON A.BA003=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx AND C.AK017 IN ('执行','审核') INNER JOIN R_REVIEWS D ON A.BA003=D.RES06  " );
            //strSql . Append ( "WHERE BA001=@CP01 AND RES05='执行' " );
            //strSql . Append ( "GROUP BY BA056,BA058,BA013,BA054,BA003,AK017 ) A GROUP BY BA056,BA058,ISNULL(AK011,0),AK017" );

            strSql . Append ( "SELECT CP56,CP58,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(CP)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(CP)) END AK,CONVERT(DECIMAL(18,2),SUM(CP)) CP,AK017 FROM (" );
            strSql . Append ( "SELECT A.idx,CASE WHEN CP09 LIKE '%雕刻%' THEN '雕刻' WHEN CP09 LIKE '%绕锯%' THEN '绕锯' WHEN CP09 LIKE '%夹料%' THEN '夹料' WHEN CP09 LIKE '%砂皮%' THEN '擦砂皮' WHEN CP09 LIKE '%丝印%' THEN '丝印' WHEN CP09 LIKE '%走台印%' THEN '走台印' WHEN CP09 LIKE '%移印%' THEN '移印' WHEN CP09 LIKE '%热转印%' THEN '热转印' WHEN CP09 LIKE '%烫印%' THEN '烫印' WHEN CP09 LIKE '%喷漆%' THEN '喷漆' WHEN CP09 LIKE '%冲压%' THEN '冲压' WHEN CP09 LIKE '%/%' THEN '委外' ELSE '手工剪切、其它' END CP09,CASE CP56 WHEN 'T' THEN 'T' ELSE 'F' END CP56,CASE CP58 WHEN 'T' THEN 'T' ELSE 'F' END CP58,CP01,CASE WHEN CP10=0 THEN CP13*CP54*CP11-CP12 ELSE CP13*CP54*CP10-CP12 END CP,CP03,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQQ A LEFT JOIN R_PQAL B ON A.CP03=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx INNER JOIN R_REVIEWS D ON A.CP03=D.RES06 " );
            strSql . Append ( "WHERE CP01=@CP01 AND RES05='执行' " );
            strSql . Append ( "GROUP BY A.idx,CP09,CP56,CP58,CP01,CP10,CP13,CP54,CP11,CP12,CP03,AK017) A WHERE CP09='委外' GROUP BY CP09,CP56,CP58,ISNULL(AK011,0),AK017 " );
            strSql . Append ( " UNION ALL " );
            strSql . Append ( "SELECT BA056,BA058,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(BA)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(BA)) END AK,CONVERT(DECIMAL(18,2),SUM(BA)) BA,AK017 FROM (SELECT BA056,BA058,BA013*BA054 BA,BA003,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQBA A LEFT JOIN R_PQAL B ON A.BA003=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx INNER JOIN R_REVIEWS D ON A.BA003=D.RES06  " );
            strSql . Append ( "WHERE BA001=@CP01 AND RES05='执行' " );
            strSql . Append ( "GROUP BY BA056,BA058,BA013,BA054,BA003,AK017 ) A WHERE AK017 IN ('执行','审核') GROUP BY BA056,BA058,ISNULL(AK011,0),AK017" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@CP01",SqlDbType.NVarChar)
            };

            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public bool UpdatePqq ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT A.CP03,CASE CP56 WHEN 'T' THEN 'T' ELSE 'F' END CP56,CASE CP58 WHEN 'T' THEN 'T' ELSE 'F' END CP58,CP01,SUM(CASE WHEN CP10=0 THEN CONVERT(DECIMAL(18,1),CP13*CP54*CP11-CP12) WHEN CP11=0 THEN CONVERT(DECIMAL(18,1),CP13*CP54*CP10-CP12)END) CP FROM R_PQQ A LEFT JOIN R_REVIEWS D ON A.CP03=D.RES06 AND RES05='执行'" );
            strSql.Append( " WHERE CP01=@CP01" );
            strSql.Append( " GROUP BY A.CP03,CP56,CP58,CP01" );
            strSql.Append( " UNION" );
            strSql.Append( " SELECT BA003,BA056,BA058,BA001,CONVERT(DECIMAL(18,0),SUM(BA011*BA054)) BA FROM R_PQBA A LEFT JOIN R_REVIEWS D ON A.BA003=D.RES06 AND RES05='执行'" );
            strSql.Append( " WHERE BA001=@CP01" );
            strSql.Append( " GROUP BY BA056,BA058,BA001,BA003" );
            SqlParameter[] parameter = {
                new SqlParameter("@CP01",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = model.AM002;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da != null && da.Rows.Count > 0 )
            {
                string oddNum = "";
                for ( int i = 0 ; i < da.Rows.Count ; i++ )
                {
                    oddNum = da.Rows[i]["CP03"].ToString( );
                    WriteReceivableToGeneralLedger.ByOneByChanPintZhiBao( model ,oddNum ,SQLString );
                }
            }

            if ( SQLString.Count > 0 )
                return SqlHelper.ExecuteSqlTran( SQLString );
            else
                return true;
        }

        /// <summary>
        /// 获取199数据
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqba ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            //strSql.Append( "SELECT BA056,BA058,CONVERT(DECIMAL(18,2),SUM(BA)) BA,CONVERT(DECIMAL(18,2),SUM(CASE WHEN AK>=BA THEN BA WHEN AK=0 THEN 0 END)) AK FROM (" );
            //strSql.Append( "SELECT BA056,BA058,SUM(BA011*BA054) BA,ISNULL(AK011,0) AK FROM R_PQBA A LEFT JOIN R_PQAL B ON A.BA003=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx   AND C.AK017 IN ('执行','审核') INNER JOIN R_REVIEWS D ON A.BA003=D.RES06 AND RES05='执行'" );
            //strSql.Append( " WHERE BA001=@BA001" );
            //strSql.Append( " GROUP BY BA056,BA058,AK011) A GROUP BY BA056,BA058" );
            strSql . Append ( "SELECT BA056,BA058,CONVERT(DECIMAL(18,2),SUM(BA)) BA,ISNULL(AK011,0) AK FROM (SELECT BA056,BA058,BA011*BA054 BA,BA003 FROM R_PQBA A LEFT JOIN R_PQAL B ON A.BA003=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx AND C.AK017 IN ('执行','审核') INNER JOIN R_REVIEWS D ON A.BA003=D.RES06 AND RES05='执行' " );
            strSql . Append ( "WHERE BA001=@BA001 " );
            strSql . Append ( ") A LEFT JOIN R_PQAK B ON A.BA003=B.AK003 GROUP BY BA056,BA058,ISNULL(AK011,0)" );
            SqlParameter[] parameter = {
                new SqlParameter("@BA001",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取317成本
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqw ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "WITH CET AS(SELECT GX04,CASE WHEN GZ39 IN ('执行','审核') THEN GZ39 ELSE '非执行' END GZ39,CONVERT(DECIMAL(18,0),SUM(GZ06*GZ25*GZ41+GZ36*(GZ12+GZ13+GZ14))) GZ FROM R_PQW A LEFT JOIN R_PQAA B ON A.GZ04=B.GX02 " );
            strSql.Append( " WHERE GZ01=@GZ01 " );
            strSql.Append( " GROUP BY GX04,GZ39) " );
            strSql.Append( " ,CFT AS ( " );
            strSql.Append( " SELECT GX04,CASE WHEN GZ39 IN ('执行','审核') THEN GZ39 ELSE '非执行' END GZ39,CONVERT(DECIMAL(18,0),SUM(GZ06*GZ25*GZ41+GZ36*(GZ12+GZ13+GZ14))) GZ FROM R_PQW A LEFT JOIN R_PQAA B ON A.GZ04=B.GX02 " );
            strSql.Append( " WHERE GZ01=@GZ01 " );
            strSql.Append( " AND A.idx IN (SELECT FZ002 FROM R_PQEZ A LEFT JOIN R_PQFZ B ON A.idx=B.FZ001 AND A.EZ015 IN ('执行','审核') " );
            strSql.Append( " )GROUP BY GX04,GZ39,GZ01) " );
            strSql.Append( " SELECT CASE WHEN A.GX04='修理' THEN A.GX04 WHEN A.GX04='包装' THEN A.GX04 WHEN A.GX04='后道辅助' THEN A.GX04 WHEN A.GX04='检验' THEN A.GX04 WHEN A.GX04='白坯' THEN A.GX04 WHEN A.GX04='砂光' THEN A.GX04 WHEN A.GX04='粘接' THEN A.GX04 WHEN A.GX04='组装' THEN A.GX04 WHEN A.GX04='返工' THEN A.GX04 ELSE '其它' END GX04,ISNULL(GZ,0) GZ,ISNULL(GZ1,0) GZ1 FROM (SELECT GX04,SUM(GZ) GZ FROM CET GROUP BY GX04) A  " );
            strSql.Append( " LEFT JOIN  " );
            strSql.Append( " (SELECT GX04,GZ39,SUM(GZ) GZ1 FROM CFT WHERE GZ39 IN('执行','审核') GROUP BY GX04,GZ39 ) B ON A.GX04=B.GX04 ORDER BY B.GX04 " );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ01",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取338数据
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqo ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            //strSql . Append ( "SELECT JM90,JM09,JM93,JM14,JM107,CONVERT(DECIMAL(18,2),SUM(JM)) JM,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(JM)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(JM)) END AK,AK017 FROM (" );
            //strSql . Append ( "SELECT A.idx,JM90,CASE WHEN JM09 LIKE '%密度板%' THEN '密度板' WHEN JM09 LIKE '%胶合板%' OR JM09 LIKE '%曲板%' THEN '胶合板' ELSE '胶合板' END JM09,JM93,JM14,CASE WHEN JM107='F' OR JM107 IS NULL THEN 'F' WHEN JM107='T' THEN 'T' END JM107,CASE WHEN JM10 = 0 THEN 0 WHEN JM10 != 0 THEN JM103/JM10* JM11 END JM,JM01,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQO A LEFT JOIN R_PQAL B ON A.JM01=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx AND C.AK017 IN ('执行','审核') INNER JOIN R_REVIEWS D ON A.JM01=D.RES06 WHERE JM90!='' AND RES05='执行' " );
            //strSql . Append ( "AND JM90=@JM90 AND (JM90!='' AND JM90 IS NOT NULL) " );
            //strSql . Append ( "GROUP BY A.idx,JM90,JM09,JM93,JM14,JM107,JM10,JM103,JM11,JM01,AK017 ) A " );
            //strSql . Append ( "GROUP BY JM90,JM09,JM93,JM14,JM107,ISNULL(AK011,0),AK017" );

            strSql . Append ( "SELECT JM90,JM09,JM93,JM14,JM107,CONVERT(DECIMAL(18,2),SUM(JM)) JM,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(JM)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(JM)) END AK,AK017 FROM (" );
            strSql . Append ( "SELECT A.idx,JM90,CASE WHEN JM09 LIKE '%密度板%' THEN '密度板' WHEN JM09 LIKE '%胶合板%' OR JM09 LIKE '%曲板%' THEN '胶合板' ELSE '胶合板' END JM09,JM93,JM14,CASE WHEN JM107='F' OR JM107 IS NULL THEN 'F' WHEN JM107='T' THEN 'T' END JM107,CASE WHEN JM10 = 0 THEN 0 WHEN JM10 != 0 THEN convert(decimal(11,0),JM103/JM10+ISNULL(JM118,0))*JM11 END JM,JM01,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQO A LEFT JOIN R_PQAL B ON A.JM01=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx INNER JOIN R_REVIEWS D ON A.JM01=D.RES06 WHERE JM90!='' AND RES05='执行' " );
            strSql . Append ( "AND JM90=@JM90 AND (JM90!='' AND JM90 IS NOT NULL) " );
            strSql . Append ( "GROUP BY A.idx,JM90,JM09,JM93,JM14,JM107,JM10,JM103,JM11,JM01,AK017,ISNULL(JM118,0) ) A WHERE AK017 IN ('执行','审核') " );
            strSql . Append ( "GROUP BY JM90,JM09,JM93,JM14,JM107,ISNULL(AK011,0),AK017" );

            SqlParameter [ ] paramter = {
                new SqlParameter("@JM90",SqlDbType.NVarChar)
            };
            paramter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,paramter );
        }
        public bool UpdatePqo ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT A.JM01,JM90,CASE WHEN JM09 LIKE '%密度板%' THEN '密度板' WHEN JM09 LIKE '%胶合板%' OR JM09 LIKE '%曲板%' THEN '胶合板' ELSE '胶合板' END JM09,JM93,JM14,CASE WHEN JM107='F' OR JM107 IS NULL THEN 'F' WHEN JM107='T' THEN 'T' END JM107,SUM(CASE WHEN JM10 = 0 THEN 0 WHEN JM10 != 0 THEN CONVERT( DECIMAL( 11 ,2 ) ,JM103 / JM10 * JM11 ) END ) JM FROM R_PQO A LEFT JOIN R_REVIEWS D ON A.JM01=D.RES06 AND RES05='执行' " );
            strSql.Append( " WHERE JM90=@JM90" );
            strSql.Append( " GROUP BY JM01,JM90,JM09,JM93,JM14,JM107" );
            SqlParameter[] parameter = {
                new SqlParameter("@JM90",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = model.AM002;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da != null && da.Rows.Count > 0 )
            {
                string oddNum = "";
                for ( int i = 0 ; i < da.Rows.Count ; i++ )
                {
                    oddNum = da.Rows[i]["JM01"].ToString( );
                    WriteReceivableToGeneralLedger.ByOneByJiao( model ,oddNum ,SQLString );
                }
            }

            if ( SQLString.Count > 0 )
                return SqlHelper.ExecuteSqlTran( SQLString );
            else
                return true;
        }

        /// <summary>
        /// 339
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqi ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            //strSql . Append ( "SELECT YQ12,YQ101,YQ123,CONVERT(DECIMAL(18,2),SUM(YQ)) YQ,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(YQ)) THEN ISNULL(AK011,0) ELSE  CONVERT(DECIMAL(18,2),SUM(YQ)) END AK,AK017 FROM (" );
            //strSql . Append ( "SELECT A.idx,YQ03,CASE WHEN YQ12 LIKE '%硝基漆%' THEN '硝基漆' WHEN YQ12 LIKE '%香蕉水%' THEN '香蕉水' ELSE CASE WHEN YQ33='T' OR YQ35='T' THEN '水性漆一类' ELSE '水性漆二类' END END YQ12,YQ101,CASE WHEN YQ123='T' THEN 'T' ELSE 'F' END YQ123,CASE WHEN YQ114=0 OR YQ115=0 THEN 0 WHEN YQ114!=0 AND YQ115!=0 THEN YQ108*YQ112*YQ113*YQ116*YQ13*YQ14*0.01/YQ114/YQ115 + YQ13*YQ16*YQ108*YQ112*YQ113*YQ114*YQ115*YQ116*0.000001 END YQ,YQ99,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQI A LEFT JOIN R_PQAL B ON A.YQ99=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx  AND C.AK017 IN ('执行','审核') INNER JOIN R_REVIEWS D ON A.YQ99=D.RES06 " );
            //strSql . Append ( "WHERE YQ03=@YQ03  AND RES05='执行' AND (YQ03!='' AND YQ03 IS NOT NULL) " );
            //strSql . Append ( "GROUP BY A.idx,YQ03,YQ12,YQ33,YQ35,YQ101,YQ123,YQ114,YQ115,YQ108,YQ112,YQ113,YQ116,YQ13,YQ14,YQ16,YQ99,AK017) A " );
            //strSql . Append ( "GROUP BY YQ12,YQ12,YQ101,YQ123,ISNULL(AK011,0),AK017" );

            strSql . Append ( "SELECT YQ12,YQ101,YQ123,CONVERT(DECIMAL(18,2),SUM(YQ)) YQ,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(YQ)) THEN ISNULL(AK011,0) ELSE  CONVERT(DECIMAL(18,2),SUM(YQ)) END AK,AK017 FROM (" );
            strSql . Append ( "SELECT A.idx,YQ03,CASE WHEN YQ12 LIKE '%硝基漆%' THEN '硝基漆' WHEN YQ12 LIKE '%香蕉水%' THEN '香蕉水' ELSE CASE WHEN YQ33='T' OR YQ35='T' THEN '水性漆一类' ELSE '水性漆二类' END END YQ12,YQ101,CASE WHEN YQ123='T' THEN 'T' ELSE 'F' END YQ123,CASE WHEN YQ114=0 OR YQ115=0 THEN 0 WHEN YQ114!=0 AND YQ115!=0 THEN YQ108*YQ112*YQ113*YQ116*YQ13*YQ14*0.01/YQ114/YQ115 + YQ13*YQ16*YQ108*YQ112*YQ113*YQ114*YQ115*YQ116*0.000001 END YQ,YQ99,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQI A LEFT JOIN R_PQAL B ON A.YQ99=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx INNER JOIN R_REVIEWS D ON A.YQ99=D.RES06 " );
            strSql . Append ( "WHERE YQ03=@YQ03 AND RES05='执行' AND (YQ03!='' AND YQ03 IS NOT NULL) " );
            strSql . Append ( "GROUP BY A.idx,YQ03,YQ12,YQ33,YQ35,YQ101,YQ123,YQ114,YQ115,YQ108,YQ112,YQ113,YQ116,YQ13,YQ14,YQ16,YQ99,AK017) A WHERE AK017 IN ('执行','审核') " );
            strSql . Append ( "GROUP BY YQ12,YQ12,YQ101,YQ123,ISNULL(AK011,0),AK017" );

            SqlParameter [ ] parameter = {
                new SqlParameter("@YQ03",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public bool UpdatePqi ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT A.YQ99,YQ03,CASE WHEN YQ12 LIKE '%硝基漆%' THEN '硝基漆' WHEN YQ12 LIKE '%香蕉水%' THEN '香蕉水' ELSE CASE WHEN YQ33='T' OR YQ35='T' THEN '水性漆一类' ELSE '水性漆二类' END END YQ12,YQ101,CASE WHEN YQ123='T' THEN 'T' ELSE 'F' END YQ123,SUM(CASE WHEN YQ114=0 OR YQ115=0 THEN 0 WHEN YQ114!=0 AND YQ115!=0 THEN CONVERT(DECIMAL(18,0),YQ108*YQ112*YQ113*YQ116*YQ13*YQ14*0.01/YQ114/YQ115 + YQ13*YQ16*YQ108*YQ112*YQ113*YQ114*YQ115*YQ116*0.000001) END) YQ FROM R_PQI A LEFT JOIN R_REVIEWS D ON A.YQ99=D.RES06 AND RES05='执行'" );
            strSql.Append( " WHERE YQ03=@YQ03" );
            strSql.Append( " GROUP BY YQ03,YQ12,YQ101,YQ123,YQ33,YQ35,A.YQ99" );
            SqlParameter[] parameter = {
                new SqlParameter("@YQ03",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = model.AM002;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da != null && da.Rows.Count > 0 )
            {
                string oddNum = "";
                for ( int i = 0 ; i < da.Rows.Count ; i++ )
                {
                    oddNum = da.Rows[i]["YQ99"].ToString( );
                    WriteReceivableToGeneralLedger.ByOneByYouQi( model ,oddNum ,SQLString );
                }
            }

            if ( SQLString.Count > 0 )
                return SqlHelper.ExecuteSqlTran( SQLString );
            else
                return true;
        }
        
        /// <summary>
        /// 285
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqk ( string num )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT CONVERT(DECIMAL(18,2),SUM(ISNULL(PQK10,0)*ISNULL(PQK25,0)+ISNULL(PQK31,0)*ISNULL(PQK25,0))) PQK,PQK01 FROM R_PQK" );
            strSql . Append ( " WHERE PQK02=@PQK02" );
            strSql . Append ( " GROUP BY PQK01" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PQK02",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = num;

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) , parameter );
        }
        public bool UpdatePqk ( MulaolaoLibrary . ProductCostSummaryLibrary model )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT CONVERT(DECIMAL(18,0),SUM(ISNULL(PQK10,0)*ISNULL(PQK25,0)+ISNULL(PQK31,0)*ISNULL(PQK25,0))) PQK,PQK01 FROM R_PQK" );
            strSql . Append ( " WHERE PQK02=@PQK02" );
            strSql . Append ( " GROUP BY PQK01" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PQK02",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = model . AM002;

            DataTable da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) , parameter );
            if ( da != null && da . Rows . Count > 0 )
            {
                string oddNum = "";
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    oddNum = da . Rows [ i ] [ "PQK01" ] . ToString ( );
                    WriteReceivableToGeneralLedger . ByOneByQiSum ( model , oddNum , SQLString );
                }
            }

            if ( SQLString . Count > 0 )
                return SqlHelper . ExecuteSqlTran ( SQLString );
            else
                return true;
        }

        /// <summary>
        /// 341
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqv ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql . Append ( "SELECT PQV01,PQV92,PQV86,PQV65,PQV88,CONVERT(DECIMAL(18,2),SUM(PQV)) PQV,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(PQV)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(PQV)) END AK,AK017 FROM (SELECT A.idx,PQV01,CASE WHEN PQV92='F' OR PQV92 IS NULL THEN 'F' WHEN PQV92='T' THEN 'T' END PQV92,CASE WHEN PQV86 LIKE '%荷%' THEN '荷木' WHEN PQV86 LIKE '%松%' THEN '新西兰松' WHEN PQV86 LIKE '%榉%' THEN '榉木' WHEN PQV86 LIKE '%椴%' THEN '椴木' WHEN PQV86 LIKE '%桦%' THEN '桦木' WHEN PQV86 LIKE '%杨%' THEN '杨木' ELSE '杂木' END PQV86,PQV65,CASE WHEN PQV88='T' THEN 'T' ELSE 'F' END PQV88,PQV11*PQV66*PQV81*PQV67*PQV13 PQV,PQV76,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQV A LEFT JOIN R_PQAL B ON A.PQV76=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx INNER JOIN R_REVIEWS D ON A.PQV76=D.RES06 " );
            strSql . Append ( "WHERE PQV01=@PQV01 AND RES05='执行' AND (PQV01!='' AND PQV01 IS NOT NULL) " );
            strSql . Append ( " GROUP BY A.idx,PQV01,PQV92,PQV86,PQV65,PQV88,PQV11,PQV66,PQV81,PQV67,PQV13,PQV76,PQV17,AK017) A WHERE AK017 IN ('执行','审核') GROUP BY PQV01,PQV92,PQV86,PQV65,PQV88,ISNULL(AK011,0),AK017 " );

            SqlParameter [ ] parameter = {
                new SqlParameter("@PQV01",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public bool UpdatePqv ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            //CASE WHEN PQV16>'95' OR PQV16='清水' THEN '清水' WHEN PQV16<'95' OR PQV16='混水' THEN '混水' END PQV16,
            strSql.Append( "SELECT A.PQV76,PQV01,CASE WHEN PQV92='F' OR PQV92 IS NULL THEN 'F' WHEN PQV92='T' THEN 'T' END PQV92,CASE WHEN PQV86 LIKE '%荷%' THEN '荷木' WHEN PQV86 LIKE '%松%' THEN '新西兰松' WHEN PQV86 LIKE '%榉%' THEN '榉木' WHEN PQV86 LIKE '%椴%' THEN '椴木' WHEN PQV86 LIKE '%桦%' THEN '桦木' ELSE '杂木' END PQV86,PQV65,CASE WHEN PQV88='T' THEN 'T' ELSE 'F' END PQV88,CONVERT(DECIMAL(18,1),SUM(PQV11*PQV66*PQV81*PQV67*PQV13)) PQV FROM R_PQV A LEFT JOIN R_REVIEWS D ON A.PQV76=D.RES06 AND RES05='执行'" );
            strSql.Append( " WHERE PQV01=@PQV01" );
            strSql.Append( " GROUP BY PQV01,PQV86,PQV65,PQV88,PQV92,A.PQV76" );
            SqlParameter[] parameter = {
                new SqlParameter("@PQV01",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = model.AM002;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da != null && da.Rows.Count > 0 )
            {
                string oddNum = "";
                for ( int i = 0 ; i < da.Rows.Count ; i++ )
                {
                    oddNum = da.Rows[i]["PQV01"].ToString( );
                    WriteReceivableToGeneralLedger.ByOneByMuCai( model ,oddNum ,SQLString );
                }
            }

            if ( SQLString.Count > 0 )
                return SqlHelper.ExecuteSqlTran( SQLString );
            else
                return true;
        }

        /// <summary>
        /// 342
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqaf ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            //合同若有部分在526没有执行，部分在526已经执行，则应付款会有误差，误差是应付款*2-未结款
            //strSql . Append ( "SELECT AF002,AF016,AF078,CONVERT(DECIMAL(18,2),SUM(AF)) AF,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(AF)) THEN ISNULL(AK011,0) ELSE  CONVERT(DECIMAL(18,2),SUM(AF)) END AK,AK017 FROM (" );
            //strSql . Append ( "SELECT A.idx,AF002,AF016,CASE WHEN AF078='T' THEN 'T' WHEN AF078='F' OR AF078 IS NULL THEN 'F' END AF078,AF023*AF006*AF019 AF,AF001,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQAF A LEFT JOIN R_PQAL B ON A.AF001=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx AND C.AK017 IN ('执行','审核') INNER JOIN R_REVIEWS D ON A.AF001=D.RES06 WHERE AF002!='' AND RES05='执行' " );
            //strSql . Append ( "AND AF002=@AF002 AND (AF002!='' AND AF002 IS NOT NULL) " );
            //strSql . Append ( "GROUP BY A.idx,AF002,AF016,AF078,AF006,AF023,AF019,AF001,AK017 " );
            //strSql . Append ( ") A  GROUP BY AF002,AF016,AF078,ISNULL(AK011,0),AK017" );
            //合同若有部分在526没有执行，部分在526已经执行，则应付款会有误差，误差是未结款
            strSql . Append ( "SELECT AF002,AF016,AF078,CONVERT(DECIMAL(18,2),SUM(AF)) AF,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(AF)) THEN ISNULL(AK011,0) ELSE  CONVERT(DECIMAL(18,2),SUM(AF)) END AK,AK017 FROM (" );
            strSql . Append ( "SELECT A.idx,AF002,AF016,CASE WHEN AF078='T' THEN 'T' WHEN AF078='F' OR AF078 IS NULL THEN 'F' END AF078,AF023*AF006*AF019 AF,AF001,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQAF A LEFT JOIN R_PQAL B ON A.AF001=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx INNER JOIN R_REVIEWS D ON A.AF001=D.RES06 WHERE AF002!='' AND RES05='执行' " );
            strSql . Append ( "AND AF002=@AF002 AND (AF002!='' AND AF002 IS NOT NULL) " );
            strSql . Append ( "GROUP BY A.idx,AF002,AF016,AF078,AF006,AF023,AF019,AF001,AK017 " );
            strSql . Append ( ") A WHERE AK017 IN ('执行','审核') GROUP BY AF002,AF016,AF078,ISNULL(AK011,0),AK017" );

            SqlParameter [ ] parameter = {
                new SqlParameter("@AF002",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public bool UpdatePqaf ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            //CASE WHEN  AF026='清水' THEN '清水' WHEN  AF026='混水' THEN '混水' END AF026,
            strSql.Append( "SELECT A.AF001,AF002,AF016,CASE WHEN AF078='T' THEN 'T' WHEN AF078='F' OR AF078 IS NULL THEN 'F' END AF078,CONVERT(DECIMAL(18,1),SUM(AF023*AF006*AF019)) AF FROM R_PQAF A LEFT JOIN R_REVIEWS D ON A.AF001=D.RES06 AND RES05='执行' " );
            strSql.Append( " WHERE AF002=@AF002" );
            strSql.Append( " GROUP BY AF002,AF016,AF078,A.AF001" );
            SqlParameter[] parameter = {
                new SqlParameter("@AF002",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = model.AM002;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da != null && da.Rows.Count > 0 )
            {
                string oddNum = "";
                for ( int i = 0 ; i < da.Rows.Count ; i++ )
                {
                    oddNum = da.Rows[i]["AF002"].ToString( );
                    WriteReceivableToGeneralLedger.ByOneByChe( model ,oddNum ,SQLString );
                }
            }

            if ( SQLString.Count > 0 )
                return SqlHelper.ExecuteSqlTran( SQLString );
            else
                return true;
        }
        
        /// <summary>
        /// 343
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqu ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            //strSql . Append ( "SELECT PQU107,PQU19,CONVERT(DECIMAL(18,2),SUM(PQ)) PQ,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(PQ)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(PQ)) END AK,AK017 FROM(" );
            //strSql . Append ( "SELECT A . idx ,PQU19 ,CASE WHEN PQU107 = 'T' THEN 'T' ELSE 'F' END PQU107 ,PQU16 * ( PQU101 * PQU13 + PQU14 ) PQ ,PQU97 ,SUM ( ISNULL ( AK011 ,0 ) ) AK011 ,AK017 FROM R_PQU A LEFT JOIN R_PQAL B ON A.PQU97=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx  AND C.AK017 IN ('执行','审核') INNER JOIN R_REVIEWS D ON A.PQU97=D.RES06 " );
            //strSql . Append ( "WHERE PQU01=@PQU01  AND RES05='执行' AND (PQU01!='' AND PQU01 IS NOT NULL) " );
            //strSql . Append ( "GROUP BY A.idx,PQU19,PQU107,PQU16,PQU101,PQU13,PQU14,PQU97,AK017) A GROUP BY PQU107,PQU19,ISNULL(AK011,0),AK017" );

            strSql . Append ( "SELECT PQU107,PQU19,CONVERT(DECIMAL(18,2),SUM(PQ)) PQ,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(PQ)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(PQ)) END AK,AK017 FROM(" );
            strSql . Append ( "SELECT A . idx ,PQU19 ,CASE WHEN PQU107 = 'T' THEN 'T' ELSE 'F' END PQU107 ,PQU16 * ( PQU101 * PQU13 + PQU14 ) PQ ,PQU97 ,SUM ( ISNULL ( AK011 ,0 ) ) AK011 ,AK017 FROM R_PQU A LEFT JOIN R_PQAL B ON A.PQU97=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx INNER JOIN R_REVIEWS D ON A.PQU97=D.RES06 " );
            strSql . Append ( "WHERE PQU01=@PQU01  AND RES05='执行' AND (PQU01!='' AND PQU01 IS NOT NULL) " );
            strSql . Append ( "GROUP BY A.idx,PQU19,PQU107,PQU16,PQU101,PQU13,PQU14,PQU97,AK017) A WHERE AK017 IN ('执行','审核') GROUP BY PQU107,PQU19,ISNULL(AK011,0),AK017" );

            SqlParameter [ ] parameter = {
                new SqlParameter("@PQU01",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;
            
            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public bool UpdatePqu ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT A.PQU97,PQU01,CASE WHEN PQU107='T' THEN 'T' ELSE 'F' END PQU107,CONVERT(DECIMAL(18,1),SUM(PQU16*(PQU101*PQU13+PQU14))) PQ FROM R_PQU A LEFT JOIN R_REVIEWS D ON A.PQU97=D.RES06 AND RES05='执行'" );
            strSql.Append( " WHERE PQU01=@PQU01" );
            strSql.Append( " GROUP BY PQU107,A.PQU97,PQU01" );
            SqlParameter[] parameter = {
                new SqlParameter("@PQU01",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = model.AM002;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da != null && da.Rows.Count > 0 )
            {
                string oddNum = "";
                for ( int i = 0 ; i < da.Rows.Count ; i++ )
                {
                    oddNum = da.Rows[i]["PQU01"].ToString( );
                    WriteReceivableToGeneralLedger.ByOneByWu( model ,oddNum ,SQLString );
                }
            }

            if ( SQLString.Count > 0 )
                return SqlHelper.ExecuteSqlTran( SQLString );
            else
                return true;
        }

        /// <summary>
        /// 347
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqs ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            //strSql . Append ( "SELECT PJ01,PJ100,PJ15,PJ105,CONVERT(DECIMAL(18,2),SUM(PQ)) PQ,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(PQ)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(PQ)) END AK,AK017 FROM (" );
            //strSql . Append ( "SELECT A.idx,PJ01,PJ15,CASE WHEN PJ100='T' THEN 'T' ELSE 'F' END PJ100,PJ09,PJ92,PJ12*(PJ11*PJ96+PJ10) PQ,PJ105,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQS A LEFT JOIN R_PQAL B ON A.PJ92=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx AND C.AK017 IN ('执行','审核') LEFT JOIN R_REVIEWS D ON A.PJ92=D.RES06 " );
            //strSql . Append ( "WHERE PJ01=@PJ01 AND RES01='R_347' AND RES05='执行' AND (PJ01!='' AND PJ01 IS NOT NULL) " );
            //strSql . Append ( "GROUP BY A.idx,PJ01,PJ15,PJ100,PJ09,PJ92,PJ12,PJ11,PJ96,PJ10,PJ105,AK017" );
            //strSql . Append ( ") A  GROUP BY PJ100,PJ105,PJ15,PJ01,AK017,ISNULL(AK011,0) ORDER BY PJ01" );

            strSql . Append ( "SELECT PJ01,PJ100,PJ15,PJ105,CONVERT(DECIMAL(18,2),SUM(PQ)) PQ,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(PQ)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(PQ)) END AK,AK017 FROM (" );
            strSql . Append ( "SELECT A.idx,PJ01,PJ15,CASE WHEN PJ100='T' THEN 'T' ELSE 'F' END PJ100,PJ09,PJ92,PJ12*(PJ11*PJ96+PJ10) PQ,PJ105,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQS A LEFT JOIN R_PQAL B ON A.PJ92=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx LEFT JOIN R_REVIEWS D ON A.PJ92=D.RES06 " );
            strSql . Append ( "WHERE PJ01=@PJ01 AND RES01='R_347' AND RES05='执行' AND (PJ01!='' AND PJ01 IS NOT NULL) " );
            strSql . Append ( "GROUP BY A.idx,PJ01,PJ15,PJ100,PJ09,PJ92,PJ12,PJ11,PJ96,PJ10,PJ105,AK017" );
            strSql . Append ( ") A WHERE AK017 IN ('执行','审核') GROUP BY PJ100,PJ105,PJ15,PJ01,AK017,ISNULL(AK011,0) ORDER BY PJ01" );

            SqlParameter [ ] parameter = {
                new SqlParameter("@PJ01",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public bool UpdatePqs ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT A.PJ92,PJ01,CASE WHEN PJ100='T' THEN 'T' ELSE 'F' END PJ100,CONVERT(DECIMAL(18,1),SUM(PJ12*(PJ11*PJ96+PJ10))) PQ,PJ105,PJ15 FROM R_PQS A LEFT JOIN R_REVIEWS D ON A.PJ92=D.RES06 AND RES01='R_347' AND RES05='执行'" );
            strSql.Append( " WHERE PJ01=@PJ01" );
            strSql.Append( " GROUP BY PJ100,A.PJ92,PJ105,PJ01,PJ15" );
            SqlParameter[] parameter = {
                new SqlParameter("@PJ01",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = model.AM002;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da != null && da.Rows.Count > 0 )
            {
                string oddNum = "";
                for ( int i = 0 ; i < da.Rows.Count ; i++ )
                {
                    oddNum = da.Rows[i]["PJ92"].ToString( );
                    WriteReceivableToGeneralLedger.ByOneBySu( model ,oddNum ,SQLString );
                }
            }

            if ( SQLString.Count > 0 )
                return SqlHelper.ExecuteSqlTran( SQLString );
            else
                return true;
        }

        /// <summary>
        /// 349
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqt ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            //strSql . Append ( "WITH CET AS (SELECT SUM(OZ) OZ,OZ011,COUN FROM (SELECT OZ005*OZ006 OZ,OZ011,COUNT(1) COUN FROM R_PQOZ GROUP BY OZ011,OZ005,OZ006) A GROUP BY OZ011,COUN)" );
            //strSql . Append ( ",CFT AS (SELECT X,Z,WX90,CONVERT(DECIMAL(18,2),SUM(OZ)) OZ,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(OZ)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(OZ)) END AK,AK017 FROM (" );
            //strSql . Append ( "SELECT '外箱' X,'外购' Z,CASE WHEN OZ=0 THEN 0 ELSE SUM(OZ009)/OZ*OZ005*OZ006/COUN END OZ,WX90,C.OZ011,OZ001,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQOZ TT LEFT JOIN TPADGA B ON TT.OZ014=B.DGA001 LEFT JOIN CET C ON TT.OZ011=C.OZ011 INNER JOIN R_REVIEWS D ON TT.OZ011=D.RES06 LEFT JOIN R_PQT E ON TT.OZ015=E.WX82 LEFT JOIN R_PQAK F ON TT.OZ011=F.AK003 AND TT.OZ001=F.AK002 " );
            //strSql . Append ( "WHERE TT.OZ001=@WX01  AND RES05='执行' AND F.AK017 IN ('执行','审核') " );
            //strSql . Append ( "GROUP BY OZ001,TT.OZ011,OZ,OZ005,OZ006,WX90,COUN,C.OZ011,AK017 " );
            //strSql . Append ( ") A  GROUP BY WX90,X,Z,ISNULL(AK011,0),AK017)" );
            //strSql . Append ( ",CHT AS(" );
            //strSql . Append ( "SELECT PJ105,PJ15,PJ100,CONVERT(DECIMAL(18,2),SUM(PQ)) PQ,CASE WHEN SUM(ISNULL(AK011,0))<CONVERT(DECIMAL(18,2),SUM(PQ)) THEN SUM(ISNULL(AK011,0)) ELSE CONVERT(DECIMAL(18,2),SUM(PQ)) END AK,A.AK017 FROM (SELECT A.idx,PJ15,CASE WHEN PJ100='T' THEN 'T' ELSE 'F' END PJ100,PJ09,PJ12*(PJ11*PJ96+PJ10) PQ,PJ105,PJ92,AK017 FROM R_PQS A LEFT JOIN R_PQAL B ON A.PJ92=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx  AND C.AK017 IN ('执行','审核') LEFT JOIN R_REVIEWS D ON A.PJ92=D.RES06 WHERE PJ01=@WX01 AND RES01='R_347' AND RES05='执行' AND (PJ01!='' AND PJ01 IS NOT NULL) AND PJ105='包装辅料' ) A LEFT JOIN R_PQAK B ON A.PJ92=B.AK003 GROUP BY PJ100,PJ105,PJ15,A.AK017) " );
            //strSql . Append ( "SELECT WX20,WX17,WX90,CONVERT(DECIMAL(18,2),SUM(PQ)) PQ,CONVERT(DECIMAL(18,2),CASE WHEN SUM(PQ)<ISNULL(AK011,0) THEN SUM(PQ) ELSE ISNULL(AK011,0) END) AK,A.AK017 FROM (" );
            //strSql . Append ( "SELECT A.idx,WX17,CASE WHEN WX90='T' THEN 'T' ELSE 'F' END WX90,WX20,CASE WHEN WX10='双瓦外箱' THEN ((WX27 + WX28 + WX29) * (WX30 + WX31 + WX32) + (WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15 WHEN WX10='小箱式' THEN ((WX27 + WX28 + WX29) * (WX30 + WX31 + WX32) + (WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15 WHEN WX10='牙膏式' THEN ((WX27 + 2*WX28 + WX29) * (2*WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15  WHEN WX10='插口式' THEN ((WX27 + 2*WX28 + WX29) * (2*WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10='天盖' THEN ((WX27 + 2*WX28 + WX29) * (WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10='地盖' THEN ((WX27 + 2*WX28 + WX29) * (WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10='折叠式' THEN ((2*WX27 + 2*WX28 + WX29) * (1.5*WX30 + WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10 NOT IN ('双瓦外箱','小箱式','牙膏式','插口式','天盖','地盖','折叠式') THEN (WX23 + WX24) * (WX25 + WX26) * 0.0001 * WX13* WX15 END PQ,WX82,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQT A LEFT JOIN R_PQAL B ON A.WX82=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx  AND C.AK017 IN ('执行','审核') INNER JOIN R_REVIEWS D ON A.WX82=D.RES06 " );
            //strSql . Append ( "WHERE WX01=@WX01 AND RES05='执行' AND (WX01!='' AND WX01 IS NOT NULL) AND LEN(WX01)<=8 GROUP BY A.idx,WX10,WX13,WX15,WX27,WX17,WX20,WX28,WX29,WX30,WX31,WX32,WX23,WX24,WX25,WX26,WX82,WX90,AK017) A GROUP BY WX20,WX90,WX17,ISNULL(AK011,0),A.AK017 " );
            //strSql . Append ( "UNION ALL " );
            //strSql . Append ( "SELECT * FROM CFT " );
            //strSql . Append ( "UNION ALL " );
            //strSql . Append ( "SELECT * FROM CHT" );

            strSql . Append ( "WITH CET AS (SELECT SUM(OZ) OZ,OZ011,COUN FROM (SELECT OZ005*OZ006 OZ,OZ011,COUNT(1) COUN FROM R_PQOZ GROUP BY OZ011,OZ005,OZ006) A GROUP BY OZ011,COUN)" );
            strSql . Append ( ",CFT AS (SELECT X,Z,WX90,CONVERT(DECIMAL(18,2),SUM(OZ)) OZ,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(OZ)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(OZ)) END AK,AK017 FROM (" );
            strSql . Append ( "SELECT '外箱' X,'外购' Z,CASE WHEN OZ=0 THEN 0 ELSE SUM(OZ009)/OZ*OZ005*OZ006/COUN END OZ,WX90,C.OZ011,OZ001,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQOZ TT LEFT JOIN TPADGA B ON TT.OZ014=B.DGA001 LEFT JOIN CET C ON TT.OZ011=C.OZ011 INNER JOIN R_REVIEWS D ON TT.OZ011=D.RES06 LEFT JOIN R_PQT E ON TT.OZ015=E.WX82 LEFT JOIN R_PQAK F ON TT.OZ011=F.AK003 AND TT.OZ001=F.AK002 " );
            strSql . Append ( "WHERE TT.OZ001=@WX01  AND RES05='执行' " );
            strSql . Append ( "GROUP BY OZ001,TT.OZ011,OZ,OZ005,OZ006,WX90,COUN,C.OZ011,AK017 " );
            strSql . Append ( ") A GROUP BY WX90,X,Z,ISNULL(AK011,0),AK017)" );
            strSql . Append ( ",CHT AS(" );
            strSql . Append ( "SELECT PJ105,PJ15,PJ100,CONVERT(DECIMAL(18,2),SUM(PQ)) PQ,CASE WHEN SUM(ISNULL(AK011,0))<CONVERT(DECIMAL(18,2),SUM(PQ)) THEN SUM(ISNULL(AK011,0)) ELSE CONVERT(DECIMAL(18,2),SUM(PQ)) END AK,A.AK017 FROM (SELECT A.idx,PJ15,CASE WHEN PJ100='T' THEN 'T' ELSE 'F' END PJ100,PJ09,PJ12*(PJ11*PJ96+PJ10) PQ,PJ105,PJ92,AK017 FROM R_PQS A LEFT JOIN R_PQAL B ON A.PJ92=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx LEFT JOIN R_REVIEWS D ON A.PJ92=D.RES06 WHERE PJ01=@WX01 AND RES01='R_347' AND RES05='执行' AND (PJ01!='' AND PJ01 IS NOT NULL) AND PJ105='包装辅料' ) A LEFT JOIN R_PQAK B ON A.PJ92=B.AK003 GROUP BY PJ100,PJ105,PJ15,A.AK017) " );
            strSql . Append ( "SELECT WX20,WX17,WX90,CONVERT(DECIMAL(18,2),SUM(PQ)) PQ,CONVERT(DECIMAL(18,2),CASE WHEN SUM(PQ)<ISNULL(AK011,0) THEN SUM(PQ) ELSE ISNULL(AK011,0) END) AK,A.AK017 FROM (" );
            strSql . Append ( "SELECT A.idx,WX17,CASE WHEN WX90='T' THEN 'T' ELSE 'F' END WX90,WX20,CASE WHEN WX10='双瓦外箱' THEN ((WX27 + WX28 + WX29) * (WX30 + WX31 + WX32) + (WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15 WHEN WX10='小箱式' THEN ((WX27 + WX28 + WX29) * (WX30 + WX31 + WX32) + (WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15 WHEN WX10='牙膏式' THEN ((WX27 + 2*WX28 + WX29) * (2*WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15  WHEN WX10='插口式' THEN ((WX27 + 2*WX28 + WX29) * (2*WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10='天盖' THEN ((WX27 + 2*WX28 + WX29) * (WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10='地盖' THEN ((WX27 + 2*WX28 + WX29) * (WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10='折叠式' THEN ((2*WX27 + 2*WX28 + WX29) * (1.5*WX30 + WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10 NOT IN ('双瓦外箱','小箱式','牙膏式','插口式','天盖','地盖','折叠式') THEN (WX23 + WX24) * (WX25 + WX26) * 0.0001 * WX13* WX15 END PQ,WX82,SUM(ISNULL(AK011,0)) AK011,AK017 FROM R_PQT A LEFT JOIN R_PQAL B ON A.WX82=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx INNER JOIN R_REVIEWS D ON A.WX82=D.RES06 " );
            strSql . Append ( "WHERE WX01=@WX01 AND RES05='执行' AND (WX01!='' AND WX01 IS NOT NULL) AND LEN(WX01)<=8 GROUP BY A.idx,WX10,WX13,WX15,WX27,WX17,WX20,WX28,WX29,WX30,WX31,WX32,WX23,WX24,WX25,WX26,WX82,WX90,AK017) A WHERE AK017 IN ('执行','审核') GROUP BY WX20,WX90,WX17,ISNULL(AK011,0),A.AK017 " );
            strSql . Append ( "UNION ALL " );
            strSql . Append ( "SELECT * FROM CFT WHERE AK017 IN ('执行','审核') " );
            strSql . Append ( "UNION ALL " );
            strSql . Append ( "SELECT * FROM CHT WHERE AK017 IN ('执行','审核') " );

            SqlParameter [] parameter = {
                new SqlParameter("@WX01",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public bool UpdatePqt ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT WX01,A.WX82,CASE WHEN WX90='T' THEN 'T' ELSE 'F' END WX90,WX20,SUM(CASE WHEN WX10='双瓦外箱' THEN CONVERT( DECIMAL( 11, 1 ), ((WX27 + WX28 + WX29) * (WX30 + WX31 + WX32) + (WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15 ) WHEN WX10='小箱式' THEN CONVERT( DECIMAL( 11, 1 ), ((WX27 + WX28 + WX29)* (WX30 + WX31 + WX32) + (WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15 ) WHEN WX10='牙膏式' THEN CONVERT( DECIMAL( 11, 1 ), ((WX27 + 2*WX28 + WX29) * (2*WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 ) WHEN WX10='插口式' THEN CONVERT( DECIMAL( 11, 1 ), ((WX27 + 2*WX28 + WX29)* (2*WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 ) WHEN WX10='天盖' THEN CONVERT( DECIMAL( 11, 1 ), ((WX27 + 2*WX28 + WX29)* (WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 ) WHEN WX10='地盖' THEN CONVERT( DECIMAL( 11, 1 ), ((WX27 + 2*WX28 + WX29)* (WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 ) WHEN WX10='折叠式' THEN CONVERT( DECIMAL( 11, 1 ), ((2*WX27 + 2*WX28 + WX29)* (1.5*WX30 + WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 ) WHEN WX10 NOT IN ('双瓦外箱','小箱式','牙膏式','插口式','天盖','地盖','折叠式') THEN CONVERT( DECIMAL( 11, 1 ), (WX23 + WX24) * (WX25 + WX26) * 0.0001 * WX13* WX15) END) PQ FROM R_PQT A LEFT JOIN R_REVIEWS D ON A.WX82=D.RES06 AND RES05='执行'" );
            strSql.Append( " WHERE WX01=@WX01 AND LEN(WX01)<=8" );
            strSql.Append( " GROUP BY WX20,WX90,A.WX82,WX01" );
            SqlParameter[] parameter = {
                new SqlParameter("@WX01",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = model.AM002;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da != null && da.Rows.Count > 0 )
            {
                string oddNum = "";
                for ( int i = 0 ; i < da.Rows.Count ; i++ )
                {
                    oddNum = da.Rows[i]["WX82"].ToString( );
                    WriteReceivableToGeneralLedger.ByOneByLiao( model ,oddNum ,SQLString );
                }
            }

            if ( SQLString.Count > 0 )
                return SqlHelper.ExecuteSqlTran( SQLString );
            else
                return true;
        }

        /// <summary>
        /// 344  漆款厂外
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqlz ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            //strSql . Append ( "SELECT MZ123,CONVERT(DECIMAL(18,2),SUM(MZ2)) MZ2,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(MZ2)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(MZ2)) END AK,A.AK017 FROM (" );
            //strSql . Append ( "SELECT  A.idx,MZ123,MZ022*MZ006*MZ028*MZ024+ISNULL(MZ120,0) MZ2,MZ001,AK017,SUM(ISNULL(AK011,0)) AK011 FROM R_PQMZ A LEFT JOIN R_PQAL B ON A.MZ001=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx  LEFT JOIN R_REVIEWS ON MZ001=RES06 " );
            //strSql . Append ( "WHERE MZ002=@MZ002 AND (MZ002!='' AND MZ002 IS NOT NULL)  AND C.AK017 IN ('执行','审核') AND RES05='执行' AND MZ107='厂外' " );
            //strSql . Append ( "GROUP BY MZ123,MZ022,MZ006,MZ028,MZ024,MZ120,MZ001,AK017,A.idx" );
            //strSql . Append ( ") A GROUP BY MZ123,ISNULL(AK011,0),A.AK017" );

            strSql . Append ( "SELECT MZ123,CONVERT(DECIMAL(18,2),SUM(MZ2)) MZ2,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(MZ2)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(MZ2)) END AK,A.AK017 FROM (" );
            strSql . Append ( "SELECT  A.idx,MZ123,MZ022*MZ006*MZ028*MZ024+ISNULL(MZ120,0) MZ2,MZ001,AK017,SUM(ISNULL(AK011,0)) AK011 FROM R_PQMZ A LEFT JOIN R_PQAL B ON A.MZ001=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx  LEFT JOIN R_REVIEWS ON MZ001=RES06 " );
            strSql . Append ( "WHERE MZ002=@MZ002 AND (MZ002!='' AND MZ002 IS NOT NULL) AND RES05='执行' AND MZ107='厂外' " );
            strSql . Append ( "GROUP BY MZ123,MZ022,MZ006,MZ028,MZ024,MZ120,MZ001,AK017,A.idx" );
            strSql . Append ( ") A WHERE AK017 IN ('执行','审核') GROUP BY MZ123,ISNULL(AK011,0),A.AK017" );

            SqlParameter [ ] parameter = {
                new SqlParameter("@MZ002",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public bool UpdatePqlz ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT MZ001,MZ123,MZ002,CONVERT(DECIMAL(18,0),SUM(MZ022*MZ006*MZ028*MZ024+ISNULL(MZ120,0))) MZ2 FROM R_PQMZ A LEFT JOIN R_REVIEWS ON MZ001=RES06 AND RES05='执行'" );
            strSql.Append( " WHERE MZ002=@MZ002 AND MZ107='厂外'" );
            strSql.Append( " GROUP BY MZ002,MZ123,MZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@MZ002",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = model.AM002;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da != null && da.Rows.Count > 0 )
            {
                string oddNum = "";
                for ( int i = 0 ; i < da.Rows.Count ; i++ )
                {
                    oddNum = da.Rows[i]["MZ001"].ToString( );
                    WriteReceivableToGeneralLedger.ByOneByQi( model ,oddNum ,SQLString );
                }
            }

            if ( SQLString.Count > 0 )
                return SqlHelper.ExecuteSqlTran( SQLString );
            else
                return true;
        }

        /// <summary>
        /// 346 漆款厂内
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqlzs ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            //344不会有超补  346是产品生产完之后再填单价  所以比344多出来的金额算是超补已付款
            //strSql.Append( "SELECT MZ002,MZ1,CASE WHEN MZ1>=PZ THEN PZ WHEN MZ1<PZ THEN MZ1 ELSE 0 END PZ,CASE WHEN MZ1<PZ THEN PZ-MZ1 ELSE 0 END PZ1,MZ123 FROM (SELECT PZ003,CONVERT(DECIMAL(18,0),SUM(PZ026*PZ017)) PZ FROM R_PQPZ" );
            //strSql.Append( " WHERE PZ003=@PZ" );
            //strSql.Append( " GROUP BY PZ003) A" );
            //strSql.Append( " RIGHT JOIN (" );
            //strSql.Append( " SELECT MZ002,MZ123, CONVERT(DECIMAL(18,0),SUM(MZ022*MZ006*MZ026*MZ024+ISNULL(MZ119,0))) MZ1 FROM R_PQMZ WHERE MZ107='厂内'" );
            //strSql.Append( " AND MZ002=@PZ" );
            //strSql.Append( " GROUP BY MZ123,MZ002) B ON A.PZ003=B.MZ002" );
            //344厂内漆由346读到241
            strSql.Append( "SELECT PZ003,CONVERT(DECIMAL(18,2),SUM(ISNULL(PZ026,0)*ISNULL(PZ017,0)+isnull(PZ034,0))) PZ FROM R_PQPZ" );
            strSql.Append( " WHERE PZ003=@PZ" );
            strSql.Append( " GROUP BY PZ003" );
            SqlParameter[] parameter = {
                new SqlParameter("@PZ",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 344漆款  厂内   （与346厂内漆款做对比  显示差额）
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqmzs ( string num )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MZ002,CONVERT(DECIMAL(18,2),SUM(MZ022*MZ006*MZ026*MZ024+ISNULL(MZ119,0))) MZ FROM R_PQMZ " );
            strSql . AppendFormat ( "WHERE MZ002='{0}'  AND MZ107='厂内'" ,num );
            strSql . Append ( " GROUP BY MZ002" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 344  工资
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqmz ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql . Append ( "SELECT CONVERT(DECIMAL(18,2),SUM(MZ0)) MZ0,CASE WHEN ISNULL(AK011,0)<CONVERT(DECIMAL(18,2),SUM(MZ0)) THEN ISNULL(AK011,0) ELSE CONVERT(DECIMAL(18,2),SUM(MZ0)) END AK FROM (" );
            strSql . Append ( "SELECT A.idx,CASE WHEN MZ107='厂内' THEN MZ022*MZ006*MZ027+ISNULL(MZ118,0) ELSE 0 END MZ0,MZ001,SUM(ISNULL(AK011,0)) AK011 FROM R_PQMZ A LEFT JOIN R_PQAL B ON A.MZ001=B.AL002 AND A.idx=B.AL003 LEFT JOIN R_PQAK C ON B.AL001=C.idx  LEFT JOIN R_REVIEWS ON MZ001=RES06 " );
            strSql . Append ( "WHERE MZ002=@MZ002 AND C.AK017 IN ('执行','审核') AND RES05='执行' AND (MZ002!='' AND MZ002 IS NOT NULL) " );
            strSql . Append ( "GROUP BY MZ107,MZ022,MZ006,MZ027,MZ118,MZ001,A.idx " );
            strSql . Append ( ") A  GROUP BY ISNULL(AK011,0)" );

            SqlParameter [ ] parameter = {
                new SqlParameter("@MZ002",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public bool UpdatePqmz ( MulaolaoLibrary.ProductCostSummaryLibrary model )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT MZ001,MZ002,CONVERT(DECIMAL(18,0),CASE WHEN MZ107='厂内' THEN SUM(MZ022*MZ006*MZ027+ISNULL(MZ118,0)) ELSE 0 END) MZ0 FROM R_PQMZ A LEFT JOIN R_REVIEWS ON MZ001=RES06 AND RES05='执行'" );
            strSql.Append( " WHERE MZ002=@MZ002" );
            strSql.Append( " GROUP BY MZ002,MZ107,MZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@MZ002",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = model.AM002;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da != null && da.Rows.Count > 0 )
            {
                string oddNum = "";
                for ( int i = 0 ; i < da.Rows.Count ; i++ )
                {
                    oddNum = da.Rows[i]["MZ001"].ToString( );
                    WriteReceivableToGeneralLedger.ByOneByQi( model ,oddNum ,SQLString );
                }
            }

            if ( SQLString.Count > 0 )
                return SqlHelper.ExecuteSqlTran( SQLString );
            else
                return true;
        }

        /// <summary>
        /// 243  运费
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePqbe ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT SUM(BE007) BE007,SUM(BE008) BE008,SUM(BE009) BE009,SUM(BE010) BE010,SUM(BE011+BE012) BE011 FROM R_PQBE" );
            strSql.Append( " WHERE BE002=@BE002 AND BE013 IN ('审核','执行')" );
            SqlParameter[] parameter = {
                new SqlParameter("@BE002",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取001已经执行数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePqf ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql . Append ( "SELECT PQF66 DAA002,DBA002,DFA003,PQF02,PQF04,PQF06,ISNULL(SUM(AE37),0) AE37,PQF09,PQF23,PQF24,PQF03,PQF01,MIN(AE21) AE21,CASE WHEN PQF10>0 THEN '是' ELSE '否' END PQF10 FROM R_PQF A LEFT JOIN TPADAA B ON PQF17=DAA001 LEFT JOIN TPADBA C ON C.DBA001=PQF55 LEFT JOIN TPADFA D ON PQF11= D.DFA001 LEFT JOIN R_PQAE E ON AE02=PQF01 LEFT JOIN R_REVIEWS F ON PQF01=RES06 " );
            if ( !string . IsNullOrEmpty ( num ) )
                strSql . AppendFormat ( "WHERE {0} AND RES05='执行' GROUP BY DBA002,DFA003,PQF02,PQF04,PQF06,PQF09,PQF23,PQF03,PQF01,PQF24,PQF10,PQF66 ORDER BY PQF01" ,num );
            else
                strSql . Append ( "WHERE RES05='执行' GROUP BY DAA002,DFA003,PQF02,PQF04,PQF06,PQF09,PQF23,PQF03,PQF01,PQF24,PQF10,PQF66 ORDER BY PQF01" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取车间主任
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableTpa ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DBA002,DAA002 FROM TPADBA A INNER JOIN (SELECT DAA001,DAA002 FROM TPADAA WHERE DAA002 IN (SELECT DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002='生产部'))) B ON A.DBA005=B.DAA001" );
            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 编辑标记
        /// </summary>
        /// <param name="dicIdx"></param>
        /// <returns></returns>
        public bool UpdateOfSign ( Dictionary<string ,string> dicIdx )
        {
            ArrayList SQLString = new ArrayList( );
            if ( dicIdx.Count > 0 )
            {
                foreach ( var item in dicIdx )
                {
                    StringBuilder strSql = new StringBuilder( );
                    strSql.Append( "UPDATE R_PQS SET " );
                    strSql.AppendFormat( " PJ105='{0}'" ,item.Value );
                    strSql.AppendFormat( " WHERE idx='{0}'" ,item.Key );
                    SQLString.Add( strSql.ToString( ) );
                }
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 更改241标记
        /// </summary>
        /// <returns></returns>
        public bool UpdateGetDataTable ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAK SET AK018='T' WHERE AK018!='T' AND AK002 IN (SELECT AM002 FROM R_PQAM)" );

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 批量编辑税率
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="deOne"></param>
        /// <param name="deTwo"></param>
        /// <returns></returns>
        public bool BatchEdit(string strWhere,decimal deOne,decimal deTwo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE R_PQAM SET ");
            strSql.Append("AM017=@AM017,");
            strSql.Append("AM018=@AM018");
            strSql.Append(" WHERE AM002 IN (" + strWhere + ")");
            SqlParameter[] parameter = {
                new SqlParameter("@AM017",SqlDbType.Decimal,5),
                new SqlParameter("@AM018",SqlDbType.Decimal,5)
            };
            parameter[0].Value = deOne;
            parameter[1].Value = deTwo;

            int row = SqlHelper.ExecuteNonQuery(strSql.ToString(), parameter);
            if (row > 0)
                return true;
            else
                return false;
        }

        #endregion
    }
}

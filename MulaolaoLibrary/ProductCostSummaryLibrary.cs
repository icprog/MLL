using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MulaolaoLibrary
{
    public class ProductCostSummaryLibrary
    {
        public ProductCostSummaryLibrary ( )
        {
        }
        
        #region model
        private int _idx;
        public int Idx
        {
            get
            {
                return _idx;
            }set
            {
                _idx = value;
            }
        }

        private string _am001;
        /// <summary>
        /// 单号
        /// </summary>
        public string AM001
        {
            get
            {
                return _am001;
            }set
            {
                _am001 = value;
            }
        }

        private string _am002;
        /// <summary>
        /// 流水号
        /// </summary>
        public string AM002
        {
            get
            {
                return _am002;
            }
            set
            {
                _am002 = value;
            }
        }

        private string _am003;
        /// <summary>
        /// 产品名称
        /// </summary>
        public string AM003
        {
            get
            {
                return _am003;
            }
            set
            {
                _am003 = value;
            }
        }

        private string _am004;
        /// <summary>
        /// 合同号
        /// </summary>
        public string AM004
        {
            get
            {
                return _am004;
            }
            set
            {
                _am004 = value;
            }
        }

        private string _am005;
        /// <summary>
        /// 货号
        /// </summary>
        public string AM005
        {
            get
            {
                return _am005;
            }
            set
            {
                _am005 = value;
            }
        }

        private long _am006;
        /// <summary>
        /// 产品数量
        /// </summary>
        public long AM006
        {
            get
            {
                return _am006;
            }
            set
            {
                _am006 = value;
            }
        }

        private DateTime? _am007;
        /// <summary>
        /// 出货月份
        /// </summary>
        public DateTime? AM007
        {
            get
            {
                return _am007;
            }
            set
            {
                _am007 = value;
            }
        }

        private string _am008;
        /// <summary>
        /// 跟单组长
        /// </summary>
        public string AM008
        {
            get
            {
                return _am008;
            }
            set
            {
                _am008 = value;
            }
        }

        private string _am009;
        /// <summary>
        /// 车间主任
        /// </summary>
        public string AM009
        {
            get
            {
                return _am009;
            }
            set
            {
                _am009 = value;
            }
        }

        private string _am010;
        /// <summary>
        /// 业务员
        /// </summary>
        public string AM010
        {
            get
            {
                return _am010;
            }
            set
            {
                _am010 = value;
            }
        }

        private string _am011;
        /// <summary>
        /// 客户
        /// </summary>
        public string AM011
        {
            get
            {
                return _am011;
            }
            set
            {
                _am011 = value;
            }
        }

        private string _am012;
        /// <summary>
        /// FSC
        /// </summary>
        public string AM012
        {
            get
            {
                return _am012;
            }
            set
            {
                _am012 = value;
            }
        }

        private string _am013;
        /// <summary>
        /// 专利产品
        /// </summary>
        public string AM013
        {
            get
            {
                return _am013;
            }
            set
            {
                _am013 = value;
            }
        }

        private string _am014;
        /// <summary>
        /// 出口退税产品
        /// </summary>
        public string AM014
        {
            get
            {
                return _am014;
            }
            set
            {
                _am014 = value;
            }
        }

        private long _am015;
        /// <summary>
        /// 发货产品数量
        /// </summary>
        public long AM015
        {
            get
            {
                return _am015;
            }
            set
            {
                _am015 = value;
            }
        }

        private decimal _am016;
        /// <summary>
        /// 销售单价
        /// </summary>
        public decimal AM016
        {
            get
            {
                return _am016;
            }
            set
            {
                _am016 = value;
            }
        }

        private decimal _am017;
        /// <summary>
        /// 税率%
        /// </summary>
        public decimal AM017
        {
            get
            {
                return _am017;
            }
            set
            {
                _am017 = value;
            }
        }

        private decimal _am018;
        /// <summary>
        /// 后道费用%
        /// </summary>
        public decimal AM018
        {
            get
            {
                return _am018;
            }
            set
            {
                _am018 = value;
            }
        }

        private decimal _am019;
        /// <summary>
        /// 合计扣责任赔偿款
        /// </summary>
        public decimal AM019
        {
            get
            {
                return _am019;
            }
            set
            {
                _am019 = value;
            }
        }

        private decimal _am020;
        /// <summary>
        /// 装运费合同应付款额
        /// </summary>
        public decimal AM020
        {
            get
            {
                return _am020;
            }
            set
            {
                _am020 = value;
            }
        }

        private decimal _am021;
        /// <summary>
        /// 装运费合同已付款额
        /// </summary>
        public decimal AM021
        {
            get
            {
                return _am021;
            }
            set
            {
                _am021 = value;
            }
        }

        private decimal _am022;
        /// <summary>
        /// 拖柜费合同应付款
        /// </summary>
        public decimal AM022
        {
            get
            {
                return _am022;
            }
            set
            {
                _am022 = value;
            }
        }

        private decimal _am023;
        /// <summary>
        /// 拖柜费合同已付款
        /// </summary>
        public decimal AM023
        {
            get
            {
                return _am023;
            }
            set
            {
                _am023 = value;
            }
        }

        private decimal _am024;
        /// <summary>
        /// 代理费合同应付款
        /// </summary>
        public decimal AM024
        {
            get
            {
                return _am024;
            }
            set
            {
                _am024 = value;
            }
        }

        private decimal _am025;
        /// <summary>
        /// 代理费合同已付款
        /// </summary>
        public decimal AM025
        {
            get
            {
                return _am025;
            }
            set
            {
                _am025 = value;
            }
        }

        private decimal _am026;
        /// <summary>
        /// 检测费合同应付款
        /// </summary>
        public decimal AM026
        {
            get
            {
                return _am026;
            }
            set
            {
                _am026 = value;
            }
        }

        private decimal _am027;
        /// <summary>
        /// 检测费合同已付款额
        /// </summary>
        public decimal AM027
        {
            get
            {
                return _am027;
            }
            set
            {
                _am027 = value;
            }
        }

        private decimal _am028;
        /// <summary>
        /// 其它费用合同应付款金额
        /// </summary>
        public decimal AM028
        {
            get
            {
                return _am028;
            }
            set
            {
                _am028 = value;
            }
        }

        private decimal _am029;
        /// <summary>
        /// 其它费用合同已付款额
        /// </summary>
        public decimal AM029
        {
            get
            {
                return _am029;
            }
            set
            {
                _am029 = value;
            }
        }

        private decimal _am030;
        /// <summary>
        /// 运费备用1合同应付款
        /// </summary>
        public decimal AM030
        {
            get
            {
                return _am030;
            }
            set
            {
                _am030 = value;
            }
        }

        private decimal _am031;
        /// <summary>
        /// 运费备用1合同已付款
        /// </summary>
        public decimal AM031
        {
            get
            {
                return _am031;
            }
            set
            {
                _am031 = value;
            }
        }

        private decimal _am032;
        /// <summary>
        /// 运费备用2合同应付款
        /// </summary>
        public decimal AM032
        {
            get
            {
                return _am032;
            }
            set
            {
                _am032 = value;
            }
        }

        private decimal _am033;
        /// <summary>
        /// 运费备用2合同已付款
        /// </summary>
        public decimal AM033
        {
            get
            {
                return _am033;
            }
            set
            {
                _am033 = value;
            }
        }

        private decimal _am034;
        /// <summary>
        /// 运费备用3合同应付款
        /// </summary>
        public decimal AM034
        {
            get
            {
                return _am034;
            }
            set
            {
                _am034 = value;
            }
        }

        private decimal _am035;
        /// <summary>
        /// 运费备用3合同已付款
        /// </summary>
        public decimal AM035
        {
            get
            {
                return _am035;
            }
            set
            {
                _am035 = value;
            }
        }

        private decimal _am036;
        /// <summary>
        /// 运费备用4合同应付款
        /// </summary>
        public decimal AM036
        {
            get
            {
                return _am036;
            }
            set
            {
                _am036 = value;
            }
        }

        private decimal _am037;
        /// <summary>
        /// 运费备用4合同已付款
        /// </summary>
        public decimal AM037
        {
            get
            {
                return _am037;
            }
            set
            {
                _am037 = value;
            }
        }

        private decimal _am038;
        /// <summary>
        /// 运费备用5合同应付款
        /// </summary>
        public decimal AM038
        {
            get
            {
                return _am038;
            }
            set
            {
                _am038 = value;
            }
        }

        private decimal _am039;
        /// <summary>
        /// 运费备用5合同已付款
        /// </summary>
        public decimal AM039
        {
            get
            {
                return _am039;
            }
            set
            {
                _am039 = value;
            }
        }

        private decimal _am040;
        /// <summary>
        /// 运费备用6合同应付款
        /// </summary>
        public decimal AM040
        {
            get
            {
                return _am040;
            }
            set
            {
                _am040 = value;
            }
        }

        private decimal _am041;
        /// <summary>
        ///运费备用6合同已付款
        /// </summary>
        public decimal AM041
        {
            get
            {
                return _am041;
            }
            set
            {
                _am041 = value;
            }
        }

        private decimal _am042;
        /// <summary>
        ///费备用7合同应付款
        /// </summary>
        public decimal AM042
        {
            get
            {
                return _am042;
            }
            set
            {
                _am042 = value;
            }
        }

        private decimal _am043;
        /// <summary>
        ///运费备用7合同已付款
        /// </summary>
        public decimal AM043
        {
            get
            {
                return _am043;
            }
            set
            {
                _am043 = value;
            }
        }

        private decimal _am044;
        /// <summary>
        ///白坯工资合同应付款
        /// </summary>
        public decimal AM044
        {
            get
            {
                return _am044;
            }
            set
            {
                _am044 = value;
            }
        }

        private decimal _am045;
        /// <summary>
        ///白坯工资合同已付款
        /// </summary>
        public decimal AM045
        {
            get
            {
                return _am045;
            }
            set
            {
                _am045 = value;
            }
        }

        private decimal _am046;
        /// <summary>
        ///砂光工资合同应付款
        /// </summary>
        public decimal AM046
        {
            get
            {
                return _am046;
            }
            set
            {
                _am046 = value;
            }
        }

        private decimal _am047;
        /// <summary>
        ///砂光工资合同已付款
        /// </summary>
        public decimal AM047
        {
            get
            {
                return _am047;
            }
            set
            {
                _am047 = value;
            }
        }

        private decimal _am048;
        /// <summary>
        ///粘结工资合同应付款
        /// </summary>
        public decimal AM048
        {
            get
            {
                return _am048;
            }
            set
            {
                _am048 = value;
            }
        }

        private decimal _am049;
        /// <summary>
        ///粘结工资合同已付款
        /// </summary>
        public decimal AM049
        {
            get
            {
                return _am049;
            }
            set
            {
                _am049 = value;
            }
        }

        private decimal _am050;
        /// <summary>
        ///组装工资合同应付款
        /// </summary>
        public decimal AM050
        {
            get
            {
                return _am050;
            }
            set
            {
                _am050 = value;
            }
        }

        private decimal _am051;
        /// <summary>
        ///组装工资合同已付款
        /// </summary>
        public decimal AM051
        {
            get
            {
                return _am051;
            }
            set
            {
                _am051 = value;
            }
        }

        private decimal _am052;
        /// <summary>
        ///验收工资合同应付款
        /// </summary>
        public decimal AM052
        {
            get
            {
                return _am052;
            }
            set
            {
                _am052 = value;
            }
        }

        private decimal _am053;
        /// <summary>
        ///验收工资合同已付款
        /// </summary>
        public decimal AM053
        {
            get
            {
                return _am053;
            }
            set
            {
                _am053 = value;
            }
        }

        private decimal _am054;
        /// <summary>
        ///包装工资合同应付款额
        /// </summary>
        public decimal AM054
        {
            get
            {
                return _am054;
            }
            set
            {
                _am054 = value;
            }
        }

        private decimal _am055;
        /// <summary>
        ///包装工资合同已付款额
        /// </summary>
        public decimal AM055
        {
            get
            {
                return _am055;
            }
            set
            {
                _am055 = value;
            }
        }

        private decimal _am056;
        /// <summary>
        ///修理工资合同应付款
        /// </summary>
        public decimal AM056
        {
            get
            {
                return _am056;
            }
            set
            {
                _am056 = value;
            }
        }

        private decimal _am057;
        /// <summary>
        ///修理工资合同已付款
        /// </summary>
        public decimal AM057
        {
            get
            {
                return _am057;
            }
            set
            {
                _am057 = value;
            }
        }

        private decimal _am058;
        /// <summary>
        ///后勤辅助工资应付款
        /// </summary>
        public decimal AM058
        {
            get
            {
                return _am058;
            }
            set
            {
                _am058 = value;
            }
        }

        private decimal _am059;
        /// <summary>
        ///后勤辅助工资已付款
        /// </summary>
        public decimal AM059
        {
            get
            {
                return _am059;
            }
            set
            {
                _am059 = value;
            }
        }

        private decimal _am060;
        /// <summary>
        ///返工工资应付款
        /// </summary>
        public decimal AM060
        {
            get
            {
                return _am060;
            }
            set
            {
                _am060 = value;
            }
        }

        private decimal _am061;
        /// <summary>
        ///返工工资已付款
        /// </summary>
        public decimal AM061
        {
            get
            {
                return _am061;
            }
            set
            {
                _am061 = value;
            }
        }

        private decimal _am062;
        /// <summary>
        ///其它工资应付款
        /// </summary>
        public decimal AM062
        {
            get
            {
                return _am062;
            }
            set
            {
                _am062 = value;
            }
        }

        private decimal _am063;
        /// <summary>
        ///其它工资已付款
        /// </summary>
        public decimal AM063
        {
            get
            {
                return _am063;
            }
            set
            {
                _am063 = value;
            }
        }

        private decimal _am064;
        /// <summary>
        ///工资5合同应付款
        /// </summary>
        public decimal AM064
        {
            get
            {
                return _am064;
            }
            set
            {
                _am064 = value;
            }
        }

        private decimal _am065;
        /// <summary>
        ///工资5合同已付款
        /// </summary>
        public decimal AM065
        {
            get
            {
                return _am065;
            }
            set
            {
                _am065 = value;
            }
        }

        private decimal _am066;
        /// <summary>
        ///工资6合同应付款
        /// </summary>
        public decimal AM066
        {
            get
            {
                return _am066;
            }
            set
            {
                _am066 = value;
            }
        }

        private decimal _am067;
        /// <summary>
        ///工资6合同已付款
        /// </summary>
        public decimal AM067
        {
            get
            {
                return _am067;
            }
            set
            {
                _am067 = value;
            }
        }

        private decimal _am068;
        /// <summary>
        ///工资7合同应付款
        /// </summary>
        public decimal AM068
        {
            get
            {
                return _am068;
            }
            set
            {
                _am068 = value;
            }
        }

        private decimal _am069;
        /// <summary>
        ///工资7合同已付款
        /// </summary>
        public decimal AM069
        {
            get
            {
                return _am069;
            }
            set
            {
                _am069 = value;
            }
        }

        private decimal _am070;
        /// <summary>
        ///雕刻工资合同应付款
        /// </summary>
        public decimal AM070
        {
            get
            {
                return _am070;
            }
            set
            {
                _am070 = value;
            }
        }

        private decimal _am071;
        /// <summary>
        ///雕刻工资合同已付款
        /// </summary>
        public decimal AM071
        {
            get
            {
                return _am071;
            }
            set
            {
                _am071 = value;
            }
        }

        private decimal _am072;
        /// <summary>
        ///绕锯工资合同应付款
        /// </summary>
        public decimal AM072
        {
            get
            {
                return _am072;
            }
            set
            {
                _am072 = value;
            }
        }

        private decimal _am073;
        /// <summary>
        ///绕锯工资合同已付款
        /// </summary>
        public decimal AM073
        {
            get
            {
                return _am073;
            }
            set
            {
                _am073 = value;
            }
        }

        private decimal _am074;
        /// <summary>
        ///夹料工资合同应付款
        /// </summary>
        public decimal AM074
        {
            get
            {
                return _am074;
            }
            set
            {
                _am074 = value;
            }
        }

        private decimal _am075;
        /// <summary>
        ///夹料工资合同已付款
        /// </summary>
        public decimal AM075
        {
            get
            {
                return _am075;
            }
            set
            {
                _am075 = value;
            }
        }

        private decimal _am076;
        /// <summary>
        ///擦砂皮工资合同应付款
        /// </summary>
        public decimal AM076
        {
            get
            {
                return _am076;
            }
            set
            {
                _am076 = value;
            }
        }

        private decimal _am077;
        /// <summary>
        ///擦砂皮工资合同已付款
        /// </summary>
        public decimal AM077
        {
            get
            {
                return _am077;
            }
            set
            {
                _am077 = value;
            }
        }

        private decimal _am078;
        /// <summary>
        ///丝印工资合同应付款
        /// </summary>
        public decimal AM078
        {
            get
            {
                return _am078;
            }
            set
            {
                _am078 = value;
            }
        }

        private decimal _am079;
        /// <summary>
        ///丝印工资合同已付款
        /// </summary>
        public decimal AM079
        {
            get
            {
                return _am079;
            }
            set
            {
                _am079 = value;
            }
        }

        private decimal _am080;
        /// <summary>
        ///走台印工资合同应付款
        /// </summary>
        public decimal AM080
        {
            get
            {
                return _am080;
            }
            set
            {
                _am080 = value;
            }
        }

        private decimal _am081;
        /// <summary>
        ///走台印工资合同已付款
        /// </summary>
        public decimal AM081
        {
            get
            {
                return _am081;
            }
            set
            {
                _am081 = value;
            }
        }

        private decimal _am082;
        /// <summary>
        ///移印工资合同应付款
        /// </summary>
        public decimal AM082
        {
            get
            {
                return _am082;
            }
            set
            {
                _am082 = value;
            }
        }

        private decimal _am083;
        /// <summary>
        ///移印工资合同已付款
        /// </summary>
        public decimal AM083
        {
            get
            {
                return _am083;
            }
            set
            {
                _am083 = value;
            }
        }

        private decimal _am084;
        /// <summary>
        ///热转印工资合同应付款
        /// </summary>
        public decimal AM084
        {
            get
            {
                return _am084;
            }
            set
            {
                _am084 = value;
            }
        }

        private decimal _am085;
        /// <summary>
        ///热转印工资合同已付款
        /// </summary>
        public decimal AM085
        {
            get
            {
                return _am085;
            }
            set
            {
                _am085 = value;
            }
        }

        private decimal _am086;
        /// <summary>
        ///烫印工资合同应付款
        /// </summary>
        public decimal AM086
        {
            get
            {
                return _am086;
            }
            set
            {
                _am086 = value;
            }
        }

        private decimal _am087;
        /// <summary>
        ///烫印工资合同已付款
        /// </summary>
        public decimal AM087
        {
            get
            {
                return _am087;
            }
            set
            {
                _am087 = value;
            }
        }

        private decimal _am088;
        /// <summary>
        ///喷漆工资合同应付款
        /// </summary>
        public decimal AM088
        {
            get
            {
                return _am088;
            }
            set
            {
                _am088 = value;
            }
        }

        private decimal _am089;
        /// <summary>
        ///喷漆工资合同已付款
        /// </summary>
        public decimal AM089
        {
            get
            {
                return _am089;
            }
            set
            {
                _am089 = value;
            }
        }

        private decimal _am090;
        /// <summary>
        ///冲压工资合同应付款
        /// </summary>
        public decimal AM090
        {
            get
            {
                return _am090;
            }
            set
            {
                _am090 = value;
            }
        }

        private decimal _am091;
        /// <summary>
        ///冲压工资合同已付款
        /// </summary>
        public decimal AM091
        {
            get
            {
                return _am091;
            }
            set
            {
                _am091 = value;
            }
        }

        private decimal _am092;
        /// <summary>
        ///手工剪切/其它工资合同应付款
        /// </summary>
        public decimal AM092
        {
            get
            {
                return _am092;
            }
            set
            {
                _am092 = value;
            }
        }

        private decimal _am093;
        /// <summary>
        ///手工剪切/其它工资合同已付款
        /// </summary>
        public decimal AM093
        {
            get
            {
                return _am093;
            }
            set
            {
                _am093 = value;
            }
        }

        private decimal _am094;
        /// <summary>
        ///承揽加工1应收合同应付款
        /// </summary>
        public decimal AM094
        {
            get
            {
                return _am094;
            }
            set
            {
                _am094 = value;
            }
        }

        private decimal _am095;
        /// <summary>
        ///承揽加工1应收合同已付款
        /// </summary>
        public decimal AM095
        {
            get
            {
                return _am095;
            }
            set
            {
                _am095 = value;
            }
        }

        private decimal _am096;
        /// <summary>
        ///承揽加工2应收合同应付款
        /// </summary>
        public decimal AM096
        {
            get
            {
                return _am096;
            }
            set
            {
                _am096 = value;
            }
        }

        private decimal _am097;
        /// <summary>
        ///承揽加工2应收合同已付款
        /// </summary>
        public decimal AM097
        {
            get
            {
                return _am097;
            }
            set
            {
                _am097 = value;
            }
        }

        private decimal _am098;
        /// <summary>
        ///承揽加工3应收合同应付款
        /// </summary>
        public decimal AM098
        {
            get
            {
                return _am098;
            }
            set
            {
                _am098 = value;
            }
        }

        private decimal _am099;
        /// <summary>
        ///承揽加工3应收合同已付款
        /// </summary>
        public decimal AM099
        {
            get
            {
                return _am099;
            }
            set
            {
                _am099 = value;
            }
        }

        private decimal _am100;
        /// <summary>
        ///承揽加工4应收合同应付款
        /// </summary>
        public decimal AM100
        {
            get
            {
                return _am100;
            }
            set
            {
                _am100 = value;
            }
        }

        private decimal _am101;
        /// <summary>
        ///承揽加工4应收合同已付款
        /// </summary>
        public decimal AM101
        {
            get
            {
                return _am101;
            }
            set
            {
                _am101 = value;
            }
        }

        private decimal _am102;
        /// <summary>
        ///承揽加工5应收合同应付款
        /// </summary>
        public decimal AM102
        {
            get
            {
                return _am102;
            }
            set
            {
                _am102 = value;
            }
        }

        private decimal _am103;
        /// <summary>
        ///承揽加工5应收合同已付款
        /// </summary>
        public decimal AM103
        {
            get
            {
                return _am103;
            }
            set
            {
                _am103 = value;
            }
        }

        private decimal _am104;
        /// <summary>
        ///承揽加工6应收合同应付款
        /// </summary>
        public decimal AM104
        {
            get
            {
                return _am104;
            }
            set
            {
                _am104 = value;
            }
        }

        private decimal _am105;
        /// <summary>
        ///承揽加工6应收合同已付款
        /// </summary>
        public decimal AM105
        {
            get
            {
                return _am105;
            }
            set
            {
                _am105 = value;
            }
        }

        private decimal _am106;
        /// <summary>
        ///承揽加工7应收合同应付款
        /// </summary>
        public decimal AM106
        {
            get
            {
                return _am106;
            }
            set
            {
                _am106 = value;
            }
        }

        private decimal _am107;
        /// <summary>
        ///承揽加工7应收合同已付款
        /// </summary>
        public decimal AM107
        {
            get
            {
                return _am107;
            }
            set
            {
                _am107 = value;
            }
        }

        private decimal _am108;
        /// <summary>
        ///成品委外A类应收合同款
        /// </summary>
        public decimal AM108
        {
            get
            {
                return _am108;
            }
            set
            {
                _am108 = value;
            }
        }

        private decimal _am109;
        /// <summary>
        ///成品委外A已付合同款
        /// </summary>
        public decimal AM109
        {
            get
            {
                return _am109;
            }
            set
            {
                _am109 = value;
            }
        }

        private decimal _am110;
        /// <summary>
        /// 成品委外A类超补应付款
        /// </summary>
        public decimal AM110
        {
            get
            {
                return _am110;
            }
            set
            {
                _am110 = value;
            }
        }

        private decimal _am113;
        /// <summary>
        /// 成品委外A类超补已付款
        /// </summary>
        public decimal AM113
        {
            get
            {
                return _am113;
            }
            set
            {
                _am113 = value;
            }
        }

        private decimal _am111;
        /// <summary>
        ///成品委外B类应收合同款
        /// </summary>
        public decimal AM111
        {
            get
            {
                return _am111;
            }
            set
            {
                _am111 = value;
            }
        }

        private decimal _am112;
        /// <summary>
        ///成品委外B已付合同款
        /// </summary>
        public decimal AM112
        {
            get
            {
                return _am112;
            }
            set
            {
                _am112 = value;
            }
        }

        private string _am114;
        /// <summary>
        /// 成品委外B类是否隐藏
        /// </summary>
        public string AM114
        {
            get
            {
                return _am114;
            }
            set
            {
                _am114 = value;
            }
        }

        private decimal _am115;
        /// <summary>
        ///成品委外B类超补应付款
        /// </summary>
        public decimal AM115
        {
            get
            {
                return _am115;
            }
            set
            {
                _am115 = value;
            }
        }

        private decimal _am116;
        /// <summary>
        ///成品委外B类超补已付款
        /// </summary>
        public decimal AM116
        {
            get
            {
                return _am116;
            }
            set
            {
                _am116 = value;
            }
        }

        private string _am117;
        /// <summary>
        /// 成品委外C类是否超补
        /// </summary>
        public string AM117
        {
            get
            {
                return _am117;
            }
            set
            {
                _am117 = value;
            }
        }

        private decimal _am118;
        /// <summary>
        ///成品委外D类应收合同款
        /// </summary>
        public decimal AM118
        {
            get
            {
                return _am118;
            }
            set
            {
                _am118 = value;
            }
        }

        private decimal _am119;
        /// <summary>
        ///成品委外D已付合同款
        /// </summary>
        public decimal AM119
        {
            get
            {
                return _am119;
            }
            set
            {
                _am119 = value;
            }
        }

        private string _am120;
        /// <summary>
        /// 成品委外D类是否超补
        /// </summary>
        public string AM120
        {
            get
            {
                return _am120;
            }
            set
            {
                _am120 = value;
            }
        }

        private decimal _am121;
        /// <summary>
        ///成品委外E类应收合同款
        /// </summary>
        public decimal AM121
        {
            get
            {
                return _am121;
            }
            set
            {
                _am121 = value;
            }
        }

        private decimal _am122;
        /// <summary>
        ///成品委外E已付合同款
        /// </summary>
        public decimal AM122
        {
            get
            {
                return _am122;
            }
            set
            {
                _am122 = value;
            }
        }

        private string _am123;
        /// <summary>
        /// 成品委外E类是否超补
        /// </summary>
        public string AM123
        {
            get
            {
                return _am123;
            }
            set
            {
                _am123 = value;
            }
        }

        private decimal _am124;
        /// <summary>
        ///成品委外F类应收合同款
        /// </summary>
        public decimal AM124
        {
            get
            {
                return _am124;
            }
            set
            {
                _am124 = value;
            }
        }

        private decimal _am125;
        /// <summary>
        ///成品委外F已付合同款
        /// </summary>
        public decimal AM125
        {
            get
            {
                return _am125;
            }
            set
            {
                _am125 = value;
            }
        }

        private string _am126;
        /// <summary>
        /// 成品委外F类是否超补
        /// </summary>
        public string AM126
        {
            get
            {
                return _am126;
            }
            set
            {
                _am126 = value;
            }
        }

        private decimal _am127;
        /// <summary>
        ///成品委外G类应收合同款
        /// </summary>
        public decimal AM127
        {
            get
            {
                return _am127;
            }
            set
            {
                _am127 = value;
            }
        }

        private decimal _am128;
        /// <summary>
        ///成品委外G已付合同款
        /// </summary>
        public decimal AM128
        {
            get
            {
                return _am128;
            }
            set
            {
                _am128 = value;
            }
        }

        private string _am129;
        /// <summary>
        /// 成品委外G类是否超补
        /// </summary>
        public string AM129
        {
            get
            {
                return _am129;
            }
            set
            {
                _am129 = value;
            }
        }

        private string _am132;
        /// <summary>
        /// 成品委外H类是否超补
        /// </summary>
        public string AM132
        {
            get
            {
                return _am132;
            }
            set
            {
                _am132 = value;
            }
        }

        private decimal _am136;
        /// <summary>
        ///包装辅料合同应收款
        /// </summary>
        public decimal AM136
        {
            get
            {
                return _am136;
            }
            set
            {
                _am136 = value;
            }
        }

        private decimal _am137;
        /// <summary>
        ///包装辅料合同已付款
        /// </summary>
        public decimal AM137
        {
            get
            {
                return _am137;
            }
            set
            {
                _am137 = value;
            }
        }

        private decimal _am138;
        /// <summary>
        /// 包装辅料超补合同应收款
        /// </summary>
        public decimal AM138
        {
            get
            {
                return _am138;
            }
            set
            {
                _am138 = value;
            }
        }

        private decimal _am141;
        /// <summary>
        /// 包装辅料超补合同已付款
        /// </summary>
        public decimal AM141
        {
            get
            {
                return _am141;
            }
            set
            {
                _am141 = value;
            }
        }

        private decimal _am139;
        /// <summary>
        ///外箱合同应收款
        /// </summary>
        public decimal AM139
        {
            get
            {
                return _am139;
            }
            set
            {
                _am139 = value;
            }
        }

        private decimal _am140;
        /// <summary>
        ///外箱合同已付款
        /// </summary>
        public decimal AM140
        {
            get
            {
                return _am140;
            }
            set
            {
                _am140 = value;
            }
        }

        private decimal _am142;
        /// <summary>
        ///中包合同应收款
        /// </summary>
        public decimal AM142
        {
            get
            {
                return _am142;
            }
            set
            {
                _am142 = value;
            }
        }

        private decimal _am143;
        /// <summary>
        ///中包合同已付款
        /// </summary>
        public decimal AM143
        {
            get
            {
                return _am143;
            }
            set
            {
                _am143 = value;
            }
        }

        private decimal _am144;
        /// <summary>
        /// 外箱合同超补应收款
        /// </summary>
        public decimal AM144
        {
            get
            {
                return _am144;
            }
            set
            {
                _am144 = value;
            }
        }

        private decimal _am147;
        /// <summary>
        /// 外箱合同超补已付款
        /// </summary>
        public decimal AM147
        {
            get
            {
                return _am147;
            }
            set
            {
                _am147 = value;
            }
        }

        private decimal _am145;
        /// <summary>
        ///内盒合同应收款
        /// </summary>
        public decimal AM145
        {
            get
            {
                return _am145;
            }
            set
            {
                _am145 = value;
            }
        }

        private decimal _am146;
        /// <summary>
        ///内盒合同已付款
        /// </summary>
        public decimal AM146
        {
            get
            {
                return _am146;
            }
            set
            {
                _am146 = value;
            }
        }

        private decimal _am133;
        /// <summary>
        ///内盒合同超补应收款
        /// </summary>
        public decimal AM133
        {
            get
            {
                return _am133;
            }
            set
            {
                _am133 = value;
            }
        }

        private decimal _am134;
        /// <summary>
        ///内盒合同超补已付款
        /// </summary>
        public decimal AM134
        {
            get
            {
                return _am134;
            }
            set
            {
                _am134 = value;
            }
        }

        private decimal _am148;
        /// <summary>
        ///彩盒合同应收款
        /// </summary>
        public decimal AM148
        {
            get
            {
                return _am148;
            }
            set
            {
                _am148 = value;
            }
        }

        private decimal _am149;
        /// <summary>
        ///彩盒合同已付款
        /// </summary>
        public decimal AM149
        {
            get
            {
                return _am149;
            }
            set
            {
                _am149 = value;
            }
        }

        private decimal _am130;
        /// <summary>
        ///彩盒合同超补应收款
        /// </summary>
        public decimal AM130
        {
            get
            {
                return _am130;
            }
            set
            {
                _am130 = value;
            }
        }

        private decimal _am131;
        /// <summary>
        ///彩盒合同超补已付款
        /// </summary>
        public decimal AM131
        {
            get
            {
                return _am131;
            }
            set
            {
                _am131 = value;
            }
        }

        private decimal _am150;
        /// <summary>
        /// 中包合同超补应收款
        /// </summary>
        public decimal AM150
        {
            get
            {
                return _am150;
            }
            set
            {
                _am150 = value;
            }
        }

        private decimal _am135;
        /// <summary>
        /// 中包合同超补已付款
        /// </summary>
        public decimal AM135
        {
            get
            {
                return _am135;
            }
            set
            {
                _am135 = value;
            }
        }

        private decimal _am151;
        /// <summary>
        ///用库存合同应付款
        /// </summary>
        public decimal AM151
        {
            get
            {
                return _am151;
            }
            set
            {
                _am151 = value;
            }
        }

        private decimal _am152;
        /// <summary>
        ///用库存合同已付款
        /// </summary>
        public decimal AM152
        {
            get
            {
                return _am152;
            }
            set
            {
                _am152 = value;
            }
        }

        private decimal _am153;
        /// <summary>
        /// 杨木应付款
        /// </summary>
        public decimal AM153
        {
            get
            {
                return _am153;
            }
            set
            {
                _am153 = value;
            }
        }

        private decimal _am154;
        /// <summary>
        ///杨木已付款
        /// </summary>
        public decimal AM154
        {
            get
            {
                return _am154;
            }
            set
            {
                _am154 = value;
            }
        }

        private decimal _am155;
        /// <summary>
        ///杨木超补应付款
        /// </summary>
        public decimal AM155
        {
            get
            {
                return _am155;
            }
            set
            {
                _am155 = value;
            }
        }

        private decimal _am156;
        /// <summary>
        /// 杨木超补已付款
        /// </summary>
        public decimal AM156
        {
            get
            {
                return _am156;
            }
            set
            {
                _am156 = value;
            }
        }

        private decimal _am157;
        /// <summary>
        ///杨木用库存应付款
        /// </summary>
        public decimal AM157
        {
            get
            {
                return _am157;
            }
            set
            {
                _am157 = value;
            }
        }

        private decimal _am158;
        /// <summary>
        ///杨木用库存超补应付款
        /// </summary>
        public decimal AM158
        {
            get
            {
                return _am158;
            }
            set
            {
                _am158 = value;
            }
        }

        private string _am159;
        /// <summary>
        /// 包材2是否超补
        /// </summary>
        public string AM159
        {
            get
            {
                return _am159;
            }
            set
            {
                _am159 = value;
            }
        }

        private decimal _am160;
        /// <summary>
        ///包材3合同应付款
        /// </summary>
        public decimal AM160
        {
            get
            {
                return _am160;
            }
            set
            {
                _am160 = value;
            }
        }

        private decimal _am161;
        /// <summary>
        ///包材3合同已付款
        /// </summary>
        public decimal AM161
        {
            get
            {
                return _am161;
            }
            set
            {
                _am161 = value;
            }
        }

        private string _am162;
        /// <summary>
        /// 包材3是否超补
        /// </summary>
        public string AM162
        {
            get
            {
                return _am162;
            }
            set
            {
                _am162 = value;
            }
        }

        private decimal _am163;
        /// <summary>
        ///包材4合同应付款
        /// </summary>
        public decimal AM163
        {
            get
            {
                return _am163;
            }
            set
            {
                _am163 = value;
            }
        }

        private decimal _am164;
        /// <summary>
        ///包材4合同已付款
        /// </summary>
        public decimal AM164
        {
            get
            {
                return _am164;
            }
            set
            {
                _am164 = value;
            }
        }

        private string _am165;
        /// <summary>
        /// 包材4是否超补
        /// </summary>
        public string AM165
        {
            get
            {
                return _am165;
            }
            set
            {
                _am165 = value;
            }
        }

        private decimal _am166;
        /// <summary>
        ///包材5合同应付款
        /// </summary>
        public decimal AM166
        {
            get
            {
                return _am166;
            }
            set
            {
                _am166 = value;
            }
        }

        private decimal _am167;
        /// <summary>
        ///包材5合同已付款
        /// </summary>
        public decimal AM167
        {
            get
            {
                return _am167;
            }
            set
            {
                _am167 = value;
            }
        }

        private string _am168;
        /// <summary>
        /// 包材5是否超补
        /// </summary>
        public string AM168
        {
            get
            {
                return _am168;
            }
            set
            {
                _am168 = value;
            }
        }

        private decimal _am169;
        /// <summary>
        ///包材6合同应付款
        /// </summary>
        public decimal AM169
        {
            get
            {
                return _am169;
            }
            set
            {
                _am169 = value;
            }
        }

        private decimal _am170;
        /// <summary>
        ///包材6合同已付款
        /// </summary>
        public decimal AM170
        {
            get
            {
                return _am170;
            }
            set
            {
                _am170 = value;
            }
        }

        private string _am171;
        /// <summary>
        /// 包材6是否超补
        /// </summary>
        public string AM171
        {
            get
            {
                return _am171;
            }
            set
            {
                _am171 = value;
            }
        }

        private decimal _am172;
        /// <summary>
        ///包材7合同应付款
        /// </summary>
        public decimal AM172
        {
            get
            {
                return _am172;
            }
            set
            {
                _am172 = value;
            }
        }

        private decimal _am173;
        /// <summary>
        ///285油漆实际用漆款
        /// </summary>
        public decimal AM173
        {
            get
            {
                return _am173;
            }
            set
            {
                _am173 = value;
            }
        }

        private string _am174;
        /// <summary>
        /// 包材7是否超补
        /// </summary>
        public string AM174
        {
            get
            {
                return _am174;
            }
            set
            {
                _am174 = value;
            }
        }

        private decimal _am175;
        /// <summary>
        ///水性漆一类应付合同款
        /// </summary>
        public decimal AM175
        {
            get
            {
                return _am175;
            }
            set
            {
                _am175 = value;
            }
        }

        private decimal _am176;
        /// <summary>
        ///水性漆一类已付合同款
        /// </summary>
        public decimal AM176
        {
            get
            {
                return _am176;
            }
            set
            {
                _am176 = value;
            }
        }

        private decimal _am177;
        /// <summary>
        /// 水性漆一类应付超补合同款
        /// </summary>
        public decimal AM177
        {
            get
            {
                return _am177;
            }
            set
            {
                _am177 = value;
            }
        }

        private decimal _am180;
        /// <summary>
        /// 水性漆一类应付超补已付款
        /// </summary>
        public decimal AM180
        {
            get
            {
                return _am180;
            }
            set
            {
                _am180 = value;
            }
        }

        private decimal _am178;
        /// <summary>
        ///水性漆二类应付合同款
        /// </summary>
        public decimal AM178
        {
            get
            {
                return _am178;
            }
            set
            {
                _am178 = value;
            }
        }

        private decimal _am179;
        /// <summary>
        ///水性漆二类已付合同款
        /// </summary>
        public decimal AM179
        {
            get
            {
                return _am179;
            }
            set
            {
                _am179 = value;
            }
        }

        private string _am181;
        /// <summary>
        /// 水性漆二类是否隐藏
        /// </summary>
        public string AM181
        {
            get
            {
                return _am181;
            }
            set
            {
                _am181 = value;
            }
        }

        private decimal _am182;
        /// <summary>
        ///硝基漆合同应付款
        /// </summary>
        public decimal AM182
        {
            get
            {
                return _am182;
            }
            set
            {
                _am182 = value;
            }
        }

        private decimal _am183;
        /// <summary>
        ///硝基漆合同已付款
        /// </summary>
        public decimal AM183
        {
            get
            {
                return _am183;
            }
            set
            {
                _am183 = value;
            }
        }

        private decimal _am184;
        /// <summary>
        /// 水性漆二类应付超补合同款
        /// </summary>
        public decimal AM184
        {
            get
            {
                return _am184;
            }
            set
            {
                _am184 = value;
            }
        }

        private decimal _am187;
        /// <summary>
        /// 水性漆二类已付超补合同款
        /// </summary>
        public decimal AM187
        {
            get
            {
                return _am187;
            }
            set
            {
                _am187 = value;
            }
        }

        private decimal _am185;
        /// <summary>
        ///香蕉水合同应付款
        /// </summary>
        public decimal AM185
        {
            get
            {
                return _am185;
            }
            set
            {
                _am185 = value;
            }
        }

        private decimal _am186;
        /// <summary>
        ///香蕉水合同已付款
        /// </summary>
        public decimal AM186
        {
            get
            {
                return _am186;
            }
            set
            {
                _am186 = value;
            }
        }

        private decimal _am188;
        /// <summary>
        ///水性漆一类用库存应付款
        /// </summary>
        public decimal AM188
        {
            get
            {
                return _am188;
            }
            set
            {
                _am188 = value;
            }
        }

        private decimal _am189;
        /// <summary>
        ///水性漆一类用库存已付款
        /// </summary>
        public decimal AM189
        {
            get
            {
                return _am189;
            }
            set
            {
                _am189 = value;
            }
        }

        private decimal _am200;
        /// <summary>
        ///水性漆一类用库存超补应付款
        /// </summary>
        public decimal AM200
        {
            get
            {
                return _am200;
            }
            set
            {
                _am200 = value;
            }
        }

        private decimal _am201;
        /// <summary>
        ///水性漆一类用库存超补已付款
        /// </summary>
        public decimal AM201
        {
            get
            {
                return _am201;
            }
            set
            {
                _am201 = value;
            }
        }

        private decimal _am190;
        /// <summary>
        /// 硝基漆合同超补应付款
        /// </summary>
        public decimal AM190
        {
            get
            {
                return _am190;
            }
            set
            {
                _am190 = value;
            }
        }

        private decimal _am193;
        /// <summary>
        /// 硝基漆合同超补已付款
        /// </summary>
        public decimal AM193
        {
            get
            {
                return _am193;
            }
            set
            {
                _am193 = value;
            }
        }

        private decimal _am191;
        /// <summary>
        ///水性漆二类用库存应付款
        /// </summary>
        public decimal AM191
        {
            get
            {
                return _am191;
            }
            set
            {
                _am191 = value;
            }
        }

        private decimal _am192;
        /// <summary>
        ///水性漆二类用库存已付款
        /// </summary>
        public decimal AM192
        {
            get
            {
                return _am192;
            }
            set
            {
                _am192 = value;
            }
        }

        private decimal _am203;
        /// <summary>
        ///水性漆二类用库存超补应付款
        /// </summary>
        public decimal AM203
        {
            get
            {
                return _am203;
            }
            set
            {
                _am203 = value;
            }
        }

        private decimal _am204;
        /// <summary>
        ///水性漆二类用库存超补已付款
        /// </summary>
        public decimal AM204
        {
            get
            {
                return _am204;
            }
            set
            {
                _am204 = value;
            }
        }

        private decimal _am194;
        /// <summary>
        ///硝基漆用库存应付款
        /// </summary>
        public decimal AM194
        {
            get
            {
                return _am194;
            }
            set
            {
                _am194 = value;
            }
        }

        private decimal _am195;
        /// <summary>
        ///硝基漆用库存已付款
        /// </summary>
        public decimal AM195
        {
            get
            {
                return _am195;
            }
            set
            {
                _am195 = value;
            }
        }

        private decimal _am205;
        /// <summary>
        /// 硝基漆用库存超补应付款
        /// </summary>
        public decimal AM205
        {
            get
            {
                return _am205;
            }
            set
            {
                _am205 = value;
            }
        }

        private decimal _am206;
        /// <summary>
        ///硝基漆用库存超补已付款
        /// </summary>
        public decimal AM206
        {
            get
            {
                return _am206;
            }
            set
            {
                _am206 = value;
            }
        }

        private decimal _am196;
        /// <summary>
        /// 香蕉水合同超补应付款
        /// </summary>
        public decimal AM196
        {
            get
            {
                return _am196;
            }
            set
            {
                _am196 = value;
            }
        }

        private decimal _am199;
        /// <summary>
        /// 香蕉水合同超补已付款
        /// </summary>
        public decimal AM199
        {
            get
            {
                return _am199;
            }
            set
            {
                _am199 = value;
            }
        }

        private decimal _am197;
        /// <summary>
        ///香蕉水用库存应付款
        /// </summary>
        public decimal AM197
        {
            get
            {
                return _am197;
            }
            set
            {
                _am197 = value;
            }
        }

        private decimal _am198;
        /// <summary>
        ///香蕉水用库存已付款
        /// </summary>
        public decimal AM198
        {
            get
            {
                return _am198;
            }
            set
            {
                _am198 = value;
            }
        }

        private decimal _am207;
        /// <summary>
        ///香蕉水用库存超补应付款
        /// </summary>
        public decimal AM207
        {
            get
            {
                return _am207;
            }
            set
            {
                _am207 = value;
            }
        }

        private decimal _am208;
        /// <summary>
        /// 香蕉水用库存超补已付款
        /// </summary>
        public decimal AM208
        {
            get
            {
                return _am208;
            }
            set
            {
                _am208 = value;
            }
        }

        private string _am202;
        /// <summary>
        /// 油漆5是否超补
        /// </summary>
        public string AM202
        {
            get
            {
                return _am202;
            }
            set
            {
                _am202 = value;
            }
        }

        private decimal _am209;
        /// <summary>
        ///铁件合同应付款
        /// </summary>
        public decimal AM209
        {
            get
            {
                return _am209;
            }
            set
            {
                _am209 = value;
            }
        }

        private decimal _am210;
        /// <summary>
        ///铁件合同已付款
        /// </summary>
        public decimal AM210
        {
            get
            {
                return _am210;
            }
            set
            {
                _am210 = value;
            }
        }

        private decimal _am211;
        /// <summary>
        /// 铁件合同超补应付款
        /// </summary>
        public decimal AM211
        {
            get
            {
                return _am211;
            }
            set
            {
                _am211 = value;
            }
        }

        private decimal _am214;
        /// <summary>
        /// 铁件合同超补已付款
        /// </summary>
        public decimal AM214
        {
            get
            {
                return _am214;
            }
            set
            {
                _am214 = value;
            }
        }

        private decimal _am212;
        /// <summary>
        ///塑料件合同应付款
        /// </summary>
        public decimal AM212
        {
            get
            {
                return _am212;
            }
            set
            {
                _am212 = value;
            }
        }

        private decimal _am213;
        /// <summary>
        ///塑料件合同已付款
        /// </summary>
        public decimal AM213
        {
            get
            {
                return _am213;
            }
            set
            {
                _am213 = value;
            }
        }

        private decimal _am217;
        /// <summary>
        /// 塑料件合同超补应付款
        /// </summary>
        public decimal AM217
        {
            get
            {
                return _am217;
            }
            set
            {
                _am217 = value;
            }
        }

        private decimal _am220;
        /// <summary>
        /// 塑料件合同超补已付款
        /// </summary>
        public decimal AM220
        {
            get
            {
                return _am220;
            }
            set
            {
                _am220 = value;
            }
        }

        private decimal _am215;
        /// <summary>
        ///其它材料合同应付款
        /// </summary>
        public decimal AM215
        {
            get
            {
                return _am215;
            }
            set
            {
                _am215 = value;
            }
        }

        private decimal _am216;
        /// <summary>
        ///其它材料合同已付款
        /// </summary>
        public decimal AM216
        {
            get
            {
                return _am216;
            }
            set
            {
                _am216 = value;
            }
        }

        private decimal _am221;
        /// <summary>
        ///其它材料合同超补应付款
        /// </summary>
        public decimal AM221
        {
            get
            {
                return _am221;
            }
            set
            {
                _am221 = value;
            }
        }

        private decimal _am222;
        /// <summary>
        ///其它材料合同超补已付款
        /// </summary>
        public decimal AM222
        {
            get
            {
                return _am222;
            }
            set
            {
                _am222 = value;
            }
        }

        private decimal _am218;
        /// <summary>
        ///包装辅料应付款
        /// </summary>
        public decimal AM218
        {
            get
            {
                return _am218;
            }
            set
            {
                _am218 = value;
            }
        }

        private decimal _am219;
        /// <summary>
        ///包装辅料已付款
        /// </summary>
        public decimal AM219
        {
            get
            {
                return _am219;
            }
            set
            {
                _am219 = value;
            }
        }

        private decimal _am223;
        /// <summary>
        /// 包装辅料合同超补应付款
        /// </summary>
        public decimal AM223
        {
            get
            {
                return _am223;
            }
            set
            {
                _am223 = value;
            }
        }

        private decimal _am224;
        /// <summary>
        ///包装辅料合同超补已付款
        /// </summary>
        public decimal AM224
        {
            get
            {
                return _am224;
            }
            set
            {
                _am224 = value;
            }
        }

        private decimal _am225;
        /// <summary>
        ///铁件用库存合同应付款
        /// </summary>
        public decimal AM225
        {
            get
            {
                return _am225;
            }
            set
            {
                _am225 = value;
            }
        }

        private decimal _am226;
        /// <summary>
        /// 铁件用库存合同已付款
        /// </summary>
        public decimal AM226
        {
            get
            {
                return _am226;
            }
            set
            {
                _am226 = value;
            }
        }

        private decimal _am227;
        /// <summary>
        ///铁件用库存合同应付超补款
        /// </summary>
        public decimal AM227
        {
            get
            {
                return _am227;
            }
            set
            {
                _am227 = value;
            }
        }

        private decimal _am228;
        /// <summary>
        ///铁件用库存合同已付超补款
        /// </summary>
        public decimal AM228
        {
            get
            {
                return _am228;
            }
            set
            {
                _am228 = value;
            }
        }

        private decimal _am229;
        /// <summary>
        /// 塑料件用库存合同应付款
        /// </summary>
        public decimal AM229
        {
            get
            {
                return _am229;
            }
            set
            {
                _am229 = value;
            }
        }

        private decimal _am230;
        /// <summary>
        ///塑料件用库存合同已付款
        /// </summary>
        public decimal AM230
        {
            get
            {
                return _am230;
            }
            set
            {
                _am230 = value;
            }
        }

        private decimal _am231;
        /// <summary>
        ///塑料件用库存合同应付超补款
        /// </summary>
        public decimal AM231
        {
            get
            {
                return _am231;
            }
            set
            {
                _am231 = value;
            }
        }

        private decimal _am232;
        /// <summary>
        /// 塑料件用库存合同已付超补款
        /// </summary>
        public decimal AM232
        {
            get
            {
                return _am232;
            }
            set
            {
                _am232 = value;
            }
        }

        private decimal _am233;
        /// <summary>
        ///其它材料用库存合同应付款
        /// </summary>
        public decimal AM233
        {
            get
            {
                return _am233;
            }
            set
            {
                _am233 = value;
            }
        }

        private decimal _am234;
        /// <summary>
        ///其它材料用库存合同已付款
        /// </summary>
        public decimal AM234
        {
            get
            {
                return _am234;
            }
            set
            {
                _am234 = value;
            }
        }

        private decimal _am235;
        /// <summary>
        /// 其它材料用库存合同应付超补款
        /// </summary>
        public decimal AM235
        {
            get
            {
                return _am235;
            }
            set
            {
                _am235 = value;
            }
        }

        private decimal _am236;
        /// <summary>
        ///其它材料用库存合同已付超补款
        /// </summary>
        public decimal AM236
        {
            get
            {
                return _am236;
            }
            set
            {
                _am236 = value;
            }
        }

        private decimal _am237;
        /// <summary>
        ///包装辅料用库存合同应付款
        /// </summary>
        public decimal AM237
        {
            get
            {
                return _am237;
            }
            set
            {
                _am237 = value;
            }
        }

        private decimal _am238;
        /// <summary>
        /// 包装辅料用库存合同已付款
        /// </summary>
        public decimal AM238
        {
            get
            {
                return _am238;
            }
            set
            {
                _am238 = value;
            }
        }

        private decimal _am239;
        /// <summary>
        ///滚漆一类合同应付款
        /// </summary>
        public decimal AM239
        {
            get
            {
                return _am239;
            }
            set
            {
                _am239 = value;
            }
        }

        private decimal _am240;
        /// <summary>
        ///滚漆一类合同已付款
        /// </summary>
        public decimal AM240
        {
            get
            {
                return _am240;
            }
            set
            {
                _am240 = value;
            }
        }

        private decimal _am241;
        /// <summary>
        /// 滚漆一类合同超补应付款
        /// </summary>
        public decimal AM241
        {
            get
            {
                return _am241;
            }
            set
            {
                _am241 = value;
            }
        }

        private decimal _am244;
        /// <summary>
        /// 滚漆一类合同超补已付款
        /// </summary>
        public decimal AM244
        {
            get
            {
                return _am244;
            }
            set
            {
                _am244 = value;
            }
        }

        private decimal _am242;
        /// <summary>
        ///滚漆二类合同应付款
        /// </summary>
        public decimal AM242
        {
            get
            {
                return _am242;
            }
            set
            {
                _am242 = value;
            }
        }

        private decimal _am243;
        /// <summary>
        ///滚漆二类合同已付款
        /// </summary>
        public decimal AM243
        {
            get
            {
                return _am243;
            }
            set
            {
                _am243 = value;
            }
        }

        private decimal _am247;
        /// <summary>
        /// 滚漆二类合同超补应付款
        /// </summary>
        public decimal AM247
        {
            get
            {
                return _am247;
            }
            set
            {
                _am247 = value;
            }
        }

        private decimal _am251;
        /// <summary>
        /// 滚漆二类合同超补已付款
        /// </summary>
        public decimal AM251
        {
            get
            {
                return _am251;
            }
            set
            {
                _am251 = value;
            }
        }

        private decimal _am245;
        /// <summary>
        ///滚漆三类合同应付款
        /// </summary>
        public decimal AM245
        {
            get
            {
                return _am245;
            }
            set
            {
                _am245 = value;
            }
        }

        private decimal _am246;
        /// <summary>
        ///滚漆三类合同已付款
        /// </summary>
        public decimal AM246
        {
            get
            {
                return _am246;
            }
            set
            {
                _am246 = value;
            }
        }

        private decimal _am252;
        /// <summary>
        ///滚漆三类合同超补应付款
        /// </summary>
        public decimal AM252
        {
            get
            {
                return _am252;
            }
            set
            {
                _am252 = value;
            }
        }

        private decimal _am253;
        /// <summary>
        ///滚漆三类合同超补已付款
        /// </summary>
        public decimal AM253
        {
            get
            {
                return _am253;
            }
            set
            {
                _am253 = value;
            }
        }

        private decimal _am248;
        /// <summary>
        /// R-346厂内滚漆实际金额'
        /// </summary>
        public decimal AM248
        {
            get
            {
                return _am248;
            }
            set
            {
                _am248 = value;
            }
        }

        private decimal _am249;
        /// <summary>
        ///滚漆工资应付款
        /// </summary>
        public decimal AM249
        {
            get
            {
                return _am249;
            }
            set
            {
                _am249 = value;
            }
        }

        private decimal _am250;
        /// <summary>
        ///滚漆工资已付款
        /// </summary>
        public decimal AM250
        {
            get
            {
                return _am250;
            }
            set
            {
                _am250 = value;
            }
        }

        private string _am254;
        /// <summary>
        /// 滚漆2是否超补
        /// </summary>
        public string AM254
        {
            get
            {
                return _am254;
            }
            set
            {
                _am254 = value;
            }
        }

        private decimal _am255;
        /// <summary>
        ///包装辅料用库存合同应付超补款
        /// </summary>
        public decimal AM255
        {
            get
            {
                return _am255;
            }
            set
            {
                _am255 = value;
            }
        }

        private decimal _am256;
        /// <summary>
        ///包装辅料用库存合同已付超补款
        /// </summary>
        public decimal AM256
        {
            get
            {
                return _am256;
            }
            set
            {
                _am256 = value;
            }
        }

        private string _am257;
        /// <summary>
        /// 滚漆3是否超补
        /// </summary>
        public string AM257
        {
            get
            {
                return _am257;
            }
            set
            {
                _am257 = value;
            }
        }

        private decimal _am258;
        /// <summary>
        ///滚漆4合同应付款
        /// </summary>
        public decimal AM258
        {
            get
            {
                return _am258;
            }
            set
            {
                _am258 = value;
            }
        }

        private decimal _am259;
        /// <summary>
        ///滚漆4合同已付款
        /// </summary>
        public decimal AM259
        {
            get
            {
                return _am259;
            }
            set
            {
                _am259 = value;
            }
        }

        private string _am260;
        /// <summary>
        /// 滚漆4是否超补
        /// </summary>
        public string AM260
        {
            get
            {
                return _am260;
            }
            set
            {
                _am260 = value;
            }
        }

        private decimal _am270;
        /// <summary>
        ///车木件清水合同应付款
        /// </summary>
        public decimal AM270
        {
            get
            {
                return _am270;
            }
            set
            {
                _am270 = value;
            }
        }

        private decimal _am271;
        /// <summary>
        ///车木件清水合同已付款
        /// </summary>
        public decimal AM271
        {
            get
            {
                return _am271;
            }
            set
            {
                _am271 = value;
            }
        }



        private decimal _am272;
        /// <summary>
        /// 车木件清水合同超补应付款
        /// </summary>
        public decimal AM272
        {
            get
            {
                return _am272;
            }
            set
            {
                _am272 = value;
            }
        }

        private decimal _am275;
        /// <summary>
        /// 车木件清水合同超补已付款
        /// </summary>
        public decimal AM275
        {
            get
            {
                return _am275;
            }
            set
            {
                _am275 = value;
            }
        }

        private decimal _am273;
        /// <summary>
        ///车木件浊水合同应付款
        /// </summary>
        public decimal AM273
        {
            get
            {
                return _am273;
            }
            set
            {
                _am273 = value;
            }
        }

        private decimal _am274;
        /// <summary>
        ///车木件浊水合同已付款
        /// </summary>
        public decimal AM274
        {
            get
            {
                return _am274;
            }
            set
            {
                _am274 = value;
            }
        }

        private decimal _am279;
        /// <summary>
        /// 车木件浊水合同超补应付款
        /// </summary>
        public decimal AM279
        {
            get
            {
                return _am279;
            }
            set
            {
                _am279 = value;
            }
        }

        private decimal _am282;
        /// <summary>
        /// 车木件浊水合同超补已付款
        /// </summary>
        public decimal AM282
        {
            get
            {
                return _am282;
            }
            set
            {
                _am282 = value;
            }
        }

        private string _am276;
        /// <summary>
        /// 车木件浊水是否隐藏
        /// </summary>
        public string AM276
        {
            get
            {
                return _am276;
            }
            set
            {
                _am276 = value;
            }
        }

        private decimal _am277;
        /// <summary>
        /// 车木件清水用库存合同应付款
        /// </summary>
        public decimal AM277
        {
            get
            {
                return _am277;
            }
            set
            {
                _am277 = value;
            }
        }

        private decimal _am278;
        /// <summary>
        /// 车木件清水用库存合同已付款
        /// </summary>
        public decimal AM278
        {
            get
            {
                return _am278;
            }
            set
            {
                _am278 = value;
            }
        }

        private decimal _am283;
        /// <summary>
        /// 车木件清水用库存合同超补应付款
        /// </summary>
        public decimal AM283
        {
            get
            {
                return _am283;
            }
            set
            {
                _am283 = value;
            }
        }

        private decimal _am284;
        /// <summary>
        /// 车木件清水用库存合同超补已付款
        /// </summary>
        public decimal AM284
        {
            get
            {
                return _am284;
            }
            set
            {
                _am284 = value;
            }
        }

        private decimal _am280;
        /// <summary>
        /// 车木件混水用库存合同应付款
        /// </summary>
        public decimal AM280
        {
            get
            {
                return _am280;
            }
            set
            {
                _am280 = value;
            }
        }

        private decimal _am281;
        /// <summary>
        /// 车木件混水用库存合同已付款
        /// </summary>
        public decimal AM281
        {
            get
            {
                return _am281;
            }
            set
            {
                _am281 = value;
            }
        }

        private decimal _am285;
        /// <summary>
        /// 车木件混水用库存合同超补应付款
        /// </summary>
        public decimal AM285
        {
            get
            {
                return _am285;
            }
            set
            {
                _am285 = value;
            }
        }

        private decimal _am286;
        /// <summary>
        /// 车木件混水用库存合同超补已付款
        /// </summary>
        public decimal AM286
        {
            get
            {
                return _am286;
            }
            set
            {
                _am286 = value;
            }
        }

        private decimal _am298;
        /// <summary>
        /// 胶合板E0级合同应付款
        /// </summary>
        public decimal AM298
        {
            get
            {
                return _am298;
            }
            set
            {
                _am298 = value;
            }
        }

        private decimal _am299;
        /// <summary>
        /// 胶合板E0级合同已付款
        /// </summary>
        public decimal AM299
        {
            get
            {
                return _am299;
            }
            set
            {
                _am299 = value;
            }
        }

        private decimal _am300;
        /// <summary>
        /// 胶合板E0级合同超补应付款
        /// </summary>
        public decimal AM300
        {
            get
            {
                return _am300;
            }
            set
            {
                _am300 = value;
            }
        }

        private decimal _am303;
        /// <summary>
        /// 胶合板E0级合同超补已付款
        /// </summary>
        public decimal AM303
        {
            get
            {
                return _am303;
            }
            set
            {
                _am303 = value;
            }
        }

        private decimal _am301;
        /// <summary>
        /// 密度板E0级合同应付款
        /// </summary>
        public decimal AM301
        {
            get
            {
                return _am301;
            }
            set
            {
                _am301 = value;
            }
        }

        private decimal _am302;
        /// <summary>
        /// 密度板E0级合同已付款
        /// </summary>
        public decimal AM302
        {
            get
            {
                return _am302;
            }
            set
            {
                _am302 = value;
            }
        }

        private decimal _am306;
        /// <summary>
        /// 密度板E0级合同超补应付款
        /// </summary>
        public decimal AM306
        {
            get
            {
                return _am306;
            }
            set
            {
                _am306 = value;
            }
        }

        private decimal _am309;
        /// <summary>
        /// 密度板E0级合同超补已付款
        /// </summary>
        public decimal AM309
        {
            get
            {
                return _am309;
            }
            set
            {
                _am309 = value;
            }
        }

        private decimal _am304;
        /// <summary>
        /// 用库存胶合板E0合同应付款
        /// </summary>
        public decimal AM304
        {
            get
            {
                return _am304;
            }
            set
            {
                _am304 = value;
            }
        }

        private decimal _am305;
        /// <summary>
        /// 用库存胶合板E0合同已付款
        /// </summary>
        public decimal AM305
        {
            get
            {
                return _am305;
            }
            set
            {
                _am305 = value;
            }
        }

        private decimal _am313;
        /// <summary>
        /// 用库存胶合板E0合同超补应付款
        /// </summary>
        public decimal AM313
        {
            get
            {
                return _am313;
            }
            set
            {
                _am313 = value;
            }
        }

        private decimal _am317;
        /// <summary>
        /// 用库存胶合板E0合同超补已付款
        /// </summary>
        public decimal AM317
        {
            get
            {
                return _am317;
            }
            set
            {
                _am317 = value;
            }
        }

        private decimal _am307;
        /// <summary>
        /// 胶合板E1级合同应付款
        /// </summary>
        public decimal AM307
        {
            get
            {
                return _am307;
            }
            set
            {
                _am307 = value;
            }
        }

        private decimal _am308;
        /// <summary>
        /// 胶合板E1级合同已付款
        /// </summary>
        public decimal AM308
        {
            get
            {
                return _am308;
            }
            set
            {
                _am308 = value;
            }
        }

        private decimal _am320;
        /// <summary>
        /// 胶合板E1级合同超补应付款
        /// </summary>
        public decimal AM320
        {
            get
            {
                return _am320;
            }
            set
            {
                _am320 = value;
            }
        }

        private decimal _am323;
        /// <summary>
        /// 胶合板E1级合同超补已付款
        /// </summary>
        public decimal AM323
        {
            get
            {
                return _am323;
            }
            set
            {
                _am323 = value;
            }
        }

        private string _am310;
        /// <summary>
        /// 胶合板E1是否隐藏
        /// </summary>
        public string AM310
        {
            get
            {
                return _am310;
            }
            set
            {
                _am310 = value;
            }
        }

        private decimal _am311;
        /// <summary>
        /// 密度板E1级合同应付款
        /// </summary>
        public decimal AM311
        {
            get
            {
                return _am311;
            }
            set
            {
                _am311 = value;
            }
        }

        private decimal _am312;
        /// <summary>
        /// 密度板E1级合同已付款
        /// </summary>
        public decimal AM312
        {
            get
            {
                return _am312;
            }
            set
            {
                _am312 = value;
            }
        }

        private decimal _am324;
        /// <summary>
        /// 密度板E1级合同超补应付款
        /// </summary>
        public decimal AM324
        {
            get
            {
                return _am324;
            }
            set
            {
                _am324 = value;
            }
        }

        private decimal _am325;
        /// <summary>
        /// 密度板E1级合同超补已付款
        /// </summary>
        public decimal AM325
        {
            get
            {
                return _am325;
            }
            set
            {
                _am325 = value;
            }
        }

        private string _am314;
        /// <summary>
        /// 密度板E1是否隐藏
        /// </summary>
        public string AM314
        {
            get
            {
                return _am314;
            }
            set
            {
                _am314 = value;
            }
        }

        private decimal _am315;
        /// <summary>
        /// 用库存胶合板E1合同应付款
        /// </summary>
        public decimal AM315
        {
            get
            {
                return _am315;
            }
            set
            {
                _am315 = value;
            }
        }

        private decimal _am316;
        /// <summary>
        /// 用库存胶合板E1合同已付款
        /// </summary>
        public decimal AM316
        {
            get
            {
                return _am316;
            }
            set
            {
                _am316 = value;
            }
        }

        private decimal _am326;
        /// <summary>
        /// 用库存胶合板E1合同超补应付款
        /// </summary>
        public decimal AM326
        {
            get
            {
                return _am326;
            }
            set
            {
                _am326 = value;
            }
        }

        private decimal _am327;
        /// <summary>
        /// 用库存胶合板E1合同超补已付款
        /// </summary>
        public decimal AM327
        {
            get
            {
                return _am327;
            }
            set
            {
                _am327 = value;
            }
        }

        private decimal _am318;
        /// <summary>
        /// 用库存密度板E0合同应付款
        /// </summary>
        public decimal AM318
        {
            get
            {
                return _am318;
            }
            set
            {
                _am318 = value;
            }
        }

        private decimal _am319;
        /// <summary>
        /// 用库存密度板E0合同已付款
        /// </summary>
        public decimal AM319
        {
            get
            {
                return _am319;
            }
            set
            {
                _am319 = value;
            }
        }

        private decimal _am328;
        /// <summary>
        /// 用库存密度板E0合同超补应付款
        /// </summary>
        public decimal AM328
        {
            get
            {
                return _am328;
            }
            set
            {
                _am328 = value;
            }
        }

        private decimal _am329;
        /// <summary>
        /// 用库存密度板E0合同超补已付款
        /// </summary>
        public decimal AM329
        {
            get
            {
                return _am329;
            }
            set
            {
                _am329 = value;
            }
        }

        private decimal _am321;
        /// <summary>
        /// 用库存密度板E1合同应付款
        /// </summary>
        public decimal AM321
        {
            get
            {
                return _am321;
            }
            set
            {
                _am321 = value;
            }
        }

        private decimal _am322;
        /// <summary>
        /// 用库存密度板E1合同已付款
        /// </summary>
        public decimal AM322
        {
            get
            {
                return _am322;
            }
            set
            {
                _am322 = value;
            }
        }

        private decimal _am296;
        /// <summary>
        /// 用库存密度板E1合同超补应付款
        /// </summary>
        public decimal AM296
        {
            get
            {
                return _am296;
            }
            set
            {
                _am296 = value;
            }
        }

        private decimal _am297;
        /// <summary>
        /// 用库存密度板E1合同超补已付款
        /// </summary>
        public decimal AM297
        {
            get
            {
                return _am297;
            }
            set
            {
                _am297 = value;
            }
        }

        private decimal _am330;
        /// <summary>
        /// 用库存杂木应付款
        /// </summary>
        public decimal AM330
        {
            get
            {
                return _am330;
            }
            set
            {
                _am330 = value;
            }
        }

        private decimal _am331;
        /// <summary>
        /// 用库存杂木已付款
        /// </summary>
        public decimal AM331
        {
            get
            {
                return _am331;
            }
            set
            {
                _am331 = value;
            }
        }


        private decimal _am290;
        /// <summary>
        /// 用库存杂木超补应付款
        /// </summary>
        public decimal AM290
        {
            get
            {
                return _am290;
            }
            set
            {
                _am290 = value;
            }
        }

        private decimal _am291;
        /// <summary>
        /// 用库存杂木超补已付款
        /// </summary>
        public decimal AM291
        {
            get
            {
                return _am291;
            }
            set
            {
                _am291 = value;
            }
        }

        private decimal _am333;
        /// <summary>
        /// 用库存桦木混水应付款
        /// </summary>
        public decimal AM333
        {
            get
            {
                return _am333;
            }
            set
            {
                _am333 = value;
            }
        }

        private decimal _am334;
        /// <summary>
        /// 用库存桦木混水已付款
        /// </summary>
        public decimal AM334
        {
            get
            {
                return _am334;
            }
            set
            {
                _am334 = value;
            }
        }

        private decimal _am288;
        /// <summary>
        /// 用库存桦木混水超补应付款
        /// </summary>
        public decimal AM288
        {
            get
            {
                return _am288;
            }
            set
            {
                _am288 = value;
            }
        }

        private decimal _am289;
        /// <summary>
        /// 用库存桦木混水超补已付款
        /// </summary>
        public decimal AM289
        {
            get
            {
                return _am289;
            }
            set
            {
                _am289 = value;
            }
        }

        private decimal _am336;
        /// <summary>
        /// 新西兰松A级材料合同应付款
        /// </summary>
        public decimal AM336
        {
            get
            {
                return _am336;
            }
            set
            {
                _am336 = value;
            }
        }

        private decimal _am337;
        /// <summary>
        /// 新西兰松A级材料合同已付款
        /// </summary>
        public decimal AM337
        {
            get
            {
                return _am337;
            }
            set
            {
                _am337 = value;
            }
        }

        private decimal _am338;
        /// <summary>
        /// 新西兰松A级材料合同超补应付款
        /// </summary>
        public decimal AM338
        {
            get
            {
                return _am338;
            }
            set
            {
                _am338 = value;
            }
        }

        private decimal _am341;
        /// <summary>
        /// 新西兰松A级材料合同超补已付款
        /// </summary>
        public decimal AM341
        {
            get
            {
                return _am341;
            }
            set
            {
                _am341 = value;
            }
        }

        private decimal _am339;
        /// <summary>
        /// 新西兰松B级材料合同应付款
        /// </summary>
        public decimal AM339
        {
            get
            {
                return _am339;
            }
            set
            {
                _am339 = value;
            }
        }

        private decimal _am340;
        /// <summary>
        /// 新西兰松B级材料合同已付款
        /// </summary>
        public decimal AM340
        {
            get
            {
                return _am340;
            }
            set
            {
                _am340 = value;
            }
        }

        private decimal _am345;
        /// <summary>
        /// 新西兰松B级材料合同超补应付款
        /// </summary>
        public decimal AM345
        {
            get
            {
                return _am345;
            }
            set
            {
                _am345 = value;
            }
        }

        private decimal _am348;
        /// <summary>
        /// 新西兰松B级材料合同超补已付款
        /// </summary>
        public decimal AM348
        {
            get
            {
                return _am348;
            }
            set
            {
                _am348 = value;
            }
        }

        private string _am342;
        /// <summary>
        /// 新西兰松B级是否隐藏
        /// </summary>
        public string AM342
        {
            get
            {
                return _am342;
            }
            set
            {
                _am342 = value;
            }
        }

        private decimal _am343;
        /// <summary>
        /// 荷木金额清水合同应付款
        /// </summary>
        public decimal AM343
        {
            get
            {
                return _am343;
            }
            set
            {
                _am343 = value;
            }
        }

        private decimal _am344;
        /// <summary>
        /// 荷木金额清水合同已付款
        /// </summary>
        public decimal AM344
        {
            get
            {
                return _am344;
            }
            set
            {
                _am344 = value;
            }
        }

        private decimal _am351;
        /// <summary>
        /// 荷木金额清水合同超补应付款
        /// </summary>
        public decimal AM351
        {
            get
            {
                return _am351;
            }
            set
            {
                _am351 = value;
            }
        }

        private decimal _am354;
        /// <summary>
        /// 荷木金额清水合同超补已付款
        /// </summary>
        public decimal AM354
        {
            get
            {
                return _am354;
            }
            set
            {
                _am354 = value;
            }
        }

        private decimal _am346;
        /// <summary>
        ///榉木A级材合同应付款
        /// </summary>
        public decimal AM346
        {
            get
            {
                return _am346;
            }
            set
            {
                _am346 = value;
            }
        }

        private decimal _am347;
        /// <summary>
        ///榉木A级材合同已付款
        /// </summary>
        public decimal AM347
        {
            get
            {
                return _am347;
            }
            set
            {
                _am347 = value;
            }
        }

        private decimal _am357;
        /// <summary>
        /// 榉木A级材合同超补应付款
        /// </summary>
        public decimal AM357
        {
            get
            {
                return _am357;
            }
            set
            {
                _am357 = value;
            }
        }

        private decimal _am360;
        /// <summary>
        /// 榉木A级材合同超补已付款
        /// </summary>
        public decimal AM360
        {
            get
            {
                return _am360;
            }
            set
            {
                _am360 = value;
            }
        }

        private decimal _am349;
        /// <summary>
        ///椴木清水合同应付款
        /// </summary>
        public decimal AM349
        {
            get
            {
                return _am349;
            }
            set
            {
                _am349 = value;
            }
        }

        private decimal _am350;
        /// <summary>
        ///椴木清水合同已付款
        /// </summary>
        public decimal AM350
        {
            get
            {
                return _am350;
            }
            set
            {
                _am350 = value;
            }
        }

        private decimal _am363;
        /// <summary>
        /// 椴木清水合同超补应付款
        /// </summary>
        public decimal AM363
        {
            get
            {
                return _am363;
            }
            set
            {
                _am363 = value;
            }
        }

        private decimal _am366;
        /// <summary>
        /// 椴木清水合同超补已付款
        /// </summary>
        public decimal AM366
        {
            get
            {
                return _am366;
            }
            set
            {
                _am366 = value;
            }
        }

        private decimal _am352;
        /// <summary>
        ///桦木清水合同应付款
        /// </summary>
        public decimal AM352
        {
            get
            {
                return _am352;
            }
            set
            {
                _am352 = value;
            }
        }

        private decimal _am353;
        /// <summary>
        ///桦木清水合同已付款
        /// </summary>
        public decimal AM353
        {
            get
            {
                return _am353;
            }
            set
            {
                _am353 = value;
            }
        }

        private decimal _am369;
        /// <summary>
        /// 桦木清水合同超补应付款
        /// </summary>
        public decimal AM369
        {
            get
            {
                return _am369;
            }
            set
            {
                _am369 = value;
            }
        }

        private decimal _am372;
        /// <summary>
        /// 桦木清水合同超补已付款
        /// </summary>
        public decimal AM372
        {
            get
            {
                return _am372;
            }
            set
            {
                _am372 = value;
            }
        }

        private decimal _am355;
        /// <summary>
        ///杂木合同应付款
        /// </summary>
        public decimal AM355
        {
            get
            {
                return _am355;
            }
            set
            {
                _am355 = value;
            }
        }

        private decimal _am356;
        /// <summary>
        ///杂木合同已付款
        /// </summary>
        public decimal AM356
        {
            get
            {
                return _am356;
            }
            set
            {
                _am356 = value;
            }
        }

        private decimal _am332;
        /// <summary>
        /// 杂木合同超补应付款
        /// </summary>
        public decimal AM332
        {
            get
            {
                return _am332;
            }
            set
            {
                _am332 = value;
            }
        }

        private decimal _am335;
        /// <summary>
        /// 杂木合同超补已付款
        /// </summary>
        public decimal AM335
        {
            get
            {
                return _am335;
            }
            set
            {
                _am335 = value;
            }
        }

        private decimal _am358;
        /// <summary>
        ///用库存新西兰A板材合同应付款
        /// </summary>
        public decimal AM358
        {
            get
            {
                return _am358;
            }
            set
            {
                _am358 = value;
            }
        }

        private decimal _am359;
        /// <summary>
        ///用库存新西兰A板材合同已付款
        /// </summary>
        public decimal AM359
        {
            get
            {
                return _am359;
            }
            set
            {
                _am359 = value;
            }
        }

        private decimal _am375;
        /// <summary>
        /// 用库存新西兰A板材合同超补应付款
        /// </summary>
        public decimal AM375
        {
            get
            {
                return _am375;
            }
            set
            {
                _am375 = value;
            }
        }

        private decimal _am378;
        /// <summary>
        /// 用库存新西兰A板材合同超补已付款
        /// </summary>
        public decimal AM378
        {
            get
            {
                return _am378;
            }
            set
            {
                _am378 = value;
            }
        }

        private decimal _am361;
        /// <summary>
        ///荷木金额混水合同应付金额
        /// </summary>
        public decimal AM361
        {
            get
            {
                return _am361;
            }
            set
            {
                _am361 = value;
            }
        }

        private decimal _am362;
        /// <summary>
        ///荷木金额混水合同已付金额
        /// </summary>
        public decimal AM362
        {
            get
            {
                return _am362;
            }
            set
            {
                _am362 = value;
            }
        }

        private decimal _am381;
        /// <summary>
        /// 荷木金额混水合同超补应付金额
        /// </summary>
        public decimal AM381
        {
            get
            {
                return _am381;
            }
            set
            {
                _am381 = value;
            }
        }

        private decimal _am387;
        /// <summary>
        /// 荷木金额混水合同超补已付金额
        /// </summary>
        public decimal AM387
        {
            get
            {
                return _am387;
            }
            set
            {
                _am387 = value;
            }
        }

        private decimal _am364;
        /// <summary>
        ///榉木B级才合同应付款
        /// </summary>
        public decimal AM364
        {
            get
            {
                return _am364;
            }
            set
            {
                _am364 = value;
            }
        }

        private decimal _am365;
        /// <summary>
        ///榉木B级才合同已付款
        /// </summary>
        public decimal AM365
        {
            get
            {
                return _am365;
            }
            set
            {
                _am365 = value;
            }
        }

        private decimal _am390;
        /// <summary>
        /// 榉木B级才合同超补应付款
        /// </summary>
        public decimal AM390
        {
            get
            {
                return _am390;
            }
            set
            {
                _am390 = value;
            }
        }
        
        private decimal _am393;
        /// <summary>
        /// 榉木B级才合同超补已付款
        /// </summary>
        public decimal AM393
        {
            get
            {
                return _am393;
            }
            set
            {
                _am393 = value;
            }
        }

        private decimal _am367;
        /// <summary>
        ///椴木混水合同应付款
        /// </summary>
        public decimal AM367
        {
            get
            {
                return _am367;
            }
            set
            {
                _am367 = value;
            }
        }

        private decimal _am368;
        /// <summary>
        ///椴木混水合同已付款
        /// </summary>
        public decimal AM368
        {
            get
            {
                return _am368;
            }
            set
            {
                _am368 = value;
            }
        }

        private decimal _am294;
        /// <summary>
        /// 椴木混水合同超补应付款
        /// </summary>
        public decimal AM294
        {
            get
            {
                return _am294;
            }
            set
            {
                _am294 = value;
            }
        }

        private decimal _am295;
        /// <summary>
        /// 椴木混水合同超补已付款
        /// </summary>
        public decimal AM295
        {
            get
            {
                return _am295;
            }
            set
            {
                _am295 = value;
            }
        }

        private decimal _am370;
        /// <summary>
        ///桦木混水合同应付款
        /// </summary>
        public decimal AM370
        {
            get
            {
                return _am370;
            }
            set
            {
                _am370 = value;
            }
        }

        private decimal _am371;
        /// <summary>
        ///桦木混水合同已付款
        /// </summary>
        public decimal AM371
        {
            get
            {
                return _am371;
            }
            set
            {
                _am371 = value;
            }
        }

        private decimal _am292;
        /// <summary>
        /// 桦木混水合同超补应付款
        /// </summary>
        public decimal AM292
        {
            get
            {
                return _am292;
            }
            set
            {
                _am292 = value;
            }
        }

        private decimal _am293;
        /// <summary>
        /// 桦木混水合同超补已付款
        /// </summary>
        public decimal AM293
        {
            get
            {
                return _am293;
            }
            set
            {
                _am293 = value;
            }
        }

        private decimal _am373;
        /// <summary>
        ///用库存荷木清水应付款
        /// </summary>
        public decimal AM373
        {
            get
            {
                return _am373;
            }
            set
            {
                _am373 = value;
            }
        }

        private decimal _am374;
        /// <summary>
        ///用库存荷木清水已付款
        /// </summary>
        public decimal AM374
        {
            get
            {
                return _am374;
            }
            set
            {
                _am374 = value;
            }
        }

        private decimal _am269;
        /// <summary>
        /// 用库存荷木清水超补已付款
        /// </summary>
        public decimal AM269
        {
            get
            {
                return _am269;
            }
            set
            {
                _am269 = value;
            }
        }

        private decimal _am287;
        /// <summary>
        /// 用库存荷木清水超补应付款
        /// </summary>
        public decimal AM287
        {
            get
            {
                return _am287;
            }
            set
            {
                _am287 = value;
            }
        }

        private decimal _am376;
        /// <summary>
        ///用库存荷木混水应付款
        /// </summary>
        public decimal AM376
        {
            get
            {
                return _am376;
            }
            set
            {
                _am376 = value;
            }
        }

        private decimal _am377;
        /// <summary>
        ///用库存荷木混水已付款
        /// </summary>
        public decimal AM377
        {
            get
            {
                return _am377;
            }
            set
            {
                _am377 = value;
            }
        }

        private decimal _am267;
        /// <summary>
        ///用库存荷木混水超补应付款
        /// </summary>
        public decimal AM267
        {
            get
            {
                return _am267;
            }
            set
            {
                _am267 = value;
            }
        }

        private decimal _am268;
        /// <summary>
        ///用库存荷木混水超补已付款
        /// </summary>
        public decimal AM268
        {
            get
            {
                return _am268;
            }
            set
            {
                _am268 = value;
            }
        }

        private decimal _am379;
        /// <summary>
        ///用库存榉木清水应付款
        /// </summary>
        public decimal AM379
        {
            get
            {
                return _am379;
            }
            set
            {
                _am379 = value;
            }
        }

        private decimal _am380;
        /// <summary>
        ///用库存榉木清水已付款
        /// </summary>
        public decimal AM380
        {
            get
            {
                return _am380;
            }
            set
            {
                _am380 = value;
            }
        }

        private decimal _am265;
        /// <summary>
        ///用库存榉木超补应付款
        /// </summary>
        public decimal AM265
        {
            get
            {
                return _am265;
            }
            set
            {
                _am265 = value;
            }
        }

        private decimal _am266;
        /// <summary>
        /// 用库存榉木超补已付款
        /// </summary>
        public decimal AM266
        {
            get
            {
                return _am266;
            }
            set
            {
                _am266 = value;
            }
        }

        private string _am384;
        /// <summary>
        /// 是否超补
        /// </summary>
        public string AM384
        {
            get
            {
                return _am384;
            }
            set
            {
                _am384 = value;
            }
        }

        private decimal _am385;
        /// <summary>
        ///用库存锻木清水应付款
        /// </summary>
        public decimal AM385
        {
            get
            {
                return _am385;
            }
            set
            {
                _am385 = value;
            }
        }

        private decimal _am386;
        /// <summary>
        ///用库存锻木清水已付款
        /// </summary>
        public decimal AM386
        {
            get
            {
                return _am386;
            }
            set
            {
                _am386 = value;
            }
        }

        private decimal _am382;
        /// <summary>
        ///用库存椴木清水超补应付款
        /// </summary>
        public decimal AM382
        {
            get
            {
                return _am382;
            }
            set
            {
                _am382 = value;
            }
        }

        private decimal _am383;
        /// <summary>
        ///用库存椴木清水超补已付款
        /// </summary>
        public decimal AM383
        {
            get
            {
                return _am383;
            }
            set
            {
                _am383 = value;
            }
        }

        private decimal _am388;
        /// <summary>
        ///用库存锻木混水应付款
        /// </summary>
        public decimal AM388
        {
            get
            {
                return _am388;
            }
            set
            {
                _am388 = value;
            }
        }

        private decimal _am389;
        /// <summary>
        ///用库存锻木混水已付款
        /// </summary>
        public decimal AM389
        {
            get
            {
                return _am389;
            }
            set
            {
                _am389 = value;
            }
        }

        private decimal _am263;
        /// <summary>
        /// 用库存椴木混水超补应付款
        /// </summary>
        public decimal AM263
        {
            get
            {
                return _am263;
            }
            set
            {
                _am263 = value;
            }
        }

        private decimal _am264;
        /// <summary>
        ///用库存椴木混水超补已付款
        /// </summary>
        public decimal AM264
        {
            get
            {
                return _am264;
            }
            set
            {
                _am264 = value;
            }
        }

        private decimal _am391;
        /// <summary>
        ///用库存桦木清水应付款
        /// </summary>
        public decimal AM391
        {
            get
            {
                return _am391;
            }
            set
            {
                _am391 = value;
            }
        }

        private decimal _am392;
        /// <summary>
        ///用库存桦木清水已付款
        /// </summary>
        public decimal AM392
        {
            get
            {
                return _am392;
            }
            set
            {
                _am392 = value;
            }
        }

        private decimal _am261;
        /// <summary>
        ///用库存桦木清水超补应付款
        /// </summary>
        public decimal AM261
        {
            get
            {
                return _am261;
            }
            set
            {
                _am261 = value;
            }
        }

        private decimal _am262;
        /// <summary>
        ///用库存桦木清水超补已付款
        /// </summary>
        public decimal AM262
        {
            get
            {
                return _am262;
            }
            set
            {
                _am262 = value;
            }
        }

        #endregion
    }
}

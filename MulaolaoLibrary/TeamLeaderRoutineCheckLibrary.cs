using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MulaolaoLibrary
{
    public class TeamLeaderRoutineCheckLibrary
    {
        private int _idx;
        public int IDX
        {
            get
            {
                return _idx;
            }
            set
            {
                _idx = value;
            }
        }
        
        private string _qz001;
        /// <summary>
        /// 单号
        /// </summary>
        public string QZ001
        {
            get
            {
                return _qz001;
            }
            set
            {
                _qz001 = value;
            }
        }

        private string _qz010;
        /// <summary>
        /// 序号
        /// </summary>
        public string QZ010
        {
            get
            {
                return _qz010;
            }
            set
            {
                _qz010 = value;
            }
        }

        private DateTime _qz002;
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime QZ002
        {
            get
            {
                return _qz002;
            }
            set
            {
                _qz002 = value;
            }
        }

        private string _qz003;
        /// <summary>
        /// 部门
        /// </summary>
        public string QZ003
        {
            get
            {
                return _qz003;
            }
            set
            {
                _qz003 = value;
            }
        }

        private string _qz004;
        /// <summary>
        /// 姓名
        /// </summary>
        public string QZ004
        {
            get
            {
                return _qz004;
            }
            set
            {
                _qz004 = value;
            }
        }

        private string _qz005;
        /// <summary>
        /// 类别
        /// </summary>
        public string QZ005
        {
            get
            {
                return _qz005;
            }
            set
            {
                _qz005 = value;
            }
        }

        private decimal _qz006;
        /// <summary>
        /// 月考勤工数 R502
        /// </summary>
        public decimal QZ006
        {
            get
            {
                return _qz006;
            }
            set
            {
                _qz006 = value;
            }
        }

        private decimal _qz007;
        /// <summary>
        /// 月出勤日 R502
        /// </summary>
        public decimal QZ007
        {
            get
            {
                return _qz007;
            }
            set
            {
                _qz007 = value;
            }
        }

        private decimal _qz008;
        /// <summary>
        /// 月出产值万元 R468
        /// </summary>
        public decimal QZ008
        {
            get
            {
                return _qz008;
            }
            set
            {
                _qz008 = value;
            }
        }

        private decimal _qz009;
        /// <summary>
        /// 系数1(男)
        /// </summary>
        public decimal QZ009
        {
            get
            {
                return _qz009;
            }
            set
            {
                _qz009 = value;
            }
        }

        private decimal _qz015;
        /// <summary>
        /// 系数1(女)
        /// </summary>
        public decimal QZ015
        {
            get
            {
                return _qz015;
            }
            set
            {
                _qz015 = value;
            }
        }

        private decimal _qz040;
        /// <summary>
        /// 系数1(其它)
        /// </summary>
        public decimal QZ040
        {
            get
            {
                return _qz040;
            }
            set
            {
                _qz040 = value;
            }
        }

        private int _qz011;
        /// <summary>
        /// 系数2(男)
        /// </summary>
        public int QZ011
        {
            get
            {
                return _qz011;
            }
            set
            {
                _qz011 = value;
            }
        }

        private int _qz016;
        /// <summary>
        /// 系数2(女)
        /// </summary>
        public int QZ016
        {
            get
            {
                return _qz016;
            }
            set
            {
                _qz016 = value;
            }
        }

        private int _qz041;
        /// <summary>
        /// 系数2(其它)
        /// </summary>
        public int QZ041
        {
            get
            {
                return _qz041;
            }
            set
            {
                _qz041 = value;
            }
        }

        private decimal _qz012;
        /// <summary>
        /// 系数3(男)
        /// </summary>
        public decimal QZ012
        {
            get
            {
                return _qz012;
            }
            set
            {
                _qz012 = value;
            }
        }

        private decimal _qz042;
        /// <summary>
        /// 系数3(女)
        /// </summary>
        public decimal QZ042
        {
            get
            {
                return _qz042;
            }
            set
            {
                _qz042 = value;
            }
        }

        private decimal _qz043;
        /// <summary>
        /// 系数3(其它)
        /// </summary>
        public decimal QZ043
        {
            get
            {
                return _qz043;
            }
            set
            {
                _qz043 = value;
            }
        }

        private int _qz013;
        /// <summary>
        /// 本组创利润额R241
        /// </summary>
        public int QZ013
        {
            get
            {
                return _qz013;
            }
            set
            {
                _qz013 = value;
            }
        }

        private decimal _qz014;
        /// <summary>
        /// 月体系提资额  R502
        /// </summary>
        public decimal QZ014
        {
            get
            {
                return _qz014;
            }
            set
            {
                _qz014 = value;
            }
        }

        private int _qz017;
        /// <summary>
        /// 系数4(男)
        /// </summary>
        public int QZ017
        {
            get
            {
                return _qz017;
            }
            set
            {
                _qz017 = value;
            }
        }

        private int _qz044;
        /// <summary>
        /// 系数4(女)
        /// </summary>
        public int QZ044
        {
            get
            {
                return _qz044;
            }
            set
            {
                _qz044 = value;
            }
        }

        private int _qz045;
        /// <summary>
        /// 系数4(其它)
        /// </summary>
        public int QZ045
        {
            get
            {
                return _qz045;
            }
            set
            {
                _qz045 = value;
            }
        }

        private decimal _qz018;
        /// <summary>
        /// 系数5
        /// </summary>
        public decimal QZ018
        {
            get
            {
                return _qz018;
            }
            set
            {
                _qz018 = value;
            }
        }

        private int _qz019;
        /// <summary>
        /// 成本节省金额
        /// </summary>
        public int QZ019
        {
            get
            {
                return _qz019;
            }
            set
            {
                _qz019 = value;
            }
        }

        private decimal _qz020;
        /// <summary>
        /// 系数6
        /// </summary>
        public decimal QZ020
        {
            get
            {
                return _qz020;
            }
            set
            {
                _qz020 = value;
            }
        }

        private int _qz021;
        /// <summary>
        /// 退货批数
        /// </summary>
        public int QZ021
        {
            get
            {
                return _qz021;
            }
            set
            {
                _qz021 = value;
            }
        }

        private int _qz022;
        /// <summary>
        /// 批价1
        /// </summary>
        public int QZ022
        {
            get
            {
                return _qz022;
            }
            set
            {
                _qz022 = value;
            }
        }

        private int _qz023;
        /// <summary>
        /// 延误批数
        /// </summary>
        public int QZ023
        {
            get
            {
                return _qz023;
            }
            set
            {
                _qz023 = value;
            }
        }

        private int _qz024;
        /// <summary>
        /// 批价2
        /// </summary>
        public int QZ024
        {
            get
            {
                return _qz024;
            }
            set
            {
                _qz024 = value;
            }
        }

        private int _qz025;
        /// <summary>
        /// 产前参与策划批数
        /// </summary>
        public int QZ025
        {
            get
            {
                return _qz025;
            }
            set
            {
                _qz025 = value;
            }
        }

        private int _qz026;
        /// <summary>
        /// 批价3
        /// </summary>
        public int QZ026
        {
            get
            {
                return _qz026;
            }
            set
            {
                _qz026 = value;
            }
        }

        private int _qz027;
        /// <summary>
        /// 跟单批数R299R253
        /// </summary>
        public int QZ027
        {
            get
            {
                return _qz027;
            }
            set
            {
                _qz027 = value;
            }
        }

        private int _qz028;
        /// <summary>
        /// 批价4
        /// </summary>
        public int QZ028
        {
            get
            {
                return _qz028;
            }
            set
            {
                _qz028 = value;
            }
        }

        private int _qz029;
        /// <summary>
        /// 跟单批数R299R253
        /// </summary>
        public int QZ029
        {
            get
            {
                return _qz029;
            }
            set
            {
                _qz029 = value;
            }
        }

        private int _qz030;
        /// <summary>
        /// 批价5
        /// </summary>
        public int QZ030
        {
            get
            {
                return _qz030;
            }
            set
            {
                _qz030 = value;
            }
        }

        private string _qz031;
        /// <summary>
        /// 填表人
        /// </summary>
        public string QZ031
        {
            get
            {
                return _qz031;
            }
            set
            {
                _qz031 = value;
            }
        }

        private DateTime _qz032;
        /// <summary>
        /// 填表期
        /// </summary>
        public DateTime QZ032
        {
            get
            {
                return _qz032;
            }
            set
            {
                _qz032 = value;
            }
        }

        private string _qz033;
        /// <summary>
        /// 审核人
        /// </summary>
        public string QZ033
        {
            get
            {
                return _qz033;
            }
            set
            {
                _qz033 = value;
            }
        }

        private DateTime _qz034;
        /// <summary>
        /// 审核期
        /// </summary>
        public DateTime QZ034
        {
            get
            {
                return _qz034;
            }
            set
            {
                _qz034 = value;
            }
        }

        private string _qz035;
        /// <summary>
        /// 审批人
        /// </summary>
        public string QZ035
        {
            get
            {
                return _qz035;
            }
            set
            {
                _qz035 = value;
            }
        }

        private DateTime _qz036;
        /// <summary>
        /// 审批期
        /// </summary>
        public DateTime QZ036
        {
            get
            {
                return _qz036;
            }
            set
            {
                _qz036 = value;
            }
        }

        private string _qz037;
        /// <summary>
        /// 维护记录
        /// </summary>
        public string QZ037
        {
            get
            {
                return _qz037;
            }
            set
            {
                _qz037 = value;
            }
        }

        private string _qz038;
        /// <summary>
        /// 维护意见
        /// </summary>
        public string QZ038
        {
            get
            {
                return _qz038;
            }
            set
            {
                _qz038 = value;
            }
        }

        private int _qz039;
        /// <summary>
        /// 其它延误
        /// </summary>
        public int QZ039
        {
            get
            {
                return _qz039;
            }
            set
            {
                _qz039 = value;
            }
        }

        private int _qz046;
        /// <summary>
        /// 跟单批数R299R253
        /// </summary>
        public int QZ046
        {
            get
            {
                return _qz046;
            }
            set
            {
                _qz046 = value;
            }
        }

        private int _qz047;
        /// <summary>
        /// 批价6
        /// </summary>
        public int QZ047
        {
            get
            {
                return _qz047;
            }
            set
            {
                _qz047 = value;
            }
        }

        private int _qz048;
        /// <summary>
        /// 跟单批数R299R253
        /// </summary>
        public int QZ048
        {
            get
            {
                return _qz048;
            }
            set
            {
                _qz048 = value;
            }
        }

        private int _qz049;
        /// <summary>
        /// 批价7
        /// </summary>
        public int QZ049
        {
            get
            {
                return _qz049;
            }
            set
            {
                _qz049 = value;
            }
        }
    }
}


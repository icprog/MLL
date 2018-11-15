using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;

namespace MulaolaoLibrary
{
    public class ChanPinGaiShanEntity
    {
        public ChanPinGaiShanEntity ( )
        {

        }

        #region Model
        private long _idx;
        private string _gs34;
        private string _gs01;
        private string _gs46;
        private string _gs47;
        private string _gs48;
        private long? _gs49;
        private string _gs02;
        private string _gs03= "0";
        private decimal? _gs04=0M;
        private decimal? _gs05=0M;
        private decimal? _gs06=0M;
        private string _gs07;
        private string _gs08;
        private string _gs09;
        private decimal? _gs10=0M;
        private decimal? _gs11=0M;
        private decimal? _gs12=0M;
        private int? _gs13;
        private decimal? _gs51;
        private string _gs14;
        private string _gs15;
        private string _gs16;
        private string _gs17;
        private string _gs18;
        private DateTime? _gs19;
        private string _gs20;
        private string _gs21;
        private string _gs22;
        private DateTime? _gs23;
        private string _gs24;
        private DateTime? _gs25;
        private string _gs26;
        private DateTime? _gs27;
        private string _gs28;
        private DateTime? _gs29;
        private string _gs30= "0";
        private int? _gs31;
        private string _gs32;
        private string _gs33;
        private string _gs35;
        private decimal? _gs36;
        private decimal? _gs37;
        private string _gs38;
        private int? _gs39;
        private string _gs40;
        private string _gs41;
        private string _gs42;
        private string _gs43;
        private string _gs44;
        private DateTime? _gs45;
        private string _gs50;
        private string _gs52;
        private decimal? _gs53;
        private decimal? _gs54;
        private decimal? _gs55;
        private string _gs56;
        private string _gs57;
        private string _gs58;
        private decimal? _gs59;
        private decimal? _gs60;
        private decimal? _gs61;
        private int? _gs69;
        private string _gs62;
        private string _gs63;
        private string _gs64;
        private string _gs65;
        private string _gs66;
        private DateTime? _gs67;
        private string _gs68;
        private string _gs70;
        private string _gs71;
        private string _gs72;
        private string _gs73;
        private string _gs74;
        private string _gs75;
        private string _gs76;
        private string _gs77;
        private string _gs78;
        private string _gs79;
        private string _gs80;
        private string _gs81;
        private string _gs82;
        private string _gs83;
        private string _gs84;
        private string _gs85;
        private string _gs86;
        private string _gs87;
        private string _gs88;
        private string _gs89;
        private string _gs90;
        /// <summary>
        /// 
        /// </summary>
        public long idx
        {
            set
            {
                _idx = value;
            }
            get
            {
                return _idx;
            }
        }
        /// <summary>
        /// 单号
        /// </summary>
        public string GS34
        {
            set
            {
                _gs34 = value;
            }
            get
            {
                return _gs34;
            }
        }
        /// <summary>
        /// 流水号
        /// </summary>
        public string GS01
        {
            set
            {
                _gs01 = value;
            }
            get
            {
                return _gs01;
            }
        }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string GS46
        {
            set
            {
                _gs46 = value;
            }
            get
            {
                return _gs46;
            }
        }
        /// <summary>
        /// 合同号
        /// </summary>
        public string GS47
        {
            set
            {
                _gs47 = value;
            }
            get
            {
                return _gs47;
            }
        }
        /// <summary>
        /// 货号
        /// </summary>
        public string GS48
        {
            set
            {
                _gs48 = value;
            }
            get
            {
                return _gs48;
            }
        }
        /// <summary>
        /// 产品数量
        /// </summary>
        public long? GS49
        {
            set
            {
                _gs49 = value;
            }
            get
            {
                return _gs49;
            }
        }
        /// <summary>
        /// 材质 工段
        /// </summary>
        public string GS02
        {
            set
            {
                _gs02 = value;
            }
            get
            {
                return _gs02;
            }
        }
        /// <summary>
        /// 分组标记  新单  老单
        /// </summary>
        public string GS03
        {
            set
            {
                _gs03 = value;
            }
            get
            {
                return _gs03;
            }
        }
        /// <summary>
        /// 原单价
        /// </summary>
        public decimal? GS04
        {
            set
            {
                _gs04 = value;
            }
            get
            {
                return _gs04;
            }
        }
        /// <summary>
        /// 计划下降差价
        /// </summary>
        public decimal? GS05
        {
            set
            {
                _gs05 = value;
            }
            get
            {
                return _gs05;
            }
        }
        /// <summary>
        /// 采购合计单价
        /// </summary>
        public decimal? GS06
        {
            set
            {
                _gs06 = value;
            }
            get
            {
                return _gs06;
            }
        }
        /// <summary>
        /// 零件名称
        /// </summary>
        public string GS07
        {
            set
            {
                _gs07 = value;
            }
            get
            {
                return _gs07;
            }
        }
        /// <summary>
        /// 规格
        /// </summary>
        public string GS08
        {
            set
            {
                _gs08 = value;
            }
            get
            {
                return _gs08;
            }
        }
        /// <summary>
        /// 单位
        /// </summary>
        public string GS09
        {
            set
            {
                _gs09 = value;
            }
            get
            {
                return _gs09;
            }
        }
        /// <summary>
        /// 每套零件数量
        /// </summary>
        public decimal? GS10
        {
            set
            {
                _gs10 = value;
            }
            get
            {
                return _gs10;
            }
        }
        /// <summary>
        /// 采购零件单价
        /// </summary>
        public decimal? GS11
        {
            set
            {
                _gs11 = value;
            }
            get
            {
                return _gs11;
            }
        }
        /// <summary>
        /// 采购小计单价
        /// </summary>
        public decimal? GS12
        {
            set
            {
                _gs12 = value;
            }
            get
            {
                return _gs12;
            }
        }
        /// <summary>
        /// 提成
        /// </summary>
        public int? GS13
        {
            set
            {
                _gs13 = value;
            }
            get
            {
                return _gs13;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? GS51
        {
            set
            {
                _gs51 = value;
            }
            get
            {
                return _gs51;
            }
        }
        /// <summary>
        /// 改善事项
        /// </summary>
        public string GS14
        {
            set
            {
                _gs14 = value;
            }
            get
            {
                return _gs14;
            }
        }
        /// <summary>
        /// 措施方法
        /// </summary>
        public string GS15
        {
            set
            {
                _gs15 = value;
            }
            get
            {
                return _gs15;
            }
        }
        /// <summary>
        /// 执行责任人
        /// </summary>
        public string GS16
        {
            set
            {
                _gs16 = value;
            }
            get
            {
                return _gs16;
            }
        }
        /// <summary>
        /// 审核人
        /// </summary>
        public string GS17
        {
            set
            {
                _gs17 = value;
            }
            get
            {
                return _gs17;
            }
        }
        /// <summary>
        /// 监督人
        /// </summary>
        public string GS18
        {
            set
            {
                _gs18 = value;
            }
            get
            {
                return _gs18;
            }
        }
        /// <summary>
        /// 应完成时间
        /// </summary>
        public DateTime? GS19
        {
            set
            {
                _gs19 = value;
            }
            get
            {
                return _gs19;
            }
        }
        /// <summary>
        /// 供应商编号
        /// </summary>
        public string GS20
        {
            set
            {
                _gs20 = value;
            }
            get
            {
                return _gs20;
            }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string GS21
        {
            set
            {
                _gs21 = value;
            }
            get
            {
                return _gs21;
            }
        }
        /// <summary>
        /// 计划定价人
        /// </summary>
        public string GS22
        {
            set
            {
                _gs22 = value;
            }
            get
            {
                return _gs22;
            }
        }
        /// <summary>
        /// 定价期
        /// </summary>
        public DateTime? GS23
        {
            set
            {
                _gs23 = value;
            }
            get
            {
                return _gs23;
            }
        }
        /// <summary>
        /// 填表人
        /// </summary>
        public string GS24
        {
            set
            {
                _gs24 = value;
            }
            get
            {
                return _gs24;
            }
        }
        /// <summary>
        /// 填表期
        /// </summary>
        public DateTime? GS25
        {
            set
            {
                _gs25 = value;
            }
            get
            {
                return _gs25;
            }
        }
        /// <summary>
        /// 审核人
        /// </summary>
        public string GS26
        {
            set
            {
                _gs26 = value;
            }
            get
            {
                return _gs26;
            }
        }
        /// <summary>
        /// 审核期
        /// </summary>
        public DateTime? GS27
        {
            set
            {
                _gs27 = value;
            }
            get
            {
                return _gs27;
            }
        }
        /// <summary>
        /// 批准人
        /// </summary>
        public string GS28
        {
            set
            {
                _gs28 = value;
            }
            get
            {
                return _gs28;
            }
        }
        /// <summary>
        /// 批准期
        /// </summary>
        public DateTime? GS29
        {
            set
            {
                _gs29 = value;
            }
            get
            {
                return _gs29;
            }
        }
        /// <summary>
        /// 监督人
        /// </summary>
        public string GS30
        {
            set
            {
                _gs30 = value;
            }
            get
            {
                return _gs30;
            }
        }
        /// <summary>
        /// 降价次数
        /// </summary>
        public int? GS31
        {
            set
            {
                _gs31 = value;
            }
            get
            {
                return _gs31;
            }
        }
        /// <summary>
        /// 维护意见
        /// </summary>
        public string GS32
        {
            set
            {
                _gs32 = value;
            }
            get
            {
                return _gs32;
            }
        }
        /// <summary>
        /// 维护记录
        /// </summary>
        public string GS33
        {
            set
            {
                _gs33 = value;
            }
            get
            {
                return _gs33;
            }
        }
        /// <summary>
        /// 工段
        /// </summary>
        public string GS35
        {
            set
            {
                _gs35 = value;
            }
            get
            {
                return _gs35;
            }
        }
        /// <summary>
        /// 原单价
        /// </summary>
        public decimal? GS36
        {
            set
            {
                _gs36 = value;
            }
            get
            {
                return _gs36;
            }
        }
        /// <summary>
        /// 计划下降差价
        /// </summary>
        public decimal? GS37
        {
            set
            {
                _gs37 = value;
            }
            get
            {
                return _gs37;
            }
        }
        /// <summary>
        /// 单位
        /// </summary>
        public string GS38
        {
            set
            {
                _gs38 = value;
            }
            get
            {
                return _gs38;
            }
        }
        /// <summary>
        /// 提成
        /// </summary>
        public int? GS39
        {
            set
            {
                _gs39 = value;
            }
            get
            {
                return _gs39;
            }
        }
        /// <summary>
        /// 改善事项
        /// </summary>
        public string GS40
        {
            set
            {
                _gs40 = value;
            }
            get
            {
                return _gs40;
            }
        }
        /// <summary>
        /// 措施方法
        /// </summary>
        public string GS41
        {
            set
            {
                _gs41 = value;
            }
            get
            {
                return _gs41;
            }
        }
        /// <summary>
        /// 执行责任人
        /// </summary>
        public string GS42
        {
            set
            {
                _gs42 = value;
            }
            get
            {
                return _gs42;
            }
        }
        /// <summary>
        /// 审核人
        /// </summary>
        public string GS43
        {
            set
            {
                _gs43 = value;
            }
            get
            {
                return _gs43;
            }
        }
        /// <summary>
        /// 监督人
        /// </summary>
        public string GS44
        {
            set
            {
                _gs44 = value;
            }
            get
            {
                return _gs44;
            }
        }
        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime? GS45
        {
            set
            {
                _gs45 = value;
            }
            get
            {
                return _gs45;
            }
        }
        /// <summary>
        ///  部门名称
        /// </summary>
        public string GS50
        {
            set
            {
                _gs50 = value;
            }
            get
            {
                return _gs50;
            }
        }
        /// <summary>
        /// 辅料
        /// </summary>
        public string GS52
        {
            set
            {
                _gs52 = value;
            }
            get
            {
                return _gs52;
            }
        }
        /// <summary>
        /// 原单价
        /// </summary>
        public decimal? GS53
        {
            set
            {
                _gs53 = value;
            }
            get
            {
                return _gs53;
            }
        }
        /// <summary>
        /// 计划下降差价
        /// </summary>
        public decimal? GS54
        {
            set
            {
                _gs54 = value;
            }
            get
            {
                return _gs54;
            }
        }
        /// <summary>
        /// 采购合计单价
        /// </summary>
        public decimal? GS55
        {
            set
            {
                _gs55 = value;
            }
            get
            {
                return _gs55;
            }
        }
        /// <summary>
        /// 零件名称
        /// </summary>
        public string GS56
        {
            set
            {
                _gs56 = value;
            }
            get
            {
                return _gs56;
            }
        }
        /// <summary>
        /// 规格
        /// </summary>
        public string GS57
        {
            set
            {
                _gs57 = value;
            }
            get
            {
                return _gs57;
            }
        }
        /// <summary>
        /// 单位
        /// </summary>
        public string GS58
        {
            set
            {
                _gs58 = value;
            }
            get
            {
                return _gs58;
            }
        }
        /// <summary>
        /// 每套零件数量
        /// </summary>
        public decimal? GS59
        {
            set
            {
                _gs59 = value;
            }
            get
            {
                return _gs59;
            }
        }
        /// <summary>
        /// 采购零件单价
        /// </summary>
        public decimal? GS60
        {
            set
            {
                _gs60 = value;
            }
            get
            {
                return _gs60;
            }
        }
        /// <summary>
        /// 辅料总单价
        /// </summary>
        public decimal? GS61
        {
            set
            {
                _gs61 = value;
            }
            get
            {
                return _gs61;
            }
        }
        /// <summary>
        /// 提成
        /// </summary>
        public int? GS69
        {
            set
            {
                _gs69 = value;
            }
            get
            {
                return _gs69;
            }
        }
        /// <summary>
        /// 改善事项
        /// </summary>
        public string GS62
        {
            set
            {
                _gs62 = value;
            }
            get
            {
                return _gs62;
            }
        }
        /// <summary>
        /// 措施方法
        /// </summary>
        public string GS63
        {
            set
            {
                _gs63 = value;
            }
            get
            {
                return _gs63;
            }
        }
        /// <summary>
        /// 执行责任人
        /// </summary>
        public string GS64
        {
            set
            {
                _gs64 = value;
            }
            get
            {
                return _gs64;
            }
        }
        /// <summary>
        /// 审核人
        /// </summary>
        public string GS65
        {
            set
            {
                _gs65 = value;
            }
            get
            {
                return _gs65;
            }
        }
        /// <summary>
        /// 监督人
        /// </summary>
        public string GS66
        {
            set
            {
                _gs66 = value;
            }
            get
            {
                return _gs66;
            }
        }
        /// <summary>
        /// 应完成时间
        /// </summary>
        public DateTime? GS67
        {
            set
            {
                _gs67 = value;
            }
            get
            {
                return _gs67;
            }
        }
        /// <summary>
        /// 供应商编号
        /// </summary>
        public string GS68
        {
            set
            {
                _gs68 = value;
            }
            get
            {
                return _gs68;
            }
        }
        /// <summary>
        /// 合同代号
        /// </summary>
        public string GS70
        {
            set
            {
                _gs70 = value;
            }
            get
            {
                return _gs70;
            }
        }
        /// <summary>
        /// 类别
        /// </summary>
        public string GS71
        {
            set
            {
                _gs71 = value;
            }
            get
            {
                return _gs71;
            }
        }
        /// <summary>
        /// 046零件
        /// </summary>
        public string GS72
        {
            set
            {
                _gs72 = value;
            }
            get
            {
                return _gs72;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GS73
        {
            set
            {
                _gs73 = value;
            }
            get
            {
                return _gs73;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GS74
        {
            set
            {
                _gs74 = value;
            }
            get
            {
                return _gs74;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GS75
        {
            set
            {
                _gs75 = value;
            }
            get
            {
                return _gs75;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GS76
        {
            set
            {
                _gs76 = value;
            }
            get
            {
                return _gs76;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GS77
        {
            set
            {
                _gs77 = value;
            }
            get
            {
                return _gs77;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GS78
        {
            set
            {
                _gs78 = value;
            }
            get
            {
                return _gs78;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GS79
        {
            set
            {
                _gs79 = value;
            }
            get
            {
                return _gs79;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GS80
        {
            set
            {
                _gs80 = value;
            }
            get
            {
                return _gs80;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GS81
        {
            set
            {
                _gs81 = value;
            }
            get
            {
                return _gs81;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GS82
        {
            set
            {
                _gs82 = value;
            }
            get
            {
                return _gs82;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GS83
        {
            set
            {
                _gs83 = value;
            }
            get
            {
                return _gs83;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GS84
        {
            set
            {
                _gs84 = value;
            }
            get
            {
                return _gs84;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GS85
        {
            set
            {
                _gs85 = value;
            }
            get
            {
                return _gs85;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GS86
        {
            set
            {
                _gs86 = value;
            }
            get
            {
                return _gs86;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GS87
        {
            set
            {
                _gs87 = value;
            }
            get
            {
                return _gs87;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GS88
        {
            set
            {
                _gs88 = value;
            }
            get
            {
                return _gs88;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GS89
        {
            set
            {
                _gs89 = value;
            }
            get
            {
                return _gs89;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GS90
        {
            set
            {
                _gs90 = value;
            }
            get
            {
                return _gs90;
            }
        }

        #endregion
    }
}

using System;
using System . Data . SqlClient;
using System . Windows . Forms;
using Mulaolao . Class;
using StudentMgr;

namespace Mulaolao . Procedure
{
    public partial class R_FrmContractreviewa : Form
    {
        public R_FrmContractreviewa()
        {
            InitializeComponent();
            this.btnYes.Click += new EventHandler(btnYes_Click);

        }
        //R_FrmContractreview cnt;
        //bool result = false;
        public string r021 = "";
        private void R_FrmContractreviewa_Load(object sender, EventArgs e)
        {           
            //if (chuan == "")
            //{
            //    MessageBox.Show("合同编号不可为空,请返回填写再进行操作");
            //}
            //else
            //{
            //    DataTable de = SqlHelper.ExecuteDataTable("SELECT HT02 FROM R_PQL WHERE HT02=@HT02",new SqlParameter("@HT02",chuan));
            //    if (de.Rows.Count < 1)
            //    {
            //        MessageBox.Show("没有数据,无法操作");
            //    }
            //    else
            //    {
            //        for (int i = 0; i < de.Rows.Count; i++)
            //        {
            //            if (de.Rows[i]["HT02"].ToString() == chuan)
            //            {
            //                result = true;
            //                break;
            //            }
            //            else
            //            {
            //                MessageBox.Show("没有内容,不能填写评审意见");
            //                this.Close();
            //            }
            //        }
            //    }
            //}
        }

        //添加一个委托
        public delegate void PassDataBetweenFormHandler(object sender, PassDataWinFormEventArgs e);
        //添加一个PassDataBetweenFormHandler类型的事件
        public event PassDataBetweenFormHandler PassDataBetweenForm;

        //禁用窗体关闭功能
        private const int CP_NOCLOSE_BUTTON = 0X200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
        string HT17 = "", HT18 = "", HT19 = "", HT02 = "", HT20 = "", HT21 = "", HT22 = "", HT23 = "", HT24 = "", HT25 = "", HT26 = "", HT27 = "", HT28 = "", HT29 = "", HT31 = "", HT32 = "", HT33 = "", HT35 = "", HT36 = "", HT37 = "", HT38 = "", HT40 = "", HT41 = "", HT42 = "", HT43 = "", HT45 = "", HT46 = "", HT47 = "", HT48 = "", HT49 = "", HT50 = "", HT52 = "", HT53 = "", HT55 = "", HT57 = "";
        DateTime HT30 = MulaolaoBll . Drity . GetDt ( ), HT34 = MulaolaoBll . Drity . GetDt ( ), HT39 = MulaolaoBll . Drity . GetDt ( ), HT44 = MulaolaoBll . Drity . GetDt ( ), HT51 = MulaolaoBll . Drity . GetDt ( ), HT54 = MulaolaoBll . Drity . GetDt ( ), HT56 = MulaolaoBll . Drity . GetDt ( );
        public string chuan = "";
        //确定状态
        public void btnYes_Click(object sender, EventArgs e)
        {
            HT02 = chuan;
            string con1 = "", con2 = "", con3 = "", con4 = "", con5 = "", con6 = "", con7 = "", con8 = "",con9="";
            #region  行政管理部意见
            if (r021 == "1")
            {
                if (rab1.Checked == false && rab2.Checked == false)
                {
                    MessageBox.Show( "请选择合同文件是否具备法律效力" );
                }
                else
                {
                    if (rab1.Checked)
                    {
                        con1 = rab1.Text + "(" + textB2.Text + ")";
                    }
                    else if (rab2.Checked)
                    {
                        con1 = rab2.Text + "(" + textB2.Text + ")";
                    }
                    if (rab3.Checked == false && rab4.Checked == false)
                    {
                        MessageBox.Show( "请选择双方权利与义务是否合理、明确" );
                    }
                    else
                    {
                        if (rab3.Checked)
                        {
                            con2 = rab3.Text + "(" + textB3.Text + ")";
                        }
                        else if (rab4.Checked)
                        {
                            con2 = rab4.Text + "(" + textB3.Text + ")";
                        }
                        con3 = textB1.Text;
                        PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( con1, con2, con3 );
                        if (PassDataBetweenForm != null)
                        {
                            PassDataBetweenForm( this, args );
                        }
                        HT17 = gb1.Text;
                        HT18 = con1;
                        HT19 = gb2.Text;
                        HT20 = con2;
                        HT21 = con3;
                        SqlHelper.ExecuteNonQuery( "UPDATE R_PQL SET HT17=@HT17,HT18=@HT18,HT19=@HT19,HT20=@HT20,HT21=@HT21 WHERE HT02=@HT02", new SqlParameter( "@HT17", HT17 ), new SqlParameter( "HT18", HT18 ), new SqlParameter( "HT19", HT19 ), new SqlParameter( "HT20", HT20 ), new SqlParameter( "@HT21", HT21 ), new SqlParameter( "@HT02", HT02 ) );
                    }
                }
            }

            #endregion

            #region 质检部意见
            else if (r021 == "6")
            {
                con1 = textB1.Text;
                PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( con1 );
                if (PassDataBetweenForm != null)
                {
                    PassDataBetweenForm( this, args );
                }
                SqlHelper.ExecuteNonQuery( "UPDATE  R_PQL SET HT26=@HT26 WHERE HT02=@HT02", new SqlParameter( "@HT26", con1 ), new SqlParameter( "@HT02", HT02 ) );
            }
            #endregion

            #region 业务部意见
            else if (r021 == "2")
            {
                if (textB1.Text == "")
                {
                    MessageBox.Show( "责任部门签字必须填写" );
                }
                else
                {
                    con1 = dateTimePicker1.Value.ToString( );
                    con2 = dateTimePicker2.Value.ToString( );
                    con3 = "时间:" + dateTimePicker3.Text + " 数量:" + textBox1.Text;
                    con4 = dateTimePicker5.Value.ToString( );
                    con5 = textB1.Text;
                    PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( con1, con2, con3, con4, con5 );
                    if (PassDataBetweenForm != null)
                    {
                        PassDataBetweenForm( this, args );
                    }
                    HT27 = "产品需求及标准样发布到位时间";
                    HT28 = con1;
                    HT29 = "大箱、彩盒等包装物资到位时间";
                    HT30 = dateTimePicker2.Value;
                    HT31 = "需提供大货确认样数量和时间";
                    HT32 = con3;
                    HT33 = "商检报检、客检（验货）时间";
                    HT34 = dateTimePicker5.Value;
                    HT35 = con5;
                    SqlHelper.ExecuteNonQuery( "UPDATE R_PQL SET HT27=@HT27,HT28=@HT28,HT29=@HT29,HT30=@HT30,HT31=@HT31,HT32=@HT32,HT33=@HT33,HT34=@HT34,HT35=@HT35 WHERE HT02=@HT02", new SqlParameter( "@HT27", HT27 ), new SqlParameter( "HT28", HT28 ), new SqlParameter( "HT29", HT29 ), new SqlParameter( "HT30", HT30 ), new SqlParameter( "HT31", HT31 ), new SqlParameter( "HT32", HT32 ), new SqlParameter( "HT33", HT33 ), new SqlParameter( "HT34", HT34 ), new SqlParameter( "HT35", HT35 ), new SqlParameter( "HT02", HT02 ) );
                }
            }
            #endregion

            #region 木材采购部意见
            else if (r021 == "4")
            {
                if (textB1.Text == "")
                {
                    MessageBox.Show( "责任部门签字必须填写" );
                }
                else
                {
                    //con1 = "木材种类:" + textBox1.Text + " 数量:" + textB5.Text;
                    //con2 = dateTimePicker1.Text;
                    con1 = textB1.Text;
                    PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( con1 );
                    if (PassDataBetweenForm != null)
                    {
                        PassDataBetweenForm( this, args );
                    }
                }
                SqlHelper.ExecuteNonQuery( "UPDATE  R_PQL SET HT40=@HT40 WHERE HT02=@HT02", new SqlParameter( "@HT40", con1 ), new SqlParameter( "@HT02", HT02 ) );
            }
            #endregion

            #region 物资采购部意见
            else if (r021 == "5")
            {
                if (textB1.Text == "")
                {
                    MessageBox.Show( "责任部门签字必须填写" );
                }
                else
                {

                    con1 = "物资:" + textBox1.Text + " 要求:" + textB5.Text;
                    con2 = dateTimePicker1.Text;
                    con3 = textB1.Text;
                    PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( con1, con2, con3 );
                    if (PassDataBetweenForm != null)
                    {
                        PassDataBetweenForm( this, args );
                    }
                    HT41 = "需采购物资及应符合的标准要求";
                    HT42 = con1;
                    HT43 = "物资供应到位时间";
                    HT44 = dateTimePicker1.Value;
                    HT45 = con3;
                    SqlHelper.ExecuteNonQuery( "UPDATE R_PQL SET HT41=@HT41,HT42=@HT42,HT43=@HT43,HT44=@HT44,HT45=@HT45 WHERE HT02=@HT02", new SqlParameter( "@HT41", HT41 ), new SqlParameter( "HT42", HT42 ), new SqlParameter( "@HT43", HT43 ), new SqlParameter( "HT44", HT44 ), new SqlParameter( "HT45", HT45 ), new SqlParameter( "HT02", HT02 ) );
                }
            }
            #endregion

            #region 生产部意见
            else if (r021 == "3")
            {
                if (textB1.Text == "")
                {
                    MessageBox.Show( "责任部门签字必须填写" );
                }
                else
                {
                    con1 = textBox1.Text;
                    con2 = textB5.Text;
                    con3 = dateTimePicker1.Value.ToString( );
                    con4 = "种类:" + textBox2.Text + "数量:" + textBox3.Text;
                    con5 = dateTimePicker2.Value.ToString( );
                    con6 = textB2.Text;
                    con7 = textB3.Text;
                    con8 = dateTimePicker3.Value.ToString( );
                    con9 = textB1.Text;
                    PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( con1, con2, con3, con4, con5, con6, con7, con8, con9 );
                    if (PassDataBetweenForm != null)
                    {
                        PassDataBetweenForm( this, args );
                    }
                    HT22 = "产品应符合的标准";
                    HT23 = con6;
                    HT24 = "需做测试项目";
                    HT25 = con7;
                    HT53 = "化学品采购到位时间";
                    HT54 = dateTimePicker3.Value;
                    HT36 = "木材种类及需要大约数量";
                    HT37 = con4;
                    HT38 = "供应到位时间";
                    HT39 = dateTimePicker2.Value;
                    HT46 = "应符合的（质量）技术要求";
                    HT47 = con1;
                    HT48 = "场地、设备、人员等是否满足要求";
                    HT49 = con2;
                    HT50 = "产品最终完成时间";
                    HT51 = dateTimePicker1.Value;
                    HT52 = con9;
                    SqlHelper.ExecuteNonQuery( "UPDATE R_PQL SET HT22=@HT22,HT23=@HT23,HT24=@HT24,HT25=@HT25,HT53=@HT53,HT54=@HT54,HT36=@HT36,HT37=@HT37,HT38=@HT38,HT39=@HT39,HT46=@HT46,HT47=@HT47,HT48=@HT48,HT49=@HT49,HT50=@HT50,HT51=@HT51,HT52=@HT52 WHERE HT02=@HT02", new SqlParameter( "@HT22", HT22 ), new SqlParameter( "@HT23", HT23 ), new SqlParameter( "@HT24", HT24 ), new SqlParameter( "@HT25", HT25 ), new SqlParameter( "@HT53", HT53 ), new SqlParameter( "@HT54", HT54 ), new SqlParameter( "@HT36", HT36 ), new SqlParameter( "@HT37", HT37 ), new SqlParameter( "@HT38", HT38 ), new SqlParameter( "@HT39", HT39 ), new SqlParameter( "@HT46", HT46 ), new SqlParameter( "HT47", HT47 ), new SqlParameter( "@HT48", HT48 ), new SqlParameter( "HT49", HT49 ), new SqlParameter( "@HT50", HT50 ), new SqlParameter( "HT51", HT51 ), new SqlParameter( "HT52", HT52 ), new SqlParameter( "HT02", HT02 ) );
                }
            }
            #endregion

            #region 生产部变更意见
            else if (r021 == "7")
            {
                if (textB1.Text == "")
                {
                    MessageBox.Show( "责任部门签字必须填写" );
                }
                else
                {
                    con1 = dateTimePicker1.Value.ToString( );
                    con2 = textB1.Text;
                    PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( con1, con2 );
                    if (PassDataBetweenForm != null)
                    {
                        PassDataBetweenForm( this, args );
                    }
                    HT55 = " 产品最终完成时间变更日期";
                    HT56 = dateTimePicker1.Value;
                    HT57 = con2;
                    SqlHelper.ExecuteNonQuery( "UPDATE R_PQL SET HT55=@HT55,HT56=@HT56,HT57=@HT57 WHERE HT02=@HT02" ,new SqlParameter("@HT55",HT55), new SqlParameter( "@HT56", HT56 ), new SqlParameter( "@HT57", HT57 ), new SqlParameter( "@HT02", HT02 ) );
                }
            }
            #endregion

            this.Close();
        }
        //取消状态
        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

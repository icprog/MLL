using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mulaolao.Procedure;
using Mulaolao.Class;
using StudentMgr;
using Mulaolao.Contract;
using Mulaolao.Bom;
using Mulaolao.Other;

namespace Mulaolao.Raw_material_cost
{
    public partial class R_Frmchanpingaishan : FormChild
    {
        public R_Frmchanpingaishan(Form1 fm)
        {
            this.MdiParent = fm;
            InitializeComponent();
        }

        R_FrmContractreviewb conb = new R_FrmContractreviewb();
        youSelect ys = new youSelect();
        DataTable ddl;
        GroupBox[] gb;

        private void R_Frmchanpingaishan_Load( object sender, EventArgs e )
        {
            Power( this );
            ////小计
            //gridView1.GroupSummary.Add( DevExpress.Data.SummaryItemType.Sum, "GS04", GS04, "下降小计：{0}" );
            //gridView1.GroupSummary.Add( DevExpress.Data.SummaryItemType.Sum, "GS05", GS05, "下降小计：{0}" );
            //gridView1.GroupSummary.Add( DevExpress.Data.SummaryItemType.Sum, "caixia", U0, "下降小计:{0}" );
            //gridView1.GroupSummary.Add( DevExpress.Data.SummaryItemType.Sum, "GS06", GS06, "下降小计：{0}" );
            //gridView1.GroupSummary.Add( DevExpress.Data.SummaryItemType.Sum, "jidan", U1, "下降小计：{0}" );
            //gridView1.GroupSummary.Add( DevExpress.Data.SummaryItemType.Sum, "jicha", U2, "下降小计：{0}" );
            //gridView1.GroupSummary.Add( DevExpress.Data.SummaryItemType.Sum, "caicha", caicha, "下降小计：{0}" );
            //gridView1.GroupSummary.Add( DevExpress.Data.SummaryItemType.Sum, "caixiaodan", U5, "下降小计：{0}" );
            //gridView1.GroupSummary.Add( DevExpress.Data.SummaryItemType.Sum, "tichen", U6, "下降小计：{0}" );

            Ergodic.FormEvery( this );
            gridControl1.DataSource = null;

            gb = new GroupBox[] { groupBox1, groupBox4, groupBox3 };
            Ergodic.FormGroupboxEnableFalse( this, gb );
            textBox16.Enabled = false;
            //列宽
            this.gridView1.IndicatorWidth = 40;

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;

            DataTable tpd = SqlHelper.ExecuteDataTable( "SELECT DBA002 FROM TPADBA" );
            comboBox11.DataSource = tpd;
            comboBox11.DisplayMember = "DBA002";
            DataTable tpds = tpd.Copy( );
            comboBox12.DataSource = tpds;
            comboBox12.DisplayMember = "DBA002";
            DataTable tp = tpd.Copy( );
            comboBox13.DataSource = tp;
            comboBox13.DisplayMember = "DBA002";

            #region
            DataTable bg = SqlHelper.ExecuteDataTable( "SELECT GS02,GS04,GS05,GS06,GS07,GS08,GS09,GS10,GS11,GS13,GS14,GS15,GS16,GS17,GS18,GS19 FROM R_PQP" );
            //材质
            DataTable cz = bg.DefaultView.ToTable( true, "GS02" );
            //DataTable cz = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS02 FROM R_PQP" );
            comboBox3.DataSource = cz;
            comboBox3.DisplayMember = "GS02";
            //原单价
            DataTable dj = bg.DefaultView.ToTable( true, "GS04" );
            //DataTable dj = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS04 FROM R_PQP" );
            comboBox1.DataSource = dj;
            comboBox1.DisplayMember = "GS04";
            //计划下降差价
            DataTable jxc = bg.DefaultView.ToTable( true, "GS05" );
            //DataTable jxc = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS05 FROM R_PQP" );
            comboBox4.DataSource = jxc;
            comboBox4.DisplayMember = "GS05";
            //提成
            DataTable tc = bg.DefaultView.ToTable( true, "GS13" );
            //DataTable tc = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS13 FROM R_PQP" );
            comboBox10.DataSource = tc;
            comboBox10.DisplayMember = "GS13";
            //零件名称
            DataTable ljmc = bg.DefaultView.ToTable( true, "GS07" );
            //DataTable ljmc = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS07 FROM R_PQP" );
            comboBox6.DataSource = ljmc;
            comboBox6.DisplayMember = "GS07";
            //规格
            DataTable gg = bg.DefaultView.ToTable( true, "GS08" );
            //DataTable gg = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS08 FROM R_PQP" );
            comboBox7.DataSource = gg;
            comboBox7.DisplayMember = "GS08";
            //单位
            DataTable dw = bg.DefaultView.ToTable( true, "GS09" );
            comboBox8.DataSource = dw;
            comboBox8.DisplayMember = "GS09";
            //每套零件数量
            DataTable mls = bg.DefaultView.ToTable( true, "GS10" );
            comboBox2.DataSource = mls;
            comboBox2.DisplayMember = "GS10";
            //采购零件单价
            DataTable cld = bg.DefaultView.ToTable( true, "GS11" );
            comboBox9.DataSource = cld;
            comboBox9.DisplayMember = "GS11";
            #endregion
        }

        #region 查询
        string GS01 = "", GS020 = "";
        Youqicaigou yq = new Youqicaigou( );
        //流水查询
        private void button4_Click( object sender, EventArgs e )
        {
            DataTable dhr = SqlHelper.ExecuteDataTable( "SELECT DISTINCT PQF01,PQF02,PQF03,PQF04,PQF06,PQF17,HT52 FROM R_PQF A, TPADAA B, R_REVIEWS C, R_PQL D, R_MLLCXMC E WHERE A.PQF17 = B.DAA001 AND A.PQF01 = D.HT01 AND A.PQF01 = C.RES06 AND C.RES01 = E.CX01 AND C.RES05 = '执行' AND CX02 IN( '合同评审表(R_021)', '订单销售合同(R_001)' ) ORDER BY PQF01 DESC" );
            if (dhr.Rows.Count < 1)
            {
                MessageBox.Show( "没有产品信息" );
            }
            else
            {
                yq.gridControl1.DataSource = dhr;
                yq.sy = "3";
                yq.PassDataBetweenForm += new Youqicaigou.PassDataBetweenFormHandler( yq_PassDataBetweenForm );
                yq.StartPosition = FormStartPosition.CenterScreen;
                yq.ShowDialog( );
            }
        }
        private void yq_PassDataBetweenForm( object sender, PassDataWinFormEventArgs e )
        {
            GS01 = e.ConOne;
            //流水
            textBox3.Text = e.ConOne;
            //合同
            textBox2.Text = e.ConTwo;
            //货号
            textBox5.Text = e.ConTre;
            //产品名称
            textBox1.Text = e.ConFor;
            //数量
            textBox4.Text = e.ConFiv;
            ////部门
            textBox12.Text = e.ConSix;
        }
        R_FrmTPADGA tpadga = new R_FrmTPADGA( );
        //供应商查询
        private void button5_Click( object sender, EventArgs e )
        {
            DataTable did = SqlHelper.ExecuteDataTable( "SELECT DGA001,DGA003,DGA008,DGA011,DGA017,DGA009,DGA012 FROM TPADGA" );
            if (did.Rows.Count < 1)
            {
                MessageBox.Show( "没有供应商信息" );
            }
            else
            {
                tpadga.gridControl2.DataSource = did;
                tpadga.st = "2";
                tpadga.PassDataBetweenForm += new R_FrmTPADGA.PassDataBetweenFomrHandler( tpadga_PassDataBetweenForm );
                tpadga.StartPosition = FormStartPosition.CenterScreen;
                tpadga.ShowDialog( );
            }
        }
        private void tpadga_PassDataBetweenForm( object sender, PassDataWinFormEventArgs e )
        {
            GS020 = e.ConOne;
            textBox11.Text = e.ConTwo;
            textBox15.Text = e.ConFiv;
        }
        R_FrmPQP pq = new R_FrmPQP( );
        //查询
        protected override void select( )
        {
            base.select( );
            DataTable da = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQP" );
            if (da.Rows.Count < 1)
            {
                MessageBox.Show( "没有数据" );
            }
            else
            {
                DataTable pqp = SqlHelper.ExecuteDataTable( "SELECT distinct GS01,PQF04,GS03 FROM R_PQP A,R_PQF B,TPADGA C WHERE A.GS01=B.PQF01 AND A.GS20=C.DGA001" );
                pq.gridControl1.DataSource = pqp;
                pq.pqstr = "1";
                pq.StartPosition = FormStartPosition.CenterScreen;
                pq.PassDataBetweenForm += new R_FrmPQP.PassDataBetweenFormHandler( pq_PassDataBetweenForm );
                pq.ShowDialog( );

                if (GS01 == "")
                {
                    MessageBox.Show( "您没有选择任何数据" );
                }
                else
                {
                    toolAdd.Enabled = true;
                    toolSelect.Enabled = true;
                    toolDelete.Enabled = true;
                    toolUpdate.Enabled = true;
                    toolReview.Enabled = true;
                    toolPrint.Enabled = true;
                    toolExport.Enabled = true;
                    toolMaintain.Enabled = true;
                    toolSave.Enabled = false;
                    toolCancel.Enabled = false;
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    button5.Enabled = false;
                    button6.Enabled = false;
                    button7.Enabled = false;
                    button8.Enabled = false;
                    button9.Enabled = false;
                    button10.Enabled = false;


                    textBox16.Enabled = false;

                    sads = "2";

                    DataTable das = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQP WHERE GS01=@GS01 AND idx=(SELECT MAX(idx) FROM (SELECT * FROM R_PQP WHERE GS01=@GS01) A)", new SqlParameter( "@GS01", GS01 ) );
                    if (das.Rows.Count < 1)
                    {
                        Ergodic.FormEvery( this );
                        gridControl1.DataSource = null;
                    }
                    else
                    {
                        if (das.Rows[0]["GS03"].ToString( ) == "新单")
                        {
                            radioButton2.Checked = true;
                        }
                        else
                        {
                            radioButton1.Checked = true;
                        }

                        textBox6.Text = das.Rows[0]["GS22"].ToString( );
                        if (das.Rows[0]["GS23"].ToString( ) != "")
                        {
                            datatimepickeroverride2.Value = Convert.ToDateTime( das.Rows[0]["GS23"] );
                        }
                        else
                        {
                            datatimepickeroverride2.Value = System.DateTime.Now;
                        }
                        textBox7.Text= das.Rows[0]["GS24"].ToString( );
                        if (das.Rows[0]["GS25"].ToString( ) != "")
                        {
                            datatimepickeroverride3.Value = Convert.ToDateTime( das.Rows[0]["GS25"] );
                        }
                        else
                        {
                            datatimepickeroverride3.Value = System.DateTime.Now;
                        }
                        textBox8.Text = das.Rows[0]["GS26"].ToString( );
                        if (das.Rows[0]["GS27"].ToString( ) != "")
                        {
                            datatimepickeroverride4.Value = Convert.ToDateTime( das.Rows[0]["GS27"] );
                        }
                        else
                        {
                            datatimepickeroverride4.Value = System.DateTime.Now;
                        }
                        textBox9.Text = das.Rows[0]["GS28"].ToString( );
                        if (das.Rows[0]["GS29"].ToString( ) != "")
                        {
                            datatimepickeroverride5.Value = Convert.ToDateTime( das.Rows[0]["GS29"] );
                        }
                        else
                        {
                            datatimepickeroverride5.Value = System.DateTime.Now;
                        }
                        textBox10.Text = das.Rows[0]["GS30"].ToString( );
                        comboBox16.Text= das.Rows[0]["GS31"].ToString( );
                        textBox16.Text = das.Rows[0]["GS32"].ToString( );

                        ddl = SqlHelper.ExecuteDataTable( "SELECT GS02,PQF06,GS04,GS05,GS07,GS08,GS09,GS10,GS11,GS13,GS14,GS15,GS16,GS17,GS18,GS19,GS20,DGA003,DGA011,D.U7 FROM R_PQP A, TPADGA B, R_PQF C, (SELECT GS02 U0, SUM( GS10 * GS11 ) U7 FROM R_PQP GROUP BY GS02 ) D WHERE A.GS20 = B.DGA001 AND A.GS01 = C.PQF01 AND A.GS02 = D.U0 AND GS01=@GS01 ORDER BY GS02", new SqlParameter( "@GS01", GS01 ) );
                        gridControl1.DataSource = ddl;
                    }
                }
            }
        }
        private void pq_PassDataBetweenForm( object sender, PassDataWinFormEventArgs e )
        {
            GS01 = e.ConOne;
            textBox3.Text = e.ConOne;
            textBox1.Text = e.ConTwo;
            if (e.ConFiv == "新单")
            {
                radioButton2.Checked = true;
            }
            else if(e.ConFiv=="老单")
            {
                radioButton1.Checked = true;
            }
        }
        #endregion

        #region 事件
        //降价次数
        private void comboBox16_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
                MessageBox.Show( "只允许输入整数" );
            }
        }
        //流水号
        private void textBox3_TextChanged( object sender, EventArgs e )
        {
            DataTable ddr = SqlHelper.ExecuteDataTable( "SELECT PQF01,PQF02,PQF03,PQF04,PQF06,PQF17,HT52 FROM R_PQF A, TPADAA B,R_PQL C WHERE A.PQF17=B.DAA001  AND C.HT01=A.PQF01 AND PQF01=@PQF01", new SqlParameter( "@PQF01", GS01 ) );
            if (ddr.Rows.Count < 1)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox12.Text = "";
            }
            else
            {
                textBox1.Text = ddr.Rows[0]["PQF04"].ToString( );
                textBox2.Text = ddr.Rows[0]["PQF02"].ToString( );
                textBox4.Text = ddr.Rows[0]["PQF06"].ToString( );
                textBox5.Text = ddr.Rows[0]["PQF03"].ToString( );
                textBox12.Text = ddr.Rows[0]["HT52"].ToString( );
            }
        }
        //原单价
        private void comboBox1_KeyPress( object sender, KeyPressEventArgs e )
        {
            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 46) && e.KeyChar != 8)
            {
                MessageBox.Show( "请输入数字" );
                e.Handled = true;
            }
            else if (char.IsPunctuation( e.KeyChar ))
            {
                if (comboBox1.Text.LastIndexOf( '.' ) != -1)
                {
                    e.Handled = true;
                    MessageBox.Show( "只能输入一个小数点" );
                }
            }
        }
        private void comboBox1_TextChanged( object sender, EventArgs e )
        {
            if (comboBox1.Text.Substring( 0 ) == ".")
            {
                comboBox1.Text = "0.";
                comboBox1.SelectionStart = 2;
            }
        }
        private void comboBox1_LostFocus( object sender, EventArgs e )
        {
            if (comboBox1.Text != "" && !DateDay.foreTwoNum( comboBox1 ))
            {
                this.comboBox1.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多两位,如99.99,请重新输入" );
            }
        }
        //计划下降差价
        private void comboBox4_KeyPress( object sender, KeyPressEventArgs e )
        {
            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 46) && e.KeyChar != 8)
            {
                MessageBox.Show( "请输入数字" );
                e.Handled = true;
            }
            else if (char.IsPunctuation( e.KeyChar ))
            {
                if (comboBox4.Text.LastIndexOf( '.' ) != -1)
                {
                    e.Handled = true;
                    MessageBox.Show( "只能输入一个小数点" );
                }
            }
        }
        private void comboBox4_TextChanged( object sender, EventArgs e )
        {
            if (comboBox4.Text.Substring( 0 ) == ".")
            {
                comboBox4.Text = "0.";
                comboBox4.SelectionStart = 2;
            }
        }
        private void comboBox4_LostFocus( object sender, EventArgs e )
        {
            if (comboBox4.Text != "" && !DateDay.threeTwoNum( comboBox4 ))
            {
                this.comboBox4.Text = "";
                MessageBox.Show( "只允许输入整数部分最一两位,小数部分最多两位,如9.99,请重新输入" );
            }
        }
        //提成
        private void comboBox10_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
                MessageBox.Show( "只允许输入整数" );
            }
        }
        //每套零件数量
        private void comboBox2_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
                MessageBox.Show( "只允许输入整数" );
            }
        }
        //采购零件单价
        private void comboBox9_KeyPress( object sender, KeyPressEventArgs e )
        {
            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 46) && e.KeyChar != 8)
            {
                MessageBox.Show( "请输入数字" );
                e.Handled = true;
            }
            else if (char.IsPunctuation( e.KeyChar ))
            {
                if (comboBox9.Text.LastIndexOf( '.' ) != -1)
                {
                    e.Handled = true;
                    MessageBox.Show( "只能输入一个小数点" );
                }
            }
        }
        private void comboBox9_TextChanged( object sender, EventArgs e )
        {
            if (comboBox9.Text.Substring( 0 ) == ".")
            {
                comboBox9.Text = "0.";
                comboBox9.SelectionStart = 2;
            }
        }
        private void comboBox9_LostFocus( object sender, EventArgs e )
        {
            if (comboBox9.Text != "" && !DateDay.foreThreeNum( comboBox9 ))
            {
                this.comboBox9.Text = "";
                MessageBox.Show( "只允许输入整数部分最一位,小数部分最多三位,如9.999,请重新输入" );
            }
        }
        //获取获得焦点的行的值
        string DGA03 = "", DGA01 = "", GS002 = "", GS007 = "";
        private void gridView1_FocusedRowChanged( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
            if (gridView1.RowCount < 1)
            {
                Ergodic.GroupboxEvery( groupBox4 );
            }
            else
            {
                comboBox3.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "GS02" ).ToString( );
                comboBox1.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "GS04" ).ToString( );
                comboBox4.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "GS05" ).ToString( );
                comboBox6.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "GS07" ).ToString( );
                comboBox7.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "GS08" ).ToString( );
                comboBox8.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "GS09" ).ToString( );
                comboBox2.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "GS10" ).ToString( );
                comboBox9.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "GS11" ).ToString( );
                comboBox10.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "GS13" ).ToString( );
                textBox13.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "GS14" ).ToString( );
                textBox14.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "GS15" ).ToString( );
                comboBox11.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "GS16" ).ToString( );
                comboBox12.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "GS17" ).ToString( );
                comboBox13.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "GS18" ).ToString( );
                textBox11.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "DGA003" ).ToString( );
                textBox15.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "DGA011" ).ToString( );
                if (gridView1.GetRowCellValue( e.FocusedRowHandle, "GS19" ).ToString( ) != "")
                {
                    datatimepickeroverride6.Value = Convert.ToDateTime( gridView1.GetRowCellValue( e.FocusedRowHandle,"GS19" ).ToString( ) );
                }  
                GS020= gridView1.GetRowCellValue( e.FocusedRowHandle, "GS20" ).ToString( );
                DGA03 = textBox11.Text;
                DGA01 = textBox15.Text;
                GS002 = comboBox3.Text;
                GS007 = comboBox6.Text;
            }
        }
        private void gridView1_Click( object sender, EventArgs e )
        {
            if (gridView1.RowCount == 1)
            {
                comboBox3.Text = gridView1.GetFocusedRowCellValue( "GS02" ).ToString( );
                comboBox1.Text = gridView1.GetFocusedRowCellValue(  "GS04" ).ToString( );
                comboBox4.Text = gridView1.GetFocusedRowCellValue(  "GS05" ).ToString( );
                comboBox6.Text = gridView1.GetFocusedRowCellValue(  "GS07" ).ToString( );
                comboBox7.Text = gridView1.GetFocusedRowCellValue(  "GS08" ).ToString( );
                comboBox8.Text = gridView1.GetFocusedRowCellValue(  "GS09" ).ToString( );
                comboBox2.Text = gridView1.GetFocusedRowCellValue(  "GS10" ).ToString( );
                comboBox9.Text = gridView1.GetFocusedRowCellValue(  "GS11" ).ToString( );
                comboBox10.Text = gridView1.GetFocusedRowCellValue(  "GS13" ).ToString( );
                textBox13.Text = gridView1.GetFocusedRowCellValue(  "GS14" ).ToString( );
                textBox14.Text = gridView1.GetFocusedRowCellValue(  "GS15" ).ToString( );
                comboBox11.Text = gridView1.GetFocusedRowCellValue(  "GS16" ).ToString( );
                comboBox12.Text = gridView1.GetFocusedRowCellValue(  "GS17" ).ToString( );
                comboBox13.Text = gridView1.GetFocusedRowCellValue(  "GS18" ).ToString( );
                textBox11.Text = gridView1.GetFocusedRowCellValue( "DGA003" ).ToString( );
                textBox15.Text = gridView1.GetFocusedRowCellValue(  "DGA011" ).ToString( );
                if (gridView1.GetFocusedRowCellValue(  "GS19" ).ToString( ) != "")
                {
                    datatimepickeroverride6.Value = Convert.ToDateTime( gridView1.GetFocusedRowCellValue(  "GS19" ).ToString( ) );
                }
                GS020= gridView1.GetFocusedRowCellValue( "GS20" ).ToString( );
                DGA03 = textBox11.Text;
                DGA01 = textBox15.Text;
                GS002 = comboBox3.Text;
                GS007 = comboBox6.Text;
            }
        }
        //显示行号
        private void gridView1_CustomDrawRowIndicator( object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e )
        {
            if (e.Info.IsRowIndicator && e.RowHandle>=0)
            {
                e.Info.DisplayText = (e.RowHandle+1).ToString( );
            }
        }
        //单元格合并
        private void gridView1_CellMerge( object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e )
        {
            //材质/工段  列名
            if (e.Column.FieldName == "材质/工段")
            {
                //GS02   字段名
                string str1 = gridView1.GetDataRow( e.RowHandle1 )["GS02"].ToString( );
                string str2 = gridView1.GetDataRow( e.RowHandle2 )["GS02"].ToString( );
                if (str1 == str2)
                {
                    e.Merge = true;
                    e.Handled = true;
                }
                else
                {
                    e.Merge = false;
                    e.Handled = true;
                }
            }
        }
        //计算字段
        private void gridView1_CustomColumnDisplayText( object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e )
        {
            //GS01 = textBox3.Text;
            //DataTable da = SqlHelper.ExecuteDataTable( "SELECT GS02,SUM(GS10*GS11) U7 FROM R_PQP WHERE GS01=@GS01 GROUP BY GS02", new SqlParameter( "@GS01", GS01 ) );
            //if (da != null && da.Rows.Count > 0)
            //{
            //    for (int i = 0; i < da.Rows.Count; i++)
            //    {
            //        for (int j = 0; j < gridView1.RowCount; j++)
            //        {
            //            if (da.Rows[i]["GS02"].ToString( ) == gridView1.GetDataRow( j )["GS02"].ToString( ))
            //            {
            //                //string X1 = da.Rows[i]["GS02"].ToString( );
            //                //string X2 = gridView1.GetDataRow( j )["GS02"].ToString( );
            //                //string X3 = da.Rows[i]["U7"].ToString( );
            //                U7.UnboundExpression = da.Rows[i]["U7"].ToString( );
            //                U7.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            //            }
            //        }
            //    }
            //}
        }
        //计划定价人
        private void button6_Click( object sender, EventArgs e )
        {
            if (textBox6.Text == "")
            {
                textBox6.Text = Logins.username;
            }
            else if (textBox6.Text != "")
            {
                textBox6.Text = "";
            }
        }
        //填表人
        private void button7_Click( object sender, EventArgs e )
        {
            if (textBox7.Text == "")
            {
                textBox7.Text = Logins.username;
            }
            else if (textBox7.Text != "")
            {
                textBox7.Text = "";
            }
        }
        //审核人
        private void button8_Click( object sender, EventArgs e )
        {
            if (textBox8.Text == "")
            {
                textBox8.Text = Logins.username;
            }
            else if (textBox8.Text != "")
            {
                textBox8.Text = "";
            }
        }
        //批准人
        private void button9_Click( object sender, EventArgs e )
        {
            if (textBox9.Text == "")
            {
                textBox9.Text = Logins.username;
            }
            else if (textBox9.Text != "")
            {
                textBox9.Text = "";
            }
        }
        //监督人
        private void button10_Click( object sender, EventArgs e )
        {
            if (textBox10.Text == "")
            {
                textBox10.Text = Logins.username;
            }
            else if (textBox10.Text != "")
            {
                textBox10.Text = "";
            }
        }
        //窗体关闭事件
        private void R_Frmchanpingaishan_FormClosing( object sender, FormClosingEventArgs e )
        {
            if (toolSave.Enabled)
            {
                MessageBox.Show( "请保存或取消" );
                e.Cancel = true;
            }
        }
        #endregion

        #region 主体
        string sads = "", weihu = "";
        string GS03 = "", GS22 = "", GS24 = "", GS26 = "", GS28 = "", GS30 = "", GS32 = "", GS33 = "";
        int GS31 = 0;
        DateTime GS29 = System.DateTime.Now, GS27 = System.DateTime.Now, GS25 = System.DateTime.Now, GS23 = System.DateTime.Now;
        //新增
        protected override void add( )
        {
            base.add( );

            Ergodic.FormEvery( this );
            gridControl1.DataSource = null;

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;

            Ergodic.FormGroupboxEnableTrue( this, gb );
            textBox16.Enabled = false;
            sads = "1";
        }
        //删除
        protected override void delete( )
        {
            base.delete( );

            GS01 = textBox3.Text;
            DataTable del = SqlHelper.ExecuteDataTable( "SELECT * FROM R_REVIEWS A,R_MLLCXMC B WHERE A.RES01=B.CX01 AND RES05='执行' AND RES06=@RES06 AND CX02=@CX02 ", new SqlParameter( "@RES06", GS01 ), new SqlParameter( "@CX02", this.Text ) );

            if (del != null && del.Rows.Count > 0)
            {
                MessageBox.Show( "流水号:" + GS01 + "的单据状态为执行,不允许删除" );
            }
            else
            {
                if (textBox3.Text == "")
                {
                    MessageBox.Show( "请查询需要删除的内容" );
                }
                else
                {
                    int count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQP WHERE GS01=@GS01", new SqlParameter( "@GS01", GS01 ) );
                    if (count < 1)
                    {
                        MessageBox.Show( "数据删除失败" );
                    }
                    else
                    {
                        MessageBox.Show( "数据删除成功" );

                        toolAdd.Enabled = true;
                        toolSelect.Enabled = true;
                        toolDelete.Enabled = false;
                        toolUpdate.Enabled = false;
                        toolReview.Enabled = false;
                        toolPrint.Enabled = false;
                        toolExport.Enabled = false;
                        toolMaintain.Enabled = false;
                        toolSave.Enabled = false;
                        toolCancel.Enabled = false;
                        button1.Enabled = false;
                        button2.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;
                        button5.Enabled = false;
                        button6.Enabled = false;
                        button7.Enabled = false;
                        button8.Enabled = false;
                        button9.Enabled = false;
                        button10.Enabled = false;

                        Ergodic.FormGroupboxEnableFalse( this, gb );

                        Ergodic.FormEvery( this );
                        gridControl1.DataSource = null;

                        textBox16.Enabled = false;

                        try
                        {
                            SqlHelper.ExecuteNonQuery( "DELETE FROM R_REVIEWS WHERE RES01=(SELECT CX01 FROM R_MLLCXMC WHERE CX02=@CX02) AND RES06=@RES06", new SqlParameter( "@CX02", this.Text ), new SqlParameter( "@RES06", GS01 ) );
                        }
                        catch { }
                    }
                }
            }
        }
        //更改
        protected override void update( )
        {
            base.update( );
          
            GS01 = textBox3.Text;
            DataTable del = SqlHelper.ExecuteDataTable( "SELECT * FROM R_REVIEWS A,R_MLLCXMC B WHERE A.RES01=B.CX01 AND RES05='执行' AND RES06=@RES06 AND CX02=@CX02 ", new SqlParameter( "@RES06", GS01 ), new SqlParameter( "@CX02", this.Text ) );
            if (del != null && del.Rows.Count > 0)
            {
                MessageBox.Show( "流水号:" + GS01 + "的单据状态为执行,不允许更改" );
            }
            else
            {
                toolAdd.Enabled = false;
                toolSelect.Enabled = false;
                toolDelete.Enabled = false;
                toolUpdate.Enabled = false;
                toolReview.Enabled = false;
                toolPrint.Enabled = false;
                toolExport.Enabled = false;
                toolMaintain.Enabled = false;
                toolSave.Enabled = true;
                toolCancel.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;

                Ergodic.FormGroupboxEnableTrue( this, gb );

                textBox16.Enabled = false;
            }
        }
        //送审
        protected override void revirw( )
        {
            base.revirw( );

            Reviews( "GS01", textBox3.Text, "R_PQP", this );
        }
        //打印
        protected override void print( )
        {
            base.print( );
        }
        //保存
        protected override void save( )
        {
            base.save( );

            if (textBox3.Text == "")
            {
                MessageBox.Show( "请选择流水号" );
            }
            else
            {
                if (!radioButton1.Checked && !radioButton2.Checked)
                {
                    MessageBox.Show( "请选择新单或者老单,不可不选" );
                }
                else
                {
                    if (radioButton1.Checked)
                    {
                        GS03 = radioButton1.Text;
                    }
                    else if (radioButton2.Checked)
                    {
                        GS03 = radioButton2.Text;
                    }
                    GS22 = textBox6.Text;
                    GS23 = datatimepickeroverride2.Value;
                    GS24 = textBox7.Text;
                    GS25 = datatimepickeroverride3.Value;
                    GS26 = textBox8.Text;
                    GS27 = datatimepickeroverride4.Value;
                    GS28 = textBox9.Text;
                    GS29 = datatimepickeroverride5.Value;
                    GS30 = textBox10.Text;
                    if (comboBox16.Text != "")
                    {
                        GS31 = Convert.ToInt32( comboBox16.Text );
                    }
                    GS32 = textBox16.Text;
                    GS33 = "";


                    DataTable das = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS01,GS33 FROM R_PQP WHERE GS01=@GS01", new SqlParameter( "@GS01", GS01 ) );

                    if (weihu == "1")
                    {
                        if (textBox16.Text == "")
                        {
                            MessageBox.Show( "请填写维护意见" );
                        }
                        else
                        {
                            if (das.Rows.Count < 1)
                            {
                                MessageBox.Show( "流水号:" + GS01 + "的数据不存在,请核实后再维护" );
                            }
                            else
                            {
                                GS33 = das.Rows[0]["GS33"].ToString( ) + "[" + Logins.username + System.DateTime.Now.ToString( "yyyyMMdd" ) + "]";
                                int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQP SET GS03=@GS03,GS22=@GS22,GS23=@GS23,GS24=@GS24,GS25=@GS25,GS26=@GS26,GS27=@GS27,GS28=@GS28,GS29=@GS29,GS30=@GS30,GS31=@GS31,GS32=@GS32,GS33=@GS33 WHERE GS01=@GS01", new SqlParameter( "@GS01", GS01 ), new SqlParameter( "@GS03", GS03 ), new SqlParameter( "@GS22", GS22 ), new SqlParameter( "@GS23", GS23 ), new SqlParameter( "@GS24", GS24 ), new SqlParameter( "@GS25", GS25 ), new SqlParameter( "@GS26", GS26 ), new SqlParameter( "@GS27", GS27 ), new SqlParameter( "@GS28", GS28 ), new SqlParameter( "@GS29", GS29 ), new SqlParameter( "@GS30", GS30 ), new SqlParameter( "@GS31", GS31 ), new SqlParameter( "@GS32", GS32 ), new SqlParameter( "@GS33", GS33 ) );
                                if (count < 1)
                                {
                                    MessageBox.Show( "录入数据失败" );
                                }
                                else
                                {
                                    MessageBox.Show( "成功录入数据" );
                                    toolAdd.Enabled = true;
                                    toolSelect.Enabled = true;
                                    toolDelete.Enabled = true;
                                    toolUpdate.Enabled = true;
                                    toolReview.Enabled = true;
                                    toolPrint.Enabled = true;
                                    toolExport.Enabled = true;
                                    toolMaintain.Enabled = true;
                                    toolSave.Enabled = false;
                                    toolCancel.Enabled = false;
                                    button1.Enabled = false;
                                    button2.Enabled = false;
                                    button3.Enabled = false;
                                    button4.Enabled = false;
                                    button5.Enabled = false;
                                    button6.Enabled = false;
                                    button7.Enabled = false;
                                    button8.Enabled = false;
                                    button9.Enabled = false;
                                    button10.Enabled = false;

                                    Ergodic.FormGroupboxEnableFalse( this, gb );

                                    textBox16.Enabled = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (das.Rows.Count < 1)
                        {
                            int count = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQP (GS01,GS03,GS22,GS23,GS24,GS25,GS26,GS27,GS28,GS29,GS30,GS31,GS32,GS33) VALUES (@GS01,@GS03,@GS22,@GS23,@GS24,@GS25,@GS26,@GS27,@GS28,@GS29,@GS30,@GS31,@GS32,@GS33)", new SqlParameter( "@GS01", GS01 ), new SqlParameter( "@GS03", GS03 ), new SqlParameter( "@GS22", GS22 ), new SqlParameter( "@GS23", GS23 ), new SqlParameter( "@GS24", GS24 ), new SqlParameter( "@GS25", GS25 ), new SqlParameter( "@GS26", GS26 ), new SqlParameter( "@GS27", GS27 ), new SqlParameter( "@GS28", GS28 ), new SqlParameter( "@GS29", GS29 ), new SqlParameter( "@GS30", GS30 ), new SqlParameter( "@GS31", GS31 ), new SqlParameter( "@GS32", GS32 ), new SqlParameter( "@GS33", GS33 ) );
                            if (count < 1)
                            {
                                MessageBox.Show( "录入数据失败" );
                            }
                            else
                            {
                                MessageBox.Show( "成功录入数据" );

                                toolAdd.Enabled = true;
                                toolSelect.Enabled = true;
                                toolDelete.Enabled = true;
                                toolUpdate.Enabled = true;
                                toolReview.Enabled = true;
                                toolPrint.Enabled = true;
                                toolExport.Enabled = true;
                                toolMaintain.Enabled = true;
                                toolSave.Enabled = false;
                                toolCancel.Enabled = false;
                                button1.Enabled = false;
                                button2.Enabled = false;
                                button3.Enabled = false;
                                button4.Enabled = false;
                                button5.Enabled = false;
                                button6.Enabled = false;
                                button7.Enabled = false;
                                button8.Enabled = false;
                                button9.Enabled = false;
                                button10.Enabled = false;

                                Ergodic.FormGroupboxEnableFalse( this, gb );

                                textBox16.Enabled = false;
                            }
                        }
                        else
                        {
                            int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQP SET GS03=@GS03,GS22=@GS22,GS23=@GS23,GS24=@GS24,GS25=@GS25,GS26=@GS26,GS27=@GS27,GS28=@GS28,GS29=@GS29,GS30=@GS30,GS31=@GS31,GS32=@GS32,GS33=@GS33 WHERE GS01=@GS01", new SqlParameter( "@GS01", GS01 ), new SqlParameter( "@GS03", GS03 ), new SqlParameter( "@GS22", GS22 ), new SqlParameter( "@GS23", GS23 ), new SqlParameter( "@GS24", GS24 ), new SqlParameter( "@GS25", GS25 ), new SqlParameter( "@GS26", GS26 ), new SqlParameter( "@GS27", GS27 ), new SqlParameter( "@GS28", GS28 ), new SqlParameter( "@GS29", GS29 ), new SqlParameter( "@GS30", GS30 ), new SqlParameter( "@GS31", GS31 ), new SqlParameter( "@GS32", GS32 ), new SqlParameter( "@GS33", GS33 ) );
                            if (count < 1)
                            {
                                MessageBox.Show( "录入数据失败" );
                            }
                            else
                            {
                                MessageBox.Show( "成功录入数据" );
                                toolAdd.Enabled = true;
                                toolSelect.Enabled = true;
                                toolDelete.Enabled = true;
                                toolUpdate.Enabled = true;
                                toolReview.Enabled = true;
                                toolPrint.Enabled = true;
                                toolExport.Enabled = true;
                                toolMaintain.Enabled = true;
                                toolSave.Enabled = false;
                                toolCancel.Enabled = false;
                                button1.Enabled = false;
                                button2.Enabled = false;
                                button3.Enabled = false;
                                button4.Enabled = false;
                                button5.Enabled = false;
                                button6.Enabled = false;
                                button7.Enabled = false;
                                button8.Enabled = false;
                                button9.Enabled = false;
                                button10.Enabled = false;

                                Ergodic.FormGroupboxEnableFalse( this, gb );

                                textBox16.Enabled = false;
                            }
                        }
                    }
                }
            }
        }
        //取消
        protected override void cancel( )
        {
            base.cancel( );
            if (sads == "1" && weihu!="1")
            {
                try
                {
                    SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQP WHERE GS01=@GS01", new SqlParameter( "@GS01", GS01 ) );
                }
                catch { }
                finally
                {
                    toolAdd.Enabled = true;
                    toolSelect.Enabled = true;
                    toolDelete.Enabled = false;
                    toolUpdate.Enabled = false;
                    toolReview.Enabled = false;
                    toolPrint.Enabled = true;
                    toolExport.Enabled = true;
                    toolMaintain.Enabled = false;
                    toolSave.Enabled = false;
                    toolCancel.Enabled = false;
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    button5.Enabled = false;
                    button6.Enabled = false;
                    button7.Enabled = false;
                    button8.Enabled = false;
                    button9.Enabled = false;
                    button10.Enabled = false;

                    Ergodic.FormGroupboxEnableFalse( this, gb );
                    textBox16.Enabled = false;
                }              
            }
            else if (sads == "2" || weihu=="1")
            {
                toolAdd.Enabled = true;
                toolSelect.Enabled = true;
                toolDelete.Enabled = true;
                toolUpdate.Enabled = true;
                toolReview.Enabled = true;
                toolPrint.Enabled = true;
                toolExport.Enabled = true;
                toolMaintain.Enabled = true;
                toolSave.Enabled = false;
                toolCancel.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button10.Enabled = false;

                Ergodic.FormGroupboxEnableFalse( this, gb );
                textBox16.Enabled = false;
            }
        }
        //维护
        protected override void maintain( )
        {
            base.maintain( );

            GS01 = textBox3.Text;
            DataTable del = SqlHelper.ExecuteDataTable( "SELECT RES03,RES05,RES06,DBA012,CX02 FROM TPADBA A,R_REVIEW B,R_REVIEWS C,R_MLLCXMC D WHERE A.DBA001=B.RE01 AND B.RE01=C.RES03 AND C.RES01=D.CX01 AND RES06=@RES06 AND CX02=@CX02", new SqlParameter( "@RES06", GS01 ), new SqlParameter( "@CX02", this.Text ) );
            if (del != null && del.Rows.Count > 0)
            {
                if (del.Select( "RES05='执行'" ).Length > 0)
                {
                    toolAdd.Enabled = false;
                    toolSelect.Enabled = false;
                    toolDelete.Enabled = false;
                    toolUpdate.Enabled = false;
                    toolReview.Enabled = false;
                    toolPrint.Enabled = false;
                    toolExport.Enabled = false;
                    toolMaintain.Enabled = false;
                    toolSave.Enabled = true;
                    toolCancel.Enabled = true;
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    button5.Enabled = true;
                    button6.Enabled = false;
                    button7.Enabled = false;
                    button8.Enabled = false;
                    button9.Enabled = false;
                    button10.Enabled = false;

                    Ergodic.FormGroupboxEnableTrue( this, gb );

                    weihu = "1";

                    textBox16.Enabled = true;
                }
                else
                {
                    MessageBox.Show( "此单据没有被执行,只需更改即可,无需维护" );
                }
            }
            else
            {
                MessageBox.Show( "此单据没有被执行,只需更改即可,无需维护" );
            }
        }
        #endregion

        #region 表格
        string GS2 ="",GS7 = "", GS8 = "", GS9 = "", GS014 = "", GS015 = "", GS016 = "", GS017 = "", GS018 = "", DGA3 = "", DGA11 = "";
        decimal GS4 = 0M, GS5 = 0M, GS6 = 0M, GS011 = 0M;
        int GS010 = 0, GS013 = 0;
        long PQF6 = 0;
        DateTime GS019 = System.DateTime.Now;
        DataTable dde;
        //新建
        private void button1_Click( object sender, EventArgs e )
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show( "请选择流水号" );
            }
            else
            {
                if (comboBox3.Text == "")
                {
                    MessageBox.Show( "请填写材质" );
                }
                else
                {
                    if (comboBox6.Text == "")
                    {
                        MessageBox.Show( "请填写零件名称" );
                    }
                    else
                    {
                        if (GS020 == "")
                        {
                            MessageBox.Show( "请选择供应商" );
                        }
                        else
                        {
                            GS01 = textBox3.Text;
                            GS2 = comboBox3.Text;
                            if (comboBox1.Text != "")
                            {
                                GS4 = Convert.ToDecimal( comboBox1.Text );
                            }
                            else
                            {
                                GS4 = 0M;
                            }
                            if (comboBox4.Text != "")
                            {
                                GS5 = Convert.ToDecimal( comboBox4.Text );
                            }
                            else
                            {
                                GS5 = 0M;
                            }
                            if (comboBox10.Text != "")
                            {
                                GS013 = Convert.ToInt32( comboBox10.Text );
                            }
                            else
                            {
                                GS013 = 0;
                            }
                            GS016 = comboBox11.Text;
                            GS019 = datatimepickeroverride6.Value;
                            GS7 = comboBox6.Text;
                            GS8 = comboBox7.Text;
                            if (comboBox2.Text != "")
                            {
                                GS010 = Convert.ToInt32( comboBox2.Text );
                            }
                            else
                            {
                                GS010 = 0;
                            }
                            if (comboBox9.Text != "")
                            {
                                GS011 = Convert.ToDecimal( comboBox9.Text );
                            }
                            else
                            {
                                GS011 = 0M;
                            }
                            GS9 = comboBox8.Text;
                            GS017 = comboBox12.Text;
                            DGA3 = textBox11.Text;
                            GS014 = textBox13.Text;
                            GS015 = textBox14.Text;
                            GS018 = comboBox13.Text;
                            DGA11 = textBox15.Text;
                            if (textBox4.Text != "")
                            {
                                PQF6 = Convert.ToInt64( textBox4.Text );
                            }
                            else
                            {
                                PQF6 = 0;
                            }

                            DataTable dsr = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQP WHERE GS01=@GS01 AND GS02=@GS02 AND GS07=@GS07 AND GS20=@GS20", new SqlParameter( "@GS01", GS01 ), new SqlParameter( "@GS02", GS2 ), new SqlParameter( "@GS07", GS7 ), new SqlParameter( "@GS20", GS020 ) );
                            if (dsr.Rows.Count < 1)
                            {
                                int count = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQP (GS01,GS02,GS04,GS05,GS07,GS08,GS09,GS10,GS11,GS13,GS14,GS15,GS16,GS17,GS18,GS19,GS20) VALUES (@GS01,@GS02,@GS04,@GS05,@GS07,@GS08,@GS09,@GS10,@GS11,@GS13,@GS14,@GS15,@GS16,@GS17,@GS18,@GS19,@GS20)", new SqlParameter( "@GS01", GS01 ), new SqlParameter( "@GS02", GS2 ), new SqlParameter( "@GS04", GS4 ), new SqlParameter( "@GS05", GS5 ),  new SqlParameter( "@GS07", GS7 ), new SqlParameter( "@GS08", GS8 ), new SqlParameter( "@GS09", GS9 ), new SqlParameter( "@GS10", GS010 ), new SqlParameter( "@GS11", GS011 ), new SqlParameter( "@GS13", GS013 ), new SqlParameter( "@GS14", GS014 ), new SqlParameter( "@GS15", GS015 ), new SqlParameter( "@GS16", GS016 ), new SqlParameter( "@GS17", GS017 ), new SqlParameter( "@GS18", GS018 ), new SqlParameter( "@GS19", GS019 ), new SqlParameter( "@GS20", GS020 ) );
                                if (count < 1)
                                {
                                    MessageBox.Show( "录入数据失败" );
                                }
                                else
                                {
                                    MessageBox.Show( "成功录入数据" );
                                    DataRow row;
                                    if (sads == "1")
                                    {
                                        dde = SqlHelper.ExecuteDataTable( "SELECT GS02,PQF06,GS04,GS05,GS07,GS08,GS09,GS10,GS11,GS13,GS14,GS15,GS16,GS17,GS18,GS19,GS20,DGA003,DGA011,D.U7 FROM R_PQP A, TPADGA B, R_PQF C, (SELECT GS02 U0, SUM( GS10 * GS11 ) U7 FROM R_PQP GROUP BY GS02 ) D WHERE A.GS20 = B.DGA001 AND A.GS01 = C.PQF01 AND A.GS02 = D.U0 AND GS01=@GS01 ORDER BY GS02", new SqlParameter( "@GS01", GS01 ) );
                                    gridControl1.DataSource = dde;
                                    }
                                    else if (sads == "2")
                                    {
                                        row = ddl.NewRow( );
                                        row["GS02"] = GS2;
                                        row["PQF06"] = PQF6;
                                        row["GS04"] = GS4;
                                        row["GS05"] = GS5;
                                        row["GS07"] = GS7;
                                        row["GS08"] = GS8;
                                        row["GS09"] = GS9;
                                        row["GS10"] = GS010;
                                        row["GS11"] = GS011;
                                        row["GS13"] = GS013;
                                        row["GS14"] = GS014;
                                        row["GS15"] = GS015;
                                        row["GS16"] = GS016;
                                        row["GS17"] = GS017;
                                        row["GS18"] = GS018;
                                        row["GS19"] = GS019;
                                        row["DGA003"] = DGA3;
                                        row["DGA011"] = DGA11;
                                        ddl.Rows.Add( row );
                                    }

                                    #region
                                    DataTable bg = SqlHelper.ExecuteDataTable( "SELECT GS02,GS04,GS05,GS06,GS07,GS08,GS09,GS10,GS11,GS13,GS14,GS15,GS16,GS17,GS18,GS19 FROM R_PQP" );
                                    //材质
                                    DataTable cz = bg.DefaultView.ToTable( true, "GS02" );
                                    //DataTable cz = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS02 FROM R_PQP" );
                                    comboBox3.DataSource = cz;
                                    comboBox3.DisplayMember = "GS02";
                                    //原单价
                                    DataTable dj = bg.DefaultView.ToTable( true, "GS04" );
                                    //DataTable dj = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS04 FROM R_PQP" );
                                    comboBox1.DataSource = dj;
                                    comboBox1.DisplayMember = "GS04";
                                    //计划下降差价
                                    DataTable jxc = bg.DefaultView.ToTable( true, "GS05" );
                                    //DataTable jxc = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS05 FROM R_PQP" );
                                    comboBox4.DataSource = jxc;
                                    comboBox4.DisplayMember = "GS05";
                                    //提成
                                    DataTable tc = bg.DefaultView.ToTable( true, "GS13" );
                                    //DataTable tc = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS13 FROM R_PQP" );
                                    comboBox10.DataSource = tc;
                                    comboBox10.DisplayMember = "GS13";
                                    //零件名称
                                    DataTable ljmc = bg.DefaultView.ToTable( true, "GS07" );
                                    //DataTable ljmc = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS07 FROM R_PQP" );
                                    comboBox6.DataSource = ljmc;
                                    comboBox6.DisplayMember = "GS07";
                                    //规格
                                    DataTable gg = bg.DefaultView.ToTable( true, "GS08" );
                                    //DataTable gg = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS08 FROM R_PQP" );
                                    comboBox7.DataSource = gg;
                                    comboBox7.DisplayMember = "GS08";
                                    //单位
                                    DataTable dw = bg.DefaultView.ToTable( true, "GS09" );
                                    comboBox8.DataSource = dw;
                                    comboBox8.DisplayMember = "GS09";
                                    //每套零件数量
                                    DataTable mls = bg.DefaultView.ToTable( true, "GS10" );
                                    comboBox2.DataSource = mls;
                                    comboBox2.DisplayMember = "GS10";
                                    //采购零件单价
                                    DataTable cld = bg.DefaultView.ToTable( true, "GS11" );
                                    comboBox9.DataSource = cld;
                                    comboBox9.DisplayMember = "GS11";
                                    #endregion
                                }
                            }
                            else
                            {
                                MessageBox.Show( "流水号：" + GS01 + "\n\r材质/工段：" + GS2 + "\n\r零件名称：" + GS7 + "\n\r供应商：" + DGA3 + "\n\r的数据已经存在,请核实后再录入" );
                            }
                        }
                    }
                }
            }
        }
        //编辑
        private void button2_Click( object sender, EventArgs e )
        {
            int num = gridView1.FocusedRowHandle;
            if (textBox3.Text == "")
            {
                MessageBox.Show( "请选择流水号" );
            }
            else
            {
                if (comboBox3.Text == "")
                {
                    MessageBox.Show( "请填写材质" );
                }
                else
                {
                    if (comboBox6.Text == "")
                    {
                        MessageBox.Show( "请填写零件名称" );
                    }
                    else
                    {
                        if (GS020 == "")
                        {
                            MessageBox.Show( "请选择供应商信息" );
                        }
                        else
                        {
                            GS01 = textBox3.Text;
                            GS2 = comboBox3.Text;
                            if (comboBox1.Text != "")
                            {
                                GS4 = Convert.ToDecimal( comboBox1.Text );
                            }
                            else
                            {
                                GS4 = 0M;
                            }
                            if (comboBox4.Text != "")
                            {
                                GS5 = Convert.ToDecimal( comboBox4.Text );
                            }
                            else
                            {
                                GS5 = 0M;
                            }
                            if (comboBox10.Text != "")
                            {
                                GS013 = Convert.ToInt32( comboBox10.Text );
                            }
                            else
                            {
                                GS013 = 0;
                            }
                            GS016 = comboBox11.Text;
                            GS019 = datatimepickeroverride6.Value;
                            GS7 = comboBox6.Text;
                            GS8 = comboBox7.Text;
                            if (comboBox2.Text != "")
                            {
                                GS010 = Convert.ToInt32( comboBox2.Text );
                            }
                            else
                            {
                                GS010 = 0;
                            }
                            if (comboBox9.Text != "")
                            {
                                GS011 = Convert.ToDecimal( comboBox9.Text );
                            }
                            else
                            {
                                GS011 = 0M;
                            }
                            GS9 = comboBox8.Text;
                            GS017 = comboBox12.Text;
                            DGA3 = textBox11.Text;
                            GS014 = textBox13.Text;
                            GS015 = textBox14.Text;
                            GS018 = comboBox13.Text;
                            DGA11 = textBox15.Text;
                            if (textBox4.Text != "")
                            {
                                PQF6 = Convert.ToInt64( textBox4.Text );
                            }
                            else
                            {
                                PQF6 = 0;
                            }

                            if (GS2 == GS002 && GS7 == GS007)
                            {
                                int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQP SET GS04=@GS04,GS05=@GS05,GS08=@GS08,GS09=@GS09,GS10=@GS10,GS11=@GS11,GS13=@GS13,GS14=@GS14,GS15=@GS15,GS16=@GS16,GS17=@GS17,GS18=@GS18,GS19=@GS19,GS20=@GS20 WHERE GS01=@GS01 AND GS02=@GS2 AND GS07=@GS7", new SqlParameter( "@GS01", GS01 ), new SqlParameter( "@GS02", GS2 ), new SqlParameter( "@GS04", GS4 ), new SqlParameter( "@GS05", GS5 ), new SqlParameter( "@GS07", GS7 ), new SqlParameter( "@GS08", GS8 ), new SqlParameter( "@GS09", GS9 ), new SqlParameter( "@GS10", GS010 ), new SqlParameter( "@GS11", GS011 ), new SqlParameter( "@GS13", GS013 ), new SqlParameter( "@GS14", GS014 ), new SqlParameter( "@GS15", GS015 ), new SqlParameter( "@GS16", GS016 ), new SqlParameter( "@GS17", GS017 ), new SqlParameter( "@GS18", GS018 ), new SqlParameter( "@GS19", GS019 ), new SqlParameter( "@GS20", GS020 ), new SqlParameter( "@GS2", GS002 ), new SqlParameter( "@GS7", GS007 ) );
                                if (count < 1)
                                {
                                    MessageBox.Show( "编辑数据失败" );
                                }
                                else
                                {
                                    MessageBox.Show( "成功编辑数据" );

                                    DataRow row;
                                    if (sads == "1")
                                    {
                                        row = dde.Rows[num];
                                        row.BeginEdit( );
                                        row["GS02"] = GS2;
                                        row["PQF06"] = PQF6;
                                        row["GS04"] = GS4;
                                        row["GS05"] = GS5;
                                        row["GS07"] = GS7;
                                        row["GS08"] = GS8;
                                        row["GS09"] = GS9;
                                        row["GS10"] = GS010;
                                        row["GS11"] = GS011;
                                        row["GS13"] = GS013;
                                        row["GS14"] = GS014;
                                        row["GS15"] = GS015;
                                        row["GS16"] = GS016;
                                        row["GS17"] = GS017;
                                        row["GS18"] = GS018;
                                        row["GS19"] = GS019;
                                        row["DGA003"] = DGA3;
                                        row["DGA011"] = DGA11;
                                        row.EndEdit( );
                                    }
                                    else if (sads == "2")
                                    {
                                        row = ddl.Rows[num];
                                        row.BeginEdit( );
                                        row["GS02"] = GS2;
                                        row["PQF06"] = PQF6;
                                        row["GS04"] = GS4;
                                        row["GS05"] = GS5;
                                        row["GS07"] = GS7;
                                        row["GS08"] = GS8;
                                        row["GS09"] = GS9;
                                        row["GS10"] = GS010;
                                        row["GS11"] = GS011;
                                        row["GS13"] = GS013;
                                        row["GS14"] = GS014;
                                        row["GS15"] = GS015;
                                        row["GS16"] = GS016;
                                        row["GS17"] = GS017;
                                        row["GS18"] = GS018;
                                        row["GS19"] = GS019;
                                        row["DGA003"] = DGA3;
                                        row["DGA011"] = DGA11;
                                        row.EndEdit( );
                                    }
                                    #region
                                    DataTable bg = SqlHelper.ExecuteDataTable( "SELECT GS02,GS04,GS05,GS06,GS07,GS08,GS09,GS10,GS11,GS13,GS14,GS15,GS16,GS17,GS18,GS19 FROM R_PQP" );
                                    //材质
                                    DataTable cz = bg.DefaultView.ToTable( true, "GS02" );
                                    //DataTable cz = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS02 FROM R_PQP" );
                                    comboBox3.DataSource = cz;
                                    comboBox3.DisplayMember = "GS02";
                                    //原单价
                                    DataTable dj = bg.DefaultView.ToTable( true, "GS04" );
                                    //DataTable dj = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS04 FROM R_PQP" );
                                    comboBox1.DataSource = dj;
                                    comboBox1.DisplayMember = "GS04";
                                    //计划下降差价
                                    DataTable jxc = bg.DefaultView.ToTable( true, "GS05" );
                                    //DataTable jxc = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS05 FROM R_PQP" );
                                    comboBox4.DataSource = jxc;
                                    comboBox4.DisplayMember = "GS05";
                                    //提成
                                    DataTable tc = bg.DefaultView.ToTable( true, "GS13" );
                                    //DataTable tc = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS13 FROM R_PQP" );
                                    comboBox10.DataSource = tc;
                                    comboBox10.DisplayMember = "GS13";
                                    //零件名称
                                    DataTable ljmc = bg.DefaultView.ToTable( true, "GS07" );
                                    //DataTable ljmc = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS07 FROM R_PQP" );
                                    comboBox6.DataSource = ljmc;
                                    comboBox6.DisplayMember = "GS07";
                                    //规格
                                    DataTable gg = bg.DefaultView.ToTable( true, "GS08" );
                                    //DataTable gg = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS08 FROM R_PQP" );
                                    comboBox7.DataSource = gg;
                                    comboBox7.DisplayMember = "GS08";
                                    //单位
                                    DataTable dw = bg.DefaultView.ToTable( true, "GS09" );
                                    comboBox8.DataSource = dw;
                                    comboBox8.DisplayMember = "GS09";
                                    //每套零件数量
                                    DataTable mls = bg.DefaultView.ToTable( true, "GS10" );
                                    comboBox2.DataSource = mls;
                                    comboBox2.DisplayMember = "GS10";
                                    //采购零件单价
                                    DataTable cld = bg.DefaultView.ToTable( true, "GS11" );
                                    comboBox9.DataSource = cld;
                                    comboBox9.DisplayMember = "GS11";
                                    #endregion
                                }
                            }
                            else
                            {
                                DataTable de = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQP WHERE GS01=@GS01 AND GS02=@GS02 AND GS07=@GS07 AND GS20=@GS20", new SqlParameter( "GS01", GS01 ), new SqlParameter( "@GS02", GS2 ), new SqlParameter( "@GS07", GS7 ), new SqlParameter( "@GS20", GS020 ) );
                                if (de.Rows.Count > 0)
                                {
                                    MessageBox.Show( "流水号：" + GS01 + "\n\r材质/工段：" + GS2 + "\n\r零件名称：" + GS7 + "\n\r供应商：" + DGA3 + "\n\r的数据已经存在,请核实后再录入" );
                                }
                                else
                                {
                                    int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQP SET GS02=@GS02,GS04=@GS04,GS05=@GS05,GS07=@GS07,GS08=@GS08,GS09=@GS09,GS10=@GS10,GS11=@GS11,GS13=@GS13,GS14=@GS14,GS15=@GS15,GS16=@GS16,GS17=@GS17,GS18=@GS18,GS19=@GS19,GS20=@GS20 WHERE GS01=@GS01 AND GS02=@GS2 AND GS07=@GS7", new SqlParameter( "@GS01", GS01 ), new SqlParameter( "@GS02", GS2 ), new SqlParameter( "@GS04", GS4 ), new SqlParameter( "@GS05", GS5 ), new SqlParameter( "@GS07", GS7 ), new SqlParameter( "@GS08", GS8 ), new SqlParameter( "@GS09", GS9 ), new SqlParameter( "@GS10", GS010 ), new SqlParameter( "@GS11", GS011 ), new SqlParameter( "@GS13", GS013 ), new SqlParameter( "@GS14", GS014 ), new SqlParameter( "@GS15", GS015 ), new SqlParameter( "@GS16", GS016 ), new SqlParameter( "@GS17", GS017 ), new SqlParameter( "@GS18", GS018 ), new SqlParameter( "@GS19", GS019 ), new SqlParameter( "@GS20", GS020 ), new SqlParameter( "@GS2", GS002 ), new SqlParameter( "@GS7", GS007 ) );
                                    if (count < 1)
                                    {
                                        MessageBox.Show( "编辑数据失败" );
                                    }
                                    else
                                    {
                                        MessageBox.Show( "成功编辑数据" );

                                        DataRow row;
                                        if (sads == "1")
                                        {
                                            row = dde.Rows[num];
                                            row.BeginEdit( );
                                            row["GS02"] = GS2;
                                            row["PQF06"] = PQF6;
                                            row["GS04"] = GS4;
                                            row["GS05"] = GS5;
                                            row["GS07"] = GS7;
                                            row["GS08"] = GS8;
                                            row["GS09"] = GS9;
                                            row["GS10"] = GS010;
                                            row["GS11"] = GS011;
                                            row["GS13"] = GS013;
                                            row["GS14"] = GS014;
                                            row["GS15"] = GS015;
                                            row["GS16"] = GS016;
                                            row["GS17"] = GS017;
                                            row["GS18"] = GS018;
                                            row["GS19"] = GS019;
                                            row["DGA003"] = DGA3;
                                            row["DGA011"] = DGA11;
                                            row.EndEdit( );
                                        }
                                        else if (sads == "2")
                                        {
                                            row = ddl.Rows[num];
                                            row.BeginEdit( );
                                            row["GS02"] = GS2;
                                            row["PQF06"] = PQF6;
                                            row["GS04"] = GS4;
                                            row["GS05"] = GS5;
                                            row["GS07"] = GS7;
                                            row["GS08"] = GS8;
                                            row["GS09"] = GS9;
                                            row["GS10"] = GS010;
                                            row["GS11"] = GS011;
                                            row["GS13"] = GS013;
                                            row["GS14"] = GS014;
                                            row["GS15"] = GS015;
                                            row["GS16"] = GS016;
                                            row["GS17"] = GS017;
                                            row["GS18"] = GS018;
                                            row["GS19"] = GS019;
                                            row["DGA003"] = DGA3;
                                            row["DGA011"] = DGA11;
                                            row.EndEdit( );
                                        }
                                        #region
                                        DataTable bg = SqlHelper.ExecuteDataTable( "SELECT GS02,GS04,GS05,GS06,GS07,GS08,GS09,GS10,GS11,GS13,GS14,GS15,GS16,GS17,GS18,GS19 FROM R_PQP" );
                                        //材质
                                        DataTable cz = bg.DefaultView.ToTable( true, "GS02" );
                                        //DataTable cz = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS02 FROM R_PQP" );
                                        comboBox3.DataSource = cz;
                                        comboBox3.DisplayMember = "GS02";
                                        //原单价
                                        DataTable dj = bg.DefaultView.ToTable( true, "GS04" );
                                        //DataTable dj = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS04 FROM R_PQP" );
                                        comboBox1.DataSource = dj;
                                        comboBox1.DisplayMember = "GS04";
                                        //计划下降差价
                                        DataTable jxc = bg.DefaultView.ToTable( true, "GS05" );
                                        //DataTable jxc = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS05 FROM R_PQP" );
                                        comboBox4.DataSource = jxc;
                                        comboBox4.DisplayMember = "GS05";
                                        //提成
                                        DataTable tc = bg.DefaultView.ToTable( true, "GS13" );
                                        //DataTable tc = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS13 FROM R_PQP" );
                                        comboBox10.DataSource = tc;
                                        comboBox10.DisplayMember = "GS13";
                                        //零件名称
                                        DataTable ljmc = bg.DefaultView.ToTable( true, "GS07" );
                                        //DataTable ljmc = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS07 FROM R_PQP" );
                                        comboBox6.DataSource = ljmc;
                                        comboBox6.DisplayMember = "GS07";
                                        //规格
                                        DataTable gg = bg.DefaultView.ToTable( true, "GS08" );
                                        //DataTable gg = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS08 FROM R_PQP" );
                                        comboBox7.DataSource = gg;
                                        comboBox7.DisplayMember = "GS08";
                                        //单位
                                        DataTable dw = bg.DefaultView.ToTable( true, "GS09" );
                                        comboBox8.DataSource = dw;
                                        comboBox8.DisplayMember = "GS09";
                                        //每套零件数量
                                        DataTable mls = bg.DefaultView.ToTable( true, "GS10" );
                                        comboBox2.DataSource = mls;
                                        comboBox2.DisplayMember = "GS10";
                                        //采购零件单价
                                        DataTable cld = bg.DefaultView.ToTable( true, "GS11" );
                                        comboBox9.DataSource = cld;
                                        comboBox9.DisplayMember = "GS11";
                                        #endregion
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        //删除
        private void button3_Click( object sender, EventArgs e )
        {
            int num = gridView1.FocusedRowHandle;
            if (textBox3.Text == "")
            {
                MessageBox.Show( "请选择流水号" );
            }
            else
            {
                if (comboBox3.Text == "")
                {
                    MessageBox.Show( "请填写材质" );
                }
                else
                {
                    if (comboBox6.Text == "")
                    {
                        MessageBox.Show( "请填写零件名称" );
                    }
                    else
                    {
                        if (GS020 == "")
                        {
                            MessageBox.Show( "请选择供应商信息" );
                        }
                        else
                        {
                            int count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQP WHERE GS01=@GS01 AND GS02=@GS02 AND GS07=@GS07 AND GS20=@GS20", new SqlParameter( "GS01", GS01 ), new SqlParameter( "@GS02", GS002 ), new SqlParameter( "@GS07", GS007 ), new SqlParameter( "@GS20", GS020 ) );
                            if (count < 1)
                            {
                                MessageBox.Show( "删除数据失败" );
                            }
                            else
                            {
                                MessageBox.Show( "成功删除数据" );

                                if (sads == "1")
                                {
                                    dde.Rows.RemoveAt( num );
                                }
                                else if (sads == "2")
                                {
                                    ddl.Rows.RemoveAt( num );
                                }
                                #region
                                DataTable bg = SqlHelper.ExecuteDataTable( "SELECT GS02,GS04,GS05,GS06,GS07,GS08,GS09,GS10,GS11,GS13,GS14,GS15,GS16,GS17,GS18,GS19 FROM R_PQP" );
                                //材质
                                DataTable cz = bg.DefaultView.ToTable( true, "GS02" );
                                //DataTable cz = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS02 FROM R_PQP" );
                                comboBox3.DataSource = cz;
                                comboBox3.DisplayMember = "GS02";
                                //原单价
                                DataTable dj = bg.DefaultView.ToTable( true, "GS04" );
                                //DataTable dj = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS04 FROM R_PQP" );
                                comboBox1.DataSource = dj;
                                comboBox1.DisplayMember = "GS04";
                                //计划下降差价
                                DataTable jxc = bg.DefaultView.ToTable( true, "GS05" );
                                //DataTable jxc = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS05 FROM R_PQP" );
                                comboBox4.DataSource = jxc;
                                comboBox4.DisplayMember = "GS05";
                                //提成
                                DataTable tc = bg.DefaultView.ToTable( true, "GS13" );
                                //DataTable tc = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS13 FROM R_PQP" );
                                comboBox10.DataSource = tc;
                                comboBox10.DisplayMember = "GS13";
                                //零件名称
                                DataTable ljmc = bg.DefaultView.ToTable( true, "GS07" );
                                //DataTable ljmc = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS07 FROM R_PQP" );
                                comboBox6.DataSource = ljmc;
                                comboBox6.DisplayMember = "GS07";
                                //规格
                                DataTable gg = bg.DefaultView.ToTable( true, "GS08" );
                                //DataTable gg = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS08 FROM R_PQP" );
                                comboBox7.DataSource = gg;
                                comboBox7.DisplayMember = "GS08";
                                //单位
                                DataTable dw = bg.DefaultView.ToTable( true, "GS09" );
                                comboBox8.DataSource = dw;
                                comboBox8.DisplayMember = "GS09";
                                //每套零件数量
                                DataTable mls = bg.DefaultView.ToTable( true, "GS10" );
                                comboBox2.DataSource = mls;
                                comboBox2.DisplayMember = "GS10";
                                //采购零件单价
                                DataTable cld = bg.DefaultView.ToTable( true, "GS11" );
                                comboBox9.DataSource = cld;
                                comboBox9.DisplayMember = "GS11";
                                #endregion
                            }
                        }
                    }
                }
            }
        }
        //刷新
        private void button11_Click( object sender, EventArgs e )
        {
            GS01 = textBox3.Text;
            if (sads == "1")
            {
                dde = SqlHelper.ExecuteDataTable( "SELECT GS02,PQF06,GS04,GS05,GS07,GS08,GS09,GS10,GS11,GS13,GS14,GS15,GS16,GS17,GS18,GS19,GS20,DGA003,DGA011,D.U7 FROM R_PQP A, TPADGA B, R_PQF C, (SELECT GS02 U0, SUM( GS10 * GS11 ) U7 FROM R_PQP GROUP BY GS02 ) D WHERE A.GS20 = B.DGA001 AND A.GS01 = C.PQF01 AND A.GS02 = D.U0 AND GS01=@GS01 ORDER BY GS02", new SqlParameter( "@GS01", GS01 ) );
                gridControl1.DataSource = dde;
            }
            else if (sads == "2")
            {
                ddl = SqlHelper.ExecuteDataTable( "SELECT GS02,PQF06,GS04,GS05,GS07,GS08,GS09,GS10,GS11,GS13,GS14,GS15,GS16,GS17,GS18,GS19,GS20,DGA003,DGA011,D.U7 FROM R_PQP A, TPADGA B, R_PQF C, (SELECT GS02 U0, SUM( GS10 * GS11 ) U7 FROM R_PQP GROUP BY GS02 ) D WHERE A.GS20 = B.DGA001 AND A.GS01 = C.PQF01 AND A.GS02 = D.U0 AND GS01=@GS01 ORDER BY GS02", new SqlParameter( "@GS01", GS01 ) );
                gridControl1.DataSource = ddl;
            }
        }
        #endregion
    }
}

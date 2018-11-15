using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mulaolao.Other;
using Mulaolao.Procedure;
using StudentMgr;
using System.Data.SqlClient;
using Mulaolao.Class;

namespace Mulaolao.Environmental
{
    public partial class R_Frmhegexianchang : Form
    {
        public R_Frmhegexianchang(Form1 fm)
        {
            this.MdiParent = fm;
            InitializeComponent();
        }
        R_FrmContractreviewb conb = new R_FrmContractreviewb();
        string bianhao;
        string HF01="",HF02 = "", HF03 = "", HF04 = "", HF05 = "", HF06 = "", HF07 = "", HG02 = "", HG03 = "", HG04 = "";

        private void toolReview_Click( object sender, EventArgs e )
        {

        }

        private void R_Frmhegexianchang_Load(object sender, EventArgs e)
        {
            List<string> li = new List<string>() { "合格","不合格","待整改"};
            foreach (string st in li)
            {
                comboBox2.Items.Add(st);
                comboBox3.Items.Add(st);
                comboBox4.Items.Add(st);
                comboBox5.Items.Add(st);
                comboBox6.Items.Add(st);
                comboBox7.Items.Add(st);
                comboBox8.Items.Add(st);
                comboBox9.Items.Add(st);
                comboBox10.Items.Add(st);
                comboBox11.Items.Add(st);
                comboBox12.Items.Add(st);
                comboBox13.Items.Add(st);
                comboBox14.Items.Add(st);
                comboBox15.Items.Add(st);
                comboBox16.Items.Add(st);
                comboBox17.Items.Add(st);
            }
        }

        private void toolUpdate_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("请查询需要更改的信息");
            }
            else
            {
                DataTable dta = SqlHelper.ExecuteDataTable("SELECT DGA008,DGA011,DGA013,DGA015,DGA017 FROM TPADGA WHERE DGA001=@dga001", new SqlParameter("@DGA001", bianhao));
                textBox5.Text = dta.Rows[0]["DGA008"].ToString();
                textBox6.Text = dta.Rows[0]["DGA017"].ToString();
                textBox7.Text = dta.Rows[0]["DGA011"].ToString();
                textBox8.Text = dta.Rows[0]["DGA013"].ToString();
                textBox9.Text = dta.Rows[0]["DGA015"].ToString();

                HF01 = bianhao;
                HF02 = textBox1.Text;
                HF03 = textBox2.Text;
                HF04 = textBox3.Text;
                HF05 = datatimepickeroverride1.Text;
                HF06 = comboBox17.Text;
                HF07 = textBox25.Text;
                SqlHelper.ExecuteNonQuery("UPDATE R_HGGFXCPGBG SET HF02=@HF02,HF03=@HF03,HF04=@HF04,HF05=@HF05,HF06=@HF06,HF07=@HF07 WHERE HF01=@HF01", new SqlParameter("@HF01", HF01), new SqlParameter("@HF02", HF02), new SqlParameter("@HF03", HF03), new SqlParameter("@HF04", HF04), new SqlParameter("@HF05", HF05), new SqlParameter("@HF06", HF06), new SqlParameter("@HF07", HF07));


                if (label14.Text == "工厂占地面积（m2）")
                {
                    HG02 = label14.Text;
                    HG03 = textBox10.Text;
                    HG04 = comboBox2.Text;
                    SqlHelper.ExecuteNonQuery("UPDATE R_HGGFXCPGBGA SET HG02=@HG02,HG03=@HG03,HG04=@HG04 WHERE HG01=@HG01", new SqlParameter("@HG01", HF01), new SqlParameter("@HG02", HG02), new SqlParameter("@HG03", HG03), new SqlParameter("@HG04", HG04));
                }
                if (label15.Text == "使用建筑面积（m2）")
                {
                    HG02 = label15.Text;
                    HG03 = textBox11.Text;
                    HG04 = comboBox3.Text;
                    SqlHelper.ExecuteNonQuery("UPDATE R_HGGFXCPGBGA SET HG02=@HG02,HG03=@HG03,HG04=@HG04 WHERE HG01=@HG01", new SqlParameter("@HG01", HF01), new SqlParameter("@HG02", HG02), new SqlParameter("@HG03", HG03), new SqlParameter("@HG04", HG04));
                }
                if (label16.Text == "工厂人数")
                {
                    HG02 = label16.Text;
                    HG03 = textBox12.Text;
                    HG04 = comboBox4.Text;
                    SqlHelper.ExecuteNonQuery("UPDATE R_HGGFXCPGBGA SET HG02=@HG02,HG03=@HG03,HG04=@HG04 WHERE HG01=@HG01", new SqlParameter("@HG01", HF01), new SqlParameter("@HG02", HG02), new SqlParameter("@HG03", HG03), new SqlParameter("@HG04", HG04));
                }
                if (label17.Text == "设备生产能力")
                {
                    HG02 = label17.Text;
                    HG03 = textBox13.Text;
                    HG04 = comboBox5.Text;
                    SqlHelper.ExecuteNonQuery("UPDATE R_HGGFXCPGBGA SET HG02=@HG02,HG03=@HG03,HG04=@HG04 WHERE HG01=@HG01", new SqlParameter("@HG01", HF01), new SqlParameter("@HG02", HG02), new SqlParameter("@HG03", HG03), new SqlParameter("@HG04", HG04));
                }
                if (label18.Text == "管理人员数")
                {
                    HG02 = label18.Text;
                    HG03 = textBox14.Text;
                    HG04 = comboBox6.Text;
                    SqlHelper.ExecuteNonQuery("UPDATE R_HGGFXCPGBGA SET HG02=@HG02,HG03=@HG03,HG04=@HG04 WHERE HG01=@HG01", new SqlParameter("@HG01", HF01), new SqlParameter("@HG02", HG02), new SqlParameter("@HG03", HG03), new SqlParameter("@HG04", HG04));
                }
                if (label19.Text == "生产规模")
                {
                    HG02 = label19.Text;
                    HG03 = textBox15.Text;
                    HG04 = comboBox7.Text;
                    SqlHelper.ExecuteNonQuery("UPDATE R_HGGFXCPGBGA SET HG02=@HG02,HG03=@HG03,HG04=@HG04 WHERE HG01=@HG01", new SqlParameter("@HG01", HF01), new SqlParameter("@HG02", HG02), new SqlParameter("@HG03", HG03), new SqlParameter("@HG04", HG04));
                }
                if (label20.Text == "是否获证（ISO9001或其他）")
                {
                    HG02 = label20.Text;
                    HG03 = textBox16.Text;
                    HG04 = comboBox8.Text;
                    SqlHelper.ExecuteNonQuery("UPDATE R_HGGFXCPGBGA SET HG02=@HG02,HG03=@HG03,HG04=@HG04 WHERE HG01=@HG01", new SqlParameter("@HG01", HF01), new SqlParameter("@HG02", HG02), new SqlParameter("@HG03", HG03), new SqlParameter("@HG04", HG04));
                }
                if (label21.Text == "文件方面（有哪些制度和控制）")
                {
                    HG02 = label21.Text;
                    HG03 = textBox17.Text;
                    HG04 = comboBox9.Text;
                    SqlHelper.ExecuteNonQuery("UPDATE R_HGGFXCPGBGA SET HG02=@HG02,HG03=@HG03,HG04=@HG04 WHERE HG01=@HG01", new SqlParameter("@HG01", HF01), new SqlParameter("@HG02", HG02), new SqlParameter("@HG03", HG03), new SqlParameter("@HG04", HG04));
                }
                if (button1.Text == "创办何年何月（企业简介及营业执照）")
                {
                    HG02 = button1.Text;
                    HG03 = textBox18.Text;
                    HG04 = comboBox10.Text;
                    SqlHelper.ExecuteNonQuery("UPDATE R_HGGFXCPGBGA SET HG02=@HG02,HG03=@HG03,HG04=@HG04 WHERE HG01=@HG01", new SqlParameter("@HG01", HF01), new SqlParameter("@HG02", HG02), new SqlParameter("@HG03", HG03), new SqlParameter("@HG04", HG04));
                }
                if (label23.Text == "有无除湿或其他配套设施及相应操作规程")
                {
                    HG02 = label23.Text;
                    HG03 = textBox19.Text;
                    HG04 = comboBox11.Text;
                    SqlHelper.ExecuteNonQuery("UPDATE R_HGGFXCPGBGA SET HG02=@HG02,HG03=@HG03,HG04=@HG04 WHERE HG01=@HG01", new SqlParameter("@HG01", HF01), new SqlParameter("@HG02", HG02), new SqlParameter("@HG03", HG03), new SqlParameter("@HG04", HG04));
                }
                if (label24.Text == "现场堆放、通道、标识是否规范、全面、充分，区域划分是否合理，现场是否整齐清洁")
                {
                    HG02 = label24.Text;
                    HG03 = textBox20.Text;
                    HG04 = comboBox12.Text;
                    SqlHelper.ExecuteNonQuery("UPDATE R_HGGFXCPGBGA SET HG02=@HG02,HG03=@HG03,HG04=@HG04 WHERE HG01=@HG01", new SqlParameter("@HG01", HF01), new SqlParameter("@HG02", HG02), new SqlParameter("@HG03", HG03), new SqlParameter("@HG04", HG04));
                }
                if (label25.Text == "工厂现场的通风设施等条件是否符合生产要求")
                {
                    HG02 = label25.Text;
                    HG03 = textBox21.Text;
                    HG04 = comboBox13.Text;
                    SqlHelper.ExecuteNonQuery("UPDATE R_HGGFXCPGBGA SET HG02=@HG02,HG03=@HG03,HG04=@HG04 WHERE HG01=@HG01", new SqlParameter("@HG01", HF01), new SqlParameter("@HG02", HG02), new SqlParameter("@HG03", HG03), new SqlParameter("@HG04", HG04));
                }
                if (label26.Text == "安全防护设施有哪些，是否有管理制度")
                {
                    HG02 = label26.Text;
                    HG03 = textBox22.Text;
                    HG04 = comboBox14.Text;
                    SqlHelper.ExecuteNonQuery("UPDATE R_HGGFXCPGBGA SET HG02=@HG02,HG03=@HG03,HG04=@HG04 WHERE HG01=@HG01", new SqlParameter("@HG01", HF01), new SqlParameter("@HG02", HG02), new SqlParameter("@HG03", HG03), new SqlParameter("@HG04", HG04));
                }
                if (label27.Text == "对特殊过程是否已识别，人员上岗前是否进行培训考核合格后再上岗")
                {
                    HG02 = label27.Text;
                    HG03 = textBox23.Text;
                    HG04 = comboBox15.Text;
                    SqlHelper.ExecuteNonQuery("UPDATE R_HGGFXCPGBGA SET HG02=@HG02,HG03=@HG03,HG04=@HG04 WHERE HG01=@HG01", new SqlParameter("@HG01", HF01), new SqlParameter("@HG02", HG02), new SqlParameter("@HG03", HG03), new SqlParameter("@HG04", HG04));
                }
                if (label28.Text == "工厂是否建立批次管理")
                {
                    HG02 = label28.Text;
                    HG03 = textBox24.Text;
                    HG04 = comboBox16.Text;
                    SqlHelper.ExecuteNonQuery("UPDATE R_HGGFXCPGBGA SET HG02=@HG02,HG03=@HG03,HG04=@HG04 WHERE HG01=@HG01", new SqlParameter("@HG01", HF01), new SqlParameter("@HG02", HG02), new SqlParameter("@HG03", HG03), new SqlParameter("@HG04", HG04));
                }
            }
        }

        private void toolDelect_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("请查询需要删除内容对应的客户信息");
            }
            else
            {
                HF01 = bianhao;
                SqlHelper.ExecuteNonQuery("DELETE FROM DELETE FROM R_CORYSJJCBG WHERE HF01=@HF01",new SqlParameter("@HF01",HF01));
                SqlHelper.ExecuteNonQuery("DELETE FROM R_CORYSJJCBGA WHERE HG01=@HG01",new SqlParameter("@HG01",HF01));
                foreach (Control cn in this.Controls)
                {
                    if (cn.GetType().ToString() == "System.Windows.Forms.TextBox")
                    {
                        TextBox tx = cn as TextBox;
                        tx.Text = "";
                        continue;
                    }
                    if (cn.GetType().ToString() == "System.Windows.Forms.ComboBox")
                    {
                        ComboBox cm = cn as ComboBox;
                        cm.Text = "";
                        continue;
                    }
                    if (cn.GetType().ToString() == "System.Windows.Forms.DateTimePicker")
                    {
                        DateTimePicker dt = cn as DateTimePicker;
                        datatimepickeroverride1.Text = MulaolaoBll . Drity . GetDt ( ).ToString();
                        continue;
                    }
                }
            }
        }

        private void toolSelect_Click(object sender, EventArgs e)
        {
            DataTable dae = SqlHelper.ExecuteDataTable("SELECT * FROM TPADGA");
            if (dae.Rows.Count < 1)
            {
                MessageBox.Show("没有客户信息");
            }
            else
            {
                //conb.label1.Text = "供方编号";
                //conb.label2.Visible = true;
                //conb.label2.Text = "供方名称";
                //conb.textBox1.Visible = false;
                //conb.comboBox2.Visible = true;
                //conb.label2.Location = new System.Drawing.Point(25, 68);
                //conb.comboBox2.Location = new System.Drawing.Point(84, 65);
                //conb.btnSure.Location = new System.Drawing.Point(27, 105);
                //conb.btnCancel.Location = new System.Drawing.Point(148, 105);
                conb.Size = new System.Drawing.Size(265, 188);
                conb.FormBorderStyle = FormBorderStyle.FixedSingle;
                conb.PassDataBetweenForm += new R_FrmContractreviewb.PassDataBetweenFormHandler(conb_PassDataBetweenForm);
                DataTable da = SqlHelper.ExecuteDataTable("SELECT DGA001 FROM TPADGA");
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    //conb.comboBox1.Items.Add(da.Rows[i]["DGA001"].ToString());
                }

                string DGA001 = "";
                DataTable de = SqlHelper.ExecuteDataTable("SELECT DGA003 FROM TPADGA WHERE DGA001=@DGA001", new SqlParameter("@DGA001", DGA001));
                for (int i = 0; i < de.Rows.Count; i++)
                {
                    //conb.comboBox2.Items.Add(de.Rows[i]["DGA003"].ToString());
                }
                conb.ShowDialog();
            }
            DataTable dta = SqlHelper.ExecuteDataTable("SELECT DGA008,DGA011,DGA013,DGA015,DGA017 FROM TPADGA WHERE DGA001=@dga001",new SqlParameter("@DGA001",bianhao));
            textBox5.Text = dta.Rows[0]["DGA008"].ToString();
            textBox6.Text = dta.Rows[0]["DGA017"].ToString();
            textBox7.Text = dta.Rows[0]["DGA011"].ToString();
            textBox8.Text = dta.Rows[0]["DGA013"].ToString();
            textBox9.Text = dta.Rows[0]["DGA015"].ToString();

            DataTable dle = SqlHelper.ExecuteDataTable("SELECT HF02,HF03,HF04,HF05,HF06,HF07 FROM R_HGGFXCPGBG WHERE DF01=@DF01",new SqlParameter("@DF01",bianhao));
            textBox1.Text = dle.Rows[0]["HF02"].ToString();
            textBox2.Text = dle.Rows[0]["HF03"].ToString();
            textBox3.Text = dle.Rows[0]["HF04"].ToString();
            datatimepickeroverride1.Text=dle.Rows[0]["HF05"].ToString();
            comboBox17.Text = dle.Rows[0]["HF06"].ToString();
            textBox25.Text = dle.Rows[0]["HF07"].ToString();

            DataTable del = SqlHelper.ExecuteDataTable("SELECT HG02,HG03,HG04 FROM R_HGGFXCPGBGA WHERE HG01=@HG01",new SqlParameter("@HG01",bianhao));
            if (del.Rows[0]["HG02"].ToString() == "工厂占地面积（m2）")
            {
                textBox10.Text = del.Rows[0]["HG03"].ToString();
                comboBox2.Text = del.Rows[0]["HG04"].ToString();
            }
            if (del.Rows[0]["HG02"].ToString() == "使用建筑面积（m2）")
            {
                textBox11.Text = del.Rows[0]["HG03"].ToString();
                comboBox3.Text = del.Rows[0]["HG04"].ToString();
            }
            if (del.Rows[0]["HG02"].ToString() == "工厂人数")
            {
                textBox12.Text = del.Rows[0]["HG03"].ToString();
                comboBox4.Text = del.Rows[0]["HG04"].ToString();
            }
            if (del.Rows[0]["HG02"].ToString() == "设备生产能力")
            {
                textBox13.Text = del.Rows[0]["HG03"].ToString();
                comboBox5.Text = del.Rows[0]["HG04"].ToString();
            }
            if (del.Rows[0]["HG02"].ToString() == "管理人员数")
            {
                textBox14.Text = del.Rows[0]["HG03"].ToString();
                comboBox6.Text = del.Rows[0]["HG04"].ToString();
            }
            if (del.Rows[0]["HG02"].ToString() == "生产规模")
            {
                textBox15.Text = del.Rows[0]["HG03"].ToString();
                comboBox7.Text = del.Rows[0]["HG04"].ToString();
            }
            if (del.Rows[0]["HG02"].ToString() == "是否获证（ISO9001或其他）")
            {
                textBox16.Text = del.Rows[0]["HG03"].ToString();
                comboBox8.Text = del.Rows[0]["HG04"].ToString();
            }
            if (del.Rows[0]["HG02"].ToString() == "文件方面（有哪些制度和控制）")
            {
                textBox17.Text = del.Rows[0]["HG03"].ToString();
                comboBox9.Text = del.Rows[0]["HG04"].ToString();
            }
            if (del.Rows[0]["HG02"].ToString() == "创办何年何月（企业简介及营业执照）")
            {
                textBox18.Text = del.Rows[0]["HG03"].ToString();
                comboBox10.Text = del.Rows[0]["HG04"].ToString();
            }
            if (del.Rows[0]["HG02"].ToString() == "有无除湿或其他配套设施及相应操作规程")
            {
                textBox19.Text = del.Rows[0]["HG03"].ToString();
                comboBox11.Text = del.Rows[0]["HG04"].ToString();
            }
            if (del.Rows[0]["HG02"].ToString() == "现场堆放、通道、标识是否规范、全面、充分，区域划分是否合理，现场是否整齐清洁")
            {
                textBox20.Text = del.Rows[0]["HG03"].ToString();
                comboBox12.Text = del.Rows[0]["HG04"].ToString();
            }
            if (del.Rows[0]["HG02"].ToString() == "工厂现场的通风设施等条件是否符合生产要求")
            {
                textBox21.Text = del.Rows[0]["HG03"].ToString();
                comboBox13.Text = del.Rows[0]["HG04"].ToString();
            }
            if (del.Rows[0]["HG02"].ToString() == "安全防护设施有哪些，是否有管理制度")
            {
                textBox22.Text = del.Rows[0]["HG03"].ToString();
                comboBox14.Text = del.Rows[0]["HG04"].ToString();
            }
            if (del.Rows[0]["HG02"].ToString() == "对特殊过程是否已识别，人员上岗前是否进行培训考核合格后再上岗")
            {
                textBox23.Text = del.Rows[0]["HG03"].ToString();
                comboBox15.Text = del.Rows[0]["HG04"].ToString();
            }
            if (del.Rows[0]["HG02"].ToString() == "工厂是否建立批次管理")
            {
                textBox24.Text = del.Rows[0]["HG03"].ToString();
                comboBox16.Text = del.Rows[0]["HG04"].ToString();
            }
        }
        
        private void conb_PassDataBetweenForm(object sender, PassDataWinFormEventArgs e)
        {
            bianhao = e.ConOne;
            this.textBox4.Text = e.ConTwo;
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            DataTable dae = SqlHelper.ExecuteDataTable("SELECT * FROM TPADGA");
            if (dae.Rows.Count < 1)
            {
                MessageBox.Show("没有客户信息");
            }
            else
            {
                //conb.label1.Text = "供方编号";
                //conb.label2.Visible = true;
                //conb.label2.Text = "供方名称";
                //conb.textBox1.Visible = false;
                //conb.comboBox2.Visible = true;
                //conb.label2.Location = new System.Drawing.Point(25, 68);
                //conb.comboBox2.Location = new System.Drawing.Point(84, 65);
                //conb.btnSure.Location = new System.Drawing.Point(27, 105);
                //conb.btnCancel.Location = new System.Drawing.Point(148, 105);
                conb.Size = new System.Drawing.Size(265, 188);
                conb.FormBorderStyle = FormBorderStyle.FixedSingle;
                conb.PassDataBetweenForm += new R_FrmContractreviewb.PassDataBetweenFormHandler(conb_PassDataBetweenForm);
                DataTable da = SqlHelper.ExecuteDataTable("SELECT DGA001 FROM TPADGA");
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    //conb.comboBox1.Items.Add(da.Rows[i]["DGA001"].ToString());
                }

                string DGA001 = "";
                DataTable de = SqlHelper.ExecuteDataTable("SELECT DGA003 FROM TPADGA WHERE DGA001=@DGA001", new SqlParameter("@DGA001", DGA001));
                for (int i = 0; i < de.Rows.Count; i++)
                {
                    //conb.comboBox2.Items.Add(de.Rows[i]["DGA003"].ToString());
                }
                conb.ShowDialog();
            }
            DataTable dta = SqlHelper.ExecuteDataTable("SELECT DGA008,DGA011,DGA013,DGA015,DGA017 FROM TPADGA WHERE DGA001=@dga001", new SqlParameter("@DGA001", bianhao));
            textBox5.Text = dta.Rows[0]["DGA008"].ToString();
            textBox6.Text = dta.Rows[0]["DGA017"].ToString();
            textBox7.Text = dta.Rows[0]["DGA011"].ToString();
            textBox8.Text = dta.Rows[0]["DGA013"].ToString();
            textBox9.Text = dta.Rows[0]["DGA015"].ToString();

            DataTable dea = SqlHelper.ExecuteDataTable("SELECT HF01 FROM R_HGGFXCPGBG");
            for (int i = 0; i < dea.Rows.Count; i++)
            {
                if (bianhao == dea.Rows[i]["DF01"].ToString())
                {
                    MessageBox.Show("供方名称为" + textBox4.Text + "的数据已经存在,无法录入重复数据");
                }
                else
                {
                    HF01 = bianhao;
                    HF02 = textBox1.Text;
                    HF03 = textBox2.Text;
                    HF04 = textBox3.Text;
                    HF05 = datatimepickeroverride1.Text;
                    HF06 = comboBox17.Text;
                    HF07 = textBox25.Text;
                    SqlHelper.ExecuteNonQuery("INSERT INTO R_HGGFXCPGBG (HF01,HF02,HF03,HF04,HF05,HF06,HF07) VALUES (@HF01,@HF02,@HF03,@HF04,@HF05,@HF06,@HF07)",new SqlParameter("@HF01",HF01), new SqlParameter("@HF02", HF02), new SqlParameter("@HF03", HF03), new SqlParameter("@HF04", HF04), new SqlParameter("@HF05", HF05), new SqlParameter("@HF06", HF06), new SqlParameter("@HF07", HF07));


                    if (label14.Text == "工厂占地面积（m2）")
                    {
                        HG02 = label14.Text;
                        HG03 = textBox10.Text;
                        HG04 = comboBox2.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_HGGFXCPGBGA (HG01,HG02,HG03,HG04) VALUES (@HG01,@HG02,@HG03,@HG04)", new SqlParameter("@HG01", HF01), new SqlParameter("@HG02", HG02), new SqlParameter("@HG03", HG03), new SqlParameter("@HG04", HG04));
                    }
                    if (label15.Text == "使用建筑面积（m2）")
                    {
                        HG02 = label15.Text;
                        HG03 = textBox11.Text;
                        HG04 = comboBox3.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_HGGFXCPGBGA (HG01,HG02,HG03,HG04) VALUES (@HG01,@HG02,@HG03,@HG04)", new SqlParameter("@HG01", HF01), new SqlParameter("@HG02", HG02), new SqlParameter("@HG03", HG03), new SqlParameter("@HG04", HG04));
                    }
                    if (label16.Text == "工厂人数")
                    {
                        HG02 = label16.Text;
                        HG03 = textBox12.Text;
                        HG04 = comboBox4.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_HGGFXCPGBGA (HG01,HG02,HG03,HG04) VALUES (@HG01,@HG02,@HG03,@HG04)", new SqlParameter("@HG01", HF01), new SqlParameter("@HG02", HG02), new SqlParameter("@HG03", HG03), new SqlParameter("@HG04", HG04));
                    }
                    if (label17.Text == "设备生产能力")
                    {
                        HG02 = label17.Text;
                        HG03 = textBox13.Text;
                        HG04 = comboBox5.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_HGGFXCPGBGA (HG01,HG02,HG03,HG04) VALUES (@HG01,@HG02,@HG03,@HG04)", new SqlParameter("@HG01", HF01), new SqlParameter("@HG02", HG02), new SqlParameter("@HG03", HG03), new SqlParameter("@HG04", HG04));
                    }
                    if (label18.Text == "管理人员数")
                    {
                        HG02 = label18.Text;
                        HG03 = textBox14.Text;
                        HG04 = comboBox6.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_HGGFXCPGBGA (HG01,HG02,HG03,HG04) VALUES (@HG01,@HG02,@HG03,@HG04)", new SqlParameter("@HG01", HF01), new SqlParameter("@HG02", HG02), new SqlParameter("@HG03", HG03), new SqlParameter("@HG04", HG04));
                    }
                    if (label19.Text == "生产规模")
                    {
                        HG02 = label19.Text;
                        HG03 = textBox15.Text;
                        HG04 = comboBox7.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_HGGFXCPGBGA (HG01,HG02,HG03,HG04) VALUES (@HG01,@HG02,@HG03,@HG04)", new SqlParameter("@HG01", HF01), new SqlParameter("@HG02", HG02), new SqlParameter("@HG03", HG03), new SqlParameter("@HG04", HG04));
                    }
                    if (label20.Text == "是否获证（ISO9001或其他）")
                    {
                        HG02 = label20.Text;
                        HG03 = textBox16.Text;
                        HG04 = comboBox8.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_HGGFXCPGBGA (HG01,HG02,HG03,HG04) VALUES (@HG01,@HG02,@HG03,@HG04)", new SqlParameter("@HG01", HF01), new SqlParameter("@HG02", HG02), new SqlParameter("@HG03", HG03), new SqlParameter("@HG04", HG04));
                    }
                    if (label21.Text == "文件方面（有哪些制度和控制）")
                    {
                        HG02 = label21.Text;
                        HG03 = textBox17.Text;
                        HG04 = comboBox9.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_HGGFXCPGBGA (HG01,HG02,HG03,HG04) VALUES (@HG01,@HG02,@HG03,@HG04)", new SqlParameter("@HG01", HF01), new SqlParameter("@HG02", HG02), new SqlParameter("@HG03", HG03), new SqlParameter("@HG04", HG04));
                    }
                    if (button1.Text == "创办何年何月（企业简介及营业执照）")
                    {
                        HG02 = button1.Text;
                        HG03 = textBox18.Text;
                        HG04 = comboBox10.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_HGGFXCPGBGA (HG01,HG02,HG03,HG04) VALUES (@HG01,@HG02,@HG03,@HG04)", new SqlParameter("@HG01", HF01), new SqlParameter("@HG02", HG02), new SqlParameter("@HG03", HG03), new SqlParameter("@HG04", HG04));
                    }
                    if (label23.Text == "有无除湿或其他配套设施及相应操作规程")
                    {
                        HG02 = label23.Text;
                        HG03 = textBox19.Text;
                        HG04 = comboBox11.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_HGGFXCPGBGA (HG01,HG02,HG03,HG04) VALUES (@HG01,@HG02,@HG03,@HG04)", new SqlParameter("@HG01", HF01), new SqlParameter("@HG02", HG02), new SqlParameter("@HG03", HG03), new SqlParameter("@HG04", HG04));
                    }
                    if (label24.Text == "现场堆放、通道、标识是否规范、全面、充分，区域划分是否合理，现场是否整齐清洁")
                    {
                        HG02 = label24.Text;
                        HG03 = textBox20.Text;
                        HG04 = comboBox12.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_HGGFXCPGBGA (HG01,HG02,HG03,HG04) VALUES (@HG01,@HG02,@HG03,@HG04)", new SqlParameter("@HG01", HF01), new SqlParameter("@HG02", HG02), new SqlParameter("@HG03", HG03), new SqlParameter("@HG04", HG04));
                    }
                    if (label25.Text == "工厂现场的通风设施等条件是否符合生产要求")
                    {
                        HG02 = label25.Text;
                        HG03 = textBox21.Text;
                        HG04 = comboBox13.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_HGGFXCPGBGA (HG01,HG02,HG03,HG04) VALUES (@HG01,@HG02,@HG03,@HG04)", new SqlParameter("@HG01", HF01), new SqlParameter("@HG02", HG02), new SqlParameter("@HG03", HG03), new SqlParameter("@HG04", HG04));
                    }
                    if (label26.Text == "安全防护设施有哪些，是否有管理制度")
                    {
                        HG02 = label26.Text;
                        HG03 = textBox22.Text;
                        HG04 = comboBox14.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_HGGFXCPGBGA (HG01,HG02,HG03,HG04) VALUES (@HG01,@HG02,@HG03,@HG04)", new SqlParameter("@HG01", HF01), new SqlParameter("@HG02", HG02), new SqlParameter("@HG03", HG03), new SqlParameter("@HG04", HG04));
                    }
                    if (label27.Text == "对特殊过程是否已识别，人员上岗前是否进行培训考核合格后再上岗")
                    {
                        HG02 = label27.Text;
                        HG03 = textBox23.Text;
                        HG04 = comboBox15.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_HGGFXCPGBGA (HG01,HG02,HG03,HG04) VALUES (@HG01,@HG02,@HG03,@HG04)", new SqlParameter("@HG01", HF01), new SqlParameter("@HG02", HG02), new SqlParameter("@HG03", HG03), new SqlParameter("@HG04", HG04));
                    }
                    if (label28.Text == "工厂是否建立批次管理")
                    {
                        HG02 = label28.Text;
                        HG03 = textBox24.Text;
                        HG04 = comboBox16.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_HGGFXCPGBGA (HG01,HG02,HG03,HG04) VALUES (@HG01,@HG02,@HG03,@HG04)", new SqlParameter("@HG01", HF01), new SqlParameter("@HG02", HG02), new SqlParameter("@HG03", HG03), new SqlParameter("@HG04", HG04));
                    }
                }
            }
        }
    }
}

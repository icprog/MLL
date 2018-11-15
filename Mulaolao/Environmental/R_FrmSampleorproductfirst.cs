using Mulaolao.Class;
using StudentMgr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mulaolao.Procedure
{
    public partial class R_FrmSampleorproductfirst : Form
    {
        public R_FrmSampleorproductfirst(Form1 fm)
        {
            this.MdiParent = fm;
            InitializeComponent();


        }
        R_FrmContractreviewb conb = new R_FrmContractreviewb();
        private void R_FrmSampleorproductfirst_Load(object sender, EventArgs e)
        {
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;
        }
        string SJ01 = "", SJ02 = "", SJ03 = "", SJ04 = "", SJ05 = "", SJ06 = "", SJ07 = "", SJ08 = "", SJ09 = "", SJ10 = "", SJ11 = "", SJ12 = "", SJ13 = "", SJ14 = "", SJ15 = "", SJ16 = "", SJ17 = "", SJ18 = "", SC02 = "", SC03 = "", SC04 = "", SC05 = "", SC06 = "";

        private void toolReview_Click( object sender, EventArgs e )
        {

        }

        private void toolSelect_Click(object sender, EventArgs e)
        {
            DataTable dt = SqlHelper.ExecuteDataTable(" SELECT KH25 FROM R_MLLKHXXCD");
            if (dt.Rows.Count < 0)
            {
                MessageBox.Show("没有数据");
            }
            else
            {
                //conb.label1.Text = "流水号";
                //conb.label2.Visible = true;
                //conb.label2.Text = "合同编号";
                //conb.textBox1.Visible = false;
                //conb.comboBox2.Visible = true;
                //conb.label2.Location = new System.Drawing.Point(25, 68);
                //conb.comboBox2.Location = new System.Drawing.Point(84, 65);
                //conb.btnSure.Location = new System.Drawing.Point(27, 105);
                //conb.btnCancel.Location = new System.Drawing.Point(148, 105);
                conb.Size = new System.Drawing.Size(265, 188);
                conb.FormBorderStyle = FormBorderStyle.FixedSingle;
                conb.PassDataBetweenForm += new R_FrmContractreviewb.PassDataBetweenFormHandler(conb_PassDataBetweenForm);
                DataTable da = SqlHelper.ExecuteDataTable("SELECT KH25 FROM R_MLLKHXXCD");
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    //conb.comboBox1.Items.Add(da.Rows[i]["KH25"].ToString());
                }

                string KH25 = "";
                DataTable de = SqlHelper.ExecuteDataTable("SELECT KH24 FROM R_MLLKHXXCD WHERE KH25=@KH25", new SqlParameter("@KH25", KH25));
                for (int i = 0; i < de.Rows.Count; i++)
                {
                    //conb.comboBox2.Items.Add(de.Rows[i]["KH24"].ToString());
                }
                conb.ShowDialog();
            }
            string HT14 = textBox3.Text;
            string HT001 = textBox4.Text;
            DataTable dd = SqlHelper.ExecuteDataTable("SELECT A.DEA002,B.HT03 FROM TPADEA A,R_MLLHTPS B WHERE A.DEA001=B.HT01 AND HT01=@HT01 AND HT14=@HT14", new SqlParameter("@HT01", HT001), new SqlParameter("@HT14", HT14));
            textBox2.Text = dd.Rows[0]["DEA002"].ToString();
            textBox6.Text = dd.Rows[0]["HT03"].ToString();
            #region  表头 表尾
            DataTable dle = SqlHelper.ExecuteDataTable("SELECT * FROM R_CORYSJJCBG WHERE SJ01=HT001");
            textBox1.Text = dle.Rows[0]["SJ02"].ToString();
            if (dle.Rows[0]["SJ03"].ToString() == "Y")
            {
                checkBox1.Checked = true;
                textBox7.Enabled = true;
                String[] st = dle.Rows[0]["SJ03"].ToString().Split(',');
                textBox7.Text = st[1];
            }
            else
            {
                checkBox1.Checked = false;
            }
            if (dle.Rows[0]["SJ04"].ToString() == "Y")
            {
                checkBox2.Checked = true;
                textBox8.Enabled = true;
                String[] st = dle.Rows[0]["SJ04"].ToString().Split(',');
                textBox8.Text = st[1];
            }
            else
            {
                checkBox2.Checked = false;
            }
            if (dle.Rows[0]["SJ05"].ToString() == "Y")
            {
                checkBox3.Checked = true;
                textBox9.Enabled = true;
                String[] st = dle.Rows[0]["SJ05"].ToString().Split(',');
                textBox9.Text = st[1];
            }
            else
            {
                checkBox3.Checked = false;
            }
            if (dle.Rows[0]["SJ06"].ToString() == "Y")
            {
                checkBox4.Checked = true;
            }
            else
            {
                checkBox4.Checked = false;
            }
            if (dle.Rows[0]["SJ07"].ToString() == radioButton1.Text)
            {
                radioButton1.Checked = true;
            }
            else if (dle.Rows[0]["SJ07"].ToString() == radioButton2.Text)
            {
                radioButton2.Checked = true;
            }
            else if (dle.Rows[0]["SJ07"].ToString() == radioButton3.Text)
            {
                radioButton3.Checked = true;
            }
            else
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
            }
            if (dle.Rows[0]["SJ08"].ToString() == radioButton5.Text)
            {
                radioButton5.Checked = true;
            }
            else if (dle.Rows[0]["SJ08"].ToString() == radioButton6.Text)
            {
                radioButton6.Checked = true;
            }
            else
            {
                radioButton5.Checked = false;
                radioButton6.Checked = false;
            }
            textBox103.Text = dle.Rows[0]["SJ09"].ToString();
            textBox104.Text = dle.Rows[0]["SJ10"].ToString();
            textBox105.Text = dle.Rows[0]["SJ11"].ToString();
            datatimepickeroverride1.Text = dle.Rows[0]["SJ12"].ToString();
            textBox108.Text = dle.Rows[0]["SJ13"].ToString();
            textBox109.Text = dle.Rows[0]["SJ14"].ToString();
            textBox110.Text = dle.Rows[0]["SJ15"].ToString();
            textBox111.Text = dle.Rows[0]["SJ16"].ToString();
            datatimepickeroverride2.Text = dle.Rows[0]["SJ17"].ToString();
            datatimepickeroverride3.Text = dle.Rows[0]["SJ18"].ToString();
            #endregion
            #region 表中
            SJ02 = textBox1.Text;
            DataTable dae = SqlHelper.ExecuteDataTable("SELECT * FROM R_CORYSJJCBGA WHERE SC01=@SC01", new SqlParameter("@SC01", SJ02));
            for (int i = 0; i < dae.Rows.Count; i++)
            {
                if (dae.Rows[i]["SC02"].ToString() == "1")
                {
                    textBox10.Text = dae.Rows[i]["SC04"].ToString();
                    textBox11.Text = dae.Rows[i]["SC05"].ToString();
                    textBox12.Text = dae.Rows[i]["SC06"].ToString();
                }
                if (dae.Rows[i]["SC02"].ToString() == "2")
                {
                    textBox13.Text = dae.Rows[i]["SC04"].ToString();
                    textBox14.Text = dae.Rows[i]["SC05"].ToString();
                    textBox15.Text = dae.Rows[i]["SC06"].ToString();
                }
                if (dae.Rows[i]["SC02"].ToString() == "3")
                {
                    textBox16.Text = dae.Rows[i]["SC04"].ToString();
                    textBox17.Text = dae.Rows[i]["SC05"].ToString();
                    textBox18.Text = dae.Rows[i]["SC06"].ToString();
                }
                if (dae.Rows[i]["SC02"].ToString() == "4")
                {
                    textBox19.Text = dae.Rows[i]["SC04"].ToString();
                    textBox20.Text = dae.Rows[i]["SC05"].ToString();
                    textBox21.Text = dae.Rows[i]["SC06"].ToString();
                }
                if (dae.Rows[i]["SC02"].ToString() == "5")
                {
                    textBox22.Text = dae.Rows[i]["SC04"].ToString();
                    textBox23.Text = dae.Rows[i]["SC05"].ToString();
                    textBox24.Text = dae.Rows[i]["SC06"].ToString();
                }
                if (dae.Rows[i]["SC02"].ToString() == "6")
                {
                    textBox25.Text = dae.Rows[i]["SC04"].ToString();
                    textBox26.Text = dae.Rows[i]["SC05"].ToString();
                    textBox27.Text = dae.Rows[i]["SC06"].ToString();
                }
                if (dae.Rows[i]["SC02"].ToString() == "7")
                {
                    textBox28.Text = dae.Rows[i]["SC04"].ToString();
                    textBox29.Text = dae.Rows[i]["SC05"].ToString();
                    textBox30.Text = dae.Rows[i]["SC06"].ToString();
                }
                if (dae.Rows[i]["SC02"].ToString() == "8")
                {
                    textBox31.Text = dae.Rows[i]["SC04"].ToString();
                    textBox32.Text = dae.Rows[i]["SC05"].ToString();
                    textBox33.Text = dae.Rows[i]["SC06"].ToString();
                }
                if (dae.Rows[i]["SC02"].ToString() == "9")
                {
                    textBox34.Text = dae.Rows[i]["SC04"].ToString();
                    textBox35.Text = dae.Rows[i]["SC05"].ToString();
                    textBox36.Text = dae.Rows[i]["SC06"].ToString();
                }
                if (dae.Rows[i]["SC02"].ToString() == "10")
                {
                    textBox37.Text = dae.Rows[i]["SC04"].ToString();
                    textBox38.Text = dae.Rows[i]["SC05"].ToString();
                    textBox39.Text = dae.Rows[i]["SC06"].ToString();
                }
                if (dae.Rows[i]["SC02"].ToString() == "11")
                {
                    textBox40.Text = dae.Rows[i]["SC04"].ToString();
                    textBox41.Text = dae.Rows[i]["SC05"].ToString();
                    textBox42.Text = dae.Rows[i]["SC06"].ToString();
                }
                if (dae.Rows[i]["SC02"].ToString() == "12")
                {
                    textBox43.Text = dae.Rows[i]["SC04"].ToString();
                    textBox46.Text = dae.Rows[i]["SC05"].ToString();
                    textBox47.Text = dae.Rows[i]["SC06"].ToString();
                }
                if (dae.Rows[i]["SC02"].ToString() == "13")
                {
                    textBox44.Text = dae.Rows[i]["SC04"].ToString();
                    textBox48.Text = dae.Rows[i]["SC05"].ToString();
                    textBox49.Text = dae.Rows[i]["SC06"].ToString();
                }
                if (dae.Rows[i]["SC02"].ToString() == "14")
                {
                    textBox45.Text = dae.Rows[i]["SC04"].ToString();
                    textBox50.Text = dae.Rows[i]["SC05"].ToString();
                    textBox51.Text = dae.Rows[i]["SC06"].ToString();
                }
                if (dae.Rows[i]["SC02"].ToString() == "15")
                {
                    textBox52.Text = dae.Rows[i]["SC04"].ToString();
                    textBox53.Text = dae.Rows[i]["SC05"].ToString();
                    textBox54.Text = dae.Rows[i]["SC06"].ToString();
                }
                if (dae.Rows[i]["SC02"].ToString() == "16")
                {
                    textBox55.Text = dae.Rows[i]["SC04"].ToString();
                    textBox56.Text = dae.Rows[i]["SC05"].ToString();
                    textBox57.Text = dae.Rows[i]["SC06"].ToString();
                }
                if (dae.Rows[i]["SC02"].ToString() == "17")
                {
                    textBox58.Text = dae.Rows[i]["SC04"].ToString();
                    textBox59.Text = dae.Rows[i]["SC05"].ToString();
                    textBox60.Text = dae.Rows[i]["SC06"].ToString();
                }
                if (dae.Rows[i]["SC02"].ToString() == "18")
                {
                    textBox61.Text = dae.Rows[i]["SC04"].ToString();
                    textBox62.Text = dae.Rows[i]["SC05"].ToString();
                    textBox63.Text = dae.Rows[i]["SC06"].ToString();
                }
                if (dae.Rows[i]["SC02"].ToString() == "19")
                {
                    textBox64.Text = dae.Rows[i]["SC04"].ToString();
                    textBox65.Text = dae.Rows[i]["SC05"].ToString();
                    textBox66.Text = dae.Rows[i]["SC06"].ToString();
                }
                if (dae.Rows[i]["SC02"].ToString() == "20")
                {
                    textBox67.Text = dae.Rows[i]["SC04"].ToString();
                    textBox68.Text = dae.Rows[i]["SC05"].ToString();
                    textBox69.Text = dae.Rows[i]["SC06"].ToString();
                }
                if (dae.Rows[i]["SC02"].ToString() == "21")
                {
                    textBox70.Text = dae.Rows[i]["SC04"].ToString();
                    textBox71.Text = dae.Rows[i]["SC05"].ToString();
                    textBox72.Text = dae.Rows[i]["SC06"].ToString();
                }
                if (dae.Rows[i]["SC02"].ToString() == "22")
                {
                    textBox73.Text = dae.Rows[i]["SC04"].ToString();
                    textBox74.Text = dae.Rows[i]["SC05"].ToString();
                    textBox75.Text = dae.Rows[i]["SC06"].ToString();
                }
                if (dae.Rows[i]["SC02"].ToString() == "23")
                {
                    textBox76.Text = dae.Rows[i]["SC04"].ToString();
                    textBox77.Text = dae.Rows[i]["SC05"].ToString();
                    textBox78.Text = dae.Rows[i]["SC06"].ToString();
                }
                if (dae.Rows[i]["SC02"].ToString() == "24")
                {
                    textBox79.Text = dae.Rows[i]["SC04"].ToString();
                    textBox80.Text = dae.Rows[i]["SC05"].ToString();
                    textBox81.Text = dae.Rows[i]["SC06"].ToString();
                }
                if (dae.Rows[i]["SC02"].ToString() == "25")
                {
                    textBox82.Text = dae.Rows[i]["SC04"].ToString();
                    textBox83.Text = dae.Rows[i]["SC05"].ToString();
                    textBox84.Text = dae.Rows[i]["SC06"].ToString();
                }
                if (dae.Rows[i]["SC02"].ToString() == "26")
                {
                    textBox85.Text = dae.Rows[i]["SC04"].ToString();
                    textBox86.Text = dae.Rows[i]["SC05"].ToString();
                    textBox87.Text = dae.Rows[i]["SC06"].ToString();
                }
                if (dae.Rows[i]["SC02"].ToString() == "27")
                {
                    textBox88.Text = dae.Rows[i]["SC04"].ToString();
                    textBox89.Text = dae.Rows[i]["SC05"].ToString();
                    textBox90.Text = dae.Rows[i]["SC06"].ToString();
                }
                if (dae.Rows[i]["SC02"].ToString() == "28")
                {
                    textBox91.Text = dae.Rows[i]["SC04"].ToString();
                    textBox92.Text = dae.Rows[i]["SC05"].ToString();
                    textBox93.Text = dae.Rows[i]["SC06"].ToString();
                }
                if (dae.Rows[i]["SC02"].ToString() == "29")
                {
                    textBox94.Text = dae.Rows[i]["SC04"].ToString();
                    textBox95.Text = dae.Rows[i]["SC05"].ToString();
                    textBox96.Text = dae.Rows[i]["SC06"].ToString();
                }
                if (dae.Rows[i]["SC02"].ToString() == "30")
                {
                    textBox97.Text = dae.Rows[i]["SC04"].ToString();
                    textBox98.Text = dae.Rows[i]["SC05"].ToString();
                    textBox99.Text = dae.Rows[i]["SC06"].ToString();
                }
                if (dae.Rows[i]["SC02"].ToString() == "31")
                {
                    textBox100.Text = dae.Rows[i]["SC04"].ToString();
                    textBox101.Text = dae.Rows[i]["SC05"].ToString();
                    textBox102.Text = dae.Rows[i]["SC06"].ToString();
                }
            }
            #endregion
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            DataTable dt = SqlHelper.ExecuteDataTable(" SELECT KH24 FROM R_MLLKHXXCD");
            if (dt.Rows.Count < 0)
            {
                MessageBox.Show("没有数据");
            }
            else
            {
                //conb.label1.Text = "流水号";
                //conb.label2.Visible = true;
                //conb.label2.Text = "合同编号";
                //conb.textBox1.Visible = false;
                //conb.comboBox2.Visible = true;
                //conb.label2.Location = new System.Drawing.Point(25, 68);
                //conb.comboBox2.Location = new System.Drawing.Point(84, 65);
                //conb.btnSure.Location = new System.Drawing.Point(27, 105);
                //conb.btnCancel.Location = new System.Drawing.Point(148, 105);
                conb.Size = new System.Drawing.Size(265, 188);
                conb.FormBorderStyle = FormBorderStyle.FixedSingle;
                conb.PassDataBetweenForm += new R_FrmContractreviewb.PassDataBetweenFormHandler(conb_PassDataBetweenForm);
                DataTable da = SqlHelper.ExecuteDataTable("SELECT KH25 FROM R_MLLKHXXCD");
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    //conb.comboBox1.Items.Add(da.Rows[i]["KH25"].ToString());
                }

                string KH25 = "";
                DataTable de = SqlHelper.ExecuteDataTable("SELECT KH24 FROM R_MLLKHXXCD WHERE KH25=@KH25", new SqlParameter("@KH25", KH25));
                for (int i = 0; i < de.Rows.Count; i++)
                {
                    //conb.comboBox2.Items.Add(de.Rows[i]["KH24"].ToString());
                }
                conb.ShowDialog();
            }
            string HT14 = textBox3.Text;
            string HT001 = textBox4.Text;
            DataTable dd = SqlHelper.ExecuteDataTable("SELECT A.DEA002,B.HT03 FROM TPADEA A,R_MLLHTPS B WHERE A.DEA001=B.HT01 AND HT01=@HT01 AND HT14=@HT14", new SqlParameter("@HT01", HT001), new SqlParameter("@HT14", HT14));
            textBox2.Text = dd.Rows[0]["DEA002"].ToString();
            textBox6.Text = dd.Rows[0]["HT03"].ToString();
            #region 表头  表尾
            SJ02 = textBox1.Text;
            if (checkBox1.Checked)
            {
                textBox7.Enabled = true;
                SJ03 = "Y" + "," + textBox7.Text;
            }
            else
            {
                SJ03 = "N";
            }
            if (checkBox2.Checked)
            {
                textBox8.Enabled = true;
                SJ04 = "Y" + "," + textBox8.Text;
            }
            else
            {
                SJ04 = "N";
            }
            if (checkBox3.Checked)
            {
                textBox9.Enabled = true;
                SJ05 = "Y" + "," + textBox9.Text;
            }
            else
            {
                SJ05 = "N";
            }
            if (checkBox4.Checked)
            {
                SJ06 = "Y";
            }
            else
            {
                SJ06 = "N";
            }
            if (radioButton1.Checked)
            {
                SJ07 = radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                SJ07 = radioButton2.Text;
            }
            else if (radioButton3.Checked)
            {
                SJ07 = radioButton3.Text;
            }
            else
            {
                MessageBox.Show("您没有选择检测次数");
            }
            if (radioButton5.Checked)
            {
                SJ08 = radioButton5.Text;
            }
            else if (radioButton6.Checked)
            {
                SJ08 = radioButton6.Text;
            }
            else
            {
                MessageBox.Show("您没有选择检测结果");
            }
            SJ09 = textBox103.Text;
            SJ10 = textBox104.Text;
            SJ11 = textBox105.Text;
            SJ12 = datatimepickeroverride1.Text;
            SJ13 = textBox108.Text;
            SJ14 = textBox109.Text;
            SJ15 = textBox110.Text;
            SJ16 = textBox111.Text;
            SJ17 = datatimepickeroverride2.Text;
            SJ18 = datatimepickeroverride3.Text;

            DataTable dta = SqlHelper.ExecuteDataTable("SELECT SJ02 FROM R_CORYSJJCBG");
            for (int i = 0; i < dta.Rows.Count; i++)
            {
                if (textBox1.Text == dta.Rows[i]["SJ02"].ToString())
                {
                    MessageBox.Show("首检测编号为:" + textBox1.Text + "的数据已经存在，无法录入重复数据");
                }
                else
                {
                    SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBG (SJ01,SJ02,SJ03,SJ04,SJ05,SJ06,SJ07,SJ08,SJ09,SJ10,SJ11,SJ12,SJ13,SJ14,SJ15,SJ16,SJ17,SJ18) VALUES (@SJ01,@SJ02,@SJ03,@SJ04,@SJ05,@SJ06,@SJ07,@SJ08,@SJ09,@SJ10,@SJ11,@SJ12,@SJ13,@SJ14,@SJ15,@SJ16,@SJ17,@SJ18)",new SqlParameter("@SJ01",SJ01), new SqlParameter("@SJ02", SJ02), new SqlParameter("@SJ03", SJ03), new SqlParameter("@SJ04", SJ04), new SqlParameter("@SJ05", SJ06), new SqlParameter("@SJ07", SJ07), new SqlParameter("@SJ08", SJ08), new SqlParameter("@SJ09", SJ09), new SqlParameter("@SJ10", SJ10), new SqlParameter("@SJ11", SJ11), new SqlParameter("@SJ12", SJ12), new SqlParameter("@SJ13", SJ13), new SqlParameter("@SJ14", SJ14), new SqlParameter("@SJ15", SJ15), new SqlParameter("@SJ16", SJ16), new SqlParameter("@SJ17", SJ17), new SqlParameter("@SJ18", SJ18));
                }
            }
            #endregion
            #region 表中
            DataTable dte = SqlHelper.ExecuteDataTable("SELECT SC01,SC02 FROM R_CORYSJJCBGA");
            for (int i = 0; i < dte.Rows.Count; i++)
            {
                if (dte.Rows[0]["SC01"].ToString() == label7.Text && dte.Rows[0]["SC02"].ToString() == label9.Text)
                {
                    MessageBox.Show("首检测编号为:" + textBox1.Text + " 检验项目名称为" + label9.Text + "的数据已经存在,无法录入重复数据");
                }
                else
                {
                    if (label7.Text == "1")
                    {
                        SC02 = label7.Text;
                        SC03 = label9.Text;
                        SC04 = textBox10.Text;
                        SC05 = textBox11.Text;
                        SC06 = textBox12.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                    }
                    if (label10.Text == "2")
                    {
                        SC02 = label10.Text;
                        SC03 = label11.Text;
                        SC04 = textBox13.Text;
                        SC05 = textBox14.Text;
                        SC06 = textBox15.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                    }
                    if (label12.Text == "3")
                    {
                        SC02 = label12.Text;
                        SC03 = label13.Text;
                        SC04 = textBox16.Text;
                        SC05 = textBox17.Text;
                        SC06 = textBox18.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                    }
                    if (label14.Text == "4")
                    {
                        SC02 = label14.Text;
                        SC03 = label15.Text;
                        SC04 = textBox19.Text;
                        SC05 = textBox20.Text;
                        SC06 = textBox21.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                    }
                    if (label16.Text == "5")
                    {
                        SC02 = label16.Text;
                        SC03 = label17.Text;
                        SC04 = textBox22.Text;
                        SC05 = textBox23.Text;
                        SC06 = textBox24.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                    }
                    if (label18.Text == "6")
                    {
                        SC02 = label18.Text;
                        SC03 = label19.Text;
                        SC04 = textBox25.Text;
                        SC05 = textBox26.Text;
                        SC06 = textBox27.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                    }
                    if (label20.Text == "7")
                    {
                        SC02 = label20.Text;
                        SC03 = label21.Text;
                        SC04 = textBox28.Text;
                        SC05 = textBox29.Text;
                        SC06 = textBox30.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                    }
                    if (label22.Text == "8")
                    {
                        SC02 = label22.Text;
                        SC03 = label23.Text;
                        SC04 = textBox31.Text;
                        SC05 = textBox32.Text;
                        SC06 = textBox33.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                    }
                    if (label24.Text == "9")
                    {
                        SC02 = label24.Text;
                        SC03 = label25.Text;
                        SC04 = textBox34.Text;
                        SC05 = textBox35.Text;
                        SC06 = textBox36.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                    }
                    if (label26.Text == "10")
                    {
                        SC02 = label26.Text;
                        SC03 = label27.Text;
                        SC04 = textBox37.Text;
                        SC05 = textBox38.Text;
                        SC06 = textBox39.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                    }
                    if (label28.Text == "11")
                    {
                        SC02 = label28.Text;
                        SC03 = label29.Text;
                        SC04 = textBox40.Text;
                        SC05 = textBox41.Text;
                        SC06 = textBox42.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                    }
                    if (label30.Text == "12")
                    {
                        SC02 = label30.Text;
                        SC03 = label31.Text;
                        SC04 = textBox43.Text;
                        SC05 = textBox46.Text;
                        SC06 = textBox47.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                    }
                    if (label32.Text == "13")
                    {
                        SC02 = label32.Text;
                        SC03 = label33.Text;
                        SC04 = textBox44.Text;
                        SC05 = textBox48.Text;
                        SC06 = textBox49.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                    }
                    if (label34.Text == "14")
                    {
                        SC02 = label35.Text;
                        SC03 = label36.Text;
                        SC04 = textBox45.Text;
                        SC05 = textBox50.Text;
                        SC06 = textBox51.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                    }
                    if (label36.Text == "15")
                    {
                        SC02 = label36.Text;
                        SC03 = label37.Text;
                        SC04 = textBox52.Text;
                        SC05 = textBox53.Text;
                        SC06 = textBox54.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                    }
                    if (label38.Text == "16")
                    {
                        SC02 = label38.Text;
                        SC03 = label39.Text;
                        SC04 = textBox55.Text;
                        SC05 = textBox56.Text;
                        SC06 = textBox57.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                    }
                    if (label40.Text == "17")
                    {
                        SC02 = label40.Text;
                        SC03 = label41.Text;
                        SC04 = textBox58.Text;
                        SC05 = textBox59.Text;
                        SC06 = textBox60.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                    }
                    if (label42.Text == "18")
                    {
                        SC02 = label42.Text;
                        SC03 = label43.Text;
                        SC04 = textBox61.Text;
                        SC05 = textBox62.Text;
                        SC06 = textBox63.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                    }
                    if (label44.Text == "19")
                    {
                        SC02 = label44.Text;
                        SC03 = label45.Text;
                        SC04 = textBox64.Text;
                        SC05 = textBox65.Text;
                        SC06 = textBox66.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                    }
                    if (label46.Text == "20")
                    {
                        SC02 = label46.Text;
                        SC03 = label47.Text;
                        SC04 = textBox67.Text;
                        SC05 = textBox68.Text;
                        SC06 = textBox69.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                    }
                    if (label48.Text == "21")
                    {
                        SC02 = label48.Text;
                        SC03 = label49.Text;
                        SC04 = textBox70.Text;
                        SC05 = textBox71.Text;
                        SC06 = textBox72.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                    }
                    if (label50.Text == "22")
                    {
                        SC02 = label50.Text;
                        SC03 = label51.Text;
                        SC04 = textBox73.Text;
                        SC05 = textBox74.Text;
                        SC06 = textBox75.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                    }
                    if (label52.Text == "23")
                    {
                        SC02 = label52.Text;
                        SC03 = label53.Text;
                        SC04 = textBox76.Text;
                        SC05 = textBox77.Text;
                        SC06 = textBox78.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                    }
                    if (label54.Text == "24")
                    {
                        SC02 = label54.Text;
                        SC03 = label55.Text;
                        SC04 = textBox79.Text;
                        SC05 = textBox80.Text;
                        SC06 = textBox81.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                    }
                    if (label56.Text == "25")
                    {
                        SC02 = label56.Text;
                        SC03 = label57.Text;
                        SC04 = textBox82.Text;
                        SC05 = textBox83.Text;
                        SC06 = textBox84.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                    }
                    if (label58.Text == "26")
                    {
                        SC02 = label58.Text;
                        SC03 = label59.Text;
                        SC04 = textBox85.Text;
                        SC05 = textBox86.Text;
                        SC06 = textBox87.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                    }
                    if (label60.Text == "27")
                    {
                        SC02 = label60.Text;
                        SC03 = label61.Text;
                        SC04 = textBox88.Text;
                        SC05 = textBox89.Text;
                        SC06 = textBox90.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                    }
                    if (label62.Text == "28")
                    {
                        SC02 = label62.Text;
                        SC03 = label63.Text;
                        SC04 = textBox91.Text;
                        SC05 = textBox92.Text;
                        SC06 = textBox93.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                    }
                    if (label64.Text == "29")
                    {
                        SC02 = label64.Text;
                        SC03 = label65.Text;
                        SC04 = textBox94.Text;
                        SC05 = textBox95.Text;
                        SC06 = textBox96.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                    }
                    if (label66.Text == "30")
                    {
                        SC02 = label66.Text;
                        SC03 = label67.Text;
                        SC04 = textBox97.Text;
                        SC05 = textBox98.Text;
                        SC06 = textBox99.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                    }
                    if (label68.Text == "31")
                    {
                        SC02 = label68.Text;
                        SC03 = label69.Text;
                        SC04 = textBox100.Text;
                        SC05 = textBox101.Text;
                        SC06 = textBox102.Text;
                        SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                    }
                }
            }
            
            #endregion
        }

        private void toolDelect_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("请查询需要删除的数据");
            }
            else
            {
                SJ02 = textBox1.Text;
                string HT001 = textBox4.Text;
                SqlHelper.ExecuteNonQuery("DELETE FROM R_CORYSJJCBG WHERE SJ01=@SJ01 AND SJ02=@SJ02",new SqlParameter("@SJ01",HT001),new SqlParameter("@SJ02",SJ02));
                SqlHelper.ExecuteNonQuery("DELETE FROM R_CORYSJJCBGA WHERE SC01=@SC01",new SqlParameter("@SC01",SJ02));
                foreach (Control tx in this.Controls)
                {
                    if (tx.GetType().ToString() == "System.Windows.Forms.TextBox")
                    {
                        TextBox tb = tx as TextBox;
                        tb.Text = "";
                        continue;
                    }
                    if (tx.GetType().ToString() == "System.Windows.Forms.CheckBox")
                    {
                        CheckBox cb = tx as CheckBox;
                        cb.Checked = false;
                    }
                    if (tx.GetType().ToString() == "System.Windows.Forms.RadioButton")
                    {
                        RadioButton rb = tx as RadioButton;
                        rb.Checked = false;
                    }
                }
            }
        }

        private void toolUpdate_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("请查询需要更改的数据");
            }
            else
            {
                DataTable da = SqlHelper.ExecuteDataTable("SELECT SJ02 FROM R_CORYSJJCBG");
                for (int j = 0; j < da.Rows.Count; j++)
                {
                    if (da.Rows[j]["SJ02"].ToString() == textBox1.Text)
                    {
                        #region  更改原有数据
                        #region 表头  表尾
                        SJ02 = textBox1.Text;
                        if (checkBox1.Checked)
                        {
                            textBox7.Enabled = true;
                            SJ03 = "Y" + "," + textBox7.Text;
                        }
                        else
                        {
                            SJ03 = "N";
                        }
                        if (checkBox2.Checked)
                        {
                            textBox8.Enabled = true;
                            SJ04 = "Y" + "," + textBox8.Text;
                        }
                        else
                        {
                            SJ04 = "N";
                        }
                        if (checkBox3.Checked)
                        {
                            textBox9.Enabled = true;
                            SJ05 = "Y" + "," + textBox9.Text;
                        }
                        else
                        {
                            SJ05 = "N";
                        }
                        if (checkBox4.Checked)
                        {
                            SJ06 = "Y";
                        }
                        else
                        {
                            SJ06 = "N";
                        }
                        if (radioButton1.Checked)
                        {
                            SJ07 = radioButton1.Text;
                        }
                        else if (radioButton2.Checked)
                        {
                            SJ07 = radioButton2.Text;
                        }
                        else if (radioButton3.Checked)
                        {
                            SJ07 = radioButton3.Text;
                        }
                        else
                        {
                            MessageBox.Show("您没有选择检测次数");
                        }
                        if (radioButton5.Checked)
                        {
                            SJ08 = radioButton5.Text;
                        }
                        else if (radioButton6.Checked)
                        {
                            SJ08 = radioButton6.Text;
                        }
                        else
                        {
                            MessageBox.Show("您没有选择检测结果");
                        }
                        SJ09 = textBox103.Text;
                        SJ10 = textBox104.Text;
                        SJ11 = textBox105.Text;
                        SJ12 = datatimepickeroverride1.Text;
                        SJ13 = textBox108.Text;
                        SJ14 = textBox109.Text;
                        SJ15 = textBox110.Text;
                        SJ16 = textBox111.Text;
                        SJ17 = datatimepickeroverride2.Text;
                        SJ18 = datatimepickeroverride3.Text;

                        DataTable dta = SqlHelper.ExecuteDataTable("SELECT SJ02 FROM R_CORYSJJCBG");
                        for (int i = 0; i < dta.Rows.Count; i++)
                        {
                            if (textBox1.Text == dta.Rows[i]["SJ02"].ToString())
                            {
                                MessageBox.Show("首检测编号为:" + textBox1.Text + "的数据已经存在，无法录入重复数据");
                            }
                            else
                            {
                                SqlHelper.ExecuteNonQuery("UPDATE R_CORYSJJCBG SET SJ01=@SJ01,SJ03=@SJ03,SJ04=@SJ04,SJ05=@SJ05,SJ06=@SJ06,SJ07=@SJ07,SJ08=@SJ08,SJ09=@SJ09,SJ10=@SJ10,SJ11=@SJ11,SJ12=@SJ12,SJ13=@SJ13,SJ14=@SJ14,SJ15=@SJ15,SJ16=@SJ16,SJ17=@SJ17,SJ18=@SJ18 WHERE SJ02=@SJ02", new SqlParameter("@SJ01", SJ01), new SqlParameter("@SJ02", SJ02), new SqlParameter("@SJ03", SJ03), new SqlParameter("@SJ04", SJ04), new SqlParameter("@SJ05", SJ06), new SqlParameter("@SJ07", SJ07), new SqlParameter("@SJ08", SJ08), new SqlParameter("@SJ09", SJ09), new SqlParameter("@SJ10", SJ10), new SqlParameter("@SJ11", SJ11), new SqlParameter("@SJ12", SJ12), new SqlParameter("@SJ13", SJ13), new SqlParameter("@SJ14", SJ14), new SqlParameter("@SJ15", SJ15), new SqlParameter("@SJ16", SJ16), new SqlParameter("@SJ17", SJ17), new SqlParameter("@SJ18", SJ18));
                            }
                        }
                        #endregion
                        #region 表中
                        DataTable dte = SqlHelper.ExecuteDataTable("SELECT SC01,SC02 FROM R_CORYSJJCBGA");
                        for (int i = 0; i < dte.Rows.Count; i++)
                        {
                            if (dte.Rows[0]["SC01"].ToString() == label7.Text && dte.Rows[0]["SC02"].ToString() == label9.Text)
                            {
                                MessageBox.Show("首检测编号为:" + textBox1.Text + " 检验项目名称为" + label9.Text + "的数据已经存在,无法录入重复数据");
                            }
                            else
                            {
                                if (label7.Text == "1")
                                {
                                    SC02 = label7.Text;
                                    SC03 = label9.Text;
                                    SC04 = textBox10.Text;
                                    SC05 = textBox11.Text;
                                    SC06 = textBox12.Text;
                                    SqlHelper.ExecuteNonQuery("UPDATE R_CORYSJJCBGA SET SC02=@SC02,SC03=@SC03,SC04=@SC04,SC05=@SC05,SC06=@SC06 WHERE SC01=@SC01", new SqlParameter("@SC01", SJ02), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label10.Text == "2")
                                {
                                    SC02 = label10.Text;
                                    SC03 = label11.Text;
                                    SC04 = textBox13.Text;
                                    SC05 = textBox14.Text;
                                    SC06 = textBox15.Text;
                                    SqlHelper.ExecuteNonQuery("UPDATE R_CORYSJJCBGA SET SC02=@SC02,SC03=@SC03,SC04=@SC04,SC05=@SC05,SC06=@SC06 WHERE SC01=@SC01", new SqlParameter("@SC01", SJ02), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label12.Text == "3")
                                {
                                    SC02 = label12.Text;
                                    SC03 = label13.Text;
                                    SC04 = textBox16.Text;
                                    SC05 = textBox17.Text;
                                    SC06 = textBox18.Text;
                                    SqlHelper.ExecuteNonQuery("UPDATE R_CORYSJJCBGA SET SC02=@SC02,SC03=@SC03,SC04=@SC04,SC05=@SC05,SC06=@SC06 WHERE SC01=@SC01", new SqlParameter("@SC01", SJ02), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label14.Text == "4")
                                {
                                    SC02 = label14.Text;
                                    SC03 = label15.Text;
                                    SC04 = textBox19.Text;
                                    SC05 = textBox20.Text;
                                    SC06 = textBox21.Text;
                                    SqlHelper.ExecuteNonQuery("UPDATE R_CORYSJJCBGA SET SC02=@SC02,SC03=@SC03,SC04=@SC04,SC05=@SC05,SC06=@SC06 WHERE SC01=@SC01", new SqlParameter("@SC01", SJ02), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label16.Text == "5")
                                {
                                    SC02 = label16.Text;
                                    SC03 = label17.Text;
                                    SC04 = textBox22.Text;
                                    SC05 = textBox23.Text;
                                    SC06 = textBox24.Text;
                                    SqlHelper.ExecuteNonQuery("UPDATE R_CORYSJJCBGA SET SC02=@SC02,SC03=@SC03,SC04=@SC04,SC05=@SC05,SC06=@SC06 WHERE SC01=@SC01", new SqlParameter("@SC01", SJ02), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label18.Text == "6")
                                {
                                    SC02 = label18.Text;
                                    SC03 = label19.Text;
                                    SC04 = textBox25.Text;
                                    SC05 = textBox26.Text;
                                    SC06 = textBox27.Text;
                                    SqlHelper.ExecuteNonQuery("UPDATE R_CORYSJJCBGA SET SC02=@SC02,SC03=@SC03,SC04=@SC04,SC05=@SC05,SC06=@SC06 WHERE SC01=@SC01", new SqlParameter("@SC01", SJ02), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label20.Text == "7")
                                {
                                    SC02 = label20.Text;
                                    SC03 = label21.Text;
                                    SC04 = textBox28.Text;
                                    SC05 = textBox29.Text;
                                    SC06 = textBox30.Text;
                                    SqlHelper.ExecuteNonQuery("UPDATE R_CORYSJJCBGA SET SC02=@SC02,SC03=@SC03,SC04=@SC04,SC05=@SC05,SC06=@SC06 WHERE SC01=@SC01", new SqlParameter("@SC01", SJ02), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label22.Text == "8")
                                {
                                    SC02 = label22.Text;
                                    SC03 = label23.Text;
                                    SC04 = textBox31.Text;
                                    SC05 = textBox32.Text;
                                    SC06 = textBox33.Text;
                                    SqlHelper.ExecuteNonQuery("UPDATE R_CORYSJJCBGA SET SC02=@SC02,SC03=@SC03,SC04=@SC04,SC05=@SC05,SC06=@SC06 WHERE SC01=@SC01", new SqlParameter("@SC01", SJ02), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label24.Text == "9")
                                {
                                    SC02 = label24.Text;
                                    SC03 = label25.Text;
                                    SC04 = textBox34.Text;
                                    SC05 = textBox35.Text;
                                    SC06 = textBox36.Text;
                                    SqlHelper.ExecuteNonQuery("UPDATE R_CORYSJJCBGA SET SC02=@SC02,SC03=@SC03,SC04=@SC04,SC05=@SC05,SC06=@SC06 WHERE SC01=@SC01", new SqlParameter("@SC01", SJ02), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label26.Text == "10")
                                {
                                    SC02 = label26.Text;
                                    SC03 = label27.Text;
                                    SC04 = textBox37.Text;
                                    SC05 = textBox38.Text;
                                    SC06 = textBox39.Text;
                                    SqlHelper.ExecuteNonQuery("UPDATE R_CORYSJJCBGA SET SC02=@SC02,SC03=@SC03,SC04=@SC04,SC05=@SC05,SC06=@SC06 WHERE SC01=@SC01", new SqlParameter("@SC01", SJ02), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label28.Text == "11")
                                {
                                    SC02 = label28.Text;
                                    SC03 = label29.Text;
                                    SC04 = textBox40.Text;
                                    SC05 = textBox41.Text;
                                    SC06 = textBox42.Text;
                                    SqlHelper.ExecuteNonQuery("UPDATE R_CORYSJJCBGA SET SC02=@SC02,SC03=@SC03,SC04=@SC04,SC05=@SC05,SC06=@SC06 WHERE SC01=@SC01", new SqlParameter("@SC01", SJ02), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label30.Text == "12")
                                {
                                    SC02 = label30.Text;
                                    SC03 = label31.Text;
                                    SC04 = textBox43.Text;
                                    SC05 = textBox46.Text;
                                    SC06 = textBox47.Text;
                                    SqlHelper.ExecuteNonQuery("UPDATE R_CORYSJJCBGA SET SC02=@SC02,SC03=@SC03,SC04=@SC04,SC05=@SC05,SC06=@SC06 WHERE SC01=@SC01", new SqlParameter("@SC01", SJ02), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label32.Text == "13")
                                {
                                    SC02 = label32.Text;
                                    SC03 = label33.Text;
                                    SC04 = textBox44.Text;
                                    SC05 = textBox48.Text;
                                    SC06 = textBox49.Text;
                                    SqlHelper.ExecuteNonQuery("UPDATE R_CORYSJJCBGA SET SC02=@SC02,SC03=@SC03,SC04=@SC04,SC05=@SC05,SC06=@SC06 WHERE SC01=@SC01", new SqlParameter("@SC01", SJ02), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label34.Text == "14")
                                {
                                    SC02 = label35.Text;
                                    SC03 = label36.Text;
                                    SC04 = textBox45.Text;
                                    SC05 = textBox50.Text;
                                    SC06 = textBox51.Text;
                                    SqlHelper.ExecuteNonQuery("UPDATE R_CORYSJJCBGA SET SC02=@SC02,SC03=@SC03,SC04=@SC04,SC05=@SC05,SC06=@SC06 WHERE SC01=@SC01", new SqlParameter("@SC01", SJ02), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label36.Text == "15")
                                {
                                    SC02 = label36.Text;
                                    SC03 = label37.Text;
                                    SC04 = textBox52.Text;
                                    SC05 = textBox53.Text;
                                    SC06 = textBox54.Text;
                                    SqlHelper.ExecuteNonQuery("UPDATE R_CORYSJJCBGA SET SC02=@SC02,SC03=@SC03,SC04=@SC04,SC05=@SC05,SC06=@SC06 WHERE SC01=@SC01", new SqlParameter("@SC01", SJ02), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label38.Text == "16")
                                {
                                    SC02 = label38.Text;
                                    SC03 = label39.Text;
                                    SC04 = textBox55.Text;
                                    SC05 = textBox56.Text;
                                    SC06 = textBox57.Text;
                                    SqlHelper.ExecuteNonQuery("UPDATE R_CORYSJJCBGA SET SC02=@SC02,SC03=@SC03,SC04=@SC04,SC05=@SC05,SC06=@SC06 WHERE SC01=@SC01", new SqlParameter("@SC01", SJ02), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label40.Text == "17")
                                {
                                    SC02 = label40.Text;
                                    SC03 = label41.Text;
                                    SC04 = textBox58.Text;
                                    SC05 = textBox59.Text;
                                    SC06 = textBox60.Text;
                                    SqlHelper.ExecuteNonQuery("UPDATE R_CORYSJJCBGA SET SC02=@SC02,SC03=@SC03,SC04=@SC04,SC05=@SC05,SC06=@SC06 WHERE SC01=@SC01", new SqlParameter("@SC01", SJ02), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label42.Text == "18")
                                {
                                    SC02 = label42.Text;
                                    SC03 = label43.Text;
                                    SC04 = textBox61.Text;
                                    SC05 = textBox62.Text;
                                    SC06 = textBox63.Text;
                                    SqlHelper.ExecuteNonQuery("UPDATE R_CORYSJJCBGA SET SC02=@SC02,SC03=@SC03,SC04=@SC04,SC05=@SC05,SC06=@SC06 WHERE SC01=@SC01", new SqlParameter("@SC01", SJ02), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label44.Text == "19")
                                {
                                    SC02 = label44.Text;
                                    SC03 = label45.Text;
                                    SC04 = textBox64.Text;
                                    SC05 = textBox65.Text;
                                    SC06 = textBox66.Text;
                                    SqlHelper.ExecuteNonQuery("UPDATE R_CORYSJJCBGA SET SC02=@SC02,SC03=@SC03,SC04=@SC04,SC05=@SC05,SC06=@SC06 WHERE SC01=@SC01", new SqlParameter("@SC01", SJ02), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label46.Text == "20")
                                {
                                    SC02 = label46.Text;
                                    SC03 = label47.Text;
                                    SC04 = textBox67.Text;
                                    SC05 = textBox68.Text;
                                    SC06 = textBox69.Text;
                                    SqlHelper.ExecuteNonQuery("UPDATE R_CORYSJJCBGA SET SC02=@SC02,SC03=@SC03,SC04=@SC04,SC05=@SC05,SC06=@SC06 WHERE SC01=@SC01", new SqlParameter("@SC01", SJ02), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label48.Text == "21")
                                {
                                    SC02 = label48.Text;
                                    SC03 = label49.Text;
                                    SC04 = textBox70.Text;
                                    SC05 = textBox71.Text;
                                    SC06 = textBox72.Text;
                                    SqlHelper.ExecuteNonQuery("UPDATE R_CORYSJJCBGA SET SC02=@SC02,SC03=@SC03,SC04=@SC04,SC05=@SC05,SC06=@SC06 WHERE SC01=@SC01", new SqlParameter("@SC01", SJ02), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label50.Text == "22")
                                {
                                    SC02 = label50.Text;
                                    SC03 = label51.Text;
                                    SC04 = textBox73.Text;
                                    SC05 = textBox74.Text;
                                    SC06 = textBox75.Text;
                                    SqlHelper.ExecuteNonQuery("UPDATE R_CORYSJJCBGA SET SC02=@SC02,SC03=@SC03,SC04=@SC04,SC05=@SC05,SC06=@SC06 WHERE SC01=@SC01", new SqlParameter("@SC01", SJ02), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label52.Text == "23")
                                {
                                    SC02 = label52.Text;
                                    SC03 = label53.Text;
                                    SC04 = textBox76.Text;
                                    SC05 = textBox77.Text;
                                    SC06 = textBox78.Text;
                                    SqlHelper.ExecuteNonQuery("UPDATE R_CORYSJJCBGA SET SC02=@SC02,SC03=@SC03,SC04=@SC04,SC05=@SC05,SC06=@SC06 WHERE SC01=@SC01", new SqlParameter("@SC01", SJ02), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label54.Text == "24")
                                {
                                    SC02 = label54.Text;
                                    SC03 = label55.Text;
                                    SC04 = textBox79.Text;
                                    SC05 = textBox80.Text;
                                    SC06 = textBox81.Text;
                                    SqlHelper.ExecuteNonQuery("UPDATE R_CORYSJJCBGA SET SC02=@SC02,SC03=@SC03,SC04=@SC04,SC05=@SC05,SC06=@SC06 WHERE SC01=@SC01", new SqlParameter("@SC01", SJ02), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label56.Text == "25")
                                {
                                    SC02 = label56.Text;
                                    SC03 = label57.Text;
                                    SC04 = textBox82.Text;
                                    SC05 = textBox83.Text;
                                    SC06 = textBox84.Text;
                                    SqlHelper.ExecuteNonQuery("UPDATE R_CORYSJJCBGA SET SC02=@SC02,SC03=@SC03,SC04=@SC04,SC05=@SC05,SC06=@SC06 WHERE SC01=@SC01", new SqlParameter("@SC01", SJ02), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label58.Text == "26")
                                {
                                    SC02 = label58.Text;
                                    SC03 = label59.Text;
                                    SC04 = textBox85.Text;
                                    SC05 = textBox86.Text;
                                    SC06 = textBox87.Text;
                                    SqlHelper.ExecuteNonQuery("UPDATE R_CORYSJJCBGA SET SC02=@SC02,SC03=@SC03,SC04=@SC04,SC05=@SC05,SC06=@SC06 WHERE SC01=@SC01", new SqlParameter("@SC01", SJ02), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label60.Text == "27")
                                {
                                    SC02 = label60.Text;
                                    SC03 = label61.Text;
                                    SC04 = textBox88.Text;
                                    SC05 = textBox89.Text;
                                    SC06 = textBox90.Text;
                                    SqlHelper.ExecuteNonQuery("UPDATE R_CORYSJJCBGA SET SC02=@SC02,SC03=@SC03,SC04=@SC04,SC05=@SC05,SC06=@SC06 WHERE SC01=@SC01", new SqlParameter("@SC01", SJ02), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label62.Text == "28")
                                {
                                    SC02 = label62.Text;
                                    SC03 = label63.Text;
                                    SC04 = textBox91.Text;
                                    SC05 = textBox92.Text;
                                    SC06 = textBox93.Text;
                                    SqlHelper.ExecuteNonQuery("UPDATE R_CORYSJJCBGA SET SC02=@SC02,SC03=@SC03,SC04=@SC04,SC05=@SC05,SC06=@SC06 WHERE SC01=@SC01", new SqlParameter("@SC01", SJ02), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label64.Text == "29")
                                {
                                    SC02 = label64.Text;
                                    SC03 = label65.Text;
                                    SC04 = textBox94.Text;
                                    SC05 = textBox95.Text;
                                    SC06 = textBox96.Text;
                                    SqlHelper.ExecuteNonQuery("UPDATE R_CORYSJJCBGA SET SC02=@SC02,SC03=@SC03,SC04=@SC04,SC05=@SC05,SC06=@SC06 WHERE SC01=@SC01", new SqlParameter("@SC01", SJ02), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label66.Text == "30")
                                {
                                    SC02 = label66.Text;
                                    SC03 = label67.Text;
                                    SC04 = textBox97.Text;
                                    SC05 = textBox98.Text;
                                    SC06 = textBox99.Text;
                                    SqlHelper.ExecuteNonQuery("UPDATE R_CORYSJJCBGA SET SC02=@SC02,SC03=@SC03,SC04=@SC04,SC05=@SC05,SC06=@SC06 WHERE SC01=@SC01", new SqlParameter("@SC01", SJ02), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label68.Text == "31")
                                {
                                    SC02 = label68.Text;
                                    SC03 = label69.Text;
                                    SC04 = textBox100.Text;
                                    SC05 = textBox101.Text;
                                    SC06 = textBox102.Text;
                                    SqlHelper.ExecuteNonQuery("UPDATE R_CORYSJJCBGA SET SC02=@SC02,SC03=@SC03,SC04=@SC04,SC05=@SC05,SC06=@SC06 WHERE SC01=@SC01", new SqlParameter("@SC01", SJ02), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                            }
                        }

                        #endregion
                        #endregion

                    }
                    else
                    {
                        #region  插入新的数据

                        #region 表头  表尾
                        SJ02 = textBox1.Text;
                        if (checkBox1.Checked)
                        {
                            textBox7.Enabled = true;
                            SJ03 = "Y" + "," + textBox7.Text;
                        }
                        else
                        {
                            SJ03 = "N";
                        }
                        if (checkBox2.Checked)
                        {
                            textBox8.Enabled = true;
                            SJ04 = "Y" + "," + textBox8.Text;
                        }
                        else
                        {
                            SJ04 = "N";
                        }
                        if (checkBox3.Checked)
                        {
                            textBox9.Enabled = true;
                            SJ05 = "Y" + "," + textBox9.Text;
                        }
                        else
                        {
                            SJ05 = "N";
                        }
                        if (checkBox4.Checked)
                        {
                            SJ06 = "Y";
                        }
                        else
                        {
                            SJ06 = "N";
                        }
                        if (radioButton1.Checked)
                        {
                            SJ07 = radioButton1.Text;
                        }
                        else if (radioButton2.Checked)
                        {
                            SJ07 = radioButton2.Text;
                        }
                        else if (radioButton3.Checked)
                        {
                            SJ07 = radioButton3.Text;
                        }
                        else
                        {
                            MessageBox.Show("您没有选择检测次数");
                        }
                        if (radioButton5.Checked)
                        {
                            SJ08 = radioButton5.Text;
                        }
                        else if (radioButton6.Checked)
                        {
                            SJ08 = radioButton6.Text;
                        }
                        else
                        {
                            MessageBox.Show("您没有选择检测结果");
                        }
                        SJ09 = textBox103.Text;
                        SJ10 = textBox104.Text;
                        SJ11 = textBox105.Text;
                        SJ12 = datatimepickeroverride1.Text;
                        SJ13 = textBox108.Text;
                        SJ14 = textBox109.Text;
                        SJ15 = textBox110.Text;
                        SJ16 = textBox111.Text;
                        SJ17 = datatimepickeroverride2.Text;
                        SJ18 = datatimepickeroverride3.Text;

                        DataTable dta = SqlHelper.ExecuteDataTable("SELECT SJ02 FROM R_CORYSJJCBG");
                        for (int i = 0; i < dta.Rows.Count; i++)
                        {
                            if (textBox1.Text == dta.Rows[i]["SJ02"].ToString())
                            {
                                MessageBox.Show("首检测编号为:" + textBox1.Text + "的数据已经存在，无法录入重复数据");
                            }
                            else
                            {
                                SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBG (SJ01,SJ02,SJ03,SJ04,SJ05,SJ06,SJ07,SJ08,SJ09,SJ10,SJ11,SJ12,SJ13,SJ14,SJ15,SJ16,SJ17,SJ18) VALUES (@SJ01,@SJ02,@SJ03,@SJ04,@SJ05,@SJ06,@SJ07,@SJ08,@SJ09,@SJ10,@SJ11,@SJ12,@SJ13,@SJ14,@SJ15,@SJ16,@SJ17,@SJ18)", new SqlParameter("@SJ01", SJ01), new SqlParameter("@SJ02", SJ02), new SqlParameter("@SJ03", SJ03), new SqlParameter("@SJ04", SJ04), new SqlParameter("@SJ05", SJ06), new SqlParameter("@SJ07", SJ07), new SqlParameter("@SJ08", SJ08), new SqlParameter("@SJ09", SJ09), new SqlParameter("@SJ10", SJ10), new SqlParameter("@SJ11", SJ11), new SqlParameter("@SJ12", SJ12), new SqlParameter("@SJ13", SJ13), new SqlParameter("@SJ14", SJ14), new SqlParameter("@SJ15", SJ15), new SqlParameter("@SJ16", SJ16), new SqlParameter("@SJ17", SJ17), new SqlParameter("@SJ18", SJ18));
                            }
                        }
                        #endregion
                        #region 表中
                        DataTable dte = SqlHelper.ExecuteDataTable("SELECT SC01,SC02 FROM R_CORYSJJCBGA");
                        for (int i = 0; i < dte.Rows.Count; i++)
                        {
                            if (dte.Rows[0]["SC01"].ToString() == label7.Text && dte.Rows[0]["SC02"].ToString() == label9.Text)
                            {
                                MessageBox.Show("首检测编号为:" + textBox1.Text + " 检验项目名称为" + label9.Text + "的数据已经存在,无法录入重复数据");
                            }
                            else
                            {
                                if (label7.Text == "1")
                                {
                                    SC02 = label7.Text;
                                    SC03 = label9.Text;
                                    SC04 = textBox10.Text;
                                    SC05 = textBox11.Text;
                                    SC06 = textBox12.Text;
                                    SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label10.Text == "2")
                                {
                                    SC02 = label10.Text;
                                    SC03 = label11.Text;
                                    SC04 = textBox13.Text;
                                    SC05 = textBox14.Text;
                                    SC06 = textBox15.Text;
                                    SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label12.Text == "3")
                                {
                                    SC02 = label12.Text;
                                    SC03 = label13.Text;
                                    SC04 = textBox16.Text;
                                    SC05 = textBox17.Text;
                                    SC06 = textBox18.Text;
                                    SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label14.Text == "4")
                                {
                                    SC02 = label14.Text;
                                    SC03 = label15.Text;
                                    SC04 = textBox19.Text;
                                    SC05 = textBox20.Text;
                                    SC06 = textBox21.Text;
                                    SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label16.Text == "5")
                                {
                                    SC02 = label16.Text;
                                    SC03 = label17.Text;
                                    SC04 = textBox22.Text;
                                    SC05 = textBox23.Text;
                                    SC06 = textBox24.Text;
                                    SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label18.Text == "6")
                                {
                                    SC02 = label18.Text;
                                    SC03 = label19.Text;
                                    SC04 = textBox25.Text;
                                    SC05 = textBox26.Text;
                                    SC06 = textBox27.Text;
                                    SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label20.Text == "7")
                                {
                                    SC02 = label20.Text;
                                    SC03 = label21.Text;
                                    SC04 = textBox28.Text;
                                    SC05 = textBox29.Text;
                                    SC06 = textBox30.Text;
                                    SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label22.Text == "8")
                                {
                                    SC02 = label22.Text;
                                    SC03 = label23.Text;
                                    SC04 = textBox31.Text;
                                    SC05 = textBox32.Text;
                                    SC06 = textBox33.Text;
                                    SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label24.Text == "9")
                                {
                                    SC02 = label24.Text;
                                    SC03 = label25.Text;
                                    SC04 = textBox34.Text;
                                    SC05 = textBox35.Text;
                                    SC06 = textBox36.Text;
                                    SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label26.Text == "10")
                                {
                                    SC02 = label26.Text;
                                    SC03 = label27.Text;
                                    SC04 = textBox37.Text;
                                    SC05 = textBox38.Text;
                                    SC06 = textBox39.Text;
                                    SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label28.Text == "11")
                                {
                                    SC02 = label28.Text;
                                    SC03 = label29.Text;
                                    SC04 = textBox40.Text;
                                    SC05 = textBox41.Text;
                                    SC06 = textBox42.Text;
                                    SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label30.Text == "12")
                                {
                                    SC02 = label30.Text;
                                    SC03 = label31.Text;
                                    SC04 = textBox43.Text;
                                    SC05 = textBox46.Text;
                                    SC06 = textBox47.Text;
                                    SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label32.Text == "13")
                                {
                                    SC02 = label32.Text;
                                    SC03 = label33.Text;
                                    SC04 = textBox44.Text;
                                    SC05 = textBox48.Text;
                                    SC06 = textBox49.Text;
                                    SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label34.Text == "14")
                                {
                                    SC02 = label35.Text;
                                    SC03 = label36.Text;
                                    SC04 = textBox45.Text;
                                    SC05 = textBox50.Text;
                                    SC06 = textBox51.Text;
                                    SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label36.Text == "15")
                                {
                                    SC02 = label36.Text;
                                    SC03 = label37.Text;
                                    SC04 = textBox52.Text;
                                    SC05 = textBox53.Text;
                                    SC06 = textBox54.Text;
                                    SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label38.Text == "16")
                                {
                                    SC02 = label38.Text;
                                    SC03 = label39.Text;
                                    SC04 = textBox55.Text;
                                    SC05 = textBox56.Text;
                                    SC06 = textBox57.Text;
                                    SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label40.Text == "17")
                                {
                                    SC02 = label40.Text;
                                    SC03 = label41.Text;
                                    SC04 = textBox58.Text;
                                    SC05 = textBox59.Text;
                                    SC06 = textBox60.Text;
                                    SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label42.Text == "18")
                                {
                                    SC02 = label42.Text;
                                    SC03 = label43.Text;
                                    SC04 = textBox61.Text;
                                    SC05 = textBox62.Text;
                                    SC06 = textBox63.Text;
                                    SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label44.Text == "19")
                                {
                                    SC02 = label44.Text;
                                    SC03 = label45.Text;
                                    SC04 = textBox64.Text;
                                    SC05 = textBox65.Text;
                                    SC06 = textBox66.Text;
                                    SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label46.Text == "20")
                                {
                                    SC02 = label46.Text;
                                    SC03 = label47.Text;
                                    SC04 = textBox67.Text;
                                    SC05 = textBox68.Text;
                                    SC06 = textBox69.Text;
                                    SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label48.Text == "21")
                                {
                                    SC02 = label48.Text;
                                    SC03 = label49.Text;
                                    SC04 = textBox70.Text;
                                    SC05 = textBox71.Text;
                                    SC06 = textBox72.Text;
                                    SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label50.Text == "22")
                                {
                                    SC02 = label50.Text;
                                    SC03 = label51.Text;
                                    SC04 = textBox73.Text;
                                    SC05 = textBox74.Text;
                                    SC06 = textBox75.Text;
                                    SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label52.Text == "23")
                                {
                                    SC02 = label52.Text;
                                    SC03 = label53.Text;
                                    SC04 = textBox76.Text;
                                    SC05 = textBox77.Text;
                                    SC06 = textBox78.Text;
                                    SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label54.Text == "24")
                                {
                                    SC02 = label54.Text;
                                    SC03 = label55.Text;
                                    SC04 = textBox79.Text;
                                    SC05 = textBox80.Text;
                                    SC06 = textBox81.Text;
                                    SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label56.Text == "25")
                                {
                                    SC02 = label56.Text;
                                    SC03 = label57.Text;
                                    SC04 = textBox82.Text;
                                    SC05 = textBox83.Text;
                                    SC06 = textBox84.Text;
                                    SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label58.Text == "26")
                                {
                                    SC02 = label58.Text;
                                    SC03 = label59.Text;
                                    SC04 = textBox85.Text;
                                    SC05 = textBox86.Text;
                                    SC06 = textBox87.Text;
                                    SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label60.Text == "27")
                                {
                                    SC02 = label60.Text;
                                    SC03 = label61.Text;
                                    SC04 = textBox88.Text;
                                    SC05 = textBox89.Text;
                                    SC06 = textBox90.Text;
                                    SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label62.Text == "28")
                                {
                                    SC02 = label62.Text;
                                    SC03 = label63.Text;
                                    SC04 = textBox91.Text;
                                    SC05 = textBox92.Text;
                                    SC06 = textBox93.Text;
                                    SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label64.Text == "29")
                                {
                                    SC02 = label64.Text;
                                    SC03 = label65.Text;
                                    SC04 = textBox94.Text;
                                    SC05 = textBox95.Text;
                                    SC06 = textBox96.Text;
                                    SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label66.Text == "30")
                                {
                                    SC02 = label66.Text;
                                    SC03 = label67.Text;
                                    SC04 = textBox97.Text;
                                    SC05 = textBox98.Text;
                                    SC06 = textBox99.Text;
                                    SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                                if (label68.Text == "31")
                                {
                                    SC02 = label68.Text;
                                    SC03 = label69.Text;
                                    SC04 = textBox100.Text;
                                    SC05 = textBox101.Text;
                                    SC06 = textBox102.Text;
                                    SqlHelper.ExecuteNonQuery("INSERT INTO R_CORYSJJCBGA (SC01,SC02,SC03,SC04,SC05,SC06) VALUES(@SC01,@SC02,@SC03,@SC04,@SC05,@SC06)", new SqlParameter("@SC01", SJ01), new SqlParameter("@SC02", SC02), new SqlParameter("@SC03", SC03), new SqlParameter("@SC04", SC04), new SqlParameter("@SC05", SC05), new SqlParameter("@SC06", SC06));
                                }
                            }
                        }
                        #endregion

                        #endregion
                    }
                }
            }
        }

        private void conb_PassDataBetweenForm(object sender, PassDataWinFormEventArgs e)
        {
            this.textBox5.Text = e.ConOne;
            this.textBox3.Text = e.ConTwo;
        }
    }
}

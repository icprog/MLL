using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StudentMgr;
using Mulaolao.Environmental;
using Mulaolao.Class;

namespace Mulaolao.Environmental
{
    public partial class R_Frmhegegongfanshenhe : Form
    {
        public R_Frmhegegongfanshenhe( Form1 fm )
        {
            this.MdiParent = fm;
            InitializeComponent();
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        Picichaxun ph = new Picichaxun();
        private void R_Frmhegegongfanshenhe_Load( object sender, EventArgs e )
        {
            //下达人
            DataTable da = SqlHelper.ExecuteDataTable("SELECT DBA002 FROM TPADBA");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                comboBoxEdit1.Properties.Items.Add(da.Rows[i]["DBA002"].ToString());
            }
            //审核部门
            DataTable dt = SqlHelper.ExecuteDataTable("SELECT DAA002 FROM TPADAA");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBoxEdit2.Properties.Items.Add(dt.Rows[i]["DAA002"].ToString());
            }

            //代码
            List<string> dm = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R" };
            foreach (string st in dm)
            {
                comboBoxEdit4.Properties.Items.Add(st);
                comboBoxEdit10.Properties.Items.Add(st);
                comboBoxEdit9.Properties.Items.Add(st);
            }
            //品牌及物料名称
            DataTable dw = SqlHelper.ExecuteDataTable("SELECT DEA962,DEA963 FROM TPADEA");
            for (int i = 0; i < dw.Rows.Count; i++)
            {
                comboBoxEdit5.Properties.Items.Add(dw.Rows[i]["DEA962"].ToString() + "','" + dw.Rows[i]["DEA963"].ToString());
            }
            //法规标准
            List<string> ls = new List<string>() { "供方检测结果限量值级类别", "法人工程师口答值级(类)别", "供方承诺保证限量值级类别", "我方送测值" };
            foreach (string lt in ls)
            {
                comboBoxEdit6.Properties.Items.Add(lt);
            }
            //多环芳香限量
            List<string> lg = new List<string>() { "一类", "二类", "三类" };
            foreach (string g in lg)
            {
                comboBoxEdit7.Properties.Items.Add(g);
            }
            //重金属
            List<string> li = new List<string>() { "欧盟", "美国", "加拿大", "日本", "其它国家标准" };
            foreach (string i in li)
            {
                comboBoxEdit8.Properties.Items.Add(i);
            }
        }

        private void comboBoxEdit2_SelectedValueChanged( object sender, EventArgs e )
        {
            //审核人
            string daa002 = comboBoxEdit2.Text;
            DataTable de = SqlHelper.ExecuteDataTable("SELECT DBA002 FROM TPADBA WHERE DBA005=(SELECT DAA001 FROM TPADAA WHERE DAA002=@DAA002)", new SqlParameter("@DAA002", daa002));
            for (int i = 0; i < de.Rows.Count; i++)
            {
                comboBoxEdit3.Properties.Items.Add(de.Rows[i]["DBA002"].ToString());
            }
        }
        DataTable det;
        private void toolSelect_Click( object sender, EventArgs e )
        {
            DataTable del = SqlHelper.ExecuteDataTable("SELECT WL01 FROM R_HGGFHXPWLSH");
            if (del.Rows.Count < 0)
            {
                MessageBox.Show("没有数据");
            }
            else
            {
                for (int i = 0; i < del.Rows.Count; i++)
                {
                    ph.comboBox1.Items.Add(del.Rows[i]["WL01"].ToString());
                }
                ph.PassDataBetweenForm += new Picichaxun.PassDataBetweenFormHandler(ph_PassDataBetweenForm);
                ph.ShowDialog();

                det = SqlHelper.ExecuteDataTable("SELECT WL02,WL03,WL04,WL05,WL06,WL07,WL08 FROM R_HGGFHXPWLSH WHERE WL01=@WL01", new SqlParameter("@WL01", textBox35.Text));
                comboBoxEdit1.Text = det.Rows[0]["WL02"].ToString();
                comboBoxEdit2.Text = det.Rows[0]["WL03"].ToString();
                comboBoxEdit3.Text = det.Rows[0]["WL04"].ToString();
                textBox30.Text = det.Rows[0]["WL05"].ToString();
                textBox31.Text = det.Rows[0]["WL06"].ToString();
                textBox32.Text = det.Rows[0]["WL07"].ToString();
                textBox33.Text = det.Rows[0]["WL08"].ToString();

                gridControl1.DataSource = det;
                gridControl2.DataSource = det;
                gridControl3.DataSource = det;
            }
        }
        private void ph_PassDataBetweenForm( object sender, PassDataWinFormEventArgs e )
        {
            this.textBox35.Text = e.ConOne;
        }

        private void toolAdd_Click( object sender, EventArgs e )
        {
            if (comboBoxEdit1.Text == "")
            {
                MessageBox.Show("请填写计划下达人");
            }
            else
            {
                DataTable dde = SqlHelper.ExecuteDataTable("SELECT WL01,WL02,WL13 FROM R_HGGFHXPWLSH");
                if (dde.Rows.Count < 0)
                {
                    DateTime WL05, WL06, WL07, WL08;
                    if (textBox30.Text == "")
                    {
                        WL05 = Convert.ToDateTime(null);
                    }
                    else
                    {
                        WL05 = Convert.ToDateTime(textBox30.Text);
                    }
                    if (textBox31.Text == "")
                    {
                        WL06 = Convert.ToDateTime(null);
                    }
                    else
                    {
                        WL06 = Convert.ToDateTime(textBox31.Text);
                    }
                    if (textBox32.Text == "")
                    {
                        WL07 = Convert.ToDateTime(null);
                    }
                    else
                    {
                        WL07 = Convert.ToDateTime(textBox32.Text);
                    }
                    if (textBox33.Text == "")
                    {
                        WL08 = Convert.ToDateTime(null);
                    }
                    else
                    {
                        WL08 = Convert.ToDateTime(textBox33.Text);
                    }
                    int count = SqlHelper.ExecuteNonQuery("INSERT INTO R_HGGFHXPWLSH (WL01,WL02,WL03,WL04,WL05,WL06,WL07,WL08) VALUES (@WL02,@WL03,@WL04,@WL05,@WL06,@WL07,@WL08) WHERE WL01=@WL01", new SqlParameter("@WL01", textBox35.Text), new SqlParameter("@WL02", comboBoxEdit1.Text), new SqlParameter("@WL03", comboBoxEdit2.Text), new SqlParameter("@WL04", comboBoxEdit3.Text), new SqlParameter("@WL05", WL05), new SqlParameter("@WL06", WL06), new SqlParameter("@WL07", WL07), new SqlParameter("@WL08", WL08), new SqlParameter("@WL01", textBox35.Text));
                    if (count < 0)
                    {
                        MessageBox.Show("录入数据失败");
                    }
                    else
                    {
                        MessageBox.Show("成功录入数据");
                    }
                }
                else
                {
                    for (int i = 0; i < dde.Rows.Count; i++)
                    {
                        if (dde.Rows[i]["WL02"].ToString() == comboBoxEdit1.Text && dde.Rows[i]["WL13"].ToString() == textBox4.Text)
                        {
                            MessageBox.Show("数据已经存在,请核实后再操作");
                        }
                        else
                        {
                            DateTime WL05, WL06, WL07, WL08;
                            if (textBox30.Text == "")
                            {
                                WL05 = Convert.ToDateTime(null);
                            }
                            else
                            {
                                WL05 = Convert.ToDateTime(textBox30.Text);
                            }
                            if (textBox31.Text == "")
                            {
                                WL06 = Convert.ToDateTime(null);
                            }
                            else
                            {
                                WL06 = Convert.ToDateTime(textBox31.Text);
                            }
                            if (textBox32.Text == "")
                            {
                                WL07 = Convert.ToDateTime(null);
                            }
                            else
                            {
                                WL07 = Convert.ToDateTime(textBox32.Text);
                            }
                            if (textBox33.Text == "")
                            {
                                WL08 = Convert.ToDateTime(null);
                            }
                            else
                            {
                                WL08 = Convert.ToDateTime(textBox33.Text);
                            }
                            int count = SqlHelper.ExecuteNonQuery("INSERT INTO R_HGGFHXPWLSH (WL02,WL03,WL04,WL05,WL06,WL07,WL08) VALUES (@WL02,@WL03,@WL04,@WL05,@WL06,@WL07,@WL08) WHERE WL01=@WL01", new SqlParameter("@WL01", textBox35.Text), new SqlParameter("@WL02", comboBoxEdit1.Text), new SqlParameter("@WL03", comboBoxEdit2.Text), new SqlParameter("@WL04", comboBoxEdit3.Text), new SqlParameter("@WL05", WL05), new SqlParameter("@WL06", WL06), new SqlParameter("@WL07", WL07), new SqlParameter("@WL08", WL08));
                            if (count < 0)
                            {
                                MessageBox.Show("录入数据失败");
                            }
                            else
                            {
                                MessageBox.Show("成功录入数据");
                            }
                        }
                    }
                }
            }
        }

        private void toolDelete_Click( object sender, EventArgs e )
        {
            if (textBox4.Text == "" || comboBoxEdit1.Text == "")
            {
                MessageBox.Show("请选择要删除的信息");
            }
            else
            {
                foreach (Control cs in this.Controls)
                {
                    if (cs.GetType().ToString() == "System.Windows.Forms.TextBox")
                    {
                        TextBox tb = cs as TextBox;
                        tb.Text = "";
                        continue;
                    }
                    comboBoxEdit1.Text = "";
                    comboBoxEdit2.Text = "";
                    comboBoxEdit3.Text = "";
                }

                int count = SqlHelper.ExecuteNonQuery("DELETE FROM R_HGGFHXPWLSH WHERE WL01=@WL01", new SqlParameter("@WL01", textBox35.Text));
                if (count < 0)
                {
                    MessageBox.Show("删除数据失败");
                }
                else
                {
                    MessageBox.Show("成功删除数据");
                }
            }
        }

        private void toolUpdate_Click( object sender, EventArgs e )
        {
            if (comboBoxEdit1.Text == "")
            {
                MessageBox.Show("请选择需要更改的信息");
            }
            else
            {
                int count = SqlHelper.ExecuteNonQuery("UPDATE R_HGGFHXPWLSH SET WL02=@WL02,WL03=@WL03,WL04=@WL04,WL05=@WL05,WL06=@WL06,WL07=@WL07,WL08=@WL08 WHERE WL01=@WL01", new SqlParameter("@WL01", textBox35.Text), new SqlParameter("@WL02", comboBoxEdit1.Text), new SqlParameter("@WL03", comboBoxEdit2.Text), new SqlParameter("@WL04", comboBoxEdit3.Text), new SqlParameter("@WL05", Convert.ToDateTime(textBox30.Text)), new SqlParameter("@WL06", Convert.ToDateTime(textBox31.Text)), new SqlParameter("@WL07", Convert.ToDateTime(textBox32.Text)), new SqlParameter("@WL08", Convert.ToDateTime(textBox33.Text)));
                if (count < 0)
                {
                    MessageBox.Show("数据更新失败");
                }
                else
                {
                    MessageBox.Show("成功更新数据");
                }
            }
        }

        private void toolReview_Click( object sender, EventArgs e )
        {
            //int count = ReviewES.Revie(this,reve, Logins.number);
            //if (count < 0)
            //{
            //    MessageBox.Show("送审失败");
            //}
            //else
            //{
            //    MessageBox.Show("成功送审");
            //}
        }
        //新建
        private void button1_Click( object sender, EventArgs e )
        {
            foreach (Control ct in this.groupBox2.Controls)
            {
                if (ct.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    TextBox tb = ct as TextBox;
                    if (tb.Text == "")
                    {
                        MessageBox.Show("有部分内容为空,请填写");
                    }
                }
                else
                {
                    if (comboBoxEdit4.Text == "" || comboBoxEdit5.Text == "")
                    {
                        MessageBox.Show("您有单选内容没有选择");
                    }
                    else
                    {
                        DataTable dtl = SqlHelper.ExecuteDataTable("SELECT * FROM R_HGGFHXPWLSH");
                        if (dtl.Rows.Count < 0)
                        {
                            DataRow row = det.NewRow();
                            row["WL01"] = textBox35.Text;
                            row["WL09"] = textBox2.Text;
                            row["WL10"] = comboBoxEdit4.Text;
                            row["WL11"] = textBox3.Text;
                            row["WL12"] = comboBoxEdit5.Text;
                            row["WL13"] = textBox4.Text;
                            row["WL14"] = textBox5.Text;
                            row["WL15"] = textBox6.Text;
                            row["WL16"] = textBox7.Text;
                            row["WL17"] = textBox8.Text;
                            row["WL18"] = textBox9.Text;
                            row["WL19"] = textBox10.Text;
                            row["WL20"] = Convert.ToDateTime(textBox34.Text);
                            row["WL21"] = textBox11.Text;
                            row["WL22"] = textBox12.Text;
                            row["WL23"] = textBox13.Text;
                            row["WL24"] = textBox14.Text;
                            row["WL25"] = textBox15.Text;
                            row["WL26"] = textBox16.Text;
                            det.Rows.Add(row);

                            SqlHelper.ExecuteNonQuery("INSERT INTO R_HGGFHXPWLSH (WL01,WL09,WL10,WL11,WL12,WL13,WL14,WL15,WL16,WL17,WL18,WL19,WL20,WL21,WL22,WL23,WL24,WL25,WL26) VALUES (@WL01,@WL09,@WL10,@WL11,@WL12,@WL13,@WL14,@WL15,@WL16,@WL17,@WL18,@WL19,@WL20,@WL21,@WL22,@WL23,@WL24,@WL25,@WL26)", new SqlParameter("@WL09", textBox2.Text), new SqlParameter("@WL10", comboBoxEdit4.Text), new SqlParameter("@WL11", textBox3.Text), new SqlParameter("@WL12", comboBoxEdit5.Text), new SqlParameter("@WL13", textBox4.Text), new SqlParameter("@WL14", textBox5.Text), new SqlParameter("@WL15", textBox6.Text), new SqlParameter("@WL16", textBox7.Text), new SqlParameter("@WL17", textBox8.Text), new SqlParameter("@WL18", textBox9.Text), new SqlParameter("@WL19", textBox10.Text), new SqlParameter("@WL20", Convert.ToDateTime(textBox34.Text)), new SqlParameter("@WL21", textBox11.Text), new SqlParameter("@WL22", textBox12.Text), new SqlParameter("@WL23", textBox13.Text), new SqlParameter("@WL24", textBox14.Text), new SqlParameter("@WL25", textBox15.Text), new SqlParameter("@WL26", textBox16.Text), new SqlParameter("@WL01", textBox35.Text));
                        }
                        else
                        {
                            for (int i = 0; i < dtl.Rows.Count; i++)
                            {
                                if (textBox35.Text == dtl.Rows[i]["WL01"].ToString())
                                {
                                    DataRow row = det.NewRow();
                                    row["WL09"] = textBox2.Text;
                                    row["WL10"] = comboBoxEdit4.Text;
                                    row["WL11"] = textBox3.Text;
                                    row["WL12"] = comboBoxEdit5.Text;
                                    row["WL13"] = textBox4.Text;
                                    row["WL14"] = textBox5.Text;
                                    row["WL15"] = textBox6.Text;
                                    row["WL16"] = textBox7.Text;
                                    row["WL17"] = textBox8.Text;
                                    row["WL18"] = textBox9.Text;
                                    row["WL19"] = textBox10.Text;
                                    row["WL20"] = Convert.ToDateTime(textBox34.Text);
                                    row["WL21"] = textBox11.Text;
                                    row["WL22"] = textBox12.Text;
                                    row["WL23"] = textBox13.Text;
                                    row["WL24"] = textBox14.Text;
                                    row["WL25"] = textBox15.Text;
                                    row["WL26"] = textBox16.Text;
                                    det.Rows.Add(row);

                                    SqlHelper.ExecuteNonQuery("INSERT INTO R_HGGFHXPWLSH (WL09,WL10,WL11,WL12,WL13,WL14,WL15,WL16,WL17,WL18,WL19,WL20,WL21,WL22,WL23,WL24,WL25,WL26) VALUES (@WL09,@WL10,@WL11,@WL12,@WL13,@WL14,@WL15,@WL16,@WL17,@WL18,@WL19,@WL20,@WL21,@WL22,@WL23,@WL24,@WL25,@WL26) WHERE WL01=@WL01", new SqlParameter("@WL09", textBox2.Text), new SqlParameter("@WL10", comboBoxEdit4.Text), new SqlParameter("@WL11", textBox3.Text), new SqlParameter("@WL12", comboBoxEdit5.Text), new SqlParameter("@WL13", textBox4.Text), new SqlParameter("@WL14", textBox5.Text), new SqlParameter("@WL15", textBox6.Text), new SqlParameter("@WL16", textBox7.Text), new SqlParameter("@WL17", textBox8.Text), new SqlParameter("@WL18", textBox9.Text), new SqlParameter("@WL19", textBox10.Text), new SqlParameter("@WL20", Convert.ToDateTime(textBox34.Text)), new SqlParameter("@WL21", textBox11.Text), new SqlParameter("@WL22", textBox12.Text), new SqlParameter("@WL23", textBox13.Text), new SqlParameter("@WL24", textBox14.Text), new SqlParameter("@WL25", textBox15.Text), new SqlParameter("@WL26", textBox16.Text), new SqlParameter("@WL01", textBox35.Text));
                                }
                                else
                                {
                                    DataRow row = det.NewRow();
                                    row["WL01"] = textBox35.Text;
                                    row["WL09"] = textBox2.Text;
                                    row["WL10"] = comboBoxEdit4.Text;
                                    row["WL11"] = textBox3.Text;
                                    row["WL12"] = comboBoxEdit5.Text;
                                    row["WL13"] = textBox4.Text;
                                    row["WL14"] = textBox5.Text;
                                    row["WL15"] = textBox6.Text;
                                    row["WL16"] = textBox7.Text;
                                    row["WL17"] = textBox8.Text;
                                    row["WL18"] = textBox9.Text;
                                    row["WL19"] = textBox10.Text;
                                    row["WL20"] = Convert.ToDateTime(textBox34.Text);
                                    row["WL21"] = textBox11.Text;
                                    row["WL22"] = textBox12.Text;
                                    row["WL23"] = textBox13.Text;
                                    row["WL24"] = textBox14.Text;
                                    row["WL25"] = textBox15.Text;
                                    row["WL26"] = textBox16.Text;
                                    det.Rows.Add(row);

                                    SqlHelper.ExecuteNonQuery("INSERT INTO R_HGGFHXPWLSH (WL01,WL09,WL10,WL11,WL12,WL13,WL14,WL15,WL16,WL17,WL18,WL19,WL20,WL21,WL22,WL23,WL24,WL25,WL26) VALUES (@WL01,@WL09,@WL10,@WL11,@WL12,@WL13,@WL14,@WL15,@WL16,@WL17,@WL18,@WL19,@WL20,@WL21,@WL22,@WL23,@WL24,@WL25,@WL26)", new SqlParameter("@WL09", textBox2.Text), new SqlParameter("@WL10", comboBoxEdit4.Text), new SqlParameter("@WL11", textBox3.Text), new SqlParameter("@WL12", comboBoxEdit5.Text), new SqlParameter("@WL13", textBox4.Text), new SqlParameter("@WL14", textBox5.Text), new SqlParameter("@WL15", textBox6.Text), new SqlParameter("@WL16", textBox7.Text), new SqlParameter("@WL17", textBox8.Text), new SqlParameter("@WL18", textBox9.Text), new SqlParameter("@WL19", textBox10.Text), new SqlParameter("@WL20", Convert.ToDateTime(textBox34.Text)), new SqlParameter("@WL21", textBox11.Text), new SqlParameter("@WL22", textBox12.Text), new SqlParameter("@WL23", textBox13.Text), new SqlParameter("@WL24", textBox14.Text), new SqlParameter("@WL25", textBox15.Text), new SqlParameter("@WL26", textBox16.Text), new SqlParameter("@WL01", textBox35.Text));
                                }
                            }
                        }

                    }
                }
            }
        }
        //更新
        private void button2_Click( object sender, EventArgs e )
        {
            foreach (Control ct in this.groupBox2.Controls)
            {
                if (ct.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    TextBox tb = ct as TextBox;
                    if (tb.Text == "")
                    {
                        MessageBox.Show("有部分内容为空,请填写");
                    }
                }
                else
                {
                    if (comboBoxEdit4.Text == "" || comboBoxEdit5.Text == "")
                    {
                        MessageBox.Show("您有单选内容没有选择");
                    }
                    else
                    {
                        int num = gridView1.FocusedRowHandle;
                        DataRow row = det.Rows[num];
                        row.BeginEdit();
                        row["WL09"] = textBox2.Text;
                        row["WL10"] = comboBoxEdit4.Text;
                        row["WL11"] = textBox3.Text;
                        row["WL12"] = comboBoxEdit5.Text;
                        row["WL13"] = textBox4.Text;
                        row["WL14"] = textBox5.Text;
                        row["WL15"] = textBox6.Text;
                        row["WL16"] = textBox7.Text;
                        row["WL17"] = textBox8.Text;
                        row["WL18"] = textBox9.Text;
                        row["WL19"] = textBox10.Text;
                        row["WL20"] = Convert.ToDateTime(textBox34.Text);
                        row["WL21"] = textBox11.Text;
                        row["WL22"] = textBox12.Text;
                        row["WL23"] = textBox13.Text;
                        row["WL24"] = textBox14.Text;
                        row["WL25"] = textBox15.Text;
                        row["WL26"] = textBox16.Text;
                        row.EndEdit();

                        SqlHelper.ExecuteNonQuery("UPDATE R_HGGFHXPWLSH SET WL09=@WL09,WL10=@WL10,WL11=@WL11,WL12=@WL12,WL13=@WL13,WL14=@WL14,WL15=@WL15,WL16=@WL16,WL17=@WL17,WL18=@WL18,WL19=@WL19,WL20=@WL20,WL21=@WL21,WL22=@WL22,WL23=@WL23,WL24=@WL24,WL25=@WL25,WL26=@WL26 WHERE WL01=@WL01",new SqlParameter("@WL01",textBox35.Text), new SqlParameter("@WL09", textBox2.Text), new SqlParameter("@WL10", comboBoxEdit4.Text), new SqlParameter("@WL11", textBox3.Text), new SqlParameter("@WL12", comboBoxEdit5.Text), new SqlParameter("@WL13", textBox4.Text), new SqlParameter("@WL14", textBox5.Text), new SqlParameter("@WL15", textBox6.Text), new SqlParameter("@WL16", textBox7.Text), new SqlParameter("@WL17", textBox8.Text), new SqlParameter("@WL18", textBox9.Text), new SqlParameter("@WL19", textBox10.Text), new SqlParameter("@WL20", Convert.ToDateTime(textBox34.Text)), new SqlParameter("@WL21", textBox11.Text), new SqlParameter("@WL22", textBox12.Text), new SqlParameter("@WL23", textBox13.Text), new SqlParameter("@WL24", textBox14.Text), new SqlParameter("@WL25", textBox15.Text), new SqlParameter("@WL26", textBox16.Text));
                    }
                }
            }
        }
        //删除
        private void button3_Click( object sender, EventArgs e )
        {
            int num = gridView1.FocusedRowHandle;
            det.Rows.RemoveAt(num);

            SqlHelper.ExecuteNonQuery("UPDATE R_HGGFHXPWLSH SET WL09=@WL09,WL10=@WL10,WL11=@WL11,WL12=@WL12,WL13=@WL13,WL14=@WL14，WL15=@WL15，WL16=@WL16，WL17=@WL17，WL18=@WL18，WL19=@WL19，WL20=@WL20，WL21=@WL21,WL22=@WL22,WL23=@WL23,WL24=@WL24,WL25=@WL25,WL26=@WL26 WHERE WL01=@WL01", new SqlParameter("@WL01", textBox35.Text), new SqlParameter("@WL09", null), new SqlParameter("@WL10", null), new SqlParameter("@WL11", null), new SqlParameter("@WL12", null), new SqlParameter("@WL13", null), new SqlParameter("@WL14", null), new SqlParameter("@WL15", null), new SqlParameter("@WL16", null), new SqlParameter("@WL17", null), new SqlParameter("@WL18", null), new SqlParameter("@WL19", null), new SqlParameter("@WL20", null), new SqlParameter("@WL21", null), new SqlParameter("@WL22", null), new SqlParameter("@WL23", null), new SqlParameter("@WL24", null), new SqlParameter("@WL25", null), new SqlParameter("@WL26", null));
        }
        //获取得到焦点的行的值
        private void gridView1_FocusedRowChanged( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
            if (gridView1.RowCount < 1)
            {
                textBox2.Text = "";
                comboBoxEdit4.Text = "";
                textBox3.Text = "";
                comboBoxEdit5.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                textBox34.Text = "";                                        
                textBox11.Text = "";
                textBox12.Text = "";
                textBox13.Text = "";
                textBox14.Text = "";
                textBox15.Text = "";
                textBox16.Text = "";
            }
            else
            {
                textBox2.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "WL09").ToString();
                comboBoxEdit4.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "WL10").ToString();
                textBox3.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "WL11").ToString();
                comboBoxEdit5.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "WL12").ToString();
                textBox4.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "WL13").ToString();
                textBox5.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "WL14").ToString();
                textBox6.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "WL15").ToString();
                textBox7.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "WL16").ToString();
                textBox8.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "WL17").ToString();
                textBox9.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "WL18").ToString();
                textBox10.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "WL19").ToString();
                textBox34.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "WL20").ToString();
                textBox11.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "WL21").ToString();
                textBox12.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "WL22").ToString();
                textBox13.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "WL23").ToString();
                textBox14.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "WL24").ToString();
                textBox15.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "WL25").ToString();
                textBox16.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "WL26").ToString();
            }
        }
        //新建
        private void button4_Click( object sender, EventArgs e )
        {
            foreach (Control ct in this.groupBox5.Controls)
            {
                if (ct.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    TextBox tb = ct as TextBox;
                    if (tb.Text == "")
                    {
                        MessageBox.Show("有部分内容为空,请填写");
                    }
                }
                else
                {
                    if (comboBoxEdit10.Text == "")
                    {
                        MessageBox.Show("您有单选内容没有选择");
                    }
                    else
                    {
                        DataTable dtl = SqlHelper.ExecuteDataTable("SELECT * FROM R_HGGFHXPWLSH");
                        if (dtl.Rows.Count < 0)
                        {
                            DataRow row = det.NewRow();
                            row["WL01"] = textBox35.Text;
                            row["WL27"] = comboBoxEdit10.Text;
                            row["WL28"] = textBox17.Text;
                            row["WL29"] = textBox18.Text;
                            row["WL30"] = textBox19.Text;
                            row["WL31"] = textBox20.Text;
                            row["WL32"] = textBox21.Text;
                            row["WL33"] = textBox27.Text;
                            row["WL34"] = textBox22.Text;
                            row["WL35"] = textBox24.Text;
                            row["WL36"] = textBox25.Text;
                            row["WL37"] = textBox26.Text;
                            row["WL38"] = textBox23.Text;
                            row["WL39"] = textBox28.Text;
                            det.Rows.Add(row);

                            SqlHelper.ExecuteNonQuery("INSERT INTO R_HGGFHXPWLSH (WL01,WL27,WL28,WL29,WL30,WL31,WL32,WL33,WL34,WL35,WL36,WL37,WL38,WL39) VALUES (@WL01,@WL27,@WL28,@WL29,@WL30,@WL31,@WL32,@WL33,@WL34,@WL35,@WL36,@WL37,@WL38,@WL39)", new SqlParameter("@WL01", textBox35.Text), new SqlParameter("@WL27", comboBoxEdit10.Text), new SqlParameter("@WL28", textBox17.Text), new SqlParameter("@WL29", textBox18.Text), new SqlParameter("@WL30", textBox19.Text), new SqlParameter("@WL31", textBox20.Text), new SqlParameter("@WL32", textBox21.Text), new SqlParameter("@WL33", textBox27.Text), new SqlParameter("@WL34", textBox22.Text), new SqlParameter("@WL35", textBox24.Text), new SqlParameter("@WL36", textBox25.Text), new SqlParameter("@WL37", textBox26.Text), new SqlParameter("@WL38", textBox23.Text), new SqlParameter("@WL39", textBox28.Text));
                        }
                        else
                        {
                            for (int i = 0; i < dtl.Rows.Count; i++)
                            {
                                if (textBox35.Text == dtl.Rows[i]["WL01"].ToString())
                                {
                                    DataRow row = det.NewRow();
                                    row["WL27"] = comboBoxEdit10.Text;
                                    row["WL28"] = textBox17.Text;
                                    row["WL29"] = textBox18.Text;
                                    row["WL30"] = textBox19.Text;
                                    row["WL31"] = textBox20.Text;
                                    row["WL32"] = textBox21.Text;
                                    row["WL33"] = textBox27.Text;
                                    row["WL34"] = textBox22.Text;
                                    row["WL35"] = textBox24.Text;
                                    row["WL36"] = textBox25.Text;
                                    row["WL37"] = textBox26.Text;
                                    row["WL38"] = textBox23.Text;
                                    row["WL39"] = textBox28.Text;
                                    det.Rows.Add(row);

                                    SqlHelper.ExecuteNonQuery("INSERT INTO R_HGGFHXPWLSH (WL27,WL28,WL29,WL30,WL31,WL32,WL33,WL34,WL35,WL36,WL37,WL38,WL39) VALUES (@WL27,@WL28,@WL29,@WL30,@WL31,@WL32,@WL33,@WL34,@WL35,@WL36,@WL37,@WL38,@WL39) WHERE WL01=@WL01", new SqlParameter("@WL01", textBox35.Text), new SqlParameter("@WL27", comboBoxEdit10.Text), new SqlParameter("@WL28", textBox17.Text), new SqlParameter("@WL29", textBox18.Text), new SqlParameter("@WL30", textBox19.Text), new SqlParameter("@WL31", textBox20.Text), new SqlParameter("@WL32", textBox21.Text), new SqlParameter("@WL33", textBox27.Text), new SqlParameter("@WL34", textBox22.Text), new SqlParameter("@WL35", textBox24.Text), new SqlParameter("@WL36", textBox25.Text), new SqlParameter("@WL37", textBox26.Text), new SqlParameter("@WL38", textBox23.Text), new SqlParameter("@WL39", textBox28.Text));
                                }
                                else
                                {
                                    DataRow row = det.NewRow();
                                    row["WL01"] = textBox35.Text;
                                    row["WL27"] = comboBoxEdit10.Text;
                                    row["WL28"] = textBox17.Text;
                                    row["WL29"] = textBox18.Text;
                                    row["WL30"] = textBox19.Text;
                                    row["WL31"] = textBox20.Text;
                                    row["WL32"] = textBox21.Text;
                                    row["WL33"] = textBox27.Text;
                                    row["WL34"] = textBox22.Text;
                                    row["WL35"] = textBox24.Text;
                                    row["WL36"] = textBox25.Text;
                                    row["WL37"] = textBox26.Text;
                                    row["WL38"] = textBox23.Text;
                                    row["WL39"] = textBox28.Text;
                                    det.Rows.Add(row);

                                    SqlHelper.ExecuteNonQuery("INSERT INTO R_HGGFHXPWLSH (WL01,WL27,WL28,WL29,WL30,WL31,WL32,WL33,WL34,WL35,WL36,WL37,WL38,WL39) VALUES (@WL01,@WL27,@WL28,@WL29,@WL30,@WL31,@WL32,@WL33,@WL34,@WL35,@WL36,@WL37,@WL38,@WL39)", new SqlParameter("@WL01", textBox35.Text), new SqlParameter("@WL27", comboBoxEdit10.Text), new SqlParameter("@WL28", textBox17.Text), new SqlParameter("@WL29", textBox18.Text), new SqlParameter("@WL30", textBox19.Text), new SqlParameter("@WL31", textBox20.Text), new SqlParameter("@WL32", textBox21.Text), new SqlParameter("@WL33", textBox27.Text), new SqlParameter("@WL34", textBox22.Text), new SqlParameter("@WL35", textBox24.Text), new SqlParameter("@WL36", textBox25.Text), new SqlParameter("@WL37", textBox26.Text), new SqlParameter("@WL38", textBox23.Text), new SqlParameter("@WL39", textBox28.Text));
                                }
                            }
                        }
                    }
                }
            }
        }
        //更新
        private void button5_Click( object sender, EventArgs e )
        {
            foreach (Control ct in this.groupBox5.Controls)
            {
                if (ct.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    TextBox tb = ct as TextBox;
                    if (tb.Text == "")
                    {
                        MessageBox.Show("有部分内容为空,请填写");
                    }
                }
                else
                {
                    if (comboBoxEdit10.Text == "")
                    {
                        MessageBox.Show("您有单选内容没有选择");
                    }
                    else
                    {
                        int num = gridView2.FocusedRowHandle;
                        DataRow row = det.Rows[num];
                        row.BeginEdit();
                        row["WL27"] = comboBoxEdit10.Text;
                        row["WL28"] = textBox17.Text;
                        row["WL29"] = textBox18.Text;
                        row["WL30"] = textBox19.Text;
                        row["WL31"] = textBox20.Text;
                        row["WL32"] = textBox21.Text;
                        row["WL33"] = textBox27.Text;
                        row["WL34"] = textBox22.Text;
                        row["WL35"] = textBox24.Text;
                        row["WL36"] = textBox25.Text;
                        row["WL37"] = textBox26.Text;
                        row["WL38"] = textBox23.Text;
                        row["WL39"] = textBox28.Text;
                        row.EndEdit();

                        SqlHelper.ExecuteNonQuery("UPDATE R_HGGFHXPWLSH SET WL27=@WL27,WL28=@WL28,WL29=@WL29,WL30=@WL30,WL31=@WL31,WL32=@WL32,WL33=@WL33,WL34=@WL34,WL35=@WL35,WL36=@WL36,WL37=@WL27,WL38=@WL38,WL39=@WL39 WHERE WL01=@WL01", new SqlParameter("@WL01", textBox35.Text), new SqlParameter("@WL27", comboBoxEdit10.Text), new SqlParameter("@WL28", textBox17.Text), new SqlParameter("@WL29", textBox18.Text), new SqlParameter("@WL30", textBox19.Text), new SqlParameter("@WL31", textBox20.Text), new SqlParameter("@WL32", textBox21.Text), new SqlParameter("@WL33", textBox27.Text), new SqlParameter("@WL34",textBox22.Text), new SqlParameter("@WL35", textBox24.Text), new SqlParameter("@WL36", textBox25.Text), new SqlParameter("@WL37", textBox26.Text), new SqlParameter("@WL38", textBox23.Text), new SqlParameter("@WL39", textBox28.Text));
                    }
                }
            }
        }
        //删除
        private void button6_Click( object sender, EventArgs e )
        {
            int num = gridView2.FocusedRowHandle;
            det.Rows.RemoveAt(num);

            SqlHelper.ExecuteNonQuery("UPDATE R_HGGFHXPWLSH SET WL27=@WL27,WL28=@WL28,WL29=@WL29,WL30=@WL30,WL31=@WL31,WL32=@WL32,WL33=@WL33,WL34=@WL34,WL35=@WL35,WL36=@WL36,WL37=@WL27,WL38=@WL38,WL39=@WL39 WHERE WL01=@WL01", new SqlParameter("@WL01", textBox35.Text), new SqlParameter("@WL27",null), new SqlParameter("@WL28", null), new SqlParameter("@WL29", null), new SqlParameter("@WL30", null), new SqlParameter("@WL31", null), new SqlParameter("@WL32", null), new SqlParameter("@WL33", null), new SqlParameter("@WL34", null), new SqlParameter("@WL35", null), new SqlParameter("@WL36", null), new SqlParameter("@WL37", null), new SqlParameter("@WL38", null), new SqlParameter("@WL39", null));
        }
        //获取得到焦点的行的值
        private void gridView2_FocusedRowChanged( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
            if (gridView2.RowCount < 1)
            {
                comboBoxEdit10.Text = "";
                textBox17.Text = "";
                textBox18.Text = "";
                textBox19.Text = "";
                textBox20.Text = "";
                textBox21.Text = "";
                textBox27.Text = "";
                textBox22.Text = "";
                textBox24.Text = "";
                textBox25.Text = "";
                textBox26.Text = "";
                textBox23.Text = "";
                textBox28.Text = "";
            }
            else
            {
                comboBoxEdit10.Text = gridView2.GetRowCellValue(e.FocusedRowHandle, "ML27").ToString();
                textBox17.Text = gridView2.GetRowCellValue(e.FocusedRowHandle, "ML28").ToString();
                textBox18.Text = gridView2.GetRowCellValue(e.FocusedRowHandle, "ML29").ToString();
                textBox19.Text = gridView2.GetRowCellValue(e.FocusedRowHandle, "ML30").ToString();
                textBox20.Text = gridView2.GetRowCellValue(e.FocusedRowHandle, "ML31").ToString();
                textBox21.Text = gridView2.GetRowCellValue(e.FocusedRowHandle, "ML32").ToString();
                textBox27.Text = gridView2.GetRowCellValue(e.FocusedRowHandle, "ML33").ToString();
                textBox22.Text = gridView2.GetRowCellValue(e.FocusedRowHandle, "ML34").ToString();
                textBox24.Text = gridView2.GetRowCellValue(e.FocusedRowHandle, "ML35").ToString();
                textBox25.Text = gridView2.GetRowCellValue(e.FocusedRowHandle, "ML36").ToString();
                textBox26.Text = gridView2.GetRowCellValue(e.FocusedRowHandle, "ML37").ToString();
                textBox23.Text = gridView2.GetRowCellValue(e.FocusedRowHandle, "ML38").ToString();
                textBox28.Text = gridView2.GetRowCellValue(e.FocusedRowHandle, "ML39").ToString();
            }
        }
        //新建
        private void button9_Click( object sender, EventArgs e )
        {
            if (comboBoxEdit9.Text == "")
            {
                MessageBox.Show("请选择代号");
            }
            else
            {
                if (comboBoxEdit6.Text == "")
                {
                    MessageBox.Show("请选择法规限量");
                }
                else
                {
                    if (comboBoxEdit7.Text == "")
                    {
                        MessageBox.Show("请选择多环芳香限量的类别");
                    }
                    else
                    {
                        if (comboBoxEdit8.Text == "")
                        {
                            MessageBox.Show("请选择重金属相关");
                        }
                        else
                        {
                            string WL42 = "",WL421="",WL422="", WL44 = "", WL45 = "", WL46 = "", WL47 = "", WL48 = "", WL49 = "";
                            DataTable dtl = SqlHelper.ExecuteDataTable("SELECT * FROM R_HGGFHXPWLSH");
                            if (dtl.Rows.Count < 0)
                            {
                                DataRow row = det.NewRow();
                                row["WL01"] = textBox35.Text;
                                row["WL40"] = comboBoxEdit6.Text;
                                row["WL41"] = comboBoxEdit9.Text;
                                if (comboBoxEdit7.Text == "一类")
                                {
                                    row["WL42"] = comboBoxEdit7.Text;
                                    WL42 = comboBoxEdit7.Text;
                                }
                                else if (comboBoxEdit7.Text == "二类")
                                {
                                    row["WL421"] = comboBoxEdit7.Text;
                                    WL421 = comboBoxEdit7.Text;
                                }
                                else
                                {
                                    row["WL422"] = comboBoxEdit7.Text;
                                    WL422 = comboBoxEdit7.Text;
                                }
                                row["WL43"] = comboBoxEdit8.Text;
                                if (checkEdit1.Checked)
                                {
                                    row["WL44"] = "符合";
                                    WL44 = "符合";
                                }
                                else
                                {
                                    row["WL44"] = "不符合";
                                    WL44 = "不符合";
                                }
                                if (checkEdit2.Checked)
                                {
                                    row["WL45"] = "符合";
                                    WL45 = "符合";
                                }
                                else
                                {
                                    row["WL45"] = "不符合";
                                    WL45 = "不符合";
                                }
                                if (checkEdit3.Checked)
                                {
                                    row["WL46"] = "符合";
                                    WL46 = "符合";
                                }
                                else
                                {
                                    row["WL46"] = "不符合";
                                    WL46 = "不符合";
                                }
                                if (checkEdit4.Checked)
                                {
                                    row["WL47"] = "符合";
                                    WL47 = "符合";
                                }
                                else
                                {
                                    row["WL47"] = "不符合";
                                    WL47 = "不符合";
                                }
                                if (checkEdit5.Checked)
                                {
                                    row["WL48"] = "符合";
                                    WL48 = "符合";
                                }
                                else
                                {
                                    row["WL48"] = "不符合";
                                    WL48 = "不符合";
                                }
                                if (checkEdit6.Checked)
                                {
                                    row["WL49"] = "符合";
                                    WL49 = "符合";
                                }
                                else
                                {
                                    row["WL49"] = "不符合";
                                    WL49 = "不符合";
                                }
                                row["WL50"] = textBox29.Text;
                                det.Rows.Add(row);

                                SqlHelper.ExecuteNonQuery("INSERT INTO R_HGGFHXPWLSH (WL01,WL40,WL41,WL42,WL421,WL422,WL43,WL44,WL45,WL46,WL47,WL48,WL49,WL50) VALUES (@WL01,@WL40,@WL41,@WL42,@WL421,@WL422,@WL43,@WL44,@WL45,@WL46,@WL47,@WL48,@WL49,@WL50)", new SqlParameter("@WL01", textBox35.Text), new SqlParameter("@WL40", comboBoxEdit6.Text), new SqlParameter("@WL41", comboBoxEdit9.Text), new SqlParameter("@WL42", WL42), new SqlParameter("@WL421", WL421), new SqlParameter("@WL422", WL422), new SqlParameter("@WL43", comboBoxEdit8.Text), new SqlParameter("@WL44", WL44), new SqlParameter("@WL45", WL45), new SqlParameter("@WL46", WL46), new SqlParameter("@WL47", WL47), new SqlParameter("@WL48", WL48), new SqlParameter("@WL49", WL49), new SqlParameter("@WL50", textBox29.Text));
                            }
                            else
                            {
                                for (int i = 0; i < dtl.Rows.Count; i++)
                                {
                                    if (textBox35.Text == dtl.Rows[i]["WL01"].ToString())
                                    {
                                        DataRow row = det.NewRow();
                                        row["WL01"] = textBox35.Text;
                                        row["WL40"] = comboBoxEdit6.Text;
                                        row["WL41"] = comboBoxEdit9.Text;
                                        if (comboBoxEdit7.Text == "一类")
                                        {
                                            row["WL42"] = comboBoxEdit7.Text;
                                            WL42 = comboBoxEdit7.Text;
                                        }
                                        else if (comboBoxEdit7.Text == "二类")
                                        {
                                            row["WL421"] = comboBoxEdit7.Text;
                                            WL421 = comboBoxEdit7.Text;
                                        }
                                        else
                                        {
                                            row["WL422"] = comboBoxEdit7.Text;
                                            WL422 = comboBoxEdit7.Text;
                                        }
                                        row["WL43"] = comboBoxEdit8.Text;
                                        if (checkEdit1.Checked)
                                        {
                                            row["WL44"] = "符合";
                                            WL44 = "符合";
                                        }
                                        else
                                        {
                                            row["WL44"] = "不符合";
                                            WL44 = "不符合";
                                        }
                                        if (checkEdit2.Checked)
                                        {
                                            row["WL45"] = "符合";
                                            WL45 = "符合";
                                        }
                                        else
                                        {
                                            row["WL45"] = "不符合";
                                            WL45 = "不符合";
                                        }
                                        if (checkEdit3.Checked)
                                        {
                                            row["WL46"] = "符合";
                                            WL46 = "符合";
                                        }
                                        else
                                        {
                                            row["WL46"] = "不符合";
                                            WL46 = "不符合";
                                        }
                                        if (checkEdit4.Checked)
                                        {
                                            row["WL47"] = "符合";
                                            WL47 = "符合";
                                        }
                                        else
                                        {
                                            row["WL47"] = "不符合";
                                            WL47 = "不符合";
                                        }
                                        if (checkEdit5.Checked)
                                        {
                                            row["WL48"] = "符合";
                                            WL48 = "符合";
                                        }
                                        else
                                        {
                                            row["WL48"] = "不符合";
                                            WL48 = "不符合";
                                        }
                                        if (checkEdit6.Checked)
                                        {
                                            row["WL49"] = "符合";
                                            WL49 = "符合";
                                        }
                                        else
                                        {
                                            row["WL49"] = "不符合";
                                            WL49 = "不符合";
                                        }
                                        row["WL50"] = textBox29.Text;
                                        det.Rows.Add(row);

                                        SqlHelper.ExecuteNonQuery("INSERT INTO R_HGGFHXPWLSH (WL40,WL41,WL42,WL421,WL422,WL43,WL44,WL45,WL46,WL47,WL48,WL49,WL50) VALUES (@WL40,@WL41,@WL42,@WL421,@WL422,@WL43,@WL44,@WL45,@WL46,@WL47,@WL48,@WL49,@WL50) WHERE WL01=@WL01", new SqlParameter("@WL01", textBox35.Text), new SqlParameter("@WL40", comboBoxEdit6.Text), new SqlParameter("@WL41", comboBoxEdit9.Text), new SqlParameter("@WL42", WL42), new SqlParameter("@WL421", WL421), new SqlParameter("@WL422", WL422), new SqlParameter("@WL43", comboBoxEdit8.Text), new SqlParameter("@WL44", WL44), new SqlParameter("@WL45", WL45), new SqlParameter("@WL46", WL46), new SqlParameter("@WL47", WL47), new SqlParameter("@WL48", WL48), new SqlParameter("@WL49", WL49), new SqlParameter("@WL50", textBox29.Text));
                                    }
                                    else
                                    {
                                        DataRow row = det.NewRow();
                                        row["WL01"] = textBox35.Text;
                                        row["WL40"] = comboBoxEdit6.Text;
                                        row["WL41"] = comboBoxEdit9.Text;
                                        if (comboBoxEdit7.Text == "一类")
                                        {
                                            row["WL42"] = comboBoxEdit7.Text;
                                            WL42 = comboBoxEdit7.Text;
                                        }
                                        else if (comboBoxEdit7.Text == "二类")
                                        {
                                            row["WL421"] = comboBoxEdit7.Text;
                                            WL421 = comboBoxEdit7.Text;
                                        }
                                        else
                                        {
                                            row["WL422"] = comboBoxEdit7.Text;
                                            WL422 = comboBoxEdit7.Text;
                                        }
                                        row["WL43"] = comboBoxEdit8.Text;
                                        if (checkEdit1.Checked)
                                        {
                                            row["WL44"] = "符合";
                                            WL44 = "符合";
                                        }
                                        else
                                        {
                                            row["WL44"] = "不符合";
                                            WL44 = "不符合";
                                        }
                                        if (checkEdit2.Checked)
                                        {
                                            row["WL45"] = "符合";
                                            WL45 = "符合";
                                        }
                                        else
                                        {
                                            row["WL45"] = "不符合";
                                            WL45 = "不符合";
                                        }
                                        if (checkEdit3.Checked)
                                        {
                                            row["WL46"] = "符合";
                                            WL46 = "符合";
                                        }
                                        else
                                        {
                                            row["WL46"] = "不符合";
                                            WL46 = "不符合";
                                        }
                                        if (checkEdit4.Checked)
                                        {
                                            row["WL47"] = "符合";
                                            WL47 = "符合";
                                        }
                                        else
                                        {
                                            row["WL47"] = "不符合";
                                            WL47 = "不符合";
                                        }
                                        if (checkEdit5.Checked)
                                        {
                                            row["WL48"] = "符合";
                                            WL48 = "符合";
                                        }
                                        else
                                        {
                                            row["WL48"] = "不符合";
                                            WL48 = "不符合";
                                        }
                                        if (checkEdit6.Checked)
                                        {
                                            row["WL49"] = "符合";
                                            WL49 = "符合";
                                        }
                                        else
                                        {
                                            row["WL49"] = "不符合";
                                            WL49 = "不符合";
                                        }
                                        row["WL50"] = textBox29.Text;
                                        det.Rows.Add(row);

                                        SqlHelper.ExecuteNonQuery("INSERT INTO R_HGGFHXPWLSH (WL01,WL40,WL41,WL42,WL421,WL422,WL43,WL44,WL45,WL46,WL47,WL48,WL49,WL50) VALUES (@WL01,@WL40,@WL41,@WL42,@WL421,@WL422,@WL43,@WL44,@WL45,@WL46,@WL47,@WL48,@WL49,@WL50)", new SqlParameter("@WL01", textBox35.Text), new SqlParameter("@WL40", comboBoxEdit6.Text), new SqlParameter("@WL41", comboBoxEdit9.Text), new SqlParameter("@WL42", WL42), new SqlParameter("@WL421", WL421), new SqlParameter("@WL422", WL422), new SqlParameter("@WL43", comboBoxEdit8.Text), new SqlParameter("@WL44", WL44), new SqlParameter("@WL45", WL45), new SqlParameter("@WL46", WL46), new SqlParameter("@WL47", WL47), new SqlParameter("@WL48", WL48), new SqlParameter("@WL49", WL49), new SqlParameter("@WL50", textBox29.Text));
                                    }
                                }  
                            }
                        }
                    }
                }
            }
        }
        //更新
        private void button7_Click( object sender, EventArgs e )
        {
            if (comboBoxEdit9.Text == "")
            {
                MessageBox.Show("请选择代号");
            }
            else
            {
                if (comboBoxEdit6.Text == "")
                {
                    MessageBox.Show("请选择法规限量");
                }
                else
                {
                    if (comboBoxEdit7.Text == "")
                    {
                        MessageBox.Show("请选择多环芳香限量的类别");
                    }
                    else
                    {
                        if (comboBoxEdit8.Text == "")
                        {
                            MessageBox.Show("请选择重金属相关");
                        }
                        else
                        {
                            string WL42 = "", WL421 = "", WL422 = "", WL44 = "", WL45 = "", WL46 = "", WL47 = "", WL48 = "", WL49 = "";
                            DataRow row = det.NewRow();
                            row["WL01"] = textBox35.Text;
                            row["WL40"] = comboBoxEdit6.Text;
                            row["WL41"] = comboBoxEdit9.Text;
                            if (comboBoxEdit7.Text == "一类")
                            {
                                row["WL42"] = comboBoxEdit7.Text;
                                WL42 = comboBoxEdit7.Text;
                            }
                            else if (comboBoxEdit7.Text == "二类")
                            {
                                row["WL421"] = comboBoxEdit7.Text;
                                WL421 = comboBoxEdit7.Text;
                            }
                            else
                            {
                                row["WL422"] = comboBoxEdit7.Text;
                                WL422 = comboBoxEdit7.Text;
                            }
                            row["WL43"] = comboBoxEdit8.Text;
                            if (checkEdit1.Checked)
                            {
                                row["WL44"] = "符合";
                                WL44 = "符合";
                            }
                            else
                            {
                                row["WL44"] = "不符合";
                                WL44 = "不符合";
                            }
                            if (checkEdit2.Checked)
                            {
                                row["WL45"] = "符合";
                                WL45 = "符合";
                            }
                            else
                            {
                                row["WL45"] = "不符合";
                                WL45 = "不符合";
                            }
                            if (checkEdit3.Checked)
                            {
                                row["WL46"] = "符合";
                                WL46 = "符合";
                            }
                            else
                            {
                                row["WL46"] = "不符合";
                                WL46 = "不符合";
                            }
                            if (checkEdit4.Checked)
                            {
                                row["WL47"] = "符合";
                                WL47 = "符合";
                            }
                            else
                            {
                                row["WL47"] = "不符合";
                                WL47 = "不符合";
                            }
                            if (checkEdit5.Checked)
                            {
                                row["WL48"] = "符合";
                                WL48 = "符合";
                            }
                            else
                            {
                                row["WL48"] = "不符合";
                                WL48 = "不符合";
                            }
                            if (checkEdit6.Checked)
                            {
                                row["WL49"] = "符合";
                                WL49 = "符合";
                            }
                            else
                            {
                                row["WL49"] = "不符合";
                                WL49 = "不符合";
                            }
                            row["WL50"] = textBox29.Text;
                            det.Rows.Add(row);

                            SqlHelper.ExecuteNonQuery("UPDATE R_HGGFHXPWLSH SET WL40=@WL40,WL41=@WL41,WL42=@WL42,WL421=@WL421,WL422=@WL422,WL43=@WL43,WL44=@WL44,WL45=@WL45,WL46=@WL46,WL47=@WL47,WL48=@WL48,WL49=@WL49,WL50=@WL50 WHERE WL01=@WL01", new SqlParameter("@WL01", textBox35.Text), new SqlParameter("@WL40", comboBoxEdit6.Text), new SqlParameter("@WL41", comboBoxEdit9.Text), new SqlParameter("@WL42", WL42), new SqlParameter("@WL421", WL421), new SqlParameter("@WL422", WL422), new SqlParameter("@WL43", comboBoxEdit8.Text), new SqlParameter("@WL44", WL44), new SqlParameter("@WL45", WL45), new SqlParameter("@WL46", WL46), new SqlParameter("@WL47", WL47), new SqlParameter("@WL48", WL48), new SqlParameter("@WL49", WL49), new SqlParameter("@WL50", textBox29.Text));
                        }
                    }
                }
            }
        }
        //删除
        private void button8_Click( object sender, EventArgs e )
        {
            int num = bandedGridView1.FocusedRowHandle;
            det.Rows.RemoveAt(num);

            SqlHelper.ExecuteNonQuery("UPDATE R_HGGFHXPWLSH SET WL40=@WL40,WL41=@WL41,WL42=@WL42,WL421=@WL421,WL422=@WL422,WL43=@WL43,WL44=@WL44,WL45=@WL45,WL46=@WL46,WL47=@WL47,WL48=@WL48,WL49=@WL49,WL50=@WL50 WHERE WL01=@WL01",new SqlParameter("@WL01",textBox35.Text),new SqlParameter("@WL40",null), new SqlParameter("@WL41", null), new SqlParameter("@WL42", null), new SqlParameter("@WL421", null), new SqlParameter("@WL422", null), new SqlParameter("@WL43", null), new SqlParameter("@WL44", null), new SqlParameter("@WL45", null), new SqlParameter("@WL46", null), new SqlParameter("@WL47", null), new SqlParameter("@WL48", null), new SqlParameter("@WL49", null), new SqlParameter("@WL50", null));
        }
        //获取得到焦点的行的值
        private void bandedGridView1_FocusedRowChanged( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
            if (bandedGridView1.RowCount < 1)
            {
                comboBoxEdit6.Text = "";
                comboBoxEdit9.Text = "";
                comboBoxEdit7.Text = "";
                comboBoxEdit8.Text = "";
                checkEdit1.Checked = false;
                checkEdit2.Checked = false;
                checkEdit3.Checked = false;
                checkEdit4.Checked = false;
                checkEdit5.Checked = false;
                checkEdit6.Checked = false;
                textBox29.Text = "";
            }
            else
            {
                comboBoxEdit6.Text = bandedGridView1.GetRowCellValue(e.FocusedRowHandle, "WL40").ToString();
                comboBoxEdit9.Text = bandedGridView1.GetRowCellValue(e.FocusedRowHandle, "WL41").ToString();
                if (bandedGridView1.GetRowCellValue(e.FocusedRowHandle, "WL42").ToString() != "")
                {
                    comboBoxEdit7.Text = bandedGridView1.GetRowCellValue(e.FocusedRowHandle, "WL42").ToString();
                }
                else if (bandedGridView1.GetRowCellValue(e.FocusedRowHandle, "WL421").ToString() != "")
                {
                    comboBoxEdit7.Text = bandedGridView1.GetRowCellValue(e.FocusedRowHandle, "WL421").ToString();
                }
                else if (bandedGridView1.GetRowCellValue(e.FocusedRowHandle, "WL422").ToString() != "")
                {
                    comboBoxEdit7.Text = bandedGridView1.GetRowCellValue(e.FocusedRowHandle, "WL422").ToString();
                }
                comboBoxEdit8.Text = bandedGridView1.GetRowCellValue(e.FocusedRowHandle, "WL43").ToString();
                if (bandedGridView1.GetRowCellValue(e.FocusedRowHandle, "WL44").ToString() == "符合")
                {
                    checkEdit1.Checked = true;
                }
                else
                {
                    checkEdit1.Checked = false;
                }
                if (bandedGridView1.GetRowCellValue(e.FocusedRowHandle, "WL45").ToString() == "符合")
                {
                    checkEdit2.Checked = true;
                }
                else
                {
                    checkEdit2.Checked = false;
                }
                if (bandedGridView1.GetRowCellValue(e.FocusedRowHandle, "WL46").ToString() == "符合")
                {
                    checkEdit3.Checked = true;
                }
                else
                {
                    checkEdit3.Checked = false;
                }
                if (bandedGridView1.GetRowCellValue(e.FocusedRowHandle, "WL47").ToString() == "符合")
                {
                    checkEdit4.Checked = true;
                }
                else
                {
                    checkEdit4.Checked = false;
                }
                if (bandedGridView1.GetRowCellValue(e.FocusedRowHandle, "WL48").ToString() == "符合")
                {
                    checkEdit5.Checked = true;
                }
                else
                {
                    checkEdit5.Checked = false;
                }
                if (bandedGridView1.GetRowCellValue(e.FocusedRowHandle, "WL49").ToString() == "符合")
                {
                    checkEdit6.Checked = true;
                }
                else
                {
                    checkEdit6.Checked = false;
                }
                textBox29.Text = bandedGridView1.GetRowCellValue(e.FocusedRowHandle, "WL50").ToString();
            }
        }
    }
}

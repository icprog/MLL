using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mulaolao.Class;
using StudentMgr;
using Mulaolao.Environmental;

namespace Mulaolao.Environmental
{
    public partial class R_Frmhuaxuepinruku : Form
    {
        public R_Frmhuaxuepinruku( Form fm)
        {
            this.MdiParent = fm;
            InitializeComponent();
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        huaxuepinSelect hs = new huaxuepinSelect();
        DataTable de;
        DataTable dl;/* = SqlHelper.ExecuteDataTable("SELECT * FROM R_HXPRCKMX");*/
        string HX01 = "", HX02 = "", HX03 = "", HX04 = "", HX05 = "", HX06 = "", HX07 = "", HX08 = "", HX09 = "", HX10 = "", HX12 = "", HX14 = "", HX15 = "", HX16 = "", HX32 = "", HX33 = "";
        decimal HX11 = 0M, HX13 = 0M;
        private void R_Frmhuaxuepinruku_Load( object sender, EventArgs e )
        {
            //if (radioButton1.Checked)
            //{
            //    comboBox14.Enabled = true;
            //    comboBox15.Enabled = false;
            //}
            //else if (radioButton2.Checked)
            //{
            //    comboBox14.Enabled = false;
            //    comboBox15.Enabled = true;
            //}
            //else
            //{
            //    comboBox14.Enabled = false;
            //    comboBox15.Enabled = false;
            //}


            toolSelect.Enabled = false;
            toolAdd.Enabled = false;
            toolDelete.Enabled = false;
            toolUpdate.Enabled = false;
            toolReview.Enabled = false;
            toolPrint.Enabled = false;
            toolSave.Enabled = false;
            toolCancel.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
        }
        //string str="";
        private void textBox4_TextChanged( object sender, EventArgs e )
        {
        }

        private void textBox9_TextChanged( object sender, EventArgs e )
        {
          
        }
        private void comboBox10_SelectedValueChanged( object sender, EventArgs e )
        {
        }

        //查询
        private void toolSelect_Click( object sender, EventArgs e )
        {
            DataTable da = SqlHelper.ExecuteDataTable("SELECT * FROM R_HXPRCKMX");
            if (da.Rows.Count < 0)
            {
                MessageBox.Show("没有数据");
            }
            else
            {
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    hs.comboBox1.Items.Add(da.Rows[i]["HX01"].ToString());
                }
                hs.PassDataBetweenForm += new huaxuepinSelect.PassDataBetweenFormHandler(hs_PassDataBetweenForm);
                hs.ShowDialog();

                de = SqlHelper.ExecuteDataTable("SELECT * FROM R_HXPRCKMX WHERE HX01=@HX01",new SqlParameter("@HX01",bie));
                textBox1.Text = de.Rows[0]["HX02"].ToString();
                comboBox1.Text= de.Rows[0]["HX03"].ToString();//品名和品号
                comboBox2.Text= de.Rows[0]["HX04"].ToString();
                comboBox3.Text = de.Rows[0]["HX05"].ToString();
                comboBox4.Text = de.Rows[0]["HX06"].ToString();
                comboBox5.Text = de.Rows[0]["HX07"].ToString();
                comboBox6.Text = de.Rows[0]["HX08"].ToString();
                textBox2.Text = de.Rows[0]["HX09"].ToString();
                textBox3.Text = de.Rows[0]["HX10"].ToString();
                textBox4.Text = de.Rows[0]["HX11"].ToString();
                textBox5.Text = de.Rows[0]["HX12"].ToString();
                comboBox7.Text = de.Rows[0]["HX13"].ToString();
                textBox6.Text = de.Rows[0]["HX14"].ToString();
                //textBox7.Text = de.Rows[0]["HX15"].ToString();

                gridControl1.DataSource = de;

                if (de.Rows[0]["HX32"].ToString() == "R")
                {
                    //radioButton1.Checked = true;
                    //radioButton2.Checked = false;
                    comboBox14.Enabled = true;
                    comboBox14.Text = de.Rows[0]["HX33"].ToString();
                    comboBox15.Enabled = false;
                }
                else if (de.Rows[0]["HX32"].ToString() == "C")
                {
                    //radioButton2.Checked = true;
                    //radioButton1.Checked = false;
                    comboBox15.Enabled = true;
                    comboBox15.Text = de.Rows[0]["HX33"].ToString();
                    comboBox14.Enabled = false;
                }
                else
                {
                    //radioButton1.Checked = false;
                    //radioButton2.Checked = false;
                    comboBox14.Enabled = false;
                    comboBox15.Enabled = false;
                }
                //textBox18.Text= de.Rows[0]["HX16"].ToString();
            }
        }
        string bie = "";
        private void hs_PassDataBetweenForm( object sender, PassDataWinFormEventArgs e )
        {
            bie = e.ConOne;
        }
        //新增
        private void toolAdd_Click( object sender, EventArgs e )
        {
            if (/*radioButton1.Checked == false && radioButton2.Checked == false*/1==1)
            {
                MessageBox.Show("请选择入库还是出库");
            }
            else
            {
                foreach (Control cn in this.Controls)
                {
                    if (cn.GetType().ToString() == "System.Windows.Forms.TextBox")
                    {
                        TextBox tb = cn as TextBox;
                        if (tb.Text == "")
                        {
                            MessageBox.Show("您有内容没有填写,请填写");
                        }
                        else
                        {
                            if (cn.GetType().ToString() == "System.Windows.Forms.ComboBox")
                            {
                                ComboBox cb = cn as ComboBox;
                                if (cb.Text == "")
                                {
                                    MessageBox.Show("您有内容没有选择,请填写");
                                }
                                else
                                {
                                    //if (radioButton1.Checked)
                                    //{
                                    //    comboBox14.Enabled = true;
                                    //    comboBox15.Enabled = false;
                                    //    HX32 = "R";
                                    //    HX33 = comboBox14.Text;
                                    //    HX01 = comboBox1.SelectedValue.ToString() + textBox1.Text + HX33;
                                    //}
                                    //else if (radioButton2.Checked)
                                    //{
                                    //    comboBox14.Enabled = false;
                                    //    comboBox15.Enabled = true;
                                    //    HX32 = "C";
                                    //    HX33 = comboBox15.Text;
                                    //    HX01 = comboBox1.SelectedValue.ToString() + textBox1.Text + HX33;
                                    //}
                                    HX02 = textBox1.Text;
                                    HX03 = comboBox1.Text;//品名和品号
                                    HX04 = comboBox2.Text;
                                    HX05 = comboBox3.Text;
                                    HX06 = comboBox4.Text;
                                    HX07 = comboBox5.Text;
                                    HX08 = comboBox6.Text;
                                    HX09 = textBox2.Text;
                                    HX10 = textBox3.Text;
                                    HX11 = Convert.ToDecimal(textBox4.Text);
                                    HX12 = textBox5.Text;
                                    HX13 = Convert.ToDecimal(comboBox7.Text);
                                    HX14 = textBox6.Text;
                                    //HX15 = textBox7.Text;
                                    //HX16 = textBox18.Text;
                                    if (dl.Rows.Count < 0)
                                    {
                                        int count = SqlHelper.ExecuteNonQuery("INSERT INTO R_HXPRCKMX (HX01,HX02,HX03,HX04,HX05,HX06,HX07,HX08,HX09,HX10,HX11,HX12,HX13,HX14,HX15,HX16,HX32,HX33) VALUES(@HX01,@HX02,@HX03,@HX04,@HX05,@HX06,@HX07,@HX08,@HX09,@HX10,@HX11,@HX12,@HX13,@HX14,@HX15,@HX16,@HX32,@HX33)", new SqlParameter("@HX01", HX01), new SqlParameter("@HX02", HX02), new SqlParameter("@HX03", HX03), new SqlParameter("@HX04", HX04), new SqlParameter("@HX05", HX05), new SqlParameter("@HX06", HX06), new SqlParameter("@HX07", HX07), new SqlParameter("@HX08", HX08), new SqlParameter("@HX09", HX09), new SqlParameter("@HX10", HX10), new SqlParameter("@HX11", HX11), new SqlParameter("@HX12", HX12), new SqlParameter("@HX13", HX13), new SqlParameter("@HX14", HX14), new SqlParameter("@HX15", HX15), new SqlParameter("@HX16", HX16), new SqlParameter("@HX32", HX32), new SqlParameter("@HX33", HX33));
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
                                        for (int i = 0; i < dl.Rows.Count; i++)
                                        {
                                            if (dl.Rows[i]["HX01"].ToString() != HX01)
                                            {
                                                int count = SqlHelper.ExecuteNonQuery("INSERT INTO R_HXPRCKMX (HX01,HX02,HX03,HX04,HX05,HX06,HX07,HX08,HX09,HX10,HX11,HX12,HX13,HX14,HX15,HX16,HX32,HX33) VALUES(@HX01,@HX02,@HX03,@HX04,@HX05,@HX06,@HX07,@HX08,@HX09,@HX10,@HX11,@HX12,@HX13,@HX14,@HX15,@HX16,@HX32,@HX33)", new SqlParameter("@HX01", HX01), new SqlParameter("@HX02", HX02), new SqlParameter("@HX03", HX03), new SqlParameter("@HX04", HX04), new SqlParameter("@HX05", HX05), new SqlParameter("@HX06", HX06), new SqlParameter("@HX07", HX07), new SqlParameter("@HX08", HX08), new SqlParameter("@HX09", HX09), new SqlParameter("@HX10", HX10), new SqlParameter("@HX11", HX11), new SqlParameter("@HX12", HX12), new SqlParameter("@HX13", HX13), new SqlParameter("@HX14", HX14), new SqlParameter("@HX15", HX15), new SqlParameter("@HX16", HX16), new SqlParameter("@HX32", HX32), new SqlParameter("@HX33", HX33));
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
                                                MessageBox.Show("唯一标示为:"+HX01+"的数据已经存在,请核实后再进行操作");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
             }           
        }
        //删除
        private void toolDelete_Click( object sender, EventArgs e )
        {
            if (bie == "")
            {
                MessageBox.Show("请查询需要删除的数据");
            }
            else
            {
                int count = SqlHelper.ExecuteNonQuery("DELETE FROM R_HXPRCKMX WHERE HX01=@HX01",new SqlParameter("@HX01",bie));
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
        //更改
        private void toolUpdate_Click( object sender, EventArgs e )
        {
            if (bie == "")
            {
                MessageBox.Show("请查询需要更改的数据");
            }
            else
            {
                //if (radioButton1.Checked)
                //{
                //    comboBox14.Enabled = true;
                //    comboBox15.Enabled = false;
                //    HX32 = "R";
                //    HX33 = comboBox14.Text;
                //    HX01 = comboBox1.SelectedValue.ToString() + textBox1.Text + HX33;
                //}
                //else if (radioButton2.Checked)
                //{
                //    comboBox14.Enabled = false;
                //    comboBox15.Enabled = true;
                //    HX32 = "C";
                //    HX33 = comboBox15.Text;
                //    HX01 = comboBox1.SelectedValue.ToString() + textBox1.Text + HX33;
                //}
                HX02 = textBox1.Text;
                HX03 = comboBox1.Text;//品名和品号
                HX04 = comboBox2.Text;
                HX05 = comboBox3.Text;
                HX06 = comboBox4.Text;
                HX07 = comboBox5.Text;
                HX08 = comboBox6.Text;
                HX09 = textBox2.Text;
                HX10 = textBox3.Text;
                HX11 = Convert.ToDecimal(textBox4.Text);
                HX12 = textBox5.Text;
                HX13 = Convert.ToDecimal(comboBox7.Text);
                HX14 = textBox6.Text;
                //HX15 = textBox7.Text;
                //HX16 = textBox18.Text;
                int count = SqlHelper.ExecuteNonQuery("UPDATE R_HXPRCKMX SET HX02=@HX02,HX03=@HX03,HX04=@HX04,HX05=@HX05,HX06=@HX06,HX07=@HX07,HX08=@HX08,HX09=@HX09,HX10=@HX10,HX11=@HX11,HX12=@HX12,HX13=@HX13,HX14=@HX14,HX15=@HX15,HX16=@HX16 WHERE HX01=@HX01", new SqlParameter("@HX01", bie), new SqlParameter("@HX02", HX02), new SqlParameter("@HX03", HX03), new SqlParameter("@HX04", HX04), new SqlParameter("@HX05", HX05), new SqlParameter("@HX06", HX06), new SqlParameter("@HX07", HX07), new SqlParameter("@HX08", HX08), new SqlParameter("@HX09", HX09), new SqlParameter("@HX10", HX10), new SqlParameter("@HX11", HX11), new SqlParameter("@HX12", HX12), new SqlParameter("@HX13", HX13), new SqlParameter("@HX14", HX14), new SqlParameter("@HX15", HX15), new SqlParameter("@HX16", HX16));
                if (count < 0)
                {
                    MessageBox.Show("更改数据失败");
                }
                else
                {
                    MessageBox.Show("成功更改数据");
                }
            }
        }
        //送审
        string reve = "";
        private void toolReview_Click( object sender, EventArgs e )
        {
            //if (radioButton1.Checked)
            //{
            //    comboBox14.Enabled = true;
            //    comboBox15.Enabled = false;
            //    HX32 = "R";
            //    HX33 = comboBox14.Text;
            //    HX01 = comboBox1.SelectedValue.ToString() + textBox1.Text + HX33;
            //}
            //else if (radioButton2.Checked)
            //{
            //    comboBox14.Enabled = false;
            //    comboBox15.Enabled = true;
            //    HX32 = "C";
            //    HX33 = comboBox15.Text;
            //    HX01 = comboBox1.SelectedValue.ToString() + textBox1.Text + HX33;
            //}
            //int count = ReviewES.Revie(this,reve, Logins.number);
            //if (count < 0)
            //{
            //    MessageBox.Show("送审失败");
            //}
            //else
            //{
            //    MessageBox.Show("送审成功");
            //}
        }
        //打印
        private void toolPrint_Click( object sender, EventArgs e )
        {

        }
        string HX017 = "", HX018 = "", HX019 = "", HX020 = "", HX021 = "", HX022 = "", HX029 = "", HX031 = "";
        private void radioButton1_CheckedChanged( object sender, EventArgs e )
        {

        }
        decimal HX023 = 0M, HX024 = 0M, HX025 = 0M, HX026 = 0M, HX027 = 0M, HX028 = 0M, HX030 = 0M;
        private void gridView1_FocusedRowChanged( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
            if (gridView1.RowCount < 1)
            {
                //Ergodic.GroupboxEvery(groupBox3);
            }
            else
            {
                //textBox8.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "HX17").ToString();
                comboBox8.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "HX18").ToString();
                comboBox9.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "HX19").ToString();
                comboBox10.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "HX20").ToString();
                comboBox11.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "HX21").ToString();
                comboBox12.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "HX22").ToString();
                comboBox13.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "HX30").ToString();
                //textBox9.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "HX23").ToString();
                //textBox10.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "HX25").ToString();
                //textBox11.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "HX24").ToString();
                //textBox12.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "HX26").ToString();
                //textBox13.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "HX27").ToString();
                //textBox14.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "HX28").ToString();
                //textBox15.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "HX29").ToString();
                //textBox16.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "HX31").ToString();
            }
        }
        //新建
        private void button1_Click( object sender, EventArgs e )
        {
            DataRow row;           
            //HX017 = textBox8.Text;
            HX018 = comboBox8.Text;
            HX019 = comboBox9.Text;
            HX020 = comboBox10.Text;
            HX021= comboBox11.Text;
            HX022= comboBox12.Text;
            //HX023 = Convert.ToDecimal(textBox9.Text);
            //HX024= Convert.ToDecimal(textBox11.Text);
            //HX025 = Convert.ToDecimal(textBox10.Text);
            //HX026 = Convert.ToDecimal(textBox12.Text);
            //HX027 = Convert.ToDecimal(textBox13.Text);
            //HX028 = Convert.ToDecimal(textBox14.Text);
            //HX029 = textBox15.Text;
            HX030= Convert.ToDecimal(comboBox13.Text);
            //HX031 = textBox16.Text;
            foreach (Control cn in this.Controls)
            {
                if (cn.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    TextBox tb = cn as TextBox;
                    if (tb.Text == "")
                    {
                        MessageBox.Show("您有内容没有填写,请填写");
                    }
                    else
                    {
                        if (cn.GetType().ToString() == "System.Windows.Forms.ComboBox")
                        {
                            ComboBox cb = cn as ComboBox;
                            if (cb.Text == "")
                            {
                                MessageBox.Show("您有内容没有选择,请选择");
                            }
                            else
                            {
                                if (gridControl1.DataSource == de)
                                {
                                    row = de.NewRow();
                                    //row["HX17"] = textBox8.Text;
                                    row["HX18"] = comboBox8.Text;
                                    row["HX19"] = comboBox9.Text;
                                    row["HX20"] = comboBox10.Text;
                                    row["HX21"] = comboBox11.Text;
                                    row["HX22"] = comboBox12.Text;
                                    //row["HX23"] = Convert.ToDecimal(textBox9.Text);
                                    //row["HX24"] = Convert.ToDecimal(textBox11.Text);
                                    //row["HX25"] = Convert.ToDecimal(textBox10.Text);
                                    //row["HX26"] = Convert.ToDecimal(textBox12.Text);
                                    //row["HX27"] = Convert.ToDecimal(textBox13.Text);
                                    //row["HX28"] = Convert.ToDecimal(textBox14.Text);
                                    //row["HX29"] = textBox15.Text;
                                    row["HX30"] = Convert.ToDecimal(comboBox13.Text);
                                    //row["HX31"] = textBox16.Text;
                                    de.Rows.Add(row);

                                    SqlHelper.ExecuteNonQuery("INSERT INTO R_HXPRCKMX (HX01,HX17,HX18,HX19,HX20,HX21,HX22,HX23,HX24,HX25,HX26,HX27,HX28,HX29,HX30,HX31) VALUES (@HX01,@HX17,@HX18,@HX19,@HX20,@HX21,@HX22,@HX23,@HX24,@HX25,@HX26,@HX27,@HX28,@HX29,@HX30,@HX31)", new SqlParameter("@HX01", bie), new SqlParameter("@HX17", HX017), new SqlParameter("@HX18", HX018), new SqlParameter("@HX19", HX019), new SqlParameter("@HX20", HX020), new SqlParameter("@HX21", HX021), new SqlParameter("@HX22", HX022), new SqlParameter("@HX23", HX023), new SqlParameter("@HX24", HX024), new SqlParameter("@HX25", HX025), new SqlParameter("@HX26", HX026), new SqlParameter("@HX27", HX027), new SqlParameter("@HX28", HX028), new SqlParameter("@HX29", HX029), new SqlParameter("@HX30", HX030), new SqlParameter("@HX31", HX031));
                                }
                                else
                                {
                                    if (textBox1.Text == "")
                                    {
                                        MessageBox.Show("请填写入库日期");
                                    }
                                    else
                                    {
                                        if (comboBox1.Text == "")
                                        {
                                            MessageBox.Show("请选择品名");
                                        }
                                        else
                                        {
                                            //if (radioButton1.Checked)
                                            //{
                                            //    comboBox14.Enabled = true;
                                            //    comboBox15.Enabled = false;
                                            //    HX32 = "R";
                                            //    HX33 = comboBox14.Text;
                                            //    HX01 = comboBox1.SelectedValue.ToString() + textBox1.Text + HX33;
                                            //}
                                            //else if (radioButton2.Checked)
                                            //{
                                            //    comboBox14.Enabled = false;
                                            //    comboBox15.Enabled = true;
                                            //    HX32 = "C";
                                            //    HX33 = comboBox15.Text;
                                            //    HX01 = comboBox1.SelectedValue.ToString() + textBox1.Text + HX33;
                                            //}

                                            gridControl1.DataSource = dl;
                                            row = dl.NewRow();
                                            //row["HX17"] = textBox8.Text;
                                            row["HX18"] = comboBox8.Text;
                                            row["HX19"] = comboBox9.Text;
                                            row["HX20"] = comboBox10.Text;
                                            row["HX21"] = comboBox11.Text;
                                            row["HX22"] = comboBox12.Text;
                                            //row["HX23"] = Convert.ToDecimal(textBox9.Text);
                                            //row["HX24"] = Convert.ToDecimal(textBox11.Text);
                                            //row["HX25"] = Convert.ToDecimal(textBox10.Text);
                                            //row["HX26"] = Convert.ToDecimal(textBox12.Text);
                                            //row["HX27"] = Convert.ToDecimal(textBox13.Text);
                                            //row["HX28"] = Convert.ToDecimal(textBox14.Text);
                                            //row["HX29"] = textBox15.Text;
                                            //row["HX30"] = Convert.ToDecimal(comboBox13.Text);
                                            //row["HX31"] = textBox16.Text;
                                            dl.Rows.Add(row);

                                            SqlHelper.ExecuteNonQuery("INSERT INTO R_HXPRCKMX (HX01,HX17,HX18,HX19,HX20,HX21,HX22,HX23,HX24,HX25,HX26,HX27,HX28,HX29,HX30,HX31) VALUES (@HX01,@HX17,@HX18,@HX19,@HX20,@HX21,@HX22,@HX23,@HX24,@HX25,@HX26,@HX27,@HX28,@HX29,@HX30,@HX31)", new SqlParameter("@HX01", HX01), new SqlParameter("@HX17", HX017), new SqlParameter("@HX18", HX018), new SqlParameter("@HX19", HX019), new SqlParameter("@HX20", HX020), new SqlParameter("@HX21", HX021), new SqlParameter("@HX22", HX022), new SqlParameter("@HX23", HX023), new SqlParameter("@HX24", HX024), new SqlParameter("@HX25", HX025), new SqlParameter("@HX26", HX026), new SqlParameter("@HX27", HX027), new SqlParameter("@HX28", HX028), new SqlParameter("@HX29", HX029), new SqlParameter("@HX30", HX030), new SqlParameter("@HX31", HX031));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        //删除
        private void button2_Click( object sender, EventArgs e )
        {
            int num = gridView1.FocusedRowHandle;
            if (gridControl1.DataSource == de)
            {
                HX020 = de.Rows[0]["HX20"].ToString();
                de.Rows.RemoveAt(num);
                SqlHelper.ExecuteNonQuery("UPDATE R_HXPRCKMX SET HX17=@HX17,HX18=@HX18,HX19=@HX19,HX20=@HX20,HX21=@HX21,HX22=@HX22,HX23=@HX23,HX24=@HX24,HX25=@HX25,HX26=@HX26,HX27=@HX27,HX28=@HX28,HX29=@HX29,HX30=@HX30,HX31=@HX31 WHERE HX01=@HX01 AND HX20=@HX020", new SqlParameter("@HX01", bie), new SqlParameter("@HX17", HX017), new SqlParameter("@HX18", HX018), new SqlParameter("@HX19", HX019), new SqlParameter("@HX20", HX020), new SqlParameter("@HX21", HX021), new SqlParameter("@HX22", HX022), new SqlParameter("@HX23", HX023), new SqlParameter("@HX24", HX024), new SqlParameter("@HX25", HX025), new SqlParameter("@HX26", HX026), new SqlParameter("@HX27", HX027), new SqlParameter("@HX28", HX028), new SqlParameter("@HX29", HX029), new SqlParameter("@HX30", HX030), new SqlParameter("@HX31", HX031), new SqlParameter("@HX020", HX020));
            }
            else
            {
                //if (radioButton1.Checked)
                //{
                //    comboBox14.Enabled = true;
                //    comboBox15.Enabled = false;
                //    HX32 = "R";
                //    HX33 = comboBox14.Text;
                //    HX01 = comboBox1.SelectedValue.ToString() + textBox1.Text + HX33;
                //}
                //else if (radioButton2.Checked)
                //{
                //    comboBox14.Enabled = false;
                //    comboBox15.Enabled = true;
                //    HX32 = "C";
                //    HX33 = comboBox15.Text;
                //    HX01 = comboBox1.SelectedValue.ToString() + textBox1.Text + HX33;
                //}
                HX020 = de.Rows[0]["HX20"].ToString();
                gridControl1.DataSource = dl;
                SqlHelper.ExecuteNonQuery("DELETE FROM R_HXPRCKMX WHERE HX01=@HX01 AND HX20=@HX020", new SqlParameter("@HX01", HX01),new SqlParameter("@HX020",HX020));
            }
        }
        //编辑
        private void button3_Click( object sender, EventArgs e )
        {
            int num = gridView1.FocusedRowHandle;
            DataRow row;
            //HX017 = textBox8.Text;
            HX018 = comboBox8.Text;
            HX019 = comboBox9.Text;
            HX020 = comboBox10.Text;
            HX021 = comboBox11.Text;
            HX022 = comboBox12.Text;
            //HX023 = Convert.ToDecimal(textBox9.Text);
            //HX024 = Convert.ToDecimal(textBox11.Text);
            //HX025 = Convert.ToDecimal(textBox10.Text);
            //HX026 = Convert.ToDecimal(textBox12.Text);
            //HX027 = Convert.ToDecimal(textBox13.Text);
            //HX028 = Convert.ToDecimal(textBox14.Text);
            //HX029 = textBox15.Text;
            HX030 = Convert.ToDecimal(comboBox13.Text);
            //HX031 = textBox16.Text;
            foreach (Control cn in this.Controls)
            {
                if (cn.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    TextBox tb = cn as TextBox;
                    if (tb.Text == "")
                    {
                        MessageBox.Show("您有内容没有填写,请填写");
                    }
                    else
                    {
                        if (cn.GetType().ToString() == "System.Windows.Forms.ComboBox")
                        {
                            ComboBox cb = cn as ComboBox;
                            if (cb.Text == "")
                            {
                                MessageBox.Show("您有内容没有选择,请选择");
                            }
                            else
                            {
                                if (gridControl1.DataSource == de)
                                {
                                    row = de.Rows[num];
                                    row.BeginEdit();
                                    //row["HX17"] = textBox8.Text;
                                    row["HX18"] = comboBox8.Text;
                                    row["HX19"] = comboBox9.Text;
                                    row["HX20"] = comboBox10.Text;
                                    row["HX21"] = comboBox11.Text;
                                    row["HX22"] = comboBox12.Text;
                                    //row["HX23"] = Convert.ToDecimal(textBox9.Text);
                                    //row["HX24"] = Convert.ToDecimal(textBox11.Text);
                                    //row["HX25"] = Convert.ToDecimal(textBox10.Text);
                                    //row["HX26"] = Convert.ToDecimal(textBox12.Text);
                                    //row["HX27"] = Convert.ToDecimal(textBox13.Text);
                                    //row["HX28"] = Convert.ToDecimal(textBox14.Text);
                                    //row["HX29"] = textBox15.Text;
                                    //row["HX30"] = Convert.ToDecimal(comboBox13.Text);
                                    //row["HX31"] = textBox16.Text;
                                    row.EndEdit();

                                    SqlHelper.ExecuteNonQuery("UPDATE R_HXPRCKMX SET HX17=@HX17,HX18=@HX18,HX19=@HX19,HX20=@HX20,HX21=@HX21,HX22=@HX22,HX23=@HX23,HX24=@HX24,HX25=@HX25,HX26=@HX26,HX27=@HX27,HX28=@HX28,HX29=@HX29,HX30=@HX30,HX31=@HX31 WHERE HX01=@HX01 AND HX20=@HX020", new SqlParameter("@HX01", bie), new SqlParameter("@HX17", HX017), new SqlParameter("@HX18", HX018), new SqlParameter("@HX19", HX019), new SqlParameter("@HX20", HX020), new SqlParameter("@HX21", HX021), new SqlParameter("@HX22", HX022), new SqlParameter("@HX23", HX023), new SqlParameter("@HX24", HX024), new SqlParameter("@HX25", HX025), new SqlParameter("@HX26", HX026), new SqlParameter("@HX27", HX027), new SqlParameter("@HX28", HX028), new SqlParameter("@HX29", HX029), new SqlParameter("@HX30", HX030), new SqlParameter("@HX31", HX031), new SqlParameter("@HX020", HX020));
                                }
                                else
                                {
                                    if (textBox1.Text == "")
                                    {
                                        MessageBox.Show("请填写入库日期");
                                    }
                                    else
                                    {
                                        if (comboBox1.Text == "")
                                        {
                                            MessageBox.Show("请选择品名");
                                        }
                                        else
                                        {
                                            //if (radioButton1.Checked)
                                            //{
                                            //    comboBox14.Enabled = true;
                                            //    comboBox15.Enabled = false;
                                            //    HX32 = "R";
                                            //    HX33 = comboBox14.Text;
                                            //    HX01 = comboBox1.SelectedValue.ToString() + textBox1.Text + HX33;
                                            //}
                                            //else if (radioButton2.Checked)
                                            //{
                                            //    comboBox14.Enabled = false;
                                            //    comboBox15.Enabled = true;
                                            //    HX32 = "C";
                                            //    HX33 = comboBox15.Text;
                                            //    HX01 = comboBox1.SelectedValue.ToString() + textBox1.Text + HX33;
                                            //}

                                            gridControl1.DataSource = dl;
                                            row = dl.Rows[num];
                                            row.BeginEdit();
                                            //row["HX17"] = textBox8.Text;
                                            //row["HX18"] = comboBox8.Text;
                                            //row["HX19"] = comboBox9.Text;
                                            //row["HX20"] = comboBox10.Text;
                                            //row["HX21"] = comboBox11.Text;
                                            //row["HX22"] = comboBox12.Text;
                                            //row["HX23"] = Convert.ToDecimal(textBox9.Text);
                                            //row["HX24"] = Convert.ToDecimal(textBox11.Text);
                                            //row["HX25"] = Convert.ToDecimal(textBox10.Text);
                                            //row["HX26"] = Convert.ToDecimal(textBox12.Text);
                                            //row["HX27"] = Convert.ToDecimal(textBox13.Text);
                                            //row["HX28"] = Convert.ToDecimal(textBox14.Text);
                                            //row["HX29"] = textBox15.Text;
                                            //row["HX30"] = Convert.ToDecimal(comboBox13.Text);
                                            //row["HX31"] = textBox16.Text;
                                            row.EndEdit();

                                            SqlHelper.ExecuteNonQuery("UPDATE R_HXPRCKMX SET HX17=@HX17,HX18=@HX18,HX19=@HX19,HX20=@HX20,HX21=@HX21,HX22=@HX22,HX23=@HX23,HX24=@HX24,HX25=@HX25,HX26=@HX26,HX27=@HX27,HX28=@HX28,HX29=@HX29,HX30=@HX30,HX31=@HX31 WHERE HX01=@HX01 AND HX20=@HX020", new SqlParameter("@HX01", HX01), new SqlParameter("@HX17", HX017), new SqlParameter("@HX18", HX018), new SqlParameter("@HX19", HX019), new SqlParameter("@HX20", HX020), new SqlParameter("@HX21", HX021), new SqlParameter("@HX22", HX022), new SqlParameter("@HX23", HX023), new SqlParameter("@HX24", HX024), new SqlParameter("@HX25", HX025), new SqlParameter("@HX26", HX026), new SqlParameter("@HX27", HX027), new SqlParameter("@HX28", HX028), new SqlParameter("@HX29", HX029), new SqlParameter("@HX30", HX030), new SqlParameter("@HX31", HX031), new SqlParameter("@HX020", HX020));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void textBox10_TextChanged( object sender, EventArgs e )
        {

        }
    }
}

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
using Mulaolao.Class;

namespace Mulaolao.Wages
{
    public partial class R_Frmxiaozuzhangyeji : FormChild
    {
        public R_Frmxiaozuzhangyeji(Form fm)
        {
            this.MdiParent = fm;
            InitializeComponent();

            GridViewMoHuSelect . SetFilter ( bandedGridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { this . bandedGridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        string DBA0011 = "", DBA0012 = "", DBA0013 = "", DBA0014 = "", DBA0015 = "", KH025 = "";
        private void R_Frmxiaozuzhangyeji_Load( object sender, EventArgs e )
        {
            toolSelect.Enabled = false;
            toolAdd.Enabled = false;
            toolDelete.Enabled = false;
            toolUpdate.Enabled = false;
            toolReview.Enabled = false;
            toolPrint.Enabled = true;
            toolExport.Enabled = true;
            toolSave.Enabled = false;
            toolCancel.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;

            DataTable da = SqlHelper.ExecuteDataTable("SELECT DBA001,DBA002 FROM TPADBA");
            comboBox1.DataSource = da;
            comboBox1.DisplayMember = "DBA002";
            comboBox1.ValueMember = "DBA001";
            DataTable de = SqlHelper.ExecuteDataTable("SELECT DBA001,DBA002  FROM TPADBA   WHERE DBA012='车间主任'");
            comboBox2.DataSource = de;
            comboBox2.DisplayMember = "DBA002";
            comboBox2.ValueMember = "DBA001";
            DataTable dt = SqlHelper.ExecuteDataTable("SELECT DBA001,DBA002  FROM TPADBA   WHERE DBA012='统计员'");
            comboBox3.DataSource = dt;
            comboBox3.DisplayMember = "DBA002";
            comboBox3.ValueMember = "DBA001";
            DataTable dl = SqlHelper.ExecuteDataTable("SELECT DBA001,DBA002  FROM TPADBA   WHERE DBA012='成本员'");
            comboBox4.DataSource = dl;
            comboBox4.DisplayMember = "DBA002";
            comboBox4.ValueMember = "DBA001";
            DataTable del = SqlHelper.ExecuteDataTable("SELECT DBA001,DBA002  FROM TPADBA   WHERE DBA012='成本会计'");
            comboBox5.DataSource = del;
            comboBox5.DisplayMember = "DBA002";
            comboBox5.ValueMember = "DBA001";
            //DataTable dle = SqlHelper.ExecuteDataTable("SELECT KH25 FROM R_MLLKHXXCD");
            //for (int i = 0; i < dle.Rows.Count; i++)
            //{
            //    comboBox6.Items.Add(dle.Rows[i]["KH25"].ToString());
            //}
        }
        private void comboBox5_SelectedValueChanged( object sender, EventArgs e )
        {
            if (comboBox5.Items.Count < 1)
            {
                DBA0015 = "";
            }
            else
            {
                DBA0015 = comboBox5.SelectedValue.ToString();
            }
           
        }
        string XZ1 = "";
        private void comboBox6_SelectedValueChanged( object sender, EventArgs e )
        {
            XZ1 = comboBox6.SelectedValue.ToString();
            KH025 = comboBox6.Text;
            DataTable dte = SqlHelper.ExecuteDataTable("SELECT A.KH24,B.HT01,B.HT03,B.HT04,C.DEA002 FROM R_MLLKHXXCD A,R_MLLHTPS B,TPADEA C WHERE A.KH25=B.HT14 AND B.HT01=C.DEA001 AND KH25=@KH25",new SqlParameter("@KH25",KH025));
            textBox1.Text = dte.Rows[0]["HT01"].ToString();
            textBox2.Text = dte.Rows[0]["DEA002"].ToString();
            textBox3.Text = dte.Rows[0]["HT03"].ToString();
            textBox4.Text = dte.Rows[0]["HT04"].ToString();
        }
        private void comboBox3_SelectedValueChanged( object sender, EventArgs e )
        {
            if (comboBox3.Items.Count < 1)
            {
                DBA0013 = "";
            }
            else
            {
                DBA0013 = comboBox3.SelectedValue.ToString();
            }
            
        }
        private void comboBox4_SelectedValueChanged( object sender, EventArgs e )
        {
            if (comboBox4.Items.Count < 1)
            {
                DBA0014 = "";
            }
            else
            {
                DBA0014 = comboBox4.SelectedValue.ToString();
            }
            
        }
        private void comboBox2_SelectedValueChanged( object sender, EventArgs e )
        {
            if (comboBox2.Items.Count<1)
            {
                DBA0012 = "";
            }
            else
            {
                DBA0012 = comboBox2.SelectedValue.ToString();
            }          
        }
        private void comboBox1_SelectedValueChanged( object sender, EventArgs e )
        {
            DBA0011 = comboBox1.SelectedValue.ToString();
        }
        xiaozuSelect xs = new xiaozuSelect();
        string XZ12="",XZ02 = "", XZ03 = "", XZ04 = "", XZ05 = "", XZ06 = "";
        DataTable ddl; /*= SqlHelper.ExecuteDataTable("SELECT * FROM R_XZCGZYJKH");*/
        DataTable dtt;
        DataTable ddt /*= SqlHelper.ExecuteDataTable("SELECT B.HT01,B.HT03,B.HT04,C.DEA002,D.XZ07,D.XZ08,D.XZ09,D.XZ10,D.XZ11 FROM R_MLLKHXXCD A,R_MLLHTPS B,TPADEA C,R_XZCGZYJKH D WHERE A.KH24 = B.HT14 AND B.HT01 = C.DEA001 AND A.KH25 = D.XZ01")*/;
        //查询
        private void toolSelect_Click( object sender, EventArgs e )
        {
            DataTable dat = SqlHelper.ExecuteDataTable("SELECT * FROM R_XZCGZYJKH");
            if (dat.Rows.Count < 0)
            {
                MessageBox.Show("没有数据");
            }
            else
            {
                //for (int i = 0; i < dat.Rows.Count; i++)
                //{
                //    xs.comboBox1.Items.Add(dat.Rows[i]["XZ12"].ToString());
                //}
                xs.PassDataBetweenForm += new xiaozuSelect.PassDataBetweenFormHandler(xs_PassDataBetweenForm);
                xs.ShowDialog();

                DataTable dea = SqlHelper.ExecuteDataTable("SELECT * FROM R_XZCGZYJKH WHERE XZ12=@XZ12",new SqlParameter("@XZ12",shi));
                string com1 = dea.Rows[0]["XZ02"].ToString();
                DataTable dll = SqlHelper.ExecuteDataTable("SELECT DEA002 FROM TPADEA WHERE DEA001=@DEA001",new SqlParameter("@DEA001",com1));
                comboBox1.Text = dll.Rows[0]["DEA002"].ToString();
                string com2 = dea.Rows[0]["XZ03"].ToString();
                DataTable dcom= SqlHelper.ExecuteDataTable("SELECT DEA002 FROM TPADEA WHERE DEA001=@DEA001", new SqlParameter("@DEA001", com2));
                comboBox2.Text = dcom.Rows[0]["DEA002"].ToString();
                string com3 = dea.Rows[0]["XZ04"].ToString();
                DataTable dco = SqlHelper.ExecuteDataTable("SELECT DEA002 FROM TPADEA WHERE DEA001=@DEA001", new SqlParameter("@DEA001", com3));
                comboBox3.Text = dco.Rows[0]["DEA002"].ToString();
                string com4 = dea.Rows[0]["XZ05"].ToString();
                DataTable dc = SqlHelper.ExecuteDataTable("SELECT DEA002 FROM TPADEA WHERE DEA001=@DEA001", new SqlParameter("@DEA001", com4));
                comboBox4.Text = dc.Rows[0]["DEA002"].ToString();
                string com5 = dea.Rows[0]["XZ06"].ToString();
                DataTable dm = SqlHelper.ExecuteDataTable("SELECT DEA002 FROM TPADEA WHERE DEA001=@DEA001", new SqlParameter("@DEA001", com5));
                comboBox5.Text = dm.Rows[0]["DEA002"].ToString();

                dtt = SqlHelper.ExecuteDataTable("SELECT B.HT01,B.HT03,B.HT04,C.DEA002,D.XZ07,D.XZ08,D.XZ09,D.XZ10,D.XZ11 FROM R_MLLKHXXCD A,R_MLLHTPS B,TPADEA C,R_XZCGZYJKH D WHERE A.KH24 = B.HT14 AND B.HT01 = C.DEA001 AND A.KH25 = D.XZ01 WHERE XZ12=@XZ12", new SqlParameter("@XZ12", shi));
                gridControl1.DataSource = dtt;
            }
        }
        //新增
        private void toolAdd_Click( object sender, EventArgs e )
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("请选择产品生产责任人");
            }
            else
            {                
                XZ02 = comboBox1.Text;
                XZ03 = comboBox2.Text;
                XZ04 = comboBox3.Text;
                XZ05 = comboBox4.Text;
                XZ06 = comboBox5.Text;
                if (ddl.Rows.Count < 0)
                {
                    XZ12 = comboBox1.SelectedValue.ToString() + MulaolaoBll . Drity . GetDt ( ).ToString("yyyyMMdd");
                    int count = SqlHelper.ExecuteNonQuery("INSERT INTO R_XZCGZYJKH (XZ12,XZ02,XZ03,XZ04,XZ05,XZ06) VALUES (@XZ12,@XZ02,@XZ03,@XZ04,@XZ05,@XZ06)", new SqlParameter("@XZ12", XZ12), new SqlParameter("@XZ02", XZ02), new SqlParameter("@XZ03", XZ03), new SqlParameter("@XZ04", XZ04), new SqlParameter("@XZ05", XZ05), new SqlParameter("@XZ06", XZ06));
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
                    for (int k = 0; k < ddl.Rows.Count; k++)
                    {
                        if (ddl.Rows[k]["XZ12"].ToString() != XZ02 + MulaolaoBll . Drity . GetDt ( ).ToString("yyyyMMdd"))
                        {
                            int count = SqlHelper.ExecuteNonQuery("INSERT INTO R_XZCGZYJKH (XZ12,XZ02,XZ03,XZ04,XZ05,XZ06) VALUES (@XZ12,@XZ02,@XZ03,@XZ04,@XZ05,@XZ06)", new SqlParameter("@XZ12", XZ12), new SqlParameter("@XZ02", XZ02), new SqlParameter("@XZ03", XZ03), new SqlParameter("@XZ04", XZ04), new SqlParameter("@XZ05", XZ05), new SqlParameter("@XZ06", XZ06));
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
                            MessageBox.Show("唯一标示为:"+ XZ02 + MulaolaoBll . Drity . GetDt ( ).ToString("yyyyMMdd") + "的数据已经存在,请核实后再做新增操作");
                            //int count = SqlHelper.ExecuteNonQuery("UPDATE R_XZCGZYJKH SET XZ02=@XZ02,XZ03=@XZ03,XZ04=@XZ04,XZ05=@XZ05,XZ06=@XZ06 WHERE XZ12=@XZ12", new SqlParameter("@XZ12", XZ12), new SqlParameter("@XZ02", XZ02), new SqlParameter("@XZ03", XZ03), new SqlParameter("@XZ04", XZ04), new SqlParameter("@XZ05", XZ05), new SqlParameter("@XZ06", XZ06));
                            //if (count < 0)
                            //{
                            //    MessageBox.Show("录入数据失败");
                            //}
                            //else
                            //{
                            //    MessageBox.Show("成功录入数据");
                            //}
                        }
                    }
                }
            }
        }
        //删除
        private void toolDelete_Click( object sender, EventArgs e )
        {
            if (shi == "")
            {
                MessageBox.Show("请查询需要删除的数据");
            }
            else
            {
                int count = SqlHelper.ExecuteNonQuery("DELETE FROM R_XZCGZYJKH WHERE XZ12=@XZ12",new SqlParameter("@XZ12",shi));
                if (count < 0)
                {
                    MessageBox.Show("删除数据失败");
                }
                else
                {
                    Ergodic.FormEvery(this);
                    gridControl1.DataSource = null;
                    MessageBox.Show("成功删除数据");
                }
            }
        }
        //更改
        private void toolUpdate_Click( object sender, EventArgs e )
        {
            if (shi == "")
            {
                MessageBox.Show("请选择需要更改的数据");
            }
            else
            {
                XZ02 = comboBox1.Text;
                XZ03 = comboBox2.Text;
                XZ04 = comboBox3.Text;
                XZ05 = comboBox4.Text;
                XZ06 = comboBox5.Text;
                
                int count = SqlHelper.ExecuteNonQuery("UPDATE R_XZCGZYJKH SET XZ02=@XZ02,XZ03=@XZ03,XZ04=@XZ04,XZ05=@XZ05,XZ06=@XZ06 WHERE XZ12=@XZ12", new SqlParameter("@XZ12", shi), new SqlParameter("@XZ02", XZ02), new SqlParameter("@XZ03", XZ03), new SqlParameter("@XZ04", XZ04), new SqlParameter("@XZ05", XZ05), new SqlParameter("@XZ06", XZ06));
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
            //int count = ReviewES.Revie(this,reve, Logins.number);
            //if (count < 1)
            //{
            //    MessageBox.Show("送审失败");
            //}
            //else
            //{
            //    MessageBox.Show("送审成功");
            //}
        }
        string shi = "";
        private void xs_PassDataBetweenForm( object sender, PassDataWinFormEventArgs e )
        {
            shi = e.ConOne;
        }
        private void bandedGridView1_FocusedRowChanged( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
            if (bandedGridView1.RowCount < 1)
            {
                //Ergodic.GroupboxEvery(groupBox3);
            }
            else
            {
                comboBox6.Text = bandedGridView1.GetRowCellValue(e.FocusedRowHandle, "XZ01").ToString();
                textBox1.Text = bandedGridView1.GetRowCellValue(e.FocusedRowHandle, "HT01").ToString();
                textBox2.Text = bandedGridView1.GetRowCellValue(e.FocusedRowHandle, "DEA002").ToString();
                textBox3.Text = bandedGridView1.GetRowCellValue(e.FocusedRowHandle, "HT03").ToString();
                textBox4.Text = bandedGridView1.GetRowCellValue(e.FocusedRowHandle, "HT04").ToString();
                textBox5.Text = bandedGridView1.GetRowCellValue(e.FocusedRowHandle, "U4").ToString();
                textBox6.Text = bandedGridView1.GetRowCellValue(e.FocusedRowHandle, "XZ08").ToString();
                //textBox7.Text = bandedGridView1.GetRowCellValue(e.FocusedRowHandle, "XZ09").ToString();
                //textBox8.Text = bandedGridView1.GetRowCellValue(e.FocusedRowHandle, "XZ11").ToString();
                //textBox9.Text = bandedGridView1.GetRowCellValue(e.FocusedRowHandle, "XZ10").ToString();
                //textBox10.Text = bandedGridView1.GetRowCellValue(e.FocusedRowHandle, "XZ07").ToString();
            }
        }
        string XZ001 = "", HT001 = "", HT004 = "", DEA02 = "", XZ007 = "", XZ008 = "", XZ009 = "", XZ010 = "", XZ011 = "", U04 = "";
        int HT003 = 0;
        //新建
        private void button1_Click( object sender, EventArgs e )
        {
            DataRow row;
            XZ001 = comboBox6.Text;
            HT001 = textBox1.Text;
            DEA02 = textBox2.Text;
            HT003 = Convert.ToInt32(textBox3.Text);
            HT004 = textBox4.Text;
            U04 = textBox5.Text;
            XZ008 = textBox6.Text;
            //XZ009 = textBox7.Text;
            //XZ011 = textBox8.Text;
            //XZ010 = textBox9.Text;
            //XZ007 = textBox10.Text;
            XZ12 = comboBox1.SelectedValue.ToString() + MulaolaoBll . Drity . GetDt ( ).ToString("yyyyMMdd");
            foreach (Control cn in this.Controls)
            {
                if (comboBox6.Text == "")
                {
                    MessageBox.Show("请选择流水号");
                }
                else
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
                            if (gridControl1.DataSource == dtt)
                            {
                                row = dtt.NewRow();
                                row["XZ01"] = comboBox6.Text;
                                row["HT01"] = textBox1.Text;
                                row["DEA002"] = textBox2.Text;
                                row["HT03"] = Convert.ToInt32(textBox3.Text);
                                row["HT04"] = textBox4.Text;
                                //row["XZ07"] = textBox10.Text;
                                //row["XZ08"] = textBox6.Text;
                                //row["XZ09"] = textBox7.Text;
                                //row["XZ10"] = textBox9.Text;
                                //row["XZ11"] = textBox8.Text;
                                dtt.Rows.Add(row);

                                SqlHelper.ExecuteNonQuery("INSERT INTO R_XZCGZYJKH (XZ01,XZ07,XZ08,XZ09,XZ10,XZ11,XZ12) VALUES (@XZ01,@XZ07,@XZ08,@XZ09,@XZ10,@XZ11,@XZ12)", new SqlParameter("@XZ12", XZ12), new SqlParameter("@XZ01", XZ001), new SqlParameter("@XZ07", XZ007), new SqlParameter("@XZ08", XZ008), new SqlParameter("@XZ09", XZ009), new SqlParameter("@XZ10", XZ010), new SqlParameter("@XZ11", XZ011));
                            }
                            else
                            {
                                gridControl1.DataSource = ddt;

                                row = ddt.NewRow();
                                row["XZ01"] = comboBox6.Text;
                                row["HT01"] = textBox1.Text;
                                row["DEA002"] = textBox2.Text;
                                row["HT03"] = Convert.ToInt32(textBox3.Text);
                                row["HT04"] = textBox4.Text;
                                //row["XZ07"] = textBox10.Text;
                                //row["XZ08"] = textBox6.Text;
                                //row["XZ09"] = textBox7.Text;
                                //row["XZ10"] = textBox9.Text;
                                //row["XZ11"] = textBox8.Text;
                                ddt.Rows.Add(row);

                                SqlHelper.ExecuteNonQuery("INSERT INTO R_XZCGZYJKH (XZ01,XZ07,XZ08,XZ09,XZ10,XZ11,XZ12) VALUES (@XZ01,@XZ07,@XZ08,@XZ09,@XZ10,@XZ11,@XZ12)", new SqlParameter("@XZ12", XZ12), new SqlParameter("@XZ01", XZ001), new SqlParameter("@XZ07", XZ007), new SqlParameter("@XZ08", XZ008), new SqlParameter("@XZ09", XZ009), new SqlParameter("@XZ10", XZ010), new SqlParameter("@XZ11", XZ011));
                            }
                        }
                    }
                }
            }           
        }
        //删除
        private void button2_Click( object sender, EventArgs e )
        {
            //XZ001 = comboBox6.Text;
            ////HT001 = textBox1.Text;
            ////DEA02 = textBox2.Text;
            ////HT003 = Convert.ToInt32(textBox3.Text);
            ////HT004 = textBox4.Text;
            ////U04 = textBox5.Text;
            //XZ008 = textBox6.Text;
            //XZ009 = textBox7.Text;
            //XZ011 = textBox8.Text;
            //XZ010 = textBox9.Text;
            //XZ007 = textBox10.Text;
            //XZ12 = comboBox1.SelectedValue.ToString() + MulaolaoBll . Drity . GetDt ( ).ToString("yyyyMMdd");

            int num = bandedGridView1.FocusedRowHandle;
            if (gridControl1.DataSource == dtt)
            {
                dtt.Rows.RemoveAt(num);
                SqlHelper.ExecuteNonQuery("UPDATE R_XZCGZYJKH SET XZ01=@XZ01,XZ07=@XZ07,XZ08=@XZ08,XZ09=@XZ09,XZ10=@XZ10,XZ11=@XZ11 WHERE XZ12=@XZ12 AND XZ01=@XZ010", new SqlParameter("@XZ01", XZ001), new SqlParameter("@XZ07", XZ007), new SqlParameter("@XZ08", XZ008), new SqlParameter("@XZ09", XZ009), new SqlParameter("@XZ10", XZ010), new SqlParameter("@XZ11", XZ011), new SqlParameter("@XZ12", shi));
            }
            else
            {
                gridControl1.DataSource = ddt;
                ddt.Rows.RemoveAt(num);
                XZ001 = comboBox6.SelectedValue.ToString();
                XZ12 = comboBox1.SelectedValue.ToString() + MulaolaoBll . Drity . GetDt ( ).ToString("yyyyMMdd");
                SqlHelper.ExecuteNonQuery("DELETE FROM R_XZCGZYJKH WHERE XZ01=@XZ01 AND XZ12=@XZ12", new SqlParameter("@XZ01",XZ001), new SqlParameter("@XZ12",XZ12));
            }
        }
        //编辑
        private void button3_Click( object sender, EventArgs e )
        {
            int num = bandedGridView1.FocusedRowHandle;
            DataRow row;
            XZ001 = comboBox6.Text;
            HT001 = textBox1.Text;
            DEA02 = textBox2.Text;
            HT003 = Convert.ToInt32(textBox3.Text);
            HT004 = textBox4.Text;
            U04 = textBox5.Text;
            XZ008 = textBox6.Text;
            //XZ009 = textBox7.Text;
            //XZ011 = textBox8.Text;
            //XZ010 = textBox9.Text;
            //XZ007 = textBox10.Text;
            XZ12 = comboBox1.SelectedValue.ToString() + MulaolaoBll . Drity . GetDt ( ).ToString("yyyyMMdd");
            foreach (Control cn in this.Controls)
            {
                if (comboBox6.Text == "")
                {
                    MessageBox.Show("请选择流水号");
                }
                else
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
                            if (gridControl1.DataSource == dtt)
                            {
                                row = dtt.Rows[num];
                                row.BeginEdit();
                                row["XZ01"] = comboBox6.Text;
                                row["HT01"] = textBox1.Text;
                                row["DEA002"] = textBox2.Text;
                                row["HT03"] = Convert.ToInt32(textBox3.Text);
                                row["HT04"] = textBox4.Text;
                                //row["XZ07"] = textBox10.Text;
                                //row["XZ08"] = textBox6.Text;
                                //row["XZ09"] = textBox7.Text;
                                //row["XZ10"] = textBox9.Text;
                                //row["XZ11"] = textBox8.Text;
                                row.EndEdit();

                                SqlHelper.ExecuteNonQuery("UPDATE R_XZCGZYJKH SET XZ01=@XZ01,XZ07=@XZ07,XZ08=@XZ08,XZ09=@XZ09,XZ10=@XZ10,XZ11=@XZ11 WHERE XZ12=@XZ12 AND XZ01=@XZ001", new SqlParameter("@XZ01", XZ001), new SqlParameter("@XZ07", XZ007), new SqlParameter("@XZ08", XZ008), new SqlParameter("@XZ09", XZ009), new SqlParameter("@XZ10", XZ010), new SqlParameter("@XZ11", XZ011), new SqlParameter("@XZ12", shi),new SqlParameter("@XZ001",XZ1));
                            }
                            else
                            {
                                gridControl1.DataSource = ddt;

                                row = dtt.Rows[num];
                                row.BeginEdit();
                                row["XZ01"] = comboBox6.Text;
                                row["HT01"] = textBox1.Text;
                                row["DEA002"] = textBox2.Text;
                                row["HT03"] = Convert.ToInt32(textBox3.Text);
                                row["HT04"] = textBox4.Text;
                                //row["XZ07"] = textBox10.Text;
                                //row["XZ08"] = textBox6.Text;
                                //row["XZ09"] = textBox7.Text;
                                //row["XZ10"] = textBox9.Text;
                                //row["XZ11"] = textBox8.Text;
                                row.EndEdit();
                                
                                SqlHelper.ExecuteNonQuery("UPDATE R_XZCGZYJKH SET XZ01=@XZ01,XZ07=@XZ07,XZ08=@XZ08,XZ09=@XZ09,XZ10=@XZ10,XZ11=@XZ11 WHERE XZ01=@XZ01", new SqlParameter("@XZ01", XZ1), new SqlParameter("@XZ07", XZ007), new SqlParameter("@XZ08", XZ008), new SqlParameter("@XZ09", XZ009), new SqlParameter("@XZ10", XZ010), new SqlParameter("@XZ11", XZ011), new SqlParameter("@XZ12",XZ12));
                            }
                        }
                    }
                }
            }
        }
    }
}

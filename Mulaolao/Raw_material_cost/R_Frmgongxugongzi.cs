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

namespace Mulaolao.Raw_material_cost
{
    public partial class R_Frmgongxugongzi : FormChild
    {
        public R_Frmgongxugongzi(Form1 fm )
        {
            this.MdiParent = fm;
            InitializeComponent();
        }

        gongxugongzi gz = new gongxugongzi( );
        GroupBox[] gb;
        DataTable de;

        private void R_Frmgongxugongzi_Load( object sender, EventArgs e )
        {
            Power( this );

            gb = new GroupBox[] { groupBox1, groupBox3, groupBox5 };

            Ergodic.FormEvery( this );
            gridControl1.DataSource = null;         
            Ergodic.FormGroupboxEnableFalse( this, gb );

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;

            textBox14.Enabled = false;

            DataTable biao = SqlHelper.ExecuteDataTable( "SELECT DS06,DS07,DS17,DS10 FROM R_PQR" );
            //实日产量
            DataTable sr = biao.DefaultView.ToTable( true, "DS06" );
            comboBox4.DataSource = sr;
            comboBox4.DisplayMember = "DS06";
            //计划单价
            DataTable jd = biao.DefaultView.ToTable( true, "DS07" );
            comboBox5.DataSource = jd;
            comboBox5.DisplayMember = "DS07";
            //本工序名称
            DataTable bgx = biao.DefaultView.ToTable( true, "DS17" );
            comboBox6.DataSource = bgx;
            comboBox6.DisplayMember = "DS17";
            //接收单位
            DataTable jsdw = biao.DefaultView.ToTable( true, "DS10" );
            comboBox7.DataSource = jsdw;
            comboBox7.DisplayMember = "DS10";
        }

        #region  查询
        string chx = "";
        //查询
        protected override void select( )
        {
            base.select( );
        
        DataTable da = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQR" );
            if (da.Rows.Count < 0)
            {
                MessageBox.Show( "没有数据" );
            }
            else
            {
                DataTable del = SqlHelper.ExecuteDataTable( "SELECT DISTINCT DS01,PQF04,PQF03,PQF06,PQF17,DAA002,PQF31 FROM R_PQR A,R_PQF B,TPADAA C WHERE A.DS01=B.PQF01 AND B.PQF17=C.DAA001" );
                if (del.Rows.Count < 1)
                {
                    MessageBox.Show( "产品信息为空" );
                }
                else
                {
                    gz.gridControl1.DataSource = del;
                    gz.gonxu = "1";
                    chx = "1";
                    gz.PassDataBetweenForm += new gongxugongzi.PassDataBetweenFormHandler( gz_PassDataBetweenForm );
                    gz.StartPosition = FormStartPosition.CenterScreen;
                    gz.ShowDialog( );

                    if (DS01 == "")
                    {
                        MessageBox.Show( "您没有选择任何内容" );
                    }
                    else
                    {
                        Ergodic.FormGroupboxEnableFalse( this, gb );

                        toolSelect.Enabled = true;
                        toolAdd.Enabled = true;
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

                        textBox14.Enabled = false;

                        sav = "2";

                        DataTable drs = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQR WHERE DS01=(SELECT DISTINCT DS01 FROM R_PQR WHERE DS01=@DS01)", new SqlParameter( "@DS01", DS01 ) );
                        if (drs.Rows.Count < 1)
                        {
                            Ergodic.FormEvery( this );
                            gridControl1.DataSource = null;
                        }
                        else
                        {
                            comboBox7.Text = drs.Rows[0]["DS10"].ToString( );
                            textBox12.Text = drs.Rows[0]["DS11"].ToString( );
                            if (drs.Rows[0]["DS12"].ToString( ) != "")
                            {
                                dateTimePicker2.Value = Convert.ToDateTime( drs.Rows[0]["DS12"].ToString( ) );
                            }
                            textBox13.Text = drs.Rows[0]["DS13"].ToString( );
                            if (drs.Rows[0]["DS14"].ToString( ) != "")
                            {
                                dateTimePicker3.Value = Convert.ToDateTime( drs.Rows[0]["DS14"].ToString( ) );
                            }

                            textBox14.Text = drs.Rows[0]["DS19"].ToString( );

                            de = SqlHelper.ExecuteDataTable( "SELECT DS02,DS18,DS03,DS04,DS17,DS05,DS06,DS07,DS08,DS15,DS16,DS09 FROM R_PQR WHERE DS01=@DS01", new SqlParameter( "@DS01", DS01 ) );
                            gridControl1.DataSource = de;
                        }
                    }
                }
            }
        }
        private void gz_PassDataBetweenForm( object sender, PassDataWinFormEventArgs e )
        {
            if (chx == "1")
            {
                textBox1.Text = e.ConOne;
                DS01 = e.ConTwo;
                textBox18.Text = e.ConTwo;
                textBox2.Text = e.ConTre;
                textBox3.Text = e.ConFor;
                textBox4.Text = e.ConFiv;
                if (e.ConSix != "")
                {
                    dateTimePicker1.Value = Convert.ToDateTime( e.ConSix );
                }
            }
            else if (chx == "2")
            {
                DS2 = e.ConOne;
                textBox10.Text = e.ConOne;
                textBox7.Text = e.ConTwo;
                if (e.ConTwo != "")
                {
                    DS018 = Convert.ToDecimal( e.ConTwo );
                }
            }
            else if (chx == "3")
            {
                textBox5.Text = e.ConOne;
                textBox6.Text = e.ConTwo;
                textBox8.Text = e.ConTre;
            }
        }
        //流水查询
        private void button4_Click( object sender, EventArgs e )
        {
            DataTable lius = SqlHelper.ExecuteDataTable( "SELECT PQF01,PQF04,PQF03,PQF06,PQF17,DAA002,PQF31 FROM R_PQF B,TPADAA C WHERE  B.PQF17=C.DAA001" );
            if (lius.Rows.Count < 1)
            {
                MessageBox.Show( "没有产品信息" );
            }
            else
            {
                gz.gridControl1.DataSource = lius;
                gz.gonxu = "2";
                chx = "1";
                gz.PassDataBetweenForm += new gongxugongzi.PassDataBetweenFormHandler( gz_PassDataBetweenForm );
                gz.StartPosition = FormStartPosition.CenterScreen;
                gz.ShowDialog( );
            }
        }
        //工段查询
        private void button5_Click( object sender, EventArgs e )
        {
            DataTable gond = SqlHelper.ExecuteDataTable( "SELECT GS02,GS04 FROM R_PQP GROUP BY GS02,GS04" );
            if (gond.Rows.Count < 1)
            {
                MessageBox.Show( "产品每套成本改善控制表(R_509)表中没有材质工段等信息" );
            }
            else
            {
                gz.gridControl1.DataSource = gond;
                gz.gonxu = "3";
                chx = "2";
                gz.PassDataBetweenForm += new gongxugongzi.PassDataBetweenFormHandler( gz_PassDataBetweenForm );
                gz.StartPosition = FormStartPosition.CenterScreen;
                gz.ShowDialog( );
            }
        }
        //定日产量查询
        private void button6_Click( object sender, EventArgs e )
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show( "请选择零件名称" );
            }
            else
            {
                DataTable dinri = SqlHelper.ExecuteDataTable( "SELECT (GZ09+GZ10+GZ11+GZ12+GZ13+GZ14) U0,GZ06,GZ05*(GZ12+GZ13+GZ14) U1 FROM R_PQW WHERE  GZ03=@GZ03", new SqlParameter( "@GZ03", comboBox1.Text ) );
                if (dinri.Rows.Count < 1)
                {
                    MessageBox.Show( "产品工资考勤表(R_317)没有实日产量等信息" );
                }
                else
                {
                    gz.gridControl1.DataSource = dinri;
                    gz.gonxu = "4";
                    chx = "3";
                    gz.PassDataBetweenForm += new gongxugongzi.PassDataBetweenFormHandler( gz_PassDataBetweenForm );
                    gz.StartPosition = FormStartPosition.CenterScreen;
                    gz.ShowDialog( );
                }
            }          
        }
        #endregion

        #region 事件
        string ds3 = "", ds4 = "", ds017 = "";
        //表
        private void bandedGridView1_FocusedRowChanged( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
            if (bandedGridView1.RowCount < 1)
            {
                Ergodic.GroupboxEvery( groupBox3 );
            }
            else
            {
                textBox10.Text = bandedGridView1.GetRowCellValue( e.FocusedRowHandle, "DS02" ).ToString( );
                textBox7.Text = bandedGridView1.GetRowCellValue( e.FocusedRowHandle, "DS18" ).ToString( );
                comboBox1.Text = bandedGridView1.GetRowCellValue( e.FocusedRowHandle, "DS03" ).ToString( );
                comboBox2.Text = bandedGridView1.GetRowCellValue( e.FocusedRowHandle, "DS04" ).ToString( );
                comboBox6.Text = bandedGridView1.GetRowCellValue( e.FocusedRowHandle, "DS17" ).ToString( );
                comboBox3.Text = bandedGridView1.GetRowCellValue( e.FocusedRowHandle, "DS05" ).ToString( );
                comboBox4.Text = bandedGridView1.GetRowCellValue( e.FocusedRowHandle, "DS06" ).ToString( );
                comboBox5.Text = bandedGridView1.GetRowCellValue( e.FocusedRowHandle, "DS07" ).ToString( );
                textBox5.Text = bandedGridView1.GetRowCellValue( e.FocusedRowHandle, "DS08" ).ToString( );
                textBox6.Text = bandedGridView1.GetRowCellValue( e.FocusedRowHandle, "DS15" ).ToString( );
                textBox8.Text = bandedGridView1.GetRowCellValue( e.FocusedRowHandle, "DS16" ).ToString( );
                textBox9.Text = bandedGridView1.GetRowCellValue( e.FocusedRowHandle, "DS09" ).ToString( );
                ds3 = comboBox1.Text;
                ds4 = comboBox2.Text;
                ds017 = comboBox6.Text;
            }
        }
        private void bandedGridView1_Click( object sender, EventArgs e )
        {
            if (bandedGridView1.RowCount == 1)
            {
                textBox10.Text = bandedGridView1.GetFocusedRowCellValue(  "DS02" ).ToString( );
                textBox7.Text = bandedGridView1.GetFocusedRowCellValue( "DS18" ).ToString( );
                comboBox1.Text = bandedGridView1.GetFocusedRowCellValue( "DS03" ).ToString( );
                comboBox2.Text = bandedGridView1.GetFocusedRowCellValue( "DS04" ).ToString( );
                comboBox3.Text = bandedGridView1.GetFocusedRowCellValue( "DS05" ).ToString( );
                comboBox4.Text = bandedGridView1.GetFocusedRowCellValue( "DS06" ).ToString( );
                comboBox5.Text = bandedGridView1.GetFocusedRowCellValue( "DS07" ).ToString( );
                textBox5.Text = bandedGridView1.GetFocusedRowCellValue( "DS08" ).ToString( );
                textBox6.Text = bandedGridView1.GetFocusedRowCellValue( "DS15" ).ToString( );
                textBox8.Text = bandedGridView1.GetFocusedRowCellValue( "DS16" ).ToString( );
                textBox9.Text = bandedGridView1.GetFocusedRowCellValue( "DS09" ).ToString( );
                ds3 = comboBox1.Text;
                ds4 = comboBox2.Text;
                ds017 = comboBox6.Text;
            }
        }
        //定日工资额
        private void comboBox3_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
                MessageBox.Show( "只允许输入整数" );
            }
        }
        //定日产量
        private void comboBox4_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
                MessageBox.Show( "只允许输入整数" );
            }
        }
        //计划单价
        private void comboBox5_KeyPress( object sender, KeyPressEventArgs e )
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
                if (comboBox5.Text.LastIndexOf( '.' ) != -1)
                {
                    e.Handled = true;
                    MessageBox.Show( "只能输入一个小数点" );
                }
            }
        }
        private void comboBox5_TextChanged( object sender, EventArgs e )
        {
            if (comboBox5.Text.Substring( 0 ) == ".")
            {
                comboBox5.Text = "0.";
                comboBox5.SelectionStart = 2;
            }
        }
        private void comboBox5_LostFocus( object sender, EventArgs e )
        {
            if (comboBox5.Text != "" && !DateDay.sevenFour( comboBox5 ))
            {
                this.comboBox5.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多四位,如999.9999,请重新输入" );
            }
        }
        //窗体
        private void R_Frmgongxugongzi_FormClosing( object sender, FormClosingEventArgs e )
        {
            if (toolSave.Enabled)
            {
                MessageBox.Show( "请保存或取消" );
                e.Cancel = true;
            }
        }
        //流水号
        private void textBox18_TextChanged( object sender, EventArgs e )
        {
            if (textBox18.Text != "")
            {
                DataTable de = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQX WHERE PQX01=@PQX01", new SqlParameter( "@PQX01", textBox18.Text ) );
                if (de.Rows.Count > 0)
                {
                    DataTable ljmc = de.DefaultView.ToTable( true, "PQX14" );
                    comboBox1.DataSource = ljmc;
                    comboBox1.DisplayMember = "PQX14";
                    DataTable gx = de.DefaultView.ToTable( true, "PQX15" );
                    comboBox2.DataSource = gx;
                    comboBox2.DisplayMember = "PQX15";
                }
            }
        }
        //填表人签字
        private void button7_Click( object sender, EventArgs e )
        {
            if (textBox12.Text == "")
            {
                textBox12.Text = Logins.username;
            }
            else if (textBox12.Text != "" && textBox12.Text == Logins.username)
            {
                textBox12.Text = "";
            }
        }
        //审批人签字
        private void button8_Click( object sender, EventArgs e )
        {
            if (textBox13.Text == "")
            {
                textBox13.Text = Logins.username;
            }
            else if (textBox13.Text != "" && textBox13.Text == Logins.username)
            {
                textBox13.Text = "";
            }
        }
        #endregion

        #region 主体
        string DS01 = "", DS2 = "", DS3 = "", DS4 = "", DS9 = "", DS10 = "", DS11 = "", DS13 = "", DS017 = "", sav = "", DS19 = "", DS20 = "";
        decimal DS7 = 0M, DS018 = 0M, DS015 = 0M;
        long DS5 = 0, DS6 = 0, DS8 = 0, DS016 = 0;
        DateTime DS12 = System.DateTime.Now, DS14 = System.DateTime.Now;
        //新增
        protected override void add( )
        {
            base.add( );

            Ergodic.FormEvery( this );
            gridControl1.DataSource = null;
            Ergodic.FormGroupboxEnableTrue( this, gb );

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;

            sav = "1";
        }
        //删除
        protected override void delete( )
        {
            base.delete( );

            DS01 = textBox18.Text;
            DataTable del = SqlHelper.ExecuteDataTable( "SELECT * FROM R_REVIEWS A,R_MLLCXMC B WHERE A.RES01=B.CX01 AND RES05='执行' AND RES06=@RES06 AND CX02=@CX02 ", new SqlParameter( "@RES06", DS01 ), new SqlParameter( "@CX02", this.Text ) );
            if (del != null && del.Rows.Count > 0)
            {
                MessageBox.Show( "流水号:" + DS01 + "的单据状态为执行,不允许删除" );
            }
            else
            {
                if (textBox18.Text == "")
                {
                    MessageBox.Show( "请查询需要删除的数据" );
                }
                else
                {
                    int count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQR WHERE DS01=@DS01", new SqlParameter( "@DS01", DS01 ) );
                    if (count < 0)
                    {
                        MessageBox.Show( "删除数据失败" );
                    }
                    else
                    {
                        MessageBox.Show( "成功删除数据" );
                        Ergodic.FormEvery( this );
                        gridControl1.DataSource = null;
                        Ergodic.FormGroupboxEnableFalse( this, gb );

                        toolSelect.Enabled = true;
                        toolAdd.Enabled = true;
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

                        textBox14.Enabled = false;
                    }
                }
            }
        }
        //更改
        protected override void update( )
        {
            base.update( );

            DS01 = textBox18.Text;
            DataTable del = SqlHelper.ExecuteDataTable( "SELECT * FROM R_REVIEWS A,R_MLLCXMC B WHERE A.RES01=B.CX01 AND RES05='执行' AND RES06=@RES06 AND CX02=@CX02 ", new SqlParameter( "@RES06", DS01 ), new SqlParameter( "@CX02", this.Text ) );
            if (del != null && del.Rows.Count > 0)
            {
                MessageBox.Show( "流水号:" + DS01 + "的单据状态为执行,不允许更改" );
            }
            else
            {
                Ergodic.FormGroupboxEnableTrue( this, gb );

                toolSelect.Enabled = false;
                toolAdd.Enabled = false;
                toolDelete.Enabled = false;
                toolUpdate.Enabled = false;
                toolReview.Enabled = false;
                toolPrint.Enabled = true;
                toolExport.Enabled = true;
                toolMaintain.Enabled = false;
                toolSave.Enabled = true;
                toolCancel.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;

                textBox14.Enabled = false;
            }
        }
        //送审
        protected override void revirw( )
        {
            base.revirw( );

            Reviews( "DS01", textBox18.Text, "R_PQR", this );
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

            if (textBox18.Text == "")
            {
                MessageBox.Show( "请查询流水号" );
            }
            else
            {
                DS10 = comboBox7.Text;
                DS11 = textBox12.Text;
                DS12 = dateTimePicker2.Value;
                DS13 = textBox13.Text;
                DS14 = dateTimePicker3.Value;
                DataTable saves = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQR WHERE DS01=@DS01", new SqlParameter( "@DS01", DS01 ) );

                if (weihu == "1")
                {
                    if (textBox14.Text == "")
                    {
                        MessageBox.Show( "请输入维护意见" );
                    }
                    else
                    {
                        if (saves.Rows.Count < 1)
                        {
                            MessageBox.Show( "流水号:" + DS01 + "的记录不存在,请核实后再维护" );
                        }
                        else
                        {
                            DS19 = textBox14.Text;
                            DS20 = saves.Rows[0]["DS20"].ToString( ) + "[" + Logins.username + System.DateTime.Now.ToString( "yyyyMMdd" ) + "]";

                            int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQR SET DS10=@DS10,DS11=@DS11,DS12=@DS12,DS13=@DS13,DS14=@DS14,DS19=@DS19,DS20=@DS20 WHERE DS01=@DS01", new SqlParameter( "@DS01", DS01 ), new SqlParameter( "@DS10", DS10 ), new SqlParameter( "@DS11", DS11 ), new SqlParameter( "@DS12", DS12 ), new SqlParameter( "@DS13", DS13 ), new SqlParameter( "@DS14", DS14 ), new SqlParameter( "@DS19", DS19 ), new SqlParameter( "@DS20", DS20 ) );
                            if (count < 1)
                            {
                                MessageBox.Show( "录入数据失败" );
                            }
                            else
                            {
                                MessageBox.Show( "成功录入数据" );

                                Ergodic.FormGroupboxEnableFalse( this, gb );

                                toolSelect.Enabled = true;
                                toolAdd.Enabled = true;
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

                                textBox14.Enabled = false;
                            }
                        }
                    }
                }
                else
                {
                    if (saves.Rows.Count < 1)
                    {
                        int count = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQR (DS01,DS10,DS11,DS12,DS13,DS14) VALUES (@DS01,@DS10,@DS11,@DS12,@DS13,@DS14)", new SqlParameter( "@DS01", DS01 ), new SqlParameter( "@DS10", DS10 ), new SqlParameter( "@DS11", DS11 ), new SqlParameter( "@DS12", DS12 ), new SqlParameter( "@DS13", DS13 ), new SqlParameter( "@DS14", DS14 ) );
                        if (count < 1)
                        {
                            MessageBox.Show( "录入数据失败" );
                        }
                        else
                        {
                            MessageBox.Show( "成功录入数据" );

                            Ergodic.FormGroupboxEnableFalse( this, gb );

                            toolSelect.Enabled = true;
                            toolAdd.Enabled = true;
                            toolDelete.Enabled = true;
                            toolUpdate.Enabled = true;
                            toolReview.Enabled = true;
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

                            textBox14.Enabled = false;
                        }
                    }
                    else
                    {
                        int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQR SET DS10=@DS10,DS11=@DS11,DS12=@DS12,DS13=@DS13,DS14=@DS14 WHERE DS01=@DS01", new SqlParameter( "@DS01", DS01 ), new SqlParameter( "@DS10", DS10 ), new SqlParameter( "@DS11", DS11 ), new SqlParameter( "@DS12", DS12 ), new SqlParameter( "@DS13", DS13 ), new SqlParameter( "@DS14", DS14 ) );
                        if (count < 1)
                        {
                            MessageBox.Show( "录入数据失败" );
                        }
                        else
                        {
                            MessageBox.Show( "成功录入数据" );

                            Ergodic.FormGroupboxEnableFalse( this, gb );

                            toolSelect.Enabled = true;
                            toolAdd.Enabled = true;
                            toolDelete.Enabled = true;
                            toolUpdate.Enabled = true;
                            toolReview.Enabled = true;
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

                            textBox14.Enabled = false;
                        }
                    }
                }
            }
        }
        //取消
        protected override void cancel( )
        {
            base.cancel( );
            
            if (sav == "1" && weihu=="1")
            {
                try
                {
                    DS01 = textBox18.Text;
                    SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQR WHERE DS01=@DS01", new SqlParameter( "@DS01", DS01 ) );
                }
                catch { }
                finally
                {
                    Ergodic.FormEvery( this );
                    gridControl1.DataSource = null;

                    toolSelect.Enabled = true;
                    toolAdd.Enabled = true;
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
                    button5.Enabled = false;
                    button6.Enabled = false;
                }
            }
            else if (sav == "2" || weihu=="1")
            {
                toolSelect.Enabled = true;
                toolAdd.Enabled = true;
                toolDelete.Enabled = true;
                toolUpdate.Enabled = true;
                toolReview.Enabled = false;
                toolPrint.Enabled = true;
                toolExport.Enabled = true;
                toolSave.Enabled = false;
                toolCancel.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
            }

            Ergodic.FormGroupboxEnableFalse( this, gb );
            textBox14.Enabled = false;
        }
        //维护
        string weihu = "";
        protected override void maintain( )
        {
            base.maintain( );

            DS01 = textBox18.Text;
            DataTable del = SqlHelper.ExecuteDataTable( "SELECT RES03,RES05,RES06,DBA012,CX02 FROM TPADBA A,R_REVIEW B,R_REVIEWS C,R_MLLCXMC D WHERE A.DBA001=B.RE01 AND B.RE01=C.RES03 AND C.RES01=D.CX01 AND RES06=@RES06 AND CX02=@CX02", new SqlParameter( "@RES06", DS01 ), new SqlParameter( "@CX02", this.Text ) );
            if (del != null && del.Rows.Count > 0)
            {
                if (del.Select( "RES05='执行'" ).Length > 0)
                {
                    toolAdd.Enabled = false;
                    toolSelect.Enabled = false;
                    toolDelete.Enabled = false;
                    toolUpdate.Enabled = false;
                    toolReview.Enabled = false;
                    toolMaintain.Enabled = false;
                    toolPrint.Enabled = false;
                    toolExport.Enabled = false;
                    toolCancel.Enabled = true;
                    toolSave.Enabled = true;
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button5.Enabled = true;
                    button6.Enabled = true;
                    button4.Enabled = true;
                    button7.Enabled = true;
                    button8.Enabled = true;

                    Ergodic.FormGroupboxEnableTrue( this, gb );

                    textBox14.Enabled = true;

                    weihu = "1";
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
        DataTable del;
        //新建
        private void button1_Click( object sender, EventArgs e )
        {
            if (textBox18.Text == "")
            {
                MessageBox.Show( "请选择流水号" );
            }
            else
            {
                if (comboBox1.Text == "")
                {
                    MessageBox.Show( "请选择零件名称" );
                }
                else
                {
                    if (comboBox2.Text == "")
                    {
                        MessageBox.Show( "请选择或填写工序" );
                    }
                    else
                    {
                        DS2 = textBox10.Text;
                        if (textBox7.Text == "")
                        {
                            DS018 = 0M;
                        }
                        else
                        {
                            DS018 = Convert.ToDecimal( textBox7.Text );
                        }
                        DS3 = comboBox1.Text;
                        DS4 = comboBox2.Text;
                        DS017 = comboBox6.Text;
                        if (comboBox3.Text == "")
                        {
                            DS5 = 0;
                        }
                        else
                        {
                            DS5 = Convert.ToInt64( comboBox3.Text );
                        }
                        if (comboBox4.Text == "")
                        {
                            DS6 = 0;
                        }
                        else
                        {
                            DS6 = Convert.ToInt64( comboBox4.Text );
                        }
                        if (comboBox5.Text == "")
                        {
                            DS7 = 0M;
                        }
                        else
                        {
                            DS7 = Convert.ToDecimal( comboBox5.Text );
                        }
                        if (textBox5.Text == "")
                        {
                            DS8 = 0;
                        }
                        else
                        {
                            DS8 = Convert.ToInt64( textBox5.Text );
                        }
                        if (textBox6.Text == "")
                        {
                            DS015 = 0M;
                        }
                        else
                        {
                            DS015 = Convert.ToDecimal( textBox6.Text );
                        }
                        if (textBox8.Text == "")
                        {
                            DS016 = 0;
                        }
                        else
                        {
                            DS016 = Convert.ToInt64( textBox8.Text );
                        }
                        DS9 = textBox9.Text;

                        DataTable dbi = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQR WHERE DS01=@DS01 AND DS03=@DS03 AND DS04=@DS04 AND DS17=@DS17", new SqlParameter( "@DS01", DS01 ), new SqlParameter( "@DS03", DS3 ), new SqlParameter( "@DS04", DS4 ), new SqlParameter( "@DS17", DS017 ) );
                        if (dbi.Rows.Count < 1)
                        {
                            int count = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQR (DS01,DS02,DS18,DS03,DS04,DS17,DS05,DS06,DS07,DS08,DS15,DS16,DS09) VALUES (@DS01,@DS02,@DS18,@DS03,@DS04,@DS17,@DS05,@DS06,@DS07,@DS08,@DS15,@DS16,@DS09)", new SqlParameter( "@DS01", DS01 ), new SqlParameter( "@DS02", DS2 ), new SqlParameter( "@DS18", DS018 ), new SqlParameter( "@DS03", DS3 ), new SqlParameter( "@DS04", DS4 ), new SqlParameter( "@DS17", DS017 ), new SqlParameter( "@DS05", DS5 ), new SqlParameter( "@DS06", DS6 ), new SqlParameter( "@DS07", DS7 ), new SqlParameter( "@DS08", DS8 ), new SqlParameter( "@DS15", DS015 ), new SqlParameter( "@DS16", DS016 ), new SqlParameter( "@DS09", DS9 ) );
                            if (count < 1)
                            {
                                MessageBox.Show( "录入数据失败" );
                            }
                            else
                            {
                                MessageBox.Show( "成功录入数据" );
                                DataRow row;
                                if (sav=="1")
                                {
                                    del = SqlHelper.ExecuteDataTable( "SELECT DS02,DS18,DS03,DS04,DS17,DS05,DS06,DS07,DS08,DS15,DS16,DS09 FROM R_PQR WHERE DS01=@DS01", new SqlParameter( "@DS01", DS01 ) );
                                    gridControl1.DataSource = del;
                                }
                                else if(sav=="2")
                                {
                                    row = de.NewRow( );
                                    row["DS02"] = DS2;
                                    row["DS18"] = DS018;
                                    row["DS03"] = DS3;
                                    row["DS04"] = DS4;
                                    row["DS17"] = DS017;
                                    row["DS05"] = DS5;
                                    row["DS06"] = DS6;
                                    row["DS07"] = DS7;
                                    row["DS08"] = DS8;
                                    row["DS15"] = DS015;
                                    row["DS16"] = DS016;
                                    row["DS09"] = DS9;
                                    de.Rows.Add( row );
                                }
                                DataTable biao = SqlHelper.ExecuteDataTable( "SELECT DS06,DS07,DS17 FROM R_PQR" );
                                //实日产量
                                DataTable sr = biao.DefaultView.ToTable( true, "DS06" );
                                comboBox4.DataSource = sr;
                                comboBox4.DisplayMember = "DS06";
                                //计划单价
                                DataTable jd = biao.DefaultView.ToTable( true, "DS07" );
                                comboBox5.DataSource = jd;
                                comboBox5.DisplayMember = "DS07";
                                //本工序名称
                                DataTable bgx = biao.DefaultView.ToTable( true, "DS17" );
                                comboBox6.DataSource = bgx;
                                comboBox6.DisplayMember = "DS17";
                            }
                        }
                        else
                        {
                            MessageBox.Show( "" + label2.Text + ":" + textBox18.Text + "\n\r" + label10.Text + ":" + comboBox1.Text + "\n\r" + label9.Text + ":" + comboBox2.Text + "\n\r" + label23.Text + ":" + comboBox6.Text + "\n\r的数据已经存在,请核实后再录入" );
                        }
                    }
                }
            }
        }
        //删除
        private void button2_Click( object sender, EventArgs e )
        {
            if (textBox18.Text == "")
            {
                MessageBox.Show( "请选择流水号" );
            }
            else
            {
                if (comboBox1.Text == "")
                {
                    MessageBox.Show( "请选择零件名称" );
                }
                else
                {
                    if (comboBox2.Text == "")
                    {
                        MessageBox.Show( "请选择或填写工序" );
                    }
                    else
                    {
                        DS3 = comboBox1.Text;
                        DS4 = comboBox2.Text;
                        DS017 = comboBox6.Text;
                        int num = bandedGridView1.FocusedRowHandle;
                        DataTable dele = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQR WHERE DS01=@DS01 AND DS03=@DS03 AND DS04=@DS04 AND DS17=@DS17", new SqlParameter( "@DS01", DS01 ), new SqlParameter( "@DS03", DS3 ), new SqlParameter( "@DS04", DS4 ), new SqlParameter( "@DS17", DS017 ) );
                        if (dele.Rows.Count < 1)
                        {
                            MessageBox.Show( "不存在\n\r" + label2.Text + ":" + textBox18.Text + "\n\r" + label10.Text + ":" + comboBox1.Text + "\n\r" + label9.Text + ":" + comboBox2.Text + "\n\r" + label23.Text + ":" + comboBox6.Text + "\n\r的数据, 请核实后再删除" );
                        }
                        else
                        {
                            int count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQR WHERE DS01=@DS01 AND DS03=@DS03 AND DS04=@DS04 AND DS17=@DS17", new SqlParameter( "@DS01", DS01 ), new SqlParameter( "@DS03", DS3 ), new SqlParameter( "@DS04", DS4 ), new SqlParameter( "@DS17", DS017 ) );
                            if (count < 1)
                            {
                                MessageBox.Show( "删除数据失败" );
                            }
                            else
                            {
                                MessageBox.Show( "成功删除数据" );

                                if (sav == "1")
                                {
                                    del.Rows.RemoveAt( num );
                                }
                                else if (sav == "2")
                                {
                                    de.Rows.RemoveAt( num );
                                }

                                DataTable biao = SqlHelper.ExecuteDataTable( "SELECT DS06,DS07,DS17 FROM R_PQR" );
                                //实日产量
                                DataTable sr = biao.DefaultView.ToTable( true, "DS06" );
                                comboBox4.DataSource = sr;
                                comboBox4.DisplayMember = "DS06";
                                //计划单价
                                DataTable jd = biao.DefaultView.ToTable( true, "DS07" );
                                comboBox5.DataSource = jd;
                                comboBox5.DisplayMember = "DS07";
                                //本工序名称
                                DataTable bgx = biao.DefaultView.ToTable( true, "DS17" );
                                comboBox6.DataSource = bgx;
                                comboBox6.DisplayMember = "DS17";
                            }
                        }
                    }
                }
            }
        }
        //更新
        private void button3_Click( object sender, EventArgs e )
        {
            if (textBox18.Text == "")
            {
                MessageBox.Show( "请选择流水号" );
            }
            else
            {
                if (comboBox1.Text == "")
                {
                    MessageBox.Show( "请选择零件名称" );
                }
                else
                {
                    if (comboBox2.Text == "")
                    {
                        MessageBox.Show( "请选择或填写工序" );
                    }
                    else
                    {
                        DS2 = textBox10.Text;
                        if (textBox7.Text == "")
                        {
                            DS018 = 0M;
                        }
                        else
                        {
                            DS018 = Convert.ToDecimal( textBox7.Text );
                        }
                        DS3 = comboBox1.Text;
                        DS4 = comboBox2.Text;
                        DS017 = comboBox6.Text;
                        if (comboBox3.Text == "")
                        {
                            DS5 = 0;
                        }
                        else
                        {
                            DS5 = Convert.ToInt64( comboBox3.Text );
                        }
                        if (comboBox4.Text == "")
                        {
                            DS6 = 0;
                        }
                        else
                        {
                            DS6 = Convert.ToInt64( comboBox4.Text );
                        }
                        if (comboBox5.Text == "")
                        {
                            DS7 = 0M;
                        }
                        else
                        {
                            DS7 = Convert.ToDecimal( comboBox5.Text );
                        }
                        if (textBox5.Text == "")
                        {
                            DS8 = 0;
                        }
                        else
                        {
                            DS8 = Convert.ToInt64( textBox5.Text );
                        }
                        if (textBox6.Text == "")
                        {
                            DS015 = 0M;
                        }
                        else
                        {
                            DS015 = Convert.ToDecimal( textBox6.Text );
                        }
                        if (textBox8.Text == "")
                        {
                            DS016 = 0;
                        }
                        else
                        {
                            DS016 = Convert.ToInt64( textBox8.Text );
                        }
                        DS9 = textBox9.Text;
                        DataRow row;
                        int num = bandedGridView1.FocusedRowHandle;
                        if (DS3 == ds3 && DS4 == ds4 && DS017 == ds017)
                        {
                            int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQR SET DS02=@DS02,DS18=@DS18,DS05=@DS05,DS06=@DS06,DS07=@DS07,DS08=@DS08,DS15=@DS15,DS16=@DS16,DS09=@DS09 WHERE DS01=@DS01 AND DS03=@DS03 AND DS04=@DS04 AND DS17=@DS17", new SqlParameter( "@DS01", DS01 ), new SqlParameter( "@DS02", DS2 ), new SqlParameter( "@DS18", DS018 ), new SqlParameter( "@DS03", DS3 ), new SqlParameter( "@DS04", DS4 ), new SqlParameter( "@DS17", DS017 ), new SqlParameter( "@DS05", DS5 ), new SqlParameter( "@DS06", DS6 ), new SqlParameter( "@DS07", DS7 ), new SqlParameter( "@DS08", DS8 ), new SqlParameter( "@DS15", DS015 ), new SqlParameter( "@DS16", DS016 ), new SqlParameter( "@DS09", DS9 ) );
                            if (count < 1)
                            {
                                MessageBox.Show( "编辑数据失败" );
                            }
                            else
                            {
                                MessageBox.Show( "成功编辑数据" );

                                if (sav == "1")
                                {
                                    row = del.Rows[num];
                                    row.BeginEdit( );
                                    row["DS02"] = DS2;
                                    row["DS18"] = DS018;
                                    row["DS03"] = DS3;
                                    row["DS04"] = DS4;
                                    row["DS17"] = DS017;
                                    row["DS05"] = DS5;
                                    row["DS06"] = DS6;
                                    row["DS07"] = DS7;
                                    row["DS08"] = DS8;
                                    row["DS15"] = DS015;
                                    row["DS16"] = DS016;
                                    row["DS09"] = DS9;
                                    row.EndEdit( );
                                }
                                else if (sav == "2")
                                {
                                    row = de.Rows[num];
                                    row.BeginEdit( );
                                    row["DS02"] = DS2;
                                    row["DS18"] = DS018;
                                    row["DS03"] = DS3;
                                    row["DS04"] = DS4;
                                    row["DS17"] = DS017;
                                    row["DS05"] = DS5;
                                    row["DS06"] = DS6;
                                    row["DS07"] = DS7;
                                    row["DS08"] = DS8;
                                    row["DS15"] = DS015;
                                    row["DS16"] = DS016;
                                    row["DS09"] = DS9;
                                    row.EndEdit( );
                                }

                                DataTable biao = SqlHelper.ExecuteDataTable( "SELECT DS06,DS07,DS17 FROM R_PQR" );
                                //实日产量
                                DataTable sr = biao.DefaultView.ToTable( true, "DS06" );
                                comboBox4.DataSource = sr;
                                comboBox4.DisplayMember = "DS06";
                                //计划单价
                                DataTable jd = biao.DefaultView.ToTable( true, "DS07" );
                                comboBox5.DataSource = jd;
                                comboBox5.DisplayMember = "DS07";
                                //本工序名称
                                DataTable bgx = biao.DefaultView.ToTable( true, "DS17" );
                                comboBox6.DataSource = bgx;
                                comboBox6.DisplayMember = "DS17";
                            }
                        }
                        else
                        {
                            DataTable dce = SqlHelper.ExecuteDataTable( "SELECT * RFOM R_PQR WHERE DS01=@DS01 AND DS03=@DS03 AND DS04=@DS04 AND DS17=@DS17", new SqlParameter( "@DS01", DS01 ), new SqlParameter( "@DS03", DS3 ), new SqlParameter( "@DS04", DS4 ), new SqlParameter( "@DS17", DS017 ) );
                            if (dce.Rows.Count < 1)
                            {
                                int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQR SET DS02 = @DS02, DS03 = @DS03, DS04 = @DS04, DS17 = @DS17, DS18 = @DS18, DS05 = @DS05, DS06 = @DS06, DS07 = @DS07, DS08 = @DS08, DS15 = @DS15, DS16 = @DS16, DS09 = @DS09 WHERE DS01 = @DS01 AND DS03 = @DS3 AND DS04 = @DS4 AND DS17 = @DS017", new SqlParameter( "@DS01", DS01 ), new SqlParameter( "@DS02", DS2 ), new SqlParameter( "@DS18", DS018 ), new SqlParameter( "@DS03", DS3 ), new SqlParameter( "@DS04", DS4 ), new SqlParameter( "@DS17", DS017 ), new SqlParameter( "@DS05", DS5 ), new SqlParameter( "@DS06", DS6 ), new SqlParameter( "@DS07", DS7 ), new SqlParameter( "@DS08", DS8 ), new SqlParameter( "@DS15", DS015 ), new SqlParameter( "@DS16", DS016 ), new SqlParameter( "@DS09", DS9 ), new SqlParameter( "@DS3", ds3 ), new SqlParameter( "@DS4", ds4 ), new SqlParameter( "@DS017", ds017 ) );
                                if (count < 1)
                                {
                                    MessageBox.Show( "编辑数据失败" );
                                }
                                else
                                {
                                    MessageBox.Show( "成功编辑数据" );

                                    if (sav == "1")
                                    {
                                        row = del.Rows[num];
                                        row.BeginEdit( );
                                        row["DS02"] = DS2;
                                        row["DS18"] = DS018;
                                        row["DS03"] = DS3;
                                        row["DS04"] = DS4;
                                        row["DS17"] = DS017;
                                        row["DS05"] = DS5;
                                        row["DS06"] = DS6;
                                        row["DS07"] = DS7;
                                        row["DS08"] = DS8;
                                        row["DS15"] = DS015;
                                        row["DS16"] = DS016;
                                        row["DS09"] = DS9;
                                        row.EndEdit( );
                                    }
                                    else if (sav == "2")
                                    {
                                        row = de.Rows[num];
                                        row.BeginEdit( );
                                        row["DS02"] = DS2;
                                        row["DS18"] = DS018;
                                        row["DS03"] = DS3;
                                        row["DS04"] = DS4;
                                        row["DS17"] = DS017;
                                        row["DS05"] = DS5;
                                        row["DS06"] = DS6;
                                        row["DS07"] = DS7;
                                        row["DS08"] = DS8;
                                        row["DS15"] = DS015;
                                        row["DS16"] = DS016;
                                        row["DS09"] = DS9;
                                        row.EndEdit( );
                                    }

                                    DataTable biao = SqlHelper.ExecuteDataTable( "SELECT DS06,DS07,DS17 FROM R_PQR" );
                                    //实日产量
                                    DataTable sr = biao.DefaultView.ToTable( true, "DS06" );
                                    comboBox4.DataSource = sr;
                                    comboBox4.DisplayMember = "DS06";
                                    //计划单价
                                    DataTable jd = biao.DefaultView.ToTable( true, "DS07" );
                                    comboBox5.DataSource = jd;
                                    comboBox5.DisplayMember = "DS07";
                                    //本工序名称
                                    DataTable bgx = biao.DefaultView.ToTable( true, "DS17" );
                                    comboBox6.DataSource = bgx;
                                    comboBox6.DisplayMember = "DS17";
                                }
                            }
                            else
                            {
                                MessageBox.Show( "" + label2.Text + ":" + textBox18.Text + "\n\r" + label10.Text + ":" + comboBox1.Text + "\n\r" + label9.Text + ":" + comboBox2.Text + "\n\r" + label23.Text + ":" + comboBox6.Text + "\n\r的数据已经存在,请核实后再编辑" );
                            }
                        }
                    }
                }
            }
        }
        #endregion  
    }
}

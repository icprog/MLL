using Mulaolao.Class;
using Mulaolao.Other;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StudentMgr;

namespace Mulaolao.Bom
{
    public partial class R_FrmProductBom : Form
    {
        public R_FrmProductBom(Form1 fm)
        {
            this.MdiParent = fm;
            InitializeComponent( );

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { this . gridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        DataTable da;
        private void ProductBom_Load( object sender, EventArgs e )
        {
            textBox9.Enabled = false;
            textBox38.Enabled = false;
            dateTimePicker12.Enabled = false;
            textBox27.Enabled = false;
            textBox28.Enabled = false;
            //label19.Visible = label18.Visible = label50.Visible = false;

            da = SqlHelper.ExecuteDataTable( "SELECT PQF01,PQF02,PQF03,PQF04,PQF05,PQF06,PQF07,PQF08,PQF09,PQF10,DFA003,DBA002,PQF13,PQF14,PQF15,PQF16,DAA002,PQF19,PQF20,PQF21,PQF22,PQF23, PQF24, PQF25, PQF26, PQF27, PQF28, PQF29, PQF30, PQF31, PQF32, PQF33, PQF34, PQF35, PQF36, PQF37, PQF38, PQF39, PQF40, PQF41, PQF42, PQF43, PQF44, PQF45, PQF46,PQF47, PQF48, PQF49, PQF50, PQF51,PQF53,PQF54 FROM R_PQF A, TPADFA B, TPADBA C, TPADAA D WHERE A.PQF11 = B.DFA001 AND A.PQF12 = C.DBA001 AND A.PQF17 = D.DAA001 ORDER BY PQF01" );
            gridControl1.DataSource = da;

            DataTable de = SqlHelper.ExecuteDataTable( "SELECT DFA001,DFA002 FROM TPADFA" );
            comboBox1.DataSource = de;
            comboBox1.DisplayMember = "DFA002";
            comboBox1.ValueMember = "DFA001";

            DataTable dl = SqlHelper.ExecuteDataTable( "SELECT  DBA001,DBA002 FROM TPADBA WHERE DBA012='业务员'" );
            comboBox2.DataSource = dl;
            comboBox2.DisplayMember = "DBA002";
            comboBox2.ValueMember = "DBA001";

            DataTable db = SqlHelper.ExecuteDataTable( "SELECT DAA001,DAA002 FROM TPADAA" );
            comboBox3.DataSource = db;
            comboBox3.DisplayMember = "DAA002";
            comboBox3.ValueMember = "DAA001";
        }

        #region 事件
        private void textBox5_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox27_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox27 );
        }
        private void textBox27_LostFocus( object sender, EventArgs e )
        {
            if (textBox27.Text!=""&&!DateDayRegise.eightFiveNumber( textBox27 ))
            {
                this.textBox27.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多五位,如999.99999,请重新输入" );
            }
        }
        private void textBox28_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox28 );
        }
        private void textBox28_LostFocus( object sender, EventArgs e )
        {
            if (textBox28.Text!=""&&!DateDayRegise.eightFiveNumber( textBox28 ))
            {
                this.textBox28.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多五位,如999.99999,请重新输入" );
            }
        }
        private void textBox7_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox15_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox23_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox23 );
        }
        private void textBox23_LostFocus( object sender, EventArgs e )
        {
            if (textBox23.Text!=""&&!DateDayRegise.sixTwoNumber( textBox23 ))
            {
                this.textBox23.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多一位,如9999.99,请重新输入" );
            }
        }
        private void textBox23_TextChanged( object sender, EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox23 );
        }
        private void textBox24_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox24 );
        }
        private void textBox24_LostFocus( object sender, EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox24 );
        }
        private void textBox24_TextChanged( object sender, EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox24 );
        }
        private void textBox25_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox25 );
        }
        private void textBox25_LostFocus( object sender, EventArgs e )
        {
            if (textBox25.Text!=""&&!DateDayRegise.sixTwoNumber( textBox25 ))
            {
                this.textBox25.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多一位,如9999.99,请重新输入" );
            }
        }
        private void textBox25_TextChanged( object sender, EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox25 );
        }
        private void textBox9_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox9 );
        }
        private void textBox9_LostFocus( object sender, EventArgs e )
        {
            if (textBox9.Text!=""&&!DateDayRegise.tenTwoNumber( textBox9 ))
            {
                this.textBox9.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多一位,如99999999.99,请重新输入" );
            }
        }
        private void textBox9_TextChanged( object sender, EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox9 );
        }
        private void textBox38_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox38 );
        }
        private void textBox38_LostFocus( object sender, EventArgs e )
        {
            if (textBox38.Text!=""&&!DateDayRegise.tenTwoNumber( textBox38 ))
            {
                this.textBox38.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多一位,如99999999.99,请重新输入" );
            }
        }
        private void textBox38_TextChanged( object sender, EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox38 );
        }
        private void textBox10_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox11_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox8_LostFocus( object sender, EventArgs e )
        {
            if (textBox8.Text!=""&&!DateDayRegise.fiveThreeNumtb( textBox8 ))
            {
                this.textBox8.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多一位,如99.999,请重新输入" );
            }
        }
        private void textBox8_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox8 );
        }
        private void textBox8_TextChanged( object sender, EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox8 );
        }
        private void textBox21_LostFocus( object sender, EventArgs e )
        {
            if (textBox21.Text!=""&&!DateDayRegise.fiveThreeNumtb( textBox21 ))
            {
                this.textBox21.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多一位,如99.999,请重新输入" );
            }
        }
        private void textBox21_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox21 );
        }
        private void textBox13_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox13 );
        }
        private void textBox13_LostFocus( object sender, EventArgs e )
        {
            if (textBox13.Text!=""&&!DateDayRegise.fiveThreeNumtb( textBox13 ))
            {
                this.textBox13.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多一位,如99.999,请重新输入" );
            }
        }
        private void textBox13_TextChanged( object sender, EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox13 );
        }
        private void textBox19_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox19 );
        }
        private void textBox19_LostFocus( object sender, EventArgs e )
        {
            if (textBox19.Text!=""&&!DateDayRegise.fiveThreeNumtb( textBox19 ))
            {
                this.textBox19.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多一位,如99.999,请重新输入" );
            }
        }
        private void textBox19_TextChanged( object sender, EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox19 );
        }
        private void textBox31_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox31 );
        }
        private void textBox31_LostFocus( object sender, EventArgs e )
        {
            if (textBox31.Text!=""&&!DateDayRegise.tenTwoNumber( textBox31 ))
            {
                this.textBox31.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多一位,如99999999.99,请重新输入" );
            }
        }
        private void textBox31_TextChanged( object sender, EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox31 );
        }
        private void textBox40_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox40 );
        }
        private void textBox40_LostFocus( object sender, EventArgs e )
        {
            if (textBox40.Text!=""&&!DateDayRegise.tenTwoNumber( textBox40 ))
            {
                this.textBox40.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多一位,如99999999.99,请重新输入" );
            }
        }
        private void textBox40_TextChanged( object sender, EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox40 );
        }
        double a, b, c, d;
        private void textBox28_TextChanged( object sender, EventArgs e )
        {
            if (textBox28.Text.Substring( 0 ) == ".")
            {
                this.textBox28.Text = "0.";
                textBox28.SelectionStart = 2;
            }
            if (radioButton8.Checked)
            {
                a = double.Parse( textBox28.Text );
                //int.TryParse( textBox28.Text, out a );
                textBox27.Text = (a * b).ToString( );
            }   
        }
        private void textBox21_TextChanged( object sender, EventArgs e )
        {
            if (textBox21.Text.Substring( 0 ) == ".")
            {
                textBox21.Text = "0.";
                textBox21.SelectionStart = 2;
            }
            if (radioButton8.Checked)
            {
                if (textBox21.Text == "")
                {
                    textBox27.Text = "";
                }
                else
                {
                    b = double.Parse( textBox21.Text );
                    //int.TryParse( textBox21.Text, out b );
                    textBox27.Text = (a * b).ToString( );
                }
            }
            else if (radioButton7.Checked)
            {
                if (textBox21.Text != "")
                {
                    c = double.Parse( textBox21.Text );
                    //int.TryParse( textBox21.Text, out c );
                    if (c != 0)
                    {
                        textBox28.Text = (d / c).ToString( "000.00000" );
                    }
                }
                else if (textBox21.Text == "")
                {
                    textBox28.Text = "";
                }
            }

        }
        private void textBox27_TextChanged( object sender, EventArgs e )
        {
            if (textBox27.Text.Substring( 0 ) == ".")
            {
                this.textBox27.Text = "0.";
                textBox27.SelectionStart = 2;
            }
            if (radioButton7.Checked)
            {
                d = double.Parse( textBox27.Text );
                //int.TryParse( textBox27.Text, out d );
                textBox28.Text = (d / c).ToString( "000.00000" );
            }
        }
        string pqf1 = "";
        private void gridView1_FocusedRowChanged( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
            if (gridView1.RowCount < 1)
            {
                Ergodic.FormEvery( this );
            }
            else
            {
                textBox1.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF01" ).ToString( );
                pqf1 = textBox1.Text;
                textBox2.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF02" ).ToString( );
                textBox3.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF03" ).ToString( );
                textBox4.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF04" ).ToString( );
                textBox6.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF05" ).ToString( );
                textBox5.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF06" ).ToString( );
                textBox16.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF07" ).ToString( );
                textBox17.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF08" ).ToString( );                
                comboBox1.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "DFA003" ).ToString( );
                comboBox2.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "DBA002" ).ToString( );
                if (gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF13" ).ToString( ) != "")
                {
                    dateTimePicker1.Value = Convert.ToDateTime( gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF13" ).ToString( ) );
                }
                if (gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF14" ).ToString( ) != "")
                {
                    dateTimePicker10.Value = Convert.ToDateTime( gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF14" ).ToString( ) );
                }
                textBox7.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF15" ).ToString( );
                textBox15.Text= gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF16" ).ToString( );
                comboBox3.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "DAA002" ).ToString( );
                comboBox4.Text= gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF19" ).ToString( );
                textBox34.Text= gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF20" ).ToString( );
                textBox35.Text= gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF21" ).ToString( );
                textBox39.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF22" ).ToString( );
                if (gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF23" ).ToString( ) == "是")
                {
                    radioButton3.Checked = true;
                }
                else if (gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF23" ).ToString( ) == "否")
                {
                    radioButton4.Checked = true;
                }
                if (gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF24" ).ToString( ) == "是")
                {
                    radioButton6.Checked = true;
                }
                else if (gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF24" ).ToString( ) == "否")
                {
                    radioButton5.Checked = true;
                }
                textBox18.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF25" ).ToString( );
                textBox23.Text= gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF26" ).ToString( );
                textBox24.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF27" ).ToString( );
                textBox25.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF28" ).ToString( );
                if (gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF30" ).ToString( ) != "")
                {
                    dateTimePicker2.Value = Convert.ToDateTime( gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF30" ).ToString( ) );
                }
                if (gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF31" ).ToString( ) != "")
                {
                    dateTimePicker4.Value = Convert.ToDateTime( gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF31" ).ToString( ) );
                }
                if (gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF32" ).ToString( ) != "")
                {
                    dateTimePicker3.Value = Convert.ToDateTime( gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF32" ).ToString( ) );
                }
                if (gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF33" ).ToString( ) != "")
                {
                    dateTimePicker5.Value = Convert.ToDateTime( gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF33" ).ToString( ) );
                }
                if (gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF34" ).ToString( ) != "")
                {
                    dateTimePicker7.Value = Convert.ToDateTime( gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF34" ).ToString( ) );
                }
                if (gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF35" ).ToString( ) != "")
                {
                    dateTimePicker8.Value = Convert.ToDateTime( gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF35" ).ToString( ) );
                }
                if (gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF36" ).ToString( ) != "")
                {
                    dateTimePicker9.Value = Convert.ToDateTime( gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF36" ).ToString( ) );
                }
                if (gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF37" ).ToString( ) != "")
                {
                    dateTimePicker6.Value = Convert.ToDateTime( gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF37" ).ToString( ) );
                }
                if (gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF41" ).ToString( ) == "人民币")
                {
                    radioButton7.Checked = true;
                    textBox27.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF09" ).ToString( );
                    textBox29.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF41" ).ToString( );
                    textBox9.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF38" ).ToString( );
                    if (gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF39" ).ToString( ) != "")
                    {
                        dateTimePicker12.Value = Convert.ToDateTime( gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF39" ).ToString( ) );
                    }
                    textBox38.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF40" ).ToString( );
                }
                else if (gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF41" ).ToString( ) == "美元")
                {
                    radioButton8.Checked = true;
                    textBox29.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF41" ).ToString( );
                    textBox28.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF10" ).ToString( );
                    textBox9.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF38" ).ToString( );
                    if (gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF39" ).ToString( ) != "")
                    {
                        dateTimePicker12.Value = Convert.ToDateTime( gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF39" ).ToString( ) );
                    }
                    textBox38.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF40" ).ToString( );
                }
                textBox10.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF42" ).ToString( );
                textBox11.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF54" ).ToString( );
                textBox12.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF44" ).ToString( );
                textBox8.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF43" ).ToString( );
                textBox33.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF47" ).ToString( );
                textBox21.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF45" ).ToString( );
                textBox40.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF48" ).ToString( );
                textBox13.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF53" ).ToString( );
                textBox31.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF49" ).ToString( );
                textBox19.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF46" ).ToString( );
                textBox20.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF50" ).ToString( );
                textBox14.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQF51" ).ToString( );
            }
        }
        private void gridView1_Click( object sender, EventArgs e )
        {
            if (gridView1.RowCount == 1)
            {
                textBox1.Text = gridView1.GetFocusedRowCellValue( "PQF01" ).ToString( );
                textBox2.Text = gridView1.GetFocusedRowCellValue( "PQF02" ).ToString( );
                textBox3.Text = gridView1.GetFocusedRowCellValue( "PQF03" ).ToString( );
                textBox4.Text = gridView1.GetFocusedRowCellValue( "PQF04" ).ToString( );
                textBox6.Text = gridView1.GetFocusedRowCellValue( "PQF05" ).ToString( );
                textBox5.Text = gridView1.GetFocusedRowCellValue( "PQF06" ).ToString( );
                textBox16.Text = gridView1.GetFocusedRowCellValue( "PQF07" ).ToString( );
                textBox17.Text = gridView1.GetFocusedRowCellValue( "PQF08" ).ToString( );              
                comboBox1.Text = gridView1.GetFocusedRowCellValue( "DFA003" ).ToString( );
                comboBox2.Text = gridView1.GetFocusedRowCellValue( "DBA002" ).ToString( );
                if (gridView1.GetFocusedRowCellValue( "PQF13" ).ToString( ) != "")
                {
                    dateTimePicker1.Value = Convert.ToDateTime( gridView1.GetFocusedRowCellValue( "PQF13" ).ToString( ) );
                }
                if (gridView1.GetFocusedRowCellValue( "PQF14" ).ToString( ) != "")
                {
                    dateTimePicker10.Value = Convert.ToDateTime( gridView1.GetFocusedRowCellValue( "PQF14" ).ToString( ) );
                }
                textBox7.Text = gridView1.GetFocusedRowCellValue( "PQF15" ).ToString( );
                textBox15.Text = gridView1.GetFocusedRowCellValue( "PQF16" ).ToString( );
                comboBox3.Text = gridView1.GetFocusedRowCellValue( "DAA002" ).ToString( );
                comboBox4.Text = gridView1.GetFocusedRowCellValue( "PQF19" ).ToString( );
                textBox34.Text = gridView1.GetFocusedRowCellValue( "PQF20" ).ToString( );
                textBox35.Text = gridView1.GetFocusedRowCellValue( "PQF21" ).ToString( );
                textBox39.Text = gridView1.GetFocusedRowCellValue( "PQF22" ).ToString( );
                if (gridView1.GetFocusedRowCellValue( "PQF23" ).ToString( ) == "是")
                {
                    radioButton3.Checked = true;
                }
                else if (gridView1.GetFocusedRowCellValue( "PQF23" ).ToString( ) == "否")
                {
                    radioButton4.Checked = true;
                }
                if (gridView1.GetFocusedRowCellValue( "PQF24" ).ToString( ) == "是")
                {
                    radioButton6.Checked = true;
                }
                else if (gridView1.GetFocusedRowCellValue( "PQF24" ).ToString( ) == "否")
                {
                    radioButton5.Checked = true;
                }
                textBox18.Text = gridView1.GetFocusedRowCellValue( "PQF25" ).ToString( );
                textBox23.Text = gridView1.GetFocusedRowCellValue( "PQF26" ).ToString( );
                textBox24.Text = gridView1.GetFocusedRowCellValue( "PQF27" ).ToString( );
                textBox25.Text = gridView1.GetFocusedRowCellValue( "PQF28" ).ToString( );
                if (gridView1.GetFocusedRowCellValue( "PQF30" ).ToString( ) != "")
                {
                    dateTimePicker2.Value = Convert.ToDateTime( gridView1.GetFocusedRowCellValue( "PQF30" ).ToString( ) );
                }
                if (gridView1.GetFocusedRowCellValue( "PQF30" ).ToString( ) != "")
                {
                    dateTimePicker4.Value = Convert.ToDateTime( gridView1.GetFocusedRowCellValue( "PQF31" ).ToString( ) );
                }
                if (gridView1.GetFocusedRowCellValue( "PQF32" ).ToString( ) != "")
                {
                    dateTimePicker3.Value = Convert.ToDateTime( gridView1.GetFocusedRowCellValue( "PQF32" ).ToString( ) );
                }
                if (gridView1.GetFocusedRowCellValue( "PQF33" ).ToString( ) != "")
                {
                    dateTimePicker5.Value = Convert.ToDateTime( gridView1.GetFocusedRowCellValue( "PQF33" ).ToString( ) );
                }
                if (gridView1.GetFocusedRowCellValue( "PQF34" ).ToString( ) != "")
                {
                    dateTimePicker7.Value = Convert.ToDateTime( gridView1.GetFocusedRowCellValue( "PQF34" ).ToString( ) );
                }
                if (gridView1.GetFocusedRowCellValue( "PQF35" ).ToString( ) != "")
                {
                    dateTimePicker8.Value = Convert.ToDateTime( gridView1.GetFocusedRowCellValue( "PQF35" ).ToString( ) );
                }
                if (gridView1.GetFocusedRowCellValue( "PQF36" ).ToString( ) != "")
                {
                    dateTimePicker9.Value = Convert.ToDateTime( gridView1.GetFocusedRowCellValue( "PQF36" ).ToString( ) );
                }
                if (gridView1.GetFocusedRowCellValue( "PQF37" ).ToString( ) != "")
                {
                    dateTimePicker6.Value = Convert.ToDateTime( gridView1.GetFocusedRowCellValue( "PQF37" ).ToString( ) );
                }
                if (gridView1.GetFocusedRowCellValue( "PQF41" ).ToString( ) == "人民币")
                {
                    radioButton7.Checked = true;
                    textBox27.Text = gridView1.GetFocusedRowCellValue( "PQF09" ).ToString( );
                    textBox29.Text = gridView1.GetFocusedRowCellValue( "PQF41" ).ToString( );
                    textBox9.Text = gridView1.GetFocusedRowCellValue( "PQF38" ).ToString( );
                    if (gridView1.GetFocusedRowCellValue( "PQF39" ).ToString( ) != "")
                    {
                        dateTimePicker12.Value = Convert.ToDateTime( gridView1.GetFocusedRowCellValue( "PQF39" ).ToString( ) );
                    }
                    textBox38.Text = gridView1.GetFocusedRowCellValue( "PQF40" ).ToString( );
                }
                else if (gridView1.GetFocusedRowCellValue( "PQF41" ).ToString( ) == "美元")
                {
                    radioButton8.Checked = true;
                    textBox28.Text = gridView1.GetFocusedRowCellValue( "PQF10" ).ToString( );
                    textBox29.Text = gridView1.GetFocusedRowCellValue( "PQF41" ).ToString( );
                    textBox9.Text = gridView1.GetFocusedRowCellValue( "PQF38" ).ToString( );
                    if (gridView1.GetFocusedRowCellValue( "PQF39" ).ToString( ) != "")
                    {
                        dateTimePicker12.Value = Convert.ToDateTime( gridView1.GetFocusedRowCellValue( "PQF39" ).ToString( ) );
                    }
                    textBox38.Text = gridView1.GetFocusedRowCellValue( "PQF40" ).ToString( );
                }
                textBox10.Text = gridView1.GetFocusedRowCellValue( "PQF42" ).ToString( );
                textBox11.Text = gridView1.GetFocusedRowCellValue( "PQF54" ).ToString( );
                textBox12.Text = gridView1.GetFocusedRowCellValue( "PQF44" ).ToString( );
                textBox8.Text = gridView1.GetFocusedRowCellValue( "PQF43" ).ToString( );
                textBox33.Text = gridView1.GetFocusedRowCellValue( "PQF47" ).ToString( );
                textBox21.Text = gridView1.GetFocusedRowCellValue( "PQF45" ).ToString( );
                textBox40.Text = gridView1.GetFocusedRowCellValue( "PQF48" ).ToString( );
                textBox13.Text = gridView1.GetFocusedRowCellValue( "PQF53" ).ToString( );
                textBox31.Text = gridView1.GetFocusedRowCellValue( "PQF49" ).ToString( );
                textBox19.Text = gridView1.GetFocusedRowCellValue( "PQF46" ).ToString( );
                textBox20.Text = gridView1.GetFocusedRowCellValue( "PQF50" ).ToString( );
                textBox14.Text = gridView1.GetFocusedRowCellValue( "PQF51" ).ToString( );
            }
        }
        private void textBox1_TextChanged( object sender, EventArgs e )
        {
            DataTable ddl = SqlHelper.ExecuteDataTable( "SELECT PQF29 FROM R_PQF WHERE PQF01=@PQF01", new SqlParameter( "@PQF01", textBox1.Text ) );
            if (ddl.Rows.Count > 0)
            {
                if (((byte[])ddl.Rows[0]["PQF29"]).Length == 0)
                {
                    pictureBox1.Image = null;
                }
                else
                {
                    byte[] mybyte = (byte[])ddl.Rows[0]["PQF29"];
                    MemoryStream ms = new MemoryStream( mybyte );
                    ms.Write( mybyte, 0, mybyte.Length );
                    ms.Position = 0;
                    ms.Seek( 0, SeekOrigin.Begin );
                    Image img = Image.FromStream( ms, true );
                    pictureBox1.Image = img;
                }
            }

            DataTable ddr = SqlHelper.ExecuteDataTable( "SELECT PQF01,(SELECT RES05 FROM R_REVIEWS WHERE RES04=(SELECT MAX(RES04) FROM R_REVIEWS WHERE RES06=PQF01)) RES05 FROM R_PQF WHERE PQF01=@PQF01" ,new SqlParameter( "@PQF01" ,textBox1.Text ) );
            if ( ddr.Rows.Count < 1 )
            {
                label19.Visible = label18.Visible = label50.Visible = false;
            }
            else
            {
                if ( ddr.Rows[0]["PQF01"].ToString( ) == "执行" )
                {
                    label18.Visible = true;
                    label19.Visible = label50.Visible = false;
                }
                else if ( ddr.Rows[0]["PQF01"].ToString( ) == "驳回" )
                {
                    label19.Visible = true;
                    label18.Visible = label50.Visible = false;
                }
                else if ( ddr.Rows[0]["PQF01"].ToString( ) == "送审" )
                {
                    label50.Visible = true;
                    label18.Visible = label19.Visible = false;
                }
            }
        }
        private void radioButton7_CheckedChanged( object sender, EventArgs e )
        {
            textBox9.Enabled = true;
            textBox38.Enabled = true;
            dateTimePicker12.Enabled = true;
            textBox27.Enabled = true;
            textBox28.Enabled = false;
            textBox29.Text = radioButton7.Text;
        }
        private void radioButton8_CheckedChanged( object sender, EventArgs e )
        {
            textBox9.Enabled = true;
            textBox38.Enabled = true;
            dateTimePicker12.Enabled = true;
            textBox27.Enabled = false;
            textBox28.Enabled = true;
            textBox29.Text = radioButton8.Text;
    }
        long ar, br;
        private void gridView1_CustomColumnDisplayText( object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e )
        {
            ar = Convert.ToInt64( dateTimePicker4.Value.ToString( "yyyyMMdd" ) );
            br = Convert.ToInt64( dateTimePicker8.Value.ToString( "yyyyMMdd" ) );
            U1.UnboundExpression = (ar - br).ToString( );
            U1.UnboundType = DevExpress.Data.UnboundColumnType.Integer;

            ar = Convert.ToInt64( dateTimePicker7.Value.ToString( "yyyyMMdd" ) );
            br = Convert.ToInt64( dateTimePicker9.Value.ToString( "yyyyMMdd" ) );
            U6.UnboundExpression = (ar - br).ToString( );
            U6.UnboundType = DevExpress.Data.UnboundColumnType.Integer;

            ar = Convert.ToInt64( dateTimePicker8.Value.ToString( "yyyyMMdd" ) );
            br = Convert.ToInt64( dateTimePicker6.Value.ToString( "yyyyMMdd" ) );
            U5.UnboundExpression = (ar - br).ToString( );
            U5.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
        }
        #endregion

        #region
        string filepath = "";
        //打开
        private void button4_Click( object sender, EventArgs e )
        {
            OpenFileDialog opd = new OpenFileDialog( );
            opd.Filter = "*jpg|*.JPG|*.GIF|*BMP";
            if (opd.ShowDialog( ) == DialogResult.OK)
            {
                filepath = opd.FileName;
                pictureBox1.ImageLocation = filepath;

                FileStream fs = new FileStream( filepath, FileMode.Open, FileAccess.Read );
                BinaryReader bs = new BinaryReader( fs );
                PQF029 = bs.ReadBytes( (int)fs.Length );
            }
        }       
        //放大
        R_FrmImageAmplication ima = new R_FrmImageAmplication( );//另一个窗体,用做放大的图片显示,上面有一个picturebox控件
        private void button5_Click( object sender, EventArgs e )
        {
            if (pictureBox1.ImageLocation == "")
            {
                MessageBox.Show( "没有图片,无法放大" );
            }
            else
            {
                ima.pictureBox1.Image = pictureBox1.Image;
                ima.ShowDialog( );
            }
        }
        //删除
        private void button6_Click( object sender, EventArgs e )
        {
            pictureBox1.Image = null;
        }
        #endregion

        #region
        string PQF1 = "", PQF2 = "", PQF3 = "", PQF4 = "", PQF5 = "", PQF7 = "", PQF8 = "", PQF011 = "", PQF012 = "", PQF017 = "",  PQF019 = "", PQF020 = "", PQF021 = "", PQF022 = "", PQF023 = "", PQF024 = "", PQF025 = "", PQF041 = "", PQF044 = "", PQF047 = "", PQF051 = "";
        long PQF6 = 0, PQF015 = 0, PQF016 = 0, PQF042 = 0, PQF054 = 0;
        decimal PQF9 = 0M, PQF010 = 0M, PQF026 = 0M, PQF027 = 0M, PQF028 = 0M, PQF038 = 0M, PQF040 = 0M, PQF043 = 0M, PQF045 = 0M, PQF046 = 0M, PQF048 = 0M, PQF049 = 0M, PQF053 = 0M;
        DateTime PQF013 = MulaolaoBll . Drity . GetDt ( ), PQF014 = MulaolaoBll . Drity . GetDt ( ), PQF030 = MulaolaoBll . Drity . GetDt ( ), PQF031 = MulaolaoBll . Drity . GetDt ( ), PQF032 = MulaolaoBll . Drity . GetDt ( ), PQF033 = MulaolaoBll . Drity . GetDt ( ), PQF034 = MulaolaoBll . Drity . GetDt ( ), PQF035 = MulaolaoBll . Drity . GetDt ( ), PQF036 = MulaolaoBll . Drity . GetDt ( ), PQF037 = MulaolaoBll . Drity . GetDt ( ), PQF039 = MulaolaoBll . Drity . GetDt ( );
        int  PQF050 = 0;
        byte[] PQF029 = new byte[0];
        //新建
        private void add ( )
        {
            #region           
            PQF2 = textBox2.Text;
            PQF3 = textBox3.Text;
            PQF4 = textBox4.Text;
            PQF5 = textBox6.Text;
            if ( textBox5.Text != "" )
            {
                PQF6 = Convert.ToInt64( textBox5.Text );
            }
            PQF7 = textBox16.Text;
            PQF8 = textBox17.Text;
            if ( textBox8.Text != "" )
            {
                PQF045 = Convert.ToDecimal( textBox8.Text );
            }
            if ( textBox28.Text != "" )
            {
                PQF010 = Convert.ToDecimal( textBox28.Text );
            }
            if ( textBox27.Text != "" )
            {
                PQF9 = Convert.ToDecimal( textBox27.Text );
            }
            PQF011 = comboBox1.SelectedValue.ToString( );
            PQF012 = comboBox2.SelectedValue.ToString( );
            PQF013 = dateTimePicker1.Value;
            PQF014 = dateTimePicker10.Value;
            if ( textBox7.Text == "" )
            {
                PQF015 = 0;
            }
            else
            {
                PQF015 = Convert.ToInt64( textBox7.Text );
            }
            if ( textBox15.Text == "" )
            {
                PQF016 = 0;
            }
            else
            {
                PQF016 = Convert.ToInt64( textBox15.Text );
            }
            PQF017 = comboBox3.SelectedValue.ToString( );
            PQF019 = comboBox4.Text;
            PQF020 = textBox34.Text;
            PQF021 = textBox35.Text;
            PQF022 = textBox39.Text;
            if ( radioButton3.Checked )
            {
                PQF023 = radioButton3.Text;
            }
            else if ( radioButton4.Checked )
            {
                PQF023 = radioButton4.Text;
            }
            else
            {
                PQF023 = "";
            }
            if ( radioButton5.Checked )
            {
                PQF024 = radioButton5.Text;
            }
            else if ( radioButton6.Checked )
            {
                PQF024 = radioButton6.Text;
            }
            else
            {
                PQF024 = "";
            }
            PQF025 = textBox18.Text;
            if ( textBox23.Text == "" )
            {
                PQF026 = 0M;
            }
            else
            {
                PQF026 = Convert.ToDecimal( textBox23.Text );
            }
            if ( textBox24.Text == "" )
            {
                PQF027 = 0M;
            }
            else
            {
                PQF027 = Convert.ToDecimal( textBox24.Text );
            }
            if ( textBox25.Text == "" )
            {
                PQF028 = 0M;
            }
            else
            {
                PQF028 = Convert.ToDecimal( textBox25.Text );
            }
            PQF030 = dateTimePicker2.Value;
            PQF031 = dateTimePicker4.Value;
            PQF032 = dateTimePicker3.Value;
            PQF033 = dateTimePicker5.Value;
            PQF034 = dateTimePicker7.Value;
            PQF035 = dateTimePicker8.Value;
            PQF036 = dateTimePicker9.Value;
            PQF037 = dateTimePicker6.Value;
            if ( textBox10.Text == "" )
            {
                PQF042 = 0;
            }
            else
            {
                PQF042 = Convert.ToInt64( textBox10.Text );
            }
            if ( textBox8.Text != "" )
            {
                PQF043 = Convert.ToDecimal( textBox8.Text );
            }
            PQF044 = textBox12.Text;
            if ( textBox21.Text != "" )
            {
                PQF045 = Convert.ToDecimal( textBox21.Text );
            }
            if ( textBox19.Text != "" )
            {
                PQF046 = Convert.ToDecimal( textBox19.Text );
            }
            PQF047 = textBox33.Text;
            if ( textBox40.Text != "" )
            {
                PQF048 = Convert.ToDecimal( textBox40.Text );
            }
            if ( textBox31.Text != "" )
            {
                PQF049 = Convert.ToDecimal( textBox31.Text );
            }
            if ( textBox20.Text != "" )
            {
                PQF050 = Convert.ToInt32( textBox20.Text );
            }
            PQF051 = textBox14.Text;
            if ( radioButton7.Checked )
            {
                PQF041 = radioButton7.Text;
            }
            else if ( radioButton8.Checked )
            {
                PQF041 = radioButton8.Text;
            }
            if ( textBox13.Text != "" )
            {
                PQF053 = Convert.ToDecimal( textBox13.Text );
            }
            if ( textBox11.Text != "" )
            {
                PQF054 = Convert.ToInt64( textBox11.Text );
            }
            #endregion
        }
        private void over ( )
        {
            DataRow row = da.NewRow( );
            row["PQF01"] = PQF1;
            row["PQF02"] = PQF2;
            row["PQF03"] = PQF3;
            row["PQF04"] = PQF4;
            row["PQF05"] = PQF5;
            row["PQF06"] = PQF6;
            row["PQF07"] = PQF7;
            row["PQF08"] = PQF8;
            row["PQF09"] = PQF9;
            row["PQF10"] = PQF010;
            row["DFA003"] = comboBox1.Text;
            row["DBA002"] = comboBox2.Text;
            row["PQF13"] = PQF013;
            row["PQF14"] = PQF014;
            row["PQF15"] = PQF015;
            row["PQF16"] = PQF016;
            row["DAA002"] = comboBox3.Text;
            row["PQF19"] = PQF019;
            row["PQF20"] = PQF020;
            row["PQF21"] = PQF021;
            row["PQF22"] = PQF022;
            row["PQF23"] = PQF023;
            row["PQF24"] = PQF024;
            row["PQF25"] = PQF025;
            row["PQF26"] = PQF026;
            row["PQF27"] = PQF027;
            row["PQF28"] = PQF028;
            row["PQF29"] = PQF029;
            row["PQF30"] = PQF030;
            row["PQF31"] = PQF031;
            row["PQF32"] = PQF032;
            row["PQF33"] = PQF033;
            row["PQF34"] = PQF034;
            row["PQF35"] = PQF035;
            row["PQF36"] = PQF036;
            row["PQF37"] = PQF037;
            row["PQF38"] = PQF038;
            row["PQF39"] = PQF039;
            row["PQF40"] = PQF040;
            row["PQF41"] = PQF041;
            row["PQF42"] = PQF042;
            row["PQF43"] = PQF043;
            row["PQF44"] = PQF044;
            row["PQF45"] = PQF045;
            row["PQF46"] = PQF046;
            row["PQF47"] = PQF047;
            row["PQF48"] = PQF048;
            row["PQF49"] = PQF049;
            row["PQF50"] = PQF050;
            row["PQF51"] = PQF051;
            row["PQF53"] = PQF053;
            row["PQF54"] = PQF054;
            da.Rows.Add( row );
        }
        private void button1_Click( object sender, EventArgs e )
        {
            label19.Visible = label18.Visible = label50.Visible = false;

            add( );
            DataTable dal = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQF" );
            if (dal.Rows.Count < 1)
            {
                PQF1 = MulaolaoBll . Drity . GetDt ( ).ToString( "yyyy" ).Substring( 2, 2 ) + MulaolaoBll . Drity . GetDt ( ).ToString( "MM" ) + "0001";
                textBox1.Text = PQF1;
                int count = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQF (PQF01,PQF02,PQF03,PQF04,PQF05,PQF06,PQF07,PQF08,PQF09, PQF10, PQF11, PQF12, PQF13, PQF14, PQF15, PQF16,PQF17, PQF19, PQF20, PQF21, PQF22, PQF23, PQF24, PQF25,PQF26, PQF27, PQF28, PQF29, PQF30, PQF31, PQF32, PQF33,PQF34, PQF35, PQF36, PQF37, PQF38, PQF39, PQF40, PQF41,PQF42, PQF43, PQF44, PQF45, PQF46, PQF47, PQF48, PQF49,PQF50, PQF51, PQF53,PQF54) VALUES (@PQF01,@PQF02,@PQF03,@PQF04,@PQF05,@PQF06,@PQF07,@PQF08,@PQF09, @PQF10, @PQF11, @PQF12, @PQF13, @PQF14, @PQF15, @PQF16,@PQF17, @PQF19, @PQF20, @PQF21, @PQF22, @PQF23, @PQF24, @PQF25,@PQF26, @PQF27, @PQF28, @PQF29, @PQF30, @PQF31, @PQF32, @PQF33,@PQF34, @PQF35, @PQF36, @PQF37, @PQF38, @PQF39, @PQF40, @PQF41,@PQF42, @PQF43, @PQF44, @PQF45, @PQF46, @PQF47, @PQF48, @PQF49,@PQF50, @PQF51, @PQF53,@PQF54)", new SqlParameter( "@PQF01", PQF1 ), new SqlParameter( "@PQF02", PQF2 ), new SqlParameter( "@PQF03", PQF3 ), new SqlParameter( "@PQF04", PQF4 ), new SqlParameter( "@PQF05", PQF5 ), new SqlParameter( "@PQF06", PQF6 ), new SqlParameter( "@PQF07", PQF7 ), new SqlParameter( "@PQF08", PQF8 ), new SqlParameter( "@PQF09", PQF9 ), new SqlParameter( "@PQF10", PQF010 ), new SqlParameter( "@PQF11", PQF011 ), new SqlParameter( "@PQF12", PQF012 ), new SqlParameter( "@PQF13", PQF013 ), new SqlParameter( "@PQF14", PQF014 ), new SqlParameter( "@PQF15", PQF015 ), new SqlParameter( "@PQF16", PQF016 ), new SqlParameter( "@PQF17", PQF017 ), new SqlParameter( "@PQF19", PQF019 ), new SqlParameter( "@PQF20", PQF020 ), new SqlParameter( "@PQF21", PQF021 ), new SqlParameter( "@PQF22", PQF022 ), new SqlParameter( "@PQF23", PQF023 ), new SqlParameter( "@PQF24", PQF024 ), new SqlParameter( "@PQF25", PQF025 ), new SqlParameter( "@PQF26", PQF026 ), new SqlParameter( "@PQF27", PQF027 ), new SqlParameter( "@PQF28", PQF028 ), new SqlParameter( "@PQF29", PQF029 ), new SqlParameter( "@PQF30", PQF030 ), new SqlParameter( "@PQF31", PQF031 ), new SqlParameter( "@PQF32", PQF032 ), new SqlParameter( "@PQF33", PQF033 ), new SqlParameter( "@PQF34", PQF034 ), new SqlParameter( "@PQF35", PQF035 ), new SqlParameter( "@PQF36", PQF036 ), new SqlParameter( "@PQF37", PQF037 ), new SqlParameter( "@PQF38", PQF038 ), new SqlParameter( "@PQF39", PQF039 ), new SqlParameter( "@PQF40", PQF040 ), new SqlParameter( "@PQF41", PQF041 ), new SqlParameter( "@PQF42", PQF042 ), new SqlParameter( "@PQF43", PQF043 ), new SqlParameter( "@PQF44", PQF044 ), new SqlParameter( "@PQF45", PQF045 ), new SqlParameter( "@PQF46", PQF046 ), new SqlParameter( "@PQF47", PQF047 ), new SqlParameter( "@PQF48", PQF048 ), new SqlParameter( "@PQF49", PQF049 ), new SqlParameter( "@PQF50", PQF050 ), new SqlParameter( "@PQF51", PQF051 ), new SqlParameter( "@PQF53", PQF053 ), new SqlParameter( "@PQF54", PQF054 ) );
                if (count < 1)
                {
                    MessageBox.Show( "录入数据失败" );
                }
                else
                {                 
                    MessageBox.Show( "成功录入数据" );

                    over( );
                }
            }
            else
            {
                DataTable del = SqlHelper.ExecuteDataTable( "SELECT PQF01 FROM R_PQF WHERE idx=(SELECT MAX(idx) FROM R_PQF)" );
                if (del.Rows.Count > 0)
                {
                    if (del.Rows[0]["PQF01"].ToString( ).Substring( 0, 2 ) == MulaolaoBll . Drity . GetDt ( ).ToString( "yyyy" ).Substring( 2, 2 ) && del.Rows[0]["PQF01"].ToString( ).Substring( 2, 2 ) == MulaolaoBll . Drity . GetDt ( ).ToString( "MM" ))
                    {
                        PQF1 = (Convert.ToInt64( del.Rows[0]["PQF01"] ) + 1).ToString( );
                        textBox1.Text = PQF1;
                    }
                    else
                    {
                        PQF1 = MulaolaoBll . Drity . GetDt ( ).ToString( "yyyy" ).Substring( 2, 2 ) + MulaolaoBll . Drity . GetDt ( ).ToString( "MM" ) + "0001";
                        textBox1.Text = PQF1;
                    }
                    int count = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQF (PQF01,PQF02,PQF03,PQF04,PQF05,PQF06,PQF07,PQF08,PQF09, PQF10, PQF11, PQF12, PQF13, PQF14, PQF15, PQF16,PQF17, PQF19, PQF20, PQF21, PQF22, PQF23, PQF24, PQF25,PQF26, PQF27, PQF28, PQF29, PQF30, PQF31, PQF32, PQF33,PQF34, PQF35, PQF36, PQF37, PQF38, PQF39, PQF40, PQF41,PQF42, PQF43, PQF44, PQF45, PQF46, PQF47, PQF48, PQF49,PQF50, PQF51, PQF54, PQF53) VALUES (@PQF01,@PQF02,@PQF03,@PQF04,@PQF05,@PQF06,@PQF07,@PQF08,@PQF09, @PQF10, @PQF11, @PQF12, @PQF13, @PQF14, @PQF15, @PQF16,@PQF17, @PQF19, @PQF20, @PQF21, @PQF22, @PQF23, @PQF24, @PQF25,@PQF26, @PQF27, @PQF28, @PQF29, @PQF30, @PQF31, @PQF32, @PQF33,@PQF34, @PQF35, @PQF36, @PQF37, @PQF38, @PQF39, @PQF40, @PQF41,@PQF42, @PQF43, @PQF44, @PQF45, @PQF46, @PQF47, @PQF48, @PQF49,@PQF50, @PQF51, @PQF54, @PQF53)", new SqlParameter( "@PQF01", PQF1 ), new SqlParameter( "@PQF02", PQF2 ), new SqlParameter( "@PQF03", PQF3 ), new SqlParameter( "@PQF04", PQF4 ), new SqlParameter( "@PQF05", PQF5 ), new SqlParameter( "@PQF06", PQF6 ), new SqlParameter( "@PQF07", PQF7 ), new SqlParameter( "@PQF08", PQF8 ), new SqlParameter( "@PQF09", PQF9 ), new SqlParameter( "@PQF10", PQF010 ), new SqlParameter( "@PQF11", PQF011 ), new SqlParameter( "@PQF12", PQF012 ), new SqlParameter( "@PQF13", PQF013 ), new SqlParameter( "@PQF14", PQF014 ), new SqlParameter( "@PQF15", PQF015 ), new SqlParameter( "@PQF16", PQF016 ), new SqlParameter( "@PQF17", PQF017 ), new SqlParameter( "@PQF19", PQF019 ), new SqlParameter( "@PQF20", PQF020 ), new SqlParameter( "@PQF21", PQF021 ), new SqlParameter( "@PQF22", PQF022 ), new SqlParameter( "@PQF23", PQF023 ), new SqlParameter( "@PQF24", PQF024 ), new SqlParameter( "@PQF25", PQF025 ), new SqlParameter( "@PQF26", PQF026 ), new SqlParameter( "@PQF27", PQF027 ), new SqlParameter( "@PQF28", PQF028 ), new SqlParameter( "@PQF29", PQF029 ), new SqlParameter( "@PQF30", PQF030 ), new SqlParameter( "@PQF31", PQF031 ), new SqlParameter( "@PQF32", PQF032 ), new SqlParameter( "@PQF33", PQF033 ), new SqlParameter( "@PQF34", PQF034 ), new SqlParameter( "@PQF35", PQF035 ), new SqlParameter( "@PQF36", PQF036 ), new SqlParameter( "@PQF37", PQF037 ), new SqlParameter( "@PQF38", PQF038 ), new SqlParameter( "@PQF39", PQF039 ), new SqlParameter( "@PQF40", PQF040 ), new SqlParameter( "@PQF41", PQF041 ), new SqlParameter( "@PQF42", PQF042 ), new SqlParameter( "@PQF43", PQF043 ), new SqlParameter( "@PQF44", PQF044 ), new SqlParameter( "@PQF45", PQF045 ), new SqlParameter( "@PQF46", PQF046 ), new SqlParameter( "@PQF47", PQF047 ), new SqlParameter( "@PQF48", PQF048 ), new SqlParameter( "@PQF49", PQF049 ), new SqlParameter( "@PQF50", PQF050 ), new SqlParameter( "@PQF51", PQF051 ), new SqlParameter( "@PQF54", PQF054 ), new SqlParameter( "@PQF53", PQF053 ) );
                    if (count < 1)
                    {
                        MessageBox.Show( "录入数据失败" );
                    }
                    else
                    {                      
                        MessageBox.Show( "成功录入数据" );

                        over( );
                    }
                }
            }
        }
        //编辑
        private void button2_Click( object sender, EventArgs e )
        {
            add( );

            DataTable del = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQF" );
            if (del.Rows.Count < 1)
            {
                MessageBox.Show( "没有数据,无法编辑" );
            }
            else
            {
                int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQF SET PQF02=@PQF02,PQF03=@PQF03,PQF04=@PQF04,PQF05=@PQF05,PQF06=@PQF06,PQF07=@PQF07,PQF08=@PQF08,PQF09=@PQF09, PQF10=@PQF10, PQF11=@PQF11, PQF12=@PQF12, PQF13=@PQF13, PQF14=@PQF14, PQF15=@PQF15, PQF16=@PQF16,PQF17=@PQF17, PQF19=@PQF19, PQF20=@PQF20, PQF21=@PQF21, PQF22=@PQF22, PQF23=@PQF23, PQF24=@PQF24, PQF25=@PQF25,PQF26=@PQF26, PQF27=@PQF27, PQF28=@PQF28, PQF29=@PQF29, PQF30=@PQF30, PQF31=@PQF31, PQF32=@PQF32, PQF33=@PQF33,PQF34=@PQF34, PQF35=@PQF35, PQF36=@PQF36, PQF37=@PQF37, PQF38=@PQF38, PQF39=@PQF39, PQF40=@PQF40, PQF41=@PQF41,PQF42=@PQF42, PQF43=@PQF43, PQF44=@PQF44, PQF45=@PQF45, PQF46=@PQF46, PQF47=@PQF47, PQF48=@PQF48, PQF49=@PQF49,PQF50=@PQF50, PQF51=@PQF51, PQF54=@PQF54, PQF53=@PQF53 WHERE PQF01=@PQF01", new SqlParameter( "@PQF01",pqf1 ), new SqlParameter( "@PQF02", PQF2 ), new SqlParameter( "@PQF03", PQF3 ), new SqlParameter( "@PQF04", PQF4 ), new SqlParameter( "@PQF05", PQF5 ), new SqlParameter( "@PQF06", PQF6 ), new SqlParameter( "@PQF07", PQF7 ), new SqlParameter( "@PQF08", PQF8 ), new SqlParameter( "@PQF09", PQF9 ), new SqlParameter( "@PQF10", PQF010 ), new SqlParameter( "@PQF11", PQF011 ), new SqlParameter( "@PQF12", PQF012 ), new SqlParameter( "@PQF13", PQF013 ), new SqlParameter( "@PQF14", PQF014 ), new SqlParameter( "@PQF15", PQF015 ), new SqlParameter( "@PQF16", PQF016 ), new SqlParameter( "@PQF17", PQF017 ), new SqlParameter( "@PQF19", PQF019 ), new SqlParameter( "@PQF20", PQF020 ), new SqlParameter( "@PQF21", PQF021 ), new SqlParameter( "@PQF22", PQF022 ), new SqlParameter( "@PQF23", PQF023 ), new SqlParameter( "@PQF24", PQF024 ), new SqlParameter( "@PQF25", PQF025 ), new SqlParameter( "@PQF26", PQF026 ), new SqlParameter( "@PQF27", PQF027 ), new SqlParameter( "@PQF28", PQF028 ), new SqlParameter( "@PQF29", PQF029 ), new SqlParameter( "@PQF30", PQF030 ), new SqlParameter( "@PQF31", PQF031 ), new SqlParameter( "@PQF32", PQF032 ), new SqlParameter( "@PQF33", PQF033 ), new SqlParameter( "@PQF34", PQF034 ), new SqlParameter( "@PQF35", PQF035 ), new SqlParameter( "@PQF36", PQF036 ), new SqlParameter( "@PQF37", PQF037 ), new SqlParameter( "@PQF38", PQF038 ), new SqlParameter( "@PQF39", PQF039 ), new SqlParameter( "@PQF40", PQF040 ), new SqlParameter( "@PQF41", PQF041 ), new SqlParameter( "@PQF42", PQF042 ), new SqlParameter( "@PQF43", PQF043 ), new SqlParameter( "@PQF44", PQF044 ), new SqlParameter( "@PQF45", PQF045 ), new SqlParameter( "@PQF46", PQF046 ), new SqlParameter( "@PQF47", PQF047 ), new SqlParameter( "@PQF48", PQF048 ), new SqlParameter( "@PQF49", PQF049 ), new SqlParameter( "@PQF50", PQF050 ), new SqlParameter( "@PQF51", PQF051 ), new SqlParameter( "@PQF54", PQF054 ), new SqlParameter( "@PQF53", PQF053 ) );
                if (count < 1)
                {
                    MessageBox.Show( "编辑数据失败" );
                }
                else
                {
                    int num = gridView1.FocusedRowHandle;
                    DataRow row = da.Rows[num];
                    row.BeginEdit( );
                    row["PQF01"] = pqf1;
                    row["PQF02"] = PQF2;
                    row["PQF03"] = PQF3;
                    row["PQF04"] = PQF4;
                    row["PQF05"] = PQF5;
                    row["PQF06"] = PQF6;
                    row["PQF07"] = PQF7;
                    row["PQF08"] = PQF8;
                    row["PQF09"] = PQF9;
                    row["PQF10"] = PQF010;
                    row["DFA003"] = comboBox1.Text;
                    row["DBA002"] = comboBox2.Text;
                    row["PQF13"] = PQF013;
                    row["PQF14"] = PQF014;
                    row["PQF15"] = PQF015;
                    row["PQF16"] = PQF016;
                    row["DAA002"] = comboBox3.Text;
                    row["PQF19"] = PQF019;
                    row["PQF20"] = PQF020;
                    row["PQF21"] = PQF021;
                    row["PQF22"] = PQF022;
                    row["PQF23"] = PQF023;
                    row["PQF24"] = PQF024;
                    row["PQF25"] = PQF025;
                    row["PQF26"] = PQF026;
                    row["PQF27"] = PQF027;
                    row["PQF28"] = PQF028;
                    row["PQF29"] = PQF029;
                    row["PQF30"] = PQF030;
                    row["PQF31"] = PQF031;
                    row["PQF32"] = PQF032;
                    row["PQF33"] = PQF033;
                    row["PQF34"] = PQF034;
                    row["PQF35"] = PQF035;
                    row["PQF36"] = PQF036;
                    row["PQF37"] = PQF037;
                    row["PQF38"] = PQF038;
                    row["PQF39"] = PQF039;
                    row["PQF40"] = PQF040;
                    row["PQF41"] = PQF041;
                    row["PQF42"] = PQF042;
                    row["PQF43"] = PQF043;
                    row["PQF44"] = PQF044;
                    row["PQF45"] = PQF045;
                    row["PQF46"] = PQF046;
                    row["PQF47"] = PQF047;
                    row["PQF48"] = PQF048;
                    row["PQF49"] = PQF049;
                    row["PQF50"] = PQF050;
                    row["PQF51"] = PQF051;
                    row["PQF54"] = PQF054;
                    row["PQF53"] = PQF053;
                    row.EndEdit( );
                    MessageBox.Show( "编辑数据成功" );
                }
            }
        }
        //删除
        private void button3_Click( object sender, EventArgs e )
        {
            DataTable dtl = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQF" );
            if (dtl.Rows.Count < 1)
            {
                MessageBox.Show( "没有数据,无法删除" );
            }
            else
            {
                int count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQF WHERE PQF01=@PQF01",new SqlParameter("@PQF01",pqf1) );
                if (count < 1)
                {
                    MessageBox.Show( "数据删除失败" );
                }
                else
                {                  
                    MessageBox.Show( "成功删除数据" );
                    int num = gridView1.FocusedRowHandle;
                    da.Rows.RemoveAt( num );
                }
            }
        }
        #endregion

        #region
        //列宽设置
        private void ColumnSet()
        {

        }
        #endregion
    }
}

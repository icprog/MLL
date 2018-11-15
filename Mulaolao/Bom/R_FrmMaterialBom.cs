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

namespace Mulaolao.Bom
{
    public partial class R_FrmMaterialBom : Form
    {
        public R_FrmMaterialBom(Form1 fm )
        {
            this.MdiParent = fm;
            InitializeComponent( );

            //GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { this . gridView1 ,this . gridView2  } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        DataTable de;
        private void R_FrmMaterialBom_Load( object sender, EventArgs e )
        {
            de = SqlHelper.ExecuteDataTable( "SELECT DGA003,DGA009,DGA011,PQH03,PQH04,PQH05,PQH06,PQH07,PQH08,PQH09,PQH10,PQH12,PQH13,PQH14 FROM R_PQH A,TPADGA B WHERE A.PQH11=B.DGA001" );
            gridControl2.DataSource = de;

            DataTable dx = SqlHelper.ExecuteDataTable( "SELECT DISTINCT PQH12 FROM R_PQH" );
            comboBox3.DataSource = dx;
            comboBox3.DisplayMember = "PQH12";

            DataTable df = SqlHelper.ExecuteDataTable( "SELECT DISTINCT PQH04 FROM R_PQH" );
            comboBox8.DataSource = df;
            comboBox8.DisplayMember = "PQH04";

            DataTable dt = SqlHelper.ExecuteDataTable( "SELECT DISTINCT PQH05 FROM R_PQH" );
            comboBox9.DataSource = dt;
            comboBox9.DisplayMember = "PQH05";
        }
        //供应商资料
        R_FrmTPADGA tpadga = new R_FrmTPADGA( );
        private void button7_Click( object sender, EventArgs e )
        {
            DataTable da = SqlHelper.ExecuteDataTable( "SELECT DGA001,DGA003,DGA009,DGA011 FROM TPADGA ORDER BY DGA001" );
            if (da.Rows.Count < 0)
            {
                MessageBox.Show( "没有供应商信息" );
            }
            else
            {
                tpadga.st = "1";
                tpadga.gridControl2.DataSource = da;
                tpadga.PassDataBetweenForm += new R_FrmTPADGA.PassDataBetweenFomrHandler( tpadga_PassDataBetweenForm );
                tpadga.StartPosition = FormStartPosition.CenterScreen;
                tpadga.ShowDialog( );
            }
        }
        string tpanum = "";
        private void tpadga_PassDataBetweenForm( object sender, PassDataWinFormEventArgs e )
        {
            tpanum = e.ConOne;
            textBox15.Text = e.ConTwo;
            textBox14.Text = e.ConTre;
            textBox13.Text = e.ConFor;
        }

        #region 事件
        //定义字段显示内容
        private void gridView2_CustomColumnDisplayText( object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e )
        {
            U0.UnboundExpression = (Convert.ToDecimal( comboBox5.Text ) / 100 * Convert.ToDecimal( comboBox6.Text ) / 100 * Convert.ToDecimal( comboBox8.Text )).ToString( );
            U0.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;

            PQH14.UnboundExpression = comboBox5.Text + "*" + comboBox6.Text + "*" + comboBox7.Text;
            PQH14.UnboundType = DevExpress.Data.UnboundColumnType.String;
        }
        //供应商规格(长)
        private void comboBox5_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
                MessageBox.Show( "只允许输入整数" );
            }
        }
        //供应商规格(宽)
        private void comboBox6_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
                MessageBox.Show( "只允许输入整数" );
            }
        }
        //供应商规格(高)
        private void comboBox7_KeyPress( object sender, KeyPressEventArgs e )
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
                if (comboBox7.Text.LastIndexOf( '.' ) != -1)
                {
                    e.Handled = true;
                    MessageBox.Show( "只能输入一个小数点" );
                }
            }
        }
        private void comboBox7_LostFocus( object sender, EventArgs e )
        {
            if (comboBox7.Text != "" && !DateDayRegise.twoOneNum( comboBox7 ))
            {
                this.comboBox7.Text = "";
                MessageBox.Show( "只允许输入整数部分最多一位,小数部分最多一位,如9.9,请重新输入" );
            }
        }
        //板厚度mm
        private void comboBox8_KeyPress( object sender, KeyPressEventArgs e )
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
                if (comboBox8.Text.LastIndexOf( '.' ) != -1)
                {
                    e.Handled = true;
                    MessageBox.Show( "只能输入一个小数点" );
                }
            }
        }
        private void comboBox8_LostFocus( object sender, EventArgs e )
        {
            if (comboBox8.Text != "" && !DateDayRegise.foreThreeNum( comboBox8 ))
            {
                this.comboBox8.Text = "";
                MessageBox.Show( "只允许输入整数部分最多一位,小数部分最多三位,如9.999,请重新输入" );
            }
        }
        //E0级原价/张
        private void comboBox11_KeyPress( object sender, KeyPressEventArgs e )
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
                if (comboBox11.Text.LastIndexOf( '.' ) != -1)
                {
                    e.Handled = true;
                    MessageBox.Show( "只能输入一个小数点" );
                }
            }
        }
        private void comboBox11_LostFocus( object sender, EventArgs e )
        {
            if (comboBox11.Text != "" && !DateDayRegise.foreTwoNum( comboBox11 ))
            {
                this.comboBox11.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多两位,如99.99,请重新输入" );
            }
        }
        //E0级议价/张
        private void comboBox12_KeyPress( object sender, KeyPressEventArgs e )
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
                if (comboBox12.Text.LastIndexOf( '.' ) != -1)
                {
                    e.Handled = true;
                    MessageBox.Show( "只能输入一个小数点" );
                }
            }
        }
        private void comboBox12_LostFocus( object sender, EventArgs e )
        {
            if (comboBox12.Text != "" && !DateDayRegise.foreTwoNum( comboBox12 ))
            {
                this.comboBox12.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多两位,如99.99,请重新输入" );
            }
        }
        //E1级原价/张
        private void comboBox14_KeyPress( object sender, KeyPressEventArgs e )
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
                if (comboBox14.Text.LastIndexOf( '.' ) != -1)
                {
                    e.Handled = true;
                    MessageBox.Show( "只能输入一个小数点" );
                }
            }
        }
        private void comboBox14_LostFocus( object sender, EventArgs e )
        {
            if (comboBox14.Text != "" && !DateDayRegise.foreTwoNum( comboBox14 ))
            {
                this.comboBox14.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多两位,如99.99,请重新输入" );
            }
        }
        //E1级现价/张
        private void comboBox13_KeyPress( object sender, KeyPressEventArgs e )
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
                if (comboBox13.Text.LastIndexOf( '.' ) != -1)
                {
                    e.Handled = true;
                    MessageBox.Show( "只能输入一个小数点" );
                }
            }
        }
        private void comboBox13_LostFocus( object sender, EventArgs e )
        {
            if (comboBox13.Text != "" && !DateDayRegise.foreTwoNum( comboBox13 ))
            {
                this.comboBox13.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多两位,如99.99,请重新输入" );
            }
        }
        //层数
        private void comboBox15_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
                MessageBox.Show( "只允许输入整数" );
            }
        }
        string pq12 = "", pq13 = "", pq14 = "", pq3 = "", pq4 = "", pq5 = "", pq6 = "", pq7 = "", pq8 = "", pq9 = "", pq10 = "", pq11 = "";
        //材料名称
        private void comboBox4_TextChanged( object sender, EventArgs e )
        {
                  
        }
        //材料类别
        private void comboBox3_TextChanged( object sender, EventArgs e )
        {
            DataTable dg = SqlHelper.ExecuteDataTable( "SELECT DISTINCT PQH13 FROM R_PQH WHERE PQH12=@PQH12", new SqlParameter( "@PQH12", comboBox3.Text ) );
            if (dg.Rows.Count > 0)
            {
                comboBox4.DataSource = dg;
                comboBox4.DisplayMember = "PQH13";
            }

            comboBox5.Items.Clear( );
            comboBox6.Items.Clear( );
            comboBox7.Items.Clear( );
            DataTable da = SqlHelper.ExecuteDataTable( "SELECT DISTINCT PQH14 FROM R_PQH WHERE PQH12=@PQH12", new SqlParameter( "@PQH12", comboBox3.Text ) );
            if (da.Rows.Count > 0)
            {
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    string[] str = da.Rows[i]["PQH14"].ToString( ).Split( '*' );
                    comboBox5.Items.Add( str[0] );
                    comboBox6.Items.Add( str[1] );
                    comboBox7.Items.Add( str[2] );
                }
            }

            DataTable ds = SqlHelper.ExecuteDataTable( "SELECT DISTINCT PQH07 FROM R_PQH WHERE PQH12=@PQH12", new SqlParameter( "@PQH12", comboBox3.Text ) );
            comboBox11.DataSource = ds;
            comboBox11.DisplayMember = "PQH07";

            DataTable dr = SqlHelper.ExecuteDataTable( "SELECT DISTINCT PQH08 FROM R_PQH WHERE PQH12=@PQH12", new SqlParameter( "@PQH12", comboBox3.Text ) );
            comboBox12.DataSource = dr;
            comboBox12.DisplayMember = "PQH08";

            DataTable dq = SqlHelper.ExecuteDataTable( "SELECT DISTINCT PQH09 FROM R_PQH WHERE PQH12=@PQH12", new SqlParameter( "@PQH12", comboBox3.Text ) );
            comboBox14.DataSource = dq;
            comboBox14.DisplayMember = "PQH09";

            DataTable dz = SqlHelper.ExecuteDataTable( "SELECT DISTINCT PQH10 FROM R_PQH WHERE PQH12=@PQH12", new SqlParameter( "@PQH12", comboBox3.Text ) );
            comboBox13.DataSource = dz;
            comboBox13.DisplayMember = "PQH10";

            DataTable dn = SqlHelper.ExecuteDataTable( "SELECT DISTINCT PQH03 FROM R_PQH WHERE PQH12=@PQH12", new SqlParameter( "@PQH12", comboBox3.Text ) );
            comboBox15.DataSource = dn;
            comboBox15.DisplayMember = "PQH03";

            DataTable dm = SqlHelper.ExecuteDataTable( "SELECT DISTINCT PQH06 FROM R_PQH WHERE PQH12=@PQH12", new SqlParameter( "@PQH12", comboBox3.Text ) );
            comboBox10.DataSource = dm;
            comboBox10.DisplayMember = "PQH06";
        }
        //市场价
        private void comboBox10_KeyPress( object sender, KeyPressEventArgs e )
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
                if (comboBox10.Text.LastIndexOf( '.' ) != -1)
                {
                    e.Handled = true;
                    MessageBox.Show( "只能输入一个小数点" );
                }
            }
        }
        private void comboBox10_LostFocus( object sender, EventArgs e )
        {
            if (comboBox10.Text != "" && !DateDayRegise.foreTwoNum( comboBox10 ))
            {
                this.comboBox10.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多两位,如99.99,请重新输入" );
            }
        }
        private void gridView2_FocusedRowChanged( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
            if (gridView2.RowCount < 1)
            {
                Ergodic.GroupboxEvery( groupBox4 );
            }
            else
            {
                textBox15.Text = gridView2.GetRowCellValue( e.FocusedRowHandle, "DGA003" ).ToString( );
                textBox14.Text = gridView2.GetRowCellValue( e.FocusedRowHandle, "DGA009" ).ToString( );
                textBox13.Text = gridView2.GetRowCellValue( e.FocusedRowHandle, "DGA011" ).ToString( );
                comboBox3.Text = gridView2.GetRowCellValue( e.FocusedRowHandle, "PQH12" ).ToString( );
                comboBox4.Text = gridView2.GetRowCellValue( e.FocusedRowHandle, "PQH13" ).ToString( );
                if (gridView2.GetRowCellValue( e.FocusedRowHandle, "PQH14" ).ToString( ) != "")
                {
                    string[] str = gridView2.GetRowCellValue( e.FocusedRowHandle, "PQH14" ).ToString( ).Split( '*' );
                    comboBox5.Text = str[0];
                    comboBox6.Text = str[1];
                    comboBox7.Text = str[2];
                }
                else
                {
                    comboBox5.Text = "";
                    comboBox6.Text = "";
                    comboBox7.Text = "";
                }
                comboBox15.Text= gridView2.GetRowCellValue( e.FocusedRowHandle, "PQH03" ).ToString( );
                comboBox8.Text = gridView2.GetRowCellValue( e.FocusedRowHandle, "PQH04" ).ToString( );
                comboBox9.Text = gridView2.GetRowCellValue( e.FocusedRowHandle, "PQH05" ).ToString( );
                comboBox10.Text = gridView2.GetRowCellValue( e.FocusedRowHandle, "PQH06" ).ToString( );
                comboBox11.Text = gridView2.GetRowCellValue( e.FocusedRowHandle, "PQH07" ).ToString( );
                comboBox12.Text = gridView2.GetRowCellValue( e.FocusedRowHandle, "PQH08" ).ToString( );
                comboBox14.Text = gridView2.GetRowCellValue( e.FocusedRowHandle, "PQH09" ).ToString( );
                comboBox13.Text = gridView2.GetRowCellValue( e.FocusedRowHandle, "PQH10" ).ToString( );
                pq12= gridView2.GetRowCellValue( e.FocusedRowHandle, "PQH12" ).ToString( );
                pq13= gridView2.GetRowCellValue( e.FocusedRowHandle, "PQH13" ).ToString( );
                pq14 = gridView2.GetRowCellValue( e.FocusedRowHandle, "PQH14" ).ToString( );
                pq3= gridView2.GetRowCellValue( e.FocusedRowHandle, "PQH03" ).ToString( );
                pq4 = gridView2.GetRowCellValue( e.FocusedRowHandle, "PQH04" ).ToString( );
                pq5 = gridView2.GetRowCellValue( e.FocusedRowHandle, "PQH05" ).ToString( );
                pq6 = gridView2.GetRowCellValue( e.FocusedRowHandle, "PQH06" ).ToString( );
                pq7 = gridView2.GetRowCellValue( e.FocusedRowHandle, "PQH07" ).ToString( );
                pq8 = gridView2.GetRowCellValue( e.FocusedRowHandle, "PQH08" ).ToString( );
                pq9 = gridView2.GetRowCellValue( e.FocusedRowHandle, "PQH09" ).ToString( );
                pq10 = gridView2.GetRowCellValue( e.FocusedRowHandle, "PQH10" ).ToString( );

                DataTable dl = SqlHelper.ExecuteDataTable( "SELECT DGA001 FROM TPADGA WHERE DGA003=@DGA003 AND DGA009=@DGA009 AND DGA011=@DGA011", new SqlParameter( "@DGA003", textBox15.Text ), new SqlParameter( "@DGA009", textBox14.Text ), new SqlParameter( "@DGA011", textBox13.Text ) );
                if (dl.Rows.Count < 1)
                {
                    pq11 = "";
                }
                else
                {
                    pq11 = dl.Rows[0]["DGA001"].ToString( );
                }
            }
        }
        private void gridView2_Click( object sender, EventArgs e )
        {
            if (gridView2.RowCount == 1)
            {
                textBox15.Text = gridView2.GetFocusedRowCellValue( "DGA003" ).ToString( );
                textBox14.Text = gridView2.GetFocusedRowCellValue(  "DGA009" ).ToString( );
                textBox13.Text = gridView2.GetFocusedRowCellValue(  "DGA011" ).ToString( );
                comboBox3.Text = gridView2.GetFocusedRowCellValue(  "PQH12" ).ToString( );
                comboBox4.Text = gridView2.GetFocusedRowCellValue(  "PQH13" ).ToString( );
                if (gridView2.GetFocusedRowCellValue( "PQH14" ).ToString( ) != "")
                {
                    string[] str = gridView2.GetFocusedRowCellValue( "PQH14" ).ToString( ).Split( '*' );
                    comboBox5.Text = str[0];
                    comboBox6.Text = str[1];
                    comboBox7.Text = str[2];
                }
                else
                {
                    comboBox5.Text = "";
                    comboBox6.Text = "";
                    comboBox7.Text = "";
                }
                comboBox15.Text = gridView2.GetFocusedRowCellValue(  "PQH03" ).ToString( );
                comboBox8.Text = gridView2.GetFocusedRowCellValue( "PQH04" ).ToString( );
                comboBox9.Text = gridView2.GetFocusedRowCellValue( "PQH05" ).ToString( );
                comboBox10.Text = gridView2.GetFocusedRowCellValue( "PQH06" ).ToString( );
                comboBox11.Text = gridView2.GetFocusedRowCellValue("PQH07" ).ToString( );
                comboBox12.Text = gridView2.GetFocusedRowCellValue("PQH08" ).ToString( );
                comboBox14.Text = gridView2.GetFocusedRowCellValue( "PQH09" ).ToString( );
                comboBox13.Text = gridView2.GetFocusedRowCellValue("PQH10" ).ToString( );
                pq12 = gridView2.GetFocusedRowCellValue( "PQH12" ).ToString( );
                pq13 = gridView2.GetFocusedRowCellValue(  "PQH13" ).ToString( );
                pq14 = gridView2.GetFocusedRowCellValue(  "PQH14" ).ToString( );
                pq3 = gridView2.GetFocusedRowCellValue( "PQH03" ).ToString( );
                pq4 = gridView2.GetFocusedRowCellValue(  "PQH04" ).ToString( );
                pq5 = gridView2.GetFocusedRowCellValue(  "PQH05" ).ToString( );
                pq6 = gridView2.GetFocusedRowCellValue( "PQH06" ).ToString( );
                pq7 = gridView2.GetFocusedRowCellValue( "PQH07" ).ToString( );
                pq8 = gridView2.GetFocusedRowCellValue( "PQH08" ).ToString( );
                pq9 = gridView2.GetFocusedRowCellValue(  "PQH09" ).ToString( );
                pq10 = gridView2.GetFocusedRowCellValue( "PQH10" ).ToString( );

                DataTable dl = SqlHelper.ExecuteDataTable( "SELECT DGA001 FROM TPADGA WHERE DGA003=@DGA003 AND DGA009=@DGA009 AND DGA011=@DGA011", new SqlParameter( "@DGA003", textBox15.Text ), new SqlParameter( "@DGA009", textBox14.Text ), new SqlParameter( "@DGA011", textBox13.Text ) );
                if (dl.Rows.Count < 1)
                {
                    pq11 = "";
                }
                else
                {
                    pq11 = dl.Rows[0]["DGA001"].ToString( );
                }
            }
        }
        #endregion

        #region
        string PQH011 = "", PQH012 = "", PQH013 = "", PQH014 = "", PQH5 = "";
        decimal PQH4 = 0M, PQH6 = 0M, PQH7 = 0M, PQH8 = 0M, PQH9 = 0M, PQH010 = 0M;
        int PQH3 = 0; 
        //新建
        private void button6_Click( object sender, EventArgs e )
        {
            PQH011 = tpanum;
            PQH012 = comboBox3.Text;
            PQH013 = comboBox4.Text;
            PQH014 = comboBox5.Text + "*" + comboBox6.Text + "*" + comboBox7.Text;
            if (comboBox15.Text != "")
            {
                PQH3 = Convert.ToInt32( comboBox15.Text );
            }
            if (comboBox8.Text != "")
            {
                PQH4 = Convert.ToDecimal( comboBox8.Text );
            }
            PQH5 = comboBox9.Text;
            if (comboBox10.Text != "")
            {
                PQH6 = Convert.ToDecimal( comboBox10.Text );
            }
            if (comboBox11.Text != "")
            {
                PQH7 = Convert.ToDecimal( comboBox11.Text );
            }
            if (comboBox12.Text != "")
            {
                PQH8 = Convert.ToDecimal( comboBox12.Text );
            }
            if (comboBox14.Text != "")
            {
                PQH9 = Convert.ToDecimal( comboBox14.Text );
            }
            if (comboBox13.Text != "")
            {
                PQH010 = Convert.ToDecimal( comboBox13.Text );
            }
            if (de.Rows.Count < 1)
            {
                int count = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQH (PQH03,PQH04,PQH05,PQH06,PQH07,PQH08,PQH09,PQH10,PQH11,PQH12,PQH13,PQH14) VALUES (@PQH03,@PQH04,@PQH05,@PQH06,@PQH07,@PQH08,@PQH09,@PQH10,@PQH11,@PQH12,@PQH13,@PQH14)", new SqlParameter( "@PQH03", PQH3 ), new SqlParameter( "@PQH04", PQH4 ), new SqlParameter( "@PQH05", PQH5 ), new SqlParameter( "@PQH06", PQH6 ), new SqlParameter( "@PQH07", PQH7 ), new SqlParameter( "@PQH08", PQH8 ), new SqlParameter( "@PQH09", PQH9 ), new SqlParameter( "@PQH10", PQH010 ), new SqlParameter( "@PQH11", PQH011 ), new SqlParameter( "@PQH12", PQH012 ), new SqlParameter( "@PQH13", PQH013 ), new SqlParameter( "@PQH14", PQH014 ) );
                if (count < 1)
                {
                    MessageBox.Show( "录入数据失败" );
                }
                else
                {
                    DataRow row = de.NewRow( );
                    row["DGA003"] = textBox15.Text;
                    row["DGA009"] = textBox14.Text;
                    row["DGA011"] = textBox13.Text;
                    row["PQH03"] = PQH3;
                    row["PQH04"] = PQH4;
                    row["PQH05"] = PQH5;
                    row["PQH06"] = PQH6;
                    row["PQH07"] = PQH7;
                    row["PQH08"] = PQH8;
                    row["PQH09"] = PQH9;
                    row["PQH10"] = PQH010;
                    row["PQH12"] = PQH012;
                    row["PQH13"] = PQH013;
                    row["PQH14"] = PQH014;
                    de.Rows.Add( row );
                    MessageBox.Show( "录入数据成功" );
                }
            }
            else
            {
                if (de.Select( "PQH03='" + PQH3 + "'" ).Length > 0 && de.Select( "PQH04='" + PQH4 + "'" ).Length > 0 && de.Select( "PQH05='" + PQH5 + "'" ).Length > 0 && de.Select( "PQH06='" + PQH6 + "'" ).Length > 0 && de.Select( "PQH07='" + PQH7 + "'" ).Length > 0 && de.Select( "PQH08='" + PQH8 + "'" ).Length > 0 && de.Select( "PQH09='" + PQH9 + "'" ).Length > 0 && de.Select( "PQH10='" + PQH010 + "'" ).Length > 0 && de.Select( "DGA003='" + textBox15.Text + "'" ).Length > 0 && de.Select( "PQH12='" + PQH012 + "'" ).Length > 0 && de.Select( "PQH13='" + PQH013 + "'" ).Length > 0 && de.Select( "PQH14='" + PQH014 + "'" ).Length > 0)
                {
                    MessageBox.Show( "已经存在 \n\r " + label18.Text + "：" + comboBox3.Text + " \n\r " + label21.Text + "：" + comboBox4.Text + " \n\r " + label17.Text + "：" + textBox15.Text + " \n\r " + label16.Text + "：" + textBox14.Text + " \n\r " + label15.Text + "：" + textBox13.Text + " \n\r 供应商规格：" + comboBox5.Text + "*" + comboBox6.Text + "*" + comboBox7.Text + " \n\r " + label19.Text + "：" + comboBox8.Text + " \n\r " + label14.Text + "：" + comboBox9.Text + " \n\r " + label13.Text + "：" + comboBox11.Text + " \n\r" + label25.Text + "：" + comboBox12.Text + " \n\r" + label12.Text + "：" + comboBox14.Text + " \n\r" + label11.Text + "：" + comboBox13.Text + " \n\r" + label24.Text + "：" + comboBox10.Text + " \n\r" + label26.Text + "：" + comboBox15.Text + " \n\r的数据,请核实后再重新录入" );
                }
                else
                {
                    int count = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQH VALUES (@PQH03,@PQH04,@PQH05,@PQH06,@PQH07,@PQH08,@PQH09,@PQH10,@PQH11,@PQH12,@PQH13,@PQH14)", new SqlParameter( "@PQH03", PQH3 ), new SqlParameter( "@PQH04", PQH4 ), new SqlParameter( "@PQH05", PQH5 ), new SqlParameter( "@PQH06", PQH6 ), new SqlParameter( "@PQH07", PQH7 ), new SqlParameter( "@PQH08", PQH8 ), new SqlParameter( "@PQH09", PQH9 ), new SqlParameter( "@PQH10", PQH010 ), new SqlParameter( "@PQH11", PQH011 ), new SqlParameter( "@PQH12", PQH012 ), new SqlParameter( "@PQH13", PQH013 ), new SqlParameter( "@PQH14", PQH014 ) );
                    if (count < 1)
                    {
                        MessageBox.Show( "录入数据失败" );
                    }
                    else
                    {
                        DataRow row = de.NewRow( );
                        row["DGA003"] = textBox15.Text;
                        row["DGA009"] = textBox14.Text;
                        row["DGA011"] = textBox13.Text;
                        row["PQH03"] = PQH3;
                        row["PQH04"] = PQH4;
                        row["PQH05"] = PQH5;
                        row["PQH06"] = PQH6;
                        row["PQH07"] = PQH7;
                        row["PQH08"] = PQH8;
                        row["PQH09"] = PQH9;
                        row["PQH10"] = PQH010;
                        row["PQH12"] = PQH012;
                        row["PQH13"] = PQH013;
                        row["PQH14"] = PQH014;
                        de.Rows.Add( row );
                        MessageBox.Show( "录入数据成功" );
                    }
                }
            }
        }
        //编辑
        private void button5_Click( object sender, EventArgs e )
        {
            if (de.Rows.Count < 0)
            {
                MessageBox.Show( "没有数据,无法编辑" );
            }
            else
            {
                PQH011 = tpanum;
                PQH012 = comboBox3.Text;
                PQH013 = comboBox4.Text;
                PQH014 = comboBox5.Text + "*" + comboBox6.Text + "*" + comboBox7.Text;
                if (comboBox15.Text != "")
                {
                    PQH3 = Convert.ToInt32( comboBox15.Text );
                }
                if (comboBox8.Text != "")
                {
                    PQH4 = Convert.ToDecimal( comboBox8.Text );
                }
                PQH5 = comboBox9.Text;
                if (comboBox10.Text != "")
                {
                    PQH6 = Convert.ToDecimal( comboBox10.Text );
                }
                if (comboBox11.Text != "")
                {
                    PQH7 = Convert.ToDecimal( comboBox11.Text );
                }
                if (comboBox12.Text != "")
                {
                    PQH8 = Convert.ToDecimal( comboBox12.Text );
                }
                if (comboBox14.Text != "")
                {
                    PQH9 = Convert.ToDecimal( comboBox14.Text );
                }
                if (comboBox13.Text != "")
                {
                    PQH010 = Convert.ToDecimal( comboBox13.Text );
                }
                if (de.Select( "PQH03='" + PQH3 + "'" ).Length > 0 && de.Select( "PQH04='" + PQH4 + "'" ).Length > 0 && de.Select( "PQH05='" + PQH5 + "'" ).Length > 0 && de.Select( "PQH06='" + PQH6 + "'" ).Length > 0 && de.Select( "PQH07='" + PQH7 + "'" ).Length > 0 && de.Select( "PQH08='" + PQH8 + "'" ).Length > 0 && de.Select( "PQH09='" + PQH9 + "'" ).Length > 0 && de.Select( "PQH10='" + PQH010 + "'" ).Length > 0 && de.Select( "DGA003='" + textBox15.Text + "'" ).Length > 0 && de.Select( "PQH12='" + PQH012 + "'" ).Length > 0 && de.Select( "PQH13='" + PQH013 + "'" ).Length > 0 && de.Select( "PQH14='" + PQH014 + "'" ).Length > 0)
                {
                    MessageBox.Show( "已经存在 \n\r " + label18.Text + "：" + comboBox3.Text + " \n\r " + label21.Text + "：" + comboBox4.Text + " \n\r " + label17.Text + "：" + textBox15.Text + " \n\r " + label16.Text + "：" + textBox14.Text + " \n\r " + label15.Text + "：" + textBox13.Text + " \n\r 供应商规格：" + comboBox5.Text + "*" + comboBox6.Text + "*" + comboBox7.Text + " \n\r " + label19.Text + "：" + comboBox8.Text + " \n\r " + label14.Text + "：" + comboBox9.Text + " \n\r " + label13.Text + "：" + comboBox11.Text + " \n\r" + label25.Text + "：" + comboBox12.Text + " \n\r" + label12.Text + "：" + comboBox14.Text + " \n\r" + label11.Text + "：" + comboBox13.Text + " \n\r" + label24.Text + "：" + comboBox10.Text + " \n\r" + label26.Text + "：" + comboBox15.Text + " \n\r 的数据,请核实后再编辑" );
                }
                else
                {
                    int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQH SET PQH03=@PQH03,PQH04=@PQH04,PQH05=@PQH05,PQH06=@PQH06,PQH07=@PQH07,PQH08=@PQH08,PQH09=@PQH09,PQH10=@PQH10,PQH11=@PQH11,PQH12=@PQH12,PQH13=@PQH13,PQH14=@PQH14 WHERE PQH03=@PQH3 AND PQH04=@PQH4 AND PQH05=@PQH5 AND PQH06=@PQH6 AND PQH07=@PQH7 AND PQH08=@PQH8 AND PQH09=@PQH9 AND PQH10=@PQH010 AND PQH11=@PQH011 AND PQH12=@PQH012 AND PQH13=@PQH013 AND PQH14=@PQH014", new SqlParameter( "@PQH03", PQH3 ), new SqlParameter( "@PQH04", PQH4 ), new SqlParameter( "@PQH05", PQH5 ), new SqlParameter( "@PQH06", PQH6 ), new SqlParameter( "@PQH07", PQH7 ), new SqlParameter( "@PQH08", PQH8 ), new SqlParameter( "@PQH09", PQH9 ), new SqlParameter( "@PQH10", PQH010 ), new SqlParameter( "@PQH11", PQH011 ), new SqlParameter( "@PQH12", PQH012 ), new SqlParameter( "@PQH13", PQH013 ), new SqlParameter( "@PQH14", PQH014 ), new SqlParameter( "@PQH3", pq3 ), new SqlParameter( "@PQH4", pq4 ), new SqlParameter( "@PQH5", pq5 ), new SqlParameter( "@PQH6", pq6 ), new SqlParameter( "@PQH7", pq7 ), new SqlParameter( "@PQH8", pq8 ), new SqlParameter( "@PQH9", pq9 ), new SqlParameter( "@PQH010", pq10 ), new SqlParameter( "@PQH011", pq11 ), new SqlParameter( "@PQH012", pq12 ), new SqlParameter( "@PQH013", pq13 ), new SqlParameter( "@PQH014", pq14 ) );
                    if (count < 1)
                    {
                        MessageBox.Show( "编辑数据失败" );
                    }
                    else
                    {
                        int num = gridView2.FocusedRowHandle;
                        DataRow row = de.Rows[num];
                        row.BeginEdit( );
                        row["DGA003"] = textBox15.Text;
                        row["DGA009"] = textBox14.Text;
                        row["DGA011"] = textBox13.Text;
                        row["PQH03"] = PQH3;
                        row["PQH04"] = PQH4;
                        row["PQH05"] = PQH5;
                        row["PQH06"] = PQH6;
                        row["PQH07"] = PQH7;
                        row["PQH08"] = PQH8;
                        row["PQH09"] = PQH9;
                        row["PQH10"] = PQH010;
                        row["PQH12"] = PQH012;
                        row["PQH13"] = PQH013;
                        row["PQH14"] = PQH014;
                        row.EndEdit( );
                        MessageBox.Show( "编辑数据成功" );
                    }
                }
            }
        }
        //删除
        private void button4_Click( object sender, EventArgs e )
        {
            if (de.Rows.Count < 0)
            {
                MessageBox.Show( "没有数据,无法删除" );
            }
            else
            {
                PQH011 = tpanum;
                PQH012 = comboBox3.Text;
                PQH013 = comboBox4.Text;
                PQH014 = comboBox5.Text + "*" + comboBox6.Text + "*" + comboBox7.Text;
                if (comboBox15.Text != "")
                {
                    PQH3 = Convert.ToInt32( comboBox15.Text );
                }
                if (comboBox8.Text != "")
                {
                    PQH4 = Convert.ToDecimal( comboBox8.Text );
                }
                PQH5 = comboBox9.Text;
                if (comboBox10.Text != "")
                {
                    PQH6 = Convert.ToDecimal( comboBox10.Text );
                }
                if (comboBox11.Text != "")
                {
                    PQH7 = Convert.ToDecimal( comboBox11.Text );
                }
                if (comboBox12.Text != "")
                {
                    PQH8 = Convert.ToDecimal( comboBox12.Text );
                }
                if (comboBox14.Text != "")
                {
                    PQH9 = Convert.ToDecimal( comboBox14.Text );
                }
                if (comboBox13.Text != "")
                {
                    PQH010 = Convert.ToDecimal( comboBox13.Text );
                }
                int count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQH WHERE PQH03=@PQH03 AND PQH04=@PQH04 AND PQH05=@PQH05 AND PQH06=@PQH06 AND PQH07=@PQH07 AND PQH08=@PQH08 AND PQH09=@PQH09 AND PQH10=@PQH10 AND PQH11=@PQH11 AND PQH12=@PQH12 AND PQH13=@PQH13 AND PQH14=@PQH14", new SqlParameter( "@PQH03", PQH3 ), new SqlParameter( "@PQH04", PQH4 ), new SqlParameter( "@PQH05", PQH5 ), new SqlParameter( "@PQH06", PQH6 ), new SqlParameter( "@PQH07", PQH7 ), new SqlParameter( "@PQH08", PQH8 ), new SqlParameter( "@PQH09", PQH9 ), new SqlParameter( "@PQH10", PQH010 ), new SqlParameter( "@PQH11", PQH011 ), new SqlParameter( "@PQH12", PQH012 ), new SqlParameter( "@PQH13", PQH013 ), new SqlParameter( "@PQH14", PQH014 ) );
                if (count < 1)
                {
                    MessageBox.Show( "删除数据失败" );
                }
                else
                {
                    int num = gridView2.FocusedRowHandle;
                    de.Rows.RemoveAt( num );
                    MessageBox.Show( "删除数据成功" );
                }
            }
        }
        #endregion
    }
}

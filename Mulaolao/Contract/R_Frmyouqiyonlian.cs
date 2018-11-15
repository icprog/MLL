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

namespace Mulaolao.Contract
{
    public partial class R_Frmyouqiyonlian : Form
    {
        public R_Frmyouqiyonlian( Form1 fm )
        {
            this.MdiParent = fm;
            InitializeComponent( );
        }
        private void textBox2_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 46) && e.KeyChar != 8 && e.KeyChar != 1 && e.KeyChar != 3 && e.KeyChar != 22)
            {
                e.Handled = true;
                MessageBox.Show( "请输入数字" );
            }
        }

        private void textBox3_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 46) && e.KeyChar != 8 && e.KeyChar != 1 && e.KeyChar != 3 && e.KeyChar != 22)
            {
                e.Handled = true;
                MessageBox.Show( "请输入数字" );
            }
        }

        private void textBox5_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 46) && e.KeyChar != 8 && e.KeyChar != 1 && e.KeyChar != 3 && e.KeyChar != 22)
            {
                e.Handled = true;
                MessageBox.Show( "请输入数字" );
            }
        }

        private void textBox7_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 46) && e.KeyChar != 8 && e.KeyChar != 1 && e.KeyChar != 3 && e.KeyChar != 22)
            {
                e.Handled = true;
                MessageBox.Show( "请输入数字" );
            }
        }

        private void textBox9_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 46) && e.KeyChar != 8 && e.KeyChar != 1 && e.KeyChar != 3 && e.KeyChar != 22)
            {
                e.Handled = true;
                MessageBox.Show( "请输入数字" );
            }
        }

        private void textBox11_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 46) && e.KeyChar != 8 && e.KeyChar != 1 && e.KeyChar != 3 && e.KeyChar != 22)
            {
                e.Handled = true;
                MessageBox.Show( "请输入数字" );
            }
        }

        private void textBox12_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 46) && e.KeyChar != 8 && e.KeyChar != 1 && e.KeyChar != 3 && e.KeyChar != 22)
            {
                e.Handled = true;
                MessageBox.Show( "请输入数字" );
            }
        }

        private void textBox13_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 46) && e.KeyChar != 8 && e.KeyChar != 1 && e.KeyChar != 3 && e.KeyChar != 22)
            {
                e.Handled = true;
                MessageBox.Show( "请输入数字" );
            }
        }

        private void textBox16_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 46) && e.KeyChar != 8 && e.KeyChar != 1 && e.KeyChar != 3 && e.KeyChar != 22)
            {
                e.Handled = true;
                MessageBox.Show( "请输入数字" );
            }
        }
        DataTable da;
        DataTable db;
        DataTable dc;
        DataTable dd;
        DataTable de;
        DataTable df;
        DataTable dg;
        DataTable dh;
        DataTable djj;
        private void R_Frmyouqiyonlian_Load( object sender, EventArgs e )
        {
            #region R_PQA 每板手喷单面.单遍色面、底漆用量、工资、单价
            da = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQA" );
            gridControl1.DataSource = da;

            DataTable b = da.DefaultView.ToTable( true, new string[] { "PQA02" } );
            for (int a = 0; a < b.Rows.Count; a++)
            {
                comboBox1.Items.Add( b.Rows[a]["PQA02"].ToString( ) );
            }
            DataTable c = da.DefaultView.ToTable( true, new string[] { "PQA03" } );
            for (int a = 0; a < c.Rows.Count; a++)
            {
                comboBox2.Items.Add( c.Rows[a]["PQA03"].ToString( ) );
            }
            DataTable d = da.DefaultView.ToTable( true, new string[] { "PQA04" } );
            for (int a = 0; a < d.Rows.Count; a++)
            {
                comboBox3.Items.Add( d.Rows[a]["PQA04"].ToString( ) );
            }
            DataTable f = da.DefaultView.ToTable( true, new string[] { "PQA05" } );
            for (int a = 0; a < f.Rows.Count; a++)
            {
                comboBox4.Items.Add( f.Rows[a]["PQA05"].ToString( ) );
            }
            DataTable g = da.DefaultView.ToTable( true, new string[] { "PQA06" } );
            for (int a = 0; a < g.Rows.Count; a++)
            {
                comboBox5.Items.Add( g.Rows[a]["PQA06"].ToString( ) );
            }
            #endregion

            #region R_PQB每板手喷单面.单遍清面、底漆用量、工资、单价
            db = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQB" );
            gridControl2.DataSource = db;

            DataTable h = db.DefaultView.ToTable( true, new string[] { "PQB02" } );
            for (int a = 0; a < h.Rows.Count; a++)
            {
                comboBox10.Items.Add( h.Rows[a]["PQB02"].ToString( ) );
            }
            DataTable i = db.DefaultView.ToTable( true, new string[] { "PQB03" } );
            for (int a = 0; a < i.Rows.Count; a++)
            {
                comboBox9.Items.Add( i.Rows[a]["PQB03"].ToString( ) );
            }
            DataTable j = db.DefaultView.ToTable( true, new string[] { "PQB04" } );
            for (int a = 0; a < j.Rows.Count; a++)
            {
                comboBox8.Items.Add( j.Rows[a]["PQB04"].ToString( ) );
            }
            DataTable fg = db.DefaultView.ToTable( true, new string[] { "PQB05" } );
            for (int a = 0; a < fg.Rows.Count; a++)
            {
                comboBox7.Items.Add( fg.Rows[a]["PQB05"].ToString( ) );
            }
            DataTable gh = db.DefaultView.ToTable( true, new string[] { "PQB06" } );
            for (int a = 0; a < gh.Rows.Count; a++)
            {
                comboBox6.Items.Add( gh.Rows[a]["PQB06"].ToString( ) );
            }
            #endregion

            #region R_PQC辊涂白面、底漆用量、单价
            dc = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQC" );
            gridControl3.DataSource = dc;

            DataTable bj = dc.DefaultView.ToTable( true, new string[] { "PQC02" } );
            for (int a = 0; a < bj.Rows.Count; a++)
            {
                comboBox15.Items.Add( bj.Rows[a]["PQC02"].ToString( ) );
            }
            DataTable cj = dc.DefaultView.ToTable( true, new string[] { "PQC03" } );
            for (int a = 0; a < cj.Rows.Count; a++)
            {
                comboBox14.Items.Add( cj.Rows[a]["PQC03"].ToString( ) );
            }
            DataTable dj = dc.DefaultView.ToTable( true, new string[] { "PQC04" } );
            for (int a = 0; a < dj.Rows.Count; a++)
            {
                comboBox13.Items.Add( dj.Rows[a]["PQC04"].ToString( ) );
            }
            DataTable gj = dc.DefaultView.ToTable( true, new string[] { "PQC05" } );
            for (int a = 0; a < gj.Rows.Count; a++)
            {
                comboBox12.Items.Add( gj.Rows[a]["PQC05"].ToString( ) );
            }
            #endregion

            #region R_PQD辊涂色面、清底漆用量、单价
            dd = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQD" );
            gridControl4.DataSource = dd;

            DataTable bk = dd.DefaultView.ToTable( true, new string[] { "PQD02" } );
            for (int a = 0; a < bk.Rows.Count; a++)
            {
                comboBox18.Items.Add( bk.Rows[a]["PQD02"].ToString( ) );
            }
            DataTable hk = dd.DefaultView.ToTable( true, new string[] { "PQD03" } );
            for (int a = 0; a < hk.Rows.Count; a++)
            {
                comboBox17.Items.Add( hk.Rows[a]["PQD03"].ToString( ) );
            }
            DataTable gk = dd.DefaultView.ToTable( true, new string[] { "PQD04" } );
            for (int a = 0; a < gk.Rows.Count; a++)
            {
                comboBox16.Items.Add( gk.Rows[a]["PQD04"].ToString( ) );
            }
            DataTable kk = dd.DefaultView.ToTable( true, new string[] { "PQD05" } );
            for (int a = 0; a < kk.Rows.Count; a++)
            {
                comboBox11.Items.Add( kk.Rows[a]["PQD05"].ToString( ) );
            }
            #endregion

            #region R_PQE手喷封边白面、底漆用量、单价
            de = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQE" );
            gridControl5.DataSource = de;

            DataTable bo = de.DefaultView.ToTable( true, new string[] { "PQE02" } );
            for (int a = 0; a < bo.Rows.Count; a++)
            {
                comboBox22.Items.Add( bo.Rows[a]["PQE02"].ToString( ) );
            }
            DataTable fo = de.DefaultView.ToTable( true, new string[] { "PQE03" } );
            for (int a = 0; a < fo.Rows.Count; a++)
            {
                comboBox21.Items.Add( fo.Rows[a]["PQE03"].ToString( ) );
            }
            DataTable go = de.DefaultView.ToTable( true, new string[] { "PQE04" } );
            for (int a = 0; a < go.Rows.Count; a++)
            {
                comboBox20.Items.Add( go.Rows[a]["PQE04"].ToString( ) );
            }
            DataTable ho = de.DefaultView.ToTable( true, new string[] { "PQE05" } );
            for (int a = 0; a < ho.Rows.Count; a++)
            {
                comboBox19.Items.Add( ho.Rows[a]["PQE05"].ToString( ) );
            }
            #endregion

            #region R_PQF 水帘机手喷
            df = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQF" );
            gridControl6.DataSource = df;
            //获得DATATABLE中某列的唯一值
            DataTable dw = df.DefaultView.ToTable( true, new string[] { "PQF01" } );
            for (int a = 0; a < dw.Rows.Count; a++)
            {
                comboBox28.Items.Add( dw.Rows[a]["PQF01"].ToString( ) );
            }
            DataTable bw = df.DefaultView.ToTable( true, new string[] { "PQF02" } );
            for (int a = 0; a < bw.Rows.Count; a++)
            {
                comboBox27.Items.Add( bw.Rows[a]["PQF02"].ToString( ) );
            }
            DataTable tw = df.DefaultView.ToTable( true, new string[] { "PQF03" } );
            for (int a = 0; a < tw.Rows.Count; a++)
            {
                comboBox26.Items.Add( tw.Rows[a]["PQF03"].ToString( ) );
            }
            DataTable hw = df.DefaultView.ToTable( true, new string[] { "PQF04" } );
            for (int a = 0; a < hw.Rows.Count; a++)
            {
                comboBox25.Items.Add( hw.Rows[a]["PQF04"].ToString( ) );
            }
            DataTable gw = df.DefaultView.ToTable( true, new string[] { "PQF05" } );
            for (int a = 0; a < gw.Rows.Count; a++)
            {
                comboBox24.Items.Add( gw.Rows[a]["PQF05"].ToString( ) );
            }
            DataTable nw = df.DefaultView.ToTable( true, new string[] { "PQF06" } );
            for (int a = 0; a < nw.Rows.Count; a++)
            {
                comboBox23.Items.Add( nw.Rows[a]["PQF06"].ToString( ) );
            }
            #endregion

            #region R_PQG 静电喷涂
            dg = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQG" );
            gridControl7.DataSource = dg;
            //获得DATATABLE中某列的唯一值
            DataTable dl = dg.DefaultView.ToTable( true, new string[] { "PQG01" } );
            for (int a = 0; a < dl.Rows.Count; a++)
            {
                comboBox29.Items.Add( dl.Rows[a]["PQG01"].ToString( ) );
            }
            DataTable bl = dg.DefaultView.ToTable( true, new string[] { "PQG02" } );
            for (int a = 0; a < bl.Rows.Count; a++)
            {
                comboBox34.Items.Add( bl.Rows[a]["PQG02"].ToString( ) );
            }
            DataTable tl = dg.DefaultView.ToTable( true, new string[] { "PQG03" } );
            for (int a = 0; a < tl.Rows.Count; a++)
            {
                comboBox33.Items.Add( tl.Rows[a]["PQG03"].ToString( ) );
            }
            DataTable hl = dg.DefaultView.ToTable( true, new string[] { "PQG04" } );
            for (int a = 0; a < hl.Rows.Count; a++)
            {
                comboBox32.Items.Add( hl.Rows[a]["PQG04"].ToString( ) );
            }
            DataTable gl = dg.DefaultView.ToTable( true, new string[] { "PQG05" } );
            for (int a = 0; a < gl.Rows.Count; a++)
            {
                comboBox31.Items.Add( gl.Rows[a]["PQG05"].ToString( ) );
            }
            DataTable nl = dg.DefaultView.ToTable( true, new string[] { "PQG06" } );
            for (int a = 0; a < nl.Rows.Count; a++)
            {
                comboBox30.Items.Add( nl.Rows[a]["PQG06"].ToString( ) );
            }
            #endregion

            #region R_PQH 涂布机加工
            dh = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQH" );
            gridControl8.DataSource = dh;

            DataTable bx = dh.DefaultView.ToTable( true, new string[] { "PQH02" } );
            for (int a = 0; a < bx.Rows.Count; a++)
            {
                comboBox40.Items.Add( bx.Rows[a]["PQH02"].ToString( ) );
            }
            DataTable cx = dh.DefaultView.ToTable( true, new string[] { "PQH03" } );
            for (int a = 0; a < cx.Rows.Count; a++)
            {
                comboBox39.Items.Add( cx.Rows[a]["PQH03"].ToString( ) );
            }
            DataTable dx = dh.DefaultView.ToTable( true, new string[] { "PQH04" } );
            for (int a = 0; a < dx.Rows.Count; a++)
            {
                comboBox38.Items.Add( dx.Rows[a]["PQH04"].ToString( ) );
            }
            DataTable fx = dh.DefaultView.ToTable( true, new string[] { "PQH05" } );
            for (int a = 0; a < fx.Rows.Count; a++)
            {
                comboBox37.Items.Add( fx.Rows[a]["PQH05"].ToString( ) );
            }
            DataTable gx = dh.DefaultView.ToTable( true, new string[] { "PQH06" } );
            for (int a = 0; a < gx.Rows.Count; a++)
            {
                comboBox36.Items.Add( gx.Rows[a]["PQH06"].ToString( ) );
            }
            #endregion

            #region R_PQJ 浸漆
            djj = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQJ" );
            gridControl9.DataSource = djj;

            DataTable bz = djj.DefaultView.ToTable( true, new string[] { "PQJ02" } );
            for (int a = 0; a < bz.Rows.Count; a++)
            {
                comboBox44.Items.Add( bz.Rows[a]["PQJ02"].ToString( ) );
            }
            DataTable cz = djj.DefaultView.ToTable( true, new string[] { "PQJ03" } );
            for (int a = 0; a < cz.Rows.Count; a++)
            {
                comboBox43.Items.Add( cz.Rows[a]["PQJ03"].ToString( ) );
            }
            DataTable dz = djj.DefaultView.ToTable( true, new string[] { "PQJ04" } );
            for (int a = 0; a < dz.Rows.Count; a++)
            {
                comboBox42.Items.Add( dz.Rows[a]["PQJ04"].ToString( ) );
            }
            DataTable fz = djj.DefaultView.ToTable( true, new string[] { "PQJ05" } );
            for (int a = 0; a < fz.Rows.Count; a++)
            {
                comboBox41.Items.Add( fz.Rows[a]["PQJ05"].ToString( ) );
            }
            DataTable gz = djj.DefaultView.ToTable( true, new string[] { "PQJ06" } );
            for (int a = 0; a < gz.Rows.Count; a++)
            {
                comboBox35.Items.Add( gz.Rows[a]["PQJ06"].ToString( ) );
            }
            #endregion
        }

        #region R_PQA 每板手喷单面.单遍色面、底漆用量、工资、单价
        string PQA001 = "", PQA002 = "", PQA003 = "", PQA004 = "", PQA005 = "", PQ2 = "", PQ3 = "", PQ4 = "", PQ5 = "";
        int PQA006 = 0, PQ6 = 0;
        Decimal PQA007 = 0M, PQ7 = 0M;
        //ROWCHANGED
        private void gridView1_FocusedRowChanged( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
            if (gridView1.RowCount < 1)
            {
                textBox1.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox4.Text = "";
                comboBox5.Text = "";
                textBox2.Text = "";
            }
            else
            {
                textBox1.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQA01" ).ToString( );
                comboBox1.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQA02" ).ToString( );
                comboBox2.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQA03" ).ToString( );
                comboBox3.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQA04" ).ToString( );
                comboBox4.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQA05" ).ToString( );
                comboBox5.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQA06" ).ToString( );
                textBox2.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "PQA07" ).ToString( );
                PQ2 = comboBox1.Text;
                PQ3 = comboBox2.Text;
                PQ4 = comboBox3.Text;
                PQ5 = comboBox4.Text;
                if (comboBox5.Text == "")
                {
                    PQ6 = 0;
                }
                else
                {
                    PQ6 = Convert.ToInt32( comboBox5.Text );
                }
                if (textBox2.Text == "")
                {
                    PQ7 = 0;
                }
                else
                {
                    PQ7 = Convert.ToDecimal( textBox2.Text );
                }               
            }     
        }

        //DEL
        private void button4_Click( object sender, EventArgs e )
        {
            int num = gridView1.FocusedRowHandle;
            if (da.Rows.Count < 1)
            {
                MessageBox.Show( "没有数据,无法删除" );
            }
            else
            {
               
                if (da.Rows.Count < 1)
                {
                    MessageBox.Show( "没有数据,无法删除" );
                }
                else
                {
                    int count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQA WHERE PQA02=@PQ2 AND PQA03=@PQ3 AND PQA04=@PQ4 AND PQA05=@PQ5 AND PQA06=@PQ6 AND PQA07=@PQ7", new SqlParameter( "@PQ2", PQ2 ), new SqlParameter( "@PQ3", PQ3 ), new SqlParameter( "@PQ4", PQ4 ), new SqlParameter( "@PQ5", PQ5 ), new SqlParameter( "@PQ6", PQ6 ), new SqlParameter( "@PQ7", PQ7 ) );
                    
                    if (count < 1)
                    {
                        MessageBox.Show( "删除失败" );
                    }
                    else
                    {
                        MessageBox.Show( "删除成功" );
                        da.Rows.RemoveAt( num );
                    }
                }
            }
        }
        //UPDATE
        private void button3_Click( object sender, EventArgs e )
        {
            int num = gridView1.FocusedRowHandle;
            if (da.Rows.Count < 1)
            {
                MessageBox.Show( "没有数据,无法编辑" );
            }
            else
            {
                DataRow dr = da.Rows[num];
                PQA001 = textBox1.Text;
                PQA002 = comboBox1.Text;
                PQA003 = comboBox2.Text;
                PQA004 = comboBox3.Text;
                PQA005 = comboBox4.Text;
                if (comboBox5.Text == "")
                {
                    PQA006 = 0;
                }
                else
                {
                    PQA006 = Convert.ToInt32( comboBox5.Text );
                }
                if (comboBox2.Text == "")
                {
                    PQA007 = 0;
                }
                else
                {
                    PQA007 = Convert.ToDecimal( textBox2.Text );
                }

                dr.BeginEdit( );
                dr["PQA01"] = PQA001;
                dr["PQA02"] = PQA002;
                dr["PQA03"] = PQA003;
                dr["PQA04"] = PQA004;
                dr["PQA05"] = PQA005;
                dr["PQA06"] = PQA006;
                dr["PQA07"] = PQA007;
                dr.EndEdit( );

                int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQA SET PQA02=@PQA02,PQA03=@PQA03,PQA04=@PQA04,PQA05=@PQA05,PQA06=@PQA06,PQA07=@PQA07 WHERE PQA02=@PQ2 AND PQA03=@PQ3 AND PQA04=@PQ4 AND PQA05=@PQ5 AND PQA06=@PQ6 AND PQA07=@PQ7", new SqlParameter( "@PQA02", PQA002 ), new SqlParameter( "@PQA03", PQA003 ), new SqlParameter( "@PQA04", PQA004 ), new SqlParameter( "@PQA05", PQA005 ), new SqlParameter( "@PQA06", PQA006 ), new SqlParameter( "@PQA07", PQA007 ), new SqlParameter( "@PQ2", PQ2 ), new SqlParameter( "@PQ3", PQ3 ), new SqlParameter( "@PQ4", PQ4 ), new SqlParameter( "@PQ5", PQ5 ), new SqlParameter( "@PQ6", PQ6 ), new SqlParameter( "@PQ7", PQ7 ) );
                if (count < 1)
                {
                    MessageBox.Show( "更新失败" );
                }
                else
                {
                    MessageBox.Show( "更新成功" );
                }
            }
        }
        //ADD
        private void button2_Click( object sender, EventArgs e )
        {
            DataRow dr = da.NewRow( );
            PQA001 = textBox1.Text;
            PQA002 = comboBox1.Text;
            PQA003 = comboBox2.Text;
            PQA004 = comboBox3.Text;
            PQA005 = comboBox4.Text;
            if (comboBox5.Text == "")
            {
                PQA006 = 0;
            }
            else
            {
                PQA006 = Convert.ToInt32( comboBox5.Text );
            }
            if (textBox2.Text == "")
            {
                PQA007 = 0;
            }
            else
            {
                PQA007 = Convert.ToDecimal( textBox2.Text );
            }

            dr["PQA01"] = PQA001;
            dr["PQA02"] = PQA002;
            dr["PQA03"] = PQA003;
            dr["PQA04"] = PQA004;
            dr["PQA05"] = PQA005;
            dr["PQA06"] = PQA006;
            dr["PQA07"] = PQA007;
            

            int count = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQA VALUES (@PQA01,@PQA02,@PQA03,@PQA04,@PQA05,@PQA06,@PQA07)", new SqlParameter( "@PQA01", PQA001 ), new SqlParameter( "@PQA02", PQA002 ), new SqlParameter( "@PQA03", PQA003 ), new SqlParameter( "@PQA04", PQA004 ), new SqlParameter( "@PQA05", PQA005 ), new SqlParameter( "@PQA06", PQA006 ), new SqlParameter( "@PQA07", PQA007 ) );
            if (count < 1)
            {
                MessageBox.Show( "录入失败" );
            }
            else
            {
                MessageBox.Show( "录入成功" );
                da.Rows.Add( dr );
            }
        }
        #endregion

        #region R_PQB 每板手喷单面.单遍清面、底漆用量、工资、单价
        string PQB001 = "", PQB002 = "", PQB003 = "", PQB004 = "", PQB005 = "", PB2 = "", PB3 = "", PB4 = "", PB5 = "";
        int PQB006 = 0, PB6 = 0;
        Decimal PQB007 = 0M, PB7 = 0M;
        //ROWCHANGED
        private void gridView2_FocusedRowChanged( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
            if (gridView1.RowCount < 1)
            {
                textBox4.Text = "";
                comboBox10.Text = "";
                comboBox9.Text = "";
                comboBox8.Text = "";
                comboBox7.Text = "";
                comboBox6.Text = "";
                textBox3.Text = "";
            }
            else
            {
                textBox4.Text = gridView2.GetRowCellValue( e.FocusedRowHandle, "PQB01" ).ToString( );
                comboBox10.Text = gridView2.GetRowCellValue( e.FocusedRowHandle, "PQB02" ).ToString( );
                comboBox9.Text = gridView2.GetRowCellValue( e.FocusedRowHandle, "PQB03" ).ToString( );
                comboBox8.Text = gridView2.GetRowCellValue( e.FocusedRowHandle, "PQB04" ).ToString( );
                comboBox7.Text = gridView2.GetRowCellValue( e.FocusedRowHandle, "PQB05" ).ToString( );
                comboBox6.Text = gridView2.GetRowCellValue( e.FocusedRowHandle, "PQB06" ).ToString( );
                textBox3.Text = gridView2.GetRowCellValue( e.FocusedRowHandle, "PQB07" ).ToString( );
                PB2 = comboBox10.Text;
                PB3 = comboBox9.Text;
                PB4 = comboBox8.Text;
                PB5 = comboBox7.Text;
                if (comboBox6.Text == "")
                {
                    PB6 = 0;
                }
                else
                {
                    PB6 = Convert.ToInt32( comboBox6.Text );
                }
                if (textBox3.Text == "")
                {
                    PB7 = 0;
                }
                else
                {
                    PB7 = Convert.ToDecimal( textBox3.Text );
                }
                
            }
            
        }
        //DEL
        private void button1_Click( object sender, EventArgs e )
        {
            int num = gridView2.FocusedRowHandle;
            if (db.Rows.Count < 1)
            {
                MessageBox.Show( "没有数据,无法删除" );
            }
            else
            {
                int count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQB WHERE PQB02=@PB2 AND PQB03=@PB3 AND PQB04=@PB4 AND PQB05=@PB5 AND PQB06=@PB6 AND PQB07=@PB7", new SqlParameter( "@PB2", PB2 ), new SqlParameter( "@PB3", PB3 ), new SqlParameter( "@PB4", PB4 ), new SqlParameter( "@PB5", PB5 ), new SqlParameter( "@PB6", PB6 ), new SqlParameter( "@PB7", PB7 ) );
                if (count < 1)
                {
                    MessageBox.Show( "删除失败" );
                }
                else
                {
                    MessageBox.Show( "删除成功" );
                    db.Rows.RemoveAt( num );
                }
            }
        }
        //UPDATE
        private void button5_Click( object sender, EventArgs e )
        {
            if (comboBox6.Text == "")
            {
                PQB006 = 0;
            }
            else
            {
                PQB006 = Convert.ToInt32( comboBox6.Text );
            }
            if (textBox3.Text == "")
            {
                PQB007 = 0M;
            }
            else
            {
                PQB007 = Convert.ToDecimal( textBox3.Text );
            }
            PQB002 = comboBox10.Text;
            PQB003 = comboBox9.Text;
            PQB004 = comboBox8.Text;
            PQB005 = comboBox7.Text;
            PQB001 = textBox4.Text;
            
            int num = gridView2.FocusedRowHandle;
            if (db.Rows.Count < 1)
            {
                MessageBox.Show( "没有数据,无法编辑" );
            }
            else
            {
                DataRow dr = db.Rows[num];
                dr.BeginEdit( );
                dr["PQB01"] = PQB001;
                dr["PQB02"] = PQB002;
                dr["PQB03"] = PQB003;
                dr["PQB04"] = PQB004;
                dr["PQB05"] = PQB005;
                dr["PQB06"] = PQB006;
                dr["PQB07"] = PQB007;
                dr.EndEdit( );



                int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQB SET PQB02=@PQB02,PQB03=@PQB03,PQB04=@PQB04,PQB05=@PQB05,PQB06=@PQB06,PQB07=@PQB07 WHERE PQB02=@PB2 AND PQB03=@PB3 AND PQB04=@PB4 AND PQB05=@PB5 AND PQB06=@PB6 AND PQB07=@PB7", new SqlParameter( "@PQB02", PQB002 ), new SqlParameter( "@PQB03", PQB003 ), new SqlParameter( "@PQB04", PQB004 ), new SqlParameter( "@PQB05", PQB005 ), new SqlParameter( "@PQB06", PQB006 ), new SqlParameter( "@PQB07", PQB007 ), new SqlParameter( "@PB2", PB2 ), new SqlParameter( "@PB3", PB3 ), new SqlParameter( "@PB4", PB4 ), new SqlParameter( "@PB5", PB5 ), new SqlParameter( "@PB6", PB6 ), new SqlParameter( "@PB7", PB7 ) );
                if (count < 1)
                {
                    MessageBox.Show( "更新失败" );
                }
                else
                {
                    MessageBox.Show( "更新成功" );
                }
            } 
        }
        //ADD
        private void button6_Click( object sender, EventArgs e )
        {
            if (comboBox6.Text == "")
            {
                PQB006 = 0;
            }
            else
            {
                PQB006 = Convert.ToInt32( comboBox6.Text );
            }
            if (textBox3.Text == "")
            {
                PQB007 = 0M;
            }
            else
            {
                PQB007 = Convert.ToDecimal( textBox3.Text );
            }
            PQB002 = comboBox10.Text;
            PQB003 = comboBox9.Text;
            PQB004 = comboBox8.Text;
            PQB005 = comboBox7.Text;
            PQB001 = textBox4.Text;
            DataRow dr = db.NewRow();
            dr["PQB01"] = PQB001;
            dr["PQB02"] = PQB002;
            dr["PQB03"] = PQB003;
            dr["PQB04"] = PQB004;
            dr["PQB05"] = PQB005;
            dr["PQB06"] = PQB006;
            dr["PQB07"] = PQB007;
            

            int count = SqlHelper.ExecuteNonQuery("INSERT INTO R_PQB VALUES (@PQB01,@PQB02,@PQB03,@PQB04,@PQB05,@PQB06,@PQB07)", new SqlParameter("@PQB01", PQB001), new SqlParameter("@PQB02", PQB002), new SqlParameter("@PQB03", PQB003), new SqlParameter("@PQB04", PQB004), new SqlParameter("@PQB05", PQB005), new SqlParameter("@PQB06", PQB006), new SqlParameter("@PQB07", PQB007));
            if (count < 1)
            {
                MessageBox.Show("录入失败");
            }
            else
            {
                MessageBox.Show("录入成功");
                db.Rows.Add( dr );
            }
        }
        #endregion

        #region R_PQC辊涂白面、底漆用量、单价
        string PQC001 = "", PQC002 = "", PQC003 = "", PQC004 = "", PQC005 = "", PC2 = "", PC3 = "", PC4 = "", PC5 = "";
        Decimal PQC006 = 0M, PC6 = 0M;
        //ROWCHANGED
        private void gridView3_FocusedRowChanged( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
            if (gridView1.RowCount < 1)
            {
                textBox6.Text = "";
                comboBox15.Text = "";
                comboBox14.Text = "";
                comboBox13.Text = "";
                comboBox12.Text = "";
                textBox5.Text = "";
            }
            else
            {
                textBox6.Text= gridView3.GetRowCellValue( e.FocusedRowHandle, "PQC01" ).ToString( );
                comboBox15.Text = gridView3.GetRowCellValue( e.FocusedRowHandle, "PQC02" ).ToString( );
                comboBox14.Text = gridView3.GetRowCellValue( e.FocusedRowHandle, "PQC03" ).ToString( );
                comboBox13.Text = gridView3.GetRowCellValue( e.FocusedRowHandle, "PQC04" ).ToString( );
                comboBox12.Text = gridView3.GetRowCellValue( e.FocusedRowHandle, "PQC05" ).ToString( );
                textBox5.Text = gridView3.GetRowCellValue( e.FocusedRowHandle, "PQC06" ).ToString( );
                PC2 = comboBox15.Text;
                PC3 = comboBox14.Text;
                PC4 = comboBox13.Text;
                PC5 = comboBox12.Text;
                if (textBox5.Text == "")
                {
                    PC6 = 0M;
                }
                else
                {
                    PC6 = Convert.ToDecimal( textBox5.Text );
                }

            }
        }
        //DEL
        private void button7_Click( object sender, EventArgs e )
        {
            int num = gridView3.FocusedRowHandle;
            if (dc.Rows.Count < 1)
            {
                MessageBox.Show( "没有数据,无法删除" );
            }
            else
            {
                int count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQC WHERE PQC02=@PC2 AND PQC03=@PC3 AND PQC04=@PC4 AND PQC05=@PC5 AND PQC06=@PC6", new SqlParameter( "@PC2", PC2 ), new SqlParameter( "@PC3", PC3 ), new SqlParameter( "@PC4", PC4 ), new SqlParameter( "@PC5", PC5 ), new SqlParameter( "@PC6", PC6 ) );
                if (count < 1)
                {
                    MessageBox.Show( "删除失败" );
                }
                else
                {
                    MessageBox.Show( "删除成功" );
                    dc.Rows.RemoveAt( num );
                }
            }
        }
        //UPDATE
        private void button8_Click( object sender, EventArgs e )
        {
            if (textBox5.Text == "")
            {
                PQC006 = 0M;
            }
            else
            {
                PQC006 = Convert.ToDecimal( textBox5.Text );
            }
            PQC002 = comboBox15.Text;
            PQC003 = comboBox14.Text;
            PQC004 = comboBox13.Text;
            PQC005 = comboBox12.Text;
            PQC001 = textBox6.Text;
            int num = gridView3.FocusedRowHandle;
            if (dc.Rows.Count < 1)
            {
                MessageBox.Show( "没有数据,无法编辑" );
            }
            else
            {

                DataRow dr = dc.Rows[num];
                dr.BeginEdit( );
                dr["PQC01"] = PQC001;
                dr["PQC02"] = PQC002;
                dr["PQC03"] = PQC003;
                dr["PQC04"] = PQC004;
                dr["PQC05"] = PQC005;
                dr["PQC06"] = PQC006;
                dr.EndEdit( );

                int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQC SET PQC02=@PQC02,PQC03=@PQC03,PQC04=@PQC04,PQC05=@PQC05,PQC06=@PQC06 WHERE PQC02=@PC2 AND PQC03=@PC3 AND PQC04=@PC4 AND PQC05=@PC5 AND PQC06=@PC6", new SqlParameter( "@PQC02", PQC002 ), new SqlParameter( "@PQC03", PQC003 ), new SqlParameter( "@PQC04", PQC004 ), new SqlParameter( "@PQC05", PQC005 ), new SqlParameter( "@PQC06", PQC006 ), new SqlParameter( "@PC2", PC2 ), new SqlParameter( "@PC3", PC3 ), new SqlParameter( "@PC4", PC4 ), new SqlParameter( "@PC5", PC5 ), new SqlParameter( "@PC6", PC6 ) );
                if (count < 1)
                {
                    MessageBox.Show( "更新失败" );
                }
                else
                {
                    MessageBox.Show( "更新成功" );
                }
            }
        }
        //ADD
        private void button9_Click( object sender, EventArgs e )
        {
            if (textBox5.Text == "")
            {
                PQC006 = 0M;
            }
            else
            {
                PQC006 = Convert.ToDecimal( textBox5.Text );
            }
            PQC002 = comboBox15.Text;
            PQC003 = comboBox14.Text;
            PQC004 = comboBox13.Text;
            PQC005 = comboBox12.Text;
            PQC001 = textBox6.Text;
            DataRow dr = dc.NewRow();
            dr["PQC01"] = PQC001;
            dr["PQC02"] = PQC002;
            dr["PQC03"] = PQC003;
            dr["PQC04"] = PQC004;
            dr["PQC05"] = PQC005;
            dr["PQC06"] = PQC006;          

            int count = SqlHelper.ExecuteNonQuery("INSERT INTO R_PQC VALUES (@PQC01,@PQC02,@PQC03,@PQC04,@PQC05,@PQC06)", new SqlParameter("@PQC01", PQC001), new SqlParameter("@PQC02", PQC002), new SqlParameter("@PQC03", PQC003), new SqlParameter("@PQC04", PQC004), new SqlParameter("@PQC05", PQC005), new SqlParameter("@PQC06", PQC006));
            if (count < 1)
            {
                MessageBox.Show("录入失败");
            }
            else
            {
                MessageBox.Show("录入成功");
                dc.Rows.Add( dr );
            }
        }
        #endregion

        #region R_PQC辊涂色面、清底漆用量、单价
        string PQD001 = "", PQD002 = "", PQD003 = "", PQD004 = "", PQD005 = "", PD2 = "", PD3 = "", PD4 = "", PD5 = "";
        Decimal PQD006 = 0M, PD6 = 0M;

        //ROWCHANGED
        private void gridView4_FocusedRowChanged( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
            if (gridView4.RowCount < 1)
            {
                textBox8.Text = "";
                comboBox18.Text = "";
                comboBox17.Text = "";
                comboBox16.Text = "";
                comboBox11.Text = "";
                textBox7.Text = "";
            }
            else
            {
                textBox8.Text= gridView4.GetRowCellValue( e.FocusedRowHandle, "PQD01" ).ToString( );
                comboBox18.Text = gridView4.GetRowCellValue(e.FocusedRowHandle, "PQD02").ToString();
                comboBox17.Text = gridView4.GetRowCellValue(e.FocusedRowHandle, "PQD03").ToString();
                comboBox16.Text = gridView4.GetRowCellValue(e.FocusedRowHandle, "PQD04").ToString();
                comboBox11.Text = gridView4.GetRowCellValue(e.FocusedRowHandle, "PQD05").ToString();
                textBox7.Text = gridView4.GetRowCellValue(e.FocusedRowHandle, "PQD06").ToString();
                PD2 = comboBox18.Text;
                PD3 = comboBox17.Text;
                PD4 = comboBox16.Text;
                PD5 = comboBox11.Text;
                if (textBox7.Text == "")
                {
                    PD6 = 0;
                }
                else
                {
                    PD6 = Convert.ToDecimal( textBox7.Text );
                }
                
            }    
        }
        //DEL
        private void button10_Click( object sender, EventArgs e )
        {
            int num = gridView4.FocusedRowHandle;
            if (dd.Rows.Count < 1)
            {
                MessageBox.Show( "没有数据,无法删除" );
            }
            else
            {
                int count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQD WHERE PQD02=@PD2 AND PQD03=@PD3 AND PQD04=@PD4 AND PQD05=@PD5 AND PQD06=@PD6", new SqlParameter( "@PD2", PD2 ), new SqlParameter( "@PD3", PD3 ), new SqlParameter( "@PD4", PD4 ), new SqlParameter( "@PD5", PD5 ), new SqlParameter( "@PD6", PD6 ) ); 
                if (count < 1)
                {
                    MessageBox.Show( "删除失败" );
                }
                else
                {
                    MessageBox.Show( "删除成功" );
                    dd.Rows.RemoveAt( num );
                }
            }
        }
        //UPDATE
        private void button11_Click( object sender, EventArgs e )
        {
            int num = gridView4.FocusedRowHandle;
            PQD001 = textBox8.Text;
            PQD002 = comboBox18.Text;
            PQD003 = comboBox17.Text;
            PQD004 = comboBox16.Text;
            PQD005 = comboBox11.Text;
            if (textBox7.Text == "")
            {
                PQD006 = 0M;
            }
            else
            {
                PQD006 = Convert.ToDecimal( textBox7.Text );
            }
            if (dd.Rows.Count < 1)
            {
                MessageBox.Show( "没有数据,无法编辑" );
            }
            else
            {
                DataRow dr = dd.Rows[num];
                dr.BeginEdit( );
                dr["PQD01"] =PQD001;
                dr["PQD02"] = PQD002;
                dr["PQD03"] = PQD003;
                dr["PQD04"] = PQD004;
                dr["PQD05"] = PQD005;
                dr["PQD06"] = PQD006;
                dr.EndEdit( );

                int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQD SET PQD02=@PQD02,PQD03=@PQD03,PQD04=@PQD04,PQD05=@PQD05,PQD06=@PQD06 WHERE PQD02=@PD2 AND PQD03=@PD3 AND PQD04=@PD4 AND PQD05=@PD5 AND PQD06=@PD6", new SqlParameter( "@PQD02", PQD002 ), new SqlParameter( "@PQD03", PQD003 ), new SqlParameter( "@PQD04", PQD004 ), new SqlParameter( "@PQD05", PQD005 ), new SqlParameter( "@PQD06", PQD006 ), new SqlParameter( "@PD2", PD2 ), new SqlParameter( "@PD3", PD3 ), new SqlParameter( "@PD4", PD4 ), new SqlParameter( "@PD5", PD5 ), new SqlParameter( "@PD6", PD6 ) );
                if (count < 1)
                {
                    MessageBox.Show( "更新失败" );
                }
                else
                {
                    MessageBox.Show( "更新成功" );
                }
            }
        }
        //ADD
        private void button12_Click( object sender, EventArgs e )
        {
            DataRow dr = dd.NewRow( );
            PQD001 = textBox8.Text;
            PQD002 = comboBox18.Text;
            PQD003 = comboBox17.Text;
            PQD004 = comboBox16.Text;
            PQD005 = comboBox11.Text;
            if (textBox7.Text == "")
            {
                PQD006 = 0M;
            }
            else
            {
                PQD006 = Convert.ToDecimal( textBox7.Text );
            }
            if (dd.Rows.Count < 1)
            {
                MessageBox.Show( "没有数据,无法编辑" );
            }
            else
            {
                dr["PQD01"] = PQD001;
                dr["PQD02"] = PQD002;
                dr["PQD03"] = PQD003;
                dr["PQD04"] = PQD004;
                dr["PQD05"] = PQD005;
                dr["PQD06"] = PQD006;

                int count = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQD VALUES (@PQD01,@PQD02,@PQD03,@PQD04,@PQD05,@PQD06)", new SqlParameter( "@PQD01", PQD001 ), new SqlParameter( "@PQD02", PQD002 ), new SqlParameter( "@PQD03", PQD003 ), new SqlParameter( "@PQD04", PQD004 ), new SqlParameter( "@PQD05", PQD005 ), new SqlParameter( "@PQD06", PQD006 ) );
                if (count < 1)
                {
                    MessageBox.Show( "录入失败" );
                }
                else
                {
                    MessageBox.Show( "录入成功" );
                    dd.Rows.Add( dr );
                }
            }
        }
        #endregion

        #region R_PQE手喷封边白面、底漆用量、单价
        string PQE001 = "", PQE002 = "", PQE003 = "", PQE004 = "", PQE005 = "", PE2 = "", PE3 = "", PE4 = "", PE5 = "";
        Decimal PQE006 = 0M, PE6 = 0M;
        //ROWCHANGED
        private void gridView5_FocusedRowChanged( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
            if (gridView5.RowCount < 1)
            {
                textBox10.Text = "";
                comboBox22.Text = "";
                comboBox21.Text = "";
                comboBox20.Text = "";
                comboBox19.Text = "";
                textBox9.Text = "";
            }
            else
            {
                textBox10.Text= gridView5.GetRowCellValue( e.FocusedRowHandle, "PQE01" ).ToString( );
                comboBox22.Text = gridView5.GetRowCellValue(e.FocusedRowHandle, "PQE02").ToString();
                comboBox21.Text = gridView5.GetRowCellValue(e.FocusedRowHandle, "PQE03").ToString();
                comboBox20.Text = gridView5.GetRowCellValue(e.FocusedRowHandle, "PQE04").ToString();
                comboBox19.Text = gridView5.GetRowCellValue(e.FocusedRowHandle, "PQE05").ToString();
                textBox9.Text = gridView5.GetRowCellValue(e.FocusedRowHandle, "PQE06").ToString();
                PE2 = comboBox22.Text;
                PE3 = comboBox21.Text;
                PE4 = comboBox20.Text;
                PE5 = comboBox19.Text;
                if (textBox9.Text == "")
                {
                    PE6 = 0M;
                }
                else
                {
                    PE6 = Convert.ToDecimal( textBox9.Text );
                }                
            }
        }
        //DEL
        private void button13_Click( object sender, EventArgs e )
        {
            int num = gridView5.FocusedRowHandle;
            if (de.Rows.Count < 1)
            {
                MessageBox.Show( "没有数据,无法删除" );
            }
            else
            {
                int count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQE WHERE PQE02=@PE2 AND PQE03=@PE3 AND PQE04=@PE4 AND PQE05=@PE5 AND PQE06=@PE6", new SqlParameter( "@PE2", PE2 ), new SqlParameter( "@PE3", PE3 ), new SqlParameter( "@PE4", PE4 ), new SqlParameter( "@PE5", PE5 ), new SqlParameter( "@PE6", PE6 ) );           
                if (count < 1)
                {
                    MessageBox.Show( "删除失败" );
                }
                else
                {
                    MessageBox.Show( "删除成功" );
                    de.Rows.RemoveAt( num );
                }
            }
        }
        //UPDATE
        private void button14_Click( object sender, EventArgs e )
        {
            int num = gridView5.FocusedRowHandle;
            PQE001 = textBox10.Text;
            PQE002 = comboBox22.Text;
            PQE003 = comboBox21.Text;
            PQE004 = comboBox20.Text;
            PQE005 = comboBox19.Text;
            if (textBox9.Text == "")
            {
                PQE006 = 0;
            }
            else
            {
                PQE006 = Convert.ToDecimal( textBox9.Text );
            }
            if (de.Rows.Count < 1)
            {
                MessageBox.Show( "没有数据,无法编辑" );
            }
            else
            {
                DataRow dr = de.Rows[num];
                dr.BeginEdit( );
                dr["PQE01"] = PQE001;
                dr["PQE02"] = PQE002;
                dr["PQE03"] = PQE003;
                dr["PQE04"] = PQE004;
                dr["PQE05"] = PQE005;
                dr["PQE06"] = PQE006;
                dr.EndEdit( );

                int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQE SET PQE02=@PQE02,PQE03=@PQE03,PQE04=@PQE04,PQE05=@PQE05,PQE06=@PQE06 WHERE PQE02=@PE2 AND PQE03=@PE3 AND PQE04=@PE4 AND PQE05=@PE5 AND PQE06=@PE6", new SqlParameter( "@PQE02", PQE002 ), new SqlParameter( "@PQE03", PQE003 ), new SqlParameter( "@PQE04", PQE004 ), new SqlParameter( "@PQE05", PQE005 ), new SqlParameter( "@PQE06", PQE006 ), new SqlParameter( "@PE2", PE2 ), new SqlParameter( "@PE3", PE3 ), new SqlParameter( "@PE4", PE4 ), new SqlParameter( "@PE5", PE5 ), new SqlParameter( "@PE6", PE6 ) );
                if (count < 1)
                {
                    MessageBox.Show( "更新失败" );
                }
                else
                {
                    MessageBox.Show( "更新成功" );
                }
            }
        }
        //ADD
        private void button15_Click( object sender, EventArgs e )
        {
            DataRow dr = de.NewRow();
            PQE001 = textBox10.Text;
            PQE002 = comboBox22.Text;
            PQE003 = comboBox21.Text;
            PQE004 = comboBox20.Text;
            PQE005 = comboBox19.Text;
            if (textBox9.Text == "")
            {
                PQE006 = 0;
            }
            else
            {
                PQE006 = Convert.ToDecimal( textBox9.Text );
            }
            dr["PQE01"] = PQE001;
            dr["PQE02"] = PQE002;
            dr["PQE03"] = PQE003;
            dr["PQE04"] = PQE004;
            dr["PQE05"] = PQE005;
            dr["PQE06"] = PQE006;
            
            int count = SqlHelper.ExecuteNonQuery("INSERT INTO R_PQE VALUES (@PQE01,@PQE02,@PQE03,@PQE04,@PQE05,@PQE06)", new SqlParameter("@PQE01", PQE001), new SqlParameter("@PQE02", PQE002), new SqlParameter("@PQE03", PQE003), new SqlParameter("@PQE04", PQE004), new SqlParameter("@PQE05", PQE005), new SqlParameter("@PQE06", PQE006));
            if (count < 1)
            {
                MessageBox.Show("录入失败");
            }
            else
            {
                MessageBox.Show("录入成功");
                de.Rows.Add( dr );
            }
        }
        #endregion

        #region R_PQF 水帘机手喷
        string PQF001 = "", PQF002 = "", PQF003 = "", PQF004 = "",PF1="", PF2 = "", PF3 = "", PF4 = "";
        int PQF006 = 0, PF6 = 0;
        Decimal PQF007 = 0M, PF7 = 0M, PQF005 =0M,PF5=0M;
        //ROWCHANGED
        private void gridView6_FocusedRowChanged( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
            if (gridView1.RowCount < 1)
            {
                comboBox28.Text = "";
                comboBox27.Text = "";
                comboBox26.Text = "";
                comboBox25.Text = "";
                comboBox24.Text = "";
                comboBox23.Text = "";
                textBox11.Text = "";
            }
            else
            {
                comboBox28.Text = gridView6.GetRowCellValue(e.FocusedRowHandle, "PQF01").ToString();
                comboBox27.Text = gridView6.GetRowCellValue(e.FocusedRowHandle, "PQF02").ToString();
                comboBox26.Text = gridView6.GetRowCellValue(e.FocusedRowHandle, "PQF03").ToString();
                comboBox25.Text = gridView6.GetRowCellValue(e.FocusedRowHandle, "PQF04").ToString();
                comboBox24.Text = gridView6.GetRowCellValue(e.FocusedRowHandle, "PQF05").ToString();
                comboBox23.Text = gridView6.GetRowCellValue(e.FocusedRowHandle, "PQF06").ToString();
                textBox11.Text = gridView6.GetRowCellValue(e.FocusedRowHandle, "PQF07").ToString();
                PF1 = comboBox28.Text;
                PF2 = comboBox27.Text;
                PF3 = comboBox26.Text;
                PF4 = comboBox25.Text;
                if (comboBox24.Text == "")
                {
                    PF5 = 0M;
                }
                else
                {
                    PF5 = Convert.ToDecimal( comboBox24.Text );
                }
                if (comboBox23.Text == "")
                {
                    PF6 = 0;
                }
                else
                {
                    PF6 = Convert.ToInt32( comboBox23.Text );
                }
                if (textBox11.Text == "")
                {
                    PF7 = 0M;
                }
                else
                {
                    PF7 = Convert.ToDecimal( textBox11.Text );
                }
                
            }         
        }
        //DEL
        private void button16_Click( object sender, EventArgs e )
        {
            int num = gridView6.FocusedRowHandle;
            if (df.Rows.Count < 1)
            {
                MessageBox.Show( "没有数据,无法删除" );
            }
            else
            {
                int count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQF WHERE PQF01=@PF1,PQF02=@PF2 AND PQF03=@PF3 AND PQF04=@PF4 AND PQF05=@PF5 AND PQF06=@PF6 AND PQF07=@PF7", new SqlParameter( "@PF1", PF1 ), new SqlParameter( "@PF2", PF2 ), new SqlParameter( "@PF3", PF3 ), new SqlParameter( "@PF4", PF4 ), new SqlParameter( "@PF5", PF5 ), new SqlParameter( "@PF6", PF6 ), new SqlParameter( "@PF7", PF7 ) );
                if (count < 1)
                {
                    MessageBox.Show( "删除失败" );
                }
                else
                {
                    MessageBox.Show( "删除成功" );
                    df.Rows.RemoveAt( num );
                }
            }
        }
        //UPDATE
        private void button17_Click( object sender, EventArgs e )
        {
            int num = gridView6.FocusedRowHandle;
            if (df.Rows.Count < 1)
            {
                MessageBox.Show( "没有数据,无法编译" );
            }
            else
            {
                PQF001 = comboBox28.Text;
                PQF002 = comboBox27.Text;
                PQF003 = comboBox26.Text;
                PQF004 = comboBox25.Text;
                if (comboBox24.Text == "")
                {
                    PQF005 = 0M;
                }
                else
                {
                    PQF005 = Convert.ToDecimal( comboBox24.Text );
                }
                if (comboBox23.Text == "")
                {
                    PQF006 = 0;
                }
                else
                {
                    PQF006 = Convert.ToInt32( comboBox23.Text );
                }
                if (textBox11.Text == "")
                {
                    PQF007 = 0M;
                }
                else
                {
                    PQF007 = Convert.ToDecimal( textBox11.Text );
                }
                DataRow dr = df.Rows[num];
                dr.BeginEdit( );
                dr["PQF01"] = PQF001;
                dr["PQF02"] = PQF002;
                dr["PQF03"] = PQF003;
                dr["PQF04"] = PQF004;
                dr["PQF05"] = PQF005;
                dr["PQF06"] = PQF006;
                dr["PQF07"] = PQF007;
                dr.EndEdit( );

                int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQF SET PQF01=@PQF01,PQF02=@PQF02,PQF03=@PQF03,PQF04=@PQF04,PQF05=@PQF05,PQF06=@PQF06,PQF07=@PQF07 WHERE PQF01=@PF1,PQF02=@PF2 AND PQF03=@PF3 AND PQF04=@PF4 AND PQF05=@PF5 AND PQF06=@PF6 AND PQF07=@PF7", new SqlParameter( "@PQF01", PQF001 ), new SqlParameter( "@PQF02", PQF002 ), new SqlParameter( "@PQF03", PQF003 ), new SqlParameter( "@PQF04", PQF004 ), new SqlParameter( "@PQF05", PQF005 ), new SqlParameter( "@PQF06", PQF006 ), new SqlParameter( "@PQF07", PQF007 ), new SqlParameter( "@PF1", PF1 ), new SqlParameter( "@PF2", PF2 ), new SqlParameter( "@PF3", PF3 ), new SqlParameter( "@PF4", PF4 ), new SqlParameter( "@PF5", PF5 ), new SqlParameter( "@PF6", PF6 ), new SqlParameter( "@PF7", PF7 ) );
                if (count < 1)
                {
                    MessageBox.Show( "更新失败" );
                }
                else
                {
                    MessageBox.Show( "更新成功" );
                }
            }
        }
        //ADD
        private void button18_Click( object sender, EventArgs e )
        {
            DataRow dr = df.NewRow();
            PQF001 = comboBox28.Text;
            PQF002 = comboBox27.Text;
            PQF003 = comboBox26.Text;
            PQF004 = comboBox25.Text;
            if (comboBox24.Text == "")
            {
                PQF005 = 0M;
            }
            else
            {
                PQF005 = Convert.ToDecimal( comboBox24.Text );
            }
            if (comboBox23.Text == "")
            {
                PQF006 = 0;
            }
            else
            {
                PQF006 = Convert.ToInt32( comboBox23.Text );
            }
            if (textBox11.Text == "")
            {
                PQF007 = 0M;
            }
            else
            {
                PQF007 = Convert.ToDecimal( textBox11.Text );
            }
            dr["PQF01"] = PQF001;
            dr["PQF02"] = PQF002;
            dr["PQF03"] = PQF003;
            dr["PQF04"] = PQF004;
            dr["PQF05"] = PQF005;
            dr["PQF06"] = PQF006;
            dr["PQF07"] = PQF007;
            
            int count = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQF VALUES (@PQF01,@PQF02,@PQF03,@PQF04,@PQF05,@PQF06,@PQF07)", new SqlParameter( "@PQF01", PQF001 ), new SqlParameter( "@PQF02", PQF002 ), new SqlParameter( "@PQF03", PQF003 ), new SqlParameter( "@PQF04", PQF004 ), new SqlParameter( "@PQF05", PQF005 ), new SqlParameter( "@PQF06", PQF006 ), new SqlParameter( "@PQF07", PQF007 ) );
            if (count < 1)
            {
                MessageBox.Show("录入失败");
            }
            else
            {
                MessageBox.Show("录入成功");
                df.Rows.Add( dr );
            }
        }
        #endregion

        #region R_PQG 静电喷涂
        string PQG001 = "", PQG002 = "", PQG003 = "", PQG004 = "", PG1 = "", PG2 = "", PG3 = "", PG4 = "";
        int PQG006 = 0, PG6 = 0;
        Decimal PQG007 = 0M, PG7 = 0M, PQG005 = 0M, PG5 = 0M;
        //ROWCHANGED
        private void gridView7_FocusedRowChanged( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
            if (gridView7.RowCount < 1)
            {
                comboBox29.Text = "";
                comboBox34.Text = "";
                comboBox33.Text = "";
                comboBox32.Text = "";
                comboBox31.Text = "";
                comboBox30.Text = "";
                textBox12.Text = "";
            }
            else
            {
                comboBox29.Text = gridView7.GetRowCellValue(e.FocusedRowHandle, "PQG01").ToString();
                comboBox34.Text = gridView7.GetRowCellValue(e.FocusedRowHandle, "PQG02").ToString();
                comboBox33.Text = gridView7.GetRowCellValue(e.FocusedRowHandle, "PQG03").ToString();
                comboBox32.Text = gridView7.GetRowCellValue(e.FocusedRowHandle, "PQG04").ToString();
                comboBox31.Text = gridView7.GetRowCellValue(e.FocusedRowHandle, "PQG05").ToString();
                comboBox30.Text = gridView7.GetRowCellValue(e.FocusedRowHandle, "PQG06").ToString();
                textBox12.Text = gridView7.GetRowCellValue( e.FocusedRowHandle, "PQG07" ).ToString( );
                PG1 = comboBox29.Text;
                PG2 = comboBox34.Text;
                PG3 = comboBox33.Text;
                PG4 = comboBox32.Text;
                if (comboBox31.Text == "")
                {
                    PG5 = 0M;
                }
                else
                {
                    PG5 = Convert.ToDecimal( comboBox31.Text );
                }
                if (comboBox30.Text == "")
                {
                    PG6 = 0;
                }
                else
                {
                    PG6 = Convert.ToInt32( comboBox30.Text );
                }
                if (textBox12.Text == "")
                {
                    PG7 = 0M;
                }
                else
                {
                    PG7 = Convert.ToDecimal( textBox12.Text );
                } 
            }        
        }
        //DEL
        private void button19_Click( object sender, EventArgs e )
        {
            int num = gridView7.FocusedRowHandle;
            if (dg.Rows.Count < 1)
            {
                MessageBox.Show( "没有数据,无法删除" );
            }
            else
            {
                int count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQG WHERE PQG01=@PG1 AND PQG02=@PG2 AND PQG03=@PG3 AND PQG04=@PF4 AND PQG05=@PF5 AND PQG06=@PG6 AND PQG07=@PG7", new SqlParameter( "@PG1", PG1 ), new SqlParameter( "@PG2", PG2 ), new SqlParameter( "@PG3", PG3 ), new SqlParameter( "@PG4", PG4 ), new SqlParameter( "@PG5", PG5 ), new SqlParameter( "@PG6", PG6 ), new SqlParameter( "@PG7", PG7 ) );
                
                if (count < 1)
                {
                    MessageBox.Show( "删除失败" );
                }
                else
                {
                    MessageBox.Show( "删除成功" );
                    dg.Rows.RemoveAt( num );
                }
            }
        }
        //UPDATE
        private void button20_Click( object sender, EventArgs e )
        {
            int num = gridView7.FocusedRowHandle;
            if (dg.Rows.Count < 1)
            {
                MessageBox.Show( "没有数据,无法编译" );
            }
            else
            {
                PQG001 = comboBox29.Text;
                PQG002 = comboBox34.Text;
                PQG003 = comboBox33.Text;
                PQG004 = comboBox32.Text;
                if (comboBox31.Text == "")
                {
                    PQG005 = 0M;
                }
                else
                {
                    PQG005 = Convert.ToDecimal( comboBox31.Text );
                }
                if (comboBox30.Text == "")
                {
                    PQG006 = 0;
                }
                else
                {
                    PQG006 = Convert.ToInt32( comboBox30.Text );
                }
                if (textBox12.Text == "")
                {
                    PQG007 = 0M;
                }
                else
                {
                    PQG007 = Convert.ToDecimal( textBox12.Text );
                }

                DataRow dr = dg.Rows[num];
                dr.BeginEdit( );
                dr["PQG01"] = PQG001;
                dr["PQG02"] = PQG002;
                dr["PQG03"] = PQG003;
                dr["PQG04"] = PQG004;
                dr["PQG05"] = PQG005;
                dr["PQG06"] = PQG006;
                dr["PQG07"] = PQG007;
                dr.EndEdit( );

                int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQG SET PQG01=@PQG01,PQG02=@PQG02,PQG03=@PQG03,PQG04=@PQG04,PQG05=@PQG05,PQG06=@PQG06,PQG07=@PQG07 WHERE PQG01=@PG1,PQG02=@PG2 AND PQG03=@PG3 AND PQG04=@PG4 AND PQG05=@PG5 AND PQG06=@PG6 AND PQG07=@PG7", new SqlParameter( "@PQG01", PQG001 ), new SqlParameter( "@PQG02", PQG002 ), new SqlParameter( "@PQG03", PQG003 ), new SqlParameter( "@PQG04", PQG004 ), new SqlParameter( "@PQG05", PQG005 ), new SqlParameter( "@PQG06", PQG006 ), new SqlParameter( "@PQG07", PQG007 ), new SqlParameter( "@PG1", PG1 ), new SqlParameter( "@PG2", PG2 ), new SqlParameter( "@PG3", PG3 ), new SqlParameter( "@PG4", PG4 ), new SqlParameter( "@PG5", PG5 ), new SqlParameter( "@PG6", PG6 ), new SqlParameter( "@PG7", PG7 ) );
                if (count < 1)
                {
                    MessageBox.Show( "更新失败" );
                }
                else
                {
                    MessageBox.Show( "更新成功" );
                }
            }
        }
        //ADD
        private void button21_Click( object sender, EventArgs e )
        {
            DataRow dr = dg.NewRow();
            PQG001 = comboBox29.Text;
            PQG002 = comboBox34.Text;
            PQG003 = comboBox33.Text;
            PQG004 = comboBox32.Text;
            if (comboBox31.Text == "")
            {
                PQG005 = 0M;
            }
            else
            {
                PQG005 = Convert.ToDecimal( comboBox31.Text );
            }
            if (comboBox30.Text == "")
            {
                PQG006 = 0;
            }
            else
            {
                PQG006 = Convert.ToInt32( comboBox30.Text );
            }
            if (textBox12.Text == "")
            {
                PQG007 = 0M;
            }
            else
            {
                PQG007 = Convert.ToDecimal( textBox12.Text );
            }
            dr["PQG01"] = PQG001;
            dr["PQG02"] = PQG002;
            dr["PQG03"] = PQG003;
            dr["PQG04"] = PQG004;
            dr["PQG05"] = PQG005;
            dr["PQG06"] = PQG006;
            dr["PQG07"] = PQG007;
            
            int count = SqlHelper.ExecuteNonQuery("INSERT INTO R_PQG VALUES (@PQG01,@PQG02,@PQG03,@PQG04,@PQG05,@PQG06,@PQG07)", new SqlParameter("@PQG01", PQG001), new SqlParameter("@PQG02", PQG002), new SqlParameter("@PQG03", PQG003), new SqlParameter("@PQG04", PQG004), new SqlParameter("@PQG05", PQG005), new SqlParameter("@PQG06", PQG006), new SqlParameter("@PQG07", PQG007));
            if (count < 1)
            {
                MessageBox.Show("录入失败");
            }
            else
            {
                MessageBox.Show("录入成功");
                dg.Rows.Add( dr );
            }
        }
        #endregion

        #region R_PQH 涂布机加工
        string PQH001 = "", PQH002 = "", PQH003 = "", PQH004 = "", PQH005 = "", PH2 = "", PH3 = "", PH4 = "", PH5 = "";
        int PQH006 = 0, PH6 = 0;
        Decimal PQH007 = 0M, PH7 = 0M;
        //ROWCHANGED
        private void gridView8_FocusedRowChanged( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
            if (gridView8.RowCount < 1)
            {
                textBox14.Text = "";
                comboBox40.Text = "";
                comboBox39.Text = "";
                comboBox38.Text = "";
                comboBox37.Text = "";
                comboBox36.Text = "";
                textBox13.Text = "";
            }
            else
            {
                textBox14.Text = gridView8.GetRowCellValue( e.FocusedRowHandle, "PQH01" ).ToString( );
                comboBox40.Text = gridView8.GetRowCellValue( e.FocusedRowHandle, "PQH02" ).ToString( );
                comboBox39.Text = gridView8.GetRowCellValue( e.FocusedRowHandle, "PQH03" ).ToString( );
                comboBox38.Text = gridView8.GetRowCellValue( e.FocusedRowHandle, "PQH04" ).ToString( );
                comboBox37.Text = gridView8.GetRowCellValue( e.FocusedRowHandle, "PQH05" ).ToString( );
                comboBox36.Text = gridView8.GetRowCellValue( e.FocusedRowHandle, "PQH06" ).ToString( );
                textBox13.Text = gridView8.GetRowCellValue( e.FocusedRowHandle, "PQH07" ).ToString( );
                PH2 = comboBox40.Text;
                PH3 = comboBox39.Text;
                PH4 = comboBox38.Text;
                PH5 = comboBox37.Text;
                if (comboBox36.Text == "")
                {
                    PH6 = 0;
                }
                else
                {
                    PH6 = Convert.ToInt32( comboBox36.Text );
                }
                if (textBox13.Text == "")
                {
                    PH7 = 0;
                }
                else
                {
                    PH7 = Convert.ToDecimal( textBox13.Text );
                }
            }          
        }

        //DEL
        private void button22_Click( object sender, EventArgs e )
        {
            int num = gridView8.FocusedRowHandle;
            if (dh.Rows.Count < 1)
            {
                MessageBox.Show( "没有数据,无法删除" );
            }
            else
            {
                int count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQH WHERE PQH02=@PH2 AND PQH03=@PH3 AND PQH04=@PH4 AND PQH05=@PH5 AND PQH06=@PH6 AND PQH07=@PH7", new SqlParameter( "@PH2", PH2 ), new SqlParameter( "@PH3", PH3 ), new SqlParameter( "@PH4", PH4 ), new SqlParameter( "@PH5", PH5 ), new SqlParameter( "@PH6", PH6 ), new SqlParameter( "@PH7", PH7 ) );            
                if (count < 1)
                {
                    MessageBox.Show( "删除失败" );
                }
                else
                {
                    MessageBox.Show( "删除成功" );
                    dh.Rows.RemoveAt( num );
                }
            }
        }
        //UPDATE
        private void button23_Click( object sender, EventArgs e )
        {
            int num = gridView8.FocusedRowHandle;
            if (dh.Rows.Count < 1)
            {
                MessageBox.Show( "没有数据,无法编辑" );
            }
            else
            {
                PQH001 = textBox14.Text;
                PQH002 = comboBox40.Text;
                PQH003 = comboBox39.Text;
                PQH004 = comboBox38.Text;
                PQH005 = comboBox37.Text;
                if (comboBox36.Text == "")
                {
                    PQH006 = 0;
                }
                else
                {
                    PQH006 = Convert.ToInt32( comboBox36.Text );
                }
                if (textBox13.Text == "")
                {
                    PQH007 = 0M;
                }
                else
                {
                    PQH007 = Convert.ToDecimal( textBox13.Text );
                }
                
                DataRow dr = dh.Rows[num];
                dr.BeginEdit( );
                dr["PQH01"] = PQH001;
                dr["PQH02"] = PQH002;
                dr["PQH03"] = PQH003;
                dr["PQH04"] = PQH004;
                dr["PQH05"] = PQH005;
                dr["PQH06"] = PQH006;
                dr["PQH07"] = PQH007;
                dr.EndEdit( );               

                int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQH SET PQH02=@PQH02,PQH03=@PQH03,PQH04=@PQH04,PQH05=@PQH05,PQH06=@PQH06,PQH07=@PQH07 WHERE PQH02=@PH2 AND PQH03=@PH3 AND PQH04=@PH4 AND PQH05=@PH5 AND PQH06=@PH6 AND PQH07=@PH7", new SqlParameter( "@PQH02", PQH002 ), new SqlParameter( "@PQH03", PQH003 ), new SqlParameter( "@PQH04", PQH004 ), new SqlParameter( "@PQH05", PQH005 ), new SqlParameter( "@PQH06", PQH006 ), new SqlParameter( "@PQH07", PQH007 ), new SqlParameter( "@PH2", PH2 ), new SqlParameter( "@PH3", PH3 ), new SqlParameter( "@PH4", PH4 ), new SqlParameter( "@PH5", PH5 ), new SqlParameter( "@PH6", PH6 ), new SqlParameter( "@PH7", PH7 ) );
                if (count < 1)
                {
                    MessageBox.Show( "更新失败" );
                }
                else
                {
                    MessageBox.Show( "更新成功" );
                }
            }
        }
        //ADD
        private void button24_Click( object sender, EventArgs e )
        {
            DataRow dr = dh.NewRow();
            PQH001 = textBox14.Text;
            PQH002 = comboBox40.Text;
            PQH003 = comboBox39.Text;
            PQH004 = comboBox38.Text;
            PQH005 = comboBox37.Text;
            if (comboBox36.Text == "")
            {
                PQH006 = 0;
            }
            else
            {
                PQH006 = Convert.ToInt32( comboBox36.Text );
            }
            if (textBox13.Text == "")
            {
                PQH007 = 0M;
            }
            else
            {
                PQH007 = Convert.ToDecimal( textBox13.Text );
            }

            dr["PQH01"] = PQH001;
            dr["PQH02"] = PQH002;
            dr["PQH03"] = PQH003;
            dr["PQH04"] = PQH004;
            dr["PQH05"] = PQH005;
            dr["PQH06"] = PQH006;
            dr["PQH07"] = PQH007;
            

            int count = SqlHelper.ExecuteNonQuery("INSERT INTO R_PQH VALUES (@PQH01,@PQH02,@PQH03,@PQH04,@PQH05,@PQH06,@PQH07)", new SqlParameter("@PQH01", PQH001), new SqlParameter("@PQH02", PQH002), new SqlParameter("@PQH03", PQH003), new SqlParameter("@PQH04", PQH004), new SqlParameter("@PQH05", PQH005), new SqlParameter("@PQH06", PQH006), new SqlParameter("@PQH07", PQH007));
            if (count < 1)
            {
                MessageBox.Show("录入失败");
            }
            else
            {
                MessageBox.Show("录入成功");
                dh.Rows.Add( dr );
            }
        }
        #endregion

        #region R_PQJ 浸漆
        string PQJ001 = "", PQJ002 = "", PQJ003 = "", PQJ004 = "", PQJ005 = "", PJ2 = "", PJ3 = "", PJ4 = "", PJ5 = "";
        int PQJ006 = 0, PJ6 = 0;
        Decimal PQJ007 = 0M, PJ7 = 0M;
        //ROWCHANGED
        private void gridView9_FocusedRowChanged( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
            if (gridView9.RowCount < 1)
            {
                textBox15.Text = "";
                comboBox44.Text = "";
                comboBox43.Text = "";
                comboBox42.Text = "";
                comboBox41.Text = "";
                comboBox35.Text = "";
                textBox16.Text = "";
            }
            else
            {
                textBox15.Text = gridView9.GetRowCellValue( e.FocusedRowHandle, "PQJ01" ).ToString( );
                comboBox44.Text = gridView9.GetRowCellValue( e.FocusedRowHandle, "PQJ02" ).ToString( );
                comboBox43.Text = gridView9.GetRowCellValue( e.FocusedRowHandle, "PQJ03" ).ToString( );
                comboBox42.Text = gridView9.GetRowCellValue( e.FocusedRowHandle, "PQJ04" ).ToString( );
                comboBox41.Text = gridView9.GetRowCellValue( e.FocusedRowHandle, "PQJ05" ).ToString( );
                comboBox35.Text = gridView9.GetRowCellValue( e.FocusedRowHandle, "PQJ06" ).ToString( );
                textBox16.Text = gridView9.GetRowCellValue( e.FocusedRowHandle, "PQJ07" ).ToString( );
                PJ2 = comboBox44.Text;
                PJ3 = comboBox43.Text;
                PJ4 = comboBox42.Text;
                PJ5 = comboBox41.Text;
                if (comboBox35.Text == "")
                {
                    PJ6 = 0;
                }
                else
                {
                    PJ6 = Convert.ToInt32( comboBox35.Text );
                }
                if (textBox16.Text == "")
                {
                    PJ7 = 0M;
                }
                else
                {
                    PJ7 = Convert.ToDecimal( textBox16.Text );
                }   
            }        
        }
        //DEL
        private void button25_Click( object sender, EventArgs e )
        {
            int num = gridView9.FocusedRowHandle;
            if (djj.Rows.Count < 1)
            {
                MessageBox.Show( "没有数据,无法删除" );
            }
            else
            {
                int count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQJ WHERE PQJ02=@PJ2 AND PQJ03=@PJ3 AND PQJ04=@PJ4 AND PQJ05=@PJ5 AND PQJ06=@PJ6 AND PQJ07=@PJ7", new SqlParameter( "@PJ2", PJ2 ), new SqlParameter( "@PJ3", PJ3 ), new SqlParameter( "@PJ4", PJ4 ), new SqlParameter( "@PJ5", PJ5 ), new SqlParameter( "@PJ6", PJ6 ), new SqlParameter( "@PJ7", PJ7 ) ); 
                if (count < 1)
                {
                    MessageBox.Show( "删除失败" );
                }
                else
                {
                    MessageBox.Show( "删除成功" );
                    djj.Rows.RemoveAt( num );
                }
            }
        }
        //UPDATE
        private void button26_Click( object sender, EventArgs e )
        {
            int num = gridView9.FocusedRowHandle;
            if (djj.Rows.Count < 1)
            {
                MessageBox.Show( "没有数据,无法编译" );
            }
            else
            {
                PQJ001 = textBox15.Text;
                PQJ002 = comboBox44.Text;
                PQJ003 = comboBox43.Text;
                PQJ004 = comboBox42.Text;
                PQJ005 = comboBox41.Text;
                if (comboBox35.Text == "")
                {
                    PQJ006 = 0;
                }
                else
                {
                    PQJ006 = Convert.ToInt32( comboBox35.Text );
                }
                if (textBox16.Text == "")
                {
                    PQJ007 = 0M;
                }
                else
                {
                    PQJ007 = Convert.ToDecimal( textBox16.Text );
                }
                DataRow dr = djj.Rows[num];
                dr.BeginEdit( );
                dr["PQJ01"] = PQJ001;
                dr["PQJ02"] = PQJ002;
                dr["PQJ03"] = PQJ003;
                dr["PQJ04"] = PQJ004;
                dr["PQJ05"] = PQJ005;
                dr["PQJ06"] = PQJ006;
                dr["PQJ07"] = PQJ007;
                dr.EndEdit( );

                int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQJ SET PQJ02=@PQJ02,PQJ03=@PQJ03,PQJ04=@PQJ04,PQJ05=@PQJ05,PQJ06=@PQJ06,PQJ07=@PQJ07 WHERE PQJ02=@PJ2 AND PQJ03=@PJ3 AND PQJ04=@PJ4 AND PQJ05=@PJ5 AND PQJ06=@PJ6 AND PQJ07=@PJ7", new SqlParameter( "@PQJ02", PQJ002 ), new SqlParameter( "@PQJ03", PQJ003 ), new SqlParameter( "@PQJ04", PQJ004 ), new SqlParameter( "@PQJ05", PQJ005 ), new SqlParameter( "@PQJ06", PQJ006 ), new SqlParameter( "@PQJ07", PQJ007 ), new SqlParameter( "@PJ2", PJ2 ), new SqlParameter( "@PJ3", PJ3 ), new SqlParameter( "@PJ4", PJ4 ), new SqlParameter( "@PJ5", PJ5 ), new SqlParameter( "@PJ6", PJ6 ), new SqlParameter( "@PJ7", PJ7 ) );
                if (count < 1)
                {
                    MessageBox.Show( "更新失败" );
                }
                else
                {
                    MessageBox.Show( "更新成功" );
                }
            }
        }
        //ADD
        private void button27_Click( object sender, EventArgs e )
        {
            DataRow dr = djj.NewRow();
            PQJ001 = textBox15.Text;
            PQJ002 = comboBox44.Text;
            PQJ003 = comboBox43.Text;
            PQJ004 = comboBox42.Text;
            PQJ005 = comboBox41.Text;
            if (comboBox35.Text == "")
            {
                PQJ006 = 0;
            }
            else
            {
                PQJ006 = Convert.ToInt32( comboBox35.Text );
            }
            if (textBox16.Text == "")
            {
                PQJ007 = 0M;
            }
            else
            {
                PQJ007 = Convert.ToDecimal( textBox16.Text );
            }
            dr["PQJ01"] = PQJ001;
            dr["PQJ02"] = PQJ002;
            dr["PQJ03"] = PQJ003;
            dr["PQJ04"] = PQJ004;
            dr["PQJ05"] = PQJ005;
            dr["PQJ06"] = PQJ006;
            dr["PQJ07"] = PQJ007;
            

            int count = SqlHelper.ExecuteNonQuery("INSERT INTO R_PQJ VALUES (@PQJ01,@PQJ02,@PQJ03,@PQJ04,@PQJ05,@PQJ06,@PQJ07)", new SqlParameter("@PQJ01", PQJ001), new SqlParameter("@PQJ02", PQJ002), new SqlParameter("@PQJ03", PQJ003), new SqlParameter("@PQJ04", PQJ004), new SqlParameter("@PQJ05", PQJ005), new SqlParameter("@PQJ06", PQJ006), new SqlParameter("@PQJ07", PQJ007));
            if (count < 1)
            {
                MessageBox.Show("录入失败");
            }
            else
            {
                MessageBox.Show("录入成功");
                djj.Rows.Add( dr );
            }
        }
        #endregion
    }
}

using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Data;
using System . Data . SqlClient;
using System . Drawing;
using System . Linq;
using System . Text;
using System . Windows . Forms;
using StudentMgr;
using Mulaolao . Class;

namespace Mulaolao.Other
{
    public partial class Review : Form
    {
        public Review(Form1 fm)
        {
            this.MdiParent = fm;
            InitializeComponent();

            //GridViewMoHuSelect . SetFilter ( gridView1 );
            //GridViewMoHuSelect . SetFilter ( gridView1 );
            //GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { this . gridView1,this.gridView2,this.gridView3 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        string num = "", name = "", CX01 = "",RE001="",RE002="",RE0001="";
        DataTable dt, dl, dx;
        private void Review_Load(object sender, EventArgs e)
        {
            
            DataTable de = SqlHelper.ExecuteDataTable("SELECT CX01,CX02 FROM R_MLLCXMC");
            comboBox1.DataSource = de;
            comboBox1.DisplayMember = "CX01";
            comboBox1.ValueMember = "CX02";
            
            DataTable dte = SqlHelper.ExecuteDataTable("SELECT DBA001,DBA002 FROM TPADBA");
            comboBox2.DataSource = dte;
            comboBox2.DisplayMember = "DBA002";
            comboBox2.ValueMember = "DBA001";           
        }
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                textBox1.Text = comboBox1.SelectedValue.ToString( );
            }
            
            dt = SqlHelper.ExecuteDataTable( "SELECT DBB001, DBA002 FROM R_DBB A, TPADBA B, R_MLLCXMC C WHERE A.DBB001 = B.DBA001 AND A.DBB002 = C.CX01 AND CX01 = @CX01", new SqlParameter("@CX01", comboBox1.Text));
            gridControl2.DataSource = dt;
            dx = SqlHelper.ExecuteDataTable( "SELECT RE01,DBA002  FROM R_REVIEW A,TPADBA B,R_MLLCXMC C WHERE A.RE01=B.DBA001 AND A.RE02=C.CX01 AND CX01=@CX01", new SqlParameter( "@CX01", comboBox1.Text ) );
            gridControl1.DataSource = dx;
        }
        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text != "")
            {
                textBox2.Text = comboBox2.SelectedValue.ToString( );
            }

            dl = SqlHelper.ExecuteDataTable( "SELECT RE02,CX02,RE01,DBA002,DAA002 FROM R_REVIEW A,R_MLLCXMC B,TPADBA C,TPADAA D WHERE A.RE02=B.CX01 AND A.RE01=C.DBA001 AND C.DBA005=D.DAA001 AND RE01=@RE01", new SqlParameter( "@RE01", textBox2.Text ) );
            gridControl3.DataSource = dl;
        }

        private void gridView2_FocusedRowChanged_1( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
            if (gridView2.RowCount > 0)
            {
                if (e.FocusedRowHandle>=gridView2.RowCount)
                {
                    num = gridView2.GetRowCellValue( 0, "DBB001" ).ToString( );
                    name = gridView2.GetRowCellValue( 0, "DBA002" ).ToString( );
                }
                else
                {
                    num = gridView2.GetRowCellValue( e.FocusedRowHandle, "DBB001" ).ToString( );
                    name = gridView2.GetRowCellValue( e.FocusedRowHandle, "DBA002" ).ToString( );
                }                
            }
        }
        private void gridView2_Click( object sender, EventArgs e )
        {
            if (gridView2.RowCount == 1)
            {
                num = gridView2.GetFocusedRowCellValue( "DBB001" ).ToString( );
                name = gridView2.GetFocusedRowCellValue( "DBA002" ).ToString( );
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RE002 = comboBox1.Text;
            SqlHelper.ExecuteNonQuery( "DELETE FROM R_REVIEW WHERE RE01 = @RE01 AND RE02=@RE02", new SqlParameter( "@RE01", RE001 ), new SqlParameter( "@RE02", RE002 ) );

            int count = gridView1.FocusedRowHandle;           
            dx.Rows.RemoveAt(count);  
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.RowCount < 1)
            {
                RE001 = "";
            }
            else
            {
                if (e.FocusedRowHandle >= gridView1.RowCount)
                {
                    RE001 = gridView1.GetRowCellValue( 0, "RE01" ).ToString( );
                }
                else
                {
                    RE001 = gridView1.GetRowCellValue( e.FocusedRowHandle, "RE01" ).ToString( );
                }             
            }
        }
        private void gridView1_Click( object sender, EventArgs e )
        {
            if (gridView1.RowCount == 1)
            {
                RE001 = gridView1.GetFocusedRowCellValue( "RE01" ).ToString( );
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (gridView2.FocusedRowHandle < 0)
            {
                MessageBox.Show( "不明确送审人员" );
            }
            else
            {
                string RE01 = comboBox1.Text;
                SqlHelper.ExecuteNonQuery( "INSERT INTO R_REVIEW (RE01,RE02) VALUES (@RE01,@RE02)", new SqlParameter( "@RE01", num ), new SqlParameter( "@RE02", comboBox1.Text ) );

                DataRow dr = dx.NewRow( );
                dr["RE01"] = num;
                dr["DBA002"] = name;
                dx.Rows.Add( dr );
            }
        }
    }
}

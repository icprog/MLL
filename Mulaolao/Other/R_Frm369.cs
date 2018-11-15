using System;
using System . Windows . Forms;
using Mulaolao . Class;

namespace Mulaolao . Base
{
    public partial class R_Frm369 : Form
    {
        public R_Frm369( )
        {
            InitializeComponent( );
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        public delegate void PassDataBetweenFormHandler( object sender, PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        public string r369 = "";
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "";

        private void R_Frm369_Load( object sender, EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );

            if ( r369 == "1" )
            {
                this.gridView1.Columns["KH01"].Visible = true;
                this.gridView1.Columns["KH49"].Visible = true;
                this.gridView1.Columns["KH50"].Visible = true;
                this.gridView1.Columns["KH24"].Visible = false;
                this.gridView1.Columns["CP001"].Visible = false;
                this.gridView1.Columns["PQF04"].Visible = false;
                this.gridView1.Columns["PQF01"].Visible = false;
                this.gridView1.Columns["PQF02"].Visible = false;
                this.gridView1.Columns["PQF03"].Visible = false;
                this.gridView1.Columns["PQF06"].Visible = false;
                this.gridView1.Columns["PQF07"].Visible = false;
                this.gridView1.Columns["PQF08"].Visible = false;
            }
            else if ( r369 == "2" )
            {
                this.gridView1.Columns["KH01"].Visible = false;
                this.gridView1.Columns["KH49"].Visible = false;
                this.gridView1.Columns["KH50"].Visible = false;
                this.gridView1.Columns["KH24"].Visible = false;
                this.gridView1.Columns["CP001"].Visible = true;
                this.gridView1.Columns["PQF04"].Visible = true;
                this.gridView1.Columns["PQF01"].Visible = false;
                this.gridView1.Columns["PQF02"].Visible = false;
                this.gridView1.Columns["PQF03"].Visible = false;
                this.gridView1.Columns["PQF06"].Visible = false;
                this.gridView1.Columns["PQF07"].Visible = false;
                this.gridView1.Columns["PQF08"].Visible = false;
            }
            else if ( r369 == "3" )
            {
                this.gridView1.Columns["PQF01"].Visible = true;
                this.gridView1.Columns["PQF02"].Visible = true;
                this.gridView1.Columns["PQF03"].Visible = true;
                this.gridView1.Columns["PQF04"].Visible = true;
                this.gridView1.Columns["PQF06"].Visible = true;
                this.gridView1.Columns["PQF07"].Visible = true;
                this.gridView1.Columns["PQF08"].Visible = true;
                this.gridView1.Columns["KH01"].Visible = false;
                this.gridView1.Columns["KH49"].Visible = false;
                this.gridView1.Columns["KH50"].Visible = false;
                this.gridView1.Columns["KH24"].Visible = false;
                this.gridView1.Columns["CP001"].Visible = false;
            }
        }

        private void gridView1_DoubleClick( object sender, EventArgs e )
        {
            if ( r369 == "1" )
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"KH01" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"KH49" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"KH50" ).ToString( );
            }
            else if ( r369 == "2" )
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"CP001" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF04" ).ToString( );
            }
            else if ( r369 == "3" )
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF01" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF02" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF03" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF04" ).ToString( );
                cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF06" ).ToString( );
                cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF07" ).ToString( );
                cn7 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF08" ).ToString( );
            }
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 );
            if (PassDataBetweenForm != null)
            {
                PassDataBetweenForm( this, args );
            }
            this.Close( );
        }


        private void gridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( Logins.number != "MLL-0001" )
                return;
            if ( gridView1.FocusedRowHandle >= 0 )
            {
                if ( r369 == "3" )
                {
                    int num = gridView1.FocusedRowHandle;
                    if ( gridView1.GetDataRow( num )["check"].ToString( ) == "True" )
                        gridView1.GetDataRow( num )["check"] = false;
                    else
                        gridView1.GetDataRow( num )["check"] = true;
                }
            }
        }
        int count = 0;
        private void gridView1_KeyDown ( object sender ,KeyEventArgs e )
        {
            if ( Logins.number != "MLL-0001" )
                return;
            //按Enter键   确认是否合并
            if ( e.KeyCode == Keys.Enter )
            {
                for ( int k = 0 ; k < gridView1.RowCount ; k++ )
                {
                    if ( gridView1.GetDataRow( k )["check"].ToString( ) == "True" )
                        count++;
                }
                cn1 = cn2 = cn3 = cn4 = cn5 = cn6 = cn7 = "";
                if ( r369 == "3" )
                {
                    ergodic( );
                }
                else
                    MessageBox.Show( "本合同不做合并操作" );
            }
            else
                MessageBox.Show( "请按Enter键确认是否合并" );
        }
        void ergodic ( )
        {
            if ( count > 1 )
            {
                long sum = 0;
                if ( MessageBox.Show( "确定合并？" ,"数据合并" ,MessageBoxButtons.OKCancel ) == DialogResult.OK )
                {
                    for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                    {
                        if ( gridView1.GetDataRow( i )["check"].ToString( ) == "True" )
                        {
                            if ( cn1 == "" )
                                cn1 = gridView1.GetRowCellValue( i ,"PQF01" ).ToString( );
                            else
                                cn1 = cn1 + "," + gridView1.GetRowCellValue( i ,"PQF01" ).ToString( );
                            if ( cn2 == "" )
                                cn2 = gridView1.GetRowCellValue( i ,"PQF02" ).ToString( );
                            else
                                cn2 = cn2 + "," + gridView1.GetRowCellValue( i ,"PQF02" ).ToString( );
                            if ( cn3 == "" )
                                cn3 = gridView1.GetRowCellValue( i ,"PQF03" ).ToString( );
                            else
                                cn3 = cn3 + "," + gridView1.GetRowCellValue( i ,"PQF03" ).ToString( );
                            if ( cn4 == "" )
                                cn4 = gridView1.GetRowCellValue( i ,"PQF04" ).ToString( );
                            else
                                cn4 = cn4 + "," + gridView1.GetRowCellValue( i ,"PQF04" ).ToString( );
                            if ( cn6 == "" )
                                cn6 = gridView1.GetRowCellValue( i ,"PQF07" ).ToString( );
                            else
                                cn6 = cn6 + "," + gridView1.GetRowCellValue( i ,"PQF07" ).ToString( );
                            if ( cn7 == "" )
                                cn7 = gridView1.GetRowCellValue( i ,"PQF08" ).ToString( );
                            else
                                cn7 = cn7 + "," + gridView1.GetRowCellValue( i ,"PQF08" ).ToString( );
                            sum = sum + Convert.ToInt64( gridView1.GetRowCellValue( i ,"PQF06" ) );
                        }
                    }
                    cn5 = sum.ToString( );
                    PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 );
                    if ( PassDataBetweenForm != null )
                        PassDataBetweenForm( this ,args );
                    this.Close( );
                }
            }
            else
                MessageBox.Show( "请至少选择两项合并" );
        }
    }
}

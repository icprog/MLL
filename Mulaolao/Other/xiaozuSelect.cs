using System;
using System . Windows . Forms;
using Mulaolao . Class;

namespace Mulaolao . Wages
{
    public partial class xiaozuSelect : Form
    {
        public xiaozuSelect( )
        {
            InitializeComponent();
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        public delegate void PassDataBetweenFormHandler( object sender, PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        public string xizu = "";
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "", cn8 = "", cn9 = "", cn10 = "", cn11 = "";

        private void xiaozuSelect_Load( object sender, EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
            gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;

            if (xizu == "1")
            {
                gridView1.Columns["PQF03"].Visible = false;
                gridView1.Columns["GZ02"].Visible = true;
                gridView1.Columns["GZ29"].Visible = true;
                gridView1.Columns["GZ01"].Visible = true;
                gridView1.Columns["GZ22"].Visible = true;
                gridView1.Columns["GZ23"].Visible = true;
                gridView1.Columns["RES05"].Visible = true;
                gridView1.Columns["PQX04"].Visible = false;
                gridView1.Columns["DBA2"].Visible = false;
                gridView1.Columns["DBA3"].Visible = false;
                gridView1.Columns["PQF06"].Visible = false;
                gridView1.Columns["PQF31"].Visible = false;
                gridView1.Columns["PQX01"].Visible = false;
                gridView1.Columns["PQX29"].Visible = false;
                gridView1.Columns["PQX30"].Visible = false;
                gridView1.Columns["PQX31"].Visible = false;
                gridView1.Columns["PQX32"].Visible = false;
                gridView1.Columns["PQX33"].Visible = false;
                gridView1.Columns["PQF01"].Visible = false;
                gridView1.Columns["PQF04"].Visible = false;
            }
            else if (xizu == "2")
            {
                gridView1.Columns["PQF03"].Visible = true;
                gridView1.Columns["PQF01"].Visible = true;
                gridView1.Columns["PQF04"].Visible = true;
                gridView1.Columns["GZ02"].Visible = false;
                gridView1.Columns["GZ29"].Visible = false;
                gridView1.Columns["GZ01"].Visible = false;
                gridView1.Columns["GZ22"].Visible = false;
                gridView1.Columns["GZ23"].Visible = false;
                gridView1.Columns["RES05"].Visible = false;
                gridView1.Columns["PQX04"].Visible = false;
                gridView1.Columns["DBA2"].Visible = false;
                gridView1.Columns["DBA3"].Visible = false;
                gridView1.Columns["PQF06"].Visible = true;
                gridView1.Columns["PQF31"].Visible = false;
                gridView1.Columns["PQX01"].Visible = false;
                gridView1.Columns["PQX29"].Visible = false;
                gridView1.Columns["PQX30"].Visible = false;
                gridView1.Columns["PQX31"].Visible = false;
                gridView1.Columns["PQX32"].Visible = false;
                gridView1.Columns["PQX33"].Visible = false;
            }
            else if (xizu == "3")
            {
                gridView1.Columns["PQX01"].Visible = true;
                gridView1.Columns["PQX29"].Visible = true;
                gridView1.Columns["PQX30"].Visible = true;
                gridView1.Columns["PQX31"].Visible = true;
                gridView1.Columns["PQX32"].Visible = true;
                gridView1.Columns["PQX33"].Visible = true;
                gridView1.Columns["PQX04"].Visible = true;
                gridView1.Columns["DBA2"].Visible = true;
                gridView1.Columns["DBA3"].Visible = true;
                gridView1.Columns["PQF03"].Visible = false;
                gridView1.Columns["PQF04"].Visible = false;
                gridView1.Columns["PQF01"].Visible = false;
                gridView1.Columns["GZ02"].Visible = false;
                gridView1.Columns["GZ29"].Visible = false;
                gridView1.Columns["GZ01"].Visible = false;
                gridView1.Columns["GZ22"].Visible = false;
                gridView1.Columns["GZ23"].Visible = false;
                gridView1.Columns["RES05"].Visible = false;
                gridView1.Columns["PQF06"].Visible = false;
                gridView1.Columns["PQF31"].Visible = false;             
            }
        }
        private void gridView1_DoubleClick( object sender, EventArgs e )
        {
            if (xizu == "1")
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"GZ22" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"GZ01" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"GZ02" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"GZ23" ).ToString( );
                cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"GZ29" ).ToString( );
                cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"RES05" ).ToString( );
            }
            else if (xizu == "2")
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF04" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF03" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF01" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF06" ).ToString( );
            }
            else if (xizu == "3")
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQX29" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQX01" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQX04" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"DBA2" ).ToString( );
                cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"DBA3" ).ToString( );
                cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQX31" ).ToString( );
                cn7 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQX32" ).ToString( );
                cn8 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQX30" ).ToString( );
                cn9 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQX02" ).ToString( );
                cn10 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQX03" ).ToString( );
                cn11 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQX33" ).ToString( );
            }
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 ,cn8 ,cn9 ,cn10 ,cn11 );
            if (PassDataBetweenForm != null)
            {
                PassDataBetweenForm( this, args );
            }
            this.Close( );
        }

        int count = 0;       
        private void gridView1_Click ( object sender ,EventArgs e )
        {
            if ( gridView1.FocusedRowHandle >= 0 )
            {
                if ( xizu == "2" )
                {
                    int num = gridView1.FocusedRowHandle;
                    if ( gridView1.GetDataRow( num )["check"].ToString( ) == "True" )
                    {
                        gridView1.GetDataRow( num )["check"] = false;
                    }
                    else
                    {
                        gridView1.GetDataRow( num )["check"] = true;
                    }
                }
            }
            
        }
        private void gridView1_KeyDown ( object sender ,KeyEventArgs e )
        {
            if ( e.KeyCode == Keys.Enter )
            {
                if ( xizu == "2" )
                {
                    for ( int k = 0 ; k < gridView1.RowCount ; k++ )
                    {
                        if ( gridView1.GetDataRow( k )["check"].ToString() == "True" )
                            count++;
                    }
                    cn1 = cn2 = cn3 = "";
                    if ( count > 1 )
                    {
                        if ( MessageBox.Show( "确认合并？" ,"合并" ,MessageBoxButtons.OKCancel ) == DialogResult.OK )
                        {                       
                            for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                            {
                                if ( gridView1.GetDataRow( i )["check"].ToString( ) == "True" )
                                {
                                    if ( string.IsNullOrEmpty( cn1 ) )
                                        cn1 = gridView1.GetRowCellValue(i, "PQF04" ).ToString( );
                                    else
                                        cn1 = cn1 + "," + gridView1.GetRowCellValue(i, "PQF04" ).ToString( );
                                    if ( string.IsNullOrEmpty( cn2 ) )
                                        cn2 = gridView1.GetRowCellValue(i, "PQF01" ).ToString( );
                                    else
                                        cn2 = cn2 + "," + gridView1.GetRowCellValue(i, "PQF01" ).ToString( );
                                    if ( string.IsNullOrEmpty( cn3 ) )
                                        cn3 = gridView1.GetRowCellValue(i, "PQF03" ).ToString( );
                                    else
                                        cn3 = cn3 + "," + gridView1.GetRowCellValue(i, "PQF03" ).ToString( );
                                }
                            }
                            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 );
                            if ( PassDataBetweenForm != null )
                            {
                                PassDataBetweenForm( this ,args );
                            }
                            this.Close( );
                        }
                    }
                    else
                        MessageBox.Show( "请至少选择两项合并" );
                }
            }
            else
                MessageBox.Show( "请按Enter键合并项" );
        }
    }
}

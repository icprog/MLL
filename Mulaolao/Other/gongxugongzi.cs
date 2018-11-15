using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mulaolao.Class;

namespace Mulaolao.Raw_material_cost
{
    public partial class gongxugongzi : Form
    {
        public gongxugongzi( )
        {
            InitializeComponent();
        }
        public delegate void PassDataBetweenFormHandler( object sender, PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        public string gonxu = "";
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "", cn8 = "";
        private void gongxugongzi_Load( object sender, EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
            gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;

            if (gonxu == "1")
            {
                this.gridView1.Columns["DS01"].Visible = true;
                this.gridView1.Columns["DS21"].Visible = true;
                this.gridView1.Columns["DS22"].Visible = true;
                this.gridView1.Columns["DS24"].Visible = true;
                this.gridView1.Columns["DS25"].Visible = true;
                this.gridView1.Columns["DS26"].Visible = true;
                this.gridView1.Columns["DS27"].Visible = true;
                this.gridView1.Columns["RES05"].Visible = true;
                this.gridView1.Columns["PQF01"].Visible = false;           
                this.gridView1.Columns["PQF03"].Visible = false;
                this.gridView1.Columns["PQF04"].Visible = false;
                this.gridView1.Columns["PQF06"].Visible = false;
                this.gridView1.Columns["DAA002"].Visible = false;
                this.gridView1.Columns["PQF31"].Visible = false;
                this.gridView1.Columns["GS35"].Visible = false;
                this.gridView1.Columns["GS36"].Visible = false;
                this.gridView1.Columns["U0"].Visible = false;
                this.gridView1.Columns["GZ06"].Visible = false;
                this.gridView1.Columns["U1"].Visible = false;
            }
            else if (gonxu == "2")
            {
                this.gridView1.Columns["PQF01"].Visible = true;
                this.gridView1.Columns["DS01"].Visible = false;
                this.gridView1.Columns["PQF03"].Visible = true;
                this.gridView1.Columns["PQF04"].Visible = true;
                this.gridView1.Columns["PQF06"].Visible = true;
                this.gridView1.Columns["DAA002"].Visible = true;
                this.gridView1.Columns["PQF31"].Visible = true;
                this.gridView1.Columns["GS35"].Visible = false;
                this.gridView1.Columns["GS36"].Visible = false;
                this.gridView1.Columns["U0"].Visible = false;
                this.gridView1.Columns["GZ06"].Visible = false;
                this.gridView1.Columns["U1"].Visible = false;
                this.gridView1.Columns["DS21"].Visible = false;
                this.gridView1.Columns["DS22"].Visible = false;
                this.gridView1.Columns["DS24"].Visible = false;
                this.gridView1.Columns["DS25"].Visible = false;
                this.gridView1.Columns["DS26"].Visible = false;
                this.gridView1.Columns["DS27"].Visible = false;
                this.gridView1.Columns["RES05"].Visible = false;
            }
            else if (gonxu == "3")
            {
                this.gridView1.Columns["PQF01"].Visible = false;
                this.gridView1.Columns["DS01"].Visible = false;
                this.gridView1.Columns["PQF03"].Visible = false;
                this.gridView1.Columns["PQF04"].Visible = false;
                this.gridView1.Columns["PQF06"].Visible = false;
                this.gridView1.Columns["DAA002"].Visible = false;
                this.gridView1.Columns["PQF31"].Visible = false;
                this.gridView1.Columns["GS35"].Visible = true;
                this.gridView1.Columns["GS36"].Visible = true;
                this.gridView1.Columns["U0"].Visible = false;
                this.gridView1.Columns["GZ06"].Visible = false;
                this.gridView1.Columns["U1"].Visible = false;
                this.gridView1.Columns["DS21"].Visible = false;
                this.gridView1.Columns["DS22"].Visible = false;
                this.gridView1.Columns["DS24"].Visible = false;
                this.gridView1.Columns["DS25"].Visible = false;
                this.gridView1.Columns["DS26"].Visible = false;
                this.gridView1.Columns["DS27"].Visible = false;
                this.gridView1.Columns["RES05"].Visible = false;
            }
            else if (gonxu == "4")
            {
                this.gridView1.Columns["PQF01"].Visible = false;
                this.gridView1.Columns["DS01"].Visible = false;
                this.gridView1.Columns["PQF03"].Visible = false;
                this.gridView1.Columns["PQF04"].Visible = false;
                this.gridView1.Columns["PQF06"].Visible = false;
                this.gridView1.Columns["DAA002"].Visible = false;
                this.gridView1.Columns["PQF31"].Visible = false;
                this.gridView1.Columns["GS35"].Visible = false;
                this.gridView1.Columns["GS36"].Visible = false;
                this.gridView1.Columns["U0"].Visible = true;
                this.gridView1.Columns["GZ06"].Visible = true;
                this.gridView1.Columns["U1"].Visible = true;
                this.gridView1.Columns["DS21"].Visible = false;
                this.gridView1.Columns["DS22"].Visible = false;
                this.gridView1.Columns["DS24"].Visible = false;
                this.gridView1.Columns["DS25"].Visible = false;
                this.gridView1.Columns["DS26"].Visible = false;
                this.gridView1.Columns["DS27"].Visible = false;
                this.gridView1.Columns["RES05"].Visible = false;
            }
        }
        private void gridView1_DoubleClick( object sender, EventArgs e )
        {
            if (gonxu == "1")
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"DS22" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"DS01" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"DS24" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"DS25" ).ToString( );
                cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"DS26" ).ToString( );
                cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"DS27" ).ToString( );
                cn7 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"DS21" ).ToString( );
                cn8 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"RES05" ).ToString( );
            }
            else if (gonxu == "2")
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF04" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF01" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF03" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF06" ).ToString( );
                cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "DAA002" ).ToString( );
                cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF31" ).ToString( );
            }
            else if (gonxu == "3")
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "GS35" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "GS36" ).ToString( );
            }
            else if (gonxu == "4")
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "U0" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "GZ06" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "U1" ).ToString( );
            }
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 ,cn8 );
            if (PassDataBetweenForm != null)
            {
                PassDataBetweenForm( this, args );
            }
            this.Close( );
        }
        long sum = 0; int count = 0;
        private void gridView1_KeyDown ( object sender ,KeyEventArgs e )
        {
            if ( e.KeyCode == Keys.Enter )
            {
                if ( gonxu == "2" )
                {
                    for ( int k = 0 ; k < gridView1.RowCount ; k++ )
                    {
                        if ( gridView1.GetDataRow( k )["check"].ToString( ) == "True" )
                            count++;
                    }
                    cn1 = cn2 = cn3 = cn4 = cn5 = cn6 = "";
                    if ( count > 1 )
                    {
                        if ( MessageBox.Show( "确认合并？" ,"合并" ,MessageBoxButtons.OKCancel ) == DialogResult.OK )
                        {
                            for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                            {
                                if ( gridView1.GetDataRow( i )["check"].ToString( ) == "True" )
                                {
                                    if ( string.IsNullOrEmpty( cn1 ) )
                                        cn1 = gridView1.GetRowCellValue( i ,"PQF04" ).ToString( );
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
                                    if ( string.IsNullOrEmpty( gridView1.GetRowCellValue(i, "PQF06" ).ToString( ) ) )
                                        sum = 0;
                                    else
                                        sum = sum + Convert.ToInt64( gridView1.GetRowCellValue(i, "PQF06" ).ToString( ) );
                                    if ( string.IsNullOrEmpty( cn5 ) )
                                        cn5 = gridView1.GetRowCellValue(i, "DAA002" ).ToString( );
                                    else
                                        cn5 = cn5 + "," + gridView1.GetRowCellValue(i, "DAA002" ).ToString( );
                                    if ( string.IsNullOrEmpty( cn6 ) )
                                        cn6 = gridView1.GetRowCellValue( i ,"PQF31" ).ToString( );
                                    else
                                        cn6 = cn6 + "," + gridView1.GetRowCellValue( i ,"PQF31" ).ToString( );
                                }
                            }
                            cn4 = sum.ToString( );
                            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 );
                            if ( PassDataBetweenForm != null )
                                PassDataBetweenForm( this ,args );

                            this.Close( );
                        }
                        else
                            MessageBox.Show( "请至少选择两项合并" );
                    }
                }
            }
            else
                MessageBox.Show( "请按Enter键合并选择的内容" );
        }
        private void gridView1_Click ( object sender ,EventArgs e )
        {
            if ( gridView1.FocusedRowHandle >= 0 )
            {
                if ( gonxu == "2" )
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
    }
}

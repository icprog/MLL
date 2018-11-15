using System;
using System.Windows.Forms;
using Mulaolao.Class;

namespace Mulaolao.Contract
{
    public partial class Youqicaigou : Form
    {
        public Youqicaigou ( )
        {
            InitializeComponent( );

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "", cn8 = "", cn9 = "", cn10 = "", cn11 = "", cn12 = "";
        private void Youqicaigou_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
            gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;

            if ( sy == "1" )
            {
                this.gridView1.Columns["PQF01"].Visible = true;
                this.gridView1.Columns["PQF02"].Visible = true;
                this.gridView1.Columns["PQF03"].Visible = true;
                this.gridView1.Columns["PQF06"].Visible = true;
                this.gridView1.Columns["PQF04"].Visible = true;
                this.gridView1.Columns["HT52"].Visible = false;
                this.gridView1.Columns["YQ03"].Visible = false;
                this.gridView1.Columns["YQ04"].Visible = false;
                this.gridView1.Columns["YQ99"].Visible = false;
                this.gridView1.Columns["YQ105"].Visible = false;
                this.gridView1.Columns["YQ106"].Visible = false;
                this.gridView1.Columns["YQ107"].Visible = false;
                this.gridView1.Columns["YQ108"].Visible = false;
                this.gridView1.Columns["YQ10"].Visible = false;
                this.gridView1.Columns["YQ11"].Visible = false;
                this.gridView1.Columns["YQ12"].Visible = false;
                this.gridView1.Columns["YQ19"].Visible = false;
                this.gridView1.Columns["YQ101"].Visible = false;
                this.gridView1.Columns["YQ109"].Visible = false;
                this.gridView1.Columns["DBA002"].Visible = false;
                this.gridView1.Columns["DAA002"].Visible = false;
                this.gridView1.Columns["DGA003"].Visible = false;
                this.gridView1.Columns["DFA002"].Visible = false;
                this.gridView1.Columns["RES05"].Visible = false;
            }
            else if ( sy == "2" )
            {
                this.gridView1.Columns["YQ03"].Visible = true;
                this.gridView1.Columns["YQ04"].Visible = true;
                this.gridView1.Columns["YQ10"].Visible = true;
                this.gridView1.Columns["YQ11"].Visible = true;
                this.gridView1.Columns["YQ12"].Visible = true;
                this.gridView1.Columns["YQ19"].Visible = true;
                this.gridView1.Columns["YQ101"].Visible = true;
                this.gridView1.Columns["YQ109"].Visible = true;
                this.gridView1.Columns["YQ99"].Visible = true;
                this.gridView1.Columns["YQ105"].Visible = true;
                this.gridView1.Columns["YQ106"].Visible = true;
                this.gridView1.Columns["YQ107"].Visible = true;
                this.gridView1.Columns["YQ108"].Visible = true;
                this.gridView1.Columns["DBA002"].Visible = true;
                this.gridView1.Columns["DGA003"].Visible = true;
                this.gridView1.Columns["RES05"].Visible = true;
                this.gridView1.Columns["PQF01"].Visible = false;
                this.gridView1.Columns["PQF02"].Visible = false;
                this.gridView1.Columns["PQF04"].Visible = false;
                this.gridView1.Columns["PQF03"].Visible = false;
                this.gridView1.Columns["PQF06"].Visible = false;
                this.gridView1.Columns["HT52"].Visible = false;
                this.gridView1.Columns["DAA002"].Visible = false;
                this.gridView1.Columns["DFA002"].Visible = false;
            }
            else if ( sy == "3" )
            {
                this.gridView1.Columns["PQF01"].Visible = true;
                this.gridView1.Columns["PQF02"].Visible = true;
                this.gridView1.Columns["PQF03"].Visible = true;
                this.gridView1.Columns["PQF06"].Visible = true;
                this.gridView1.Columns["PQF04"].Visible = true;
                this.gridView1.Columns["HT52"].Visible = true;
                this.gridView1.Columns["DAA002"].Visible = false;
                this.gridView1.Columns["DBA002"].Visible = false;
                this.gridView1.Columns["DGA003"].Visible = false;
                this.gridView1.Columns["DFA002"].Visible = false;
                this.gridView1.Columns["YQ03"].Visible = false;
                this.gridView1.Columns["YQ04"].Visible = false;
                this.gridView1.Columns["YQ99"].Visible = false;
                this.gridView1.Columns["YQ105"].Visible = false;
                this.gridView1.Columns["YQ106"].Visible = false;
                this.gridView1.Columns["YQ107"].Visible = false;
                this.gridView1.Columns["YQ108"].Visible = false;
                this.gridView1.Columns["YQ10"].Visible = false;
                this.gridView1.Columns["YQ11"].Visible = false;
                this.gridView1.Columns["YQ12"].Visible = false;
                this.gridView1.Columns["YQ19"].Visible = false;
                this.gridView1.Columns["YQ101"].Visible = false;
                this.gridView1.Columns["YQ109"].Visible = false;
                this.gridView1.Columns["RES05"].Visible = false;
            }
            else if ( sy == "4" )
            {
                this.gridView1.Columns["PQF01"].Visible = true;
                this.gridView1.Columns["PQF03"].Visible = true;
                this.gridView1.Columns["PQF04"].Visible = true;
                this.gridView1.Columns["DAA002"].Visible = true;
                this.gridView1.Columns["PQF02"].Visible = false;
                this.gridView1.Columns["PQF06"].Visible = false;
                this.gridView1.Columns["HT52"].Visible = false;
                this.gridView1.Columns["DBA002"].Visible = false;
                this.gridView1.Columns["DGA003"].Visible = false;
                this.gridView1.Columns["DFA002"].Visible = true;
                this.gridView1.Columns["YQ04"].Visible = false;
                this.gridView1.Columns["YQ99"].Visible = false;
                this.gridView1.Columns["YQ105"].Visible = false;
                this.gridView1.Columns["YQ106"].Visible = false;
                this.gridView1.Columns["YQ107"].Visible = false;
                this.gridView1.Columns["YQ108"].Visible = false;
                this.gridView1.Columns["YQ03"].Visible = false;
                this.gridView1.Columns["YQ10"].Visible = false;
                this.gridView1.Columns["YQ11"].Visible = false;
                this.gridView1.Columns["YQ12"].Visible = false;
                this.gridView1.Columns["YQ19"].Visible = false;
                this.gridView1.Columns["YQ101"].Visible = false;
                this.gridView1.Columns["YQ109"].Visible = false;
                this.gridView1.Columns["RES05"].Visible = false;
            }
            else if ( sy == "5" )
            {
                this.gridView1.Columns["PQF01"].Visible = true;
                this.gridView1.Columns["PQF02"].Visible = true;
                this.gridView1.Columns["PQF03"].Visible = true;
                this.gridView1.Columns["PQF06"].Visible = true;
                this.gridView1.Columns["PQF04"].Visible = true;
                this.gridView1.Columns["HT52"].Visible = false;
                this.gridView1.Columns["YQ03"].Visible = false;
                this.gridView1.Columns["YQ04"].Visible = false;
                this.gridView1.Columns["YQ99"].Visible = false;
                this.gridView1.Columns["YQ105"].Visible = false;
                this.gridView1.Columns["YQ106"].Visible = false;
                this.gridView1.Columns["YQ107"].Visible = false;
                this.gridView1.Columns["YQ108"].Visible = false;
                this.gridView1.Columns["DBA002"].Visible = false;
                this.gridView1.Columns["DAA002"].Visible = false;
                this.gridView1.Columns["DGA003"].Visible = false;
                this.gridView1.Columns["DFA002"].Visible = false;
                this.gridView1.Columns["YQ10"].Visible = false;
                this.gridView1.Columns["YQ11"].Visible = false;
                this.gridView1.Columns["YQ12"].Visible = false;
                this.gridView1.Columns["YQ19"].Visible = false;
                this.gridView1.Columns["YQ101"].Visible = false;
                this.gridView1.Columns["YQ109"].Visible = false;
                this.gridView1.Columns["RES05"].Visible = false;
            }
            else if ( sy == "6" )
            {
                this.gridView1.Columns["PQF01"].Visible = true;
                this.gridView1.Columns["PQF02"].Visible = true;
                this.gridView1.Columns["PQF03"].Visible = true;
                this.gridView1.Columns["PQF04"].Visible = true;
                this.gridView1.Columns["PQF06"].Visible = true;
                this.gridView1.Columns["HT52"].Visible = false;
                this.gridView1.Columns["DAA002"].Visible = false;
                this.gridView1.Columns["DBA002"].Visible = false;
                this.gridView1.Columns["DGA003"].Visible = false;
                this.gridView1.Columns["DFA002"].Visible = false;
                this.gridView1.Columns["YQ03"].Visible = false;
                this.gridView1.Columns["YQ04"].Visible = false;
                this.gridView1.Columns["YQ99"].Visible = false;
                this.gridView1.Columns["YQ105"].Visible = false;
                this.gridView1.Columns["YQ106"].Visible = false;
                this.gridView1.Columns["YQ107"].Visible = false;
                this.gridView1.Columns["YQ108"].Visible = false;
                this.gridView1.Columns["YQ10"].Visible = false;
                this.gridView1.Columns["YQ11"].Visible = false;
                this.gridView1.Columns["YQ12"].Visible = false;
                this.gridView1.Columns["YQ19"].Visible = false;
                this.gridView1.Columns["YQ101"].Visible = false;
                this.gridView1.Columns["YQ109"].Visible = false;
                this.gridView1.Columns["RES05"].Visible = false;
            }
            else if ( sy == "7" )
            {
                this.gridView1.Columns["PQF01"].Visible = true;
                this.gridView1.Columns["PQF02"].Visible = true;
                this.gridView1.Columns["PQF03"].Visible = true;
                this.gridView1.Columns["PQF04"].Visible = true;
                this.gridView1.Columns["PQF06"].Visible = true;
                this.gridView1.Columns["HT52"].Visible = false;
                this.gridView1.Columns["DAA002"].Visible = false;
                this.gridView1.Columns["DBA002"].Visible = false;
                this.gridView1.Columns["DGA003"].Visible = false;
                this.gridView1.Columns["DFA002"].Visible = false;
                this.gridView1.Columns["YQ03"].Visible = false;
                this.gridView1.Columns["YQ04"].Visible = false;
                this.gridView1.Columns["YQ99"].Visible = false;
                this.gridView1.Columns["YQ105"].Visible = false;
                this.gridView1.Columns["YQ106"].Visible = false;
                this.gridView1.Columns["YQ107"].Visible = false;
                this.gridView1.Columns["YQ108"].Visible = false;
                this.gridView1.Columns["YQ10"].Visible = false;
                this.gridView1.Columns["YQ11"].Visible = false;
                this.gridView1.Columns["YQ12"].Visible = false;
                this.gridView1.Columns["YQ19"].Visible = false;
                this.gridView1.Columns["YQ101"].Visible = false;
                this.gridView1.Columns["YQ109"].Visible = false;
                this.gridView1.Columns["RES05"].Visible = false;
            }
            else if ( sy == "8" )
            {
                this.gridView1.Columns["PQF01"].Visible = true;
                this.gridView1.Columns["PQF02"].Visible = true;
                this.gridView1.Columns["PQF03"].Visible = true;
                this.gridView1.Columns["PQF04"].Visible = true;
                this.gridView1.Columns["PQF06"].Visible = true;
                this.gridView1.Columns["PQF07"].Visible = false;
                this.gridView1.Columns["PQF08"].Visible = false;
                this.gridView1.Columns["HT52"].Visible = false;
                this.gridView1.Columns["DAA002"].Visible = false;
                this.gridView1.Columns["DBA002"].Visible = false;
                this.gridView1.Columns["DGA003"].Visible = false;
                this.gridView1.Columns["DFA002"].Visible = false;
                this.gridView1.Columns["YQ03"].Visible = false;
                this.gridView1.Columns["YQ04"].Visible = false;
                this.gridView1.Columns["YQ99"].Visible = false;
                this.gridView1.Columns["YQ105"].Visible = false;
                this.gridView1.Columns["YQ106"].Visible = false;
                this.gridView1.Columns["YQ107"].Visible = false;
                this.gridView1.Columns["YQ108"].Visible = false;
                this.gridView1.Columns["YQ10"].Visible = false;
                this.gridView1.Columns["YQ11"].Visible = false;
                this.gridView1.Columns["YQ12"].Visible = false;
                this.gridView1.Columns["YQ19"].Visible = false;
                this.gridView1.Columns["YQ101"].Visible = false;
                this.gridView1.Columns["YQ109"].Visible = false;
                this.gridView1.Columns["RES05"].Visible = false;
            }
            else if ( sy == "9" )
            {
                this.gridView1.Columns["PQF01"].Visible = true;
                this.gridView1.Columns["PQF02"].Visible = true;
                this.gridView1.Columns["PQF03"].Visible = true;
                this.gridView1.Columns["PQF04"].Visible = true;
                this.gridView1.Columns["PQF06"].Visible = true;
                this.gridView1.Columns["PQF07"].Visible = false;
                this.gridView1.Columns["PQF08"].Visible = false;
                this.gridView1.Columns["HT52"].Visible = false;
                this.gridView1.Columns["DAA002"].Visible = false;
                this.gridView1.Columns["DBA002"].Visible = false;
                this.gridView1.Columns["DGA003"].Visible = false;
                this.gridView1.Columns["DFA002"].Visible = false;
                this.gridView1.Columns["YQ03"].Visible = false;
                this.gridView1.Columns["YQ04"].Visible = false;
                this.gridView1.Columns["YQ99"].Visible = false;
                this.gridView1.Columns["YQ105"].Visible = false;
                this.gridView1.Columns["YQ106"].Visible = false;
                this.gridView1.Columns["YQ107"].Visible = false;
                this.gridView1.Columns["YQ108"].Visible = false;
                this.gridView1.Columns["YQ10"].Visible = false;
                this.gridView1.Columns["YQ11"].Visible = false;
                this.gridView1.Columns["YQ12"].Visible = false;
                this.gridView1.Columns["YQ19"].Visible = false;
                this.gridView1.Columns["YQ101"].Visible = false;
                this.gridView1.Columns["YQ109"].Visible = false;
                this.gridView1.Columns["RES05"].Visible = false;
            }
        }
        public string sy = "";
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            if ( sy == "1" )
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF01" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF02" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF03" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF04" ).ToString( );
                cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF06" ).ToString( );
                cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF07" ).ToString( );
                cn7 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF08" ).ToString( );
            }
            else if ( sy == "2" )
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"YQ03" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"RES05" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"YQ01" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"YQ105" ).ToString( );
                cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"DBA002" ).ToString( );
                cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"YQ02" ).ToString( );
                cn7 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"DGA003" ).ToString( );
                cn8 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"YQ04" ).ToString( );
                cn9 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"YQ99" ).ToString( );
                cn10 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"YQ106" ).ToString( );
                cn11 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"YQ107" ).ToString( );
                cn12 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"YQ108" ).ToString( );
            }
            else if ( sy == "3" )
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF01" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF02" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF03" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF04" ).ToString( );
                cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF06" ).ToString( );
                cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF07" ).ToString( );
                cn7 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF08" ).ToString( );
                cn8 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"HT52" ).ToString( );
            }
            else if ( sy == "4" )
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF01" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF03" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF04" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF11" ).ToString( );
                cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"DFA002" ).ToString( );
            }
            else if ( sy == "5" )
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF01" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF02" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF03" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF04" ).ToString( );
                cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF06" ).ToString( );
                cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF07" ).ToString( );
                cn7 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF08" ).ToString( );
            }
            else if ( sy == "6" )
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF01" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF02" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF03" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF04" ).ToString( );
                cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF06" ).ToString( );
                cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF07" ).ToString( );
                cn7 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF08" ).ToString( );
            }
            else if ( sy == "7" )
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF01" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF02" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF03" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF04" ).ToString( );
                cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF06" ).ToString( );
                cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF07" ).ToString( );
                cn7 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF08" ).ToString( );
            }
            else if ( sy == "8" )
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF01" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF02" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF03" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF04" ).ToString( );
                cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF06" ).ToString( );
                //cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF07" ).ToString( );
                //cn7 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF08" ).ToString( );
            }
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 ,cn8 ,cn9 ,cn10 ,cn11 ,cn12 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
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
                cn1 = cn2 = cn3 = cn4 = cn5 = cn6 = cn7 = cn8 = "";
                if ( sy == "3" )
                    ergodic( );
                else if ( sy == "1" )
                    ergodics( );
                else if ( sy == "9" )
                    ergodices( );
                else if ( sy == "8" )
                    ergodideses( );
                else if ( sy == "7" || sy=="5")
                    megerSev( );
                else
                    MessageBox.Show( "本合同不做合并操作" );
            }
            else
                MessageBox.Show( "请按Enter键确认是否合并" );
        }
        private void gridView1_Click ( object sender ,EventArgs e )
        {
            if ( Logins.number != "MLL-0001" )
                return;
            if ( gridView1.FocusedRowHandle >= 0 )
            {
                if ( sy == "1" || sy == "3" || sy == "9" || sy == "8" || sy == "7" || sy == "5" )
                {
                    int num = gridView1.FocusedRowHandle;
                    if ( gridView1.GetDataRow( num )["check"].ToString( ) == "True" )
                        gridView1.GetDataRow( num )["check"] = false;
                    else
                        gridView1.GetDataRow( num )["check"] = true;
                }
            }
        }
        private void ergodic ( )
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
                            if ( cn8 == "" )
                                cn8 = gridView1.GetRowCellValue( i ,"HT52" ).ToString( );
                            else
                                cn8 = cn8 + gridView1.GetRowCellValue( i ,"HT52" ).ToString( );
                            sum = sum + Convert.ToInt64( gridView1.GetRowCellValue( i ,"PQF06" ) );
                        }
                    }
                    cn5 = sum.ToString( );
                    PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 ,cn8 );
                    if ( PassDataBetweenForm != null )
                        PassDataBetweenForm( this ,args );
                    this.Close( );
                }
            }
            else
                MessageBox.Show( "请至少选择两项合并" );
        }
        private void ergodics ( )
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
        void ergodices ( )
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
                            sum = sum + Convert.ToInt64( gridView1.GetRowCellValue( i ,"PQF06" ) );

                        }
                    }
                    cn5 = sum.ToString( );
                    PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 );
                    if ( PassDataBetweenForm != null )
                        PassDataBetweenForm( this ,args );
                    this.Close( );
                }
            }
            else
                MessageBox.Show( "请至少选择两项合并" );
        }
        void ergodideses ( )
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
                            sum = sum + Convert.ToInt64( gridView1.GetRowCellValue( i ,"PQF06" ) );

                        }
                    }
                    cn5 = sum.ToString( );
                    PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 );
                    if ( PassDataBetweenForm != null )
                        PassDataBetweenForm( this ,args );
                    this.Close( );
                }
            }
        }
        void megerSev ( )
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
                            sum = sum + Convert.ToInt64( gridView1.GetRowCellValue( i ,"PQF06" ) );
                            if ( cn6 == "" )
                                cn6 = gridView1.GetRowCellValue( i ,"PQF07" ).ToString( );
                            else
                                cn6 = cn6 + "," + gridView1.GetRowCellValue( i ,"PQF07" ).ToString( );
                            if ( cn7 == "" )
                                cn7 = gridView1.GetRowCellValue( i ,"PQF08" ).ToString( );
                            else
                                cn7 = cn7 + "," + gridView1.GetRowCellValue( i ,"PQF08" ).ToString( );
                        }
                    }
                    cn5 = sum.ToString( );
                    PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 );
                    if ( PassDataBetweenForm != null )
                        PassDataBetweenForm( this ,args );
                    this.Close( );
                }
            }
        }
    }
}

using System;
using System . Windows . Forms;
using Mulaolao . Class;

namespace Mulaolao . Procedure
{
    public partial class R_FrmContractreviewb : Form
    {
        public R_FrmContractreviewb()
        {
            InitializeComponent();
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        //添加一个委托
        public delegate void PassDataBetweenFormHandler(object sender, PassDataWinFormEventArgs e);
        //添加一个PassDataBetweenFormHandler类型的事件
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        public string r21 = "";
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "", cn8 = "", cn9 = "";
        private void R_FrmContractreviewb_Load(object sender, EventArgs e)
        {
            GridViewMoHuSelect.SetFilter( gridView1 );

            if (r21 == "1")
            {     
                this.gridView1.Columns["PQF01"].Visible = true;
                this.gridView1.Columns["PQF03"].Visible = true;
                this.gridView1.Columns["PQF04"].Visible = true;
                this.gridView1.Columns["PQF05"].Visible = true;
                this.gridView1.Columns["PQF06"].Visible = true;
                this.gridView1.Columns["PQF07"].Visible = true;
                this.gridView1.Columns["PQF08"].Visible = true;
                this.gridView1.Columns["PQF09"].Visible = true;              
                this.gridView1.Columns["PQF31"].Visible = true;
                this.gridView1.Columns["RES05"].Visible = false;
                this.gridView1.Columns["HT02"].Visible = false;
                this.gridView1.Columns["HT64"].Visible = false;
                this.gridView1.Columns["HT03"].Visible = false;
                this.gridView1.Columns["HT04"].Visible = false;
                this.gridView1.Columns["DFA003"].Visible = false;
                this.gridView1.Columns["DFA015"].Visible = false;
                this.gridView1.Columns["DFA016"].Visible = false;
            }
            if (r21 == "2")
            {
                this.gridView1.Columns["HT02"].Visible = true;
                this.gridView1.Columns["HT03"].Visible = true;
                this.gridView1.Columns["HT04"].Visible = true;
                this.gridView1.Columns["HT64"].Visible = true;
                this.gridView1.Columns["DFA003"].Visible = true;
                this.gridView1.Columns["DFA015"].Visible = true;
                this.gridView1.Columns["DFA016"].Visible = true;
                this.gridView1.Columns["RES05"].Visible = true;
                this.gridView1.Columns["PQF01"].Visible = true;
                this.gridView1.Columns["PQF03"].Visible = false;
                this.gridView1.Columns["PQF04"].Visible = false;
                this.gridView1.Columns["PQF05"].Visible = false;
                this.gridView1.Columns["PQF06"].Visible = false;
                this.gridView1.Columns["PQF07"].Visible = false;
                this.gridView1.Columns["PQF08"].Visible = false;
                this.gridView1.Columns["PQF09"].Visible = false;                             
                this.gridView1.Columns["PQF31"].Visible = false;
                
            }
        }
        private void gridView1_DoubleClick( object sender, EventArgs e )
        {
            if (r21 == "1")
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF01" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF03" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF04" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF05" ).ToString( );
                cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF06" ).ToString( );
                cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF07" ).ToString( );
                cn7 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF08" ).ToString( );
                cn8 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF09" ).ToString( );
                cn9 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF31" ).ToString( );
            }
            else if (r21 == "2")
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "HT02" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "HT03" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "HT04" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "DFA003" ).ToString( );
                cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "DFA015" ).ToString( );
                cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "DFA016" ).ToString( );
                cn7 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"RES05" ).ToString( );
                cn8 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"HT64" ).ToString( );
            }
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1, cn2, cn3, cn4, cn5, cn6, cn7, cn8,cn9 );
            if (PassDataBetweenForm != null)
            {
                PassDataBetweenForm( this, args );
            }
            this.Close( );
        }
    }
}

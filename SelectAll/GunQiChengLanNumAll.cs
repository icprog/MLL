using Mulaolao;
using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class GunQiChengLanNumAll : Form
    {
        public GunQiChengLanNumAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        
        MulaolaoBll.Bll.GunQiChengLanJiaGongBll bll = new MulaolaoBll.Bll.GunQiChengLanJiaGongBll( );
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        public string sign = "";
        DataTable tableQuery;

        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "", cn8 = "", cn9 = "";

        private void GunQiChengLanNumAll_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
            query( );
        }

        void query ( )
        {
            tableQuery = bll.GetDataTableNums( );
            gridControl1.DataSource = tableQuery;
        }

        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = gridView1.GetFocusedRowCellValue( "PQF01" ).ToString( );
            cn2 = gridView1.GetFocusedRowCellValue( "PQF02" ).ToString( );
            cn3 = gridView1.GetFocusedRowCellValue( "PQF03" ).ToString( );
            cn4 = gridView1.GetFocusedRowCellValue( "PQF04" ).ToString( );
            cn5 = gridView1.GetFocusedRowCellValue( "PQF06" ).ToString( );
            cn6 = gridView1.GetFocusedRowCellValue( "PQF31" ).ToString( );
            cn7 = gridView1.GetFocusedRowCellValue( "HT04" ).ToString( );
            cn8 = gridView1.GetFocusedRowCellValue( "PQF07" ).ToString( );
            cn9 = gridView1.GetFocusedRowCellValue( "PQF08" ).ToString( );
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 ,cn8 ,cn9 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }
    }
}

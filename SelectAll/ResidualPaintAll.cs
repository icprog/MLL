using Mulaolao;
using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class ResidualPaintAll : Form
    {
        public ResidualPaintAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        MulaolaoBll.Bll.YouQicontractBll bll = new MulaolaoBll.Bll.YouQicontractBll( );
        DataTable tableQuery;
        public string nameOf = "", workOf = "", colorName = "";

        private void ResidualPaintAll_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
            query( );
        }

        void query ( )
        {
            tableQuery = bll.GetDataTableSerialNum( nameOf ,workOf ,colorName );
            gridControl1.DataSource = tableQuery;
        }

        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "";
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = gridView1.GetFocusedRowCellValue( "AI001" ).ToString( );
            cn2 = gridView1.GetFocusedRowCellValue( "AI002" ).ToString( );
            cn3 = gridView1.GetFocusedRowCellValue( "AI005" ).ToString( );
            cn4 = gridView1.GetFocusedRowCellValue( "AI006" ).ToString( );
            cn5 = gridView1.GetFocusedRowCellValue( "AI" ).ToString( );
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }
    }
}

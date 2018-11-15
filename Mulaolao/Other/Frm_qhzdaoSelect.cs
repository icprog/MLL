using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mulaolao.Class;

namespace Mulaolao.Other
{
    public partial class Frm_qhzdaoSelect : Form
    {
        public Frm_qhzdaoSelect( )
        {
            InitializeComponent( );

            GridViewMoHuSelect . SetFilter ( gridView1);
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        public delegate void PassDataBetweenFormHandler( object sender, PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;

        public string qhd = "";
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "";

        private void Frm_qhzdaoSelect_Load( object sender, EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );

            if (qhd == "2" && qhd=="1")
            {
                this.gridView1.Columns["U5"].Visible = false;
                this.gridView1.Columns["U1"].Visible = true;
            }
            else if (qhd == "3")
            {
                this.gridView1.Columns["U1"].Visible = false;
                this.gridView1.Columns["U5"].Visible = true;
            }
        }
        //双击选中并关闭
        private void gridView1_DoubleClick( object sender, EventArgs e )
        {
            if (qhd == "2" && qhd == "1")
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "U0" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "U1" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "U2" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "U3" ).ToString( );
            }
            else if (qhd == "3")
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "U4" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "U5" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "U2" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "U3" ).ToString( );
            } 
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1, cn2, cn3, cn4 );
            if (PassDataBetweenForm != null)
            {
                PassDataBetweenForm( this, args );
            }
            this.Close( );
        }
    }
}


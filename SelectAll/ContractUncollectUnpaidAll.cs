﻿using Mulaolao;
using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class ContractUncollectUnpaidAll : Form
    {
        public ContractUncollectUnpaidAll ( )
        {
            InitializeComponent( );

            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        MulaolaoBll.Bll.ContractUncollectUnpaidBll _bll = new MulaolaoBll.Bll.ContractUncollectUnpaidBll( );
        //DataTable tableQuery;
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "";

        private void ContractUncollectUnpaidAll_Load ( object sender ,EventArgs e )
        {
            query( );
        }

        void query ( )
        {
            //tableQuery = _bll.GetDataTable( );
            //gridControl1.DataSource = tableQuery;
        }

        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = gridView1.GetFocusedRowCellValue( "AE02" ).ToString( );
            cn2 = gridView1.GetFocusedRowCellValue( "AE03" ).ToString( );
            cn3 = gridView1.GetFocusedRowCellValue( "AE04" ).ToString( );
            cn4 = gridView1.GetFocusedRowCellValue( "AE05" ).ToString( );
            cn5 = gridView1.GetFocusedRowCellValue( "AE06" ).ToString( );
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }
    }
}

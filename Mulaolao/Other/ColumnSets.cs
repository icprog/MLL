using System;
using System. Collections. Generic;
using System. ComponentModel;
using System. Data;
using System. Drawing;
using System. Linq;
using System. Text;
using System. Windows. Forms;

namespace Mulaolao. Other
{
    public partial class ColumnSets : Form
    {
        public ColumnSets ( )
        {
            InitializeComponent ( );
        }

        private void ColumnSets_Load ( object sender , EventArgs e )
        {
           
        }

        private void ColumnSet (DevExpress.XtraGrid.Views.Grid.GridView gv)
        {
            var coun = gv. Columns. Count;
            this. CreateControl ( );
            //循环增加label以及textbox
            Label le = new Label ( );
            for ( int i = 0 ; i < coun ; i++ )
            {
                if ( this. Contains ( le ) )
                {
                    le. Location = new System. Drawing. Point ( );
                }
                else
                {

                }
            }
        }
    }
}

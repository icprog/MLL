using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Data;
using System . Drawing;
using System . Text;
using System . Linq;
using System . Windows . Forms;
using DevExpress . XtraEditors;

namespace Mulaolao . Other
{
    public partial class FormGonXuGonXi :DevExpress . XtraEditors . XtraForm
    {
        public FormGonXuGonXi ( DataTable table )
        {
            InitializeComponent ( );

            gridControl1 . DataSource = table;
        }

        private void btnCancel_Click ( object sender ,EventArgs e )
        {
            this . DialogResult = DialogResult . Cancel;
        }

        List<DataRow> rows=new List<DataRow>();
        private void btnSure_Click ( object sender ,EventArgs e )
        {
            int [ ] selectRows = gridView1 . GetSelectedRows ( );
            if ( selectRows . Length < 1 )
                return;
            foreach ( int i in selectRows )
            {
                rows . Add ( gridView1 . GetDataRow ( i ) );
            }
            if ( rows . Count < 1 )
                return;
            this . DialogResult = DialogResult . OK;
        }

        public List<DataRow> getRows
        {
            get
            {
                return rows;
            }
        }

    }
}
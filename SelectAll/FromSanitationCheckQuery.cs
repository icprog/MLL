using Mulaolao;
using Mulaolao . Class;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class FromSanitationCheckQuery :Form
    {
        MulaolaoBll.Bll.SanitationCheckBll _bll=null;
        DataTable tableView;

        public FromSanitationCheckQuery ( )
        {
            InitializeComponent ( );

            _bll = new MulaolaoBll . Bll . SanitationCheckBll ( );

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
            InitData ( );
        }

        void InitData ( )
        {
            tableView = _bll . getTableQuery ( string . Empty );
            gridControl1 . DataSource = tableView;
        }

        string code=string.Empty;
        private void gridView1_DoubleClick ( object sender ,System . EventArgs e )
        {
            code = gridView1 . GetFocusedRowCellValue ( "SAC001" ) . ToString ( );
            if ( code == string . Empty )
                return;
            this . DialogResult = DialogResult . OK;
        }

        public string getCode
        {
            get
            {
                return code;
            }
        }

    }
}

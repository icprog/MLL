using Mulaolao;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class FeedTestPartAll :Form
    {
        MulaolaoBll.Bll.FeedTestBll _bll=null;
        
        public FeedTestPartAll ( string text,string num ,string oddNum)
        {
            InitializeComponent ( );

            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );

            _bll = new MulaolaoBll . Bll . FeedTestBll ( );
            this . Text = text;
            DataTable tableView = _bll . getPart ( num ,oddNum );
            gridControl1 . DataSource = tableView;
        }

        List<MulaolaoLibrary . FeedTestCPEntity> modelCP=new List<MulaolaoLibrary.FeedTestCPEntity>();

        private void gridControl1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            if ( e . KeyChar == 13 )
            {
                int [ ] rows = gridView1 . GetSelectedRows ( );
                if ( rows . Length > 0 )
                {
                    foreach ( int i in rows )
                    {
                        MulaolaoLibrary . FeedTestCPEntity _cp = new MulaolaoLibrary . FeedTestCPEntity ( );
                        DataRow row = gridView1 . GetDataRow ( i );
                        _cp . CP001 = row [ "TAB" ] . ToString ( );
                        _cp . CP002 = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
                        _cp . CP003 = row [ "ONE" ] . ToString ( );
                        _cp . CP004 = row [ "TWO" ] . ToString ( );
                        _cp . CP005 = string . IsNullOrEmpty ( row [ "TRE" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "TRE" ] . ToString ( ) );
                        modelCP . Add ( _cp );
                    }
                    this . DialogResult = DialogResult . OK;
                }
                else
                    MessageBox . Show ( "请选择零件" );
            }
        }

        public List<MulaolaoLibrary . FeedTestCPEntity> getModel
        {
            get
            {
                return modelCP;
            }
        }

    }
}

using System;
using System . Data;
using System . Windows . Forms;
using Mulaolao . Class;

namespace Mulaolao . Other
{
    public partial class FormJiaoMiDu :DevExpress . XtraEditors . XtraForm
    {
        MulaolaoBll.Bll.YouQiBomBll bll = null;
        DataTable tableOne,tableTwo;

        DataRow rowSelect;
        string sign=string.Empty;

        public FormJiaoMiDu ( )
        {
            InitializeComponent ( );

            bll = new MulaolaoBll . Bll . YouQiBomBll ( );

            GridViewMoHuSelect . SetFilter ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView8 ,gridView9 } );

            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { this . gridView8 ,this . gridView9 } );
        }

        private void FormJiaoMiDu_Load ( object sender ,EventArgs e )
        {
            tableOne = bll . getTable ( );
            gridControl8 . DataSource = tableOne;
            gridView8 . BestFitColumns ( );

            tableTwo = bll . getTableMd ( );
            gridControl9 . DataSource = tableTwo;
            gridView9 . BestFitColumns ( );
        }
        private void gridView8_DoubleClick ( object sender ,EventArgs e )
        {
            sign = "胶合板";
            rowSelect = gridView8 . GetFocusedDataRow ( );
            if ( rowSelect != null )
                this . DialogResult = DialogResult . OK;
        }
        private void gridView9_DoubleClick ( object sender ,EventArgs e )
        {
            sign = "密度板";
            rowSelect = gridView9 . GetFocusedDataRow ( );
            if ( rowSelect != null )
                this . DialogResult = DialogResult . OK;
        }
        public DataRow getRow
        {
            get
            {
                return rowSelect;
            }
        }
        public string getStr
        {
            get
            {
                return sign;
            }
        }

    }
}
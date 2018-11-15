using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Environmental
{
    public partial class FormSanitionReport :Form
    {
        MulaolaoBll.Bll.SanitationCheckBll _bll=null;
        DataTable tableView;

        public FormSanitionReport ( )
        {
            InitializeComponent ( );

            _bll = new MulaolaoBll . Bll . SanitationCheckBll ( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );

            InitData ( );
        }

        void InitData ( )
        {
            tableView = _bll . getTableAll ( );
            gridControl1 . DataSource = tableView;
            gridView1 . BestFitColumns ( );
            gridView1 . PopulateColumns ( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
            addColumn ( );
        }

        void addColumn ( )
        {
            if ( tableView == null || tableView . Rows . Count < 1 )
                return;
            foreach ( DevExpress . XtraGrid . Columns . GridColumn column in gridView1 . Columns )
            {
                column . BestFit ( );
                column . Summary . Clear ( );
                if ( column . FieldName != "检查区域" && column . FieldName != "检查项目" && column . FieldName != "现场检查内容" && column . FieldName != "评分标准" && column . FieldName != "车间" && column . FieldName != "现在及存在问题描述" )
                {
                    column . Summary . Add ( DevExpress . Data . SummaryItemType . Sum ,column . FieldName );
                }
            }
        }

    }
}

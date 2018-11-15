using Mulaolao.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mulaolao.Wages
{
    public partial class R_FrmZuZhangBom : FormChild
    {
        public R_FrmZuZhangBom ( )
        {
            InitializeComponent( );

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        MulaolaoLibrary.ZuZhangBomLibrary _model = new MulaolaoLibrary.ZuZhangBomLibrary( );
        MulaolaoBll.Bll.ZuZhangBomBll _bll = new MulaolaoBll.Bll.ZuZhangBomBll( );
        DataTable tableQuery;

        private void R_FrmZuZhangBom_Load ( object sender ,EventArgs e )
        {
            Power( this );
            gridView1.OptionsBehavior.Editable = false;
        }

        protected override void select ( )
        {
            base.select( );

            tableQuery = _bll.GetDataTable( );
            gridControl1.DataSource = tableQuery;
            gridView1.OptionsBehavior.Editable = true;

            toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolSelect.Enabled = toolReview.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolPrint.Enabled = toolExport.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
        }
        protected override void save ( )
        {
            base.save( );

            gridView1.UpdateCurrentRow( );
            for ( int i = 0 ; i < tableQuery.Rows.Count ; i++ )
            {
                if ( string.IsNullOrEmpty( tableQuery.Rows[i]["ZZ001"].ToString( ) ) )
                    tableQuery.Rows.RemoveAt( i );
            }
            
            
            bool result = _bll.Save( tableQuery );
            if ( result == true )
            {
                MessageBox.Show( "保存数据成功" );
                gridView1.OptionsBehavior.Editable = false;

                toolSelect.Enabled = true;
                toolUpdate.Enabled = toolSave.Enabled = toolCancel.Enabled = toolReview.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolPrint.Enabled = toolExport.Enabled = toolAdd.Enabled = toolDelete.Enabled = false;
            }
            else
                MessageBox.Show( "保存数据失败" );
        }
        protected override void cancel ( )
        {
            base.cancel( );

            gridView1.OptionsBehavior.Editable = false;

            toolSelect.Enabled = true;
            toolUpdate.Enabled = toolSave.Enabled = toolCancel.Enabled = toolReview.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolPrint.Enabled = toolExport.Enabled = toolAdd.Enabled = toolDelete.Enabled = false;
        }
    }
}

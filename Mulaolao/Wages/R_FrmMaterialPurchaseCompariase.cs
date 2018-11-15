using System;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Wages
{
    public partial class R_FrmMaterialPurchaseCompariase : Form
    {
        public R_FrmMaterialPurchaseCompariase ( )
        {
            InitializeComponent( );

            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        private void R_FrmMaterialPurchaseCompariase_Load ( object sender ,EventArgs e )
        {
            
        }
        
        MulaolaoBll.Bll.MaterialPurchaseCompariaseBll _bll = new MulaolaoBll.Bll.MaterialPurchaseCompariaseBll( );
        MulaolaoLibrary.MaterialPurchaseCompariaseLibrary _model = new MulaolaoLibrary.MaterialPurchaseCompariaseLibrary( );
        bool result = false;
        DataTable tableQuery;
        
        #region Generate
        private void button1_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( dateEdit1 . Text ) )
            {
                MessageBox . Show ( "请选择日期" );
                return;
            }
            string year =  dateEdit1 . Text ;
            result = _bll . Generate ( _model ,year );
            if ( result == true )
            {
                MessageBox.Show( "生成成功" );
                tableQuery = _bll.GetDataTable( );
                gridControl1.DataSource = tableQuery;
            }
            else
                MessageBox.Show( "生成失败" );
        }
        #endregion

    }
}

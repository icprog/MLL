using Mulaolao.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mulaolao.Base
{
    public partial class ReadyOfNum : FormChild
    {
        public ReadyOfNum ( )
        {
            InitializeComponent( );

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        MulaolaoLibrary.ReadyOfNumLibrary _model = new MulaolaoLibrary.ReadyOfNumLibrary( );
        MulaolaoBll.Bll.ReadyOfNumBll _bll = new MulaolaoBll.Bll.ReadyOfNumBll( );
        DataTable tableOfNum, tableQuery; bool result = false;

        private void ReadyOfNum_Load ( object sender ,EventArgs e )
        {
            Power( this );
            button4.Enabled = false;
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
            textBox4.ReadOnly = true;
            refre( );
            toolDelete.Enabled = toolUpdate.Enabled = true;
        }

        #region Main
        protected override void add ( )
        {
            base.add( );

            tableOfNum = _bll.GetDataTableOfNum( );
            if ( tableOfNum == null || tableOfNum.Rows.Count < 1 )
                _model.BG001 = "317" + MulaolaoBll . Drity . GetDt ( ).ToString( "yyMM" ) + "001";
            else
            {
                if (string.IsNullOrEmpty( tableOfNum.Rows[0]["BG"].ToString( ) ) )
                    _model.BG001 = "317" + MulaolaoBll . Drity . GetDt ( ).ToString( "yyMM" ) + "001";
                else
                {
                    if ( tableOfNum.Rows[0]["BG"].ToString( ).Substring( 3 ,4 ) == MulaolaoBll . Drity . GetDt ( ).ToString( "yyMM" ) )
                        _model.BG001 = ( Convert.ToInt64( tableOfNum.Rows[0]["BG"].ToString( ) ) + 1 ).ToString( );
                    else
                        _model.BG001 = "317" + MulaolaoBll . Drity . GetDt ( ).ToString( "yyMM" ) + "001";
                }
            }
            textBox1.Text = _model.BG001;
            button4.Enabled = true;
            refre( );
            textBox2.Text = textBox3.Text = textBox4.Text = "";
            textBox4.ReadOnly = false;
            toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolcopy.Enabled = toolMaintain.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
        }
        protected override void delete ( )
        {
            base.delete( );

            if ( string.IsNullOrEmpty( textBox1.Text ) )
            {
                MessageBox.Show( "请选择需要删除的内容" );
                return;
            }
                result = _bll.Delete( _model.BG001 );
                if ( result == true )
                {
                    MessageBox.Show( "成功删除记录" );
                    button4.Enabled = false;
                    refre( );
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                    textBox4.ReadOnly = true;
                    if ( gridView1.RowCount > 0 )
                    {
                        toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = true;
                        toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolcopy.Enabled = toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled = false;
                    }
                    else
                    {
                        toolAdd.Enabled = toolSelect.Enabled = true;
                        toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolcopy.Enabled = toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled = false;
                    }
                }
                else
                    MessageBox.Show( "删除失败,请重试" );
            
        }
        protected override void update ( )
        {
            base.update( );

            button4.Enabled = true;
            toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolcopy.Enabled = toolMaintain.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
            textBox4.ReadOnly = false;
        }
        protected override void save ( )
        {
            base.save( );

            _model.BG002 = textBox2.Text;
            _model.BG003 = textBox3.Text;
            _model.BG004 = string.IsNullOrEmpty( textBox4.Text ) == true ? 0 : Convert.ToInt32( textBox4.Text );

            result = _bll.ExistsOf( _model );
            if ( result == true )
            {
                MessageBox.Show( "已经存在相同的产品名称、货号和产品数量" );
                return;
            }
            result = _bll.Save( _model );
            if ( result == true )
            {
                MessageBox.Show( "成功保存数据" );
                button4.Enabled = false;
                refre( );
                toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolcopy.Enabled = toolMaintain.Enabled = false;
                textBox4.ReadOnly = false;
            }
            else
                MessageBox.Show( "保存数据失败" );
        }
        protected override void cancel ( )
        {
            base.cancel( );

            button4.Enabled = false;
            refre( );
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
            textBox4.ReadOnly = true;
            if ( gridView1.RowCount > 0 )
            {
                toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = true;
                toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolcopy.Enabled = toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled = false;
            }
            else
            {
                toolAdd.Enabled = toolSelect.Enabled = true;
                toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolcopy.Enabled = toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled = false;
            }
        }
        #endregion

        #region Query
        private void button4_Click ( object sender ,EventArgs e )
        {
            SelectAll.ReadyOfNumAll query = new SelectAll.ReadyOfNumAll( );
            query.StartPosition = FormStartPosition.CenterScreen;
            query.PassDataBetweenForm += new SelectAll.ReadyOfNumAll.PassDataBetweenFormHandler( query_PassDataBetweenForm );
            query.ShowDialog( );
        }
        private void query_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            textBox2.Text = e.ConOne;
            textBox3.Text = e.ConTwo;
        }
        #endregion

        #region Table
        void refre ( )
        {
            tableQuery = _bll.GetDataTable( );
            gridControl1.DataSource = tableQuery;
        }
        #endregion

        #region Event
        private void textBox4_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void gridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.RowCount - 1 )
            {
                _model.BG001 = gridView1.GetDataRow( gridView1.FocusedRowHandle )["BG001"].ToString( );
                assageMent( );
            }
        }
        void assageMent ( )
        {
            _model = _bll.GetModel( _model.BG001 );
            if ( _model == null )
                return;
            textBox1.Text = _model.BG001;
            textBox2.Text = _model.BG002;
            textBox3.Text = _model.BG003;
            textBox4.Text = _model.BG004.ToString( );
        }
        #endregion
    }
}

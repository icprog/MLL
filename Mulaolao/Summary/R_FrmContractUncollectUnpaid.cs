using Mulaolao.Class;
using System;
using System.Data;
using System.Windows.Forms;

namespace Mulaolao.Summary
{
    public partial class R_FrmContractUncollectUnpaid : Form
    {
        public R_FrmContractUncollectUnpaid ( )
        {
            InitializeComponent( );

            GridViewMoHuSelect . SetFilter ( bandedGridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { bandedGridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
            
        }
        
        MulaolaoBll.Bll.ContractUncollectUnpaidBll _bll = new MulaolaoBll.Bll.ContractUncollectUnpaidBll( );
        MulaolaoLibrary.ContractUncollectUnpaid _model = new MulaolaoLibrary.ContractUncollectUnpaid( );
        DataTable tableQuery;

        bool result = false;
        
        private void R_FrmContractUncollectUnpaid_Load ( object sender ,EventArgs e )
        {
            
        }

        #region Table
        //Query
        private void button2_Click ( object sender ,EventArgs e )
        {
            _model.RZ001 = dateTimePicker1.Value.Year;
            result = _bll.Add( _model );
            if ( result == true )
                button3_Click( null ,null );
            else
                MessageBox.Show( "生成数据失败" );
        }
        //BatchEdit
        private void button4_Click ( object sender ,EventArgs e )
        {
            bool result = false;
            if ( string.IsNullOrEmpty( textBox1.Text ) )
            {
                MessageBox.Show( "系数不可为空" );
                return;
            }
            _model.RZ001 = dateTimePicker1.Value.Year;
            _model.RZ002 = string.IsNullOrEmpty( textBox1.Text ) == true ? 0 : Convert.ToDecimal( textBox1.Text );
            //_model.RZ003 = dateTimePicker1.Value.Month;
            _model.RZ006 = string.IsNullOrEmpty( textBox2.Text ) == true ? 0 : Convert.ToDecimal( textBox2.Text );
            result = _bll.Exists( _model.RZ001 );
            if ( result == true )
            {
                result = _bll.Update( _model );
                if ( result == true )
                {
                    MessageBox.Show( "成功编辑数据" );
                    button3_Click( null ,null );
                }
                else
                    MessageBox.Show( "编辑数据失败" );
            }
            else
                MessageBox.Show( "请刷新再编辑" );
        }
        //Edit
        private void button1_Click ( object sender ,EventArgs e )
        {
            _model.RZ005 = string.IsNullOrEmpty( textBox3.Text ) == true ? 0 : Convert.ToInt32( textBox3.Text );
            _model.RZ008 = string.IsNullOrEmpty( textBox4.Text ) == true ? 0 : Convert.ToInt32( textBox4.Text );
            _model.RZ016 = string.IsNullOrEmpty( textBox5.Text ) == true ? 0 : Convert.ToInt32( textBox5.Text );
            _model.RZ017 = string.IsNullOrEmpty( textBox6.Text ) == true ? 0 : Convert.ToInt32( textBox6.Text );
            result = _bll.ExistsIdx( _model.IDX );
            if ( result == true )
            {
                result = _bll.UpdateOther( _model );
                if ( result == true )
                {
                    MessageBox.Show( "成功编辑数据" );
                    button3_Click( null ,null );
                }
                else
                    MessageBox.Show( "编辑数据失败" );
            }
            else
                MessageBox.Show( "请刷新再试" );
        }
        //Refresh
        private void button3_Click ( object sender ,EventArgs e )
        {
            _model.RZ001 = dateTimePicker1.Value.Year;
            tableQuery = _bll.GetDataTable( _model.RZ001 );
            gridControl1.DataSource = tableQuery;
        }
        //Delete
        private void button5_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) ==DialogResult . Cancel )
                return;

            result = _bll.Delete( _model.IDX );
            if ( result == true )
            {
                MessageBox.Show( "删除数据成功" );
                button3_Click( null ,null );
            }
            else
                MessageBox.Show( "删除数据失败" );
        }
        //DeleteAll
        private void button6_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) ==   DialogResult . Cancel )
                return;

            _model .RZ001 = dateTimePicker1.Value.Year;
            result = _bll.DeleteBatch( _model.RZ001 );
            if ( result == true )
            {
                MessageBox.Show( "删除数据成功" );
                gridControl1.DataSource = null;
            }
            else
                MessageBox.Show( "删除数据失败" );
        }
        //export
        private void btnExport_Click ( object sender ,EventArgs e )
        {
            ViewExport . ExportToExcel ( this . Text ,gridControl1 );
        }
        #endregion

        #region Event
        private void textBox1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox1 );
        }
        private void textBox1_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise . textChangeTb( textBox1 );
        }
        private void textBox1_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox1.Text != "" && !DateDayRegise . sixTwoNumber( textBox1 ) )
            {
                textBox1.Text = "";
                MessageBox.Show( "只允许输入整数部分最多四位,小数部分最多两位,如9999.99,请重新输入" );
            }
        }
        private void textBox2_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise . fractionTb( e ,textBox2 );
        }
        private void textBox2_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise . textChangeTb( textBox2 );
        }
        private void textBox2_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox2.Text != "" && !DateDayRegise . sixTwoNumber( textBox2 ) )
            {
                textBox2.Text = "";
                MessageBox.Show( "只允许输入整数部分最多四位,小数部分最多两位,如9999.99,请重新输入" );
            }
        }
        private void textBox3_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise . intgra( e );
        }
        private void textBox4_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise . intgra( e );
        }
        private void bandedGridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( bandedGridView1.FocusedRowHandle >= 0 && bandedGridView1.FocusedRowHandle <= bandedGridView1.RowCount )
            {
                _model.IDX = string.IsNullOrEmpty( bandedGridView1.GetFocusedRowCellValue( "idx" ).ToString( ) ) == true ? 0 : Convert.ToInt32( bandedGridView1.GetFocusedRowCellValue( "idx" ).ToString( ) );
                assign( );
            }
        }
        void assign ( )
        {
            _model = _bll.GetModel( _model.IDX );
            if ( !string.IsNullOrEmpty( _model.RZ001.ToString( ) ) && !string.IsNullOrEmpty( _model.RZ003.ToString( ) ) )
                dateTimePicker1.Value = Convert.ToDateTime( _model.RZ001 + "年" + _model.RZ003 + "月" + "01日" );
            textBox1.Text = _model.RZ002.ToString( );
            textBox2.Text = _model.RZ006.ToString( );
            textBox3.Text = _model.RZ005.ToString( );
            textBox4.Text = _model.RZ008.ToString( );
            textBox5.Text = _model.RZ016.ToString( );
            textBox6.Text = _model.RZ017.ToString( );
        }
        private void textBox5_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise . intgra( e );
        }
        private void textBox6_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise . intgra( e );
        }
        #endregion

    }
}

using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Data;
using System . Drawing;
using System . Linq;
using System . Text;
using System . Windows . Forms;

namespace Mulaolao.Wages
{
    public partial class R_FrmWagesContrastTable : Form
    {
        public R_FrmWagesContrastTable ( )
        {
            InitializeComponent( );

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        MulaolaoLibrary.WagesContrastTableLibrary _model = new MulaolaoLibrary.WagesContrastTableLibrary( );
        MulaolaoBll.Bll.WagesContrastTableBll _bll = new MulaolaoBll.Bll.WagesContrastTableBll( );
        bool result = false;
        DataTable tableQuery;

        private void R_FrmWagesContrastTable_Load ( object sender ,EventArgs e )
        {

        }

        //Generate
        private void button1_Click ( object sender ,EventArgs e )
        {
            _model.VZ001 = dateTimePicker1.Value.Year;
            _model.VZ002 = dateTimePicker1.Value.Month;
            result = _bll.Insert( _model );
            if ( result == true )
            {
                MessageBox.Show( "生成成功" );
                button2_Click( null ,null );
            }
            else
                MessageBox.Show( "生成失败" );
        }

        //Refresh
        private void button2_Click ( object sender ,EventArgs e )
        {
            _model.VZ001 = dateTimePicker1.Value.Year;
            _model.VZ002 = dateTimePicker1.Value.Month;
            tableQuery = _bll.GetDataTable( _model );
            gridControl1.DataSource = tableQuery;
        }

        //Delete
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) ==
DialogResult . Cancel )
                return;
            _model .VZ001 = dateTimePicker1.Value.Year;
            _model.VZ002 = dateTimePicker1.Value.Month;
            result = _bll.Delete( _model );
            if ( result == true )
            {
                MessageBox.Show( "删除数据成功" );
                gridControl1.DataSource = null; 
            }
            else
                MessageBox.Show( "删除数据失败" );
        }
    }
}

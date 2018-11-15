using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SelectAll
{
    public partial class _519BatchGunQi : Form
    {
        public _519BatchGunQi ( )
        {
            InitializeComponent( );
        }
        
        MulaolaoBll.Bll.YouQiBomBll _bll = new MulaolaoBll.Bll.YouQiBomBll( );
        MulaolaoLibrary.YouQiBomLibrary _model = new MulaolaoLibrary.YouQiBomLibrary( );

        public string sign = "";
        bool result = false;
        DataTable tableOnly;

        private void _519BatchGunQi_Load ( object sender ,EventArgs e )
        {
            if ( sign == "Delete" )
            {
                comboBox1.Enabled = comboBox2.Enabled = comboBox3.Enabled = comboBox4.Enabled = comboBox5.Enabled = false;
                comboBox1.Text = textBox1.Text;
                comboBox2.Text = textBox2.Text;
                comboBox3.Text = textBox3.Text;
                comboBox4.Text = textBox4.Text;
                comboBox5.Text = textBox5.Text;
            }
            else
            {
                comboBox1.Enabled = comboBox2.Enabled = comboBox3.Enabled = comboBox4.Enabled = comboBox5.Enabled = true;
               
                tableOnly = _bll.GetDataTableOnly( );
                comboBox1.DataSource = tableOnly.AsEnumerable( ).Select( p => p.Field<string>( "KZ001" ) ).OrderBy( p => p ).Distinct( ).ToList( );
                comboBox1.DisplayMember = "KZ001";
                comboBox2.DataSource = tableOnly.AsEnumerable( ).Select( p => p.Field<string>( "KZ002" ) ).OrderBy( p => p ).Distinct( ).ToList( );
                comboBox2.DisplayMember = "KZ002";
                comboBox3.DataSource = tableOnly.AsEnumerable( ).Select( p => p.Field<string>( "KZ003" ) ).OrderBy( p => p ).Distinct( ).ToList( );
                comboBox3.DisplayMember = "KZ003";
                comboBox4.DataSource = tableOnly.AsEnumerable( ).Select( p => p.Field<decimal>( "KZ007" ) ).OrderBy( p => p ).Distinct( ).ToList( );
                comboBox4.DisplayMember = "KZ007";
                comboBox5.DataSource = tableOnly.AsEnumerable( ).Select( p => p.Field<decimal>( "KZ006" ) ).OrderBy( p => p ).Distinct( ).ToList( );
                comboBox5.DisplayMember = "KZ006";
                if ( sign == "Edit" )
                {
                    comboBox1.Text = textBox1.Text;
                    comboBox2.Text = textBox2.Text;
                    comboBox3.Text = textBox3.Text;
                    comboBox4.Text = textBox4.Text;
                    comboBox5.Text = textBox5.Text;
                }
            }
        }

        #region
        //Sure
        private void button1_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( comboBox1.Text ) )
            {
                MessageBox.Show( "色号与色板间不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox2.Text ) )
            {
                MessageBox.Show( "油漆种类不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox3.Text ) )
            {
                MessageBox.Show( "基材不可为空" );
                return;
            }
            #region BatchBuild
            if ( sign == "Build" )
            {
                _model.KZ001 = comboBox1.Text;
                _model.KZ002 = comboBox2.Text;
                _model.KZ003 = comboBox3.Text;
                result = _bll.Exists( _model.KZ001 ,_model.KZ002 ,_model.KZ003 );
                if ( result == true )
                {
                    MessageBox.Show( "已经存在色号与色板间：" + _model.KZ001 + ",油漆种类：" + _model.KZ002 + ",基材：" + _model.KZ003 + "的记录" );
                    return;
                }
                _model.KZ007 = string.IsNullOrEmpty( comboBox4.Text ) == true ? 0 : Convert.ToDecimal( comboBox4.Text );
                _model.KZ006 = string.IsNullOrEmpty( comboBox5.Text ) == true ? 0 : Convert.ToDecimal( comboBox5.Text );
                result = _bll.batchAdd( textBox1.Text ,textBox2.Text ,textBox3.Text ,_model );
                if ( result == true )
                {
                    MessageBox.Show( "成功批量新建数据" );
                    this.Close( );
                }
                else
                    MessageBox.Show( "批量新建数据失败" );
            }
            #endregion

            #region BatchEdit
            else if ( sign == "Edit" )
            {
                _model.KZ001 = comboBox1.Text;
                _model.KZ002 = comboBox2.Text;
                _model.KZ003 = comboBox3.Text;
                _model.KZ007 = string.IsNullOrEmpty( comboBox4.Text ) == true ? 0 : Convert.ToDecimal( comboBox4.Text );
                _model.KZ006 = string.IsNullOrEmpty( comboBox5.Text ) == true ? 0 : Convert.ToDecimal( comboBox5.Text );
                result = _bll.batchEdit( textBox1.Text ,textBox2.Text ,textBox3.Text ,_model );
                if ( result == true )
                {
                    MessageBox.Show( "批量编辑成功" );
                    this.Close( );
                }
                else
                    MessageBox.Show( "批量编辑失败" );
            }
            #endregion

            #region BatchDelete
            else if ( sign == "Delete" )
            {

                if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) ==

                DialogResult . Cancel )
                    return;
                _model .KZ001 = textBox1.Text;
                _model.KZ002 = textBox2.Text;
                _model.KZ003 = textBox3.Text;
                result = _bll.batchDelete( _model.KZ001 ,_model.KZ002 ,_model.KZ003 );
                if ( result == true )
                {
                    MessageBox.Show( "成功批量删除数据" );
                    this.Close( );
                }
                else
                    MessageBox.Show( "批量删除数据失败" );
            }
            #endregion
        }
        //Cancel
        private void button2_Click ( object sender ,EventArgs e )
        {
            this.Close( );
        }
        #endregion
    }
}

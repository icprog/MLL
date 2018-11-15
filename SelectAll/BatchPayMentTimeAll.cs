using Mulaolao.Class;
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
    public partial class BatchPayMentTimeAll : Form
    {
        public BatchPayMentTimeAll ( )
        {
            InitializeComponent( );
        }

        public string oddNum = "", sign = "";
        
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        MulaolaoBll.Bll.PayMentBll _bll = new MulaolaoBll.Bll.PayMentBll( ); MulaolaoLibrary.PayMentOneLibrary _modelOne = new MulaolaoLibrary.PayMentOneLibrary( );
        MulaolaoLibrary.PayMentLibrary _model = new MulaolaoLibrary.PayMentLibrary( );
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "";
        public string login = "";

        private void BatchPayMentTimeAll_Load ( object sender ,EventArgs e )
        {
            comboBox3 . Visible = label3 . Visible = textBox1 . Visible = dateTimePicker2 . Visible = false;
            comboBox1.Items.Clear( );
            comboBox2.Items.Clear( );
            //comboBox3 . Items . Clear ( );
            if ( login == "MLL-0001" )
            {
                comboBox1 . Items . AddRange ( new string [ ] { "" , "审核" , "执行" } );
                comboBox2 . Items . AddRange ( new string [ ] { "" , "审核" , "执行" } );
                //comboBox3 . Items . AddRange ( new string [ ] { "" , "审核" , "执行" } );
            }
            else
            {
                comboBox1 . Items . AddRange ( new string [ ] { "" , "审核" } );
                comboBox2 . Items . AddRange ( new string [ ] { "" , "审核" } );
                //comboBox3 . Items . AddRange ( new string [ ] { "" , "审核" } );
            }
        }

        //Sure
        private void button1_Click ( object sender ,EventArgs e )
        {
            if ( sign == "1" )
            {
                cn1 = "1";
                if ( tabControl1.SelectedTab.Name == "tabPageOne" )
                {
                    cn2 = comboBox1.Text;
                    cn3 = dateTimePicker1.Value.ToString( );
                    cn4 = cn5 = "";
                    cn6 = "1";
                }
                else
                {
                    cn2 = "";
                    //cn3 = dateTimePicker2.Value.ToString( "yyyy-MM-dd 0:00:00" );
                    cn4 = comboBox2.Text;
                    //cn5 = comboBox3.Text;
                    cn6 = "2";
                }
            }
            if ( sign == "2" )
            {
                cn1 = "2";
                if ( tabControl1.SelectedTab.Name == "tabPageOne" )
                {
                    cn2 = comboBox1.Text;
                    cn3 = dateTimePicker1.Value.ToString( );
                    cn4 = cn5 = "";
                    cn6 = "1";
                }
                else
                {
                    cn2 = "";
                    //cn3 = dateTimePicker2.Value.ToString( "yyyy-MM-dd 0:00:00" );
                    cn4 = comboBox2.Text;
                    //cn5 = comboBox3.Text;
                    cn6 = "2";
                }
            }
            if ( sign == "3" )
            {
                cn1 = "3";
                if ( tabControl1 . SelectedTab . Name == "tabPageOne" )
                {
                    cn2 = comboBox1 . Text;
                    cn3 = dateTimePicker1 . Value . ToString ( );
                    cn4 = cn5 = "";
                    cn6 = "1";
                }
                else
                {
                    cn2 = "";
                    //cn3 = dateTimePicker2.Value.ToString( "yyyy-MM-dd 0:00:00" );
                    cn4 = comboBox2 . Text;
                    //cn5 = comboBox3.Text;
                    cn6 = "2";
                }
            }
            if ( sign == "4" )
            {
                cn1 = "4";
                if ( tabControl1 . SelectedTab . Name == "tabPageOne" )
                {
                    cn2 = comboBox1 . Text;
                    cn3 = dateTimePicker1 . Value . ToString ( );
                    cn4 = cn5 = "";
                    cn6 = "1";
                }
                else
                {
                    cn2 = "";
                    //cn3 = dateTimePicker2.Value.ToString( "yyyy-MM-dd 0:00:00" );
                    cn4 = comboBox2 . Text;
                    //cn5 = comboBox3.Text;
                    cn6 = "2";
                }
            }
            if ( sign == "5" )
            {
                cn1 = "5";
                if ( tabControl1 . SelectedTab . Name == "tabPageOne" )
                {
                    cn2 = comboBox1 . Text;
                    cn3 = dateTimePicker1 . Value . ToString ( );
                    cn4 = cn5 = "";
                    cn6 = "1";
                }
                else
                {
                    cn2 = "";
                    //cn3 = dateTimePicker2.Value.ToString( "yyyy-MM-dd 0:00:00" );
                    cn4 = comboBox2 . Text;
                    //cn5 = comboBox3.Text;
                    cn6 = "2";
                }
            }
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }
        //Close
        private void button2_Click ( object sender ,EventArgs e )
        {
            this.Close( );
        }

        private void dateTimePicker2_ValueChanged ( object sender ,EventArgs e )
        {
            textBox1.Text = dateTimePicker2.Value.ToString( "yyyy年MM月dd日" );
        }
        private void textBox1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            if ( e.KeyChar == 8 )
                textBox1.Text = "";
            else
                e.Handled = true;
        }
    }
}

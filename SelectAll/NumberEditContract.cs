using Mulaolao;
using Mulaolao . Class;
using System;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class NumberEditContract : Form
    {
        public NumberEditContract ( )
        {
            InitializeComponent( );
        }

        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        public long number = 0;

        string cn1 = "", cn2 = "";
        //Sure
        private void button1_Click ( object sender ,EventArgs e )
        {
            cn1 = textBox1.Text;
            cn2 = "yes";
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }

        //Cancel
        private void button2_Click ( object sender ,EventArgs e )
        {
            cn1 = "";
            cn2 = "no";
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }

        private void NumberEditContract_Load ( object sender ,EventArgs e )
        {

        }

        //Event
        private void textBox1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            if ( ( e.KeyChar < 48 || e.KeyChar > 57 ) && e.KeyChar != 8 )
            {
                e.Handled = true;
                MessageBox.Show( "只允许输入整数" );
            }
        }
    }
}

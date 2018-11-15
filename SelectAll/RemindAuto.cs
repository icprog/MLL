using Mulaolao . Class;
using System;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class RemindAuto : Form
    {
        public RemindAuto ( )
        {
            InitializeComponent( );
        }
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;

        string cn1 = "";

        private void RemindAuto_Load ( object sender ,EventArgs e )
        {

        }

        private void textBox1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            if ( ( e.KeyChar < 48 || e.KeyChar > 57 ) && e.KeyChar != 8 )
            {
                e.Handled = true;
                MessageBox.Show( "只允许输入整数" );
            }
        }

        private void button1_Click ( object sender ,EventArgs e )
        {
            cn1 = textBox1.Text;
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }

        private void button2_Click ( object sender ,EventArgs e )
        {
            this.Close( );
        }
    }
}

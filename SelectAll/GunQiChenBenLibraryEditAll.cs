using System;
using System . Windows . Forms;
using Mulaolao . Class;
using Mulaolao;

namespace SelectAll
{
    public partial class GunQiChenBenLibraryEditAll :Form
    {
        public GunQiChenBenLibraryEditAll ( )
        {
            InitializeComponent ( );
        }
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;

        string cn1="",cn2="";

        //Sure
        private void button1_Click ( object sender ,EventArgs e )
        {
            cn1 = textBox1 . Text;
            cn2 = "1";
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs ( cn1 ,cn2 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm ( this ,args );
            }
            this . Close ( );
        }
        //Cancel
        private void button2_Click ( object sender ,EventArgs e )
        {
            cn1 = textBox1 . Text;
            cn2 = "2";
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs ( cn1 ,cn2 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm ( this ,args );
            }
            this . Close ( );
        }

        private void GunQiChenBenLibraryEditAll_FormClosing ( object sender ,FormClosingEventArgs e )
        {

        }

        private void textBox1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay . fractionTb ( e ,textBox1 );
        }

        private void textBox1_TextChanged ( object sender ,EventArgs e )
        {
            DateDay . textChangeTb ( textBox1 );
        }
        
    }
}

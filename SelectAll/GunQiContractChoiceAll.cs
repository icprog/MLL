using Mulaolao;
using Mulaolao . Class;
using System;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class GunQiContractChoiceAll : Form
    {
        public GunQiContractChoiceAll ( )
        {
            InitializeComponent( );
        }
        MulaolaoBll.Bll.GunQiContractBll bll = new MulaolaoBll.Bll.GunQiContractBll( );
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        string cn1 = "";

        //Sure
        private void button1_Click ( object sender ,EventArgs e )
        {
            if ( !radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked)
            {
                MessageBox.Show( "请选择打印模板" );
                return;
            }
            if ( radioButton1.Checked )
                cn1 = "1";
            else if ( radioButton2.Checked )
                cn1 = "2";
            else if ( radioButton3.Checked )
                cn1 = "3";
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }

        //Cancel
        private void button2_Click ( object sender ,EventArgs e )
        {
            this.Close( );
        }

        private void GunQiContractChoiceAll_Load ( object sender ,EventArgs e )
        {

        }
    }
}

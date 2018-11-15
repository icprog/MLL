using Mulaolao;
using Mulaolao . Class;
using System;
using System . Drawing;
using System . Runtime . InteropServices;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class ProductContractProcessAll : Form
    {
        public ProductContractProcessAll ( )
        {
            InitializeComponent( );
            textBoxKeypress( );
        }

        MulaolaoBll.Bll.ProductCostSummaryBll bll = new MulaolaoBll.Bll.ProductCostSummaryBll( );
        MulaolaoLibrary.ProductCostSummaryLibrary model = new MulaolaoLibrary.ProductCostSummaryLibrary( );
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        decimal unitPrice;
        bool result = false;
        string cn1 = "", cn2 = "";

        public int id = 0;

        private void ProductContractProcessAll_Load ( object sender ,EventArgs e )
        {
            this.MouseDown += new System.Windows.Forms.MouseEventHandler( Form_MouseDown );
            this.MouseMove += new System.Windows.Forms.MouseEventHandler( Form_MouseMove );
            this.MouseUp += new System.Windows.Forms.MouseEventHandler( Form_MouseUp );

            model = bll.GetModel( id );
            textBox79.Text = model.AM070.ToString( );
            textBox78.Text = model.AM071.ToString( );
            textBox84.Text = model.AM072.ToString( );
            textBox83.Text = model.AM073.ToString( );
            textBox86.Text = model.AM074.ToString( );
            textBox85.Text = model.AM075.ToString( );
            textBox88.Text = model.AM076.ToString( );
            textBox87.Text = model.AM077.ToString( );
            textBox90.Text = model.AM078.ToString( );
            textBox89.Text = model.AM079.ToString( );
            textBox92.Text = model.AM080.ToString( );
            textBox91.Text = model.AM081.ToString( );
            textBox94.Text = model.AM082.ToString( );
            textBox93.Text = model.AM083.ToString( );
            textBox96.Text = model.AM084.ToString( );
            textBox95.Text = model.AM085.ToString( );
            textBox98.Text = model.AM086.ToString( );
            textBox97.Text = model.AM087.ToString( );
            textBox100.Text = model.AM088.ToString( );
            textBox99.Text = model.AM089.ToString( );
            textBox102.Text = model.AM090.ToString( );
            textBox101.Text = model.AM091.ToString( );
            textBox104.Text = model.AM092.ToString( );
            textBox103.Text = model.AM093.ToString( );
        }

        #region FormEvent
        Point mouseOff;//鼠标移动位置变量  
        bool leftFlag;//标签是否为左键  
        private void Form_MouseDown ( object sender ,MouseEventArgs e )
        {
            if ( e.Button == MouseButtons.Left )
            {
                mouseOff = new Point( -e.X ,-e.Y ); //得到变量的值  
                leftFlag = true;                  //点击左键按下时标注为true;  
            }
        }
        private void Form_MouseMove ( object sender ,MouseEventArgs e )
        {
            if ( leftFlag )
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset( mouseOff.X ,mouseOff.Y );  //设置移动后的位置  
                //( ( ( /*System.Windows.Forms.PictureBox*/ ) sender ).Parent ).Location = mouseSet;
                this.Location = mouseSet;
            }
        }
        private void Form_MouseUp ( object sender ,MouseEventArgs e )
        {
            if ( leftFlag )
            {
                leftFlag = false;//释放鼠标后标注为false;  
            }
        }

        [DllImport( "user32.dll" )]
        public static extern bool ReleaseCapture ( );
        [DllImport( "user32.dll" )]
        public static extern bool SendMessage ( IntPtr hwnd ,int wMsg ,int wParam ,int lParam );
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        private void Form1_MouseDown ( object sender ,System.Windows.Forms.MouseEventArgs e )
        {
            ReleaseCapture( );
            SendMessage( this.Handle ,WM_SYSCOMMAND ,SC_MOVE + HTCAPTION ,0 );
        }
        #endregion

        #region BoxEvent
        void textBoxKeypress ( )
        {
            foreach ( Control item in this.Controls )
            {
                if ( item.GetType( ) == typeof( GroupBox ) )
                {
                    GroupBox box = item as GroupBox;
                    foreach ( Control bo in box.Controls )
                    {
                        if ( bo.GetType( ) == typeof( TextBox ) )
                        {
                            TextBox text = bo as TextBox;

                            text.KeyPress += new KeyPressEventHandler( textBox_KeyPress );
                            text.TextChanged += new EventHandler( textBox_TextChanged );
                            text.LostFocus += new EventHandler( textBox_LostFocus );
                        }
                    }
                }
            }
        }
        private void textBox_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            TextBox box = ( TextBox ) sender;
            DateDay.fractionTb( e ,box );
        }
        private void textBox_TextChanged ( object sender ,EventArgs e )
        {
            TextBox box = ( TextBox ) sender;
            DateDay.textChangeTb( box );
        }
        private void textBox_LostFocus ( object sender ,EventArgs e )
        {
            TextBox box = ( TextBox ) sender;
            if ( box.Text != "" && !DateDay.tenTwoNumber( box ) )
            {
                box.Text = "";
                MessageBox.Show( "只允许输入整数部分最多八位,小数部分最多两位,如99999999.99,请重新输入" );
            }
        }
        #endregion

        #region Value
        void assignMent ( )
        {
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox79.Text ) ? "0" : textBox79.Text ,out unitPrice );
            model.AM070 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox78.Text ) ? "0" : textBox78.Text ,out unitPrice );
            model.AM071 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox84.Text ) ? "0" : textBox84.Text ,out unitPrice );
            model.AM072 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox83.Text ) ? "0" : textBox83.Text ,out unitPrice );
            model.AM073 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox86.Text ) ? "0" : textBox86.Text ,out unitPrice );
            model.AM074 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox85.Text ) ? "0" : textBox85.Text ,out unitPrice );
            model.AM075 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox88.Text ) ? "0" : textBox88.Text ,out unitPrice );
            model.AM076 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox87.Text ) ? "0" : textBox87.Text ,out unitPrice );
            model.AM077 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox90.Text ) ? "0" : textBox90.Text ,out unitPrice );
            model.AM078 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox89.Text ) ? "0" : textBox89.Text ,out unitPrice );
            model.AM079 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox92.Text ) ? "0" : textBox92.Text ,out unitPrice );
            model.AM080 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox91.Text ) ? "0" : textBox91.Text ,out unitPrice );
            model.AM081 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox94.Text ) ? "0" : textBox94.Text ,out unitPrice );
            model.AM082 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox93.Text ) ? "0" : textBox93.Text ,out unitPrice );
            model.AM083 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox96.Text ) ? "0" : textBox96.Text ,out unitPrice );
            model.AM084 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox95.Text ) ? "0" : textBox95.Text ,out unitPrice );
            model.AM085 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox98.Text ) ? "0" : textBox98.Text ,out unitPrice );
            model.AM086 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox97.Text ) ? "0" : textBox97.Text ,out unitPrice );
            model.AM087 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox100.Text ) ? "0" : textBox100.Text ,out unitPrice );
            model.AM088 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox99.Text ) ? "0" : textBox99.Text ,out unitPrice );
            model.AM089 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox102.Text ) ? "0" : textBox102.Text ,out unitPrice );
            model.AM090 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox101.Text ) ? "0" : textBox101.Text ,out unitPrice );
            model.AM091 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox104.Text ) ? "0" : textBox104.Text ,out unitPrice );
            model.AM092 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox103.Text ) ? "0" : textBox103.Text ,out unitPrice );
            model.AM093 = unitPrice;
        }
        //Sure
        private void button1_Click ( object sender ,EventArgs e )
        {
            assignMent( );
            result = bll.ContractProcess( model );
            if ( result == true )
                cn1 = "1";
            else
                cn1 = "2";
            cn2 = "1";

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
            cn1 = cn2 = "";
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }
        #endregion
    }
}

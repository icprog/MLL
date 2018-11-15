using Mulaolao;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Drawing;
using System . Runtime . InteropServices;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class ProductFinishedProductOutsourcingAll : Form
    {
        public ProductFinishedProductOutsourcingAll ( )
        {
            InitializeComponent( );

            boxLis ( );
            textBoxKeypress( );
        }

        MulaolaoBll.Bll.ProductCostSummaryBll bll = new MulaolaoBll.Bll.ProductCostSummaryBll( );
        MulaolaoLibrary.ProductCostSummaryLibrary model = new MulaolaoLibrary.ProductCostSummaryLibrary( );
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        decimal unitPrice;
        bool result = false;
        string cn1 = "", cn2 = "";
        List<TextBox> boxList = new List<TextBox>( );

        public int id = 0;

        private void ProductFinishedProductOutsourcingAll_Load ( object sender ,EventArgs e )
        {
            this.MouseDown += new System.Windows.Forms.MouseEventHandler( Form_MouseDown );
            this.MouseMove += new System.Windows.Forms.MouseEventHandler( Form_MouseMove );
            this.MouseUp += new System.Windows.Forms.MouseEventHandler( Form_MouseUp );

            model = bll.GetModel( id );
            textBox120.Text = model.AM108.ToString( );
            textBox119.Text = model.AM109.ToString( );
            textBox126.Text = model.AM110.ToString( );
            textBox1.Text = model.AM113.ToString( );
            textBox125.Text = model.AM111.ToString( );
            textBox124.Text = model.AM112.ToString( );
            textBox127.Text = model.AM115.ToString( );
            textBox2.Text = model.AM116.ToString( );
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
        void boxLis ( )
        {
            boxList.Clear( );
            boxList.Add( textBox126 );
            boxList.Add( textBox127 );
        }
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
                            if ( !boxList.Contains( text ) )
                            {
                                text.KeyPress += new KeyPressEventHandler( textBox_KeyPress );
                                text.TextChanged += new EventHandler( textBox_TextChanged );
                                text.LostFocus += new EventHandler( textBox_LostFocus );
                            }
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
            decimal.TryParse( string.IsNullOrEmpty( textBox120.Text ) ? "0" : textBox120.Text ,out unitPrice );
            model.AM108 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox119.Text ) ? "0" : textBox119.Text ,out unitPrice );
            model.AM109 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox126.Text ) ? "0" : textBox126.Text ,out unitPrice );
            model.AM110 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox1.Text ) ? "0" : textBox1.Text ,out unitPrice );
            model.AM113 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox125.Text ) ? "0" : textBox125.Text ,out unitPrice );
            model.AM111 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox124.Text ) ? "0" : textBox124.Text ,out unitPrice );
            model.AM112 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox127.Text ) ? "0" : textBox127.Text ,out unitPrice );
            model.AM115 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox2.Text ) ? "0" : textBox2.Text ,out unitPrice );
            model.AM116 = unitPrice;
            model.AM114 = "";
        }
        //Sure
        private void button1_Click ( object sender ,EventArgs e )
        {
            assignMent( );
            result = bll.FinishedProductOutsourcing( model );
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

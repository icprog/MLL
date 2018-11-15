using Mulaolao;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Drawing;
using System . Runtime . InteropServices;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class ProductGunPaintAll : Form
    {
        public ProductGunPaintAll ( )
        {
            InitializeComponent( );

            boxLi ( );
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

        private void ProductGunPaintAll_Load ( object sender ,EventArgs e )
        {
            this.MouseDown += new System.Windows.Forms.MouseEventHandler( Form_MouseDown );
            this.MouseMove += new System.Windows.Forms.MouseEventHandler( Form_MouseMove );
            this.MouseUp += new System.Windows.Forms.MouseEventHandler( Form_MouseUp );

            model = bll.GetModel( id );
            textBox262.Text = model.AM239.ToString( );
            textBox261.Text = model.AM240.ToString( );
            textBox260.Text = model.AM241.ToString( );
            textBox1.Text = model.AM244.ToString( );
            textBox268.Text = model.AM242.ToString( );
            textBox267.Text = model.AM243.ToString( );
            textBox266.Text = model.AM247.ToString( );
            textBox4.Text = model.AM251.ToString( );
            textBox271.Text = model.AM245.ToString( );
            textBox270.Text = model.AM246.ToString( );
            textBox269.Text = model.AM252.ToString( );
            textBox5.Text = model.AM253.ToString( );
            textBox3.Text = model.AM249.ToString( );
            textBox2.Text = model.AM250.ToString( );
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
        void boxLi ( )
        {
            boxList.Clear( );
            boxList.Add( textBox260 );
            boxList.Add( textBox266 );
            boxList.Add( textBox269 );
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
            decimal.TryParse( string.IsNullOrEmpty( textBox262.Text ) ? "0" : textBox262.Text ,out unitPrice );
            model.AM239 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox261.Text ) ? "0" : textBox261.Text ,out unitPrice );
            model.AM240 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox260.Text ) ? "0" : textBox260.Text ,out unitPrice );
            model.AM241 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox1.Text ) ? "0" : textBox1.Text ,out unitPrice );
            model.AM244 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox268.Text ) ? "0" : textBox268.Text ,out unitPrice );
            model.AM242 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox267.Text ) ? "0" : textBox267.Text ,out unitPrice );
            model.AM243 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox266.Text ) ? "0" : textBox266.Text ,out unitPrice );
            model.AM247 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox4.Text ) ? "0" : textBox4.Text ,out unitPrice );
            model.AM251 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox271.Text ) ? "0" : textBox271.Text ,out unitPrice );
            model.AM245 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox270.Text ) ? "0" : textBox270.Text ,out unitPrice );
            model.AM246 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox269.Text ) ? "0" : textBox269.Text ,out unitPrice );
            model.AM252 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox5.Text ) ? "0" : textBox5.Text ,out unitPrice );
            model.AM253 = unitPrice;
            model . AM248 = 0;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox3.Text ) ? "0" : textBox3.Text ,out unitPrice );
            model.AM249 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox2.Text ) ? "0" : textBox2.Text ,out unitPrice );
            model.AM250 = unitPrice;
        }
        //Sure
        private void button1_Click ( object sender ,EventArgs e )
        {
            assignMent( );
            result = bll.GunPaint( model );
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

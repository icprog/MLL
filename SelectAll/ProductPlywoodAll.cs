using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Drawing;
using System . Runtime . InteropServices;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class ProductPlywoodAll : Form
    {
        public ProductPlywoodAll ( )
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

        private void ProductPlywoodAll_Load ( object sender ,EventArgs e )
        {
            this.MouseDown += new System.Windows.Forms.MouseEventHandler( Form_MouseDown );
            this.MouseMove += new System.Windows.Forms.MouseEventHandler( Form_MouseMove );
            this.MouseUp += new System.Windows.Forms.MouseEventHandler( Form_MouseUp );

            model = bll.GetModel( id );
            textBox325.Text = model.AM298.ToString( );
            textBox324.Text = model.AM299.ToString( );
            textBox323.Text = model.AM300.ToString( );
            textBox1.Text = model.AM303.ToString( );
            textBox331.Text = model.AM301.ToString( );
            textBox330.Text = model.AM302.ToString( );
            textBox329.Text = model.AM306.ToString( );
            textBox2.Text = model.AM309.ToString( );
            textBox334.Text = model.AM304.ToString( );
            textBox333.Text = model.AM305.ToString( );
            textBox332.Text = model.AM313.ToString( );
            textBox3.Text = model.AM317.ToString( );
            textBox337.Text = model.AM307.ToString( );
            textBox336.Text = model.AM308.ToString( );
            textBox335.Text = model.AM320.ToString( );
            textBox5.Text= model.AM323.ToString( );
            textBox340.Text = model.AM311.ToString( );
            textBox339.Text = model.AM312.ToString( );
            textBox338.Text = model.AM324.ToString( );
            textBox6.Text = model.AM325.ToString( );
            textBox43.Text = model.AM315.ToString( );
            textBox42.Text = model.AM316.ToString( );
            textBox41.Text = model.AM326.ToString( );
            textBox7.Text = model.AM327.ToString( );
            textBox37.Text = model.AM318.ToString( );
            textBox36.Text = model.AM319.ToString( );
            textBox35.Text = model.AM328.ToString( );
            textBox4.Text = model.AM329.ToString( );
            textBox40.Text = model.AM321.ToString( );
            textBox39.Text = model.AM322.ToString( );
            textBox38.Text = model.AM296.ToString( );
            textBox8.Text = model.AM297.ToString( );
        }

        #region Value
        void assignMent ( )
        {
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox325.Text ) ? "0" : textBox325.Text ,out unitPrice );
            model.AM298 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox324.Text ) ? "0" : textBox324.Text ,out unitPrice );
            model.AM299 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox323.Text ) ? "0" : textBox323.Text ,out unitPrice );
            model.AM300 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox1.Text ) ? "0" : textBox1.Text ,out unitPrice );
            model.AM303 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox331.Text ) ? "0" : textBox331.Text ,out unitPrice );
            model.AM301 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox330.Text ) ? "0" : textBox330.Text ,out unitPrice );
            model.AM302 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox329.Text ) ? "0" : textBox329.Text ,out unitPrice );
            model.AM306 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox2.Text ) ? "0" : textBox2.Text ,out unitPrice );
            model.AM309 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox334.Text ) ? "0" : textBox334.Text ,out unitPrice );
            model.AM304 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox333.Text ) ? "0" : textBox333.Text ,out unitPrice );
            model.AM305 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox332.Text ) ? "0" : textBox332.Text ,out unitPrice );
            model.AM313 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox3.Text ) ? "0" : textBox3.Text ,out unitPrice );
            model.AM317 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox337.Text ) ? "0" : textBox337.Text ,out unitPrice );
            model.AM307 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox336.Text ) ? "0" : textBox336.Text ,out unitPrice );
            model.AM308 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox335.Text ) ? "0" : textBox335.Text ,out unitPrice );
            model.AM320 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox5.Text ) ? "0" : textBox5.Text ,out unitPrice );
            model.AM323 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox340.Text ) ? "0" : textBox340.Text ,out unitPrice );
            model.AM311 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox339.Text ) ? "0" : textBox339.Text ,out unitPrice );
            model.AM312 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox338.Text ) ? "0" : textBox338.Text ,out unitPrice );
            model.AM324 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox6.Text ) ? "0" : textBox6.Text ,out unitPrice );
            model.AM325 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox43.Text ) ? "0" : textBox43.Text ,out unitPrice );
            model.AM315 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox42.Text ) ? "0" : textBox42.Text ,out unitPrice );
            model.AM316 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox41.Text ) ? "0" : textBox41.Text ,out unitPrice );
            model.AM326 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox7.Text ) ? "0" : textBox7.Text ,out unitPrice );
            model.AM327 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox37.Text ) ? "0" : textBox37.Text ,out unitPrice );
            model.AM318 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox36.Text ) ? "0" : textBox36.Text ,out unitPrice );
            model.AM319 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox35.Text ) ? "0" : textBox35.Text ,out unitPrice );
            model.AM328 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox4.Text ) ? "0" : textBox4.Text ,out unitPrice );
            model.AM329 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox40.Text ) ? "0" : textBox40.Text ,out unitPrice );
            model.AM321 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox39.Text ) ? "0" : textBox39.Text ,out unitPrice );
            model.AM322 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox38.Text ) ? "0" : textBox38.Text ,out unitPrice );
            model.AM328 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox8.Text ) ? "0" : textBox8.Text ,out unitPrice );
            model.AM329 = unitPrice;
        }
        //Sure
        private void button1_Click ( object sender ,EventArgs e )
        {
            assignMent( );
            model.Idx = id;
            result = bll.Plywood( model );
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
            boxList.Add( textBox323 );
            boxList.Add( textBox329 );
            boxList.Add( textBox332 );
            boxList.Add( textBox335 );
            boxList.Add( textBox338 );
            boxList.Add( textBox41 );
            boxList.Add( textBox35 );
            boxList.Add( textBox38 );
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
    }
}

using Mulaolao;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Drawing;
using System . Runtime . InteropServices;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class ProductLron : Form
    {
        public ProductLron ( )
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
        public string num = "";

        private void ProductLron_Load ( object sender , EventArgs e )
        {
            this . MouseDown += new System . Windows . Forms . MouseEventHandler ( Form_MouseDown );
            this . MouseMove += new System . Windows . Forms . MouseEventHandler ( Form_MouseMove );
            this . MouseUp += new System . Windows . Forms . MouseEventHandler ( Form_MouseUp );

            model = bll . GetModel ( id );
            textBox229 . Text = model . AM209 . ToString ( );
            textBox228 . Text = model . AM210 . ToString ( );
            textBox227 . Text = model . AM211 . ToString ( );
            textBox4 . Text = model . AM214 . ToString ( );
            textBox235 . Text = model . AM212 . ToString ( );
            textBox234 . Text = model . AM213 . ToString ( );
            textBox233 . Text = model . AM217 . ToString ( );
            textBox5 . Text = model . AM220 . ToString ( );
            textBox238 . Text = model . AM215 . ToString ( );
            textBox237 . Text = model . AM216 . ToString ( );
            textBox236 . Text = model . AM221 . ToString ( );
            textBox6 . Text = model . AM222 . ToString ( );
            textBox3 . Text = model . AM218 . ToString ( );
            textBox2 . Text = model . AM219 . ToString ( );
            textBox1 . Text = model . AM223 . ToString ( );
            textBox7 . Text = model . AM224 . ToString ( );
            textBox23 . Text = model . AM225 . ToString ( );
            textBox22 . Text = model . AM226 . ToString ( );
            textBox21 . Text = model . AM227 . ToString ( );
            textBox20 . Text = model . AM228 . ToString ( );
            textBox19 . Text = model . AM229 . ToString ( );
            textBox18 . Text = model . AM230 . ToString ( );
            textBox17 . Text = model . AM231 . ToString ( );
            textBox16 . Text = model . AM232 . ToString ( );
            textBox15 . Text = model . AM233 . ToString ( );
            textBox14 . Text = model . AM234 . ToString ( );
            textBox13 . Text = model . AM235 . ToString ( );
            textBox12 . Text = model . AM236 . ToString ( );
            textBox11 . Text = model . AM237 . ToString ( );
            textBox10 . Text = model . AM238 . ToString ( );
            textBox9 . Text = model . AM255 . ToString ( );
            textBox8 . Text = model . AM256 . ToString ( );
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
            boxList.Add( textBox227 );
            boxList.Add( textBox233 );
            boxList.Add( textBox236 );
            boxList.Add( textBox1 );
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
            decimal.TryParse( string.IsNullOrEmpty( textBox229.Text ) ? "0" : textBox229.Text ,out unitPrice );
            model.AM209 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox228.Text ) ? "0" : textBox228.Text ,out unitPrice );
            model.AM210 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox227.Text ) ? "0" : textBox227.Text ,out unitPrice );
            model.AM211 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox4.Text ) ? "0" : textBox4.Text ,out unitPrice );
            model.AM214 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox235.Text ) ? "0" : textBox235.Text ,out unitPrice );
            model.AM212 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox234.Text ) ? "0" : textBox234.Text ,out unitPrice );
            model.AM213 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox233.Text ) ? "0" : textBox233.Text ,out unitPrice );
            model.AM217 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox5.Text ) ? "0" : textBox5.Text ,out unitPrice );
            model.AM220 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox238.Text ) ? "0" : textBox238.Text ,out unitPrice );
            model.AM215 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox237.Text ) ? "0" : textBox237.Text ,out unitPrice );
            model.AM216 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox236.Text ) ? "0" : textBox236.Text ,out unitPrice );
            model.AM221 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox6.Text ) ? "0" : textBox6.Text ,out unitPrice );
            model.AM222 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox3.Text ) ? "0" : textBox3.Text ,out unitPrice );
            model.AM218 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox2.Text ) ? "0" : textBox2.Text ,out unitPrice );
            model.AM219 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox1.Text ) ? "0" : textBox1.Text ,out unitPrice );
            model.AM223 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox7.Text ) ? "0" : textBox7.Text ,out unitPrice );
            model.AM224 = unitPrice;
            unitPrice = 0M;
            decimal . TryParse ( string . IsNullOrEmpty ( textBox23 . Text ) ? "0" : textBox23 . Text , out unitPrice );
            model . AM225 = unitPrice;
            unitPrice = 0M;
            decimal . TryParse ( string . IsNullOrEmpty ( textBox22 . Text ) ? "0" : textBox22 . Text , out unitPrice );
            model . AM226 = unitPrice;
            unitPrice = 0M;
            decimal . TryParse ( string . IsNullOrEmpty ( textBox21 . Text ) ? "0" : textBox21 . Text , out unitPrice );
            model . AM227 = unitPrice;
            unitPrice = 0M;
            decimal . TryParse ( string . IsNullOrEmpty ( textBox20 . Text ) ? "0" : textBox20 . Text , out unitPrice );
            model . AM228 = unitPrice;
            unitPrice = 0M;
            decimal . TryParse ( string . IsNullOrEmpty ( textBox19 . Text ) ? "0" : textBox19 . Text , out unitPrice );
            model . AM229 = unitPrice;
            unitPrice = 0M;
            decimal . TryParse ( string . IsNullOrEmpty ( textBox18 . Text ) ? "0" : textBox18 . Text , out unitPrice );
            model . AM230 = unitPrice;
            unitPrice = 0M;
            decimal . TryParse ( string . IsNullOrEmpty ( textBox17 . Text ) ? "0" : textBox17 . Text , out unitPrice );
            model . AM231 = unitPrice;
            unitPrice = 0M;
            decimal . TryParse ( string . IsNullOrEmpty ( textBox16 . Text ) ? "0" : textBox16 . Text , out unitPrice );
            model . AM232 = unitPrice;
            unitPrice = 0M;
            decimal . TryParse ( string . IsNullOrEmpty ( textBox15 . Text ) ? "0" : textBox15 . Text , out unitPrice );
            model . AM233 = unitPrice;
            unitPrice = 0M;
            decimal . TryParse ( string . IsNullOrEmpty ( textBox14 . Text ) ? "0" : textBox14 . Text , out unitPrice );
            model . AM234 = unitPrice;
            unitPrice = 0M;
            decimal . TryParse ( string . IsNullOrEmpty ( textBox13 . Text ) ? "0" : textBox13 . Text , out unitPrice );
            model . AM235 = unitPrice;
            unitPrice = 0M;
            decimal . TryParse ( string . IsNullOrEmpty ( textBox12 . Text ) ? "0" : textBox12 . Text , out unitPrice );
            model . AM236 = unitPrice;
            unitPrice = 0M;
            decimal . TryParse ( string . IsNullOrEmpty ( textBox11 . Text ) ? "0" : textBox11 . Text , out unitPrice );
            model . AM237 = unitPrice;
            unitPrice = 0M;
            decimal . TryParse ( string . IsNullOrEmpty ( textBox10 . Text ) ? "0" : textBox10 . Text , out unitPrice );
            model . AM238 = unitPrice;
            unitPrice = 0M;
            decimal . TryParse ( string . IsNullOrEmpty ( textBox9 . Text ) ? "0" : textBox9 . Text , out unitPrice );
            model . AM255 = unitPrice;
            unitPrice = 0M;
            decimal . TryParse ( string . IsNullOrEmpty ( textBox8 . Text ) ? "0" : textBox8 . Text , out unitPrice );
            model . AM256 = unitPrice;
        }
        //Sure
        private void button1_Click ( object sender ,EventArgs e )
        {
            assignMent( );
            result = bll.Lron( model );
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
        //Read
        private void button3_Click ( object sender ,EventArgs e )
        {
            //DataTable readTable=bll
            SelectAll.ProductLronAll productLron = new ProductLronAll( );
            productLron.StartPosition = FormStartPosition.CenterScreen;
            productLron.PassDataBetweenForm += new ProductLronAll.PassDataBetweenFormHandler( suLiaoBucontract_PassDataBetweenForm );
            productLron.num = num;
            productLron.ShowDialog( );
        }
        void suLiaoBucontract_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            textBox235.Text = e.ConOne.ToString( );
            textBox234.Text = e.ConTwo.ToString( );
            textBox233.Text = e.ConTre;
            textBox3.Text = e.ConFor.ToString( );
            textBox2.Text = e.ConFiv.ToString( );
            textBox1.Text = e.ConSix;
            textBox238.Text = e.ConSev.ToString( );
            textBox237.Text = e.ConEgi.ToString( );
            textBox236.Text = e.ConNin;
        }
        #endregion
    }
}

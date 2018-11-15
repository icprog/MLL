using Mulaolao;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Drawing;
using System . Runtime . InteropServices;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class ProductPaintAll : Form
    {
        public ProductPaintAll ( )
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

        private void ProductPaintAll_Load ( object sender ,EventArgs e )
        {
            this.MouseDown += new System.Windows.Forms.MouseEventHandler( Form_MouseDown );
            this.MouseMove += new System.Windows.Forms.MouseEventHandler( Form_MouseMove );
            this.MouseUp += new System.Windows.Forms.MouseEventHandler( Form_MouseUp );

            model = bll.GetModel( id );
            textBox193.Text = model.AM175.ToString( );
            textBox192.Text = model.AM176.ToString( );
            textBox191.Text = model.AM177.ToString( );
            textBox13.Text = model.AM180.ToString( );
            textBox199.Text = model.AM178.ToString( );
            textBox198.Text = model.AM179.ToString( );
            textBox197.Text = model.AM184.ToString( );
            textBox14.Text = model.AM187.ToString( );
            textBox202.Text = model.AM182.ToString( );
            textBox201.Text = model.AM183.ToString( );
            textBox200.Text = model.AM190.ToString( );
            textBox15.Text = model.AM193.ToString( );
            textBox205.Text = model.AM185.ToString( );
            textBox204.Text = model.AM186.ToString( );
            textBox203.Text = model.AM196.ToString( );
            textBox16.Text = model.AM199.ToString( );
            textBox3.Text = model.AM188.ToString( );
            textBox2.Text = model.AM189.ToString( );
            textBox1.Text = model.AM200.ToString( );
            textBox17.Text = model.AM201.ToString( );
            textBox6.Text = model.AM191.ToString( );
            textBox5.Text = model.AM192.ToString( );
            textBox4.Text = model.AM203.ToString( );
            textBox18.Text = model.AM204.ToString( );
            textBox9.Text = model.AM194.ToString( );
            textBox8.Text = model.AM195.ToString( );
            textBox7.Text = model.AM205.ToString( );
            textBox19.Text = model.AM206.ToString( );
            textBox12.Text = model.AM197.ToString( );
            textBox11.Text = model.AM198.ToString( );
            textBox10.Text = model.AM207.ToString( );
            textBox20.Text = model.AM208.ToString( );
            textBox21 . Text = model . AM173 . ToString ( );
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
            boxList.Add( textBox191 );
            boxList . Add ( textBox192 );
            boxList . Add ( textBox193 );
            boxList . Add ( textBox197 );
            boxList . Add ( textBox198 );
            boxList . Add ( textBox199 );
            boxList . Add ( textBox200 );
            boxList . Add ( textBox201 );
            boxList . Add ( textBox202 );
            boxList . Add ( textBox203 );
            boxList . Add ( textBox204 );
            boxList . Add ( textBox205 );
            boxList . Add ( textBox1 );
            boxList . Add ( textBox2 );
            boxList . Add ( textBox3 );
            boxList . Add ( textBox4 );
            boxList . Add ( textBox5 );
            boxList . Add ( textBox6 );
            boxList . Add ( textBox7 );
            boxList . Add ( textBox8 );
            boxList . Add ( textBox9 );
            boxList . Add ( textBox10 );
            boxList . Add ( textBox11 );
            boxList . Add ( textBox12 );
            boxList . Add ( textBox13 );
            boxList . Add ( textBox14 );
            boxList . Add ( textBox15 );
            boxList . Add ( textBox16 );
            boxList . Add ( textBox17 );
            boxList . Add ( textBox18 );
            boxList . Add ( textBox19 );
            boxList . Add ( textBox20 );
            boxList . Add ( textBox21 );
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

        #region Values
        void assignMent ( )
        {
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox193.Text ) ? "0" : textBox193.Text ,out unitPrice );
            model.AM175 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox192.Text ) ? "0" : textBox192.Text ,out unitPrice );
            model.AM176 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox191.Text ) ? "0" : textBox191.Text ,out unitPrice );
            model.AM177 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox13.Text ) ? "0" : textBox13.Text ,out unitPrice );
            model.AM180 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox199.Text ) ? "0" : textBox199.Text ,out unitPrice );
            model.AM178 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox198.Text ) ? "0" : textBox198.Text ,out unitPrice );
            model.AM179 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox197.Text ) ? "0" : textBox197.Text ,out unitPrice );
            model.AM184 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox14.Text ) ? "0" : textBox14.Text ,out unitPrice );
            model.AM187 = unitPrice;
            model.AM181 = "";
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox202.Text ) ? "0" : textBox202.Text ,out unitPrice );
            model.AM182 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox201.Text ) ? "0" : textBox201.Text ,out unitPrice );
            model.AM183 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox200.Text ) ? "0" : textBox200.Text ,out unitPrice );
            model.AM190 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox15.Text ) ? "0" : textBox15.Text ,out unitPrice );
            model.AM193 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox205.Text ) ? "0" : textBox205.Text ,out unitPrice );
            model.AM185 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox204.Text ) ? "0" : textBox204.Text ,out unitPrice );
            model.AM186 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox203.Text ) ? "0" : textBox203.Text ,out unitPrice );
            model.AM196 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox16.Text ) ? "0" : textBox16.Text ,out unitPrice );
            model.AM199 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox3.Text ) ? "0" : textBox3.Text ,out unitPrice );
            model.AM188 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox2.Text ) ? "0" : textBox2.Text ,out unitPrice );
            model.AM189 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox1.Text ) ? "0" : textBox1.Text ,out unitPrice );
            model.AM200 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox17.Text ) ? "0" : textBox17.Text ,out unitPrice );
            model.AM201 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox6.Text ) ? "0" : textBox6.Text ,out unitPrice );
            model.AM191 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox5.Text ) ? "0" : textBox5.Text ,out unitPrice );
            model.AM192 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox4.Text ) ? "0" : textBox4.Text ,out unitPrice );
            model.AM203 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox18.Text ) ? "0" : textBox18.Text ,out unitPrice );
            model.AM204 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox9.Text ) ? "0" : textBox9.Text ,out unitPrice );
            model.AM194 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox8.Text ) ? "0" : textBox8.Text ,out unitPrice );
            model.AM195 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox7.Text ) ? "0" : textBox7.Text ,out unitPrice );
            model.AM205 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox19.Text ) ? "0" : textBox19.Text ,out unitPrice );
            model.AM206 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox12.Text ) ? "0" : textBox12.Text ,out unitPrice );
            model.AM197 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox11.Text ) ? "0" : textBox11.Text ,out unitPrice );
            model.AM198 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox10.Text ) ? "0" : textBox10.Text ,out unitPrice );
            model.AM207 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox20.Text ) ? "0" : textBox20.Text ,out unitPrice );
            model.AM208 = unitPrice;
            unitPrice = 0M;
            decimal . TryParse ( string . IsNullOrEmpty ( textBox21 . Text ) ? "0" : textBox21 . Text , out unitPrice );
            model . AM173 = unitPrice;
        }
        //Sure
        private void button1_Click ( object sender ,EventArgs e )
        {
            assignMent( );
            result = bll.Paint( model );
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

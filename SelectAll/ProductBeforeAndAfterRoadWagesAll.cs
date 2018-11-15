using Mulaolao;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Data;
using System . Drawing;
using System . Linq;
using System . Runtime . InteropServices;
using System . Text;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class ProductBeforeAndAfterRoadWagesAll : Form
    {
        public ProductBeforeAndAfterRoadWagesAll ( )
        {
            InitializeComponent( );
            textBoxKeypress( );
        }

        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        MulaolaoBll.Bll.ProductCostSummaryBll bll = new MulaolaoBll.Bll.ProductCostSummaryBll( );
        MulaolaoLibrary.ProductCostSummaryLibrary model = new MulaolaoLibrary.ProductCostSummaryLibrary( );

        decimal unitPrice;
        bool result = false;
        string cn1 = "", cn2 = "";

        public string signOfBuildOrEdit = "";
        public int id = 0;

        private void ProductBeforeAndAfterRoadWagesAll_Load ( object sender ,EventArgs e )
        {
            this.MouseDown += new System.Windows.Forms.MouseEventHandler( Form_MouseDown );
            this.MouseMove += new System.Windows.Forms.MouseEventHandler( Form_MouseMove );
            this.MouseUp += new System.Windows.Forms.MouseEventHandler( Form_MouseUp );

            model = bll.GetModel( id );
            textBox53.Text = model.AM044.ToString( );
            textBox52.Text = model.AM045.ToString( );
            textBox55.Text = model.AM046.ToString( );
            textBox54.Text = model.AM047.ToString( );
            textBox57.Text = model.AM048.ToString( );
            textBox56.Text = model.AM049.ToString( );
            textBox59.Text = model.AM050.ToString( );
            textBox58.Text = model.AM051.ToString( );
            textBox61.Text = model.AM052.ToString( );
            textBox60.Text = model.AM053.ToString( );
            textBox63.Text = model.AM054.ToString( );
            textBox62.Text = model.AM055.ToString( );
            textBox4.Text = model.AM056.ToString( );
            textBox3.Text = model.AM057.ToString( );
            textBox2.Text = model.AM058.ToString( );
            textBox1.Text = model.AM059.ToString( );
            textBox6.Text = model.AM060.ToString( );
            textBox5.Text = model.AM061.ToString( );
            textBox8.Text = model.AM062.ToString( );
            textBox7.Text = model.AM063.ToString( );
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
            decimal.TryParse( string.IsNullOrEmpty( textBox53.Text ) ? "0" : textBox53.Text ,out unitPrice );
            model.AM044 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox52.Text ) ? "0" : textBox52.Text ,out unitPrice );
            model.AM045 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox55.Text ) ? "0" : textBox55.Text ,out unitPrice );
            model.AM046 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox54.Text ) ? "0" : textBox54.Text ,out unitPrice );
            model.AM047 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox57.Text ) ? "0" : textBox57.Text ,out unitPrice );
            model.AM048 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox56.Text ) ? "0" : textBox56.Text ,out unitPrice );
            model.AM049 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox59.Text ) ? "0" : textBox59.Text ,out unitPrice );
            model.AM050 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox58.Text ) ? "0" : textBox58.Text ,out unitPrice );
            model.AM051 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox61.Text ) ? "0" : textBox61.Text ,out unitPrice );
            model.AM052 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox60.Text ) ? "0" : textBox60.Text ,out unitPrice );
            model.AM053 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox63.Text ) ? "0" : textBox63.Text ,out unitPrice );
            model.AM054 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox62.Text ) ? "0" : textBox62.Text ,out unitPrice );
            model.AM055 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox4.Text ) ? "0" : textBox4.Text ,out unitPrice );
            model.AM056 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox3.Text ) ? "0" : textBox3.Text ,out unitPrice );
            model.AM057 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox2.Text ) ? "0" : textBox2.Text ,out unitPrice );
            model.AM058 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox1.Text ) ? "0" : textBox1.Text ,out unitPrice );
            model.AM059 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox6.Text ) ? "0" : textBox6.Text ,out unitPrice );
            model.AM060 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox5.Text ) ? "0" : textBox5.Text ,out unitPrice );
            model.AM061 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox8.Text ) ? "0" : textBox8.Text ,out unitPrice );
            model.AM062 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox7.Text ) ? "0" : textBox7.Text ,out unitPrice );
            model.AM063 = unitPrice;
        }
        //sure
        private void button1_Click ( object sender ,EventArgs e )
        {
            assignMent( );
            result = bll.ProductBeforeAndAfterRoadWages( model );
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

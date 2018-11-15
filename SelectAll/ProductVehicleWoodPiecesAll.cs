using Mulaolao.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SelectAll
{
    public partial class ProductVehicleWoodPiecesAll : Form
    {
        public ProductVehicleWoodPiecesAll ( )
        {
            InitializeComponent( );

            boxLi( );
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

        private void ProductVehicleWoodPiecesAll_Load ( object sender ,EventArgs e )
        {
            this.MouseDown += new System.Windows.Forms.MouseEventHandler( Form_MouseDown );
            this.MouseMove += new System.Windows.Forms.MouseEventHandler( Form_MouseMove );
            this.MouseUp += new System.Windows.Forms.MouseEventHandler( Form_MouseUp );

            model = bll.GetModel( id );
            textBox295.Text = model.AM270.ToString( );
            textBox294.Text = model.AM271.ToString( );
            textBox293.Text = model.AM272.ToString( );
            textBox7.Text = model.AM275.ToString( );
            textBox301.Text = model.AM273.ToString( );
            textBox300.Text = model.AM274.ToString( );
            textBox299.Text = model.AM279.ToString( );
            textBox8.Text = model.AM282.ToString( );
            textBox6.Text = model.AM277.ToString( );
            textBox5.Text = model.AM278.ToString( );
            textBox3.Text = model.AM280.ToString( );
            textBox2.Text = model.AM281.ToString( );
        }

        #region Value
        void assignMent ( )
        {
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox295.Text ) ? "0" : textBox295.Text ,out unitPrice );
            model.AM270 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox294.Text ) ? "0" : textBox294.Text ,out unitPrice );
            model.AM271 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox293.Text ) ? "0" : textBox293.Text ,out unitPrice );
            model.AM272 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox7.Text ) ? "0" : textBox7.Text ,out unitPrice );
            model.AM275 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox301.Text ) ? "0" : textBox301.Text ,out unitPrice );
            model.AM273 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox300.Text ) ? "0" : textBox300.Text ,out unitPrice );
            model.AM274 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox299.Text ) ? "0" : textBox299.Text ,out unitPrice );
            model.AM279 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox8.Text ) ? "0" : textBox8.Text ,out unitPrice );
            model.AM282 = unitPrice;
            model.AM276 = "";
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox6.Text ) ? "0" : textBox6.Text ,out unitPrice );
            model.AM277 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox5.Text ) ? "0" : textBox5.Text ,out unitPrice );
            model.AM278 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox3.Text ) ? "0" : textBox3.Text ,out unitPrice );
            model.AM280 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox2.Text ) ? "0" : textBox2.Text ,out unitPrice );
            model.AM281 = unitPrice;
        }
        //Sure
        private void button1_Click ( object sender ,EventArgs e )
        {
            assignMent( );
            result = bll.VehicleWoodPieces( model );
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
            boxList.Add( textBox293 );
            boxList.Add( textBox299 );
            boxList.Add( textBox4 );
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
    }
}

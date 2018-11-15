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
    public partial class ProductWoodAll : Form
    {
        public ProductWoodAll ( )
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
        private void ProductWoodAll_Load ( object sender ,EventArgs e )
        {
            this.MouseDown += new System.Windows.Forms.MouseEventHandler( Form_MouseDown );
            this.MouseMove += new System.Windows.Forms.MouseEventHandler( Form_MouseMove );
            this.MouseUp += new System.Windows.Forms.MouseEventHandler( Form_MouseUp );

            model = bll.GetModel( id );
            textBox364.Text = model.AM336.ToString( );
            textBox363.Text = model.AM337.ToString( );
            textBox362.Text = model.AM338.ToString( );
            textBox25.Text = model.AM341.ToString( );
            textBox370.Text = model.AM339.ToString( );
            textBox369.Text = model.AM340.ToString( );
            textBox368.Text = model.AM345.ToString( );
            textBox39.Text = model.AM348.ToString( );
            textBox373.Text = model.AM343.ToString( );
            textBox372.Text = model.AM344.ToString( );
            textBox371.Text = model.AM351.ToString( );
            textBox26.Text = model.AM354.ToString( );
            textBox376.Text = model.AM346.ToString( );
            textBox375.Text = model.AM347.ToString( );
            textBox374.Text = model.AM357.ToString( );
            textBox28.Text = model.AM360.ToString( );
            textBox379.Text = model.AM349.ToString( );
            textBox378.Text = model.AM350.ToString( );
            textBox377.Text = model.AM363.ToString( );
            textBox29.Text = model.AM366.ToString( );
            textBox382.Text = model.AM352.ToString( );
            textBox381.Text = model.AM353.ToString( );
            textBox380.Text = model.AM369.ToString( );
            textBox31.Text = model.AM372.ToString( );
            textBox385.Text = model.AM355.ToString( );
            textBox384.Text = model.AM356.ToString( );
            textBox383.Text = model.AM332.ToString( );
            textBox41.Text = model.AM335.ToString( );
            textBox388.Text = model.AM358.ToString( );
            textBox387.Text = model.AM359.ToString( );
            textBox386.Text = model.AM375.ToString( );
            textBox32.Text = model.AM378.ToString( );
            textBox391.Text = model.AM361.ToString( );
            textBox390.Text = model.AM362.ToString( );
            textBox389.Text = model.AM381.ToString( );
            textBox27.Text = model.AM387.ToString( );
            textBox394.Text = model.AM364.ToString( );
            textBox393.Text = model.AM365.ToString( );
            textBox392.Text = model.AM390.ToString( );
            textBox40.Text = model.AM393.ToString( );
            textBox397.Text = model.AM367.ToString( );
            textBox396.Text = model.AM368.ToString( );
            textBox395.Text = model.AM294.ToString( );
            textBox30.Text = model.AM295.ToString( );
            textBox400.Text = model.AM370.ToString( );
            textBox399.Text = model.AM371.ToString( );
            textBox398.Text = model.AM292.ToString( );
            textBox43.Text = model.AM293.ToString( );
            textBox24.Text = model.AM330.ToString( );
            textBox23.Text = model.AM331.ToString( );
            textBox22.Text = model.AM290.ToString( );
            textBox42.Text = model.AM291.ToString( );
            textBox21.Text = model.AM333.ToString( );
            textBox20.Text = model.AM334.ToString( );
            textBox19.Text = model.AM288.ToString( );
            textBox44.Text = model.AM289.ToString( );
            textBox3.Text = model.AM373.ToString( );
            textBox2.Text = model.AM374.ToString( );
            textBox1.Text = model.AM287.ToString( );
            textBox33.Text= model.AM269.ToString( );
            textBox6.Text = model.AM376.ToString( );
            textBox5.Text = model.AM377.ToString( );
            textBox4.Text = model.AM267.ToString( );
            textBox34.Text = model.AM268.ToString( );
            textBox9.Text = model.AM379.ToString( );
            textBox8.Text = model.AM380.ToString( );
            textBox7.Text = model.AM265.ToString( );
            textBox35.Text = model.AM266.ToString( );
            textBox12.Text = model.AM385.ToString( );
            textBox11.Text = model.AM386.ToString( );
            textBox10.Text = model.AM382.ToString( );
            textBox36.Text= model.AM383.ToString( );
            textBox15.Text = model.AM388.ToString( );
            textBox14.Text = model.AM389.ToString( );
            textBox13.Text = model.AM263.ToString( );
            textBox37.Text = model.AM264.ToString( );
            textBox18.Text = model.AM391.ToString( );
            textBox17.Text = model.AM392.ToString( );
            textBox16.Text = model.AM261.ToString( );
            textBox38.Text = model.AM262.ToString( );
        }

        #region Value
        void assignMent ( )
        {
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox364.Text ) ? "0" : textBox364.Text ,out unitPrice );
            model.AM336 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox363.Text ) ? "0" : textBox363.Text ,out unitPrice );
            model.AM337 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox362.Text ) ? "0" : textBox362.Text ,out unitPrice );
            model.AM338 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox25.Text ) ? "0" : textBox25.Text ,out unitPrice );
            model.AM341 = unitPrice;
           
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox370.Text ) ? "0" : textBox370.Text ,out unitPrice );
            model.AM339 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox369.Text ) ? "0" : textBox369.Text ,out unitPrice );
            model.AM340 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox368.Text ) ? "0" : textBox368.Text ,out unitPrice );
            model.AM345 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox39.Text ) ? "0" : textBox39.Text ,out unitPrice );
            model.AM348 = unitPrice;
            
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox373.Text ) ? "0" : textBox373.Text ,out unitPrice );
            model.AM343 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox372.Text ) ? "0" : textBox372.Text ,out unitPrice );
            model.AM344 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox371.Text ) ? "0" : textBox371.Text ,out unitPrice );
            model.AM351 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox26.Text ) ? "0" : textBox26.Text ,out unitPrice );
            model.AM354 = unitPrice;
           
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox376.Text ) ? "0" : textBox376.Text ,out unitPrice );
            model.AM346 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox375.Text ) ? "0" : textBox375.Text ,out unitPrice );
            model.AM347 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox374.Text ) ? "0" : textBox374.Text ,out unitPrice );
            model.AM357 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox28.Text ) ? "0" : textBox28.Text ,out unitPrice );
            model.AM360 = unitPrice;
           
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox379.Text ) ? "0" : textBox379.Text ,out unitPrice );
            model.AM349 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox378.Text ) ? "0" : textBox378.Text ,out unitPrice );
            model.AM350 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox377.Text ) ? "0" : textBox377.Text ,out unitPrice );
            model.AM363 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox29.Text ) ? "0" : textBox29.Text ,out unitPrice );
            model.AM366 = unitPrice;
           
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox382.Text ) ? "0" : textBox382.Text ,out unitPrice );
            model.AM352 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox381.Text ) ? "0" : textBox381.Text ,out unitPrice );
            model.AM353 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox380.Text ) ? "0" : textBox380.Text ,out unitPrice );
            model.AM369 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox31.Text ) ? "0" : textBox31.Text ,out unitPrice );
            model.AM372 = unitPrice;
            
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox385.Text ) ? "0" : textBox385.Text ,out unitPrice );
            model.AM355 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox384.Text ) ? "0" : textBox384.Text ,out unitPrice );
            model.AM356 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox383.Text ) ? "0" : textBox383.Text ,out unitPrice );
            model.AM332 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox41.Text ) ? "0" : textBox41.Text ,out unitPrice );
            model.AM335 = unitPrice;
           
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox388.Text ) ? "0" : textBox388.Text ,out unitPrice );
            model.AM358 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox387.Text ) ? "0" : textBox387.Text ,out unitPrice );
            model.AM359 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox386.Text ) ? "0" : textBox386.Text ,out unitPrice );
            model.AM375 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox32.Text ) ? "0" : textBox32.Text ,out unitPrice );
            model.AM378 = unitPrice;
           
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox391.Text ) ? "0" : textBox391.Text ,out unitPrice );
            model.AM361 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox390.Text ) ? "0" : textBox390.Text ,out unitPrice );
            model.AM362 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox389.Text ) ? "0" : textBox389.Text ,out unitPrice );
            model.AM381 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox27.Text ) ? "0" : textBox27.Text ,out unitPrice );
            model.AM387 = unitPrice;
           
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox394.Text ) ? "0" : textBox394.Text ,out unitPrice );
            model.AM364 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox393.Text ) ? "0" : textBox393.Text ,out unitPrice );
            model.AM365 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox392.Text ) ? "0" : textBox392.Text ,out unitPrice );
            model.AM390 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox40.Text ) ? "0" : textBox40.Text ,out unitPrice );
            model.AM393 = unitPrice;
          
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox397.Text ) ? "0" : textBox397.Text ,out unitPrice );
            model.AM367 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox396.Text ) ? "0" : textBox396.Text ,out unitPrice );
            model.AM368 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox395.Text ) ? "0" : textBox395.Text ,out unitPrice );
            model.AM294 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox30.Text ) ? "0" : textBox30.Text ,out unitPrice );
            model.AM295 = unitPrice;
           
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox400.Text ) ? "0" : textBox400.Text ,out unitPrice );
            model.AM370 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox399.Text ) ? "0" : textBox399.Text ,out unitPrice );
            model.AM371 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox398.Text ) ? "0" : textBox398.Text ,out unitPrice );
            model.AM292 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox43.Text ) ? "0" : textBox43.Text ,out unitPrice );
            model.AM293 = unitPrice;
            
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox24.Text ) ? "0" : textBox24.Text ,out unitPrice );
            model.AM330 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox23.Text ) ? "0" : textBox23.Text ,out unitPrice );
            model.AM331 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox22.Text ) ? "0" : textBox22.Text ,out unitPrice );
            model.AM290 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox42.Text ) ? "0" : textBox42.Text ,out unitPrice );
            model.AM291 = unitPrice;
           
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox21.Text ) ? "0" : textBox21.Text ,out unitPrice );
            model.AM333 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox20.Text ) ? "0" : textBox20.Text ,out unitPrice );
            model.AM334 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox19.Text ) ? "0" : textBox19.Text ,out unitPrice );
            model.AM288 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox44.Text ) ? "0" : textBox44.Text ,out unitPrice );
            model.AM289 = unitPrice;
            
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox3.Text ) ? "0" : textBox3.Text ,out unitPrice );
            model.AM373 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox2.Text ) ? "0" : textBox2.Text ,out unitPrice );
            model.AM374 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox1.Text ) ? "0" : textBox1.Text ,out unitPrice );
            model.AM287 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox33.Text ) ? "0" : textBox33.Text ,out unitPrice );
            model.AM269 = unitPrice;
           
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox6.Text ) ? "0" : textBox6.Text ,out unitPrice );
            model.AM376 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox5.Text ) ? "0" : textBox5.Text ,out unitPrice );
            model.AM377 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox4.Text ) ? "0" : textBox4.Text ,out unitPrice );
            model.AM267 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox34.Text ) ? "0" : textBox34.Text ,out unitPrice );
            model.AM268 = unitPrice;
            
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox9.Text ) ? "0" : textBox9.Text ,out unitPrice );
            model.AM379 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox8.Text ) ? "0" : textBox8.Text ,out unitPrice );
            model.AM380 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox7.Text ) ? "0" : textBox7.Text ,out unitPrice );
            model.AM265 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox35.Text ) ? "0" : textBox35.Text ,out unitPrice );
            model.AM266 = unitPrice;
          
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox12.Text ) ? "0" : textBox12.Text ,out unitPrice );
            model.AM385 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox11.Text ) ? "0" : textBox11.Text ,out unitPrice );
            model.AM386 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox10.Text ) ? "0" : textBox10.Text ,out unitPrice );
            model.AM382 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox36.Text ) ? "0" : textBox36.Text ,out unitPrice );
            model.AM383 = unitPrice;
            
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox15.Text ) ? "0" : textBox15.Text ,out unitPrice );
            model.AM388 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox14.Text ) ? "0" : textBox14.Text ,out unitPrice );
            model.AM389 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox13.Text ) ? "0" : textBox13.Text ,out unitPrice );
            model.AM263 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox37.Text ) ? "0" : textBox37.Text ,out unitPrice );
            model.AM264 = unitPrice;

            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox18.Text ) ? "0" : textBox18.Text ,out unitPrice );
            model.AM391 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox17.Text ) ? "0" : textBox17.Text ,out unitPrice );
            model.AM392 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox16.Text ) ? "0" : textBox16.Text ,out unitPrice );
            model.AM261 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox38.Text ) ? "0" : textBox38.Text ,out unitPrice );
            model.AM262 = unitPrice;
        }
        //Sure
        private void button1_Click ( object sender ,EventArgs e )
        {
            assignMent( );
            result = bll.Wood( model );
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
            boxList.Add( textBox362 );
            boxList.Add( textBox368 );
            boxList.Add( textBox371 );
            boxList.Add( textBox374 );
            boxList.Add( textBox377 );
            boxList.Add( textBox380 );
            boxList.Add( textBox383 );
            boxList.Add( textBox386 );
            boxList.Add( textBox389 );
            boxList.Add( textBox392 );
            boxList.Add( textBox395 );
            boxList.Add( textBox398 );
            boxList.Add( textBox22 );
            boxList.Add( textBox19 );
            boxList.Add( textBox1 );
            boxList.Add( textBox4 );
            boxList.Add( textBox7 );
            boxList.Add( textBox10 );
            boxList.Add( textBox13 );
            boxList.Add( textBox16 );
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

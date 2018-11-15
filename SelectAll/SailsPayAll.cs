using Mulaolao;
using Mulaolao . Class;
using System;
using System . Drawing;
using System . Runtime . InteropServices;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class SailsPayAll : Form
    {
        public SailsPayAll ( )
        {
            InitializeComponent( );
        }

        private void SailsPayAll_Load ( object sender ,EventArgs e )
        {
            this.MouseDown += new System.Windows.Forms.MouseEventHandler( Form_MouseDown );
            this.MouseMove += new System.Windows.Forms.MouseEventHandler( Form_MouseMove );
            this.MouseUp += new System.Windows.Forms.MouseEventHandler( Form_MouseUp );

            textEdit1.Properties.Items.Clear( );
            textEdit1.Properties.Items.AddRange( new string[] { "订单R - 250表额" ,"开票.实交金额" ,"收齐(申报)" } );
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

        #region Value
        //Sure
        private void button1_Click ( object sender ,EventArgs e )
        {

        }
        //Clear
        private void button2_Click ( object sender ,EventArgs e )
        {
            this.Close( );
        }
        #endregion

        #region Event
        private void textEdit2_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.intgra( e );
        }
        private void textEdit3_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.intgra( e );
        }
        private void textEdit5_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.intgra( e );
        }
        private void textEdit4_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.intgra( e );
        }
        private void textEdit6_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.intgra( e );
        }
        private void textEdit7_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.fractionTb( e ,textEdit7 );
        }
        private void textEdit7_TextChanged ( object sender ,EventArgs e )
        {
            DateDay.textChangeTb( textEdit7 );
        }
        private void textEdit7_LostFocus ( object sender ,EventArgs e )
        {
            if ( textEdit7.Text != "" && !DateDay.threeTwoNumTb( textEdit7 ) )
            {
                textEdit7.Text = "";
                MessageBox.Show( "只允许输入整数部分最多一位,小数部分最多两位,如9.99,请重新输入" );
            }
        }
        private void textEdit8_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.fractionTb( e ,textEdit8 );
        }
        private void textEdit8_TextChanged ( object sender ,EventArgs e )
        {
            DateDay.textChangeTb( textEdit8 );
        }
        private void textEdit8_LostFocus ( object sender ,EventArgs e )
        {
            if ( textEdit8.Text != "" && !DateDay.threeTwoNumTb( textEdit8 ) )
            {
                textEdit8.Text = "";
                MessageBox.Show( "只允许输入整数部分最多一位,小数部分最多两位,如9.99,请重新输入" );
            }
        }
        private void textEdit9_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.fractionTb( e ,textEdit9 );
        }
        private void textEdit9_TextChanged ( object sender ,EventArgs e )
        {
            DateDay.textChangeTb( textEdit9 );
        }
        private void textEdit9_LostFocus ( object sender ,EventArgs e )
        {
            if ( textEdit9.Text != "" && !DateDay.threeTwoNumTb( textEdit9 ) )
            {
                textEdit9.Text = "";
                MessageBox.Show( "只允许输入整数部分最多一位,小数部分最多两位,如9.99,请重新输入" );
            }
        }
        private void textEdit10_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.intgra( e );
        }
        private void textEdit11_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.intgra( e );
        }
        private void textEdit12_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.intgra( e );
        }
        private void textEdit13_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.intgra( e );
        }
        private void textEdit14_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.intgra( e );
        }
        private void textEdit15_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.fractionTb( e ,textEdit15 );
        }
        private void textEdit15_TextChanged ( object sender ,EventArgs e )
        {
            DateDay.textChangeTb( textEdit15 );
        }
        private void textEdit15_LostFocus ( object sender ,EventArgs e )
        {
            if ( textEdit15.Text != "" && !DateDay.foreOneNum( textEdit15 ) )
            {
                textEdit15.Text = "";
                MessageBox.Show( "只允许输入整数部分最多一位,小数部分最多三位,如9.999,请重新输入" );
            }
        }
        private void textEdit16_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.intgra( e );
        }
        #endregion
    }
}

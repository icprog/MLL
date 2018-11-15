using System;
using System. Collections. Generic;
using System. ComponentModel;
using System. Drawing;
using System. Data;
using System. Linq;
using System. Text;
using System. Windows. Forms;
using Mulaolao. Class;

namespace Mulaolao
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1( )
        {
            InitializeComponent( );
        }

        private void UserControl1_Load( object sender, EventArgs e )
        {

        }

        #region  事件
        //1日
        private void textBox1_KeyPress ( object sender , KeyPressEventArgs e )
        {
            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ( ( e. KeyChar < 48 || e. KeyChar > 57 ) && ( e. KeyChar != 46 ) && e. KeyChar != 8 )
            {
                MessageBox. Show ( "请输入数字" );
                e. Handled = true;
            }
            else if ( char. IsPunctuation ( e. KeyChar ) )
            {
                if ( textBox1. Text. LastIndexOf ( '.' ) != -1 )
                {
                    e. Handled = true;
                    MessageBox. Show ( "只能输入一个小数点" );
                }
            }
        }
        private void textBox1_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox1. Text != "" && !DateDay. threeTwoNumTb ( textBox1 ) )
            {
                this. textBox1. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多三位,小数部分最多五位,如9.99,请重新输入" );
            }
        }
        //2日
        private void textBox2_KeyPress ( object sender , KeyPressEventArgs e )
        {
            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ( ( e. KeyChar < 48 || e. KeyChar > 57 ) && ( e. KeyChar != 46 ) && e. KeyChar != 8 )
            {
                MessageBox. Show ( "请输入数字" );
                e. Handled = true;
            }
            else if ( char. IsPunctuation ( e. KeyChar ) )
            {
                if ( textBox2. Text. LastIndexOf ( '.' ) != -1 )
                {
                    e. Handled = true;
                    MessageBox. Show ( "只能输入一个小数点" );
                }
            }
        }
        private void textBox2_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox2. Text != "" && !DateDay. threeTwoNumTb ( textBox2 ) )
            {
                this. textBox2. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多三位,小数部分最多五位,如9.99,请重新输入" );
            }
        }
        //3日
        private void textBox3_KeyPress ( object sender , KeyPressEventArgs e )
        {
            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ( ( e. KeyChar < 48 || e. KeyChar > 57 ) && ( e. KeyChar != 46 ) && e. KeyChar != 8 )
            {
                MessageBox. Show ( "请输入数字" );
                e. Handled = true;
            }
            else if ( char. IsPunctuation ( e. KeyChar ) )
            {
                if ( textBox3. Text. LastIndexOf ( '.' ) != -1 )
                {
                    e. Handled = true;
                    MessageBox. Show ( "只能输入一个小数点" );
                }
            }
        }
        private void textBox3_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox3. Text != "" && !DateDay. threeTwoNumTb ( textBox3 ) )
            {
                this. textBox3. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多三位,小数部分最多五位,如9.99,请重新输入" );
            }
        }
        //4日
        private void textBox4_KeyPress ( object sender , KeyPressEventArgs e )
        {
            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ( ( e. KeyChar < 48 || e. KeyChar > 57 ) && ( e. KeyChar != 46 ) && e. KeyChar != 8 )
            {
                MessageBox. Show ( "请输入数字" );
                e. Handled = true;
            }
            else if ( char. IsPunctuation ( e. KeyChar ) )
            {
                if ( textBox4. Text. LastIndexOf ( '.' ) != -1 )
                {
                    e. Handled = true;
                    MessageBox. Show ( "只能输入一个小数点" );
                }
            }
        }
        private void textBox4_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox4. Text != "" && !DateDay. threeTwoNumTb ( textBox4 ) )
            {
                this. textBox4. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多三位,小数部分最多五位,如9.99,请重新输入" );
            }
        }
        //5日
        private void textBox5_KeyPress ( object sender , KeyPressEventArgs e )
        {

            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ( ( e. KeyChar < 48 || e. KeyChar > 57 ) && ( e. KeyChar != 46 ) && e. KeyChar != 8 )
            {
                MessageBox. Show ( "请输入数字" );
                e. Handled = true;
            }
            else if ( char. IsPunctuation ( e. KeyChar ) )
            {
                if ( textBox5. Text. LastIndexOf ( '.' ) != -1 )
                {
                    e. Handled = true;
                    MessageBox. Show ( "只能输入一个小数点" );
                }
            }
        }
        private void textBox5_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox5. Text != "" && !DateDay. threeTwoNumTb ( textBox5 ) )
            {
                this. textBox5. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多三位,小数部分最多五位,如9.99,请重新输入" );
            }
        }
        //6日
        private void textBox6_KeyPress ( object sender , KeyPressEventArgs e )
        {

            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ( ( e. KeyChar < 48 || e. KeyChar > 57 ) && ( e. KeyChar != 46 ) && e. KeyChar != 8 )
            {
                MessageBox. Show ( "请输入数字" );
                e. Handled = true;
            }
            else if ( char. IsPunctuation ( e. KeyChar ) )
            {
                if ( textBox6. Text. LastIndexOf ( '.' ) != -1 )
                {
                    e. Handled = true;
                    MessageBox. Show ( "只能输入一个小数点" );
                }
            }
        }
        private void textBox6_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox6. Text != "" && !DateDay. threeTwoNumTb ( textBox6 ) )
            {
                this. textBox6. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多三位,小数部分最多五位,如9.99,请重新输入" );
            }
        }
        //7日
        private void textBox7_KeyPress ( object sender , KeyPressEventArgs e )
        {

            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ( ( e. KeyChar < 48 || e. KeyChar > 57 ) && ( e. KeyChar != 46 ) && e. KeyChar != 8 )
            {
                MessageBox. Show ( "请输入数字" );
                e. Handled = true;
            }
            else if ( char. IsPunctuation ( e. KeyChar ) )
            {
                if ( textBox7. Text. LastIndexOf ( '.' ) != -1 )
                {
                    e. Handled = true;
                    MessageBox. Show ( "只能输入一个小数点" );
                }
            }
        }
        private void textBox7_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox7. Text != "" && !DateDay. threeTwoNumTb ( textBox7 ) )
            {
                this. textBox7. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多三位,小数部分最多五位,如9.99,请重新输入" );
            }
        }
        //8日
        private void textBox8_KeyPress ( object sender , KeyPressEventArgs e )
        {

            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ( ( e. KeyChar < 48 || e. KeyChar > 57 ) && ( e. KeyChar != 46 ) && e. KeyChar != 8 )
            {
                MessageBox. Show ( "请输入数字" );
                e. Handled = true;
            }
            else if ( char. IsPunctuation ( e. KeyChar ) )
            {
                if ( textBox8. Text. LastIndexOf ( '.' ) != -1 )
                {
                    e. Handled = true;
                    MessageBox. Show ( "只能输入一个小数点" );
                }
            }
        }
        private void textBox8_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox8. Text != "" && !DateDay. threeTwoNumTb ( textBox8 ) )
            {
                this. textBox8. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多三位,小数部分最多五位,如9.99,请重新输入" );
            }
        }
        //9日
        private void textBox9_KeyPress ( object sender , KeyPressEventArgs e )
        {

            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ( ( e. KeyChar < 48 || e. KeyChar > 57 ) && ( e. KeyChar != 46 ) && e. KeyChar != 8 )
            {
                MessageBox. Show ( "请输入数字" );
                e. Handled = true;
            }
            else if ( char. IsPunctuation ( e. KeyChar ) )
            {
                if ( textBox9. Text. LastIndexOf ( '.' ) != -1 )
                {
                    e. Handled = true;
                    MessageBox. Show ( "只能输入一个小数点" );
                }
            }
        }
        private void textBox9_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox9. Text != "" && !DateDay. threeTwoNumTb ( textBox9 ) )
            {
                this. textBox9. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多三位,小数部分最多五位,如9.99,请重新输入" );
            }
        }
        //10日
        private void textBox10_KeyPress ( object sender , KeyPressEventArgs e )
        {

            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ( ( e. KeyChar < 48 || e. KeyChar > 57 ) && ( e. KeyChar != 46 ) && e. KeyChar != 8 )
            {
                MessageBox. Show ( "请输入数字" );
                e. Handled = true;
            }
            else if ( char. IsPunctuation ( e. KeyChar ) )
            {
                if ( textBox10. Text. LastIndexOf ( '.' ) != -1 )
                {
                    e. Handled = true;
                    MessageBox. Show ( "只能输入一个小数点" );
                }
            }
        }
        private void textBox10_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox10. Text != "" && !DateDay. threeTwoNumTb ( textBox10 ) )
            {
                this. textBox10. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多三位,小数部分最多五位,如9.99,请重新输入" );
            }
        }
        //11日
        private void textBox11_KeyPress ( object sender , KeyPressEventArgs e )
        {

            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ( ( e. KeyChar < 48 || e. KeyChar > 57 ) && ( e. KeyChar != 46 ) && e. KeyChar != 8 )
            {
                MessageBox. Show ( "请输入数字" );
                e. Handled = true;
            }
            else if ( char. IsPunctuation ( e. KeyChar ) )
            {
                if ( textBox11. Text. LastIndexOf ( '.' ) != -1 )
                {
                    e. Handled = true;
                    MessageBox. Show ( "只能输入一个小数点" );
                }
            }
        }
        private void textBox11_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox11. Text != "" && !DateDay. threeTwoNumTb ( textBox11 ) )
            {
                this. textBox11. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多三位,小数部分最多五位,如9.99,请重新输入" );
            }
        }
        //12日
        private void textBox12_KeyPress ( object sender , KeyPressEventArgs e )
        {

            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ( ( e. KeyChar < 48 || e. KeyChar > 57 ) && ( e. KeyChar != 46 ) && e. KeyChar != 8 )
            {
                MessageBox. Show ( "请输入数字" );
                e. Handled = true;
            }
            else if ( char. IsPunctuation ( e. KeyChar ) )
            {
                if ( textBox12. Text. LastIndexOf ( '.' ) != -1 )
                {
                    e. Handled = true;
                    MessageBox. Show ( "只能输入一个小数点" );
                }
            }
        }
        private void textBox12_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox12. Text != "" && !DateDay. threeTwoNumTb ( textBox12 ) )
            {
                this. textBox12. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多三位,小数部分最多五位,如9.99,请重新输入" );
            }
        }
        //13日
        private void textBox13_KeyPress ( object sender , KeyPressEventArgs e )
        {

            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ( ( e. KeyChar < 48 || e. KeyChar > 57 ) && ( e. KeyChar != 46 ) && e. KeyChar != 8 )
            {
                MessageBox. Show ( "请输入数字" );
                e. Handled = true;
            }
            else if ( char. IsPunctuation ( e. KeyChar ) )
            {
                if ( textBox13. Text. LastIndexOf ( '.' ) != -1 )
                {
                    e. Handled = true;
                    MessageBox. Show ( "只能输入一个小数点" );
                }
            }
        }
        private void textBox13_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox13. Text != "" && !DateDay. threeTwoNumTb ( textBox13 ) )
            {
                this. textBox13. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多三位,小数部分最多五位,如9.99,请重新输入" );
            }
        }
        //14日
        private void textBox14_KeyPress ( object sender , KeyPressEventArgs e )
        {
            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ( ( e. KeyChar < 48 || e. KeyChar > 57 ) && ( e. KeyChar != 46 ) && e. KeyChar != 8 )
            {
                MessageBox. Show ( "请输入数字" );
                e. Handled = true;
            }
            else if ( char. IsPunctuation ( e. KeyChar ) )
            {
                if ( textBox14. Text. LastIndexOf ( '.' ) != -1 )
                {
                    e. Handled = true;
                    MessageBox. Show ( "只能输入一个小数点" );
                }
            }
        }
        private void textBox14_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox14. Text != "" && !DateDay. threeTwoNumTb ( textBox14 ) )
            {
                this. textBox14. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多三位,小数部分最多五位,如9.99,请重新输入" );
            }
        }
        //15日
        private void textBox15_KeyPress ( object sender , KeyPressEventArgs e )
        {
            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ( ( e. KeyChar < 48 || e. KeyChar > 57 ) && ( e. KeyChar != 46 ) && e. KeyChar != 8 )
            {
                MessageBox. Show ( "请输入数字" );
                e. Handled = true;
            }
            else if ( char. IsPunctuation ( e. KeyChar ) )
            {
                if ( textBox15. Text. LastIndexOf ( '.' ) != -1 )
                {
                    e. Handled = true;
                    MessageBox. Show ( "只能输入一个小数点" );
                }
            }
        }
        private void textBox15_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox15. Text != "" && !DateDay. threeTwoNumTb ( textBox15 ) )
            {
                this. textBox15. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多三位,小数部分最多五位,如9.99,请重新输入" );
            }
        }
        //16日
        private void textBox16_KeyPress ( object sender , KeyPressEventArgs e )
        {
            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ( ( e. KeyChar < 48 || e. KeyChar > 57 ) && ( e. KeyChar != 46 ) && e. KeyChar != 8 )
            {
                MessageBox. Show ( "请输入数字" );
                e. Handled = true;
            }
            else if ( char. IsPunctuation ( e. KeyChar ) )
            {
                if ( textBox16. Text. LastIndexOf ( '.' ) != -1 )
                {
                    e. Handled = true;
                    MessageBox. Show ( "只能输入一个小数点" );
                }
            }
        }
        private void textBox16_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox16. Text != "" && !DateDayRegise . threeTwoNumTb ( textBox16 ) )
            {
                this. textBox16. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多三位,小数部分最多五位,如9.99,请重新输入" );
            }
        }
        //17日
        private void textBox17_KeyPress ( object sender , KeyPressEventArgs e )
        {
            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ( ( e. KeyChar < 48 || e. KeyChar > 57 ) && ( e. KeyChar != 46 ) && e. KeyChar != 8 )
            {
                MessageBox. Show ( "请输入数字" );
                e. Handled = true;
            }
            else if ( char. IsPunctuation ( e. KeyChar ) )
            {
                if ( textBox17. Text. LastIndexOf ( '.' ) != -1 )
                {
                    e. Handled = true;
                    MessageBox. Show ( "只能输入一个小数点" );
                }
            }
        }
        private void textBox17_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox17. Text != "" && !DateDayRegise . threeTwoNumTb ( textBox17 ) )
            {
                this. textBox17. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多三位,小数部分最多五位,如9.99,请重新输入" );
            }
        }
        //18日
        private void textBox18_KeyPress ( object sender , KeyPressEventArgs e )
        {
            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ( ( e. KeyChar < 48 || e. KeyChar > 57 ) && ( e. KeyChar != 46 ) && e. KeyChar != 8 )
            {
                MessageBox. Show ( "请输入数字" );
                e. Handled = true;
            }
            else if ( char. IsPunctuation ( e. KeyChar ) )
            {
                if ( textBox18. Text. LastIndexOf ( '.' ) != -1 )
                {
                    e. Handled = true;
                    MessageBox. Show ( "只能输入一个小数点" );
                }
            }
        }
        private void textBox18_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox18. Text != "" && !DateDayRegise . threeTwoNumTb ( textBox18 ) )
            {
                this. textBox18. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多三位,小数部分最多五位,如9.99,请重新输入" );
            }
        }
        //19日
        private void textBox19_KeyPress ( object sender , KeyPressEventArgs e )
        {
            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ( ( e. KeyChar < 48 || e. KeyChar > 57 ) && ( e. KeyChar != 46 ) && e. KeyChar != 8 )
            {
                MessageBox. Show ( "请输入数字" );
                e. Handled = true;
            }
            else if ( char. IsPunctuation ( e. KeyChar ) )
            {
                if ( textBox19. Text. LastIndexOf ( '.' ) != -1 )
                {
                    e. Handled = true;
                    MessageBox. Show ( "只能输入一个小数点" );
                }
            }
        }
        private void textBox19_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox19. Text != "" && !DateDayRegise . threeTwoNumTb ( textBox19 ) )
            {
                this. textBox19. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多三位,小数部分最多五位,如9.99,请重新输入" );
            }
        }
        //20日
        private void textBox20_KeyPress ( object sender , KeyPressEventArgs e )
        {
            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ( ( e. KeyChar < 48 || e. KeyChar > 57 ) && ( e. KeyChar != 46 ) && e. KeyChar != 8 )
            {
                MessageBox. Show ( "请输入数字" );
                e. Handled = true;
            }
            else if ( char. IsPunctuation ( e. KeyChar ) )
            {
                if ( textBox20. Text. LastIndexOf ( '.' ) != -1 )
                {
                    e. Handled = true;
                    MessageBox. Show ( "只能输入一个小数点" );
                }
            }
        }
        private void textBox20_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox20. Text != "" && !DateDayRegise . threeTwoNumTb ( textBox20 ) )
            {
                this. textBox20. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多三位,小数部分最多五位,如9.99,请重新输入" );
            }
        }
        //21日
        private void textBox21_KeyPress ( object sender , KeyPressEventArgs e )
        {
            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ( ( e. KeyChar < 48 || e. KeyChar > 57 ) && ( e. KeyChar != 46 ) && e. KeyChar != 8 )
            {
                MessageBox. Show ( "请输入数字" );
                e. Handled = true;
            }
            else if ( char. IsPunctuation ( e. KeyChar ) )
            {
                if ( textBox21. Text. LastIndexOf ( '.' ) != -1 )
                {
                    e. Handled = true;
                    MessageBox. Show ( "只能输入一个小数点" );
                }
            }
        }
        private void textBox21_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox21. Text != "" && !DateDayRegise . threeTwoNumTb ( textBox21 ) )
            {
                this. textBox21. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多三位,小数部分最多五位,如9.99,请重新输入" );
            }
        }
        //22日
        private void textBox22_KeyPress ( object sender , KeyPressEventArgs e )
        {
            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ( ( e. KeyChar < 48 || e. KeyChar > 57 ) && ( e. KeyChar != 46 ) && e. KeyChar != 8 )
            {
                MessageBox. Show ( "请输入数字" );
                e. Handled = true;
            }
            else if ( char. IsPunctuation ( e. KeyChar ) )
            {
                if ( textBox22. Text. LastIndexOf ( '.' ) != -1 )
                {
                    e. Handled = true;
                    MessageBox. Show ( "只能输入一个小数点" );
                }
            }
        }
        private void textBox22_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox22. Text != "" && !DateDayRegise . threeTwoNumTb ( textBox22 ) )
            {
                this. textBox22. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多三位,小数部分最多五位,如9.99,请重新输入" );
            }
        }
        //23日
        private void textBox23_KeyPress ( object sender , KeyPressEventArgs e )
        {
            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ( ( e. KeyChar < 48 || e. KeyChar > 57 ) && ( e. KeyChar != 46 ) && e. KeyChar != 8 )
            {
                MessageBox. Show ( "请输入数字" );
                e. Handled = true;
            }
            else if ( char. IsPunctuation ( e. KeyChar ) )
            {
                if ( textBox23. Text. LastIndexOf ( '.' ) != -1 )
                {
                    e. Handled = true;
                    MessageBox. Show ( "只能输入一个小数点" );
                }
            }
        }
        private void textBox23_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox23. Text != "" && !DateDayRegise . threeTwoNumTb ( textBox23 ) )
            {
                this. textBox23. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多三位,小数部分最多五位,如9.99,请重新输入" );
            }
        }
        //24日
        private void textBox24_KeyPress ( object sender , KeyPressEventArgs e )
        {
            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ( ( e. KeyChar < 48 || e. KeyChar > 57 ) && ( e. KeyChar != 46 ) && e. KeyChar != 8 )
            {
                MessageBox. Show ( "请输入数字" );
                e. Handled = true;
            }
            else if ( char. IsPunctuation ( e. KeyChar ) )
            {
                if ( textBox24. Text. LastIndexOf ( '.' ) != -1 )
                {
                    e. Handled = true;
                    MessageBox. Show ( "只能输入一个小数点" );
                }
            }
        }
        private void textBox24_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox24. Text != "" && !DateDayRegise . threeTwoNumTb ( textBox24 ) )
            {
                this. textBox24. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多三位,小数部分最多五位,如9.99,请重新输入" );
            }
        }
        //25日
        private void textBox25_KeyPress ( object sender , KeyPressEventArgs e )
        {
            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ( ( e. KeyChar < 48 || e. KeyChar > 57 ) && ( e. KeyChar != 46 ) && e. KeyChar != 8 )
            {
                MessageBox. Show ( "请输入数字" );
                e. Handled = true;
            }
            else if ( char. IsPunctuation ( e. KeyChar ) )
            {
                if ( textBox25. Text. LastIndexOf ( '.' ) != -1 )
                {
                    e. Handled = true;
                    MessageBox. Show ( "只能输入一个小数点" );
                }
            }
        }
        private void textBox25_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox25. Text != "" && !DateDayRegise . threeTwoNumTb ( textBox25 ) )
            {
                this. textBox25. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多三位,小数部分最多五位,如9.99,请重新输入" );
            }
        }
        //26日
        private void textBox26_KeyPress ( object sender , KeyPressEventArgs e )
        {
            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ( ( e. KeyChar < 48 || e. KeyChar > 57 ) && ( e. KeyChar != 46 ) && e. KeyChar != 8 )
            {
                MessageBox. Show ( "请输入数字" );
                e. Handled = true;
            }
            else if ( char. IsPunctuation ( e. KeyChar ) )
            {
                if ( textBox26. Text. LastIndexOf ( '.' ) != -1 )
                {
                    e. Handled = true;
                    MessageBox. Show ( "只能输入一个小数点" );
                }
            }
        }
        private void textBox26_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox26. Text != "" && !DateDayRegise . threeTwoNumTb ( textBox26 ) )
            {
                this. textBox26. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多三位,小数部分最多五位,如9.99,请重新输入" );
            }
        }
        //27日
        private void textBox27_KeyPress ( object sender , KeyPressEventArgs e )
        {
            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ( ( e. KeyChar < 48 || e. KeyChar > 57 ) && ( e. KeyChar != 46 ) && e. KeyChar != 8 )
            {
                MessageBox. Show ( "请输入数字" );
                e. Handled = true;
            }
            else if ( char. IsPunctuation ( e. KeyChar ) )
            {
                if ( textBox27. Text. LastIndexOf ( '.' ) != -1 )
                {
                    e. Handled = true;
                    MessageBox. Show ( "只能输入一个小数点" );
                }
            }
        }
        private void textBox27_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox27. Text != "" && !DateDayRegise . threeTwoNumTb ( textBox27 ) )
            {
                this. textBox27. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多三位,小数部分最多五位,如9.99,请重新输入" );
            }
        }
        //28日
        private void textBox28_KeyPress ( object sender , KeyPressEventArgs e )
        {
            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ( ( e. KeyChar < 48 || e. KeyChar > 57 ) && ( e. KeyChar != 46 ) && e. KeyChar != 8 )
            {
                MessageBox. Show ( "请输入数字" );
                e. Handled = true;
            }
            else if ( char. IsPunctuation ( e. KeyChar ) )
            {
                if ( textBox28. Text. LastIndexOf ( '.' ) != -1 )
                {
                    e. Handled = true;
                    MessageBox. Show ( "只能输入一个小数点" );
                }
            }
        }
        private void textBox28_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox28. Text != "" && !DateDayRegise . threeTwoNumTb ( textBox28 ) )
            {
                this. textBox28. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多三位,小数部分最多五位,如9.99,请重新输入" );
            }
        }
        //29日
        private void textBox29_KeyPress ( object sender , KeyPressEventArgs e )
        {
            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ( ( e. KeyChar < 48 || e. KeyChar > 57 ) && ( e. KeyChar != 46 ) && e. KeyChar != 8 )
            {
                MessageBox. Show ( "请输入数字" );
                e. Handled = true;
            }
            else if ( char. IsPunctuation ( e. KeyChar ) )
            {
                if ( textBox29. Text. LastIndexOf ( '.' ) != -1 )
                {
                    e. Handled = true;
                    MessageBox. Show ( "只能输入一个小数点" );
                }
            }
        }
        private void textBox29_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox29. Text != "" && !DateDayRegise . threeTwoNumTb ( textBox29 ) )
            {
                this. textBox29. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多三位,小数部分最多五位,如9.99,请重新输入" );
            }
        }
        //30日
        private void textBox30_KeyPress ( object sender , KeyPressEventArgs e )
        {
            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ( ( e. KeyChar < 48 || e. KeyChar > 57 ) && ( e. KeyChar != 46 ) && e. KeyChar != 8 )
            {
                MessageBox. Show ( "请输入数字" );
                e. Handled = true;
            }
            else if ( char. IsPunctuation ( e. KeyChar ) )
            {
                if ( textBox30. Text. LastIndexOf ( '.' ) != -1 )
                {
                    e. Handled = true;
                    MessageBox. Show ( "只能输入一个小数点" );
                }
            }
        }
        private void textBox30_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox30. Text != "" && !DateDayRegise . threeTwoNumTb ( textBox30 ) )
            {
                this. textBox30. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多三位,小数部分最多五位,如9.99,请重新输入" );
            }
        }
        //31日
        private void textBox31_KeyPress ( object sender , KeyPressEventArgs e )
        {
            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ( ( e. KeyChar < 48 || e. KeyChar > 57 ) && ( e. KeyChar != 46 ) && e. KeyChar != 8 )
            {
                MessageBox. Show ( "请输入数字" );
                e. Handled = true;
            }
            else if ( char. IsPunctuation ( e. KeyChar ) )
            {
                if ( textBox31. Text. LastIndexOf ( '.' ) != -1 )
                {
                    e. Handled = true;
                    MessageBox. Show ( "只能输入一个小数点" );
                }
            }
        }
        private void textBox31_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox31. Text != "" && !DateDayRegise . threeTwoNumTb ( textBox31 ) )
            {
                this. textBox31. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多三位,小数部分最多五位,如9.99,请重新输入" );
            }
        }

        #endregion
    }
}

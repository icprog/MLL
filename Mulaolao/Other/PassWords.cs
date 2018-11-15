using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StudentMgr;
using Mulaolao.Class;

namespace Mulaolao.Other
{
    public partial class PassWords : Form
    {
        public PassWords(/*Form1 fm*/ )
        {
            //this.MdiParent = fm;
            InitializeComponent( );
            this.ControlBox = false;
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }

        private void PassWords_Load( object sender, EventArgs e )
        {

        }
        private void textBox2_LostFocus( object sender, EventArgs e )
        {
            if (textBox2.Text != "" && !DateDayRegise.PassWords(textBox2))
            {
                textBox2.Text = "";
                MessageBox.Show( "密码应由6-15位字母数字下划线等特殊字符组成" );
            }
        }
        private void textBox3_LostFocus( object sender, EventArgs e )
        {
            if (textBox3.Text != textBox2.Text)
            {
                textBox3.Text = "";
                MessageBox.Show( "两次输入的新密码不一致,请重新输入" );
            }
        }
        private void button1_Click( object sender, EventArgs e )
        {
            DataTable da = SqlHelper.ExecuteDataTable( "SELECT * FROM TPADBA WHERE DBA001=@DBA001", new SqlParameter( "@DBA001", Logins.number ) );
            if (da != null && da.Rows.Count > 0)
            {
                if (textBox1.Text != da.Rows[0]["DBA965"].ToString( ))
                {
                    MessageBox.Show( "您输入的旧密码错误,请重新输入" );
                }
                else
                {
                    if (textBox1.Text == textBox2.Text)
                    {
                        MessageBox.Show( "新旧密码一致" );
                    }
                    else
                    {
                        int count = SqlHelper.ExecuteNonQuery( "UPDATE TPADBA SET DBA965=@DBA965 WHERE DBA001=@DBA001", new SqlParameter( "@DBA965", textBox2.Text ), new SqlParameter( "@DBA001", Logins.number ) );
                        if (count > 0)
                        {
                            MessageBox.Show( "更改密码成功" );
                            this.Close( );
                        }
                        else
                        {
                            MessageBox.Show( "更改密码失败" );
                        }
                    }
                }
            }
        }
        private void button2_Click( object sender, EventArgs e )
        {
            this.Close( );
        }
    }
}

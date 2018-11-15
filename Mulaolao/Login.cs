using System;
using System . Data;
using System . Data . SqlClient;
using System . Windows . Forms;
using StudentMgr;
using System . Configuration;
using MulaolaoBll;

namespace Mulaolao
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        //获取Configuration对象
        Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration( /*ConfigurationUserLevel.None*/System.Windows.Forms.Application.ExecutablePath );

        string userName = "", passWord = "", sign = "";

        private void Login_Load(object sender, EventArgs e)
        {
            //获取所有登录名
            DataTable dt = SqlHelper.ExecuteDataTable( "SELECT DBA001,DBA002 FROM TPADBA WHERE DBA001 IN (SELECT DBB001 FROM R_DBB) ORDER BY DBA002" );
            comboB1.DataSource = dt;
            //显示给客户看
            comboB1.DisplayMember = "DBA002";
            //自己识别
            comboB1.ValueMember = "DBA001";
            userName = config.AppSettings.Settings["UserName"].Value;
            passWord = config.AppSettings.Settings["PassWord"].Value;
            sign = config.AppSettings.Settings["Sign"].Value;
            if ( !string.IsNullOrEmpty( userName ) )
            {
                comboB1.Text = userName;
                textB2.Text = passWord;
                checkBox1.Checked = sign.Trim( ) == "1" ? true : false;
            }
        }

        private void Action_Click ( object sender ,EventArgs e )
        {
            Logins . username = UserInfoMation . username = SelectAll . Class . LoginUser . UserName = comboB1 . Text;
            Logins . pwd = SelectAll . Class . LoginUser . UserNum = textB2 . Text;
            Logins . number = UserInfoMation . number = SelectAll . Class . LoginUser . Num = comboB1 . SelectedValue . ToString ( );
            if ( comboB1 . Text == "" )
            {
                MessageBox . Show ( "请选择登录名" );
            }
            else
            {
                string DBA002 = comboB1 . Text;
                string DBA001 = comboB1 . SelectedValue . ToString ( );
                //根据登录名获取密码
                DataTable da = SqlHelper . ExecuteDataTable ( "SELECT A.DBA965,B.DAA002 FROM TPADBA A,TPADAA B WHERE A.DBA005=B.DAA001 AND DBA001=@DBA001" ,new SqlParameter ( "@DBA001" ,DBA001 ) );
                if ( textB2 . Text == da . Rows [ 0 ] [ "DBA965" ] . ToString ( ) )
                {
                    string str = comboB1 . Text;
                    string emp = da . Rows [ 0 ] [ "DAA002" ] . ToString ( );
                    //DataTable dd = SqlHelper.ExecuteDataTable("SELECT NAME FROM R_NAME");
                    //保存登录名
                    SqlHelper . ExecuteNonQuery ( "INSERT INTO R_NAME (NAME,NUMBER,EMPLOYEE) VALUES (@NAME,@NUMBER,@EMPLOYEE)" ,new SqlParameter ( "@NAME" ,str ) ,new SqlParameter ( "@NUMBER" ,DBA001 ) ,new SqlParameter ( "@EMPLOYEE" ,emp ) );
                    //MessageBox.Show("登录成功");
                    try
                    {
                        if ( checkBox1 . Checked )
                            AccessAppSeting ( comboB1 . Text ,textB2 . Text ,"1" );
                        else
                            AccessAppSeting ( comboB1 . Text ,"" ,"" );
                    }
                    catch { }
                    //返回给program.cs一个登录成功的状态
                    this . DialogResult = DialogResult . OK;
                    this . Close ( );
                }
                else
                {
                    MessageBox . Show ( "登录失败,请检查登录名或密码是否正确" );
                }
            }
        }

        void AccessAppSeting ( string userName ,string passWord ,string sign )
        {
            //删除<add>元素
            config.AppSettings.Settings.Remove( "UserName" );
            config.AppSettings.Settings.Remove( "PassWord" );
            config.AppSettings.Settings.Remove( "Sign" );
            //写入<add>元素的value
            //config.AppSettings.Settings["UserName"].Value = userName;
            //config.AppSettings.Settings["PassWord"].Value = passWord;
            //增加<add> 元素
            config.AppSettings.Settings.Add( "UserName" ,userName );
            config.AppSettings.Settings.Add( "PassWord" ,passWord );
            config.AppSettings.Settings.Add( "Sign" ,sign );
            //一定要记得保存，写不带参数的config.Save()也可以
            config.Save( ConfigurationSaveMode.Modified );
            //刷新，否则程序读取的还是之前的值（可能已装入内存）
            System.Configuration.ConfigurationManager.RefreshSection( "appSettings" );
        }

        private void comboB1_SelectedValueChanged ( object sender ,EventArgs e )
        {
            if ( comboB1.Text == userName )
            {
                textB2.Text = passWord;
                checkBox1.Checked = sign.Trim( ) == "1" ? true : false;
            }
            else
            {
                textB2.Text = "";
                checkBox1.Checked = false;
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class Logins
    {
        public static string username =string.Empty;
        public static string pwd =string.Empty;
        public static string number =string.Empty;

        public static string tableNum=string.Empty;
        public static string tableName=string.Empty;


    }
}

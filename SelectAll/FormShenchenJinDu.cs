using System;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class FormShenchenJinDu :DevExpress . XtraEditors . XtraForm
    {
        DataRow row=null;
        MulaolaoBll.Bll.ShenChanJinDuJiHuaBll bll = null;
        int nums =0,num = 0;

        public FormShenchenJinDu ( DataRow row )
        {
            InitializeComponent ( );

            bll = new MulaolaoBll . Bll . ShenChanJinDuJiHuaBll ( );

            this . row = row;
            this . Text = row [ "PQX38" ] . ToString ( ) + this . Text;
            setValue ( );
        }

        void setValue ( )
        {
            textBox1 . Tag = row [ "idx" ] . ToString ( );
            textBox1 . Text = row [ "PQX21" ] . ToString ( );
            textBox2 . Text = row [ "PQX13" ] . ToString ( );
            textBox3 . Text = row [ "PQX14" ] . ToString ( );
            textBox4 . Text = row [ "PQX15" ] . ToString ( );
            textBox6 . Text = row [ "PQX34" ] . ToString ( );
            radioButton1 . Checked = true;
        }
        
        private void btnOk_Click ( object sender ,EventArgs e )
        {
            errorProvider1 . Clear ( );
            if ( string . IsNullOrEmpty ( textBox5 . Text ) )
            {
                errorProvider1 . SetError ( textBox5 ,"请填写日产部件量" );
                return;
            }
            num = 0;
            if ( !string . IsNullOrEmpty ( textBox5 . Text ) && int . TryParse ( textBox5 . Text ,out num ) == false )
            {
                errorProvider1 . SetError ( textBox5 ,"请输入数字" );
                return;
            }
            nums = bll . EditAll ( row [ "idx" ] . ToString ( ) ,num ,radioButton1 . Checked == true ? "+" : "-" );
            if ( nums == -1 )
            {
                MessageBox . Show ( "编辑失败" );
                return;
            }
            num = radioButton1 . Checked == true ? +num : -num;
            this . DialogResult = DialogResult . OK;
        }

        private void btnCan_Click ( object sender ,EventArgs e )
        {
            this . DialogResult = DialogResult . Cancel;
        }

        public int getNums
        {
            get
            {
                return nums;
            }
        }
        public int getCNum
        {
            get
            {
                return num;
            }
        }

    }
}
using Mulaolao;
using System;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class FormGongXuBatch :Form
    {
        bool result=false;

        MulaolaoBll.Bll.GongXuGongZiBll bll = null;
        MulaolaoLibrary .GongXuGongZiLibrary model = null;

        public FormGongXuBatch (DataTable table,DataTable tableOne,MulaolaoLibrary.GongXuGongZiLibrary entity )
        {
            InitializeComponent ( );

            bll = new MulaolaoBll . Bll . GongXuGongZiBll ( );
            this . model = entity;

            textBox1 . Text =  model . DS03;
            textBox2 . Text = model . DS01;
            textBox3 . Text = model . DS04;

            comboBox1 . DataSource = table;
            comboBox1 . DisplayMember = "GZ03";

            comboBox2 . DataSource = tableOne;
            comboBox2 . DisplayMember = "GX02";
        }
        
        private void btnOk_Click ( object sender ,EventArgs e )
        {
            if ( xtraTabControl1 . SelectedTabPage . Name == "TabPageOne" )
            {
                if ( string . IsNullOrEmpty ( comboBox1 . Text ) )
                {
                    MessageBox . Show ( "请选择部件名称" );
                    return;
                }
                result = bll . Batch ( model . DS01 ,model . DS21 ,"R_436" ,"产品定时、定量、定额工序工资明细表" ,model . DS20 ,DateTime . Now ,"批量编辑" ,"批量编辑" ,comboBox1 . Text ,model . DS03 );
                if ( result )
                {
                    MessageBox . Show ( "成功编辑" );
                    this . DialogResult = DialogResult . OK;
                }
                else
                    MessageBox . Show ( "编辑失败" );
            }
            
        }

        private void btnCancel_Click ( object sender ,EventArgs e )
        {
            this . DialogResult = DialogResult . Cancel;
        }

        public string getStr
        {
            get
            {
                return comboBox1 . Text;
            }
        }

        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( xtraTabControl1 . SelectedTabPage . Name == "TabPageTwo" )
            {
                if ( string . IsNullOrEmpty ( comboBox2 . Text ) )
                {
                    MessageBox . Show ( "请选择工序名称" );
                    return;
                }
                result = bll . BatchGX ( model . DS01 ,model . DS21 ,"R_436" ,"产品定时、定量、定额工序工资明细表" ,model . DS20 ,DateTime . Now ,"批量编辑" ,"批量编辑" ,comboBox2 . Text ,textBox3 . Text );
                if ( result )
                {
                    MessageBox . Show ( "成功编辑" );
                    this . DialogResult = DialogResult . OK;
                }
                else
                    MessageBox . Show ( "编辑失败" );
            }
        }

        private void button1_Click ( object sender ,EventArgs e )
        {
            this . DialogResult = DialogResult . Cancel;
        }
    }
}

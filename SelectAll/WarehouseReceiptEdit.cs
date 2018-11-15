using System;
using System . Windows . Forms;
using Mulaolao . Class;

namespace SelectAll
{
    public partial class WarehouseReceiptEdit :Form
    {
        MulaolaoLibrary . WarehouseReceiptWAREntity _war =null;
        bool result=false; MulaolaoBll . Bll . WarehouseReceiptBll _bll = new MulaolaoBll . Bll . WarehouseReceiptBll ( );

        public WarehouseReceiptEdit ( string text ,MulaolaoLibrary . WarehouseReceiptWAREntity _war )
        {
            InitializeComponent ( );

            this . Text = text;

            if ( this . Text . Equals ( "编辑" ) )
                this . _war = _war;
            
            
            comboBox1 . DataSource = _bll . GetDataTableOnly ( "WAR001" ,"R_PQWAR" );
            comboBox1 . DisplayMember = "WAR001";
            comboBox2 . DataSource = _bll . GetDataTableOnly ( "WAR004" ,"R_PQWAR" );
            comboBox2 . DisplayMember = "WAR004";
            comboBox3 . DataSource = _bll . GetDataTableOnly ( "WAR005" ,"R_PQWAR" );
            comboBox3 . DisplayMember = "WAR005";
            comboBox4 . DataSource = _bll . GetDataTableOnly ( "WAR007" ,"R_PQWAR" );
            comboBox4 . DisplayMember = "WAR007";
            comboBox5 . DataSource = _bll . GetDataTableOnly ( "WAR010" ,"R_PQWAR" );
            comboBox5 . DisplayMember = "WAR010";
            lookUpEdit12 . Properties . DataSource = _bll . GetDataTablePerson ( );
            lookUpEdit12 . Properties . DisplayMember = "DBA002";
            lookUpEdit12 . Properties . ValueMember = "DBA001";
            lookUpEdit2 . Properties . DataSource = _bll . GetDataTablePerson ( );
            lookUpEdit2 . Properties . DisplayMember = "DBA002";
            lookUpEdit2 . Properties . ValueMember = "DBA001";
        }
        
        private void WarehouseReceiptEdit_Load ( object sender ,System . EventArgs e )
        {
            if ( _war != null )
            {
                comboBox1 . Text = _war . WAR001;
                comboBox1 . Tag = _war . idx . ToString ( );
                comboBox2 . Text = _war . WAR004;
                if ( _war . WAR002 != null )
                    dateTimePicker1 . Value = _war . WAR002;
                comboBox3 . Text = _war . WAR005;
                lookUpEdit12 . Text = _war . WAR003;
                textBox1 . Text = _war . WAR006 . ToString ( );
                comboBox4 . Text = _war . WAR007;
                comboBox5 . Text = _war . WAR010;
                textBox2 . Text = _war . WAR008 . ToString ( );
                textBox3 . Text = _war . WAR009 . ToString ( );
                lookUpEdit2 . Text = _war . WAR011;
                richTextBox1 . Text = _war . WAR012;
            }
        }

        //确定
        private void button2_Click ( object sender ,System . EventArgs e )
        {
            if ( string . IsNullOrEmpty ( comboBox1.Text ) )
            {
                MessageBox . Show ( "物料类别不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( comboBox2 . Text ) )
            {
                MessageBox . Show ( "物料名称不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( lookUpEdit12 . Text ) )
            {
                MessageBox . Show ( "申购人不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( textBox1 . Text ) )
            {
                MessageBox . Show ( "入库数量不可为空" );
                return;
            }

            _war = new MulaolaoLibrary . WarehouseReceiptWAREntity ( );
            _war . WAR001 = comboBox1 . Text;
            _war . WAR004 = comboBox2 . Text;
            _war . WAR002 = dateTimePicker1 . Value;
            _war . WAR005 = comboBox3 . Text;
            _war . WAR003 = lookUpEdit12 . Text;
            _war . WAR006 = string . IsNullOrEmpty ( textBox1 . Text ) == true ? 0 : Convert . ToInt32 ( textBox1 . Text );
            _war . WAR007 = comboBox4 . Text;
            _war . WAR010 = comboBox5 . Text;
            _war . WAR008 = string . IsNullOrEmpty ( textBox2 . Text ) == true ? 0 : Convert . ToDecimal ( textBox2 . Text );
            _war . WAR009 = string . IsNullOrEmpty ( textBox3 . Text ) == true ? 0 : Convert . ToDecimal ( textBox3 . Text );
            _war . WAR011 = lookUpEdit2 . Text;
            _war . WAR012 = richTextBox1 . Text;

            
            if ( this . Text . Equals ( "新增" ) )
            {
                result = _bll . AddS ( _war );
                if ( result == true )
                {
                    MessageBox . Show ( "新增成功" );
                    this . DialogResult = DialogResult . OK;
                }
                else
                    MessageBox . Show ( "新增失败" );
            }
            else
            {
                _war . idx = Convert . ToInt32 ( comboBox1 . Tag );
                result = _bll . EditS ( _war );
                if ( result == true )
                {
                    MessageBox . Show ( "编辑成功" );
                    this . DialogResult = DialogResult . OK;
                }
                else
                    MessageBox . Show ( "编辑失败" );
            }

        }
        //取消
        private void button1_Click ( object sender ,System . EventArgs e )
        {
            this . DialogResult = DialogResult . Cancel;
        }

        private void textBox1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay . intgra ( e );
        }

        private void textBox3_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay . fractionTb ( e ,textBox3 );         
        }
        private void textBox3_TextChanged ( object sender ,EventArgs e )
        {
            DateDay . textChangeTb ( textBox3 );
        }
        private void textBox3_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox3 . Text != "" && !DateDay . elevenForNumber ( textBox3 ) )
            {
                this . textBox3 . Text = "";
                MessageBox . Show ( "只允许输入整数部分最多七位,小数部分最多四位,如9999999.9999,请重新输入" );
            }
        }

        void readSP ( )
        {
            if ( this . Text . Equals ( "新增" ) )
            {
                textBox2 . Text = _bll . priceS ( comboBox1 . Text ,comboBox2 . Text ,comboBox3 . Text ) . ToString ( );
            }
        }

        private void comboBox1_TextChanged ( object sender ,EventArgs e )
        {
            readSP ( );
        }
    }
}

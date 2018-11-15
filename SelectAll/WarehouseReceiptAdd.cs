using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class WarehouseReceiptAdd :Form
    {
        MulaolaoLibrary.WarehouseReceiptWASEntity _was=null;
        MulaolaoBll .Bll.WarehouseReceiptBll _bll=new MulaolaoBll.Bll.WarehouseReceiptBll();
        DataTable dtOther,da;bool result=false;

        public WarehouseReceiptAdd ( string text ,MulaolaoLibrary . WarehouseReceiptWASEntity _was )
        {
            InitializeComponent ( );

            this . Text = text;
            if ( this . Text . Equals ( "编辑" ) )
                this . _was = _was;

            da = _bll . GetDataTableOnly ( "idx,WAR001,WAR003,WAR004,WAR005,WAR007,WAR009,WAR010,WAR011" ,"R_PQWAR" );
            lookUpEdit14 . Properties . DataSource = da;
            lookUpEdit14 . Properties . DisplayMember = "WAR001";
            lookUpEdit14 . Properties . ValueMember = "idx";
            //lookUpEdit3 . Properties . DataSource = _bll . GetDataTableOnly ( "WAR004" ,"R_PQWAR" );
            //lookUpEdit3 . Properties . DisplayMember = "WAR004";
            //lookUpEdit4 . Properties . DataSource = _bll . GetDataTableOnly ( "WAR005" ,"R_PQWAR" );
            //lookUpEdit4 . Properties . DisplayMember = "WAR005";
            lookUpEdit2 . Properties . DataSource = _bll . GetDataTablePerson ( );
            lookUpEdit2 . Properties . DisplayMember = "DBA002";
            lookUpEdit2 . Properties . ValueMember = "DBA001";
        }

        private void WarehouseReceiptAdd_Load ( object sender ,System . EventArgs e )
        {
            if ( _was != null )
            {
                lookUpEdit14 . EditValue = _was . WAS012;
                //lookUpEdit14 . Text = _was . WAS001;
                lookUpEdit14 . Tag = _was . idx;
                //lookUpEdit3 . Text = _was . WAS004;
                dateTimePicker1 . Value = _was . WAS002;
                //lookUpEdit4 . Text = _was . WAS005;
                textBox1 . Text = _was . WAS006 . ToString ( );
                textBox2 . Text = _was . WAS007 . ToString ( );
                textBox3 . Text = _was . WAS008 . ToString ( );
                lookUpEdit2 . Text = _was . WAS009;
                richTextBox1 . Text = _was . WAS010;
            }
        }
        
        private void lookUpEdit14_EditValueChanged ( object sender ,System . EventArgs e )
        {
            if ( !string . IsNullOrEmpty ( lookUpEdit14 . Text ) && da . Select ( "idx='" + lookUpEdit14 . EditValue . ToString ( ) + "'" ).Length>0 )
            {
                textBox6 . Text = da . Select ( "idx='" + lookUpEdit14 . EditValue . ToString ( ) + "'" ) [ 0 ] [ "WAR003" ] . ToString ( );
                textBox8 . Text = da . Select ( "idx='" + lookUpEdit14 . EditValue . ToString ( ) + "'" ) [ 0 ] [ "WAR004" ] . ToString ( );
                textBox7 . Text = da . Select ( "idx='" + lookUpEdit14 . EditValue . ToString ( ) + "'" ) [ 0 ] [ "WAR005" ] . ToString ( );
                textBox5 . Text = da . Select ( "idx='" + lookUpEdit14 . EditValue . ToString ( ) + "'" ) [ 0 ] [ "WAR007" ] . ToString ( );
                textBox3 . Text = da . Select ( "idx='" + lookUpEdit14 . EditValue . ToString ( ) + "'" ) [ 0 ] [ "WAR009" ] . ToString ( );
                textBox4 . Text = da . Select ( "idx='" + lookUpEdit14 . EditValue . ToString ( ) + "'" ) [ 0 ] [ "WAR010" ] . ToString ( );
            }
            //readL ( );
            readLP ( );
        }

        void readL ( )
        {
            dtOther = _bll . GetDataTableOther ( lookUpEdit14 . EditValue . ToString ( ) );
            if ( dtOther != null && dtOther . Rows . Count > 0 )
            {
                textBox6 . Text = dtOther . Rows [ 0 ] [ "WAR003" ] . ToString ( );
                textBox5 . Text = dtOther . Rows [ 0 ] [ "WAR007" ] . ToString ( );
                textBox4 . Text = dtOther . Rows [ 0 ] [ "WAR010" ] . ToString ( );
                textBox3 . Text = dtOther . Rows [ 0 ] [ "WAR009" ] . ToString ( );
            }
            else
                textBox6 . Text = textBox5 . Text = textBox4 . Text = string . Empty;
        }
        void readLP ( )
        {
            if ( this . Text . Equals ( "新增" ) )
            {
                textBox2 . Text = _bll . price ( lookUpEdit14 . Text ,textBox8 . Text ,textBox7 . Text ) . ToString ( );
            }
        }

        //确认
        private void button2_Click ( object sender ,System . EventArgs e )
        {
            if ( string . IsNullOrEmpty ( lookUpEdit14 . Text ) )
            {
                MessageBox . Show ( "物料类别不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( textBox1 . Text ) )
            {
                MessageBox . Show ( "领用数量不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( lookUpEdit2 . Text ) )
            {
                MessageBox . Show ( "领用人不可为空" );
                return;
            }

            _was = new MulaolaoLibrary . WarehouseReceiptWASEntity ( );
            _was . WAS001 = lookUpEdit14 . Text;
            _was . WAS004 = textBox8 . Text;
            _was . WAS002 = dateTimePicker1 . Value;
            _was . WAS005 = textBox7 . Text;
            _was . WAS006 = string . IsNullOrEmpty ( textBox1 . Text ) == true ? 0 : Convert . ToInt32 ( textBox1 . Text );
            _was . WAS007 = string . IsNullOrEmpty ( textBox2 . Text ) == true ? 0 : Convert . ToDecimal ( textBox2 . Text );
            _was . WAS008 = string . IsNullOrEmpty ( textBox3 . Text ) == true ? 0 : Convert . ToDecimal ( textBox3 . Text );
            _was . WAS009 = lookUpEdit2 . Text;
            _was . WAS010 = richTextBox1 . Text;
            _was . WAS012 = string . IsNullOrEmpty ( lookUpEdit14 . EditValue . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( lookUpEdit14 . EditValue . ToString ( ) );

            if ( this . Text . Equals ( "新增" ) )
            {
                result = _bll . AddL ( _was );
                if ( result == true )
                {
                    MessageBox . Show ( "新增成功" );
                    this . DialogResult = DialogResult . OK;
                }
                else
                    MessageBox . Show ( "新增失败" );
            }
            else if ( this . Text . Equals ( "编辑" ) )
            {
                _was . idx = string . IsNullOrEmpty ( lookUpEdit14 . Tag . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( lookUpEdit14 . Tag );
                result = _bll . EditL ( _was );
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

    }
}

using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Contract
{
    public partial class FormWarehouseReceipt :FormChild
    {
        MulaolaoLibrary.WarehouseReceiptWAREntity _war=null;
        MulaolaoLibrary.WarehouseReceiptWASEntity _was=null;
        MulaolaoBll.Bll.WarehouseReceiptBll _bll=null;
        string strWhere="1=1";
        DataTable tableOne,tableTwo,tableQuery;
        int num=0;bool isOk=false;
        
        public FormWarehouseReceipt ( )
        {
            InitializeComponent ( );

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GridViewMoHuSelect . SetFilter ( gridView2 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 ,gridView2 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;

            button3 . Enabled = button4 . Enabled = button5 . Enabled = button6. Enabled = /*button7 . Enabled = button8 . Enabled =*/ false;

            _war = new MulaolaoLibrary . WarehouseReceiptWAREntity ( );
            _was = new MulaolaoLibrary . WarehouseReceiptWASEntity ( );
            _bll = new MulaolaoBll . Bll . WarehouseReceiptBll ( );
            tableOne = new DataTable ( );
            tableTwo = new DataTable ( );

            comboBox1 . DataSource = _bll . GetDataTableOnly ( "WAR001" ,"R_PQWAR" );
            comboBox1 . DisplayMember = "WAR001";
            comboBox2 . DataSource = _bll . GetDataTableOnly ( "WAR004" ,"R_PQWAR" );
            comboBox2 . DisplayMember = "WAR004";
            comboBox3 . DataSource = _bll . GetDataTableOnly ( "WAR005" ,"R_PQWAR" );
            comboBox3 . DisplayMember = "WAR005";
            comboBox4  . DataSource = _bll . GetDataTableOnly ( "WAR010" ,"R_PQWAR" );
            comboBox4  . DisplayMember = "WAR010";
            comboBox5 . DataSource = _bll . GetDataTableOnly ( "WAR007" ,"R_PQWAR" );
            comboBox5 . DisplayMember = "WAR007";
            lookUpEdit7 . Properties . DataSource = _bll . GetDataTablePerson ( );
            lookUpEdit7 . Properties . DisplayMember = "DBA002";
            lookUpEdit3 . Properties . DataSource = _bll . GetDataTablePerson ( );
            lookUpEdit3 . Properties . DisplayMember = "DBA002";

            tableQuery = _bll . GetDataTableOnly ( "idx,WAR001,WAR003,WAR004,WAR005,WAR007,WAR009,WAR010,WAR011" ,"R_PQWAR" );
            //lookUpEdit14 . Properties . DataSource = tableQuery;
            //lookUpEdit14 . Properties . DisplayMember = "WAR001";
            //lookUpEdit14 . Properties . ValueMember = "idx";
            //lookUpEdit8 . Properties . DataSource = _bll . GetDataTablePerson ( );
            //lookUpEdit8 . Properties . DisplayMember = "DBA002";
        }
        
        #region Main
        protected override void select ( )
        {
            base . select ( );

            //入
            if ( xtraTabControl1 . SelectedTabPage == TabPageTre )
            {
                getWhere ( );
                setTre ( );
            }
            //出
            if ( xtraTabControl1 . SelectedTabPage == TabPageFor )
            {
                getWhereFor ( );
                setFor ( );
            }

            toolExport . Enabled = true;
        }
        protected override void add ( )
        {
            base . add ( );

            button3 . Enabled = button4 . Enabled = button5 . Enabled = button6 . Enabled = /*button7 . Enabled = button8 . Enabled =*/ true;

            toolAdd . Enabled = toolSelect . Enabled = false;
            toolSave . Enabled = toolCancel . Enabled = true;
            toolExport . Enabled = true;
        }
        protected override void save ( )
        {
            button3 . Enabled = button4 . Enabled = button5 . Enabled = button6 . Enabled = /*button7 . Enabled = button8 . Enabled = */false;
            toolSelect . Enabled = toolAdd . Enabled = true;
            toolSave . Enabled = toolCancel . Enabled = false;
            toolExport . Enabled = true;

            base . save ( );
        }
        protected override void cancel ( )
        {
            button3 . Enabled = button4 . Enabled = button5 . Enabled = button6 . Enabled = /*button7 . Enabled = button8 . Enabled =*/ false;
            toolSelect . Enabled = toolAdd . Enabled = true;
            toolSave . Enabled = toolCancel . Enabled = false;
            toolExport . Enabled = true;

            base . cancel ( );
        }
        protected override void export ( )
        {
            if ( xtraTabControl1 . SelectedTabPage . Name . Equals ( "TabPageTre" ) )
                ViewExport . ExportToExcel ( this . Text + "入库单" ,gridControl1 );
            if ( xtraTabControl1 . SelectedTabPage . Name . Equals ( "TabPageFor" ) )
                ViewExport . ExportToExcel ( this . Text + "出库单" ,gridControl2 );

            base . export ( );
        }
        #endregion

        #region Table
        //新建
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( getTre ( ) == false )
                return;
            isOk = _bll . AddS ( _war );
            if ( isOk == true )
            {
                MessageBox . Show ( "新建成功" );
                setTre ( );
            }
            else
                MessageBox . Show ( "新建失败" );
        }
        //编辑
        private void button4_Click ( object sender ,EventArgs e )
        {
            if ( getTre ( ) == false )
                return;
            isOk = _bll . EditS ( _war );
            if ( isOk == true )
            {
                MessageBox . Show ( "编辑成功" );
                setTre ( );
            }
            else
                MessageBox . Show ( "编辑失败" );
        }
        //删除
        private void button5_Click ( object sender ,EventArgs e )
        {
            if ( _war . idx < 0 )
                return;

            isOk = _bll . Exists ( _war . idx );
            if ( isOk == true )
            {
                MessageBox . Show ( "已经被领用,不允许删除" );
                return;
            }
            isOk = _bll . DeleteS ( _war . idx );
            if ( isOk == true )
            {
                MessageBox . Show ( "删除成功" );
                tableOne . Rows . RemoveAt ( num );
            }
            else
                MessageBox . Show ( "删除失败,请重试" );
        }

        //新建
        private void button8_Click ( object sender ,EventArgs e )
        {
            if ( getFor ( ) == false )
                return;
            isOk = _bll . AddL ( _was );
            if ( isOk == true )
            {
                MessageBox . Show ( "新建成功" );
                setFor ( );
            }
            else
                MessageBox . Show ( "新建失败" );
        }
        //编辑
        private void button7_Click ( object sender ,EventArgs e )
        {
            if ( getFor ( ) == false )
                return;
            isOk = _bll . EditL ( _was );
            if ( isOk == true )
            {
                MessageBox . Show ( "编辑成功" );
                setFor ( );
            }
            else
                MessageBox . Show ( "编辑失败" );
        }
        //删除
        private void button6_Click ( object sender ,EventArgs e )
        {
            if ( _was . idx < 0 )
                return;
            isOk = _bll . DeleteL ( _was . idx );
            if ( isOk == true )
            {
                MessageBox . Show ( "删除成功" );
                tableTwo . Rows . RemoveAt ( num );
            }
            else
                MessageBox . Show ( "删除失败,请重试" );
        }
        #endregion

        #region Method
        //入
        void getWhere ( )
        {
            strWhere = "1=1";

            if ( !string . IsNullOrEmpty ( comboBox1 . Text ) )
                strWhere = strWhere + " AND WAR001 ='" + comboBox1 . Text + "'";
            if ( !string . IsNullOrEmpty ( lookUpEdit3 . Text ) )
                strWhere = strWhere + " AND WAR003 ='" + lookUpEdit3 . Text + "'";
            if ( !string . IsNullOrEmpty ( comboBox2 . Text ) )
                strWhere = strWhere + " AND WAR004 ='" + comboBox2 . Text + "'";
            if ( !string . IsNullOrEmpty ( comboBox3 . Text ) )
                strWhere = strWhere + " AND WAR005 ='" + comboBox3 . Text + "'";
            if ( !string . IsNullOrEmpty ( comboBox4 . Text ) )
                strWhere = strWhere + " AND WAR010 ='" + comboBox4 . Text + "'";
            if ( !string . IsNullOrEmpty ( lookUpEdit7 . Text ) )
                strWhere = strWhere + " AND WAR011 ='" + lookUpEdit7 . Text + "'";
        }
        void setTre ( )
        {
            tableOne = _bll . GetDataTableS ( strWhere );
            gridControl1 . DataSource = tableOne;
        }
        void getWar ( )
        {
            _war = _bll . GetDataTableS ( _war . idx );
            if ( _war == null )
                return;
            comboBox1 . Text = _war . WAR001;
            if ( _war . WAR002 != null )
                dateTimePicker1 . Value = _war . WAR002;
            lookUpEdit3 . Text = _war . WAR003;
            comboBox2 . Text = _war . WAR004;
            comboBox3 . Text = _war . WAR005;
            comboBox4 . Text = _war . WAR010;
            lookUpEdit7 . Text = _war . WAR011;
            textBox1 . Text = _war . WAR006 . ToString ( );
            textBox2 . Text = _war . WAR008 . ToString ( );
            textBox3 . Text = _war . WAR009 . ToString ( );
            comboBox5 . Text = _war . WAR007;
            textBox4 . Text = _war . WAR012;
        }
        bool getTre ( )
        {
            if ( string . IsNullOrEmpty ( comboBox1 . Text ) )
            {
                MessageBox . Show ( "物料类别不可为空" );
                return false;
            }
            if ( string . IsNullOrEmpty ( lookUpEdit3 . Text ) )
            {
                MessageBox . Show ( "申购人不可为空" );
                return false;
            }
            if ( string . IsNullOrEmpty ( comboBox2 . Text ) )
            {
                MessageBox . Show ( "物料名称不可为空" );
                return false;
            }
            if ( string . IsNullOrEmpty ( comboBox3 . Text ) )
            {
                MessageBox . Show ( "规格不可为空" );
                return false;
            }
            if ( string . IsNullOrEmpty ( textBox1 . Text ) )
            {
                MessageBox . Show ( "入库数量不可为空" );
                return false;
            }
            _war . WAR001 = comboBox1 . Text;
            _war . WAR002 = dateTimePicker1 . Value;
            _war . WAR003 = lookUpEdit3 . Text;
            _war . WAR004 = comboBox2 . Text;
            _war . WAR005 = comboBox3 . Text;
            _war . WAR006 = string . IsNullOrEmpty ( textBox1 . Text ) == true ? 0 : Convert . ToDecimal ( textBox1 . Text );
            _war . WAR007 = comboBox5 . Text;
            _war . WAR008 = string . IsNullOrEmpty ( textBox2 . Text ) == true ? 0 : Convert . ToDecimal ( textBox2 . Text );
            _war . WAR009 = string . IsNullOrEmpty ( textBox3 . Text ) == true ? 0 : Convert . ToDecimal ( textBox3 . Text );        
            _war . WAR010 = comboBox4 . Text;
            _war . WAR011 = lookUpEdit7 . Text;
            _war . WAR012 = textBox4 . Text;

            return true;         
        }
        //出
        void getWhereFor ( )
        {
            strWhere = "1=1";
            //if ( !string . IsNullOrEmpty ( lookUpEdit14 . Text ) )
            //    strWhere = strWhere + " AND WAS001='" + lookUpEdit14 . Text + "'";
            //if ( !string . IsNullOrEmpty ( textBox6 . Text ) )
            //    strWhere = strWhere + " AND WAS004='" + textBox6 . Text + "'";
            //if ( !string . IsNullOrEmpty ( textBox7 . Text ) )
            //    strWhere = strWhere + " AND WAS005='" + textBox7 . Text + "'";
            //if ( !string . IsNullOrEmpty ( lookUpEdit8 . Text ) )
            //    strWhere = strWhere + " AND WAS009='" + lookUpEdit8 . EditValue . ToString ( ) + "'";
        }
        void setFor ( )
        {
            tableTwo = _bll . GetDataTableL ( strWhere );
            gridControl2 . DataSource = tableTwo;
        }
        void getWas ( )
        {
            _was = _bll . GetDataTableL ( _was . idx );
            if ( _was == null )
                return;

            //lookUpEdit14 . Text = _was . WAS001;
            //if ( _was . WAS002 != null )
            //    dateTimePicker2 . Value = _was . WAS002;
            //lookUpEdit8 . Text = _was . WAS009;
            //textBox9 . Text = _was . WAS006 . ToString ( );
            //textBox11 . Text = _was . WAS007 . ToString ( );
            //textBox10 . Text = _was . WAS008 . ToString ( );
            //textBox12 . Text = _was . WAS010;
            //textBox7 . Text = _was . WAS005;
            //textBox6 . Text = _was . WAS004;
        }
        bool getFor ( )
        {
            //if ( string . IsNullOrEmpty ( lookUpEdit14 . Text ) )
            //{
            //    MessageBox . Show ( "物料类别不可为空" );
            //    return false;
            //}
            //if ( string . IsNullOrEmpty ( textBox9 . Text ) )
            //{
            //    MessageBox . Show ( "领用数量不可为空" );
            //    return false;
            //}
            //if ( string . IsNullOrEmpty ( lookUpEdit8 . Text ) )
            //{
            //    MessageBox . Show ( "领用人不可为空" );
            //    return false;
            //}
            //_was . WAS001 = lookUpEdit14 . Text;
            //_was . WAS002 = dateTimePicker2 . Value;
            //_was . WAS004 = textBox6 . Text;
            //_was . WAS005 = textBox7 . Text;         
            //_was . WAS006 = string . IsNullOrEmpty ( textBox9 . Text ) == true ? 0 : Convert . ToInt32 ( textBox9 . Text );
            //_was . WAS007 = string . IsNullOrEmpty ( textBox11 . Text ) == true ? 0 : Convert . ToDecimal ( textBox11 . Text );
            //_was . WAS008 = string . IsNullOrEmpty ( textBox10 . Text ) == true ? 0 : Convert . ToDecimal ( textBox10 . Text );
            //_was . WAS009 = lookUpEdit8 . Text;
            //_was . WAS010 = textBox12 . Text;

            return true;
        }
        #endregion

        #region Event
        //入
        private void gridView1_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            num = gridView1 . FocusedRowHandle;
            if ( num >= 0 && num <= gridView1 . DataRowCount - 1 )
            {
                _war . idx = string . IsNullOrEmpty ( gridView1 . GetDataRow ( num ) [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( gridView1 . GetDataRow ( num ) [ "idx" ] . ToString ( ) );
                getWar ( );
            }
        }
        //出
        private void gridView2_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            num = gridView2 . FocusedRowHandle;
            if ( num >= 0 && num <= gridView2 . DataRowCount - 1 )
            {
                _was . idx = string . IsNullOrEmpty ( gridView2 . GetDataRow ( num ) [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( gridView2 . GetDataRow ( num ) [ "idx" ] . ToString ( ) );
                //getWas ( );
                //textBox8 . Text = gridView2 . GetDataRow ( num ) [ "WAR010" ] . ToString ( );
                //textBox14 . Text = gridView2 . GetDataRow ( num ) [ "WAR011" ] . ToString ( );
            }
        }
        private void button1_Click ( object sender ,EventArgs e )
        {
            comboBox1 . Text = comboBox2 . Text = comboBox3 . Text = comboBox4 . Text = comboBox5 . Text =textBox4.Text= string . Empty;
            lookUpEdit7 . EditValue = lookUpEdit3 . EditValue = null;
        }
        private void button2_Click ( object sender ,EventArgs e )
        {
            //lookUpEdit14 . EditValue =  lookUpEdit8 . EditValue = null;
            //textBox5 . Text = textBox6 . Text = textBox7 . Text = textBox8 . Text = textBox9 . Text = textBox10 . Text = textBox11 . Text = textBox12 . Text = textBox13 . Text = textBox14 . Text = string . Empty;
        }
        private void textBox1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise . fractionTb ( e ,textBox1 );
        }
        private void textBox1_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise . textChangeTb ( textBox1 );
        }
        private void textBox1_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox1 . Text != "" && !DateDayRegise . elevenTreNumber ( textBox1 ) )
            {
                this . textBox1 . Text = "";
                MessageBox . Show ( "只允许输入整数部分最多七位,小数部分最多四位,如99999999.999,请重新输入" );
            }
        }
        private void textBox10_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            //DateDayRegise . fractionTb ( e ,textBox10 );
        }
        private void textBox10_TextChanged ( object sender ,EventArgs e )
        {
            //DateDayRegise . textChangeTb ( textBox10 );
        }
        private void textBox10_LostFocus ( object sender ,EventArgs e )
        {
            //if ( textBox10 . Text != "" && !DateDayRegise . elevenForNumber ( textBox10 )  )
            //{
            //    this . textBox10 . Text = "";
            //    MessageBox . Show ( "只允许输入整数部分最多七位,小数部分最多四位,如9999999.9999,请重新输入" );
            //}
        }
        private void textBox9_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise . intgra ( e );
        }
        private void lookUpEdit14_EditValueChanged ( object sender ,EventArgs e )
        {
            //if ( !string . IsNullOrEmpty ( lookUpEdit14 . Text ) )
            //{
            //    _was . WAS012 = Convert . ToInt32 ( lookUpEdit14 . EditValue . ToString ( ) );
            //    textBox5 . Text = tableQuery . Select ( "idx='" + _was . WAS012 + "'" ) [ 0 ] [ "WAR003" ] . ToString ( );
            //    textBox6 . Text = tableQuery . Select ( "idx='" + _was . WAS012 + "'" ) [ 0 ] [ "WAR004" ] . ToString ( );
            //    textBox7 . Text = tableQuery . Select ( "idx='" + _was . WAS012 + "'" ) [ 0 ] [ "WAR005" ] . ToString ( );
            //    textBox8 . Text = tableQuery . Select ( "idx='" + _was . WAS012 + "'" ) [ 0 ] [ "WAR010" ] . ToString ( );
            //    textBox10 . Text = tableQuery . Select ( "idx='" + _was . WAS012 + "'" ) [ 0 ] [ "WAR009" ] . ToString ( );
            //    textBox14 . Text = tableQuery . Select ( "idx='" + _was . WAS012 + "'" ) [ 0 ] [ "WAR011" ] . ToString ( );
            //    textBox13 . Text = tableQuery . Select ( "idx='" + _was . WAS012 + "'" ) [ 0 ] [ "WAR007" ] . ToString ( );
            //}
        }
        private void comboBox1_TextChanged ( object sender ,EventArgs e )
        {
            if ( !string . IsNullOrEmpty ( comboBox1 . Text ) && !string . IsNullOrEmpty ( comboBox2 . Text ) )
            {
                textBox2 . Text = _bll . priceOne ( comboBox1 . Text ,comboBox2 . Text ) . ToString ( );
            }
        }
        private void textBox6_TextChanged ( object sender ,EventArgs e )
        {
            //if ( !string . IsNullOrEmpty ( lookUpEdit14 . Text ) && !string . IsNullOrEmpty ( textBox6 . Text ) )
            //{
            //    textBox11 . Text = _bll . priceOne ( lookUpEdit14 . Text ,textBox6 . Text ) . ToString ( );
            //}
        }
        //出库
        private void button9_Click ( object sender ,EventArgs e )
        {
            if ( Logins . number . Equals ( "MLL-0020" ) || Logins . number . Equals ( "MLL-0004" ) || Logins . number . Equals ( "MLL-0001" ) )
            {
                SelectAll . WarehouseReceiptLibr from = new SelectAll . WarehouseReceiptLibr ( Logins . number );
                if ( from . ShowDialog ( ) == DialogResult . OK )
                {
                    getWhereFor ( );
                    setFor ( );
                }
            }
            else
                MessageBox . Show ( "您无权出库" );
        }
        #endregion

    }
}

using Mulaolao.Class;
using System;
using FastReport;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using FastReport.Export.Xml;
using StudentMgr;

namespace Mulaolao.Contract
{
    public partial class R_FrmDuanLiaoContract : FormChild
    {
        public R_FrmDuanLiaoContract ( )
        {
            InitializeComponent( );
            
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GridViewMoHuSelect . SetFilter ( gridView2 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1,gridView2} );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        MulaolaoBll.Bll.DaunLiaoBll bll = new MulaolaoBll.Bll.DaunLiaoBll( );
        MulaolaoLibrary.DuanLiaoLibrary model = new MulaolaoLibrary.DuanLiaoLibrary( );
        Report report = new Report( );
        DataSet RDataSet;
        List<SplitContainer> spList = new List<SplitContainer>( );
        string sign = "", weihu = "", strWhere = "1=1", copy = "", file = "", stateOfOdd = "";
        bool result = false;
        DataTable tableQuery, tableTwo;

        private void R_FrmDuanLiaoContract_Load ( object sender ,EventArgs e )
        {
            Power( this );

            spList.Clear( );
            spList.AddRange( new SplitContainer[] { splitContainer1 ,splitContainer2 ,splitContainer3 } );
            Ergodic.FormEvery( this );
            Ergodic.SpliEnableFalse( spList );
            Ergodic.SpliClear( spList );
            gridControl1.DataSource = null;
            gridControl2.DataSource = null;
            label45.Visible = false;
            label46.Visible = false;
            textBox13.Enabled = false;

            comboBox2.Items.Clear( );
            comboBox2.Items.AddRange( new string[] { "荷木" ,"橡胶木" ,"榉木" ,"硬杂木" ,"新西兰松" ,"椴木" ,"软杂木" ,"密度板" ,"胶合板" ,"三聚青胺" } );

            comboBox4.DataSource = bll.GetTableOfCl( );
            comboBox4.DisplayMember = "IZ035";
        }
        
        private void R_FrmDuanLiaoContract_Shown ( object sender ,EventArgs e )
        {
            model.IZ001 = Merges.oddNum;
            if ( model.IZ001 != null && model.IZ001 != "" )
                autoQuery( );
            Merges.oddNum = "";
        }
        
        #region Print
        void createPrint ( )
        {
            RDataSet = new DataSet( );
            DataTable print = bll.GetDataTablePrint( model.IZ001 );
            DataTable prints = bll.GetDataTablePrints( model.IZ001 );
            print.TableName = "R_PQIZ";
            prints.TableName = "R_PQIZS";
            RDataSet.Tables.Add( print );
            RDataSet.Tables.Add( prints );
        }
        #endregion

        #region Event
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox1.Text ) )
            {
                MessageBox.Show( "流水号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox6.Text ) )
            {
                textBox6.Text = Logins.username;
                model.IZ006 = textBox6.Text;

                string[] str = new string[2];
                str = oddNumbers.contractBatch( "R_PQIZ" ,model.IZ006 ,textBox6 ,textBox7 ,"IZ007" );
                if ( str[0] == "" )
                    textBox7.Text = "";
                else
                    model.IZ007 = str[1];
                textBox7.Text = str[1];
                textBox8.Text = textBox6.Text;
            }
            else if ( !string.IsNullOrEmpty( textBox6.Text ) && textBox6.Text == Logins.username )
            {
                textBox6.Text = "";
                textBox7.Text = "";
                model.IZ006 = model.IZ007 = "";
                textBox8.Text = "";
            }
        }
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox8.Text ) )
                textBox8.Text = Logins.username;
            else if ( !string.IsNullOrEmpty( textBox8.Text ) && textBox8.Text == Logins.username )
                textBox8.Text = "";
        }
        private void button4_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox9.Text ) )
                textBox9.Text = Logins.username;
            else if ( !string.IsNullOrEmpty( textBox9.Text ) && textBox9.Text == Logins.username )
                textBox9.Text = "";

            dateTimePicker1 . Value = DateTime . Now;
        }
        private void button5_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox10.Text ) )
                textBox10.Text = Logins.username;
            else if ( !string.IsNullOrEmpty( textBox10.Text ) && textBox10.Text == Logins.username )
                textBox10.Text = "";

            dateTimePicker2 . Value = DateTime . Now;
        }
        private void button6_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox11.Text ) )
                textBox11.Text = Logins.username;
            else if ( !string.IsNullOrEmpty( textBox11.Text ) && textBox11.Text == Logins.username )
                textBox11.Text = "";

            dateTimePicker3 . Value = DateTime . Now;
        }
        private void button7_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox12.Text ) )
                textBox12.Text = Logins.username;
            else if ( !string.IsNullOrEmpty( textBox12.Text ) && textBox12.Text == Logins.username )
                textBox12.Text = "";

            dateTimePicker4 . Value = DateTime . Now;
        }
        private void textBox14_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox14 );
        }
        private void textBox14_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox14 );
        }
        private void textBox14_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox14.Text != "" && !DateDayRegise.foreOneNum( textBox14 ) )
            {
                this.textBox14.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多一位,如999.9,请重新输入" );
            }
        }
        private void textBox15_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox15 );
        }
        private void textBox15_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox15 );
        }
        private void textBox15_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox15.Text != "" && !DateDayRegise.foreOneNum( textBox15 ) )
            {
                this.textBox15.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多一位,如999.9,请重新输入" );
            }
        }
        private void textBox16_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox16 );
        }
        private void textBox16_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox16 );
        }
        private void textBox16_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox16.Text != "" && !DateDayRegise.foreOneNum( textBox16 ) )
            {
                this.textBox16.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多一位,如999.9,请重新输入" );
            }
        }
        private void textBox17_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox17 );
        }
        private void textBox17_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox17 );
        }
        private void textBox17_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox17.Text != "" && !DateDayRegise.ninSevTb( textBox17 ) )
            {
                this.textBox17.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多七位,如99.9999999,请重新输入" );
            }
        }
        private void textBox18_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox18 );
        }
        private void textBox18_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox18 );
        }
        private void textBox18_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox18.Text != "" && !DateDayRegise.foreTwoNum( textBox18 ) )
            {
                this.textBox18.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多两位,如99.99,请重新输入" );
            }
        }
        private void textBox20_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox20 );
        }
        private void textBox20_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox20 );
        }
        private void textBox20_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox20.Text != "" && !DateDayRegise.threeOneNumTb( textBox20 ) )
            {
                this.textBox20.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多一位,如99.9,请重新输入" );
            }
        }
        private void textBox19_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox23_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox23 );
        }
        private void textBox23_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox23 );
        }
        private void textBox23_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox23.Text != "" && !DateDayRegise.fiveTwoNum( textBox23 ) )
            {
                this.textBox23.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多两位,如99.99,请重新输入" );
            }
        }
        private void tabControl1_Selected ( object sender ,TabControlEventArgs e )
        {
            if ( e.TabPage==tabPageTwo )
            {
                if ( tableTwo != null )
                    return;
                tableTwo = new DataTable( "Datas" );
                tableTwo.Columns.Add( "U1" ,Type.GetType( "System.String" ) );
                tableTwo.Columns.Add( "U2" ,Type.GetType( "System.Decimal" ) );
                tableTwo.Columns.Add( "U3" ,Type.GetType( "System.Decimal" ) );
                tableTwo.Columns.Add( "U4" ,Type.GetType( "System.Decimal" ) );
                tableTwo.Columns.Add( "U5" ,Type.GetType( "System.Decimal" ) );
                tableTwo.Columns.Add( "U6" ,Type.GetType( "System.Decimal" ) );
                tableTwo.Columns.Add( "U7" ,Type.GetType( "System.Decimal" ) );
                tableTwo.Columns.Add( "U8" ,Type.GetType( "System.Decimal" ) );
                tableTwo.Columns.Add( "U9" ,Type.GetType( "System.Decimal" ) );
                tableTwo.Columns.Add( "U10" ,Type.GetType( "System.Decimal" ) );
                tableTwo.Columns.Add( "U11" ,Type.GetType( "System.Decimal" ) );
                tableTwo.Rows.Add( new object[] { "小单夹价格/cm²" ,0.0002 ,0.0002 ,0.0002 ,0.0002 ,0.00012 ,0.00012 ,0.00012 ,0.00004 ,0.00004 ,0.00004 } );
                tableTwo.Rows.Add( new object[] { "大单夹价格/cm²" ,0.00015 ,0.00015 ,0.00015 ,0.00015 ,0.00009 ,0.00009 ,0.00009 ,0.00003 ,0.00003 ,0.00003 } );
                gridControl1.DataSource = tableTwo;
            }
        }
        string component = "", wood = "", specifications = "";
        private void gridView2_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( gridView2.FocusedRowHandle >= 0 && gridView2.FocusedRowHandle <= gridView2.RowCount - 1 )
            {
                model.IDX = string.IsNullOrEmpty( gridView2.GetFocusedRowCellValue( "idx" ).ToString( ) ) == true ? 0 : Convert.ToInt32( gridView2.GetFocusedRowCellValue( "idx" ).ToString( ) );
                aessignMent( );
            }
        }
        void aessignMent ( )
        {
            model = bll.GetModel( model.IDX );
            gridLookUpEdit1.Text = model.IZ008;
            comboBox2.Text = model.IZ009;
            textBox21.Text = model.IZ011.ToString( );
            textBox22.Text = model.IZ012;
            textBox14.Text = model.IZ013.ToString( );
            textBox15.Text = model.IZ014.ToString( );
            textBox16.Text = model.IZ015.ToString( );
            textBox17.Text = model.IZ016.ToString( );
            dateTimePicker5.Value = model.IZ017;
            dateTimePicker6.Value = model.IZ018;
            textBox18.Text = model.IZ019.ToString( );
            textBox23.Text = model.IZ020.ToString( );
            textBox20.Text = model.IZ021.ToString( );
            textBox19.Text = model.IZ022.ToString( );
            component = gridLookUpEdit1.Text;
            textBox24 . Text = model . IZ010;
            wood = comboBox2.Text;
            specifications = textBox24.Text;
        }
        private void textBox1_TextChanged ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( textBox1 . Text ) )
                return;
            DataTable table = bll . getTable ( textBox1 . Text );
            gridLookUpEdit1 . Properties . DataSource = table;
            gridLookUpEdit1 . Properties . DisplayMember = "GS07";
            gridLookUpEdit1 . Properties . ValueMember = "GS07";
        }
        private void gridLookUpEdit1_EditValueChanged ( object sender ,EventArgs e )
        {
            DataRow row = View . GetFocusedDataRow ( );
            if ( row == null )
                return;
            textBox24 . Text = row [ "GS08" ] . ToString ( );
        }
        #endregion

        #region Table
        DataRow row;
        void variable ( )
        {
            model.IZ005 = string.IsNullOrEmpty( textBox5.Text ) == true ? 0 : Convert.ToInt64( textBox5.Text );
            model.IZ008 = gridLookUpEdit1.Text;
            model.IZ009 = comboBox2.Text;
            model.IZ010 = textBox24.Text;
            model.IZ011 = string.IsNullOrEmpty( textBox21.Text ) == true ? 0 : Convert.ToInt32( textBox21.Text );
            model.IZ012 = textBox22.Text;
            model.IZ013 = string.IsNullOrEmpty( textBox14.Text ) == true ? 0 : Convert.ToDecimal( textBox14.Text );
            model.IZ014 = string.IsNullOrEmpty( textBox15.Text ) == true ? 0 : Convert.ToDecimal( textBox15.Text );
            model.IZ015 = string.IsNullOrEmpty( textBox16.Text ) == true ? 0 : Convert.ToDecimal( textBox16.Text );
            model.IZ016 = string.IsNullOrEmpty( textBox17.Text ) == true ? 0 : Convert.ToDecimal( textBox17.Text );
            model.IZ017 = dateTimePicker5.Value;
            model.IZ018 = dateTimePicker6.Value;
            model.IZ019 = string.IsNullOrEmpty( textBox18.Text ) == true ? 0 : Convert.ToDecimal( textBox18.Text );
            model.IZ020 = string.IsNullOrEmpty( textBox23.Text ) == true ? 0 : Convert.ToDecimal( textBox23.Text );
            model.IZ021 = string.IsNullOrEmpty( textBox20.Text ) == true ? 0 : Convert.ToDecimal( textBox20.Text );
            model.IZ022 = string.IsNullOrEmpty( textBox19.Text ) == true ? 0 : Convert.ToInt32( textBox19.Text );
        }
        void rows ( )
        {
            row["IZ005"] = model.IZ005;
            row["IZ008"] = model.IZ008;
            row["IZ009"] = model.IZ009;
            row["IZ010"] = model.IZ010;
            row["IZ011"] = model.IZ011;
            row["IZ012"] = model.IZ012;
            row["IZ013"] = model.IZ013;
            row["IZ014"] = model.IZ014;
            row["IZ015"] = model.IZ015;
            row["IZ016"] = model.IZ016;
            row["IZ017"] = model.IZ017;
            row["IZ018"] = model.IZ018;
            row["IZ019"] = model.IZ019;
            row["IZ020"] = model.IZ020;
            row["IZ021"] = model.IZ021;
            row["IZ022"] = model.IZ022;
        }
        //Build
        private void button8_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox1.Text ) )
            {
                MessageBox.Show( "流水号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( gridLookUpEdit1.Text ) )
            {
                MessageBox.Show( "部件名称不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox24.Text ) )
            {
                MessageBox.Show( "规格不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox2.Text ) )
            {
                MessageBox.Show( "材种不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( textBox6 . Text ) )
            {
                MessageBox . Show ( "开合同人不可为空" );
                return;
            }
            if ( dateTimePicker5.Value < MulaolaoBll . Drity . GetDt ( ).AddDays( 5 ) )
            {
                MessageBox.Show( "约定工期必须在当天的基础上延迟5天" );
                return;
            }
            variable( );
            result = bll.ExistsOf( model );
            if ( result == true && Logins . number != "MLL-0001" )
            {
                MessageBox . Show ( "此单为超补,请联系总经理" );
                return;
            }
            if ( label45.Visible == true )
                stateOfOdd = "维护新建";
            else
            {
                if ( sign == "1" )
                    stateOfOdd = "新增新建";
                else
                    stateOfOdd = "更改新建";
            }

            result = bll.Insert( model ,"R_505" ,"断料、平刨、压刨、夹料、叠料、清理承揽加工合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"新建" ,stateOfOdd );
            if ( result == true )
            {
                MessageBox.Show( "录入数据成功" );
                //if ( tableQuery != null )
                //{
                //    row = tableQuery.NewRow( );
                //    row["idx"] = model.IDX;
                //    rows( );
                //    tableQuery.Rows.Add( row );
                //    gridView2.FocusedRowHandle = gridView2.RowCount - 1;
                //}
                //else
                //{
                strWhere = "1=1";
                strWhere = strWhere + " AND IZ001='" + model.IZ001 + "'";
                button11_Click( null ,null );
                //}
            }
            else
                MessageBox.Show( "录入数据失败" );
        }
        //Edit
        void edit ( )
        {
            if ( label45.Visible == true )
                stateOfOdd = "维护编辑";
            else
            {
                if ( sign == "1" )
                    stateOfOdd = "新增编辑";
                else
                    stateOfOdd = "更改编辑";
            }
            result = bll.Update( model ,"R_505" ,"断料、平刨、压刨、夹料、叠料、清理承揽加工合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"编辑" ,stateOfOdd );
            if ( result == true )
            {
                MessageBox.Show( "编辑数据成功" );
                row = tableQuery.Rows[gridView2.FocusedRowHandle];
                row.BeginEdit( );
                rows( );
                row.EndEdit( );
            }
            else
                MessageBox.Show( "编辑数据失败" );
        }
        private void button9_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox1.Text ) )
            {
                MessageBox.Show( "流水号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( gridLookUpEdit1.Text ) )
            {
                MessageBox.Show( "部件名称不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox24.Text ) )
            {
                MessageBox.Show( "规格不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox2.Text ) )
            {
                MessageBox.Show( "材种不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( textBox6 . Text ) )
            {
                MessageBox . Show ( "开合同人不可为空" );
                return;
            }
            if ( dateTimePicker5.Value < MulaolaoBll . Drity . GetDt ( ).AddDays( 5 ) )
            {
                MessageBox.Show( "约定工期必须在当天的基础上延迟5天" );
                return;
            }

            variable( );
            if ( component == model.IZ008 && wood == model.IZ009 && specifications == model.IZ010 )
                edit( );
            else
            {
                result = bll.ExistsOf( model );
                if ( result == true )
                {
                    if ( Logins.number != "MLL-0001" )
                    {
                        MessageBox.Show( "此单为超补,请联系总经理" );
                        return;
                    }
                }

                result = bll.ExistsEdit( model );
                if ( result == true )
                {
                    if ( model.IZ007.Length > 8 && model.IZ007.Substring( 0 ,8 ) == "MLL-0001" )
                        edit( );
                    else
                        MessageBox.Show( "此记录已经存在,需要总经理处理" );
                }
                else
                    edit( );
            }
        }
        //Delete
        private void button10_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                return;
            if ( label45.Visible == true )
                stateOfOdd = "维护删除";
            else
            {
                if ( sign == "1" )
                    stateOfOdd = "新增删除";
                else
                    stateOfOdd = "更改删除";
            }
            result = bll.Delete( model.IDX ,"R_505" ,"断料、平刨、压刨、夹料、叠料、清理承揽加工合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"删除" ,stateOfOdd ,model.IZ001 );
            if ( result == true )
            {
                MessageBox.Show( "删除数据成功" );
                //tableQuery.Rows.RemoveAt( gridView2.FocusedRowHandle );
                strWhere = "";
                strWhere = "1=1" + "AND IZ001='" + model . IZ001 + "'";
                button11_Click ( null , null );
            }
            else
                MessageBox.Show( "删除数据失败" );
        }
        //Refresh
        private void button11_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( strWhere ) )
                strWhere = "1=1";
            tableQuery = bll.GetDataTable( strWhere );
            gridControl2.DataSource = tableQuery;
        }
        #endregion

        #region Main
        protected override void add ( )
        {
            base.add( );

            Ergodic.FormEvery( this );
            gridControl1.DataSource = null;
            gridControl2.DataSource = null;
            Ergodic.SpliEnableTrue( spList );
            sign = "1";
            textBox13.Enabled = false;
            label46.Visible = label45.Visible = false;
            dateTimePicker6.Enabled = false;
            Ergodic.SpliClear( spList );
            
            model.IZ001 = oddNumbers.purchaseContract( "SELECT MAX(AJ016) AJ016 FROM R_PQAJ" ,"AJ016" ,"R_505-" );

            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled =toolLibrary.Enabled=toolStorage.Enabled= false;
            toolSave.Enabled = toolCancel.Enabled = true;
        }
        void dele ( )
        {
            if ( label45.Visible == true )
                stateOfOdd = "维护删除";
            else
            {
                if ( sign == "1" )
                    stateOfOdd = "新增删除";
                else
                    stateOfOdd = "更改删除";
            }

            result = bll.DeleteAll( model.IZ001 ,"R_505" ,"断料、平刨、压刨、夹料、叠料、清理承揽加工合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"删除" ,stateOfOdd );
            if ( result == true )
            {
                MessageBox.Show( "删除成功" );
                toolSelect.Enabled = toolAdd.Enabled = true;
                toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;

                Ergodic.FormEvery( this );
                gridControl1.DataSource = null;
                gridControl2.DataSource = null;
                Ergodic.SpliEnableFalse( spList );
                sign = "";
                weihu = "";
                label46.Visible = label45.Visible = false;
                textBox13.Enabled = false;
                Ergodic.SpliClear( spList );
            }
            else
                MessageBox.Show( "删除失败" );
        }
        protected override void delete ( )
        {
            base.delete( );

            //result = bll.GetDataTableReviews( "R_505" ,model.IZ001 );
            if ( label45.Visible == true )
            {
                if ( Logins.number == "MLL-0001" )
                    dele( );
                else
                    MessageBox.Show( "此单已经执行,需要总经理删除" );
            }
            else
            {
                dele( );
            }
        }
        protected override void update ( )
        {
            base.update( );

            //result = bll.GetDataTableReviews( "R_505" ,model.IZ001 );
            if ( label45.Visible == true )
                MessageBox.Show( "此单已经执行,需要维护" );
            else
            {
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled =toolLibrary.Enabled=toolStorage.Enabled= false;
                toolSave.Enabled = toolCancel.Enabled = true;
                sign = "2";
                Ergodic.SpliEnableTrue( spList );
                textBox13.Enabled = false;
                label46.Visible = label45.Visible = false;
                dateTimePicker6.Enabled = false;
            }
        }
        void saveState ( )
        {
            Ergodic.SpliEnableFalse( spList );
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled =toolcopy.Enabled=toolLibrary.Enabled=toolStorage.Enabled= toolcopy.Enabled = true;
             toolSave.Enabled = toolCancel.Enabled =  false;
            label46.Visible = false;
            textBox13.Enabled = false;
            sign = "";
            weihu = "";
        }
        void variableMain ( )
        {
            model.IZ002 = textBox1.Text;
            model.IZ003 = textBox2.Text;
            model.IZ004 = textBox3.Text;
            model.IZ005 = string.IsNullOrEmpty( textBox5.Text ) == true ? 0 : Convert.ToInt64( textBox5.Text );
            model.IZ006 = textBox6.Text;
            model.IZ007 = textBox7.Text;
            model.IZ023 = textBox8.Text;
            model.IZ024 = textBox9.Text;
            model.IZ025 = dateTimePicker1.Value;
            model.IZ026 = textBox10.Text;
            model.IZ027 = dateTimePicker2.Value;
            model.IZ028 = textBox11.Text;
            model.IZ029 = dateTimePicker3.Value;
            model.IZ030 = textBox12.Text;
            model.IZ031 = dateTimePicker4.Value;
            model.IZ032 = textBox13.Text;
            model.IZ034 = textBox4.Text;
            model.IZ035 = comboBox4.Text;
        }
        void mainSave ( )
        {
            result = bll.UpdateMain( model ,"R_505" ,"断料、平刨、压刨、夹料、叠料、清理承揽加工合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"保存" ,stateOfOdd );
            if ( result == true )
            {
                MessageBox.Show( "保存数据成功" );
                if ( weihu == "1" )
                {
                    try
                    {
                        SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfCopy( "R_PQIZC" ,"R_PQIZ" ,"IZ001" ,model.IZ001 ) );
                        WriteOfReceivablesTo( );
                    }
                    catch { }
                }
                saveState( );
            }
            else
                MessageBox.Show( "保存数据失败" );
        }
        protected override void save ( )
        {
            base.save( );

            if ( string.IsNullOrEmpty( textBox6.Text ) )
            {
                MessageBox.Show( "开合同人不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox4.Text ) )
            {
                MessageBox.Show( "承揽人不可为空" );
                return;
            }
            variableMain( );

            DataTable da = bll.GetDataTableMain( model.IZ001 );
            if ( weihu == "1" )
            {
                if ( string.IsNullOrEmpty( textBox13.Text ) )
                {
                    MessageBox.Show( "请填写维护意见" );
                    return;
                }
                if ( da == null )
                    return;
                stateOfOdd = "维护保存";
                model.IZ033 = da.Rows[0]["IZ033"].ToString( ) + "[" + Logins.username + MulaolaoBll . Drity . GetDt ( ).ToString( "yyyyMMdd" ) + "]";
                mainSave( );
            }
            else
            {
                if ( sign == "1" )
                    stateOfOdd = "新增保存";
                else
                    stateOfOdd = "更改保存";
                model.IZ033 = "";
                if ( da.Rows.Count > 0 )
                {
                    if ( copy == "1" )
                    {
                        stateOfOdd = "复制保存";
                        DataTable de = bll.GetDataTableNoMain( model.IZ001 ,model.IZ002 );
                        if ( de.Rows.Count < 1 )
                            mainSave( );
                        else
                        {
                            int proNum = 0;

                            for ( int i = 0 ; i < gridView2.RowCount ; i++ )
                            {
                                proNum = string . IsNullOrEmpty ( gridView2 . GetDataRow ( i ) [ "IZ005" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( gridView2 . GetDataRow ( i ) [ "IZ005" ] );
                                if ( proNum != model . IZ005 )
                                {
                                    MessageBox . Show ( "产品数量不一致,请核实" );
                                    break;
                                }

                                if ( de.Select( "IZ008='" + gridView2.GetDataRow( i )["IZ008"].ToString( ) + "' AND IZ009='" + gridView2.GetDataRow( i )["IZ009"].ToString( ) + "' AND IZ010='" + gridView2.GetDataRow( i )["IZ010"].ToString( ) + "'" ).Length > 0 )
                                {
                                    if ( Logins . number . Equals ( "MLL-0001" ) )
                                    {
                                        mainSave ( );
                                        break;
                                    }
                                    else
                                    {
                                        MessageBox . Show ( "此单为超补,需要总经理处理" );
                                        break;
                                    }
                                }
                                else
                                {
                                    mainSave( );
                                    break;
                                }
                            }
                        }
                    }
                    else
                        mainSave( );
                }
                else
                    saveState( );
            }
        }
        protected override void revirw ( )
        {
            base.revirw( );

            if ( string.IsNullOrEmpty( textBox11.Text ) )
                result = true;
            else
                result = false;
            Reviews( "IZ001" ,model.IZ001 ,"R_PQIZ" ,this ,"" ,"R_505" ,false ,result,null/*,"" ,"" ,"" ,"" ,"" ,"" ,"","R_195"*/ );
            SpecialPowers sp = new SpecialPowers( );
            result=sp.reviewImple( "R_505" ,model.IZ001 );
            if ( result == true )
            {
                label45.Visible = true;
                try
                {
                    SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfCopy( "R_PQIZC" ,"R_PQIZ" ,"IZ001" ,model.IZ001 ) );
                    WriteOfReceivablesTo( );
                }
                catch { }
            }   
            else
                label45.Visible = false;
        }
        void WriteOfReceivablesTo ( )
        {
            DataTable receiva;
            MulaolaoLibrary.ProductCostSummaryLibrary modelAm = new MulaolaoLibrary.ProductCostSummaryLibrary( );
            receiva = bll.GetDataTableOfReceviable( model.IZ001 );
            if ( receiva != null && receiva.Rows.Count > 0 )
            {
                modelAm.AM002 = receiva.Rows[0]["IZ002"].ToString( );
                
                modelAm.AM074 = 0;
                modelAm.AM074 = string.IsNullOrEmpty( receiva.Rows[0]["U0"].ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Rows[0]["U0"].ToString( ) );
                bll.UpdateOfReceivable( modelAm ,model.IZ001 );
            }
        }
        protected override void print ( )
        {
            base.print( );

            if ( label45.Visible == true )
            {
                MulaolaoBll . ContractAddPrintTime . addTimeToContract ( "R_PQIZ" ,"IZ036" ,model . IZ001 ,"IZ001" );

                createPrint( );
                file = "";
                file= System.Windows.Forms.Application.StartupPath;
                report.Load( file + "\\R_505.frx" );
                report.RegisterData( RDataSet );
                report.Show( );
            }
            else
                MessageBox.Show( "非执行单据不允许打印" );
        }
        protected override void export ( )
        {
            base.export( );

            createPrint( );
            file = "";
            file = System.Windows.Forms.Application.StartupPath;
            report.Load( file + "\\R_505.frx" );
            report.RegisterData( RDataSet );
            report.Prepare( );
            XMLExport exprots = new XMLExport( );
            exprots.Export( report );
        }
        protected override void cancel ( )
        {
            base.cancel( );

            if ( sign == "1" && weihu != "1" )
            {
                Ergodic.FormEvery( this );
                gridControl1.DataSource = null;
                gridControl2.DataSource = null;
                toolSelect.Enabled = toolAdd.Enabled = true;
                toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled = toolPrint.Enabled = toolExport.Enabled =toolcopy.Enabled=toolLibrary.Enabled=toolStorage.Enabled= false;
                sign = "";
                weihu = "";
                copy = "";
                textBox13.Enabled = false;
                label45.Visible = label46.Visible = false;
                tableQuery = null;
                Ergodic.SpliClear( spList );
                try
                {
                    result = bll.DeleteAll( model.IZ001 ,"R_505" ,"断料、平刨、压刨、夹料、叠料、清理承揽加工合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"取消" ,"新增取消" );
                }
                catch { }
            }
            else
            {
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolMaintain.Enabled =toolcopy.Enabled=toolLibrary.Enabled=toolStorage.Enabled= true;
                toolSave.Enabled = toolCancel.Enabled = false;
            }
            Ergodic.SpliEnableFalse( spList );
        }
        protected override void maintain ( )
        {
            base.maintain( );

            //result = bll.GetDataTableReviews( "R_505" ,model.IZ001 );
            if ( label45.Visible == true )
            {
                Ergodic.SpliEnableTrue( spList );
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled =toolLibrary.Enabled=toolStorage.Enabled= false;
                toolSave.Enabled = toolCancel.Enabled = true;
                dateTimePicker6.Enabled = false;
                textBox13.Enabled = true;
                weihu = "1";
            }
            else
                MessageBox.Show( "此单据状态为非执行,请更改" );
        }
        protected override void copys ( )
        {
            base.copys( );

            if ( label45.Visible == true )
                stateOfOdd = "维护复制";
            else
            {
                if ( sign == "1" )
                    stateOfOdd = "新增复制";
                else
                    stateOfOdd = "更改复制";
            }

            result = bll.Copy( model.IZ001 ,"R_505" ,"断料、平刨、压刨、夹料、叠料、清理承揽加工合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"复制" ,stateOfOdd );
            if ( result == false )
            {
                MessageBox.Show( "复制失败，请重试" );
            }
            else
            {
                stateOfOdd = "复制更改单号";
                model.IZ001 = oddNumbers.purchaseContract( "SELECT MAX(AJ016) AJ016 FROM R_PQAJ" ,"AJ016" ,"R_505-" );
                result = bll.CopyUpdate( model.IZ001 ,"R_505" ,"断料、平刨、压刨、夹料、叠料、清理承揽加工合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"复制" ,stateOfOdd );
                if ( result == false )
                {
                    MessageBox.Show( "复制失败,请重试" );
                    bll.deleteCopy( );
                }
                else
                {
                    MessageBox.Show( "成功复制此表" );
                    Ergodic.FormEvery( this );
                    gridControl2.DataSource = null;
                    Ergodic.SpliEnableTrue( spList );
                    toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolcopy.Enabled =toolLibrary.Enabled=toolStorage.Enabled= false;
                    toolSave.Enabled = toolCancel.Enabled = true;
                    dateTimePicker1.Value = dateTimePicker2.Value = dateTimePicker3.Value = dateTimePicker4.Value = dateTimePicker5.Value = dateTimePicker6.Value = MulaolaoBll . Drity . GetDt ( );
                    textBox13.Enabled = false;
                    dateTimePicker6.Enabled = false;
                    sign = "1";
                    weihu = "";
                    copy = "1";
                    label45.Visible = false;
                    label46.Visible = true;
                    queryContent( );
                }
            }
        }
        #endregion

        #region Query
        SelectAll.DuanLiaoNumSelect duan = new SelectAll.DuanLiaoNumSelect( );
        private void button1_Click ( object sender ,EventArgs e )
        {
            duan.StartPosition = FormStartPosition.CenterScreen;
            duan.PassDataBetweenForm += new SelectAll.DuanLiaoNumSelect.PassDataBetweenFormHandler( duan_PassDataBetweenForm );
            duan.ShowDialog( );
        }
        private void duan_PassDataBetweenForm (object sender,PassDataWinFormEventArgs e)
        {
            textBox1.Text = e.ConOne;
            model.IZ002 = e.ConOne;
            textBox2.Text = e.ConTre;
            model.IZ003 = e.ConTre;
            textBox4.Text = e.ConTwo;
            model.IZ034 = e.ConTwo;
            textBox3.Text = e.ConFor;
            model.IZ004 = e.ConFor;
            textBox5.Text = e.ConFiv;
            model.IZ005 = string.IsNullOrEmpty( e.ConFiv ) == true ? 0 : Convert.ToInt64( e.ConFiv );
        }
        SelectAll.DuanLiaoAll query = new SelectAll.DuanLiaoAll( );
        void autoQuery ( )
        {
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled =toolLibrary.Enabled=toolStorage.Enabled= true;
            toolSave.Enabled = toolCancel.Enabled = false;

            Ergodic.SpliEnableFalse( spList );
            sign = "2";
            queryContent( );
        }
        void queryContent ( )
        {
            if ( model.IZ001 != null )
            {
                model = bll.GetModel( model.IZ001 );
                if ( model == null )
                    return;
                textBox1.Text = model.IZ002;
                textBox2.Text = model.IZ003;
                textBox3.Text = model.IZ004;
                textBox4.Text = model.IZ034;
                textBox5.Text = model.IZ005.ToString( );
                textBox6.Text = model.IZ006;
                textBox7.Text = model.IZ007;
                textBox8.Text = model.IZ023;
                textBox9.Text = model.IZ024;
                comboBox4.Text = model.IZ035;
                if ( model.IZ025 > DateTime.MinValue && model.IZ025 < DateTime.MaxValue )
                    dateTimePicker1.Value = model.IZ025;
                textBox10.Text = model.IZ026;
                if ( model.IZ027 > DateTime.MinValue && model.IZ027 < DateTime.MaxValue )
                    dateTimePicker2.Value = model.IZ027;
                textBox11.Text = model.IZ028;
                if ( model.IZ029 > DateTime.MinValue && model.IZ029 < DateTime.MaxValue )
                    dateTimePicker3.Value = model.IZ029;
                textBox12.Text = model.IZ030;
                if ( model.IZ031 > DateTime.MinValue && model.IZ031 < DateTime.MaxValue )
                    dateTimePicker4.Value = model.IZ031;
                textBox13.Text = model.IZ032;

                strWhere = "1=1";
                strWhere = strWhere + " AND IZ001='" + model.IZ001 + "'";
                button11_Click( null ,null );
            }
        }
        protected override void select ( )
        {
            base.select( );
            
            model = new MulaolaoLibrary.DuanLiaoLibrary( );
            query.StartPosition = FormStartPosition.CenterScreen;
            query.PassDataBetweenForm += new SelectAll.DuanLiaoAll.PassDataBetweenFormHandler( query_PassDataBetweenForm );
            query.ShowDialog( );

            if ( model.IZ001 != null && model.IZ001!="")
                autoQuery( );
            else
                MessageBox.Show( "您没有选择任何内容" );
        }
        private void query_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            model.IZ001 = e.ConOne;
            if ( e.ConTwo == "执行" )
                label45.Visible = true;
            else
                label45.Visible = false;
        }
        #endregion

    }
}

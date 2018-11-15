using Mulaolao.Class;
using Mulaolao.Other;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using FastReport;
using FastReport.Export.Xml;
using Mulaolao.Bom;
using StudentMgr;

namespace Mulaolao.Contract
{
    public partial class R_FrmGunQiContrract : FormChild
    {
        public R_FrmGunQiContrract ( )
        {
            InitializeComponent( );

            Logins . tableNum = "R_344";
            Logins . tableName = this . Text;
            
            GridViewMoHuSelect . SetFilter ( bandedGridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { bandedGridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        MulaolaoLibrary.GunQiContractLibrary model = new MulaolaoLibrary.GunQiContractLibrary( );
        MulaolaoBll.Bll.GunQiContractBll bll = new MulaolaoBll.Bll.GunQiContractBll( );
        List<SplitContainer> spList = new List<SplitContainer>( );
        DataTable tableQuery, de, dl, dk, libraryTable;
        string strWhere = "1=1", sign = "", weihu = "", copy = "", file = "", printSign = "", stateOdOdd = "", conOne = "";
        bool result = false;
        DataSet RDataSet;
        Report report = new Report( );List<TabPage> pageList = new List<TabPage>( ); List<string> speList = new List<string>( );
        HeadmanWagesCalculation hw = new HeadmanWagesCalculation( ); Factory fc = new Factory( );
        
        private void R_FrmGunQiContrract_Load ( object sender ,EventArgs e )
        {
            Power( this );
            spList.Clear( );
            spList.AddRange( new SplitContainer[] { splitContainer1 ,splitContainer2 } );
            pageList.Clear( );
            pageList.AddRange( new TabPage[] { tabPageFor ,tabPageOne ,tabPageTwo ,tabPageTre } );
            gridControl1.DataSource = null;
            Ergodic.SpliClear( spList );
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableClear( pageList );
            Ergodic.TablePageEnableFalse( pageList );
            label45.Visible = label46.Visible = false;
            textBox9.Text = "";
            textBox9.Enabled = false;
            comboBox2.Items.Clear( );
            comboBox2.Items.AddRange( new string[] { "厂内" ,"厂外" } );

            dk = bll.GetDataTableBusi( );
            lookUpEdit2.Properties.DataSource = dk;
            lookUpEdit2.Properties.DisplayMember = "DBA002";
            lookUpEdit2.Properties.ValueMember = "DBA028";

            comboBox6.DataSource = bll.GetDataTableOfYf( );
            comboBox6.DisplayMember = "MZ014";

            if ( Logins.number == "MLL-0001" )
                checkBox16.Visible = true;
            else
                checkBox16.Visible = false;
        }
        
        private void R_FrmGunQiContrract_Shown ( object sender ,EventArgs e )
        {
            model.MZ001 = Merges.oddNum;
            if ( model.MZ001 != null && model.MZ001 != "" )
                autoQuery( );
            Merges.oddNum = "";
        }
        
        #region Print
        void CreatePrint ( )
        {
            RDataSet = new DataSet( );
            DataTable print = bll.GetDataTablePrint( model.MZ001 );
            DataTable prints = bll.GetDataTableExport( model.MZ001 );
            print.TableName = "R_PQMZ";
            prints.TableName = "R_PQMZS";
            RDataSet.Tables.AddRange( new DataTable[] { print ,prints } );
        }
        void CreateExport ( )
        {
            RDataSet = new DataSet( );
            DataTable pri = bll.GetDataTablePri( model.MZ001 );
            DataTable exp = bll.GetDataTableExp( model.MZ001 );
            pri.TableName = "R_PQMZ";
            exp.TableName = "R_PQMZS";
            RDataSet.Tables.AddRange( new DataTable[] { pri ,exp } );
        }
        void CreateOther ( )
        {
            RDataSet = new DataSet( );
            DataTable print = bll.GetDataTableOther( model.MZ001 );
            DataTable prints = bll.GetDataTableOtherTwo( model.MZ001 );
            DataTable printes = bll.GetDataTableTre( model.MZ001 );
            print.TableName = "R_PQMZ";
            prints.TableName = "R_PQMZS";
            printes.TableName = "R_PQMZES";
            RDataSet.Tables.AddRange( new DataTable[] { print ,prints ,printes } );
        }
        #endregion

        #region Event
        private void textBox17_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
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
            if ( string.IsNullOrEmpty( textBox18.Text ) && !DateDayRegise.sevenFourTb( textBox18 ) )
            {
                textBox18.Text = "";
                MessageBox.Show( "只允许输入整数部分最多四位,小数部分最多三位,如9999.999,请重新输入" );
            }
        }
        private void textBox55_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise . textChangeTb ( textBox55 );
        }
        private void textBox55_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise . fractionTb ( e ,textBox55 );
        }
        private void textBox55_LostFocus ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( textBox55 . Text ) && !DateDayRegise . sevenFourTb ( textBox55 ) )
            {
                textBox55 . Text = "";
                MessageBox . Show ( "只允许输入整数部分最多四位,小数部分最多三位,如9999.999,请重新输入" );
            }
        }
        private void button7_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox12.Text ) )
                textBox12.Text = Logins.username;
            else if ( textBox12.Text != "" && textBox12.Text == Logins.username )
                textBox12.Text = "";
        }
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox5.Text ) )
                textBox5.Text = Logins.username;
            else if ( textBox5.Text != "" && textBox5.Text == Logins.username )
                textBox5.Text = "";

            dateTimePicker3 . Value = DateTime . Now;
        }
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox6.Text ) )
                textBox6.Text = Logins.username;
            else if ( textBox6.Text != "" && textBox6.Text == Logins.username )
                textBox6.Text = "";

            dateTimePicker4 . Value = DateTime . Now;
        }
        private void button4_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox7.Text ) )
                textBox7.Text = Logins.username;
            else if ( textBox7.Text != "" && textBox7.Text == Logins.username )
                textBox7.Text = "";
        }
        private void comboBox1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        string partName = "", product = "", wages = "", colorName = "", brand = "";
        private void bandedGridView1_Click ( object sender ,EventArgs e )
        {
            if ( bandedGridView1.FocusedRowHandle >= 0 && bandedGridView1.FocusedRowHandle <= bandedGridView1.RowCount - 1 )
            {
                //model.IDX = string.IsNullOrEmpty( bandedGridView1.GetFocusedRowCellValue( "idx" ).ToString( ) ) == true ? 0 : Convert.ToInt32( bandedGridView1.GetFocusedRowCellValue( "idx" ).ToString( ) );
                model.MZ125 = bandedGridView1.GetFocusedRowCellValue( "MZ125" ).ToString( );
                assignMent( );
            }
        }
        void assignMent ( )
        {
            model = bll.GetModel( model.MZ125,model.MZ001 );
            if ( model == null )
                return;
            lookUpEdit1.Text = model.MZ016;
            textBox13.Text = model.MZ017;
            comboBox3.Text = model.MZ018;         
            textBox16.Text = model.MZ020.ToString( );
            textBox17.Text = model.MZ021.ToString( );
            textBox18.Text = model.MZ022.ToString( );
            textBox21.Text = model.MZ032;
            textBox19.Text = model.MZ023;
            comboBox1.Text = model.MZ024.ToString( );
            textBox23.Text = model.MZ025.ToString( );
            textBox20.Text = model.MZ026.ToString( );
            textBox32.Text = model.MZ027.ToString( );
            textBox22.Text = model.MZ028.ToString( );
            textBox34.Text = model.MZ106;
            comboBox2.Text = model.MZ107;
            textBox51.Text = model.MZ118.ToString( );
            textBox50.Text = model.MZ119.ToString( );
            textBox49.Text = model.MZ120.ToString( );
            comboBox4.Text = model.MZ019;
            comboBox7.Text = model.MZ124;
            textBox55 . Text = model . MZ126 . ToString ( );
            partName = lookUpEdit1.Text;
            product = comboBox3.Text;
            wages = comboBox4.Text;
            colorName = textBox19.Text;
            brand = textBox21.Text;
            textBox8.Text= hw.SomeOfCaculation( textBox18.Text ,textBox10.Text ,textBox20.Text ,comboBox1.Text ,textBox23.Text );
        }
        private void comboBox2_TextChanged ( object sender ,EventArgs e )
        {
            if ( comboBox2.Text == "厂内" )
            {
                DataTable de = bll.GetDataTableStock( comboBox4.Text ,textBox19.Text ,textBox21.Text );
                if ( de != null && de.Rows.Count > 0 )
                    textBox53.Text = de.Rows[0]["AC10"].ToString( );
                else
                    textBox53.Text = "0";
            }
        }
        private void textBox1_TextChanged ( object sender ,EventArgs e )
        {
            de = bll.GetDataTableOfPart( textBox1.Text );
            lookUpEdit1.Properties.DataSource = de.DefaultView.ToTable( true ,"LZ015" );
            lookUpEdit1.Properties.DisplayMember = "LZ015";
            comboBox3.DataSource = de.DefaultView.ToTable( true ,"LZ017" );
            comboBox3.DisplayMember = "LZ017";
            dl= bll.GetDataTable( textBox1.Text );
            comboBox7.DataSource = dl.DefaultView.ToTable( true ,"MZ124" );
            comboBox7.DisplayMember = "MZ124";
            comboBox1.DataSource = dl.DefaultView.ToTable( true ,"MZ024" );
            comboBox1.DisplayMember = "MZ024";
        }
        private void lookUpEdit1_EditValueChanged ( object sender ,EventArgs e )
        {
            if ( lookUpEdit1.EditValue != null )
                comboBox3.Text = de.Select( "LZ015='" + lookUpEdit1.Text + "'" )[0]["LZ017"].ToString( );
        }
        private void R_FrmGunQiContrract_FormClosing ( object sender ,FormClosingEventArgs e )
        {
            if ( toolSave.Enabled )
                cancel( );
        }
        private void lookUpEdit2_EditValueChanged ( object sender ,EventArgs e )
        {
            if ( lookUpEdit2.EditValue != null )
            {
                textBox48.Text = lookUpEdit2.EditValue.ToString( );
                model.MZ117 = dk.Select( "DBA002='" + lookUpEdit2.Text.ToString( ) + "'" )[0]["DBA001"].ToString( );
            }
        }
        private void textBox51_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox50_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox49_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void radioButton10_CheckedChanged ( object sender ,EventArgs e )
        {
            if ( radioButton10.Checked )
            {
                if ( comboBox2.Text != "厂内" )
                    return;
                DataTable de = bll.GetDataTableStock( comboBox4.Text ,textBox19.Text ,textBox21.Text );
                if ( de != null && de.Rows.Count > 0 )
                    textBox53.Text = de.Rows[0]["AC10"].ToString( );
                else
                    textBox53.Text = "0";

                textBox52.Text = hw.SomeOfCaculation( textBox18.Text ,textBox10.Text ,textBox20.Text ,comboBox1.Text ,textBox23.Text );
                textBox54.Text = "0";
            }
        }
        private void radioButton11_CheckedChanged ( object sender ,EventArgs e )
        {
            if ( radioButton11.Checked )
            {
                if ( comboBox2.Text != "厂内" )
                    return;
                textBox54.Text = hw.SomeOfCaculation( textBox18.Text ,textBox10.Text ,textBox20.Text ,comboBox1.Text ,textBox23.Text );
                textBox52.Text = "0";
            }
        }
        private void textBox19_TextChanged ( object sender ,EventArgs e )
        {
            changeOf( );
        }
        private void textBox21_TextChanged ( object sender ,EventArgs e )
        {
            changeOf( );
        }
        void changeOf ( )
        {
            DataTable dr = bll.GetDataTableOfPqac( textBox19.Text ,textBox21.Text );
            if ( dr != null && dr.Rows.Count > 0 )
                dr.Rows.Add( "" );
            comboBox4.DataSource = dr;
            comboBox4.DisplayMember = "AC05";
        }
        #endregion
        
        #region Main
        protected override void add ( )
        {
            base.add( );
         
            Ergodic.SpliClear( spList );
            Ergodic.SpliEnableTrue( spList );
            Ergodic.TablePageEnableClear( pageList );
            Ergodic.TablePageEnableTrue( pageList );
            sign = "1";
            textBox10.Enabled = false;
            dateTimePicker1.Enabled = dateTimePicker2.Enabled = false;
            label45.Visible = label46.Visible = false;
            model.MZ001 = oddNumbers.purchaseContract( "SELECT MAX(AJ019) AJ019 FROM R_PQAJ" ,"AJ019" ,"R_344-" );
            gridControl1.DataSource = null;
            tableQuery = null;
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled =toolLibrary.Enabled=toolStorage.Enabled= false;
            toolSave.Enabled = toolCancel.Enabled = true;
        }
        protected override void delete ( )
        {
            base.delete( );

            if ( label45.Visible == true )
            {
                if ( Logins.number == "MLL-0001" )
                    dele( );
                else
                    MessageBox.Show( "此单已经执行,需要总经理删除" );
            }
            else
                dele( );
        }
        void dele ( )
        {
            if ( label45.Visible == true )
                stateOdOdd = "维护删除";
            else
            {
                if ( sign == "1" )
                    stateOdOdd = "新增删除";
                else
                    stateOdOdd = "更改删除";
            }
            result = bll.DeleteAll( model.MZ001 ,"R_344" ,"滚漆承揽加工成本合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"删除" ,stateOdOdd );
            if ( result == true )
            {
                MessageBox.Show( "成功删除数据" );
                toolSelect.Enabled = toolAdd.Enabled = true;
                toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;

                gridControl1.DataSource = null;
                Ergodic.SpliClear( spList );
                Ergodic.SpliEnableFalse( spList );
                Ergodic.TablePageEnableClear( pageList );
                Ergodic.TablePageEnableFalse( pageList );
                sign = "";
                label45.Visible = label46.Visible = false;
            }
            else
                MessageBox.Show( "删除数据失败" );
        }
        protected override void update ( )
        {
            base.update( );
            
            if ( label45.Visible == true )
                MessageBox.Show( "此单已经执行,需要维护" );
            else
            {
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
                sign = "2";
                Ergodic.SpliEnableTrue( spList );
                Ergodic.TablePageEnableTrue( pageList );
                textBox10.Enabled = false;
                label45.Visible = label46.Visible = false;
                dateTimePicker1.Enabled = dateTimePicker2.Enabled = false;
            }
        }
        protected override void save ( )
        {
            base.save( );

            variableMain( );
            if ( string.IsNullOrEmpty( textBox1.Text ) )
            {
                MessageBox.Show( "流水号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox12.Text ) )
            {
                MessageBox.Show( "开合同人不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox6.Text ) )
            {
                MessageBox.Show( "乙方不可为空" );
                return;
            }
            
            DataTable de = bll.GetDataTableMain( model.MZ001 );
            if ( weihu == "1" )
            {
                if ( de.Rows.Count > 0 )
                {
                    if ( string.IsNullOrEmpty( textBox9.Text ) )
                    {
                        MessageBox.Show( "请填写维护信息" );
                        return;
                    }
                    if ( bandedGridView1 . GetDataRow ( 0 ) [ "MZ107" ] . ToString ( ) . Equals ( "厂内" ) )
                        MessageBox . Show ( "若有维护使用数量等,请手动出库修改出库数量" );
                    
                    stateOdOdd = "维护保存";
                    model.MZ030 = de.Rows[0]["MZ030"].ToString( ) + "[" + Logins.username + MulaolaoBll . Drity . GetDt ( ).ToString( "yyyyMMdd" ) + "]";
                    mainSave( );
                }
            }
            else
            {
                if ( sign == "1" )
                    stateOdOdd = "新增保存";
                else
                    stateOdOdd = "更改保存";
                model.MZ030 = "";
                if ( de.Rows.Count > 0 )
                {

                    if ( copy == "1" )
                    {
                        if ( MulaolaoBll . WriteReceivableToGeneralLedger . ExistsSup ( model . MZ108 ) == false )
                        {
                            MessageBox . Show ( "供应商已注销,请核实" );
                            return;
                        }

                        stateOdOdd = "复制保存";
                        DataTable dt = bll.GetDataTableWeiHu( model.MZ001 ,model.MZ002 );
                        if ( de.Rows.Count < 1 )
                            mainSave( );
                        else
                        {
                            int proNum = 0;

                            for ( int i = 0 ; i < de.Rows.Count ; i++ )
                            {
                                proNum = string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "MZ006" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( bandedGridView1 . GetDataRow ( i ) [ "MZ006" ] );
                                if ( proNum != model . MZ006 )
                                {
                                    MessageBox . Show ( "产品数量不一致,请核实" );
                                    break;
                                }

                                if ( dt.Select( "MZ016='" + bandedGridView1.GetDataRow( i )["MZ016"].ToString( ) + "' AND MZ018='" + bandedGridView1.GetDataRow( i )["MZ018"].ToString( ) + "' " ).Length > 0 )//AND MZ019='" + bandedGridView1.GetDataRow( i )["MZ019"].ToString( ) + "' AND MZ023='" + bandedGridView1.GetDataRow( i )["MZ023"].ToString( ) + "'
                                {
                                    if ( model.MZ031 == "廖灵飞" )
                                    {
                                        mainSave( );
                                        break;
                                    }
                                    else
                                    {
                                        MessageBox.Show( "此单为超补,需要总经理处理" );
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
        void mainSave ( )
        {
            result = bll.UpdateAll( model ,"R_344" ,"滚漆承揽加工成本合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"保存" ,stateOdOdd );
            if ( result == true )
            {
                MessageBox.Show( "保存数据成功" );
                if ( weihu == "1" )
                {
                    try
                    {
                        SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfCopy( "R_PQMZC" ,"R_PQMZ" ,"MZ001" ,model.MZ001 ) );
                        WriteOfReceivablesTo( );
                    }
                    catch { }
                }
                saveState( );
            }
            else
                MessageBox.Show( "保存数据失败" );
        }
        void variableMain ( )
        {
            model.MZ002 = textBox1.Text;
            model.MZ003 = textBox2.Text;
            model.MZ004 = textBox3.Text;
            model.MZ005 = textBox4.Text;
            model.MZ006 = string.IsNullOrEmpty( textBox10.Text ) == true ? 0 : Convert.ToInt64( textBox10.Text );
            model.MZ007 = dateTimePicker1.Value;
            model.MZ008 = dateTimePicker2.Value;
            model.MZ009 = textBox5.Text;
            model.MZ010 = dateTimePicker3.Value;
            model.MZ011 = textBox6.Text;
            model.MZ012 = dateTimePicker4.Value;
            model.MZ013 = textBox7.Text;
            model.MZ014 = comboBox6.Text;
            model.MZ015 = dateTimePicker5.Value;
            model.MZ029 = textBox9.Text;
            model.MZ031 = textBox12.Text;
            model.MZ033 = textBox27.Text;
            model.MZ034 = textBox28.Text;
            model.MZ035 = checkBox36.Checked == true ? "T" : "F";
            model.MZ036 = checkBox37.Checked == true ? "T" : "F";
            model.MZ037 = checkBox38.Checked == true ? "T" : "F";
            model.MZ038 = checkBox39.Checked == true ? "T" : "F";
            model.MZ039 = checkBox40.Checked == true ? "T" : "F";
            model.MZ040 = comboBox16.Text;
            model.MZ041 = dateTimePicker7.Value;
            model.MZ042 = comboBox17.Text;
            model.MZ043 = dateTimePicker6.Value;
            model.MZ044 = checkBox4.Checked == true ? "T" : "F";
            model.MZ045 = checkBox7.Checked == true ? "T" : "F";
            model.MZ046 = checkBox5.Checked == true ? "T" : "F";
            model.MZ047 = checkBox6.Checked == true ? "T" : "F";
            model.MZ048 = checkBox1.Checked == true ? "T" : "F";
            model.MZ049 = checkBox2.Checked == true ? "T" : "F";
            model.MZ050 = checkBox3.Checked == true ? "T" : "F";
            model.MZ051 = checkBox8.Checked == true ? "T" : "F";
            model.MZ052 = checkBox9.Checked == true ? "T" : "F";
            model.MZ053 = checkBox10.Checked == true ? "T" : "F";
            model.MZ054 = checkBox41.Checked == true ? "T" : "F";
            model.MZ055 = textBox24.Text;
            model.MZ056 = textBox26.Text;
            model.MZ057 = radioButton1.Checked == true ? "T1" : ( radioButton2.Checked == true ? "T2" : "F" );
            model.MZ058 = radioButton3.Checked == true ? "T1" : ( radioButton4.Checked == true ? "T2" : "F" );
            model.MZ059 = radioButton6.Checked == true ? "T1" : ( radioButton5.Checked == true ? "T2" : "F" );
            model.MZ060 = textBox25.Text;
            model.MZ061 = textBox18.Text;
            model.MZ062 = dateTimePicker9.Value;
            model.MZ063 = checkBox11.Checked == true ? "T" : "F";
            model.MZ064 = checkBox12.Checked == true ? "T" : "F";
            model.MZ065 = checkBox13.Checked == true ? "T" : "F";
            model.MZ066 = checkBox18.Checked == true ? "T" : "F";
            model.MZ067 = checkBox20.Checked == true ? "T" : "F";
            model.MZ068 = checkBox19.Checked == true ? "T" : "F";
            model.MZ069 = checkBox15.Checked == true ? "T" : "F";
            model.MZ070 = checkBox14.Checked == true ? "T" : "F";
            model.MZ071 = checkBox17.Checked == true ? "T" : "F";
            model.MZ072 = checkBox21.Checked == true ? "T" : "F";
            model.MZ073 = checkBox22.Checked == true ? "T" : "F";
            model.MZ074 = checkBox23.Checked == true ? "T" : "F";
            model.MZ075 = checkBox24.Checked == true ? "T" : "F";
            model.MZ076 = checkBox25.Checked == true ? "T" : "F";
            model.MZ077 = checkBox26.Checked == true ? "T" : "F";
            model.MZ078 = checkBox27.Checked == true ? "T" : "F";
            model.MZ079 = checkBox28.Checked == true ? "T" : "F";
            model.MZ080 = checkBox29.Checked == true ? "T" : "F";
            model.MZ081 = checkBox30.Checked == true ? "T" : "F";
            model.MZ082 = checkBox35.Checked == true ? "T" : "F";
            model.MZ083 = checkBox32.Checked == true ? "T" : "F";
            model.MZ084 = checkBox31.Checked == true ? "T" : "F";
            model.MZ085 = checkBox34.Checked == true ? "T" : "F";
            model.MZ086 = checkBox33.Checked == true ? "T" : "F";
            model.MZ087 = textBox30.Text;
            model.MZ088 = textBox31.Text;
            model.MZ089 = comboBox19.Text;
            model.MZ090 = dateTimePicker8.Value;
            model.MZ091 = string.IsNullOrEmpty( textBox33.Text ) == true ? 0 : Convert.ToInt32( textBox33.Text );
            model.MZ092 = radioButton7.Checked == true ? "T1" : ( radioButton8.Checked == true ? "T2" : radioButton9.Checked == true ? "T3" : "F" );
            model.MZ093 = comboBox5.Text;
            model.MZ094 = dateTimePicker10.Value;
            model.MZ095 = string.IsNullOrEmpty( textBox36.Text ) == true ? 0 : Convert.ToInt32( textBox36.Text );
            model.MZ096 = string.IsNullOrEmpty( textBox37.Text ) == true ? 0 : Convert.ToInt32( textBox37.Text );
            model.MZ097 = string.IsNullOrEmpty( textBox38.Text ) == true ? 0 : Convert.ToInt32( textBox38.Text );
            model.MZ098 = string.IsNullOrEmpty( textBox41.Text ) == true ? 0 : Convert.ToInt32( textBox41.Text );
            model.MZ099 = string.IsNullOrEmpty( textBox40.Text ) == true ? 0 : Convert.ToInt32( textBox40.Text );
            model.MZ100 = string.IsNullOrEmpty( textBox39.Text ) == true ? 0 : Convert.ToInt32( textBox39.Text );
            model.MZ101 = string.IsNullOrEmpty( textBox44.Text ) == true ? 0 : Convert.ToInt32( textBox44.Text );
            model.MZ102 = string.IsNullOrEmpty( textBox43.Text ) == true ? 0 : Convert.ToInt32( textBox43.Text );
            model.MZ103 = string.IsNullOrEmpty( textBox42.Text ) == true ? 0 : Convert.ToInt32( textBox42.Text );
            model.MZ104 = textBox35.Text;
            model.MZ109 = textBox11.Text;
            model.MZ110 = textBox47.Text;
            model.MZ111 = textBox46.Text;
            model.MZ112 = textBox45.Text;
            model.MZ113 = textBox15.Text;
            model.MZ114 = textBox14.Text;
            model.MZ115 = lookUpEdit2.Text;
            model.MZ116 = textBox48.Text;
            model.MZ123 = checkBox16.Checked == true ? "T" : "F";
        }
        void saveState ( )
        {
            Ergodic.SpliEnableFalse( spList );
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled = false;
            Ergodic.TablePageEnableFalse( pageList );
            label46.Visible = false;
            textBox9.Enabled = false;
            sign = "";
            weihu = "";
            copy = "";
            button13.Enabled = true;
        }
        protected override void print ( )
        {
            base.print( );

            
            if ( label45.Visible == true )
            {
                MulaolaoBll . ContractAddPrintTime . addTimeToContract ( "R_PQMZ" ,"MZ127" ,model . MZ001 ,"MZ001" );

                SelectAll.GunQiContractChoiceAll choice = new SelectAll.GunQiContractChoiceAll( );
                choice.StartPosition = FormStartPosition.CenterScreen;
                choice.PassDataBetweenForm += new SelectAll.GunQiContractChoiceAll.PassDataBetweenFormHandler( print_PassDataBetweenForm );
                choice.ShowDialog( );
                file = "";
                file = Application.StartupPath;
                if ( printSign == "1" )
                {
                    CreateExport( );
                    report.Load( file + "\\R_344.frx" );
                    report.RegisterData( RDataSet );
                    report.Show( );
                }
                else if ( printSign == "2" )
                {
                    CreatePrint( );
                    report.Load( file + "\\R_345-2.frx" );
                    report.RegisterData( RDataSet );
                    report.Show( );
                }
                else if ( printSign == "3" )
                {
                    CreateOther( );
                    report.Load( file + "\\R_345-1.frx" );
                    report.RegisterData( RDataSet );
                    report.Show( );
                }
            }
            else
                MessageBox.Show( "非执行单据不能打印" );
        }
        private void print_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            printSign = e.ConOne;
        }
        protected override void export ( )
        {
            base.export( );
            
            SelectAll.GunQiContractChoiceAll choice = new SelectAll.GunQiContractChoiceAll( );
            choice.StartPosition = FormStartPosition.CenterScreen;
            choice.PassDataBetweenForm += new SelectAll.GunQiContractChoiceAll.PassDataBetweenFormHandler( print_PassDataBetweenForm );
            choice.ShowDialog( );
            file = "";
            file = Application.StartupPath;
            if ( printSign == "1" )
            {
                CreateExport( );
                report.Load( file + "\\R_344.frx" );
                report.RegisterData( RDataSet );
                report.Prepare( );
                XMLExport exprots = new XMLExport( );
                exprots.Export( report );
            }
            else if ( printSign == "2" )
            {
                CreatePrint( );
                report.Load( file + "\\R_345-2.frx" );
                report.RegisterData( RDataSet );
                report.Prepare( );
                XMLExport exprots = new XMLExport( );
                exprots.Export( report );
            }
            else if ( printSign == "3" )
            {
                CreateOther( );
                report.Load( file + "\\R_345-1.frx" );
                report.RegisterData( RDataSet );
                report.Prepare( );
                XMLExport exprots = new XMLExport( );
                exprots.Export( report );
            }
        }
        protected override void revirw ( )
        {
            base.revirw( );

            Reviews ( "MZ001" ,model . MZ001 ,"R_PQMZ" ,this ,"" ,"R_344" ,false ,false ,null/*,"" ,"" ,"" ,"" ,"" ,"" ,"","R_195"*/ );
            SpecialPowers sp = new SpecialPowers( );
            result = sp.reviewImple( "R_344" ,model.MZ001 );
            if ( result == true )
            {
                result = bll . WriteTo ( model . MZ002 );
                if ( result == false )
                    MessageBox . Show ( "写入346失败,请重新写入" );

                autoLibrary ( );

                label45 .Visible = true;
                button13.Enabled = true;
                try
                {
                    SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfCopy( "R_PQMZC" ,"R_PQMZ" ,"MZ001" ,model.MZ001 ) );
                    WriteOfReceivablesTo( );
                }
                catch { }
            }
            else
                label45.Visible = false;
        }
        bool WriteOfReceivablesTo ( )
        {
            bool result = false;
            DataTable receiva;
            MulaolaoLibrary.ProductCostSummaryLibrary modelAm = new MulaolaoLibrary.ProductCostSummaryLibrary( );
            receiva = bll.GetDataTableOfRecevable( model.MZ001 );
            if ( receiva != null && receiva.Rows.Count > 0 )
            {
                modelAm.AM002 = receiva.Rows[0]["MZ002"].ToString( );
                modelAm.AM249 = 0M;
                modelAm.AM249 = string.IsNullOrEmpty( receiva.Compute( "SUM(MZ0)" ,"MZ002='" + modelAm.AM002 + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "SUM(MZ0)" ,"MZ002='" + modelAm.AM002 + "'" ) );
                if ( bll . UpdateOfReceviable ( modelAm ,model . MZ001 ) )
                    result = true;
                else
                    result = false;
            }
            else
            {
                receiva = new DataTable( );
                receiva = bll.GetDataTableOfReceviable( model.MZ001 );
                if ( receiva != null && receiva.Rows.Count > 0 )
                {
                    modelAm.AM002 = receiva.Rows[0]["MZ002"].ToString( );
                    modelAm.AM242 = modelAm.AM247 = 0M;
                    modelAm.AM242 = string.IsNullOrEmpty( receiva.Compute( "SUM(MZ2)" ,"MZ002='" + modelAm.AM002 + "'  AND MZ123='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "SUM(MZ2)" ,"MZ002='" + modelAm.AM002 + "'  AND MZ123='F'" ) );
                    modelAm.AM247 = string.IsNullOrEmpty( receiva.Compute( "SUM(MZ2)" ,"MZ002='" + modelAm.AM002 + "'  AND MZ123='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "SUM(MZ2)" ,"MZ002='" + modelAm.AM002 + "'  AND MZ123='T'" ) );
                    if ( bll . UpdateOfReceviable ( modelAm ,model . MZ001 ) )
                        result = true;
                    else
                        result = false;
                }
            }

            return result;
        }
        bool autoLibrary ( )
        {
            if ( !bandedGridView1 . GetDataRow ( 0 ) [ "MZ107" ] . ToString ( ) . Equals ( "厂内" ) )
                return true;

            if ( bll . DeleteLibrary ( model . MZ001 ) == false )
            {
                MessageBox . Show ( "请重新查询,重新入库" );
                return false;
            }

            DataTable tableLibrary = bll . getAutoLibrary ( );
            if ( tableLibrary == null || tableLibrary . Rows . Count < 1 )
            {
                MessageBox . Show ( "没有库存,无法出库" );
                return false;
            }
            //出库单号
            string oddNum = string . Empty;
            //库存数量
            decimal libraryNum = 0;
            for ( int i = 0 ; i < bandedGridView1 . RowCount ; i++ )
            {
                model . MZ020 += string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "MZ025" ] . ToString ( ) ) == true ? 0 : Math . Round ( Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "MZ022" ] . ToString ( ) ) * Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "MZ006" ] . ToString ( ) ) * Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "MZ024" ] . ToString ( ) ) * Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "MZ026" ] . ToString ( ) ) / Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "MZ025" ] . ToString ( ) ) + Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "MZ126" ] . ToString ( ) ) ,2 );
            }
            foreach ( DataRow row in tableLibrary . Rows )
            {
                libraryNum += string . IsNullOrEmpty ( row [ "ONE" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "ONE" ] );
            }
            if ( model . MZ020 > libraryNum )
            {
                MessageBox . Show ( "剩余库存量少于使用库存量,请核实再出库" );
                return false;
            }
            int j = 0;
            decimal libraryNumLast = 0;
            string resultLast = string . Empty;
            for ( int i = 0 ; i < bandedGridView1 . RowCount ; i++ )
            {
                if ( j != 0 )
                    i = j;
                model . MZ020 = string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "MZ025" ] . ToString ( ) ) == true ? 0 : Math . Round ( Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "MZ022" ] . ToString ( ) ) * Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "MZ006" ] . ToString ( ) ) * Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "MZ024" ] . ToString ( ) ) * Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "MZ026" ] . ToString ( ) ) / Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "MZ025" ] . ToString ( ) ) + Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "MZ126" ] . ToString ( ) ) ,2 );
                model . MZ023 = bandedGridView1 . GetDataRow ( i ) [ "MZ023" ] . ToString ( );
                model . MZ019 = bandedGridView1 . GetDataRow ( i ) [ "MZ019" ] . ToString ( );
                model . MZ032 = bandedGridView1 . GetDataRow ( i ) [ "MZ124" ] . ToString ( );
                model . MZ003 = textBox2 . Text;
                model . MZ005 = textBox4 . Text;
                model . MZ002 = textBox1 . Text;

                if ( libraryNumLast != 0 )
                {
                    model . MZ020 = libraryNumLast;
                    libraryNumLast = 0;
                }

                DataRow rows = null;
                foreach ( DataRow row in tableLibrary . Rows )
                {
                    rows = row;
                    oddNum = row [ "AC18" ] . ToString ( );
                    libraryNum = string . IsNullOrEmpty ( row [ "ONE" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "ONE" ] );
                    if ( libraryNum >= model . MZ020 )
                    {
                        row [ "ONE" ] = libraryNum - model . MZ020;
                        libraryNum = 0;
                        j = 0;
                        break;
                    }
                    else if ( libraryNum > 0 && libraryNum < model . MZ020 )
                    {
                        j = i;
                        libraryNumLast = model . MZ020 - libraryNum;
                        model . MZ020 =  libraryNum;
                        libraryNum = 0;
                        resultLast = string . Empty;
                        break;
                    }
                    else if ( libraryNum == 0 )
                    {
                        resultLast = "-1";
                        j = i;
                        break;
                    }
                }

                if ( resultLast == string . Empty )
                    tableLibrary . Rows . Remove ( rows );
                if ( resultLast . Equals ( "-1" ) )
                    continue;

                result = fc . LibraryOf ( model . MZ003 ,model . MZ005 ,model . MZ002 ,bandedGridView1 . GetDataRow ( 0 ) [ "MZ006" ] . ToString ( ) ,model . MZ023 ,model . MZ019 ,model . MZ032 ,0 . ToString ( ) ,"" ,0 . ToString ( ) ,/*u15Cal.ToString( )*/model . MZ020 . ToString ( ) ,Logins . username ,System . DateTime . Now ,model . MZ001 ,oddNum );
                if ( result == false )
                {
                    MessageBox . Show ( "出库失败" );
                    break;
                }
            }

            if ( result == true )
            {
                if ( WriteOfReceivablesTo ( ) == false )
                {
                    MessageBox . Show ( "写入241数据错误,请重新出库" );
                    return false;
                }
                else
                {
                    MessageBox . Show ( "出库成功" );
                    model . MZ002 = textBox1 . Text;
                    if ( speList . Count > 0 )
                        fc . deleteOfLibrary ( speList ,model . MZ001 ,model . MZ002 );
                }
            }
            return true;
        }
        protected override void maintain ( )
        {
            base.maintain( );

            if ( label45.Visible == true )
            {
                Ergodic.SpliEnableTrue( spList );
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
                Ergodic.TablePageEnableTrue( pageList );
                textBox9.Enabled = true;
                weihu = "1";
            }
            else
                MessageBox.Show( "此单据状态为非执行,请更改" );
        }
        protected override void cancel ( )
        {
            base.cancel( );

            if ( sign == "1" && weihu != "1" )
            {
                Ergodic.FormEvery( this );
                gridControl1.DataSource = null;
                toolSelect.Enabled = toolAdd.Enabled = true;
                toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                sign = "";
                weihu = "";
                copy = "";
                textBox13.Enabled = false;
                label45.Visible = label46.Visible = false;
                Ergodic.SpliClear( spList );
                Ergodic.TablePageEnableClear( pageList );
                try
                {
                    bll.DeleteAll( model.MZ001 ,"R_344" ,"滚漆承揽加工成本合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"删除" ,stateOdOdd );
                }
                catch { }
            }
            else
            {
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = false;
            }
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableFalse( pageList );
        }
        protected override void copys ( )
        {
            base.copys( );

            if ( label45 . Visible == true )
                stateOdOdd = "维护复制";
            else
            {
                if ( sign . Equals ( "1" ) )
                    stateOdOdd = "新增复制";
                else
                    stateOdOdd = "更改复制";
            }
            
            result = bll.Copy( model.MZ001 ,"R_344" ,"滚漆承揽加工成本合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"复制" ,stateOdOdd );
            if ( result == true )
            {
                model.MZ001 = oddNumbers.purchaseContract( "SELECT MAX(AJ019) AJ019 FROM R_PQAJ" ,"AJ019" ,"R_344-" );
                stateOdOdd = "复制更改单号";
                result = bll.UpdateCopy( model.MZ001 ,"R_344" ,"滚漆承揽加工成本合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"复制" ,stateOdOdd );
                if ( result == true )
                {
                    MessageBox.Show( "复制成功" );
                    Ergodic.FormEvery( this );
                    gridControl1.DataSource = null;
                    Ergodic.SpliEnableTrue( spList );
                    Ergodic.TablePageEnableTrue( pageList );
                    toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                    toolSave.Enabled = toolCancel.Enabled = true;

                    textBox9.Enabled = false;
                    sign = "1";
                    weihu = "";
                    copy = "1";
                    label45.Visible = false;
                    label46.Visible = true;
                    queryContent( );
                }
                else
                {
                    MessageBox.Show( "复制失败" );
                    bll.DeleteCopy( );
                }
            }
            else
                MessageBox.Show( "复制失败" );
        }
        protected override void library ( )
        {
            base.library( );

            if ( label45 . Visible == false )
            {
                MessageBox . Show ( "非执行单据不能出库" );
                return;
            }

            if ( !bandedGridView1 . GetDataRow ( 0 ) [ "MZ107" ] . ToString ( ) . Equals ( "厂内" ) )
            {
                MessageBox . Show ( "厂外单据不允许出库" );
                return;
            }

            autoLibrary ( );
            return;

            decimal planQi = 0;
            libraryTable = null;
            for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
            {
                planQi = string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "MZ025" ] . ToString ( ) ) == true ? 0 : Math . Round ( Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "MZ022" ] . ToString ( ) ) * Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "MZ006" ] . ToString ( ) ) * Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "MZ024" ] . ToString ( ) ) * Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "MZ026" ] . ToString ( ) ) / Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "MZ025" ] . ToString ( ) ) + Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "MZ126" ] . ToString ( ) ) ,2 );
                //[MZ022] * [MZ006] * [MZ026]*[MZ024] / [MZ025]
                if ( libraryTable != null )
                    libraryTable . Rows . Add ( new object [ ] { bandedGridView1 . GetDataRow ( i ) [ "MZ032" ] . ToString ( )/*品牌*/ ,bandedGridView1 . GetDataRow ( i ) [ "MZ023" ] . ToString ( )/*色名*/,bandedGridView1 . GetDataRow ( i ) [ "MZ019" ] . ToString ( )/*色号*/ ,planQi } );
                else
                {
                    libraryTable = new DataTable ( "Datas" );
                    libraryTable . Columns . Add ( "tOne" ,typeof ( System . String ) );
                    libraryTable . Columns . Add ( "tTwo" ,typeof ( System . String ) );
                    libraryTable . Columns . Add ( "tTre" ,typeof ( System . String ) );
                    libraryTable . Columns . Add ( "tFor" ,typeof ( System . Decimal ) );
                    libraryTable . Rows . Add ( new object [ ] { bandedGridView1 . GetDataRow ( i ) [ "MZ032" ] . ToString ( ) ,bandedGridView1 . GetDataRow ( i ) [ "MZ023" ] . ToString ( ) ,bandedGridView1 . GetDataRow ( i ) [ "MZ019" ] . ToString ( ) ,planQi } );
                }
            }
            if ( libraryTable.Rows.Count > 0 )
            {
                SelectAll. GunQiChenBenLibraryAll outC = new SelectAll. GunQiChenBenLibraryAll ( );
                outC.libraryTable = libraryTable;
                outC.oddNum = model.MZ001;
                outC.StartPosition = FormStartPosition.CenterScreen;
                outC . PassDataBetweenForm += new SelectAll . GunQiChenBenLibraryAll . PassDataBetweenFormHandler ( outC_PassDataBetweenForm );
                outC.ShowDialog( );
            }
            if ( conOne == "2" )
                return;
            //int countSum = 0;
            //decimal u15Cal = 0, perSet = 0;
            for ( int i = 0 ; i < libraryTable . Rows . Count ; i++ )
            {
                //出库单号
                model . MZ003 = libraryTable . Rows [ i ] [ "tOne" ] . ToString ( );
                if ( model . MZ003 . Contains ( "R_464" ) )
                {
                    //每套用量
                    model . MZ020 = string . IsNullOrEmpty ( libraryTable . Rows [ i ] [ "tFor" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( libraryTable . Rows [ i ] [ "tFor" ] . ToString ( ) );

                    tableQuery = bll . GetDataTableAC ( model . MZ001 );
                    if ( tableQuery != null && tableQuery . Rows . Count > 0 )
                    {
                        model . MZ023 = tableQuery . Rows [ 0 ] [ "AC04" ] . ToString ( );
                        model . MZ019 = tableQuery . Rows [ 0 ] [ "AC05" ] . ToString ( );
                        model . MZ032 = tableQuery . Rows [ 0 ] [ "AC06" ] . ToString ( );
                    }
                    
                    result = fc . LibraryOf ( textBox2 . Text ,textBox4 . Text ,textBox1 . Text ,bandedGridView1 . GetDataRow ( 0 ) [ "MZ006" ] . ToString ( ) ,model . MZ023 ,model . MZ019 ,model . MZ032 ,0 . ToString ( ) ,"" ,0 . ToString ( ) ,/*u15Cal.ToString( )*/model . MZ020 . ToString ( ) ,Logins . username ,System . DateTime . Now ,model . MZ001 ,model . MZ003 );
                    if ( result == false )
                    {
                        MessageBox . Show ( "出库失败" );
                        break;
                    }
                }
                else
                    result = false;
            }
            if ( result == true )
            {
                if ( WriteOfReceivablesTo ( ) == false )
                {
                    MessageBox . Show ( "写入241数据错误,请重新出库" );
                    return;
                }
                else
                {
                    MessageBox . Show ( "出库成功" );
                    model . MZ002 = textBox1 . Text;
                    if ( speList . Count > 0 )
                        fc . deleteOfLibrary ( speList ,model . MZ001 ,model . MZ002 );
                }
            }
            //for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
            //{
            //    speList.Clear( );
            //    string query = "", count = "";
            //    if ( libraryTable == null )
            //        query = count = "";
            //    if ( libraryTable != null && libraryTable.Rows.Count > 0 )
            //    {
            //        countSum = libraryTable.Select( "tTwo='" + bandedGridView1.GetDataRow( i )["MZ019"].ToString( ) + bandedGridView1.GetDataRow( i )["MZ023"].ToString( ) + bandedGridView1.GetDataRow( i )["MZ032"].ToString( ) + "'" ).Length;
            //        if ( countSum > 0 )
            //        {
            //            for ( int k = 0 ; k < countSum ; k++ )
            //            {
            //                if ( !speList.Contains( libraryTable.Select( "tTwo='" + bandedGridView1.GetDataRow( i )["MZ019"].ToString( ) + bandedGridView1.GetDataRow( i )["MZ023"].ToString( ) + bandedGridView1.GetDataRow( i )["MZ032"].ToString( ) + "'" )[k]["tOne"].ToString( ) ) )
            //                    speList.Add( libraryTable.Select( "tTwo='" + bandedGridView1.GetDataRow( i )["MZ019"].ToString( ) + bandedGridView1.GetDataRow( i )["MZ023"].ToString( ) + bandedGridView1.GetDataRow( i )["MZ032"].ToString( ) + "'" )[k]["tOne"].ToString( ) );
            //            }
            //            if ( speList.Count > 0 )
            //            {
            //                foreach ( string str in speList )
            //                {
            //                    query = str;
            //                    count = libraryTable.Select( "tTwo='" + bandedGridView1.GetDataRow( i )["MZ019"].ToString( ) + bandedGridView1.GetDataRow( i )["MZ023"].ToString( ) + bandedGridView1.GetDataRow( i )["MZ032"].ToString( ) + "' AND tOne='" + query + "'" )[0]["tFor"].ToString( );

            //                    //u15Cal = Convert.ToDecimal( hw.SomeOfCaculation( bandedGridView1.GetDataRow( i )["MZ022"].ToString( ) ,bandedGridView1.GetDataRow( i )["MZ006"].ToString( ) ,bandedGridView1.GetDataRow( i )["MZ026"].ToString( ) ,bandedGridView1.GetDataRow( i )["MZ024"].ToString( ) ,bandedGridView1.GetDataRow( i )["MZ025"].ToString( ) ) );
            //                    perSet = string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["MZ006"].ToString( ) ) == true ? 0M : Math.Round( u15Cal / Convert.ToDecimal( bandedGridView1.GetDataRow( i )["MZ006"].ToString( ) ) ,2 );

            //                    result = fc.LibraryOf( textBox2.Text ,textBox4.Text ,textBox1.Text ,bandedGridView1.GetDataRow( i )["MZ006"].ToString( ) ,bandedGridView1.GetDataRow( i )["MZ023"].ToString( ) ,bandedGridView1.GetDataRow( i )["MZ019"].ToString( ) ,bandedGridView1.GetDataRow( i )["MZ032"].ToString( ) ,perSet.ToString( ) ,"" ,bandedGridView1.GetDataRow( i )["MZ025"].ToString( ) ,/*u15Cal.ToString( )*/count.ToString( ) ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,model.MZ001 ,query );
            //                    if ( result == false )
            //                    {
            //                        MessageBox.Show( "出库失败" );
            //                        break;
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            //if ( result == true )
            //    MessageBox.Show( "出库成功" );
        }
        private void outC_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            libraryTable = new DataTable ( );
            conOne = e . ConOne;
            libraryTable = e . TabOne;
        }
        #endregion
        
        #region Table
        DataRow row;
        void variable ( )
        {
            model . MZ002 = textBox1 . Text;
            model . MZ031 = textBox12 . Text;
            model . MZ006 = string . IsNullOrEmpty ( textBox10 . Text ) == true ? 0 : Convert . ToInt64 ( textBox10 . Text );
            model . MZ016 = lookUpEdit1 . Text;
            model . MZ017 = textBox13 . Text;
            model . MZ018 = comboBox3 . Text;
            model . MZ019 = comboBox4 . Text;
            model . MZ020 = string . IsNullOrEmpty ( textBox16 . Text ) == true ? 0 : Convert . ToDecimal ( textBox16 . Text );
            model . MZ021 = string . IsNullOrEmpty ( textBox17 . Text ) == true ? 0 : Convert . ToInt32 ( textBox17 . Text );
            model . MZ022 = string . IsNullOrEmpty ( textBox18 . Text ) == true ? 0M : Convert . ToDecimal ( textBox18 . Text );
            model . MZ023 = textBox19 . Text;
            model . MZ024 = string . IsNullOrEmpty ( comboBox1 . Text ) == true ? 0 : Convert . ToInt32 ( comboBox1 . Text );
            model . MZ025 = string . IsNullOrEmpty ( textBox23 . Text ) == true ? 0 : Convert . ToDecimal ( textBox23 . Text );
            model . MZ026 = string . IsNullOrEmpty ( textBox20 . Text ) == true ? 0 : Convert . ToDecimal ( textBox20 . Text );
            model . MZ027 = string . IsNullOrEmpty ( textBox32 . Text ) == true ? 0 : Convert . ToDecimal ( textBox32 . Text );
            model . MZ028 = string . IsNullOrEmpty ( textBox22 . Text ) == true ? 0 : Convert . ToDecimal ( textBox22 . Text );
            model . MZ032 = textBox21 . Text;
            model . MZ105 = calculVolume ( comboBox3 . Text );
            model . MZ106 = textBox34 . Text;
            model . MZ107 = comboBox2 . Text;
            model . MZ118 = string . IsNullOrEmpty ( textBox51 . Text ) == true ? 0 : Convert . ToInt32 ( textBox51 . Text );
            model . MZ119 = string . IsNullOrEmpty ( textBox50 . Text ) == true ? 0 : Convert . ToInt32 ( textBox50 . Text );
            model . MZ120 = string . IsNullOrEmpty ( textBox49 . Text ) == true ? 0 : Convert . ToInt32 ( textBox49 . Text );
            model . MZ122 = radioButton10 . Checked == true ? "库存" : "外购";
            model . MZ124 = comboBox7 . Text;
            model . MZ126 = string . IsNullOrEmpty ( textBox55 . Text ) == true ? 0 : Convert . ToDecimal ( textBox55 . Text );
        }
        decimal calculVolume ( string speci )
        {
            decimal resus = 0M;
            if ( string.IsNullOrEmpty( speci ) )
                resus = 0M;
            else
            {
                string[] str = speci.Split( '*' );
                if ( str.Length < 1 )
                    resus = 0M;
                else if ( str.Length == 1 )
                {
                    if ( isNumberic( str[0] ,out resus ) )
                        resus = 0M;
                    else
                    {
                        if ( str[0].Contains( "Φ" ) || str[0].Contains( "φ" ) )
                            resus = Math.Round( Convert.ToDecimal( Convert.ToDouble( Math.PI ) * Math.Pow( Convert.ToDouble( str[0].Substring( 1 ,str[0].Length - 1 ) ) ,3 ) /** Convert.ToDouble( 0.0001 )*/ * 4 / 3 ) ,1 );
                        else
                            resus = 0M;
                    }
                }
                else if ( str.Length == 2 )
                {
                    if ( isNumberic( str[0] ,out resus ) )
                        resus = 0M;
                    else
                    {
                        if ( ( str[0].Contains( "Φ" ) || str[0].Contains( "φ" ) ) && ( str[0].Substring( 0 ,1 ) == "Φ" || str[0].Substring( 0 ,1 ) == "φ" ) )
                        {
                            if ( isNumberic( str[1] ,out resus ) )
                            {
                                if ( isNumberic( str[0].Substring( 1 ,str[0].Length - 1 ) ,out resus ) )
                                    resus = Math.Round( Convert.ToDecimal( Convert.ToDouble( Math.PI ) * Math.Pow( Convert.ToDouble( str[0].Substring( 1 ,str[0].Length - 1 ) ) / 2 ,2 ) * Convert.ToDouble( str[1] ) /** Convert.ToDouble( 0.0001 )*/ ) ,1 );
                                else
                                    resus = 0M;
                            }
                            else
                                resus = 0M;
                        }
                        else
                            resus = 0M;
                    }
                }
                else if ( str.Length >= 3 )
                {
                    if ( isNumberic( str[0] ,out resus ) && isNumberic( str[1] ,out resus ) && isNumberic( str[2] ,out resus ) )
                        resus = Math.Round( Convert.ToDecimal( str[0] ) * Convert.ToDecimal( str[1] ) * Convert.ToDecimal( str[2] ) /** Convert.ToDecimal( 0.0001 )*/ ,1 );
                    else
                        resus = 0M;
                }
            }
            return resus;
        }
        protected bool isNumberic ( string message ,out decimal reus )
        {
            reus = -1M;
            try
            {
                reus = Convert.ToDecimal( message );
                if ( reus == 0M )
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }
        void addOfCom ( )
        {
            if ( dl == null )
                return;
            else
            {
                DataRow rows = dl.NewRow( );
                DataRow[] rowOne = dl.Select( "MZ124='" + model.MZ124 + "'" );
                if (! rowOne.Length.Equals(1))
                {
                    rows["MZ124"] = model.MZ124;
                    dl.Rows.Add( rows );
                }
                DataRow rowe = dl.NewRow( );
                DataRow[] rowTwo = dl.Select( "MZ024='" + model.MZ024 + "'" );
                if (! rowTwo.Length.Equals( 1 ) )
                {
                    rowe["MZ024"] = model.MZ024;
                    dl.Rows.Add( rowe );
                }
            }
        }
        void col ( )
        {
            row [ "MZ006" ] = model . MZ006;
            row [ "MZ016" ] = model . MZ016;
            row [ "MZ017" ] = model . MZ017;
            row [ "MZ018" ] = model . MZ018;
            row [ "MZ019" ] = model . MZ019;
            row [ "MZ020" ] = model . MZ020;
            row [ "MZ021" ] = model . MZ021;
            row [ "MZ022" ] = model . MZ022;
            row [ "MZ023" ] = model . MZ023;
            row [ "MZ024" ] = model . MZ024;
            row [ "MZ025" ] = model . MZ025;
            row [ "MZ026" ] = model . MZ026;
            row [ "MZ027" ] = model . MZ027;
            row [ "MZ028" ] = model . MZ028;
            row [ "MZ032" ] = model . MZ032;
            row [ "MZ105" ] = model . MZ105;
            row [ "MZ106" ] = model . MZ106;
            row [ "MZ107" ] = model . MZ107;
            row [ "MZ118" ] = model . MZ118;
            row [ "MZ119" ] = model . MZ119;
            row [ "MZ120" ] = model . MZ120;
            row [ "MZ124" ] = model . MZ124;
            row [ "MZ125" ] = model . MZ125;
            row [ "MZ126" ] = model . MZ126;
            //row["MZ108"] = model.MZ108;
        }
        void serialNum ( )
        {
            DataTable da = bll.GetDataTableOfSerialNum( model.MZ001 );
            if ( da == null || da . Rows . Count < 1 )
                model . MZ125 = "001";
            else
            {
                model . MZ125 = da . Rows [ 0 ] [ "MZ125" ] . ToString ( );

                if ( string . IsNullOrEmpty ( model . MZ125 ) )
                    model . MZ125 = "001";
                else
                    model . MZ125 = ( Convert . ToInt32 ( model . MZ125 ) + 1 ) . ToString ( ) . PadLeft ( 3 ,'0' );
            }
        }
        //Build
        private void button8_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( textBox1 . Text ) )
            {
                MessageBox . Show ( "流水号不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( textBox12 . Text ) )
            {
                MessageBox . Show ( "开合同人不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( lookUpEdit1 . Text ) )
            {
                MessageBox . Show ( "零件名称不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( comboBox2 . Text ) )
            {
                MessageBox . Show ( "请选择厂内或厂外" );
                return;
            }
            if ( string . IsNullOrEmpty ( comboBox7 . Text ) )
            {
                MessageBox . Show ( "产品色号不可为空" );
                return;
            }
            //if ( comboBox2.Text == "厂内" )
            //{
            //    if ( radioButton10.Checked == false && radioButton11.Checked == false )
            //    {
            //        MessageBox.Show( "请选择使用库存或外购" );
            //        return;
            //    }
            //    //if ( radioButton10.Checked )
            //    //{
            //    //    if ( string.IsNullOrEmpty( comboBox4.Text ) )
            //    //    {
            //    //        MessageBox.Show( "色号不可为空" );
            //    //        return;
            //    //    }
            //    //}
            //    if ( radioButton11.Checked )
            //    {
            //        MessageBox.Show( "厂内必须用库存" );
            //        return;
            //    }


            //    //色号  色名   品牌
            //    DataTable dl = bll.GetDataTableStock( comboBox4.Text ,textBox19.Text ,textBox21.Text );
            //    if ( dl != null && dl.Rows.Count > 0 )
            //    {
            //        //radioButton10.Checked = true;
            //        textBox53.Text = dl.Rows[0]["AC10"].ToString( );
            //    }
            //    //else
            //    //    radioButton11.Checked = true;

            //    if ( !string.IsNullOrEmpty( textBox53.Text ) && !string.IsNullOrEmpty( textBox52.Text ) )
            //    {
            //        if ( Convert.ToDecimal( textBox52.Text ) > Convert.ToDecimal( textBox53.Text ) )
            //        {
            //            MessageBox.Show( "外购数量大于库存数量" );
            //            return;
            //        }
            //    }

            //}

            variable ( );
            serialNum ( );
            result = bll . Exists ( model );
            if ( result == true )
            {
                if ( model . MZ031 . Equals ( "廖灵飞" ) )
                    build ( );
                else
                {
                    MessageBox . Show ( "此单为超补,需要总经理处理" );
                    return;
                }
            }
            else
                build ( );
        }
        void build ( )
        {
            if ( label45.Visible == true )
                stateOdOdd = "维护新建";
            else
            {
                if ( sign == "1" )
                    stateOdOdd = "新增新建";
                else
                    stateOdOdd = "更改新建";
            }

            result = bll.Insert( model ,"R_344" ,"滚漆承揽加工成本合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"新建" ,stateOdOdd );
            if ( result == true )
            {
                MessageBox.Show( "成功录入数据" );
                if ( tableQuery == null )
                    button11_Click( null ,null );
                else
                {
                    row = tableQuery.NewRow( );
                    //row["idx"] = model.IDX;
                    col( );
                    tableQuery.Rows.Add( row );
                }
                addOfCom( );
            }
            else
                MessageBox.Show( "录入数据失败" );
        }
        //Edit
        private void button9_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( textBox1 . Text ) )
            {
                MessageBox . Show ( "流水号不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( textBox12 . Text ) )
            {
                MessageBox . Show ( "开合同人不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( lookUpEdit1 . Text ) )
            {
                MessageBox . Show ( "零件名称不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( comboBox7 . Text ) )
            {
                MessageBox . Show ( "产品色号不可为空" );
                return;
            }
            //if ( comboBox2.Text == "厂内" )
            //{
            //    if ( radioButton10.Checked == false && radioButton11.Checked == false )
            //    {
            //        MessageBox.Show( "请选择使用库存或外购" );
            //        return;
            //    }
            //    //if ( radioButton10.Checked )
            //    //{
            //    //    if ( string.IsNullOrEmpty( comboBox4.Text ) )
            //    //    {
            //    //        MessageBox.Show( "色号不可为空" );
            //    //        return;
            //    //    }
            //    //}
            //    if ( radioButton11.Checked )
            //    {
            //        MessageBox.Show( "厂内必须用库存" );
            //        return;
            //    }

            //    //色号  色名   品牌
            //    DataTable dl = bll.GetDataTableStock( comboBox4.Text ,textBox19.Text ,textBox21.Text );
            //    if ( dl != null && dl.Rows.Count > 0 )
            //    {
            //        //radioButton10.Checked = true;
            //        textBox53.Text = dl.Rows[0]["AC10"].ToString( );
            //    }
            //    //else
            //        //radioButton11.Checked = true;
            //    if ( !string.IsNullOrEmpty( textBox53.Text )  && !string.IsNullOrEmpty( textBox52.Text ) && !string.IsNullOrEmpty( textBox8.Text ) )
            //    {
            //        if ( Convert.ToDecimal( textBox8.Text ) != Convert.ToDecimal( textBox52.Text ) )
            //        {
            //            if ( Convert.ToDecimal( textBox52.Text ) > Convert.ToDecimal( textBox53.Text ) )
            //            {
            //                MessageBox.Show( "外购数量大于库存数量" );
            //                return;
            //            }
            //        }
            //    }

            //}

            variable ( );
            if ( partName == lookUpEdit1 . Text && product == comboBox3 . Text && wages == comboBox4 . Text && colorName == textBox19 . Text && brand == textBox21 . Text )
                edit ( );
            else
            {
                result = bll . Exists ( model );
                if ( result == true )
                {
                    if ( model . MZ031 . Equals ( "廖灵飞" ) )
                        edit ( );
                    else
                    {
                        MessageBox . Show ( "此单为超补,需要总经理处理" );
                        return;
                    }
                }
                edit ( );
            }
        }
        void edit ( )
        {
            if ( label45.Visible == true )
                stateOdOdd = "维护编辑";
            else
            {
                if ( sign == "1" )
                    stateOdOdd = "新增编辑";
                else
                    stateOdOdd = "更改编辑";
            }

            result = bll.Update( model ,"R_344" ,"滚漆承揽加工成本合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"编辑" ,stateOdOdd );
            if ( result == true )
            {
                MessageBox.Show( "编辑数据成功" );
                row = tableQuery.Rows[bandedGridView1.FocusedRowHandle];
                row.BeginEdit( );
                col( );
                row.EndEdit( );
                addOfCom( );
            }
            else
                MessageBox.Show( "编辑数据失败" );
        }
        //Delete
        private void button10_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) ==DialogResult . Cancel )
                return;
            if ( label45.Visible == true )
                stateOdOdd = "维护删除";
            else
            {
                if ( sign == "1" )
                    stateOdOdd = "新增删除";
                else
                    stateOdOdd = "更改删除";
            }

            result = bll.Delete( model.MZ125 ,"R_344" ,"滚漆承揽加工成本合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"删除" ,stateOdOdd ,model.MZ001 );
            if ( result == true )
            {
                MessageBox.Show( "成功删除数据" );
                tableQuery.Rows.RemoveAt( bandedGridView1.FocusedRowHandle );
            }
            else
                MessageBox.Show( "删除数据失败" );
        }
        //Refresh
        private void button11_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            strWhere = strWhere + " AND MZ001='" + model.MZ001 + "'";
            tableQuery = bll.GetDataTableQuery( strWhere );
            gridControl1.DataSource = tableQuery;
            assign( );
        }
        void assign ( )
        {
            if ( tableQuery != null && tableQuery . Rows . Count > 0 )
            {
                MZ006 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,bandedGridView1 . GetDataRow ( 0 ) [ "MZ006" ] . ToString ( ) );
                decimal d1 = string . IsNullOrEmpty ( U0 . SummaryItem . SummaryValue . ToString ( ) ) == true ? 0 : ( Convert . ToDecimal ( U0 . SummaryItem . SummaryValue ) == 0 ? 0 : Math . Round ( Convert . ToDecimal ( U16 . SummaryItem . SummaryValue ) / Convert . ToDecimal ( U0 . SummaryItem . SummaryValue ) ,2 ) );
                decimal d2 = string . IsNullOrEmpty ( U0 . SummaryItem . SummaryValue . ToString ( ) ) == true ? 0 : ( Convert . ToDecimal ( U0 . SummaryItem . SummaryValue ) == 0 ? 0 : Math . Round ( Convert . ToDecimal ( U14 . SummaryItem . SummaryValue ) / Convert . ToDecimal ( U0 . SummaryItem . SummaryValue ) ,1 ) );
                decimal d3 = string . IsNullOrEmpty ( U0 . SummaryItem . SummaryValue . ToString ( ) ) == true ? 0 : ( Convert . ToDecimal ( U0 . SummaryItem . SummaryValue ) == 0 ? 0 : Math . Round ( Convert . ToDecimal ( U12 . SummaryItem . SummaryValue ) / Convert . ToDecimal ( U0 . SummaryItem . SummaryValue ) ,3 ) );
                MZ027 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,d2 . ToString ( ) );
                MZ026 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,d1 . ToString ( ) );
                U8 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( d1 + d2 ,3 ) . ToString ( ) );
                MZ028 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,d3 . ToString ( ) );
                U9 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( d3 - d1 - d2 ,2 ) . ToString ( ) );
                U11 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "MZ006" ] . ToString ( ) ) == true ? 0 : ( Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "MZ006" ] . ToString ( ) ) == 0 ? 0 : Math . Round ( Convert . ToDecimal ( U14 . SummaryItem . SummaryValue ) / Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "MZ006" ] . ToString ( ) ) ,3 ) ) ) . ToString ( ) );
                U19 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Convert . ToDecimal ( U12 . SummaryItem . SummaryValue ) == 0 ? 0 . ToString ( ) : Math . Round ( Convert . ToDecimal ( U18 . SummaryItem . SummaryValue ) / Convert . ToDecimal ( U12 . SummaryItem . SummaryValue ) * 100 ,2 ) . ToString ( ) + "%" );
            }
        }
        //Batch
        string numSign = "";
        private void button14_Click ( object sender ,EventArgs e )
        {
            SelectAll.NumberEditContract numQuery = new SelectAll.NumberEditContract( );
            numQuery.textBox1.Text = textBox10.Text;
            numQuery.StartPosition = FormStartPosition.CenterScreen;
            numQuery.PassDataBetweenForm += new SelectAll.NumberEditContract.PassDataBetweenFormHandler( num_PassDataBetweenForm );
            numQuery.ShowDialog( );

            if ( numSign == "yes" )
            {
                if ( label45.Visible == true )
                    stateOdOdd = "维护批量编辑";
                else
                {
                    if ( sign == "1" )
                        stateOdOdd = "新增批量编辑";
                    else
                        stateOdOdd = "更改批量编辑";
                }

                result = bll.batchUpdate( model.MZ001 ,model.MZ006 ,"R_344" ,"滚漆承揽加工成本合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"批量编辑" ,stateOdOdd );
                if ( result == true )
                {
                    MessageBox.Show( "批量编辑成功" );
                    button11_Click( null ,null );
                }
                else
                    MessageBox.Show( "批量编辑产品数量失败,请刷新重试" );
            }
        }
        private void num_PassDataBetweenForm ( object sender,PassDataWinFormEventArgs e )
        {
            if ( e.ConTwo == "yes" )
            {
                numSign = e.ConTwo;
                model.MZ006 = string.IsNullOrEmpty( e.ConOne ) == true ? 0 : Convert.ToInt64( e.ConOne );
            }
            else
                numSign = "";
        }
        //WriteToR_346
        private void button13_Click ( object sender ,EventArgs e )
        {
            if ( label45.Visible == true )
            {
                //if ( bandedGridView1.GetDataRow( 0 )["MZ122"].ToString( ) == "库存" )
                //{
                //    result = bll.ExistsOfLibrary( model.MZ001 );
                //    if ( result == false )
                //    {
                //        MessageBox.Show( "此单没有出库,请出库" );
                //        return;
                //    }
                //}
                
                result = bll.WriteTo( model.MZ002 );
                if ( result == true )
                {
                    MessageBox . Show ( "成功写入数据" );

                }
                else
                    MessageBox.Show( "写入数据失败" );
            }
            else
                MessageBox.Show( "非执行数据不能写入" );
        }
        //Clear
        private void button15_Click ( object sender ,EventArgs e )
        {
               textBox13.Text = comboBox3.Text = comboBox4.Text = textBox16.Text = textBox17.Text = textBox18.Text = textBox19.Text = comboBox1.Text = textBox23.Text = textBox20.Text = textBox32.Text = textBox22.Text = textBox21.Text = comboBox3.Text = textBox34.Text = comboBox2.Text = textBox51.Text = textBox50.Text = textBox49.Text = "";
        }
        #endregion

        #region Query
        //Num      
        private void button1_Click ( object sender ,EventArgs e )
        {
            SelectAll.GunQiChengLanNumAll numQuery = new SelectAll.GunQiChengLanNumAll( );
            numQuery.StartPosition = FormStartPosition.CenterScreen;
            numQuery.PassDataBetweenForm += new SelectAll.GunQiChengLanNumAll.PassDataBetweenFormHandler( numQuery_PassDataBetweenForm );
            numQuery.ShowDialog( );
        }
        private void numQuery_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            textBox1.Text = e.ConOne;
            textBox3.Text = e.ConTwo;
            textBox4.Text = e.ConTre;
            textBox2.Text = e.ConFor;
            textBox10.Text = e.ConFiv;
            dateTimePicker1.Value = string.IsNullOrEmpty( e.ConSix ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( e.ConSix );
            dateTimePicker2.Value = string.IsNullOrEmpty( e.ConSev ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( e.ConSev );
            textBox27.Text = e.ConEgi;
            textBox28.Text = e.ConNin;
        }
        //Part
        private void button6_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( comboBox2 . Text ) )
            {
                MessageBox . Show ( "请选择厂内或厂外" );
                return;
            }
            R_FrmR_519select se = new R_FrmR_519select( );
            se.StartPosition = FormStartPosition.CenterScreen;
            se.PassDataBetweenForm += new R_FrmR_519select.PassDataBetweenFormHandler( se_PassDataBetweenForm );
            se.zhi = "7";
            se.ShowDialog( );
        }
        private void se_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            textBox13.Text = e.ConOne;
            textBox21.Text = e.ConTwo;
            textBox19.Text = e.ConTre;
            textBox16.Text = e.ConFor;
            textBox23.Text = e.ConFiv;
            textBox32.Text = e.ConSix;
            textBox20.Text = e.ConSev;
            textBox22.Text = e.ConEgi;
            textBox34.Text = e.ConNin;
        }
        SelectAll.GunQiContractAll query = new SelectAll.GunQiContractAll( );
        protected override void select ( )
        {
            base.select( );

            model = new MulaolaoLibrary . GunQiContractLibrary ( );
            model.MZ001 = "";
            
            query.StartPosition = FormStartPosition.CenterScreen;
            query.PassDataBetweenForm += new SelectAll.GunQiContractAll.PassDataBetweenFormHandler( query_PassDataBetweenForm );
            query.ShowDialog( );
            if ( model.MZ001 != null && model.MZ001 != "" )
                autoQuery( );
            else
                MessageBox.Show( "您没有选择任何内容" );
        }
        private void query_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            model.MZ001 = e.ConOne;
            if ( e.ConTwo == "执行" )
                label45.Visible = true;
            else
                label45.Visible = false;
        }
        void autoQuery ( )
        {
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;

            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableFalse( pageList );
            sign = "2";
            queryContent( );
            if ( label45.Visible == true )
                button13.Enabled = true;
        }
        void queryContent ( )
        {
            model = bll.GetModel( model.MZ001 );
            if ( model == null )
                return;
            button11_Click( null ,null );
            textBox1.Text = model.MZ002;
            textBox2.Text = model.MZ003;
            textBox3.Text = model.MZ004;
            textBox4.Text = model.MZ005;
            textBox10.Text = model.MZ006.ToString( );
            if ( model . MZ007 > DateTime . MinValue && model . MZ007 < DateTime . MaxValue )
                dateTimePicker1 . Value = model . MZ007;
            else
                dateTimePicker1 . Value = DateTime . Now;
            if ( model.MZ008 > DateTime.MinValue && model.MZ008 < DateTime.MaxValue )
                dateTimePicker2.Value = model.MZ008;
            else
                dateTimePicker2 . Value = DateTime . Now;
            textBox12 .Text = model.MZ031;
            textBox5.Text = model.MZ009;
            if ( model.MZ010 > DateTime.MinValue && model.MZ010 < DateTime.MaxValue )
                dateTimePicker3.Value = model.MZ010;
            else
                dateTimePicker3 . Value = DateTime . Now;
            textBox6 .Text = model.MZ011;
            if ( model.MZ012 > DateTime.MinValue && model.MZ012 < DateTime.MaxValue )
                dateTimePicker4.Value = model.MZ012;
            else
                dateTimePicker4 . Value = DateTime . Now;
            textBox7 .Text = model.MZ013;
            comboBox6.Text = model.MZ014;
            if ( model.MZ015 > DateTime.MinValue && model.MZ015 < DateTime.MaxValue )
                dateTimePicker5.Value = model.MZ015;
            else
                dateTimePicker5 . Value = DateTime . Now;
            textBox9 .Text = model.MZ029;
            textBox27.Text = model.MZ033;
            textBox28.Text = model.MZ034;
            checkBox36.Checked = model.MZ035.Trim( ) == "T" ? true : false;
            checkBox37.Checked = model.MZ036.Trim( ) == "T" ? true : false;
            checkBox38.Checked = model.MZ037.Trim( ) == "T" ? true : false;
            checkBox39.Checked = model.MZ038.Trim( ) == "T" ? true : false;
            checkBox40.Checked = model.MZ039.Trim( ) == "T" ? true : false;
            comboBox16.Text = model.MZ040;
            if ( model.MZ041 > DateTime.MinValue && model.MZ041 < DateTime.MaxValue )
                dateTimePicker7.Value = model.MZ041;
            else
                dateTimePicker7 . Value = DateTime . Now;
            comboBox17 .Text = model.MZ042;
            if ( model.MZ043 > DateTime.MinValue && model.MZ043 < DateTime.MaxValue )
                dateTimePicker6.Value = model.MZ043;
            else
                dateTimePicker6 . Value = DateTime . Now;
            checkBox4 .Checked = model.MZ044.Trim( ) == "T" ? true : false;
            checkBox7.Checked = model.MZ045.Trim( ) == "T" ? true : false;
            checkBox5.Checked = model.MZ046.Trim( ) == "T" ? true : false;
            checkBox6.Checked = model.MZ047.Trim( ) == "T" ? true : false;
            checkBox1.Checked = model.MZ048.Trim( ) == "T" ? true : false;
            checkBox2.Checked = model.MZ049.Trim( ) == "T" ? true : false;
            checkBox3.Checked = model.MZ050.Trim( ) == "T" ? true : false;
            checkBox8.Checked = model.MZ051.Trim( ) == "T" ? true : false;
            checkBox9.Checked = model.MZ052.Trim( ) == "T" ? true : false;
            checkBox10.Checked = model.MZ053.Trim( ) == "T" ? true : false;
            checkBox41.Checked = model.MZ054.Trim( ) == "T" ? true : false;
            textBox24.Text = model.MZ055;
            textBox26.Text = model.MZ056;
            radioButton1.Checked = model.MZ057.Trim( ) == "T1" ? true : false;
            radioButton2.Checked = model.MZ057.Trim( ) == "T2" ? true : false;
            radioButton3.Checked = model.MZ058.Trim( ) == "T1" ? true : false;
            radioButton4.Checked = model.MZ058.Trim( ) == "T2" ? true : false;
            radioButton6.Checked = model.MZ059.Trim( ) == "T1" ? true : false;
            radioButton5.Checked = model.MZ059.Trim( ) == "T2" ? true : false;
            textBox25.Text = model.MZ060;
            textBox18.Text = model.MZ061;
            if ( model.MZ062 > DateTime.MinValue && model.MZ062 < DateTime.MaxValue )
                dateTimePicker9.Value = model.MZ062;
            else
                dateTimePicker9 . Value = DateTime . Now;
            checkBox11 .Checked = model.MZ063.Trim( ) == "T" ? true : false;
            checkBox12.Checked = model.MZ064.Trim( ) == "T" ? true : false;
            checkBox13.Checked = model.MZ065.Trim( ) == "T" ? true : false;
            checkBox18.Checked = model.MZ066.Trim( ) == "T" ? true : false;
            checkBox20.Checked = model.MZ067.Trim( ) == "T" ? true : false;
            checkBox19.Checked = model.MZ068.Trim( ) == "T" ? true : false;
            checkBox15.Checked = model.MZ069.Trim( ) == "T" ? true : false;
            checkBox14.Checked = model.MZ070.Trim( ) == "T" ? true : false;
            checkBox17.Checked = model.MZ071.Trim( ) == "T" ? true : false;
            checkBox21.Checked = model.MZ072.Trim( ) == "T" ? true : false;
            checkBox22.Checked = model.MZ073.Trim( ) == "T" ? true : false;
            checkBox23.Checked = model.MZ074.Trim( ) == "T" ? true : false;
            checkBox24.Checked = model.MZ075.Trim( ) == "T" ? true : false;
            checkBox25.Checked = model.MZ076.Trim( ) == "T" ? true : false;
            checkBox26.Checked = model.MZ077.Trim( ) == "T" ? true : false;
            checkBox27.Checked = model.MZ078.Trim( ) == "T" ? true : false;
            checkBox28.Checked = model.MZ079.Trim( ) == "T" ? true : false;
            checkBox29.Checked = model.MZ080.Trim( ) == "T" ? true : false;
            checkBox30.Checked = model.MZ081.Trim( ) == "T" ? true : false;
            checkBox35.Checked = model.MZ082.Trim( ) == "T" ? true : false;
            checkBox32.Checked = model.MZ083.Trim( ) == "T" ? true : false;
            checkBox31.Checked = model.MZ084.Trim( ) == "T" ? true : false;
            checkBox34.Checked = model.MZ085.Trim( ) == "T" ? true : false;
            checkBox33.Checked = model.MZ086.Trim( ) == "T" ? true : false;
            textBox30.Text = model.MZ087;
            textBox31.Text = model.MZ088;
            comboBox19.Text = model.MZ089;
            if ( model.MZ090 > DateTime.MinValue && model.MZ090 < DateTime.MaxValue )
                dateTimePicker8.Value = model.MZ090;
            else
                dateTimePicker8 . Value = DateTime . Now;
            textBox33 .Text = model.MZ091.ToString( );
            radioButton7.Checked = model.MZ092.Trim( ) == "T1" ? true : false;
            radioButton8.Checked = model.MZ092.Trim( ) == "T2" ? true : false;
            radioButton9.Checked = model.MZ092.Trim( ) == "T3" ? true : false;
            comboBox5.Text = model.MZ093;
            if ( model.MZ094 > DateTime.MinValue && model.MZ094 < DateTime.MaxValue )
                dateTimePicker10.Value = model.MZ094;
            else
                dateTimePicker10 . Value = DateTime . Now;
            textBox36 .Text = model.MZ095.ToString( );
            textBox37.Text = model.MZ096.ToString( );
            textBox38.Text = model.MZ097.ToString( );
            textBox41.Text = model.MZ098.ToString( );
            textBox40.Text = model.MZ099.ToString( );
            textBox39.Text = model.MZ100.ToString( );
            textBox44.Text = model.MZ101.ToString( );
            textBox43.Text = model.MZ102.ToString( );
            textBox42.Text = model.MZ103.ToString( );
            textBox35.Text = model.MZ104;
            textBox11.Text = model.MZ109;
            textBox47.Text = model.MZ110;
            textBox46.Text = model.MZ111;
            textBox45.Text = model.MZ112;
            textBox15.Text = model.MZ113;
            textBox14.Text = model.MZ114;
            lookUpEdit2.Text = model.MZ115;
            if ( !string . IsNullOrEmpty ( model . MZ123 ) )
                checkBox16 . Checked = model . MZ123 . Trim ( ) == "T" ? true : false;
            else
                checkBox16 . Checked = false;
            if ( model.MZ108 != null )
            {
                DataTable da = bll.GetDataTableOfGy( model.MZ108 );
                if ( da != null && da.Rows.Count > 0 )
                {
                    textBox11.Text = da.Rows[0]["DGA003"].ToString( );
                    textBox47.Text = da.Rows[0]["DGA017"].ToString( );
                    textBox46.Text = da.Rows[0]["DGA008"].ToString( );
                    textBox45.Text = da.Rows[0]["DGA012"].ToString( );
                    textBox15.Text = da.Rows[0]["DGA009"].ToString( );
                    textBox14.Text = da.Rows[0]["DGA011"].ToString( );
                }
            }
        }
        private void button12_Click ( object sender ,EventArgs e )
        {
            R_FrmTPADGA tpadga = new R_FrmTPADGA( );
            DataTable dp = bll.GetDataTableP( );
            tpadga.gridControl2.DataSource = dp;
            tpadga.st = "2";
            tpadga.Text = "R_344 供应商查询";
            tpadga.PassDataBetweenForm += new R_FrmTPADGA.PassDataBetweenFomrHandler( tpadga_PassDataBetweenForm );
            tpadga.StartPosition = FormStartPosition.CenterScreen;
            tpadga.ShowDialog( );
        }
        private void tpadga_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            model.MZ108 = e.ConOne;
            textBox11.Text = e.ConTwo;
            textBox46.Text = e.ConTre;
            textBox15.Text = e.ConFor;
            textBox14.Text = e.ConFiv;
            textBox45.Text = e.ConSix;
            textBox47.Text = e.ConSev;
        }
        #endregion

    }
}

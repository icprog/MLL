using Mulaolao.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using FastReport;
using FastReport.Export.Xml;
using StudentMgr;

namespace Mulaolao.Contract
{
    public partial class R_FrmContractToDoAJob : FormChild
    {
        public R_FrmContractToDoAJob ( )
        {
            InitializeComponent( );
            
            Logins . tableNum = "R_199";
            Logins . tableName = this . Text;
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        MulaolaoLibrary.ContractToDoAJobLibrary _model = new MulaolaoLibrary.ContractToDoAJobLibrary( );
        MulaolaoBll.Bll.ContractToDoAJobBll _bll = new MulaolaoBll.Bll.ContractToDoAJobBll( );
        List<SplitContainer> spList = new List<SplitContainer>( );
        SpecialPowers sp = new SpecialPowers( );Report report = new Report( );DataSet RDataSet = new DataSet( );
        List<TabPage> pageList = new List<TabPage>( );
        bool result = false;
        string sign = "", file = "", strWhere = "", stateOfOdd = "";
        DataTable tableQuery, contract;

        private void R_FrmContractToDoAJob_Load ( object sender ,EventArgs e )
        {
            Power( this );

            spList.Clear( );
            spList.AddRange( new SplitContainer[] { splitContainer1 ,splitContainer2 } );
            pageList.Clear( );
            pageList.AddRange( new TabPage[] { tabPageOne ,tabPageTwo ,tabPageTre ,tabPageFor } );
            Ergodic.SpliClear( spList );
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableClear( pageList );
            Ergodic.TablePageEnableFalse( pageList );

            label45.Visible = label46.Visible = false;

            lookUpEdit2.Properties.DataSource = _bll.GetDataTableWork( );
            lookUpEdit2.Properties.DisplayMember = "DAA002";
            lookUpEdit2.Properties.ValueMember = "DAA001";

            contract = _bll.GetDataTableSalesman( );
            lookUpEdit1.Properties.DataSource = contract;
            lookUpEdit1.Properties.DisplayMember = "DBA002";
            lookUpEdit1.Properties.ValueMember = "DBA001";

            if ( Logins.number == "MLL-0001" || Logins.number == "MLL-0007" || Logins.number == "MLL-0008" )
                checkBox18.Visible = true;
            else
                checkBox18.Visible = false;

            DataTable dl = _bll.GetDataTableOfB( );
            comboBox8.DataSource = dl.DefaultView.ToTable( true ,"BA044" );
            comboBox8.DisplayMember = "BA044";
            comboBox9.DataSource = dl.DefaultView.ToTable( true ,"BA045" );
            comboBox9.DisplayMember = "BA045";
            comboBox10.DataSource = dl.DefaultView.ToTable( true ,"BA046" );
            comboBox10.DisplayMember = "BA046";
            comboBox11.DataSource = dl.DefaultView.ToTable( true ,"BA047" );
            comboBox11.DisplayMember = "BA047";
            comboBox12.DataSource = dl.DefaultView.ToTable( true ,"BA048" );
            comboBox12.DisplayMember = "BA048";

            if ( Logins.number == "MLL-0001" )
                checkBox17.Visible = true;
            else
                checkBox17.Visible = false;
        }
        
        private void R_FrmContractToDoAJob_Shown ( object sender ,EventArgs e )
        {
            _model.BA003 = Merges.oddNum;
            if ( !string.IsNullOrEmpty( _model.BA003 ) )
                autoQuery( );
            Merges.oddNum = "";
        }

        #region Print
        void createRDataSet ( )
        {
            DataTable print = _bll.GetDataTablePrint( _model.BA003 );
            DataTable prints = _bll.GetDataTablePrints( _model.BA003 );
            print.TableName = "R_PQBA";
            prints.TableName = "R_PQBAS";
            RDataSet.Tables.Clear( );
            RDataSet.Tables.AddRange( new DataTable[] { print ,prints } );
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
            textBox3.Enabled = false;
            label45.Visible = label46.Visible = false;
            sign = "1";
            _model.BA003 = oddNumbers.purchaseContract( "SELECT MAX(AJ022) AJ022 FROM R_PQAJ" ,"AJ022" ,"R_199-" );
            gridControl1.DataSource = null;
            toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;           
        }
        protected override void delete ( )
        {
            base.delete( );

            if ( Logins.number == "MLL-0001" )
                dele( );
            else
            {
                if ( label45.Visible == true )
                    MessageBox.Show( "此单已执行,需要总经理删除" );
                else
                    dele( );
            }
        }
        void dele ( )
        {
            stateOfOdd = "";
            if ( label45.Visible == true )
                stateOfOdd = "维护删除";
            else
            {
                if ( sign == "1" )
                    stateOfOdd = "新增删除";
                else
                    stateOfOdd = "更改删除";
            }

            result = _bll.DeleteAll( _model.BA003 ,"R_199" ,"委外加工合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"删除" ,stateOfOdd );
            if ( result == true )
            {
                MessageBox.Show( "成功删除数据" );
                Ergodic.SpliClear( spList );
                Ergodic.SpliEnableFalse( spList );
                Ergodic.TablePageEnableClear( pageList );
                Ergodic.TablePageEnableFalse( pageList );
                gridControl1.DataSource = null;

                label45.Visible = label46.Visible = false;
                sign = "";
                toolAdd.Enabled = toolSelect.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
            }
            else
                MessageBox.Show( "删除数据失败" );
        }
        protected override void update ( )
        {
            base.update( );

            if ( label45.Visible == true )
                MessageBox.Show( "此单已执行,请维护" );
            else
            {
                Ergodic.SpliEnableTrue( spList );
                Ergodic.TablePageEnableTrue( pageList );

                sign = "2";
                toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
                textBox3.Enabled = false;
            }
        }
        protected override void revirw ( )
        {
            base.revirw( );

            bool over = false;
            if ( !string.IsNullOrEmpty( textBox26.Text ) )
                over = true;
            else
                over = false;
            Reviews( "BA003" ,_model.BA003 ,"R_PQBA" ,this ,"" ,"R_199" ,false ,over,null/*,"" ,"" ,"" ,"" ,"" ,"" ,"","R_196"*/ );
            over = false;
            over = sp.reviewImple( "R_199" ,_model.BA003 );
            if ( over == true )
            {
                label45.Visible = true;
                try
                {
                    SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfCopy( "R_PQBAC" ,"R_PQBA" ,"BA003" ,_model.BA003 ) );
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
            receiva = _bll.GetDataTableOfRecevable( _model.BA003 );
            if ( receiva != null && receiva.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < receiva.Rows.Count ; i++ )
                {
                    modelAm.AM002 = receiva.Rows[i]["BA001"].ToString( );
                    modelAm.AM108 = modelAm.AM110 = modelAm.AM111 = modelAm.AM115 = 0M;
                    modelAm.AM108 = string.IsNullOrEmpty( receiva.Compute( "sum(BA)" ,"BA001='" + modelAm.AM002 + "' and BA058= 'F' AND BA056='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(BA)" ,"BA001='" + modelAm.AM002 + "' and BA058= 'F'  AND BA056='F'" ) );
                    modelAm.AM111 = string.IsNullOrEmpty( receiva.Compute( "sum(BA)" ,"BA001='" + modelAm.AM002 + "' and BA058= 'T' AND BA056='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(BA)" ,"BA001='" + modelAm.AM002 + "' and BA058= 'T' AND BA056='F'" ) );
                    modelAm.AM110 = string.IsNullOrEmpty( receiva.Compute( "sum(BA)" ,"BA001='" + modelAm.AM002 + "' and BA058= 'F' AND BA056='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(BA)" ,"BA001='" + modelAm.AM002 + "' and BA058= 'F' AND BA056='T'" ) );
                    modelAm.AM115 = string.IsNullOrEmpty( receiva.Compute( "sum(BA)" ,"BA001='" + modelAm.AM002 + "' and BA058= 'T' AND BA056='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(BA)" ,"BA001='" + modelAm.AM002 + "' and BA058= 'T' AND BA056='T'" ) );
                    _bll.UpdateOfRecevable( modelAm ,_model.BA003 );
                }
            }
        }
        protected override void print ( )
        {
            base.print( );

            if ( label45.Visible == true )
            {
                MulaolaoBll . ContractAddPrintTime . addTimeToContract ( "R_PQBA" ,"BA061" ,_model . BA003 ,"BA003" );

                file = "";
                file = System.Windows.Forms.Application.StartupPath;
                createRDataSet( );
                report.Load( file + "\\R_199.frx" );
                report.RegisterData( RDataSet );
                report.Show( );
            }
            else
                MessageBox.Show( "非执行单据不能打印" );
        }
        protected override void export ( )
        {
            base.export( );

            file = "";
            file = System.Windows.Forms.Application.StartupPath;

            createRDataSet( );
            report.Load( file + "\\R_199.frx" );
            report.RegisterData( RDataSet );
            report.Prepare( );
            XMLExport exprots = new XMLExport( );
            exprots.Export( report );
        }
        protected override void save ( )
        {
            base.save( );

            if ( string.IsNullOrEmpty( comboBox8.Text ) )
            {
                MessageBox.Show( "乙方不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox2.Text ) )
            {
                MessageBox.Show( "合同批号不可为空" );
                return;
            }
            assignMent( );
            DataTable da = _bll.GetDataTableOfAll( _model.BA003 );
            if ( sign == "3" )
            {
                if ( string.IsNullOrEmpty( textBox3.Text ) )
                {
                    MessageBox.Show( "请填写维护意见" );
                    return;
                }
                stateOfOdd = "维护保存";
                if ( da != null && da.Rows.Count > 0 )
                    _model.BA050 = da.Rows[0]["BA050"].ToString( ) + "[" + Logins.username + MulaolaoBll . Drity . GetDt ( ).ToString( "yyyyMMdd" ) + "]";
                else
                {
                    MessageBox.Show( "此单记录不存在,请重新查询" );
                    return;
                }
                saveOfAll( );
            }
            else
            {
                if ( sign == "1" )
                    stateOfOdd = "新增保存";
                else if(sign=="2")
                    stateOfOdd = "更改保存";
                _model.BA050 = "";
                if ( da != null && da.Rows.Count > 0 )
                {
                    if ( sign == "4" )
                    {
                        stateOfOdd = "复制保存";
                        for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                        {
                            if ( da.Select( "BA001='" + gridView1.GetDataRow( i )["BA001"].ToString( ) + "'" ).Length > 0 )
                            {
                                if ( Logins.number == "MLL-0001" )
                                {
                                    saveOfAll( );
                                    break;
                                }
                                else
                                {
                                    MessageBox.Show( "此单为超补,需要总经理处理" );
                                    break;
                                }
                            }
                            else if ( i == gridView1.RowCount - 1 )
                            {
                                saveOfAll( );
                                break;
                            }
                        }
                    }
                    else
                        saveOfAll( );
                }
                else
                    saveState( );
            }
        }
        void assignMent ( )
        {
            _model.BA004 = textBox2.Text;
            _model.BA005 = textBox4.Text;
            _model.BA015 = checkBox1.Checked == true ? "T" : "F";
            _model.BA016 = checkBox2.Checked == true ? "T" : "F";
            _model.BA017 = checkBox3.Checked == true ? "T" : "F";
            _model.BA018 = checkBox4.Checked == true ? "T" : "F";
            _model.BA019 = string.IsNullOrEmpty( textBox20.Text ) == true ? 0 : Convert.ToInt32( textBox20.Text );
            _model.BA020 = checkBox5.Checked == true ? "T" : "F";
            _model.BA021 = checkBox6.Checked == true ? "T" : "F";
            _model.BA022 = checkBox7.Checked == true ? "T" : "F";
            _model.BA023 = checkBox8.Checked == true ? "T" : "F";
            _model.BA024 = checkBox9.Checked == true ? "T" : "F";
            _model.BA025 = checkBox10.Checked == true ? "T" : "F";
            _model.BA026 = checkBox11.Checked == true ? "T" : "F";
            _model.BA027 = checkBox12.Checked == true ? "T" : "F";
            _model.BA028 = checkBox13.Checked == true ? "T" : "F";
            _model.BA029 = checkBox14.Checked == true ? "T" : "F";
            _model.BA030 = checkBox15.Checked == true ? "T" : "F";
            _model.BA031 = checkBox16.Checked == true ? "T" : "F";
            _model.BA032 = textBox23.Text;
            _model.BA033 = dateTimePicker2.Value;
            _model.BA034 = textBox26.Text;
            _model.BA035 = dateTimePicker3.Value;
            _model.BA036 = textBox28.Text;
            _model.BA037 = dateTimePicker4.Value;
            _model.BA038 = textBox30.Text;
            _model.BA039 = dateTimePicker5.Value;
            _model.BA040 = textBox32.Text;
            _model.BA041 = dateTimePicker6.Value;
            _model.BA042 = textBox34.Text;
            _model.BA043 = dateTimePicker7.Value;
            _model.BA044 = comboBox8.Text;
            _model.BA045 = comboBox9.Text;
            _model.BA046 = comboBox10.Text;
            _model.BA047 = comboBox11.Text;
            _model.BA048 = comboBox12.Text;
            _model.BA049 = textBox3.Text;
            _model.BA051 = textBox10.Text;
            _model.BA052 = textBox9.Text;
            _model.BA053 = textBox11.Text;
            _model.BA054 = string.IsNullOrEmpty( textBox13.Text ) == true ? 0 : Convert.ToInt32( textBox13.Text );
            _model.BA056 = checkBox17.Checked == true ? "T" : "F";
            _model.BA057 = lookUpEdit2.Text;
            _model.BA058= checkBox18.Checked == true ? "T" : "F";
        }
        void saveState ( )
        {
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableFalse( pageList );

            toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;
            label46.Visible = false;
        }
        void saveOfAll ( )
        {
            stateOfOdd = "";
            if ( label45.Visible == true )
                stateOfOdd = "维护保存";
            else
            {
                if ( sign == "1" )
                    stateOfOdd = "新增保存";
                else
                    stateOfOdd = "更改保存";
            }

            result = _bll.Update( _model ,"R_199" ,"委外加工合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"保存" ,stateOfOdd );
            if ( result == true )
            {
                MessageBox.Show( "保存数据成功" );
                if ( sign == "3" )
                {
                    try
                    {
                        SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfCopy( "R_PQBAC" ,"R_PQBA" ,"BA003" ,_model.BA003 ) );
                        WriteOfReceivablesTo( );
                    }
                    catch { }
                }
                saveState( );
            }
            else
                MessageBox.Show( "保存数据失败" );
        }
        protected override void cancel ( )
        {
            base.cancel( );

            if ( (sign == "1" || sign=="4") && sign != "3" )
            {
                Ergodic.SpliClear( spList );
                Ergodic.SpliEnableFalse( spList );
                Ergodic.TablePageEnableClear( pageList );
                Ergodic.TablePageEnableFalse( pageList );

                label45.Visible = label46.Visible = false;
                sign = "";
                gridControl1.DataSource = null;

                toolSelect.Enabled = toolAdd.Enabled = true;
                toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolPrint.Enabled = toolExport.Enabled = false;

                try
                {
                    _bll.DeleteAll( _model.BA003 ,"R_199" ,"委外加工合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"取消" ,"新增取消" );
                }
                catch { }
            }
            else if(sign=="2" || sign=="3")
            {
                Ergodic.SpliEnableFalse( spList );
                Ergodic.TablePageEnableFalse( pageList );
                toolSelect.Enabled = toolAdd.Enabled = toolcopy.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolPrint.Enabled = toolExport.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = false;
                label9.Visible =  false;
            }
        }
        protected override void maintain ( )
        {
            base.maintain( );

            if ( label45.Visible == true )
            {
                Ergodic.SpliEnableTrue( spList );
                Ergodic.TablePageEnableTrue( pageList );

                sign = "3";
                toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
            }
            else
                MessageBox.Show( "非执行单据,请更改" );
        }
        protected override void copys ( )
        {
            base.copys( );
            
            stateOfOdd = "";
            if ( label45.Visible == true )
                stateOfOdd = "维护复制";
            else
            {
                if ( sign == "1" )
                    stateOfOdd = "新增复制";
                else
                    stateOfOdd = "更改复制";
            }
            result = _bll.Copy( _model.BA003 ,"R_199" ,"委外加工合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"复制" ,stateOfOdd );
            if ( result == false )
                MessageBox.Show( "复制失败,请重试" );
            else
            {
                stateOfOdd = "更改复制单号";
                _model.BA003 = oddNumbers.purchaseContract( "SELECT MAX(AJ022) AJ022 FROM R_PQAJ" ,"AJ022" ,"R_199-" );
                result = _bll.UpdateOfCopy( _model.BA003 ,"R_199" ,"委外加工合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"复制" ,stateOfOdd );
                if ( result == false )
                {
                    MessageBox.Show( "复制失败,请重试" );
                    _bll.DeleteOfCopy( );
                }
                else
                {
                    MessageBox.Show( "成功复制此表" );

                    Ergodic.SpliEnableTrue( spList );
                    Ergodic.TablePageEnableTrue( pageList );

                    sign = "4";
                    toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
                    toolSave.Enabled = toolCancel.Enabled = true;
                    label46.Visible = true;
                    label45.Visible = false;
                    queryContent( );
                }
            }
        }
        #endregion

        #region Event
        string num = "";
        private void gridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.RowCount - 1 )
            {
                _model.IDX = string.IsNullOrEmpty( gridView1.GetFocusedRowCellValue( "idx" ).ToString( ) ) == true ? 0 : Convert.ToInt32( gridView1.GetFocusedRowCellValue( "idx" ).ToString( ) );
                assign( );
            }
        }
        void assign ( )
        {
            _model = _bll.GetModel( _model.IDX );
            if ( _model == null )
                return;
            textBox1.Text = _model.BA001;
            textBox12.Text = _model.BA006;
            textBox14.Text = _model.BA007;
            textBox8.Text = _model.BA008;
            textBox5.Text = _model.BA009.ToString( );
            textBox6.Text = _model.BA059.ToString( );
            textBox10.Text = _model.BA051;
            textBox9.Text = _model.BA052;
            textBox11.Text = _model.BA053;
            textBox13.Text = _model.BA054.ToString( );
            textBox16.Text = _model.BA010.ToString( );
            textBox15.Text = _model.BA011.ToString( );
            textBox17.Text = _model.BA012.ToString( );
            textBox18.Text = _model.BA013.ToString( );
            textBox19.Text = _model.BA060.ToString( );
            if ( _model.BA014 > DateTime.MinValue && _model.BA014 < DateTime.MaxValue )
                dateTimePicker1.Value = _model.BA014;
            textBox6.Text = _model.BA059.ToString( );
            num = textBox1.Text;
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
            if ( textBox18.Text != "" && !DateDayRegise.eightTwoNumber( textBox18 ) )
            {
                textBox18.Text = "";
                MessageBox.Show( "只允许输入整数部分最多六位,小数部分最多两位,如999999.99,请重新输入" );
            }
        }
        private void comboBox8_TextChanged ( object sender ,EventArgs e )
        {
            if ( !string.IsNullOrEmpty( comboBox8.Text ) )
            {
                DataTable de = _bll.GetDataTableOfB( comboBox8.Text );
                if ( de != null && de.Rows.Count > 0 )
                {
                    comboBox9.Text = de.Rows[0]["BA045"].ToString( );
                    comboBox10.Text = de.Rows[0]["BA046"].ToString( );
                    comboBox11.Text = de.Rows[0]["BA047"].ToString( );
                    comboBox12.Text = de.Rows[0]["BA048"].ToString( );
                }
            }
        }
        private void textBox11_TextChanged ( object sender ,EventArgs e )
        {
            if ( !string.IsNullOrEmpty( textBox11.Text ) )
            {
                DataTable dl = _bll.GetDataTableOfNum( textBox11.Text ,_model.BA003 );
                if ( dl != null && dl.Rows.Count > 0 )
                {
                    textBox16.Text = dl.Rows[0]["BA011"].ToString( );
                    textBox17.Text = dl.Rows[0]["BA013"].ToString( );
                }
                else
                    textBox16.Text = textBox17.Text = 0.ToString( );
            }
            else
                textBox16.Text = textBox17.Text = 0.ToString( );
        }
        private void textBox1_TextChanged ( object sender ,EventArgs e )
        {
           
        }
        private void button4_Click ( object sender ,EventArgs e )
        {
            if ( textBox23.Text == "" )
            {
                textBox23.Text = Logins.username;
                _model.BA032 = textBox23.Text;

                string[] str = new string[2];
                str = oddNumbers.contractBatch( "R_PQBA" ,_model.BA032 ,textBox23 ,textBox2 ,"BA004" );
                if ( str[0] == "" )
                    textBox23.Text = "";
                else
                    _model.BA004 = str[1];
                textBox2.Text = str[1];
            }
            else if ( textBox23.Text != "" && textBox23.Text == Logins.username )
            {
                textBox23.Text = "";
                _model.BA032 = "";
                _model.BA004 = "";
                textBox2.Text = "";
            }
            dateTimePicker2.Value = MulaolaoBll . Drity . GetDt ( );
        }
        private void button7_Click ( object sender ,EventArgs e )
        {
            if ( textBox34.Text == "" )
                textBox34.Text = Logins.username;
            else if ( textBox34.Text != "" && textBox34.Text == Logins.username )
                textBox34.Text = "";
            dateTimePicker7 . Value = DateTime . Now;
        }
        private void button8_Click ( object sender ,EventArgs e )
        {
            if ( textBox26.Text == "" )
                textBox26.Text = Logins.username;
            else if ( textBox26.Text != "" && textBox26.Text == Logins.username )
                textBox26.Text = "";
            dateTimePicker3 . Value = DateTime . Now;
        }
        private void button9_Click ( object sender ,EventArgs e )
        {
            if ( textBox28.Text == "" )
                textBox28.Text = Logins.username;
            else if ( textBox28.Text != "" && textBox28.Text == Logins.username )
                textBox28.Text = "";
            dateTimePicker4 . Value = DateTime . Now;
        }
        private void button10_Click ( object sender ,EventArgs e )
        {
            if ( textBox30.Text == "" )
                textBox30.Text = Logins.username;
            else if ( textBox30.Text != "" && textBox30.Text == Logins.username )
                textBox30.Text = "";
            dateTimePicker5 . Value = DateTime . Now;
        }
        private void button11_Click ( object sender ,EventArgs e )
        {
            if ( textBox32.Text == "" )
                textBox32.Text = Logins.username;
            else if ( textBox32.Text != "" && textBox32.Text == Logins.username )
                textBox32.Text = "";
            dateTimePicker6 . Value = DateTime . Now;
        }
        private void lookUpEdit1_EditValueChanged ( object sender ,EventArgs e )
        {
            if ( lookUpEdit1.EditValue != null )
            {
                _model.BA002 = lookUpEdit1.EditValue.ToString( );
                if ( contract != null && contract.Rows.Count > 0 && contract.Select( "DBA001='" + _model.BA002 + "'" ).Length > 0 )
                {
                    textBox7.Text = contract.Select( "DBA001='" + _model.BA002 + "'" )[0]["DBA028"].ToString( );
                }
            }
        }
        private void textBox19_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox19 );
        }
        private void textBox19_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox19 );
        }
        private void textBox19_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox19.Text != "" && !DateDayRegise.sixTwoNumber( textBox19 ) )
            {
                textBox19.Text = "";
                MessageBox.Show( "只允许输入整数部分最多四位,小数部分最多两位,如9999.99,请重新输入" );
            }
        }
        #endregion

        #region Table
        void variable ( )
        {
            _model.BA001 = textBox1.Text;
            _model.BA006 = textBox12.Text;
            _model.BA007 = textBox14.Text;
            _model.BA008 = textBox8.Text;
            _model.BA009 = string.IsNullOrEmpty( textBox5.Text ) == true ? 0M : Convert.ToDecimal( textBox5.Text );
            _model.BA010 = string.IsNullOrEmpty( textBox16.Text ) == true ? 0M : Convert.ToDecimal( textBox16.Text );
            _model.BA011 = string.IsNullOrEmpty( textBox15.Text ) == true ? 0M : Convert.ToDecimal( textBox15.Text );
            _model.BA012 = string.IsNullOrEmpty( textBox17.Text ) == true ? 0M : Convert.ToDecimal( textBox17.Text );
            _model.BA013 = string.IsNullOrEmpty( textBox18.Text ) == true ? 0M : Convert.ToDecimal( textBox18.Text );
            _model.BA014 = dateTimePicker1.Value;
            _model.BA051 = textBox10.Text;
            _model.BA052 = textBox9.Text;
            _model.BA053 = textBox11.Text;
            _model.BA054 = string.IsNullOrEmpty( textBox13.Text ) == true ? 0 : Convert.ToInt32( textBox13.Text );
            _model.BA059 = string.IsNullOrEmpty( textBox6.Text ) == true ? 0M : Convert.ToDecimal( textBox6.Text );
            _model.BA060 = string.IsNullOrEmpty( textBox19.Text ) == true ? 0 : Convert.ToDecimal( textBox19.Text );
        }
        //Add
        private void button1_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox1.Text ) )
            {
                MessageBox.Show( "流水号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox10.Text ) )
            {
                MessageBox.Show( "产品名称不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox13.Text ) )
            {
                MessageBox.Show( "产品数量不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox18.Text ) )
            {
                MessageBox.Show( "现含税外价不可为空" );
                return;
            }
            variable( );
            result = _bll.Exists( _model.BA001 );
            if ( result == true )
            {
                if ( Logins.number == "MLL-0001" )
                    addOfOne( );
                else
                {
                    MessageBox.Show( "此单为超补,需要总经理处理" );
                    return;
                }
            }
            addOfOne( );
        }
        void addOfOne ( )
        {
            stateOfOdd = "";
            if ( label45.Visible == true )
                stateOfOdd = "维护新建";
            else
            {
                if ( sign == "1" )
                    stateOfOdd = "新增新建";
                else
                    stateOfOdd = "更改新建";
            }
            result = _bll.Add( _model ,"R_199" ,"委外加工合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,_model.BA003 ,"新建" ,stateOfOdd );
            if ( result==true )
            {
                MessageBox.Show( "录入数据成功" );
                button6_Click( null ,null );
            }
            else
                MessageBox.Show( "录入数据失败" );
        }
        //Edit
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox1.Text ) )
            {
                MessageBox.Show( "流水号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox10.Text ) )
            {
                MessageBox.Show( "产品名称不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox13.Text ) )
            {
                MessageBox.Show( "产品数量不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox18.Text ) )
            {
                MessageBox.Show( "现含税外价不可为空" );
                return;
            }
            variable( );
            if ( num == _model.BA001 )
                edit( );
            else
            {
                result = _bll.Exists( _model.BA001 );
                if ( result == true )
                {
                    if ( Logins.number == "MLL-0001" )
                        edit( );
                    else
                    {
                        MessageBox.Show( "此单为超补,需要总经理处理" );
                        return;
                    }
                }
                else
                    edit( );
            }
        }
        void edit ( )
        {
            stateOfOdd = "";
            if ( label45.Visible == true )
                stateOfOdd = "维护编辑";
            else
            {
                if ( sign == "1" )
                    stateOfOdd = "新增编辑";
                else
                    stateOfOdd = "更改编辑";
            }
            result = _bll.UpdateOfOne( _model ,"R_199" ,"委外加工合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,_model.BA003 ,"编辑" ,stateOfOdd );
            if ( result == true )
            {
                MessageBox.Show( "成功编辑数据" );
                button6_Click( null ,null );
            }
            else
                MessageBox.Show( "编辑数据失败" );
        }
        //Delete
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) ==

            DialogResult . Cancel )
                return;

            stateOfOdd = "";
            if ( label45.Visible == true )
                stateOfOdd = "维护删除";
            else
            {
                if ( sign == "1" )
                    stateOfOdd = "新增删除";
                else
                    stateOfOdd = "更改删除";
            }
            result = _bll.DeleteOfOne( _model.IDX ,"R_199" ,"委外加工合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,_model.BA003 ,"删除" ,stateOfOdd );
            if ( result == true )
            {
                MessageBox.Show( "成功删除数据" );
                button6_Click( null ,null );
            }
            else
                MessageBox.Show( "删除数据失败" );
        }
        //Refresh
        private void button6_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( string.IsNullOrEmpty( strWhere ) )
                strWhere = "1=1";
            strWhere = strWhere + " AND BA003='" + _model.BA003 + "'";
            tableQuery = _bll.GetDataTable( strWhere );
            gridControl1.DataSource = tableQuery;
        }
        #endregion

        #region Query
        SelectAll.ContracToDoAJobAll query = new SelectAll.ContracToDoAJobAll( );
        protected override void select ( )
        {
            base.select( );

            _model = new MulaolaoLibrary.ContractToDoAJobLibrary( );
            
            query.PassDataBetweenForm += new SelectAll.ContracToDoAJobAll.PassDataBetweenFormHandler( query_PassDataBetweenForm );
            query.StartPosition = FormStartPosition.CenterScreen;
            query.ShowDialog( );

            if ( _model.BA003 != null )
                autoQuery( );
        }
        private void query_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            _model.BA003 = e.ConOne;
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
        }
        void queryContent ( )
        {
            _model = _bll.GetModel( _model.BA003 );
            if ( _model == null )
                return;
            if ( contract != null && contract.Rows.Count > 0 )
            {
                if ( contract.Select( "DBA001='"+_model.BA002+"'" ).Length > 0 )
                {
                    lookUpEdit1.Text = contract.Select( "DBA001='" + _model.BA002 + "'" )[0]["DBA002"].ToString( );
                }
            }
            textBox2.Text = _model.BA004;
            textBox4.Text = _model.BA005;
            checkBox1.Checked = _model.BA015.Trim( ) == "T" ? true : false;
            checkBox2.Checked = _model.BA016.Trim( ) == "T" ? true : false;
            checkBox3.Checked = _model.BA017.Trim( ) == "T" ? true : false;
            checkBox4.Checked = _model.BA018.Trim( ) == "T" ? true : false;
            textBox20.Text = _model.BA019.ToString( );
            checkBox5.Checked = _model.BA020.Trim( ) == "T" ? true : false;
            checkBox6.Checked = _model.BA021.Trim( ) == "T" ? true : false;
            checkBox7.Checked = _model.BA022.Trim( ) == "T" ? true : false;
            checkBox8.Checked = _model.BA023.Trim( ) == "T" ? true : false;
            checkBox9.Checked = _model.BA024.Trim( ) == "T" ? true : false;
            checkBox10.Checked = _model.BA025.Trim( ) == "T" ? true : false;
            checkBox11.Checked = _model.BA026.Trim( ) == "T" ? true : false;
            checkBox12.Checked = _model.BA027.Trim( ) == "T" ? true : false;
            checkBox13.Checked = _model.BA028.Trim( ) == "T" ? true : false;
            checkBox14.Checked = _model.BA029.Trim( ) == "T" ? true : false;
            checkBox15.Checked = _model.BA030.Trim( ) == "T" ? true : false;
            checkBox16.Checked = _model.BA031.Trim( ) == "T" ? true : false;
            textBox23.Text = _model.BA032;
            if ( _model . BA033 > DateTime . MinValue && _model . BA033 < DateTime . MaxValue )
                dateTimePicker2 . Value = _model . BA033;
            else
                dateTimePicker2 . Value = DateTime . Now;
            textBox26.Text = _model.BA034;
            if ( _model.BA035 > DateTime.MinValue && _model.BA035 < DateTime.MaxValue )
                dateTimePicker3.Value = _model.BA035;
            else
                dateTimePicker3 . Value = DateTime . Now;
            textBox28 .Text = _model.BA036;
            if ( _model.BA037 > DateTime.MinValue && _model.BA037 < DateTime.MaxValue )
                dateTimePicker4.Value = _model.BA037;
            else
                dateTimePicker4 . Value = DateTime . Now;
            textBox30 .Text = _model.BA038;
            if ( _model.BA039 > DateTime.MinValue && _model.BA039 < DateTime.MaxValue )
                dateTimePicker5.Value = _model.BA039;
            else
                dateTimePicker5 . Value = DateTime . Now;
            textBox32 .Text = _model.BA040;
            if ( _model.BA041 > DateTime.MinValue && _model.BA041 < DateTime.MaxValue )
                dateTimePicker6.Value = _model.BA041;
            else
                dateTimePicker6 . Value = DateTime . Now;
            textBox34 .Text = _model.BA042;
            if ( _model.BA043 > DateTime.MinValue && _model.BA043 < DateTime.MaxValue )
                _model.BA043 = dateTimePicker7.Value;
            else
                dateTimePicker7 . Value = DateTime . Now;
            comboBox8 .Text = _model.BA044;
            comboBox9.Text = _model.BA045;
            comboBox10.Text = _model.BA046;
            comboBox11.Text = _model.BA047;
            comboBox12.Text = _model.BA048;
            textBox3.Text = _model.BA049;
            textBox10.Text = _model.BA051;
            textBox9.Text = _model.BA052;
            textBox11.Text = _model.BA053;
            checkBox17.Checked = _model.BA056.Trim( ) == "T" ? true : false;
            lookUpEdit2.Text = _model.BA057;
            checkBox18.Checked = _model.BA058.Trim( ) == "T" ? true : false;
            button6_Click( null ,null );
        }
        private void button5_Click ( object sender ,EventArgs e )
        {
            SelectAll.ContractToDoAJobNumAll numQuery = new SelectAll.ContractToDoAJobNumAll( );
            numQuery.PassDataBetweenForm += new SelectAll.ContractToDoAJobNumAll.PassDataBetweenFormHandler( numQuery_PassDataBetweenFrom );
            numQuery.StartPosition = FormStartPosition.CenterScreen;
            numQuery.ShowDialog( );
        }
        private void numQuery_PassDataBetweenFrom ( object sender ,PassDataWinFormEventArgs e )
        {
            textBox1.Text = e.ConOne;
            textBox9.Text = e.ConTwo;
            textBox11.Text = e.ConTre;
            textBox10.Text = e.ConFor;
            textBox8.Text = e.ConFiv;
            textBox13.Text = e.ConSix;
            textBox15.Text = e.ConSev;
            textBox5.Text = e.ConEgi;
            textBox6.Text = e.ConNin;
        }
        #endregion

    }
}

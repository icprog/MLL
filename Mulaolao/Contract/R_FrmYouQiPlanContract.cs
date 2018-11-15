using Mulaolao . Bom;
using Mulaolao . Class;
using Mulaolao . Other;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;
using FastReport;
using FastReport . Export . Xml;
using StudentMgr;

namespace Mulaolao . Contract
{
    public partial class R_FrmYouQiPlanContract : FormChild
    {
        public R_FrmYouQiPlanContract ( )
        {
            InitializeComponent( );
            
            Logins . tableNum = "R_337";
            Logins . tableName = this . Text;

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        MulaolaoLibrary.YouQiLibrary _model = new MulaolaoLibrary.YouQiLibrary( );
        MulaolaoBll.Bll.YouQicontractBll _bll = new MulaolaoBll.Bll.YouQicontractBll( );
        Youqicaigou yq = new Youqicaigou( ); SpecialPowers sp = new SpecialPowers( );
        List<SplitContainer> spList = new List<SplitContainer>( ); List<TabPage> pageList = new List<TabPage>( );
        Factory fc = new Factory( );Report report = new Report( );
        DataTable name, tableQuery; DataRow row;DataSet RDataSet;
        string sign = "", copy = "", weihu = "", strWhere = "", procedure = "", color = "", colorName = "", file = "", brand = "", stateOfOdd = "";
        bool result = false;
        
        private void R_FrmYouQiPlanContract_Load ( object sender ,EventArgs e )
        {
            Power( this );
            spList.Clear( );
            spList.AddRange( new SplitContainer[] { splitContainer1 ,splitContainer2 } );
            pageList.Clear( );
            pageList.AddRange( new TabPage[] { tabPageFor ,tabPageTre ,tabPageTwo } );
            Ergodic.TablePageEnableFalse( pageList );
            Ergodic.FormEverySpliEnableFalse( this );
            gridControl1.DataSource = null;
            Ergodic.SpliEnableFalse( spList );
            label36.Visible = label24.Visible = false;
            dateTimePicker2.Enabled = dateTimePicker4.Enabled = false;
            textBox12.Enabled = false;
            Ergodic.SpliClear( spList );

            name = _bll.GetDataTableProson( );
            lookUpEdit1.Properties.DataSource = name;
            lookUpEdit1.Properties.DisplayMember = "DBA002";
            lookUpEdit1.Properties.ValueMember = "DBA001";

            comboBox1.Items.Clear( );
            comboBox1.Items.AddRange( new string[] { "水帘机喷涂" ,"静电喷涂" ,"浸漆" ,"封边" ,"涂布" ,"滚漆" ,"化学品辅料" } );
        }
        
        private void R_FrmYouQiPlanContract_Shown ( object sender ,EventArgs e )
        {
            _model.YQ99 = Merges.oddNum;
            if ( !string.IsNullOrEmpty( _model.YQ99 ) )
                autoQuery( );
            Merges.oddNum = "";
        }

        #region Print
        void createPrint ( )
        {
            RDataSet = new DataSet( );
            DataTable print = _bll.GetDataTablePrintOther( _model.YQ99 );
            DataTable prints = _bll.GetDataTablePrintsOther( _model.YQ99 );
            print.TableName = "R_PQI";
            prints.TableName = "R_PQIS";
            RDataSet.Tables.AddRange( new DataTable[] { print ,prints } );
        }
        #endregion
        
        #region Main
        protected override void add ( )
        {
            base.add( );

            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled =toolLibrary.Enabled=toolStorage.Enabled= false;
            toolSave.Enabled = toolCancel.Enabled = true;
            Ergodic.TablePageEnableTrue( pageList );
            Ergodic.SpliEnableTrue( spList );
            Ergodic.SpliClear( spList );
            Ergodic.TablePageEnableClear( pageList );
            gridControl1.DataSource = null;
            textBox12.Enabled = false;
            dateTimePicker2.Enabled = dateTimePicker4.Enabled = false;
            sign = "1";
            label24.Visible = label36.Visible = false;
            _model.YQ99 = oddNumbers.purchaseContract( "SELECT MAX(AJ020) AJ020 FROM R_PQAJ" ,"AJ020" ,"R_337-" );
        }
        protected override void delete ( )
        {
            base.delete( );

            if ( label24.Visible == true )
            {
                if ( Logins.number == "MLL-0001" )
                    dele( );
                else
                    MessageBox.Show( "单号:" + _model.YQ99 + "的单据状态为执行,不允许删除" );
            }
            else
                dele( );
        }
        void dele ( )
        {
            if ( label24.Visible == true )
                stateOfOdd = "维护删除";
            else
            {
                if ( sign == "1" )
                    stateOfOdd = "新增删除";
                else
                    stateOfOdd = "更改删除";
            }
            result = _bll.DeleteOddNum( _model.YQ99 ,"R_337" ,"库存油漆（墨）等采购合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"删除" ,stateOfOdd );
            if ( result == false )
                MessageBox.Show( "删除数据失败" );
            else
            {
                MessageBox.Show( "成功删除数据" );
                Ergodic.TablePageEnableFalse( pageList );
                Ergodic.SpliEnableFalse( spList );
                gridControl1.DataSource = null;
                Ergodic.SpliClear( spList );
                Ergodic.TablePageEnableClear( pageList );

                toolSelect.Enabled = toolAdd.Enabled = toolPrint.Enabled = toolExport.Enabled = true;
                toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled =toolStorage.Enabled=toolLibrary.Enabled= false;

                textBox12.Enabled = false;
                label36.Visible = false;
                label24.Visible = false;
                tableQuery = null;
                try
                {
                    _bll.DeleteReview( _model.YQ99 ,"R_337" );
                    _bll.EditOfSign( _model.YQ99 );
                }
                catch { }
            }
        }
        protected override void update ( )
        {
            base.update( );

            if ( label24.Visible == true )
                MessageBox.Show( "单号:" + _model.YQ99 + "的单据状态为执行,不允许更改" );
            else
            {
                Ergodic.SpliEnableTrue( spList );
                Ergodic.TablePageEnableTrue( pageList );

                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled =toolLibrary.Enabled=toolStorage.Enabled= false;
                toolSave.Enabled = toolCancel.Enabled = true;
                sign = "2";
                textBox12.Enabled = false;
                dateTimePicker2.Enabled = dateTimePicker4.Enabled = false;
            }
        }
        protected override void revirw ( )
        {
            base.revirw( );
            bool result = false, over = false;
            if ( textBox48.Text == "廖灵飞" )
                result = true;
            else
                result = false;
            if ( string.IsNullOrEmpty( textBox13.Text ) )
                over = false;
            else
                over = true;
            Reviews( "YQ99" ,_model.YQ99 ,"R_PQI" ,this ,_model.YQ03 ,"R_337" ,result ,over,null/*,"YQ07" ,"YQ96" ,"R_PQI" ,"YQ99" ,YQ99 ,ord ,textBox49.Text,"R_339" */);
            result = false;
            result = sp.reviewImple( "R_337" ,_model.YQ99 );
            if ( result == true )
            {
                label24.Visible = true;
                try
                {
                    SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfCopy( "R_PQIC" ,"R_PQI" ,"YQ99" ,_model.YQ99 ) );
                }
                catch { }
            }  
            else
                label24.Visible = false;
        }
        void addes ( )
        {
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolMaintain.Enabled =toolLibrary.Enabled=toolStorage.Enabled= true;
            toolSave.Enabled = toolCancel.Enabled = false;

            textBox12.Enabled = false;
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableFalse( pageList );
            copy = "";
            sign = "";
            weihu = "";
            label36.Visible = false;
        }
        void updates ( )
        {
            result = _bll.UpdatePlan( _model ,"R_337" ,"库存油漆（墨）等采购合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"保存" ,stateOfOdd );
            if ( result == false )
                MessageBox.Show( "录入数据失败" );
            else
            {
                MessageBox.Show( "成功录入数据" );
                if ( weihu == "1" )
                {
                    try
                    {
                        SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfCopy( "R_PQIC" ,"R_PQI" ,"YQ99" ,_model.YQ99 ) );
                    }
                    catch { }
                }
                addes( );
            }
        }
        void vari ( )
        {
            if ( !string.IsNullOrEmpty( lookUpEdit1.Text ) )
                _model.YQ01 = lookUpEdit1.EditValue.ToString( );
            else
                _model.YQ01 = "";
            _model.YQ04 = textBox17.Text;
            _model.YQ07 = textBox13.Text;
            _model.YQ08 = dateTimePicker2.Value;
            _model.YQ09 = textBox16.Text;
            _model.YQ17 = dateTimePicker3.Value;
            _model.YQ18 = dateTimePicker4.Value;
            _model.YQ22 = checkBox36.Checked == true ? "T" : "F";
            _model.YQ23 = checkBox37.Checked == true ? "T" : "F";
            _model.YQ24 = checkBox38.Checked == true ? "T" : "F";
            _model.YQ25 = checkBox39.Checked == true ? "T" : "F";
            _model.YQ26 = checkBox40.Checked == true ? "T" : "F";
            _model.YQ27 = comboBox16.Text;
            _model.YQ28 = dateTimePicker5.Value;
            _model.YQ29 = comboBox17.Text;
            _model.YQ30 = dateTimePicker6.Value;
            _model.YQ31 = textBox26.Text;
            _model.YQ32 = checkBox4.Checked == true ? "T" : "F";
            _model.YQ33 = checkBox7.Checked == true ? "T" : "F";
            _model.YQ34 = checkBox5.Checked == true ? "T" : "F";
            _model.YQ35 = checkBox6.Checked == true ? "T" : "F";
            if ( radioButton1.Checked )
                _model.YQ36 = "在内";
            else if ( radioButton2.Checked )
                _model.YQ36 = "不在内";
            else
                _model.YQ36 = string.Empty;
            if ( radioButton3.Checked )
                _model.YQ37 = "有";
            else if ( radioButton4.Checked )
                _model.YQ37 = "没有";
            else
                _model.YQ37 = string.Empty;
            if ( radioButton6.Checked )
            {
                _model.YQ38 = "已检测";
                _model.YQ39 = textBox24.Text;
            }
            else if ( radioButton5.Checked )
            {
                _model.YQ38 = "未检测";
                _model.YQ39 = string.Empty;
            }
            else
            {
                _model.YQ38 = string.Empty;
                _model.YQ39 = string.Empty;
            }
            _model.YQ40 = checkBox1.Checked == true ? "T" : "F";
            _model.YQ41 = checkBox2.Checked == true ? "T" : "F";
            _model.YQ42 = checkBox3.Checked == true ? "T" : "F";
            _model.YQ43 = checkBox8.Checked == true ? "T" : "F";
            _model.YQ44 = checkBox10.Checked == true ? "T" : "F";
            _model.YQ45 = checkBox9.Checked == true ? "T" : "F";
            _model.YQ46 = comboBox18.Text;
            _model.YQ47 = dateTimePicker7.Value;
            _model.YQ48 = comboBox19.Text;
            _model.YQ49 = dateTimePicker8.Value;
            _model.YQ50 = textBox31.Text;
            _model.YQ51 = textBox30.Text;
            _model.YQ52 = checkBox11.Checked == true ? "T" : "F";
            _model.YQ53 = checkBox12.Checked == true ? "T" : "F";
            _model.YQ54 = checkBox13.Checked == true ? "T" : "F";
            _model.YQ55 = textBox1.Text;
            _model.YQ56 = checkBox18.Checked == true ? "T" : "F";
            _model.YQ57 = checkBox20.Checked == true ? "T" : "F";
            _model.YQ58 = checkBox19.Checked == true ? "T" : "F";
            _model.YQ59 = checkBox21.Checked == true ? "T" : "F";
            _model.YQ60 = checkBox15.Checked == true ? "T" + "," + textBox29.Text : "F";
            _model.YQ61 = checkBox14.Checked == true ? "T" : "F";
            _model.YQ62 = checkBox17.Checked == true ? "T" : "F";
            _model.YQ63 = checkBox25.Checked == true ? "T" : "F";
            _model.YQ64 = checkBox22.Checked == true ? "T" : "F";
            _model.YQ65 = checkBox23.Checked == true ? "T" : "F";
            _model.YQ66 = checkBox24.Checked == true ? "T" : "F";
            _model.YQ67 = checkBox29.Checked == true ? "T" : "F";
            _model.YQ68 = checkBox26.Checked == true ? "T" : "F";
            _model.YQ69 = checkBox27.Checked == true ? "T" : "F";
            _model.YQ70 = checkBox28.Checked == true ? "T" : "F";
            _model.YQ71 = checkBox33.Checked == true ? "T" : "F";
            _model.YQ72 = checkBox35.Checked == true ? "T" : "F";
            _model.YQ73 = checkBox32.Checked == true ? "T" : "F";
            _model.YQ74 = checkBox31.Checked == true ? "T" : "F";
            _model.YQ75 = checkBox34.Checked == true ? "T" : "F";
            _model.YQ76 = checkBox30.Checked == true ? "T" : "F";
            _model.YQ77 = string.IsNullOrEmpty( textBox33.Text ) == true ? 0 : Convert.ToInt64( textBox33.Text );
            _model.YQ78 = comboBox5.Text;
            _model.YQ79 = dateTimePicker9.Value;
            if ( radioButton7.Checked )
            {
                _model.YQ80 = "合格";
                _model.YQ81 = string.Empty;
            }
            else if ( radioButton8.Checked )
            {
                _model.YQ80 = "退货";
                _model.YQ81 = string.Empty;
            }
            else if ( radioButton9.Checked )
            {
                _model.YQ80 = "条件接收";
                _model.YQ81 = textBox35.Text;
            }
            else
            {
                _model.YQ80 = string.Empty;
                _model.YQ81 = string.Empty;
            }
            _model.YQ82 = string.IsNullOrEmpty( textBox36.Text ) == true ? 0 : Convert.ToInt64( textBox36.Text );
            _model.YQ83 = string.IsNullOrEmpty( textBox37.Text ) == true ? 0 : Convert.ToInt64( textBox37.Text );
            _model.YQ84 = string.IsNullOrEmpty( textBox38.Text ) == true ? 0 : Convert.ToInt64( textBox38.Text );
            _model.YQ85 = string.IsNullOrEmpty( textBox41.Text ) == true ? 0 : Convert.ToInt64( textBox41.Text );
            _model.YQ86 = string.IsNullOrEmpty( textBox40.Text ) == true ? 0 : Convert.ToInt64( textBox40.Text );
            _model.YQ87 = string.IsNullOrEmpty( textBox39.Text ) == true ? 0 : Convert.ToInt64( textBox39.Text );
            _model.YQ88 = string.IsNullOrEmpty( textBox44.Text ) == true ? 0 : Convert.ToInt64( textBox44.Text );
            _model.YQ89 = string.IsNullOrEmpty( textBox43.Text ) == true ? 0 : Convert.ToInt64( textBox43.Text );
            _model.YQ90 = string.IsNullOrEmpty( textBox42.Text ) == true ? 0 : Convert.ToInt64( textBox42.Text );
            _model.YQ91 = textBox45.Text;
            _model.YQ92 = textBox46.Text;
            _model.YQ93 = dateTimePicker10.Value;
            _model.YQ94 = textBox47.Text;
            _model.YQ95 = dateTimePicker11.Value;
            _model.YQ96 = textBox48.Text;
            _model.YQ97 = dateTimePicker12.Value;
            _model.YQ98 = dateTimePicker13.Value;
            _model.YQ102 = checkBox41.Checked == true ? "T" : "F";
            _model.YQ103 = textBox12.Text;
            _model.YQ110 = dateTimePicker1.Value;
            _model.YQ111 = string.Empty;
        }
        protected override void save ( )
        {
            base.save( );

            if ( string.IsNullOrEmpty( textBox16.Text ) )
            {
                MessageBox.Show( "合同批号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox2.Text ) )
            {
                MessageBox.Show( "供应商不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( lookUpEdit1.Text ) )
            {
                MessageBox.Show( "请选择采购人" );
                return;
            }
            if ( _model.YQ02 == null || _model.YQ02 == "" )
            {
                MessageBox.Show( "请选择供应商" );
                return;
            }
            vari( );
            DataTable daw = _bll.GetDataTableMain( _model.YQ99 );

            if ( weihu == "1" )
            {
                if ( string.IsNullOrEmpty( textBox12.Text ) )
                    MessageBox.Show( "请填写维护意见" );
                else
                {
                    stateOfOdd = "维护保存";
                    _model.YQ104 = daw.Rows[0]["YQ104"].ToString( ) + "[" + Logins.username + MulaolaoBll . Drity . GetDt ( ).ToString( "yyyyMMdd" ) + "]";
                    updates( );
                }
            }
            else
            {
                if ( sign == "1" )
                    stateOfOdd = "新增保存";
                else
                    stateOfOdd = "更改保存";
                if ( dateTimePicker3.Value < MulaolaoBll . Drity . GetDt ( ).AddDays( 5 ) )
                {
                    MessageBox.Show( "约定供期必须在当天的基础上延迟5天" );
                    return;
                }
                _model.YQ104 = string.Empty;
                if ( daw.Rows.Count < 1 )
                    addes( );
                else
                {
                    if ( copy == "1" )
                    {
                        stateOfOdd = "复制保存";
                        // AND YQ04=@YQ04  ,new SqlParameter( "@YQ04" ,YQ04 )
                        DataTable dyu = _bll.GetDataTableCopy( _model.YQ99 );
                        if ( dyu.Rows.Count < 1 )
                            updates( );
                        else
                        {
                            for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                            {
                                if ( dyu.Select( "YQ119='" + gridView1.GetDataRow( i )["YQ119"].ToString( ) + "' AND YQ11='" + gridView1.GetDataRow( i )["YQ11"].ToString( ) + "' AND YQ12='" + gridView1.GetDataRow( i )["YQ12"].ToString( ) + "'" ).Length > 0 )
                                {
                                    if ( _model.YQ09.Length >= 8 && _model.YQ09.Substring( 0 ,8 ) == "MLL-0001" )
                                    {
                                        updates( );
                                        break;
                                    }
                                    else
                                    {
                                        //\n\r开合同人:" + YQ04 + "
                                        MessageBox.Show( "已经存在\n\r工艺:" + gridView1.GetDataRow( i )["YQ10"].ToString( ) + "\n\r工序:" + gridView1.GetDataRow( i )["YQ11"].ToString( ) + "\n\r色号:" + gridView1.GetDataRow( i )["YQ12"].ToString( ) + "\n\r的记录,请核实后再录入" );
                                        break;
                                    }
                                }
                                else
                                {
                                    updates( );
                                    break;
                                }
                            }

                        }
                    }
                    else
                        updates( );
                }
            }
        }
        protected override void cancel ( )
        {
            base.cancel( );

            if ( sign == "1" && weihu != "1" || copy == "1" )
            {
                Ergodic.TablePageEnableFalse( pageList );
                Ergodic.SpliEnableFalse( spList );
                gridControl1.DataSource = null;
                Ergodic.SpliClear( spList );
                Ergodic.TablePageEnableClear( pageList );

                toolSelect.Enabled = toolAdd.Enabled = toolExport.Enabled = toolPrint.Enabled = true;
                toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled =toolStorage.Enabled=toolLibrary.Enabled= false;

                label36.Visible = false;
                label24.Visible = false;
                tableQuery = null;
                try
                {
                    _bll.DeleteOddNum( _model.YQ99 ,"R_337" ,"库存油漆（墨）等采购合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"取消" ,"新增取消" );
                }
                catch { }
            }
            else if ( sign == "2" || weihu == "1" )
            {
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolMaintain.Enabled =toolLibrary.Enabled=toolStorage.Enabled= true;
                toolSave.Enabled = toolCancel.Enabled = false;
                Ergodic.SpliEnableFalse( spList );
                Ergodic.TablePageEnableFalse( pageList );
            }
            textBox12.Enabled = false;
        }
        protected override void maintain ( )
        {
            base.maintain( );

            if ( label24.Visible == true )
            {
                Ergodic.SpliEnableTrue( spList );
                Ergodic.TablePageEnableTrue( pageList );

                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled =toolStorage.Enabled=toolLibrary.Enabled= false;
                toolSave.Enabled = toolCancel.Enabled = true;

                textBox12.Enabled = true;

                weihu = "1";
                dateTimePicker2.Enabled = dateTimePicker4.Enabled = false;
                label24.Visible = true;
            }
            else
                MessageBox.Show( "此单据没有被执行,只需更改即可,无需维护" );
        }
        protected override void storage ( )
        {
            base.storage( );

            if ( label24.Visible == true )
            {
                //if ( Logins.number == "MLL-0001" )
                //{
                for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                {
                    result = fc . Storage ( gridView1 . GetDataRow ( i ) [ "YQ06" ] . ToString ( ) ,gridView1 . GetDataRow ( i ) [ "YQ119" ] . ToString ( ) ,"" ,gridView1 . GetDataRow ( i ) [ "YQ11" ] . ToString ( ) ,gridView1 . GetDataRow ( i ) [ "YQ12" ] . ToString ( ) ,gridView1 . GetDataRow ( i ) [ "YQ06" ] . ToString ( )/*+ gridView1.GetDataRow( i )["YQ119"].ToString( )*/ ,"" ,"" ,gridView1 . GetDataRow ( i ) [ "YQ15" ] . ToString ( ) ,gridView1 . GetDataRow ( i ) [ "YQ109" ] . ToString ( ) ,textBox17 . Text ,dateTimePicker2 . Value ,lookUpEdit1 . Text ,MulaolaoBll . Drity . GetDt ( ) ,_model . YQ99 ,"" ,gridView1 . GetDataRow ( i ) [ "YQ126" ] . ToString ( ) ,string . Empty ,textBox2 . Text ,textBox10 . Text );
                    if ( result == false )
                    {
                        MessageBox.Show( "入库失败" );
                        break;
                    }
                    else if ( i == gridView1.RowCount - 1 )
                    {
                        MessageBox.Show( "入库成功" );
                        //try
                        //{
                        for ( int k = 0 ; k < gridView1 . RowCount ; k++ )
                        {
                            _model . IDX = string . IsNullOrEmpty ( gridView1 . GetDataRow ( k ) [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( gridView1 . GetDataRow ( k ) [ "idx" ] . ToString ( ) );
                            _model . YQ125 = 0;
                            _model . YQ126 = string . IsNullOrEmpty ( gridView1 . GetDataRow ( k ) [ "YQ126" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( gridView1 . GetDataRow ( k ) [ "YQ126" ] . ToString ( ) );
                            _bll . UpdateStr ( _model );
                        }
                        _bll . editSigns ( _model . YQ99 );
                        //    }
                        //}
                        //catch { }
                    }
                }
                //}
                //else
                //    MessageBox.Show( "须总经理入库" );
            }
            else
                MessageBox.Show( "非执行单据不能入库" );
        }
        protected override void copys ( )
        {
            base.copys( );

            if ( label24.Visible == true )
                stateOfOdd = "维护复制";
            else
            {
                if ( sign == "1" )
                    stateOfOdd = "新增复制";
                else
                    stateOfOdd = "更改复制";
            }

            result = _bll.Copy( _model.YQ99 ,"R_337" ,"库存油漆（墨）等采购合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"复制" ,stateOfOdd );
            if ( result == false )
                MessageBox.Show( "复制失败,请重试" );
            else
            {
                _model.YQ99 = oddNumbers.purchaseContract( "SELECT MAX(AJ020) AJ020 FROM R_PQAJ" ,"AJ020" ,"R_337-" );
                stateOfOdd = "更改复制单号";
                result = _bll.UpdateCo( _model.YQ99 ,"R_337" ,"库存油漆（墨）等采购合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"复制" ,stateOfOdd );
                if ( result == false )
                {
                    MessageBox.Show( "复制失败,请重试" );
                    _bll.DeleteCopy( );
                }
                else
                {
                    MessageBox.Show( "成功复制此表" );
                    Ergodic.TablePageEnableTrue( pageList );
                    gridControl1.DataSource = null;
                    Ergodic.SpliEnableTrue( spList );
                    Ergodic.TablePageEnableClear( pageList );
                    Ergodic.SpliClear( spList );
                    toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolReview.Enabled = toolcopy.Enabled =toolLibrary.Enabled=toolStorage.Enabled= false;
                    toolSave.Enabled = toolCancel.Enabled = true;
                    textBox12.Enabled = false;
                    dateTimePicker2.Enabled = dateTimePicker4.Enabled = false;
                    sign = "2";
                    copy = "1";
                    weihu = "";
                    label24.Visible = false;
                    queryContent( );
                }
            }
        }
        protected override void print ( )
        {
            base.print( );

            if ( label24.Visible == true )
            {
                MulaolaoBll . ContractAddPrintTime . addTimeToContract ( "R_PQI" ,"YQ136" ,_model . YQ99 ,"YQ99" );

                file = "";
                file = Application.StartupPath;
                createPrint( );
                report.Load( file + "\\R_337.frx" );
                report.RegisterData( RDataSet );
                report.Show( );
            }
            else
                MessageBox.Show( "非执行单据不能打印" );
        }
        protected override void export ( )
        {
            base.export( );

            createPrint( );
            file = "";
            file = System.Windows.Forms.Application.StartupPath;
            report.Load( file + "\\R_345.frx" );
            report.RegisterData( RDataSet );
            report.Prepare( );
            XMLExport exprots = new XMLExport( );
            exprots.Export( report );
        }
        #endregion

        #region Event
        private void comboBox1_TextChanged ( object sender ,EventArgs e )
        {
            comboBox2.DataSource = _bll.GetDataTableColorName( );
            comboBox2.DisplayMember = "YQ12";
        }
        private void lookUpEdit1_EditValueChanged ( object sender ,EventArgs e )
        {
            if ( lookUpEdit1.EditValue != null && name.Select( "DBA001='" + lookUpEdit1.EditValue.ToString( ) + "'" ).Length > 0 )
                textBox5.Text = name.Select( "DBA001='" + lookUpEdit1.EditValue.ToString( ) + "'" )[0]["DBA028"].ToString( );
        }
        private void textBox33_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox36_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox37_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox38_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox41_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox40_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox39_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox44_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox43_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox42_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox3_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise . fractionTb ( e ,textBox3 );
        }
        private void textBox3_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise . textChangeTb ( textBox3 );
        }
        private void textBox3_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox3 . Text != "" && !DateDayRegise .sevenOne ( textBox3 ) )
            {
                this . textBox3 . Text = "";
                MessageBox . Show ( "只允许输入整数部分最多六位,小数部分最多一位,如999999.9,请重新输入" );
            }
        }
        private void button7_Click ( object sender ,EventArgs e )
        {
            if ( textBox17.Text == "" )
            {
                textBox17.Text = Logins.username;
                _model.YQ04 = textBox17.Text;
                string[] str = new string[2];
                str = oddNumbers.contractBatch( "R_PQI" ,_model.YQ04 ,textBox17 ,textBox16 ,"YQ09" );
                if ( str[0] == "" )
                    textBox17.Text = "";
                else
                    _model.YQ09 = str[1];
                textBox16.Text = str[1];
            }
            else if ( textBox17.Text != "" && textBox17.Text == Logins.username )
            {
                textBox17.Text = "";
                textBox16.Text = "";
                _model.YQ09 = "";
                textBox16.Text = "";
            }

            if ( textBox45.Text == "" )
                textBox45.Text = Logins.username;
            else if ( textBox45.Text != "" && textBox45.Text == Logins.username )
                textBox45.Text = "";
        }
        private void button8_Click ( object sender ,EventArgs e )
        {
            if ( textBox13.Text == "" )
                textBox13.Text = Logins.username;
            else if ( textBox13.Text != "" && textBox13.Text == Logins.username )
                textBox13.Text = "";

            dateTimePicker2 . Value = DateTime . Now;
        }
        private void button10_Click ( object sender ,EventArgs e )
        {
            if ( textBox46.Text == "" )
                textBox46.Text = Logins.username;
            else if ( textBox46.Text != "" && textBox46.Text == Logins.username )
                textBox46.Text = "";

            dateTimePicker10 . Value = DateTime . Now;
        }
        private void button11_Click ( object sender ,EventArgs e )
        {
            if ( textBox47.Text == "" )
                textBox47.Text = Logins.username;
            else if ( textBox47.Text != "" && textBox47.Text == Logins.username )
                textBox47.Text = "";

            dateTimePicker11 . Value = DateTime . Now;
        }
        private void button12_Click ( object sender ,EventArgs e )
        {
            if ( textBox48.Text == "" )
                textBox48.Text = Logins.username;
            else if ( textBox48.Text != "" && textBox48.Text == Logins.username )
                textBox48.Text = "";

            dateTimePicker12 . Value = DateTime . Now;
        }
        private void gridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.RowCount - 1 )
            {
                _model.IDX = string.IsNullOrEmpty( gridView1.GetFocusedRowCellValue( "idx" ).ToString( ) ) == true ? 0 : Convert.ToInt32( gridView1.GetFocusedRowCellValue( "idx" ).ToString( ) );
                assignMent( );
            }
        }
        void assignMent ( )
        {
            _model = _bll.GetModel( _model.IDX );
            if ( _model == null )
                return;
            textBox27.Text = _model.YQ06;
            textBox32.Text = _model.YQ11;
            comboBox2.Text = _model.YQ12;
            textBox59.Text = _model.YQ15.ToString( );
            textBox3 . Text = _model . YQ109 . ToString ( );
            comboBox1.Text = _model.YQ119;
            textBox4.Text = _model.YQ10;
            textBox11.Text = _model.YQ117;
            textBox14 . Text = _model . YQ100;
            brand = textBox27.Text;
            procedure = comboBox1.Text;
            color = textBox32.Text;
            colorName = comboBox2.Text;
        }
        #endregion

        #region Query
        private void button4_Click ( object sender ,EventArgs e )
        {
            R_FrmTPADGA tpadga = new R_FrmTPADGA( );
            DataTable did = _bll.GetDataTableSupplier( );
            if ( did.Rows.Count < 1 )
                MessageBox.Show( "没有供应商信息" );
            else
            {
                tpadga.gridControl2.DataSource = did;
                tpadga.st = "2";
                tpadga.Text = "R_339 信息查询";
                tpadga.PassDataBetweenForm += new R_FrmTPADGA.PassDataBetweenFomrHandler( tpadga_PassDataBetweenForm );
                tpadga.StartPosition = FormStartPosition.CenterScreen;
                tpadga.ShowDialog( );
            }
        }
        private void tpadga_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            _model.YQ02 = e.ConOne;
            textBox2.Text = e.ConTwo;
            textBox7.Text = e.ConSev;
            textBox8.Text = e.ConTre;
            textBox9.Text = e.ConSix;
            textBox10.Text = e.ConFor;
            textBox6.Text = e.ConFiv;
        }
        string r519ben = "";
        private void button17_Click ( object sender ,EventArgs e )
        {
            R_FrmR_519select se = new R_FrmR_519select( );
           
            if ( string.IsNullOrEmpty( comboBox1.Text ) )
                MessageBox.Show( "请选择工艺" );
            else
            {
                se.chose = "2";
                DataTable r519;
                if ( comboBox1.Text .Equals( "水帘机喷涂") )
                {
                    r519 = _bll.GetDataTablePqabcdekz( "R_PQA" );
                    if ( r519.Rows.Count < 1 )
                        MessageBox.Show( "没有水帘机喷涂数据" );
                    else
                    {
                        se.zhi = "1";
                        r519ben = "1";
                        se.PassDataBetweenForm += new R_FrmR_519select.PassDataBetweenFormHandler( se_PassDataBetweenForm );
                        se.StartPosition = FormStartPosition.CenterScreen;
                        se.ShowDialog( );
                    }
                }
                else if ( comboBox1.Text .Equals( "静电喷涂") )
                {
                    r519 = _bll.GetDataTablePqabcdekz( "R_PQD" );
                    if ( r519.Rows.Count < 1 )
                        MessageBox.Show( "没有静电喷涂数据" );
                    else
                    {
                        se.zhi = "2";
                        r519ben = "2";
                        se.PassDataBetweenForm += new R_FrmR_519select.PassDataBetweenFormHandler( se_PassDataBetweenForm );
                        se.StartPosition = FormStartPosition.CenterScreen;
                        se.ShowDialog( );
                    }
                }
                else if ( comboBox1.Text .Equals( "浸漆") )
                {
                    r519 = _bll.GetDataTablePqabcdekz( "R_PQE" );
                    if ( r519.Rows.Count < 1 )
                        MessageBox.Show( "没有浸漆数据" );
                    else
                    {
                        se.zhi = "3";
                        r519ben = "3";
                        se.PassDataBetweenForm += new R_FrmR_519select.PassDataBetweenFormHandler( se_PassDataBetweenForm );
                        se.StartPosition = FormStartPosition.CenterScreen;
                        se.ShowDialog( );
                    }
                }
                else if ( comboBox1.Text .Equals( "封边") )
                {
                    r519 = _bll.GetDataTablePqabcdekz( "R_PQB" );
                    if ( r519.Rows.Count < 1 )
                        MessageBox.Show( "没有封边数据" );
                    else
                    {
                        se.zhi = "4";
                        r519ben = "4";
                        se.PassDataBetweenForm += new R_FrmR_519select.PassDataBetweenFormHandler( se_PassDataBetweenForm );
                        se.StartPosition = FormStartPosition.CenterScreen;
                        se.ShowDialog( );
                    }
                }
                else if ( comboBox1.Text .Equals( "涂布") )
                {
                    r519 = _bll.GetDataTablePqabcdekz( "R_PQC" );
                    if ( r519.Rows.Count < 1 )
                        MessageBox.Show( "没有涂布数据" );
                    else
                    {
                        se.zhi = "5";
                        r519ben = "5";
                        se.PassDataBetweenForm += new R_FrmR_519select.PassDataBetweenFormHandler( se_PassDataBetweenForm );
                        se.StartPosition = FormStartPosition.CenterScreen;
                        se.ShowDialog( );
                    }
                }
                else if ( comboBox1.Text .Equals( "滚漆") )
                {
                    r519 = _bll.GetDataTablePqabcdekz( "R_PQKZ" );
                    if ( r519.Rows.Count < 1 )
                        MessageBox.Show( "没有滚漆数据" );
                    else
                    {
                        se.zhi = "8";
                        r519ben = "6";
                        se.PassDataBetweenForm += new R_FrmR_519select.PassDataBetweenFormHandler( se_PassDataBetweenForm );
                        se.StartPosition = FormStartPosition.CenterScreen;
                        se.ShowDialog( );
                    }
                }
                else if ( comboBox1.Text .Equals( "化学品辅料") )
                {
                    r519 = _bll.GetDataTablePqabcdekz( "R_PQAS" );
                    if ( r519.Rows.Count < 1 )
                        MessageBox.Show( "没有化学品辅料数据" );
                    else
                    {
                        se.zhi = "9";
                        r519ben = "7";
                        se.PassDataBetweenForm += new R_FrmR_519select.PassDataBetweenFormHandler( se_PassDataBetweenForm );
                        se.StartPosition = FormStartPosition.CenterScreen;
                        se.ShowDialog( );
                    }
                }
            }
        }
        private void se_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            textBox27 . Text = textBox59 . Text = textBox32 . Text = textBox4 . Text = textBox11 . Text = comboBox2 . Text = "";
            if ( r519ben . Equals ( "1" ) )
            {
                textBox27 . Text = e . ConTwo;
                textBox59 . Text = e . ConTre;
                textBox32 . Text = e . ConFor;
                //textBox4.Text = e.ConFor;
            }
            else if ( r519ben . Equals ( "2" ) )
            {
                textBox27 . Text = e . ConTwo;
                textBox59 . Text = e . ConTre;
                textBox32 . Text = e . ConFor;
                //textBox4.Text = e.ConFor;
            }
            else if ( r519ben . Equals ( "3" ) )
            {
                textBox27 . Text = e . ConTwo;
                textBox59 . Text = e . ConTre;
                textBox32 . Text = e . ConFor;
                //textBox4.Text = e.ConFor;
            }
            else if ( r519ben . Equals ( "4" ) )
            {
                textBox27 . Text = e . ConTwo;
                textBox59 . Text = e . ConTre;
                textBox32 . Text = e . ConFor;
            }
            else if ( r519ben . Equals ( "5" ) )
            {
                textBox27 . Text = e . ConTwo;
                textBox59 . Text = e . ConTre;
                textBox32 . Text = e . ConFor;
            }
            else if ( r519ben . Equals ( "6" ) )
            {
                textBox27 . Text = e . ConOne;
                textBox59 . Text = e . ConTwo;
                textBox11 . Text = e . ConTre;
                textBox32 . Text = e . ConFor;
            }
            else if ( r519ben . Equals ( "7" ) )
            {
                textBox32 . Text = e . ConOne;
                comboBox2 . Text = e . ConTwo;
                textBox27 . Text = e . ConTre;
                textBox59 . Text = e . ConFor;
                textBox4 . Text = e . ConFiv;
                textBox11 . Text = e . ConSix;
                textBox14 . Text = e . ConSev;
            }
        }
        SelectAll.YouQiSelectAll query = new SelectAll.YouQiSelectAll( );
        protected override void select ( )
        {
            base.select( );

            
            _model = new MulaolaoLibrary.YouQiLibrary( );
            query.StartPosition = FormStartPosition.CenterScreen;
            query.PassDataBetweenForm += new SelectAll.YouQiSelectAll.PassDataBetweenFormHandler( query_PassDataBetweenForm );
            query.signYou = "1";
            query.ShowDialog( );


            if ( _model.YQ99 == null || _model.YQ99 == "" )
                MessageBox.Show( "您没有选择任何内容" );
            else
                autoQuery( );
        }
        private void query_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            _model.YQ99 = e.ConOne;
            if ( e.ConTwo == "执行" )
                label24.Visible = true;
            else
                label24.Visible = false;
        }
        void queryContent ( )
        {
            if ( _model.YQ99 != null && _model.YQ99 != "" )
            {
                _model = _bll.GetMo( _model.YQ99 );
                if ( _model != null )
                {
                    DataTable gongy = _bll.GetDataTableSupp( _model.YQ02 );
                    if ( gongy.Rows.Count > 0 )
                    {
                        textBox2.Text = gongy.Rows[0]["DGA003"].ToString( );
                        textBox7.Text = gongy.Rows[0]["DGA017"].ToString( );
                        textBox8.Text = gongy.Rows[0]["DGA008"].ToString( );
                        textBox9.Text = gongy.Rows[0]["DGA012"].ToString( );
                        textBox10.Text = gongy.Rows[0]["DGA009"].ToString( );
                        textBox6.Text = gongy.Rows[0]["DGA011"].ToString( );
                    }

                    lookUpEdit1.Text = name.Select( "DBA001='" + _model.YQ01 + "'" ).Length > 0 ? name.Select( "DBA001='" + _model.YQ01 + "'" )[0]["DBA002"].ToString( ) : string.Empty;
                    textBox5.Text = name.Select( "DBA001='" + _model.YQ01 + "'" ).Length > 0 ? name.Select( "DBA001='" + _model.YQ01 + "'" )[0]["DBA028"].ToString( ) : string.Empty;
                    textBox13.Text = _model.YQ07;
                    dateTimePicker2.Value = _model.YQ08;
                    textBox16.Text = _model.YQ09;
                    dateTimePicker3.Value = _model.YQ17;
                    dateTimePicker4.Value = _model.YQ18;
                    textBox17.Text = _model.YQ04;
                    checkBox36.Checked = _model.YQ22.Trim( ) == "T" ? true : false;
                    checkBox37.Checked = _model.YQ23.Trim( ) == "T" ? true : false;
                    checkBox38.Checked = _model.YQ24.Trim( ) == "T" ? true : false;
                    checkBox39.Checked = _model.YQ25.Trim( ) == "T" ? true : false;
                    checkBox40.Checked = _model.YQ26.Trim( ) == "T" ? true : false;
                    comboBox16.Text = _model.YQ27;
                    dateTimePicker5.Value = _model.YQ28;
                    comboBox17.Text = _model.YQ29;
                    dateTimePicker6.Value = _model.YQ30;
                    textBox26.Text = _model.YQ31;
                    checkBox4.Checked = _model.YQ32.Trim( ) == "T" ? true : false;
                    checkBox7.Checked = _model.YQ33.Trim( ) == "T" ? true : false;
                    checkBox5.Checked = _model.YQ34.Trim( ) == "T" ? true : false;
                    checkBox6.Checked = _model.YQ35.Trim( ) == "T" ? true : false;
                    if ( _model.YQ36.Trim( ) .Equals( "在内") )
                    {
                        radioButton1.Checked = true;
                        radioButton2.Checked = false;
                    }
                    else if ( _model.YQ36.Trim( ) .Equals( "不在内") )
                    {
                        radioButton1.Checked = false;
                        radioButton2.Checked = true;
                    }
                    else
                    {
                        radioButton1.Checked = false;
                        radioButton2.Checked = false;
                    }
                    if ( _model.YQ37.Trim( ) .Equals( "有") )
                    {
                        radioButton3.Checked = true;
                        radioButton4.Checked = false;
                    }
                    else if ( _model.YQ37.Trim( ) .Equals( "没有") )
                    {
                        radioButton3.Checked = false;
                        radioButton4.Checked = true;
                    }
                    else
                    {
                        radioButton3.Checked = false;
                        radioButton4.Checked = false;
                    }
                    if ( _model.YQ38.Trim( ) .Equals( "已检测") )
                    {
                        radioButton6.Checked = true;
                        textBox24.Text = _model.YQ39;
                        radioButton5.Checked = false;
                    }
                    else if ( _model.YQ38.Trim( ) .Equals( "未检测") )
                    {
                        radioButton5.Checked = true;
                        radioButton6.Checked = false;
                        textBox24.Text = string.Empty;
                    }
                    else
                    {
                        radioButton5.Checked = false;
                        radioButton6.Checked = false;
                        textBox24.Text = string.Empty;
                    }
                    checkBox1.Checked = _model.YQ40.Trim( ) == "T" ? true : false;
                    checkBox2.Checked = _model.YQ41.Trim( ) == "T" ? true : false;
                    checkBox3.Checked = _model.YQ42.Trim( ) == "T" ? true : false;
                    checkBox8.Checked = _model.YQ43.Trim( ) == "T" ? true : false;
                    checkBox10.Checked = _model.YQ44.Trim( ) == "T" ? true : false;
                    checkBox9.Checked = _model.YQ45.Trim( ) == "T" ? true : false;
                    comboBox18.Text = _model.YQ46;
                    dateTimePicker7.Value = _model.YQ47;
                    comboBox19.Text = _model.YQ48;
                    dateTimePicker8.Value = _model.YQ49;
                    textBox31.Text = _model.YQ50;
                    textBox30.Text = _model.YQ51;
                    checkBox11.Checked = _model.YQ52.Trim( ) == "T" ? true : false;
                    checkBox12.Checked = _model.YQ53.Trim( ) == "T" ? true : false;
                    checkBox13.Checked = _model.YQ54.Trim( ) == "T" ? true : false;
                    textBox1.Text = _model.YQ55;
                    checkBox41.Checked = _model.YQ102.Trim( ) == "T" ? true : false;
                    checkBox18.Checked = _model.YQ56.Trim( ) == "T" ? true : false;
                    checkBox20.Checked = _model.YQ57.Trim( ) == "T" ? true : false;
                    checkBox19.Checked = _model.YQ58.Trim( ) == "T" ? true : false;
                    checkBox21.Checked = _model.YQ59.Trim( ) == "T" ? true : false;
                    string[] str = _model.YQ60.Split( ',' );
                    if ( str[0] == "T" )
                    {
                        checkBox15.Checked = true;
                        textBox29.Text = str[1];
                    }
                    else
                    {
                        checkBox15.Checked = false;
                        textBox29.Text = string.Empty;
                    }
                    checkBox14.Checked = _model.YQ61.Trim( ) == "T" ? true : false;
                    checkBox17.Checked = _model.YQ62.Trim( ) == "T" ? true : false;
                    checkBox25.Checked = _model.YQ63.Trim( ) == "T" ? true : false;
                    checkBox22.Checked = _model.YQ64.Trim( ) == "T" ? true : false;
                    checkBox23.Checked = _model.YQ65.Trim( ) == "T" ? true : false;
                    checkBox24.Checked = _model.YQ66.Trim( ) == "T" ? true : false;
                    checkBox29.Checked = _model.YQ67.Trim( ) == "T" ? true : false;
                    checkBox26.Checked = _model.YQ68.Trim( ) == "T" ? true : false;
                    checkBox27.Checked = _model.YQ69.Trim( ) == "T" ? true : false;
                    checkBox28.Checked = _model.YQ70.Trim( ) == "T" ? true : false;
                    checkBox33.Checked = _model.YQ71.Trim( ) == "T" ? true : false;
                    checkBox35.Checked = _model.YQ72.Trim( ) == "T" ? true : false;
                    checkBox32.Checked = _model.YQ73.Trim( ) == "T" ? true : false;
                    checkBox31.Checked = _model.YQ74.Trim( ) == "T" ? true : false;
                    checkBox34.Checked = _model.YQ75.Trim( ) == "T" ? true : false;
                    checkBox30.Checked = _model.YQ76.Trim( ) == "T" ? true : false;
                    textBox33.Text = _model.YQ77.ToString( );
                    comboBox5.Text = _model.YQ78;
                    dateTimePicker9.Value = _model.YQ79;
                    if ( _model.YQ80.Trim( ) .Equals( "合格") )
                        radioButton7.Checked = true;
                    else if ( _model.YQ80.Trim( ) .Equals( "退货") )
                        radioButton8.Checked = true;
                    else if ( _model.YQ80.Trim( ) .Equals( "条件接收") )
                    {
                        radioButton9.Checked = true;
                        textBox35.Text = _model.YQ81;
                    }
                    textBox36.Text = _model.YQ82.ToString( );
                    textBox37.Text = _model.YQ83.ToString( );
                    textBox38.Text = _model.YQ84.ToString( );
                    textBox41.Text = _model.YQ85.ToString( );
                    textBox40.Text = _model.YQ86.ToString( );
                    textBox39.Text = _model.YQ87.ToString( );
                    textBox44.Text = _model.YQ88.ToString( );
                    textBox43.Text = _model.YQ89.ToString( );
                    textBox42.Text = _model.YQ90.ToString( );
                    textBox45.Text = _model.YQ91;
                    textBox46.Text = _model.YQ92;
                    dateTimePicker10.Value = _model.YQ93;
                    textBox47.Text = _model.YQ94;
                    dateTimePicker11.Value = _model.YQ95;
                    textBox48.Text = _model.YQ96;
                    dateTimePicker12.Value = _model.YQ97;
                    dateTimePicker13.Value = _model.YQ98;
                    if ( _model.YQ111.Trim( ) .Equals( "复制") )
                        label36.Visible = true;
                    else
                        label36.Visible = false;
                    textBox12.Text = _model.YQ103;
                    if ( _model . YQ110 > DateTime . MinValue && _model . YQ110 < DateTime . MaxValue )
                        dateTimePicker1 . Value = _model . YQ110;
                    else
                        dateTimePicker1 . Value = DateTime . Now;

                    strWhere = "1=1";
                    strWhere = strWhere + " AND YQ99='" + _model.YQ99 + "'";
                    refre( );
                }
            }
        }
        void autoQuery ( )
        {
            Ergodic.SpliEnableFalse( spList );

            toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolReview.Enabled = toolcopy.Enabled =toolLibrary.Enabled=toolStorage.Enabled= true;
            toolSave.Enabled = toolCancel.Enabled = false;

            textBox12.Enabled = false;

            sign = "2";
            queryContent( );
        }
        #endregion
        
        #region Table
        void variable ( )
        {
            _model.YQ04 = textBox17.Text;
            _model.YQ09 = textBox16.Text;
            _model.YQ06 = textBox27.Text;
            _model.YQ11 = textBox32.Text;
            _model.YQ12 = comboBox2.Text;
            _model.YQ15 = string.IsNullOrEmpty( textBox59.Text ) == true ? 0M : Convert.ToDecimal( textBox59.Text );
            _model . YQ109 = string . IsNullOrEmpty ( textBox3 . Text ) == true ? 0 : Convert . ToDecimal ( textBox3 . Text );
            _model.YQ119 = comboBox1.Text;
            _model.YQ10 = textBox4.Text;
            _model.YQ117 = textBox11.Text;
            _model . YQ100 = textBox14 . Text;
        }
        void rowEdit ( )
        {
            row [ "YQ06" ] = _model . YQ06;
            row [ "YQ11" ] = _model . YQ11;
            row [ "YQ12" ] = _model . YQ12;
            row [ "YQ15" ] = _model . YQ15;
            row [ "YQ109" ] = _model . YQ109;
            row [ "YQ119" ] = _model . YQ119;
            row [ "YQ10" ] = _model . YQ10;
            row [ "YQ117" ] = _model . YQ117;
            row [ "YQ100" ] = _model . YQ100;
        }
        //Build
        private void button1_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox16.Text ) )
            {
                MessageBox.Show( "合同批号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox1.Text ) )
            {
                MessageBox.Show( "工艺不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox32.Text ) )
            {
                MessageBox.Show( "色名不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox2.Text ) )
            {
                MessageBox.Show( "色号不可为空" );
                return;
            }
            variable( );
            result = _bll.ExistsBuild( _model.YQ11 ,_model.YQ12 ,_model.YQ99 ,_model.YQ06 ,_model.YQ119 );
            if ( result == false )
                build( );
            else
                MessageBox.Show( "此单已经从在该记录,请刷新核实" );
        }
        void build ( )
        {
            if ( label24.Visible == true )
                stateOfOdd = "维护新建";
            else
            {
                if ( sign == "1" )
                    stateOfOdd = "新增新建";
                else
                    stateOfOdd = "更改新建";
            }
            result = _bll.Insert( _model ,"R_337" ,"库存油漆（墨）等采购合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"新建" ,stateOfOdd );
            if ( result == true )
            {
                MessageBox.Show( "成功录入数据" );
                //if ( tableQuery == null )
                refre( );
                //else
                //{
                //    row = tableQuery.NewRow( );
                //    row["idx"] = _model.IDX;
                //    rowEdit( );
                //    tableQuery.Rows.Add( row );
                //}
            }
            else
                MessageBox.Show( "录入数据失败" );
        }
        //Edit
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox16.Text ) )
            {
                MessageBox.Show( "合同批号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox1.Text ) )
            {
                MessageBox.Show( "工艺不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox32.Text ) )
            {
                MessageBox.Show( "色名不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox2.Text ) )
            {
                MessageBox.Show( "色号不可为空" );
                return;
            }
            variable( );
            /*
             brand = textBox27.Text;
            procedure = comboBox1.Text;
            color = textBox32.Text;
            colorName = comboBox2.Text;
            */
            if ( color .Equals( textBox32.Text) && colorName .Equals( comboBox2.Text) && procedure.Equals(comboBox1.Text) && brand.Equals(textBox27.Text))
                edit( );
            else
            {
                result = _bll.ExistsBuild( _model.YQ11 ,_model.YQ12 ,_model.YQ99 ,_model.YQ06 ,_model.YQ119 );
                if ( result == false )
                    edit( );
                else
                    MessageBox.Show( "此单已经存在该记录,请刷新核实" );
            }
        }
        void edit ( )
        {
            if ( label24.Visible == true )
                stateOfOdd = "维护编辑";
            else
            {
                if ( sign == "1" )
                    stateOfOdd = "新增编辑";
                else
                    stateOfOdd = "更改编辑";
            }
            result = _bll.UpdateOther( _model ,"R_337" ,"库存油漆（墨）等采购合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"编辑" ,stateOfOdd );
            if ( result == true )
            {
                MessageBox.Show( "编辑成功" );
                row = tableQuery.Rows[gridView1.FocusedRowHandle];
                row.BeginEdit( );
                rowEdit( );
                row.EndEdit( );
            }
            else
                MessageBox.Show( "编辑失败" );
        }
        //Delete
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                return;
            if ( label24.Visible == true )
                stateOfOdd = "维护删除";
            else
            {
                if ( sign == "1" )
                    stateOfOdd = "新增删除";
                else
                    stateOfOdd = "更改删除";
            }
            result = _bll.DeleteOther( _model.IDX ,"R_337" ,"库存油漆（墨）等采购合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,_model.YQ99 ,"删除" ,stateOfOdd );
            if ( result == true )
            {
                MessageBox.Show( "成功删除数据" );
                //tableQuery.Rows.RemoveAt( gridView1.FocusedRowHandle );
                button13_Click ( null , null );
            }
            else
                MessageBox.Show( "删除数据失败" );
        }
        //Refresh
        private void button13_Click ( object sender ,EventArgs e )
        {
            refre( );
        }
        void refre ( )
        {
            strWhere = "1=1";
            strWhere = strWhere + " AND YQ99='" + _model.YQ99 + "'";
            tableQuery = _bll.GetDataTablePlanOther( strWhere );
            gridControl1.DataSource = tableQuery;
        }
        #endregion

    }
}

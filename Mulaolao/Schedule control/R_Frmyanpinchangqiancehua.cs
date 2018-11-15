using System;
using System . Collections . Generic;
using System . Data;
using System . Drawing;
using System . Windows . Forms;
using Mulaolao . Class;
using System . IO;
using FastReport;
using FastReport . Export . Xml;

namespace Mulaolao . Schedule_control
{
    public partial class R_Frmyanpinchangqiancehua : FormChild
    {
        public R_Frmyanpinchangqiancehua( )
        {
            InitializeComponent();

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        MulaolaoLibrary.yanpinchangqiancehuaLibrary model = new MulaolaoLibrary.yanpinchangqiancehuaLibrary( );
        MulaolaoBll.Bll.yanpinchangqiancehuaBll _bll = new MulaolaoBll.Bll.yanpinchangqiancehuaBll( );
        List<SplitContainer> spList = new List<SplitContainer>( );
        List<TabPage> pageList = new List<TabPage>( ); SpecialPowers sp = new SpecialPowers( );
        string stateOfOdd = "", sign = "", filepath = "", strWhere = "", file = "";
        bool result = false;
        DataTable tableQuery,printes,prints;Report report = new Report( ); DataSet RDataSet = new DataSet( );

        private void R_Frmyanpinchangqiancehua_Load( object sender, EventArgs e )
        {
            Power( this );

            spList.Clear( );
            spList.AddRange( new SplitContainer[] { splitContainer1 } );
            Ergodic.SpliClear( spList );
            Ergodic.SpliEnableFalse( spList );
            pageList.Clear( );
            pageList.AddRange( new TabPage[] { tabPageOne ,tabPageTwo ,tabPageTre ,tabPageFor ,tabPageFiv } );
            Ergodic.TablePageEnableClear( pageList );
            Ergodic.TablePageEnableFalse( pageList );
            gridControl1.DataSource = null;
            label74.Visible = label107.Visible = false;
        }

        private void R_Frmyanpinchangqiancehua_Shown ( object sender ,EventArgs e )
        {
            model.CQ01 = Merges.oddNum;
            if ( model.CQ01 != null && model.CQ01 != "" )
                autoQuery( );
            Merges.oddNum = "";
        }

        #region Print
        void CreateOfPrint ( )
        {
            RDataSet = new DataSet( );
            printes = _bll.GetDataTableOfPrintOne( model.CQ01 );
            prints = _bll.GetDataTableOfPrintTwo( model.CQ01 );
            printes.TableName = "R_PQCQ";
            prints.TableName = "R_PQCQS";
            RDataSet.Tables.AddRange( new DataTable[] { printes ,prints } );
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
            gridControl1.DataSource = null;

            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;

            textBox47.Enabled = false;
            label74.Visible = label107.Visible = false;
            sign = "1";
            model.CQ01 = oddNumbers.purchaseContract( "SELECT MAX(AJ028) AJ028 FROM R_PQAJ" ,"AJ028" ,"R_480-" );
            columnsChoise ( );
        }
        protected override void delete ( )
        {
            base.delete( );

            if ( label107.Visible == true )
            {
                if ( Logins.number == "MLL-0001" )
                    deletes( );
                else
                    MessageBox.Show( "此单已执行,需要总经理删除" );
            }
            else
                deletes( );
        }
        void deletes ( )
        {
            if ( deleteOf ( ) == true )
                return;
            if ( sign == "1" )
                stateOfOdd = "新增删除";
            else if ( sign == "2" )
                stateOfOdd = "更改删除";
            else if ( sign == "3" )
                stateOfOdd = "复制删除";
            else if ( sign == "4" )
                stateOfOdd = "维护删除";

            result = _bll.DeleteOfAll( model.CQ01 ,"R_480" ,"样品产前策划及打样任务单" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"删除" ,stateOfOdd );
            if ( result == true )
            {
                MessageBox.Show( "成功删除数据" );
                pictureBox1.Image = null;
                model.CQ34 = new byte[0];
                Ergodic.SpliClear( spList );
                Ergodic.TablePageEnableClear( pageList );
                Ergodic.SpliEnableFalse( spList );
                Ergodic.TablePageEnableFalse( pageList );
                gridControl1.DataSource = null;
                label74.Visible = label107.Visible = false;
                sign = "";
                toolAdd.Enabled = toolSelect.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
            }
            else
                MessageBox.Show( "删除失败,请重试" );
        }
        bool deleteOf ( )
        {
            result = false;
            if ( gridView1 . RowCount > 0 )
            {
                for ( int i = 0 ; i < gridView1 . RowCount ; i++ )
                {
                    if ( !string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "CQ112" ] . ToString ( ) ) )
                    {
                        MessageBox . Show ( "本单据中有内容已被231选择结账,不允许删除" );
                        result= true;
                        break;
                    }
                }
            }

            return result;
        }
        protected override void update ( )
        {
            base.update( );

            if ( label107.Visible == true )
                MessageBox.Show( "本单状态为执行,请维护" );
            else
            {
                Ergodic.SpliEnableTrue( spList );
                Ergodic.TablePageEnableTrue( pageList );

                sign = "2";
                toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
                textBox47.Enabled = false;
                columnsChoise ( );
            }
        }
        protected override void revirw ( )
        {
            base.revirw( );

            Reviews( "CQ01" ,model.CQ01 ,"R_PQCQ" ,this ,"" ,"R_480" ,false ,false,MulaolaoBll . Drity . GetDt ( )/*,"" ,"" ,"" ,"" ,"" ,"" ,"","R_196"*/ );

            result = sp.reviewImple( "R_480" ,model.CQ01 );
            if ( result == true )
                label107.Visible = true;
            else
                label107.Visible = false;
        }
        protected override void print ( )
        {
            base.print( );

            if ( label107.Visible == true )
            {
                file = "";
                file = System.Windows.Forms.Application.StartupPath;
                CreateOfPrint( );
                report.Load( file + "\\R_480.frx" );
                report.RegisterData( RDataSet );
                report.Show( );
            }
            else
                MessageBox.Show( "单据没有执行,不允许打印" );
        }
        protected override void export ( )
        {
            base.export( );

            file = "";
            file = System.Windows.Forms.Application.StartupPath;

            CreateOfPrint( );
            report.Load( file + "\\R_480.frx" );
            report.RegisterData( RDataSet );
            report.Prepare( );
            XMLExport exprots = new XMLExport( );
            exprots.Export( report );
        }
        protected override void save ( )
        {
            base.save( );

            if ( string.IsNullOrEmpty( textBox1.Text ) )
            {
                MessageBox.Show( "客户不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox3.Text ) )
            {
                MessageBox.Show( "样品产前名称不可为空" );
                return;
            }
            if ( gridView1.RowCount < 1 )
            {
                MessageBox.Show( "请填写采购信息" );
                return;
            }
            if ( sign == "4" )
            {
                if ( string.IsNullOrEmpty( textBox47.Text ) )
                {
                    MessageBox.Show( "请填写维护意见" );
                    return;
                }
                model.CQ97 = _bll.GetDataTableOfWeiHu( model.CQ01 ) + "[" + Logins.username + MulaolaoBll . Drity . GetDt ( ) + "]";
                stateOfOdd = "维护保存";
                saveOfAll( );
            }
            else
            {
                model.CQ97 = "";
                if ( sign == "3" )
                    stateOfOdd = "复制保存";
                else
                {
                    if ( sign == "1" )
                        stateOfOdd = "新增保存";
                    else if ( sign == "2" )
                        stateOfOdd = "更改保存";
                }
                saveOfAll( );
            }
        }
        void variAble ( )
        {
            model.CQ02 = textBox1.Text;
            model.CQ03 = textBox2.Text;
            model.CQ04 = textBox3.Text;
            model.CQ05 = textBox4.Text;
            model.CQ06 = dateTimePicker1.Value;
            model.CQ07 = dateTimePicker2.Value;
            model.CQ08 = checkBox1.Checked == true ? "T" : "F";
            model.CQ09 = checkBox2.Checked == true ? "T" : "F";
            model.CQ10 = checkBox3.Checked == true ? "T" : "F";
            model.CQ11 = checkBox4.Checked == true ? "T" : "F";
            model.CQ12 = textBox5.Text;
            model.CQ13 = textBox6.Text;
            model.CQ14 = string.IsNullOrEmpty( textBox7.Text ) == true ? 0 : Convert.ToInt32( textBox7.Text );
            model.CQ15 = checkBox5.Checked == true ? "T" : "F";
            model.CQ16 = checkBox6.Checked == true ? "T" : "F";
            model.CQ17 = checkBox7.Checked == true ? "T" : "F";
            model.CQ18 = checkBox8.Checked == true ? "T" : "F";
            model.CQ19 = checkBox9.Checked == true ? "T" : "F";
            if ( model.CQ19.Trim( ) == "T" )
                model.CQ20 = textBox8.Text;
            else
                model.CQ20 = "";
            model.CQ21 = textBox9.Text;
            model.CQ22 = checkBox10.Checked == true ? "T" : "F";
            model.CQ23 = checkBox11.Checked == true ? "T" : "F";
            model.CQ24 = checkBox12.Checked == true ? "T" : "F";
            model.CQ25 = checkBox13.Checked == true ? "T" : "F";
            model.CQ26 = checkBox14.Checked == true ? "T" : "F";
            model.CQ27 = checkBox15.Checked == true ? "T" : "F";
            if ( model.CQ27.Trim( ) == "T" )
                model.CQ28 = textBox10.Text;
            else
                model.CQ28 = "";
            model.CQ29 = checkBox16.Checked == true ? "T" : "F";
            model.CQ30 = checkBox17.Checked == true ? "T" : "F";
            model.CQ31 = checkBox18.Checked == true ? "T" : "F";
            model.CQ32 = checkBox19.Checked == true ? "T" : "F";
            if ( model.CQ32.Trim( ) == "T" )
                model.CQ33 = textBox11.Text;
            else
                model.CQ33 = "";
            model.CQ35 = textBox33.Text;
            model.CQ36 = textBox34.Text;
            model.CQ37 = textBox35.Text;
            model.CQ38 = textBox36.Text;
            model.CQ39 = textBox37.Text;
            model.CQ40 = textBox38.Text;
            model.CQ41 = textBox39.Text;
            model.CQ42 = textBox40.Text;
            model.CQ43 = textBox41.Text;
            model.CQ44 = textBox42.Text;
            model.CQ45 = textBox43.Text;
            model.CQ46 = string.IsNullOrEmpty( textBox22.Text ) == true ? 0 : Convert.ToInt32( textBox22.Text );
            model.CQ47 = string.IsNullOrEmpty( textBox23.Text ) == true ? 0 : Convert.ToInt32( textBox23.Text );
            model.CQ48 = string.IsNullOrEmpty( textBox24.Text ) == true ? 0 : Convert.ToInt32( textBox24.Text );
            model.CQ49 = string.IsNullOrEmpty( textBox25.Text ) == true ? 0 : Convert.ToInt32( textBox25.Text );
            model.CQ50 = string.IsNullOrEmpty( textBox26.Text ) == true ? 0 : Convert.ToInt32( textBox26.Text );
            model.CQ51 = string.IsNullOrEmpty( textBox27.Text ) == true ? 0 : Convert.ToInt32( textBox27.Text );
            model.CQ52 = string.IsNullOrEmpty( textBox28.Text ) == true ? 0 : Convert.ToInt32( textBox28.Text );
            model.CQ53 = string.IsNullOrEmpty( textBox29.Text ) == true ? 0 : Convert.ToInt32( textBox29.Text );
            model.CQ54 = string.IsNullOrEmpty( textBox30.Text ) == true ? 0 : Convert.ToInt32( textBox30.Text );
            model.CQ55 = string.IsNullOrEmpty( textBox31.Text ) == true ? 0 : Convert.ToInt32( textBox31.Text );
            model.CQ56 = string.IsNullOrEmpty( textBox32.Text ) == true ? 0 : Convert.ToInt32( textBox32.Text );
            model.CQ57 = dateTimePicker5.Value;
            model.CQ58 = dateTimePicker4.Value;
            model.CQ59 = dateTimePicker6.Value;
            model.CQ60 = dateTimePicker7.Value;
            model.CQ61 = dateTimePicker8.Value;
            model.CQ62 = dateTimePicker9.Value;
            model.CQ63 = dateTimePicker10.Value;
            model.CQ64 = dateTimePicker11.Value;
            model.CQ65 = dateTimePicker12.Value;
            model.CQ66 = dateTimePicker13.Value;
            model.CQ67 = dateTimePicker14.Value;
            model.CQ68 = dateTimePicker15.Value;
            model.CQ69 = dateTimePicker16.Value;
            model.CQ70 = dateTimePicker17.Value;
            model.CQ71 = dateTimePicker18.Value;
            model.CQ72 = dateTimePicker19.Value;
            model.CQ73 = dateTimePicker20.Value;
            model.CQ74 = dateTimePicker21.Value;
            model.CQ75 = dateTimePicker22.Value;
            model.CQ76 = dateTimePicker23.Value;
            model.CQ77 = dateTimePicker24.Value;
            model.CQ78 = dateTimePicker25.Value;
            model.CQ79 = checkBox20.Checked == true ? "T" : "F";
            model.CQ80 = checkBox21.Checked == true ? "T" : "F";
            model.CQ81 = checkBox22.Checked == true ? "T" : "F";
            model.CQ82 = checkBox23.Checked == true ? "T" : "F";
            model.CQ83 = checkBox24.Checked == true ? "T" : "F";
            model.CQ84 = checkBox25.Checked == true ? "T" : "F";
            model.CQ85 = checkBox26.Checked == true ? "T" : "F";
            model.CQ86 = checkBox27.Checked == true ? "T" : "F";
            model.CQ87 = textBox13.Text;
            model.CQ88 = textBox14.Text;
            model.CQ89 = textBox15.Text;
            model.CQ90 = textBox16.Text;
            model.CQ91 = textBox17.Text;
            model.CQ92 = textBox18.Text;
            model.CQ93 = textBox19.Text;
            model.CQ94 = textBox20.Text;
            model.CQ95 = textBox21.Text;
            model.CQ96 = dateTimePicker3.Value;
            model.CQ108 = textBox12.Text;
            model.CQ109 = checkBox28.Checked == true ? "T" : "F";
            model.CQ110 = checkBox29.Checked == true ? "T" : "F";
            model.CQ111 = checkBox30.Checked == true ? "T" : "F";
            model.CQ98 = textBox47.Text;
            if ( pictureBox1.Image == null )
                model.CQ34 = new byte[0];
            else
                GetImageBytes( );
        }
        void saveState ( )
        {
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableFalse( pageList );

            toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
            label74.Visible = false;
        }
        void saveOfAll ( )
        {
            variAble( );
            result = _bll.SaveOfAll( model ,"R_480" ,"样品产前策划及打样任务单" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"保存" ,stateOfOdd );
            if ( result == true )
            {
                MessageBox.Show( "保存数据成功" );
                saveState( );
            }
            else
                MessageBox.Show( "保存失败,请重试" );
        }
        void GetImageBytes (  )
        {
            MemoryStream mstream = new MemoryStream( );
            pictureBox1.Image.Save( mstream ,System.Drawing.Imaging.ImageFormat.Jpeg );
            byte[] byteData = new byte[mstream.Length];
            mstream.Position = 0;
            mstream.Read( byteData ,0 ,byteData.Length );
            mstream.Close( );
            model.CQ34 = byteData;
        }
        protected override void cancel ( )
        {
            base.cancel( );

            if ( sign == "1" || sign == "3" )
            {
                pictureBox1.Image = null;
                model.CQ34 = new byte[0];
                Ergodic.SpliClear( spList );
                Ergodic.TablePageEnableClear( pageList );
                gridControl1.DataSource = null;
                toolSelect.Enabled = toolAdd.Enabled = true;
                toolDelete.Enabled = toolReview.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolSave.Enabled = toolCancel.Enabled = toolPrint.Enabled = toolExport.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                label74.Visible = false;
                try
                {
                    if ( sign == "1" )
                        stateOfOdd = "新增取消";
                    else if ( sign == "3" )
                        stateOfOdd = "维护取消";
                    _bll.DeleteOfAll( model.CQ01 ,"R_480" ,"样品产前策划及打样任务单" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"取消" ,stateOfOdd );
                }
                catch { }
            }
            else if(sign=="2" || sign=="4")
            {
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolUpdate.Enabled = toolcopy.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
            }
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableFalse( pageList );
        }
        protected override void maintain ( )
        {
            base.maintain( );

            if ( label107.Visible == true )
            {
                Ergodic.SpliEnableTrue( spList );
                Ergodic.TablePageEnableTrue( pageList );
                sign = "4";
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolUpdate.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
                columnsChoise ( );
            }
            else
                MessageBox.Show( "此单据没有被执行,只需更改即可,无需维护" );
        }
        protected override void copys ( )
        {
            base.copys( );

            if ( sign == "1" )
                stateOfOdd = "新增复制";
            else if ( sign == "2" )
                stateOfOdd = "更改复制";
            else if ( sign == "4" )
                stateOfOdd = "维护复制";
            result = _bll.Copy( model.CQ01 ,"R_480" ,"样品产前策划及打样任务单" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"复制" ,stateOfOdd );
            if ( result == false )
            {
                MessageBox.Show( "复制失败,请重试" );
                return;
            }
            else
            {
                stateOfOdd = "复制更改单号";
                model.CQ01 = oddNumbers.purchaseContract( "SELECT MAX(AJ028) AJ028 FROM R_PQAJ" ,"AJ028" ,"R_480-" );
                result = _bll.CopyOf( model.CQ01 ,"R_480" ,"样品产前策划及打样任务单" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"复制" ,stateOfOdd );
                if ( result == false )
                {
                    MessageBox.Show( "复制失败,请重试" );
                    _bll.DeleteOfCopy( model.CQ01 ,"R_480" ,"样品产前策划及打样任务单" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"删除" ,"删除复制" );
                }
                else
                {
                    MessageBox.Show( "成功复制此表" );

                    Ergodic.SpliEnableTrue( spList );
                    Ergodic.TablePageEnableTrue( pageList );

                    sign = "3";
                    toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                    toolSave.Enabled = toolCancel.Enabled = true;
                    label74.Visible = true; label107.Visible = false;
                    queryContent( );
                }
            }
        }
        void columnsChoise ( )
        {
            DataTable da = _bll . GetDataTableOnly ( "CQ114,CQ99,CQ100,CQ101,CQ104" );
            comboBox5 . DataSource = da . DefaultView . ToTable ( true ,"CQ114" );
            comboBox5 . DisplayMember = "CQ114";
            comboBox1 . DataSource = da . DefaultView . ToTable ( true ,"CQ99" );
            comboBox1 . DisplayMember = "CQ99";
            comboBox2 . DataSource = da . DefaultView . ToTable ( true ,"CQ100" );
            comboBox2 . DisplayMember = "CQ100";
            comboBox3 . DataSource = da . DefaultView . ToTable ( true ,"CQ101" );
            comboBox3 . DisplayMember = "CQ101";
            comboBox4 . DataSource = da . DefaultView . ToTable ( true ,"CQ104" );
            comboBox4 . DisplayMember = "CQ104";
        }
        #endregion

        #region Query
        protected override void select ( )
        {
            base.select( );

            model = new MulaolaoLibrary.yanpinchangqiancehuaLibrary( );
            SelectAll.yanpinchangqiancehuaAll query = new SelectAll.yanpinchangqiancehuaAll( );
            query.StartPosition = FormStartPosition.CenterScreen;
            query.PassDataBetweenForm += new SelectAll.yanpinchangqiancehuaAll.PassDataBetweenFormHandler( query_PassDataBetweenForm );
            query.ShowDialog( );

            if(!string.IsNullOrEmpty(model.CQ01))
                autoQuery( );
        }
        void autoQuery ( )
        {
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;

            Ergodic.TablePageEnableFalse( pageList );
            Ergodic.SpliEnableFalse( spList );
            queryContent( );
        }
        void queryContent ( )
        {
            #region
            model = _bll.GetDataTableOfModel( model.CQ01 );
            if ( model == null )
                return;
            textBox1.Text = model.CQ02;
            textBox2.Text = model.CQ03;
            textBox3.Text = model.CQ04;
            textBox4.Text = model.CQ05;
            if ( model.CQ06 > DateTime.MinValue && model.CQ06 < DateTime.MaxValue )
                dateTimePicker1.Value = model.CQ06;
            if ( model.CQ07 > DateTime.MinValue && model.CQ07 < DateTime.MaxValue )
                model.CQ07 = dateTimePicker2.Value;
            checkBox1.Checked = model.CQ08.Trim( ) == "T" ? true : false;
            checkBox2.Checked = model.CQ09.Trim( ) == "T" ? true : false;
            checkBox3.Checked = model.CQ10.Trim( ) == "T" ? true : false;
            checkBox4.Checked = model.CQ11.Trim( ) == "T" ? true : false;
            textBox5.Text = model.CQ12;
            textBox6.Text = model.CQ13;
            textBox7.Text = model.CQ14.ToString( );
            checkBox5.Checked = model.CQ15.Trim( ) == "T" ? true : false;
            checkBox6.Checked = model.CQ16.Trim( ) == "T" ? true : false;
            checkBox7.Checked = model.CQ17.Trim( ) == "T" ? true : false;
            checkBox8.Checked = model.CQ18.Trim( ) == "T" ? true : false;
            checkBox9.Checked = model.CQ19.Trim( ) == "T" ? true : false;
            textBox8.Text = model.CQ20;
            textBox9.Text = model.CQ21;
            checkBox10.Checked = model.CQ22.Trim( ) == "T" ? true : false;
            checkBox11.Checked = model.CQ23.Trim( ) == "T" ? true : false;
            checkBox12.Checked = model.CQ24.Trim( ) == "T" ? true : false;
            checkBox13.Checked = model.CQ25.Trim( ) == "T" ? true : false;
            checkBox14.Checked = model.CQ26.Trim( ) == "T" ? true : false;
            checkBox15.Checked = model.CQ27.Trim( ) == "T" ? true : false;
            textBox10.Text = model.CQ28;
            checkBox16.Checked = model.CQ29.Trim( ) == "T" ? true : false;
            checkBox17.Checked = model.CQ30.Trim( ) == "T" ? true : false;
            checkBox18.Checked = model.CQ31.Trim( ) == "T" ? true : false;
            checkBox19.Checked = model.CQ32.Trim( ) == "T" ? true : false;
            textBox11.Text = model.CQ33;
            textBox33.Text = model.CQ35;
            textBox34.Text = model.CQ36;
            textBox35.Text = model.CQ37;
            textBox36.Text = model.CQ38;
            textBox37.Text = model.CQ39;
            textBox38.Text = model.CQ40;
            textBox39.Text = model.CQ41;
            textBox40.Text = model.CQ42;
            textBox41.Text = model.CQ43;
            textBox42.Text = model.CQ44;
            textBox43.Text = model.CQ45;
            textBox22.Text = model.CQ46.ToString( );
            textBox23.Text = model.CQ47.ToString( );
            textBox24.Text = model.CQ48.ToString( );
            textBox25.Text = model.CQ49.ToString( );
            textBox26.Text = model.CQ50.ToString( );
            textBox27.Text = model.CQ51.ToString( );
            textBox28.Text = model.CQ52.ToString( );
            textBox29.Text = model.CQ53.ToString( );
            textBox30.Text = model.CQ54.ToString( );
            textBox31.Text = model.CQ55.ToString( );
            textBox32.Text = model.CQ56.ToString( );
            if ( model.CQ57 > DateTime.MinValue && model.CQ57 < DateTime.MaxValue )
                dateTimePicker5.Value = model.CQ57;
            if ( model.CQ58 > DateTime.MinValue && model.CQ58 < DateTime.MaxValue )
                dateTimePicker4.Value = model.CQ58;
            if ( model.CQ59 > DateTime.MinValue && model.CQ59 < DateTime.MaxValue )
                dateTimePicker6.Value = model.CQ59;
            if ( model.CQ60 > DateTime.MinValue && model.CQ60 < DateTime.MaxValue )
                dateTimePicker7.Value = model.CQ60;
            if ( model.CQ61 > DateTime.MinValue && model.CQ61 < DateTime.MaxValue )
                dateTimePicker8.Value = model.CQ61;
            if ( model.CQ62 > DateTime.MinValue && model.CQ62 < DateTime.MaxValue )
                dateTimePicker9.Value = model.CQ62;
            if ( model.CQ63 > DateTime.MinValue && model.CQ63 < DateTime.MaxValue )
                dateTimePicker10.Value = model.CQ63;
            if ( model.CQ64 > DateTime.MinValue && model.CQ64 < DateTime.MaxValue )
                dateTimePicker11.Value = model.CQ64;
            if ( model.CQ65 > DateTime.MinValue && model.CQ65 < DateTime.MaxValue )
                dateTimePicker12.Value = model.CQ65;
            if ( model.CQ66 > DateTime.MinValue && model.CQ66 < DateTime.MaxValue )
                dateTimePicker13.Value = model.CQ66;
            if ( model.CQ67 > DateTime.MinValue && model.CQ67 < DateTime.MaxValue )
                dateTimePicker14.Value = model.CQ67;
            if ( model.CQ68 > DateTime.MinValue && model.CQ68 < DateTime.MaxValue )
                dateTimePicker15.Value = model.CQ68;
            if ( model.CQ69 > DateTime.MinValue && model.CQ69 < DateTime.MaxValue )
                dateTimePicker16.Value = model.CQ69;
            if ( model.CQ70 > DateTime.MinValue && model.CQ70 < DateTime.MaxValue )
                dateTimePicker17.Value = model.CQ70;
            if ( model.CQ71 > DateTime.MinValue && model.CQ71 < DateTime.MaxValue )
                dateTimePicker18.Value = model.CQ71;
            if ( model.CQ72 > DateTime.MinValue && model.CQ72 < DateTime.MaxValue )
                dateTimePicker19.Value = model.CQ72;
            if ( model.CQ73 > DateTime.MinValue && model.CQ73 < DateTime.MaxValue )
                dateTimePicker20.Value = model.CQ73;
            if ( model.CQ74 > DateTime.MinValue && model.CQ74 < DateTime.MaxValue )
                dateTimePicker21.Value = model.CQ74;
            if ( model.CQ75 > DateTime.MinValue && model.CQ75 < DateTime.MaxValue )
                dateTimePicker22.Value = model.CQ75;
            if ( model.CQ76 > DateTime.MinValue && model.CQ76 < DateTime.MaxValue )
                dateTimePicker23.Value = model.CQ76;
            if ( model.CQ77 > DateTime.MinValue && model.CQ77 < DateTime.MaxValue )
                dateTimePicker24.Value = model.CQ77;
            if ( model.CQ78 > DateTime.MinValue && model.CQ78 < DateTime.MaxValue )
                dateTimePicker25.Value = model.CQ78;
            checkBox20.Checked = model.CQ79.Trim( ) == "T" ? true : false;
            checkBox21.Checked = model.CQ80.Trim( ) == "T" ? true : false;
            checkBox22.Checked = model.CQ81.Trim( ) == "T" ? true : false;
            checkBox23.Checked = model.CQ82.Trim( ) == "T" ? true : false;
            checkBox24.Checked = model.CQ83.Trim( ) == "T" ? true : false;
            checkBox25.Checked = model.CQ84.Trim( ) == "T" ? true : false;
            checkBox26.Checked = model.CQ85.Trim( ) == "T" ? true : false;
            checkBox27.Checked = model.CQ86.Trim( ) == "T" ? true : false;
            textBox13.Text = model.CQ87;
            textBox14.Text = model.CQ88;
            textBox15.Text = model.CQ89;
            textBox16.Text = model.CQ90;
            textBox17.Text = model.CQ91;
            textBox18.Text = model.CQ92;
            textBox19.Text = model.CQ93;
            textBox20.Text = model.CQ94;
            textBox21.Text = model.CQ95;
            if ( model.CQ96 > DateTime.MinValue && model.CQ96 < DateTime.MaxValue )
                dateTimePicker3.Value = model.CQ96;
            textBox12.Text = model.CQ108;
            checkBox28.Checked = model.CQ109.Trim( ) == "T" ? true : false;
            checkBox29.Checked = model.CQ110.Trim( ) == "T" ? true : false;
            checkBox30.Checked = model.CQ111.Trim( ) == "T" ? true : false;
            textBox47.Text = model.CQ98;
            #endregion

            DataTable tableOfPic = _bll.GetDataTableOfPic( model.CQ01 );
            if ( tableOfPic != null && tableOfPic.Rows.Count > 0 )
            {
                if ( ( ( byte[] ) tableOfPic.Rows[0]["CQ34"] ).Length == 0 )
                    pictureBox1.Image = null;
                else
                {
                    model.CQ34 = ( byte[] ) tableOfPic.Rows[0]["CQ34"];
                    byte[] mybyte = ( byte[] ) tableOfPic.Rows[0]["CQ34"];
                    MemoryStream ms = new MemoryStream( mybyte );
                    ms.Write( mybyte ,0 ,mybyte.Length );
                    ms.Position = 0;
                    ms.Seek( 0 ,SeekOrigin.Begin );
                    Image img = Image.FromStream( ms ,true );
                    pictureBox1.Image = img;
                }
            }

            strWhere = "1=1";
            strWhere = strWhere + " AND CQ01='" + model.CQ01 + "'";
            refre( );
        }
        private void query_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            model.CQ01 = e.ConOne;
            if ( e.ConTwo == "执行" )
            {
                label107.Visible = true;
                sign = "4";
            }  
            else
                label107.Visible = false;
        }
        private void button4_Click ( object sender ,EventArgs e )
        {
            OpenFileDialog opd = new OpenFileDialog( );
            opd.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
            if ( opd.ShowDialog( ) == DialogResult.OK )
            {
                filepath = opd.FileName;
                pictureBox1.ImageLocation = filepath;

                FileStream fs = new FileStream( filepath ,FileMode.Open ,FileAccess.Read );
                BinaryReader bs = new BinaryReader( fs );
                model.CQ34 = bs.ReadBytes( ( int ) fs.Length );
            }
        }
        private void button8_Click ( object sender ,EventArgs e )
        {
            pictureBox1.Image = null;
            model.CQ34 = new byte[0];
        }
        #endregion

        #region Event
        private void textBox44_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox45_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise . fractionTb ( e ,textBox45 );
        }
        private void textBox45_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise . textChangeTb ( textBox45 );
        }
        private void textBox45_LostFocus ( object sender ,EventArgs e )
        {
            if ( !string . IsNullOrEmpty ( textBox45 . Text ) && !DateDayRegise . elevenTwoNumber ( textBox45 ) )
            {
                this . textBox45 . Text = "";
                MessageBox . Show ( "只允许输入整数部分最多九位,小数部分最多两位,如999999999.99,请重新输入" );
            }
        }
        private void textBox46_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox46 );
        }
        private void textBox46_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox46 );
        }
        private void textBox46_LostFocus ( object sender ,EventArgs e )
        {
            if ( !string.IsNullOrEmpty( textBox46.Text ) && !DateDayRegise.sixTwoNumber( textBox46 ) )
            {
                this.textBox46.Text = "";
                MessageBox.Show( "只允许输入整数部分最多四位,小数部分最多两位,如9999.99,请重新输入" );
            }
        }
        private void textBox7_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox22_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox23_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox24_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox25_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox26_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox27_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox28_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox29_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox30_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox31_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox32_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void dateTimePicker5_ValueChanged ( object sender ,EventArgs e )
        {
            label46.Text = ( dateTimePicker5.Value - dateTimePicker15.Value ).Days.ToString( );
        }
        private void dateTimePicker15_ValueChanged ( object sender ,EventArgs e )
        {
            label46.Text = ( dateTimePicker5.Value - dateTimePicker15.Value ).Days.ToString( );
        }
        private void dateTimePicker4_ValueChanged ( object sender ,EventArgs e )
        {
            label47.Text = ( dateTimePicker4.Value - dateTimePicker16.Value ).Days.ToString( );
        }
        private void dateTimePicker16_ValueChanged ( object sender ,EventArgs e )
        {
            label47.Text = ( dateTimePicker4.Value - dateTimePicker16.Value ).Days.ToString( );
        }
        private void dateTimePicker6_ValueChanged ( object sender ,EventArgs e )
        {
            label48.Text = ( dateTimePicker6.Value - dateTimePicker17.Value ).Days.ToString( );
        }
        private void dateTimePicker17_ValueChanged ( object sender ,EventArgs e )
        {
            label48.Text = ( dateTimePicker6.Value - dateTimePicker17.Value ).Days.ToString( );
        }
        private void dateTimePicker7_ValueChanged ( object sender ,EventArgs e )
        {
            label49.Text = ( dateTimePicker7.Value - dateTimePicker18.Value ).Days.ToString( );
        }
        private void dateTimePicker18_ValueChanged ( object sender ,EventArgs e )
        {
            label49.Text = ( dateTimePicker7.Value - dateTimePicker18.Value ).Days.ToString( );
        }
        private void dateTimePicker8_ValueChanged ( object sender ,EventArgs e )
        {
            label50.Text = ( dateTimePicker8.Value - dateTimePicker19.Value ).Days.ToString( );
        }
        private void dateTimePicker19_ValueChanged ( object sender ,EventArgs e )
        {
            label50.Text = ( dateTimePicker8.Value - dateTimePicker19.Value ).Days.ToString( );
        }
        private void dateTimePicker9_ValueChanged ( object sender ,EventArgs e )
        {
            label51.Text = ( dateTimePicker9.Value - dateTimePicker20.Value ).Days.ToString( );
        }
        private void dateTimePicker20_ValueChanged ( object sender ,EventArgs e )
        {
            label51.Text = ( dateTimePicker9.Value - dateTimePicker20.Value ).Days.ToString( );
        }
        private void dateTimePicker10_ValueChanged ( object sender ,EventArgs e )
        {
            label52.Text = ( dateTimePicker10.Value - dateTimePicker21.Value ).Days.ToString( );
        }
        private void dateTimePicker21_ValueChanged ( object sender ,EventArgs e )
        {
            label52.Text = ( dateTimePicker10.Value - dateTimePicker21.Value ).Days.ToString( );
        }
        private void dateTimePicker11_ValueChanged ( object sender ,EventArgs e )
        {
            label53.Text = ( dateTimePicker11.Value - dateTimePicker22.Value ).Days.ToString( );
        }
        private void dateTimePicker22_ValueChanged ( object sender ,EventArgs e )
        {
            label53.Text = ( dateTimePicker11.Value - dateTimePicker22.Value ).Days.ToString( );
        }
        private void dateTimePicker12_ValueChanged ( object sender ,EventArgs e )
        {
            label54.Text = ( dateTimePicker12.Value - dateTimePicker23.Value ).Days.ToString( );
        }
        private void dateTimePicker23_ValueChanged ( object sender ,EventArgs e )
        {
            label54.Text = ( dateTimePicker12.Value - dateTimePicker23.Value ).Days.ToString( );
        }
        private void dateTimePicker13_ValueChanged ( object sender ,EventArgs e )
        {
            label55.Text = ( dateTimePicker13.Value - dateTimePicker24.Value ).Days.ToString( );
        }
        private void dateTimePicker24_ValueChanged ( object sender ,EventArgs e )
        {
            label55.Text = ( dateTimePicker13.Value - dateTimePicker24.Value ).Days.ToString( );
        }
        private void dateTimePicker14_ValueChanged ( object sender ,EventArgs e )
        {
            label56.Text = ( dateTimePicker14.Value - dateTimePicker25.Value ).Days.ToString( );
        }
        private void dateTimePicker25_ValueChanged ( object sender ,EventArgs e )
        {
            label56.Text = ( dateTimePicker14.Value - dateTimePicker25.Value ).Days.ToString( );
        }
        private void gridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.RowCount - 1 )
            {
                model.idx = string.IsNullOrEmpty( gridView1.GetFocusedRowCellValue( "idx" ).ToString( ) ) == true ? 0 : Convert.ToInt32( gridView1.GetFocusedRowCellValue( "idx" ).ToString( ) );
                assignMent( );
            }
        }
        void assignMent ( )
        {
            model = _bll.GetDataModel( model.idx );
            if ( model == null )
                return;
            comboBox1.Text = model.CQ99;
            comboBox2.Text = model.CQ100;
            comboBox3.Text = model.CQ101;
            textBox44.Text = model.CQ102.ToString( );
            textBox45.Text = model.CQ103.ToString( );
            comboBox4.Text = model.CQ104;
            textBox46.Text = model.CQ105.ToString( );
            if ( model.CQ106 > DateTime.MinValue && model.CQ106 < DateTime.MaxValue )
                dateTimePicker26.Value = model.CQ106;
            if ( model.CQ107 > DateTime.MinValue && model.CQ107 < DateTime.MaxValue )
                dateTimePicker27.Value = model.CQ107;
            comboBox5 . Text = model . CQ114;
        }
        #endregion

        #region Table
        //Build
        void buildVariable ( )
        {
            model.CQ99 = comboBox1.Text;
            model.CQ100 = comboBox2.Text;
            model.CQ101 = comboBox3.Text;
            model.CQ102 = string.IsNullOrEmpty( textBox44.Text ) == true ? 0 : Convert.ToInt32( textBox44.Text );
            model.CQ103 = string.IsNullOrEmpty( textBox45.Text ) == true ? 0 : Convert.ToDecimal( textBox45.Text );
            model.CQ104 = comboBox4.Text;
            model.CQ105 = string.IsNullOrEmpty( textBox46.Text ) == true ? 0 : Convert.ToDecimal( textBox46.Text );
            model.CQ106 = dateTimePicker26.Value;
            model.CQ107 = dateTimePicker27.Value;
            model . CQ114 = comboBox5 . Text;
        }
        private void button1_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( comboBox1.Text ) )
            {
                MessageBox.Show( "物料或部件名称不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox44.Text ) )
            {
                MessageBox.Show( "样品数量不可为空" );
                return;
            }
            buildVariable( );
            if ( sign == "1" )
                stateOfOdd = "新增新建";
            else if ( sign == "2" )
                stateOfOdd = "更改新建";
            else if(sign=="3")
                stateOfOdd = "复制新建";
            else if ( sign == "4" )
                stateOfOdd = "维护新建";
            result = _bll.Add( model ,"R_480" ,"样品产前策划及打样任务单" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"新建" ,stateOfOdd );
            if ( result == true )
            {
                MessageBox.Show( "新建数据成功" );
                strWhere = "1=1";
                strWhere = strWhere + " AND CQ01='" + model.CQ01 + "'";
                refre( );
            }
            else
                MessageBox.Show( "新建失败,请重试" );
        }
        //Edit
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( !string . IsNullOrEmpty ( model . CQ112 ) )
            {
                MessageBox . Show ( "本记录已被231选择结账,不允许编辑" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox1.Text ) )
            {
                MessageBox.Show( "物料或部件名称不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox44.Text ) )
            {
                MessageBox.Show( "样品数量不可为空" );
                return;
            }
            buildVariable( );
            if ( sign == "1" )
                stateOfOdd = "新增编辑";
            else if ( sign == "2" )
                stateOfOdd = "更改编辑";
            else if ( sign == "3" )
                stateOfOdd = "复制编辑";
            else if ( sign == "4" )
                stateOfOdd = "维护编辑";

            result = _bll.Edit( model ,"R_480" ,"样品产前策划及打样任务单" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"编辑" ,stateOfOdd );
            if ( result == true )
            {
                MessageBox.Show( "成功编辑数据" );
                strWhere = "1=1";
                strWhere = strWhere + " AND CQ01='" + model.CQ01 + "'";
                refre( );
            }
            else
                MessageBox.Show( "编辑失败,请重试" );
        }
        //Delete
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) ==

   DialogResult . Cancel )
                return;

            if ( !string . IsNullOrEmpty ( model . CQ112 ) )
            {
                MessageBox . Show ( "本记录已被231选择结账,不允许删除" );
                return;
            }
            if ( sign == "1" )
                stateOfOdd = "新增删除";
            else if ( sign == "2" )
                stateOfOdd = "更改删除";
            else if ( sign == "3" )
                stateOfOdd = "复制删除";
            else if ( sign == "4" )
                stateOfOdd = "维护删除";
            int num = gridView1.FocusedRowHandle;
            result = _bll.Delete( model ,"R_480" ,"样品产前策划及打样任务单" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"删除" ,stateOfOdd );
            if ( result == true )
            {
                MessageBox.Show( "成功删除数据" );
                tableQuery.Rows.RemoveAt( num );
            }
            else
                MessageBox.Show( "删除数据失败,请重试" );
        }
        //Refre
        private void button5_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            strWhere = strWhere + " AND CQ01='" + model.CQ01 + "'";
            refre( );
        }
        void refre ( )
        {
            if ( strWhere == "" )
                strWhere = "1=1";
            tableQuery = _bll.GetDataTableOfTable( strWhere );
            gridControl1.DataSource = tableQuery;
        }
        #endregion
    }
}

using Mulaolao.Class;
using Mulaolao.Other;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using FastReport;
using FastReport.Export.Xml;

namespace Mulaolao.Contract
{
    public partial class GunqiChengLanJiaGong : FormChild
    {
        public GunqiChengLanJiaGong ( )
        {
            InitializeComponent( );

            GridViewMoHuSelect . SetFilter ( bandedGridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { bandedGridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }

        MulaolaoLibrary.GunQiChengLanJiaGongLibrary model = new MulaolaoLibrary.GunQiChengLanJiaGongLibrary( );
        MulaolaoBll.Bll.GunQiChengLanJiaGongBll bll = new MulaolaoBll.Bll.GunQiChengLanJiaGongBll( );

        List<SplitContainer> spList = new List<SplitContainer>( );
        List<TabPage> pageList = new List<TabPage>( );
        bool result = false;
        DataTable tableQuery, rearOf;
        string strWhere = "1=1", sign = "", weihu = "", copy = "", file = "";
        DataSet RDataSet;Report report = new Report( );
        
        private void GunqiChengLanJiaGong_Load ( object sender ,EventArgs e )
        {
            Power( this );

            gridControl1.DataSource = null;
            spList.Clear( );
            spList.AddRange( new SplitContainer[] { splitContainer1 ,splitContainer2 ,splitContainer3 } );
            Ergodic.SpliClear( spList );
            Ergodic.SpliEnableFalse( spList );
            pageList.Clear( );
            pageList.AddRange( new TabPage[] { tabPageOne ,tabPageTwo ,tabPageTre } );
            Ergodic.TablePageEnableClear( pageList );
            Ergodic.TablePageEnableFalse( pageList );
            textBox10.Text = "";

            label45.Visible = label46.Visible = false;
            textBox10.Enabled = false;

            comboBox3.Items.Clear( );
            comboBox3.Items.AddRange( new string[] { "厂内" ,"厂外" ,"桶" } );
        }

        private void GunqiChengLanJiaGong_Shown ( object sender ,EventArgs e )
        {
            model.LZ001 = Merges.oddNum;
            if ( model.LZ001 != null && model.LZ001 != "" )
                autoQuery( );
            Merges.oddNum = "";
        }

        #region Pirnt Export
        void createDataSet ( )
        {
            RDataSet = new DataSet( );
            DataTable print = bll.GetDataTablePrintOne( model.LZ001 );
            DataTable prints = bll.GetDataTablePrintTwo( model.LZ001 );
            print.TableName = "R_PQLZ";
            prints.TableName = "R_PQLZS";
            RDataSet.Tables.AddRange( new DataTable[] { print ,prints } );
        }
        #endregion

        #region Event
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
            if ( textBox14.Text != "" && !DateDayRegise.sevenSixTb( textBox14 ) )
            {
                textBox14.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多五位,如99.99999,请重新输入" );
            }
        }
        private void textBox19_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
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
            if ( textBox20.Text != "" && !DateDayRegise.sevenFourTb( textBox20 ) )
            {
                textBox20.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多四位,如999.9999,请重新输入" );
            }
        }
        private void textBox21_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            //DateDayRegise.fractionTb( e ,textBox21 );
        }
        private void textBox21_TextChanged ( object sender ,EventArgs e )
        {
            //DateDayRegise.textChangeTb( textBox21 );
        }
        private void textBox21_LostFocus ( object sender ,EventArgs e )
        {
            //if ( textBox21.Text != "" && !DateDayRegise.sixThrNumberCb( textBox21 ) )
           // {
            //    textBox21.Text = "";
            //    MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多三位,如999.999,请重新输入" );
           // }
        }
        private void textBox22_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty(textBox6.Text ) )
                textBox6.Text = Logins.username;
            else if ( textBox6.Text != "" && textBox6.Text == Logins.username )
                textBox6.Text = "";
        }
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox7.Text ) )
                textBox7.Text = Logins.username;
            else if ( textBox7.Text != "" && textBox7.Text == Logins.username )
                textBox7.Text = "";
        }
        private void button4_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox8.Text ) )
                textBox8.Text = Logins.username;
            else if ( textBox8.Text != "" && textBox8.Text == Logins.username )
                textBox8.Text = "";
        }
        private void button5_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox9.Text ) )
                textBox9.Text = Logins.username;
            else if ( textBox9.Text != "" && textBox9.Text == Logins.username )
                textBox9.Text = "";
        }
        private void button11_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox17.Text ) )
                textBox17.Text = Logins.username;
            else if ( textBox17.Text != "" && textBox17.Text == Logins.username )
                textBox17.Text = "";
        }
        string partName = "", product = "", wages = "", colorNum = "", brand = "";
        private void bandedGridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( bandedGridView1.FocusedRowHandle >= 0 && bandedGridView1.FocusedRowHandle <= bandedGridView1.RowCount - 1 )
            {
                model.IDX = string.IsNullOrEmpty( bandedGridView1.GetFocusedRowCellValue( "idx" ).ToString( ) ) == true ? 0 : Convert.ToInt32( bandedGridView1.GetFocusedRowCellValue( "idx" ).ToString( ) );
                assignMent( );
            }
        }
        void assignMent ( )
        {
            model = bll.GetModel( model.IDX );
            comboBox1.Text = model.LZ015;
            textBox12.Text = model.LZ016;
            comboBox2.Text = model.LZ017;
            textBox11.Text = model.LZ018;
            textBox13.Text = model.LZ019;
            textBox14.Text = model.LZ020.ToString( );
            textBox19.Text = model.LZ021.ToString( );
            textBox20.Text = model.LZ022.ToString( );
            //textBox15.Text = model.LZ025.ToString( );
            //textBox21.Text = model.LZ024.ToString( );
            textBox16.Text = model.LZ023.ToString( );
            textBox22.Text = model.LZ026.ToString( );
            textBox17.Text = model.LZ029;
            textBox18.Text = model.LZ031;
            textBox15.Text = model.LZ033;
            textBox21.Text = model.LZ034.ToString( );
            comboBox3.Text = model.LZ035;
            partName = comboBox1.Text;
            product = comboBox2.Text;
            wages = textBox11.Text;
            colorNum = textBox13.Text;
            brand = textBox18.Text;
        }
        private void textBox1_TextChanged ( object sender ,EventArgs e )
        {
            model.LZ002 = textBox1.Text;
            every( );
        }
        void every ( )
        {
            rearOf = bll.GetDataTableReadOf( model.LZ002 );
            comboBox1.DataSource = rearOf.DefaultView.ToTable( true ,"LZ015" );
            comboBox1.DisplayMember = "LZ015";
            comboBox2.DataSource = rearOf.DefaultView.ToTable( true ,"LZ017" );
            comboBox2.DisplayMember = "LZ017";
        }
        private void comboBox1_TextChanged ( object sender ,EventArgs e )
        {
            if ( comboBox1.Text != "" && rearOf.Select( "LZ015='" + comboBox1.Text + "'" ).Length > 0 )
                comboBox2.Text = rearOf.Select( "LZ015='" + comboBox1.Text + "'" )[0]["LZ017"].ToString( );
        }
        private void GunqiChengLanJiaGong_FormClosing ( object sender ,FormClosingEventArgs e )
        {
            if ( toolSave.Enabled )
            {
                cancel( );
            }
        }
        private void comboBox3_TextChanged ( object sender ,EventArgs e )
        {
            if ( comboBox3.Text == "厂内" )
                textBox21.Text = textBox22.Text = "";
            else if ( comboBox3.Text == "厂外" )
                textBox16.Text = textBox22.Text = "";
            else if ( comboBox3.Text == "桶" )
                textBox21.Text = textBox21.Text = "";
            else
                textBox16.Text = textBox21.Text = textBox22.Text = "";
        }
        #endregion

        #region Main
        protected override void add ( )
        {
            base.add( );

            gridControl1.DataSource = null;
            Ergodic.SpliClear( spList );
            Ergodic.SpliEnableTrue( spList );
            Ergodic.TablePageEnableClear( pageList );
            Ergodic.TablePageEnableTrue( pageList );
            sign = "1";
            textBox10.Enabled = false;
            dateTimePicker1.Enabled = dateTimePicker2.Enabled = false;
            label45.Visible = label46.Visible = false;
            model.LZ001= oddNumbers.purchaseContract( "SELECT MAX(AJ018) AJ018 FROM R_PQAJ" ,"AJ018" ,"R_344-" );

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
            result = bll.DeleteAll( model.LZ001 );
            if ( result == true )
            {
                MessageBox.Show( "成功删除数据" );
                toolSelect.Enabled = toolAdd.Enabled = true;
                toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled =toolLibrary.Enabled=toolStorage.Enabled= false;

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
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled =toolLibrary.Enabled=toolStorage.Enabled= false;
                toolSave.Enabled = toolCancel.Enabled = true;

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

            if ( string.IsNullOrEmpty( textBox1.Text ) )
            {
                MessageBox.Show( "流水号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox17.Text ) )
            {
                MessageBox.Show( "开合同人不可为空" );
                return;
            }
            variableMain( );
            DataTable da = bll.GetDataTableWeiHu( model.LZ001 );
            if ( weihu == "1" )
            {
                if ( da.Rows.Count > 0 )
                {
                    if ( string.IsNullOrEmpty( textBox10.Text ) )
                    {
                        MessageBox.Show( "请填写维护意见" );
                        return;
                    }
                    model.LZ028 = da.Rows[0]["LZ028"].ToString( ) + "[" + Logins.username + MulaolaoBll . Drity . GetDt ( ).ToString( "yyyyMMdd" ) + "]";
                    mainSave( );
                }
            }
            else
            {
                model.LZ028 = "";
                if ( da.Rows.Count > 0 )
                {
                    if ( copy == "1" )
                    {
                        DataTable de = bll.GetDataTableWu( model.LZ001 ,model.LZ002 );
                        if ( de.Rows.Count < 1 )
                            mainSave( );
                        else
                        {
                            for ( int i = 0 ; i < de.Rows.Count ; i++ )
                            {
                                if ( de.Select( "LZ015='" + bandedGridView1.GetDataRow( i )["LZ015"].ToString( ) + "' AND LZ017='" + bandedGridView1.GetDataRow( i )["LZ017"].ToString( ) + "' AND LZ018='" + bandedGridView1.GetDataRow( i )["LZ018"].ToString( ) + "' AND LZ019='" + bandedGridView1.GetDataRow( i )["LZ019"].ToString( ) + "'" ).Length > 0 )
                                {
                                    if ( model.LZ029 == "廖灵飞" )
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
        void saveState ( )
        {
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableFalse( pageList );
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled =toolLibrary.Enabled=toolStorage.Enabled= true;
            toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled = false;
            label46.Visible = false;
            sign = "";
            weihu = "";
            copy = "";
            textBox10.Enabled = false;
        }
        void variableMain ( )
        {
            model.LZ002 = textBox1.Text;
            model.LZ003 = textBox2.Text;
            model.LZ004 = textBox4.Text;
            model.LZ005 = textBox3.Text;
            model.LZ006 = string.IsNullOrEmpty( textBox5.Text ) == true ? 0 : Convert.ToInt64( textBox5.Text );
            model.LZ007 = dateTimePicker1.Value;
            model.LZ008 = dateTimePicker2.Value;
            model.LZ009 = textBox6.Text;
            model.LZ010 = dateTimePicker3.Value;
            model.LZ011 = textBox7.Text;
            model.LZ012 = dateTimePicker4.Value;
            model.LZ013 = textBox9.Text;
            model.LZ014 = dateTimePicker5.Value;
            model.LZ030 = textBox8.Text;
            model.LZ029 = textBox17.Text;
            model.LZ027 = textBox10.Text;
        }
        void mainSave ( )
        {
            result = bll.UpdateAll( model );
            if ( result == true )
            {
                MessageBox.Show( "保存数据成功" );
                saveState( );
            }
            else
                MessageBox.Show( "保存数据失败" );
        }
        protected override void cancel ( )
        {
            base.cancel( );

            if ( sign == "1" && weihu != "1" )
            {
                Ergodic.FormEvery( this );
               
                gridControl1.DataSource = null;
                toolSelect.Enabled = toolAdd.Enabled = true;
                toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled =toolLibrary.Enabled=toolStorage.Enabled= false;
                sign = "";
                weihu = "";
                copy = "";
                textBox13.Enabled = false;
                label45.Visible = label46.Visible = false;
                Ergodic.SpliClear( spList );
                Ergodic.TablePageEnableClear( pageList );
                try
                {
                    bll.DeleteAll( model.LZ001 );
                }
                catch { }
            }
            else
            {
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolMaintain.Enabled = toolcopy.Enabled =toolLibrary.Enabled=toolStorage.Enabled= true;
                toolSave.Enabled = toolCancel.Enabled = false;
            }
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableFalse( pageList );
            textBox10.Enabled = false;
        }
        protected override void print ( )
        {
            base.print( );

            if ( label45.Visible == true )
            {
                createDataSet( );
                file = "";
                file = Application.StartupPath + "\\R_344.frx";
                report.Load( file );
                report.RegisterData( RDataSet );
                report.Show( );
            }
            else
                MessageBox.Show( "非执行单据不能打印" );
        }
        protected override void export ( )
        {
            base.export( );

            createDataSet( );
            file = "";
            file = System.Windows.Forms.Application.StartupPath;
            report.Load( file + "\\R_344.frx" );
            report.RegisterData( RDataSet );
            report.Prepare( );
            XMLExport exprots = new XMLExport( );
            exprots.Export( report );
        }
        protected override void revirw ( )
        {
            base.revirw( );

            Reviews( "LZ001" ,model.LZ001 ,"R_PQLZ" ,this ,"" ,"R_344" ,false ,false,MulaolaoBll . Drity . GetDt ( )/*,"" ,"" ,"" ,"" ,"" ,"" ,"","R_195"*/ );
            SpecialPowers sp = new SpecialPowers( );
            result = sp.reviewImple( "R_344" ,model.LZ001 );
            if ( result == true )
                label45.Visible = true;
            else
                label45.Visible = false;
        }
        protected override void maintain ( )
        {
            base.maintain( );

            if ( label45.Visible == true )
            {
                Ergodic.SpliEnableTrue( spList );
                Ergodic.TablePageEnableTrue( pageList );
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled =toolLibrary.Enabled=toolStorage.Enabled= false;
                toolSave.Enabled = toolCancel.Enabled = true;
                textBox10.Enabled = true;
                weihu = "1";
            }
            else
                MessageBox.Show( "此单据状态为非执行,请更改" );
        }
        protected override void copys ( )
        {
            base.copys( );

            result = bll.Copy( model.LZ001 );
            if ( result == false )
            {
                MessageBox.Show( "复制失败,请重试" );
                return;
            }
            model.LZ001 = oddNumbers.purchaseContract( "SELECT MAX(AJ018) AJ018 FROM R_PQAJ" ,"AJ018" ,"R_344-" );
            result = bll.UpdateCopy( model.LZ001 );
            if ( result == false )
            {
                MessageBox.Show( "复制失败,请重试" );
                bll.DeleteCopy( );
            }
            else
            {
                MessageBox.Show( "复制成功" );
                Ergodic.FormEvery( this );
                gridControl1.DataSource = null;
                Ergodic.SpliEnableTrue( spList );
                Ergodic.TablePageEnableTrue( pageList );
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolcopy.Enabled =toolLibrary.Enabled=toolStorage.Enabled= false;
                toolSave.Enabled = toolCancel.Enabled = true;

                textBox10.Enabled = false;
                sign = "1";
                weihu = "";
                copy = "1";
                label45.Visible = false;
                label46.Visible = true;
                queryContent( );
            }
        }
        #endregion

        #region Table  
        DataRow row;  
        void variable ( )
        {
            model.LZ002 = textBox1.Text;
            model.LZ006 = string.IsNullOrEmpty( textBox5.Text ) == true ? 0 : Convert.ToInt64( textBox5.Text );
            model.LZ029 = textBox17.Text;
            model.LZ015 = comboBox1.Text;
            model.LZ016 = textBox12.Text;
            model.LZ017 = comboBox2.Text;
            model.LZ018 = textBox11.Text;
            model.LZ019 = textBox13.Text;
            model.LZ020 = string.IsNullOrEmpty( textBox14.Text ) == true ? 0 : Convert.ToDecimal( textBox14.Text );
            model.LZ021 = string.IsNullOrEmpty( textBox19.Text ) == true ? 0 : Convert.ToInt32( textBox19.Text );
            model.LZ022 = string.IsNullOrEmpty( textBox20.Text ) == true ? 0 : Convert.ToDecimal( textBox20.Text );
            model.LZ023 = string.IsNullOrEmpty( textBox16.Text ) == true ? 0 : Convert.ToDecimal( textBox16.Text );
            model.LZ024 = 0M; /*string.IsNullOrEmpty( textBox21.Text ) == true ? 0 : Convert.ToDecimal( textBox21.Text );*/
            model.LZ026 = string.IsNullOrEmpty( textBox22.Text ) == true ? 0 : Convert.ToInt32( textBox22.Text );
            model.LZ029 = textBox17.Text;
            model.LZ031 = textBox18.Text;
            model.LZ032 = calculVolume( comboBox2.Text );
            model.LZ033 = textBox15.Text;
            model.LZ034 = string.IsNullOrEmpty( textBox21.Text ) == true ? 0 : Convert.ToDecimal( textBox21.Text );
            model.LZ035 = comboBox3.Text;
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
            catch {
                return false;
            }
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
        void col ( )
        {
            row["LZ006"] = model.LZ006;
            row["LZ015"] = model.LZ015;
            row["LZ016"] = model.LZ016;
            row["LZ017"] = model.LZ017;
            row["LZ018"] = model.LZ018;
            row["LZ019"] = model.LZ019;
            row["LZ020"] = model.LZ020;
            row["LZ021"] = model.LZ021;
            row["LZ022"] = model.LZ022;
            row["LZ023"] = model.LZ023;
            row["LZ024"] = model.LZ024;
            //row["LZ025"] = model.LZ025;
            row["LZ026"] = model.LZ026;
            row["LZ031"] = model.LZ031;
            row["LZ032"] = model.LZ032;
            row["LZ033"] = model.LZ033;
            row["LZ034"] = model.LZ034;
            row["LZ035"] = model.LZ035;
        }
        //Build    
        void build ( )
        {
            model.IDX = bll.Insert( model );
            if ( model.IDX > 0 )
            {
                MessageBox.Show( "录入数据成功" );
                if ( tableQuery == null )
                    button10_Click( null ,null );
                else
                {
                    row = tableQuery.NewRow( );
                    row["idx"] = model.IDX;
                    col( );
                    tableQuery.Rows.Add( row );
                }
            }
            else
                MessageBox.Show( "录入数据失败" );
        }       
        private void button7_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox5.Text ) )
            {
                MessageBox.Show( "产品数量不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox17.Text ) )
            {
                MessageBox.Show( "开合同人不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox1.Text ) )
            {
                MessageBox.Show( "零部件名称不可为空" );
                return;
            }
            if ( !string.IsNullOrEmpty( textBox16.Text ) && Convert.ToDecimal( textBox16.Text ) > 0 && !string.IsNullOrEmpty( textBox21.Text ) && Convert.ToDecimal( textBox21.Text ) > 0 && !string.IsNullOrEmpty( textBox22.Text ) && Convert.ToDecimal( textBox22.Text ) > 0 )
            {
                MessageBox.Show( "工资计划价/斤、委外计划价/斤、按桶计工资只能选一个" );
                return;
            }
            variable( );
            result = bll.Exists( model );
            if ( result == true )
            {
                if ( model.LZ029 == "廖灵飞" )
                    build( );
                else
                    MessageBox.Show( "此单为超补,需要总经理处理" );
            }
            else
                build( );
        }
        //Edit
        void edit ( )
        {
            variable( );
            result = bll.Update( model );
            if ( result == true )
            {
                MessageBox.Show( "编辑数据成功" );
                row = tableQuery.Rows[bandedGridView1.FocusedRowHandle];
                row.BeginEdit( );
                col( );
                row.EndEdit( );
            }
            else
                MessageBox.Show( "编辑数据失败" );
        }
        private void button8_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox5.Text ) )
            {
                MessageBox.Show( "产品数量不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox17.Text ) )
            {
                MessageBox.Show( "开合同人不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox1.Text ) )
            {
                MessageBox.Show( "零部件名称不可为空" );
                return;
            }
            if ( !string.IsNullOrEmpty( textBox16.Text ) && Convert.ToDecimal( textBox16.Text ) > 0 && !string.IsNullOrEmpty( textBox21.Text ) && Convert.ToDecimal( textBox21.Text ) > 0 && !string.IsNullOrEmpty( textBox22.Text ) && Convert.ToDecimal( textBox22.Text ) > 0 )
            {
                MessageBox.Show( "工资计划价/斤、委外计划价/斤、按桶计工资只能选一个" );
                return;
            }
            if ( partName == comboBox1.Text && product == comboBox2.Text && wages == textBox11.Text && colorNum == textBox13.Text && brand==textBox18.Text)
                edit( );
            else
            {
                variable( );
                result = bll.Exists( model );
                if ( result == true )
                {
                    if ( model.LZ029 == "廖灵飞" )
                        edit( );
                    else
                        MessageBox.Show( "此单为超补,需要总经理处理" );
                }
                else
                    edit( );
            }
        }
        //Delete
        private void button9_Click ( object sender ,EventArgs e )
        {
            result = bll.Delete( model );
            if ( result == true )
            {
                MessageBox.Show( "成功删除数据" );
                int num = bandedGridView1.FocusedRowHandle;
                tableQuery.Rows.RemoveAt( num );
            }
            else
                MessageBox.Show( "删除数据失败" );
        }
        //Refresh
        private void button10_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            strWhere = strWhere + " AND LZ001='" + model.LZ001 + "'";
            tableQuery = bll.GetDataTable( strWhere );
            gridControl1.DataSource = tableQuery;
            textBox1_TextChanged( null ,null );
        }
        #endregion

        #region Query
        //Number
        SelectAll.GunQiChengLanNumAll numQuery = new SelectAll.GunQiChengLanNumAll( );
        private void button1_Click ( object sender ,EventArgs e )
        {
            numQuery.StartPosition = FormStartPosition.CenterScreen;
            numQuery.PassDataBetweenForm += new SelectAll.GunQiChengLanNumAll.PassDataBetweenFormHandler( numQuery_PassDataBetweenForm );
            numQuery.sign = "1";
            numQuery.ShowDialog( );
        }
        private void numQuery_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            textBox1.Text = e.ConOne;
            textBox4.Text = e.ConTwo;
            textBox3.Text = e.ConTre;
            textBox2.Text = e.ConFor;
            textBox5.Text = e.ConFiv;
            dateTimePicker1.Value = string.IsNullOrEmpty( e.ConSix ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( e.ConSix );
            dateTimePicker2.Value = string.IsNullOrEmpty( e.ConSev ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( e.ConSev );
        }
        //Table     
        private void button6_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( comboBox3.Text ) )
            {
                MessageBox.Show( "请选择厂内或厂外" );
                return;
            }
            R_FrmR_519select se = new R_FrmR_519select( );
            se.StartPosition = FormStartPosition.CenterScreen;
            se.PassDataBetweenForm += new R_FrmR_519select.PassDataBetweenFormHandler( se_PassDataBetweenForm );
            se.zhi = "6";
            se.ShowDialog( );
        }
        private void se_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            textBox13.Text = e.ConOne;
            textBox11.Text = e.ConTwo;
            textBox12.Text = e.ConTre;
            //textBox14.Text = e.ConFor;
            //textBox15.Text = e.ConFiv;          
            textBox18.Text = e.ConSev;
            if ( comboBox3.Text == "厂内" )
            {
                textBox16.Text = e.ConFiv;
                textBox21.Text = "0";
            }
            else if ( comboBox3.Text == "厂外" )
            {
                textBox21.Text = e.ConEgi;
                textBox16.Text = "0";
            }
            else
                textBox16.Text = textBox21.Text = "0";
        }       
        protected override void select ( )
        {
            base.select( );

            model = new MulaolaoLibrary.GunQiChengLanJiaGongLibrary( );
            SelectAll.GunQiChengLanAll query = new SelectAll.GunQiChengLanAll( );
            query.StartPosition = FormStartPosition.CenterScreen;
            query.PassDataBetweenForm += new SelectAll.GunQiChengLanAll.PassDataBetweenFormHandler( query_PassDataBetweenForm );
            query.ShowDialog( );

            if ( model.LZ001 != null && model.LZ001!="")
                autoQuery( );
            else
                MessageBox.Show( "您没有选择任何内容" );
        }
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
            model = bll.GetModel( model.LZ001 );
            textBox1.Text = model.LZ002;
            textBox2.Text = model.LZ003;
            textBox4.Text = model.LZ004;
            textBox3.Text = model.LZ005;
            textBox5.Text = model.LZ006.ToString( );
            if ( model.LZ007 != null && model.LZ007 > DateTime.MinValue && model.LZ007 < DateTime.MaxValue )
                dateTimePicker1.Value = model.LZ007;
            if ( model.LZ008 != null && model.LZ008 > DateTime.MinValue && model.LZ008 < DateTime.MaxValue )
                dateTimePicker2.Value = model.LZ008;
            textBox17.Text = model.LZ029;
            textBox6.Text = model.LZ009;
            if ( model.LZ010 != null && model.LZ010 > DateTime.MinValue && model.LZ010 < DateTime.MaxValue )
                dateTimePicker3.Value = model.LZ010;
            textBox7.Text = model.LZ011;
            if ( model.LZ012 != null && model.LZ012 > DateTime.MinValue && model.LZ012 < DateTime.MaxValue )
                dateTimePicker4.Value = model.LZ012;
            textBox9.Text = model.LZ013;
            if ( model.LZ014 != null && model.LZ014 > DateTime.MinValue && model.LZ014 < DateTime.MaxValue )
                dateTimePicker5.Value = model.LZ014;
            textBox8.Text = model.LZ030;
            textBox10.Text = model.LZ027;
            textBox18.Text = model.LZ031;

            button10_Click( null ,null );
        }
        private void query_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            model.LZ001 = e.ConOne;
            if ( e.ConTwo == "执行" )
                label45.Visible = true;
            else
                label45.Visible = false;
        }
        #endregion
    }
}

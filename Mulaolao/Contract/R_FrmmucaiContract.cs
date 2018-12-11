using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using Mulaolao.Class;
using StudentMgr;
using Mulaolao.Bom;
using FastReport;
using FastReport.Export.Xml;
using Mulaolao.Raw_material_cost;
using Mulaolao.Schedule_control;
using Mulaolao.Other;
using Mulaolao.Contract.yesOrNoPlan;
using System.Collections.Generic;

namespace Mulaolao.Contract
{
    public partial class R_FrmmucaiContract : FormChild
    {
        public R_FrmmucaiContract ( /*Form1 fm*/ )
        {
            //this.MdiParent = fm;
            InitializeComponent( );

            Logins . tableNum = "R_341";
            Logins . tableName = this . Text;

            GridViewMoHuSelect . SetFilter ( bandedGridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { this . bandedGridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        MulaolaoBll.Bll.MucaiContractBll bll = new MulaolaoBll.Bll.MucaiContractBll( );
        MulaolaoLibrary.MuCaiContractLibrary model = new MulaolaoLibrary.MuCaiContractLibrary( );
        DataTable bi, wpmc, biao, name, libraryTable;
        Report report = new Report( );
        DataSet RDataSet;
        Factory fc = new Factory( );
        SpecialPowers sp = new SpecialPowers( ); List<string> speList = new List<string>( );
        string copy = "", file = "", strWhere = "1=1", sav = "", weihu = "", numQu = "", stateOfOdd = "", conOne = "";
        yesOrNoPlanActual pc = new yesOrNoPlanActual( ); //Dictionary<string ,string> dicStr = new Dictionary<string ,string>( );
        List<SplitContainer> spList = new List<SplitContainer>( ); List<TabPage> pageList = new List<TabPage>( ); int printCount=0;
        
        private void R_FrmmucaiContract_Load ( object sender ,EventArgs e )
        {
            Power( this );

            spList.Clear( );
            spList.AddRange( new SplitContainer[] { splitContainer1 ,splitContainer2 } );
            Ergodic.SpliClear( spList );
            Ergodic.SpliEnableFalse( spList );
            pageList.Clear( );
            pageList.AddRange( new TabPage[] { tabPageOne ,tabPageTwo ,tabPageTre ,tabPageFor } );
            Ergodic.TablePageEnableClear( pageList );
            Ergodic.TablePageEnableFalse( pageList );
            Ergodic.FormEvery( this );
            gridControl1.DataSource = null;

            textBox25.Enabled = false;
            label107.Visible = false;
            label98.Visible = false;

            name = bll.GetDataTablePerson( );
            lookUpEdit1.Properties.DataSource = name;
            lookUpEdit1.Properties.DisplayMember = "DBA002";
            lookUpEdit1.Properties.ValueMember = "DBA001";

            lookUpEdit3.Properties.DataSource = bll.GetDataTableWork( );
            lookUpEdit3.Properties.DisplayMember = "DBA002";
            lookUpEdit3.Properties.ValueMember = "DBA001";

            anOther( );

            if ( Logins.number == "MLL-0001" || Logins.number == "MLL-0007" || Logins.number == "MLL-0008" )
                checkBox2.Visible = true;
            else
                checkBox2.Visible = false;

            comboBox15.Items.Clear( );
            comboBox15.Items.Add( "清水" );
            comboBox15.Items.Add( "混水" );

            if ( Logins.number == "MLL-0001" )
                checkBox1.Visible = true;
            else
                checkBox1.Visible = false;
        }
        
        private void R_FrmmucaiContract_Shown ( object sender ,EventArgs e )
        {
            model.PQV76 = Merges.oddNum;
            if ( !string.IsNullOrEmpty( model.PQV76 ) )
                autoQuery( );
            Merges.oddNum = "";
        }

        #region Print Export
        private void CreateDataset (int startIndex ,int endIndex )
        {
            RDataSet = new DataSet( );
            DataTable print = bll . GetDataTablePrintOne ( model . PQV76 ,startIndex ,endIndex );
            DataTable prints = bll . GetDataTablePrintTwo ( model . PQV76 ,startIndex ,endIndex );
            print.TableName = "R_PQV";
            prints.TableName = "R_PQVS";
            RDataSet.Tables.Add( print );
            RDataSet.Tables.Add( prints );
        }
        #endregion

        #region Event
        void anOther ( )
        {
            DataTable dAn = SqlHelper.ExecuteDataTable( "SELECT PQV25,PQV31,PQV32,PQV34,PQV36,PQV40,PQV54,PQV55 FROM R_PQV" );
            //填写人
            comboBox23.DataSource = dAn.DefaultView.ToTable( true ,"PQV25" );
            comboBox23.DisplayMember = "PQV25";
            //策划人
            comboBox24.DataSource = dAn.DefaultView.ToTable( true ,"PQV31" );
            comboBox24.DisplayMember = "PQV31";
            //检验人
            comboBox25.DataSource = dAn.DefaultView.ToTable( true ,"PQV32" );
            comboBox25.DisplayMember = "PQV32";
            //生产负责人
            comboBox26.DataSource = dAn.DefaultView.ToTable( true ,"PQV34" );
            comboBox26.DisplayMember = "PQV34";
            //检验员
            comboBox28.DataSource = dAn.DefaultView.ToTable( true ,"PQV36" );
            comboBox28.DisplayMember = "PQV36";
            //QC
            comboBox27.DataSource = dAn.DefaultView.ToTable( true ,"PQV40" );
            comboBox27.DisplayMember = "PQV40";
            //甲方
            comboBox29.DataSource = dAn.DefaultView.ToTable( true ,"PQV54" );
            comboBox29.DisplayMember = "PQV54";
            //乙方
            comboBox30.DataSource = dAn.DefaultView.ToTable( true ,"PQV55" );
            comboBox30.DisplayMember = "PQV55";
        }
        //货号
        private void comboBox32_TextChanged ( object sender ,EventArgs e )
        {
            table( );

            getPreCost ( );
        }
        void table ( )
        {
            model . PQV79 = comboBox32 . Text;
            //if ( string . IsNullOrEmpty ( textBox68 . Text ) )
            //    wpmc = SqlHelper . ExecuteDataTable ( "SELECT  DISTINCT GS02 PQV86,GS07 PQV10 FROM R_PQP WHERE GS07 IS NOT NULL AND GS07!='' AND GS70='R_341' AND GS48=@GS48" ,new SqlParameter ( "@GS48" ,model . PQV79 ) );
            if ( !string . IsNullOrEmpty ( textBox68 . Text ) )
            {
                model . PQV01 = textBox68 . Text;
                wpmc = SqlHelper . ExecuteDataTable ( "SELECT  DISTINCT GS02 PQV86,GS07 PQV10 FROM R_PQP WHERE GS07 IS NOT NULL AND GS07!='' AND GS70='R_341' AND GS01=@GS01" ,new SqlParameter ( "@GS01" ,model . PQV01 ) );

                biao = SqlHelper . ExecuteDataTable ( "SELECT '' PQV10,PQV11,PQV12,PQV13,PQV14,PQV15,PQV17,PQV18,PQV19,PQV20,PQV21,PQV22,PQV23,PQV24,PQV64,PQV65,PQV66,PQV67,PQV68,PQV69,PQV70,PQV71,PQV72,PQV73,PQV81,'' PQV86 FROM R_PQV WHERE PQV79=@PQV79" ,new SqlParameter ( "@PQV79" ,model . PQV79 ) );
            }

            if ( string . IsNullOrEmpty ( textBox68 . Text ) )
            {
                biao = SqlHelper . ExecuteDataTable ( "SELECT PQV10,PQV11,PQV12,PQV13,PQV14,PQV15,PQV17,PQV18,PQV19,PQV20,PQV21,PQV22,PQV23,PQV24,PQV64,PQV65,PQV66,PQV67,PQV68,PQV69,PQV70,PQV71,PQV72,PQV73,PQV81,PQV86 FROM R_PQV WHERE PQV79=@PQV79" ,new SqlParameter ( "@PQV79" ,model . PQV79 ) );
            }

            if ( wpmc != null )
                biao . Merge ( wpmc );

            //物料名称
            partInfo . Properties . DataSource = biao . DefaultView . ToTable ( true ,new string [ ] { "PQV10" ,"PQV86" } );
            partInfo . Properties . DisplayMember = "PQV86";
            partInfo . Properties . ValueMember = "PQV86";
            ////材料名称
            //lookUpEdit2 . Properties . DataSource = biao . DefaultView . ToTable ( true ,"PQV86" );
            //lookUpEdit2 . Properties . DisplayMember = "PQV86";
            //每立方米现价
            comboBox12 . DataSource = biao . DefaultView . ToTable ( true ,"PQV11" );
            comboBox12 . DisplayMember = "PQV11";
            //每套部件数量
            comboBox1 . DataSource = biao . DefaultView . ToTable ( true ,"PQV12" );
            comboBox1 . DisplayMember = "PQV12";
            //购规格料条数
            comboBox13 . DataSource = biao . DefaultView . ToTable ( true ,"PQV13" );
            comboBox13 . DisplayMember = "PQV13";
            //不开裂率
            comboBox17 . DataSource = biao . DefaultView . ToTable ( true ,"PQV17" );
            comboBox17 . DisplayMember = "PQV17";
            //碰.压.划伤合格率%
            comboBox19 . DataSource = biao . DefaultView . ToTable ( true ,"PQV18" );
            comboBox19 . DisplayMember = "PQV18";
            //开裂、弯曲、变形合格率%
            comboBox21 . DataSource = biao . DefaultView . ToTable ( true ,"PQV19" );
            comboBox21 . DisplayMember = "PQV19";
            //利边、尖点合格率%
            comboBox20 . DataSource = biao . DefaultView . ToTable ( true ,"PQV21" );
            comboBox20 . DisplayMember = "PQV21";
            //含水率
            comboBox16 . DataSource = biao . DefaultView . ToTable ( true ,"PQV14" );
            comboBox16 . DisplayMember = "PQV14";
            //实际含水率
            comboBox18 . DataSource = biao . DefaultView . ToTable ( true ,"PQV15" );
            comboBox18 . DisplayMember = "PQV15";
            //长
            comboBox3 . DataSource = biao . DefaultView . ToTable ( true ,"PQV66" );
            comboBox3 . DisplayMember = "PQV66";
            //木材宽
            comboBox33 . DataSource = biao . DefaultView . ToTable ( true ,"PQV81" );
            comboBox33 . DisplayMember = "PQV81";
            //高(厚)
            comboBox4 . DataSource = biao . DefaultView . ToTable ( true ,"PQV67" );
            comboBox4 . DisplayMember = "PQV67";
            //长
            comboBox5 . DataSource = biao . DefaultView . ToTable ( true ,"PQV68" );
            comboBox5 . DisplayMember = "PQV68";
            //宽
            comboBox7 . DataSource = biao . DefaultView . ToTable ( true ,"PQV69" );
            comboBox7 . DisplayMember = "PQV69";
            //高(厚)
            comboBox8 . DataSource = biao . DefaultView . ToTable ( true ,"PQV70" );
            comboBox8 . DisplayMember = "PQV70";
            //虫蛀.腐变.节疤合格率%
            comboBox22 . DataSource = biao . DefaultView . ToTable ( true ,"PQV22" );
            comboBox22 . DisplayMember = "PQV22";
            //else
            //{
            //    model.PQV01 = textBox68.Text;
            //    biao = SqlHelper.ExecuteDataTable( "SELECT '' PQV10,PQV11,PQV12,PQV13,PQV14,PQV15,PQV17,PQV18,PQV19,PQV20,PQV21,PQV22,PQV23,PQV24,PQV64,PQV65,PQV66,PQV67,PQV68,PQV69,PQV70,PQV71,PQV72,PQV73,PQV81,PQV86 FROM R_PQV WHERE PQV01=@PQV01" ,new SqlParameter( "@PQV01" ,model.PQV01 ) );
            //}
            //if ( wpmc != null && biao!=null )
            //    biao.Merge( wpmc );
        }
        //干燥度
        private void textBox31_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox31 );
        }
        private void textBox31_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox31 );
        }
        private void textBox31_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox31.Text != "" && !DateDayRegise.foreTwoNum( textBox31 ) )
            {
                this.textBox31.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多两位,如99.99,请重新输入" );
            }
        }
        //板材宽
        private void button16_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( comboBox5.Text ) )
                MessageBox.Show( "半成品规格长不可为空" );
            else
            {
                if ( string.IsNullOrEmpty( comboBox7.Text ) )
                    MessageBox.Show( "半成品规格宽不可为空" );
                else
                {
                    if ( string.IsNullOrEmpty( comboBox8.Text ) )
                        MessageBox.Show( "半成品规格高不可为空" );
                    else
                    {
                        if ( string.IsNullOrEmpty( comboBox1.Text ) )
                            MessageBox.Show( "每套部件数量不可为空" );
                        else
                        {
                            if ( string.IsNullOrEmpty( textBox71.Text ) )
                                MessageBox.Show( "产品数量不可为空" );
                            else
                            {
                                if ( string.IsNullOrEmpty( comboBox3.Text ) )
                                    MessageBox.Show( "毛规格长不可为空" );
                                else
                                {
                                    if ( string.IsNullOrEmpty( comboBox4.Text ) )
                                        MessageBox.Show( "毛规格高不可为空" );
                                    else
                                    {
                                        //产品数量*每套部件数量*半成品规格长*半成品规格宽*半成品规格高*0.000001/(毛规格长*毛规格高)
                                        
                                        textBox32.Text = Math.Round( ( Convert.ToDecimal( textBox71.Text ) * Convert.ToDecimal( comboBox1.Text ) * Convert.ToDecimal( comboBox5.Text ) * Convert.ToDecimal( comboBox7.Text ) * Convert.ToDecimal( comboBox8.Text ) * Convert.ToDecimal( 0.000001 ) ) / ( Convert.ToDecimal( comboBox3.Text ) * Convert.ToDecimal( comboBox4.Text ) ) ,3 ).ToString( );
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        //计算净立方倍率
        private void button15_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( comboBox5.Text ) )
                MessageBox.Show( "半成品毛规格长不可为空" );
            else
            {
                if ( string.IsNullOrEmpty( comboBox7.Text ) )
                    MessageBox.Show( "半成品宽不可为空" );
                else
                {
                    if ( string.IsNullOrEmpty( comboBox8.Text ) )
                        MessageBox.Show( "半成品高不可为空" );
                    else
                    {
                        if ( string.IsNullOrEmpty( textBox35.Text ) )
                            MessageBox.Show( "净规格长不可为空" );
                        else
                        {
                            if ( string.IsNullOrEmpty( textBox36.Text ) )
                                MessageBox.Show( "净规格宽不可为空" );
                            else
                            {
                                if ( string.IsNullOrEmpty( textBox37.Text ) )
                                    MessageBox.Show( "净规格高不可为空" );
                                else
                                {
                                    if ( Convert.ToDecimal( textBox36.Text ) <= 0 || Convert.ToDecimal( textBox35.Text ) <= 0 || Convert.ToDecimal( textBox37.Text ) <= 0 )
                                        textBox29.Text = "";
                                    else
                                        //textBox29.Text = Math.Round( ( Convert.ToDecimal( comboBox3.Text ) * Convert.ToDecimal( comboBox33.Text ) * Convert.ToDecimal( comboBox4.Text ) ) / ( Convert.ToDecimal( textBox35.Text ) * Convert.ToDecimal( textBox36.Text ) * Convert.ToDecimal( textBox37.Text ) * Convert.ToDecimal( 0.000001 ) * Convert.ToInt64( textBox71.Text ) * Convert.ToDecimal( comboBox1.Text ) ) ,2 ).ToString( );
                                        textBox29.Text = Math.Round( ( ( Convert.ToDecimal( comboBox5.Text ) * Convert.ToDecimal( comboBox7.Text ) * Convert.ToDecimal( comboBox8.Text ) ) / ( Convert.ToDecimal( textBox35.Text ) * Convert.ToDecimal( textBox36.Text ) * Convert.ToDecimal( textBox37.Text ) ) ) ,3 ).ToString( );
                                }
                            }
                        }
                    }
                }
            }
        }
        //采购人
        private void lookUpEdit1_EditValueChanged ( object sender ,EventArgs e )
        {
            if ( lookUpEdit1.EditValue != null )
            {
                model.PQV02 = lookUpEdit1.EditValue.ToString( );
                textBox5.Text = name.Select( "DBA001='" + model.PQV02 + "'" )[0]["DBA028"].ToString( );
            }
        }
        //表
        string wp = "";
        decimal pqv6 = 0M, pqv8 = 0M, pqv7 = 0M;
        private void bandedGridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( bandedGridView1.FocusedRowHandle >= 0 && bandedGridView1.FocusedRowHandle <= bandedGridView1.RowCount - 1 )
            {
                model.IDX = string.IsNullOrEmpty( bandedGridView1.GetFocusedRowCellValue( "idx" ).ToString( ) ) == true ? 0 : Convert.ToInt32( bandedGridView1.GetFocusedRowCellValue( "idx" ).ToString( ) );
                assign( );
                dateTimePicker5.Value = string.IsNullOrEmpty( bandedGridView1.GetFocusedRowCellValue( "PQV24" ).ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( bandedGridView1.GetFocusedRowCellValue( "PQV24" ).ToString( ) );
            }
        }
        void assign ( )
        {
            model = bll.GetModel( model.IDX );
            if ( model == null )
                return;
            partInfo . Text = model . PQV86;
            partName . Text = model . PQV10;

            comboBox12 .Text = model.PQV11.ToString( );
            comboBox1.Text = model.PQV12.ToString( );
            comboBox13.Text = model.PQV13.ToString( );
            comboBox16.Text = model.PQV14.ToString( );
            comboBox18.Text = model.PQV15.ToString( );
            comboBox15.Text = model.PQV16;
            comboBox17.Text = model.PQV17.ToString( );
            comboBox19.Text = model.PQV18.ToString( );
            comboBox21.Text = model.PQV19.ToString( );
            comboBox29.Text = model.PQV20.ToString( );
            comboBox20.Text = model.PQV21.ToString( );
            comboBox22.Text = model.PQV22.ToString( );
            if ( model.PQV23.ToString( ) != "0001/1/1 0:00:00" && model.PQV23.ToString( ) != "0001-1-1 0:00:00" && model.PQV23.ToString( ) != "0001.1.1 0:00:00" )
                dateTimePicker4.Value = model.PQV23;
            //if ( model.PQV24.ToString( ) != "0001/1/1 0:00:00" && model.PQV24.ToString( ) != "0001-1-1 0:00:00" && model.PQV24.ToString( ) != "0001.1.1 0:00:00" )
            //    dateTimePicker5.Value = model.PQV24;
            comboBox3.Text = model.PQV66.ToString( );
            comboBox4.Text = model.PQV67.ToString( );
            comboBox5.Text = model.PQV68.ToString( );
            comboBox7.Text = model.PQV69.ToString( );
            comboBox8.Text = model.PQV70.ToString( );
            textBox35.Text = model.PQV71.ToString( );
            textBox36.Text = model.PQV72.ToString( );
            textBox37.Text = model.PQV73.ToString( );
            
            //textBox71.Text = model.PQV80.ToString( );
            comboBox33 .Text = model.PQV81.ToString( );
            if ( model.PQV65.Trim( ) == "库存" )
            {
                radioButton13.Checked = true;
                textBox1.Text = model.PQV64.ToString( );
            }
            else if ( model.PQV65.ToString( ) == "外购" )
            {
                radioButton14.Checked = true;
                textBox28.Text = model.PQV82.ToString( );
            }
            textBox30.Text = model.PQV84.ToString( );
            textBox34 . Text = model . PQV97 . ToString ( );
            wp = model.PQV10;
            pqv6 = model.PQV66;
            pqv8 = model.PQV81;
            pqv7 = model.PQV67;
        }
        //每立方米现价
        private void comboBox12_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox12 );
        }
        private void comboBox12_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox12 );
        }
        private void comboBox12_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox12.Text != "" && !DateDayRegise.sixOne( comboBox12 ) )
            {
                this.comboBox12.Text = "";
                MessageBox.Show( "只允许输入整数部分最多五位,小数部分最多一位,如99999.9,请重新输入" );
            }
        }
        //每套部件数量
        private void comboBox1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //购规格料条数
        private void comboBox13_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //净.毛立方倍率
        private void textBox30_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox30 );
        }
        private void textBox30_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox30 );
        }
        private void textBox30_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox30.Text != "" && !DateDayRegise.fiveThreeNumtb( textBox30 ) )
            {
                this.textBox30.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多三位,如9.99,请重新输入" );
            }
        }
        //使用库存数量
        private void textBox1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox1 );
        }
        private void textBox1_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox1 );
        }
        private void textBox1_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox1.Text != "" && !DateDayRegise.tenForNumber( textBox1 ) )
            {
                this.textBox1.Text = "";
                MessageBox.Show( "只允许输入整数部分最多六位,小数部分最多四位,如999999.9999,请重新输入" );
            }
        }
        //使用库存
        private void radioButton13_CheckedChanged ( object sender ,EventArgs e )
        {
            if ( radioButton13.Checked && ( ord == "实际" || !string.IsNullOrEmpty( textBox68.Text ) ) )
            {
                fc.yesOrNoThrForOneOf( /*comboBox32.Text*/"" ,partInfo.Text ,/*comboBox3.Text + "*" +*/ comboBox4.Text ,textBox27 ,textBox33 ,textBox71.Text );

                string str = textBox27 . Text;
                if (!string.IsNullOrEmpty( str ) && Convert . ToDecimal ( str ) < Convert . ToDecimal ( 0.01 ) )
                    str = 0 . ToString ( );
                textBox28 .Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTbes( comboBox5 ,comboBox7 ,comboBox8 ,textBox71 ,comboBox1 ,str ) ) ,4 ).ToString( );

                textBox1.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTbes( comboBox5 ,comboBox7 ,comboBox8 ,textBox71 ,comboBox1 ) ) ,4 ).ToString( );
            }
        }
        //使用外购
        private void radioButton14_CheckedChanged ( object sender ,EventArgs e )
        {
            if ( radioButton14.Checked && ( ord == "实际" || !string.IsNullOrEmpty( textBox68.Text ) ) )
                get( );
            else
            {
                fc.yesOrNoThrForOneOf( /*comboBox32.Text*/"" ,partInfo.Text ,/*comboBox3.Text + "*" +*/ comboBox4.Text ,textBox27 ,textBox33 ,textBox71.Text );
                textBox28.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTbes( comboBox5 ,comboBox7 ,comboBox8 ,textBox71 ,comboBox1 ) ) ,4 ).ToString( );
                /*Thr * For * Fiv * One * Nin * Convert.ToDecimal( 0.000001 )*/
            }
        }
        void get ( )
        {
            string str = "";
            model.PQV86 = partInfo.Text;
            if ( string.IsNullOrEmpty( comboBox4.Text ) )
                model.PQV67 = 0M;
            else
                model.PQV67 = Convert.ToDecimal( comboBox4.Text );
            DataTable del = SqlHelper.ExecuteDataTable( "SELECT AC18,AC10+ISNULL(AC27,0)-ISNULL(SUM(AD12+ISNULL(AD21,0)),0) AC10 FROM R_PQAC A LEFT JOIN R_PQAD B ON A.AC18=B.AD01 WHERE  AC04=@AC04 AND AC05=convert(varchar(10),@PQV67) GROUP BY AC10,AC18,ISNULL(AC27,0) HAVING AC10+ISNULL(AC27,0)-ISNULL(SUM(AD12+ISNULL(AD21,0)),0)>0" ,new SqlParameter( "@AC04" ,model.PQV86 ) ,new SqlParameter( "@PQV67" ,model.PQV67 ) );
            if ( del.Rows.Count < 1 )
                str = "0";
            else if ( string.IsNullOrEmpty( del.Rows[0]["AC10"].ToString( ) ) )
                str = "0";
            else
                str = del.Rows[0]["AC10"].ToString( );
            textBox27 . Text = str;
            if ( Convert . ToDecimal ( str ) < Convert . ToDecimal ( 0.01 ) )
                str = 0 . ToString ( );
            textBox28 .Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTbes( comboBox5 ,comboBox7 ,comboBox8 ,textBox71 ,comboBox1 ,str ) ) ,4 ).ToString( );
        }
        //使用外购数量
        private void textBox28_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox28 );
        }
        private void textBox28_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox28 );
        }
        private void textBox28_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox28.Text != "" && !DateDayRegise.tenForNumber( textBox28 ) )
            {
                this.textBox28.Text = "";
                MessageBox.Show( "只允许输入整数部分最多六位,小数部分最多四位,如999999.9999,请重新输入" );
            }
        }
        //产品数量
        private void textBox71_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //不开裂率
        private void comboBox17_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //碰.压.划伤合格率%
        private void comboBox19_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //开裂、弯曲、变形合格率%
        private void comboBox21_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //利边、尖点合格率%
        private void comboBox20_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //含水率
        private void comboBox16_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //实际含水率
        private void comboBox18_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //长
        private void comboBox3_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox3 );
        }
        private void comboBox3_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox3 );
        }
        private void comboBox3_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox3.Text != "" && !DateDayRegise.sevenThr( comboBox3 ) && Convert.ToDecimal( comboBox3.Text ) > 0 )
            {
                this.comboBox3.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多三位,如999.999,请重新输入" );
            }

            DateDayRegise.fill( comboBox3 );
            //if ( !string.IsNullOrEmpty( comboBox3.Text ) && Convert.ToDecimal( comboBox3.Text ) < 0 )
            //    comboBox3.Text = "";
        }
        //板材宽
        private void comboBox33_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox33 );
        }
        private void comboBox33_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox33 );
        }
        private void comboBox33_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox33.Text != "" && !DateDayRegise.sevenThr( comboBox33 ) && Convert.ToDecimal( comboBox33.Text ) > 0 )
            {
                this.comboBox33.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多三位,如999.999,请重新输入" );
            }

            DateDayRegise.fills( comboBox33 );
            //if ( !string.IsNullOrEmpty( comboBox33.Text ) && Convert.ToDecimal( comboBox33.Text ) < 0 )
            //    comboBox33.Text = "";
        }
        //高
        private void comboBox4_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox4 );
        }
        private void comboBox4_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox4 );
        }
        private void comboBox4_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox4.Text != "" && !DateDayRegise.sevenThr( comboBox4 ) && Convert.ToDecimal( comboBox4.Text ) > 0 )
            {
                this.comboBox4.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多三位,如999.999,请重新输入" );
            }

            DateDayRegise.fills( comboBox4 );

            //if ( !string.IsNullOrEmpty( comboBox4.Text ) && Convert.ToDecimal( comboBox4.Text ) < 0 )
            //    comboBox4.Text = "";
        }
        //长
        private void comboBox5_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox5 );
        }
        private void comboBox5_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox5 );
            getPreCost ( );
        }
        private void comboBox5_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox5.Text != "" && !DateDayRegise.sixThrNumberCb( comboBox5 ) && Convert.ToDecimal( comboBox5.Text ) > 0 )
            {
                this.comboBox5.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多三位,如999.999,请重新输入" );
            }

            DateDayRegise.fills( comboBox5 );
        }
        //宽
        private void comboBox7_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox7 );
        }
        private void comboBox7_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox7 );
            getPreCost ( );
        }
        private void comboBox7_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox7.Text != "" && !DateDayRegise.sixThrNumberCb( comboBox7 ) && Convert.ToDecimal( comboBox7.Text ) > 0 )
            {
                this.comboBox7.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多三位,如999.999,请重新输入" );
            }

            DateDayRegise.fills( comboBox7 );
        }
        //高
        private void comboBox8_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox8 );
        }
        private void comboBox8_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox8 );
            getPreCost ( );
        }
        private void comboBox8_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox8.Text != "" && !DateDayRegise.sixThrNumberCb( comboBox8 ) && Convert.ToDecimal( comboBox8.Text ) > 0 )
            {
                this.comboBox8.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多三位,如999.999,请重新输入" );
            }
            DateDayRegise.fills( comboBox8 );
        }
        //虫蛀.腐变.节疤合格率%
        private void comboBox22_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //抽查数量
        private void textBox4_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //AQL
        private void textBox11_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox12_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox16_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox20_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox18_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox17_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox23_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox22_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox21_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //窗体关闭
        private void R_FrmmucaiContract_FormClosing ( object sender ,FormClosingEventArgs e )
        {
            if ( toolSave.Enabled )
            {
                cancel( );
            }
        }
        //乙方代表签字
        private void button8_Click ( object sender ,EventArgs e )
        {
            if ( textBox55.Text == "" )
                textBox55.Text = Logins.username;
            else if ( textBox55.Text != "" && textBox55.Text == Logins.username )
                textBox55.Text = "";
        }
        //复核人
        private void button9_Click ( object sender ,EventArgs e )
        {
            if ( textBox54.Text == "" )
                textBox54.Text = Logins.username;
            else if ( textBox54.Text != "" && textBox54.Text == Logins.username )
                textBox54.Text = "";
            dateTimePicker13.Value = MulaolaoBll . Drity . GetDt ( );
        }
        //审批人
        private void button10_Click ( object sender ,EventArgs e )
        {
            if ( textBox53.Text == "" )
                textBox53.Text = Logins.username;
            else if ( textBox53.Text != "" && textBox53.Text == Logins.username )
                textBox53.Text = "";
            dateTimePicker12.Value = MulaolaoBll . Drity . GetDt ( );
        }
        //甲方代表签字
        private void button7_Click ( object sender ,EventArgs e )
        {

        }
        //开合同人
        private void button6_Click ( object sender ,EventArgs e )
        {
            if ( textBox13.Text == "" )
            {
                textBox13.Text = Logins.username;
                model.PQV05 = Logins.username;

                string[] str = new string[2];
                str = oddNumbers.contractBatch( "R_PQV" ,model.PQV05 ,textBox13 ,textBox15 ,"PQV09" );
                if ( str[0] == "" )
                    textBox13.Text = "";
                else
                    model.PQV09 = str[1];
                textBox15.Text = str[1];
            }
            else if ( textBox13.Text != "" && textBox13.Text == Logins.username )
            {
                textBox13.Text = "";
                model.PQV05 = "";
                model.PQV09 = "";
                textBox15.Text = "";
            }
            if ( textBox56.Text == "" )
                textBox56.Text = Logins.username;
            else if ( textBox56.Text != "" && textBox56.Text == Logins.username )
                textBox56.Text = "";

            dateTimePicker14.Value = MulaolaoBll . Drity . GetDt ( );
            dateTimePicker2 . Value = DateTime . Now;
        }
        //成本员
        private void button11_Click ( object sender ,EventArgs e )
        {
            if ( textBox14.Text == "" )
                textBox14.Text = Logins.username;
            else if ( textBox14.Text != "" && textBox14.Text == Logins.username )
                textBox14.Text = "";
            dateTimePicker3 . Value = DateTime . Now;
        }
        //产品名称
        private void comboBox31_SelectedValueChanged ( object sender ,EventArgs e )
        {
            if ( ord == "计划" || string.IsNullOrEmpty( textBox68.Text ) )
            {
                if ( !string.IsNullOrEmpty( comboBox31.Text ) )
                    comboBox32.Text = comboBox31.SelectedValue.ToString( );
            }
        }
        private void partInfo_EditValueChanged ( object sender ,EventArgs e )
        {
            DataRow row = ViewInfo . GetFocusedDataRow ( );
            if ( row == null )
                return;
            partName . Text = row [ "PQV10" ] . ToString ( );

            getPreCost ( );
            getSpe ( );
        }
        private void partName_TextChanged ( object sender ,EventArgs e )
        {
            getPreCost ( );
            getSpe ( );
        }
        private void textBox68_TextChanged ( object sender ,EventArgs e )
        {
            getSpe ( );
            if ( string . IsNullOrEmpty ( textBox68 . Text ) )
                textBox35 . ReadOnly = textBox36 . ReadOnly = textBox37 . ReadOnly = false;
            else
                textBox35 . ReadOnly = textBox36 . ReadOnly = textBox37 . ReadOnly = true;
        }
        void getPreCost ( )
        {
            if ( string . IsNullOrEmpty ( comboBox32 . Text ) )
                return;
            if ( string . IsNullOrEmpty ( partName . Text ) )
                return;
            if ( string . IsNullOrEmpty ( partInfo . Text ) )
                return;
            if ( string . IsNullOrEmpty ( comboBox5 . Text ) )
                return;
            if ( string . IsNullOrEmpty ( comboBox7 . Text ) )
                return;
            if ( string . IsNullOrEmpty ( comboBox8 . Text ) )
                return;
            textBox34 . Text = bll . getPreviousCost ( comboBox32 . Text ,partInfo . Text ,partName . Text ,comboBox5 . Text ,comboBox7 . Text ,comboBox8 . Text ,model . PQV76 ) . ToString ( );
        }
        void getSpe ( )
        {
            if ( string . IsNullOrEmpty ( partName . Text ) )
                return;
            if ( string . IsNullOrEmpty ( partInfo . Text ) )
                return;
            if ( string . IsNullOrEmpty ( textBox68 . Text ) )
                return;
            DataTable dtSpe= bll . getSpe ( textBox68 . Text ,partInfo . Text ,partName . Text );
            if ( dtSpe == null || dtSpe . Rows . Count < 1 )
                return;
            string strSpe = dtSpe . Rows [ 0 ] [ "GS08" ] . ToString ( );
            if ( !string . IsNullOrEmpty ( strSpe ) )
            {
                if ( strSpe . Contains ( "*" ) )
                {
                    string [ ] strInfo = strSpe . Split ( '*' );

                    decimal outResult = 0M;
                    if ( !string . IsNullOrEmpty ( strInfo [ 0 ] ) && decimal . TryParse ( strInfo [ 0 ] ,out outResult ) == true )
                    {
                        textBox35 . Text = ( Convert . ToDecimal ( strInfo [ 0 ] ) / 10 ) . ToString ( );
                    }
                    if ( strInfo . Length > 1 && !string . IsNullOrEmpty ( strInfo [ 1 ] ) && decimal . TryParse ( strInfo [ 1 ] ,out outResult ) == true )
                    {
                        textBox36 . Text = ( Convert . ToDecimal ( strInfo [ 1 ] ) / 10 ) . ToString ( );
                    }
                    if ( strInfo . Length > 2 && !string . IsNullOrEmpty ( strInfo [ 2 ] ) && decimal . TryParse ( strInfo [ 2 ] ,out outResult ) == true )
                    {
                        textBox37 . Text = ( Convert . ToDecimal ( strInfo [ 2 ] ) / 10 ) . ToString ( );
                    }
                }
            }
            string strNum = dtSpe . Rows [ 0 ] [ "GS10" ] . ToString ( );
            if ( string . IsNullOrEmpty ( strNum ) )
                return;
            comboBox1 . Text = Math . Round ( Convert . ToDecimal ( strNum ) ,0 ) . ToString ( );
        }
        #endregion

        #region Main
        //Add
        Order od = new Order( );
        string ord = "";
        void orde ( )
        {
            Ergodic.SpliClear( spList );
            Ergodic.TablePageEnableClear( pageList );
            Ergodic.SpliEnableTrue( spList );
            Ergodic.TablePageEnableTrue( pageList );
            Ergodic.FormEvery( this );
            gridControl1.DataSource = null;

            textBox25.Enabled = false;
            dateTimePicker3.Enabled = dateTimePicker2.Enabled = dateTimePicker5.Enabled = false;
            label98.Visible = label107.Visible = false;
            sav = "1";

            model.PQV76 = oddNumbers.purchaseContract( "SELECT MAX(AJ004) AJ004 FROM R_PQAJ" ,"AJ004" ,"R_341-" );
        }
        protected override void add ( )
        {
            base.add( );

            od.StartPosition = FormStartPosition.CenterScreen;
            od.PassDataBetweenForm += new Order.PassDataBetweenFormHandler( od_PassDataBetweenForm );
            od.ShowDialog( );

            if ( ord == "计划" )
            {
                orde( );
                comboBox31.Enabled = comboBox32.Enabled = true;
                textBox71.Enabled = true;
                button4.Enabled = false;
                button14.Enabled = true;
                //fc.productNumberRthr( comboBox31 );
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
            }
            else if ( ord == "实际" )
            {
                orde( );

                comboBox31.Enabled = comboBox32.Enabled = false;
                textBox71.Enabled = false;
                button4.Enabled = true;
                button14.Enabled = false;
                //comboBox31.DataSource = null;
                //comboBox31.Items.Clear( );
                //comboBox32.DataSource = null;
                //comboBox32.Items.Clear( );
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;

            }
            else if ( ord == "" )
            {
                MessageBox.Show( "请选择计划订单或实际订单" );
                sav = "1";
                model.PQV76 = "";
                toolSelect.Enabled = toolAdd.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
            }

        }
        private void od_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            ord = e.ConOne;
        }
        //Delete
        void dele ( )
        {
            if ( label107.Visible == true )
                stateOfOdd = "维护删除";
            else
            {
                if ( sav == "1" )
                    stateOfOdd = "新增新建";
                else
                    stateOfOdd = "更改新建";
            }

            result = bll.DeleteOddNum( model.PQV76 ,"R_341" ,"木材采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"删除" ,stateOfOdd );
            if ( result == false )
                MessageBox.Show( "删除数据失败" );
            else
            {
                MessageBox.Show( "成功删除数据" );
                Ergodic.SpliClear( spList );
                Ergodic.TablePageEnableClear( pageList );
                Ergodic.SpliEnableFalse( spList );
                Ergodic.TablePageEnableFalse( pageList );
                Ergodic.FormEvery( this );
                gridControl1.DataSource = null;


                toolSelect.Enabled = toolAdd.Enabled = toolPrint.Enabled = toolExport.Enabled = true;
                toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;

                label98.Visible = label107.Visible = false;
                textBox25.Enabled = false;
            }
        }
        protected override void delete ( )
        {
            base.delete( );

            result = bll.ExistsReeviews( model.PQV76 ,"R_341" );
            if ( result == true )
            {
                if ( Logins.number == "MLL-0001" )
                    dele( );
                else
                    MessageBox.Show( "单号:" + model.PQV76 + "的单据状态为执行,不允许删除" );
            }
            else
                dele( );
        }
        //Update
        protected override void update ( )
        {
            base.update( );

            if ( label107.Visible == true )
                MessageBox.Show( "单号:" + model.PQV76 + "的单据状态为执行,不允许更改" );
            else
            {
                sav = "2";
                Ergodic.SpliEnableTrue( spList );
                Ergodic.TablePageEnableTrue( pageList );
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;

                textBox25.Enabled = false;
                dateTimePicker3.Enabled = dateTimePicker2.Enabled = dateTimePicker5.Enabled = false;
                if ( string.IsNullOrEmpty( textBox68.Text ) )
                {
                    comboBox31.Enabled = comboBox32.Enabled = true;
                    textBox71.Enabled = true;
                    button4.Enabled = false;
                    button14.Enabled = true;
                }
                else
                {
                    comboBox31.Enabled = comboBox32.Enabled = false;
                    textBox71.Enabled = false;
                    button4.Enabled = true;
                    button14.Enabled = false;
                }
            }
        }
        //Review
        protected override void revirw ( )
        {
            base.revirw( );
            bool result = false, over = false;
            if ( textBox53.Text == "廖灵飞" )
                result = true;
            else
                result = false;
            if ( string.IsNullOrEmpty( textBox14.Text ) )
                over = false;
            else
                over = true;
            Reviews( "PQV76" ,model.PQV76 ,"R_PQV" ,this ,model.PQV01 ,"" ,result ,over,null/*,"PQV05" ,"PQV62" ,"R_PQV" ,"PQV76" ,PQV76 ,ord ,textBox68.Text ,"R_341"*/ );
            result = false;
            result = sp.reviewImple( "R_341" ,model.PQV76 );
            if ( result == true )
            {
                label107.Visible = true;
                try
                {
                    SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfCopy( "R_PQVC" ,"R_PQV" ,"PQV76" ,model.PQV76 ) );
                    WriteOfReceivablesTo( );
                }
                catch { }
            }
            else
                label107.Visible = false;
        }
        void WriteOfReceivablesTo ( )
        {
            DataTable receiva;
            MulaolaoLibrary.ProductCostSummaryLibrary modelAm = new MulaolaoLibrary.ProductCostSummaryLibrary( );
            receiva = bll.GetDataTableOfReceviable( model.PQV76 );
            if ( receiva != null && receiva.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < receiva.Rows.Count ; i++ )
                {
                    modelAm.AM002 = receiva.Rows[i]["PQV01"].ToString( );

                    modelAm.AM261 = modelAm.AM263 = modelAm.AM265 = modelAm.AM267 = modelAm.AM287 = modelAm.AM288 = modelAm.AM290 = modelAm.AM292 = modelAm.AM294 = modelAm.AM330 = modelAm.AM332 = modelAm.AM333 = modelAm.AM336 = modelAm.AM338 = modelAm.AM343 = modelAm.AM345 = modelAm.AM346 = modelAm.AM349 = modelAm.AM351 = modelAm.AM352 = modelAm.AM355 = modelAm.AM357 = modelAm.AM358 = modelAm.AM361 = modelAm.AM363 = modelAm.AM364 = modelAm.AM367 = modelAm.AM369 = modelAm.AM370 = modelAm.AM373 = modelAm.AM375 = modelAm.AM376 = modelAm.AM379 = modelAm.AM381 = modelAm.AM382 = modelAm.AM385 = modelAm.AM388 = modelAm.AM390 = modelAm.AM391 = 0;
                    modelAm.AM339 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'T' and PQV86='新西兰松' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'T' and PQV86='新西兰松' AND PQV88='F'" ) );
                    modelAm.AM345 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'T' and PQV86='新西兰松' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'T' and PQV86='新西兰松' AND PQV88='T'" ) );

                    modelAm.AM364 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'T' and PQV86='榉木' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'T' and PQV86='榉木' AND PQV88='F'" ) );
                    modelAm.AM390 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'T' and PQV86='榉木' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'T' and PQV86='榉木' AND PQV88='T'" ) );

                    modelAm.AM336 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='外购' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='外购' AND PQV88='F'" ) );
                    modelAm.AM338 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='外购' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='外购' AND PQV88='T'" ) );

                    modelAm.AM358 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='库存' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='库存' AND PQV88='F'" ) );
                    modelAm.AM375 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='库存' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='新西兰松' AND PQV65='库存' AND PQV88='T'" ) );

                    modelAm.AM343 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV88='F'" ) );
                    modelAm.AM351 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV88='T'" ) );

                    //modelAm.AM361 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV16='混水' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV16='混水' AND PQV88='F'" ) );
                    //modelAm.AM381 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV16='混水' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='外购' AND PQV16='混水' AND PQV88='T'" ) );

                    modelAm.AM373 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存'  AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存'  AND PQV88='F'" ) );
                    modelAm.AM287 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存'  AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存'  AND PQV88='T'" ) );

                    //modelAm.AM376 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV16='混水' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV16='混水' AND PQV88='F'" ) );
                    //modelAm.AM267 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV16='混水' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='荷木' AND PQV65='库存' AND PQV16='混水' AND PQV88='T'" ) );

                    modelAm.AM346 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='外购' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='外购' AND PQV88='F'" ) );
                    modelAm.AM357 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='外购' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='外购' AND PQV88='T'" ) );

                    modelAm.AM379 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='库存' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='库存' AND PQV88='F'" ) );
                    modelAm.AM265 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='库存' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='榉木' AND PQV65='库存' AND PQV88='T'" ) );

                    modelAm.AM349 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购'  AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购'  AND PQV88='F'" ) );
                    modelAm.AM363 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购'  AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购'  AND PQV88='T'" ) );

                    //modelAm.AM367 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND PQV16='混水' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND PQV16='混水' AND PQV88='F'" ) );
                    //modelAm.AM294 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND PQV16='混水' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='外购' AND PQV16='混水' AND PQV88='T'" ) );

                    modelAm.AM385 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV88='F'" ) );
                    modelAm.AM382 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV88='T'" ) );

                    //modelAm.AM388 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV16='混水' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV16='混水' AND PQV88='F'" ) );
                    //modelAm.AM263 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV16='混水' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='椴木' AND PQV65='库存' AND PQV16='混水' AND PQV88='T'" ) );

                    modelAm.AM352 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND PQV88='F'" ) );
                    modelAm.AM369 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND PQV88='T'" ) );

                    //modelAm.AM370 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND PQV16='混水' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND PQV16='混水' AND PQV88='F'" ) );
                    //modelAm.AM292 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND PQV16='混水' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='外购' AND PQV16='混水' AND PQV88='T'" ) );

                    modelAm.AM391 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV88='F'" ) );
                    modelAm.AM261 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV88='T'" ) );

                    //modelAm.AM333 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV16='混水' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV16='混水' AND PQV88='F'" ) );
                    //modelAm.AM288 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV16='混水' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='桦木' AND PQV65='库存' AND PQV16='混水' AND PQV88='T'" ) );

                    modelAm.AM355 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='杂木' AND PQV65='外购' AND PQV88='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='杂木' AND PQV65='外购' AND PQV88='F'" ) );
                    modelAm.AM332 = string.IsNullOrEmpty( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='杂木' AND PQV65='外购' AND PQV88='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQV)" ,"PQV01='" + modelAm.AM002 + "' and PQV92= 'F' and PQV86='杂木' AND PQV65='外购' AND PQV88='T'" ) );
                    bll.UpdateOfReceviable( modelAm ,model.PQV76 );
                }
            }
        }
        //Print
        bool result = false;
        void trueOrFalse ( )
        {
            if ( ( string.IsNullOrEmpty( textBox68.Text ) && bandedGridView1.GetDataRow( 0 )["PQV65"].ToString( ) == "外购" ) || ( !string.IsNullOrEmpty( textBox68.Text ) && bandedGridView1.GetDataRow( 0 )["PQV65"].ToString( ) == "库存" ) )
            {
                for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
                {
                    if ( sp.inOut( model.PQV76 ,bandedGridView1.GetDataRow( i )["PQV86"].ToString( ) ,/*bandedGridView1.GetDataRow( i )["idx"].ToString( ) ,*/bandedGridView1.GetDataRow( i )["PQV67"].ToString( ) ) == false )
                    {
                        //所有都不等就是没有出或入
                        result = false;
                        break;
                    }
                    else if ( i == bandedGridView1.RowCount - 1 )
                        result = true;
                }
            }
        }
        protected override void print ( )
        {
            base.print( );
            //sp.panDuan( "PQV05" ,"PQV62" ,"R_PQV" ,"PQV76" ,PQV76 ,ord ,textBox68.Text,"R_341" );

            printCount = bandedGridView1 . DataRowCount;
            if ( printCount % 6 > 0 )
                printCount = printCount / 6 + 1;
            else
                printCount = printCount / 6;

            if ( ( ord == "实际" || !string.IsNullOrEmpty( textBox68.Text ) ) && bandedGridView1.GetDataRow( 0 )["PQV65"].ToString( ) == "外购" )
            {
                if ( label107.Visible == true )
                {
                    MulaolaoBll . ContractAddPrintTime . addTimeToContract ( "R_PQV" ,"PQV95" ,model . PQV76 ,"PQV76" );

                    printC ( );
                }
                else
                    MessageBox.Show( "非执行单据不能打印" );
            }
            else
            {
                trueOrFalse( );
                if ( result == true )
                {
                    MulaolaoBll . ContractAddPrintTime . addTimeToContract ( "R_PQV" ,"PQV95" ,model . PQV76 ,"PQV76" );

                    printC ( );
                }
                else
                    MessageBox.Show( "没有出入库的单据不能打印" );
            }
        }
        //Export
        protected override void export ( )
        {
            base.export( );
            //sp.panDuan( "PQV05" ,"PQV62" ,"R_PQV" ,"PQV76" ,PQV76 ,ord ,textBox68.Text ,"R_341");

            //if ( ( ord == "实际" || !string.IsNullOrEmpty( textBox68.Text ) ) && radioButton14.Checked )
            //{
            //    if ( label107.Visible == true )
            //    {

            printCount = bandedGridView1 . DataRowCount;
            if ( printCount % 6 > 0 )
                printCount = printCount / 6 + 1;
            else
                printCount = printCount / 6;

            for ( int i = 0 ; i < printCount ; i++ )
            {
                CreateDataset ( i * 6 + 1 ,i * 6 + 6 );
                file = "";
                file = System . Windows . Forms . Application . StartupPath;
                report . Load ( file + "\\R_341_mc.frx" );
                report . RegisterData ( RDataSet );
                report . Prepare ( );
                XMLExport exprots = new XMLExport ( );
                exprots . Export ( report );
            }
            //    }
            //    else
            //        MessageBox.Show( "非执行单据不能导出" );
            //}
            //else
            //{
            //    trueOrFalse( );
            //    if ( result == true )
            //    {
            //        CreateDataset( );
            //        report.Load( Environment.CurrentDirectory + "\\R_341_mc.frx" );
            //        report.RegisterData( RDataSet );
            //        report.Prepare( );
            //        XMLExport exprots = new XMLExport( );
            //        exprots.Export( report );
            //    }
            //    else
            //        MessageBox.Show( "没有出入库的单据不能导出" );
            //}
        }
        void printC ( )
        {
            for ( int i = 0 ; i < printCount ; i++ )
            {
                CreateDataset ( i * 6 + 1 ,i * 6 + 6 );
                file = "";
                file = System . Windows . Forms . Application . StartupPath;
                report . Load ( file + "\\R_341_mc.frx" );
                report . RegisterData ( RDataSet );
                report . Show ( );
            }
        }
        //Save
        void saves ( )
        {
            Ergodic.TablePageEnableFalse( pageList );
            Ergodic.SpliEnableFalse( spList );
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;

            textBox25.Enabled = false;
            copy = "";
            weihu = "";
            label98.Visible = false;
        }
        void updates ( )
        {
            result = bll.UpdateWeiHu( model ,"R_341" ,"木材采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"保存" ,stateOfOdd );
            if ( result == false )
                MessageBox.Show( "录入数据失败" );
            else
            {
                MessageBox.Show( "成功录入数据" );
                if ( weihu == "1" )
                {
                    try
                    {
                        SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfCopy( "R_PQVC" ,"R_PQV" ,"PQV76" ,model.PQV76 ) );
                        WriteOfReceivablesTo( );
                    }
                    catch { }
                }
                saves( );
            }
        }
        void vari ( )
        {
            model.PQV01 = textBox68.Text;
            model.PQV02 = lookUpEdit1.EditValue.ToString( );
            model.PQV04 = dateTimePicker1.Value;
            model.PQV05 = textBox13.Text;
            model.PQV06 = dateTimePicker2.Value;
            model.PQV07 = textBox14.Text;
            model.PQV08 = dateTimePicker3.Value;
            model.PQV09 = textBox15.Text;
            model.PQV25 = comboBox23.Text;
            model.PQV26 = dateTimePicker6.Value;
            if ( radioButton1.Checked )
                model.PQV27 = radioButton1.Text;
            else if ( radioButton2.Checked )
                model.PQV27 = radioButton2.Text;
            else
                model.PQV27 = string.Empty;
            if ( radioButton3.Checked )
                model.PQV28 = radioButton3.Text;
            else if ( radioButton4.Checked )
                model.PQV28 = radioButton4.Text;
            else
                model.PQV28 = string.Empty;
            if ( radioButton6.Checked )
            {
                model.PQV29 = radioButton6.Text;
                model.PQV30 = textBox26.Text;
            }
            else if ( radioButton5.Checked )
            {
                model.PQV29 = radioButton5.Text;
                model.PQV30 = string.Empty;
            }
            else
            {
                model.PQV29 = string.Empty;
                model.PQV30 = string.Empty;
            }
            model.PQV31 = comboBox24.Text;
            model.PQV32 = comboBox25.Text;
            model.PQV33 = dateTimePicker7.Value;
            model.PQV34 = comboBox26.Text;
            model.PQV35 = dateTimePicker8.Value;
            model.PQV36 = comboBox28.Text;
            model.PQV37 = dateTimePicker10.Value;
            if ( radioButton8.Checked )
            {
                model.PQV38 = radioButton8.Text;
                model.PQV39 = textBox3.Text;
            }
            else if ( radioButton7.Checked )
            {
                model.PQV38 = radioButton7.Text;
                model.PQV39 = string.Empty;
            }
            else if ( radioButton9.Checked )
            {
                model.PQV38 = radioButton9.Text;
                model.PQV39 = string.Empty;
            }
            else
            {
                model.PQV38 = string.Empty;
                model.PQV39 = string.Empty;
            }
            model.PQV40 = comboBox27.Text;
            model.PQV41 = dateTimePicker9.Value;
            model.PQV42 = string.IsNullOrEmpty( textBox4.Text ) == true ? 0 : Convert.ToInt64( textBox4.Text );
            if ( radioButton12.Checked )
            {
                model.PQV43 = radioButton12.Text;
                model.PQV44 = textBox24.Text;
            }
            else if ( radioButton11.Checked )
            {
                model.PQV43 = radioButton11.Text;
                model.PQV44 = string.Empty;
            }
            else if ( radioButton10.Checked )
            {
                model.PQV43 = radioButton10.Text;
                model.PQV44 = string.Empty;
            }
            else
            {
                model.PQV43 = string.Empty;
                model.PQV44 = string.Empty;
            }
            model.PQV45 = string.IsNullOrEmpty( textBox11.Text ) == true ? 0 : Convert.ToInt64( textBox11.Text );
            model.PQV46 = string.IsNullOrEmpty( textBox12.Text ) == true ? 0 : Convert.ToInt64( textBox12.Text );
            model.PQV47 = string.IsNullOrEmpty( textBox16.Text ) == true ? 0 : Convert.ToInt64( textBox16.Text );
            model.PQV48 = string.IsNullOrEmpty( textBox20.Text ) == true ? 0 : Convert.ToInt64( textBox20.Text );
            model.PQV49 = string.IsNullOrEmpty( textBox18.Text ) == true ? 0 : Convert.ToInt64( textBox18.Text );
            model.PQV50 = string.IsNullOrEmpty( textBox17.Text ) == true ? 0 : Convert.ToInt64( textBox17.Text );
            model.PQV51 = string.IsNullOrEmpty( textBox23.Text ) == true ? 0 : Convert.ToInt64( textBox23.Text );
            model.PQV52 = string.IsNullOrEmpty( textBox22.Text ) == true ? 0 : Convert.ToInt64( textBox22.Text );
            model.PQV53 = string.IsNullOrEmpty( textBox21.Text ) == true ? 0 : Convert.ToInt64( textBox21.Text );
            model.PQV54 = comboBox29.Text;
            model.PQV55 = comboBox30.Text;
            model.PQV56 = dateTimePicker11.Value;
            model.PQV57 = textBox56.Text;
            model.PQV58 = textBox55.Text;
            model.PQV59 = dateTimePicker14.Value;
            model.PQV60 = textBox54.Text;
            model.PQV61 = dateTimePicker13.Value;
            model.PQV62 = textBox53.Text;
            model.PQV63 = dateTimePicker12.Value;
            model.PQV74 = textBox25.Text;
            model.PQV77 = comboBox31.Text;
            model.PQV78 = textBox2.Text;
            model.PQV79 = comboBox32.Text;
            model.PQV80 = string.IsNullOrEmpty( textBox71.Text ) == true ? 0 : Convert.ToInt64( textBox71.Text );
            model.PQV85 = string.IsNullOrEmpty( textBox31.Text ) == true ? 0 : Convert.ToDecimal( textBox31.Text );
            model.PQV87 = string.Empty;
            model.PQV88 = checkBox1.Checked == true ? "T" : "F";
            model.PQV89 = lookUpEdit3.Text;
            model.PQV92 = checkBox2.Checked == true ? "T" : "F";
            model.PQV94 = checkBox3.Checked == true ? "T" : "F";
            if ( ord == "计划" || string.IsNullOrEmpty( textBox68.Text ) )
            {
                model.PQV01 = string.Empty;
                model.PQV78 = string.Empty;
            }
        }
        protected override void save ( )
        {
            base.save( );

            if ( string.IsNullOrEmpty( textBox15.Text ) )
            {
                MessageBox.Show( "合同批号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( lookUpEdit1.Text ) )
            {
                MessageBox.Show( "请选择采购人" );
                return;
            }
            if ( string . IsNullOrEmpty ( model . PQV03 ) || string . IsNullOrEmpty ( textBox19 . Text ) )
            {
                MessageBox . Show ( "请选择供应商" );
                return;
            }

            vari ( );
            DataTable dae = bll.GetDataTableAll( model.PQV76 );
            if ( weihu == "1" )
            {
                if ( string.IsNullOrEmpty( textBox25.Text ) )
                    MessageBox.Show( "请填写维护意见" );
                else
                {
                    stateOfOdd = "维护保存";
                    model.PQV75 = dae.Rows[0]["PQV75"].ToString( ) + "[" + Logins.username + MulaolaoBll . Drity . GetDt ( ).ToString( "yyyyMMdd" ) + "]";
                    updates( );
                }
            }
            else
            {
                if ( sav == "1" )
                    stateOfOdd = "新增保存";
                else
                    stateOfOdd = "更改保存";
                model.PQV75 = string.Empty;
                if ( dae.Rows.Count < 1 )
                    saves( );
                else
                {
                    if ( copy == "1" )
                    {
                        if ( MulaolaoBll . WriteReceivableToGeneralLedger . ExistsSup ( model .PQV03 ) == false )
                        {
                            MessageBox . Show ( "供应商已注销,请核实" );
                            return;
                        }

                        stateOfOdd = "复制保存";

                        DataTable dru = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQV WHERE PQV76!=@PQV76" ,new SqlParameter( "@PQV76" ,model.PQV76 )  /*,new SqlParameter( "@PQV05" ,PQV05 )*/ );
                        if ( dru.Rows.Count < 1 )
                            updates( );
                        else
                        {
                            int proNum = 0;
                            for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
                            {
                                proNum = string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "PQV80" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( bandedGridView1 . GetDataRow ( i ) [ "PQV80" ] );
                                if ( proNum != model . PQV80 )
                                {
                                    MessageBox . Show ( "产品数量不一致,请核实" );
                                    break;
                                }

                                if ( ord == "计划" || string.IsNullOrEmpty( textBox68.Text ) )
                                {
                                    if ( dru.Select( "PQV10='" + bandedGridView1.GetDataRow( i )["PQV10"].ToString( ) + "' AND PQV66='" + bandedGridView1.GetDataRow( i )["PQV66"].ToString( ) + "' AND PQV81='" + bandedGridView1.GetDataRow( i )["PQV81"].ToString( ) + "' AND PQV67='" + bandedGridView1.GetDataRow( i )["PQV67"].ToString( ) + "' AND PQV79='" + model.PQV79 + "'" ).Length > 0 )
                                    {
                                        if ( model.PQV09.Length > 8 && model.PQV09.Substring( 0 ,8 ) == "MLL-0001" )
                                        {
                                            updates( );
                                            break;
                                        }
                                        else
                                        {
                                            ///*\n\r开合同人:" + PQV05 + "*/
                                            MessageBox.Show( "已经存\n\r货号:" + model.PQV79 + "\n\r物料名称:" + bandedGridView1.GetDataRow( i )["PQV10"].ToString( ) + "\n\r规格长:" + bandedGridView1.GetDataRow( i )["PQV66"].ToString( ) + "\n\r规格宽:" + bandedGridView1.GetDataRow( i )["PQV81"].ToString( ) + "\n\r规格高:" + bandedGridView1.GetDataRow( i )["PQV67"].ToString( ) + "\n\r的记录,请核实后再录" );
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        updates( );
                                        break;
                                    }
                                }
                                else if ( ord == "实际" || !string.IsNullOrEmpty( textBox68.Text ) )
                                {
                                    if ( yesOrNoHaveStock( ) == false )
                                        break;
                                    if ( !string . IsNullOrEmpty ( textBox68 . Text ) )
                                    {
                                        if ( checkThisAnd509 ( ) == false )
                                            break;
                                    }
                                    if ( dru.Select( "PQV10='" + bandedGridView1.GetDataRow( i )["PQV10"].ToString( ) + "' AND PQV66='" + bandedGridView1.GetDataRow( i )["PQV66"].ToString( ) + "' AND PQV81='" + bandedGridView1.GetDataRow( i )["PQV81"].ToString( ) + "' AND PQV67='" + bandedGridView1.GetDataRow( i )["PQV67"].ToString( ) + "' AND PQV01='" + model.PQV01 + "'" ).Length > 0 )
                                    {
                                        if ( model.PQV09.Length > 8 && model.PQV09.Substring( 0 ,8 ) == "MLL-0001" )
                                        {
                                            updates( );
                                            break;
                                        }
                                        else
                                        {
                                            //\n\r开合同人:" + PQV05 + "
                                            MessageBox.Show( "已经存\n\r流水号:" + model.PQV01 + "\n\r物料名称:" + bandedGridView1.GetDataRow( i )["PQV10"].ToString( ) + "\n\r规格长:" + bandedGridView1.GetDataRow( i )["PQV66"].ToString( ) + "\n\r规格宽:" + bandedGridView1.GetDataRow( i )["PQV81"].ToString( ) + "\n\r规格高:" + bandedGridView1.GetDataRow( i )["PQV67"].ToString( ) + "\n\r的记录,请核实后再录" );
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
                    }
                    else
                        updates( );
                }
            }
        }
        bool yesOrNoHaveStock ( )
        {
            result = true;
            //PQV65:使用库存OR外购
            //PQV64:物料数量
            //PQV86:物料名称
            //PQV76:规格
            if ( bandedGridView1.RowCount > 0 && bandedGridView1.GetDataRow( 0 )["PQV65"].ToString( ) == "库存" )
            {
                decimal count = 0;
                for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
                {
                    count = 0;
                    count = Convert.ToDecimal( bi.Compute( "SUM(PQV64)" ,"PQV67='" + bandedGridView1.GetDataRow( i )["PQV67"].ToString( ) + "' AND PQV86='" + bandedGridView1.GetDataRow( i )["PQV86"].ToString( ) + "'" ) );
                    result = fc.LibraryOf( count.ToString( ) ,bandedGridView1.GetDataRow( i )["PQV86"].ToString( ) ,bandedGridView1.GetDataRow( i )["PQV67"].ToString( ) );
                    if ( result == false )
                    {
                        MessageBox.Show( "库存数量少于使用库存数量,请核实" );
                        break;
                    }
                    else if ( i == bandedGridView1.RowCount - 1 )
                        result = true;
                }
            }
            return result;
        }
        bool checkThisAnd509 ( )
        {
            result = true;
            model . PQV01 = textBox68 . Text;
            for ( int i = 0 ; i < bandedGridView1 . RowCount ; i++ )
            {
                model . PQV86 = bandedGridView1 . GetDataRow ( i ) [ "PQV86" ] . ToString ( );
                model . PQV10 = bandedGridView1 . GetDataRow ( i ) [ "PQV10" ] . ToString ( );
                model . PQV73 = string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "PQV73" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "PQV73" ] ) * 10;
                result = fc . check341And509 ( model );
                if ( result == false )
                {
                    MessageBox . Show ( "流水号:" + model . PQV01 + "\n\r材料名称:" + model . PQV86 + "\n\r物料或部件名称:" + model . PQV10 + "\n\r部件净规格:" + model . PQV73 + "\n\r与509的数据不对应,请核实" );
                    break;
                }
            }
            return result;
        }
        //Cancel
        protected override void cancel ( )
        {
            base.cancel( );

            if ( sav == "1" && weihu != "1" )
            {
                Ergodic.SpliClear( spList );
                Ergodic.TablePageEnableClear( pageList );
                Ergodic.FormEvery( this );
                gridControl1.DataSource = null;

                toolSelect.Enabled = toolAdd.Enabled = true;
                toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;

                label98.Visible = false;
                try
                {
                    result = bll.DeleteOddNum( model.PQV76 ,"R_341" ,"木材采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"取消" ,"新增取消" );
                }
                catch { }

            }
            else if ( sav == "2" || weihu == "1" )
            {
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = false;
            }
            textBox25.Enabled = false;
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableFalse( pageList );
        }
        //Main
        protected override void maintain ( )
        {
            base.maintain( );

            result = false;
            result = bll.ExistsReeviews( model.PQV76 ,"R_341" );
            if ( result == true )
            {
                Ergodic.SpliEnableTrue( spList );
                Ergodic.TablePageEnableTrue( pageList );
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;

                textBox25.Enabled = true;

                dateTimePicker3.Enabled = dateTimePicker2.Enabled = dateTimePicker5.Enabled = false;

                weihu = "1";
                if ( !string.IsNullOrEmpty( textBox68.Text ) )
                {
                    comboBox31.Enabled = comboBox32.Enabled = false;
                    textBox71.Enabled = false;
                    button4.Enabled = true;
                    button14.Enabled = false;
                }
                else
                {
                    comboBox31.Enabled = comboBox32.Enabled = true;
                    textBox71.Enabled = true;
                    button4.Enabled = false;
                    button14.Enabled = true;
                }
            }
            else
                MessageBox.Show( "此单据没有被执行,只需更改即可,无需维护" );
        }
        //Stroage
        protected override void storage ( )
        {
            base.storage( );

            if ( label107.Visible == false )
            {
                MessageBox.Show( "非执行单据不能入库" );
                return;
            }
            if ( string.IsNullOrEmpty( partInfo.Text ) )
            {
                MessageBox.Show( "物料名称不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox71.Text ) )
            {
                MessageBox.Show( "产品数量不可为空" );
                return;
            }
            if ( bandedGridView1.GetDataRow( 0 )["PQV65"].ToString( ) == "库存" )
            {
                MessageBox.Show( "库存无法入库,请选择出库或更改状态" );
                return;
            }
            if ( bandedGridView1.GetDataRow( 0 )["PQV65"].ToString( ) == "外购" && ( ( ord == "实际" ) || !string.IsNullOrEmpty( textBox68.Text ) ) )
            {
                MessageBox.Show( "实际订单不允许入库" );
                return;
            }
            string costPerSet = "";
            for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
            {
                costPerSet = "";
                costPerSet = Math.Round( Convert.ToDecimal( bandedGridView1.GetDataRow( i )["PQV12"].ToString( ) ) * Convert.ToDecimal( bandedGridView1.GetDataRow( i )["PQV68"].ToString( ) ) * Convert.ToDecimal( bandedGridView1.GetDataRow( i )["PQV69"].ToString( ) ) * Convert.ToDecimal( bandedGridView1.GetDataRow( i )["PQV70"].ToString( ) ) * Convert.ToDecimal( 0.000001 ) ,7 ).ToString( );

                result = fc . StorageThrFouOne341 ( comboBox31 . Text ,comboBox32 . Text ,textBox71 . Text ,bandedGridView1 . GetDataRow ( i ) [ "PQV86" ] . ToString ( ) ,bandedGridView1 . GetDataRow ( i ) [ "PQV67" ] . ToString ( ) ,"套" ,costPerSet ,"" ,bandedGridView1 . GetDataRow ( i ) [ "PQV11" ] . ToString ( ) ,bandedGridView1 . GetDataRow ( i ) [ "PQV82" ] . ToString ( ) ,textBox13 . Text ,dateTimePicker3 . Value ,lookUpEdit1 . Text ,MulaolaoBll . Drity . GetDt ( ) ,model . PQV76 ,bandedGridView1 . GetDataRow ( i ) [ "PQV90" ] . ToString ( ) ,bandedGridView1 . GetDataRow ( i ) [ "PQV91" ] . ToString ( ) ,lookUpEdit3 . Text ,bandedGridView1 . GetDataRow ( i ) [ "PQV66" ] . ToString ( ) + "*" + bandedGridView1 . GetDataRow ( i ) [ "PQV81" ] . ToString ( ) ,textBox19 . Text ,textBox9 . Text );
                if ( result == false )
                {
                    MessageBox.Show( "入库失败" );
                    break;
                }
                else if ( i == bandedGridView1.RowCount - 1 )
                {
                    MessageBox.Show( "入库成功" );
                    try
                    {
                        for ( int k = 0 ; k < bandedGridView1.RowCount ; k++ )
                        {
                            model.IDX = string.IsNullOrEmpty( bandedGridView1.GetDataRow( k )["idx"].ToString( ) ) == true ? 0 : Convert.ToInt32( bandedGridView1.GetDataRow( k )["idx"].ToString( ) );
                            model.PQV90 = string.IsNullOrEmpty( textBox71.Text ) == true ? 0 : Convert.ToInt64( textBox71.Text );
                            model.PQV91 = string.IsNullOrEmpty( bandedGridView1.GetDataRow( k )["PQV82"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( k )["PQV82"].ToString( ) );
                            bll.UpdateStr( model );
                        }
                    }
                    catch { }
                }
            }
        }
        //Library
        protected override void library ( )
        {
            base.library( );

            if ( label107.Visible == false )
            {
                MessageBox.Show( "非执行单据不能出库" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox71.Text ) )
            {
                MessageBox.Show( "产品数量不可为空" );
                return;
            }
            if ( bandedGridView1.GetDataRow( 0 )["PQV65"].ToString( ) == "外购" )
            {
                MessageBox.Show( "外购无法出库,请选择库存或更改状态" );
                return;
            }
            libraryTable = null;
            for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
            {
                if ( libraryTable != null )
                    libraryTable.Rows.Add( new object[] { bandedGridView1.GetDataRow( i )["PQV67"].ToString( ) ,bandedGridView1.GetDataRow( i )["PQV86"].ToString( ) ,Convert.ToDecimal( bandedGridView1.GetDataRow( i )["PQV64"].ToString( ) ) } );
                else
                {
                    libraryTable = new DataTable( "Datas" );
                    libraryTable.Columns.Add( "tOne" ,typeof( System.String ) );
                    libraryTable.Columns.Add( "tTwo" ,typeof( System.String ) );
                    libraryTable.Columns.Add( "tTre" ,typeof( System.Decimal ) );
                    libraryTable.Rows.Add( new object[] { bandedGridView1.GetDataRow( i )["PQV67"].ToString( ) ,bandedGridView1.GetDataRow( i )["PQV86"].ToString( ) ,Convert.ToDecimal( bandedGridView1.GetDataRow( i )["PQV64"].ToString( ) ) } );
                }
            }
            if ( libraryTable.Rows.Count > 0 )
            {
                SelectAll.OutbandChoice outC = new SelectAll.OutbandChoice( );
                outC.libraryTable = libraryTable;
                outC.sign = "R_341";
                outC.oddNum = model.PQV76;
                outC.StartPosition = FormStartPosition.CenterScreen;
                outC.PassDataBetweenForm += new SelectAll.OutbandChoice.PassDataBetweenFormHandler( outC_PassDataBetweenForm );
                outC.ShowDialog( );
            }
            if ( conOne == "2" )
                return;
            int countSum = 0;
            for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
            {
                speList.Clear( );
                string query = "", count = "";
                if ( libraryTable == null )
                    query = count = "";
                if ( libraryTable != null && libraryTable.Rows.Count > 0 )
                {
                    countSum = libraryTable.Select( "tTwo='" + bandedGridView1.GetDataRow( i )["PQV67"].ToString( ) + bandedGridView1.GetDataRow( i )["PQV86"].ToString( ) + "'" ).Length;
                    if ( countSum > 0 )
                    {
                        for ( int k = 0 ; k < countSum ; k++ )
                        {
                            if ( !speList.Contains( libraryTable.Select( "tTwo='" + bandedGridView1.GetDataRow( i )["PQV67"].ToString( ) + bandedGridView1.GetDataRow( i )["PQV86"].ToString( ) + "'" )[k]["tOne"].ToString( ) ) )
                                speList.Add( libraryTable.Select( "tTwo='" + bandedGridView1.GetDataRow( i )["PQV67"].ToString( ) + bandedGridView1.GetDataRow( i )["PQV86"].ToString( ) + "'" )[k]["tOne"].ToString( ) );
                        }
                        if ( speList.Count > 0 )
                        {
                            foreach ( string str in speList )
                            {
                                query = str;
                                //count = libraryTable.Select( "tTwo='" + bandedGridView1.GetDataRow( i )["PQV67"].ToString( ) + bandedGridView1.GetDataRow( i )["PQV86"].ToString( ) + "' AND tOne='" + query + "'" )[0]["tTre"].ToString( );
                                count = libraryTable.Compute( "SUM(tTre)" ,"tTwo='" + bandedGridView1.GetDataRow( i )["PQV67"].ToString( ) + bandedGridView1.GetDataRow( i )["PQV86"].ToString( ) + "'" ).ToString( );

                                result = fc . LibraryThrFouOne ( comboBox31 . Text ,bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ,textBox68 . Text ,textBox71 . Text ,bandedGridView1 . GetDataRow ( i ) [ "PQV86" ] . ToString ( ) ,bandedGridView1 . GetDataRow ( i ) [ "PQV67" ] . ToString ( ) ,"套" ,bandedGridView1 . GetDataRow ( i ) [ "PQV12" ] . ToString ( ) ,"" ,bandedGridView1 . GetDataRow ( i ) [ "PQV11" ] . ToString ( ) ,/*bandedGridView1.GetDataRow( i )["PQV64"].ToString( )*/ count ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,model . PQV76 ,query . ToString ( ) ,lookUpEdit3 . Text );
                                if ( result == false )
                                {
                                    MessageBox.Show( "出库失败" );
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            if ( result == true )
            {
                MessageBox . Show ( "出库成功" );
                //fc . deleteOfLibrary ( speList ,model . PQV76 ,model . PQV01 );
            }
        }
        private void outC_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            libraryTable = new DataTable( );
            conOne = e.ConOne;
            libraryTable = e.TabOne;
        }
        //Copy
        protected override void copys ( )
        {
            base.copys( );

            if ( label107.Visible == true )
                stateOfOdd = "维护复制";
            else
            {
                if ( sav == "1" )
                    stateOfOdd = "新增复制";
                else
                    stateOfOdd = "更改复制";
            }

            result = bll.AddCopy( model.PQV76 ,"R_341" ,"木材采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"复制" ,stateOfOdd );
            if ( result == false )
                MessageBox.Show( "复制失败,请重试" );
            else
            {
                model.PQV76 = oddNumbers.purchaseContract( "SELECT MAX(AJ004) AJ004 FROM R_PQAJ" ,"AJ004" ,"R_341-" );
                result = false;
                result = bll.UpdateCopy( model.PQV76 ,"R_341" ,"木材采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"复制" ,"更改复制单号" );
                if ( result == false )
                {
                    MessageBox.Show( "复制失败,请重试" );
                    bll.DeleteCopy( model.PQV76 );
                }
                else
                {
                    MessageBox.Show( "成功复制此表" );
                    toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                    toolSave.Enabled = toolCancel.Enabled = true;

                    textBox25.Enabled = false;
                    Ergodic.FormEvery( this );
                    Ergodic.SpliEnableTrue( spList );
                    Ergodic.TablePageEnableTrue( pageList );
                    gridControl1.DataSource = null;
                    dateTimePicker5.Enabled = dateTimePicker3.Enabled = dateTimePicker2.Enabled = false;
                    sav = "1";
                    ord = "";
                    copy = "1";
                    weihu = "";
                    label107.Visible = false;
                    queryContent( );
                }
            }
        }
        #endregion

        #region Table
        void variable ( )
        {
            model . PQV01 = textBox68 . Text;
            model . PQV09 = textBox15 . Text;
            model . PQV10 = partName . Text;
            model . PQV11 = string . IsNullOrEmpty ( comboBox12 . Text ) == true ? 0 : Convert . ToDecimal ( comboBox12 . Text );
            model . PQV12 = string . IsNullOrEmpty ( comboBox1 . Text ) == true ? 0 : Convert . ToInt32 ( comboBox1 . Text );
            model . PQV13 = string . IsNullOrEmpty ( comboBox13 . Text ) == true ? 0 : Convert . ToInt32 ( comboBox13 . Text );

            model . PQV14 = string . IsNullOrEmpty ( comboBox16 . Text ) == true ? 0 : Convert . ToInt32 ( comboBox16 . Text );
            model . PQV15 = string . IsNullOrEmpty ( comboBox18 . Text ) == true ? 0 : Convert . ToInt32 ( comboBox18 . Text );
            model . PQV16 = comboBox15 . Text;
            model . PQV17 = string . IsNullOrEmpty ( comboBox17 . Text ) == true ? 0 : Convert . ToInt32 ( comboBox17 . Text );
            model . PQV18 = string . IsNullOrEmpty ( comboBox19 . Text ) == true ? 0 : Convert . ToInt32 ( comboBox19 . Text );
            model . PQV19 = string . IsNullOrEmpty ( comboBox21 . Text ) == true ? 0 : Convert . ToInt32 ( comboBox21 . Text );
            model . PQV20 = string . IsNullOrEmpty ( textBox29 . Text ) == true ? 0 : Convert . ToDecimal ( textBox29 . Text );
            model . PQV21 = string . IsNullOrEmpty ( comboBox20 . Text ) == true ? 0 : Convert . ToInt32 ( comboBox20 . Text );
            model . PQV22 = string . IsNullOrEmpty ( comboBox22 . Text ) == true ? 0 : Convert . ToInt32 ( comboBox22 . Text );
            model . PQV23 = dateTimePicker4 . Value;
            model . PQV24 = dateTimePicker5 . Value;
            model . PQV66 = string . IsNullOrEmpty ( comboBox3 . Text ) == true ? 0 : Convert . ToDecimal ( comboBox3 . Text );
            model . PQV67 = string . IsNullOrEmpty ( comboBox4 . Text ) == true ? 0 : Convert . ToDecimal ( comboBox4 . Text );
            model . PQV68 = string . IsNullOrEmpty ( comboBox5 . Text ) == true ? 0 : Convert . ToDecimal ( comboBox5 . Text );
            model . PQV69 = string . IsNullOrEmpty ( comboBox7 . Text ) == true ? 0 : Convert . ToDecimal ( comboBox7 . Text );
            model . PQV70 = string . IsNullOrEmpty ( comboBox8 . Text ) == true ? 0 : Convert . ToDecimal ( comboBox8 . Text );
            model . PQV71 = string . IsNullOrEmpty ( textBox35 . Text ) == true ? 0 : Convert . ToDecimal ( textBox35 . Text );
            model . PQV72 = string . IsNullOrEmpty ( textBox36 . Text ) == true ? 0 : Convert . ToDecimal ( textBox36 . Text );
            model . PQV73 = string . IsNullOrEmpty ( textBox37 . Text ) == true ? 0 : Convert . ToDecimal ( textBox37 . Text );
            model . PQV77 = comboBox31 . Text;
            model . PQV79 = comboBox32 . Text;
            model . PQV86 = partInfo . Text;
            model . PQV80 = string . IsNullOrEmpty ( textBox71 . Text ) == true ? 0 : Convert . ToInt64 ( textBox71 . Text );
            model . PQV81 = string . IsNullOrEmpty ( comboBox33 . Text ) == true ? 0 : Convert . ToDecimal ( comboBox33 . Text );
            if ( radioButton13 . Checked )
            {
                model . PQV65 = "库存";
                model . PQV64 = string . IsNullOrEmpty ( textBox1 . Text ) == true ? 0 : Convert . ToDecimal ( textBox1 . Text );
                model . PQV82 = 0;
            }
            else if ( radioButton14 . Checked )
            {
                model . PQV65 = "外购";
                model . PQV82 = string . IsNullOrEmpty ( textBox28 . Text ) == true ? 0 : Convert . ToDecimal ( textBox28 . Text );
                model . PQV64 = 0;
            }
            model . PQV84 = string . IsNullOrEmpty ( textBox30 . Text ) == true ? 0 : Convert . ToDecimal ( textBox30 . Text );
            model . PQV97 = string . IsNullOrEmpty ( textBox34 . Text ) == true ? 0 : Convert . ToDecimal ( textBox34 . Text );
        }
        //Build
        void outSources ( )
        {
            if ( radioButton13.Checked )
                MessageBox.Show( "只能开外购合同" );
            else
            {
                string sx = ( Math.Round( Convert.ToDecimal( Operation.MultiTwoTbes( comboBox5 ,comboBox7 ,comboBox8 ,textBox71 ,comboBox1 ) ) ,4 ) ).ToString( );
                if ( !string.IsNullOrEmpty( sx ) && !string.IsNullOrEmpty( textBox28.Text ) )
                {
                    if ( Convert.ToDecimal( sx ) != Convert.ToDecimal( textBox28.Text ) && Convert.ToDecimal(sx)>=Convert.ToDecimal(textBox28.Text)+Convert.ToDecimal(0.01) )
                        MessageBox.Show( "外购数量有误,请核实" );
                    else
                        build( );
                }
            }
        }
        void outSourc ( )
        {
            if ( radioButton13.Checked )
                MessageBox.Show( "只能开外购合同" );
            else
            {
                string sx = ( Math.Round( Convert.ToDecimal( Operation.MultiTwoTbes( comboBox5 ,comboBox7 ,comboBox8 ,textBox71 ,comboBox1 ) ) ,4 ) ).ToString( );
                if ( !string.IsNullOrEmpty( sx ) && !string.IsNullOrEmpty( textBox28.Text ) )
                {
                    if ( Convert . ToDecimal ( sx ) != Convert . ToDecimal ( textBox28 . Text ) && Convert . ToDecimal ( sx ) >= Convert . ToDecimal ( textBox28 . Text ) + Convert . ToDecimal ( 0.01 ) )
                        MessageBox . Show ( "外购数量有误,请核实" );
                    else
                        builds ( );
                }
            }
        }
        void build ( )
        {
            if ( label107.Visible == true )
                stateOfOdd = "维护新建";
            else
            {
                if ( sav == "1" )
                    stateOfOdd = "新增新建";
                else
                    stateOfOdd = "更改新建";
            }
            result = bll.ExistsTable( model );
            if ( result == false )
            {
                result = bll.Add( model ,"R_341" ,"木材采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"新建" ,stateOfOdd );
                if ( result == false )
                    MessageBox.Show( "录入数据失败" );
                else
                {
                    MessageBox.Show( "成功录入数据" );

                    //table( );
                    button12_Click( null ,null );
                }
            }
            else
                MessageBox.Show( "单号：" + model.PQV76 + "\n\r物品或部件名称：" + model.PQV10 + "\n\r毛板长:" + model.PQV66 + "\n\r宽:" + model.PQV81 + "\n\r高:" + model.PQV67 + "\n\r的数据已经存在,请核实后再录入" );
        }
        void builds ( )
        {
            DataTable da = bll.GetDataTableContrast( model );
            if ( da.Rows.Count > 0 )
            {
                if ( da.Select( "PQV68='" + comboBox5.Text + "'" ).Length <= 0 )
                    MessageBox.Show( "半成品规格长与计划订单不一致,应为:" + da.Rows[0]["PQV68"].ToString( ) + "" );
                else
                {
                    if ( da.Select( "PQV69='" + comboBox7.Text + "'" ).Length <= 0 )
                        MessageBox.Show( "半成品规格宽与计划订单不一致,应为:" + da.Rows[0]["PQV69"].ToString( ) + "" );
                    else
                    {
                        if ( da.Select( "PQV70='" + comboBox8.Text + "'" ).Length <= 0 )
                            MessageBox.Show( "半成品规格高与计划订单不一致,应为:" + da.Rows[0]["PQV70"].ToString( ) + "" );
                        else
                        {
                            if ( da.Select( "PQV71='" + textBox35.Text + "'" ).Length <= 0 )
                                MessageBox.Show( "净规格长与计划订单不一致,应为:" + da.Rows[0]["PQV71"].ToString( ) + "" );
                            else
                            {
                                if ( da.Select( "PQV72='" + textBox36.Text + "'" ).Length <= 0 )
                                    MessageBox.Show( "净规格宽与计划订单不一致,应为:" + da.Rows[0]["PQV72"].ToString( ) + "" );
                                else
                                {
                                    if ( da.Select( "PQV73='" + textBox37.Text + "'" ).Length <= 0 )
                                        MessageBox.Show( "净规格高与计划订单不一致,应为:" + da.Rows[0]["PQV73"].ToString( ) + "" );
                                    else
                                        build( );
                                }
                            }
                        }
                    }
                }
            }
            else
                build( );
        }
        void plan ( )
        {
            if ( radioButton14.Checked == true )
            {
                if ( Logins.number == "MLL-0001" )
                {
                    string sx = ( Math.Round( Convert.ToDecimal( Operation.MultiTwoTbes( comboBox5 ,comboBox7 ,comboBox8 ,textBox71 ,comboBox1 ) ) ,4 ) ).ToString( );
                    if ( !string.IsNullOrEmpty( sx ) && !string.IsNullOrEmpty( textBox28.Text ) )
                    {
                        if ( Convert . ToDecimal ( sx ) != Convert . ToDecimal ( textBox28 . Text ) && Convert . ToDecimal ( sx ) >= Convert . ToDecimal ( textBox28 . Text ) + Convert . ToDecimal ( 0.01 ) )
                            MessageBox . Show ( "外购数量有误,请核实" );
                        else
                            build ( );
                    }
                }
                else
                    MessageBox.Show( "库存还有剩余,需要总经理补开" );
            }
            //只能开具库存合同
            else
            {
                if ( !string.IsNullOrEmpty( textBox27.Text ) && !string.IsNullOrEmpty( textBox1.Text ) )
                {
                    if ( Convert.ToDecimal( textBox27.Text ) < Convert.ToDecimal( textBox1.Text ) )
                        MessageBox.Show( "出库数量必须小于库存数量" );
                    //且出库数小于等于库存数量
                    else
                    {
                        string str = ( Math.Round( Convert.ToDecimal( Operation.MultiTwoTbes( comboBox5 ,comboBox7 ,comboBox8 ,textBox71 ,comboBox1 ) ) ,4 ) ).ToString( );
                        if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox1.Text ) )
                            MessageBox.Show( "出库数量有误,请核查" );
                        else
                            builds( );
                    }
                }
            }
        }
        private void button1_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( comboBox32 . Text ) )
            {
                MessageBox . Show ( "货号不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( textBox15 . Text ) )
            {
                MessageBox . Show ( "合同批号不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( model . PQV03 ) || string . IsNullOrEmpty ( textBox19 . Text ) )
            {
                MessageBox . Show ( "请选择供应商" );
                return;
            }
            if ( string . IsNullOrEmpty ( partInfo . Text ) )
            {
                MessageBox . Show ( "请选择材料名称" );
                return;
            }
            if ( string . IsNullOrEmpty ( partName . Text ) )
            {
                MessageBox . Show ( "请选择物品或部件名称" );
                return;
            }
            if ( radioButton13 . Checked == false && radioButton14 . Checked == false )
            {
                MessageBox . Show ( "请选择库存或外购" );
                return;
            }
            if ( dateTimePicker4 . Value < MulaolaoBll . Drity . GetDt ( ) . AddDays ( 5 ) )
            {
                MessageBox . Show ( "约定供期必须在当天的基础上延迟5天" );
                return;
            }
            if ( string . IsNullOrEmpty ( comboBox15 . Text ) )
            {
                MessageBox . Show ( "请选择清水或混水" );
                return;
            }
            variable ( );
            if ( model . PQV13 == 0 )
            {
                MessageBox . Show ( "规格料条数不可为0" );
                return;
            }

            #region 计划  更改新建  无流水号
            if ( ord == "计划" || string . IsNullOrEmpty ( textBox68 . Text ) )
            {
                //计划可以开具多份
                //同货号、物料名称、规格是否已经开过计划订单
                //AC02=@AC02 AND 
                DataTable yesNoAcPlan = bll . GetDataTableYesNoAcPlan ( model );
                //有  继续开  只能开外购  且每张套数  每张单价  原价/m³都必须与第一份计划订单相同
                if ( yesNoAcPlan . Rows . Count > 0 && string . IsNullOrEmpty ( yesNoAcPlan . Rows [ 0 ] [ "AC18" ] . ToString ( ) ) == false )
                {
                    DataTable yesNoAdPlan = bll . GetDataTableYseNoAdPlan ( yesNoAcPlan . Rows [ 0 ] [ "AC18" ] . ToString ( ) );
                    //有
                    if ( yesNoAdPlan . Rows . Count > 0 && !string . IsNullOrEmpty ( yesNoAdPlan . Rows [ 0 ] [ "AD05" ] . ToString ( ) ) )
                    {
                        if ( yesNoAcPlan . Rows [ 0 ] [ "AC03" ] . ToString ( ) == yesNoAdPlan . Rows [ 0 ] [ "AD05" ] . ToString ( ) )
                            outSources ( );
                        else
                        {
                            //开合同人是否是MLL-0001
                            if ( model . PQV09 . Length > 8 && model . PQV09 . Substring ( 0 ,8 ) == "MLL-0001" )
                                outSourc ( );
                            else
                                MessageBox . Show ( "此合同为补开,请找总经理处理" );
                        }
                    }
                    //无  只能开外购
                    else
                    {
                        //开合同人是否是MLL-0001
                        if ( model . PQV09 . Length > 8 && model . PQV09 . Substring ( 0 ,8 ) == "MLL-0001" )
                            outSourc ( );
                        else
                            MessageBox . Show ( "此合同为补开,请找总经理处理" );
                    }
                }
                //无  只能开外购
                else
                    outSources ( );
            }
            #endregion

            #region 实际  更改新建  有流水号
            else if ( ord == "实际" || !string . IsNullOrEmpty ( textBox68 . Text ) )
            {
       

                string sx = ( Math . Round ( Convert . ToDecimal ( Operation . MultiTwoTbes ( comboBox5 ,comboBox7 ,comboBox8 ,textBox71 ,comboBox1 ) ) ,4 ) ) . ToString ( );

                //bool result = pc . PlanActual ( model . PQV86 ,/*PQV066 + "*" + PQV081 + "*" +*/ model . PQV67 . ToString ( ) ,string . Empty );
                bool vode = pc . PlanInDataBaseTree ( model . PQV01 ,model . PQV10 ,model . PQV66 ,model . PQV67 ,model . PQV81 );
                //if ( !string . IsNullOrEmpty ( sx ) && !string . IsNullOrEmpty ( textBox28 . Text ) && Convert . ToDecimal ( sx ) != Convert . ToDecimal ( textBox28 . Text ) && Convert . ToDecimal ( sx ) >= Convert . ToDecimal ( textBox28 . Text ) + Convert . ToDecimal ( 0.01 ) )
                //{
                //    if ( vode == true )
                //        outSources ( );
                //    else
                //    {
                //        if ( model . PQV09 . Length > 8 && model . PQV09 . Substring ( 0 ,8 ) == "MLL-0001" /*Logins.number=="MLL-0001"*/)
                //            outSources ( );
                //        else
                //            MessageBox . Show ( "此单为超补,需要总经理处理" );
                //    }
                //}
                //else
                //{
                if ( vode == true )
                    outSources ( );
                else
                {
                    if ( model . PQV09 . Length > 8 && model . PQV09 . Substring ( 0 ,8 )/*Logins.number*/ == "MLL-0001" )
                        outSources ( );
                    else
                        MessageBox . Show ( "此单为超补,需要总经理处理" );
                }
                //}
            }
            #endregion
        }
        //Edit
        void over ()
        {
            //DataRow row;
            //int num = bandedGridView1.FocusedRowHandle;
            //if ( sav == "1" )
            //{
            //    row = dk.Rows[num];
            //    row.BeginEdit( );
            //    row["PQV10"] = PQV010;
            //    row["PQV11"] = PQV011;
            //    row["PQV12"] = PQV012;
            //    row["PQV13"] = PQV013;
            //    row["PQV14"] = PQV014;
            //    row["PQV15"] = PQV015;
            //    row["PQV16"] = PQV016;
            //    row["PQV17"] = PQV017;
            //    row["PQV18"] = PQV018;
            //    row["PQV19"] = PQV019;
            //    row["PQV20"] = PQV020;
            //    row["PQV21"] = PQV021;
            //    row["PQV22"] = PQV022;
            //    row["PQV23"] = PQV023;
            //    row["PQV24"] = PQV024;
            //    row["PQV64"] = PQV064;
            //    row["PQV65"] = PQV065;
            //    row["PQV66"] = PQV066;
            //    row["PQV67"] = PQV067;
            //    row["PQV68"] = PQV068;
            //    row["PQV69"] = PQV069;
            //    row["PQV70"] = PQV070;
            //    row["PQV71"] = PQV071;
            //    row["PQV72"] = PQV072;
            //    row["PQV73"] = PQV073;
            //    row["PQV80"] = PQV080;
            //    row["PQV81"] = PQV081;
            //    row["PQV82"] = PQV082;
            //    row["PQV84"] = PQV084;
            //    row["PQV86"] = PQV086;
            //    row["PQV88"] = PQV088;
            //    row.EndEdit( );
            //}
            //else if ( sav == "2" )
            //{
            //    row = bi.Rows[num];
            //    row.BeginEdit( );
            //    row["PQV10"] = PQV010;
            //    row["PQV11"] = PQV011;
            //    row["PQV12"] = PQV012;
            //    row["PQV13"] = PQV013;
            //    row["PQV14"] = PQV014;
            //    row["PQV15"] = PQV015;
            //    row["PQV16"] = PQV016;
            //    row["PQV17"] = PQV017;
            //    row["PQV18"] = PQV018;
            //    row["PQV19"] = PQV019;
            //    row["PQV20"] = PQV020;
            //    row["PQV21"] = PQV021;
            //    row["PQV22"] = PQV022;
            //    row["PQV23"] = PQV023;
            //    row["PQV24"] = PQV024;
            //    row["PQV64"] = PQV064;
            //    row["PQV65"] = PQV065;
            //    row["PQV66"] = PQV066;
            //    row["PQV67"] = PQV067;
            //    row["PQV68"] = PQV068;
            //    row["PQV69"] = PQV069;
            //    row["PQV70"] = PQV070;
            //    row["PQV71"] = PQV071;
            //    row["PQV72"] = PQV072;
            //    row["PQV73"] = PQV073;
            //    row["PQV80"] = PQV080;
            //    row["PQV81"] = PQV081;
            //    row["PQV82"] = PQV082;
            //    row["PQV84"] = PQV084;
            //    row["PQV86"] = PQV086;
            //    row["PQV88"] = PQV088;
            //    row.EndEdit( );
            //}

            //table( );
            button12_Click( null ,null );
        }
        void edit ( )
        {
            if ( label107.Visible == true )
                stateOfOdd = "维护编辑";
            else
            {
                if ( sav == "1" )
                    stateOfOdd = "新增编辑";
                else
                    stateOfOdd = "更改编辑";
            }
            result = bll.ExistsTable( model );
            if ( result==false )
            {
                result = false;
                result = bll.Update( model ,"R_341" ,"木材采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"编辑" ,stateOfOdd );
                if ( result==false )
                    MessageBox.Show( "编辑数据失败" );
                else
                {
                    MessageBox.Show( "成功编辑数据" );

                    //over( );
                    button12_Click( null ,null );
                }
            }
            else
                MessageBox.Show( "单号：" + model.PQV76 + "\n\r物品或部件名称：" + model.PQV10 + "\n\r毛板长:" + model.PQV66 + "\n\r宽:" + model.PQV81 + "\n\r高:" + model.PQV67 + "\n\r的数据已经存在,请核实后再录入" );
        }
        void planOrActual ( )
        {
            if ( radioButton13.Checked )
            {
                if ( !string.IsNullOrEmpty( textBox27.Text ) && !string.IsNullOrEmpty( textBox1.Text ) )
                {
                    if ( Convert.ToDecimal( textBox27.Text ) < Convert.ToDecimal( textBox1.Text ) )
                        MessageBox.Show( "出库数量大于库存数量,请更改出库数量" );
                    else
                    {
                        string str= Math.Round( Convert.ToDecimal( Operation.MultiTwoTbes( comboBox5 ,comboBox7 ,comboBox8 ,textBox71 ,comboBox1 ) ) ,4 ).ToString( );
                        if ( !string.IsNullOrEmpty( str ) )
                        {
                            if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox1.Text ) )
                                MessageBox.Show( "出库数量有误,请核查" );
                            else
                                edit( );
                        }
                    }
                }
            }
            else
            {
                string str = Math.Round( Convert.ToDecimal( Operation.MultiTwoTbes( comboBox5 ,comboBox7 ,comboBox8 ,textBox71 ,comboBox1 ) ) ,4 ).ToString( );
                if ( !string.IsNullOrEmpty( str ) && !string.IsNullOrEmpty( textBox28.Text ) )
                {
                    if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox28.Text ) )
                        MessageBox.Show( "外购数量有误,请核查" );
                    else
                    {
                        if ( Logins.number == "MLL-0001" )
                            edit( );
                        else
                        {
                            if ( !string.IsNullOrEmpty( textBox27.Text ) && Convert.ToDecimal( textBox27.Text ) > 0 )
                                MessageBox.Show( "库存数量不为零,不能开外购合同" );
                            else
                                edit( );
                        }
                    }
                        
                }
            }
        }
        void edit_One ( )
        {
            if ( label107.Visible == true )
                stateOfOdd = "维护编辑";
            else
            {
                if ( sav == "1" )
                    stateOfOdd = "新增编辑";
                else
                    stateOfOdd = "更改编辑";
            }
            result = bll.Update( model ,"R_341" ,"木材采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"编辑" ,stateOfOdd );
            if ( result==false )
                MessageBox.Show( "编辑数据失败" );
            else
            {
                MessageBox.Show( "成功编辑数据" );

                //over( );
                button12_Click( null ,null );
            }
        }
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( comboBox32.Text ) )
            {
                MessageBox.Show( "货号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox15.Text ) )
            {
                MessageBox.Show( "合同批号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( partInfo.Text ) )
            {
                MessageBox.Show( "请选择材料名称" );
                return;
            }
            if ( string.IsNullOrEmpty( partName.Text ) )
            {
                MessageBox.Show( "请选择物品或部件名称" );
                return;
            }
            if ( radioButton13.Checked == false && radioButton14.Checked == false )
            {
                MessageBox.Show( "请选择库存或外购" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox15.Text ) )
            {
                MessageBox.Show( "请选择清水或混水" );
                return;
            }
            variable( );
            if ( model . PQV13 == 0 )
            {
                MessageBox . Show ( "规格料条数不可为0" );
                return;
            }

            if ( wp == model.PQV10 && model.PQV66 == pqv6 && model.PQV81 == pqv8 && model.PQV67 == pqv7 )
            {
                if ( radioButton13.Checked )
                {
                    if ( !string.IsNullOrEmpty( textBox27.Text ) && !string.IsNullOrEmpty( textBox1.Text ) )
                    {
                        if ( Convert.ToDecimal( textBox27.Text ) < Convert.ToDecimal( textBox1.Text ) )
                            MessageBox.Show( "出库数量大于库存数量,请修改出库数量" );
                        else
                        {
                            string str = Math.Round( Convert.ToDecimal( Operation.MultiTwoTbes( comboBox5 ,comboBox7 ,comboBox8 ,textBox71 ,comboBox1 ) ) ,4 ).ToString( );
                            if ( !string.IsNullOrEmpty( str ) )
                            {
                                if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox1.Text ) )
                                    MessageBox.Show( "出库数量有误,请核实" );
                                else
                                    edit_One( );
                            }
                        }
                    }
                }
                else
                {
                    string str = Math.Round( Convert.ToDecimal( Operation.MultiTwoTbes( comboBox5 ,comboBox7 ,comboBox8 ,textBox71 ,comboBox1 ) ) ,4 ).ToString( );
                    if ( !string.IsNullOrEmpty( str ) )
                    {
                        if ( Convert . ToDecimal ( str ) != Convert . ToDecimal ( textBox28 . Text ) && Convert . ToDecimal ( str ) >= Convert . ToDecimal ( textBox28 . Text ) + Convert . ToDecimal ( 0.01 ) )
                            MessageBox . Show ( "外购数量有误,请核实" );
                        else
                        {
                            if ( Logins . number == "MLL-0001" )
                                edit_One ( );
                            else
                            {
                                if ( !string . IsNullOrEmpty ( textBox27 . Text ) && textBox27 . Text != "0" && Convert . ToDecimal ( textBox27 . Text ) >= Convert . ToDecimal ( 0.01 ) )
                                    MessageBox . Show ( "库存数量不为零,不能开外购合同" );
                                else
                                    edit_One ( );
                            }
                        }
                    }
                }
            }
            else
            {
                if ( ord == "计划" || string.IsNullOrEmpty( textBox68.Text ) )
                {
                    //AC02=@AC02 AND
                    DataTable plan = bll.GetDataTablePlan( model );
                    if ( plan.Rows.Count > 0 && !string.IsNullOrEmpty( plan.Rows[0]["AD05"].ToString( ) ) && plan.Rows[0]["AD05"].ToString( ) != "0" )
                        //MessageBox.Show( "库存表中已经存在\n\r货号:" + model.PQV79 + "\n\r物料名称:" + model.PQV10 + "\n\r规格:" + model.PQV66 + "*" + model.PQV81 + "*" + model.PQV67 + "\n\r的记录,且入库数量大于出库数量。不允许新建此计划订单" );
                        planOrActual( );
                    else
                        planOrActual( );
                }
                else if ( ord == "实际" || !string.IsNullOrEmpty( textBox68.Text ) )
                {
                    //PQV05=@PQV05 AND 
                    DataTable dwo = bll.GetDataTableDwo( model );
                    if ( dwo.Rows.Count > 0 )
                    {
                        //开过的合同中是否包含此流水(针对可能合批)
                        for ( int k = 0 ; k < dwo.Rows.Count ; k++ )
                        {
                            if ( dwo.Rows[k]["PQV01"].ToString( ).Contains( model.PQV01 ) || model.PQV01.Contains( dwo.Rows[k]["PQV01"].ToString( ) ) )
                            {
                                if ( model.PQV09.Length > 8 && model.PQV09.Substring( 0 ,8 )/*Logins.number*/ == "MLL-0001" )
                                {
                                    planOrActual( );
                                    break;
                                }
                                else
                                {
                                    MessageBox.Show( "此合同为补开,请联系总经理处理" );
                                    break;
                                }
                            }
                            else if ( k == dwo.Rows.Count - 1 )
                                planOrActual( );
                        }
                    }
                    else
                        planOrActual( );
                }
            }
        }
        //Edit Batch 
        SelectAll.NumberEditContract numQuery = new SelectAll.NumberEditContract( );
        private void button17_Click ( object sender ,EventArgs e )
        {
            numQuery.textBox1.Text = textBox71.Text;
            numQuery.StartPosition = FormStartPosition.CenterScreen;
            numQuery.PassDataBetweenForm += new SelectAll.NumberEditContract.PassDataBetweenFormHandler( numQuery_PassDataBetweenForm );
            numQuery.ShowDialog( );
            if ( label107.Visible == true )
                stateOfOdd = "维护批量编辑";
            else
            {
                if ( sav == "1" )
                    stateOfOdd = "新增批量编辑";
                else
                    stateOfOdd = "更改批量编辑";
            }
            if ( numQu == "yes" )
            {
                for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
                {
                    //model.PQV80 = string.IsNullOrEmpty( textBox71.Text ) == true ? 0 : Convert.ToInt64( textBox71.Text );
                    model.PQV65 = bandedGridView1.GetDataRow( i )["PQV65"].ToString( );
                    model.PQV68 = string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["PQV68"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( i )["PQV68"].ToString( ) );
                    model.PQV69 = string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["PQV69"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( i )["PQV69"].ToString( ) );
                    model.PQV70 = string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["PQV70"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( i )["PQV70"].ToString( ) );
                    model.PQV12 = string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["PQV12"].ToString( ) ) == true ? 0 : Convert.ToInt32( bandedGridView1.GetDataRow( i )["PQV12"].ToString( ) );
                    model.IDX = string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["idx"].ToString( ) ) == true ? 0 : Convert.ToInt32( bandedGridView1.GetDataRow( i )["idx"].ToString( ) );
                    if ( model.PQV65 == "外购" )
                    {
                        model.PQV82 = Math.Round( model.PQV68 * model.PQV69 * model.PQV70 * model.PQV80 * model.PQV12 * Convert.ToDecimal( 0.000001 ) ,4 );
                        model.PQV64 = 0;
                    }
                    else if ( model.PQV65 == "库存" )
                    {
                        model.PQV82 = 0;
                        model.PQV64 = Math.Round( model.PQV68 * model.PQV69 * model.PQV70 * model.PQV80 * model.PQV12 * Convert.ToDecimal( 0.000001 ) ,4 );
                    }
                    else
                    {
                        model.PQV64 = 0;
                        model.PQV82 = 0;
                    }

                    result = false;
                    result = bll.UpdateBatch( model ,"R_341" ,"木材采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"批量编辑" ,stateOfOdd );
                    if ( result == false )
                    {
                        MessageBox.Show( "编辑数据失败" );
                        break;
                    }
                    else if ( i == bandedGridView1.RowCount - 1 )
                    {
                        MessageBox.Show( "编辑数据成功" );
                        strWhere = "1=1";
                        strWhere = strWhere + " AND PQV76='" + model.PQV76 + "'";
                        refre( );
                    }
                }
            }
        }
        private void numQuery_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            numQu = e.ConTwo;
            model.PQV80 = string.IsNullOrEmpty( e.ConOne ) == true ? 0 : Convert.ToInt64( e.ConOne );
        }
        //Delete
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                return;
            if ( label107 . Visible == true )
                stateOfOdd = "维护删除";
            else
            {
                if ( sav == "1" )
                    stateOfOdd = "新增删除";
                else
                    stateOfOdd = "更改删除";
            }
            result = bll . Delete ( model . IDX ,"R_341" ,"木材采购合同" ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,"删除" ,stateOfOdd ,model . PQV76 );
            if ( result == false )
                MessageBox . Show ( "删除数据失败" );
            else
            {
                MessageBox . Show ( "删除数据成功" );
                //bi.Rows.Remove( bi.Select( "idx='" + model.IDX + "'" )[0] );
                button12_Click ( null ,null );
            }
        }
        //Refresh
        private void button12_Click( object sender, EventArgs e )
        {
            strWhere = "1=1";
            strWhere = strWhere + " AND PQV76='" + model.PQV76 + "'";
            refre( );

            table ( );
        }
        void refre ( )
        {
            if ( string.IsNullOrEmpty( strWhere ) )
                strWhere = "1=1";
            bi = bll.GetDataTabelTable( strWhere );
            gridControl1.DataSource = bi;
        }
        //Actual receipt date
        yanpinSelect ys = new yanpinSelect( );
        private void button13_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox.Show( "流水号:" + model.PQV01 + "\n\r物料名称:" + partName.Text + "\n\r毛规格长:" + comboBox3.Text + "\n\r宽:" + comboBox33.Text + "\n\r高:" + comboBox4.Text + "\n\r已经到货？" ,"提示" ,MessageBoxButtons.OKCancel ) == DialogResult.OK )
            {
                ys.ysOne = model.PQV76;
                ys.ysTwo = partName . Text;
                ys.ysThr = comboBox3.Text;
                ys.ysFou = comboBox33.Text;
                ys.ysFiv = comboBox4.Text;
                ys.ysSix = "R_341";
                ys.StartPosition = FormStartPosition.CenterScreen;
                ys.ShowDialog( );
            }
        }
        #endregion

        #region Query
        void queryContent ( )
        {
            if ( model . PQV76 != null && model . PQV76 != "" )
            {
                model = bll . GetMo ( model . PQV76 );
                if ( model != null )
                {
                    lookUpEdit1 . Text = name . Select ( "DBA001='" + model . PQV02 + "'" ) . Length > 0 ? name . Select ( "DBA001='" + model . PQV02 + "'" ) [ 0 ] [ "DBA002" ] . ToString ( ) : string . Empty;
                    textBox5 . Text = name . Select ( "DBA001='" + model . PQV02 + "'" ) . Length > 0 ? name . Select ( "DBA001='" + model . PQV02 + "'" ) [ 0 ] [ "DBA028" ] . ToString ( ) : string . Empty;
                    DataTable gongy = bll . GetDataTableSecond ( model . PQV03 );
                    if ( gongy . Rows . Count > 0 )
                    {
                        textBox19 . Text = gongy . Rows [ 0 ] [ "DGA003" ] . ToString ( );
                        textBox6 . Text = gongy . Rows [ 0 ] [ "DGA017" ] . ToString ( );
                        textBox7 . Text = gongy . Rows [ 0 ] [ "DGA008" ] . ToString ( );
                        textBox8 . Text = gongy . Rows [ 0 ] [ "DGA012" ] . ToString ( );
                        textBox9 . Text = gongy . Rows [ 0 ] [ "DGA009" ] . ToString ( );
                        textBox10 . Text = gongy . Rows [ 0 ] [ "DGA011" ] . ToString ( );
                    }

                    textBox68 . Text = model . PQV01;
                    comboBox31 . Text = model . PQV77;
                    textBox2 . Text = model . PQV78;
                    comboBox32 . Text = model . PQV79;
                    textBox71 . Text = model . PQV80 . ToString ( );
                    lookUpEdit3 . Text = model . PQV89;
                    if ( model . PQV04 > DateTime . MinValue && model . PQV04 < DateTime . MaxValue )
                        dateTimePicker1 . Value = model . PQV04;
                    else
                        dateTimePicker1 . Value = DateTime . Now;
                    textBox13 . Text = model . PQV05;
                    if ( model . PQV06 > DateTime . MinValue && model . PQV06 < DateTime . MaxValue )
                        dateTimePicker2 . Value = model . PQV06;
                    else
                        dateTimePicker2 . Value = DateTime . Now;
                    textBox14 . Text = model . PQV07;
                    if ( model . PQV08 > DateTime . MinValue && model . PQV08 < DateTime . MaxValue )
                        dateTimePicker3 . Value = model . PQV08;
                    else
                        dateTimePicker3 . Value = DateTime . Now;
                    textBox15 . Text = model . PQV09;
                    comboBox23 . Text = model . PQV25;
                    if ( model . PQV26 > DateTime . MinValue && model . PQV26 < DateTime . MaxValue )
                        dateTimePicker6 . Value = model . PQV26;
                    else
                        dateTimePicker6 . Value = DateTime . Now;
                    if ( model . PQV27 != null && model . PQV27 . Equals ( radioButton1 . Text ) )
                        radioButton1 . Checked = true;
                    else if ( model . PQV27!=null && model . PQV27 . Equals ( radioButton2 . Text ) )
                        radioButton2 . Checked = true;
                    if ( model . PQV28!=null && model . PQV28 . Equals ( radioButton3 . Text ) )
                        radioButton3 . Checked = true;
                    else if ( model . PQV28 != null && model . PQV28 . Equals ( radioButton4 . Text ) )
                        radioButton4 . Checked = true;
                    if (model.PQV29!=null && model . PQV29 . Equals ( radioButton6 . Text ) )
                    {
                        radioButton6 . Checked = true;
                        textBox26 . Text = model . PQV30;
                    }
                    else if ( model . PQV29 != null && model . PQV29 . Equals ( radioButton5 . Text ) )
                        radioButton5 . Checked = true;
                    comboBox24 . Text = model . PQV31;
                    comboBox25 . Text = model . PQV32;
                    if ( model . PQV33 > DateTime . MinValue && model . PQV33 < DateTime . MaxValue )
                        dateTimePicker7 . Value = model . PQV33;
                    else
                        dateTimePicker7 . Value = DateTime . Now;
                    comboBox26 . Text = model . PQV34;
                    if ( model . PQV35 > DateTime . MinValue && model . PQV35 < DateTime . MaxValue )
                        dateTimePicker8 . Value = model . PQV35;
                    else
                        dateTimePicker8 . Value = DateTime . Now;
                    comboBox28 . Text = model . PQV36;
                    if ( model . PQV37 > DateTime . MinValue && model . PQV37 < DateTime . MaxValue )
                        dateTimePicker10 . Value = model . PQV37;
                    else
                        dateTimePicker10 . Value = DateTime . Now;
                    if ( model . PQV38!=null && model . PQV38 . Equals ( radioButton8 . Text ) )
                    {
                        radioButton8 . Checked = true;
                        textBox3 . Text = model . PQV39;
                    }
                    else if ( model . PQV38 != null && model . PQV38 . Equals ( radioButton7 . Text ) )
                        radioButton7 . Checked = true;
                    else if ( model . PQV38 != null && model . PQV38 . Equals ( radioButton9 . Text ) )
                        radioButton9 . Checked = true;
                    comboBox27 . Text = model . PQV40;
                    if ( model . PQV41 > DateTime . MinValue && model . PQV41 < DateTime . MaxValue )
                        dateTimePicker9 . Value = model . PQV41;
                    else
                        dateTimePicker9 . Value = DateTime . Now;
                    textBox4 . Text = model . PQV42 . ToString ( );
                    if ( model . PQV43!=null && model . PQV43 . Equals ( radioButton12 . Text ) )
                    {
                        radioButton12 . Checked = true;
                        textBox24 . Text = model . PQV44;
                    }
                    else if ( model . PQV43 != null && model . PQV43 . Equals ( radioButton11 . Text ) )
                        radioButton11 . Checked = true;
                    else if ( model . PQV43 != null && model . PQV43 . Equals ( radioButton10 . Text ) )
                        radioButton10 . Checked = true;
                    textBox11 . Text = model . PQV45 . ToString ( );
                    textBox12 . Text = model . PQV46 . ToString ( );
                    textBox16 . Text = model . PQV47 . ToString ( );
                    textBox20 . Text = model . PQV48 . ToString ( );
                    textBox18 . Text = model . PQV49 . ToString ( );
                    textBox17 . Text = model . PQV50 . ToString ( );
                    textBox23 . Text = model . PQV51 . ToString ( );
                    textBox22 . Text = model . PQV52 . ToString ( );
                    textBox21 . Text = model . PQV53 . ToString ( );
                    comboBox29 . Text = model . PQV54;
                    comboBox30 . Text = model . PQV55;
                    if ( model . PQV56 > DateTime . MinValue && model . PQV56 < DateTime . MaxValue )
                        dateTimePicker11 . Value = model . PQV56;
                    else
                        dateTimePicker11 . Value = DateTime . Now;
                    textBox56 . Text = model . PQV57;
                    textBox55 . Text = model . PQV58;
                    if ( model . PQV59 > DateTime . MinValue && model . PQV59 < DateTime . MaxValue )
                        dateTimePicker14 . Value = model . PQV59;
                    else
                        dateTimePicker14 . Value = DateTime . Now;
                    textBox54 . Text = model . PQV60;
                    if ( model . PQV61 > DateTime . MinValue && model . PQV61 < DateTime . MaxValue )
                        dateTimePicker13 . Value = model . PQV61;
                    else
                        dateTimePicker13 . Value = DateTime . Now;
                    textBox53 . Text = model . PQV62;
                    if ( model . PQV63 > DateTime . MinValue && model . PQV63 < DateTime . MaxValue )
                        dateTimePicker12 . Value = model . PQV63;
                    else
                        dateTimePicker12 . Value = DateTime . Now;
                    textBox25 . Text = model . PQV74;
                    textBox31 . Text = model . PQV85 . ToString ( );
                    label98 . Visible = model . PQV87 == null ? false : model . PQV87 . Equals ( "复制" ) ? true : false;
                    checkBox2 . Checked = model . PQV92 == null ? false : model . PQV92 . Trim ( ) . Equals ( "T" ) ? true : false;
                    checkBox3 . Checked = model . PQV94 == null ? false : model . PQV94 . Trim ( ) . Equals ( "T" ) ? true : false;
                    checkBox1 . Checked = model . PQV88 == null ? false : model . PQV88 . Trim ( ) . Equals ( "T" ) ? true : false;

                    strWhere = "1=1";
                    strWhere = strWhere + " AND PQV76='" + model . PQV76 + "'";
                    refre ( );
                }
            }
        }
        void autoQuery ( )
        {
            Ergodic.SpliClear( spList );
            Ergodic.TablePageEnableClear( pageList );
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableFalse( pageList );
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;

            textBox25.Enabled = false;

            sav = "2";
            ord = "";

            queryContent( );
        }
        SelectAll.MucaiContractQueryAll query = new SelectAll.MucaiContractQueryAll( );
        //查询
        protected override void select ( )
        {
            base.select( );

            model = new MulaolaoLibrary.MuCaiContractLibrary( );
            query.StartPosition = FormStartPosition.CenterScreen;
            query.PassDataBetweenForm += new SelectAll.MucaiContractQueryAll.PassDataBetweenFormHandler( query_PassDataBetweenForm );
            query.ShowDialog( );

            if (  model.PQV76 ==null || model.PQV76=="" )
                MessageBox.Show( "您没有选择任何内容" );
            else
                autoQuery( );
        }
        private void query_PassDataBetweenForm( Object sender, PassDataWinFormEventArgs e )
        {
            //comboBox31.Text = e.ConOne;
            model.PQV77 = e.ConOne;
            //textBox2.Text = e.ConTwo;
            model.PQV78 = e.ConTwo;
            //textBox68.Text = e.ConTre;
            model.PQV01 = e.ConTre;
            //PQV02 = e.ConFor;        
            //lookUpEdit1.Text = e.ConFiv;
            model.PQV03 = e.ConSix;
            //textBox19.Text = e.ConSev;
            if(e.ConEgi=="执行")
                label107.Visible = true;
            else
                label107.Visible = false;
            model.PQV76 = e.ConNin;
            model.PQV79 = e.ConTen;
            //comboBox32.Text = e.ConTen;
            if ( e.ConEleven == "" )
                model.PQV80 = 0;
            else
                model.PQV80 = Convert.ToInt64(e.ConEleven);
           // textBox71.Text = e.ConEleven;

            //DataTable wpmc = SqlHelper.ExecuteDataTable( "SELECT  DISTINCT GS02,GS07 FROM R_PQP WHERE GS07 IS NOT NULL AND GS07!='' AND GS01=@GS01 UNION SELECT DISTINCT PQV86,PQV10 FROM R_PQV WHERE PQV10!='' AND PQV10 IS NOT NULL AND PQV01=@PQV01" ,new SqlParameter( "@GS01" ,PQV01 ) ,new SqlParameter( "@PQV01" ,PQV01 ) );
            //DataTable wpmcOne = wpmc.DefaultView.ToTable( true ,"GS07" );
            //partInfo.DataSource = wpmc;
            //partInfo.DisplayMember = "GS07";
            //DataTable wpmcTwo = wpmc.DefaultView.ToTable( true ,"GS02" );
            //lookUpEdit2.DataSource = wpmcTwo;
            //lookUpEdit2.DisplayMember = "GS02";
        }
        //供应商查询
        R_FrmTPADGA tpadga = new R_FrmTPADGA( );
        private void button5_Click( object sender, EventArgs e )
        {
            DataTable did = SqlHelper.ExecuteDataTable( "SELECT DGA001,DGA003,DGA008,DGA011,DGA012,DGA017,DGA009 FROM TPADGA WHERE DGA052='F'" );
            if (did.Rows.Count < 1)
                MessageBox.Show( "没有供应商信息" );
            else
            {
                tpadga.gridControl2.DataSource = did;
                tpadga.st = "2";
                tpadga.Text = "R_341 信息查询";
                tpadga.PassDataBetweenForm += new R_FrmTPADGA.PassDataBetweenFomrHandler( tpadga_PassDataBetweenForm );
                tpadga.StartPosition = FormStartPosition.CenterScreen;
                tpadga.ShowDialog( );
            }
        }
        private void tpadga_PassDataBetweenForm( object sender, PassDataWinFormEventArgs e )
        {
            model.PQV03 = e.ConOne;
            textBox19.Text = e.ConTwo;
            textBox10.Text = e.ConFiv;
            textBox7.Text = e.ConTre;
            textBox9.Text = e.ConFor;
            textBox8.Text = e.ConSix;
            textBox6.Text = e.ConSev;
        }
        //流水号查询
        Youqicaigou yq = new Youqicaigou( );
        private void button4_Click( object sender, EventArgs e )
        {
            DataTable dhr = SqlHelper.ExecuteDataTable( "SELECT PQF01,PQF02,PQF03,PQF04,PQF06,PQF07,PQF08 FROM R_PQF A,R_REVIEWS B,R_MLLCXMC C WHERE A.PQF01 = B.RES06 AND B.RES01 = C.CX01 AND C.CX02 = '订单销售合同(R_001)' AND RES05 = '执行' ORDER BY PQF01 DESC" );
            if (dhr.Rows.Count < 1)
                MessageBox.Show( "没有产品信息" );
            else
            {
                dhr.Columns.Add("check" ,System.Type.GetType("System.Boolean"));
                yq.gridControl1.DataSource = dhr;
                yq.sy = "1";
                yq.Text = "R_341 信息查询";
                yq.PassDataBetweenForm += new Youqicaigou.PassDataBetweenFormHandler( yq_PassDataBetweenForm );
                yq.StartPosition = FormStartPosition.CenterScreen;
                yq.ShowDialog( );
            }
        }
        private void yq_PassDataBetweenForm( object sender, PassDataWinFormEventArgs e )
        {          
            if ( e.ConOne.IndexOf(",") > 0 )
                textBox68.Text = string.Join("," ,e.ConOne.Split(',').Distinct( ).ToArray( ));
            else
                textBox68.Text = e.ConOne;
            model.PQV01 = textBox68.Text;
            if ( e.ConTwo.IndexOf(",") > 0 )
                textBox2.Text = string.Join("," ,e.ConTwo.Split(',').Distinct( ).ToArray( ));
            else
                textBox2.Text = e.ConTwo;
            model.PQV78 = textBox2.Text;
            if ( e.ConTre.IndexOf(",") > 0 )
                comboBox32.Text = string.Join("," ,e.ConTre.Split(',').Distinct( ).ToArray( ));
            else
                comboBox32.Text = e.ConTre;
            model.PQV79 = comboBox32.Text;
            if ( e.ConFor.IndexOf(",") > 0 )
                comboBox31.Text = string.Join("," ,e.ConFor.Split(',').Distinct( ).ToArray( ));
            else
                comboBox31.Text = e.ConFor;
            model.PQV77 = comboBox31.Text;
            if ( !string.IsNullOrEmpty( e.ConFor ) )
                model.PQV80 = Convert.ToInt64( e.ConFiv );
            else
                model.PQV80 = 0;
            textBox71.Text = e.ConFiv;          
        }
        //计划查询
        planeQuery pq = new planeQuery( );
        private void button14_Click ( object sender ,EventArgs e )
        {
            DataTable plq = SqlHelper.ExecuteDataTable( "SELECT DISTINCT PQF03,PQF04,PQF06 FROM R_PQF A,R_MLLCXMC B,R_REVIEWS C WHERE A.PQF01 = C.RES06 AND B.CX01 = C.RES01 AND RES05 = '执行' AND CX02 = '订单销售合同(R_001)' ORDER BY PQF04" );
            if ( plq.Rows.Count > 0 )
            {
                pq.Text = "R_341 信息查询";
                pq.gridControl1.DataSource = plq;
                pq.StartPosition = FormStartPosition.CenterScreen;
                pq.PassDataBetweenForm += new planeQuery.PassDataBetweenFormHandler( pq_PassDataBetweenForm );
                pq.ShowDialog( );
            }
        }
        void pq_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            textBox68.Text = "";
            model.PQV77 = e.ConOne;
            comboBox31.Text = e.ConOne;
            model.PQV79 = e.ConTwo;
            comboBox32.Text = e.ConTwo;
            if ( !string.IsNullOrEmpty( e.ConTre ) )
                model.PQV80 = Convert.ToInt64( e.ConTre );
            else
                model.PQV80 = 0;
            textBox71.Text = e.ConTre;
            textBox2.Text = "";
        }
        #endregion

    }
}

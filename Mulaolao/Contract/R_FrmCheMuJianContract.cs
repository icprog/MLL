using Mulaolao . Class;
using StudentMgr;
using System;
using System . Data;
using System . Linq;
using System . Windows . Forms;
using System . Data . SqlClient;
using Mulaolao . Bom;
using Mulaolao . Other;
using Mulaolao . Raw_material_cost;
using Mulaolao . Schedule_control;
using FastReport;
using FastReport . Export . Xml;
using Mulaolao . Contract . yesOrNoPlan;
using System . Text;
using System . Collections . Generic;

namespace Mulaolao . Contract
{
    public partial class R_FrmCheMuJianContract : FormChild
    {
        public R_FrmCheMuJianContract ( /*Form1 fm */)
        {
            //this.MdiParent = fm;
            InitializeComponent( );
            
            Logins . tableNum = "R_342";
            Logins . tableName = this . Text;

            GridViewMoHuSelect . SetFilter ( bandedGridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { bandedGridView1  } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        MulaolaoLibrary.CheMuJianContractLibrary cmj = new MulaolaoLibrary.CheMuJianContractLibrary( );
        MulaolaoBll.Bll.CheMuJiancontractBll bll = new MulaolaoBll.Bll.CheMuJiancontractBll( );
        Factory fc = new Factory( );
        DataTable tableSele, wpmc, name, libraryTable;
        string saer = "", mainTain = "", copy = "", numQu = "", stateOfOdd = "", conOne = "", file = "";int printCount=0;
        Report report = new Report( );
        DataSet RDataSet;
        DataTable biao;
        SpecialPowers sp = new SpecialPowers( );
        yesOrNoPlanActual pc = new yesOrNoPlanActual( );
        //Dictionary<string ,string> dicStr = new Dictionary<string ,string>( );
        List<SplitContainer> spList = new List<SplitContainer>( );
        List<TabPage> pageList = new List<TabPage>( ); List<string> speList = new List<string>( );
        
        private void R_FrmCheMuJianContract_Load ( object sender ,EventArgs e )
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

            label107.Visible = false;
            label98.Visible = false;
            textBox25.Enabled = false;

            name = bll.GetDataTablePerson( );
            lookUpEdit1.Properties.DataSource = name;
            lookUpEdit1.Properties.DisplayMember = "DBA002";
            lookUpEdit1.Properties.ValueMember = "DBA001";

            lookUpEdit2.Properties.DataSource = bll.GetDataTableWork( );
            lookUpEdit2.Properties.DisplayMember = "DBA002";
            lookUpEdit2.Properties.ValueMember = "DBA001";
            anOther( );

            comboBox15.Items.Clear( );
            comboBox15.Items.Add( "清水" );
            comboBox15.Items.Add( "混水" );

            if ( Logins.number == "MLL-0001" )
                checkBox1.Visible = true;
            else
                checkBox1.Visible = false;
        }
        
        private void R_FrmCheMuJianContract_Shown ( object sender ,EventArgs e )
        {
            cmj.AF001 = Merges.oddNum;
            if ( !string.IsNullOrEmpty( cmj.AF001 ) )
                autoQuery( );
            Merges.oddNum = "";
        }

        #region Print Export
        void Create (int startIndex,int endIndex )
        {
            RDataSet = new DataSet( );
            DataTable print = bll . GetDataTablePrintOne ( cmj . AF001 ,startIndex ,endIndex );
            DataTable printe = bll . GetDataTablePrintTwo ( cmj . AF001 ,startIndex ,endIndex );
            DataTable prints = bll . GetDataTablePrintThr ( cmj . AF001 );
            print.TableName = "R_PQAF";
            printe.TableName = "R_PQAFE";
            prints.TableName = "R_PQAFS";
            RDataSet.Tables.Add( print );
            RDataSet.Tables.Add( printe );
            RDataSet.Tables.Add( prints );
        }
        #endregion

        #region 事件
        void anOther ( )
        {
            DataTable dAn = SqlHelper.ExecuteDataTable( "SELECT AF035,AF041,AF042,AF044,AF048,AF050,AF064,AF065 FROM R_PQAF" );
            //选填人
            comboBox23.DataSource = dAn.DefaultView.ToTable( true ,"AF035" );
            comboBox23.DisplayMember = "AF035";
            //标准策划人
            comboBox24.DataSource = dAn.DefaultView.ToTable( true ,"AF041" );
            comboBox24.DisplayMember = "AF041";
            //检验人
            comboBox25.DataSource = dAn.DefaultView.ToTable( true ,"AF042" );
            comboBox25.DisplayMember = "AF042";
            //生产负责人
            comboBox26.DataSource = dAn.DefaultView.ToTable( true ,"AF044" );
            comboBox26.DisplayMember = "AF044";
            //检验员
            comboBox28.DataSource = dAn.DefaultView.ToTable( true ,"AF048" );
            comboBox28.DisplayMember = "AF048";
            //QC
            comboBox27.DataSource = dAn.DefaultView.ToTable( true ,"AF050" );
            comboBox27.DisplayMember = "AF050";
            //甲方
            comboBox29.DataSource = dAn.DefaultView.ToTable( true ,"AF064" );
            comboBox29.DisplayMember = "AF064";
            //乙方
            comboBox30.DataSource = dAn.DefaultView.ToTable( true ,"AF065" );
            comboBox30.DisplayMember = "AF065";
        }
        //货号
        private void comboBox32_TextChanged ( object sender ,EventArgs e )
        {
            every( );
        }
        void every ( )
        {
            cmj . AF004 = comboBox32 . Text;
            if ( !string . IsNullOrEmpty ( textBox68 . Text ) )
            {
                cmj . AF002 = textBox68 . Text;
                wpmc = SqlHelper . ExecuteDataTable ( "SELECT DISTINCT GS02 AF084,GS07 AF015 FROM R_PQP WHERE GS07 IS NOT NULL AND GS07!='' AND GS70='R_342' AND GS01=@GS01" ,new SqlParameter ( "@GS01" ,cmj . AF002 ) );

                biao = SqlHelper . ExecuteDataTable ( " SELECT '' AF015,AF019,AF020,AF021,AF022,AF023,AF026,AF027,AF028,AF029,AF029,AF030,AF031,AF032,AF033,AF034,'' AF084 FROM R_PQAF WHERE AF002=@AF002" ,new SqlParameter ( "@AF002" ,cmj . AF002 ) );
            }
            //else
            //    wpmc = SqlHelper . ExecuteDataTable ( "SELECT DISTINCT GS02 AF084,GS07 AF015 FROM R_PQP WHERE GS07 IS NOT NULL AND GS07!='' AND GS48=@GS48" ,new SqlParameter ( "@GS48" ,cmj . AF004 ) );

            if ( string.IsNullOrEmpty( textBox68.Text ) )
                biao = SqlHelper.ExecuteDataTable( " SELECT AF015,AF019,AF020,AF021,AF022,AF023,AF026,AF027,AF028,AF029,AF029,AF030,AF031,AF032,AF033,AF034,AF084 FROM R_PQAF WHERE AF004=@AF004" ,new SqlParameter( "@AF004" ,cmj.AF004 ) );
            //else
            //{
            //    cmj.AF002 = textBox68.Text;
            //    biao = SqlHelper.ExecuteDataTable( " SELECT AF015,AF019,AF020,AF021,AF022,AF023,AF026,AF027,AF028,AF029,AF029,AF030,AF031,AF032,AF033,AF034,AF084 FROM R_PQAF WHERE AF002=@AF002" ,new SqlParameter( "@AF002" ,cmj.AF002 ) );
            //}
            if ( wpmc != null )
                biao.Merge( wpmc );
            //材料名称
            //lookUpEdit3 . Properties . DataSource = biao . DefaultView . ToTable ( true ,"AF084" );
            //lookUpEdit3 . Properties . DisplayMember = "AF084";
            //每个单价
            comboBox12 .DataSource = biao.DefaultView.ToTable( true ,"AF023" );
            comboBox12.DisplayMember = "AF023";
            //材料名称  物料或部件名称
            partInfo . Properties . DataSource = biao . DefaultView . ToTable ( true ,new string [ ] { "AF084","AF015" } );
            partInfo . Properties . DisplayMember = "AF084";
            partInfo . Properties . ValueMember = "AF084";
            //每套用量
            comboBox1 .DataSource = biao.DefaultView.ToTable( true ,"AF019" );
            comboBox1.DisplayMember = "AF019";
            //含水率
            comboBox16.DataSource = biao.DefaultView.ToTable( true ,"AF027" );
            comboBox16.DisplayMember = "AF027";
            //不开裂率
            comboBox17.DataSource = biao.DefaultView.ToTable( true ,"AF028" );
            comboBox17.DisplayMember = "AF028";
            //实际含水率
            comboBox18.DataSource = biao.DefaultView.ToTable( true ,"AF029" );
            comboBox18.DisplayMember = "AF029";
            //利边、尖点合格率%
            comboBox19.DataSource = biao.DefaultView.ToTable( true ,"AF030" );
            comboBox19.DisplayMember = "AF030";
            //表、切面光洁度合格率%
            comboBox21.DataSource = biao.DefaultView.ToTable( true ,"AF031" );
            comboBox21.DisplayMember = "AF031";
            //碰、压、划伤合格率%
            comboBox20.DataSource = biao.DefaultView.ToTable( true ,"AF032" );
            comboBox20.DisplayMember = "AF032";
            //边口老鼠牙合格率%
            comboBox3.DataSource = biao.DefaultView.ToTable( true ,"AF033" );
            comboBox3.DisplayMember = "AF033";
            //虫蛀、腐变、节疤合格率%
            comboBox22.DataSource = biao.DefaultView.ToTable( true ,"AF034" );
            comboBox22.DisplayMember = "AF034";
        }
        //物料名称
        private void comboBox2_SelectedValueChanged ( object sender ,EventArgs e )
        {
            //if ( !string.IsNullOrEmpty( partInfo.Text ) && biao.Select( "AF015='" + partInfo.Text + "'" ).Length > 0 )
            //{
            //    comboBox12.Text = biao.Select( "AF015='" + partInfo.Text + "'" )[0]["AF023"].ToString( );
            //    comboBox1.Text = biao.Select( "AF015='" + partInfo.Text + "'" )[0]["AF019"].ToString( );
            //    textBox32.Text = biao.Select( "AF015='" + partInfo.Text + "'" )[0]["AF020"].ToString( );
            //    textBox33.Text = biao.Select( "AF015='" + partInfo.Text + "'" )[0]["AF021"].ToString( );
            //    textBox34.Text = biao.Select( "AF015='" + partInfo.Text + "'" )[0]["AF022"].ToString( );
            //    comboBox15.Text = biao.Select( "AF015='" + partInfo.Text + "'" )[0]["AF026"].ToString( );
            //    comboBox16.Text = biao.Select( "AF015='" + partInfo.Text + "'" )[0]["AF027"].ToString( );
            //    comboBox17.Text = biao.Select( "AF015='" + partInfo.Text + "'" )[0]["AF028"].ToString( );
            //    comboBox18.Text = biao.Select( "AF015='" + partInfo.Text + "'" )[0]["AF029"].ToString( );
            //    comboBox19.Text = biao.Select( "AF015='" + partInfo.Text + "'" )[0]["AF030"].ToString( );
            //    comboBox21.Text = biao.Select( "AF015='" + partInfo.Text + "'" )[0]["AF031"].ToString( );
            //    comboBox20.Text = biao.Select( "AF015='" + partInfo.Text + "'" )[0]["AF032"].ToString( );
            //    comboBox3.Text = biao.Select( "AF015='" + partInfo.Text + "'" )[0]["AF033"].ToString( );
            //    comboBox22.Text = biao.Select( "AF015='" + partInfo.Text + "'" )[0]["AF034"].ToString( );
            //}

            
        }
        //采购员
        private void lookUpEdit1_EditValueChanged ( object sender ,EventArgs e )
        {
            if ( lookUpEdit1.EditValue != null )
            {
                cmj.AF007 = lookUpEdit1.EditValue.ToString( );
                textBox5.Text = name.Select( "DBA001='" + lookUpEdit1.EditValue + "'" )[0]["DBA028"].ToString( );
            }
        }
        //产品数量
        private void textBox71_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //每个单价
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
            if ( comboBox12.Text != "" && !DateDayRegise.eighteenSixNumber( comboBox12 ) )
            {
                this.comboBox12.Text = "";
                MessageBox.Show( "只允许输入小数部分最多六位,如9999.999999,请重新输入" );
            }
        }
        //每套用量
        private void comboBox1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox1 );
        }
        private void comboBox1_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox1 );
        }
        private void comboBox1_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox1.Text != "" && !DateDayRegise.sixThrNumberCb( comboBox1 ) )
            {
                this.comboBox1.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多三位,如999.999,请重新输入" );
            }
        }
        //使用库存数量
        private void textBox1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //使用外购数量
        private void textBox28_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //使用库存
        private void radioButton13_CheckedChanged ( object sender ,EventArgs e )
        {
            if ( radioButton13.Checked && ( ord == "实际" || !string.IsNullOrEmpty( textBox68.Text ) ) )
            {
                fc.yesOrNoOf( comboBox32.Text ,partName.Text ,textBox32.Text + "*" + textBox33.Text + "*" + textBox34.Text ,textBox27 ,textBox29 ,textBox71.Text );

                textBox28.Text = Math.Round( Convert.ToDecimal( Operation.MultiThrTbC( textBox71 ,comboBox1 ,textBox27.Text ) ) ,0 ).ToString( );

                //if ( string.IsNullOrEmpty( textBox27.Text ) || textBox27.Text == "0" )
                //    textBox1.Text = 0.ToString( );
                //else
                textBox1.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTbCbes( textBox71 ,comboBox1 ) ) ,0 ).ToString( );
            }

            if ( !string.IsNullOrEmpty( textBox27.Text ) )
                textBox27.Text = Math.Round( Convert.ToDecimal( textBox27.Text ) ,0 ).ToString( );
        }
        private void radioButton13_Click ( object sender ,EventArgs e )
        {

        }
        //使用外购
        private void radioButton14_CheckedChanged ( object sender ,EventArgs e )
        {
            if ( radioButton14.Checked && ( ord == "实际" || !string.IsNullOrEmpty( textBox68.Text ) ) )
                get( );
            else
            {
                fc.yesOrNoOf( comboBox32.Text ,partName.Text ,textBox32.Text + "*" + textBox33.Text + "*" + textBox34.Text ,textBox27 ,textBox29 ,textBox71.Text );
                textBox28.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTbCbes( textBox71 ,comboBox1 ) ) ,0 ).ToString( );
            }
            if ( !string.IsNullOrEmpty( textBox27.Text ) )
                textBox27.Text = Math.Round( Convert.ToDecimal( textBox27.Text ) ,0 ).ToString( );
        }
        private void radioButton14_Click ( object sender ,EventArgs e )
        {

        }
        void get ( )
        {
            string str = "";
            cmj.AF004 = comboBox32.Text;
            cmj.AF015 = partName.Text;
            if ( string.IsNullOrEmpty( textBox32.Text ) )
                cmj.AF020 = 0;
            else
                cmj.AF020 = Convert.ToDecimal( textBox32.Text );
            if ( string.IsNullOrEmpty( textBox33.Text ) )
                cmj.AF021 = 0;
            else
                cmj.AF021 = Convert.ToDecimal( textBox33.Text );
            if ( string.IsNullOrEmpty( textBox34.Text ) )
                cmj.AF022 = 0;
            else
                cmj.AF022 = Convert.ToDecimal( textBox34.Text );
            //AC16=@AC16 AND
            DataTable del = SqlHelper.ExecuteDataTable( "SELECT AC18,AC10+ISNULL(AC27,0)-ISNULL(SUM(AD12+ISNULL(AD21,0)),0) AC10 FROM R_PQAC A LEFT JOIN R_PQAD B ON A.AC18=B.AD01 WHERE AC02=@AC02 AND AC04=@AC04 AND AC05=(convert(varchar(10),@AF020)+'*'+convert(varchar(10),@AF021)+'*'+convert(varchar(10),@AF022)) GROUP BY AC10,AC18,ISNULL(AC27,0) HAVING AC10+ISNULL(AC27,0)-ISNULL(SUM(AD12+ISNULL(AD21,0)),0)>0" ,new SqlParameter( "@AC02" ,cmj.AF004 ) ,new SqlParameter( "@AC04" ,cmj.AF015 ) ,new SqlParameter( "@AF020" ,cmj.AF020 ) ,new SqlParameter( "@AF021" ,cmj.AF021 ) ,new SqlParameter( "@AF022" ,cmj.AF022 ) );
            if ( del.Rows.Count < 1 )
                str = "0";
            else if ( string.IsNullOrEmpty( del.Rows[0]["AC10"].ToString( ) ) )
                str = "0";
            else
                str = del.Rows[0]["AC10"].ToString( );
            //怎么读取库存数量
            textBox28.Text = Math.Round( Convert.ToDecimal( Operation.MultiThrTbC( textBox71 ,comboBox1 ,str ) ) ,0 ).ToString( );
        }
        //利边、尖点合格率%
        private void comboBox19_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //表、切面光洁度合格率%
        private void comboBox21_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //碰、压、划伤合格率%
        private void comboBox20_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //边口老鼠牙合格率%
        private void comboBox3_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //虫蛀.腐变.节疤合格率%
        private void comboBox22_KeyPress ( object sender ,KeyPressEventArgs e )
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
        //不开裂率
        private void comboBox17_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox32_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise . fill ( textBox32 );
            textBox30 . Text = bll . getOriPri ( textBox68 . Text ,comboBox32 . Text ,partName . Text ,textBox32 . Text ,textBox33 . Text ,textBox34 . Text ) . ToString ( );
        }
        private void textBox33_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise . fill ( textBox32 );
            textBox30 . Text = bll . getOriPri ( textBox68 . Text ,comboBox32 . Text ,partName . Text ,textBox32 . Text ,textBox33 . Text ,textBox34 . Text ) . ToString ( );
        }
        private void textBox34_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise . fill ( textBox32 );
            textBox30 . Text = bll . getOriPri ( textBox68 . Text ,comboBox32 . Text ,partName . Text ,textBox32 . Text ,textBox33 . Text ,textBox34 . Text ) . ToString ( );
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
        //开合同人
        private void button6_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox13.Text ) )
            {
                textBox13.Text = Logins.username;
                cmj.AF010 = textBox13.Text;

                string[] str = new string[2];
                str = oddNumbers.contractBatch( "R_PQAF" ,cmj.AF010 ,textBox13 ,textBox15 ,"AF011" );
                if ( str[0] == "" )
                    textBox13.Text = "";
                else
                    cmj.AF011 = str[1];
                textBox15.Text = str[1];


            }
            else if ( textBox13.Text != "" && textBox13.Text == Logins.username )
            {
                textBox13.Text = "";
                cmj.AF010 = textBox13.Text;
                cmj.AF011 = "";
                textBox15.Text = "";
            }

            if ( string.IsNullOrEmpty( textBox56.Text ) )
                textBox56.Text = Logins.username;
            else if ( !string.IsNullOrEmpty( textBox56.Text ) && textBox56.Text == Logins.username )
                textBox56.Text = "";
            dateTimePicker2 . Value = DateTime . Now;
            dateTimePicker14 . Value = DateTime . Now;
        }
        //成本员
        private void button11_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox14.Text ) )
                textBox14.Text = Logins.username;
            else if ( !string.IsNullOrEmpty( textBox14.Text ) && textBox14.Text == Logins.username )
                textBox14.Text = "";
            dateTimePicker3 . Value = DateTime . Now;
        }
        //甲方代表签字
        private void button7_Click ( object sender ,EventArgs e )
        {

        }
        //乙方代表签字
        private void button8_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox55.Text ) )
                textBox55.Text = Logins.username;
            else if ( !string.IsNullOrEmpty( textBox55.Text ) && textBox55.Text == Logins.username )
                textBox55.Text = "";
        }
        //复核人
        private void button9_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox54.Text ) )
                textBox54.Text = Logins.username;
            else if ( !string.IsNullOrEmpty( textBox55.Text ) && textBox55.Text == Logins.username )
                textBox55.Text = "";
            dateTimePicker13.Value = MulaolaoBll . Drity . GetDt ( );
        }
        //审批人
        private void button10_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox53.Text ) )
                textBox53.Text = Logins.username;
            else if ( !string.IsNullOrEmpty( textBox53.Text ) && textBox53.Text == Logins.username )
                textBox53.Text = "";
            dateTimePicker12.Value = MulaolaoBll . Drity . GetDt ( );
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
        //表
        string af15 = "";
        decimal af20 = 0M, af21 = 0M, af22 = 0M;
        private void bandedGridView1_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            DataRow row = bandedGridView1 . GetFocusedDataRow ( );
            if ( row == null )
                return;
            partInfo . Text = row [ "AF084" ] . ToString ( );
            partName . Text = row [ "AF015" ] . ToString ( );
            comboBox1 . Text = row [ "AF019" ] . ToString ( );
            textBox32 . Text = row [ "AF020" ] . ToString ( );
            textBox33 . Text = row [ "AF021" ] . ToString ( );
            textBox34 . Text = row [ "AF022" ] . ToString ( );
            comboBox12 . Text = row [ "AF023" ] . ToString ( );
            if ( !string . IsNullOrEmpty ( row [ "AF024" ] . ToString ( ) ) )
                dateTimePicker4 . Value = Convert . ToDateTime ( row [ "AF024" ] . ToString ( ) );
            if ( !string . IsNullOrEmpty ( row [ "AF025" ] . ToString ( ) ) )
                dateTimePicker5 . Value = Convert . ToDateTime ( row [ "AF025" ] . ToString ( ) );
            comboBox15 . Text = row [ "AF026" ] . ToString ( );
            comboBox16 . Text = row [ "AF027" ] . ToString ( );
            comboBox17 . Text = row [ "AF028" ] . ToString ( );
            comboBox18 . Text = row [ "AF029" ] . ToString ( );
            comboBox19 . Text = row [ "AF030" ] . ToString ( );
            comboBox21 . Text = row [ "AF031" ] . ToString ( );
            comboBox20 . Text = row [ "AF032" ] . ToString ( );
            comboBox3 . Text = row [ "AF033" ] . ToString ( );
            comboBox22 . Text = row [ "AF034" ] . ToString ( );
            if ( row [ "AF016" ] . ToString ( ) . Equals ( "库存" ) )
            {
                radioButton13 . Checked = true;
                radioButton13_CheckedChanged ( null ,null );
                textBox1 . Text = row [ "AF018" ] . ToString ( );
            }
            else if ( row [ "AF016" ] . ToString ( ) . Equals ( "外购" ) )
            {
                radioButton14 . Checked = true;
                radioButton14_CheckedChanged ( null ,null );
                textBox28 . Text = row [ "AF017" ] . ToString ( );
            }
            af15 = partName . Text;
            if ( string . IsNullOrEmpty ( textBox32 . Text ) )
                af20 = 0M;
            else
                af20 = Convert . ToDecimal ( textBox32 . Text );
            if ( string . IsNullOrEmpty ( textBox33 . Text ) )
                af21 = 0M;
            else
                af21 = Convert . ToDecimal ( textBox33 . Text );
            if ( string . IsNullOrEmpty ( textBox34 . Text ) )
                af22 = 0M;
            else
                af22 = Convert . ToDecimal ( textBox34 . Text );
            if ( !string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) )
                cmj . idx = Convert . ToInt64 ( row [ "idx" ] . ToString ( ) );
            textBox30 . Text = row [ "AF087" ] . ToString ( );
            textBox31 . Text = row [ "AF088" ] . ToString ( );
        }
        private void R_FrmCheMuJianContract_FormClosing ( object sender ,FormClosingEventArgs e )
        {
            if ( toolSave.Enabled == true )
                cancel( );
        }
        private void partName_TextChanged ( object sender ,EventArgs e )
        {
            textBox30 . Text = bll . getOriPri ( textBox68 . Text ,comboBox32 . Text ,partName . Text ,textBox32 . Text ,textBox33 . Text ,textBox34 . Text ) . ToString ( );
            textBox31 . Text = bll . getOriPrice ( textBox68 . Text ,comboBox32 . Text ,partName . Text ,textBox32 . Text ,textBox33 . Text ,textBox34 . Text ) . ToString ( );


            string strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( textBox68 . Text ) )
                strWhere = strWhere + " AND GS01='" + textBox68 . Text + "'";
            if ( !string . IsNullOrEmpty ( partName . Text ) )
                strWhere = strWhere + " AND GS07='" + partName . Text + "'";

            textBox34 . Text = textBox33 . Text = textBox32 . Text = string . Empty;

            DataTable table = bll . getPartInfo ( strWhere );
            if ( table != null && table . Rows . Count > 0 )
            {
                comboBox1 . Text = table . Rows [ 0 ] [ "GS10" ] . ToString ( );
                strWhere = string . Empty;
                strWhere = table . Rows [ 0 ] [ "GS08" ] . ToString ( );
                if ( strWhere . Contains ( "*" ) )
                {
                    string [ ] str = strWhere . Split ( '*' );
                    if ( !str [ 0 ] . Contains ( "Φ" ) )
                    {
                        textBox32 . Text = string . IsNullOrEmpty ( str [ 0 ] ) == true ? 0 . ToString ( ) : Math . Round ( Convert . ToDecimal ( str [ 0 ] ) / 10 ,2 ) . ToString ( );
                        if ( str . Length >= 2 )
                            textBox33 . Text = string . IsNullOrEmpty ( str [ 1 ] ) == true ? 0 . ToString ( ) : Math . Round ( Convert . ToDecimal ( str [ 1 ] ) / 10 ,2 ) . ToString ( );
                        if ( str . Length >= 3 )
                            textBox34 . Text = string . IsNullOrEmpty ( str [ 2 ] ) == true ? 0 . ToString ( ) : Math . Round ( Convert . ToDecimal ( str [ 2 ] ) / 10 ,2 ) . ToString ( );
                    }
                    else
                    {
                        textBox34 . Text = textBox33 . Text = str [ 0 ] . Replace ( 'Φ' ,' ' );
                        textBox34 . Text = textBox33 . Text = string . IsNullOrEmpty ( textBox34 . Text ) == true ? 0 . ToString ( ) : Math . Round ( Convert . ToDecimal ( textBox34 . Text ) / 10 ,2 ) . ToString ( );
                        if ( str . Length >= 2 )
                            textBox32 . Text = string . IsNullOrEmpty ( str [ 1 ] ) == true ? 0 . ToString ( ) : Math . Round ( Convert . ToDecimal ( str [ 1 ] ) / 10 ,2 ) . ToString ( );
                    }
                }
            }
        }
        private void partInfo_EditValueChanged ( object sender ,EventArgs e )
        {
            DataRow row = ViewInfo . GetFocusedDataRow ( );
            if ( row == null )
                return;
            partName . Text = row [ "AF015" ] . ToString ( );
        }
        #endregion

        #region 主体
        //送审
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

            Reviews ( "AF001" ,cmj . AF001 ,"R_PQAF" ,this ,cmj . AF002 ,"R_342" ,result ,over ,null/*,"AF012" ,"AF072" ,"R_PQAF" ,"AF001" ,cmj.AF001 ,ord ,textBox68.Text ,"R_342"*/);
            result = false;
            result = sp.reviewImple( "R_342" ,cmj.AF001 );
            if ( result == true )
            {
                label107.Visible = true;
                try
                {
                    SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfCopy( "R_PQAFC" ,"R_PQAF" ,"AF001" ,cmj.AF001 ) );
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
            receiva = bll.GetDataTableOfReceivable( cmj.AF001 );
            if ( receiva != null && receiva.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < receiva.Rows.Count ; i++ )
                {
                    modelAm.AM002 = receiva.Rows[i]["AF002"].ToString( );
                    modelAm.AM270 = modelAm.AM273 = modelAm.AM277 = modelAm.AM280 = modelAm.AM272 = modelAm.AM279 = modelAm.AM283 = modelAm.AM285 = 0;

                    modelAm.AM270 = string.IsNullOrEmpty( receiva.Compute( "SUM(AF)" ,"AF002='" + modelAm.AM002 + "' and AF016= '外购' AND AF078='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "SUM(AF)" ,"AF002='" + modelAm.AM002 + "' and AF016= '外购' AND AF078='F'" ) );
                    modelAm.AM272 = string.IsNullOrEmpty( receiva.Compute( "SUM(AF)" ,"AF002='" + modelAm.AM002 + "' and AF016= '外购' AND AF078='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "SUM(AF)" ,"AF002='" + modelAm.AM002 + "' and AF016= '外购' AND AF078='T'" ) );

                    //modelAm.AM273 = string.IsNullOrEmpty( receiva.Compute( "SUM(AF)" ,"AF002='" + modelAm.AM002 + "' and AF016= '外购' and AF026='混水' AND AF078='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "SUM(AF)" ,"AF002='" + modelAm.AM002 + "' and AF016= '外购' and AF026='混水' AND AF078='F'" ) );
                    //modelAm.AM279 = string.IsNullOrEmpty( receiva.Compute( "SUM(AF)" ,"AF002='" + modelAm.AM002 + "' and AF016= '外购' and AF026='混水' AND AF078='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "SUM(AF)" ,"AF002='" + modelAm.AM002 + "' and AF016= '外购' and AF026='混水' AND AF078='T'" ) );

                    modelAm.AM277 = string.IsNullOrEmpty( receiva.Compute( "SUM(AF)" ,"AF002='" + modelAm.AM002 + "' and AF016= '库存' AND AF078='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "SUM(AF)" ,"AF002='" + modelAm.AM002 + "' and AF016= '库存' AND AF078='F'" ) );
                    modelAm.AM283 = string.IsNullOrEmpty( receiva.Compute( "SUM(AF)" ,"AF002='" + modelAm.AM002 + "' and AF016= '库存' AND AF078='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "SUM(AF)" ,"AF002='" + modelAm.AM002 + "' and AF016= '库存' AND AF078='T'" ) );

                    //modelAm.AM280 = string.IsNullOrEmpty( receiva.Compute( "SUM(AF)" ,"AF002='" + modelAm.AM002 + "' and AF016= '库存' and AF026='混水' AND AF078='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "SUM(AF)" ,"AF002='" + modelAm.AM002 + "' and AF016= '库存' and AF026='混水'  AND AF078='F'" ) );
                    //modelAm.AM285 = string.IsNullOrEmpty( receiva.Compute( "SUM(AF)" ,"AF002='" + modelAm.AM002 + "' and AF016= '库存' and AF026='混水' AND AF078='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "SUM(AF)" ,"AF002='" + modelAm.AM002 + "' and AF016= '库存' and AF026='混水'  AND AF078='T'" ) );

                    bll.UpdateOfReceivable( modelAm ,cmj.AF001 );
                }
            }
        }
        //更改
        protected override void update ( )
        {
            base.update( );

            if ( label107.Visible==true )
                MessageBox.Show( "单号:" + cmj.AF001 + "的单据状态为执行,不允许更改" );
            else
            {
                Ergodic.SpliEnableTrue( spList );
                Ergodic.TablePageEnableTrue( pageList );
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolUpdate.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;

                comboBox31.Enabled = comboBox32.Enabled = false;
                textBox25.Enabled = false;
                dateTimePicker2.Enabled = dateTimePicker3.Enabled = dateTimePicker5.Enabled = false;
                if ( string.IsNullOrEmpty( textBox68.Text ) )
                {
                    comboBox31.Enabled = comboBox32.Enabled = true;
                    textBox71.Enabled = true;
                    button14.Enabled = true;
                    button4.Enabled = false;
                }
                else
                {
                    comboBox31.Enabled = comboBox32.Enabled = false;
                    textBox71.Enabled = false;
                    button14.Enabled = false;
                    button4.Enabled = true;
                }
            }
        }
        //删除
        protected override void delete ( )
        {
            base.delete( );

            if ( label107.Visible==true )
            {
                if ( Logins.number == "MLL-0001" )
                    deles( );
                else
                    MessageBox.Show( "单号:" + cmj.AF001 + "的单据状态为执行,不允许删除" );
            }
            else
                deles( );
        }
        void deles ( )
        {
            if ( label107.Visible == true )
                stateOfOdd = "维护删除";
            else
            {
                if ( saer == "1" )
                    stateOfOdd = "新增删除";
                else
                    stateOfOdd = "更改删除";
            }
            result = bll.DeleteAll( cmj ,"R_342" ,"车木件采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"删除" ,stateOfOdd );
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

                toolSelect.Enabled = toolAdd.Enabled = true;
                toolDelete.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolUpdate.Enabled = toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolPrint.Enabled = toolExport.Enabled = false;
                label98.Visible = label107.Visible = false;

                textBox2.Text = "";
                textBox25.Enabled = false;
            }
        }
        //新增
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
            label98.Visible = false;
            saer = "1";
            mainTain = "";

            dateTimePicker2.Enabled = dateTimePicker3.Enabled = dateTimePicker5.Enabled = false;
            cmj.AF001 = oddNumbers.purchaseContract( "SELECT MAX(AJ005) AJ005 FROM R_PQAJ" ,"AJ005" ,"R_342-" );
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
                button14.Enabled = true;
                button4.Enabled = false;
                //fc.productNumberRthr( comboBox31 );
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
            }
            else if ( ord == "实际" )
            {
                orde( );

                comboBox31.Enabled = comboBox32.Enabled = false;
                textBox71.Enabled = false;
                button14.Enabled = false;
                button4.Enabled = true;
                //comboBox31.DataSource = null;
                //comboBox31.Items.Clear( );
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
            }
            else
            {
                MessageBox.Show( "请选择计划订单或实际订单" );
                saer = "1";
                cmj.AF001 = "";
                toolSelect.Enabled = toolAdd.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
            }
        }
        private void od_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            ord = e.ConOne;
        }
        //保存
        void assignment ( )
        {
            cmj.AF002 = textBox68.Text;
            cmj.AF003 = comboBox31.Text;
            cmj.AF004 = comboBox32.Text;
            cmj.AF005 = textBox2.Text;
            if ( !string.IsNullOrEmpty( textBox71.Text ) )
                cmj.AF006 = Convert.ToInt64( textBox71.Text );
            else
                cmj.AF006 = 0;
            cmj.AF005 = textBox2.Text;
            cmj.AF009 = dateTimePicker1.Value;
            cmj.AF010 = textBox13.Text;
            cmj.AF011 = textBox15.Text;
            cmj.AF012 = textBox14.Text;
            cmj.AF013 = dateTimePicker3.Value;
            cmj.AF014 = dateTimePicker2.Value;
            cmj.AF035 = comboBox23.Text;
            cmj.AF036 = dateTimePicker6.Value;
            if ( radioButton1.Checked )
                cmj.AF037 = "在内";
            else if ( radioButton2.Checked )
                cmj.AF037 = "不在内";
            else if ( !radioButton1.Checked && !radioButton2.Checked )
                cmj.AF037 = "";
            if ( radioButton3.Checked )
                cmj.AF038 = "T";
            else if ( radioButton4.Checked )
                cmj.AF038 = "F";
            else if ( !radioButton3.Checked && !radioButton4.Checked )
                cmj.AF038 = "";
            if ( radioButton6.Checked )
            {
                cmj.AF039 = "T";
                cmj.AF040 = textBox26.Text;
            }
            else if ( radioButton5.Checked )
            {
                cmj.AF039 = "F";
                cmj.AF040 = "";
            }
            else if ( !radioButton6.Checked && !radioButton5.Checked )
            {
                cmj.AF039 = "";
                cmj.AF040 = "";
            }
            cmj.AF041 = comboBox24.Text;
            cmj.AF042 = comboBox25.Text;
            cmj.AF043 = dateTimePicker7.Value;
            cmj.AF044 = comboBox26.Text;
            cmj.AF045 = dateTimePicker8.Value;
            if ( radioButton8.Checked )
            {
                cmj.AF046 = "合格";
                cmj.AF047 = "";
            }
            else if ( radioButton7.Checked )
            {
                cmj.AF046 = "条件接收";
                cmj.AF047 = textBox3.Text;
            }
            else if ( radioButton9.Checked )
            {
                cmj.AF046 = "退货";
                cmj.AF047 = "";
            }
            else if ( !radioButton7.Checked && !radioButton8.Checked && !radioButton9.Checked )
            {
                cmj.AF046 = "";
                cmj.AF047 = "";
            }
            cmj.AF048 = comboBox28.Text;
            cmj.AF049 = dateTimePicker10.Value;
            cmj.AF050 = comboBox27.Text;
            cmj.AF051 = dateTimePicker9.Value;
            if ( !string.IsNullOrEmpty( textBox4.Text ) )
                cmj.AF052 = Convert.ToInt64( textBox4.Text );
            else
                cmj.AF052 = 0;
            if ( radioButton12.Checked )
            {
                cmj.AF053 = "合格";
                cmj.AF054 = "";
            }
            else if ( radioButton11.Checked )
            {
                cmj.AF053 = "条件接收";
                cmj.AF054 = textBox24.Text;
            }
            else if ( radioButton10.Checked )
            {
                cmj.AF054 = "";
                cmj.AF053 = "退货";
            }
            else if ( !radioButton12.Checked && !radioButton11.Checked && !radioButton10.Checked )
            {
                cmj.AF053 = "";
                cmj.AF054 = "";
            }
            if ( !string.IsNullOrEmpty( textBox11.Text ) )
                cmj.AF055 = Convert.ToInt32( textBox11.Text );
            else
                cmj.AF055 = 0;
            if ( !string.IsNullOrEmpty( textBox12.Text ) )
                cmj.AF056 = Convert.ToInt32( textBox12.Text );
            else
                cmj.AF056 = 0;
            if ( !string.IsNullOrEmpty( textBox16.Text ) )
                cmj.AF057 = Convert.ToInt32( textBox16.Text );
            else
                cmj.AF057 = 0;
            if ( !string.IsNullOrEmpty( textBox20.Text ) )
                cmj.AF058 = Convert.ToInt32( textBox20.Text );
            else
                cmj.AF058 = 0;
            if ( !string.IsNullOrEmpty( textBox18.Text ) )
                cmj.AF059 = Convert.ToInt32( textBox18.Text );
            else
                cmj.AF059 = 0;
            if ( !string.IsNullOrEmpty( textBox17.Text ) )
                cmj.AF060 = Convert.ToInt32( textBox17.Text );
            else
                cmj.AF060 = 0;
            if ( !string.IsNullOrEmpty( textBox23.Text ) )
                cmj.AF061 = Convert.ToInt32( textBox23.Text );
            else
                cmj.AF061 = 0;
            if ( !string.IsNullOrEmpty( textBox22.Text ) )
                cmj.AF062 = Convert.ToInt32( textBox22.Text );
            else
                cmj.AF062 = 0;
            if ( !string.IsNullOrEmpty( textBox21.Text ) )
                cmj.AF063 = Convert.ToInt32( textBox21.Text );
            else
                cmj.AF063 = 0;
            cmj.AF064 = comboBox29.Text;
            cmj.AF065 = comboBox30.Text;
            cmj.AF066 = dateTimePicker11.Value;
            cmj.AF067 = textBox56.Text;
            cmj.AF068 = textBox55.Text;
            cmj.AF069 = dateTimePicker14.Value;
            cmj.AF070 = textBox54.Text;
            cmj.AF071 = dateTimePicker13.Value;
            cmj.AF072 = textBox53.Text;
            cmj.AF073 = dateTimePicker12.Value;
            cmj.AF074 = "";
            cmj.AF075 = textBox25.Text;
            cmj.AF078 = checkBox1.Checked == true ? "T" : "F";
            cmj.AF079 = lookUpEdit2.Text;
            cmj.AF083 = checkBox2.Checked == true ? "T" : "F"; 

        }
        void save_All ( )
        {
            Ergodic.TablePageEnableFalse( pageList );
            Ergodic.SpliEnableFalse( spList );
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolUpdate.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;

            textBox25.Enabled = false;
            copy = "";
            saer = "2";
            mainTain = "";
            label98.Visible = false;
        }
        void updates ( )
        {
            result = bll.UpdateOfAll( cmj ,"R_342" ,"车木件采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"保存" ,stateOfOdd );
            if ( result == false )
                MessageBox.Show( "录入数据失败" );
            else
            {
                MessageBox.Show( "成功录入数据" );
                if ( mainTain == "1" )
                {
                    try
                    {
                        SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfCopy( "R_PQAFC" ,"R_PQAF" ,"AF001" ,cmj.AF001 ) );
                        WriteOfReceivablesTo( );
                    }
                    catch { }
                }
                save_All( );
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
            assignment( );
            DataTable dop = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQAF WHERE AF001=@AF001" ,new SqlParameter( "@AF001" ,cmj.AF001 ) );
            if ( mainTain == "1" )
            {
                if ( string.IsNullOrEmpty( cmj.AF075 ) )
                {
                    MessageBox.Show( "维护意见不可为空" );
                    return;
                }
                if ( dop.Rows.Count < 1 )
                    MessageBox.Show( "单号:" + cmj.AF001 + "的记录不存在,请核实后再录入" );
                else
                {
                    stateOfOdd = "维护保存";
                    cmj.AF074 = dop.Rows[0]["AF074"].ToString( ) + "[" + Logins.username + MulaolaoBll . Drity . GetDt ( ).ToString( "yyyyMMdd" ) + "]";
                    updates( );
                }
            }
            else
            {
                if ( saer == "1" )
                    stateOfOdd = "新增保存";
                else
                    stateOfOdd = "更改保存";
                if ( dop.Rows.Count < 1 )
                    save_All( );
                else
                {
                    if ( copy == "1" )
                    {
                        if ( MulaolaoBll . WriteReceivableToGeneralLedger . ExistsSup ( cmj.AF008 ) == false )
                        {
                            MessageBox . Show ( "供应商已注销,请核实" );
                            return;
                        }

                        stateOfOdd = "复制保存";
                        // AND AF010=@AF010
                        DataTable dyu = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQAF WHERE AF001!=@AF001" ,new SqlParameter( "@AF001" ,cmj.AF001 ) /*,new SqlParameter( "@AF010" ,cmj.AF010 )*/ );
                        if ( dyu.Rows.Count < 1 )
                            updates( );
                        else
                        {
                            int proNum = 0;
                            for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
                            {
                                proNum = string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "AF006" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( bandedGridView1 . GetDataRow ( i ) [ "AF006" ] );
                                if ( proNum != cmj . AF006 )
                                {
                                    MessageBox . Show ( "产品数量不一致,请核实" );
                                    break;
                                }

                                if ( ord == "计划" || string.IsNullOrEmpty( textBox68.Text ) )
                                {
                                    if ( dyu.Select( "AF015='" + bandedGridView1.GetDataRow( i )["AF015"].ToString( ) + "' AND AF020='" + bandedGridView1.GetDataRow( i )["AF020"].ToString( ) + "' AND AF021='" + bandedGridView1.GetDataRow( i )["AF021"].ToString( ) + "' AND AF022='" + bandedGridView1.GetDataRow( i )["AF022"].ToString( ) + "' AND AF004='" + cmj.AF004 + "'" ).Length > 0 )
                                    {
                                        if ( cmj.AF011.Length > 8 && cmj.AF011.Substring( 0 ,8 ) == "MLL-0001" )
                                        {
                                            updates( );
                                            break;
                                        }
                                        else
                                        {
                                            //开合同人:" + cmj.AF010 + "\n\r
                                            MessageBox.Show( "已经存在\n\r货号:" + cmj.AF004 + "\n\r物料名称:" + bandedGridView1.GetDataRow( i )["AF015"].ToString( ) + "\n\r长:" + bandedGridView1.GetDataRow( i )["AF020"].ToString( ) + "\n\r宽:" + bandedGridView1.GetDataRow( i )["AF021"].ToString( ) + "\n\r高:" + bandedGridView1.GetDataRow( i )["AF022"].ToString( ) + "的记录,请核实后再录入" );
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
                                        return;
                                    if ( !string . IsNullOrEmpty ( textBox68 . Text ) )
                                    {
                                        if ( checkThisAnd509 ( ) == false )
                                            return;
                                    }
                                    if ( dyu.Select( "AF015='" + bandedGridView1.GetDataRow( i )["AF015"].ToString( ) + "' AND AF020='" + bandedGridView1.GetDataRow( i )["AF020"].ToString( ) + "' AND AF021='" + bandedGridView1.GetDataRow( i )["AF021"].ToString( ) + "' AND AF022='" + bandedGridView1.GetDataRow( i )["AF022"].ToString( ) + "' AND AF002='" + cmj.AF002 + "'" ).Length > 0 )
                                    {
                                        if ( cmj.AF011.Length > 8 && cmj.AF011.Substring( 0 ,8 ) == "MLL-0001" )
                                        {
                                            updates( );
                                            break;
                                        }
                                        else
                                        {
                                            //\n\r开合同人:" + cmj.AF010 + "
                                            MessageBox.Show( "已经存在\n\r流水号:" + cmj.AF002 + "\n\r物料名称:" + bandedGridView1.GetDataRow( i )["AF015"].ToString( ) + "\n\r长:" + bandedGridView1.GetDataRow( i )["AF020"].ToString( ) + "\n\r宽:" + bandedGridView1.GetDataRow( i )["AF021"].ToString( ) + "\n\r高:" + bandedGridView1.GetDataRow( i )["AF022"].ToString( ) + "的记录,请核实后再录入" );
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
            //AF016:使用库存OR外购
            //AF006:产品数量
            //AF015:物料名称
            //AF020:长
            //AF021:宽
            //AF022:高
            //combobox32:货号

            if ( bandedGridView1.RowCount > 0 && bandedGridView1.GetDataRow( 0 )["AF016"].ToString( ) == "库存" )
            {
                for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
                {
                    result = fc.LibraryOf( comboBox32.Text ,bandedGridView1.GetDataRow( i )["AF006"].ToString( ) ,bandedGridView1.GetDataRow( i )["AF015"].ToString( ) ,bandedGridView1.GetDataRow( i )["AF020"].ToString( ) + "*" + bandedGridView1.GetDataRow( i )["AF021"].ToString( ) + "*" + bandedGridView1.GetDataRow( i )["AF022"].ToString( ) );
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
            cmj . AF002 = textBox68 . Text;
            for ( int i = 0 ; i < bandedGridView1 . RowCount ; i++ )
            {
                cmj . AF015 = bandedGridView1 . GetDataRow ( i ) [ "AF015" ] . ToString ( );
                cmj . AF084 = bandedGridView1 . GetDataRow ( i ) [ "AF084" ] . ToString ( );
                cmj . AF020 = string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "AF020" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "AF020" ] );
                cmj . AF021 = string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "AF021" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "AF021" ] );
                cmj . AF022 = string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "AF022" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "AF022" ] );
                result = fc . check342And509 ( cmj );
                if ( result == false )
                {
                    MessageBox . Show ( "流水号:" + cmj . AF002 + "\n\r材料名称:" + cmj . AF084 + "\n\r物料或部件名称:" + cmj . AF015 + "\n\r长:" + cmj . AF020 . ToString ( "0.####" ) + "\n\r宽:" + cmj . AF021 . ToString ( "0.####" ) + "\n\r高:" + cmj . AF022 . ToString ( "0.####" ) + "\n\r与509数据不一致,请核实" );
                    break;
                }
            }

            return result;
        }
        //打印
        bool result = false;
        void trueOrFalse ( )
        {
            cmj.AF004 = comboBox32.Text;
            if ( ( string.IsNullOrEmpty( textBox68.Text ) && bandedGridView1.GetDataRow( 0 )["AF016"].ToString( ) == "外购" ) || ( !string.IsNullOrEmpty( textBox68.Text ) && bandedGridView1.GetDataRow( 0 )["AF016"].ToString( ) == "库存" ) )
            {
                for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
                {
                    if ( sp.inOut( cmj.AF001 ,bandedGridView1.GetDataRow( i )["AF015"].ToString( ) ,cmj.AF004 ,bandedGridView1.GetDataRow( i )["AF020"].ToString( ) + "*" + bandedGridView1.GetDataRow( i )["AF021"].ToString( ) + "*" + bandedGridView1.GetDataRow( i )["AF022"].ToString( ) ) == false )
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
            sp.panDuan( "AF012" ,"AF072" ,"R_PQAF" ,"AF001" ,cmj.AF001 ,ord ,textBox68.Text,"R_342" );
            if ( sp . sp != "1" )
                return;

            printCount = bandedGridView1 . DataRowCount;
            if ( printCount % 8 > 0 )
                printCount = printCount / 8 + 1;
            else
                printCount = printCount / 8;

            if ( ( ord == "实际" || !string.IsNullOrEmpty( textBox68.Text ) ) && bandedGridView1.GetDataRow( 0 )["AF016"].ToString( ) == "外购" )
            {
                if ( label107.Visible == true )
                {
                    MulaolaoBll . ContractAddPrintTime . addTimeToContract ( "R_PQAF" ,"AF085" ,cmj . AF001 ,"AF001" );
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
                    MulaolaoBll . ContractAddPrintTime . addTimeToContract ( "R_PQAF" ,"AF085" ,cmj . AF001 ,"AF001" );
                    printC ( );
                }
                else
                    MessageBox.Show( "没有出入库的单据不能打印" );
            }

        }
        void printC ( )
        {
            for ( int i = 0 ; i < printCount ; i++ )
            {
                Create ( i * 8 + 1 ,i * 8 + 8 );

                file = "";
                file = Environment . CurrentDirectory;

                report . Load ( file + "\\R_342cmj.frx" );
                report . RegisterData ( RDataSet );
                report . Show ( );
            }
        }
        //导出
        protected override void export ( )
        {
            base.export( );
            //sp.panDuan( "AF012" ,"AF072" ,"R_PQAF" ,"AF001" ,cmj.AF001 ,ord ,textBox68.Text,"R_342" );

            //if ( ( ord == "实际" || !string.IsNullOrEmpty( textBox68.Text ) ) && radioButton14.Checked )
            //{
            //    if ( label107.Visible == true )
            //    {

            printCount = bandedGridView1 . DataRowCount;
            if ( printCount % 8 > 0 )
                printCount = printCount / 8 + 1;
            else
                printCount = printCount / 8;

            for ( int i = 0 ; i < printCount ; i++ )
            {
                Create ( i * 8 + 1 ,i * 8 + 8 );
                file = "";
                file = System . Windows . Forms . Application . StartupPath;
                report . Load ( file + "\\R_342cmj.frx" );
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
            //        Create( );
            //        report.Load( Environment.CurrentDirectory + "\\R_342cmj.frx" );
            //        report.RegisterData( RDataSet );
            //        report.Prepare( );
            //        XMLExport exprots = new XMLExport( );
            //        exprots.Export( report );
            //    }
            //    else
            //        MessageBox.Show( "没有出入库的单据不能导出" );
            //}
        }
        //维护
        protected override void maintain ( )
        {
            base.maintain( );

            if ( label107.Visible == true )
            {
                Ergodic.SpliEnableTrue( spList );
                Ergodic.TablePageEnableTrue( pageList );
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolUpdate.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;

                textBox25.Enabled = true;

                mainTain = "1";

                dateTimePicker2.Enabled = dateTimePicker3.Enabled = dateTimePicker5.Enabled = false;

                if ( !string.IsNullOrEmpty( textBox68.Text ) )
                {
                    comboBox31.Enabled = comboBox32.Enabled = false;
                    textBox71.Enabled = false;
                    button14.Enabled = false;
                    button4.Enabled = true;
                }
                else
                {
                    comboBox31.Enabled = comboBox32.Enabled = true;
                    textBox71.Enabled = true;
                    button14.Enabled = true;
                    button4.Enabled = false;
                }
            }
            else
                MessageBox.Show( "此单据没有被执行,只需更改即可,无需维护" );
        }
        //取消
        protected override void cancel ( )
        {
            base.cancel( );

            if ( saer == "1" && mainTain != "1" )
            {
                Ergodic.SpliClear( spList );
                Ergodic.TablePageEnableClear( pageList );
                Ergodic.FormEvery( this );
                gridControl1.DataSource = null;
                toolSelect.Enabled = toolAdd.Enabled = toolPrint.Enabled = toolExport.Enabled = true;
                toolDelete.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolUpdate.Enabled = toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;

                label98.Visible = false;
                copy = "";
                try
                {
                    bll.DeleteAll( cmj ,"R_342" ,"车木件采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"取消" ,"新增取消" );
                }
                catch { }
            }
            else if ( saer == "2" || mainTain == "1" )
            {
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolUpdate.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = false;

                copy = "";
            }

            textBox25.Enabled = false;
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableFalse( pageList );
        }
        //出库
        protected override void library ( )
        {
            base.library( );
            if ( label107.Visible == false )
            {
                MessageBox.Show( "非执行单据不能出库" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox31.Text ) )
            {
                MessageBox.Show( "产品名称不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox32.Text ) )
            {
                MessageBox.Show( "货号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox71.Text ) )
            {
                MessageBox.Show( "产品数量不可为空" );
                return;
            }
            if ( bandedGridView1.GetDataRow( 0 )["AF016"].ToString( ) == "外购" )
            {
                MessageBox.Show( "外购无法出库,请选择入库或更改状态" );
                return;
            }
            libraryTable = null;
            for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
            {
                if ( libraryTable != null )
                    libraryTable.Rows.Add( new object[] { bandedGridView1.GetDataRow( i )["AF020"].ToString( ) + "*" + bandedGridView1.GetDataRow( i )["AF021"].ToString( ) + "*" + bandedGridView1.GetDataRow( i )["AF022"].ToString( ) ,bandedGridView1.GetDataRow( i )["AF015"].ToString( ) ,Convert.ToDecimal( bandedGridView1.GetDataRow( i )["AF018"].ToString( ) ) } );
                else
                {
                    libraryTable = new DataTable( "Datas" );
                    libraryTable.Columns.Add( "tOne" ,typeof( System.String ) );
                    libraryTable.Columns.Add( "tTwo" ,typeof( System.String ) );
                    libraryTable.Columns.Add( "tTre" ,typeof( System.Decimal ) );
                    libraryTable.Rows.Add( new object[] { bandedGridView1.GetDataRow( i )["AF020"].ToString( ) + "*" + bandedGridView1.GetDataRow( i )["AF021"].ToString( ) + "*" + bandedGridView1.GetDataRow( i )["AF022"].ToString( ) ,bandedGridView1.GetDataRow( i )["AF015"].ToString( ) ,Convert.ToDecimal( bandedGridView1.GetDataRow( i )["AF018"].ToString( ) ) } );
                }
            }
            if ( libraryTable.Rows.Count > 0 )
            {
                SelectAll.OutbandChoice outC = new SelectAll.OutbandChoice( );
                outC.libraryTable = libraryTable;
                outC.number = comboBox32.Text;
                outC.sign = "R_342";
                outC.oddNum = cmj.AF001;
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
                    countSum = libraryTable.Select( "tTwo='" + bandedGridView1.GetDataRow( i )["AF020"].ToString( ) + "*" + bandedGridView1.GetDataRow( i )["AF021"].ToString( ) + "*" + bandedGridView1.GetDataRow( i )["AF022"].ToString( ) + bandedGridView1.GetDataRow( i )["AF015"].ToString( ) + "'" ).Length;
                    if ( countSum > 0 )
                    {
                        for ( int k = 0 ; k < countSum ; k++ )
                        {
                            if ( !speList.Contains( libraryTable.Select( "tTwo='" + bandedGridView1.GetDataRow( i )["AF020"].ToString( ) + "*" + bandedGridView1.GetDataRow( i )["AF021"].ToString( ) + "*" + bandedGridView1.GetDataRow( i )["AF022"].ToString( ) + bandedGridView1.GetDataRow( i )["AF015"].ToString( ) + "'" )[k]["tOne"].ToString( ) ) )
                                speList.Add( libraryTable.Select( "tTwo='" + bandedGridView1.GetDataRow( i )["AF020"].ToString( ) + "*" + bandedGridView1.GetDataRow( i )["AF021"].ToString( ) + "*" + bandedGridView1.GetDataRow( i )["AF022"].ToString( ) + bandedGridView1.GetDataRow( i )["AF015"].ToString( ) + "'" )[k]["tOne"].ToString( ) );
                        }
                        if ( speList.Count > 0 )
                        {
                            foreach ( string str in speList )
                            {
                                query = str;
                                count = libraryTable.Select( "tTwo='" + bandedGridView1.GetDataRow( i )["AF020"].ToString( ) + "*" + bandedGridView1.GetDataRow( i )["AF021"].ToString( ) + "*" + bandedGridView1.GetDataRow( i )["AF022"].ToString( ) + bandedGridView1.GetDataRow( i )["AF015"].ToString( ) + "' AND tOne='" + query + "'" )[0]["tTre"].ToString( );

                                result = fc . Library ( comboBox31 . Text ,comboBox32 . Text ,textBox68 . Text ,textBox71 . Text ,bandedGridView1 . GetDataRow ( i ) [ "AF015" ] . ToString ( ) ,bandedGridView1 . GetDataRow ( i ) [ "AF020" ] . ToString ( ) + "*" + bandedGridView1 . GetDataRow ( i ) [ "AF021" ] . ToString ( ) + "*" + bandedGridView1 . GetDataRow ( i ) [ "AF022" ] . ToString ( ) ,"张" ,bandedGridView1 . GetDataRow ( i ) [ "AF023" ] . ToString ( ) ,"" ,bandedGridView1 . GetDataRow ( i ) [ "AF022" ] . ToString ( ) ,/*bandedGridView1.GetDataRow( i )["AF018"].ToString( )*/ count ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,cmj . AF001 ,query . ToString ( ) ,lookUpEdit2 . Text );
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
                //fc . deleteOfLibrary ( speList ,cmj . AF001 ,cmj . AF002 );
            }
        }
        private void outC_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            libraryTable = new DataTable( );
            conOne = e.ConOne;
            libraryTable = e.TabOne;
        }
        //入库
        protected override void storage ( )
        {
            base.storage( );


            if ( label107.Visible == true )
            {
                if ( string.IsNullOrEmpty( comboBox31.Text ) )
                {
                    MessageBox.Show( "产品名称不可为空" );
                    return;
                }
                if ( string.IsNullOrEmpty( comboBox32.Text ) )
                {
                    MessageBox.Show( "货号不可为空" );
                    return;
                }
                if ( string.IsNullOrEmpty( textBox71.Text ) )
                {
                    MessageBox.Show( "产品数量不可为空" );
                    return;
                }
                if ( bandedGridView1.GetDataRow( 0 )["AF016"].ToString( ) == "库存" )
                {
                    MessageBox.Show( "库存无法入库,请选择出库或更改状态" );
                    return;
                }
                if ( bandedGridView1.GetDataRow( 0 )["AF016"].ToString( ) == "外购" && ( ord == "实际" ) || !string.IsNullOrEmpty( textBox68.Text ) )
                {
                    MessageBox.Show( "实际订单不允许入库" );
                    return;
                }
                for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
                {
                    result = fc . Storage ( comboBox31 . Text ,comboBox32 . Text ,textBox71 . Text ,bandedGridView1 . GetDataRow ( i ) [ "AF015" ] . ToString ( ) ,bandedGridView1 . GetDataRow ( i ) [ "AF020" ] . ToString ( ) + "*" + bandedGridView1 . GetDataRow ( i ) [ "AF021" ] . ToString ( ) + "*" + bandedGridView1 . GetDataRow ( i ) [ "AF022" ] . ToString ( ) ,"张" ,bandedGridView1 . GetDataRow ( i ) [ "AF019" ] . ToString ( ) ,"" ,bandedGridView1 . GetDataRow ( i ) [ "AF023" ] . ToString ( ) ,bandedGridView1 . GetDataRow ( i ) [ "AF017" ] . ToString ( ) ,textBox13 . Text ,dateTimePicker3 . Value ,lookUpEdit1 . Text ,MulaolaoBll . Drity . GetDt ( ) ,cmj . AF001 ,bandedGridView1 . GetDataRow ( i ) [ "AF080" ] . ToString ( ) ,bandedGridView1 . GetDataRow ( i ) [ "AF081" ] . ToString ( ) ,lookUpEdit2 . Text ,textBox19 . Text ,textBox7 . Text );
                    if ( result == false )
                    {
                        MessageBox.Show( "入库失败" );
                        break;
                    }
                    else if ( i == bandedGridView1.RowCount - 1 )
                    {
                        MessageBox.Show( "已入库" );
                        try
                        {
                            for ( int k = 0 ; k < bandedGridView1.RowCount ; k++ )
                            {
                                cmj.idx = string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["idx"].ToString( ) ) == true ? 0 : Convert.ToInt32( bandedGridView1.GetDataRow( i )["idx"].ToString( ) );
                                cmj.AF080 = string.IsNullOrEmpty( textBox71.Text ) == true ? 0 : Convert.ToInt64( textBox71.Text );
                                cmj.AF081 = string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["AF081"].ToString( ) ) == true ? 0 : Convert.ToInt64( bandedGridView1.GetDataRow( i )["AF081"].ToString( ) );
                                bll.UpdateStr( cmj );
                            }
                        }
                        catch { }
                    }
                }
            }
            else
                MessageBox.Show( "非执行单据不能入库" );
        }
        //复制
        protected override void copys ( )
        {
            base.copys( );

            if ( label107.Visible == true )
                stateOfOdd = "维护复制";
            else
            {
                if ( saer == "1" )
                    stateOfOdd = "新增复制";
                else
                    stateOfOdd = "更改复制";
            }

            result = bll.Copy( cmj.AF001 ,"R_342" ,"车木件采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"复制" ,stateOfOdd );
            if ( result == false )
                MessageBox.Show( "复制失败,请重试" );
            else
            {
                cmj.AF001 = oddNumbers.purchaseContract( "SELECT MAX(AJ005) AJ005 FROM R_PQAJ" ,"AJ005" ,"R_342-" );
                stateOfOdd = "更改复制单号";
                result = bll.CopyOdd( cmj.AF001 ,"R_342" ,"车木件采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"复制" ,stateOfOdd );
                if ( result == false )
                {
                    MessageBox.Show( "复制失败,请重试" );
                    SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQAF WHERE AF001 IS NULL" );
                }
                else
                {
                    MessageBox.Show( "成功复制此表" );
                    toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                    toolSave.Enabled = toolCancel.Enabled = true;

                    label107.Visible = false;
                    textBox25.Enabled = false;
                    Ergodic.FormEvery( this );
                    Ergodic.SpliEnableTrue( spList );
                    Ergodic.TablePageEnableTrue( pageList );
                    gridControl1.DataSource = null;
                    dateTimePicker2.Enabled = dateTimePicker3.Enabled = dateTimePicker5.Enabled = false;
                    ord = "";
                    saer = "1";
                    copy = "1";
                    mainTain = "";
                    queryContent( );
                    button12_Click( null ,null );
                }
            }
        }
        #endregion

        #region 查询
        void queryContent ( )
        {
            DataTable de = SqlHelper.ExecuteDataTable( "SELECT TOP 1 *,(SELECT DBA002 FROM TPADBA WHERE AF007=DBA001) DBA002 FROM R_PQAF WHERE AF001=@AF001" ,new SqlParameter( "@AF001" ,cmj.AF001 ) );
            if ( de.Rows.Count > 0 )
            {
                lookUpEdit1.Text = de.Rows[0]["DBA002"].ToString( );
                cmj.AF008 = de.Rows[0]["AF008"].ToString( );
                DataTable dl = SqlHelper.ExecuteDataTable( "SELECT DGA003,DGA008,DGA011,DGA012,DGA017,DGA009 FROM TPADGA WHERE DGA001=@DGA001" ,new SqlParameter( "@DGA001" ,cmj.AF008 ) );
                if ( dl.Rows.Count > 0 )
                {
                    textBox19.Text = dl.Rows[0]["DGA003"].ToString( );
                    textBox10.Text = dl.Rows[0]["DGA011"].ToString( );
                    textBox7.Text = dl.Rows[0]["DGA008"].ToString( );
                    textBox9.Text = dl.Rows[0]["DGA009"].ToString( );
                    textBox8.Text = dl.Rows[0]["DGA012"].ToString( );
                    textBox6.Text = dl.Rows[0]["DGA017"].ToString( );
                }

                #region
                cmj.AF007 = de.Rows[0]["AF007"].ToString( );
                textBox13.Text = de.Rows[0]["AF010"].ToString( );
                comboBox31.Text = de.Rows[0]["AF003"].ToString( );
                textBox68 . Text = de . Rows [ 0 ] [ "AF002" ] . ToString ( );
                comboBox32 .Text = de.Rows[0]["AF004"].ToString( );
                textBox2.Text = de.Rows[0]["AF005"].ToString( );
                textBox71.Text = de.Rows[0]["AF006"].ToString( );
                textBox14.Text = de.Rows[0]["AF012"].ToString( );
                if ( !string . IsNullOrEmpty ( de . Rows [ 0 ] [ "AF013" ] . ToString ( ) ) )
                    dateTimePicker3 . Value = Convert . ToDateTime ( de . Rows [ 0 ] [ "AF013" ] . ToString ( ) );
                else
                    dateTimePicker3 . Value = DateTime . Now;
                if ( !string.IsNullOrEmpty( de.Rows[0]["AF014"].ToString( ) ) )
                    dateTimePicker2.Value = Convert.ToDateTime( de.Rows[0]["AF014"].ToString( ) );
                else
                    dateTimePicker2 . Value = DateTime . Now;
                textBox15 .Text = de.Rows[0]["AF011"].ToString( );
                if ( !string.IsNullOrEmpty( de.Rows[0]["AF009"].ToString( ) ) )
                    dateTimePicker1.Value = Convert.ToDateTime( de.Rows[0]["AF009"].ToString( ) );
                else
                    dateTimePicker1 . Value = DateTime . Now;
                comboBox23 .Text = de.Rows[0]["AF035"].ToString( );
                if ( !string.IsNullOrEmpty( de.Rows[0]["AF036"].ToString( ) ) )
                    dateTimePicker6.Value = Convert.ToDateTime( de.Rows[0]["AF036"].ToString( ) );
                else
                    dateTimePicker6 . Value = DateTime . Now;
                if ( de.Rows[0]["AF037"].ToString( ).Trim( ) == "在内" )
                    radioButton1.Checked = true;
                else if ( de.Rows[0]["AF037"].ToString( ).Trim( ) == "不在内" )
                    radioButton2.Checked = true;
                else
                    radioButton1.Checked = radioButton2.Checked = false;
                if ( de.Rows[0]["AF038"].ToString( ).Trim() == "T" )
                    radioButton3.Checked = true;
                else if ( de.Rows[0]["AF038"].ToString( ).Trim() == "F" )
                    radioButton4.Checked = true;
                else
                    radioButton3.Checked = radioButton4.Checked = false;
                if ( de.Rows[0]["AF039"].ToString( ).Trim( ) == "T" )
                {
                    radioButton6.Checked = true;
                    textBox26.Text = de.Rows[0]["AF040"].ToString( );
                }
                else if ( de.Rows[0]["AF039"].ToString( ).Trim( ) == "F" )
                    radioButton5.Checked = true;
                else
                    radioButton6.Checked = radioButton5.Checked = false;
                comboBox24.Text = de.Rows[0]["AF041"].ToString( );
                comboBox25.Text = de.Rows[0]["AF042"].ToString( );
                if ( !string.IsNullOrEmpty( de.Rows[0]["AF043"].ToString( ) ) )
                    dateTimePicker7.Value = Convert.ToDateTime( de.Rows[0]["AF043"].ToString( ) );
                else
                    dateTimePicker7 . Value = DateTime . Now;
                comboBox26 .Text = de.Rows[0]["AF044"].ToString( );
                if ( !string.IsNullOrEmpty( de.Rows[0]["AF045"].ToString( ) ) )
                    dateTimePicker8.Value = Convert.ToDateTime( de.Rows[0]["AF045"].ToString( ) );
                else
                    dateTimePicker8 . Value = DateTime . Now;
                if ( de.Rows[0]["AF046"].ToString( ).Trim() == "合格" )
                    radioButton8.Checked = true;
                else if ( de.Rows[0]["AF046"].ToString( ).Trim() == "条件接收" )
                {
                    radioButton7.Checked = true;
                    textBox3.Text = de.Rows[0]["AF047"].ToString( );
                }
                else if ( de.Rows[0]["AF046"].ToString( ).Trim() == "退货" )
                    radioButton9.Checked = true;
                else
                    radioButton7.Checked = radioButton8.Checked = radioButton9.Checked = false;
                comboBox28.Text = de.Rows[0]["AF048"].ToString( );
                if ( !string.IsNullOrEmpty( de.Rows[0]["AF049"].ToString( ) ) )
                    dateTimePicker10.Value = Convert.ToDateTime( de.Rows[0]["AF049"].ToString( ) );
                else
                    dateTimePicker10 . Value = DateTime . Now;
                comboBox27 .Text = de.Rows[0]["AF050"].ToString( );
                if ( !string.IsNullOrEmpty( de.Rows[0]["AF051"].ToString( ) ) )
                    dateTimePicker9.Value = Convert.ToDateTime( de.Rows[0]["AF051"].ToString( ) );
                else
                    dateTimePicker9 . Value = DateTime . Now;
                textBox4 .Text = de.Rows[0]["AF052"].ToString( );
                if ( de.Rows[0]["AF053"].ToString( ).Trim() == "合格" )
                    radioButton12.Checked = true;
                else if ( de.Rows[0]["AF053"].ToString( ).Trim() == "条件接收" )
                {
                    radioButton11.Checked = true;
                    textBox24.Text = de.Rows[0]["AF054"].ToString( );
                }
                else if ( de.Rows[0]["AF053"].ToString( ).Trim() == "退货" )
                    radioButton10.Checked = true;
                else
                    radioButton12.Checked = radioButton11.Checked = radioButton10.Checked = false;
                textBox11.Text = de.Rows[0]["AF055"].ToString( );
                textBox12.Text = de.Rows[0]["AF056"].ToString( );
                textBox16.Text = de.Rows[0]["AF057"].ToString( );
                textBox20.Text = de.Rows[0]["AF058"].ToString( );
                textBox18.Text = de.Rows[0]["AF059"].ToString( );
                textBox17.Text = de.Rows[0]["AF060"].ToString( );
                textBox23.Text = de.Rows[0]["AF061"].ToString( );
                textBox22.Text = de.Rows[0]["AF062"].ToString( );
                textBox21.Text = de.Rows[0]["AF063"].ToString( );
                comboBox29.Text = de.Rows[0]["AF064"].ToString( );
                comboBox30.Text = de.Rows[0]["AF065"].ToString( );
                if ( !string.IsNullOrEmpty( de.Rows[0]["AF066"].ToString( ) ) )
                    dateTimePicker11.Value = Convert.ToDateTime( de.Rows[0]["AF066"].ToString( ) );
                else
                    dateTimePicker11 . Value = DateTime . Now;
                textBox56 .Text = de.Rows[0]["AF067"].ToString( );
                textBox55.Text = de.Rows[0]["AF068"].ToString( );
                if ( !string.IsNullOrEmpty( de.Rows[0]["AF069"].ToString( ) ) )
                    dateTimePicker14.Value = Convert.ToDateTime( de.Rows[0]["AF069"].ToString( ) );
                else
                    dateTimePicker14 . Value = DateTime . Now;
                textBox54 .Text = de.Rows[0]["AF070"].ToString( );
                if ( !string.IsNullOrEmpty( de.Rows[0]["AF071"].ToString( ) ) )
                    dateTimePicker13.Value = Convert.ToDateTime( de.Rows[0]["AF071"].ToString( ) );
                else
                    dateTimePicker13 . Value = DateTime . Now;
                textBox53 .Text = de.Rows[0]["AF072"].ToString( );
                if ( !string.IsNullOrEmpty( de.Rows[0]["AF073"].ToString( ) ) )
                    dateTimePicker12.Value = Convert.ToDateTime( de.Rows[0]["AF073"].ToString( ) );
                else
                    dateTimePicker12 . Value = DateTime . Now;
                textBox25 .Text = de.Rows[0]["AF075"].ToString( );
                if ( de.Rows[0]["AF077"].ToString( ).Trim() != "复制" )
                    label98.Visible = false;
                else if ( de.Rows[0]["AF077"].ToString( ).Trim() == "复制" )
                    label98.Visible = true;
                lookUpEdit2.Text = de.Rows[0]["AF079"].ToString( );
                checkBox1.Checked = de.Rows[0]["AF078"].ToString( ).Trim( ) == "T" ? true : false;
                checkBox2.Checked = de.Rows[0]["AF083"].ToString( ).Trim( ) == "T" ? true : false;
                #endregion
                //,AF078
                tableSele = SqlHelper.ExecuteDataTable( "SELECT idx,AF002,AF003,AF004,AF006,AF015,AF016,AF017,AF018,AF019,AF020,AF021,AF022,AF023,AF024,AF025,AF026,AF027,AF028,AF029,AF029,AF030,AF031,AF032,AF033,AF034,AF080,AF081,AF084,CONVERT(FLOAT,AF087) AF087,CONVERT(FLOAT,AF088) AF088  FROM R_PQAF WHERE AF001=@AF001 ORDER BY idx DESC" ,new SqlParameter( "@AF001" ,cmj.AF001 ) );
                gridControl1.DataSource = tableSele;
                assignSum ( );
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

            ord = "";
            saer = "2";
            queryContent( );
        }
        SelectAll.CheMuJiancontractQueryAll query = new SelectAll.CheMuJiancontractQueryAll( );
        protected override void select ( )
        {
            base.select( );

            cmj = new MulaolaoLibrary.CheMuJianContractLibrary( );
            query.StartPosition = FormStartPosition.CenterScreen;
            query.PassDataBetweenForm += new SelectAll.CheMuJiancontractQueryAll.PassDataBetweenFormHandler( query_PassDataBetWeenForm );
            query.ShowDialog( );

            if ( cmj.AF001 == null || cmj.AF001 == "" )
                MessageBox.Show( "您没有选择任何信息" );
            else
                autoQuery( );
        }
        private void query_PassDataBetWeenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            cmj.AF001 = e.ConOne;
            cmj.AF002 = e.ConTwo;
            //textBox68.Text = e.ConTwo;
            cmj.AF003 = e.ConTre;
            //comboBox31.Text = e.ConTre;
            cmj.AF004 = e.ConFor;
            //comboBox32.Text = e.ConFor;
            cmj.AF005 = e.ConFiv;
            //textBox2.Text = e.ConFiv;
            if ( !string.IsNullOrEmpty( e.ConSix ) )
                cmj.AF006 = Convert.ToInt64( e.ConSix );
            else
                cmj.AF006 = 0;
            //textBox71.Text = e.ConSix;
            //textBox19.Text = e.ConEgi;
            if ( e.ConNin == "执行" )
                label107.Visible = true;
            else
                label107.Visible = false;
            cmj.AF008 = e.ConEleven;
            cmj.AF010 = e.ConTwelve;
        }
        //流水号
        Youqicaigou yq = new Youqicaigou( );
        private void button4_Click ( object sender ,EventArgs e )
        {
            DataTable dhr = SqlHelper.ExecuteDataTable( "SELECT PQF01,PQF02,PQF03,PQF04,PQF06,PQF07,PQF08 FROM R_PQF A,R_REVIEWS B,R_MLLCXMC C WHERE A.PQF01 = B.RES06 AND B.RES01 = C.CX01 AND C.CX02 = '订单销售合同(R_001)' AND RES05 = '执行' ORDER BY PQF01 DESC" );
            if ( dhr.Rows.Count < 1 )
                MessageBox.Show( "没有产品信息" );
            else
            {
                dhr.Columns.Add( "check" ,System.Type.GetType( "System.Boolean" ) );
                yq.gridControl1.DataSource = dhr;
                yq.sy = "1";
                yq.Text = "R_342 信息查询";
                yq.PassDataBetweenForm += new Youqicaigou.PassDataBetweenFormHandler( yq_PassDataBetweenForm );
                yq.StartPosition = FormStartPosition.CenterScreen;
                yq.ShowDialog( );
            }
        }
        private void yq_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            if ( e.ConOne.IndexOf( "," ) > 0 )
                textBox68.Text = string.Join( "," ,e.ConOne.Split( ',' ).Distinct( ).ToArray( ) );
            else
                textBox68.Text = e.ConOne;
            cmj.AF002 = textBox68.Text;
            if ( e.ConTwo.IndexOf( "," ) > 0 )
                textBox2.Text = string.Join( "," ,e.ConTwo.Split( ',' ).Distinct( ).ToArray( ) );
            else
                textBox2.Text = e.ConTwo;
            cmj.AF005 = textBox2.Text;
            if ( e.ConTre.IndexOf( "," ) > 0 )
                comboBox32.Text = string.Join( "," ,e.ConTre.Split( ',' ).Distinct( ).ToArray( ) );
            else
                comboBox32.Text = e.ConTre;
            cmj.AF004 = comboBox32.Text;
            if ( e.ConFor.IndexOf( "," ) > 0 )
                comboBox31.Text = string.Join( "," ,e.ConFor.Split( ',' ).Distinct( ).ToArray( ) );
            else
                comboBox31.Text = e.ConFor;
            cmj.AF003 = comboBox31.Text;
            if ( !string.IsNullOrEmpty( e.ConFor ) )
                cmj.AF006 = Convert.ToInt64( e.ConFiv );
            else
                cmj.AF006 = 0;
            textBox71.Text = e.ConFiv;
        }
        //计划
        planeQuery pq = new planeQuery( );
        private void button14_Click ( object sender ,EventArgs e )
        {
            DataTable plq = SqlHelper.ExecuteDataTable( "SELECT DISTINCT PQF03,PQF04,PQF06 FROM R_PQF A,R_MLLCXMC B,R_REVIEWS C WHERE A.PQF01 = C.RES06 AND B.CX01 = C.RES01 AND RES05 = '执行' AND CX02 = '订单销售合同(R_001)' ORDER BY PQF04" );
            if ( plq.Rows.Count > 0 )
            {
                pq.Text = "R_342 信息查询";
                pq.gridControl1.DataSource = plq;
                pq.StartPosition = FormStartPosition.CenterScreen;
                pq.PassDataBetweenForm += new planeQuery.PassDataBetweenFormHandler( pq_PassDataBetweenForm );
                pq.ShowDialog( );
            }
        }
        void pq_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            textBox68.Text = "";
            cmj.AF003 = e.ConOne;
            comboBox31.Text = e.ConOne;
            cmj.AF004 = e.ConTwo;
            comboBox32.Text = e.ConTwo;
            if ( !string.IsNullOrEmpty( e.ConTre ) )
                cmj.AF006 = Convert.ToInt64( e.ConTre );
            else
                cmj.AF006 = 0;
            textBox71.Text = e.ConTre;
            textBox2.Text = "";
        }
        //供应商
        R_FrmTPADGA tpadga = new R_FrmTPADGA( );
        private void button5_Click ( object sender ,EventArgs e )
        {
            DataTable did = SqlHelper.ExecuteDataTable( "SELECT DGA001,DGA003,DGA008,DGA011,DGA012,DGA017,DGA009 FROM TPADGA WHERE DGA052='F'" );
            if ( did.Rows.Count < 1 )
                MessageBox.Show( "没有供应商信息" );
            else
            {
                tpadga.gridControl2.DataSource = did;
                tpadga.st = "2";
                tpadga.Text = "R_342 信息查询";
                tpadga.PassDataBetweenForm += new R_FrmTPADGA.PassDataBetweenFomrHandler( tpadga_PassDataBetweenForm );
                tpadga.StartPosition = FormStartPosition.CenterScreen;
                tpadga.ShowDialog( );
            }
        }
        private void tpadga_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            cmj.AF008 = e.ConOne;
            textBox19.Text = e.ConTwo;
            textBox10.Text = e.ConFiv;
            textBox7.Text = e.ConTre;
            textBox9.Text = e.ConFor;
            textBox8.Text = e.ConSix;
            textBox6.Text = e.ConSev;
        }
        #endregion
        
        #region 表格
        //新建
        DataTable tableBuild;
        void biao_One ( )
        {
            cmj.AF011 = textBox15.Text;
            cmj.AF002 = textBox68.Text;
            cmj.AF003 = comboBox31.Text;
            cmj.AF004 = comboBox32.Text;
            if ( !string.IsNullOrEmpty( textBox71.Text ) )
                cmj.AF006 = Convert.ToInt64( textBox71.Text );
            else
                cmj.AF006 = 0;
            cmj.AF015 = partName . Text;
            if ( radioButton13.Checked )
            {
                cmj.AF016 = "库存";
                if ( !string.IsNullOrEmpty( textBox1.Text ) )
                    cmj.AF018 = Convert.ToInt64( textBox1.Text );
                else
                    cmj.AF018 = 0;
                cmj.AF017 = 0;
            }
            else if ( radioButton14.Checked )
            {
                cmj.AF016 = "外购";
                if ( !string.IsNullOrEmpty( textBox28.Text ) )
                    cmj.AF017 = Convert.ToInt64( textBox28.Text );
                else
                    cmj.AF017 = 0;
                cmj.AF018 = 0;
            }
            if ( !string.IsNullOrEmpty( comboBox1.Text ) )
                cmj.AF019 = Convert.ToDecimal( comboBox1.Text );
            else
                cmj.AF019 = 0;
            if ( !string.IsNullOrEmpty( textBox32.Text ) )
                cmj.AF020 = Convert.ToDecimal( textBox32.Text );
            else
                cmj.AF020 = 0;
            if ( !string.IsNullOrEmpty( textBox33.Text ) )
                cmj.AF021 = Convert.ToDecimal( textBox33.Text );
            else
                cmj.AF021 = 0;
            if ( !string.IsNullOrEmpty( textBox34.Text ) )
                cmj.AF022 = Convert.ToDecimal( textBox34.Text );
            else
                cmj.AF022 = 0;
            if ( !string.IsNullOrEmpty( comboBox12.Text ) )
                cmj.AF023 = Convert.ToDecimal( comboBox12.Text );
            else
                cmj.AF023 = 0;
            cmj.AF024 = dateTimePicker4.Value;
            cmj.AF025 = dateTimePicker5.Value;
            cmj.AF026 = comboBox15.Text;
            if ( !string.IsNullOrEmpty( comboBox16.Text ) )
                cmj.AF027 = Convert.ToInt32( comboBox16.Text );
            else
                cmj.AF027 = 0;
            if ( !string.IsNullOrEmpty( comboBox17.Text ) )
                cmj.AF028 = Convert.ToInt32( comboBox17.Text );
            else
                cmj.AF028 = 0;
            if ( !string.IsNullOrEmpty( comboBox18.Text ) )
                cmj.AF029 = Convert.ToInt32( comboBox18.Text );
            else
                cmj.AF029 = 0;
            if ( !string.IsNullOrEmpty( comboBox19.Text ) )
                cmj.AF030 = Convert.ToInt32( comboBox19.Text );
            else
                cmj.AF030 = 0;
            if ( !string.IsNullOrEmpty( comboBox21.Text ) )
                cmj.AF031 = Convert.ToInt32( comboBox21.Text );
            else
                cmj.AF031 = 0;
            if ( !string.IsNullOrEmpty( comboBox20.Text ) )
                cmj.AF032 = Convert.ToInt32( comboBox20.Text );
            else
                cmj.AF032 = 0;
            if ( !string.IsNullOrEmpty( comboBox3.Text ) )
                cmj.AF033 = Convert.ToInt32( comboBox3.Text );
            else
                cmj.AF033 = 0;
            if ( !string.IsNullOrEmpty( comboBox22.Text ) )
                cmj.AF034 = Convert.ToInt32( comboBox22.Text );
            else
                cmj.AF034 = 0;
            //cmj.AF078 = checkBox1.Checked == true ? "T" : "F";
            cmj . AF084 = partInfo . Text;
            cmj . AF087 = string . IsNullOrEmpty ( textBox30 . Text ) == true ? 0 : Convert . ToDecimal ( textBox30 . Text );
            cmj . AF088 = string . IsNullOrEmpty ( textBox31 . Text ) == true ? 0 : Convert . ToDecimal ( textBox31 . Text );
        }
        void build ( )
        {
            int count = 0;
            DataTable da = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQAF WHERE AF001=@AF001  AND AF015=@AF015 AND AF020=@AF020 AND AF021=@AF021 AND AF022=@AF022" ,new SqlParameter( "@AF001" ,cmj.AF001 ) /*,new SqlParameter( "@AF002" ,cmj.AF002 )*/ ,new SqlParameter( "@AF015" ,cmj.AF015 ) ,new SqlParameter( "@AF020" ,cmj.AF020 ) ,new SqlParameter( "@AF021" ,cmj.AF021 ) ,new SqlParameter( "@AF022" ,cmj.AF022 ) );
            if ( da.Rows.Count < 1 )
            {
                count = SqlHelper . ExecuteNonQuery ( "INSERT INTO R_PQAF (AF001,AF002,AF003,AF004,AF006,AF015,AF016,AF017,AF018,AF019,AF020,AF021,AF022,AF023,AF024,AF025,AF026,AF027,AF028,AF029,AF030,AF031,AF032,AF033,AF034,AF008,AF084,AF087,AF088) VALUES (@AF001,@AF002,@AF003,@AF004,@AF006,@AF015,@AF016,@AF017,@AF018,@AF019,@AF020,@AF021,@AF022,@AF023,@AF024,@AF025,@AF026,@AF027,@AF028,@AF029,@AF030,@AF031,@AF032,@AF033,@AF034,@AF008,@AF084,@AF087,@AF088)" ,new SqlParameter ( "@AF001" ,cmj . AF001 ) ,new SqlParameter ( "@AF002" ,cmj . AF002 ) ,new SqlParameter ( "@AF003" ,cmj . AF003 ) ,new SqlParameter ( "@AF004" ,cmj . AF004 ) ,new SqlParameter ( "@AF006" ,cmj . AF006 ) ,new SqlParameter ( "@AF015" ,cmj . AF015 ) ,new SqlParameter ( "@AF016" ,cmj . AF016 ) ,new SqlParameter ( "@AF017" ,cmj . AF017 ) ,new SqlParameter ( "@AF018" ,cmj . AF018 ) ,new SqlParameter ( "@AF019" ,cmj . AF019 ) ,new SqlParameter ( "@AF020" ,cmj . AF020 ) ,new SqlParameter ( "@AF021" ,cmj . AF021 ) ,new SqlParameter ( "@AF022" ,cmj . AF022 ) ,new SqlParameter ( "@AF023" ,cmj . AF023 ) ,new SqlParameter ( "@AF024" ,cmj . AF024 ) ,new SqlParameter ( "@AF025" ,cmj . AF025 ) ,new SqlParameter ( "@AF026" ,cmj . AF026 ) ,new SqlParameter ( "@AF027" ,cmj . AF027 ) ,new SqlParameter ( "@AF028" ,cmj . AF028 ) ,new SqlParameter ( "@AF029" ,cmj . AF029 ) ,new SqlParameter ( "@AF030" ,cmj . AF030 ) ,new SqlParameter ( "@AF031" ,cmj . AF031 ) ,new SqlParameter ( "@AF032" ,cmj . AF032 ) ,new SqlParameter ( "@AF033" ,cmj . AF033 ) ,new SqlParameter ( "@AF034" ,cmj . AF034 ) ,new SqlParameter ( "@AF008" ,cmj . AF008 ) ,new SqlParameter ( "@AF084" ,cmj . AF084 ) ,new SqlParameter ( "@AF087" ,cmj . AF087 ) ,new SqlParameter ( "@AF088" ,cmj . AF088 ) );
                if ( count < 1 )
                    MessageBox.Show( "录入数据失败" );
                else
                {
                    MessageBox.Show( "成功录入数据" );
                    try
                    {
                        if ( label107.Visible == true )
                            stateOfOdd = "维护新建";
                        else
                        {
                            if ( saer == "1" )
                                stateOfOdd = "新增新建";
                            else
                                stateOfOdd = "更改新建";
                        }
                        StringBuilder strSql = new StringBuilder( );
                        strSql.Append( "INSERT INTO R_PQAF (AF001,AF002,AF003,AF004,AF006,AF015,AF016,AF017,AF018,AF019,AF020,AF021,AF022,AF023,AF024,AF025,AF026,AF027,AF028,AF029,AF030,AF031,AF032,AF033,AF034,AF008,AF084,AF087,AF088) VALUES" );
                        strSql.AppendFormat( "('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}')" ,cmj.AF001 ,cmj.AF002 ,cmj.AF003 ,cmj.AF004 ,cmj.AF006 ,cmj.AF015 ,cmj.AF016 ,cmj.AF017 ,cmj.AF018 ,cmj.AF019 ,cmj.AF020 ,cmj.AF021 ,cmj.AF022 ,cmj.AF023 ,cmj.AF024 ,cmj.AF025 ,cmj.AF026 ,cmj.AF027 ,cmj.AF028 ,cmj.AF029 ,cmj.AF030 ,cmj.AF031 ,cmj.AF032 ,cmj.AF033 ,cmj.AF034 ,cmj.AF008 ,cmj . AF084 ,cmj . AF087 ,cmj . AF088 );
                        SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfComparation( "R_342" ,"车木件采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,cmj.AF001 ,strSql.ToString( ).Replace( "'" ,"''" ) ,"新建" ,stateOfOdd ) );
                    }
                    catch { }
                    finally
                    {
                        //every( );
                        button12_Click( null ,null );
                    }
                }
            }
            else
                MessageBox.Show( "单号:" + cmj.AF001 + "中已经存在\n\r流水号:" + cmj.AF002 + "\n\r物料名称:" + cmj.AF015 + "\n\r长:" + cmj.AF020 + "\n\r宽:" + cmj.AF021 + "\n\r高:" + cmj.AF022 + "\n\r的记录,请核实后再录入" );
        }
        void builds ( )
        {
            DataTable de = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQAF WHERE AF004=@AF004 AND AF015=@AF015 AND AF020=@AF020 AND AF021=@AF021 AND AF022=@AF022 AND AF001=(SELECT MAX(AF001) AF001 FROM R_PQAF WHERE AF004=@AF004 AND AF015=@AF015 AND AF020=@AF020 AND AF021=@AF021 AND AF022=@AF022)" ,new SqlParameter( "@AF004" ,cmj.AF004 ) ,new SqlParameter( "@AF015" ,cmj.AF015 ) ,new SqlParameter( "@AF020" ,cmj.AF020 ) ,new SqlParameter( "@AF021" ,cmj.AF021 ) ,new SqlParameter( "@AF022" ,cmj.AF022 ) );
            if ( de.Rows.Count > 0 )
            {
                if ( de.Select( "AF023='" + comboBox12.Text + "'" ).Length <= 0 )
                    MessageBox.Show( "每个单价与计划订单不一致,应为:" + de.Rows[0]["AF023"].ToString( ) + "" );
                else
                {
                    if ( !de.Select( "AF019='" + comboBox1.Text + "'" ).Length.Equals( 1 ) )
                        MessageBox.Show( "每套用量与计划订单不一致,应为:" + de.Rows[0]["AF019"].ToString( ) + "" );
                    else
                    {
                        build( );
                    }
                }
            }
            else
                build( );
        }
        void outSourc ( )
        {
            if ( radioButton13.Checked )
                MessageBox.Show( "只能开外购合同" );
            else
            {
                string sx = Math.Round( Convert.ToDecimal( Operation.MultiTwoTbCbes( textBox71 ,comboBox1 ) ) ,0 ).ToString( );
                if ( !string.IsNullOrEmpty( sx ) && !string.IsNullOrEmpty( textBox28.Text ) )
                {
                    if ( Convert.ToDecimal( sx ) != Convert.ToDecimal( textBox28.Text ) )
                        MessageBox.Show( "外购数量有误,请核实" );
                    else
                        builds( );
                }
            }
        }
        void outSources ( )
        {
            if ( radioButton13.Checked )
                MessageBox.Show( "只能开外购合同" );
            else
            {
                string sx = Math.Round( Convert.ToDecimal( Operation.MultiTwoTbCbes( textBox71 ,comboBox1 ) ) ,0 ).ToString( );
                if ( !string.IsNullOrEmpty( sx ) && !string.IsNullOrEmpty( textBox28.Text ) )
                {
                    if ( Convert.ToDecimal( sx ) != Convert.ToDecimal( textBox28.Text ) )
                        MessageBox.Show( "外购数量有误,请核实" );
                    else
                        build( );
                }
            }
        }
        void plan ( )
        {
            if ( radioButton14.Checked == true )
            {
                if ( Logins.number == "MLL-0001" )
                {
                    string sx = Math.Round( Convert.ToDecimal( Operation.MultiTwoTbCbes( textBox71 ,comboBox1 ) ) ,0 ).ToString( );
                    if ( !string.IsNullOrEmpty( sx ) && !string.IsNullOrEmpty( textBox28.Text ) )
                    {
                        if ( Convert.ToDecimal( sx ) != Convert.ToDecimal( textBox28.Text ) )
                            MessageBox.Show( "外购数量有误,请核实" );
                        else
                            build( );
                    }
                }
                else
                    MessageBox.Show( "库存数量还有剩余,需要总经理补开" );
            }
            //只能开具库存合同
            else
            {
                if ( !string.IsNullOrEmpty( textBox27.Text ) && !string.IsNullOrEmpty( textBox1.Text ) )
                {
                    if ( Math.Round( Convert.ToDecimal( textBox27.Text ) ,0 ) < Convert.ToDecimal( textBox1.Text ) )
                        MessageBox.Show( "出库数量必须小于库存数量" );
                    //且出库数小于等于库存数量
                    else
                    {
                        string str = Math.Round( Convert.ToDecimal( Operation.MultiTwoTbCbes( textBox71 ,comboBox1 ) ) ,0 ).ToString( );
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
            if ( string.IsNullOrEmpty( textBox15.Text ) )
            {
                MessageBox.Show( "合同批号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox31.Text ) )
            {
                MessageBox.Show( "产品名称不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( cmj.AF008 ) || string.IsNullOrEmpty( textBox19.Text ) )
            {
                MessageBox.Show( "请选择供应商" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox32.Text ) )
            {
                MessageBox.Show( "货号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox71.Text ) )
            {
                MessageBox.Show( "产品数量不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( partInfo . Text ) )
            {
                MessageBox . Show ( "材料名称不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( partName . Text ) )
            {
                MessageBox.Show( "物料名称不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox1.Text ) )
            {
                MessageBox.Show( "每套用量不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox12.Text ) )
            {
                MessageBox.Show( "每个单价不可为空" );
                return;
            }
            if ( !radioButton13.Checked && !radioButton14.Checked )
            {
                MessageBox.Show( "请选择库存或外购" );
                return;
            }
            if ( dateTimePicker4.Value < MulaolaoBll . Drity . GetDt ( ).AddDays( 5 ) )
            {
                MessageBox.Show( "约定供期必须在当天的基础上延迟5天" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox15.Text ) )
            {
                MessageBox.Show( "请选择清水或混水" );
                return;
            }
            biao_One( );

            #region
            /*
            #region EveryOne Only Once Plan
            bool result = pc.PlanActual( cmj.AF015 ,cmj.AF020 + "*" + cmj.AF021 + "*" + cmj.AF022 ,cmj.AF004 );
            if ( ord == "计划" || string.IsNullOrEmpty( textBox68.Text ) )
            {

                if ( result == true )
                    outSources( );
                else
                {
                    if ( cmj.AF011.Length > 8 && cmj.AF011.Substring( 0 ,8 ) == "MLL-0001" )
                    {
                        if ( result == true )
                            outSourc( );
                        else
                            plan( );
                    }
                    else
                        MessageBox.Show( "此合同为补开,请找总经理处理" );
                }
            }
            #endregion

            #region EveryOne Only Once Actual
            if ( ord == "实际" || !string.IsNullOrEmpty( textBox68.Text ) )
            {
                DataTable yesNoActual = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQAF WHERE AF004=@AF004 AND AF020=@AF020 AND AF021=@AF021 AND AF022=@AF022 AND AF002=@AF002" ,new SqlParameter( "@AF002" ,cmj.AF002 ) ,new SqlParameter( "@AF004" ,cmj.AF004 ) ,new SqlParameter( "@AF020" ,cmj.AF020 ) ,new SqlParameter( "@AF021" ,cmj.AF021 ) ,new SqlParameter( "@AF022" ,cmj.AF022 ) );
                if ( yesNoActual.Rows.Count > 0 )
                {
                    if ( cmj.AF011.Length > 8 && cmj.AF011.Substring( 0 ,8 ) == "MLL-0001" )
                    {
                        if ( result == true )
                            outSourc( );
                        else
                            plan( );
                    }
                    else
                        MessageBox.Show( "此合同为补开,请找总经理处理" );
                }
                else
                {
                    if ( result == true )
                        outSourc( );
                    else
                        plan( );
                }
            }
            #endregion
        */
            #endregion


            #region 计划订单  更改新建  流水号为空
            if ( ord == "计划" || string.IsNullOrEmpty( textBox68.Text ) )
            {
                //计划可以开具多份
                //同货号、物料名称、规格是否已经开过计划订单
                DataTable yesNoAcPlan = SqlHelper.ExecuteDataTable( "SELECT AC03,AC18 FROM R_PQAC WHERE AC18=(SELECT MAX(AC18) FROM R_PQAC WHERE AC02=@AC02 AND AC04=@AC04 AND AC05=@AC05)" ,new SqlParameter( "@AC02" ,cmj.AF004 ) ,new SqlParameter( "@AC04" ,cmj.AF015 ) ,new SqlParameter( "@AC05" ,cmj.AF020 + "*" + cmj.AF021 + "*" + cmj.AF022 ) );
                //有  继续开  只能开外购  且每张套数  每张单价  原价/m³都必须与第一份计划订单相同
                if ( yesNoAcPlan.Rows.Count > 0 && string.IsNullOrEmpty( yesNoAcPlan.Rows[0]["AC18"].ToString( ) ) == false )
                {
                    DataTable yesNoAdPlan = SqlHelper.ExecuteDataTable( "SELECT SUM(AD05+ISNULL(AD20,0)) AD05 FROM R_PQAD WHERE AD01=@AD01" ,new SqlParameter( "@AD01" ,yesNoAcPlan.Rows[0]["AC18"].ToString( ) ) );
                    //有
                    if ( yesNoAdPlan.Rows.Count > 0 && !string.IsNullOrEmpty( yesNoAdPlan.Rows[0]["AD05"].ToString( ) ) )
                    {
                        if ( yesNoAcPlan.Rows[0]["AC03"].ToString( ) == yesNoAdPlan.Rows[0]["AD05"].ToString( ) )
                            outSources( );
                        else
                        {
                            //开合同人是否是MLL-0001
                            if ( cmj.AF011.Length > 8 && cmj.AF011.Substring( 0 ,8 ) == "MLL-0001" )
                                outSourc( );
                            else
                                MessageBox.Show( "此合同为补开,请找总经理处理" );
                        }
                    }
                    else
                    {
                        //开合同人是否是MLL-0001
                        if ( cmj.AF011.Length > 8 && cmj.AF011.Substring( 0 ,8 ) == "MLL-0001" )
                            outSourc( );
                        else
                            MessageBox.Show( "此合同为补开,请找总经理处理" );
                    }
                }
                else
                    //无  直接开  只能开外购
                    outSources( );
            }
            #endregion

            #region 实际订单  更改新建  流水号不为空
            else if ( ord == "实际" || !string.IsNullOrEmpty( textBox68.Text ) )
            {
      
                //result=true  表示没有库存
                bool result = pc.PlanActual( cmj.AF015 ,cmj.AF020 + "*" + cmj.AF021 + "*" + cmj.AF022 ,cmj.AF004 );
                //vode=true 表示合同没开过此物品
                bool vode = pc.PlanInDataBaseCar( cmj.AF002 ,cmj.AF015 ,cmj.AF020 ,cmj.AF021 ,cmj.AF022 );
                if ( result == true )
                {
                    if ( vode == true )
                        outSources( );
                    else
                    {
                        if ( cmj.AF011.Length > 8 && cmj.AF011.Substring( 0 ,8 ) == "MLL-0001" )
                            outSources( );
                        else
                            MessageBox.Show( "此单为超补,需要总经理处理" );
                    }
                }
                else
                {
                    if ( vode == true )
                        plan( );
                    else
                    {
                        if ( cmj.AF011.Length > 8 && cmj.AF011.Substring( 0 ,8 ) == "MLL-0001" )
                            plan( );
                        else
                            MessageBox.Show( "此单为超补,需要总经理处理" );
                    }
                }
            }
            #endregion

        }
        //编辑
        void upda ( )
        {
            DataRow row;
            int num = bandedGridView1 . FocusedRowHandle;
            if ( saer == "1" )
            {
                row = tableBuild . Rows [ num ];
                row . BeginEdit ( );
                row [ "AF002" ] = cmj . AF002;
                row [ "AF003" ] = cmj . AF003;
                row [ "AF004" ] = cmj . AF004;
                row [ "AF006" ] = cmj . AF006;
                row [ "AF015" ] = cmj . AF015;
                row [ "AF016" ] = cmj . AF016;
                row [ "AF017" ] = cmj . AF017;
                row [ "AF018" ] = cmj . AF018;
                row [ "AF019" ] = cmj . AF019;
                row [ "AF020" ] = cmj . AF020;
                row [ "AF021" ] = cmj . AF021;
                row [ "AF022" ] = cmj . AF022;
                row [ "AF023" ] = cmj . AF023;
                row [ "AF024" ] = cmj . AF024;
                row [ "AF025" ] = cmj . AF025;
                row [ "AF026" ] = cmj . AF026;
                row [ "AF027" ] = cmj . AF027;
                row [ "AF028" ] = cmj . AF028;
                row [ "AF029" ] = cmj . AF029;
                row [ "AF030" ] = cmj . AF030;
                row [ "AF031" ] = cmj . AF031;
                row [ "AF032" ] = cmj . AF032;
                row [ "AF033" ] = cmj . AF033;
                row [ "AF034" ] = cmj . AF034;
                row [ "AF084" ] = cmj . AF084;
                row [ "AF087" ] = cmj . AF087;
                row [ "AF088" ] = cmj . AF088;
                row . EndEdit ( );
            }
            else if ( saer == "2" )
            {
                row = tableSele . Rows [ num ];
                row . BeginEdit ( );
                row [ "AF002" ] = cmj . AF002;
                row [ "AF003" ] = cmj . AF003;
                row [ "AF004" ] = cmj . AF004;
                row [ "AF006" ] = cmj . AF006;
                row [ "AF015" ] = cmj . AF015;
                row [ "AF016" ] = cmj . AF016;
                row [ "AF017" ] = cmj . AF017;
                row [ "AF018" ] = cmj . AF018;
                row [ "AF019" ] = cmj . AF019;
                row [ "AF020" ] = cmj . AF020;
                row [ "AF021" ] = cmj . AF021;
                row [ "AF022" ] = cmj . AF022;
                row [ "AF023" ] = cmj . AF023;
                row [ "AF024" ] = cmj . AF024;
                row [ "AF025" ] = cmj . AF025;
                row [ "AF026" ] = cmj . AF026;
                row [ "AF027" ] = cmj . AF027;
                row [ "AF028" ] = cmj . AF028;
                row [ "AF029" ] = cmj . AF029;
                row [ "AF030" ] = cmj . AF030;
                row [ "AF031" ] = cmj . AF031;
                row [ "AF032" ] = cmj . AF032;
                row [ "AF033" ] = cmj . AF033;
                row [ "AF034" ] = cmj . AF034;
                row [ "AF084" ] = cmj . AF084;
                row [ "AF087" ] = cmj . AF087;
                row [ "AF088" ] = cmj . AF088;
                row . EndEdit ( );
            }

            //every ( );
        }
        void upda_One ( )
        {
            //AF001=@AF001 AND AF015=@AF015 AND AF020=@AF020 AND AF021=@AF021 AND AF022=@AF022
            int count = SqlHelper . ExecuteNonQuery ( "UPDATE R_PQAF SET AF003=@AF003,AF004=@AF004,AF006=@AF006,AF016=@AF016,AF017=@AF017,AF018=@AF018,AF019=@AF019,AF023=@AF023,AF024=@AF024,AF025=@AF025,AF026=@AF026,AF027=@AF027,AF028=@AF028,AF029=@AF029,AF030=@AF030,AF031=@AF031,AF032=@AF032,AF033=@AF033,AF034=@AF034,AF084=@AF084,AF087=@AF087,AF088=@AF088 WHERE AF001=@AF001 AND idx=@idx" /*,new SqlParameter( "@AF001" ,cmj.AF001 ) */,new SqlParameter ( "@AF002" ,cmj . AF002 ) ,new SqlParameter ( "@AF003" ,cmj . AF003 ) ,new SqlParameter ( "@AF004" ,cmj . AF004 ) ,new SqlParameter ( "@AF006" ,cmj . AF006 ) /*,new SqlParameter( "@AF015" ,cmj.AF015 )*/ ,new SqlParameter ( "@AF016" ,cmj . AF016 ) ,new SqlParameter ( "@AF017" ,cmj . AF017 ) ,new SqlParameter ( "@AF018" ,cmj . AF018 ) ,new SqlParameter ( "@AF019" ,cmj . AF019 ) /*,new SqlParameter( "@AF020" ,cmj.AF020 )*//* ,new SqlParameter( "@AF021" ,cmj.AF021 )*/ /*,new SqlParameter( "@AF022" ,cmj.AF022 )*/ ,new SqlParameter ( "@AF023" ,cmj . AF023 ) ,new SqlParameter ( "@AF024" ,cmj . AF024 ) ,new SqlParameter ( "@AF025" ,cmj . AF025 ) ,new SqlParameter ( "@AF026" ,cmj . AF026 ) ,new SqlParameter ( "@AF027" ,cmj . AF027 ) ,new SqlParameter ( "@AF028" ,cmj . AF028 ) ,new SqlParameter ( "@AF029" ,cmj . AF029 ) ,new SqlParameter ( "@AF030" ,cmj . AF030 ) ,new SqlParameter ( "@AF031" ,cmj . AF031 ) ,new SqlParameter ( "@AF032" ,cmj . AF032 ) ,new SqlParameter ( "@AF033" ,cmj . AF033 ) ,new SqlParameter ( "@AF034" ,cmj . AF034 ) ,new SqlParameter ( "@idx" ,cmj . idx ) ,new SqlParameter ( "@AF001" ,cmj . AF001 ) ,new SqlParameter ( "@AF084" ,cmj . AF084 ) ,new SqlParameter ( "@AF087" ,cmj . AF087 ) ,new SqlParameter ( "@AF088" ,cmj . AF088 ) );
            if ( count < 1 )
                MessageBox.Show( "编辑数据失败" );
            else
            {
                MessageBox.Show( "成功编辑数据" );
                try
                {
                    if ( label107.Visible == true )
                        stateOfOdd = "维护编辑";
                    else
                    {
                        if ( saer == "1" )
                            stateOfOdd = "新增编辑";
                        else
                            stateOfOdd = "更改编辑";
                    }
                    StringBuilder strSql = new StringBuilder( );
                    strSql . AppendFormat ( "UPDATE R_PQAF SET AF003='{0}',AF004='{1}',AF006='{2}',AF016='{3}',AF017='{4}',AF018='{5}',AF019='{6}',AF023='{7}',AF024='{8}',AF025='{9}',AF026='{10}',AF027='{11}',AF028='{12}',AF029='{13}',AF030='{14}',AF031='{15}',AF032='{16}',AF033='{17}',AF034='{18}',AF084='{21}',AF087='{22}',AF088='{23}' WHERE AF001='{20}' AND idx='{19}'" ,cmj . AF003 ,cmj . AF004 ,cmj . AF006 ,cmj . AF016 ,cmj . AF017 ,cmj . AF018 ,cmj . AF019 ,cmj . AF023 ,cmj . AF024 ,cmj . AF025 ,cmj . AF026 ,cmj . AF027 ,cmj . AF028 ,cmj . AF029 ,cmj . AF030 ,cmj . AF031 ,cmj . AF032 ,cmj . AF033 ,cmj . AF034 ,cmj . idx ,cmj . AF001 ,cmj . AF084 ,cmj . AF087 ,cmj . AF088 );

                    SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfComparation( "R_342" ,"车木件采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,cmj.AF001 ,strSql.ToString( ).Replace( "'" ,"''" ) ,"编辑" ,stateOfOdd ) );
                }
                catch { }
                finally { button12_Click( null ,null ); }
            }
        }
        void upda_Two ( )
        {
            if ( radioButton13.Checked )
            {
                if ( !string.IsNullOrEmpty( textBox27.Text ) && !string.IsNullOrEmpty( textBox1.Text ) )
                {
                    if ( Math.Round( Convert.ToDecimal( textBox27.Text ) ,0 ) < Convert.ToDecimal( textBox1.Text ) )
                        MessageBox.Show( "出库数量大于库存数量,请更改出库数量" );
                    else
                    {
                        string str = Math.Round( Convert.ToDecimal( Operation.MultiTwoTbCbes( textBox71 ,comboBox1 ) ) ,0 ).ToString( );
                        if ( !string.IsNullOrEmpty( str ) )
                        {
                            if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox1.Text ) )
                                MessageBox.Show( "出库数量有误,请核查" );
                            else
                                upda_Thr( );
                        }
                    }
                }
            }
            else
            {
                string str = Math.Round( Convert.ToDecimal( Operation.MultiTwoTbCbes( textBox71 ,comboBox1 ) ) ,0 ).ToString( );
                if ( !string.IsNullOrEmpty( str ) && !string.IsNullOrEmpty( textBox28.Text ) )
                {
                    if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox28.Text ) )
                        MessageBox.Show( "外购数量有误,请核查" );
                    else
                    {
                        if ( Logins.number == "MLL-0001" )
                            upda_Thr( );
                        else
                        {
                            if ( !string.IsNullOrEmpty( textBox27.Text ) && Convert.ToDecimal( textBox27.Text ) > 0 )
                                MessageBox.Show( "库存数量不为零,不可以开外购合同" );
                            else
                                upda_Thr( );
                        }
                    }
                }
            }
        }
        void upda_Thr ( )
        {
            DataTable den = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQAF WHERE AF001=@AF001 AND AF015=@AF015 AND AF020=@AF020 AND AF021=@AF021 AND AF022=@AF022" ,new SqlParameter( "@AF001" ,cmj.AF001 ) ,new SqlParameter( "@AF015" ,cmj.AF015 ) ,new SqlParameter( "@AF020" ,cmj.AF020 ) ,new SqlParameter( "@AF021" ,cmj.AF021 ) ,new SqlParameter( "@AF022" ,cmj.AF022 ) );
            if ( den.Rows.Count < 1 )
            {
                //AF001=@AF001 AND AF015=@AF15 AND AF020=@AF20 AND AF021=@AF21 AND AF022=@AF22 ,AF078=@AF078  , new SqlParameter ( "@AF078" , cmj . AF078 )
                int count = SqlHelper . ExecuteNonQuery ( "UPDATE R_PQAF SET AF003=@AF003,AF004=@AF004,AF006=@AF006,AF015=@AF015,AF016=@AF016,AF017=@AF017,AF018=@AF018,AF019=@AF019,AF020=@AF020,AF021=@AF021,AF022=@AF022,AF023=@AF023,AF024=@AF024,AF025=@AF025,AF026=@AF026,AF027=@AF027,AF028=@AF028,AF029=@AF029,AF030=@AF030,AF031=@AF031,AF032=@AF032,AF033=@AF033,AF034=@AF034,AF087=@AF087,AF088=@AF088 WHERE AF001=@AF001 AND idx=@idx" /*,new SqlParameter( "@AF001" ,cmj.AF001 ) */, new SqlParameter ( "@AF002" , cmj . AF002 ) , new SqlParameter ( "@AF003" , cmj . AF003 ) , new SqlParameter ( "@AF004" , cmj . AF004 ) , new SqlParameter ( "@AF006" , cmj . AF006 ) , new SqlParameter ( "@AF015" , cmj . AF015 ) , new SqlParameter ( "@AF016" , cmj . AF016 ) , new SqlParameter ( "@AF017" , cmj . AF017 ) , new SqlParameter ( "@AF018" , cmj . AF018 ) , new SqlParameter ( "@AF019" , cmj . AF019 ) , new SqlParameter ( "@AF020" , cmj . AF020 ) , new SqlParameter ( "@AF021" , cmj . AF021 ) , new SqlParameter ( "@AF022" , cmj . AF022 ) , new SqlParameter ( "@AF023" , cmj . AF023 ) , new SqlParameter ( "@AF024" , cmj . AF024 ) , new SqlParameter ( "@AF025" , cmj . AF025 ) , new SqlParameter ( "@AF026" , cmj . AF026 ) , new SqlParameter ( "@AF027" , cmj . AF027 ) , new SqlParameter ( "@AF028" , cmj . AF028 ) , new SqlParameter ( "@AF029" , cmj . AF029 ) , new SqlParameter ( "@AF030" , cmj . AF030 ) , new SqlParameter ( "@AF031" , cmj . AF031 ) , new SqlParameter ( "@AF032" , cmj . AF032 ) , new SqlParameter ( "@AF033" , cmj . AF033 ) , new SqlParameter ( "@AF034" , cmj . AF034 ) /*,new SqlParameter( "@AF15" ,af15 ) ,new SqlParameter( "@AF20" ,af20 ) ,new SqlParameter( "@AF21" ,af21 ) ,new SqlParameter( "@AF22" ,af22 )*/  , new SqlParameter ( "@idx" , cmj . idx ) , new SqlParameter ( "@AF001" , cmj . AF001 ) ,new SqlParameter ( "@AF087" ,cmj . AF087 ) ,new SqlParameter ( "@AF088" ,cmj . AF088 ) );
                if ( count < 1 )
                    MessageBox.Show( "录入数据失败" );
                else
                {
                    MessageBox.Show( "成功录入数据" );

                    try
                    {
                        if ( label107.Visible == true )
                            stateOfOdd = "维护编辑";
                        else
                        {
                            if ( saer == "1" )
                                stateOfOdd = "新增编辑";
                            else
                                stateOfOdd = "更改编辑";
                        }
                        StringBuilder strSql = new StringBuilder( );
                        strSql . AppendFormat ( "UPDATE R_PQAF SET AF003='{0}',AF004='{1}',AF006='{2}',AF016='{3}',AF017='{4}',AF018='{5}',AF019='{6}',AF023='{7}',AF024='{8}',AF025='{9}',AF026='{10}',AF027='{11}',AF028='{12}',AF029='{13}',AF030='{14}',AF031='{15}',AF032='{16}',AF033='{17}',AF034='{18}',AF015='{19}',AF020='{20}',AF021='{21}',AF022='{22}',AF087='{24}',AF088='{25}' WHERE AF001='{24}' AND idx='{23}'" , cmj . AF003 , cmj . AF004 , cmj . AF006 , cmj . AF016 , cmj . AF017 , cmj . AF018 , cmj . AF019 , cmj . AF023 , cmj . AF024 , cmj . AF025 , cmj . AF026 , cmj . AF027 , cmj . AF028 , cmj . AF029 , cmj . AF030 , cmj . AF031 , cmj . AF032 , cmj . AF033 , cmj . AF034 , cmj . AF015 , cmj . AF020 , cmj . AF021 , cmj . AF022 , cmj . idx , cmj . AF001 ,cmj . AF087 ,cmj . AF088 );

                        SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfComparation( "R_342" ,"车木件采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,cmj.AF001 ,strSql.ToString( ).Replace( "'" ,"''" ) ,"编辑" ,stateOfOdd ) );
                    }
                    catch { }
                    finally { button12_Click( null ,null ); }
                }
            }
            else
                MessageBox.Show( "单号:" + cmj.AF001 + "中已经存在\n\r物料名称" + cmj.AF015 + "\n\r长：" + cmj.AF020 + "\n\r宽：" + cmj.AF021 + "\n\r高：" + cmj.AF022 + "\n\r的数据,请核实后再编辑" );
        }
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox15.Text ) )
            {
                MessageBox.Show( "合同批号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox31.Text ) )
            {
                MessageBox.Show( "产品名称不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox32.Text ) )
            {
                MessageBox.Show( "货号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox71.Text ) )
            {
                MessageBox.Show( "产品数量不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( partInfo . Text ) )
            {
                MessageBox . Show ( "材料名称不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( partName . Text ) )
            {
                MessageBox.Show( "物料名称不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox1.Text ) )
            {
                MessageBox.Show( "每套用量不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox12.Text ) )
            {
                MessageBox.Show( "每个单价不可为空" );
                return;
            }
            if ( !radioButton13.Checked && !radioButton14.Checked )
            {
                MessageBox.Show( "请选择库存或外购" );
                return;
            }

            if ( string.IsNullOrEmpty( comboBox15.Text ) )
            {
                MessageBox.Show( "请选择清水或混水" );
                return;
            }
            //if ( dateTimePicker4.Value < MulaolaoBll . Drity . GetDt ( ).AddDays( 5 ) )
            //    MessageBox.Show( "约定供期必须在当天的基础上延迟5天" );
            //else
            //{
            biao_One( );

            if ( cmj.AF015 == af15 && cmj.AF020 == af20 && cmj.AF021 == af21 && cmj.AF022 == af22 )
            {
                if ( radioButton13.Checked )
                {
                    if ( !string.IsNullOrEmpty( textBox27.Text ) && !string.IsNullOrEmpty( textBox1.Text ) )
                    {
                        if ( Convert.ToDecimal( textBox27.Text ) < Convert.ToDecimal( textBox1.Text ) )
                            MessageBox.Show( "出库数量大于库存数量,请更改出库数量" );
                        else
                        {
                            string str = Math.Round( Convert.ToDecimal( Operation.MultiTwoTbCbes( textBox71 ,comboBox1 ) ) ,0 ).ToString( );
                            if ( !string.IsNullOrEmpty( str ) )
                            {
                                if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox1.Text ) )
                                    MessageBox.Show( "出库数量有误,请核查" );
                                else
                                    upda_One( );
                            }
                        }
                    }
                }
                else
                {
                    string str = Math.Round( Convert.ToDecimal( Operation.MultiTwoTbCbes( textBox71 ,comboBox1 ) ) ,0 ).ToString( );
                    if ( !string.IsNullOrEmpty( str ) && !string.IsNullOrEmpty( textBox28.Text ) )
                    {
                        if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox28.Text ) )
                            MessageBox.Show( "外购数量有误,请核查" );
                        else
                        {
                            if ( Logins.number == "MLL-0001" )
                                upda_One( );
                            else
                            {
                                if ( !string.IsNullOrEmpty( textBox27.Text ) && Convert.ToDecimal( textBox27.Text ) > 0 )
                                    MessageBox.Show( "库存数量不为零,不可以开外购合同" );
                                else
                                    upda_One( );
                            }
                        }
                    }
                }
            }
            else
            {
                #region
                /*
                #region Plan
                bool result = pc.PlanActual( cmj.AF015 ,cmj.AF020 + "*" + cmj.AF021 + "*" + cmj.AF022 ,cmj.AF004 );
                if ( ord == "计划" || string.IsNullOrEmpty( textBox68.Text ) )
                {
                    if ( result == true )
                        upda_Thr( );
                    else
                    {
                        if ( cmj.AF011.Length > 8 && cmj.AF011.Substring( 0 ,8 ) == "MLL-0001" )
                            upda_Thr( );
                        else
                            MessageBox.Show( "此合同为补开,请找总经理处理" );
                    }
                }
                #endregion

                #region Actual
                else if ( ord == "实际" || !string.IsNullOrEmpty( textBox68.Text ) )
                {
                    DataTable yesNoActual = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQAF WHERE AF004=@AF004 AND AF020=@AF020 AND AF021=@AF021 AND AF022=@AF022 AND AF002=@AF002" ,new SqlParameter( "@AF002" ,cmj.AF002 ) ,new SqlParameter( "@AF004" ,cmj.AF004 ) ,new SqlParameter( "@AF020" ,cmj.AF020 ) ,new SqlParameter( "@AF021" ,cmj.AF021 ) ,new SqlParameter( "@AF022" ,cmj.AF022 ) );
                    if ( yesNoActual.Rows.Count > 0 )
                    {
                        if ( cmj.AF011.Length > 8 && cmj.AF011.Substring( 0 ,8 ) == "MLL-0001" )
                        {
                            if ( result == true )
                                outSourc( );
                            else
                                plan( );
                        }
                        else
                            MessageBox.Show( "此合同为补开,请找总经理处理" );
                    }
                    else
                    {
                        if ( result == true )
                            outSourc( );
                        else
                            plan( );
                    }
                }
                #endregion
            */
                #endregion

                #region
                if ( ord == "计划" || string.IsNullOrEmpty( textBox68.Text ) )
                {
                    DataTable plan = SqlHelper.ExecuteDataTable( "SELECT AC03+ISNULL(AC26,0)-(SELECT SUM(AD05+ISNULL(AD20,0)) AD05 FROM R_PQAD  WHERE AC18=AD01) AD05  FROM R_PQAC WHERE AC18=(SELECT MAX(AC18) FROM R_PQAC WHERE AC02=@AC02 AND AC04=@AC04 AND AC05=@AC05) GROUP BY AC03,ISNULL(AC26,0),AC18" ,new SqlParameter( "@AC02" ,cmj.AF004 ) ,new SqlParameter( "@AC04" ,cmj.AF015 ) ,new SqlParameter( "@AC05" ,cmj.AF020 + "*" + cmj.AF021 + "*" + cmj.AF022 ) );
                    if ( plan.Rows.Count > 0 && !string.IsNullOrEmpty( plan.Rows[0]["AD05"].ToString( ) ) && plan.Rows[0]["AD05"].ToString( ) != "0" )
                        //MessageBox.Show( "库存表中已经存在\n\r货号:" + cmj.AF004 + "\n\r物料名称:" + cmj.AF015 + "\n\r规格:" + cmj.AF020 + "*" + cmj.AF021 + "*" + cmj.AF022 + "\n\r的记录,且入库数量大于出库数量。不允许新建此计划订单" );
                        upda_Two( );
                    else
                        upda_Two( );
                }
                else if ( ord == "实际" || !string.IsNullOrEmpty( textBox68.Text ) )
                {
                    //AF010=@AF010 AND
                    DataTable dwo = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQAF WHERE  AF016=@AF016 AND AF015=@AF015 AND AF020=@AF020 AND AF021=@AF021 AND AF022=@AF022 AND AF004=@AF004" /*,new SqlParameter( "@AF010" ,cmj.AF010 ) */,new SqlParameter( "@AF016" ,cmj.AF016 ) ,new SqlParameter( "@AF015" ,cmj.AF015 ) ,new SqlParameter( "@AF020" ,cmj.AF020 ) ,new SqlParameter( "@AF021" ,cmj.AF021 ) ,new SqlParameter( "@AF022" ,cmj.AF022 ) ,new SqlParameter( "@AF004" ,cmj.AF004 ) );
                    if ( dwo.Rows.Count > 0 )
                    {
                        //开过的合同中是否包含此流水(针对可能合批)
                        for ( int k = 0 ; k < dwo.Rows.Count ; k++ )
                        {
                            if ( dwo.Rows[k]["AF002"].ToString( ).Contains( cmj.AF002 ) == true || cmj.AF002.Contains( dwo.Rows[k]["AF002"].ToString( ) ) == true )
                            {
                                if ( cmj.AF011.Length > 8 && cmj.AF011.Substring( 0 ,8 ) == "MLL-0001" )
                                {
                                    upda_Two( );
                                    break;
                                }
                                else
                                {
                                    MessageBox.Show( "此合同为补开,请联系总经理处理" );
                                    break;
                                }
                            }
                            else if ( k == dwo.Rows.Count - 1 )
                                upda_Two( );
                        }
                    }
                    else
                        upda_Two( );
                }
                #endregion
            }
        }
        //删除
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                return;
            biao_One ( );
            //int num = bandedGridView1.FocusedRowHandle;
            //int count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQAF WHERE AF001=@AF001 AND AF015=@AF015 AND AF020=@AF020 AND AF021=@AF021 AND AF022=@AF022" ,new SqlParameter( "@AF001" ,cmj.AF001 ) ,new SqlParameter( "@AF015" ,cmj.AF015 ) ,new SqlParameter( "@AF020" ,cmj.AF020 ) ,new SqlParameter( "@AF021" ,cmj.AF021 ) ,new SqlParameter( "@AF022" ,cmj.AF022 ) );
            int count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQAF WHERE AF001=@AF001 AND idx=@idx" ,new SqlParameter( "@idx" ,cmj.idx ) , new SqlParameter ( "@AF001" , cmj . AF001  ) );
            if ( count < 1 )
                MessageBox.Show( "删除数据失败" );
            else
            {
                MessageBox.Show( "成功删除数据" );
                try
                {
                    if ( label107.Visible == true )
                        stateOfOdd = "维护删除";
                    else
                    {
                        if ( saer == "1" )
                            stateOfOdd = "新增删除";
                        else
                            stateOfOdd = "更改删除";
                    }
                    StringBuilder strSql = new StringBuilder( );
                    strSql.AppendFormat( "DELETE FROM R_PQAF WHERE idx='{0}'" ,cmj.idx );

                    SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfComparation( "R_342" ,"车木件采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,cmj.AF001 ,strSql.ToString( ).Replace( "'" ,"''" ) ,"删除" ,stateOfOdd ) );
                }
                catch { }
                finally
                {
                    every( );
                    button12_Click( null ,null );
                }
            }
        }
        //Edit Batch
        SelectAll.NumberEditContract numQuery = new SelectAll.NumberEditContract( );
        private void button15_Click ( object sender ,EventArgs e )
        {
            numQuery.textBox1.Text = textBox71.Text;
            numQuery.StartPosition = FormStartPosition.CenterScreen;
            numQuery.PassDataBetweenForm += new SelectAll.NumberEditContract.PassDataBetweenFormHandler( numQuery_PassDataBetweenForm );
            numQuery.ShowDialog( );

            if ( numQu == "yes" )
            {
                for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
                {
                    //cmj.AF006 = string.IsNullOrEmpty( textBox71.Text ) == true ? 0 : Convert.ToInt64( textBox71.Text );
                    cmj.idx = string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["idx"].ToString( ) ) == true ? 0 : Convert.ToInt32( bandedGridView1.GetDataRow( i )["idx"].ToString( ) );
                    cmj.AF016 = bandedGridView1.GetDataRow( i )["AF016"].ToString( );
                    cmj.AF019 = string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["AF019"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( i )["AF019"].ToString( ) );
                    if ( cmj.AF016 == "外购" )
                    {
                        cmj.AF017 = Convert.ToInt64( Math.Round( cmj.AF006 * cmj.AF019 ,0 ) );
                        cmj.AF018 = 0;
                    }
                    else if ( cmj.AF016 == "库存" )
                    {
                        cmj.AF017 = 0;
                        cmj.AF018 = Convert.ToInt64( Math.Round( cmj.AF006 * cmj.AF019 ,0 ) );
                    }
                    else
                    {
                        cmj.AF017 = 0;
                        cmj.AF018 = 0;
                    }
                    if ( label107.Visible == true )
                        stateOfOdd = "维护批量编辑";
                    else
                    {
                        if ( saer == "1" )
                            stateOfOdd = "新增批量编辑";
                        else
                            stateOfOdd = "更改批量编辑";
                    }

                    result = bll.UpdateBatch( cmj,"R_342" ,"车木件采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"批量编辑" ,stateOfOdd );
                    if ( result == false )
                    {
                        MessageBox.Show( "编辑数据失败" );
                        break;
                    }
                    else if ( i == bandedGridView1.RowCount - 1 )
                    {
                        MessageBox.Show( "编辑数据成功" );
                        button12_Click( null ,null );
                    }
                }
            }
        }
        private void numQuery_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            numQu = e.ConTwo;
            cmj.AF006 = string.IsNullOrEmpty( e.ConOne ) == true ? 0 : Convert.ToInt64( e.ConOne );
        }
        //刷新
        private void button12_Click ( object sender ,EventArgs e )
        {
            tableSele = SqlHelper.ExecuteDataTable( "SELECT idx,AF002,AF003,AF004,AF006,AF015,AF016,AF017,AF018,AF019,AF020,AF021,AF022,AF023,AF024,AF025,AF026,AF027,AF028,AF029,AF029,AF030,AF031,AF032,AF033,AF034,AF080,AF081,AF084,CONVERT(FLOAT,AF087) AF087,CONVERT(FLOAT,AF088) AF088 FROM R_PQAF WHERE AF001=@AF001 ORDER BY idx DESC" ,new SqlParameter( "@AF001" ,cmj.AF001 ) );
            gridControl1.DataSource = tableSele;
            assignSum ( );

            every ( );
        }
        void assignSum ( )
        {
            if ( tableSele != null && tableSele . Rows . Count > 0 )
            {
                decimal d1 = Convert . ToDecimal ( U5 . SummaryItem . SummaryValue . ToString ( ) );
                decimal d2 = Convert . ToDecimal ( U6 . SummaryItem . SummaryValue . ToString ( ) );
                decimal d3 = d1 / d2;
                U4 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( d3 ,0 ) . ToString ( ) );
            }
        }
        //实际收货日期
        yanpinSelect ys = new yanpinSelect( );
        private void button13_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox.Show( "流水号:" + cmj.AF002 + "\n\r物料名称:" + partName . Text + "\n\r长:" + textBox32.Text + "\n\r宽:" + textBox33.Text + "\n\r高:" + textBox34.Text + "\n\r已经到货？" ,"提示" ,MessageBoxButtons.OKCancel ) == DialogResult.OK )
            {
                ys.ysOne = cmj.AF001;
                ys.ysTwo = partName . Text;
                ys.ysThr = textBox32.Text;
                ys.ysFou = textBox33.Text;
                ys.ysFiv = textBox34.Text;
                ys.ysSix = "R_412";
                ys.StartPosition = FormStartPosition.CenterScreen;
                ys.ShowDialog( );
            }
        }
        #endregion

    }
}


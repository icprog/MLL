using System;
using System . Data;
using System . Data . SqlClient;
using System . Linq;
using System . Windows . Forms;
using Mulaolao . Procedure;
using Mulaolao . Class;
using StudentMgr;
using Mulaolao . Contract;
using Mulaolao . Bom;
using FastReport;
using FastReport . Export . Xml;
using System . Collections . Generic;
using MulaolaoBll;

namespace Mulaolao.Raw_material_cost
{
    public partial class R_Frmchanpingaishan : FormChild
    {
        public R_Frmchanpingaishan ( /*Form1 fm*/ )
        {
            //this.MdiParent = fm;
            InitializeComponent ( );

            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { this . gridView1 ,this . gridView2 ,this . gridView3   } );
            UserInfoMation . tableName = this . Name;
        }
        
        R_FrmContractreviewb conb = new R_FrmContractreviewb( );
        Order ys = new Order( );
        DataTable ddl,ddk,ddp;
        
        List<SplitContainer> spList=new List<SplitContainer>();
        Report report = new Report( );
        DataSet RDataSet;
        
        MulaolaoBll.Bll.ChanPinGaiShanBll bll = new MulaolaoBll.Bll.ChanPinGaiShanBll( );
        MulaolaoLibrary.ChanPinGaiShanEntity _model=new MulaolaoLibrary.ChanPinGaiShanEntity();
        bool result=false;

        private void R_Frmchanpingaishan_Load ( object sender ,EventArgs e )
        {
            Power( this );

            Ergodic.FormEvery( this );
            gridControl1.DataSource = null;
            gridControl2.DataSource = null;
            gridControl3.DataSource = null;

            spList . Add ( splitContainer1 );
            spList . Add ( splitContainer2 );
            spList . Add ( splitContainer3 );
            spList . Add ( splitContainer4 );
            Ergodic . SpliEnableFalse ( spList );
            textBox16.Enabled = false;
            //列宽
            this.gridView1.IndicatorWidth = 40;

            label7.Visible = false;

            datatimepickeroverride6.Enabled = datatimepickeroverride1.Enabled = false;

            DataTable tpd = SqlHelper.ExecuteDataTable( "SELECT DBA002 FROM TPADBA ORDER BY DBA002" );
            lookUpEdit1.Properties.DataSource = tpd;
            lookUpEdit1.Properties.DisplayMember = "DBA002";

            lookUpEdit2.Properties.DataSource = tpd.Copy( );
            lookUpEdit2.Properties.DisplayMember = "DBA002";

            lookUpEdit3.Properties.DataSource = tpd.Copy( );
            lookUpEdit3.Properties.DisplayMember = "DBA002";

            lookUpEdit4.Properties.DataSource = tpd.Copy( );
            lookUpEdit4.Properties.DisplayMember = "DBA002";

            lookUpEdit5.Properties.DataSource = tpd.Copy( );
            lookUpEdit5.Properties.DisplayMember = "DBA002";

            lookUpEdit6.Properties.DataSource = tpd.Copy( );
            lookUpEdit6.Properties.DisplayMember = "DBA002";

            lookUpEdit7.Properties.DataSource = tpd.Copy( );
            lookUpEdit7.Properties.DisplayMember = "DBA002";

            lookUpEdit8.Properties.DataSource = tpd.Copy( );
            lookUpEdit8.Properties.DisplayMember = "DBA002";

            lookUpEdit9.Properties.DataSource = tpd.Copy( );
            lookUpEdit9.Properties.DisplayMember = "DBA002";

            comboBox32 . Items . AddRange ( new string [ ] { "双瓦外箱" ,"小箱式" ,"牙膏式" ,"插口式" ,"折叠式" ,"天盖" ,"底盖" ,"单瓦楞纸卡" ,"双瓦楞纸卡","常规计算" } );
        }

        #region 打印  导出
        private void Create ( )
        {
            RDataSet = new DataSet( );
            DataTable print = bll . printTableOne ( _model.GS34 );
            DataTable prints = bll . printTableTwo ( _model . GS34 );
            DataTable printse = bll . printTableTre ( _model . GS34 );
            DataTable printese = bll . printTableFor ( _model . GS34 );
            print.TableName = "R_PQP";
            prints.TableName = "R_PQPS";
            printse.TableName = "R_PQPSE";
            printese.TableName = "R_PQPSES";
            RDataSet.Tables.Add( print );
            RDataSet.Tables.Add( prints );
            RDataSet.Tables.Add( printse );
            RDataSet.Tables.Add( printese );
        }
        #endregion

        #region 查询
        //string GS01 = "", GS020 = "";
        Youqicaigou yq = new Youqicaigou( );
        //流水查询
        private void button4_Click ( object sender ,EventArgs e )
        {
            //DataTable dhr = SqlHelper.ExecuteDataTable( "SELECT DISTINCT PQF01,PQF02,PQF03,PQF04,PQF06,PQF17,HT52,PQF07,PQF08 FROM R_PQF A, TPADAA B, R_REVIEWS C, R_PQL D, R_MLLCXMC E WHERE A.PQF17 = B.DAA001 AND A.PQF01 = D.HT01 AND A.PQF01 = C.RES06 AND C.RES01 = E.CX01 AND C.RES05 = '执行' AND CX02 IN( '合同评审表(R_021)', '订单销售合同(R_001)' ) ORDER BY PQF01 DESC" );
            //if ( dhr.Rows.Count < 1 )
            //{
            //    MessageBox.Show( "没有产品信息" );
            //}
            //else
            //{
            //    dhr.Columns.Add( "check" ,System.Type.GetType( "System.Boolean" ) );
            //    yq.gridControl1.DataSource = dhr;
            //    yq.sy = "3";
            //    yq.Text = "R_509 信息查询";
            //    yq.PassDataBetweenForm += new Youqicaigou.PassDataBetweenFormHandler( yq_PassDataBetweenForm );
            //    yq.StartPosition = FormStartPosition.CenterScreen;
            //    yq.ShowDialog( );
            //}
            SelectAll.ChangPingGaiShanNumAll queryAll = new SelectAll.ChangPingGaiShanNumAll( );
            queryAll.StartPosition = FormStartPosition.CenterScreen;
            queryAll.PassDataBetweenForm += new SelectAll.ChangPingGaiShanNumAll.PassDataBetweenFormHandler( yq_PassDataBetweenForm );
            queryAll.ShowDialog( );
        }
        private void yq_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            _model.GS01 = e.ConOne;
            //流水
            textBox3.Text = e.ConOne;
            //合同
            if ( e.ConTwo.IndexOf( "," ) > 0 )
                textBox2.Text = string.Join( "," ,e.ConTwo.Split( ',' ).Distinct( ).ToArray( ) );
            else
                textBox2.Text = e.ConTwo;
            _model . GS47 = textBox2.Text;
            //货号
            if ( e.ConTre.IndexOf( "," ) > 0 )
                textBox5.Text = string.Join( "," ,e.ConTre.Split( ',' ).Distinct( ).ToArray( ) );
            else
                textBox5.Text = e.ConTre;
            _model . GS48 = textBox5.Text;
            //产品名称
            if ( e.ConFor.IndexOf( "," ) > 0 )
                textBox1.Text = string.Join( "," ,e.ConFor.Split( ',' ).Distinct( ).ToArray( ) );
            else
                textBox1.Text = e.ConFor;
            _model . GS46 = textBox1.Text;
            //数量
            textBox4.Text = e.ConFiv;
            if ( e.ConFiv == "" )
                _model . GS49 = 0;
            else
                _model . GS49 = Convert.ToInt64( e.ConFiv );
            //部门
            //if ( e.ConEgi.IndexOf( "," ) > 0 )
            //    textBox12.Text = string.Join( "," ,e.ConEgi.Split( ',' ).Distinct( ).ToArray( ) );
            //else
            textBox12.Text = e.ConEgi;
            _model . GS50 = textBox12.Text;
        }
        R_FrmTPADGA tpadga = new R_FrmTPADGA( );
        //供应商查询
        string sup = "";
        void supplier ( )
        {
            DataTable did = SqlHelper.ExecuteDataTable( "SELECT DGA001,DGA003,DGA008,DGA011,DGA017,DGA009,DGA012 FROM TPADGA" );
            if ( did.Rows.Count < 1 )
                MessageBox.Show( "没有供应商信息" );
            else
            {
                tpadga.gridControl2.DataSource = did;
                tpadga.st = "2";
                tpadga.Text = "R_509 信息查询";
                tpadga.PassDataBetweenForm += new R_FrmTPADGA.PassDataBetweenFomrHandler( tpadga_PassDataBetweenForm );
                tpadga.StartPosition = FormStartPosition.CenterScreen;
                tpadga.ShowDialog( );
            }
        }
        private void button5_Click ( object sender ,EventArgs e )
        {
            supplier( );
            sup = "1";
        }
        private void button18_Click ( object sender ,EventArgs e )
        {
            supplier( );
            sup = "2";
        }
        private void tpadga_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            if ( sup == "1" )
            {
                _model . GS20 = e.ConOne;
                textBox11.Text = e.ConTwo;
                textBox15.Text = e.ConFiv;
            }
            else if ( sup == "2" )
            {
                _model . GS68 = e.ConOne;
                textBox18.Text = e.ConTwo;
                textBox17.Text = e.ConFiv;
            }         
        }
        R_FrmPQP pq = new R_FrmPQP( );
        //查询
        void query ( )
        {
            DataTable das = SqlHelper.ExecuteDataTable( "SELECT TOP 1 * FROM R_PQP WHERE GS34=@GS34" ,new SqlParameter( "@GS34" ,_model . GS34 ) );
            if ( das.Rows.Count > 0 )
            {
                if ( das.Rows[0]["GS03"].ToString( ) == "新单" )
                    radioButton2.Checked = true;
                else
                    radioButton1.Checked = true;

                textBox6.Text = das.Rows[0]["GS22"].ToString( );
                if ( !string.IsNullOrEmpty( das.Rows[0]["GS23"].ToString( ) ) )
                    datatimepickeroverride2.Value = Convert.ToDateTime( das.Rows[0]["GS23"] );
                else
                    datatimepickeroverride2.Value = MulaolaoBll . Drity . GetDt ( );
                textBox7.Text = das.Rows[0]["GS24"].ToString( );
                if ( !string.IsNullOrEmpty( das.Rows[0]["GS25"].ToString( ) ) )
                    datatimepickeroverride3.Value = Convert.ToDateTime( das.Rows[0]["GS25"] );
                else
                    datatimepickeroverride3.Value = MulaolaoBll . Drity . GetDt ( );
                textBox8.Text = das.Rows[0]["GS26"].ToString( );
                if ( !string.IsNullOrEmpty( das.Rows[0]["GS27"].ToString( ) ) )
                    datatimepickeroverride4.Value = Convert.ToDateTime( das.Rows[0]["GS27"] );
                else
                    datatimepickeroverride4.Value = MulaolaoBll . Drity . GetDt ( );
                textBox9.Text = das.Rows[0]["GS28"].ToString( );
                if ( !string.IsNullOrEmpty( das.Rows[0]["GS29"].ToString( ) ) )
                    datatimepickeroverride5.Value = Convert.ToDateTime( das.Rows[0]["GS29"] );
                else
                    datatimepickeroverride5.Value = MulaolaoBll . Drity . GetDt ( );
                textBox10.Text = das.Rows[0]["GS30"].ToString( );
                comboBox16.Text = das.Rows[0]["GS31"].ToString( );
                textBox16.Text = das.Rows[0]["GS32"].ToString( );

                ddl = SqlHelper.ExecuteDataTable( "SELECT idx,GS02,GS49,GS51,GS04,GS05,GS07,GS08,GS09,GS10,GS11,GS13,GS14,GS15,GS16,GS17,GS18,GS19,GS20,(SELECT DGA003 FROM TPADGA WHERE GS20 = DGA001 ) DGA003 ,(SELECT DGA011 FROM TPADGA WHERE GS20 = DGA001 ) DGA011,D.U7,GS70,GS71 FROM R_PQP A, (SELECT GS02 U0 ,SUM( GS10 * GS11 ) U7 FROM R_PQP GROUP BY GS02 ) D WHERE A.GS02 = D.U0 AND GS34 = @GS34 AND GS02!='' AND GS02 IS NOT NULL ORDER BY GS70,GS71,GS02,GS07 " ,new SqlParameter( "@GS34" ,_model . GS34 ) );//ASC,REVERSE(GS07) ASC
                gridControl1 .DataSource = ddl;

                ddk = SqlHelper.ExecuteDataTable( "SELECT idx,GS35,GS36,GS37,GS38,GS39,GS40,GS41,GS42,GS43,GS44,GS45,GS72 FROM R_PQP WHERE GS35 IS NOT NULL AND GS35!='' AND GS34=@GS34 ORDER BY REVERSE(GS35) ASC" ,new SqlParameter( "@GS34" ,_model . GS34 ) );
                gridControl2.DataSource = ddk;

                ddp = SqlHelper.ExecuteDataTable( "SELECT idx,GS52,GS49,GS61,GS53,GS54,GS56,GS57,GS58,GS59,GS60,GS69,GS62,GS63,GS64,GS65,GS66,GS67,GS68,(SELECT DGA003 FROM TPADGA WHERE GS68 = DGA001 ) DGA003 ,(SELECT DGA011 FROM TPADGA WHERE GS68 = DGA001 ) DGA011,D.U11 FROM R_PQP A, (SELECT GS52 U0 ,SUM( GS59 * GS60 ) U11 FROM R_PQP GROUP BY GS52 ) D WHERE A.GS52 = D.U0 AND GS34 = @GS34 AND GS52!='' AND GS52 IS NOT NULL ORDER BY GS52 ASC,REVERSE(GS56) ASC" ,new SqlParameter( "@GS34" ,_model . GS34 ) );
                gridControl3.DataSource = ddp;

            }
        }
        protected override void select ( )
        {
            base . select ( );

            //DataTable pqp = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS34,GS01,GS46,GS47,GS48,GS49,GS50,GS03,(SELECT RES05 FROM R_REVIEWS WHERE RES04 = ( SELECT MAX( RES04 ) FROM R_REVIEWS WHERE RES06 = GS34 ) ) RES05 FROM R_PQP ORDER BY GS34 DESC" );
            //if ( pqp.Rows.Count < 1 )
            //    MessageBox.Show( "没有任何信息" );
            //else
            //{
            //    pq.gridControl1.DataSource = pqp;
            //    pq.pqstr = "1";
            //    pq.Text = "R_509 信息查询";
            //    pq.StartPosition = FormStartPosition.CenterScreen;
            //    pq.PassDataBetweenForm += new R_FrmPQP.PassDataBetweenFormHandler( pq_PassDataBetweenForm );
            //    pq.ShowDialog( );

            SelectAll . FrmchanpingaishanQuery from = new SelectAll . FrmchanpingaishanQuery ( );
            if ( from . ShowDialog ( ) == DialogResult . OK )
            {
                DataRow row = from . getRow;
                if ( row == null )
                    return;

                _model . GS01 = row [ "GS01" ] . ToString ( );
                _model . GS46 = row [ "GS46" ] . ToString ( );
                if ( row [ "GS03" ] . ToString ( ) . Equals ( "新单" ) )
                    radioButton2 . Checked = true;
                else
                    radioButton1 . Checked = true;
                _model . GS34 = row [ "GS34" ] . ToString ( );
                _model . GS47 = row [ "GS47" ] . ToString ( );
                _model . GS48 = row [ "GS48" ] . ToString ( );
                _model . GS49 = string . IsNullOrEmpty ( row [ "GS49" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "GS49" ] . ToString ( ) );
                _model . GS50 = row [ "GS50" ] . ToString ( );
                if ( "执行" . Equals ( row [ "RES05" ] . ToString ( ) ) )
                    label7 . Visible = true;
                else
                    label7 . Visible = false;

                textBox3 . Text = _model . GS01;
                textBox1 . Text = _model . GS46;
                textBox2 . Text = _model . GS47;
                textBox5 . Text = _model . GS48;
                textBox4 . Text = _model . GS49 . ToString ( );
                textBox12 . Text = _model . GS50;

                toolAdd . Enabled = toolSelect . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = true;
                toolSave . Enabled = toolCancel . Enabled = false;

                textBox16 . Enabled = false;
                datatimepickeroverride6 . Enabled = datatimepickeroverride1 . Enabled = false;

                sads = "2";
                query ( );
            }
        }
        private void pq_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            _model . GS01 = e.ConOne;
            textBox3.Text = e.ConOne;
            textBox1.Text = e.ConTwo;
            _model . GS46 = e.ConTwo;
            if ( e.ConFiv == "新单" )
            {
                radioButton2.Checked = true;
            }
            else if ( e.ConFiv == "老单" )
            {
                radioButton1.Checked = true;
            }
            _model . GS34 = e.ConFor;
            _model . GS47 = e.ConFiv;
            textBox2.Text = e.ConFiv;
            _model . GS48 = e.ConSix;
            textBox5.Text = e.ConSix;
            if ( e.ConSev == "" )
                _model . GS49 = 0;
            else
                _model . GS49 = Convert.ToInt64( e.ConSev );
            textBox4.Text = e.ConSev;
            _model . GS50 = e.ConEgi;
            textBox12.Text = e.ConEgi;
            if ( e.ConNin == "执行" )
                label7.Visible = true;
            else
                label7.Visible = false;
        }
        #endregion

        #region 事件
        void workshopSection ( )
        {
            DataTable dlo = SqlHelper.ExecuteDataTable( "SELECT GS35,GS36,GS37,GS38,GS39,GS72 FROM R_PQP WHERE GS48=@GS48" ,new SqlParameter( "@GS48" ,_model . GS48 ) );
            //工段
            //DataTable workshop = dlo.DefaultView.ToTable( true ,"GS35" );
            comboBox12.DataSource = dlo.DefaultView.ToTable( true ,"GS35" );
            comboBox12.DisplayMember = "GS35";
            //原单价
            //DataTable unitCost = dlo.DefaultView.ToTable( true ,"GS36" );
            comboBox24 .DataSource = dlo.DefaultView.ToTable( true ,"GS36" );
            comboBox24.DisplayMember = "GS36";
            //计划下降差价
            //DataTable priceDcline = dlo.DefaultView.ToTable( true ,"GS37" );
            comboBox23.DataSource = dlo.DefaultView.ToTable( true ,"GS37" );
            comboBox23.DisplayMember = "GS37";
            //单位
            //DataTable company = dlo.DefaultView.ToTable( true ,"GS38" );
            comboBox20.DataSource = dlo.DefaultView.ToTable( true ,"GS38" );
            comboBox20.DisplayMember = "GS38";
            //提成
            //DataTable commission = dlo.DefaultView.ToTable( true ,"GS39" );
            comboBox17.DataSource = dlo.DefaultView.ToTable( true ,"GS39" );
            comboBox17.DisplayMember = "GS39";
            //046工序
            //DataTable commission = dlo.DefaultView.ToTable( true ,"GS39" );
            comboBox13 . DataSource = dlo . DefaultView . ToTable ( true ,"GS72" );
            comboBox13 . DisplayMember = "GS72";
        }
        void materialScience ( )
        {
            DataTable ass = bll . GetDataTable ( _model . GS48 );

            DataTable bg = SqlHelper . ExecuteDataTable ( "SELECT GS02,GS04,GS05,GS06,GS07,GS08,GS09,GS10,GS11,GS13,GS14,GS15,GS16,GS17,GS18,GS19,GS51 FROM R_PQP WHERE GS48=@GS48" ,new SqlParameter ( "@GS48" ,_model . GS48 ) );
            if ( ass != null )
                bg . Merge ( ass );
            //材料
            //DataTable cz = bg.DefaultView.ToTable( true ,"GS02" );
            //DataTable cz = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS02 FROM R_PQP" );
            comboBox3.DataSource = bg . DefaultView . ToTable ( true ,"GS02" );
            comboBox3 . DisplayMember = "GS02";
            //comboBox3 . Properties . DisplayMember = "GS02";
            //comboBox3 . Properties . ValueMember = "GS02";
            //原单价
            //DataTable dj = bg.DefaultView.ToTable( true ,"GS04" );
            //DataTable dj = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS04 FROM R_PQP" );
            comboBox1 . DataSource = bg . DefaultView . ToTable ( true ,"GS04" );
            comboBox1 . DisplayMember = "GS04";
            //计划下降差价
            //DataTable jxc = bg.DefaultView.ToTable( true ,"GS05" );
            //DataTable jxc = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS05 FROM R_PQP" );
            comboBox4 . DataSource = bg . DefaultView . ToTable ( true ,"GS05" );
            comboBox4 . DisplayMember = "GS05";
            //提成
            //DataTable tc = bg.DefaultView.ToTable( true ,"GS13" );
            //DataTable tc = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS13 FROM R_PQP" );
            comboBox10 . DataSource = bg . DefaultView . ToTable ( true ,"GS13" );
            comboBox10 . DisplayMember = "GS13";
            //零件名称
            //DataTable ljmc = bg.DefaultView.ToTable( true ,"GS07" );
            //DataTable ljmc = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS07 FROM R_PQP" );
            comboBox6 . DataSource = bg . DefaultView . ToTable ( true ,"GS07" );
            comboBox6 . DisplayMember = "GS07";
            //规格
            //DataTable gg = bg.DefaultView.ToTable( true ,"GS08" );
            //DataTable gg = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS08 FROM R_PQP" );
            comboBox7 . DataSource = bg . DefaultView . ToTable ( true ,"GS08" );
            comboBox7 . DisplayMember = "GS08";
            //单位
            //DataTable dw = bg.DefaultView.ToTable( true ,"GS09" );
            comboBox8 . DataSource = bg . DefaultView . ToTable ( true ,"GS09" );
            comboBox8 . DisplayMember = "GS09";
            //每套零件数量
            //DataTable mls = bg.DefaultView.ToTable( true ,"GS10" );
            comboBox2 . DataSource = bg . DefaultView . ToTable ( true ,"GS10" );
            comboBox2 . DisplayMember = "GS10";
            //采购零件单价
            //DataTable cld = bg.DefaultView.ToTable( true ,"GS11" );
            comboBox9 . DataSource = bg . DefaultView . ToTable ( true ,"GS11" );
            comboBox9 . DisplayMember = "GS11";
            //材料总单价
            //DataTable unitPrict = bg.DefaultView.ToTable( true ,"GS51" );
            comboBox18 . DataSource = bg . DefaultView . ToTable ( true ,"GS51" );
            comboBox18 . DisplayMember = "GS51";
        }
        void accessories ( )
        {
            DataTable add = bll.GetDataTableOn( );
            DataTable access = SqlHelper.ExecuteDataTable( "SELECT GS52,GS61,GS53,GS54,GS56,GS57,GS58,GS59,GS60,GS69 FROM R_PQP " );
            if ( add != null )
                access.Merge( add );
            //辅料 
            //DataTable acc = access.DefaultView.ToTable( true ,"GS52" );
            comboBox14.DataSource = access.DefaultView.ToTable( true ,"GS52" );
            comboBox14.DisplayMember = "GS52";
            //零件名称 
            //DataTable partName = access.DefaultView.ToTable( true ,"GS56" );
            //comboBox32.DataSource = access.DefaultView.ToTable( true ,"GS56" );
            //comboBox32.DisplayMember = "GS56";
            //原单价 
            //DataTable unitPrice = access.DefaultView.ToTable( true ,"GS53" );
            comboBox34 .DataSource = access.DefaultView.ToTable( true ,"GS53" );
            comboBox34.DisplayMember = "GS53";
            //规格 
            //DataTable specification = access.DefaultView.ToTable( true ,"GS57" );
            comboBox15.DataSource = access.DefaultView.ToTable( true ,"GS57" );
            comboBox15.DisplayMember = "GS57";
            //每套零件数量 
            //DataTable partPerSet = access.DefaultView.ToTable( true ,"GS59" );
            comboBox29 .DataSource = access.DefaultView.ToTable( true ,"GS59" );
            comboBox29.DisplayMember = "GS59";
            //计划下降差价 
            //DataTable planToDrop = access.DefaultView.ToTable( true ,"GS54" );
            comboBox33.DataSource = access.DefaultView.ToTable( true ,"GS54" );
            comboBox33.DisplayMember = "GS54";
            //单位 
            //DataTable unit = access.DefaultView.ToTable( true ,"GS58" );
            comboBox30.DataSource = access.DefaultView.ToTable( true ,"GS58" );
            comboBox30.DisplayMember = "GS58";
            //采购零件单价 
            //DataTable partUnitPrice = access.DefaultView.ToTable( true ,"GS60" );
            comboBox28.DataSource = access.DefaultView.ToTable( true ,"GS60" );
            comboBox28.DisplayMember = "GS60";
            //材料总单价 
            //DataTable totalUnitPrice = access.DefaultView.ToTable( true ,"GS61" );
            comboBox19.DataSource = access.DefaultView.ToTable( true ,"GS61" );
            comboBox19.DisplayMember = "GS61";
            //提成 
            //DataTable commission = access.DefaultView.ToTable( true ,"GS69" );
            comboBox27.DataSource = access.DefaultView.ToTable( true ,"GS69" );
            comboBox27.DisplayMember = "GS69";
        }
        private void textBox5_TextChanged ( object sender ,EventArgs e )
        {
            _model . GS48 = textBox5 . Text;
            workshopSection ( );
            materialScience ( );
            accessories ( );

            if ( string . IsNullOrEmpty ( textBox5 . Text ) )
                button13 . Enabled = BatchAdd . Enabled = false;
            else
                button13 . Enabled = BatchAdd . Enabled = true;
        }
        //降价次数
        private void comboBox16_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //原单价
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
            if ( comboBox1.Text != "" && !DateDayRegise.elevenForNumber( comboBox1 ) )
            {
                this.comboBox1.Text = "";
                MessageBox.Show( "只允许输入整数部分最多七位,小数部分最多四位,如9999999.9999,请重新输入" );
            }
        }
        private void comboBox24_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox24 );
        }
        private void comboBox24_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox24 );
        }
        private void comboBox24_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox24.Text != "" && !DateDayRegise.sevenFour( comboBox24 ) )
            {
                this.comboBox24.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多四位,如999.9999,请重新输入" );
            }
        }
        //计划下降差价
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
            if ( comboBox4.Text != "" && !DateDayRegise.fiveFoureNum( comboBox4 ) )
            {
                this.comboBox4.Text = "";
                MessageBox.Show( "只允许输入整数部分最一两位,小数部分最多四位,如9.9999,请重新输入" );
            }
        }
        private void comboBox23_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox23 );
        }
        private void comboBox23_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox23 );
        }
        private void comboBox23_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox23.Text != "" && !DateDayRegise.fiveFoureNum( comboBox23 ) )
            {
                this.comboBox23.Text = "";
                MessageBox.Show( "只允许输入整数部分最一两位,小数部分最多四位,如9.9999,请重新输入" );
            }
        }
        //提成
        private void comboBox10_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void comboBox17_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //每套零件数量
        private void comboBox2_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox2 );
        }
        private void comboBox2_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox2 );
        }
        private void comboBox2_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox2.Text != "" && !DateDayRegise.sevenFour( comboBox2 ) )
            {
                this.comboBox2.Text = "";
                MessageBox.Show( "只允许输入整数部分最三位,小数部分最多四位,如999.9999,请重新输入" );
            }
        }
        //采购零件单价
        private void comboBox9_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox9 );
        }
        private void comboBox9_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox9 );
        }
        private void comboBox9_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox9.Text != "" && !DateDayRegise.elevenForNumber( comboBox9 ) )
            {
                this.comboBox9.Text = "";
                MessageBox.Show( "只允许输入整数部分最七位,小数部分最多四位,如9999999.9999,请重新输入" );
            }
        }
        //材料总单价
        private void comboBox18_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox18 );
        }
        private void comboBox18_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox18 );
        }
        private void comboBox18_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox18.Text != "" && !DateDayRegise.elevenForNumber( comboBox18 ) )
            {
                this.comboBox18.Text = "";
                MessageBox.Show( "只允许输入整数部分最七位,小数部分最多四位,如9999999.9999,请重新输入" );
            }
        }
        //获取获得焦点的行的值
        string DGA03 = "", DGA01 = "", GS002 = "", GS007 = "", GS200 = "",GS008="";
        private void gridView1_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            DataRow row = gridView1 . GetFocusedDataRow ( );
            if ( row != null )
            {
                comboBox3 . Text = row [ "GS02" ] . ToString ( );
                comboBox1 . Text = row [ "GS04" ] . ToString ( );
                comboBox4 . Text = row [ "GS05" ] . ToString ( );
                comboBox6 . Text = row [ "GS07" ] . ToString ( );
                comboBox7 . Text = row [ "GS08" ] . ToString ( );
                comboBox8 . Text = row [ "GS09" ] . ToString ( );
                comboBox2 . Text = row [ "GS10" ] . ToString ( );
                comboBox9 . Text = row [ "GS11" ] . ToString ( );
                comboBox10 . Text = row [ "GS13" ] . ToString ( );
                textBox13 . Text = row [ "GS14" ] . ToString ( );
                textBox14 . Text = row [ "GS15" ] . ToString ( );
                lookUpEdit1 . Text = row [ "GS16" ] . ToString ( );
                lookUpEdit2 . Text = row [ "GS17" ] . ToString ( );
                lookUpEdit3 . Text = row [ "GS18" ] . ToString ( );
                comboBox18 . Text = row [ "GS51" ] . ToString ( );
                textBox11 . Text = row [ "DGA003" ] . ToString ( );
                textBox15 . Text = row [ "DGA011" ] . ToString ( );
                comboBox5 . Text = row [ "GS70" ] . ToString ( );
                comboBox11 . Text = row [ "GS71" ] . ToString ( );
                if ( row [ "GS19" ] . ToString ( ) != "" )
                    datatimepickeroverride6 . Value = Convert . ToDateTime ( row [ "GS19" ] . ToString ( ) );
                else
                    datatimepickeroverride6 . Value = DateTime . Now;
                _model . GS20 = row [ "GS20" ] . ToString ( );
                DGA03 = textBox11 . Text;
                DGA01 = textBox15 . Text;
                GS002 = comboBox3 . Text;
                GS007 = comboBox6 . Text;
                GS200 = _model . GS20;
                GS008 = comboBox7 . Text;
                _model .idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
            }
        }
        //显示行号
        private void gridView1_CustomDrawRowIndicator ( object sender ,DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e )
        {
            if ( e.Info.IsRowIndicator && e.RowHandle >= 0 )
            {
                e.Info.DisplayText = ( e.RowHandle + 1 ).ToString( );
            }
        }
        //单元格合并
        private void gridView1_CellMerge ( object sender ,DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e )
        {
            //材质/工段  列名
            if ( e.Column.FieldName == "材质/工段" )
            {
                //GS02   字段名
                string str1 = gridView1.GetDataRow( e.RowHandle1 )["GS02"].ToString( );
                string str2 = gridView1.GetDataRow( e.RowHandle2 )["GS02"].ToString( );
                if ( str1 == str2 )
                {
                    e.Merge = true;
                    e.Handled = true;
                }
                else
                {
                    e.Merge = false;
                    e.Handled = true;
                }
            }
        }
        //计算字段
        private void gridView1_CustomColumnDisplayText ( object sender ,DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e )
        {
            //GS01 = textBox3.Text;
            //DataTable da = SqlHelper.ExecuteDataTable( "SELECT GS02,SUM(GS10*GS11) U7 FROM R_PQP WHERE GS01=@GS01 GROUP BY GS02", new SqlParameter( "@GS01", GS01 ) );
            //if (da != null && da.Rows.Count > 0)
            //{
            //    for (int i = 0; i < da.Rows.Count; i++)
            //    {
            //        for (int j = 0; j < gridView1.RowCount; j++)
            //        {
            //            if (da.Rows[i]["GS02"].ToString( ) == gridView1.GetDataRow( j )["GS02"].ToString( ))
            //            {
            //                //string X1 = da.Rows[i]["GS02"].ToString( );
            //                //string X2 = gridView1.GetDataRow( j )["GS02"].ToString( );
            //                //string X3 = da.Rows[i]["U7"].ToString( );
            //                U7.UnboundExpression = da.Rows[i]["U7"].ToString( );
            //                U7.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            //            }
            //        }
            //    }
            //}
        }
        //计划定价人
        private void button6_Click ( object sender ,EventArgs e )
        {
            if ( textBox6.Text == "" )
            {
                textBox6.Text = Logins.username;
            }
            else if ( textBox6.Text != "" )
            {
                textBox6.Text = "";
            }
        }
        //填表人
        private void button7_Click ( object sender ,EventArgs e )
        {
            if ( textBox7.Text == "" )
            {
                textBox7.Text = Logins.username;
            }
            else if ( textBox7.Text != "" )
            {
                textBox7.Text = "";
            }
        }
        //审核人
        private void button8_Click ( object sender ,EventArgs e )
        {
            if ( textBox8.Text == "" )
            {
                textBox8.Text = Logins.username;
            }
            else if ( textBox8.Text != "" )
            {
                textBox8.Text = "";
            }
        }
        //批准人
        private void button9_Click ( object sender ,EventArgs e )
        {
            if ( textBox9.Text == "" )
            {
                textBox9.Text = Logins.username;
            }
            else if ( textBox9.Text != "" )
            {
                textBox9.Text = "";
            }
        }
        //监督人
        private void button10_Click ( object sender ,EventArgs e )
        {
            if ( textBox10.Text == "" )
            {
                textBox10.Text = Logins.username;
            }
            else if ( textBox10.Text != "" )
            {
                textBox10.Text = "";
            }
        }
        //窗体关闭事件
        private void R_Frmchanpingaishan_FormClosing ( object sender ,FormClosingEventArgs e )
        {
            if ( toolSave.Enabled )
            {
                MessageBox.Show( "请保存或取消" );
                e.Cancel = true;
            }
        }
        //工段
        string gs035 = "";
        private void gridView2_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            DataRow row = gridView2 . GetFocusedDataRow ( );
            if ( row != null )
            {
                comboBox12 . Text = row [ "GS35" ] . ToString ( );
                comboBox24 . Text = row [ "GS36" ] . ToString ( );
                comboBox23 . Text = row [ "GS37" ] . ToString ( );
                comboBox20 . Text = row [ "GS38" ] . ToString ( );
                comboBox17 . Text = row [ "GS39" ] . ToString ( );
                textBox20 . Text = row [ "GS40" ] . ToString ( );
                textBox19 . Text = row [ "GS41" ] . ToString ( );
                lookUpEdit4 . Text = row [ "GS42" ] . ToString ( );
                lookUpEdit5 . Text = row [ "GS43" ] . ToString ( );
                lookUpEdit6 . Text = row [ "GS44" ] . ToString ( );
                comboBox13 . Text = row [ "GS72" ] . ToString ( );
                if ( row [ "GS45" ] . ToString ( ) != "" )
                    datatimepickeroverride1 . Value = Convert . ToDateTime ( row [ "GS45" ] . ToString ( ) );
                else
                    datatimepickeroverride1 . Value = DateTime . Now;
                gs035 = comboBox12 . Text;
                _model . idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
            }
        }
        //辅料
        string gs052 = "", gs056 = "", gs068 = "",gs057="";
        //int idxOne=0,idxTwo=0,idxTre=0;
        private void gridView3_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            DataRow row = gridView3 . GetFocusedDataRow ( );
            if ( row != null )
            {
                comboBox14 . Text = row [ "GS52" ] . ToString ( );
                comboBox34 . Text = row [ "GS53" ] . ToString ( );
                comboBox33 . Text = row [ "GS54" ] . ToString ( );
                comboBox32 . Text = row [ "GS56" ] . ToString ( );
                comboBox15 . Text = row [ "GS57" ] . ToString ( );
                comboBox30 . Text = row [ "GS58" ] . ToString ( );
                comboBox29 . Text = row [ "GS59" ] . ToString ( );
                comboBox28 . Text = row [ "GS60" ] . ToString ( );
                comboBox19 . Text = row [ "GS61" ] . ToString ( );
                comboBox27 . Text = row [ "GS69" ] . ToString ( );
                textBox22 . Text = row [ "GS62" ] . ToString ( );
                textBox21 . Text = row [ "GS63" ] . ToString ( );
                lookUpEdit7 . Text = row [ "GS64" ] . ToString ( );
                lookUpEdit8 . Text = row [ "GS65" ] . ToString ( );
                lookUpEdit9 . Text = row [ "GS66" ] . ToString ( );
                if ( !string . IsNullOrEmpty ( row [ "GS67" ] . ToString ( ) ) )
                    datatimepickeroverride7 . Value = Convert . ToDateTime ( row [ "GS67" ] . ToString ( ) );
                else
                    datatimepickeroverride7 . Value = DateTime . Now;
                textBox18 . Text = row [ "DGA003" ] . ToString ( );
                textBox17 . Text = row [ "DGA011" ] . ToString ( );
               _model. GS68 = gridView3 . GetFocusedRowCellValue ( "GS68" ) . ToString ( );
                gs052 = comboBox14 . Text;
                gs056 = comboBox32 . Text;
                gs068 = _model . GS68;
                gs057 = comboBox15 . Text;
                _model . idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
            }
        }
        //原单价
        private void comboBox34_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox34 );
        }
        private void comboBox34_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox34 );
        }
        private void comboBox34_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox34.Text != "" && !DateDayRegise.sevenFour( comboBox34 ) )
            {
                this.comboBox34.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多四位,如999.9999,请重新输入" );
            }
        }
        //计划下降差价
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
            if ( comboBox33.Text != "" && !DateDayRegise.fiveFoureNum( comboBox33 ) )
            {
                this.comboBox33.Text = "";
                MessageBox.Show( "只允许输入整数部分最一两位,小数部分最多四位,如9.9999,请重新输入" );
            }
        }
        //采购零件单价
        private void comboBox28_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox28 );
        }
        private void comboBox28_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox28 );
        }
        private void comboBox28_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox28.Text != "" && !DateDayRegise. elevenForNumber ( comboBox28 ) )
            {
                this.comboBox28.Text = "";
                MessageBox.Show( "只允许输入整数部分最七位,小数部分最多四位,如9999999.9999,请重新输入" );
            }
        }
        //提成       
        private void comboBox27_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //每套零件数量
        private void comboBox29_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise . fractionCb ( e ,comboBox29 );
        }
        private void comboBox29_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise . textChangeCb ( comboBox29 );
        }
        private void comboBox29_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox29 . Text != "" && !DateDayRegise . eightFourNumber ( comboBox29 ) )
            {
                this . comboBox29 . Text = "";
                MessageBox . Show ( "只允许输入整数部分最四位,小数部分最多四位,如9999.9999,请重新输入" );
            }
        }
        //材料总单价
        private void comboBox19_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox19 );
        }
        private void comboBox19_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox19 );
        }
        private void comboBox19_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox19.Text != "" && !DateDayRegise.eightFourNumber( comboBox19 ) )
            {
                this.comboBox19.Text = "";
                MessageBox.Show( "只允许输入整数部分最四位,小数部分最多四位,如9999.9999,请重新输入" );
            }
        }
        private void comboBox11_SelectedValueChanged ( object sender ,EventArgs e )
        {
            switch ( comboBox11 . Text )
            {
                case "成品委外":
                comboBox5 . Text = "R_199";
                break;
                //case "热转印":
                //comboBox5 . Text = "R_196";
                //break;
                //case "装运.代理":
                //comboBox5 . Text = "R_243";
                //break;
                case "胶合板":
                comboBox5 . Text = "R_338";
                break;
                case "密度板":
                comboBox5 . Text = "R_338";
                break;
                case "木材":
                comboBox5 . Text = "R_341";
                break;
                case "车木件":
                comboBox5 . Text = "R_342";
                break;
                case "白坯委外":
                comboBox5 . Text = "R_342";
                break;
                case "铁件":
                comboBox5 . Text = "R_343";
                break;
                case "塑料件":
                comboBox5 . Text = "R_347";
                break;
                case "其它材料":
                comboBox5 . Text = "R_347";
                break;
                //case "喷漆工资":
                //comboBox5 . Text = "R_519.495";
                //break;
                //case "油漆款":
                //comboBox5 . Text = "R_519.339";
                //break;
                //case "滚漆款":
                //comboBox5 . Text = "R_519.344";
                //break;
                case "包装材料":
                comboBox5 . Text = "R_349.347";
                break;
                case "生产":
                comboBox5 . Text = "生产";
                break;
                case "/":
                comboBox5 . Text = "/";
                break;
            }
        }
        #endregion

        #region 主体
        string sads = "", weihu = "";
        //string GS03 = "", GS22 = "", GS24 = "", GS26 = "", GS28 = "", GS30 = "", GS32 = "", GS33 = "", GS47 = "", GS48 = "", GS46 = "", GS50 = "", GS34 = "";
        //int GS31 = 0;
        //long GS049 = 0;
        //DateTime GS29 = MulaolaoBll . Drity . GetDt ( ), GS27 = MulaolaoBll . Drity . GetDt ( ), GS25 = MulaolaoBll . Drity . GetDt ( ), GS23 = MulaolaoBll . Drity . GetDt ( );
        //新增
        protected override void add ( )
        {
            base.add( );

            Ergodic.FormEvery( this );
            gridControl1.DataSource = null;
            gridControl2.DataSource = null;
            gridControl3.DataSource = null;

            //button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button9.Enabled = button10.Enabled = button12.Enabled = button14.Enabled = button15.Enabled = button16.Enabled = button17.Enabled = button19.Enabled = button20.Enabled = button21.Enabled = button18.Enabled = true;

            Ergodic . SpliEnableTrue ( spList );
            textBox16.Enabled = false;
            //button13.Enabled = false;
            label7.Visible = false;
            datatimepickeroverride6.Enabled = datatimepickeroverride1.Enabled = false;
            sads = "1";

            _model . GS34 = oddNumbers.purchaseContract( "SELECT MAX(GS34) GS34 FROM R_PQP" ,"GS34" ,"R_509-" );
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
        }
        //删除
        protected override void delete ( )
        {
            base.delete( );

            if ( label7 . Visible == true )
            {
                if ( Logins . number == "MLL-0001" )
                {
                    dele ( );
                }
                else
                    MessageBox . Show ( "单号:" + _model . GS34 + "的单据状态为执行,您无权删除" );
            }
            else
                dele ( );
        }
        void dele ( )
        {
            if ( _model . GS34 == "" )
                MessageBox . Show ( "请查询需要删除的内容" );
            else
            {
                result = bll . Delete ( _model . GS34 ,Logins . username );
                //int count = SqlHelper . ExecuteNonQuery ( "DELETE FROM R_PQP WHERE GS34=@GS34" ,new SqlParameter ( "@GS34" ,GS34 ) );
                if ( result == false )
                    MessageBox . Show ( "数据删除失败" );
                else
                {
                    MessageBox . Show ( "数据删除成功" );

                    toolAdd . Enabled = toolSelect . Enabled = true;
                    toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolSave . Enabled = toolCancel . Enabled = toolcopy . Enabled = false;
                    //button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button9.Enabled = button10.Enabled = button12.Enabled = button14.Enabled = button15.Enabled = button16.Enabled = button17.Enabled = button19.Enabled = button20.Enabled = button21.Enabled = button18.Enabled = false;

                    Ergodic . SpliEnableFalse ( spList );

                    Ergodic . FormEvery ( this );
                    gridControl1 . DataSource = null;
                    gridControl2 . DataSource = null;
                    gridControl3 . DataSource = null;

                    textBox16 . Enabled = false;
                    //button13.Enabled = false;

                    //try
                    //{
                    //    SqlHelper . ExecuteNonQuery ( "DELETE FROM R_REVIEWS WHERE RES01=(SELECT CX01 FROM R_MLLCXMC WHERE CX02=@CX02) AND RES06=@RES06" ,new SqlParameter ( "@CX02" ,this . Text ) ,new SqlParameter ( "@RES06" ,GS34 ) );
                    //}
                    //catch { }
                }
            }
        }
        //更改
        protected override void update ( )
        {
            base.update( );

            //DataTable del = SqlHelper.ExecuteDataTable( "SELECT * FROM R_REVIEWS A,R_MLLCXMC B WHERE A.RES01=B.CX01 AND RES05='执行' AND RES06=@RES06 AND CX02=@CX02 " ,new SqlParameter( "@RES06" ,GS34 ) ,new SqlParameter( "@CX02" ,this.Text ) );
            if(label7.Visible==true)
            //if ( del != null && del.Rows.Count > 0 )
            //{
                MessageBox.Show( "单号:" + _model . GS01 + "的单据状态为执行,不允许更改" );
            //}
            else
            {
                toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled =toolcopy.Enabled= false;
                toolSave.Enabled = toolCancel.Enabled = true;
                //button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button9.Enabled = button10.Enabled = button12.Enabled = button14.Enabled = button15.Enabled = button16.Enabled = button17.Enabled = button19.Enabled = button20.Enabled = button21.Enabled = button18.Enabled = true;

                Ergodic.SpliEnableTrue( spList );
                //button13.Enabled = false;
                textBox16.Enabled = false;
                label7.Visible = false;
                datatimepickeroverride6.Enabled = datatimepickeroverride1.Enabled = false;
            }
        }
        //送审
        protected override void revirw ( )
        {
            base.revirw( );

            Reviews( "GS34" ,_model . GS34 ,"R_PQP" ,this ,"" ,"R_509" ,false ,false,MulaolaoBll . Drity . GetDt ( )/* ,"" ,"" ,"" ,"" ,"" ,"" ,"" ,"R_509"*/);
        }
        //打印
        protected override void print ( )
        {
            base.print( );
            Create( );

            report.Load( Environment.CurrentDirectory + "\\R_509.frx" );
            report.RegisterData( RDataSet );
            report.Show( );
        }
        //导出
        protected override void export ( )
        {
            base.export( );
            Create( );

            report.Load( Environment.CurrentDirectory + "\\R_509.frx" );
            report.RegisterData( RDataSet );
            report.Prepare( );
            XMLExport exprots = new XMLExport( );
            exprots.Export( report );
        }
        //保存
        private void adds ( )
        {
            toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled =toolcopy.Enabled= true;
            toolSave.Enabled = toolCancel.Enabled = false;
            //button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button9.Enabled = button10.Enabled = button12.Enabled = button14.Enabled = button15.Enabled = button16.Enabled = button17.Enabled = button19.Enabled = button20.Enabled = button21.Enabled = button18.Enabled = false;

            Ergodic.SpliEnableFalse( spList );
            //button13.Enabled = false;
            textBox16.Enabled = false;
            weihu = "";
        }
        protected override void save ( )
        {
            base.save( );

            if ( !radioButton1.Checked && !radioButton2.Checked )
                MessageBox.Show( "请选择新单或者老单,不可不选" );
            else
            {
                _model . GS01 = textBox3.Text;
                _model . GS46 = textBox1.Text;
                _model . GS47 = textBox2.Text;
                _model . GS48 = textBox5.Text;
                if ( string.IsNullOrEmpty( textBox4.Text ) )
                    _model . GS49 = 0;
                else
                    _model . GS49 = Convert.ToInt64( textBox4.Text );
                if ( radioButton1.Checked )
                    _model . GS03 = radioButton1.Text;
                else if ( radioButton2.Checked )
                    _model . GS03 = radioButton2.Text;
                _model . GS22 = textBox6.Text;
                _model . GS23 = datatimepickeroverride2.Value;
                _model . GS24 = textBox7.Text;
                _model . GS25 = datatimepickeroverride3.Value;
                _model . GS26 = textBox8.Text;
                _model . GS27 = datatimepickeroverride4.Value;
                _model . GS28 = textBox9.Text;
                _model . GS29 = datatimepickeroverride5.Value;
                _model . GS30 = textBox10.Text;
                if ( comboBox16 . Text != "" )
                    _model . GS31 = Convert . ToInt32 ( comboBox16 . Text );
                else
                    _model . GS31 = 0;
                _model . GS32 = textBox16.Text;
                _model . GS33 = "";


                DataTable das = SqlHelper.ExecuteDataTable( "SELECT GS34,GS33 FROM R_PQP WHERE GS34=@GS34" ,new SqlParameter( "@GS34" ,_model . GS34 ) );

                if ( weihu == "1" )
                {
                    if ( textBox16.Text == "" )
                        MessageBox.Show( "请填写维护意见" );
                    else
                    {
                        if ( das.Rows.Count < 1 )
                            MessageBox.Show( "单号:" + _model . GS34 + "的数据不存在,请核实后再维护" );
                        else
                        {
                            if ( bll . ExistsNum ( _model ) )
                            {
                                MessageBox . Show ( "流水号:" + _model . GS01 + "已经存在，不允许保存" );
                                return;
                            }
                            _model . GS33 = das.Rows[0]["GS33"].ToString( ) + "[" + Logins.username + MulaolaoBll . Drity . GetDt ( ).ToString( "yyyyMMdd" ) + "]";
                            //int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQP SET GS01=@GS01,GS46=@GS46,GS47=@GS47,GS48=@GS48,GS49=@GS49,GS50=@GS50,GS03=@GS03,GS22=@GS22,GS23=@GS23,GS24=@GS24,GS25=@GS25,GS26=@GS26,GS27=@GS27,GS28=@GS28,GS29=@GS29,GS30=@GS30,GS31=@GS31,GS32=@GS32,GS33=@GS33 WHERE GS34=@GS34" ,new SqlParameter( "@GS34" ,GS34 ) ,new SqlParameter( "@GS03" ,GS03 ) ,new SqlParameter( "@GS22" ,GS22 ) ,new SqlParameter( "@GS23" ,GS23 ) ,new SqlParameter( "@GS24" ,GS24 ) ,new SqlParameter( "@GS25" ,GS25 ) ,new SqlParameter( "@GS26" ,GS26 ) ,new SqlParameter( "@GS27" ,GS27 ) ,new SqlParameter( "@GS28" ,GS28 ) ,new SqlParameter( "@GS29" ,GS29 ) ,new SqlParameter( "@GS30" ,GS30 ) ,new SqlParameter( "@GS31" ,GS31 ) ,new SqlParameter( "@GS32" ,GS32 ) ,new SqlParameter( "@GS33" ,GS33 ) ,new SqlParameter( "@GS46" ,GS46 ) ,new SqlParameter( "@GS47" ,GS47 ) ,new SqlParameter( "@GS48" ,GS48 ) ,new SqlParameter( "@GS49" ,GS049 ) ,new SqlParameter( "@GS50" ,GS50 ) ,new SqlParameter( "@GS01" ,GS01 ) );
                            result = bll . Update ( _model );
                            if ( result==false )
                                MessageBox.Show( "录入数据失败" );
                            else
                            {
                                MessageBox.Show( "成功录入数据" );

                                adds( );
                            }
                        }
                    }
                }
                else
                {
                    if ( das.Rows.Count < 1 )
                    {
                        //int count = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQP (GS01,GS03,GS22,GS23,GS24,GS25,GS26,GS27,GS28,GS29,GS30,GS31,GS32,GS33,GS34,GS46,GS47,GS48,GS49,GS50) VALUES (@GS01,@GS03,@GS22,@GS23,@GS24,@GS25,@GS26,@GS27,@GS28,@GS29,@GS30,@GS31,@GS32,@GS33,@GS34,@GS46,@GS47,@GS48,@GS49,@GS50)" ,new SqlParameter( "@GS34" ,GS34 ) ,new SqlParameter( "@GS03" ,GS03 ) ,new SqlParameter( "@GS22" ,GS22 ) ,new SqlParameter( "@GS23" ,GS23 ) ,new SqlParameter( "@GS24" ,GS24 ) ,new SqlParameter( "@GS25" ,GS25 ) ,new SqlParameter( "@GS26" ,GS26 ) ,new SqlParameter( "@GS27" ,GS27 ) ,new SqlParameter( "@GS28" ,GS28 ) ,new SqlParameter( "@GS29" ,GS29 ) ,new SqlParameter( "@GS30" ,GS30 ) ,new SqlParameter( "@GS31" ,GS31 ) ,new SqlParameter( "@GS32" ,GS32 ) ,new SqlParameter( "@GS33" ,GS33 ) ,new SqlParameter( "@GS46" ,GS46 ) ,new SqlParameter( "@GS47" ,GS47 ) ,new SqlParameter( "@GS48" ,GS48 ) ,new SqlParameter( "@GS49" ,GS049 ) ,new SqlParameter( "@GS50" ,GS50 ) ,new SqlParameter( "@GS01" ,GS01 ) );

                        if ( bll . ExistsNum ( _model ) )
                        {
                            MessageBox . Show ( "流水号:" + _model . GS01 + "已经存在，不允许保存" );
                            return;
                        }

                        result = bll . Add ( _model );
                        if ( result==false )
                            MessageBox.Show( "录入数据失败" );
                        else
                        {
                            MessageBox.Show( "成功录入数据" );

                            adds( );
                        }
                    }
                    else
                    {
                        //int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQP SET GS01=@GS01,GS46=@GS46,GS47=@GS47,GS48=@GS48,GS49=@GS49,GS50=@GS50,GS03=@GS03,GS22=@GS22,GS23=@GS23,GS24=@GS24,GS25=@GS25,GS26=@GS26,GS27=@GS27,GS28=@GS28,GS29=@GS29,GS30=@GS30,GS31=@GS31,GS32=@GS32,GS33=@GS33 WHERE GS34=@GS34" ,new SqlParameter( "@GS34" ,GS34 ) ,new SqlParameter( "@GS03" ,GS03 ) ,new SqlParameter( "@GS22" ,GS22 ) ,new SqlParameter( "@GS23" ,GS23 ) ,new SqlParameter( "@GS24" ,GS24 ) ,new SqlParameter( "@GS25" ,GS25 ) ,new SqlParameter( "@GS26" ,GS26 ) ,new SqlParameter( "@GS27" ,GS27 ) ,new SqlParameter( "@GS28" ,GS28 ) ,new SqlParameter( "@GS29" ,GS29 ) ,new SqlParameter( "@GS30" ,GS30 ) ,new SqlParameter( "@GS31" ,GS31 ) ,new SqlParameter( "@GS32" ,GS32 ) ,new SqlParameter( "@GS33" ,GS33 ) ,new SqlParameter( "@GS46" ,GS46 ) ,new SqlParameter( "@GS47" ,GS47 ) ,new SqlParameter( "@GS48" ,GS48 ) ,new SqlParameter( "@GS49" ,GS049 ) ,new SqlParameter( "@GS50" ,GS50 ) ,new SqlParameter( "@GS01" ,GS01 ) );
                        if ( bll . ExistsNum ( _model ) )
                        {
                            MessageBox . Show ( "流水号:" + _model . GS01 + "已经存在，不允许保存" );
                            return;
                        }
                        result = bll . Update ( _model );
                        if ( result==false )
                            MessageBox.Show( "录入数据失败" );
                        else
                        {
                            MessageBox.Show( "成功录入数据" );
                            adds( );
                        }
                    }
                }
            }
        }
        //取消
        protected override void cancel ( )
        {
            base.cancel( );
            if ( sads == "1" && weihu != "1" )
            {
                try
                {
                    SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQP WHERE GS34=@GS34" ,new SqlParameter( "@GS34" ,_model . GS34 ) );
                }
                catch { }
                finally
                {
                    Ergodic.FormEvery( this );
                    gridControl1.DataSource = null;
                    gridControl2.DataSource = null;
                    gridControl3.DataSource = null;
                    toolAdd.Enabled = toolSelect.Enabled = toolPrint.Enabled = toolExport.Enabled = true;
                    toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled =toolcopy.Enabled= false;

                    //button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button9.Enabled = button10.Enabled = button12.Enabled = button14.Enabled = button15.Enabled = button16.Enabled = button17.Enabled = button19.Enabled = button20.Enabled = button21.Enabled = button18.Enabled = false;

                    
                    //button13.Enabled = false;
                }
            }
            else if ( sads == "2" || weihu == "1" )
            {
                toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled =toolcopy.Enabled= true;
                toolSave.Enabled = toolCancel.Enabled = false;
                //button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button9.Enabled = button10.Enabled = button17.Enabled = button19.Enabled = button20.Enabled = button21.Enabled = button18.Enabled = false;
            }
            Ergodic.SpliEnableFalse( spList );
            textBox16.Enabled = false;
        }
        //维护
        protected override void maintain ( )
        {
            base . maintain ( );

            //DataTable del = SqlHelper.ExecuteDataTable( "SELECT RES03,RES05,RES06,DBA012,CX02 FROM TPADBA A,R_REVIEW B,R_REVIEWS C,R_MLLCXMC D WHERE A.DBA001=B.RE01 AND B.RE01=C.RES03 AND C.RES01=D.CX01 AND RES06=@RES06 AND CX02=@CX02" ,new SqlParameter( "@RES06" ,_model . GS34 ) ,new SqlParameter( "@CX02" ,this.Text ) );
            if ( label7 . Visible == true )
            //if ( del != null && del.Rows.Count > 0 )
            {
                //if ( del.Select( "RES05='执行'" ).Length > 0 )
                //{
                toolAdd . Enabled = toolSelect . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = false;
                toolSave . Enabled = toolCancel . Enabled = true;
                //button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button12.Enabled = button14.Enabled = button15.Enabled = button16.Enabled = button17.Enabled = button19.Enabled = button20.Enabled = button21.Enabled = button18.Enabled = true;
                button6 . Enabled = button7 . Enabled = button8 . Enabled = button9 . Enabled = button10 . Enabled = false;

                Ergodic . SpliEnableTrue ( spList );

                weihu = "1";

                textBox16 . Enabled = true;
                //button13.Enabled = false;
                label7 . Visible = true;
                datatimepickeroverride6 . Enabled = datatimepickeroverride1 . Enabled = false;
                //}
                //else
                //    MessageBox.Show( "此单据没有被执行,只需更改即可,无需维护" );
            }
            else
                MessageBox . Show ( "此单据没有被执行,只需更改即可,无需维护" );
        }
        //复制
        protected override void copys ( )
        {
            base.copys( );

            int count = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQP (GS30,GS31,GS38,GS02,GS03,GS04,GS05,GS06,GS07,GS08,GS09,GS10,GS11,GS13,GS14,GS15,GS16,GS17,GS18,GS20,GS22,GS24,GS26,GS28,GS32,GS33,GS35,GS36,GS37,GS39,GS40,GS41,GS42,GS43,GS44,GS51,GS52,GS53,GS54,GS56,GS57,GS58,GS59,GS60,GS61,GS62,GS63,GS64,GS65,GS66,GS68,GS69,GS70,GS71) SELECT GS30,GS31,GS38,GS02,GS03,GS04,GS05,GS06,GS07,GS08,GS09,GS10,GS11,GS13,GS14,GS15,GS16,GS17,GS18,GS20,GS22,GS24,GS26,GS28,GS32,GS33,GS35,GS36,GS37,GS39,GS40,GS41,GS42,GS43,GS44,GS51,GS52,GS53,GS54,GS56,GS57,GS58,GS59,GS60,GS61,GS62,GS63,GS64,GS65,GS66,GS68,GS69,GS70,GS71 FROM R_PQP WHERE GS34=@GS34" ,new SqlParameter( "@GS34" ,_model . GS34 ) );
            if ( count < 1 )
                MessageBox.Show( "复制失败,请重试" );
            else
            {
                _model . GS34 = oddNumbers.purchaseContract( "SELECT MAX(GS34) GS34 FROM R_PQP" ,"GS34" ,"R_509-" );
                int num = SqlHelper.ExecuteNonQuery( "UPDATE R_PQP SET GS34=@GS34 WHERE GS34 IS NULL" ,new SqlParameter( "@GS34" ,_model . GS34 ) );
                if ( num < 1 )
                {
                    MessageBox.Show( "复制失败,请重试" );
                    try
                    {
                        SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQP WHERE GS34 IS NULL" );
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show( "成功复制此表" );
                    Ergodic.FormEvery( this );
                    gridControl1.DataSource = null;
                    gridControl2.DataSource = null;
                    gridControl3.DataSource = null;
                    Ergodic.SpliEnableTrue( spList );
                   toolSelect.Enabled= toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolReview.Enabled = toolcopy.Enabled = false;
                    toolSave.Enabled = toolCancel.Enabled = true;
                    sads = "1";
                    label7 . Visible = false;
                    query( );
                    button11_Click( null ,null );
                    button12_Click( null ,null );
                    button17_Click( null ,null );
                }
            }
        }
        #endregion

        #region 表格
        //string GS2 = "", GS7 = "", GS8 = "", GS9 = "", GS014 = "", GS015 = "", GS016 = "", GS017 = "", GS018 = "", , GS035 = "", GS038 = "", GS040 = "", GS041 = "", GS042 = "", GS043 = "", GS044 = "", GS052 = "", GS056 = "", GS057 = "", GS058 = "", GS062 = "", GS063 = "", GS064 = "", GS065 = "", GS066 = "", GS068 = "", ,GS070="",GS071="";
        string DGA3 = "", DGA11 = "",D3 = "", D11 = "";
        //decimal GS4 = 0M, GS5 = 0M, GS6 = 0M, GS011 = 0M, GS036 = 0M, GS037 = 0M, GS051 = 0M, GS053 = 0M, GS054 = 0M, GS055 = 0M, GS060 = 0M, GS061 = 0M, GS010 = 0M;
        //int  GS013 = 0, GS039 = 0, GS059 = 0, GS069 = 0;
        //DateTime GS019 = MulaolaoBll . Drity . GetDt ( ), GS045 = MulaolaoBll . Drity . GetDt ( ), GS067 = MulaolaoBll . Drity . GetDt ( );

        #region  材料
        //新建
        private void build ( )
        {
            _model . GS02 = comboBox3 . Text;
            if ( comboBox1 . Text != "" )
                _model . GS04 = Convert . ToDecimal ( comboBox1 . Text );
            else
                _model . GS04 = 0M;
            if ( comboBox4 . Text != "" )
                _model . GS05 = Convert . ToDecimal ( comboBox4 . Text );
            else
                _model . GS05 = 0M;
            if ( comboBox10 . Text != "" )
                _model . GS13 = Convert . ToInt32 ( comboBox10 . Text );
            else
                _model . GS13 = 0;
            _model . GS16 = lookUpEdit1 . Text;
            _model . GS19 = datatimepickeroverride6 . Value;
            _model . GS07 = comboBox6 . Text;
            _model . GS08 = comboBox7 . Text;
            if ( comboBox2 . Text != "" )
                _model . GS10 = Convert . ToDecimal ( comboBox2 . Text );
            else
                _model . GS10 = 0;
            if ( comboBox9 . Text != "" )
                _model . GS11 = Convert . ToDecimal ( comboBox9 . Text );
            else
                _model . GS11 = 0M;
            _model . GS09 = comboBox8 . Text;
            _model . GS17 = lookUpEdit2 . Text;
            DGA3 = textBox11 . Text;
            _model . GS14 = textBox13 . Text;
            _model . GS15 = textBox14 . Text;
            _model . GS18 = lookUpEdit3 . Text;
            DGA11 = textBox15 . Text;
            if ( string . IsNullOrEmpty ( comboBox18 . Text ) )
                _model . GS51 = 0M;
            else
                _model . GS51 = Convert . ToDecimal ( comboBox18 . Text );
            _model . GS70 = comboBox5 . Text;
            _model . GS71 = comboBox11 . Text;
        }
        private void button1_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( comboBox5 . Text ) )
            {
                MessageBox . Show ( "请选择合同代号" );
                return;
            }
            if ( string . IsNullOrEmpty ( comboBox11 . Text ) )
            {
                MessageBox . Show ( "请选择类别" );
                return;
            }
            if ( string . IsNullOrEmpty ( comboBox3 . Text ) )
            {
                MessageBox . Show ( "请填写材料" );
                return;
            }
            if ( string . IsNullOrEmpty ( comboBox6 . Text ) )
            {
                MessageBox . Show ( "请填写零件名称" );
                return;
            }
            build ( );

            //DataTable dsr = SqlHelper . ExecuteDataTable ( "SELECT * FROM R_PQP WHERE GS34=@GS34 AND GS02=@GS02 AND GS07=@GS07 AND GS20=@GS20" ,new SqlParameter ( "@GS34" ,GS34 ) ,new SqlParameter ( "@GS02" ,GS2 ) ,new SqlParameter ( "@GS07" ,GS7 ) ,new SqlParameter ( "@GS20" ,GS020 ) );
            result = bll . Exists ( _model );
            if ( result==false )
            {
                //int count = SqlHelper . ExecuteNonQuery ( "INSERT INTO R_PQP (GS34,GS02,GS04,GS05,GS07,GS08,GS09,GS10,GS11,GS13,GS14,GS15,GS16,GS17,GS18,GS19,GS20,GS49,GS51,GS70,GS71) VALUES (@GS34,@GS02,@GS04,@GS05,@GS07,@GS08,@GS09,@GS10,@GS11,@GS13,@GS14,@GS15,@GS16,@GS17,@GS18,@GS19,@GS20,@GS49,@GS51,@GS70,@GS71)" ,new SqlParameter ( "@GS34" ,GS34 ) ,new SqlParameter ( "@GS02" ,GS2 ) ,new SqlParameter ( "@GS04" ,GS4 ) ,new SqlParameter ( "@GS05" ,GS5 ) ,new SqlParameter ( "@GS07" ,GS7 ) ,new SqlParameter ( "@GS08" ,GS8 ) ,new SqlParameter ( "@GS09" ,GS9 ) ,new SqlParameter ( "@GS10" ,GS010 ) ,new SqlParameter ( "@GS11" ,GS011 ) ,new SqlParameter ( "@GS13" ,GS013 ) ,new SqlParameter ( "@GS14" ,GS014 ) ,new SqlParameter ( "@GS15" ,GS015 ) ,new SqlParameter ( "@GS16" ,GS016 ) ,new SqlParameter ( "@GS17" ,GS017 ) ,new SqlParameter ( "@GS18" ,GS018 ) ,new SqlParameter ( "@GS19" ,GS019 ) ,new SqlParameter ( "@GS20" ,GS020 ) ,new SqlParameter ( "@GS49" ,GS049 ) ,new SqlParameter ( "@GS51" ,GS051 ) ,new SqlParameter ( "@GS70" ,GS070 ) ,new SqlParameter ( "@GS71" ,GS071 ) );      if ( bll . ExistsNum ( _model ) )
                if ( bll . ExistsNum ( _model ) )
                {
                    MessageBox . Show ( "流水号:" + _model . GS01 + "已经存在，不允许保存" );
                    return;
                }
                result = bll . BuildOne ( _model );
                if ( result==false )
                    MessageBox . Show ( "录入数据失败" );
                else
                {
                    MessageBox . Show ( "成功录入数据" );
                    DataRow row;
                    if ( sads == "1" )
                    {
                        ddl = SqlHelper . ExecuteDataTable ( "SELECT idx,GS02,GS49,GS51,GS04,GS05,GS07,GS08,GS09,GS10,GS11,GS13,GS14,GS15,GS16,GS17,GS18,GS19,GS20,(SELECT DGA003 FROM TPADGA WHERE GS20 = DGA001 ) DGA003 ,(SELECT DGA011 FROM TPADGA WHERE GS20 = DGA001 ) DGA011,D.U7,GS70,GS71 FROM R_PQP A, (SELECT GS02 U0 ,SUM( GS10 * GS11 ) U7 FROM R_PQP GROUP BY GS02 ) D WHERE A.GS02 = D.U0 AND GS34 = @GS34 AND GS02!='' AND GS02 IS NOT NULL ORDER BY GS02,GS71,GS70,GS07" ,new SqlParameter ( "@GS34" ,_model . GS34 ) );
                        gridControl1 . DataSource = ddl;
                    }
                    else if ( sads == "2" )
                    {
                        row = ddl . NewRow ( );
                        row [ "GS02" ] = _model . GS02;
                        row [ "GS49" ] = _model . GS49;
                        row [ "GS04" ] = _model . GS04;
                        row [ "GS05" ] = _model . GS05;
                        row [ "GS07" ] = _model . GS07;
                        row [ "GS08" ] = _model . GS08;
                        row [ "GS09" ] = _model . GS09;
                        row [ "GS10" ] = _model . GS10;
                        row [ "GS11" ] = _model . GS11;
                        row [ "GS13" ] = _model . GS13;
                        row [ "GS14" ] = _model . GS14;
                        row [ "GS15" ] = _model . GS15;
                        row [ "GS16" ] = _model . GS16;
                        row [ "GS17" ] = _model . GS17;
                        row [ "GS18" ] = _model . GS18;
                        row [ "GS19" ] = _model . GS19;
                        row [ "GS51" ] = _model . GS51;
                        row [ "GS70" ] = _model . GS70;
                        row [ "GS71" ] = _model . GS71;
                        row [ "DGA003" ] = DGA3;
                        row [ "DGA011" ] = DGA11;
                        ddl . Rows . Add ( row );
                    }

                    materialScience ( );
                }
            }
            else
                MessageBox . Show ( "单号：" + _model . GS34 + "\n\r材料：" + _model . GS02 + "\n\r零件名称：" + _model . GS07 + "\n\r供应商：" + DGA3 + "\n\r的数据已经存在,请核实后再录入" );
        }
        //编辑
        private void up ( )
        {
            int num = gridView1 . FocusedRowHandle;
            DataRow row;
            //if ( sads == "1" )
            //{
            //    row = dde . Rows [ num ];
            //    row . BeginEdit ( );
            //    row [ "GS02" ] = _model . GS02;
            //    row [ "GS49" ] = _model . GS49;
            //    row [ "GS04" ] = _model . GS04;
            //    row [ "GS05" ] = _model . GS05;
            //    row [ "GS07" ] = _model . GS07;
            //    row [ "GS08" ] = _model . GS08;
            //    row [ "GS09" ] = _model . GS09;
            //    row [ "GS10" ] = _model . GS10;
            //    row [ "GS11" ] = _model . GS11;
            //    row [ "GS13" ] = _model . GS13;
            //    row [ "GS14" ] = _model . GS14;
            //    row [ "GS15" ] = _model . GS15;
            //    row [ "GS16" ] = _model . GS16;
            //    row [ "GS17" ] = _model . GS17;
            //    row [ "GS18" ] = _model . GS18;
            //    row [ "GS19" ] = _model . GS19;
            //    row [ "GS51" ] = _model . GS51;
            //    row [ "GS70" ] = _model . GS70;
            //    row [ "GS71" ] = _model . GS71;
            //    row [ "DGA003" ] = DGA3;
            //    row [ "DGA011" ] = DGA11;
            //    row . EndEdit ( );
            //}
            //else if ( sads == "2" )
            //{
                row = ddl . Rows [ num ];
                row . BeginEdit ( );
                row [ "GS02" ] = _model . GS02;
                row [ "GS49" ] = _model . GS49;
                row [ "GS04" ] = _model . GS04;
                row [ "GS05" ] = _model . GS05;
                row [ "GS07" ] = _model . GS07;
                row [ "GS08" ] = _model . GS08;
                row [ "GS09" ] = _model . GS09;
                row [ "GS10" ] = _model . GS10;
                row [ "GS11" ] = _model . GS11;
                row [ "GS13" ] = _model . GS13;
                row [ "GS14" ] = _model . GS14;
                row [ "GS15" ] = _model . GS15;
                row [ "GS16" ] = _model . GS16;
                row [ "GS17" ] = _model . GS17;
                row [ "GS18" ] = _model . GS18;
                row [ "GS19" ] = _model . GS19;
                row [ "GS51" ] = _model . GS51;
                row [ "GS70" ] = _model . GS70;
                row [ "GS71" ] = _model . GS71;
                row [ "DGA003" ] = DGA3;
                row [ "DGA011" ] = DGA11;
                row . EndEdit ( );
            //}

            materialScience ( );
        }
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( comboBox5 . Text ) )
            {
                MessageBox . Show ( "请选择合同代号" );
                return;
            }
            if ( string . IsNullOrEmpty ( comboBox11 . Text ) )
            {
                MessageBox . Show ( "请选择类别" );
                return;
            }
            if ( string . IsNullOrEmpty ( comboBox3 . Text ) )
            {
                MessageBox . Show ( "请填写材质" );
                return;
            }
            if ( string . IsNullOrEmpty ( comboBox6 . Text ) )
            {
                MessageBox . Show ( "请填写零件名称" );
                return;
            }
            build ( );

            if ( _model . GS02 == GS002 && _model . GS07 == GS007 && _model . GS20 == GS200  && _model.GS08==GS008)
            {
                //GS34=@GS34 AND  AND  AND 
                //,new SqlParameter( "@GS34" ,GS34 ) 
                //
                //
                //
                //int count = SqlHelper . ExecuteNonQuery ( "UPDATE R_PQP SET GS02=@GS2,GS04=@GS04,GS05=@GS05,GS07=@GS7,GS08=@GS08,GS09=@GS09,GS10=@GS10,GS11=@GS11,GS13=@GS13,GS14=@GS14,GS15=@GS15,GS16=@GS16,GS17=@GS17,GS18=@GS18,GS19=@GS19,GS20=@GS20,GS51=@GS51,GS70=@GS70,GS71=@GS71 WHERE idx=@idx" ,new SqlParameter ( "@GS02" ,GS2 ) ,new SqlParameter ( "@GS04" ,GS4 ) ,new SqlParameter ( "@GS05" ,GS5 ) ,new SqlParameter ( "@GS07" ,GS7 ) ,new SqlParameter ( "@GS08" ,GS8 ) ,new SqlParameter ( "@GS09" ,GS9 ) ,new SqlParameter ( "@GS10" ,GS010 ) ,new SqlParameter ( "@GS11" ,GS011 ) ,new SqlParameter ( "@GS13" ,GS013 ) ,new SqlParameter ( "@GS14" ,GS014 ) ,new SqlParameter ( "@GS15" ,GS015 ) ,new SqlParameter ( "@GS16" ,GS016 ) ,new SqlParameter ( "@GS17" ,GS017 ) ,new SqlParameter ( "@GS18" ,GS018 ) ,new SqlParameter ( "@GS19" ,GS019 ) ,new SqlParameter ( "@GS51" ,GS051 ) ,new SqlParameter ( "@idx" ,idxOne ) ,new SqlParameter ( "@GS2" ,GS002 ) ,new SqlParameter ( "@GS7" ,GS007 ) ,new SqlParameter ( "@GS20" ,GS020 ) ,new SqlParameter ( "@GS70" ,GS070 ) ,new SqlParameter ( "@GS71" ,GS071 ) );
                result = bll . EditOne ( _model );
                if ( result==false )
                    MessageBox . Show ( "编辑数据失败" );
                else
                {
                    MessageBox . Show ( "成功编辑数据" );
                    up ( );
                }
            }
            else
            {
                //DataTable de = SqlHelper . ExecuteDataTable ( "SELECT * FROM R_PQP WHERE GS34=@GS34 AND GS02=@GS02 AND GS07=@GS07 AND GS20=@GS20" ,new SqlParameter ( "GS34" ,_model . GS34 ) ,new SqlParameter ( "@GS02" ,_model . GS02 ) ,new SqlParameter ( "@GS07" ,_model . GS07 ) ,new SqlParameter ( "@GS20" ,_model . GS20 ) );
                result = bll . Exists ( _model );
                if ( result )
                    MessageBox . Show ( "单号：" + _model . GS34 + "\n\r材料：" + _model . GS02 + "\n\r零件名称：" + _model . GS07 + "\n\r规格:" + _model . GS08 + "\n\r供应商：" + DGA3 + "\n\r的数据已经存在,请核实后再录入" );
                else
                {
                    //GS34=@GS34 AND GS02=@GS2 AND GS07=@GS7 AND GS20=@GS020
                    //,new SqlParameter( "@GS34" ,GS34 )
                    //,new SqlParameter( "@GS2" ,GS002 ) ,new SqlParameter( "@GS7" ,GS007 )
                    //,new SqlParameter( "@GS020" ,GS200 )
                    //int count = SqlHelper . ExecuteNonQuery ( "UPDATE R_PQP SET GS02=@GS02,GS04=@GS04,GS05=@GS05,GS07=@GS07,GS08=@GS08,GS09=@GS09,GS10=@GS10,GS11=@GS11,GS13=@GS13,GS14=@GS14,GS15=@GS15,GS16=@GS16,GS17=@GS17,GS18=@GS18,GS19=@GS19,GS20=@GS20,GS51=@GS51,GS70=@GS70,GS71=@GS71 WHERE idx=@idx" ,new SqlParameter ( "@GS02" ,GS2 ) ,new SqlParameter ( "@GS04" ,GS4 ) ,new SqlParameter ( "@GS05" ,GS5 ) ,new SqlParameter ( "@GS07" ,GS7 ) ,new SqlParameter ( "@GS08" ,GS8 ) ,new SqlParameter ( "@GS09" ,GS9 ) ,new SqlParameter ( "@GS10" ,GS010 ) ,new SqlParameter ( "@GS11" ,GS011 ) ,new SqlParameter ( "@GS13" ,GS013 ) ,new SqlParameter ( "@GS14" ,GS014 ) ,new SqlParameter ( "@GS15" ,GS015 ) ,new SqlParameter ( "@GS16" ,GS016 ) ,new SqlParameter ( "@GS17" ,GS017 ) ,new SqlParameter ( "@GS18" ,GS018 ) ,new SqlParameter ( "@GS19" ,GS019 ) ,new SqlParameter ( "@GS20" ,GS020 ) ,new SqlParameter ( "@GS51" ,GS051 ) ,new SqlParameter ( "@idx" ,idxOne ) ,new SqlParameter ( "@GS70" ,GS070 ) ,new SqlParameter ( "@GS71" ,GS071 ) );
                    result = bll . EditOne ( _model );
                    if ( result == false )
                        MessageBox . Show ( "编辑数据失败" );
                    else
                    {
                        MessageBox . Show ( "成功编辑数据" );
                        up ( );
                    }
                }
            }
        }
        //删除
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                return;
            int num = gridView1 . FocusedRowHandle;
            if ( comboBox3 . Text == "" )
                MessageBox . Show ( "请填写材质" );
            else
            {
                if ( comboBox6 . Text == "" )
                    MessageBox . Show ( "请填写零件名称" );
                else
                {
                    build ( );
                    //DataTable de = SqlHelper . ExecuteDataTable ( "SELECT * FROM R_PQP WHERE GS34=@GS34 AND GS02=@GS02 AND GS07=@GS07 AND GS20=@GS20" ,new SqlParameter ( "GS34" ,GS34 ) ,new SqlParameter ( "@GS02" ,GS2 ) ,new SqlParameter ( "@GS07" ,GS7 ) ,new SqlParameter ( "@GS20" ,GS020 ) );
                    result = bll . Exists ( _model );
                    if ( result==false )
                        MessageBox . Show ( "不存在\n\r单号：" + _model.GS34 + "\n\r材料：" + _model . GS02 + "\n\r零件名称：" + _model . GS07 + "\n\r供应商：" + DGA3 + "\n\r的数据,请核实后再录入" );
                    else
                    {
                        //GS34=@GS34 AND GS02=@GS02 AND GS07=@GS07 AND GS20=@GS20
                        //,new SqlParameter( "@GS02" ,GS002 ) ,new SqlParameter( "@GS07" ,GS007 ) ,new SqlParameter( "@GS20" ,GS020 )
                        //int count = SqlHelper . ExecuteNonQuery ( "DELETE FROM R_PQP WHERE idx=@idx" ,new SqlParameter ( "idx" ,idxOne ) );
                        result = bll . DeleteOne ( _model );
                        if ( result==false )
                            MessageBox . Show ( "删除数据失败" );
                        else
                        {
                            MessageBox . Show ( "成功删除数据" );

                            //if ( sads == "1" )
                            //    dde . Rows . RemoveAt ( num );
                            //else if ( sads == "2" )
                                ddl . Rows . RemoveAt ( num );

                            materialScience ( );
                        }
                    }
                }
            }
        }
        //刷新
        private void button11_Click( object sender, EventArgs e )
        {
            //if (sads == "1")
            //{
            //    dde = SqlHelper.ExecuteDataTable( "SELECT idx,GS02,GS49,GS51,GS04,GS05,GS07,GS08,GS09,GS10,GS11,GS13,GS14,GS15,GS16,GS17,GS18,GS19,GS20,(SELECT DGA003 FROM TPADGA WHERE GS20 = DGA001 ) DGA003 ,(SELECT DGA011 FROM TPADGA WHERE GS20 = DGA001 ) DGA011,D.U7,GS70,GS71 FROM R_PQP A, (SELECT GS02 U0 ,SUM( GS10 * GS11 ) U7 FROM R_PQP GROUP BY GS02 ) D WHERE A.GS02 = D.U0 AND GS34 = @GS34 AND GS02!='' AND GS02 IS NOT NULL ORDER BY GS02,GS07,GS71,GS70" ,new SqlParameter( "@GS34" ,_model.GS34 ) );
            //    gridControl1.DataSource = dde;
            //}
            //else if (sads == "2")
            //{
                ddl = SqlHelper.ExecuteDataTable( "SELECT idx,GS02,GS51,GS49,GS04,GS05,GS07,GS08,GS09,GS10,GS11,GS13,GS14,GS15,GS16,GS17,GS18,GS19,GS20,(SELECT DGA003 FROM TPADGA WHERE GS20 = DGA001 ) DGA003 ,(SELECT DGA011 FROM TPADGA WHERE GS20 = DGA001 ) DGA011,D.U7,GS70,GS71 FROM R_PQP A, (SELECT GS02 U0 ,SUM( GS10 * GS11 ) U7 FROM R_PQP GROUP BY GS02) D WHERE A.GS02 = D.U0 AND GS34 = @GS34 AND GS02!='' AND GS02 IS NOT NULL ORDER BY GS70,GS71,GS02,GS07" ,new SqlParameter( "@GS34" ,_model . GS34 ) );
                gridControl1.DataSource = ddl;
            //}
        }
        #endregion

        #region 工段
        //DataTable dda;
        //新建
        private void builds ( )
        {
            _model.GS35 = comboBox12.Text;
            if ( comboBox24.Text == "" )
                _model . GS36 = 0M;
            else
                _model . GS36 = Convert.ToDecimal( comboBox24.Text );
            if ( comboBox23.Text == "" )
                _model . GS37 = 0M;
            else
                _model . GS37 = Convert.ToDecimal( comboBox23.Text );
            _model . GS38 = comboBox20.Text;
            if ( comboBox17.Text == "" )
                _model . GS39 = 0;
            else
                _model . GS39 = Convert.ToInt32( comboBox17.Text );
            _model . GS40 = textBox20.Text;
            _model . GS41 = textBox19.Text;
            _model . GS42 = lookUpEdit4.Text;
            _model . GS43 = lookUpEdit5.Text;
            _model . GS44 = lookUpEdit6.Text;
            _model . GS45 = datatimepickeroverride1.Value;
            _model . GS72 = comboBox13 . Text;
        }
        private void button16_Click ( object sender ,EventArgs e )
        {
            if ( comboBox12 . Text == "" )
                MessageBox . Show ( "请选择或填写工段" );
            else
            {
                builds ( );

                //DataTable dl = SqlHelper . ExecuteDataTable ( "SELECT * FROM R_PQP WHERE GS34=@GS34 AND GS35=@GS35" ,new SqlParameter ( "@GS34" ,_model . GS34 ) ,new SqlParameter ( "@GS35" ,_model . GS35 ) );
                result = bll . ExistsOne ( _model );
                if ( result == false )
                {
                    //int count = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQP (GS34,GS35,GS36,GS37,GS38,GS39,GS40,GS41,GS42,GS43,GS44,GS45) VALUES (@GS34,@GS35,@GS36,@GS37,@GS38,@GS39,@GS40,@GS41,@GS42,@GS43,@GS44,@GS45)" ,new SqlParameter( "@GS34" ,GS34 ) ,new SqlParameter( "@GS35" ,GS035 ) ,new SqlParameter( "@GS36" ,GS036 ) ,new SqlParameter( "@GS37" ,GS037 ) ,new SqlParameter( "@GS38" ,GS038 ) ,new SqlParameter( "@GS39" ,GS039 ) ,new SqlParameter( "@GS40" ,GS040 ) ,new SqlParameter( "@GS41" ,GS041 ) ,new SqlParameter( "@GS42" ,GS042 ) ,new SqlParameter( "@GS43" ,GS043 ) ,new SqlParameter( "@GS44" ,GS044 ) ,new SqlParameter( "@GS45" ,GS045 ) );
                    if ( bll . ExistsNum ( _model ) )
                    {
                        MessageBox . Show ( "流水号:" + _model . GS01 + "已经存在，不允许保存" );
                        return;
                    }
                    result = bll . BuildTwo ( _model );
                    if ( result == false )
                        MessageBox . Show ( "数据录入失败" );
                    else
                    {
                        MessageBox . Show ( "成功录入数据" );

                        if ( sads == "1" )
                        {
                            ddk = SqlHelper . ExecuteDataTable ( "SELECT idx,GS35,GS36,GS37,GS38,GS39,GS40,GS41,GS42,GS43,GS44,GS45,GS72 FROM R_PQP WHERE GS36 IS NOT NULL AND GS34=@GS34 AND GS35!='' AND GS35 IS NOT NULL" ,new SqlParameter ( "@GS34" ,_model.GS34 ) );
                            gridControl2 . DataSource = ddk;
                        }
                        else if ( sads == "2" )
                        {
                            DataRow row;
                            row = ddk . NewRow ( );
                            row [ "GS35" ] = _model . GS35;
                            row [ "GS36" ] = _model . GS36;
                            row [ "GS37" ] = _model . GS37;
                            row [ "GS38" ] = _model . GS38;
                            row [ "GS39" ] = _model . GS39;
                            row [ "GS40" ] = _model . GS40;
                            row [ "GS41" ] = _model . GS41;
                            row [ "GS42" ] = _model . GS42;
                            row [ "GS43" ] = _model . GS43;
                            row [ "GS44" ] = _model . GS44;
                            row [ "GS45" ] = _model . GS45;
                            row [ "GS72" ] = _model . GS72;
                            ddk . Rows . Add ( row );
                        }
                        workshopSection ( );
                    }
                }
                else
                    MessageBox . Show ( "单号:" + _model . GS34 + "\n\r工段:" + _model . GS35 + "\n\r的记录已经存在,请核实后再录入" );
            }
        }
        //编辑
        private void upd ( )
        {
            DataRow row;
            int num = gridView2 . FocusedRowHandle;
            //if ( sads == "1" )
            //{
            //    row = dda . Rows [ num ];
            //    row . BeginEdit ( );
            //    row [ "GS35" ] = _model . GS35;
            //    row [ "GS36" ] = _model . GS36;
            //    row [ "GS37" ] = _model . GS37;
            //    row [ "GS38" ] = _model . GS38;
            //    row [ "GS39" ] = _model . GS39;
            //    row [ "GS40" ] = _model . GS40;
            //    row [ "GS41" ] = _model . GS41;
            //    row [ "GS42" ] = _model . GS42;
            //    row [ "GS43" ] = _model . GS43;
            //    row [ "GS44" ] = _model . GS44;
            //    row [ "GS45" ] = _model . GS45;
            //    row [ "GS72" ] = _model . GS72;
            //    row . EndEdit ( );
            //}
            //else if ( sads == "2" )
            //{
                row = ddk . Rows [ num ];
                row . BeginEdit ( );
                row [ "GS35" ] = _model . GS35;
                row [ "GS36" ] = _model . GS36;
                row [ "GS37" ] = _model . GS37;
                row [ "GS38" ] = _model . GS38;
                row [ "GS39" ] = _model . GS39;
                row [ "GS40" ] = _model . GS40;
                row [ "GS41" ] = _model . GS41;
                row [ "GS42" ] = _model . GS42;
                row [ "GS43" ] = _model . GS43;
                row [ "GS44" ] = _model . GS44;
                row [ "GS45" ] = _model . GS45;
                row [ "GS72" ] = _model . GS72;
                row . EndEdit ( );
            //}
            workshopSection ( );
        }
        private void button15_Click ( object sender ,EventArgs e )
        {
            if ( comboBox12 . Text == "" )
                MessageBox . Show ( "请选择或填写工段" );
            else
            {
                builds ( );

                if ( gs035 == _model . GS35 )
                {
                    //GS34=@GS34 AND 
                    //,new SqlParameter( "@GS34" ,GS34 ) 
                    //int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQP SET GS35=@GS35,GS36=@GS36,GS37=@GS37,GS38=@GS38,GS39=@GS39,GS40=@GS40,GS41=@GS41,GS42=@GS42,GS43=@GS43,GS44=@GS44,GS45=@GS45 WHERE idx=@idx" ,new SqlParameter( "@GS36" ,GS036 ) ,new SqlParameter( "@GS37" ,GS037 ) ,new SqlParameter( "@GS38" ,GS038 ) ,new SqlParameter( "@GS39" ,GS039 ) ,new SqlParameter( "@GS40" ,GS040 ) ,new SqlParameter( "@GS41" ,GS041 ) ,new SqlParameter( "@GS42" ,GS042 ) ,new SqlParameter( "@GS43" ,GS043 ) ,new SqlParameter( "@GS44" ,GS044 ) ,new SqlParameter( "@GS45" ,GS045 ) ,new SqlParameter ( "@idx" ,idxTwo ) ,new SqlParameter ( "@GS35" ,GS035 ) );
                    result = bll . EditTwo ( _model );
                    if ( result == false )
                        MessageBox . Show ( "编辑数据失败" );
                    else
                    {
                        MessageBox . Show ( "编辑数据成功" );

                        upd ( );
                    }
                }
                else
                {
                    //DataTable dr = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQP WHERE GS34=@GS34 AND GS35=@GS35" ,new SqlParameter( "@GS34" ,GS34 ) ,new SqlParameter( "@GS35" ,GS035 ) );
                    result = bll . ExistsOne ( _model );
                    if ( result == false )
                    {
                        //GS34=@GS34 AND GS35=@GS035
                        //,new SqlParameter( "@GS34" ,GS34 )   ,new SqlParameter( "@GS035" ,gs035 )
                        //int count = SqlHelper . ExecuteNonQuery ( "UPDATE R_PQP SET GS35=@GS35,GS36=@GS36,GS37=@GS37,GS38=@GS38,GS39=@GS39,GS40=@GS40,GS41=@GS41,GS42=@GS42,GS43=@GS43,GS44=@GS44,GS45=@GS45 WHERE idx=@idx" ,new SqlParameter ( "@GS35" ,GS035 ) ,new SqlParameter ( "@GS36" ,GS036 ) ,new SqlParameter ( "@GS37" ,GS037 ) ,new SqlParameter ( "@GS38" ,GS038 ) ,new SqlParameter ( "@GS39" ,GS039 ) ,new SqlParameter ( "@GS40" ,GS040 ) ,new SqlParameter ( "@GS41" ,GS041 ) ,new SqlParameter ( "@GS42" ,GS042 ) ,new SqlParameter ( "@GS43" ,GS043 ) ,new SqlParameter ( "@GS44" ,GS044 ) ,new SqlParameter ( "@GS45" ,GS045 ) ,new SqlParameter ( "@idx" ,idxTwo ) );
                        result = bll . EditTwo ( _model );
                        if ( result == false )
                            MessageBox . Show ( "编辑数据失败" );
                        else
                        {
                            MessageBox . Show ( "编辑数据成功" );

                            upd ( );
                        }
                    }
                    else
                        MessageBox . Show ( "已经存在\n\r单号:" + _model . GS34 + "\n\r工段:" + _model . GS35 + "\n\r的记录,请核实后再编辑" );
                }
            }
        }
        //删除
        private void button14_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) ==DialogResult . Cancel )
                return;

            builds ( );
            if ( comboBox12.Text == "" )
                MessageBox.Show( "请选择或填写工段" );
            else
            {
                //DataTable dy = SqlHelper . ExecuteDataTable ( "SELECT * FROM R_PQP WHERE GS34=@GS34 AND GS35=@GS35" ,new SqlParameter ( "@GS34" ,_model . GS34 ) ,new SqlParameter ( "@GS35" ,_model . GS35 ) );
                result = bll . ExistsOne ( _model );
                if ( result==false )
                    MessageBox.Show( "不存在\n\r单号:" + _model.GS34 + "\n\r工段:" +_model. GS35 + "\n\r的记录,请核实后再删除" );
                else
                {
                    //GS34=@GS34 AND GS35=@GS35
                    //,new SqlParameter( "@GS35" ,GS035 )
                    //int count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQP WHERE idx=@idx" ,new SqlParameter( "@idx" ,idxTwo )  );
                    result = bll . DeleteOne ( _model );
                    if ( result==false )
                        MessageBox.Show( "删除数据失败" );
                    else
                    {
                        MessageBox.Show( "成功删除数据" );

                        int num = gridView2.FocusedRowHandle;
                        //if ( sads == "1" )
                        //    dda.Rows.RemoveAt( num );
                        //else if ( sads == "2" )
                            ddk.Rows.RemoveAt( num );
                        workshopSection( );
                    }
                }
            }
        }
        //刷新
        private void button12_Click ( object sender ,EventArgs e )
        {
            //if ( sads == "1" )
            //{
            //    dda = SqlHelper.ExecuteDataTable( "SELECT idx,GS35,GS36,GS37,GS38,GS39,GS40,GS41,GS42,GS43,GS44,GS45,GS72 FROM R_PQP WHERE GS36 IS NOT NULL AND GS34=@GS34 AND GS35!='' AND GS35 IS NOT NULL" ,new SqlParameter( "@GS34" ,_model.GS34 ) );
            //    gridControl2.DataSource = dda;
            //}
            //else if ( sads == "2" )
            //{
                ddk = SqlHelper.ExecuteDataTable( "SELECT idx,GS35,GS36,GS37,GS38,GS39,GS40,GS41,GS42,GS43,GS44,GS45,GS72 FROM R_PQP WHERE GS36 IS NOT NULL AND GS34=@GS34 AND GS35!='' AND GS35 IS NOT NULL" ,new SqlParameter( "@GS34" ,_model.GS34 ) );
                gridControl2.DataSource = ddk;
            //}
        }
        #endregion

        #region 辅料
        //DataTable dx;
        void build_one ( )
        {
            _model . GS52 = comboBox14 . Text;
            if ( string . IsNullOrEmpty ( comboBox34 . Text ) )
                _model . GS53 = 0M;
            else
                _model . GS53 = Convert . ToDecimal ( comboBox34 . Text );
            if ( string . IsNullOrEmpty ( comboBox33 . Text ) )
                _model . GS54 = 0M;
            else
                _model . GS54 = Convert . ToDecimal ( comboBox33 . Text );
            _model . GS56 = comboBox32 . Text;
            _model . GS57 = comboBox15 . Text;
            _model . GS58 = comboBox30 . Text;
            if ( string . IsNullOrEmpty ( comboBox29 . Text ) )
                _model . GS59 = 0;
            else
                _model . GS59 = Convert . ToDecimal ( comboBox29 . Text );
            if ( string . IsNullOrEmpty ( comboBox28 . Text ) )
                _model . GS60 = 0M;
            else
                _model . GS60 = Convert . ToDecimal ( comboBox28 . Text );
            if ( string . IsNullOrEmpty ( comboBox19 . Text ) )
                _model . GS61 = 0M;
            else
                _model . GS61 = Convert . ToDecimal ( comboBox19 . Text );
            if ( string . IsNullOrEmpty ( comboBox27 . Text ) )
                _model . GS69 = 0;
            else
                _model . GS69 = Convert . ToInt32 ( comboBox27 . Text );
            _model . GS62 = textBox22 . Text;
            _model . GS63 = textBox21 . Text;
            _model . GS64 = lookUpEdit7 . Text;
            _model . GS65 = lookUpEdit8 . Text;
            _model . GS66 = lookUpEdit9 . Text;
            _model . GS67 = datatimepickeroverride7 . Value;
            D3 = textBox18 . Text;
            D11 = textBox17 . Text;
        }
        //新建
        private void button21_Click ( object sender ,EventArgs e )
        {
            if ( comboBox14 . Text == "" )
                MessageBox . Show ( "请填写材料" );
            else
            {
                if ( comboBox32 . Text == "" )
                    MessageBox . Show ( "请填写零件名称" );
                else
                {
                    build_one ( );

                    //DataTable dsr = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQP WHERE GS34=@GS34 AND GS52=@GS52 AND GS56=@GS56 AND GS57=@GS57 AND GS68=@GS68" ,new SqlParameter( "@GS34" ,GS34 ) ,new SqlParameter( "@GS52" ,GS052 ) ,new SqlParameter( "@GS56" ,GS056 ) ,new SqlParameter( "@GS68" ,GS068 ) ,new SqlParameter ( "@GS57" ,GS057 ) );
                    result = bll . ExistsTwo ( _model );
                    if ( result == false )
                    {
                        //int count = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQP (GS34,GS52,GS49,GS53,GS54,GS55,GS56,GS57,GS58,GS59,GS60,GS61,GS69,GS62,GS63,GS64,GS65,GS66,GS67,GS68) VALUES (@GS34,@GS52,@GS49,@GS53,@GS54,@GS55,@GS56,@GS57,@GS58,@GS59,@GS60,@GS61,@GS69,@GS62,@GS63,@GS64,@GS65,@GS66,@GS67,@GS68)" ,new SqlParameter( "@GS34" ,GS34 ) ,new SqlParameter( "@GS52" ,GS052 ) ,new SqlParameter( "@GS53" ,GS053 ) ,new SqlParameter( "@GS54" ,GS054 ) ,new SqlParameter( "@GS55" ,GS055 ) ,new SqlParameter( "@GS56" ,GS056 ) ,new SqlParameter( "@GS57" ,GS057 ) ,new SqlParameter( "@GS58" ,GS058 ) ,new SqlParameter( "@GS59" ,GS059 ) ,new SqlParameter( "@GS60" ,GS060 ) ,new SqlParameter( "@GS61" ,GS061 ) ,new SqlParameter( "@GS69" ,GS069 ) ,new SqlParameter( "@GS62" ,GS062 ) ,new SqlParameter( "@GS63" ,GS063 ) ,new SqlParameter( "@GS64" ,GS064 ) ,new SqlParameter( "@GS65" ,GS065 ) ,new SqlParameter( "@GS66" ,GS066 ) ,new SqlParameter( "@GS67" ,GS067 ) ,new SqlParameter( "@GS68" ,GS068 ) ,new SqlParameter( "@GS49" ,GS049 ) );
                        if ( bll . ExistsNum ( _model ) )
                        {
                            MessageBox . Show ( "流水号:" + _model . GS01 + "已经存在，不允许保存" );
                            return;
                        }
                        result = bll . BuildTre ( _model );
                        if ( result == false )
                            MessageBox . Show ( "录入数据失败" );
                        else
                        {
                            MessageBox . Show ( "录入数据成功" );

                            if ( sads == "1" )
                            {
                                ddp = SqlHelper . ExecuteDataTable ( "SELECT idx,GS52,GS49,GS61,GS53,GS54,GS56,GS57,GS58,GS59,GS60,GS69,GS62,GS63,GS64,GS65,GS66,GS67,GS68,(SELECT DGA003 FROM TPADGA WHERE GS68 = DGA001 ) DGA003 ,(SELECT DGA011 FROM TPADGA WHERE GS68 = DGA001 ) DGA011,D.U11 FROM R_PQP A, (SELECT GS52 U0 ,SUM( GS59 * GS60 ) U11 FROM R_PQP GROUP BY GS52 ) D WHERE A.GS52 = D.U0 AND GS34 = @GS34 AND GS52!='' AND GS52 IS NOT NULL ORDER BY GS52" ,new SqlParameter ( "@GS34" ,_model . GS34 ) );
                                gridControl3 . DataSource = ddp;
                            }
                            else if ( sads == "2" )
                            {
                                DataRow row = ddp . NewRow ( );
                                row [ "GS49" ] =_model. GS49;
                                row [ "GS52" ] = _model . GS52;
                                row [ "GS53" ] = _model . GS53;
                                row [ "GS54" ] = _model . GS54;
                                row [ "GS56" ] = _model . GS56;
                                row [ "GS57" ] = _model . GS57;
                                row [ "GS58" ] = _model . GS58;
                                row [ "GS59" ] = _model . GS59;
                                row [ "GS60" ] = _model . GS60;
                                row [ "GS61" ] = _model . GS61;
                                row [ "GS62" ] = _model . GS62;
                                row [ "GS63" ] = _model . GS63;
                                row [ "GS64" ] = _model . GS64;
                                row [ "GS65" ] = _model . GS65;
                                row [ "GS66" ] = _model . GS66;
                                row [ "GS67" ] = _model . GS67;
                                row [ "GS68" ] = _model . GS68;
                                row [ "GS69" ] = _model . GS69;
                                row [ "DGA003" ] = D3;
                                row [ "DGA011" ] = D11;
                                ddp . Rows . Add ( row );
                            }
                            accessories ( );
                        }
                    }
                    else
                        MessageBox . Show ( "单号：" + _model . GS34 + "\n\r辅料：" + _model . GS52 + "\n\r零件名称：" + _model . GS56 + "\n\r规格：" + _model . GS57 + "\n\r供应商：" + D3 + "\n\r的数据已经存在 ,请核实后再录入" );
                }
            }
        }
        //删除
        private void button19_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) ==DialogResult . Cancel )
                return;
            if ( comboBox14.Text == "" )
                MessageBox.Show( "请填写材料" );
            else
            {
                if ( comboBox32.Text == "" )
                    MessageBox.Show( "请填写零件名称" );
                else
                {
                    build_one( );

                    //DataTable dsr = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQP WHERE GS34=@GS34 AND GS52=@GS52 AND GS56=@GS56 AND GS68=@GS68" ,new SqlParameter( "@GS34" ,GS34 ) ,new SqlParameter( "@GS52" ,GS052 ) ,new SqlParameter( "@GS56" ,GS056 ) ,new SqlParameter( "@GS68" ,GS068 ) );
                    result = bll . ExistsTwo ( _model );
                    if ( result==false )
                        MessageBox.Show( "不存在\n\r单号：" + _model . GS34 + "\n\r辅料：" + _model . GS52 + "\n\r零件名称：" + _model . GS56 + "\n\r供应商：" + D3 + "\n\r的数据 ,请核实后再录入" );
                    else
                    {
                        //GS34=@GS34 AND GS52=@GS52 AND GS56=@GS56 AND GS68=@GS68
                        // ,new SqlParameter( "@GS52" ,GS052 ) ,new SqlParameter( "@GS56" ,GS056 ) ,new SqlParameter( "@GS68" ,GS068 )
                        //int count = SqlHelper . ExecuteNonQuery ( "DELETE FROM R_PQP WHERE idx=@idx" ,new SqlParameter ( "@idx" ,idxTre ) );
                        result = bll . DeleteOne ( _model );
                        if ( result==false )
                            MessageBox.Show( "删除数据失败" );
                        else
                        {
                            MessageBox.Show( "删除数据成功" );

                            int num = gridView3.FocusedRowHandle;
                            //if ( sads == "1" )
                            //    dx.Rows.RemoveAt( num );
                            //else
                                ddp.Rows.RemoveAt( num );
                            accessories( );
                        }
                    }
                }
            }
        }
        void up_one ( )
        {
            int num = gridView3.FocusedRowHandle;
            DataRow row;
            //if ( sads == "1" )
            //{
            //    row = dx.Rows[num];
            //    row.BeginEdit( );
            //    row["GS49"] = _model . GS49;
            //    row["GS52"] = _model . GS52;
            //    row["GS53"] = _model . GS53;
            //    row["GS54"] = _model . GS54;
            //    row["GS56"] = _model . GS56;
            //    row["GS57"] = _model . GS57;
            //    row["GS58"] = _model . GS58;
            //    row["GS59"] = _model . GS59;
            //    row["GS60"] = _model . GS60;
            //    row["GS61"] = _model . GS61;
            //    row["GS62"] = _model . GS62;
            //    row["GS63"] = _model . GS63;
            //    row["GS64"] = _model . GS64;
            //    row["GS65"] = _model . GS65;
            //    row["GS66"] = _model . GS66;
            //    row["GS67"] = _model . GS67;
            //    row["GS68"] = _model . GS68;
            //    row["GS69"] = _model . GS69;
            //    row["DGA003"] = D3;
            //    row["DGA011"] = D11;
            //    row.EndEdit( );
            //}
            //else if ( sads == "2" )
            //{
                row = ddp.Rows[num];
                row.BeginEdit( );
                row["GS49"] = _model . GS49;
                row["GS52"] = _model . GS52;
                row["GS53"] = _model . GS53;
                row["GS54"] = _model . GS54;
                row["GS56"] = _model . GS56;
                row["GS57"] = _model . GS57;
                row["GS58"] = _model . GS58;
                row["GS59"] = _model . GS59;
                row["GS60"] = _model . GS60;
                row["GS61"] = _model . GS61;
                row["GS62"] = _model . GS62;
                row["GS63"] = _model . GS63;
                row["GS64"] = _model . GS64;
                row["GS65"] = _model . GS65;
                row["GS66"] = _model . GS66;
                row["GS67"] = _model . GS67;
                row["GS68"] = _model . GS68;
                row["GS69"] = _model . GS69;
                row["DGA003"] = D3;
                row["DGA011"] = D11;
                row.EndEdit( );
            //}
            accessories( );
        }
        //编辑
        private void button20_Click ( object sender ,EventArgs e )
        {
            if ( comboBox14 . Text == "" )
                MessageBox . Show ( "请填写材料" );
            else
            {
                if ( comboBox32 . Text == "" )
                    MessageBox . Show ( "请填写零件名称" );
                else
                {
                    build_one ( );

                    if ( gs052 == _model . GS52 && gs056 == _model . GS56 && gs068 == _model . GS68 && gs057 == _model . GS57 )
                    {
                        //GS34=@GS34 AND   
                        //,new SqlParameter( "@GS34" ,GS34 )
                        //   
                        //int count = SqlHelper . ExecuteNonQuery ( "UPDATE R_PQP SET GS52=@GS52,GS53=@GS53,GS54=@GS54,GS55=@GS55,GS56=@GS56,GS57=@GS57,GS58=@GS58,GS59=@GS59,GS60=@GS60,GS61=@GS61,GS68=@GS68,GS69=@GS69,GS62=@GS62,GS63=@GS63,GS64=@GS64,GS65=@GS65,GS66=@GS66,GS67=@GS67 WHERE idx=@idx" ,new SqlParameter ( "@GS53" ,GS053 ) ,new SqlParameter ( "@GS54" ,GS054 ) ,new SqlParameter ( "@GS55" ,GS055 ) ,new SqlParameter ( "@GS58" ,GS058 ) ,new SqlParameter ( "@GS59" ,GS059 ) ,new SqlParameter ( "@GS60" ,GS060 ) ,new SqlParameter ( "@GS61" ,GS061 ) ,new SqlParameter ( "@GS69" ,GS069 ) ,new SqlParameter ( "@GS62" ,GS062 ) ,new SqlParameter ( "@GS63" ,GS063 ) ,new SqlParameter ( "@GS64" ,GS064 ) ,new SqlParameter ( "@GS65" ,GS065 ) ,new SqlParameter ( "@GS66" ,GS066 ) ,new SqlParameter ( "@GS67" ,GS067 ) ,new SqlParameter ( "@idx" ,idxTre ) ,new SqlParameter ( "@GS52" ,GS052 ) ,new SqlParameter ( "@GS56" ,GS056 ) ,new SqlParameter ( "@GS68" ,GS068 ) ,new SqlParameter ( "@GS57" ,GS057 ) );
                        result = bll . EditTre ( _model );
                        if ( result == false )
                            MessageBox . Show ( "编辑数据失败" );
                        else
                        {
                            MessageBox . Show ( "成功编辑数据" );

                            up_one ( );
                        }
                    }
                    else
                    {
                        //DataTable dsr = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQP WHERE GS34=@GS34 AND GS52=@GS52 AND GS56=@GS56 AND GS57=@GS57 AND GS68=@GS68" ,new SqlParameter( "@GS34" ,GS34 ) ,new SqlParameter( "@GS52" ,GS052 ) ,new SqlParameter( "@GS56" ,GS056 ) ,new SqlParameter( "@GS68" ,GS068 ) ,new SqlParameter ( "@GS57" ,GS057 ) );
                        result = bll . ExistsTwo ( _model );
                        if ( result )
                            MessageBox . Show ( "单号：" + _model . GS34 + "\n\r辅料：" + _model . GS52 + "\n\r零件名称：" + _model . GS56 + "辅料规格：" + _model . GS57 + "\n\r供应商：" + D3 + "\n\r的数据已经存在,请核实后再录入" );
                        else
                        {
                            //GS34=@GS34 AND GS52=@GS52 AND GS56=@GS56 AND GS68=@GS068 AND GS57=@GS57
                            //,new SqlParameter ( "@GS34" ,GS34 )
                            // ,new SqlParameter ( "@GS52" ,gs052 )
                            //,new SqlParameter ( "@GS56" ,gs056 )
                            //,new SqlParameter ( "@GS068" ,gs068 )
                            //,new SqlParameter ( "@GS57" ,GS057 ) 
                            //int count = SqlHelper . ExecuteNonQuery ( "UPDATE R_PQP SET GS53=@GS53,GS54=@GS54,GS55=@GS55,GS58=@GS58,GS59=@GS59,GS60=@GS60,GS61=@GS61,GS69=@GS69,GS62=@GS62,GS63=@GS63,GS64=@GS64,GS65=@GS65,GS66=@GS66,GS67=@GS67,GS68=@GS68,GS52=@GS052,GS56=@GS056,GS57=@GS057 WHERE idx=@idx" ,new SqlParameter ( "@GS53" ,GS053 ) ,new SqlParameter ( "@GS54" ,GS054 ) ,new SqlParameter ( "@GS55" ,GS055 ) ,new SqlParameter ( "@GS58" ,GS058 ) ,new SqlParameter ( "@GS59" ,GS059 ) ,new SqlParameter ( "@GS60" ,GS060 ) ,new SqlParameter ( "@GS61" ,GS061 ) ,new SqlParameter ( "@GS69" ,GS069 ) ,new SqlParameter ( "@GS62" ,GS062 ) ,new SqlParameter ( "@GS63" ,GS063 ) ,new SqlParameter ( "@GS64" ,GS064 ) ,new SqlParameter ( "@GS65" ,GS065 ) ,new SqlParameter ( "@GS66" ,GS066 ) ,new SqlParameter ( "@GS67" ,GS067 ) ,new SqlParameter ( "@GS68" ,GS068 ) ,new SqlParameter ( "@GS052" ,GS052 ) ,new SqlParameter ( "@GS056" ,GS056 ) ,new SqlParameter ( "@GS057" ,gs057 ) ,new SqlParameter ( "@idx" ,idxTre ) );
                            result = bll . EditTre ( _model );
                            if ( result == false )
                                MessageBox . Show ( "编辑数据失败" );
                            else
                            {
                                MessageBox . Show ( "成功编辑数据" );

                                up_one ( );
                            }
                        }
                    }
                }
            }
        }
        //刷新
        private void button17_Click ( object sender ,EventArgs e )
        {
            //if ( sads == "1" )
            //{
            //    dx = SqlHelper.ExecuteDataTable( "SELECT idx,GS52,GS49,GS61,GS53,GS54,GS56,GS57,GS58,GS59,GS60,GS69,GS62,GS63,GS64,GS65,GS66,GS67,GS68,(SELECT DGA003 FROM TPADGA WHERE GS68 = DGA001 ) DGA003 ,(SELECT DGA011 FROM TPADGA WHERE GS68 = DGA001 ) DGA011,D.U11 FROM R_PQP A, (SELECT GS52 U0 ,SUM( GS59 * GS60 ) U11 FROM R_PQP GROUP BY GS52 ) D WHERE A.GS52 = D.U0 AND GS34 = @GS34 AND GS52!='' AND GS52 IS NOT NULL ORDER BY GS52" ,new SqlParameter( "@GS34" ,_model.GS34 ) );
            //    gridControl3.DataSource = dx;
            //}
            //else if ( sads == "2" )
            //{
                ddp = SqlHelper.ExecuteDataTable( "SELECT idx,GS52,GS49,GS61,GS53,GS54,GS56,GS57,GS58,GS59,GS60,GS69,GS62,GS63,GS64,GS65,GS66,GS67,GS68,(SELECT DGA003 FROM TPADGA WHERE GS68 = DGA001 ) DGA003 ,(SELECT DGA011 FROM TPADGA WHERE GS68 = DGA001 ) DGA011,D.U11 FROM R_PQP A, (SELECT GS52 U0 ,SUM( GS59 * GS60 ) U11 FROM R_PQP GROUP BY GS52 ) D WHERE A.GS52 = D.U0 AND GS34 = @GS34 AND GS52!='' AND GS52 IS NOT NULL ORDER BY GS52" ,new SqlParameter( "@GS34" ,_model.GS34 ) );
                gridControl3.DataSource = ddp;
            //}
        }
        #endregion

        #region BatchEdit
        private void button13_Click_1 ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( textBox5 . Text ) )
            {
                MessageBox . Show ( "货号不可为空" );
                return;
            }
            SelectAll .BatchEdit batch = new SelectAll.BatchEdit( );
            batch.number = textBox5.Text;
            batch.StartPosition = FormStartPosition.CenterScreen;
            batch.ShowDialog( );
        }
        private void BatchAdd_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( textBox5 . Text ) )
            {
                MessageBox . Show ( "货号不可为空" );
                return;
            }
            SelectAll . FormBatchAdd batch = new SelectAll . FormBatchAdd ( textBox5 . Text );
            batch . StartPosition = FormStartPosition . CenterScreen;
            batch . ShowDialog ( );
        }
        #endregion

        #endregion

        #region 复制
        //COPY
        private void button13_Click ( object sender ,EventArgs e )
        {
            if ( _model.GS34 == "" )
                MessageBox.Show( "请查询需要复制的内容" );
            else
            {
                //int count = 0;
                DataTable dw = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQP WHERE GS34=@GS34" ,new SqlParameter( "@GS34" ,_model . GS34 ) );
                if ( dw.Rows.Count < 1 )
                    MessageBox.Show( "不存在单号:" + _model . GS34 + "的记录" );
                else
                {
                    _model . GS34 = oddNumbers.purchaseContract( "SELECT MAX(GS34) GS34 FROM R_PQP" ,"GS34" ,"R_509-" );
                    for ( int i = 0 ; i < dw.Rows.Count ; i++ )
                    {
                        //GS01 = dw.Rows[i]["GS01"].ToString( );
                        _model . GS46 = dw.Rows[i]["GS46"].ToString( );
                        _model . GS47 = dw.Rows[i]["GS47"].ToString( );
                        _model . GS48 = dw.Rows[i]["GS48"].ToString( );
                        if ( string.IsNullOrEmpty( dw.Rows[i]["GS49"].ToString( ) ) )
                            _model . GS49 = 0;
                        else
                            _model . GS49 = Convert.ToInt64( dw.Rows[i]["GS49"].ToString( ) );
                        //GS50 = dw.Rows[i]["GS50"].ToString( );
                        _model . GS03 = dw.Rows[i]["GS03"].ToString( );
                        _model . GS02 = dw.Rows[i]["GS02"].ToString( );
                        if ( string.IsNullOrEmpty( dw.Rows[i]["GS04"].ToString( ) ) )
                            _model . GS04 = 0;
                        else
                            _model . GS04 = Convert.ToDecimal( dw.Rows[i]["GS04"].ToString( ) );
                        if ( string.IsNullOrEmpty( dw.Rows[i]["GS05"].ToString( ) ) )
                            _model . GS05 = 0;
                        else
                            _model . GS05 = Convert.ToDecimal( dw.Rows[i]["GS05"].ToString( ) );
                        if ( string.IsNullOrEmpty( dw.Rows[i]["GS06"].ToString( ) ) )
                            _model . GS06 = 0;
                        else
                            _model . GS06 = Convert.ToDecimal( dw.Rows[i]["GS06"].ToString( ) );
                        _model . GS07 = dw.Rows[i]["GS07"].ToString( );
                        _model . GS08 = dw.Rows[i]["GS08"].ToString( );
                        _model . GS09 = dw.Rows[i]["GS09"].ToString( );
                        if ( string.IsNullOrEmpty( dw.Rows[i]["GS10"].ToString( ) ) )
                            _model . GS10 = 0;
                        else
                            _model . GS10 = Convert.ToDecimal( dw.Rows[i]["GS10"].ToString( ) );
                        if ( string.IsNullOrEmpty( dw.Rows[i]["GS11"].ToString( ) ) )
                            _model . GS11 = 0;
                        else
                            _model . GS11 = Convert.ToDecimal( dw.Rows[i]["GS11"].ToString( ) );
                        if ( string.IsNullOrEmpty( dw.Rows[i]["GS13"].ToString( ) ) )
                            _model . GS13 = 0;
                        else
                            _model . GS13 = Convert.ToInt32( dw.Rows[i]["GS13"].ToString( ) );
                        _model . GS14 = dw.Rows[i]["GS14"].ToString( );
                        _model . GS15 = dw.Rows[i]["GS15"].ToString( );
                        _model . GS16 = dw.Rows[i]["GS16"].ToString( );
                        _model . GS17 = dw.Rows[i]["GS17"].ToString( );
                        _model . GS18 = dw.Rows[i]["GS18"].ToString( );
                        if ( string.IsNullOrEmpty( dw.Rows[i]["GS19"].ToString( ) ) )
                            _model . GS19 = MulaolaoBll . Drity . GetDt ( );
                        else
                            _model . GS19 = Convert.ToDateTime( dw.Rows[i]["GS19"].ToString( ) );
                        _model . GS20 = dw.Rows[i]["GS20"].ToString( );
                        _model . GS22 = dw.Rows[i]["GS22"].ToString( );
                        if ( string.IsNullOrEmpty( dw.Rows[i]["GS23"].ToString( ) ) )
                            _model . GS23 = MulaolaoBll . Drity . GetDt ( );
                        else
                            _model . GS23 = Convert.ToDateTime( dw.Rows[i]["GS23"].ToString( ) );
                        _model . GS24 = dw.Rows[i]["GS24"].ToString( );
                        if ( string.IsNullOrEmpty( dw.Rows[i]["GS25"].ToString( ) ) )
                            _model . GS25 = MulaolaoBll . Drity . GetDt ( );
                        else
                            _model . GS25 = Convert.ToDateTime( dw.Rows[i]["GS25"].ToString( ) );
                        _model . GS26 = dw.Rows[i]["GS26"].ToString( );
                        //if ( string.IsNullOrEmpty( dw.Rows[i]["GS27"].ToString( ) ) )
                        //    GS27 = MulaolaoBll . Drity . GetDt ( );
                        //else
                        //    GS27 = Convert.ToDateTime( dw.Rows[i]["GS27"].ToString( ) );
                        _model . GS28 = dw.Rows[i]["GS28"].ToString( );
                        if ( string.IsNullOrEmpty( dw.Rows[i]["GS29"].ToString( ) ) )
                            _model . GS29 = MulaolaoBll . Drity . GetDt ( );
                        else
                            _model . GS29 = Convert.ToDateTime( dw.Rows[i]["GS29"].ToString( ) );
                        //GS30 = dw.Rows[i]["GS30"].ToString( );
                        //if ( string.IsNullOrEmpty( dw.Rows[i]["GS31"].ToString( ) ) )
                        //    GS31 = 0;
                        //else
                        //    GS31 = Convert.ToInt32( dw.Rows[i]["GS31"].ToString( ) );
                        _model . GS32 = dw.Rows[i]["GS32"].ToString( );
                        _model . GS33 = dw.Rows[i]["GS33"].ToString( );
                        _model . GS35 = dw.Rows[i]["GS35"].ToString( );
                        if ( string.IsNullOrEmpty( dw.Rows[i]["GS36"].ToString( ) ) )
                            _model . GS36 = 0M;
                        else
                            _model . GS36 = Convert.ToDecimal( dw.Rows[i]["GS36"].ToString( ) );
                        if ( string.IsNullOrEmpty( dw.Rows[i]["GS37"].ToString( ) ) )
                            _model . GS37 = 0M;
                        else
                            _model . GS37 = Convert.ToDecimal( dw.Rows[i]["GS37"].ToString( ) );
                        //GS038 = dw.Rows[i]["GS38"].ToString( );
                        if ( string.IsNullOrEmpty( dw.Rows[i]["GS39"].ToString( ) ) )
                            _model . GS39 = 0;
                        else
                            _model . GS39 = Convert.ToInt32( dw.Rows[i]["GS39"].ToString( ) );
                        _model . GS40 = dw.Rows[i]["GS40"].ToString( );
                        _model . GS41 = dw.Rows[i]["GS41"].ToString( );
                        _model . GS42 = dw.Rows[i]["GS42"].ToString( );
                        _model . GS43 = dw.Rows[i]["GS43"].ToString( );
                        _model . GS44 = dw.Rows[i]["GS44"].ToString( );
                        //if ( string.IsNullOrEmpty( dw.Rows[i]["GS45"].ToString( ) ) )
                        //    GS045 = MulaolaoBll . Drity . GetDt ( );
                        //else
                        //    GS045 = Convert.ToDateTime( dw.Rows[i]["GS45"].ToString( ) );
                        _model . GS45 = System . DateTime . Now;
                        if ( string.IsNullOrEmpty( dw.Rows[i]["GS51"].ToString( ) ) )
                            _model . GS51 = 0;
                        else
                            _model . GS51 = Convert.ToDecimal( dw.Rows[i]["GS51"].ToString( ) );
                        _model . GS52 = dw.Rows[i]["GS52"].ToString( );
                        if ( string.IsNullOrEmpty( dw.Rows[i]["GS53"].ToString( ) ) )
                            _model . GS53 = 0M;
                        else
                            _model . GS53 = Convert.ToDecimal( dw.Rows[i]["GS53"].ToString( ) );
                        if ( string.IsNullOrEmpty( dw.Rows[i]["GS54"].ToString( ) ) )
                            _model . GS54 = 0M;
                        else
                            _model . GS54 = Convert.ToDecimal( dw.Rows[i]["GS54"].ToString( ) );
                        _model . GS56 = dw.Rows[i]["GS56"].ToString( );
                        _model . GS57 = dw.Rows[i]["GS57"].ToString( );
                        _model . GS58 = dw.Rows[i]["GS58"].ToString( );
                        if ( string.IsNullOrEmpty( dw.Rows[i]["GS59"].ToString( ) ) )
                            _model . GS59 = 0;
                        else
                            _model . GS59 = Convert.ToInt32( dw.Rows[i]["GS59"].ToString( ) );
                        if ( string.IsNullOrEmpty( dw.Rows[i]["GS60"].ToString( ) ) )
                            _model . GS60 = 0M;
                        else
                            _model . GS60 = Convert.ToDecimal( dw.Rows[i]["GS60"].ToString( ) );
                        if ( string.IsNullOrEmpty( dw.Rows[i]["GS61"].ToString( ) ) )
                            _model . GS61 = 0M;
                        else
                            _model . GS61 = Convert.ToDecimal( dw.Rows[i]["GS61"].ToString( ) );
                        if ( string.IsNullOrEmpty( dw.Rows[i]["GS69"].ToString( ) ) )
                            _model . GS69 = 0;
                        else
                            _model . GS69 = Convert.ToInt32( dw.Rows[i]["GS69"].ToString( ) );
                        _model . GS62 = dw.Rows[i]["GS62"].ToString( );
                        _model . GS63 = dw.Rows[i]["GS63"].ToString( );
                        _model . GS64 = dw.Rows[i]["GS64"].ToString( );
                        _model . GS65 = dw.Rows[i]["GS65"].ToString( );
                        _model . GS66 = dw.Rows[i]["GS66"].ToString( );
                        if ( string.IsNullOrEmpty( dw.Rows[i]["GS67"].ToString( ) ) )
                            _model . GS67 = MulaolaoBll . Drity . GetDt ( );
                        else
                            _model . GS67 = Convert.ToDateTime( dw.Rows[i]["GS67"].ToString( ) );
                        _model . GS68 = dw.Rows[i]["GS68"].ToString( );
                        _model . GS70 = dw . Rows [ i ] [ "GS70" ] . ToString ( );
                        _model . GS71 = dw . Rows [ i ] [ "GS71" ] . ToString ( );

                        //GS01,GS27,GS30,GS31,GS38,@GS01,@GS27,@GS30,@GS31,@GS38,GS50,@GS50,
                        //count = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQP (GS34,GS46,GS47,GS48,GS49,GS02,GS03,GS04,GS05,GS06,GS07,GS08,GS09,GS10,GS11,GS13,GS14,GS15,GS16,GS17,GS18,GS19,GS20,GS22,GS23,GS24,GS25,GS26,GS28,GS29,GS32,GS33,GS35,GS36,GS37,GS39,GS40,GS41,GS42,GS43,GS44,GS45,GS51,GS52,GS53,GS54,GS56,GS57,GS58,GS59,GS60,GS61,GS62,GS63,GS64,GS65,GS66,GS67,GS68,GS69,GS70,GS71) VALUES (@GS34,@GS46,@GS47,@GS48,@GS49,@GS02,@GS03,@GS04,@GS05,@GS06,@GS07,@GS08,@GS09,@GS10,@GS11,@GS13,@GS14,@GS15,@GS16,@GS17,@GS18,@GS19,@GS20,@GS22,@GS23,@GS24,@GS25,@GS26,@GS28,@GS29,@GS32,@GS33,@GS35,@GS36,@GS37,@GS39,@GS40,@GS41,@GS42,@GS43,@GS44,@GS45,@GS51,@GS52,@GS53,@GS54,@GS56,@GS57,@GS58,@GS59,@GS60,@GS61,@GS62,@GS63,@GS64,@GS65,@GS66,@GS67,@GS68,@GS69,@GS70,@GS71)" ,new SqlParameter( "@GS34" ,GS34 ) /*,new SqlParameter( "@GS01" ,GS01 )*/ ,new SqlParameter( "@GS46" ,GS46 ) ,new SqlParameter( "@GS47" ,GS47 ) ,new SqlParameter( "@GS48" ,GS48 ) ,new SqlParameter( "@GS49" ,GS049 ) /*,new SqlParameter( "@GS50" ,GS50 )*/ ,new SqlParameter( "@GS02" ,GS2 ) ,new SqlParameter( "@GS03" ,GS03 ) ,new SqlParameter( "@GS04" ,GS4 ) ,new SqlParameter( "@GS05" ,GS5 ) ,new SqlParameter( "@GS06" ,GS6 ) ,new SqlParameter( "@GS07" ,GS7 ) ,new SqlParameter( "@GS08" ,GS8 ) ,new SqlParameter( "@GS09" ,GS9 ) ,new SqlParameter( "@GS10" ,GS010 ) ,new SqlParameter( "@GS11" ,GS011 ) ,new SqlParameter( "@GS13" ,GS013 ) ,new SqlParameter( "@GS14" ,GS014 ) ,new SqlParameter( "@GS15" ,GS015 ) ,new SqlParameter( "@GS16" ,GS016 ) ,new SqlParameter( "@GS17" ,GS017 ) ,new SqlParameter( "@GS18" ,GS018 ) ,new SqlParameter( "@GS19" ,GS019 ) ,new SqlParameter( "@GS20" ,GS020 ) ,new SqlParameter( "@GS22" ,GS22 ) ,new SqlParameter( "@GS23" ,GS23 ) ,new SqlParameter( "@GS24" ,GS24 ) ,new SqlParameter( "@GS25" ,GS25 ) ,new SqlParameter( "@GS26" ,GS26 ) /*,new SqlParameter( "@GS27" ,GS27 )*/ ,new SqlParameter( "@GS28" ,GS28 ) ,new SqlParameter( "@GS29" ,GS29 ) /*,new SqlParameter( "@GS30" ,GS30 ) *//*,new SqlParameter( "@GS31" ,GS31 ) */,new SqlParameter( "@GS32" ,GS32 ) ,new SqlParameter( "@GS33" ,GS33 ) ,new SqlParameter( "@GS35" ,GS035 ) ,new SqlParameter( "@GS36" ,GS036 ) ,new SqlParameter( "@GS37" ,GS037 ) /*,new SqlParameter( "@GS38" ,GS038 )*/ ,new SqlParameter( "@GS39" ,GS039 ) ,new SqlParameter( "@GS40" ,GS040 ) ,new SqlParameter( "@GS41" ,GS041 ) ,new SqlParameter( "@GS42" ,GS042 ) ,new SqlParameter( "@GS43" ,GS043 ) ,new SqlParameter( "@GS44" ,GS044 ) ,new SqlParameter( "@GS45" ,GS045 ) ,new SqlParameter( "@GS51" ,GS051 ) ,new SqlParameter( "@GS52" ,GS052 ) ,new SqlParameter( "@GS53" ,GS053 ) ,new SqlParameter( "@GS54" ,GS054 ) ,new SqlParameter( "@GS56" ,GS056 ) ,new SqlParameter( "@GS57" ,GS057 ) ,new SqlParameter( "@GS58" ,GS058 ) ,new SqlParameter( "@GS59" ,GS059 ) ,new SqlParameter( "@GS60" ,GS060 ) ,new SqlParameter( "@GS61" ,GS061 ) ,new SqlParameter( "@GS62" ,GS062 ) ,new SqlParameter( "@GS63" ,GS063 ) ,new SqlParameter( "@GS64" ,GS064 ) ,new SqlParameter( "@GS65" ,GS065 ) ,new SqlParameter( "@GS66" ,GS066 ) ,new SqlParameter( "@GS67" ,GS067 ) ,new SqlParameter( "@GS68" ,GS068 ) ,new SqlParameter( "@GS69" ,GS069 ) ,new SqlParameter ( "@GS70" ,GS070 ) ,new SqlParameter ( "@GS71" ,GS071 ) );
                        result = bll . Copy ( _model );
                    }
                    if ( result==false )
                        MessageBox.Show( "复制数据失败,请重新查找此数据,然后复制" );
                    else
                        MessageBox.Show( "成功复制数据,单号为:" + _model.GS34 + ",要操作此记录,请重新查询" );
                }
            }
        }
        #endregion

    }
}









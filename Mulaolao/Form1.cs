using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Data;
using System . Data . SqlClient;
using System . Windows . Forms;
using Mulaolao . Procedure;
using Mulaolao . Forms;
using StudentMgr;
using Mulaolao . Other;
using Mulaolao . Environmental;
using Mulaolao . Raw_material_cost;
using Mulaolao . Contract;
using Mulaolao . Schedule_control;
using Mulaolao . Wages;
using Mulaolao . Bom;
using Mulaolao . Summary;
using Mulaolao . Base;
using text;

namespace Mulaolao
{
    public partial class Form1 : Form
    {
        public Form1 ( )
        {
            InitializeComponent ( );
            this.WindowState = FormWindowState.Maximized;        
        }

        string user = Logins.username;
        string pe = Logins.pwd;
        string num = Logins.number;

        public static  List<ToolStripMenuItem> chen = new List<ToolStripMenuItem>( );

        private void Form1_Load( object sender, EventArgs e )
        {
            xtraTabbedMdiManager1.MdiParent = this;

          

            //遍历窗体的所有菜单
            foreach ( ToolStripMenuItem ts in this.MainMenuStrip.Items )
            {
                foreach ( var t in ts.DropDownItems )
                {
                    if ( t.GetType( ) == typeof( ToolStripMenuItem ) )
                        chen.Add( ( ToolStripMenuItem ) t );
                }
            }

            List<ToolStripMenuItem> tru = new List<ToolStripMenuItem>( );
            //根据读取到的登录用户名 查找该用户有哪些权限
            DataTable dt = SqlHelper.ExecuteDataTable( "SELECT B.CX02,DBB001,DBB003,DBB004,DBB005,DBB006,DBB007,DBB008,DBB009,DBB010 FROM R_DBB A,R_MLLCXMC B WHERE A.DBB002=B.CX01 AND DBB001=(SELECT DBA001 FROM TPADBA WHERE DBA001=@DBA001)", new SqlParameter( "@DBA001", num ) );
            //判断是否有数据  如果没有  则此人没有任何权限
            if (dt.Rows.Count < 1)
            {
                foreach (ToolStripMenuItem str in chen)
                {
                    str.Enabled = false;
                }
                MessageBox.Show( "" + user + "你好,你没有操作此系统的权限,请联系系统管理员" );
            }
            else
            {
                #region 送审提示设置
                Remind rd = new Remind ( this );
                rd . WindowState = FormWindowState . Maximized;
                rd . MdiParent = this;
                rd . Show ( );
                #endregion

                for ( int i = 0; i < dt.Rows.Count; i++)
                {
                    //遍历所有的二级ToolStripMenuItem
                    foreach (ToolStripMenuItem str in chen)
                    {
                        if (dt.Rows[i]["CX02"].ToString( ) == "全部程序")
                        {
                            str.Enabled = true;
                        }
                        else
                        {
                            string XZ = dt.Rows[i]["CX02"].ToString( );
                            //如果二级菜单的text与查找到的程序名称一致
                            if (dt.Rows[i]["CX02"].ToString( ) == str.Text)
                            {
                                //判断运行权限的值  若是F 则可以无法运行  若是T则能运行
                                if (dt.Rows[i]["DBB003"].ToString( ) == "T")
                                {
                                    str.Enabled = true;
                                    tru.Add( str );
                                }
                                else
                                {
                                    str.Enabled = false;
                                }
                            }
                            else
                            {
                                str.Enabled = false;
                            }
                        }
                    }
                }
            }

            foreach (ToolStripMenuItem sm in tru)
            {
                sm.Enabled = true;
            }
            guanTool.Enabled = true;
            RegeditTool.Enabled = true;
            ExitTool.Enabled = true;
            pwTool.Enabled = true;
            ToolRemain.Enabled = true;
            rToolStripMenuItem.Enabled = true;
            r004Tools . Enabled = true;
            r048Tool . Enabled = true;
        }

        public void r021Too_Click( object sender, EventArgs e )
        {
            R_FrmContractreview con = new R_FrmContractreview(  );
            con.MdiParent = this;
            con.StartPosition = FormStartPosition.CenterScreen;
            con.Show( );

        }
        private void r369Tool_Click(object sender, EventArgs e)
        {
            R_FrmCustomerrecord cus = new R_FrmCustomerrecord( );
            cus.MdiParent = this;
            cus.StartPosition = FormStartPosition.CenterScreen;
            cus.Show();
        }
        private void r404Tool_Click(object sender, EventArgs e)
        {
            R_FrmProductarchives pr = new R_FrmProductarchives( );
            pr.MdiParent = this;
            pr.StartPosition = FormStartPosition.CenterScreen;
            pr.Show();
        }
        private void r029Tool_Click(object sender, EventArgs e)
        {
            R_Frmhegexianchang hg = new R_Frmhegexianchang(this);
            hg.StartPosition = FormStartPosition.CenterScreen;
            hg.Show();
        }
        private void r045Tool_Click(object sender, EventArgs e)
        {
            R_FrmSampleorproductfirst sl = new R_FrmSampleorproductfirst(this);
            sl.StartPosition = FormStartPosition.CenterScreen;
            sl.Show();
        }
        private void r509Tool_Click(object sender, EventArgs e)
        {
            R_Frmchanpingaishan cp = new R_Frmchanpingaishan();
            cp.MdiParent = this;
            cp.StartPosition = FormStartPosition.CenterScreen;
            cp.Show( );
        }
        private void r338Tool_Click ( object sender ,EventArgs e )
        {
            R_FrmJiaomiducontract jd = new R_FrmJiaomiducontract ( );
            jd . MdiParent = this;
            jd . StartPosition = FormStartPosition . CenterScreen;
            jd . Show ( );
        }
        private void r339Tool_Click(object sender, EventArgs e)
        {
            R_Frmyouqimocontract yq = new R_Frmyouqimocontract();
            yq.MdiParent = this;
            yq.StartPosition = FormStartPosition.CenterScreen;
            yq.Show();
        }
        private void r519Tool_Click( object sender, EventArgs e )
        {
            R_FrmyouqiBom bo = new R_FrmyouqiBom( );
            bo.MdiParent = this;
            bo.StartPosition = FormStartPosition.CenterScreen;
            bo.Show( );
        }
        private void r495Tool_Click ( object sender , EventArgs e )
        {
            R_Frmpenyouqichen pq = new R_Frmpenyouqichen ( );
            pq . MdiParent = this;
            pq . StartPosition = FormStartPosition . CenterScreen;
            pq . Show ( );
        }
        private void r389Tool_Click( object sender, EventArgs e )
        {
            R_Frmhegegongfanshenhe gf = new R_Frmhegegongfanshenhe(this);
            gf.StartPosition = FormStartPosition.CenterScreen;
            gf . Show ( );
        }
        private void r436Tool_Click( object sender, EventArgs e )
        {
            R_Frmgongxugongzi gi = new R_Frmgongxugongzi(  );
            gi.MdiParent = this;
            gi.StartPosition = FormStartPosition.CenterScreen;
            gi.Show( );
        }
        private void r358Tool_Click( object sender, EventArgs e )
        {
            R_Frmxiaozuzhangyeji yj = new R_Frmxiaozuzhangyeji(this);
            yj.StartPosition = FormStartPosition.CenterScreen;
            yj.Show();
        }
        private void r317Tool_Click( object sender, EventArgs e )
        {
            R_Frmchanpingongzikaoqin pk = new R_Frmchanpingongzikaoqin();
            pk.MdiParent = this;
            pk.StartPosition = FormStartPosition.CenterScreen;
            pk.Show();
        }
        private void r146Tool_Click( object sender, EventArgs e )
        {
            R_Frmhuaxuepinruku ku = new R_Frmhuaxuepinruku(this);
            ku.StartPosition = FormStartPosition.CenterScreen;
            ku.Show();
        }
        private void r347Tool_Click( object sender, EventArgs e )
        {
            R_Frmsuliaobuqitacontract sli = new R_Frmsuliaobuqitacontract( );
            sli.MdiParent = this;
            sli.StartPosition = FormStartPosition.CenterScreen;
            sli.Show( );
        }
        private void r349Tool_Click( object sender, EventArgs e )
        {
            R_Frmwaixiancontract wx = new R_Frmwaixiancontract( );
            wx.MdiParent = this;
            wx.StartPosition = FormStartPosition.CenterScreen;
            wx.Show();
        }
        private void guanTool_Click( object sender, EventArgs e )
        {
            Guanyu gy = new Guanyu(this);
            gy.StartPosition = FormStartPosition.CenterScreen;
            gy.Show();
        }
        private void ExitTool_Click( object sender, EventArgs e )
        {
            if (MessageBox.Show("确认退出?", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
                this.Dispose();
            }
        }
        private void PowerTool_Click( object sender, EventArgs e )
        {
            Power pw = new Power(this);
            pw.MdiParent = this;
            pw.StartPosition = FormStartPosition.CenterScreen;
            pw.Show();
        }
        private void ToolReview_Click( object sender, EventArgs e )
        {
            Review re = new Review(this);
            re.StartPosition = FormStartPosition.CenterScreen;
            re.Show();
        }
        protected override void OnClosing ( CancelEventArgs e )
        {
            if ( MessageBox.Show( this ,"确认退出" ,"提示信息：" ,MessageBoxButtons.YesNo ,MessageBoxIcon.Question ) == DialogResult.Yes )
                e.Cancel = false;//Cancel为false，说明不取消窗口关闭操作，所以窗口关闭
            else
                e.Cancel = true;
        }
        private void RegeditTool_Click( object sender, EventArgs e )
        {
            //System.Diagnostics.Process.Start( System.Reflection.Assembly.GetExecutingAssembly( ).Location );//Restart application
            Application.Restart( );
        }
        private void ProductTool_Click( object sender, EventArgs e )
        {
            R_FrmProductBom pm = new R_FrmProductBom( this );
            pm.StartPosition = FormStartPosition.CenterScreen;
            pm.Show( );
        }
        private void PartTool_Click( object sender, EventArgs e )
        {
            R_FrmPartBom pr = new R_FrmPartBom( this );
            pr.StartPosition = FormStartPosition.CenterScreen;
            pr.Show( );
        }
        private void MaterialTool_Click( object sender, EventArgs e )
        {
            R_FrmMaterialBom ml = new R_FrmMaterialBom( this );
            ml.StartPosition = FormStartPosition.CenterScreen;
            ml.Show( );
        }
        private void R285Tool_Click( object sender, EventArgs e )
        {
            R_Frmhuaxuepicichenben hen = new R_Frmhuaxuepicichenben(  );
            hen.MdiParent = this;
            hen.StartPosition = FormStartPosition.CenterScreen;
            hen.Show( );
        }
        private void r195Tool_Click( object sender, EventArgs e )
        {
            R_Frmchanpinzhibiao zbo = new R_Frmchanpinzhibiao( );
            zbo.MdiParent = this;
            zbo.StartPosition = FormStartPosition.CenterScreen;
            zbo.Show( );
        }
        private void r341Tool_Click( object sender, EventArgs e )
        {
            R_FrmmucaiContract mca = new R_FrmmucaiContract( );
            mca.StartPosition = FormStartPosition.CenterScreen;
            mca.MdiParent = this;
            mca.Show( );
        }
        private void r046Tool_Click( object sender, EventArgs e )
        {
            R_Frmshenchanjindujihua scj = new R_Frmshenchanjindujihua ( );
            scj.MdiParent = this;
            scj.StartPosition = FormStartPosition.CenterScreen;
            scj.Show( );
        }
        private void r340Tool_Click( object sender, EventArgs e )
        {
            R_FrmWuJinContract syi = new R_FrmWuJinContract(  );
            syi.MdiParent = this;
            syi.StartPosition = FormStartPosition.CenterScreen;
            syi.Show( );
        }
        private void saleTool_Click_1( object sender, EventArgs e )
        {
            R_FrmSailes fs = new R_FrmSailes(  );
            fs.MdiParent = this;
            fs.StartPosition = FormStartPosition.CenterScreen;
            fs.Show( );
        }
        private void pwTool_Click( object sender, EventArgs e )
        {
            PassWords pw = new PassWords( );
            pw.StartPosition = FormStartPosition.CenterScreen;
            pw.Show( );
        }
        private void r501Tool_Click( object sender, EventArgs e )
        {
            R_Frmzuzhanggongzikaohe zuzhu = new R_Frmzuzhanggongzikaohe(  );
            zuzhu.MdiParent = this;
            zuzhu.StartPosition = FormStartPosition.CenterScreen;
            zuzhu.Show( );
        }
        private void r502Tool_Click( object sender, EventArgs e )
        {
            Frmzuzhanggongzikaohehd hd = new Frmzuzhanggongzikaohehd(  );
            hd.MdiParent = this;
            hd.StartPosition = FormStartPosition.CenterScreen;
            hd.Show( );
        }
        private void r503Tool_Click( object sender, EventArgs e )
        {
            R_Frmchejianzhurenkaohe cjz = new R_Frmchejianzhurenkaohe( );
            cjz.MdiParent = this;
            cjz.StartPosition = FormStartPosition.CenterScreen;
            cjz.Show( );
        }
        private void BOMTool_Click ( object sender , EventArgs e )
        {
            R_FrmgongxuBom gxb = new R_FrmgongxuBom ( this );
            gxb. StartPosition = FormStartPosition. CenterScreen;
            gxb. Show ( );
        }
        private void r464Tool_Click ( object sender ,EventArgs e )
        {
            R_FrmInventoryProcurement ip = new R_FrmInventoryProcurement( this );
            ip.StartPosition = FormStartPosition.CenterScreen;
            ip.Show( );
        }
        private void r241Tool_Click ( object sender ,EventArgs e )
        {
            R_FrmProductCostSummary cost = new R_FrmProductCostSummary( );
            cost.MdiParent = this;
            cost.StartPosition = FormStartPosition.CenterScreen;
            cost.Show( );
        }
        private void r250Tool_Click ( object sender ,EventArgs e )
        {
            R_FrmDailyCollectionRecord record = new R_FrmDailyCollectionRecord( );
            record.MdiParent = this;
            record.StartPosition = FormStartPosition.CenterScreen;
            record.Show( );
        }
        private void r412Tool_Click ( object sender ,EventArgs e )
        {
            R_FrmCheMuJianContract cmj = new R_FrmCheMuJianContract(  );
            cmj.MdiParent = this;
            cmj.StartPosition = FormStartPosition.CenterScreen;
            cmj.Show( );
        }
        private void r266Tool_Click ( object sender ,EventArgs e )
        {
            R_FrmDailyUseOfChemicals duc = new R_FrmDailyUseOfChemicals( this );
            duc.StartPosition = FormStartPosition.CenterScreen;
            duc.Show( );
        }
        private void r196Tool_Click ( object sender ,EventArgs e )
        {
            R_FrmSiReYiYinContract syy = new R_FrmSiReYiYinContract(  );
            syy.MdiParent = this;
            syy.StartPosition = FormStartPosition.CenterScreen;
            syy.Show( );
        }
        private void r525Tool_Click ( object sender ,EventArgs e )
        {
            R_FrmBatchNumManagement bn = new R_FrmBatchNumManagement( this );
            bn.StartPosition = FormStartPosition.CenterScreen;
            bn.Show( );
        }
        private void r526Tool_Click ( object sender ,EventArgs e )
        {
            R_FrmCheckOut cou = new R_FrmCheckOut( );
            cou.MdiParent = this;
            cou.StartPosition = FormStartPosition.CenterScreen;
            cou.Show( );
        }
        private void r240Tool_Click ( object sender ,EventArgs e )
        {
            R_FrmChengBenYuHeSuanAll cheBen = new R_FrmChengBenYuHeSuanAll( );
            cheBen.MdiParent = this;
            cheBen.StartPosition = FormStartPosition.CenterScreen;
            cheBen.Show( );
        }
        private void R323Tool_Click ( object sender ,EventArgs e )
        {
            FrmGongZiCe gzc = new FrmGongZiCe( );
            gzc.MdiParent = this;
            gzc.StartPosition = FormStartPosition.CenterScreen;
            gzc.Show( );
        }
        private void r527Tool_Click ( object sender ,EventArgs e )
        {
            ChanPinGongZiKaoQinReport cpRe = new ChanPinGongZiKaoQinReport( );
            cpRe.MdiParent = this;
            cpRe.StartPosition = FormStartPosition.CenterScreen;
            cpRe.Show( );
        }
        private void ToolRemain_Click ( object sender ,EventArgs e )
        {
            Remind reM = new Remind( this );
            reM.StartPosition = FormStartPosition.CenterScreen;
            reM.MdiParent = this;
            reM.Show( );
        }
        private void r225Tool_Click ( object sender ,EventArgs e )
        {
            R_FrmChanPinGongZiKaoQinHuiZong cphz = new R_FrmChanPinGongZiKaoQinHuiZong( );
            cphz.StartPosition = FormStartPosition.CenterScreen;
            cphz.MdiParent = this;
            cphz.Show( );
        }
        private void r505Tool_Click ( object sender ,EventArgs e )
        {
            R_FrmDuanLiaoContract duan = new R_FrmDuanLiaoContract( );
            duan.StartPosition = FormStartPosition.CenterScreen;
            duan.MdiParent = this;
            duan.Show( );
        }
        private void r047Tool_Click ( object sender ,EventArgs e )
        {
            R_FrmJiaoMiDuJunHenTable jun = new R_FrmJiaoMiDuJunHenTable( );
            jun.StartPosition = FormStartPosition.CenterScreen;
            jun.MdiParent = this;
            jun.Show( );
        }
        private void r345Tool_Click ( object sender ,EventArgs e )
        {
            GunqiChengLanJiaGong jc = new GunqiChengLanJiaGong( );
            jc.StartPosition = FormStartPosition.CenterScreen;
            jc.MdiParent = this;
            jc.Show( );
        }
        private void r340Tool_Click_1 ( object sender ,EventArgs e )
        {
            R_FrmGunQiContrract gq = new R_FrmGunQiContrract( );
            gq.MdiParent = this;
            gq.Show( );
        }
        private void r337Tool_Click ( object sender ,EventArgs e )
        {
            R_FrmYouQiPlanContract yqp = new R_FrmYouQiPlanContract( );
            yqp.MdiParent = this;
            yqp.Show( );
        }
        private void r500Tool_Click ( object sender ,EventArgs e )
        {
            SailsPaymentTaxRefundAndElectricityBill seb = new SailsPaymentTaxRefundAndElectricityBill( );
            seb.MdiParent = this;
            seb.Show( );
        }
        private void r348Tool_Click ( object sender ,EventArgs e )
        {
            R_FrmWaiXian wx = new R_FrmWaiXian( );
            wx.MdiParent = this;
            wx.Show( );
        }
        private void r346Tool_Click ( object sender ,EventArgs e )
        {
            R_FrmGunQiChenBen gq = new R_FrmGunQiChenBen( );
            gq.MdiParent = this;
            gq.Show( );
        }
        private void r251Tool_Click ( object sender ,EventArgs e )
        {
            R_FrmContractUncollectUnpaid un = new R_FrmContractUncollectUnpaid( );
            un.MdiParent = this;
            un.Show( );
        }
        private void r324Tool_Click ( object sender ,EventArgs e )
        {
            R_FrmWorkWages wa = new R_FrmWorkWages( );
            wa.MdiParent = this;
            wa.Show( );
        }
        private void r468Tool_Click ( object sender ,EventArgs e )
        {
            R_FrmTargetActualWarn tw = new R_FrmTargetActualWarn( );
            tw.MdiParent = this;
            tw.Show( );
        }
        private void r325Tool_Click ( object sender ,EventArgs e )
        {
            R_FrmWagesCostComparison wac = new R_FrmWagesCostComparison( );
            wac.MdiParent = this;
            wac.Show( );
        }
        private void r326Tool_Click ( object sender ,EventArgs e )
        {
            R_FrmWagesContrastTable wa = new R_FrmWagesContrastTable( );
            wa.MdiParent = this;
            wa.Show( );
        }
        private void r351Tool_Click ( object sender ,EventArgs e )
        {
            R_FrmTeamLeaderRoutineCheck tlr = new R_FrmTeamLeaderRoutineCheck( );
            tlr.MdiParent = this;
            tlr.Show( );
        }
        private void r244Tool_Click ( object sender ,EventArgs e )
        {
            R_FrmDetailedDeduction de = new R_FrmDetailedDeduction( );
            de.MdiParent = this;
            de.Show( );
        }
        private void r050Tool_Click ( object sender ,EventArgs e )
        {
            R_FrmManagePayroll mp = new R_FrmManagePayroll( );
            mp.MdiParent = this;
            mp.Show( );
        }
        private void Tool_Click ( object sender ,EventArgs e )
        {
            R_FrmZuZhangBom zu = new R_FrmZuZhangBom( );
            zu.MdiParent = this;
            zu.Show( );
        }
        private void r231Tool_Click ( object sender ,EventArgs e )
        {
            R_FrmPayMent pm = new R_FrmPayMent( );
            pm.MdiParent = this;
            pm.Show( );
        }
        private void r512Tool_Click ( object sender ,EventArgs e )
        {
            R_FrmCostIndex ci = new R_FrmCostIndex( );
            ci.MdiParent = this;
            ci.Show( );
        }
        private void r252Tool_Click ( object sender ,EventArgs e )
        {
            R_FrmMaterialPurchaseCompariase mp = new R_FrmMaterialPurchaseCompariase( );
            mp.MdiParent = this;
            mp.Show( );
        }
        private void r199Tool_Click ( object sender ,EventArgs e )
        {
            R_FrmContractToDoAJob aj = new R_FrmContractToDoAJob( );
            aj.MdiParent = this;
            aj.Show( );
        }
        private void r364Tool_Click ( object sender ,EventArgs e )
        {
            R_FrmQualityTesting qt = new R_FrmQualityTesting( );
            qt.MdiParent = this;
            qt.Show( );
        }
        private void r365Tool_Click ( object sender ,EventArgs e )
        {
            R_FrmProductQuality pq = new R_FrmProductQuality( );
            pq.MdiParent = this;
            pq.Show( );
        }
        private void R243Tool_Click ( object sender ,EventArgs e )
        {
            R_FrmOtherExpenseStatement es = new R_FrmOtherExpenseStatement( );
            es.MdiParent = this;
            es.Show( );
        }
        private void rToolStripMenuItem_Click ( object sender ,EventArgs e )
        {
            R_FrmSystemDrity sd = new R_FrmSystemDrity( );
            sd.MdiParent = this;
            sd.Show( );
        }
        private void r480ToolStrip_Click ( object sender ,EventArgs e )
        {
            R_Frmyanpinchangqiancehua yc = new R_Frmyanpinchangqiancehua( );
            yc.MdiParent = this;
            yc.Show( );
        }
        private void r002Tool_Click ( object sender ,EventArgs e )
        {
            ReadyOfNum rn = new ReadyOfNum( );
            rn.MdiParent = this;
            rn.Show( );
        }
        private void r300Tool_Click ( object sender , EventArgs e )
        {
            MaterialProcurementSummary mate = new MaterialProcurementSummary ( );
            mate . MdiParent = this;
            mate . Show ( );
        }
        private void R301MenuItem_Click ( object sender ,EventArgs e )
        {
            FormWarehouseReceipt wr = new FormWarehouseReceipt ( );
            wr . MdiParent = this;
            wr . Show ( );
        }
        private void R376ToolPeragg_Click ( object sender ,EventArgs e )
        {
            FormPeragg wr = new FormPeragg ( );
            wr . MdiParent = this;
            wr . Show ( );
        }
        private void R457Tool_Click ( object sender ,EventArgs e )
        {
            Form aps = new FormAnnualPayrollSummary ( );
            aps . MdiParent = this;
            aps . Show ( );
        }
        private void R458Tool_Click ( object sender ,EventArgs e )
        {
            Form pfa = new FormPerformanceAppraisal ( );
            pfa . MdiParent = this;
            pfa . Show ( );
        }
        private void r318Tool_Click ( object sender ,EventArgs e )
        {
            Form pfa = new FormUserChange ( );
            pfa . MdiParent = this;
            pfa . Show ( );
        }
        private void r482Tool_Click ( object sender ,EventArgs e )
        {
            Form pfa = new FormStandardAuditOne ( );
            pfa . MdiParent = this;
            pfa . Show ( );
        }
        private void r483Tool_Click ( object sender ,EventArgs e )
        {
            Form pfa = new FormStandardAuditTwo ( );
            pfa . MdiParent = this;
            pfa . Show ( );
        }
        private void r484Tool_Click ( object sender ,EventArgs e )
        {
            Form pfa = new FormStandardAuditTre ( );
            pfa . MdiParent = this;
            pfa . Show ( );
        }
        private void r489Tool_Click ( object sender ,EventArgs e )
        {
            Form pfa = new FormStandardAuditFiv ( );
            pfa . MdiParent = this;
            pfa . Show ( );
        }
        private void r487Tool_Click ( object sender ,EventArgs e )
        {
            Form pfa = new FormStandardAuditFor ( );
            pfa . MdiParent = this;
            pfa . Show ( );
        }
        private void r043Tool_Click ( object sender ,EventArgs e )
        {
            Form pfa = new FormStandardTest ( );
            pfa . MdiParent = this;
            pfa . Show ( );
        }
        private void r044Tool_Click ( object sender ,EventArgs e )
        {
            Form pfa = new FormFeedTest ( );
            pfa . MdiParent = this;
            pfa . Show ( );
        }
        private void r418Tool_Click ( object sender ,EventArgs e )
        {
            Form pfa = new FormTestResultRecord ( );
            pfa . MdiParent = this;
            pfa . Show ( );
        }
        private void r368Tool_Click ( object sender ,EventArgs e )
        {
            Form pfa = new FormTestResultRecordOne ( );
            pfa . MdiParent = this;
            pfa . Show ( );
        }
        private void r142Tool_Click ( object sender ,EventArgs e )
        {
            Form pfa = new FormTestReportForAQ ( );
            pfa . MdiParent = this;
            pfa . Show ( );
        }
        private void r429Tool_Click ( object sender ,EventArgs e )
        {
            Form pfa = new FormSafetyManegerAndControl ( );
            pfa . MdiParent = this;
            pfa . Show ( );
        }
        private void r366Tool_Click ( object sender ,EventArgs e )
        {
            Form pfa = new FormProductSpecification ( );
            pfa . MdiParent = this;
            pfa . Show ( );
        }
        private void r101Tool_Click ( object sender ,EventArgs e )
        {
            Form pfa = new FormQualityFinalInspsction ( );
            pfa . MdiParent = this;
            pfa . Show ( );
        }
        private void r293Tool_Click ( object sender ,EventArgs e )
        {
            Form pfa = new FormQualityReport ( );
            pfa . MdiParent = this;
            pfa . Show ( );
        }
        private void r473Tool_Click ( object sender ,EventArgs e )
        {
            Form pfa = new FormCustomerInspectionTable ( );
            pfa . MdiParent = this;
            pfa . Show ( );
        }
        private void r513Tool_Click ( object sender ,EventArgs e )
        {
            Form pfa = new FormContCheckTable ( );
            pfa . MdiParent = this;
            pfa . Show ( );
        }
        private void r2411Tool_Click ( object sender ,EventArgs e )
        {
            Form pfa = new FormMaterial ( );
            pfa . MdiParent = this;
            pfa . Show ( );
        }
        private void r261Tool_Click ( object sender ,EventArgs e )
        {
            Form pfa = new FormWages ( );
            pfa . MdiParent = this;
            pfa . Show ( );
        }
        private void r262Tool_Click ( object sender ,EventArgs e )
        {
            Form pfa = new FormPaint ( );
            pfa . MdiParent = this;
            pfa . Show ( );
        }
        private void r046ToolY_Click ( object sender ,EventArgs e )
        {
            Form pfa = new ChartControl2 ( );
            pfa . MdiParent = this;
            pfa . Show ( );
        }
        private void r003Tool_Click ( object sender ,EventArgs e )
        {
            Form pfa = new FormUserInfo ( );
            pfa . MdiParent = this;
            pfa . Show ( );
        }
        private void R049Tool_Click ( object sender ,EventArgs e )
        {
            Form pfa = new FormPurchaseDelaySummary ( );
            pfa . MdiParent = this;
            pfa . Show ( );
        }
        private void R051Tool_Click ( object sender ,EventArgs e )
        {
            Form pfa = new FormProcessingDelay ( );
            pfa . MdiParent = this;
            pfa . Show ( );
        }
        private void r504tool_Click ( object sender ,EventArgs e )
        {
            FormQuotation form = new FormQuotation ( );
            form . MdiParent = this;
            form . Show ( );
        }
        private void r004Tool_Click ( object sender ,EventArgs e )
        {
            FormSanitationCheck from = new FormSanitationCheck ( );
            from . MdiParent = this;
            from . Show ( );
        }
        private void r004Tools_Click ( object sender ,EventArgs e )
        {
            FormSanitationBroad from = new FormSanitationBroad ( );
            //from . MdiParent = this;
            from . WindowState = FormWindowState . Maximized;
            from . Show ( );
        }
        private void r048Tool_Click_1 ( object sender ,EventArgs e )
        {
            Form pfa = new R_FrmshenchanjindujihuaReport ( );
            //pfa . MdiParent = this;
            pfa . WindowState = FormWindowState . Maximized;
            pfa . Show ( );
        }
        private void R465ToolS_Click ( object sender ,EventArgs e )
        {
            Form pfa = new FormInvenAdSheet ( );
            pfa . MdiParent = this;
            //pfa . WindowState = FormWindowState . Maximized;
            pfa . Show ( );
        }
    }
}


/*

CREATE TRIGGER checkOutContract
ON R_PQAK
FOR INSERT,UPDATE
AS
BEGIN
--195
WITH CET AS (SELECT CP01,CP03,SUM(CASE WHEN CP10=0 THEN CP11*CP13*CP54-CP12 WHEN CP11=0 THEN CP10*CP13*CP54-CP12 ELSE CP10*CP13*CP54-CP12 END)-ISNULL(AK011,0) U2 FROM R_PQQ A LEFT JOIN (SELECT AK002,AK003,SUM(ISNULL(AK011,0)) AK011 FROM R_PQAK WHERE AK003 LIKE 'R_195%' GROUP BY AK002,AK003) B ON A.CP01=B.AK002 AND A.CP03=B.AK003 GROUP BY  CP01,CP03,ISNULL(AK011,0)) 
UPDATE R_PQQ SET CP63=CASE WHEN U2<=10 AND U2>=-10 THEN '已结' ELSE '未结' END FROM CET B WHERE R_PQQ.CP01=B.CP01 AND R_PQQ.CP03=B.CP03
END
BEGIN
--196
WITH CET AS (SELECT AH01,AH97,SUM(AH16*AH101*AH13*AH14)-ISNULL(AK011,0) U2 FROM R_PQAH A LEFT JOIN (SELECT AK002,AK003,SUM(ISNULL(AK011,0)) AK011 FROM R_PQAK WHERE AK003 LIKE 'R_196%' GROUP BY AK002,AK003) B ON A.AH01=B.AK002 AND A.AH97=B.AK003 GROUP BY AH01,AH97,ISNULL(AK011,0))  UPDATE R_PQAH SET AH118=CASE WHEN U2<=10 AND U2>=-10 THEN '已结' ELSE '未结' END FROM CET B WHERE R_PQAH.AH97=B.AH97 AND R_PQAH.AH01=B.AH01
END
BEGIN
--199
WITH CET AS (
SELECT BA003,BA001,SUM(BA054*BA013)-ISNULL(AK011,0) U2 FROM R_PQBA A LEFT JOIN (SELECT AK002,AK003,SUM(ISNULL(AK011,0)) AK011 FROM R_PQAK WHERE AK003 LIKE 'R_199%' GROUP BY AK002,AK003) B ON A.BA003=B.AK003 AND A.BA001=B.AK002 GROUP BY  BA003,BA001,ISNULL(AK011,0)
) 
UPDATE R_PQBA SET BA063=CASE WHEN U2<=10 AND U2>=-10 THEN '已结' ELSE '未结' END FROM CET B WHERE R_PQBA.BA003=B.BA003 AND R_PQBA.BA001=B.BA001

END
BEGIN
--337
WITH CET AS (
SELECT YQ99,SUM(YQ109*YQ15)-ISNULL(AK011,0) U2 FROM R_PQI A LEFT JOIN (SELECT AK002,AK003,SUM(ISNULL(AK011,0)) AK011 FROM R_PQAK WHERE AK003 LIKE 'R_337%' GROUP BY AK002,AK003) B ON A.YQ99=B.AK003  GROUP BY  YQ99,ISNULL(AK011,0)
) 
UPDATE R_PQI SET YQ140=CASE WHEN B.U2<=10 AND B.U2>=-10 THEN '已结' ELSE '未结' END FROM CET B WHERE R_PQI.YQ99=B.YQ99 AND R_PQI.YQ99 LIKE 'R_337%'
END
BEGIN
--338
WITH CET AS (
SELECT JM01,JM90,SUM(JM103/JM10*JM11)-ISNULL(AK011,0) U2 FROM R_PQO A LEFT JOIN (SELECT AK002,AK003,SUM(ISNULL(AK011,0)) AK011 FROM R_PQAK WHERE AK003 LIKE 'R_338%' GROUP BY AK002,AK003) B ON A.JM01=B.AK003 AND A.JM90=B.AK002 WHERE A.JM90!='' AND A.JM90 IS NOT NULL GROUP BY JM01,JM90,ISNULL(AK011,0)
) 
UPDATE R_PQO SET JM117=CASE WHEN U2<=10 AND U2>=-10 THEN '已结' ELSE '未结' END FROM CET B WHERE R_PQO.JM01=B.JM01 AND R_PQO.JM90=B.JM90
END
BEGIN
--338
WITH CET AS (
SELECT JM01,SUM(JM103/JM10*JM11)-ISNULL(AK011,0) U2 FROM R_PQO A LEFT JOIN (SELECT AK002,AK003,SUM(ISNULL(AK011,0)) AK011 FROM R_PQAK WHERE AK003 LIKE 'R_338%' GROUP BY AK002,AK003) B ON A.JM01=B.AK003 WHERE (A.JM90='' OR A.JM90 IS NULL) GROUP BY JM01,ISNULL(AK011,0)
) 
UPDATE R_PQO SET JM117=CASE WHEN U2<=10 AND U2>=-10 THEN '已结' ELSE '未结' END FROM CET B WHERE R_PQO.JM01=B.JM01
END
BEGIN
--339
WITH CET AS (
SELECT YQ99,YQ03,SUM(YQ16*YQ108*YQ112*YQ114*YQ115*YQ116*YQ113*0.0001*YQ13*0.01+YQ108*YQ112*YQ116*YQ113*YQ13*YQ14*0.01/YQ114/YQ115)-ISNULL(AK011,0) U2 FROM R_PQI A LEFT JOIN (SELECT AK002,AK003,SUM(ISNULL(AK011,0)) AK011 FROM R_PQAK WHERE AK003 LIKE 'R_339%' GROUP BY AK002,AK003) B ON A.YQ99=B.AK003 AND A.YQ03=B.AK002 GROUP BY YQ99,YQ03,ISNULL(AK011,0)
) 
UPDATE R_PQI SET YQ140=CASE WHEN B.U2<=10 AND B.U2>=-10 THEN '已结' ELSE '未结' END FROM CET B WHERE R_PQI.YQ03=B.YQ03 AND R_PQI.YQ99=B.YQ99 AND R_PQI.YQ99 LIKE 'R_339%'
END
BEGIN
--341
WITH CET AS (
SELECT PQV76,PQV01,SUM(PQV11*PQV66*PQV81*PQV67*PQV13)-ISNULL(AK011,0) U2 FROM R_PQV A LEFT JOIN (SELECT AK002,AK003,SUM(ISNULL(AK011,0)) AK011 FROM R_PQAK WHERE AK003 LIKE 'R_341%' GROUP BY AK002,AK003) B ON A.PQV76=B.AK003 AND A.PQV01=B.AK002 WHERE A.PQV01!='' AND A.PQV01 IS NOT NULL GROUP BY  PQV76,PQV01,ISNULL(AK011,0)
) 
UPDATE R_PQV SET PQV99=CASE WHEN U2<=10 AND U2>=-10 THEN '已结' ELSE '未结' END FROM CET B WHERE R_PQV.PQV76=B.PQV76 AND R_PQV.PQV01=B.PQV01
END
BEGIN
--341
WITH CET AS (
SELECT PQV76,SUM(PQV11*PQV66*PQV81*PQV67*PQV13)-ISNULL(AK011,0) U2 FROM R_PQV A LEFT JOIN (SELECT AK002,AK003,SUM(ISNULL(AK011,0)) AK011 FROM R_PQAK WHERE AK003 LIKE 'R_341%' GROUP BY AK002,AK003) B ON A.PQV76=B.AK003 WHERE (A.PQV01='' OR A.PQV01 IS NULL) GROUP BY  PQV76,ISNULL(AK011,0)
) 
UPDATE R_PQV SET PQV99=CASE WHEN U2<=10 AND U2>=-10 THEN '已结' ELSE '未结' END FROM CET B WHERE R_PQV.PQV76=B.PQV76
END
BEGIN
--342
WITH CET AS (
SELECT AF001,AF002,SUM(AF023*AF006*AF019)-ISNULL(AK011,0) U2 FROM R_PQAF A LEFT JOIN (SELECT AK002,AK003,SUM(ISNULL(AK011,0)) AK011 FROM R_PQAK WHERE AK003 LIKE 'R_342%' GROUP BY AK002,AK003) B ON A.AF001=B.AK003 AND A.AF002=B.AK002 WHERE A.AF002!='' AND A.AF002 IS NOT NULL GROUP BY AF001,AF002,ISNULL(AK011,0)
) 
UPDATE R_PQAF SET AF090=CASE WHEN U2<=10 AND U2>=-10 THEN '已结' ELSE '未结' END FROM CET B WHERE R_PQAF.AF001=B.AF001 AND R_PQAF.AF002=B.AF002
END
BEGIN
--342
WITH CET AS (
SELECT AF001,SUM(AF023*AF006*AF019)-ISNULL(AK011,0) U2 FROM R_PQAF A LEFT JOIN (SELECT AK002,AK003,SUM(ISNULL(AK011,0)) AK011 FROM R_PQAK WHERE AK003 LIKE 'R_342%' GROUP BY AK002,AK003) B ON A.AF001=B.AK003 WHERE (A.AF002='' OR A.AF002 IS NULL) GROUP BY AF001,AF002,ISNULL(AK011,0)
) 
UPDATE R_PQAF SET AF090=CASE WHEN U2<=10 AND U2>=-10 THEN '已结' ELSE '未结' END FROM CET B WHERE R_PQAF.AF001=B.AF001
END
BEGIN
--343
WITH CET AS (
SELECT PQU97,PQU01,SUM(PQU16*(PQU13*PQU101+PQU14))-ISNULL(AK011,0) U2 FROM R_PQU A LEFT JOIN (SELECT AK002,AK003,SUM(ISNULL(AK011,0)) AK011 FROM R_PQAK WHERE AK003 LIKE 'R_343%' GROUP BY AK002,AK003) B ON A.PQU97=B.AK003 AND A.PQU01=B.AK002 WHERE A.PQU01!='' AND A.PQU01 IS NOT NULL GROUP BY  PQU97,PQU01,ISNULL(AK011,0)
) 
UPDATE R_PQU SET PQU116=CASE WHEN U2<=10 AND U2>=-10 THEN '已结' ELSE '未结' END FROM CET B WHERE R_PQU.PQU97=B.PQU97 AND R_PQU.PQU01=B.PQU01
END
BEGIN
--343
WITH CET AS (
SELECT PQU97,SUM(PQU16*(PQU13*PQU101+PQU14))-ISNULL(AK011,0) U2 FROM R_PQU A LEFT JOIN (SELECT AK002,AK003,SUM(ISNULL(AK011,0)) AK011 FROM R_PQAK WHERE AK003 LIKE 'R_343%' GROUP BY AK002,AK003) B ON A.PQU97=B.AK003 WHERE (A.PQU01='' OR A.PQU01 IS NULL) GROUP BY  PQU97,ISNULL(AK011,0)
) 
UPDATE R_PQU SET PQU116=CASE WHEN U2<=10 AND U2>=-10 THEN '已结' ELSE '未结' END FROM CET B WHERE R_PQU.PQU97=B.PQU97 
END
BEGIN
--344
WITH CET AS (
SELECT MZ001,MZ002,SUM(CASE WHEN MZ107='厂内' THEN MZ022*MZ006*MZ027+ISNULL(MZ118,0) ELSE 0 END+CASE WHEN MZ107='厂外' THEN ISNULL(MZ120,0)+MZ022*MZ006*MZ028*MZ024 ELSE 0 END)-ISNULL(AK011,0) U2 FROM R_PQMZ A LEFT JOIN (SELECT AK002,AK003,SUM(ISNULL(AK011,0)) AK011 FROM R_PQAK WHERE AK003 LIKE 'R_344%' GROUP BY AK002,AK003) B ON A.MZ001=B.AK003 AND A.MZ002=B.AK002 GROUP BY  MZ001,MZ002,ISNULL(AK011,0)
) 
UPDATE R_PQMZ SET MZ129=CASE WHEN U2<=10 AND U2>=-10 THEN '已结' ELSE '未结' END FROM CET B WHERE R_PQMZ.MZ001=B.MZ001 AND R_PQMZ.MZ002=B.MZ002
END
BEGIN
--347
WITH CET AS (
SELECT PJ92,PJ01,SUM(PJ12*(PJ11*PJ96+PJ10))-ISNULL(AK011,0) U2 FROM R_PQS A LEFT JOIN (SELECT AK002,AK003,SUM(ISNULL(AK011,0)) AK011 FROM R_PQAK WHERE AK003 LIKE 'R_347%' GROUP BY AK002,AK003) B ON A.PJ92=B.AK003 AND A.PJ01=B.AK002 GROUP BY  PJ92,PJ01,ISNULL(AK011,0)
) 
UPDATE R_PQS SET PJ110=CASE WHEN U2<=10 AND U2>=-10 THEN '已结' ELSE '未结' END FROM CET B WHERE R_PQS.PJ92=B.PJ92 AND R_PQS.PJ01=B.PJ01
END
BEGIN
--349
WITH CET AS (
SELECT WX82,WX01,SUM(CASE WHEN WX10='双瓦外箱' THEN ((WX27 + WX28 + WX29) * (WX30 + WX31 + WX32) + (WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15 WHEN WX10='小箱式' THEN ((WX27 + WX28 + WX29) * (WX30 + WX31 + WX32) + (WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15 WHEN WX10='牙膏式' THEN ((WX27 + 2*WX28 + WX29) * (2*WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15  WHEN WX10='插口式' THEN ((WX27 + 2*WX28 + WX29) * (2*WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10='天盖' THEN  ((WX27 + 2*WX28 + WX29) * (WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15  WHEN WX10='地盖' THEN ((WX27 + 2*WX28 + WX29) * (WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15  WHEN WX10='折叠式' THEN ((2*WX27 + 2*WX28 + WX29) * (1.5*WX30 + WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10 NOT IN ('双瓦外箱','小箱式','牙膏式','插口式','天盖','地盖','折叠式') THEN (WX23 + WX24) * (WX25 + WX26) * 0.0001 * WX13* WX15 END)-ISNULL(AK011,0) U2 FROM R_PQT A LEFT JOIN (SELECT AK002,AK003,SUM(ISNULL(AK011,0)) AK011 FROM R_PQAK WHERE AK003 LIKE 'R_349%' GROUP BY AK002,AK003) B ON A.WX82=B.AK003 AND A.WX01=B.AK002 GROUP BY  WX82,WX01,ISNULL(AK011,0)
) 
UPDATE R_PQT SET WX97=CASE WHEN B.U2<=10 AND B.U2>=-10 THEN '已结' ELSE '未结' END FROM CET B WHERE R_PQT.WX82=B.WX82 AND R_PQT.WX01=B.WX01
END
BEGIN
--495
WITH CET AS (
SELECT PY33,PY01,SUM(PY23*PY14*PY18*PY11*PY10*PY12*PY15*0.0001+CASE WHEN PY14 = 0 OR PY18 = 0 OR PY21 = 0 THEN 0 WHEN PY14 != 0 AND PY18 != 0 AND PY21 != 0 THEN (PY10*PY11*PY15*PY12*PY20/PY21/PY14/PY18+PY13*PY19*PY16*PY10*PY11/PY14/PY18/PY21/2)*(1+PY17/100) END)-ISNULL(AK011,0) U2 FROM R_PQY A LEFT JOIN (SELECT AK002,AK003,SUM(ISNULL(AK011,0)) AK011 FROM R_PQAK WHERE AK003 LIKE 'R_495%' GROUP BY AK002,AK003) B ON A.PY33=B.AK003 AND A.PY01=B.AK002 GROUP BY  PY33,PY01,ISNULL(AK011,0)
) 
UPDATE R_PQY SET PY46=CASE WHEN U2<=10 AND U2>=-10 THEN '已结' ELSE '未结' END FROM CET B WHERE R_PQY.PY33=B.PY33 AND R_PQY.PY01=B.PY01
END
BEGIN
--505
WITH CET AS (
SELECT IZ001,IZ002,SUM(CASE WHEN IZ021=0 THEN 0 ELSE (IZ005*IZ022/IZ021)*(IZ013*(IZ014+IZ015)*2*IZ016) END)-ISNULL(AK011,0) U2 FROM R_PQIZ A LEFT JOIN (SELECT AK002,AK003,SUM(ISNULL(AK011,0)) AK011 FROM R_PQAK WHERE AK003 LIKE 'R_505%' GROUP BY AK002,AK003) B ON A.IZ001=B.AK003 AND A.IZ002=B.AK002 GROUP BY  IZ001,IZ002,ISNULL(AK011,0)
) 
UPDATE R_PQIZ SET IZ038=CASE WHEN U2<=10 AND U2>=-10 THEN '已结' ELSE '未结' END FROM CET B WHERE R_PQIZ.IZ001=B.IZ001 AND R_PQIZ.IZ002=B.IZ002
END
     */




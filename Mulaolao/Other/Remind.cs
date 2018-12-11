using System;
using System . Data;
using System . Windows . Forms;
using StudentMgr;
using System . Reflection;
using Mulaolao . Class;
using System . Text;
using System . Data . SqlClient;
using System . Threading . Tasks;
using System . Collections . Generic;

namespace Mulaolao . Other
{
    public partial class Remind : Form
    {
        MulaolaoBll.Bll.RemindBll _bll=null;

        public Remind ( Form1 fm )
        {
            this . MdiParent = fm;
            InitializeComponent ( );

            _bll = new MulaolaoBll . Bll . RemindBll ( );

            GridViewMoHuSelect . SetFilter ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { bandedGridView1 ,bandedGridView2 ,gridView1 ,gridView2 ,gridView10 ,gridView3 ,gridView4 ,gridView5 ,gridView6 ,gridView7 ,gridView8 ,gridView9 } );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { bandedGridView1 ,bandedGridView2 ,gridView1 ,gridView2 ,gridView10 ,gridView3 ,gridView4 ,gridView5 ,gridView6 ,gridView7 ,gridView8 ,gridView9 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        DataTable da;
        
        Form1 fms = new Form1( );
        
        //[DllImport( "user32" )]
        //private static extern bool AnimateWindow( IntPtr hwnd, int dwTime, int dwFlags );
        ////下面是可用的常量，根据不同的动画效果声明自己需要的          
        ////自左向右显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志  
        //private const int AW_HOR_POSITIVE = 0x0001;
        ////自右向左显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志  
        //private const int AW_HOR_NEGATIVE = 0x0002;
        ////自顶向下显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志  
        //private const int AW_VER_POSITIVE = 0x0004;
        ////自下向上显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志该标志  
        //private const int AW_VER_NEGATIVE = 0x0008;
        ////若使用了AW_HIDE标志，则使窗口向内重叠；否则向外扩展
        //private const int AW_CENTER = 0x0010;
        ////隐藏窗口  
        //private const int AW_HIDE = 0x10000;
        ////激活窗口，在使用了AW_HIDE标志后不要使用这个标志  
        //private const int AW_ACTIVE = 0x20000;
        ////使用滑动类型动画效果，默认为滚动动画类型，当使用AW_CENTER标志时，这个标志就被忽略
        //private const int AW_SLIDE = 0x40000;
        ////使用淡入淡出效果 
        //private const int AW_BLEND = 0x80000; 
        
        private void Remind_Load(object sender, EventArgs e)
        {
            label3 . Visible = false;
            if ( gridView1.RowCount > 0 )
                gridView1.FocusedRowHandle = 0;

            int len = label2.Text.Length - 1;
            StringBuilder txt = new StringBuilder( );
            for ( int i = len ; i >= 0 ; i-- )
            {
                txt.Append( label2.Text.Substring( i ,1 ) );
            }
            label2.Text = txt.ToString( );
            //this.label2.TextAlign = MidpointRounding;
            //int x = fms.Right - this.Width;
            //int y = fms.Bottom - this.Height;
            //int x = Screen.PrimaryScreen.WorkingArea.Right - this.Width;
            //int y = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height;
            // this.Location = new Point( x, y );//设置窗体在屏幕右下角显示  
            //AnimateWindow( this.Handle, 1000, AW_SLIDE | AW_ACTIVE | AW_VER_NEGATIVE );

            //DataTable de = SqlHelper.ExecuteDataTable( "SELECT RES01,CX02,DBA002,RES04 FROM R_REVIEWS A,R_MLLCXMC B,TPADBA C WHERE A.RES02=B.CX01 AND A.RES03=C.DBA001 AND DBA001=@DBA001 ",new SqlParameter("@DBA001",Logins.number) );
            //if (de.Rows.Count < 1)
            //{
            //    this.Close( );
            //}
            //else
            //{
            //    textBox1.Text = de.Rows[0]["DBA002"].ToString( );
            //    gridControl1.DataSource = de;
            //}

            da = SqlHelper.ExecuteDataTable( "SELECT CX02,CX03 FROM R_MLLCXMC" );
            pos = 1;

            SqlHelper . ExecuteNonQuery ( "UPDATE R_PQP SET GS73='F' WHERE GS73 IS NULL OR GS73=''" );
            SqlHelper . ExecuteNonQuery ( "UPDATE R_PQP SET GS08=0 WHERE GS08 LIKE '%/%'" );

            Task task = new Task ( UpdateOver );
            task . Start ( );
           
        }
        void UpdateOver ( )
        {
            _bll . UpdateOver ( );
        }
        //根据程序名称打开对应的程序
        private void gridView1_DoubleClick( object sender, EventArgs e )
        {
            Reflected( );
        }
        //获取程序名称
        string processName = "", oddNum = "";
        private void gridView1_Click ( object sender ,EventArgs e )
        {
            if ( gridView1 . RowCount == 1 )
            {
                processName = gridView1 . GetFocusedRowCellValue ( "CX02" ) . ToString ( );
                oddNum = gridView1 . GetFocusedRowCellValue ( "RES06" ) . ToString ( );
            }
        }
        private void gridView1_FocusedRowChanged( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
            if ( e . FocusedRowHandle >= 0 && e . FocusedRowHandle <= gridView1 . RowCount - 1 )
            {
                processName = gridView1 . GetRowCellValue ( e . FocusedRowHandle ,"CX02" ) . ToString ( );
                oddNum = gridView1 . GetFocusedRowCellValue ( "RES06" ) . ToString ( );
            }
        }

        void Reflected ( )
        {
            //1、MDI窗体不能通过反射打开
            //Form doc = ( Form ) Assembly.Load( "Mulaolao" ).CreateInstance( "Mulaolao.Contract.R_FrmmucaiContract" );
            //doc.MdiParent = this.MdiParent;
            //doc.Show( );
            //2、若是在同一个程序集  则
            string path = "";
            if ( processName . Equals ( "木材采购合同(R_341)" ) )
                path = "Mulaolao.Contract.R_FrmmucaiContract";
            else if ( processName == "胶合板、密度板采购合同书(R_338)" )
                path = "Mulaolao.Procedure.R_FrmJiaomiducontract";
            else if ( processName == "油漆（墨）等化学品采购合同书(R_339)" )
                path = "Mulaolao.Procedure.R_Frmyouqimocontract";
            else if ( processName == "车木件采购合同(R_342)" )
                path = "Mulaolao.Contract.R_FrmCheMuJianContract";
            else if ( processName == "五金件(镀、烤漆)采购合同书(R_343)" )
                path = "Mulaolao.Contract.R_FrmWuJinContract";
            else if ( processName == "产品塑料、布和其他零配件采购合同(R_347)" )
                path = "Mulaolao.Contract.R_Frmsuliaobuqitacontract";
            else if ( processName == "外箱、中包、彩盒、纸片（卡）等采购合同(R_349)" )
                path = "Mulaolao.Contract.R_Frmwaixiancontract";
            else if ( processName == "喷油漆承揽生产加工合同(R_495)" )
                path = "Mulaolao.Contract.R_Frmpenyouqichen";
            else if ( processName == "订单销售合同(R_001)" )
                path = "Mulaolao.Contract.R_FrmSailes";
            else if ( processName == "合同评审表(R_021)" )
                path = "Mulaolao.Forms.R_FrmContractreview";
            else if ( processName == "客户信息传递记录表(R_369)" )
                path = "Mulaolao.Procedure.R_FrmCustomerrecord";
            else if ( processName == "产品档案表(R_404)" )
                path = "Mulaolao.Procedure.R_FrmProductarchives";
            else if ( processName == "产品委外(成品、雕刻、冲印、砂皮)等承揽加工合同书(R_195)" )
                path = "Mulaolao.Raw_material_cost.R_Frmchanpinzhibiao";
            else if ( processName == "丝.热.移印(化学品)承揽加工合同书 (R_196)" )
                path = "Mulaolao.Contract.R_FrmSiReYiYinContract";
            //else if ( processName == "产品成本汇总表(R_241)" )
            //    path = "Mulaolao.Summary.R_FrmProductCostSummary";
            else if ( processName == "产品每套成本改善控制表(R_509)" )
                path = "Mulaolao.Raw_material_cost.R_Frmchanpingaishan";
            //else if ( processName == "产品定时、定量、定额工序工资明细表(R_436)" )
            //    path = "Mulaolao.Raw_material_cost.R_Frmgongxugongzi";
            //else if ( processName == "产品工资考勤表(R_317)" )
            //    path = "Mulaolao.Wages.R_Frmchanpingongzikaoqin";
            else if ( processName == "产品塑料、布和其他零配件采购合同(R_347)" )
                path = "Mulaolao.Contract.R_Frmsuliaobuqitacontract";
            else if ( processName == "外箱、中包、彩盒、纸片（卡）等采购合同(R_349)" )
                path = "Mulaolao.Contract.R_Frmwaixiancontract";
            //else if ( processName == "油漆（墨）、香蕉水等化学品防白水使用批次及成本汇总表(R_285)" )
            //    path = "Mulaolao.Raw_material_cost.R_Frmhuaxuepicichenben";
            //else if ( processName == "生产计划进度计算表(R_046)" )
            //    path = "Mulaolao.Wages.R_Frmshenchanjindujihua";
            else if ( processName == "工资册(R_323)" )
                path = "Mulaolao.Wages.FrmGongZiCe";
            else if ( processName == "产品工资考勤表(R_317)" )
                path = "Mulaolao.Wages.R_Frmchanpingongzikaoqin";
            else if ( processName == "断料、平刨、压刨、夹料、叠料、清理承揽加工合同(R_505)" )
                path = "Mulaolao.Contract.R_FrmDuanLiaoContract";
            else if ( processName == "胶板供货计划均衡表(R_047)" )
                path = "Mulaolao.Contract.R_FrmJiaoMiDuJunHenTable";
            else if ( processName == "库存油漆（墨）等采购合同书(R_337)" )
                path = "Mulaolao.Contract.R_FrmYouQiPlanContract";
            //else if ( processName == "滚漆承揽加工成本合同书(R_344)" )
            //    path = "Mulaolao.Contract.GunqiChengLanJiaGong";
            else if ( processName == "滚漆承揽加工成本合同书(R_344)" )
                path = "Mulaolao.Contract.R_FrmGunQiContrract";
            else if ( processName == "管理人员工资册汇总表(R_050)" )
                path = "Mulaolao.Wages.R_FrmManagePayroll";
            else if ( processName == "企业日常付款流水明细帐(R_231)" )
                path = "Mulaolao.Wages.R_FrmPayMent";
            else if ( processName == "产品定时、定量、定额工序工资明细表(R_436)" )
                path = "Mulaolao.Raw_material_cost.R_Frmgongxugongzi";
            else if ( processName == "委外加工合同(R_199)" )
                path = "Mulaolao.Contract.R_FrmContractToDoAJob";
            else if ( processName == "样品产前策划及打样任务单(R_480)" )
                path = "Mulaolao.Schedule_control.R_Frmyanpinchangqiancehua";
            else if ( processName == "R_349合并流水号拆分(R_348)" )
                path = "Mulaolao.Contract.R_FrmWaiXian";
            Assembly asm = Assembly.GetExecutingAssembly( );
            Form doc = ( Form ) asm.CreateInstance( path );
            doc.MdiParent = this.MdiParent;
            doc.WindowState = FormWindowState.Maximized;
            Merges.oddNum = oddNum;
            doc.Show( );
        }

        public delegate void AccomplishTask ( );//声明一个在完成任务时通知主线程的委托
        public AccomplishTask TaskCallBack;

        DataTable remands = new DataTable( );
        private void Remind_Shown ( object sender ,EventArgs e )
        {
            this . label2 . Text = Logins . username;
            label3 . Visible = true;
            Func<string> funStr = dataTab;
            IAsyncResult result = funStr . BeginInvoke ( new AsyncCallback ( other ) ,null );

            Func<string> funBase = R021;
            IAsyncResult baseResult = funBase . BeginInvoke ( new AsyncCallback ( baseOther ) ,null );

            Func<string> funContract = contract;
            IAsyncResult contractResult = funContract . BeginInvoke ( new AsyncCallback ( contractOther ) ,null );

            Func<string> funContractAll = contractAll;
            IAsyncResult contractAllResult = funContractAll . BeginInvoke ( new AsyncCallback ( contractOtherAll ) ,null );

            //dataTab ( );

            DataTable de = SqlHelper.ExecuteDataTable( "SELECT GZ001 FROM R_PQGZ" );
            if ( de.Rows.Count > 0 )
                temp = string.IsNullOrEmpty( de.Rows[0]["GZ001"].ToString( ) ) == true ? 0 : Convert.ToInt32( de.Rows[0]["GZ001"].ToString( ) );
            else
                temp = 60;
        }
        
        string dataTab ( )
        {
            string strWhere = "";

            if ( Logins . number . Equals ( "MLL-0001" ) )
                //remands = SqlHelper . ExecuteDataTable ( "SELECT DISTINCT A.RES01,B.CX02,C.DBA002,A.RES04,A.RES05,A.RES06,A.RES07 FROM R_REVIEWS A INNER JOIN R_MLLCXMC B ON A.RES01=B.CX01 INNER JOIN TPADBA C ON A.RES03=C.DBA001 INNER JOIN R_REVIEW D ON A.RES01=D.RE02 INNER JOIN (SELECT MAX(RES04) RES04 FROM R_REVIEWS WHERE RES03!='" + Logins . number + "' GROUP BY RES01,RES06) E ON A.RES04=E.RES04 WHERE (SELECT COUNT(1) FROM R_REVIEWS B WHERE A.RES06=B.RES06 AND RES05='执行' )=0  AND (SELECT COUNT(1) FROM R_PQW B WHERE A.RES06=B.GZ29 AND GZ39='执行' AND GZ29 IS NOT NULL)=0 AND RE01='" + Logins . number + "' ORDER BY RES01,CX02,DBA002,A.RES04,RES05,RES06,RES07" );
                remands = SqlHelper . ExecuteDataTable ( "SELECT DISTINCT A.RES01,B.CX02,C.DBA002,A.RES04,A.RES05,A.RES06,A.RES07 FROM R_REVIEWS A INNER JOIN R_MLLCXMC B ON A.RES01=B.CX01 INNER JOIN TPADBA C ON A.RES03=C.DBA001 INNER JOIN R_REVIEW D ON A.RES01=D.RE02 INNER JOIN (SELECT MAX(RES04) RES04 FROM R_REVIEWS  GROUP BY RES01,RES06) E ON A.RES04=E.RES04 WHERE (SELECT COUNT(1) FROM R_REVIEWS B WHERE A.RES06=B.RES06 AND RES05='执行' )=0  AND (SELECT COUNT(1) FROM R_PQW B WHERE A.RES06=B.GZ29 AND GZ39='执行' AND GZ29 IS NOT NULL)=0 AND RE01='" + Logins . number + "' ORDER BY RES01,CX02,DBA002,A.RES04,RES05,RES06,RES07" );
            else
                remands = SqlHelper . ExecuteDataTable ( "SELECT DISTINCT A.RES01,B.CX02,C.DBA002,A.RES04,A.RES05,A.RES06,A.RES07 FROM R_REVIEWS A INNER JOIN R_MLLCXMC B ON A.RES01=B.CX01 INNER JOIN TPADBA C ON A.RES03=C.DBA001 INNER JOIN R_REVIEW D ON A.RES01=D.RE02 INNER JOIN (SELECT MAX(RES04) RES04 FROM R_REVIEWS WHERE RES03!='" + Logins . number + "' GROUP BY RES01,RES06) E ON A.RES04=E.RES04 WHERE (SELECT COUNT(1) FROM R_REVIEWS B WHERE A.RES06=B.RES06 AND RES05='执行' AND RES08 IS NOT NULL )=0  AND (SELECT COUNT(1) FROM R_PQW B WHERE A.RES06=B.GZ29 AND GZ39='执行' AND GZ29 IS NOT NULL)=0 AND RE01='" + Logins . number + "' ORDER BY RES01,CX02,DBA002,A.RES04,RES05,RES06,RES07" );

            return strWhere;
        }
        
        delegate void AsynUpdateUI ( );//定义一个委托，使其可以更新UI控件的状态
        void other ( IAsyncResult result )
        {
            if ( InvokeRequired )
            {
                this . Invoke ( new AsynUpdateUI ( delegate ( )
                {
                    label3 . Visible = false;
                    this . gridControl1 . DataSource = remands;
                } ) );
            }
        }

        int temp = 0;
        int pos = -1;

        int i = 0;
        private void contextMenuStrip1_ItemClicked ( object sender ,ToolStripItemClickedEventArgs e )
        {
            if ( ( e . ClickedItem ) . Name == "MenuItemRefresh" )
            {
                label3 . Visible = true;
                Func<string> funStr = dataTab;
                IAsyncResult result = funStr . BeginInvoke ( new AsyncCallback ( other ) ,null );

                Func<string> funBase = R021;
                IAsyncResult baseResult = funBase . BeginInvoke ( new AsyncCallback ( baseOther ) ,null );

                Func<string> funContract = contract;
                IAsyncResult contractResult = funContract . BeginInvoke ( new AsyncCallback ( contractOther ) ,null );

                Func<string> funContractAll = contractAll;
                IAsyncResult contractAllResult = funContractAll . BeginInvoke ( new AsyncCallback ( contractOtherAll ) ,null );
            }
            else if ( ( e . ClickedItem ) . Name == "MenuItemAutoMatic" )
            {
                SelectAll . RemindAuto reAu = new SelectAll . RemindAuto ( );
                reAu . StartPosition = FormStartPosition . CenterScreen;
                reAu . PassDataBetweenForm += new SelectAll . RemindAuto . PassDataBetweenFormHandler ( reAu_PassDataBetweenForm );
                reAu . ShowDialog ( );

                if ( temp <= 0 )
                    temp = 60;
                else
                {
                    DataTable da = SqlHelper . ExecuteDataTable ( "SELECT GZ001 FROM R_PQGZ" );
                    if ( da . Rows . Count > 0 )
                    {
                        try
                        {
                            SqlHelper . ExecuteNonQuery ( "UPDATE R_PQGZ SET GZ001=@GZ001" ,new SqlParameter ( "@GZ001" ,temp ) );
                        }
                        catch { }
                    }
                    else
                    {
                        try
                        {
                            SqlHelper . ExecuteNonQuery ( "INSERT INTO R_PQGZ (GZ001) VALUES (@GZ001)" ,new SqlParameter ( "@GZ001" ,temp ) );
                        }
                        catch { }
                    }
                }
            }
            else if ( ( e . ClickedItem ) . Name == "MenuItemDelete" )
            {
                SqlHelper . ExecuteNonQuery ( "DELETE FROM R_REVIEWS WHERE RES06=@RES06" ,new SqlParameter ( "@RES06" ,oddNum ) );
            }
        }
        private void reAu_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            temp = string.IsNullOrEmpty( e.ConOne ) == true ? 0 : Convert.ToInt32( e.ConOne );
        }

        private void timer1_Tick ( object sender ,EventArgs e )
        {
            if ( pos == 1 )
            {
                i++;
                if ( i == temp )
                {
                    i = 0;
                    dataTab( );
                }
            }
        }

        DataTable baseInfo,contractInfo,contractInfoAll,r195Con,r196Con,r338Con,r339Con,r341Con,r342Con,r343Con,r347Con,r349Con;
        delegate void AsynUpdateUIBase ( );//定义一个委托，使其可以更新UI控件的状态

        void baseOther ( IAsyncResult result )
        {
            if ( InvokeRequired )
            {
                this . Invoke ( new AsynUpdateUIBase ( delegate ( )
                {
                    this . gridControl2 . DataSource = baseInfo;
                } ) );
            }
        }

        //001-021-509-436-046
        string R021 ()
        {
            baseInfo = _bll . getTableFor021 ( Logins . number );
            return string . Empty;
            /*
             * R_021
             SELECT PQF01 流水号,PQF04 产品名称,PQF02 合同号,PQF03 货号 FROM R_PQF A INNER JOIN R_REVIEWS B ON A.PQF01=B.RES06 WHERE PQF01 NOT IN (SELECT PQF01 FROM R_PQF A INNER JOIN R_REVIEWS B ON A.PQF01=B.RES06 LEFT JOIN R_PQL C ON A.PQF01=C.HT01 WHERE RES05='执行') AND RES05='执行'

            SELECT COUNT(1) FROM R_DBB WHERE DBB002='R_021' AND DBB001='MLL-0001' AND DBB015='T'
             */

            /*
             R_509
             SELECT HT01 流水号,PQF04 产品名称,HT02 合同号,PQF03 货号 FROM R_PQL A INNER JOIN R_REVIEWS B ON A.HT01=B.RES06 INNER JOIN R_PQF C ON A.HT01=C.PQF01 WHERE HT01 NOT IN (SELECT HT01 FROM R_PQL A INNER JOIN R_REVIEWS B ON A.HT01=B.RES06 INNER JOIN R_PQP C ON A.HT01=C.GS01 WHERE RES05='执行') AND RES05='执行'

            SELECT COUNT(1) FROM R_DBB WHERE DBB002='R_509' AND DBB001='MLL-0001' AND DBB015='T'
             */

            /*
             * R_436
             SELECT DISTINCT GS01,GS46,GS47 FROM R_PQP A INNER JOIN R_REVIEWS B ON A.GS34=B.RES06 WHERE GS01 NOT IN (SELECT DISTINCT GS01 FROM R_PQP A INNER JOIN R_REVIEWS B ON A.GS34=B.RES06 INNER JOIN R_PQR D ON A.GS01=D.DS01 WHERE RES05='执行') AND RES05='执行'
             */

            /*
             * R_046
             SELECT DISTINCT DS01,DS22,DS24 FROM R_PQR A INNER JOIN R_REVIEWS B ON A.DS21=B.RES06 
             WHERE DS01 NOT IN (SELECT DS01 FROM R_PQR A INNER JOIN R_REVIEWS B ON A.DS21=B.RES06 INNER JOIN R_PQX D ON A.DS01=D.PQX01 WHERE RES05='执行') AND 
             RES05='执行'
             */

        }

        delegate void AsynUpdateUIContract ( );
        void contractOther ( IAsyncResult result )
        {
            if ( InvokeRequired )
            {
                this . Invoke ( new AsynUpdateUIContract ( delegate ( )
                {
                    this . gridControl3 . DataSource = contractInfo;
                } ) );
            }
        }
        //采购合同采购人提醒
        string contract ( )
        {
             
            contractInfo = _bll . getTableForContract ( Logins . number );
            contractInfo . Columns . Add ( "CP" ,typeof ( string ) );
            return string . Empty;
            /*
             * R_195
             * SELECT CP51,CP01,CP52,CP03,CP06,CP07,CP54,CP54*CP13 CP1,PQF31,CP57 
                FROM R_PQQ A INNER JOIN R_PQF B ON A.CP01=B.PQF01
                INNER JOIN R_REVIEWS D ON A.CP03=D.RES06
                WHERE --CP02='' AND 
                RES05='执行' AND (CP61='' OR CP61 IS NULL)            
             */

            /*
             * R_196
             * SELECT AH98,AH01,AH99,AH97,AH10,AH11,AH101,AH101*AH13*AH14 AH,PQF31,AH112 FROM R_PQAH 
                A INNER JOIN R_PQF B ON A.AH01=B.PQF01
                INNER JOIN R_REVIEWS D ON A.AH97=D.RES06
                WHERE --AH02='' AND 
                RES05='执行' AND (AH116='' OR AH116 IS NULL)
             */

            /*
             * R_199
             * SELECT BA051,BA001,BA052,BA003,BA006,BA007,BA054,BA054,PQF31,BA057 FROM R_PQBA A INNER JOIN R_PQF B ON A.BA001=B.PQF01
                INNER JOIN R_REVIEWS D ON A.BA003=D.RES06
                WHERE --BA002='' AND 
                RES05='执行' AND (BA062='' OR BA062 IS NULL)
             */

            /*
             * R_338
             * SELECT JM100,JM90,JM101,JM01,JM09,CONVERT(VARCHAR,JM94)+'*'+CONVERT(VARCHAR,JM95)+'*'+CONVERT(VARCHAR,JM96) JM,JM103,CASE WHEN JM14='外购' THEN JM104 ELSE JM15 END JM1 FROM R_PQO A INNER JOIN R_PQF B ON A.JM90=B.PQF01
                INNER JOIN R_REVIEWS D ON A.JM01=D.RES06
                WHERE --JM02='' AND 
                RES05='执行' AND (JM115='' OR JM115 IS NULL)
             */

            /*
             * R_339
             * SELECT YQ105,YQ03,YQ106,YQ99,YQ10,YQ12,YQ108,CASE WHEN YQ101='外购' THEN YQ109 ELSE YQ19 END YQ,PQF31,YQ124 FROM R_PQI A INNER JOIN R_PQF B ON A.YQ03=B.PQF01 INNER JOIN R_REVIEWS D ON A.YQ99=D.RES06
                WHERE YQ99 LIKE 'R_339%' AND 
                --YQ01='' AND 
                RES05='执行' AND (YQ137='' OR YQ137 IS NULL)
             */


            /*
             * R_337
             * SELECT YQ105,YQ03,YQ106,YQ99,YQ10,YQ06,YQ11,YQ12,YQ109,YQ17,YQ124 
                FROM R_PQI A INNER JOIN R_REVIEWS D ON A.YQ99=D.RES06
                WHERE YQ99 LIKE 'R_337%' AND 
                --YQ01='' AND 
                RES05='执行' AND (YQ138='' OR YQ138 IS NULL)
             */


            /*
             * R_341
             * SELECT PQV77,PQV01,PQV78,PQV76,PQV10,CONVERT(VARCHAR,PQV66)+'*'+CONVERT(VARCHAR,PQV81)+'*'+CONVERT(VARCHAR,PQV67) PQV,PQV80,
                CASE WHEN PQV65='外购' THEN PQV82 ELSE PQV64 END PQV1,PQF31,PQV89 FROM R_PQV A INNER JOIN R_PQF B ON A.PQV01=B.PQF01
                INNER JOIN R_REVIEWS D ON A.PQV76=D.RES06
                WHERE --PQV02='' AND 
                RES05='执行' AND (PQV96='' OR PQV96 IS NULL)
             */

            /*
             * R_342
             SELECT AF003,AF002,AF005,AF001,AF015,CONVERT(VARCHAR,AF020)+'*'+CONVERT(VARCHAR,AF021)+'*'+CONVERT(VARCHAR,AF022) AF,AF006,
                CASE WHEN AF016='外购' THEN AF017 ELSE AF018 END AF1,PQF31 FROM R_PQAF A INNER JOIN R_PQF B ON A.AF002=B.PQF01
                INNER JOIN R_REVIEWS D ON A.AF001=D.RES06
                WHERE --AF007='' AND 
                RES05='执行' AND (AF086='' OR AF086 IS NULL)
             */


            /*
             * R_343
             SELECT PQU98,PQU01,PQU99,PQU97,PQU10,PQU12,PQU101,CASE WHEN PQU19='外购' THEN PQU104 ELSE PQU18 END PQU,PQF31,PQU108 FROM R_PQU 
            A INNER JOIN R_PQF B ON A.PQU01=B.PQF01
             INNER JOIN R_REVIEWS D ON A.PQU97=D.RES06
             WHERE --CP02='' AND 
            RES05='执行' AND (PQU114='' OR PQU114 IS NULL)
             */

            /*
             * R_344
             SELECT MZ003,MZ002,MZ004,MZ001,MZ016,MZ018,MZ006,MZ006*MZ021 MZ,PQF31,'' MZ1 FROM R_PQMZ A INNER JOIN R_PQF B ON A.MZ002=B.PQF01
            INNER JOIN R_REVIEWS D ON A.MZ001=D.RES06
            WHERE --MZ117='' AND 
            RES05='执行' AND (MZ128='' OR MZ128 IS NULL)
             */

            /*
             * R_347
             SELECT PJ93,PJ01,PJ94,PJ92,PJ09,PJ89,PJ96,PJ11*PJ96+PJ10 PJ,PQF31,PJ101 FROM R_PQS A INNER JOIN R_PQF B ON A.PJ01=B.PQF01
             INNER JOIN R_REVIEWS D ON A.PJ92=D.RES06
            WHERE --PJ02='' AND 
            RES05='执行' AND (PJ108='' OR PJ108 IS NULL)
             */

            /*
             * R_349
             * SELECT WX83,WX01,WX84,WX82,WX10,WX11,WX86,CASE WHEN WX17='外购' THEN WX87 ELSE WX16 END WX,PQF31,WX91 FROM R_PQT  A INNER JOIN R_PQF B ON A.WX01=B.PQF01
                INNER JOIN R_REVIEWS D ON A.WX82=D.RES06
                WHERE --WX02='' AND 
                RES05='执行' AND (WX95='' OR WX95 IS NULL)
             */


            /*
             * R_495
             SELECT PY30,PY01,PY38,PY33,PY24,PY25,PY27,PY10*PY11 PY,PQF31,PY41 FROM R_PQY A INNER JOIN R_PQF B ON A.PY01=B.PQF01
            INNER JOIN R_REVIEWS D ON A.PY33=D.RES06
            WHERE --CP02='' AND 
            RES05='执行' AND (PY45='' OR PY45 IS NULL)
             */
        }
        delegate void AsynUpdateUIContractAll ( );

        void contractOtherAll ( IAsyncResult reuslt )
        {
            if ( InvokeRequired )
            {
                this . Invoke ( new AsynUpdateUIContractAll ( delegate ( )
                    {
                        this . gridControl4 . DataSource = r338Con;
                        this . gridControl5 . DataSource = r195Con;
                        this . gridControl6 . DataSource = r196Con;
                        this . gridControl7 . DataSource = r339Con;
                        this . gridControl8 . DataSource = r341Con;
                        this . gridControl9 . DataSource = r342Con;
                        this . gridControl10 . DataSource = r343Con;
                        this . gridControl11 . DataSource = r347Con;
                        this . gridControl12 . DataSource = r349Con;
                    } ) );
            }
        }

        /// <summary>
        /// 采购合同没有开的提醒
        /// </summary>
        /// <returns></returns>
        string contractAll ( )
        {
            contractInfoAll = _bll . getTableForContractAll ( );

            if ( contractInfoAll != null && contractInfoAll . Rows . Count > 0 )
            {
                r195Con = contractInfoAll . Clone ( );
                r196Con = contractInfoAll . Clone ( );
                r338Con = contractInfoAll . Clone ( );
                r339Con = contractInfoAll . Clone ( );
                r341Con = contractInfoAll . Clone ( );
                r342Con = contractInfoAll . Clone ( );
                r343Con = contractInfoAll . Clone ( );
                r347Con = contractInfoAll . Clone ( );
                r349Con = contractInfoAll . Clone ( );
                foreach ( DataRow row in contractInfoAll . Rows )
                {
                    if ( row [ "GS70" ] != null && row [ "GS70" ] . ToString ( ) != string . Empty )
                    {
                        if ( "R_195" . Equals ( row [ "GS70" ] . ToString ( ) ) )
                        {
                            r195Con . ImportRow ( row );
                        }else if ( "R_196" . Equals ( row [ "GS70" ] . ToString ( ) ) )
                        {
                            r196Con . ImportRow ( row );
                        }
                        else if ( "R_338" . Equals ( row [ "GS70" ] . ToString ( ) ) )
                        {
                            r338Con . ImportRow ( row );
                        }
                        else if ( "R_339" . Equals ( row [ "GS70" ] . ToString ( ) ) )
                        {
                            r339Con . ImportRow ( row );
                        }
                        else if ( "R_341" . Equals ( row [ "GS70" ] . ToString ( ) ) )
                        {
                            r341Con . ImportRow ( row );
                        }
                        else if ( "R_342" . Equals ( row [ "GS70" ] . ToString ( ) ) )
                        {
                            r342Con . ImportRow ( row );
                        }
                        else if ( "R_343" . Equals ( row [ "GS70" ] . ToString ( ) ) )
                        {
                            r343Con . ImportRow ( row );
                        }
                        else if ( "R_347" . Equals ( row [ "GS70" ] . ToString ( ) ) )
                        {
                            r347Con . ImportRow ( row );
                        }
                        else if ( "R_349" . Equals ( row [ "GS70" ] . ToString ( ) ) )
                        {
                            r349Con . ImportRow ( row );
                        }
                    }
                }

            }

            return string . Empty;

            /**
             * 
             * 合同分类是合同号的
             * 
             * 338:
             * 流水号、物料名称、厚
             * 流水号、部件或材料、规格厚
             * 
             * 341
             * 流水号、物料或部件名称、部件净规格厚
             * 流水号、部件或材料、规格厚
             * 
             * 342
             * 流水号、物料或部件名称、材料名称、Φ+高(厚)+长
             * 流水号、零件名称、部件或材料、规格
             * 
             * 343
             * 流水号、零件名称、规格尺寸按图纸或样板
             * 流水号、部件名称、规格
             * 
             * 347
             * 流水号、物品名称、公差尺寸含长宽高
             * 流水号、计算公式名称、规格
             * 
             * 349
             * 流水号、计算公式名称、规格
             * 流水号、计算公式名称、规格
             * 
             * 195(雕刻、砂皮)
             * 流水号、加工工序名称
             * 流水号、工段
             * 
             * 196(丝印/移印/热转印/走台印/冲印)
             * 流水号、加工.工序
             * 流水号、工段
             * 
             * 339
             * 流水号
             * 流水号、工段是(油漆、工资)
             * */



            //采购合同  
            /* 338
    WITH CET AS (
     select GS70,GS01,GS46,GS49,GS71,GS02,right(GS08,len(GS08) - charindex('*',GS08) ) a from R_PQP 
     WHERE GS70='R_338'
     ),CFT AS (
     SELECT GS70,GS01,GS46,GS49,GS71,GS02,right(a,LEN(a)-charindex('*',a)) GS08 FROM CET
     ),CHT AS(
     SELECT DISTINCT GS70,GS01,GS46,GS49,GS71,GS02,CONVERT(FLOAT,CONVERT(DECIMAL(11,2),GS08)*1.0/10) GS08 FROM CFT 
     )
     SELECT GS70,GS01,GS46,GS49,GS71,GS02,GS08,'' GS07 FROM CHT WHERE (SELECT COUNT(1) FROM R_PQO WHERE GS01=JM90 AND GS71=JM09 AND CONVERT(VARCHAR,GS08)=CONVERT(VARCHAR,CONVERT(FLOAT,CONVERT(DECIMAL(11,4),JM96))))=0

            341
    WITH CET AS (
    select GS70,GS01,GS46,GS49,GS71,GS02,right(GS08,len(GS08) - charindex('*',GS08) ) a from R_PQP 
    WHERE GS70='R_341'
    ),CFT AS (
    SELECT GS70,GS01,GS46,GS49,GS71,GS02,right(a,LEN(a)-charindex('*',a)) GS08 FROM CET
    ),CGT AS(
    SELECT DISTINCT GS70,GS01,GS46,GS49,GS71,GS02,CASE WHEN GS08='/' OR GS08='\' OR GS08='' THEN '0' ELSE GS08 END GS08 
    FROM CFT 
    ),CHT AS(
    SELECT DISTINCT GS70,GS01,GS46,GS49,GS71,GS02,CONVERT(FLOAT,CONVERT(DECIMAL(11,2),GS08)*1.0/10) GS08 FROM CGT 
    )
    SELECT GS70,GS01,GS46,GS49,GS71,GS02,GS08,'' GS07 FROM CHT WHERE (SELECT COUNT(1) FROM R_PQV WHERE GS01=PQV01 AND GS02=PQV86 AND CONVERT(VARCHAR,GS08)=CONVERT(VARCHAR,CONVERT(FLOAT,PQV73)))=0

            342
            SELECT DISTINCT GS70,GS01,GS46,GS49,GS71,GS02,GS08,GS07 FROM R_PQP A
    WHERE GS70='R_342' AND (SELECT COUNT(1) as num FROM R_PQAF B WHERE A.GS01=B.AF002 AND A.GS07=B.AF015 AND A.GS02=B.AF084 AND A.GS08=CONVERT(VARCHAR,B.AF020)+'*'+CONVERT(VARCHAR,B.AF021)+'*'+CONVERT(VARCHAR,B.AF022))=0 ORDER BY GS01

            343
           SELECT DISTINCT GS70,GS01,GS46,GS49,GS71,GS02,GS08,GS07 FROM R_PQP A GS70='R_343' AND (SELECT COUNT(1) as num FROM R_PQU B WHERE A.GS01=B.PQU01 AND A.GS07=B.PQU10 AND A.GS08=PQU12)=0 ORDER BY GS01


            347
            SELECT DISTINCT GS70,GS01,GS46,GS49,GS71,GS02,GS08,GS07 FROM R_PQP A WHERE GS70='R_347' AND (SELECT COUNT(1) as num FROM R_PQS B WHERE A.GS01=B.PJ01 AND A.GS07=B.PJ09 AND A.GS08=PJ89)=0 ORDER BY GS01

            349
            SELECT DISTINCT 'R_349' GS70,GS01,GS46,GS49,GS52 GS71,'' GS02,GS57 GS08,'' GS07 FROM R_PQP A WHERE GS52 IS NOT NULL AND GS52!='' AND (SELECT COUNT(1) as num FROM R_PQT B WHERE A.GS01=B.WX01 AND A.GS56=B.WX10 AND A.GS57=WX11)=0 ORDER BY GS01

            195
            SELECT DISTINCT 'R_195' GS70,GS01,GS46,GS49,GS35 GS71,'' GS02,'' GS08,'' GS07  FROM R_PQP A WHERE (GS35  LIKE '%丝印%' OR GS35 LIKE '%雕刻%' OR GS35  LIKE '%砂皮%' OR GS35  LIKE '%走台印%' OR GS35  LIKE '%冲印%') AND (SELECT COUNT(1) as num FROM R_PQQ B WHERE A.GS01=B.CP01 AND A.GS35=B.CP09)=0 ORDER BY GS01

            196
    SELECT DISTINCT 'R_196' GS70,GS01,GS46,GS49,GS35 GS71,'' GS02,'' GS08,'' GS07 FROM R_PQP A WHERE (GS35 LIKE '%丝印%' OR GS35 LIKE '%画线%' OR GS35 LIKE '%内加工%' OR GS35 LIKE '%热转印%' OR GS35 LIKE '%走台印%') AND  (SELECT COUNT(1) as num FROM R_PQAH B WHERE A.GS01=B.AH01 AND A.GS35=B.AH18)=0 ORDER BY GS01


            339
         SELECT DISTINCT 'R_339' GS70,GS01,GS46,GS49,GS35 GS71,'' GS02,'' GS08,'' GS07 FROM R_PQP A WHERE GS35 LIKE '%油漆%' AND   (SELECT COUNT(1) as num FROM R_PQI B WHERE A.GS01=B.YQ03)=0 ORDER BY GS01

              */
        }

        private void btnOver_ButtonClick ( object sender ,DevExpress . XtraEditors . Controls . ButtonPressedEventArgs e )
        {
            DataRow row = gridView2 . GetFocusedDataRow ( );
            if ( row == null )
                return;
            overCon ( row );
        }

        //批量已开
        private void btnOver_Click ( object sender ,EventArgs e )
        {
            
            if ( xtraTabControl2 . SelectedTabPage . Name == "R195" )
            {
                //rows = gridView3 . GetSelectedRows ( );
                //overAllCon ( rows ,row ,gridView3 );
                overAllCon ( gridView3 );
            }
            else if ( xtraTabControl2 . SelectedTabPage . Name == "R196" )
            {
                //rows = gridView4 . GetSelectedRows ( );
                //overAllCon ( rows ,row ,gridView4 );
                overAllCon ( gridView4 );
            }
            else if ( xtraTabControl2 . SelectedTabPage . Name == "R338" )
            {
                //rows = gridView2 . GetSelectedRows ( );
                //overAllCon ( rows ,row ,gridView2 );
                overAllCon ( gridView2 );
            }
            else if ( xtraTabControl2 . SelectedTabPage . Name == "R339" )
            {
                //rows = gridView5 . GetSelectedRows ( );
                //overAllCon ( rows ,row ,gridView5 );
                overAllCon ( gridView5 );
            }
            else if ( xtraTabControl2 . SelectedTabPage . Name == "R341" )
            {
                //rows = gridView6 . GetSelectedRows ( );
                //overAllCon ( rows ,row ,gridView6 );
                overAllCon ( gridView6 );
            }
            else if ( xtraTabControl2 . SelectedTabPage . Name == "R342" )
            {
                //rows = gridView7 . GetSelectedRows ( );
                //overAllCon ( rows ,row ,gridView7 );
                overAllCon ( gridView7 );
            }
            else if ( xtraTabControl2 . SelectedTabPage . Name == "R343" )
            {
                //rows = gridView8 . GetSelectedRows ( );
                //overAllCon ( rows ,row ,gridView8 );
                overAllCon ( gridView8 );
            }
            else if ( xtraTabControl2 . SelectedTabPage . Name == "R347" )
            {
                //rows = gridView9 . GetSelectedRows ( );
                //overAllCon ( rows ,row ,gridView9 );
                overAllCon ( gridView9 );
            }
            else if ( xtraTabControl2 . SelectedTabPage . Name == "R349" )
            {
                //rows = gridView10 . GetSelectedRows ( );
                //overAllCon ( rows ,row ,gridView10 );
                overAllCon ( gridView10 );
            }
        }
        void overAllCon ( DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            int [ ] rows;
            List<DataRow> row = new List<DataRow> ( );
            rows = view . GetSelectedRows ( );
            if ( rows . Length <= 0 )
                return;
            if ( MessageBox . Show ( "确认已开?" ,"提示" ,MessageBoxButtons . OKCancel ) != DialogResult . OK )
                return;
            foreach ( int i in rows )
            {
                row . Add ( view . GetDataRow ( i ) );
            }
            if ( row . Count > 0 )
            {
                foreach ( DataRow r in row )
                {
                    _bll . UpdateOver ( r );
                }
            }
        }
        private void btn195_ButtonClick ( object sender ,DevExpress . XtraEditors . Controls . ButtonPressedEventArgs e )
        {
            DataRow row = gridView3 . GetFocusedDataRow ( );
            if ( row == null )
                return;
            overCon ( row );
        }
        private void btn196_ButtonClick ( object sender ,DevExpress . XtraEditors . Controls . ButtonPressedEventArgs e )
        {
            DataRow row = gridView4 . GetFocusedDataRow ( );
            if ( row == null )
                return;
            overCon ( row );
        }
        private void btn339_ButtonClick ( object sender ,DevExpress . XtraEditors . Controls . ButtonPressedEventArgs e )
        {
            DataRow row = gridView5 . GetFocusedDataRow ( );
            if ( row == null )
                return;
            overCon ( row );
        }
        private void btn341_ButtonClick ( object sender ,DevExpress . XtraEditors . Controls . ButtonPressedEventArgs e )
        {
            DataRow row = gridView6 . GetFocusedDataRow ( );
            if ( row == null )
                return;
            overCon ( row );
        }
        private void btn342_ButtonClick ( object sender ,DevExpress . XtraEditors . Controls . ButtonPressedEventArgs e )
        {
            DataRow row = gridView7 . GetFocusedDataRow ( );
            if ( row == null )
                return;
            overCon ( row );
        }
        private void btn343_ButtonClick ( object sender ,DevExpress . XtraEditors . Controls . ButtonPressedEventArgs e )
        {
            DataRow row = gridView8 . GetFocusedDataRow ( );
            if ( row == null )
                return;
            overCon ( row );
        }
        private void btn347_ButtonClick ( object sender ,DevExpress . XtraEditors . Controls . ButtonPressedEventArgs e )
        {
            DataRow row = gridView9 . GetFocusedDataRow ( );
            if ( row == null )
                return;
            overCon ( row );
        }
        private void btn349_ButtonClick ( object sender ,DevExpress . XtraEditors . Controls . ButtonPressedEventArgs e )
        {
            DataRow row = gridView10 . GetFocusedDataRow ( );
            if ( row == null )
                return;
            overCon ( row );
        }
        void overCon ( DataRow row )
        {
            if ( MessageBox . Show ( "确认已开?" ,"确认" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                return;

            _bll . UpdateOver ( row );
        }
        private void btnDate_ButtonClick ( object sender ,DevExpress . XtraEditors . Controls . ButtonPressedEventArgs e )
        {
            DataRow row = bandedGridView1 . GetFocusedDataRow ( );
            if ( row == null )
                return;
            if ( MessageBox . Show ( "确认到货?" ,"确认" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                return;
            string tableName = row [ "tn" ] . ToString ( );
            string idx = row [ "idx" ] . ToString ( );
            string oddNum = row [ "CP03" ] . ToString ( );
            if ( !tableName . Equals ( "油漆（墨）等化学品采购合同书(R_339)" ) && !tableName . Equals ( "库存油漆（墨）等采购合同书(R_337)" ) )
                _bll . UpdateDate ( tableName ,idx );
            else if( tableName . Equals ( "油漆（墨）等化学品采购合同书(R_339)" ) || tableName . Equals ( "库存油漆（墨）等采购合同书(R_337)" ) )
                _bll . UpdateDateT ( tableName ,oddNum );
        }
        private void bandedGridView1_DoubleClick ( object sender ,EventArgs e )
        {
            DataRow row = bandedGridView1 . GetFocusedDataRow ( );
            if ( row != null )
                return;
            processName= row [ "tn" ] . ToString ( );
            Reflected ( );
        }
        private void contextMenuStrip2_ItemClicked ( object sender ,ToolStripItemClickedEventArgs e )
        {
            if ( ( e . ClickedItem ) . Name == "MenuItemRe" )
            {
                Func<string> funContract = contract;
                IAsyncResult contractResult = funContract . BeginInvoke ( new AsyncCallback ( contractOther ) ,null );
            }
        }

    }
}





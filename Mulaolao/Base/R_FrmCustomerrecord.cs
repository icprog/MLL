using System;
using System . Data;
using System . Drawing;
using System . Windows . Forms;
using Mulaolao . Class;
using System . IO;
using Mulaolao . Other;
using FastReport;
using System . Collections . Generic;
using FastReport . Export . Xml;
using MulaolaoBll;

namespace Mulaolao . Procedure
{
    public partial class R_FrmCustomerrecord : FormChild
    {
        MulaolaoBll.Bll.CustomerrecordBll _bll=null;
        MulaolaoLibrary.CustomerrecordEntity _kh=null;
        MulaolaoLibrary.CustomerrecordNAEntity _na=null;
        DataTable tableView;
        string state=string.Empty;
        bool result=false;
        SpecialPowers sp = new SpecialPowers( );
        DataSet RDataset;List<CheckBox> cbo=new List<CheckBox>();
        Report report = new Report( );
        List<string> strList=new List<string>();

        public R_FrmCustomerrecord( )
        {
            InitializeComponent();

            _kh = new MulaolaoLibrary . CustomerrecordEntity ( );
            _na = new MulaolaoLibrary . CustomerrecordNAEntity ( );
            _bll = new MulaolaoBll . Bll . CustomerrecordBll ( );
            tableView = new DataTable ( );
            lab . Visible = false;

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { this . gridView1 } );
            UserInfoMation . tableName = this . Name;
        }

        private void R_FrmCustomerrecord_Load( object sender, EventArgs e )
        {
            Power( this );
            UnEnable ( );

            lupCustom . Properties . DataSource = _bll . getCustomNameInfo ( );
            lupCustom . Properties . DisplayMember = "DFA002";

            lupSalesman . Properties . DataSource = _bll . getSalesmanInfo ( );
            lupSalesman . Properties . DisplayMember = "DBA002";

            DataTable dt = _bll . getAllInfo ( );
            cmbNo . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"KH03" );
            cmbNo . DisplayMember = "KH03";
            cmbProName . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"KH05" );
            cmbProName . DisplayMember = "KH05";
            cmbProNo . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"KH04" );
            cmbProNo . DisplayMember = "KH04";
            cmbSample . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"KH02" );
            cmbSample . DisplayMember = "KH02";
            cmbAge . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"KH14" );
            cmbAge . DisplayMember = "KH14";
            cmbCountry . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"KH17" );
            cmbCountry . DisplayMember = "KH17";
            cmbTestNo . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"KH19" );
            cmbTestNo . DisplayMember = "KH19";
            
        }

        private void R_FrmCustomerrecord_Shown ( object sender ,EventArgs e )
        {
            _kh . KH01 = Merges . oddNum;
            if ( !string . IsNullOrEmpty ( _kh . KH01 ) )
                autoQuery ( );
            Merges . oddNum = "";
        }

        #region print or export
        private void CreateDataset( )
        {
            RDataset = new DataSet( );
            DataTable print = _bll . getPrintOne ( _kh . KH01 );
            DataTable prints = _bll . getPrintTwo ( _kh . KH01 );
            print.TableName = "R_PQN";
            prints.TableName = "R_PQNA";
            RDataset.Tables.Add( print );
            RDataset.Tables.Add( prints );
        }
        #endregion

        #region  Main
        void autoQuery ( )
        {
            UnEnable ( );
            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = true;
            toolSave . Enabled = toolCancel . Enabled = false;

            state = "2";
            setVlues ( );
        }
        protected override void select ( )
        {
            SelectAll . CustomerrecordAll from = new SelectAll . CustomerrecordAll ( this . Text + "查询" );
            if ( from . ShowDialog ( ) == DialogResult . OK )
            {
                _kh . KH01 = _na . NA001 = from . getOddNum;
                autoQuery ( );
            }

            base.select( );
        }
        protected override void add ( )
        {
            state = "1";
            _kh . KH01 = _na . NA001 = _bll . getOddNum ( );
            Clear ( );
            Enable ( );
            txtKH35 . Enabled = false;
            lab . Visible = false;
            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = false;
            toolSave . Enabled = toolCancel . Enabled = true;
            tableView = _bll . getTableView ( "1=2" );
            gridControl1 . DataSource = tableView;

            base . add ( );
        }
        protected override void delete ( )
        {

            if ( lab . Visible )
            {
                if ( Logins . number . Equals ( "MLL-0001" ) )
                    dele ( );
                else
                    MessageBox . Show ( "执行单据您无权删除,需要总经理删除" );
            }
            else
                dele ( );

            base . delete ( );
        }
        void dele ( )
        {
            result = _bll . Delete ( _kh . KH01 ,Logins . username );
            if ( result )
            {
                MessageBox . Show ( "成功删除" );

                UnEnable ( );
                Clear ( );
                toolSelect . Enabled = toolAdd . Enabled = toolPrint . Enabled = toolExport . Enabled = true;
                toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolMaintain . Enabled = toolSave . Enabled = toolCancel . Enabled = false;
                lab . Visible = false;
            }
            else
                MessageBox . Show ( "删除失败,请重试" );
        }
        protected override void update( )
        {
            if ( lab . Visible )
                MessageBox . Show ( "本单据已经执行,请维护" );
            else
            {
                state = "2";
                toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = false;
                toolSave . Enabled = toolCancel . Enabled = true;
                Enable ( );
                txtKH35 . Enabled = false;
            }
            base .update( );
        }         
        protected override void revirw( )
        {
            Reviews ( "KH01" ,_kh.KH01 ,"R_PQN" ,this ,"" ,"R_369" ,false ,false ,MulaolaoBll . Drity . GetDt ( )/*,"" ,"" ,"" ,"" ,"" ,"" ,"","R_001" */);
            result = false;
            result = sp . reviewImple ( "R_369" ,_kh . KH01 );
            if ( result == true )
                lab . Visible = true;
            else
                lab . Visible = false;

            base .revirw( );       
        }
        protected override void print( )
        {
            base.print( );

            CreateDataset ( );
            
            report . Load ( Application . StartupPath + "\\R_369.frx" );
            report . RegisterData ( RDataset );
            report . Show ( );
        }
        protected override void export( )
        {
            base.export( );

            CreateDataset ( );
            report . Load ( Application . StartupPath + "\\R_369.frx" );
            report . RegisterData ( RDataset );
            report . Prepare ( );
            XMLExport exprots = new XMLExport ( );
            exprots . Export ( report );
        }
        private void addes ( )
        {
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolPrint.Enabled = toolExport.Enabled = true;
            toolSave . Enabled = toolCancel . Enabled = false;
            UnEnable ( );
        }
        protected override void save ( )
        {
            if ( string . IsNullOrEmpty ( cmbSample . Text ) )
            {
                MessageBox . Show ( "样品名称不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( cmbProName . Text ) )
            {
                MessageBox . Show ( "产品名称不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( cmbProNo . Text ) )
            {
                MessageBox . Show ( "合同号不可为空" );
                return;
            }

            gridView1 . CloseEditor ( );
            gridView1 . UpdateCurrentRow ( );
            getValue ( );

            if ( state . Equals ( "1" ) )
                result = _bll . Save ( _kh ,tableView ,Logins . username );
            else
                result = _bll . Edit ( _kh ,tableView ,Logins . username ,strList );

            if ( result )
            {
                MessageBox . Show ( "保存成功" );
                addes ( );
                strList . Clear ( );
            }
            else
                MessageBox . Show ( "保存失败,请重试" );

            base . save ( );
        }
        protected override void cancel( )
        {
            base.cancel( );
            if ( state . Equals ( "1" ) )
            {
                Clear ( );
                toolSelect . Enabled = toolAdd . Enabled = toolPrint . Enabled = toolExport . Enabled = true;
                toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolMaintain . Enabled = toolExport . Enabled = toolSave . Enabled = toolCancel . Enabled = false;
            }
            else if ( state . Equals ( "2" ) )
            {
                toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = true;
                toolSave . Enabled = toolCancel . Enabled = false;
            }
            UnEnable ( );
        }
        protected override void maintain( )
        {
            if ( lab . Visible )
            {
                state = "2";
                Enable ( );
                toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = false;
                toolSave . Enabled = toolCancel . Enabled = true;
            }
            else
                MessageBox . Show ( "请更改" );

            base.maintain( );
        }
        #endregion

        #region Event
        //EN71
        private void che1_CheckedChanged( object sender, EventArgs e )
        {
            if (cheKH21.Checked)
            {
                cbo.Add( cheKH21 );
                if (cbo.Count > 2)
                {
                    foreach (CheckBox cb in cbo)
                    {
                        cb.Checked = false;
                    }
                    cbo.Clear( );
                    cheKH25.Checked = true;
                }
            }
        }
        //ASTM F963
        private void che2_CheckedChanged( object sender, EventArgs e )
        {
            if (cheKH22.Checked)
            {
                cbo.Add( cheKH22 );
                if (cbo.Count > 2)
                {
                    foreach (CheckBox cb in cbo)
                    {
                        cb.Checked = false;
                    }
                    cbo.Clear( );
                    cheKH25.Checked = true;
                }
            }
        }
        //ST2012
        private void che3_CheckedChanged( object sender, EventArgs e )
        {
            if (cheKH23.Checked)
            {
                cbo.Add( cheKH23 );
                if (cbo.Count > 2)
                {
                    foreach (CheckBox cb in cbo)
                    {
                        cb.Checked = false;
                    }
                    cbo.Clear( );
                    cheKH25.Checked = true;
                }
            }
        }
        //GB6675
        private void che4_CheckedChanged( object sender, EventArgs e )
        {
            if (cheKH24.Checked)
            {
                cbo.Add( cheKH24 );
                if (cbo.Count > 2)
                {
                    foreach (CheckBox cb in cbo)
                    {
                        cb.Checked = false;
                    }
                    cbo.Clear( );
                    cheKH25.Checked = true;
                }
            }
        }
        //全球
        private void checkBox1_CheckedChanged( object sender, EventArgs e )
        {
            if (cheKH25.Checked)
                cheKH21.Checked = cheKH22.Checked = cheKH23.Checked = cheKH24.Checked = cheKH21.Enabled = cheKH22.Enabled = cheKH23.Enabled = cheKH24.Enabled = false;
            else
                cheKH21.Enabled = cheKH22.Enabled = cheKH23.Enabled = cheKH24.Enabled = true;
        }
        //法规
        private void checkB3_CheckedChanged( object sender, EventArgs e )
        {
            if (cheKH20.Checked)
            {
                cheKH21.Enabled = cheKH22.Enabled = cheKH23.Enabled = cheKH24.Enabled = true;
                cheKH25.Enabled = true;
            }
            else
            {
                cheKH21.Enabled = cheKH22.Enabled = cheKH23.Enabled = cheKH24.Enabled = false;
                cheKH25.Enabled = false;
            }
        }
        //年龄段
        private void checkB7_CheckedChanged( object sender, EventArgs e )
        {
            if (cheKH13.Checked)
                cmbAge.Enabled = true;
            else
                cmbAge.Enabled = false;
        }
        //输入国
        private void checkB6_CheckedChanged( object sender, EventArgs e )
        {
            if (cheKH16.Checked)
                cmbCountry.Enabled = true;
            else
                cmbCountry.Enabled = false;
        }
        //检测号
        private void checkB8_CheckedChanged( object sender, EventArgs e )
        {
            if (cheKH18.Checked)
                cmbTestNo.Enabled = true;
            else
                cmbTestNo.Enabled = false;
        }
        //窗体关闭事件
        private void R_FrmCustomerrecord_FormClosing( object sender, FormClosingEventArgs e )
        {
            if (toolSave.Enabled)
            {
                cancel( );
            }
        }
        //产品数量
        private void comboBox8_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //确认人签字
        private void button4_Click( object sender, EventArgs e )
        {
            if (txtKH30.Text == "")
                txtKH30.Text = Logins.username;
            else if (txtKH30.Text != "" && txtKH30.Text==Logins.username)
                txtKH30.Text = "";
        }
        //接受人签字
        private void button5_Click( object sender, EventArgs e )
        {
            if (txtKH32.Text == "")
                txtKH32.Text = Logins.username;
            else if (txtKH32.Text != "" && txtKH32.Text==Logins.username)
                txtKH32.Text = "";
        }
        private void gridControl1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DataRow row = gridView1 . GetFocusedDataRow ( );
            if ( row != null )
            {
                if ( MessageBox . Show ( "确认删除?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                    return;
                strList . Add ( row [ "idx" ] . ToString ( ) );
                tableView . Rows . Remove ( row );
                gridControl1 . RefreshDataSource ( );
            }
        }
        #endregion

        #region Picture        
        string filePath1 = "";
        private void btn10_Click( object sender, EventArgs e )
        {
            OpenFileDialog ofd = new OpenFileDialog( );
            ofd.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
            if ( ofd . ShowDialog ( ) == DialogResult . OK )
            {
                filePath1 = ofd . FileName;//图片路径
                picKH07 . ImageLocation = filePath1;

                FileStream fs = new FileStream ( filePath1 ,FileMode . Open ,FileAccess . Read );
                //byte[] imageBytes = new byte[fs.Length];
                BinaryReader br = new BinaryReader ( fs );
                _kh . KH07 = br . ReadBytes ( ( int ) fs . Length );//图片转换成二进制流    
            }
        }
        private void btn11_Click( object sender, EventArgs e )
        {
            if (picKH07.ImageLocation == "")
                MessageBox.Show( "没有图片,不能放大" );
            else
            {
                R_FrmImageAmplication ima = new R_FrmImageAmplication ( );
                ima .pictureBox1.Image = picKH07.Image;
                ima.ShowDialog( );
            }
        }
        private void btn12_Click ( object sender ,EventArgs e )
        {
            picKH07 . Image = null;
            picKH07 . ImageLocation = "";
            _kh . KH07 = new byte [ 0 ];
        }
        #endregion

        #region Method
        void UnEnable ( )
        {
            cmbAge . Enabled = cmbCountry . Enabled = cmbNo . Enabled = cmbProName . Enabled = cmbProNo . Enabled = cmbSample . Enabled = txtProNum . Enabled = cmbTestNo . Enabled = dtOne . Enabled = cheKH11 . Enabled = cheKH12 . Enabled = cheKH13 . Enabled = cheKH15 . Enabled = cheKH16 . Enabled = cheKH18 . Enabled = cheKH20 . Enabled = cheKH21 . Enabled = cheKH22 . Enabled = cheKH23 . Enabled = cheKH24 . Enabled = cheKH25 . Enabled = txtKH26 . Enabled = txtKH27 . Enabled = txtKH28 . Enabled = txtKH29 . Enabled = txtKH30 . Enabled = txtKH32 . Enabled = dtTwo . Enabled = dtTre . Enabled = picKH07 . Enabled = btnP1 . Enabled = btnP2 . Enabled = btnP3 . Enabled = txtKH35 . Enabled = lupCustom . Enabled = lupSalesman . Enabled = false;
            gridView1 . OptionsBehavior . Editable = false;
        }
        void Enable ( )
        {
            cmbAge . Enabled = cmbCountry . Enabled = cmbNo . Enabled = cmbProName . Enabled = cmbProNo . Enabled = cmbSample . Enabled = txtProNum . Enabled = cmbTestNo . Enabled = dtOne . Enabled = cheKH11 . Enabled = cheKH12 . Enabled = cheKH13 . Enabled = cheKH15 . Enabled = cheKH16 . Enabled = cheKH18 . Enabled = cheKH20 . Enabled = cheKH21 . Enabled = cheKH22 . Enabled = cheKH23 . Enabled = cheKH24 . Enabled = cheKH25 . Enabled = txtKH26 . Enabled = txtKH27 . Enabled = txtKH28 . Enabled = txtKH29 . Enabled = txtKH30 . Enabled = txtKH32 . Enabled = dtTwo . Enabled = dtTre . Enabled = picKH07 . Enabled = btnP1 . Enabled = btnP2 . Enabled = btnP3 . Enabled = txtKH35 . Enabled = lupCustom . Enabled = lupSalesman . Enabled = true;
            gridView1 . OptionsBehavior . Editable = true;
        }
        void Clear ( )
        {
            cmbAge . Text = cmbCountry . Text = cmbNo . Text = cmbProName . Text = cmbProNo . Text = cmbSample . Text = cmbTestNo . Text = txtKH26 . Text = txtKH27 . Text = txtKH28 . Text = txtKH29 . Text = txtKH30 . Text = txtKH32 . Text = txtKH35 . Text = txtProNum . Text = string . Empty;
            dtOne . Value = dtTwo . Value = dtTre . Value = MulaolaoBll . Drity . GetDt ( );
            picKH07 . Image = null;
            lupCustom . EditValue = lupSalesman . EditValue = null;
            cheKH11 . Checked = cheKH12 . Checked = cheKH13 . Checked = cheKH15 . Checked = cheKH16 . Checked = cheKH18 . Checked = cheKH20 . Checked = cheKH21 . Checked = cheKH22 . Checked = cheKH23 . Checked = cheKH24 . Checked = cheKH25 . Checked = false;
            gridControl1 . DataSource = null;
        }
        void setVlues ( )
        {
            tableView = _bll . getTableView ( " NA001='" + _kh . KH01 + "'" );
            gridControl1 . DataSource = tableView;
            _kh = _bll . getModel ( _kh . KH01 );
            setValueHead ( );
        }
        void setValueHead ( )
        {
            cmbSample . Text = _kh . KH02;
            cmbNo . Text = _kh . KH03;
            cmbProNo . Text = _kh . KH04;
            cmbProName . Text = _kh . KH05;
            txtProNum . Text = _kh . KH06 . ToString ( );
            if ( _kh . KH08 > DateTime . MinValue && _kh . KH08 < DateTime . MaxValue )
                dtOne . Value = _kh . KH08;
            lupCustom . Text = _kh . KH09;
            lupSalesman . Text = _kh . KH10;
            cheKH11 . Checked = _kh . KH11 == true ? true : false;
            cheKH12 . Checked = _kh . KH12 == true ? true : false;
            cheKH13 . Checked = _kh . KH13 == true ? true : false;
            cmbAge . Text = _kh . KH14;
            cheKH15 . Checked = _kh . KH15 == true ? true : false;
            cheKH16 . Checked = _kh . KH16 == true ? true : false;
            cmbCountry . Text = _kh . KH17;
            cheKH18 . Checked = _kh . KH18 == true ? true : false;
            cmbTestNo . Text = _kh . KH19;
            cheKH20 . Checked = _kh . KH20 == true ? true : false;
            cheKH21 . Checked = _kh . KH21 == true ? true : false;
            cheKH22 . Checked = _kh . KH22 == true ? true : false;
            cheKH23 . Checked = _kh . KH23 == true ? true : false;
            cheKH24 . Checked = _kh . KH24 == true ? true : false;
            cheKH25 . Checked = _kh . KH25 == true ? true : false;
            txtKH26 . Text = _kh . KH26;
            txtKH27 . Text = _kh . KH27;
            txtKH28 . Text = _kh . KH28;
            txtKH29 . Text = _kh . KH29;
            txtKH30 . Text = _kh . KH30;
            txtKH32 . Text = _kh . KH32;
            if ( _kh . KH31 > DateTime . MinValue && _kh . KH31 < DateTime . MaxValue )
                dtTwo . Value = _kh . KH31;
            if ( _kh . KH33 > DateTime . MinValue && _kh . KH33 < DateTime . MaxValue )
                dtTre . Value = _kh . KH33;

            MemoryStream ms = new MemoryStream ( _kh . KH07 );
            ms . Write ( _kh . KH07 ,0 ,_kh . KH07 . Length );
            ms . Position = 0;
            ms . Seek ( 0 ,SeekOrigin . Begin );
            Image img = Image . FromStream ( ms ,true );
            picKH07 . Image = img;

            txtKH35 . Text = _kh . KH35;
            txtKH35 . Tag = _kh . KH34;
            if ( !string . IsNullOrEmpty ( txtKH35 . Text ) )
                lab . Visible = true;
        }
        void getValue ( )
        {
            _kh . KH02 = cmbSample . Text;
            _kh . KH03 = cmbNo . Text;
            _kh . KH04 = cmbProNo . Text;
            _kh . KH05 = cmbProName . Text;
            _kh . KH06 = string . IsNullOrEmpty ( txtProNum . Text ) == true ? 0 : Convert . ToInt32 ( txtProNum . Text );
            _kh . KH08 = dtOne . Value;
            _kh . KH09 = lupCustom . Text;
            _kh . KH10 = lupSalesman . Text;
            _kh . KH11 = cheKH11 . Checked == true ? true : false;
            _kh . KH12 = cheKH12 . Checked == true ? true : false;
            _kh . KH13 = cheKH13 . Checked == true ? true : false;
            _kh . KH14 = cmbAge . Text;
            _kh . KH15 = cheKH15 . Checked == true ? true : false;
            _kh . KH16 = cheKH16 . Checked == true ? true : false;
            _kh . KH17 = cmbCountry . Text;
            _kh . KH18 = cheKH18 . Checked == true ? true : false;
            _kh . KH19 = cmbTestNo . Text;
            _kh . KH20 = cheKH20 . Checked == true ? true : false;
            _kh . KH21 = cheKH21 . Checked == true ? true : false;
            _kh . KH22 = cheKH22 . Checked == true ? true : false;
            _kh . KH23 = cheKH23 . Checked == true ? true : false;
            _kh . KH24 = cheKH24 . Checked == true ? true : false;
            _kh . KH25 = cheKH25 . Checked == true ? true : false;
            _kh . KH26 = txtKH26 . Text;
            _kh . KH27 = txtKH27 . Text;
            _kh . KH28 = txtKH28 . Text;
            _kh . KH29 = txtKH29 . Text;
            _kh . KH30 = txtKH30 . Text;
            _kh . KH32 = txtKH32 . Text;
            _kh . KH31 = dtTwo . Value;
            _kh . KH33 = dtTre . Value;
            _kh . KH35 = txtKH35 . Text;
            if ( txtKH35 . Tag == null )
                _kh . KH34 = string . Empty;
            else
                _kh . KH34 = txtKH35 . Tag . ToString ( );
        }
        #endregion

    }
}

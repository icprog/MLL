using System;
using System . Collections . Generic;
using System . Data;
using System . Drawing;
using System . Windows . Forms;
using StudentMgr;
using Mulaolao . Class;
using System . IO;
using Mulaolao . Other;
using FastReport;
using FastReport . Export . Xml;
using DevExpress . Utils . Taskbar . Core;
using DevExpress . Utils . Taskbar;

namespace Mulaolao . Contract
{
    public partial class R_FrmSailes : FormChild
    {
        public R_FrmSailes (/*Form fm */)
        {
            //this.MdiParent = fm;
            InitializeComponent( );

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { this . gridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        MulaolaoLibrary.SailesLibrary model = new MulaolaoLibrary.SailesLibrary( );
        MulaolaoBll.Bll.SailesBll bll = new MulaolaoBll.Bll.SailesBll( );
        SpecialPowers sp = new SpecialPowers( );
        List<string> numList = new List<string>( );
        List<DevExpress.XtraEditors.LookUpEdit> look = new List<DevExpress.XtraEditors.LookUpEdit>( );
        string file = "", strWhere = "1=1", weihu = "";
        DataTable da;
        GroupBox[] gb;
        string bj;
        List<string> zt = new List<string>( );

        private DataSet XDataSet;
        Report report = new Report( );
        bool result = false;

        string path = Environment.CurrentDirectory + "\\布局";
        string files = "\\R_001.XML";

        
        private void R_FrmSailes_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );

            Power( this );

            look.Clear( );
            gb = new GroupBox[] { groupBox1 ,groupBox2 ,groupBox4 ,groupBox5 ,groupBox6 };
            look.Add( lookUpEdit1 );
            look.Add( lookUpEdit2 );
            look.Add( lookUpEdit3 );
            look.Add( lookUpEdit4 );
            look.Add( lookUpEdit5 );
            look.Add( lookUpEdit6 );
            Ergodic.FormEvery( this );
            Ergodic.FormGroupboxEnableFalse( this ,gb );
            Ergodic.LookUpEditState( look );
            clearControl ( );

            label22 .Visible = label21.Visible = label50.Visible = false;
            textBox6.Enabled = false;
            textBox27.Enabled = textBox28.Enabled = false;

            zt.Add( "提交" );
            zt.Add( "执行" );
            zt.Add( "驳回" );
            foreach ( string dj in zt )
            {
                comboBox16.Items.Add( dj );
            }

            #region

            lookUpEdit1.Properties.DataSource = bll.GetDataTableCustomer( );
            lookUpEdit1.Properties.DisplayMember = "DFA003";
            lookUpEdit1.Properties.ValueMember = "DFA001";

            lookUpEdit2.Properties.DataSource = bll.GetDataTableBusiness( );
            lookUpEdit2.Properties.DisplayMember = "DBA002";
            lookUpEdit2.Properties.ValueMember = "DBA001";

            DataTable dro = bll.GetDataTableSingle( );

            lookUpEdit3.Properties.DataSource = dro.Copy( );
            lookUpEdit3.Properties.DisplayMember = "DBA002";
            lookUpEdit3.Properties.ValueMember = "DBA001";

            lookUpEdit5.Properties.DataSource = dro.Copy( );
            lookUpEdit5.Properties.DisplayMember = "DBA002";
            lookUpEdit5.Properties.ValueMember = "DBA001";

            lookUpEdit4.Properties.DataSource = bll.GetDataTableWork( );
            lookUpEdit4.Properties.DisplayMember = "DAA002";
            lookUpEdit4.Properties.ValueMember = "DAA001";
            
            lookUpEdit6.Properties.DataSource = bll.GetDataTableSail( );
            lookUpEdit6.Properties.DisplayMember = "DAA002";
            lookUpEdit6.Properties.ValueMember = "DAA001";

            #region
            DataTable biao = bll.GetDataTableAll( );
            comboBox8.DataSource = biao.DefaultView.ToTable( true ,"PQF02" );
            comboBox8.DisplayMember = "PQF02";
            comboBox10.DataSource = biao.DefaultView.ToTable( true ,"PQF05" );
            comboBox10.DisplayMember = "PQF05";
            comboBox4.DataSource = biao.DefaultView.ToTable( true ,"PQF07" );
            comboBox4.DisplayMember = "PQF07";
            comboBox11.DataSource = biao.DefaultView.ToTable( true ,"PQF08" );
            comboBox11.DisplayMember = "PQF08";
            comboBox5.DataSource = biao.DefaultView.ToTable( true ,"PQF47" );
            comboBox5.DisplayMember = "PQF47";
            comboBox7.DataSource = biao.DefaultView.ToTable( true ,"PQF44" );
            comboBox7.DisplayMember = "PQF44";
            comboBox6.DataSource = biao.DefaultView.ToTable( true ,"PQF20" );
            comboBox6.DisplayMember = "PQF20";
            comboBox15.DataSource = biao.DefaultView.ToTable( true ,"PQF60" );
            comboBox15.DisplayMember = "PQF60";
            comboBox9.DataSource = biao.DefaultView.ToTable( true ,new string[] { "PQF03" ,"PQF04" } );
            comboBox9.DisplayMember = "PQF03";
            comboBox9.ValueMember = "PQF04";

            #endregion

            #endregion

            if ( Directory.Exists( path + files ) )
            {
                gridControl1.MainView.RestoreLayoutFromXml( path + files );
            }
        }

        private void R_FrmSailes_Shown ( object sender ,EventArgs e )
        {
            model.PQF01 = Merges.oddNum;
            if ( !string.IsNullOrEmpty( model.PQF01 ) )
                autoQuery( );
            Merges.oddNum = "";
        }
        
        #region Print Export
        private void CreateDataset ( )
        {
            XDataSet = new DataSet( );
            string PQF1 = textBox1.Text, PQF2 = comboBox8.Text;
            DataTable xs = bll.GetDataTablePrint( model.PQF01 );
            DataTable mx = bll.GetDataTableExport( model.PQF02 );
            xs.TableName = "R_PQF";
            mx.TableName = "R_PQFS";
            XDataSet.Tables.Add( xs );
            XDataSet.Tables.Add( mx );
        }
        #endregion

        #region  Event
        //窗体关闭
        private void R_FrmSailes_FormClosing ( object sender ,FormClosingEventArgs e )
        {
            if ( toolSave.Enabled )
            {
                cancel( );
            }
            if ( !Directory.Exists( path ) )
            {
                Directory.CreateDirectory( path );
            }
            gridControl1.MainView.SaveLayoutToXml( path + files );
        }
        //产品数量
        private void textBox5_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //产品单价
        private void textBox27_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox27 );
        }
        private void textBox27_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox27.Text != "" && !DateDayRegise.eightFiveNumber( textBox27 ) )
            {
                this.textBox27.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多五位,如999.99999,请重新输入" );
            }
        }
        //美元单价
        private void textBox28_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox28 );
        }
        private void textBox28_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox28.Text != "" && !DateDayRegise.eightFiveNumber( textBox28 ) )
            {
                this.textBox28.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多五位,如999.99999,请重新输入" );
            }
        }
        //预收款金额
        private void textBox8_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox8 );
        }
        private void textBox8_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox8.Text != "" && !DateDayRegise.tenTwoNumber( textBox8 ) )
            {
                this.textBox8.Text = "";
                MessageBox.Show( "只允许输入整数部分最多八位,小数部分最多两位,如99999999.99,请重新输入" );
            }
        }
        //接单汇率
        private void textBox32_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox32 );
        }
        private void textBox32_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox32.Text != "" && !DateDayRegise.fiveThreeNumtb( textBox32 ) )
            {
                this.textBox32.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多三位,如99.999,请重新输入" );
            }
        }
        //其他收款
        private void textBox31_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox31 );
        }
        private void textBox31_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox31.Text != "" && !DateDayRegise.tenTwoNumber( textBox31 ) )
            {
                this.textBox31.Text = "";
                MessageBox.Show( "只允许输入整数部分最多八位,小数部分最多两位,如99999999.99,请重新输入" );
            }
        }
        //double a=0, b=0, c=0, d=0;
        private void textBox32_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox32 );

            if ( radioButton7.Checked )
            {
                //if (textBox32.Text != "" && double.Parse( textBox32.Text ) != 0)
                //{
                //a = double.Parse( textBox32.Text );
                //textBox28.Text = (b / a).ToString( "000.00000" );
                textBox28.Text = Math.Round( Convert.ToDecimal( Operation.DivisionTc( textBox27 ,textBox32 ) ) ,5 ).ToString( );
                //}
                //else
                //{
                //    textBox28.Text = "";
                //}
            }
            else if ( radioButton8.Checked )
            {
                //if (textBox32.Text == "" || double.Parse( textBox32.Text ) == 0.000)
                //{
                //    textBox27.Text = "";
                //}
                //else
                //{
                //    c = double.Parse( textBox32.Text );
                //    textBox27.Text = (c * d).ToString( "000.00000" );
                textBox27.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTb( textBox32 ,textBox28 ) ) ,5 ).ToString( );
                //}
            }
        }
        private void textBox28_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox28 );

            if ( radioButton8.Checked )
            {
                //if ( textBox32.Text == "" )
                //    c = 0;
                //d = double.Parse( textBox28.Text );
                //textBox27.Text = (c * d).ToString( "000.00000" );
                textBox27.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTb( textBox32 ,textBox28 ) ) ,5 ).ToString( );
            }
        }
        private void textBox27_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox27 );

            if ( radioButton7.Checked )
            {
                //b = double.Parse( textBox27.Text );
                //if (a == 0)
                //{
                //    textBox28.Text = "";
                //}
                //else
                //{
                //    textBox28.Text = (b / a).ToString( "000.00000" );
                textBox28.Text = Math.Round( Convert.ToDecimal( Operation.DivisionTc( textBox27 ,textBox32 ) ) ,5 ).ToString( );
                //}
            }
        }
        private void gridControl1_DoubleClick ( object sender ,EventArgs e )
        {
            if ( gridView1 . FocusedRowHandle >= 0 && gridView1 . FocusedRowHandle <= gridView1 . RowCount - 1 )
            {
                model . PQF01 = gridView1 . GetFocusedRowCellValue ( "PQF01" ) . ToString ( );
                assignMent ( );
                tabControl1 . SelectedIndex = 0;
            }
        }
        private void gridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            
        }
        void assignMent ( )
        {
            model = bll.GetModel( model.PQF01 );
            textBox1.Text = model.PQF01;
            comboBox8.Text = model.PQF02;
            comboBox9.Text = model.PQF03;
            textBox4.Text = model.PQF04;
            comboBox10.Text = model.PQF05;
            textBox5.Text = model.PQF06.ToString( );
            comboBox4.Text = model.PQF07;
            comboBox11.Text = model.PQF08;
            textBox27.Text = model.PQF09.ToString( );
            textBox28.Text = model.PQF10.ToString( );
            dateTimePicker1.Value = model.PQF13;
            comboBox6.Text = model.PQF20;
            comboBox16.Text = model.PQF21;
            dateTimePicker5.Value = model.PQF56;
            dateTimePicker6.Value = model.PQF58;
            comboBox15.Text = model.PQF60;
            if ( model.PQF23 == "是" )
            {
                radioButton3.Checked = true;
            }
            else if ( model.PQF23 == "否" )
            {
                radioButton4.Checked = true;
            }
            if ( model.PQF24 == "是" )
            {
                radioButton6.Checked = true;
            }
            else if ( model.PQF24 == "否" )
            {
                radioButton5.Checked = true;
            }
            textBox3.Text = model.PQF61;
            dateTimePicker2.Value = model.PQF63;
            dateTimePicker4.Value = model.PQF31;
            dateTimePicker3.Value = model.PQF32;
            dateTimePicker7.Value = model.PQF34;
            if ( model.PQF41 == "人民币" )
            {
                radioButton7.Checked = true;
                textBox2.Text = "人民币";
            }
            else if ( model.PQF41 == "美元" )
            {
                radioButton8.Checked = true;
                textBox2.Text = "美元";
            }
            comboBox5.Text = model.PQF47;
            textBox8.Text = model.PQF38.ToString( );
            comboBox7.Text = model.PQF44;
            textBox32.Text = model.PQF45.ToString( );
            textBox31.Text = model.PQF49.ToString( );
            textBox14.Text = model.PQF51;
            textBox6.Text = model.PQF64;
            other( );
        }
        void other ( )
        {
            DataTable dp = bll . GetDataTableOther ( model . PQF01 );
            if ( dp . Rows . Count > 0 )
            {
                if ( ( ( byte [ ] ) dp . Rows [ 0 ] [ "PQF29" ] ) . Length == 0 )
                {
                    pictureBox1 . Image = null;
                }
                else
                {
                    model . PQF29 = ( byte [ ] ) dp . Rows [ 0 ] [ "PQF29" ];
                    byte [ ] mybyte = ( byte [ ] ) dp . Rows [ 0 ] [ "PQF29" ];
                    MemoryStream ms = new MemoryStream ( mybyte );
                    ms . Write ( mybyte ,0 ,mybyte . Length );
                    ms . Position = 0;
                    ms . Seek ( 0 ,SeekOrigin . Begin );
                    Image img = Image . FromStream ( ms ,true );
                    pictureBox1 . Image = img;
                }
                if ( ( ( byte [ ] ) dp . Rows [ 0 ] [ "PQF62" ] ) . Length == 0 )
                {
                    pictureBox2 . Image = null;
                }
                else
                {
                    model . PQF62 = ( byte [ ] ) dp . Rows [ 0 ] [ "PQF62" ];
                    byte [ ] mybyte = ( byte [ ] ) dp . Rows [ 0 ] [ "PQF62" ];
                    MemoryStream ms = new MemoryStream ( mybyte );
                    ms . Write ( mybyte ,0 ,mybyte . Length );
                    ms . Position = 0;
                    ms . Seek ( 0 ,SeekOrigin . Begin );
                    Image img = Image . FromStream ( ms ,true );
                    pictureBox2 . Image = img;
                }

                lookUpEdit1 . Text = dp . Rows [ 0 ] [ "DFA003" ] . ToString ( );
                lookUpEdit5 . Text = dp . Rows [ 0 ] [ "DBA2" ] . ToString ( );
                lookUpEdit2 . Text = dp . Rows [ 0 ] [ "PQF67" ] . ToString ( );
                lookUpEdit3 . Text = dp . Rows [ 0 ] [ "DBA02" ] . ToString ( );
                lookUpEdit4 . Text = dp . Rows [ 0 ] [ "PQF66" ] . ToString ( );
                lookUpEdit6 . Text = dp . Rows [ 0 ] [ "DAA02" ] . ToString ( );

                if ( dp . Rows [ 0 ] [ "RES05" ] . ToString ( ) == "执行" )
                {
                    label22 . Visible = true;
                    label21 . Visible = label50 . Visible = false;
                }
                else if ( dp . Rows [ 0 ] [ "RES05" ] . ToString ( ) == "驳回" )
                {
                    label21 . Visible = true;
                    label22 . Visible = label50 . Visible = false;
                }
                else if ( dp . Rows [ 0 ] [ "RES05" ] . ToString ( ) == "送审" )
                {
                    label50 . Visible = true;
                    label21 . Visible = label22 . Visible = true;
                }
                else
                    label21 . Visible = label22 . Visible = label50 . Visible = false;
            }
        }
        private void radioButton7_CheckedChanged ( object sender ,EventArgs e )
        {
            if ( toolAdd.Enabled || toolUpdate.Enabled || toolMaintain.Enabled )
            {
                textBox27.Enabled = true;
                textBox28.Enabled = false;
                textBox2.Text = radioButton7.Text;
            }
        }
        private void radioButton8_CheckedChanged ( object sender ,EventArgs e )
        {
            if ( toolAdd.Enabled || toolUpdate.Enabled || toolMaintain.Enabled )
            {
                textBox28.Enabled = true;
                textBox27.Enabled = false;
                textBox2.Text = radioButton8.Text;
            }
        }
        //货号
        private void comboBox9_SelectedValueChanged ( object sender ,EventArgs e )
        {
            if ( comboBox9.Items.Count > 1 )
            {
                textBox4.Text = comboBox9.SelectedValue.ToString( );
            }
        }
        //单据状态
        private void comboBox16_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox16.Text != "" && !zt.Contains( comboBox16.Text ) )
            {
                comboBox16.Text = "";
                MessageBox.Show( "单据状态不能输入,必须选择" );
            }
        }
        #endregion

        #region  Picture
        //图片
        string filepath = "";
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
                model.PQF29 = bs.ReadBytes( ( int ) fs.Length );
            }
        }
        //放大 
        R_FrmImageAmplication ima = new R_FrmImageAmplication( );
        //另一个窗体,用做放大的图片显示,上面有一个picturebox控件
        private void button5_Click ( object sender ,EventArgs e )
        {
            if ( pictureBox1.ImageLocation == "" )
            {
                MessageBox.Show( "没有图片,无法放大" );
            }
            else
            {
                ima.pictureBox1.Image = pictureBox1.Image;
                ima.ShowDialog( );
            }
        }
        //删除
        private void button6_Click ( object sender ,EventArgs e )
        {
            pictureBox1.Image = null;
            model.PQF29 = new byte[0];
        }
        //合同附件
        string filepath1 = "";
        private void button3_Click ( object sender ,EventArgs e )
        {
            OpenFileDialog opd = new OpenFileDialog( );
            opd.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
            if ( opd.ShowDialog( ) == DialogResult.OK )
            {
                filepath1 = opd.FileName;
                pictureBox2.ImageLocation = filepath1;

                FileStream fs = new FileStream( filepath1 ,FileMode.Open ,FileAccess.Read );
                BinaryReader bs = new BinaryReader( fs );
                model.PQF62 = bs.ReadBytes( ( int ) fs.Length );
            }
        }
        //放大
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( pictureBox2.ImageLocation == "" )
            {
                MessageBox.Show( "没有图片,无法放大" );
            }
            else
            {
                ima.pictureBox1.Image = pictureBox2.Image;
                ima.ShowDialog( );
            }
        }
        //删除
        private void button1_Click ( object sender ,EventArgs e )
        {
            pictureBox2.Image = null;
            model.PQF62 = new byte[0];
        }
        #endregion
        
        #region Main
        void autoQuery ( )
        {
            Ergodic.FormEvery( this );
            Ergodic.LookUpEditState( look );
            Ergodic.FormGroupboxEnableFalse( this ,gb );
            toolSelect.Enabled = toolAdd.Enabled = toolExport.Enabled = toolPrint.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolMaintain.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;

            if ( numList == null || numList.Count < 1 )
            {
                strWhere = "1=1";
                strWhere = strWhere + " AND PQF01='" + model.PQF01 + "'";
            }
            else
            {
                strWhere = "1=1";
                string stri = "''";
                foreach ( string str in numList )
                {
                    stri = stri + "," + "'" + str + "'";
                }
                strWhere = " idx IN (" + stri + ")";
            }
            refre( );
        }
        SelectAll.SailesQueryAll saq = new SelectAll.SailesQueryAll( );
        //Query
        protected override void select ( )
        {
            base.select( );

            model = new MulaolaoLibrary.SailesLibrary( );
            saq.StartPosition = FormStartPosition.CenterScreen;
            saq.Text = "R_001 信息查询";
            saq.PassDataBetweenForm += new SelectAll.SailesQueryAll.PassDataBetweenFormHandler( saq_PassDataBetweenForm );
            saq.ShowDialog( );

            if ( string.IsNullOrEmpty( model.PQF01 ) && ( numList == null || numList.Count < 1 ) )
                MessageBox.Show( "您没有选择任何内容" );
            else
                autoQuery( );
        }
        private void saq_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            if ( e.List != null && e.List.Count > 0 )
                numList = e.List;
            else
            {
                model.PQF01 = e.ConOne;
                if ( e.ConTwo == "执行" )
                {
                    label22.Visible = true;
                    label21.Visible = label50.Visible = false;
                }
                else if ( e.ConTwo == "驳回" )
                {
                    label21.Visible = true;
                    label22.Visible = label50.Visible = false;
                }
                else if ( e.ConTwo == "送审" )
                {
                    label50.Visible = true;
                    label21.Visible = label22.Visible = true;
                }
                else
                    label21.Visible = label22.Visible = label50.Visible = false;
            }
        }
        //Add
        protected override void add ( )
        {
            base.add( );

            clearControl ( );
            Ergodic .FormEvery( this );
            Ergodic.FormGroupboxEnableTrue( this ,gb );
            Ergodic.LookUpEditState( look );
            gridControl1.DataSource = null;
            label22.Visible = label21.Visible = label50.Visible = false;
            textBox6.Enabled = false;
            model.PQF01 = "";
            bj = "1";
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
        }
        //Delete
        void dele ( )
        {
            string stateOfOdd = "";
            if ( label21.Visible == true )
                stateOfOdd = label21.Text;
            if ( label22.Visible == true )
                stateOfOdd = label22.Text;
            if ( label50.Visible == true )
                stateOfOdd = label50.Text;
            result = bll.Delete( "R_001" ,"销售订单合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,model.PQF01 ,"" ,"删除" ,stateOfOdd );
            if ( result == true )
            {
                MessageBox.Show( "成功删除记录" );
                int num = gridView1.FocusedRowHandle;
                da.Rows.RemoveAt( num );
                Ergodic.FormEvery( this );
                Ergodic.FormGroupboxEnableFalse( this ,gb );
                Ergodic.LookUpEditState( look );
                clearControl ( );

                toolDelete .Enabled = toolUpdate.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled = false;
                toolExport.Enabled = toolPrint.Enabled = toolSelect.Enabled = toolAdd.Enabled = true;

                textBox6.Enabled = false;
                label21.Visible = label22.Visible = label50.Visible = false;
            }
            else
                MessageBox.Show( "删除记录失败" );
        }
        protected override void delete ( )
        {
            base . delete ( );

                result = bll . ExistsReviews ( model . PQF01 );

                if ( result == true )
                {
                    if ( Logins . number == "MLL-0001" )
                        dele ( );
                    else
                        MessageBox . Show ( "流水号:" + model . PQF01 + "的单据状态为执行,不允许删除" );
                }
                else
                    dele ( );
        }
        //Update
        protected override void update ( )
        {
            base.update( );

            result = false;
            result = bll.ExistsReviews( model.PQF01 );

            if ( result == true )
                MessageBox.Show( "流水号:" + model.PQF01 + "的单据状态为执行,不允许更改" );
            else
            {
                Ergodic.FormGroupboxEnableTrue( this ,gb );
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolExport.Enabled = toolReview.Enabled = toolMaintain.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;

                textBox6.Enabled = false;

                bj = "2";
            }
        }
        //Reviews
        protected override void revirw ( )
        {
            base.revirw( );

            Reviews( "PQF01" ,textBox1.Text ,"R_PQF" ,this ,"" ,"R_001" ,false ,false,MulaolaoBll . Drity . GetDt ( )/*,"" ,"" ,"" ,"" ,"" ,"" ,"","R_001" */);
            result = false;
            result = sp.reviewImple( "R_001" ,model.PQF01 );
            if ( result == true )
            {
                label22.Visible = true;
                try
                {
                    SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfCopy( "R_PQFC" ,"R_PQF" ,"PQF01" ,textBox1.Text ) );
                    bll.WriteToDaily( model.PQF01 );
                }
                catch { }
            }
            else
                label22.Visible = false;
        }
        //Print
        protected override void print ( )
        {
            base.print( );

            CreateDataset( );
            file = "";
            file = System.Windows.Forms.Application.StartupPath;
            report.Load( file + "\\XSDD.frx" );
            report.SetParameterValue( "Day" ,MulaolaoBll . Drity . GetDt ( ).ToString( "yyyy年MM月dd日" ) );

            report.RegisterData( XDataSet );
            report.Show( );
            //report.Dispose( );
        }
        //Export
        protected override void export ( )
        {
            base.export( );
            CreateDataset( );
            file = "";
            file = System.Windows.Forms.Application.StartupPath;
            report.Load( file + "\\XSDD.frx" );
            report.SetParameterValue( "Day" ,MulaolaoBll . Drity . GetDt ( ).ToString( "yyyy年MM月dd日" ) );

            report.RegisterData( XDataSet );
            report.Prepare( );
            XMLExport exports = new XMLExport( );
            exports.Export( report );
            //report.Dispose( );
        }
        //Save
        void adds ( )
        {
            model . PQF02 = comboBox8 . Text;
            model . PQF03 = comboBox9 . Text;
            model . PQF04 = textBox4 . Text;
            model . PQF05 = comboBox10 . Text;
            model . PQF06 = string . IsNullOrEmpty ( textBox5 . Text ) == true ? 0 : Convert . ToInt64 ( textBox5 . Text );
            model . PQF07 = comboBox4 . Text;
            model . PQF08 = comboBox11 . Text;
            model . PQF09 = string . IsNullOrEmpty ( textBox27 . Text ) == true ? 0 : Convert . ToDecimal ( textBox27 . Text );
            model . PQF10 = string . IsNullOrEmpty ( textBox28 . Text ) == true ? 0 : Convert . ToDecimal ( textBox28 . Text );
            model . PQF11 = lookUpEdit1 . EditValue == null ? string . Empty : lookUpEdit1 . EditValue . ToString ( );
            model . PQF12 = lookUpEdit2 . EditValue == null ? string . Empty : lookUpEdit2 . EditValue . ToString ( );
            model . PQF67 = lookUpEdit2 . Text;
            model . PQF13 = dateTimePicker1 . Value;
            model . PQF20 = comboBox6 . Text;
            model . PQF55 = lookUpEdit3 . EditValue == null ? string . Empty : lookUpEdit3 . EditValue . ToString ( );
            model . PQF21 = comboBox16 . Text;
            model . PQF56 = dateTimePicker5 . Value;
            model . PQF57 = lookUpEdit5 . EditValue == null ? string . Empty : lookUpEdit5 . EditValue . ToString ( );
            model . PQF17 = lookUpEdit4 . EditValue == null ? string . Empty : lookUpEdit4 . EditValue . ToString ( );
            model . PQF66 = lookUpEdit4 . Text;
            model . PQF58 = dateTimePicker6 . Value;
            model . PQF59 = lookUpEdit6 . EditValue == null ? string . Empty : lookUpEdit6 . EditValue . ToString ( );
            model . PQF60 = comboBox15 . Text;
            model . PQF23 = radioButton3 . Checked == true ? radioButton3 . Text : radioButton4 . Text;
            model . PQF24 = radioButton6 . Checked == true ? radioButton6 . Text : radioButton5 . Text;
            model . PQF61 = textBox3 . Text;
            model . PQF63 = dateTimePicker2 . Value;
            model . PQF31 = dateTimePicker4 . Value;
            model . PQF32 = dateTimePicker3 . Value;
            model . PQF34 = dateTimePicker7 . Value;
            model . PQF41 = radioButton7 . Checked == true ? radioButton7 . Text : radioButton8 . Text;
            model . PQF47 = comboBox5 . Text;
            model . PQF38 = string . IsNullOrEmpty ( textBox8 . Text ) == true ? 0 : Convert . ToDecimal ( textBox8 . Text );
            model . PQF44 = comboBox7 . Text;
            model . PQF45 = string . IsNullOrEmpty ( textBox32 . Text ) == true ? 0 : Convert . ToDecimal ( textBox32 . Text );
            model . PQF49 = string . IsNullOrEmpty ( textBox31 . Text ) == true ? 0 : Convert . ToDecimal ( textBox31 . Text );
            model . PQF51 = textBox14 . Text;
            model . PQF64 = textBox6 . Text;
        }
        void state ( )
        {
            strWhere = "1=1";
            strWhere = strWhere + " AND PQF01='" + model.PQF01 + "'";
            refre( );

            Ergodic.FormGroupboxEnableFalse( this ,gb );
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolExport.Enabled = toolReview.Enabled = toolMaintain.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;

            textBox6.Enabled = false;
        }
        protected override void save ( )
        {
            base.save( );

            if ( string.IsNullOrEmpty( comboBox8.Text ) )
            {
                MessageBox.Show( "合同号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox9.Text ) )
            {
                MessageBox.Show( "货号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox4.Text ) )
            {
                MessageBox.Show( "产品名称不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( lookUpEdit1.Text ) )
            {
                MessageBox.Show( "客户名称不可为空" );
                return;
            }
            if ( radioButton7.Checked == false && radioButton8.Checked == false )
            {
                MessageBox.Show( "请选择人民币或美元" );
                return;
            }
            if ( radioButton7.Checked )
            {
                if ( string.IsNullOrEmpty( textBox27.Text ) )
                {
                    MessageBox.Show( "产品单价不可为空" );
                    return;
                }
                if ( Convert.ToDecimal( textBox27.Text )<=0 )
                {
                    MessageBox.Show( "产品单价不可小于等于0" );
                    return;
                }
            }
            if ( radioButton8.Checked )
            {
                if ( string.IsNullOrEmpty( textBox28.Text ) )
                {
                    MessageBox.Show( "美元单价不可为空" );
                    return;
                }
                if ( Convert.ToDecimal( textBox28.Text ) <= 0 )
                {
                    MessageBox.Show( "美元单价不可小于等于0" );
                    return;
                }
            }
            adds( );

            DataTable del = SqlHelper.ExecuteDataTable( "SELECT PQF01,PQF65 FROM R_PQF" );
            if ( bj == "1" )
            {
                if ( del.Rows.Count < 1 )
                {
                    //model.PQF01 = MulaolaoBll . Drity . GetDt ( ).ToString( "yyyy" ).Substring( 2 ,2 ) + MulaolaoBll . Drity . GetDt ( ).ToString( "MM" ) + "0001";
                    model.PQF01 = MulaolaoBll . Drity . GetDt ( ).ToString( "yyyy" ).Substring( 2 ,2 ) + "000001";
                    model.PQF65 = "";
                    result = bll.Add( model ,"R_001" ,"销售订单合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"保存" ,"新增保存" );
                    if ( result==false )
                        MessageBox.Show( "录入数据失败" );
                    else
                    {
                        MessageBox.Show( "成功录入数据" );
                        state( );
                    }
                }
                else
                {
                    model.PQF01 = del.Compute( "Max(PQF01)" ,"true" ).ToString( );
                    if ( model.PQF01.Substring( 0 ,4 ) == MulaolaoBll . Drity . GetDt ( ).ToString( "yyyyMM" ).Substring( 2 ,4 ) )
                        model.PQF01 = ( Convert.ToInt32( model.PQF01 ) + 1 ).ToString( );
                    else
                    {
                        if ( model.PQF01.Substring( 0 ,2 ) == MulaolaoBll . Drity . GetDt ( ).ToString( "yyyy" ).Substring( 2 ,2 ) )
                        {
                            if ( Convert.ToInt32( model.PQF01.Substring( 2 ,1 ) ) > 0 )
                                model.PQF01 = MulaolaoBll . Drity . GetDt ( ).ToString( "yyyyMM" ).Substring( 2 ,4 ) + ( Convert.ToInt32( model.PQF01.Substring( 2 ,6 ) ) + 1 ).ToString( ).Substring( 2 ,4 );
                            else
                                model.PQF01 = MulaolaoBll . Drity . GetDt ( ).ToString( "yyyyMM" ).Substring( 2 ,4 ) + ( Convert.ToInt32( model.PQF01.Substring( 3 ,5 ) ) + 1 ).ToString( ).Substring( 1 ,4 );
                        }
                        else
                            model.PQF01 = MulaolaoBll . Drity . GetDt ( ).ToString( "yyyyMM" ).Substring( 2 ,4 ) + "0001";
                    }
                    model.PQF65 = "";
                    result = bll.Add( model ,"R_001" ,"销售订单合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"保存" ,"新增保存" );
                    if ( result==false )
                        MessageBox.Show( "录入数据失败" );
                    else
                    {
                        MessageBox.Show( "成功录入数据" );
                        state( );
                    }
                }
            }
            else if ( bj == "2" )
            {
                model.PQF01 = textBox1.Text;
                model.PQF65 = "";
                result = false;
                result = bll.Update( model ,"R_001" ,"销售订单合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"保存" ,"更改保存" );
                if ( result == false )
                    MessageBox.Show( "编辑数据失败" );
                else
                {
                    MessageBox.Show( "编辑数据成功" );
                    try
                    {
                        bll.WriteToDaily( model.PQF01 );
                    }
                    catch { }
                    state( );
                }
            }
            else if ( weihu == "1" )
            {
                if ( string.IsNullOrEmpty( textBox6.Text ) )
                    MessageBox.Show( "请填写维护意见" );
                else
                {
                    model.PQF01 = textBox1.Text;
                    model.PQF65 = del.Select( "PQF01='" + model.PQF01 + "'" )[0]["PQF65"].ToString( ) + "[" + Logins.username + MulaolaoBll . Drity . GetDt ( ).ToString( "yyyyMMdd" ) + "]";

                    result = false;
                    result = bll.Update( model ,"R_001" ,"销售订单合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"保存" ,"维护保存" );
                    if ( result == false )
                        MessageBox.Show( "编辑数据失败" );
                    else
                    {
                        MessageBox.Show( "编辑数据成功" );
                        try
                        {
                            SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfCopy( "R_PQFC" ,"R_PQF" ,"PQF01" ,model.PQF01 ) );
                            bll.WriteToDaily( model.PQF01 );
                        }
                        catch { }
                        state( );
                    }
                }
            }
        }
        //Cancel
        protected override void cancel( )
        {
            base.cancel( );

            if (bj == "1" && weihu !="1")
            {
                Ergodic.FormEvery( this );
                Ergodic.LookUpEditState( look );
                clearControl ( );
                toolSelect .Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolExport.Enabled = toolReview.Enabled = toolMaintain.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = false;
                label21.Visible = label22.Visible = label50.Visible = false;
                try
                {
                    bll.Delete( "R_001" ,"销售订单合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,model.PQF01 ,"" ,"新增取消" ,"无此单" );
                }
                catch { }
            }
            else if (bj == "2" || weihu=="1")
            {
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolExport.Enabled = toolReview.Enabled = toolMaintain.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = false;
            }         
            Ergodic.FormGroupboxEnableFalse( this, gb );
            textBox6.Enabled = false;
        }
        //Maintain
        protected override void maintain( )
        {
            base.maintain( );

            result = false;
            result = bll.ExistsReviews( model.PQF01  );
            if ( result == true )
            {
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolExport.Enabled = toolReview.Enabled = toolMaintain.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;

                Ergodic.FormGroupboxEnableTrue( this ,gb );

                textBox6.Enabled = true;
                label22.Visible = true;
                label21.Visible = label50.Visible = false;

                weihu = "1";
            }
            else
                MessageBox.Show( "此单据没有被执行,只需更改即可,无需维护" );
        }
        void refre ( )
        {
            if ( string . IsNullOrEmpty ( strWhere ) )
                strWhere = "1=1";
            da = bll . GetDataTabletable ( strWhere );
            gridControl1 . DataSource = da;
            if ( gridView1 . DataRowCount > 0 )
            {
                model . PQF01 = gridView1 . GetDataRow ( 0 ) [ "PQF01" ] . ToString ( );
                assignMent ( );
            }
        }
        #endregion

        #region Method
        void clearControl ( )
        {
            textBox1 . Text = comboBox8 . Text = comboBox9 . Text = textBox4 . Text = comboBox10 . Text = textBox5 . Text = comboBox4 . Text = comboBox11 . Text = textBox27 . Text = textBox28 . Text = comboBox6 . Text = comboBox16 . Text = comboBox15 . Text = textBox3 . Text = comboBox5 . Text = textBox8 . Text = comboBox7 . Text = textBox32 . Text = textBox31 . Text = textBox14 . Text = textBox6 . Text = string . Empty;
            lookUpEdit1 . EditValue = lookUpEdit2 . EditValue = lookUpEdit2 . EditValue = lookUpEdit3 . EditValue = lookUpEdit5 . EditValue = lookUpEdit4 . EditValue = lookUpEdit4 . EditValue = lookUpEdit6 . EditValue = null;
            dateTimePicker1 . Value = dateTimePicker5 . Value = dateTimePicker6 . Value = dateTimePicker2 . Value = dateTimePicker4 . Value = dateTimePicker3 . Value = dateTimePicker7 . Value = MulaolaoBll . Drity . GetDt ( );
            radioButton3 . Checked = radioButton6 . Checked = radioButton7 . Checked = radioButton8 . Checked = false;
            pictureBox1 . Image = pictureBox2 . Image = null;
        }
        #endregion

    }
}

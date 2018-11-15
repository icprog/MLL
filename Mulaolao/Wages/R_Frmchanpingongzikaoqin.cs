using System;
using System . Data;
using System . Windows . Forms;
using Mulaolao . Class;
using System . Collections . Generic;

namespace Mulaolao . Wages
{
    public partial class R_Frmchanpingongzikaoqin : FormChild
    {
        public R_Frmchanpingongzikaoqin ( )
        {
            InitializeComponent( );
            
            GridViewMoHuSelect . SetFilter ( bandedGridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { this . bandedGridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        MulaolaoLibrary .ChanPinGongZiKaoQinLibrary model = new MulaolaoLibrary.ChanPinGongZiKaoQinLibrary( );
        MulaolaoBll.Bll.ChanPinGongZiKaoQinBll bll = new MulaolaoBll.Bll.ChanPinGongZiKaoQinBll( );
        SelectAll.BeingLoaded beLoad = new SelectAll.BeingLoaded( );
        DataTable tableQuery, nameTable, partTable;
        string bj = "", strWhere = "1=1", stateOfState = "",state="",queryWhere="";
        bool result = false;
        List<SplitContainer> spList = new List<SplitContainer>( );
        List<string> listQuery = new List<string>( ); SpecialPowers sp = new SpecialPowers( );
        
        private void R_Frmchanpingongzikaoqin_Load ( object sender ,EventArgs e )
        {
            Power( this );

            spList.Clear( );
            spList.Add( splitContainer1 );
            Ergodic.SpliClear( spList );
            gridControl1.DataSource = null;
            Ergodic.SpliEnableFalse( spList );
            lookUpEdit1.Properties.ShowHeader = false;
            lookUpEdit2.Properties.ShowHeader = false;
            //lookUpEdit3.Properties.ShowHeader = false;
            lookUpEdit4.Properties.ShowHeader = false;
            lookUpEdit5.Properties.ShowHeader = false;
             
            nameTable = bll.GetDataTableOne( );
            lookUpEdit4.Properties.DataSource = nameTable;
            lookUpEdit4.Properties.DisplayMember = "DBA002";
            lookUpEdit4.Properties.ValueMember = "DBA001";

            DataTable dr = bll . GetDataTableLeader ( );
            lookUpEdit5 . Properties . DataSource = dr;
            lookUpEdit5 . Properties . DisplayMember = "DBA002";
            lookUpEdit5 . Properties . ValueMember = "DBA001";
            
            DataTable de = bll . GetDataTableLeaderY ( );
            lookUpEdit2 . Properties . DataSource = de;
            lookUpEdit2 . Properties . DisplayMember = "DBA002";
            lookUpEdit2 . Properties . ValueMember = "DBA001";

            GridViewMoHuSelect .SetFilter( bandedGridView1 );
        }
        
        private void R_Frmchanpingongzikaoqin_Shown ( object sender ,EventArgs e )
        {
            model.GZ29 = Merges.oddNum;
            if ( model.GZ29 != null && model.GZ29 != "" )
                autoQuery( );
            Merges.oddNum = "";
        }
        
        #region Query        
        string cd = "";
        void assignMentAll ( )
        {
            if ( listQuery == null || listQuery.Count < 0 )
            {
                strWhere = "1=1";
                strWhere = strWhere + " AND GZ29='" + model.GZ29 + "'";
            }
            else if(state!="queryAll")
            {
                strWhere = "1=1";
                string str = "''";
                foreach ( string item in listQuery )
                {
                    if ( !string.IsNullOrEmpty( item ) )
                        str = str + ",'" + item + "'";
                }
                strWhere = strWhere + " AND A.idx IN (" + str + ")";
            }
            queryWhere = strWhere;
            refresh( );

            if ( tableQuery != null && tableQuery . Rows . Count > 0 )
            {
                model . Idx = string . IsNullOrEmpty ( tableQuery . Rows [ 0 ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableQuery . Rows [ 0 ] [ "idx" ] . ToString ( ) );
                assignMent ( );
            }

            listQuery.Clear( );

            //beLoad.Close( );
            //beLoad.Dispose( );
        }
        void autoQuery ( )
        {
            //text.SpessOfProgress sp = new text.SpessOfProgress( );
            bool ok = this.Do( );
            this.BeginInvoke( new System.Threading.ThreadStart( delegate ( )
            {
                if ( ok )
                {
                    bj = "1";

                    Ergodic.SpliEnableFalse( spList );

                    toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = true;
                    toolSave.Enabled = toolCancel.Enabled = false;

                    assignMentAll( );
                }
            } ) );
        }
        protected override void select ( )
        {
            base . select ( );

            SelectAll . ChanPinGongZiKaoQinAll query = new SelectAll . ChanPinGongZiKaoQinAll ( );
            model = new MulaolaoLibrary . ChanPinGongZiKaoQinLibrary ( );
            cd = "1";
            query . nameOfTj = Logins . number;
            query . StartPosition = FormStartPosition . CenterScreen;
            //query . PassDataBetweenForm += new SelectAll . ChanPinGongZiKaoQinAll . PassDataBetweenFormHandler ( query_PassDataBetweenForm );
            if ( query . ShowDialog ( ) == DialogResult . OK )
            {
                listQuery = query . strList;
                state = model . GZ29 = query . getCn1;
                model . GZ23 = query . getCn2;
            //}

            //if ( string . IsNullOrEmpty ( model . GZ29 ) && listQuery . Count <= 0 && state == string . Empty )
            //    MessageBox . Show ( "您没有选择任何信息" );
            //else
            //{
                //beLoad.StartPosition = FormStartPosition.CenterScreen;
                //beLoad.ShowDialog( );
                //加载线程
                System . Threading . Thread thread = new System . Threading . Thread ( new System . Threading . ThreadStart ( this . autoQuery ) );
                thread . Start ( );
            }
            //autoQuery( );
        }
        bool Do ( )
        {
            //等待1s再加载数据
            System.Threading.Thread.Sleep( 5 );
            return true;
        }
        private void query_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            eQuery( e );
        }
        void eQuery (PassDataWinFormEventArgs e )
        {
            state = "";
            if ( cd == "1" )
            {
                if ( e . List != null && e . List . Count >= 0 )
                {
                    listQuery = e . List;
                }
                else if ( e . ConOne != "queryAll" )
                {
                    model . GZ29 = e . ConOne;
                    model . GZ23 = e . ConTwo;
                }
                else
                    state = e . ConOne;
            }
            else if ( cd == "2" )
            {
                model.GZ01 = e.ConOne;
                textBox3.Text = e.ConOne;
                model.GZ22 = e.ConTre;
                textBox2.Text = e.ConTre;

                model.GZ23 = e.ConTwo;
                textBox1.Text = e.ConTwo;

                model.GZ34 = string.IsNullOrEmpty( e.ConFor ) == true ? 0 : Convert.ToInt64( e.ConFor );
                textBox21.Text = e.ConFor;
            }
        }
        private void button4_Click ( object sender ,EventArgs e )
        {
            SelectAll.ChangPingGongZiKaoQingAll queryAll = new SelectAll.ChangPingGongZiKaoQingAll( );
            cd = "2";
            queryAll.PassDataBetweenForm += new SelectAll.ChangPingGongZiKaoQingAll.PassDataBetweenFormHandler( query_PassDataBetweenForm );
            queryAll.StartPosition = FormStartPosition.CenterScreen;
            queryAll.ShowDialog( );
        }
        #endregion

        #region Event
        void assign ( )
        {
            if ( string.IsNullOrEmpty( model.GZ01 ) )
                model.GZ01 = "";
            partTable = null;
            if ( model . GZ01 != "" && Convert . ToInt64 ( model . GZ01 ) < Convert . ToInt64 ( "16080100" ) )
            {
                //零件名称==》509
                partTable = bll . GetDataTableWork ( model . GZ01 );
                lookUpEdit3 . Properties . DataSource = partTable;
                lookUpEdit3 . Properties . DisplayMember = "GZ03";
                lookUpEdit3 . Properties . ValueMember = "idx";

                //工序名称==》工序BOM
                lookUpEdit1 . Properties . DataSource = new DataView ( bll . GetDataTableBom ( ) ) . ToTable ( true ,"GX02" );
                lookUpEdit1 . Properties . DisplayMember = "GX02";
            }
            else
            {
                //零件名称==》509
                partTable = bll . GetDataTableWorkProcedure ( model . GZ01 );
                lookUpEdit3 . Properties . DataSource = partTable;
                lookUpEdit3 . Properties . DisplayMember = "GZ03";
                lookUpEdit3 . Properties . ValueMember = "idx";

                
            }
            ////lookUpEdit3.Properties.Columns[0].Caption = "编号";
            ////lookUpEdit3.Properties.Columns[1].Caption = "零件名称";
            ////lookUpEdit3.Properties.Columns[2].Caption = "零件数量";
            ////lookUpEdit3.Properties.Columns[3].Caption = "工序";
            ////lookUpEdit3.Properties.Columns[4].Caption = "计划单价";
            //lookUpEdit3.Properties.Columns[0].Width = 20;
            //lookUpEdit3.Properties.Columns[1].Width = 40;
            //lookUpEdit3.Properties.Columns[2].Width = 20;
            //lookUpEdit3.Properties.Columns[3].Width = 40;
            //lookUpEdit3.Properties.Columns[4].Width = 20;
        }
        private void lookUpEdit3_EditValueChanged ( object sender ,EventArgs e )
        {
            if ( model.GZ01 != "" && Convert.ToInt64( model.GZ01 ) < Convert.ToInt64( "16080100" ) )
            {
                if ( lookUpEdit3.EditValue != null && partTable.Select( "idx='" + lookUpEdit3.EditValue.ToString( ) + "'" ).Length > 0 )
                    textBox4.Text = partTable.Select( "idx='" + lookUpEdit3.EditValue.ToString( ) + "'" )[0]["GS"].ToString( );
            }
            else
            {
                if ( lookUpEdit3.EditValue != null && partTable.Select( "idx='" + lookUpEdit3.EditValue.ToString( ) + "'" ).Length > 0 )
                {
                    textBox4.Text = partTable.Select( "idx='" + lookUpEdit3.EditValue.ToString( ) + "'" )[0]["GS"].ToString( );
                    lookUpEdit1.Text = partTable.Select( "idx='" + lookUpEdit3.EditValue.ToString( ) + "'" )[0]["GX02"].ToString( );
                    textBox5.Text = partTable.Select( "idx='" + lookUpEdit3.EditValue.ToString( ) + "'" )[0]["DS1"].ToString( );
                }
            }
        }
        private void textBox3_TextChanged ( object sender ,EventArgs e )
        {
            model.GZ01 = textBox3.Text;
            assign( );
        }
        private void textBox1_TextChanged ( object sender ,EventArgs e )
        {

        }
        //工序
        private void comboBox2_SelectedValueChanged ( object sender ,EventArgs e )
        {
            model.GZ04 = lookUpEdit1.Text;
            model.GZ03 = lookUpEdit3.Text;
            DataTable del = bll.GetDataTableProcess( model );
            if ( del.Rows.Count > 0 )
                textBox5.Text = del.Rows[0]["DS07"].ToString( );
            else
                textBox5.Text = 0.ToString( );
        }
        //表格
        string gz3 = "", gz4 = "", stateOf = "";
        private void bandedGridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( bandedGridView1.FocusedRowHandle >= 0 && bandedGridView1.FocusedRowHandle <= bandedGridView1.RowCount - 1 )
            {
                if ( !string.IsNullOrEmpty( bandedGridView1.GetFocusedRowCellValue( "idx" ).ToString( ) ) )
                {
                    model.Idx = Convert.ToInt32( bandedGridView1.GetFocusedRowCellValue( "idx" ).ToString( ) );
                    assignMent( );
                }
            }
        }
        void assignMent ( )
        {
            model = bll.GetModel( model.Idx );
           
            textBox3.Text = model.GZ01;
            //textBox19.Text = model.GZ05.ToString( );
            textBox16.Text = model.GZ06.ToString( );
            textBox20.Text = model.GZ07;
            textBox18.Text = model.GZ08.ToString( );
            textBox7.Text = model.GZ09.ToString( );
            textBox8.Text = model.GZ10.ToString( );
            textBox9.Text = model.GZ11.ToString( );
            textBox10.Text = model.GZ12.ToString( );
            textBox11.Text = model.GZ13.ToString( );
            textBox12.Text = model.GZ14.ToString( );
            //textBox17.Text = model.GZ15.ToString( );         
            dateTimePicker1.Value = ( string.IsNullOrEmpty( model.GZ35.ToString( ) ) && string.IsNullOrEmpty( model.GZ17.ToString( ) ) && string.IsNullOrEmpty( model.GZ24.ToString( ) ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( model.GZ35.ToString( ) + "年" + model.GZ24.ToString( ) + "月" + model.GZ17.ToString( ) + "日" );
            textBox6.Text = model.GZ18;
            //textBox15.Text = model.GZ19.ToString( );
            textBox2.Text = model.GZ22;
            textBox1.Text = model.GZ23;
            textBox13.Text = model.GZ25.ToString( );
            textBox14.Text = model.GZ26.ToString( );
            textBox5.Text = model.GZ27.ToString( );
            if ( model.GZ28 == 0 )
                dateTimePicker2.Value = MulaolaoBll . Drity . GetDt ( );
            else
                dateTimePicker2.Value = string.IsNullOrEmpty( model.GZ28.ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( model.GZ28.ToString( ) + "月" );
            textBox22.Text = model.GZ28.ToString( ) + "月";
            textBox21.Text = model.GZ34.ToString( );
            textBox23.Text = model.GZ36.ToString( );


            lookUpEdit3.Text = model.GZ03;
            lookUpEdit1.Text = model.GZ04;
            lookUpEdit4.Text = model.GZ30;
            lookUpEdit5.Text = model.GZ16;
            lookUpEdit2.Text = model.GZ02;
            lookUpEdit6.Text = model.GZ37;

            gz3 = model.GZ03;
            gz4 = model.GZ04;
            stateOf = model.GZ39;
        }
        //车间主任
        private void lookUpEdit4_EditValueChanged ( object sender ,EventArgs e )
        {

            lookUpEdit6.Properties.DataSource = bll.GetDataTableSta( );
            lookUpEdit6.Properties.DisplayMember = "DBA002";
            lookUpEdit6.Properties.ValueMember = "DBA001";

            //DataTable de = bll.GetDataTableLeader( lookUpEdit4.Text );
            //lookUpEdit2.Properties.DataSource = de;
            //lookUpEdit2.Properties.DisplayMember = "DBA002";
            //lookUpEdit2.Properties.ValueMember = "DBA001";
        }
        //组长
        private void lookUpEdit5_EditValueChanged ( object sender ,EventArgs e )
        {
            

        }
        //计时标准日资
        private void comboBox13_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //计时量
        private void textBox14_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //计件量
        private void textBox13_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //结算工资
        private void comboBox17_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //计价单价
        private void textBox16_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox16 );
        }
        private void textBox16_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox16.Text != "" && !DateDayRegise.sevenFourTb( textBox16 ) )
            {
                this.textBox16.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多四位,如999.9999,请重新输入" );
            }
        }
        private void textBox16_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox16 );
        }
        //合格率
        private void textBox18_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox18 );
        }
        private void textBox18_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox18.Text != "" && !DateDayRegise.foreOneNum( textBox18 ) )
            {
                this.textBox18.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多一位,如999.9,请重新输入" );
            }
        }
        private void textBox18_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox18 );
        }
        //上午计件
        private void textBox7_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox7 );
        }
        private void textBox7_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox7 );
        }
        private void textBox7_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox7.Text != "" && !DateDayRegise.foreTwoNum( textBox7 ) )
            {
                this.textBox7.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多两位,如99.99,请重新输入" );
            }
        }
        //下午
        private void textBox8_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox8 );
        }
        private void textBox8_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox8 );
        }
        private void textBox8_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox8.Text != "" && !DateDayRegise.foreTwoNum( textBox8 ) )
            {
                this.textBox8.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多两位,如99.99,请重新输入" );
            }
        }
        //晚上
        private void textBox9_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox9 );
        }
        private void textBox9_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox9 );
        }
        private void textBox9_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox9.Text != "" && !DateDayRegise.foreTwoNum( textBox9 ) )
            {
                this.textBox9.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多两位,如99.99,请重新输入" );
            }
        }
        //上午计时
        private void textBox10_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox10 );
        }
        private void textBox10_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox10 );
        }
        private void textBox10_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox10.Text != "" && !DateDayRegise.foreTwoNum( textBox10 ) )
            {
                this.textBox10.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多两位,如99.99,请重新输入" );
            }
        }
        //下午
        private void textBox11_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox11 );
        }
        private void textBox11_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox11 );
        }
        private void textBox11_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox11.Text != "" && !DateDayRegise.foreTwoNum( textBox11 ) )
            {
                this.textBox11.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多两位,如99.99,请重新输入" );
            }
        }
        //晚上
        private void textBox12_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox12 );
        }
        private void textBox12_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox12 );
        }
        private void textBox12_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox12.Text != "" && !DateDayRegise.foreTwoNum( textBox12 ) )
            {
                this.textBox12.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多两位,如99.99,请重新输入" );
            }
        }
        //电子日工时
        private void textBox15_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox15 );
        }
        private void textBox15_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox15 );
        }
        private void textBox15_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox15.Text != "" && !DateDayRegise.foreTwoNum( textBox15 ) )
            {
                this.textBox15.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多两位,如99.99,请重新输入" );
            }
        }
        //窗体
        private void R_Frmchanpingongzikaoqin_FormClosing ( object sender ,FormClosingEventArgs e )
        {
            if ( toolSave.Enabled )
            {
                cancel( );
            }
        }
        private void lookUpEdit1_EditValueChanged ( object sender ,EventArgs e )
        {
            DataTable price = bll.GetDataTablePrice( lookUpEdit1.Text );
            if ( price != null && price.Rows.Count > 0 )
            {
                textBox19.Text = price.Rows[0]["GX03"].ToString( );
            }


            //textBox19.Text = lookUpEdit1.EditValue.ToString( );
        }
        private void dateTimePicker2_ValueChanged ( object sender ,EventArgs e )
        {
            textBox22.Text = this.dateTimePicker2.Value.ToString( "MM" ) + "月";
        }
        private void textBox22_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            if ( e.KeyChar == 8 )
            {
                textBox22.Text = "";
            }
            else
            {
                e.Handled = true;
            }
        }
        private void textBox23_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox23 );
        }
        private void textBox23_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox23 );
        }
        private void textBox23_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox23.Text != "" && !DateDayRegise.fiveOneNum( textBox23 ) )
            {
                this.textBox23.Text = "";
                MessageBox.Show( "只允许输入整数部分最多四位,小数部分最多一位,如9999.9,请重新输入" );
            }
        }
        private void bandedGridView1_ColumnFilterChanged ( object sender ,EventArgs e )
        {
            assignSummary( );
        }
        //零件名称
        private void lookUpEdit3_TextChanged ( object sender ,EventArgs e )
        {
            model . GZ03 = lookUpEdit3 . Text;
            //工序名称==》工序BOM
            DataTable tableOne = bll . GetDataTableBom ( model . GZ01 ,model . GZ03 );
            if ( tableOne == null && tableOne . Rows . Count < 1 )
                return;
            DataView dv = new DataView ( tableOne );
            lookUpEdit1 . Properties . DataSource = dv . ToTable ( true ,"TAB" ,"GX02" );
            lookUpEdit1 . Properties . DisplayMember = "GX02";
        }
        #endregion

        #region Main
        protected override void add ( )
        {
            base.add( );

            Ergodic.SpliClear( spList );
            gridControl1.DataSource = null;
            Ergodic.SpliEnableTrue( spList );

            bj = "2";

            model.GZ29 = oddNumbers.purchaseContract( "SELECT MAX(AJ013) AJ013 FROM R_PQAJ" ,"AJ013" ,"R_317-" );

            strWhere = "1=2";
            refresh ( );

            toolSelect .Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
            //tableQuery = null;
        }
        void dele ( )
        {
            if ( MessageBox.Show( "确认删除?" ,"确认" ,MessageBoxButtons.OKCancel ,MessageBoxIcon.Question ) == DialogResult.OK )
            { 
                if ( bj == "1" )
                    stateOfState = "更改删除";
                else
                    stateOfState = "新增删除";
                result = bll.DeleteOddNum( model.GZ29 ,"R_317" ,"产品工资考勤表" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"删除" ,stateOfState );

                if ( result == false )
                    MessageBox.Show( "删除数据失败" );
                else
                {
                    MessageBox.Show( "成功删除数据" );

                    Ergodic.SpliClear( spList );
                    gridControl1.DataSource = null;
                    Ergodic.SpliEnableFalse( spList );
                    tableQuery = null;
                    toolSelect.Enabled = toolAdd.Enabled = toolPrint.Enabled = toolExport.Enabled = true;
                    toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolSave.Enabled = toolCancel.Enabled = false;
                    try
                    {
                        bll.DeleteReview( "R_317" ,model.GZ29 );
                    }
                    catch { }
                }
            }
        }
        protected override void delete ( )
        {
            base.delete( );

            result = bll.ExistsReview( model.GZ29 );

            if ( result == true )
                MessageBox.Show( "单号:" + model.GZ29 + "的单据中存在记录状态为执行的记录,不能删除" );
            else
                dele( );
        }
        protected override void update ( )
        {
            base.update( );


            Ergodic.SpliEnableTrue( spList );
            bj = "1";
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
        }
        protected override void revirw ( )
        {
            base.revirw( );

            Reviews( "GZ29" ,model.GZ29 ,"R_PQW" ,this ,"" ,"R_317" ,false ,false,MulaolaoBll . Drity . GetDt ( )/* ,"" ,"" ,"" ,"" ,"" ,"" ,"","R_317"*/ );
        }
        protected override void print ( )
        {
            base.print( );
        }
        protected override void save ( )
        {
            base.save( );
            Ergodic.SpliEnableFalse( spList );

            toolSelect.Enabled = toolAdd.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolReview.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;

            bj = "";
        }
        protected override void cancel ( )
        {
            base.cancel( );

            if ( bj == "1" )
            {
                Ergodic.SpliEnableFalse( spList );

                toolSelect.Enabled = toolAdd.Enabled = toolPrint.Enabled = toolExport.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolMaintain.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = false;
            }
            else if ( bj == "2" )
            {
                //try
                //{
                //    //bll.DeleteOddNum( model.GZ29 ,"R_317" ,"产品工资考勤表" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"删除" ,"新增取消" );
                //}
                //catch { }
                //finally
                //{
                    Ergodic.SpliClear( spList );
                    Ergodic.SpliEnableFalse( spList );
                    gridControl1.DataSource = null;
                    tableQuery = null;
                    toolSelect.Enabled = toolAdd.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = true;
                    toolSave.Enabled = toolCancel.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = false;
                    model . GZ29 = string . Empty;
                //}
            }
        }
        protected override void maintain ( )
        {
            base.maintain( );

            ////result = false;
            ////result = bll.ExistsReview( model.GZ29 ,"R_317" );

            //if ( /*result == true*/label45.Visible == true )
            //{
            //    toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolPrint.Enabled = toolExport.Enabled = false;
            //    toolCancel.Enabled = toolSave.Enabled = true;

            //    Ergodic.SpliEnableTrue( spList );

            //    weihu = "1";
            //    label45.Visible = true;
            //}
            //else
            //    MessageBox.Show( "此单据没有被执行,只需更改即可,无需维护" );
        }
        #endregion

        #region Table
        //Build
        DataRow row;
        bool oddOne ( )
        {
            DataTable dOddOnt = bll.GetDataTableOddOne( model.GZ02 ,model.GZ16,model.GZ37 );
            if ( dOddOnt.Rows.Count > 0 )
            {
                if ( dOddOnt.Select( "GZ29='" + model.GZ29 + "'" ).Length <= 0 )
                {
                    MessageBox.Show( "组长:" + model.GZ16 + "\n\r生产人:" + model.GZ02 + "\n\r统计员:"+model.GZ37+"已经存在另一单记录,请刷新" );
                    result = false;
                }
                else
                    result = true;
            }
            else
            {
                if (tableQuery!=null &&  tableQuery.Rows.Count > 0 )
                {
                    if ( tableQuery.Select( "GZ02='" + model.GZ02 + "' AND GZ16='" + model.GZ16 + "'" ).Length > 0 )
                        result = true;
                    else
                    {
                        MessageBox.Show( "组长:" + model.GZ16 + "\n\r生产人:" + model.GZ02 + "\n\r不允许新建此单,请刷新" );
                        result = false;
                    }
                }
                else
                    result = true;
            }
            return result;
        }
        void build ( )
        {
            model.GZ01 = textBox3.Text;
            model.GZ02 = lookUpEdit2.Text;
            model.GZ03 = lookUpEdit3.Text;
            model.GZ04 = lookUpEdit1.Text;
            model.GZ05 = string.IsNullOrEmpty( textBox19.Text ) == true ? 0 : Convert.ToInt32( textBox19.Text );
            model.GZ06 = string.IsNullOrEmpty( textBox16.Text ) == true ? 0 : Convert.ToDecimal( textBox16.Text );
            model.GZ07 = textBox20.Text;
            model.GZ08 = string.IsNullOrEmpty( textBox18.Text ) == true ? 0 : Convert.ToDecimal( textBox18.Text );
            model.GZ09 = string.IsNullOrEmpty( textBox7.Text ) == true ? 0 : Convert.ToDecimal( textBox7.Text );
            model.GZ10 = string.IsNullOrEmpty( textBox8.Text ) == true ? 0 : Convert.ToDecimal( textBox8.Text );
            model.GZ11 = string.IsNullOrEmpty( textBox9.Text ) == true ? 0 : Convert.ToDecimal( textBox9.Text );
            model.GZ12 = string.IsNullOrEmpty( textBox10.Text ) == true ? 0 : Convert.ToDecimal( textBox10.Text );
            model.GZ13 = string.IsNullOrEmpty( textBox11.Text ) == true ? 0 : Convert.ToDecimal( textBox11.Text );
            model.GZ14 = string.IsNullOrEmpty( textBox12.Text ) == true ? 0 : Convert.ToDecimal( textBox12.Text );
            //model.GZ15 = string.IsNullOrEmpty( textBox17.Text ) == true ? 0 : Convert.ToInt32( textBox17.Text );
            model.GZ16 = lookUpEdit5.Text;
            model.GZ17 = Convert.ToInt32( dateTimePicker1.Value.ToString( "dd" ) );
            model.GZ18 = textBox6.Text;
            //model.GZ19 = string.IsNullOrEmpty( textBox15.Text ) == true ? 0 : Convert.ToDecimal( textBox15.Text );
            model.GZ22 = textBox2.Text;
            model.GZ23 = textBox1.Text;
            model.GZ24 = Convert.ToInt32( dateTimePicker1.Value.ToString( "MM" ) );
            model.GZ25 = string.IsNullOrEmpty( textBox13.Text ) == true ? 0 : Convert.ToInt64( textBox13.Text );
            model.GZ26 = string.IsNullOrEmpty( textBox14.Text ) == true ? 0 : Convert.ToInt64( textBox14.Text );
            model.GZ27 = string.IsNullOrEmpty( textBox5.Text ) == true ? 0 : Convert.ToDecimal( textBox5.Text );
            //model.GZ28 = string.IsNullOrEmpty( textBox22.Text ) == true ? 0 : Convert.ToInt32( textBox22.Text.Substring( 0 ,textBox22.Text.Length - 1 ) );
            model.GZ30 = lookUpEdit4.Text;
            model.GZ31 = lookUpEdit4.EditValue.ToString( );
            model.GZ32 = lookUpEdit5.EditValue.ToString( );
            model.GZ33 = lookUpEdit2.EditValue.ToString( );
            model.GZ34 = string.IsNullOrEmpty( textBox21.Text ) == true ? 0 : Convert.ToInt64( textBox21.Text );
            model.GZ35 = dateTimePicker1.Value.ToString( "yyyy" );
            model.GZ36 = string.IsNullOrEmpty( textBox23.Text ) == true ? 0 : Convert.ToDecimal( textBox23.Text );
            model.GZ37 = lookUpEdit6.Text;
            model.GZ38 = lookUpEdit6.EditValue.ToString( );
            model.GZ40 = string.IsNullOrEmpty( textBox4.Text ) == true ? 0 : Convert.ToInt32( textBox4.Text );
            model.GZ43 = MulaolaoBll . Drity . GetDt ( );
        }
        private void button1_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( lookUpEdit2 . Text ) )
            {
                MessageBox . Show ( "生产人姓名不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( textBox3 . Text ) )
            {
                MessageBox . Show ( "流水号不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( lookUpEdit3 . Text ) )
            {
                MessageBox . Show ( "零件名称不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( lookUpEdit1 . Text ) )
            {
                MessageBox . Show ( "工序不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( lookUpEdit6 . Text ) )
            {
                MessageBox . Show ( "统计员不可为空" );
                return;
            }
            build ( );
            result = oddOne ( );
            if ( result == false )
                return;
            if ( ( model . GZ09 > 0 && model . GZ12 > 0 ) || ( model . GZ10 > 0 && model . GZ13 > 0 ) || ( model . GZ11 > 0 && model . GZ14 > 0 ) )
            {
                MessageBox . Show ( "上午和下午不能同时计件和计时,请更改" );
                return;
            }

            result = bll . Exists ( model );
            if ( result == true )
                MessageBox . Show ( "单号:" + model . GZ29 + "\n\r流水号:" + model . GZ01 + "\n\r月:" + model . GZ24 + "\n\r日:" + model . GZ17 + "\n\r零件名称:" + model . GZ03 + "\n\r工序:" + model . GZ04 + "\n\r的数据已经存在,请核实后再添加" );
            else
            {
                if ( bj . Equals ( "1" ) )
                    stateOfState = "更改新建";
                else
                    stateOfState = "新增新建";

                model . GZ42 = "新建";
                result = bll . Add ( model ,"R_317" ,"产品工资考勤表" ,Logins . username ,DateTime . Now ,"新建" ,stateOfState );
                if ( result == true )
                {
                    MessageBox . Show ( "录入数据成功" );
                    //strWhere = "1=1";
                    //strWhere = strWhere + " AND GZ29='" + model . GZ29 + "'";
                    //refresh ( );
                    add_view ( );
                }
                else
                    MessageBox . Show ( "录入数据失败" );
            }
        }
        void add_view ( )
        {
            row = tableQuery . NewRow ( );
            row [ "GZ01" ] = model . GZ01;
            row [ "GZ02" ] = model . GZ02;
            row [ "GZ03" ] = model . GZ03;
            row [ "GZ04" ] = model . GZ04;
            row [ "GZ05" ] = model . GZ05;
            row [ "GZ06" ] = model . GZ06;
            row [ "GZ07" ] = model . GZ07;
            row [ "GZ08" ] = model . GZ08;
            row [ "GZ09" ] = model . GZ09;
            row [ "GZ10" ] = model . GZ10;
            row [ "GZ11" ] = model . GZ11;
            row [ "GZ12" ] = model . GZ12;
            row [ "GZ13" ] = model . GZ13;
            row [ "GZ14" ] = model . GZ14;
            row [ "GZ16" ] = model . GZ16;
            row [ "GZ17" ] = model . GZ17;
            row [ "GZ18" ] = model . GZ18;
            row [ "GZ22" ] = model . GZ22;
            row [ "GZ23" ] = model . GZ23;
            row [ "GZ24" ] = model . GZ24;
            row [ "GZ25" ] = model . GZ25;
            row [ "GZ26" ] = model . GZ26;
            row [ "GZ27" ] = model . GZ27;
            row [ "GZ29" ] = model . GZ29;
            row [ "GZ30" ] = model . GZ30;
            row [ "GZ31" ] = model . GZ31;
            row [ "GZ32" ] = model . GZ32;
            row [ "GZ33" ] = model . GZ33;
            row [ "GZ34" ] = model . GZ34;
            row [ "GZ35" ] = model . GZ35;
            row [ "GZ36" ] = model . GZ36;
            row [ "GZ37" ] = model . GZ37;
            row [ "GZ38" ] = model . GZ38;
            row [ "GZ40" ] = model . GZ40;
            row [ "GZ44" ] = model . GZ44;
            tableQuery . Rows . Add ( row );
            gridControl1 . RefreshDataSource ( );
        }
        //Edit
        void edi ( )
        {
            int num = bandedGridView1 . FocusedRowHandle;
            DataRow row = tableQuery . Rows [ num ];
            row . BeginEdit ( );
            row [ "GZ01" ] = model . GZ01;
            row [ "GZ02" ] = model . GZ02;
            row [ "GZ03" ] = model . GZ03;
            row [ "GZ04" ] = model . GZ04;
            row [ "GZ05" ] = model . GZ05;
            row [ "GZ06" ] = model . GZ06;
            row [ "GZ07" ] = model . GZ07;
            row [ "GZ08" ] = model . GZ08;
            row [ "GZ09" ] = model . GZ09;
            row [ "GZ10" ] = model . GZ10;
            row [ "GZ11" ] = model . GZ11;
            row [ "GZ12" ] = model . GZ12;
            row [ "GZ13" ] = model . GZ13;
            row [ "GZ14" ] = model . GZ14;
            row [ "GZ16" ] = model . GZ16;
            row [ "GZ17" ] = model . GZ17;
            row [ "GZ18" ] = model . GZ18;
            row [ "GZ22" ] = model . GZ22;
            row [ "GZ23" ] = model . GZ23;
            row [ "GZ24" ] = model . GZ24;
            row [ "GZ25" ] = model . GZ25;
            row [ "GZ26" ] = model . GZ26;
            row [ "GZ27" ] = model . GZ27;
            //row["GZ28"] = model.GZ28;
            row [ "GZ30" ] = model . GZ30;
            row [ "GZ31" ] = model . GZ31;
            row [ "GZ32" ] = model . GZ32;
            row [ "GZ33" ] = model . GZ33;
            row [ "GZ34" ] = model . GZ34;
            row [ "GZ36" ] = model . GZ36;
            row [ "GZ37" ] = model . GZ37;
            row [ "GZ38" ] = model . GZ38;
            row . EndEdit ( );
            gridControl1 . RefreshDataSource ( );
            //gridControl1 . DataSource = null;
            //gridControl1 . DataSource = tableQuery;
            assignMent ( );
            bandedGridView1 . FocusedRowHandle = num;
        }
        void edit ( )
        {
            if ( bandedGridView1.GetDataRow( bandedGridView1.FocusedRowHandle )["GZ02"].ToString( ) != lookUpEdit2.Text )
            {
                MessageBox.Show( "生产人:" + bandedGridView1.GetDataRow( bandedGridView1.FocusedRowHandle )["GZ02"].ToString( ) + "不存在,不允许编辑" );
                return;
            }
            if ( ( model.GZ09 > 0 && model.GZ12 > 0 ) || ( model.GZ10 > 0 && model.GZ13 > 0 ) || ( model.GZ11 > 0 && model.GZ14 > 0 ) )
            {
                MessageBox.Show( "上午和下午不能同时计件和计时,请更改" );
                return;
            }
            TimeSpan ts = MulaolaoBll . Drity . GetDt ( ) - dateTimePicker1 . Value;
            if ( ts . Days > 3 )
            {
                if ( Logins . number == "MLL-0001" || Logins . number == "MLL-0008" )
                {
                    result = bll . ExistsIdx ( model );
                    if ( result == true )
                        MessageBox . Show ( "单号:" + model . GZ29 + "\n\r流水号:" + model . GZ01 + "\n\r月:" + model . GZ24 + "\n\r日:" + model . GZ17 + "\n\r零件名称:" + model . GZ03 + "\n\r工序:" + model . GZ04 + "\n\r的数据已经存在,请核实后再添加" );
                    else
                    {
                        result = bll . Update ( model ,"R_317" ,"产品工资考勤表" ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,"编辑" ,stateOfState );
                        if ( result == false )
                            MessageBox . Show ( "编辑数据失败" );
                        else
                        {
                            MessageBox . Show ( "成功编辑数据" );
                            edi ( );
                        }
                    }
                }
                else
                    MessageBox . Show ( "距考核日期已经超过3天,您无权修改此记录,需要总经理或张伟芳修改" );
            }
            else
            {
                result = bll.ExistsIdx( model );
                if ( result == true )
                    MessageBox.Show( "单号:" + model.GZ29 + "\n\r流水号:" + model.GZ01 + "\n\r月:" + model.GZ24 + "\n\r日:" + model.GZ17 + "\n\r零件名称:" + model.GZ03 + "\n\r工序:" + model.GZ04 + "\n\r的数据已经存在,请核实后再添加" );
                else
            {
                if ( bj == "1" )
                    stateOfState = "更改编辑";
                else
                    stateOfState = "新增编辑";
                result = bll.Update( model ,"R_317" ,"产品工资考勤表" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"编辑" ,stateOfState );
                    if ( result == false )
                        MessageBox.Show( "编辑数据失败" );
                    else
                    {
                        MessageBox.Show( "成功编辑数据" );
                        edi( );
                    }
                }
            }
        }
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( lookUpEdit2.Text ) )
            {
                MessageBox.Show( "生产人姓名不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox3.Text ) )
            {
                MessageBox.Show( "流水号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( lookUpEdit3.Text ) )
            {
                MessageBox.Show( "零件名称不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( lookUpEdit1.Text ) )
            {
                MessageBox.Show( "工序不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( lookUpEdit6.Text ) )
            {
                MessageBox.Show( "统计员不可为空" );
                return;
            }
            build( );
            //if ( isZero( ) == false )
            //    return;
            result = oddOne( );
            model.GZ42 = "编辑";
            if ( result == false )
                return;
            if ( !string.IsNullOrEmpty( stateOf ) && stateOf.Trim( ) == "执行" )
            {
                if ( Logins.number == "MLL-0001" )
                    edit( );
                else
                    MessageBox.Show( "只有总经理有权限编辑已经执行的记录" );
            }
            else
                edit( );
        }
        //Delete
        void deles ( )
        {
            //TimeSpan ts = MulaolaoBll . Drity . GetDt ( ) - dateTimePicker1.Value;
            //if ( ts.Days > 3 )
            //{
            //    if ( Logins.number == "MLL-0001" || Logins.number == "MLL-0008" )
            //    {
            //        result = bll.Delete( model );
            //        if ( result == true )
            //        {
            //            MessageBox.Show( "删除数据成功" );
            //            strWhere = "1=1";
            //            strWhere = strWhere + " AND GZ29='" + model.GZ29 + "'";
            //            refresh( );
            //        }
            //        else
            //            MessageBox.Show( "删除数据失败,请刷新" );
            //    }
            //    else
            //        MessageBox.Show( "距考核日期已经超过3天,您无权删除此记录,需要总经理或张伟芳删除" );
            //}
            //else
            //{
            if ( bj == "1" )
                stateOfState = "更改删除";
            else
                stateOfState = "新增删除";
            result = bll.Delete( model ,"R_317" ,"产品工资考勤表" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"删除" ,stateOfState );
            if ( result == true )
            {
                MessageBox.Show( "删除数据成功" );
                strWhere = "1=1";
                strWhere = strWhere + " AND GZ29='" + model.GZ29 + "'";
                refresh( );
            }
            else
                MessageBox.Show( "删除数据失败,请刷新" );
            //}
        }
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) ==
DialogResult . Cancel )
                return;
            if ( !string.IsNullOrEmpty( stateOf ) && stateOf.Trim( ) == "执行" )
            {
                if ( Logins.number == "MLL-0001" )
                    deles( );
                else
                    MessageBox.Show( "只有总经理有权限删除已经执行的记录" );
            }
            else
                deles( );
        }
        //batchEdit       
        string sign = "",dhCheck="",gxCheck="";
        private void button6_Click_1 ( object sender ,EventArgs e )
        {
            SelectAll.ChanPinGongZiKaiQinBatchEdit batch = new SelectAll.ChanPinGongZiKaiQinBatchEdit( );
            batch.StartPosition = FormStartPosition.CenterScreen;
            batch.PassDataBetweenForm += new SelectAll.ChanPinGongZiKaiQinBatchEdit.PassDataBetweenFormHandler( batch_PassDataBetweenForm );
            //batch.textBox1.Text = textBox22.Text;
            //if ( lookUpEdit3.Text != model.GZ03 )
            //{
            //    MessageBox.Show( "部件名称有误,请核实" );
            //    return;
            //}
            model . GZ03 = lookUpEdit3 . Text;
            batch.textBox3.Text = lookUpEdit3.Text;
            batch.num= textBox3.Text;
            //if ( textBox16.Text != model.GZ06.ToString( ) )
            //{
            //    MessageBox.Show( "计件单价有误,请核实" );
            //    return;
            //}
            model . GZ06 = string . IsNullOrEmpty ( textBox16 . Text ) == true ? 0 : Convert . ToDecimal ( textBox16 . Text );
            batch.textBox4.Text = textBox16.Text;
            //if ( lookUpEdit1.Text != model.GZ04 )
            //{
            //    MessageBox.Show( "工序有误,请核实" );
            //    return;
            //}
            model . GZ04 = lookUpEdit1 . Text;
            batch.textBox6.Text = lookUpEdit1.Text;
            batch.textBox2.Text = textBox3.Text;
            batch.oddNum = model.GZ29;
            batch.signOf = bj;
            batch.logins = Logins.username;
            batch.ShowDialog( );

            if ( !string.IsNullOrEmpty( sign ) )
            {
                model.GZ01 = textBox3.Text;

                if ( sign == "2" )
                {
                    if ( bj == "1" )
                        stateOfState = "更改批量编辑部件名称";
                    else
                        stateOfState = "新增批量编辑部件名称";
                    result = bll . UpdateBatchPro ( model . GZ01 ,model . GZ29 ,model . GZ03 ,"R_317" ,"产品工资考勤表" ,Logins . username ,DateTime . Now ,"批量编辑" ,stateOfState ,lookUpEdit3 . Text ,lookUpEdit1 . Text ,dhCheck ,gxCheck );
                    if ( result == true )
                    {
                        MessageBox.Show( "批量编辑部件名称成功" );
                        edit_batch ( );
                        //strWhere = "1=1";
                        //strWhere = strWhere + " AND GZ29='" + model.GZ29 + "'";
                        //refresh( );
                    }
                    else
                        MessageBox.Show( "批量编辑部件名称失败" );
                }
                else if ( sign == "3" )
                {
                    if ( bj == "1" )
                        stateOfState = "更改批量编辑工序实际单价";
                    else
                        stateOfState = "新增批量编辑工序实际单价";
                    model.GZ03 = lookUpEdit3.Text;
                    model.GZ04 = lookUpEdit1.Text;
                    result = bll.UpdateBatchPrice( model.GZ06 ,model.GZ01 ,model.GZ03 ,model.GZ04 ,model.GZ29 ,"R_317" ,"产品工资考勤表" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"批量编辑" ,stateOfState );
                    if ( result == true )
                    {
                        MessageBox.Show( "批量编辑工序实际单价成功" );
                        edit_batch_price ( );
                        //strWhere = "1=1";
                        //strWhere = strWhere + " AND GZ29='" + model.GZ29 + "'";
                        //refresh( );
                    }
                    else
                        MessageBox.Show( "批量编辑工序实际单价失败" );
                }
                else if ( sign == "4" )
                {
                    if ( bj == "1" )
                        stateOfState = "更改批量编辑工序";
                    else
                        stateOfState = "新增批量编辑工序";
                    model.GZ03 = lookUpEdit3.Text;
                    result = bll.UpdateBarchWork( lookUpEdit1.Text ,model.GZ04 ,model.GZ01 ,model.GZ03 ,model.GZ29 ,"R_317" ,"产品工资考勤表" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"批量编辑" ,stateOfState );
                    if ( result == true )
                    {
                        MessageBox.Show( "批量编辑工序成功" );
                        edit_batch_gx ( );
                        //strWhere = "1=1";
                        //strWhere = strWhere + " AND GZ29='" + model.GZ29 + "'";
                        //refresh( );
                    }
                    else
                        MessageBox.Show( "批量编辑工序失败" );
                }
            }
            sign = "";
        }
        private void batch_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            if ( !string.IsNullOrEmpty( e.ConTwo ) )
            {
                if ( e.ConTwo == "1" )
                {
                    sign = "1";
                    model.GZ28 = string.IsNullOrEmpty( e.ConOne ) == true ? 0 : Convert.ToInt32( e.ConOne );
                }
                else if ( e.ConTwo == "2" )
                {
                    sign = "2";
                    model.GZ03 = string.IsNullOrEmpty( e.ConOne ) == true ? string.Empty : e.ConOne;
                    dhCheck = e . ConTre;
                    gxCheck = e . ConFor;
                }
                else if ( e.ConTwo == "3" )
                {
                    sign = "3";
                    model.GZ06 = string.IsNullOrEmpty( e.ConOne ) == true ? 0M : Convert.ToDecimal( e.ConOne );
                }
                else if ( e.ConTwo == "4" )
                {
                    sign = "4";
                    model.GZ04 = string.IsNullOrEmpty( e.ConOne ) == true ? string.Empty : e.ConOne;
                }
            }
            else
                sign = "";
        }
        void edit_batch ( )
        {
            for ( int i = 0 ; i < bandedGridView1 . DataRowCount ; i++ )
            {
                row = bandedGridView1 . GetDataRow ( i );
                if ( row [ "GZ01" ] . ToString ( ) . Equals ( model . GZ01 ) && row [ "GZ03" ] . ToString ( ) . Equals ( lookUpEdit3 . Text ) )
                {
                    row = tableQuery . Rows [ i ];
                    row . BeginEdit ( );
                    row [ "GZ03" ] = model . GZ03;
                    row . BeginEdit ( );
                }
            }

            gridControl1 . RefreshDataSource ( );
        }
        void edit_batch_gx ( )
        {
            for ( int i = 0 ; i < bandedGridView1 . DataRowCount ; i++ )
            {
                row = bandedGridView1 . GetDataRow ( i );
                if ( row [ "GZ01" ] . ToString ( ) . Equals ( model . GZ01 ) && row [ "GZ03" ] . ToString ( ) . Equals ( model . GZ03 ) && row [ "GZ04" ] . ToString ( ) . Equals ( lookUpEdit1 . Text ) )
                {
                    row = tableQuery . Rows [ i ];
                    row . BeginEdit ( );
                    row [ "GZ04" ] = model . GZ04;
                    row . BeginEdit ( );
                }
            }

            gridControl1 . RefreshDataSource ( );
        }
        void edit_batch_price ( )
        {
            for ( int i = 0 ; i < bandedGridView1 . DataRowCount ; i++ )
            {
                row = bandedGridView1 . GetDataRow ( i );
                if ( row [ "GZ01" ] . ToString ( ) . Equals ( model . GZ01 ) && row [ "GZ03" ] . ToString ( ) . Equals ( model . GZ03 ) && row [ "GZ04" ] . ToString ( ) . Equals ( model . GZ04 ) )
                {
                    row = tableQuery . Rows [ i ];
                    row . BeginEdit ( );
                    row [ "GZ06" ] = model . GZ06;
                    row . BeginEdit ( );
                }
            }

            gridControl1 . RefreshDataSource ( );
        }
        //Refresh
        private void btnRefreTJ_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( lookUpEdit4 . Text ) )
                strWhere = strWhere + " AND GZ30='" + lookUpEdit4 . Text + "'";
            if ( !string . IsNullOrEmpty ( lookUpEdit5 . Text ) )
                strWhere = strWhere + " AND GZ16='" + lookUpEdit5 . Text + "'";
            if ( !string . IsNullOrEmpty ( lookUpEdit6 . Text ) )
                strWhere = strWhere + " AND GZ37='" + lookUpEdit6 . Text + "'";
            if ( !string . IsNullOrEmpty ( lookUpEdit2 . Text ) )
                strWhere = strWhere + " AND GZ02='" + lookUpEdit2 . Text + "'";
            refresh ( );

            nameTable = bll . GetDataTableOne ( );
            lookUpEdit4 . Properties . DataSource = nameTable;
            lookUpEdit4 . Properties . DisplayMember = "DBA002";
            lookUpEdit4 . Properties . ValueMember = "DBA001";

            DataTable dr = bll . GetDataTableLeader ( );
            lookUpEdit5 . Properties . DataSource = dr;
            lookUpEdit5 . Properties . DisplayMember = "DBA002";
            lookUpEdit5 . Properties . ValueMember = "DBA001";

            DataTable de = bll . GetDataTableLeaderY ( );
            lookUpEdit2 . Properties . DataSource = de;
            lookUpEdit2 . Properties . DisplayMember = "DBA002";
            lookUpEdit2 . Properties . ValueMember = "DBA001";
        }
        private void button5_Click ( object sender ,EventArgs e )
        {
            strWhere = queryWhere;
            //if ( !string.IsNullOrEmpty( lookUpEdit4.Text ) )
            //    strWhere = strWhere + " AND GZ30='" + lookUpEdit4.Text + "'";
            //if ( !string.IsNullOrEmpty( lookUpEdit5.Text ) )
            //    strWhere = strWhere + " AND GZ16='" + lookUpEdit5.Text + "'";
            //if ( !string.IsNullOrEmpty( lookUpEdit6.Text ) )
            //    strWhere = strWhere + " AND GZ37='" + lookUpEdit6.Text + "'";
            //if ( !string.IsNullOrEmpty( lookUpEdit2.Text ) )
            //    strWhere = strWhere + " AND GZ02='" + lookUpEdit2.Text + "'";
            refresh( );

            nameTable = bll . GetDataTableOne ( );
            lookUpEdit4 . Properties . DataSource = nameTable;
            lookUpEdit4 . Properties . DisplayMember = "DBA002";
            lookUpEdit4 . Properties . ValueMember = "DBA001";

            DataTable dr = bll . GetDataTableLeader ( );
            lookUpEdit5 . Properties . DataSource = dr;
            lookUpEdit5 . Properties . DisplayMember = "DBA002";
            lookUpEdit5 . Properties . ValueMember = "DBA001";

            DataTable de = bll . GetDataTableLeaderY ( );
            lookUpEdit2 . Properties . DataSource = de;
            lookUpEdit2 . Properties . DisplayMember = "DBA002";
            lookUpEdit2 . Properties . ValueMember = "DBA001";
        }
        void refresh ( )
        {
            DataTable da = bll.ExistsIsZero( model );
            if ( da != null && da.Rows.Count > 0 )
            {
                List<int> lisId = new List<int>( );
                for ( int i = 0 ; i < da.Rows.Count ; i++ )
                {
                    lisId.Add( string.IsNullOrEmpty( da.Rows[i]["idx"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[i]["idx"].ToString( ) ) );
                }
                string arrlist = string.Join( "," ,lisId );
                //计件率计算：
                /*
                 结计件率计算公式:同流水,部件名称,工序 (产品数量*零部件数量-SUM(计时量)/SUM(计件量))  计算结果全部限定在0-1之间
                 */
                result = bll.calCuIsZero( );
                if ( result == false )
                {
                    MessageBox.Show( "读取数据失败,请重试" );
                    return;
                }
            }
            if ( string.IsNullOrEmpty( strWhere ) )
                strWhere = "1=1";
            result = bll.ExistsTJ( Logins.number );
            if ( result == true )
                tableQuery = bll . GetDataTableOf ( strWhere ,Logins . number );
            else
            {
                if ( state . Equals ( "queryAll" ) )
                    tableQuery = bll . GetDataTable ( );
                else
                    tableQuery = bll . GetDataTable ( strWhere ,Logins . number . Replace ( "-" ,string . Empty ) );
            }              
            gridControl1.DataSource = tableQuery;
            assignSummary( );
            if ( tableQuery != null && tableQuery . Rows . Count > 0 )
            {
                model . GZ01 = textBox3 . Text == string . Empty ? tableQuery . Rows [ 0 ] [ "GZ01" ] . ToString ( ) : textBox3 . Text;
                assign ( );
            }
        }
        void assignSummary ( )
        {
            if ( tableQuery != null )
            {
                if (U10.SummaryItem.SummaryValue!=null && !string.IsNullOrEmpty( U10.SummaryItem.SummaryValue.ToString( ) ) )
                {
                    if ( Convert.ToDecimal( U10.SummaryItem.SummaryValue ) == 0 )
                        U9.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
                    else
                        U9.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( Convert.ToDecimal( bandedGridView1.Columns["U5"].SummaryItem.SummaryValue ) / Convert.ToDecimal( U10.SummaryItem.SummaryValue ) ,2 ).ToString( ) );
                }
                Dictionary<string ,int> dc = new Dictionary<string ,int>( );
                for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
                {
                    string str = bandedGridView1.GetDataRow( i )["GZ01"].ToString( ) + bandedGridView1.GetDataRow( i )["GZ03"].ToString( ) + bandedGridView1.GetDataRow( i )["GZ04"].ToString( );
                    //[GZ34] * [GZ40]
                    int gz40 = string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["GZ40"].ToString( ) ) == true ? 0 : Convert.ToInt32( bandedGridView1.GetDataRow( i )["GZ40"].ToString( ) );
                    int gz34 = string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["GZ34"].ToString( ) ) == true ? 0 : Convert.ToInt32( bandedGridView1.GetDataRow( i )["GZ34"].ToString( ) );
                    if ( dc.Count < 1 )
                        dc.Add( str ,gz40 * gz34 );
                    else
                    {
                        if ( !dc.ContainsKey( str ) )
                            dc.Add( str ,gz40 * gz34 );
                    }
                }
                int xy = 0;
                if ( dc.Count > 0 )
                {
                    foreach ( int x in dc.Values )
                    {
                        xy += x;
                    }
                    U15.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,xy.ToString( ) );
                }
            }
        }
        //Acquisition plan price
        private void button7_Click ( object sender ,EventArgs e )
        {
            model.GZ01 = textBox3.Text;
            DataTable da = bll.GetDataTablePlanPrice( model.GZ01 );
            if ( da != null && da.Rows.Count > 0 )
            {
                if ( tableQuery != null && tableQuery.Rows.Count > 0 )
                {
                    for ( int i = 0 ; i < tableQuery.Rows.Count ; i++ )
                    {
                        model.GZ03 = tableQuery.Rows[i]["GZ03"].ToString( );
                        model.GZ04 = tableQuery.Rows[i]["GZ04"].ToString( );
                        if ( da.Select( "DS03='" + model.GZ03 + "' AND DS04='" + model.GZ04 + "'" ).Length > 0 )
                        {
                            model.Idx = string.IsNullOrEmpty( tableQuery.Rows[i]["idx"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQuery.Rows[i]["idx"].ToString( ) );
                            model.GZ27 = string.IsNullOrEmpty( da.Select( "DS03='" + model.GZ03 + "' AND DS04='" + model.GZ04 + "'" )[0]["DS"].ToString( ) ) ? 0 : Convert.ToDecimal( da.Select( "DS03='" + model.GZ03 + "' AND DS04='" + model.GZ04 + "'" )[0]["DS"].ToString( ) );
                            result = false;
                            result = bll.UpdatePlanPrice( model );
                            if ( result == false )
                            {
                                MessageBox.Show( "读取数据失败" );
                                break;
                            }
                            else if ( i == tableQuery.Rows.Count - 1 )
                            {
                                MessageBox.Show( "读取数据成功" );
                                strWhere = "1=1";
                                strWhere = strWhere + " AND GZ29='" + model.GZ29 + "'";
                                refresh( );
                            }
                        }
                        else if ( i == tableQuery.Rows.Count - 1 )
                        {
                            MessageBox.Show( "读取数据成功" );
                            strWhere = "1=1";
                            strWhere = strWhere + " AND GZ29='" + model.GZ29 + "'";
                            refresh( );
                        }
                    }
                }
            }
        }
        //Write To R_046
        private void button6_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox3.Text ) )
                MessageBox.Show( "流水号不可为空" );
            else
            {
                build( );

                DataTable dt = bll.GetDataTableWrite( model.GZ01 );
                if ( dt.Rows.Count < 1 )
                    MessageBox.Show( "没有数据写入R_046" );
                else
                {
                    for ( int i = 0 ; i < dt.Rows.Count ; i++ )
                    {
                        int GZ = 0;
                        model.GZ03 = dt.Rows[i]["GZ03"].ToString( );
                        model.GZ04 = dt.Rows[i]["GZ04"].ToString( );
                        model.GZ24 = string.IsNullOrEmpty( dt.Rows[i]["GZ24"].ToString( ) ) == true ? 0 : Convert.ToInt32( dt.Rows[i]["GZ24"].ToString( ) );
                        model.GZ17 = string.IsNullOrEmpty( dt.Rows[i]["GZ17"].ToString( ) ) == true ? 0 : Convert.ToInt32( dt.Rows[i]["GZ17"].ToString( ) );
                        GZ = string.IsNullOrEmpty( dt.Rows[i]["GZ"].ToString( ) ) == true ? 0 : Convert.ToInt32( dt.Rows[i]["GZ"].ToString( ) );

                        result = false;
                        result = bll.UpdateSum( model ,GZ );
                        if ( result == false )
                        {
                            MessageBox.Show( "写入R_046失败" );
                            break;
                        }
                        else if ( i == dt.Rows.Count - 1 )
                        {
                            MessageBox.Show( "写入R_046成功" );
                        }
                    }
                }
            }
        }
        #endregion

    }
}





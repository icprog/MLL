using System;
using System.Data;
using System.Windows.Forms;
using Mulaolao.Class;
using System.Collections.Generic;

namespace Mulaolao.Wages
{
    public partial class R_Frmchejianzhurenkaohe : FormChild
    {
        public R_Frmchejianzhurenkaohe ( )
        {
            InitializeComponent( );
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { this . gridView1 ,this . bandedGridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }

        MulaolaoBll.Bll.CheJianZhuRenKaoHeBll bll = new MulaolaoBll.Bll.CheJianZhuRenKaoHeBll( );
        MulaolaoLibrary.CheJianZhuRenKaoHeCzLibrary modelCz = new MulaolaoLibrary.CheJianZhuRenKaoHeCzLibrary( );
        MulaolaoLibrary.CheJianZhuRenKaoHeDzLibrary modelDz = new MulaolaoLibrary.CheJianZhuRenKaoHeDzLibrary( );
        
        DataTable DirecTor, tableQueryOne, tableQueryTwo;
        string saa = "", strWhere = "1=1", weihu = "", dd = "", yearMonth = "";
        bool result = false;
        List<SplitContainer> spList = new List<SplitContainer>( );
        
        private void R_Frmchejianzhurenkaohe_Load ( object sender ,EventArgs e )
        {
            Power( this );

            spList.Clear( );
            spList.AddRange( new SplitContainer[] { splitContainer2 ,splitContainer1 ,splitContainer3 } );
            Ergodic.SpliClear( spList );
            gridControl1.DataSource = null;
            gridControl2.DataSource = null;
            Ergodic.SpliEnableFalse( spList );
            clearLook( );

            textBox19.Enabled = false;
            label45.Visible = false;
            textBox5.Enabled = false;

            bandedGridView1.OptionsBehavior.Editable = false;

            DirecTor = bll.GetDataTableDirecTor( );
            lookUpEdit1.Properties.DataSource = DirecTor;
            lookUpEdit1.Properties.DisplayMember = "DAA002";
            lookUpEdit1.Properties.ValueMember = "DAA001";

            dateTimePicker2.Enabled = false;
        }
        
        #region Event
        void clearLook ( )
        {
            lookUpEdit1.EditValue = null;
            lookUpEdit1.ItemIndex = -1;
        }
        private void gridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.RowCount - 1 )
            {
                if ( !string.IsNullOrEmpty( gridView1.GetFocusedRowCellValue( "idx" ).ToString( ) ) )
                {
                    modelCz.IDX = Convert.ToInt32( gridView1.GetFocusedRowCellValue( "idx" ).ToString( ) );
                    assignMent( );
                }
            }
        }
        void assignMent ( )
        {
            modelCz = bll.GetModelCz( modelCz.IDX );
            lookUpEdit1.Text = textBox21.Text = modelCz.CZ001;
            if ( !string.IsNullOrEmpty( modelCz.CZ003 ) )
                dateTimePicker1.Value = dateTimePicker2.Value = DateTime.ParseExact( modelCz.CZ002 + modelCz.CZ003.Substring( 2 ,2 ) ,"yyyyMMdd" ,System.Globalization.CultureInfo.CurrentCulture );
            textBox20.Text = modelCz.CZ004.ToString( );
            textBox5.Text = modelCz.CZ005.ToString( );
            yearMonth = modelCz.CZ002;
            modelDz.DZ004 = dateTimePicker1.Value.ToString( "MMdd" );
            lookAss( modelDz.DZ004 );
        }
        private void textBox20_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.fractionTb( e ,textBox20 );
        }
        private void textBox20_TextChanged ( object sender ,EventArgs e )
        {
            DateDay.textChangeTb( textBox20 );
        }
        private void textBox20_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox20.Text != "" && !DateDay.foreOneNum( textBox20 ) )
            {
                this.textBox20.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多一位,如999.9,请重新输入" );
            }
        }
        private void textBox5_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.fractionTb( e ,textBox5 );
        }
        private void textBox5_TextChanged ( object sender ,EventArgs e )
        {
            DateDay.textChangeTb( textBox5 );
            textBox13.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTb( textBox5 ,textBox9 ) ) ,1 ).ToString( );
        }
        private void textBox9_TextChanged ( object sender ,EventArgs e )
        {
            textBox13.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTb( textBox5 ,textBox9 ) ) ,1 ).ToString( );
        }
        private void textBox5_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox5.Text != "" && !DateDay.tenOneNumber( textBox5 ) )
            {
                this.textBox5.Text = "";
                MessageBox.Show( "只允许输入整数部分最多九位,小数部分最多一位,如999999999.9,请重新输入" );
            }
        }
        private void textBox3_TextChanged ( object sender ,EventArgs e )
        {
            textBox11.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTb( textBox3 ,textBox7 ) ) ,1 ).ToString( );
        }
        private void textBox7_TextChanged ( object sender ,EventArgs e )
        {
            textBox11.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTb( textBox3 ,textBox7 ) ) ,1 ).ToString( );
        }
        private void textBox4_TextChanged ( object sender ,EventArgs e )
        {
            textBox12.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTb( textBox4 ,textBox8 ) ) ,1 ).ToString( );
        }
        private void textBox8_TextChanged ( object sender ,EventArgs e )
        {
            textBox12.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTb( textBox4 ,textBox8 ) ) ,1 ).ToString( );
        }
        private void dateTimePicker1_ValueChanged ( object sender ,EventArgs e )
        {
            dateTimePicker2.Value = dateTimePicker1.Value;
        }
        #endregion

        #region Query
        SelectAll.CheJianZhuRenKaoHeAll query = new SelectAll.CheJianZhuRenKaoHeAll( );
        protected override void select ( )
        {
            base.select( );

            query.StartPosition = FormStartPosition.CenterScreen;
            query.PassDataBetweenForm += new SelectAll.CheJianZhuRenKaoHeAll.PassDataBetweenFormHandler( query_PassDataBetweenForm );
            query.ShowDialog( );

            if ( string.IsNullOrEmpty( modelCz.CZ006 ) )
                MessageBox.Show( "您没有选择任何内容" );
            else
            {
                Ergodic.FormEverySpliEnableFalse( this );
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = toolPrint.Enabled = toolExport.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
                saa = "2";
                textBox19.Enabled = false;

                gridControl2.DataSource = null;
                tableQueryTwo = null;

                strWhere = "1=1";
                strWhere = strWhere + " AND CZ006='" + modelCz.CZ006 + "'";
                refre( );
            }
        }
        private void query_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            modelCz.CZ006 = e.ConOne;
        }
        #endregion

        #region TableOne
        void variable ( )
        {
            modelCz.CZ001 = lookUpEdit1.Text;
            modelCz.CZ002 = dateTimePicker1.Value.ToString( "yyyyMM" );
            modelCz.CZ003 = dateTimePicker1.Value.ToString( "MMdd" );
            modelCz.CZ004 = string.IsNullOrEmpty( textBox20.Text ) == true ? 0 : Convert.ToDecimal( textBox20.Text );
            modelCz.CZ005 = string.IsNullOrEmpty( textBox5.Text ) == true ? 0 : Convert.ToDecimal( textBox5.Text );
        }
        //Build
        private void button1_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( lookUpEdit1.Text ) )
                MessageBox.Show( "车间主任不可为空" );
            else
            {
                variable( );
                modelCz.IDX = bll.Add( modelCz );
                if ( modelCz.IDX > 0 )
                {
                    MessageBox.Show( "录入数据成功" );
                    strWhere = "1=1";
                    strWhere = strWhere + "AND CZ006='" + modelCz.CZ006 + "'";
                    refre( );
                }
                else
                    MessageBox.Show( "录入数据失败" );
            }
        }
        //Edit
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( lookUpEdit1.Text ) )
                MessageBox.Show( "车间主任不可为空" );
            else
            {
                variable( );
                result = false;
                result = bll.Update( modelCz );
                if ( result == false )
                    MessageBox.Show( "编辑数据失败" );
                else
                {
                    MessageBox.Show( "编辑数据成功" );
                    strWhere = "1=1";
                    strWhere = strWhere + "AND CZ006='" + modelCz.CZ006 + "'";
                    refre( );
                }
            }
        }
        //Dele
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) ==
DialogResult . Cancel )
                return;
            result = false;
            result = bll.Delete( modelCz );
            if ( result == false )
                MessageBox.Show( "删除数据失败" );
            else
            {
                MessageBox.Show( "删除数据成功" );
                tableQueryOne.Rows.Remove( tableQueryOne.Select( "idx='" + modelCz.IDX + "'" )[0] );
            }
        }
        //Refresh
        private void button4_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            strWhere = strWhere + " AND CZ006='" + modelCz.CZ006 + "'";
            refre( );
        }
        void refre ( )
        {
            if ( string.IsNullOrEmpty( strWhere ) )
                strWhere = "1=1";
            tableQueryOne = bll.GetDataTableOne( strWhere );
            gridControl1.DataSource = tableQueryOne;
        }
        #endregion

        #region TableTwo     
        void queryAuto ( )
        {
            if ( tableQueryOne != null && tableQueryOne.Rows.Count > 0 )
            {
                if ( tableQueryOne.Select( "CZ003='" + dateTimePicker2.Value.ToString( "MMdd" ) + "'" ).Length < 1 )
                {
                    MessageBox.Show( "本月考核无" + dateTimePicker2.Value.ToString( "MMdd" ) + "的数据" );
                    tableQueryTwo = null;
                    gridControl2.DataSource = null;
                    return;
                }
            }
            strWhere = "1=1";
            strWhere = strWhere + " AND DZ001='" + modelCz.CZ006 + "' AND DZ004='" + dateTimePicker2.Value.ToString( "MMdd" ) + "'";
            tableQueryTwo = bll.GetDataTableTwo( strWhere );
            gridControl2.DataSource = tableQueryTwo;
            calcuAll( );
        }   
        private void dateTimePicker2_ValueChanged ( object sender ,EventArgs e )
        {
            queryAuto( );
        }
        //Query
        private void button5_Click ( object sender ,EventArgs e )
        {
            queryAuto( );
        }
        //Save
        private void button6_Click ( object sender ,EventArgs e )
        {
            bandedGridView1.CancelUpdateCurrentRow( );

            if ( tableQueryTwo != null && tableQueryTwo.Rows.Count > 0 )
            {
                DataRow row;
                for ( int i = 0 ; i < tableQueryTwo.Rows.Count ; i++ )
                {
                    row = tableQueryTwo.Rows[i];
                    row.BeginEdit( );
                    row["DZ001"] = modelCz.CZ006;
                    row["DZ002"] = textBox21.Text;
                    row["DZ003"] = dateTimePicker2.Value.ToString( "yyyyMM" );
                    row["DZ004"] = dateTimePicker2.Value.ToString( "MMdd" );
                    row.EndEdit( );
                }
                result = bll.UpdateTable( tableQueryTwo );
                if ( result == true )
                {
                    MessageBox.Show( "保存数据成功" );
                    queryAuto( );
                }
                else
                    MessageBox.Show( "保存数据失败,请重试" );
            }
        }
        //Read
        private void button7_Click ( object sender ,EventArgs e )
        {
            tableAddNewRow( );
            gridControl2.DataSource = tableQueryTwo;
        }
        private void bandedGridView1_CustomColumnDisplayText ( object sender ,DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e )
        {
            DZ009.DisplayFormat.FormatString = "MM月dd日";
            DZ010.DisplayFormat.FormatString = "MM月dd日";
            DZ011.DisplayFormat.FormatString = "MM月dd日";
            DZ012.DisplayFormat.FormatString = "MM月dd日";
            DZ014.DisplayFormat.FormatString = "MM月dd日";
        }
        private void bandedGridView1_KeyDown ( object sender ,KeyEventArgs e )
        {
            if ( e.KeyCode == Keys.Delete )
            {
                int num = bandedGridView1.FocusedRowHandle;
                if ( num >= 0 && num <= bandedGridView1.RowCount - 1 )
                {
                    modelDz.IDX = string.IsNullOrEmpty( bandedGridView1.GetFocusedRowCellValue( "idx" ).ToString( ) ) == true ? 0 : Convert.ToInt32( bandedGridView1.GetFocusedRowCellValue( "idx" ).ToString( ) );
                    tableQueryTwo.Rows.RemoveAt( num );
                    gridControl2.DataSource = tableQueryTwo;
                    bll.DeleteDz( modelDz.IDX );
                }
            }
        }
        void saveTo ( )
        {
            bandedGridView1.CancelUpdateCurrentRow( );

            if ( tableQueryTwo != null && tableQueryTwo.Rows.Count > 0 )
            {
                DataRow row;
                for ( int i = 0 ; i < tableQueryTwo.Rows.Count ; i++ )
                {
                    row = tableQueryTwo.Rows[i];
                    row.BeginEdit( );
                    row["DZ001"] = modelCz.CZ006;
                    row["DZ002"] = lookUpEdit1.Text;
                    row["DZ003"] = dateTimePicker1.Value.ToString( "yyyyMM" );
                    row["DZ004"] = modelDz.DZ004;
                    row.EndEdit( );
                }
                result = bll.UpdateTable( tableQueryTwo );
            }
            #region
            /*
            modelDz.DZ002 = lookUpEdit1.Text;
                    modelDz.DZ003 = dateTimePicker1.Value.ToString( "yyyyMM" );
                    //modelDz.DZ004 = dateTimePicker1.Value.ToString( "MMdd" );
                    modelDz.DZ005 = tableQueryTwo.Rows[i]["DZ005"].ToString( );
                    modelDz.DZ006 = tableQueryTwo.Rows[i]["DZ006"].ToString( );
                    modelDz.DZ007 = tableQueryTwo.Rows[i]["DZ007"].ToString( );
                    modelDz.DZ008 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ008"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["DZ008"].ToString( ) );
                    modelDz.DZ009 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ009"].ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( tableQueryTwo.Rows[i]["DZ009"].ToString( ) );
                    modelDz.DZ010 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ010"].ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( tableQueryTwo.Rows[i]["DZ010"].ToString( ) );
                    modelDz.DZ011 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ011"].ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( tableQueryTwo.Rows[i]["DZ011"].ToString( ) );
                    modelDz.DZ012 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ012"].ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( tableQueryTwo.Rows[i]["DZ012"].ToString( ) );
                    modelDz.DZ013 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ013"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ013"].ToString( ) );
                    modelDz.DZ014 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ014"].ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( tableQueryTwo.Rows[i]["DZ014"].ToString( ) );
                    modelDz.DZ015 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ015"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["DZ015"].ToString( ) );
                    modelDz.DZ016 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ016"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["DZ016"].ToString( ) );
                    modelDz.DZ017 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ017"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["DZ017"].ToString( ) );
                    modelDz.DZ018 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ018"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["DZ018"].ToString( ) );
                    modelDz.DZ019 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ019"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["DZ019"].ToString( ) );
                    modelDz.DZ020 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ020"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["DZ020"].ToString( ) );
                    modelDz.DZ021 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ021"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ021"].ToString( ) );
                    modelDz.DZ022 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ022"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ022"].ToString( ) );
                    modelDz.DZ023 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ023"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ023"].ToString( ) );
                    modelDz.DZ024 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ024"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ024"].ToString( ) );
                    modelDz.DZ025 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ025"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ025"].ToString( ) );
                    modelDz.DZ026 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ026"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ026"].ToString( ) );
                    modelDz.DZ027 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ027"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ027"].ToString( ) );
                    modelDz.DZ028 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ028"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ028"].ToString( ) );
                    modelDz.DZ029 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ029"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ029"].ToString( ) );
                    modelDz.DZ030 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ030"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ030"].ToString( ) );
                    modelDz.DZ031 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ031"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ031"].ToString( ) );
                    modelDz.DZ032 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ032"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ032"].ToString( ) );
                    modelDz.DZ033 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ033"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ033"].ToString( ) );
                    modelDz.DZ034 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ034"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ034"].ToString( ) );
                    modelDz.DZ035 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ035"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ035"].ToString( ) );
                    modelDz.DZ036 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ036"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ036"].ToString( ) );
                    modelDz.DZ037 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ037"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ037"].ToString( ) );
                    modelDz.DZ038 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ038"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ038"].ToString( ) );
                    modelDz.DZ039 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ039"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ039"].ToString( ) );
                    modelDz.DZ040 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ040"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ040"].ToString( ) );
                    modelDz.DZ041 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ041"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ041"].ToString( ) );
                    modelDz.DZ042 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ042"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ042"].ToString( ) );
                    modelDz.DZ043 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ043"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ043"].ToString( ) );
                    modelDz.DZ044 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ044"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ044"].ToString( ) );
                    modelDz.DZ045 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ045"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ045"].ToString( ) );
                    modelDz.DZ046 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ046"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ046"].ToString( ) );
                    modelDz.DZ047 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ047"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ047"].ToString( ) );
                    modelDz.DZ048 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ048"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ048"].ToString( ) );
                    modelDz.DZ049 = tableQueryTwo.Rows[i]["DZ049"].ToString( );
                    modelDz.DZ050 = tableQueryTwo.Rows[i]["DZ050"].ToString( );
                    modelDz.DZ051 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ051"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ051"].ToString( ) );
                    modelDz.DZ052 = tableQueryTwo.Rows[i]["DZ041"].ToString( );
                    modelDz.DZ053 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ053"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ053"].ToString( ) );
                    modelDz.DZ054 = tableQueryTwo.Rows[i]["DZ041"].ToString( );
                    modelDz.DZ055 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ055"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ055"].ToString( ) );
                    modelDz.DZ056 = tableQueryTwo.Rows[i]["DZ041"].ToString( );
                    modelDz.DZ057 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ057"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ057"].ToString( ) );
                    modelDz.DZ058 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ058"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ058"].ToString( ) );
                    modelDz.DZ059 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ059"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ059"].ToString( ) );
                    modelDz.DZ060 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ060"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ060"].ToString( ) );
                    modelDz.DZ061 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ061"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ061"].ToString( ) );
                    modelDz.DZ062 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ062"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ062"].ToString( ) );
                    modelDz.DZ063 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ063"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ063"].ToString( ) );
                    modelDz.DZ064 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ064"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ064"].ToString( ) );
                    modelDz.DZ065 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ065"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ065"].ToString( ) );
                    modelDz.DZ066 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ066"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ066"].ToString( ) );
                    modelDz.DZ067 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ067"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ067"].ToString( ) );
                    modelDz.DZ068 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ068"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ068"].ToString( ) );
                    modelDz.DZ069 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ069"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ069"].ToString( ) );
                    modelDz.DZ070 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ070"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ070"].ToString( ) );
                    modelDz.DZ071 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ071"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ071"].ToString( ) );
                    modelDz.DZ072 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ072"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ072"].ToString( ) );
                    modelDz.DZ073 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ073"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ073"].ToString( ) );
                    modelDz.DZ074 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ074"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ074"].ToString( ) );
                    modelDz.DZ075 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ075"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ075"].ToString( ) );
                    modelDz.DZ076 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ076"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ076"].ToString( ) );
                    modelDz.DZ077 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["DZ077"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["DZ077"].ToString( ) );
                    modelDz.IDX = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["idx"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["idx"].ToString( ) );

                    result = false;
                    result = bll.ExistsIdx( modelDz.IDX );
                    if ( result == true )
                    {
                        result = false;
                        result = bll.UpdateTwo( modelDz );
                        if ( i+1 == tableQueryTwo.Rows.Count )
                        {
                            tableQueryTwo = null;
                            break;
                        }
                    }
                    else
                    {
                        modelDz.IDX = bll.AddTwo( modelDz );
                        if ( i+1 == tableQueryTwo.Rows.Count )
                        {
                            tableQueryTwo = null;
                            break;
                        }
                    }
                }
            }
    */
            #endregion
        }
        void lookAss (string dateD )
        {
            //modelDz.DZ004 = modelCz.CZ003;
            bandedGridView1.CancelUpdateCurrentRow( );
            if ( tableQueryTwo != null && tableQueryTwo.Rows.Count > 0 )
            {
                modelDz.DZ004 = dd;
                saveTo( );
            }

            strWhere = "1=1";
            strWhere = strWhere + " AND DZ001='" + modelCz.CZ006 + "' AND DZ004='" + dateD + "'";
            tableQueryTwo = bll.GetDataTableTwo( strWhere );
            tableAddNewRow( );
            gridControl2.DataSource = tableQueryTwo;
            calcuAll( );

            dd = dateTimePicker1.Value.ToString( "MMdd" );
        }
        private void contextMenuStrip1_ItemClicked ( object sender ,ToolStripItemClickedEventArgs e )
        {
            //modelDz.DZ004 = modelCz.CZ006;
            //lookAss( modelDz.DZ004 );
        }
        void calcuAll ( )
        {
            if ( tableQueryTwo != null && tableQueryTwo.Rows.Count > 0 )
            {
                modelDz.DZ001 = modelCz.CZ006;
                modelDz.DZ002 = lookUpEdit1.Text;
                modelDz.DZ003 = yearMonth;
                modelDz.DZ004 = modelCz.CZ003;
                DataTable dr = bll.GetDataTableCacle( modelDz );
                if ( dr != null && dr.Rows.Count > 0 )
                {
                    for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                    {
                        gridView1.SetRowCellValue( i ,gridView1.Columns["U7"] ,dr.Select( "DZ004='" + gridView1.GetDataRow( i )["CZ003"].ToString( ) + "'" ).Length > 0 == true ? dr.Select( "DZ004='" + gridView1.GetDataRow( i )["CZ003"].ToString( ) + "'" )[0]["U7"].ToString( ) : 0.ToString( ) );
                        gridView1.SetRowCellValue( i ,gridView1.Columns["U0"] ,dr.Select( "DZ004='" + gridView1.GetDataRow( i )["CZ003"].ToString( ) + "'" ).Length > 0 == true ? dr.Select( "DZ004='" + gridView1.GetDataRow( i )["CZ003"].ToString( ) + "'" )[0]["U0"].ToString( ) : 0.ToString( ) );
                        gridView1.SetRowCellValue( i ,gridView1.Columns["U1"] ,dr.Select( "DZ004='" + gridView1.GetDataRow( i )["CZ003"].ToString( ) + "'" ).Length > 0 == true ? dr.Select( "DZ004='" + gridView1.GetDataRow( i )["CZ003"].ToString( ) + "'" )[0]["U1"].ToString( ) : 0.ToString( ) );
                        gridView1.SetRowCellValue( i ,gridView1.Columns["U2"] ,dr.Select( "DZ004='" + gridView1.GetDataRow( i )["CZ003"].ToString( ) + "'" ).Length > 0 == true ? dr.Select( "DZ004='" + gridView1.GetDataRow( i )["CZ003"].ToString( ) + "'" )[0]["U2"].ToString( ) : 0.ToString( ) );
                        gridView1.SetRowCellValue( i ,gridView1.Columns["U3"] ,dr.Select( "DZ004='" + gridView1.GetDataRow( i )["CZ003"].ToString( ) + "'" ).Length > 0 == true ? dr.Select( "DZ004='" + gridView1.GetDataRow( i )["CZ003"].ToString( ) + "'" )[0]["U3"].ToString( ) : 0.ToString( ) );
                        gridView1.SetRowCellValue( i ,gridView1.Columns["U4"] ,dr.Select( "DZ004='" + gridView1.GetDataRow( i )["CZ003"].ToString( ) + "'" ).Length > 0 == true ? dr.Select( "DZ004='" + gridView1.GetDataRow( i )["CZ003"].ToString( ) + "'" )[0]["U4"].ToString( ) : 0.ToString( ) );
                    }

                    textBox1.Text = dr.Select( "DZ004='" + modelDz.DZ004 + "'" ).Length > 0 == true ? dr.Select( "DZ004='" + modelDz.DZ004 + "'" )[0]["U0"].ToString( ) : 0.ToString( );
                    textBox3.Text = dr.Select( "DZ004='" + modelDz.DZ004 + "'" ).Length > 0 == true ? dr.Select( "DZ004='" + modelDz.DZ004 + "'" )[0]["F0"].ToString( ) : 0.ToString( );
                    textBox4.Text = dr.Select( "DZ004='" + modelDz.DZ004 + "'" ).Length > 0 == true ? dr.Select( "DZ004='" + modelDz.DZ004 + "'" )[0]["F1"].ToString( ) : 0.ToString( );
                    textBox6.Text = dr.Select( "DZ004='" + modelDz.DZ004 + "'" ).Length > 0 == true ? dr.Select( "DZ004='" + modelDz.DZ004 + "'" )[0]["F2"].ToString( ) : 0.ToString( );
                    textBox7.Text = textBox8.Text = textBox9.Text = bandedGridView1.GetDataRow( 0 )["DZ019"].ToString( );
                    textBox10.Text = dr.Select( "DZ004='" + modelDz.DZ004 + "'" ).Length > 0 == true ? dr.Select( "DZ004='" + modelDz.DZ004 + "'" )[0]["F4"].ToString( ) : 0.ToString( );
                    textBox14.Text = dr.Select( "DZ004='" + modelDz.DZ004 + "'" ).Length > 0 == true ? dr.Select( "DZ004='" + modelDz.DZ004 + "'" )[0]["F3"].ToString( ) : 0.ToString( );
                    textBox14.Text = dr.Select( "DZ004='" + modelDz.DZ004 + "'" ).Length > 0 == true ? dr.Select( "DZ004='" + modelDz.DZ004 + "'" )[0]["F5"].ToString( ) : 0.ToString( );
                    textBox2.Text = dr.Select( "DZ004='" + modelDz.DZ004 + "'" ).Length > 0 == true ? dr.Select( "DZ004='" + modelDz.DZ004 + "'" )[0]["U1"].ToString( ) : 0.ToString( );
                    textBox15.Text = dr.Select( "DZ004='" + modelDz.DZ004 + "'" ).Length > 0 == true ? dr.Select( "DZ004='" + modelDz.DZ004 + "'" )[0]["U2"].ToString( ) : 0.ToString( );
                    textBox16.Text = dr.Select( "DZ004='" + modelDz.DZ004 + "'" ).Length > 0 == true ? dr.Select( "DZ004='" + modelDz.DZ004 + "'" )[0]["U3"].ToString( ) : 0.ToString( );
                    textBox17.Text = dr.Select( "DZ004='" + modelDz.DZ004 + "'" ).Length > 0 == true ? dr.Select( "DZ004='" + modelDz.DZ004 + "'" )[0]["U4"].ToString( ) : 0.ToString( );
                }
                decimal cz04 = Convert.ToDecimal( gridView1.Columns["CZ004"].SummaryItem.SummaryValue );
                U7.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( cz04 == 0 ? 0 : Convert.ToDecimal( gridView1.Columns["U7"].Summary[0].SummaryValue ) / cz04 ).ToString( ) );
                U0.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( cz04 == 0 ? 0 : Convert.ToDecimal( gridView1.Columns["U0"].Summary[0].SummaryValue ) / cz04 ).ToString( ) );
                U1.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( cz04 == 0 ? 0 : Convert.ToDecimal( gridView1.Columns["U1"].Summary[0].SummaryValue ) / cz04 ).ToString( ) );
                U2.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( cz04 == 0 ? 0 : Convert.ToDecimal( gridView1.Columns["U2"].Summary[0].SummaryValue ) / cz04 ).ToString( ) );
                U3.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( cz04 == 0 ? 0 : Convert.ToDecimal( gridView1.Columns["U3"].Summary[0].SummaryValue ) / cz04 ).ToString( ) );
                U4.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( cz04 == 0 ? 0 : Convert.ToDecimal( gridView1.Columns["U4"].Summary[0].SummaryValue ) / cz04 ).ToString( ) );
                U5.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( cz04 == 0 ? 0 : Convert.ToDecimal( gridView1.Columns["U5"].Summary[0].SummaryValue ) / cz04 ).ToString( ) );
                U6.Summary[0].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( cz04 == 0 ? 0 : Convert.ToDecimal( gridView1.Columns["U5"].Summary[0].SummaryValue ) / cz04).ToString( ) );

                DZ25.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( Convert.ToDecimal( bandedGridView1.Columns["DZ3"].SummaryItem.SummaryValue ) + Convert.ToDecimal( bandedGridView1.Columns["DZ6"].SummaryItem.SummaryValue ) + Convert.ToDecimal( bandedGridView1.Columns["DZ9"].SummaryItem.SummaryValue ) + Convert.ToDecimal( bandedGridView1.Columns["DZ12"].SummaryItem.SummaryValue ) + Convert.ToDecimal( bandedGridView1.Columns["DZ15"].SummaryItem.SummaryValue ) + Convert.ToDecimal( bandedGridView1.Columns["DZ16"].SummaryItem.SummaryValue ) + Convert.ToDecimal( bandedGridView1.Columns["DZ17"].SummaryItem.SummaryValue ) + Convert.ToDecimal( bandedGridView1.Columns["DZ18"].SummaryItem.SummaryValue ) + Convert.ToDecimal( bandedGridView1.Columns["DZ19"].SummaryItem.SummaryValue ) ).ToString( ) );
                DZ49.Summary[0].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( Convert.ToDecimal( bandedGridView1.Columns["DZ40"].SummaryItem.SummaryValue ) + Convert.ToDecimal( bandedGridView1.Columns["DZ44"].SummaryItem.SummaryValue ) + Convert.ToDecimal( bandedGridView1.Columns["DZ45"].SummaryItem.SummaryValue ) + Convert.ToDecimal( bandedGridView1.Columns["DZ46"].SummaryItem.SummaryValue ) ).ToString( ) );
            }
        }
        void tableAddNewRow ( )
        {
            if ( tableQueryTwo == null )
            {
                queryAuto( );
            }
            if ( tableQueryOne != null )
            {
                if ( tableQueryOne.Select( "CZ001='" + lookUpEdit1.Text + "'" ).Length < 1 )
                {
                    MessageBox.Show( "人员信息错误,请重新查询" );
                    return;
                }
            }
            modelCz.CZ002 = dateTimePicker2.Value.ToString( "yyyyMM" );
            if ( modelCz.CZ002 != null && modelCz.CZ002.Length > 5 && lookUpEdit1.EditValue!=null)
            {
                DataTable dt = bll.GetDataTableNum( lookUpEdit1.EditValue.ToString( ) ,modelCz.CZ002.Substring( 0 ,4 ) + "-" + modelCz.CZ002.Substring( 4 ,2 ) );
                if ( dt != null && dt.Rows.Count > 0 )
                {
                    for ( int i = 0 ; i < dt.Rows.Count ; i++ )
                    {
                        if ( tableQueryTwo.Select( "DZ005='" + dt.Rows[i]["PQF01"].ToString( ) + "'" ).Length <= 0 )
                        {
                            DataRow row = tableQueryTwo.NewRow( );
                            row["DZ006"] = dt.Rows[i]["PQF04"].ToString( );
                            row["DZ005"] = dt.Rows[i]["PQF01"].ToString( );
                            row["DZ007"] = dt.Rows[i]["PQF03"].ToString( );
                            row["DZ008"] = dt.Rows[i]["U1"].ToString( );
                            if ( string.IsNullOrEmpty( dt.Rows[i]["PQF31"].ToString( ) ) )
                                row["DZ009"] = DBNull.Value;
                            else
                                row["DZ009"] = Convert.ToDateTime( dt.Rows[i]["PQF31"].ToString( ) );
                            if ( string.IsNullOrEmpty( dt.Rows[i]["HT04"].ToString( ) ) )
                                row["DZ010"] = DBNull.Value;
                            else
                                row["DZ010"] = Convert.ToDateTime( dt.Rows[i]["HT04"].ToString( ) );
                            row["DZ049"] = dt.Rows[i]["DAA002"].ToString( );

                            rowEdit( row );

                            tableQueryTwo.Rows.Add( row );
                        }
                        else
                        {
                            DataRow[] rows = tableQueryTwo.Select( "DZ005='" + dt.Rows[i]["PQF01"].ToString( ) + "'" );
                            DataRow row = rows[0];
                            row.BeginEdit( );
                            row["DZ006"] = dt.Rows[i]["PQF04"].ToString( );
                            row["DZ005"] = dt.Rows[i]["PQF01"].ToString( );
                            row["DZ007"] = dt.Rows[i]["PQF03"].ToString( );
                            row["DZ008"] = dt.Rows[i]["U1"].ToString( );
                            if ( string.IsNullOrEmpty( dt.Rows[i]["PQF31"].ToString( ) ) )
                                row["DZ009"] = DBNull.Value;
                            else
                                row["DZ009"] = Convert.ToDateTime( dt.Rows[i]["PQF31"].ToString( ) );
                            if ( string.IsNullOrEmpty( dt.Rows[i]["HT04"].ToString( ) ) )
                                row["DZ010"] = DBNull.Value;
                            else
                                row["DZ010"] = Convert.ToDateTime( dt.Rows[i]["HT04"].ToString( ) );
                            row["DZ049"] = dt.Rows[i]["DAA002"].ToString( );

                            row.EndEdit( );
                        }
                    }
                }
            }
            modelCz.CZ002 = null;
        }
        void rowEdit ( DataRow row )
        {
            row["DZ015"] = 0.45;
            row["DZ017"] = 0.45;
            row["DZ019"] = 0.45;
            row["DZ022"] = 30;
            row["DZ025"] = 30;
            row["DZ028"] = 30;
            row["DZ073"] = 30;
            row["DZ030"] = 6;
            row["DZ033"] = 6;
            row["DZ036"] = 6;
            row["DZ075"] = 6;
            row["DZ045"] = 10;
            row["DZ047"] = 5;
            row["DZ051"] = 2;
            row["DZ053"] = 3;
            row["DZ055"] = 4;
            row["DZ057"] = 5;
            row["DZ058"] = 20;
            row["DZ060"] = -100;
            row["DZ062"] = -100;
            row["DZ064"] = -600;
            row["DZ066"] = -1000;
            row["DZ068"] = 100;
            row["DZ070"] = 100;
        }
        #endregion

        #region Main
        protected override void add ( )
        {
            base.add( );

            Ergodic.SpliClear( spList );
            gridControl1.DataSource = null;
            gridControl2.DataSource = null;
            Ergodic.SpliEnableTrue( spList );
            clearLook( );
            textBox19.Enabled = false;
            label45.Visible = false;
            textBox5.Enabled = true;
            saa = "1";
            bandedGridView1.OptionsBehavior.Editable = true;
            modelCz.CZ006 = oddNumbers.purchaseContract( "SELECT MAX(AJ029) AJ029 FROM R_PQAJ" ,"AJ029" ,"R_503-" );
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
        }
        void dele ( )
        {
            result = false;
            result = bll.DeleteOddNum( modelCz.CZ006 );
            if ( result == false )
                MessageBox.Show( "删除数据失败" );
            else
            {
                MessageBox.Show( "删除数据成功" );
                Ergodic.SpliClear( spList );
                gridControl1.DataSource = null;
                gridControl2.DataSource = null;
                Ergodic.SpliEnableFalse( spList );
                clearLook( );

                toolAdd.Enabled = toolSelect.Enabled = true;
                toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolExport.Enabled = toolReview.Enabled = toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled = toolMaintain.Enabled = false;

                textBox19.Enabled = false;
                label45.Visible = false;
                textBox5.Enabled = false;
                bandedGridView1.OptionsBehavior.Editable = false;
            }
        }
        protected override void delete ( )
        {
            base.delete( );

            if ( MessageBox.Show( "确认删除？" ,"删除" ,MessageBoxButtons.OKCancel ) == DialogResult.OK )
            {
                result = false;
                result = bll.ExistsReview( modelCz.CZ006 ,"R_503" );
                if ( result == true )
                {
                    if ( Logins.number == "MLL-0001" )
                        dele( );
                    else
                        MessageBox.Show( "单号:" + modelCz.CZ006 + "的单据状态为执行,需要总经理删除" );
                }
                else
                    dele( );
            }
        }
        protected override void update ( )
        {
            base.update( );

            result = false;
            result = bll.ExistsReview( modelCz.CZ006 ,"R_503" );
            if ( result == true )
                MessageBox.Show( "单号:" + modelCz.CZ006 + "的单据状态为执行,不允许更改" );
            else
            {
                toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolExport.Enabled = toolReview.Enabled = toolcopy.Enabled = toolMaintain.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;

                Ergodic.SpliEnableTrue( spList );

                textBox19.Enabled = false;
                label45.Visible = false;
                textBox5.Enabled = true;
                bandedGridView1.OptionsBehavior.Editable = true;
                modelDz.DZ004 = modelCz.CZ006;
                //lookAss( modelDz.DZ004 );
            }
        }
        protected override void revirw ( )
        {
            base.revirw( );

            Reviews( "CZ006" ,modelCz.CZ006 ,"R_PQCZ" ,this ,"" ,"R_503" ,false ,false,MulaolaoBll . Drity . GetDt ( )/*,"JM06" ,"JM87" ,"R_PQO" ,"JM01" ,JM01 ,ord ,textBox68.Text,"R_338"*/ );
        }
        protected override void print ( )
        {
            base.print( );
        }
        protected override void export ( )
        {
            base.export( );
        }
        protected override void maintain ( )
        {
            base.maintain( );

            result = false;
            result = bll.ExistsReview( modelCz.CZ006 ,"R_503" );
            if ( result == true )
            {
                Ergodic.SpliEnableTrue( spList );

                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolUpdate.Enabled = toolcopy.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;

                weihu = "1";

                textBox19.Enabled = true;
                label45.Visible = true;
                textBox5.Enabled = true;

                bandedGridView1.OptionsBehavior.Editable = true;
            }
            else
                MessageBox.Show( "此单据没有被执行,只需更改即可,无需维护" );
        }
        void state ( )
        {
            Ergodic.SpliEnableFalse( spList );

            toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolExport.Enabled = toolReview.Enabled = toolcopy.Enabled = toolMaintain.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;

            textBox19.Enabled = false;
            textBox5.Enabled = false;

            bandedGridView1.OptionsBehavior.Editable = false;
        }
        void vari ( )
        {
            modelCz.CZ001 = lookUpEdit1.Text;
            modelCz.CZ002 = dateTimePicker1.Value.ToString( "yyyyMM" );
            modelCz.CZ003 = dateTimePicker1.Value.ToString( "MMdd" );
            modelCz.CZ004 = string.IsNullOrEmpty( textBox20.Text ) == true ? 0 : Convert.ToDecimal( textBox20.Text );
            modelCz.CZ005 = string.IsNullOrEmpty( textBox5.Text ) == true ? 0 : Convert.ToDecimal( textBox5.Text );
            modelCz.CZ007 = textBox19.Text;
        }
        void save_Tw ( )
        {
            result = false;
            result = bll.UpdateWeiHu( modelCz );
            if ( result == true )
            {
                MessageBox.Show( "录入数据成功" );
                state( );
            }
            else
                MessageBox.Show( "录入数据失败" );
        }
        protected override void save ( )
        {
            base.save( );

            if ( string.IsNullOrEmpty( lookUpEdit1.Text ) )
                MessageBox.Show( "车间主任不可为空" );
            else
            {
                DataTable dt = bll.GetDataTabbleExists( modelCz.CZ006 );
                vari( );
                if ( weihu == "1" )
                {
                    if ( string.IsNullOrEmpty( textBox19.Text ) )
                        MessageBox.Show( "请填写维护意见" );
                    else
                    {
                        modelCz.CZ008 = dt.Rows[0]["CZ008"].ToString( ) + "[" + Logins.username + MulaolaoBll . Drity . GetDt ( ).ToString( "yyyyMMdd" ) + "]";
                        save_Tw( );
                    }
                }
                else
                {
                    if ( dt.Rows.Count > 0 )
                    {
                        modelCz.CZ008 = string.Empty;
                        save_Tw( );
                    }
                    else
                        state( );
                }
            }
        }
        protected override void cancel ( )
        {
            base.cancel( );

            if ( saa == "1" && weihu != "1" )
            {
                try
                {
                    bll.DeleteOddNum( modelCz.CZ006 );
                }
                catch { }
                finally
                {
                    Ergodic.SpliClear( spList );
                    gridControl1.DataSource = null;
                    gridControl2.DataSource = null;
                    Ergodic.SpliEnableFalse( spList );
                    clearLook( );

                    toolAdd.Enabled = toolSelect.Enabled = true;
                    toolSave.Enabled = toolCancel.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolExport.Enabled = toolReview.Enabled = toolcopy.Enabled = toolMaintain.Enabled = false;

                    textBox19.Enabled = false;
                    textBox5.Enabled = false;
                    label45.Visible = false;

                    bandedGridView1.OptionsBehavior.Editable = false;
                }
            }
            else if ( saa == "2" || weihu == "1" )
            {
                Ergodic.SpliEnableFalse( spList );

                toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolExport.Enabled = toolReview.Enabled = toolcopy.Enabled = toolMaintain.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = false;

                textBox19.Enabled = false;
                textBox5.Enabled = false;

                bandedGridView1.OptionsBehavior.Editable = false;
            }
        }
        #endregion
    }
}

using Mulaolao.Class;
using Mulaolao.Procedure;
using StudentMgr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Mulaolao.Other;
using System.IO;
using FastReport;
using MulaolaoBll;

namespace Mulaolao .Forms
{
    public partial class R_FrmContractreview : FormChild
    {
        MulaolaoLibrary.ContractreviewEntity _model=null;
        MulaolaoBll.Bll.ContractreviewBll _bll=null;
        
        public R_FrmContractreview(/*Form fm*/)
        {
            //this.MdiParent = fm;
            InitializeComponent( );

            _bll = new MulaolaoBll . Bll . ContractreviewBll ( );
            _model = new MulaolaoLibrary . ContractreviewEntity ( );

            GridViewMoHuSelect . SetFilter ( gvHe );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { this . gvHe } );

            UserInfoMation . tableName = this . Name;

        }
        
        GroupBox[] gb;
        private DataSet RDataset;
        Report report = new Report( );
        string path = Environment.CurrentDirectory + "\\布局";
        string file = "\\R_021.XML";
        string weihu="",sav="";
        bool result = false; SpecialPowers sp = new SpecialPowers( );
        DataTable tableView;long PQF6=0;

        private void R_FrmContractreview_Load( object sender, EventArgs e )
        {           
            Power( this );

            Ergodic.FormEvery( this );
            gcHe.DataSource = null;

            button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button9.Enabled = button24.Enabled = button25.Enabled = button26.Enabled = false;

            gb = new GroupBox[] { groupBox1, groupBox11, groupBox12, groupBox2, groupBox3, groupBox4, groupBox13 };
            Ergodic.FormGroupboxEnableFalse( this, gb );
            textBox35.Enabled = false;

            dateTimePicker2.Enabled = dateTimePicker3.Enabled = false;
            label46.Visible = false;

            List<string> heTong = new List<string> { "基本合同", "特殊合同", "订单" };
            for (int i = 0; i < heTong.Count; i++)
            {
                comb1.Items.Add( heTong[i] );
            }

            lookUpEdit1 . Properties . DataSource = _bll . GetDataTableOfWork ( );
            lookUpEdit1.Properties.DisplayMember = "DAA002";
            lookUpEdit1.Properties.ValueMember = "DAA001";

            try
            {
                _bll . delete ( Logins . username );
            }
            catch { }

            if ( Directory.Exists( path + file ) )
            {
                gcHe.MainView.RestoreLayoutFromXml( path + file );
            }
        }

        private void R_FrmContractreview_Shown ( object sender ,EventArgs e )
        {
            _model . HT64 = Merges . oddNum;
            if ( !string . IsNullOrEmpty ( _model . HT64 ) )
                autoQuery ( );
            Merges . oddNum = "";
        }

        #region 打印 导出
        private void CreateDataset( )
        {
            RDataset = new DataSet( );
            DataTable print = _bll . printOne ( _model . HT64 );
            
            print.TableName = "R_PQL";
            RDataset.Tables.Add( print );

            report.Load( Environment.CurrentDirectory + "\\htpsR_021.frx" );

            DataTable other = _bll . printTwo ( _model . HT64 );
            if (other != null && other.Rows.Count > 0)
            {
                report.SetParameterValue( "HT02", other.Rows[0]["HT02"].ToString( ) );
                report.SetParameterValue( "HT03", other.Rows[0]["HT03"].ToString( ) );
                report.SetParameterValue( "HT04", other.Rows[0]["HT04"].ToString( ) );
                report.SetParameterValue( "DFA002", other.Rows[0]["DFA002"].ToString( ) );
                report.SetParameterValue( "DFA015", other.Rows[0]["DFA015"].ToString( ) );
                report.SetParameterValue( "DFA016", other.Rows[0]["DFA016"].ToString( ) );
                report.SetParameterValue( "HT10", other.Rows[0]["HT10"].ToString( ) );
                report.SetParameterValue( "HT11", other.Rows[0]["HT11"].ToString( ) );
                report.SetParameterValue( "HT12", other.Rows[0]["HT12"].ToString( ) );
                report.SetParameterValue( "HT18", other.Rows[0]["HT18"].ToString( ) );
                report.SetParameterValue( "HT20", other.Rows[0]["HT20"].ToString( ) );
                report.SetParameterValue( "HT21", other.Rows[0]["HT21"].ToString( ) );
                report.SetParameterValue( "HT23", other.Rows[0]["HT23"].ToString( ) );
                report.SetParameterValue( "HT25", other.Rows[0]["HT25"].ToString( ) );
                report.SetParameterValue( "HT26", other.Rows[0]["HT26"].ToString( ) );
                report.SetParameterValue( "HT28", other.Rows[0]["HT28"].ToString( ) );
                report.SetParameterValue( "HT30", other.Rows[0]["HT30"].ToString( ) );
                report.SetParameterValue( "HT32", other.Rows[0]["HT32"].ToString( ) );
                report.SetParameterValue( "HT34" ,other.Rows[0]["HT34"].ToString( ) );
                report.SetParameterValue( "HT35", other.Rows[0]["HT35"].ToString( ) );
                report.SetParameterValue( "HT37", other.Rows[0]["HT37"].ToString( ) );
                report.SetParameterValue( "HT39", other.Rows[0]["HT39"].ToString( ) );
                report.SetParameterValue( "HT40", other.Rows[0]["HT40"].ToString( ) );
                report.SetParameterValue( "HT42", other.Rows[0]["HT42"].ToString( ) );
                report.SetParameterValue( "HT44", other.Rows[0]["HT44"].ToString( ) );
                report.SetParameterValue( "HT45", other.Rows[0]["HT45"].ToString( ) );
                report.SetParameterValue( "HT49", other.Rows[0]["HT49"].ToString( ) );
                report.SetParameterValue( "HT51", other.Rows[0]["HT51"].ToString( ) );
                report.SetParameterValue( "HT52", other.Rows[0]["HT52"].ToString( ) );
            }
        }
        #endregion

        #region 主体
        //打印
        protected override void print( )
        {
            base.print( );
            CreateDataset( );
            //report.Load( Environment.CurrentDirectory + "\\R_021.frx" );
            //report.RegisterData( RDataset );
            ////report.Design( );
            //report.Show( );
            //report.Dispose( );
        }
        //导出
        protected override void export( )
        {
            base.export( );
            //CreateDataset( );
            //report.Load( Environment.CurrentDirectory + "\\R_021.frx" );
            //report.RegisterData( RDataset );
            //report.Prepare( );
            //XMLExport exprots = new XMLExport( );
            //exprots.Export( report );
            //report.Dispose( );
        }
        //增加        
        protected override void add( )
        {
            base.add( );
            Ergodic.FormEvery( this );
            gcHe.DataSource = null;

            button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button9.Enabled = button24.Enabled = button25.Enabled = button26.Enabled = true;

            Ergodic.FormGroupboxEnableTrue( this, gb );
            textBox35.Enabled = false;
            dateTimePicker2.Enabled = dateTimePicker3.Enabled = false;
            label46.Visible = false;
            sav = "1";
            _model . HT64 = oddNumbers . purchaseContract ( "SELECT MAX(AJ030) AJ030 FROM R_PQAJ" ,"AJ030" ,"R_021-" );
            _model . HT64 = _bll . getOddNum ( );
           toolSelect .Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;

            //_model . HT64 = "1=1";
            button27_Click ( null ,null );
        }
        //保存
        private void adds ( )
        {
            toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolMaintain.Enabled = toolExport.Enabled = true;
            toolCancel.Enabled = toolSave.Enabled = false;
            button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button9.Enabled = button24.Enabled = button25.Enabled = button26.Enabled = false;

            Ergodic.FormGroupboxEnableFalse( this ,gb );
            textBox35.Enabled = false;
            //SqlHelper.ExecuteNonQuery( "UPDATE R_PQF SET PQF30=@PQF30 WHERE PQF02=@PQF02" ,new SqlParameter( "@PQF30" ,HT04 ) ,new SqlParameter( "@PQF02" ,HT02 ) );
        }
        protected override void save ( )
        {
            base . save ( );

            if ( string . IsNullOrEmpty ( textB1 . Text ) )
            {
                MessageBox . Show ( "合同号不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( textBox7 . Text ) )
            {
                MessageBox . Show ( "至少增加一条产品记录,否则记录无效" );
                return;
            }
            getValue ( );

            DataTable dw = _bll . getTable ( _model . HT64 );

            if ( weihu . Equals ( "1" ) )
            {
                if ( string . IsNullOrEmpty ( textBox35 . Text ) )
                {
                    MessageBox . Show ( "请填写维护意见" );
                    return;
                }

                if ( dw . Rows . Count < 1 )
                    MessageBox . Show ( "单号:" + _model . HT64 + "的记录不存在,请核实后再维护" );
                else
                {
                    _model . HT63 = dw . Rows [ 0 ] [ "HT63" ] . ToString ( ) + "[" + Logins . username + MulaolaoBll . Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "]";

                    result = _bll . Save ( _model );
                    if ( result == false )
                        MessageBox . Show ( "录入数据失败" );
                    else
                    {
                        MessageBox . Show ( "成功录入数据" );
                        adds ( );
                    }
                }
            }
            else
            {
                if ( dw . Rows . Count < 1 )
                {
                    result = _bll . Edit ( _model );
                    if ( result == false )
                        MessageBox . Show ( "录入数据失败" );
                    else
                    {
                        MessageBox . Show ( "成功录入数据" );
                        adds ( );
                    }
                }
                else
                {
                    result = _bll . Save ( _model );
                    if ( result==false )
                        MessageBox . Show ( "录入数据失败" );
                    else
                    {
                        MessageBox . Show ( "成功录入数据" );
                        adds ( );
                    }
                }
            }
        }
        void getValue ( )
        {
            _model . HT03 = comb1 . Text;
            _model . HT04 = dateTimePicker1 . Value;
            _model . HT09 = textBox1 . Text;
            _model . HT10 = textB27 . Text;
            _model . HT11 = textB28 . Text;
            _model . HT12 = dateTimePicker3 . Value;
            _model . HT02 = textB1 . Text;
            _model . HT18 = textBox14 . Text;
            _model . HT20 = textBox15 . Text;
            _model . HT21 = textBox30 . Text;
            _model . HT23 = textBox16 . Text;
            _model . HT25 = textBox17 . Text;
            _model . HT26 = textBox31 . Text;
            _model . HT28 = textBox18 . Text;
            _model . HT30 = textBox19 . Text;
            _model . HT32 = textBox20 . Text;
            _model . HT34 = textBox21 . Text;
            _model . HT35 = textBox32 . Text;
            _model . HT37 = textBox22 . Text;
            _model . HT39 = textBox23 . Text;
            _model . HT40 = textBox33 . Text;
            _model . HT42 = textBox24 . Text;
            _model . HT44 = textBox25 . Text;
            _model . HT45 = textBox34 . Text;
            _model . HT47 = textBox26 . Text;
            _model . HT49 = textBox27 . Text;
            _model . HT51 = textBox28 . Text;
            _model . HT52 = textBox29 . Text;
            _model . HT55 = textBox35 . Text;
            _model . HT63 = "";
            if ( _model . HT08 == null )
                _model . HT08 = new byte [ 0 ];
            if ( _model . HT58 == null )
                _model . HT58 = new byte [ 0 ];
            if ( _model . HT59 == null )
                _model . HT59 = new byte [ 0 ];
            if ( _model . HT60 == null )
                _model . HT60 = new byte [ 0 ];
            if ( _model . HT61 == null )
                _model . HT61 = new byte [ 0 ];
            if ( _model . HT62 == null )
                _model . HT62 = new byte [ 0 ];
        }
        //取消
        protected override void cancel( )
        {
            base.cancel( );
            if (sav == "1" && weihu!="1")
            {
                try
                {
                    if (gvHe.RowCount > 0)
                    {
                        _bll . delete ( _model . HT64 ,Logins . username );
                    }
                }
                catch { }
                finally
                {
                    toolAdd.Enabled = toolSelect.Enabled = true;
                    toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolPrint.Enabled = toolExport.Enabled = toolCancel.Enabled = toolSave.Enabled = false;
                    button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button9.Enabled = button24.Enabled = button25.Enabled = button26.Enabled = false;
                }          
            }
            else if (sav == "2" || weihu=="1")
            {
                toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolMaintain.Enabled = true;
                toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolCancel.Enabled = toolSave.Enabled = false;
                button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button9.Enabled = button24.Enabled = button25.Enabled = button26.Enabled = false;
            }
            Ergodic.FormGroupboxEnableFalse( this, gb );
            textBox35.Enabled = false;
        }
        //更改
        protected override void update( )
        {
            base.update( );

            //DataTable del = SqlHelper.ExecuteDataTable( "SELECT * FROM R_REVIEWS A,R_MLLCXMC B WHERE A.RES01=B.CX01 AND RES05='执行' AND RES06=@RES06 AND CX02=@CX02 ", new SqlParameter( "@RES06", HT64 ), new SqlParameter( "@CX02", this.Text ) );

            if (label46.Visible==true)
                MessageBox.Show( "单号:" + _model.HT64 + "的单据状态为执行,不允许更改" );
            else
            {
                toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolPrint.Enabled = toolExport.Enabled = false;
                toolCancel.Enabled = toolSave.Enabled = true;
                button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button9.Enabled = button24.Enabled = button25.Enabled = button26.Enabled = true;
                Ergodic.FormGroupboxEnableTrue( this, gb );
                textBox35.Enabled = false;
                dateTimePicker2.Enabled = dateTimePicker3.Enabled = false;
                label46.Visible = false;
            }
        }
        //送审      
        protected override void revirw ( )
        {
            base.revirw( );

            Reviews( "HT64" ,_model.HT64 ,"R_PQL" ,this ,"" ,"R_021" ,false ,false,MulaolaoBll.Drity.GetDt()/*,"" ,"" ,"" ,"" ,"" ,"" ,"" ,"R_021"*/);

            result = sp.reviewImple( "R_021" ,_model.HT64 );
            if ( result == true )
            {
                label46.Visible = true;
                _bll . saveTo ( tableView ,Logins . username );
                //for ( int i = 0 ; i < gvHe.RowCount ; i++ )
                //{
                //    if ( SqlHelper.Exists( "SELECT COUNT(1) FROM R_PQAE WHERE AE02='" + gvHe.GetDataRow( i )["PQF01"].ToString( ) + "'" ) == true )
                //    {
                //        try
                //        {
                //            SqlHelper.ExecuteNonQuery( "UPDATE R_PQAE SET AE08='" + gvHe.GetDataRow( i )["HT66"].ToString( ) + "' WHERE AE02='" + gvHe.GetDataRow( i )["PQF01"].ToString( ) + "'" );
                //        }
                //        catch { }
                //    }
                //}
            } 
            else
                label46.Visible = false;
        }
        //删除
        protected override void delete ( )
        {
            base . delete ( );

            if ( Logins . number .Equals( "MLL-0001" ))
                dele ( );
            else
            {
                if ( label46 . Visible )
                    MessageBox . Show ( "单号:" + _model.HT64 + "的单据状态为执行,不允许删除" );
                else
                    dele ( );
            }
        }
        void dele ( )
        {
            if ( string . IsNullOrEmpty ( _model.HT64 ) )
                MessageBox . Show ( "请查询需要删除的信息" );
            else
            {
                //HT02 = textB1 . Text;
                //int count = SqlHelper . ExecuteNonQuery ( "DELETE FROM R_PQL WHERE HT64=@HT64" ,new SqlParameter ( "@HT64" ,HT64 ) );
                result = _bll . Delete ( _model . HT64 ,this . Text ,Logins . username );
                if ( result == false )
                    MessageBox . Show ( "删除失败" );
                else
                {
                    MessageBox . Show ( "成功删除" );

                    Ergodic . FormEvery ( this );
                    gcHe . DataSource = null;

                    toolAdd . Enabled = toolSelect . Enabled = true;
                    toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolMaintain . Enabled = toolPrint . Enabled = toolExport . Enabled = toolCancel . Enabled = toolSave . Enabled = false;
                    button2 . Enabled = button3 . Enabled = button4 . Enabled = button5 . Enabled = button6 . Enabled = button7 . Enabled = button8 . Enabled = button9 . Enabled = button24 . Enabled = button25 . Enabled = button26 . Enabled = false;
                    label46 . Visible = false;
                    weihu = "";

                    Ergodic . FormGroupboxEnableFalse ( this ,gb );
                    textBox35 . Enabled = false;
                    //try
                    //{
                    //    SqlHelper . ExecuteNonQuery ( "DELETE FROM R_REVIEWS WHERE RES01=(SELECT CX01 FROM R_MLLCXMC WHERE CX02=@CX02) AND RES06=@RES06" ,new SqlParameter ( "@CX02" ,this . Text ) ,new SqlParameter ( "@RES06" ,HT64 ) );
                    //}
                    //catch { }
                }
            }
        }
        //维护
        protected override void maintain ( )
        {
            base . maintain ( );

            //DataTable del = SqlHelper.ExecuteDataTable( "SELECT RES03,RES05,RES06,DBA012,CX02 FROM TPADBA A,R_REVIEW B,R_REVIEWS C,R_MLLCXMC D WHERE A.DBA001=B.RE01 AND B.RE01=C.RES03 AND C.RES01=D.CX01 AND RES06=@RES06 AND CX02=@CX02", new SqlParameter( "@RES06", HT64 ), new SqlParameter( "@CX02", this.Text ) );
            if ( label46 . Visible == true )
            {
                toolAdd . Enabled = toolSelect . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolMaintain . Enabled = toolPrint . Enabled = toolExport . Enabled = false;
                toolCancel . Enabled = toolSave . Enabled = true;
                button1 . Enabled = button2 . Enabled = button3 . Enabled = button4 . Enabled = button5 . Enabled = button6 . Enabled = button7 . Enabled = button8 . Enabled = button9 . Enabled = true;
                button24 . Enabled = button25 . Enabled = button26 . Enabled = false;

                Ergodic . FormGroupboxEnableTrue ( this ,gb );

                textBox35 . Enabled = true;
                dateTimePicker2 . Enabled = dateTimePicker3 . Enabled = false;
                label46 . Visible = true;
                weihu = "1";
            }
            else
                MessageBox . Show ( "此单据没有被执行,只需更改即可,无需维护" );
        }
        #endregion

        #region  表格
        //编辑
        private void button3_Click ( object sender ,EventArgs e )
        {
            int num = gvHe . FocusedRowHandle;
            if ( num < 0 || num > gvHe . DataRowCount - 1 )
            {
                MessageBox . Show ( "请选择需要编辑的内容" );
                return;
            }
            _model . idx = string . IsNullOrEmpty ( gvHe . GetDataRow ( num ) [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( gvHe . GetDataRow ( num ) [ "idx" ] . ToString ( ) );
            if ( string . IsNullOrEmpty ( textB1 . Text ) )
            {
                MessageBox . Show ( "请选择合同号" );
                return;
            }
            if ( string . IsNullOrEmpty ( textBox7 . Text ) )
            {
                MessageBox . Show ( "请选择流水号等信息" );
                return;
            }
            if ( string . IsNullOrEmpty ( lookUpEdit1 . Text ) )
            {
                MessageBox . Show ( "生产车间不可为空" );
                return;
            }
            _model . HT07 = textBox8 . Text;
            _model . HT01 = textBox7 . Text;
            _model . HT02 = textB1 . Text;
            _model . HT66 = lookUpEdit1 . Text;
            
            if ( textBox4 . Text != "" )
                PQF6 = Convert . ToInt64 ( textBox4 . Text );
            else
                PQF6 = 0;
            //int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQL SET HT01=@HT01,HT07=@HT07,HT65=@HT65,HT66=@HT66 WHERE idx=@idx" ,new SqlParameter( "@HT07" ,HT7 ) ,new SqlParameter( "@HT01" ,HT01 ) ,new SqlParameter( "@HT65" ,HT065 ) ,new SqlParameter( "@HT66" ,HT066 ) ,new SqlParameter ( "@idx" ,idx ) );
            result = _bll . Update ( _model ,Logins . username );
            if ( result == false )
                MessageBox . Show ( "编辑数据失败" );
            else
            {
                MessageBox . Show ( "成功编辑数据" );
                //try
                //{
                //    SqlHelper.ExecuteNonQuery( "UPDATE R_PQF SET PQF25=@PQF25,PQF17=@PQF17 WHERE PQF01=@PQF01" ,new SqlParameter( "@PQF25" ,HT7 ) ,new SqlParameter( "@PQF01" ,HT01 ) ,new SqlParameter( "@PQF17" ,HT065 ) );
                //}
                //catch { }
                //finally
                //{
                DataRow row;
                row = tableView . Rows [ num ];
                row . BeginEdit ( );
                row [ "PQF01" ] = textBox7 . Text;
                row [ "PQF03" ] = textBox13 . Text;
                row [ "PQF04" ] = textBox2 . Text;
                row [ "PQF05" ] = textBox3 . Text;
                row [ "PQF06" ] = PQF6;
                row [ "PQF07" ] = textBox6 . Text;
                row [ "PQF08" ] = textBox9 . Text;
                row [ "PQF09" ] = textBox5 . Text;
                row [ "PQF31" ] = dateTimePicker2 . Value;
                row [ "HT65" ] = _model . HT65;
                row [ "HT66" ] = _model . HT66;
                row [ "HT07" ] = _model . HT07;
                row . EndEdit ( );
                gcHe . RefreshDataSource ( );
            }
        }
        //删除
        private void button1_Click ( object sender ,EventArgs e )
        {
            int num = gvHe . FocusedRowHandle;
            if ( num < 0 || num > gvHe . DataRowCount - 1 )
            {
                MessageBox . Show ( "请选择需要删除的内容" );
                return;
            }
            _model . idx = string . IsNullOrEmpty ( gvHe . GetDataRow ( num ) [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( gvHe . GetDataRow ( num ) [ "idx" ] . ToString ( ) );
            if ( string . IsNullOrEmpty ( textB1 . Text ) )
            {
                MessageBox . Show ( "请选择合同号" );
                return;
            }
            if ( string . IsNullOrEmpty ( textBox7 . Text ) )
            {
                MessageBox . Show ( "流水号不可为空" );
                return;
            }

            _model . HT01 = textBox7 . Text;
            _model . HT02 = textB1 . Text;
            //int count = SqlHelper . ExecuteNonQuery ( "DELETE FROM R_PQL WHERE idx=@idx" ,new SqlParameter ( "@idx" ,idx ) );
            result = _bll . Delete ( _model ,Logins . username );
            if ( result == false )
                MessageBox . Show ( "删除数据失败" );
            else
            {
                MessageBox . Show ( "成功删除数据" );
                //try
                //{
                //    SqlHelper . ExecuteNonQuery ( "UPDATE R_PQF SET PQF25=@PQF25 WHERE PQF01=@PQF01" ,new SqlParameter ( "@PQF25" ,HT7 ) ,new SqlParameter ( "@PQF01" ,HT01 ) );
                //}
                //catch { }
                //finally
                //{
                //if ( sav == "1" )
                //{
                //    dee . Rows . RemoveAt ( num );
                //}
                //else if ( sav == "2" )
                //{
                //    daa . Rows . RemoveAt ( num );
                //}
                tableView . Rows . RemoveAt ( num );
                gcHe . RefreshDataSource ( );
                //}
            }
        }
        //新建
        private void build ( )
        {
            //try
            //{
            //    SqlHelper.ExecuteNonQuery( "UPDATE R_PQF SET PQF25=@PQF25,PQF17=@PQF17 WHERE PQF01=@PQF01" ,new SqlParameter( "@PQF25" ,HT7 ) ,new SqlParameter( "@PQF01" ,HT01 ) ,new SqlParameter ( "@PQF17" ,HT065 ) );
            //}
            //catch { }
            //finally
            //{
            //    
            //    if ( sav == "1" )
            //    {
            //        dee = SqlHelper.ExecuteDataTable( "SELECT PQF01,PQF03,PQF04,PQF05,PQF06,PQF07,PQF08,PQF09,PQF31,HT07,HT65,HT66  FROM R_PQF A,R_PQL B WHERE A.PQF01=B.HT01 AND HT64=@HT64" ,new SqlParameter( "@HT64" ,HT64 ) );
            //        gcHe.DataSource = dee;
            //    }
            //    else if ( sav == "2" )
            //    {
            DataRow row;
            row = tableView . NewRow ( );
            row [ "PQF01" ] = textBox7 . Text;
            row [ "PQF03" ] = textBox13 . Text;
            row [ "PQF04" ] = textBox2 . Text;
            row [ "PQF05" ] = textBox3 . Text;
            row [ "PQF06" ] = PQF6;
            row [ "PQF07" ] = textBox6 . Text;
            row [ "PQF08" ] = textBox9 . Text;
            row [ "PQF09" ] = textBox5 . Text;
            row [ "PQF31" ] = dateTimePicker2 . Value;
            row [ "HT65" ] = _model . HT65;
            row [ "HT66" ] = _model . HT66;
            row [ "HT07" ] = _model . HT07;
            tableView . Rows . Add ( row );
            gcHe . RefreshDataSource ( );
            //}
        }
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( textB1 . Text ) )
            {
                MessageBox . Show ( "请选择合同号" );
                return;
            }
            if ( string . IsNullOrEmpty ( textBox7 . Text ) )
            {
                MessageBox . Show ( "请选择流水号等信息" );
                return;
            }
            if ( string . IsNullOrEmpty ( lookUpEdit1 . Text ) )
            {
                MessageBox . Show ( "生厂车间不可为空" );
                return;
            }
            _model . HT07 = textBox8 . Text;
            _model . HT01 = textBox7 . Text;
            _model . HT02 = textB1 . Text;
            _model . HT66 = lookUpEdit1 . Text;
            if ( textBox4 . Text != "" )
                PQF6 = Convert . ToInt64 ( textBox4 . Text );
            else
                PQF6 = 0;

            result = _bll . ExistsNum ( _model . HT01 );

            if ( result )
                MessageBox . Show ( "流水号为：" + HT01 + "的数据已经存在，请核实后再录入" );
            else
            {
                //int count = SqlHelper . ExecuteNonQuery ( "INSERT INTO R_PQL (HT64,HT01,HT02,HT07,HT65,HT66) VALUES (@HT64,@HT01,@HT02,@HT07,@HT65,@HT66)" ,new SqlParameter ( "@HT01" ,HT01 ) ,new SqlParameter ( "@HT02" ,HT02 ) ,new SqlParameter ( "@HT07" ,HT7 ) ,new SqlParameter ( "@HT64" ,HT64 ) ,new SqlParameter ( "@HT65" ,HT065 ) ,new SqlParameter ( "@HT66" ,HT066 ) );
                result = _bll . Insert ( _model ,Logins . username );
                if ( result == false )
                    MessageBox . Show ( "录入数据失败" );
                else
                {
                    MessageBox . Show ( "成功录入数据" );
                    build ( );
                }
            }
        }
        //刷新
        private void button27_Click ( object sender ,EventArgs e )
        {
            tableView = _bll . getTableView ( _model . HT64 );
            gcHe . DataSource = tableView;
        }
        #endregion

        #region 事件
        string pqf1 = "";
        private void gvHe_FocusedRowChanged( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
            if (gvHe.RowCount < 1)
                Ergodic.GroupboxEvery( groupBox11 );
            else
            {
                textBox7.Text = this.gvHe.GetRowCellValue( e.FocusedRowHandle, "PQF01" ).ToString( );
                textBox13.Text = this.gvHe.GetRowCellValue( e.FocusedRowHandle, "PQF03" ).ToString( );
                textBox2.Text = this.gvHe.GetRowCellValue( e.FocusedRowHandle, "PQF04" ).ToString( );
                textBox3.Text = this.gvHe.GetRowCellValue( e.FocusedRowHandle, "PQF05" ).ToString( );
                textBox4.Text = this.gvHe.GetRowCellValue( e.FocusedRowHandle, "PQF06" ).ToString( );
                if (string.IsNullOrEmpty( this.gvHe.GetRowCellValue( e.FocusedRowHandle, "PQF31" ).ToString( ) ))
                {
                    dateTimePicker2.Value = MulaolaoBll . Drity . GetDt ( );
                }
                else
                {
                    dateTimePicker2.Value = Convert.ToDateTime( this.gvHe.GetRowCellValue( e.FocusedRowHandle, "PQF31" ) );
                }
                textBox6.Text = this.gvHe.GetRowCellValue( e.FocusedRowHandle, "PQF07" ).ToString( );
                textBox9.Text = this.gvHe.GetRowCellValue( e.FocusedRowHandle, "PQF08" ).ToString( );
                textBox5.Text = this.gvHe.GetRowCellValue( e.FocusedRowHandle, "PQF09" ).ToString( );
                textBox8.Text = this.gvHe.GetRowCellValue( e.FocusedRowHandle, "HT07" ).ToString( );
                lookUpEdit1 . EditValue =_model. HT65 = this . gvHe . GetRowCellValue ( e . FocusedRowHandle ,"HT65" ) . ToString ( );
                //lookUpEdit1.Text = this.gvHe.GetRowCellValue( e.FocusedRowHandle ,"HT66" ).ToString( );
                pqf1 = textBox7.Text;
            }
        }
        private void gvHe_Click ( object sender ,EventArgs e )
        {
            if ( gvHe . RowCount == 1 )
            {
                textBox7 . Text = this . gvHe . GetFocusedRowCellValue ( "PQF01" ) . ToString ( );
                textBox13 . Text = this . gvHe . GetFocusedRowCellValue ( "PQF03" ) . ToString ( );
                textBox2 . Text = this . gvHe . GetFocusedRowCellValue ( "PQF04" ) . ToString ( );
                textBox3 . Text = this . gvHe . GetFocusedRowCellValue ( "PQF05" ) . ToString ( );
                textBox4 . Text = this . gvHe . GetFocusedRowCellValue ( "PQF06" ) . ToString ( );
                if ( string . IsNullOrEmpty ( this . gvHe . GetFocusedRowCellValue ( "PQF31" ) . ToString ( ) ) )
                {
                    dateTimePicker2 . Value = MulaolaoBll . Drity . GetDt ( );
                }
                else
                {
                    dateTimePicker2 . Value = Convert . ToDateTime ( this . gvHe . GetFocusedRowCellValue ( "PQF31" ) );
                }
                textBox6 . Text = this . gvHe . GetFocusedRowCellValue ( "PQF07" ) . ToString ( );
                textBox9 . Text = this . gvHe . GetFocusedRowCellValue ( "PQF08" ) . ToString ( );
                textBox5 . Text = this . gvHe . GetFocusedRowCellValue ( "PQF09" ) . ToString ( );
                textBox8 . Text = this . gvHe . GetFocusedRowCellValue ( "HT07" ) . ToString ( );
                lookUpEdit1 . EditValue = _model . HT65 = this . gvHe . GetFocusedRowCellValue ( "HT65" ) . ToString ( );
                //lookUpEdit1.Text = this.gvHe.GetFocusedRowCellValue( "HT66" ).ToString( );
                pqf1 = textBox7 . Text;
            }
        }
        //业务员签字
        private void button24_Click( object sender, EventArgs e )
        {
            if (textBox1.Text == "")
                textBox1.Text = Logins.username;
            else if (textBox1.Text != "" && textBox1.Text==Logins.username)
                textBox1.Text = "";
        }
        //业务部经理签字
        private void button25_Click( object sender, EventArgs e )
        {
            if (textB27.Text == "")
                textB27.Text = Logins.username;
            else if (textB27.Text != "" && textB27.Text==Logins.username)
                textB27.Text = "";
        }
        //总经理签字
        private void button26_Click( object sender, EventArgs e )
        {
            if (textB28.Text == "")
                textB28.Text = Logins.username;
            else if (textB28.Text != "" && textB28.Text==Logins.username)
                textB28.Text = "";
        }
        //窗体关闭事件
        private void R_FrmContractreview_FormClosing( object sender, FormClosingEventArgs e )
        {
            if (toolSave.Enabled)
            {
                cancel( );
            }

            if ( !Directory.Exists( path ) )
            {
                Directory.CreateDirectory( path );
            }
            gcHe.MainView.SaveLayoutToXml( path + file );
        }
        private void lookUpEdit1_EditValueChanged ( object sender ,EventArgs e )
        {
            if ( !string.IsNullOrEmpty( lookUpEdit1.Text ) )
                _model.HT65 = lookUpEdit1.EditValue.ToString( );
        }
        #endregion

        #region  查询
        DataTable daa;
        string HT01 = "", HT02 = "", HT03 = "";
        R_FrmContractreviewb conb = new R_FrmContractreviewb( );
        R_FrmTPADFA tpadfa = new R_FrmTPADFA( );
        string DFA001 = "", biaoji = "";
        //流水号查询
        private void button6_Click ( object sender , EventArgs e )
        {
            if ( HT02 == "" )
                MessageBox. Show ( "请选择合同号" );
            else
            {
                DataTable da = SqlHelper. ExecuteDataTable ( "SELECT PQF01 ,PQF03 ,PQF04 ,PQF05 ,PQF06 ,PQF07 ,PQF08 ,PQF09 ,PQF31 FROM R_PQF A, R_REVIEWS B, R_MLLCXMC C WHERE A.PQF01 = B.RES06 AND B.RES01 = C.CX01 AND CX02 = '订单销售合同(R_001)' AND B.RES05 = '执行' AND PQF02=@PQF02 ORDER BY PQF01 DESC" , new SqlParameter ( "@PQF02" , HT02 ) );
                if ( da. Rows. Count < 1 )
                    MessageBox. Show ( "没有任何产品信息" );
                else
                {
                    conb. gridControl1. DataSource = da;
                    conb. PassDataBetweenForm += new R_FrmContractreviewb. PassDataBetweenFormHandler ( conb_PassDataBetweenForm );
                    conb. StartPosition = FormStartPosition. CenterScreen;
                    conb. r21 = "1";
                    biaoji = "1";
                    conb. ShowDialog ( );
                }
            }
        }
        private void conb_PassDataBetweenForm( object sender, PassDataWinFormEventArgs e )
        {
            if (biaoji == "1")
            {
                textBox7.Text = e.ConOne;
                textBox13.Text = e.ConTwo;
                textBox2.Text = e.ConTre;
                textBox3.Text = e.ConFor;
                textBox4.Text = e.ConFiv;
                textBox6.Text = e.ConSix;
                textBox9.Text = e.ConSev;
                textBox5.Text = e.ConEgi;
                if (!string.IsNullOrEmpty( e.ConNin))
                    dateTimePicker2.Value = Convert.ToDateTime( e.ConNin );
            }
            else if (biaoji == "2")
            {
                HT02 = e.ConOne;
                HT03 = e.ConTwo;
                if (!string.IsNullOrEmpty( e.ConTre ))
                {
                    dateTimePicker1.Value = Convert.ToDateTime( e.ConTre );
                    _model . HT04 = Convert . ToDateTime ( e . ConTre );
                }
                textBox11.Text = e.ConFor;
                textBox12.Text = e.ConFiv;
                textBox10.Text = e.ConSix;
                if ( e.ConSev == "执行" )
                    label46.Visible = true;
                else
                    label46.Visible = false;
                _model . HT64 = e . ConEgi;
            }
        }
        //客户合同号以及顾客信息
        private void button5_Click( object sender, EventArgs e )
        {
            DataTable de = SqlHelper.ExecuteDataTable( "SELECT DISTINCT PQF02,DFA001,DFA003,DFA015,DFA016 FROM R_PQF A, TPADFA B WHERE A.PQF11=B.DFA001" );
            if (de.Rows.Count < 1)
                MessageBox.Show( "没有任何客户信息" );
            else
            {
                tpadfa.gridControl1.DataSource = de;
                tpadfa.dfa = "1";
                tpadfa.PassDataBetweenForm += new R_FrmTPADFA.PassDataBetweenFormHandler( tpadfa_PassDataBetweenForm );
                tpadfa.StartPosition = FormStartPosition.CenterScreen;
                tpadfa.ShowDialog( );
            }
        }
        private void tpadfa_PassDataBetweenForm( object sender, PassDataWinFormEventArgs e )
        {
            DFA001 = e.ConOne;
            textBox11.Text = e.ConTwo;
            textBox12.Text = e.ConTre;
            textBox10.Text = e.ConFor;
            HT02 = e.ConFiv;
            textB1.Text = e.ConFiv;
        }
        //查询
        void autoQuery ( )
        {
            toolAdd . Enabled = toolSelect . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolMaintain . Enabled = toolPrint . Enabled = toolExport . Enabled = true;
            toolCancel . Enabled = toolSave . Enabled = false;
            button1 . Enabled = button2 . Enabled = button3 . Enabled = button4 . Enabled = button5 . Enabled = button6 . Enabled = button24 . Enabled = button25 . Enabled = button26 . Enabled = false;

            textBox35 . Enabled = false;

            sav = "2";

            DataTable da = SqlHelper . ExecuteDataTable ( "SELECT TOP 1 * FROM R_PQL WHERE HT64=@HT64" ,new SqlParameter ( "@HT64" ,_model . HT64 ) );
            if ( da . Rows . Count > 0 )
            {
                textB1 . Text = da . Rows [ 0 ] [ "HT02" ] . ToString ( );
                comb1 . Text = da . Rows [ 0 ] [ "HT03" ] . ToString ( );
                textBox14 . Text = da . Rows [ 0 ] [ "HT18" ] . ToString ( );
                textBox15 . Text = da . Rows [ 0 ] [ "HT20" ] . ToString ( );
                textBox30 . Text = da . Rows [ 0 ] [ "HT21" ] . ToString ( );
                textBox16 . Text = da . Rows [ 0 ] [ "HT23" ] . ToString ( );
                textBox17 . Text = da . Rows [ 0 ] [ "HT25" ] . ToString ( );
                textBox31 . Text = da . Rows [ 0 ] [ "HT26" ] . ToString ( );
                textBox18 . Text = da . Rows [ 0 ] [ "HT28" ] . ToString ( );
                textBox19 . Text = da . Rows [ 0 ] [ "HT30" ] . ToString ( );
                textBox20 . Text = da . Rows [ 0 ] [ "HT32" ] . ToString ( );
                textBox21 . Text = da . Rows [ 0 ] [ "HT34" ] . ToString ( );
                textBox32 . Text = da . Rows [ 0 ] [ "HT35" ] . ToString ( );
                textBox22 . Text = da . Rows [ 0 ] [ "HT37" ] . ToString ( );
                textBox23 . Text = da . Rows [ 0 ] [ "HT39" ] . ToString ( );
                textBox33 . Text = da . Rows [ 0 ] [ "HT40" ] . ToString ( );
                textBox24 . Text = da . Rows [ 0 ] [ "HT42" ] . ToString ( );
                textBox25 . Text = da . Rows [ 0 ] [ "HT44" ] . ToString ( );
                textBox34 . Text = da . Rows [ 0 ] [ "HT45" ] . ToString ( );
                textBox26 . Text = da . Rows [ 0 ] [ "HT47" ] . ToString ( );
                textBox27 . Text = da . Rows [ 0 ] [ "HT49" ] . ToString ( );
                textBox28 . Text = da . Rows [ 0 ] [ "HT51" ] . ToString ( );
                textBox29 . Text = da . Rows [ 0 ] [ "HT52" ] . ToString ( );
                textBox35 . Text = da . Rows [ 0 ] [ "HT55" ] . ToString ( );
                textBox1 . Text = da . Rows [ 0 ] [ "HT09" ] . ToString ( );
                textB27 . Text = da . Rows [ 0 ] [ "HT10" ] . ToString ( );
                textB28 . Text = da . Rows [ 0 ] [ "HT11" ] . ToString ( );

                if ( da . Rows [ 0 ] [ "HT12" ] . ToString ( ) == label43 . Text )
                    dateTimePicker3 . Value = Convert . ToDateTime ( da . Rows [ 0 ] [ "HT12" ] );

                //string str = da . Rows [ 0 ] [ "HT08" ] . ToString ( );

                if ( da == null || da . Rows [ 0 ] [ "HT08" ] == null || string . IsNullOrEmpty ( da . Rows [ 0 ] [ "HT08" ] . ToString ( ) ) )
                    pictureBox1 . Image = null;
                else if ( ( ( byte [ ] ) da . Rows [ 0 ] [ "HT08" ] ) . Length == 0 )
                    pictureBox1 . Image = null;
                else
                {
                    byte [ ] mybyte = ( byte [ ] ) da . Rows [ 0 ] [ "HT08" ];
                    MemoryStream ms = new MemoryStream ( mybyte );
                    ms . Write ( mybyte ,0 ,mybyte . Length );
                    ms . Position = 0;
                    ms . Seek ( 0 ,SeekOrigin . Begin );
                    Image img = Image . FromStream ( ms ,true );
                    pictureBox1 . Image = img;
                }
                if ( da == null || da . Rows [ 0 ] [ "HT58" ] == null || string . IsNullOrEmpty ( da . Rows [ 0 ] [ "HT58" ] . ToString ( ) ) )
                    pictureBox2 . Image = null;
                else if ( ( ( byte [ ] ) da . Rows [ 0 ] [ "HT58" ] ) . Length == 0 )
                    pictureBox2 . Image = null;
                else
                {
                    byte [ ] mybyte = ( byte [ ] ) da . Rows [ 0 ] [ "HT58" ];
                    MemoryStream ms = new MemoryStream ( mybyte );
                    ms . Write ( mybyte ,0 ,mybyte . Length );
                    ms . Position = 0;
                    ms . Seek ( 0 ,SeekOrigin . Begin );
                    Image img = Image . FromStream ( ms ,true );
                    pictureBox2 . Image = img;
                }
                if ( da == null || da . Rows [ 0 ] [ "HT59" ] == null || string . IsNullOrEmpty ( da . Rows [ 0 ] [ "HT59" ] . ToString ( ) ) )
                    pictureBox4 . Image = null;
                else if ( ( ( byte [ ] ) da . Rows [ 0 ] [ "HT59" ] ) . Length == 0 )
                    pictureBox4 . Image = null;
                else
                {
                    byte [ ] mybyte = ( byte [ ] ) da . Rows [ 0 ] [ "HT59" ];
                    MemoryStream ms = new MemoryStream ( mybyte );
                    ms . Write ( mybyte ,0 ,mybyte . Length );
                    ms . Position = 0;
                    ms . Seek ( 0 ,SeekOrigin . Begin );
                    Image img = Image . FromStream ( ms ,true );
                    pictureBox4 . Image = img;
                }
                if ( da == null || da . Rows [ 0 ] [ "HT60" ] == null || string . IsNullOrEmpty ( da . Rows [ 0 ] [ "HT60" ] . ToString ( ) ) )
                    pictureBox3 . Image = null;
                else if ( ( ( byte [ ] ) da . Rows [ 0 ] [ "HT60" ] ) . Length == 0 )
                    pictureBox3 . Image = null;
                else
                {
                    byte [ ] mybyte = ( byte [ ] ) da . Rows [ 0 ] [ "HT60" ];
                    MemoryStream ms = new MemoryStream ( mybyte );
                    ms . Write ( mybyte ,0 ,mybyte . Length );
                    ms . Position = 0;
                    ms . Seek ( 0 ,SeekOrigin . Begin );
                    Image img = Image . FromStream ( ms ,true );
                    pictureBox3 . Image = img;
                }
                if ( da == null || da . Rows [ 0 ] [ "HT61" ] == null || string . IsNullOrEmpty ( da . Rows [ 0 ] [ "HT61" ] . ToString ( ) ) )
                    pictureBox6 . Image = null;
                else if ( ( ( byte [ ] ) da . Rows [ 0 ] [ "HT61" ] ) . Length == 0 )
                    pictureBox6 . Image = null;
                else
                {
                    byte [ ] mybyte = ( byte [ ] ) da . Rows [ 0 ] [ "HT61" ];
                    MemoryStream ms = new MemoryStream ( mybyte );
                    ms . Write ( mybyte ,0 ,mybyte . Length );
                    ms . Position = 0;
                    ms . Seek ( 0 ,SeekOrigin . Begin );
                    Image img = Image . FromStream ( ms ,true );
                    pictureBox6 . Image = img;
                }
                if ( da == null || da . Rows [ 0 ] [ "HT62" ] == null || string . IsNullOrEmpty ( da . Rows [ 0 ] [ "HT62" ] . ToString ( ) ) )
                    pictureBox5 . Image = null;
                else if ( ( da != null && da . Rows [ 0 ] [ "HT62" ] != null ) && ( ( byte [ ] ) da . Rows [ 0 ] [ "HT62" ] ) . Length == 0 )
                    pictureBox5 . Image = null;
                else
                {
                    byte [ ] mybyte = ( byte [ ] ) da . Rows [ 0 ] [ "HT62" ];
                    MemoryStream ms = new MemoryStream ( mybyte );
                    ms . Write ( mybyte ,0 ,mybyte . Length );
                    ms . Position = 0;
                    ms . Seek ( 0 ,SeekOrigin . Begin );
                    Image img = Image . FromStream ( ms ,true );
                    pictureBox5 . Image = img;
                }
                button27_Click ( null ,null );
                //daa = SqlHelper.ExecuteDataTable( "SELECT B.idx,PQF01 ,PQF03 ,PQF04 ,PQF05 ,PQF06 ,PQF07 ,PQF08 ,PQF09 ,PQF31 ,HT07,HT65,HT66  FROM R_PQF A,R_PQL B WHERE A.PQF01=B.HT01 AND HT64=@HT64" ,new SqlParameter( "@HT64" ,HT64 ) );
                //gcHe.DataSource = daa;
            }
        }
        protected override void select ( )
        {
            base.select( );

            //DataTable dql = SqlHelper.ExecuteDataTable( "SELECT DISTINCT PQF01,HT64,HT02,HT03,HT04,DFA003,DFA015,DFA016,(SELECT RES05 FROM R_REVIEWS WHERE RES04=(SELECT MAX(RES04) FROM R_REVIEWS WHERE RES06=HT64)) RES05 FROM R_PQL A,R_PQF B,TPADFA C WHERE A.HT01=B.PQF01 AND B.PQF11=C.DFA001 ORDER BY HT64 DESC" );
            //if ( dql . Rows . Count < 1 )
            //    MessageBox . Show ( "没有任何评审信息" );
            //else
            //{
            //    conb . gridControl1 . DataSource = dql;
            //    conb . r21 = "2";
            //    biaoji = "2";
            //    conb . PassDataBetweenForm += new R_FrmContractreviewb . PassDataBetweenFormHandler ( conb_PassDataBetweenForm );
            //    conb . StartPosition = FormStartPosition . CenterScreen;
            //    conb . ShowDialog ( );

            //    if ( _model . HT64 == "" )
            //        MessageBox . Show ( "您没有选择任何信息" );
            //    else
            //        autoQuery ( );
            //}

            SelectAll . ContractreviewQuery from = new SelectAll . ContractreviewQuery ( this . Text + "查询" );
            if ( from . ShowDialog ( ) == DialogResult . OK )
            {
                _model . HT64 = from . getOdd;
                if ( from . getState . Equals ( "执行" ) )
                    label46 . Visible = true;
                else
                    label46 . Visible = false;
                autoQuery ( );
            }
        }
        #endregion

        #region 初审
        //byte[] HT08 = new byte[0];
        //byte[] HT58 = new byte[0];
        //byte[] HT59 = new byte[0];
        //byte[] HT60 = new byte[0];
        //byte[] HT61 = new byte[0];
        //byte[] HT62 = new byte[0];
        R_FrmImageAmplication ima = new R_FrmImageAmplication( );
        //合同初审
        string filePath1 = "";
        private void button4_Click( object sender, EventArgs e )
        {
            OpenFileDialog ofd = new OpenFileDialog( );
            ofd.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
            if (ofd.ShowDialog( ) == DialogResult.OK)
            {
                filePath1 = ofd.FileName;//图片路径
                pictureBox1.ImageLocation = filePath1;

                FileStream fs = new FileStream( filePath1, FileMode.Open, FileAccess.Read );
                //byte[] imageBytes = new byte[fs.Length];
                BinaryReader br = new BinaryReader( fs );
                _model . HT08 = br . ReadBytes ( ( int ) fs . Length );//图片转换成二进制流    
            }
        }
        //放大
        private void button7_Click( object sender, EventArgs e )
        {
            if (pictureBox1.ImageLocation == "")
                MessageBox.Show( "没有图片,不能放大" );
            else
            {
                ima.pictureBox1.Image = pictureBox1.Image;
                ima.ShowDialog( );
            }
        }
        //删除
        private void button8_Click( object sender, EventArgs e )
        {
            pictureBox1.Image = null;
            pictureBox1.ImageLocation = "";
            _model . HT08 = new byte [ 0 ];
        }
        string filePath2 = "";
        private void button11_Click( object sender, EventArgs e )
        {
            OpenFileDialog ofd = new OpenFileDialog( );
            ofd.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
            if (ofd.ShowDialog( ) == DialogResult.OK)
            {
                filePath2 = ofd.FileName;//图片路径
                pictureBox2.ImageLocation = filePath2;

                FileStream fs = new FileStream( filePath2, FileMode.Open, FileAccess.Read );
                //byte[] imageBytes = new byte[fs.Length];
                BinaryReader br = new BinaryReader( fs );
                _model.HT58 = br.ReadBytes( (int)fs.Length );//图片转换成二进制流    
            }
        }
        //放大
        private void button10_Click( object sender, EventArgs e )
        {
            if (pictureBox2.ImageLocation == "")
                MessageBox.Show( "没有图片,不能放大" );
            else
            {
                ima.pictureBox1.Image = pictureBox2.Image;
                ima.ShowDialog( );
            }
        }
        //删除
        private void button9_Click( object sender, EventArgs e )
        {
            pictureBox2.Image = null;
            pictureBox2.ImageLocation = "";
            _model.HT58 = new byte[0];
        }
        string filePath3 = "";
        private void button17_Click( object sender, EventArgs e )
        {
            OpenFileDialog ofd = new OpenFileDialog( );
            //ofd.Filter = "*jpg|*.JPG|*.GIF|*.BMP";
            ofd.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
            if (ofd.ShowDialog( ) == DialogResult.OK)
            {
                filePath3 = ofd.FileName;//图片路径
                pictureBox4.ImageLocation = filePath3;

                FileStream fs = new FileStream( filePath3, FileMode.Open, FileAccess.Read );
                //byte[] imageBytes = new byte[fs.Length];
                BinaryReader br = new BinaryReader( fs );
                _model.HT59 = br.ReadBytes( (int)fs.Length );//图片转换成二进制流    
            }
        }
        //放大
        private void button16_Click( object sender, EventArgs e )
        {
            if (pictureBox4.ImageLocation == "")
                MessageBox.Show( "没有图片,不能放大" );
            else
            {
                ima.pictureBox1.Image = pictureBox4.Image;
                ima.ShowDialog( );
            }
        }
        //删除
        private void button15_Click( object sender, EventArgs e )
        {
            pictureBox4.Image = null;
            pictureBox4.ImageLocation = "";
            _model.HT59 = new byte[0];
        }
        string filePath4 = "";
        private void button14_Click( object sender, EventArgs e )
        {
            OpenFileDialog ofd = new OpenFileDialog( );
            ofd.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
            if (ofd.ShowDialog( ) == DialogResult.OK)
            {
                filePath4 = ofd.FileName;//图片路径
                pictureBox3.ImageLocation = filePath4;

                FileStream fs = new FileStream( filePath4, FileMode.Open, FileAccess.Read );
                //byte[] imageBytes = new byte[fs.Length];
                BinaryReader br = new BinaryReader( fs );
                _model.HT60 = br.ReadBytes( (int)fs.Length );//图片转换成二进制流    
            }
        }
        //放大
        private void button13_Click( object sender, EventArgs e )
        {
            if (pictureBox3.ImageLocation == "")
                MessageBox.Show( "没有图片,不能放大" );
            else
            {
                ima.pictureBox1.Image = pictureBox3.Image;
                ima.ShowDialog( );
            }
        }
        //删除
        private void button12_Click( object sender, EventArgs e )
        {
            pictureBox3.Image = null;
            pictureBox3.ImageLocation = "";
            _model.HT60 = new byte[0];
        }
        string filePath5 = "";
        private void button23_Click( object sender, EventArgs e )
        {
            OpenFileDialog ofd = new OpenFileDialog( );
            ofd.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
            if (ofd.ShowDialog( ) == DialogResult.OK)
            {
                filePath5 = ofd.FileName;//图片路径
                pictureBox6.ImageLocation = filePath5;

                FileStream fs = new FileStream( filePath5, FileMode.Open, FileAccess.Read );
                //byte[] imageBytes = new byte[fs.Length];
                BinaryReader br = new BinaryReader( fs );
                _model.HT61 = br.ReadBytes( (int)fs.Length );//图片转换成二进制流    
            }
        } 
        //放大
        private void button22_Click( object sender, EventArgs e )
        {
            if (pictureBox6.ImageLocation == "")
                MessageBox.Show( "没有图片,不能放大" );
            else
            {
                ima.pictureBox1.Image = pictureBox6.Image;
                ima.ShowDialog( );
            }
        }
        //删除
        private void button21_Click( object sender, EventArgs e )
        {
            pictureBox6.Image = null;
            pictureBox6.ImageLocation = "";
            _model.HT61 = new byte[0];
        }
        string filePath6 = "";
        private void button20_Click( object sender, EventArgs e )
        {
            OpenFileDialog ofd = new OpenFileDialog( );
            ofd.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
            if (ofd.ShowDialog( ) == DialogResult.OK)
            {
                filePath6 = ofd.FileName;//图片路径
                pictureBox5.ImageLocation = filePath6;

                FileStream fs = new FileStream( filePath6, FileMode.Open, FileAccess.Read );
                //byte[] imageBytes = new byte[fs.Length];
                BinaryReader br = new BinaryReader( fs );
                _model.HT62 = br.ReadBytes( (int)fs.Length );//图片转换成二进制流    
            }
        }
        //放大
        private void button19_Click( object sender, EventArgs e )
        {
            if (pictureBox5.ImageLocation == "")
                MessageBox.Show( "没有图片,不能放大" );
            else
            {
                ima.pictureBox1.Image = pictureBox5.Image;
                ima.ShowDialog( );
            }
        }
        //删除
        private void button18_Click( object sender, EventArgs e )
        {
            pictureBox5.Image = null;
            pictureBox5.ImageLocation = "";
            _model.HT62 = new byte[0];
        }
        #endregion

    }
}

using Mulaolao.Class;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using StudentMgr;

namespace Mulaolao.Other
{
    public partial class Reviews : Form
    {
        public Reviews( )
        {
            InitializeComponent( );
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            this.ControlBox = false;
        }
        SpecialPowers sp = new SpecialPowers( );
        //添加一个委托
        public delegate void PassDataBetweenFormHandler( object sender, PassDataWinFormEventArgs e );
        //添加一个PassDataBetweenFormHandler类型的事件
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        public string sta = "", CX02 = ""/*, variableOne = "", variableTwo = "", tableName = "", variableThr = "", variableFor = "", ord = "", box = "", tableNum = ""*/, num, tableNum;
       public bool formState = false;
        public bool result = false, over = false;
        private void Reviews_Load( object sender, EventArgs e )
        {
            DataTable dd = SqlHelper.ExecuteDataTable( "SELECT RES03,RES05,CX02,RES06 FROM R_REVIEWS A,R_MLLCXMC B WHERE A.RES01=B.CX01 AND CX02=@CX02 AND RES06=@RES06", new SqlParameter( "@CX02", CX02 ) ,new SqlParameter("@RES06",sta));
            DataTable de = SqlHelper.ExecuteDataTable( "SELECT * FROM R_DBB A,R_MLLCXMC B WHERE A.DBB002=B.CX01 AND DBB011='T' AND CX02=@CX02 AND DBB001=@DBB001", new SqlParameter( "@CX02", CX02 ), new SqlParameter( "@DBB001", Logins.number ) );
            DataTable dq = SqlHelper.ExecuteDataTable( "SELECT * FROM R_REVIEW A,R_MLLCXMC B WHERE A.RE02=B.CX01 AND RE01=@RE01 and CX02=@CX02", new SqlParameter( "@RE01", Logins.number ), new SqlParameter( "@CX02", CX02 ) );
            //try
            //{
            //    DataTable dl = SqlHelper.ExecuteDataTable( "SELECT * FROM R_REVIEWS A,R_MLLCXMC B WHERE A.RES01=B.CX01 AND RES03=@RES03 AND RES06=@RESO6 AND CX02=@CX02" ,new SqlParameter( "@RES03" ,Logins.number ) ,new SqlParameter( "@RES06" ,sta ) ,new SqlParameter( "@CX02" ,CX02 ) );
            //}
            //catch (Exception ex) { }
            //有权送审 
            if (dq != null && dq.Rows.Count > 0)
            {
                //已送审
                if (dd != null && dd.Rows.Count > 0)
                {
                    for (int i = 0; i < dd.Rows.Count; i++)
                    {
                        //已执行
                        if (dd.Rows[i]["RES05"].ToString( ) == "执行")
                        {
                            radioButton1.Enabled = false;
                            radioButton2.Enabled = false;
                            radioButton3.Enabled = false;
                        }
                        else
                        {
                            //未执行
    
                            //本人有执行权
                            if (de != null && de.Rows.Count > 0)
                            {
                                //若本人已经驳回  而且没有再次送审
                                //若本人没有执行过驳回或者送审 也没有送审
                                //若本人没有执行过驳回或者送审  送审过了
                                //radioButton1.Enabled = false;
                                //radioButton2.Enabled = false;
                                //radioButton3.Enabled = true;
                                radioButton1.Enabled = false;
                                radioButton2.Enabled = true;
                                radioButton3.Enabled = true;
                            }
                            //本人无执行权
                            else
                            {
                                //本人驳回  没有再次送审
                                //radioButton1.Enabled = false;
                                //radioButton2.Enabled = false;
                                //radioButton3.Enabled = false;
                                //本人送审  没有驳回
                                //radioButton1.Enabled = false;
                                //radioButton2.Enabled = false;
                                //radioButton3.Enabled = false;
                                //本人送审  被驳回   (本人是中间人)
                                radioButton1.Enabled = true;
                                radioButton2.Enabled = true;
                                radioButton3.Enabled = false;
                                //本人送审  被驳回  (本人是发起人)
                                //radioButton1.Enabled = true;
                                //radioButton2.Enabled = false;
                                //radioButton3.Enabled = false;
                            }
                        }
                    }
                }
                //无送审记录
                else if (dd.Rows.Count == 0)
                {
                    radioButton1.Enabled = true;
                    radioButton2.Enabled = false;
                    radioButton3.Enabled = false;
                }
            }
            //无权送审
            else
            {
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                radioButton3.Enabled = false;
            }
        }
        string cn1 = "", cn2 = "";
        private void button1_Click( object sender, EventArgs e )
        {
            if ( radioButton1.Checked )
                cn1 = radioButton1.Text;
            else if ( radioButton2.Checked )
                cn1 = radioButton2.Text;
            else if ( radioButton3.Checked )
                cn1 = radioButton3.Text;
            cn2 = textBox1.Text;
            if ( cn1 == "" )
            {
                MessageBox.Show( "请选择送审状态" );
                formState = false;
            }
            else
            {
                if ( cn1 == radioButton3.Text )
                {
                    if ( tableNum == "R_341" )
                    {
                        if ( result == true && over == true )
                        {
                            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 );
                            if ( PassDataBetweenForm != null )
                            {
                                PassDataBetweenForm( this ,args );
                            }
                            this.Close( );
                        }
                        else
                            MessageBox.Show( "成本员不可为空且需要廖总审核" );
                    }
                    else if ( tableNum == "R_495" )
                    {
                        if ( result == true )
                        {
                            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 );
                            if ( PassDataBetweenForm != null )
                            {
                                PassDataBetweenForm( this ,args );
                            }
                            this.Close( );
                        }
                        else
                            MessageBox.Show( "此表需要廖总审核" );
                    }
                    else if ( tableNum == "R_339" )
                    {
                        if ( result == true && over == true )
                        {
                            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 );
                            if ( PassDataBetweenForm != null )
                            {
                                PassDataBetweenForm( this ,args );
                            }
                            this.Close( );
                        }
                        else
                            MessageBox.Show( "成本员不可为空且必须廖总审核" );
                    }
                    else if ( tableNum == "R_195" || tableNum == "R_196" )
                    {
                        if ( over == true )
                        {
                            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 );
                            if ( PassDataBetweenForm != null )
                            {
                                PassDataBetweenForm( this ,args );
                            }
                            this.Close( );
                        }
                        else
                            MessageBox.Show( "成本员不可为空" );
                    }
                    else
                    {
                        if ( string.IsNullOrEmpty( num ) && ( tableNum == "R_338" || tableNum == "R_341" || tableNum == "R_342" || tableNum == "R_343" || tableNum == "R_347" || tableNum == "R_349" ) )
                        {
                            if ( result == true && over == true )
                            {
                                PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 );
                                if ( PassDataBetweenForm != null )
                                {
                                    PassDataBetweenForm( this ,args );
                                }
                                this.Close( );
                            }
                            else
                                MessageBox.Show( "成本员不可为空且计划订单需要廖总审核" );
                        }
                        else if ( !string.IsNullOrEmpty( num ) && ( tableNum == "R_338" || tableNum == "R_339" || tableNum == "R_341" || tableNum == "R_342" || tableNum == "R_343" || tableNum == "R_347" || tableNum == "R_349" || tableNum == "R_195" || tableNum == "R_196" ) )
                        {
                            if ( over == true )
                            {
                                PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 );
                                if ( PassDataBetweenForm != null )
                                {
                                    PassDataBetweenForm( this ,args );
                                }
                                this.Close( );
                            }
                            else
                                MessageBox.Show( "成本员不可为空" );
                        }
                        else
                        {
                            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 );
                            if ( PassDataBetweenForm != null )
                            {
                                PassDataBetweenForm( this ,args );
                            }
                            this.Close( );
                        }
                    }
                }
                else
                {
                    PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 );
                    if ( PassDataBetweenForm != null )
                    {
                        PassDataBetweenForm( this ,args );
                    }
                    this.Close( );
                }
                formState = true;
            }
        }
        private void button2_Click( object sender, EventArgs e )
        {
            formState = false;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            cn1 = cn2 = "";
            this.Close( );
        }
    }
}

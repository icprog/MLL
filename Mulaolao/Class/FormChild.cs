using System;
using System.Data;
using System.Windows.Forms;
using StudentMgr;
using System.Data.SqlClient;
using Mulaolao.Other;
using MulaolaoBll;

namespace Mulaolao.Class
{
    public partial class FormChild : Form
    {
        public FormChild( )
        {
            InitializeComponent( );
            //if (this.DesignMode == true)
            //{
            //}
            toolSelect.Enabled = toolAdd.Enabled = true;
            toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled =toolStorage.Enabled=toolLibrary.Enabled= false;
        }
        
        //按钮权限
        protected void Power(Form fm )
        {
            string num = Logins.number, cx02 = fm.Text;

            DataTable power = SqlHelper.ExecuteDataTable( "SELECT B.CX02,DBB001,DBB003,DBB004,DBB005,DBB006,DBB007,DBB008,DBB009,DBB010,DBB012,DBB013,DBB014,DBB015,DBB016,DBB017 FROM R_DBB A,R_MLLCXMC B WHERE A.DBB002=B.CX01 AND CX02=@CX02 AND DBB001=(SELECT DBA001 FROM TPADBA WHERE DBA001=@DBA001)" , new SqlParameter( "@DBA001", num ), new SqlParameter( "@CX02", cx02 ) );
            if (power != null && power.Rows.Count > 0)
            {
                if (power.Rows[0]["DBB004"].ToString( ) == "T")
                {
                    this.toolAdd.Visible = true;
                }
                else
                {
                    this.toolAdd.Visible = false;
                }
                if (power.Rows[0]["DBB005"].ToString( ) == "T")
                {
                    this.toolSelect.Visible = true;
                }
                else
                {
                    this.toolSelect.Visible = false;
                }
                if (power.Rows[0]["DBB006"].ToString( ) == "T")
                {
                    this.toolUpdate.Visible = true;
                }
                else
                {
                    this.toolUpdate.Visible = false;
                }
                if (power.Rows[0]["DBB007"].ToString( ) == "T")
                {
                    this.toolDelete.Visible = true;
                }
                else
                {
                    this.toolDelete.Visible = false;
                }
                if (power.Rows[0]["DBB008"].ToString( ) == "T")
                {
                    this.toolPrint.Visible = true;
                }
                else
                {
                    this.toolPrint.Visible = false;
                }
                if (power.Rows[0]["DBB009"].ToString( ) == "T")
                {
                    this.toolReview.Visible = true;
                }
                else
                {
                    this.toolReview.Visible = false;
                }
                if (power.Rows[0]["DBB010"].ToString( ) == "T")
                {
                    this.toolExport.Visible = true;
                }
                else
                {
                    this.toolExport.Visible = false;
                }
                if (power.Rows[0]["DBB012"].ToString( ) == "T")
                {
                    this.toolMaintain.Visible = true;
                }
                else
                {
                    this.toolMaintain.Visible = false;
                }
                if ( power.Rows[0]["DBB013"].ToString( ) == "T" )
                {
                    this.toolLibrary.Visible = true;
                }
                else
                {
                    this.toolLibrary.Visible = false;
                }
                if ( power.Rows[0]["DBB014"].ToString( ) == "T" )
                {
                    this.toolStorage.Visible = true;
                }
                else
                {
                    this.toolStorage.Visible = false;
                }
                if ( power.Rows[0]["DBB015"].ToString( ) == "T" )
                {
                    this.toolSave.Visible = true;
                }
                else
                {
                    this.toolSave.Visible = false;
                }
                if ( power.Rows[0]["DBB016"].ToString( ) == "T" )
                {
                    this.toolCancel.Visible = true;
                }
                else
                {
                    this.toolCancel.Visible = false;
                }
                if ( power.Rows[0]["DBB017"].ToString( ) == "T" )
                {
                    this.toolcopy.Visible = true;
                }
                else
                {
                    this.toolcopy.Visible = false;
                }
            }
        }
        
        protected virtual void save( )
        {

        }
        protected virtual void select( )
        {
            
        }
        protected virtual void add( )
        {
        }
        protected virtual void delete( )
        {
           
        }
        protected virtual void update()
        {
        }
        protected virtual void revirw( )
        {       
        }
        protected virtual void print( )
        {
        }
        protected virtual void cancel( )
        {
        }
        protected virtual void export( )
        {
        }
        protected virtual void maintain( )
        {
            
        }
        protected virtual void library ( )
        {

        }
        protected virtual void storage ( )
        {
        }
        protected virtual void copys ( )
        {
        }
        //送审
        Reviews res = new Reviews( );
        string state = "", views = "";
        /// <summary>
        /// 送审
        /// </summary>
        /// <param name="FieldName">单号或唯一字段</param>
        /// <param name="FieldValue">单号或唯一字段的值</param>
        /// <param name="TableName">表名</param>
        /// <param name="fm">窗体</param>
        protected void Reviews(string FieldName,string FieldValue,string TableName,Form fm ,string num,string tableNum,bool result,bool over ,DateTime? dt)
        {
            DataTable revi = SqlHelper.ExecuteDataTable( "SELECT * FROM "+TableName+" WHERE "+FieldName+"=@"+FieldName+"", new SqlParameter( "@"+FieldName+"", FieldValue ) );
            if (revi.Rows.Count < 1)
                MessageBox.Show( "没有关于单号:" + FieldValue + "的任何信息,无法送审,请核实后再操作" );
            else
            {
                res.Text = fm.Text;
                res.sta = FieldValue;
                res.CX02 = fm.Text;
                //res.variableOne = variableOne;
                //res.variableTwo = variableTwo;
                //res.tableName = tableName;
                //res.variableThr = variableThr;
                res.result = result;
                res.over = over;
                res.num = num;
                res.tableNum = tableNum;
                res.StartPosition = FormStartPosition.CenterScreen;
                res.PassDataBetweenForm += new Reviews.PassDataBetweenFormHandler( res_PassDataBetweenForm );
                res.ShowDialog( );
                
                string RES02 = "";
                if ( res.formState == true )
                {
                    if ( state != "" )
                    {
                        int count = ReviewES . Revie ( this ,Logins . number ,RES02 ,state ,FieldValue ,views ,dt );
                        if ( count < 1 )
                            MessageBox.Show( "送审失败" );
                        else
                            MessageBox.Show( "成功送审" );
                    }
                }
            }
        }
        private void res_PassDataBetweenForm( object sender, PassDataWinFormEventArgs e )
        {
            state = e.ConOne;
            views = e.ConTwo;
        }
        private void toolSave_Click( object sender, EventArgs e )
        {
            UserInfoMation . TypeOfOper = "保存";
            save( );               
        }
        private void toolSelect_Click( object sender, EventArgs e )
        {
            UserInfoMation . TypeOfOper = "查询";

            select ( );

            //toolSelect.Enabled = true;
            //toolAdd.Enabled = true;
            //toolDelete.Enabled = true;
            //toolUpdate.Enabled = true;
            //toolReview.Enabled = true;
            //toolPrint.Enabled = true;
            //toolExport.Enabled = true;
            //toolMaintain.Enabled = true;
            //toolSave.Enabled = false;
            //toolCancel.Enabled = false;
        }
        private void toolAdd_Click( object sender, EventArgs e )
        {
            UserInfoMation . TypeOfOper = "新增";
            add ( );

            
        }
        private void toolDelete_Click( object sender, EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此单?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                return;
            UserInfoMation . TypeOfOper = "删除";
            delete ( );
        }
        private void toolUpdate_Click( object sender, EventArgs e )
        {
            UserInfoMation . TypeOfOper = "编辑";
            update ( );
        }      
        private void toolReview_Click( object sender, EventArgs e )
        {
            UserInfoMation . TypeOfOper = "送审";
            revirw ( );     
        }     
        private void toolPrint_Click( object sender, EventArgs e )
        {
            UserInfoMation . TypeOfOper = "打印";
            print ( );
        }
        private void toolCancel_Click( object sender, EventArgs e )
        {
            UserInfoMation . TypeOfOper = "取消";
            cancel ( );          
        }
        private void toolExport_Click( object sender, EventArgs e )
        {
            UserInfoMation . TypeOfOper = "导出";
            export ( );
        }
        private void toolMaintain_Click( object sender, EventArgs e )
        {
            UserInfoMation . TypeOfOper = "维护";
            maintain ( );
        }
        private void toolLibrary_Click ( object sender ,EventArgs e )
        {
            UserInfoMation . TypeOfOper = "出库";
            library ( );
        }
        private void toolStorage_Click ( object sender ,EventArgs e )
        {
            UserInfoMation . TypeOfOper = "入库";
            storage ( );
        }
        private void toolcopy_Click ( object sender ,EventArgs e )
        {
            UserInfoMation . TypeOfOper = "复制";
            copys ( );
        }

        private void FormChild_Load( object sender, EventArgs e )
        {
            //Power( this );
        }
    }
}

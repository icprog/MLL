using Mulaolao . Class;
using System;
using System . Windows . Forms;

namespace Mulaolao . Contract
{
    public partial class R_Frmpenselect : Form
    {
        public R_Frmpenselect ()
        {
            InitializeComponent( );
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        //添加一个委托
        public delegate void PassDataBetweenFomrHandler ( object sender ,PassDataWinFormEventArgs e );
        //添加一个PassDataBetweenFormHandler类型的事件
        public event PassDataBetweenFomrHandler PassDataBetweenForm;
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "", cn8 = "", cn9 = "";
        public string str = "";
        private void R_Frmpenselect_Load( object sender, EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
            gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;

            if (str == "1")
            {
                this.gridView1.Columns["PQF01"].Visible = true;
                this.gridView1.Columns["PQF02"].Visible = true;
                this.gridView1.Columns["PQF03"].Visible = true;
                this.gridView1.Columns["PQF04"].Visible = true;
                this.gridView1.Columns["PQF06"].Visible = true;
                this.gridView1.Columns["PQF31"].Visible = true;
                this.gridView1.Columns["PY06"].Visible = false;
                this.gridView1.Columns["PY33"].Visible = false;
                this.gridView1.Columns["PY27"].Visible = false;
                this.gridView1.Columns["RES05"].Visible = false;
                this.gridView1.Columns["YQ06"].Visible = false;
                this.gridView1.Columns["YQ12"].Visible = false;
                this.gridView1.Columns["YQ107"].Visible = false;
                this.gridView1.Columns["YQ03"].Visible = false;
                this.gridView1.Columns["DBA002"].Visible = false;
            }
            else if (str == "3")
            {
                this.gridView1.Columns["YQ06"].Visible = true;
                this.gridView1.Columns["YQ12"].Visible = true;
                this.gridView1.Columns["YQ107"].Visible = true;
                this.gridView1.Columns["YQ03"].Visible = true;
                this.gridView1.Columns["PQF02"].Visible = false;
                this.gridView1.Columns["PQF03"].Visible = false;
                this.gridView1.Columns["PQF04"].Visible = false;
                this.gridView1.Columns["PQF06"].Visible = false;
                this.gridView1.Columns["PY06"].Visible = false;
                this.gridView1.Columns["PY33"].Visible = false;
                this.gridView1.Columns["PY27"].Visible = false;
                this.gridView1.Columns["PQF31"].Visible = false;
                this.gridView1.Columns["RES05"].Visible = false;
                this.gridView1.Columns["DBA002"].Visible = false;
            }
            else if (str == "4")
            {
                this.gridView1.Columns["PQF01"].Visible = true;
                this.gridView1.Columns["PQF03"].Visible = true;
                this.gridView1.Columns["PQF04"].Visible = true;
                this.gridView1.Columns["PY33"].Visible = true;
                this.gridView1.Columns["PQF02"].Visible = false;
                this.gridView1.Columns["PQF06"].Visible = false;
                this.gridView1.Columns["PY27"].Visible = false;
                this.gridView1.Columns["PY06"].Visible = false;
                this.gridView1.Columns["YQ06"].Visible = false;
                this.gridView1.Columns["YQ12"].Visible = false;
                this.gridView1.Columns["YQ107"].Visible = false;
                this.gridView1.Columns["YQ03"].Visible = false;
                this.gridView1.Columns["PQF31"].Visible = false;
                this.gridView1.Columns["RES05"].Visible = false;
                this.gridView1.Columns["DBA002"].Visible = false;
            }
            else if (str == "5")
            {
                this.gridView1.Columns["PQF01"].Visible = true;
                this.gridView1.Columns["PQF03"].Visible = true;
                this.gridView1.Columns["PQF04"].Visible = true;
                this.gridView1.Columns["PQF06"].Visible = true;
                this.gridView1.Columns["PQF31"].Visible = true;
                this.gridView1.Columns["DBA002"].Visible = true;
                this.gridView1.Columns["PQF02"].Visible = false;
                this.gridView1.Columns["YQ06"].Visible = false;
                this.gridView1.Columns["YQ12"].Visible = false;
                this.gridView1.Columns["YQ107"].Visible = false;
                this.gridView1.Columns["YQ03"].Visible = false;
                this.gridView1.Columns["PY06"].Visible = false;
                this.gridView1.Columns["PY33"].Visible = false;
                this.gridView1.Columns["PY27"].Visible = false;
                this.gridView1.Columns["RES05"].Visible = false;
            }
            else if (str == "6")
            {
                this.gridView1.Columns["PQF01"].Visible = true;
                this.gridView1.Columns["PQF02"].Visible = true;
                this.gridView1.Columns["PQF03"].Visible = true;
                this.gridView1.Columns["PQF04"].Visible = true;
                this.gridView1.Columns["PQF06"].Visible = true;
                this.gridView1.Columns["RES05"].Visible = true;
                this.gridView1.Columns["PQF31"].Visible = false;
                this.gridView1.Columns["YQ06"].Visible = false;
                this.gridView1.Columns["YQ12"].Visible = false;
                this.gridView1.Columns["YQ107"].Visible = false;
                this.gridView1.Columns["YQ03"].Visible = false;
                this.gridView1.Columns["PY06"].Visible = false;
                this.gridView1.Columns["PY33"].Visible = false;
                this.gridView1.Columns["PY27"].Visible = false;
                this.gridView1.Columns["DBA002"].Visible = false;
            }
            else if (str == "7")
            {
                this.gridView1.Columns["PQF01"].Visible = true;
                this.gridView1.Columns["PQF03"].Visible = true;
                this.gridView1.Columns["PQF04"].Visible = true;
                this.gridView1.Columns["PQF02"].Visible = false;
                this.gridView1.Columns["PQF06"].Visible = false;
                this.gridView1.Columns["PQF31"].Visible = false;
                this.gridView1.Columns["YQ06"].Visible = false;
                this.gridView1.Columns["YQ12"].Visible = false;
                this.gridView1.Columns["YQ107"].Visible = false;
                this.gridView1.Columns["YQ03"].Visible = false;
                this.gridView1.Columns["PY06"].Visible = false;
                this.gridView1.Columns["PY33"].Visible = false;
                this.gridView1.Columns["PY27"].Visible = false;
                this.gridView1.Columns["RES05"].Visible = false;
                this.gridView1.Columns["DBA002"].Visible = false;
            }
            else if ( str == "8" )
            {
                this.gridView1.Columns["PQF01"].Visible = false;
                this.gridView1.Columns["PQF02"].Visible = false;
                this.gridView1.Columns["PQF03"].Visible = true;
                this.gridView1.Columns["PQF04"].Visible = true;
                this.gridView1.Columns["PQF06"].Visible = true;
                this.gridView1.Columns["PQF31"].Visible = false;
                this.gridView1.Columns["PY06"].Visible = false;
                this.gridView1.Columns["PY33"].Visible = false;
                this.gridView1.Columns["PY27"].Visible = false;
                this.gridView1.Columns["RES05"].Visible = false;
                this.gridView1.Columns["YQ06"].Visible = false;
                this.gridView1.Columns["YQ12"].Visible = false;
                this.gridView1.Columns["YQ107"].Visible = false;
                this.gridView1.Columns["YQ03"].Visible = false;
                this.gridView1.Columns["DBA002"].Visible = false;
            }
        }
        //双击
        private void gridView1_DoubleClick( object sender, EventArgs e )
        {
            if (str == "1")
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF01" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF02" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF03" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF04" ).ToString( );
                cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF06" ).ToString( );
                cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF31" ).ToString( );
            }
            else if (str == "3")
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "YQ12" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle,"YQ107" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle,"YQ03" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "YQ06" ).ToString( );
            }
            else if (str == "4")
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF01" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF03" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF04" ).ToString( );
                cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PY33" ).ToString( );
            }
            else if (str == "5")
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF01" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"DBA002" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF03" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF04" ).ToString( );
                cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF06" ).ToString( );
                cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF31" ).ToString( );
            }
            else if (str == "6")
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF01" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF02" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF03" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF04" ).ToString( );
                cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF06" ).ToString( );
                cn6 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle ,"RES05").ToString( );
            }
            else if (str == "7")
            {
                cn1= gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF01" ).ToString( );
                cn2= gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF03" ).ToString( );
                cn3= gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF04" ).ToString( );
            }
            else if ( str == "8" )
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF03" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF04" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF06" ).ToString( );
            }
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 ,cn8 ,cn9 );
            if (PassDataBetweenForm != null)
            {
                PassDataBetweenForm( this, args );
            }

            this.Close( );
        }
        //单击键盘上面的任何键   确认是否需要合并
        int sum = 0;
        long count = 0;
        private void gridView1_KeyDown ( object sender ,KeyEventArgs e )
        {
            if ( Logins.number != "MLL-0001" )
                return;
            if ( e.KeyCode == Keys.Enter )
            {
                for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                {
                    if ( gridView1.GetDataRow( i )["check"].ToString( ) == "True" )
                        sum++;
                }
                cn1 = cn2 = cn3 = cn4 = cn5 = cn6 = "";
                count = 0;
                if ( str == "6" )
                    megerSix( );
                else if ( str == "5" )
                    megerFiv( );
                else if ( str == "1" )
                    megerOne( );
            }
        }
        //单击选中或者取消
        private void gridView1_Click ( object sender ,EventArgs e )
        {
            if ( Logins.number == "MLL-0001" )
            {
                if ( gridView1.FocusedRowHandle >= 0 )
                {
                    if ( str == "6" || str == "5" || str == "1" )
                    {
                        int num = gridView1.FocusedRowHandle;
                        if ( gridView1.GetDataRow( num )["check"].ToString( ) == "True" )
                            gridView1.GetDataRow( num )["check"] = false;
                        else
                            gridView1.GetDataRow( num )["check"] = true;
                    }
                }
            }
        }
        void megerSix ( )
        {
            if ( sum >= 2 )
            {
                if ( MessageBox.Show( "确定合并？" ,"数据合并" ,MessageBoxButtons.OKCancel ) == DialogResult.OK )
                {
                    for ( int j = 0 ; j < gridView1.RowCount ; j++ )
                    {
                        if ( gridView1.GetDataRow( j )["check"].ToString( ) == "True" )
                        {
                            if ( cn1 == "" )
                                cn1 = gridView1.GetRowCellValue( j ,"PQF01" ).ToString( );
                            else
                                cn1 = cn1 + "," + gridView1.GetRowCellValue( j ,"PQF01" ).ToString( );
                            if ( cn2 == "" )
                                cn2 = gridView1.GetRowCellValue( j ,"PQF02" ).ToString( );
                            else
                                cn2 = cn2 + "," + gridView1.GetRowCellValue( j ,"PQF02" ).ToString( );
                            if ( cn3 == "" )
                                cn3 = gridView1.GetRowCellValue( j ,"PQF03" ).ToString( );
                            else
                                cn3 = cn3 + "," + gridView1.GetRowCellValue( j ,"PQF03" ).ToString( );
                            if ( cn4 == "" )
                                cn4 = gridView1.GetRowCellValue( j ,"PQF04" ).ToString( );
                            else
                                cn4 = cn4 + "," + gridView1.GetRowCellValue( j ,"PQF04" ).ToString( );
                            count = count + Convert.ToInt64( gridView1.GetRowCellValue( j ,"PQF06" ).ToString( ) );
                        }
                    }
                    cn5 = count.ToString( );
                    PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 );
                    if ( PassDataBetweenForm != null )
                        PassDataBetweenForm( this ,args );
                    this.Close( );
                }
            }
            else
                MessageBox.Show( "请选择至少两行" );
        }
        void megerFiv ( )
        {
            if ( sum >= 2 )
            {
                if ( MessageBox.Show( "确定合并？" ,"数据合并" ,MessageBoxButtons.OKCancel ) == DialogResult.OK )
                {
                    for ( int j = 0 ; j < gridView1.RowCount ; j++ )
                    {
                        if ( gridView1.GetDataRow( j )["check"].ToString( ) == "True" )
                        {
                            if ( cn1 == "" )
                                cn1 = gridView1.GetRowCellValue( j ,"PQF01" ).ToString( );
                            else
                                cn1 = cn1 + "," + gridView1.GetRowCellValue( j ,"PQF01" ).ToString( );
                            if(cn2=="")
                                cn2 = gridView1.GetRowCellValue( j ,"DBA002" ).ToString( );
                            else
                                cn2 = cn2 + "," + gridView1.GetRowCellValue( j ,"DBA002" ).ToString( );
                            if ( cn3 == "" )
                                cn3 = gridView1.GetRowCellValue( j ,"PQF03" ).ToString( );
                            else
                                cn3 = cn3 + "," + gridView1.GetRowCellValue( j ,"PQF03" ).ToString( );
                            if ( cn4 == "" )
                                cn4 = gridView1.GetRowCellValue( j ,"PQF04" ).ToString( );
                            else
                                cn4 = cn4 + "," + gridView1.GetRowCellValue( j ,"PQF04" ).ToString( );
                            count = count + Convert.ToInt64( gridView1.GetRowCellValue( j ,"PQF06" ).ToString( ) );
                            if ( cn6 == "" )
                                cn6 = gridView1.GetRowCellValue( j ,"PQF31" ).ToString( );
                            else
                                cn6 = cn6 + "," + gridView1.GetRowCellValue( j ,"PQF31" ).ToString( );
                        }
                    }
                    cn5 = count.ToString( );
                    PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 );
                    if ( PassDataBetweenForm != null )
                        PassDataBetweenForm( this ,args );
                    this.Close( );
                }
            }
            else
                MessageBox.Show( "请选择至少两行" );
        }
        void megerOne ( )
        {
            if ( sum >= 2 )
            {
                if ( MessageBox.Show( "确定合并？" ,"数据合并" ,MessageBoxButtons.OKCancel ) == DialogResult.OK )
                {
                    for ( int j = 0 ; j < gridView1.RowCount ; j++ )
                    {
                        if ( gridView1.GetDataRow( j )["check"].ToString( ) == "True" )
                        {
                            if ( cn1 == "" )
                                cn1 = gridView1.GetRowCellValue( j ,"PQF01" ).ToString( );
                            else
                                cn1 = cn1 + "," + gridView1.GetRowCellValue( j ,"PQF01" ).ToString( );
                            if(cn2=="")
                                cn2= gridView1.GetRowCellValue( j ,"PQF02" ).ToString( );
                            else
                                cn2 = cn2 + "," + gridView1.GetRowCellValue( j ,"PQF02" ).ToString( );
                            if ( cn3 == "" )
                                cn3 = gridView1.GetRowCellValue( j ,"PQF03" ).ToString( );
                            else
                                cn3 = cn3 + "," + gridView1.GetRowCellValue( j ,"PQF03" ).ToString( );
                            if ( cn4 == "" )
                                cn4 = gridView1.GetRowCellValue( j ,"PQF04" ).ToString( );
                            else
                                cn4 = cn4 + "," + gridView1.GetRowCellValue( j ,"PQF04" ).ToString( );
                            count = count + Convert.ToInt64( gridView1.GetRowCellValue( j ,"PQF06" ).ToString( ) );
                            cn6 = gridView1.GetRowCellValue( j ,"PQF31" ).ToString( );
                        }
                    }
                    cn5 = count.ToString( );
                    PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 );
                    if ( PassDataBetweenForm != null )
                        PassDataBetweenForm( this ,args );
                    this.Close( );
                }
            }
            else
                MessageBox.Show( "请选择至少两行" );
        }

    }
}






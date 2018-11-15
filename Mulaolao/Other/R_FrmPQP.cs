using Mulaolao . Class;
using System;
using System . Windows . Forms;

namespace Mulaolao . Raw_material_cost
{
    public partial class R_FrmPQP : Form
    {
        public R_FrmPQP( )
        {
            InitializeComponent( );
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        //添加一个委托
        public delegate void PassDataBetweenFormHandler( object sender, PassDataWinFormEventArgs e );
        //添加一个PassDataBetweenFormHandler类型的事件
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        public string pqstr = "";
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "", cn8 = "", cn9 = "";
        private void R_FrmPQP_Load( object sender, EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
            gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            if ( pqstr == "1" )
            {
                this.gridView1.Columns["GS07"].Visible = false;
                this.gridView1.Columns["GS08"].Visible = false;
                this.gridView1.Columns["GS01"].Visible = true;
                this.gridView1.Columns["GS03"].Visible = true;
                this.gridView1.Columns["GS10"].Visible = false;
                this.gridView1.Columns["GS09"].Visible = false;
                this.gridView1.Columns["GS34"].Visible = true;
                this.gridView1.Columns["GS46"].Visible = true;
                this.gridView1.Columns["GS47"].Visible = true;
                this.gridView1.Columns["GS48"].Visible = true;
                this.gridView1.Columns["GS49"].Visible = true;
                this.gridView1.Columns["GS50"].Visible = true;
                this.gridView1.Columns["GS56"].Visible = false;
                this.gridView1.Columns["GS57"].Visible = false;
                this.gridView1.Columns["GS58"].Visible = false;
                this.gridView1.Columns["RES05"].Visible = true;
            }
            else if ( pqstr == "2" )
            {
                this.gridView1.Columns["GS07"].Visible = true;
                this.gridView1.Columns["GS08"].Visible = true;
                this.gridView1.Columns["GS01"].Visible = false;
                this.gridView1.Columns["GS03"].Visible = false;
                this.gridView1.Columns["GS10"].Visible = true;
                this.gridView1.Columns["GS09"].Visible = false;
                this.gridView1.Columns["GS34"].Visible = false;
                this.gridView1.Columns["GS46"].Visible = false;
                this.gridView1.Columns["GS47"].Visible = false;
                this.gridView1.Columns["GS48"].Visible = false;
                this.gridView1.Columns["GS49"].Visible = false;
                this.gridView1.Columns["GS50"].Visible = false;
                this.gridView1.Columns["GS56"].Visible = false;
                this.gridView1.Columns["GS57"].Visible = false;
                this.gridView1.Columns["GS58"].Visible = false;
                this.gridView1.Columns["RES05"].Visible = false;
            }
            else if ( pqstr == "3" )
            {
                this.gridView1.Columns["GS07"].Visible = true;
                this.gridView1.Columns["GS08"].Visible = true;
                this.gridView1.Columns["GS01"].Visible = false;
                this.gridView1.Columns["GS03"].Visible = false;
                this.gridView1.Columns["GS10"].Visible = true;
                this.gridView1.Columns["GS09"].Visible = true;
                this.gridView1.Columns["GS34"].Visible = false;
                this.gridView1.Columns["GS46"].Visible = false;
                this.gridView1.Columns["GS47"].Visible = false;
                this.gridView1.Columns["GS48"].Visible = false;
                this.gridView1.Columns["GS49"].Visible = false;
                this.gridView1.Columns["GS50"].Visible = false;
                this.gridView1.Columns["GS56"].Visible = false;
                this.gridView1.Columns["GS57"].Visible = false;
                this.gridView1.Columns["GS58"].Visible = false;
                this.gridView1.Columns["RES05"].Visible = false;
            }
            else if ( pqstr == "4" )
            {
                this.gridView1.Columns["GS07"].Visible = true;
                this.gridView1.Columns["GS08"].Visible = true;
                this.gridView1.Columns["GS01"].Visible = false;
                this.gridView1.Columns["GS03"].Visible = false;
                this.gridView1.Columns["GS10"].Visible = true;
                this.gridView1.Columns["GS09"].Visible = true;
                this.gridView1.Columns["GS34"].Visible = false;
                this.gridView1.Columns["GS46"].Visible = false;
                this.gridView1.Columns["GS47"].Visible = false;
                this.gridView1.Columns["GS48"].Visible = false;
                this.gridView1.Columns["GS49"].Visible = false;
                this.gridView1.Columns["GS50"].Visible = false;
                this.gridView1.Columns["GS56"].Visible = false;
                this.gridView1.Columns["GS57"].Visible = false;
                this.gridView1.Columns["GS58"].Visible = false;
                this.gridView1.Columns["RES05"].Visible = false;
            }
            else if ( pqstr == "5" )
            {
                this.gridView1.Columns["GS56"].Visible = true;
                this.gridView1.Columns["GS57"].Visible = true;
                this.gridView1.Columns["GS58"].Visible = true;
                this.gridView1.Columns["GS07"].Visible = false;
                this.gridView1.Columns["GS08"].Visible = false;
                this.gridView1.Columns["GS01"].Visible = false;
                this.gridView1.Columns["GS03"].Visible = false;
                this.gridView1.Columns["GS10"].Visible = false;
                this.gridView1.Columns["GS09"].Visible = false;
                this.gridView1.Columns["GS34"].Visible = false;
                this.gridView1.Columns["GS46"].Visible = false;
                this.gridView1.Columns["GS47"].Visible = false;
                this.gridView1.Columns["GS48"].Visible = false;
                this.gridView1.Columns["GS49"].Visible = false;
                this.gridView1.Columns["GS50"].Visible = false;
                this.gridView1.Columns["RES05"].Visible = false;
            }
        }
        //双击选中行   传值给主窗体
        private void gridView1_DoubleClick( object sender, EventArgs e )
        {
            if ( pqstr == "1" )
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"GS01" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"GS46" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"GS03" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"GS34" ).ToString( );
                cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"GS47" ).ToString( );
                cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"GS48" ).ToString( );
                cn7 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"GS49" ).ToString( );
                cn8 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"GS50" ).ToString( );
                cn9 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"RES05" ).ToString( );
            }
            else if ( pqstr == "2" )
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"GS07" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"GS08" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"GS10" ).ToString( );
            }
            else if ( pqstr == "3" )
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"GS07" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"GS08" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"GS10" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"GS09" ).ToString( );
            }
            else if ( pqstr == "4" )
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"GS07" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"GS08" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"GS10" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"GS09" ).ToString( );
            }
            else if ( pqstr == "5" )
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"GS56" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"GS57" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"GS58" ).ToString( );
            }
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 ,cn8 ,cn9 );
            if (PassDataBetweenForm != null)
            {
                PassDataBetweenForm( this, args );
            }
            this.Close( );
        }
        //按键盘任意键  确认是否合并
        private void gridView1_KeyDown ( object sender ,KeyEventArgs e )
        {
            if ( e.KeyCode == Keys.Enter )
            {
                if ( pqstr == "3" )
                {
                    for ( int l = 0 ; l < gridView1.RowCount ; l++ )
                    {
                        if ( gridView1.GetDataRow( l )["check"].ToString( ) == "True" )
                            count++;
                    }
                    if ( count > 1 )
                    {
                        cn1 = cn2 = cn3 = cn4 = "";
                        if ( MessageBox.Show( "确认合并？" ,"合并" ,MessageBoxButtons.OKCancel) == DialogResult.OK )
                        {
                            long all = 0;
                            for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                            {
                                if ( gridView1.GetDataRow(i)["check"].ToString( ) == "True" )
                                {
                                    cn1 = "整套";
                                    cn2 = "";
                                    all = all + Convert.ToInt64(gridView1.GetRowCellValue(i ,"GS10"));
                                    cn4 = "套";
                                }
                            }
                            cn3 = all.ToString( );
                            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs(cn1 ,cn2 ,cn3 ,cn4);
                            if ( PassDataBetweenForm != null )
                            {
                                PassDataBetweenForm(this ,args);
                            }

                            this.Close( );
                        }
                    }
                    else
                        MessageBox.Show("请至少选择两项合并");
                }
            }
            else
                MessageBox.Show("请按Enter键确认是否合并");
        }
        //单击选中需要合并的项
        int count = 0;
        private void gridView1_Click ( object sender ,EventArgs e )
        {
            if ( gridView1.FocusedRowHandle >= 0 )
            {
                if ( pqstr == "3" )
                {
                    int num = gridView1.FocusedRowHandle;
                    if ( gridView1.GetDataRow( num )["check"].ToString( ) == "True" )
                    {
                        gridView1.GetDataRow( num )["check"] = false;
                    }
                    else
                    {
                        gridView1.GetDataRow( num )["check"] = true;
                    }
                }
            }
           
        }
    }
}

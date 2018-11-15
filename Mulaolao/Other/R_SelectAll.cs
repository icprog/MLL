using DevExpress . XtraEditors;
using DevExpress . XtraEditors . Repository;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;
using Mulaolao . Class;

namespace Mulaolao . Other
{
    public partial class R_SelectAll : Form
    {
        public R_SelectAll( )
        {
            InitializeComponent( );
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        public string sailes = "";

        RepositoryItemComboBox riCombo = new RepositoryItemComboBox( );
        RepositoryItemComboBox riCombos = new RepositoryItemComboBox( );
        RepositoryItemComboBox riComboes = new RepositoryItemComboBox( );

        
        private void R_SelectAll_Load( object sender, EventArgs e )
        {
            DataTable da = new DataTable( );
            DataColumn dc = null;
            DataRow dr;

            //设置列可选不可操作
            riCombo.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            riCombos.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            riComboes.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            dc = da.Columns.Add( "Names" ,Type.GetType( "System.String" ) );
            dc = da.Columns.Add( "Options", Type.GetType( "System.String" ) );
            dc = da.Columns.Add( "Starts", Type.GetType( "System.String" ) );
            dc = da.Columns.Add( "Ends", Type.GetType( "System.String" ) );
            dc = da.Columns.Add( "Relations", Type.GetType( "System.String" ) );

            gridControl1.RepositoryItems.Add( riCombo );
            gridControl1.RepositoryItems.Add( riCombos );
            gridControl1.RepositoryItems.Add( riComboes );
            gridView1.Columns["Names"].ColumnEdit = riCombo;
            gridView1.Columns["Options"].ColumnEdit = riCombos;
            gridView1.Columns["Relations"].ColumnEdit = riComboes;

            riCombo.Items.Clear( );
            comboBox3.Items.Clear( );
            comboBox4.Items.Clear( );
            riCombos.Items.Clear( );
            riComboes.Items.Clear( );
            
            riCombos.Items.AddRange( new string[] { "等于", "大于等于", "小于等于", "大于", "小于", "不等于", "相似于", "在之间" } );
            riComboes.Items.AddRange( new string[] { "且", "或" } );
            
            if (sailes == "1")
            {
                for (int x = 0; x < 4; x++)
                {
                    dr = da.NewRow( );
                    dr["Names"] = "";
                    dr["Options"] = "";
                    dr["Starts"] = "";
                    dr["Ends"] = "";
                    dr["Relations"] = "";
                    da.Rows.Add( dr );
                }
                
                riCombo.Items.AddRange( new string[] { "产品名称", "货号", "流水号", "合同号" } );
                comboBox3.Items.Add( "产品名称" );
                comboBox3.Items.Add( "货号" );
                comboBox3.Items.Add( "流水号" );
                comboBox3.Items.Add( "合同号" );
                comboBox4.Items.Add( "产品名称" );
                comboBox4.Items.Add( "货号" );
                comboBox4.Items.Add( "流水号" );
                comboBox4.Items.Add( "合同号" );
            }
            gridControl1.DataSource = da;
        }

        //获取值
        string select = "", sele = "";
        Dictionary<int, string> colum = new Dictionary<int, string>( );
        Dictionary<int, string> caption = new Dictionary<int, string>( );
        Dictionary<int, string> or = new Dictionary<int, string>( );
        Dictionary<int, string> valuOne = new Dictionary<int, string>( );
        Dictionary<int, string> valuTwo = new Dictionary<int, string>( );
        //名称
        private void riCombo_SelectedValueChanged( object sender, EventArgs e )
        {
            BaseEdit logicEdit = gridView1.ActiveEditor;
            select = Convert.ToString( logicEdit.EditValue );
            if (colum.ContainsKey( gridView1.FocusedRowHandle ))
            {
                if (colum.ContainsValue( select ) == false && select != "")
                    colum[gridView1.FocusedRowHandle] = select;       
            }
            else
            {
                if (colum.ContainsValue( select ) == false && select != "")
                    colum.Add( gridView1.FocusedRowHandle, select );
            }
        }
        //操作
        private void riCombos_SelectedValueChanged( object sender, EventArgs e )
        {
            BaseEdit logicEdit = gridView1.ActiveEditor;
            select = Convert.ToString( logicEdit.EditValue );
            if (caption.ContainsKey( gridView1.FocusedRowHandle ))
            {
                if (caption.ContainsValue( select )==false && select != "")
                    caption[gridView1.FocusedRowHandle] = select;
            }
            else
            {
                if (caption.ContainsValue( select ) == false && select != "")
                    caption.Add( gridView1.FocusedRowHandle, select );
            }
        }
        //关系
        private void riComboes_SelectedValueChanged( object sender, EventArgs e )
        {
            BaseEdit logicEdit = gridView1.ActiveEditor;
            select = Convert.ToString( logicEdit.EditValue );
            if (or.ContainsKey( gridView1.FocusedRowHandle ))
            {
                if (or.ContainsValue( select ) == false && select != "")
                    or[gridView1.FocusedRowHandle] = select;
            }
            else
            {
                if (or.ContainsValue( select ) == false && select != "")
                    or.Add( gridView1.FocusedRowHandle, select );
            }
        }
        //起始值   截至值
        private void gridView1_FocusedRowChanged( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
            if (gridView1.RowCount > 0)
            {
                select = gridView1.GetRowCellValue( e.FocusedRowHandle, "Starts" ).ToString( );
                if (valuOne.ContainsKey( e.FocusedRowHandle ))
                {
                    if (valuOne.ContainsValue( select ) == false && select!="")
                        colum[e.FocusedRowHandle] = select;
                }
                else
                {
                    if (valuOne.ContainsValue( select ) == false && select != "")
                        valuOne.Add( e.FocusedRowHandle, select );
                }
                sele = gridView1.GetRowCellValue( e.FocusedRowHandle, "Ends" ).ToString( );
                if (valuTwo.ContainsKey( e.FocusedRowHandle ))
                {
                    if (valuTwo.ContainsValue( sele ) == false && select != "")
                        colum[e.FocusedRowHandle] = sele;
                }
                else
                {
                    if (valuTwo.ContainsValue( sele ) == false && select != "")
                        valuTwo.Add( e.FocusedRowHandle, sele );
                }
            }
        }
        private void gridView1_Click( object sender, EventArgs e )
        {
            if (gridView1.RowCount == 1)
            {
                select = gridView1.GetFocusedRowCellValue( "Starts" ).ToString( );
                if (valuOne.ContainsKey( gridView1.FocusedRowHandle ))
                {
                    if (valuOne.ContainsValue( select ) == false && select != "")
                        colum[gridView1.FocusedRowHandle] = select;
                }
                else
                {
                    if (valuOne.ContainsValue( select ) == false && select != "")
                        valuOne.Add( gridView1.FocusedRowHandle, select );
                }
                sele = gridView1.GetFocusedRowCellValue( "Ends" ).ToString( );
                if (valuTwo.ContainsKey( gridView1.FocusedRowHandle ))
                {
                    if (valuTwo.ContainsValue( sele ) == false && select != "")
                        colum[gridView1.FocusedRowHandle] = sele;
                }
                else
                {
                    if (valuTwo.ContainsValue( sele ) == false && select != "")
                        valuTwo.Add( gridView1.FocusedRowHandle, sele );
                }
            }
        }
        //取消
        private void button5_Click( object sender, EventArgs e )
        {
            this.Close( );
        }
        //确定
        public DataTable da = new DataTable( );
        string where = "AND 1=1";
        //where 作为每一个条件加入 where="1=1"
        private void button4_Click( object sender, EventArgs e )
        {
            //if ( sailes == "1" )
            //{
            //    da = SqlHelper.ExecuteDataTable( "SELECT PQF01,PQF56,PQF58,PQF60,PQF61,PQF51,(SELECT DBA002 FROM TPADBA WHERE DBA001=PQF55) AS DBA02,( SELECT DBA002 FROM TPADBA WHERE DBA001 = PQF57 ) AS DBA2, (SELECT DAA002 FROM TPADAA WHERE DAA001 = PQF59 ) AS DAA02,PQF01, PQF02, PQF03, PQF04, PQF05, PQF06, PQF07, PQF08, PQF09, PQF10, DFA003,(SELECT DBA002 FROM TPADBA WHERE DBA001 = PQF12) AS DBA002,PQF13, PQF20, PQF21, PQF17,(SELECT DAA002 FROM TPADAA WHERE DAA001 = PQF17) DAA002, PQF23, PQF24, PQF63, PQF31, PQF32, PQF34, PQF41, PQF47, PQF38, PQF44, PQF45, PQF49 FROM R_PQF B, TPADFA C WHERE B.PQF11 = C.DFA001 " + where + "" );
            //}
            //this.Close( );

            selectAll( );           
        }
        string x1 = "", x2 = "", x3 = "", x4 = "", x5 = "";
        void selectAll ( )
        {       
            for ( int i = 0 ; i < gridView1.RowCount ; i++ )
            {
                x1 = gridView1.GetDataRow( i )["Names"].ToString( );
                x2 = gridView1.GetDataRow( i )["Options"].ToString( );
                x3 = gridView1.GetDataRow( i )["Starts"].ToString( );
                x4 = gridView1.GetDataRow( i )["Ends"].ToString( );
                x5 = gridView1.GetDataRow( i )["Relations"].ToString( );               
            }           
        }
    }
}

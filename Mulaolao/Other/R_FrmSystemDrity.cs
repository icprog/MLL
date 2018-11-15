using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Other
{
    public partial class R_FrmSystemDrity : Form
    {
        public R_FrmSystemDrity ( )
        {
            InitializeComponent( );


            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        MulaolaoBll.Bll.SystemDrityBll _bll = new MulaolaoBll.Bll.SystemDrityBll( );
        string strWhere = "1=1";
        DataTable tabelQuery;
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( comboBox1.Text ) )
                strWhere = strWhere + " AND BF001='" + comboBox1.Text + "'";
            if ( !string.IsNullOrEmpty( comboBox2.Text ) )
                strWhere = strWhere + " AND BF005='" + comboBox2.Text + "'";
            tabelQuery = _bll.GetDataTable( strWhere );
            gridControl1.DataSource = tabelQuery;
        }

        private void R_FrmSystemDrity_Load ( object sender ,EventArgs e )
        {
            comboBox1.DataSource = _bll.GetDataTableOnly( );
            comboBox1.DisplayMember = "BF001";
            comboBox1.ValueMember = "BF002";
            comboBox1.Text = "";
            textBox1.Text = "";
        }

        private void comboBox1_TextChanged ( object sender ,EventArgs e )
        {
            if ( !string.IsNullOrEmpty( comboBox1.Text ) )
            {
                textBox1.Text = comboBox1.SelectedValue.ToString( );
                comboBox2.DataSource = _bll.GetDataTableOf( comboBox1.Text );
                comboBox2.DisplayMember = "BF005";
            }
        }
    }
}

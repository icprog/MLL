using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Wages
{
    public partial class ChanPinGongZiKaoQinReport : FormChild
    {
        public ChanPinGongZiKaoQinReport ( )
        {
            InitializeComponent( );

            GridViewMoHuSelect . SetFilter ( bandedGridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { bandedGridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }

        MulaolaoBll.Bll.ChanPinGongZiKaoQinReportBll bll = new MulaolaoBll.Bll.ChanPinGongZiKaoQinReportBll( );
        MulaolaoLibrary.ChanPinGongZiKaoQinLibrary model = new MulaolaoLibrary.ChanPinGongZiKaoQinLibrary( );
        DataTable tableQuery;
        string strWhere = "1=1";

        private void ChanPinGongZiKaoQinReport_Load ( object sender ,EventArgs e )
        {
            lookUpEdit2.Properties.DataSource = bll.GetDataTableGroupLeader( );
            lookUpEdit2.Properties.DisplayMember = "DBA002";
            lookUpEdit2.Properties.ValueMember = "DBA001";        
        }

        #region Event
        private void lookUpEdit2_EditValueChanged ( object sender ,EventArgs e )
        {
            if ( lookUpEdit2.EditValue != null )
            {
                lookUpEdit1.Properties.DataSource = bll.GetDataTablePerson( lookUpEdit2.Text );
                lookUpEdit1.Properties.DisplayMember = "DBA002";
                lookUpEdit1.Properties.ValueMember = "DBA001";
            }
        }
        private void lookUpEdit1_EditValueChanged ( object sender ,EventArgs e )
        {
            if ( lookUpEdit1.EditValue !=null )
            {
                searchLookUpEdit1.Properties.DataSource = bll.GetDataTableProduct( lookUpEdit1.EditValue.ToString( ) );
                searchLookUpEdit1.Properties.DisplayMember = "GZ01";
                searchLookUpEdit1.Properties.ValueMember = "GZ22";
            }
        }
        private void searchLookUpEdit1_EditValueChanged ( object sender ,EventArgs e )
        {
            if ( searchLookUpEdit1.EditValue != null )
                textBox2.Text = searchLookUpEdit1.EditValue.ToString( );
        }
        private void dateTimePicker1_ValueChanged ( object sender ,EventArgs e )
        {
            textBox1.Text = dateTimePicker1.Value.ToString( "MM月" );
        }
        private void textBox1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            if ( e.KeyChar == 8 )
                textBox1.Text = "";
            else
                e.Handled = true;
        }
        #endregion

        #region Table
        private void button1_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( lookUpEdit1.Text ) )
                MessageBox.Show( "生产人姓名不可为空" );
            else
            {
                strWhere = "1=1";
                strWhere = strWhere + " AND GZ02='" + lookUpEdit1.Text + "' AND GZ16='" + lookUpEdit2.Text + "'";
                if ( !string.IsNullOrEmpty( searchLookUpEdit1.Text ) )
                    strWhere = strWhere + " AND GZ01='" + searchLookUpEdit1.Text + "'";
                if ( !string.IsNullOrEmpty( textBox1.Text ) )
                    strWhere = strWhere + " AND GZ24='" + dateTimePicker1.Value.ToString( "MM" ) + "' AND GZ35='" + dateTimePicker1.Value.ToString( "yyyy" ) + "'";
                tableQuery = bll.GetDataTableReport( strWhere );
                gridControl1.DataSource = tableQuery; 
                assignMent ( );
            }
        }
        void assignMent ( )
        {
            if ( tableQuery != null && tableQuery . Rows . Count > 0 )
            {
                U9 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom , Convert . ToDecimal ( U0 . SummaryItem . SummaryValue ) == 0 ? 0 . ToString ( ) : Math . Round ( Convert . ToDecimal ( U3 . SummaryItem . SummaryValue ) / Convert . ToDecimal ( U0 . SummaryItem . SummaryValue ) , 0 ) . ToString ( ) );
            }
        }
        private void button2_Click ( object sender ,EventArgs e )
        {
            lookUpEdit2.EditValue = lookUpEdit1.EditValue = null;
            lookUpEdit2.ItemIndex = lookUpEdit1.ItemIndex = -1;
            textBox1.Text = textBox2.Text = "";
            searchLookUpEdit1.Text = "";
            gridControl1.DataSource = null;
        }
        #endregion
    }
}

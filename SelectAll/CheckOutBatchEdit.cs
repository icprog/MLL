using System;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class CheckOutBatchEdit :Form
    {
        public CheckOutBatchEdit ( )
        {
            InitializeComponent ( );
        }

        MulaolaoBll.Bll.CheckOutBll bll = new MulaolaoBll.Bll.CheckOutBll( );

        private void CheckOutBatchEdit_Load ( object sender , EventArgs e )
        {
            DataTable da = bll . GetDataTableOfG ( );
            comboBox1 . DataSource = da . Copy ( );
            comboBox1 . DisplayMember = "AK001";
            comboBox2 . DataSource = da . Copy ( );
            comboBox2 . DisplayMember = "AK001";
        }

        //sure
        private void button1_Click ( object sender , EventArgs e )
        {
            if ( string . IsNullOrEmpty ( comboBox1 . Text ) )
            {
                MessageBox . Show ( "请选择原供应商" );
                return;
            }
            if ( string . IsNullOrEmpty ( comboBox2 . Text ) )
            {
                MessageBox . Show ( "请选择或填写需要编辑的供应商" );
                return;
            }
            bool result = bll . UpdateOfG ( comboBox2 . Text , comboBox1 . Text );
            if ( result == true )
            {
                MessageBox . Show ( "编辑成功,请重查" );
                this . Close ( );
            }
            else
                MessageBox . Show ( "编辑失败,请重试" );
        }
        //cancel
        private void button2_Click ( object sender , EventArgs e )
        {
            this . Close ( );
        }


    }
}

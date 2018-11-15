using System;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class ZuZhangGongZiKaoHeOne : Form
    {
        public ZuZhangGongZiKaoHeOne ( )
        {
            InitializeComponent( );
        }

        MulaolaoBll.Bll.ZuZhangGongZiKaoHeBll bll = new MulaolaoBll.Bll.ZuZhangGongZiKaoHeBll( );
        public string oddNum = "", sign = "";
        DataTable tableQuery;
        bool result = false;
        
        private void ZuZhangGongZiKaoHeOne_Load ( object sender ,EventArgs e )
        {
            if ( sign == "1" )
                tabPageTwo.Parent = null;
            else
                tabPageOne.Parent = null;
            query( );
        }

        void query ( )
        {
            tableQuery = null;
            if ( sign == "1" )
            {
                tableQuery = bll.GetDataTableOfParameter( "R_501" );
                tableQuery.Rows[0]["AY001"] = "R_501";
                gridControl2.DataSource = tableQuery;
            }
            if ( sign == "2" )
            {
                tableQuery = bll.GetDataTableOfParameter( "R_502" );
                tableQuery.Rows[0]["AY001"] = "R_502";
                gridControl1.DataSource = tableQuery;
            }
        }

        private void button1_Click ( object sender ,EventArgs e )
        {
            if ( sign == "1" )
            {
                bandedGridView1 . CloseEditor ( );
                bandedGridView1.UpdateCurrentRow( );
                if ( tableQuery != null && tableQuery.Rows.Count > 0 )
                {
                    result = bll . AddOfParameter ( tableQuery ,sign );
                    if ( result == true )
                    {
                        MessageBox.Show( "成功保存数据" );
                        this.Close( );
                    }
                    else
                        MessageBox.Show( "保存数据失败" );
                }
            }
        }

        private void button3_Click ( object sender ,EventArgs e )
        {
            this.Close( );
        }

        private void button4_Click ( object sender ,EventArgs e )
        {
            if ( sign == "2" )
            {
                bandedGridView1.UpdateCurrentRow( );
                if ( tableQuery != null && tableQuery.Rows.Count > 0 )
                {
                    result = bll . AddOfParameter ( tableQuery ,sign );
                    if ( result == true )
                    {
                        MessageBox.Show( "成功保存数据" );
                        this.Close( );
                    }
                    else
                        MessageBox.Show( "保存数据失败" );
                }
            }
        }

        private void button2_Click ( object sender ,EventArgs e )
        {
            this.Close( );
        }


    }
}

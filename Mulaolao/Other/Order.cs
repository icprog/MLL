using Mulaolao.Class;
using StudentMgr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Mulaolao.Raw_material_cost
{
    public partial class Order : Form
    {
        public Order()
        {
            InitializeComponent();
        }
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        string cn1 = "";
        private void youSelect_Load( object sender, EventArgs e )
        {

        }
        //确定
        private void btn1_Click ( object sender ,EventArgs e )
        {
            if ( !radioButton1.Checked && !radioButton2.Checked )
                MessageBox.Show( "请选择计划订单或实际订单" );
            else
            {
                if ( radioButton1.Checked )
                    cn1 = "计划";
                else if ( radioButton2.Checked )
                    cn1 = "实际";

                PassDataWinFormEventArgs arge = new PassDataWinFormEventArgs( cn1 );
                if ( PassDataBetweenForm != null )
                {
                    PassDataBetweenForm( this ,arge );
                }
                this.Close( );
            }               
        }
        //取消
        private void btn2_Click ( object sender ,EventArgs e )
        {
            radioButton1.Checked = radioButton2.Checked = false;
            this.Close( );
        }
    }
}

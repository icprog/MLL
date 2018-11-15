using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mulaolao.Class;

namespace Mulaolao.Environmental
{
    public partial class huaxuepinSelect : Form
    {
        public huaxuepinSelect( )
        {
            InitializeComponent();
        }
        public delegate void PassDataBetweenFormHandler( object sender, PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        private void huaxuepinSelect_Load( object sender, EventArgs e )
        {

        }
        string cn1 = "";
        private void button1_Click( object sender, EventArgs e )
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("请选择识别号");
            }
            else
            {
                cn1 = comboBox1.Text;
                PassDataWinFormEventArgs args = new PassDataWinFormEventArgs(cn1);
                if (PassDataBetweenForm != null)
                {
                    PassDataBetweenForm(this, args);
                }
                this.Close();
            }
        }

        private void button2_Click( object sender, EventArgs e )
        {
            this.Close();
        }
    }
}

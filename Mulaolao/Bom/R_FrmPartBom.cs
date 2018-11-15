using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mulaolao.Bom
{
    public partial class R_FrmPartBom : Form
    {
        public R_FrmPartBom(Form1 fm )
        {
            this.MdiParent = fm;
            InitializeComponent( );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }

        private void R_FrmPartBom_Load( object sender, EventArgs e )
        {

        }
    }
}

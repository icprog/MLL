using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mulaolao.Other
{
    public partial class Guanyu : Form
    {
        public Guanyu( Form fm)
        {
            this.MdiParent = fm;
            InitializeComponent();
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
    }
}

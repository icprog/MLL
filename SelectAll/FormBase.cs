using Mulaolao.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using CYQ.Data.Table;
//using CYQ.Data;

namespace SelectAll
{
    public partial class FormBase : Form
    {
        public FormBase ( )
        {
            InitializeComponent( );
        }

        private void FormBase_Load ( object sender ,EventArgs e )
        {
           
        }


        #region button click
        protected virtual void checkAll ( )
        {
        }
        protected virtual void unCheckAll ( )
        {
        }
        protected virtual void sure ( )
        {
        }
        protected virtual void cancel ( )
        {
        }

        private void btnCheckAll_Click ( object sender ,EventArgs e )
        {
            checkAll( );
        }
        private void btnAnCheckAll_Click ( object sender ,EventArgs e )
        {
            unCheckAll( );
        }
        private void btnSure_Click ( object sender ,EventArgs e )
        {
            sure( );
        }
        private void btnCancel_Click ( object sender ,EventArgs e )
        {
            cancel( );

            this.Close( );
        }
        #endregion


    }
}

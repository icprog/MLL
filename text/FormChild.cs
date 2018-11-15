using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Data;
using System . Drawing;
using System . Linq;
using System . Text;
using System . Windows . Forms;

namespace text
{
    public partial class FormChild :Form
    {
        FormReflect from;
        int num;
        public FormChild ( FormReflect form,int num )
        {
            InitializeComponent ( );

            this . from = form;
            this . Text = "Form" + num;
            this . num = num;
            this . from . SendEvent += new FormReflect . SendEventHandler ( from_SendEvent );
        }

        void from_SendEvent ( string msg )
        {
            this . textBox1 . Text = this . num + ":" + msg;
        }

        

        private void button1_Click ( object sender ,EventArgs e )
        {
            
          
        }
    }
}

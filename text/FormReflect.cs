using System;
using System . Collections . Generic;
using System . Windows . Forms;

namespace text
{
    public partial class FormReflect :Form
    {
        public FormReflect ( )
        {
            InitializeComponent ( );
        }

        public delegate void SendEventHandler ( string msg );
        public event SendEventHandler SendEvent;

        int i=0;
        private void btnNew_Click ( object sender ,EventArgs e )
        {
            i++;
            FormChild from = new FormChild ( this ,i );
            from . Show ( );
        }

        private void btnSend_Click ( object sender ,EventArgs e )
        {
            if ( SendEvent != null )
            {
                this . SendEvent ( this . textBox1 . Text );
            }
        }

        private void button1_Click ( object sender ,EventArgs e )
        {
            MessageBox . Show ( getMax ( new List<string> ( ) { "2017C10-11" ,"2017C2-1" ,"2017C10-10" } ) );
        }

        string getMax ( List<string> strList )
        {
            string maxValue = string . Empty;
            string value = string . Empty;
            string maxStr = string . Empty;
            foreach ( string str in strList )
            {
                value = string . Empty;
                foreach ( char c in str )
                {
                    if ( c >= 48 && c <= 57 )
                    {
                        value = value + c . ToString ( );
                    }
                    else
                    {
                        value = value + 0 . ToString ( );
                    }
                }
                if ( maxValue == string . Empty )
                {
                    maxValue = value;
                    maxStr = str;
                }
                else
                {
                    if ( Convert . ToDouble ( maxValue ) < Convert . ToDouble ( value ) )
                    {
                        maxValue = value;
                        maxStr = str;
                    }
                }
            }

            return maxStr;
        }

    }
}

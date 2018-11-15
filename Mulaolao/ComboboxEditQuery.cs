using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace Mulaolao
{
    public static class ComboboxEditQuery
    {
        public static void keyUp ( DevExpress . XtraEditors . ComboBoxEdit cmb ,DataTable dt)
        {
            cmb . KeyUp += ( s ,e ) =>
            {
                try
                {
                    string str = cmb . Text . ToString ( );
                    //if (str == "")
                    //    return;
                    cmb . Properties . Items . Clear ( );//无论有没有过滤，都要清空原来的值
                    string ss = "value like '%" + str + "%'";
                    DataView v = dt . DefaultView;
                    v . RowFilter = ss;

                    DataTable dtt = v . ToTable ( );
                    if ( dtt . Rows . Count > 0 )//如果输入的值过滤后有满足的值，则加载满足条件的值,否则加载全部
                    {
                        for ( int i = 0 ; i < dtt . Rows . Count ; i++ )
                        {
                             cmb . Properties . Items . Add ( dtt . Rows [ i ] [ "value" ] . ToString ( ) );
                        }
                    }
                    else
                    {
                        for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                        {
                            cmb . Properties . Items . Add ( dt . Rows [ i ] [ "value" ] . ToString ( ) );
                        }
                    }
                }
                catch 
                {
                    throw new Exception ( "不包括值" );
                }
            };
        }

    }
    
}

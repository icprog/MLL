using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SelectAll.Class
{
    public class SailesCombobox
    {
        /// <summary>
        /// 实现模糊查询
        /// </summary>
        /// <param name="listOne"></param>
        /// <param name="box"></param>
        public void comboboxQuery ( DataTable dt ,ComboBox box,string field )
        {
            try
            {
                //查询出来符合条件的集合
                List<string> listNew = new List<string> ( );

                //dt.Rows.Clear( );
                box . DataSource = null;
                box . Items . Clear ( );
                listNew . Clear ( );
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    if ( dt . Rows [ i ] [ "" + field + "" ] . ToString ( ) . Contains ( box . Text ) )
                    {
                        listNew . Add ( dt . Rows [ i ] [ "" + field + "" ] . ToString ( ) );
                    }
                }
                box . Items . AddRange ( listNew . ToArray ( ) );
                //光标位置
                box . SelectionStart = box . Text . Length;
                //保持鼠标指针在原来位置
                //Cursor = Cursors.Default;
                //自动弹出下拉框
                box . DroppedDown = true;
            }
            catch
            {
            }
        }
    }
}

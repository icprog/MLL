using StudentMgr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Mulaolao.Class
{
    public class Encrypt
    {
        public static string encryPt ( string plainText ,string keyValue )
        {
            int len = keyValue.Length - 1;
            int _moveIndex = 0;
            string _result = string.Empty;
            
            for ( int i = 0 ; i < plainText.Length ; i++ )
            {
                _moveIndex = keyValue.LastIndexOf( plainText[i] ) + i + 1 > len ?
                            ( ( keyValue.LastIndexOf( plainText[i] ) + i + 1 ) % len ) - 1 :
                            ( keyValue.LastIndexOf( plainText[i] ) + i + 1 ) % len;
                _result += keyValue.Substring( _moveIndex ,1 );
            }
            return _result;
        }

        public static string GetDataTable ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "select net_address from master..sysprocesses where net_address in ('204747884C74','204747884C76','BE2B2D8489FF')" );

            DataTable da= SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            if ( da != null && da.Rows.Count > 0 )
                return encryPt("MLL", da.Rows[0]["net_address"].ToString( ) );
            else
                return null;
        }
    }
}

using System;
using System . Collections;
using System . Collections . Generic;
using System . IO;
using System . Linq;
using System . Text;

namespace text
{
    public class IniOperation
    {
        public Dictionary<string, string> configData;
        string fullFileName = "";

        public void Config ( string _fileName )
        {
            configData = new Dictionary<string ,string> ( );

            fullFileName = System . Environment . GetFolderPath ( Environment . SpecialFolder .ApplicationData ) + @"\" + _fileName;
            
            bool hasCfgFile = File . Exists ( System . Environment . GetFolderPath ( Environment . SpecialFolder . ApplicationData ) + @"\" + _fileName );
            if ( hasCfgFile == false )
            {
                StreamWriter write = new StreamWriter ( File . Create ( System . Environment . GetFolderPath ( Environment . SpecialFolder . ApplicationData ) + @"\" + _fileName ) ,Encoding . Default );
                write . Close ( );
            }
            StreamReader reader = new StreamReader ( System . Environment . GetFolderPath ( Environment . SpecialFolder . ApplicationData ) + @"\" + _fileName ,Encoding . Default );
            string line/* = reader . ReadLine ( );*/;
            int idx = 0;
            while ( ( line = reader . ReadLine ( ) ) != null )
            {
                if ( line . StartsWith ( ";" ) || string . IsNullOrEmpty ( line ) )
                {
                    configData . Add ( ";" + idx++ ,line );
                }
                else
                {
                    string [ ] key_value = line . Split ( '=' );
                    if ( key_value . Length >= 2 )
                    {
                        configData . Add ( key_value [ 0 ] ,key_value [ 1 ] );
                    }
                    else
                        configData . Add ( ";" + idx++ ,line );
                }
            }
            reader . Close ( );
        }

        public string get ( string key )
        {
            if ( configData . Count <= 0 )
                return null;
            else if ( configData . ContainsKey ( key ) )
                return configData [ key ] . ToString ( );
            else
                return null;
        }

        public void set ( string key ,string value )
        {
            if ( configData . ContainsKey ( key ) )
                configData [ key ] = value;
            else
                configData . Add ( key ,value );
        }

        public void save ( )
        {
            StreamWriter write = new StreamWriter ( fullFileName ,false ,Encoding . Default );
            IDictionaryEnumerator enu = configData . GetEnumerator ( );
            while ( enu . MoveNext ( ) )
            {
                if ( enu . Key . ToString ( ) . StartsWith ( ";" ) )
                    write . WriteLine ( enu . Value );
                else
                    write . WriteLine ( enu . Key + "=" + enu . Value );
            }
            write . Close ( );
        }
    }
}

using System;
using System . Windows . Forms;
using AutoUpdate;
using Mulaolao . Class;

namespace Mulaolao
{
    static class Program
    {
        //private static Mutex mutex;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main ( )
        {
            //Devexpress 13.1  汉化
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo( "zh-CN" );

            Application.EnableVisualStyles( );
            Application.SetCompatibleTextRenderingDefault( false );

            //打印报表界面汉化
            FastReport . Utils . Res . LoadLocale ( Application . StartupPath + "\\Chinese (Simplified).frl" );

            AppUpdate au = new AppUpdate ( );
            string msg = "";
            bool result = au . CheckAppVersion ( ref msg );
            if ( result == true )
                System . Diagnostics . Process . Start ( Application . StartupPath + @"\AutoUpdate.exe" );
            else
            {
                if ( Encrypt . GetDataTable ( ) . Equals ( "204" ,StringComparison . CurrentCultureIgnoreCase ) || Encrypt . GetDataTable ( ) . Equals ( "BE2" ,StringComparison . CurrentCultureIgnoreCase ) )
                {
                    Login lg = new Login ( );
                    lg . StartPosition = FormStartPosition . CenterScreen;
                    lg . ShowDialog ( );
                    if ( lg . DialogResult == DialogResult . OK )
                        Application . Run ( new Form1 ( ) );
                }
            }
        }

    }

}
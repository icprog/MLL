using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;

namespace Mulaolao . Class
{
    public static class Calcu344Spe
    {
        public static decimal calculVolume ( string speci )
        {
            decimal resus = 0M;
            if ( string . IsNullOrEmpty ( speci ) )
                resus = 0M;
            else
            {
                string [ ] str = speci . Split ( '*' );
                if ( str . Length < 1 )
                    resus = 0M;
                else if ( str . Length == 1 )
                {
                    if ( isNumberic ( str [ 0 ] ,out resus ) )
                        resus = 0M;
                    else
                    {
                        if ( str [ 0 ] . Contains ( "Φ" ) || str [ 0 ] . Contains ( "φ" ) )
                            resus = Math . Round ( Convert . ToDecimal ( Convert . ToDouble ( Math . PI ) * Math . Pow ( Convert . ToDouble ( str [ 0 ] . Substring ( 1 ,str [ 0 ] . Length - 1 ) ) ,3 ) /** Convert.ToDouble( 0.0001 )*/ * 4 / 3 ) ,1 );
                        else
                            resus = 0M;
                    }
                }
                else if ( str . Length == 2 )
                {
                    if ( isNumberic ( str [ 0 ] ,out resus ) )
                        resus = 0M;
                    else
                    {
                        if ( ( str [ 0 ] . Contains ( "Φ" ) || str [ 0 ] . Contains ( "φ" ) ) && ( str [ 0 ] . Substring ( 0 ,1 ) == "Φ" || str [ 0 ] . Substring ( 0 ,1 ) == "φ" ) )
                        {
                            if ( isNumberic ( str [ 1 ] ,out resus ) )
                            {
                                if ( isNumberic ( str [ 0 ] . Substring ( 1 ,str [ 0 ] . Length - 1 ) ,out resus ) )
                                    resus = Math . Round ( Convert . ToDecimal ( Convert . ToDouble ( Math . PI ) * Math . Pow ( Convert . ToDouble ( str [ 0 ] . Substring ( 1 ,str [ 0 ] . Length - 1 ) ) / 2 ,2 ) * Convert . ToDouble ( str [ 1 ] ) /** Convert.ToDouble( 0.0001 )*/ ) ,1 );
                                else
                                    resus = 0M;
                            }
                            else
                                resus = 0M;
                        }
                        else
                            resus = 0M;
                    }
                }
                else if ( str . Length >= 3 )
                {
                    if ( isNumberic ( str [ 0 ] ,out resus ) && isNumberic ( str [ 1 ] ,out resus ) && isNumberic ( str [ 2 ] ,out resus ) )
                        resus = Math . Round ( Convert . ToDecimal ( str [ 0 ] ) * Convert . ToDecimal ( str [ 1 ] ) * Convert . ToDecimal ( str [ 2 ] ) /** Convert.ToDecimal( 0.0001 )*/ ,1 );
                    else
                        resus = 0M;
                }
            }
            return resus;
        }

        private static bool isNumberic ( string message ,out decimal reus )
        {
            reus = -1M;
            try
            {
                reus = Convert . ToDecimal ( message );
                if ( reus == 0M )
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }

    }
}

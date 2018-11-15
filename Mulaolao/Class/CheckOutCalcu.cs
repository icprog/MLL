using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mulaolao.Class
{
    public  class CheckOutCalcu
    {           
        public static decimal Calculation ( TextBox boxOne ,TextBox boxTwo ,TextBox boxTre,TextBox boxFor )
        {
            decimal result = 0M;
            decimal _one = 0M, _two = 0M, _thr = 0M, _for = 0M;
            if ( !string.IsNullOrEmpty( boxOne.Text ) )
                _one = Convert.ToDecimal( boxOne.Text );
            else
                _one = 0;
            if ( !string.IsNullOrEmpty( boxTwo.Text ) )
                _two = Convert.ToDecimal( boxTwo.Text );
            else
                _two = 0;

            if ( !string.IsNullOrEmpty( boxTre.Text ) )
                _thr = Convert.ToDecimal( boxTre.Text );
            else
                _thr = 0;
            if ( !string.IsNullOrEmpty( boxFor.Text ) )
                _for = Convert.ToDecimal( boxFor.Text );
            else
                _for = 0;

            result = _one - _two - _thr - _for;

            return result;
        }
    }
}

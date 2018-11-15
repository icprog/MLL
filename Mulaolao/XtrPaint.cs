using DevExpress . Utils . Paint;
using System;
using System . Collections . Generic;
using System . Drawing;
using System . Linq;
using System . Text;

namespace Mulaolao
{
    public class DrawXPaint :XPaint
    {
        public override void DrawFocusRectangle ( Graphics g ,Rectangle r ,Color foreColor ,Color backColor )
        {
            base . DrawFocusRectangle ( g ,r ,foreColor ,backColor );
            if ( !CanDraw ( r ) )
                return;
            Brush hb = Brushes . Black;
            g . FillRectangle ( hb ,new Rectangle ( r . X ,r . Y ,2 ,r . Height - 2 ) );//Left
            g . FillRectangle ( hb ,new Rectangle ( r . X ,r . Y ,r . Width - 2 ,2 ) );//Top
            g . FillRectangle ( hb ,new Rectangle ( r . Right - 2 ,r . Y ,2 ,r . Height - 2 ) );//Right
            g . FillRectangle ( hb ,new Rectangle ( r . X ,r . Bottom - 2 ,r . Width - 2 ,2 ) );//Bottom    
        }
    }
}

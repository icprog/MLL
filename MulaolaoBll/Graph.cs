using System . Drawing;

namespace MulaolaoBll
{
   public static class Graph
    {
        public static void gra ( DevExpress . XtraEditors . SplitContainerControl sp ,string fontName )
        {
            sp . Panel1 . Paint += ( s ,e ) =>
            {
                Point p = sp . PointToScreen ( sp . Location );
                Graphics gp = e . Graphics;
                //gp . Clear ( CarpenterBll . UserInformation . FeedColor );
                if ( !fontName . Contains ( "反" ) )
                {
                    //画填充圆
                    //SolidBrush s = new SolidBrush ( Color . Red );
                    //画空心圆
                    Pen pen = new Pen ( Color . Red ,3 );
                    gp . DrawEllipse ( pen ,1000 ,80 ,100 ,45 );
                    Font myFont = new Font ( "宋体" ,18 ,FontStyle . Bold );
                    Brush bush = new SolidBrush ( Color . Red );
                    gp . DrawString ( fontName ,myFont ,bush ,1600 ,20 );
                }
            };
        }

        public static void gra ( DevExpress . XtraTab . XtraTabControl sp ,string fontName )
        {
            sp . TabPages [ 0 ] . Paint += ( s ,e ) =>
            {
                Point p = sp . PointToScreen ( sp . Location );
                Graphics gp = e . Graphics;
                //gp . Clear ( CarpenterBll . UserInformation . FeedColor );
                if ( !fontName . Contains ( "反" ) )
                {
                    //画填充圆
                    //SolidBrush s = new SolidBrush ( Color . Red );
                    //画空心圆
                    Pen pen = new Pen ( Color . Red ,3 );
                    gp . DrawEllipse ( pen ,600 ,10 ,60 ,45 );
                    Font myFont = new Font ( "宋体" ,18 ,FontStyle . Bold );
                    Brush bush = new SolidBrush ( Color . Red );
                    gp . DrawString ( fontName ,myFont ,bush ,600 ,20 );
                }
            };
        }

        public static void gra ( DevExpress . XtraEditors . SplitContainerControl sp ,string fontName ,int x )
        {
            sp . Panel1 . Paint += ( s ,e ) =>
            {
                Point p = sp . PointToScreen ( sp . Location );
                Graphics gp = e . Graphics;
                //gp . Clear ( CarpenterBll . UserInformation . FeedColor );
                if ( !fontName . Contains ( "反" ) )
                {
                    //画填充圆
                    //SolidBrush s = new SolidBrush ( Color . Red );
                    //画空心圆
                    Pen pen = new Pen ( Color . Red ,3 );
                    gp . DrawEllipse ( pen ,x ,10 ,60 ,45 );
                    Font myFont = new Font ( "宋体" ,18 ,FontStyle . Bold );
                    Brush bush = new SolidBrush ( Color . Red );
                    gp . DrawString ( fontName ,myFont ,bush ,x ,20 );
                }
            };
        }

        public static void gra ( System.Windows.Forms.Form sp ,string fontName ,int x )
        {
            sp .  Paint += ( s ,e ) =>
            {
                Point p = sp . PointToScreen ( sp . Location );
                Graphics gp = e . Graphics;
                //gp . Clear ( CarpenterBll . UserInformation . FeedColor );
                if ( !fontName . Contains ( "反" ) )
                {
                    //画填充圆
                    //SolidBrush s = new SolidBrush ( Color . Red );
                    //画空心圆
                    Pen pen = new Pen ( Color . Red ,3 );
                    gp . DrawEllipse ( pen ,x ,10 ,60 ,45 );
                    Font myFont = new Font ( "宋体" ,18 ,FontStyle . Bold );
                    Brush bush = new SolidBrush ( Color . Red );
                    gp . DrawString ( fontName ,myFont ,bush ,x ,20 );
                }
            };
        }

    }
}

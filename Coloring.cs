using System.Drawing;

namespace Runner
{
    class Coloring
    {
        /* Coloring class designed to make all coloring type actions.
           Actions include:
           - Changing pixel colors of a bitmap via x,y coordinates
           - Changing pixel colors of a bitmap via Point object
           - Returning bitmap that is being adjusted
           - Determining what color a pixel is
        */
        public Bitmap Bmp
        {
            get;
        }
        private static Color solutionColor = Color.Green; //Solution set color
        public Coloring(Bitmap bmp)
        {
            this.Bmp = bmp;
        }
        public bool isRed(int x, int y)
        {
            //Determines if pixel is a shade of red
            Color color = Bmp.GetPixel(x, y);
            int red = color.R;
            int blue = color.B;
            int green = color.G;
   
            return red > blue && red > green;
        }
        public bool isRed(Point point)
        {
            //Wrapper function for Points       
            return isRed(point.X,point.Y);
        }
        public bool isBlue(int x, int y)
        {
            //Determines if pixel is a shade of blue
            Color color = Bmp.GetPixel(x, y);
            int red = color.R;
            int blue = color.B;
            int green = color.G;
            
            return blue > red && blue > green;
        }
        public bool isBlue(Point point)
        {
            //Wrapper function for Points   
            return isBlue(point.X,point.Y);
        }
        public bool isBlack(int x, int y)
        {
            //Determines if pixel contains the RGB for black.(0,0,0)
            Color color = Bmp.GetPixel(x, y);
            int red = color.R;
            int blue = color.B;
            int green = color.G;
            return (red + green + blue) == 0;
        }
        public bool isBlack(Point point)
        {
            //Wrapper function for Points
            return isBlack(point.X,point.Y);
        }
        public bool isWhite(int x, int y)
        {
            //Determines if pixel contains the RGB for black.(255,255,255)
            Color color = Bmp.GetPixel(x, y);
            int red = color.R;
            int blue = color.B;
            int green = color.G;
            return (red + green - blue) == 255;
        }
        public bool isWhite(Point point)
        {
            //Wrapper function for Points    
            return isWhite(point.X,point.Y);
        }
        public void colorPixel(int x,int y)
        {
            //Colors the coordinates of a bitmap to the solution color.
            Bmp.SetPixel(x, y, solutionColor);
        }
        public void colorPixel(Point point)
        {
            //Colors the coordinates of a bitmap to the solution color.
            Bmp.SetPixel(point.X, point.Y, solutionColor);
        }

    }
}

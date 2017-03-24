using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters
{
    class TurnFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Random t = new Random();
            int x0 = sourceImage.Width / 2;
            int y0 = sourceImage.Height / 2;
            int k = (int)((x - x0) * Math.Cos(Math.PI / 3) - (y - y0) * Math.Sin(Math.PI / 3) + x0);
            int l = (int)((x - x0) * Math.Sin(Math.PI / 3) + (y - y0) * Math.Cos(Math.PI / 3) + y0);
            if (k <= 0 || k >= sourceImage.Width || l <= 0 || l >= sourceImage.Height)
                return Color.Black;
            return sourceImage.GetPixel(k, l);
        }
    }
}

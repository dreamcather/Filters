using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters
{
    class WavesFiter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int k = (int)(x + 20 * Math.Sin(2 * Math.PI * y / 60));
            int l = (int)y;
            return sourceImage.GetPixel(Clamp(k, 0, sourceImage.Width - 1), Clamp(l, 0, sourceImage.Height - 1));
        }
    }
}

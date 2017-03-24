using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters
{
    class BrightFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int c = 60;
            return Color.FromArgb(Clamp(sourceColor.R + c, 0, 255),
                                  Clamp(sourceColor.G + c, 0, 255),
                                  Clamp(sourceColor.B + c, 0, 255));
        }
    }
}

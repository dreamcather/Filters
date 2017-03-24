using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters
{
    class SepiaFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            double Intensity = 0.36 * sourceColor.R + 0.53 * sourceColor.G + 0.11 * sourceColor.B;
            int k = 18;
            Color resultColor = Color.FromArgb(Clamp((int)(Intensity + 2 * k), 0, 255),
                                               Clamp((int)(Intensity + 0.5 * k), 0, 255),
                                               Clamp((int)(Intensity - 1 * k), 0, 255));
            return resultColor;
        }
    }
}
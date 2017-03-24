using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters
{
    class GrayScaleFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            double Intensity = 0.36 * sourceColor.R + 0.53 * sourceColor.G + 0.11 * sourceColor.B;
            return Color.FromArgb((int)Intensity, (int)Intensity, (int)Intensity);
        }
    }
}
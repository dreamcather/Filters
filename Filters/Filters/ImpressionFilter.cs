using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Filters
{
    class ImpressionFilter:Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            float[,] kernel = new float[,] { { 0, 1, 0 }, { 1, 0, -1 }, { 0, -1, 0 } };
            int radius = kernel.GetLength(0) / 2;
            float resultR = 0;
            float resultG = 0;
            float resultB = 0;
            for (int i = -radius; i <= radius; i++)
            {
                for (int j = -radius; j <= radius; j++)
                {
                    int idX = Clamp(x + i, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + j, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultR += neighborColor.R * kernel[i + radius, j + radius];
                    resultG += neighborColor.G * kernel[i + radius, j + radius];
                    resultB += neighborColor.B * kernel[i + radius, j + radius];
                }
            }
            int c = 150;
            return Color.FromArgb(
                Clamp((int)resultR + c, 0, 255),
                Clamp((int)resultG + c, 0, 255),
                Clamp((int)resultB + c, 0, 255)
                );
        }
    }
}

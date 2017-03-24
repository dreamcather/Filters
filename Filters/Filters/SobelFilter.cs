using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters
{
    class SobelFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            float[,] kernel1 = new float[,] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };
            float resultR1 = 0;
            float resultG1 = 0;
            float resultB1 = 0;
            float[,] kernel2 = new float[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            float resultR2 = 0;
            float resultG2 = 0;
            float resultB2 = 0;
            for (int l = -1; l <= 1; l++)
            {
                for (int k = -1; k <= 1; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultR1 += neighborColor.R * kernel1[k + 1, l + 1];
                    resultG1 += neighborColor.G * kernel1[k + 1, l + 1];
                    resultB1 += neighborColor.B * kernel1[k + 1, l + 1];
                    resultR2 += neighborColor.R * kernel2[k + 1, l + 1];
                    resultG2 += neighborColor.G * kernel2[k + 1, l + 1];
                    resultB2 += neighborColor.B * kernel2[k + 1, l + 1];
                }
            }
            return Color.FromArgb(
                Clamp((int)Math.Sqrt(Math.Pow(resultR1,2) + Math.Pow(resultR2,2)), 0, 255),
                Clamp((int)Math.Sqrt(Math.Pow(resultG1, 2) + Math.Pow(resultG2, 2)), 0, 255),
                Clamp((int)Math.Sqrt(Math.Pow(resultB1, 2) + Math.Pow(resultB2, 2)), 0, 255)
                );
        }
    }
}

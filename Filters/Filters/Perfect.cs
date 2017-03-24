using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters
{
    class Perfect : Filters
    {
        ushort[] maxR;
        ushort[] maxG;
        ushort[] maxB;
        void CalcParC(Bitmap sourceImage)
        {
            maxR = CalcParR(sourceImage);
            maxG = CalcParG(sourceImage);
            maxB = CalcParB(sourceImage);
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            if ((x == 0) && (y == 0))
            {
                maxR = CalcParR(sourceImage);
                maxG = CalcParG(sourceImage);
                maxB = CalcParB(sourceImage);
            }
            Color res = sourceImage.GetPixel(x, y);
            ushort R = (ushort)(res.R * 255 / maxR[1]);
            ushort G = (ushort)(res.G * 255 / maxG[1]);
            ushort B = (ushort)(res.B * 255 / maxB[1]);
            Color resultColor = Color.FromArgb(R,G,B);
            return resultColor;

        }
    }
}

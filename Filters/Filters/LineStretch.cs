using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Filters
{
    class LineStretch:Filters
    {
        ushort[] resR = new ushort[2];
        ushort[] resG = new ushort[2];
        ushort[] resB = new ushort[2];
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            if ((x==0)&&(y==0))
            {resR=CalcParR(sourceImage);
                resG = CalcParG(sourceImage);
                resB = CalcParB(sourceImage);
            }
            Color rgbim = sourceImage.GetPixel(x, y);
                ushort corectR = (ushort)((rgbim.R - resR[0]) * (255f / (resR[1] - resR[0])));
                corectR = (ushort)Clamp(corectR, 0, 255);
            ushort corectG = (ushort)((rgbim.G - resG[0]) * (255f /(resG[1] - resG[0])));
            corectG = (ushort)Clamp(corectG, 0, 255);
            ushort corectB = (ushort)((rgbim.B - resB[0]) * (255f / (resB[1] - resB[0])));
            corectB= (ushort)Clamp(corectB, 0, 255);
            return Color.FromArgb(corectR, corectG, corectB);
        }
    }
}

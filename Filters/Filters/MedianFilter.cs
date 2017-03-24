using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Filters
{
    class MedianFilter : Filters
    {
        public struct inf
        {
            public ushort hue;
            public int k;
            public int l;
        }
        ushort CalcHue(Color temp)
        {
            float hue=0;
            float R_ = temp.R / 255f;
            float G_ = temp.G / 255f;
            float B_ = temp.B / 255f;
            float cMAX = Math.Max(Math.Max(R_,G_),B_);
            float cMIN= Math.Min(Math.Min(R_, G_), B_);
            if((cMAX-cMIN)<0.00001f)
            { hue = 0; }
            else
                if(cMAX==R_)
            { hue = 60f * (((G_ - B_) / (cMAX - cMIN) / 6f)); }
            else
                if(cMAX == G_)
            { hue = 60f * (((B_ - R_) / (cMAX - cMIN) +2f)); }
            else
                if(cMAX == B_)
            { hue = 60f * (((R_ - G_) / (cMAX - cMIN) + 4f)); }
            return (ushort)hue;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int m = 0;
            inf[] mas = new inf[9];
            for (int l = -1; l <= 1; l++)
            {
                for (int k = -1; k <= 1; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    mas[m].hue = CalcHue(neighborColor);
                    mas[m].k = k;
                    mas[m].l = l;
                    m++;
                }
            }
            ushort[] hue = new ushort[9];
            for(int i=0;i<9;i++)
            { hue[i] = mas[i].hue; }
            Array.Sort(hue);
            ushort thue = hue[5];
            for (int i = 0; i < 9; i++)
            {if (mas[i].hue == thue)
                {
                    int idX = Clamp(x + mas[i].k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + mas[i].l, 0, sourceImage.Height - 1);
                    return sourceImage.GetPixel(idX, idY);
                }
            }
            return sourceImage.GetPixel(x, y);
        }
    }
}

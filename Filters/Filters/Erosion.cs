﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Filters
{
    class Erosion: MatrixFilter
{
        public Erosion()
        {
            SetStruct();
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color min = sourceImage.GetPixel(x, y);
            HSVcolor minhsv = RGBtoHSV(min);
            ushort minv = minhsv.v;
            for (int l = -kernel.GetLength(0)/2; l <= kernel.GetLength(0)/2; l++)
            {
                for (int k = -kernel.GetLength(1)/2; k <= kernel.GetLength(1)/2; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    HSVcolor hsvim = RGBtoHSV(neighborColor);
                    if ((kernel[k + kernel.GetLength(0) / 2, l + kernel.GetLength(1) / 2]) == 1)
                    {
                        ushort v = (ushort)(hsvim.v);
                        if(v<minv)
                        {
                            minv = v;
                            min = HSVtoRGB(hsvim);
                        }

                    }
                    

                }
            }
            return min;
        }
    }
}

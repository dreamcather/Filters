using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace Filters
{
    class Grad:MatrixFilter
    {
        Bitmap frs;
        Bitmap sec;
        public Grad()
        {
            SetStruct();
        }
        Bitmap CalcFrs (Bitmap sourceImage)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor1(sourceImage, i, j));

                }
            }
            return resultImage;
        }
        Color calculateNewPixelColor1(Bitmap sourceImage, int x, int y)
        {
            for (int l = -kernel.GetLength(0) / 2; l <= kernel.GetLength(0) / 2; l++)
            {
                for (int k = -kernel.GetLength(1) / 2; k <= kernel.GetLength(1) / 2; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    HSVcolor hsvim = RGBtoHSV(neighborColor);
                    if ((kernel[k + kernel.GetLength(0) / 2, l + kernel.GetLength(1) / 2]) == 1)
                    {
                        ushort h = (ushort)(hsvim.v);
                        if (h < 20)
                        {
                            return Color.Black;
                        }
                    }

                }
            }
            return Color.White;
        }
        Bitmap CalcSec(Bitmap sourceImage)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor2(sourceImage, i, j));

                }
            }
            return resultImage;
        }
        Color calculateNewPixelColor2(Bitmap sourceImage, int x, int y)
        {
            for (int l = -kernel.GetLength(0) / 2; l <= kernel.GetLength(0) / 2; l++)
            {
                for (int k = -kernel.GetLength(1) / 2; k <= kernel.GetLength(1) / 2; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    HSVcolor hsvim = RGBtoHSV(neighborColor);
                    if ((kernel[k + kernel.GetLength(0) / 2, l + kernel.GetLength(1) / 2]) == 1)
                    {
                        ushort h = (ushort)(hsvim.v);
                        if (h > 80)
                        {
                            return Color.White;
                        }

                    }


                }
            }
            Color res = Color.Black;
            return res;
        }
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            frs = CalcFrs(sourceImage);
            sec=CalcSec(sourceImage);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));

                }
            }
            return resultImage;
        }
        protected override Color  calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            if (frs.GetPixel(x, y) != sec.GetPixel(x, y))
            {
                return Color.Black;
            }
            return Color.White;
        }
    }
}

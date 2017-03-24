using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace Filters
{
    class Closing:MatrixFilter    {
        public Closing()
        {
            SetStruct();
        }
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));

                }
            }
            Bitmap resultImage1 = new Bitmap(resultImage.Width, sourceImage.Height);
            for (int i = 0; i < resultImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage1.Width * 100));
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < resultImage.Height; j++)
                {
                    resultImage1.SetPixel(i, j, calculateNewPixelColor1(resultImage, i, j));

                }
            }
            return resultImage1;

        }
        protected  Color calculateNewPixelColor1(Bitmap sourceImage, int x, int y)
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
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
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
}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
namespace Filters
{
    abstract class Filters:ColorConvert
    {
        protected abstract Color calculateNewPixelColor(Bitmap sourceImage, int x, int y);

        public virtual Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            CalcParR(sourceImage);
            CalcParG(sourceImage);
            CalcParB(sourceImage);
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

        public int Clamp(int value, int min, int max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }
        public byte[] CalcPar(Bitmap sourceImage)
        {
            int width = sourceImage.Width;
            int hight = sourceImage.Height;
            byte max = 0;
            byte min = 100;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < hight; j++)
                {
                    Color rgbres = sourceImage.GetPixel(i, j);
                    HSVcolor hsvres = RGBtoHSV(rgbres);
                    if (hsvres.v > max)
                        max = hsvres.v;
                    if (hsvres.v < min)
                        min = hsvres.v;
                }
            }
            byte[] res = new byte[2] { min, max };
            return res;
        }
        public ushort[] CalcParR(Bitmap sourceImage)
        {
            int width = sourceImage.Width;
            int hight = sourceImage.Height;
            byte max = 0;
            byte min = 255;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < hight; j++)
                {
                    Color rgbres = sourceImage.GetPixel(i, j);
                    if (rgbres.R > max)
                        max = rgbres.R;
                    if (rgbres.R < min)
                        min = rgbres.R;
                }
            }
            ushort[] res = new ushort[2] { min, max };
            return res;
        }
        public ushort[] CalcParG(Bitmap sourceImage)
        {
            int width = sourceImage.Width;
            int hight = sourceImage.Height;
            byte max = 0;
            byte min = 255;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < hight; j++)
                {
                    Color rgbres = sourceImage.GetPixel(i, j);
                    if (rgbres.G > max)
                        max = rgbres.G;
                    if (rgbres.G < min)
                        min = rgbres.G;
                }
            }
            ushort[] res = new ushort[2] { min, max };
            return res;
        }
        public ushort[] CalcParB(Bitmap sourceImage)
        {
            int width = sourceImage.Width;
            int hight = sourceImage.Height;
            byte max = 0;
            byte min = 255;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < hight; j++)
                {
                    Color rgbres = sourceImage.GetPixel(i, j);
                    if (rgbres.B > max)
                        max = rgbres.B;
                    if (rgbres.B < min)
                        min = rgbres.B;
                }
            }
            ushort[] res = new ushort[2] { min, max };
            return res;
        }
    }
}

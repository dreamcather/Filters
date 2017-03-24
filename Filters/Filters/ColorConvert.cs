using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Filters
{
    public struct HSVcolor
    {
        public ushort h;
        public byte s;
        public byte v;
        public HSVcolor(ushort h_, byte s_, byte v_)
        {
            h = h_;
            s = s_;
            v = v_;
        }
    }
    public class ColorConvert
    {
        public Bitmap rgbimage;
        public HSVcolor[,] hsvimage;
        byte Clamp(byte min,byte value,byte max)
        {
            return Math.Min(Math.Max(min, value), max);
        }
        ushort Clamp(ushort min, ushort value, ushort max)
        {
            return Math.Min(Math.Max(min, value), max);
        }
        public HSVcolor RGBtoHSV(Color source)
        {
            float eps=0.0000001f;
            ushort hue = 0;
            byte saturation = 0;
            byte value = 0;
            float R_ = source.R / 255f;
            float G_ = source.G / 255f;
            float B_ = source.B / 255f;
            float Cmax = Math.Max(R_,Math.Max(G_,B_));
            float Cmin = Math.Min(R_, Math.Min(G_, B_));
            float delta = Cmax - Cmin;
            value = (byte)(Cmax * 100);
            if (Cmax < eps)
                saturation = 0;
            else
                saturation = (byte)(100 * delta / Cmax);
            if (delta < eps)
                hue = 0;
            else if (Cmax == R_)
                hue = (ushort)(60f * (((G_ - B_) / delta) % 6f));
            else if(Cmax==G_)
                hue= (ushort)(60f * (((B_ - R_) / delta) + 2f));
            else if(Cmax==B_)
                hue = (ushort)(60f * (((R_ - G_) / delta) + 4f));
            return new HSVcolor(Clamp(0, hue, 359), saturation, value);
        }
        public Color HSVtoRGB(HSVcolor source)
        {
            float R_ = 0f, G_ = 0f, B_ = 0f;
            float C = source.s * source.v / 100f / 100f;
            float X = C * (1 - Math.Abs((source.h / 60f) / 2f - 1));
            float m = source.v / 100f - C;
            if(source.h<60)
            {
                R_ = C;G_ = X;B_ = 0f;
            }
            else if(source.h<120)
            {
                R_ = X;G_ = C;B_ = 0f;
            }
            else if(source.h<180)
            {
                R_ = 0f; G_ = C;B_ = X;
            }
            else if(source.h<240)
            {
                R_ = 0f;G_ = X;B_ = C;
            }
            else if(source.h<300)
            {
                R_ = X;G_ = 0f;B_ = C;
            }
            else if(source.h<360)
            {
                R_ = C;G_ = 0f;B_ = X;
            }
            byte R = (byte)(255f * (R_ + m));
            byte G = (byte)(255f * (G_ + m));
            byte B = (byte)(255f * (B_ + m));
            return Color.FromArgb(Clamp(0, R, 255), Clamp(0, G, 255), Clamp(0, B, 255));
        }
    }
}

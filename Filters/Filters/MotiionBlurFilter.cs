using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters
{
    class MotionBlurFilter : MatrixFilter
    {
        public MotionBlurFilter()
        {
            int n = 7;
            kernel = new float[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    kernel[i, j] = 0;
                    if (i == j)
                        kernel[i, j] = 1.0f / (float)n;
                }
            }
        }
    }
}

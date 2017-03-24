using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters
{
    class HarshnessFilter:MatrixFilter
    {
        public HarshnessFilter()
        {
            kernel = new float[,] { { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 } };
        }
    }
}

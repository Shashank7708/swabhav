using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintInfo
{
    class Rectangle
    {
        public int height;
        public int width;

        public void setvalue(int a, int b)
        {
            height = a;
            width = b;
        }

        public int getHeight()
        {
            return height;

        }

        public int getWidth()
        {
            return width;
        }
    }
}

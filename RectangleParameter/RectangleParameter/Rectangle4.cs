using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleParameter
{
    class Rectangle4
    {
        public int height;
        public int width;
        public string color;

        public Rectangle4(int h,int w,string c)
        {
            if (h < 1)
                height = 1;
            else if (h > 100)
                height = 100;
            else
                height = h;
            if (w< 1)
                width = 1;
            else if (w > 100)
                width = 100;
            else
                width = 100;

            if (c == "Red" || c == "red" || c == "Blue" || c == "blue" || c == "green" || c == "Green")
            {
                color = c;
            }
            else
                color = "black";
        }
    }
}

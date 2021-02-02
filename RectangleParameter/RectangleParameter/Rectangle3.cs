using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleParameter
{
    class Rectangle3
    {
        private  int height;
        private  int width;
        private string color;

        public Rectangle3(int h1, int w1, string c)
        {
            height = h1;
            width = w1;
            color = c;
        }
        
        public int returnHeight()
        {
            return height;
        }

        public int returnWidth()
        {
            return width;
        }

        public string returnColor()
        {
            return color;
        }


    }
}


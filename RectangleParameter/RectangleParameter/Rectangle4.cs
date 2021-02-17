using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleParameter
{
    class Rectangle4
    {
        private int height;
        private int width;
        private string color;

        public int PropertyHeight
        { set
            {
                if (value < 1)
                    height = 1;
                else if (value > 100)
                    height = 100;
                else
                    height = value;
            }
            get { return height; }
        }

        public int PropertyWidth
        {
            set {
                if (value < 1)
                    width = 1;
                else if (value > 100)
                    width = 100;
                else
                    width = value;
            }
            get { return width; }
        }
        public string PropertyColor
        {
            set
            {
                if (value== "Red" || value== "red" || value == "Blue" || value == "blue" ||value == "green" || value== "Green")
                {
                    color = value;
                }
                else
                    color = "black";
            }
            get
            {
                return color;
            }
        }
    }
}

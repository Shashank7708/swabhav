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

        public int returnHeight
        {
            set { this.height = value; }
            get { return this.height; }
        }
        public int returnWidth
        {
            set { this.width = value; }
            get { return this.width; }
        }
        public string returnColor
        {
            set
            {
                if (value == "Red" || value == "red" || value == "Blue" || value == "blue" || value == "Green" || value == "green")
                    this.color = value;
                else
                    this.color = "Black";
            }
            get { return this.color; }
        }
        
      

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonHealth
{
    class Person
    {
        private int age;
        private string name;
        private string gender;
        private float weight;
        private float height;

        public int getAge
        {
            set { this.age = value; }
            get { return this.age; }
        }

        public string getName
        {
            set { this.name = value; }
            get { return this.name; }
        }
        public string getGender
        {
            set { this.gender = value; }
            get { return this.gender; }
        }

        public float getWeight
        {
            set { this.weight = value; }
            get { return this.weight; }
        }
        public float getHeight
        {
            set { this.height = value; }
            get { return this.height; }
        }
        
        public void eat()
        {
           
                this.weight = this.weight + 5 * this.weight / 100;
            

        }
        public float BMR
        {
            get { 
                return (66.5f + 13.75f * weight + 5.003f * height - 6.755f * age);
            }
        }

    }
}

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

        internal Person(int a, string n, string g, float w,float h)
        {
            age = a;
            name = n;
            gender = g;
            weight = w;
            height = h;
        }
        internal Person(string n,string gender)
        {
            name = n;
            this.gender = gender;
        }

        public int getAge()
        {
            return age;
        }

        public string getName()
        {
            return name;
        }
        public string getGender()
        {
            return gender;
        }
        public float getWeight()
        {
            return weight;
        }

        public float getHeight()
        {
            return height;
        }
        public  void workout()
        {
            weight =weight - 2.5f*weight/100;

        }
        public void eat()
        {
            weight =weight + 5*weight/ 100;

        }
        public float BMR()
        {
            return(66.5f+13.75f*weight+5.003f*height - 6.755f*age);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.IO;

namespace AnimalSerialization
{   [Serializable]
    class Animal :ISerializable
    {
        public string name { set; get; }
        public double Weight { set; get; }
        public double Height { set; get; }
        public int AnimalID { set; get; }

        public Animal() { }
        public Animal(String name="No name",Double weight=0,double height=0)
        {
            this.name = name;
            this.Height = height;
            this.Weight = weight;
        }
        public override string ToString()
        {
            return string.Format("{0} weighs {1} kgs and is {2} inches tall", name, Weight, Height);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", name);
            info.AddValue("Weight", Weight);
            info.AddValue("Height", Height);
        }
        public Animal(SerializationInfo info, StreamingContext context)
        {
                name = (string)info.GetValue("Name", typeof(string));
            Weight = (double)info.GetValue("Weight", typeof(double));
            Height = (double)info.GetValue("Height", typeof(double));

            

        }
    }
}

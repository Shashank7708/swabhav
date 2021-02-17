using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace AnimalSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal bowser = new Animal("Rocky", 45, 13);
            Stream stream = File.Open("AnimalData.dat", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, bowser);
            stream.Close();
            bowser = null;
            stream = File.Open("AnimalData.dat", FileMode.Open);
            bf = new BinaryFormatter();
            bowser = (Animal)bf.Deserialize(stream);
            stream.Close();
            Console.WriteLine(bowser.ToString());
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingCSVFile
{
    class Program
    {
        static void Main(string[] args)
        {   //Reading a .CSV FIle
            string path = @"reading.csv";
            var reading = File.ReadAllLines("C:\\swabhav\\reading.csv");

            foreach(var i in reading)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\nAfter Changes:");
            var list = new List<Content>();
            foreach(var i in reading)                          //Printing a .CSV File
            {
                string[] arr = i.Split(',');
                var content = new Content() { id = arr[0], name = arr[1]=="Null"? "NotDefined":arr[1], age = arr[2] };
                list.Add(content);

            }
            list.ForEach(x => Console.WriteLine($"{x.id},{x.name},{x.age}"));
            Console.ReadLine();

        }
       
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PrintContentOFTXTFile
{
    class Program
    {
        static void Main(string[] args)
        {   //Read A FIle in C#
            string filepath = @"C:\swabhav\xyz.txt";
            string[] show = File.ReadAllLines(filepath);          //Read A File
            foreach (string j in show)
            {
                Console.WriteLine(j);
            }

            //Write to afile in C#
            string path = @"C:\swabhav\CsharpCreatedfile.txt";     //Path
            string filename = "CsharpCreatedfile.txt";
            string[] Content = {"Hello All","Mahesh Chand", "Allen O'Neill", "David McCarter",
"Raj Kumar", "Dhananjay Kumar"};                                  //Content
             File.WriteAllLines(path, Content);                    //Create a file

            //Adding a new Line In Created File
            String[] fileToChange = File.ReadAllLines(@"C:\swabhav\CsharpCreatedfile.txt");
            string newLine = "Hello i changing the content";
            int previousfileSize = fileToChange.Length;
            Console.WriteLine(previousfileSize);
            string[] newContent= new string[previousfileSize +5];
            int i = 0;
            for(; i < previousfileSize; i++)
            {
                newContent[i] = Content[i];
            }
            Console.WriteLine(i);
            newContent[i] = newLine;
            File.WriteAllLines(path, newContent);

            
            Console.ReadLine();

        }
    }
}

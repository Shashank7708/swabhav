using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferenceBetweenstructureANDClass
{
    class Program
    {   
        struct Book
        {
            public int id;
            public string name;
            public string author;

            public void Getdetails(int i,string n,string a)
            {
                id = i;
                name = n;
                author = a;
            }
        }
        static void Main(string[] args)
        {
            Book b1 = new Book();
            b1.Getdetails(101, "Legend Of Mehulas", "V.R.Shetty");
            Console.WriteLine(b1.author);
            Console.ReadLine();
        }
    }
}

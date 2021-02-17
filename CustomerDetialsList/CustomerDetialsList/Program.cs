using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace CustomerDetialsList
{
    class Program
    {
        static void Main(string[] args)
        {

            Customer[] customer = new Customer[4];
            customer[0] = new Customer("Amir", "Shaik", "Palghar", 101, "amirshaik@gmail.com" );
            customer[1] = new Customer( "Baban","Singh","Vasai",102,"babansingh@gmail.com" );
            customer[2] = new Customer("Catrine","Dsouza","Bhyandar",103, "catrine@gmail.com" );
            customer[3] = new Customer("Catrine",  "Dsouza","Bhyandar", 103,"catrine@gmail.com");

            List<Customer> customerlist = new List<Customer>(4);
            foreach(Customer i in customer)
            {
                customerlist.Add(i);
            }
           
            customerlist.Sort((x, y) => x.lname.CompareTo(y.lname));
            foreach (Customer i in customerlist)
            {
                PrintDetails(i);
            }

            Console.WriteLine("After Removing Duplicate");
            for(int i = 0; i < customerlist.Count-1; i++)
            {
                for(int j = i + 1; j < customerlist.Count; j++)
                {
                    if (customerlist[i].phoneno == customerlist[j].phoneno)
                        customerlist.Remove(customerlist[j]);
                }
            }
            foreach (Customer i in customerlist)
            {
                PrintDetails(i);
            }
            Stream stream = File.Open("Customer.txt", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, customerlist);
            stream.Close();
            Console.ReadLine();

        }


        static void PrintDetails(Customer c)
        {
            Console.WriteLine("FirstName: {0}\tLastName: {1}",c.fname,c.lname);
            Console.WriteLine("Address: {0}\tPhoneno: {1}\tEmail: {2}\n", c.address, c.phoneno, c.email);
        }
    }
}

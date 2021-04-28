using System;
using EFCoreApp.Repository;
using EFCoreApp.Model;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace EFCoreApp
{
    class Program
    {
      

        static void Main(string[] args)
        {
            CompanyDbContext db = new CompanyDbContext();

            //  Student s1 = new Student {Fname = "Romy", LName = "Rajan", Class = "X", Div = 'A' };
            /*
                        Student shehan = new Student{ Fname = "Shehan",LName = "Shetty", Class = "XI",Div = 'B'};
                        bool insertShehan = InsertStudent(shehan,db);
                        Result(insertShehan);
                        Student dummy = new Student { Fname = "dummy", LName = "Dummy", Class = "XII", Div = 'B' };
                        bool insertDummy  = InsertStudent(dummy, db);
                        Result(insertDummy);

                        Student student1 = new Student{ Id = 1, LName = "George",Div = 'C'};
                        bool editResult = EditStudent(student1,db);
                        Result(editResult);

                        bool deleteResult =DeleteStudent(3, db);
                        Result(deleteResult);
            */
            Query(db);
            Console.WriteLine("Done");
            Console.ReadLine();
        }


        public static void Result(bool result)
        {
            if (result)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Transaction Successfull");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Transaction UnSuccessfull");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }


        //Insert Student In Database
        private static bool InsertStudent(Student student,CompanyDbContext companyDbContext)
        {
            CompanyDbContext db = companyDbContext;
            db.Students.Add(student);
            db.SaveChanges();
            return true;
        }

        //Delete Student in Database
        private static bool DeleteStudent(int id, CompanyDbContext companyDbContext)
        {
            CompanyDbContext db = companyDbContext;
            var student = db.Students.FirstOrDefault(x => x.Id == id);
            if (student != null)
            {
                db.Students.Remove(student);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        //Update Student in Database
       private static bool EditStudent(Student student, CompanyDbContext companyDbContext)
        {
            CompanyDbContext db = companyDbContext;
            var student1 = db.Students.FirstOrDefault(x => x.Id == student.Id);
            if (student1 != null) {
                if (student.Fname != null)
                {
                    student1.Fname = student.Fname;
                }
                if (student.LName != null)
                {
                    student1.LName = student.LName;
                }
                if (student.Class != null)
                {
                    student1.Class = student.Class;
                }
                if (student.Div != 0)
                {
                    student1.Div = student.Div;
                }
                
                db.SaveChanges();
                return true;
            }
            return false;
        }


        private static void Query(CompanyDbContext companyDbContext)
        {
            CompanyDbContext db = companyDbContext;
            //Get All Students

            List<Student> students = (from student in db.Students
                                     select student).ToList<Student>();
            foreach(var student in students)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();
            

        }

    }
}

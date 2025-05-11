
namespace Generic_Method_Eg
{

    internal class Person<T> where T : class
    { 
        public T FirstName { get; set; }
        public T LastName { get; set; }
        public Person(T FirstName, T LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

    }

    delegate IEnumerable<T> DelegateOdd<T>(IEnumerable<T> list);
    internal class Program
    {
        
        static void Main(string[] args)
        {
            List<int> myList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            //Pointing delegate a function
            DelegateOdd<int> dele = Odd;
            var list1 = dele(myList);

            //var oddno=
            //Get Odd No
            //2nd I have use delegate version 1 which uses delegate keyword
            var odd = Filter<int>(myList, delegate (int i)
            {
                if (i % 2 != 0)
                    return true;
                return false;
            });

            ///here 2nd parameter is also a delegate which used arrow 
            var even = Filter(myList, i => i % 2 == 0);

            Console.WriteLine("Odd");
            foreach(int i in odd)
            {
                Console.WriteLine(i); 
            }

            Console.WriteLine("Even");
            foreach(int i in even)
            {
                Console.WriteLine(i);
            }


            List<Person<string>> people = new List<Person<string>> { new Person<string>("Andrew", "p1"), new Person<string>("Abbey", "p2"), new Person<string>("Jemmy", "p3") };
            //Basic Code
            var peopleNameStartWithA = new List<Person<string>>();
            foreach(Person<string> p in people)
            {
                if (p.FirstName.Length > 0 && p.FirstName.ToLower()[0] == 'a')
                    peopleNameStartWithA.Add(p);
            }


            ///using Filter method created
            var peopleNameStartWithAUsingFilter = Filter<Person<string>>(people, i => i.FirstName.Length > 0 && i.FirstName.ToLower()[0] == 'a');
            Console.WriteLine("Name Of people Starting with P");
            foreach(Person<string> p in peopleNameStartWithAUsingFilter)
            {
                Console.WriteLine(p.FirstName);
            }



            Console.Read();
        }

        //Generic Method
        static IEnumerable<TResult> ABC<TSource,TResult>(IEnumerable<TSource> source,Func<TSource,TResult> projection)
        {
            foreach(TSource i in source)
            {
                yield return projection(i);
                   
            }
        }

        //Generic Method
        static IEnumerable<T> Filter<T>(IEnumerable<T> source,Func<T,bool> predicate) 
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }

        }
         static IEnumerable<int>  Odd(IEnumerable<int> value)
        {
            foreach (int i in value)
            {
                if (i % 2 == 0) 
                   yield return i;

            }
        }




    }
}

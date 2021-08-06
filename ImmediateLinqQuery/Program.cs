using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmediateLinqQuery
{
    class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var empList = new List<Employee>(
                    new Employee[]
                    {
                        new Employee{ ID = 1, Name = "Sid", Age = 21},
                        new Employee { ID = 2, Name = "Jack", Age = 27},
                        new Employee { ID = 3, Name = "Akira", Age = 29},
                        new Employee { ID = 4, Name = "Barbara", Age = 31},
                        new Employee { ID = 5, Name = "James", Age = 28}
                    }
                );

            var lst = (from e in empList
                      where e.Age > 27
                      select new { e.Name }).Count();

            empList.Add(new Employee { ID = 6, Name = "Bruce", Age = 29 });

            //Here when we want to return an singleton value Immediate Execution Query is preffered.
            //Because it is executed just once and the output will remain constant even if
            //we try to modify or add the elements.
            //Even after adding a new employee the count for age > 28 will be same
            //since it has already executed.
            Console.WriteLine("The total employees whose age is > 28 are "+lst);
            Console.ReadLine();
        }
    }
}

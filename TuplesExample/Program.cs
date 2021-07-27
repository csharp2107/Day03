using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuplesExample
{
    class Program
    {
        class Response
        {
            public int StatusCode { get; set; }
            public string Message { get; set; }
        }

        static void Main(string[] args)
        {
            Tuple<int, string> tuple1 = new Tuple<int, string>(200, "OK");
            var tuple2 = new 
                Tuple<int, int, int, int, int, int, int, Tuple<int> >
                (1, 2, 3, 4, 5, 6, 7, Tuple.Create(1));
            //tuple2.Item1 = 10;
            var tuple3 = new
                Tuple<int, int, int, int, int, int, int, Tuple<int, int>>
                (1, 2, 3, 4, 5, 6, 7, Tuple.Create(8,9));
            var person1 = (1, "John", "Smith"); // also tuple
            (int, string, string) person2 = (2, "Elvis", "Presley");

            // named tuple
            var person3 = (Id: 3, FirstName: "Anna", LastName: "Smith");
            Console.WriteLine($"{person3.Id} {person3.FirstName} {person3.LastName}");

            (int Id, string FirstName, string LastName) person4 = (2, "Elvis", "Presley");

            int personId = person4.Id;
            string fname = person4.FirstName;
            string lname = person4.LastName;

            (_, var _fname, var _lname) = person4;
            Console.WriteLine($"{_fname} {_lname}");

            

            var tuple4 = new Tuple<Tuple<int, int>, Tuple<int, int>>
                (Tuple.Create(1, 2), Tuple.Create(3, 4));
            Console.WriteLine($"{tuple4.Item1.Item2}");

            Console.ReadKey();

        }
    }
}

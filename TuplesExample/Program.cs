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
            

        }
    }
}

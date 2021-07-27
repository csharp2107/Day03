using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            MyIntStorage intStorage = new MyIntStorage();
            intStorage.Data = 123;

            MyStorage<string> myStorage1 = new MyStorage<string>();
            myStorage1.Data = "ABCDEF";

            MyStorage<double> myStorage2 = new MyStorage<double>();
            myStorage2.Data = 123.45;

            MyStorageWithKey<string, int> myStorageWithKey1 =
                new MyStorageWithKey<string, int>()
                {
                    key = "key",
                    value = 123
                };
            
            int a = 10, b = -10;
            Console.WriteLine($"before: a={a}, b={b}");
            SwapVar<int>(ref a, ref b);
            Console.WriteLine($"after: a={a}, b={b}");

            String s1 = "abc", s2 = "xyz";
            Console.WriteLine($"before: s1={s1}, s2={s2}");
            SwapVar<string>(ref s1, ref s2);
            Console.WriteLine($"before: s1={s1}, s2={s2}");
        }

        static void SwapVar<T>(ref T input1, ref T input2)
        {
            T temp = default(T);
            temp = input2;
            input2 = input1;
            input1 = temp;
        }
    }
}

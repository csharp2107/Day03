using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExample
{
    delegate T Operation<T>(T a, T b);
    class Program
    {
        static int Add(int a, int b)
        {
            return a + b;
        }

        static void Main(string[] args)
        {
            MyIntStorage intStorage = new MyIntStorage();
            intStorage.Data = 123;

            MyStorage<string> myStorage1 = new MyStorage<string>();
            myStorage1.Data = "ABCDEF";

            MyStorage<double> myStorage2 = new MyStorage<double>();
            myStorage2.Data = 123.45;

            MyStorageWithKey<int, string> myStorageWithKey1 =
                new MyStorageWithKey<int, string>()
                {
                    key = 1,
                    value = "ABCD"
                };
            
            int a = 10, b = -10;
            Console.WriteLine($"before: a={a}, b={b}");
            SwapVar<int>(ref a, ref b);
            Console.WriteLine($"after: a={a}, b={b}");

            String s1 = "abc", s2 = "xyz";
            Console.WriteLine($"before: s1={s1}, s2={s2}");
            SwapVar<string>(ref s1, ref s2);
            Console.WriteLine($"before: s1={s1}, s2={s2}");

            Operation<int> oper1 = new Operation<int>(Add);
            Console.WriteLine($"{oper1(2, 2)}");

            Operation<double> oper2 = new Operation<double>((x, y) => x + y);
            Console.WriteLine($"{oper2(1.23, -1.23)}");

            // use derivated interfaces
            IPersons<Employee> employees = new People<Employee>();
            employees.Add(new Employee() { 
                Id = 1, FirstName = "John", LastName = "Smith"
            });
            employees.Add(new Employee()
            {
                Id = 2,
                FirstName = "James",
                LastName = "Watt"
            });
            Console.WriteLine($"count:{employees.Count}, {employees.Get(1)}" );

            IPersons<User> users = new People<User>();
            users.Add(new User() { Id=1, Nickname="john1234" });
            users.Add(new User() { Id = 2, Nickname = "elvis123" });
            Console.WriteLine($"count:{users.Count}, {users.Get(0)}");

        }

        static void SwapVar<T>(ref T input1, ref T input2)
        {
            T temp = default(T);
            temp = input2;
            input2 = input1;
            input1 = temp;
        }

        static void SwapVar<T, U>(ref T input1, ref U input2) { }

        static void SwapVar<T, U, W>(ref T input1, ref U input2, ref W input3) { }
    }
}

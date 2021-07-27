using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExample
{
    public interface ICounter<T>
    {
        int Count { get; }
        T Get(int index);
    }

    public interface IPersons<T> : ICounter<T>
    {
        void Add(T item);
    }

    public class People<T> : IPersons<T>
    {
        private int size;
        private List<T> persons = new List<T>();

        public People()
        {
            size = 0;
        }

        public int Count { get { return size; } }

        public void Add(T person)
        {
            persons.Add(person);
            size++;
        }

        public T Get(int index)
        {
            return persons[index];
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{Id}, {FirstName} {LastName}";
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Nickname { get; set; }

        public override string ToString()
        {
            return $"{Id},  {Nickname}";
        }
    }

}

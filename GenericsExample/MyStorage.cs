using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExample
{
    class MyStorage<T>
    {
        protected T data;

        public T Data { get; set; }

        public void SetData(T _data)
        {
            this.data = _data;
        }

        public T GetData()
        {
            return data;
        }

        public bool Compare(T otherData)
        {
            return data.Equals(otherData);
        }
        
    }

    class MyDeriveStorage<T> : MyStorage<T>
    {
        public MyDeriveStorage(T _data)
        {
            data = _data;
        }
    }

    class MyIntStorage : MyStorage<int>
    {

    }

    class MyStorageWithKey<TKey, TValue>
        where TKey : struct
        where TValue : class
    {
        public TKey key;
        public TValue value; 
    }
}

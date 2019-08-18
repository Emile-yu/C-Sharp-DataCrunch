using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_Sharp
{
    class List_Collection<T>
    {
        private List<T> l;
        public List_Collection() {
            l = new List<T>();
        }

        public void Add(T t) {
            l.Add(t);
        }

        public void Insert(int index, T t) {
            l.Insert(index, t);
        }

        public void Remove(T t) {
            l.Remove(t);
        }
        public void Remove_Index(int index) {
            l.RemoveAt(index);
        }

        public bool Exist(T t) {
            return l.Contains(t);
        }
        public void List_Show()
        {
            foreach (T a in l) {
                Console.WriteLine(a);
            }
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_Sharp
{
    class Dictionary_Collection<K,V>
    {
        private Dictionary<K, V> d;
        public Dictionary_Collection() {
            d = new Dictionary<K, V>();
        }

        public void Add(K k, V v) {
            d.Add(k, v);
        }

        public void Remove_key(K k) {
            d.Remove(k);
        }

        public bool Exist_key(K k) {
            return d.ContainsKey(k);
        }

        public bool Exist_value(V v) {
            return d.ContainsValue(v);
        }

        public void Show_key() {
            foreach (K k in d.Keys) {
                Console.WriteLine(k);
            }
        }

        public void Show_value() {
            foreach (V v in d.Values) {
                Console.WriteLine(v);
            }
        }

        public void Show_pair() {
            foreach (KeyValuePair<K, V> pair in d) {
                Console.WriteLine("{0},{1}", pair.Key, pair.Value);  
            }
        }
    }
}

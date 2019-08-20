﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GLRouteFinder
{
    /// <summary>
    /// High Priority with least estimated cost out of all path under consideration.
    /// </summary>
    /// <typeparam name="P"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class PriorityQueue<P, V> : IEnumerable
    {
        private SortedDictionary<P, Queue<V>> list = new SortedDictionary<P, Queue<V>>();
        
        public void Enqueue(P priority, V value)
        {
            Queue<V> q;

            if(!list.TryGetValue(priority, out q))
            {
                q = new Queue<V>();

                list.Add(priority, q);
            }

            q.Enqueue(value);
        }

        public V Dequeue()
        {
            // will throw if there isn’t any first element!
            var pair = list.First();

            var v = pair.Value.Dequeue();
            
            if(pair.Value.Count == 0) // nothing left of the top priority.
                list.Remove(pair.Key);
            
            return v;
        }

        public bool IsEmpty
        {
            get { return !list.Any(); }
        }

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        #endregion
    }

}

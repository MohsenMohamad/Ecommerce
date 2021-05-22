using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Version1.domainLayer.DataStructures
{
    public class Node<T1,T2> : IEnumerable<Node<T1,T2>>
    {

        internal T1 Key;
        internal T2 Value;
        private List<Node<T1,T2>> Children;
        
        
        public Node(T1 key ,T2 value)
        {
            Key = key;
            Value = value;
            Children = new List<Node<T1,T2>>();
        }

        public void AddNode(T1 key, T2 value)
        {
            Children.Add(new Node<T1,T2>(key,value));
        }

        public bool DeleteNode(T1 key)
        {
            if (Key.Equals(key))
                return true;
            
            foreach (var child in Children.ToList())
            {
                if (child.DeleteNode(key))
                    return Children.Remove(child);
            }

            return false;
        }

        public Node<T1,T2> GetNode(T1 key)
        {
            if (Key.Equals(key))
                return this;

            foreach (var child in Children)
            {
                var childResult = GetNode(key);
                if (childResult != null) return childResult;
            }

            return null;
        }
        
        public IEnumerator<Node<T1,T2>> GetEnumerator()
        {
            return Children.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
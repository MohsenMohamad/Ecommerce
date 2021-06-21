using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLogic.DataAccessLayer.DataStructures
{
    public class Node<T1, T2> : IEnumerable<Node<T1, T2>>
    {
        internal T1 Key;
        internal T2 Value;
        public List<Node<T1, T2>> Children;


        public Node(T1 key, T2 value)
        {
            Key = key;
            Value = value;
            Children = new List<Node<T1, T2>>();
        }

        public void AddNode(T1 key, T2 value)
        {
            Children.Add(new Node<T1, T2>(key, value));
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

        public Node<T1, T2> GetNode(T1 key)
        {
            if (Key.Equals(key))
                return this;

            foreach (var child in Children)
            {
                var childResult = child.GetNode(key);
                if (childResult != null) return childResult;
            }

            return null;
        }

        public List<T1> GetByValue(T2 value)
        {
            var result = new List<T1>();

            if (Value.Equals(value))
                result.Add(Key);
            foreach (var node in Children)
            {
                var childrenResults = node.GetByValue(value);
                result.AddRange(childrenResults);
            }

            return result;
        }

        public List<T1> GetNotNull()
        {
            var result = new List<T1>();

            if (!Value.Equals(-1))
                result.Add(Key);
            foreach (var node in Children)
            {
                var childrenResults = node.GetNotNull();
                result.AddRange(childrenResults);
            }

            return result;
        }

        public IEnumerator<Node<T1, T2>> GetEnumerator()
        {
            return Children.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool IsParent(T1 key)
        {
            return GetNode(key) != null;
        }
    }
}
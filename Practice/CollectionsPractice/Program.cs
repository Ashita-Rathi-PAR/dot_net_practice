using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionsPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList array_list = new ArrayList();
            array_list.Add(1);
            array_list.Add("C#");
            array_list.Add(" ");
            array_list.Add(true);
            array_list.Add(2.1);
            array_list.Add(null);

            //Adding another collection like queue, list, array list in Arraylist
            Queue myQ = new Queue();
            myQ.Enqueue("Queue1");
            myQ.Enqueue("Queue2");
            array_list.AddRange(myQ);

            var array_list2 = new ArrayList() { 2, "C#2", " ", false, 8.9, null };
            array_list.AddRange(array_list2);

            Console.WriteLine("ArrayList:");
            for (int i = 0; i < array_list.Count; i++)
                Console.Write(array_list[i] + ", ");

            //foreach (var item in array_list2)
            //    Console.Write(item + ", ");


            List<int> l = new List<int>();
            l.Add(1);
            l.Add(3);
            l.Add(1);
            l.Add(4);
            l.Add(2);
            l.Add(7);
            l.Insert(1, 11);
            l.Remove(3);
            l.RemoveAt(2);
            Console.WriteLine(l.Count);
            Console.WriteLine("List");
            Console.WriteLine(l);
            Console.ReadLine();
            if (l.Contains(10))
            {
                Console.WriteLine(l[0]);
            }

            l.ForEach(num => Console.Write(num + ", "));

            Dictionary<int, string> num_names = new Dictionary<int, string>();
            num_names.Add(1, "One");
            num_names.Add(2, "Two");
            num_names.Add(3, "Three");
            Console.WriteLine("\nDict");
            Console.WriteLine(num_names);

            foreach (KeyValuePair<int, string> kvp in num_names)
                Console.WriteLine("Key: {0}, Value: {1}", kvp.Key, kvp.Value);

            if (num_names.ContainsKey(1))
            {
                num_names.Remove(1);
            }


            Console.WriteLine("Hashtable:");
            Hashtable hash_names = new Hashtable();
            hash_names.Add(1, "One");
            hash_names.Add(2, "Two");
            hash_names.Add(3, "Three");

            foreach (DictionaryEntry de in hash_names)
                Console.WriteLine("Key: {0}, Value: {1}", de.Key, de.Value);

            Console.WriteLine("Stack:");
            Stack<int> myStack = new Stack<int>();
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            myStack.Push(4);

            foreach (var item in myStack)
                Console.Write(item + ",");


            Console.WriteLine("Tuple:");
            Tuple<int, string, string> t = new Tuple<int, string, string>(1, "T1", "T2");
            Console.WriteLine(t.Item1 + t.Item2 + t.Item3);
        }
    }
}

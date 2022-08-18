using System;
using System.Collections.Generic;

namespace FileHandlingUsingGenerics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose:\n1. JSON\n2. XML");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    List<Item> items = JsonFileReader.JSONRead<Item>(@"C:\Users\rathia\file.json");
                    foreach (var i in items)
                    {
                        Console.WriteLine("a=" + i.a + " b=" + i.b + " c=" + i.c);
                    }
                    break;
                case 2:
                    List<XmlItem> xml_items = XmlFileReader.XMLRead<XmlItem>(@"C:\Users\rathia\file.xml");
                    foreach (var i in xml_items)
                    {
                        Console.WriteLine("xa=" + i.xa + " xb=" + i.xb + " xc=" + i.xc);
                    }
                    break;
            }
            Console.ReadLine();
        }
    }

    public class Item
    {
        public int a { get; set; }
        public string b { get; set; }
        public float c { get; set; }
    }

    public class XmlItem
    {
        public int xa { get; set; }
        public string xb { get; set; }
        public float xc { get; set; }
    }

    public class JsonFileReader
    {
        public static List<T> JSONRead<T>(string filePath)
        {
            List<T> items = new List<T>();
            foreach (var e in new ChoETL.ChoJSONReader<T>(filePath))
            {
                items.Add(e);
            }
            return items;
        }
    }
    public class XmlFileReader
    {
        public static List<T> XMLRead<T>(string filePath) where T : class
        {
            List<T> xmlitems = new List<T>();
            foreach (var e in new ChoETL.ChoXmlReader<T>(filePath))
            {
                xmlitems.Add(e);
            }
            return xmlitems;
        }

    }
}


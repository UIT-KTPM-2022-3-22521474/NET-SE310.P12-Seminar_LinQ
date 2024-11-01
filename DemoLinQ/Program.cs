using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml.Linq;

namespace DemoLinQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. LINQ to Objects");
                Console.WriteLine("2. LINQ to SQL");
                Console.WriteLine("3. LINQ to Entities");
                Console.WriteLine("4. LINQ to DataSets");
                Console.WriteLine("5. LINQ to XML");
                Console.WriteLine("6. Exit");
                Console.Write("Please choose an option: ");

                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        DemoLINQToObjects();
                        break;
                    case 2:
                        DemoLINQToSQL();
                        break;
                    case 3:
                        DemoLINQToEntities();
                        break;
                    case 4:
                        DemoLINQToDataSets();
                        break;
                    case 5:
                        DemoLINQToXML();
                        break;
                    case 6:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        static void DemoLINQToObjects()
        {
            string[] words = { "hello", "wonderful", "LINQ", "beautiful", "world" };
            var shortWords = from word in words
                             where word.Length <= 5
                             select word;

            Console.WriteLine("LINQ to Objects - Words with length less than or equal to 5:");
            foreach (var word in shortWords)
            {
                Console.WriteLine(word);
            }
        }

        static void DemoLINQToSQL()
        {
            Console.WriteLine("LINQ to SQL - Demo (Illustration only, requires database configuration).");
            Console.WriteLine("An example LINQ to SQL query would require a real SQL database setup.");
        }

        static void DemoLINQToEntities()
        {
            Console.WriteLine("LINQ to Entities - Demo (Illustration only, requires Entity Framework).");
            Console.WriteLine("An example LINQ to Entities query would require a real Entity Framework setup with a database.");
        }

        static void DemoLINQToDataSets()
        {
            DataSet dataSet = new DataSet();
            DataTable table = new DataTable("Students");
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Rows.Add(1, "Alice");
            table.Rows.Add(2, "Bob");
            table.Rows.Add(3, "Charlie");
            dataSet.Tables.Add(table);

            var students = from student in dataSet.Tables["Students"].AsEnumerable()
                           where student.Field<int>("ID") > 1
                           select student.Field<string>("Name");

            Console.WriteLine("LINQ to DataSets - Students with ID greater than 1:");
            foreach (var name in students)
            {
                Console.WriteLine(name);
            }
        }

        static void DemoLINQToXML()
        {
            XElement studentsXml = new XElement("Students",
                new XElement("Student", new XAttribute("ID", 1), new XElement("Name", "Alice")),
                new XElement("Student", new XAttribute("ID", 2), new XElement("Name", "Bob")),
                new XElement("Student", new XAttribute("ID", 3), new XElement("Name", "Charlie"))
            );

            var studentNames = from student in studentsXml.Elements("Student")
                               where (int)student.Attribute("ID") > 1
                               select student.Element("Name").Value;

            Console.WriteLine("LINQ to XML - Students with ID greater than 1:");
            foreach (var name in studentNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}

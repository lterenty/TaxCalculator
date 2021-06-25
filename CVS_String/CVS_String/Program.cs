using System;
using System.IO;
using System.Net;
using System.Data;
using System.Collections.Generic;

namespace CVS_String
{
    class Program
    {
        static void Main(string[] args)
        {

            
            Console.Write("Enter filter: ");
            string val = Console.ReadLine();
            string file = File.ReadAllText("/Users/alexsherman/Projects/CVS_String/CVS_String/test.csv");
           
            string[] lines = file.Split(new string[] { "\\n" }, StringSplitOptions.RemoveEmptyEntries);
            decimal Total = 0;

            var dataObjects = new List<DataObject>();
           

            for (int i = 0; i < lines.Length; i++)
            {
                DataObject dataObj= new DataObject(lines[i]);
                dataObjects.Add(dataObj);
            }
            for(int i = 0; i<dataObjects.Count; i++)
            {
                //if (dataObjects[i].LastName.Contains(val))
                //{
                //    Total = dataObjects[i].TransactionAmount++;
                //    Console.WriteLine(dataObjects[i]);
                //}
                if (dataObjects[i].TransactionDate > DateTime.Parse(val))
                {
                    Total = dataObjects[i].TransactionAmount++;
                    Console.WriteLine(dataObjects[i]);
                }
            }

            Console.WriteLine("Total:" + Total);
        }
    }
}
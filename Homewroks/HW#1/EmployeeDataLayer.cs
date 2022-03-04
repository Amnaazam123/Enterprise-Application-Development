using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using BusinessObjects;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DataAccessLayer
{
    public class EmpolyeeDataLayer
    {
        public void TakeData(EmployeeBusinessObjects EBO)
        {
            string data = JsonSerializer.Serialize(EBO);

            StreamWriter sw = new StreamWriter("myFile.txt", append:true);
            sw.WriteLine(data);
            sw.Close();
           
        }
        public List<EmployeeBusinessObjects> readData()
        {
            List<EmployeeBusinessObjects> list = new List<EmployeeBusinessObjects>(); 
            Console.WriteLine("\n\n-------------------After reading from file-------------\n");
            FileStream f = new FileStream("myFile.txt", FileMode.Open);
            StreamReader sr = new StreamReader(f);
            string s = sr.ReadLine();
            while (s != null)
            {
                EmployeeBusinessObjects info = JsonSerializer.Deserialize<EmployeeBusinessObjects>(s);
                list.Add(info);
                s = sr.ReadLine();
            }

            sr.Close();
            f.Close();

            return list;

        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            
            string inputFilePath = System.AppDomain.CurrentDomain.BaseDirectory + "input.csv"; 
            string outputDirectory = System.AppDomain.CurrentDomain.BaseDirectory + "output"; 
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            
            string[] lines = File.ReadAllLines(inputFilePath);
            List<User> records = new List<User>();
            foreach (string line in lines.Select(x => x.Replace(@"""", "")).Skip(1)) 
            {
                string[] parts = line.Split(',');
                User record = new User
                {
                    UserId = parts[0],
                    FirstName = parts[1],
                    LastName = parts[2],
                    Version = int.Parse(parts[3]),
                    InsuranceCompany = parts[4]
                };
                records.Add(record);
            }

            
            var groups = records.GroupBy(r => r.InsuranceCompany);
            foreach (var group in groups)
            {
               
                var sortedRecords = group.OrderBy(r => r.LastName).ThenBy(r => r.FirstName).ThenByDescending(r => r.Version);

                var uniqueRecords = new Dictionary<string, User>();
                foreach (var record in sortedRecords)
                {
                    if (!uniqueRecords.ContainsKey(record.UserId))
                    {
                        uniqueRecords.Add(record.UserId, record);
                    }
                }

                string outputFile = Path.Combine(outputDirectory, $"{group.Key}_enrollment.csv");
                using (StreamWriter writer = new StreamWriter(outputFile))
                {
                    writer.WriteLine("User Id,First Name,Last Name,Version,Insurance Company");
                    foreach (var record in uniqueRecords.Values)
                    {
                        writer.WriteLine($"{record.UserId},{record.FirstName},{record.LastName},{record.Version},{record.InsuranceCompany}");
                    }
                }
            }

            Console.WriteLine("Files processed successfully.");
        }
    }
    class User
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Version { get; set; }
        public string InsuranceCompany { get; set; }
    }
}

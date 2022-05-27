using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdPartyLibrary
{
    public class CsvHandler
    {
        const string IMPORT_FILEPATH = @"D:\PracticeProblem\ThirdPartyLibrary\ThirdPartyLibrary\addressbook.csv";
        const string EXPORT_FILEPATH = @"D:\PracticeProblem\ThirdPartyLibrary\ThirdPartyLibrary\Export.csv";
        const string EXPORT_JSON_FILEPATH = @"D:\PracticeProblem\ThirdPartyLibrary\ThirdPartyLibrary\AddressDetail.json";
        public void ImplementationCsv()
        {
            using (var reader = new StreamReader(IMPORT_FILEPATH))
            {
                using (var csv = new CsvReader(reader,CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<Address>().ToList();
                    Console.WriteLine("After Reading CSV File");
                    foreach (var data in records)
                    {
                        Console.WriteLine(data.FirstName + " " + data.LastName + " " + data.Email + " " + data.AddressDetail + " " + data.City + " " + data.State + " " + data.Code);
                    }
                    using (var writter = new StreamWriter(EXPORT_FILEPATH))
                    {
                        using (var csvExport = new CsvWriter(writter, CultureInfo.InvariantCulture))
                        {
                            csvExport.WriteRecords(records);
                        }
                    }
                }
            }
        }
        public void ImplementationJson()
        {
            using (var reader = new StreamReader(IMPORT_FILEPATH))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<Address>().ToList();
                    Console.WriteLine("After Reading CSV File");
                    foreach (var data in records)
                    {
                        Console.WriteLine(data.FirstName + " " + data.LastName + " " + data.Email + " " + data.AddressDetail + " " + data.City + " " + data.State + " " + data.Code);
                    }
                    JsonSerializer serializer = new JsonSerializer();
                    using (var writter = new StreamWriter(EXPORT_JSON_FILEPATH))
                    {
                        using (var writer = new JsonTextWriter(writter))
                        {
                            serializer.Serialize(writter,records);
                        }
                    }
                }
            }
        }
    }
}

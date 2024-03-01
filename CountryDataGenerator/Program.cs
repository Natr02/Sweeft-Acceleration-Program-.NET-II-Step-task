//მოცემულია Countries REST API ის მისამართი: https://restcountries.com/v3.1/all,
//რომელიც აბრუნებს ინფორმაციას ქვეყნების შესახებ. დაწერეთ ფუნქცია,
//რომელიც ყოველი ქვეყნისთვის შექმნის ტექსტურ დოკუმენტს (.txt) სახელად
//{ქვეყნის_სახელი.txt}. თითოეულ დოკუმენტში უნდა იყოს შევსებული ქვეყნის
//“region”, “subregion”, “latlng”, “area” და “population” ველები.
//void GenerateCountryDataFiles();

using System;
using System.IO;
using System.Net;
using System.Text;
using CountryDataGenerator.Classes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

class Program
{
    static void Main()
    {
        GenerateCountryDataFiles();
    }

    static void GenerateCountryDataFiles()
    {
        try
        {

            // URL for the countries API
            string apiUrl = "https://restcountries.com/v3.1/all";

            // Download the JSON data from the API               
            string json = new WebClient().DownloadString(apiUrl);            

            //deserialization
            List<Country> cityList = JsonConvert.DeserializeObject<List<Country>>(json);
            //file creation
            foreach (Country item in cityList)
            {
                string path = @"C:\Users\Admin\OneDrive\Desktop\g\demo-repo\CountryDataGenerator\CountryDataGenerator\GeneratedFiles\";
                string filename = $"{path}{item.name.common}.txt";
                string filecontent = item.ToString();
                if (File.Exists(filename))
                    File.Delete(filename);

                using (FileStream fs = File.Create(filename))
                {
                    Byte[] content = new UTF8Encoding(true).GetBytes(filecontent);
                    fs.Write(content, 0, content.Length);
                }
                //Console.WriteLine(item);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error:{ex.Message}");
        }
        finally
        {
            Console.WriteLine("Files have already created!");
        }
    }
}

using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace MyPractice;
public class MyCsvDataWorker
{
    public static IEnumerable<ProductsSales> CsvRead(string path){
        using(var sw = new StreamReader(path)){
            var config = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = "," };
            using(var csv = new CsvReader(sw, config)){
                return csv.GetRecords<ProductsSales>().ToList();
            }
        }
    }
    public static void CsvWrite(string path, IEnumerable<dynamic> data){
        using(var sw = new StreamWriter(path)){
            var config = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = "," };
            using(var csv = new CsvWriter(sw, config)){
                csv.WriteRecords(data);
            }
        }
    }
}


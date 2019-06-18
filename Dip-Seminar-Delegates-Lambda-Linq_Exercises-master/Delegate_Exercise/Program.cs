using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using FileParserNetStandard;

public delegate List<List<string>> Parser(List<List<string>> data);

namespace Delegate_Exercise {
 
    
    internal class Delegate_Exercise {

        public static string csvPath = "C:/Users/Owner/Documents/Diploma Weekly Task 11/Dip-Seminar-Delegates-Lambda-Linq_Exercises-master/Files/myData.csv";
        public static string tsvPath = "C:/Users/Owner/Documents/Diploma Weekly Task 11/Dip-Seminar-Delegates-Lambda-Linq_Exercises-master/Files/data.tsv";
        public static string writeFile = "C:/Users/Owner/Documents/Diploma Weekly Task 11/Dip-Seminar-Delegates-Lambda-Linq_Exercises-master/Files/dataWrite.txt";
        public static void Main(string[] args) {

            FileHandler fh = new FileHandler();
            DataParser dp = new DataParser();
            List<string> newFile = fh.ReadFile(csvPath);
            List<List<string>> Kellogs = fh.ParseCsv(newFile);

            Func<List<List<string>>, List<List<string>>> dataHandler = new Func<List<List<string>>, List<List<string>>>(dp.StripWhiteSpace);
            dataHandler += dp.StripHashtags;
            dataHandler += dp.StripQuotes;

            Kellogs = dataHandler(Kellogs);

            fh.WriteFile(writeFile, ',', Kellogs);
          

        }   
    }
}
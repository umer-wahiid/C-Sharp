using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration.Assemblies;
using System.Configuration;
using System.Xml;
using System.Data.SqlClient;
using System.IO;
using Microsoft.VisualBasic.FileIO;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var Csv = new CSVGenerator();
            Csv.Generate();
            
            var imp = new CSVImporter();
            imp.ImportData();
        }
    }
}

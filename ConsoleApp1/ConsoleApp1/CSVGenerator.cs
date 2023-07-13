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
using System.Net;
using System.Net.Mail;

namespace ConsoleApp1
{
    class CSVGenerator
    {
        public void Generate()
        {
            string connectionString = ConfigurationManager.AppSettings["Con"];
            string tableName = ConfigurationManager.AppSettings["TName"];
            string csvFilePath = ConfigurationManager.AppSettings["PathCSV"];
            List<string> selectedColumns = new List<string>() { "UName", "UEmail"};
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();


                    using (SqlCommand command = new SqlCommand("Sp_Select", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters to the command
                        command.Parameters.AddWithValue("@StartDate", "2023-7-11");
                        command.Parameters.AddWithValue("@EndDate", "2023-7-12");
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            DataTable table = new DataTable();
                            table.Load(reader);


                            bool fileExists = File.Exists(csvFilePath + tableName + "2.csv");


                            if (!fileExists)
                            {
                                using (StreamWriter writer = new StreamWriter(csvFilePath+tableName+"2.csv"))
                                {

                                    // Write the column headers
                                    foreach (DataColumn column in table.Columns)
                                    {
                                        writer.Write(column.ColumnName);
                                        writer.Write(",");
                                    }
                                    writer.WriteLine();

                                    // Write the data rows
                                    foreach (DataRow row in table.Rows)
                                    {
                                        foreach (var item in row.ItemArray)
                                        {
                                            writer.Write(item);
                                            writer.Write(",");
                                        }
                                        writer.WriteLine();
                                    }
                                    Console.WriteLine("CSV file Generated successfully.");
                                }
                            }
                            else
                            {
                                int existingRowCount = File.ReadLines(csvFilePath + tableName + "2.csv").Count();

                                using (StreamWriter writer = new StreamWriter(csvFilePath + tableName + "2.csv", true))
                                {
                                    int newRowCount = 0;

                                    foreach (DataRow row in table.Rows)
                                    {
                                        if (newRowCount >= existingRowCount)
                                        {
                                            string rowString = string.Join(",", row.ItemArray);
                                            writer.WriteLine(rowString);
                                        }

                                        newRowCount++;
                                    }
                                }

                                Console.WriteLine("CSV file updated successfully.");
                                //using (StreamWriter writerr = new StreamWriter(csvFilePath + tableName + "2.csv", true))
                                //{
                                //    // Write the data rows
                                //    foreach (DataRow row in table.Rows)
                                //    {
                                //        foreach (var item in row.ItemArray)
                                //        {
                                //            writerr.Write(item);
                                //            writerr.Write(",");
                                //        }
                                //        writerr.WriteLine();
                                //    }
                                //    Console.WriteLine("CSV file updated successfully.");
                                //}
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);

                var Mail = new Mail();
                Mail.EMail(ex);
            }

            Console.ReadLine();
        }
    }
}
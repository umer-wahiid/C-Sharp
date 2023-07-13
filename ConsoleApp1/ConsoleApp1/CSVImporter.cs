using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Linq;

namespace ConsoleApp1
{
    class CSVImporter
    {
        public void ImportData()
        {
            string connectionString = ConfigurationManager.AppSettings["Con"];
            string tableName = "Test6";
            string csvFilePath = ConfigurationManager.AppSettings["Path"];

            try
            {
                // Establish database connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Check if the table exists
                    bool tableExists;
                    using (SqlCommand tableExistsCommand = new SqlCommand($"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{tableName}'", connection))
                    {
                        tableExists = (int)tableExistsCommand.ExecuteScalar() > 0;
                    }

                    // Read the CSV file
                    using (StreamReader reader = new StreamReader(csvFilePath))
                    {
                        string line;
                        if ((line = reader.ReadLine()) != null)
                        {
                            string[] columns = line.Split(',');

                            // Create table and columns if they don't exist
                            if (!tableExists)
                            {
                                string createTableQuery = GetCreateTableQuery(tableName, columns);
                                using (SqlCommand createTableCommand = new SqlCommand(createTableQuery, connection))
                                {
                                    createTableCommand.ExecuteNonQuery();
                                }
                            }

                            // Prepare the SQL INSERT statement
                            string insertQuery = GetInsertQuery(tableName, columns);

                            while ((line = reader.ReadLine()) != null)
                            {
                                string[] fields = line.Split(',');

                                // Execute the SQL statement
                                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                                {
                                    for (int i = 0; i < fields.Length; i++)
                                    {
                                        command.Parameters.AddWithValue($"@param{i}", fields[i]);
                                    }

                                    command.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    using (SqlCommand countCommand = new SqlCommand($"SELECT COUNT(*) FROM {tableName}", connection))
                    {
                        int rowCount = (int)countCommand.ExecuteScalar();
                        Console.WriteLine(tableName+" has " + rowCount+" Records");
                    }
                    using (SqlCommand columnNamesCommand = new SqlCommand($"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'", connection))
                    using (SqlDataReader reader = columnNamesCommand.ExecuteReader())
                    {
                        Console.WriteLine("Columns Includes :");
                        while (reader.Read())
                        {
                            string columnName = reader.GetString(0);
                            Console.WriteLine(columnName);
                        }
                    }
                }
                Console.WriteLine("Data inserted successfully in : "+tableName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            Console.ReadLine();
        }

        private string GetCreateTableQuery(string tableName, string[] columns)
        {
            string columnDefinitions = string.Join(", ", columns.Select(column => $"{column} NVARCHAR(100)"));
            return $"CREATE TABLE {tableName} ({columnDefinitions})";
        }

        private string GetInsertQuery(string tableName, string[] columns)
        {
            string columnNames = string.Join(", ", columns);
            string valuePlaceholders = string.Join(", ", columns.Select((c, i) => $"@param{i}"));
            return $"INSERT INTO {tableName} ({columnNames}) VALUES ({valuePlaceholders})";
        }
    }
}
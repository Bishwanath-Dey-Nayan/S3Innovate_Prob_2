using System;
using System.Data.SqlClient;

namespace InsetToDB
{
    class Program
    {

       public static string constr = "Data Source=.;Initial Catalog=BuildingDataDB;Integrated Security=True";
        public static void Main()
        {
            using (SqlConnection connection = new SqlConnection(constr))
            {
                String query = "INSERT INTO dbo.Reading (BuildingId,ObjectId,DataFieldId,Value,Timestamp) VALUES (@Building,@Object,@DataField, @Val, @Time)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int value = 2000;
                    DateTime dt = Convert.ToDateTime(" 2020-09-18 06:50:00 am");
                    for(int i=0;i<30000;i++)
                    {
                        dt = dt.AddMinutes(5);
                        if(value>2500)
                        {
                            value = 2100;
                        }
                        value += 10;
                        command.Parameters.AddWithValue("@Building", 1);
                        command.Parameters.AddWithValue("@Object", 2);
                        command.Parameters.AddWithValue("@DataField", 2);
                        command.Parameters.AddWithValue("@Val", value);
                        command.Parameters.AddWithValue("@Time", dt);

                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        connection.Close();
                        command.Parameters.Clear();
                       

                        // Check Error
                        if (result < 0)
                            Console.WriteLine("Error inserting data into Database!");

                        Console.WriteLine(i+" -Ok");
                    }

                }
            }
        }
    }

}

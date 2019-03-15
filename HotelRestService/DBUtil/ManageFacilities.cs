using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HotelModel;

namespace HotelRestService.DBUtil
{
    public class ManageFacilities
    {
        //TODO Password is in the Assignment Doc, please input pw in line 13
        static string pw = "";
        static string connectionString = $"Data Source=jbsdbserver.database.windows.net;Initial Catalog=JBSDB;User ID=Fr0thgar;Password={pw};Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Facilities> GetAllFacilities()
        {
            List<Facilities> facilitiesList = new List<Facilities>();
            string queryString = "Select * FROM DemoFacilities";

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {

                        Facilities facilities = new Facilities();
                        facilities.Hotel_No = reader.GetInt32(0);
                        facilities.SwimmingPool = reader.GetBoolean(1);
                        facilities.TableTennis = reader.GetBoolean(2);
                        facilities.PoolTable = reader.GetBoolean(3);
                        facilities.Bar = reader.GetBoolean(4);
                        facilitiesList.Add(facilities);
                    }
                }
                finally
                {
                    reader.Close();
                }

                return facilitiesList;
            }
        }

        public Facilities GetFacilitiesFromId(int Hotel_No)
        {
            Facilities facilities = new Facilities();

            string queryString =
                "SELECT * FROM Demofacilities WHERE Hotel_No LIKE '" +
                Hotel_No + "'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                try
                {

                }
                finally
                {
                    reader.Close();
                }

                return facilities;
            }
        }

        public bool CreateFacility(Facilities facilities)
        {
            Facilities f = new Facilities();

            string queryString =
                $"INSERT INTO Demofacilities (Hotel_No, SwimmingPool, TableTennis, PoolTable, Bar)" +
                $"VALUES({facilities.Hotel_No}, {Convert.ToInt16(facilities.SwimmingPool)}, {Convert.ToInt16(facilities.TableTennis)}, {Convert.ToInt16(facilities.PoolTable)}, {Convert.ToInt16(facilities.Bar)})";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                try
                {
                    command.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }

                return true;
            }
        }

        public bool UpdateFacilities(Facilities facilities, int Hotel_No)
        {
            string queryString = $"UPDATE DemoFacilities " +
                                 $"SET SwimmingPool = {Convert.ToInt16(facilities.SwimmingPool)}, " +
                                 $"TableTennis = {Convert.ToInt16(facilities.TableTennis)}, " +
                                 $"PoolTable = {Convert.ToInt16(facilities.PoolTable)}, " +
                                 $"Bar = {Convert.ToInt16(facilities.Bar)} " +
                                 $"WHERE Hotel_No = {Hotel_No}";

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                try
                {
                    command.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }

                return true;
            }
        }

        public Facilities DeleteFacilities(int Hotel_No)
        {
            Facilities f = GetFacilitiesFromId(Hotel_No);
            string queryString =
                "DELETE FROM Demofacilities WHERE Hotel_No LIKE '" + Hotel_No +
                "'";

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                try
                {
                    command.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }

                return f;
            }
        }
    }
}
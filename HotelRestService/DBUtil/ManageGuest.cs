using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HotelModel;

namespace HotelRestService.DBUtil
{
    public class ManageGuest : IManageGuest
    {
        string connectionString =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HotelDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public List<Guest> GetAllGuest()
        {
            List<Guest> guestList = new List<Guest>();
            string queryString = "Select Guest_No,Name,Address FROM demoGuest";

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                //command.ExecuteNonQuery();

                try
                {
                    while (reader.Read())
                    {
                        Guest guest = new Guest();
                        guest.Guest_No = reader.GetInt32(0);
                        guest.Name = reader.GetString(1);
                        guest.Address = reader.GetString(2);
                        guestList.Add(guest);
                    }
                }
                finally
                {
                    reader.Close();
                }

                return guestList;
            }
        }

        public List<Guest> GetAllGuest(object guestList)
        {
            throw new NotImplementedException();
        }

        public Guest GetGuestFromId(int guestNr)
        {
            Guest guest = new Guest();

            string queryString = "SELECT * FROM demoguest WHERE Guest_NO LIKE '" + guestNr + "'";
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
                        guest.Guest_No = reader.GetInt32(0);
                        guest.Name = reader.GetString(1);
                        guest.Address = reader.GetString(2);
                    }
                }
                finally
                {
                    reader.Close();
                }
                return guest;
            }
        }

        public bool CreateGuest(Guest guest)
        {
            Guest g = new Guest();

            string queryString =
                $"INSERT INTO demoguest (Guest_No, Name, Address) " +
                $"VALUES ({guest.Guest_No}, '{guest.Name}', '{guest.Address}')";

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

        public bool UpdateGuest(Guest guest, int guestNr)
        {
            string queryString = $"UPDATE demoguest " +
                                 $"SET Guest_No = {guest.Guest_No}, Name = '{guest.Name}', Address = '{guest.Address}' " +
                                 $"WHERE Guest_No = {guestNr}";

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

        public Guest DeleteGuest(int guestNr)
        {
            Guest g = GetGuestFromId(guestNr);
            string queryString = "DELETE FROM demoguest WHERE Guest_No LIKE '" + guestNr + "'";

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
                return g;
            }
        }
    }
}
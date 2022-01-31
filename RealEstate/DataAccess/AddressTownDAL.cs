using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using RealEstate.Models;


namespace RealEstate.DataAccess
{
    public class AddressTownDAL
    {
        static private AddressTownDAL _Methods { get; set; }
        static public AddressTownDAL Methods
        {
            get
            {
                if (_Methods != null)
                    _Methods = new AddressTownDAL();
                return _Methods;
            }
        }

        public List<AddressTown> ListTown(string query)
        {
            List<AddressTown> towns = new List<AddressTown>();
            SqlCommand cmd = new SqlCommand(query, DbTools.Connection.con);
            IDataReader reader;
            try
            {
                DbTools.Connection.ConnectDB();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    towns.Add(new AddressTown()
                    {
                        ID = int.Parse(reader["ID"].ToString()),
                        Name = reader["Name"].ToString(),
                        CityID = int.Parse(reader["CityID"].ToString())
                    });
                }
            }
            catch
            {
                Console.WriteLine("HATA OLUŞTU");
            }
            finally
            {
                DbTools.Connection.DisconnectDB();
            }
            //List<AddressCountry> copyCountries = new List<AddressCountry>();
            return towns;
        }

       



    }
}
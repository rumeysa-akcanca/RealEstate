using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using RealEstate.Models;


namespace RealEstate.DataAccess
{
    public class AddressCityDAL
    {
        static private AddressCityDAL _Methods { get; set; }
        static public AddressCityDAL Methods
        {
            get
            {
                if (_Methods != null)
                    _Methods = new AddressCityDAL();
                return _Methods;
            }
        }

        
        public List<AddressCity> ListCity(string query)
        {
            List<AddressCity> cities = new List<AddressCity>();
            SqlCommand cmd = new SqlCommand(query, DbTools.Connection.con);
            IDataReader reader;
            try
            {
                DbTools.Connection.ConnectDB();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cities.Add(new AddressCity()
                    {
                        ID = int.Parse(reader["ID"].ToString()),
                        Name = reader["Name"].ToString(),
                        CountryID = int.Parse(reader["CountryID"].ToString())
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
            return cities;
        }



    }
}
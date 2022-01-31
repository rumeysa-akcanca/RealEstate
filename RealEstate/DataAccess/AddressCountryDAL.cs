using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using RealEstate.Models;


namespace RealEstate.DataAccess
{
    public class AddressCountryDAL
    {
        static private AddressCountryDAL _Methods { get; set; }
        static public AddressCountryDAL Methods
        {
            get
            {
                if (_Methods != null)
                    _Methods = new AddressCountryDAL();
                return _Methods;
            }
        }

        public List<AddressCountry> ListCountry(string query)
        {
            List<AddressCountry> countries = new List<AddressCountry>();
            SqlCommand cmd = new SqlCommand(query, DbTools.Connection.con);
            IDataReader reader;
            try
            {
                DbTools.Connection.ConnectDB();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    countries.Add(new AddressCountry()
                    {
                        ID = int.Parse(reader["ID"].ToString()),
                        Name = reader["Name"].ToString(),
                        Abbreviation = reader["Abbreviation"].ToString()
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
            return countries;
        }





    }
}
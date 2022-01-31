using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using RealEstate.Models;

namespace RealEstate.DataAccess
{
    public class DbTools
    {
        static string strConnection = ConfigurationManager.ConnectionStrings["RealEstate"].ConnectionString;
        public SqlConnection con = new SqlConnection(strConnection);
        private static DbTools _Con { get; set; }
        public static DbTools Connection
        {
            get
            {
                if (_Con == null)
                    _Con = new DbTools();
                return _Con;
            }
        }
        public bool ConnectDB()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }



        public bool DisconnectDB()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public object Create(string query)
        {
            SqlCommand cmd = new SqlCommand(query, con);
            object insertedID = -1;
            try
            {
                ConnectDB();
                insertedID = cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                Console.WriteLine("HATA LOGU Yaz.");
            }
            finally
            {
                DisconnectDB();
            }
            return insertedID;
        }
        public bool Execute(string query)
        {
            SqlCommand cmd = new SqlCommand(query, con);
            int affectedRows = -1;
            try
            {
                ConnectDB();
                affectedRows = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                DisconnectDB();
            }
            if (affectedRows > 0)
                return true;
            else
                return false;
        }



        //internal Role GetRoleByID(int roleid)
        //{
        //    Role role = new Role();
        //    string query = $"SELECT * FROM Role WHERE ID = {roleid}";
        //    SqlCommand cmd = new SqlCommand(query, con);
        //    IDataReader reader;
        //    try
        //    {
        //        ConnectDB();
        //        reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            role.ID = int.Parse(reader["ID"].ToString());
        //            role.Name = reader["Name"].ToString();
        //            role.Level = byte.Parse(reader["Level"].ToString());
        //        }
        //    }
        //    catch
        //    {
        //        Console.WriteLine("HATA OLUŞTU");
        //    }
        //    finally
        //    {
        //        DisconnectDB();
        //    }
        //    return role;
        //}


        //public List<Role> ListRole(string query)
        //{
        //    List<Role> roles = new List<Role>();
        //    SqlCommand cmd = new SqlCommand(query, con);
        //    IDataReader reader;
        //    try
        //    {
        //        ConnectDB();
        //        reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            roles.Add(new Role()
        //            {
        //                ID = int.Parse(reader["ID"].ToString()),
        //                Name = reader["Name"].ToString(),
        //                Level = byte.Parse(reader["Level"].ToString())
        //            });
        //        }
        //    }
        //    catch
        //    {
        //        Console.WriteLine("HATA OLUŞTU");
        //    }
        //    finally
        //    {
        //        DisconnectDB();
        //    }
        //    return roles;
        //}

        //public List<AddressCountry> ListCountry(string query)
        //{
        //    List<AddressCountry> countries = new List<AddressCountry>();
        //    SqlCommand cmd = new SqlCommand(query, con);
        //    IDataReader reader;
        //    try
        //    {
        //        ConnectDB();
        //        reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            countries.Add(new AddressCountry()
        //            {
        //                ID = int.Parse(reader["ID"].ToString()),
        //                Name = reader["Name"].ToString(),
        //                Abbreviation = reader["Abbreviation"].ToString()
        //            });
        //        }
        //    }
        //    catch
        //    {
        //        Console.WriteLine("HATA OLUŞTU");
        //    }
        //    finally
        //    {
        //        DisconnectDB();
        //    }
        //    //List<AddressCountry> copyCountries = new List<AddressCountry>();
        //    return countries;
        //}

        //public List<AddressCity> ListCity(string query)
        //{
        //    List<AddressCity> cities = new List<AddressCity>();
        //    SqlCommand cmd = new SqlCommand(query, con);
        //    IDataReader reader;
        //    try
        //    {
        //        ConnectDB();
        //        reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            cities.Add(new AddressCity()
        //            {
        //                ID = int.Parse(reader["ID"].ToString()),
        //                Name = reader["Name"].ToString(),
        //                CountryID = int.Parse(reader["CountryID"].ToString())
        //            });
        //        }
        //    }
        //    catch
        //    {
        //        Console.WriteLine("HATA OLUŞTU");
        //    }
        //    finally
        //    {
        //        DisconnectDB();
        //    }
        //    //List<AddressCountry> copyCountries = new List<AddressCountry>();
        //    return cities;
        //}

        //public List<AddressTown> ListTown(string query)
        //{
        //    List<AddressTown> towns = new List<AddressTown>();
        //    SqlCommand cmd = new SqlCommand(query, con);
        //    IDataReader reader;
        //    try
        //    {
        //        ConnectDB();
        //        reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            towns.Add(new AddressTown()
        //            {
        //                ID = int.Parse(reader["ID"].ToString()),
        //                Name = reader["Name"].ToString(),
        //                CityID = int.Parse(reader["CityID"].ToString())
        //            });
        //        }
        //    }
        //    catch
        //    {
        //        Console.WriteLine("HATA OLUŞTU");
        //    }
        //    finally
        //    {
        //        DisconnectDB();
        //    }
        //    //List<AddressCountry> copyCountries = new List<AddressCountry>();
        //    return towns;
        //}
        //public List<User> ListUser(string query)
        //{
        //    List<User> users = new List<User>();
        //    SqlCommand cmd = new SqlCommand(query, con);
        //    IDataReader reader;
        //    try
        //    {
        //        ConnectDB();
        //        reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            users.Add(new User()
        //            {
        //                ID = int.Parse(reader["ID"].ToString()),
        //                FullName = reader["FullName"].ToString(),
        //                AddressID = int.Parse(reader["AddressID"].ToString()),
        //                Email = reader["Email"].ToString(),
        //                Password = reader["Password"].ToString(),
        //                RoleID = int.Parse(reader["RoleID"].ToString()),
        //                PhoneNumber = reader["PhoneNumber"].ToString(),
        //                ProfilePicUrl = reader["ProfilePicUrl"].ToString()
        //            });
        //        }
        //    }
        //    catch
        //    {
        //        Console.WriteLine("HATA OLUŞTU");
        //    }
        //    finally
        //    {
        //        DisconnectDB();
        //    }
        //    return users;
        //}
        //public List<Address> ListAddress(string query)
        //{
        //    List<Address> addresses = new List<Address>();
        //    SqlCommand cmd = new SqlCommand(query, con);
        //    IDataReader reader;
        //    try
        //    {
        //        ConnectDB();
        //        reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            addresses.Add(new Address()
        //            {
        //                ID = int.Parse(reader["ID"].ToString()),
        //                Details = reader["Details"].ToString(),
        //                TownID = int.Parse(reader["TownID"].ToString())
        //            });
        //        }
        //    }
        //    catch
        //    {
        //        Console.WriteLine("HATA OLUŞTU");
        //    }
        //    finally
        //    {
        //        DisconnectDB();
        //    }
        //    return addresses;
        //}

    }
}
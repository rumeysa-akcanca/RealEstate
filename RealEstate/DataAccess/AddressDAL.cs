using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using RealEstate.Models;

namespace RealEstate.DataAccess
{
    public class AddressDAL
    {
        private static AddressDAL _Methods { get; set; }

        public static AddressDAL Methods
        {
            get
            {
                if (_Methods == null)
                    _Methods = new AddressDAL();
                return _Methods;
            }
        }
        public object Insert(Address address)
        {
            string query = $"INSERT INTO Address (TownID,Details) VALUES({address.TownID},'{address.Details}'); SELECT CAST(scope_identity() as int);";
            object insertedID = DbTools.Connection.Create(query);
            return insertedID;
        }
        public bool Delete(Address address)
        {
            string query = $@"DELETE FROM Address WHERE ID={address.ID};";
            return DbTools.Connection.Execute(query);
        }
        public bool Update(Address address)
        {
            string query = $@"
                            UPDATE [dbo].[Address]
                               SET [TownID] = {address.TownID}
                                  ,[Details] = '{address.Details}'
                             WHERE ID={address.ID};";
            return DbTools.Connection.Execute(query);
        }
        public Address GetByID(int addressId)
        {
            string query = $"SELECT * FROM Address WHERE ID={addressId};";
            return ListAddress(query)[0];
        }

        public List<Address> ListAddress(string query)
        {
            List<Address> addresses = new List<Address>();
            SqlCommand cmd = new SqlCommand(query, DbTools.Connection.con);
            IDataReader reader;
            try
            {
                DbTools.Connection.ConnectDB();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    addresses.Add(new Address()
                    {
                        ID = int.Parse(reader["ID"].ToString()),
                        Details = reader["Details"].ToString(),
                        TownID = int.Parse(reader["TownID"].ToString())
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
            return addresses;
        }
    }
}
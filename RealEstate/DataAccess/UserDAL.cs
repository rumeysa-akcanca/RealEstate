using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using RealEstate.Models;

namespace RealEstate.DataAccess
{
    public class UserDAL
    {

        public object Insert(User user)
        {

            user.AddressID = Convert.ToInt32(AddressDAL.Methods.Insert(user.Address));
            string query = $@"
            INSERT INTO [dbo].[User]
               ([FullName]
               ,[Email]
               ,[Password]
               ,[PhoneNumber]
               ,[ProfilePicUrl]
               ,[AddressID]
               ,[RoleID])
            VALUES
           ( '{user.FullName}','{user.Email}','{user.Password}','{user.PhoneNumber}','{user.ProfilePic}',{user.AddressID},{user.RoleID});";
            
            return DbTools.Connection.Create(query);
        }
        public User Read(int userid)
        {
            string query = $"SELECT * FROM User WHERE ID = {userid}";
            User usr = ListUser(query)[0];
            return usr;
        }
        public bool Update(User user)
        {
            string query = $@"
                            UPDATE [dbo].[User]
                               SET [FullName] = '{user.FullName}'
                                  ,[Email] = '{user.Email}'
                                  ,[Password] = '{user.Password}'
                                  ,[PhoneNumber] = '{user.PhoneNumber}'
                                  ,[ProfilePicUrl] = '{user.ProfilePicUrl}'
                                  ,[AddressID] = {user.AddressID}
                                  ,[RoleID] = {user.RoleID}
                             WHERE ID={user.ID};";
            return DbTools.Connection.Execute(query);
        }

        public bool Delete(User user)
        {
            string query = $@"DELETE FROM User WHERE ID={user.ID};";
            return DbTools.Connection.Execute(query);
        }

        public List<User> List()
        {
            string query = "SELECT * FROM User;";
            return ListUser(query);
        }

        public List<User> ListUser(string query)
        {
            List<User> users = new List<User>();
            SqlCommand cmd = new SqlCommand(query, DbTools.Connection.con);
            IDataReader reader;
            try
            {
                DbTools.Connection.ConnectDB();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new User()
                    {
                        ID = int.Parse(reader["ID"].ToString()),
                        FullName = reader["FullName"].ToString(),
                        AddressID = int.Parse(reader["AddressID"].ToString()),
                        Email = reader["Email"].ToString(),
                        Password = reader["Password"].ToString(),
                        RoleID = int.Parse(reader["RoleID"].ToString()),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        ProfilePicUrl = reader["ProfilePicUrl"].ToString()
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
            return users;
        }
    }

}
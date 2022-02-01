using RealEstate.DataAccess;
using System;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var result =  UserDAL.Methods.ListUser("Select * From Users");
            foreach (var user in result)
            {
                Console.WriteLine(user.FullName);
            }
        }
    }
}

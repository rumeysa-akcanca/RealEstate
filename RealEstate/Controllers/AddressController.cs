using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealEstate.DataAccess;
using RealEstate.Models;
using Newtonsoft.Json;

namespace RealEstate.Controllers
{
    public class AddressController : Controller
    {
        public string GetCountries()
        {
            // Liste olarak döndürülen Address nesnelerini json objelerine çevirdik.
            // string tipindeki bu json objelerini js ile html içerisine yerleştireceğiz.
            string query = "SELECT * FROM Address;";
            string jsonCountries =  JsonConvert.SerializeObject(AddressCountryDAL.Methods.ListCountry(query));
            return jsonCountries;
        }
        public string GetCities(int countryid)
        {
            string query = $"SELECT * FROM AddressCity WHERE CountryID={countryid};";
            string jsonCities = JsonConvert.SerializeObject(AddressCityDAL.Methods.ListCity(query));
            return jsonCities;
        }
        public string GetTowns(int cityid)
        {
            string query = $"SELECT * FROM AddressTown WHERE CityID={cityid};";
            string jsonTowns = JsonConvert.SerializeObject(AddressTownDAL.Methods.ListTown(query));
            return jsonTowns;
        }
        public string GetAddressByID(int addressid)
        {
            
            string jsonAddress = JsonConvert.SerializeObject(AddressDAL.Methods.GetByID(addressid));
            return jsonAddress;
        }
    }
}

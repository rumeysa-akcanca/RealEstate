using Newtonsoft.Json;
using RealEstate.DataAccess;
using RealEstate.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstate.Controllers
{
    public class UserController : Controller
    {
        //private UserDAL _userDAL;
        //public UserDAL(UserDAL userDAL)
        //{
        //    _userDAL = userDAL;
        //}
        // GET: User
        public ActionResult Index()
        {

            var result = UserDAL.Methods.List();

           // var users = JsonConvert.SerializeObject(UserDAL.Methods.ListUser(query));

            return View(result);
        }


        //get: user/details/5
        public ActionResult Details(int id)
        {
            var result = UserDAL.Methods.GetByID(id);
            return View(result);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            
            return View();


        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                // TODO: Add insert logic here
                var insertedID=UserDAL.Methods.Insert(user);
                user.ID = Convert.ToInt32( insertedID);
                FotoUpload(user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var result = UserDAL.Methods.GetByID(id);
            
            return View(result);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                UserDAL.Methods.Update(user);
                   
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var result = UserDAL.Methods.GetByID(id);

            return View(result);
        }
        [NonAction] // Bu metot controller acction'ı değildir.
        private void FotoUpload(User user)
        {
            string userPath = Server.MapPath($"~/UploadedFiles/User/{user.ID }/");
            if (!Directory.Exists(userPath))
            {
                Directory.CreateDirectory(userPath);
            }
            string fotoPath = Path.Combine(userPath, Path.GetFileName(user.ProfilePic.FileName));
            user.ProfilePic.SaveAs(fotoPath);
            user.ProfilePicUrl = user.ID + "/" + user.ProfilePic.FileName;
            UserDAL.Methods.Update(user);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete( User user)
        {
            UserDAL.Methods.Delete(user);
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

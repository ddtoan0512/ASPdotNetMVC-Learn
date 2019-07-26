using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;
using OnlineShopTEDU.Common;
using PagedList;

namespace OnlineShopTEDU.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var userDAO = new UserDAO();
            var userModel = userDAO.ListAllPaging(searchString,page, pageSize);
            ViewBag.SearchString = searchString;
            return View(userModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {

            if (ModelState.IsValid)
            {
                var userDAO = new UserDAO();

                var encryptedMD5Password = Encryptor.MD5Hash(user.Password);
                user.Password = encryptedMD5Password;

                long userID = userDAO.Insert(user);

                if (userID > 0)
                {
                    SetAlert("Thêm user thành công !", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới không thành công !");
                }
            }
            return View("Index");
        }

        public ActionResult Edit(int id)
        {
            var user = new UserDAO().ViewDetail(id);
            
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {

            if (ModelState.IsValid)
            {
                var userDAO = new UserDAO();

                if(!string.IsNullOrEmpty(user.Password))
                {
                    var encryptedMD5Password = Encryptor.MD5Hash(user.Password);
                    user.Password = encryptedMD5Password;
                }

                var result = userDAO.Update(user);

                if (result)
                {
                    SetAlert("Sửa user thành công !", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công !");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new UserDAO().Delete(id);

            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new UserDAO().ChangeStatus(id);

            return Json(new
            {
                status = result
            });
        }
    }
}
using Model.DAO;
using Model.EF;
using OnlineShopTEDU.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopTEDU.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category model)
        {
            var currentCulture = Session[CommonConstants.CurrentCulture];
            model.Language = currentCulture.ToString();
            if (ModelState.IsValid)
            {
                var id = new CategoryDAO().Insert(model);
                if(id > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("",StaticResources.Resources.InsertCategoryFailed);
                }
            }
            return View(model);
        }
    }
}
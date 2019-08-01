using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;

namespace OnlineShopTEDU.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult ProductCategory()
        {
            var model = new ProductCategoryDAO().ListAll();
            return PartialView(model);
        }

        public ActionResult Category(long cateID)
        {
            var category = new CategoryDAO().ViewDetail(cateID);
            return View(category);
        }

        public ActionResult Detail(long id)
        {
            var product = new ProductDAO().ViewDetail(id);
            return View();
        }
    }
}
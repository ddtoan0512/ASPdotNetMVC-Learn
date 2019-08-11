using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using OnlineShopTEDU.Models;

namespace OnlineShopTEDU.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if(cart != null)
            {
                list = (List<CartItem>)cart;
            }

            return View(list);
        }

        public ActionResult AddItem(long productID, int quantity)
        {
            var product = new ProductDAO().ViewDetail(productID);
            var cart = Session[CartSession];

            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Product.ID == productID))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.ID == productID)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    // Tao moi doi tuong cart item
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;

                    list.Add(item);
                }

                //Gan vao session
                Session[CartSession] = list;

            }
            else
            {
                // Tao moi doi tuong cart item
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;

                var list = new List<CartItem>();
                list.Add(item);
                // Gan vao session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }
    }
}
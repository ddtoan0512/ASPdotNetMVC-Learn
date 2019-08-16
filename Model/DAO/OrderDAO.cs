using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class OrderDAO
    {
        OnlineShopTeduDbContext db;
        public OrderDAO()
        {
            db = new OnlineShopTeduDbContext();
        }
        public long Insert(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();

            return order.ID;
        }
    }
}

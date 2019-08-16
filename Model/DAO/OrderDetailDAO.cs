using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{

    public class OrderDetailDAO
    {
        OnlineShopTeduDbContext db;
        public OrderDetailDAO()
        {
            db = new OnlineShopTeduDbContext();
        }

        public bool Insert(OrderDetail detail)
        {
            try
            {
                db.OrderDetails.Add(detail);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

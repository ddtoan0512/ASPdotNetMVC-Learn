using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ContactDAO
    {
        OnlineShopTeduDbContext db;

        public ContactDAO()
        {
            db = new OnlineShopTeduDbContext();
        }

        public Contact GetActiveContact()
        {
            return db.Contacts.SingleOrDefault(x => x.Status == true);
        }

        public int Insert(Feedback fb)
        {
            db.Feedbacks.Add(fb);
            db.SaveChanges();
            return fb.ID;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class FooterDAO
    {
        OnlineShopTeduDbContext db = null;

        public FooterDAO()
        {
            db = new OnlineShopTeduDbContext();
        }

        public Footer GetFooter() {
            return db.Footers.SingleOrDefault(x => x.Status == true);
        }

    }
}

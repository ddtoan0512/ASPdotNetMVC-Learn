using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ContentDAO
    {
        OnlineShopTeduDbContext db = null;

        public ContentDAO()
        {
            db = new OnlineShopTeduDbContext();
        }

        public Content GetByID(long id)
        {
            return db.Contents.Find(id);
        }
    }
}

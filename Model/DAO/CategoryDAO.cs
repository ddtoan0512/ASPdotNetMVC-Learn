﻿using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class CategoryDAO
    {
        OnlineShopTeduDbContext db = null;
        
        public CategoryDAO()
        {
            db = new OnlineShopTeduDbContext();
        }

        public List<Category> ListAll()
        {
            return db.Categories.Where(x => x.Status == true).ToList();
        }
    }
}

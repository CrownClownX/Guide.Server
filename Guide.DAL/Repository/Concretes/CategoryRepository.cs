using Guide.BLL.Models;
using Guide.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guide.DAL.Repository.Concretes
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}

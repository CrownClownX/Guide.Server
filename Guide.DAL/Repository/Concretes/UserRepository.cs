using Guide.BLL.Models;
using Guide.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guide.DAL.Repository.Concretes
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context)
            :base(context)
        {

        }
    }
}

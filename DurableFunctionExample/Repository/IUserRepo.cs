using DurableFunctionExample.DataContext.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DurableFunctionExample.Repository
{
    interface IUserRepo
    {
        IEnumerable<User> GetAll();

        Task<User> Add(User user);

        Task<User> Get(int userId);

        Task SaveChanges();
    }
}

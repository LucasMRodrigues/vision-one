using LoginApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginApp.Repositories
{
    public class UserRepository : BaseRepository
    {
        public UserRepository(string connectionString) : base(connectionString) { }

        public async Task<int> RegisterAsync(User u)
        {
            return await Add<User>(new
            {
                u.username,
                u.password,
                e.email
            });
        }

        public async Task<User> LoginAsync(string phone, string email)
        {
            User user = await QueryFirstOrDefaultAsync<User>("Login", new { phone, email });
            return user;
        }
    }
}

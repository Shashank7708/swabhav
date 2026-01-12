using Microsoft.EntityFrameworkCore;

namespace AuthenticationAndAuthorization.Entities
{
    public class MyDbContext(DbContextOptions options) :DbContext(options)
    {
        public DbSet<LoginMaster> LoginMaster { get; set; }
        public DbSet<UserRefreshToken> UserRefreshToken { get; set; }
    }
}

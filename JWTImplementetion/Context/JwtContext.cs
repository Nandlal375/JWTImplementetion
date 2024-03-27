using JWTImplementetion.Model;
using Microsoft.EntityFrameworkCore;

namespace JWTImplementetion.Context
{
    public class JwtContext : DbContext
    {
        public JwtContext(DbContextOptions<JwtContext> options) : base(options) 
        {
        }
        public DbSet<User> users { get; set; }
        public DbSet<Employee> employees { get; set; }
    }
}

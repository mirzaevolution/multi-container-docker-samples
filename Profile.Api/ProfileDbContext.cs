using Microsoft.EntityFrameworkCore;
using Profile.Api.Entities;

namespace Profile.Api
{
    public class ProfileDbContext : DbContext
    {
        public ProfileDbContext(DbContextOptions<ProfileDbContext> options) : base(options)
        {
        }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
    }
}

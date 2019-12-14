using DataAccessLogic.EfStructures.Configurations;
using DataAccessLogic.EfStructures.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLogic.EfStructures.Context
{
    public partial class DanceCoolContext : DbContext
    {
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public DanceCoolContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if ( !optionsBuilder.IsConfigured )
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=DanceCool;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
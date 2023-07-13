using BE_Usuarios.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_Usuarios.Repository
{
    public partial class AplicationDbContext : DbContext
    {
        private string _connectionString;

        public AplicationDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public DbSet<Usuario> Usuario { get; set; }                

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(_connectionString);

    }
}

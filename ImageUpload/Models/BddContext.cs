using Microsoft.EntityFrameworkCore;

namespace ImageUpload.Models
{
    public class BddContext : DbContext

    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // Permet de se connecter à la Bdd
        {

            optionsBuilder.UseMySql("server=localhost;user id=root;password=rrrrr;database=ImgExample");
        }

        public void InitializeDb() // Permet la création de la Bdd et le remplissage des tables
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
            this.SaveChanges();
        }


    }
}

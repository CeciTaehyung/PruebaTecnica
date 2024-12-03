using Microsoft.EntityFrameworkCore;
using proyectoEN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoDAL
{
    public class SysProductoDBContext : DbContext
    {
        public SysProductoDBContext(DbContextOptions<SysProductoDBContext> options) : base(options) { }
        public DbSet<Productos> productos { get; set; }
        public DbSet<Categoria> categoria { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Productos>()
               .HasOne(p => p.categoria)
               .WithMany(c => c.Productos) 
               .HasForeignKey(p => p.CategoriaId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }


}
  


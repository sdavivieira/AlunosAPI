using AlunosAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace AlunosAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        
        }
        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().HasData(
                new Aluno
                {
                    Id = 1,
                    Nome = "Maria",
                    Email = "mariadapenha@gmail.com",
                    Idade = 23
                },
                 new Aluno
                 {
                     Id = 2,
                     Nome = "Manuel",
                     Email = "Manuelbueno@gmail.com",
                     Idade = 23
                 }
                 );

        }
    }
}

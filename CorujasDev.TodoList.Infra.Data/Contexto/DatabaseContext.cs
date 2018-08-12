using CorujasDev.TodoList.Domain.Entidades;
using CorujasDev.TodoList.Infra.Data.ConfigEntidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CorujasDev.TodoList.Infra.Data.Contexto
{
    public class DatabaseContext : DbContext
    {
        public DbSet<UsuarioDomain> Usuarios { get; set; }
        public DbSet<TarefaDomain> Tarefas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=EFCore-TodoList;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new TarefaConfiguration());
            
            base.OnModelCreating(modelBuilder); 
        }

        public override int SaveChanges()
        {
            try
            {
                foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCriacao") != null))
                {
                    if (new Guid(entry.Property("Id").CurrentValue.ToString()) == Guid.Empty)
                        entry.Property("Id").CurrentValue = Guid.NewGuid();

                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("DataCriacao").CurrentValue = Util.Helper.DateTimeHelper.GetCurrentTimeZone(DateTime.Now);
                        entry.Property("DataAlteracao").CurrentValue = Util.Helper.DateTimeHelper.GetCurrentTimeZone(DateTime.Now);
                    }

                    if (entry.State == EntityState.Modified)
                    {
                        entry.Property("DataCriacao").IsModified = false;
                        entry.Property("DataAlteracao").CurrentValue = Util.Helper.DateTimeHelper.GetCurrentTimeZone(DateTime.Now);
                    }
                }

                return base.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

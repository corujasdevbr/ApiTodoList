using CorujasDev.TodoList.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CorujasDev.TodoList.Infra.Data.Contexto
{
    public class DatabaseContext : DbContext
    {

        public DbSet<UsuarioDomain> Usuarios { get; set; }
        public DbSet<TarefaDomain> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder); 
        }

    }
}

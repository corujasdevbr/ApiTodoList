using CorujasDev.TodoList.Domain.Entidades;
using CorujasDev.TodoList.Infra.Data.ConfigEntidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CorujasDev.TodoList.Infra.Data.Contexto
{
    /// <summary>
    /// Classe do contexto que herda de DbContext para trabalhar com Entity Framework Core
    /// </summary>
    public class DatabaseContext : DbContext
    {
        public DbSet<UsuarioDomain> Usuarios { get; set; }
        public DbSet<TarefaDomain> Tarefas { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DatabaseContext()
        {
        }

        /// <summary>
        /// Configura as opções do DbContext
        /// </summary>
        /// <param name="optionsBuilder"> Parametro responsavel pelas configurações do DbContext</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Define o banco de dado a ser usado passando a Connection String
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=EFCore-TodoList;Trusted_Connection=True");
        }

        /// <summary>
        /// Ocorre na criação do Modelo, ele passa neste metodo antes do migrations
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new TarefaConfiguration());
            
            base.OnModelCreating(modelBuilder); 
        }

        /// <summary>
        /// Metodo para salvar os dados
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            try
            {
                //Percorre as entidades procurando pelas entidades que tem a propriedade DataCriacao
                foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCriacao") != null))
                {
                    //Verifica se o Guid esta empty, caso sim gera um novo Guid
                    if (new Guid(entry.Property("Id").CurrentValue.ToString()) == Guid.Empty)
                        entry.Property("Id").CurrentValue = Guid.NewGuid();

                    //Verifica se esta inserindo no banco, caso sim altera a propriedade DataCriacao e DataAlteracao para data e hora atual
                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("DataCriacao").CurrentValue = Util.Helper.DateTimeHelper.GetCurrentTimeZone(DateTime.Now);
                        entry.Property("DataAlteracao").CurrentValue = Util.Helper.DateTimeHelper.GetCurrentTimeZone(DateTime.Now);
                    }

                    //Verifica se esta inserindo no banco, caso sim altera a somente a propriedade DataAlteracao para data e hora atual
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

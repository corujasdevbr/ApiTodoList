using CorujasDev.TodoList.Domain.Contratos.Repositorios;
using CorujasDev.TodoList.Domain.Interfaces.Repositorios;
using CorujasDev.TodoList.Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CorujasDev.TodoList.Infra.Data.Repositorios
{
    /// <summary>
    /// Classe generica que irá fazer a ponte entre a aplicação e o banco de dados
    /// Existem metodos de leitura e gravação
    /// </summary>
    /// <typeparam name="T">Classe/Dominio que irá ocorrer as alterações</typeparam>
    public class BaseRep<TEntity> : IDisposable, IRepositorioBase<TEntity> where TEntity : class
    {
        
        protected DatabaseContext Context { get; set; }
        protected readonly DbSet<TEntity> DbSet;

        /// <summary>
        /// Contrutor - instancia a classe Context
        /// </summary>
        public BaseRep()
        {
            this.Context = new DatabaseContext();
            DbSet = this.Context.Set<TEntity>();
        }
        /// <summary>
        /// Destroi o objeto Conext
        /// </summary>
        public void Dispose()
        {
            this.Context.Dispose();
            GC.SuppressFinalize(this);

        }
        /// <summary>
        /// Altera os dados da classe
        /// </summary>
        /// <param name="Dados">Dados do Objeto passado</param>
        public virtual void Alterar(TEntity Dados)
        {
            try
            {
                DbSet.Update(Dados);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Exclui um objeto 
        /// </summary>
        /// <param name="Id">Id do objecto a ser excluido</param>
        public virtual void Excluir(Guid Id)
        {
            try
            {
                DbSet.Remove(DbSet.Find(Id));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Insere um novo objeto
        /// </summary>
        /// <param name="Dados">Dados do objeto</param>
        public virtual void Inserir(TEntity Dados)
        {
            try
            {
                DbSet.Add(Dados);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Lista todos os dados da entidade informada
        /// </summary>
        /// <returns>Retorna uma coleção de objetos</returns>
        public virtual IQueryable<TEntity> Listar()
        {
            try
            {
                return DbSet;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Busca um objeto na entidade por meio do seu Id
        /// </summary>
        /// <param name="Id">Id do objeto</param>
        public virtual TEntity BuscarPorId(Guid Id)
        {
            try
            {
                return DbSet.Find(Id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Salva as mudanças no contexto
        /// </summary>
        /// <returns>Retorna a quantidade de alterações</returns>
        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }
    }
}

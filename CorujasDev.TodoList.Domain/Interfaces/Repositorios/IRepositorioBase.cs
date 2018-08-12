using System;
using System.Collections.Generic;
using System.Linq;

namespace CorujasDev.TodoList.Domain.Interfaces.Repositorios
{
    /// <summary>
    /// Interface responsável pelos metodos do Repositorio
    /// </summary>
    /// <typeparam name="T">Tipo da Classe que será utilizado</typeparam>
    public interface IRepositorioBase<T> where T : class
    {
        #region Leitura
        IQueryable<T> Listar();
        T BuscarPorId(Guid Id);
        #endregion

        #region Gravação
        void Alterar(T Dados);
        void Inserir(T Dados);
        void Excluir(Guid Id);
        int SaveChanges();
        #endregion
    }
}

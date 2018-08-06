using System;
using System.Collections.Generic;

namespace CorujasDev.TodoList.Domain.Contratos.Repositorios
{
    /// <summary>
    /// Interface responsável pelos metodos do Repositorio
    /// </summary>
    /// <typeparam name="T">Tipo da Classe que será utilizado</typeparam>
    public interface IRepositorioBase<T> where T : class
    {
        ICollection<T> Listar();
        T BuscarPorId(Guid Id);
        T Alterar(T Dados);
        T Inserir(T Dados);
        int Excluir(Guid Id);
    }
}

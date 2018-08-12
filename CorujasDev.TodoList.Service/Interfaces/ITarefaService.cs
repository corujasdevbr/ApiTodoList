using CorujasDev.TodoList.Service.ViewModels.Tarefa;
using System;
using System.Collections.Generic;

namespace CorujasDev.TodoList.Service.Interfaces
{
    public interface ITarefaService : IDisposable
    {
        #region Gravação
        void Inserir(TarefaViewModel tarefaViewModel);
        void Alterar(TarefaViewModel tarefaViewModel);
        void Excluir(Guid id);
        #endregion

        #region Leitura
        IEnumerable<TarefaViewModel> Listar();
        TarefaViewModel BuscarPorId(Guid id);
        #endregion
    }
}

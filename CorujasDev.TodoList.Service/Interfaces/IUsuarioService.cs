using CorujasDev.TodoList.Service.ViewModels.Tarefa;
using CorujasDev.TodoList.Service.ViewModels.Usuario;
using System;
using System.Collections.Generic;

namespace CorujasDev.TodoList.Service.Interfaces
{
    public interface IUsuarioService : IDisposable
    {
        #region Gravação
        void Inserir(UsuarioViewModel usuarioViewModel);
        void Alterar(UsuarioViewModel usuarioViewModel);
        void Excluir(Guid id);
        int Salvar();
        #endregion

        #region Leitura
        IList<TarefaViewModel> ListarTarefas(Guid id);
        IEnumerable<UsuarioViewModel> Listar();
        UsuarioViewModel BuscarPorId(Guid id);
        UsuarioViewModel Login(string email, string senha);
        #endregion
    }
}

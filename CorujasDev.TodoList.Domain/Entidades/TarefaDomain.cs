using CorujasDev.TodoList.Util.Enum;
using System;

namespace CorujasDev.TodoList.Domain.Entidades
{
    /// <summary>
    /// Classe que irá armazenar as tarefas do usuário
    /// </summary>
    public class TarefaDomain : BaseDomain
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public EnStatus Status { get; set; }
        public DateTime DataConcluido { get; set; }

        #region Relacionamentos
        public Guid IdUsuario { get; set; }
        public UsuarioDomain Usuario { get; set; }
        #endregion
    }
}

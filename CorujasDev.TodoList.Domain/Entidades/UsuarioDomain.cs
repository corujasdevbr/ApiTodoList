using CorujasDev.TodoList.Util.Enum;
using System.Collections.Generic;

namespace CorujasDev.TodoList.Domain.Entidades
{
    /// <summary>
    /// Classe referente aos dados do usuario
    /// </summary>
    public class UsuarioDomain : BaseDomain
    {
        public string Nome { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }   
        public string Senha { get; set; }
        public string Imagem { get; set; }
        public EnTipoUsuario TipoUsuario { get; set; }
        #region Relacionamento
        public virtual ICollection<TarefaDomain> Tarefas { get; set; }
        #endregion
    }
}

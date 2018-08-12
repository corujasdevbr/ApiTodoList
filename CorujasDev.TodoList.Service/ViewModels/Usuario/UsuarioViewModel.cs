using CorujasDev.TodoList.Service.ViewModels.Tarefa;
using CorujasDev.TodoList.Util.Enum;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CorujasDev.TodoList.Service.ViewModels.Usuario
{
    public class UsuarioViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Campo Nome é requerido")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo UserName é requerido")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Campo Email é requerido")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Senha é requerido")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Campo Tipo de Usuário é requerido")]
        [DisplayName("Tipo de Usuário")]
        public EnTipoUsuario TipoUsuario { get; set; }

        public string Imagem { get; set; }

        #region Relacionamento
        public virtual ICollection<TarefaViewModel> Tarefas { get; set; }
        #endregion
    }
}

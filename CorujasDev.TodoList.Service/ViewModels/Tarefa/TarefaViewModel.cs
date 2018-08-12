using CorujasDev.TodoList.Service.ViewModels.Usuario;
using CorujasDev.TodoList.Util.Enum;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CorujasDev.TodoList.Service.ViewModels.Tarefa
{
    public class TarefaViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Campo Título é requerido")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Campo Descrição é requerido")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo Tempo é requerido")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Tempo")]
        public double Tempo { get; set; }

        [Required(ErrorMessage = "Campo Status é requerido")]
        [DisplayName("Status")]
        public EnStatus Status { get; set; }
        public DateTime DataConcluido { get; set; }

        #region Relacionamentos
        [Required(ErrorMessage = "Campo Id do Usuário é requerido")]
        [DisplayName("Id do Usuário")]
        public Guid IdUsuario { get; set; }
        public UsuarioViewModel Usuario { get; set; }
        #endregion
    }
}

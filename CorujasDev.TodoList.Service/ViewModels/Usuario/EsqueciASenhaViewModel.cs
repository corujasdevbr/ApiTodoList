using System.ComponentModel.DataAnnotations;

namespace CorujasDev.TodoList.Service.ViewModels.Usuario
{
    public class EsqueciASenhaViewModel
    {
        [Required(ErrorMessage = "Informe o Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}

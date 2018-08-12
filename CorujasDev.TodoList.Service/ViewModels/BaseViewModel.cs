using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CorujasDev.TodoList.Service.ViewModels
{
    public class BaseViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public bool Ativo { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayName("Data de Cadastro")]
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}

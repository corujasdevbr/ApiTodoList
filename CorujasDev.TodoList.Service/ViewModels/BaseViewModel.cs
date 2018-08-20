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
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}

using System;

namespace CorujasDev.TodoList.Domain.Entidades
{
    /// <summary>
    /// Classe que irá ser herdada pelas classes do projeto
    /// A mesma é abstract pois não pode ser instanciada.
    /// </summary>
    public abstract class BaseDomain
    {
        public Guid Id { get; set; }
        public bool Ativo { get; set; } 
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}

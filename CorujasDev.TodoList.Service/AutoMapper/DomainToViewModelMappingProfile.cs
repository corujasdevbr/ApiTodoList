using AutoMapper;
using CorujasDev.TodoList.Domain.Entidades;
using CorujasDev.TodoList.Service.ViewModels.Tarefa;
using CorujasDev.TodoList.Service.ViewModels.Usuario;

namespace CorujasDev.TodoList.Service.AutoMapper
{
    /// <summary>
    /// Classe responsável pelo mapeamendo do Domino para o ViewModel
    /// </summary>
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<UsuarioDomain, UsuarioViewModel>();
            CreateMap<TarefaDomain, TarefaViewModel>();
        }
    }
}

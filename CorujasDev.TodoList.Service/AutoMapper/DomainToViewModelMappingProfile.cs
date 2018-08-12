using AutoMapper;
using CorujasDev.TodoList.Domain.Entidades;
using CorujasDev.TodoList.Service.ViewModels.Tarefa;
using CorujasDev.TodoList.Service.ViewModels.Usuario;

namespace CorujasDev.TodoList.Service.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<UsuarioDomain, UsuarioViewModel>();
            CreateMap<TarefaDomain, TarefaViewModel>();
        }
    }
}

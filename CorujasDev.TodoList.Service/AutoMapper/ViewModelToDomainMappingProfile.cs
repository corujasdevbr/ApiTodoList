using AutoMapper;
using CorujasDev.TodoList.Domain.Entidades;
using CorujasDev.TodoList.Service.ViewModels.Tarefa;
using CorujasDev.TodoList.Service.ViewModels.Usuario;

namespace CorujasDev.TodoList.Service.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UsuarioViewModel, UsuarioDomain>();
            CreateMap<TarefaViewModel, TarefaDomain>();
        }
    }
}

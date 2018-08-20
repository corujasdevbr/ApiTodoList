using AutoMapper;
using CorujasDev.TodoList.Domain.Entidades;
using CorujasDev.TodoList.Service.ViewModels.Tarefa;
using CorujasDev.TodoList.Service.ViewModels.Usuario;

namespace CorujasDev.TodoList.Service.AutoMapper
{
    /// <summary>
    /// Classe responsável pelo mapeamendo do ViewModel para o Domino
    /// </summary>
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UsuarioViewModel, UsuarioDomain>();
            CreateMap<TarefaViewModel, TarefaDomain>();
        }
    }
}

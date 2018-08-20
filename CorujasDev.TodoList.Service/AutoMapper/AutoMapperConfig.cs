using AutoMapper;

namespace CorujasDev.TodoList.Service.AutoMapper
{
    /// <summary>
    /// Classe que configura o Mapeamento das classes de Dominio para ViewModel
    /// </summary>
    public class AutoMapperConfig
    {
        /// <summary>
        /// Registra os mapeamentos
        /// </summary>
        /// <returns></returns>
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                //Classes de ajuda para informar os mapeamentos
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}

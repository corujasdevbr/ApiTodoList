using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CorujasDev.TodoList.Domain.Entidades;
using CorujasDev.TodoList.Domain.Interfaces.Repositorios;
using CorujasDev.TodoList.Service.Interfaces;
using CorujasDev.TodoList.Service.ViewModels.Tarefa;
using CorujasDev.TodoList.Service.ViewModels.Usuario;

namespace CorujasDev.TodoList.Service.Services
{
    public class UsuarioAppService : IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IRepositorioBase<UsuarioDomain> _usuarioRepository;
        private readonly IRepositorioBase<TarefaDomain> _tarefaRepository;

        public UsuarioAppService(IRepositorioBase<UsuarioDomain> usuarioRepository, IRepositorioBase<TarefaDomain> tarefaRepository)
        {
            this._usuarioRepository = usuarioRepository;
            this._tarefaRepository = tarefaRepository;
        }

        public void Alterar(UsuarioViewModel usuarioViewModel)
        {
            try
            {
                _usuarioRepository.Alterar(_mapper.Map<UsuarioDomain>(usuarioViewModel));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public UsuarioViewModel BuscarPorId(Guid id)
        {
            try
            {
                return _mapper.Map<UsuarioViewModel>(_usuarioRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Dispose()
        {
            try
            {
                GC.SuppressFinalize(this);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Excluir(Guid id)
        {
            try
            {
                _usuarioRepository.Excluir(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Inserir(UsuarioViewModel usuarioViewModel)
        {
            try
            {
                _usuarioRepository.Inserir(_mapper.Map<UsuarioDomain>(usuarioViewModel));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<UsuarioViewModel> Listar()
        {
            return _usuarioRepository.Listar().ProjectTo<UsuarioViewModel>();
        }

        public IList<TarefaViewModel> ListarTarefas(Guid id)
        {
            return _mapper.Map<IList<TarefaViewModel>>(_tarefaRepository.Listar().Where(x => x.IdUsuario == id));
        }

        public UsuarioViewModel Login(string email, string senha)
        {
            UsuarioViewModel usuario = _mapper.Map<UsuarioViewModel>(_usuarioRepository.Listar().FirstOrDefault(x => x.Email.ToLower() == email.ToLower()));

            if (usuario == null)
                throw new Exception("E-mail inválido");

            if(usuario.Senha == senha)
                throw new Exception("Senha inválida");
            
            return usuario;
        }

        public int Salvar()
        {
            return _usuarioRepository.SaveChanges();
        }
    }
}

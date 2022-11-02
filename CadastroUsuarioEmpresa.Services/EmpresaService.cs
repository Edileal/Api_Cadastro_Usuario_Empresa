using AutoMapper;
using CadastroUsuarioEmpresa.Domain.Contracts.Empresa;
using CadastroUsuarioEmpresa.Domain.Contracts.Usuario;
using CadastroUsuarioEmpresa.Domain.Entities;
using CadastroUsuarioEmpresa.Domain.Interfaces.Repository;
using CadastroUsuarioEmpresa.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioEmpresa.Services
{
    public class EmpresaService : IEmpresaService
    {
        public readonly IEmpresaRepository _empresaRepository;
        public readonly IEnderecoRepository _enderecoRepository;
        public readonly IMapper _mapper;
        public EmpresaService(IEmpresaRepository empresaRepository, IEnderecoRepository enderecoRepository, IMapper mapper)
        {
            _empresaRepository = empresaRepository;
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmpresaResponse>> Get()
        {
            var listaEmpresasBaseDados = await _empresaRepository.Get();

            return _mapper.Map<IEnumerable<EmpresaResponse>>(listaEmpresasBaseDados);
        }

        public async Task<EmpresaResponse> GetById(int id)
        {
            var empresaRetornoBanco = await _empresaRepository.GetById(id);

            return _mapper.Map<EmpresaResponse>(empresaRetornoBanco);
        }

        public async Task<EmpresaResponse> Post(EmpresaRequest request)
        {
            var empresaEntity = _mapper.Map<EmpresaEntities>(request);
            var empresaCadastrada = _empresaRepository.Post(empresaEntity);

            return _mapper.Map<EmpresaResponse>(empresaCadastrada);
        }

        public async Task<EmpresaResponse> Put(EmpresaRequest request, int? id)
        {
            var empresaBancoDeDados = await _empresaRepository.GetById((int)id);

            empresaBancoDeDados.NomeFantasia = request.NomeFantasia;

            var empresaAtualizada = await _empresaRepository.Put(empresaBancoDeDados, null);

            return _mapper.Map<EmpresaResponse>(empresaAtualizada);
        }
        public async Task Delete(int request)
        {
            var empresaBancoDeDados = await _empresaRepository.GetById((int)request);

            if (empresaBancoDeDados != null)
            {
                await _empresaRepository.Delete(empresaBancoDeDados);
            }
        }
    }
}

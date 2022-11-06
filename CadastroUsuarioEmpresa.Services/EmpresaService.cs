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
        public EmpresaService(IEmpresaRepository empresaRepository, IMapper mapper)
        {
            _empresaRepository = empresaRepository;
            
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
            
            if (string.IsNullOrWhiteSpace(request.NomeFantasia))
            {
                throw new Exception("Nome fantasia inválido");
            }
            if (string.IsNullOrWhiteSpace(request.Endereco.Rua))
            {
                throw new Exception("Rua inválida");
            }
            if (string.IsNullOrWhiteSpace(request.Endereco.Bairro))
            {
                throw new Exception("Bairro inválido");
            }
            if (request.Endereco.Cep.Length != 8)
            {
                throw new Exception("Cep inválido");
            }
            if (string.IsNullOrWhiteSpace(request.Endereco.Cidade))
            {
                throw new Exception("Cidade inválida");
            }
            if (string.IsNullOrWhiteSpace(request.Endereco.Estado))
            {
                throw new Exception("Bairro inválido");
            }
            if (string.IsNullOrWhiteSpace(request.Endereco.Numero))
            {
                throw new Exception("Número inválido");
            }
            var empresaEntity = _mapper.Map<EmpresaEntities>(request);

            var empresaCadastrada = await _empresaRepository.Post(empresaEntity);

            return _mapper.Map<EmpresaResponse>(empresaCadastrada);
        }

        public async Task<EmpresaResponse> Put(EmpresaRequest request, int? id)
        {
            var empresaBancoDeDados = await _empresaRepository.GetById((int)id);

            if(request.NomeFantasia == null)
            {
                throw new Exception("Insira um Nome fantasia válido");
            }

            empresaBancoDeDados.NomeFantasia = request.NomeFantasia;
            empresaBancoDeDados.Nome = request.Nome;

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

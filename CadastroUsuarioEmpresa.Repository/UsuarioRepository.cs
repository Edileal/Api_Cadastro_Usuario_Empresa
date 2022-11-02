using CadastroUsuarioEmpresa.Domain.Entities;
using CadastroUsuarioEmpresa.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioEmpresa.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CadastroUsuarioEmpresaContext _context;
        public UsuarioRepository(CadastroUsuarioEmpresaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UsuarioEntities>> Get()
        {
            return await _context.Usuarios.AsNoTracking().ToListAsync();
        }
        public async Task<UsuarioEntities> GetById(int id)
        {
            return await _context.Usuarios.Where(prop => prop.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<UsuarioEntities> GetByEmail(string email)
        {
            return await _context.Usuarios.Where(prop => prop.Email == email)
                                          .AsNoTracking()
                                          .FirstOrDefaultAsync();
        }
        

        public async Task<UsuarioEntities> Post(UsuarioEntities request)
        {
            await _context.Usuarios.AddAsync(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<UsuarioEntities> Put(UsuarioEntities request, int? id = null)
        {
            _context.Usuarios.Update(request);
            await _context.SaveChangesAsync();
            return request;
        }
        public async Task Delete(UsuarioEntities request)
        {
            _context.Usuarios.Remove(request);
            await _context.SaveChangesAsync();
        }

        public Task Delete(int request)
        {
            throw new NotImplementedException();
        }
    }
}

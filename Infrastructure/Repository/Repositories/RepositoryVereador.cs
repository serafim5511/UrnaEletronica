using Domain.Interfaces.InterfaceVereador;
using Entities.Entities;
using Entities.Entities.Enums;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryVereador : RepositoryGenerics<Vereador>, IVereador
    {

        private readonly DbContextOptions<ContextBase> _optionsbuilder;

        public RepositoryVereador()
        {
            _optionsbuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Vereador>> ListarVereadors(Expression<Func<Vereador, bool>> exVereador)
        {
            using (var banco = new ContextBase(_optionsbuilder))
            {
                return await banco.Vereador.Where(exVereador).AsNoTracking().ToListAsync();
            }
        }


        public async Task<List<Vereador>> ListarVereadorsUsuario()
        {
            using (var banco = new ContextBase(_optionsbuilder))
            {
                return await banco.Vereador.AsNoTracking().ToListAsync();
            }
        }

    }
}

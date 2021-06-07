using Domain.Interfaces.InterfacePrefeito;
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
    public class RepositoryPrefeito : RepositoryGenerics<Prefeito>, IPrefeito
    {

        private readonly DbContextOptions<ContextBase> _optionsbuilder;

        public RepositoryPrefeito()
        {
            _optionsbuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Prefeito>> ListarPrefeitos(Expression<Func<Prefeito, bool>> exPrefeito)
        {
            using (var banco = new ContextBase(_optionsbuilder))
            {
                return await banco.Prefeito.Where(exPrefeito).AsNoTracking().ToListAsync();
            }
        }  

        public async Task<List<Prefeito>> ListarPrefeitosUsuario( )
        {
            using (var banco = new ContextBase(_optionsbuilder))
            {
                return await banco.Prefeito.AsNoTracking().ToListAsync();
            }
        }

    }
}

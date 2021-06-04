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

        /*public async Task<List<Prefeito>> ListarPrefeitosCarrinhoUsuario(string userId)
        {
            using (var banco = new ContextBase(_optionsbuilder))
            {
                var PrefeitosCarrinhoUsuario = await (from p in banco.Prefeito
                                                     join c in banco.CompraUsuario on p.Id equals c.IdPrefeito
                                                     join co in banco.Compra on c.IdCompra equals co.Id
                                                     where c.UserId.Equals(userId)
                                                     && c.Estado == EnumEstadoCompra.Prefeito_Carrinho
                                                     select new Prefeito
                                                     {
                                                         Id = p.Id,
                                                         Nome = p.Nome,
                                                         Descricao = p.Descricao,
                                                         Observacao = p.Observacao,
                                                         Valor = p.Valor,
                                                         QtdCompra = c.QtdCompra,
                                                         IdPrefeitoCarrinho = c.Id,
                                                         Url = p.Url,
                                                         DataCompra = co.DataCompra

                                                     }).AsNoTracking().ToListAsync();

                return PrefeitosCarrinhoUsuario;

            }
        }
*/
        

        public async Task<List<Prefeito>> ListarPrefeitosUsuario(string userId)
        {
            using (var banco = new ContextBase(_optionsbuilder))
            {
                return await banco.Prefeito.Where(p => p.UserId == userId).AsNoTracking().ToListAsync();
            }
        }
/*
        public async Task<List<Prefeito>> ListarPrefeitosVendidos(string userId, string filtro)
        {
            using (var banco = new ContextBase(_optionsbuilder))
            {
                var PrefeitosVendidos = await (from p in banco.Prefeito
                                              join c in banco.CompraUsuario on p.Id equals c.IdPrefeito
                                              where p.UserId.Equals(userId) && c.Estado == EnumEstadoCompra.Prefeito_Comprado
                                              && (string.IsNullOrWhiteSpace(filtro) || p.Descricao.Contains(filtro))
                                              select p).AsNoTracking().ToListAsync();

                return PrefeitosVendidos;
            }
        }*/
    }
}

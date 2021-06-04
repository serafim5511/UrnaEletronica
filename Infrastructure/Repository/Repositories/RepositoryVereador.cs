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

        /*public async Task<List<Vereador>> ListarVereadorsCarrinhoUsuario(string userId)
        {
            using (var banco = new ContextBase(_optionsbuilder))
            {
                var VereadorsCarrinhoUsuario = await (from p in banco.Vereador
                                                     join c in banco.CompraUsuario on p.Id equals c.IdVereador
                                                     join co in banco.Compra on c.IdCompra equals co.Id
                                                     where c.UserId.Equals(userId)
                                                     && c.Estado == EnumEstadoCompra.Vereador_Carrinho
                                                     select new Vereador
                                                     {
                                                         Id = p.Id,
                                                         Nome = p.Nome,
                                                         Descricao = p.Descricao,
                                                         Observacao = p.Observacao,
                                                         Valor = p.Valor,
                                                         QtdCompra = c.QtdCompra,
                                                         IdVereadorCarrinho = c.Id,
                                                         Url = p.Url,
                                                         DataCompra = co.DataCompra

                                                     }).AsNoTracking().ToListAsync();

                return VereadorsCarrinhoUsuario;

            }
        }
*/
        

        public async Task<List<Vereador>> ListarVereadorsUsuario(string userId)
        {
            using (var banco = new ContextBase(_optionsbuilder))
            {
                return await banco.Vereador.Where(p => p.UserId == userId).AsNoTracking().ToListAsync();
            }
        }
/*
        public async Task<List<Vereador>> ListarVereadorsVendidos(string userId, string filtro)
        {
            using (var banco = new ContextBase(_optionsbuilder))
            {
                var VereadorsVendidos = await (from p in banco.Vereador
                                              join c in banco.CompraUsuario on p.Id equals c.IdVereador
                                              where p.UserId.Equals(userId) && c.Estado == EnumEstadoCompra.Vereador_Comprado
                                              && (string.IsNullOrWhiteSpace(filtro) || p.Descricao.Contains(filtro))
                                              select p).AsNoTracking().ToListAsync();

                return VereadorsVendidos;
            }
        }*/
    }
}

using Domain.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceVereador
{
    public interface IVereador : IGeneric<Vereador>
    {
        Task<List<Vereador>> ListarVereadorsUsuario(string userId);

        Task<List<Vereador>> ListarVereadors(Expression<Func<Vereador, bool>> exVereador);

/*        Task<List<Vereador>> ListarVereadorsCarrinhoUsuario(string userId);
*/
       /* Task<Vereador> ObterVereadorCarrinho(int idVereadorCarrinho);

        Task<List<Vereador>> ListarVereadorsVendidos(string userId, string filtro);*/
    }
}

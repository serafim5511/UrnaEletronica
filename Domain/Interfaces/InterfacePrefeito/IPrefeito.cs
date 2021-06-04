using Domain.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfacePrefeito
{
    public interface IPrefeito : IGeneric<Prefeito>
    {
        Task<List<Prefeito>> ListarPrefeitosUsuario(string userId);

        Task<List<Prefeito>> ListarPrefeitos(Expression<Func<Prefeito, bool>> exPrefeito);

/*        Task<List<Prefeito>> ListarPrefeitosCarrinhoUsuario(string userId);
*/
       /* Task<Prefeito> ObterPrefeitoCarrinho(int idPrefeitoCarrinho);

        Task<List<Prefeito>> ListarPrefeitosVendidos(string userId, string filtro);*/
    }
}

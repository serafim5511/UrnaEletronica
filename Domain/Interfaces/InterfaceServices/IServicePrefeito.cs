using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IServicePrefeito
    {
        Task AddPrefeito(Prefeito Prefeito);
        Task UpdatePrefeito(Prefeito Prefeito);

        //Task<List<Prefeito>> ListarPrefeitosComEstoque(string descricao);
    }
}

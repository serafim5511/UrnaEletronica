using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IServiceVereador
    {
        Task AddVereador(Vereador Vereador);
        Task UpdateVereador(Vereador Vereador);

        //Task<List<Vereador>> ListarVereadorsComEstoque(string descricao);
    }
}

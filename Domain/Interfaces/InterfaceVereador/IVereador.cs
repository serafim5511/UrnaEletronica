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
        Task<List<Vereador>> ListarVereadorsUsuario();

        Task<List<Vereador>> ListarVereadors(Expression<Func<Vereador, bool>> exVereador);

    }
}

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
        Task<List<Prefeito>> ListarPrefeitosUsuario();

        Task<List<Prefeito>> ListarPrefeitos(Expression<Func<Prefeito, bool>> exPrefeito);

    }
}

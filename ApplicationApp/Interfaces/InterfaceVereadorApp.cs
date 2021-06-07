using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationApp.Interfaces
{
    public interface InterfaceVereadorApp : InterfaceGenericaApp<Vereador>
    {
        Task AddVereador(Vereador Vereador);
        Task UpdateVereador(Vereador Vereador);

        Task<List<Vereador>> ListarVereadorUsuario();

    }
}

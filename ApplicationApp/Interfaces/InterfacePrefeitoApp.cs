using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationApp.Interfaces
{
    public interface InterfacePrefeitoApp : InterfaceGenericaApp<Prefeito>
    {
        Task AddPrefeito(Prefeito Prefeito);
        Task UpdatePrefeito(Prefeito Prefeito);

        Task<List<Prefeito>> ListarPrefeitoUsuario();

      
    }
}

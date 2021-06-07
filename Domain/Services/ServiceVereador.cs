using Domain.Interfaces.InterfaceVereador;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceVereador : IServiceVereador
    {

        private readonly IVereador _IVereador;

        public ServiceVereador(IVereador IVereador)
        {
            _IVereador = IVereador;
        }

        public async Task AddVereador(Vereador Vereador)
        {
            var validaNome = Vereador.ValidarPropriedadeString(Vereador.Nome, "Nome");

         

            if (validaNome )
            {
                Vereador.DataCadastro = DateTime.Now;
                
                await _IVereador.Add(Vereador);
            }
        }

     
        public async Task UpdateVereador(Vereador Vereador)
        {
            var validaNome = Vereador.ValidarPropriedadeString(Vereador.Nome, "Nome");

          

            if (validaNome)
            {

                await _IVereador.Update(Vereador);
            }
        }
    }
}

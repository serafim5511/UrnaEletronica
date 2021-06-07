using Domain.Interfaces.InterfacePrefeito;
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
    public class ServicePrefeito : IServicePrefeito
    {

        private readonly IPrefeito _IPrefeito;

        public ServicePrefeito(IPrefeito IPrefeito)
        {
            _IPrefeito = IPrefeito;
        }

        public async Task AddPrefeito(Prefeito Prefeito)
        {
            var validaNome = Prefeito.ValidarPropriedadeString(Prefeito.Nome, "Nome");

          

            if (validaNome )
            {
                Prefeito.DataCadastro = DateTime.Now;
                await _IPrefeito.Add(Prefeito);
            }
        }

        

        public async Task UpdatePrefeito(Prefeito Prefeito)
        {
            var validaNome = Prefeito.ValidarPropriedadeString(Prefeito.Nome, "Nome");

          

            if (validaNome )
            {
           

                await _IPrefeito.Update(Prefeito);
            }
        }
    }
}

using ApplicationApp.Interfaces;
using Domain.Interfaces.InterfacePrefeito;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationApp.OpenApp
{
    public class AppPrefeito : InterfacePrefeitoApp
    {
        IPrefeito _IPrefeito;
        IServicePrefeito _IServicePrefeito;
        public AppPrefeito(IPrefeito IPrefeito, IServicePrefeito IServicePrefeito)
        {
            _IPrefeito = IPrefeito;
            _IServicePrefeito = IServicePrefeito;
        }


        public async Task AddPrefeito(Prefeito Prefeito)
        {
            await _IServicePrefeito.AddPrefeito(Prefeito);
        }
        public async Task UpdatePrefeito(Prefeito Prefeito)
        {
            await _IServicePrefeito.UpdatePrefeito(Prefeito);
        }

        public async Task<List<Prefeito>> ListarPrefeitoUsuario()
        {
            return await _IPrefeito.ListarPrefeitosUsuario();
        }


        public async Task Add(Prefeito Objeto)
        {
            await _IPrefeito.Add(Objeto);
        }
        public async Task Delete(Prefeito Objeto)
        {
            await _IPrefeito.Delete(Objeto);
        }
        public async Task<Prefeito> GetEntityById(int Id)
        {
            return await _IPrefeito.GetEntityById(Id);
        }

        public async Task<List<Prefeito>> List()
        {
            return await _IPrefeito.List();
        }

        public async Task Update(Prefeito Objeto)
        {
            await _IPrefeito.Update(Objeto);
        }


    }
}

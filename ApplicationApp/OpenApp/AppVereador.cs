using ApplicationApp.Interfaces;
using Domain.Interfaces.InterfaceVereador;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationApp.OpenApp
{
    public class AppVereador : InterfaceVereadorApp
    {
        IVereador _IVereador;
        IServiceVereador _IServiceVereador;
        public AppVereador(IVereador IVereador, IServiceVereador IServiceVereador)
        {
            _IVereador = IVereador;
            _IServiceVereador = IServiceVereador;
        }


        public async Task AddVereador(Vereador Vereador)
        {
            await _IServiceVereador.AddVereador(Vereador);
        }
        public async Task UpdateVereador(Vereador Vereador)
        {
            await _IServiceVereador.UpdateVereador(Vereador);
        }

        public async Task<List<Vereador>> ListarVereadorUsuario()
        {
            return await _IVereador.ListarVereadorsUsuario();
        }

        public async Task Add(Vereador Objeto)
        {
            await _IVereador.Add(Objeto);
        }
        public async Task Delete(Vereador Objeto)
        {
            await _IVereador.Delete(Objeto);
        }
        public async Task<Vereador> GetEntityById(int Id)
        {
            return await _IVereador.GetEntityById(Id);
        }

        public async Task<List<Vereador>> List()
        {
            return await _IVereador.List();
        }

        public async Task Update(Vereador Objeto)
        {
            await _IVereador.Update(Objeto);
        }

    }
}

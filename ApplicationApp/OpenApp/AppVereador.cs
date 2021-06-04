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


       /* public async Task<List<Vereador>> ListarVereadorsCarrinhoUsuario(string userId)
        {
            return await _IVereador.ListarVereadorsCarrinhoUsuario(userId);
        }
*/
      /*  public async Task<Vereador> ObterVereadorCarrinho(int idVereadorCarrinho)
        {
            return await _IVereador.ObterVereadorCarrinho(idVereadorCarrinho);
        }

*/

        public async Task AddVereador(Vereador Vereador)
        {
            await _IServiceVereador.AddVereador(Vereador);
        }
        public async Task UpdateVereador(Vereador Vereador)
        {
            await _IServiceVereador.UpdateVereador(Vereador);
        }

        public async Task<List<Vereador>> ListarVereadorUsuario(string userId)
        {
            return await _IVereador.ListarVereadorsUsuario(userId);
        }

        /*public async Task<List<Vereador>> ListarVereadorsVendidos(string userId, string filtro)
        {
            return await _IVereador.ListarVereadorsVendidos(userId, filtro);
        }
*/

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

      /*  public async Task<List<Vereador>> ListarVereadorsComEstoque(string descricao)
        {
            return await _IServiceVereador.ListarVereadorComEstoque(descricao);
        }*/

       
    }
}

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

           /* var validaValor = Vereador.ValidarPropriedadeDecimal(Vereador.Valor, "Valor");

            var validaQtdEstoque = Vereador.ValidarPropriedadeInt(Vereador.QtdEstoque, "QtdEstoque");*/

            if (validaNome /*&& validaValor && validaQtdEstoque*/)
            {
                Vereador.DataCadastro = DateTime.Now;
                /*Vereador.DataAlteracao = DateTime.Now;
                Vereador.Estado = true;*/
                await _IVereador.Add(Vereador);
            }
        }

       /* public async Task<List<Vereador>> ListarVereadorComEstoque(string descricao)
        {
            if (string.IsNullOrWhiteSpace(descricao))
                return await _IVereador.ListarVereadors(p => p.QtdEstoque > 0);
            else
            {
                return await _IVereador.ListarVereadors(p => p.QtdEstoque > 0
                && p.Nome.ToUpper().Contains(descricao.ToUpper()));
            }
        }*/

        public async Task UpdateVereador(Vereador Vereador)
        {
            var validaNome = Vereador.ValidarPropriedadeString(Vereador.Nome, "Nome");

            /*var validaValor = Vereador.ValidarPropriedadeDecimal(Vereador.Valor, "Valor");

            var validaQtdEstoque = Vereador.ValidarPropriedadeInt(Vereador.QtdEstoque, "QtdEstoque");*/

            if (validaNome /*&& validaValor && validaQtdEstoque*/)
            {
                //Vereador.candidato.DataAlteracao = DateTime.Now;

                await _IVereador.Update(Vereador);
            }
        }
    }
}

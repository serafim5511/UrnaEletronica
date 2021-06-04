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

            /*var validaValor = Prefeito.ValidarPropriedadeDecimal(Prefeito.Valor, "Valor");

            var validaQtdEstoque = Prefeito.ValidarPropriedadeInt(Prefeito.QtdEstoque, "QtdEstoque");*/

            if (validaNome /*&& validaValor && validaQtdEstoque*/)
            {
                Prefeito.DataCadastro = DateTime.Now;
                await _IPrefeito.Add(Prefeito);
            }
        }

        /*public async Task<List<Prefeito>> ListarPrefeitosComEstoque(string descricao)
        {
            if (string.IsNullOrWhiteSpace(descricao))
                return await _IPrefeito.ListarPrefeitos(p => p.QtdEstoque > 0);
            else
            {
                return await _IPrefeito.ListarPrefeitos(p => p.QtdEstoque > 0
                && p.Nome.ToUpper().Contains(descricao.ToUpper()));
            }
        }*/

        public async Task UpdatePrefeito(Prefeito Prefeito)
        {
            var validaNome = Prefeito.ValidarPropriedadeString(Prefeito.Nome, "Nome");

           /*var validaValor = Prefeito.ValidarPropriedadeDecimal(Prefeito.Valor, "Valor");

            var validaQtdEstoque = Prefeito.ValidarPropriedadeInt(Prefeito.QtdEstoque, "QtdEstoque");*/

            if (validaNome /*&& validaValor && validaQtdEstoque*/)
            {
                //Prefeito.candidato.DataAlteracao = DateTime.Now;

                await _IPrefeito.Update(Prefeito);
            }
        }
    }
}

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

        Task<List<Prefeito>> ListarPrefeitoUsuario(string userId);

        //Task<List<Candidato>> ListarCandidatosComEstoque(string descricao);

        //Task<List<Candidato>> ListarCandidatosCarrinhoUsuario(string userId);

        //Task<Candidato> ObterCandidatoCarrinho(int idCandidatoCarrinho);

        //Task<List<Candidato>> ListarCandidatosVendidos(string userId, string filtro);
    }
}

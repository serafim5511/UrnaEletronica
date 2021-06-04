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

        Task<List<Vereador>> ListarVereadorUsuario(string userId);

        //Task<List<Candidato>> ListarCandidatosComEstoque(string descricao);

        //Task<List<Candidato>> ListarCandidatosCarrinhoUsuario(string userId);

        //Task<Candidato> ObterCandidatoCarrinho(int idCandidatoCarrinho);

        //Task<List<Candidato>> ListarCandidatosVendidos(string userId, string filtro);
    }
}

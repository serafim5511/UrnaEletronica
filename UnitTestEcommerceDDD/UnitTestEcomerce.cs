using Domain.Interfaces.InterfaceProduct;
using Domain.Interfaces.InterfaceServices;
using Domain.Services;
using Entities.Entities;
using Infrastructure.Repository.Repositories;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTestElevate
{
    [TestClass]
    public class UnitTestElevate
    {
        [TestMethod]
        public async Task AddProductComSucesso()
        {
            try
            {
                IProduct _IProduct = new RepositoryProduct();
                IServiceProduct _IServiceProduct = new ServiceProduct(_IProduct);
                var Candidato = new Candidato
                {
                    Descricao = string.Concat("Descrição Test TDD", DateTime.Now.ToString()),
                    QtdEstoque = 10,
                    Nome = string.Concat("Nome Test TDD", DateTime.Now.ToString()),
                    Valor = 20,
                    UserId = "c5fe6ba9-8f82-4881-84c5-c3b6a8732edb"
                };
                await _IServiceProduct.AddProduct(Candidato);

                Assert.IsFalse(Candidato.Notitycoes.Any());
            }
            catch (Exception)
            {

                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task AddProductComValidacaoCampoObrigatorio()
        {
            try
            {
                IProduct _IProduct = new RepositoryProduct();
                IServiceProduct _IServiceProduct = new ServiceProduct(_IProduct);
                var Candidato = new Candidato
                {

                };
                await _IServiceProduct.AddProduct(Candidato);

                Assert.IsTrue(Candidato.Notitycoes.Any());
            }
            catch (Exception)
            {

                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task ListarCandidatosUsuario()
        {

            try
            {
                IProduct _IProduct = new RepositoryProduct();

                var listaCandidatos = await _IProduct.ListarCandidatosUsuario("c5fe6ba9-8f82-4881-84c5-c3b6a8732edb");

                Assert.IsTrue(listaCandidatos.Any());
            }
            catch (Exception)
            {

                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task GetEntityById()
        {
            try
            {
                IProduct _IProduct = new RepositoryProduct();
                var listaCandidatos = await _IProduct.ListarCandidatosUsuario("c5fe6ba9-8f82-4881-84c5-c3b6a8732edb");
                var Candidato = await _IProduct.GetEntityById(listaCandidatos.LastOrDefault().Id);

                Assert.IsTrue(Candidato != null);
            }
            catch (Exception)
            {

                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task Delete()
        {
            try
            {
                IProduct _IProduct = new RepositoryProduct();
                var listaCandidatos = await _IProduct.ListarCandidatosUsuario("c5fe6ba9-8f82-4881-84c5-c3b6a8732edb");
                var ultimoCandidato = listaCandidatos.LastOrDefault();
                await _IProduct.Delete(ultimoCandidato);
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }


    }
}

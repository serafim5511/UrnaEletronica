using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Threading.Tasks;
using ApplicationApp.Interfaces;
using Entities.Entities;
using Entities.Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web_ECommerce.Controllers
{

    [Authorize]
    [LogActionFilter]
    public class VereadorController : BaseController
    {

        public readonly InterfaceVereadorApp _InterfaceVereadorApp;


        //private IWebHostEnvironment _environment;

        public VereadorController(InterfaceVereadorApp InterfaceVereadorApp, UserManager<ApplicationUser> userManager, ILogger<VereadorController> logger, IWebHostEnvironment environment)
            : base(logger, userManager)
        {
            _InterfaceVereadorApp = InterfaceVereadorApp;
        }

        // GET: VereadorController
        public async Task<IActionResult> Index()
        {
            var idUsuario = await RetornarIdUsuarioLogado();
            var test = await _InterfaceVereadorApp.ListarVereadorUsuario(idUsuario);

            return View(test);
        }

        // GET: VereadorController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var teste = await _InterfaceVereadorApp.GetEntityById(id);
            return View(teste);
        }

        // GET: VereadorController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: VereadorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vereador Vereador)
        {
            try
            {
                var idUsuario = await RetornarIdUsuarioLogado();

                Vereador.UserId = idUsuario;
                Vereador.partido = Titulo.Vereador;

                await _InterfaceVereadorApp.AddVereador(Vereador);
                if (Vereador.Notitycoes.Any())
                {
                    foreach (var item in Vereador.Notitycoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.mensagem);
                    }

                    return View("Create", Vereador);
                }

                await SalvarImagemVereador(Vereador);


            }
            catch (Exception erro)
            {

                return View("Create", Vereador);
            }

            return RedirectToAction(nameof(Index));

        }

        // GET: VereadorController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _InterfaceVereadorApp.GetEntityById(id));
        }

        // POST: VereadorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Vereador Vereador)
        {
            try
            {
                await _InterfaceVereadorApp.UpdateVereador(Vereador);
                if (Vereador.Notitycoes.Any())
                {
                    foreach (var item in Vereador.Notitycoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.mensagem);
                    }

                    ViewBag.Alerta = true;
                    ViewBag.Mensagem = "Verifique, ocorreu algum erro!";


                    return View("Edit", Vereador);
                }

            }
            catch (Exception erro)
            {

                return View("Edit", Vereador);
            }



            return RedirectToAction(nameof(Index));
        }

        // GET: VereadorController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _InterfaceVereadorApp.GetEntityById(id));
        }

        // POST: VereadorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Vereador Vereador)
        {
            try
            {
                var VereadorDeletar = await _InterfaceVereadorApp.GetEntityById(id);

                await _InterfaceVereadorApp.Delete(VereadorDeletar);


                return RedirectToAction(nameof(Index));
            }
            catch (Exception erro)
            {
                return View();
            }
        }


       /* public async Task<IActionResult> DashboardVendas()
        {
            ModelPai pai =new ModelPai();
            var usuario = await _userManager.GetUserAsync(User);
            pai.Total= await _InterfaceCompraUsuarioApp.MinhasCompras(usuario.Id);
            var idUsuario = await RetornarIdUsuarioLogado();
            pai.Carrinho = await _InterfaceVereadorApp.ListarVereadorCarrinhoUsuario(idUsuario);
            return View(pai);
        }*/


        /*[HttpGet("/api/ListarVereadorVendidos")]
        public async Task<JsonResult> ListarVereadorVendidos(string filtro)
        {
            var idUsuario = await RetornarIdUsuarioLogado();

            return Json(await _InterfaceVereadorApp.ListarVereadorVendidos(idUsuario, filtro));
        }
*/

        /*[AllowAnonymous]
        [HttpGet("/api/ListarVereadorComEstoque")]
        public async Task<JsonResult> ListarVereadorComEstoque(string descricao)
        {
            return Json(await _InterfaceVereadorApp.ListarVereadorComEstoque(descricao));
        }
*/
       /* public async Task<IActionResult> ListarVereadorCarrinhoUsuario()
        {
            var idUsuario = await RetornarIdUsuarioLogado();
            return View(await _InterfaceVereadorApp.ListarVereadorCarrinhoUsuario(idUsuario));

        }*/

       /* // GET: VereadorController/Delete/5
        public async Task<IActionResult> RemoverCarrinho(int id)
        {
            return View(await _InterfaceVereadorApp.ObterVereadorCarrinho(id));
        }*/

       /* // POST: VereadorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoverCarrinho(int id, Vereador Vereador)
        {
            try
            {
                var VereadorDeletar = await _InterfaceCompraUsuarioApp.GetEntityById(id);

                await _InterfaceCompraUsuarioApp.Delete(VereadorDeletar);

                return RedirectToAction(nameof(ListarVereadorCarrinhoUsuario));
            }
            catch (Exception erro)
            {
                await LogEcommerce(EnumTipoLog.Erro, erro);
                return View();
            }
        }*/

        public async Task SalvarImagemVereador(Vereador VereadorTela)
        {
            try
            {
                var Vereador = await _InterfaceVereadorApp.GetEntityById(VereadorTela.Id);

                if (VereadorTela.Imagem != null)
                {

                    var permissionSet = new PermissionSet(PermissionState.Unrestricted);

                    var Extension = System.IO.Path.GetExtension(VereadorTela.Imagem.FileName);

                    var NomeArquivo = string.Concat(Vereador.Id.ToString(), Extension);



                    Vereador.Url = string.Concat("https://localhost:5001", "/imgVereador/", NomeArquivo);

                    await _InterfaceVereadorApp.UpdateVereador(Vereador);
                }
            }
            catch (Exception erro)
            {
            }

        }


    }
}

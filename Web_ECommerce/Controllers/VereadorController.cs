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

        private IWebHostEnvironment _environment;


        public VereadorController(InterfaceVereadorApp InterfaceVereadorApp, UserManager<ApplicationUser> userManager, ILogger<VereadorController> logger, IWebHostEnvironment environment)
            : base(logger, userManager)
        {
            _InterfaceVereadorApp = InterfaceVereadorApp;
            _environment = environment;
        }

        // GET: VereadorController
        public async Task<IActionResult> Index()
        {
            var idUsuario = await RetornarIdUsuarioLogado();
            var test = await _InterfaceVereadorApp.ListarVereadorUsuario();

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
                var test = await _InterfaceVereadorApp.ListarVereadorUsuario();

                foreach (var item in test)
                {
                    if (item.Numero == Vereador.Numero)
                    {
                        ViewBag.existeNumero = "Ja existe esse numero";
                        return View("Create", Vereador);
                    }
                }

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

        [HttpGet("/api/RetornoVereador")]
        public async Task<IActionResult> RetornoVereador()
        {
            var idUsuario = await RetornarIdUsuarioLogado();
            var teste = await _InterfaceVereadorApp.ListarVereadorUsuario();
            return Json(teste);
        }

        // POST: VereadorController/Delete/5
        [HttpPost("/api/VotacaoVereador")]
        public async Task<IActionResult> VotacaoVereador(int id)
        {
            var resul = await _InterfaceVereadorApp.GetEntityById(id);
            resul.voto++;
             await _InterfaceVereadorApp.UpdateVereador(resul);

            return Json("");
        }

        public async Task SalvarImagemVereador(Vereador VereadorTela)
        {
            try
            {
                var Vereador = await _InterfaceVereadorApp.GetEntityById(VereadorTela.Id);

                if (VereadorTela.Imagem != null)
                {
                    var prefeito = await _InterfaceVereadorApp.GetEntityById(VereadorTela.Id);


                    var webRoot = _environment.WebRootPath;
                    var permissionSet = new PermissionSet(PermissionState.Unrestricted);
                    var writePermission = new FileIOPermission(FileIOPermissionAccess.Append, string.Concat(webRoot, "/imgPrefeito"));
                    permissionSet.AddPermission(writePermission);

                    var Extension = System.IO.Path.GetExtension(VereadorTela.Imagem.FileName);

                    var NomeArquivo = string.Concat(VereadorTela.Id.ToString(), Extension);

                    var diretorioArquivoSalvar = string.Concat(webRoot, "\\imgPrefeito\\", NomeArquivo);

                    VereadorTela.Imagem.CopyTo(new FileStream(diretorioArquivoSalvar, FileMode.Create));

                    prefeito.Url = string.Concat("https://localhost:5001", "/imgPrefeito/", NomeArquivo);

                    await _InterfaceVereadorApp.UpdateVereador(prefeito);
                }
            }
            catch (Exception erro)
            {
            }

        }


    }
}

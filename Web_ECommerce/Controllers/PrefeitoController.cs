using System;
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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web_ECommerce.Controllers
{

    [Authorize]
    [LogActionFilter]
    public class PrefeitoController : BaseController
    {

        public readonly InterfacePrefeitoApp _InterfacePrefeitoApp;
        private IWebHostEnvironment _environment;

        public PrefeitoController(InterfacePrefeitoApp InterfacePrefeitoApp, UserManager<ApplicationUser> userManager, ILogger<PrefeitoController> logger, IWebHostEnvironment environment)
            : base(logger, userManager)
        {
            _InterfacePrefeitoApp = InterfacePrefeitoApp;
            _environment = environment;
        }

        // GET: PrefeitoController
        public async Task<IActionResult> Index()
        {
            var idUsuario = await RetornarIdUsuarioLogado();
            var test = await _InterfacePrefeitoApp.ListarPrefeitoUsuario(idUsuario);

            return View(test);
        }

        // GET: PrefeitoController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var teste = await _InterfacePrefeitoApp.GetEntityById(id);
            return View(teste);
        }

        // GET: PrefeitoController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: PrefeitoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Prefeito Prefeito)
        {
            try
            {
                var idUsuario = await RetornarIdUsuarioLogado();

                Prefeito.UserId = idUsuario;
                Prefeito.partido = Titulo.Prefeito;

                await _InterfacePrefeitoApp.AddPrefeito(Prefeito);
                if (Prefeito.Notitycoes.Any())
                {
                    foreach (var item in Prefeito.Notitycoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.mensagem);
                    }

                    return View("Create", Prefeito);
                }

                await SalvarImagemPrefeito(Prefeito);


            }
            catch (Exception erro)
            {

                return View("Create", Prefeito);
            }

            return RedirectToAction(nameof(Index));

        }

        // GET: PrefeitoController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _InterfacePrefeitoApp.GetEntityById(id));
        }

        // POST: PrefeitoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Prefeito Prefeito)
        {
            try
            {
                await _InterfacePrefeitoApp.UpdatePrefeito(Prefeito);
                if (Prefeito.Notitycoes.Any())
                {
                    foreach (var item in Prefeito.Notitycoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.mensagem);
                    }

                    ViewBag.Alerta = true;
                    ViewBag.Mensagem = "Verifique, ocorreu algum erro!";


                    return View("Edit", Prefeito);
                }

            }
            catch (Exception erro)
            {

                return View("Edit", Prefeito);
            }



            return RedirectToAction(nameof(Index));
        }

        // GET: PrefeitoController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _InterfacePrefeitoApp.GetEntityById(id));
        }

        // POST: PrefeitoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Prefeito Prefeito)
        {
            try
            {
                var PrefeitoDeletar = await _InterfacePrefeitoApp.GetEntityById(id);

                await _InterfacePrefeitoApp.Delete(PrefeitoDeletar);


                return RedirectToAction(nameof(Index));
            }
            catch (Exception erro)
            {
                return View();
            }
        }

        [HttpGet("/api/RetornoCandidatos")]
        public async Task<IActionResult> RetornoCandidatos()
        {
            
            var idUsuario = await RetornarIdUsuarioLogado();
            var teste =await _InterfacePrefeitoApp.ListarPrefeitoUsuario(idUsuario);
            return Json(teste);
        }


/*[HttpGet("/api/ListarPrefeitoVendidos")]
public async Task<JsonResult> ListarPrefeitoVendidos(string filtro)
{
    var idUsuario = await RetornarIdUsuarioLogado();

    return Json(await _InterfacePrefeitoApp.ListarPrefeitoVendidos(idUsuario, filtro));
}


[AllowAnonymous]
[HttpGet("/api/ListarPrefeitoComEstoque")]
public async Task<JsonResult> ListarPrefeitoComEstoque(string descricao)
{
    return Json(await _InterfacePrefeitoApp.ListarPrefeitoComEstoque(descricao));
}

public async Task<IActionResult> ListarPrefeitoCarrinhoUsuario()
{
    var idUsuario = await RetornarIdUsuarioLogado();
    return View(await _InterfacePrefeitoApp.ListarPrefeitoCarrinhoUsuario(idUsuario));

}

// GET: PrefeitoController/Delete/5
public async Task<IActionResult> RemoverCarrinho(int id)
{
    return View(await _InterfacePrefeitoApp.ObterPrefeitoCarrinho(id));
}

// POST: PrefeitoController/Delete/5
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> RemoverCarrinho(int id, Prefeito Prefeito)
{
    try
    {
        var PrefeitoDeletar = await _InterfaceCompraUsuarioApp.GetEntityById(id);

        await _InterfaceCompraUsuarioApp.Delete(PrefeitoDeletar);

        return RedirectToAction(nameof(ListarPrefeitoCarrinhoUsuario));
    }
    catch (Exception erro)
    {
        await LogEcommerce(EnumTipoLog.Erro, erro);
        return View();
    }
}
*/
        public async Task SalvarImagemPrefeito(Prefeito PrefeitoTela)
        {
            try
            {
                var Prefeito = await _InterfacePrefeitoApp.GetEntityById(PrefeitoTela.Id);

                if (PrefeitoTela.Imagem != null)
                {
                    var prefeito = await _InterfacePrefeitoApp.GetEntityById(PrefeitoTela.Id);


                    var webRoot = _environment.WebRootPath;
                    var permissionSet = new PermissionSet(PermissionState.Unrestricted);
                    var writePermission = new FileIOPermission(FileIOPermissionAccess.Append, string.Concat(webRoot, "/imgPrefeito"));
                    permissionSet.AddPermission(writePermission);

                    var Extension = System.IO.Path.GetExtension(PrefeitoTela.Imagem.FileName);

                    var NomeArquivo = string.Concat(PrefeitoTela.Id.ToString(), Extension);

                    var diretorioArquivoSalvar = string.Concat(webRoot, "\\imgPrefeito\\", NomeArquivo);

                    PrefeitoTela.Imagem.CopyTo(new FileStream(diretorioArquivoSalvar, FileMode.Create));

                    prefeito.Url = string.Concat("https://localhost:5001", "/imgPrefeito/", NomeArquivo);

                    await _InterfacePrefeitoApp.UpdatePrefeito(prefeito);
                }
            }
            catch (Exception erro)
            {
            }

        }


    }
}

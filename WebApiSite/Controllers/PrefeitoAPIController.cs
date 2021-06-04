using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationApp.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApiSite.Controllers
{
    [Authorize]
    public class PrefeitoAPIController : Controller
    {

        public readonly InterfacePrefeitoApp _InterfacePrefeitoApp;

        public PrefeitoAPIController(InterfacePrefeitoApp InterfacePrefeitoApp)
        {
            _InterfacePrefeitoApp = InterfacePrefeitoApp;
        }


        [HttpGet("/api/ListaPrefeito")]
        public async Task<JsonResult> ListaPrefeito(string descricao)
        {
            return Json(await _InterfacePrefeitoApp.ListarPrefeitoUsuario(descricao));
        }

    }
}

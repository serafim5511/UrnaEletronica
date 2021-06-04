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
    public class VereadorAPIController : Controller
    {

        public readonly InterfaceVereadorApp _InterfaceVereadorApp;

        public VereadorAPIController(InterfaceVereadorApp InterfaceVereadorApp)
        {
            _InterfaceVereadorApp = InterfaceVereadorApp;
        }


        [HttpGet("/api/ListaVereador")]
        public async Task<JsonResult> ListaVereadors(string descricao)
        {
            return Json(await _InterfaceVereadorApp.ListarVereadorUsuario(descricao));
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationApp.Interfaces;
using Entities.Entities;
using Entities.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Web_ECommerce.Controllers
{
    public class BaseController : Controller
    {
        public readonly ILogger<BaseController> logger;

        public readonly UserManager<ApplicationUser> _userManager;


        public BaseController(ILogger<BaseController> logger, UserManager<ApplicationUser> userManager)
        {
            this.logger = logger;
            this._userManager = userManager;
        }

        public async Task<string> RetornarIdUsuarioLogado()
        {
            if (_userManager != null)
            {
                var idUsuario = await _userManager.GetUserAsync(User);
                return idUsuario != null ? idUsuario.Id : string.Empty;
            }
            return string.Empty;
        }

        public async Task<bool> UsuarioAdministrador()
        {
            if (_userManager != null)
            {
                var idUsuario = await _userManager.GetUserAsync(User);
                if (idUsuario != null && idUsuario.Tipo != null)
                {
                    if ((TipoUsuario)idUsuario.Tipo == TipoUsuario.Administrador)
                        return true;
                }
            }
            return false;
        }



        

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

using System.Linq;
using Dapper; // Importación de Dapper
using System.Data.SqlClient;
using ManejoPresupuesto.Models;
using ManejoPresupuesto.Servicios;

namespace ManejoPresupuesto.Controllers
{
    public class TiposCuentasController : Controller
    {
        private readonly IRepositorioTiposCuentas repositorioTiposCuentas;

        public TiposCuentasController(IRepositorioTiposCuentas repositorioTiposCuentas)
        {
            this.repositorioTiposCuentas = repositorioTiposCuentas;
        }

        public IActionResult Crear()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Crear(TipoCuenta tipoCuenta)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoCuenta);
            }
            tipoCuenta.UsuarioId = 1;
            repositorioTiposCuentas.Crear(tipoCuenta);
            return View();
        }
    }
}

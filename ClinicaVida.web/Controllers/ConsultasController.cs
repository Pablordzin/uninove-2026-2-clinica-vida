using ClinicaVida.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClinicaVida.Web.Controllers;

public class ConsultasController : Controller
{
    [HttpGet]
    public IActionResult Agendar()
    {
        CarregarListas();
        return View(new Consulta { Data = DateTime.Today });
    }

    private void CarregarListas()
    {
        ViewBag.Pacientes = new SelectList(ClinicaEmMemoria.Pacientes, "Id", "Nome");
        ViewBag.Medicos   = new SelectList(ClinicaEmMemoria.Medicos,   "Id", "Nome");
    }
}
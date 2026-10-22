
using ClinicaVida.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVida.Web.Controllers;

public class MedicosController : Controller
{
    public IActionResult Index(int? especialidadeId)
    {
        var medicos = ClinicaEmMemoria.Medicos
            .Select(m => new Medico
            {
                Id = m.Id,
                Nome = m.Nome,
                Crm = m.Crm,
                EspecialidadeId = m.EspecialidadeId,
                Especialidade = ClinicaEmMemoria.ObterEspecialidadePorId(m.EspecialidadeId)
            })
            .Where(m => especialidadeId == null || m.EspecialidadeId == especialidadeId)
            .OrderBy(m => m.Nome)
            .ToList();

        ViewBag.Especialidades = ClinicaEmMemoria.Especialidades;
        ViewBag.EspecialidadeSelecionada = especialidadeId;

        return View(medicos);
    }

    public IActionResult Details(int id)
    {
        var medico = ClinicaEmMemoria.ObterMedicoPorId(id);

        if (medico == null)
        {
            return NotFound();
        }

        medico.Especialidade =
            ClinicaEmMemoria.ObterEspecialidadePorId(medico.EspecialidadeId);

        return View(medico);
    }

    public IActionResult ContagemPorEspecialidade()
    {
        var contagem = ClinicaEmMemoria.Medicos
            .GroupBy(m => m.EspecialidadeId)
            .ToDictionary(
                grupo => grupo.Key,
                grupo => grupo.Count()
            );

        ViewBag.Especialidades = ClinicaEmMemoria.Especialidades;
        return View(contagem);
    }
}

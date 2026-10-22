namespace ClinicaVida.Web.Models;

public static class ClinicaEmMemoria
{
    public static List<Especialidade> Especialidades { get; } = new()
    {
        new Especialidade { Id = 1, Nome = "Cardiologia", Descricao = "Cuidados com o coração." },
        new Especialidade { Id = 2, Nome = "Dermatologia", Descricao = "Cuidados com a pele." },
        new Especialidade { Id = 3, Nome = "Ortopedia", Descricao = "Cuidados com ossos e articulações." },
        new Especialidade { Id = 4, Nome = "Pediatria", Descricao = "Cuidados com a saúde infantil." }
    };

    public static List<Medico> Medicos { get; } = new()
    {
        new Medico { Id = 1, Nome = "Ana Souza", Crm = "123456-SP", EspecialidadeId = 1 },
        new Medico { Id = 2, Nome = "Bruno Lima", Crm = "234567-SP", EspecialidadeId = 1 },
        new Medico { Id = 3, Nome = "Carla Mendes", Crm = "345678-SP", EspecialidadeId = 2 },
        new Medico { Id = 4, Nome = "Diego Alves", Crm = "456789-SP", EspecialidadeId = 2 },
        new Medico { Id = 5, Nome = "Eduarda Costa", Crm = "567890-SP", EspecialidadeId = 3 },
        new Medico { Id = 6, Nome = "Felipe Santos", Crm = "678901-SP", EspecialidadeId = 4 }
    };

    public static Medico? ObterMedicoPorId(int id)
    {
        return Medicos.FirstOrDefault(m => m.Id == id);
    }

    public static Especialidade? ObterEspecialidadePorId(int id)
    {
        return Especialidades.FirstOrDefault(e => e.Id == id);
    }
}
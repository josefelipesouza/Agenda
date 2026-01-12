using Api.Domain.Enums;

namespace Api.Domain.Entities;

public class AgendaVisitaTecnica
{
    public Guid Id { get; private set; }
    public DateOnly Data { get; private set; }
    public TimeOnly Horario { get; private set; }
    public int DuracaoVisitaMinutos { get; private set; }

    public Guid ClienteId { get; private set; }
    public string TecnicoId { get; private set; } // IdentityUser

    public string UsuarioLancamentoId { get; private set; }
    public DateTime DataLancamento { get; private set; }
    public DateTime? DataAlteracao { get; private set; }

    public StatusAgenda Status { get; private set; }

    protected AgendaVisitaTecnica() { }

    public AgendaVisitaTecnica(
        DateOnly data,
        TimeOnly horario,
        int duracao,
        Guid clienteId,
        string tecnicoId,
        string usuarioLancamentoId)
    {
        Id = Guid.NewGuid();
        Data = data;
        Horario = horario;
        DuracaoVisitaMinutos = duracao;
        ClienteId = clienteId;
        TecnicoId = tecnicoId;
        UsuarioLancamentoId = usuarioLancamentoId;
        DataLancamento = DateTime.UtcNow;
        Status = StatusAgenda.Agendado;
    }

    public void Cancelar()
    {
        Status = StatusAgenda.Cancelado;
        DataAlteracao = DateTime.UtcNow;
    }
}

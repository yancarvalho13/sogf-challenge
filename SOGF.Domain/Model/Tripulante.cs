namespace SOGF.Domain.Model;

public sealed class Tripulante : BaseModel
{
    public string Nome { get; private set; }
    public Patente Patente { get; private set; }
    
    public long? NavePilotadaId { get; private set; }
    public Nave? NavePilotada { get; private set; }
    public Especialidade Especialidade { get; private set; }
    public ICollection<RelatorioCombate> HistoricoDeCombates { get; private set; } = new List<RelatorioCombate>();

    public ICollection<RelatorioCombate> HistoricoDeDerrotas { get; private set; } = new List<RelatorioCombate>();
    public long? NaveAtualId { get; private set; }
    public Nave? NaveAtual { get; private set; }
}
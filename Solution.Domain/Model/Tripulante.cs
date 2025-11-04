namespace Solution.Domain.Model;

public sealed class Tripulante : BaseModel
{
    public string Nome { get; private set; }
    public Patente Patente { get; private set; }
    public Especialidade Especialidade { get; private set; }
    public List<RelatorioCombate> HistoricoDeCombates { get; private set; }
    
    public Nave? NaveAtual { get; private set; }
}
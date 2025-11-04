namespace Solution.Domain.Model;

public sealed class RelatorioCombate : BaseModel
{
    public DateTime Data { get; private set; }
    public ResultadoCombate Resultado { get; private set; }
    public string DescricaoDeEventos { get; private set; }
    
    public long PilotoVencedorId { get; private set;}
    public Tripulante PilotoVencedor { get; private set; }
    public long PilotoPerdedorId { get; private set; }
}
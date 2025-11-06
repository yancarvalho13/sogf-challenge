namespace SOGF.Domain.Model;

public sealed class RelatorioCombate : BaseEntity
{
    public DateTime Data { get; private set; }
    public ResultadoCombate Resultado { get; private set; }
    
    public string DescricaoTatica { get; private set;}
    
    public long FaccaoVencedoraId { get; private set; }
    
    public List<EngajamentoCombate> NavesEngajadas {get; private set;}
    
    
}
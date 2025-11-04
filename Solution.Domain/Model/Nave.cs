namespace Solution.Domain.Model;

public sealed class Nave : BaseModel
{
    public string Nome { get; private set; }
    public TipoNave Classe { get; private set; }
    public Tripulante Piloto { get; private set;}
    public List<Tripulante> Tripulantes { get; private set; }
    public StatusOperacional Status { get; private set; }
    
    
}
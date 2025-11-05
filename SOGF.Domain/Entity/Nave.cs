namespace SOGF.Domain.Model;

public sealed class Nave : BaseModel
{
    public string Nome { get; private set; }
    public TipoNave Classe { get; private set; }
    public Tripulante? Piloto { get; private set;}
    public ICollection<Tripulante> Tripulantes { get; private set; } = new List<Tripulante>(); 
    public StatusOperacional Status { get; private set; }

    public ICollection<Missao>? Missoes { get; private set; } = new List<Missao>();

    public Nave() {}

    public Nave(string nome, TipoNave classe, Tripulante? piloto, StatusOperacional status)
    {
        Nome = nome;
        Classe = classe;
        Piloto = piloto;
        Status = status;
    }

  

    public void EnlistTripulante(Tripulante tripulante)
    {
        Tripulantes.Add(tripulante);
    }

    public Nave(string nome, TipoNave classe, StatusOperacional status)
    {
        Nome = nome;
        Classe = classe;
        Status = status;
    }

    public long PilotId()
    {
        return PilotId();
    }
}
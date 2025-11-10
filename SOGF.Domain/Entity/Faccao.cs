namespace SOGF.Domain.Model;

public sealed class Faccao : BaseEntity
{
    public string Nome {get; private set;}
    public StatusDiplomatico StatusDiplomatico {get; private set;}
    public NivelAmeaca NivelAmeaca {get; private set;}
    public List<Nave>? Naves { get; private set; } = new List<Nave>();

    public Faccao()
    {
    }

    public Faccao(string nome, StatusDiplomatico statusDiplomatico, NivelAmeaca nivelAmeaca)
    {
        Nome = nome;
        StatusDiplomatico = statusDiplomatico;
        NivelAmeaca = nivelAmeaca;
    }
    
    public Faccao(string nome, StatusDiplomatico statusDiplomatico, NivelAmeaca nivelAmeaca, List<Nave> naves)
    {
        Nome = nome;
        StatusDiplomatico = statusDiplomatico;
        NivelAmeaca = nivelAmeaca;
        Naves = naves;
    }
}
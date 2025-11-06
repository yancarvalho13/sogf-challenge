namespace SOGF.Domain.Model;

public sealed class Nave : BaseEntity
{
    public string Nome { get; private set; }
    public TipoNave Classe { get; private set; }
    
    public long CapacidadeTripulacao { get; private set; }
 
    public StatusOperacional Status { get; private set; }

    public  long FaccaoId { get; private set; }
    
    public Faccao Faccao { get; private set; }

    public Nave() {}

    public Nave(string nome, TipoNave classe, long capacidadeTripulacao, StatusOperacional status, long faccaoId)
    {
        Nome = nome;
        Classe = classe;
        CapacidadeTripulacao = capacidadeTripulacao;
        Status = status;
        FaccaoId = faccaoId;
    }

    public long PilotId()
    {
        return PilotId();
    }
}
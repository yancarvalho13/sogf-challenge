namespace SOGF.Domain.Model;

public sealed class Missao : BaseEntity
{
    public ObjetivoMissao ObjetivoMissao { get; private set; }
    public SetorGalatico SetorGalatico { get; private set; }
    public StatusMissao StatusMissao { get; private set; }
    public long NaveId { get; private set; }
    public long PilotoId { get; private set; }
    public List<MissaoTripulantes> Tripulantes { get; private set; } = [];

    public Missao()
    {
        
    }
    public Missao(ObjetivoMissao objetivoMissao, SetorGalatico setorGalatico, StatusMissao statusMissao, long naveId, long pilotoId, List<MissaoTripulantes> tripulantes)
    
    {
        ObjetivoMissao = objetivoMissao;
        SetorGalatico = setorGalatico;
        StatusMissao = statusMissao;
        NaveId = naveId;
        PilotoId = pilotoId;
        Tripulantes = tripulantes;
    }
}
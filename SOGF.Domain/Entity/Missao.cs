namespace SOGF.Domain.Model;

public sealed class Missao : BaseModel
{
    public string Descricao { get; private set; }
    public StatusMissao Status { get; private set; }
    public long? NaveDesignadaId { get; private set; }
    public Nave? NaveDesignada { get; private set; }
    
}
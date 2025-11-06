namespace SOGF.Domain.Model;

public class EngajamentoCombate : BaseEntity
{
    public long NaveId { get; private set; }
    public long PilotoId { get; private set; }
    public long RelatorioCombateId { get; private set; }
    public long MissaoId { get; private set; }
    public ResultadoCombate Resultado { get; private set; }
}
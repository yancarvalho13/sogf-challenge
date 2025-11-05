namespace SOGF.Domain.Model;

public class Tripulante : BaseModel
{
    public string Nome { get; private set; }
    public Patente Patente { get; private set; }
    public Especialidade Especialidade { get; private set; }
    public virtual List<RelatorioCombate> Vitorias { get; set; }
    public virtual List<RelatorioCombate> Derrotas { get; set; }

    public Tripulante(string nome, Patente patente, Especialidade especialidade)
    {
        Nome = nome;
        Patente = patente;
        Especialidade = especialidade;
    }
    
}
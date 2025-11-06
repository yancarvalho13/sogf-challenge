namespace SOGF.Domain.Model;

public class Tripulante : BaseEntity
{
    public string Nome { get; private set; }
    public Patente Patente { get; private set; }
    public Especialidade Especialidade { get; private set; }
    public Tripulante(string nome, Patente patente, Especialidade especialidade)
    {
        Nome = nome;
        Patente = patente;
        Especialidade = especialidade;
    }
    
}
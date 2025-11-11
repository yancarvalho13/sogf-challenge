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
    public Tripulante(long id,string nome, Patente patente, Especialidade especialidade) : base(id)
    {
        Id = id;
        Nome = nome;
        Patente = patente;
        Especialidade = especialidade;
    }
    
}
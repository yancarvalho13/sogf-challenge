namespace SOGF.Domain.Model;

public class Piloto : BaseEntity
{
    public string Nome { get; private set; }
    
    public Patente Patente { get; private set; }
    
  
    public Piloto(string nome, Patente patente)
    {
        Nome = nome;
        Patente = patente;
    }
    
    public Piloto(long id,string nome, Patente patente) : base(id)
    {
        Id = id;
        Nome = nome;
        Patente = patente;
    }
}
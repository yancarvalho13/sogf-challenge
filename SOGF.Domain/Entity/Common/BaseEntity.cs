namespace SOGF.Domain.Model;

public abstract class BaseEntity
{
    public long Id { get;  set; }
    public DateTime DataCriacao { get; } 
    public DateTime DataAtualizacao { get; } 

    protected BaseEntity(long id)
    {
        Id = id;
    }

    protected BaseEntity()
    {
    }
}
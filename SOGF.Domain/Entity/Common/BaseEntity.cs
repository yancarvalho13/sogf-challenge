namespace SOGF.Domain.Model;

public abstract class BaseEntity
{
    public long Id { get; }
    public DateTime DataCriacao { get; } = DateTime.Now;
    public DateTime DataAtualizacao { get; } =  DateTime.Now;
}
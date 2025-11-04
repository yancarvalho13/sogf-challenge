namespace Solution.Domain.Model;

public abstract class BaseModel
{
    public long Id { get; }
    public DateTime DataCriacao { get; }
    public DateTime DataAtualizacao { get; }
}
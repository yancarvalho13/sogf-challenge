using SOGF.Shared.Result;

namespace Solution.Application.Contracts.Adapters;

public interface ILlMAdapter
{
    Task<Result<string>> Consult(string prompt);
}
using SOGF.Domain.Entity.Result;
using Solution.Application;
using Solution.Application.Dto;

namespace Solution.Api.Contracts;

public interface ILlMAdapter
{
    Task<Result<string>> Consult(string prompt);
}
using SOGF.Domain.Model;

namespace Solution.Application.Dto;

public record CreateNaveRequest(string nome, TipoNave classe, StatusOperacional status);
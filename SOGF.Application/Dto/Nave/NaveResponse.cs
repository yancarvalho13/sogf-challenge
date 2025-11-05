using SOGF.Domain.Model;

namespace Solution.Application.Dto;

public record NaveResponse(string nome, TipoNave classe, StatusOperacional status);
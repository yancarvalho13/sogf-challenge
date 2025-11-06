using SOGF.Domain.Model;

namespace Solution.Application.Dto;

public record CreateNaveRequest(string nome, TipoNave classe,long capacidadeTripulacao, StatusOperacional status, long faccaoId);
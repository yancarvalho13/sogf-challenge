using SOGF.Domain.Model;

namespace Solution.Application.Dto;

public record NaveResponse(long id,string nome, TipoNave classe
    ,long capacidadeTripulacao, StatusOperacional status,long faccaoId);
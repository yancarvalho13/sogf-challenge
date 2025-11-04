using Solution.Domain.Model;

namespace Solution.Application.Request;

public record NaveRequest(string nome, TipoNave TipoNave, StatusOperacional StatusOperacional);
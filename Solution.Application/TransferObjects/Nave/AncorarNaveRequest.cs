using Solution.Domain.Model;

namespace Solution.Application.TransferObjects.Nave;

public sealed record AncorarNaveRequest(string nome, string tipoNave, long pilotoId, string statusOperacional);
using SOGF.Domain.Entity.Enum;
using SOGF.Domain.Model;
using SOGF.Shared.Result;
using Solution.Application.Contracts.Adapters;
using Solution.Application.Contracts.Mapping;
using Solution.Application.Contracts.Persistence;
using Solution.Application.Contracts.Service;
using Solution.Application.Dto.RelatorioCombate;

namespace Solution.Application.Service.Combate;

public class RelatorioCombateService : IRelatorioCombateService
{
    private readonly IRelatorioCombateMapper _mapper;
    private readonly IRelatorioCombateRepository _repository;
    private readonly ILlMAdapter _adapter;
    private readonly IMissaoRepository _missaoRepository;
    private readonly INaveRepository _naveRepository;
    private readonly ITripulanteRepository _tripulanteRepository;
    private readonly IPilotoRepository _pilotoRepository;
    public RelatorioCombateService(IRelatorioCombateRepository repository, ILlMAdapter adapter, IMissaoRepository missaoRepository, ITripulanteRepository tripulanteRepository, IPilotoRepository pilotoRepository, INaveRepository naveRepository, IRelatorioCombateMapper mapper)
    {
        _repository = repository;
        _adapter = adapter;
        _missaoRepository = missaoRepository;
        _tripulanteRepository = tripulanteRepository;
        _pilotoRepository = pilotoRepository;
        _naveRepository = naveRepository;
        _mapper = mapper;
    }

    public async Task<Result<RelatorioCombateResponse>> IniciarCombate()
    {
        var rng = new Random();
        var naves = await _naveRepository.GetAllAsync();
        var pilotos = await _pilotoRepository.GetAllAsync();
        
        
        var missoes = await _missaoRepository.GetMissoesEmAndamento();
        var vencedor = missoes[rng.Next(missoes.Count)];
        var naveVencedora = await _naveRepository.GetByIdAsync(vencedor.NaveId);
        var pilotoVencedor = await _pilotoRepository.GetByIdAsync(vencedor.PilotoId);
        var perdores = missoes.Where(m => m.Id != vencedor.Id).ToList();
        var navesPerdoras = naves.Where(n => perdores.Any(m => m.NaveId == n.Id)).ToList();
        var pilotosPerdoras = pilotos.Where(p => perdores.Any(m => m.PilotoId == p.Id)).ToList();
        
        var prompt = 
            $"No vasto universo de Star Wars, ocorreu um encontro entre {missoes.Count} naves. " +
            $"A nave vencedora foi **{naveVencedora.Nome}**, comandada pelo piloto **{pilotoVencedor.Nome}**. " +
            $"As naves derrotadas foram {string.Join(", ", navesPerdoras.Select(n => n.Nome))}, " +
            $"tripuladas por {string.Join(", ", pilotosPerdoras.Select(p => p.Nome))}. " +
            "Com base nesses dados, gere um relatório de combate cinematográfico, " +
            "descrevendo o confronto em estilo narrativo épico, digno da saga Star Wars. " +
            "Limite a resposta a 400 caracteres.";

        var descricao = await _adapter.Consult(prompt);

        var engajamentos = new List<EngajamentoCombate>();
        
        engajamentos.Add(new EngajamentoCombate(
            vencedor.NaveId,
            vencedor.PilotoId,
            vencedor.Id,
            ResultadoCombate.Vitoria));

        foreach (var m in perdores)
        {
            engajamentos.Add(new EngajamentoCombate(
                m.NaveId,
                m.PilotoId,
                m.Id,
                ResultadoCombate.Derrota));
        }

        var relatorio = new RelatorioCombate(
            DateTime.Now,
            ResultadoCombate.Vitoria,
            descricao.Value,
            naveVencedora.FaccaoId,
            engajamentos);

        await _repository.CreateAsync(relatorio);

        return _mapper.ToDto(relatorio);    
    }

    public async Task<Result<IEnumerable<RelatorioCombateResponse>>> GetAllAsync()
    {
        var relatorios = await _repository.GetAllAsync();

        var response = relatorios
            .Select(x => _mapper.ToDto(x))
            .ToList();

        return response;
    }

    public async Task<Result<HistoricoCombateResponse>> BuscarRelatorioPiloto(long id)
    {
        
        var relatorios = await _repository.GetAllAsync();
        var vitorias = relatorios.Where(r
            => r.NavesEngajadas.Any(ne =>
                ne.PilotoId == id && ne.Resultado == ResultadoCombate.Vitoria)).ToList();
        
        var derrotas = relatorios.Where(r
            => r.NavesEngajadas.Any(ne =>
                ne.PilotoId == id && ne.Resultado == ResultadoCombate.Derrota)).ToList();

        var relatorioDoPiloto = new List<RelatorioCombate>();
        relatorioDoPiloto.AddRange(vitorias);
        relatorioDoPiloto.AddRange(derrotas);
        var response = _mapper.ToHistoricoDto(vitorias, derrotas);
        
        return response;
    }

    public async Task<Result<HistoricoCombateResponse>> BuscarRelatorioFaccao(long id)
    {
        var relatorios = await _repository.GetAllAsync();
        var vitorias = relatorios.Where(r => r.FaccaoVencedoraId.Equals(id)).ToList();
        
        var derrotas = relatorios.Where(r => r.FaccaoVencedoraId != id).ToList();

        var relatorioDoPiloto = new List<RelatorioCombate>();
        relatorioDoPiloto.AddRange(vitorias);
        relatorioDoPiloto.AddRange(derrotas);
        var response = _mapper.ToHistoricoDto(vitorias, derrotas);
            
        return response;
    }
}
using Solution.Application.Contracts.Mapping;
using Solution.Application.Contracts.Persistence;
using Solution.Application.Contracts.Service;
using Solution.Application.Dto.Faccao;

namespace Solution.Application.Service.Faccao;

public class FaccaoService(
    IFaccaoRepository faccaoRepository,
    IFaccaoMapper mapper)
    :
        GenericService<SOGF.Domain.Model.Faccao, FaccaoRequest, FaccaoResponse>(faccaoRepository, mapper),
        IFaccaoService;
        

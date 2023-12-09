using AutoMapper;
using MyFinanceWeb.Application.DTOs.PlanoContaDTOs;
using MyFinanceWeb.Application.Interfaces;
using MyFinanceWeb.Domain.Entities;
using MyFinanceWeb.Domain.Repositories;

namespace MyFinanceWeb.Application.Services;

public class PlanoContaService : IPlanoContaService
{
    private readonly IMapper _mapper;
    private readonly IPlanoContaRepository _planoContaRepository;

    public PlanoContaService(IPlanoContaRepository planoContaRepository, IMapper mapper)
    {
        _mapper = mapper;
        _planoContaRepository = planoContaRepository ?? throw new ArgumentNullException(nameof(planoContaRepository));
    }

    public async Task<PlanoContaDTO> Create(PlanoContaDTO planoContaDTO)
    {
        PlanoConta planoConta = _mapper.Map<PlanoConta>(planoContaDTO);

        var planoContaCreated = await _planoContaRepository.Create(planoConta);

        PlanoContaDTO planoContaRead = _mapper.Map<PlanoContaDTO>(planoContaCreated);

        return planoContaRead;
    }

    public async Task<PlanoContaDTO> Delete(int id)
    {
        var planoContaDeleted = await _planoContaRepository.Delete(id);

        PlanoContaDTO planoContaRead = _mapper.Map<PlanoContaDTO>(planoContaDeleted);

        return planoContaRead;
    }

    public async Task<IEnumerable<PlanoContaDTO>> FindAll()
    {

        IEnumerable<PlanoConta> planoContas = await _planoContaRepository.FindAll();

        IEnumerable<PlanoContaDTO> planoContasRead = _mapper.Map<IEnumerable<PlanoContaDTO>>(planoContas);

        return planoContasRead;
    }

    public async Task<PlanoContaDTO> FindById(int id)
    {

        var planoConta = await _planoContaRepository.FindById(id);

        PlanoContaDTO planoContaRead = _mapper.Map<PlanoContaDTO>(planoConta);

        return planoContaRead;
    }

    public async Task<PlanoContaDTO> Update(PlanoContaDTO planoContaDTO)
    {
        PlanoConta planoConta = await _planoContaRepository.FindById(planoContaDTO.Id);

        planoConta = _mapper.Map(planoContaDTO, planoConta);

        var planoContaUpdated = await _planoContaRepository.Update(planoConta);

        PlanoContaDTO planoContaRead = _mapper.Map<PlanoContaDTO>(planoContaUpdated);

        return planoContaRead;
    }
}


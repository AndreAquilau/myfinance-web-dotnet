using MyFinanceWeb.Application.DTOs;
using MyFinanceWeb.Application.Interfaces;
using MyFinanceWeb.Domain.Repositories;
using AutoMapper;
using MyFinanceWeb.Domain.Entities;

namespace MyFinanceWeb.Application.Services;

public class PlanoContaService : IPlanoContaService
{
    private readonly IPlanoContaRepository _planoContaRepository;
    private readonly IMapper _mapper;
    public PlanoContaService(IPlanoContaRepository planoContaRepository, IMapper mapper)
    {
        _planoContaRepository = planoContaRepository;
        _mapper = mapper;
    }

    public async Task<PlanoContaDTO> Create(PlanoContaDTO transacao)
    {
        // Convert the DTO to the entity using AutoMapper
        var planoConta = _mapper.Map<PlanoConta>(transacao);

        // Call the repository to create the entity
        await _planoContaRepository.Create(planoConta);

        // Convert the entity back to DTO using AutoMapper
        var result = _mapper.Map<PlanoContaDTO>(planoConta);

        return result;
    }


    public async Task<PlanoContaDTO> Delete(int id)
    {
        var planoConta = _planoContaRepository.FindById(id);
        if (planoConta == null)
        {
            throw new Exception("Plano de Conta não encontrado");
        }
        var result = _mapper.Map<PlanoContaDTO>(planoConta);
        await _planoContaRepository.Delete(planoConta.Id);
        return result;
    }

    public async Task<IEnumerable<PlanoContaDTO>> FindAll()
    {
        // Call the repository to get all entities
        var planoContas = await _planoContaRepository.FindAll();

        // Convert the entities to DTOs using AutoMapper
        var result = _mapper.Map<IEnumerable<PlanoContaDTO>>(planoContas);

        return result;
    }

    public async Task<PlanoContaDTO> FindById(int id)
    {
        var planoConta = await _planoContaRepository.FindById(id);
        if (planoConta == null)
        {
            throw new Exception("Plano de Conta não encontrado");
        }
        var result = _mapper.Map<PlanoContaDTO>(planoConta);
        return result; 
    }

    public async Task<PlanoContaDTO> Update(PlanoContaDTO transacao)
    {
        var planoConta = await _planoContaRepository.FindById(transacao.Id);
        if (planoConta == null)
        {
            throw new Exception("Plano de Conta não encontrado");
        }

        // Update the entity with the DTO data using AutoMapper
        _mapper.Map(transacao, planoConta);

        // Call the repository to update the entity
        await _planoContaRepository.Update(planoConta);

        // Convert the entity back to DTO using AutoMapper
        var result = _mapper.Map<PlanoContaDTO>(planoConta);

        return result;
    }
}


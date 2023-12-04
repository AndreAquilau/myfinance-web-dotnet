using AutoMapper;
using MyFinanceWeb.Application.DTOs.PlanoContaDTOs;
using MyFinanceWeb.Application.Interfaces;
using MyFinanceWeb.Domain.Entities;
using MyFinanceWeb.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinanceWeb.Application.Services;

public class PlanoContaService : IPlanoContaService
{
    private readonly IMapper _mapper;
    private readonly IPlanoContaRepository _planoContaRepository;

    public PlanoContaService(IPlanoContaRepository planoContaRepository, IMapper mapper)
    {
        _mapper = mapper;
        _planoContaRepository = planoContaRepository;
    }

    public async Task<PlanoContaDTO> Create(PlanoContaDTO planoContaCreateDTO)
    {
        PlanoConta planoConta = _mapper.Map<PlanoConta>(planoContaCreateDTO);

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

        IEnumerable<PlanoConta> planoContas= await _planoContaRepository.FindAll();

        IEnumerable<PlanoContaDTO> planoContasRead = _mapper.Map<IEnumerable<PlanoContaDTO>>(planoContas);

        return planoContasRead;
    }

    public async Task<PlanoContaDTO> FindById(int id)
    {

        var planoConta = await _planoContaRepository.FindById(id);

        PlanoContaDTO planoContaRead = _mapper.Map<PlanoContaDTO>(planoConta);

        return planoContaRead;
    }

    public async Task<PlanoContaDTO> Update(PlanoContaDTO planoContaUpdateDTO)
    {
        PlanoConta planoConta = _mapper.Map<PlanoConta>(planoContaUpdateDTO);

        var planoContaUpdated = await _planoContaRepository.Update(planoConta);

        PlanoContaDTO planoContaRead = _mapper.Map<PlanoContaDTO>(planoContaUpdated);

        return planoContaRead;
    }
}


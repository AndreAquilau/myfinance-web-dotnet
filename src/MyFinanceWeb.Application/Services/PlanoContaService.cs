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

    public async Task<PlanoContaReadDTO> Create(PlanoContaCreateDTO planoContaCreateDTO)
    {
        PlanoConta planoConta = _mapper.Map<PlanoConta>(planoContaCreateDTO);

        var planoContaCreated = await _planoContaRepository.Create(planoConta);

        PlanoContaReadDTO planoContaRead = _mapper.Map<PlanoContaReadDTO>(planoContaCreated);

        return planoContaRead;
    }

    public async Task<PlanoContaReadDTO> Delete(int id)
    {
        var planoContaDeleted = await _planoContaRepository.Delete(id);

        PlanoContaReadDTO planoContaRead = _mapper.Map<PlanoContaReadDTO>(planoContaDeleted);

        return planoContaRead;
    }

    public async Task<IEnumerable<PlanoContaReadDTO>> FindAll()
    {

        IEnumerable<PlanoConta> planoContas= await _planoContaRepository.FindAll();

        IEnumerable<PlanoContaReadDTO> planoContasRead = _mapper.Map<IEnumerable<PlanoContaReadDTO>>(planoContas);

        return planoContasRead;
    }

    public async Task<PlanoContaReadDTO> FindById(int id)
    {

        var planoConta = await _planoContaRepository.FindById(id);

        PlanoContaReadDTO planoContaRead = _mapper.Map<PlanoContaReadDTO>(planoConta);

        return planoContaRead;
    }

    public async Task<PlanoContaReadDTO> Update(PlanoContaUpdateDTO planoContaUpdateDTO)
    {
        PlanoConta planoConta = _mapper.Map<PlanoConta>(planoContaUpdateDTO);

        var planoContaUpdated = await _planoContaRepository.Update(planoConta);

        PlanoContaReadDTO planoContaRead = _mapper.Map<PlanoContaReadDTO>(planoContaUpdated);

        return planoContaRead;
    }
}


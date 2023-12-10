using AutoMapper;
using MyFinanceWeb.Application.DTOs;
using MyFinanceWeb.Application.DTOs.TransacaoDTOs;
using MyFinanceWeb.Application.Interfaces;
using MyFinanceWeb.Domain.Entities;
using MyFinanceWeb.Domain.ObjectValue;
using MyFinanceWeb.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinanceWeb.Application.Services;

public class UtilService : IUtilService
{
    private readonly IMapper _mapper;
    private readonly IUtilRepository _utilRepository;
    public UtilService(IUtilRepository utilRepository, IMapper mapper)
    {
        _mapper = mapper;
        _utilRepository = utilRepository ?? throw new ArgumentNullException(nameof(utilRepository));
    }

    public async Task<DespesaReceitaDTO> DespesaReceita(DateOnly dataInit, DateOnly dataEnd)
    {
        var dispesaReceita = await _utilRepository.DespesaReceita(dataInit, dataEnd);
        var dispesaReceitaDto = _mapper.Map<DespesaReceitaDTO>(dispesaReceita);
        return dispesaReceitaDto;
    }
}


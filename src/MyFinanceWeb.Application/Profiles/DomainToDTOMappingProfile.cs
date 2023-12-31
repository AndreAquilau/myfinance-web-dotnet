﻿using AutoMapper;
using MyFinanceWeb.Application.DTOs;
using MyFinanceWeb.Application.DTOs.PlanoContaDTOs;
using MyFinanceWeb.Application.DTOs.TransacaoDTOs;
using MyFinanceWeb.Domain.Entities;
using MyFinanceWeb.Domain.ObjectValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinanceWeb.Application.Profiles;
public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile() {
        CreateMap<PlanoContaDTO, PlanoConta>().ReverseMap();
        CreateMap<TransacaoDTO, Transacao>().ReverseMap();
        CreateMap<DespesaReceitaDTO, DespesaReceita>().ReverseMap();
    }
}

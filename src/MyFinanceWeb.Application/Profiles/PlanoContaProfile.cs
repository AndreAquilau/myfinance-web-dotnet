using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyFinanceWeb.Application.DTOs.PlanoContaDTOs;
using MyFinanceWeb.Domain.Entities;

namespace MyFinanceWeb.Application.Profiles;

public class PlanoContaProfile : Profile
{
    public PlanoContaProfile()
    {
        CreateMap<PlanoContaDTO, PlanoConta>().ReverseMap();
        CreateMap<PlanoContaCreateDTO, PlanoConta>().ReverseMap();
        CreateMap<PlanoContaUpdateDTO, PlanoConta>().ReverseMap();
        CreateMap<PlanoContaReadDTO, PlanoConta>().ReverseMap();
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyFinanceWeb.Domain.Entities;

namespace MyFinanceWeb.Application.Profiles;

public class PlanoContaProfile : Profile
{
    public PlanoContaProfile()
    {
        CreateMap<PlanoContaProfile, PlanoConta>().ReverseMap();
    }
}


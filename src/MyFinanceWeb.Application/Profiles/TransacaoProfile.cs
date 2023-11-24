using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyFinanceWeb.Application.DTOs.TransacaoDTOs;

namespace MyFinanceWeb.Application.Profiles;
public class TransacaoProfile : Profile
{
    public TransacaoProfile()
    {
        CreateMap<TransacaoDTO, TransacaoProfile>();
    }
}
